Public Class frmFacturacion
    Private swShowB As Boolean = False

#Region "Eventos Principales"
    Private Sub frmFacturacion_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.Size = Screen.PrimaryScreen.WorkingArea.Size

        'Inicializo entorno
        Me.PnlBody.Left = CType(Me.Owner, frmMain).PnlBody.Left
        Me.PnlBody.Top = CType(Me.Owner, frmMain).PnlBody.Top + (IIf(My.m_opt.swNoteBook, Me.SplitContainer.Panel1.Height, 0))
        Me.PnlBody.Visible = True

        'Cargo las cajas
        Me.Load_FacturasVentas()


        Me.Load_InfoVentas()

    End Sub
#End Region

#Region "Manejadores"
    'Manejador Principal (Shell)
    Private Sub ShellApp(ByVal command As String)
        Dim cmd As String = command.ToUpper

        Select Case cmd
            Case "DESFACTURAR_COMPRA"
                If MsgBox("¿Esta seguro que desea desfacturar la factura seleccionada?", MsgBoxStyle.Question + MsgBoxStyle.OkCancel) <> MsgBoxResult.Ok Then Exit Sub
                My.m_db.Execute("UPDATE db_albaranes_compra SET estado='ALBARAN' WHERE id_factura=" & Me.GridCompras.SelectedRows(0).Cells(0).Value)

                Me.Load_FacturasCompras()

                MsgBox("Los albaranes de la factura selecciona ya se encuentran accesibles desde el módulo de compras.", MsgBoxStyle.Information)


            Case "PRINTTICKET"
                My.PrintFactura(Me.GridVentas.CurrentRow.Cells(0).Value)

            Case "PRINTVENTA"
                Dim sql As String = ""
                Dim FrmAux As New frmPreviewReport
                FrmAux.StrName = "Generar Factura"
                FrmAux.StrSubName = "Generación de Facturas a Clientes"

                'Compongo la sql
                sql &= IIf(sql.Length > 0, " AND ", "") & " {app_empresa.id}=" & My.m_app.GetValue("id_empresa")
                sql &= IIf(sql.Length > 0, " AND ", "") & " {db_facturas.id}=" & Me.GridVentas.CurrentRow.Cells(0).Value

                FrmAux.RptPrint = New crtFactura

                FrmAux.StrSQL = sql
                FrmAux.ShowDialog(Me)


            Case "PRINTCAJA"
                'If Me.GridVentas.SelectedRows.Count <= 0 Then Exit Select
                'PrintCaja(Me.GridVentas.SelectedRows(0).Cells(0).Value)

            Case "EDITVENTA"
                Dim rst As ADODB.Recordset = My.m_db.GetRst("SELECT * FROM db_tickets WHERE id_factura=" & Me.GridVentas.SelectedRows(0).Cells(0).Value)

                'Muestro panel de ventas
                With My.Forms.frmPaneldeVentas
                    .idRef = rst("id").Value
                    .idMesa = rst("id_referencia").Value
                    .idUser = rst("id_user").Value
                    '.swCajaDirecta = Not (Me.LblHistory_Mesa.Tag = -1)

                    .swFinalizado = True

                    .ShowDialog(Me)
                    If .DialogResult <> Windows.Forms.DialogResult.OK Then
                        .Dispose()
                        Exit Sub
                    End If
                    .Dispose()
                End With

                Me.Load_FacturasVentas()
                Me.Load_InfoVentas()


            Case "DELVENTA"
                If Me.GridVentas.SelectedRows.Count <= 0 Then Exit Select
                If MsgBox("¿Esta seguro de que desea eliminar la factura seleccionada?", MsgBoxStyle.OkCancel + MsgBoxStyle.Question, My.APP_NAME) <> MsgBoxResult.Ok Then Exit Select

                My.m_db.Execute("DELETE FROM db_facturas WHERE id=" & Me.GridVentas.SelectedRows(0).Cells(0).Value)
                My.m_db.Execute("UPDATE db_tickets SET estado='FINALIZADO', id_factura=0 WHERE id_factura=" & Me.GridVentas.SelectedRows(0).Cells(0).Value)

                Me.Load_FacturasVentas()
                Me.Load_InfoVentas()

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
    Private Sub Buttons_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtMin.Click, BtClose.Click, BtDel_FacturaVenta.Click, BtPreview_FacturaVenta.Click, BtTicket.Click, BtDesfacturar.Click, btEditFactura.Click
        'Si no tiene establecido el tag mando un error
        If IsNothing(CType(sender, Button).Tag) OrElse CType(sender, Button).Tag.ToString.Length = 0 Then
            My.m_msg.MessageError(sender, "Tag de control de elemento no referenciado")
            Exit Sub
        End If

        ShellApp(CType(sender, Button).Tag.ToString)
    End Sub

    Private Sub Tab_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Tab.SelectedIndexChanged
        Select Case True
            Case Me.Tab.SelectedTab Is Me.TabPage_AlbaranesCompra : Me.Load_AlbaranesCompra()
            Case Me.Tab.SelectedTab Is Me.TabPage_FacturasCompra : Me.Load_FacturasCompras()
        End Select

    End Sub
