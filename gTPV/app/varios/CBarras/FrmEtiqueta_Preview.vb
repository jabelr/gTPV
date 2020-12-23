Public Class FrmEtiqueta_Preview
    Public idRef As Integer = 0
    Public arrImage() As Byte

#Region "Eventos Auxiliares"
    Private Sub ToolStrip_Save_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStrip_Save.Click
        'Me.DialogResult = Windows.Forms.DialogResult.OK
        'Limpio y agrego la linea temporal con la imagen
        Dim RstImg As ADODB.Recordset

        My.m_db_temp.Execute("DELETE FROM tmp_codbarras")
        RstImg = My.m_db_temp.GetRst("Select * from tmp_codbarras where id=-1")

        RstImg.AddNew()
        RstImg.Fields("id_line").Value = 1
        RstImg.Fields("image").Value = arrImage
        'RstImg.Fields("image2").Value = arrImage
        RstImg.Fields("line1").Value = ""
        RstImg.Fields("line2").Value = ""
        RstImg.Update()

        My.m_db.CloseRst(RstImg)

        Dim FrmAux As New frmPreviewReport
        FrmAux.StrName = "ETIQUETAS"
        FrmAux.RptPrint = New crtEtiquetas_Tipo2
        FrmAux.StrSQL = ""
        FrmAux.Show()
    End Sub

    Private Sub FrmEtiquetas_Lines_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated

    End Sub
    Private Sub FrmEtiquetas_Lines_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        LblTitle.Text = IIf(idRef = 0, "Agregar etiqueta", "Editar Etiqueta")
        Num_Etiquetas.Select()
    End Sub

    Private Sub ToolStrip_Cancell_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStrip_Cancell.Click
        Me.Close()
    End Sub
#End Region

#Region "Etiquetas"
    Private Sub GenerateEtiqueta()
        On Error GoTo ErrHandler
        'Creo la imagen con el codigo de barras 
        Dim StrFile As String = My.Computer.FileSystem.SpecialDirectories.Temp & "\barcode_tmp.bmp"
        'Dim StrFile As String = "c:\naturabar_tmp.bmp"

        'Me.PicBarCode.Visible = True
        Me.PicBarCode.BackColor = Color.White
        Me.PicBarCode.Refresh()
        'El ascii de la 'a' + 'r' + el id + digito de control
        Dim StrEan As String = "111111"
        StrEan &= Format(Val(Me.idRef), "000000")

        StrEan = ""
        StrEan &= GetDCBarCodEAN13(StrEan)
        PrintEANBarCode(StrEan, Me.PicBarCode, 10, 10, Me.PicBarCode.Width - 10, Me.PicBarCode.Height - 10)
        Dim bmp = CType(copyRect(Me.PicBarCode, New RectangleF(0, 0, Me.PicBarCode.Width, Me.PicBarCode.Height)), Bitmap)

        If My.Computer.FileSystem.FileExists(StrFile) Then My.Computer.FileSystem.DeleteFile(StrFile)

        bmp.Save(StrFile)

        Me.PicBarCode.Load(StrFile)

        Dim ms As New IO.MemoryStream
        Me.PicBarCode.Image.Save(ms, Me.PicBarCode.Image.RawFormat)
        'Dim arrImage() As Byte = ms.GetBuffer
        arrImage = ms.GetBuffer
        ms.Close()




        Exit Sub
ErrHandler:
        MsgBox("Error en el código EAN13. Compruebe que el código es correcto.", MsgBoxStyle.Critical)
        Me.Close()
    End Sub
#End Region

    Private Sub Num_Etiquetas_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Num_Etiquetas.KeyPress
        If e.KeyChar = Chr(13) Then
            SendKeys.Send("{TAB}")
            e.Handled = True
        End If
        If e.KeyChar = Chr(27) Then     'El escape
            Me.Close()
        End If
    End Sub

    Private Sub ChkPrint_Name_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles ChkPrint_Name.KeyPress
        If e.KeyChar = Chr(13) Then
            e.Handled = True
            Me.DialogResult = Windows.Forms.DialogResult.OK
        End If
    End Sub

    Private Sub Num_Etiquetas_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Num_Etiquetas.ValueChanged

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Me.m_GenerateEtiqueta()
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        MsgBox(TextBox2.Text & " >> " & GetDCBarCodEAN13(TextBox2.Text))
    End Sub



    Private Sub m_GenerateEtiqueta()
        On Error GoTo ErrHandler
        'Creo la imagen con el codigo de barras 
        Dim StrFile As String = "c:\barcode_tmp.bmp"
        'Dim StrFile As String = "c:\naturabar_tmp.bmp"

        'Me.PicBarCode.Visible = True
        Me.PicBarCode.BackColor = Color.White
        Me.PicBarCode.Refresh()
        'El ascii de la 'a' + 'r' + el id + digito de control
        Dim StrEan As String = ""
        'StrEan &= Format(Val(Me.idRef), "000000")

        StrEan = Me.TextBox1.Text
        StrEan &= GetDCBarCodEAN13(StrEan)
        PrintEANBarCode(StrEan, Me.PicBarCode)
        Dim bmp = CType(copyRect(Me.PicBarCode, New RectangleF(0, 0, Me.PicBarCode.Width, Me.PicBarCode.Height)), Bitmap)

        If My.Computer.FileSystem.FileExists(StrFile) Then My.Computer.FileSystem.DeleteFile(StrFile)

        bmp.Save(StrFile)

        Me.PicBarCode.Load(StrFile)

        Dim ms As New IO.MemoryStream
        Me.PicBarCode.Image.Save(ms, Me.PicBarCode.Image.RawFormat)
        'Dim arrImage() As Byte = ms.GetBuffer
        arrImage = ms.GetBuffer
        ms.Close()


        Exit Sub
ErrHandler:
        MsgBox("Error en el código EAN13. Compruebe que el código es correcto.", MsgBoxStyle.Critical)
        Me.Close()
    End Sub
End Class