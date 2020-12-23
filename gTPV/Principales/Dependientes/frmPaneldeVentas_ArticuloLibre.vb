Public Class frmPaneldeVentas_ArticuloLibre
    'Public Id_Ref As Integer = 0                'El id del usuario/empleado

    Private arr() As String
    Private arrIVA() As Double

    Dim i As Integer = 0

#Region "Eventos Principales"
    Private Sub frmPaneldeVentas_ArticuloLibre_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Cargo los conceptos varios
        Dim rst As ADODB.Recordset = My.m_db.GetRst("SELECT * FROM db_vv ORDER BY name ASC")
        ReDim Preserve arr(rst.RecordCount - 1)
        ReDim Preserve arrIVA(rst.RecordCount)

        Me.TxtPVP.Text = ""
        Me.cbConceptos.Items.Clear()
        Me.lst.Items.Clear()

        Me.lst.Items.Add("")
        Me.arrIVA(0) = My.m_opt.IVA_General

        While Not rst.EOF
            Me.cbConceptos.Items.Add(rst("name").Value)
            Me.lst.Items.Add(rst("name").Value)
            Me.arr(i) = IIf(rst("swImporteNegativo").Value, "-", "+")
            Me.arrIVA(i + 1) = IIf(IsDBNull(rst("iva").Value), My.m_opt.IVA_General, rst("iva").Value)

            i += 1
            rst.MoveNext()
        End While
        My.m_db.CloseRst(rst)

        If Me.cbConceptos.Items.Count > 0 Then
            If My.m_app.GetValue("vv_id", 0) > Me.cbConceptos.Items.Count Then My.m_app.SetValue("vv_id") = 0

            Me.cbConceptos.SelectedIndex = My.m_app.GetValue("vv_id")
        Else
            Me.cbConceptos.Text = "VARIOS"
        End If

        'Configuro el listview de agregados
        With Me.LstLines.Columns
            .Clear()
            .Add("Importe", 80, HorizontalAlignment.Right)
            .Add("Concepto", 240, HorizontalAlignment.Left)
            .Add("%IVA", 60, HorizontalAlignment.Left)
        End With
        Me.LstLines.Columns(0).TextAlign = HorizontalAlignment.Right
        Me.LstLines.Columns(2).TextAlign = HorizontalAlignment.Right

        AddHandler Me.TxtPVP.KeyPress, AddressOf gDevelop.lite.m_OverridesEvents.TxtValidaEuro_KeyPress
    End Sub
#End Region

