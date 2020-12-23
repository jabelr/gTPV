Public Class frmEstanco
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

    Private Sub frmEstanco_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        My.AsignarFoco(Me.TxtFind)
    End Sub

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

        Me.dtFhUpdate.Value = CDate("01/01/1900")


        'Cargo el historial de pedidos
        Me.Load_Marcas()
        Me.Load_TicketsHistory(True)

        'Establezco la fecha y hora
        Me.LblHour.Text = Now.ToString("HH:mm")
        Me.TmHour.Enabled = True

        Me.BtHistory_Print.Enabled = Not (My.MyHardware.IdPort = 0)


        'Configuro el listView de los precios
        With Me.lstImportaPrecios
            .Columns.Clear()
            .Columns.Add("", 40, HorizontalAlignment.Right)
            .Columns.Add("Código", 80, HorizontalAlignment.Right)
            .Columns.Add("idMarca", 0, HorizontalAlignment.Right)
            .Columns.Add("Marca", 240, HorizontalAlignment.Left)
            .Columns.Add("Precio Actual", 150, HorizontalAlignment.Right)
            .Columns.Add("Precio Revisado", 150, HorizontalAlignment.Right)
        End With

        'Me.Tab.TabPages.Remove(Me.TabPage_articulos)
    End Sub
#End Region

#Region "Manejadores"
    'Manejador Principal (Shell)
    Private Sub ShellApp(ByVal command As String)
        Dim cmd As String = command.ToUpper

        Select Case cmd
            Case "UPDATE"
                Me.UpdatePrecios()

            Case "IMPORTAR"
                If MsgBox("¿Importar precios de tabla?", MsgBoxStyle.OkCancel) <> MsgBoxResult.Ok Then Exit Sub

                Exit Sub

                My.m_db.Execute("DELETE FROM estanco_marcas")

                Dim rst As ADODB.Recordset = Nothing, rstNew As ADODB.Recordset = Nothing
                rst = My.m_db.GetRst("SELECT * FROM estanco_marcas2")
                rstNew = My.m_db.GetRst("SELECT * FROM estanco_marcas WHERE id=-1")

                While Not rst.EOF
                    If CDbl(rst("art_pvp200").Value) > 0 Then
                        rstNew.AddNew()
                        rstNew("cod_barras").Value = Trim(rst("cod_barras").Value)
                        rstNew("codigo").Value = Trim(rst("art_codsap").Value & "")
                        rstNew("name").Value = Trim(rst("art_descri").Value)
                        If Not IsDBNull(rst("art_pvp200").Value) Then rstNew("precio").Value = CDbl(rst("art_pvp200").Value)
                        'rstNew("fh_alta").Value = Now

                        rstNew("id_tipo").Value = 0

                        rstNew.Update()
                    End If
                    rst.MoveNext()
                End While
                My.m_db.CloseRst(rst)


                MsgBox("No implementado", MsgBoxStyle.Exclamation)

            Case "NUEVO"
                'Dim id As Integer = 0
                'Dim strName As String = "", strTlf As String = "", strDir As String = "", strDir_n As String = "", strDir_bloque As String = ""

                ''Selecciono el cliente
                'frmEstanco_SelectCliente.IdRef = -1
                'frmEstanco_SelectCliente.ConfigureApp("clientes_pedidos")
                'frmEstanco_SelectCliente.ShowDialog(Me)
                'If frmEstanco_SelectCliente.DialogResult <> Windows.Forms.DialogResult.OK Then
                '    frmEstanco_SelectCliente.Dispose()
                '    frmEstanco_SelectCliente = Nothing
                '    Exit Sub
                'End If

                'id = frmEstanco_SelectCliente.IdRef
                'strName = frmEstanco_SelectCliente.strName
                'strTlf = frmEstanco_SelectCliente.strTlf
                'strDir = frmEstanco_SelectCliente.strDir
                'strDir_n = frmEstanco_SelectCliente.strDir_n
                'strDir_bloque = frmEstanco_SelectCliente.strDir_bloque

                'frmEstanco_SelectCliente.Dispose()
                'frmEstanco_SelectCliente = Nothing


                ''Selecciono el repartidor
                'Dim idUser As Integer = My.ValidateUser(True)
                'If id = -1 Then Exit Sub

                ''Muestro panel de ventas
                'With My.Forms.frmPaneldePedidos
                '    .idRef = -1
                '    .idMesa = -2
                '    .idUser = idUser
                '    .idPedido = -1
                '    .idCliente = id

                '    'Establezco detalles del pedido
                '    .lblPedido_Name.Text = strName
                '    .lblPedido_Tlf.Text = strTlf

                '    .lblPedido_Dir.Text = strDir
                '    .lblPedido_DirN.Text = strDir_n
                '    .lblPedido_DirBLoque.Text = strDir_bloque

                '    'El usuario que edita la mesa
                '    .swCajaDirecta = False

                '    .ShowDialog(Me)
                '    If .DialogResult = Windows.Forms.DialogResult.OK Then
                '        Me.LblHour.Text = Now.ToString("HH:mm")
                '        Me.TmHour.Enabled = True

                '        Me.Load_Pedidos()

                '        'Imprimo el pedido
                '        For i As Integer = 0 To My.m_opt.nPrintCopiaPedidos - 1
                '            My.PrintTicket(Me.gridPedidos.SelectedRows(0).Cells(1).Value, 0, True, Me.gridPedidos.SelectedRows(0).Cells(0).Value)
                '        Next


                '        If .swKill Then
                '            ''Pongo estado por defecto
                '            'Me.UpdateState_Ticket(CType(sender, PictureBox).Text, -1)

                '            'Me.LoadInfo_LastTicket(.idRef)

                '            'Me.Load_TicketsHistory(True)

                '            'ElseIf .swReload Then
                '            '    'Actualizo valores
                '            '    Me.UpdateState_Ticket(CType(sender, PictureBox).Text, .idRef)

                '            '    If .swChangeMesa Then Me.LoadZonas()
                '        End If
                '    End If
                '    .Dispose()
                'End With

            Case "CAJADIRECTA"
                ''Obtengo Camarero
                'Dim id As Integer = My.ValidateUser()
                'If id = -1 Then Exit Sub

                ''Muestro panel de ventas
                'With My.Forms.frmPaneldeVentas
                '    .idRef = -1
                '    .idMesa = -1
                '    .idUser = id
                '    .swCajaDirecta = True

                '    .ShowDialog(Me)
                '    .Dispose()
                'End With

                ''Recargo valores
                'Me.Load_TicketsHistory(True)

            Case "REPARTO"
                ''Compruebo si hay usuarios marcados para el reparto
                'Dim rst As ADODB.Recordset = Nothing
                'rst = My.m_db.GetRst("SELECT id FROM db_usuarios WHERE swRepartidor=TRUE")
                'If rst.RecordCount = 0 Then
                '    MsgBox("No se ha establecido ningun empleado como repartidor, establezca uno para poder continuar.", MsgBoxStyle.Critical)
                '    My.m_db.CloseRst(rst)
                '    Exit Sub
                'End If
                'My.m_db.CloseRst(rst)

                ''Selecciono el cliente
                'frmEstanco_SelectCliente.IdRef = -1
                'frmEstanco_SelectCliente.ConfigureApp("clientes_pedidos")
                'frmEstanco_SelectCliente.ShowDialog(Me)
                'If frmEstanco_SelectCliente.DialogResult <> Windows.Forms.DialogResult.OK Then
                '    frmEstanco_SelectCliente.Dispose()
                '    frmEstanco_SelectCliente = Nothing
                '    Exit Sub
                'End If

                'frmEstanco_SelectCliente.Dispose()
                'frmEstanco_SelectCliente = Nothing


                ''Obtengo el repartidor
                'Dim id As Integer = My.ValidateUser(True)
                'If id = -1 Then Exit Sub


                'MsgBox("reparto para " & id)

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
    Private Sub Buttons_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtClose.Click, BtUpdatePVP.Click, btImportar.Click
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

