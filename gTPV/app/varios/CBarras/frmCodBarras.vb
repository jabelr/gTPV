Public Class frmCodBarras
    'RecordSet para el temporal de imagenes
    Private RstImg As ADODB.Recordset

    'El id automatico de la linea de articulo
    Private Id_Auto As Integer = 0


    'Para controlar los pasos 
    '   0 - Seleccion de articulos
    '   1 - Configuracion del resultado
    '   2 - Trabajando
    '   3 - Preparando la impresion
    Private intPaso As Integer = 0

    'Controlo en que posicion empiezo a imprimir
    Private intInitPrint As Integer = 0

#Region "Eventos Principales"
    Private Sub FrmCfgEtiquetas_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Elimino el temporal de imagenes
        My.m_db_temp.Execute("DELETE FROM tmp_etiquetas")
        My.m_db_temp.Execute("DELETE FROM tmp_codbarras")

        Me.LoadPrinters()

        'Establezco valores por defecto
        Me.CbTipoImpresiones.SelectedIndex = 0
        Me.CbTipoEtiquta.SelectedIndex = 0
        Me.CbTamanoEtiqueta.SelectedIndex = 0
        Me.cbTipo.SelectedIndex = 0

        'Pociciono los groups
        Me.Group_Art.Location = New Point(7, 7)
        Me.Group_CfgEtiquetadora.Location = Me.Group_Art.Location
        Me.Group_CfgPrinter.Location = Me.Group_Art.Location
        Me.Group_Generate.Location = Me.Group_Art.Location


        '' Configuracion del fondo
        'Dim pic As New PictureBox()
        'pic.Image = My.Resources.background_Form
        'pic.SizeMode = PictureBoxSizeMode.AutoSize
        'pic.Dock = DockStyle.Fill
        'Me.SplitContainer.Panel2.Controls.Add(pic)

    End Sub
#End Region

