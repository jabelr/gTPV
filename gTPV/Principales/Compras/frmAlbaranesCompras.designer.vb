<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmAlbaranesCompras
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmAlbaranesCompras))
        Me.SplitContainer = New System.Windows.Forms.SplitContainer
        Me.m_logo = New System.Windows.Forms.PictureBox
        Me.PnlButton_Shell = New System.Windows.Forms.Panel
        Me.BtClose = New System.Windows.Forms.Button
        Me.BtMin = New System.Windows.Forms.Button
        Me.LblSubTitle = New System.Windows.Forms.Label
        Me.LblTitle = New System.Windows.Forms.Label
        Me.PnlBody = New System.Windows.Forms.Panel
        Me.LblMonth = New System.Windows.Forms.Label
        Me.PnlData = New System.Windows.Forms.Panel
        Me.Tab = New System.Windows.Forms.TabControl
        Me.TabPage_AlbaranesCompra = New System.Windows.Forms.TabPage
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.BtEdit = New System.Windows.Forms.Button
        Me.Label3 = New System.Windows.Forms.Label
        Me.LblInfoCompras = New System.Windows.Forms.Label
        Me.BtAdd = New System.Windows.Forms.Button
        Me.BtDel = New System.Windows.Forms.Button
        Me.LblDaySelect = New System.Windows.Forms.Label
        Me.GridAlbaranes = New System.Windows.Forms.DataGridView
        Me.ImageList = New System.Windows.Forms.ImageList(Me.components)
        Me.ToolTip = New System.Windows.Forms.ToolTip(Me.components)
        Me.SplitContainer.Panel1.SuspendLayout()
        Me.SplitContainer.Panel2.SuspendLayout()
        Me.SplitContainer.SuspendLayout()
        CType(Me.m_logo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PnlButton_Shell.SuspendLayout()
        Me.PnlBody.SuspendLayout()
        Me.PnlData.SuspendLayout()
        Me.Tab.SuspendLayout()
        Me.TabPage_AlbaranesCompra.SuspendLayout()
        Me.Panel1.SuspendLayout()
        CType(Me.GridAlbaranes, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.LblSubTitle.Size = New System.Drawing.Size(321, 28)
        Me.LblSubTitle.TabIndex = 1
        Me.LblSubTitle.Text = "Información y gestión de los albaranes de Compra a Proveedores"
        '
        'LblTitle
        '
        Me.LblTitle.AutoSize = True
        Me.LblTitle.Font = New System.Drawing.Font("Tahoma", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblTitle.Location = New System.Drawing.Point(57, 4)
        Me.LblTitle.Name = "LblTitle"
        Me.LblTitle.Size = New System.Drawing.Size(213, 23)
        Me.LblTitle.TabIndex = 0
        Me.LblTitle.Text = "Albaranes de Compra"
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
        Me.LblMonth.Size = New System.Drawing.Size(449, 31)
        Me.LblMonth.TabIndex = 39
        Me.LblMonth.Text = "Albaranes Pendientes de Compra"
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
        Me.Tab.Controls.Add(Me.TabPage_AlbaranesCompra)
        Me.Tab.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Tab.ImageList = Me.ImageList
        Me.Tab.Location = New System.Drawing.Point(0, 0)
        Me.Tab.Name = "Tab"
        Me.Tab.SelectedIndex = 0
        Me.Tab.Size = New System.Drawing.Size(908, 530)
        Me.Tab.TabIndex = 11
        '
        'TabPage_AlbaranesCompra
        '
        Me.TabPage_AlbaranesCompra.Controls.Add(Me.Panel1)
        Me.TabPage_AlbaranesCompra.Controls.Add(Me.GridAlbaranes)
        Me.TabPage_AlbaranesCompra.ImageIndex = 0
        Me.TabPage_AlbaranesCompra.Location = New System.Drawing.Point(4, 23)
        Me.TabPage_AlbaranesCompra.Name = "TabPage_AlbaranesCompra"
        Me.TabPage_AlbaranesCompra.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage_AlbaranesCompra.Size = New System.Drawing.Size(900, 503)
        Me.TabPage_AlbaranesCompra.TabIndex = 0
        Me.TabPage_AlbaranesCompra.Text = "Albaranes de Compra"
        Me.TabPage_AlbaranesCompra.UseVisualStyleBackColor = True
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.Transparent
        Me.Panel1.Controls.Add(Me.BtEdit)
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Controls.Add(Me.LblInfoCompras)
        Me.Panel1.Controls.Add(Me.BtAdd)
        Me.Panel1.Controls.Add(Me.BtDel)
        Me.Panel1.Controls.Add(Me.LblDaySelect)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Right
        Me.Panel1.Location = New System.Drawing.Point(725, 3)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(172, 497)
        Me.Panel1.TabIndex = 11
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
        Me.Label3.Size = New System.Drawing.Size(172, 21)
        Me.Label3.TabIndex = 49
        Me.Label3.Text = "Detalles"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
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
        Me.LblDaySelect.Size = New System.Drawing.Size(172, 35)
        Me.LblDaySelect.TabIndex = 42
        Me.LblDaySelect.Text = "ACCIONES"
        Me.LblDaySelect.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
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
        'ImageList
        '
        Me.ImageList.ImageStream = CType(resources.GetObject("ImageList.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageList.Images.SetKeyName(0, "shop_cart.png")
        '
        'frmAlbaranesCompras
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Black
        Me.ClientSize = New System.Drawing.Size(1020, 770)
        Me.Controls.Add(Me.SplitContainer)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "frmAlbaranesCompras"
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
        Me.TabPage_AlbaranesCompra.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        CType(Me.GridAlbaranes, System.ComponentModel.ISupportInitialize).EndInit()
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
    Friend WithEvents GridAlbaranes As System.Windows.Forms.DataGridView
    Friend WithEvents LblMonth As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents BtDel As System.Windows.Forms.Button
    Friend WithEvents LblDaySelect As System.Windows.Forms.Label
    Friend WithEvents BtAdd As System.Windows.Forms.Button
    Friend WithEvents Tab As System.Windows.Forms.TabControl
    Friend WithEvents TabPage_AlbaranesCompra As System.Windows.Forms.TabPage
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents LblInfoCompras As System.Windows.Forms.Label
    Friend WithEvents BtEdit As System.Windows.Forms.Button
End Class
