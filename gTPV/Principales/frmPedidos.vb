Public Class frmPedidos
    Private _arrImgs() As PictureBox = Nothing
    Private _arrNames() As Label = Nothing

#Region "Variables Constantes"
    '# Contantes comunes sobre el formulario

    'Localizacion de inicio para el primer boton
    Dim _left As Integer = 1
    Dim _top As Integer = 1

    Private _default_color As Color = Color.YellowGreen
#End Region

#Region "Eventos Principales"
    Private Sub frmPaneldePedidos_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.Size = Screen.PrimaryScreen.WorkingArea.Size

        'Inicializo entorno
        If Not IsNothing(Me.Owner) Then
            Me.PnlBody.Left = CType(Me.Owner, frmMain).PnlBody.Left
            Me.PnlBody.Top = CType(Me.Owner, frmMain).PnlBody.Top
        Else
            Me.PnlBody.Left = (Me.Width - Me.PnlBody.Width) / 2
            Me.PnlBody.Top = (Me.SplitContainer.Panel2.Height - Me.PnlBody.Height) / 2 + (IIf(My.m_opt.swNoteBook, Me.SplitContainer.Panel1.Height, 0))
        End If

        Me.PnlBody.Visible = True



        'Cargo el historial de pedidos
        Me.Load_Pedidos()
        Me.Load_TicketsHistory(True)

        'Establezco la fecha y hora
        Me.LblHour.Text = Now.ToString("HH:mm")
        Me.TmHour.Enabled = True

        Me.BtHistory_Print.Enabled = Not (My.MyHardware.IdPort = 0)

    End Sub
#End Region

#Region "Manejadores"
    'Manejador Principal (Shell)
    Private Sub ShellApp(ByVal command As String)
        Dim cmd As String = command.ToUpper

        Select Case cmd
            Case "NUEVO"
                Dim id As Integer = 0
                Dim strName As String = "", strTlf As String = "", strDir As String = "", strDir_n As String = "", strDir_bloque As String = ""

                'Selecciono el cliente
                frmPedidos_SelectCliente.IdRef = -1
                frmPedidos_SelectCliente.ConfigureApp("clientes_pedidos")
                frmPedidos_SelectCliente.ShowDialog(Me)
                If frmPedidos_SelectCliente.DialogResult <> Windows.Forms.DialogResult.OK Then
                    frmPedidos_SelectCliente.Dispose()
                    frmPedidos_SelectCliente = Nothing
                    Exit Sub
                End If

                id = frmPedidos_SelectCliente.IdRef
                strName = frmPedidos_SelectCliente.strName
                strTlf = frmPedidos_SelectCliente.strTlf
                strDir = frmPedidos_SelectCliente.strDir
                strDir_n = frmPedidos_SelectCliente.strDir_n
                strDir_bloque = frmPedidos_SelectCliente.strDir_bloque

                frmPedidos_SelectCliente.Dispose()
                frmPedidos_SelectCliente = Nothing


                'Selecciono el repartidor
                Dim idUser As Integer = My.ValidateUser(True)
                If id = -1 Then Exit Sub

                'Muestro panel de ventas
                With My.Forms.frmPaneldePedidos
                    .idRef = -1
                    .idMesa = -2
                    .idUser = idUser
                    .idPedido = -1
                    .idCliente = id

                    'Establezco detalles del pedido
                    .lblPedido_Name.Text = strName
                    .lblPedido_Tlf.Text = strTlf

                    .lblPedido_Dir.Text = strDir
                    .lblPedido_DirN.Text = strDir_n
                    .lblPedido_DirBLoque.Text = strDir_bloque

                    'El usuario que edita la mesa
                    .swCajaDirecta = False

                    .ShowDialog(Me)
                    If .DialogResult = Windows.Forms.DialogResult.OK Then
                        Me.LblHour.Text = Now.ToString("HH:mm")
                        Me.TmHour.Enabled = True

                        Me.Load_Pedidos()

                        'Imprimo el pedido
                        For i As Integer = 0 To My.m_opt.nPrintCopiaPedidos - 1
                            My.PrintTicket(Me.gridPedidos.SelectedRows(0).Cells(1).Value, 0, True, Me.gridPedidos.SelectedRows(0).Cells(0).Value)
                        Next


                        If .swKill Then
                            ''Pongo estado por defecto
                            'Me.UpdateState_Ticket(CType(sender, PictureBox).Text, -1)

                            'Me.LoadInfo_LastTicket(.idRef)

                            'Me.Load_TicketsHistory(True)

                            'ElseIf .swReload Then
                            '    'Actualizo valores
                            '    Me.UpdateState_Ticket(CType(sender, PictureBox).Text, .idRef)

                            '    If .swChangeMesa Then Me.LoadZonas()
                        End If
                    End If
                    .Dispose()
                End With

            Case "CAJADIRECTA"
                'Obtengo Camarero
                Dim id As Integer = My.ValidateUser()
                If id = -1 Then Exit Sub

                'Muestro panel de ventas
                With My.Forms.frmPaneldeVentas
                    .idRef = -1
                    .idMesa = -1
                    .idUser = id
                    .swCajaDirecta = True

                    .ShowDialog(Me)
                    .Dispose()
                End With

                'Recargo valores
                Me.Load_TicketsHistory(True)

            Case "REPARTO"
                'Compruebo si hay usuarios marcados para el reparto
                Dim rst As ADODB.Recordset = Nothing
                rst = My.m_db.GetRst("SELECT id FROM db_usuarios WHERE swRepartidor=TRUE")
                If rst.RecordCount = 0 Then
                    MsgBox("No se ha establecido ningun empleado como repartidor, establezca uno para poder continuar.", MsgBoxStyle.Critical)
                    My.m_db.CloseRst(rst)
                    Exit Sub
                End If
                My.m_db.CloseRst(rst)

                'Selecciono el cliente
                frmPedidos_SelectCliente.IdRef = -1
                frmPedidos_SelectCliente.ConfigureApp("clientes_pedidos")
                frmPedidos_SelectCliente.ShowDialog(Me)
                If frmPedidos_SelectCliente.DialogResult <> Windows.Forms.DialogResult.OK Then
                    frmPedidos_SelectCliente.Dispose()
                    frmPedidos_SelectCliente = Nothing
                    Exit Sub
                End If

                frmPedidos_SelectCliente.Dispose()
                frmPedidos_SelectCliente = Nothing


                'Obtengo el repartidor
                Dim id As Integer = My.ValidateUser(True)
                If id = -1 Then Exit Sub


                MsgBox("reparto para " & id)

            Case "CANCEL"
                If MsgBox("¿Esta seguro que desea descartar los cambios que haya realizado?", MsgBoxStyle.YesNo + MsgBoxStyle.Question, My.APP_NAME) <> MsgBoxResult.Yes Then Exit Select
                Me.Close()

            Case "MINIMIZE"
                frm_AppIsMinimized.Show()

                Me.Owner.WindowState = FormWindowState.Minimized
                Me.WindowState = FormWindowState.Minimized

            Case "CLOSE"
                Me.Close()
            Case Else
                My.m_msg.MessageError(Me, "Comando de acción de " & cmd & " no controlado.")
        End Select
    End Sub
