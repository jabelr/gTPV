Public Class frmFacturar_Compras
    Public IdRef As Integer = 0
    Public Id_Prov As Integer = 0

    Public Id_Factura As Integer = -1
    Public TipoFacturacion As String

#Region "Configuración"
    'Enumeracion para las columnas de la lista
    Private Enum lst_Columns
        id = 0
        fh_albaran = 1
        albaran = 2
        base_general = 3
        base_medio = 4
        base_basico = 5
        iva_general = 6
        iva_medio = 7
        iva_basico = 8
        total = 9
    End Enum
#End Region

#Region "Eventos Principales"
    Private Sub frmFacturar_Compras_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        LoadAlbaranes()

        CalcularTotales()

        Me.LblIVA_General.Text = My.m_opt.IVA_General
        Me.LblIVA_Medio.Text = My.m_opt.IVA_Medio
        Me.LblIVA_Basico.Text = My.m_opt.IVA_Basico

        'recargo los datoss de la factura
        'If Me.Id_Factura <> 0 Then LoadDataFact()
    End Sub
#End Region

#Region "Eventos Auxiliares"
    Private Sub BtOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtOk.Click
        If Me.TxtFactura.TextLength <= 0 Then
            MsgBox("Debe de establecer un número de factura para poder facturar los albaranes.", MsgBoxStyle.Exclamation)
            My.AsignarFoco(Me.TxtFactura)
            Exit Sub
        End If
        If MsgBox("¿Esta seguro de que desea facturar los albaranes seleccionados?", MsgBoxStyle.OkCancel + MsgBoxStyle.Question, "Facturar Albaranes") = MsgBoxResult.Cancel Then Exit Sub
        Me.GenerarFactura()
        Me.DialogResult = Windows.Forms.DialogResult.OK
    End Sub

    Private Sub BtCancell_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtCancell.Click
        Me.Close()
    End Sub

    Private Sub LstAlbaranes_ItemCheck(ByVal sender As Object, ByVal e As System.Windows.Forms.ItemCheckEventArgs) Handles LstAlbaranes.ItemCheck
        If Me.LstAlbaranes.Items(e.Index).Text = Me.IdRef AndAlso e.NewValue = CheckState.Unchecked Then e.NewValue = CheckState.Checked
        LstAlbaranes.Items(e.Index).ImageIndex = IIf(e.NewValue = CheckState.Checked, 1, 0)
        CalcularTotales()
    End Sub
#End Region

