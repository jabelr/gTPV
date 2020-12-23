Public Class frmArticulos
    'Private WithEvents m_data As gDevelop.m_dataform
    Private _app As String = ""             'El modulo que cargamos por defecto

    Private _id As Integer = 0

    Private _n As Integer = 0
    Private _m As Integer = 0

    Dim _action As gDevelop.Lite.m_EnumTypes.TypeAction
    Public Event Shell_App(ByVal app_form As String)         'Para controlar las acciones de los botones desde el formulario padre


#Region "Funciones"
    ''' <summary>Funcion para preconfigurar el formulario</summary>
    Public Function ConfigureApp(ByVal app As String, ByVal name As String) As Boolean
        Me._app = app

        Me.LblTitle.Text = name
        Me.LblName.Text = name

        '####### Cargo las categorias de Imagen
        Dim rst As ADODB.Recordset = My.m_db.GetRst("SELECT * FROM db_categorias ORDER BY name ASC")
        Me.CbCategoria.Items.Clear()
        'Me.CbCategoria.Items.Add("(Ninguna)" & Space(100) & 0)
        Me.CbCombinable.Items.Add("(Ninguna)" & Space(100) & 0)

        While Not rst.EOF
            Me.CbCategoria.Items.Add(rst("name").Value & Space(100) & rst("id").Value)
            Me.CbCombinable.Items.Add(rst("name").Value & Space(100) & rst("id").Value)
            rst.MoveNext()
        End While

        My.m_db.CloseRst(rst)


        '####### Agrego tipos de IVA
        With Me.cbIVA.Items
            .Add(My.m_opt.IVA_General)
            .Add(My.m_opt.IVA_Medio)
            .Add(My.m_opt.IVA_Basico)
        End With

        'Asigno manejadores
        Me.AddHandlers()


        'Configuro los artículos dependiendo del tipo de compatibilidad
        Dim sw As Boolean = (My.m_opt.modo_compatibilidad = "COMERCIO")
        Me.ChkPesaje.Visible = sw
        Me.LblPesaje.Visible = sw
    End Function
#End Region

#Region "Manejadores"
    'Manejador Principal (Shell)
    Private Sub ShellApp(ByVal app_form As String, Optional ByVal action As String = "")
        Dim app As String = app_form.ToUpper

        ''Antes de iniciar cualquier opcion compruebo si la demo es valida (fix change fh)
        Select Case app
            Case "MINIMIZE"
                frm_AppIsMinimized.Show()

                Me.Owner.WindowState = FormWindowState.Minimized
                Me.WindowState = FormWindowState.Minimized

            Case "CLOSE"
                Me.Close()

            Case "OK"
                '### Antes de guardar valido datos
                'Valido las unidades de capacidad
                If Me.CbTipoStock.Text = "CAPACIDAD" AndAlso (Val(Me.TxtUD_Capacidad.Text) <= 0 OrElse Val(Me.TxtUD_capacidad_articulo.Text) <= 0) Then
                    MsgBox("Ha establecido para gestionar el almacén del artículo la modalidad de CAPACIDAD, pero los valores establecidos no son validos para poder usarlo. " & vbCrLf & "Proceda a corregirlos si desea poder guardar.", MsgBoxStyle.Exclamation)
                    Me.TabInfo.SelectedTab = Me.TabPage_Almacen
                    Exit Sub
                End If

                'Valido las unidades de fraccionado
                If Me.CbTipoStock.Text = "FRACCIONADO" AndAlso Val(Me.TxtUd_Fraccion.Text) <= 0 Then
                    MsgBox("Ha establecido para gestionar el almacén del artículo la modalidad de FRACCIONADO, pero los valores establecidos no son validos para poder usarlo. " & vbCrLf & "Proceda a corregirlos si desea poder guardar.", MsgBoxStyle.Exclamation)
                    Me.TabInfo.SelectedTab = Me.TabPage_Almacen
                    Exit Sub
                End If

                'Si esta habilitado el caso 1 compruebo valores
                If Me.ChkCaso1.Checked AndAlso (Me.TxtCaso1_Name.TextLength <= 0) Then
                    MsgBox("Ha habilitado el control 1 de valoración y control de uso para el almacén y no ha establecido los valores correctamente." & vbCrLf & vbCrLf & "Para poder continuar debe corregir dichos valores o deshabilitar esta opción", MsgBoxStyle.Exclamation)
                    Me.TabInfo.SelectedTab = Me.TabPage_Valoraciones
                    Exit Sub
                End If

                'Si esta habilitado el caso 2 compruebo valores
                If Me.ChkCaso2.Checked AndAlso (Me.TxtCaso2_Name.TextLength <= 0) Then
                    MsgBox("Ha habilitado el control 2 de valoración y control de uso para el almacén y no ha establecido los valores correctamente." & vbCrLf & vbCrLf & "Para poder continuar debe corregir dichos valores o deshabilitar esta opción", MsgBoxStyle.Exclamation)
                    Me.TabInfo.SelectedTab = Me.TabPage_Valoraciones
                    Exit Sub
                End If

                'Si esta habilitado el caso 3 compruebo valores
                If Me.ChkCaso3.Checked AndAlso (Me.TxtCaso3_Name.TextLength <= 0) Then
                    MsgBox("Ha habilitado el control 3 de valoración y control de uso para el almacén y no ha establecido los valores correctamente." & vbCrLf & vbCrLf & "Para poder continuar debe corregir dichos valores o deshabilitar esta opción", MsgBoxStyle.Exclamation)
                    Me.TabInfo.SelectedTab = Me.TabPage_Valoraciones
                    Exit Sub
                End If

                RaiseEvent Shell_App(app)

            Case Else
                RaiseEvent Shell_App(app)
        End Select
    End Sub

#End Region

#Region "Eventos Principales"
    Private Sub m_Shell_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs)
        If (Not IsNothing(m_KeyBoard)) Then m_KeyBoard.Close()
    End Sub
    Private Sub m_Shell_Load(ByVal sender As Object, ByVal e As System.EventArgs)
        'Configuro el formulario
        Me.Size = Screen.PrimaryScreen.WorkingArea.Size

        'Centro el body
        Me.PnlBody.Left = CType(Me.Owner, m_Shell).PnlBody.Left         '(Me.Width - Me.PnlBody.Width) / 2
        Me.PnlBody.Top = CType(Me.Owner, m_Shell).PnlBody.Top '+ (IIf(My.m_opt.swNoteBook, Me.SplitContainer.Panel1.Height, 0)) '(Me.SplitContainer.Panel2.Height - Me.PnlBody.Height) / 2
        Me.PnlBody.Visible = True

        Me.PnlCapacidad.Location = Me.PnlFraccionado.Location

    End Sub

#End Region

#Region "Eventos Delegados"

    'Para controlar el caso del nuevo
    Public Sub OnNewField()
        Me.LblFh_Alta.Visible = False
        Me.LblFh_Alta_nfo.Visible = False

        Me.BtSelectImg.Image = Nothing
        Me.PicImg.Image = Nothing

        Me.CbCategoria.SelectedIndex = 0
        Me.CbCombinable.SelectedIndex = 0
        Me.CbTipoStock.SelectedIndex = 0

        Me.TxtId_empresa.Text = My.m_app.GetValue("id_empresa")
        Me.cbIVA.SelectedIndex = 1
        CbCategoria_SelectedIndexChanged(Me.CbCategoria, New System.EventArgs)

        Me._id = 0

        If Me.TabInfo.Contains(Me.TabPage_Almacen) Then Me.TabInfo.TabPages.Remove(Me.TabPage_Almacen)
        If Me.TabInfo.Contains(Me.tabPage_Tarifas) Then Me.TabInfo.TabPages.Remove(Me.tabPage_Tarifas)
        If Me.TabInfo.Contains(Me.TabPage_Valoraciones) Then Me.TabInfo.TabPages.Remove(Me.TabPage_Valoraciones)
    End Sub

    ' Cada vez que cargo un registro
    Public Sub OnLoadField(ByVal id As Integer)
        'Limpio controles antes de cada carga
        'Me.PicImg.Image = Nothing
        'Me.BtSelectImg.Image = Nothing

        'Establezco  valores
        Me._id = id
        Me.LblId.Text = "Ref. " & id

        Me.TxtName_Comercial.Select()
        Me.Tab.SelectedIndex = 0

        Me.LblSubTitle.Text = "Visualizando el registro de """ & Me.TxtName_Comercial.Text & """"                 ' Submensaje"
        'if me.PicImg.Image isnot nothing andalso not isnothing(Me.BtSelectImg.Image = Me. then
        'Me.BtSelectImg.Image = Me.PicImg.Image

        'Compruebo foto
        'Me.BtSelectImg.Text = IIf(IsNothing(Me.BtSelectImg.Image), "Click para seleccionar Imagen", "")

        'Cargo la Foto
        LoadImgGaleria()

        'Establezco estados
        Me.LblFh_Alta.Visible = True
        Me.LblFh_Alta_nfo.Visible = True

        'Establezco la categoria enlazadas
        Dim i As Integer
        For i = 0 To Me.CbCategoria.Items.Count - 1
            If Me.TxtId_Categoria.Text = Me.CbCategoria.Items(i).Substring(100).Trim Then Me.CbCategoria.SelectedIndex = i
        Next

        For i = 0 To Me.CbCombinable.Items.Count - 1
            If Me.TxtId_categoria_combina.Text = Me.CbCombinable.Items(i).Substring(100).Trim Then Me.CbCombinable.SelectedIndex = i
        Next

        If Val(Me.TxtId_Img.Text) <= 0 Then Me.PicImg.Image = Nothing


        '### Controlo los tabs
        'Si se controla el almacen, valoro si tiene control especial de unidades
        If Me.ChkEstocable.Checked Then
            If Not Me.TabInfo.Contains(Me.TabPage_Almacen) Then Me.TabInfo.TabPages.Add(Me.TabPage_Almacen)

        Else
            If Me.TabInfo.Contains(Me.TabPage_Almacen) Then Me.TabInfo.TabPages.Remove(Me.TabPage_Almacen)
            'If Me.TabInfo.Contains(Me.TabPage_Valoraciones) Then Me.TabInfo.TabPages.Remove(Me.TabPage_Valoraciones)
        End If

        If Me.ChkValoraciones.Checked Then
            If Not Me.TabInfo.Contains(Me.TabPage_Valoraciones) Then Me.TabInfo.TabPages.Add(Me.TabPage_Valoraciones)
        Else
            If Me.TabInfo.Contains(Me.TabPage_Valoraciones) Then Me.TabInfo.TabPages.Remove(Me.TabPage_Valoraciones)
        End If

        'Controlo si tiene habilitadas tarifas de articulo
        If Me.chkTarifas.Checked Then
            If Not Me.TabInfo.Contains(Me.tabPage_Tarifas) Then Me.TabInfo.TabPages.Add(Me.tabPage_Tarifas)
        ElseIf Me.TabInfo.Contains(Me.tabPage_Tarifas) Then
            Me.TabInfo.TabPages.Remove(Me.tabPage_Tarifas)
        End If



        'Me.CbCombinable.Visible = Me.ChkCombinable.Checked
        'Me.LblNfo_Combina.Visible = Me.ChkCombinable.Checked
    End Sub

    'Comprobaciones antes de guardar
    Public Sub OnSaveField(ByRef cancell As Boolean)
        If Me.TxtName_Comercial.TextLength <= 0 Then
            My.m_msg.MessageError(Me.Owner, "Debe de establecer el nombre del producto para poder guardar.")
            Me.TxtName_Comercial.SelectAll()
            cancell = True
            Exit Sub
        End If

        If Not IsNumeric(Me.TxtUd_Pedido.Text) Then Me.TxtUd_Pedido.Text = 1

        If CDbl(Me.TxtUd_Pedido.Text) < 1 Then Me.TxtUd_Pedido.Text = 1


        'cancell = True
    End Sub

    Public Sub StateForm(ByVal action As gDevelop.Lite.m_EnumTypes.TypeAction)
        _action = action
        Select Case action
            Case gDevelop.Lite.m_EnumTypes.TypeAction._Unknown
                Me.BtNew.Enabled = True
                Me.BtEdit.Enabled = True
                Me.BtDel.Enabled = True

                Me.BtCancell.Enabled = False
                Me.BtOk.Enabled = False

                Me.BtCancell.Enabled = False
                Me.BtOk.Enabled = False


                'Me.BtSelectImg.Text = ""

                'Me.LblSubTitle.Text = "Mostrando " & Me.TxtName.Text

            Case gDevelop.Lite.m_EnumTypes.TypeAction.OnNew, gDevelop.Lite.m_EnumTypes.TypeAction.OnEdit
                Me.BtNew.Enabled = False
                Me.BtEdit.Enabled = False
                Me.BtDel.Enabled = False

                Me.BtCancell.Enabled = True
                Me.BtOk.Enabled = True

                Me.BtFirst.Enabled = False
                Me.BtPrevious.Enabled = False

                Me.BtNext.Enabled = False
                Me.BtLast.Enabled = False

                Me.BtClose.Visible = False

                Me.LblSubTitle.Text = "Editando " & Me.TxtName_Comercial.Text                 ' Submensaje

                If action = gDevelop.Lite.m_EnumTypes.TypeAction.OnNew Then
                    Me.LblSubTitle.Text = "Nuevo Registro"
                    Me.LblId.Visible = False
                    Me.LblNofM.Visible = False

                    'Me.CbIVA.SelectedIndex = 0
                    'Me.BtSelectImg.Image = Nothing
                    'Me.PicImg.Image = Nothing

                End If

                Me.BtSelectImg.Image = Me.PicImg.Image
                Me.TxtName_Comercial.Select()

                Exit Sub
            Case gDevelop.Lite.m_EnumTypes.TypeAction.OnCancell, gDevelop.Lite.m_EnumTypes.TypeAction.OnSave
                Me.BtNew.Enabled = True
                Me.BtEdit.Enabled = True
                Me.BtDel.Enabled = True

                Me.BtCancell.Enabled = False
                Me.BtOk.Enabled = False

                Me.BtSelectImg.Text = ""

                Me.LblNofM.Visible = True
                Me.LblId.Visible = True

                FieldPosition(Me._n, Me._m)
            Case gDevelop.Lite.m_EnumTypes.TypeAction.OnShow
                Me.PicImg.Image = Nothing
                Me.BtSelectImg.Image = Nothing
        End Select

        ' Estados fijos a no ser que retornemos la funcion
        'Me.PicImg.Visible = True
        Me.BtClose.Visible = True

        'Limpio controles
        'Me.PicImg.Image = Nothing
        'Me.BtSelectImg.Image = Nothing
    End Sub

    Public Sub FieldPosition(ByVal n As Integer, ByVal m As Integer)
        Me.LblNofM.Text = n & "/" & m

        'Establezco el estado de los botones de movimiento
        Me.BtFirst.Enabled = (n > 1)
        Me.BtPrevious.Enabled = (n > 1)

        Me.BtNext.Enabled = (n < m)
        Me.BtLast.Enabled = (n < m)

        Me._n = n
        Me._m = m

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
    Private Sub ChkSesionPVP_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.ChkSesionPVP.ImageIndex = IIf(Me.ChkSesionPVP.Checked, 1, 0)
        Me.PnlSecionPVP.Visible = Me.ChkSesionPVP.Checked
    End Sub

    Private Sub ChkUd_Espciales_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.ChkValoraciones.ImageIndex = IIf(Me.ChkValoraciones.Checked, 1, 0)

        If Me._action = gDevelop.Lite.m_EnumTypes.TypeAction.OnEdit OrElse Me._action = gDevelop.Lite.m_EnumTypes.TypeAction.OnNew Then
            '### Controlo el tab de unidades especiales
            If Me.ChkValoraciones.Checked AndAlso Not Me.TabInfo.Contains(Me.TabPage_Valoraciones) Then
                Me.TabInfo.TabPages.Add(Me.TabPage_Valoraciones)
            ElseIf Me.TabInfo.Contains(Me.TabPage_Valoraciones) Then
                Me.TabInfo.TabPages.Remove(Me.TabPage_Valoraciones)
            End If
        End If
    End Sub

    Private Sub CbTipoStock_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If Me.BtOk.Enabled AndAlso Me.PnlFraccionado.Visible AndAlso Me.CbTipoStock.Text <> "FRACCIONADO" Then Me.TxtUsos.Text = 0
        If Me.BtOk.Enabled AndAlso Me.PnlCapacidad.Visible AndAlso Me.CbTipoStock.Text <> "CAPACIDAD" Then Me.TxtCapacidad_usos.Text = 0

        Me.PnlFraccionado.Visible = (Me.CbTipoStock.Text = "FRACCIONADO")
        Me.PnlCapacidad.Visible = (Me.CbTipoStock.Text = "CAPACIDAD")
        'Me.PnlConsumo.Visible = (Me.CbTipoStock.Text = "CAPACIDAD")
    End Sub

    Private Sub ChkIs_Menu_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.ChkIs_Menu.ImageIndex = IIf(Me.ChkIs_Menu.Checked, 1, 0)
        Me.PnlComandas.Visible = Me.ChkIs_Menu.Checked
    End Sub

    Private Sub ChkComanda_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.ChkComanda.ImageIndex = IIf(Me.ChkComanda.Checked, 1, 0)
    End Sub

    Private Sub TxtPvp_IVA_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs)
        My.AsignarFoco(Me.TxtPvp_IVA)
    End Sub

    Private Sub TxtPvp_IVA_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.TxtCaso1_Pvp.Text = Me.TxtPvp_IVA.Text
    End Sub

    Private Sub ChkEstocable_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.ChkEstocable.ImageIndex = IIf(Me.ChkEstocable.Checked, 1, 0)
        Me.Group_Stock.Visible = Me.ChkEstocable.Checked

        If Me._action = gDevelop.Lite.m_EnumTypes.TypeAction.OnEdit OrElse Me._action = gDevelop.Lite.m_EnumTypes.TypeAction.OnNew Then
            '### Controlo el tab de almacen
            If Me.ChkEstocable.Checked AndAlso Not Me.TabInfo.Contains(Me.TabPage_Almacen) Then
                Me.TabInfo.TabPages.Add(Me.TabPage_Almacen)
            ElseIf Me.TabInfo.Contains(Me.TabPage_Almacen) Then
                Me.TabInfo.TabPages.Remove(Me.TabPage_Almacen)
            End If

        End If
    End Sub

    Private Sub chkTarifas_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.chkTarifas.ImageIndex = IIf(Me.chkTarifas.Checked, 1, 0)

        If Me._action = gDevelop.Lite.m_EnumTypes.TypeAction.OnEdit OrElse Me._action = gDevelop.Lite.m_EnumTypes.TypeAction.OnNew Then
            '### Controlo el tab de tarifas
            If Me.chkTarifas.Checked AndAlso Not Me.TabInfo.Contains(Me.tabPage_Tarifas) Then
                Me.TabInfo.TabPages.Add(Me.tabPage_Tarifas)
            ElseIf Me.TabInfo.Contains(Me.tabPage_Tarifas) Then
                Me.TabInfo.TabPages.Remove(Me.tabPage_Tarifas)
            End If

        End If
    End Sub

    Private Sub ChkPesaje_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.ChkPesaje.ImageIndex = IIf(Me.ChkPesaje.Checked, 1, 0)
    End Sub

    Private Sub ChkPedido_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.chkPedido.ImageIndex = IIf(Me.chkPedido.Checked, 1, 0)
    End Sub

    Private Sub ChkObs_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.chkObs.ImageIndex = IIf(Me.chkObs.Checked, 1, 0)
    End Sub

    Private Sub ChkCombinable_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.ChkCombinable.ImageIndex = IIf(Me.ChkCombinable.Checked, 1, 0)
        Me.PnlCombina.Visible = Me.ChkCombinable.Checked
    End Sub

    Private Sub chkIncCombina_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.chkIncCombina.ImageIndex = IIf(Me.chkIncCombina.Checked, 1, 0)
        Me.pnlIncCombina.Visible = Me.chkIncCombina.Checked
    End Sub

    Private Sub CbCombinable_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.TxtId_categoria_combina.Text = Me.CbCombinable.Text.Substring(100).Trim
    End Sub

    Private Sub CbCategoria_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.TxtId_Categoria.Text = Me.CbCategoria.Text.Substring(100).Trim
    End Sub

    Private Sub Buttons_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'Si no tiene establecido el tag mando un error
        If IsNothing(CType(sender, Button).Tag) OrElse CType(sender, Button).Tag.ToString.Length = 0 Then
            My.m_msg.MessageError(sender, "Tag de control de elemento no referenciado")
            Exit Sub
        End If

        ShellApp(CType(sender, Button).Tag.ToString)
    End Sub

    Private Sub m_Shell_Activated(ByVal sender As Object, ByVal e As System.EventArgs)
        Me.Left = 0
        Me.Top = 0

        Me.PnlData.Visible = True
    End Sub

    Private Sub ChkCaso1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.PnlCaso1.Visible = Me.ChkCaso1.Checked
    End Sub

    Private Sub ChkCaso2_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.PnlCaso2.Visible = Me.ChkCaso2.Checked
    End Sub

    Private Sub ChkCaso3_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.PnlCaso3.Visible = Me.ChkCaso3.Checked
    End Sub
#End Region

#Region "Control de Imagen"
    Private Sub BtSelectImg_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'Muestro el formulario de lineas
        With frmArticulos_SelectImgGalery
            .Id_Ref = Val(Me.TxtId_Img.Text)
            .ShowDialog(Me)
            If .DialogResult <> Windows.Forms.DialogResult.OK Then
                .Dispose()
                Exit Sub
            End If
            Me.TxtId_Img.Text = .Id_Ref

            Me.LoadImgGaleria()
            Me.BtSelectImg.Image = Me.PicImg.Image

            .Dispose()
        End With



        'Dim myStream As IO.Stream
        'Dim dlg As New OpenFileDialog()

        'dlg.Filter = "Archivos de imagen jpg (*.jpg)|*.jpg"
        'dlg.FilterIndex = 0
        'dlg.RestoreDirectory = False



        'If dlg.ShowDialog() <> Windows.Forms.DialogResult.OK Then Exit Sub

        'Me.BtSelectImg.Image = Image.FromFile(gDevelop.m_Functions.resize_image(dlg.FileName, 110))
        'Me.PicImg.Image = Me.BtSelectImg.Image


    End Sub

    Private Sub LnkDelImg_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs)
        Me.TxtId_Img.Text = 0
        Me.PicImg.Image = Nothing
        Me.BtSelectImg.Image = Nothing
        Me.BtSelectImg.Text = "Click para seleccionar Fotografía de la Galería"
    End Sub

    ' Carga de la imagen
    Private Sub LoadImgGaleria()
        Me.PicImg.Image = Nothing

        Dim rst As ADODB.Recordset = My.m_db.GetRst("SELECT img FROM app_imgs WHERE id=" & Me.TxtId_Img.Text)
        If rst.RecordCount = 0 Then Exit Sub
        Me.PicImg.Image = My.m_db.data_GetImgRow(rst("img"))
        My.m_db.CloseRst(rst)
    End Sub
#End Region

#Region "AddHandlers"
    Private Sub AddHandlers()
        AddHandler Me.TxtPVP.KeyPress, AddressOf gDevelop.Lite.m_OverridesEvents.TxtValidaEuro_KeyPress
        AddHandler Me.TxtPvp_IVA.KeyPress, AddressOf gDevelop.Lite.m_OverridesEvents.TxtValidaEuro_KeyPress
        AddHandler Me.txtPVP_Costo.KeyPress, AddressOf gDevelop.Lite.m_OverridesEvents.TxtValidaEuro_KeyPress

        AddHandler Me.txtTarifa_1_pvp.KeyPress, AddressOf gDevelop.Lite.m_OverridesEvents.TxtValidaEuro_KeyPress
        AddHandler Me.txtTarifa_2_pvp.KeyPress, AddressOf gDevelop.Lite.m_OverridesEvents.TxtValidaEuro_KeyPress
        AddHandler Me.txtTarifa_3_pvp.KeyPress, AddressOf gDevelop.Lite.m_OverridesEvents.TxtValidaEuro_KeyPress

        AddHandler Me.txtTarifa_1_base.KeyPress, AddressOf gDevelop.Lite.m_OverridesEvents.TxtValidaEuro_KeyPress
        AddHandler Me.txtTarifa_2_base.KeyPress, AddressOf gDevelop.Lite.m_OverridesEvents.TxtValidaEuro_KeyPress
        AddHandler Me.txtTarifa_3_base.KeyPress, AddressOf gDevelop.Lite.m_OverridesEvents.TxtValidaEuro_KeyPress


        AddHandler Me.TxtUd.KeyPress, AddressOf gDevelop.Lite.m_OverridesEvents.TxtValidaNumeric_KeyPress
        AddHandler Me.TxtUd_Min.KeyPress, AddressOf gDevelop.Lite.m_OverridesEvents.TxtValidaNumeric_KeyPress
        AddHandler Me.TxtUd_Opt.KeyPress, AddressOf gDevelop.Lite.m_OverridesEvents.TxtValidaNumeric_KeyPress

        AddHandler Me.TxtUd_Pedido.KeyPress, AddressOf gDevelop.Lite.m_OverridesEvents.TxtValidaNumeric_KeyPress

        AddHandler Me.TxtUd_Fraccion.KeyPress, AddressOf gDevelop.Lite.m_OverridesEvents.TxtValidaNumeric_KeyPress
        AddHandler Me.TxtUD_Capacidad.KeyPress, AddressOf gDevelop.Lite.m_OverridesEvents.TxtValidaNumeric_KeyPress
        AddHandler Me.TxtUD_capacidad_articulo.KeyPress, AddressOf gDevelop.Lite.m_OverridesEvents.TxtValidaNumeric_KeyPress

        AddHandler Me.TxtCaso1_Pvp.KeyPress, AddressOf gDevelop.Lite.m_OverridesEvents.TxtValidaEuro_KeyPress
        AddHandler Me.TxtCaso1_Ud.KeyPress, AddressOf gDevelop.Lite.m_OverridesEvents.TxtValidaNumeric_KeyPress

        AddHandler Me.TxtCaso2_Pvp.KeyPress, AddressOf gDevelop.Lite.m_OverridesEvents.TxtValidaEuro_KeyPress
        AddHandler Me.TxtCaso2_Ud.KeyPress, AddressOf gDevelop.Lite.m_OverridesEvents.TxtValidaNumeric_KeyPress

        AddHandler Me.TxtCaso3_Pvp.KeyPress, AddressOf gDevelop.Lite.m_OverridesEvents.TxtValidaEuro_KeyPress
        AddHandler Me.TxtCaso3_Ud.KeyPress, AddressOf gDevelop.Lite.m_OverridesEvents.TxtValidaNumeric_KeyPress


        AddHandler Me.TxtSesionPVP_HoraFeliz.KeyPress, AddressOf gDevelop.Lite.m_OverridesEvents.TxtValidaEuro_KeyPress
        AddHandler Me.TxtSesionPVP_PVP2.KeyPress, AddressOf gDevelop.Lite.m_OverridesEvents.TxtValidaEuro_KeyPress

        AddHandler Me.txtPvp_IncCombina.KeyPress, AddressOf gDevelop.Lite.m_OverridesEvents.TxtValidaEuro_KeyPress

        AddHandler Me.TxtUsos.KeyPress, AddressOf gDevelop.Lite.m_OverridesEvents.TxtValidaNumeric_KeyPress
        AddHandler Me.TxtFraccion_Uso.KeyPress, AddressOf gDevelop.Lite.m_OverridesEvents.TxtValidaNumeric_KeyPress

    End Sub
#End Region

#Region "Calculos de Precios"
    Private Sub TxtPVP_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs)
        If Not IsNumeric(Me.TxtPVP.Text) Then Me.TxtPVP.Text = 0
        'If Me.CbIVA.SelectedIndex <= 0 Then Me.CbIVA.SelectedIndex = 0

        Me.TxtPvp_IVA.Text = Format(Me.TxtPVP.Text + ((Me.TxtPVP.Text * Me.cbIVA.Text) / 100), "0.00")
        Me.TxtPVP.Text = Format(CDbl(Me.TxtPVP.Text), "0.00#")

    End Sub

    ' De Precio IVA Incluido a Precio Base
    Private Sub TxtPvp_IVA_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs)
        If Me.cbIVA.SelectedIndex <= 0 Then Me.cbIVA.SelectedIndex = 0

        If Not IsNumeric(Me.TxtPvp_IVA.Text) Then Me.TxtPvp_IVA.Text = 0
        Me.TxtPVP.Text = Format(Me.TxtPvp_IVA.Text / CDbl("1," & Format(CDbl(Me.cbIVA.Text), "00")), "0.00###")
        Me.TxtPvp_IVA.Text = Format(CDbl(Me.TxtPvp_IVA.Text), "0.00")
    End Sub

    Private Sub CbIVA_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If Me._action = gDevelop.Lite.m_EnumTypes.TypeAction.OnNew OrElse Me._action = gDevelop.Lite.m_EnumTypes.TypeAction.OnEdit Then
            Me.TxtPvp_IVA_LostFocus(Me.TxtPvp_IVA, e)
            Me.TxtTarifa_1_PVP_LostFocus(Me.txtTarifa_1_pvp, e)
        End If

    End Sub

#Region "Tarifa #1"
    Private Sub txtTarifa_1_base_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs)
        If Not IsNumeric(Me.txtTarifa_1_base.Text) Then Me.txtTarifa_1_base.Text = 0
        'If Me.CbIVA.SelectedIndex <= 0 Then Me.CbIVA.SelectedIndex = 0

        Me.txtTarifa_1_pvp.Text = Format(Me.txtTarifa_1_base.Text + ((Me.txtTarifa_1_base.Text * Me.cbIVA.Text) / 100), "0.00")
        Me.txtTarifa_1_base.Text = Format(CDbl(Me.txtTarifa_1_base.Text), "0.00#")

    End Sub

    ' De Precio IVA Incluido a Precio Base
    Private Sub TxtTarifa_1_PVP_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs)
        If Me.cbIVA.SelectedIndex <= 0 Then Me.cbIVA.SelectedIndex = 0

        If Not IsNumeric(Me.txtTarifa_1_pvp.Text) Then Me.txtTarifa_1_pvp.Text = 0
        Me.txtTarifa_1_base.Text = Format(Me.txtTarifa_1_pvp.Text / CDbl("1," & Format(CDbl(Me.cbIVA.Text), "00")), "0.00#")
        Me.txtTarifa_1_pvp.Text = Format(CDbl(Me.txtTarifa_1_pvp.Text), "0.00")
    End Sub
#End Region

#Region "Tarifa #2"
    Private Sub txttarifa_2_base_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs)
        If Not IsNumeric(Me.txtTarifa_2_base.Text) Then Me.txtTarifa_2_base.Text = 0
        'If Me.CbIVA.SelectedIndex <= 0 Then Me.CbIVA.SelectedIndex = 0

        Me.txtTarifa_2_pvp.Text = Format(Me.txtTarifa_2_base.Text + ((Me.txtTarifa_2_base.Text * Me.cbIVA.Text) / 100), "0.00")
        Me.txtTarifa_2_base.Text = Format(CDbl(Me.txtTarifa_2_base.Text), "0.00#")

    End Sub

    ' De Precio IVA Incluido a Precio Base
    Private Sub Txttarifa_2_PVP_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs)
        If Me.cbIVA.SelectedIndex <= 0 Then Me.cbIVA.SelectedIndex = 0

        If Not IsNumeric(Me.txtTarifa_2_pvp.Text) Then Me.txtTarifa_2_pvp.Text = 0
        Me.txtTarifa_2_base.Text = Format(Me.txtTarifa_2_pvp.Text / CDbl("1," & Format(CDbl(Me.cbIVA.Text), "00")), "0.00#")
        Me.txtTarifa_2_pvp.Text = Format(CDbl(Me.txtTarifa_2_pvp.Text), "0.00")
    End Sub
#End Region

#Region "Tarifa #3"
    Private Sub txttarifa_3_base_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txttarifa_3_base.LostFocus
        If Not IsNumeric(Me.txttarifa_3_base.Text) Then Me.txttarifa_3_base.Text = 0
        'If Me.CbIVA.SelectedIndex <= 0 Then Me.CbIVA.SelectedIndex = 0

        Me.txttarifa_3_pvp.Text = Format(Me.txttarifa_3_base.Text + ((Me.txttarifa_3_base.Text * Me.cbIVA.Text) / 100), "0.00")
        Me.txttarifa_3_base.Text = Format(CDbl(Me.txttarifa_3_base.Text), "0.00#")

    End Sub

    ' De Precio IVA Incluido a Precio Base
    Private Sub Txttarifa_3_PVP_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txttarifa_3_pvp.LostFocus
        If Me.cbIVA.SelectedIndex <= 0 Then Me.cbIVA.SelectedIndex = 0

        If Not IsNumeric(Me.txttarifa_3_pvp.Text) Then Me.txtTarifa_3_pvp.Text = 0
        Me.txtTarifa_3_base.Text = Format(Me.txtTarifa_3_pvp.Text / CDbl("1," & Format(CDbl(Me.cbIVA.Text), "00")), "0.00#")
        Me.txtTarifa_3_pvp.Text = Format(CDbl(Me.txtTarifa_3_pvp.Text), "0.00")
    End Sub
#End Region


#End Region



    'Muestro detalles ocultos
    Private Sub m_logo_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles m_logo.DoubleClick
        Me.TxtUsos.Visible = True
        Me.TxtCapacidad_usos.Visible = True
    End Sub

    Private Sub TxtPVP_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtPVP.TextChanged

    End Sub

    Private Sub cbIVA_General_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbIVA.SelectedIndexChanged
        Me.txtIdTipoIVA.Text = Me.cbIVA.SelectedIndex
    End Sub
End Class