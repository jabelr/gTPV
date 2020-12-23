<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCajas
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
        Dim LblNfoFhAlta As System.Windows.Forms.Label
        Dim Label6 As System.Windows.Forms.Label
        Dim Label7 As System.Windows.Forms.Label
        Dim Label8 As System.Windows.Forms.Label
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmCajas))
        Me.SplitContainer = New System.Windows.Forms.SplitContainer()
        Me.m_logo = New System.Windows.Forms.PictureBox()
        Me.PnlButton_Shell = New System.Windows.Forms.Panel()
        Me.BtCerrarCaja = New System.Windows.Forms.Button()
        Me.BtClose = New System.Windows.Forms.Button()
        Me.BtMin = New System.Windows.Forms.Button()
        Me.LblSubTitle = New System.Windows.Forms.Label()
        Me.LblTitle = New System.Windows.Forms.Label()
        Me.PnlBody = New System.Windows.Forms.Panel()
        Me.LblMonth = New System.Windows.Forms.Label()
        Me.PnlData = New System.Windows.Forms.Panel()
        Me.Tab = New System.Windows.Forms.TabControl()
        Me.TabPage_CajaActual = New System.Windows.Forms.TabPage()
        Me.TabCajaActual = New System.Windows.Forms.TabControl()
        Me.TabCajaActual_Tickets = New System.Windows.Forms.TabPage()
        Me.GridActual = New System.Windows.Forms.DataGridView()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.DtCajaActual_Hasta = New System.Windows.Forms.DateTimePicker()
        Me.DtCajaActual_Desde = New System.Windows.Forms.DateTimePicker()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.PnlInfo = New System.Windows.Forms.Panel()
        Me.LblInfo = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.BtFacturar = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.LblInfoCaja = New System.Windows.Forms.Label()
        Me.BtCancell = New System.Windows.Forms.Button()
        Me.BtPrintTicket = New System.Windows.Forms.Button()
        Me.BtDelTicket = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TabCajaActual_Pedidos = New System.Windows.Forms.TabPage()
        Me.gridPedidos = New System.Windows.Forms.DataGridView()
        Me.TabCajaActual_Marcas = New System.Windows.Forms.TabPage()
        Me.gridMarcas = New System.Windows.Forms.DataGridView()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.TabPage_HistoricoCajas = New System.Windows.Forms.TabPage()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.BtPrintOldTicket_ALL = New System.Windows.Forms.Button()
        Me.BtShowCaja = New System.Windows.Forms.Button()
        Me.PnlFilter = New System.Windows.Forms.Panel()
        Me.DtFh_Hasta = New System.Windows.Forms.DateTimePicker()
        Me.DtFh_Desde = New System.Windows.Forms.DateTimePicker()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.LblInfoCajas = New System.Windows.Forms.Label()
        Me.BtPrintCaja = New System.Windows.Forms.Button()
        Me.BtDelCaja = New System.Windows.Forms.Button()
        Me.LblDaySelect = New System.Windows.Forms.Label()
        Me.GridHistorico = New System.Windows.Forms.DataGridView()
        Me.TabPage_MuestraCaja = New System.Windows.Forms.TabPage()
        Me.GridCajaClosed = New System.Windows.Forms.DataGridView()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.lblTOTAL_nCajaNew = New System.Windows.Forms.Label()
        Me.lblTOTAL_nCaja = New System.Windows.Forms.Label()
        Me.lblTOTAL_Caja = New System.Windows.Forms.Label()
        Me.lblTOTAL_CajaNew = New System.Windows.Forms.Label()
        Me.BtReload = New System.Windows.Forms.Button()
        Me.btOld_Facturar = New System.Windows.Forms.Button()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.LstLines = New System.Windows.Forms.ListView()
        Me.BtCancellOld = New System.Windows.Forms.Button()
        Me.BtPrintOldTicket = New System.Windows.Forms.Button()
        Me.BtDelOldTicket = New System.Windows.Forms.Button()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.ImageList = New System.Windows.Forms.ImageList(Me.components)
        Me.BtCloseBox = New System.Windows.Forms.Button()
        Me.ToolTip = New System.Windows.Forms.ToolTip(Me.components)
        Me.ImageList_day = New System.Windows.Forms.ImageList(Me.components)
        LblNfoFhAlta = New System.Windows.Forms.Label()
        Label6 = New System.Windows.Forms.Label()
        Label7 = New System.Windows.Forms.Label()
        Label8 = New System.Windows.Forms.Label()
        Me.SplitContainer.Panel1.SuspendLayout()
        Me.SplitContainer.Panel2.SuspendLayout()
        Me.SplitContainer.SuspendLayout()
        CType(Me.m_logo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PnlButton_Shell.SuspendLayout()
        Me.PnlBody.SuspendLayout()
        Me.PnlData.SuspendLayout()
        Me.Tab.SuspendLayout()
        Me.TabPage_CajaActual.SuspendLayout()
        Me.TabCajaActual.SuspendLayout()
        Me.TabCajaActual_Tickets.SuspendLayout()
        CType(Me.GridActual, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel2.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.PnlInfo.SuspendLayout()
        Me.TabCajaActual_Pedidos.SuspendLayout()
        CType(Me.gridPedidos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabCajaActual_Marcas.SuspendLayout()
        CType(Me.gridMarcas, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage_HistoricoCajas.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.PnlFilter.SuspendLayout()
        CType(Me.GridHistorico, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage_MuestraCaja.SuspendLayout()
        CType(Me.GridCajaClosed, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel4.SuspendLayout()
        Me.SuspendLayout()
        '
        'LblNfoFhAlta
        '
        LblNfoFhAlta.AutoSize = True
        LblNfoFhAlta.Font = New System.Drawing.Font("Tahoma", 6.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        LblNfoFhAlta.Location = New System.Drawing.Point(4, 27)
        LblNfoFhAlta.Name = "LblNfoFhAlta"
        LblNfoFhAlta.Size = New System.Drawing.Size(27, 10)
        LblNfoFhAlta.TabIndex = 63
        LblNfoFhAlta.Text = "DESDE"
        '
        'Label6
        '
        Label6.AutoSize = True
        Label6.Font = New System.Drawing.Font("Tahoma", 6.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Label6.Location = New System.Drawing.Point(4, 74)
        Label6.Name = "Label6"
        Label6.Size = New System.Drawing.Size(29, 10)
        Label6.TabIndex = 65
        Label6.Text = "HASTA"
        '
        'Label7
        '
        Label7.AutoSize = True
        Label7.Font = New System.Drawing.Font("Tahoma", 6.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Label7.Location = New System.Drawing.Point(4, 74)
        Label7.Name = "Label7"
        Label7.Size = New System.Drawing.Size(29, 10)
        Label7.TabIndex = 65
        Label7.Text = "HASTA"
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
        Me.PnlButton_Shell.Controls.Add(Me.BtCerrarCaja)
        Me.PnlButton_Shell.Controls.Add(Me.BtClose)
        Me.PnlButton_Shell.Controls.Add(Me.BtMin)
        Me.PnlButton_Shell.Dock = System.Windows.Forms.DockStyle.Right
        Me.PnlButton_Shell.Location = New System.Drawing.Point(470, 0)
        Me.PnlButton_Shell.Name = "PnlButton_Shell"
        Me.PnlButton_Shell.Size = New System.Drawing.Size(550, 64)
        Me.PnlButton_Shell.TabIndex = 2
        '
        'BtCerrarCaja
        '
        Me.BtCerrarCaja.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.BtCerrarCaja.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtCerrarCaja.Image = CType(resources.GetObject("BtCerrarCaja.Image"), System.Drawing.Image)
        Me.BtCerrarCaja.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtCerrarCaja.Location = New System.Drawing.Point(173, 4)
        Me.BtCerrarCaja.Name = "BtCerrarCaja"
        Me.BtCerrarCaja.Size = New System.Drawing.Size(189, 58)
        Me.BtCerrarCaja.TabIndex = 8
        Me.BtCerrarCaja.Tag = "cerrarcaja"
        Me.BtCerrarCaja.Text = "Cierre" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "de Caja"
        Me.BtCerrarCaja.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BtCerrarCaja.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.BtCerrarCaja.UseVisualStyleBackColor = True
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
        Me.LblSubTitle.Text = "Información y Administración sobre las cajas y los tickets generados"
        '
        'LblTitle
        '
        Me.LblTitle.AutoSize = True
        Me.LblTitle.Font = New System.Drawing.Font("Tahoma", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblTitle.Location = New System.Drawing.Point(57, 4)
        Me.LblTitle.Name = "LblTitle"
        Me.LblTitle.Size = New System.Drawing.Size(153, 23)
        Me.LblTitle.TabIndex = 0
        Me.LblTitle.Text = "Cajas y Tickets"
        '
        'PnlBody
        '
        Me.PnlBody.BackColor = System.Drawing.SystemColors.Control
        Me.PnlBody.BackgroundImage = CType(resources.GetObject("PnlBody.BackgroundImage"), System.Drawing.Image)
        Me.PnlBody.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PnlBody.Controls.Add(Me.LblMonth)
        Me.PnlBody.Controls.Add(Me.PnlData)
        Me.PnlBody.Controls.Add(Me.BtCloseBox)
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
        Me.LblMonth.Size = New System.Drawing.Size(215, 31)
        Me.LblMonth.TabIndex = 39
        Me.LblMonth.Text = "Cajas y Tickets"
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
        Me.Tab.Controls.Add(Me.TabPage_CajaActual)
        Me.Tab.Controls.Add(Me.TabPage_HistoricoCajas)
        Me.Tab.Controls.Add(Me.TabPage_MuestraCaja)
        Me.Tab.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Tab.ImageList = Me.ImageList
        Me.Tab.Location = New System.Drawing.Point(0, 0)
        Me.Tab.Name = "Tab"
        Me.Tab.SelectedIndex = 0
        Me.Tab.Size = New System.Drawing.Size(908, 530)
        Me.Tab.TabIndex = 11
        '
        'TabPage_CajaActual
        '
        Me.TabPage_CajaActual.Controls.Add(Me.TabCajaActual)
        Me.TabPage_CajaActual.ImageIndex = 1
        Me.TabPage_CajaActual.Location = New System.Drawing.Point(4, 23)
        Me.TabPage_CajaActual.Name = "TabPage_CajaActual"
        Me.TabPage_CajaActual.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage_CajaActual.Size = New System.Drawing.Size(900, 503)
        Me.TabPage_CajaActual.TabIndex = 1
        Me.TabPage_CajaActual.Text = "Caja Actual"
        Me.TabPage_CajaActual.UseVisualStyleBackColor = True
        '
        'TabCajaActual
        '
        Me.TabCajaActual.Controls.Add(Me.TabCajaActual_Tickets)
        Me.TabCajaActual.Controls.Add(Me.TabCajaActual_Pedidos)
        Me.TabCajaActual.Controls.Add(Me.TabCajaActual_Marcas)
        Me.TabCajaActual.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabCajaActual.Location = New System.Drawing.Point(3, 3)
        Me.TabCajaActual.Name = "TabCajaActual"
        Me.TabCajaActual.SelectedIndex = 0
        Me.TabCajaActual.Size = New System.Drawing.Size(894, 497)
        Me.TabCajaActual.TabIndex = 14
        '
        'TabCajaActual_Tickets
        '
        Me.TabCajaActual_Tickets.Controls.Add(Me.GridActual)
        Me.TabCajaActual_Tickets.Controls.Add(Me.Panel2)
        Me.TabCajaActual_Tickets.Location = New System.Drawing.Point(4, 22)
        Me.TabCajaActual_Tickets.Name = "TabCajaActual_Tickets"
        Me.TabCajaActual_Tickets.Padding = New System.Windows.Forms.Padding(3)
        Me.TabCajaActual_Tickets.Size = New System.Drawing.Size(886, 471)
        Me.TabCajaActual_Tickets.TabIndex = 0
        Me.TabCajaActual_Tickets.Text = "Tickets"
        Me.TabCajaActual_Tickets.UseVisualStyleBackColor = True
        '
        'GridActual
        '
        Me.GridActual.AllowUserToAddRows = False
        Me.GridActual.AllowUserToDeleteRows = False
        Me.GridActual.AllowUserToOrderColumns = True
        Me.GridActual.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.GridActual.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GridActual.Location = New System.Drawing.Point(3, 3)
        Me.GridActual.Name = "GridActual"
        Me.GridActual.ReadOnly = True
        Me.GridActual.RowHeadersWidth = 35
        Me.GridActual.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.GridActual.Size = New System.Drawing.Size(686, 465)
        Me.GridActual.TabIndex = 13
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.Transparent
        Me.Panel2.Controls.Add(Me.Panel3)
        Me.Panel2.Controls.Add(Me.PnlInfo)
        Me.Panel2.Controls.Add(Me.BtFacturar)
        Me.Panel2.Controls.Add(Me.Label2)
        Me.Panel2.Controls.Add(Me.LblInfoCaja)
        Me.Panel2.Controls.Add(Me.BtCancell)
        Me.Panel2.Controls.Add(Me.BtPrintTicket)
        Me.Panel2.Controls.Add(Me.BtDelTicket)
        Me.Panel2.Controls.Add(Me.Label1)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Right
        Me.Panel2.Location = New System.Drawing.Point(689, 3)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(194, 465)
        Me.Panel2.TabIndex = 12
        '
        'Panel3
        '
        Me.Panel3.Controls.Add(Me.DtCajaActual_Hasta)
        Me.Panel3.Controls.Add(Label7)
        Me.Panel3.Controls.Add(Me.DtCajaActual_Desde)
        Me.Panel3.Controls.Add(Label8)
        Me.Panel3.Controls.Add(Me.Label9)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel3.Location = New System.Drawing.Point(0, 214)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(194, 121)
        Me.Panel3.TabIndex = 52
        '
        'DtCajaActual_Hasta
        '
        Me.DtCajaActual_Hasta.CalendarFont = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DtCajaActual_Hasta.CustomFormat = "dd/MM/yyyy"
        Me.DtCajaActual_Hasta.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DtCajaActual_Hasta.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DtCajaActual_Hasta.Location = New System.Drawing.Point(15, 87)
        Me.DtCajaActual_Hasta.Name = "DtCajaActual_Hasta"
        Me.DtCajaActual_Hasta.Size = New System.Drawing.Size(176, 27)
        Me.DtCajaActual_Hasta.TabIndex = 66
        Me.DtCajaActual_Hasta.Tag = "fh_venta"
        '
        'DtCajaActual_Desde
        '
        Me.DtCajaActual_Desde.CalendarFont = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DtCajaActual_Desde.CustomFormat = "dd/MM/yyyy"
        Me.DtCajaActual_Desde.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DtCajaActual_Desde.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DtCajaActual_Desde.Location = New System.Drawing.Point(15, 40)
        Me.DtCajaActual_Desde.Name = "DtCajaActual_Desde"
        Me.DtCajaActual_Desde.Size = New System.Drawing.Size(176, 27)
        Me.DtCajaActual_Desde.TabIndex = 64
        Me.DtCajaActual_Desde.Tag = "fh_venta"
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
        Me.Label9.Size = New System.Drawing.Size(194, 21)
        Me.Label9.TabIndex = 50
        Me.Label9.Text = "Filtro entre Fechas"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'PnlInfo
        '
        Me.PnlInfo.Controls.Add(Me.LblInfo)
        Me.PnlInfo.Controls.Add(Me.Label4)
        Me.PnlInfo.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PnlInfo.Location = New System.Drawing.Point(0, 335)
        Me.PnlInfo.Name = "PnlInfo"
        Me.PnlInfo.Size = New System.Drawing.Size(194, 42)
        Me.PnlInfo.TabIndex = 51
        Me.PnlInfo.Visible = False
        '
        'LblInfo
        '
        Me.LblInfo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LblInfo.Dock = System.Windows.Forms.DockStyle.Top
        Me.LblInfo.Font = New System.Drawing.Font("Arial", 8.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblInfo.Location = New System.Drawing.Point(0, 21)
        Me.LblInfo.Name = "LblInfo"
        Me.LblInfo.Padding = New System.Windows.Forms.Padding(3)
        Me.LblInfo.Size = New System.Drawing.Size(194, 23)
        Me.LblInfo.TabIndex = 53
        Me.LblInfo.Text = "Imposible Facturar de Caja Directa"
        Me.LblInfo.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.Color.LightSteelBlue
        Me.Label4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label4.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label4.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Image = CType(resources.GetObject("Label4.Image"), System.Drawing.Image)
        Me.Label4.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Label4.Location = New System.Drawing.Point(0, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(194, 21)
        Me.Label4.TabIndex = 52
        Me.Label4.Text = "Información"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'BtFacturar
        '
        Me.BtFacturar.BackColor = System.Drawing.SystemColors.Control
        Me.BtFacturar.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtFacturar.Image = CType(resources.GetObject("BtFacturar.Image"), System.Drawing.Image)
        Me.BtFacturar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtFacturar.Location = New System.Drawing.Point(3, 38)
        Me.BtFacturar.Name = "BtFacturar"
        Me.BtFacturar.Size = New System.Drawing.Size(188, 56)
        Me.BtFacturar.TabIndex = 48
        Me.BtFacturar.Tag = "facturar"
        Me.BtFacturar.Text = "Generar Factura"
        Me.BtFacturar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ToolTip.SetToolTip(Me.BtFacturar, "Generar Factura")
        Me.BtFacturar.UseVisualStyleBackColor = False
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.LightSteelBlue
        Me.Label2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Label2.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Image = CType(resources.GetObject("Label2.Image"), System.Drawing.Image)
        Me.Label2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Label2.Location = New System.Drawing.Point(0, 377)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(194, 21)
        Me.Label2.TabIndex = 47
        Me.Label2.Text = "Detalles"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'LblInfoCaja
        '
        Me.LblInfoCaja.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LblInfoCaja.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.LblInfoCaja.Font = New System.Drawing.Font("Arial", 6.75!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblInfoCaja.Location = New System.Drawing.Point(0, 398)
        Me.LblInfoCaja.Name = "LblInfoCaja"
        Me.LblInfoCaja.Padding = New System.Windows.Forms.Padding(3)
        Me.LblInfoCaja.Size = New System.Drawing.Size(194, 67)
        Me.LblInfoCaja.TabIndex = 46
        Me.LblInfoCaja.Text = "Label2"
        '
        'BtCancell
        '
        Me.BtCancell.BackColor = System.Drawing.SystemColors.Control
        Me.BtCancell.Enabled = False
        Me.BtCancell.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.BtCancell.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtCancell.Image = CType(resources.GetObject("BtCancell.Image"), System.Drawing.Image)
        Me.BtCancell.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtCancell.Location = New System.Drawing.Point(3, 101)
        Me.BtCancell.Name = "BtCancell"
        Me.BtCancell.Size = New System.Drawing.Size(188, 42)
        Me.BtCancell.TabIndex = 45
        Me.BtCancell.Tag = "CANCELATICKET"
        Me.BtCancell.Text = "Cancelar"
        Me.BtCancell.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ToolTip.SetToolTip(Me.BtCancell, "Cancelar el Ticket")
        Me.BtCancell.UseVisualStyleBackColor = False
        '
        'BtPrintTicket
        '
        Me.BtPrintTicket.BackColor = System.Drawing.SystemColors.Control
        Me.BtPrintTicket.Enabled = False
        Me.BtPrintTicket.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.BtPrintTicket.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtPrintTicket.Image = CType(resources.GetObject("BtPrintTicket.Image"), System.Drawing.Image)
        Me.BtPrintTicket.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtPrintTicket.Location = New System.Drawing.Point(98, 149)
        Me.BtPrintTicket.Name = "BtPrintTicket"
        Me.BtPrintTicket.Size = New System.Drawing.Size(93, 42)
        Me.BtPrintTicket.TabIndex = 43
        Me.BtPrintTicket.Tag = "PRINTTICKET"
        Me.BtPrintTicket.Text = "Imprimir"
        Me.BtPrintTicket.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BtPrintTicket.UseVisualStyleBackColor = False
        '
        'BtDelTicket
        '
        Me.BtDelTicket.BackColor = System.Drawing.SystemColors.Control
        Me.BtDelTicket.Enabled = False
        Me.BtDelTicket.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.BtDelTicket.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtDelTicket.Image = CType(resources.GetObject("BtDelTicket.Image"), System.Drawing.Image)
        Me.BtDelTicket.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtDelTicket.Location = New System.Drawing.Point(3, 149)
        Me.BtDelTicket.Name = "BtDelTicket"
        Me.BtDelTicket.Size = New System.Drawing.Size(93, 42)
        Me.BtDelTicket.TabIndex = 41
        Me.BtDelTicket.Tag = "DELETETICKET"
        Me.BtDelTicket.Text = "Eliminar"
        Me.BtDelTicket.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BtDelTicket.UseVisualStyleBackColor = False
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.LightSteelBlue
        Me.Label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label1.Font = New System.Drawing.Font("Verdana", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Image = CType(resources.GetObject("Label1.Image"), System.Drawing.Image)
        Me.Label1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Label1.Location = New System.Drawing.Point(0, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(194, 35)
        Me.Label1.TabIndex = 42
        Me.Label1.Text = "ACCIONES"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'TabCajaActual_Pedidos
        '
        Me.TabCajaActual_Pedidos.Controls.Add(Me.gridPedidos)
        Me.TabCajaActual_Pedidos.Location = New System.Drawing.Point(4, 22)
        Me.TabCajaActual_Pedidos.Name = "TabCajaActual_Pedidos"
        Me.TabCajaActual_Pedidos.Padding = New System.Windows.Forms.Padding(3)
        Me.TabCajaActual_Pedidos.Size = New System.Drawing.Size(886, 471)
        Me.TabCajaActual_Pedidos.TabIndex = 1
        Me.TabCajaActual_Pedidos.Text = "Pedidos"
        Me.TabCajaActual_Pedidos.UseVisualStyleBackColor = True
        '
        'gridPedidos
        '
        Me.gridPedidos.AllowUserToAddRows = False
        Me.gridPedidos.AllowUserToDeleteRows = False
        Me.gridPedidos.AllowUserToOrderColumns = True
        Me.gridPedidos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.gridPedidos.Dock = System.Windows.Forms.DockStyle.Fill
        Me.gridPedidos.Location = New System.Drawing.Point(3, 3)
        Me.gridPedidos.Name = "gridPedidos"
        Me.gridPedidos.ReadOnly = True
        Me.gridPedidos.RowHeadersWidth = 35
        Me.gridPedidos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.gridPedidos.Size = New System.Drawing.Size(880, 465)
        Me.gridPedidos.TabIndex = 14
        '
        'TabCajaActual_Marcas
        '
        Me.TabCajaActual_Marcas.Controls.Add(Me.gridMarcas)
        Me.TabCajaActual_Marcas.Controls.Add(Me.Label10)
        Me.TabCajaActual_Marcas.Location = New System.Drawing.Point(4, 22)
        Me.TabCajaActual_Marcas.Name = "TabCajaActual_Marcas"
        Me.TabCajaActual_Marcas.Size = New System.Drawing.Size(886, 471)
        Me.TabCajaActual_Marcas.TabIndex = 2
        Me.TabCajaActual_Marcas.Text = "Marcas de Estanco"
        Me.TabCajaActual_Marcas.UseVisualStyleBackColor = True
        '
        'gridMarcas
        '
        Me.gridMarcas.AllowUserToAddRows = False
        Me.gridMarcas.AllowUserToDeleteRows = False
        Me.gridMarcas.AllowUserToOrderColumns = True
        Me.gridMarcas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.gridMarcas.Dock = System.Windows.Forms.DockStyle.Fill
        Me.gridMarcas.Location = New System.Drawing.Point(0, 29)
        Me.gridMarcas.Name = "gridMarcas"
        Me.gridMarcas.ReadOnly = True
        Me.gridMarcas.RowHeadersWidth = 35
        Me.gridMarcas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.gridMarcas.Size = New System.Drawing.Size(886, 442)
        Me.gridMarcas.TabIndex = 15
        '
        'Label10
        '
        Me.Label10.BackColor = System.Drawing.Color.LightSteelBlue
        Me.Label10.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label10.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label10.Font = New System.Drawing.Font("Verdana", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Image = CType(resources.GetObject("Label10.Image"), System.Drawing.Image)
        Me.Label10.ImageAlign = System.Drawing.ContentAlignment.TopLeft
        Me.Label10.Location = New System.Drawing.Point(0, 0)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(886, 29)
        Me.Label10.TabIndex = 46
        Me.Label10.Text = "LISTA DE MARCAS MAS VENDIDAS"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'TabPage_HistoricoCajas
        '
        Me.TabPage_HistoricoCajas.Controls.Add(Me.Panel1)
        Me.TabPage_HistoricoCajas.Controls.Add(Me.GridHistorico)
        Me.TabPage_HistoricoCajas.ImageIndex = 0
        Me.TabPage_HistoricoCajas.Location = New System.Drawing.Point(4, 23)
        Me.TabPage_HistoricoCajas.Name = "TabPage_HistoricoCajas"
        Me.TabPage_HistoricoCajas.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage_HistoricoCajas.Size = New System.Drawing.Size(900, 503)
        Me.TabPage_HistoricoCajas.TabIndex = 0
        Me.TabPage_HistoricoCajas.Text = "Histórico de Cajas"
        Me.TabPage_HistoricoCajas.UseVisualStyleBackColor = True
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.Transparent
        Me.Panel1.Controls.Add(Me.Button1)
        Me.Panel1.Controls.Add(Me.BtPrintOldTicket_ALL)
        Me.Panel1.Controls.Add(Me.BtShowCaja)
        Me.Panel1.Controls.Add(Me.PnlFilter)
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Controls.Add(Me.LblInfoCajas)
        Me.Panel1.Controls.Add(Me.BtPrintCaja)
        Me.Panel1.Controls.Add(Me.BtDelCaja)
        Me.Panel1.Controls.Add(Me.LblDaySelect)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Right
        Me.Panel1.Location = New System.Drawing.Point(703, 3)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(194, 497)
        Me.Panel1.TabIndex = 11
        '
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.SystemColors.Control
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.Button1.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.Image = CType(resources.GetObject("Button1.Image"), System.Drawing.Image)
        Me.Button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Button1.Location = New System.Drawing.Point(92, 205)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(99, 42)
        Me.Button1.TabIndex = 54
        Me.Button1.Tag = "RECALCULAR_CAJA"
        Me.Button1.Text = "Recalcular Caja"
        Me.Button1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Button1.UseVisualStyleBackColor = False
        Me.Button1.Visible = False
        '
        'BtPrintOldTicket_ALL
        '
        Me.BtPrintOldTicket_ALL.BackColor = System.Drawing.SystemColors.Control
        Me.BtPrintOldTicket_ALL.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.BtPrintOldTicket_ALL.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtPrintOldTicket_ALL.Image = CType(resources.GetObject("BtPrintOldTicket_ALL.Image"), System.Drawing.Image)
        Me.BtPrintOldTicket_ALL.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtPrintOldTicket_ALL.Location = New System.Drawing.Point(3, 205)
        Me.BtPrintOldTicket_ALL.Name = "BtPrintOldTicket_ALL"
        Me.BtPrintOldTicket_ALL.Size = New System.Drawing.Size(83, 69)
        Me.BtPrintOldTicket_ALL.TabIndex = 53
        Me.BtPrintOldTicket_ALL.Tag = "PRINTTICKET_ALL"
        Me.BtPrintOldTicket_ALL.Text = "Imprimir Todos los Ticket"
        Me.BtPrintOldTicket_ALL.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BtPrintOldTicket_ALL.UseVisualStyleBackColor = False
        '
        'BtShowCaja
        '
        Me.BtShowCaja.BackColor = System.Drawing.SystemColors.Control
        Me.BtShowCaja.Enabled = False
        Me.BtShowCaja.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtShowCaja.Image = CType(resources.GetObject("BtShowCaja.Image"), System.Drawing.Image)
        Me.BtShowCaja.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtShowCaja.Location = New System.Drawing.Point(3, 148)
        Me.BtShowCaja.Name = "BtShowCaja"
        Me.BtShowCaja.Size = New System.Drawing.Size(188, 42)
        Me.BtShowCaja.TabIndex = 52
        Me.BtShowCaja.Tag = "VER_CAJA"
        Me.BtShowCaja.Text = "Mostrar Detalles de Caja"
        Me.BtShowCaja.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BtShowCaja.UseVisualStyleBackColor = False
        '
        'PnlFilter
        '
        Me.PnlFilter.Controls.Add(Me.DtFh_Hasta)
        Me.PnlFilter.Controls.Add(Label6)
        Me.PnlFilter.Controls.Add(Me.DtFh_Desde)
        Me.PnlFilter.Controls.Add(LblNfoFhAlta)
        Me.PnlFilter.Controls.Add(Me.Label5)
        Me.PnlFilter.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PnlFilter.Location = New System.Drawing.Point(0, 280)
        Me.PnlFilter.Name = "PnlFilter"
        Me.PnlFilter.Size = New System.Drawing.Size(194, 130)
        Me.PnlFilter.TabIndex = 50
        '
        'DtFh_Hasta
        '
        Me.DtFh_Hasta.CalendarFont = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DtFh_Hasta.CustomFormat = "dd/MM/yyyy"
        Me.DtFh_Hasta.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DtFh_Hasta.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DtFh_Hasta.Location = New System.Drawing.Point(15, 87)
        Me.DtFh_Hasta.Name = "DtFh_Hasta"
        Me.DtFh_Hasta.Size = New System.Drawing.Size(176, 27)
        Me.DtFh_Hasta.TabIndex = 66
        Me.DtFh_Hasta.Tag = "fh_venta"
        '
        'DtFh_Desde
        '
        Me.DtFh_Desde.CalendarFont = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DtFh_Desde.CustomFormat = "dd/MM/yyyy"
        Me.DtFh_Desde.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DtFh_Desde.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DtFh_Desde.Location = New System.Drawing.Point(15, 40)
        Me.DtFh_Desde.Name = "DtFh_Desde"
        Me.DtFh_Desde.Size = New System.Drawing.Size(176, 27)
        Me.DtFh_Desde.TabIndex = 64
        Me.DtFh_Desde.Tag = "fh_venta"
        '
        'Label5
        '
        Me.Label5.BackColor = System.Drawing.Color.LightSteelBlue
        Me.Label5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label5.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label5.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Image = CType(resources.GetObject("Label5.Image"), System.Drawing.Image)
        Me.Label5.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Label5.Location = New System.Drawing.Point(0, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(194, 21)
        Me.Label5.TabIndex = 50
        Me.Label5.Text = "Filtro entre Fechas"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
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
        'LblInfoCajas
        '
        Me.LblInfoCajas.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LblInfoCajas.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.LblInfoCajas.Font = New System.Drawing.Font("Arial", 6.75!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblInfoCajas.Location = New System.Drawing.Point(0, 431)
        Me.LblInfoCajas.Name = "LblInfoCajas"
        Me.LblInfoCajas.Padding = New System.Windows.Forms.Padding(3)
        Me.LblInfoCajas.Size = New System.Drawing.Size(194, 66)
        Me.LblInfoCajas.TabIndex = 48
        Me.LblInfoCajas.Text = "Label2"
        '
        'BtPrintCaja
        '
        Me.BtPrintCaja.BackColor = System.Drawing.SystemColors.Control
        Me.BtPrintCaja.Enabled = False
        Me.BtPrintCaja.Font = New System.Drawing.Font("Tahoma", 11.25!)
        Me.BtPrintCaja.Image = CType(resources.GetObject("BtPrintCaja.Image"), System.Drawing.Image)
        Me.BtPrintCaja.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtPrintCaja.Location = New System.Drawing.Point(3, 38)
        Me.BtPrintCaja.Name = "BtPrintCaja"
        Me.BtPrintCaja.Size = New System.Drawing.Size(188, 56)
        Me.BtPrintCaja.TabIndex = 43
        Me.BtPrintCaja.Tag = "PRINTCAJA"
        Me.BtPrintCaja.Text = "Imprimir Resumen"
        Me.BtPrintCaja.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BtPrintCaja.UseVisualStyleBackColor = False
        '
        'BtDelCaja
        '
        Me.BtDelCaja.BackColor = System.Drawing.SystemColors.Control
        Me.BtDelCaja.Enabled = False
        Me.BtDelCaja.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtDelCaja.Image = CType(resources.GetObject("BtDelCaja.Image"), System.Drawing.Image)
        Me.BtDelCaja.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtDelCaja.Location = New System.Drawing.Point(3, 100)
        Me.BtDelCaja.Name = "BtDelCaja"
        Me.BtDelCaja.Size = New System.Drawing.Size(188, 42)
        Me.BtDelCaja.TabIndex = 41
        Me.BtDelCaja.Tag = "DELETECAJA"
        Me.BtDelCaja.Text = "Eliminar Caja"
        Me.BtDelCaja.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BtDelCaja.UseVisualStyleBackColor = False
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
        'GridHistorico
        '
        Me.GridHistorico.AllowUserToAddRows = False
        Me.GridHistorico.AllowUserToDeleteRows = False
        Me.GridHistorico.AllowUserToOrderColumns = True
        Me.GridHistorico.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.GridHistorico.Location = New System.Drawing.Point(3, 6)
        Me.GridHistorico.Name = "GridHistorico"
        Me.GridHistorico.ReadOnly = True
        Me.GridHistorico.RowHeadersWidth = 35
        Me.GridHistorico.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.GridHistorico.Size = New System.Drawing.Size(694, 491)
        Me.GridHistorico.TabIndex = 10
        '
        'TabPage_MuestraCaja
        '
        Me.TabPage_MuestraCaja.Controls.Add(Me.GridCajaClosed)
        Me.TabPage_MuestraCaja.Controls.Add(Me.Panel4)
        Me.TabPage_MuestraCaja.ImageIndex = 1
        Me.TabPage_MuestraCaja.Location = New System.Drawing.Point(4, 23)
        Me.TabPage_MuestraCaja.Name = "TabPage_MuestraCaja"
        Me.TabPage_MuestraCaja.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage_MuestraCaja.Size = New System.Drawing.Size(900, 503)
        Me.TabPage_MuestraCaja.TabIndex = 2
        Me.TabPage_MuestraCaja.Text = "Caja >>"
        Me.TabPage_MuestraCaja.UseVisualStyleBackColor = True
        '
        'GridCajaClosed
        '
        Me.GridCajaClosed.AllowUserToAddRows = False
        Me.GridCajaClosed.AllowUserToDeleteRows = False
        Me.GridCajaClosed.AllowUserToOrderColumns = True
        Me.GridCajaClosed.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.GridCajaClosed.Location = New System.Drawing.Point(3, 6)
        Me.GridCajaClosed.Name = "GridCajaClosed"
        Me.GridCajaClosed.ReadOnly = True
        Me.GridCajaClosed.RowHeadersWidth = 35
        Me.GridCajaClosed.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.GridCajaClosed.Size = New System.Drawing.Size(694, 491)
        Me.GridCajaClosed.TabIndex = 14
        '
        'Panel4
        '
        Me.Panel4.BackColor = System.Drawing.Color.Transparent
        Me.Panel4.Controls.Add(Me.lblTOTAL_nCajaNew)
        Me.Panel4.Controls.Add(Me.lblTOTAL_nCaja)
        Me.Panel4.Controls.Add(Me.lblTOTAL_Caja)
        Me.Panel4.Controls.Add(Me.lblTOTAL_CajaNew)
        Me.Panel4.Controls.Add(Me.BtReload)
        Me.Panel4.Controls.Add(Me.btOld_Facturar)
        Me.Panel4.Controls.Add(Me.Label15)
        Me.Panel4.Controls.Add(Me.LstLines)
        Me.Panel4.Controls.Add(Me.BtCancellOld)
        Me.Panel4.Controls.Add(Me.BtPrintOldTicket)
        Me.Panel4.Controls.Add(Me.BtDelOldTicket)
        Me.Panel4.Controls.Add(Me.Label17)
        Me.Panel4.Dock = System.Windows.Forms.DockStyle.Right
        Me.Panel4.Location = New System.Drawing.Point(703, 3)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(194, 497)
        Me.Panel4.TabIndex = 13
        '
        'lblTOTAL_nCajaNew
        '
        Me.lblTOTAL_nCajaNew.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTOTAL_nCajaNew.Location = New System.Drawing.Point(116, 250)
        Me.lblTOTAL_nCajaNew.Name = "lblTOTAL_nCajaNew"
        Me.lblTOTAL_nCajaNew.Size = New System.Drawing.Size(72, 16)
        Me.lblTOTAL_nCajaNew.TabIndex = 57
        Me.lblTOTAL_nCajaNew.Text = "0,00"
        Me.lblTOTAL_nCajaNew.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'lblTOTAL_nCaja
        '
        Me.lblTOTAL_nCaja.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTOTAL_nCaja.Location = New System.Drawing.Point(116, 206)
        Me.lblTOTAL_nCaja.Name = "lblTOTAL_nCaja"
        Me.lblTOTAL_nCaja.Size = New System.Drawing.Size(72, 16)
        Me.lblTOTAL_nCaja.TabIndex = 56
        Me.lblTOTAL_nCaja.Text = "0,00"
        Me.lblTOTAL_nCaja.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'lblTOTAL_Caja
        '
        Me.lblTOTAL_Caja.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTOTAL_Caja.Location = New System.Drawing.Point(119, 222)
        Me.lblTOTAL_Caja.Name = "lblTOTAL_Caja"
        Me.lblTOTAL_Caja.Size = New System.Drawing.Size(72, 22)
        Me.lblTOTAL_Caja.TabIndex = 55
        Me.lblTOTAL_Caja.Text = "0,00"
        '
        'lblTOTAL_CajaNew
        '
        Me.lblTOTAL_CajaNew.Font = New System.Drawing.Font("Tahoma", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTOTAL_CajaNew.Location = New System.Drawing.Point(94, 266)
        Me.lblTOTAL_CajaNew.Name = "lblTOTAL_CajaNew"
        Me.lblTOTAL_CajaNew.Size = New System.Drawing.Size(94, 30)
        Me.lblTOTAL_CajaNew.TabIndex = 54
        Me.lblTOTAL_CajaNew.Text = "0,00"
        '
        'BtReload
        '
        Me.BtReload.BackColor = System.Drawing.SystemColors.Control
        Me.BtReload.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.BtReload.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtReload.Image = CType(resources.GetObject("BtReload.Image"), System.Drawing.Image)
        Me.BtReload.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtReload.Location = New System.Drawing.Point(92, 143)
        Me.BtReload.Name = "BtReload"
        Me.BtReload.Size = New System.Drawing.Size(99, 42)
        Me.BtReload.TabIndex = 53
        Me.BtReload.Tag = "RECALCULAR_CAJA"
        Me.BtReload.Text = "Recalcular Caja"
        Me.BtReload.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BtReload.UseVisualStyleBackColor = False
        '
        'btOld_Facturar
        '
        Me.btOld_Facturar.BackColor = System.Drawing.SystemColors.Control
        Me.btOld_Facturar.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btOld_Facturar.Image = CType(resources.GetObject("btOld_Facturar.Image"), System.Drawing.Image)
        Me.btOld_Facturar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btOld_Facturar.Location = New System.Drawing.Point(3, 243)
        Me.btOld_Facturar.Name = "btOld_Facturar"
        Me.btOld_Facturar.Size = New System.Drawing.Size(72, 56)
        Me.btOld_Facturar.TabIndex = 51
        Me.btOld_Facturar.Tag = "facturar"
        Me.btOld_Facturar.Text = "Generar Factura"
        Me.btOld_Facturar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ToolTip.SetToolTip(Me.btOld_Facturar, "Generar Factura")
        Me.btOld_Facturar.UseVisualStyleBackColor = False
        '
        'Label15
        '
        Me.Label15.BackColor = System.Drawing.Color.LightSteelBlue
        Me.Label15.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label15.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Label15.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.Image = CType(resources.GetObject("Label15.Image"), System.Drawing.Image)
        Me.Label15.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Label15.Location = New System.Drawing.Point(0, 302)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(194, 21)
        Me.Label15.TabIndex = 50
        Me.Label15.Text = "Detalles"
        Me.Label15.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'LstLines
        '
        Me.LstLines.BackColor = System.Drawing.Color.Beige
        Me.LstLines.CheckBoxes = True
        Me.LstLines.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.LstLines.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LstLines.FullRowSelect = True
        Me.LstLines.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable
        Me.LstLines.HideSelection = False
        Me.LstLines.Location = New System.Drawing.Point(0, 323)
        Me.LstLines.MultiSelect = False
        Me.LstLines.Name = "LstLines"
        Me.LstLines.Size = New System.Drawing.Size(194, 174)
        Me.LstLines.TabIndex = 49
        Me.LstLines.UseCompatibleStateImageBehavior = False
        Me.LstLines.View = System.Windows.Forms.View.Details
        '
        'BtCancellOld
        '
        Me.BtCancellOld.BackColor = System.Drawing.SystemColors.Control
        Me.BtCancellOld.Enabled = False
        Me.BtCancellOld.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtCancellOld.Image = CType(resources.GetObject("BtCancellOld.Image"), System.Drawing.Image)
        Me.BtCancellOld.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtCancellOld.Location = New System.Drawing.Point(3, 38)
        Me.BtCancellOld.Name = "BtCancellOld"
        Me.BtCancellOld.Size = New System.Drawing.Size(188, 51)
        Me.BtCancellOld.TabIndex = 48
        Me.BtCancellOld.Tag = "CLOSEOLD"
        Me.BtCancellOld.Text = "Cancelar"
        Me.BtCancellOld.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BtCancellOld.UseVisualStyleBackColor = False
        '
        'BtPrintOldTicket
        '
        Me.BtPrintOldTicket.BackColor = System.Drawing.SystemColors.Control
        Me.BtPrintOldTicket.Enabled = False
        Me.BtPrintOldTicket.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.BtPrintOldTicket.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtPrintOldTicket.Image = CType(resources.GetObject("BtPrintOldTicket.Image"), System.Drawing.Image)
        Me.BtPrintOldTicket.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtPrintOldTicket.Location = New System.Drawing.Point(3, 95)
        Me.BtPrintOldTicket.Name = "BtPrintOldTicket"
        Me.BtPrintOldTicket.Size = New System.Drawing.Size(188, 42)
        Me.BtPrintOldTicket.TabIndex = 43
        Me.BtPrintOldTicket.Tag = "PRINTTICKET_CLOSED"
        Me.BtPrintOldTicket.Text = "Imprimir Ticket"
        Me.BtPrintOldTicket.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BtPrintOldTicket.UseVisualStyleBackColor = False
        '
        'BtDelOldTicket
        '
        Me.BtDelOldTicket.BackColor = System.Drawing.SystemColors.Control
        Me.BtDelOldTicket.Enabled = False
        Me.BtDelOldTicket.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.BtDelOldTicket.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtDelOldTicket.Image = CType(resources.GetObject("BtDelOldTicket.Image"), System.Drawing.Image)
        Me.BtDelOldTicket.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtDelOldTicket.Location = New System.Drawing.Point(3, 143)
        Me.BtDelOldTicket.Name = "BtDelOldTicket"
        Me.BtDelOldTicket.Size = New System.Drawing.Size(83, 42)
        Me.BtDelOldTicket.TabIndex = 41
        Me.BtDelOldTicket.Tag = "DELETETICKET_CLOSED"
        Me.BtDelOldTicket.Text = "Eliminar Ticket"
        Me.BtDelOldTicket.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BtDelOldTicket.UseVisualStyleBackColor = False
        '
        'Label17
        '
        Me.Label17.BackColor = System.Drawing.Color.LightSteelBlue
        Me.Label17.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label17.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label17.Font = New System.Drawing.Font("Verdana", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.Image = CType(resources.GetObject("Label17.Image"), System.Drawing.Image)
        Me.Label17.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Label17.Location = New System.Drawing.Point(0, 0)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(194, 35)
        Me.Label17.TabIndex = 42
        Me.Label17.Text = "ACCIONES"
        Me.Label17.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'ImageList
        '
        Me.ImageList.ImageStream = CType(resources.GetObject("ImageList.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageList.Images.SetKeyName(0, "history.png")
        Me.ImageList.Images.SetKeyName(1, "calculator.png")
        '
        'BtCloseBox
        '
        Me.BtCloseBox.BackColor = System.Drawing.SystemColors.Control
        Me.BtCloseBox.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtCloseBox.Image = CType(resources.GetObject("BtCloseBox.Image"), System.Drawing.Image)
        Me.BtCloseBox.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtCloseBox.Location = New System.Drawing.Point(715, 28)
        Me.BtCloseBox.Name = "BtCloseBox"
        Me.BtCloseBox.Size = New System.Drawing.Size(188, 56)
        Me.BtCloseBox.TabIndex = 44
        Me.BtCloseBox.Tag = "cerrarcaja"
        Me.BtCloseBox.Text = "Cerrar Caja Actual"
        Me.BtCloseBox.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ToolTip.SetToolTip(Me.BtCloseBox, "Cerrar Caja Actual")
        Me.BtCloseBox.UseVisualStyleBackColor = False
        Me.BtCloseBox.Visible = False
        '
        'ImageList_day
        '
        Me.ImageList_day.ImageStream = CType(resources.GetObject("ImageList_day.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList_day.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageList_day.Images.SetKeyName(0, "note.png")
        '
        'frmCajas
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Black
        Me.ClientSize = New System.Drawing.Size(1020, 770)
        Me.Controls.Add(Me.SplitContainer)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "frmCajas"
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
        Me.TabPage_CajaActual.ResumeLayout(False)
        Me.TabCajaActual.ResumeLayout(False)
        Me.TabCajaActual_Tickets.ResumeLayout(False)
        CType(Me.GridActual, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel2.ResumeLayout(False)
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        Me.PnlInfo.ResumeLayout(False)
        Me.TabCajaActual_Pedidos.ResumeLayout(False)
        CType(Me.gridPedidos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabCajaActual_Marcas.ResumeLayout(False)
        CType(Me.gridMarcas, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage_HistoricoCajas.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.PnlFilter.ResumeLayout(False)
        Me.PnlFilter.PerformLayout()
        CType(Me.GridHistorico, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage_MuestraCaja.ResumeLayout(False)
        CType(Me.GridCajaClosed, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel4.ResumeLayout(False)
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
    Friend WithEvents GridHistorico As System.Windows.Forms.DataGridView
    Friend WithEvents BtCerrarCaja As System.Windows.Forms.Button
    Friend WithEvents LblMonth As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents BtDelCaja As System.Windows.Forms.Button
    Friend WithEvents LblDaySelect As System.Windows.Forms.Label
    Friend WithEvents BtPrintCaja As System.Windows.Forms.Button
    Friend WithEvents BtCloseBox As System.Windows.Forms.Button
    Friend WithEvents Tab As System.Windows.Forms.TabControl
    Friend WithEvents TabPage_HistoricoCajas As System.Windows.Forms.TabPage
    Friend WithEvents TabPage_CajaActual As System.Windows.Forms.TabPage
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents BtPrintTicket As System.Windows.Forms.Button
    Friend WithEvents BtDelTicket As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents GridActual As System.Windows.Forms.DataGridView
    Friend WithEvents BtCancell As System.Windows.Forms.Button
    Friend WithEvents LblInfoCaja As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents LblInfoCajas As System.Windows.Forms.Label
    Friend WithEvents BtFacturar As System.Windows.Forms.Button
    Friend WithEvents PnlInfo As System.Windows.Forms.Panel
    Friend WithEvents LblInfo As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents PnlFilter As System.Windows.Forms.Panel
    Friend WithEvents DtFh_Hasta As System.Windows.Forms.DateTimePicker
    Friend WithEvents DtFh_Desde As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents TabPage_MuestraCaja As System.Windows.Forms.TabPage
    Friend WithEvents BtShowCaja As System.Windows.Forms.Button
    Friend WithEvents GridCajaClosed As System.Windows.Forms.DataGridView
    Friend WithEvents Panel4 As System.Windows.Forms.Panel
    Friend WithEvents BtPrintOldTicket As System.Windows.Forms.Button
    Friend WithEvents BtDelOldTicket As System.Windows.Forms.Button
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents BtCancellOld As System.Windows.Forms.Button
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents LstLines As System.Windows.Forms.ListView
    Friend WithEvents TabCajaActual As System.Windows.Forms.TabControl
    Friend WithEvents TabCajaActual_Tickets As System.Windows.Forms.TabPage
    Friend WithEvents TabCajaActual_Pedidos As System.Windows.Forms.TabPage
    Friend WithEvents gridPedidos As System.Windows.Forms.DataGridView
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents DtCajaActual_Hasta As System.Windows.Forms.DateTimePicker
    Friend WithEvents DtCajaActual_Desde As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents TabCajaActual_Marcas As System.Windows.Forms.TabPage
    Friend WithEvents gridMarcas As System.Windows.Forms.DataGridView
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents btOld_Facturar As System.Windows.Forms.Button
    Friend WithEvents BtReload As System.Windows.Forms.Button
    Friend WithEvents lblTOTAL_CajaNew As System.Windows.Forms.Label
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents BtPrintOldTicket_ALL As System.Windows.Forms.Button
    Friend WithEvents lblTOTAL_Caja As System.Windows.Forms.Label
    Friend WithEvents lblTOTAL_nCaja As System.Windows.Forms.Label
    Friend WithEvents lblTOTAL_nCajaNew As System.Windows.Forms.Label
End Class
