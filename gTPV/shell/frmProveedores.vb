Public Class frmProveedores
    'Private WithEvents m_data As gDevelop.m_dataform
    Private _app As String = ""             'El modulo que cargamos por defecto

    Private _id As Integer = 0

    Private _n As Integer = 0
    Private _m As Integer = 0

    Public Event Shell_App(ByVal app_form As String)         'Para controlar las acciones de los botones desde el formulario padre




#Region "Funciones"
    Public Function ConfigureApp(ByVal app As String, ByVal name As String) As Boolean
        Me._app = app

        Me.LblTitle.Text = name
        Me.LblName.Text = name
    End Function



#End Region

#Region "Manejadores"
    'Manejador Principal (Shell) 
    Private Sub ShellApp(ByVal app_form As String, Optional ByVal action As String = "")
        Dim app As String = app_form.ToUpper

        ''Antes de iniciar cualquier opcion compruebo si la demo es valida (fix change fh)

        Select Case app
            Case "MINIMIZE"
                frm_AppIsMinimized.Show()

                Me.Owner.WindowState = FormWindowState.Minimized
                Me.WindowState = FormWindowState.Minimized

            Case "CLOSE"
                Me.Close()
            Case Else
                RaiseEvent Shell_App(app)
        End Select
    End Sub

#End Region

#Region "Eventos Principales"
    Private Sub m_Shell_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        If (Not IsNothing(m_KeyBoard)) Then m_KeyBoard.Close()
    End Sub
    Private Sub m_Shell_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'Configuro el formulario
        Me.Size = Screen.PrimaryScreen.WorkingArea.Size

        'Centro el body
        Me.PnlBody.Left = CType(Me.Owner, m_Shell).PnlBody.Left         '(Me.Width - Me.PnlBody.Width) / 2
        Me.PnlBody.Top = CType(Me.Owner, m_Shell).PnlBody.Top '+ (IIf(My.m_opt.swNoteBook, Me.SplitContainer.Panel1.Height, 0)) '(Me.SplitContainer.Panel2.Height - Me.PnlBody.Height) / 2
        Me.PnlBody.Visible = True

        'Cargo los valores informativos de configuracion
        'Me.LblTitle.Text = Me.m_data.cfg_GetValue("title")
        'Me.LblName.Text = Me.m_data.cfg_GetValue("title")
        'Me.LblSubTitle.Text = Me.m_data.cfg_GetValue("subtitle")
    End Sub

#End Region

