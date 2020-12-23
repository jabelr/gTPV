Public Class frmConfigurePrinter
    Private WithEvents m_Data As gDevelop.Lite.m_dataform

    Public IdRef As Integer = 0

#Region "Eventos Principales"
    Private Sub frmConfigurePrinter_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        '# Inicializo y cargo la clase de los datos y configuración de la EMPRESA 
        Me.m_Data = New gDevelop.Lite.m_dataform(My.m_db)
        Me.m_Data.DbTable = "app_printers"
        Me.m_Data.ConfigureDataForm(Me.SplitContainer.Panel2.Controls)

        

        'Dependiendo de si es nuevo o estoy cargando un registro en concreto
        If Me.IdRef = 0 Then
            Me.m_Data.data_NewField()

            Dim rst As ADODB.Recordset = My.m_db.GetRst("SELECT id FROM app_printers ORDER BY id DESC")
            Me.TxtId.Text = rst("id").Value + 1
            My.m_db.CloseRst(rst)

            Me.TxtCRReturn.Text = 10
            Me.TxtAncho.Text = 40
        Else
            'Me.m_Data.data_LoadData(Me.IdRef)
            'Me.m_Data.EditField()
            Me.m_Data.data_EditField(Me.IdRef)
        End If

        'Asigno manejadores
        Me.AddHandlers()

        My.AsignarFoco(Me.TxtName)
    End Sub
#End Region

#Region "Eventos Auxiliares"
    Private Sub frmConfigurePrinter_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated

    End Sub

    Private Sub frmConfigurePrinter_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
        If e.KeyChar = Chr(27) Then Me.DialogResult = Windows.Forms.DialogResult.Cancel
    End Sub

    Private Sub ToolStrip_Cancell_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStrip_Cancell.Click
        Me.Close()
    End Sub

    Private Sub ToolStrip_Save_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStrip_Save.Click
        If Me.TxtName.TextLength <= 0 Then
            MsgBox("Debe de establecer un nombre de impresora para poder guardar.", MsgBoxStyle.Critical)
            My.AsignarFoco(Me.TxtName)
            Exit Sub
        End If

        If Val(Me.TxtAncho.Text) < 30 Then
            MsgBox("El ancho mínimo de caractares del ticket tiene que ser igual o superior a 30.", MsgBoxStyle.Critical)
            My.AsignarFoco(Me.TxtAncho)
            Exit Sub
        End If

        Me.m_Data.data_SaveField()
        Me.DialogResult = Windows.Forms.DialogResult.OK
    End Sub

    Private Sub PicLogo_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles PicLogo.MouseDown
        If e.Button = Windows.Forms.MouseButtons.Right AndAlso e.Clicks >= 2 Then
            Me.ChkNotDelete.Visible = True
            Me.TxtOpen_6.Visible = True
            Me.TxtOpen_7.Visible = True
        End If
    End Sub
#End Region

