Public Class frmConfigure_GetCodeGP20
    'El codigo leido
    Public StrCode As String = ""
    Public IdPort As Integer = 0

    Private _GP20 As ClassGP20

    Private Sub FrmCheckGP20_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If Not IsNothing(Me._GP20) Then Me._GP20.Dispose()

        'If MyCtlAccesos.IdPort_GP20_Entrada = Me.IdPort Then

        '    'Devuelvo el controlador de eventos al formulario principal
        '    RemoveHandler m_GP20_Entradas.CodeRead_GP20, AddressOf Read_LectorGP20
        '    AddHandler m_GP20_Entradas.CodeRead_GP20, AddressOf FrmMain.Read_LectorGP20_Entradas
        'End If
    End Sub

    Private Sub FrmCheckGP20_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'If MyCtlAccesos.IdPort_GP20_Entrada = Me.IdPort Then

        '    'Deshabilito el evento de lectura para la apertura del torno
        '    RemoveHandler m_GP20_Entradas.CodeRead_GP20, AddressOf FrmMain.Read_LectorGP20_Entradas

        '    'Asingo el manejor de evento de lectura
        '    AddHandler m_GP20_Entradas.CodeRead_GP20, AddressOf Read_LectorGP20

        'Else

        Me._GP20 = New ClassGP20
        Me._GP20.Open("COM" & Me.IdPort)

        'Asingo el manejor de evento de lectura
        AddHandler Me._GP20.CodeRead_GP20, AddressOf Read_LectorGP20
        'End If
        Me.Timer.Enabled = True
    End Sub

    Private Sub Timer_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer.Tick
        Static sw As Boolean = False
        LblWait.ForeColor = IIf(sw, Color.Black, Color.Red)
        sw = Not sw
    End Sub

    Public Sub Read_LectorGP20(ByVal strCode As String)
        Me.StrCode = strCode
        Me.DialogResult = Windows.Forms.DialogResult.OK
    End Sub

    Private Sub BtCancell_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtCancell.Click
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
    End Sub
End Class