#Region "m_Work"
    Private Sub GenerarFactura()
        Dim RstFactura As ADODB.Recordset = My.m_db.GetRst("SELECT * FROM db_facturas_compra where id=" & Me.Id_Factura)

        If Me.Id_Factura = 0 Then RstFactura.AddNew()

        RstFactura("id_proveedor").Value = Me.Id_Prov
        RstFactura("id_contable").Value = My.m_app.GetValue("id_contable")

        RstFactura("fh_alta").Value = Format(Now, "dd/MM/yyyy")
        RstFactura("fh_update").Value = Now

        RstFactura("tipo").Value = Me.TipoFacturacion
        RstFactura("n_factura").Value = Me.TxtFactura.Text
        RstFactura("fh_factura").Value = Format(Me.DtFactura.Value, "dd/MM/yyyy")

        RstFactura("base_general").Value = CDbl(Me.LblPvp_Base_General.Text)
        RstFactura("base_medio").Value = CDbl(Me.LblPvp_Base_Medio.Text)
        RstFactura("base_basico").Value = CDbl(Me.LblPvp_Base_Basico.Text)

        RstFactura("iva_general").Value = CDbl(Me.LblPvp_Iva_General.Text)
        RstFactura("iva_medio").Value = CDbl(Me.LblPvp_Iva_Medio.Text)
        RstFactura("iva_basico").Value = CDbl(Me.LblPvp_Iva_Basico.Text)

        RstFactura("total_general").Value = CDbl(Me.LblPvp_Total_General.Text)
        RstFactura("total_medio").Value = CDbl(Me.LblPvp_Total_Medio.Text)
        RstFactura("total_basico").Value = CDbl(Me.LblPvp_Total_Basico.Text)


        RstFactura("total").Value = CDbl(Me.LblPvp_Total.Text)

        RstFactura("obs").Value = Me.TxtObs.Text & ""
        RstFactura.Update()

        Dim id_Aux As Integer = RstFactura("id").Value
        My.m_db.CloseRst(RstFactura)

        'Actualizo los albaranes
        Dim i As Integer, StrAux As String = ""
        For i = 0 To Me.LstAlbaranes.Items.Count - 1
            If Me.LstAlbaranes.Items(i).ImageIndex = 1 Then StrAux &= " (id=" & Me.LstAlbaranes.Items(i).Text & ") OR"
        Next

        StrAux = StrAux.Substring(0, StrAux.Length - 2)
        My.m_db.Execute("UPDATE db_albaranes_compra SET estado='FACTURA',id_factura=" & id_Aux & " WHERE " & StrAux)

    End Sub

    Private Sub LoadAlbaranes()
        Dim i As Integer = 0
        Dim RstAux As ADODB.Recordset
        Dim StrSQL As String = "Select * from db_albaranes_compra where estado='ALBARAN' AND "
        StrSQL &= "id_contable=" & My.m_app.GetValue("id_contable") & " AND id_proveedor=" & Me.Id_Prov & " AND "
        StrSQL &= " id_factura=" & Me.Id_Factura & " AND tipo='" & Me.TipoFacturacion & "'"
        StrSQL &= " order by fh_albaran desc"

        'Cargo los albaranes sin facturar del proveedor 
        RstAux = My.m_db.GetRst(StrSQL)
        While Not RstAux.EOF

            LstAlbaranes.Items.Add(RstAux("id").Value)
            LstAlbaranes.Items(i).SubItems.Add(Format(RstAux("fh_albaran").Value, "dd/MM/yyyy"))
            LstAlbaranes.Items(i).SubItems.Add(RstAux("n_albaran").Value)

            LstAlbaranes.Items(i).SubItems.Add(RstAux("base_general").Value)
            LstAlbaranes.Items(i).SubItems.Add(RstAux("base_medio").Value)
            LstAlbaranes.Items(i).SubItems.Add(RstAux("base_basico").Value)

            LstAlbaranes.Items(i).SubItems.Add(RstAux("iva_general").Value)
            LstAlbaranes.Items(i).SubItems.Add(RstAux("iva_medio").Value)
            LstAlbaranes.Items(i).SubItems.Add(RstAux("iva_basico").Value)

            LstAlbaranes.Items(i).SubItems.Add(RstAux("total").Value)

            LstAlbaranes.Items(i).ImageIndex = 0
            If LstAlbaranes.Items(i).Text = Me.IdRef OrElse (RstAux("id_factura").Value <> 0 AndAlso RstAux("id_factura").Value = Me.Id_Factura) Then           'Es el actual
                LstAlbaranes.Items(i).Checked = True
                LstAlbaranes.Items(i).ImageIndex = 1
                LstAlbaranes.Items(i).Font = New Font(LstAlbaranes.Font, FontStyle.Bold)
            End If
            i += 1
            RstAux.MoveNext()
        End While
        My.m_db.CloseRst(RstAux)
    End Sub

    Private Sub CalcularTotales()
        Dim i As Integer = 0, DblBase_General As Double = 0, DblBase_Medio As Double = 0, DblBase_Basico As Double = 0
        Dim DblIVA_General As Double = 0, DblIVA_Medio As Double = 0, DblIVA_Basico As Double = 0
        Dim DblTotal As Double = 0

        For i = 0 To Me.LstAlbaranes.Items.Count - 1
            If LstAlbaranes.Items(i).ImageIndex = 1 Then
                DblBase_General += CDbl(Me.LstAlbaranes.Items(i).SubItems(lst_Columns.base_general).Text)
                DblBase_Medio += CDbl(Me.LstAlbaranes.Items(i).SubItems(lst_Columns.base_medio).Text)
                DblBase_Basico += CDbl(Me.LstAlbaranes.Items(i).SubItems(lst_Columns.base_basico).Text)

                DblIVA_General += CDbl(Me.LstAlbaranes.Items(i).SubItems(lst_Columns.iva_general).Text)
                DblIVA_Medio += CDbl(Me.LstAlbaranes.Items(i).SubItems(lst_Columns.iva_medio).Text)
                DblIVA_Basico += CDbl(Me.LstAlbaranes.Items(i).SubItems(lst_Columns.iva_basico).Text)

                DblTotal += CDbl(Me.LstAlbaranes.Items(i).SubItems(lst_Columns.total).Text)
            End If
        Next

        '#Compongo los importes
        Me.LblPvp_Base_General.Text = Format(DblBase_General, "0.00")
        Me.LblPvp_Base_Medio.Text = Format(DblBase_Medio, "0.00")
        Me.LblPvp_Base_Basico.Text = Format(DblBase_Basico, "0.00")

        Me.LblPvp_Iva_General.Text = Format(DblIVA_General, "0.00")
        Me.LblPvp_Iva_Medio.Text = Format(DblIVA_Medio, "0.00")
        Me.LblPvp_Iva_Basico.Text = Format(DblIVA_Basico, "0.00")

        Me.LblPvp_Total_General.Text = Format(DblBase_General + DblIVA_General, "0.00")
        Me.LblPvp_Total_Medio.Text = Format(DblBase_Medio + DblIVA_Medio, "0.00")
        Me.LblPvp_Total_Basico.Text = Format(DblBase_Basico + DblIVA_Basico, "0.00")

        'Calculo el total totalisimo
        Me.LblPvp_Total.Text = Format(DblTotal, "0.00")
    End Sub

    'Private Sub LoadDataFact()
    '    Dim RstAux As ADODB.Recordset = My.Application.m_Db.GetRst("Select * from facturas where id=" & Me.Id_Factura)
    '    If RstAux.EOF Then Exit Sub
    '    Me.LblFactura.Text = RstAux("factura").Value
    '    DtFactura.Value = Format(RstAux("fh_factura").Value, "dd/MM/yyyy")
    '    Me.TxtObs.Text = RstAux("obs").Value
    '    Me.ChkIncluirBancos.Checked = RstAux("sw_incluirdatosbancarios").Value
    '    My.Application.m_Db.CloseRst(RstAux)

    '    Me.LblFactura.Visible = True
    'End Sub
#End Region


End Class