#Region "Handlers"
    Private Sub AddHandlers()
        AddHandler Me.TxtAncho.KeyPress, AddressOf gDevelop.Lite.m_OverridesEvents.TxtValidaNumeric_KeyPress
        AddHandler Me.TxtCRReturn.KeyPress, AddressOf gDevelop.Lite.m_OverridesEvents.TxtValidaNumeric_KeyPress

        AddHandler Me.TxtInit_1.KeyPress, AddressOf gDevelop.Lite.m_OverridesEvents.TxtValidaNumeric_KeyPress
        AddHandler Me.TxtInit_2.KeyPress, AddressOf gDevelop.Lite.m_OverridesEvents.TxtValidaNumeric_KeyPress
        AddHandler Me.TxtInit_3.KeyPress, AddressOf gDevelop.Lite.m_OverridesEvents.TxtValidaNumeric_KeyPress
        AddHandler Me.TxtInit_4.KeyPress, AddressOf gDevelop.Lite.m_OverridesEvents.TxtValidaNumeric_KeyPress
        AddHandler Me.TxtInit_5.KeyPress, AddressOf gDevelop.Lite.m_OverridesEvents.TxtValidaNumeric_KeyPress


        AddHandler Me.TxtNormal_1.KeyPress, AddressOf gDevelop.Lite.m_OverridesEvents.TxtValidaNumeric_KeyPress
        AddHandler Me.TxtNormal_2.KeyPress, AddressOf gDevelop.Lite.m_OverridesEvents.TxtValidaNumeric_KeyPress
        AddHandler Me.TxtNormal_3.KeyPress, AddressOf gDevelop.Lite.m_OverridesEvents.TxtValidaNumeric_KeyPress
        AddHandler Me.TxtNormal_4.KeyPress, AddressOf gDevelop.Lite.m_OverridesEvents.TxtValidaNumeric_KeyPress
        AddHandler Me.TxtNormal_5.KeyPress, AddressOf gDevelop.Lite.m_OverridesEvents.TxtValidaNumeric_KeyPress


        AddHandler Me.TxtGrande_1.KeyPress, AddressOf gDevelop.Lite.m_OverridesEvents.TxtValidaNumeric_KeyPress
        AddHandler Me.TxtGrande_2.KeyPress, AddressOf gDevelop.Lite.m_OverridesEvents.TxtValidaNumeric_KeyPress
        AddHandler Me.TxtGrande_3.KeyPress, AddressOf gDevelop.Lite.m_OverridesEvents.TxtValidaNumeric_KeyPress
        AddHandler Me.TxtGrande_4.KeyPress, AddressOf gDevelop.Lite.m_OverridesEvents.TxtValidaNumeric_KeyPress
        AddHandler Me.TxtGrande_5.KeyPress, AddressOf gDevelop.Lite.m_OverridesEvents.TxtValidaNumeric_KeyPress


        AddHandler Me.TxtNegro_1.KeyPress, AddressOf gDevelop.Lite.m_OverridesEvents.TxtValidaNumeric_KeyPress
        AddHandler Me.TxtNegro_2.KeyPress, AddressOf gDevelop.Lite.m_OverridesEvents.TxtValidaNumeric_KeyPress
        AddHandler Me.TxtNegro_3.KeyPress, AddressOf gDevelop.Lite.m_OverridesEvents.TxtValidaNumeric_KeyPress
        AddHandler Me.TxtNegro_4.KeyPress, AddressOf gDevelop.Lite.m_OverridesEvents.TxtValidaNumeric_KeyPress
        AddHandler Me.TxtNegro_5.KeyPress, AddressOf gDevelop.Lite.m_OverridesEvents.TxtValidaNumeric_KeyPress


        AddHandler Me.TxtRed_1.KeyPress, AddressOf gDevelop.Lite.m_OverridesEvents.TxtValidaNumeric_KeyPress
        AddHandler Me.TxtRed_2.KeyPress, AddressOf gDevelop.Lite.m_OverridesEvents.TxtValidaNumeric_KeyPress
        AddHandler Me.TxtRed_3.KeyPress, AddressOf gDevelop.Lite.m_OverridesEvents.TxtValidaNumeric_KeyPress
        AddHandler Me.TxtRed_4.KeyPress, AddressOf gDevelop.Lite.m_OverridesEvents.TxtValidaNumeric_KeyPress
        AddHandler Me.TxtRed_5.KeyPress, AddressOf gDevelop.Lite.m_OverridesEvents.TxtValidaNumeric_KeyPress


        AddHandler Me.TxtCut_1.KeyPress, AddressOf gDevelop.Lite.m_OverridesEvents.TxtValidaNumeric_KeyPress
        AddHandler Me.TxtCut_2.KeyPress, AddressOf gDevelop.Lite.m_OverridesEvents.TxtValidaNumeric_KeyPress
        AddHandler Me.TxtCut_3.KeyPress, AddressOf gDevelop.Lite.m_OverridesEvents.TxtValidaNumeric_KeyPress
        AddHandler Me.TxtCut_4.KeyPress, AddressOf gDevelop.Lite.m_OverridesEvents.TxtValidaNumeric_KeyPress
        AddHandler Me.TxtCut_5.KeyPress, AddressOf gDevelop.Lite.m_OverridesEvents.TxtValidaNumeric_KeyPress


        AddHandler Me.TxtSubActivo_1.KeyPress, AddressOf gDevelop.Lite.m_OverridesEvents.TxtValidaNumeric_KeyPress
        AddHandler Me.TxtSubActivo_2.KeyPress, AddressOf gDevelop.Lite.m_OverridesEvents.TxtValidaNumeric_KeyPress
        AddHandler Me.TxtSubActivo_3.KeyPress, AddressOf gDevelop.Lite.m_OverridesEvents.TxtValidaNumeric_KeyPress
        AddHandler Me.TxtSubActivo_4.KeyPress, AddressOf gDevelop.Lite.m_OverridesEvents.TxtValidaNumeric_KeyPress
        AddHandler Me.TxtSubActivo_5.KeyPress, AddressOf gDevelop.Lite.m_OverridesEvents.TxtValidaNumeric_KeyPress


        AddHandler Me.TxtSubDesactivo_1.KeyPress, AddressOf gDevelop.Lite.m_OverridesEvents.TxtValidaNumeric_KeyPress
        AddHandler Me.TxtSubDesactivo_2.KeyPress, AddressOf gDevelop.Lite.m_OverridesEvents.TxtValidaNumeric_KeyPress
        AddHandler Me.TxtSubDesactivo_3.KeyPress, AddressOf gDevelop.Lite.m_OverridesEvents.TxtValidaNumeric_KeyPress
        AddHandler Me.TxtSubDesactivo_4.KeyPress, AddressOf gDevelop.Lite.m_OverridesEvents.TxtValidaNumeric_KeyPress
        AddHandler Me.TxtSubDesactivo_5.KeyPress, AddressOf gDevelop.Lite.m_OverridesEvents.TxtValidaNumeric_KeyPress


        AddHandler Me.TxtNegritaAct_1.KeyPress, AddressOf gDevelop.Lite.m_OverridesEvents.TxtValidaNumeric_KeyPress
        AddHandler Me.TxtNegritaAct_2.KeyPress, AddressOf gDevelop.Lite.m_OverridesEvents.TxtValidaNumeric_KeyPress
        AddHandler Me.TxtNegritaAct_3.KeyPress, AddressOf gDevelop.Lite.m_OverridesEvents.TxtValidaNumeric_KeyPress
        AddHandler Me.TxtNegritaAct_4.KeyPress, AddressOf gDevelop.Lite.m_OverridesEvents.TxtValidaNumeric_KeyPress
        AddHandler Me.TxtNegritaAct_5.KeyPress, AddressOf gDevelop.Lite.m_OverridesEvents.TxtValidaNumeric_KeyPress


        AddHandler Me.TxtNegritaDesact_1.KeyPress, AddressOf gDevelop.Lite.m_OverridesEvents.TxtValidaNumeric_KeyPress
        AddHandler Me.TxtNegritaDesact_2.KeyPress, AddressOf gDevelop.Lite.m_OverridesEvents.TxtValidaNumeric_KeyPress
        AddHandler Me.TxtNegritaDesact_3.KeyPress, AddressOf gDevelop.Lite.m_OverridesEvents.TxtValidaNumeric_KeyPress
        AddHandler Me.TxtNegritaDesact_4.KeyPress, AddressOf gDevelop.Lite.m_OverridesEvents.TxtValidaNumeric_KeyPress
        AddHandler Me.TxtNegritaDesact_5.KeyPress, AddressOf gDevelop.Lite.m_OverridesEvents.TxtValidaNumeric_KeyPress


        AddHandler Me.TxtSalto_1.KeyPress, AddressOf gDevelop.Lite.m_OverridesEvents.TxtValidaNumeric_KeyPress
        AddHandler Me.TxtSalto_2.KeyPress, AddressOf gDevelop.Lite.m_OverridesEvents.TxtValidaNumeric_KeyPress
        AddHandler Me.TxtSalto_3.KeyPress, AddressOf gDevelop.Lite.m_OverridesEvents.TxtValidaNumeric_KeyPress
        AddHandler Me.TxtSalto_4.KeyPress, AddressOf gDevelop.Lite.m_OverridesEvents.TxtValidaNumeric_KeyPress
        AddHandler Me.TxtSalto_5.KeyPress, AddressOf gDevelop.Lite.m_OverridesEvents.TxtValidaNumeric_KeyPress


        AddHandler Me.TxtOpen_1.KeyPress, AddressOf gDevelop.Lite.m_OverridesEvents.TxtValidaNumeric_KeyPress
        AddHandler Me.TxtOpen_2.KeyPress, AddressOf gDevelop.Lite.m_OverridesEvents.TxtValidaNumeric_KeyPress
        AddHandler Me.TxtOpen_3.KeyPress, AddressOf gDevelop.Lite.m_OverridesEvents.TxtValidaNumeric_KeyPress
        AddHandler Me.TxtOpen_4.KeyPress, AddressOf gDevelop.Lite.m_OverridesEvents.TxtValidaNumeric_KeyPress
        AddHandler Me.TxtOpen_5.KeyPress, AddressOf gDevelop.Lite.m_OverridesEvents.TxtValidaNumeric_KeyPress
    End Sub
#End Region

End Class