#End Region

#Region "Eventos Auxiliares"
    Private Sub Buttons_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtClose.Click, BtCajaDirecta.Click
        'Si no tiene establecido el tag mando un error
        If IsNothing(CType(sender, Button).Tag) OrElse CType(sender, Button).Tag.ToString.Length = 0 Then
            My.m_msg.MessageError(sender, "Tag de control de elemento no referenciado")
            Exit Sub
        End If

        ShellApp(CType(sender, Button).Tag.ToString)
    End Sub

    Private Sub m_logo_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles m_logo.DoubleClick
        My.OpenCajon()
    End Sub

    Private Sub TmHour_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.LblHour.Text = Now.ToString("HH:mm")
    End Sub

    Private Sub BtPrintLastTicket_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        My.PrintTicket(Me.lblHistory_ID.Text)
    End Sub
#End Region

#Region "Historial de Pedidos en Lista"
    'Cargo los pedidos activos
    Private Sub Load_Pedidos()
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
            ColStyle.Visible = False
            ColStyle.DefaultCellStyle = m_Style
            ColStyle.CellTemplate = Cell
            .Columns.Add(ColStyle)

            'El id del ticket
            ColStyle = New DataGridViewColumn()
            ColStyle.DataPropertyName = "idTicket"
            ColStyle.HeaderText = "IdTicket"
            ColStyle.Width = 0
            ColStyle.Visible = False
            ColStyle.DefaultCellStyle = m_Style
            ColStyle.CellTemplate = Cell
            .Columns.Add(ColStyle)

            'El id del cliente
            ColStyle = New DataGridViewColumn()
            ColStyle.DataPropertyName = "idUser"
            ColStyle.HeaderText = "IdUser"
            ColStyle.Width = 0
            ColStyle.Visible = False
            ColStyle.DefaultCellStyle = m_Style
            ColStyle.CellTemplate = Cell
            .Columns.Add(ColStyle)

            'El id del cliente
            ColStyle = New DataGridViewColumn()
            ColStyle.DataPropertyName = "idCliente"
            ColStyle.HeaderText = "IdCliente"
            ColStyle.Width = 0
            ColStyle.Visible = False
            ColStyle.DefaultCellStyle = m_Style
            ColStyle.CellTemplate = Cell
            .Columns.Add(ColStyle)

            ''La referencia
            'ColStyle = New DataGridViewColumn()
            'ColStyle.DataPropertyName = "n_ticket"
            'ColStyle.HeaderText = "Referencia"
            'ColStyle.Width = 80
            'ColStyle.DefaultCellStyle = m_Style
            'ColStyle.CellTemplate = Cell
            '.Columns.Add(ColStyle)

            'Fecha de creacion
            ColStyle = New DataGridViewColumn()
            ColStyle.DataPropertyName = "fh_alta"
            ColStyle.HeaderText = "Fecha de Pedido"
            ColStyle.Width = 160
            ColStyle.DefaultCellStyle = m_Style
            ColStyle.CellTemplate = Cell
            .Columns.Add(ColStyle)

            'El estado
            ColStyle = New DataGridViewColumn()
            ColStyle.DataPropertyName = "estado"
            ColStyle.HeaderText = "Estado"
            ColStyle.Width = 110
            ColStyle.DefaultCellStyle = m_Style
            ColStyle.CellTemplate = Cell
            .Columns.Add(ColStyle)

            'El cliente
            ColStyle = New DataGridViewColumn()
            ColStyle.DataPropertyName = "name_fiscal"
            ColStyle.HeaderText = "Cliente"
            ColStyle.Width = 250
            ColStyle.DefaultCellStyle = m_Style
            ColStyle.CellTemplate = Cell
            .Columns.Add(ColStyle)

            'El Telefono
            ColStyle = New DataGridViewColumn()
            ColStyle.DataPropertyName = "tlf"
            ColStyle.HeaderText = "Teléfono"
            ColStyle.Width = 110
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

            ''El id en de la mesa
            'ColStyle = New DataGridViewColumn()
            'ColStyle.DataPropertyName = "id_referencia"
            'ColStyle.HeaderText = "Ref Mesa"
            'ColStyle.Visible = False
            'ColStyle.DefaultCellStyle = m_Style
            'ColStyle.CellTemplate = Cell
            '.Columns.Add(ColStyle)
        End With

        'Asignamos los datos
        'rst = My.m_db.GetRst("SELECT db_tickets.id,db_tickets.n_ticket,db_tickets.fh_alta,db_tickets.estado,name,total,id_referencia FROM db_tickets,db_usuarios WHERE db_usuarios.id=db_tickets.id_user AND db_tickets.estado<>'FACTURADO' AND id_pedido=0 AND id_caja=-1 AND id_contable=" & My.m_app.GetValue("id_contable") & " AND ((db_tickets.fh_finaliza>=#" & Format(Me.DtCajaActual_Desde.Value, "MM-dd-yyyy") & " 00:00# AND db_tickets.fh_finaliza<=#" & Format(Me.DtCajaActual_Hasta.Value, "MM-dd-yyyy") & " 23:59#) OR isnull(db_tickets.fh_finaliza)) order by db_tickets.estado DESC, db_tickets.fh_finaliza DESC,db_tickets.fh_alta DESC")
        rst = My.m_db.GetRst("SELECT db_pedidos.*,db_clientes.name_fiscal,db_clientes.id AS idCliente,db_tickets.id AS idTicket,db_tickets.id_user AS idUser, db_tickets.total FROM db_pedidos,db_clientes,db_tickets WHERE db_tickets.id=db_pedidos.id_ticket AND db_pedidos.id_cliente=db_clientes.id AND db_tickets.id_caja=-1 ORDER BY db_pedidos.estado DESC,db_pedidos.id DESC, name_fiscal ASC")
        If IsNothing(rst) Then Exit Sub

        m_Table = New DataTable("m_tabla")
        da = New Data.OleDb.OleDbDataAdapter
        da.Fill(m_Table, rst)
        Me.gridPedidos.DataSource = m_Table


        'Permito borrar y volver a imprimir resumen
        Dim sw As Boolean = (Me.gridPedidos.RowCount > 0)
        Me.btPedido_Editar.Enabled = sw
        Me.btPedido_Del.Enabled = sw
        Me.btPedido_Print.Enabled = sw



        ''Preconfiguramos el grid de las ventas
        'With Me.gridPedidos
        '    .Columns.Clear()
        '    .AutoGenerateColumns = False
        '    .AlternatingRowsDefaultCellStyle = m_Style_alt
        '    .RowTemplate.Height = 30

        '    'El id
        '    ColStyle = New DataGridViewColumn()
        '    ColStyle.DataPropertyName = "id"
        '    ColStyle.HeaderText = "Id."
        '    ColStyle.Width = 0
        '    ColStyle.DefaultCellStyle = m_Style
        '    ColStyle.CellTemplate = Cell
        '    .Columns.Add(ColStyle)

        '    'La referencia
        '    ColStyle = New DataGridViewColumn()
        '    ColStyle.DataPropertyName = "n_ticket"
        '    ColStyle.HeaderText = "Referencia"
        '    ColStyle.Width = 0
        '    ColStyle.DefaultCellStyle = m_Style
        '    ColStyle.CellTemplate = Cell
        '    .Columns.Add(ColStyle)

        '    'Fecha de creacion
        '    ColStyle = New DataGridViewColumn()
        '    ColStyle.DataPropertyName = "fh_alta"
        '    ColStyle.HeaderText = "Fecha de Ticket"
        '    ColStyle.Width = 160
        '    ColStyle.DefaultCellStyle = m_Style
        '    ColStyle.CellTemplate = Cell
        '    .Columns.Add(ColStyle)

        '    'El cliente
        '    ColStyle = New DataGridViewColumn()
        '    ColStyle.DataPropertyName = "name_cliente"
        '    ColStyle.HeaderText = "Cliente"
        '    ColStyle.Width = 230
        '    ColStyle.DefaultCellStyle = m_Style
        '    ColStyle.CellTemplate = Cell
        '    .Columns.Add(ColStyle)

        '    'El estado
        '    ColStyle = New DataGridViewColumn()
        '    ColStyle.DataPropertyName = "estado"
        '    ColStyle.HeaderText = "Estado"
        '    ColStyle.Width = 0
        '    ColStyle.DefaultCellStyle = m_Style
        '    ColStyle.CellTemplate = Cell
        '    .Columns.Add(ColStyle)

        '    'El empleado
        '    ColStyle = New DataGridViewColumn()
        '    ColStyle.DataPropertyName = "name"
        '    ColStyle.HeaderText = "Repartidor"
        '    ColStyle.Width = 135
        '    ColStyle.DefaultCellStyle = m_Style
        '    ColStyle.CellTemplate = Cell
        '    .Columns.Add(ColStyle)

        '    'El total
        '    ColStyle = New DataGridViewColumn()
        '    ColStyle.DataPropertyName = "total"
        '    ColStyle.HeaderText = "Total"
        '    ColStyle.Width = 70
        '    ColStyle.DefaultCellStyle = m_Style
        '    ColStyle.CellTemplate = Cell
        '    .Columns.Add(ColStyle)

        '    'El id en de la mesa
        '    ColStyle = New DataGridViewColumn()
        '    ColStyle.DataPropertyName = "id_referencia"
        '    ColStyle.HeaderText = "Ref Mesa"
        '    ColStyle.Visible = False
        '    ColStyle.DefaultCellStyle = m_Style
        '    ColStyle.CellTemplate = Cell
        '    .Columns.Add(ColStyle)
        'End With

        ''Asignamos los datos
        'rst = My.m_db.GetRst("SELECT db_tickets.id,db_tickets.n_ticket,db_tickets.fh_alta,db_tickets.estado,name,total,id_referencia FROM db_tickets,db_usuarios WHERE db_usuarios.id=db_tickets.id_user AND db_tickets.estado<>'FACTURADO' AND id_pedido>0 AND id_caja=-1 AND id_contable=" & My.m_app.GetValue("id_contable") & " AND ((db_tickets.fh_finaliza>=#" & Format(Me.DtCajaActual_Desde.Value, "MM-dd-yyyy") & " 00:00# AND db_tickets.fh_finaliza<=#" & Format(Me.DtCajaActual_Hasta.Value, "MM-dd-yyyy") & " 23:59#) OR isnull(db_tickets.fh_finaliza)) order by db_tickets.estado DESC, db_tickets.fh_finaliza DESC,db_tickets.fh_alta DESC")
        ''rst = My.m_db.GetRst("SELECT db_tickets.id,db_tickets.fh_alta,db_tickets.estado,total FROM db_tickets WHERE id_caja=-1 AND id_contable=" & My.m_app.GetValue("id_contable") & "  order by db_tickets.fh_alta desc")
        'If IsNothing(rst) Then Exit Sub

        'm_Table = New DataTable("m_tabla")
        'da = New Data.OleDb.OleDbDataAdapter
        'da.Fill(m_Table, rst)
        'Me.gridPedidos.DataSource = m_Table

        'Me.CheckBtStates_CajaActual()
    End Sub

    Private Sub btPedido_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btPedido_Editar.Click, btPedido_Del.Click, btPedido_Print.Click, btPedido_Finalizar.Click, btPedido_Cancela.Click
        If Me.gridPedidos.SelectedRows.Count <= 0 Then
            MsgBox("Ningún pedido que procesar.", MsgBoxStyle.Exclamation)
            Exit Sub
        End If
        'Obtengo el ID seleccionado
        Dim id As Integer = Me.gridPedidos.SelectedRows(0).Cells(0).Value()

        Select Case True
            Case sender Is Me.btPedido_Editar
                'Muestro panel de ventas
                With My.Forms.frmPaneldePedidos
                    .idRef = Me.gridPedidos.SelectedRows(0).Cells(1).Value()
                    .idUser = Me.gridPedidos.SelectedRows(0).Cells(2).Value()
                    .idMesa = -2
                    .idPedido = id
                    .idCliente = Me.gridPedidos.SelectedRows(0).Cells(3).Value()

                    'El usuario que edita la mesa
                    .swCajaDirecta = False

                    .ShowDialog(Me)
                    If .DialogResult = Windows.Forms.DialogResult.OK Then
                        If .swKill Then
                            ''Pongo estado por defecto
                            'Me.UpdateState_Ticket(CType(sender, PictureBox).Text, -1)

                            'Me.LoadInfo_LastTicket(.idRef)

                            'Me.Load_TicketsHistory(True)

                            'ElseIf .swReload Then
                            '    'Actualizo valores
                            '    Me.UpdateState_Ticket(CType(sender, PictureBox).Text, .idRef)

                            '    If .swChangeMesa Then Me.LoadZonas()
                        End If
                    End If
                    .Dispose()
                End With

                Me.LblHour.Text = Now.ToString("HH:mm")
                Me.TmHour.Enabled = True

                Me.Load_Pedidos()

            Case sender Is Me.btPedido_Finalizar
                'Selecciono el usuario para el que voy a finalizar ventas
                Dim idUser As Integer = My.ValidateUser(True)
                If id = -1 Then Exit Sub

                frmPedidos_Finaliza.Id_Ref = idUser
                frmPedidos_Finaliza.ShowDialog(Me)
                If frmPedidos_Finaliza.DialogResult <> Windows.Forms.DialogResult.OK Then
                    frmPedidos_Finaliza.Dispose()
                    frmPedidos_Finaliza = Nothing
                    Exit Sub
                End If
                frmPedidos_Finaliza.Dispose()
                frmPedidos_Finaliza = Nothing

                'Recargo los pedidos
                Me.Load_Pedidos()

            Case sender Is Me.btPedido_Del
                If MsgBox("¿Este seguro de que desea eleminar el pedido?", MsgBoxStyle.OkCancel + MsgBoxStyle.Question) <> MsgBoxResult.Ok Then Exit Sub
                My.m_db.Execute("DELETE FROM db_pedidos WHERE id=" & id)
                My.m_db.Execute("DELETE FROM db_tickets WHERE id=" & Me.gridPedidos.SelectedRows(0).Cells(1).Value)

                Me.Load_Pedidos()

                'Case sender Is Me.btPedido_Cancela
                '    If MsgBox("¿Esta seguro de que desea cancelar los pedidos seleccionados?", MsgBoxStyle.OkCancel + MsgBoxStyle.Question) <> MsgBoxResult.Ok Then Exit Sub
                '    My.m_db.Execute("UPDATE db_pedidos SET estado='FINALIZADO',fh_finaliza=#" & Now & "# WHERE id=" & Me.lstPedidos.Items(i).Text)
                '    My.m_db.Execute("UPDATE db_tickets SET estado='FINALIZADO',fh_finaliza=#" & Now & "# WHERE id_pedido=" & Me.lstPedidos.Items(i).Text)


            Case sender Is Me.btPedido_Print
                My.PrintTicket(Me.gridPedidos.SelectedRows(0).Cells(1).Value, 0, True, Me.gridPedidos.SelectedRows(0).Cells(0).Value)





        End Select

    End Sub

    Private Sub gridPedidos_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles gridPedidos.CellDoubleClick
        Me.btPedido_Click(Me.btPedido_Editar, New System.EventArgs)
    End Sub