#Region "Marcas en Lista"
    'Cargo las marcas
    Private Sub Load_Marcas()
        Dim m_Table As DataTable            'Tabla de datos
        Dim rst As ADODB.Recordset
        Dim da As Data.OleDb.OleDbDataAdapter
        Dim ColStyle As DataGridViewColumn
        Dim Cell As DataGridViewCell = New DataGridViewTextBoxCell()

        Dim strWhere As String = ""

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
            ColStyle.Visible = False
            ColStyle.DefaultCellStyle = m_Style
            ColStyle.CellTemplate = Cell
            .Columns.Add(ColStyle)

            'Las marcas
            ColStyle = New DataGridViewColumn()
            ColStyle.DataPropertyName = "name"
            ColStyle.HeaderText = "Marca"
            ColStyle.Width = 320
            ColStyle.DefaultCellStyle = m_Style
            ColStyle.CellTemplate = Cell
            .Columns.Add(ColStyle)

            'El precio
            ColStyle = New DataGridViewColumn()
            ColStyle.DataPropertyName = "precio"
            ColStyle.HeaderText = "Precio"
            ColStyle.Width = 65
            ColStyle.DefaultCellStyle = m_Style
            ColStyle.CellTemplate = Cell
            .Columns.Add(ColStyle)

            ''El precio + recargo
            'ColStyle = New DataGridViewColumn()
            'ColStyle.DataPropertyName = "precio_recargo"
            'ColStyle.HeaderText = "Precio R."
            'ColStyle.Width = 65
            'ColStyle.DefaultCellStyle = m_Style
            'ColStyle.CellTemplate = Cell
            '.Columns.Add(ColStyle)

            ''Fecha de actualización
            'ColStyle = New DataGridViewColumn()
            'ColStyle.DataPropertyName = "fh_updatePrecio"
            'ColStyle.HeaderText = "Fh. Actualización"
            'ColStyle.Width = 160
            'ColStyle.DefaultCellStyle = m_Style
            'ColStyle.CellTemplate = Cell
            '.Columns.Add(ColStyle)

            'El(código)
            ColStyle = New DataGridViewColumn()
            ColStyle.DataPropertyName = "codigo"
            ColStyle.HeaderText = "Código CMT"
            ColStyle.Width = 120
            ColStyle.DefaultCellStyle = m_Style
            ColStyle.CellTemplate = Cell
            .Columns.Add(ColStyle)

            'Las unidades
            ColStyle = New DataGridViewColumn()
            ColStyle.DataPropertyName = "ud"
            ColStyle.HeaderText = "Ud."
            ColStyle.Width = 50
            ColStyle.DefaultCellStyle = m_Style
            ColStyle.CellTemplate = Cell
            .Columns.Add(ColStyle)

            'Las unidades x10
            ColStyle = New DataGridViewColumn()
            ColStyle.DataPropertyName = "ud_x10"
            ColStyle.HeaderText = "Ud.x10"
            ColStyle.Width = 50
            ColStyle.DefaultCellStyle = m_Style
            ColStyle.CellTemplate = Cell
            .Columns.Add(ColStyle)

        End With

        'Filtro especial de letras (cuando esta visible y he aplicado un filtro de letra)
        If Me.PnlFilter.Visible AndAlso Not Me.Rbt_Filter_All.Checked Then
            strWhere &= " AND name LIKE '" & Me.PnlFilter.Tag & "%'"
        End If

        If Me.chkActivo.Checked Then strWhere &= " AND activo=TRUE "

        'Filtro por nombre
        For Each strAux As String In Me.TxtFind.Text.Split(" ")
            strAux = strAux.Trim
            If strAux.Length > 0 Then
                'Sql &= IIf(Sql.Length = 0, "", " AND ") & " name LIKE '%" & strAux & "%'"
                strWhere &= " AND " & " name LIKE '%" & strAux & "%'"
            End If
        Next


        'Filtro de nombre
        'strWhere &= " AND name LIKE '%" & Me.TxtFind.Text & "%'"
        strWhere &= " AND (fh_updatePrecio>=#" & Format(Me.dtFhUpdate.Value, "MM-dd-yyyy") & " 00:00# OR isnull(fh_updatePrecio))"

        'Asignamos los datos
        'rst = My.m_db.GetRst("SELECT db_tickets.id,db_tickets.n_ticket,db_tickets.fh_alta,db_tickets.estado,name,total,id_referencia FROM db_tickets,db_usuarios WHERE db_usuarios.id=db_tickets.id_user AND db_tickets.estado<>'FACTURADO' AND id_pedido=0 AND id_caja=-1 AND id_contable=" & My.m_app.GetValue("id_contable") & " AND ((db_tickets.fh_finaliza>=#" & Format(Me.DtCajaActual_Desde.Value, "MM-dd-yyyy") & " 00:00# AND db_tickets.fh_finaliza<=#" & Format(Me.DtCajaActual_Hasta.Value, "MM-dd-yyyy") & " 23:59#) OR isnull(db_tickets.fh_finaliza)) order by db_tickets.estado DESC, db_tickets.fh_finaliza DESC,db_tickets.fh_alta DESC")
        'rst = My.m_db.GetRst("SELECT db_pedidos.*,db_clientes.name_fiscal,db_clientes.id AS idCliente,db_tickets.id AS idTicket,db_tickets.id_user AS idUser, db_tickets.total FROM db_pedidos,db_clientes,db_tickets WHERE db_tickets.id=db_pedidos.id_ticket AND db_pedidos.id_cliente=db_clientes.id AND db_tickets.id_caja=-1 ORDER BY db_pedidos.estado DESC,db_pedidos.id DESC, name_fiscal ASC")
        rst = My.m_db.GetRst("SELECT id,cod_barras,name,precio,precio_recargo,fh_updatePrecio,ud,ud_x10 FROM estanco_marcas WHERE 1=1 " & strWhere & " ORDER BY name ASC")
        If IsNothing(rst) Then Exit Sub

        m_Table = New DataTable("m_tabla")
        da = New Data.OleDb.OleDbDataAdapter
        da.Fill(m_Table, rst)
        Me.gridMarcas.DataSource = m_Table

        Me.lblTotProductos.Text = rst.RecordCount

        Me.lblInfo.Text = "Mostrando " & rst.RecordCount

        'Permito borrar y volver a imprimir resumen
        Dim sw As Boolean = (Me.gridMarcas.RowCount > 0)
        Me.btMarca_edit.Enabled = sw
        Me.btMarca_del.Enabled = sw

    End Sub

    'Seleccion de filtro
    Private Sub rbtFilter_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Rbt_Filter_All.CheckedChanged, V.CheckedChanged, Rbt_Filter_Z.CheckedChanged, Rbt_Filter_Y.CheckedChanged, Rbt_Filter_X.CheckedChanged, Rbt_Filter_W.CheckedChanged, Rbt_Filter_U.CheckedChanged, Rbt_Filter_T.CheckedChanged, Rbt_Filter_S.CheckedChanged, Rbt_Filter_R.CheckedChanged, Rbt_Filter_Q.CheckedChanged, Rbt_Filter_P.CheckedChanged, Rbt_Filter_O.CheckedChanged, Rbt_Filter_Ñ.CheckedChanged, Rbt_Filter_N.CheckedChanged, Rbt_Filter_M.CheckedChanged, Rbt_Filter_L.CheckedChanged, Rbt_Filter_K.CheckedChanged, Rbt_Filter_J.CheckedChanged, Rbt_Filter_I.CheckedChanged, Rbt_Filter_H.CheckedChanged, Rbt_Filter_G.CheckedChanged, Rbt_Filter_F.CheckedChanged, Rbt_Filter_E.CheckedChanged, Rbt_Filter_D.CheckedChanged, Rbt_Filter_C.CheckedChanged, Rbt_Filter_B.CheckedChanged, Rbt_Filter_A.CheckedChanged
        'Caso de que no este chequeado restauro valores
        If Not CType(sender, RadioButton).Checked Then
            CType(sender, RadioButton).Font = New Font("Microsoft Sans Serif", 8.25)
            Exit Sub
        End If

        'Si he seleccionado uno, quito 
        CType(sender, RadioButton).Font = New Font("Microsoft Sans Serif", 8, FontStyle.Bold)
        Me.PnlFilter.Tag = CType(sender, RadioButton).Text

        Me.Load_Marcas()
    End Sub

    Private Sub btMarcas_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btMarca_Add.Click, btMarca_del.Click, btPedido_Print.Click, btPedido_Finalizar.Click, btPedido_Cancela.Click, btMarca_edit.Click
        If Me.gridMarcas.SelectedRows.Count <= 0 Then
            MsgBox("Ninguna marca que procesar.", MsgBoxStyle.Exclamation)
            Exit Sub
        End If
        'Obtengo el ID seleccionado
        Dim id As Integer = Me.gridMarcas.SelectedRows(0).Cells(0).Value()

        Select Case True
            Case sender Is Me.btMarca_Add
                'Muestro el formulario de lineas
                With frmEstanco_Marca
                    .Id_Ref = 0
                    .ShowDialog(Me)
                    If .DialogResult <> Windows.Forms.DialogResult.OK Then
                        .Dispose()
                        Exit Sub
                    End If
                    .Dispose()
                End With

                Me.LblHour.Text = Now.ToString("HH:mm")
                Me.TmHour.Enabled = True

                Me.Load_Marcas()

            Case sender Is Me.btMarca_edit
                'Muestro el formulario de lineas
                With frmEstanco_Marca
                    .Id_Ref = Me.gridMarcas.SelectedRows(0).Cells(0).Value
                    .ShowDialog(Me)
                    If .DialogResult <> Windows.Forms.DialogResult.OK Then
                        .Dispose()
                        Exit Sub
                    End If
                    .Dispose()
                End With

                Me.LblHour.Text = Now.ToString("HH:mm")
                Me.TmHour.Enabled = True

                Me.Load_Marcas()



                'Case sender Is Me.btPedido_Finalizar
                '    'Selecciono el usuario para el que voy a finalizar ventas
                '    Dim idUser As Integer = My.ValidateUser(True)
                '    If id = -1 Then Exit Sub

                '    'frmEstanco_Finaliza.Id_Ref = idUser
                '    'frmEstanco_Finaliza.ShowDialog(Me)
                '    'If frmEstanco_Finaliza.DialogResult <> Windows.Forms.DialogResult.OK Then
                '    '    frmEstanco_Finaliza.Dispose()
                '    '    frmEstanco_Finaliza = Nothing
                '    '    Exit Sub
                '    'End If
                '    'frmEstanco_Finaliza.Dispose()
                '    'frmEstanco_Finaliza = Nothing

                '    'Recargo los pedidos
                '    Me.Load_Marcas()

            Case sender Is Me.btMarca_del
                If MsgBox("¿Este seguro de que desea eleminar la marca?", MsgBoxStyle.OkCancel + MsgBoxStyle.Question) <> MsgBoxResult.Ok Then Exit Sub
                'My.m_db.Execute("DELETE FROM db_pedidos WHERE id=" & id)
                My.m_db.Execute("DELETE FROM estanco_marcas WHERE id=" & Me.gridMarcas.SelectedRows(0).Cells(0).Value)

                Me.Load_Marcas()

                'Case sender Is Me.btPedido_Cancela
                '    If MsgBox("¿Esta seguro de que desea cancelar los pedidos seleccionados?", MsgBoxStyle.OkCancel + MsgBoxStyle.Question) <> MsgBoxResult.Ok Then Exit Sub
                '    My.m_db.Execute("UPDATE db_pedidos SET estado='FINALIZADO',fh_finaliza=#" & Now & "# WHERE id=" & Me.lstPedidos.Items(i).Text)
                '    My.m_db.Execute("UPDATE db_tickets SET estado='FINALIZADO',fh_finaliza=#" & Now & "# WHERE id_pedido=" & Me.lstPedidos.Items(i).Text)


                'Case sender Is Me.btPedido_Print
                '    My.PrintTicket(Me.gridMarcas.SelectedRows(0).Cells(1).Value, 0, True, Me.gridMarcas.SelectedRows(0).Cells(0).Value)





        End Select

    End Sub

    Private Sub gridMarcas_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles gridMarcas.CellDoubleClick
        Me.btMarcas_Click(Me.btMarca_edit, New System.EventArgs)
    End Sub

    Private Sub chkActivo_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkActivo.CheckedChanged, CheckBox1.CheckedChanged
        Me.Load_Marcas()
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
            Case Me.Tab.SelectedTab Is Me.TabPage_pedidos : Me.LoadPedidos()
        End Select
    End Sub












