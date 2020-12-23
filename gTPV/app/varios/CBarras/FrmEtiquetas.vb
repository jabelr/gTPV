Imports CrystalDecisions.Shared
Imports CrystalDecisions.CrystalReports.Engine
Public Class FrmEtiquetas
    Public IdRef As Integer = 0
    Public StrName As String = ""
    Public DblPvp As Double = 0

    Private arrImage() As Byte

#Region "Impresoras"
    Private Sub LoadPrinters()
        Dim i As Integer, StrAux As String = ""
        Dim srcPrint As New System.Drawing.Printing.PrinterSettings

        For i = 0 To Printing.PrinterSettings.InstalledPrinters.Count - 1
            StrAux = Printing.PrinterSettings.InstalledPrinters(i)
            Me.CbPrint.Items.Add(StrAux)

            'Selecciono la impresora por defecto
            If StrAux = srcPrint.PrinterName Then Me.CbPrint.SelectedIndex = Me.CbPrint.Items.Count - 1
        Next
    End Sub
#End Region

#Region "Etiquetas"
    Private Sub GenerateEtiqueta()
        'Creo la imagen con el codigo de barras 
        Dim StrFile As String = My.Computer.FileSystem.SpecialDirectories.Temp & "\naturabar_tmp.bmp"
        'Dim StrFile As String = "c:\naturabar_tmp.bmp"

        'Me.PicBarCode.Visible = True
        Me.PicBarCode.BackColor = Color.White
        Me.PicBarCode.Refresh()
        'El ascii de la 'a' + 'r' + el id + digito de control
        Dim StrEan As String = "111111"
        StrEan &= Format(Val(Me.IdRef), "000000")
        StrEan &= GetDCBarCodEAN13(StrEan)
        PrintEANBarCode(StrEan, Me.PicBarCode, 10, 10, Me.PicBarCode.Width - 20, Me.PicBarCode.Height - 20)
        Dim bmp = CType(copyRect(Me.PicBarCode, New RectangleF(0, 0, Me.PicBarCode.Width, Me.PicBarCode.Height)), Bitmap)

        If My.Computer.FileSystem.FileExists(StrFile) Then My.Computer.FileSystem.DeleteFile(StrFile)

        bmp.Save(StrFile)

        Me.PicBarCode.Load(StrFile)

        Dim ms As New IO.MemoryStream
        Me.PicBarCode.Image.Save(ms, Me.PicBarCode.Image.RawFormat)
        'Dim arrImage() As Byte = ms.GetBuffer
        arrImage = ms.GetBuffer
        ms.Close()

        My.m_db_temp.GetRst("DELETE FROM tmp_etiquetas where id_articulo=" & Me.IdRef)

    End Sub
#End Region

#Region "Eventos Auxiliares"
    Private Sub BtCancell_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtCancell.Click
        Me.Close()
    End Sub

    Private Sub BtOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtOk.Click
        'Agrego los registros oportunos
        Dim i As Integer = 0
        Dim RstAux As ADODB.Recordset = My.m_db_temp.GetRst("Select * from tmp_etiquetas where id_articulo=" & Me.IdRef)

        For i = 1 To Me.CbPrint_N.Text
            RstAux.AddNew()
            RstAux.Fields("id_articulo").Value = Me.IdRef
            RstAux.Fields("name").Value = IIf(Me.ChkPrint_Name.Checked, Me.StrName, "")
            RstAux.Fields("pvp").Value = IIf(Me.ChkPrint_Name.Checked, Me.DblPvp & " €", "")
            RstAux.Fields("test").Value = arrImage
            RstAux.Update()
        Next



        'Dim idAux As Integer = RstAux("id").Value




        'Dim FrmAux As New FrmReport
        'FrmAux.StrName = "[ETIQUETAS]"
        'FrmAux.RptPrint = New Crystal_Etiquetas
        'FrmAux.StrSQL = "{tmp_etiquetas.id}=" & idAux

        'FrmAux.Show()

        Dim RptAux As New crtEtiquetas
        RptAux.RecordSelectionFormula = "{tmp_etiquetas.id_articulo}=" & Me.IdRef
        RptAux.PrintOptions.PrinterName = Me.CbPrint.Text
        RptAux.PrintToPrinter(1, False, 0, 0)


        Me.DialogResult = Windows.Forms.DialogResult.OK
    End Sub

    Private Sub FrmEtiquetas_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        Me.GenerateEtiqueta()
    End Sub

    Private Sub FrmEtiquetas_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.LoadPrinters()
        CbPrint_N.SelectedIndex = 0
    End Sub
#End Region
End Class