#End Region

#Region "Historial de Pedidos Rapido"
    Private rstHistory As ADODB.Recordset = Nothing          'Controlo los tickets de la caja actual

    'Cargo información sobre el historico de tickets
    Private Sub Load_TicketsHistory(ByVal ReloadHistory As Boolean)
        'Limpio valores
        Me.lblHistory_ID.Tag = 0
        Me.lblHistory_ID.Text = ""
        Me.LblHistory_Fh.Text = ""
        Me.LblHistory_Mesa.Text = ""
        Me.LblHistory_Empleado.Text = ""
        Me.LblHistory_Total.Text = ""

        'Si tengo que recargar la lista de tickets
        If ReloadHistory Then
            Me.rstHistory = My.m_db.GetRst("SELECT db_tickets.id,db_tickets.id_referencia,db_tickets.name_mesa,db_tickets.n_ticket,db_tickets.total,db_tickets.id_user,db_tickets.fh_finaliza,db_usuarios.name FROM db_tickets,db_usuarios WHERE db_usuarios.id=db_tickets.id_user AND id_caja=-1 AND db_tickets.estado='FINALIZADO' AND id_pedido> 0 ORDER BY db_tickets.fh_alta DESC")
            If Me.rstHistory.RecordCount = 0 Then
                Me.PnlHistory.Enabled = False
                Exit Sub
            End If

            Me.BtHistory_Next.Enabled = Not (Me.rstHistory.Bookmark = 1)
            Me.BtHistory_Previous.Enabled = Not (Me.rstHistory.Bookmark = Me.rstHistory.RecordCount)
        End If

        'Asigno los valores del ticket
        Me.lblHistory_ID.Tag = Me.rstHistory("id").Value
        If Not IsDBNull(Me.rstHistory("n_ticket").Value) AndAlso Len(Me.rstHistory("n_ticket").Value) > 0 Then
            Me.lblHistory_ID.Text = "Ticket: " & Me.rstHistory("n_ticket").Value
        Else
            Me.lblHistory_ID.Text = "Ref. Ticket: " & Me.rstHistory("id").Value
        End If
        Me.LblHistory_Fh.Text = "Fecha: " & Format(Me.rstHistory("fh_finaliza").Value, "dd/MM/yyyy HH:mm")
        Me.LblHistory_Empleado.Tag = Me.rstHistory("id_user").Value
        Me.LblHistory_Empleado.Text = Me.rstHistory("name").Value
        Me.LblHistory_Total.Text = Format(Me.rstHistory("total").Value, "0.00") & " " & System.Threading.Thread.CurrentThread.CurrentCulture.NumberFormat.CurrencySymbol
        Me.LblHistory_Mesa.Text = Me.rstHistory("name_mesa").Value


        Me.GroupHistory.Text = "Historial de Tickets (" & Me.rstHistory.Bookmark & "/" & Me.rstHistory.RecordCount & ")"

        'Obtengo la mesa en la que ha sido
        Me.LblHistory_Mesa.Tag = Me.rstHistory("id_referencia").Value
        'If Me.rstHistory("id_referencia").Value = -1 Then         'Si es caja directa
        '    Me.LblHistory_Mesa.Text = "CAJA DIRECTA"
        'Else
        '    Dim rst As ADODB.Recordset = My.m_db.GetRst("SELECT name FROM db_design WHERE id=" & Me.rstHistory("id_referencia").Value)
        '    Me.LblHistory_Mesa.Text = rst("name").Value
        '    My.m_db.CloseRst(rst)
        'End If

        Me.PnlHistory.Enabled = True
        'Me.GroupHistory.Visible = True


        'Me.LblLastRef.Text = id_ticket
        'Me.PnlLast.Visible = True
        'Me.Group_Last.Enabled = True
    End Sub

    'Me muevo en el historial de los tickets de la caja actual
    Private Sub BtHistory_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtHistory_Previous.Click, BtHistory_Next.Click
        'Hago el movimiento
        Select Case True
            Case sender Is Me.BtHistory_Next : Me.rstHistory.MovePrevious()
            Case sender Is Me.BtHistory_Previous : Me.rstHistory.MoveNext()
        End Select

        'Establezco estados y recargo
        'Me.BtHistory_Next.Enabled = Not Me.rstHistory.BOF
        'Me.BtHistory_Previous.Enabled = Not Me.rstHistory.BOF

        Me.BtHistory_Next.Enabled = Not (Me.rstHistory.Bookmark = 1)
        Me.BtHistory_Previous.Enabled = Not (Me.rstHistory.Bookmark = Me.rstHistory.RecordCount)
        Me.Load_TicketsHistory(False)

    End Sub

    Private Sub BtHistory_Print_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtHistory_Print.Click
        My.PrintTicket(Me.lblHistory_ID.Tag)
    End Sub

    Private Sub BtHistory_Edit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtHistory_Edit.Click
        'Muestro panel de ventas
        With My.Forms.frmPaneldeVentas
            .idRef = Me.lblHistory_ID.Tag                           'El id del ticket
            .idMesa = Me.LblHistory_Mesa.Tag          'El id de la mesa
            .idUser = Me.LblHistory_Empleado.Tag        'El usuario que edita la mesa
            .swCajaDirecta = Not (Me.LblHistory_Mesa.Tag = -1)

            .swFinalizado = True

            .ShowDialog(Me)
            If .DialogResult = Windows.Forms.DialogResult.OK Then
                Me.Load_TicketsHistory(True)
            End If
            .Dispose()
        End With
    End Sub
