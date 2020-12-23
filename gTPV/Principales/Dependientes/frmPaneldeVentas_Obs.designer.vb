<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmPaneldeVentas_Obs
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmPaneldeVentas_Obs))
        Me.LblName = New System.Windows.Forms.Label
        Me.BtCancela = New System.Windows.Forms.Button
        Me.BtOK = New System.Windows.Forms.Button
        Me.Tmr = New System.Windows.Forms.Timer(Me.components)
        Me.Label330 = New System.Windows.Forms.Label
        Me.pnlObs = New System.Windows.Forms.Panel
        Me.txtObs = New System.Windows.Forms.TextBox
        Me.pnlObs.SuspendLayout()
        Me.SuspendLayout()
        '
        'LblName
        '
        Me.LblName.BackColor = System.Drawing.Color.Transparent
        Me.LblName.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblName.Location = New System.Drawing.Point(39, 37)
        Me.LblName.Name = "LblName"
        Me.LblName.Size = New System.Drawing.Size(214, 23)
        Me.LblName.TabIndex = 0
        Me.LblName.Text = "OBSERVACIONES"
        Me.LblName.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'BtCancela
        '
        Me.BtCancela.BackColor = System.Drawing.SystemColors.Control
        Me.BtCancela.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.BtCancela.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtCancela.Image = CType(resources.GetObject("BtCancela.Image"), System.Drawing.Image)
        Me.BtCancela.Location = New System.Drawing.Point(250, 12)
        Me.BtCancela.Name = "BtCancela"
        Me.BtCancela.Size = New System.Drawing.Size(55, 50)
        Me.BtCancela.TabIndex = 0
        Me.BtCancela.Tag = ""
        Me.BtCancela.UseVisualStyleBackColor = False
        '
        'BtOK
        '
        Me.BtOK.Enabled = False
        Me.BtOK.Font = New System.Drawing.Font("Tahoma", 26.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtOK.Image = CType(resources.GetObject("BtOK.Image"), System.Drawing.Image)
        Me.BtOK.Location = New System.Drawing.Point(311, 12)
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
        Me.Label330.Size = New System.Drawing.Size(318, 19)
        Me.Label330.TabIndex = 44
        Me.Label330.Tag = ""
        Me.Label330.Text = " OBSERVACIONES"
        Me.Label330.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'pnlObs
        '
        Me.pnlObs.Controls.Add(Me.txtObs)
        Me.pnlObs.Controls.Add(Me.Label330)
        Me.pnlObs.Location = New System.Drawing.Point(43, 86)
        Me.pnlObs.Name = "pnlObs"
        Me.pnlObs.Size = New System.Drawing.Size(318, 332)
        Me.pnlObs.TabIndex = 45
        '
        'txtObs
        '
        Me.txtObs.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtObs.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtObs.Location = New System.Drawing.Point(0, 19)
        Me.txtObs.Multiline = True
        Me.txtObs.Name = "txtObs"
        Me.txtObs.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtObs.Size = New System.Drawing.Size(318, 313)
        Me.txtObs.TabIndex = 45
        '
        'frmPaneldeVentas_Obs
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(174, Byte), Integer), CType(CType(186, Byte), Integer), CType(CType(186, Byte), Integer))
        Me.BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), System.Drawing.Image)
        Me.ClientSize = New System.Drawing.Size(399, 458)
        Me.Controls.Add(Me.BtCancela)
        Me.Controls.Add(Me.pnlObs)
        Me.Controls.Add(Me.BtOK)
        Me.Controls.Add(Me.LblName)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmPaneldeVentas_Obs"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Variaciones del Artículo"
        Me.pnlObs.ResumeLayout(False)
        Me.pnlObs.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents LblName As System.Windows.Forms.Label
    Friend WithEvents BtCancela As System.Windows.Forms.Button
    Friend WithEvents BtOK As System.Windows.Forms.Button
    Friend WithEvents Tmr As System.Windows.Forms.Timer
    Friend WithEvents Label330 As System.Windows.Forms.Label
    Friend WithEvents pnlObs As System.Windows.Forms.Panel
    Friend WithEvents txtObs As System.Windows.Forms.TextBox

End Class
