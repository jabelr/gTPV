Public Class frmCajas
    Private swShowB As Boolean = False

#Region "Eventos Principales"

    Private Sub frmCajas_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyValue = Keys.Escape Then Me.Close()
    End Sub


    Private Sub frmCajas_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.Size = Screen.PrimaryScreen.WorkingArea.Size

        'Inicializo entorno
        Me.PnlBody.Left = CType(Me.Owner, frmMain).PnlBody.Left
        Me.PnlBody.Top = CType(Me.Owner, frmMain).PnlBody.Top + (IIf(My.m_opt.swNoteBook, Me.SplitContainer.Panel1.Height, 0))
        Me.PnlBody.Visible = True


        Me.DtFh_Desde.Value = CDate("01/" & Format(Now, "MM/yyyy"))
        Me.DtFh_Hasta.Value = Me.DtFh_Desde.Value.AddMonths(1).AddDays(-1)

        'Me.DtFh_Desde.Value = CDate("01/12/2013")
        'Me.DtFh_Hasta.Value = CDate("31/12/2013")


        Me.DtCajaActual_Desde.Value = Now.AddDays(-7)
        Me.DtCajaActual_Hasta.Value = Now

        'Cargo las cajas
        Me.Load_CajaActual()
        Me.Load_HistoricoCajas()

        Me.Load_InfoCajas()

        Me.RefreshEstates()

        Me.Tab.TabPages.Remove(Me.TabPage_MuestraCaja)
    End Sub
#End Region

#Region "Manejadores"
    'Manejador Principal (Shell)
    Private Sub ShellApp(ByVal command As String)
        Dim cmd As String = command.ToUpper
        Dim rst As ADODB.Recordset = Nothing

        Select Case cmd
            Case "VER_CAJA"                             'Muestro una Caja CERRADA
                Me.TabPage_MuestraCaja.Text = "Caja >> " & Me.GridHistorico.SelectedRows(0).Cells(1).Value
                If Not Me.Tab.TabPages.Contains(Me.TabPage_MuestraCaja) Then Me.Tab.TabPages.Add(Me.TabPage_MuestraCaja)

                Me.lblTOTAL_Caja.Text = Format(Me.GridHistorico.SelectedRows(0).Cells(4).Value, "0.00")
                Me.lblTOTAL_nCaja.Text = Format(Me.GridHistorico.SelectedRows(0).Cells(3).Value, "0")

                ' Pongo el total de la caja
                rst = My.m_db.GetRst("SELECT SUM(total) AS nTOT FROM db_tickets WHERE id_caja=" & Me.GridHistorico.SelectedRows(0).Cells(0).Value)
                If rst.RecordCount > 0 Then
                    Me.lblTOTAL_CajaNew.Text = Format(rst("nTOT").Value, "0.00")
                Else
                    Me.lblTOTAL_CajaNew.Text = Format(0, "0.00")
                End If
                My.m_db.CloseRst(rst)

                rst = My.m_db.GetRst("SELECT COUNT(id) AS nTOT FROM db_tickets WHERE id_caja=" & Me.GridHistorico.SelectedRows(0).Cells(0).Value)
                If rst.RecordCount > 0 Then
                    Me.lblTOTAL_nCajaNew.Text = Format(rst("nTOT").Value, "0")
                Else
                    Me.lblTOTAL_nCajaNew.Text = Format(0, "0")
                End If
                My.m_db.CloseRst(rst)


                'Cargo los detalles de la caja
                Me.Load_CajaHistoria(Me.GridHistorico.SelectedRows(0).Cells(0).Value)
                Me.Tab.SelectedTab = Me.TabPage_MuestraCaja

            Case "CLOSEOLD"
                Me.Tab.TabPages.Remove(Me.TabPage_MuestraCaja)

            Case "PRINTTICKET_CLOSED"                   'Imprimo un ticket cerrado
                My.PrintTicket(Me.GridCajaClosed.SelectedRows(0).Cells(0).Value)

            Case "DELETETICKET_CLOSED"
                My.m_db.Execute("DELETE FROM db_tickets WHERE id=" & Me.GridCajaClosed.SelectedRows(0).Cells(0).Value)


                'Recargo valores
                rst = My.m_db.GetRst("SELECT SUM(total) AS nTOT FROM db_tickets WHERE id_caja=" & Me.GridHistorico.SelectedRows(0).Cells(0).Value)
                If rst.RecordCount > 0 Then
                    Me.lblTOTAL_CajaNew.Text = Format(rst("nTOT").Value, "0.00")
                Else
                    Me.lblTOTAL_CajaNew.Text = Format(0, "0.00")
                End If
                My.m_db.CloseRst(rst)

                rst = My.m_db.GetRst("SELECT COUNT(id) AS nTOT FROM db_tickets WHERE id_caja=" & Me.GridHistorico.SelectedRows(0).Cells(0).Value)
                If rst.RecordCount > 0 Then
                    Me.lblTOTAL_nCajaNew.Text = Format(rst("nTOT").Value, "0")
                Else
                    Me.lblTOTAL_nCajaNew.Text = Format(0, "0")
                End If
                My.m_db.CloseRst(rst)

                'Recargo la caja actual
                Me.Load_CajaHistoria(Me.GridHistorico.SelectedRows(0).Cells(0).Value)



            Case "RELOAD"

            Case "RECALCULAR_CAJA"
                'Recalculo caja, cierro y recargo
                Me.RecalcularCaja()

                Me.Load_HistoricoCajas()
                Me.Tab.TabPages.Remove(Me.TabPage_MuestraCaja)





            Case "PRINTTICKET_ALL"
                If MsgBox("¿Esta seguro de que desea imprimir todos los tickets de la caja?", MsgBoxStyle.OkCancel + MsgBoxStyle.Question) <> MsgBoxResult.Ok Then Exit Sub
                rst = My.m_db.GetRst("SELECT id FROM db_tickets WHERE id_caja=" & Me.GridHistorico.SelectedRows(0).Cells(0).Value)
                While Not rst.EOF
                    My.PrintTicket(rst("id").Value)
                    rst.MoveNext()
                End While
                My.m_db.CloseRst(rst)



            Case "FACTURAR"                          'Generación de facturas
                Dim id As Integer = 0
                Select Case True
                    Case Me.Tab.SelectedTab Is Me.TabPage_MuestraCaja
                        If Me.GridCajaClosed.SelectedRows.Count <= 0 Then Exit Sub
                        id = Me.GridCajaClosed.SelectedRows(0).Cells(0).Value

                    Case Me.TabCajaActual.SelectedTab Is Me.TabCajaActual_Tickets
                        If Me.GridActual.SelectedRows.Count <= 0 Then Exit Sub
                        id = Me.GridActual.SelectedRows(0).Cells(0).Value

                    Case Me.TabCajaActual.SelectedTab Is Me.TabCajaActual_Pedidos
                        If Me.gridPedidos.SelectedRows.Count <= 0 Then Exit Sub
                        id = Me.gridPedidos.SelectedRows(0).Cells(0).Value
                End Select

                'Muestro el formulario de facturar
                frmPaneldeVentas_Facturar.IdRef = id
                frmPaneldeVentas_Facturar.ConfigureApp("facturar")
                frmPaneldeVentas_Facturar.ShowDialog(Me)
                If frmPaneldeVentas_Facturar.DialogResult = Windows.Forms.DialogResult.OK Then
                    Me.Load_CajaActual()
                    Me.RefreshEstates()
                    Me.Load_InfoCajas()
                End If
                frmPaneldeVentas_Facturar.Dispose()

            Case "PRINTTICKET"                      'Imprimo un ticket
                My.PrintTicket(Me.GridActual.SelectedRows(0).Cells(0).Value)

            Case "CANCELATICKET"                                      'Cancelo el ticket
                Dim id As Integer = 0
                Select Case True
                    Case Me.TabCajaActual.SelectedTab Is Me.TabCajaActual_Tickets
                        If Me.GridActual.SelectedRows.Count <= 0 Then Exit Sub
                        id = Me.GridActual.SelectedRows(0).Cells(0).Value
                    Case Me.TabCajaActual.SelectedTab Is Me.TabCajaActual_Pedidos
                        If Me.gridPedidos.SelectedRows.Count <= 0 Then Exit Sub
                        id = Me.gridPedidos.SelectedRows(0).Cells(0).Value
                End Select

                If MsgBox("¿Esta seguro de que desea dar como CANCELADO el ticket seleccionado?", MsgBoxStyle.OkCancel + MsgBoxStyle.Question, My.APP_NAME) <> MsgBoxResult.Ok Then Exit Select
                My.m_db.Execute("UPDATE db_tickets SET estado='CANCELADO' WHERE id=" & id)

                'Tengo que actualizar el stock
                rst = My.m_db.GetRst("SELECT id,id_articulo,id_articulo_combina,ud FROM db_tickets_lines WHERE id_ticket=" & id)
                While Not rst.EOF
                    My.UpdateAlmacen(rst("id_articulo").Value, -rst("ud").Value)
                    My.UpdateAlmacen(rst("id_articulo_combina").Value, -rst("ud").Value)
                    rst.MoveNext()
                End While
                My.m_db.CloseRst(rst)


                'Recargo la caja actual
                Me.Load_CajaActual()
                Me.Load_InfoCajas()

            Case "DELETETICKET"                                        'Elimino el ticket actual y recargo
                Dim id As Integer = 0
                Select Case True
                    Case Me.TabCajaActual.SelectedTab Is Me.TabCajaActual_Tickets
                        If Me.GridActual.SelectedRows.Count <= 0 Then Exit Sub
                        id = Me.GridActual.SelectedRows(0).Cells(0).Value
                    Case Me.TabCajaActual.SelectedTab Is Me.TabCajaActual_Pedidos
                        If Me.gridPedidos.SelectedRows.Count <= 0 Then Exit Sub
                        id = Me.gridPedidos.SelectedRows(0).Cells(0).Value
                End Select

                If MsgBox("¿Esta seguro de que desea eliminar el ticket seleccionado?", MsgBoxStyle.OkCancel + MsgBoxStyle.Question, My.APP_NAME) <> MsgBoxResult.Ok Then Exit Select
                My.m_db.Execute("DELETE FROM db_tickets WHERE id=" & id)

                'Tengo que actualizar el stock si previamente no estaba cancelado (SOLO TICKET NORMALES, NO DE PEDIDO)
                If Me.TabCajaActual.SelectedTab Is Me.TabCajaActual_Tickets Then
                    If Me.GridActual.SelectedRows(0).Cells(3).Value <> "CANCELADO" Then
                        rst = My.m_db.GetRst("SELECT id,id_articulo,id_articulo_combina,ud FROM db_tickets_lines WHERE id_ticket=" & id)
                        While Not rst.EOF
                            My.UpdateAlmacen(rst("id_articulo").Value, -rst("ud").Value)
                            My.UpdateAlmacen(rst("id_articulo_combina").Value, -rst("ud").Value)
                            rst.MoveNext()
                        End While
                        My.m_db.CloseRst(rst)
                    End If
                End If

                'Recargo la caja actual
                Me.Load_CajaActual()

            Case "CERRARCAJA"                                           'Cierro la caja actual
                'frmCajas_CerrarCaja.fhStart = Me.DtCajaActual_Desde.Value
                'frmCajas_CerrarCaja.fhEnd = Me.DtCajaActual_Hasta.Value
                frmCajas_CerrarCaja.ShowDialog(Me)
                If frmCajas_CerrarCaja.DialogResult <> Windows.Forms.DialogResult.OK Then
                    frmCajas_CerrarCaja.Dispose()
                    Exit Select
                End If
                Dim idAux As Integer = frmCajas_CerrarCaja.IdCaja
                frmCajas_CerrarCaja.Dispose()

                'Imprimo y Recargo valores
                Me.PrintCaja(idAux)

                If My.m_opt.swPrintResumen Then Me.PrintResumen(idAux)

                Me.Load_HistoricoCajas()
                Me.Load_CajaActual()
                Me.Load_InfoCajas()

                'Refresco estados
                Me.RefreshEstates()


            Case "PRINTCAJA"
                If Me.GridHistorico.SelectedRows.Count <= 0 Then Exit Select
                PrintCaja(Me.GridHistorico.SelectedRows(0).Cells(0).Value)

            Case "DELETECAJA"
                If Me.GridHistorico.SelectedRows.Count <= 0 Then Exit Select
                If MsgBox("¿Esta seguro de que desea eliminar la caja seleccionada?", MsgBoxStyle.OkCancel + MsgBoxStyle.Question, My.APP_NAME) <> MsgBoxResult.Ok Then Exit Select

                My.m_db.Execute("DELETE FROM db_cajas WHERE id=" & Me.GridHistorico.SelectedRows(0).Cells(0).Value)

                Me.Load_HistoricoCajas()

            Case "MINIMIZE"
                frm_AppIsMinimized.Show()

                Me.Owner.WindowState = FormWindowState.Minimized
                Me.WindowState = FormWindowState.Minimized

            Case "CLOSE"
                Me.Close()
            Case Else
                My.m_msg.MessageError(Me, "Comando de acción de " & cmd & " no controlada.")
        End Select
    End Sub
#End Region

