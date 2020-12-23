<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmPaneldeVentas_Name
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
        Dim Label6 As System.Windows.Forms.Label
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmPaneldeVentas_Name))
        Me.PnlAction_Buttons = New System.Windows.Forms.Panel
        Me.BtKeyBoard = New System.Windows.Forms.Button
        Me.BtCancell = New System.Windows.Forms.Button
        Me.BtOk = New System.Windows.Forms.Button
        Me.LblName = New System.Windows.Forms.Label
        Me.PnlGaleria = New System.Windows.Forms.Panel
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.TxtName = New System.Windows.Forms.TextBox
        Label6 = New System.Windows.Forms.Label
        Me.PnlAction_Buttons.SuspendLayout()
        Me.PnlGaleria.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label6
        '
        Label6.AutoSize = True
        Label6.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Label6.Location = New System.Drawing.Point(13, 16)
        Label6.Name = "Label6"
        Label6.Size = New System.Drawing.Size(145, 19)
        Label6.TabIndex = 7
        Label6.Text = "Nombre de la Mesa"
        '
        'PnlAction_Buttons
        '
        Me.PnlAction_Buttons.BackColor = System.Drawing.Color.Transparent
        Me.PnlAction_Buttons.Controls.Add(Me.BtKeyBoard)
        Me.PnlAction_Buttons.Controls.Add(Me.BtCancell)
        Me.PnlAction_Buttons.Controls.Add(Me.BtOk)
        Me.PnlAction_Buttons.Location = New System.Drawing.Point(365, 31)
        Me.PnlAction_Buttons.Name = "PnlAction_Buttons"
        Me.PnlAction_Buttons.Size = New System.Drawing.Size(230, 70)
        Me.PnlAction_Buttons.TabIndex = 1
        Me.PnlAction_Buttons.Tag = "NO_SCAN"
        '
        'BtKeyBoard
        '
        Me.BtKeyBoard.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.BtKeyBoard.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtKeyBoard.Image = CType(resources.GetObject("BtKeyBoard.Image"), System.Drawing.Image)
        Me.BtKeyBoard.Location = New System.Drawing.Point(3, 29)
        Me.BtKeyBoard.Name = "BtKeyBoard"
        Me.BtKeyBoard.Size = New System.Drawing.Size(38, 38)
        Me.BtKeyBoard.TabIndex = 48
        Me.BtKeyBoard.Tag = "last"
        Me.BtKeyBoard.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.BtKeyBoard.UseVisualStyleBackColor = True
        '
        'BtCancell
        '
        Me.BtCancell.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.BtCancell.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.BtCancell.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtCancell.Image = CType(resources.GetObject("BtCancell.Image"), System.Drawing.Image)
        Me.BtCancell.Location = New System.Drawing.Point(85, 4)
        Me.BtCancell.Name = "BtCancell"
        Me.BtCancell.Size = New System.Drawing.Size(67, 63)
        Me.BtCancell.TabIndex = 2
        Me.BtCancell.Tag = "cancell"
        Me.BtCancell.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.BtCancell.UseVisualStyleBackColor = True
        '
        'BtOk
        '
        Me.BtOk.Enabled = False
        Me.BtOk.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.BtOk.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtOk.Image = CType(resources.GetObject("BtOk.Image"), System.Drawing.Image)
        Me.BtOk.Location = New System.Drawing.Point(158, 4)
        Me.BtOk.Name = "BtOk"
        Me.BtOk.Size = New System.Drawing.Size(67, 63)
        Me.BtOk.TabIndex = 3
        Me.BtOk.Tag = "ok"
        Me.BtOk.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.BtOk.UseVisualStyleBackColor = True
        '
        'LblName
        '
        Me.LblName.BackColor = System.Drawing.Color.Transparent
        Me.LblName.Font = New System.Drawing.Font("Verdana", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblName.Location = New System.Drawing.Point(47, 38)
        Me.LblName.Name = "LblName"
        Me.LblName.Size = New System.Drawing.Size(312, 23)
        Me.LblName.TabIndex = 34
        Me.LblName.Text = "Personalización de Mesa"
        '
        'PnlGaleria
        '
        Me.PnlGaleria.BackColor = System.Drawing.Color.FromArgb(CType(CType(174, Byte), Integer), CType(CType(186, Byte), Integer), CType(CType(186, Byte), Integer))
        Me.PnlGaleria.Controls.Add(Me.GroupBox1)
        Me.PnlGaleria.Location = New System.Drawing.Point(40, 105)
        Me.PnlGaleria.Name = "PnlGaleria"
        Me.PnlGaleria.Size = New System.Drawing.Size(559, 104)
        Me.PnlGaleria.TabIndex = 0
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.TxtName)
        Me.GroupBox1.Controls.Add(Label6)
        Me.GroupBox1.Location = New System.Drawing.Point(6, 3)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(547, 96)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        '
        'TxtName
        '
        Me.TxtName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtName.Font = New System.Drawing.Font("Verdana", 21.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtName.Location = New System.Drawing.Point(6, 38)
        Me.TxtName.MaxLength = 25
        Me.TxtName.Name = "TxtName"
        Me.TxtName.Size = New System.Drawing.Size(535, 43)
        Me.TxtName.TabIndex = 0
        Me.TxtName.Tag = "name"
        '
        'frmPaneldeVentas_Name
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), System.Drawing.Image)
        Me.ClientSize = New System.Drawing.Size(638, 250)
        Me.Controls.Add(Me.PnlGaleria)
        Me.Controls.Add(Me.LblName)
        Me.Controls.Add(Me.PnlAction_Buttons)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmPaneldeVentas_Name"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Personalización de Mesa"
        Me.PnlAction_Buttons.ResumeLayout(False)
        Me.PnlGaleria.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents PnlAction_Buttons As System.Windows.Forms.Panel
    Friend WithEvents LblName As System.Windows.Forms.Label
    Friend WithEvents PnlGaleria As System.Windows.Forms.Panel
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents TxtName As System.Windows.Forms.TextBox
    Friend WithEvents BtCancell As System.Windows.Forms.Button
    Friend WithEvents BtOk As System.Windows.Forms.Button
    Friend WithEvents BtKeyBoard As System.Windows.Forms.Button
End Class
