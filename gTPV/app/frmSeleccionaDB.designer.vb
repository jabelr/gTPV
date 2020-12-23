<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSeleccionaDB
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
        Dim GroupBox1 As System.Windows.Forms.GroupBox
        Dim ToolStrip As System.Windows.Forms.ToolStrip
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmSeleccionaDB))
        Dim Label5 As System.Windows.Forms.Label
        Me.CbEmpresas = New System.Windows.Forms.ComboBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.LblInfo = New System.Windows.Forms.ToolStripLabel
        Me.BtOk = New System.Windows.Forms.ToolStripButton
        Me.BtCancell = New System.Windows.Forms.ToolStripButton
        Me.SplitContainer = New System.Windows.Forms.SplitContainer
        Me.PicImg = New System.Windows.Forms.PictureBox
        Me.Label4 = New System.Windows.Forms.Label
        GroupBox1 = New System.Windows.Forms.GroupBox
        ToolStrip = New System.Windows.Forms.ToolStrip
        Label5 = New System.Windows.Forms.Label
        GroupBox1.SuspendLayout()
        ToolStrip.SuspendLayout()
        Me.SplitContainer.Panel1.SuspendLayout()
        Me.SplitContainer.Panel2.SuspendLayout()
        Me.SplitContainer.SuspendLayout()
        CType(Me.PicImg, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        GroupBox1.Controls.Add(Me.CbEmpresas)
        GroupBox1.Controls.Add(Me.Label2)
        GroupBox1.Location = New System.Drawing.Point(12, 3)
        GroupBox1.Name = "GroupBox1"
        GroupBox1.Size = New System.Drawing.Size(466, 98)
        GroupBox1.TabIndex = 1
        GroupBox1.TabStop = False
        GroupBox1.Text = "Detalles de Inicio"
        '
        'CbEmpresas
        '
        Me.CbEmpresas.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CbEmpresas.Font = New System.Drawing.Font("Tahoma", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CbEmpresas.FormattingEnabled = True
        Me.CbEmpresas.Location = New System.Drawing.Point(12, 39)
        Me.CbEmpresas.Name = "CbEmpresas"
        Me.CbEmpresas.Size = New System.Drawing.Size(438, 37)
        Me.CbEmpresas.TabIndex = 0
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Tahoma", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(16, 25)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(214, 11)
        Me.Label2.TabIndex = 23
        Me.Label2.Text = "SELECCIONE LA BASE DE DATOS DE INICIO"
        '
        'ToolStrip
        '
        ToolStrip.Dock = System.Windows.Forms.DockStyle.Bottom
        ToolStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        ToolStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.LblInfo, Me.BtOk, Me.BtCancell})
        ToolStrip.Location = New System.Drawing.Point(0, 59)
        ToolStrip.Name = "ToolStrip"
        ToolStrip.Size = New System.Drawing.Size(490, 25)
        ToolStrip.TabIndex = 40
        '
        'LblInfo
        '
        Me.LblInfo.AutoSize = False
        Me.LblInfo.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblInfo.Margin = New System.Windows.Forms.Padding(7, 1, 0, 2)
        Me.LblInfo.Name = "LblInfo"
        Me.LblInfo.Size = New System.Drawing.Size(180, 22)
        Me.LblInfo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'BtOk
        '
        Me.BtOk.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.BtOk.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtOk.Image = CType(resources.GetObject("BtOk.Image"), System.Drawing.Image)
        Me.BtOk.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BtOk.Name = "BtOk"
        Me.BtOk.Size = New System.Drawing.Size(63, 22)
        Me.BtOk.Tag = ""
        Me.BtOk.Text = "Iniciar"
        '
        'BtCancell
        '
        Me.BtCancell.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.BtCancell.Image = CType(resources.GetObject("BtCancell.Image"), System.Drawing.Image)
        Me.BtCancell.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BtCancell.Name = "BtCancell"
        Me.BtCancell.Size = New System.Drawing.Size(73, 22)
        Me.BtCancell.Tag = "cancelar"
        Me.BtCancell.Text = "Cancelar"
        '
        'Label5
        '
        Label5.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Label5.Location = New System.Drawing.Point(74, 31)
        Label5.Name = "Label5"
        Label5.Size = New System.Drawing.Size(296, 22)
        Label5.TabIndex = 6
        Label5.Text = "Especifique la base de datos desde la que va iniciar"
        '
        'SplitContainer
        '
        Me.SplitContainer.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer.FixedPanel = System.Windows.Forms.FixedPanel.Panel1
        Me.SplitContainer.IsSplitterFixed = True
        Me.SplitContainer.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainer.Name = "SplitContainer"
        Me.SplitContainer.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'SplitContainer.Panel1
        '
        Me.SplitContainer.Panel1.BackColor = System.Drawing.SystemColors.InactiveCaption
        Me.SplitContainer.Panel1.Controls.Add(ToolStrip)
        Me.SplitContainer.Panel1.Controls.Add(Me.PicImg)
        Me.SplitContainer.Panel1.Controls.Add(Me.Label4)
        Me.SplitContainer.Panel1.Controls.Add(Label5)
        '
        'SplitContainer.Panel2
        '
        Me.SplitContainer.Panel2.Controls.Add(GroupBox1)
        Me.SplitContainer.Size = New System.Drawing.Size(490, 201)
        Me.SplitContainer.SplitterDistance = 84
        Me.SplitContainer.SplitterWidth = 1
        Me.SplitContainer.TabIndex = 0
        '
        'PicImg
        '
        Me.PicImg.Image = CType(resources.GetObject("PicImg.Image"), System.Drawing.Image)
        Me.PicImg.Location = New System.Drawing.Point(5, 5)
        Me.PicImg.Name = "PicImg"
        Me.PicImg.Size = New System.Drawing.Size(48, 48)
        Me.PicImg.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.PicImg.TabIndex = 38
        Me.PicImg.TabStop = False
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(64, 9)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(137, 19)
        Me.Label4.TabIndex = 7
        Me.Label4.Text = "Inicio de Sesión"
        '
        'frmSeleccionaDB
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(490, 201)
        Me.Controls.Add(Me.SplitContainer)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.Name = "frmSeleccionaDB"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Inicio de Sesión"
        GroupBox1.ResumeLayout(False)
        GroupBox1.PerformLayout()
        ToolStrip.ResumeLayout(False)
        ToolStrip.PerformLayout()
        Me.SplitContainer.Panel1.ResumeLayout(False)
        Me.SplitContainer.Panel1.PerformLayout()
        Me.SplitContainer.Panel2.ResumeLayout(False)
        Me.SplitContainer.ResumeLayout(False)
        CType(Me.PicImg, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents SplitContainer As System.Windows.Forms.SplitContainer
    Friend WithEvents LblInfo As System.Windows.Forms.ToolStripLabel
    Friend WithEvents BtOk As System.Windows.Forms.ToolStripButton
    Friend WithEvents BtCancell As System.Windows.Forms.ToolStripButton
    Friend WithEvents PicImg As System.Windows.Forms.PictureBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents CbEmpresas As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
End Class
