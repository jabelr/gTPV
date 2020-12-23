Public Class frmPaneldeVentas_Num
    'Public Id_Ref As Integer = 0                'El id del usuario/empleado

    'Private arr() As String

    Dim i As Integer = 0

    Public swAdd As Boolean = False             'Para cuando es agregar

#Region "Eventos Principales"
    Private Sub frmPaneldeVentas_Num_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Cargo los conceptos varios
        'Dim rst As ADODB.Recordset = My.m_db.GetRst("SELECT * FROM db_vv ORDER BY name ASC")
        'ReDim Preserve arr(rst.RecordCount - 1)

        'Me.TxtUD.Text = ""
        'Me.cbConceptos.Items.Clear()
        'While Not rst.EOF
        '    Me.cbConceptos.Items.Add(rst("name").Value)
        '    Me.arr(i) = IIf(rst("swImporteNegativo").Value, "-", "+")

        '    i += 1
        '    rst.MoveNext()
        'End While
        'My.m_db.CloseRst(rst)

        'If Me.cbConceptos.Items.Count > 0 Then
        '    If My.m_app.GetValue("vv_id", 0) > Me.cbConceptos.Items.Count Then My.m_app.SetValue("vv_id") = 0

        '    Me.cbConceptos.SelectedIndex = My.m_app.GetValue("vv_id")
        'Else
        '    Me.cbConceptos.Text = "VARIOS"
        'End If

        ''Configuro el listview de agregados
        'With Me.LstLines.Columns
        '    .Clear()
        '    .Add("Importe", 80, HorizontalAlignment.Right)
        '    .Add("Concepto", 240, HorizontalAlignment.Left)
        'End With

        AddHandler Me.TxtUD.KeyPress, AddressOf gDevelop.lite.m_OverridesEvents.TxtValidaEuro_KeyPress
    End Sub
#End Region

#Region "Eventos Auxiliares"
    Private Sub Buttons_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtCancell.Click, BtOK.Click, btMas.Click
        Select Case True


            Case sender Is Me.BtOK
                If Not IsNumeric(Me.TxtUD.Text) Then
                    My.m_msg.MessageError(Me, "Importe incorrecto")
                    Me.TxtUD.Text = ""
                    My.AsignarFoco(Me.TxtUD)
                    Exit Select
                End If




                'Dim rst As ADODB.Recordset = My.m_db.GetRst("SELECT id FROM db_usuarios WHERE id=" & Me.Id_Ref & " AND pass='" & Me.TxtPass.Text & "'")
                'If rst.RecordCount = 0 Then
                '    My.m_msg.MessageError(Me, "Contraseña de Usuario errónea, Pruebe de nuevo!!!")
                '    Me.TxtPass.Text = ""
                '    My.AsignarFoco(Me.TxtPass)
                '    Exit Select
                'End If
                Me.DialogResult = Windows.Forms.DialogResult.OK


            Case sender Is Me.btMas
                If Not IsNumeric(Me.TxtUD.Text) Then
                    My.m_msg.MessageError(Me, "Importe incorrecto")
                    Me.TxtUD.Text = ""
                    My.AsignarFoco(Me.TxtUD)
                    Exit Select
                End If

                Me.swAdd = True
                Me.DialogResult = Windows.Forms.DialogResult.OK

            Case sender Is Me.BtCancell
                Me.Close()
        End Select
    End Sub

    Private Sub frmPaneldeVentas_Num_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        Me.PnlGaleria.Visible = True
        My.AsignarFoco(Me.TxtUD)
    End Sub

 
    Private Sub TxtUD_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtUD.KeyPress
        If Asc(e.KeyChar) = 13 Then Buttons_Click(Me.BtOK, e)
    End Sub

    Private Sub TxtUD_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtUD.TextChanged
        Dim sw As Boolean = (Val(Me.TxtUD.TextLength) > 0)
        Me.BtOK.Enabled = sw
        Me.btMas.Enabled = sw
        Me.btBy10.Enabled = sw
    End Sub

    Private Sub Bt_Num_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Bt_9.Click, Bt_8.Click, Bt_7.Click, Bt_6.Click, Bt_5.Click, Bt_4.Click, Bt_3.Click, Bt_2.Click, Bt_1.Click, Bt_0.Click, BtDecimal.Click
        If sender Is Me.BtDecimal Then
            If InStr(Me.TxtUD.Text, ",") > 0 Then Exit Sub
            If Me.TxtUD.TextLength = 0 Then Me.TxtUD.Text = "0"
        End If

        Me.TxtUD.Text &= CType(sender, Button).Text
        Me.TxtUD.Select()
        Me.TxtUD.SelectionStart = Me.TxtUD.TextLength
    End Sub

    Private Sub Bt_MouseDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Bt_9.MouseDown, Bt_8.MouseDown, Bt_7.MouseDown, Bt_6.MouseDown, Bt_5.MouseDown, Bt_4.MouseDown, Bt_3.MouseDown, Bt_2.MouseDown, Bt_1.MouseDown, Bt_0.MouseDown, BtDecimal.MouseDown, btMasMenos.MouseDown
        If sender Is Me.BtDecimal Then
            If InStr(Me.TxtUD.Text, ",") > 0 Then Exit Sub
            If Me.TxtUD.TextLength = 0 Then Me.TxtUD.Text = "0"
        End If

        'Cambio el signo
        If sender Is Me.btMasMenos Then
            If IsNumeric(Me.TxtUD.Text) Then
                Me.TxtUD.Text *= -1
                My.AsignarFoco(Me.TxtUD)
            End If
            Exit Sub
        End If

        If Me.TxtUD.TextLength = Me.TxtUD.SelectionLength Then Me.TxtUD.Text = ""

        Me.TxtUD.Text &= CType(sender, Button).Text
        Me.TxtUD.Select()
        Me.TxtUD.SelectionStart = Me.TxtUD.TextLength
    End Sub


    Private Sub frmPaneldeVentas_Num_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
        If Asc(e.KeyChar) = 13 Then Buttons_Click(Me.BtOK, e)
        If Asc(e.KeyChar) = 27 Then Me.Close()
    End Sub


#End Region

    Private Sub btPor2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btPor2.Click
        If Not IsNumeric(Me.TxtUD.Text) Then Me.TxtUD.Text = 1
        Me.TxtUD.Text *= 2
        My.AsignarFoco(Me.TxtUD)
    End Sub

    Private Sub btBy10_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btBy10.Click
        If Not IsNumeric(Me.TxtUD.Text) Then Me.TxtUD.Text = 1
        Me.TxtUD.Text *= 10
        My.AsignarFoco(Me.TxtUD)
    End Sub
End Class