Imports System.IO
Public Class frmEstanco_Marca
    Public Id_Ref As Integer = 0

    Private m_Data As gDevelop.Lite.m_dataform

#Region "Eventos Principales"
    Private Sub frmEstanco_Marca_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        '####### Cargo las categorias de Imagen
        Dim rst As ADODB.Recordset = My.m_db.GetRst("SELECT * FROM estanco_tipos ORDER BY name ASC")

        Me.CbImg_Cat.Items.Clear()
        While Not rst.EOF
            Me.CbImg_Cat.Items.Add(rst("name").Value & Space(100) & rst("id").Value)
            rst.MoveNext()
        End While

        My.m_db.CloseRst(rst)


        '####### Cargo la configuración de las lineas de facturas de proveedores
        Me.m_Data = New gDevelop.Lite.m_dataform(My.m_db)
        Me.m_Data.DbTable = "estanco_marcas"
        Me.m_Data.ConfigureDataForm(Me.Controls)

        If Me.Id_Ref = 0 Then           'Caso del nuevo
            Me.m_Data.data_NewField()

            Me.CbImg_Cat.SelectedIndex = -1

            Me.chkActivo.Checked = True

            Me.BtDel.Visible = False

        Else      'Caso de la edicion
            Me.m_Data.data_EditField(Me.Id_Ref)

            'Establezco la categoria que es
            Dim i As Integer
            For i = 0 To Me.CbImg_Cat.Items.Count - 1
                If Me.txtIdTipo.Text = Me.CbImg_Cat.Items(i).Substring(100).Trim Then Me.CbImg_Cat.SelectedIndex = i
            Next

        End If

        Me.AddHandlers()

        'Me.BtDel.Enabled = (Not Me.ChkNotDelete.Checked)
    End Sub
#End Region

#Region "Eventos Auxiliares"
    Private Sub CbImg_Cat_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CbImg_Cat.SelectedIndexChanged
        Me.txtIdTipo.Text = Me.CbImg_Cat.Text.Substring(100).Trim
    End Sub

    Private Sub frmEstanco_Marca_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Me.m_Data.Dispose()
        m_Data = Nothing
    End Sub

#End Region

#Region "Manejadores"
    Private Sub Buttons_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtOk.Click, BtCancell.Click, BtDel.Click
        Select Case True
            Case sender Is Me.BtDel
                If MsgBox("¿Esta seguro de que desea eliminar la marca seleccionada?", MsgBoxStyle.OkCancel + MsgBoxStyle.Question, My.APP_NAME) <> MsgBoxResult.Ok Then Exit Select
                My.m_db.Execute("DELETE FROM estanco_marcas WHERE id=" & Me.Id_Ref)
                Me.DialogResult = Windows.Forms.DialogResult.OK

            Case sender Is Me.BtOk
                'If Me.TxtFactura.TextLength = 0 Then
                '    My.m_msg.MessageError(Me, "Imposible guardar, no se ha especificado un número de factura correcto.")
                '    Exit Sub
                'End If
                'Me.CalcularTotales()

                Me.m_Data.data_SaveField()
                Me.DialogResult = Windows.Forms.DialogResult.OK


            Case sender Is Me.BtCancell
                Me.Close()
        End Select
    End Sub
#End Region

#Region "Handlers"
    Private Sub AddHandlers()
        AddHandler Me.txtPrecio.KeyPress, AddressOf gDevelop.Lite.m_OverridesEvents.TxtValidaEuro_KeyPress
        AddHandler Me.txtPrecioRecargo.KeyPress, AddressOf gDevelop.Lite.m_OverridesEvents.TxtValidaEuro_KeyPress


        AddHandler Me.txtUD.KeyPress, AddressOf gDevelop.Lite.m_OverridesEvents.TxtValidaNumeric_KeyPress
        AddHandler Me.txtUD_x10.KeyPress, AddressOf gDevelop.Lite.m_OverridesEvents.TxtValidaNumeric_KeyPress

        AddHandler Me.txtUD_min.KeyPress, AddressOf gDevelop.Lite.m_OverridesEvents.TxtValidaNumeric_KeyPress
        AddHandler Me.txtUD_opt.KeyPress, AddressOf gDevelop.Lite.m_OverridesEvents.TxtValidaNumeric_KeyPress
    End Sub
#End Region

#Region "Añadir Imagenes"
    Private Sub BtImg_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtImg.Click
        Dim dlg As New OpenFileDialog()

        dlg.Filter = "Archivos de imagen jpg (*.jpg)|*.jpg"
        dlg.FilterIndex = 0
        dlg.RestoreDirectory = False

        If dlg.ShowDialog() <> Windows.Forms.DialogResult.OK Then Exit Sub

        Me.BtImg.Image = Nothing
        Me.BtImg.Image = Image.FromFile(gDevelop.Lite.m_Functions.resize_image(dlg.FileName, 110))

        'Me.TxtName.Text = My.Computer.FileSystem.GetFileInfo(dlg.FileName).Name.Replace(".jpg", "")


        'Me.PicImg.Image = Me.BtSelectImg.Image

        'Me.BtSelectImg.Text = ""
    End Sub
#End Region


    Private Sub LblName_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LblName.Click
        'Dim rst As ADODB.Recordset = My.m_db.GetRst("SELECT * FROM app_imgs WHERE id=-1")
        'For Each fl As String In IO.Directory.GetFiles("C:\temp\Logos")
        '    'MsgBox("File: " & fl)
        '    rst.AddNew()
        '    rst("id_categoria").Value = 1
        '    rst("name").Value = IO.Path.GetFileNameWithoutExtension(fl).ToUpper
        '    rst("img").Value = My.m_db.data_SaveImgToField(Image.FromFile(gDevelop.Lite.m_Functions.resize_image(fl, 110)))
        '    rst("fh_alta").Value = Now
        '    rst.Update()
        'Next


    End Sub

    Private Sub BtCodBarras_Add_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtCodBarras_Add.Click
        frmGetCodBarras.ShowDialog(Me)
        If frmGetCodBarras.DialogResult <> Windows.Forms.DialogResult.OK Then frmGetCodBarras.Dispose() : Exit Sub

        Me.txtCodBarras.Text = frmGetCodBarras.StrCode
        frmGetCodBarras.Dispose()
    End Sub


    Private Sub BtCodBarrasx10_Add_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtCodBarrasx10_Add.Click
        frmGetCodBarras.ShowDialog(Me)
        If frmGetCodBarras.DialogResult <> Windows.Forms.DialogResult.OK Then frmGetCodBarras.Dispose() : Exit Sub

        Me.txtCodBarras_x10.Text = frmGetCodBarras.StrCode
        frmGetCodBarras.Dispose()
    End Sub
End Class