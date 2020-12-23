Public Class frmProveedores_Facturas
    Public Id_Prov As Integer = 0
    Public Id_Ref As Integer = 0

    Private m_Data As gDevelop.Lite.m_dataform

#Region "Eventos Principales"
    Private Sub frmProveedores_Facturas_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        '####### Cargo la configuración de las lineas de facturas de proveedores
        Me.m_Data = New gDevelop.Lite.m_dataform(My.m_db)
        Me.m_Data.DbTable = "db_proveedores_facturas"
        Me.m_Data.ConfigureDataForm(Me.Controls)

        If Me.Id_Ref = 0 Then           'Caso del nuevo
            'Establezco estados
            Me.LblFh_Alta_nfo.Visible = False
            Me.LblFh_Alta.Visible = False

            Me.m_Data.data_NewField()

            'Preconfiguro valores 
            Me.DtFh_Compra.Value = Now
            Me.DtFh_Factura.Value = Now

            Me.TxtId_Contable.Text = My.m_app.GetValue("id_contable")
            Me.TxtId_Proveedor.Text = Me.Id_Prov


        Else      'Caso de la edicion
            Me.m_Data.data_EditField(Me.Id_Ref)
        End If

        Me.AddHandlers()
        Me.CalcularTotales()
    End Sub
#End Region

    Private Sub Buttons_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtOk.Click, BtCancell.Click
        Select Case True
            Case sender Is Me.BtOk
                If Me.TxtFactura.TextLength = 0 Then
                    My.m_msg.MessageError(Me, "Imposible guardar, no se ha especificado un número de factura correcto.")
                    Exit Sub
                End If
                Me.CalcularTotales()

                Me.m_Data.data_SaveField()
                Me.DialogResult = Windows.Forms.DialogResult.OK


            Case sender Is Me.BtCancell
                Me.Close()
        End Select
    End Sub


    'Funcion para calcular y validar totales
    Private Sub CalcularTotales()
        '' Calculo el 16% de IVA
        'If Not IsNumeric(Me.TxtBase_16.Text) Then Me.TxtBase_16.Text = 0
        'Me.TxtBase_16.Text = Format(CDbl(Me.TxtBase_16.Text), "0.00")
        'Me.TxtIVA_16.Text = Format((Me.TxtBase_16.Text * My.IVA_16) / 100, "0.00")
        'Me.TxtImporte_16.Text = Format(CDbl(Me.TxtBase_16.Text) + CDbl(Me.TxtIVA_16.Text), "0.00")

        'Me.LblIVA_16.Text = Me.TxtIVA_16.Text
        'Me.LblTotal_16.Text = Me.TxtImporte_16.Text


        '' Calculo el 7% de IVA
        'If Not IsNumeric(Me.TxtBase_7.Text) Then Me.TxtBase_7.Text = 0
        'Me.TxtBase_7.Text = Format(CDbl(Me.TxtBase_7.Text), "0.00")
        'Me.TxtIVA_7.Text = Format((Me.TxtBase_7.Text * My.IVA_7) / 100, "0.00")
        'Me.TxtImporte_7.Text = Format(CDbl(Me.TxtBase_7.Text) + CDbl(Me.TxtIVA_7.Text), "0.00")

        'Me.LblIVA_7.Text = Me.TxtIVA_7.Text
        'Me.LblTotal_7.Text = Me.TxtImporte_7.Text

        ' Calculo el mega total
        Me.TxtTotal.Text = Format(CDbl(Me.TxtImporte_7.Text) + CDbl(Me.TxtImporte_16.Text), "0.00")
        Me.LblTotal.Text = Me.TxtTotal.Text

    End Sub

#Region "Handlers"
    Private Sub AddHandlers()
        AddHandler Me.TxtBase_7.KeyPress, AddressOf gDevelop.Lite.m_OverridesEvents.TxtValidaEuro_KeyPress
        AddHandler Me.TxtBase_16.KeyPress, AddressOf gDevelop.Lite.m_OverridesEvents.TxtValidaEuro_KeyPress
    End Sub
#End Region

    Private Sub TxtBase_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtBase_7.LostFocus, TxtBase_16.LostFocus
        Me.CalcularTotales()
    End Sub

End Class