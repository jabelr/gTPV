<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmPedidos
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
        Me.components = New System.ComponentModel.Container
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmPedidos))
        Me.LblHistory_Empleado = New System.Windows.Forms.Label
        Me.SplitContainer = New System.Windows.Forms.SplitContainer
        Me.LblHour = New System.Windows.Forms.Label
        Me.m_logo = New System.Windows.Forms.PictureBox
        Me.PnlButton_Shell = New System.Windows.Forms.Panel
        Me.BtCajaDirecta = New System.Windows.Forms.Button
        Me.BtClose = New System.Windows.Forms.Button
        Me.LblSubTitle = New System.Windows.Forms.Label
        Me.LblTitle = New System.Windows.Forms.Label
        Me.PnlBody = New System.Windows.Forms.Panel
        Me.PnlData = New System.Windows.Forms.Panel
        Me.Tab = New System.Windows.Forms.TabControl
        Me.TabPage_Pedidos = New System.Windows.Forms.TabPage
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer
        Me.PnlHistory = New System.Windows.Forms.Panel
        Me.GroupHistory = New System.Windows.Forms.GroupBox
        Me.lblHistory_ID = New System.Windows.Forms.Label
        Me.BtHistory_Edit = New System.Windows.Forms.Button
        Me.BtHistory_Print = New System.Windows.Forms.Button
        Me.LblHistory_Fh = New System.Windows.Forms.Label
        Me.Label16 = New System.Windows.Forms.Label
        Me.Label17 = New System.Windows.Forms.Label
        Me.LblHistory_Mesa = New System.Windows.Forms.Label
        Me.Label14 = New System.Windows.Forms.Label
        Me.LblHistory_Total = New System.Windows.Forms.Label
        Me.BtHistory_Next = New System.Windows.Forms.Button
        Me.BtHistory_Previous = New System.Windows.Forms.Button
        Me.gridPedidos = New System.Windows.Forms.DataGridView
        Me.Label6 = New System.Windows.Forms.Label
        Me.btPedido_Finalizar = New System.Windows.Forms.Button
        Me.btPedido_Comanda = New System.Windows.Forms.Button
        Me.btPedido_Editar = New System.Windows.Forms.Button
        Me.btPedido_Del = New System.Windows.Forms.Button
        Me.btPedido_Cancela = New System.Windows.Forms.Button
        Me.btPedido_Print = New System.Windows.Forms.Button
        Me.LblDaySelect = New System.Windows.Forms.Label
        Me.TabPage_articulos = New System.Windows.Forms.TabPage
        Me.SplitHistory = New System.Windows.Forms.SplitContainer
        Me.btAll = New System.Windows.Forms.Button
        Me.GridHistory = New System.Windows.Forms.DataGridView
        Me.Label20 = New System.Windows.Forms.Label
        Me.lblTicket = New System.Windows.Forms.Label
        Me.GridHistoryLines = New System.Windows.Forms.DataGridView
        Me.Label21 = New System.Windows.Forms.Label
        Me.ToolTip = New System.Windows.Forms.ToolTip(Me.components)
        Me.TmHour = New System.Windows.Forms.Timer(Me.components)
        Me.SplitContainer.Panel1.SuspendLayout()
        Me.SplitContainer.Panel2.SuspendLayout()
        Me.SplitContainer.SuspendLayout()
        CType(Me.m_logo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PnlButton_Shell.SuspendLayout()
        Me.PnlBody.SuspendLayout()
        Me.PnlData.SuspendLayout()
        Me.Tab.SuspendLayout()
        Me.TabPage_Pedidos.SuspendLayout()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        Me.PnlHistory.SuspendLayout()
        Me.GroupHistory.SuspendLayout()
        CType(Me.gridPedidos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage_articulos.SuspendLayout()
        Me.SplitHistory.Panel1.SuspendLayout()
        Me.SplitHistory.Panel2.SuspendLayout()
        Me.SplitHistory.SuspendLayout()
        CType(Me.GridHistory, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridHistoryLines, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
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
        Me.PnlButton_Shell.Controls.Add(Me.BtCajaDirecta)
        Me.PnlButton_Shell.Controls.Add(Me.BtClose)
        Me.PnlButton_Shell.Dock = System.Windows.Forms.DockStyle.Right
        Me.PnlButton_Shell.Location = New System.Drawing.Point(470, 0)
        Me.PnlButton_Shell.Name = "PnlButton_Shell"
        Me.PnlButton_Shell.Size = New System.Drawing.Size(550, 64)
        Me.PnlButton_Shell.TabIndex = 2
        '
        'BtCajaDirecta
        '
        Me.BtCajaDirecta.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.BtCajaDirecta.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Bold)
        Me.BtCajaDirecta.Image = CType(resources.GetObject("BtCajaDirecta.Image"), System.Drawing.Image)
        Me.BtCajaDirecta.Location = New System.Drawing.Point(112, 6)
        Me.BtCajaDirecta.Name = "BtCajaDirecta"
        Me.BtCajaDirecta.Size = New System.Drawing.Size(253, 57)
        Me.BtCajaDirecta.TabIndex = 8
        Me.BtCajaDirecta.Tag = "NUEVO"
        Me.BtCajaDirecta.Text = "Nuevo Pedido"
        Me.BtCajaDirecta.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BtCajaDirecta.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.BtCajaDirecta.UseVisualStyleBackColor = True
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
        Me.LblSubTitle.Text = "Gestión de pedidos de clientes para reparto a domicilio"
        '
        'LblTitle
        '
        Me.LblTitle.AutoSize = True
        Me.LblTitle.Font = New System.Drawing.Font("Tahoma", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblTitle.Location = New System.Drawing.Point(57, 4)
        Me.LblTitle.Name = "LblTitle"
        Me.LblTitle.Size = New System.Drawing.Size(193, 23)
        Me.LblTitle.TabIndex = 0
        Me.LblTitle.Text = "Gestión de Pedidos"
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
        Me.Tab.Controls.Add(Me.TabPage_Pedidos)
        Me.Tab.Controls.Add(Me.TabPage_articulos)
        Me.Tab.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Tab.Location = New System.Drawing.Point(0, 3)
        Me.Tab.Name = "Tab"
        Me.Tab.SelectedIndex = 0
        Me.Tab.Size = New System.Drawing.Size(908, 600)
        Me.Tab.TabIndex = 41
        '
        'TabPage_Pedidos
        '
        Me.TabPage_Pedidos.Controls.Add(Me.SplitContainer1)
        Me.TabPage_Pedidos.Location = New System.Drawing.Point(4, 22)
        Me.TabPage_Pedidos.Name = "TabPage_Pedidos"
        Me.TabPage_Pedidos.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage_Pedidos.Size = New System.Drawing.Size(900, 574)
        Me.TabPage_Pedidos.TabIndex = 0
        Me.TabPage_Pedidos.Text = "Lista de Pedidos"
        Me.TabPage_Pedidos.UseVisualStyleBackColor = True
        '
        'SplitContainer1
        '
        Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer1.Location = New System.Drawing.Point(3, 3)
        Me.SplitContainer1.Name = "SplitContainer1"
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.PnlHistory)
        Me.SplitContainer1.Panel1.Controls.Add(Me.gridPedidos)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label6)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.btPedido_Finalizar)
        Me.SplitContainer1.Panel2.Controls.Add(Me.btPedido_Comanda)
        Me.SplitContainer1.Panel2.Controls.Add(Me.btPedido_Editar)
        Me.SplitContainer1.Panel2.Controls.Add(Me.btPedido_Del)
        Me.SplitContainer1.Panel2.Controls.Add(Me.btPedido_Cancela)
        Me.SplitContainer1.Panel2.Controls.Add(Me.btPedido_Print)
        Me.SplitContainer1.Panel2.Controls.Add(Me.LblDaySelect)
        Me.SplitContainer1.Size = New System.Drawing.Size(894, 568)
        Me.SplitContainer1.SplitterDistance = 778
        Me.SplitContainer1.TabIndex = 0
        '
        'PnlHistory
        '
        Me.PnlHistory.BackColor = System.Drawing.Color.Gainsboro
        Me.PnlHistory.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.PnlHistory.Controls.Add(Me.GroupHistory)
        Me.PnlHistory.Controls.Add(Me.BtHistory_Next)
        Me.PnlHistory.Controls.Add(Me.BtHistory_Previous)
        Me.PnlHistory.Location = New System.Drawing.Point(258, 435)
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
        Me.LblHistory_Total.Text = "0.000,00 €"
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
        'gridPedidos
        '
        Me.gridPedidos.AllowUserToAddRows = False
        Me.gridPedidos.AllowUserToDeleteRows = False
        Me.gridPedidos.AllowUserToOrderColumns = True
        Me.gridPedidos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.gridPedidos.Dock = System.Windows.Forms.DockStyle.Fill
        Me.gridPedidos.Location = New System.Drawing.Point(0, 29)
        Me.gridPedidos.Name = "gridPedidos"
        Me.gridPedidos.ReadOnly = True
        Me.gridPedidos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.gridPedidos.Size = New System.Drawing.Size(778, 539)
        Me.gridPedidos.TabIndex = 44
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
        Me.Label6.Size = New System.Drawing.Size(778, 29)
        Me.Label6.TabIndex = 45
        Me.Label6.Text = "HISTORIAL DE PEDIDOS"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'btPedido_Finalizar
        '
        Me.btPedido_Finalizar.BackColor = System.Drawing.SystemColors.Control
        Me.btPedido_Finalizar.Font = New System.Drawing.Font("Tahoma", 11.25!)
        Me.btPedido_Finalizar.Image = CType(resources.GetObject("btPedido_Finalizar.Image"), System.Drawing.Image)
        Me.btPedido_Finalizar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btPedido_Finalizar.Location = New System.Drawing.Point(3, 500)
        Me.btPedido_Finalizar.Name = "btPedido_Finalizar"
        Me.btPedido_Finalizar.Size = New System.Drawing.Size(106, 65)
        Me.btPedido_Finalizar.TabIndex = 44
        Me.btPedido_Finalizar.Tag = ""
        Me.btPedido_Finalizar.Text = "Finalizar Entregas"
        Me.btPedido_Finalizar.TextAlign = System.Drawing.ContentAlignment.TopRight
        Me.btPedido_Finalizar.UseVisualStyleBackColor = False
        '
        'btPedido_Comanda
        '
        Me.btPedido_Comanda.BackColor = System.Drawing.SystemColors.Control
        Me.btPedido_Comanda.Enabled = False
        Me.btPedido_Comanda.Font = New System.Drawing.Font("Tahoma", 11.25!)
        Me.btPedido_Comanda.Image = CType(resources.GetObject("btPedido_Comanda.Image"), System.Drawing.Image)
        Me.btPedido_Comanda.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btPedido_Comanda.Location = New System.Drawing.Point(3, 180)
        Me.btPedido_Comanda.Name = "btPedido_Comanda"
        Me.btPedido_Comanda.Size = New System.Drawing.Size(106, 65)
        Me.btPedido_Comanda.TabIndex = 2
        Me.btPedido_Comanda.Tag = "PRINTCOMANDA"
        Me.btPedido_Comanda.Text = "Imprimir Comanda"
        Me.btPedido_Comanda.TextAlign = System.Drawing.ContentAlignment.TopRight
        Me.btPedido_Comanda.UseVisualStyleBackColor = False
        Me.btPedido_Comanda.Visible = False
        '
        'btPedido_Editar
        '
        Me.btPedido_Editar.BackColor = System.Drawing.SystemColors.Control
        Me.btPedido_Editar.Enabled = False
        Me.btPedido_Editar.Font = New System.Drawing.Font("Tahoma", 11.25!)
        Me.btPedido_Editar.Image = CType(resources.GetObject("btPedido_Editar.Image"), System.Drawing.Image)
        Me.btPedido_Editar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btPedido_Editar.Location = New System.Drawing.Point(3, 38)
        Me.btPedido_Editar.Name = "btPedido_Editar"
        Me.btPedido_Editar.Size = New System.Drawing.Size(106, 65)
        Me.btPedido_Editar.TabIndex = 0
        Me.btPedido_Editar.Tag = "MODIFICAR"
        Me.btPedido_Editar.Text = "Modificar Pedido"
        Me.btPedido_Editar.TextAlign = System.Drawing.ContentAlignment.TopRight
        Me.btPedido_Editar.UseVisualStyleBackColor = False
        '
        'btPedido_Del
        '
        Me.btPedido_Del.BackColor = System.Drawing.SystemColors.Control
        Me.btPedido_Del.Enabled = False
        Me.btPedido_Del.Font = New System.Drawing.Font("Tahoma", 11.25!)
        Me.btPedido_Del.Image = CType(resources.GetObject("btPedido_Del.Image"), System.Drawing.Image)
        Me.btPedido_Del.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btPedido_Del.Location = New System.Drawing.Point(3, 322)
        Me.btPedido_Del.Name = "btPedido_Del"
        Me.btPedido_Del.Size = New System.Drawing.Size(106, 65)
        Me.btPedido_Del.TabIndex = 4
        Me.btPedido_Del.Tag = "ELIMINARPEDIDO"
        Me.btPedido_Del.Text = "Eliminar Pedido"
        Me.btPedido_Del.TextAlign = System.Drawing.ContentAlignment.TopRight
        Me.btPedido_Del.UseVisualStyleBackColor = False
        '
        'btPedido_Cancela
        '
        Me.btPedido_Cancela.BackColor = System.Drawing.SystemColors.Control
        Me.btPedido_Cancela.Enabled = False
        Me.btPedido_Cancela.Font = New System.Drawing.Font("Tahoma", 11.25!)
        Me.btPedido_Cancela.Image = CType(resources.GetObject("btPedido_Cancela.Image"), System.Drawing.Image)
        Me.btPedido_Cancela.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btPedido_Cancela.Location = New System.Drawing.Point(3, 251)
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
        Me.btPedido_Print.Location = New System.Drawing.Point(3, 109)
        Me.btPedido_Print.Name = "btPedido_Print"
        Me.btPedido_Print.Size = New System.Drawing.Size(106, 65)
        Me.btPedido_Print.TabIndex = 1
        Me.btPedido_Print.Tag = "PRINTPEDIDO"
        Me.btPedido_Print.Text = "Imprimir Pedido"
        Me.btPedido_Print.TextAlign = System.Drawing.ContentAlignment.TopRight
        Me.btPedido_Print.UseVisualStyleBackColor = False
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
        Me.LblDaySelect.Size = New System.Drawing.Size(112, 35)
        Me.LblDaySelect.TabIndex = 43
        Me.LblDaySelect.Text = "ACCIONES"
        Me.LblDaySelect.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'TabPage_articulos
        '
        Me.TabPage_articulos.Controls.Add(Me.SplitHistory)
        Me.TabPage_articulos.Location = New System.Drawing.Point(4, 22)
        Me.TabPage_articulos.Name = "TabPage_articulos"
        Me.TabPage_articulos.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage_articulos.Size = New System.Drawing.Size(900, 574)
        Me.TabPage_articulos.TabIndex = 1
        Me.TabPage_articulos.Text = "Productos solicitados"
        Me.TabPage_articulos.UseVisualStyleBackColor = True
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
        Me.SplitHistory.Panel1.Controls.Add(Me.btAll)
        Me.SplitHistory.Panel1.Controls.Add(Me.GridHistory)
        Me.SplitHistory.Panel1.Controls.Add(Me.Label20)
        '
        'SplitHistory.Panel2
        '
        Me.SplitHistory.Panel2.Controls.Add(Me.lblTicket)
        Me.SplitHistory.Panel2.Controls.Add(Me.GridHistoryLines)
        Me.SplitHistory.Panel2.Controls.Add(Me.Label21)
        Me.SplitHistory.Size = New System.Drawing.Size(894, 568)
        Me.SplitHistory.SplitterDistance = 637
        Me.SplitHistory.SplitterWidth = 2
        Me.SplitHistory.TabIndex = 2
        '
        'btAll
        '
        Me.btAll.BackColor = System.Drawing.Color.PowderBlue
        Me.btAll.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btAll.Image = CType(resources.GetObject("btAll.Image"), System.Drawing.Image)
        Me.btAll.Location = New System.Drawing.Point(579, 2)
        Me.btAll.Name = "btAll"
        Me.btAll.Size = New System.Drawing.Size(55, 22)
        Me.btAll.TabIndex = 9
        Me.btAll.Tag = ""
        Me.btAll.Text = "  All"
        Me.btAll.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btAll.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btAll.UseVisualStyleBackColor = False
        '
        'GridHistory
        '
        Me.GridHistory.AllowUserToAddRows = False
        Me.GridHistory.AllowUserToDeleteRows = False
        Me.GridHistory.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.GridHistory.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GridHistory.Location = New System.Drawing.Point(0, 27)
        Me.GridHistory.Name = "GridHistory"
        Me.GridHistory.ReadOnly = True
        Me.GridHistory.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        Me.GridHistory.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.GridHistory.Size = New System.Drawing.Size(637, 541)
        Me.GridHistory.TabIndex = 5
        Me.GridHistory.Tag = ""
        '
        'Label20
        '
        Me.Label20.BackColor = System.Drawing.Color.LightSteelBlue
        Me.Label20.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label20.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label20.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label20.Location = New System.Drawing.Point(0, 0)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(637, 27)
        Me.Label20.TabIndex = 4
        Me.Label20.Tag = ""
        Me.Label20.Text = "HISTORIAL DE PEDIDOS POR LINEA"
        Me.Label20.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblTicket
        '
        Me.lblTicket.BackColor = System.Drawing.Color.LightBlue
        Me.lblTicket.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblTicket.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTicket.Location = New System.Drawing.Point(160, 3)
        Me.lblTicket.Name = "lblTicket"
        Me.lblTicket.Size = New System.Drawing.Size(92, 20)
        Me.lblTicket.TabIndex = 7
        Me.lblTicket.Tag = ""
        Me.lblTicket.Text = "NTICKET"
        Me.lblTicket.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'GridHistoryLines
        '
        Me.GridHistoryLines.AllowUserToAddRows = False
        Me.GridHistoryLines.AllowUserToDeleteRows = False
        Me.GridHistoryLines.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.GridHistoryLines.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GridHistoryLines.Location = New System.Drawing.Point(0, 27)
        Me.GridHistoryLines.Name = "GridHistoryLines"
        Me.GridHistoryLines.ReadOnly = True
        Me.GridHistoryLines.RowHeadersWidth = 15
        Me.GridHistoryLines.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        Me.GridHistoryLines.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.GridHistoryLines.Size = New System.Drawing.Size(255, 541)
        Me.GridHistoryLines.TabIndex = 6
        Me.GridHistoryLines.Tag = ""
        '
        'Label21
        '
        Me.Label21.BackColor = System.Drawing.Color.LightSteelBlue
        Me.Label21.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label21.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label21.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label21.Location = New System.Drawing.Point(0, 0)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(255, 27)
        Me.Label21.TabIndex = 5
        Me.Label21.Tag = ""
        Me.Label21.Text = "ACUMULADO DE PEDIDOS"
        Me.Label21.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'TmHour
        '
        Me.TmHour.Interval = 30000
        '
        'frmPedidos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoScroll = True
        Me.BackColor = System.Drawing.Color.Black
        Me.ClientSize = New System.Drawing.Size(1020, 770)
        Me.Controls.Add(Me.SplitContainer)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "frmPedidos"
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
        Me.TabPage_Pedidos.ResumeLayout(False)
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        Me.SplitContainer1.ResumeLayout(False)
        Me.PnlHistory.ResumeLayout(False)
        Me.GroupHistory.ResumeLayout(False)
        Me.GroupHistory.PerformLayout()
        CType(Me.gridPedidos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage_articulos.ResumeLayout(False)
        Me.SplitHistory.Panel1.ResumeLayout(False)
        Me.SplitHistory.Panel2.ResumeLayout(False)
        Me.SplitHistory.ResumeLayout(False)
        CType(Me.GridHistory, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridHistoryLines, System.ComponentModel.ISupportInitialize).EndInit()
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
    Friend WithEvents BtCajaDirecta As System.Windows.Forms.Button
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
    Friend WithEvents TabPage_Pedidos As System.Windows.Forms.TabPage
    Friend WithEvents TabPage_articulos As System.Windows.Forms.TabPage
    Friend WithEvents lblHistory_ID As System.Windows.Forms.Label
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Friend WithEvents gridPedidos As System.Windows.Forms.DataGridView
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents LblDaySelect As System.Windows.Forms.Label
    Friend WithEvents btPedido_Print As System.Windows.Forms.Button
    Friend WithEvents btPedido_Editar As System.Windows.Forms.Button
    Friend WithEvents btPedido_Del As System.Windows.Forms.Button
    Friend WithEvents btPedido_Cancela As System.Windows.Forms.Button
    Friend WithEvents btPedido_Comanda As System.Windows.Forms.Button
    Friend WithEvents SplitHistory As System.Windows.Forms.SplitContainer
    Friend WithEvents GridHistory As System.Windows.Forms.DataGridView
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents GridHistoryLines As System.Windows.Forms.DataGridView
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents lblTicket As System.Windows.Forms.Label
    Friend WithEvents btAll As System.Windows.Forms.Button
    Friend WithEvents btPedido_Finalizar As System.Windows.Forms.Button
End Class
