Public Class frmRegisterApp

#Region "Eventos Principales"
    Private Sub frmDemo_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Class_UnLock = New gDevelop.ClassRegisterApp

        'Me.TxtLock.Text = Me.Class_UnLock.StrLockCode
        'If Me.Class_UnLock.SwDemo Then
        '    Dim IntDias As Integer = Me.Class_UnLock.GetDaysOnRegister
        '    Dim StrAux As String = IIf(Not Me.Class_UnLock.SwDemoExpires, "[Quedan " & IntDias & " días para que caduque la clave]", "[Clave de aplicación caducada]")
        '    Me.Text = "Versión de evaulación de " & My.Application.Info.ProductName & " - " & StrAux
        '    Me.BtUnLock.Visible = True

        '    Me.BtOk.Text = IIf(Not Me.Class_UnLock.SwDemoExpires, "Continuar", "Terminar")
        'Else
        '    Me.BtOk.Text = "Aceptar"
        '    Me.BtUnLock.Visible = False
        '    Me.Text = "Información del registro de " & My.Application.Info.ProductName
        '    Me.TxtUnLock.Text = Class_UnLock.StrUnLockCode
        '    Me.TxtUnLock.ReadOnly = True
        'End If

        Me.Text = "Registro de la aplicación """ & My.APP_NAME & """"

        Me.TxtLock.Text = My.m_app.GetAppcode
        My.AsignarFoco(Me.TxtUnLock)

        If My.m_app.IsRegister Then
            Me.TxtUnLock.Visible = False
            Me.lblCode.Visible = False

            Me.BtUnLock.Enabled = True
        End If
    End Sub

    'Registro la aplicación
    Private Sub BtUnLock_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtUnLock.Click

        If My.m_app.IsRegister Then
            MsgBox("Gracias por haber registrado su copia de la aplicación.", MsgBoxStyle.Information)
            Exit Sub
        End If

        If MsgBox("¿Esta seguro de ha establecido los datos de facturación y cabecera de ticket con datos correctos?" & vbCrLf & "Una vez registrado NO se podrán cambiar estos valores sin intervención del distribuidor.", MsgBoxStyle.Question + MsgBoxStyle.OkCancel) <> MsgBoxResult.Ok Then Exit Sub

        If My.m_app.IsRegister Then
            MsgBox("Gracias por confiar en nosotros.", MsgBoxStyle.Information)
            Exit Sub
        End If
        If Not My.m_app.RegisterApp(Me.TxtUnLock.Text) Then
            My.m_msg.MessageError(Me, "Código de aplicación no valido.")
            My.AsignarFoco(Me.TxtUnLock)
            Exit Sub
        End If

        Dim m_crypt As New gDevelop.Lite.Crypto_Rijndael
        My.m_app.SetValue("crypt_name") = m_crypt.Crypt(My.m_opt.company_name)
        My.m_app.SetValue("crypt_fiscal") = m_crypt.Crypt(My.m_opt.company_namefiscal)
        My.m_app.SetValue("crypt_cif") = m_crypt.Crypt(My.m_opt.company_cif)
        My.m_app.SetValue("crypt_cab0") = m_crypt.Crypt(My.MyHardware.StrCab(1))
        My.m_app.SetValue("crypt_cab1") = m_crypt.Crypt(My.MyHardware.StrCab(2))

        MsgBox("Gracias por registrar su aplicación de """ & My.APP_NAME & """!!!!!", MsgBoxStyle.Information, My.APP_NAME)
        Me.DialogResult = Windows.Forms.DialogResult.OK
        'If Me.Class_UnLock.RegisterApp(Me.TxtUnLock.Text) Then
        '    MsgBox("Thank'you!!", MsgBoxStyle.Information)
        '    Me.DialogResult = Windows.Forms.DialogResult.OK
        'Else
        '    Me.TxtUnLock.SelectAll()
        '    Me.TxtUnLock.Select()
        '    MsgBox("Código erroneo", MsgBoxStyle.Critical)
        'End If
    End Sub
#End Region

#Region "Eventos Auxiliares"
    Private Sub BtOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtOk.Click
        Me.Close()
    End Sub

    Private Sub TxtLock_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtLock.Click
        My.AsignarFoco(Me.TxtLock)
    End Sub

    Private Sub TxtLock_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtLock.GotFocus
        My.AsignarFoco(Me.TxtLock)
    End Sub

    Private Sub TxtLock_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtLock.KeyPress
        If e.KeyChar = Chr(13) Then My.AsignarFoco(Me.TxtUnLock) : e.Handled = True
    End Sub

    Private Sub TxtUnLock_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtUnLock.DoubleClick
        My.AsignarFoco(Me.TxtUnLock)
    End Sub

    Private Sub TxtUnLock_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtUnLock.GotFocus
        My.AsignarFoco(Me.TxtUnLock)
    End Sub

    Private Sub TxtUnLock_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtUnLock.TextChanged
        Me.BtUnLock.Enabled = (Me.TxtUnLock.TextLength > 0)
    End Sub
#End Region



    Private Sub PicImg_gDev_MouseDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles PicImg_gDev.MouseDoubleClick
        'If e.Button <> Windows.Forms.MouseButtons.Right Then Exit Sub
        If MsgBox("¿Deseas usar el redemtion time?", MsgBoxStyle.Question + MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
            My.m_app.remove_Value("key")
            My.m_app.remove_Value("key_unlock")

            MsgBox("OK :_)", MsgBoxStyle.Information)
            End
        End If
    End Sub
End Class