#End Region

#Region "Funciones"
    'Funcion que me obtiene informacion sobre las cajas
    Private Sub Load_InfoVentas()
        Dim rst As ADODB.Recordset, str As String = ""

        '### Obtengo informacion sobre el nº de facturas totales
        rst = My.m_db.GetRst("SELECT COUNT(id) AS n_tot FROM db_facturas WHERE id_contable=" & My.m_app.GetValue("id_contable"))
        str = "Se han emitido un total de " & rst("n_tot").Value & " Facturas"
        My.m_db.CloseRst(rst)

        'Importe Total
        rst = My.m_db.GetRst("SELECT sum(total) as tot FROM db_facturas,db_tickets WHERE db_tickets.id=db_facturas.id_ticket AND db_facturas.id_contable=" & My.m_app.GetValue("id_contable"))
        str &= " acumulando un importe total de " & IIf(IsDBNull(rst("tot").Value), 0, rst("tot").Value) & " euros."
        My.m_db.CloseRst(rst)

        Me.LblInfoVentas.Text = str

    End Sub

    'Private Sub RefreshEstates()
    '    ''Si no hay nada, no muestro
    '    'Dim rst As ADODB.Recordset = My.m_db.GetRst("SELECT id FROM db_tickets WHERE estado<>'PENDIENTE' AND id_caja=-1")
    '    'My.m_db.CloseRst(rst)
    'End Sub

    ''Funcion de Chequeo de los estados de los botones sobre la Caja Actual
    'Private Sub CheckBtStates_CajaActual()
    '    ''Establezco estados "Default"
    '    'Me.BtDelTicket.Enabled = False
    '    'Me.BtCancell.Enabled = False
    '    'Me.BtPrintTicket.Enabled = False

    '    ''Si no hay ninguno seleccionado salgo
    '    'If Me.GridActual.SelectedRows.Count <= 0 Then Exit Sub


    '    'If Me.GridActual.SelectedRows(0).Cells.Count < 2 Then Exit Sub
    '    ''Deshabilitados cuando el ticket no esta cancelado
    '    'Dim sw As Boolean = (Me.GridActual.SelectedRows(0).Cells(2).Value <> "CANCELADO")
    '    'Me.BtCancell.Enabled = sw
    '    'Me.BtPrintTicket.Enabled = sw

    '    'Me.BtDelTicket.Enabled = True
    'End Sub
#End Region

