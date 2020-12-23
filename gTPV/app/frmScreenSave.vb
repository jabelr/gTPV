Public Class frmScreenSave

 

    Private Sub frmScreenSave_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then Me.Close()
    End Sub

    Private Sub frmScreenSave_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        With Me
            'Establezco información
            .Text = My.APP_NAME

            'Centro el body y establezco tamaños
            .pnlBody.Left = (Me.Width - Me.pnlBody.Width) / 2
            .pnlBody.Top = (Me.Height - Me.pnlBody.Height) / 2 + (IIf(My.m_opt.swNoteBook, Me.Height, 0))
            .pnlBody.Visible = True
            .Size = Screen.PrimaryScreen.WorkingArea.Size
        End With

        Me.lblName.Text = My.m_opt.company_name
        Me.lblNameFiscal.Text = My.m_opt.company_namefiscal

    End Sub

    Private Sub picLogo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles picLogo.Click
        Me.Close()
    End Sub

    Private Sub pnlBody_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles pnlBody.Click
        Me.Close()
    End Sub

    Private Sub frmScreenSave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Click
        Me.Close()
    End Sub

    Private Sub LblTotal_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LblTotal.Click
        Me.Close()
    End Sub

    Private Sub Buttons_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub LstLines_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub lblName_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblName.Click
        Me.Close()
    End Sub

    Private Sub lblNameFiscal_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblNameFiscal.Click
        Me.Close()
    End Sub
End Class