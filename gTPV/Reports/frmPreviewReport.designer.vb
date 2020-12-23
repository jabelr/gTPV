<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmPreviewReport
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
        Dim Label6 As System.Windows.Forms.Label
        Dim Label1 As System.Windows.Forms.Label
        Dim LblNameCab As System.Windows.Forms.Label
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmPreviewReport))
        Me.SplitContainer = New System.Windows.Forms.SplitContainer()
        Me.m_logo = New System.Windows.Forms.PictureBox()
        Me.PnlButton_Shell = New System.Windows.Forms.Panel()
        Me.BtClose = New System.Windows.Forms.Button()
        Me.LblSubTitle = New System.Windows.Forms.Label()
        Me.LblTitle = New System.Windows.Forms.Label()
        Me.PnlBody = New System.Windows.Forms.Panel()
        Me.PnlData = New System.Windows.Forms.Panel()
        Me.ContainerData = New System.Windows.Forms.SplitContainer()
        Me.LblName = New System.Windows.Forms.Label()
        Me.PicIcon_Empresa = New System.Windows.Forms.PictureBox()
        Me.PnlAction_Buttons = New System.Windows.Forms.Panel()
        Me.CbPrinters = New System.Windows.Forms.ComboBox()
        Me.BtPrint = New System.Windows.Forms.Button()
        Me.LblNfoListado = New System.Windows.Forms.Label()
        Me.Viewer = New CrystalDecisions.Windows.Forms.CrystalReportViewer()
        Me.ImageList = New System.Windows.Forms.ImageList(Me.components)
        Me.ToolTip = New System.Windows.Forms.ToolTip(Me.components)
        Me.ImageList_day = New System.Windows.Forms.ImageList(Me.components)
        Label6 = New System.Windows.Forms.Label()
        Label1 = New System.Windows.Forms.Label()
        LblNameCab = New System.Windows.Forms.Label()
        Me.SplitContainer.Panel1.SuspendLayout()
        Me.SplitContainer.Panel2.SuspendLayout()
        Me.SplitContainer.SuspendLayout()
        CType(Me.m_logo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PnlButton_Shell.SuspendLayout()
        Me.PnlBody.SuspendLayout()
        Me.PnlData.SuspendLayout()
        Me.ContainerData.Panel1.SuspendLayout()
        Me.ContainerData.Panel2.SuspendLayout()
        Me.ContainerData.SuspendLayout()
        CType(Me.PicIcon_Empresa, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PnlAction_Buttons.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label6
        '
        Label6.AutoSize = True
        Label6.Font = New System.Drawing.Font("Tahoma", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Label6.Location = New System.Drawing.Point(5, 4)
        Label6.Name = "Label6"
        Label6.Size = New System.Drawing.Size(66, 11)
        Label6.TabIndex = 18
        Label6.Text = "Imprimir por la"
        '
        'Label1
        '
        Label1.AutoSize = True
        Label1.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Label1.Location = New System.Drawing.Point(11, 15)
        Label1.Name = "Label1"
        Label1.Size = New System.Drawing.Size(87, 18)
        Label1.TabIndex = 21
        Label1.Text = "Impresora"
        '
        'LblNameCab
        '
        LblNameCab.AutoSize = True
        LblNameCab.Font = New System.Drawing.Font("Tahoma", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        LblNameCab.Location = New System.Drawing.Point(73, 1)
        LblNameCab.Name = "LblNameCab"
        LblNameCab.Size = New System.Drawing.Size(193, 23)
        LblNameCab.TabIndex = 35
        LblNameCab.Text = "Previsualización de"
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
        'LblSubTitle
        '
        Me.LblSubTitle.ForeColor = System.Drawing.SystemColors.InactiveCaption
        Me.LblSubTitle.Location = New System.Drawing.Point(64, 30)
        Me.LblSubTitle.Name = "LblSubTitle"
        Me.LblSubTitle.Size = New System.Drawing.Size(321, 31)
        Me.LblSubTitle.TabIndex = 1
        Me.LblSubTitle.Text = "Previsualización de listados e informes"
        '
        'LblTitle
        '
        Me.LblTitle.AutoSize = True
        Me.LblTitle.Font = New System.Drawing.Font("Tahoma", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblTitle.Location = New System.Drawing.Point(57, 4)
        Me.LblTitle.Name = "LblTitle"
        Me.LblTitle.Size = New System.Drawing.Size(279, 23)
        Me.LblTitle.TabIndex = 0
        Me.LblTitle.Text = "Previsualización de Listados"
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
        Me.PnlData.Controls.Add(Me.ContainerData)
        Me.PnlData.Location = New System.Drawing.Point(35, 35)
        Me.PnlData.Name = "PnlData"
        Me.PnlData.Size = New System.Drawing.Size(912, 600)
        Me.PnlData.TabIndex = 38
        '
        'ContainerData
        '
        Me.ContainerData.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ContainerData.Location = New System.Drawing.Point(0, 0)
        Me.ContainerData.Name = "ContainerData"
        Me.ContainerData.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'ContainerData.Panel1
        '
        Me.ContainerData.Panel1.BackColor = System.Drawing.Color.Silver
        Me.ContainerData.Panel1.Controls.Add(Me.LblName)
        Me.ContainerData.Panel1.Controls.Add(Me.PicIcon_Empresa)
        Me.ContainerData.Panel1.Controls.Add(Me.PnlAction_Buttons)
        Me.ContainerData.Panel1.Controls.Add(Me.LblNfoListado)
        Me.ContainerData.Panel1.Controls.Add(LblNameCab)
        '
        'ContainerData.Panel2
        '
        Me.ContainerData.Panel2.BackColor = System.Drawing.Color.Transparent
        Me.ContainerData.Panel2.Controls.Add(Me.Viewer)
        Me.ContainerData.Size = New System.Drawing.Size(912, 600)
        Me.ContainerData.SplitterDistance = 74
        Me.ContainerData.SplitterWidth = 1
        Me.ContainerData.TabIndex = 39
        '
        'LblName
        '
        Me.LblName.Font = New System.Drawing.Font("Tahoma", 17.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblName.Location = New System.Drawing.Point(120, 20)
        Me.LblName.Name = "LblName"
        Me.LblName.Size = New System.Drawing.Size(329, 29)
        Me.LblName.TabIndex = 38
        Me.LblName.Text = "<object />"
        '
        'PicIcon_Empresa
        '
        Me.PicIcon_Empresa.Image = CType(resources.GetObject("PicIcon_Empresa.Image"), System.Drawing.Image)
        Me.PicIcon_Empresa.Location = New System.Drawing.Point(0, 0)
        Me.PicIcon_Empresa.Name = "PicIcon_Empresa"
        Me.PicIcon_Empresa.Size = New System.Drawing.Size(72, 72)
        Me.PicIcon_Empresa.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PicIcon_Empresa.TabIndex = 37
        Me.PicIcon_Empresa.TabStop = False
        '
        'PnlAction_Buttons
        '
        Me.PnlAction_Buttons.BackColor = System.Drawing.Color.Transparent
        Me.PnlAction_Buttons.Controls.Add(Me.CbPrinters)
        Me.PnlAction_Buttons.Controls.Add(Label1)
        Me.PnlAction_Buttons.Controls.Add(Me.BtPrint)
        Me.PnlAction_Buttons.Controls.Add(Label6)
        Me.PnlAction_Buttons.Dock = System.Windows.Forms.DockStyle.Right
        Me.PnlAction_Buttons.Location = New System.Drawing.Point(484, 0)
        Me.PnlAction_Buttons.Name = "PnlAction_Buttons"
        Me.PnlAction_Buttons.Size = New System.Drawing.Size(428, 74)
        Me.PnlAction_Buttons.TabIndex = 37
        Me.PnlAction_Buttons.Tag = "NO_SCAN"
        '
        'CbPrinters
        '
        Me.CbPrinters.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CbPrinters.Enabled = False
        Me.CbPrinters.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CbPrinters.FormattingEnabled = True
        Me.CbPrinters.Location = New System.Drawing.Point(1, 38)
        Me.CbPrinters.Name = "CbPrinters"
        Me.CbPrinters.Size = New System.Drawing.Size(320, 32)
        Me.CbPrinters.TabIndex = 22
        '
        'BtPrint
        '
        Me.BtPrint.BackColor = System.Drawing.SystemColors.Control
        Me.BtPrint.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtPrint.Image = CType(resources.GetObject("BtPrint.Image"), System.Drawing.Image)
        Me.BtPrint.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.BtPrint.Location = New System.Drawing.Point(327, 3)
        Me.BtPrint.Name = "BtPrint"
        Me.BtPrint.Size = New System.Drawing.Size(98, 67)
        Me.BtPrint.TabIndex = 19
        Me.BtPrint.Tag = "PRINT"
        Me.BtPrint.Text = "Imprimir"
        Me.BtPrint.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.BtPrint.UseVisualStyleBackColor = False
        '
        'LblNfoListado
        '
        Me.LblNfoListado.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblNfoListado.Location = New System.Drawing.Point(100, 46)
        Me.LblNfoListado.Name = "LblNfoListado"
        Me.LblNfoListado.Size = New System.Drawing.Size(373, 26)
        Me.LblNfoListado.TabIndex = 36
        Me.LblNfoListado.Text = "El texto que quiero poner de información" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Por que yo lo valgo!! xD"
        '
        'Viewer
        '
        Me.Viewer.ActiveViewIndex = -1
        Me.Viewer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Viewer.Cursor = System.Windows.Forms.Cursors.Default
        Me.Viewer.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Viewer.Location = New System.Drawing.Point(0, 0)
        Me.Viewer.Name = "Viewer"
        'Me.Viewer.SelectionFormula = ""
        Me.Viewer.ShowCloseButton = False
        Me.Viewer.ShowGotoPageButton = False
        Me.Viewer.ShowGroupTreeButton = False
        Me.Viewer.ShowTextSearchButton = False
        Me.Viewer.Size = New System.Drawing.Size(912, 525)
        Me.Viewer.TabIndex = 38
        Me.Viewer.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None
        Me.Viewer.ViewTimeSelectionFormula = ""
        '
        'ImageList
        '
        Me.ImageList.ImageStream = CType(resources.GetObject("ImageList.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageList.Images.SetKeyName(0, "ball_red.png")
        Me.ImageList.Images.SetKeyName(1, "ball_green.png")
        '
        'ImageList_day
        '
        Me.ImageList_day.ImageStream = CType(resources.GetObject("ImageList_day.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList_day.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageList_day.Images.SetKeyName(0, "note.png")
        '
        'frmPreviewReport
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Black
        Me.ClientSize = New System.Drawing.Size(1020, 770)
        Me.Controls.Add(Me.SplitContainer)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "frmPreviewReport"
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
        Me.ContainerData.Panel1.ResumeLayout(False)
        Me.ContainerData.Panel1.PerformLayout()
        Me.ContainerData.Panel2.ResumeLayout(False)
        Me.ContainerData.ResumeLayout(False)
        CType(Me.PicIcon_Empresa, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PnlAction_Buttons.ResumeLayout(False)
        Me.PnlAction_Buttons.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents SplitContainer As System.Windows.Forms.SplitContainer
    Friend WithEvents m_logo As System.Windows.Forms.PictureBox
    Friend WithEvents PnlButton_Shell As System.Windows.Forms.Panel
    Friend WithEvents BtClose As System.Windows.Forms.Button
    Friend WithEvents LblSubTitle As System.Windows.Forms.Label
    Friend WithEvents LblTitle As System.Windows.Forms.Label
    Friend WithEvents PnlBody As System.Windows.Forms.Panel
    Friend WithEvents ImageList As System.Windows.Forms.ImageList
    Friend WithEvents PnlData As System.Windows.Forms.Panel
    Friend WithEvents ToolTip As System.Windows.Forms.ToolTip
    Friend WithEvents ImageList_day As System.Windows.Forms.ImageList
    Friend WithEvents BtPrint As System.Windows.Forms.Button
    Friend WithEvents PnlAction_Buttons As System.Windows.Forms.Panel
    Friend WithEvents Viewer As CrystalDecisions.Windows.Forms.CrystalReportViewer
    Friend WithEvents CbPrinters As System.Windows.Forms.ComboBox
    Friend WithEvents ContainerData As System.Windows.Forms.SplitContainer
    Friend WithEvents PicIcon_Empresa As System.Windows.Forms.PictureBox
    Friend WithEvents LblNfoListado As System.Windows.Forms.Label
    Friend WithEvents LblName As System.Windows.Forms.Label
End Class
