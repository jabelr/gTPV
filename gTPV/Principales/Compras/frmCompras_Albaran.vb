Public Class frmCompras_Albaran
    Private WithEvents m_data As gDevelop.Lite.m_dataform

    'Private _app As String = ""             'El modulo que cargamos por defecto
    'Private _id As Integer = 0

    'Private _n As Integer = 0
    'Private _m As Integer = 0
    'Public Event Shell_App(ByVal app_form As String)         'Para controlar las acciones de los botones desde el formulario padre

    Public IdProv As Integer = 0
    Public IdRef As Integer = 0


#Region "Declaraciones"
    'Enumeracion para las columnas de la lista
    Private Enum lst_Columns
        id = 0
        id_articulo = 1
        name = 2
        pvp_ud = 3
        ud = 4
        iva = 5
        dto = 6
        total = 7
        ud_orig = 8
    End Enum

    'Articulos eliminados
    Private ArrayDelField(0) As Integer
    Private ArrayDelField_IdArt(0) As Integer
    Private ArrayDelField_Ud(0) As Double
#End Region

#Region "Manejadores"
    'Manejador Principal (Shell)
    Private Sub ShellApp(ByVal app_form As String, Optional ByVal action As String = "")
        Dim app As String = app_form.ToUpper

        'Antes de iniciar cualquier opcion compruebo si la demo es valida (fix change fh)

        Select Case app
            Case "FACTURAR"
                frmFacturar_Compras.IdRef = Me.IdRef
                frmFacturar_Compras.Id_Prov = Me.TxtId_Proveedor.Text
                frmFacturar_Compras.Id_Factura = Me.TxtId_Factura.Text
                frmFacturar_Compras.TipoFacturacion = Me.CbTipo.Text
                frmFacturar_Compras.ShowDialog(Me)

                If frmFacturar_Compras.DialogResult <> Windows.Forms.DialogResult.OK Then
                    frmFacturar_Compras.Dispose()
                    Exit Sub
                End If
                frmFacturar_Compras.Dispose()
                Me.DialogResult = Windows.Forms.DialogResult.OK

            Case "EDIT"
                Me.BtEdit.Enabled = False
                Me.BtCancell.Enabled = True
                Me.BtOk.Enabled = True

                Me.BtFacturar.Enabled = False

                Me.m_data.data_EditField(Me.IdRef)

            Case "OK"
                Me.CalcularTotales()

                If Me.IdRef < 1 Then
                    Me.IdRef = Me.m_data.data_SaveField()
                    Me.SaveLines()

                    Me.DialogResult = Windows.Forms.DialogResult.OK
                Else
                    Me.IdRef = Me.m_data.data_SaveField()
                    Me.SaveLines()

                    Me.BtEdit.Enabled = True
                    Me.BtCancell.Enabled = False
                    Me.BtOk.Enabled = False

                    Me.m_data.data_LoadField(Me.IdRef)

                    Me.BtFacturar.Enabled = True
                End If

            Case "CANCELL"
                'Si es nuevo cancelo el formulario
                If Me.IdRef < 1 Then
                    Me.DialogResult = Windows.Forms.DialogResult.Cancel
                Else
                    Me.BtEdit.Enabled = True
                    Me.BtCancell.Enabled = False
                    Me.BtOk.Enabled = False

                    Me.BtFacturar.Enabled = True

                    Me.m_data.data_LoadField(Me.IdRef)
                End If

            Case "MINIMIZE"
                frm_AppIsMinimized.Show()

                Me.Owner.WindowState = FormWindowState.Minimized
                Me.WindowState = FormWindowState.Minimized

            Case "CLOSE"
                Me.Close()
            Case Else
                MsgBox("Acción no controlada.")
                'RaiseEvent Shell_App(app)
        End Select

        Me.LstLines.Select()
    End Sub

#End Region

