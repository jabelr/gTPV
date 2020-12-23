<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmPaneldeSituacion_Select
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
        Dim Label2 As System.Windows.Forms.Label
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmPaneldeSituacion_Select))
        Me.SplitContainer = New System.Windows.Forms.SplitContainer()
        Me.m_logo = New System.Windows.Forms.PictureBox()
        Me.PnlButton_Shell = New System.Windows.Forms.Panel()
        Me.BtClose = New System.Windows.Forms.Button()
        Me.LblSubTitle = New System.Windows.Forms.Label()
        Me.LblTitle = New System.Windows.Forms.Label()
        Me.PnlBody = New System.Windows.Forms.Panel()
        Me.PnlData = New System.Windows.Forms.Panel()
        Me.PnlZonas = New System.Windows.Forms.Panel()
        Me.BtZona_Right = New System.Windows.Forms.Button()
        Me.BtZona_Left = New System.Windows.Forms.Button()
        Me.CbZonas = New System.Windows.Forms.ComboBox()
        Me.PnlHistory = New System.Windows.Forms.Panel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.PicPlano = New System.Windows.Forms.PictureBox()
        Me.ToolTip = New System.Windows.Forms.ToolTip(Me.components)
        Me.chkMantenerNombre = New System.Windows.Forms.CheckBox()
        Label2 = New System.Windows.Forms.Label()
        Me.SplitContainer.Panel1.SuspendLayout()
        Me.SplitContainer.Panel2.SuspendLayout()
        Me.SplitContainer.SuspendLayout()
        CType(Me.m_logo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PnlButton_Shell.SuspendLayout()
        Me.PnlBody.SuspendLayout()
        Me.PnlData.SuspendLayout()
        Me.PnlZonas.SuspendLayout()
        Me.PnlHistory.SuspendLayout()
        CType(Me.PicPlano, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label2
        '
        Label2.AutoSize = True
        Label2.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Label2.Location = New System.Drawing.Point(3, 4)
        Label2.Name = "Label2"
        Label2.Size = New System.Drawing.Size(122, 16)
        Label2.TabIndex = 24
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
        Me.LblSubTitle.Location = New System.Drawing.Point(96, 32)
        Me.LblSubTitle.Name = "LblSubTitle"
        Me.LblSubTitle.Size = New System.Drawing.Size(290, 31)
        Me.LblSubTitle.TabIndex = 1
        Me.LblSubTitle.Text = "Seleccione la mesa de destino"
        '
        'LblTitle
        '
        Me.LblTitle.AutoSize = True
        Me.LblTitle.Font = New System.Drawing.Font("Tahoma", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblTitle.Location = New System.Drawing.Point(57, 4)
        Me.LblTitle.Name = "LblTitle"
        Me.LblTitle.Size = New System.Drawing.Size(211, 23)
        Me.LblTitle.TabIndex = 0
        Me.LblTitle.Text = "Seleccione el destino"
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
        Me.PnlData.Controls.Add(Me.PnlZonas)
        Me.PnlData.Controls.Add(Me.PnlHistory)
        Me.PnlData.Controls.Add(Me.PicPlano)
        Me.PnlData.Location = New System.Drawing.Point(37, 34)
        Me.PnlData.Name = "PnlData"
        Me.PnlData.Size = New System.Drawing.Size(908, 603)
        Me.PnlData.TabIndex = 38
        '
        'PnlZonas
        '
        Me.PnlZonas.BackColor = System.Drawing.Color.FromArgb(CType(CType(174, Byte), Integer), CType(CType(186, Byte), Integer), CType(CType(186, Byte), Integer))
        Me.PnlZonas.Controls.Add(Me.BtZona_Right)
        Me.PnlZonas.Controls.Add(Me.BtZona_Left)
        Me.PnlZonas.Controls.Add(Label2)
        Me.PnlZonas.Controls.Add(Me.CbZonas)
        Me.PnlZonas.Location = New System.Drawing.Point(493, 3)
        Me.PnlZonas.Name = "PnlZonas"
        Me.PnlZonas.Size = New System.Drawing.Size(412, 77)
        Me.PnlZonas.TabIndex = 41
        '
        'BtZona_Right
        '
        Me.BtZona_Right.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtZona_Right.Image = CType(resources.GetObject("BtZona_Right.Image"), System.Drawing.Image)
        Me.BtZona_Right.Location = New System.Drawing.Point(365, 23)
        Me.BtZona_Right.Name = "BtZona_Right"
        Me.BtZona_Right.Size = New System.Drawing.Size(43, 39)
        Me.BtZona_Right.TabIndex = 26
        Me.BtZona_Right.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.BtZona_Right.UseVisualStyleBackColor = True
        '
        'BtZona_Left
        '
        Me.BtZona_Left.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtZona_Left.Image = CType(resources.GetObject("BtZona_Left.Image"), System.Drawing.Image)
        Me.BtZona_Left.Location = New System.Drawing.Point(321, 23)
        Me.BtZona_Left.Name = "BtZona_Left"
        Me.BtZona_Left.Size = New System.Drawing.Size(43, 39)
        Me.BtZona_Left.TabIndex = 25
        Me.BtZona_Left.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.BtZona_Left.UseVisualStyleBackColor = True
        '
        'CbZonas
        '
        Me.CbZonas.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CbZonas.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CbZonas.FormattingEnabled = True
        Me.CbZonas.Location = New System.Drawing.Point(21, 23)
        Me.CbZonas.Name = "CbZonas"
        Me.CbZonas.Size = New System.Drawing.Size(298, 39)
        Me.CbZonas.TabIndex = 23
        '
        'PnlHistory
        '
        Me.PnlHistory.BackColor = System.Drawing.Color.Gainsboro
        Me.PnlHistory.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.PnlHistory.Controls.Add(Me.chkMantenerNombre)
        Me.PnlHistory.Controls.Add(Me.Label1)
        Me.PnlHistory.Location = New System.Drawing.Point(0, 1)
        Me.PnlHistory.Name = "PnlHistory"
        Me.PnlHistory.Size = New System.Drawing.Size(487, 79)
        Me.PnlHistory.TabIndex = 40
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Tahoma", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(15, 4)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(359, 23)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Seleccione la nueva mesa de destino"
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
        'chkMantenerNombre
        '
        Me.chkMantenerNombre.AutoSize = True
        Me.chkMantenerNombre.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkMantenerNombre.Location = New System.Drawing.Point(34, 34)
        Me.chkMantenerNombre.Name = "chkMantenerNombre"
        Me.chkMantenerNombre.Size = New System.Drawing.Size(300, 28)
        Me.chkMantenerNombre.TabIndex = 2
        Me.chkMantenerNombre.Text = "Mantener el Nombre de la Mesa"
        Me.chkMantenerNombre.UseVisualStyleBackColor = True
        '
        'frmPaneldeSituacion_Select
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoScroll = True
        Me.BackColor = System.Drawing.Color.Black
        Me.ClientSize = New System.Drawing.Size(1020, 770)
        Me.Controls.Add(Me.SplitContainer)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "frmPaneldeSituacion_Select"
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
        Me.PnlZonas.ResumeLayout(False)
        Me.PnlZonas.PerformLayout()
        Me.PnlHistory.ResumeLayout(False)
        Me.PnlHistory.PerformLayout()
        CType(Me.PicPlano, System.ComponentModel.ISupportInitialize).EndInit()
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
    Friend WithEvents PicPlano As System.Windows.Forms.PictureBox
    Friend WithEvents PnlHistory As System.Windows.Forms.Panel
    Friend WithEvents PnlZonas As System.Windows.Forms.Panel
    Friend WithEvents CbZonas As System.Windows.Forms.ComboBox
    Friend WithEvents BtZona_Left As System.Windows.Forms.Button
    Friend WithEvents BtZona_Right As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents chkMantenerNombre As System.Windows.Forms.CheckBox
End Class
