Imports CrystalDecisions.Shared
Imports CrystalDecisions.CrystalReports.Engine

Public Class frmPreviewReport
    Public RptPrint As ReportClass
    Public StrSQL As String

    Public StrName As String = ""
    Public StrSubName As String = ""

#Region "Eventos Principales"
    Private Sub frmDesign_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.Size = Screen.PrimaryScreen.WorkingArea.Size

        Me.PnlBody.Left = (Me.Width - Me.PnlBody.Width) / 2
        Me.PnlBody.Top = (Me.SplitContainer.Panel2.Height - Me.PnlBody.Height) / 2
        Me.PnlBody.Visible = True

        Me.Text &= " [ " & StrName & " ]"
        Me.LblName.Text = Me.StrName
        Me.LblNfoListado.Text = Me.StrSubName

        My.LoadPrinters(Me.CbPrinters)

        ' Filtro y muestro el listado
        RptPrint.RecordSelectionFormula = StrSQL
        Viewer.ReportSource = Me.RptPrint
    End Sub
#End Region

#Region "Manejadores"
    'Manejador Principal (Shell)
    Private Sub ShellApp(ByVal command As String)
        Dim cmd As String = command.ToUpper

        Select Case cmd
            Case "PRINT"
                Me.Viewer.PrintReport()

                'CType(Me.Viewer.ReportSource, ReportClass).PrintOptions.PrinterName = Me.CbPrinters.Text
                'CType(Me.Viewer.ReportSource, ReportClass).PrintToPrinter(1, False, 0, 0)

                'Dim RptAux As New Crystal_MenuReservas
                'RptAux.RecordSelectionFormula = StrSQL
                'RptAux.PrintOptions.PrinterName = Me.CbPrinters.Text
                'RptAux.PrintToPrinter(1, False, 0, 0)

            Case "CANCEL"
                Me.Close()

            Case "MINIMIZE"
                frm_AppIsMinimized.Show()

                Me.Owner.WindowState = FormWindowState.Minimized
                Me.WindowState = FormWindowState.Minimized

            Case "CLOSE"
                Me.Close()
            Case Else
                My.m_msg.MessageError(Me, "Comando de acción de " & cmd & "no controlada.")
        End Select
    End Sub
#End Region

#Region "Eventos Auxiliares"
    Private Sub Buttons_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtClose.Click, BtPrint.Click
        'Si no tiene establecido el tag mando un error
        If IsNothing(CType(sender, Button).Tag) OrElse CType(sender, Button).Tag.ToString.Length = 0 Then
            My.m_msg.MessageError(sender, "Tag de control de elemento no referenciado")
            Exit Sub
        End If

        ShellApp(CType(sender, Button).Tag.ToString)
    End Sub
#End Region

End Class