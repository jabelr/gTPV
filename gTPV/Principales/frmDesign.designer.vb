<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmDesign
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
        Dim Label6 As System.Windows.Forms.Label
        Dim Label1 As System.Windows.Forms.Label
        Dim Label2 As System.Windows.Forms.Label
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmDesign))
        Me.SplitContainer = New System.Windows.Forms.SplitContainer
        Me.m_logo = New System.Windows.Forms.PictureBox
        Me.PnlButton_Shell = New System.Windows.Forms.Panel
        Me.CbZonas = New System.Windows.Forms.ComboBox
        Me.ChkModeLine = New System.Windows.Forms.CheckBox
        Me.ImageList = New System.Windows.Forms.ImageList(Me.components)
        Me.BtClose = New System.Windows.Forms.Button
        Me.BtMin = New System.Windows.Forms.Button
        Me.LblSubTitle = New System.Windows.Forms.Label
        Me.LblTitle = New System.Windows.Forms.Label
        Me.PnlBody = New System.Windows.Forms.Panel
        Me.PnlData = New System.Windows.Forms.Panel
        Me.PnlModeLineON = New System.Windows.Forms.Panel
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.ChkLine = New System.Windows.Forms.CheckBox
        Me.PnlCategorias = New System.Windows.Forms.Panel
        Me.BtCat_Next = New System.Windows.Forms.Button
        Me.BtCat_Previous = New System.Windows.Forms.Button
        Me.PicPlano = New System.Windows.Forms.PictureBox
        Me.PnlAction_Buttons = New System.Windows.Forms.Panel
        Me.BtCancell = New System.Windows.Forms.Button
        Me.BtOk = New System.Windows.Forms.Button
        Me.CbImg_Cat = New System.Windows.Forms.ComboBox
        Me.ToolTip = New System.Windows.Forms.ToolTip(Me.components)
        Me.ImageList_day = New System.Windows.Forms.ImageList(Me.components)
        Label6 = New System.Windows.Forms.Label
        Label1 = New System.Windows.Forms.Label
        Label2 = New System.Windows.Forms.Label
        Me.SplitContainer.Panel1.SuspendLayout()
        Me.SplitContainer.Panel2.SuspendLayout()
        Me.SplitContainer.SuspendLayout()
        CType(Me.m_logo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PnlButton_Shell.SuspendLayout()
        Me.PnlBody.SuspendLayout()
        Me.PnlData.SuspendLayout()
        Me.PnlModeLineON.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.PnlCategorias.SuspendLayout()
        CType(Me.PicPlano, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PnlAction_Buttons.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label6
        '
        Label6.AutoSize = True
        Label6.Font = New System.Drawing.Font("Tahoma", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Label6.Location = New System.Drawing.Point(5, 4)
        Label6.Name = "Label6"
        Label6.Size = New System.Drawing.Size(46, 11)
        Label6.TabIndex = 18
        Label6.Text = "Mostrar el"
        '
        'Label1
        '
        Label1.AutoSize = True
        Label1.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Label1.Location = New System.Drawing.Point(11, 15)
        Label1.Name = "Label1"
        Label1.Size = New System.Drawing.Size(84, 18)
        Label1.TabIndex = 21
        Label1.Text = "Mobiliario"
        '
        'Label2
        '
        Label2.AutoSize = True
        Label2.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Label2.Location = New System.Drawing.Point(5, 3)
        Label2.Name = "Label2"
        Label2.Size = New System.Drawing.Size(122, 16)
        Label2.TabIndex = 22
        Label2.Text = "Zonas Disponibles"
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
        Me.PnlButton_Shell.Controls.Add(Label2)
        Me.PnlButton_Shell.Controls.Add(Me.CbZonas)
        Me.PnlButton_Shell.Controls.Add(Me.ChkModeLine)
        Me.PnlButton_Shell.Controls.Add(Me.BtClose)
        Me.PnlButton_Shell.Controls.Add(Me.BtMin)
        Me.PnlButton_Shell.Dock = System.Windows.Forms.DockStyle.Right
        Me.PnlButton_Shell.Location = New System.Drawing.Point(470, 0)
        Me.PnlButton_Shell.Name = "PnlButton_Shell"
        Me.PnlButton_Shell.Size = New System.Drawing.Size(550, 64)
        Me.PnlButton_Shell.TabIndex = 2
        '
        'CbZonas
        '
        Me.CbZonas.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CbZonas.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CbZonas.FormattingEnabled = True
        Me.CbZonas.Location = New System.Drawing.Point(20, 22)
        Me.CbZonas.Name = "CbZonas"
        Me.CbZonas.Size = New System.Drawing.Size(342, 37)
        Me.CbZonas.TabIndex = 18
        '
        'ChkModeLine
        '
        Me.ChkModeLine.Appearance = System.Windows.Forms.Appearance.Button
        Me.ChkModeLine.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.ChkModeLine.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ChkModeLine.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.ChkModeLine.ImageIndex = 0
        Me.ChkModeLine.ImageList = Me.ImageList
        Me.ChkModeLine.Location = New System.Drawing.Point(20, 15)
        Me.ChkModeLine.Name = "ChkModeLine"
        Me.ChkModeLine.Size = New System.Drawing.Size(153, 38)
        Me.ChkModeLine.TabIndex = 8
        Me.ChkModeLine.Tag = "modeline"
        Me.ChkModeLine.Text = "Activar Modo ""Dibujo"""
        Me.ChkModeLine.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.ChkModeLine.UseVisualStyleBackColor = True
        Me.ChkModeLine.Visible = False
        '
        'ImageList
        '
        Me.ImageList.ImageStream = CType(resources.GetObject("ImageList.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageList.Images.SetKeyName(0, "ball_red.png")
        Me.ImageList.Images.SetKeyName(1, "ball_green.png")
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
        Me.BtMin.Location = New System.Drawing.Point(3, 4)
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
        Me.LblSubTitle.Location = New System.Drawing.Point(64, 30)
        Me.LblSubTitle.Name = "LblSubTitle"
        Me.LblSubTitle.Size = New System.Drawing.Size(321, 31)
        Me.LblSubTitle.TabIndex = 1
        Me.LblSubTitle.Text = "Diseño del local y ubicación de las distintas mesas, asi como de la barra"
        '
        'LblTitle
        '
        Me.LblTitle.AutoSize = True
        Me.LblTitle.Font = New System.Drawing.Font("Tahoma", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblTitle.Location = New System.Drawing.Point(57, 4)
        Me.LblTitle.Name = "LblTitle"
        Me.LblTitle.Size = New System.Drawing.Size(166, 23)
        Me.LblTitle.TabIndex = 0
        Me.LblTitle.Text = "Diseño del Local"
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
        Me.PnlData.Controls.Add(Me.PnlModeLineON)
        Me.PnlData.Controls.Add(Me.PnlCategorias)
        Me.PnlData.Controls.Add(Me.PicPlano)
        Me.PnlData.Controls.Add(Me.PnlAction_Buttons)
        Me.PnlData.Location = New System.Drawing.Point(37, 32)
        Me.PnlData.Name = "PnlData"
        Me.PnlData.Size = New System.Drawing.Size(908, 603)
        Me.PnlData.TabIndex = 38
        '
        'PnlModeLineON
        '
        Me.PnlModeLineON.BackColor = System.Drawing.Color.FromArgb(CType(CType(174, Byte), Integer), CType(CType(186, Byte), Integer), CType(CType(186, Byte), Integer))
        Me.PnlModeLineON.Controls.Add(Me.GroupBox1)
        Me.PnlModeLineON.Location = New System.Drawing.Point(5, 112)
        Me.PnlModeLineON.Name = "PnlModeLineON"
        Me.PnlModeLineON.Size = New System.Drawing.Size(585, 74)
        Me.PnlModeLineON.TabIndex = 40
        Me.PnlModeLineON.Visible = False
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.ChkLine)
        Me.GroupBox1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupBox1.Location = New System.Drawing.Point(0, 0)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(585, 74)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        '
        'ChkLine
        '
        Me.ChkLine.Appearance = System.Windows.Forms.Appearance.Button
        Me.ChkLine.Font = New System.Drawing.Font("Tahoma", 9.75!)
        Me.ChkLine.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.ChkLine.ImageIndex = 1
        Me.ChkLine.ImageList = Me.ImageList
        Me.ChkLine.Location = New System.Drawing.Point(6, 15)
        Me.ChkLine.Name = "ChkLine"
        Me.ChkLine.Size = New System.Drawing.Size(162, 44)
        Me.ChkLine.TabIndex = 86
        Me.ChkLine.Tag = "ticket_Print_IVA"
        Me.ChkLine.Text = "asdf"
        Me.ChkLine.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.ChkLine.UseVisualStyleBackColor = True
        Me.ChkLine.Visible = False
        '
        'PnlCategorias
        '
        Me.PnlCategorias.BackColor = System.Drawing.Color.Black
        Me.PnlCategorias.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.PnlCategorias.Controls.Add(Me.BtCat_Next)
        Me.PnlCategorias.Controls.Add(Me.BtCat_Previous)
        Me.PnlCategorias.Location = New System.Drawing.Point(0, 2)
        Me.PnlCategorias.Name = "PnlCategorias"
        Me.PnlCategorias.Size = New System.Drawing.Size(590, 79)
        Me.PnlCategorias.TabIndex = 39
        '
        'BtCat_Next
        '
        Me.BtCat_Next.BackColor = System.Drawing.SystemColors.Control
        Me.BtCat_Next.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtCat_Next.Image = CType(resources.GetObject("BtCat_Next.Image"), System.Drawing.Image)
        Me.BtCat_Next.Location = New System.Drawing.Point(518, 1)
        Me.BtCat_Next.Name = "BtCat_Next"
        Me.BtCat_Next.Size = New System.Drawing.Size(67, 73)
        Me.BtCat_Next.TabIndex = 16
        Me.BtCat_Next.Tag = ""
        Me.BtCat_Next.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtCat_Next.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage
        Me.BtCat_Next.UseVisualStyleBackColor = False
        '
        'BtCat_Previous
        '
        Me.BtCat_Previous.BackColor = System.Drawing.SystemColors.Control
        Me.BtCat_Previous.Enabled = False
        Me.BtCat_Previous.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtCat_Previous.Image = CType(resources.GetObject("BtCat_Previous.Image"), System.Drawing.Image)
        Me.BtCat_Previous.Location = New System.Drawing.Point(0, 1)
        Me.BtCat_Previous.Name = "BtCat_Previous"
        Me.BtCat_Previous.Size = New System.Drawing.Size(67, 73)
        Me.BtCat_Previous.TabIndex = 15
        Me.BtCat_Previous.Tag = ""
        Me.BtCat_Previous.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BtCat_Previous.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.BtCat_Previous.UseVisualStyleBackColor = False
        '
        'PicPlano
        '
        Me.PicPlano.BackColor = System.Drawing.Color.Black
        Me.PicPlano.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.PicPlano.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PicPlano.Location = New System.Drawing.Point(0, 81)
        Me.PicPlano.Name = "PicPlano"
        Me.PicPlano.Size = New System.Drawing.Size(908, 522)
        Me.PicPlano.TabIndex = 0
        Me.PicPlano.TabStop = False
        '
        'PnlAction_Buttons
        '
        Me.PnlAction_Buttons.BackColor = System.Drawing.Color.Transparent
        Me.PnlAction_Buttons.Controls.Add(Label1)
        Me.PnlAction_Buttons.Controls.Add(Me.BtCancell)
        Me.PnlAction_Buttons.Controls.Add(Me.BtOk)
        Me.PnlAction_Buttons.Controls.Add(Label6)
        Me.PnlAction_Buttons.Controls.Add(Me.CbImg_Cat)
        Me.PnlAction_Buttons.Location = New System.Drawing.Point(591, 1)
        Me.PnlAction_Buttons.Name = "PnlAction_Buttons"
        Me.PnlAction_Buttons.Size = New System.Drawing.Size(317, 75)
        Me.PnlAction_Buttons.TabIndex = 37
        Me.PnlAction_Buttons.Tag = "NO_SCAN"
        '
        'BtCancell
        '
        Me.BtCancell.BackColor = System.Drawing.SystemColors.Control
        Me.BtCancell.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.BtCancell.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtCancell.Image = CType(resources.GetObject("BtCancell.Image"), System.Drawing.Image)
        Me.BtCancell.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtCancell.Location = New System.Drawing.Point(42, 39)
        Me.BtCancell.Name = "BtCancell"
        Me.BtCancell.Size = New System.Drawing.Size(130, 35)
        Me.BtCancell.TabIndex = 20
        Me.BtCancell.Tag = "CANCEL"
        Me.BtCancell.Text = "Cancelar"
        Me.BtCancell.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BtCancell.UseVisualStyleBackColor = False
        '
        'BtOk
        '
        Me.BtOk.BackColor = System.Drawing.SystemColors.Control
        Me.BtOk.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.BtOk.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtOk.Image = CType(resources.GetObject("BtOk.Image"), System.Drawing.Image)
        Me.BtOk.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtOk.Location = New System.Drawing.Point(178, 39)
        Me.BtOk.Name = "BtOk"
        Me.BtOk.Size = New System.Drawing.Size(136, 35)
        Me.BtOk.TabIndex = 19
        Me.BtOk.Tag = "OK"
        Me.BtOk.Text = "Guardar"
        Me.BtOk.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BtOk.UseVisualStyleBackColor = False
        '
        'CbImg_Cat
        '
        Me.CbImg_Cat.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CbImg_Cat.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CbImg_Cat.FormattingEnabled = True
        Me.CbImg_Cat.Location = New System.Drawing.Point(108, 1)
        Me.CbImg_Cat.Name = "CbImg_Cat"
        Me.CbImg_Cat.Size = New System.Drawing.Size(206, 32)
        Me.CbImg_Cat.TabIndex = 17
        '
        'ImageList_day
        '
        Me.ImageList_day.ImageStream = CType(resources.GetObject("ImageList_day.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList_day.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageList_day.Images.SetKeyName(0, "note.png")
        '
        'frmDesign
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Black
        Me.ClientSize = New System.Drawing.Size(1020, 770)
        Me.Controls.Add(Me.SplitContainer)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "frmDesign"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.SplitContainer.Panel1.ResumeLayout(False)
        Me.SplitContainer.Panel1.PerformLayout()
        Me.SplitContainer.Panel2.ResumeLayout(False)
        Me.SplitContainer.ResumeLayout(False)
        CType(Me.m_logo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PnlButton_Shell.ResumeLayout(False)
        Me.PnlButton_Shell.PerformLayout()
        Me.PnlBody.ResumeLayout(False)
        Me.PnlData.ResumeLayout(False)
        Me.PnlModeLineON.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.PnlCategorias.ResumeLayout(False)
        CType(Me.PicPlano, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PnlAction_Buttons.ResumeLayout(False)
        Me.PnlAction_Buttons.PerformLayout()
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
    Friend WithEvents PnlCategorias As System.Windows.Forms.Panel
    Friend WithEvents BtCat_Next As System.Windows.Forms.Button
    Friend WithEvents BtCat_Previous As System.Windows.Forms.Button
    Friend WithEvents PicPlano As System.Windows.Forms.PictureBox
    Friend WithEvents CbImg_Cat As System.Windows.Forms.ComboBox
    Friend WithEvents BtOk As System.Windows.Forms.Button
    Friend WithEvents PnlAction_Buttons As System.Windows.Forms.Panel
    Friend WithEvents BtCancell As System.Windows.Forms.Button
    Friend WithEvents ChkModeLine As System.Windows.Forms.CheckBox
    Friend WithEvents PnlModeLineON As System.Windows.Forms.Panel
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents ChkLine As System.Windows.Forms.CheckBox
    Friend WithEvents CbZonas As System.Windows.Forms.ComboBox
End Class