#Region "Pedido de Productos"
    Private Sub GridHistory_CurrentCellChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        'Me.LoadHistoryLines()
    End Sub


    'Cargo los pedidos
    Private Sub loadPedidos()
        Dim m_Table As DataTable            'Tabla de datos
        Dim rst As ADODB.Recordset
        Dim da As Data.OleDb.OleDbDataAdapter
        Dim ColStyle As DataGridViewColumn
        Dim Cell As DataGridViewCell = New DataGridViewTextBoxCell()

        Dim strWhere As String = ""

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

            'El número de pedido
            ColStyle = New DataGridViewColumn()
            ColStyle.DataPropertyName = "npedido"
            ColStyle.HeaderText = "Nº"
            ColStyle.Width = 80
            ColStyle.DefaultCellStyle = m_Style
            ColStyle.CellTemplate = Cell
            .Columns.Add(ColStyle)

            'La fecha de pedido
            ColStyle = New DataGridViewColumn()
            ColStyle.DataPropertyName = "fh_pedido"
            ColStyle.HeaderText = "Fecha"
            ColStyle.Width = 180
            ColStyle.DefaultCellStyle = m_Style
            ColStyle.CellTemplate = Cell
            .Columns.Add(ColStyle)

        End With


        'strWhere &= " AND (fh_updatePrecio>=#" & Format(Me.dtFhUpdate.Value, "MM-dd-yyyy") & " 00:00# OR isnull(fh_updatePrecio))"

        'Asignamos los datos
        rst = My.m_db.GetRst("SELECT id,npedido,fh_pedido FROM estanco_pedidos WHERE 1=1 " & strWhere & " ORDER BY fh_pedido DESC, npedido DESC")
        If IsNothing(rst) Then Exit Sub

        m_Table = New DataTable("m_tabla")
        da = New Data.OleDb.OleDbDataAdapter
        da.Fill(m_Table, rst)
        Me.gridPedidos.DataSource = m_Table


        Me.lblNPedidos.Text = rst.RecordCount

        'Permito borrar y volver a imprimir resumen
        Dim sw As Boolean = (Me.gridPedidos.RowCount > 0)
        Me.BtEdit.Enabled = sw
        Me.BtDel.Enabled = sw
        Me.btPrint.Enabled = sw

        Me.BtNew.Enabled = True

        Me.groupPedido.Enabled = False
        Me.btSave.Enabled = False
        Me.btCancell.Enabled = False

        Me.gridPedidos.Enabled = True
        Me.gridPedidos.Visible = True

        'MsgBox(Me.gridLineas.Columns.Count)

        For i As Integer = 0 To Me.gridLineas.Columns.Count - 1
            Me.gridLineas.Columns(i).ReadOnly = True
        Next


        If sw Then
            Me.gridPedidos.Rows(0).Selected = True
            gridPedidos_CurrentCellChanged(Me.gridPedidos, New System.EventArgs)
        End If


        'Asigno manejadores
        'AddHandler CType(Me.gridLineas.Columns(1), TextBox).KeyPress, AddressOf TxtValidaNumeric_KeyPress


        'AddHandler Me.TxtIVA_General.KeyPress, AddressOf gDevelop.Lite.m_OverridesEvents.TxtValidaEuro_KeyPress
    End Sub

    'Cargo las lineas de los pedidos
    Private Sub loadPedidosLines()

        Me.gridLineas.Rows.Clear()
        'MsgBox("Cargo las lineas de los pedidos")

        Dim rst As ADODB.Recordset = Nothing, i As Integer = 0
        rst = My.m_db.GetRst("SELECT * FROM estanco_pedidos_lineas WHERE id_pedido=" & Me.gridPedidos.SelectedRows(0).Cells(0).Value)
        While Not rst.EOF
            Me.gridLineas.Rows.Add()
            Me.gridLineas.Rows(i).Cells(1).Value = rst("id").Value
            Me.gridLineas.Rows(i).Cells(2).Value = rst("cod_barras").Value
            Me.gridLineas.Rows(i).Cells(3).Value = rst("id_producto").Value
            Me.gridLineas.Rows(i).Cells(4).Value = rst("codigo").Value
            Me.gridLineas.Rows(i).Cells(5).Value = rst("name").Value
            Me.gridLineas.Rows(i).Cells(6).Value = rst("ud").Value

            i += 1
            rst.MoveNext()
        End While
        My.m_db.CloseRst(rst)

    End Sub

    'Manejador de los botones de pedido
    Private Sub BtPedidos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtNew.Click, btSave.Click, btPrint.Click, BtEdit.Click, BtDel.Click, btCancell.Click
        Dim rst As ADODB.Recordset = Nothing
        Dim sw As Boolean = False


        Select Case True
            Case sender Is Me.BtNew

                'Cargo el contador
                rst = My.m_db.GetRst("SELECT estanco_pedidos FROM app_contabilidad")
                If IsDBNull(rst("estanco_pedidos").Value) Then
                    Me.txtPedido_n.Text = 1
                Else
                    Me.txtPedido_n.Text = rst("estanco_pedidos").Value + 1
                End If
                Me.txtPedido_n.Tag = Me.txtPedido_n.Text
                My.m_db.CloseRst(rst)

                Me.dtPedidoFh.Value = Now

                Me.gridLineas.Rows.Clear()

                Me.gridPedidos.Visible = False

                Me.btSave.Tag = -1
                sw = False


            Case sender Is Me.BtEdit
                Me.btSave.Tag = Me.gridPedidos.SelectedRows(0).Cells(0).Value

                sw = False


            Case sender Is Me.BtDel
                ' Borro el pedido seleccionado
                If MsgBox("¿Esta seguro de que desea de eliminar el pedido seleccionado?", MsgBoxStyle.Question + MsgBoxStyle.OkCancel) <> MsgBoxResult.Ok Then Exit Sub
                My.m_db.Execute("DELETE FROM estanco_pedidos WHERE id=" & Me.gridPedidos.SelectedRows(0).Cells(0).Value)

                Me.LoadPedidos()
                Exit Sub



            Case sender Is Me.btSave
                If Me.txtPedido_n.TextLength <= 0 Then
                    MsgBox("Debe de establecer un número de pedido válido.", MsgBoxStyle.Critical)
                    Exit Sub
                End If

                Me.SavePedido(Me.btSave.Tag)
                Me.LoadPedidos()

                sw = True
                Exit Sub

            Case sender Is Me.btCancell

                sw = True
                Me.loadPedidos()

            Case sender Is Me.btPrint
                Dim sql As String = ""
                Dim FrmAux As New frmPreviewReport
                FrmAux.StrName = "Previsualización de Pedido"
                FrmAux.StrSubName = "Previsualización de Pedido"

                'Compongo la sql
                sql &= IIf(sql.Length > 0, " AND ", "") & " {app_empresa.id}=" & My.m_app.GetValue("id_empresa")
                sql &= IIf(sql.Length > 0, " AND ", "") & " {estanco_pedidos.id}=" & Me.gridPedidos.CurrentRow.Cells(0).Value

                FrmAux.RptPrint = New crtEstanco_pedidos

                CType(FrmAux.RptPrint, crtEstanco_pedidos).DataDefinition.FormulaFields("CabName").Text = "'Pedido de Género'"
                'CType(FrmAux.RptPrint, crtEstanco_pedidos).DataDefinition.FormulaFields("SubCabName").Text = "'Pedido de género'"


                FrmAux.StrSQL = sql
                FrmAux.ShowDialog(Me)

                Exit Sub
        End Select


        'Establezco estados


        Me.gridPedidos.Enabled = sw
        Me.groupPedido.Enabled = Not sw
        Me.btSave.Enabled = Not sw
        Me.btCancell.Enabled = Not sw

        Me.BtNew.Enabled = sw
        Me.BtEdit.Enabled = sw AndAlso (Me.gridPedidos.RowCount > 0)
        Me.BtDel.Enabled = sw AndAlso (Me.gridPedidos.RowCount > 0)
        Me.btPrint.Enabled = sw AndAlso (Me.gridPedidos.RowCount > 0)


        For i As Integer = 0 To Me.gridLineas.Columns.Count - 1
            If i <> 5 AndAlso i <> 0 AndAlso i <> 1 Then Me.gridLineas.Columns(i).ReadOnly = sw
        Next


        
    End Sub


    'Funcion para guardar el pedido
    Private Sub SavePedido(Optional ByVal id As Integer = -1)
        Dim rst As ADODB.Recordset = Nothing

        'Guardo el pedido
        rst = My.m_db.GetRst("SELECT * FROM estanco_pedidos WHERE id=" & id)
        If id < 0 Then rst.AddNew()
        rst("npedido").Value = Me.txtPedido_n.Text
        rst("fh_pedido").Value = Format(Me.dtPedidoFh.Value, "dd/MM/yyyy")
        rst.Update()

        ' Actualizo el contador de pedido
        If Me.txtPedido_n.Tag = Me.txtPedido_n.Text Then My.m_db.Execute("UPDATE app_contabilidad SET estanco_pedidos=" & Me.txtPedido_n.Tag)


        'Guardo las lineas de los pedidos
        For i As Integer = 0 To Me.gridLineas.Rows.Count - 1
            If IsNumeric(Me.gridLineas.Rows(i).Cells(1).Value) Then         'id de la linea
                If IsNumeric(Me.gridLineas.Rows(i).Cells(6).Value) Then
                    If Me.gridLineas.Rows(i).Cells(6).Value <= 0 Then
                        My.m_db.Execute("DELETE FROM estanco_pedidos_lineas WHERE id=" & Me.gridLineas.Rows(i).Cells(1).Value)
                    Else
                        My.m_db.Execute("UPDATE estanco_pedidos_lineas SET " & _
                                            "id_producto=" & Me.gridLineas.Rows(i).Cells(3).Value & "," & _
                                            "name='" & Me.gridLineas.Rows(i).Cells(5).Value & "'," & _
                                            "ud=" & Me.gridLineas.Rows(i).Cells(6).Value & "," & _
                                            "cod_barras='" & Me.gridLineas.Rows(i).Cells(2).Value & "'," & _
                                            "codigo='" & Me.gridLineas.Rows(i).Cells(4).Value & "'" & _
                                        " WHERE id=" & Me.gridLineas.Rows(i).Cells(1).Value)
                    End If

                Else
                    My.m_db.Execute("DELETE FROM estanco_pedidos_lineas WHERE id=" & Me.gridLineas.Rows(i).Cells(1).Value)
                End If

            Else
                If IsNumeric(Me.gridLineas.Rows(i).Cells(6).Value) Then
                    My.m_db.Execute("INSERT INTO estanco_pedidos_lineas (id_pedido, id_producto, name, ud, cod_barras, codigo) " & _
                                    " VALUES (" & rst("id").Value & "," & Me.gridLineas.Rows(i).Cells(3).Value & ",'" & Me.gridLineas.Rows(i).Cells(5).Value & "'," & Me.gridLineas.Rows(i).Cells(6).Value & ",'" & Me.gridLineas.Rows(i).Cells(2).Value & "'" & ",'" & Me.gridLineas.Rows(i).Cells(4).Value & "')")

                End If
            End If

        Next


    End Sub

    Private Sub gridPedidos_CurrentCellChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles gridPedidos.CurrentCellChanged
        If Me.gridPedidos.SelectedRows.Count <= 0 Then Exit Sub
        Me.txtPedido_n.Text = Me.gridPedidos.SelectedRows(0).Cells(1).Value
        Me.dtPedidoFh.Text = Me.gridPedidos.SelectedRows(0).Cells(2).Value
        Me.loadPedidosLines()
    End Sub

    

    Private Sub gridPedidos_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles gridPedidos.CellDoubleClick
        MsgBox("Doble clik en pedidos")
    End Sub
