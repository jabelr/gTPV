<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmFacturacion
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmFacturacion))
        Me.SplitContainer = New System.Windows.Forms.SplitContainer()
        Me.m_logo = New System.Windows.Forms.PictureBox()
        Me.PnlButton_Shell = New System.Windows.Forms.Panel()
        Me.BtClose = New System.Windows.Forms.Button()
        Me.BtMin = New System.Windows.Forms.Button()
        Me.LblSubTitle = New System.Windows.Forms.Label()
        Me.LblTitle = New System.Windows.Forms.Label()
        Me.PnlBody = New System.Windows.Forms.Panel()
        Me.LblMonth = New System.Windows.Forms.Label()
        Me.PnlData = New System.Windows.Forms.Panel()
        Me.Tab = New System.Windows.Forms.TabControl()
        Me.TabPage_FacturasVenta = New System.Windows.Forms.TabPage()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.BtTicket = New System.Windows.Forms.Button()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.LblInfoVentas = New System.Windows.Forms.Label()
        Me.BtPreview_FacturaVenta = New System.Windows.Forms.Button()
        Me.BtDel_FacturaVenta = New System.Windows.Forms.Button()
        Me.LblDaySelect = New System.Windows.Forms.Label()
        Me.GridVentas = New System.Windows.Forms.DataGridView()
        Me.TabPage_AlbaranesCompra = New System.Windows.Forms.TabPage()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.BtEdit = New System.Windows.Forms.Button()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.LblInfoCompras = New System.Windows.Forms.Label()
        Me.BtAdd = New System.Windows.Forms.Button()
        Me.BtDel = New System.Windows.Forms.Button()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.GridAlbaranes = New System.Windows.Forms.DataGridView()
        Me.TabPage_FacturasCompra = New System.Windows.Forms.TabPage()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.BtDesfacturar = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.GridCompras = New System.Windows.Forms.DataGridView()
        Me.ImageList = New System.Windows.Forms.ImageList(Me.components)
        Me.ToolTip = New System.Windows.Forms.ToolTip(Me.components)
        Me.ImageList_day = New System.Windows.Forms.ImageList(Me.components)
        Me.btEditFactura = New System.Windows.Forms.Button()
        Me.SplitContainer.Panel1.SuspendLayout()
        Me.SplitContainer.Panel2.SuspendLayout()
        Me.SplitContainer.SuspendLayout()
        CType(Me.m_logo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PnlButton_Shell.SuspendLayout()
        Me.PnlBody.SuspendLayout()
        Me.PnlData.SuspendLayout()
        Me.Tab.SuspendLayout()
        Me.TabPage_FacturasVenta.SuspendLayout()
        Me.Panel1.SuspendLayout()
        CType(Me.GridVentas, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage_AlbaranesCompra.SuspendLayout()
        Me.Panel3.SuspendLayout()
        CType(Me.GridAlbaranes, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage_FacturasCompra.SuspendLayout()
        Me.Panel2.SuspendLayout()
        CType(Me.GridCompras, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
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
        Me.PnlButton_Shell.Controls.Add(Me.BtClose)
        Me.PnlButton_Shell.Controls.Add(Me.BtMin)
        Me.PnlButton_Shell.Dock = System.Windows.Forms.DockStyle.Right
        Me.PnlButton_Shell.Location = New System.Drawing.Point(470, 0)
        Me.PnlButton_Shell.Name = "PnlButton_Shell"
        Me.PnlButton_Shell.Size = New System.Drawing.Size(550, 64)
        Me.PnlButton_Shell.TabIndex = 2
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
        'BtMin
        '
        Me.BtMin.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.BtMin.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtMin.Image = CType(resources.GetObject("BtMin.Image"), System.Drawing.Image)
        Me.BtMin.Location = New System.Drawing.Point(6, 4)
        Me.BtMin.Name = "BtMin"
        Me.BtMin.Size = New System.Drawing.Size(170, 58)
        Me.BtMin.TabIndex = 6
        Me.BtMin.Tag = "minimize"
        Me.BtMin.Text = "Minimizar"
        Me.BtMin.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.BtMin.UseVisualStyleBackColor = True
        Me.BtMin.Visible = False
        '
        'LblSubTitle
        '
        Me.LblSubTitle.ForeColor = System.Drawing.SystemColors.InactiveCaption
        Me.LblSubTitle.Location = New System.Drawing.Point(64, 30)
        Me.LblSubTitle.Name = "LblSubTitle"
        Me.LblSubTitle.Size = New System.Drawing.Size(321, 31)
        Me.LblSubTitle.TabIndex = 1
        Me.LblSubTitle.Text = "Información y Administración sobre las facturas emitidas a Clientes y remitidas h" & _
            "acia el Local."
        '
        'LblTitle
        '
        Me.LblTitle.AutoSize = True
        Me.LblTitle.Font = New System.Drawing.Font("Tahoma", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblTitle.Location = New System.Drawing.Point(57, 4)
        Me.LblTitle.Name = "LblTitle"
        Me.LblTitle.Size = New System.Drawing.Size(208, 23)
        Me.LblTitle.TabIndex = 0
        Me.LblTitle.Text = "Panel de Facturación"
        '
        'PnlBody
        '
        Me.PnlBody.BackColor = System.Drawing.SystemColors.Control
        Me.PnlBody.BackgroundImage = CType(resources.GetObject("PnlBody.BackgroundImage"), System.Drawing.Image)
        Me.PnlBody.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PnlBody.Controls.Add(Me.LblMonth)
        Me.PnlBody.Controls.Add(Me.PnlData)
        Me.PnlBody.ForeColor = System.Drawing.Color.Black
        Me.PnlBody.Location = New System.Drawing.Point(12, 14)
        Me.PnlBody.Name = "PnlBody"
        Me.PnlBody.Size = New System.Drawing.Size(982, 669)
        Me.PnlBody.TabIndex = 0
        Me.PnlBody.Visible = False
        '
        'LblMonth
        '
        Me.LblMonth.AutoSize = True
        Me.LblMonth.BackColor = System.Drawing.Color.FromArgb(CType(CType(174, Byte), Integer), CType(CType(186, Byte), Integer), CType(CType(186, Byte), Integer))
        Me.LblMonth.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblMonth.Location = New System.Drawing.Point(59, 43)
        Me.LblMonth.Name = "LblMonth"
        Me.LblMonth.Size = New System.Drawing.Size(422, 31)
        Me.LblMonth.TabIndex = 39
        Me.LblMonth.Text = "Panel de Facturación y Gestión"
        '
        'PnlData
        '
        Me.PnlData.BackColor = System.Drawing.Color.FromArgb(CType(CType(174, Byte), Integer), CType(CType(186, Byte), Integer), CType(CType(186, Byte), Integer))
        Me.PnlData.Controls.Add(Me.Tab)
        Me.PnlData.Location = New System.Drawing.Point(37, 90)
        Me.PnlData.Name = "PnlData"
        Me.PnlData.Size = New System.Drawing.Size(908, 530)
        Me.PnlData.TabIndex = 38
        '
        'Tab
        '
        Me.Tab.Controls.Add(Me.TabPage_FacturasVenta)
        Me.Tab.Controls.Add(Me.TabPage_AlbaranesCompra)
        Me.Tab.Controls.Add(Me.TabPage_FacturasCompra)
        Me.Tab.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Tab.ImageList = Me.ImageList
        Me.Tab.Location = New System.Drawing.Point(0, 0)
        Me.Tab.Name = "Tab"
        Me.Tab.SelectedIndex = 0
        Me.Tab.Size = New System.Drawing.Size(908, 530)
        Me.Tab.TabIndex = 11
        '
        'TabPage_FacturasVenta
        '
        Me.TabPage_FacturasVenta.Controls.Add(Me.Panel1)
        Me.TabPage_FacturasVenta.Controls.Add(Me.GridVentas)
        Me.TabPage_FacturasVenta.ImageIndex = 0
        Me.TabPage_FacturasVenta.Location = New System.Drawing.Point(4, 23)
        Me.TabPage_FacturasVenta.Name = "TabPage_FacturasVenta"
        Me.TabPage_FacturasVenta.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage_FacturasVenta.Size = New System.Drawing.Size(900, 503)
        Me.TabPage_FacturasVenta.TabIndex = 0
        Me.TabPage_FacturasVenta.Text = "Facturas de Venta"
        Me.TabPage_FacturasVenta.UseVisualStyleBackColor = True
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.Transparent
        Me.Panel1.Controls.Add(Me.btEditFactura)
        Me.Panel1.Controls.Add(Me.BtTicket)
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Controls.Add(Me.LblInfoVentas)
        Me.Panel1.Controls.Add(Me.BtPreview_FacturaVenta)
        Me.Panel1.Controls.Add(Me.BtDel_FacturaVenta)
        Me.Panel1.Controls.Add(Me.LblDaySelect)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Right
        Me.Panel1.Location = New System.Drawing.Point(703, 3)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(194, 497)
        Me.Panel1.TabIndex = 11
        '
        'BtTicket
        '
        Me.BtTicket.BackColor = System.Drawing.SystemColors.Control
        Me.BtTicket.Enabled = False
        Me.BtTicket.Font = New System.Drawing.Font("Tahoma", 11.25!)
        Me.BtTicket.Image = CType(resources.GetObject("BtTicket.Image"), System.Drawing.Image)
        Me.BtTicket.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtTicket.Location = New System.Drawing.Point(3, 100)
        Me.BtTicket.Name = "BtTicket"
        Me.BtTicket.Size = New System.Drawing.Size(188, 56)
        Me.BtTicket.TabIndex = 50
        Me.BtTicket.Tag = "PRINTTICKET"
        Me.BtTicket.Text = "Modo Ticket"
        Me.BtTicket.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BtTicket.UseVisualStyleBackColor = False
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.Color.LightSteelBlue
        Me.Label3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label3.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Label3.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Image = CType(resources.GetObject("Label3.Image"), System.Drawing.Image)
        Me.Label3.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Label3.Location = New System.Drawing.Point(0, 410)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(194, 21)
        Me.Label3.TabIndex = 49
        Me.Label3.Text = "Detalles"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'LblInfoVentas
        '
        Me.LblInfoVentas.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LblInfoVentas.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.LblInfoVentas.Font = New System.Drawing.Font("Arial", 6.75!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblInfoVentas.Location = New System.Drawing.Point(0, 431)
        Me.LblInfoVentas.Name = "LblInfoVentas"
        Me.LblInfoVentas.Padding = New System.Windows.Forms.Padding(3)
        Me.LblInfoVentas.Size = New System.Drawing.Size(194, 66)
        Me.LblInfoVentas.TabIndex = 48
        Me.LblInfoVentas.Text = "Label2"
        '
        'BtPreview_FacturaVenta
        '
        Me.BtPreview_FacturaVenta.BackColor = System.Drawing.SystemColors.Control
        Me.BtPreview_FacturaVenta.Enabled = False
        Me.BtPreview_FacturaVenta.Font = New System.Drawing.Font("Tahoma", 11.25!)
        Me.BtPreview_FacturaVenta.Image = CType(resources.GetObject("BtPreview_FacturaVenta.Image"), System.Drawing.Image)
        Me.BtPreview_FacturaVenta.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtPreview_FacturaVenta.Location = New System.Drawing.Point(3, 38)
        Me.BtPreview_FacturaVenta.Name = "BtPreview_FacturaVenta"
        Me.BtPreview_FacturaVenta.Size = New System.Drawing.Size(188, 56)
        Me.BtPreview_FacturaVenta.TabIndex = 43
        Me.BtPreview_FacturaVenta.Tag = "PRINTVENTA"
        Me.BtPreview_FacturaVenta.Text = "Ver Factura"
        Me.BtPreview_FacturaVenta.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BtPreview_FacturaVenta.UseVisualStyleBackColor = False
        '
        'BtDel_FacturaVenta
        '
        Me.BtDel_FacturaVenta.BackColor = System.Drawing.SystemColors.Control
        Me.BtDel_FacturaVenta.Enabled = False
        Me.BtDel_FacturaVenta.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtDel_FacturaVenta.Image = CType(resources.GetObject("BtDel_FacturaVenta.Image"), System.Drawing.Image)
        Me.BtDel_FacturaVenta.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtDel_FacturaVenta.Location = New System.Drawing.Point(3, 194)
        Me.BtDel_FacturaVenta.Name = "BtDel_FacturaVenta"
        Me.BtDel_FacturaVenta.Size = New System.Drawing.Size(188, 42)
        Me.BtDel_FacturaVenta.TabIndex = 41
        Me.BtDel_FacturaVenta.Tag = "DELVENTA"
        Me.BtDel_FacturaVenta.Text = "Eliminar Factura"
        Me.BtDel_FacturaVenta.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BtDel_FacturaVenta.UseVisualStyleBackColor = False
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
        Me.LblDaySelect.Size = New System.Drawing.Size(194, 35)
        Me.LblDaySelect.TabIndex = 42
        Me.LblDaySelect.Text = "ACCIONES"
        Me.LblDaySelect.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'GridVentas
        '
        Me.GridVentas.AllowUserToAddRows = False
        Me.GridVentas.AllowUserToDeleteRows = False
        Me.GridVentas.AllowUserToOrderColumns = True
        Me.GridVentas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.GridVentas.Location = New System.Drawing.Point(3, 6)
        Me.GridVentas.Name = "GridVentas"
        Me.GridVentas.ReadOnly = True
        Me.GridVentas.RowHeadersWidth = 35
        Me.GridVentas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.GridVentas.Size = New System.Drawing.Size(694, 491)
        Me.GridVentas.TabIndex = 10
        '
        'TabPage_AlbaranesCompra
        '
        Me.TabPage_AlbaranesCompra.Controls.Add(Me.Panel3)
        Me.TabPage_AlbaranesCompra.Controls.Add(Me.GridAlbaranes)
        Me.TabPage_AlbaranesCompra.ImageIndex = 2
        Me.TabPage_AlbaranesCompra.Location = New System.Drawing.Point(4, 23)
        Me.TabPage_AlbaranesCompra.Name = "TabPage_AlbaranesCompra"
        Me.TabPage_AlbaranesCompra.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage_AlbaranesCompra.Size = New System.Drawing.Size(900, 503)
        Me.TabPage_AlbaranesCompra.TabIndex = 3
        Me.TabPage_AlbaranesCompra.Text = "Albaranes de Compra"
        Me.TabPage_AlbaranesCompra.UseVisualStyleBackColor = True
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.Color.Transparent
        Me.Panel3.Controls.Add(Me.BtEdit)
        Me.Panel3.Controls.Add(Me.Label5)
        Me.Panel3.Controls.Add(Me.LblInfoCompras)
        Me.Panel3.Controls.Add(Me.BtAdd)
        Me.Panel3.Controls.Add(Me.BtDel)
        Me.Panel3.Controls.Add(Me.Label6)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Right
        Me.Panel3.Location = New System.Drawing.Point(725, 3)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(172, 497)
        Me.Panel3.TabIndex = 11
        '
        'BtEdit
        '
        Me.BtEdit.BackColor = System.Drawing.SystemColors.Control
        Me.BtEdit.Enabled = False
        Me.BtEdit.Font = New System.Drawing.Font("Tahoma", 11.25!)
        Me.BtEdit.Image = CType(resources.GetObject("BtEdit.Image"), System.Drawing.Image)
        Me.BtEdit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtEdit.Location = New System.Drawing.Point(3, 100)
        Me.BtEdit.Name = "BtEdit"
        Me.BtEdit.Size = New System.Drawing.Size(166, 42)
        Me.BtEdit.TabIndex = 50
        Me.BtEdit.Tag = "EDIT"
        Me.BtEdit.Text = "Mostrar Albarán "
        Me.BtEdit.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BtEdit.UseVisualStyleBackColor = False
        '
        'Label5
        '
        Me.Label5.BackColor = System.Drawing.Color.LightSteelBlue
        Me.Label5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label5.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Label5.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Image = CType(resources.GetObject("Label5.Image"), System.Drawing.Image)
        Me.Label5.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Label5.Location = New System.Drawing.Point(0, 410)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(172, 21)
        Me.Label5.TabIndex = 49
        Me.Label5.Text = "Detalles"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'LblInfoCompras
        '
        Me.LblInfoCompras.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LblInfoCompras.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.LblInfoCompras.Font = New System.Drawing.Font("Arial", 6.75!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblInfoCompras.Location = New System.Drawing.Point(0, 431)
        Me.LblInfoCompras.Name = "LblInfoCompras"
        Me.LblInfoCompras.Padding = New System.Windows.Forms.Padding(3)
        Me.LblInfoCompras.Size = New System.Drawing.Size(172, 66)
        Me.LblInfoCompras.TabIndex = 48
        '
        'BtAdd
        '
        Me.BtAdd.BackColor = System.Drawing.SystemColors.Control
        Me.BtAdd.Font = New System.Drawing.Font("Tahoma", 11.25!)
        Me.BtAdd.Image = CType(resources.GetObject("BtAdd.Image"), System.Drawing.Image)
        Me.BtAdd.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtAdd.Location = New System.Drawing.Point(3, 38)
        Me.BtAdd.Name = "BtAdd"
        Me.BtAdd.Size = New System.Drawing.Size(166, 56)
        Me.BtAdd.TabIndex = 43
        Me.BtAdd.Tag = "ADD"
        Me.BtAdd.Text = "Añadir Albarán"
        Me.BtAdd.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BtAdd.UseVisualStyleBackColor = False
        '
        'BtDel
        '
        Me.BtDel.BackColor = System.Drawing.SystemColors.Control
        Me.BtDel.Enabled = False
        Me.BtDel.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtDel.Image = CType(resources.GetObject("BtDel.Image"), System.Drawing.Image)
        Me.BtDel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtDel.Location = New System.Drawing.Point(3, 148)
        Me.BtDel.Name = "BtDel"
        Me.BtDel.Size = New System.Drawing.Size(166, 42)
        Me.BtDel.TabIndex = 41
        Me.BtDel.Tag = "DEL"
        Me.BtDel.Text = "Eliminar Albarán"
        Me.BtDel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BtDel.UseVisualStyleBackColor = False
        '
        'Label6
        '
        Me.Label6.BackColor = System.Drawing.Color.LightSteelBlue
        Me.Label6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label6.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label6.Font = New System.Drawing.Font("Verdana", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Image = CType(resources.GetObject("Label6.Image"), System.Drawing.Image)
        Me.Label6.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Label6.Location = New System.Drawing.Point(0, 0)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(172, 35)
        Me.Label6.TabIndex = 42
        Me.Label6.Text = "ACCIONES"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'GridAlbaranes
        '
        Me.GridAlbaranes.AllowUserToAddRows = False
        Me.GridAlbaranes.AllowUserToDeleteRows = False
        Me.GridAlbaranes.AllowUserToOrderColumns = True
        Me.GridAlbaranes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.GridAlbaranes.Location = New System.Drawing.Point(3, 6)
        Me.GridAlbaranes.Name = "GridAlbaranes"
        Me.GridAlbaranes.ReadOnly = True
        Me.GridAlbaranes.RowHeadersWidth = 25
        Me.GridAlbaranes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.GridAlbaranes.Size = New System.Drawing.Size(718, 493)
        Me.GridAlbaranes.TabIndex = 10
        '
        'TabPage_FacturasCompra
        '
        Me.TabPage_FacturasCompra.Controls.Add(Me.Panel2)
        Me.TabPage_FacturasCompra.Controls.Add(Me.GridCompras)
        Me.TabPage_FacturasCompra.ImageIndex = 1
        Me.TabPage_FacturasCompra.Location = New System.Drawing.Point(4, 23)
        Me.TabPage_FacturasCompra.Name = "TabPage_FacturasCompra"
        Me.TabPage_FacturasCompra.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage_FacturasCompra.Size = New System.Drawing.Size(900, 503)
        Me.TabPage_FacturasCompra.TabIndex = 1
        Me.TabPage_FacturasCompra.Text = "Facturas de Compra"
        Me.TabPage_FacturasCompra.UseVisualStyleBackColor = True
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.Transparent
        Me.Panel2.Controls.Add(Me.BtDesfacturar)
        Me.Panel2.Controls.Add(Me.Label1)
        Me.Panel2.Controls.Add(Me.Label2)
        Me.Panel2.Controls.Add(Me.Button1)
        Me.Panel2.Controls.Add(Me.Button2)
        Me.Panel2.Controls.Add(Me.Label4)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Right
        Me.Panel2.Location = New System.Drawing.Point(703, 3)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(194, 497)
        Me.Panel2.TabIndex = 12
        '
        'BtDesfacturar
        '
        Me.BtDesfacturar.BackColor = System.Drawing.SystemColors.Control
        Me.BtDesfacturar.Enabled = False
        Me.BtDesfacturar.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtDesfacturar.Image = CType(resources.GetObject("BtDesfacturar.Image"), System.Drawing.Image)
        Me.BtDesfacturar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtDesfacturar.Location = New System.Drawing.Point(3, 148)
        Me.BtDesfacturar.Name = "BtDesfacturar"
        Me.BtDesfacturar.Size = New System.Drawing.Size(188, 42)
        Me.BtDesfacturar.TabIndex = 50
        Me.BtDesfacturar.Tag = "DESFACTURAR_COMPRA"
        Me.BtDesfacturar.Text = "Desfacturar Factura"
        Me.BtDesfacturar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BtDesfacturar.UseVisualStyleBackColor = False
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.LightSteelBlue
        Me.Label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Label1.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Image = CType(resources.GetObject("Label1.Image"), System.Drawing.Image)
        Me.Label1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Label1.Location = New System.Drawing.Point(0, 410)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(194, 21)
        Me.Label1.TabIndex = 49
        Me.Label1.Text = "Detalles"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.Label1.Visible = False
        '
        'Label2
        '
        Me.Label2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Label2.Font = New System.Drawing.Font("Arial", 6.75!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(0, 431)
        Me.Label2.Name = "Label2"
        Me.Label2.Padding = New System.Windows.Forms.Padding(3)
        Me.Label2.Size = New System.Drawing.Size(194, 66)
        Me.Label2.TabIndex = 48
        Me.Label2.Visible = False
        '
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.SystemColors.Control
        Me.Button1.Enabled = False
        Me.Button1.Font = New System.Drawing.Font("Tahoma", 11.25!)
        Me.Button1.Image = CType(resources.GetObject("Button1.Image"), System.Drawing.Image)
        Me.Button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Button1.Location = New System.Drawing.Point(3, 38)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(188, 56)
        Me.Button1.TabIndex = 43
        Me.Button1.Tag = "PRINTVENTA"
        Me.Button1.Text = "Ver Factura"
        Me.Button1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Button1.UseVisualStyleBackColor = False
        '
        'Button2
        '
        Me.Button2.BackColor = System.Drawing.SystemColors.Control
        Me.Button2.Enabled = False
        Me.Button2.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button2.Image = CType(resources.GetObject("Button2.Image"), System.Drawing.Image)
        Me.Button2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Button2.Location = New System.Drawing.Point(3, 100)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(188, 42)
        Me.Button2.TabIndex = 41
        Me.Button2.Tag = "DELVENTA"
        Me.Button2.Text = "Eliminar Factura"
        Me.Button2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Button2.UseVisualStyleBackColor = False
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.Color.LightSteelBlue
        Me.Label4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label4.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label4.Font = New System.Drawing.Font("Verdana", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Image = CType(resources.GetObject("Label4.Image"), System.Drawing.Image)
        Me.Label4.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Label4.Location = New System.Drawing.Point(0, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(194, 35)
        Me.Label4.TabIndex = 42
        Me.Label4.Text = "ACCIONES"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'GridCompras
        '
        Me.GridCompras.AllowUserToAddRows = False
        Me.GridCompras.AllowUserToDeleteRows = False
        Me.GridCompras.AllowUserToOrderColumns = True
        Me.GridCompras.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.GridCompras.Location = New System.Drawing.Point(3, 6)
        Me.GridCompras.Name = "GridCompras"
        Me.GridCompras.ReadOnly = True
        Me.GridCompras.RowHeadersWidth = 35
        Me.GridCompras.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.GridCompras.Size = New System.Drawing.Size(694, 491)
        Me.GridCompras.TabIndex = 11
        '
        'ImageList
        '
        Me.ImageList.ImageStream = CType(resources.GetObject("ImageList.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageList.Images.SetKeyName(0, "import.png")
        Me.ImageList.Images.SetKeyName(1, "shop_cart.png")
        Me.ImageList.Images.SetKeyName(2, "bookmarck2.png")
        '
        'ImageList_day
        '
        Me.ImageList_day.ImageStream = CType(resources.GetObject("ImageList_day.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList_day.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageList_day.Images.SetKeyName(0, "note.png")
        '
        'btEditFactura
        '
        Me.btEditFactura.BackColor = System.Drawing.SystemColors.Control
        Me.btEditFactura.Enabled = False
        Me.btEditFactura.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btEditFactura.Image = CType(resources.GetObject("btEditFactura.Image"), System.Drawing.Image)
        Me.btEditFactura.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btEditFactura.Location = New System.Drawing.Point(3, 242)
        Me.btEditFactura.Name = "btEditFactura"
        Me.btEditFactura.Size = New System.Drawing.Size(188, 42)
        Me.btEditFactura.TabIndex = 51
        Me.btEditFactura.Tag = "EDITVENTA"
        Me.btEditFactura.Text = "Editar Venta"
        Me.btEditFactura.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btEditFactura.UseVisualStyleBackColor = False
        '
        'frmFacturacion
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Black
        Me.ClientSize = New System.Drawing.Size(1020, 770)
        Me.Controls.Add(Me.SplitContainer)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "frmFacturacion"
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
        Me.PnlBody.PerformLayout()
        Me.PnlData.ResumeLayout(False)
        Me.Tab.ResumeLayout(False)
        Me.TabPage_FacturasVenta.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        CType(Me.GridVentas, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage_AlbaranesCompra.ResumeLayout(False)
        Me.Panel3.ResumeLayout(False)
        CType(Me.GridAlbaranes, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage_FacturasCompra.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        CType(Me.GridCompras, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents SplitContainer As System.Windows.Forms.SplitContainer
    Friend WithEvents m_logo As System.Windows.Forms.PictureBox
    Friend WithEvents PnlButton_Shell As System.Windows.Forms.Panel
    Friend WithEvents BtClose As System.Windows.Forms.Button
    Friend WithEvents BtMin As System.Windows.Forms.Button
    Friend WithEvents LblSubTitle As System.Windows.Forms.Label
    Friend WithEvents LblTitle As System.Windows.Forms.Label
    Friend WithEvents PnlBody As System.Windows.Forms.Panel
    Friend WithEvents ImageList As System.Windows.Forms.ImageList
    Friend WithEvents PnlData As System.Windows.Forms.Panel
    Friend WithEvents ToolTip As System.Windows.Forms.ToolTip
    Friend WithEvents ImageList_day As System.Windows.Forms.ImageList
    Friend WithEvents GridVentas As System.Windows.Forms.DataGridView
    Friend WithEvents LblMonth As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents BtDel_FacturaVenta As System.Windows.Forms.Button
    Friend WithEvents LblDaySelect As System.Windows.Forms.Label
    Friend WithEvents BtPreview_FacturaVenta As System.Windows.Forms.Button
    Friend WithEvents Tab As System.Windows.Forms.TabControl
    Friend WithEvents TabPage_FacturasVenta As System.Windows.Forms.TabPage
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents LblInfoVentas As System.Windows.Forms.Label
    Friend WithEvents TabPage_FacturasCompra As System.Windows.Forms.TabPage
    Friend WithEvents GridCompras As System.Windows.Forms.DataGridView
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents BtTicket As System.Windows.Forms.Button
    Friend WithEvents BtDesfacturar As System.Windows.Forms.Button
    Friend WithEvents TabPage_AlbaranesCompra As System.Windows.Forms.TabPage
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents BtEdit As System.Windows.Forms.Button
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents LblInfoCompras As System.Windows.Forms.Label
    Friend WithEvents BtAdd As System.Windows.Forms.Button
    Friend WithEvents BtDel As System.Windows.Forms.Button
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents GridAlbaranes As System.Windows.Forms.DataGridView
    Friend WithEvents btEditFactura As System.Windows.Forms.Button
End Class