#Region "Eventos Auxiliares"
    Private Sub Buttons_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtMin.Click, BtClose.Click, BtCerrarCaja.Click, BtDelCaja.Click, BtPrintCaja.Click, BtCloseBox.Click, BtPrintTicket.Click, BtDelTicket.Click, BtCancell.Click, BtFacturar.Click, BtShowCaja.Click, BtCancellOld.Click, BtPrintOldTicket.Click, btOld_Facturar.Click, BtPrintOldTicket_ALL.Click, BtReload.Click, Button1.Click, BtDelOldTicket.Click
        'Si no tiene establecido el tag mando un error
        If IsNothing(CType(sender, Button).Tag) OrElse CType(sender, Button).Tag.ToString.Length = 0 Then
            My.m_msg.MessageError(sender, "Tag de control de elemento no referenciado")
            Exit Sub
        End If

        ShellApp(CType(sender, Button).Tag.ToString)
    End Sub

    Private Sub m_logo_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles m_logo.DoubleClick
        Me.swShowB = True

        'Recargo informacion sobre las cajas
        Me.Load_HistoricoCajas()
        Me.Load_InfoCajas()
    End Sub

    Private Sub Tab_TabIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Tab.TabIndexChanged
        If Tab.SelectedTab Is Me.TabPage_HistoricoCajas Then Me.Load_HistoricoCajas()
    End Sub

    Private Sub GridActual_CellEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles GridActual.CellEnter
        Me.CheckBtStates_CajaActual()
    End Sub


    Private Sub DtFh_Desde_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DtFh_Desde.ValueChanged
        If Me.Tab.SelectedTab Is Me.TabPage_HistoricoCajas Then Me.Load_HistoricoCajas() : Me.Load_InfoCajas()
    End Sub

    Private Sub DtFh_Hasta_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DtFh_Hasta.ValueChanged
        If Me.Tab.SelectedTab Is Me.TabPage_HistoricoCajas Then Me.Load_HistoricoCajas() : Me.Load_InfoCajas()
    End Sub

    Private Sub DtCajaActual_Desde_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DtCajaActual_Desde.ValueChanged
        If Me.Tab.SelectedTab Is Me.TabPage_CajaActual Then Me.Load_CajaActual() : Me.Load_InfoCajas()
    End Sub

    Private Sub DtCajaActual_Hasta_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DtCajaActual_Hasta.ValueChanged
        If Me.Tab.SelectedTab Is Me.TabPage_CajaActual Then Me.Load_CajaActual() : Me.Load_InfoCajas()
    End Sub
#End Region

#Region "Funciones"
    'Funcion que me obtiene informacion sobre las cajas
    Private Sub Load_InfoCajas()
        On Error Resume Next
        Dim rst As ADODB.Recordset, str As String = ""
        Dim pvp_ticket As Double = 0, pvp_albaran As Double = 0

        '### Obtengo informacion sobre la Caja ACTUAL
        ''Total de Tickets
        'rst = My.m_db.GetRst("SELECT COUNT(id) AS n_tot FROM db_tickets WHERE  (db_tickets.estado<>'PENDIENTE' AND db_tickets.estado<>'FACTURADO')  AND id_caja=-1")
        'str = "Se han realizado un total de " & rst("n_tot").Value & " Tickets"
        'My.m_db.CloseRst(rst)

        'Total de Tickets
        rst = My.m_db.GetRst("SELECT COUNT(id) AS n_tot FROM db_tickets WHERE  (db_tickets.estado<>'PENDIENTE' AND db_tickets.estado<>'FACTURADO')  AND id_caja=-1")
        str = "Se han realizado un total de " & rst("n_tot").Value & " Tickets"
        My.m_db.CloseRst(rst)

        ''Total de compras en los ultimos 7 dias
        'rst = My.m_db.GetRst("SELECT COUNT(id) AS n_tot FROM db_albaranes_compra WHERE fh_albaran>=#" & Format(Me.DtCajaActual_Desde.Value, "MM-dd-yyyy") & " 00:00# AND fh_albaran<=#" & Format(Me.DtCajaActual_Hasta.Value, "MM-dd-yyyy") & " 23:59#")
        'str &= " y " & rst("n_tot").Value & " albaranes de Compra"
        'My.m_db.CloseRst(rst)

        'Importe Total de tickets
        rst = My.m_db.GetRst("SELECT sum(total) as tot FROM db_tickets WHERE estado='FINALIZADO' AND id_caja=-1 AND ((db_tickets.fh_finaliza>=#" & Format(Me.DtCajaActual_Desde.Value, "MM-dd-yyyy") & " 00:00# AND db_tickets.fh_finaliza<=#" & Format(Me.DtCajaActual_Hasta.Value, "MM-dd-yyyy") & " 23:59#))")
        If Not IsDBNull(rst("tot").Value) Then pvp_ticket = rst("tot").Value
        My.m_db.CloseRst(rst)

        ''Importe Total de Albaranes
        'rst = My.m_db.GetRst("SELECT sum(total) as tot FROM db_albaranes_compra WHERE fh_albaran>=#" & Format(Me.DtCajaActual_Desde.Value, "MM-dd-yyyy") & " 00:00# AND fh_albaran<=#" & Format(Me.DtCajaActual_Hasta.Value, "MM-dd-yyyy") & " 23:59#")
        'If Not IsDBNull(rst("tot").Value) Then pvp_albaran = rst("tot").Value
        'My.m_db.CloseRst(rst)

        str &= " acumulando un importe total de " & Format(pvp_ticket - pvp_albaran, "0.00") & "" & System.Threading.Thread.CurrentThread.CurrentCulture.NumberFormat.CurrencySymbol & " (" & Format(pvp_ticket, "0.00") & "-" & Format(pvp_albaran, "0.00") & ")"
        Me.LblInfoCaja.Text = str



        ''### Obtengo la informacion sobre las TODAS las Cajas
        'Total de tickets
        rst = My.m_db.GetRst("SELECT COUNT(db_tickets.id) AS n_tot FROM db_tickets,db_cajas WHERE db_tickets.id_caja=db_cajas.id AND db_cajas.fh_alta>=#" & Format(Me.DtFh_Desde.Value, "MM-dd-yyyy") & " 00:00# AND db_cajas.fh_alta<=#" & Format(Me.DtFh_Hasta.Value, "MM-dd-yyyy") & " 23:59#")
        str = "Se han realizado un total de " & rst("n_tot").Value & " Tickets"
        My.m_db.CloseRst(rst)

        'rst = My.m_db.GetRst("SELECT COUNT(id) AS n_tot FROM db_albaranes_compra WHERE fh_albaran>=#" & Format(Me.DtFh_Desde.Value, "MM-dd-yyyy") & " 00:00# AND fh_albaran<=#" & Format(Me.DtFh_Hasta.Value, "MM-dd-yyyy") & " 23:59#")
        'str &= " y " & rst("n_tot").Value & " albaranes de Compra"
        'My.m_db.CloseRst(rst)

        'Total de cajas
        rst = My.m_db.GetRst("SELECT COUNT(id) AS n_tot FROM db_cajas WHERE db_cajas.fh_alta>=#" & Format(Me.DtFh_Desde.Value, "MM-dd-yyyy") & " 00:00# AND db_cajas.fh_alta<=#" & Format(Me.DtFh_Hasta.Value, "MM-dd-yyyy") & " 23:59#")
        str &= " en un total de " & rst("n_tot").Value & " Cajas,"
        My.m_db.CloseRst(rst)

        ''Importe Total de Albaranes
        'rst = My.m_db.GetRst("SELECT sum(total) as tot FROM db_albaranes_compra WHERE fh_albaran>=#" & Format(Me.DtFh_Desde.Value, "MM-dd-yyyy") & " 00:00# AND fh_albaran<=#" & Format(Me.DtFh_Hasta.Value, "MM-dd-yyyy") & " 23:59#")
        'pvp_albaran = rst("tot").Value
        'My.m_db.CloseRst(rst)

        'Importe total
        rst = My.m_db.GetRst("SELECT sum(" & IIf(Me.swShowB, "total_real", "total") & ") as tot FROM db_cajas WHERE db_cajas.fh_alta>=#" & Format(Me.DtFh_Desde.Value, "MM-dd-yyyy") & " 00:00# AND db_cajas.fh_alta<=#" & Format(Me.DtFh_Hasta.Value, "MM-dd-yyyy") & " 23:59#")
        str &= " generando un total " & IIf(Me.swShowB, "REAL ", "") & "de " & Format(rst("tot").Value - pvp_albaran, "0.00") & "" & System.Threading.Thread.CurrentThread.CurrentCulture.NumberFormat.CurrencySymbol & " (" & Format(rst("tot").Value, "0.00") & "-" & Format(pvp_albaran, "0.00") & ")"
        My.m_db.CloseRst(rst)

        Me.LblInfoCajas.Text = str
    End Sub

    Private Sub RefreshEstates()
        'Si no hay nada, no muestro
        Dim rst As ADODB.Recordset = My.m_db.GetRst("SELECT id FROM db_tickets WHERE estado='FINALIZADO' AND id_caja=-1")
        'Me.BtCerrarCaja.Visible = (rst.RecordCount > 0)
        Me.BtCloseBox.Enabled = (rst.RecordCount > 0)
        Me.BtFacturar.Visible = (rst.RecordCount > 0)
        My.m_db.CloseRst(rst)
    End Sub

    'Funcion de Chequeo de los estados de los botones sobre la Caja Actual
    Private Sub CheckBtStates_CajaActual()
        'Establezco estados "Default"
        Me.BtDelTicket.Enabled = False
        Me.BtCancell.Enabled = False
        Me.BtPrintTicket.Enabled = False

        'Obtengo el ID del ticket
        Dim id As Integer = 0
        Select Case True
            Case Me.TabCajaActual.SelectedTab Is Me.TabCajaActual_Tickets
                If Me.GridActual.SelectedRows.Count <= 0 Then Exit Sub
                id = Me.GridActual.SelectedRows(0).Cells(0).Value
            Case Me.TabCajaActual.SelectedTab Is Me.TabCajaActual_Pedidos
                If Me.gridPedidos.SelectedRows.Count <= 0 Then Exit Sub
                id = Me.gridPedidos.SelectedRows(0).Cells(0).Value
            Case Else
                MsgBox("Operación no permitida.", MsgBoxStyle.Critical)
                Exit Sub
        End Select



        If Me.GridActual.SelectedRows(0).Cells.Count < 3 Then Exit Sub
        'Deshabilitados cuando el ticket no esta cancelado
        Dim sw As Boolean = (Me.GridActual.SelectedRows(0).Cells(3).Value <> "CANCELADO")
        Me.BtCancell.Enabled = sw
        Me.BtPrintTicket.Enabled = sw

        Me.BtDelTicket.Enabled = True

        'Permito facturar si no es un ticket directo
        Me.BtFacturar.Enabled = (Me.GridActual.SelectedRows(0).Cells(3).Value <> "CANCELADO")
        Me.PnlInfo.Visible = Me.GridActual.SelectedRows(0).Cells(3).Value <> "CANCELADO"
    End Sub
#End Region

