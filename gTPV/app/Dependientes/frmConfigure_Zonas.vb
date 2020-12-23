Public Class frmConfigure_Zonas
    Public Id_Ref As Integer = 0
    Private m_Data As gDevelop.Lite.m_dataform

#Region "Eventos Principales"
    Private Sub frmConfigure_Zonas_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.m_Data = New gDevelop.Lite.m_dataform(My.m_db)
        Me.m_Data.DbTable = "db_zonas"
        Me.m_Data.ConfigureDataForm(Me.Controls)
        If Me.Id_Ref = 0 Then           'Caso del nuevo
            Me.m_Data.data_NewField()
        Else
            Me.m_Data.data_EditField(Me.Id_Ref)
        End If
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
                Me.m_Data.data_SaveField()
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
#End Region

    Private Sub BtOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub
End Class