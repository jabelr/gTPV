Public Class frmCompras_lines
    Public IdRef As Integer = 0
    Public m_Iva As Double = 18

#Region "Eventos Auxiliares"
    Private Sub frmCompras_lines_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        My.AsignarFoco(Me.TxtName)
    End Sub

    Private Sub frmCompras_lines_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then Me.Close()
        If e.Control AndAlso e.KeyCode = Keys.G Then Me.BtToolSave_Click(sender, e)
    End Sub

    Private Sub FrmLines_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        AddHandlers()

        '####### Agrego tipos de IVA
        With Me.CbIVA.Items
            .Clear()
            .Add(My.m_opt.IVA_General)
            .Add(My.m_opt.IVA_Medio)
            .Add(My.m_opt.IVA_Basico)
        End With

        Me.LblIva.Text = Me.m_Iva
        Me.CbIVA.Text = Me.m_Iva

        'Me.CbIVA.Enabled = Not (Me.IdRef > 0)
        Me.TxtName.ReadOnly = (Me.IdRef > 0)
    End Sub

    Private Sub TxtMarca_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtName.KeyPress
        If e.KeyChar = Chr(13) Then
            e.Handled = True
            My.AsignarFoco(TxtUD)
        End If
    End Sub

    Private Sub TxtUD_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtUD.KeyPress
        If e.KeyChar = Chr(13) Then
            e.Handled = True
            My.AsignarFoco(TxtTotal)
        End If
    End Sub

    Private Sub TxtTotal_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtTotal.GotFocus
        Me.LblNfo.Visible = True
    End Sub

    Private Sub TxtTotal_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtTotal.KeyDown
        '# Precio Iva incluido
        If e.KeyCode = Keys.F1 Then
            e.Handled = True
            Dim str As String = Me.m_Iva
            str = "1," & IIf(Me.m_Iva < 10, "0", "") & str.Replace(",", "")
            Me.TxtTotal.Text = Format(CDbl(Me.TxtTotal.Text / CDbl(str)), "0.00#")
        End If

        '# Precio Iva incluido
        If e.KeyCode = Keys.F5 Then
            e.Handled = True
            If Not IsNumeric(Me.TxtTotal.Tag) Then Me.TxtTotal.Tag = 0
            Me.TxtTotal.Text = Format(CDbl(Me.TxtTotal.Tag), "0.00#")
        End If

        '# Precio de costo
        If e.KeyCode = Keys.F2 Then
            Dim rst As ADODB.Recordset = My.m_db.GetRst("SELECT pvp_costo FROM articulos WHERE id=" & Me.IdRef)
            If rst.RecordCount = 0 Then Exit Sub
            Me.TxtTotal.Text = rst("pvp_costo").Value
            My.m_db.CloseRst(rst)
        End If
    End Sub


    Private Sub TxtTotal_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtTotal.KeyPress
        If e.KeyChar <> Chr(13) Then Exit Sub
        e.Handled = True
        If Me.TxtDto.Visible Then
            My.AsignarFoco(Me.TxtDto)
        Else
            Me.BtToolSave_Click(sender, e)
        End If

    End Sub

    Private Sub TxtDto_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtDto.KeyPress
        If e.KeyChar = Chr(13) Then
            e.Handled = True
            'BtOk_Click(sender, e)
            Me.BtToolSave_Click(sender, e)
        End If
    End Sub

    Private Sub TxtTotal_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtTotal.LostFocus
        Me.LblNfo.Visible = False
    End Sub

    Private Sub BtToolCancell_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtToolCancell.Click
        Me.Close()
    End Sub

    Private Sub BtToolSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtToolSave.Click
        Me.DialogResult = Windows.Forms.DialogResult.OK
    End Sub
#End Region

#Region "Handlers"
    Private Sub AddHandlers()
        AddHandler Me.TxtUD.KeyPress, AddressOf gDevelop.Lite.m_OverridesEvents.TxtValidaEuro_KeyPress
        AddHandler Me.TxtTotal.KeyPress, AddressOf gDevelop.Lite.m_OverridesEvents.TxtValidaEuro_KeyPress
        AddHandler Me.TxtDto.KeyPress, AddressOf gDevelop.Lite.m_OverridesEvents.TxtValidaEuro_KeyPress
    End Sub
#End Region

End Class