#Region "Eventos Principales"
    Private Sub m_Shell_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        If (Not IsNothing(m_KeyBoard)) Then m_KeyBoard.Close()
        Me.m_data.Dispose()
    End Sub

    Private Sub m_Shell_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'Configuro el formulario
        Me.Size = Screen.PrimaryScreen.WorkingArea.Size

        'Centro el body
        Me.PnlBody.Left = (Me.Width - Me.PnlBody.Width) / 2
        Me.PnlBody.Top = (Me.SplitContainer.Panel2.Height - Me.PnlBody.Height) / 2
        Me.PnlBody.Visible = True

        'Configuro el m_data
        Me.m_data = New gDevelop.Lite.m_dataform(My.m_db)
        Me.m_data.GetConfiguration("albaranes_compra")
        Me.m_data.ConfigureDataForm(Me.Controls)

        'Asigno eventos de control de la clase m_dataform
        'AddHandler Me.m_data.OnNewField, AddressOf Me.OnNewField
        'AddHandler Me.m_data.OnLoadField, AddressOf Me.OnLoadField
        'AddHandler Me.m_data.OnSaveField, AddressOf Me.OnSaveField

        'Proceso la accion en concreto
        If Me.IdRef > 0 Then
            Me.m_data.data_LoadField(Me.IdRef)
            Me.BtEdit.Enabled = True
            Me.BtCancell.Enabled = False
            Me.BtOk.Enabled = False

            Me.BtFacturar.Enabled = True
        Else
            Me.m_data.data_NewField()

            Me.TxtId_Contable.Text = My.m_app.GetValue("id_contable")
            Me.TxtId_Proveedor.Text = Me.IdProv
            Me.TxtEstado.Text = "ALBARAN"

            Me.BtEdit.Enabled = False
            Me.BtCancell.Enabled = True
            Me.BtOk.Enabled = True

            Me.BtFacturar.Enabled = False
            Me.CbTipo.SelectedIndex = 0
        End If

        'Cargo los datos del proveedor
        Dim rst As ADODB.Recordset = My.m_db.GetRst("SELECT name_fiscal FROM db_proveedores WHERE id=" & Me.TxtId_Proveedor.Text)
        Me.LblProv_name.Text = rst("name_fiscal").Value
        My.m_db.CloseRst(rst)

        Me.LoadLines()
        Me.CalcularTotales()
    End Sub
#End Region

#Region "Eventos Delegados"
    'Para controlar el caso del nuevo
    Public Sub OnNewField()
        Me.LblFh_Alta.Visible = False
        Me.LblFh_Alta_nfo.Visible = False

        Me.CbTipo.SelectedIndex = 0
    End Sub
    'Cada vez que cargo un registro
    Public Sub OnLoadField(ByVal id As Integer)
        Me.TxtId_Contable.Select()
        Me.Tab.SelectedIndex = 0

        'Me.LblSubTitle.Text = "Visualizando el registro de """ & Me.TxtName_Comercial.Text & """"                 ' Submensaje"

        'Establezco estados
        Me.LblFh_Alta.Visible = True
        Me.LblFh_Alta_nfo.Visible = True
    End Sub

    'Comprobaciones antes de guardar
    Public Sub OnSaveField(ByRef cancell As Boolean)
        'If Me.TxtName_Comercial.TextLength <= 0 Then
        '    My.m_msg.MessageError(Me.Owner, "Debe de establecer el nombre del cliente para poder guardar.")
        '    Me.TxtName_Comercial.SelectAll()
        '    cancell = True
        '    Exit Sub
        'End If
        'cancell = True
    End Sub


    'Delegacion para el control de teclas
    Private Sub form_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        Select Case e.KeyCode
            Case Keys.Escape
                If Not m_KeyBoard Is Nothing Then
                    m_KeyBoard.Dispose()
                    Exit Select
                End If
                Me.Dispose()
        End Select
    End Sub
#End Region