#Region "Eventos Delegados"
    'Para controlar el caso del nuevo
    Public Sub OnNewField()
        Me.LblFh_Alta.Visible = False
        Me.LblFh_Alta_nfo.Visible = False
        Me.BtSelectImg.Image = Nothing

        Me._id = 0
    End Sub

    'Cada vez que cargo un registro
    Public Sub OnLoadField(ByVal id As Integer)
        Me._id = id
        Me.LblId.Text = "Ref. " & id

        Me.TxtName_Fiscal.Select()
        Me.Tab.SelectedIndex = 0

        Me.LblSubTitle.Text = "Visualizando el registro de """ & Me.TxtName_Fiscal.Text & """"                 ' Submensaje"
        'if me.PicImg.Image isnot nothing andalso not isnothing(Me.BtSelectImg.Image = Me. then 
        'Me.BtSelectImg.Image = Me.PicImg.Image

        'Compruebo foto
        Me.BtSelectImg.Text = IIf(IsNothing(Me.BtSelectImg.Image), "Click para seleccionar Imagen", "")

        'Establezco estados
        Me.LblFh_Alta.Visible = True
        Me.LblFh_Alta_nfo.Visible = True
    End Sub

    'Comprobaciones antes de guardar
    Public Sub OnSaveField(ByRef cancell As Boolean)
        If Me.TxtName_Fiscal.TextLength <= 0 Then
            My.m_msg.MessageError(Me.Owner, "Debe de establecer el nombre del proveedor para poder guardar.")
            Me.TxtName_Fiscal.SelectAll()
            cancell = True
            Exit Sub
        End If

        'cancell = True
    End Sub

    Public Sub StateForm(ByVal action As gDevelop.Lite.m_EnumTypes.TypeAction)
        Select Case action
            Case gDevelop.Lite.m_EnumTypes.TypeAction._Unknown
                Me.BtNew.Enabled = True
                Me.BtEdit.Enabled = True
                Me.BtDel.Enabled = True

                Me.BtCancell.Enabled = False
                Me.BtOk.Enabled = False

                Me.BtCancell.Enabled = False
                Me.BtOk.Enabled = False

                Me.BtSelectImg.Text = ""
                If Not Me.Tab.TabPages.Contains(Me.TabPage_Facturas) Then Me.Tab.TabPages.Add(Me.TabPage_Facturas)

                'Me.LblSubTitle.Text = "Mostrando " & Me.TxtName.Text

            Case gDevelop.Lite.m_EnumTypes.TypeAction.OnNew, gDevelop.Lite.m_EnumTypes.TypeAction.OnEdit
                Me.BtNew.Enabled = False
                Me.BtEdit.Enabled = False
                Me.BtDel.Enabled = False

                Me.BtCancell.Enabled = True
                Me.BtOk.Enabled = True

                Me.BtFirst.Enabled = False
                Me.BtPrevious.Enabled = False

                Me.BtNext.Enabled = False
                Me.BtLast.Enabled = False


                Me.BtSelectImg.Image = Me.PicImg.Image
                Me.PicImg.Visible = False

                Me.BtClose.Visible = False

                Me.Tab.TabPages.Remove(Me.TabPage_Facturas)

                Me.LblSubTitle.Text = "Editando " & Me.TxtName_Fiscal.Text                 ' Submensaje

                If action = gDevelop.Lite.m_EnumTypes.TypeAction.OnNew Then
                    Me.LblSubTitle.Text = "Nuevo Registro"
                    Me.LblId.Visible = False
                    Me.LblNofM.Visible = False


                    Me.PicImg.Image = Nothing
                    'Me.BtSelectImg.Image = Nothing
                End If

                Me.TxtName_Fiscal.Select()

                Exit Sub
            Case gDevelop.Lite.m_EnumTypes.TypeAction.OnCancell, gDevelop.Lite.m_EnumTypes.TypeAction.OnSave
                Me.BtNew.Enabled = True
                Me.BtEdit.Enabled = True
                Me.BtDel.Enabled = True

                Me.BtCancell.Enabled = False
                Me.BtOk.Enabled = False

                Me.BtSelectImg.Text = ""

                Me.LblNofM.Visible = True
                Me.LblId.Visible = True

                If Not Me.Tab.TabPages.Contains(Me.TabPage_Facturas) Then Me.Tab.TabPages.Add(Me.TabPage_Facturas)

                FieldPosition(Me._n, Me._m)
        End Select

        ' Estados fijos a no ser que retornemos la funcion
        Me.PicImg.Visible = True
        Me.BtClose.Visible = True

        'Limpio controles
        Me.BtSelectImg.Image = Nothing
    End Sub

    Public Sub FieldPosition(ByVal n As Integer, ByVal m As Integer)
        Me.LblNofM.Text = n & "/" & m

        'Establezco el estado de los botones de movimiento
        Me.BtFirst.Enabled = (n > 1)
        Me.BtPrevious.Enabled = (n > 1)

        Me.BtNext.Enabled = (n < m)
        Me.BtLast.Enabled = (n < m)

        Me._n = n
        Me._m = m
        'MsgBox("hola")
    End Sub

    'Delegacion para el control de teclas
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
    Private Sub Buttons_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtClose.Click, BtEdit.Click, BtDel.Click, BtPrevious.Click, BtNext.Click, BtLast.Click, BtFirst.Click, BtOk.Click, BtNew.Click, BtCancell.Click
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

        Me.PnlData.Visible = True
    End Sub

#End Region

#Region "Seleccion de Imagen"
    Private Sub BtSelectImg_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtSelectImg.Click
        'Dim myStream As IO.Stream
        Dim dlg As New OpenFileDialog()

        dlg.Filter = "Archivos de imagen jpg (*.jpg)|*.jpg"
        dlg.FilterIndex = 0
        dlg.RestoreDirectory = False



        If dlg.ShowDialog() <> Windows.Forms.DialogResult.OK Then Exit Sub

        Me.BtSelectImg.Image = Image.FromFile(gDevelop.Lite.m_Functions.resize_image(dlg.FileName, 110))
        Me.PicImg.Image = Me.BtSelectImg.Image

        Me.BtSelectImg.Text = ""
    End Sub

    Private Sub LnkDelImg_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LnkDelImg.LinkClicked
        Me.PicImg.Image = Nothing
        Me.BtSelectImg.Image = Nothing
        Me.BtSelectImg.Text = "Click para seleccionar Imagen"
    End Sub
#End Region

#Region "Compras"
    Private Sub Tab_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Tab.SelectedIndexChanged
        If Tab.SelectedTab Is Me.TabPage_Facturas Then Me.LoadFacturas()
    End Sub

#Region "Movimiento de lineas"
    'Movimiento de lineas
    Private Sub Action_Lines(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtLines_Edit.Click, BtLines_Del.Click, BtLines_Add.Click
        Dim StrSQL As String = ""
        Select Case True
            Case sender Is Me.BtLines_Add           'AGREGAR LINEA
                'Para el id del articulo
                Dim IdRef As Integer = 0

                'Muestro el formulario de seleccion del articulo
                'With FrmSelect_ArticuloProv
                '    .IdRef = 0
                '    .Id_Prov = Me.LblId_Prov.Text
                '    .ShowDialog(Me)
                '    If .DialogResult <> Windows.Forms.DialogResult.OK Then
                '        .Dispose()
                '        Exit Sub
                '    End If
                '    IdRef = .IdRef
                '    .Dispose()
                'End With

                ''Muestro el formulario de lineas
                With frmProveedores_Facturas
                    .Id_Ref = 0
                    .Id_Prov = Me._id

                    '    .Id_Compra = Me.LblId.Text
                    '    .Id_Articulo = IdRef
                    .ShowDialog(Me)
                    If .DialogResult <> Windows.Forms.DialogResult.OK Then
                        .Dispose()
                        Exit Sub
                    End If

                    'Vuelvo a leer las facturas
                    Me.LoadFacturas()

                    .Dispose()
                End With

                

            Case sender Is Me.BtLines_Edit          'MODIFICAR LINEA
                With frmProveedores_Facturas
                    .Id_Ref = Me.Grid_Compras.CurrentRow.Cells(0).Value
                    .Id_Prov = Me._id
                    .ShowDialog(Me)
                    If .DialogResult <> Windows.Forms.DialogResult.OK Then
                        .Dispose()
                        Exit Sub
                    End If

                    'Vuelvo a leer las facturas
                    Me.LoadFacturas()

                    .Dispose()
                End With

            Case sender Is Me.BtLines_Del           'ELIMINAR LINEA
                If IsNothing(Me.Grid_Compras.CurrentRow) Then Exit Select
                If MsgBox("¿Esta seguro de que desea eliminar la factura de compra seleccionada?", MsgBoxStyle.Question + MsgBoxStyle.YesNo) <> MsgBoxResult.Yes Then Exit Sub

                'Lo elimino y recargo
                My.m_db.Execute("DELETE FROM db_proveedores_facturas WHERE id=" & Me.Grid_Compras.CurrentRow.Cells(0).Value)
                Me.LoadFacturas()

            Case Else
                Exit Sub
        End Select

    End Sub
#End Region

    Private Sub LoadFacturas()
        Dim m_Table As DataTable            'Tabla de datos
        Dim rst As ADODB.Recordset
        Dim da As Data.OleDb.OleDbDataAdapter
        Dim ColStyle As DataGridViewColumn
        Dim Cell As DataGridViewCell = New DataGridViewTextBoxCell()

        Dim m_Style As New DataGridViewCellStyle

        'El estilo de las celdas
        With m_Style
            .BackColor = Color.FromKnownColor(KnownColor.ControlDark)
            .ForeColor = Color.Black
            .Font = New Font("Verdana", 9)
        End With

        Dim m_Style_alt As New DataGridViewCellStyle
        With m_Style_alt
            .BackColor = Color.FromKnownColor(KnownColor.ControlDarkDark)
            .ForeColor = Color.Black
            .Font = New Font("Verdana", 9)
        End With

        'Preconfiguramos el grid de las ventas
        With Me.Grid_Compras
            .Columns.Clear()
            .AutoGenerateColumns = False

            'El id
            ColStyle = New DataGridViewColumn()
            ColStyle.DataPropertyName = "id"
            ColStyle.HeaderText = "Ref."
            ColStyle.Width = 60
            ColStyle.DefaultCellStyle = m_Style
            ColStyle.CellTemplate = Cell
            .Columns.Add(ColStyle)

            'La fecha de compra
            ColStyle = New DataGridViewColumn()
            ColStyle.DataPropertyName = "fh_compra"
            ColStyle.HeaderText = "Fh. Compra"
            ColStyle.Width = 110
            ColStyle.DefaultCellStyle = m_Style
            ColStyle.CellTemplate = Cell
            .Columns.Add(ColStyle)

            'El nº de factura
            ColStyle = New DataGridViewColumn()
            ColStyle.DataPropertyName = "factura"
            ColStyle.HeaderText = "Factura"
            ColStyle.Width = 120
            ColStyle.DefaultCellStyle = m_Style
            ColStyle.CellTemplate = Cell
            .Columns.Add(ColStyle)

            'La fecha del pedido
            ColStyle = New DataGridViewColumn()
            ColStyle.DataPropertyName = "fh_factura"
            ColStyle.HeaderText = "Fh. Factura"
            ColStyle.Width = 110
            ColStyle.DefaultCellStyle = m_Style
            ColStyle.CellTemplate = Cell
            .Columns.Add(ColStyle)


            'La fecha de entrega
            ColStyle = New DataGridViewColumn()
            ColStyle.DataPropertyName = "total"
            ColStyle.HeaderText = "Importe"
            ColStyle.Width = 120
            ColStyle.DefaultCellStyle = m_Style
            ColStyle.CellTemplate = Cell
            .Columns.Add(ColStyle)

            .AlternatingRowsDefaultCellStyle = m_Style_alt
        End With

        'Asignamos los datos
        rst = My.m_db.GetRst("SELECT id,fh_compra,factura,fh_factura,total FROM db_proveedores_facturas WHERE id_prov=" & Me._id & " order by fh_compra desc")
        If IsNothing(rst) Then Exit Sub

        m_Table = New DataTable("m_tabla")
        da = New Data.OleDb.OleDbDataAdapter
        da.Fill(m_Table, rst)
        Me.Grid_Compras.DataSource = m_Table
    End Sub

    Private Sub Grid_Compras_CurrentCellChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Grid_Compras.CurrentCellChanged
        On Error Resume Next
        Dim sw As Boolean = (Me.Grid_Compras.CurrentRow Is Nothing)
        Me.BtLines_Edit.Enabled = Not sw
        Me.BtLines_Del.Enabled = Not sw
    End Sub
#End Region

End Class