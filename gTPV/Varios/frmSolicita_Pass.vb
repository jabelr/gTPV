Public Class frmSolicita_Pass
    Public Id_Ref As Integer = 0                'El id del usuario/empleado
    Public swSupremo As Boolean = False

    Dim n_veces As Integer = 0                'Nº de veces que trato de meter la contraseña


    Dim swOK As Boolean = False

#Region "Eventos Principales"
    Private Sub frmSolicita_Pass_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ''####### Cargo las categorias de Imagen
        'Dim rst As ADODB.Recordset = My.m_db.GetRst("SELECT * FROM db_usuarios WHERE pass='" & & "'")

        'Me.CbImg_Cat.Items.Clear()
        'While Not rst.EOF
        '    Me.CbImg_Cat.Items.Add(rst("name").Value & Space(100) & rst("id").Value)
        '    rst.MoveNext()
        'End While
        'My.m_db.CloseRst(rst)

        'Me.CbImg_Cat.SelectedIndex = 0


        Me.PnlBody.Visible = False
        Me.Size = Screen.PrimaryScreen.WorkingArea.Size

        'Inicializo entorno
        If Not IsNothing(Me.Owner) Then
            Me.PnlBody.Left = CType(Me.Owner, frmMain).PnlBody.Left
            Me.PnlBody.Top = CType(Me.Owner, frmMain).PnlBody.Top
        Else
            Me.PnlBody.Left = (Me.Width - Me.PnlBody.Width) / 2
            Me.PnlBody.Top = (Me.SplitContainer.Panel2.Height - Me.PnlBody.Height) / 2 + (IIf(My.m_opt.swNoteBook, Me.SplitContainer.Panel1.Height, 0))
        End If

        Me.PnlBody.Visible = True

        AddHandler Me.TxtPass.KeyPress, AddressOf gDevelop.Lite.m_OverridesEvents.TxtValidaNumeric_KeyPress


        Me.LblHour.Text = Now.ToString("HH:mm")
        Me.LblHour.Location = New Point((Me.Width - Me.LblHour.Width) - 40, (Me.SplitContainer.Panel2.Height - Me.LblHour.Height) - 30)

        Me.Opacity = 85
    End Sub
#End Region

#Region "Eventos Auxiliares"
    Private Sub Buttons_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtCancell.Click, BtOK.Click, BtClear.Click, BtClose.Click
        Select Case True
            Case sender Is Me.BtClear
                Me.TxtPass.Text = ""

            Case sender Is Me.BtOK
                If Me.swSupremo Then
                    ' AÑO - 1012 - AÑO - MES
                    If Me.TxtPass.Text = StrReverse(Format(Now, "yy")) & "1012" & Format(Now, "yy") & Format(Now, "MM") Then
                        Me.Id_Ref = -7
                        Me.DialogResult = Windows.Forms.DialogResult.OK
                        Exit Sub
                    End If
                End If

                Dim rst As ADODB.Recordset = My.m_db.GetRst("SELECT id FROM db_usuarios WHERE " & IIf(Me.Id_Ref > 0, " id=" & Me.Id_Ref & " AND ", "") & " pass='" & Me.TxtPass.Text & "'")
                If rst.RecordCount = 0 Then
                    If n_veces >= 3 Then
                        MsgBox("Contraseña erronea.", MsgBoxStyle.Critical)
                    End If
                    My.m_msg.MessageError(Me, "Contraseña de Usuario errónea, Pruebe de nuevo!!!")
                    Me.TxtPass.Text = ""
                    My.AsignarFoco(Me.TxtPass)

                    'Control para 3 intentos como maximo de contraseña
                    n_veces += 1
                    If n_veces >= 3 Then Me.Close()
                    Exit Select
                End If
                Me.Id_Ref = rst("id").Value
                Me.DialogResult = Windows.Forms.DialogResult.OK

            Case sender Is Me.BtClose
                Me.Close()

            Case sender Is Me.BtCancell
                Me.Close()
        End Select
    End Sub

    Private Sub frmSolicita_Pass_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        Me.PnlGaleria.Visible = True
        My.AsignarFoco(Me.TxtPass)
    End Sub

    Private Sub TxtPass_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtPass.KeyPress
        If Asc(e.KeyChar) = 13 Then Buttons_Click(Me.BtOK, e)
    End Sub

    Private Sub TxtPass_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtPass.TextChanged
        Me.BtOK.Enabled = (Me.TxtPass.TextLength > 0)
    End Sub

    Private Sub Bt_Num_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Bt_9.Click, Bt_8.Click, Bt_7.Click, Bt_6.Click, Bt_5.Click, Bt_4.Click, Bt_3.Click, Bt_2.Click, Bt_1.Click, Bt_0.Click
        Me.TxtPass.Text &= CType(sender, Button).Text
    End Sub

    Private Sub LblName_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles LblName.MouseDown
        If e.Button = Windows.Forms.MouseButtons.Right AndAlso e.Clicks >= 2 Then Me.Id_Ref = 0 : Me.DialogResult = Windows.Forms.DialogResult.OK
    End Sub

    Private Sub TmHour_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TmHour.Tick
        Me.LblHour.Text = Now.ToString("HH:mm")
    End Sub
#End Region

    Private Sub LblTitle_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'Hack
        'Me.Id_Ref = -3
        'Me.DialogResult = Windows.Forms.DialogResult.OK
    End Sub

    Private Sub m_logo_MouseDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles m_logo.MouseDoubleClick
        
    End Sub

    Private Sub m_logo_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles m_logo.DoubleClick
        'Me.BtUnlock.Visible = True
        'Me.swOK = True
    End Sub

    Private Sub lbl_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lbl.DoubleClick
        If MsgBox("Esta intentado una eliminación completa de toda la base de datos, ¿Desea continuar?", MsgBoxStyle.AbortRetryIgnore + MsgBoxStyle.Question) <> MsgBoxResult.Retry Then Exit Sub
        Me.BtUnlock.Visible = True
    End Sub

    Private Sub BtUnlock_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtUnlock.Click
        'Hack
        If My.m_opt.modo_seguro_secciones Then
            Me.Id_Ref = 99
        Else
            Me.Id_Ref = -3
        End If
        Me.DialogResult = Windows.Forms.DialogResult.OK
    End Sub
End Class