#Region "Facturas de VENTAS"
    'Cargo Facturas Emitidas
    Private Sub Load_FacturasVentas()
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
        With Me.GridVentas
            .Columns.Clear()
            .AutoGenerateColumns = False
            .AlternatingRowsDefaultCellStyle = m_Style_alt
            .RowTemplate.Height = 31

            'El id
            ColStyle = New DataGridViewColumn()
            ColStyle.DataPropertyName = "id"
            ColStyle.HeaderText = "Referencia"
            ColStyle.Width = 65
            ColStyle.DefaultCellStyle = m_Style
            ColStyle.CellTemplate = Cell
            .Columns.Add(ColStyle)

            'La Factua
            ColStyle = New DataGridViewColumn()
            ColStyle.DataPropertyName = "n_factura"
            ColStyle.HeaderText = "Factura"
            ColStyle.Width = 110
            ColStyle.DefaultCellStyle = m_Style
            ColStyle.CellTemplate = Cell
            .Columns.Add(ColStyle)

            'Fecha de creacion
            ColStyle = New DataGridViewColumn()
            ColStyle.DataPropertyName = "fh_factura"
            ColStyle.HeaderText = "Fecha"
            ColStyle.Width = 130
            ColStyle.DefaultCellStyle = m_Style
            ColStyle.CellTemplate = Cell
            .Columns.Add(ColStyle)

            'El Nombre del Cliente
            ColStyle = New DataGridViewColumn()
            ColStyle.DataPropertyName = "name_fiscal"
            ColStyle.HeaderText = "Cliente"
            ColStyle.Width = 250
            ColStyle.DefaultCellStyle = m_Style
            ColStyle.CellTemplate = Cell
            .Columns.Add(ColStyle)

            ''El total
            ''ColStyle = New DataGridViewColumn()
            ''ColStyle.DataPropertyName = "total"
            ''ColStyle.HeaderText = "Total"
            ''ColStyle.Width = 80
            ''ColStyle.DefaultCellStyle = m_Style
            ''ColStyle.CellTemplate = Cell
            ''.Columns.Add(ColStyle)

            'If Me.swShowB Then          'El total Real
            '    ColStyle = New DataGridViewColumn()
            '    ColStyle.DataPropertyName = "total_real"
            '    ColStyle.HeaderText = "Total Real"
            '    ColStyle.Width = 100
            '    ColStyle.DefaultCellStyle = m_Style
            '    ColStyle.CellTemplate = Cell
            '    .Columns.Add(ColStyle)
            'End If
        End With

        'Asignamos los datos
        'rst = My.m_db.GetRst("SELECT id,ncaja,fh_alta,n_tickets,total" & IIf(Me.swShowB, ",total_real", "") & " FROM db_cajas WHERE id_contable=" & My.m_app.GetValue("id_contable") & "  order by ncaja desc")
        'rst = My.m_db.GetRst("SELECT db_facturas.id,db_facturas.n_factura,db_facturas.fh_factura,db_clientes.name_fiscal,db_tickets.total FROM db_facturas,db_tickets,db_clientes WHERE db_clientes.id=db_facturas.id_cliente AND db_tickets.id=db_facturas.id_ticket AND db_facturas.id_contable=" & My.m_app.GetValue("id_contable") & "  ORDER BY db_facturas.n_factura DESC")
        rst = My.m_db.GetRst("SELECT db_facturas.id,db_facturas.n_factura,db_facturas.fh_factura,db_clientes.name_fiscal FROM db_facturas,db_clientes WHERE db_clientes.id=db_facturas.id_cliente AND db_facturas.id_contable=" & My.m_app.GetValue("id_contable") & "  ORDER BY db_facturas.n_factura DESC")
        If IsNothing(rst) Then Exit Sub

        m_Table = New DataTable("m_tabla")
        da = New Data.OleDb.OleDbDataAdapter
        da.Fill(m_Table, rst)
        Me.GridVentas.DataSource = m_Table

        'Permito borrar y volver a imprimir resumen
        Me.BtDel_FacturaVenta.Enabled = (Me.GridVentas.RowCount > 0)
        Me.btEditFactura.Enabled = (Me.GridVentas.RowCount > 0)
        Me.BtPreview_FacturaVenta.Enabled = (Me.GridVentas.RowCount > 0)
        Me.BtTicket.Enabled = (Me.GridVentas.RowCount > 0)
    End Sub
