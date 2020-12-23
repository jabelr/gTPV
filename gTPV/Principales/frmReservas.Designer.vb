<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmReservas
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
        Dim LblReservas_Tot As System.Windows.Forms.Label
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmReservas))
        Dim GroupBox1 As System.Windows.Forms.GroupBox
        Dim Label13 As System.Windows.Forms.Label
        Dim Label14 As System.Windows.Forms.Label
        Me.Button2 = New System.Windows.Forms.Button()
        Me.BtGenerateTicket = New System.Windows.Forms.Button()
        Me.BtPrintMenu = New System.Windows.Forms.Button()
        Me.SplitContainer = New System.Windows.Forms.SplitContainer()
        Me.m_logo = New System.Windows.Forms.PictureBox()
        Me.PnlButton_Shell = New System.Windows.Forms.Panel()
        Me.BtClose = New System.Windows.Forms.Button()
        Me.BtGoToNow = New System.Windows.Forms.Button()
        Me.LblSubTitle = New System.Windows.Forms.Label()
        Me.LblTitle = New System.Windows.Forms.Label()
        Me.PnlBody = New System.Windows.Forms.Panel()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.PnlAgenda = New System.Windows.Forms.Panel()
        Me.GroupEdit = New System.Windows.Forms.GroupBox()
        Me.BtNew = New System.Windows.Forms.Button()
        Me.BtDell = New System.Windows.Forms.Button()
        Me.BtEdit = New System.Windows.Forms.Button()
        Me.LstEventos = New System.Windows.Forms.ListView()
        Me.LblDaySelect = New System.Windows.Forms.Label()
        Me.LblName = New System.Windows.Forms.Label()
        Me.PnlFilters = New System.Windows.Forms.Panel()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.ChkShow_Notas = New System.Windows.Forms.CheckBox()
        Me.ImageList = New System.Windows.Forms.ImageList(Me.components)
        Me.ChkShow_Reservas = New System.Windows.Forms.CheckBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.LblMonth = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.PnlAction_Buttons = New System.Windows.Forms.Panel()
        Me.BtMonth_Next = New System.Windows.Forms.Button()
        Me.BtMonth_Previous = New System.Windows.Forms.Button()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.PnlDays = New System.Windows.Forms.Panel()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.gridReservas = New System.Windows.Forms.DataGridView()
        Me.PnlButtons_Controls = New System.Windows.Forms.Panel()
        Me.DtCajaActual_Hasta = New System.Windows.Forms.DateTimePicker()
        Me.DtReservas_Desde = New System.Windows.Forms.DateTimePicker()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.txtFilter_tlf = New System.Windows.Forms.TextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.TxtFilter_name = New System.Windows.Forms.TextBox()
        Me.BtFilter = New System.Windows.Forms.Button()
        Me.ToolTip = New System.Windows.Forms.ToolTip(Me.components)
        Me.ImageList_day = New System.Windows.Forms.ImageList(Me.components)
        LblReservas_Tot = New System.Windows.Forms.Label()
        GroupBox1 = New System.Windows.Forms.GroupBox()
        Label13 = New System.Windows.Forms.Label()
        Label14 = New System.Windows.Forms.Label()
        GroupBox1.SuspendLayout()
        Me.SplitContainer.Panel1.SuspendLayout()
        Me.SplitContainer.Panel2.SuspendLayout()
        Me.SplitContainer.SuspendLayout()
        CType(Me.m_logo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PnlButton_Shell.SuspendLayout()
        Me.PnlBody.SuspendLayout()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.PnlAgenda.SuspendLayout()
        Me.GroupEdit.SuspendLayout()
        Me.PnlFilters.SuspendLayout()
        Me.PnlAction_Buttons.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        CType(Me.gridReservas, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PnlButtons_Controls.SuspendLayout()
        Me.SuspendLayout()
        '
        'LblReservas_Tot
        '
        LblReservas_Tot.BackColor = System.Drawing.Color.LightSteelBlue
        LblReservas_Tot.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        LblReservas_Tot.Dock = System.Windows.Forms.DockStyle.Bottom
        LblReservas_Tot.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        LblReservas_Tot.Image = CType(resources.GetObject("LblReservas_Tot.Image"), System.Drawing.Image)
        LblReservas_Tot.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        LblReservas_Tot.Location = New System.Drawing.Point(0, 229)
        LblReservas_Tot.Name = "LblReservas_Tot"
        LblReservas_Tot.Size = New System.Drawing.Size(319, 22)
        LblReservas_Tot.TabIndex = 44
        LblReservas_Tot.Text = "RESERVAS ACTUALES"
        LblReservas_Tot.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'GroupBox1
        '
        GroupBox1.Controls.Add(Me.Button2)
        GroupBox1.Controls.Add(Me.BtGenerateTicket)
        GroupBox1.Controls.Add(Me.BtPrintMenu)
        GroupBox1.ForeColor = System.Drawing.SystemColors.InactiveCaptionText
        GroupBox1.Location = New System.Drawing.Point(3, 145)
        GroupBox1.Name = "GroupBox1"
        GroupBox1.Size = New System.Drawing.Size(313, 84)
        GroupBox1.TabIndex = 45
        GroupBox1.TabStop = False
        GroupBox1.Text = "Opciones de Impresión"
        '
        'Button2
        '
        Me.Button2.BackColor = System.Drawing.SystemColors.Control
        Me.Button2.Enabled = False
        Me.Button2.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button2.ForeColor = System.Drawing.Color.Black
        Me.Button2.Image = CType(resources.GetObject("Button2.Image"), System.Drawing.Image)
        Me.Button2.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.Button2.Location = New System.Drawing.Point(207, 18)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(100, 61)
        Me.Button2.TabIndex = 19
        Me.Button2.Tag = ""
        Me.Button2.Text = "Generar" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Hoja de Reservas"
        Me.Button2.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Button2.UseVisualStyleBackColor = False
        Me.Button2.Visible = False
        '
        'BtGenerateTicket
        '
        Me.BtGenerateTicket.BackColor = System.Drawing.SystemColors.Control
        Me.BtGenerateTicket.Enabled = False
        Me.BtGenerateTicket.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtGenerateTicket.ForeColor = System.Drawing.Color.Black
        Me.BtGenerateTicket.Image = CType(resources.GetObject("BtGenerateTicket.Image"), System.Drawing.Image)
        Me.BtGenerateTicket.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.BtGenerateTicket.Location = New System.Drawing.Point(107, 18)
        Me.BtGenerateTicket.Name = "BtGenerateTicket"
        Me.BtGenerateTicket.Size = New System.Drawing.Size(100, 61)
        Me.BtGenerateTicket.TabIndex = 18
        Me.BtGenerateTicket.Tag = "TICKET"
        Me.BtGenerateTicket.Text = "Imprimir Resumen"
        Me.BtGenerateTicket.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.BtGenerateTicket.UseVisualStyleBackColor = False
        '
        'BtPrintMenu
        '
        Me.BtPrintMenu.BackColor = System.Drawing.SystemColors.Control
        Me.BtPrintMenu.Enabled = False
        Me.BtPrintMenu.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtPrintMenu.ForeColor = System.Drawing.Color.Black
        Me.BtPrintMenu.Image = CType(resources.GetObject("BtPrintMenu.Image"), System.Drawing.Image)
        Me.BtPrintMenu.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.BtPrintMenu.Location = New System.Drawing.Point(7, 18)
        Me.BtPrintMenu.Name = "BtPrintMenu"
        Me.BtPrintMenu.Size = New System.Drawing.Size(100, 61)
        Me.BtPrintMenu.TabIndex = 17
        Me.BtPrintMenu.Tag = "REPORT"
        Me.BtPrintMenu.Text = "Generar" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Hoja de Reservas"
        Me.BtPrintMenu.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.BtPrintMenu.UseVisualStyleBackColor = False
        '
        'Label13
        '
        Label13.AutoSize = True
        Label13.Font = New System.Drawing.Font("Tahoma", 6.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Label13.Location = New System.Drawing.Point(404, 71)
        Label13.Name = "Label13"
        Label13.Size = New System.Drawing.Size(29, 10)
        Label13.TabIndex = 69
        Label13.Text = "HASTA"
        Label13.Visible = False
        '
        'Label14
        '
        Label14.AutoSize = True
        Label14.Font = New System.Drawing.Font("Tahoma", 6.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Label14.Location = New System.Drawing.Point(212, 71)
        Label14.Name = "Label14"
        Label14.Size = New System.Drawing.Size(27, 10)
        Label14.TabIndex = 67
        Label14.Text = "DESDE"
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
        Me.PnlButton_Shell.Controls.Add(Me.BtGoToNow)
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
        'BtGoToNow
        '
        Me.BtGoToNow.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.BtGoToNow.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtGoToNow.Image = CType(resources.GetObject("BtGoToNow.Image"), System.Drawing.Image)
        Me.BtGoToNow.Location = New System.Drawing.Point(192, 4)
        Me.BtGoToNow.Name = "BtGoToNow"
        Me.BtGoToNow.Size = New System.Drawing.Size(170, 58)
        Me.BtGoToNow.TabIndex = 6
        Me.BtGoToNow.Tag = "now"
        Me.BtGoToNow.Text = "Ir a Hoy"
        Me.BtGoToNow.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.BtGoToNow.UseVisualStyleBackColor = True
        '
        'LblSubTitle
        '
        Me.LblSubTitle.Location = New System.Drawing.Point(64, 30)
        Me.LblSubTitle.Name = "LblSubTitle"
        Me.LblSubTitle.Size = New System.Drawing.Size(321, 31)
        Me.LblSubTitle.TabIndex = 1
        Me.LblSubTitle.Text = "Administración, gestión y control de Reservas y/o Agenda"
        '
        'LblTitle
        '
        Me.LblTitle.AutoSize = True
        Me.LblTitle.Font = New System.Drawing.Font("Tahoma", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblTitle.Location = New System.Drawing.Point(57, 4)
        Me.LblTitle.Name = "LblTitle"
        Me.LblTitle.Size = New System.Drawing.Size(190, 23)
        Me.LblTitle.TabIndex = 0
        Me.LblTitle.Text = "Agenda / Reservas"
        '
        'PnlBody
        '
        Me.PnlBody.BackColor = System.Drawing.SystemColors.Control
        Me.PnlBody.BackgroundImage = CType(resources.GetObject("PnlBody.BackgroundImage"), System.Drawing.Image)
        Me.PnlBody.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PnlBody.Controls.Add(Me.TabControl1)
        Me.PnlBody.ForeColor = System.Drawing.Color.Black
        Me.PnlBody.Location = New System.Drawing.Point(12, 14)
        Me.PnlBody.Name = "PnlBody"
        Me.PnlBody.Size = New System.Drawing.Size(981, 669)
        Me.PnlBody.TabIndex = 0
        Me.PnlBody.Visible = False
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Location = New System.Drawing.Point(37, 39)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(910, 586)
        Me.TabControl1.TabIndex = 45
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.PnlAgenda)
        Me.TabPage1.Controls.Add(Me.LblName)
        Me.TabPage1.Controls.Add(Me.PnlFilters)
        Me.TabPage1.Controls.Add(Me.LblMonth)
        Me.TabPage1.Controls.Add(Me.Label7)
        Me.TabPage1.Controls.Add(Me.Label1)
        Me.TabPage1.Controls.Add(Me.Label4)
        Me.TabPage1.Controls.Add(Me.PnlAction_Buttons)
        Me.TabPage1.Controls.Add(Me.Label5)
        Me.TabPage1.Controls.Add(Me.Label2)
        Me.TabPage1.Controls.Add(Me.Label6)
        Me.TabPage1.Controls.Add(Me.PnlDays)
        Me.TabPage1.Controls.Add(Me.Label3)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(902, 560)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Agenda/Reservas"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'PnlAgenda
        '
        Me.PnlAgenda.BackColor = System.Drawing.Color.FromArgb(CType(CType(174, Byte), Integer), CType(CType(186, Byte), Integer), CType(CType(186, Byte), Integer))
        Me.PnlAgenda.Controls.Add(GroupBox1)
        Me.PnlAgenda.Controls.Add(LblReservas_Tot)
        Me.PnlAgenda.Controls.Add(Me.GroupEdit)
        Me.PnlAgenda.Controls.Add(Me.LstEventos)
        Me.PnlAgenda.Controls.Add(Me.LblDaySelect)
        Me.PnlAgenda.Location = New System.Drawing.Point(581, 77)
        Me.PnlAgenda.Name = "PnlAgenda"
        Me.PnlAgenda.Size = New System.Drawing.Size(319, 477)
        Me.PnlAgenda.TabIndex = 44
        '
        'GroupEdit
        '
        Me.GroupEdit.Controls.Add(Me.BtNew)
        Me.GroupEdit.Controls.Add(Me.BtDell)
        Me.GroupEdit.Controls.Add(Me.BtEdit)
        Me.GroupEdit.ForeColor = System.Drawing.SystemColors.InactiveCaptionText
        Me.GroupEdit.Location = New System.Drawing.Point(3, 45)
        Me.GroupEdit.Name = "GroupEdit"
        Me.GroupEdit.Size = New System.Drawing.Size(313, 94)
        Me.GroupEdit.TabIndex = 41
        Me.GroupEdit.TabStop = False
        Me.GroupEdit.Text = "Acciones"
        '
        'BtNew
        '
        Me.BtNew.BackColor = System.Drawing.SystemColors.Control
        Me.BtNew.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtNew.ForeColor = System.Drawing.Color.Black
        Me.BtNew.Image = CType(resources.GetObject("BtNew.Image"), System.Drawing.Image)
        Me.BtNew.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.BtNew.Location = New System.Drawing.Point(7, 18)
        Me.BtNew.Name = "BtNew"
        Me.BtNew.Size = New System.Drawing.Size(100, 71)
        Me.BtNew.TabIndex = 15
        Me.BtNew.Tag = "NEW_EVENTS"
        Me.BtNew.Text = "Anotar Reserva !!"
        Me.BtNew.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.BtNew.UseVisualStyleBackColor = False
        '
        'BtDell
        '
        Me.BtDell.BackColor = System.Drawing.SystemColors.Control
        Me.BtDell.Enabled = False
        Me.BtDell.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtDell.ForeColor = System.Drawing.Color.Black
        Me.BtDell.Image = CType(resources.GetObject("BtDell.Image"), System.Drawing.Image)
        Me.BtDell.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.BtDell.Location = New System.Drawing.Point(207, 18)
        Me.BtDell.Name = "BtDell"
        Me.BtDell.Size = New System.Drawing.Size(100, 71)
        Me.BtDell.TabIndex = 17
        Me.BtDell.Tag = "DEL_EVENTS"
        Me.BtDell.Text = "Anular Reserva"
        Me.BtDell.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.BtDell.UseVisualStyleBackColor = False
        '
        'BtEdit
        '
        Me.BtEdit.BackColor = System.Drawing.SystemColors.Control
        Me.BtEdit.Enabled = False
        Me.BtEdit.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtEdit.ForeColor = System.Drawing.Color.Black
        Me.BtEdit.Image = CType(resources.GetObject("BtEdit.Image"), System.Drawing.Image)
        Me.BtEdit.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.BtEdit.Location = New System.Drawing.Point(107, 18)
        Me.BtEdit.Name = "BtEdit"
        Me.BtEdit.Size = New System.Drawing.Size(100, 71)
        Me.BtEdit.TabIndex = 16
        Me.BtEdit.Tag = "EDIT_EVENTS"
        Me.BtEdit.Text = "Ver Detalles"
        Me.BtEdit.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.BtEdit.UseVisualStyleBackColor = False
        '
        'LstEventos
        '
        Me.LstEventos.BackColor = System.Drawing.Color.LemonChiffon
        Me.LstEventos.CheckBoxes = True
        Me.LstEventos.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.LstEventos.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LstEventos.FullRowSelect = True
        Me.LstEventos.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable
        Me.LstEventos.HideSelection = False
        Me.LstEventos.Location = New System.Drawing.Point(0, 251)
        Me.LstEventos.MultiSelect = False
        Me.LstEventos.Name = "LstEventos"
        Me.LstEventos.Size = New System.Drawing.Size(319, 226)
        Me.LstEventos.TabIndex = 42
        Me.LstEventos.UseCompatibleStateImageBehavior = False
        Me.LstEventos.View = System.Windows.Forms.View.Details
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
        Me.LblDaySelect.Size = New System.Drawing.Size(319, 42)
        Me.LblDaySelect.TabIndex = 40
        Me.LblDaySelect.Text = "JUEVES"
        Me.LblDaySelect.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'LblName
        '
        Me.LblName.AutoSize = True
        Me.LblName.BackColor = System.Drawing.Color.Transparent
        Me.LblName.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblName.Location = New System.Drawing.Point(9, 7)
        Me.LblName.Name = "LblName"
        Me.LblName.Size = New System.Drawing.Size(197, 24)
        Me.LblName.TabIndex = 35
        Me.LblName.Text = "Agenda y Reservas:"
        '
        'PnlFilters
        '
        Me.PnlFilters.BackColor = System.Drawing.Color.FromArgb(CType(CType(174, Byte), Integer), CType(CType(186, Byte), Integer), CType(CType(186, Byte), Integer))
        Me.PnlFilters.Controls.Add(Me.Label10)
        Me.PnlFilters.Controls.Add(Me.Label9)
        Me.PnlFilters.Controls.Add(Me.ChkShow_Notas)
        Me.PnlFilters.Controls.Add(Me.ChkShow_Reservas)
        Me.PnlFilters.Controls.Add(Me.Label8)
        Me.PnlFilters.Location = New System.Drawing.Point(2, 528)
        Me.PnlFilters.Name = "PnlFilters"
        Me.PnlFilters.Size = New System.Drawing.Size(573, 57)
        Me.PnlFilters.TabIndex = 43
        Me.PnlFilters.Visible = False
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.BackColor = System.Drawing.Color.Transparent
        Me.Label10.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(210, 28)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(49, 19)
        Me.Label10.TabIndex = 40
        Me.Label10.Text = "Notas"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.BackColor = System.Drawing.Color.Transparent
        Me.Label9.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(66, 28)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(71, 19)
        Me.Label9.TabIndex = 39
        Me.Label9.Text = "Reservas"
        '
        'ChkShow_Notas
        '
        Me.ChkShow_Notas.Appearance = System.Windows.Forms.Appearance.Button
        Me.ChkShow_Notas.Checked = True
        Me.ChkShow_Notas.CheckState = System.Windows.Forms.CheckState.Checked
        Me.ChkShow_Notas.ImageIndex = 1
        Me.ChkShow_Notas.ImageList = Me.ImageList
        Me.ChkShow_Notas.Location = New System.Drawing.Point(177, 26)
        Me.ChkShow_Notas.Name = "ChkShow_Notas"
        Me.ChkShow_Notas.Size = New System.Drawing.Size(27, 27)
        Me.ChkShow_Notas.TabIndex = 38
        Me.ChkShow_Notas.Tag = "ticket_center_1"
        Me.ChkShow_Notas.UseVisualStyleBackColor = True
        '
        'ImageList
        '
        Me.ImageList.ImageStream = CType(resources.GetObject("ImageList.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageList.Images.SetKeyName(0, "ball_red.png")
        Me.ImageList.Images.SetKeyName(1, "ball_green.png")
        '
        'ChkShow_Reservas
        '
        Me.ChkShow_Reservas.Appearance = System.Windows.Forms.Appearance.Button
        Me.ChkShow_Reservas.Checked = True
        Me.ChkShow_Reservas.CheckState = System.Windows.Forms.CheckState.Checked
        Me.ChkShow_Reservas.ImageIndex = 1
        Me.ChkShow_Reservas.ImageList = Me.ImageList
        Me.ChkShow_Reservas.Location = New System.Drawing.Point(33, 26)
        Me.ChkShow_Reservas.Name = "ChkShow_Reservas"
        Me.ChkShow_Reservas.Size = New System.Drawing.Size(27, 27)
        Me.ChkShow_Reservas.TabIndex = 37
        Me.ChkShow_Reservas.Tag = "ticket_center_1"
        Me.ChkShow_Reservas.UseVisualStyleBackColor = True
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.BackColor = System.Drawing.Color.Transparent
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(7, 3)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(116, 20)
        Me.Label8.TabIndex = 36
        Me.Label8.Text = "Mostrar Solo:"
        '
        'LblMonth
        '
        Me.LblMonth.AutoSize = True
        Me.LblMonth.BackColor = System.Drawing.Color.Transparent
        Me.LblMonth.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblMonth.Location = New System.Drawing.Point(204, 7)
        Me.LblMonth.Name = "LblMonth"
        Me.LblMonth.Size = New System.Drawing.Size(266, 31)
        Me.LblMonth.TabIndex = 36
        Me.LblMonth.Text = "Noviembre de 2008"
        '
        'Label7
        '
        Me.Label7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label7.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(483, 52)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(80, 19)
        Me.Label7.TabIndex = 42
        Me.Label7.Text = "DOMINGO"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label1
        '
        Me.Label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(3, 52)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(80, 19)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "LUNES"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label4
        '
        Me.Label4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label4.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(403, 52)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(80, 19)
        Me.Label4.TabIndex = 41
        Me.Label4.Text = "SÁBADO"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'PnlAction_Buttons
        '
        Me.PnlAction_Buttons.BackColor = System.Drawing.Color.Transparent
        Me.PnlAction_Buttons.Controls.Add(Me.BtMonth_Next)
        Me.PnlAction_Buttons.Controls.Add(Me.BtMonth_Previous)
        Me.PnlAction_Buttons.Location = New System.Drawing.Point(608, -1)
        Me.PnlAction_Buttons.Name = "PnlAction_Buttons"
        Me.PnlAction_Buttons.Size = New System.Drawing.Size(283, 72)
        Me.PnlAction_Buttons.TabIndex = 37
        Me.PnlAction_Buttons.Tag = "NO_SCAN"
        '
        'BtMonth_Next
        '
        Me.BtMonth_Next.BackColor = System.Drawing.SystemColors.Control
        Me.BtMonth_Next.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtMonth_Next.Image = CType(resources.GetObject("BtMonth_Next.Image"), System.Drawing.Image)
        Me.BtMonth_Next.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BtMonth_Next.Location = New System.Drawing.Point(156, 0)
        Me.BtMonth_Next.Name = "BtMonth_Next"
        Me.BtMonth_Next.Size = New System.Drawing.Size(122, 63)
        Me.BtMonth_Next.TabIndex = 16
        Me.BtMonth_Next.Tag = ""
        Me.BtMonth_Next.Text = "Mes Siguiente"
        Me.BtMonth_Next.TextAlign = System.Drawing.ContentAlignment.BottomLeft
        Me.BtMonth_Next.UseVisualStyleBackColor = False
        '
        'BtMonth_Previous
        '
        Me.BtMonth_Previous.BackColor = System.Drawing.SystemColors.Control
        Me.BtMonth_Previous.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtMonth_Previous.Image = CType(resources.GetObject("BtMonth_Previous.Image"), System.Drawing.Image)
        Me.BtMonth_Previous.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtMonth_Previous.Location = New System.Drawing.Point(28, 0)
        Me.BtMonth_Previous.Name = "BtMonth_Previous"
        Me.BtMonth_Previous.Size = New System.Drawing.Size(122, 63)
        Me.BtMonth_Previous.TabIndex = 15
        Me.BtMonth_Previous.Tag = ""
        Me.BtMonth_Previous.Text = "Mes Anterior"
        Me.BtMonth_Previous.TextAlign = System.Drawing.ContentAlignment.TopRight
        Me.BtMonth_Previous.UseVisualStyleBackColor = False
        '
        'Label5
        '
        Me.Label5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label5.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(323, 52)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(80, 19)
        Me.Label5.TabIndex = 40
        Me.Label5.Text = "VIERNES"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label2
        '
        Me.Label2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label2.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(83, 52)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(80, 19)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "MARTES"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label6
        '
        Me.Label6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label6.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(243, 52)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(80, 19)
        Me.Label6.TabIndex = 39
        Me.Label6.Text = "JUEVES"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'PnlDays
        '
        Me.PnlDays.BackColor = System.Drawing.Color.FromArgb(CType(CType(174, Byte), Integer), CType(CType(186, Byte), Integer), CType(CType(186, Byte), Integer))
        Me.PnlDays.Location = New System.Drawing.Point(2, 74)
        Me.PnlDays.Name = "PnlDays"
        Me.PnlDays.Size = New System.Drawing.Size(573, 448)
        Me.PnlDays.TabIndex = 38
        Me.PnlDays.Visible = False
        '
        'Label3
        '
        Me.Label3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label3.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(163, 52)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(80, 19)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "MIÉRCOLES"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.gridReservas)
        Me.TabPage2.Controls.Add(Me.PnlButtons_Controls)
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(902, 560)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Historico"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'gridReservas
        '
        Me.gridReservas.AllowUserToAddRows = False
        Me.gridReservas.AllowUserToDeleteRows = False
        Me.gridReservas.AllowUserToOrderColumns = True
        Me.gridReservas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.gridReservas.Location = New System.Drawing.Point(13, 152)
        Me.gridReservas.Name = "gridReservas"
        Me.gridReservas.ReadOnly = True
        Me.gridReservas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.gridReservas.Size = New System.Drawing.Size(883, 402)
        Me.gridReservas.TabIndex = 22
        '
        'PnlButtons_Controls
        '
        Me.PnlButtons_Controls.BackColor = System.Drawing.Color.FromArgb(CType(CType(197, Byte), Integer), CType(CType(203, Byte), Integer), CType(CType(203, Byte), Integer))
        Me.PnlButtons_Controls.Controls.Add(Me.DtCajaActual_Hasta)
        Me.PnlButtons_Controls.Controls.Add(Label13)
        Me.PnlButtons_Controls.Controls.Add(Me.DtReservas_Desde)
        Me.PnlButtons_Controls.Controls.Add(Label14)
        Me.PnlButtons_Controls.Controls.Add(Me.Label11)
        Me.PnlButtons_Controls.Controls.Add(Me.txtFilter_tlf)
        Me.PnlButtons_Controls.Controls.Add(Me.Label12)
        Me.PnlButtons_Controls.Controls.Add(Me.TxtFilter_name)
        Me.PnlButtons_Controls.Controls.Add(Me.BtFilter)
        Me.PnlButtons_Controls.Location = New System.Drawing.Point(13, 6)
        Me.PnlButtons_Controls.Name = "PnlButtons_Controls"
        Me.PnlButtons_Controls.Size = New System.Drawing.Size(621, 128)
        Me.PnlButtons_Controls.TabIndex = 21
        '
        'DtCajaActual_Hasta
        '
        Me.DtCajaActual_Hasta.CalendarFont = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DtCajaActual_Hasta.CustomFormat = "dd/MM/yyyy"
        Me.DtCajaActual_Hasta.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DtCajaActual_Hasta.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DtCajaActual_Hasta.Location = New System.Drawing.Point(415, 84)
        Me.DtCajaActual_Hasta.Name = "DtCajaActual_Hasta"
        Me.DtCajaActual_Hasta.Size = New System.Drawing.Size(176, 27)
        Me.DtCajaActual_Hasta.TabIndex = 70
        Me.DtCajaActual_Hasta.Tag = "fh_venta"
        Me.DtCajaActual_Hasta.Visible = False
        '
        'DtReservas_Desde
        '
        Me.DtReservas_Desde.CalendarFont = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DtReservas_Desde.CustomFormat = "dd/MM/yyyy"
        Me.DtReservas_Desde.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DtReservas_Desde.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DtReservas_Desde.Location = New System.Drawing.Point(223, 84)
        Me.DtReservas_Desde.Name = "DtReservas_Desde"
        Me.DtReservas_Desde.Size = New System.Drawing.Size(176, 27)
        Me.DtReservas_Desde.TabIndex = 68
        Me.DtReservas_Desde.Tag = "fh_venta"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(9, 62)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(66, 13)
        Me.Label11.TabIndex = 24
        Me.Label11.Text = "TELÉFONO"
        '
        'txtFilter_tlf
        '
        Me.txtFilter_tlf.Font = New System.Drawing.Font("Tahoma", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFilter_tlf.Location = New System.Drawing.Point(27, 78)
        Me.txtFilter_tlf.Name = "txtFilter_tlf"
        Me.txtFilter_tlf.Size = New System.Drawing.Size(145, 33)
        Me.txtFilter_tlf.TabIndex = 23
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(9, 6)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(56, 13)
        Me.Label12.TabIndex = 22
        Me.Label12.Text = "NOMBRE"
        '
        'TxtFilter_name
        '
        Me.TxtFilter_name.Font = New System.Drawing.Font("Tahoma", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtFilter_name.Location = New System.Drawing.Point(27, 22)
        Me.TxtFilter_name.Name = "TxtFilter_name"
        Me.TxtFilter_name.Size = New System.Drawing.Size(283, 33)
        Me.TxtFilter_name.TabIndex = 0
        '
        'BtFilter
        '
        Me.BtFilter.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.BtFilter.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtFilter.Image = CType(resources.GetObject("BtFilter.Image"), System.Drawing.Image)
        Me.BtFilter.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtFilter.Location = New System.Drawing.Point(479, 11)
        Me.BtFilter.Name = "BtFilter"
        Me.BtFilter.Size = New System.Drawing.Size(112, 58)
        Me.BtFilter.TabIndex = 3
        Me.BtFilter.Tag = "last"
        Me.BtFilter.Text = "Buscar!!!"
        Me.BtFilter.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BtFilter.UseVisualStyleBackColor = True
        '
        'ImageList_day
        '
        Me.ImageList_day.ImageStream = CType(resources.GetObject("ImageList_day.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList_day.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageList_day.Images.SetKeyName(0, "note.png")
        '
        'frmReservas
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Black
        Me.ClientSize = New System.Drawing.Size(1020, 770)
        Me.Controls.Add(Me.SplitContainer)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "frmReservas"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        GroupBox1.ResumeLayout(False)
        Me.SplitContainer.Panel1.ResumeLayout(False)
        Me.SplitContainer.Panel1.PerformLayout()
        Me.SplitContainer.Panel2.ResumeLayout(False)
        Me.SplitContainer.ResumeLayout(False)
        CType(Me.m_logo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PnlButton_Shell.ResumeLayout(False)
        Me.PnlBody.ResumeLayout(False)
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage1.PerformLayout()
        Me.PnlAgenda.ResumeLayout(False)
        Me.GroupEdit.ResumeLayout(False)
        Me.PnlFilters.ResumeLayout(False)
        Me.PnlFilters.PerformLayout()
        Me.PnlAction_Buttons.ResumeLayout(False)
        Me.TabPage2.ResumeLayout(False)
        CType(Me.gridReservas, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PnlButtons_Controls.ResumeLayout(False)
        Me.PnlButtons_Controls.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents SplitContainer As System.Windows.Forms.SplitContainer
    Friend WithEvents m_logo As System.Windows.Forms.PictureBox
    Friend WithEvents PnlButton_Shell As System.Windows.Forms.Panel
    Friend WithEvents BtClose As System.Windows.Forms.Button
    Friend WithEvents BtGoToNow As System.Windows.Forms.Button
    Friend WithEvents LblSubTitle As System.Windows.Forms.Label
    Friend WithEvents LblTitle As System.Windows.Forms.Label
    Friend WithEvents PnlBody As System.Windows.Forms.Panel
    Friend WithEvents ImageList As System.Windows.Forms.ImageList
    Friend WithEvents LblName As System.Windows.Forms.Label
    Friend WithEvents LblMonth As System.Windows.Forms.Label
    Friend WithEvents PnlAction_Buttons As System.Windows.Forms.Panel
    Friend WithEvents BtMonth_Next As System.Windows.Forms.Button
    Friend WithEvents BtMonth_Previous As System.Windows.Forms.Button
    Friend WithEvents PnlDays As System.Windows.Forms.Panel
    Friend WithEvents ToolTip As System.Windows.Forms.ToolTip
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents PnlFilters As System.Windows.Forms.Panel
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents ChkShow_Reservas As System.Windows.Forms.CheckBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents ChkShow_Notas As System.Windows.Forms.CheckBox
    Friend WithEvents PnlAgenda As System.Windows.Forms.Panel
    Friend WithEvents LblDaySelect As System.Windows.Forms.Label
    Friend WithEvents BtDell As System.Windows.Forms.Button
    Friend WithEvents BtEdit As System.Windows.Forms.Button
    Friend WithEvents BtNew As System.Windows.Forms.Button
    Friend WithEvents GroupEdit As System.Windows.Forms.GroupBox
    Friend WithEvents BtPrintMenu As System.Windows.Forms.Button
    Friend WithEvents ImageList_day As System.Windows.Forms.ImageList
    Friend WithEvents LstEventos As System.Windows.Forms.ListView
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents BtGenerateTicket As System.Windows.Forms.Button
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents PnlButtons_Controls As System.Windows.Forms.Panel
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents txtFilter_tlf As System.Windows.Forms.TextBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents TxtFilter_name As System.Windows.Forms.TextBox
    Friend WithEvents BtFilter As System.Windows.Forms.Button
    Friend WithEvents gridReservas As System.Windows.Forms.DataGridView
    Friend WithEvents DtCajaActual_Hasta As System.Windows.Forms.DateTimePicker
    Friend WithEvents DtReservas_Desde As System.Windows.Forms.DateTimePicker
End Class
