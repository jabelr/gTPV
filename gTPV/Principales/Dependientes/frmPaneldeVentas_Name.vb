Public Class frmPaneldeVentas_Name
    'Public Id_Ref As Integer = 0
    'Private m_Data As gDevelop.Lite.m_dataform

#Region "Eventos Principales"
    Private Sub frmPaneldeVentas_Name_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Me.m_Data = New gDevelop.Lite.m_dataform(My.m_db)
        'Me.m_Data.DbTable = "db_zonas"
        'Me.m_Data.ConfigureDataForm(Me.Controls)
        'If Me.Id_Ref = 0 Then           'Caso del nuevo
        '    Me.m_Data.data_NewField()
        'Else
        '    Me.m_Data.data_EditField(Me.Id_Ref)
        'End If
    End Sub
#End Region

#Region "Eventos Auxiliares"
    Private Sub evtButtons_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtOk.Click, BtCancell.Click
        Select Case True
            Case sender Is Me.BtOk
                If Me.TxtName.TextLength <= 0 Then
                    MsgBox("Debe de establecer un nombre de zona válido.", MsgBoxStyle.Critical)
                    Exit Sub
                End If
                'Me.m_Data.data_SaveField()
                Me.DialogResult = Windows.Forms.DialogResult.OK

            Case sender Is Me.BtCancell
                Me.Close()
        End Select
    End Sub

    Private Sub TxtName_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtName.GotFocus
        Me.TxtName.SelectionStart = Me.TxtName.TextLength
    End Sub

    Private Sub TxtName_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtName.KeyPress
        If e.KeyChar = Chr(13) Then Me.evtButtons_Click(Me.BtOk, New System.EventArgs)
    End Sub

    Private Sub TxtName_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtName.TextChanged
        Me.BtOk.Enabled = (Me.TxtName.TextLength > 0)
    End Sub

    Private Sub BtKeyBoard_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtKeyBoard.Click
        AddHandler m_KeyBoard.KeyBoard_Press, AddressOf KeyBoard_Press

        m_KeyBoard.Left = (Screen.PrimaryScreen.WorkingArea.Width - m_KeyBoard.Width) / 2
        m_KeyBoard.Top = Screen.PrimaryScreen.WorkingArea.Height - m_KeyBoard.Height - My.APP_NUMBER
        m_KeyBoard.Show()

        My.AsignarFoco(Me.TxtName)
        'My.ShellExecute(0, Nothing, "osk.exe", Nothing, Nothing, 0)


        ''AddHandler m_KeyBoard.KeyBoard_Press, AddressOf KeyBoard_Press

        ''m_KeyBoard.Left = (Screen.PrimaryScreen.WorkingArea.Width - m_KeyBoard.Width) / 2
        ''m_KeyBoard.Top = Screen.PrimaryScreen.WorkingArea.Height - m_KeyBoard.Height - My.APP_NUMBER
        ''m_KeyBoard.Show()


        'My.AsignarFoco(Me.TxtName)
        'My.ShellExecute(0, Nothing, "osk.exe", Nothing, Nothing, 0)
    End Sub


    Private Sub KeyBoard_Press(ByVal key As String)
        If TypeName(Me.ActiveControl).ToUpper <> "TEXTBOX" Then Exit Sub

        Select Case key
            Case "SPACE"
                key = " "
            Case "DEL"
                If CType(Me.ActiveControl, TextBox).TextLength = 0 Then
                    m_KeyBoard.Activate()
                    Exit Sub
                End If
                CType(Me.ActiveControl, TextBox).Text = CType(Me.ActiveControl, TextBox).Text.Substring(0, CType(Me.ActiveControl, TextBox).Text.Length - 1)
                CType(Me.ActiveControl, TextBox).SelectionStart = CType(Me.ActiveControl, TextBox).TextLength
                m_KeyBoard.Activate()
                Exit Sub

            Case "OK"
                Me.DialogResult = Windows.Forms.DialogResult.OK
                Exit Sub
        End Select

        'Si esta todo seleccionado lo borro
        If CType(Me.ActiveControl, TextBox).SelectionLength = CType(Me.ActiveControl, TextBox).TextLength Then CType(Me.ActiveControl, TextBox).Text = ""

        CType(Me.ActiveControl, TextBox).Text &= key
        CType(Me.ActiveControl, TextBox).SelectionStart = CType(Me.ActiveControl, TextBox).TextLength

        m_KeyBoard.Activate()
    End Sub

    Private Sub frmPaneldeVentas_Name_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If Not IsNothing(m_KeyBoard) Then m_KeyBoard.Dispose()
    End Sub

    Private Sub frmPaneldeVentas_Name_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        My.AsignarFoco(Me.TxtName)
    End Sub

#End Region
End Class