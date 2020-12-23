<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmEstanco
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim Label8 As System.Windows.Forms.Label
        Dim Label46 As System.Windows.Forms.Label
        Dim Label48 As System.Windows.Forms.Label
        Dim Label5 As System.Windows.Forms.Label
        Dim Label7 As System.Windows.Forms.Label
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmEstanco))
        Me.LblHistory_Empleado = New System.Windows.Forms.Label()
        Me.SplitContainer = New System.Windows.Forms.SplitContainer()
        Me.LblHour = New System.Windows.Forms.Label()
        Me.m_logo = New System.Windows.Forms.PictureBox()
        Me.PnlButton_Shell = New System.Windows.Forms.Panel()
        Me.btImportar = New System.Windows.Forms.Button()
        Me.BtUpdatePVP = New System.Windows.Forms.Button()
        Me.BtClose = New System.Windows.Forms.Button()
        Me.LblSubTitle = New System.Windows.Forms.Label()
        Me.LblTitle = New System.Windows.Forms.Label()
        Me.PnlBody = New System.Windows.Forms.Panel()
        Me.PnlData = New System.Windows.Forms.Panel()
        Me.Tab = New System.Windows.Forms.TabControl()
        Me.TabPage_Marcas = New System.Windows.Forms.TabPage()
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.gridMarcas = New System.Windows.Forms.DataGridView()
        Me.PnlFilter = New System.Windows.Forms.Panel()
        Me.Rbt_Filter_Z = New System.Windows.Forms.RadioButton()
        Me.Rbt_Filter_Y = New System.Windows.Forms.RadioButton()
        Me.Rbt_Filter_X = New System.Windows.Forms.RadioButton()
        Me.Rbt_Filter_W = New System.Windows.Forms.RadioButton()
        Me.V = New System.Windows.Forms.RadioButton()
        Me.Rbt_Filter_U = New System.Windows.Forms.RadioButton()
        Me.Rbt_Filter_T = New System.Windows.Forms.RadioButton()
        Me.Rbt_Filter_S = New System.Windows.Forms.RadioButton()
        Me.Rbt_Filter_R = New System.Windows.Forms.RadioButton()
        Me.Rbt_Filter_Q = New System.Windows.Forms.RadioButton()
        Me.Rbt_Filter_P = New System.Windows.Forms.RadioButton()
        Me.Rbt_Filter_O = New System.Windows.Forms.RadioButton()
        Me.Rbt_Filter_Ñ = New System.Windows.Forms.RadioButton()
        Me.Rbt_Filter_N = New System.Windows.Forms.RadioButton()
        Me.Rbt_Filter_M = New System.Windows.Forms.RadioButton()
        Me.Rbt_Filter_L = New System.Windows.Forms.RadioButton()
        Me.Rbt_Filter_K = New System.Windows.Forms.RadioButton()
        Me.Rbt_Filter_J = New System.Windows.Forms.RadioButton()
        Me.Rbt_Filter_I = New System.Windows.Forms.RadioButton()
        Me.Rbt_Filter_H = New System.Windows.Forms.RadioButton()
        Me.Rbt_Filter_G = New System.Windows.Forms.RadioButton()
        Me.Rbt_Filter_F = New System.Windows.Forms.RadioButton()
        Me.Rbt_Filter_E = New System.Windows.Forms.RadioButton()
        Me.Rbt_Filter_D = New System.Windows.Forms.RadioButton()
        Me.Rbt_Filter_C = New System.Windows.Forms.RadioButton()
        Me.Rbt_Filter_B = New System.Windows.Forms.RadioButton()
        Me.Rbt_Filter_A = New System.Windows.Forms.RadioButton()
        Me.Rbt_Filter_All = New System.Windows.Forms.RadioButton()
        Me.PnlHistory = New System.Windows.Forms.Panel()
        Me.GroupHistory = New System.Windows.Forms.GroupBox()
        Me.lblHistory_ID = New System.Windows.Forms.Label()
        Me.BtHistory_Edit = New System.Windows.Forms.Button()
        Me.BtHistory_Print = New System.Windows.Forms.Button()
        Me.LblHistory_Fh = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.LblHistory_Mesa = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.LblHistory_Total = New System.Windows.Forms.Label()
        Me.BtHistory_Next = New System.Windows.Forms.Button()
        Me.BtHistory_Previous = New System.Windows.Forms.Button()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.CheckBox1 = New System.Windows.Forms.CheckBox()
        Me.chkActivo = New System.Windows.Forms.CheckBox()
        Me.lblTotProductos = New System.Windows.Forms.Label()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.dtFhUpdate = New System.Windows.Forms.DateTimePicker()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.lblInfo = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TxtFind = New System.Windows.Forms.TextBox()
        Me.btMarca_edit = New System.Windows.Forms.Button()
        Me.btPedido_Finalizar = New System.Windows.Forms.Button()
        Me.btPedido_Comanda = New System.Windows.Forms.Button()
        Me.btMarca_Add = New System.Windows.Forms.Button()
        Me.btMarca_del = New System.Windows.Forms.Button()
        Me.btPedido_Cancela = New System.Windows.Forms.Button()
        Me.btPedido_Print = New System.Windows.Forms.Button()
        Me.LblDaySelect = New System.Windows.Forms.Label()
        Me.TabPage_pedidos = New System.Windows.Forms.TabPage()
        Me.SplitHistory = New System.Windows.Forms.SplitContainer()
        Me.gridLineas = New System.Windows.Forms.DataGridView()
        Me.sw = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.id = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.grid_txtCodBarras = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.grid_txtRef = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.grid_txtCodigo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.grid_lblName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.grid_txtUd = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.btAll = New System.Windows.Forms.Button()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.lblNPedidos = New System.Windows.Forms.Label()
        Me.groupPedido = New System.Windows.Forms.GroupBox()
        Me.dtPedidoFh = New System.Windows.Forms.DateTimePicker()
        Me.txtPedido_n = New System.Windows.Forms.TextBox()
        Me.gridPedidos = New System.Windows.Forms.DataGridView()
        Me.btPrint = New System.Windows.Forms.Button()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.btSave = New System.Windows.Forms.Button()
        Me.btCancell = New System.Windows.Forms.Button()
        Me.BtEdit = New System.Windows.Forms.Button()
        Me.BtNew = New System.Windows.Forms.Button()
        Me.BtDel = New System.Windows.Forms.Button()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.TabPage_Update = New System.Windows.Forms.TabPage()
        Me.splitImporta = New System.Windows.Forms.SplitContainer()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.lnkCMTPrecios = New System.Windows.Forms.LinkLabel()
        Me.btUpdate = New System.Windows.Forms.Button()
        Me.chkTodos = New System.Windows.Forms.CheckBox()
        Me.btImporta_www = New System.Windows.Forms.Button()
        Me.btImport_procesa = New System.Windows.Forms.Button()
        Me.Label49 = New System.Windows.Forms.Label()
        Me.Label51 = New System.Windows.Forms.Label()
        Me.pbImporta = New System.Windows.Forms.ProgressBar()
        Me.lblImpora_N = New System.Windows.Forms.Label()
        Me.Label50 = New System.Windows.Forms.Label()
        Me.Label47 = New System.Windows.Forms.Label()
        Me.lblImpora_Periodo = New System.Windows.Forms.Label()
        Me.lblImporta_file = New System.Windows.Forms.Label()
        Me.lnkImporta_del = New System.Windows.Forms.LinkLabel()
        Me.lnkImporta_Sel = New System.Windows.Forms.LinkLabel()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.lstImportaPrecios = New System.Windows.Forms.ListView()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.ToolTip = New System.Windows.Forms.ToolTip(Me.components)
        Me.TmHour = New System.Windows.Forms.Timer(Me.components)
        Me.TmrCodBarras = New System.Windows.Forms.Timer(Me.components)
        Label8 = New System.Windows.Forms.Label()
        Label46 = New System.Windows.Forms.Label()
        Label48 = New System.Windows.Forms.Label()
        Label5 = New System.Windows.Forms.Label()
        Label7 = New System.Windows.Forms.Label()
        Me.SplitContainer.Panel1.SuspendLayout()
        Me.SplitContainer.Panel2.SuspendLayout()
        Me.SplitContainer.SuspendLayout()
        CType(Me.m_logo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PnlButton_Shell.SuspendLayout()
        Me.PnlBody.SuspendLayout()
        Me.PnlData.SuspendLayout()
        Me.Tab.SuspendLayout()
        Me.TabPage_Marcas.SuspendLayout()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        CType(Me.gridMarcas, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PnlFilter.SuspendLayout()
        Me.PnlHistory.SuspendLayout()
        Me.GroupHistory.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.TabPage_pedidos.SuspendLayout()
        Me.SplitHistory.Panel1.SuspendLayout()
        Me.SplitHistory.Panel2.SuspendLayout()
        Me.SplitHistory.SuspendLayout()
        CType(Me.gridLineas, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.groupPedido.SuspendLayout()
        CType(Me.gridPedidos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage_Update.SuspendLayout()
        Me.splitImporta.Panel1.SuspendLayout()
        Me.splitImporta.Panel2.SuspendLayout()
        Me.splitImporta.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label8
        '
        Label8.AutoSize = True
        Label8.Font = New System.Drawing.Font("Tahoma", 6.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Label8.Location = New System.Drawing.Point(4, 27)
        Label8.Name = "Label8"
        Label8.Size = New System.Drawing.Size(27, 10)
        Label8.TabIndex = 63
        Label8.Text = "DESDE"
        '
        'Label46
        '
        Label46.BackColor = System.Drawing.Color.SlateGray
        Label46.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Label46.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Label46.Location = New System.Drawing.Point(12, 14)
        Label46.Name = "Label46"
        Label46.Size = New System.Drawing.Size(621, 22)
        Label46.TabIndex = 56
        Label46.Text = "   Seleccione Fichero de Actualización (preciosCMT.html)"
        Label46.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label48
        '
        Label48.BackColor = System.Drawing.Color.SkyBlue
        Label48.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Label48.Dock = System.Windows.Forms.DockStyle.Top
        Label48.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Label48.Location = New System.Drawing.Point(3, 3)
        Label48.Name = "Label48"
        Label48.Size = New System.Drawing.Size(894, 18)
        Label48.TabIndex = 12
        Label48.Text = "LISTADO DE ACTUALIZACIÓN DE PRECIOS"
        Label48.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label5
        '
        Label5.AutoSize = True
        Label5.BackColor = System.Drawing.Color.Transparent
        Label5.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Label5.Location = New System.Drawing.Point(6, 31)
        Label5.Name = "Label5"
        Label5.Size = New System.Drawing.Size(72, 18)
        Label5.TabIndex = 50
        Label5.Text = "Nº pedido"
        '
        'Label7
        '
        Label7.AutoSize = True
        Label7.BackColor = System.Drawing.Color.Transparent
        Label7.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Label7.Location = New System.Drawing.Point(6, 73)
        Label7.Name = "Label7"
        Label7.Size = New System.Drawing.Size(94, 18)
        Label7.TabIndex = 52
        Label7.Text = "Fecha pedido"
        '
        'LblHistory_Empleado
        '
        Me.LblHistory_Empleado.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblHistory_Empleado.ForeColor = System.Drawing.Color.DimGray
        Me.LblHistory_Empleado.Location = New System.Drawing.Point(69, 29)
        Me.LblHistory_Empleado.Name = "LblHistory_Empleado"
        Me.LblHistory_Empleado.Size = New System.Drawing.Size(108, 13)
        Me.LblHistory_Empleado.TabIndex = 35
        Me.LblHistory_Empleado.Text = "EMPLEADO"
        '
        'SplitContainer
        '
        Me.SplitContainer.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer.FixedPanel = System.Windows.Forms.FixedPanel.Panel1
        Me.SplitContainer.ForeColor = System.Drawing.SystemColors.ActiveCaption
        Me.SplitContainer.IsSplitterFixed = True
        Me.SplitContainer.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainer.Name = "SplitContainer"
        Me.SplitContainer.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'SplitContainer.Panel1
        '
        Me.SplitContainer.Panel1.Controls.Add(Me.LblHour)
        Me.SplitContainer.Panel1.Controls.Add(Me.m_logo)
        Me.SplitContainer.Panel1.Controls.Add(Me.PnlButton_Shell)
        Me.SplitContainer.Panel1.Controls.Add(Me.LblSubTitle)
        Me.SplitContainer.Panel1.Controls.Add(Me.LblTitle)
        '
        'SplitContainer.Panel2
        '
        Me.SplitContainer.Panel2.AutoScroll = True
        Me.SplitContainer.Panel2.BackColor = System.Drawing.Color.Black
        Me.SplitContainer.Panel2.Controls.Add(Me.PnlBody)
        Me.SplitContainer.Panel2.Tag = "233; 248; 250"
        Me.SplitContainer.Size = New System.Drawing.Size(1020, 770)
        Me.SplitContainer.SplitterDistance = 64
        Me.SplitContainer.SplitterWidth = 1
        Me.SplitContainer.TabIndex = 2
        '
        'LblHour
        '
        Me.LblHour.Font = New System.Drawing.Font("Verdana", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblHour.ForeColor = System.Drawing.Color.DimGray
        Me.LblHour.Image = CType(resources.GetObject("LblHour.Image"), System.Drawing.Image)
        Me.LblHour.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.LblHour.Location = New System.Drawing.Point(360, 4)
        Me.LblHour.Name = "LblHour"
        Me.LblHour.Size = New System.Drawing.Size(104, 28)
        Me.LblHour.TabIndex = 34
        Me.LblHour.Text = "00:00"
        Me.LblHour.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'm_logo
        '
        Me.m_logo.Image = CType(resources.GetObject("m_logo.Image"), System.Drawing.Image)
        Me.m_logo.Location = New System.Drawing.Point(3, 3)
        Me.m_logo.Name = "m_logo"
        Me.m_logo.Size = New System.Drawing.Size(48, 48)
        Me.m_logo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.m_logo.TabIndex = 32
        Me.m_logo.TabStop = False
        '
        'PnlButton_Shell
        '
        Me.PnlButton_Shell.Controls.Add(Me.btImportar)
        Me.PnlButton_Shell.Controls.Add(Me.BtUpdatePVP)
        Me.PnlButton_Shell.Controls.Add(Me.BtClose)
        Me.PnlButton_Shell.Dock = System.Windows.Forms.DockStyle.Right
        Me.PnlButton_Shell.Location = New System.Drawing.Point(470, 0)
        Me.PnlButton_Shell.Name = "PnlButton_Shell"
        Me.PnlButton_Shell.Size = New System.Drawing.Size(550, 64)
        Me.PnlButton_Shell.TabIndex = 2
        '
        'btImportar
        '
        Me.btImportar.Enabled = False
        Me.btImportar.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btImportar.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Bold)
        Me.btImportar.Image = CType(resources.GetObject("btImportar.Image"), System.Drawing.Image)
        Me.btImportar.Location = New System.Drawing.Point(-13, 5)
        Me.btImportar.Name = "btImportar"
        Me.btImportar.Size = New System.Drawing.Size(194, 57)
        Me.btImportar.TabIndex = 9
        Me.btImportar.Tag = "IMPORTAR"
        Me.btImportar.Text = "Importar"
        Me.btImportar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btImportar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btImportar.UseVisualStyleBackColor = True
        '
        'BtUpdatePVP
        '
        Me.BtUpdatePVP.Enabled = False
        Me.BtUpdatePVP.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.BtUpdatePVP.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Bold)
        Me.BtUpdatePVP.Image = CType(resources.GetObject("BtUpdatePVP.Image"), System.Drawing.Image)
        Me.BtUpdatePVP.Location = New System.Drawing.Point(171, 6)
        Me.BtUpdatePVP.Name = "BtUpdatePVP"
        Me.BtUpdatePVP.Size = New System.Drawing.Size(194, 57)
        Me.BtUpdatePVP.TabIndex = 8
        Me.BtUpdatePVP.Tag = "UPDATE"
        Me.BtUpdatePVP.Text = "Actualizar Precios"
        Me.BtUpdatePVP.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BtUpdatePVP.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.BtUpdatePVP.UseVisualStyleBackColor = True
        '
        'BtClose
        '
        Me.BtClose.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.BtClose.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtClose.Image = CType(resources.GetObject("BtClose.Image"), System.Drawing.Image)
        Me.BtClose.Location = New System.Drawing.Point(368, 4)
        Me.BtClose.Name = "BtClose"
        Me.BtClose.Size = New System.Drawing.Size(170, 58)
        Me.BtClose.TabIndex = 7
        Me.BtClose.Tag = "close"
        Me.BtClose.Text = "Cerrar"
        Me.BtClose.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.BtClose.UseVisualStyleBackColor = True
        '
        'LblSubTitle
        '
        Me.LblSubTitle.ForeColor = System.Drawing.SystemColors.InactiveCaption
        Me.LblSubTitle.Location = New System.Drawing.Point(96, 32)
        Me.LblSubTitle.Name = "LblSubTitle"
        Me.LblSubTitle.Size = New System.Drawing.Size(290, 31)
        Me.LblSubTitle.TabIndex = 1
        Me.LblSubTitle.Text = "Gestión de marcas de estanco"
        '
        'LblTitle
        '
        Me.LblTitle.AutoSize = True
        Me.LblTitle.Font = New System.Drawing.Font("Tahoma", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblTitle.Location = New System.Drawing.Point(57, 4)
        Me.LblTitle.Name = "LblTitle"
        Me.LblTitle.Size = New System.Drawing.Size(193, 23)
        Me.LblTitle.TabIndex = 0
        Me.LblTitle.Text = "Gestión de Estanco"
        '
        'PnlBody
        '
        Me.PnlBody.BackColor = System.Drawing.SystemColors.Control
        Me.PnlBody.BackgroundImage = CType(resources.GetObject("PnlBody.BackgroundImage"), System.Drawing.Image)
        Me.PnlBody.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PnlBody.Controls.Add(Me.PnlData)
        Me.PnlBody.ForeColor = System.Drawing.Color.Black
        Me.PnlBody.Location = New System.Drawing.Point(12, 14)
        Me.PnlBody.Name = "PnlBody"
        Me.PnlBody.Size = New System.Drawing.Size(982, 669)
        Me.PnlBody.TabIndex = 0
        Me.PnlBody.Visible = False
        '
        'PnlData
        '
        Me.PnlData.BackColor = System.Drawing.Color.FromArgb(CType(CType(174, Byte), Integer), CType(CType(186, Byte), Integer), CType(CType(186, Byte), Integer))
        Me.PnlData.Controls.Add(Me.Tab)
        Me.PnlData.Location = New System.Drawing.Point(37, 34)
        Me.PnlData.Name = "PnlData"
        Me.PnlData.Size = New System.Drawing.Size(908, 603)
        Me.PnlData.TabIndex = 38
        '
        'Tab
        '
        Me.Tab.Controls.Add(Me.TabPage_Marcas)
        Me.Tab.Controls.Add(Me.TabPage_pedidos)
        Me.Tab.Controls.Add(Me.TabPage_Update)
        Me.Tab.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Tab.Location = New System.Drawing.Point(0, 3)
        Me.Tab.Name = "Tab"
        Me.Tab.SelectedIndex = 0
        Me.Tab.Size = New System.Drawing.Size(908, 600)
        Me.Tab.TabIndex = 41
        '
        'TabPage_Marcas
        '
        Me.TabPage_Marcas.Controls.Add(Me.SplitContainer1)
        Me.TabPage_Marcas.Location = New System.Drawing.Point(4, 22)
        Me.TabPage_Marcas.Name = "TabPage_Marcas"
        Me.TabPage_Marcas.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage_Marcas.Size = New System.Drawing.Size(900, 574)
        Me.TabPage_Marcas.TabIndex = 0
        Me.TabPage_Marcas.Text = "Lista de Productos"
        Me.TabPage_Marcas.UseVisualStyleBackColor = True
        '
        'SplitContainer1
        '
        Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer1.Location = New System.Drawing.Point(3, 3)
        Me.SplitContainer1.Name = "SplitContainer1"
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.gridMarcas)
        Me.SplitContainer1.Panel1.Controls.Add(Me.PnlFilter)
        Me.SplitContainer1.Panel1.Controls.Add(Me.PnlHistory)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label6)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.CheckBox1)
        Me.SplitContainer1.Panel2.Controls.Add(Me.chkActivo)
        Me.SplitContainer1.Panel2.Controls.Add(Me.lblTotProductos)
        Me.SplitContainer1.Panel2.Controls.Add(Me.Panel3)
        Me.SplitContainer1.Panel2.Controls.Add(Me.Label2)
        Me.SplitContainer1.Panel2.Controls.Add(Me.lblInfo)
        Me.SplitContainer1.Panel2.Controls.Add(Me.Label1)
        Me.SplitContainer1.Panel2.Controls.Add(Me.TxtFind)
        Me.SplitContainer1.Panel2.Controls.Add(Me.btMarca_edit)
        Me.SplitContainer1.Panel2.Controls.Add(Me.btPedido_Finalizar)
        Me.SplitContainer1.Panel2.Controls.Add(Me.btPedido_Comanda)
        Me.SplitContainer1.Panel2.Controls.Add(Me.btMarca_Add)
        Me.SplitContainer1.Panel2.Controls.Add(Me.btMarca_del)
        Me.SplitContainer1.Panel2.Controls.Add(Me.btPedido_Cancela)
        Me.SplitContainer1.Panel2.Controls.Add(Me.btPedido_Print)
        Me.SplitContainer1.Panel2.Controls.Add(Me.LblDaySelect)
        Me.SplitContainer1.Size = New System.Drawing.Size(894, 568)
        Me.SplitContainer1.SplitterDistance = 710
        Me.SplitContainer1.TabIndex = 0
        '
        'gridMarcas
        '
        Me.gridMarcas.AllowUserToAddRows = False
        Me.gridMarcas.AllowUserToDeleteRows = False
        Me.gridMarcas.AllowUserToOrderColumns = True
        Me.gridMarcas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.gridMarcas.Dock = System.Windows.Forms.DockStyle.Fill
        Me.gridMarcas.Location = New System.Drawing.Point(0, 63)
        Me.gridMarcas.Name = "gridMarcas"
        Me.gridMarcas.ReadOnly = True
        Me.gridMarcas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.gridMarcas.Size = New System.Drawing.Size(710, 505)
        Me.gridMarcas.TabIndex = 44
        '
        'PnlFilter
        '
        Me.PnlFilter.BackColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.PnlFilter.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.PnlFilter.Controls.Add(Me.Rbt_Filter_Z)
        Me.PnlFilter.Controls.Add(Me.Rbt_Filter_Y)
        Me.PnlFilter.Controls.Add(Me.Rbt_Filter_X)
        Me.PnlFilter.Controls.Add(Me.Rbt_Filter_W)
        Me.PnlFilter.Controls.Add(Me.V)
        Me.PnlFilter.Controls.Add(Me.Rbt_Filter_U)
        Me.PnlFilter.Controls.Add(Me.Rbt_Filter_T)
        Me.PnlFilter.Controls.Add(Me.Rbt_Filter_S)
        Me.PnlFilter.Controls.Add(Me.Rbt_Filter_R)
        Me.PnlFilter.Controls.Add(Me.Rbt_Filter_Q)
        Me.PnlFilter.Controls.Add(Me.Rbt_Filter_P)
        Me.PnlFilter.Controls.Add(Me.Rbt_Filter_O)
        Me.PnlFilter.Controls.Add(Me.Rbt_Filter_Ñ)
        Me.PnlFilter.Controls.Add(Me.Rbt_Filter_N)
        Me.PnlFilter.Controls.Add(Me.Rbt_Filter_M)
        Me.PnlFilter.Controls.Add(Me.Rbt_Filter_L)
        Me.PnlFilter.Controls.Add(Me.Rbt_Filter_K)
        Me.PnlFilter.Controls.Add(Me.Rbt_Filter_J)
        Me.PnlFilter.Controls.Add(Me.Rbt_Filter_I)
        Me.PnlFilter.Controls.Add(Me.Rbt_Filter_H)
        Me.PnlFilter.Controls.Add(Me.Rbt_Filter_G)
        Me.PnlFilter.Controls.Add(Me.Rbt_Filter_F)
        Me.PnlFilter.Controls.Add(Me.Rbt_Filter_E)
        Me.PnlFilter.Controls.Add(Me.Rbt_Filter_D)
        Me.PnlFilter.Controls.Add(Me.Rbt_Filter_C)
        Me.PnlFilter.Controls.Add(Me.Rbt_Filter_B)
        Me.PnlFilter.Controls.Add(Me.Rbt_Filter_A)
        Me.PnlFilter.Controls.Add(Me.Rbt_Filter_All)
        Me.PnlFilter.Dock = System.Windows.Forms.DockStyle.Top
        Me.PnlFilter.Location = New System.Drawing.Point(0, 29)
        Me.PnlFilter.Name = "PnlFilter"
        Me.PnlFilter.Size = New System.Drawing.Size(710, 34)
        Me.PnlFilter.TabIndex = 46
        '
        'Rbt_Filter_Z
        '
        Me.Rbt_Filter_Z.Appearance = System.Windows.Forms.Appearance.Button
        Me.Rbt_Filter_Z.Location = New System.Drawing.Point(679, 4)
        Me.Rbt_Filter_Z.Name = "Rbt_Filter_Z"
        Me.Rbt_Filter_Z.Size = New System.Drawing.Size(24, 23)
        Me.Rbt_Filter_Z.TabIndex = 27
        Me.Rbt_Filter_Z.Text = "Z"
        Me.Rbt_Filter_Z.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.Rbt_Filter_Z.UseVisualStyleBackColor = True
        '
        'Rbt_Filter_Y
        '
        Me.Rbt_Filter_Y.Appearance = System.Windows.Forms.Appearance.Button
        Me.Rbt_Filter_Y.Location = New System.Drawing.Point(655, 4)
        Me.Rbt_Filter_Y.Name = "Rbt_Filter_Y"
        Me.Rbt_Filter_Y.Size = New System.Drawing.Size(24, 23)
        Me.Rbt_Filter_Y.TabIndex = 26
        Me.Rbt_Filter_Y.Text = "Y"
        Me.Rbt_Filter_Y.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.Rbt_Filter_Y.UseVisualStyleBackColor = True
        '
        'Rbt_Filter_X
        '
        Me.Rbt_Filter_X.Appearance = System.Windows.Forms.Appearance.Button
        Me.Rbt_Filter_X.Location = New System.Drawing.Point(631, 4)
        Me.Rbt_Filter_X.Name = "Rbt_Filter_X"
        Me.Rbt_Filter_X.Size = New System.Drawing.Size(24, 23)
        Me.Rbt_Filter_X.TabIndex = 25
        Me.Rbt_Filter_X.Text = "X"
        Me.Rbt_Filter_X.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.Rbt_Filter_X.UseVisualStyleBackColor = True
        '
        'Rbt_Filter_W
        '
        Me.Rbt_Filter_W.Appearance = System.Windows.Forms.Appearance.Button
        Me.Rbt_Filter_W.Location = New System.Drawing.Point(607, 4)
        Me.Rbt_Filter_W.Name = "Rbt_Filter_W"
        Me.Rbt_Filter_W.Size = New System.Drawing.Size(24, 23)
        Me.Rbt_Filter_W.TabIndex = 24
        Me.Rbt_Filter_W.Text = "W"
        Me.Rbt_Filter_W.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.Rbt_Filter_W.UseVisualStyleBackColor = True
        '
        'V
        '
        Me.V.Appearance = System.Windows.Forms.Appearance.Button
        Me.V.Location = New System.Drawing.Point(583, 4)
        Me.V.Name = "V"
        Me.V.Size = New System.Drawing.Size(24, 23)
        Me.V.TabIndex = 23
        Me.V.Text = "V"
        Me.V.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.V.UseVisualStyleBackColor = True
        '
        'Rbt_Filter_U
        '
        Me.Rbt_Filter_U.Appearance = System.Windows.Forms.Appearance.Button
        Me.Rbt_Filter_U.Location = New System.Drawing.Point(559, 4)
        Me.Rbt_Filter_U.Name = "Rbt_Filter_U"
        Me.Rbt_Filter_U.Size = New System.Drawing.Size(24, 23)
        Me.Rbt_Filter_U.TabIndex = 22
        Me.Rbt_Filter_U.Text = "U"
        Me.Rbt_Filter_U.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.Rbt_Filter_U.UseVisualStyleBackColor = True
        '
        'Rbt_Filter_T
        '
        Me.Rbt_Filter_T.Appearance = System.Windows.Forms.Appearance.Button
        Me.Rbt_Filter_T.Location = New System.Drawing.Point(535, 4)
        Me.Rbt_Filter_T.Name = "Rbt_Filter_T"
        Me.Rbt_Filter_T.Size = New System.Drawing.Size(24, 23)
        Me.Rbt_Filter_T.TabIndex = 21
        Me.Rbt_Filter_T.Text = "T"
        Me.Rbt_Filter_T.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.Rbt_Filter_T.UseVisualStyleBackColor = True
        '
        'Rbt_Filter_S
        '
        Me.Rbt_Filter_S.Appearance = System.Windows.Forms.Appearance.Button
        Me.Rbt_Filter_S.Location = New System.Drawing.Point(511, 4)
        Me.Rbt_Filter_S.Name = "Rbt_Filter_S"
        Me.Rbt_Filter_S.Size = New System.Drawing.Size(24, 23)
        Me.Rbt_Filter_S.TabIndex = 20
        Me.Rbt_Filter_S.Text = "S"
        Me.Rbt_Filter_S.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.Rbt_Filter_S.UseVisualStyleBackColor = True
        '
        'Rbt_Filter_R
        '
        Me.Rbt_Filter_R.Appearance = System.Windows.Forms.Appearance.Button
        Me.Rbt_Filter_R.Location = New System.Drawing.Point(487, 4)
        Me.Rbt_Filter_R.Name = "Rbt_Filter_R"
        Me.Rbt_Filter_R.Size = New System.Drawing.Size(24, 23)
        Me.Rbt_Filter_R.TabIndex = 19
        Me.Rbt_Filter_R.Text = "R"
        Me.Rbt_Filter_R.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.Rbt_Filter_R.UseVisualStyleBackColor = True
        '
        'Rbt_Filter_Q
        '
        Me.Rbt_Filter_Q.Appearance = System.Windows.Forms.Appearance.Button
        Me.Rbt_Filter_Q.Location = New System.Drawing.Point(463, 4)
        Me.Rbt_Filter_Q.Name = "Rbt_Filter_Q"
        Me.Rbt_Filter_Q.Size = New System.Drawing.Size(24, 23)
        Me.Rbt_Filter_Q.TabIndex = 18
        Me.Rbt_Filter_Q.Text = "Q"
        Me.Rbt_Filter_Q.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.Rbt_Filter_Q.UseVisualStyleBackColor = True
        '
        'Rbt_Filter_P
        '
        Me.Rbt_Filter_P.Appearance = System.Windows.Forms.Appearance.Button
        Me.Rbt_Filter_P.Location = New System.Drawing.Point(439, 4)
        Me.Rbt_Filter_P.Name = "Rbt_Filter_P"
        Me.Rbt_Filter_P.Size = New System.Drawing.Size(24, 23)
        Me.Rbt_Filter_P.TabIndex = 17
        Me.Rbt_Filter_P.Text = "P"
        Me.Rbt_Filter_P.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.Rbt_Filter_P.UseVisualStyleBackColor = True
        '
        'Rbt_Filter_O
        '
        Me.Rbt_Filter_O.Appearance = System.Windows.Forms.Appearance.Button
        Me.Rbt_Filter_O.Location = New System.Drawing.Point(415, 4)
        Me.Rbt_Filter_O.Name = "Rbt_Filter_O"
        Me.Rbt_Filter_O.Size = New System.Drawing.Size(24, 23)
        Me.Rbt_Filter_O.TabIndex = 16
        Me.Rbt_Filter_O.Text = "O"
        Me.Rbt_Filter_O.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.Rbt_Filter_O.UseVisualStyleBackColor = True
        '
        'Rbt_Filter_Ñ
        '
        Me.Rbt_Filter_Ñ.Appearance = System.Windows.Forms.Appearance.Button
        Me.Rbt_Filter_Ñ.Location = New System.Drawing.Point(391, 4)
        Me.Rbt_Filter_Ñ.Name = "Rbt_Filter_Ñ"
        Me.Rbt_Filter_Ñ.Size = New System.Drawing.Size(24, 23)
        Me.Rbt_Filter_Ñ.TabIndex = 15
        Me.Rbt_Filter_Ñ.Text = "Ñ"
        Me.Rbt_Filter_Ñ.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.Rbt_Filter_Ñ.UseVisualStyleBackColor = True
        '
        'Rbt_Filter_N
        '
        Me.Rbt_Filter_N.Appearance = System.Windows.Forms.Appearance.Button
        Me.Rbt_Filter_N.Location = New System.Drawing.Point(367, 4)
        Me.Rbt_Filter_N.Name = "Rbt_Filter_N"
        Me.Rbt_Filter_N.Size = New System.Drawing.Size(24, 23)
        Me.Rbt_Filter_N.TabIndex = 14
        Me.Rbt_Filter_N.Text = "N"
        Me.Rbt_Filter_N.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.Rbt_Filter_N.UseVisualStyleBackColor = True
        '
        'Rbt_Filter_M
        '
        Me.Rbt_Filter_M.Appearance = System.Windows.Forms.Appearance.Button
        Me.Rbt_Filter_M.Location = New System.Drawing.Point(343, 4)
        Me.Rbt_Filter_M.Name = "Rbt_Filter_M"
        Me.Rbt_Filter_M.Size = New System.Drawing.Size(24, 23)
        Me.Rbt_Filter_M.TabIndex = 13
        Me.Rbt_Filter_M.Text = "M"
        Me.Rbt_Filter_M.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.Rbt_Filter_M.UseVisualStyleBackColor = True
        '
        'Rbt_Filter_L
        '
        Me.Rbt_Filter_L.Appearance = System.Windows.Forms.Appearance.Button
        Me.Rbt_Filter_L.Location = New System.Drawing.Point(319, 4)
        Me.Rbt_Filter_L.Name = "Rbt_Filter_L"
        Me.Rbt_Filter_L.Size = New System.Drawing.Size(24, 23)
        Me.Rbt_Filter_L.TabIndex = 12
        Me.Rbt_Filter_L.Text = "L"
        Me.Rbt_Filter_L.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.Rbt_Filter_L.UseVisualStyleBackColor = True
        '
        'Rbt_Filter_K
        '
        Me.Rbt_Filter_K.Appearance = System.Windows.Forms.Appearance.Button
        Me.Rbt_Filter_K.Location = New System.Drawing.Point(295, 4)
        Me.Rbt_Filter_K.Name = "Rbt_Filter_K"
        Me.Rbt_Filter_K.Size = New System.Drawing.Size(24, 23)
        Me.Rbt_Filter_K.TabIndex = 11
        Me.Rbt_Filter_K.Text = "K"
        Me.Rbt_Filter_K.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.Rbt_Filter_K.UseVisualStyleBackColor = True
        '
        'Rbt_Filter_J
        '
        Me.Rbt_Filter_J.Appearance = System.Windows.Forms.Appearance.Button
        Me.Rbt_Filter_J.Location = New System.Drawing.Point(271, 4)
        Me.Rbt_Filter_J.Name = "Rbt_Filter_J"
        Me.Rbt_Filter_J.Size = New System.Drawing.Size(24, 23)
        Me.Rbt_Filter_J.TabIndex = 10
        Me.Rbt_Filter_J.Text = "J"
        Me.Rbt_Filter_J.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.Rbt_Filter_J.UseVisualStyleBackColor = True
        '
        'Rbt_Filter_I
        '
        Me.Rbt_Filter_I.Appearance = System.Windows.Forms.Appearance.Button
        Me.Rbt_Filter_I.Location = New System.Drawing.Point(247, 4)
        Me.Rbt_Filter_I.Name = "Rbt_Filter_I"
        Me.Rbt_Filter_I.Size = New System.Drawing.Size(24, 23)
        Me.Rbt_Filter_I.TabIndex = 9
        Me.Rbt_Filter_I.Text = "I"
        Me.Rbt_Filter_I.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.Rbt_Filter_I.UseVisualStyleBackColor = True
        '
        'Rbt_Filter_H
        '
        Me.Rbt_Filter_H.Appearance = System.Windows.Forms.Appearance.Button
        Me.Rbt_Filter_H.Location = New System.Drawing.Point(223, 4)
        Me.Rbt_Filter_H.Name = "Rbt_Filter_H"
        Me.Rbt_Filter_H.Size = New System.Drawing.Size(24, 23)
        Me.Rbt_Filter_H.TabIndex = 8
        Me.Rbt_Filter_H.Text = "H"
        Me.Rbt_Filter_H.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.Rbt_Filter_H.UseVisualStyleBackColor = True
        '
        'Rbt_Filter_G
        '
        Me.Rbt_Filter_G.Appearance = System.Windows.Forms.Appearance.Button
        Me.Rbt_Filter_G.Location = New System.Drawing.Point(199, 4)
        Me.Rbt_Filter_G.Name = "Rbt_Filter_G"
        Me.Rbt_Filter_G.Size = New System.Drawing.Size(24, 23)
        Me.Rbt_Filter_G.TabIndex = 7
        Me.Rbt_Filter_G.Text = "G"
        Me.Rbt_Filter_G.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.Rbt_Filter_G.UseVisualStyleBackColor = True
        '
        'Rbt_Filter_F
        '
        Me.Rbt_Filter_F.Appearance = System.Windows.Forms.Appearance.Button
        Me.Rbt_Filter_F.Location = New System.Drawing.Point(175, 4)
        Me.Rbt_Filter_F.Name = "Rbt_Filter_F"
        Me.Rbt_Filter_F.Size = New System.Drawing.Size(24, 23)
        Me.Rbt_Filter_F.TabIndex = 6
        Me.Rbt_Filter_F.Text = "F"
        Me.Rbt_Filter_F.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.Rbt_Filter_F.UseVisualStyleBackColor = True
        '
        'Rbt_Filter_E
        '
        Me.Rbt_Filter_E.Appearance = System.Windows.Forms.Appearance.Button
        Me.Rbt_Filter_E.Location = New System.Drawing.Point(151, 4)
        Me.Rbt_Filter_E.Name = "Rbt_Filter_E"
        Me.Rbt_Filter_E.Size = New System.Drawing.Size(24, 23)
        Me.Rbt_Filter_E.TabIndex = 5
        Me.Rbt_Filter_E.Text = "E"
        Me.Rbt_Filter_E.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.Rbt_Filter_E.UseVisualStyleBackColor = True
        '
        'Rbt_Filter_D
        '
        Me.Rbt_Filter_D.Appearance = System.Windows.Forms.Appearance.Button
        Me.Rbt_Filter_D.Location = New System.Drawing.Point(127, 4)
        Me.Rbt_Filter_D.Name = "Rbt_Filter_D"
        Me.Rbt_Filter_D.Size = New System.Drawing.Size(24, 23)
        Me.Rbt_Filter_D.TabIndex = 4
        Me.Rbt_Filter_D.Text = "D"
        Me.Rbt_Filter_D.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.Rbt_Filter_D.UseVisualStyleBackColor = True
        '
        'Rbt_Filter_C
        '
        Me.Rbt_Filter_C.Appearance = System.Windows.Forms.Appearance.Button
        Me.Rbt_Filter_C.Location = New System.Drawing.Point(103, 4)
        Me.Rbt_Filter_C.Name = "Rbt_Filter_C"
        Me.Rbt_Filter_C.Size = New System.Drawing.Size(24, 23)
        Me.Rbt_Filter_C.TabIndex = 3
        Me.Rbt_Filter_C.Text = "C"
        Me.Rbt_Filter_C.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.Rbt_Filter_C.UseVisualStyleBackColor = True
        '
        'Rbt_Filter_B
        '
        Me.Rbt_Filter_B.Appearance = System.Windows.Forms.Appearance.Button
        Me.Rbt_Filter_B.Location = New System.Drawing.Point(79, 4)
        Me.Rbt_Filter_B.Name = "Rbt_Filter_B"
        Me.Rbt_Filter_B.Size = New System.Drawing.Size(24, 23)
        Me.Rbt_Filter_B.TabIndex = 2
        Me.Rbt_Filter_B.Text = "B"
        Me.Rbt_Filter_B.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.Rbt_Filter_B.UseVisualStyleBackColor = True
        '
        'Rbt_Filter_A
        '
        Me.Rbt_Filter_A.Appearance = System.Windows.Forms.Appearance.Button
        Me.Rbt_Filter_A.Location = New System.Drawing.Point(55, 4)
        Me.Rbt_Filter_A.Name = "Rbt_Filter_A"
        Me.Rbt_Filter_A.Size = New System.Drawing.Size(24, 23)
        Me.Rbt_Filter_A.TabIndex = 1
        Me.Rbt_Filter_A.Text = "A"
        Me.Rbt_Filter_A.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.Rbt_Filter_A.UseVisualStyleBackColor = True
        '
        'Rbt_Filter_All
        '
        Me.Rbt_Filter_All.Appearance = System.Windows.Forms.Appearance.Button
        Me.Rbt_Filter_All.Checked = True
        Me.Rbt_Filter_All.Font = New System.Drawing.Font("Microsoft Sans Serif", 27.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Rbt_Filter_All.Location = New System.Drawing.Point(3, 4)
        Me.Rbt_Filter_All.Name = "Rbt_Filter_All"
        Me.Rbt_Filter_All.Size = New System.Drawing.Size(49, 23)
        Me.Rbt_Filter_All.TabIndex = 0
        Me.Rbt_Filter_All.TabStop = True
        Me.Rbt_Filter_All.Text = "~"
        Me.Rbt_Filter_All.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.Rbt_Filter_All.UseVisualStyleBackColor = True
        '
        'PnlHistory
        '
        Me.PnlHistory.BackColor = System.Drawing.Color.Gainsboro
        Me.PnlHistory.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.PnlHistory.Controls.Add(Me.GroupHistory)
        Me.PnlHistory.Controls.Add(Me.BtHistory_Next)
        Me.PnlHistory.Controls.Add(Me.BtHistory_Previous)
        Me.PnlHistory.Location = New System.Drawing.Point(90, 486)
        Me.PnlHistory.Name = "PnlHistory"
        Me.PnlHistory.Size = New System.Drawing.Size(487, 79)
        Me.PnlHistory.TabIndex = 40
        Me.PnlHistory.Visible = False
        '
        'GroupHistory
        '
        Me.GroupHistory.BackColor = System.Drawing.Color.Gainsboro
        Me.GroupHistory.Controls.Add(Me.lblHistory_ID)
        Me.GroupHistory.Controls.Add(Me.BtHistory_Edit)
        Me.GroupHistory.Controls.Add(Me.BtHistory_Print)
        Me.GroupHistory.Controls.Add(Me.LblHistory_Fh)
        Me.GroupHistory.Controls.Add(Me.Label16)
        Me.GroupHistory.Controls.Add(Me.Label17)
        Me.GroupHistory.Controls.Add(Me.LblHistory_Mesa)
        Me.GroupHistory.Controls.Add(Me.Label14)
        Me.GroupHistory.Controls.Add(Me.LblHistory_Total)
        Me.GroupHistory.Controls.Add(Me.LblHistory_Empleado)
        Me.GroupHistory.Font = New System.Drawing.Font("Tahoma", 6.75!)
        Me.GroupHistory.Location = New System.Drawing.Point(55, 1)
        Me.GroupHistory.Name = "GroupHistory"
        Me.GroupHistory.Size = New System.Drawing.Size(371, 71)
        Me.GroupHistory.TabIndex = 23
        Me.GroupHistory.TabStop = False
        Me.GroupHistory.Text = "Historial de Pedidos"
        '
        'lblHistory_ID
        '
        Me.lblHistory_ID.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblHistory_ID.ForeColor = System.Drawing.Color.DimGray
        Me.lblHistory_ID.Location = New System.Drawing.Point(236, 42)
        Me.lblHistory_ID.Name = "lblHistory_ID"
        Me.lblHistory_ID.Size = New System.Drawing.Size(74, 13)
        Me.lblHistory_ID.TabIndex = 42
        Me.lblHistory_ID.Text = "ID"
        Me.lblHistory_ID.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'BtHistory_Edit
        '
        Me.BtHistory_Edit.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtHistory_Edit.Image = CType(resources.GetObject("BtHistory_Edit.Image"), System.Drawing.Image)
        Me.BtHistory_Edit.Location = New System.Drawing.Point(316, 38)
        Me.BtHistory_Edit.Name = "BtHistory_Edit"
        Me.BtHistory_Edit.Size = New System.Drawing.Size(49, 31)
        Me.BtHistory_Edit.TabIndex = 2
        Me.BtHistory_Edit.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.BtHistory_Edit.UseVisualStyleBackColor = True
        '
        'BtHistory_Print
        '
        Me.BtHistory_Print.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtHistory_Print.Image = CType(resources.GetObject("BtHistory_Print.Image"), System.Drawing.Image)
        Me.BtHistory_Print.Location = New System.Drawing.Point(316, 7)
        Me.BtHistory_Print.Name = "BtHistory_Print"
        Me.BtHistory_Print.Size = New System.Drawing.Size(49, 31)
        Me.BtHistory_Print.TabIndex = 1
        Me.BtHistory_Print.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.BtHistory_Print.UseVisualStyleBackColor = True
        '
        'LblHistory_Fh
        '
        Me.LblHistory_Fh.BackColor = System.Drawing.Color.Gainsboro
        Me.LblHistory_Fh.Font = New System.Drawing.Font("Tahoma", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblHistory_Fh.Location = New System.Drawing.Point(7, 11)
        Me.LblHistory_Fh.Name = "LblHistory_Fh"
        Me.LblHistory_Fh.Size = New System.Drawing.Size(150, 12)
        Me.LblHistory_Fh.TabIndex = 41
        Me.LblHistory_Fh.Text = "Fecha: 09/09/2008 00:00"
        Me.LblHistory_Fh.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.BackColor = System.Drawing.Color.Silver
        Me.Label16.Font = New System.Drawing.Font("Tahoma", 5.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.Location = New System.Drawing.Point(165, 9)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(37, 8)
        Me.Label16.TabIndex = 34
        Me.Label16.Text = "IMPORTE"
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Font = New System.Drawing.Font("Tahoma", 6.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.ForeColor = System.Drawing.Color.Black
        Me.Label17.Location = New System.Drawing.Point(11, 49)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(38, 10)
        Me.Label17.TabIndex = 32
        Me.Label17.Text = "CLIENTE:"
        '
        'LblHistory_Mesa
        '
        Me.LblHistory_Mesa.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblHistory_Mesa.ForeColor = System.Drawing.Color.Black
        Me.LblHistory_Mesa.Location = New System.Drawing.Point(69, 47)
        Me.LblHistory_Mesa.Name = "LblHistory_Mesa"
        Me.LblHistory_Mesa.Size = New System.Drawing.Size(241, 20)
        Me.LblHistory_Mesa.TabIndex = 31
        Me.LblHistory_Mesa.Text = "CAJA DIRECTA"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Tahoma", 6.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.ForeColor = System.Drawing.Color.Black
        Me.Label14.Location = New System.Drawing.Point(11, 31)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(55, 10)
        Me.Label14.TabIndex = 36
        Me.Label14.Text = "REPARTIDOR:"
        '
        'LblHistory_Total
        '
        Me.LblHistory_Total.BackColor = System.Drawing.Color.Silver
        Me.LblHistory_Total.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LblHistory_Total.Font = New System.Drawing.Font("Tahoma", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblHistory_Total.Location = New System.Drawing.Point(161, 8)
        Me.LblHistory_Total.Name = "LblHistory_Total"
        Me.LblHistory_Total.Size = New System.Drawing.Size(142, 34)
        Me.LblHistory_Total.TabIndex = 0
        Me.LblHistory_Total.Text = "0 €"
        Me.LblHistory_Total.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'BtHistory_Next
        '
        Me.BtHistory_Next.BackColor = System.Drawing.SystemColors.Control
        Me.BtHistory_Next.Enabled = False
        Me.BtHistory_Next.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtHistory_Next.Image = CType(resources.GetObject("BtHistory_Next.Image"), System.Drawing.Image)
        Me.BtHistory_Next.Location = New System.Drawing.Point(432, 1)
        Me.BtHistory_Next.Name = "BtHistory_Next"
        Me.BtHistory_Next.Size = New System.Drawing.Size(50, 73)
        Me.BtHistory_Next.TabIndex = 1
        Me.BtHistory_Next.Tag = ""
        Me.BtHistory_Next.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtHistory_Next.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage
        Me.BtHistory_Next.UseVisualStyleBackColor = False
        '
        'BtHistory_Previous
        '
        Me.BtHistory_Previous.BackColor = System.Drawing.SystemColors.Control
        Me.BtHistory_Previous.Enabled = False
        Me.BtHistory_Previous.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtHistory_Previous.Image = CType(resources.GetObject("BtHistory_Previous.Image"), System.Drawing.Image)
        Me.BtHistory_Previous.Location = New System.Drawing.Point(0, 1)
        Me.BtHistory_Previous.Name = "BtHistory_Previous"
        Me.BtHistory_Previous.Size = New System.Drawing.Size(49, 73)
        Me.BtHistory_Previous.TabIndex = 0
        Me.BtHistory_Previous.Tag = ""
        Me.BtHistory_Previous.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BtHistory_Previous.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.BtHistory_Previous.UseVisualStyleBackColor = False
        '
        'Label6
        '
        Me.Label6.BackColor = System.Drawing.Color.LightSteelBlue
        Me.Label6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label6.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label6.Font = New System.Drawing.Font("Verdana", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Image = CType(resources.GetObject("Label6.Image"), System.Drawing.Image)
        Me.Label6.ImageAlign = System.Drawing.ContentAlignment.TopLeft
        Me.Label6.Location = New System.Drawing.Point(0, 0)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(710, 29)
        Me.Label6.TabIndex = 45
        Me.Label6.Text = "LISTA DE MARCAS"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'CheckBox1
        '
        Me.CheckBox1.AutoSize = True
        Me.CheckBox1.BackColor = System.Drawing.Color.Transparent
        Me.CheckBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CheckBox1.Location = New System.Drawing.Point(15, 397)
        Me.CheckBox1.Name = "CheckBox1"
        Me.CheckBox1.Size = New System.Drawing.Size(157, 19)
        Me.CheckBox1.TabIndex = 58
        Me.CheckBox1.Tag = ""
        Me.CheckBox1.Text = "Marcas descatalogadas"
        Me.CheckBox1.UseVisualStyleBackColor = False
        '
        'chkActivo
        '
        Me.chkActivo.AutoSize = True
        Me.chkActivo.BackColor = System.Drawing.Color.Transparent
        Me.chkActivo.Checked = True
        Me.chkActivo.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkActivo.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkActivo.Location = New System.Drawing.Point(15, 303)
        Me.chkActivo.Name = "chkActivo"
        Me.chkActivo.Size = New System.Drawing.Size(129, 28)
        Me.chkActivo.TabIndex = 57
        Me.chkActivo.Tag = "activo"
        Me.chkActivo.Text = "Solo activos"
        Me.chkActivo.UseVisualStyleBackColor = False
        '
        'lblTotProductos
        '
        Me.lblTotProductos.BackColor = System.Drawing.Color.Transparent
        Me.lblTotProductos.Font = New System.Drawing.Font("Tahoma", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotProductos.Location = New System.Drawing.Point(13, 241)
        Me.lblTotProductos.Name = "lblTotProductos"
        Me.lblTotProductos.Size = New System.Drawing.Size(40, 11)
        Me.lblTotProductos.TabIndex = 56
        Me.lblTotProductos.Text = "0"
        Me.lblTotProductos.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'Panel3
        '
        Me.Panel3.Controls.Add(Me.dtFhUpdate)
        Me.Panel3.Controls.Add(Label8)
        Me.Panel3.Controls.Add(Me.Label9)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel3.Location = New System.Drawing.Point(0, 425)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(180, 72)
        Me.Panel3.TabIndex = 55
        '
        'dtFhUpdate
        '
        Me.dtFhUpdate.CalendarFont = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtFhUpdate.CustomFormat = "dd/MM/yyyy"
        Me.dtFhUpdate.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtFhUpdate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtFhUpdate.Location = New System.Drawing.Point(15, 40)
        Me.dtFhUpdate.Name = "dtFhUpdate"
        Me.dtFhUpdate.Size = New System.Drawing.Size(161, 27)
        Me.dtFhUpdate.TabIndex = 64
        Me.dtFhUpdate.Tag = "fh_venta"
        '
        'Label9
        '
        Me.Label9.BackColor = System.Drawing.Color.LightSteelBlue
        Me.Label9.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label9.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label9.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Image = CType(resources.GetObject("Label9.Image"), System.Drawing.Image)
        Me.Label9.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Label9.Location = New System.Drawing.Point(0, 0)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(180, 21)
        Me.Label9.TabIndex = 50
        Me.Label9.Text = "Precios Actualizados"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.LightSteelBlue
        Me.Label2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Label2.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Image = CType(resources.GetObject("Label2.Image"), System.Drawing.Image)
        Me.Label2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Label2.Location = New System.Drawing.Point(0, 497)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(180, 21)
        Me.Label2.TabIndex = 54
        Me.Label2.Text = "Detalles"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblInfo
        '
        Me.lblInfo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblInfo.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.lblInfo.Font = New System.Drawing.Font("Arial", 6.75!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblInfo.Location = New System.Drawing.Point(0, 518)
        Me.lblInfo.Name = "lblInfo"
        Me.lblInfo.Padding = New System.Windows.Forms.Padding(3)
        Me.lblInfo.Size = New System.Drawing.Size(180, 50)
        Me.lblInfo.TabIndex = 53
        Me.lblInfo.Text = "Label2"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Tahoma", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(12, 189)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(106, 11)
        Me.Label1.TabIndex = 47
        Me.Label1.Text = "BUSCA Y FILTRA POR"
        '
        'TxtFind
        '
        Me.TxtFind.Font = New System.Drawing.Font("Tahoma", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtFind.Location = New System.Drawing.Point(9, 202)
        Me.TxtFind.Name = "TxtFind"
        Me.TxtFind.Size = New System.Drawing.Size(166, 36)
        Me.TxtFind.TabIndex = 46
        '
        'btMarca_edit
        '
        Me.btMarca_edit.BackColor = System.Drawing.SystemColors.Control
        Me.btMarca_edit.Enabled = False
        Me.btMarca_edit.Font = New System.Drawing.Font("Tahoma", 11.25!)
        Me.btMarca_edit.Image = CType(resources.GetObject("btMarca_edit.Image"), System.Drawing.Image)
        Me.btMarca_edit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btMarca_edit.Location = New System.Drawing.Point(3, 81)
        Me.btMarca_edit.Name = "btMarca_edit"
        Me.btMarca_edit.Size = New System.Drawing.Size(174, 37)
        Me.btMarca_edit.TabIndex = 45
        Me.btMarca_edit.Tag = "ADD"
        Me.btMarca_edit.Text = "Editar Marca"
        Me.btMarca_edit.TextAlign = System.Drawing.ContentAlignment.TopRight
        Me.btMarca_edit.UseVisualStyleBackColor = False
        '
        'btPedido_Finalizar
        '
        Me.btPedido_Finalizar.BackColor = System.Drawing.SystemColors.Control
        Me.btPedido_Finalizar.Font = New System.Drawing.Font("Tahoma", 11.25!)
        Me.btPedido_Finalizar.Image = CType(resources.GetObject("btPedido_Finalizar.Image"), System.Drawing.Image)
        Me.btPedido_Finalizar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btPedido_Finalizar.Location = New System.Drawing.Point(32, 337)
        Me.btPedido_Finalizar.Name = "btPedido_Finalizar"
        Me.btPedido_Finalizar.Size = New System.Drawing.Size(106, 65)
        Me.btPedido_Finalizar.TabIndex = 44
        Me.btPedido_Finalizar.Tag = ""
        Me.btPedido_Finalizar.Text = "Finalizar Entregas"
        Me.btPedido_Finalizar.TextAlign = System.Drawing.ContentAlignment.TopRight
        Me.btPedido_Finalizar.UseVisualStyleBackColor = False
        Me.btPedido_Finalizar.Visible = False
        '
        'btPedido_Comanda
        '
        Me.btPedido_Comanda.BackColor = System.Drawing.SystemColors.Control
        Me.btPedido_Comanda.Enabled = False
        Me.btPedido_Comanda.Font = New System.Drawing.Font("Tahoma", 11.25!)
        Me.btPedido_Comanda.Image = CType(resources.GetObject("btPedido_Comanda.Image"), System.Drawing.Image)
        Me.btPedido_Comanda.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btPedido_Comanda.Location = New System.Drawing.Point(70, 195)
        Me.btPedido_Comanda.Name = "btPedido_Comanda"
        Me.btPedido_Comanda.Size = New System.Drawing.Size(106, 65)
        Me.btPedido_Comanda.TabIndex = 2
        Me.btPedido_Comanda.Tag = "PRINTCOMANDA"
        Me.btPedido_Comanda.Text = "Imprimir Comanda"
        Me.btPedido_Comanda.TextAlign = System.Drawing.ContentAlignment.TopRight
        Me.btPedido_Comanda.UseVisualStyleBackColor = False
        Me.btPedido_Comanda.Visible = False
        '
        'btMarca_Add
        '
        Me.btMarca_Add.BackColor = System.Drawing.SystemColors.Control
        Me.btMarca_Add.Font = New System.Drawing.Font("Tahoma", 11.25!)
        Me.btMarca_Add.Image = CType(resources.GetObject("btMarca_Add.Image"), System.Drawing.Image)
        Me.btMarca_Add.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btMarca_Add.Location = New System.Drawing.Point(3, 38)
        Me.btMarca_Add.Name = "btMarca_Add"
        Me.btMarca_Add.Size = New System.Drawing.Size(174, 37)
        Me.btMarca_Add.TabIndex = 0
        Me.btMarca_Add.Tag = "ADD"
        Me.btMarca_Add.Text = "Agregar Marca"
        Me.btMarca_Add.TextAlign = System.Drawing.ContentAlignment.TopRight
        Me.btMarca_Add.UseVisualStyleBackColor = False
        '
        'btMarca_del
        '
        Me.btMarca_del.BackColor = System.Drawing.SystemColors.Control
        Me.btMarca_del.Enabled = False
        Me.btMarca_del.Font = New System.Drawing.Font("Tahoma", 11.25!)
        Me.btMarca_del.Image = CType(resources.GetObject("btMarca_del.Image"), System.Drawing.Image)
        Me.btMarca_del.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btMarca_del.Location = New System.Drawing.Point(3, 124)
        Me.btMarca_del.Name = "btMarca_del"
        Me.btMarca_del.Size = New System.Drawing.Size(174, 37)
        Me.btMarca_del.TabIndex = 4
        Me.btMarca_del.Tag = "ELIMINAR"
        Me.btMarca_del.Text = "Eliminar Marca"
        Me.btMarca_del.TextAlign = System.Drawing.ContentAlignment.TopRight
        Me.btMarca_del.UseVisualStyleBackColor = False
        '
        'btPedido_Cancela
        '
        Me.btPedido_Cancela.BackColor = System.Drawing.SystemColors.Control
        Me.btPedido_Cancela.Enabled = False
        Me.btPedido_Cancela.Font = New System.Drawing.Font("Tahoma", 11.25!)
        Me.btPedido_Cancela.Image = CType(resources.GetObject("btPedido_Cancela.Image"), System.Drawing.Image)
        Me.btPedido_Cancela.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btPedido_Cancela.Location = New System.Drawing.Point(70, 266)
        Me.btPedido_Cancela.Name = "btPedido_Cancela"
        Me.btPedido_Cancela.Size = New System.Drawing.Size(106, 65)
        Me.btPedido_Cancela.TabIndex = 3
        Me.btPedido_Cancela.Tag = "CANCELARPEDIDO"
        Me.btPedido_Cancela.Text = "Cancelar Pedido"
        Me.btPedido_Cancela.TextAlign = System.Drawing.ContentAlignment.TopRight
        Me.btPedido_Cancela.UseVisualStyleBackColor = False
        Me.btPedido_Cancela.Visible = False
        '
        'btPedido_Print
        '
        Me.btPedido_Print.BackColor = System.Drawing.SystemColors.Control
        Me.btPedido_Print.Enabled = False
        Me.btPedido_Print.Font = New System.Drawing.Font("Tahoma", 11.25!)
        Me.btPedido_Print.Image = CType(resources.GetObject("btPedido_Print.Image"), System.Drawing.Image)
        Me.btPedido_Print.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btPedido_Print.Location = New System.Drawing.Point(50, 252)
        Me.btPedido_Print.Name = "btPedido_Print"
        Me.btPedido_Print.Size = New System.Drawing.Size(106, 65)
        Me.btPedido_Print.TabIndex = 1
        Me.btPedido_Print.Tag = "PRINTPEDIDO"
        Me.btPedido_Print.Text = "Imprimir Pedido"
        Me.btPedido_Print.TextAlign = System.Drawing.ContentAlignment.TopRight
        Me.btPedido_Print.UseVisualStyleBackColor = False
        Me.btPedido_Print.Visible = False
        '
        'LblDaySelect
        '
        Me.LblDaySelect.BackColor = System.Drawing.Color.LightSteelBlue
        Me.LblDaySelect.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LblDaySelect.Dock = System.Windows.Forms.DockStyle.Top
        Me.LblDaySelect.Font = New System.Drawing.Font("Verdana", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblDaySelect.Image = CType(resources.GetObject("LblDaySelect.Image"), System.Drawing.Image)
        Me.LblDaySelect.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.LblDaySelect.Location = New System.Drawing.Point(0, 0)
        Me.LblDaySelect.Name = "LblDaySelect"
        Me.LblDaySelect.Size = New System.Drawing.Size(180, 35)
        Me.LblDaySelect.TabIndex = 43
        Me.LblDaySelect.Text = "ACCIONES"
        Me.LblDaySelect.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'TabPage_pedidos
        '
        Me.TabPage_pedidos.Controls.Add(Me.SplitHistory)
        Me.TabPage_pedidos.Location = New System.Drawing.Point(4, 22)
        Me.TabPage_pedidos.Name = "TabPage_pedidos"
        Me.TabPage_pedidos.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage_pedidos.Size = New System.Drawing.Size(900, 574)
        Me.TabPage_pedidos.TabIndex = 1
        Me.TabPage_pedidos.Text = "Pedidos de Compra"
        Me.TabPage_pedidos.UseVisualStyleBackColor = True
        '
        'SplitHistory
        '
        Me.SplitHistory.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitHistory.FixedPanel = System.Windows.Forms.FixedPanel.Panel1
        Me.SplitHistory.Location = New System.Drawing.Point(3, 3)
        Me.SplitHistory.Name = "SplitHistory"
        '
        'SplitHistory.Panel1
        '
        Me.SplitHistory.Panel1.Controls.Add(Me.gridLineas)
        Me.SplitHistory.Panel1.Controls.Add(Me.btAll)
        Me.SplitHistory.Panel1.Controls.Add(Me.Label20)
        '
        'SplitHistory.Panel2
        '
        Me.SplitHistory.Panel2.Controls.Add(Me.lblNPedidos)
        Me.SplitHistory.Panel2.Controls.Add(Me.groupPedido)
        Me.SplitHistory.Panel2.Controls.Add(Me.gridPedidos)
        Me.SplitHistory.Panel2.Controls.Add(Me.btPrint)
        Me.SplitHistory.Panel2.Controls.Add(Me.Label4)
        Me.SplitHistory.Panel2.Controls.Add(Me.btSave)
        Me.SplitHistory.Panel2.Controls.Add(Me.btCancell)
        Me.SplitHistory.Panel2.Controls.Add(Me.BtEdit)
        Me.SplitHistory.Panel2.Controls.Add(Me.BtNew)
        Me.SplitHistory.Panel2.Controls.Add(Me.BtDel)
        Me.SplitHistory.Panel2.Controls.Add(Me.Label21)
        Me.SplitHistory.Size = New System.Drawing.Size(894, 568)
        Me.SplitHistory.SplitterDistance = 585
        Me.SplitHistory.SplitterWidth = 2
        Me.SplitHistory.TabIndex = 2
        '
        'gridLineas
        '
        Me.gridLineas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.gridLineas.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.sw, Me.id, Me.grid_txtCodBarras, Me.grid_txtRef, Me.grid_txtCodigo, Me.grid_lblName, Me.grid_txtUd})
        Me.gridLineas.Dock = System.Windows.Forms.DockStyle.Fill
        Me.gridLineas.Location = New System.Drawing.Point(0, 27)
        Me.gridLineas.Name = "gridLineas"
        Me.gridLineas.Size = New System.Drawing.Size(585, 541)
        Me.gridLineas.TabIndex = 14
        '
        'sw
        '
        Me.sw.HeaderText = ""
        Me.sw.Name = "sw"
        Me.sw.ReadOnly = True
        Me.sw.Width = 20
        '
        'id
        '
        Me.id.HeaderText = "id"
        Me.id.Name = "id"
        Me.id.ReadOnly = True
        Me.id.Width = 35
        '
        'grid_txtCodBarras
        '
        Me.grid_txtCodBarras.HeaderText = "Cod. Barras"
        Me.grid_txtCodBarras.Name = "grid_txtCodBarras"
        Me.grid_txtCodBarras.Width = 90
        '
        'grid_txtRef
        '
        Me.grid_txtRef.HeaderText = "Ref."
        Me.grid_txtRef.Name = "grid_txtRef"
        Me.grid_txtRef.Width = 60
        '
        'grid_txtCodigo
        '
        Me.grid_txtCodigo.HeaderText = "CódCMT"
        Me.grid_txtCodigo.Name = "grid_txtCodigo"
        Me.grid_txtCodigo.Width = 60
        '
        'grid_lblName
        '
        Me.grid_lblName.HeaderText = "Producto"
        Me.grid_lblName.Name = "grid_lblName"
        Me.grid_lblName.ReadOnly = True
        Me.grid_lblName.Width = 200
        '
        'grid_txtUd
        '
        Me.grid_txtUd.FillWeight = 50.0!
        Me.grid_txtUd.HeaderText = "Ud."
        Me.grid_txtUd.Name = "grid_txtUd"
        Me.grid_txtUd.Width = 50
        '
        'btAll
        '
        Me.btAll.BackColor = System.Drawing.Color.PowderBlue
        Me.btAll.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btAll.Image = CType(resources.GetObject("btAll.Image"), System.Drawing.Image)
        Me.btAll.Location = New System.Drawing.Point(526, 2)
        Me.btAll.Name = "btAll"
        Me.btAll.Size = New System.Drawing.Size(55, 22)
        Me.btAll.TabIndex = 9
        Me.btAll.Tag = ""
        Me.btAll.Text = "  All"
        Me.btAll.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btAll.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btAll.UseVisualStyleBackColor = False
        Me.btAll.Visible = False
        '
        'Label20
        '
        Me.Label20.BackColor = System.Drawing.Color.LightSteelBlue
        Me.Label20.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label20.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label20.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label20.Location = New System.Drawing.Point(0, 0)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(585, 27)
        Me.Label20.TabIndex = 4
        Me.Label20.Tag = ""
        Me.Label20.Text = "DETALLES DE PEDIDOS"
        Me.Label20.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblNPedidos
        '
        Me.lblNPedidos.BackColor = System.Drawing.Color.LightSteelBlue
        Me.lblNPedidos.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNPedidos.Location = New System.Drawing.Point(228, 3)
        Me.lblNPedidos.Name = "lblNPedidos"
        Me.lblNPedidos.Size = New System.Drawing.Size(72, 12)
        Me.lblNPedidos.TabIndex = 49
        Me.lblNPedidos.Text = "Label10"
        Me.lblNPedidos.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'groupPedido
        '
        Me.groupPedido.BackColor = System.Drawing.Color.LightSteelBlue
        Me.groupPedido.Controls.Add(Label7)
        Me.groupPedido.Controls.Add(Me.dtPedidoFh)
        Me.groupPedido.Controls.Add(Label5)
        Me.groupPedido.Controls.Add(Me.txtPedido_n)
        Me.groupPedido.Enabled = False
        Me.groupPedido.Location = New System.Drawing.Point(6, 64)
        Me.groupPedido.Name = "groupPedido"
        Me.groupPedido.Size = New System.Drawing.Size(298, 104)
        Me.groupPedido.TabIndex = 48
        Me.groupPedido.TabStop = False
        Me.groupPedido.Text = "Detalles del pedido"
        '
        'dtPedidoFh
        '
        Me.dtPedidoFh.CalendarFont = New System.Drawing.Font("Tahoma", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtPedidoFh.CustomFormat = "dd-MMMM-yyyy"
        Me.dtPedidoFh.Font = New System.Drawing.Font("Tahoma", 15.75!)
        Me.dtPedidoFh.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtPedidoFh.Location = New System.Drawing.Point(106, 61)
        Me.dtPedidoFh.Name = "dtPedidoFh"
        Me.dtPedidoFh.Size = New System.Drawing.Size(178, 33)
        Me.dtPedidoFh.TabIndex = 51
        Me.dtPedidoFh.Tag = "fh_reserva"
        '
        'txtPedido_n
        '
        Me.txtPedido_n.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtPedido_n.Font = New System.Drawing.Font("Tahoma", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPedido_n.Location = New System.Drawing.Point(106, 19)
        Me.txtPedido_n.MaxLength = 35
        Me.txtPedido_n.Name = "txtPedido_n"
        Me.txtPedido_n.Size = New System.Drawing.Size(125, 36)
        Me.txtPedido_n.TabIndex = 3
        Me.txtPedido_n.Tag = "codigo"
        '
        'gridPedidos
        '
        Me.gridPedidos.AllowUserToAddRows = False
        Me.gridPedidos.AllowUserToDeleteRows = False
        Me.gridPedidos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.gridPedidos.Dock = System.Windows.Forms.DockStyle.Fill
        Me.gridPedidos.Location = New System.Drawing.Point(0, 205)
        Me.gridPedidos.Name = "gridPedidos"
        Me.gridPedidos.ReadOnly = True
        Me.gridPedidos.RowHeadersWidth = 15
        Me.gridPedidos.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        Me.gridPedidos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.gridPedidos.Size = New System.Drawing.Size(307, 363)
        Me.gridPedidos.TabIndex = 6
        Me.gridPedidos.Tag = ""
        '
        'btPrint
        '
        Me.btPrint.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btPrint.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btPrint.Image = CType(resources.GetObject("btPrint.Image"), System.Drawing.Image)
        Me.btPrint.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btPrint.Location = New System.Drawing.Point(156, 18)
        Me.btPrint.Name = "btPrint"
        Me.btPrint.Size = New System.Drawing.Size(43, 40)
        Me.btPrint.TabIndex = 16
        Me.btPrint.Tag = "edit"
        Me.btPrint.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btPrint.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.Color.LightSteelBlue
        Me.Label4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label4.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label4.Font = New System.Drawing.Font("Verdana", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Image = CType(resources.GetObject("Label4.Image"), System.Drawing.Image)
        Me.Label4.ImageAlign = System.Drawing.ContentAlignment.TopLeft
        Me.Label4.Location = New System.Drawing.Point(0, 176)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(307, 29)
        Me.Label4.TabIndex = 47
        Me.Label4.Text = "HISTORICO DE PEDIDOS"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'btSave
        '
        Me.btSave.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btSave.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btSave.Image = CType(resources.GetObject("btSave.Image"), System.Drawing.Image)
        Me.btSave.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btSave.Location = New System.Drawing.Point(210, 18)
        Me.btSave.Name = "btSave"
        Me.btSave.Size = New System.Drawing.Size(43, 40)
        Me.btSave.TabIndex = 15
        Me.btSave.Tag = "edit"
        Me.btSave.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btSave.UseVisualStyleBackColor = True
        '
        'btCancell
        '
        Me.btCancell.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btCancell.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btCancell.Image = CType(resources.GetObject("btCancell.Image"), System.Drawing.Image)
        Me.btCancell.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btCancell.Location = New System.Drawing.Point(259, 18)
        Me.btCancell.Name = "btCancell"
        Me.btCancell.Size = New System.Drawing.Size(43, 40)
        Me.btCancell.TabIndex = 14
        Me.btCancell.Tag = "del"
        Me.btCancell.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btCancell.UseVisualStyleBackColor = True
        '
        'BtEdit
        '
        Me.BtEdit.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.BtEdit.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtEdit.Image = CType(resources.GetObject("BtEdit.Image"), System.Drawing.Image)
        Me.BtEdit.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.BtEdit.Location = New System.Drawing.Point(52, 18)
        Me.BtEdit.Name = "BtEdit"
        Me.BtEdit.Size = New System.Drawing.Size(43, 40)
        Me.BtEdit.TabIndex = 13
        Me.BtEdit.Tag = "edit"
        Me.BtEdit.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.BtEdit.UseVisualStyleBackColor = True
        '
        'BtNew
        '
        Me.BtNew.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.BtNew.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtNew.Image = CType(resources.GetObject("BtNew.Image"), System.Drawing.Image)
        Me.BtNew.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.BtNew.Location = New System.Drawing.Point(5, 18)
        Me.BtNew.Name = "BtNew"
        Me.BtNew.Size = New System.Drawing.Size(43, 40)
        Me.BtNew.TabIndex = 12
        Me.BtNew.Tag = "new"
        Me.BtNew.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.BtNew.UseVisualStyleBackColor = True
        '
        'BtDel
        '
        Me.BtDel.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.BtDel.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtDel.Image = CType(resources.GetObject("BtDel.Image"), System.Drawing.Image)
        Me.BtDel.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.BtDel.Location = New System.Drawing.Point(101, 18)
        Me.BtDel.Name = "BtDel"
        Me.BtDel.Size = New System.Drawing.Size(43, 40)
        Me.BtDel.TabIndex = 11
        Me.BtDel.Tag = "del"
        Me.BtDel.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.BtDel.UseVisualStyleBackColor = True
        '
        'Label21
        '
        Me.Label21.BackColor = System.Drawing.Color.LightSteelBlue
        Me.Label21.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label21.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label21.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label21.Location = New System.Drawing.Point(0, 0)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(307, 176)
        Me.Label21.TabIndex = 5
        Me.Label21.Tag = ""
        Me.Label21.Text = "PEDIDOS"
        '
        'TabPage_Update
        '
        Me.TabPage_Update.Controls.Add(Me.splitImporta)
        Me.TabPage_Update.Controls.Add(Me.Label3)
        Me.TabPage_Update.Location = New System.Drawing.Point(4, 22)
        Me.TabPage_Update.Name = "TabPage_Update"
        Me.TabPage_Update.Size = New System.Drawing.Size(900, 574)
        Me.TabPage_Update.TabIndex = 2
        Me.TabPage_Update.Text = "Actualizar precios"
        Me.TabPage_Update.UseVisualStyleBackColor = True
        '
        'splitImporta
        '
        Me.splitImporta.Dock = System.Windows.Forms.DockStyle.Fill
        Me.splitImporta.FixedPanel = System.Windows.Forms.FixedPanel.Panel1
        Me.splitImporta.Location = New System.Drawing.Point(0, 29)
        Me.splitImporta.Name = "splitImporta"
        Me.splitImporta.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'splitImporta.Panel1
        '
        Me.splitImporta.Panel1.Controls.Add(Me.Label10)
        Me.splitImporta.Panel1.Controls.Add(Me.lnkCMTPrecios)
        Me.splitImporta.Panel1.Controls.Add(Me.btUpdate)
        Me.splitImporta.Panel1.Controls.Add(Me.chkTodos)
        Me.splitImporta.Panel1.Controls.Add(Me.btImporta_www)
        Me.splitImporta.Panel1.Controls.Add(Me.btImport_procesa)
        Me.splitImporta.Panel1.Controls.Add(Me.Label49)
        Me.splitImporta.Panel1.Controls.Add(Me.Label51)
        Me.splitImporta.Panel1.Controls.Add(Me.pbImporta)
        Me.splitImporta.Panel1.Controls.Add(Me.lblImpora_N)
        Me.splitImporta.Panel1.Controls.Add(Me.Label50)
        Me.splitImporta.Panel1.Controls.Add(Me.Label47)
        Me.splitImporta.Panel1.Controls.Add(Me.lblImpora_Periodo)
        Me.splitImporta.Panel1.Controls.Add(Me.lblImporta_file)
        Me.splitImporta.Panel1.Controls.Add(Me.lnkImporta_del)
        Me.splitImporta.Panel1.Controls.Add(Me.lnkImporta_Sel)
        Me.splitImporta.Panel1.Controls.Add(Label46)
        '
        'splitImporta.Panel2
        '
        Me.splitImporta.Panel2.Controls.Add(Me.Panel1)
        Me.splitImporta.Size = New System.Drawing.Size(900, 545)
        Me.splitImporta.SplitterDistance = 154
        Me.splitImporta.TabIndex = 66
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(21, 115)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(158, 13)
        Me.Label10.TabIndex = 73
        Me.Label10.Text = "OBTENCIÓN DE PRECIOS"
        '
        'lnkCMTPrecios
        '
        Me.lnkCMTPrecios.AutoSize = True
        Me.lnkCMTPrecios.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lnkCMTPrecios.Location = New System.Drawing.Point(31, 131)
        Me.lnkCMTPrecios.Name = "lnkCMTPrecios"
        Me.lnkCMTPrecios.Size = New System.Drawing.Size(402, 13)
        Me.lnkCMTPrecios.TabIndex = 72
        Me.lnkCMTPrecios.TabStop = True
        Me.lnkCMTPrecios.Text = "http://www.cmtabacos.es/wwwcmt/paginas/ES/mercadoPrecios.tmpl"
        '
        'btUpdate
        '
        Me.btUpdate.BackColor = System.Drawing.SystemColors.Control
        Me.btUpdate.Enabled = False
        Me.btUpdate.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btUpdate.Image = CType(resources.GetObject("btUpdate.Image"), System.Drawing.Image)
        Me.btUpdate.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btUpdate.Location = New System.Drawing.Point(751, 14)
        Me.btUpdate.Name = "btUpdate"
        Me.btUpdate.Size = New System.Drawing.Size(139, 47)
        Me.btUpdate.TabIndex = 68
        Me.btUpdate.Tag = ""
        Me.btUpdate.Text = "Actualizar precios"
        Me.btUpdate.TextAlign = System.Drawing.ContentAlignment.TopRight
        Me.btUpdate.UseVisualStyleBackColor = False
        '
        'chkTodos
        '
        Me.chkTodos.AutoSize = True
        Me.chkTodos.BackColor = System.Drawing.Color.Transparent
        Me.chkTodos.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkTodos.Location = New System.Drawing.Point(739, 116)
        Me.chkTodos.Name = "chkTodos"
        Me.chkTodos.Size = New System.Drawing.Size(142, 28)
        Me.chkTodos.TabIndex = 67
        Me.chkTodos.Tag = ""
        Me.chkTodos.Text = "Mostrar todos"
        Me.chkTodos.UseVisualStyleBackColor = False
        '
        'btImporta_www
        '
        Me.btImporta_www.BackColor = System.Drawing.SystemColors.Control
        Me.btImporta_www.Font = New System.Drawing.Font("Tahoma", 11.25!)
        Me.btImporta_www.Image = CType(resources.GetObject("btImporta_www.Image"), System.Drawing.Image)
        Me.btImporta_www.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btImporta_www.Location = New System.Drawing.Point(751, 67)
        Me.btImporta_www.Name = "btImporta_www"
        Me.btImporta_www.Size = New System.Drawing.Size(139, 47)
        Me.btImporta_www.TabIndex = 66
        Me.btImporta_www.Tag = ""
        Me.btImporta_www.Text = "Importa www"
        Me.btImporta_www.TextAlign = System.Drawing.ContentAlignment.TopRight
        Me.btImporta_www.UseVisualStyleBackColor = False
        '
        'btImport_procesa
        '
        Me.btImport_procesa.BackColor = System.Drawing.SystemColors.Control
        Me.btImport_procesa.Enabled = False
        Me.btImport_procesa.Font = New System.Drawing.Font("Tahoma", 11.25!)
        Me.btImport_procesa.Image = CType(resources.GetObject("btImport_procesa.Image"), System.Drawing.Image)
        Me.btImport_procesa.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btImport_procesa.Location = New System.Drawing.Point(639, 14)
        Me.btImport_procesa.Name = "btImport_procesa"
        Me.btImport_procesa.Size = New System.Drawing.Size(106, 47)
        Me.btImport_procesa.TabIndex = 65
        Me.btImport_procesa.Tag = ""
        Me.btImport_procesa.Text = "Procesar Fichero"
        Me.btImport_procesa.TextAlign = System.Drawing.ContentAlignment.TopRight
        Me.btImport_procesa.UseVisualStyleBackColor = False
        '
        'Label49
        '
        Me.Label49.Image = CType(resources.GetObject("Label49.Image"), System.Drawing.Image)
        Me.Label49.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Label49.Location = New System.Drawing.Point(596, 116)
        Me.Label49.Name = "Label49"
        Me.Label49.Size = New System.Drawing.Size(137, 20)
        Me.Label49.TabIndex = 52
        Me.Label49.Text = "       Precio mantenido"
        Me.Label49.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label51
        '
        Me.Label51.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.Label51.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label51.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label51.Location = New System.Drawing.Point(12, 69)
        Me.Label51.Name = "Label51"
        Me.Label51.Size = New System.Drawing.Size(61, 18)
        Me.Label51.TabIndex = 64
        Me.Label51.Text = "#"
        Me.Label51.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'pbImporta
        '
        Me.pbImporta.Location = New System.Drawing.Point(248, 69)
        Me.pbImporta.Name = "pbImporta"
        Me.pbImporta.Size = New System.Drawing.Size(358, 32)
        Me.pbImporta.TabIndex = 50
        Me.pbImporta.Visible = False
        '
        'lblImpora_N
        '
        Me.lblImpora_N.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblImpora_N.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblImpora_N.Location = New System.Drawing.Point(12, 88)
        Me.lblImpora_N.Name = "lblImpora_N"
        Me.lblImpora_N.Size = New System.Drawing.Size(61, 20)
        Me.lblImpora_N.TabIndex = 63
        Me.lblImpora_N.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Label50
        '
        Me.Label50.Image = CType(resources.GetObject("Label50.Image"), System.Drawing.Image)
        Me.Label50.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Label50.Location = New System.Drawing.Point(451, 116)
        Me.Label50.Name = "Label50"
        Me.Label50.Size = New System.Drawing.Size(170, 20)
        Me.Label50.TabIndex = 51
        Me.Label50.Text = "       Actualización de precio"
        Me.Label50.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label47
        '
        Me.Label47.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.Label47.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label47.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label47.Location = New System.Drawing.Point(79, 69)
        Me.Label47.Name = "Label47"
        Me.Label47.Size = New System.Drawing.Size(157, 18)
        Me.Label47.TabIndex = 62
        Me.Label47.Text = "Fecha de Actualización"
        Me.Label47.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblImpora_Periodo
        '
        Me.lblImpora_Periodo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblImpora_Periodo.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblImpora_Periodo.Location = New System.Drawing.Point(79, 88)
        Me.lblImpora_Periodo.Name = "lblImpora_Periodo"
        Me.lblImpora_Periodo.Size = New System.Drawing.Size(157, 20)
        Me.lblImpora_Periodo.TabIndex = 61
        Me.lblImpora_Periodo.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblImporta_file
        '
        Me.lblImporta_file.BackColor = System.Drawing.Color.CadetBlue
        Me.lblImporta_file.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblImporta_file.Font = New System.Drawing.Font("Tahoma", 9.75!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblImporta_file.Location = New System.Drawing.Point(12, 36)
        Me.lblImporta_file.Name = "lblImporta_file"
        Me.lblImporta_file.Size = New System.Drawing.Size(621, 25)
        Me.lblImporta_file.TabIndex = 58
        Me.lblImporta_file.Tag = "mysqldump"
        Me.lblImporta_file.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lnkImporta_del
        '
        Me.lnkImporta_del.AutoSize = True
        Me.lnkImporta_del.BackColor = System.Drawing.Color.SlateGray
        Me.lnkImporta_del.Enabled = False
        Me.lnkImporta_del.Location = New System.Drawing.Point(581, 18)
        Me.lnkImporta_del.Name = "lnkImporta_del"
        Me.lnkImporta_del.Size = New System.Drawing.Size(43, 13)
        Me.lnkImporta_del.TabIndex = 60
        Me.lnkImporta_del.TabStop = True
        Me.lnkImporta_del.Tag = "ENABLED"
        Me.lnkImporta_del.Text = "Eliminar"
        '
        'lnkImporta_Sel
        '
        Me.lnkImporta_Sel.AutoSize = True
        Me.lnkImporta_Sel.BackColor = System.Drawing.Color.SlateGray
        Me.lnkImporta_Sel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lnkImporta_Sel.Location = New System.Drawing.Point(505, 18)
        Me.lnkImporta_Sel.Name = "lnkImporta_Sel"
        Me.lnkImporta_Sel.Size = New System.Drawing.Size(74, 13)
        Me.lnkImporta_Sel.TabIndex = 59
        Me.lnkImporta_Sel.TabStop = True
        Me.lnkImporta_Sel.Tag = "ENABLED"
        Me.lnkImporta_Sel.Text = "Seleccionar"
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.lstImportaPrecios)
        Me.Panel1.Controls.Add(Label48)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Padding = New System.Windows.Forms.Padding(3)
        Me.Panel1.Size = New System.Drawing.Size(900, 387)
        Me.Panel1.TabIndex = 54
        '
        'lstImportaPrecios
        '
        Me.lstImportaPrecios.BackColor = System.Drawing.Color.Beige
        Me.lstImportaPrecios.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lstImportaPrecios.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lstImportaPrecios.FullRowSelect = True
        Me.lstImportaPrecios.HideSelection = False
        Me.lstImportaPrecios.Location = New System.Drawing.Point(3, 21)
        Me.lstImportaPrecios.Name = "lstImportaPrecios"
        Me.lstImportaPrecios.Size = New System.Drawing.Size(894, 363)
        Me.lstImportaPrecios.TabIndex = 11
        Me.lstImportaPrecios.UseCompatibleStateImageBehavior = False
        Me.lstImportaPrecios.View = System.Windows.Forms.View.Details
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.Color.LightSteelBlue
        Me.Label3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label3.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label3.Font = New System.Drawing.Font("Verdana", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Image = CType(resources.GetObject("Label3.Image"), System.Drawing.Image)
        Me.Label3.ImageAlign = System.Drawing.ContentAlignment.TopLeft
        Me.Label3.Location = New System.Drawing.Point(0, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(900, 29)
        Me.Label3.TabIndex = 46
        Me.Label3.Text = "ACTUALIZAR PRECIOS"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'TmHour
        '
        Me.TmHour.Interval = 30000
        '
        'TmrCodBarras
        '
        Me.TmrCodBarras.Interval = 3000
        '
        'frmEstanco
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoScroll = True
        Me.BackColor = System.Drawing.Color.Black
        Me.ClientSize = New System.Drawing.Size(1020, 770)
        Me.Controls.Add(Me.SplitContainer)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.KeyPreview = True
        Me.Name = "frmEstanco"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.SplitContainer.Panel1.ResumeLayout(False)
        Me.SplitContainer.Panel1.PerformLayout()
        Me.SplitContainer.Panel2.ResumeLayout(False)
        Me.SplitContainer.ResumeLayout(False)
        CType(Me.m_logo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PnlButton_Shell.ResumeLayout(False)
        Me.PnlBody.ResumeLayout(False)
        Me.PnlData.ResumeLayout(False)
        Me.Tab.ResumeLayout(False)
        Me.TabPage_Marcas.ResumeLayout(False)
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        Me.SplitContainer1.Panel2.PerformLayout()
        Me.SplitContainer1.ResumeLayout(False)
        CType(Me.gridMarcas, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PnlFilter.ResumeLayout(False)
        Me.PnlHistory.ResumeLayout(False)
        Me.GroupHistory.ResumeLayout(False)
        Me.GroupHistory.PerformLayout()
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        Me.TabPage_pedidos.ResumeLayout(False)
        Me.SplitHistory.Panel1.ResumeLayout(False)
        Me.SplitHistory.Panel2.ResumeLayout(False)
        Me.SplitHistory.ResumeLayout(False)
        CType(Me.gridLineas, System.ComponentModel.ISupportInitialize).EndInit()
        Me.groupPedido.ResumeLayout(False)
        Me.groupPedido.PerformLayout()
        CType(Me.gridPedidos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage_Update.ResumeLayout(False)
        Me.splitImporta.Panel1.ResumeLayout(False)
        Me.splitImporta.Panel1.PerformLayout()
        Me.splitImporta.Panel2.ResumeLayout(False)
        Me.splitImporta.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents SplitContainer As System.Windows.Forms.SplitContainer
    Friend WithEvents m_logo As System.Windows.Forms.PictureBox
    Friend WithEvents PnlButton_Shell As System.Windows.Forms.Panel
    Friend WithEvents BtClose As System.Windows.Forms.Button
    Friend WithEvents LblSubTitle As System.Windows.Forms.Label
    Friend WithEvents LblTitle As System.Windows.Forms.Label
    Friend WithEvents PnlBody As System.Windows.Forms.Panel
    Friend WithEvents PnlData As System.Windows.Forms.Panel
    Friend WithEvents ToolTip As System.Windows.Forms.ToolTip
    Friend WithEvents BtUpdatePVP As System.Windows.Forms.Button
    Friend WithEvents LblHour As System.Windows.Forms.Label
    Friend WithEvents TmHour As System.Windows.Forms.Timer
    Friend WithEvents PnlHistory As System.Windows.Forms.Panel
    Friend WithEvents GroupHistory As System.Windows.Forms.GroupBox
    Friend WithEvents BtHistory_Edit As System.Windows.Forms.Button
    Friend WithEvents BtHistory_Print As System.Windows.Forms.Button
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents LblHistory_Mesa As System.Windows.Forms.Label
    Friend WithEvents LblHistory_Total As System.Windows.Forms.Label
    Friend WithEvents BtHistory_Next As System.Windows.Forms.Button
    Friend WithEvents BtHistory_Previous As System.Windows.Forms.Button
    Friend WithEvents LblHistory_Fh As System.Windows.Forms.Label
    Friend WithEvents LblHistory_Empleado As System.Windows.Forms.Label
    Friend WithEvents Tab As System.Windows.Forms.TabControl
    Friend WithEvents TabPage_Marcas As System.Windows.Forms.TabPage
    Friend WithEvents TabPage_pedidos As System.Windows.Forms.TabPage
    Friend WithEvents lblHistory_ID As System.Windows.Forms.Label
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents LblDaySelect As System.Windows.Forms.Label
    Friend WithEvents btPedido_Print As System.Windows.Forms.Button
    Friend WithEvents btMarca_Add As System.Windows.Forms.Button
    Friend WithEvents btMarca_del As System.Windows.Forms.Button
    Friend WithEvents btPedido_Cancela As System.Windows.Forms.Button
    Friend WithEvents btPedido_Comanda As System.Windows.Forms.Button
    Friend WithEvents SplitHistory As System.Windows.Forms.SplitContainer
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents gridPedidos As System.Windows.Forms.DataGridView
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents btAll As System.Windows.Forms.Button
    Friend WithEvents btPedido_Finalizar As System.Windows.Forms.Button
    Friend WithEvents btMarca_edit As System.Windows.Forms.Button
    Friend WithEvents gridMarcas As System.Windows.Forms.DataGridView
    Friend WithEvents btImportar As System.Windows.Forms.Button
    Friend WithEvents PnlFilter As System.Windows.Forms.Panel
    Friend WithEvents Rbt_Filter_Z As System.Windows.Forms.RadioButton
    Friend WithEvents Rbt_Filter_Y As System.Windows.Forms.RadioButton
    Friend WithEvents Rbt_Filter_X As System.Windows.Forms.RadioButton
    Friend WithEvents Rbt_Filter_W As System.Windows.Forms.RadioButton
    Friend WithEvents V As System.Windows.Forms.RadioButton
    Friend WithEvents Rbt_Filter_U As System.Windows.Forms.RadioButton
    Friend WithEvents Rbt_Filter_T As System.Windows.Forms.RadioButton
    Friend WithEvents Rbt_Filter_S As System.Windows.Forms.RadioButton
    Friend WithEvents Rbt_Filter_R As System.Windows.Forms.RadioButton
    Friend WithEvents Rbt_Filter_Q As System.Windows.Forms.RadioButton
    Friend WithEvents Rbt_Filter_P As System.Windows.Forms.RadioButton
    Friend WithEvents Rbt_Filter_O As System.Windows.Forms.RadioButton
    Friend WithEvents Rbt_Filter_Ñ As System.Windows.Forms.RadioButton
    Friend WithEvents Rbt_Filter_N As System.Windows.Forms.RadioButton
    Friend WithEvents Rbt_Filter_M As System.Windows.Forms.RadioButton
    Friend WithEvents Rbt_Filter_L As System.Windows.Forms.RadioButton
    Friend WithEvents Rbt_Filter_K As System.Windows.Forms.RadioButton
    Friend WithEvents Rbt_Filter_J As System.Windows.Forms.RadioButton
    Friend WithEvents Rbt_Filter_I As System.Windows.Forms.RadioButton
    Friend WithEvents Rbt_Filter_H As System.Windows.Forms.RadioButton
    Friend WithEvents Rbt_Filter_G As System.Windows.Forms.RadioButton
    Friend WithEvents Rbt_Filter_F As System.Windows.Forms.RadioButton
    Friend WithEvents Rbt_Filter_E As System.Windows.Forms.RadioButton
    Friend WithEvents Rbt_Filter_D As System.Windows.Forms.RadioButton
    Friend WithEvents Rbt_Filter_C As System.Windows.Forms.RadioButton
    Friend WithEvents Rbt_Filter_B As System.Windows.Forms.RadioButton
    Friend WithEvents Rbt_Filter_A As System.Windows.Forms.RadioButton
    Friend WithEvents Rbt_Filter_All As System.Windows.Forms.RadioButton
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents TxtFind As System.Windows.Forms.TextBox
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents dtFhUpdate As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents lblInfo As System.Windows.Forms.Label
    Friend WithEvents lblTotProductos As System.Windows.Forms.Label
    Friend WithEvents TmrCodBarras As System.Windows.Forms.Timer
    Friend WithEvents chkActivo As System.Windows.Forms.CheckBox
    Friend WithEvents CheckBox1 As System.Windows.Forms.CheckBox
    Friend WithEvents TabPage_Update As System.Windows.Forms.TabPage
    Friend WithEvents splitImporta As System.Windows.Forms.SplitContainer
    Friend WithEvents btImport_procesa As System.Windows.Forms.Button
    Friend WithEvents Label49 As System.Windows.Forms.Label
    Friend WithEvents Label51 As System.Windows.Forms.Label
    Friend WithEvents pbImporta As System.Windows.Forms.ProgressBar
    Friend WithEvents lblImpora_N As System.Windows.Forms.Label
    Friend WithEvents Label50 As System.Windows.Forms.Label
    Friend WithEvents Label47 As System.Windows.Forms.Label
    Friend WithEvents lblImpora_Periodo As System.Windows.Forms.Label
    Friend WithEvents lblImporta_file As System.Windows.Forms.Label
    Friend WithEvents lnkImporta_del As System.Windows.Forms.LinkLabel
    Friend WithEvents lnkImporta_Sel As System.Windows.Forms.LinkLabel
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents lstImportaPrecios As System.Windows.Forms.ListView
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents btImporta_www As System.Windows.Forms.Button
    Friend WithEvents chkTodos As System.Windows.Forms.CheckBox
    Friend WithEvents btUpdate As System.Windows.Forms.Button
    Friend WithEvents BtNew As System.Windows.Forms.Button
    Friend WithEvents BtDel As System.Windows.Forms.Button
    Friend WithEvents btPrint As System.Windows.Forms.Button
    Friend WithEvents btSave As System.Windows.Forms.Button
    Friend WithEvents btCancell As System.Windows.Forms.Button
    Friend WithEvents BtEdit As System.Windows.Forms.Button
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents groupPedido As System.Windows.Forms.GroupBox
    Friend WithEvents txtPedido_n As System.Windows.Forms.TextBox
    Friend WithEvents dtPedidoFh As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblNPedidos As System.Windows.Forms.Label
    Friend WithEvents gridLineas As System.Windows.Forms.DataGridView
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents lnkCMTPrecios As System.Windows.Forms.LinkLabel
    Friend WithEvents sw As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents id As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents grid_txtCodBarras As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents grid_txtRef As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents grid_txtCodigo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents grid_lblName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents grid_txtUd As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