#Region "Administracion de las Cajas"
    'Cargo los tickets de la caja actual
    Private Sub Load_CajaActual()
        Dim m_Table As DataTable            'Tabla de datos
        Dim rst As ADODB.Recordset
        Dim da As Data.OleDb.OleDbDataAdapter
        Dim ColStyle As DataGridViewColumn
        Dim Cell As DataGridViewCell = New DataGridViewTextBoxCell()

        'El estilo de las celdas
        Dim m_Style As New DataGridViewCellStyle
        With m_Style
            .BackColor = System.Drawing.SystemColors.GradientActiveCaption
            .ForeColor = System.Drawing.SystemColors.ControlText
            .Font = New System.Drawing.Font("Verdana", 10)
            .Padding = New Padding(3, 3, 3, 3)
        End With

        Dim m_Style_alt As New DataGridViewCellStyle
        With m_Style_alt
            .BackColor = System.Drawing.SystemColors.GradientInactiveCaption
            .ForeColor = System.Drawing.SystemColors.ControlText
            .Font = New System.Drawing.Font("Verdana", 10)
            .Padding = New Padding(3, 3, 3, 3)
        End With

        'Preconfiguramos el grid de las ventas
        With Me.GridActual
            .Columns.Clear()
            .AutoGenerateColumns = False
            .AlternatingRowsDefaultCellStyle = m_Style_alt
            .RowTemplate.Height = 30

            'El id
            ColStyle = New DataGridViewColumn()
            ColStyle.DataPropertyName = "id"
            ColStyle.HeaderText = "Id."
            ColStyle.Width = 0
            ColStyle.DefaultCellStyle = m_Style
            ColStyle.CellTemplate = Cell
            .Columns.Add(ColStyle)

            'La referencia
            ColStyle = New DataGridViewColumn()
            ColStyle.DataPropertyName = "n_ticket"
            ColStyle.HeaderText = "Ticket"
            ColStyle.Width = 100
            ColStyle.DefaultCellStyle = m_Style
            ColStyle.CellTemplate = Cell
            .Columns.Add(ColStyle)

            'Fecha de creacion
            ColStyle = New DataGridViewColumn()
            ColStyle.DataPropertyName = "fh_alta"
            ColStyle.HeaderText = "Fecha de Ticket"
            ColStyle.Width = 155
            ColStyle.DefaultCellStyle = m_Style
            ColStyle.CellTemplate = Cell
            .Columns.Add(ColStyle)

            'El estado
            ColStyle = New DataGridViewColumn()
            ColStyle.DataPropertyName = "estado"
            ColStyle.HeaderText = "Estado"
            ColStyle.Width = 115
            ColStyle.DefaultCellStyle = m_Style
            ColStyle.CellTemplate = Cell
            .Columns.Add(ColStyle)

            'El empleado
            ColStyle = New DataGridViewColumn()
            ColStyle.DataPropertyName = "name"
            ColStyle.HeaderText = "Empleado"
            ColStyle.Width = 180
            ColStyle.DefaultCellStyle = m_Style
            ColStyle.CellTemplate = Cell
            .Columns.Add(ColStyle)

            'El total
            ColStyle = New DataGridViewColumn()
            ColStyle.DataPropertyName = "total"
            ColStyle.HeaderText = "Total"
            ColStyle.Width = 70
            ColStyle.DefaultCellStyle = m_Style
            ColStyle.CellTemplate = Cell
            .Columns.Add(ColStyle)

            'El id en de la mesa
            ColStyle = New DataGridViewColumn()
            ColStyle.DataPropertyName = "id_referencia"
            ColStyle.HeaderText = "Ref Mesa"
            ColStyle.Visible = False
            ColStyle.DefaultCellStyle = m_Style
            ColStyle.CellTemplate = Cell
            .Columns.Add(ColStyle)
        End With

        'Asignamos los datos
        rst = My.m_db.GetRst("SELECT db_tickets.id,db_tickets.n_ticket,db_tickets.fh_alta,db_tickets.estado,name,total,id_referencia " & _
                                    "FROM db_tickets,db_usuarios " & _
                                        "WHERE db_usuarios.id=db_tickets.id_user AND db_tickets.estado<>'FACTURADO' AND id_pedido=0 AND id_caja=-1 AND id_contable=" & My.m_app.GetValue("id_contable") & " AND ((db_tickets.fh_finaliza>=#" & Format(Me.DtCajaActual_Desde.Value, "MM-dd-yyyy") & " 00:00# AND db_tickets.fh_finaliza<=#" & Format(Me.DtCajaActual_Hasta.Value, "MM-dd-yyyy") & " 23:59#))" & _
                                        " AND NOT tipo " & _
                                    " ORDER BY db_tickets.estado DESC, db_tickets.fh_finaliza DESC,db_tickets.fh_alta DESC")
        'rst = My.m_db.GetRst("SELECT db_tickets.id,db_tickets.n_ticket,db_tickets.fh_alta,db_tickets.estado,name,total,id_referencia FROM db_tickets,db_usuarios WHERE db_usuarios.id=db_tickets.id_user AND db_tickets.estado<>'FACTURADO' AND id_pedido=0 AND id_caja=-1 AND id_contable=" & My.m_app.GetValue("id_contable") & " AND ((db_tickets.fh_finaliza>=#" & Format(Me.DtCajaActual_Desde.Value, "MM-dd-yyyy") & " 00:00# AND db_tickets.fh_finaliza<=#" & Format(Me.DtCajaActual_Hasta.Value, "MM-dd-yyyy") & " 23:59#) OR isnull(db_tickets.fh_finaliza)) order by db_tickets.estado DESC, db_tickets.fh_finaliza DESC,db_tickets.fh_alta DESC")

        If IsNothing(rst) Then Exit Sub

        m_Table = New DataTable("m_tabla")
        da = New Data.OleDb.OleDbDataAdapter
        da.Fill(m_Table, rst)
        Me.GridActual.DataSource = m_Table


        'Permito borrar y volver a imprimir resumen
        Dim sw As Boolean = (Me.GridActual.RowCount > 0)
        'Me.BtCancell.Enabled = sw
        'Me.BtPrintTicket.Enabled = sw
        'Me.BtDelTicket.Enabled = sw


        'Preconfiguramos el grid de las ventas
        With Me.gridPedidos
            .Columns.Clear()
            .AutoGenerateColumns = False
            .AlternatingRowsDefaultCellStyle = m_Style_alt
            .RowTemplate.Height = 30

            'El id
            ColStyle = New DataGridViewColumn()
            ColStyle.DataPropertyName = "id"
            ColStyle.HeaderText = "Id."
            ColStyle.Width = 0
            ColStyle.DefaultCellStyle = m_Style
            ColStyle.CellTemplate = Cell
            .Columns.Add(ColStyle)

            'La referencia
            ColStyle = New DataGridViewColumn()
            ColStyle.DataPropertyName = "n_ticket"
            ColStyle.HeaderText = "Ticket"
            ColStyle.Width = 75
            ColStyle.DefaultCellStyle = m_Style
            ColStyle.CellTemplate = Cell
            .Columns.Add(ColStyle)

            'Fecha de creacion
            ColStyle = New DataGridViewColumn()
            ColStyle.DataPropertyName = "fh_alta"
            ColStyle.HeaderText = "Fecha Pedido"
            ColStyle.Width = 145
            ColStyle.DefaultCellStyle = m_Style
            ColStyle.CellTemplate = Cell
            .Columns.Add(ColStyle)

            'El cliente
            ColStyle = New DataGridViewColumn()
            ColStyle.DataPropertyName = "name_fiscal"
            ColStyle.HeaderText = "Cliente"
            ColStyle.Width = 220
            ColStyle.DefaultCellStyle = m_Style
            ColStyle.CellTemplate = Cell
            .Columns.Add(ColStyle)

            'El empleado
            ColStyle = New DataGridViewColumn()
            ColStyle.DataPropertyName = "name"
            ColStyle.HeaderText = "Empleado"
            ColStyle.Width = 185
            ColStyle.DefaultCellStyle = m_Style
            ColStyle.CellTemplate = Cell
            .Columns.Add(ColStyle)

            'El estado
            ColStyle = New DataGridViewColumn()
            ColStyle.DataPropertyName = "estado"
            ColStyle.HeaderText = "Estado"
            ColStyle.Width = 105
            ColStyle.DefaultCellStyle = m_Style
            ColStyle.CellTemplate = Cell
            .Columns.Add(ColStyle)

            'El total
            ColStyle = New DataGridViewColumn()
            ColStyle.DataPropertyName = "total"
            ColStyle.HeaderText = "Total"
            ColStyle.Width = 65
            ColStyle.DefaultCellStyle = m_Style
            ColStyle.CellTemplate = Cell
            .Columns.Add(ColStyle)

            'El id en de la mesa
            ColStyle = New DataGridViewColumn()
            ColStyle.DataPropertyName = "id_referencia"
            ColStyle.HeaderText = "Ref Mesa"
            ColStyle.Visible = False
            ColStyle.DefaultCellStyle = m_Style
            ColStyle.CellTemplate = Cell
            .Columns.Add(ColStyle)
        End With

        'Asignamos los datos
        'rst = My.m_db.GetRst("SELECT db_tickets.id,db_tickets.n_ticket,db_tickets.fh_alta,db_tickets.estado,total,id_referencia FROM db_tickets,db_usuarios WHERE db_usuarios.id=db_tickets.id_user AND db_tickets.estado<>'FACTURADO' AND id_pedido>0 AND id_caja=-1 AND id_contable=" & My.m_app.GetValue("id_contable") & " AND ((db_tickets.fh_finaliza>=#" & Format(Me.DtCajaActual_Desde.Value, "MM-dd-yyyy") & " 00:00# AND db_tickets.fh_finaliza<=#" & Format(Me.DtCajaActual_Hasta.Value, "MM-dd-yyyy") & " 23:59#) OR isnull(db_tickets.fh_finaliza)) order by db_tickets.estado DESC, db_tickets.fh_finaliza DESC,db_tickets.fh_alta DESC")
        rst = My.m_db.GetRst("SELECT db_pedidos.*,db_tickets.total,db_clientes.name_fiscal,db_clientes.id AS idCliente,db_tickets.id AS idTicket,db_tickets.n_ticket,db_tickets.id_user AS idUser,db_usuarios.name " & _
                                "FROM db_pedidos,db_clientes,db_tickets,db_usuarios " & _
                                    "WHERE " & _
                                        "db_tickets.id=db_pedidos.id_ticket AND " & _
                                        "db_pedidos.id_cliente=db_clientes.id AND db_tickets.id_caja=-1 AND " & _
                                        "db_usuarios.id=db_tickets.id_user " & _
                                    "ORDER BY db_pedidos.estado DESC,db_pedidos.id DESC, db_clientes.name_fiscal ASC")

        'rst = My.m_db.GetRst("SELECT db_tickets.id,db_tickets.n_ticket,db_tickets.fh_alta,db_tickets.estado,total,id_referencia " & _
        '            "FROM db_pedidos,db_tickets,db_usuarios " & _
        '                "WHERE " & _
        '                    "db_pedidos.id=db_tickets.id_pedido AND " & _
        '                    "db_usuarios.id=db_tickets.id_user AND " & _
        '                    "db_tickets.estado<>'FACTURADO' AND id_pedido>0 AND id_caja=-1 AND id_contable=" & My.m_app.GetValue("id_contable") & " AND ((db_tickets.fh_finaliza>=#" & Format(Me.DtCajaActual_Desde.Value, "MM-dd-yyyy") & " 00:00# AND db_tickets.fh_finaliza<=#" & Format(Me.DtCajaActual_Hasta.Value, "MM-dd-yyyy") & " 23:59#) OR isnull(db_tickets.fh_finaliza)) order by db_tickets.estado DESC, db_tickets.fh_finaliza DESC,db_tickets.fh_alta DESC")

        If IsNothing(rst) Then Exit Sub

        m_Table = New DataTable("m_tabla")
        da = New Data.OleDb.OleDbDataAdapter
        da.Fill(m_Table, rst)
        Me.gridPedidos.DataSource = m_Table


        '### ACUMULADO DE COMPRAS DE MARCAS DE TABACO
        'Preconfiguramos el grid de las ventas
        With Me.gridMarcas
            .Columns.Clear()
            .AutoGenerateColumns = False
            .AlternatingRowsDefaultCellStyle = m_Style_alt
            .RowTemplate.Height = 30

            'El id
            ColStyle = New DataGridViewColumn()
            ColStyle.DataPropertyName = "id"
            ColStyle.HeaderText = "Id."
            ColStyle.Width = 0
            ColStyle.DefaultCellStyle = m_Style
            ColStyle.CellTemplate = Cell
            .Columns.Add(ColStyle)

            'La referencia
            ColStyle = New DataGridViewColumn()
            ColStyle.DataPropertyName = "name"
            ColStyle.HeaderText = "marca"
            ColStyle.Width = 220
            ColStyle.DefaultCellStyle = m_Style
            ColStyle.CellTemplate = Cell
            .Columns.Add(ColStyle)

            'Unidades vendidats
            ColStyle = New DataGridViewColumn()
            ColStyle.DataPropertyName = "ud"
            ColStyle.HeaderText = "Ud."
            ColStyle.Width = 65
            ColStyle.DefaultCellStyle = m_Style
            ColStyle.CellTemplate = Cell
            .Columns.Add(ColStyle)

        End With

        'Asignamos los datos

        'rst = My.m_db.GetRst("SELECT  " & _
        '                        "FROM estanco_marcas,db_tickets,db_tickets_lines " & _
        '                            "WHERE " & _
        '                                "db_tickets.id=db_pedidos.id_ticket AND " & _
        '                            "ORDER BY db_pedidos.estado DESC,db_pedidos.id DESC, db_clientes.name_fiscal ASC")


        If IsNothing(rst) Then Exit Sub

        m_Table = New DataTable("m_tabla")
        da = New Data.OleDb.OleDbDataAdapter
        da.Fill(m_Table, rst)
        Me.gridMarcas.DataSource = m_Table


        Me.CheckBtStates_CajaActual()
    End Sub

    'Cargo las Cajas existentes
    Private Sub Load_HistoricoCajas()
        Dim m_Table As DataTable            'Tabla de datos
        Dim rst As ADODB.Recordset
        Dim da As Data.OleDb.OleDbDataAdapter
        Dim ColStyle As DataGridViewColumn
        Dim Cell As DataGridViewCell = New DataGridViewTextBoxCell()

        'El estilo de las celdas
        Dim m_Style As New DataGridViewCellStyle
        With m_Style
            .BackColor = System.Drawing.SystemColors.GradientActiveCaption
            .ForeColor = System.Drawing.SystemColors.ControlText
            .Font = New System.Drawing.Font("Verdana", 12)
            .Padding = New Padding(3, 1, 1, 5)
        End With

        Dim m_Style_alt As New DataGridViewCellStyle
        With m_Style_alt
            .BackColor = System.Drawing.SystemColors.GradientInactiveCaption
            .ForeColor = System.Drawing.SystemColors.ControlText
            .Font = New System.Drawing.Font("Verdana", 12)
            .Padding = New Padding(3, 1, 1, 5)
        End With

        'Preconfiguramos el grid de las ventas
        With Me.GridHistorico
            .Columns.Clear()
            .AutoGenerateColumns = False
            .AlternatingRowsDefaultCellStyle = m_Style_alt
            .RowTemplate.Height = 31

            'El id
            ColStyle = New DataGridViewColumn()
            ColStyle.DataPropertyName = "id"
            ColStyle.HeaderText = "Referencia"
            ColStyle.Width = 75
            ColStyle.DefaultCellStyle = m_Style
            ColStyle.CellTemplate = Cell
            .Columns.Add(ColStyle)

            'La caja que es
            ColStyle = New DataGridViewColumn()
            ColStyle.DataPropertyName = "ncaja"
            ColStyle.HeaderText = "Nº Caja"
            ColStyle.Width = 110
            ColStyle.DefaultCellStyle = m_Style
            ColStyle.CellTemplate = Cell
            .Columns.Add(ColStyle)

            'Fecha de creacion
            ColStyle = New DataGridViewColumn()
            ColStyle.DataPropertyName = "fh_alta"
            ColStyle.HeaderText = "Fecha de Cierre"
            ColStyle.Width = 170
            ColStyle.DefaultCellStyle = m_Style
            ColStyle.CellTemplate = Cell
            .Columns.Add(ColStyle)

            'El nº de tickets
            ColStyle = New DataGridViewColumn()
            ColStyle.DataPropertyName = "n_tickets"
            ColStyle.HeaderText = "Nº de Tickets"
            ColStyle.Width = 90
            ColStyle.DefaultCellStyle = m_Style
            ColStyle.CellTemplate = Cell
            .Columns.Add(ColStyle)

            'El total
            ColStyle = New DataGridViewColumn()
            ColStyle.DataPropertyName = "total"
            ColStyle.HeaderText = "Total"
            ColStyle.Width = 100
            ColStyle.DefaultCellStyle = m_Style
            ColStyle.CellTemplate = Cell
            .Columns.Add(ColStyle)

            If Me.swShowB Then          'El total Real
                ColStyle = New DataGridViewColumn()
                ColStyle.DataPropertyName = "total_real"
                ColStyle.HeaderText = "Total Real"
                ColStyle.Width = 100
                ColStyle.DefaultCellStyle = m_Style
                ColStyle.CellTemplate = Cell
                .Columns.Add(ColStyle)
            End If
        End With

        'Asignamos los datos
        rst = My.m_db.GetRst("SELECT id,ncaja,fh_alta,n_tickets,total" & IIf(Me.swShowB, ",total_real", "") & " FROM db_cajas WHERE id_contable=" & My.m_app.GetValue("id_contable") & " AND db_cajas.fh_alta>=#" & Format(Me.DtFh_Desde.Value, "MM-dd-yyyy") & " 00:00# AND db_cajas.fh_alta<=#" & Format(Me.DtFh_Hasta.Value, "MM-dd-yyyy") & " 23:59# order by ncaja desc")
        If IsNothing(rst) Then Exit Sub

        m_Table = New DataTable("m_tabla")
        da = New Data.OleDb.OleDbDataAdapter
        da.Fill(m_Table, rst)
        Me.GridHistorico.DataSource = m_Table

        'Permito borrar y volver a imprimir resumen
        Me.BtDelCaja.Enabled = (Me.GridHistorico.RowCount > 0)
        Me.BtShowCaja.Enabled = (Me.GridHistorico.RowCount > 0)
        Me.BtPrintCaja.Enabled = (Me.GridHistorico.RowCount > 0)
    End Sub

