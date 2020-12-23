Public Class frm_AppIsMinimized

#Region "Eventos Principales"
    Private Sub frm_AppIsMinimized_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Text = My.APP_NAME

        'Establezco posicion de inicio
        Me.Left = Screen.PrimaryScreen.WorkingArea.Width - Me.Width - My.APP_NUMBER
        Me.Top = My.APP_NUMBER * 5
    End Sub
#End Region

#Region "Eventos Auxiliares"
    Private Sub frm_AppIsMinimized_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.DoubleClick
        My.Forms.frmMain.Activate()
        My.Forms.frmMain.WindowState = FormWindowState.Maximized

        If Not IsNothing(m_Shell) Then
            My.Forms.m_Shell.Activate()
            My.Forms.m_Shell.WindowState = FormWindowState.Maximized
        End If
    End Sub
#End Region

    Private Sub frm_AppIsMinimized_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Me.MouseDown
        If Not e.Button = Windows.Forms.MouseButtons.Left Then Exit Sub
    End Sub
End Class