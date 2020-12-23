Public Class frmPaneldeVentas_Dto
    'Public Id_Ref As Integer = 0                'El id del usuario/empleado

    Private arr() As String
    Private arrIVA() As Double

    Dim i As Integer = 0

#Region "Eventos Principales"
    Private Sub frmPaneldeVentas_Dto_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
       
        AddHandler Me.TxtPVP.KeyPress, AddressOf gDevelop.lite.m_OverridesEvents.TxtValidaEuro_KeyPress
    End Sub
#End Region

#Region "Eventos Auxiliares"
    Private Sub Buttons_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtCancell.Click, BtOK.Click, BtClear.Click, BtUndo.Click
        Select Case True
            Case sender Is Me.BtUndo
                Me.TxtPVP.Text = Me.TxtPVP.Text.Substring(0, Me.TxtPVP.Text.Length - 1)
                Me.TxtPVP.Select()
                Me.TxtPVP.SelectionStart = Me.TxtPVP.TextLength

            Case sender Is Me.BtClear
                Me.TxtPVP.Text = ""

                'Case sender Is Me.btAdd
                '    If Not IsNumeric(Me.TxtPVP.Text) Then
                '        My.m_msg.MessageError(Me, "Importe incorrecto")
                '        Me.TxtPVP.Text = ""
                '        My.AsignarFoco(Me.TxtPVP)
                '        Exit Select
                '    End If

            Case sender Is Me.BtOK
                If Not IsNumeric(Me.TxtPVP.Text) Then
                    My.m_msg.MessageError(Me, "Descuento incorrecto")
                    Me.TxtPVP.Text = ""
                    My.AsignarFoco(Me.TxtPVP)
                    Exit Select
                End If

                If CDbl(Me.TxtPVP.Text) >= 100 Then
                    My.m_msg.MessageError(Me, "Descuento incorrecto")
                    Me.TxtPVP.Text = ""
                    My.AsignarFoco(Me.TxtPVP)
                    Exit Select
                End If

                Me.DialogResult = Windows.Forms.DialogResult.OK

            Case sender Is Me.BtCancell
                Me.Close()
        End Select
    End Sub

    Private Sub frmPaneldeVentas_Dto_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        Me.PnlGaleria.Visible = True
        My.AsignarFoco(Me.TxtPVP)
    End Sub


    Private Sub TxtPass_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtPVP.KeyPress
        If Asc(e.KeyChar) = 13 Then Buttons_Click(Me.BtOK, e)
    End Sub

    Private Sub TxtPass_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtPVP.TextChanged
        Dim sw As Boolean = (Val(Me.TxtPVP.TextLength) > 0)
        Me.BtOK.Enabled = sw
        Me.BtClear.Enabled = sw
        Me.BtUndo.Enabled = sw
    End Sub

    Private Sub Bt_Num_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Bt_9.Click, Bt_8.Click, Bt_7.Click, Bt_6.Click, Bt_5.Click, Bt_4.Click, Bt_3.Click, Bt_2.Click, Bt_1.Click, Bt_0.Click, BtDecimal.Click
        'If sender Is Me.BtDecimal Then
        '    If InStr(Me.TxtPVP.Text, ",") > 0 Then Exit Sub
        '    If Me.TxtPVP.TextLength = 0 Then Me.TxtPVP.Text = "0"
        'End If

        'Me.TxtPVP.Text &= CType(sender, Button).Text
        'Me.TxtPVP.Select()
        'Me.TxtPVP.SelectionStart = Me.TxtPVP.TextLength
    End Sub

    Private Sub Bt_MouseDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Bt_9.MouseDown, Bt_8.MouseDown, Bt_7.MouseDown, Bt_6.MouseDown, Bt_5.MouseDown, Bt_4.MouseDown, Bt_3.MouseDown, Bt_2.MouseDown, Bt_1.MouseDown, Bt_0.MouseDown, BtDecimal.MouseDown, btMasMenos.MouseDown
        If Me.TxtPVP.SelectionLength = Me.TxtPVP.TextLength Then Me.TxtPVP.Text = ""
        If sender Is Me.BtDecimal Then
            If InStr(Me.TxtPVP.Text, ",") > 0 Then Exit Sub
            If Me.TxtPVP.TextLength = 0 Then Me.TxtPVP.Text = "0"
        End If

        'Cambio el signo
        If sender Is Me.btMasMenos Then
            If IsNumeric(Me.TxtPVP.Text) Then
                Me.TxtPVP.Text *= -1
                My.AsignarFoco(Me.TxtPVP)
            End If
            Exit Sub
        End If

        Me.TxtPVP.Text &= CType(sender, Button).Text
        Me.TxtPVP.Select()
        Me.TxtPVP.SelectionStart = Me.TxtPVP.TextLength
    End Sub


    Private Sub frmPaneldeVentas_Dto_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
        If Asc(e.KeyChar) = 13 Then Buttons_Click(Me.BtOK, e)
    End Sub

#End Region

End Class