#Region "Cajas Pasadas"
    Private Sub Load_CajaHistoria(ByVal id As Integer)
        Dim m_Table As DataTable            'Tabla de datos
        Dim rst As ADODB.Recordset
        Dim da As Data.OleDb.OleDbDataAdapter
        Dim ColStyle As DataGridViewColumn
        Dim Cell As DataGridViewCell = New DataGridViewTextBoxCell()

        'El estilo de las celdas
        Dim m_Style As New DataGridViewCellStyle
        With m_Style
            .BackColor = System.Drawing.SystemColors.GradientActiveCaption
            .ForeColor = System.Drawing.SystemColors.ControlText
            .Font = New System.Drawing.Font("Verdana", 10)
            .Padding = New Padding(3, 1, 1, 5)
        End With

        Dim m_Style_alt As New DataGridViewCellStyle
        With m_Style_alt
            .BackColor = System.Drawing.SystemColors.GradientInactiveCaption
            .ForeColor = System.Drawing.SystemColors.ControlText
            .Font = New System.Drawing.Font("Verdana", 10)
            .Padding = New Padding(3, 1, 1, 5)
        End With

        'Preconfiguramos el grid de las ventas
        With Me.GridCajaClosed
            .Columns.Clear()
            .AutoGenerateColumns = False
            .AlternatingRowsDefaultCellStyle = m_Style_alt
            .RowTemplate.Height = 31

            'El id
            ColStyle = New DataGridViewColumn()
            ColStyle.DataPropertyName = "id"
            ColStyle.HeaderText = "Id."
            ColStyle.Width = 0
            ColStyle.DefaultCellStyle = m_Style
            ColStyle.CellTemplate = Cell
            .Columns.Add(ColStyle)

            'La referencia
            ColStyle = New DataGridViewColumn()
            ColStyle.DataPropertyName = "n_ticket"
            ColStyle.HeaderText = "Referencia"
            ColStyle.Width = 80
            ColStyle.DefaultCellStyle = m_Style
            ColStyle.CellTemplate = Cell
            .Columns.Add(ColStyle)

            'Fecha de creacion
            ColStyle = New DataGridViewColumn()
            ColStyle.DataPropertyName = "fh_alta"
            ColStyle.HeaderText = "Fecha de Ticket"
            ColStyle.Width = 160
            ColStyle.DefaultCellStyle = m_Style
            ColStyle.CellTemplate = Cell
            .Columns.Add(ColStyle)

            ''Fecha de terminacion
            'ColStyle = New DataGridViewColumn()
            'ColStyle.DataPropertyName = "fh_finaliza"
            'ColStyle.HeaderText = "Fecha Terminado"
            'ColStyle.Width = 160
            'ColStyle.DefaultCellStyle = m_Style
            'ColStyle.CellTemplate = Cell
            '.Columns.Add(ColStyle)

            'El estado
            ColStyle = New DataGridViewColumn()
            ColStyle.DataPropertyName = "estado"
            ColStyle.HeaderText = "Estado"
            ColStyle.Width = 115
            ColStyle.DefaultCellStyle = m_Style
            ColStyle.CellTemplate = Cell
            .Columns.Add(ColStyle)

            ''La mesa
            'ColStyle = New DataGridViewColumn()
            'ColStyle.DataPropertyName = "name_mesa"
            'ColStyle.HeaderText = "Mesa"
            'ColStyle.Width = 90
            'ColStyle.DefaultCellStyle = m_Style
            'ColStyle.CellTemplate = Cell
            '.Columns.Add(ColStyle)

            'El total
            ColStyle = New DataGridViewColumn()
            ColStyle.DataPropertyName = "total"
            ColStyle.HeaderText = "Total"
            ColStyle.Width = 70
            ColStyle.DefaultCellStyle = m_Style
            ColStyle.CellTemplate = Cell
            .Columns.Add(ColStyle)

            'El id en de la mesa
            ColStyle = New DataGridViewColumn()
            ColStyle.DataPropertyName = "id_referencia"
            ColStyle.HeaderText = "Ref Mesa"
            ColStyle.Visible = False
            ColStyle.DefaultCellStyle = m_Style
            ColStyle.CellTemplate = Cell
            .Columns.Add(ColStyle)

            'El empleado
            ColStyle = New DataGridViewColumn()
            ColStyle.DataPropertyName = "name"
            ColStyle.HeaderText = "Empleado"
            ColStyle.Width = 165
            ColStyle.DefaultCellStyle = m_Style
            ColStyle.CellTemplate = Cell
            .Columns.Add(ColStyle)
        End With

        'Asignamos los datos
        'rst = My.m_db.GetRst("SELECT db_tickets.id,db_tickets.n_ticket,db_tickets.fh_alta,db_tickets.fh_finaliza,db_tickets.estado,name_mesa,name,total,id_referencia FROM db_tickets,db_usuarios WHERE db_usuarios.id=db_tickets.id_user AND id_caja=" & id & " order by db_tickets.estado DESC, db_tickets.fh_finaliza DESC,db_tickets.fh_alta DESC")
        rst = My.m_db.GetRst("SELECT db_tickets.id,db_tickets.n_ticket,db_tickets.fh_alta,db_tickets.fh_finaliza,db_tickets.estado,name_mesa,total,id_referencia,id_user FROM db_tickets LEFT JOIN  db_usuarios ON  db_usuarios.id=db_tickets.id_user WHERE id_caja=" & id & " order by db_tickets.estado DESC, db_tickets.fh_finaliza DESC,db_tickets.fh_alta DESC")

        'rst = My.m_db.GetRst("SELECT db_tickets.id,db_tickets.fh_alta,db_tickets.estado,total FROM db_tickets WHERE id_caja=-1 AND id_contable=" & My.m_app.GetValue("id_contable") & "  order by db_tickets.fh_alta desc")
        If IsNothing(rst) Then Exit Sub

        m_Table = New DataTable("m_tabla")
        da = New Data.OleDb.OleDbDataAdapter
        da.Fill(m_Table, rst)
        Me.GridCajaClosed.DataSource = m_Table


        'Permito borrar y volver a imprimir resumen
        Dim sw As Boolean = (Me.GridCajaClosed.RowCount > 0)
        Me.BtCancellOld.Enabled = sw
        Me.BtPrintOldTicket.Enabled = sw
        Me.BtDelOldTicket.Enabled = sw

        'Configuro la previsualización del ticket 
        With Me.LstLines.Columns
            .Clear()
            .Add("Ref.", 0, HorizontalAlignment.Right)
            .Add("Id Art", 0, HorizontalAlignment.Right)      'id_articulo
            .Add("Id Art Combina", 0, HorizontalAlignment.Right)      'id_articulo
            .Add("Ud", 40, HorizontalAlignment.Right)
            .Add("Ud Original", 0, HorizontalAlignment.Right)
            .Add("Artículo", 140, HorizontalAlignment.Left)
            .Add("Pvp/Ud", 0, HorizontalAlignment.Right)
            .Add("Total", 0, HorizontalAlignment.Right)
            .Add("Comanda", 0, HorizontalAlignment.Center)
            .Add("Id Categoria", 0, HorizontalAlignment.Center)
            .Add("Base imponible", 0, HorizontalAlignment.Left)
            .Add("IVA", 0, HorizontalAlignment.Left)
            .Add("Pesaje", 0, HorizontalAlignment.Left)
        End With

        'Cargo el ticket
        Me.LoadTicket_Historico()
    End Sub

    Private Sub LoadTicket_Historico()
        If Me.GridCajaClosed.SelectedRows.Count <= 0 Then Exit Sub
        Dim id As Integer = Me.GridCajaClosed.SelectedRows(0).Cells(0).Value
        Me.LstLines.Items.Clear()

        Dim rst As ADODB.Recordset = Nothing, i As Integer = 0
        rst = My.m_db.GetRst("SELECT db_tickets_lines.*,db_articulos.id_categoria,db_articulos.swpesaje FROM db_tickets_lines,db_articulos WHERE db_articulos.id=db_tickets_lines.id_articulo AND id_ticket=" & id)
        While Not rst.EOF
            With Me.LstLines
                .Items.Add(rst("id").Value)
                .Items(i).SubItems.Add(rst("id_articulo").Value)
                .Items(i).SubItems.Add(rst("id_articulo_combina").Value)
                .Items(i).SubItems.Add(rst("ud").Value)
                .Items(i).SubItems.Add(rst("ud").Value)
                .Items(i).SubItems.Add(rst("name").Value)              'Si no es combinado la cadena combina esta vacia
                .Items(i).SubItems.Add(Format(rst("pvp_ud").Value, "0.00#"))
                .Items(i).SubItems.Add(Format(rst("total").Value, "0.00#"))
                .Items(i).SubItems.Add(rst("swcomanda").Value)
                .Items(i).SubItems.Add(rst("id_categoria").Value)
                .Items(i).SubItems.Add(rst("pvp_base").Value)
                .Items(i).SubItems.Add(rst("iva").Value)
                .Items(i).SubItems.Add(rst("swpesaje").Value)

                ' Quito los anteriores seleccionados y muestro el ultimo agregado
                .SelectedItems.Clear()
                .Items(i).Selected = True
                .EnsureVisible(i)
            End With
            i += 1
            rst.MoveNext()
        End While
        My.m_db.CloseRst(rst)

        '### Cargo las LINEAS de los ARTICULOS LIBRE
        rst = My.m_db.GetRst("SELECT * FROM db_tickets_lines WHERE id_articulo=-1 AND id_ticket=" & id)
        While Not rst.EOF
            With Me.LstLines
                .Items.Add(rst("id").Value)
                .Items(i).SubItems.Add(rst("id_articulo").Value)
                .Items(i).SubItems.Add(rst("id_articulo_combina").Value)
                .Items(i).SubItems.Add(rst("ud").Value)
                .Items(i).SubItems.Add(rst("ud").Value)
                .Items(i).SubItems.Add(rst("name").Value)              'Si no es combinado la cadena combina esta vacia
                .Items(i).SubItems.Add(Format(rst("pvp_ud").Value, "0.00#"))
                .Items(i).SubItems.Add(Format(rst("total").Value, "0.00#"))
                .Items(i).SubItems.Add(rst("swcomanda").Value)
                .Items(i).SubItems.Add(-1)
                .Items(i).SubItems.Add(rst("pvp_base").Value)
                .Items(i).SubItems.Add(rst("iva").Value)
                .Items(i).SubItems.Add(False)

                ' Quito los anteriores seleccionados y muestro el ultimo agregado
                .SelectedItems.Clear()
                .Items(i).Selected = True
                .EnsureVisible(i)
            End With
            i += 1
            rst.MoveNext()
        End While
        My.m_db.CloseRst(rst)
    End Sub

    Private Sub GridCajaClosed_CellEnter(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles GridCajaClosed.CellEnter
        Me.LoadTicket_Historico()
    End Sub
#End Region
#End Region

#Region "Impresion"
    'Impresion de una Caja
    Private Sub PrintCaja(ByVal id_caja As Integer)
        'No tengo configurada ninguna impresora
        If My.MyHardware.IdPort <= 0 Then
            MsgBox("No se ha detectado ningún puerto de Impresión.", MsgBoxStyle.Critical)
            Exit Sub
        End If

        Dim rst As ADODB.Recordset = My.m_db.GetRst("SELECT * FROM db_cajas WHERE id=" & id_caja)
        Dim str As String = "", strAux As String = ""
        Dim i As Integer = -1
        Dim rstTmp As ADODB.Recordset = Nothing, rstAux As ADODB.Recordset = Nothing, rstTmp1 As ADODB.Recordset = Nothing

        If My.MyHardware.PortName = "REPORT" Then
            Dim RptPrint As CrystalDecisions.CrystalReports.Engine.ReportDocument
            RptPrint = New crtCierreCaja
            'CType(RptPrint, crtCierreCaja).DataDefinition.FormulaFields("Fh_Desde").Text = "'" & Format(Now.AddDays(-7), "dd/MMMM/yyyy") & "'"

            RptPrint.RecordSelectionFormula = "{db_cajas.id}=" & id_caja
            RptPrint.PrintToPrinter(1, False, 0, 0)
            RptPrint.Dispose()
            'MsgBox("Genero por crystal")
            Exit Sub
        End If


        'Imprimo el ticket de resumen
        If My.MyHardware.PortName.Substring(0, 3) = "COM" Then
            '<!--### IMPRESIÓN POR PUERTO SERIE ###-->
            Dim _port As IO.Ports.SerialPort
            _port = New IO.Ports.SerialPort(My.MyHardware.PortName, 9600, IO.Ports.Parity.None, 8, IO.Ports.StopBits.One)
            _port.DiscardNull = True
            _port.WriteBufferSize = 2024
            _port.DtrEnable = True
            _port.Handshake = IO.Ports.Handshake.None

            _port.Open()
            If My.MyHardware.CodEsc_Init.Length > 0 Then _port.Write(My.MyHardware.CodEsc_Init & My.MyHardware.CodEsc_Cr)

            'Imprimo datos de cabecera
            For i = 1 To 4
                strAux = My.MyHardware.StrCab(i)
                str = ""
                If strAux.Length > My.MyHardware.Ancho Then strAux = strAux.Substring(0, My.MyHardware.Ancho - 1)
                str = My.Ticket_ConfigTextColor(str, My.MyHardware.SwRed(i))
                str = My.Ticket_ConfigTextStrong(str, My.MyHardware.SwNegrita(i))
                str = My.Ticket_ConfigTextSize(str, My.MyHardware.SwGrande(i))
                strAux = My.Ticket_ConfigTextAling(strAux, IIf(My.MyHardware.SwCenter(i), 2, 0), My.MyHardware.SwGrande(i))
                If My.MyHardware.StrCab(i).Length <> 0 Then _port.Write(str & strAux & My.MyHardware.CodEsc_Cr)
            Next
            _port.Write(My.MyHardware.CodEsc_Cr)

            'Imprimo linea de separacion
            str = My.MyHardware.CodEsc_TextNormal & " " & My.MyHardware.CodEsc_Subrayado_True & Space(38) & My.MyHardware.CodEsc_Subrayado_False
            _port.Write(str & My.MyHardware.CodEsc_Cr)


            'Imprimo info sobre el ticket
            strAux = My.MyHardware.CodEsc_TextNormal & "Ref.: " & Format(id_caja, "000000")
            strAux &= Space(My.MyHardware.Ancho - strAux.Length - CStr(rst("fh_alta").Value).Length) & My.MyHardware.CodEsc_Negrita_True & rst("fh_alta").Value & My.MyHardware.CodEsc_Negrita_False
            _port.Write(strAux & My.MyHardware.CodEsc_Cr)
            _port.Write(My.MyHardware.CodEsc_Cr)


            'Imprimo detalles
            str = "Ha realizado un total de " & My.MyHardware.CodEsc_Negrita_True & rst("n_tickets").Value & My.MyHardware.CodEsc_Negrita_False & " tickets."
            _port.Write(str & My.MyHardware.CodEsc_Cr)
            str = "Ha generado un total de " & My.MyHardware.CodEsc_TextGrande & Format(rst("total").Value, "0.00") & My.MyHardware.CodEsc_TextNormal & " euros en la caja."
            _port.Write(str & My.MyHardware.CodEsc_Cr)

            'Imprimo linea de separacion
            str = My.MyHardware.CodEsc_TextNormal & " " & My.MyHardware.CodEsc_Subrayado_True & Space(38) & My.MyHardware.CodEsc_Subrayado_False
            _port.Write(str & My.MyHardware.CodEsc_Cr)

            'Imprimo espameo
            str = My.MyHardware.CodEsc_Negrita_True & My.Ticket_ConfigTextAling("gTPV " & My.Application.Info.Version.Major & "." & My.Application.Info.Version.Minor & "." & My.Application.Info.Version.Build, HorizontalAlignment.Center) & My.MyHardware.CodEsc_Negrita_False
            _port.Write(My.Ticket_ConfigTextStrong(str, True) & My.MyHardware.CodEsc_Cr)

            'Imprimo el nombre de la aplicacion
            str = My.MyHardware.CodEsc_TextNormal & " "
            _port.Write(str & My.MyHardware.CodEsc_Cr)

            _port.Write(My.MyHardware.CodEsc_Salto & My.MyHardware.CodEsc_Cr)
            If Len(My.MyHardware.CodEsc_Cut) > 0 Then _port.Write(My.MyHardware.CodEsc_Cut & My.MyHardware.CodEsc_Cr)
            _port.Close()
            _port.Dispose()
        ElseIf My.MyHardware.PortName.Substring(0, 3) = "LPT" Then
            '<!--### IMPRESIÓN POR PUERTO PARALELO ###-->
            Dim _port As m_Crypto.ioParerellPort
            _port = New m_Crypto.ioParerellPort("LPT" & My.MyHardware.IdPort)
            If My.MyHardware.CodEsc_Init.Length > 0 Then _port.Write(My.MyHardware.CodEsc_Init & My.MyHardware.CodEsc_Cr)

            'Imprimo datos de cabecera
            For i = 1 To 4
                strAux = My.MyHardware.StrCab(i)
                str = ""
                If strAux.Length > My.MyHardware.Ancho Then strAux = strAux.Substring(1, My.MyHardware.Ancho)
                str = My.Ticket_ConfigTextColor(str, My.MyHardware.SwRed(i))
                str = My.Ticket_ConfigTextStrong(str, My.MyHardware.SwNegrita(i))
                str = My.Ticket_ConfigTextSize(str, My.MyHardware.SwGrande(i))
                strAux = My.Ticket_ConfigTextAling(strAux, IIf(My.MyHardware.SwCenter(i), 2, 0), My.MyHardware.SwGrande(i))
                If My.MyHardware.StrCab(i).Length <> 0 Then _port.Write(str & strAux & My.MyHardware.CodEsc_Cr)
            Next
            _port.Write(My.MyHardware.CodEsc_Cr)

            'Imprimo linea de separacion
            str = My.MyHardware.CodEsc_TextNormal & " " & My.MyHardware.CodEsc_Subrayado_True & Space(38) & My.MyHardware.CodEsc_Subrayado_False
            _port.Write(str & My.MyHardware.CodEsc_Cr)


            'Imprimo info sobre el ticket
            strAux = My.MyHardware.CodEsc_TextNormal & "Ref.: " & Format(id_caja, "000000")
            strAux &= Space(My.MyHardware.Ancho - strAux.Length - CStr(rst("fh_alta").Value).Length) & My.MyHardware.CodEsc_Negrita_True & rst("fh_alta").Value & My.MyHardware.CodEsc_Negrita_False
            _port.Write(strAux & My.MyHardware.CodEsc_Cr)
            _port.Write(My.MyHardware.CodEsc_Cr)


            'Imprimo detalles
            str = "Ha realizado un total de " & My.MyHardware.CodEsc_Negrita_True & rst("n_tickets").Value & My.MyHardware.CodEsc_Negrita_False & " tickets."
            _port.Write(str & My.MyHardware.CodEsc_Cr)

            str = "Ha generado un total de " & My.MyHardware.CodEsc_TextGrande & Format(rst("total").Value, "0.00") & My.MyHardware.CodEsc_TextNormal & " euros en la caja."
            _port.Write(str & My.MyHardware.CodEsc_Cr)

            'Imprimo linea de separacion
            str = My.MyHardware.CodEsc_TextNormal & " " & My.MyHardware.CodEsc_Subrayado_True & Space(38) & My.MyHardware.CodEsc_Subrayado_False
            _port.Write(str & My.MyHardware.CodEsc_Cr)

            'Imprimo espameo
            str = My.MyHardware.CodEsc_Negrita_True & My.Ticket_ConfigTextAling("gTPV " & My.Application.Info.Version.Major & "." & My.Application.Info.Version.Minor & "." & My.Application.Info.Version.Build, HorizontalAlignment.Center) & My.MyHardware.CodEsc_Negrita_False
            _port.Write(My.Ticket_ConfigTextStrong(str, True) & My.MyHardware.CodEsc_Cr)

            'Imprimo el nombre de la aplicacion
            str = My.MyHardware.CodEsc_TextNormal & " "
            _port.Write(str & My.MyHardware.CodEsc_Cr)

            _port.Write(My.MyHardware.CodEsc_Salto & My.MyHardware.CodEsc_Cr)
            If Len(My.MyHardware.CodEsc_Cut) > 0 Then _port.Write(My.MyHardware.CodEsc_Cut & My.MyHardware.CodEsc_Cr)
            _port.Dispose()
        Else
            '<!--### IMPRESIÓN POR RAW ###-->
            Dim strPrinter As String = "tickets"
            'Dim strTicket As String = ""

            'Impresión resumen de facturas
            Dim strText As String = ""
            Dim dblBase_4 As Double = 0, dblBase_7 As Double = 0, dblBase_16 As Double = 0
            Dim dblIVA_4 As Double = 0, dblIVA_7 As Double = 0, dblIVA_16 As Double = 0
            Dim j As Integer = 0
            Dim dblTotal As Double = 0

            Dim RstLines As ADODB.Recordset = Nothing


            If My.MyHardware.CodEsc_Init.Length > 0 Then My.RawPrinterHelper.SendStringToPrinter(strPrinter, My.MyHardware.CodEsc_Init & My.MyHardware.CodEsc_Cr)

            'Imprimo datos de cabecera
            For i = 1 To 4
                strAux = My.MyHardware.StrCab(i)
                str = ""
                If strAux.Length > My.MyHardware.Ancho Then strAux = strAux.Substring(1, My.MyHardware.Ancho)
                str = My.Ticket_ConfigTextColor(str, My.MyHardware.SwRed(i))
                str = My.Ticket_ConfigTextStrong(str, My.MyHardware.SwNegrita(i))
                str = My.Ticket_ConfigTextSize(str, My.MyHardware.SwGrande(i))
                strAux = My.Ticket_ConfigTextAling(strAux, IIf(My.MyHardware.SwCenter(i), 2, 0), My.MyHardware.SwGrande(i))
                If My.MyHardware.StrCab(i).Length <> 0 Then My.RawPrinterHelper.SendStringToPrinter(strPrinter, str & strAux & My.MyHardware.CodEsc_Cr)
            Next
            My.RawPrinterHelper.SendStringToPrinter(strPrinter, My.MyHardware.CodEsc_Cr)

            'Imprimo linea de separacion
            str = My.MyHardware.CodEsc_TextNormal & " " & My.MyHardware.CodEsc_Subrayado_True & Space(38) & My.MyHardware.CodEsc_Subrayado_False
            My.RawPrinterHelper.SendStringToPrinter(strPrinter, str & My.MyHardware.CodEsc_Cr)


            'Imprimo info sobre el ticket
            'strAux = My.MyHardware.CodEsc_TextNormal & "Ref.: " & Format(id_caja, "000000")
            strAux = My.MyHardware.CodEsc_TextNormal & "Caja: " & My.MyHardware.CodEsc_Negrita_True & rst("ncaja").Value & My.MyHardware.CodEsc_Negrita_False
            If My.MyHardware.Ancho >= 40 Then
                strAux &= Space(My.MyHardware.Ancho - strAux.Length - CStr(rst("fh_alta").Value).Length) & My.MyHardware.CodEsc_Negrita_True & rst("fh_alta").Value & My.MyHardware.CodEsc_Negrita_False
            Else
                My.RawPrinterHelper.SendStringToPrinter(strPrinter, strAux & My.MyHardware.CodEsc_Cr)
                strAux = My.MyHardware.CodEsc_TextNormal & "Fecha: " & My.MyHardware.CodEsc_Negrita_True & rst("fh_alta").Value & My.MyHardware.CodEsc_Negrita_False
            End If

            My.RawPrinterHelper.SendStringToPrinter(strPrinter, strAux & My.MyHardware.CodEsc_Cr)
            My.RawPrinterHelper.SendStringToPrinter(strPrinter, My.MyHardware.CodEsc_Cr)


            'Imprimo detalles
            str = "Ha realizado un total de " & My.MyHardware.CodEsc_Negrita_True & rst("n_tickets").Value & My.MyHardware.CodEsc_Negrita_False & " tickets."
            My.RawPrinterHelper.SendStringToPrinter(strPrinter, str & My.MyHardware.CodEsc_Cr)

            str = "Ha generado un total de " & My.MyHardware.CodEsc_Negrita_True & Format(rst("total").Value, "0.00") & My.MyHardware.CodEsc_Negrita_False & " euros en la caja."
            My.RawPrinterHelper.SendStringToPrinter(strPrinter, str & My.MyHardware.CodEsc_Cr)

            If Not IsDBNull(rst("total_banco").Value) AndAlso rst("total_banco").Value > 0 Then
                str = "Se ha cobrado un total de " & My.MyHardware.CodEsc_Negrita_True & Format(rst("total_banco").Value, "0.00") & My.MyHardware.CodEsc_Negrita_False & " euros por tarjeta."
                My.RawPrinterHelper.SendStringToPrinter(strPrinter, str & My.MyHardware.CodEsc_Cr)
            End If

            If Not IsDBNull(rst("inicio_caja").Value) AndAlso rst("inicio_caja").Value > 0 Then
                str = "Importe de Inicio de Caja: " & My.MyHardware.CodEsc_Negrita_True & Format(rst("inicio_caja").Value, "0.00") & My.MyHardware.CodEsc_Negrita_False & ""
                My.RawPrinterHelper.SendStringToPrinter(strPrinter, str & My.MyHardware.CodEsc_Cr)
            End If

            'Imprimor resumen de bases imponibles
            rstTmp = My.m_db.GetRst("SELECT db_tickets.id,db_tickets.total FROM db_tickets WHERE db_tickets.id_caja=" & id_caja & " AND estado<>'CANCELADO' AND NOT tipo ORDER BY id ASC")
            str = ""
            dblBase_4 = 0
            dblBase_7 = 0
            dblBase_16 = 0

            While Not rstTmp.EOF
                'Cargo lineas
                RstLines = My.m_db.GetRst("SELECT * FROM db_tickets_lines WHERE id_ticket=" & rstTmp("id").Value & " ORDER BY id")
                While Not RstLines.EOF
                    Select Case RstLines("iva").Value
                        Case My.m_opt.IVA_General : dblBase_16 += (RstLines("pvp_base").Value * RstLines("ud").Value)
                        Case My.m_opt.IVA_Medio : dblBase_7 += (RstLines("pvp_base").Value * RstLines("ud").Value)
                        Case My.m_opt.IVA_Basico : dblBase_4 += (RstLines("pvp_base").Value * RstLines("ud").Value)
                    End Select

                    RstLines.MoveNext()
                End While
                My.m_db.CloseRst(RstLines)

                rstTmp.MoveNext()
            End While
            My.m_db.CloseRst(rstTmp)

            'Ajusto las bases imponibles
            dblBase_4 = Format(dblBase_4, "0.0000###")
            dblBase_7 = Format(dblBase_7, "0.0000###")
            dblBase_16 = Format(dblBase_16, "0.0000###")

            'Calculo el importe de iva
            dblIVA_4 = Format(((dblBase_4 * My.m_opt.IVA_Basico) / 100), "0.00")
            dblIVA_7 = Format(((dblBase_7 * My.m_opt.IVA_Medio) / 100), "0.00")
            dblIVA_16 = Format(((dblBase_16 * My.m_opt.IVA_General) / 100), "0.00")

            '### Imprimo las bases Imponibles
            strAux = " " & My.MyHardware.CodEsc_Subrayado_True & "Base Imponible" & My.MyHardware.CodEsc_Subrayado_False
            strAux &= Space(My.MyHardware.Ancho - IIf(My.MyHardware.Ancho < 40, 0, 20) - 17) & My.MyHardware.CodEsc_Subrayado_True & "% IVA" & My.MyHardware.CodEsc_Subrayado_False
            strAux &= Space(1) & My.MyHardware.CodEsc_Subrayado_True & "Imp IVA" & My.MyHardware.CodEsc_Subrayado_False
            strAux &= Space(1) & My.MyHardware.CodEsc_Subrayado_True & "  Total" & My.MyHardware.CodEsc_Subrayado_False
            My.RawPrinterHelper.SendStringToPrinter(strPrinter, strAux & My.MyHardware.CodEsc_Cr)
            If dblBase_4 > 0 Then
                strAux = "  " & Format(dblBase_4, "0.0000")
                strAux &= Space(My.MyHardware.Ancho - IIf(My.MyHardware.Ancho < 40, 5, 22) - strAux.Length)
                strAux &= Space(5 - Format(My.m_opt.IVA_Basico, "#0.00").Length) & Format(My.m_opt.IVA_Basico, "#0.00")
                strAux &= Space(1)
                strAux &= Space(7 - Format(dblIVA_4, "0.00").Length) & Format(dblIVA_4, "0.00")
                strAux &= Space(1)
                If Format(dblBase_4 + dblIVA_4, "0.00").Length > 7 Then
                    strAux &= Space(7 - Format(dblBase_4 + dblIVA_4, "0.00").Length) & Format(dblBase_4 + dblIVA_4, "0.")
                Else
                    strAux &= Space(7 - Format(dblBase_4 + dblIVA_4, "0.00").Length) & Format(dblBase_4 + dblIVA_4, "0.00")
                End If

                My.RawPrinterHelper.SendStringToPrinter(strPrinter, strAux & My.MyHardware.CodEsc_Cr)
            End If

            If dblBase_7 > 0 Then
                strAux = "  " & Format(dblBase_7, "0.0000")
                strAux &= Space(My.MyHardware.Ancho - IIf(My.MyHardware.Ancho < 40, 5, 22) - strAux.Length)
                strAux &= Space(5 - Format(My.m_opt.IVA_Medio, "#0.00").Length) & Format(My.m_opt.IVA_Medio, "#0.00")
                strAux &= Space(1)
                strAux &= Space(7 - Format(dblIVA_7, "0.00").Length) & Format(dblIVA_7, "0.00")
                strAux &= Space(1)
                If Format(dblBase_7 + dblIVA_7, "0.00").Length > 7 Then
                    strAux &= Space(8 - Format(dblBase_7 + dblIVA_7, "0.00").Length) & Format(dblBase_7 + dblIVA_7, "0.")
                Else
                    strAux &= Space(7 - Format(dblBase_7 + dblIVA_7, "0.00").Length) & Format(dblBase_7 + dblIVA_7, "0.00")
                End If

                My.RawPrinterHelper.SendStringToPrinter(strPrinter, strAux & My.MyHardware.CodEsc_Cr)
            End If

            If dblBase_16 > 0 Then
                strAux = "  " & Format(dblBase_16, "0.0000")
                strAux &= Space(My.MyHardware.Ancho - IIf(My.MyHardware.Ancho < 40, 5, 22) - strAux.Length)
                strAux &= Space(5 - Format(My.m_opt.IVA_General, "#0.00").Length) & Format(My.m_opt.IVA_General, "#0.00")
                strAux &= Space(1)
                strAux &= Space(7 - Format(dblIVA_16).Length) & Format(dblIVA_16, "0.00")
                strAux &= Space(1)
                If Format(dblBase_16 + dblIVA_16, "0.00").Length > 7 Then
                    strAux &= Space(7 - Format(dblBase_16 + dblIVA_16, "0.00").Length) & Format(dblBase_16 + dblIVA_16, "0.")
                Else
                    strAux &= Space(7 - Format(dblBase_16 + dblIVA_16, "0.00").Length) & Format(dblBase_16 + dblIVA_16, "0.00")
                End If
                My.RawPrinterHelper.SendStringToPrinter(strPrinter, strAux & My.MyHardware.CodEsc_Cr)
            End If
            strAux = Space(My.MyHardware.Ancho - 15) & My.MyHardware.CodEsc_Subrayado_True & Space(14) & My.MyHardware.CodEsc_Subrayado_False
            My.RawPrinterHelper.SendStringToPrinter(strPrinter, strAux & My.MyHardware.CodEsc_Cr)

            dblTotal = (dblBase_4 + dblIVA_4) + (dblBase_7 + dblIVA_7) + (dblBase_16 + dblIVA_16)

            i = (6 - Format(dblTotal, "###0.00").Length)
            If i < 0 Then i = 0

            strAux = My.MyHardware.CodEsc_Rojo & Space(My.MyHardware.Ancho - 11) & My.MyHardware.CodEsc_TextGrande & My.MyHardware.CodEsc_Negrita_True & Space(i) & Format(dblTotal, "###0.00") & " E" & My.MyHardware.CodEsc_Negrita_False & My.MyHardware.CodEsc_TextNormal & My.MyHardware.CodEsc_Negro
            My.RawPrinterHelper.SendStringToPrinter(strPrinter, strAux & My.MyHardware.CodEsc_Cr)


            strAux = My.MyHardware.CodEsc_TextNormal & "           " & My.MyHardware.CodEsc_Subrayado_True & Space(My.MyHardware.Ancho - 12) & My.MyHardware.CodEsc_Subrayado_False
            My.RawPrinterHelper.SendStringToPrinter(strPrinter, strAux & My.MyHardware.CodEsc_Cr)



            'Imprimo resumen de facturado
            rstTmp = My.m_db.GetRst("SELECT SUM(total) as nTot FROM db_tickets WHERE id_caja=" & id_caja & " AND id_factura>0")

            If Not IsDBNull(rstTmp("nTot").Value) AndAlso rstTmp("nTot").Value > 0 Then
                str = "  " & My.MyHardware.CodEsc_Subrayado_True & "Facturacion en Caja" & My.MyHardware.CodEsc_Subrayado_False & My.MyHardware.CodEsc_Negrita_False
                My.RawPrinterHelper.SendStringToPrinter(strPrinter, My.MyHardware.CodEsc_Cr & str & My.MyHardware.CodEsc_Cr)

                str = "Se ha realizado una facturacion de " & My.MyHardware.CodEsc_Negrita_True & Format(rstTmp("nTot").Value, "0.00") & My.MyHardware.CodEsc_Negrita_False
                rstTmp = My.m_db.GetRst("SELECT COUNT(id) as nTot FROM db_tickets WHERE id_caja=" & id_caja & " AND id_factura>0")
                str &= " en las siguiente/s " & rstTmp("nTot").Value & " factura/s: "
                My.RawPrinterHelper.SendStringToPrinter(strPrinter, str & My.MyHardware.CodEsc_Cr & My.MyHardware.CodEsc_Cr)

                rstTmp = My.m_db.GetRst("SELECT db_tickets.id,db_clientes.name_fiscal,db_tickets.total,db_facturas.n_factura,db_facturas.fh_factura FROM db_clientes,db_tickets,db_facturas WHERE db_clientes.id=db_facturas.id_cliente AND db_facturas.id=db_tickets.id_factura AND db_tickets.id_caja=" & id_caja & " AND db_tickets.id_factura>0 ORDER BY n_factura ASC")
                'rstTmp = My.m_db.GetRst("SELECT db_tickets.total,db_facturas.n_factura,db_facturas.fh_factura FROM db_tickets,db_facturas WHERE db_facturas.id=db_tickets.id_factura AND db_tickets.id_caja=" & id_caja & " AND db_tickets.id_factura>0")
                str = ""
                While Not rstTmp.EOF
                    str = " - " & rstTmp("n_factura").Value & " " & Format(rstTmp("id").Value, "00000") & " " & Format(rstTmp("fh_factura").Value, "dd/MM/yyyy") & My.MyHardware.CodEsc_Cr
                    str &= "  " & My.MyHardware.CodEsc_Negrita_True & rstTmp("name_fiscal").Value & My.MyHardware.CodEsc_Negrita_False & My.MyHardware.CodEsc_Cr
                    My.RawPrinterHelper.SendStringToPrinter(strPrinter, str & My.MyHardware.CodEsc_Cr)

                    'Obtengo los IVA
                    RstLines = My.m_db.GetRst("SELECT * FROM db_tickets_lines WHERE id_ticket=" & rstTmp("id").Value & " ORDER BY id")
                    dblBase_4 = 0
                    dblBase_7 = 0
                    dblBase_16 = 0
                    While Not RstLines.EOF
                        Select Case My.m_opt.modo_compatibilidad
                            Case "COMERCIO"
                                strAux = " " & RstLines("name").Value
                                If strAux.Length > My.MyHardware.Ancho - 22 Then strAux = strAux.Substring(0, My.MyHardware.Ancho - 22)
                                strAux &= Space(My.MyHardware.Ancho - 20 - strAux.Length)

                                strAux &= Space(7 - Format(RstLines("ud").Value, "##0.##").Length) & Format(RstLines("ud").Value, "##0.##")
                                strAux &= Space(6 - Format(RstLines("pvp_ud").Value, "##0.00").Length) & Format(RstLines("pvp_ud").Value, "##0.00")


                                j = (6 - Format(RstLines("total").Value, "##0.00").Length)
                                If j < 0 Then j = 0

                                strAux &= " " & Space(j) & Format(RstLines("total").Value, "##0.00")

                            Case Else
                                strAux = " " & RstLines("name").Value
                                If strAux.Length > My.MyHardware.Ancho - 13 Then strAux = strAux.Substring(0, My.MyHardware.Ancho - 13)
                                strAux &= Space(My.MyHardware.Ancho - 11 - strAux.Length)
                                strAux &= Space(3 - Format(RstLines("ud").Value, "##0").Length) & Format(RstLines("ud").Value, "##0")

                                j = (6 - Format(RstLines("total").Value, "##0.00").Length)
                                If j < 0 Then j = 0

                                strAux &= " " & Space(j) & Format(RstLines("total").Value, "##0.00")
                        End Select

                        strText &= My.FixCHARISO(strAux) & My.MyHardware.CodEsc_Cr

                        'Compongo las bases
                        Select Case RstLines("iva").Value
                            Case My.m_opt.IVA_General : dblBase_16 += (RstLines("pvp_base").Value * RstLines("ud").Value)
                            Case My.m_opt.IVA_Medio : dblBase_7 += (RstLines("pvp_base").Value * RstLines("ud").Value)
                            Case My.m_opt.IVA_Basico : dblBase_4 += (RstLines("pvp_base").Value * RstLines("ud").Value)
                        End Select

                        RstLines.MoveNext()
                    End While

                    'Ajusto las bases imponibles
                    dblBase_4 = Format(dblBase_4, "0.000")
                    dblBase_7 = Format(dblBase_7, "0.000")
                    dblBase_16 = Format(dblBase_16, "0.000")

                    'Calculo el importe de iva
                    dblIVA_4 = Format(((dblBase_4 * My.m_opt.IVA_Basico) / 100), "0.00")
                    dblIVA_7 = Format(((dblBase_7 * My.m_opt.IVA_Medio) / 100), "0.00")
                    dblIVA_16 = Format(((dblBase_16 * My.m_opt.IVA_General) / 100), "0.00")

                    '### Imprimo las bases Imponibles
                    strAux = " " & My.MyHardware.CodEsc_Subrayado_True & "Base Imponible" & My.MyHardware.CodEsc_Subrayado_False
                    strAux &= Space(My.MyHardware.Ancho - IIf(My.MyHardware.Ancho < 40, 12, 20) - 17) & My.MyHardware.CodEsc_Subrayado_True & "% IVA" & My.MyHardware.CodEsc_Subrayado_False
                    strAux &= Space(1) & My.MyHardware.CodEsc_Subrayado_True & "Imp IVA" & My.MyHardware.CodEsc_Subrayado_False
                    If My.MyHardware.Ancho >= 40 Then strAux &= Space(1) & My.MyHardware.CodEsc_Subrayado_True & "  Total" & My.MyHardware.CodEsc_Subrayado_False
                    My.RawPrinterHelper.SendStringToPrinter(strPrinter, strAux & My.MyHardware.CodEsc_Cr)
                    If dblBase_4 > 0 Then
                        strAux = "  " & Format(dblBase_4, "0.000")
                        strAux &= Space(My.MyHardware.Ancho - IIf(My.MyHardware.Ancho < 40, 5, 22) - strAux.Length)
                        strAux &= Space(5 - Format(My.m_opt.IVA_Basico, "#0.00").Length) & Format(My.m_opt.IVA_Basico, "#0.00")
                        strAux &= Space(1)
                        strAux &= Space(7 - Format(dblIVA_4, "0.00").Length) & Format(dblIVA_4, "0.00")
                        If My.MyHardware.Ancho >= 40 Then
                            strAux &= Space(1)
                            strAux &= Space(7 - Format(dblBase_4 + dblIVA_4, "0.00").Length) & Format(dblBase_4 + dblIVA_4, "0.00")
                        End If
                        My.RawPrinterHelper.SendStringToPrinter(strPrinter, strAux & My.MyHardware.CodEsc_Cr)
                    End If

                    If dblBase_7 > 0 Then
                        strAux = "  " & Format(dblBase_7, "0.000")
                        strAux &= Space(My.MyHardware.Ancho - IIf(My.MyHardware.Ancho < 40, 5, 22) - strAux.Length)
                        strAux &= Space(5 - Format(My.m_opt.IVA_Medio, "#0.00").Length) & Format(My.m_opt.IVA_Medio, "#0.00")
                        strAux &= Space(1)
                        strAux &= Space(7 - Format(dblIVA_7, "0.00").Length) & Format(dblIVA_7, "0.00")
                        If My.MyHardware.Ancho >= 40 Then
                            strAux &= Space(1)
                            strAux &= Space(7 - Format(dblBase_7 + dblIVA_7, "0.00").Length) & Format(dblBase_7 + dblIVA_7, "0.00")
                        End If
                        My.RawPrinterHelper.SendStringToPrinter(strPrinter, strAux & My.MyHardware.CodEsc_Cr)
                    End If

                    If dblBase_16 > 0 Then
                        strAux = "  " & Format(dblBase_16, "0.000")
                        strAux &= Space(My.MyHardware.Ancho - IIf(My.MyHardware.Ancho < 40, 5, 22) - strAux.Length)
                        strAux &= Space(5 - Format(My.m_opt.IVA_General, "#0.00").Length) & Format(My.m_opt.IVA_General, "#0.00")
                        strAux &= Space(1)
                        strAux &= Space(7 - Format(dblIVA_16).Length) & Format(dblIVA_16, "0.00")
                        If My.MyHardware.Ancho >= 40 Then
                            strAux &= Space(1)
                            strAux &= Space(7 - Format(dblBase_16 + dblIVA_16, "0.00").Length) & Format(dblBase_16 + dblIVA_16, "0.00")
                        End If
                        My.RawPrinterHelper.SendStringToPrinter(strPrinter, strAux & My.MyHardware.CodEsc_Cr)
                    End If
                    strAux = Space(My.MyHardware.Ancho - 15) & My.MyHardware.CodEsc_Subrayado_True & Space(14) & My.MyHardware.CodEsc_Subrayado_False
                    My.RawPrinterHelper.SendStringToPrinter(strPrinter, strAux & My.MyHardware.CodEsc_Cr)

                    dblTotal = (dblBase_4 + dblIVA_4) + (dblBase_7 + dblIVA_7) + (dblBase_16 + dblIVA_16)

                    i = (6 - Format(dblTotal, "###0.00").Length)
                    If i < 0 Then i = 0

                    strAux = My.MyHardware.CodEsc_Rojo & Space(My.MyHardware.Ancho - 11) & My.MyHardware.CodEsc_TextGrande & My.MyHardware.CodEsc_Negrita_True & Space(i) & Format(dblTotal, "###0.00") & " E" & My.MyHardware.CodEsc_Negrita_False & My.MyHardware.CodEsc_TextNormal
                    My.RawPrinterHelper.SendStringToPrinter(strPrinter, strAux & My.MyHardware.CodEsc_Cr)


                    strAux = My.MyHardware.CodEsc_TextNormal & "           " & My.MyHardware.CodEsc_Subrayado_True & Space(My.MyHardware.Ancho - 12) & My.MyHardware.CodEsc_Subrayado_False
                    My.RawPrinterHelper.SendStringToPrinter(strPrinter, strAux & My.MyHardware.CodEsc_Cr)

                    'My.RawPrinterHelper.SendStringToPrinter(strPrinter, strAux & My.MyHardware.CodEsc_Cr)
                    'str &= My.MyHardware.CodEsc_Cr



                    rstTmp.MoveNext()
                End While
                'My.RawPrinterHelper.SendStringToPrinter(strPrinter, str & My.MyHardware.CodEsc_Cr)

            End If
            My.m_db.CloseRst(rstTmp)

            'Imprimo resumen de caja de usuarios
            rstTmp = My.m_db.GetRst("SELECT DISTINCT id_user FROM db_tickets WHERE id_caja=" & id_caja & " AND estado<>'CANCELADO'")
            str = ""
            If rstTmp.RecordCount > 0 Then
                str = "  " & My.MyHardware.CodEsc_Subrayado_True & "Caja por Usuario" & My.MyHardware.CodEsc_Subrayado_False
                My.RawPrinterHelper.SendStringToPrinter(strPrinter, My.MyHardware.CodEsc_Cr & str & My.MyHardware.CodEsc_Cr)
                str = ""
                While Not rstTmp.EOF
                    rstAux = My.m_db.GetRst("SELECT db_usuarios.name FROM db_usuarios WHERE id=" & rstTmp("id_user").Value)
                    If rstAux.RecordCount > 0 Then
                        str &= My.MyHardware.CodEsc_Cr & "   - " & My.MyHardware.CodEsc_Negrita_True & rstAux("name").Value & My.MyHardware.CodEsc_Negrita_False & ": "
                        rstAux = My.m_db.GetRst("SELECT SUM(total) as nTOT FROM db_tickets WHERE id_caja=" & id_caja & " AND id_user=" & rstTmp("id_user").Value)
                        str &= Format(rstAux("nTot").Value, "0.00") & My.MyHardware.CodEsc_Cr
                    End If
                    My.m_db.CloseRst(rstAux)

                    'Obtengo que ha hecho cada uno por categoria
                    rstTmp1 = My.m_db.GetRst("SELECT * FROM db_categorias ORDER BY name ASC")
                    While Not rstTmp1.EOF
                        rstAux = My.m_db.GetRst("SELECT db_tickets_lines.total FROM db_tickets,db_tickets_lines,db_categorias,db_articulos WHERE db_categorias.id=db_articulos.id_categoria AND db_articulos.id=db_tickets_lines.id_articulo AND db_tickets_lines.id_ticket=db_tickets.id AND db_tickets.id_caja=" & id_caja & " AND db_categorias.id=" & rstTmp1("id").Value & " AND db_tickets.id_user=" & rstTmp("id_user").Value)
                        dblTotal = 0
                        While Not rstAux.EOF
                            dblTotal += rstAux("total").Value
                            rstAux.MoveNext()
                        End While
                        If dblTotal > 0 Then
                            str &= " (" & rstTmp1("name").Value & ": " & Format(dblTotal, "0.00") & ")"
                            '    My.RawPrinterHelper.SendStringToPrinter(strPrinter, str & My.MyHardware.CodEsc_Cr)
                        End If
                        rstTmp1.MoveNext()
                    End While
                    My.m_db.CloseRst(rstTmp1)

                    str &= My.MyHardware.CodEsc_Cr

                    rstTmp.MoveNext()
                End While
                My.RawPrinterHelper.SendStringToPrinter(strPrinter, str & My.MyHardware.CodEsc_Cr)
            End If
            My.m_db.CloseRst(rstTmp)

            'Imprimo resumenes por familia
            str = "  " & My.MyHardware.CodEsc_Subrayado_True & "Resumen por familia" & My.MyHardware.CodEsc_Subrayado_False
            My.RawPrinterHelper.SendStringToPrinter(strPrinter, str & My.MyHardware.CodEsc_Cr)

            rstTmp = My.m_db.GetRst("SELECT * FROM db_categorias ORDER BY name ASC")
            While Not rstTmp.EOF
                rstAux = My.m_db.GetRst("SELECT db_tickets_lines.total FROM db_tickets,db_tickets_lines,db_categorias,db_articulos WHERE db_categorias.id=db_articulos.id_categoria AND db_articulos.id=db_tickets_lines.id_articulo AND db_tickets_lines.id_ticket=db_tickets.id AND db_tickets.id_caja=" & id_caja & " AND db_tickets.estado<>'CANCELADO'" & " AND db_categorias.id=" & rstTmp("id").Value)
                dblTotal = 0
                While Not rstAux.EOF
                    dblTotal += rstAux("total").Value
                    rstAux.MoveNext()
                End While
                If dblTotal > 0 Then
                    str = "   - " & rstTmp("name").Value & ": " & Format(dblTotal, "0.00")
                    My.RawPrinterHelper.SendStringToPrinter(strPrinter, str & My.MyHardware.CodEsc_Cr)
                End If
                rstTmp.MoveNext()
            End While
            My.m_db.CloseRst(rstTmp)

            'Imprimo resumenes por articulo varios
            rstTmp = My.m_db.GetRst("SELECT DISTINCT(db_tickets_lines.name) FROM db_tickets,db_tickets_lines WHERE db_tickets_lines.id_ticket=db_tickets.id AND db_tickets_lines.id_articulo=-1 AND db_tickets.id_caja=" & id_caja)
            If rstTmp.RecordCount > 0 Then
                str = "  " & My.MyHardware.CodEsc_Subrayado_True & "Resumen de conceptos varios" & My.MyHardware.CodEsc_Subrayado_False
                My.RawPrinterHelper.SendStringToPrinter(strPrinter, str & My.MyHardware.CodEsc_Cr)

                While Not rstTmp.EOF
                    rstAux = My.m_db.GetRst("SELECT SUM(db_tickets_lines.total) as nTotal FROM db_tickets,db_tickets_lines WHERE db_tickets_lines.id_ticket=db_tickets.id AND db_tickets_lines.id_articulo=-1 AND db_tickets.id_caja=" & id_caja & " AND db_tickets_lines.name='" & rstTmp("name").Value & "'")
                    str = "   - " & rstTmp("name").Value & ": " & Format(rstAux("nTotal").Value, "0.00")

                    My.RawPrinterHelper.SendStringToPrinter(strPrinter, str & My.MyHardware.CodEsc_Cr)

                    rstTmp.MoveNext()
                End While

            End If
            My.m_db.CloseRst(rstTmp)

            'Resumen de marcas de tabaco
            If My.m_opt.modo_compatibilidad = "ESTANCO" Then
                ''Imprimo resumenes por familia
                'str = "  " & My.MyHardware.CodEsc_Subrayado_True & "Resumen por familia" & My.MyHardware.CodEsc_Subrayado_False
                'My.RawPrinterHelper.SendStringToPrinter(strPrinter, str & My.MyHardware.CodEsc_Cr)


                rstAux = My.m_db.GetRst("SELECT db_tickets_lines.total FROM db_tickets,db_tickets_lines WHERE db_tickets_lines.id_ticket=db_tickets.id AND db_tickets.id_caja=" & id_caja & " AND db_tickets.estado<>'CANCELADO'" & " AND db_tickets_lines.id_marca>0")
                dblTotal = 0
                While Not rstAux.EOF
                    dblTotal += rstAux("total").Value
                    rstAux.MoveNext()
                End While
                If dblTotal > 0 Then
                    str = "   - ESTANCO: " & Format(dblTotal, "0.00")
                    My.RawPrinterHelper.SendStringToPrinter(strPrinter, str & My.MyHardware.CodEsc_Cr)
                End If

                My.m_db.CloseRst(rstAux)
            End If


            'Imprimo resumenes por hora
            str = "  " & My.MyHardware.CodEsc_Subrayado_True & "Resumen por hora" & My.MyHardware.CodEsc_Subrayado_False
            My.RawPrinterHelper.SendStringToPrinter(strPrinter, My.MyHardware.CodEsc_Cr & str & My.MyHardware.CodEsc_Cr)

            str = ""
            For n As Integer = 0 To 23
                rstTmp = My.m_db.GetRst("SELECT SUM(total) AS nTot FROM db_tickets WHERE HOUR(fh_finaliza)=" & n & " AND id_caja=" & id_caja)
                If Not IsDBNull(rstTmp("nTot").Value) AndAlso rstTmp("nTot").Value > 0 Then
                    str &= "   - " & Format(n, "00") & ": " & Format(rstTmp("nTot").Value, "0.00") & My.MyHardware.CodEsc_Cr
                End If
                My.m_db.CloseRst(rstTmp)
            Next

            My.RawPrinterHelper.SendStringToPrinter(strPrinter, str & My.MyHardware.CodEsc_Cr)


            'Imprimo linea de separacion
            str = My.MyHardware.CodEsc_TextNormal & " " & My.MyHardware.CodEsc_Subrayado_True & Space(38) & My.MyHardware.CodEsc_Subrayado_False
            My.RawPrinterHelper.SendStringToPrinter(strPrinter, str & My.MyHardware.CodEsc_Cr)

            'Imprimo espameo
            str = My.MyHardware.CodEsc_Negrita_True & My.Ticket_ConfigTextAling("gTPV " & My.Application.Info.Version.Major & "." & My.Application.Info.Version.Minor & "." & My.Application.Info.Version.Build, HorizontalAlignment.Center) & My.MyHardware.CodEsc_Negrita_False
            My.RawPrinterHelper.SendStringToPrinter(strPrinter, My.Ticket_ConfigTextStrong(str, True) & My.MyHardware.CodEsc_Cr)

            'Imprimo el nombre de la aplicacion
            str = My.MyHardware.CodEsc_TextNormal & " "
            My.RawPrinterHelper.SendStringToPrinter(strPrinter, str & My.MyHardware.CodEsc_Cr)

            My.RawPrinterHelper.SendStringToPrinter(strPrinter, My.MyHardware.CodEsc_Salto & My.MyHardware.CodEsc_Cr)
            If Len(My.MyHardware.CodEsc_Cut) > 0 Then My.RawPrinterHelper.SendStringToPrinter(strPrinter, My.MyHardware.CodEsc_Cut & My.MyHardware.CodEsc_Cr)

        End If
        My.m_db.CloseRst(rst)
    End Sub


    Private Sub PrintResumen(ByVal id_caja As Integer)
        'Genero el consumo
        My.m_db_temp.Execute("DELETE * FROM consumos")

        Dim sFilter As String = ""
        Dim rst As ADODB.Recordset = Nothing
        rst = My.m_db.GetRst("SELECT db_cajas.id,db_tickets.id as idTicket FROM db_cajas,db_tickets WHERE db_tickets.id_caja=db_cajas.id AND db_cajas.id=" & id_caja)

        Dim rstLines As ADODB.Recordset = Nothing, rstConsumo As ADODB.Recordset = Nothing, rstArticulo As ADODB.Recordset = Nothing, rstTMP As ADODB.Recordset
        Dim sw As Boolean = False

        If rst.RecordCount > 0 Then
            While Not rst.EOF
                sFilter = ""

                rstLines = My.m_db.GetRst("SELECT * FROM db_tickets_lines WHERE id_ticket=" & rst("idTicket").Value & sFilter)
                While Not rstLines.EOF
                    rstConsumo = My.m_db_temp.GetRst("SELECT * FROM consumos WHERE id_articulo=" & rstLines("id_articulo").Value)

                    If rstConsumo.EOF Then
                        'Distingo el articulo varios y agrego el registro
                        If rstLines("id_articulo").Value = -1 Then
                            My.m_db_temp.Execute("INSERT INTO consumos (id_articulo,name,ud,importe) VALUES(" & rstLines("id_articulo").Value & ",'" & rstLines("name").Value & "'," & rstLines("ud").Value.ToString.Replace(",", ".") & "," & rstLines("total").Value.ToString.Replace(",", ".") & ")")
                        Else
                            'Obtengo el nombre del articulo y lo agrego
                            rstArticulo = My.m_db.GetRst("SELECT name FROM db_articulos WHERE id=" & rstLines("id_articulo").Value)
                            If Not rstArticulo.EOF Then My.m_db_temp.Execute("INSERT INTO consumos (id_articulo,name,ud,importe) VALUES(" & rstLines("id_articulo").Value & ",'" & rstArticulo("name").Value & "'," & rstLines("ud").Value & "," & rstLines("total").Value.ToString.Replace(",", ".") & ")")
                            My.m_db.CloseRst(rstArticulo)
                        End If
                    Else
                        If rstLines("id_articulo").Value = -1 Then
                            'Compruebo si por ese concepto esta agregado ya
                            rstTMP = My.m_db_temp.GetRst("SELECT id FROM consumos WHERE name='" & rstLines("name").Value & "'")
                            If rstTMP.EOF Then
                                My.m_db_temp.Execute("INSERT INTO consumos (id_articulo,name,ud,importe) VALUES(" & rstLines("id_articulo").Value & ",'" & rstLines("name").Value & "'," & rstLines("ud").Value.ToString.Replace(",", ".") & "," & rstLines("total").Value.ToString.Replace(",", ".") & ")")
                            Else
                                My.m_db_temp.Execute("UPDATE consumos SET ud=ud+" & rstLines("ud").Value.ToString.Replace(",", ".") & ",importe=importe+" & rstLines("total").Value.ToString.Replace(",", ".") & " WHERE id=" & rstTMP("id").Value)
                            End If
                            My.m_db_temp.CloseRst(rstTMP)

                        Else
                            'Actualizo las unidades
                            My.m_db_temp.Execute("UPDATE consumos SET ud=ud+" & rstLines("ud").Value.ToString.Replace(",", ".") & ",importe=importe+" & rstLines("total").Value.ToString.Replace(",", ".") & " WHERE id_articulo=" & rstLines("id_articulo").Value)
                        End If
                    End If
                    My.m_db.CloseRst(rstConsumo)


                    'Compruebo si tiene artículo de combinacion
                    If rstLines("id_articulo_combina").Value > 0 Then
                        'Compruebo si ya esta agregado el articulo
                        rstConsumo = My.m_db_temp.GetRst("SELECT * FROM consumos WHERE id_articulo=" & rstLines("id_articulo_combina").Value)
                        If rstConsumo.EOF Then
                            'Obtengo el nombre del articulo y lo agrego
                            rstArticulo = My.m_db.GetRst("SELECT name FROM db_articulos WHERE id=" & rstLines("id_articulo_combina").Value)
                            If Not rstArticulo.EOF Then My.m_db_temp.Execute("INSERT INTO consumos (id_articulo,name,ud,ud_combina) VALUES(" & rstLines("id_articulo_combina").Value & ",'" & rstArticulo("name").Value & "'," & rstLines("ud").Value & "," & rstLines("ud").Value & ")")
                            My.m_db.CloseRst(rstArticulo)
                        Else
                            'Actualizo las unidades
                            My.m_db_temp.Execute("UPDATE consumos SET ud=ud+" & rstLines("ud").Value & ",ud_combina=ud_combina+" & rstLines("ud").Value & " WHERE id_articulo=" & rstLines("id_articulo_combina").Value)
                        End If
                        My.m_db.CloseRst(rstConsumo)
                    End If

                    rstLines.MoveNext()
                End While

                rst.MoveNext()
            End While
        Else
            Exit Sub
        End If
        My.m_db.CloseRst(rst)


        If My.MyHardware.IdPort = 0 Then
            MsgBox("No hay configurada ninguna impresora de tickets para realizar la impresión.", MsgBoxStyle.Critical)
            Exit Sub
        End If

        rst = My.m_db_temp.GetRst("SELECT * FROM consumos ORDER BY name ASC")
        If rst.RecordCount = 0 Then
            MsgBox("No existe nada que mostrar, compruebe las fechas de selección de cajas.", MsgBoxStyle.Exclamation)
            My.m_db_temp.CloseRst(rst)
            Exit Sub
        End If

        Dim StrAux As String, i As Integer, j As Integer, strCod As String = ""

        Dim dblTot As Double = 0

        Dim rstCaja As ADODB.Recordset = My.m_db.GetRst("SELECT * FROM db_cajas WHERE id=" & id_caja)

        '<!--### IMPRESIÓN POR LA IMPRESORA DE NOMBRE TICKETS ###-->
        Dim strPrinter As String = "tickets"
        If My.MyHardware.CodEsc_Init.Length > 0 Then My.RawPrinterHelper.SendStringToPrinter(strPrinter, My.MyHardware.CodEsc_Init & My.MyHardware.CodEsc_Cr)
        strCod = ""

        '###Imprimo los detalles de la Empresa
        ' > Nombre Fiscal
        StrAux = My.m_opt.company_name
        If StrAux.Length > My.MyHardware.Ancho Then StrAux = StrAux.Substring(1, My.MyHardware.Ancho)
        My.RawPrinterHelper.SendStringToPrinter(strPrinter, strCod & My.MyHardware.CodEsc_Negrita_True & StrAux & My.MyHardware.CodEsc_Negrita_True & My.MyHardware.CodEsc_Cr)

        ' > Nombre Fiscal
        ''StrAux = "Fecha: " & Format(Me.FhCaja_Desde.Value, "dd/MM/yyyy") & " - " & Format(Me.FhCaja_Hasta.Value, "dd/MM/yyyy")

        StrAux = My.MyHardware.CodEsc_TextNormal & "Caja: " & My.MyHardware.CodEsc_Negrita_True & rstCaja("ncaja").Value & My.MyHardware.CodEsc_Negrita_False
        My.RawPrinterHelper.SendStringToPrinter(strPrinter, StrAux & My.MyHardware.CodEsc_Cr)


        StrAux = My.MyHardware.CodEsc_TextNormal & " " & My.MyHardware.CodEsc_Subrayado_True & Space(My.MyHardware.Ancho - 2) & My.MyHardware.CodEsc_Subrayado_False
        My.RawPrinterHelper.SendStringToPrinter(strPrinter, StrAux & My.MyHardware.CodEsc_Cr)


        ' Imprimo la cabecera
        StrAux = " " & My.MyHardware.CodEsc_Subrayado_True & "Articulo" & My.MyHardware.CodEsc_Subrayado_False
        StrAux &= Space(My.MyHardware.Ancho - IIf(My.MyHardware.Ancho < 40, 16, 29)) & My.MyHardware.CodEsc_Subrayado_True & "udTot" & My.MyHardware.CodEsc_Subrayado_False
        StrAux &= Space(2) & My.MyHardware.CodEsc_Subrayado_True & "udCom" & My.MyHardware.CodEsc_Subrayado_False
        StrAux &= Space(2) & My.MyHardware.CodEsc_Subrayado_True & "Total" & My.MyHardware.CodEsc_Subrayado_False
        My.RawPrinterHelper.SendStringToPrinter(strPrinter, StrAux & My.MyHardware.CodEsc_Cr)

        While Not rst.EOF
            StrAux = " " & rst("name").Value
            IIf(My.MyHardware.Ancho < 40, 10, 29)

            If StrAux.Length > My.MyHardware.Ancho - IIf(My.MyHardware.Ancho < 40, 7, 20) Then StrAux = StrAux.Substring(0, My.MyHardware.Ancho - IIf(My.MyHardware.Ancho < 40, 7, 20))
            If My.MyHardware.Ancho - IIf(My.MyHardware.Ancho < 40, 9, 22) - StrAux.Length < 0 Then
                StrAux = StrAux.Substring(0, My.MyHardware.Ancho - IIf(My.MyHardware.Ancho < 40, 10, 23))
                StrAux &= Space(My.MyHardware.Ancho - IIf(My.MyHardware.Ancho < 40, 9, 22) - StrAux.Length)
            Else
                StrAux &= Space(My.MyHardware.Ancho - IIf(My.MyHardware.Ancho < 40, 9, 22) - StrAux.Length)
            End If


            StrAux &= Space(6 - Format(rst("ud").Value, "###0").Length) & Format(rst("ud").Value, "###0")
            'StrAux &= Space(7)
            StrAux &= Space(7 - Format(rst("ud_combina").Value, "####").Length) & Format(rst("ud_combina").Value, "###0")

            j = (6 - Format(rst("importe").Value, "##0.00").Length)
            If j < 0 Then j = 0

            StrAux &= " " & Space(j) & Format(rst("importe").Value, "##0.00")

            My.RawPrinterHelper.SendStringToPrinter(strPrinter, StrAux & My.MyHardware.CodEsc_Cr)
            'rstLines.MoveNext()

            dblTot += rst("importe").Value
            rst.MoveNext()
        End While

        StrAux = My.MyHardware.CodEsc_TextNormal & " " & My.MyHardware.CodEsc_Subrayado_True & Space(My.MyHardware.Ancho - 2) & My.MyHardware.CodEsc_Subrayado_False
        My.RawPrinterHelper.SendStringToPrinter(strPrinter, StrAux & My.MyHardware.CodEsc_Cr)

        StrAux = My.MyHardware.CodEsc_Rojo & Space(My.MyHardware.Ancho - 11) & My.MyHardware.CodEsc_TextGrande & My.MyHardware.CodEsc_Negrita_True & Space(i) & Format(dblTot, "###0.00") & " E" & My.MyHardware.CodEsc_Negrita_False & My.MyHardware.CodEsc_TextNormal
        My.RawPrinterHelper.SendStringToPrinter(strPrinter, StrAux & My.MyHardware.CodEsc_Cr)

        i = (6 - Format(dblTot, "###0.00").Length)
        If i < 0 Then i = 0

        My.RawPrinterHelper.SendStringToPrinter(strPrinter, My.MyHardware.CodEsc_Salto & My.MyHardware.CodEsc_Cr)
        If Len(My.MyHardware.CodEsc_Cut) > 0 Then My.RawPrinterHelper.SendStringToPrinter(strPrinter, My.MyHardware.CodEsc_Cut & My.MyHardware.CodEsc_Cr)


    End Sub
#End Region
    
    Private Sub TabCajaActual_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TabCajaActual.SelectedIndexChanged
    End Sub



    Private Sub GridActual_CellMouseDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles GridActual.CellMouseDoubleClick
        Dim rst As ADODB.Recordset = My.m_db.GetRst("SELECT * FROM db_tickets WHERE id=" & Me.GridActual.SelectedRows(0).Cells(0).Value)

        'Muestro panel de ventas
        With My.Forms.frmPaneldeVentasResponsive
            .idRef = rst("id").Value
            .idMesa = rst("id_referencia").Value
            .idUser = rst("id_user").Value
            '.swCajaDirecta = Not (Me.LblHistory_Mesa.Tag = -1)

            .swFinalizado = True

            .ShowDialog(Me)
            If .DialogResult <> Windows.Forms.DialogResult.OK Then Exit Sub
            .Dispose()
        End With

        'Recargo la caja actual
        Me.Load_CajaActual()
    End Sub

    ' Recalculo la caja cerrada
    Private Sub RecalcularCaja()
        frmCajas_CerrarCaja.IdCaja = Me.GridHistorico.SelectedRows(0).Cells(0).Value
        frmCajas_CerrarCaja.ShowDialog(Me)
        If frmCajas_CerrarCaja.DialogResult <> Windows.Forms.DialogResult.OK Then
            frmCajas_CerrarCaja.Dispose()
            Exit Sub
        End If
        Dim idAux As Integer = frmCajas_CerrarCaja.IdCaja
        frmCajas_CerrarCaja.Dispose()

        'Imprimo y Recargo valores
        Me.PrintCaja(idAux)
        Me.Load_HistoricoCajas()
        Me.Load_CajaActual()
        Me.Load_InfoCajas()

        'Refresco estados
        Me.RefreshEstates()
    End Sub





    ' Modifico un ticket guardado
    Private Sub GridCajaClosed_CellMouseDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles GridCajaClosed.CellMouseDoubleClick
        Dim rst As ADODB.Recordset = My.m_db.GetRst("SELECT * FROM db_tickets WHERE id=" & Me.GridCajaClosed.SelectedRows(0).Cells(0).Value)

        'Muestro panel de ventas
        With My.Forms.frmPaneldeVentasResponsive
            .idRef = rst("id").Value
            .idMesa = rst("id_referencia").Value
            .idUser = rst("id_user").Value
            '.swCajaDirecta = Not (Me.LblHistory_Mesa.Tag = -1)

            .swFinalizado = True

            .ShowDialog(Me)
            If .DialogResult <> Windows.Forms.DialogResult.OK Then Exit Sub
            .Dispose()
        End With

        'Recargo la caja actual
        Me.Load_CajaHistoria(Me.GridHistorico.SelectedRows(0).Cells(0).Value)

        'Recargo valores
        rst = My.m_db.GetRst("SELECT SUM(total) AS nTOT FROM db_tickets WHERE id_caja=" & Me.GridHistorico.SelectedRows(0).Cells(0).Value)
        If rst.RecordCount > 0 Then
            Me.lblTOTAL_CajaNew.Text = Format(rst("nTOT").Value, "0.00")
        Else
            Me.lblTOTAL_CajaNew.Text = Format(0, "0.00")
        End If
        My.m_db.CloseRst(rst)

        rst = My.m_db.GetRst("SELECT COUNT(id) AS nTOT FROM db_tickets WHERE id_caja=" & Me.GridHistorico.SelectedRows(0).Cells(0).Value)
        If rst.RecordCount > 0 Then
            Me.lblTOTAL_nCajaNew.Text = Format(rst("nTOT").Value, "0")
        Else
            Me.lblTOTAL_nCajaNew.Text = Format(0, "0")
        End If
        My.m_db.CloseRst(rst)
    End Sub

End Class