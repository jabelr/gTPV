Public Class FrmEtiquetas_Lines
    Public idRef As Integer = 0
    Public arrImage() As Byte

    Public Ean As String = ""

    'Cuando tiene talla genero un codigo de etiqueta diferente
    Public swColor As Boolean = False
    Public strTalla As String = ""

#Region "Eventos Auxiliares"
    Private Sub ToolStrip_Save_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStrip_Save.Click
        Me.DialogResult = Windows.Forms.DialogResult.OK
    End Sub

    Private Sub FrmEtiquetas_Lines_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        Me.GenerateEtiqueta()
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
        Dim StrFile As String = My.Computer.FileSystem.SpecialDirectories.Temp & "\pymegest_tmp.bmp"

        'Me.PicBarCode.Visible = True
        Me.PicBarCode.BackColor = Color.White
        Me.PicBarCode.Refresh()
        'El ascii de la 'a' + 'r' + el id + digito de control
        Dim StrEan As String = ""

        If Not Me.swColor Then
            StrEan = "111111"
        Else
            StrEan = "4444" & Me.strTalla
        End If

        StrEan &= Format(Val(Me.idRef), "000000")
        StrEan &= GetDCBarCodEAN13(StrEan)

        Me.Ean = StrEan

        'PrintEANBarCode(StrEan, Me.PicBarCode, 10, 10, Me.PicBarCode.Width - 10, Me.PicBarCode.Height - 10)
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
End Class