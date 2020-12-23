Imports System.IO
Public Class frmCajas_CerrarCaja
    Public IdCaja As Integer = -1

    'Por si deseo cerrar los tickets que estoy mostrando 
    'Public fhStart As Date
    'Public fhEnd As Date

#Region "Eventos Principales"

    Private Sub frmCajas_CerrarCaja_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        If (Not IsNothing(m_KeyBoard)) Then m_KeyBoard.Close()
    End Sub

    Private Sub frmCajas_CerrarCaja_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Select Case e.KeyCode
            Case Keys.Escape
                If Not m_KeyBoard Is Nothing Then
                    m_KeyBoard.Dispose()
                    Exit Select
                End If
                'Me.Dispose()
        End Select
    End Sub

    Private Sub frmCajas_CerrarCaja_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ''Cargo datos de información
        'Dim rst As ADODB.Recordset = My.m_db.GetRst("SELECT count(id) AS n_tot FROM db_tickets WHERE  estado<>'PENDIENTE' AND id_caja=-1")
        'Me.LblNTickets.Text = rst("n_tot").Value
        'My.m_db.CloseRst(rst)

        'rst = My.m_db.GetRst("SELECT sum(total) as tot FROM db_tickets WHERE  estado='FINALIZADO' AND id_caja=-1")
        'Me.LblTotalReal.Text = Format(rst("tot").Value, "0.00")
        'Me.TxtTotal.Text = Format(rst("tot").Value, "0.00")
        'My.m_db.CloseRst(rst)
        Dim rst As ADODB.Recordset = Nothing

        Me.LoadInfo()

        If IdCaja = -1 Then

            Me.fhCierre.Value = Now

            If My.m_opt.fechaCierreOnDate Then

            Else
                'Obtengo el primer ticket de la caja
                rst = My.m_db.GetRst("SELECT id,fh_alta FROM db_tickets WHERE estado='FINALIZADO' AND id_caja=" & IdCaja & " ORDER BY id ASC")
                If rst.RecordCount > 0 Then
                    Me.lblFirstTicket.Text = Format(rst("fh_alta").Value, "dd/MM/yyyy HH:mm")
                    Me.fhCierre.Value = rst("fh_alta").Value
                End If

                My.m_db.CloseRst(rst)

            End If



            'Obtengo el numero de caja siguiente
            Dim str As String = ""
            rst = My.m_db.GetRst("SELECT caja_serie,caja_contador FROM app_contabilidad WHERE id=" & My.m_app.GetValue("id_contable"))
            Me.TxtName.Text = Format(fhCierre.Value, "yy") & "/" & CStr(rst("caja_serie").Value).ToUpper & Format(rst("caja_contador").Value, "0000")
        Else
            'Cargo la caja establecida
            rst = My.m_db.GetRst("SELECT * FROM db_cajas WHERE id=" & IdCaja & " ORDER BY id ASC")
            If rst.RecordCount > 0 Then
                Me.lblFirstTicket.Visible = False
                Me.TxtName.Text = rst("name").Value
                Me.fhCierre.Value = rst("fh_alta").Value
                Me.txtApertura.Text = rst("inicio_caja").Value
            End If

            My.m_db.CloseRst(rst)
        End If
        My.AsignarFoco(Me.TxtName)

        'Asigno Handlers
        AddHandler Me.TxtTotal.KeyPress, AddressOf gDevelop.Lite.m_OverridesEvents.TxtValidaEuro_KeyPress
        AddHandler Me.TxtPorc.KeyPress, AddressOf gDevelop.Lite.m_OverridesEvents.TxtValidaNumeric_KeyPress

        AddHandler Me.txtApertura.KeyPress, AddressOf gDevelop.Lite.m_OverridesEvents.TxtValidaEuro_KeyPress


    End Sub
#End Region