#End Region

#Region "Facturas de COMPRAS"
    'Cargo las Facturas de Compra
    Private Sub Load_FacturasCompras()
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
        With Me.GridCompras
            .Columns.Clear()
            .AutoGenerateColumns = False
            .AlternatingRowsDefaultCellStyle = m_Style_alt
            .RowTemplate.Height = 31

            'El id
            ColStyle = New DataGridViewColumn()
            ColStyle.DataPropertyName = "id"
            ColStyle.HeaderText = "Ref."
            ColStyle.Width = 45
            ColStyle.DefaultCellStyle = m_Style
            ColStyle.CellTemplate = Cell
            .Columns.Add(ColStyle)

            'La Factua
            ColStyle = New DataGridViewColumn()
            ColStyle.DataPropertyName = "n_factura"
            ColStyle.HeaderText = "Factura"
            ColStyle.Width = 80
            ColStyle.DefaultCellStyle = m_Style
            ColStyle.CellTemplate = Cell
            .Columns.Add(ColStyle)

            'Fecha de creacion
            ColStyle = New DataGridViewColumn()
            ColStyle.DataPropertyName = "fh_factura"
            ColStyle.HeaderText = "Fecha"
            ColStyle.Width = 120
            ColStyle.DefaultCellStyle = m_Style
            ColStyle.CellTemplate = Cell
            .Columns.Add(ColStyle)

            'El Nombre del Cliente
            ColStyle = New DataGridViewColumn()
            ColStyle.DataPropertyName = "name_fiscal"
            ColStyle.HeaderText = "Proveedor"
            ColStyle.Width = 330
            ColStyle.DefaultCellStyle = m_Style
            ColStyle.CellTemplate = Cell
            .Columns.Add(ColStyle)

            'El total
            ColStyle = New DataGridViewColumn()
            ColStyle.DataPropertyName = "total"
            ColStyle.HeaderText = "Total"
            ColStyle.Width = 80
            ColStyle.DefaultCellStyle = m_Style
            ColStyle.CellTemplate = Cell
            .Columns.Add(ColStyle)

        End With

        'Asignamos los datos
        rst = My.m_db.GetRst("SELECT db_facturas_compra.id,db_facturas_compra.n_factura,db_facturas_compra.fh_factura,db_proveedores.name_fiscal,db_facturas_compra.total FROM db_facturas_compra,db_proveedores WHERE db_proveedores.id=db_facturas_compra.id_proveedor AND db_facturas_compra.id_contable=" & My.m_app.GetValue("id_contable") & "  ORDER BY db_facturas_compra.fh_factura DESC")
        If IsNothing(rst) Then Exit Sub

        m_Table = New DataTable("m_tabla")
        da = New Data.OleDb.OleDbDataAdapter
        da.Fill(m_Table, rst)
        Me.GridCompras.DataSource = m_Table

        Me.BtDesfacturar.Enabled = (Me.GridCompras.RowCount > 0)
    End Sub
#End Region

