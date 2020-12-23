Public Class frmGetCodBarras
    'El codigo leido
    Public StrCode As String = ""
    Private SwLectura As Boolean = False
    Private _CodBarras As String = ""

    Private Sub frmGetCodBarras_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then Me.DialogResult = Windows.Forms.DialogResult.Cancel
    End Sub

    Private Sub frmGetCodBarras_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
        If (e.KeyChar = My.MyLector.Str_CodLector Or (My.MyLector.Str_CodLector.Length = 0 AndAlso Not Me.SwLectura AndAlso IsNumeric(e.KeyChar))) Then
            Me.SwLectura = True
            e.Handled = True
            _CodBarras = IIf(IsNumeric(e.KeyChar), e.KeyChar, "")
            'StrLectorCodigos = ""
            Exit Sub
        End If

        If Me.SwLectura Then
            e.Handled = True
            If e.KeyChar = Chr(13) Then
                Me.SwLectura = False
                Me.StrCode = Me._CodBarras
                Me.DialogResult = Windows.Forms.DialogResult.OK
                Exit Sub
            End If
            'Verifico que siempre sea un numero
            If Not IsNumeric(e.KeyChar) Then
                Me.SwLectura = False
                Exit Sub
            End If
            Me._CodBarras &= e.KeyChar
        End If
    End Sub

    Private Sub FrmCheckGP20_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Timer.Enabled = True
    End Sub

    Private Sub Timer_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer.Tick
        Static sw As Boolean = False
        LblWait.ForeColor = IIf(sw, Color.Black, Color.Red)
        sw = Not sw
    End Sub

    Private Sub BtCancell_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
    End Sub

    Private Sub LblWait_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles LblWait.DoubleClick
        Me.StrCode = Me._CodBarras
        Me.DialogResult = Windows.Forms.DialogResult.OK
    End Sub
End Class