#Region "Eventos Auxiliares"
    Private Sub evtButtons_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtCancell.Click, BtCierre.Click
        Select Case True
            Case sender Is Me.BtCierre
                If MsgBox("¿Esta seguro de que desea cerrar la Caja Actual?", MsgBoxStyle.YesNo + MsgBoxStyle.Question) <> MsgBoxResult.Yes Then Exit Sub

                Dim swNewCaja As Boolean = False

                'Creo una nueva Caja
                Dim rst As ADODB.Recordset = My.m_db.GetRst("SELECT * FROM db_cajas WHERE id=" & Me.IdCaja)
                If Me.IdCaja = -1 Then
                    rst.AddNew()
                    rst("ncaja").Value = My.Get_Contador("CAJA")

                    swNewCaja = True
                End If

                rst("id_contable").Value = My.m_app.GetValue("id_contable")
                rst("name").Value = Me.TxtName.Text

                rst("fh_alta").Value = Me.fhCierre.Value.ToString("dd/MM/yyyy")
                rst("n_tickets").Value = Me.LblNTickets.Text
                If IsNumeric(Me.txtApertura.Text) Then rst("inicio_caja").Value = CDbl(Me.txtApertura.Text) 'El total ajustad
                rst("total").Value = CDbl(Me.TxtTotal.Text)           'El total ajustad
                rst("total_real").Value = CDbl(Me.LblTotalReal.Text)           'El total ajustado
                rst("total_banco").Value = CDbl(Me.lblTotalBanco.Text)           'El total del banco


                'Ajusto los importes desglosados
                rst("general_base").Value = CDbl(Me.LblPvp_Base_General.Text)
                rst("medio_base").Value = CDbl(Me.LblPvp_Base_Medio.Text)
                rst("basico_base").Value = CDbl(Me.LblPvp_Base_Basico.Text)

                rst("general_iva").Value = CDbl(Me.LblPvp_Iva_General.Text)
                rst("medio_iva").Value = CDbl(Me.LblPvp_Iva_Medio.Text)
                rst("basico_iva").Value = CDbl(Me.LblPvp_Iva_Basico.Text)

                rst("general_total").Value = CDbl(Me.LblPvp_Total_General.Text)
                rst("medio_total").Value = CDbl(Me.LblPvp_Total_Medio.Text)
                rst("basico_total").Value = CDbl(Me.LblPvp_Total_Basico.Text)

                rst.Update()

                Me.IdCaja = rst("id").Value
                My.m_db.CloseRst(rst)

                If swNewCaja Then
                    'Actualizo valores de los tickets y usuarios
                    My.m_db.Execute("UPDATE db_tickets SET id_caja=" & Me.IdCaja & " WHERE estado<>'PENDIENTE' AND id_caja=-1" & IIf(Me.ChkFiltra.Checked, "", ""))
                    My.m_db.Execute("UPDATE db_cajas_acceso SET id_caja=" & Me.IdCaja & " WHERE id_caja=-1")
                    My.m_db.Execute("UPDATE db_cajas_entradas SET id_caja=" & Me.IdCaja & " WHERE id_caja=-1")
                End If

                Me.DialogResult = Windows.Forms.DialogResult.OK

            Case sender Is Me.BtCancell
                Me.Close()
        End Select
    End Sub

    Private Sub LblName_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles LblName.DoubleClick
        Me.Group_B.Visible = True
    End Sub

    Private Sub BtReduceCaja_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtReduceCaja.Click
        If Not IsNumeric(Me.TxtPorc.Text) Then Me.TxtPorc.Text = 0
        Me.TxtTotal.Text = Format(Me.LblTotalReal.Text - ((Me.LblTotalReal.Text * Me.TxtPorc.Text) / 100), "0.00")
    End Sub

    Private Sub ChkFiltra_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChkFiltra.CheckedChanged
        Me.LoadInfo()
    End Sub
#End Region