#Region "Eventos Auxiliares"
    Private Sub Buttons_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtClose.Click, BtEdita.Click, BtDel.Click, BtPrevious.Click, BtNext.Click, BtLast.Click, BtFirst.Click, BtOk.Click, BtNew.Click, BtCancell.Click, BtEdit.Click, BtFacturar.Click
        'Si no tiene establecido el tag mando un error
        If IsNothing(CType(sender, Button).Tag) OrElse CType(sender, Button).Tag.ToString.Length = 0 Then
            My.m_msg.MessageError(sender, "Tag de control de elemento no referenciado")
            Exit Sub
        End If

        ShellApp(CType(sender, Button).Tag.ToString)
    End Sub

    Private Sub m_Shell_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        Me.Left = 0
        Me.Top = 0

        Me.PnlData.Visible = True
    End Sub

    Private Sub LstLines_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles LstLines.DoubleClick
        If Me.BtOk.Enabled Then Me.Action_Lines(Me.BtLines_Edit, e)
    End Sub

    Private Sub LstLines_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LstLines.SelectedIndexChanged
        Dim sw As Boolean = (Me.LstLines.SelectedItems.Count > 0)
        Me.BtLines_Edit.Enabled = sw
        Me.BtLines_Del.Enabled = sw
    End Sub

    Private Sub CbTipo_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CbTipo.SelectedIndexChanged
        Me.CalcularTotales()
    End Sub
#End Region

#Region "Calculos"
    Private Sub CalcularTotales()
        Dim i As Integer = 0, DblBase_General As Double = 0, DblBase_Medio As Double = 0, DblBase_Basico As Double = 0
        For i = 0 To Me.LstLines.Items.Count - 1
            Select Case Me.LstLines.Items(i).SubItems(lst_Columns.iva).Text
                Case My.m_opt.IVA_General               'General
                    DblBase_General += CDbl(Me.LstLines.Items(i).SubItems(lst_Columns.total).Text)

                Case My.m_opt.IVA_Medio               'Medio
                    DblBase_Medio += CDbl(Me.LstLines.Items(i).SubItems(lst_Columns.total).Text)

                Case My.m_opt.IVA_Basico               'Basico
                    DblBase_Basico += CDbl(Me.LstLines.Items(i).SubItems(lst_Columns.total).Text)
            End Select
        Next

        '<!-- Aplico totales del tipo de iva GENERAL -->
        Me.TxtPvp_Base_General.Text = Format(DblBase_General, "0.00")
        Me.LblPvp_Base_General.Text = Me.TxtPvp_Base_General.Text

        Me.TxtPvp_Iva_General.Text = Format(GetMyIVAPvp(DblBase_General, 0), "0.00")
        Me.LblPvp_Iva_General.Text = Me.TxtPvp_Iva_General.Text

        Me.lblRecargo_general.Text = Format(GetMyRecargoPvp(DblBase_General, 0), "0.00")

        Me.TxtPvp_Total_General.Text = Format(DblBase_General + Me.TxtPvp_Iva_General.Text + Me.lblRecargo_general.Text, "0.00")
        Me.LblPvp_Total_General.Text = Me.TxtPvp_Total_General.Text

        '<!-- Aplico totales del tipo de iva MEDIO -->
        Me.TxtPvp_Base_Medio.Text = Format(DblBase_Medio, "0.00")
        Me.LblPvp_Base_Medio.Text = Me.TxtPvp_Base_Medio.Text

        Me.TxtPvp_Iva_Medio.Text = Format(GetMyIVAPvp(DblBase_Medio, 1), "0.00")
        Me.LblPvp_Iva_Medio.Text = Me.TxtPvp_Iva_Medio.Text

        Me.lblRecargo_medio.Text = Format(GetMyRecargoPvp(DblBase_Medio, 1), "0.00")

        Me.TxtPvp_Total_Medio.Text = Format(DblBase_Medio + Me.TxtPvp_Iva_Medio.Text + Me.lblRecargo_medio.Text, "0.00")
        Me.LblPvp_Total_Medio.Text = Me.TxtPvp_Total_Medio.Text


        '<!-- Aplico totales del tipo de iva BASICO -->
        Me.TxtPvp_Base_Basico.Text = Format(DblBase_Basico, "0.00")
        Me.LblPvp_Base_Basico.Text = Me.TxtPvp_Base_Basico.Text

        Me.TxtPvp_Iva_Basico.Text = Format(GetMyIVAPvp(DblBase_Basico, 2), "0.00")
        Me.LblPvp_Iva_Basico.Text = Me.TxtPvp_Iva_Basico.Text

        Me.lblRecargo_basico.Text = Format(GetMyRecargoPvp(DblBase_Basico, 2), "0.00")

        Me.TxtPvp_Total_Basico.Text = Format(DblBase_Basico + Me.TxtPvp_Iva_Basico.Text + Me.lblRecargo_basico.Text, "0.00")
        Me.LblPvp_Total_Basico.Text = Me.TxtPvp_Total_Basico.Text


        '#El total general
        Me.TxtPvp_Total.Text = Format(CDbl(Me.LblPvp_Total_General.Text) + CDbl(Me.LblPvp_Total_Medio.Text) + CDbl(Me.LblPvp_Total_Basico.Text), "0.00")
        Me.LblPvp_Total.Text = Me.TxtPvp_Total.Text
    End Sub

    'Función para calcular el descuento
    Private Function CalculaDto(ByVal importe As Double, ByVal dto As Double) As Double
        Dim dbl As Double = (importe * dto) / 100
        Return Format(importe - dbl, "0.00#")
    End Function

    Public Function GetMyIVAPvp(ByVal DblPvp As Double, Optional ByVal intTipoIVA As Integer = 0) As Double
        'Si es tipo B
        If Me.CbTipo.SelectedIndex > 0 Then Return 0

        'Dependiendo del tipo de IVA
        Dim dbl As Double = 0
        Select Case intTipoIVA
            Case 0 : dbl = My.m_opt.IVA_General
            Case 1 : dbl = My.m_opt.IVA_Medio
            Case 2 : dbl = My.m_opt.IVA_Basico
        End Select

        Dim str As String = dbl
        str = "0," & IIf(dbl < 10, "0", "") & str.Replace(",", "")
        dbl = CDbl(str)
        Return Format(DblPvp * dbl, "0.00")
    End Function

    Public Function GetMyRecargoPvp(ByVal DblPvp As Double, Optional ByVal intTipoIVA As Integer = 0) As Double
        'Si es tipo B
        If Me.CbTipo.SelectedIndex > 0 Then Return 0

        'Dependiendo del tipo de IVA
        Dim dbl As Double = 0
        Select Case intTipoIVA
            Case 0 : dbl = My.m_opt.IVA_Recargo_General
            Case 1 : dbl = My.m_opt.IVA_Recargo_Medio
            Case 2 : dbl = My.m_opt.IVA_Recargo_Basico
        End Select

        Dim str As String = dbl
        str = "0," & IIf(dbl < 10, "0", "") & str.Replace(",", "")
        dbl = CDbl(str)
        Return Format(DblPvp * dbl, "0.00")
    End Function