#Region "Albaranes de Compras"
    'Cargo los albaranes
    Private Sub Load_AlbaranesCompra()
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
        With Me.GridAlbaranes
            .Columns.Clear()
            .AutoGenerateColumns = False
            .AlternatingRowsDefaultCellStyle = m_Style_alt
            .RowTemplate.Height = 31

            'El id
            ColStyle = New DataGridViewColumn()
            ColStyle.DataPropertyName = "id"
            ColStyle.HeaderText = "Ref."
            ColStyle.Width = 60
            ColStyle.DefaultCellStyle = m_Style
            ColStyle.CellTemplate = Cell
            .Columns.Add(ColStyle)

            'El estado
            ColStyle = New DataGridViewColumn()
            ColStyle.DataPropertyName = "estado"
            ColStyle.HeaderText = "Estado"
            ColStyle.Width = 100
            ColStyle.DefaultCellStyle = m_Style
            ColStyle.CellTemplate = Cell
            .Columns.Add(ColStyle)

            'EL albaran
            ColStyle = New DataGridViewColumn()
            ColStyle.DataPropertyName = "n_albaran"
            ColStyle.HeaderText = "Albaran"
            ColStyle.Width = 80
            ColStyle.DefaultCellStyle = m_Style
            ColStyle.CellTemplate = Cell
            .Columns.Add(ColStyle)

            'Fecha de creacion
            ColStyle = New DataGridViewColumn()
            ColStyle.DataPropertyName = "fh_albaran"
            ColStyle.HeaderText = "Fecha"
            ColStyle.Width = 110
            ColStyle.DefaultCellStyle = m_Style
            ColStyle.CellTemplate = Cell
            .Columns.Add(ColStyle)

            'El Nombre del Cliente
            ColStyle = New DataGridViewColumn()
            ColStyle.DataPropertyName = "name_fiscal"
            ColStyle.HeaderText = "Proveedor"
            ColStyle.Width = 235
            ColStyle.DefaultCellStyle = m_Style
            ColStyle.CellTemplate = Cell
            .Columns.Add(ColStyle)

            'El total
            ColStyle = New DataGridViewColumn()
            ColStyle.DataPropertyName = "total"
            ColStyle.HeaderText = "Total"
            ColStyle.Width = 80
            ColStyle.DefaultCellStyle = m_Style
            ColStyle.CellTemplate = Cell
            .Columns.Add(ColStyle)

        End With

        'Asignamos los datos
        rst = My.m_db.GetRst("SELECT db_albaranes_compra.id,db_albaranes_compra.estado,db_albaranes_compra.n_albaran,db_albaranes_compra.fh_albaran,db_proveedores.name_fiscal,db_albaranes_compra.total FROM db_albaranes_compra,db_proveedores WHERE db_proveedores.id=db_albaranes_compra.id_proveedor AND db_albaranes_compra.id_contable=" & My.m_app.GetValue("id_contable") & " AND db_albaranes_compra.estado='ALBARAN' ORDER BY db_albaranes_compra.fh_albaran DESC")
        If IsNothing(rst) Then Exit Sub

        m_Table = New DataTable("m_tabla")
        da = New Data.OleDb.OleDbDataAdapter
        da.Fill(m_Table, rst)
        Me.GridAlbaranes.DataSource = m_Table

        'Permito editar y borrar albaranes
        Me.BtEdit.Enabled = (Me.GridAlbaranes.RowCount > 0)
        Me.BtDel.Enabled = (Me.GridAlbaranes.RowCount > 0)
    End Sub


