<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class m_Shell
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(m_Shell))
        Me.SplitContainer = New System.Windows.Forms.SplitContainer()
        Me.m_logo = New System.Windows.Forms.PictureBox()
        Me.PnlButton_Shell = New System.Windows.Forms.Panel()
        Me.BtClose = New System.Windows.Forms.Button()
        Me.BtMin = New System.Windows.Forms.Button()
        Me.LblSubTitle = New System.Windows.Forms.Label()
        Me.LblTitle = New System.Windows.Forms.Label()
        Me.PnlBody = New System.Windows.Forms.Panel()
        Me.LblSQL = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.BtExport = New System.Windows.Forms.Button()
        Me.PnlButtons_Controls = New System.Windows.Forms.Panel()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.CbConditionalFilter = New System.Windows.Forms.ComboBox()
        Me.TxtFilter = New System.Windows.Forms.TextBox()
        Me.CbFilter = New System.Windows.Forms.ComboBox()
        Me.BtKeyBoard = New System.Windows.Forms.Button()
        Me.BtFilter = New System.Windows.Forms.Button()
        Me.LblNofM = New System.Windows.Forms.Label()
        Me.PnlButtons_Actions = New System.Windows.Forms.Panel()
        Me.BtNew = New System.Windows.Forms.Button()
        Me.BtDel = New System.Windows.Forms.Button()
        Me.BtShow = New System.Windows.Forms.Button()
        Me.BtEdit = New System.Windows.Forms.Button()
        Me.PnlButtons_Move = New System.Windows.Forms.Panel()
        Me.BtLast = New System.Windows.Forms.Button()
        Me.BtFirst = New System.Windows.Forms.Button()
        Me.BtNext = New System.Windows.Forms.Button()
        Me.BtPrevious = New System.Windows.Forms.Button()
        Me.LblName = New System.Windows.Forms.Label()
        Me.datagrid = New System.Windows.Forms.DataGridView()
        Me.SplitContainer.Panel1.SuspendLayout()
        Me.SplitContainer.Panel2.SuspendLayout()
        Me.SplitContainer.SuspendLayout()
        CType(Me.m_logo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PnlButton_Shell.SuspendLayout()
        Me.PnlBody.SuspendLayout()
        Me.PnlButtons_Controls.SuspendLayout()
        Me.PnlButtons_Actions.SuspendLayout()
        Me.PnlButtons_Move.SuspendLayout()
        CType(Me.datagrid, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.PnlButton_Shell.Controls.Add(Me.BtMin)
        Me.PnlButton_Shell.Dock = System.Windows.Forms.DockStyle.Right
        Me.PnlButton_Shell.Location = New System.Drawing.Point(478, 0)
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
        Me.BtMin.Location = New System.Drawing.Point(192, 4)
        Me.BtMin.Name = "BtMin"
        Me.BtMin.Size = New System.Drawing.Size(170, 58)
        Me.BtMin.TabIndex = 6
        Me.BtMin.Tag = "minimize"
        Me.BtMin.Text = "Minimizar"
        Me.BtMin.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.BtMin.UseVisualStyleBackColor = True
        '
        'LblSubTitle
        '
        Me.LblSubTitle.AutoSize = True
        Me.LblSubTitle.ForeColor = System.Drawing.SystemColors.InactiveCaption
        Me.LblSubTitle.Location = New System.Drawing.Point(64, 31)
        Me.LblSubTitle.Name = "LblSubTitle"
        Me.LblSubTitle.Size = New System.Drawing.Size(329, 13)
        Me.LblSubTitle.TabIndex = 1
        Me.LblSubTitle.Text = "Software de control, administración y ventas de locales de hosteleria" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        '
        'LblTitle
        '
        Me.LblTitle.AutoSize = True
        Me.LblTitle.Font = New System.Drawing.Font("Tahoma", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblTitle.Location = New System.Drawing.Point(57, 5)
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
        Me.PnlBody.Controls.Add(Me.LblSQL)
        Me.PnlBody.Controls.Add(Me.Label4)
        Me.PnlBody.Controls.Add(Me.BtExport)
        Me.PnlBody.Controls.Add(Me.PnlButtons_Controls)
        Me.PnlBody.Controls.Add(Me.LblNofM)
        Me.PnlBody.Controls.Add(Me.PnlButtons_Actions)
        Me.PnlBody.Controls.Add(Me.PnlButtons_Move)
        Me.PnlBody.Controls.Add(Me.LblName)
        Me.PnlBody.Controls.Add(Me.datagrid)
        Me.PnlBody.ForeColor = System.Drawing.Color.Black
        Me.PnlBody.Location = New System.Drawing.Point(12, 14)
        Me.PnlBody.Name = "PnlBody"
        Me.PnlBody.Size = New System.Drawing.Size(981, 669)
        Me.PnlBody.TabIndex = 0
        Me.PnlBody.Visible = False
        '
        'LblSQL
        '
        Me.LblSQL.BackColor = System.Drawing.Color.FromArgb(CType(CType(174, Byte), Integer), CType(CType(186, Byte), Integer), CType(CType(186, Byte), Integer))
        Me.LblSQL.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblSQL.Location = New System.Drawing.Point(327, 628)
        Me.LblSQL.Name = "LblSQL"
        Me.LblSQL.Size = New System.Drawing.Size(608, 13)
        Me.LblSQL.TabIndex = 23
        Me.LblSQL.Text = "sql"
        Me.LblSQL.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.LblSQL.Visible = False
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.FromArgb(CType(CType(174, Byte), Integer), CType(CType(186, Byte), Integer), CType(CType(186, Byte), Integer))
        Me.Label4.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(50, 628)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(271, 13)
        Me.Label4.TabIndex = 22
        Me.Label4.Text = "Haga Doble Click en el elemento para mostrar"
        '
        'BtExport
        '
        Me.BtExport.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.BtExport.Font = New System.Drawing.Font("Tahoma", 8.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtExport.Image = CType(resources.GetObject("BtExport.Image"), System.Drawing.Image)
        Me.BtExport.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BtExport.Location = New System.Drawing.Point(74, -5)
        Me.BtExport.Name = "BtExport"
        Me.BtExport.Size = New System.Drawing.Size(94, 36)
        Me.BtExport.TabIndex = 19
        Me.BtExport.Tag = "export"
        Me.BtExport.Text = "Exportar"
        Me.BtExport.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtExport.UseVisualStyleBackColor = True
        Me.BtExport.Visible = False
        '
        'PnlButtons_Controls
        '
        Me.PnlButtons_Controls.BackColor = System.Drawing.Color.FromArgb(CType(CType(197, Byte), Integer), CType(CType(203, Byte), Integer), CType(CType(203, Byte), Integer))
        Me.PnlButtons_Controls.Controls.Add(Me.Label3)
        Me.PnlButtons_Controls.Controls.Add(Me.Label2)
        Me.PnlButtons_Controls.Controls.Add(Me.Label1)
        Me.PnlButtons_Controls.Controls.Add(Me.CbConditionalFilter)
        Me.PnlButtons_Controls.Controls.Add(Me.TxtFilter)
        Me.PnlButtons_Controls.Controls.Add(Me.CbFilter)
        Me.PnlButtons_Controls.Controls.Add(Me.BtKeyBoard)
        Me.PnlButtons_Controls.Controls.Add(Me.BtFilter)
        Me.PnlButtons_Controls.Location = New System.Drawing.Point(521, 16)
        Me.PnlButtons_Controls.Name = "PnlButtons_Controls"
        Me.PnlButtons_Controls.Size = New System.Drawing.Size(434, 79)
        Me.PnlButtons_Controls.TabIndex = 20
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(243, 14)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(26, 13)
        Me.Label3.TabIndex = 23
        Me.Label3.Text = "por"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(3, 14)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(46, 13)
        Me.Label2.TabIndex = 22
        Me.Label2.Text = "Buscar"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(3, 54)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(40, 13)
        Me.Label1.TabIndex = 21
        Me.Label1.Text = "Filtrar"
        '
        'CbConditionalFilter
        '
        Me.CbConditionalFilter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CbConditionalFilter.Font = New System.Drawing.Font("Tahoma", 15.75!)
        Me.CbConditionalFilter.FormattingEnabled = True
        Me.CbConditionalFilter.Location = New System.Drawing.Point(55, 43)
        Me.CbConditionalFilter.Name = "CbConditionalFilter"
        Me.CbConditionalFilter.Size = New System.Drawing.Size(214, 33)
        Me.CbConditionalFilter.TabIndex = 20
        '
        'TxtFilter
        '
        Me.TxtFilter.Font = New System.Drawing.Font("Tahoma", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtFilter.Location = New System.Drawing.Point(55, 1)
        Me.TxtFilter.Name = "TxtFilter"
        Me.TxtFilter.Size = New System.Drawing.Size(182, 33)
        Me.TxtFilter.TabIndex = 0
        '
        'CbFilter
        '
        Me.CbFilter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CbFilter.Font = New System.Drawing.Font("Tahoma", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CbFilter.FormattingEnabled = True
        Me.CbFilter.Items.AddRange(New Object() {"Referencia", "Nombre"})
        Me.CbFilter.Location = New System.Drawing.Point(275, 1)
        Me.CbFilter.Name = "CbFilter"
        Me.CbFilter.Size = New System.Drawing.Size(156, 33)
        Me.CbFilter.TabIndex = 1
        '
        'BtKeyBoard
        '
        Me.BtKeyBoard.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.BtKeyBoard.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtKeyBoard.Image = CType(resources.GetObject("BtKeyBoard.Image"), System.Drawing.Image)
        Me.BtKeyBoard.Location = New System.Drawing.Point(275, 40)
        Me.BtKeyBoard.Name = "BtKeyBoard"
        Me.BtKeyBoard.Size = New System.Drawing.Size(38, 38)
        Me.BtKeyBoard.TabIndex = 2
        Me.BtKeyBoard.Tag = "last"
        Me.BtKeyBoard.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.BtKeyBoard.UseVisualStyleBackColor = True
        '
        'BtFilter
        '
        Me.BtFilter.Enabled = False
        Me.BtFilter.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.BtFilter.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtFilter.Image = CType(resources.GetObject("BtFilter.Image"), System.Drawing.Image)
        Me.BtFilter.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtFilter.Location = New System.Drawing.Point(319, 40)
        Me.BtFilter.Name = "BtFilter"
        Me.BtFilter.Size = New System.Drawing.Size(112, 38)
        Me.BtFilter.TabIndex = 3
        Me.BtFilter.Tag = "last"
        Me.BtFilter.Text = "Buscar!!!"
        Me.BtFilter.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BtFilter.UseVisualStyleBackColor = True
        '
        'LblNofM
        '
        Me.LblNofM.BackColor = System.Drawing.Color.FromArgb(CType(CType(197, Byte), Integer), CType(CType(203, Byte), Integer), CType(CType(203, Byte), Integer))
        Me.LblNofM.Font = New System.Drawing.Font("Tahoma", 8.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblNofM.ForeColor = System.Drawing.Color.DimGray
        Me.LblNofM.Location = New System.Drawing.Point(458, 26)
        Me.LblNofM.Name = "LblNofM"
        Me.LblNofM.Size = New System.Drawing.Size(55, 13)
        Me.LblNofM.TabIndex = 14
        Me.LblNofM.Text = "000/000"
        Me.LblNofM.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'PnlButtons_Actions
        '
        Me.PnlButtons_Actions.BackColor = System.Drawing.Color.FromArgb(CType(CType(197, Byte), Integer), CType(CType(203, Byte), Integer), CType(CType(203, Byte), Integer))
        Me.PnlButtons_Actions.Controls.Add(Me.BtNew)
        Me.PnlButtons_Actions.Controls.Add(Me.BtDel)
        Me.PnlButtons_Actions.Controls.Add(Me.BtShow)
        Me.PnlButtons_Actions.Controls.Add(Me.BtEdit)
        Me.PnlButtons_Actions.Location = New System.Drawing.Point(27, 27)
        Me.PnlButtons_Actions.Name = "PnlButtons_Actions"
        Me.PnlButtons_Actions.Size = New System.Drawing.Size(200, 62)
        Me.PnlButtons_Actions.TabIndex = 8
        '
        'BtNew
        '
        Me.BtNew.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.BtNew.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtNew.Image = CType(resources.GetObject("BtNew.Image"), System.Drawing.Image)
        Me.BtNew.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.BtNew.Location = New System.Drawing.Point(69, 3)
        Me.BtNew.Name = "BtNew"
        Me.BtNew.Size = New System.Drawing.Size(60, 55)
        Me.BtNew.TabIndex = 10
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
        'BtShow
        '
        Me.BtShow.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.BtShow.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtShow.Image = CType(resources.GetObject("BtShow.Image"), System.Drawing.Image)
        Me.BtShow.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.BtShow.Location = New System.Drawing.Point(3, 3)
        Me.BtShow.Name = "BtShow"
        Me.BtShow.Size = New System.Drawing.Size(60, 55)
        Me.BtShow.TabIndex = 11
        Me.BtShow.Tag = "show"
        Me.BtShow.Text = "Mostrar"
        Me.BtShow.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.BtShow.UseVisualStyleBackColor = True
        '
        'BtEdit
        '
        Me.BtEdit.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.BtEdit.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtEdit.Image = CType(resources.GetObject("BtEdit.Image"), System.Drawing.Image)
        Me.BtEdit.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.BtEdit.Location = New System.Drawing.Point(3, 3)
        Me.BtEdit.Name = "BtEdit"
        Me.BtEdit.Size = New System.Drawing.Size(60, 55)
        Me.BtEdit.TabIndex = 8
        Me.BtEdit.Tag = "edit"
        Me.BtEdit.Text = "Editar"
        Me.BtEdit.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.BtEdit.UseVisualStyleBackColor = True
        Me.BtEdit.Visible = False
        '
        'PnlButtons_Move
        '
        Me.PnlButtons_Move.BackColor = System.Drawing.Color.FromArgb(CType(CType(197, Byte), Integer), CType(CType(203, Byte), Integer), CType(CType(203, Byte), Integer))
        Me.PnlButtons_Move.Controls.Add(Me.BtLast)
        Me.PnlButtons_Move.Controls.Add(Me.BtFirst)
        Me.PnlButtons_Move.Controls.Add(Me.BtNext)
        Me.PnlButtons_Move.Controls.Add(Me.BtPrevious)
        Me.PnlButtons_Move.Location = New System.Drawing.Point(231, 54)
        Me.PnlButtons_Move.Name = "PnlButtons_Move"
        Me.PnlButtons_Move.Size = New System.Drawing.Size(276, 38)
        Me.PnlButtons_Move.TabIndex = 11
        '
        'BtLast
        '
        Me.BtLast.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.BtLast.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtLast.Image = CType(resources.GetObject("BtLast.Image"), System.Drawing.Image)
        Me.BtLast.Location = New System.Drawing.Point(212, 0)
        Me.BtLast.Name = "BtLast"
        Me.BtLast.Size = New System.Drawing.Size(60, 38)
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
        Me.BtFirst.Size = New System.Drawing.Size(60, 38)
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
        Me.BtNext.Location = New System.Drawing.Point(146, 0)
        Me.BtNext.Name = "BtNext"
        Me.BtNext.Size = New System.Drawing.Size(60, 38)
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
        Me.BtPrevious.Size = New System.Drawing.Size(60, 38)
        Me.BtPrevious.TabIndex = 11
        Me.BtPrevious.Tag = "previous"
        Me.BtPrevious.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.BtPrevious.UseVisualStyleBackColor = True
        '
        'LblName
        '
        Me.LblName.BackColor = System.Drawing.Color.FromArgb(CType(CType(197, Byte), Integer), CType(CType(203, Byte), Integer), CType(CType(203, Byte), Integer))
        Me.LblName.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblName.Location = New System.Drawing.Point(266, 16)
        Me.LblName.Name = "LblName"
        Me.LblName.Size = New System.Drawing.Size(236, 23)
        Me.LblName.TabIndex = 10
        Me.LblName.Tag = "138;196;200"
        Me.LblName.Text = "Label1"
        Me.LblName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'datagrid
        '
        Me.datagrid.AllowUserToAddRows = False
        Me.datagrid.AllowUserToDeleteRows = False
        Me.datagrid.AllowUserToOrderColumns = True
        Me.datagrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.datagrid.Location = New System.Drawing.Point(48, 164)
        Me.datagrid.Name = "datagrid"
        Me.datagrid.ReadOnly = True
        Me.datagrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.datagrid.Size = New System.Drawing.Size(887, 461)
        Me.datagrid.TabIndex = 9
        '
        'm_Shell
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Black
        Me.ClientSize = New System.Drawing.Size(1028, 760)
        Me.Controls.Add(Me.SplitContainer)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.KeyPreview = True
        Me.Name = "m_Shell"
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
        Me.PnlButtons_Controls.ResumeLayout(False)
        Me.PnlButtons_Controls.PerformLayout()
        Me.PnlButtons_Actions.ResumeLayout(False)
        Me.PnlButtons_Move.ResumeLayout(False)
        CType(Me.datagrid, System.ComponentModel.ISupportInitialize).EndInit()
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
    Friend WithEvents PnlButtons_Actions As System.Windows.Forms.Panel
    Friend WithEvents BtEdit As System.Windows.Forms.Button
    Friend WithEvents BtDel As System.Windows.Forms.Button
    Friend WithEvents BtLast As System.Windows.Forms.Button
    Friend WithEvents BtNext As System.Windows.Forms.Button
    Friend WithEvents BtPrevious As System.Windows.Forms.Button
    Friend WithEvents BtFirst As System.Windows.Forms.Button
    Friend WithEvents datagrid As System.Windows.Forms.DataGridView
    Friend WithEvents LblName As System.Windows.Forms.Label
    Friend WithEvents PnlButtons_Move As System.Windows.Forms.Panel
    Friend WithEvents TxtFilter As System.Windows.Forms.TextBox
    Friend WithEvents BtNew As System.Windows.Forms.Button
    Friend WithEvents LblNofM As System.Windows.Forms.Label
    Friend WithEvents CbFilter As System.Windows.Forms.ComboBox
    Friend WithEvents BtFilter As System.Windows.Forms.Button
    Friend WithEvents BtKeyBoard As System.Windows.Forms.Button
    Friend WithEvents BtExport As System.Windows.Forms.Button
    Friend WithEvents PnlButtons_Controls As System.Windows.Forms.Panel
    Friend WithEvents CbConditionalFilter As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents LblSQL As System.Windows.Forms.Label
    Friend WithEvents BtShow As System.Windows.Forms.Button
End Class