#Region "Funciones"
    Private Sub LoadInfo()
        '### Cargo datos de información

        'Numero de ticket totales
        Dim rst As ADODB.Recordset = My.m_db.GetRst("SELECT count(id) AS n_tot FROM db_tickets WHERE id_user<>-3 AND estado<>'PENDIENTE' AND NOT tipo AND id_caja=" & Me.IdCaja)
        Me.LblNTickets.Text = rst("n_tot").Value
        My.m_db.CloseRst(rst)

        'Numero de tickets cancelados
        rst = My.m_db.GetRst("SELECT count(id) AS n_tot FROM db_tickets WHERE id_user<>-3 AND estado='CANCELADO' AND NOT tipo AND id_caja=" & Me.IdCaja)
        Me.lblNTickets_C.Text = rst("n_tot").Value
        My.m_db.CloseRst(rst)

        'Numero de tickets cancelados
        rst = My.m_db.GetRst("SELECT count(id) AS n_tot FROM db_tickets WHERE id_user<>-3 AND estado='FACTURADO' AND NOT tipo AND id_caja=" & Me.IdCaja)
        Me.LblNTickets_F.Text = rst("n_tot").Value
        My.m_db.CloseRst(rst)

        rst = My.m_db.GetRst("SELECT sum(total) as tot FROM db_tickets WHERE id_user<>-3 AND (estado='FINALIZADO' OR estado='FACTURADO') AND NOT tipo AND id_caja=" & Me.IdCaja)
        If IsDBNull(rst("tot").Value) Then
            Me.LblTotalReal.Text = Format(0, "0.00")
            Me.TxtTotal.Text = Format(0, "0.00")
        Else
            Me.LblTotalReal.Text = Format(rst("tot").Value, "0.00")
            Me.TxtTotal.Text = Format(rst("tot").Value, "0.00")
        End If
        My.m_db.CloseRst(rst)


        'Obtengo el pago por tarjeta
        rst = My.m_db.GetRst("SELECT sum(total) as tot FROM db_tickets WHERE id_user<>-3 AND (estado='FINALIZADO' OR estado='FACTURADO') AND NOT tipo AND id_caja=" & Me.IdCaja & " AND tipo_cobro='TARJETA'")
        If IsDBNull(rst("tot").Value) Then
            Me.lblTotalBanco.Text = Format(0, "0.00")
        Else
            Me.lblTotalBanco.Text = Format(rst("tot").Value, "0.00")
        End If
        My.m_db.CloseRst(rst)

        'Obtengo el importe toltal facturado
        rst = My.m_db.GetRst("SELECT sum(total) as tot FROM db_tickets WHERE id_user<>-3 AND estado='FACTURADO' AND NOT tipo AND id_caja=" & Me.IdCaja)
        If IsDBNull(rst("tot").Value) Then
            Me.lblTotalFactura.Text = Format(0, "0.00")
        Else
            Me.lblTotalFactura.Text = Format(rst("tot").Value, "0.00")
        End If
        My.m_db.CloseRst(rst)



        '# OBTENGO IMPORTES DESGLOSADOS
        Dim rstTmp As ADODB.Recordset = Nothing, rstLines As ADODB.Recordset = Nothing
        Dim dblBase_4 As Double, dblBase_7 As Double = 0, dblBase_16 As Double = 0
        Dim dblIVA_4 As Double = 0, dblIVA_7 As Double = 0, dblIVA_16 As Double = 0

        'Cargo los tickets de la caja actual
        rstTmp = My.m_db.GetRst("SELECT db_tickets.id,db_tickets.total FROM db_tickets WHERE db_tickets.id_caja=" & Me.IdCaja & " AND id_user<>-3 AND NOT tipo AND (estado='FINALIZADO' OR estado='FACTURADO') ORDER BY id ASC")

        dblBase_4 = 0
        dblBase_7 = 0
        dblBase_16 = 0

        Dim dblAux As Double = 0

        While Not rstTmp.EOF
            'Cargo lineas
            rstLines = My.m_db.GetRst("SELECT * FROM db_tickets_lines WHERE id_ticket=" & rstTmp("id").Value & " ORDER BY id")
            dblAux = 0
            While Not RstLines.EOF
                Select Case RstLines("iva").Value
                    Case My.m_opt.IVA_General : dblBase_16 += Format((rstLines("pvp_base").Value * rstLines("ud").Value), "0.00#####")
                    Case My.m_opt.IVA_Medio : dblBase_7 += Format((rstLines("pvp_base").Value * rstLines("ud").Value), "0.00#####")
                    Case My.m_opt.IVA_Basico : dblBase_4 += Format((rstLines("pvp_base").Value * rstLines("ud").Value), "0.00#####")
                End Select

                dblAux += rstLines("total").Value

                rstLines.MoveNext()
            End While
            'If Format(dblAux, "0.00") <> rstTmp("total").Value Then
            '    MsgBox("liebre")
            'End If

            'If CDbl(Format(dblBase_7 * 1.1, "0.00")) + CDbl(Format(dblBase_16 * 1.21, "0.00")) <> rstTmp("total").Value Then
            '    MsgBox("liebre1")
            'End If


            My.m_db.CloseRst(rstLines)

            rstTmp.MoveNext()
        End While
        My.m_db.CloseRst(rstTmp)

        'Ajusto las bases imponibles
        dblBase_4 = Format(dblBase_4, "0.00###")
        dblBase_7 = Format(dblBase_7, "0.00###")
        dblBase_16 = Format(dblBase_16, "0.00###")

        'Calculo el importe de iva
        dblIVA_4 = Format(((dblBase_4 * My.m_opt.IVA_Basico) / 100), "0.00")
        dblIVA_7 = Format(((dblBase_7 * My.m_opt.IVA_Medio) / 100), "0.00")
        dblIVA_16 = Format(((dblBase_16 * My.m_opt.IVA_General) / 100), "0.00")

        'Establezco los importes
        Me.LblPvp_Base_Basico.Text = Format(dblBase_4, "0.00#####")
        Me.LblPvp_Base_Medio.Text = Format(dblBase_7, "0.00#####")
        Me.LblPvp_Base_General.Text = Format(dblBase_16, "0.00#####")

        Me.LblPvp_Iva_Basico.Text = Format(dblIVA_4, "0.00")
        Me.LblPvp_Iva_Medio.Text = Format(dblIVA_7, "0.00")
        Me.LblPvp_Iva_General.Text = Format(dblIVA_16, "0.00")

        Me.LblPvp_Total_Basico.Text = Format(dblBase_4 + dblIVA_4, "0.00")
        Me.LblPvp_Total_Medio.Text = Format(dblBase_7 + dblIVA_7, "0.00")
        Me.LblPvp_Total_General.Text = Format(dblBase_16 + dblIVA_16, "0.00")



    End Sub
