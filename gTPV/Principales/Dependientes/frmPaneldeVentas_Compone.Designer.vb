<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmPaneldeVentas_Compone
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmPaneldeVentas_Compone))
        Me.PnlAction_Buttons = New System.Windows.Forms.Panel()
        Me.BtOK = New System.Windows.Forms.Button()
        Me.BtImg_Next = New System.Windows.Forms.Button()
        Me.BtCancell = New System.Windows.Forms.Button()
        Me.BtImg_Previous = New System.Windows.Forms.Button()
        Me.LblName = New System.Windows.Forms.Label()
        Me.CbCategorias = New System.Windows.Forms.ComboBox()
        Me.PnlGaleria = New System.Windows.Forms.Panel()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.lst = New System.Windows.Forms.ListBox()
        Me.pnlName = New System.Windows.Forms.Panel()
        Me.lblPrecio = New System.Windows.Forms.Label()
        Me.lblArticulo = New System.Windows.Forms.Label()
        Me.PnlAction_Buttons.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.pnlName.SuspendLayout()
        Me.SuspendLayout()
        '
        'PnlAction_Buttons
        '
        Me.PnlAction_Buttons.BackColor = System.Drawing.Color.FromArgb(CType(CType(174, Byte), Integer), CType(CType(186, Byte), Integer), CType(CType(186, Byte), Integer))
        Me.PnlAction_Buttons.Controls.Add(Me.BtOK)
        Me.PnlAction_Buttons.Controls.Add(Me.BtImg_Next)
        Me.PnlAction_Buttons.Controls.Add(Me.BtCancell)
        Me.PnlAction_Buttons.Controls.Add(Me.BtImg_Previous)
        Me.PnlAction_Buttons.Location = New System.Drawing.Point(405, 36)
        Me.PnlAction_Buttons.Name = "PnlAction_Buttons"
        Me.PnlAction_Buttons.Size = New System.Drawing.Size(314, 56)
        Me.PnlAction_Buttons.TabIndex = 2
        Me.PnlAction_Buttons.Tag = "NO_SCAN"
        '
        'BtOK
        '
        Me.BtOK.Font = New System.Drawing.Font("Tahoma", 26.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtOK.Image = CType(resources.GetObject("BtOK.Image"), System.Drawing.Image)
        Me.BtOK.Location = New System.Drawing.Point(208, 0)
        Me.BtOK.Name = "BtOK"
        Me.BtOK.Size = New System.Drawing.Size(103, 56)
        Me.BtOK.TabIndex = 4
        Me.BtOK.UseVisualStyleBackColor = True
        '
        'BtImg_Next
        '
        Me.BtImg_Next.BackColor = System.Drawing.SystemColors.Control
        Me.BtImg_Next.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtImg_Next.Image = CType(resources.GetObject("BtImg_Next.Image"), System.Drawing.Image)
        Me.BtImg_Next.Location = New System.Drawing.Point(69, 0)
        Me.BtImg_Next.Name = "BtImg_Next"
        Me.BtImg_Next.Size = New System.Drawing.Size(60, 54)
        Me.BtImg_Next.TabIndex = 1
        Me.BtImg_Next.Tag = ""
        Me.BtImg_Next.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtImg_Next.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage
        Me.BtImg_Next.UseVisualStyleBackColor = False
        '
        'BtCancell
        '
        Me.BtCancell.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.BtCancell.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.BtCancell.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtCancell.Image = CType(resources.GetObject("BtCancell.Image"), System.Drawing.Image)
        Me.BtCancell.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.BtCancell.Location = New System.Drawing.Point(135, 0)
        Me.BtCancell.Name = "BtCancell"
        Me.BtCancell.Size = New System.Drawing.Size(67, 54)
        Me.BtCancell.TabIndex = 3
        Me.BtCancell.Tag = "cancell"
        Me.BtCancell.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.BtCancell.UseVisualStyleBackColor = True
        '
        'BtImg_Previous
        '
        Me.BtImg_Previous.BackColor = System.Drawing.SystemColors.Control
        Me.BtImg_Previous.Enabled = False
        Me.BtImg_Previous.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtImg_Previous.Image = CType(resources.GetObject("BtImg_Previous.Image"), System.Drawing.Image)
        Me.BtImg_Previous.Location = New System.Drawing.Point(3, 0)
        Me.BtImg_Previous.Name = "BtImg_Previous"
        Me.BtImg_Previous.Size = New System.Drawing.Size(60, 54)
        Me.BtImg_Previous.TabIndex = 0
        Me.BtImg_Previous.Tag = ""
        Me.BtImg_Previous.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BtImg_Previous.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.BtImg_Previous.UseVisualStyleBackColor = False
        '
        'LblName
        '
        Me.LblName.BackColor = System.Drawing.Color.Transparent
        Me.LblName.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblName.Location = New System.Drawing.Point(47, 46)
        Me.LblName.Name = "LblName"
        Me.LblName.Size = New System.Drawing.Size(90, 23)
        Me.LblName.TabIndex = 35
        Me.LblName.Text = "Familia"
        '
        'CbCategorias
        '
        Me.CbCategorias.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CbCategorias.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CbCategorias.FormattingEnabled = True
        Me.CbCategorias.Location = New System.Drawing.Point(129, 39)
        Me.CbCategorias.Name = "CbCategorias"
        Me.CbCategorias.Size = New System.Drawing.Size(252, 37)
        Me.CbCategorias.TabIndex = 0
        '
        'PnlGaleria
        '
        Me.PnlGaleria.BackColor = System.Drawing.Color.FromArgb(CType(CType(174, Byte), Integer), CType(CType(186, Byte), Integer), CType(CType(186, Byte), Integer))
        Me.PnlGaleria.Location = New System.Drawing.Point(43, 93)
        Me.PnlGaleria.Name = "PnlGaleria"
        Me.PnlGaleria.Size = New System.Drawing.Size(676, 438)
        Me.PnlGaleria.TabIndex = 1
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.lst)
        Me.Panel1.Controls.Add(Me.pnlName)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Right
        Me.Panel1.Location = New System.Drawing.Point(757, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(338, 568)
        Me.Panel1.TabIndex = 36
        '
        'lst
        '
        Me.lst.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lst.Font = New System.Drawing.Font("Tahoma", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lst.FormattingEnabled = True
        Me.lst.ItemHeight = 33
        Me.lst.Location = New System.Drawing.Point(0, 37)
        Me.lst.Name = "lst"
        Me.lst.Size = New System.Drawing.Size(338, 531)
        Me.lst.TabIndex = 64
        '
        'pnlName
        '
        Me.pnlName.BackColor = System.Drawing.SystemColors.InactiveCaption
        Me.pnlName.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.pnlName.Controls.Add(Me.lblPrecio)
        Me.pnlName.Controls.Add(Me.lblArticulo)
        Me.pnlName.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlName.Location = New System.Drawing.Point(0, 0)
        Me.pnlName.Name = "pnlName"
        Me.pnlName.Size = New System.Drawing.Size(338, 37)
        Me.pnlName.TabIndex = 63
        '
        'lblPrecio
        '
        Me.lblPrecio.BackColor = System.Drawing.SystemColors.InactiveCaption
        Me.lblPrecio.Dock = System.Windows.Forms.DockStyle.Right
        Me.lblPrecio.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPrecio.ForeColor = System.Drawing.Color.Red
        Me.lblPrecio.Location = New System.Drawing.Point(271, 0)
        Me.lblPrecio.Name = "lblPrecio"
        Me.lblPrecio.Size = New System.Drawing.Size(63, 33)
        Me.lblPrecio.TabIndex = 62
        Me.lblPrecio.Text = "0,00"
        Me.lblPrecio.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblArticulo
        '
        Me.lblArticulo.BackColor = System.Drawing.SystemColors.InactiveCaption
        Me.lblArticulo.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblArticulo.ForeColor = System.Drawing.SystemColors.Highlight
        Me.lblArticulo.Location = New System.Drawing.Point(3, 4)
        Me.lblArticulo.Name = "lblArticulo"
        Me.lblArticulo.Size = New System.Drawing.Size(196, 24)
        Me.lblArticulo.TabIndex = 61
        Me.lblArticulo.Text = "NOMBRE ARTICULO Y TAL"
        Me.lblArticulo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'frmPaneldeVentas_Compone
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), System.Drawing.Image)
        Me.CancelButton = Me.BtCancell
        Me.ClientSize = New System.Drawing.Size(1095, 568)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.PnlGaleria)
        Me.Controls.Add(Me.CbCategorias)
        Me.Controls.Add(Me.LblName)
        Me.Controls.Add(Me.PnlAction_Buttons)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmPaneldeVentas_Compone"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Seleccione la composición del producto"
        Me.PnlAction_Buttons.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.pnlName.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents PnlAction_Buttons As System.Windows.Forms.Panel
    Friend WithEvents BtCancell As System.Windows.Forms.Button
    Friend WithEvents LblName As System.Windows.Forms.Label
    Friend WithEvents CbCategorias As System.Windows.Forms.ComboBox
    Friend WithEvents PnlGaleria As System.Windows.Forms.Panel
    Friend WithEvents BtImg_Next As System.Windows.Forms.Button
    Friend WithEvents BtImg_Previous As System.Windows.Forms.Button
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents pnlName As System.Windows.Forms.Panel
    Friend WithEvents lblArticulo As System.Windows.Forms.Label
    Friend WithEvents lst As System.Windows.Forms.ListBox
    Friend WithEvents lblPrecio As System.Windows.Forms.Label
    Friend WithEvents BtOK As System.Windows.Forms.Button
End Class
