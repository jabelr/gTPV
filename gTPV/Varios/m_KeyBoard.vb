Public Class m_KeyBoard
    Public Event KeyBoard_Press(ByVal key As String)

    Private Sub Buttons_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Bt_Z.Click, Bt_Y.Click, Bt_X.Click, Bt_W.Click, Bt_V.Click, Bt_U.Click, Bt_T.Click, Bt_S.Click, Bt_R.Click, Bt_Q.Click, Bt_P.Click, Bt_O.Click, Bt_Ñ.Click, Bt_N.Click, Bt_M.Click, Bt_L.Click, Bt_K.Click, Bt_J.Click, Bt_I.Click, Bt_H.Click, Bt_G.Click, Bt_F.Click, Bt_E.Click, Bt_D.Click, Bt_C.Click, Bt_B.Click, Bt_A.Click, Bt_DECIMAL.Click, Bt_9.Click, Bt_8.Click, Bt_7.Click, Bt_6.Click, Bt_5.Click, Bt_4.Click, Bt_3.Click, Bt_2.Click, Bt_1.Click, Bt_0.Click
        RaiseEvent KeyBoard_Press(CType(sender, Button).Text)
    End Sub

    Private Sub Bt_SPACE_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Bt_SPACE.Click
        RaiseEvent KeyBoard_Press("SPACE")
    End Sub

    Private Sub Bt_Back_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Bt_Back.Click
        RaiseEvent KeyBoard_Press("DEL")
    End Sub

    Private Sub Bt_OK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Bt_OK.Click
        RaiseEvent KeyBoard_Press("OK")
    End Sub

    Private Sub m_KeyBoard_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        Me.PnlButtons.Visible = True
    End Sub

    Private Sub m_KeyBoard_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then Me.Close()
    End Sub
End Class