#End Region

    Private Sub btPedido_Comanda_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btPedido_Comanda.Click

    End Sub

    Private Sub TxtFind_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtFind.TextChanged
        Me.Load_Marcas()
    End Sub

    Private Sub TxtFind_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtFind.KeyPress
        If e.KeyChar = Chr(Keys.Enter) Then
            e.Handled = True
            If Me.lblTotProductos.Text = 1 Then
                Me.btMarcas_Click(Me.btMarca_edit, New System.EventArgs)
            End If
        End If
    End Sub








#Region "Importación de precios"
    '### CHEQUEO DE FICHERO DE PRECIOS
    Private Sub UpdatePrecios()
        'Compruebo que es el documento que estoy esperando
        Dim objReader As New IO.StreamReader(Me.lblImporta_file.Text)
        Dim sLine As String = ""

        Dim i As Integer = 0, n As Integer = 0
        Dim swCMT As Boolean = False, swPeriodo As Boolean = False, swCodigo As Boolean = False

        Dim str As String = ""
        Dim rst As ADODB.Recordset = Nothing

        Me.lstImportaPrecios.Items.Clear()

        Do
            sLine = objReader.ReadLine()
            If Not sLine Is Nothing Then
                If Not swCMT Then
                    'Compruebo si lleva en la cabecera especificado que es libro de mayor
                    'If sLine = "Comisionado para el Mercado de Tabaco" Then swCMT = True
                    If sLine.Contains("http://www.cmtabacos.es") Then swCMT = True

                    'Si en las 5 primeras lineas no he detectado que es el mayor cancelo
                    If i >= 50 And Not swCMT Then
                        MsgBox("Fichero de actualización no reconocible de origen.", MsgBoxStyle.Critical)
                        Exit Sub
                    End If
                ElseIf Not swPeriodo Then
                    'Se ha reconocido que es de la CMT busco la fecha de actualizacion

                    str = "corresponden a las marcas actualizadas el "
                    If sLine.Contains(str) Then
                        'If InStr("PERIODO", sLine, CompareMethod.Text) > 0 Then

                        Me.lblImpora_Periodo.Text = sLine.Substring(InStr(sLine, str, CompareMethod.Text) + str.Length - 1, 10)
                        Me.lblImpora_Periodo.Refresh()
                        swPeriodo = True
                    End If
                ElseIf Not swCodigo Then
                    'Compruebo que tiene el código de marca
                    str = "<td class=""marca"">"
                    If sLine.Contains(str) Then
                        i = 0

                        'Obtengo el codigo
                        Dim sCod As String = sLine.Substring(InStr(sLine, str) + str.Length - 1).Replace("</td>", "")

                        'Compruebo si el código existe
                        rst = My.m_db.GetRst("SELECT * FROM estanco_marcas WHERE codigo='" & sCod & "'")
                        If Not rst.EOF Then

                            If rst.RecordCount > 1 Then
                                MsgBox("Encontrado mas de un producto con el mismo código: " & rst("codigo").Value, MsgBoxStyle.Critical)
                            End If

                            Dim sMarcas As String = "", dPrecio As Double = 0

                            'Obtnego nombre
                            sLine = objReader.ReadLine()

                            'Obtengo precio
                            sLine = objReader.ReadLine()
                            str = "<td class=""pvp_exp"">"
                            dPrecio = sLine.Substring(InStr(sLine, str) + str.Length - 1).Replace("</td>", "").Replace("<strong>", "").Replace("</strong>", "")

                            'Obtengo recargo
                            sLine = objReader.ReadLine()

                            'Agrego los precios que cambian
                            If rst("precio").Value <> dPrecio OrElse Me.chkTodos.Checked Then
                                Me.lstImportaPrecios.Items.Add("")
                                Me.lstImportaPrecios.Items(Me.lstImportaPrecios.Items.Count - 1).SubItems.Add(sCod)
                                Me.lstImportaPrecios.Items(Me.lstImportaPrecios.Items.Count - 1).SubItems.Add(rst("id").Value)
                                Me.lstImportaPrecios.Items(Me.lstImportaPrecios.Items.Count - 1).SubItems.Add(rst("name").Value)
                                Me.lstImportaPrecios.Items(Me.lstImportaPrecios.Items.Count - 1).SubItems.Add(rst("precio").Value)
                                Me.lstImportaPrecios.Items(Me.lstImportaPrecios.Items.Count - 1).SubItems.Add(dPrecio)

                                n += 1
                            End If


                            'Me.lstImportaPrecios.Items.Add("")
                            'Me.lstImportaPrecios.Items.Add("")
                            'Me.lstImportaPrecios.Items.Add("")


                        End If
                    ElseIf i >= 250 Then
                        'MsgBox("Código de marca no localizado.", MsgBoxStyle.Critical)
                        Exit Do
                    End If

                Else
                    str = sLine.Trim
                End If


                'Nº de linea leido
                i += 1
            End If
        Loop Until sLine Is Nothing
        objReader.Close()

        If n > 0 Then
            MsgBox("Se han detectado " & n & " cambios de precio.", MsgBoxStyle.Information)
            Me.btUpdate.Enabled = True
        Else
            MsgBox("No se ha detectado ningún cambio en los precios.", MsgBoxStyle.Information)
        End If


    End Sub

    'Selecciono documento
    Private Sub lnkImporta_Sel_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles lnkImporta_Sel.LinkClicked, lnkImporta_del.LinkClicked
        Select Case True
            Case sender Is Me.lnkImporta_Sel
                Dim dlg As New OpenFileDialog()

                dlg.Filter = "Documento HTML de precios (*.html)|preciosCMT.html|Fichero de actualización de precios (*.zip)|preciosCMT.zip"
                dlg.FilterIndex = 0
                dlg.RestoreDirectory = False

                If dlg.ShowDialog() <> Windows.Forms.DialogResult.OK Then Exit Sub

                Me.lblImporta_file.Text = dlg.FileName
                dlg.Dispose()


                Me.btImport_procesa.Enabled = True
                Me.lnkImporta_del.Enabled = True


            Case sender Is Me.lnkImporta_del
                Me.lblImpora_N.Text = ""
                Me.lblImpora_Periodo.Text = ""
                Me.lstImportaPrecios.Items.Clear()

                Me.lblImporta_file.Text = ""
                Me.lnkImporta_del.Enabled = False
                Me.btImport_procesa.Enabled = False
        End Select
    End Sub


    Private Sub btImport_procesa_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btImport_procesa.Click
        Me.UpdatePrecios()
    End Sub

    Private Sub btImporta_www_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btImporta_www.Click
        MsgBox("Aún no implementado.", MsgBoxStyle.Critical)
    End Sub



    Private Sub btUpdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btUpdate.Click
        If MsgBox("¿Esta seguro de que deséa actualizar los precios de las marcas?", MsgBoxStyle.OkCancel + MsgBoxStyle.Question) <> MsgBoxResult.Ok Then Exit Sub

        Me.pbImporta.Value = 0
        Me.pbImporta.Maximum = Me.lstImportaPrecios.Items.Count
        Me.pbImporta.Visible = True
        Me.pbImporta.Refresh()
        For i As Integer = 0 To Me.lstImportaPrecios.Items.Count - 1
            My.m_db.Execute("UPDATE estanco_marcas SET precio=" & Me.lstImportaPrecios.Items(i).SubItems(5).Text.Replace(",", ".") & " WHERE codigo='" & Me.lstImportaPrecios.Items(i).SubItems(1).Text & "'")

            Me.pbImporta.Value += 1
            Me.pbImporta.Refresh()
        Next

        Me.pbImporta.Visible = False

        MsgBox("Proceso terminado, precio actualizados correctamente.", MsgBoxStyle.Information)
        Me.Load_Marcas()
    End Sub
