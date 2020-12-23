Imports System.Windows.Forms

Public Class FrmExporta
    Public id As Integer = -1

    Public frm As New m_Shell

#Region "Funciones"
    Public Function Configure(ByVal configuracion As String, ByVal filterSQL As String) As Boolean

        With frm
            'Preconfiguro y muestro
            If Not .ConfigureApp(configuracion, True) Then Return False
            'Preconfiguro y muestro
            AddHandler .mData_ExportId, AddressOf mData_ExportId
            AddHandler .mData_CancelExport, AddressOf mData_CancelExport

            .MdiParent = Me
            '.m_Form.MdiParent = Me
            .Dock = DockStyle.Fill
            .ShowDialog()
            ' .Select()
        End With
        Return True
    End Function
#End Region

#Region "Eventos Delegados"
    Private Sub mData_ExportId(ByVal id As Integer)
        Me.id = id
        Me.DialogResult = Windows.Forms.DialogResult.OK
        'Me.Close()
    End Sub

    Private Sub mData_CancelExport()
        ' Me.frm.Dispose()
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
    End Sub


    ''Funcion que me controla cuando cierro un formulario hijo
    'Private Sub mEvent_CloseForm(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs)
    '    If frm.DialogResult = Windows.Forms.DialogResult.OK Then
    '        Me.id = frm.Grid.CurrentRow.Cells(0).Value
    '        'Me.DialogResult = Windows.Forms.DialogResult.OK
    '    End If
    '    'frm.Dispose()
    '    'Me.Close()
    'End Sub
#End Region

    Private Sub FrmExporta_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Me.frm.Close()
        Me.frm.Dispose()
        Me.frm = Nothing
    End Sub

    'Private Sub FrmExporta_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
    '    frm.Close()
    'End Sub

    Private Sub FrmExporta_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Screen.PrimaryScreen.Bounds.Height = 600 Then Me.Size = New Size(834, 550)
    End Sub
End Class