#Region "Eventos Auxiliares"
    Private Sub Buttons_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtCancell.Click, BtOK.Click, BtClear.Click, BtUndo.Click, btAdd.Click
        Select Case True
            Case sender Is Me.BtUndo
                Me.TxtPVP.Text = Me.TxtPVP.Text.Substring(0, Me.TxtPVP.Text.Length - 1)
                Me.TxtPVP.Select()
                Me.TxtPVP.SelectionStart = Me.TxtPVP.TextLength

            Case sender Is Me.BtClear
                Me.TxtPVP.Text = ""

                'Case sender Is Me.btAdd
                '    If Not IsNumeric(Me.TxtPVP.Text) Then
                '        My.m_msg.MessageError(Me, "Importe incorrecto")
                '        Me.TxtPVP.Text = ""
                '        My.AsignarFoco(Me.TxtPVP)
                '        Exit Select
                '    End If

            Case sender Is Me.BtOK, sender Is Me.btAdd
                If Not IsNumeric(Me.TxtPVP.Text) AndAlso Me.LstLines.Items.Count = 0 Then
                    My.m_msg.MessageError(Me, "Importe incorrecto")
                    Me.TxtPVP.Text = ""
                    My.AsignarFoco(Me.TxtPVP)
                    Exit Select

                ElseIf IsNumeric(Me.TxtPVP.Text) Then

                    Me.LstLines.Items.Add(Format(CDbl(Me.TxtPVP.Text), "0.00"))
                    Me.LstLines.Items(Me.LstLines.Items.Count - 1).SubItems.Add(Me.cbConceptos.Text)
                    Me.LstLines.Items(Me.LstLines.Items.Count - 1).SubItems.Add(Format(Me.arrIVA(Me.cbConceptos.SelectedIndex + 1), "0.00"))
                End If




                'Dim rst As ADODB.Recordset = My.m_db.GetRst("SELECT id FROM db_usuarios WHERE id=" & Me.Id_Ref & " AND pass='" & Me.TxtPass.Text & "'")
                'If rst.RecordCount = 0 Then
                '    My.m_msg.MessageError(Me, "Contraseña de Usuario errónea, Pruebe de nuevo!!!")
                '    Me.TxtPass.Text = ""
                '    My.AsignarFoco(Me.TxtPass)
                '    Exit Select
                'End If
                If sender Is Me.btAdd Then
                    Me.TxtPVP.Text = ""
                    If Me.cbConceptos.SelectedIndex = -1 Then Exit Select
                    If Me.arr(Me.cbConceptos.SelectedIndex) = "-" Then Me.TxtPVP.Text = "-"
                Else
                    Me.DialogResult = Windows.Forms.DialogResult.OK
                End If



            Case sender Is Me.BtCancell
                Me.Close()
        End Select
    End Sub

    Private Sub frmPaneldeVentas_ArticuloLibre_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        Me.PnlGaleria.Visible = True
        My.AsignarFoco(Me.TxtPVP)
    End Sub

    Private Sub txtName_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs)
        My.AsignarFoco(Me.cbConceptos)
    End Sub

    Private Sub txtName_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        My.AsignarFoco(Me.cbConceptos)
    End Sub

    Private Sub TxtPass_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtPVP.KeyPress
        If Asc(e.KeyChar) = 13 Then Buttons_Click(Me.BtOK, e)
    End Sub

    Private Sub TxtPass_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtPVP.TextChanged
        Dim sw As Boolean = (Val(Me.TxtPVP.TextLength) > 0)
        Me.BtOK.Enabled = sw OrElse Me.LstLines.Items.Count > 0
        Me.BtClear.Enabled = sw
        Me.BtUndo.Enabled = sw
    End Sub

    Private Sub Bt_Num_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Bt_9.Click, Bt_8.Click, Bt_7.Click, Bt_6.Click, Bt_5.Click, Bt_4.Click, Bt_3.Click, Bt_2.Click, Bt_1.Click, Bt_0.Click, BtDecimal.Click
        'If sender Is Me.BtDecimal Then
        '    If InStr(Me.TxtPVP.Text, ",") > 0 Then Exit Sub
        '    If Me.TxtPVP.TextLength = 0 Then Me.TxtPVP.Text = "0"
        'End If

        'Me.TxtPVP.Text &= CType(sender, Button).Text
        'Me.TxtPVP.Select()
        'Me.TxtPVP.SelectionStart = Me.TxtPVP.TextLength
    End Sub

    Private Sub Bt_MouseDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Bt_9.MouseDown, Bt_8.MouseDown, Bt_7.MouseDown, Bt_6.MouseDown, Bt_5.MouseDown, Bt_4.MouseDown, Bt_3.MouseDown, Bt_2.MouseDown, Bt_1.MouseDown, Bt_0.MouseDown, BtDecimal.MouseDown, btMasMenos.MouseDown
        If sender Is Me.BtDecimal Then
            If InStr(Me.TxtPVP.Text, ",") > 0 Then Exit Sub
            If Me.TxtPVP.TextLength = 0 Then Me.TxtPVP.Text = "0"
        End If

        'Cambio el signo
        If sender Is Me.btMasMenos Then
            If IsNumeric(Me.TxtPVP.Text) Then
                Me.TxtPVP.Text *= -1
                My.AsignarFoco(Me.TxtPVP)
            End If
            Exit Sub
        End If

        Me.TxtPVP.Text &= CType(sender, Button).Text
        Me.TxtPVP.Select()
        Me.TxtPVP.SelectionStart = Me.TxtPVP.TextLength
    End Sub


    Private Sub frmPaneldeVentas_ArticuloLibre_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
        If Asc(e.KeyChar) = 13 Then Buttons_Click(Me.BtOK, e)
    End Sub

    Private Sub cbConceptos_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbConceptos.SelectedIndexChanged
        If Me.cbConceptos.SelectedIndex < 0 Then Exit Sub
        My.m_app.SetValue("vv_id") = Me.cbConceptos.SelectedIndex


        If IsNumeric(Me.TxtPVP.Text) Then
            If Me.arr(Me.cbConceptos.SelectedIndex) = "-" Then
                If Me.TxtPVP.Text > 0 Then Me.TxtPVP.Text *= -1
            Else
                If Me.TxtPVP.Text < 0 Then Me.TxtPVP.Text *= -1
            End If

            My.AsignarFoco(Me.TxtPVP)
        Else
            If Me.arr(Me.cbConceptos.SelectedIndex) = "-" Then
                Me.TxtPVP.Text = "-"
            Else
                Me.TxtPVP.Text = ""
            End If
            Me.TxtPVP.Select()
            Me.TxtPVP.SelectionStart = Me.TxtPVP.TextLength
        End If

    End Sub
#End Region

    Private Sub lst_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lst.SelectedIndexChanged
        If Me.lst.SelectedIndex < 0 Then Exit Sub
        Me.cbConceptos.SelectedIndex = Me.lst.SelectedIndex - 1
    End Sub
End Class