#Region "Manejador de Lineas"
    Private Sub ShellApp_AlbaranesCompra(ByVal command As String)
        Dim cmd As String = command.ToUpper

        Select Case cmd
            'Case "PRINTVENTA"
            '    Dim sql As String = ""
            '    Dim FrmAux As New frmPreviewReport
            '    FrmAux.StrName = "Generar Factura"
            '    FrmAux.StrSubName = "Generación de Facturas a Clientes"

            '    'Compongo la sql
            '    sql &= IIf(sql.Length > 0, " AND ", "") & " {app_empresa.id}=" & My.m_app.GetValue("id_empresa")
            '    sql &= IIf(sql.Length > 0, " AND ", "") & " {db_facturas.id}=" & Me.GridAlbaranes.CurrentRow.Cells(0).Value

            '    FrmAux.RptPrint = New crtFactura

            '    FrmAux.StrSQL = sql
            '    FrmAux.ShowDialog(Me)


            'Case "PRINTCAJA"
            '    'If Me.GridVentas.SelectedRows.Count <= 0 Then Exit Select
            '    'PrintCaja(Me.GridVentas.SelectedRows(0).Cells(0).Value)

            Case "DEL"
                If Me.GridAlbaranes.SelectedRows.Count <= 0 Then Exit Select
                If MsgBox("¿Esta seguro de que desea eliminar el albarán seleccionado?", MsgBoxStyle.OkCancel + MsgBoxStyle.Question, My.APP_NAME) <> MsgBoxResult.Ok Then Exit Select

                'Actualizo el stock
                Dim rst As ADODB.Recordset = My.m_db.GetRst("SELECT db_lin_compras.ud,db_articulos.id,db_articulos.ud_pedido FROM db_articulos,db_lin_compras WHERE db_articulos.id=db_lin_compras.id_articulo AND id_albaran=" & Me.GridAlbaranes.SelectedRows(0).Cells(0).Value)
                Dim rstTmp As ADODB.Recordset = Nothing
                While Not rst.EOF
                    My.m_db.Execute("UPDATE db_articulos SET ud=ud-" & Replace(rst("ud").Value * rst("ud_pedido").Value, ",", ".") & " WHERE estocable=true and id=" & rst("id").Value)
                    rst.MoveNext()
                End While
                My.m_db.CloseRst(rst)


                'Elimino el albaran
                My.m_db.Execute("DELETE FROM db_albaranes_compra WHERE id=" & Me.GridAlbaranes.SelectedRows(0).Cells(0).Value)

                'Cargo los albaranes
                Me.Load_AlbaranesCompra()

            Case "EDIT"
                'Cargo el formulario de gestion de ALBARAN
                frmCompras_Albaran.IdProv = 0
                frmCompras_Albaran.IdRef = Me.GridAlbaranes.SelectedRows(0).Cells(0).Value
                frmCompras_Albaran.ShowDialog(Me)
                If frmCompras_Albaran.DialogResult <> Windows.Forms.DialogResult.OK Then
                    frmCompras_Albaran.Dispose()
                    Exit Sub
                End If
                frmCompras_Albaran.Dispose()

                'reCargo los albaranes
                Me.Load_AlbaranesCompra()

            Case "ADD"
                Dim idProv As Integer = 0
                'Primero selecciono el proveedor
                frmCompras_SelectProv.IdRef = 0
                frmCompras_SelectProv.ConfigureApp("proveedores")
                frmCompras_SelectProv.ShowDialog(Me)
                If frmCompras_SelectProv.DialogResult <> Windows.Forms.DialogResult.OK Then
                    frmCompras_SelectProv.Dispose()
                    Exit Sub
                End If
                idProv = frmCompras_SelectProv.IdRef
                frmCompras_SelectProv.Dispose()

                'Cargo el formulario de gestion de ALBARAN
                frmCompras_Albaran.IdProv = idProv
                frmCompras_Albaran.IdRef = 0
                frmCompras_Albaran.ShowDialog(Me)
                If frmCompras_Albaran.DialogResult <> Windows.Forms.DialogResult.OK Then
                    frmCompras_Albaran.Dispose()
                    Exit Sub
                End If
                frmCompras_Albaran.Dispose()

                'Cargo los albaranes
                Me.Load_AlbaranesCompra()

            Case Else
                My.m_msg.MessageError(Me, "Comando de acción de " & cmd & " no controlada. <ALBARAN_COMPRA>")
        End Select
    End Sub

    Private Sub ButtonsAlbaranes_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtDel.Click, BtAdd.Click, BtEdit.Click
        'Si no tiene establecido el tag mando un error
        If IsNothing(CType(sender, Button).Tag) OrElse CType(sender, Button).Tag.ToString.Length = 0 Then
            My.m_msg.MessageError(sender, "Tag de control de elemento no referenciado <ALBARAN_COMPRA>")
            Exit Sub
        End If

        ShellApp_AlbaranesCompra(CType(sender, Button).Tag.ToString)
    End Sub
#End Region
#End Region
    
End Class