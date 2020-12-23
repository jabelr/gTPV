Public Class frmPaneldeVentas_Cobra
    Public Id_Ref As Integer = 0
    Public strTicket As String = ""
    Public DblTotal As Double = 0.0

    Public swPrintTicket As Boolean = False

    Public swPagoTarjeta As Boolean = False

    Public swPagoEfectivo As Boolean = True
    Public swNota As Boolean = False

#Region "Eventos Principales"
    Private Sub frmPaneldeVentas_Cobra_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If My.m_opt.modo_compatibilidad = "DISCOTECA" Then
            Me.Tab.SelectedTab = Me.TabPage_Entrada
        Else
            Me.Tab.TabPages.Remove(Me.TabPage_Entrada)
        End If

        If Not My.m_opt.lector_sw Then Me.Tab.TabPages.Remove(Me.TabPage_Tarjeta)

        'Doy formatos
        Me.LblTotal.Text = Format(Me.DblTotal, "0.00")


        Me.BtCobraPrint.Enabled = (My.MyHardware.IdPort > 0)

        Me.CbTipo.SelectedIndex = 0

        AddHandler Me.TxtEntrega.KeyPress, AddressOf gDevelop.Lite.m_OverridesEvents.TxtValidaEuro_KeyPress
    End Sub
#End Region

#Region "Eventos Auxiliares"

    Private Sub frmPaneldeVentas_Cobra_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        'Me.m_Data.Dispose()
        'm_Data = Nothing
    End Sub

    Private Sub Bt_Num_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Bt_9.Click, Bt_8.Click, Bt_7.Click, Bt_6.Click, Bt_5.Click, Bt_4.Click, Bt_3.Click, Bt_2.Click, Bt_1.Click, Bt_0.Click, BtDecimal.Click
        If sender Is Me.BtDecimal AndAlso InStr(Me.TxtEntrega.Text, ",") > 0 Then Exit Sub
        Me.TxtEntrega.Text &= CType(sender, Button).Text
    End Sub

    Private Sub TxtEntrega_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtEntrega.TextChanged
        Me.PnlCambio.Visible = (IsNumeric(Me.TxtEntrega.Text) AndAlso (Me.TxtEntrega.Text > 0))
        Me.GroupEntrega.Enabled = Me.PnlCambio.Visible
        Me.BtClear.Enabled = (Me.TxtEntrega.TextLength > 0)

        Me.BtCobraPrint.Enabled = (Me.TxtEntrega.TextLength = 0) OrElse ((Val(Me.TxtEntrega.Text) > 0) AndAlso ((CDbl(Me.TxtEntrega.Text) - CDbl(Me.LblTotal.Text)) > 0))
        Me.BtCobra.Enabled = Me.BtCobraPrint.Enabled

        If Me.TxtEntrega.TextLength = 0 Then Exit Sub
        If Me.TxtEntrega.Text = "," Then Me.TxtEntrega.Text = "0,"
        Me.LblCambio.Text = Format(CDbl(Me.TxtEntrega.Text) - CDbl(Me.LblTotal.Text), "0.00")
    End Sub

    Private Sub BtClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtClear.Click
        If MsgBox("¿Esta seguro de que desea eliminar el importe entregado?", MsgBoxStyle.Question + MsgBoxStyle.OkCancel) <> MsgBoxResult.Ok Then Exit Sub
        Me.TxtEntrega.Text = ""
    End Sub

    Private Sub frmPaneldeVentas_Cobra_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        My.AsignarFoco(Me.TxtEntrega)
    End Sub
