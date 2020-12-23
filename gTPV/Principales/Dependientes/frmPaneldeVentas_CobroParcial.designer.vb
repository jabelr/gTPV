<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmPaneldeVentas_CobroParcial
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmPaneldeVentas_CobroParcial))
        Me.PnlAction_Buttons = New System.Windows.Forms.Panel()
        Me.BtCobraPrint = New System.Windows.Forms.Button()
        Me.BtCobra = New System.Windows.Forms.Button()
        Me.LblName = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.LblTotal_Original = New System.Windows.Forms.Label()
        Me.PnlCambio = New System.Windows.Forms.Panel()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.LblTotal_Parcial = New System.Windows.Forms.Label()
        Me.LstTicket_Parcial = New System.Windows.Forms.ListView()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.BtMove_Left = New System.Windows.Forms.Button()
        Me.BtMove_Menos = New System.Windows.Forms.Button()
        Me.BtMove_Mas = New System.Windows.Forms.Button()
        Me.BtMove_Right = New System.Windows.Forms.Button()
        Me.LstTicket_Original = New System.Windows.Forms.ListView()
        Me.LblInfo = New System.Windows.Forms.Label()
        Me.SplitContainer = New System.Windows.Forms.SplitContainer()
        Me.m_logo = New System.Windows.Forms.PictureBox()
        Me.PnlButton_Shell = New System.Windows.Forms.Panel()
        Me.BtCobrar = New System.Windows.Forms.Button()
        Me.BtClose = New System.Windows.Forms.Button()
        Me.LblSubTitle = New System.Windows.Forms.Label()
        Me.LblTitle = New System.Windows.Forms.Label()
        Me.PnlBody = New System.Windows.Forms.Panel()
        Me.BtImg_Next = New System.Windows.Forms.Button()
        Me.BtImg_Previous = New System.Windows.Forms.Button()
        Me.PnlData = New System.Windows.Forms.Panel()
        Me.PnlGaleria = New System.Windows.Forms.Panel()
        Me.TmrAvisoPvp = New System.Windows.Forms.Timer(Me.components)
        Me.btCobraTarjeta = New System.Windows.Forms.Button()
        Me.PnlAction_Buttons.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.PnlCambio.SuspendLayout()
        Me.SplitContainer.Panel1.SuspendLayout()
        Me.SplitContainer.Panel2.SuspendLayout()
        Me.SplitContainer.SuspendLayout()
        CType(Me.m_logo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PnlButton_Shell.SuspendLayout()
        Me.PnlBody.SuspendLayout()
        Me.PnlData.SuspendLayout()
        Me.SuspendLayout()
        '
        'PnlAction_Buttons
        '
        Me.PnlAction_Buttons.BackColor = System.Drawing.Color.FromArgb(CType(CType(174, Byte), Integer), CType(CType(186, Byte), Integer), CType(CType(186, Byte), Integer))
        Me.PnlAction_Buttons.Controls.Add(Me.BtCobraPrint)
        Me.PnlAction_Buttons.Controls.Add(Me.BtCobra)
        Me.PnlAction_Buttons.Location = New System.Drawing.Point(651, 3)
        Me.PnlAction_Buttons.Name = "PnlAction_Buttons"
        Me.PnlAction_Buttons.Size = New System.Drawing.Size(300, 63)
        Me.PnlAction_Buttons.TabIndex = 2
        Me.PnlAction_Buttons.Tag = "NO_SCAN"
        Me.PnlAction_Buttons.Visible = False
        '
        'BtCobraPrint
        '
        Me.BtCobraPrint.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtCobraPrint.Image = CType(resources.GetObject("BtCobraPrint.Image"), System.Drawing.Image)
        Me.BtCobraPrint.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtCobraPrint.Location = New System.Drawing.Point(153, 3)
        Me.BtCobraPrint.Name = "BtCobraPrint"
        Me.BtCobraPrint.Size = New System.Drawing.Size(144, 58)
        Me.BtCobraPrint.TabIndex = 35
        Me.BtCobraPrint.Text = "Cobrar e Imprimir!"
        Me.BtCobraPrint.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BtCobraPrint.UseVisualStyleBackColor = True
        '
        'BtCobra
        '
        Me.BtCobra.Font = New System.Drawing.Font("Tahoma", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtCobra.Image = CType(resources.GetObject("BtCobra.Image"), System.Drawing.Image)
        Me.BtCobra.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtCobra.Location = New System.Drawing.Point(3, 3)
        Me.BtCobra.Name = "BtCobra"
        Me.BtCobra.Size = New System.Drawing.Size(144, 58)
        Me.BtCobra.TabIndex = 36
        Me.BtCobra.Text = "Cobrar!"
        Me.BtCobra.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BtCobra.UseVisualStyleBackColor = True
        '
        'LblName
        '
        Me.LblName.BackColor = System.Drawing.Color.Transparent
        Me.LblName.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblName.Location = New System.Drawing.Point(59, 43)
        Me.LblName.Name = "LblName"
        Me.LblName.Size = New System.Drawing.Size(208, 34)
        Me.LblName.TabIndex = 35
        Me.LblName.Text = "Cobro Parcial"
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Controls.Add(Me.LblTotal_Original)
        Me.Panel1.Location = New System.Drawing.Point(3, 313)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(288, 48)
        Me.Panel1.TabIndex = 63
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.Label3.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(8, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(54, 13)
        Me.Label3.TabIndex = 60
        Me.Label3.Text = "Importe"
        '
        'LblTotal_Original
        '
        Me.LblTotal_Original.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.LblTotal_Original.Font = New System.Drawing.Font("Verdana", 24.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblTotal_Original.ForeColor = System.Drawing.SystemColors.InactiveCaption
        Me.LblTotal_Original.Location = New System.Drawing.Point(19, 2)
        Me.LblTotal_Original.Name = "LblTotal_Original"
        Me.LblTotal_Original.Size = New System.Drawing.Size(261, 39)
        Me.LblTotal_Original.TabIndex = 61
        Me.LblTotal_Original.Text = "0,00 €"
        Me.LblTotal_Original.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'PnlCambio
        '
        Me.PnlCambio.BackColor = System.Drawing.SystemColors.InactiveCaption
        Me.PnlCambio.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.PnlCambio.Controls.Add(Me.Label2)
        Me.PnlCambio.Controls.Add(Me.LblTotal_Parcial)
        Me.PnlCambio.Location = New System.Drawing.Point(3, 20)
        Me.PnlCambio.Name = "PnlCambio"
        Me.PnlCambio.Size = New System.Drawing.Size(288, 48)
        Me.PnlCambio.TabIndex = 62
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.SystemColors.InactiveCaption
        Me.Label2.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(8, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(54, 13)
        Me.Label2.TabIndex = 60
        Me.Label2.Text = "Importe"
        '
        'LblTotal_Parcial
        '
        Me.LblTotal_Parcial.BackColor = System.Drawing.SystemColors.InactiveCaption
        Me.LblTotal_Parcial.Font = New System.Drawing.Font("Verdana", 24.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblTotal_Parcial.ForeColor = System.Drawing.SystemColors.Highlight
        Me.LblTotal_Parcial.Location = New System.Drawing.Point(19, 2)
        Me.LblTotal_Parcial.Name = "LblTotal_Parcial"
        Me.LblTotal_Parcial.Size = New System.Drawing.Size(261, 39)
        Me.LblTotal_Parcial.TabIndex = 61
        Me.LblTotal_Parcial.Text = "0,00 €"
        Me.LblTotal_Parcial.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'LstTicket_Parcial
        '
        Me.LstTicket_Parcial.BackColor = System.Drawing.Color.Beige
        Me.LstTicket_Parcial.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LstTicket_Parcial.FullRowSelect = True
        Me.LstTicket_Parcial.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable
        Me.LstTicket_Parcial.HideSelection = False
        Me.LstTicket_Parcial.Location = New System.Drawing.Point(3, 69)
        Me.LstTicket_Parcial.MultiSelect = False
        Me.LstTicket_Parcial.Name = "LstTicket_Parcial"
        Me.LstTicket_Parcial.Size = New System.Drawing.Size(288, 219)
        Me.LstTicket_Parcial.TabIndex = 33
        Me.LstTicket_Parcial.UseCompatibleStateImageBehavior = False
        Me.LstTicket_Parcial.View = System.Windows.Forms.View.Details
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.LightSteelBlue
        Me.Label1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Label1.Location = New System.Drawing.Point(3, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(288, 19)
        Me.Label1.TabIndex = 34
        Me.Label1.Text = "TICKET PARCIAL"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'BtMove_Left
        '
        Me.BtMove_Left.BackColor = System.Drawing.SystemColors.Control
        Me.BtMove_Left.Enabled = False
        Me.BtMove_Left.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtMove_Left.Image = CType(resources.GetObject("BtMove_Left.Image"), System.Drawing.Image)
        Me.BtMove_Left.Location = New System.Drawing.Point(249, 363)
        Me.BtMove_Left.Name = "BtMove_Left"
        Me.BtMove_Left.Size = New System.Drawing.Size(60, 54)
        Me.BtMove_Left.TabIndex = 32
        Me.BtMove_Left.Tag = ""
        Me.BtMove_Left.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtMove_Left.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage
        Me.BtMove_Left.UseVisualStyleBackColor = False
        Me.BtMove_Left.Visible = False
        '
        'BtMove_Menos
        '
        Me.BtMove_Menos.BackColor = System.Drawing.SystemColors.Control
        Me.BtMove_Menos.Enabled = False
        Me.BtMove_Menos.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtMove_Menos.Image = CType(resources.GetObject("BtMove_Menos.Image"), System.Drawing.Image)
        Me.BtMove_Menos.Location = New System.Drawing.Point(249, 303)
        Me.BtMove_Menos.Name = "BtMove_Menos"
        Me.BtMove_Menos.Size = New System.Drawing.Size(60, 54)
        Me.BtMove_Menos.TabIndex = 31
        Me.BtMove_Menos.Tag = ""
        Me.BtMove_Menos.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BtMove_Menos.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.BtMove_Menos.UseVisualStyleBackColor = False
        Me.BtMove_Menos.Visible = False
        '
        'BtMove_Mas
        '
        Me.BtMove_Mas.BackColor = System.Drawing.SystemColors.Control
        Me.BtMove_Mas.Enabled = False
        Me.BtMove_Mas.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtMove_Mas.Image = CType(resources.GetObject("BtMove_Mas.Image"), System.Drawing.Image)
        Me.BtMove_Mas.Location = New System.Drawing.Point(249, 243)
        Me.BtMove_Mas.Name = "BtMove_Mas"
        Me.BtMove_Mas.Size = New System.Drawing.Size(60, 54)
        Me.BtMove_Mas.TabIndex = 30
        Me.BtMove_Mas.Tag = ""
        Me.BtMove_Mas.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtMove_Mas.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage
        Me.BtMove_Mas.UseVisualStyleBackColor = False
        Me.BtMove_Mas.Visible = False
        '
        'BtMove_Right
        '
        Me.BtMove_Right.BackColor = System.Drawing.SystemColors.Control
        Me.BtMove_Right.Enabled = False
        Me.BtMove_Right.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtMove_Right.Image = CType(resources.GetObject("BtMove_Right.Image"), System.Drawing.Image)
        Me.BtMove_Right.Location = New System.Drawing.Point(249, 183)
        Me.BtMove_Right.Name = "BtMove_Right"
        Me.BtMove_Right.Size = New System.Drawing.Size(60, 54)
        Me.BtMove_Right.TabIndex = 29
        Me.BtMove_Right.Tag = ""
        Me.BtMove_Right.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BtMove_Right.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.BtMove_Right.UseVisualStyleBackColor = False
        Me.BtMove_Right.Visible = False
        '
        'LstTicket_Original
        '
        Me.LstTicket_Original.BackColor = System.Drawing.Color.Beige
        Me.LstTicket_Original.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LstTicket_Original.FullRowSelect = True
        Me.LstTicket_Original.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable
        Me.LstTicket_Original.Location = New System.Drawing.Point(3, 362)
        Me.LstTicket_Original.MultiSelect = False
        Me.LstTicket_Original.Name = "LstTicket_Original"
        Me.LstTicket_Original.Size = New System.Drawing.Size(288, 219)
        Me.LstTicket_Original.TabIndex = 27
        Me.LstTicket_Original.UseCompatibleStateImageBehavior = False
        Me.LstTicket_Original.View = System.Windows.Forms.View.Details
        '
        'LblInfo
        '
        Me.LblInfo.BackColor = System.Drawing.Color.CornflowerBlue
        Me.LblInfo.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblInfo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.LblInfo.Location = New System.Drawing.Point(3, 293)
        Me.LblInfo.Name = "LblInfo"
        Me.LblInfo.Size = New System.Drawing.Size(288, 19)
        Me.LblInfo.TabIndex = 28
        Me.LblInfo.Text = "TICKET ORIGINAL"
        Me.LblInfo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
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
        Me.SplitContainer.Panel2.BackColor = System.Drawing.Color.Black
        Me.SplitContainer.Panel2.Controls.Add(Me.PnlBody)
        Me.SplitContainer.Panel2.Tag = "233; 248; 250"
        Me.SplitContainer.Size = New System.Drawing.Size(1028, 760)
        Me.SplitContainer.SplitterDistance = 64
        Me.SplitContainer.SplitterWidth = 1
        Me.SplitContainer.TabIndex = 36
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
        Me.PnlButton_Shell.Controls.Add(Me.btCobraTarjeta)
        Me.PnlButton_Shell.Controls.Add(Me.BtCobrar)
        Me.PnlButton_Shell.Controls.Add(Me.BtClose)
        Me.PnlButton_Shell.Dock = System.Windows.Forms.DockStyle.Right
        Me.PnlButton_Shell.Location = New System.Drawing.Point(478, 0)
        Me.PnlButton_Shell.Name = "PnlButton_Shell"
        Me.PnlButton_Shell.Size = New System.Drawing.Size(550, 64)
        Me.PnlButton_Shell.TabIndex = 2
        '
        'BtCobrar
        '
        Me.BtCobrar.Enabled = False
        Me.BtCobrar.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.BtCobrar.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtCobrar.Image = CType(resources.GetObject("BtCobrar.Image"), System.Drawing.Image)
        Me.BtCobrar.Location = New System.Drawing.Point(190, 4)
        Me.BtCobrar.Name = "BtCobrar"
        Me.BtCobrar.Size = New System.Drawing.Size(170, 58)
        Me.BtCobrar.TabIndex = 8
        Me.BtCobrar.Tag = "cobrar"
        Me.BtCobrar.Text = "Cobrar"
        Me.BtCobrar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.BtCobrar.UseVisualStyleBackColor = True
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
        Me.LblSubTitle.Location = New System.Drawing.Point(64, 30)
        Me.LblSubTitle.Name = "LblSubTitle"
        Me.LblSubTitle.Size = New System.Drawing.Size(352, 31)
        Me.LblSubTitle.TabIndex = 1
        Me.LblSubTitle.Text = "Cobro parcial del Ticket actual" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Realize click sobre el artículo para traspasar 1" & _
            " unidad entre tickets"
        '
        'LblTitle
        '
        Me.LblTitle.AutoSize = True
        Me.LblTitle.Font = New System.Drawing.Font("Tahoma", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblTitle.Location = New System.Drawing.Point(57, 4)
        Me.LblTitle.Name = "LblTitle"
        Me.LblTitle.Size = New System.Drawing.Size(137, 23)
        Me.LblTitle.TabIndex = 0
        Me.LblTitle.Text = "Cobro Parcial"
        '
        'PnlBody
        '
        Me.PnlBody.BackColor = System.Drawing.SystemColors.Control
        Me.PnlBody.BackgroundImage = CType(resources.GetObject("PnlBody.BackgroundImage"), System.Drawing.Image)
        Me.PnlBody.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PnlBody.Controls.Add(Me.BtImg_Next)
        Me.PnlBody.Controls.Add(Me.BtImg_Previous)
        Me.PnlBody.Controls.Add(Me.PnlAction_Buttons)
        Me.PnlBody.Controls.Add(Me.LblName)
        Me.PnlBody.Controls.Add(Me.PnlData)
        Me.PnlBody.Controls.Add(Me.PnlGaleria)
        Me.PnlBody.ForeColor = System.Drawing.Color.Black
        Me.PnlBody.Location = New System.Drawing.Point(12, 14)
        Me.PnlBody.Name = "PnlBody"
        Me.PnlBody.Size = New System.Drawing.Size(982, 669)
        Me.PnlBody.TabIndex = 0
        Me.PnlBody.Visible = False
        '
        'BtImg_Next
        '
        Me.BtImg_Next.BackColor = System.Drawing.SystemColors.Control
        Me.BtImg_Next.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtImg_Next.Image = CType(resources.GetObject("BtImg_Next.Image"), System.Drawing.Image)
        Me.BtImg_Next.Location = New System.Drawing.Point(482, 23)
        Me.BtImg_Next.Name = "BtImg_Next"
        Me.BtImg_Next.Size = New System.Drawing.Size(60, 54)
        Me.BtImg_Next.TabIndex = 41
        Me.BtImg_Next.Tag = ""
        Me.BtImg_Next.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtImg_Next.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage
        Me.BtImg_Next.UseVisualStyleBackColor = False
        '
        'BtImg_Previous
        '
        Me.BtImg_Previous.BackColor = System.Drawing.SystemColors.Control
        Me.BtImg_Previous.Enabled = False
        Me.BtImg_Previous.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtImg_Previous.Image = CType(resources.GetObject("BtImg_Previous.Image"), System.Drawing.Image)
        Me.BtImg_Previous.Location = New System.Drawing.Point(416, 23)
        Me.BtImg_Previous.Name = "BtImg_Previous"
        Me.BtImg_Previous.Size = New System.Drawing.Size(60, 54)
        Me.BtImg_Previous.TabIndex = 40
        Me.BtImg_Previous.Tag = ""
        Me.BtImg_Previous.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BtImg_Previous.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.BtImg_Previous.UseVisualStyleBackColor = False
        '
        'PnlData
        '
        Me.PnlData.BackColor = System.Drawing.Color.FromArgb(CType(CType(174, Byte), Integer), CType(CType(186, Byte), Integer), CType(CType(186, Byte), Integer))
        Me.PnlData.Controls.Add(Me.BtMove_Right)
        Me.PnlData.Controls.Add(Me.BtMove_Left)
        Me.PnlData.Controls.Add(Me.BtMove_Mas)
        Me.PnlData.Controls.Add(Me.BtMove_Menos)
        Me.PnlData.Controls.Add(Me.Panel1)
        Me.PnlData.Controls.Add(Me.PnlCambio)
        Me.PnlData.Controls.Add(Me.LblInfo)
        Me.PnlData.Controls.Add(Me.LstTicket_Parcial)
        Me.PnlData.Controls.Add(Me.LstTicket_Original)
        Me.PnlData.Controls.Add(Me.Label1)
        Me.PnlData.Location = New System.Drawing.Point(648, 43)
        Me.PnlData.Name = "PnlData"
        Me.PnlData.Size = New System.Drawing.Size(295, 585)
        Me.PnlData.TabIndex = 38
        '
        'PnlGaleria
        '
        Me.PnlGaleria.BackColor = System.Drawing.Color.FromArgb(CType(CType(174, Byte), Integer), CType(CType(186, Byte), Integer), CType(CType(186, Byte), Integer))
        Me.PnlGaleria.Location = New System.Drawing.Point(54, 95)
        Me.PnlGaleria.Name = "PnlGaleria"
        Me.PnlGaleria.Size = New System.Drawing.Size(577, 532)
        Me.PnlGaleria.TabIndex = 39
        '
        'TmrAvisoPvp
        '
        Me.TmrAvisoPvp.Interval = 600
        '
        'btCobraTarjeta
        '
        Me.btCobraTarjeta.Enabled = False
        Me.btCobraTarjeta.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btCobraTarjeta.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btCobraTarjeta.Image = CType(resources.GetObject("btCobraTarjeta.Image"), System.Drawing.Image)
        Me.btCobraTarjeta.Location = New System.Drawing.Point(14, 3)
        Me.btCobraTarjeta.Name = "btCobraTarjeta"
        Me.btCobraTarjeta.Size = New System.Drawing.Size(170, 58)
        Me.btCobraTarjeta.TabIndex = 9
        Me.btCobraTarjeta.Tag = "tarjeta"
        Me.btCobraTarjeta.Text = "Tarjeta"
        Me.btCobraTarjeta.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btCobraTarjeta.UseVisualStyleBackColor = True
        '
        'frmPaneldeVentas_CobroParcial
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Black
        Me.ClientSize = New System.Drawing.Size(1028, 760)
        Me.Controls.Add(Me.SplitContainer)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmPaneldeVentas_CobroParcial"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.Text = "Cobro Parcial del Ticket"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.PnlAction_Buttons.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.PnlCambio.ResumeLayout(False)
        Me.PnlCambio.PerformLayout()
        Me.SplitContainer.Panel1.ResumeLayout(False)
        Me.SplitContainer.Panel1.PerformLayout()
        Me.SplitContainer.Panel2.ResumeLayout(False)
        Me.SplitContainer.ResumeLayout(False)
        CType(Me.m_logo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PnlButton_Shell.ResumeLayout(False)
        Me.PnlBody.ResumeLayout(False)
        Me.PnlData.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents PnlAction_Buttons As System.Windows.Forms.Panel
    Friend WithEvents LblName As System.Windows.Forms.Label
    Friend WithEvents BtMove_Mas As System.Windows.Forms.Button
    Friend WithEvents BtMove_Right As System.Windows.Forms.Button
    Friend WithEvents LstTicket_Original As System.Windows.Forms.ListView
    Friend WithEvents LblInfo As System.Windows.Forms.Label
    Friend WithEvents LstTicket_Parcial As System.Windows.Forms.ListView
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents BtMove_Left As System.Windows.Forms.Button
    Friend WithEvents BtMove_Menos As System.Windows.Forms.Button
    Friend WithEvents BtCobraPrint As System.Windows.Forms.Button
    Friend WithEvents BtCobra As System.Windows.Forms.Button
    Friend WithEvents PnlCambio As System.Windows.Forms.Panel
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents LblTotal_Parcial As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents LblTotal_Original As System.Windows.Forms.Label
    Friend WithEvents SplitContainer As System.Windows.Forms.SplitContainer
    Friend WithEvents m_logo As System.Windows.Forms.PictureBox
    Friend WithEvents PnlButton_Shell As System.Windows.Forms.Panel
    Friend WithEvents BtClose As System.Windows.Forms.Button
    Friend WithEvents LblSubTitle As System.Windows.Forms.Label
    Friend WithEvents LblTitle As System.Windows.Forms.Label
    Friend WithEvents PnlBody As System.Windows.Forms.Panel
    Friend WithEvents PnlData As System.Windows.Forms.Panel
    Friend WithEvents PnlGaleria As System.Windows.Forms.Panel
    Friend WithEvents BtImg_Next As System.Windows.Forms.Button
    Friend WithEvents BtImg_Previous As System.Windows.Forms.Button
    Friend WithEvents TmrAvisoPvp As System.Windows.Forms.Timer
    Friend WithEvents BtCobrar As System.Windows.Forms.Button
    Friend WithEvents btCobraTarjeta As System.Windows.Forms.Button
End Class
