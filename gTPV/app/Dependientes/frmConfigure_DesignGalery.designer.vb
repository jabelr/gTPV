<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmConfigure_DesignGalery
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
        Dim Label3 As System.Windows.Forms.Label
        Dim Label1 As System.Windows.Forms.Label
        Dim Label2 As System.Windows.Forms.Label
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmConfigure_DesignGalery))
        Me.LblFh_Alta = New System.Windows.Forms.Label
        Me.LblFh_Alta_nfo = New System.Windows.Forms.Label
        Me.PnlAction_Buttons = New System.Windows.Forms.Panel
        Me.BtDell = New System.Windows.Forms.Button
        Me.BtCancell = New System.Windows.Forms.Button
        Me.BtOk = New System.Windows.Forms.Button
        Me.TxtId_Categoria = New System.Windows.Forms.TextBox
        Me.LblName = New System.Windows.Forms.Label
        Me.BtImg = New System.Windows.Forms.Button
        Me.CbImg_Cat = New System.Windows.Forms.ComboBox
        Me.TxtName = New System.Windows.Forms.TextBox
        Me.ChkNotDelete = New System.Windows.Forms.CheckBox
        Label3 = New System.Windows.Forms.Label
        Label1 = New System.Windows.Forms.Label
        Label2 = New System.Windows.Forms.Label
        Me.PnlAction_Buttons.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label3
        '
        Label3.AutoSize = True
        Label3.BackColor = System.Drawing.Color.Transparent
        Label3.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Label3.Location = New System.Drawing.Point(47, 120)
        Label3.Name = "Label3"
        Label3.Size = New System.Drawing.Size(60, 18)
        Label3.TabIndex = 38
        Label3.Text = "Nombre"
        '
        'Label1
        '
        Label1.AutoSize = True
        Label1.BackColor = System.Drawing.Color.Transparent
        Label1.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Label1.Location = New System.Drawing.Point(47, 161)
        Label1.Name = "Label1"
        Label1.Size = New System.Drawing.Size(69, 18)
        Label1.TabIndex = 40
        Label1.Text = "Categoría"
        '
        'Label2
        '
        Label2.AutoSize = True
        Label2.BackColor = System.Drawing.Color.Transparent
        Label2.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Label2.Location = New System.Drawing.Point(48, 199)
        Label2.Name = "Label2"
        Label2.Size = New System.Drawing.Size(59, 18)
        Label2.TabIndex = 41
        Label2.Text = "Imagen"
        '
        'LblFh_Alta
        '
        Me.LblFh_Alta.BackColor = System.Drawing.Color.Transparent
        Me.LblFh_Alta.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblFh_Alta.Location = New System.Drawing.Point(139, 405)
        Me.LblFh_Alta.Name = "LblFh_Alta"
        Me.LblFh_Alta.Size = New System.Drawing.Size(179, 13)
        Me.LblFh_Alta.TabIndex = 6
        Me.LblFh_Alta.Tag = "fh_alta"
        Me.LblFh_Alta.Text = "00/00/0000"
        '
        'LblFh_Alta_nfo
        '
        Me.LblFh_Alta_nfo.AutoSize = True
        Me.LblFh_Alta_nfo.BackColor = System.Drawing.Color.Transparent
        Me.LblFh_Alta_nfo.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblFh_Alta_nfo.Location = New System.Drawing.Point(47, 405)
        Me.LblFh_Alta_nfo.Name = "LblFh_Alta_nfo"
        Me.LblFh_Alta_nfo.Size = New System.Drawing.Size(88, 13)
        Me.LblFh_Alta_nfo.TabIndex = 5
        Me.LblFh_Alta_nfo.Text = "Fecha de alta:"
        '
        'PnlAction_Buttons
        '
        Me.PnlAction_Buttons.BackColor = System.Drawing.Color.Transparent
        Me.PnlAction_Buttons.Controls.Add(Me.BtDell)
        Me.PnlAction_Buttons.Controls.Add(Me.BtCancell)
        Me.PnlAction_Buttons.Controls.Add(Me.BtOk)
        Me.PnlAction_Buttons.Location = New System.Drawing.Point(357, 35)
        Me.PnlAction_Buttons.Name = "PnlAction_Buttons"
        Me.PnlAction_Buttons.Size = New System.Drawing.Size(238, 70)
        Me.PnlAction_Buttons.TabIndex = 3
        Me.PnlAction_Buttons.Tag = "NO_SCAN"
        '
        'BtDell
        '
        Me.BtDell.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.BtDell.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtDell.Image = CType(resources.GetObject("BtDell.Image"), System.Drawing.Image)
        Me.BtDell.Location = New System.Drawing.Point(3, 3)
        Me.BtDell.Name = "BtDell"
        Me.BtDell.Size = New System.Drawing.Size(67, 63)
        Me.BtDell.TabIndex = 2
        Me.BtDell.Tag = "cancell"
        Me.BtDell.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.BtDell.UseVisualStyleBackColor = True
        '
        'BtCancell
        '
        Me.BtCancell.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.BtCancell.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.BtCancell.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtCancell.Image = CType(resources.GetObject("BtCancell.Image"), System.Drawing.Image)
        Me.BtCancell.Location = New System.Drawing.Point(94, 3)
        Me.BtCancell.Name = "BtCancell"
        Me.BtCancell.Size = New System.Drawing.Size(67, 63)
        Me.BtCancell.TabIndex = 0
        Me.BtCancell.Tag = "cancell"
        Me.BtCancell.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.BtCancell.UseVisualStyleBackColor = True
        '
        'BtOk
        '
        Me.BtOk.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.BtOk.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtOk.Image = CType(resources.GetObject("BtOk.Image"), System.Drawing.Image)
        Me.BtOk.Location = New System.Drawing.Point(167, 3)
        Me.BtOk.Name = "BtOk"
        Me.BtOk.Size = New System.Drawing.Size(67, 63)
        Me.BtOk.TabIndex = 1
        Me.BtOk.Tag = "ok"
        Me.BtOk.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.BtOk.UseVisualStyleBackColor = True
        '
        'TxtId_Categoria
        '
        Me.TxtId_Categoria.Font = New System.Drawing.Font("Tahoma", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtId_Categoria.Location = New System.Drawing.Point(443, 385)
        Me.TxtId_Categoria.MaxLength = 25
        Me.TxtId_Categoria.Name = "TxtId_Categoria"
        Me.TxtId_Categoria.Size = New System.Drawing.Size(152, 33)
        Me.TxtId_Categoria.TabIndex = 33
        Me.TxtId_Categoria.Tag = "id_categoria"
        Me.TxtId_Categoria.Text = "id_categoria"
        Me.TxtId_Categoria.Visible = False
        '
        'LblName
        '
        Me.LblName.BackColor = System.Drawing.Color.Transparent
        Me.LblName.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblName.Location = New System.Drawing.Point(47, 38)
        Me.LblName.Name = "LblName"
        Me.LblName.Size = New System.Drawing.Size(291, 23)
        Me.LblName.TabIndex = 34
        Me.LblName.Text = "Images del Diseño del Local"
        '
        'BtImg
        '
        Me.BtImg.Location = New System.Drawing.Point(175, 195)
        Me.BtImg.Margin = New System.Windows.Forms.Padding(0)
        Me.BtImg.Name = "BtImg"
        Me.BtImg.Size = New System.Drawing.Size(112, 109)
        Me.BtImg.TabIndex = 2
        Me.BtImg.Tag = "img"
        Me.BtImg.Text = "Click para seleccionar"
        Me.BtImg.UseVisualStyleBackColor = True
        '
        'CbImg_Cat
        '
        Me.CbImg_Cat.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CbImg_Cat.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CbImg_Cat.FormattingEnabled = True
        Me.CbImg_Cat.Location = New System.Drawing.Point(175, 150)
        Me.CbImg_Cat.Name = "CbImg_Cat"
        Me.CbImg_Cat.Size = New System.Drawing.Size(374, 37)
        Me.CbImg_Cat.TabIndex = 1
        '
        'TxtName
        '
        Me.TxtName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtName.Font = New System.Drawing.Font("Tahoma", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtName.Location = New System.Drawing.Point(175, 111)
        Me.TxtName.MaxLength = 35
        Me.TxtName.Name = "TxtName"
        Me.TxtName.Size = New System.Drawing.Size(416, 33)
        Me.TxtName.TabIndex = 0
        Me.TxtName.Tag = "name"
        '
        'ChkNotDelete
        '
        Me.ChkNotDelete.AutoSize = True
        Me.ChkNotDelete.Location = New System.Drawing.Point(175, 325)
        Me.ChkNotDelete.Name = "ChkNotDelete"
        Me.ChkNotDelete.Size = New System.Drawing.Size(70, 17)
        Me.ChkNotDelete.TabIndex = 3
        Me.ChkNotDelete.Tag = "notdelete"
        Me.ChkNotDelete.Text = "notdelete"
        Me.ChkNotDelete.UseVisualStyleBackColor = True
        Me.ChkNotDelete.Visible = False
        '
        'frmConfigure_DesignGalery
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), System.Drawing.Image)
        Me.CancelButton = Me.BtCancell
        Me.ClientSize = New System.Drawing.Size(639, 451)
        Me.Controls.Add(Me.ChkNotDelete)
        Me.Controls.Add(Label2)
        Me.Controls.Add(Label1)
        Me.Controls.Add(Me.TxtName)
        Me.Controls.Add(Label3)
        Me.Controls.Add(Me.CbImg_Cat)
        Me.Controls.Add(Me.BtImg)
        Me.Controls.Add(Me.LblName)
        Me.Controls.Add(Me.TxtId_Categoria)
        Me.Controls.Add(Me.PnlAction_Buttons)
        Me.Controls.Add(Me.LblFh_Alta)
        Me.Controls.Add(Me.LblFh_Alta_nfo)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmConfigure_DesignGalery"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Galeria de Imagenes para el Diseño del Local"
        Me.PnlAction_Buttons.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents LblFh_Alta As System.Windows.Forms.Label
    Friend WithEvents LblFh_Alta_nfo As System.Windows.Forms.Label
    Friend WithEvents PnlAction_Buttons As System.Windows.Forms.Panel
    Friend WithEvents BtCancell As System.Windows.Forms.Button
    Friend WithEvents BtOk As System.Windows.Forms.Button
    Friend WithEvents TxtId_Categoria As System.Windows.Forms.TextBox
    Friend WithEvents BtDell As System.Windows.Forms.Button
    Friend WithEvents LblName As System.Windows.Forms.Label
    Friend WithEvents BtImg As System.Windows.Forms.Button
    Friend WithEvents CbImg_Cat As System.Windows.Forms.ComboBox
    Friend WithEvents TxtName As System.Windows.Forms.TextBox
    Friend WithEvents ChkNotDelete As System.Windows.Forms.CheckBox
End Class
