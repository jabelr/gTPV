Public Class frmCompras_SelectProv
    Public IdRef As Integer = -1                                        'El ticket sobre el que actuamos
    Private WithEvents m_data As gDevelop.Lite.m_dataform

    Private _app As String = ""             'El modulo que cargamos por defecto

#Region "Funciones"
    ''' <summary>Funcion para configurar el origen de datos</summary>
    Public Function ConfigureApp(ByVal app As String) As Boolean
        Me._app = app
        Me.m_data = New gDevelop.Lite.m_dataform(My.m_db)

        'Si no localiza la configuracion no continuo
        If Not Me.m_data.GetConfiguration(Me._app) Then
            My.m_msg.MessageError(Me.m_data, "Configuración de shell no encontrada")
            Return False
        End If

        'Establezco valores de configuracion
        Me.LblTitle.Text = Me.m_data.cfg_GetValue("title")
        Me.LblSubTitle.Text = Me.m_data.cfg_GetValue("subtitle")

        ' Establezco los valores condicionales
        Me.m_data.combo_SetFilters(Me.CbFilter)
        'Me.m_data.combo_AddConditionalFilters(Me.CbConditionalFilter)

        'Configuro el grid con valores por defecto
        Me.m_data.grid_Configure(Me.datagrid, 20)

        'Cargo origen de datos por defecto y chequeo estados
        Me.datagrid.DataSource = Me.m_data.grid_GetDataSource

        Me.m_data.ConfigureDataForm(Me.PnlNewClient.Controls)
        Return True
    End Function


    ' Fucnion que me establece el estado de los botones
    Private Sub CheckStates()
        ' Obtengo el registro por el que veo del total de registros (NofM)
        Dim index As Integer = 0
        If Me.datagrid.SelectedRows.Count > 0 Then index = Me.datagrid.SelectedRows(0).Index + 1

        Me.LblNofM.Text = index & "/" & Me.datagrid.Rows.Count

        'Configuro los botones de movimiento de registros
        Me.BtFirst.Enabled = Not (index <= 1)
        Me.BtPrevious.Enabled = Not (index <= 1)
        Me.BtNext.Enabled = Not (index = Me.datagrid.Rows.Count)
        Me.BtLast.Enabled = Not (index = Me.datagrid.Rows.Count)

        Me.BtSelect.Enabled = (Me.datagrid.RowCount > 0)
       End Sub
#End Region

#Region "Manejadores"
    'Manejador Principal (Shell)
    Private Sub ShellApp(ByVal command As String)
        Dim cmd As String = command.ToUpper

        'Antes de iniciar cualquier opcion compruebo si la demo es valida (fix change fh)
        Select Case cmd
            Case "GENERAR"
                If Me.datagrid.SelectedRows.Count <= 0 Then Exit Select
                If MsgBox("¿Esta seguro de que desea generar un albarán para el proveedor '" & Me.datagrid.SelectedRows(0).Cells(1).Value & "'?", MsgBoxStyle.OkCancel + MsgBoxStyle.Question, My.APP_NAME) <> MsgBoxResult.Ok Then Exit Select
                Me.IdRef = Me.datagrid.SelectedRows(0).Cells(0).Value
                Me.DialogResult = Windows.Forms.DialogResult.OK

            Case "NEW_OK"
                If MsgBox("¿Esta seguro de que desea generar el albaran de compra con los datos que ha establecido?", MsgBoxStyle.OkCancel + MsgBoxStyle.Question) <> MsgBoxResult.Ok Then Exit Select
                Me.IdRef = Me.m_data.data_SaveField
                Me.DialogResult = Windows.Forms.DialogResult.OK

            Case "NEW_CANCELL"
                Me.Tab.SelectedTab = Me.TabPage_Lista

            Case "FIRST"
                Me.datagrid.CurrentCell = Me.datagrid.Rows(0).Cells(0)
                Me.CheckStates()

                Me.m_data.data_LoadField(Me.datagrid.CurrentRow.Cells(0).Value)

            Case "PREVIOUS"
                If Me.datagrid.CurrentRow.Index <> 0 Then Me.datagrid.CurrentCell = Me.datagrid.Rows(Me.datagrid.CurrentRow.Index - 1).Cells(0)
                Me.CheckStates()

                Me.m_data.data_LoadField(Me.datagrid.CurrentRow.Cells(0).Value)

            Case "NEXT"
                'If Me.datagrid.CurrentRow.Index = Me.datagrid.Rows.Count - 1 Then Exit Select
                Me.datagrid.CurrentCell = Me.datagrid.Rows(Me.datagrid.CurrentRow.Index + 1).Cells(0)
                Me.CheckStates()

                Me.m_data.data_LoadField(Me.datagrid.CurrentRow.Cells(0).Value)

            Case "LAST"
                Me.datagrid.CurrentCell = Me.datagrid.Rows(Me.datagrid.Rows.Count - 1).Cells(0)
                Me.CheckStates()

                Me.m_data.data_LoadField(Me.datagrid.CurrentRow.Cells(0).Value)

            Case "CLOSE"
                Me.Close()
            Case Else
                My.m_msg.MessageError(Me, "Comando de acción de " & cmd & "no controlada.")
        End Select
    End Sub
#End Region

#Region "Eventos Principales"
    Private Sub frmPaneldeVentas_Factura_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        If (Not IsNothing(Me.m_data)) Then Me.m_data.Dispose()

        If (Not IsNothing(m_KeyBoard)) Then m_KeyBoard.Close()
    End Sub
    Private Sub frmPaneldeVentas_Factura_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'Configuro el formulario
        Me.Size = Screen.PrimaryScreen.WorkingArea.Size

        'Centro el body
        Me.PnlBody.Left = (Me.Width - Me.PnlBody.Width) / 2
        Me.PnlBody.Top = (Me.SplitContainer.Panel2.Height - Me.PnlBody.Height) / 2
        Me.PnlBody.Visible = True

        Me.TxtFilter.Focus()

        Me.CheckStates()

        '  Me.BtSelect.Enabled = (Me.datagrid.RowCount > 0)
        'BtFilter_Click(Me.TxtFilter, New System.EventArgs)
    End Sub

#End Region

#Region "Eventos Delegados"

    ' Delegacion para el control de teclas
    Private Sub form_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        Select Case e.KeyCode
            Case Keys.Escape
                If Not m_KeyBoard Is Nothing Then
                    m_KeyBoard.Dispose()
                    Exit Select
                End If
                Me.Dispose()
        End Select

    End Sub

#End Region

#Region "Eventos Auxiliares"
    Private Sub datagrid_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles datagrid.CellClick
        Me.CheckStates()
    End Sub

    Private Sub datagrid_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles datagrid.CellDoubleClick
        Me.ShellApp("GENERAR")
        Me.CheckStates()
    End Sub

    Private Sub BtFilter_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtFilter.Click
        Dim sqlfilter As String = ""

        ' Establezco el origen de datos y compruebo estados
        Me.datagrid.DataSource = Me.m_data.grid_GetDataSource(Me.TxtFilter.Text, sqlfilter)


        Me.CheckStates()
    End Sub

    Private Sub CbConditionalFilter_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If Me.IsHandleCreated Then Me.BtFilter.Enabled = True
    End Sub

    Private Sub Buttons_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtMin.Click, BtClose.Click, BtPrevious.Click, BtNext.Click, BtLast.Click, BtFirst.Click, BtNewClient.Click, BtCancelNew.Click, BtPrintCaja.Click, BtSelect.Click
        'Si no tiene establecido el tag mando un error
        If IsNothing(CType(sender, Button).Tag) OrElse CType(sender, Button).Tag.ToString.Length = 0 Then
            My.m_msg.MessageError(sender, "Tag de control de elemento no referenciado")
            Exit Sub
        End If

        ShellApp(CType(sender, Button).Tag.ToString)
    End Sub

    Private Sub frmPaneldeVentas_Factura_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        Me.Left = 0
        Me.Top = 0
    End Sub

    Private Sub TxtFilter_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtFilter.KeyDown
        If e.KeyCode = Keys.Enter Then BtFilter_Click(Me.BtFilter, New EventArgs)
    End Sub

    Private Sub TxtFilter_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtFilter.TextChanged
        'En cuanto establezco un criterio de busqueda activo el boton de buscar
        If Me.TxtFilter.TextLength Then Me.BtFilter.Enabled = True
    End Sub

    Private Sub CbFilter_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CbFilter.SelectedIndexChanged
        If Me.IsHandleCreated Then Me.BtFilter.Enabled = True
    End Sub

    Private Sub TxtRequisitos_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtName_Fiscal.TextChanged, TxtName_Comercial.TextChanged, TxtCIF.TextChanged, TxtProv.TextChanged, TxtPob.TextChanged, TxtDir.TextChanged, TxtCP.TextChanged
        Dim sw As Boolean = False
        Me.BtNewClient.Enabled = IIf(Me.TxtName_Fiscal.TextLength > 0 AndAlso Me.TxtCIF.TextLength > 0 AndAlso Me.TxtProv.TextLength > 0 AndAlso Me.TxtPob.TextLength > 0 AndAlso Me.TxtDir.TextLength > 0 AndAlso Me.TxtCP.TextLength > 0, True, False)
    End Sub

    Private Sub Tab_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Tab.SelectedIndexChanged
        Select Case True
            Case Me.Tab.SelectedTab Is Me.TabPage_Lista
                'Recargo la lista
                Me.datagrid.DataSource = Me.m_data.grid_GetDataSource

                Me.PnlButtons_Controls.Visible = True
                Me.PnlButtons_Move.Visible = True

                Me.CheckStates()

            Case Me.Tab.SelectedTab Is Me.TabPage_Nuevo
                Me.PnlButtons_Controls.Visible = False
                Me.PnlButtons_Move.Visible = False

                Me.m_data.data_NewField()

                My.AsignarFoco(Me.TxtName_Fiscal)
        End Select
    End Sub

    Private Sub BtNewClient_Extra_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtNewClient_Extra.Click
        Me.Tab.SelectedTab = Me.TabPage_Nuevo
    End Sub
#End Region

#Region "Control del Teclado Multimedia"
    Private Sub BtKeyBoard_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtKeyBoard.Click
        AddHandler m_KeyBoard.KeyBoard_Press, AddressOf KeyBoard_Press

        m_KeyBoard.Left = (Screen.PrimaryScreen.WorkingArea.Width - m_KeyBoard.Width) / 2
        m_KeyBoard.Top = Screen.PrimaryScreen.WorkingArea.Height - m_KeyBoard.Height - My.APP_NUMBER
        m_KeyBoard.Show()
    End Sub

    Private Sub KeyBoard_Press(ByVal key As String)
        Select Case True
            Case Me.TxtFilter.Focus
                Select Case key
                    Case "SPACE"
                        key = " "
                    Case "DEL"
                        If Me.TxtFilter.TextLength = 0 Then
                            m_KeyBoard.Activate()
                            Exit Sub
                        End If
                        Me.TxtFilter.Text = Me.TxtFilter.Text.Substring(0, Me.TxtFilter.Text.Length - 1)
                        Me.TxtFilter.SelectionStart = Me.TxtFilter.TextLength
                        m_KeyBoard.Activate()
                        Exit Sub
                    Case "OK"
                        BtFilter_Click(Me.BtFilter, New EventArgs)
                        Exit Sub

                End Select
                Me.TxtFilter.Text &= key
                Me.TxtFilter.SelectionStart = Me.TxtFilter.TextLength

                m_KeyBoard.Activate()
        End Select

        Me.TxtFilter.Focus()
        'Me.Focus()
    End Sub
#End Region

End Class