#End Region


    Private Sub KeyBoard_Press(ByVal key As String)
        Select Case True
            Case Me.txtApertura.Focus
                Select Case key
                    Case "SPACE"
                        Exit Select
                    Case "DEL"
                        If Me.txtApertura.TextLength = 0 Then
                            m_KeyBoard.Activate()
                            Exit Sub
                        End If
                        Me.txtApertura.Text = Me.txtApertura.Text.Substring(0, Me.txtApertura.Text.Length - 1)
                        Me.txtApertura.SelectionStart = Me.txtApertura.TextLength
                        m_KeyBoard.Activate()
                        Exit Sub
                    Case "OK"
                        'BtFilter_Click(Me.BtFilter, New EventArgs)
                        m_KeyBoard.Close()
                        m_KeyBoard.Dispose()
                        'm_KeyBoard.Visible=
                        Exit Sub

                    Case ","
                        Me.txtApertura.Text &= key
                        Me.txtApertura.SelectionStart = Me.txtApertura.TextLength

                End Select
                If Not IsNumeric(key) Then Exit Sub
                Me.txtApertura.Text &= key
                Me.txtApertura.SelectionStart = Me.txtApertura.TextLength

                m_KeyBoard.Activate()
        End Select


        'Me.Focus()
    End Sub

    Private Sub txtApertura_MouseClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles txtApertura.MouseClick
        AddHandler m_KeyBoard.KeyBoard_Press, AddressOf KeyBoard_Press

        m_KeyBoard.Left = (Screen.PrimaryScreen.WorkingArea.Width - m_KeyBoard.Width) / 2
        m_KeyBoard.Top = Screen.PrimaryScreen.WorkingArea.Height - m_KeyBoard.Height - My.APP_NUMBER
        m_KeyBoard.Show()
        My.AsignarFoco(Me.TxtTotal)
    End Sub
End Class