<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmPaneldeVentas_Dto
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmPaneldeVentas_Dto))
        Me.BtCancell = New System.Windows.Forms.Button()
        Me.PnlGaleria = New System.Windows.Forms.Panel()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.BtClear = New System.Windows.Forms.Button()
        Me.BtOK = New System.Windows.Forms.Button()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.BtUndo = New System.Windows.Forms.Button()
        Me.TxtPVP = New System.Windows.Forms.TextBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.btMasMenos = New System.Windows.Forms.Button()
        Me.BtDecimal = New System.Windows.Forms.Button()
        Me.Bt_7 = New System.Windows.Forms.Button()
        Me.Bt_8 = New System.Windows.Forms.Button()
        Me.Bt_9 = New System.Windows.Forms.Button()
        Me.Bt_0 = New System.Windows.Forms.Button()
        Me.Bt_4 = New System.Windows.Forms.Button()
        Me.Bt_3 = New System.Windows.Forms.Button()
        Me.Bt_5 = New System.Windows.Forms.Button()
        Me.Bt_2 = New System.Windows.Forms.Button()
        Me.Bt_6 = New System.Windows.Forms.Button()
        Me.Bt_1 = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.PnlGaleria.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'BtCancell
        '
        Me.BtCancell.BackColor = System.Drawing.SystemColors.Control
        Me.BtCancell.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.BtCancell.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtCancell.Image = CType(resources.GetObject("BtCancell.Image"), System.Drawing.Image)
        Me.BtCancell.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.BtCancell.Location = New System.Drawing.Point(6, 139)
        Me.BtCancell.Name = "BtCancell"
        Me.BtCancell.Size = New System.Drawing.Size(94, 58)
        Me.BtCancell.TabIndex = 0
        Me.BtCancell.Tag = "cancell"
        Me.BtCancell.Text = "Salir"
        Me.BtCancell.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.BtCancell.UseVisualStyleBackColor = False
        '
        'PnlGaleria
        '
        Me.PnlGaleria.BackColor = System.Drawing.Color.FromArgb(CType(CType(174, Byte), Integer), CType(CType(186, Byte), Integer), CType(CType(186, Byte), Integer))
        Me.PnlGaleria.Controls.Add(Me.GroupBox3)
        Me.PnlGaleria.Controls.Add(Me.GroupBox2)
        Me.PnlGaleria.Controls.Add(Me.GroupBox1)
        Me.PnlGaleria.Location = New System.Drawing.Point(41, 71)
        Me.PnlGaleria.Name = "PnlGaleria"
        Me.PnlGaleria.Size = New System.Drawing.Size(318, 352)
        Me.PnlGaleria.TabIndex = 42
        Me.PnlGaleria.Visible = False
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.BtClear)
        Me.GroupBox3.Controls.Add(Me.BtCancell)
        Me.GroupBox3.Controls.Add(Me.BtOK)
        Me.GroupBox3.Location = New System.Drawing.Point(209, 78)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(106, 269)
        Me.GroupBox3.TabIndex = 57
        Me.GroupBox3.TabStop = False
        '
        'BtClear
        '
        Me.BtClear.BackColor = System.Drawing.SystemColors.Control
        Me.BtClear.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtClear.Image = CType(resources.GetObject("BtClear.Image"), System.Drawing.Image)
        Me.BtClear.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.BtClear.Location = New System.Drawing.Point(6, 78)
        Me.BtClear.Name = "BtClear"
        Me.BtClear.Size = New System.Drawing.Size(94, 55)
        Me.BtClear.TabIndex = 54
        Me.BtClear.Tag = "clear"
        Me.BtClear.Text = "Limpia"
        Me.BtClear.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.BtClear.UseVisualStyleBackColor = False
        '
        'BtOK
        '
        Me.BtOK.Enabled = False
        Me.BtOK.Font = New System.Drawing.Font("Tahoma", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtOK.Image = CType(resources.GetObject("BtOK.Image"), System.Drawing.Image)
        Me.BtOK.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.BtOK.Location = New System.Drawing.Point(6, 203)
        Me.BtOK.Name = "BtOK"
        Me.BtOK.Size = New System.Drawing.Size(94, 58)
        Me.BtOK.TabIndex = 53
        Me.BtOK.Text = "Ok!!"
        Me.BtOK.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.BtOK.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.BtUndo)
        Me.GroupBox2.Controls.Add(Me.TxtPVP)
        Me.GroupBox2.Location = New System.Drawing.Point(3, 1)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(312, 71)
        Me.GroupBox2.TabIndex = 56
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Descuento"
        '
        'BtUndo
        '
        Me.BtUndo.BackColor = System.Drawing.SystemColors.Control
        Me.BtUndo.Enabled = False
        Me.BtUndo.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtUndo.Image = CType(resources.GetObject("BtUndo.Image"), System.Drawing.Image)
        Me.BtUndo.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.BtUndo.Location = New System.Drawing.Point(239, 16)
        Me.BtUndo.Name = "BtUndo"
        Me.BtUndo.Size = New System.Drawing.Size(67, 50)
        Me.BtUndo.TabIndex = 55
        Me.BtUndo.Tag = "undo"
        Me.BtUndo.Text = "Deshacer"
        Me.BtUndo.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.BtUndo.UseVisualStyleBackColor = False
        '
        'TxtPVP
        '
        Me.TxtPVP.Font = New System.Drawing.Font("Tahoma", 26.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtPVP.Location = New System.Drawing.Point(6, 16)
        Me.TxtPVP.MaxLength = 10
        Me.TxtPVP.Name = "TxtPVP"
        Me.TxtPVP.Size = New System.Drawing.Size(227, 50)
        Me.TxtPVP.TabIndex = 54
        Me.TxtPVP.Tag = ""
        Me.TxtPVP.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.btMasMenos)
        Me.GroupBox1.Controls.Add(Me.BtDecimal)
        Me.GroupBox1.Controls.Add(Me.Bt_7)
        Me.GroupBox1.Controls.Add(Me.Bt_8)
        Me.GroupBox1.Controls.Add(Me.Bt_9)
        Me.GroupBox1.Controls.Add(Me.Bt_0)
        Me.GroupBox1.Controls.Add(Me.Bt_4)
        Me.GroupBox1.Controls.Add(Me.Bt_3)
        Me.GroupBox1.Controls.Add(Me.Bt_5)
        Me.GroupBox1.Controls.Add(Me.Bt_2)
        Me.GroupBox1.Controls.Add(Me.Bt_6)
        Me.GroupBox1.Controls.Add(Me.Bt_1)
        Me.GroupBox1.Location = New System.Drawing.Point(3, 78)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(200, 269)
        Me.GroupBox1.TabIndex = 55
        Me.GroupBox1.TabStop = False
        '
        'btMasMenos
        '
        Me.btMasMenos.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btMasMenos.Location = New System.Drawing.Point(6, 203)
        Me.btMasMenos.Name = "btMasMenos"
        Me.btMasMenos.Size = New System.Drawing.Size(58, 58)
        Me.btMasMenos.TabIndex = 53
        Me.btMasMenos.Text = "+/-"
        Me.btMasMenos.UseVisualStyleBackColor = True
        '
        'BtDecimal
        '
        Me.BtDecimal.Font = New System.Drawing.Font("Tahoma", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtDecimal.Location = New System.Drawing.Point(134, 203)
        Me.BtDecimal.Name = "BtDecimal"
        Me.BtDecimal.Size = New System.Drawing.Size(58, 58)
        Me.BtDecimal.TabIndex = 52
        Me.BtDecimal.Text = ","
        Me.BtDecimal.UseVisualStyleBackColor = True
        '
        'Bt_7
        '
        Me.Bt_7.Font = New System.Drawing.Font("Tahoma", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Bt_7.Location = New System.Drawing.Point(6, 11)
        Me.Bt_7.Name = "Bt_7"
        Me.Bt_7.Size = New System.Drawing.Size(58, 58)
        Me.Bt_7.TabIndex = 42
        Me.Bt_7.Text = "7"
        Me.Bt_7.UseVisualStyleBackColor = True
        '
        'Bt_8
        '
        Me.Bt_8.Font = New System.Drawing.Font("Tahoma", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Bt_8.Location = New System.Drawing.Point(70, 11)
        Me.Bt_8.Name = "Bt_8"
        Me.Bt_8.Size = New System.Drawing.Size(58, 58)
        Me.Bt_8.TabIndex = 43
        Me.Bt_8.Text = "8"
        Me.Bt_8.UseVisualStyleBackColor = True
        '
        'Bt_9
        '
        Me.Bt_9.Font = New System.Drawing.Font("Tahoma", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Bt_9.Location = New System.Drawing.Point(134, 11)
        Me.Bt_9.Name = "Bt_9"
        Me.Bt_9.Size = New System.Drawing.Size(58, 58)
        Me.Bt_9.TabIndex = 44
        Me.Bt_9.Text = "9"
        Me.Bt_9.UseVisualStyleBackColor = True
        '
        'Bt_0
        '
        Me.Bt_0.Font = New System.Drawing.Font("Tahoma", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Bt_0.Location = New System.Drawing.Point(70, 203)
        Me.Bt_0.Name = "Bt_0"
        Me.Bt_0.Size = New System.Drawing.Size(58, 58)
        Me.Bt_0.TabIndex = 51
        Me.Bt_0.Text = "0"
        Me.Bt_0.UseVisualStyleBackColor = True
        '
        'Bt_4
        '
        Me.Bt_4.Font = New System.Drawing.Font("Tahoma", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Bt_4.Location = New System.Drawing.Point(6, 75)
        Me.Bt_4.Name = "Bt_4"
        Me.Bt_4.Size = New System.Drawing.Size(58, 58)
        Me.Bt_4.TabIndex = 45
        Me.Bt_4.Text = "4"
        Me.Bt_4.UseVisualStyleBackColor = True
        '
        'Bt_3
        '
        Me.Bt_3.Font = New System.Drawing.Font("Tahoma", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Bt_3.Location = New System.Drawing.Point(134, 139)
        Me.Bt_3.Name = "Bt_3"
        Me.Bt_3.Size = New System.Drawing.Size(58, 58)
        Me.Bt_3.TabIndex = 50
        Me.Bt_3.Text = "3"
        Me.Bt_3.UseVisualStyleBackColor = True
        '
        'Bt_5
        '
        Me.Bt_5.Font = New System.Drawing.Font("Tahoma", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Bt_5.Location = New System.Drawing.Point(70, 75)
        Me.Bt_5.Name = "Bt_5"
        Me.Bt_5.Size = New System.Drawing.Size(58, 58)
        Me.Bt_5.TabIndex = 46
        Me.Bt_5.Text = "5"
        Me.Bt_5.UseVisualStyleBackColor = True
        '
        'Bt_2
        '
        Me.Bt_2.Font = New System.Drawing.Font("Tahoma", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Bt_2.Location = New System.Drawing.Point(70, 139)
        Me.Bt_2.Name = "Bt_2"
        Me.Bt_2.Size = New System.Drawing.Size(58, 58)
        Me.Bt_2.TabIndex = 49
        Me.Bt_2.Text = "2"
        Me.Bt_2.UseVisualStyleBackColor = True
        '
        'Bt_6
        '
        Me.Bt_6.Font = New System.Drawing.Font("Tahoma", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Bt_6.Location = New System.Drawing.Point(134, 75)
        Me.Bt_6.Name = "Bt_6"
        Me.Bt_6.Size = New System.Drawing.Size(58, 58)
        Me.Bt_6.TabIndex = 47
        Me.Bt_6.Text = "6"
        Me.Bt_6.UseVisualStyleBackColor = True
        '
        'Bt_1
        '
        Me.Bt_1.Font = New System.Drawing.Font("Tahoma", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Bt_1.Location = New System.Drawing.Point(6, 139)
        Me.Bt_1.Name = "Bt_1"
        Me.Bt_1.Size = New System.Drawing.Size(58, 58)
        Me.Bt_1.TabIndex = 48
        Me.Bt_1.Text = "1"
        Me.Bt_1.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Tahoma", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(84, 36)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(249, 23)
        Me.Label1.TabIndex = 43
        Me.Label1.Text = "APLICAR % DESCUENTO"
        '
        'frmPaneldeVentas_Dto
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), System.Drawing.Image)
        Me.ClientSize = New System.Drawing.Size(399, 458)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.PnlGaleria)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmPaneldeVentas_Dto"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Agregar Artículo Libre"
        Me.PnlGaleria.ResumeLayout(False)
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents BtCancell As System.Windows.Forms.Button
    Friend WithEvents PnlGaleria As System.Windows.Forms.Panel
    Friend WithEvents BtOK As System.Windows.Forms.Button
    Friend WithEvents Bt_0 As System.Windows.Forms.Button
    Friend WithEvents Bt_3 As System.Windows.Forms.Button
    Friend WithEvents Bt_2 As System.Windows.Forms.Button
    Friend WithEvents Bt_1 As System.Windows.Forms.Button
    Friend WithEvents Bt_6 As System.Windows.Forms.Button
    Friend WithEvents Bt_5 As System.Windows.Forms.Button
    Friend WithEvents Bt_4 As System.Windows.Forms.Button
    Friend WithEvents Bt_9 As System.Windows.Forms.Button
    Friend WithEvents Bt_8 As System.Windows.Forms.Button
    Friend WithEvents Bt_7 As System.Windows.Forms.Button
    Friend WithEvents TxtPVP As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents BtClear As System.Windows.Forms.Button
    Friend WithEvents BtDecimal As System.Windows.Forms.Button
    Friend WithEvents BtUndo As System.Windows.Forms.Button
    Friend WithEvents btMasMenos As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
End Class
