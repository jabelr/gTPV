<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCompras_lines
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
        Dim ToolStrip As System.Windows.Forms.ToolStrip
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmCompras_lines))
        Dim LblSubName As System.Windows.Forms.Label
        Dim Label10 As System.Windows.Forms.Label
        Dim Label11 As System.Windows.Forms.Label
        Dim Label12 As System.Windows.Forms.Label
        Dim Label13 As System.Windows.Forms.Label
        Dim Label14 As System.Windows.Forms.Label
        Me.LblTitle = New System.Windows.Forms.ToolStripLabel
        Me.BtToolCancell = New System.Windows.Forms.ToolStripButton
        Me.BtToolSave = New System.Windows.Forms.ToolStripButton
        Me.TxtDto = New System.Windows.Forms.TextBox
        Me.LblIva = New System.Windows.Forms.Label
        Me.TxtUD = New System.Windows.Forms.TextBox
        Me.LblNfo = New System.Windows.Forms.Label
        Me.TxtName = New System.Windows.Forms.TextBox
        Me.TxtTotal = New System.Windows.Forms.TextBox
        Me.SplitContainer = New System.Windows.Forms.SplitContainer
        Me.LblId = New System.Windows.Forms.Label
        Me.PicImg = New System.Windows.Forms.PictureBox
        Me.LblName = New System.Windows.Forms.Label
        Me.CbIVA = New System.Windows.Forms.ComboBox
        ToolStrip = New System.Windows.Forms.ToolStrip
        LblSubName = New System.Windows.Forms.Label
        Label10 = New System.Windows.Forms.Label
        Label11 = New System.Windows.Forms.Label
        Label12 = New System.Windows.Forms.Label
        Label13 = New System.Windows.Forms.Label
        Label14 = New System.Windows.Forms.Label
        ToolStrip.SuspendLayout()
        Me.SplitContainer.Panel1.SuspendLayout()
        Me.SplitContainer.Panel2.SuspendLayout()
        Me.SplitContainer.SuspendLayout()
        CType(Me.PicImg, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ToolStrip
        '
        ToolStrip.Dock = System.Windows.Forms.DockStyle.Bottom
        ToolStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        ToolStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.LblTitle, Me.BtToolCancell, Me.BtToolSave})
        ToolStrip.Location = New System.Drawing.Point(0, 59)
        ToolStrip.Name = "ToolStrip"
        ToolStrip.Size = New System.Drawing.Size(593, 25)
        ToolStrip.TabIndex = 40
        '
        'LblTitle
        '
        Me.LblTitle.AutoSize = False
        Me.LblTitle.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblTitle.Margin = New System.Windows.Forms.Padding(7, 1, 0, 2)
        Me.LblTitle.Name = "LblTitle"
        Me.LblTitle.Size = New System.Drawing.Size(280, 22)
        Me.LblTitle.Text = "ARTÍCULO"
        Me.LblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'BtToolCancell
        '
        Me.BtToolCancell.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.BtToolCancell.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BtToolCancell.Image = CType(resources.GetObject("BtToolCancell.Image"), System.Drawing.Image)
        Me.BtToolCancell.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BtToolCancell.Name = "BtToolCancell"
        Me.BtToolCancell.Size = New System.Drawing.Size(23, 22)
        Me.BtToolCancell.Tag = "cancelar"
        Me.BtToolCancell.Text = "Cancelar/Descartar [Control + D]"
        '
        'BtToolSave
        '
        Me.BtToolSave.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.BtToolSave.Image = CType(resources.GetObject("BtToolSave.Image"), System.Drawing.Image)
        Me.BtToolSave.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BtToolSave.Name = "BtToolSave"
        Me.BtToolSave.Size = New System.Drawing.Size(75, 22)
        Me.BtToolSave.Tag = "Guardar"
        Me.BtToolSave.Text = "  Guardar "
        Me.BtToolSave.ToolTipText = "Guardar [Control + G]"
        '
        'LblSubName
        '
        LblSubName.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        LblSubName.Location = New System.Drawing.Point(74, 31)
        LblSubName.Name = "LblSubName"
        LblSubName.Size = New System.Drawing.Size(508, 22)
        LblSubName.TabIndex = 6
        LblSubName.Text = "Detalles de la linea de compra"
        '
        'Label10
        '
        Label10.BackColor = System.Drawing.Color.LightSteelBlue
        Label10.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Label10.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Label10.ForeColor = System.Drawing.Color.Black
        Label10.Location = New System.Drawing.Point(6, 4)
        Label10.Margin = New System.Windows.Forms.Padding(0)
        Label10.Name = "Label10"
        Label10.Size = New System.Drawing.Size(318, 18)
        Label10.TabIndex = 1
        Label10.Text = "ARTÍCULO"
        Label10.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Label11
        '
        Label11.BackColor = System.Drawing.Color.LightSteelBlue
        Label11.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Label11.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Label11.ForeColor = System.Drawing.Color.Black
        Label11.Location = New System.Drawing.Point(324, 4)
        Label11.Margin = New System.Windows.Forms.Padding(0)
        Label11.Name = "Label11"
        Label11.Size = New System.Drawing.Size(60, 18)
        Label11.TabIndex = 2
        Label11.Text = "UD."
        Label11.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Label12
        '
        Label12.BackColor = System.Drawing.Color.LightSteelBlue
        Label12.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Label12.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Label12.ForeColor = System.Drawing.Color.Black
        Label12.Location = New System.Drawing.Point(384, 4)
        Label12.Margin = New System.Windows.Forms.Padding(0)
        Label12.Name = "Label12"
        Label12.Size = New System.Drawing.Size(52, 18)
        Label12.TabIndex = 3
        Label12.Text = "IVA"
        Label12.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Label13
        '
        Label13.BackColor = System.Drawing.Color.LightSteelBlue
        Label13.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Label13.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Label13.ForeColor = System.Drawing.Color.Black
        Label13.Location = New System.Drawing.Point(436, 4)
        Label13.Margin = New System.Windows.Forms.Padding(0)
        Label13.Name = "Label13"
        Label13.Size = New System.Drawing.Size(82, 18)
        Label13.TabIndex = 22
        Label13.Text = "PRECIO/UD"
        Label13.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Label14
        '
        Label14.BackColor = System.Drawing.Color.LightSteelBlue
        Label14.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Label14.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Label14.ForeColor = System.Drawing.Color.Black
        Label14.Location = New System.Drawing.Point(518, 4)
        Label14.Margin = New System.Windows.Forms.Padding(0)
        Label14.Name = "Label14"
        Label14.Size = New System.Drawing.Size(67, 18)
        Label14.TabIndex = 23
        Label14.Text = "% DTO"
        Label14.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'TxtDto
        '
        Me.TxtDto.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtDto.Location = New System.Drawing.Point(518, 22)
        Me.TxtDto.Margin = New System.Windows.Forms.Padding(0)
        Me.TxtDto.Name = "TxtDto"
        Me.TxtDto.Size = New System.Drawing.Size(67, 27)
        Me.TxtDto.TabIndex = 4
        '
        'LblIva
        '
        Me.LblIva.BackColor = System.Drawing.Color.Lavender
        Me.LblIva.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.LblIva.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblIva.ForeColor = System.Drawing.Color.Black
        Me.LblIva.Location = New System.Drawing.Point(246, 51)
        Me.LblIva.Margin = New System.Windows.Forms.Padding(0)
        Me.LblIva.Name = "LblIva"
        Me.LblIva.Size = New System.Drawing.Size(52, 27)
        Me.LblIva.TabIndex = 21
        Me.LblIva.Text = "Ud"
        Me.LblIva.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.LblIva.Visible = False
        '
        'TxtUD
        '
        Me.TxtUD.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtUD.Location = New System.Drawing.Point(324, 22)
        Me.TxtUD.Margin = New System.Windows.Forms.Padding(0)
        Me.TxtUD.Name = "TxtUD"
        Me.TxtUD.Size = New System.Drawing.Size(60, 27)
        Me.TxtUD.TabIndex = 1
        '
        'LblNfo
        '
        Me.LblNfo.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblNfo.ForeColor = System.Drawing.Color.SteelBlue
        Me.LblNfo.Location = New System.Drawing.Point(324, 51)
        Me.LblNfo.Name = "LblNfo"
        Me.LblNfo.Size = New System.Drawing.Size(261, 16)
        Me.LblNfo.TabIndex = 18
        Me.LblNfo.Text = "F1 - IVA Incluido, F2 - Precio Costo, F5 - Restablecer Precio"
        Me.LblNfo.Visible = False
        '
        'TxtName
        '
        Me.TxtName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtName.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtName.Location = New System.Drawing.Point(6, 22)
        Me.TxtName.Margin = New System.Windows.Forms.Padding(0)
        Me.TxtName.MaxLength = 150
        Me.TxtName.Name = "TxtName"
        Me.TxtName.ReadOnly = True
        Me.TxtName.Size = New System.Drawing.Size(318, 27)
        Me.TxtName.TabIndex = 0
        '
        'TxtTotal
        '
        Me.TxtTotal.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtTotal.Location = New System.Drawing.Point(436, 22)
        Me.TxtTotal.Margin = New System.Windows.Forms.Padding(0)
        Me.TxtTotal.Name = "TxtTotal"
        Me.TxtTotal.Size = New System.Drawing.Size(82, 27)
        Me.TxtTotal.TabIndex = 3
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
        Me.SplitContainer.Panel1.Controls.Add(Me.LblId)
        Me.SplitContainer.Panel1.Controls.Add(Me.PicImg)
        Me.SplitContainer.Panel1.Controls.Add(Me.LblName)
        Me.SplitContainer.Panel1.Controls.Add(LblSubName)
        '
        'SplitContainer.Panel2
        '
        Me.SplitContainer.Panel2.Controls.Add(Me.CbIVA)
        Me.SplitContainer.Panel2.Controls.Add(Me.TxtDto)
        Me.SplitContainer.Panel2.Controls.Add(Label14)
        Me.SplitContainer.Panel2.Controls.Add(Label13)
        Me.SplitContainer.Panel2.Controls.Add(Label12)
        Me.SplitContainer.Panel2.Controls.Add(Label11)
        Me.SplitContainer.Panel2.Controls.Add(Label10)
        Me.SplitContainer.Panel2.Controls.Add(Me.LblNfo)
        Me.SplitContainer.Panel2.Controls.Add(Me.TxtName)
        Me.SplitContainer.Panel2.Controls.Add(Me.TxtUD)
        Me.SplitContainer.Panel2.Controls.Add(Me.LblIva)
        Me.SplitContainer.Panel2.Controls.Add(Me.TxtTotal)
        Me.SplitContainer.Size = New System.Drawing.Size(593, 162)
        Me.SplitContainer.SplitterDistance = 84
        Me.SplitContainer.SplitterWidth = 1
        Me.SplitContainer.TabIndex = 22
        '
        'LblId
        '
        Me.LblId.Font = New System.Drawing.Font("Tahoma", 6.0!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblId.Location = New System.Drawing.Point(406, 9)
        Me.LblId.Name = "LblId"
        Me.LblId.Size = New System.Drawing.Size(76, 12)
        Me.LblId.TabIndex = 39
        Me.LblId.Tag = "id"
        Me.LblId.TextAlign = System.Drawing.ContentAlignment.TopRight
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
        'LblName
        '
        Me.LblName.AutoSize = True
        Me.LblName.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblName.Location = New System.Drawing.Point(64, 9)
        Me.LblName.Name = "LblName"
        Me.LblName.Size = New System.Drawing.Size(154, 19)
        Me.LblName.TabIndex = 7
        Me.LblName.Text = "Lineas de Compra"
        '
        'CbIVA
        '
        Me.CbIVA.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CbIVA.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CbIVA.Location = New System.Drawing.Point(384, 22)
        Me.CbIVA.Name = "CbIVA"
        Me.CbIVA.Size = New System.Drawing.Size(52, 27)
        Me.CbIVA.TabIndex = 2
        Me.CbIVA.Tag = "iva"
        '
        'frmCompras_lines
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Window
        Me.ClientSize = New System.Drawing.Size(593, 162)
        Me.Controls.Add(Me.SplitContainer)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmCompras_lines"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Lineas de Compra"
        ToolStrip.ResumeLayout(False)
        ToolStrip.PerformLayout()
        Me.SplitContainer.Panel1.ResumeLayout(False)
        Me.SplitContainer.Panel1.PerformLayout()
        Me.SplitContainer.Panel2.ResumeLayout(False)
        Me.SplitContainer.Panel2.PerformLayout()
        Me.SplitContainer.ResumeLayout(False)
        CType(Me.PicImg, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TxtUD As System.Windows.Forms.TextBox
    Friend WithEvents LblNfo As System.Windows.Forms.Label
    Friend WithEvents TxtName As System.Windows.Forms.TextBox
    Friend WithEvents TxtTotal As System.Windows.Forms.TextBox
    Friend WithEvents LblIva As System.Windows.Forms.Label
    Friend WithEvents TxtDto As System.Windows.Forms.TextBox
    Friend WithEvents SplitContainer As System.Windows.Forms.SplitContainer
    Friend WithEvents LblTitle As System.Windows.Forms.ToolStripLabel
    Friend WithEvents BtToolCancell As System.Windows.Forms.ToolStripButton
    Friend WithEvents BtToolSave As System.Windows.Forms.ToolStripButton
    Friend WithEvents LblId As System.Windows.Forms.Label
    Friend WithEvents PicImg As System.Windows.Forms.PictureBox
    Friend WithEvents LblName As System.Windows.Forms.Label
    Friend WithEvents CbIVA As System.Windows.Forms.ComboBox
End Class
