<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCategorias
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
        Dim Label1 As System.Windows.Forms.Label
        Dim Label6 As System.Windows.Forms.Label
        Dim LblNUsos As System.Windows.Forms.Label
        Dim Label2 As System.Windows.Forms.Label
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmCategorias))
        Dim Label56 As System.Windows.Forms.Label
        Me.SplitContainer = New System.Windows.Forms.SplitContainer()
        Me.m_logo = New System.Windows.Forms.PictureBox()
        Me.PnlButton_Shell = New System.Windows.Forms.Panel()
        Me.BtClose = New System.Windows.Forms.Button()
        Me.LblSubTitle = New System.Windows.Forms.Label()
        Me.LblTitle = New System.Windows.Forms.Label()
        Me.PnlBody = New System.Windows.Forms.Panel()
        Me.PnlAction_Buttons = New System.Windows.Forms.Panel()
        Me.BtCancell = New System.Windows.Forms.Button()
        Me.BtOk = New System.Windows.Forms.Button()
        Me.PnlData = New System.Windows.Forms.Panel()
        Me.Tab = New System.Windows.Forms.TabControl()
        Me.TabPage_General = New System.Windows.Forms.TabPage()
        Me.Group_Personalizacion = New System.Windows.Forms.GroupBox()
        Me.PicImg = New System.Windows.Forms.PictureBox()
        Me.LnkDelImg = New System.Windows.Forms.LinkLabel()
        Me.BtSelectImg = New System.Windows.Forms.Button()
        Me.LblFh_Alta = New System.Windows.Forms.Label()
        Me.LblFh_Alta_nfo = New System.Windows.Forms.Label()
        Me.Group_User = New System.Windows.Forms.GroupBox()
        Me.CbCategoria = New System.Windows.Forms.ComboBox()
        Me.CheckBox2 = New System.Windows.Forms.CheckBox()
        Me.CheckBox1 = New System.Windows.Forms.CheckBox()
        Me.chkPedidos = New System.Windows.Forms.CheckBox()
        Me.TxtName = New System.Windows.Forms.TextBox()
        Me.ImageList_Grid = New System.Windows.Forms.ImageList(Me.components)
        Me.LblId = New System.Windows.Forms.Label()
        Me.LblNofM = New System.Windows.Forms.Label()
        Me.PnlButtons_Actions = New System.Windows.Forms.Panel()
        Me.BtNew = New System.Windows.Forms.Button()
        Me.BtDel = New System.Windows.Forms.Button()
        Me.BtEdit = New System.Windows.Forms.Button()
        Me.PnlButtons_Move = New System.Windows.Forms.Panel()
        Me.BtLast = New System.Windows.Forms.Button()
        Me.BtFirst = New System.Windows.Forms.Button()
        Me.BtNext = New System.Windows.Forms.Button()
        Me.BtPrevious = New System.Windows.Forms.Button()
        Me.LblName = New System.Windows.Forms.Label()
        Me.txtN = New System.Windows.Forms.TextBox()
        Label1 = New System.Windows.Forms.Label()
        Label6 = New System.Windows.Forms.Label()
        LblNUsos = New System.Windows.Forms.Label()
        Label2 = New System.Windows.Forms.Label()
        Label56 = New System.Windows.Forms.Label()
        Me.SplitContainer.Panel1.SuspendLayout()
        Me.SplitContainer.Panel2.SuspendLayout()
        Me.SplitContainer.SuspendLayout()
        CType(Me.m_logo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PnlButton_Shell.SuspendLayout()
        Me.PnlBody.SuspendLayout()
        Me.PnlAction_Buttons.SuspendLayout()
        Me.PnlData.SuspendLayout()
        Me.Tab.SuspendLayout()
        Me.TabPage_General.SuspendLayout()
        Me.Group_Personalizacion.SuspendLayout()
        CType(Me.PicImg, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Group_User.SuspendLayout()
        Me.PnlButtons_Actions.SuspendLayout()
        Me.PnlButtons_Move.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label1
        '
        Label1.AutoSize = True
        Label1.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Label1.Location = New System.Drawing.Point(12, 27)
        Label1.Name = "Label1"
        Label1.Size = New System.Drawing.Size(126, 18)
        Label1.TabIndex = 0
        Label1.Text = "Nombre de familia"
        '
        'Label6
        '
        Label6.AutoSize = True
        Label6.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Label6.Location = New System.Drawing.Point(149, 54)
        Label6.Name = "Label6"
        Label6.Size = New System.Drawing.Size(45, 18)
        Label6.TabIndex = 5
        Label6.Text = "Usos:"
        '
        'LblNUsos
        '
        LblNUsos.AutoSize = True
        LblNUsos.Font = New System.Drawing.Font("Tahoma", 11.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        LblNUsos.Location = New System.Drawing.Point(195, 54)
        LblNUsos.Name = "LblNUsos"
        LblNUsos.Size = New System.Drawing.Size(18, 18)
        LblNUsos.TabIndex = 14
        LblNUsos.Tag = "n_veces"
        LblNUsos.Text = "0"
        '
        'Label2
        '
        Label2.AutoSize = True
        Label2.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Label2.Location = New System.Drawing.Point(23, 215)
        Label2.Name = "Label2"
        Label2.Size = New System.Drawing.Size(171, 18)
        Label2.TabIndex = 35
        Label2.Text = "Impresora de Comandas"
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
        Me.SplitContainer.Panel2.Tag = ""
        Me.SplitContainer.Size = New System.Drawing.Size(1028, 760)
        Me.SplitContainer.SplitterDistance = 64
        Me.SplitContainer.SplitterWidth = 1
        Me.SplitContainer.TabIndex = 1
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
        Me.PnlButton_Shell.Dock = System.Windows.Forms.DockStyle.Right
        Me.PnlButton_Shell.Location = New System.Drawing.Point(478, 0)
        Me.PnlButton_Shell.Name = "PnlButton_Shell"
        Me.PnlButton_Shell.Size = New System.Drawing.Size(550, 64)
        Me.PnlButton_Shell.TabIndex = 2
        Me.PnlButton_Shell.Tag = "NO_SCAN"
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
        Me.LblSubTitle.AutoSize = True
        Me.LblSubTitle.ForeColor = System.Drawing.SystemColors.InactiveCaption
        Me.LblSubTitle.Location = New System.Drawing.Point(64, 30)
        Me.LblSubTitle.Name = "LblSubTitle"
        Me.LblSubTitle.Size = New System.Drawing.Size(329, 13)
        Me.LblSubTitle.TabIndex = 1
        Me.LblSubTitle.Text = "Software de control, administración y ventas de locales de hosteleria" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        '
        'LblTitle
        '
        Me.LblTitle.AutoSize = True
        Me.LblTitle.Font = New System.Drawing.Font("Tahoma", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblTitle.Location = New System.Drawing.Point(57, 4)
        Me.LblTitle.Name = "LblTitle"
        Me.LblTitle.Size = New System.Drawing.Size(59, 23)
        Me.LblTitle.TabIndex = 0
        Me.LblTitle.Text = "gTPV"
        '
        'PnlBody
        '
        Me.PnlBody.BackColor = System.Drawing.SystemColors.Control
        Me.PnlBody.BackgroundImage = CType(resources.GetObject("PnlBody.BackgroundImage"), System.Drawing.Image)
        Me.PnlBody.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PnlBody.Controls.Add(Me.PnlAction_Buttons)
        Me.PnlBody.Controls.Add(Me.PnlData)
        Me.PnlBody.Controls.Add(Me.LblId)
        Me.PnlBody.Controls.Add(Me.LblNofM)
        Me.PnlBody.Controls.Add(Me.PnlButtons_Actions)
        Me.PnlBody.Controls.Add(Me.PnlButtons_Move)
        Me.PnlBody.Controls.Add(Me.LblName)
        Me.PnlBody.ForeColor = System.Drawing.Color.Black
        Me.PnlBody.Location = New System.Drawing.Point(12, 14)
        Me.PnlBody.Name = "PnlBody"
        Me.PnlBody.Size = New System.Drawing.Size(981, 669)
        Me.PnlBody.TabIndex = 0
        Me.PnlBody.Visible = False
        '
        'PnlAction_Buttons
        '
        Me.PnlAction_Buttons.BackColor = System.Drawing.Color.FromArgb(CType(CType(197, Byte), Integer), CType(CType(203, Byte), Integer), CType(CType(203, Byte), Integer))
        Me.PnlAction_Buttons.Controls.Add(Me.BtCancell)
        Me.PnlAction_Buttons.Controls.Add(Me.BtOk)
        Me.PnlAction_Buttons.Location = New System.Drawing.Point(814, 24)
        Me.PnlAction_Buttons.Name = "PnlAction_Buttons"
        Me.PnlAction_Buttons.Size = New System.Drawing.Size(146, 70)
        Me.PnlAction_Buttons.TabIndex = 1
        Me.PnlAction_Buttons.Tag = "NO_SCAN"
        '
        'BtCancell
        '
        Me.BtCancell.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.BtCancell.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtCancell.Image = CType(resources.GetObject("BtCancell.Image"), System.Drawing.Image)
        Me.BtCancell.Location = New System.Drawing.Point(3, 3)
        Me.BtCancell.Name = "BtCancell"
        Me.BtCancell.Size = New System.Drawing.Size(67, 63)
        Me.BtCancell.TabIndex = 16
        Me.BtCancell.Tag = "cancell"
        Me.BtCancell.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.BtCancell.UseVisualStyleBackColor = True
        '
        'BtOk
        '
        Me.BtOk.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.BtOk.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtOk.Image = CType(resources.GetObject("BtOk.Image"), System.Drawing.Image)
        Me.BtOk.Location = New System.Drawing.Point(76, 3)
        Me.BtOk.Name = "BtOk"
        Me.BtOk.Size = New System.Drawing.Size(67, 63)
        Me.BtOk.TabIndex = 15
        Me.BtOk.Tag = "ok"
        Me.BtOk.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.BtOk.UseVisualStyleBackColor = True
        '
        'PnlData
        '
        Me.PnlData.BackColor = System.Drawing.Color.FromArgb(CType(CType(174, Byte), Integer), CType(CType(186, Byte), Integer), CType(CType(186, Byte), Integer))
        Me.PnlData.Controls.Add(Me.Tab)
        Me.PnlData.Location = New System.Drawing.Point(43, 136)
        Me.PnlData.Name = "PnlData"
        Me.PnlData.Size = New System.Drawing.Size(896, 499)
        Me.PnlData.TabIndex = 19
        Me.PnlData.Visible = False
        '
        'Tab
        '
        Me.Tab.Controls.Add(Me.TabPage_General)
        Me.Tab.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Tab.ImageList = Me.ImageList_Grid
        Me.Tab.Location = New System.Drawing.Point(0, 0)
        Me.Tab.Name = "Tab"
        Me.Tab.SelectedIndex = 0
        Me.Tab.Size = New System.Drawing.Size(896, 499)
        Me.Tab.TabIndex = 0
        '
        'TabPage_General
        '
        Me.TabPage_General.Controls.Add(Me.Group_Personalizacion)
        Me.TabPage_General.Controls.Add(Me.LblFh_Alta)
        Me.TabPage_General.Controls.Add(Me.LblFh_Alta_nfo)
        Me.TabPage_General.Controls.Add(Me.Group_User)
        Me.TabPage_General.ImageIndex = 0
        Me.TabPage_General.Location = New System.Drawing.Point(4, 23)
        Me.TabPage_General.Name = "TabPage_General"
        Me.TabPage_General.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage_General.Size = New System.Drawing.Size(888, 472)
        Me.TabPage_General.TabIndex = 0
        Me.TabPage_General.Text = "General"
        Me.TabPage_General.UseVisualStyleBackColor = True
        '
        'Group_Personalizacion
        '
        Me.Group_Personalizacion.Controls.Add(Me.PicImg)
        Me.Group_Personalizacion.Controls.Add(Me.LnkDelImg)
        Me.Group_Personalizacion.Controls.Add(Me.BtSelectImg)
        Me.Group_Personalizacion.Location = New System.Drawing.Point(736, 6)
        Me.Group_Personalizacion.Name = "Group_Personalizacion"
        Me.Group_Personalizacion.Size = New System.Drawing.Size(140, 150)
        Me.Group_Personalizacion.TabIndex = 5
        Me.Group_Personalizacion.TabStop = False
        Me.Group_Personalizacion.Tag = ""
        Me.Group_Personalizacion.Text = "Imagen"
        '
        'PicImg
        '
        Me.PicImg.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PicImg.Location = New System.Drawing.Point(14, 18)
        Me.PicImg.Name = "PicImg"
        Me.PicImg.Size = New System.Drawing.Size(112, 109)
        Me.PicImg.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage
        Me.PicImg.TabIndex = 18
        Me.PicImg.TabStop = False
        Me.PicImg.Tag = "img"
        '
        'LnkDelImg
        '
        Me.LnkDelImg.Location = New System.Drawing.Point(20, 130)
        Me.LnkDelImg.Name = "LnkDelImg"
        Me.LnkDelImg.Size = New System.Drawing.Size(96, 14)
        Me.LnkDelImg.TabIndex = 17
        Me.LnkDelImg.TabStop = True
        Me.LnkDelImg.Tag = "VISIBLE"
        Me.LnkDelImg.Text = "Quitar Imagen"
        Me.LnkDelImg.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'BtSelectImg
        '
        Me.BtSelectImg.Location = New System.Drawing.Point(13, 17)
        Me.BtSelectImg.Name = "BtSelectImg"
        Me.BtSelectImg.Size = New System.Drawing.Size(112, 109)
        Me.BtSelectImg.TabIndex = 1
        Me.BtSelectImg.Tag = "VISIBLE"
        Me.BtSelectImg.Text = "Click para seleccionar Fotografía"
        Me.BtSelectImg.UseVisualStyleBackColor = True
        '
        'LblFh_Alta
        '
        Me.LblFh_Alta.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblFh_Alta.Location = New System.Drawing.Point(111, 454)
        Me.LblFh_Alta.Name = "LblFh_Alta"
        Me.LblFh_Alta.Size = New System.Drawing.Size(179, 13)
        Me.LblFh_Alta.TabIndex = 4
        Me.LblFh_Alta.Tag = "fh_alta"
        Me.LblFh_Alta.Text = "00/00/0000"
        '
        'LblFh_Alta_nfo
        '
        Me.LblFh_Alta_nfo.AutoSize = True
        Me.LblFh_Alta_nfo.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblFh_Alta_nfo.Location = New System.Drawing.Point(19, 454)
        Me.LblFh_Alta_nfo.Name = "LblFh_Alta_nfo"
        Me.LblFh_Alta_nfo.Size = New System.Drawing.Size(88, 13)
        Me.LblFh_Alta_nfo.TabIndex = 3
        Me.LblFh_Alta_nfo.Text = "Fecha de alta:"
        '
        'Group_User
        '
        Me.Group_User.Controls.Add(Label56)
        Me.Group_User.Controls.Add(Me.txtN)
        Me.Group_User.Controls.Add(Me.CbCategoria)
        Me.Group_User.Controls.Add(Label2)
        Me.Group_User.Controls.Add(Me.CheckBox2)
        Me.Group_User.Controls.Add(Me.CheckBox1)
        Me.Group_User.Controls.Add(Me.chkPedidos)
        Me.Group_User.Controls.Add(LblNUsos)
        Me.Group_User.Controls.Add(Label1)
        Me.Group_User.Controls.Add(Me.TxtName)
        Me.Group_User.Controls.Add(Label6)
        Me.Group_User.Location = New System.Drawing.Point(21, 6)
        Me.Group_User.Name = "Group_User"
        Me.Group_User.Size = New System.Drawing.Size(709, 319)
        Me.Group_User.TabIndex = 0
        Me.Group_User.TabStop = False
        Me.Group_User.Text = "Familia"
        '
        'CbCategoria
        '
        Me.CbCategoria.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CbCategoria.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CbCategoria.FormattingEnabled = True
        Me.CbCategoria.Items.AddRange(New Object() {"", "COCINA", "FRIA", "BEBIDAS"})
        Me.CbCategoria.Location = New System.Drawing.Point(200, 204)
        Me.CbCategoria.Name = "CbCategoria"
        Me.CbCategoria.Size = New System.Drawing.Size(384, 37)
        Me.CbCategoria.TabIndex = 36
        Me.CbCategoria.Tag = "printercomandas"
        '
        'CheckBox2
        '
        Me.CheckBox2.AutoSize = True
        Me.CheckBox2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CheckBox2.Location = New System.Drawing.Point(163, 154)
        Me.CheckBox2.Name = "CheckBox2"
        Me.CheckBox2.Size = New System.Drawing.Size(249, 24)
        Me.CheckBox2.TabIndex = 17
        Me.CheckBox2.Tag = "swExtras"
        Me.CheckBox2.Text = "Categoría para productos Extra"
        Me.CheckBox2.UseVisualStyleBackColor = True
        '
        'CheckBox1
        '
        Me.CheckBox1.AutoSize = True
        Me.CheckBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CheckBox1.Location = New System.Drawing.Point(163, 124)
        Me.CheckBox1.Name = "CheckBox1"
        Me.CheckBox1.Size = New System.Drawing.Size(136, 24)
        Me.CheckBox1.TabIndex = 16
        Me.CheckBox1.Tag = "swDescatalogada"
        Me.CheckBox1.Text = "Descatalogada"
        Me.CheckBox1.UseVisualStyleBackColor = True
        '
        'chkPedidos
        '
        Me.chkPedidos.AutoSize = True
        Me.chkPedidos.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkPedidos.Location = New System.Drawing.Point(163, 94)
        Me.chkPedidos.Name = "chkPedidos"
        Me.chkPedidos.Size = New System.Drawing.Size(180, 24)
        Me.chkPedidos.TabIndex = 15
        Me.chkPedidos.Tag = "swPedidos"
        Me.chkPedidos.Text = "Categoría de Pedidos"
        Me.chkPedidos.UseVisualStyleBackColor = True
        '
        'TxtName
        '
        Me.TxtName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtName.Font = New System.Drawing.Font("Tahoma", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtName.Location = New System.Drawing.Point(152, 18)
        Me.TxtName.MaxLength = 150
        Me.TxtName.Name = "TxtName"
        Me.TxtName.Size = New System.Drawing.Size(544, 33)
        Me.TxtName.TabIndex = 0
        Me.TxtName.Tag = "name"
        '
        'ImageList_Grid
        '
        Me.ImageList_Grid.ImageStream = CType(resources.GetObject("ImageList_Grid.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList_Grid.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageList_Grid.Images.SetKeyName(0, "app copy.png")
        Me.ImageList_Grid.Images.SetKeyName(1, "general.png")
        '
        'LblId
        '
        Me.LblId.BackColor = System.Drawing.Color.FromArgb(CType(CType(197, Byte), Integer), CType(CType(203, Byte), Integer), CType(CType(203, Byte), Integer))
        Me.LblId.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblId.Location = New System.Drawing.Point(668, 49)
        Me.LblId.Name = "LblId"
        Me.LblId.Size = New System.Drawing.Size(100, 16)
        Me.LblId.TabIndex = 18
        Me.LblId.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'LblNofM
        '
        Me.LblNofM.BackColor = System.Drawing.Color.FromArgb(CType(CType(197, Byte), Integer), CType(CType(203, Byte), Integer), CType(CType(203, Byte), Integer))
        Me.LblNofM.Font = New System.Drawing.Font("Tahoma", 8.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblNofM.ForeColor = System.Drawing.Color.DimGray
        Me.LblNofM.Location = New System.Drawing.Point(725, 17)
        Me.LblNofM.Name = "LblNofM"
        Me.LblNofM.Size = New System.Drawing.Size(60, 15)
        Me.LblNofM.TabIndex = 14
        Me.LblNofM.Text = "000/000"
        Me.LblNofM.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'PnlButtons_Actions
        '
        Me.PnlButtons_Actions.BackColor = System.Drawing.Color.FromArgb(CType(CType(197, Byte), Integer), CType(CType(203, Byte), Integer), CType(CType(203, Byte), Integer))
        Me.PnlButtons_Actions.Controls.Add(Me.BtNew)
        Me.PnlButtons_Actions.Controls.Add(Me.BtDel)
        Me.PnlButtons_Actions.Controls.Add(Me.BtEdit)
        Me.PnlButtons_Actions.Location = New System.Drawing.Point(27, 27)
        Me.PnlButtons_Actions.Name = "PnlButtons_Actions"
        Me.PnlButtons_Actions.Size = New System.Drawing.Size(200, 62)
        Me.PnlButtons_Actions.TabIndex = 8
        Me.PnlButtons_Actions.Tag = "NO_SCAN"
        '
        'BtNew
        '
        Me.BtNew.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.BtNew.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtNew.Image = CType(resources.GetObject("BtNew.Image"), System.Drawing.Image)
        Me.BtNew.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.BtNew.Location = New System.Drawing.Point(3, 3)
        Me.BtNew.Name = "BtNew"
        Me.BtNew.Size = New System.Drawing.Size(60, 55)
        Me.BtNew.TabIndex = 0
        Me.BtNew.Tag = "new"
        Me.BtNew.Text = "Nuevo"
        Me.BtNew.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.BtNew.UseVisualStyleBackColor = True
        '
        'BtDel
        '
        Me.BtDel.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.BtDel.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtDel.Image = CType(resources.GetObject("BtDel.Image"), System.Drawing.Image)
        Me.BtDel.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.BtDel.Location = New System.Drawing.Point(135, 3)
        Me.BtDel.Name = "BtDel"
        Me.BtDel.Size = New System.Drawing.Size(60, 55)
        Me.BtDel.TabIndex = 9
        Me.BtDel.Tag = "del"
        Me.BtDel.Text = "Borrar"
        Me.BtDel.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.BtDel.UseVisualStyleBackColor = True
        '
        'BtEdit
        '
        Me.BtEdit.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.BtEdit.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtEdit.Image = CType(resources.GetObject("BtEdit.Image"), System.Drawing.Image)
        Me.BtEdit.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.BtEdit.Location = New System.Drawing.Point(69, 3)
        Me.BtEdit.Name = "BtEdit"
        Me.BtEdit.Size = New System.Drawing.Size(60, 55)
        Me.BtEdit.TabIndex = 8
        Me.BtEdit.Tag = "edit"
        Me.BtEdit.Text = "Editar"
        Me.BtEdit.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.BtEdit.UseVisualStyleBackColor = True
        '
        'PnlButtons_Move
        '
        Me.PnlButtons_Move.BackColor = System.Drawing.Color.FromArgb(CType(CType(197, Byte), Integer), CType(CType(203, Byte), Integer), CType(CType(203, Byte), Integer))
        Me.PnlButtons_Move.Controls.Add(Me.BtLast)
        Me.PnlButtons_Move.Controls.Add(Me.BtFirst)
        Me.PnlButtons_Move.Controls.Add(Me.BtNext)
        Me.PnlButtons_Move.Controls.Add(Me.BtPrevious)
        Me.PnlButtons_Move.Location = New System.Drawing.Point(231, 30)
        Me.PnlButtons_Move.Name = "PnlButtons_Move"
        Me.PnlButtons_Move.Size = New System.Drawing.Size(285, 62)
        Me.PnlButtons_Move.TabIndex = 0
        Me.PnlButtons_Move.Tag = "NO_SCAN"
        '
        'BtLast
        '
        Me.BtLast.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.BtLast.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtLast.Image = CType(resources.GetObject("BtLast.Image"), System.Drawing.Image)
        Me.BtLast.Location = New System.Drawing.Point(222, 0)
        Me.BtLast.Name = "BtLast"
        Me.BtLast.Size = New System.Drawing.Size(60, 55)
        Me.BtLast.TabIndex = 13
        Me.BtLast.Tag = "last"
        Me.BtLast.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.BtLast.UseVisualStyleBackColor = True
        '
        'BtFirst
        '
        Me.BtFirst.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.BtFirst.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtFirst.Image = CType(resources.GetObject("BtFirst.Image"), System.Drawing.Image)
        Me.BtFirst.Location = New System.Drawing.Point(3, 0)
        Me.BtFirst.Name = "BtFirst"
        Me.BtFirst.Size = New System.Drawing.Size(60, 55)
        Me.BtFirst.TabIndex = 10
        Me.BtFirst.Tag = "first"
        Me.BtFirst.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.BtFirst.UseVisualStyleBackColor = True
        '
        'BtNext
        '
        Me.BtNext.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.BtNext.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtNext.Image = CType(resources.GetObject("BtNext.Image"), System.Drawing.Image)
        Me.BtNext.Location = New System.Drawing.Point(156, 0)
        Me.BtNext.Name = "BtNext"
        Me.BtNext.Size = New System.Drawing.Size(60, 55)
        Me.BtNext.TabIndex = 12
        Me.BtNext.Tag = "next"
        Me.BtNext.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.BtNext.UseVisualStyleBackColor = True
        '
        'BtPrevious
        '
        Me.BtPrevious.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.BtPrevious.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtPrevious.Image = CType(resources.GetObject("BtPrevious.Image"), System.Drawing.Image)
        Me.BtPrevious.Location = New System.Drawing.Point(69, 0)
        Me.BtPrevious.Name = "BtPrevious"
        Me.BtPrevious.Size = New System.Drawing.Size(60, 55)
        Me.BtPrevious.TabIndex = 11
        Me.BtPrevious.Tag = "previous"
        Me.BtPrevious.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.BtPrevious.UseVisualStyleBackColor = True
        '
        'LblName
        '
        Me.LblName.BackColor = System.Drawing.Color.FromArgb(CType(CType(197, Byte), Integer), CType(CType(203, Byte), Integer), CType(CType(203, Byte), Integer))
        Me.LblName.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblName.Location = New System.Drawing.Point(529, 15)
        Me.LblName.Name = "LblName"
        Me.LblName.Size = New System.Drawing.Size(237, 23)
        Me.LblName.TabIndex = 10
        Me.LblName.Tag = ""
        Me.LblName.Text = "Label1"
        Me.LblName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label56
        '
        Label56.AutoSize = True
        Label56.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Label56.Location = New System.Drawing.Point(503, 66)
        Label56.Name = "Label56"
        Label56.Size = New System.Drawing.Size(45, 18)
        Label56.TabIndex = 165
        Label56.Text = "Usos:"
        '
        'txtN
        '
        Me.txtN.Font = New System.Drawing.Font("Tahoma", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtN.Location = New System.Drawing.Point(554, 57)
        Me.txtN.MaxLength = 15
        Me.txtN.Name = "txtN"
        Me.txtN.Size = New System.Drawing.Size(142, 33)
        Me.txtN.TabIndex = 164
        Me.txtN.Tag = "n_veces"
        '
        'frmCategorias
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Black
        Me.ClientSize = New System.Drawing.Size(1028, 760)
        Me.Controls.Add(Me.SplitContainer)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.KeyPreview = True
        Me.Name = "frmCategorias"
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
        Me.PnlAction_Buttons.ResumeLayout(False)
        Me.PnlData.ResumeLayout(False)
        Me.Tab.ResumeLayout(False)
        Me.TabPage_General.ResumeLayout(False)
        Me.TabPage_General.PerformLayout()
        Me.Group_Personalizacion.ResumeLayout(False)
        CType(Me.PicImg, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Group_User.ResumeLayout(False)
        Me.Group_User.PerformLayout()
        Me.PnlButtons_Actions.ResumeLayout(False)
        Me.PnlButtons_Move.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents SplitContainer As System.Windows.Forms.SplitContainer
    Friend WithEvents m_logo As System.Windows.Forms.PictureBox
    Friend WithEvents PnlButton_Shell As System.Windows.Forms.Panel
    Friend WithEvents BtClose As System.Windows.Forms.Button
    Friend WithEvents LblSubTitle As System.Windows.Forms.Label
    Friend WithEvents LblTitle As System.Windows.Forms.Label
    Friend WithEvents PnlBody As System.Windows.Forms.Panel
    Friend WithEvents PnlButtons_Actions As System.Windows.Forms.Panel
    Friend WithEvents BtEdit As System.Windows.Forms.Button
    Friend WithEvents BtDel As System.Windows.Forms.Button
    Friend WithEvents BtLast As System.Windows.Forms.Button
    Friend WithEvents BtNext As System.Windows.Forms.Button
    Friend WithEvents BtPrevious As System.Windows.Forms.Button
    Friend WithEvents BtFirst As System.Windows.Forms.Button
    Friend WithEvents LblName As System.Windows.Forms.Label
    Friend WithEvents PnlButtons_Move As System.Windows.Forms.Panel
    Friend WithEvents BtNew As System.Windows.Forms.Button
    Friend WithEvents LblNofM As System.Windows.Forms.Label
    Friend WithEvents BtOk As System.Windows.Forms.Button
    Friend WithEvents BtCancell As System.Windows.Forms.Button
    Friend WithEvents Tab As System.Windows.Forms.TabControl
    Friend WithEvents TabPage_General As System.Windows.Forms.TabPage
    Friend WithEvents LblId As System.Windows.Forms.Label
    Friend WithEvents PnlData As System.Windows.Forms.Panel
    Friend WithEvents PnlAction_Buttons As System.Windows.Forms.Panel
    Friend WithEvents TxtName As System.Windows.Forms.TextBox
    Friend WithEvents Group_User As System.Windows.Forms.GroupBox
    Friend WithEvents ImageList_Grid As System.Windows.Forms.ImageList
    Friend WithEvents LblFh_Alta As System.Windows.Forms.Label
    Friend WithEvents LblFh_Alta_nfo As System.Windows.Forms.Label
    Friend WithEvents Group_Personalizacion As System.Windows.Forms.GroupBox
    Friend WithEvents PicImg As System.Windows.Forms.PictureBox
    Friend WithEvents LnkDelImg As System.Windows.Forms.LinkLabel
    Friend WithEvents BtSelectImg As System.Windows.Forms.Button
    Friend WithEvents chkPedidos As System.Windows.Forms.CheckBox
    Friend WithEvents CheckBox1 As System.Windows.Forms.CheckBox
    Friend WithEvents CheckBox2 As System.Windows.Forms.CheckBox
    Friend WithEvents CbCategoria As System.Windows.Forms.ComboBox
    Friend WithEvents txtN As System.Windows.Forms.TextBox
End Class