#Region "Eventos Auxiliares"
    Private Sub ChkPrintDirect_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChkPrintDirect.CheckedChanged
        'Me.CbPrint.Enabled = Me.ChkPrintDirect.Checked
    End Sub

    Private Sub ChkPrintDirect_Etiquetadora_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChkPrintDirect_Etiquetadora.CheckedChanged
        'Me.CbPrint_Etiquetadora.Enabled = Me.ChkPrintDirect_Etiquetadora.Checked
    End Sub

    Private Sub BtNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtNew.Click
        Me.Lst_Contable.Items.Clear()

        My.m_db_temp.Execute("DELETE FROM tmp_etiquetas")
        My.m_db_temp.Execute("DELETE FROM tmp_codbarras")

        LoadPrinters()

        intPaso = 0
        Cfg_Change()
    End Sub

    Private Sub BtClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtClose.Click
        Me.Close()
    End Sub

    Private Sub ToolStrip_Prev_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStrip_Prev.Click
        intPaso -= 1
        Me.Cfg_Change()
    End Sub

    Private Sub ToolStrip_Next_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStrip_Next.Click
        intPaso += 1
        Me.Cfg_Change()
    End Sub

    Private Sub ToolStrip_Cancell_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStrip_Cancell.Click
        Me.Close()
    End Sub

    Private Sub ToolStrip_Save_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStrip_Save.Click
        'GenerarEtiquetas()
    End Sub

    Private Sub Lst_Contable_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles Lst_Contable.DoubleClick
        If Lst_Contable.SelectedItems.Count > 0 Then Lnk_EditArticulos()
    End Sub

    Private Sub List_Contable_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Lst_Contable.SelectedIndexChanged
        Me.Bt_Edit.Enabled = (Lst_Contable.SelectedItems.Count <> 0)
        Me.Bt_Del.Enabled = (Lst_Contable.SelectedItems.Count <> 0)
    End Sub

    Private Sub BtLst_Articulos(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Bt_Edit.Click, Bt_Del.Click, Bt_Add.Click, Bt_select.Click
        Select Case True
            Case sender Is Me.Bt_Add
                Lnk_AddArticulos()
            Case sender Is Me.Bt_Edit
                Lnk_EditArticulos()
            Case sender Is Me.Bt_Del
                Lnk_DelArticulos()

            Case sender Is Me.Bt_select
                Err.Raise(197, "frmCodBarras", "Aún no implementado.")


        End Select
    End Sub

    Private Sub Button_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If CType(sender, RadioButton).Name.Length = 0 Then Exit Sub
        If CType(sender, RadioButton).Checked Then intInitPrint = CType(sender, RadioButton).TabIndex

        CType(sender, RadioButton).BackColor = IIf(CType(sender, RadioButton).Checked, Color.Black, Color.White)
    End Sub
#End Region

#Region "Codigo de las lineas de Artículos"
    'Funcion que me elimina un articulo de la lista
    Private Sub Lnk_DelArticulos()
        If MsgBox("¿Esta seguro de que desea eliminar el artículo seleccionado?", MsgBoxStyle.Information, "Etiquetas") = MsgBoxResult.Cancel Then Exit Sub

        My.m_db_temp.Execute("DELETE FROM tmp_codbarras where id_line=" & Me.Lst_Contable.SelectedItems(0).Text)
        Me.Lst_Contable.SelectedItems(0).Remove()

        ToolStrip_Next.Enabled = (Me.Lst_Contable.Items.Count > 0)
    End Sub

    'Funcion para editar los articulos
    Private Sub Lnk_EditArticulos()
        FrmEtiquetas_Lines.idRef = Me.Lst_Contable.SelectedItems(0).Text
        FrmEtiquetas_Lines.ChkPrint_Name.Checked = (Me.Lst_Contable.SelectedItems(0).SubItems(4).Text = 1)
        FrmEtiquetas_Lines.Num_Etiquetas.Value = Me.Lst_Contable.SelectedItems(0).SubItems(2).Text
        FrmEtiquetas_Lines.swColor = CBool(Me.Lst_Contable.SelectedItems(0).SubItems(6).Text)
        FrmEtiquetas_Lines.strTalla = Me.Lst_Contable.SelectedItems(0).SubItems(7).Text
        FrmEtiquetas_Lines.ShowDialog(Me)
        If FrmEtiquetas_Lines.DialogResult = Windows.Forms.DialogResult.OK Then
            With Me.Lst_Contable.SelectedItems(0)
                .SubItems(4).Text = IIf(FrmEtiquetas_Lines.ChkPrint_Name.Checked, 1, 0)
                .SubItems(2).Text = FrmEtiquetas_Lines.Num_Etiquetas.Value
            End With
        End If
        FrmEtiquetas_Lines.Dispose()
    End Sub

    Private Sub Lnk_AddArticulos()

        ''Si no carga canceloo
        'If Not FrmExport.Load_Config("articulos", -1) Then
        '    FrmExport.Dispose()
        '    Exit Sub
        'End If

        'FrmExport.ShowDialog(Me.Owner)
        'If FrmExport.DialogResult = Windows.Forms.DialogResult.Cancel Then
        '    FrmExport.Dispose()
        '    Exit Sub
        'End If

        'Dim IdAux As Integer = FrmExport.m_Id
        'FrmExport.Dispose()

        Dim id As Integer = -1
        With m_Shell
            'Preconfiguro y muestro
            If Not .ConfigureApp("ARTICULOS", True) Then Exit Sub
            'Preconfiguro y muestro
            'AddHandler .mData_ExportId, AddressOf mData_ExportId
            'AddHandler .mData_CancelExport, AddressOf mData_CancelExport

            '.MdiParent = Me
            '.m_Form.MdiParent = Me
            '.Dock = DockStyle.Fill
            .TopMost = True

            .ShowDialog()
            ' .Select()
            If .DialogResult <> Windows.Forms.DialogResult.OK Then
                .Dispose()
                Exit Sub
            End If

            id = ._exportID
            .Dispose()
        End With


        Dim idAux As Integer = id
        If idAux = -1 Then Exit Sub

        Dim rst As ADODB.Recordset = My.m_db.GetRst("SELECT name FROM db_articulos WHERE id=" & idAux)
        FrmEtiquetas_Lines.Text = rst("name").Value
        My.m_db.CloseRst(rst)

        FrmEtiquetas_Lines.idRef = IdAux

        FrmEtiquetas_Lines.ShowDialog(Me)

        If FrmEtiquetas_Lines.DialogResult = Windows.Forms.DialogResult.OK Then

            'Incremento el id_auto (general)
            Id_Auto += 1

            'Obtengo informacion sobre el articulo
            Dim RstAux As ADODB.Recordset = My.m_db.GetRst("Select id,name,pvp,pvp_iva,tipo_iva from db_articulos where id=" & idAux)

            'Agrego el item y lo selecciono
            Dim i As Integer = Me.Lst_Contable.Items.Count
            Me.Lst_Contable.Items.Add(Id_Auto)
            Me.Lst_Contable.Items(i).SubItems.Add(IdAux)
            Me.Lst_Contable.Items(i).SubItems.Add(FrmEtiquetas_Lines.Num_Etiquetas.Value)
            Me.Lst_Contable.Items(i).SubItems.Add(RstAux("name").Value & "")
            Me.Lst_Contable.Items(i).SubItems.Add(IIf(FrmEtiquetas_Lines.ChkPrint_Name.Checked, 1, 0))
            Me.Lst_Contable.Items(i).SubItems.Add(RstAux("pvp_iva").Value)
            Me.Lst_Contable.Items(i).SubItems.Add(False)
            Me.Lst_Contable.Items(i).SubItems.Add("")
            Me.Lst_Contable.Items(i).SubItems.Add(FrmEtiquetas_Lines.Ean)
            Me.Lst_Contable.Items(i).Selected = True



            'Limpio y agrego la linea temporal con la imagen
            My.m_db_temp.Execute("DELETE FROM tmp_codbarras where id_line=" & Id_Auto)
            RstImg = My.m_db_temp.GetRst("Select * from tmp_codbarras where id=-1")

            RstImg.AddNew()
            RstImg.Fields("id_line").Value = Id_Auto
            RstImg.Fields("image").Value = FrmEtiquetas_Lines.arrImage
            RstImg.Fields("line1").Value = RstAux("name").Value & ""
            RstImg.Fields("line2").Value = RstAux("pvp_iva").Value & ""
            RstImg.Update()

            My.m_db.CloseRst(RstAux)
            My.m_db.CloseRst(RstImg)
        End If

        FrmEtiquetas_Lines.Dispose()

        ToolStrip_Next.Enabled = (Me.Lst_Contable.Items.Count > 0)

    End Sub

#End Region

#Region "Pasos nOFm"
    Private Sub Cfg_Change()
        Dim StrTitle As String = ""
        Select Case intPaso
            Case 0
                StrTitle = "Selección de Artículos [PASO 1/3]"
                Group_Art.Visible = True
                Group_CfgPrinter.Visible = False
                Me.Group_CfgEtiquetadora.Visible = False
                Me.ToolStrip_Prev.Enabled = False
                Me.Group_Generate.Visible = False
            Case 1
                StrTitle = "Configuración de la Impresión [PASO 2/3]"
                Group_Art.Visible = False

                If CbTipoImpresiones.SelectedIndex = 0 Then
                    ' Papel de etiquetas
                    Group_CfgPrinter.Visible = True
                Else
                    ' Impresora de etiquetas
                    Me.Group_CfgEtiquetadora.Visible = True
                End If

                Me.ToolStrip_Prev.Enabled = True

                Me.Group_Generate.Visible = False
                Me.ToolStrip_Next.Enabled = True
            Case 2
                StrTitle = "Generando las etiquetas [PASO 3/3]"
                Me.Group_Generate.Visible = True
                Me.Group_CfgPrinter.Visible = False
                Me.Group_CfgEtiquetadora.Visible = False
                Me.ToolStrip_Next.Enabled = False
                Me.ToolStrip_Prev.Enabled = False

                '# Impresion
                Me.DoWork()

            Case 3

                StrTitle = "Generación de etiquetas Terminada"
                PnlPrint.Visible = True
        End Select

        Me.LblTitle.Text = StrTitle
    End Sub

    Private Sub DoWork()
        'Leo el nº de etiquetas y Preconfiguro
        Dim i As Integer, n As Integer = 0, j As Integer
        For i = 0 To Me.Lst_Contable.Items.Count - 1 : n += Me.Lst_Contable.Items(i).SubItems(2).Text : Next
        Me.PBar_Generate.Value = 0
        Me.PBar_Generate.Maximum = n

        'Dim rstEmpresa As ADODB.Recordset = My.m_db.GetRst("SELECT img FROM app_empresa")

        Dim RstAux As ADODB.Recordset, RstTmp As ADODB.Recordset, rst As ADODB.Recordset

        'Genero la imagen para el caso de que sea blando
        Dim ms As New IO.MemoryStream, arrImage() As Byte
        Me.PicBarCode.Image.Save(ms, Me.PicBarCode.Image.RawFormat)
        arrImage = ms.GetBuffer
        ms.Close()

        For i = 0 To Me.intInitPrint - 1
            RstAux = My.m_db_temp.GetRst("Select * from tmp_etiquetas where id=-1")
            RstAux.AddNew()
            RstAux("id_articulo").Value = 0
            RstAux("name").Value = ""
            RstAux("pvp").Value = ""
            RstAux("test").Value = arrImage

            RstAux.Update()
        Next

        'Genero etiqueta por etiqueta
        For i = 0 To Me.Lst_Contable.Items.Count - 1
            'Cargo el registro temporal creado
            RstTmp = My.m_db_temp.GetRst("Select * from tmp_codbarras where id_line=" & Me.Lst_Contable.Items(i).Text)

            If RstTmp.RecordCount > 0 Then
                For j = 0 To Me.Lst_Contable.Items(i).SubItems(2).Text - 1
                    RstAux = My.m_db_temp.GetRst("Select * from tmp_etiquetas where id=-1")

                    RstAux.AddNew()
                    RstAux("id_articulo").Value = Me.Lst_Contable.Items(i).SubItems(1).Text
                    RstAux("test").Value = RstTmp("image").Value
                    If Me.Lst_Contable.Items(i).SubItems(4).Text = 1 Then       'Si tengo k meter la descripcion
                        RstAux("name").Value = Me.Lst_Contable.Items(i).SubItems(3).Text
                        RstAux("pvp").Value = Format(CDbl(Me.Lst_Contable.Items(i).SubItems(5).Text), "0.00") & " €"
                    Else
                        RstAux("name").Value = ""
                        RstAux("pvp").Value = ""
                    End If
                    RstAux("empresa").Value = My.m_opt.company_name '"" 'MyCfg.Str_NameComercial

                    RstAux("about").Value = ""

                    'Obtengo informacion extra del articulo
                    rst = My.m_db.GetRst("SELECT about FROM db_articulos WHERE id=" & Me.Lst_Contable.Items(i).SubItems(1).Text)
                    If rst.RecordCount > 0 Then
                        RstAux("about").Value = rst("about").Value


                        'Dim StrEan As String = "111111" & Format(Val(Me.Lst_Contable.Items(i).SubItems(1).Text), "000000")
                        'StrEan &= GetDCBarCodEAN13(StrEan)
                        'RstAux("cod_barras").Value = StrEan

                        RstAux("cod_barras").Value = Me.Lst_Contable.Items(i).SubItems(8).Text


                    End If
                    My.m_db.CloseRst(rst)

                    ' Copio el logotipo
                    'RstAux("image").Value = rstEmpresa("img").Value

                    'RstAux("image").Value = CType(rstEmpresa("img").Value, Byte())
                    ''Preparo los datos de la imagen
                    'Dim arrayImage() As Byte = CType(rstEmpresa("img").Value, Byte())
                    'RstAux("image").Value = CType(rstEmpresa("img").Value, Byte())
                    'Dim ms1 As New IO.MemoryStream(arrayImage)
                    'If Not ms1.Length = 0 Then
                    '    'Return Drawing.Image.FromStream(ms)

                    'End If

                    ''Devuelvo la imagen


                    RstAux.Update()

                    Me.PBar_Generate.Value += 1
                    Me.Refresh()
                Next
            End If

            My.m_db_temp.CloseRst(RstTmp)
        Next
        Me.PBar_Generate.Value = Me.PBar_Generate.Maximum





        intPaso += 1
        Cfg_Change()

        If Me.ChkPrintDirect.Checked Then
            Dim RptAux As New crtEtiquetas
            'RptAux.RecordSelectionFormula = "{tmp_etiquetas.id_articulo}=" & Me.IdRef
            RptAux.PrintOptions.PrinterName = Me.CbPrint.Text
            RptAux.PrintToPrinter(1, False, 0, 0)
        Else
            Dim FrmAux As New frmPreviewReport
            'FrmAux.swValidateOnDB = False
            FrmAux.StrName = "ETIQUETAS"
            Select Case Me.CbTipoImpresiones.SelectedIndex
                Case 0       'Papel de Etiquetas
                    Select Case Me.CbTipoEtiquta.SelectedIndex
                        Case 0  '44 (4x11)
                            FrmAux.RptPrint = New crtEtiquetas_4x11
                        Case 1  '40 (4x10)
                            FrmAux.RptPrint = New crtEtiquetas_4x10
                        Case 2  '24 (3x8)
                            FrmAux.RptPrint = New crtEtiquetas_3x8

                        Case 3  '40 (4x10) - Decorativas
                            FrmAux.RptPrint = New crtEtiquetas_4x10_Decorativa

                        Case 4  '24 (3x8) - Decorativas
                            FrmAux.RptPrint = New crtEtiquetas_3x8_Decorativa


                        Case 5  '24 (3x8) - Ingredientes
                            FrmAux.RptPrint = New crtEtiquetas_3x8_Ingredientes


                    End Select

                    'FrmAux.defaultPrinter = Me.CbPrint.Text

                Case 1      'Etiquetadora
                    Select Case Me.CbTamanoEtiqueta.SelectedIndex
                        Case 0  '(40x24)
                            FrmAux.RptPrint = New crtEtiquetadora_40x24
                        Case 1  '(49x38)
                            FrmAux.RptPrint = New crtEtiquetadora_49x38
                        Case 2  '(62x29)
                            FrmAux.RptPrint = New crtEtiquetadora_62x29

                        Case 3  '(50x240)
                            FrmAux.RptPrint = New crtEtiquetadora_50x240_horizontal

                    End Select

                    'FrmAux.defaultPrinter = Me.CbPrint_Etiquetadora.Text
            End Select

            FrmAux.StrSQL = ""
            FrmAux.Show()
        End If

        'Dim RptAux As New Crystal_Etiquetas
        ''RptAux.RecordSelectionFormula = "{tmp_etiquetas.id_articulo}=" & Me.IdRef
        'RptAux.PrintOptions.PrinterName = Me.CbPrint.Text
        'RptAux.PrintToPrinter(1, False, 0, 0)
    End Sub
#End Region

#Region "Impresoras"
    'Cargo en los combos las dos etiquetas
    Private Sub LoadPrinters()
        Dim i As Integer, StrAux As String = ""
        Dim srcPrint As New System.Drawing.Printing.PrinterSettings
        Me.CbPrint.Items.Clear()
        Me.CbPrint_Etiquetadora.Items.Clear()

        For i = 0 To Printing.PrinterSettings.InstalledPrinters.Count - 1
            StrAux = Printing.PrinterSettings.InstalledPrinters(i)
            Me.CbPrint.Items.Add(StrAux)
            Me.CbPrint_Etiquetadora.Items.Add(StrAux)

            'Selecciono la impresora por defecto
            If StrAux = My.m_app.GetValue("printerlabel", "") Then
                Me.CbPrint.SelectedIndex = Me.CbPrint.Items.Count - 1
                Me.CbPrint_Etiquetadora.SelectedIndex = Me.CbPrint_Etiquetadora.Items.Count - 1
            End If
        Next

        'Sino hay ninguna impresora seleccionada ponga la de por defecto
        If Me.CbPrint.SelectedIndex = -1 Then
            For i = 0 To Me.CbPrint.Items.Count - 1
                If srcPrint.PrinterName = Printing.PrinterSettings.InstalledPrinters(i) Then
                    Me.CbPrint.SelectedIndex = Me.CbPrint.Items.Count - 1
                    Me.CbPrint_Etiquetadora.SelectedIndex = Me.CbPrint_Etiquetadora.Items.Count - 1

                    Exit For
                End If
            Next
        End If
    End Sub
#End Region




    'Private Sub LblTitle_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LblTitle.Click
    '    Dim RstAux As ADODB.Recordset = My.Application.m_Db.GetRst("Select id from articulos order by id asc")
    '    While Not RstAux.EOF
    '        FrmEtiquetas_Lines.idRef = RstAux("id").Value
    '        FrmEtiquetas_Lines.ShowDialog(Me)
    '        RstAux.MoveNext()
    '    End While
    'End Sub

#Region "Manejo del tipo de Papel"


    Private Sub ConfigureEtiquetas()
        Dim Ancho As Integer = 0, Alto As Integer = 0, i As Integer, aux_x As Integer = 0, aux_y As Integer = 0, aux As Integer

        Select Case Me.CbTipoEtiquta.SelectedIndex
            Case 0      '4x11
                Ancho = 4
                Alto = 11

            Case 1      '4x10
                Ancho = 4
                Alto = 10

            Case 2      '3x8
                Ancho = 3
                Alto = 8

            Case 3      '4x10 - Decorativas
                Ancho = 4
                Alto = 10

            Case 4      '3x8 - Decorativas
                Ancho = 3
                Alto = 8

            Case 5      '3x8 - Ingredientes
                Ancho = 3
                Alto = 8
        End Select

        Dim AuxSize As New Size(((Me.PnlEtiquetas.Width - 20) / Ancho), ((Me.PnlEtiquetas.Height - 20) / Alto))

        'Limpio los botones
        aux = Me.PnlEtiquetas.Controls.Count
        For i = aux To 1 Step -1
            Me.PnlEtiquetas.Controls(i - 1).Dispose()
        Next
        intInitPrint = 0

        'Creo los botones
        For i = 0 To (Ancho * Alto) - 1
            Dim RbtAux As RadioButton
            RbtAux = New RadioButton
            If i = 0 Then
                RbtAux.BackColor = Color.Black
                RbtAux.Checked = True
            End If

            RbtAux.TabIndex = i
            RbtAux.Appearance = Appearance.Button
            RbtAux.Cursor = Cursors.Hand
            RbtAux.FlatStyle = FlatStyle.Flat
            RbtAux.Size = AuxSize 'New Size(112, 27)

            'RbtAux = Me.RbtEtiqueta     'Clono propiedades



            RbtAux.Text = i + 1
            RbtAux.Top = 10 + (RbtAux.Height * aux_y)
            RbtAux.Left = 10 + (RbtAux.Width * aux_x)

            Me.PnlEtiquetas.Controls.Add(RbtAux)

            aux_x += 1
            If aux_x >= Ancho Then aux_x = 0 : aux_y += 1


            AddHandler RbtAux.CheckedChanged, AddressOf Me.Etiqueta_CheckedChanged
        Next
    End Sub

    Private Sub CbTipoEtiquta_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CbTipoEtiquta.SelectedIndexChanged
        Me.ConfigureEtiquetas()
    End Sub

    Private Sub Etiqueta_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'If CType(sender, RadioButton).Name.Length = 0 Then Exit Sub
        If CType(sender, RadioButton).Checked Then intInitPrint = CType(sender, RadioButton).TabIndex

        CType(sender, RadioButton).BackColor = IIf(CType(sender, RadioButton).Checked, Color.Black, Color.White)
    End Sub
#End Region

    Private Sub ToolStripButton_Help_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton_Help.Click
        Dim str As String = "pg_Otros_Modulos_Etiquetas"
        'Muestro la ayuda relacionada al formulario abierto
        Help.ShowHelp(Me, "ayudaPG.chm", HelpNavigator.Topic, str & ".htm")
    End Sub

    Private Sub btPreview_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btPreview.Click
        Dim FrmAux As New frmPreviewReport
        'FrmAux.swValidateOnDB = False
        FrmAux.StrName = "ETIQUETAS"
        Select Case Me.CbTipoImpresiones.SelectedIndex
            Case 0       'Papel de Etiquetas
                Select Case Me.CbTipoEtiquta.SelectedIndex
                    Case 0  '44 (4x11)
                        FrmAux.RptPrint = New crtEtiquetas_4x11
                    Case 1  '40 (4x10)
                        FrmAux.RptPrint = New crtEtiquetas_4x10
                    Case 2  '24 (3x8)
                        FrmAux.RptPrint = New crtEtiquetas_3x8

                    Case 3  '40 (4x10) - Decorativas
                        FrmAux.RptPrint = New crtEtiquetas_4x10_Decorativa
                    Case 4  '24 (3x8) - Decorativas
                        FrmAux.RptPrint = New crtEtiquetas_3x8_Decorativa

                End Select

                'FrmAux.defaultPrinter = Me.CbPrint.Text

            Case 1      'Etiquetadora
                Select Case Me.CbTamanoEtiqueta.SelectedIndex
                    Case 0  '(40x24)
                        FrmAux.RptPrint = New crtEtiquetadora_40x24
                    Case 1  '(49x38)
                        FrmAux.RptPrint = New crtEtiquetadora_49x38
                    Case 2  '(62x29)
                        FrmAux.RptPrint = New crtEtiquetadora_62x29

                    Case 3  '(50x240)
                        FrmAux.RptPrint = New crtEtiquetadora_50x240_horizontal

                End Select

                'FrmAux.defaultPrinter = Me.CbPrint_Etiquetadora.Text
        End Select

        FrmAux.StrSQL = ""
        FrmAux.Show()
    End Sub
End Class