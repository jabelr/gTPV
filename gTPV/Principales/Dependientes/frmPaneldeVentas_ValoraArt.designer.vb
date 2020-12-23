<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmPaneldeVentas_ValoraArt
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmPaneldeVentas_ValoraArt))
        Me.LblName = New System.Windows.Forms.Label
        Me.GroupBox4 = New System.Windows.Forms.GroupBox
        Me.Rbt_3 = New System.Windows.Forms.RadioButton
        Me.Rbt_2 = New System.Windows.Forms.RadioButton
        Me.Rbt_1 = New System.Windows.Forms.RadioButton
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.BtCancela = New System.Windows.Forms.Button
        Me.BtOK = New System.Windows.Forms.Button
        Me.Tmr = New System.Windows.Forms.Timer(Me.components)
        Me.Label330 = New System.Windows.Forms.Label
        Me.pnlObs = New System.Windows.Forms.Panel
        Me.txtObs = New System.Windows.Forms.TextBox
        Me.GroupBox4.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.pnlObs.SuspendLayout()
        Me.SuspendLayout()
        '
        'LblName
        '
        Me.LblName.BackColor = System.Drawing.Color.Transparent
        Me.LblName.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblName.Location = New System.Drawing.Point(39, 37)
        Me.LblName.Name = "LblName"
        Me.LblName.Size = New System.Drawing.Size(317, 23)
        Me.LblName.TabIndex = 0
        Me.LblName.Text = "SELECCIONE TIPO"
        Me.LblName.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.Rbt_3)
        Me.GroupBox4.Controls.Add(Me.Rbt_2)
        Me.GroupBox4.Controls.Add(Me.Rbt_1)
        Me.GroupBox4.Location = New System.Drawing.Point(43, 69)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(221, 245)
        Me.GroupBox4.TabIndex = 1
        Me.GroupBox4.TabStop = False
        '
        'Rbt_3
        '
        Me.Rbt_3.Appearance = System.Windows.Forms.Appearance.Button
        Me.Rbt_3.Dock = System.Windows.Forms.DockStyle.Top
        Me.Rbt_3.Font = New System.Drawing.Font("Tahoma", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Rbt_3.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Rbt_3.Location = New System.Drawing.Point(3, 154)
        Me.Rbt_3.Name = "Rbt_3"
        Me.Rbt_3.Size = New System.Drawing.Size(215, 69)
        Me.Rbt_3.TabIndex = 2
        Me.Rbt_3.TabStop = True
        Me.Rbt_3.Tag = "3"
        Me.Rbt_3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.Rbt_3.UseVisualStyleBackColor = True
        Me.Rbt_3.Visible = False
        '
        'Rbt_2
        '
        Me.Rbt_2.Appearance = System.Windows.Forms.Appearance.Button
        Me.Rbt_2.Dock = System.Windows.Forms.DockStyle.Top
        Me.Rbt_2.Font = New System.Drawing.Font("Tahoma", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Rbt_2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Rbt_2.Location = New System.Drawing.Point(3, 85)
        Me.Rbt_2.Name = "Rbt_2"
        Me.Rbt_2.Size = New System.Drawing.Size(215, 69)
        Me.Rbt_2.TabIndex = 1
        Me.Rbt_2.TabStop = True
        Me.Rbt_2.Tag = "2"
        Me.Rbt_2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.Rbt_2.UseVisualStyleBackColor = True
        Me.Rbt_2.Visible = False
        '
        'Rbt_1
        '
        Me.Rbt_1.Appearance = System.Windows.Forms.Appearance.Button
        Me.Rbt_1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Rbt_1.Font = New System.Drawing.Font("Tahoma", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Rbt_1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Rbt_1.Location = New System.Drawing.Point(3, 16)
        Me.Rbt_1.Name = "Rbt_1"
        Me.Rbt_1.Size = New System.Drawing.Size(215, 69)
        Me.Rbt_1.TabIndex = 0
        Me.Rbt_1.TabStop = True
        Me.Rbt_1.Tag = "1"
        Me.Rbt_1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.Rbt_1.UseVisualStyleBackColor = True
        Me.Rbt_1.Visible = False
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.BtCancela)
        Me.GroupBox3.Controls.Add(Me.BtOK)
        Me.GroupBox3.Location = New System.Drawing.Point(270, 69)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(88, 267)
        Me.GroupBox3.TabIndex = 3
        Me.GroupBox3.TabStop = False
        '
        'BtCancela
        '
        Me.BtCancela.BackColor = System.Drawing.SystemColors.Control
        Me.BtCancela.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.BtCancela.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtCancela.Image = CType(resources.GetObject("BtCancela.Image"), System.Drawing.Image)
        Me.BtCancela.Location = New System.Drawing.Point(6, 17)
        Me.BtCancela.Name = "BtCancela"
        Me.BtCancela.Size = New System.Drawing.Size(76, 68)
        Me.BtCancela.TabIndex = 0
        Me.BtCancela.Tag = ""
        Me.BtCancela.UseVisualStyleBackColor = False
        '
        'BtOK
        '
        Me.BtOK.Enabled = False
        Me.BtOK.Font = New System.Drawing.Font("Tahoma", 26.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtOK.Image = CType(resources.GetObject("BtOK.Image"), System.Drawing.Image)
        Me.BtOK.Location = New System.Drawing.Point(6, 193)
        Me.BtOK.Name = "BtOK"
        Me.BtOK.Size = New System.Drawing.Size(76, 68)
        Me.BtOK.TabIndex = 2
        Me.BtOK.UseVisualStyleBackColor = True
        '
        'Tmr
        '
        Me.Tmr.Interval = 1500
        '
        'Label330
        '
        Me.Label330.BackColor = System.Drawing.Color.LightSteelBlue
        Me.Label330.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label330.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label330.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label330.Location = New System.Drawing.Point(0, 0)
        Me.Label330.Name = "Label330"
        Me.Label330.Size = New System.Drawing.Size(315, 19)
        Me.Label330.TabIndex = 44
        Me.Label330.Tag = ""
        Me.Label330.Text = " OBSERVACIONES"
        Me.Label330.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'pnlObs
        '
        Me.pnlObs.Controls.Add(Me.txtObs)
        Me.pnlObs.Controls.Add(Me.Label330)
        Me.pnlObs.Location = New System.Drawing.Point(43, 339)
        Me.pnlObs.Name = "pnlObs"
        Me.pnlObs.Size = New System.Drawing.Size(315, 84)
        Me.pnlObs.TabIndex = 45
        Me.pnlObs.Visible = False
        '
        'txtObs
        '
        Me.txtObs.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtObs.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtObs.Location = New System.Drawing.Point(0, 19)
        Me.txtObs.Multiline = True
        Me.txtObs.Name = "txtObs"
        Me.txtObs.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtObs.Size = New System.Drawing.Size(315, 65)
        Me.txtObs.TabIndex = 45
        '
        'frmPaneldeVentas_ValoraArt
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(174, Byte), Integer), CType(CType(186, Byte), Integer), CType(CType(186, Byte), Integer))
        Me.BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), System.Drawing.Image)
        Me.ClientSize = New System.Drawing.Size(399, 458)
        Me.Controls.Add(Me.pnlObs)
        Me.Controls.Add(Me.GroupBox4)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.LblName)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmPaneldeVentas_ValoraArt"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Variaciones del Artículo"
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox3.ResumeLayout(False)
        Me.pnlObs.ResumeLayout(False)
        Me.pnlObs.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents LblName As System.Windows.Forms.Label
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents BtCancela As System.Windows.Forms.Button
    Friend WithEvents BtOK As System.Windows.Forms.Button
    Friend WithEvents Tmr As System.Windows.Forms.Timer
    Friend WithEvents Rbt_1 As System.Windows.Forms.RadioButton
    Friend WithEvents Rbt_3 As System.Windows.Forms.RadioButton
    Friend WithEvents Rbt_2 As System.Windows.Forms.RadioButton
    Friend WithEvents Label330 As System.Windows.Forms.Label
    Friend WithEvents pnlObs As System.Windows.Forms.Panel
    Friend WithEvents txtObs As System.Windows.Forms.TextBox

End Class
