Imports System.IO
Public Class frmDesign_Object
    Public Id_Ref As Integer = 0

#Region "Eventos Principales"
    Private Sub frmDesign_Object_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub
#End Region

#Region "Eventos Auxiliares"
    Private Sub evtButtons_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtCancell.Click, BtDel.Click, BtChangeName.Click
        Select Case True
            Case sender Is Me.BtChangeName
                Me.DialogResult = Windows.Forms.DialogResult.Yes

            Case sender Is Me.BtDel
                If MsgBox("¿Esta seguro de que desea eliminar el Objeto seleccionado?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, My.APP_NAME) <> MsgBoxResult.Yes Then Exit Select
                Me.DialogResult = Windows.Forms.DialogResult.Ignore

            Case sender Is Me.BtCancell
                Me.Close()
        End Select
    End Sub

    Private Sub TxtName_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtName.GotFocus
        Me.TxtName.SelectionStart = Me.TxtName.TextLength
    End Sub

    Private Sub TxtName_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtName.KeyPress
        If e.KeyChar = Chr(13) Then Me.evtButtons_Click(Me.BtChangeName, New System.EventArgs)
    End Sub

    Private Sub TxtName_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtName.TextChanged
        Me.BtChangeName.Enabled = (Me.TxtName.TextLength > 0)
    End Sub
#End Region
End Class