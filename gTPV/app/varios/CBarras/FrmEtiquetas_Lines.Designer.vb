<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmEtiquetas_Lines
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmEtiquetas_Lines))
        Dim Group_Barras As System.Windows.Forms.GroupBox
        Me.LblTitle = New System.Windows.Forms.ToolStripLabel()
        Me.ToolStrip_Cancell = New System.Windows.Forms.ToolStripButton()
        Me.ToolStrip_Save = New System.Windows.Forms.ToolStripButton()
        Me.ChkPrint_Name = New System.Windows.Forms.CheckBox()
        Me.Num_Etiquetas = New System.Windows.Forms.NumericUpDown()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.PicBarCode = New System.Windows.Forms.PictureBox()
        ToolStrip = New System.Windows.Forms.ToolStrip()
        Group_Barras = New System.Windows.Forms.GroupBox()
        ToolStrip.SuspendLayout()
        Group_Barras.SuspendLayout()
        CType(Me.Num_Etiquetas, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PicBarCode, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ToolStrip
        '
        ToolStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        ToolStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.LblTitle, Me.ToolStrip_Cancell, Me.ToolStrip_Save})
        ToolStrip.Location = New System.Drawing.Point(0, 0)
        ToolStrip.Name = "ToolStrip"
        ToolStrip.Size = New System.Drawing.Size(337, 25)
        ToolStrip.TabIndex = 1
        '
        'LblTitle
        '
        Me.LblTitle.AutoSize = False
        Me.LblTitle.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblTitle.Name = "LblTitle"
        Me.LblTitle.Size = New System.Drawing.Size(200, 22)
        Me.LblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'ToolStrip_Cancell
        '
        Me.ToolStrip_Cancell.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.ToolStrip_Cancell.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStrip_Cancell.Image = CType(resources.GetObject("ToolStrip_Cancell.Image"), System.Drawing.Image)
        Me.ToolStrip_Cancell.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStrip_Cancell.Name = "ToolStrip_Cancell"
        Me.ToolStrip_Cancell.Size = New System.Drawing.Size(23, 22)
        Me.ToolStrip_Cancell.Tag = "cancelar"
        Me.ToolStrip_Cancell.Text = "Cancelar [Control + C]"
        '
        'ToolStrip_Save
        '
        Me.ToolStrip_Save.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.ToolStrip_Save.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStrip_Save.Image = CType(resources.GetObject("ToolStrip_Save.Image"), System.Drawing.Image)
        Me.ToolStrip_Save.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStrip_Save.Name = "ToolStrip_Save"
        Me.ToolStrip_Save.Size = New System.Drawing.Size(23, 22)
        Me.ToolStrip_Save.Tag = "guardar"
        Me.ToolStrip_Save.Text = "Guardar [Control + G]"
        '
        'Group_Barras
        '
        Group_Barras.Controls.Add(Me.ChkPrint_Name)
        Group_Barras.Controls.Add(Me.Num_Etiquetas)
        Group_Barras.Controls.Add(Me.Label1)
        Group_Barras.Controls.Add(Me.PicBarCode)
        Group_Barras.Location = New System.Drawing.Point(12, 28)
        Group_Barras.Name = "Group_Barras"
        Group_Barras.Size = New System.Drawing.Size(308, 194)
        Group_Barras.TabIndex = 0
        Group_Barras.TabStop = False
        Group_Barras.Text = "Etiqueta"
        '
        'ChkPrint_Name
        '
        Me.ChkPrint_Name.AutoSize = True
        Me.ChkPrint_Name.Checked = True
        Me.ChkPrint_Name.CheckState = System.Windows.Forms.CheckState.Checked
        Me.ChkPrint_Name.Location = New System.Drawing.Point(17, 158)
        Me.ChkPrint_Name.Name = "ChkPrint_Name"
        Me.ChkPrint_Name.Size = New System.Drawing.Size(180, 17)
        Me.ChkPrint_Name.TabIndex = 1
        Me.ChkPrint_Name.Text = "Incluir nombre y precio al imprimir"
        Me.ChkPrint_Name.UseVisualStyleBackColor = True
        '
        'Num_Etiquetas
        '
        Me.Num_Etiquetas.Location = New System.Drawing.Point(125, 121)
        Me.Num_Etiquetas.Name = "Num_Etiquetas"
        Me.Num_Etiquetas.Size = New System.Drawing.Size(97, 20)
        Me.Num_Etiquetas.TabIndex = 0
        Me.Num_Etiquetas.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(14, 123)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(105, 13)
        Me.Label1.TabIndex = 7
        Me.Label1.Text = "Número de etiquetas"
        '
        'PicBarCode
        '
        Me.PicBarCode.BackColor = System.Drawing.Color.White
        Me.PicBarCode.Location = New System.Drawing.Point(32, 23)
        Me.PicBarCode.Name = "PicBarCode"
        Me.PicBarCode.Size = New System.Drawing.Size(256, 81)
        Me.PicBarCode.TabIndex = 6
        Me.PicBarCode.TabStop = False
        '
        'FrmEtiquetas_Lines
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(337, 234)
        Me.Controls.Add(Group_Barras)
        Me.Controls.Add(ToolStrip)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmEtiquetas_Lines"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Impresión de Etiquetas"
        ToolStrip.ResumeLayout(False)
        ToolStrip.PerformLayout()
        Group_Barras.ResumeLayout(False)
        Group_Barras.PerformLayout()
        CType(Me.Num_Etiquetas, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PicBarCode, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents LblTitle As System.Windows.Forms.ToolStripLabel
    Friend WithEvents ToolStrip_Cancell As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStrip_Save As System.Windows.Forms.ToolStripButton
    Friend WithEvents PicBarCode As System.Windows.Forms.PictureBox
    Friend WithEvents Num_Etiquetas As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents ChkPrint_Name As System.Windows.Forms.CheckBox
End Class
