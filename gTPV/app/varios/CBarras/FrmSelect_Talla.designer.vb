<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSelect_Talla
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmSelect_Talla))
        Dim Label13 As System.Windows.Forms.Label
        Dim Label6 As System.Windows.Forms.Label
        Dim Label10 As System.Windows.Forms.Label
        Dim Label7 As System.Windows.Forms.Label
        Dim Label11 As System.Windows.Forms.Label
        Dim Label9 As System.Windows.Forms.Label
        Dim Label8 As System.Windows.Forms.Label
        Me.LblTitle = New System.Windows.Forms.ToolStripLabel()
        Me.ToolStrip_Cancell = New System.Windows.Forms.ToolStripButton()
        Me.BtExport = New System.Windows.Forms.ToolStripButton()
        Me.LstTalla = New System.Windows.Forms.ListBox()
        Me.groupTallas = New System.Windows.Forms.GroupBox()
        Me.txtTalla_35 = New System.Windows.Forms.TextBox()
        Me.txtTalla_36 = New System.Windows.Forms.TextBox()
        Me.txtTalla_37 = New System.Windows.Forms.TextBox()
        Me.txtTalla_41 = New System.Windows.Forms.TextBox()
        Me.txtTalla_38 = New System.Windows.Forms.TextBox()
        Me.txtTalla_40 = New System.Windows.Forms.TextBox()
        Me.txtTalla_39 = New System.Windows.Forms.TextBox()
        ToolStrip = New System.Windows.Forms.ToolStrip()
        Label13 = New System.Windows.Forms.Label()
        Label6 = New System.Windows.Forms.Label()
        Label10 = New System.Windows.Forms.Label()
        Label7 = New System.Windows.Forms.Label()
        Label11 = New System.Windows.Forms.Label()
        Label9 = New System.Windows.Forms.Label()
        Label8 = New System.Windows.Forms.Label()
        ToolStrip.SuspendLayout()
        Me.groupTallas.SuspendLayout()
        Me.SuspendLayout()
        '
        'ToolStrip
        '
        ToolStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        ToolStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.LblTitle, Me.ToolStrip_Cancell, Me.BtExport})
        ToolStrip.Location = New System.Drawing.Point(0, 0)
        ToolStrip.Name = "ToolStrip"
        ToolStrip.Size = New System.Drawing.Size(448, 25)
        ToolStrip.TabIndex = 1
        '
        'LblTitle
        '
        Me.LblTitle.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblTitle.Name = "LblTitle"
        Me.LblTitle.Size = New System.Drawing.Size(106, 22)
        Me.LblTitle.Text = "Tallas disponibles"
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
        Me.ToolStrip_Cancell.Text = "Cancelar"
        '
        'BtExport
        '
        Me.BtExport.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.BtExport.Image = CType(resources.GetObject("BtExport.Image"), System.Drawing.Image)
        Me.BtExport.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BtExport.Name = "BtExport"
        Me.BtExport.Size = New System.Drawing.Size(76, 22)
        Me.BtExport.Tag = ""
        Me.BtExport.Text = "Siguiente"
        '
        'LstTalla
        '
        Me.LstTalla.Dock = System.Windows.Forms.DockStyle.Left
        Me.LstTalla.Font = New System.Drawing.Font("Tahoma", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LstTalla.FormattingEnabled = True
        Me.LstTalla.ItemHeight = 25
        Me.LstTalla.Location = New System.Drawing.Point(0, 25)
        Me.LstTalla.Name = "LstTalla"
        Me.LstTalla.Size = New System.Drawing.Size(229, 347)
        Me.LstTalla.TabIndex = 0
        '
        'groupTallas
        '
        Me.groupTallas.Controls.Add(Me.txtTalla_35)
        Me.groupTallas.Controls.Add(Label13)
        Me.groupTallas.Controls.Add(Me.txtTalla_36)
        Me.groupTallas.Controls.Add(Label6)
        Me.groupTallas.Controls.Add(Label10)
        Me.groupTallas.Controls.Add(Me.txtTalla_37)
        Me.groupTallas.Controls.Add(Me.txtTalla_41)
        Me.groupTallas.Controls.Add(Label7)
        Me.groupTallas.Controls.Add(Label11)
        Me.groupTallas.Controls.Add(Me.txtTalla_38)
        Me.groupTallas.Controls.Add(Me.txtTalla_40)
        Me.groupTallas.Controls.Add(Label9)
        Me.groupTallas.Controls.Add(Label8)
        Me.groupTallas.Controls.Add(Me.txtTalla_39)
        Me.groupTallas.Location = New System.Drawing.Point(247, 28)
        Me.groupTallas.Name = "groupTallas"
        Me.groupTallas.Size = New System.Drawing.Size(162, 226)
        Me.groupTallas.TabIndex = 39
        Me.groupTallas.TabStop = False
        Me.groupTallas.Text = "Nº de Etiquetas"
        '
        'txtTalla_35
        '
        Me.txtTalla_35.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTalla_35.Location = New System.Drawing.Point(69, 27)
        Me.txtTalla_35.Margin = New System.Windows.Forms.Padding(0)
        Me.txtTalla_35.Name = "txtTalla_35"
        Me.txtTalla_35.Size = New System.Drawing.Size(61, 27)
        Me.txtTalla_35.TabIndex = 0
        Me.txtTalla_35.Tag = "talla_35"
        '
        'Label13
        '
        Label13.BackColor = System.Drawing.Color.LightSteelBlue
        Label13.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Label13.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Label13.Location = New System.Drawing.Point(14, 27)
        Label13.Name = "Label13"
        Label13.Size = New System.Drawing.Size(52, 27)
        Label13.TabIndex = 37
        Label13.Text = "35"
        Label13.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtTalla_36
        '
        Me.txtTalla_36.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTalla_36.Location = New System.Drawing.Point(69, 54)
        Me.txtTalla_36.Margin = New System.Windows.Forms.Padding(0)
        Me.txtTalla_36.Name = "txtTalla_36"
        Me.txtTalla_36.Size = New System.Drawing.Size(61, 27)
        Me.txtTalla_36.TabIndex = 1
        Me.txtTalla_36.Tag = "talla_36"
        '
        'Label6
        '
        Label6.BackColor = System.Drawing.Color.LightSteelBlue
        Label6.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Label6.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Label6.Location = New System.Drawing.Point(14, 54)
        Label6.Name = "Label6"
        Label6.Size = New System.Drawing.Size(52, 27)
        Label6.TabIndex = 25
        Label6.Text = "36"
        Label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label10
        '
        Label10.BackColor = System.Drawing.Color.LightSteelBlue
        Label10.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Label10.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Label10.Location = New System.Drawing.Point(14, 189)
        Label10.Name = "Label10"
        Label10.Size = New System.Drawing.Size(52, 27)
        Label10.TabIndex = 35
        Label10.Text = "41"
        Label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtTalla_37
        '
        Me.txtTalla_37.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTalla_37.Location = New System.Drawing.Point(69, 81)
        Me.txtTalla_37.Margin = New System.Windows.Forms.Padding(0)
        Me.txtTalla_37.Name = "txtTalla_37"
        Me.txtTalla_37.Size = New System.Drawing.Size(61, 27)
        Me.txtTalla_37.TabIndex = 2
        Me.txtTalla_37.Tag = "talla_37"
        '
        'txtTalla_41
        '
        Me.txtTalla_41.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTalla_41.Location = New System.Drawing.Point(69, 189)
        Me.txtTalla_41.Margin = New System.Windows.Forms.Padding(0)
        Me.txtTalla_41.Name = "txtTalla_41"
        Me.txtTalla_41.Size = New System.Drawing.Size(61, 27)
        Me.txtTalla_41.TabIndex = 6
        Me.txtTalla_41.Tag = "talla_41"
        '
        'Label7
        '
        Label7.BackColor = System.Drawing.Color.LightSteelBlue
        Label7.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Label7.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Label7.Location = New System.Drawing.Point(14, 81)
        Label7.Name = "Label7"
        Label7.Size = New System.Drawing.Size(52, 27)
        Label7.TabIndex = 27
        Label7.Text = "37"
        Label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label11
        '
        Label11.BackColor = System.Drawing.Color.LightSteelBlue
        Label11.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Label11.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Label11.Location = New System.Drawing.Point(14, 162)
        Label11.Name = "Label11"
        Label11.Size = New System.Drawing.Size(52, 27)
        Label11.TabIndex = 33
        Label11.Text = "40"
        Label11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtTalla_38
        '
        Me.txtTalla_38.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTalla_38.Location = New System.Drawing.Point(69, 108)
        Me.txtTalla_38.Margin = New System.Windows.Forms.Padding(0)
        Me.txtTalla_38.Name = "txtTalla_38"
        Me.txtTalla_38.Size = New System.Drawing.Size(61, 27)
        Me.txtTalla_38.TabIndex = 3
        Me.txtTalla_38.Tag = "talla_38"
        '
        'txtTalla_40
        '
        Me.txtTalla_40.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTalla_40.Location = New System.Drawing.Point(69, 162)
        Me.txtTalla_40.Margin = New System.Windows.Forms.Padding(0)
        Me.txtTalla_40.Name = "txtTalla_40"
        Me.txtTalla_40.Size = New System.Drawing.Size(61, 27)
        Me.txtTalla_40.TabIndex = 5
        Me.txtTalla_40.Tag = "talla_40"
        '
        'Label9
        '
        Label9.BackColor = System.Drawing.Color.LightSteelBlue
        Label9.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Label9.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Label9.Location = New System.Drawing.Point(14, 108)
        Label9.Name = "Label9"
        Label9.Size = New System.Drawing.Size(52, 27)
        Label9.TabIndex = 29
        Label9.Text = "38"
        Label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label8
        '
        Label8.BackColor = System.Drawing.Color.LightSteelBlue
        Label8.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Label8.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Label8.Location = New System.Drawing.Point(14, 135)
        Label8.Name = "Label8"
        Label8.Size = New System.Drawing.Size(52, 27)
        Label8.TabIndex = 31
        Label8.Text = "39"
        Label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtTalla_39
        '
        Me.txtTalla_39.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTalla_39.Location = New System.Drawing.Point(69, 135)
        Me.txtTalla_39.Margin = New System.Windows.Forms.Padding(0)
        Me.txtTalla_39.Name = "txtTalla_39"
        Me.txtTalla_39.Size = New System.Drawing.Size(61, 27)
        Me.txtTalla_39.TabIndex = 4
        Me.txtTalla_39.Tag = "talla_39"
        '
        'frmSelect_Talla
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(448, 372)
        Me.Controls.Add(Me.groupTallas)
        Me.Controls.Add(Me.LstTalla)
        Me.Controls.Add(ToolStrip)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmSelect_Talla"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Especificación de Etiquetas"
        ToolStrip.ResumeLayout(False)
        ToolStrip.PerformLayout()
        Me.groupTallas.ResumeLayout(False)
        Me.groupTallas.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents LblTitle As System.Windows.Forms.ToolStripLabel
    Friend WithEvents ToolStrip_Cancell As System.Windows.Forms.ToolStripButton
    Friend WithEvents BtExport As System.Windows.Forms.ToolStripButton
    Friend WithEvents LstTalla As System.Windows.Forms.ListBox
    Friend WithEvents groupTallas As System.Windows.Forms.GroupBox
    Friend WithEvents txtTalla_35 As System.Windows.Forms.TextBox
    Friend WithEvents txtTalla_36 As System.Windows.Forms.TextBox
    Friend WithEvents txtTalla_37 As System.Windows.Forms.TextBox
    Friend WithEvents txtTalla_41 As System.Windows.Forms.TextBox
    Friend WithEvents txtTalla_38 As System.Windows.Forms.TextBox
    Friend WithEvents txtTalla_40 As System.Windows.Forms.TextBox
    Friend WithEvents txtTalla_39 As System.Windows.Forms.TextBox
End Class