#End Region




#Region "Control de Códigos de Barras"
    'Variables de control para la lectura de codigos de barras
    Dim SwLectura As Boolean = False
    Dim StrLectorCodigos As String = ""

    Dim strCode As String = ""

    Private Sub fmrEstanco_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles MyBase.KeyPress

        If e.KeyChar = Chr(27) Then
            Me.Close()
            Exit Sub
        End If

        If Me.Tab.SelectedTab Is Me.TabPage_pedidos Then Exit Sub

        If My.MyLector.Sw_Lector AndAlso (e.KeyChar = My.MyLector.Str_CodLector Or (My.MyLector.Str_CodLector.Length = 0 AndAlso Not Me.SwLectura AndAlso IsNumeric(e.KeyChar))) Then
            Me.SwLectura = True

            StrLectorCodigos = IIf(IsNumeric(e.KeyChar), e.KeyChar, "")

            Me.strCode &= e.KeyChar

            e.Handled = True
            e.KeyChar = ""
            TmrCodBarras.Enabled = True
            Exit Sub
        End If

        If Me.SwLectura Then
            If My.MyLector.Str_CodLector.Length <> 0 Then e.Handled = True
            If e.KeyChar = Chr(13) AndAlso StrLectorCodigos.Length >= 6 Then
                TmrCodBarras.Enabled = False
                Me.SwLectura = False
                System.Threading.Thread.Sleep(350)
                Me.CheckCodeBar(StrLectorCodigos)
                Me.strCode = ""
                e.Handled = True
                Exit Sub
            End If
            If Not IsNumeric(e.KeyChar) Then
                TmrCodBarras.Enabled = False
                Me.SwLectura = False
                Exit Sub
            End If

            Me.strCode &= e.KeyChar


            StrLectorCodigos &= e.KeyChar
            If My.MyLector.Str_CodLector.Length <> 0 Then e.KeyChar = ""
            e.KeyChar = ""
            e.Handled = True
        Else
            'If e.KeyChar = Chr(Keys.Enter) Then
            '    Me.TxtFind.Text.Replace("$", "")
            '    If MyLector.Sw_Lector Then
            '        If IsNumeric(Me.TxtFind.Text) AndAlso Me.TxtFind.Text.Length >= 8 Then
            '            Dim swTmp As Boolean = CheckCodeBar(Me.TxtFind.Text)
            '            Me.TxtFind.Text = ""
            '            e.Handled = True
            '            If Me.Grid.RowCount > 0 AndAlso swTmp Then Me.ValidateItem(Me.BtToolShow, New System.EventArgs)
            '            Exit Sub
            '        End If
            '    End If

            '    e.Handled = True

            'End If
            'MsgBox("Entro aqui")
        End If
    End Sub

    Private Function CheckCodeBar(ByVal StrCod As String) As Boolean
        On Error Resume Next
        Dim CodBarras As String
        CheckCodeBar = False
        'Compruebo que corresponde a un cbarras 

        'Chequeo que el articulo exista
        Dim RstAux As ADODB.Recordset = My.m_db.GetRst("SELECT id FROM estanco_marcas WHERE cod_barras='" & StrCod & "'")



        If RstAux.RecordCount = 0 Then
            MsgBox("Código de barras no localizado", MsgBoxStyle.Critical)
            Exit Function
        End If

        CheckCodeBar = True

        'Muestro el formulario de lineas
        With frmEstanco_Marca
            .Id_Ref = RstAux("id").Value
            .ShowDialog(Me)
            If .DialogResult <> Windows.Forms.DialogResult.OK Then
                .Dispose()
                Exit Function
            End If
            .Dispose()
        End With

        Me.LblHour.Text = Now.ToString("HH:mm")
        Me.TmHour.Enabled = True

        Me.Load_Marcas()
        My.m_db.CloseRst(RstAux)



        ''Agrego el artículo
        'frmClientes_Precios.IdRef = 0
        'frmClientes_Precios.IdArticulo = Val(CodBarras)
        'frmClientes_Precios.ShowDialog(Me)
        'If frmClientes_Precios.DialogResult <> Windows.Forms.DialogResult.OK Then
        '    frmClientes_Precios.Dispose()
        '    Exit Function
        'End If

        ''### Duplicado en el evento del boton
        'My.Application.m_Db.Execute("INSERT INTO clientes_precios (id_cliente,id_articulo,pvp_1) VALUES(" & Me.LblId.Text & "," & CodBarras & "," & frmClientes_Precios.TxtPvp.Text.Replace(",", ".") & ")")
        'frmClientes_Precios.Dispose()

        'Me.LoadPvpPersonalizados()
    End Function

    Private Sub TmrCodBarras_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TmrCodBarras.Tick
        TmrCodBarras.Enabled = False
        Me.SwLectura = False
        Me.StrLectorCodigos = ""
    End Sub