#End Region

    Private Sub BtCobraPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtCobraPrint.Click
        If Me.DblTotal < 0 Then
            MsgBox("Imposible cobrar un importe inferior a 0.", MsgBoxStyle.Critical)
            Exit Sub
        End If

        If My.MyHardware.cashlogy_sw And (Me.CbTipo.SelectedIndex = 0) Then
            MsgBox("Imposible de cobrar en efectivo desde aquí con Cashlogy activado.", MsgBoxStyle.Critical)
            Exit Sub
        End If

        Me.swPagoEfectivo = (Me.CbTipo.SelectedIndex = 0)

        Me.swPrintTicket = True
        Me.DialogResult = Windows.Forms.DialogResult.OK
    End Sub

    Private Sub BtCobra_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtCobra.Click
        If Me.DblTotal < 0 Then
            MsgBox("Imposible cobrar un importe inferior a 0.", MsgBoxStyle.Critical)
            Exit Sub
        End If

        If My.MyHardware.cashlogy_sw AndAlso (Me.CbTipo.SelectedIndex = 0) Then
            MsgBox("Imposible de cobrar en efectivo desde aquí con Cashlogy activado.", MsgBoxStyle.Critical)
            Exit Sub
        End If

        Me.swPagoEfectivo = (Me.CbTipo.SelectedIndex = 0)

        Me.DialogResult = Windows.Forms.DialogResult.OK
    End Sub




    Private Sub pic_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles pic100.Click, pic50.Click, pic5.Click, pic20.Click, pic2.Click, pic10.Click, pic1.Click, pic050.Click, pic020.Click, pic010.Click, pic005.Click
        Dim dbl As Double = CDbl(CType(sender, PictureBox).Tag.ToString.Replace(".", ","))

        Me.TxtEntrega.Text = Format(Val(Me.TxtEntrega.Text.Replace(",", ".")) + dbl, "0.00")

    End Sub

    Private Sub Tab_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Tab.SelectedIndexChanged
        Me.TxtEntrega.Text = ""
    End Sub

    Private Sub BtEntrada_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtEntrada_normal.Click, BtEntrada_especial.Click
        Dim dbl As Double = 0
        Select Case True
            Case sender Is Me.BtEntrada_normal
                Me.lblEntrada_normal.Text = Val(Me.lblEntrada_normal.Text) + 1
                dbl = My.m_opt.entrada_normal

            Case sender Is Me.BtEntrada_especial
                Me.lblEntrada_especial.Text = Val(Me.lblEntrada_especial.Text) + 1
                dbl = My.m_opt.entrada_especial
        End Select
        Me.DblTotal -= dbl

        Me.LblTotal.Text = Format(Me.DblTotal, "0.00")

    End Sub

    Private Sub btLeerTarjeta_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btLeerTarjeta.Click
        Dim str As String = "", sql As String = "", strName As String = ""
        Dim id As Integer = 0, dblCredito As Double = 0
        Dim cmd As MySql.Data.MySqlClient.MySqlCommand = Nothing
        Dim reader As MySql.Data.MySqlClient.MySqlDataReader = Nothing

        'Leo el codigo
        frmConfigure_GetCodeGP20.IdPort = My.m_opt.lector_port
        frmConfigure_GetCodeGP20.ShowDialog(Me)
        If frmConfigure_GetCodeGP20.DialogResult <> Windows.Forms.DialogResult.OK Then
            frmConfigure_GetCodeGP20.Dispose()
            Exit Sub
        End If
        str = frmConfigure_GetCodeGP20.StrCode
        frmConfigure_GetCodeGP20.Dispose()

        'Compruebo si tiene cliente asociado
        sql = "SELECT id,name,credito FROM clients WHERE cod_tarjeta='" & str & "'"
        cmd = New MySql.Data.MySqlClient.MySqlCommand(sql, My.m_db_mysql)
        reader = cmd.ExecuteReader
        reader.Read()

        If Not reader.HasRows Then
            MsgBox("Tarjeta no localizada.", MsgBoxStyle.Critical)
            reader.Close()
            Exit Sub
        End If

        'Compruebo que el saldo que tiene le permite pagar la consumision
        If Me.DblTotal > reader("credito") Then
            MsgBox("Credito insuficiente para abonar la cuenta (" & reader("credito") & "" & System.Threading.Thread.CurrentThread.CurrentCulture.NumberFormat.CurrencySymbol & ")", MsgBoxStyle.Critical)
            reader.Close()
            Exit Sub
        End If

        'Guardo los valores
        id = reader("id")
        dblCredito = reader("credito")
        strName = reader("name")

        reader.Close()

        'Actualizo el credito del cliente
        sql = "UPDATE clients SET credito=credito-" & Format(Me.DblTotal, "0.00").Replace(",", ".") & " WHERE id=" & id
        cmd = New MySql.Data.MySqlClient.MySqlCommand(sql, My.m_db_mysql)
        cmd.ExecuteNonQuery()

        'Agrego la linea de pago
        sql = "INSERT INTO sales (id_local,id_ticket,id_client,ticket,importe,fh_alta)"
        sql &= " VALUES (" & My.m_opt.mysql_id & "," & Me.Id_Ref & "," & id & ",'" & Me.strTicket & "'," & Format(Me.DblTotal, "0.00").Replace(",", ".") & ",'" & Format(Now, "yyyy-MM-dd HH:mm:ss") & "')"

        cmd = New MySql.Data.MySqlClient.MySqlCommand(sql, My.m_db_mysql)
        cmd.ExecuteNonQuery()

        MsgBox("El credito restante de " & strName & " es de " & Format(dblCredito - Me.DblTotal, "0.00") & "" & System.Threading.Thread.CurrentThread.CurrentCulture.NumberFormat.CurrencySymbol & ".", MsgBoxStyle.Information)

        Me.swPagoTarjeta = True
        Me.DialogResult = Windows.Forms.DialogResult.OK
    End Sub

    Private Sub LblTotal_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LblTotal.DoubleClick
        My.OpenCajon()
    End Sub

    Private Sub btAnota_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btAnota.Click
        If Me.DblTotal < 0 Then
            MsgBox("Imposible cobrar un importe inferior a 0.", MsgBoxStyle.Critical)
            Exit Sub
        End If

        Me.swPagoEfectivo = (Me.CbTipo.SelectedIndex = 0)
        Me.swNota = True

        Me.DialogResult = Windows.Forms.DialogResult.OK
    End Sub
End Class