#End Region

#Region "Lineas"
    Private Sub LoadLines()
        '# PreConfiguro el ListView
        Me.LstLines.Items.Clear()
        Me.LstLines.Columns.Clear()

        Me.LstLines.Columns.Add("Ref.", 0, HorizontalAlignment.Right)
        Me.LstLines.Columns.Add("Ref. Art.", 0, HorizontalAlignment.Right)      'id_articulo
        Me.LstLines.Columns.Add("Artículo", 325, HorizontalAlignment.Left)
        Me.LstLines.Columns.Add("Pvp/Ud", 70, HorizontalAlignment.Right)
        Me.LstLines.Columns.Add("Ud.", 50, HorizontalAlignment.Center)
        Me.LstLines.Columns.Add("IVA", 40, HorizontalAlignment.Center)
        Me.LstLines.Columns.Add("% Dto", 55, HorizontalAlignment.Right)
        Me.LstLines.Columns.Add("Total", 80, HorizontalAlignment.Right)
        Me.LstLines.Columns.Add("Ud.Orig", 0, HorizontalAlignment.Right)


        '# Precargo los registros guardados
        Dim RstAux As ADODB.Recordset = My.m_db.GetRst("SELECT * FROM db_lin_compras WHERE id_albaran=" & Me.IdRef & " ORDER BY id ASC")
        Dim i As Integer = 0
        While Not RstAux.EOF
            Me.LstLines.Items.Add(RstAux("id").Value)
            Me.LstLines.Items(i).SubItems.Add(RstAux("id_articulo").Value)
            Me.LstLines.Items(i).SubItems.Add(RstAux("name").Value)
            Me.LstLines.Items(i).SubItems.Add(Format(RstAux("pvp_ud").Value, "0.00#"))
            Me.LstLines.Items(i).SubItems.Add(Format(RstAux("ud").Value, "0.00"))
            Me.LstLines.Items(i).SubItems.Add(Format(RstAux("iva").Value, "0.##"))
            Me.LstLines.Items(i).SubItems.Add(Format(RstAux("dto").Value, "0.00#"))
            Me.LstLines.Items(i).SubItems.Add(Format(CalculaDto(RstAux("ud").Value * RstAux("pvp_ud").Value, RstAux("dto").Value), "0.00#"))
            Me.LstLines.Items(i).SubItems.Add(Format(RstAux("ud").Value, "0.00#"))
            i += 1
            RstAux.MoveNext()
        End While
        My.m_db.CloseRst(RstAux)
    End Sub

    'Movimiento de lineas
    Private Sub Action_Lines(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtLines_Edit.Click, BtLines_Del.Click, BtLines_Add.Click, BtLines_AddFree.Click
        Select Case True
            Case sender Is Me.BtLines_Add           'AGREGAR LINEA
                'Dim idAux As Integer = Exporta("articulos")
                frmCompras_SelectArt.ShowDialog(Me)
                If frmCompras_SelectArt.DialogResult <> Windows.Forms.DialogResult.OK Then
                    frmCompras_SelectArt.Dispose()
                    Exit Sub
                End If
                Dim idAux As Integer = frmCompras_SelectArt.Id_Ref
                frmCompras_SelectArt.Dispose()

                If idAux = -1 Then Exit Sub
                AddLine(idAux)

            Case sender Is Me.BtLines_AddFree
                AddLine(-1)

            Case sender Is Me.BtLines_Edit          'MODIFICAR LINEA
                If Me.LstLines.SelectedItems.Count = 0 Then Exit Sub

                frmCompras_lines.IdRef = Me.LstLines.SelectedItems(0).SubItems(lst_Columns.id_articulo).Text
                frmCompras_lines.m_Iva = Me.LstLines.SelectedItems(0).SubItems(lst_Columns.iva).Text

                frmCompras_lines.TxtDto.Text = Me.LstLines.SelectedItems(0).SubItems(lst_Columns.dto).Text

                frmCompras_lines.TxtName.Text = Me.LstLines.SelectedItems(0).SubItems(lst_Columns.name).Text.Trim
                frmCompras_lines.TxtTotal.Text = Me.LstLines.SelectedItems(0).SubItems(lst_Columns.pvp_ud).Text
                frmCompras_lines.TxtTotal.Tag = Me.LstLines.SelectedItems(0).SubItems(lst_Columns.pvp_ud).Text
                frmCompras_lines.TxtUD.Text = Me.LstLines.SelectedItems(0).SubItems(lst_Columns.ud).Text

                frmCompras_lines.CbIVA.Enabled = False

                frmCompras_lines.ShowDialog(Me)
                If frmCompras_lines.DialogResult = Windows.Forms.DialogResult.Cancel Then
                    frmCompras_lines.Dispose()
                    Exit Sub
                End If

                If Not IsNumeric(frmCompras_lines.TxtTotal.Text) Then frmCompras_lines.TxtTotal.Text = 0
                If Not IsNumeric(frmCompras_lines.TxtUD.Text) Then frmCompras_lines.TxtUD.Text = 1
                If Not IsNumeric(frmCompras_lines.TxtDto.Text) Then frmCompras_lines.TxtDto.Text = 0

                Me.LstLines.SelectedItems(0).SubItems(lst_Columns.name).Text = frmCompras_lines.TxtName.Text.Replace("'", "")
                Me.LstLines.SelectedItems(0).SubItems(lst_Columns.pvp_ud).Text = Format(CDbl(frmCompras_lines.TxtTotal.Text), "0.00#")
                Me.LstLines.SelectedItems(0).SubItems(lst_Columns.ud).Text = Format(CDbl(frmCompras_lines.TxtUD.Text), "0.00")
                Me.LstLines.SelectedItems(0).SubItems(lst_Columns.dto).Text = Format(CDbl(frmCompras_lines.TxtDto.Text), "0.00#")
                Me.LstLines.SelectedItems(0).SubItems(lst_Columns.total).Text = Format(CalculaDto(CDbl(frmCompras_lines.TxtUD.Text) * CDbl(frmCompras_lines.TxtTotal.Text), CDbl(frmCompras_lines.TxtDto.Text)), "0.00#")


                Me.LstLines.SelectedItems(0).Checked = True
                frmCompras_lines.Dispose()

            Case sender Is Me.BtLines_Del           'ELIMINAR LINEA
                If Me.LstLines.SelectedItems.Count = 0 Then Exit Sub

                Dim Id_pos As Integer = Me.LstLines.SelectedItems(0).Index

                If (Me.LstLines.SelectedItems(0).SubItems(1).Text <> 0) Then
                    ReDim Preserve ArrayDelField(UBound(ArrayDelField) + 1)
                    ReDim Preserve ArrayDelField_IdArt(UBound(ArrayDelField_IdArt) + 1)
                    ReDim Preserve ArrayDelField_Ud(UBound(ArrayDelField_Ud) + 1)
                    ArrayDelField(UBound(ArrayDelField)) = Me.LstLines.SelectedItems(0).SubItems(lst_Columns.id).Text
                    ArrayDelField_IdArt(UBound(ArrayDelField_IdArt)) = Me.LstLines.SelectedItems(0).SubItems(lst_Columns.id_articulo).Text
                    ArrayDelField_Ud(UBound(ArrayDelField_Ud)) = Me.LstLines.SelectedItems(0).SubItems(lst_Columns.ud_orig).Text
                End If

                Me.LstLines.SelectedItems(0).Checked = False
                Me.LstLines.SelectedItems(0).Remove()

                Me.LstLines.SelectedItems.Clear()

                Dim i As Integer
                For i = Id_pos To Me.LstLines.Items.Count - 1
                    Me.LstLines.Items(i).Text = Format(i + 1, "000")
                    Me.LstLines.Items(i).Checked = True
                Next

                If Id_pos = Me.LstLines.Items.Count Then Id_pos -= 1
                If Me.LstLines.Items.Count Then Me.LstLines.Items(Id_pos).Selected = True

            Case Else
                Exit Sub
        End Select

        'Cuando modifico algo, recalculo el total
        Me.CalcularTotales()
        Me.LstLines.Select()
    End Sub

    Private Sub AddLine(ByVal idAux As Integer)
        'Chequeo que el articulo exista
        Dim rst As ADODB.Recordset = Nothing, RstAux As ADODB.Recordset = My.m_db.GetRst("SELECT id,name,pvp_costo,iva FROM db_articulos WHERE id=" & idAux)
        If RstAux.RecordCount = 0 AndAlso idAux > 0 Then
            MsgBox("Código artículo no localizado", MsgBoxStyle.Critical)
            Exit Sub
        End If

        If idAux > 0 Then
            '# Agrego un artículo del almacen
            frmCompras_lines.IdRef = idAux
            frmCompras_lines.m_Iva = RstAux("iva").Value
            frmCompras_lines.TxtName.Text = Replace(RstAux("name").Value, "'", "")
            frmCompras_lines.TxtUD.Text = 1
            frmCompras_lines.TxtDto.Text = Format(0, "0.00#")

            'Obtengo el ultimo precio al que se compro el articulo
            rst = My.m_db.GetRst("SELECT pvp_ud FROM db_lin_compras,db_albaranes_compra WHERE db_lin_compras.id_albaran=db_albaranes_compra.id AND id_articulo=" & idAux & " AND db_lin_compras.pvp_ud>0 ORDER BY db_albaranes_compra.fh_albaran DESC")
            If rst.RecordCount > 0 Then
                frmCompras_lines.TxtTotal.Text = Format(rst("pvp_ud").Value, "0.00#")
                frmCompras_lines.TxtTotal.Tag = Format(rst("pvp_ud").Value, "0.00#")
            Else
                frmCompras_lines.TxtTotal.Text = Format(0, "0.00#")
                frmCompras_lines.TxtTotal.Tag = Format(0, "0.00#")
            End If
            My.m_db.CloseRst(rst)
        Else
            '# Agrego un artículo libre
            frmCompras_lines.IdRef = idAux
            frmCompras_lines.m_Iva = My.m_opt.IVA_General
            frmCompras_lines.TxtName.Text = ""
            frmCompras_lines.TxtUD.Text = 1
            frmCompras_lines.TxtDto.Text = Format(0, "0.00#")

            
            frmCompras_lines.TxtTotal.Text = Format(0, "0.00#")
            frmCompras_lines.TxtTotal.Tag = Format(0, "0.00#")
        End If

        frmCompras_lines.ShowDialog(Me)
        If frmCompras_lines.DialogResult = Windows.Forms.DialogResult.Cancel Then
            frmCompras_lines.Dispose()
            Exit Sub
        End If

        'Verifico valores
        Dim i As Integer = Me.LstLines.Items.Count
        If Not IsNumeric(frmCompras_lines.TxtTotal.Text) Then frmCompras_lines.TxtTotal.Text = 0
        If Not IsNumeric(frmCompras_lines.TxtUD.Text) Then frmCompras_lines.TxtUD.Text = 1
        If Not IsNumeric(frmCompras_lines.TxtDto.Text) Then frmCompras_lines.TxtDto.Text = 0

        'Agrego la linea
        Me.LstLines.Items.Add(0)
        Me.LstLines.Items(i).SubItems.Add(idAux)
        Me.LstLines.Items(i).SubItems.Add(frmCompras_lines.TxtName.Text.Replace("'", ""))
        Me.LstLines.Items(i).SubItems.Add(Format(CDbl(frmCompras_lines.TxtTotal.Text), "0.00#"))
        Me.LstLines.Items(i).SubItems.Add(Format(CDbl(frmCompras_lines.TxtUD.Text), "0.00"))
        Me.LstLines.Items(i).SubItems.Add(Format(CDbl(frmCompras_lines.CbIVA.Text), "0.##"))
        Me.LstLines.Items(i).SubItems.Add(Format(CDbl(frmCompras_lines.TxtDto.Text), "0.00#"))
        Me.LstLines.Items(i).SubItems.Add(Format(CalculaDto(CDbl(frmCompras_lines.TxtUD.Text) * CDbl(frmCompras_lines.TxtTotal.Text), CDbl(frmCompras_lines.TxtDto.Text)), "0.00#"))
        Me.LstLines.Items(i).SubItems.Add(0)

        Me.LstLines.Items(i).Checked = True

        Me.LstLines.SelectedItems.Clear()
        Me.LstLines.Items(i).Selected = True
        frmCompras_lines.Dispose()
    End Sub

    'Funcion para guardar las lineas
    Private Sub SaveLines()
        Dim i As Integer = 0, StrAux As String = ""
        Dim rst As ADODB.Recordset = Nothing, n As Integer = 0

        'BORRO LOS ARTICULOS ELIMINADOS
        For i = 1 To UBound(ArrayDelField)
            My.m_db.Execute("DELETE FROM db_lin_compras where id=" & ArrayDelField(i))

            'Obtengo el multiplicador de unidades y Actualizo el stock
            rst = My.m_db.GetRst("SELECT ud_pedido FROM db_articulos WHERE id=" & Me.ArrayDelField_IdArt(i))
            If rst.RecordCount > 0 Then
                If IsDBNull(rst("ud_pedido").Value) OrElse rst("ud_pedido").Value < 1 Then
                    n = 1
                Else
                    n = rst("ud_pedido").Value
                End If
                My.m_db.Execute("UPDATE db_articulos SET ud=ud-" & Format(ArrayDelField_Ud(i) * n, "0.00").Replace(",", ".") & " WHERE estocable=true and id=" & ArrayDelField_IdArt(i))
            End If
            My.m_db.CloseRst(rst)
        Next

        'AGREGO / ACTUALIZO LAS LINEAS
        For i = 0 To Me.LstLines.Items.Count - 1
            If Me.LstLines.Items(i).Checked Then
                If Me.LstLines.Items(i).Text = 0 Then
                    'CASO DEL NUEVO
                    StrAux = "INSERT INTO db_lin_compras(id_albaran, id_articulo, name, pvp_ud, ud, iva,dto) "
                    StrAux &= "VALUES(" & Me.IdRef & "," & Me.LstLines.Items(i).SubItems(lst_Columns.id_articulo).Text & ",'" & Me.LstLines.Items(i).SubItems(lst_Columns.name).Text & "'," & Replace(Me.LstLines.Items(i).SubItems(lst_Columns.pvp_ud).Text, ",", ".") & "," & Replace(Me.LstLines.Items(i).SubItems(lst_Columns.ud).Text, ",", ".") & "," & Replace(Me.LstLines.Items(i).SubItems(lst_Columns.iva).Text, ",", ".") & "," & Replace(Me.LstLines.Items(i).SubItems(lst_Columns.dto).Text, ",", ".") & ")"
                    My.m_db.Execute(StrAux)

                    'Obtengo el multiplicador de unidades y actualizo el stock
                    rst = My.m_db.GetRst("SELECT ud_pedido FROM db_articulos WHERE id=" & Me.LstLines.Items(i).SubItems(lst_Columns.id_articulo).Text)
                    If rst.RecordCount > 0 Then
                        If IsDBNull(rst("ud_pedido").Value) OrElse rst("ud_pedido").Value < 1 Then
                            n = 1
                        Else
                            n = rst("ud_pedido").Value
                        End If

                        My.m_db.Execute("UPDATE db_articulos SET ud=ud+" & Replace(Me.LstLines.Items(i).SubItems(lst_Columns.ud).Text * n, ",", ".") & " WHERE estocable=true and id=" & Me.LstLines.Items(i).SubItems(lst_Columns.id_articulo).Text)
                    End If
                    My.m_db.CloseRst(rst)

                Else
                    'CASO DEL EDITAR
                    StrAux = "UPDATE db_lin_compras SET "
                    StrAux &= "name='" & Me.LstLines.Items(i).SubItems(lst_Columns.name).Text & "'"
                    StrAux &= ",pvp_ud=" & Replace(Me.LstLines.Items(i).SubItems(lst_Columns.pvp_ud).Text, ",", ".")
                    StrAux &= ",ud=" & Replace(Me.LstLines.Items(i).SubItems(lst_Columns.ud).Text, ",", ".")
                    StrAux &= ",dto=" & Replace(Me.LstLines.Items(i).SubItems(lst_Columns.dto).Text, ",", ".")
                    StrAux &= " WHERE id=" & Me.LstLines.Items(i).SubItems(lst_Columns.id).Text
                    My.m_db.Execute(StrAux)

                    'Obtengo el multiplicador de unidades y actualizo el stock
                    rst = My.m_db.GetRst("SELECT ud_pedido FROM db_articulos WHERE id=" & Me.LstLines.Items(i).SubItems(lst_Columns.id_articulo).Text)
                    If rst.RecordCount > 0 Then
                        If IsDBNull(rst("ud_pedido").Value) OrElse rst("ud_pedido").Value < 1 Then
                            n = 1
                        Else
                            n = rst("ud_pedido").Value
                        End If

                        My.m_db.Execute("UPDATE db_articulos SET ud=ud+" & Replace((CDbl(Me.LstLines.Items(i).SubItems(lst_Columns.ud).Text) - CDbl(Me.LstLines.Items(i).SubItems(lst_Columns.ud_orig).Text)) * n, ",", ".") & " WHERE estocable=true and id=" & Me.LstLines.Items(i).SubItems(lst_Columns.id_articulo).Text)
                    End If
                    My.m_db.CloseRst(rst)
                End If
            End If
        Next
    End Sub
#End Region

    
End Class