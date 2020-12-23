Public Class frmSelect_Talla
    'Referencia de linea
    Public IdRef As Integer = 0
    Public Id_Categoria As Integer = 0

#Region "Eventos Principales"

    Private Sub frmSelect_Talla_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        Me.LstTalla.Select()
    End Sub

    Private Sub frmSelect_Talla_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        'Agrego las tallas
        Me.LstTalla.Items.Add("35")
        Me.LstTalla.Items.Add("36")
        Me.LstTalla.Items.Add("37")
        Me.LstTalla.Items.Add("38")
        Me.LstTalla.Items.Add("39")
        Me.LstTalla.Items.Add("40")
        Me.LstTalla.Items.Add("41")


        Me.LstTalla.SetSelected(0, True)
        Me.LstTalla.Select()

        ''Configuro el data y muestro
        'Me.m_Data = New gDevelop.ClassData_Mdb(Me, My.Application.m_Db, "SELECT * FROM categorias_sub WHERE id=")
        'Me.m_Data.BackColorOnFocus = Color.FromArgb(238, 238, 238)


        'If Me.IdRef = 0 Then              'Nuevo
        '    Me.LblTitle.Text = "NUEVA SUB-CATEGORÍA"

        '    Me.m_Data.NewField()


        '    Me.TxtId_Categoria.Text = Me.Id_Categoria
        '    Me.TxtName.Text = ""

        'Else
        '    Me.m_Data.LoadData(Me.IdRef)
        '    Me.m_Data.EditField()
        '    Me.LblTitle.Text = "EDICIÓN DE LINEA SUB-CATEGORÍA"
        'End If



        Me.AddHandlers()

    End Sub
#End Region

#Region "Eventos Auxiliares"
    Private Sub frmSelect_Talla_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then Me.Close()
        If e.Control AndAlso e.KeyCode = Keys.G Then ToolStrip_Save_Click(Me.BtExport, New System.EventArgs)
    End Sub

    'Guardo los valores
    Private Sub ToolStrip_Save_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtExport.Click
        Me.DialogResult = Windows.Forms.DialogResult.OK
    End Sub

    Private Sub ToolStrip_Cancell_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStrip_Cancell.Click
        Me.Close()
    End Sub

    Private Sub LstPob_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles LstTalla.KeyPress
        If e.KeyChar = Chr(13) Then Me.DialogResult = Windows.Forms.DialogResult.OK
    End Sub
#End Region


#Region "Handlers"
    Private Sub AddHandlers()

        AddHandler Me.txtTalla_35.KeyPress, AddressOf gDevelop.m_OverridesEvents.TxtValidaNumeric_KeyPress
        AddHandler Me.txtTalla_36.KeyPress, AddressOf gDevelop.m_OverridesEvents.TxtValidaNumeric_KeyPress
        AddHandler Me.txtTalla_37.KeyPress, AddressOf gDevelop.m_OverridesEvents.TxtValidaNumeric_KeyPress
        AddHandler Me.txtTalla_38.KeyPress, AddressOf gDevelop.m_OverridesEvents.TxtValidaNumeric_KeyPress
        AddHandler Me.txtTalla_39.KeyPress, AddressOf gDevelop.m_OverridesEvents.TxtValidaNumeric_KeyPress
        AddHandler Me.txtTalla_40.KeyPress, AddressOf gDevelop.m_OverridesEvents.TxtValidaNumeric_KeyPress
        AddHandler Me.txtTalla_41.KeyPress, AddressOf gDevelop.m_OverridesEvents.TxtValidaNumeric_KeyPress
    End Sub
#End Region
End Class