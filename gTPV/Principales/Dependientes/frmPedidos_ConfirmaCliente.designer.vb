<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmPedidos_ConfirmaCliente
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
        Dim Label1 As System.Windows.Forms.Label
        Dim Label2 As System.Windows.Forms.Label
        Dim Label3 As System.Windows.Forms.Label
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmPedidos_ConfirmaCliente))
        Me.BtCancell = New System.Windows.Forms.Button
        Me.BtOk = New System.Windows.Forms.Button
        Me.LblName = New System.Windows.Forms.Label
        Me.PnlGaleria = New System.Windows.Forms.Panel
        Me.Tab = New System.Windows.Forms.TabControl
        Me.TabPage_last = New System.Windows.Forms.TabPage
        Me.TabPage_Location = New System.Windows.Forms.TabPage
        Me.txtLoc = New System.Windows.Forms.TextBox
        Me.WebBrowser = New System.Windows.Forms.WebBrowser
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.txtDirBloque = New System.Windows.Forms.TextBox
        Me.txtDirN = New System.Windows.Forms.TextBox
        Me.txtTlf = New System.Windows.Forms.TextBox
        Me.TxtDir = New System.Windows.Forms.TextBox
        Label6 = New System.Windows.Forms.Label
        Label1 = New System.Windows.Forms.Label
        Label2 = New System.Windows.Forms.Label
        Label3 = New System.Windows.Forms.Label
        Me.PnlGaleria.SuspendLayout()
        Me.Tab.SuspendLayout()
        Me.TabPage_Location.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label6
        '
        Label6.AutoSize = True
        Label6.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Label6.Location = New System.Drawing.Point(18, 13)
        Label6.Name = "Label6"
        Label6.Size = New System.Drawing.Size(141, 18)
        Label6.TabIndex = 7
        Label6.Text = "Dirección de Entrega"
        '
        'Label1
        '
        Label1.AutoSize = True
        Label1.Font = New System.Drawing.Font("Tahoma", 5.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Label1.Location = New System.Drawing.Point(426, 16)
        Label1.Name = "Label1"
        Label1.Size = New System.Drawing.Size(82, 8)
        Label1.TabIndex = 9
        Label1.Text = "TELÉFONO DE ENTREGA"
        '
        'Label2
        '
        Label2.AutoSize = True
        Label2.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Label2.Location = New System.Drawing.Point(18, 70)
        Label2.Name = "Label2"
        Label2.Size = New System.Drawing.Size(60, 18)
        Label2.TabIndex = 11
        Label2.Text = "Número"
        '
        'Label3
        '
        Label3.AutoSize = True
        Label3.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Label3.Location = New System.Drawing.Point(130, 70)
        Label3.Name = "Label3"
        Label3.Size = New System.Drawing.Size(51, 18)
        Label3.TabIndex = 13
        Label3.Text = "Bloque"
        '
        'BtCancell
        '
        Me.BtCancell.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.BtCancell.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.BtCancell.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtCancell.Image = CType(resources.GetObject("BtCancell.Image"), System.Drawing.Image)
        Me.BtCancell.Location = New System.Drawing.Point(532, 22)
        Me.BtCancell.Name = "BtCancell"
        Me.BtCancell.Size = New System.Drawing.Size(67, 53)
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
        Me.BtOk.Location = New System.Drawing.Point(605, 22)
        Me.BtOk.Name = "BtOk"
        Me.BtOk.Size = New System.Drawing.Size(82, 53)
        Me.BtOk.TabIndex = 3
        Me.BtOk.Tag = "ok"
        Me.BtOk.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.BtOk.UseVisualStyleBackColor = True
        '
        'LblName
        '
        Me.LblName.BackColor = System.Drawing.Color.Transparent
        Me.LblName.Font = New System.Drawing.Font("Verdana", 21.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblName.Location = New System.Drawing.Point(47, 36)
        Me.LblName.Name = "LblName"
        Me.LblName.Size = New System.Drawing.Size(479, 41)
        Me.LblName.TabIndex = 34
        Me.LblName.Text = "Fuckencio Martinez"
        '
        'PnlGaleria
        '
        Me.PnlGaleria.BackColor = System.Drawing.Color.FromArgb(CType(CType(152, Byte), Integer), CType(CType(161, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.PnlGaleria.Controls.Add(Me.Tab)
        Me.PnlGaleria.Controls.Add(Me.GroupBox1)
        Me.PnlGaleria.Location = New System.Drawing.Point(48, 69)
        Me.PnlGaleria.Name = "PnlGaleria"
        Me.PnlGaleria.Size = New System.Drawing.Size(640, 475)
        Me.PnlGaleria.TabIndex = 0
        '
        'Tab
        '
        Me.Tab.Controls.Add(Me.TabPage_last)
        Me.Tab.Controls.Add(Me.TabPage_Location)
        Me.Tab.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Tab.Location = New System.Drawing.Point(0, 143)
        Me.Tab.Name = "Tab"
        Me.Tab.SelectedIndex = 0
        Me.Tab.Size = New System.Drawing.Size(640, 332)
        Me.Tab.TabIndex = 1
        '
        'TabPage_last
        '
        Me.TabPage_last.Location = New System.Drawing.Point(4, 22)
        Me.TabPage_last.Name = "TabPage_last"
        Me.TabPage_last.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage_last.Size = New System.Drawing.Size(632, 306)
        Me.TabPage_last.TabIndex = 0
        Me.TabPage_last.Text = "Últimos Pedidos"
        Me.TabPage_last.UseVisualStyleBackColor = True
        '
        'TabPage_Location
        '
        Me.TabPage_Location.Controls.Add(Me.txtLoc)
        Me.TabPage_Location.Controls.Add(Me.WebBrowser)
        Me.TabPage_Location.Location = New System.Drawing.Point(4, 22)
        Me.TabPage_Location.Name = "TabPage_Location"
        Me.TabPage_Location.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage_Location.Size = New System.Drawing.Size(632, 306)
        Me.TabPage_Location.TabIndex = 1
        Me.TabPage_Location.Text = "Localización"
        Me.TabPage_Location.UseVisualStyleBackColor = True
        '
        'txtLoc
        '
        Me.txtLoc.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtLoc.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtLoc.Location = New System.Drawing.Point(18, 322)
        Me.txtLoc.MaxLength = 150
        Me.txtLoc.Name = "txtLoc"
        Me.txtLoc.Size = New System.Drawing.Size(570, 23)
        Me.txtLoc.TabIndex = 2
        Me.txtLoc.Tag = ""
        '
        'WebBrowser
        '
        Me.WebBrowser.Dock = System.Windows.Forms.DockStyle.Fill
        Me.WebBrowser.Location = New System.Drawing.Point(3, 3)
        Me.WebBrowser.MinimumSize = New System.Drawing.Size(20, 20)
        Me.WebBrowser.Name = "WebBrowser"
        Me.WebBrowser.Size = New System.Drawing.Size(626, 300)
        Me.WebBrowser.TabIndex = 1
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.txtDirBloque)
        Me.GroupBox1.Controls.Add(Label3)
        Me.GroupBox1.Controls.Add(Me.txtDirN)
        Me.GroupBox1.Controls.Add(Label2)
        Me.GroupBox1.Controls.Add(Me.txtTlf)
        Me.GroupBox1.Controls.Add(Label1)
        Me.GroupBox1.Controls.Add(Me.TxtDir)
        Me.GroupBox1.Controls.Add(Label6)
        Me.GroupBox1.Location = New System.Drawing.Point(4, 6)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(629, 131)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        '
        'txtDirBloque
        '
        Me.txtDirBloque.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtDirBloque.Font = New System.Drawing.Font("Tahoma", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDirBloque.Location = New System.Drawing.Point(122, 92)
        Me.txtDirBloque.MaxLength = 150
        Me.txtDirBloque.Name = "txtDirBloque"
        Me.txtDirBloque.Size = New System.Drawing.Size(106, 30)
        Me.txtDirBloque.TabIndex = 2
        Me.txtDirBloque.Tag = ""
        '
        'txtDirN
        '
        Me.txtDirN.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtDirN.Font = New System.Drawing.Font("Tahoma", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDirN.Location = New System.Drawing.Point(10, 92)
        Me.txtDirN.MaxLength = 150
        Me.txtDirN.Name = "txtDirN"
        Me.txtDirN.Size = New System.Drawing.Size(106, 30)
        Me.txtDirN.TabIndex = 1
        Me.txtDirN.Tag = ""
        '
        'txtTlf
        '
        Me.txtTlf.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtTlf.Font = New System.Drawing.Font("Tahoma", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTlf.Location = New System.Drawing.Point(428, 28)
        Me.txtTlf.MaxLength = 20
        Me.txtTlf.Name = "txtTlf"
        Me.txtTlf.Size = New System.Drawing.Size(193, 40)
        Me.txtTlf.TabIndex = 3
        Me.txtTlf.Tag = ""
        Me.txtTlf.Text = "000 000 000"
        '
        'TxtDir
        '
        Me.TxtDir.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtDir.Font = New System.Drawing.Font("Tahoma", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtDir.Location = New System.Drawing.Point(10, 35)
        Me.TxtDir.MaxLength = 150
        Me.TxtDir.Name = "TxtDir"
        Me.TxtDir.Size = New System.Drawing.Size(412, 30)
        Me.TxtDir.TabIndex = 0
        Me.TxtDir.Tag = ""
        '
        'frmPedidos_ConfirmaCliente
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), System.Drawing.Image)
        Me.ClientSize = New System.Drawing.Size(740, 544)
        Me.Controls.Add(Me.LblName)
        Me.Controls.Add(Me.BtCancell)
        Me.Controls.Add(Me.BtOk)
        Me.Controls.Add(Me.PnlGaleria)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmPedidos_ConfirmaCliente"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Verificación de Entrega al cliente"
        Me.PnlGaleria.ResumeLayout(False)
        Me.Tab.ResumeLayout(False)
        Me.TabPage_Location.ResumeLayout(False)
        Me.TabPage_Location.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents LblName As System.Windows.Forms.Label
    Friend WithEvents PnlGaleria As System.Windows.Forms.Panel
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents TxtDir As System.Windows.Forms.TextBox
    Friend WithEvents BtCancell As System.Windows.Forms.Button
    Friend WithEvents BtOk As System.Windows.Forms.Button
    Friend WithEvents txtTlf As System.Windows.Forms.TextBox
    Friend WithEvents Tab As System.Windows.Forms.TabControl
    Friend WithEvents TabPage_last As System.Windows.Forms.TabPage
    Friend WithEvents TabPage_Location As System.Windows.Forms.TabPage
    Friend WithEvents WebBrowser As System.Windows.Forms.WebBrowser
    Friend WithEvents txtLoc As System.Windows.Forms.TextBox
    Friend WithEvents txtDirBloque As System.Windows.Forms.TextBox
    Friend WithEvents txtDirN As System.Windows.Forms.TextBox
End Class