#End Region



    

    Private Sub Tab_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Tab.SelectedIndexChanged
        Select Case True
            Case Me.Tab.SelectedTab Is Me.TabPage_articulos : Me.LoadHistory()
        End Select
    End Sub












#Region "Historial de Productos"
    Private Sub GridHistory_CurrentCellChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles GridHistory.CurrentCellChanged
        Me.LoadHistoryLines()
    End Sub

    Private Sub LoadHistory()
        Dim m_Table As DataTable            'Tabla de datos
        Dim rst As ADODB.Recordset
        Dim da As Data.OleDb.OleDbDataAdapter
        Dim ColStyle As DataGridViewColumn
        Dim Cell As DataGridViewCell = New DataGridViewTextBoxCell()

        Dim m_Style As New DataGridViewCellStyle

        'El estilo de las celdas
        With m_Style
            .BackColor = Color.FromKnownColor(KnownColor.GradientActiveCaption)
            .ForeColor = Color.Black
            .Font = New Font("Verdana", 8)
        End With

        Dim m_Style_alt As New DataGridViewCellStyle
        With m_Style_alt
            .BackColor = Color.FromKnownColor(KnownColor.GradientInactiveCaption)
            .ForeColor = Color.Black
            .Font = New Font("Verdana", 8)
        End With

        'Preconfiguramos el grid de las ventas
        With Me.GridHistory
            .Columns.Clear()
            .AutoGenerateColumns = False

            'El id
            ColStyle = New DataGridViewColumn()
            ColStyle.DataPropertyName = "id"
            ColStyle.HeaderText = "Ref."
            ColStyle.Width = 0
            ColStyle.Visible = False
            ColStyle.DefaultCellStyle = m_Style
            ColStyle.CellTemplate = Cell
            .Columns.Add(ColStyle)

            'El id del ticket
            ColStyle = New DataGridViewColumn()
            ColStyle.DataPropertyName = "idTicket"
            ColStyle.HeaderText = "RefTicket"
            ColStyle.Width = 0
            ColStyle.Visible = False
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

            'El ticket
            ColStyle = New DataGridViewColumn()
            ColStyle.DataPropertyName = "n_ticket"
            ColStyle.HeaderText = "Ticket"
            ColStyle.Width = 70
            ColStyle.DefaultCellStyle = m_Style
            ColStyle.CellTemplate = Cell
            .Columns.Add(ColStyle)

            'El cliente
            ColStyle = New DataGridViewColumn()
            ColStyle.DataPropertyName = "nameArt"
            ColStyle.HeaderText = "Artículo"
            ColStyle.Width = 180
            ColStyle.DefaultCellStyle = m_Style
            ColStyle.CellTemplate = Cell
            .Columns.Add(ColStyle)

            ''La fecha
            'ColStyle = New DataGridViewColumn()
            'ColStyle.DataPropertyName = "fh_venta"
            'ColStyle.HeaderText = "Fh Venta"
            'ColStyle.Width = 80
            'ColStyle.DefaultCellStyle = m_Style
            'ColStyle.CellTemplate = Cell
            '.Columns.Add(ColStyle)

            ''La factura
            'ColStyle = New DataGridViewColumn()
            'ColStyle.DataPropertyName = "factura"
            'ColStyle.HeaderText = "Factura"
            'ColStyle.Width = 80
            'ColStyle.DefaultCellStyle = m_Style
            'ColStyle.CellTemplate = Cell
            '.Columns.Add(ColStyle)

            ''La fecha de la factura
            'ColStyle = New DataGridViewColumn()
            'ColStyle.DataPropertyName = "fh_factura"
            'ColStyle.HeaderText = "Fh Factura"
            'ColStyle.Width = 80
            'ColStyle.DefaultCellStyle = m_Style
            'ColStyle.CellTemplate = Cell
            '.Columns.Add(ColStyle)

            'Las unidades
            ColStyle = New DataGridViewColumn()
            ColStyle.DataPropertyName = "ud"
            ColStyle.HeaderText = "Ud."
            ColStyle.Width = 40
            ColStyle.DefaultCellStyle = m_Style
            ColStyle.CellTemplate = Cell
            .Columns.Add(ColStyle)

            'El total
            ColStyle = New DataGridViewColumn()
            ColStyle.DataPropertyName = "total"
            ColStyle.HeaderText = "Importe"
            ColStyle.Width = 50
            ColStyle.DefaultCellStyle = m_Style
            ColStyle.CellTemplate = Cell
            .Columns.Add(ColStyle)

            .AlternatingRowsDefaultCellStyle = m_Style_alt
        End With


        'Asignamos los datos
        'rst = My.m_db.GetRst("SELECT id,fh_venta,factura,fh_factura,pvp_total from cab_ventas where id_contable=" & MyCfg.Id_Contable & " AND estado='FACTURA' AND id_factura>0 AND id_cliente=" & Me.TxtCliente_Id.Text & " AND id<>" & Me.LblId.Text & IIf(Me.SwShowTipoB, "", " AND tipo_venta='A'") & " ORDER BY fh_factura DESC,fh_venta DESC,id ASC")
        rst = My.m_db.GetRst("SELECT db_pedidos.*,db_tickets_lines.name as nameArt,db_tickets_lines.ud,db_tickets_lines.total,db_clientes.name_fiscal,db_clientes.id AS idCliente,db_tickets.id AS idTicket,db_tickets.n_ticket,db_tickets.id_user AS idUser FROM db_pedidos,db_clientes,db_tickets,db_tickets_lines WHERE db_tickets_lines.id_ticket=db_tickets.id AND db_tickets.id=db_pedidos.id_ticket AND db_pedidos.id_cliente=db_clientes.id AND db_tickets.id_caja=-1 ORDER BY db_pedidos.estado DESC,db_pedidos.id DESC, name_fiscal ASC")
        If IsNothing(rst) Then Exit Sub

        m_Table = New DataTable("m_tabla")
        da = New Data.OleDb.OleDbDataAdapter
        da.Fill(m_Table, rst)
        Me.GridHistory.DataSource = m_Table

        Me.LoadHistoryLines()
    End Sub

    Private Sub LoadHistoryLines()
        If Me.GridHistory.SelectedRows.Count = 0 Then Exit Sub

        Dim m_Table As DataTable            'Tabla de datos
        Dim rst As ADODB.Recordset
        Dim da As Data.OleDb.OleDbDataAdapter
        Dim ColStyle As DataGridViewColumn
        Dim Cell As DataGridViewCell = New DataGridViewTextBoxCell()

        Dim m_Style As New DataGridViewCellStyle

        'El estilo de las celdas
        With m_Style
            .BackColor = Color.FromKnownColor(KnownColor.GradientActiveCaption)
            .ForeColor = Color.Black
            .Font = New Font("Verdana", 8)
        End With

        Dim m_Style_alt As New DataGridViewCellStyle
        With m_Style_alt
            .BackColor = Color.FromKnownColor(KnownColor.GradientInactiveCaption)
            .ForeColor = Color.Black
            .Font = New Font("Verdana", 8)
        End With

        'Preconfiguramos el grid de las ventas
        With Me.GridHistoryLines
            .Columns.Clear()
            .AutoGenerateColumns = False

            'El artículo
            ColStyle = New DataGridViewColumn()
            ColStyle.DataPropertyName = "name"
            ColStyle.HeaderText = "Artículo"
            ColStyle.Width = 180
            ColStyle.DefaultCellStyle = m_Style
            ColStyle.CellTemplate = Cell
            .Columns.Add(ColStyle)

            'Las Unidades
            ColStyle = New DataGridViewColumn()
            ColStyle.DataPropertyName = "nTot"
            ColStyle.HeaderText = "Ud."
            ColStyle.Width = 35
            ColStyle.DefaultCellStyle = m_Style
            ColStyle.CellTemplate = Cell
            .Columns.Add(ColStyle)


            ''Los Totales
            'ColStyle = New DataGridViewColumn()
            'ColStyle.DataPropertyName = "nTotPVP"
            'ColStyle.HeaderText = "Total"
            'ColStyle.Width = 45
            'ColStyle.DefaultCellStyle = m_Style
            'ColStyle.CellTemplate = Cell
            '.Columns.Add(ColStyle)

            .AlternatingRowsDefaultCellStyle = m_Style_alt
        End With

        Dim str As String = "", i As Integer = 0
        For i = 0 To Me.GridHistory.SelectedRows.Count - 1
            str &= IIf(str.Length > 0, " OR ", "") & "id_ticket=" & Me.GridHistory.SelectedRows(i).Cells(1).Value
        Next

        'Asignamos los datos
        'rst = My.Application.m_Db.GetRst("SELECT name,ud FROM lin_ventas where " & str & " ORDER BY name ASC")
        rst = My.m_db.GetRst("SELECT name,SUM(ud) AS nTot,SUM(total) AS nTotPVP FROM db_tickets_lines where " & str & " GROUP BY name")
        If IsNothing(rst) Then Exit Sub

        m_Table = New DataTable("m_tabla")
        da = New Data.OleDb.OleDbDataAdapter
        da.Fill(m_Table, rst)
        Me.GridHistoryLines.DataSource = m_Table

        'Especifico el acumulado si corresponde a un ticket o a multiples
        If Me.GridHistory.SelectedRows.Count > 1 Then
            Me.lblTicket.Text = "!= <>>"
        Else
            Me.lblTicket.Text = Me.GridHistory.SelectedRows(0).Cells(3).Value
        End If

    End Sub


    'Se seleccionan todos pedidos
    Private Sub btAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btAll.Click
        For i As Integer = 0 To Me.GridHistory.RowCount - 1
            Me.GridHistory.Rows(i).Selected = True
        Next
        Me.LoadHistoryLines()
    End Sub
#End Region

End Class