Public Class m_Shell
    Private WithEvents m_FormData As Form
    Private WithEvents m_data As gDevelop.Lite.m_dataform
    
    Private _app As String = ""             'El modulo que cargamos por defecto

    Private _export As Boolean = False             'Por si Estoy exportando
    Public _exportID As Integer = -1


    'Private m_table As DataTable


    'Eventos
    Public Event FieldPosition(ByVal n As Integer, ByVal m As Integer)                      'Evento para indicarme la posicion del registro dentro de un conjunto de datos
    Public Event StateForm(ByVal action As gDevelop.Lite.m_EnumTypes.TypeAction)      'Vento que me indica en el formulario hijo la accion actual

    Public Event mData_ExportId(ByVal id As Integer)              'Para cuando exporto un registro
    Public Event mData_CancelExport()              'Para cuando exporto un registro



#Region "Funciones"
    ''' <summary>Funcion para configurar el origen de datos</summary>
    Public Function ConfigureApp(ByVal app As String, Optional ByVal Export As Boolean = False) As Boolean
        Me._app = app
        Me._export = Export
        Me.m_data = New gDevelop.Lite.m_dataform(My.m_db)

        'Si no localiza la configuracion no continuo
        If Not Me.m_data.GetConfiguration(Me._app) Then
            My.m_msg.MessageError(Me.m_data, "Configuración de shell no encontrada")
            Return False
        End If

        'Establezco valores de configuracion
        Me.LblTitle.Text = Me.m_data.cfg_GetValue("title")
        Me.LblName.Text = Me.m_data.cfg_GetValue("title")
        Me.LblSubTitle.Text = Me.m_data.cfg_GetValue("subtitle")

        ' Establezco el manejo de formularios hijo
        Select Case Me._app
            Case "USERS"
                Me.m_FormData = frmUsuarios
                AddHandler Me.KeyDown, AddressOf form_KeyDown

                'Asigno eventos de control para el hijo
                AddHandler Me.FieldPosition, AddressOf CType(Me.m_FormData, frmUsuarios).FieldPosition
                AddHandler Me.StateForm, AddressOf CType(Me.m_FormData, frmUsuarios).StateForm

                'Control de acciones que realiza el hijo hijo
                AddHandler CType(Me.m_FormData, frmUsuarios).Shell_App, AddressOf Me.ShellApp

                'Asigno eventos de control de la clase m_dataform
                AddHandler Me.m_data.OnNewField, AddressOf CType(Me.m_FormData, frmUsuarios).OnNewField
                AddHandler Me.m_data.OnLoadField, AddressOf CType(Me.m_FormData, frmUsuarios).OnLoadField
                AddHandler Me.m_data.OnSaveField, AddressOf CType(Me.m_FormData, frmUsuarios).OnSaveField

                'Configuro el formulario
                CType(Me.m_FormData, frmUsuarios).ConfigureApp(Me._app, Me.m_data.cfg_GetValue("title"))

            Case "PROVEEDORES"
                Me.m_FormData = frmProveedores
                AddHandler Me.KeyDown, AddressOf form_KeyDown

                'Asigno eventos de control para el hijo
                AddHandler Me.FieldPosition, AddressOf CType(Me.m_FormData, frmProveedores).FieldPosition
                AddHandler Me.StateForm, AddressOf CType(Me.m_FormData, frmProveedores).StateForm

                'Control de acciones que realiza el hijo hijo
                AddHandler CType(Me.m_FormData, frmProveedores).Shell_App, AddressOf Me.ShellApp

                'Asigno eventos de control de la clase m_dataform
                AddHandler Me.m_data.OnNewField, AddressOf CType(Me.m_FormData, frmProveedores).OnNewField
                AddHandler Me.m_data.OnLoadField, AddressOf CType(Me.m_FormData, frmProveedores).OnLoadField
                AddHandler Me.m_data.OnSaveField, AddressOf CType(Me.m_FormData, frmProveedores).OnSaveField

                'Configuro el formulario
                CType(Me.m_FormData, frmProveedores).ConfigureApp(Me._app, Me.m_data.cfg_GetValue("title"))

            Case "CLIENTES"
                Me.m_FormData = frmClientes
                AddHandler Me.KeyDown, AddressOf form_KeyDown

                'Asigno eventos de control para el hijo
                AddHandler Me.FieldPosition, AddressOf CType(Me.m_FormData, frmClientes).FieldPosition
                AddHandler Me.StateForm, AddressOf CType(Me.m_FormData, frmClientes).StateForm

                'Control de acciones que realiza el hijo hijo
                AddHandler CType(Me.m_FormData, frmClientes).Shell_App, AddressOf Me.ShellApp

                'Asigno eventos de control de la clase m_dataform
                AddHandler Me.m_data.OnNewField, AddressOf CType(Me.m_FormData, frmClientes).OnNewField
                AddHandler Me.m_data.OnLoadField, AddressOf CType(Me.m_FormData, frmClientes).OnLoadField
                AddHandler Me.m_data.OnSaveField, AddressOf CType(Me.m_FormData, frmClientes).OnSaveField

                'Configuro el formulario
                CType(Me.m_FormData, frmClientes).ConfigureApp(Me._app, Me.m_data.cfg_GetValue("title"))

            Case "CATEGORIAS"
                Me.m_FormData = frmCategorias
                AddHandler Me.KeyDown, AddressOf form_KeyDown

                'Asigno eventos de control para el hijo
                AddHandler Me.FieldPosition, AddressOf CType(Me.m_FormData, frmCategorias).FieldPosition
                AddHandler Me.StateForm, AddressOf CType(Me.m_FormData, frmCategorias).StateForm

                'Control de acciones que realiza el hijo hijo
                AddHandler CType(Me.m_FormData, frmCategorias).Shell_App, AddressOf Me.ShellApp

                'Asigno eventos de control de la clase m_dataform
                AddHandler Me.m_data.OnNewField, AddressOf CType(Me.m_FormData, frmCategorias).OnNewField
                AddHandler Me.m_data.OnLoadField, AddressOf CType(Me.m_FormData, frmCategorias).OnLoadField
                AddHandler Me.m_data.OnSaveField, AddressOf CType(Me.m_FormData, frmCategorias).OnSaveField

                'Configuro el formulario
                CType(Me.m_FormData, frmCategorias).ConfigureApp(Me._app, Me.m_data.cfg_GetValue("title"))

            Case "ARTICULOS"
                Me.m_FormData = frmArticulos
                AddHandler Me.KeyDown, AddressOf form_KeyDown

                'Asigno eventos de control para el hijo
                AddHandler Me.FieldPosition, AddressOf CType(Me.m_FormData, frmArticulos).FieldPosition
                AddHandler Me.StateForm, AddressOf CType(Me.m_FormData, frmArticulos).StateForm

                'Control de acciones que realiza el hijo hijo
                AddHandler CType(Me.m_FormData, frmArticulos).Shell_App, AddressOf Me.ShellApp

                'Asigno eventos de control de la clase m_dataform
                AddHandler Me.m_data.OnNewField, AddressOf CType(Me.m_FormData, frmArticulos).OnNewField
                AddHandler Me.m_data.OnLoadField, AddressOf CType(Me.m_FormData, frmArticulos).OnLoadField
                AddHandler Me.m_data.OnSaveField, AddressOf CType(Me.m_FormData, frmArticulos).OnSaveField
                AddHandler Me.m_data.OnSavedField, AddressOf CType(Me.m_FormData, frmArticulos).OnSaved

                'Configuro el formulario
                CType(Me.m_FormData, frmArticulos).ConfigureApp(Me._app, Me.m_data.cfg_GetValue("title"))


                '# Añado Filtros y Manejadores Especificos
                Dim rst As ADODB.Recordset = My.m_db.GetRst("SELECT * FROM db_categorias ORDER BY name")
                While Not rst.EOF
                    Me.CbConditionalFilter.Items.Add(rst("name").Value & Space(150) & "id_categoria=" & rst("id").Value)
                    rst.MoveNext()
                End While

                'AddHandler Me.CbConditionalFilter.SelectedIndexChanged, AddressOf ComboConditional_SelectedIndexChanged

            Case "CAJAS"
                Me.m_FormData = frmTmpCajas
                AddHandler Me.KeyDown, AddressOf form_KeyDown

                'Asigno eventos de control para el hijo
                AddHandler Me.FieldPosition, AddressOf CType(Me.m_FormData, frmTmpCajas).FieldPosition
                AddHandler Me.StateForm, AddressOf CType(Me.m_FormData, frmTmpCajas).StateForm

                'Control de acciones que realiza el hijo hijo
                AddHandler CType(Me.m_FormData, frmTmpCajas).Shell_App, AddressOf Me.ShellApp

                'Asigno eventos de control de la clase m_dataform
                AddHandler Me.m_data.OnNewField, AddressOf CType(Me.m_FormData, frmTmpCajas).OnNewField
                AddHandler Me.m_data.OnLoadField, AddressOf CType(Me.m_FormData, frmTmpCajas).OnLoadField
                AddHandler Me.m_data.OnSaveField, AddressOf CType(Me.m_FormData, frmTmpCajas).OnSaveField

                'Configuro el formulario
                CType(Me.m_FormData, frmTmpCajas).ConfigureApp(Me._app, Me.m_data.cfg_GetValue("title"))
            Case Else
                My.m_msg.MessageError(Me, "Configuración de formulario hijo no encontrada")
                Return False
        End Select

        'Configuro el formulario de datos
        Me.m_data.ConfigureDataForm(Me.m_FormData.Controls)

        ' Establezco los valores condicionales
        Me.m_data.combo_SetFilters(Me.CbFilter)
        Me.m_data.combo_AddConditionalFilters(Me.CbConditionalFilter)

        'Configuro el grid con valores por defecto
        Me.m_data.grid_Configure(Me.datagrid, 16)

        'Cargo origen de datos por defecto y chequeo estados
        Me.datagrid.DataSource = Me.m_data.grid_GetDataSource
        Me.LblSQL.Text = Me.m_data.SQLConfig

        'Precargo el formulario
        '   Me.m_FormData.CreateControl()

        Return True

        ' Para Debug
        'Me.LblSQL.Text = Me.m_data.SQLConfig
    End Function


    ' Fucnion que me establece el estado de los botones
    Public Sub CheckStates()
        ' Obtengo el registro por el que veo del total de registros (NofM)
        Dim index As Integer = 0
        If Me.datagrid.SelectedRows.Count > 0 Then index = Me.datagrid.SelectedRows(0).Index + 1

        Me.LblNofM.Text = index & "/" & Me.datagrid.Rows.Count

        'Configuro los botones de movimiento de registros
        Me.BtFirst.Enabled = True
        Me.BtPrevious.Enabled = True
        Me.BtNext.Enabled = True
        Me.BtLast.Enabled = True

        If (index <= 1) Then
            Me.BtFirst.Enabled = False
            Me.BtPrevious.Enabled = False
        End If

        If (index = Me.datagrid.Rows.Count) Then
            Me.BtNext.Enabled = False
            Me.BtLast.Enabled = False
        End If

        'Establezco el estado de los botones de accion
        Me.BtShow.Enabled = (Me.datagrid.Rows.Count > 0)
        Me.BtEdit.Enabled = (Me.datagrid.Rows.Count > 0)
        Me.BtDel.Enabled = (Me.datagrid.Rows.Count > 0)

        RaiseEvent FieldPosition(index, Me.datagrid.Rows.Count)


        RaiseEvent StateForm(gDevelop.Lite.m_EnumTypes.TypeAction._Unknown)


        'If Me.Grid.BindingContext(Me.m_table).Position <= 0 AndAlso Me.Grid.BindingContext(Me.m_table).Position = Me.Grid.BindingContext(Me.m_table).Count - 1 Then
        '    RaiseEvent mData_StateMove(gDevelop.m_DataTypes.m_ActionMove.OnNoMove, StrAux)
        '    Exit Sub
        'End If

        'Por si esta al principio/final deshabilito botones
        'If Me.Grid.BindingContext(Me.m_table).Position <= 0 Then RaiseEvent mData_StateMove(gDevelop.m_DataTypes.m_ActionMove.OnMove_First, StrAux)
        'If Me.Grid.BindingContext(Me.m_table).Position = Me.Grid.BindingContext(Me.m_table).Count - 1 Then RaiseEvent mData_StateMove(gDevelop.m_DataTypes.m_ActionMove.OnMove_Last, StrAux)
    End Sub
#End Region

#Region "Manejadores"
    'Manejador Principal (Shell) 
    Private Sub ShellApp(ByVal command As String)
        Dim cmd As String = command.ToUpper

        'Antes de iniciar cualquier opcion compruebo si la demo es valida (fix change fh)

        Select Case cmd
            Case "SHOW"
                If Me.datagrid.CurrentRow Is Nothing Then Exit Select
                Me.m_data.data_LoadField(Me.datagrid.CurrentRow.Cells(0).Value)
                Me.CheckStates()
                'If Not Me.m_FormData.IsHandleCreated Then Me.m_FormData.ShowDialog(Me)
                If Not Me.m_FormData.IsHandleCreated Then Me.m_FormData.ShowDialog(Me)

            Case "EXPORTA"
                If IsNothing(Me.datagrid.CurrentRow) Then Exit Select
                If IsNothing(Me.datagrid.CurrentRow) Then Exit Select
                Me._exportID = Me.datagrid.CurrentRow.Cells(0).Value
                Me.DialogResult = Windows.Forms.DialogResult.OK


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

            Case "NEW"
                RaiseEvent StateForm(gDevelop.Lite.m_EnumTypes.TypeAction.OnNew)
                Me.m_data.data_NewField()

                If Not Me.m_FormData.IsHandleCreated Then Me.m_FormData.ShowDialog(Me)


            Case "EDIT"
                RaiseEvent StateForm(gDevelop.Lite.m_EnumTypes.TypeAction.OnEdit)
                Me.m_data.data_EditField(Me.datagrid.CurrentRow.Cells(0).Value)

                'Me.ShellApp("ShellApp")
                If Not Me.m_FormData.IsHandleCreated Then Me.m_FormData.ShowDialog(Me)

            Case "DEL"
                If MsgBox("¿Esta seguro de que desea eliminar el registro '" & Me.datagrid.CurrentRow.Cells(1).Value & "' de " & Me.LblName.Text & "?", MsgBoxStyle.OkCancel + MsgBoxStyle.Question) <> MsgBoxResult.Ok Then Exit Sub

                If Not Me.m_data.data_DelField(Me.datagrid.CurrentRow.Cells(0).Value) Then Exit Sub

                Dim intAux As Integer = Me.datagrid.CurrentRow.Index
                If intAux < 0 Then intAux = 0
                
                Me.datagrid.DataSource = Me.m_data.grid_GetDataSource(Me.TxtFilter.Text)

                If Me.datagrid.Rows.Count <= intAux Then intAux = Me.datagrid.Rows.Count - 1

                If Me.datagrid.Rows.Count = 0 Then
                    Me.CheckStates()
                    Me.m_FormData.Close()
                    Exit Select
                End If

                Me.datagrid.CurrentCell = Me.datagrid.Rows(intAux).Cells(0)

                If Me.m_FormData.IsHandleCreated Then Me.ShellApp("SHOW")
                'Me.m_data.data_LoadField(Me.datagrid.CurrentRow.Cells(0).Value)


                'Me.CheckStates()

            Case "CANCELL"
                If Me.datagrid.Rows.Count <= 0 Then
                    Me.m_FormData.Close()
                Else
                    Me.m_data.data_LoadField(Me.datagrid.CurrentRow.Cells(0).Value)
                    RaiseEvent StateForm(gDevelop.Lite.m_EnumTypes.TypeAction.OnCancell)

                End If
            Case "OK"
                'Dim sw As Boolean = False
                'RaiseEvent SaveField(sw)

                Dim id As Integer = Me.m_data.data_SaveField()

                If Me.m_data.Action = gDevelop.Lite.m_EnumTypes.TypeAction.OnNew Then
                    If id = -1 Then Exit Sub

                    ' Organizo por id y muestro
                    Me.CbFilter.SelectedIndex = 0
                    'Me.CbConditionalFilter.SelectedIndex = 0
                    Me.TxtFilter.Text = ""

                    Me.datagrid.DataSource = Me.m_data.grid_GetDataSource(Me.TxtFilter.Text)
                    Me.datagrid.CurrentCell = Me.datagrid.Rows(0).Cells(0)
                Else
                    Dim aux As Integer = Me.datagrid.CurrentRow.Index
                    Me.datagrid.DataSource = Me.m_data.grid_GetDataSource(Me.TxtFilter.Text)
                    If Me.datagrid.Rows.Count = 1 Then aux = 0
                    If Me.datagrid.Rows.Count > 0 Then Me.datagrid.CurrentCell = Me.datagrid.Rows(aux).Cells(0)
                End If

                RaiseEvent StateForm(gDevelop.Lite.m_EnumTypes.TypeAction.OnSave)
                'Me.m_data.data_LoadField(id)


                Me.ShellApp("SHOW")
                'Me.m_data.data_LoadField(Me.datagrid.CurrentRow.Cells(0).Value)
                'Me.m_FormData.ShowDialog(Me)

                ' Me.CheckStates()
            Case "MINIMIZE"
                frm_AppIsMinimized.Show()

                Me.Owner.WindowState = FormWindowState.Minimized
                Me.WindowState = FormWindowState.Minimized

            Case "CLOSE"
                Me.Close()
            Case Else
                My.m_msg.MessageError(Me, "Comando de acción de " & cmd & "no controlada.")
        End Select
    End Sub
#End Region

#Region "Manejadores Auxiliares del Combo de Filtro"
    Private Sub ComboConditional_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub
#End Region

#Region "Eventos Principales"

    Private Sub m_Shell_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed

        If (Not IsNothing(Me.m_data)) Then Me.m_data.Dispose()
        If (Not IsNothing(Me.m_FormData)) Then
            Me.m_FormData.Close()
            Me.m_FormData.Dispose()
        End If

        If (Not IsNothing(m_KeyBoard)) Then m_KeyBoard.Close()
    End Sub
    Private Sub m_Shell_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'Configuro el formulario
        Me.Size = Screen.PrimaryScreen.WorkingArea.Size

        'Centro el body
        If Not IsNothing(Me.Owner) Then
            Me.PnlBody.Left = CType(Me.Owner, frmMain).PnlBody.Left         '(Me.Width - Me.PnlBody.Width) / 2
            Me.PnlBody.Top = CType(Me.Owner, frmMain).PnlBody.Top '+ (IIf(My.m_opt.swNoteBook, Me.SplitContainer.Panel1.Height, 0)) '(Me.SplitContainer.Panel2.Height - Me.PnlBody.Height) / 2
        Else
            'Centro el body y establezco tamaños
            Me.PnlBody.Left = (Me.Width - Me.PnlBody.Width) / 2
            Me.PnlBody.Top = (Me.SplitContainer.Panel2.Height - Me.PnlBody.Height) / 2 + (IIf(My.m_opt.swNoteBook, Me.SplitContainer.Panel1.Height, 0))

        End If
        Me.PnlBody.Visible = True

        Me.TxtFilter.Focus()

        Me.CheckStates()
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

    Private Sub m_logo_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles m_logo.DoubleClick
        Me.LblSQL.Visible = True
    End Sub

    Private Sub datagrid_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles datagrid.CellDoubleClick
        If Me._export Then
            Me.ShellApp("EXPORTA")
        Else
            Me.ShellApp("SHOW")
        End If


        Me.CheckStates()
    End Sub

    Private Sub BtFilter_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtFilter.Click
        Dim sqlfilter As String = ""

        If Me.CbConditionalFilter.SelectedIndex > -1 Then sqlfilter &= IIf(sqlfilter.Length > 0, " AND ", "") & Me.CbConditionalFilter.Text.Substring(100).Trim
        'Genero el filtro especifico
        'sql = ""

        ' Establezco el origen de datos y compruebo estados
        Me.datagrid.DataSource = Me.m_data.grid_GetDataSource(Me.TxtFilter.Text, sqlfilter)


        Me.CheckStates()

        Me.LblSQL.Text = Me.m_data.SQLConfig
    End Sub


    Private Sub CbConditionalFilter_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CbConditionalFilter.SelectedIndexChanged
        If Me.IsHandleCreated Then Me.BtFilter.Enabled = True
    End Sub

    Private Sub Buttons_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtMin.Click, BtClose.Click, BtEdit.Click, BtDel.Click, BtPrevious.Click, BtNext.Click, BtLast.Click, BtFirst.Click, BtNew.Click, BtShow.Click
        'Si no tiene establecido el tag mando un error
        If IsNothing(CType(sender, Button).Tag) OrElse CType(sender, Button).Tag.ToString.Length = 0 Then
            My.m_msg.MessageError(sender, "Tag de control de elemento no referenciado")
            Exit Sub
        End If

        ShellApp(CType(sender, Button).Tag.ToString)
    End Sub

    Private Sub m_Shell_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
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
#End Region

#Region "Control del Teclado Multimedia"
    Private Sub BtKeyBoard_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtKeyBoard.Click
        'AddHandler m_KeyBoard.KeyBoard_Press, AddressOf KeyBoard_Press

        'm_KeyBoard.Left = (Screen.PrimaryScreen.WorkingArea.Width - m_KeyBoard.Width) / 2
        'm_KeyBoard.Top = Screen.PrimaryScreen.WorkingArea.Height - m_KeyBoard.Height - My.APP_NUMBER
        'm_KeyBoard.Show()
        My.AsignarFoco(Me.TxtFilter)
        My.ShellExecute(0, Nothing, "osk.exe", Nothing, Nothing, 0)
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


    Private Sub m_Shell_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyValue = Keys.Escape Then Me.Close()
    End Sub

    Private Sub m_Shell_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
        Dim sqlfilter As String = ""

        If Me.CbConditionalFilter.SelectedIndex > -1 Then sqlfilter &= IIf(sqlfilter.Length > 0, " AND ", "") & Me.CbConditionalFilter.Text.Substring(100).Trim
        'Genero el filtro especifico
        'sql = ""

        ' Establezco el origen de datos y compruebo estados
        Me.datagrid.DataSource = Me.m_data.grid_GetDataSource(Me.TxtFilter.Text, sqlfilter)


        Me.CheckStates()

        Me.LblSQL.Text = Me.m_data.SQLConfig
    End Sub
End Class