#End Region


    Private Sub lnkCMT_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles lnkCMTPrecios.LinkClicked
        On Error Resume Next
        My.ShellExecute(Me.Handle.ToInt32, "OPEN", Me.lnkCMTPrecios.Text, Nothing, Nothing, 0)
    End Sub







    Private Sub gridLineas_CellEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles gridLineas.CellEnter
        'MsgBox("2222")
    End Sub

    Private Sub gridLineas_CellValidated(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles gridLineas.CellValidated
        'MsgBox("Validad")
    End Sub

    Private Sub gridLineas_CellValueChanged(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles gridLineas.CellValueChanged
        'MsgBox("cell add")
    End Sub

    Private Sub gridLineas_RowsAdded(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewRowsAddedEventArgs) Handles gridLineas.RowsAdded

    End Sub

    Private Sub gridLineas_UserAddedRow(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowEventArgs) Handles gridLineas.UserAddedRow
        'MsgBox("add")

        'MsgBox(sender)

        'MsgBox(e.Row)

        'If e.Row.Cells(1).Value Then

        'End If

        'For i As Integer = 0 To e.Row.Cells.Count - 1
        '    MsgBox(e.Row.Cells(i).Value)
        'Next


        'For i As Integer = 0 To e.Row.Cells.Count - 1
        '    MsgBox(gridLineas.Rows(gridLineas.Rows.Count - 2).Cells(i).Value)
        'Next

    End Sub

    Private Sub gridLineas_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles gridLineas.CellContentClick

    End Sub




    Private Sub gridLineas_EditingControlShowing(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewEditingControlShowingEventArgs) Handles gridLineas.EditingControlShowing
        If gridLineas.CurrentCell.ColumnIndex = 1 Then
            'MsgBox("Agrego manejador para id")
        End If


        'If (Me.gridLineas.CurrentCell.ColumnIndex >= 0 AndAlso Me.gridLineas.CurrentCell.ColumnIndex <= 2) And Not e.Control Is Nothing Then
        If Me.gridLineas.CurrentCell.ColumnIndex > 1 And Not e.Control Is Nothing Then
            Dim tb As TextBox = CType(e.Control, TextBox)
            'AddHandler tb.KeyDown, AddressOf TextBox_KeyDown
            'AddHandler tb.KeyPress, AddressOf TextBox_KeyPress
            'AddHandler tb.LostFocus, AddressOf TextBox_LostFocus


            RemoveHandler tb.PreviewKeyDown, AddressOf TextBox_PreviewKeyDown
            AddHandler tb.PreviewKeyDown, AddressOf TextBox_PreviewKeyDown


            'Asignar el color no sirve de nada
            tb.BackColor = Color.Black
        End If
    End Sub



    Private Sub TextBox_PreviewKeyDown(ByVal sender As Object, ByVal e As PreviewKeyDownEventArgs)
        If e.KeyCode = Keys.Enter Or e.KeyCode = Keys.Return Or e.KeyCode = Keys.Tab Or e.KeyCode = Keys.Down Or e.KeyCode = Keys.Right Or e.KeyCode = Keys.Up Or e.KeyCode = Keys.Left Then

            Dim rst As ADODB.Recordset = Nothing

            Select Case Me.gridLineas.CurrentCell.ColumnIndex
                Case 2
                    rst = My.m_db.GetRst("SELECT * FROM estanco_marcas WHERE cod_barras='" & sender.text & "'")
                    If rst.RecordCount > 0 Then
                        Me.gridLineas.CurrentRow.Cells(3).Value = rst("id").Value
                        Me.gridLineas.CurrentRow.Cells(4).Value = rst("codigo").Value
                        Me.gridLineas.CurrentRow.Cells(5).Value = rst("name").Value

                    Else
                        MsgBox("Código de barras no localizado")
                        Me.gridLineas.CurrentRow.Cells(3).Value = ""
                        Me.gridLineas.CurrentRow.Cells(4).Value = ""
                        Me.gridLineas.CurrentRow.Cells(5).Value = ""
                    End If
                    My.m_db.CloseRst(rst)

                Case 3
                    rst = My.m_db.GetRst("SELECT * FROM estanco_marcas WHERE id=" & sender.text & "")
                    If rst.RecordCount > 0 Then
                        Me.gridLineas.CurrentRow.Cells(2).Value = rst("cod_barras").Value
                        Me.gridLineas.CurrentRow.Cells(4).Value = rst("codigo").Value
                        Me.gridLineas.CurrentRow.Cells(5).Value = rst("name").Value

                    Else
                        MsgBox("Código CMT no localizado")

                        Me.gridLineas.CurrentRow.Cells(2).Value = ""
                        Me.gridLineas.CurrentRow.Cells(4).Value = ""
                        Me.gridLineas.CurrentRow.Cells(5).Value = ""
                    End If
                    My.m_db.CloseRst(rst)

                Case 4
                    rst = My.m_db.GetRst("SELECT * FROM estanco_marcas WHERE codigo='" & sender.text & "'")
                    If rst.RecordCount > 0 Then
                        Me.gridLineas.CurrentRow.Cells(2).Value = rst("cod_barras").Value
                        Me.gridLineas.CurrentRow.Cells(3).Value = rst("id").Value
                        Me.gridLineas.CurrentRow.Cells(5).Value = rst("name").Value

                    Else
                        MsgBox("ID no localizado")

                        Me.gridLineas.CurrentRow.Cells(2).Value = ""
                        Me.gridLineas.CurrentRow.Cells(3).Value = ""
                        Me.gridLineas.CurrentRow.Cells(5).Value = ""

                    End If
                    My.m_db.CloseRst(rst)



                Case 5

                Case 6
                    ' Las unidades de pedido
                    If Not IsNumeric(sender.text) Then
                        sender.text = ""
                        Me.gridLineas.CurrentRow.Cells(4).Value = ""
                    End If

            End Select

        End If
        'If e.KeyCode = Keys.Space Then

        '    MessageBox.Show("Success2")    '''''WORKS
        'End If
    End Sub
End Class