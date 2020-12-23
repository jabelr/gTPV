<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmReservas_SelectMenu
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmReservas_SelectMenu))
        Me.PnlAction_Buttons = New System.Windows.Forms.Panel
        Me.BtImg_Next = New System.Windows.Forms.Button
        Me.BtCancell = New System.Windows.Forms.Button
        Me.BtImg_Previous = New System.Windows.Forms.Button
        Me.LblName = New System.Windows.Forms.Label
        Me.CbCategorias = New System.Windows.Forms.ComboBox
        Me.PnlGaleria = New System.Windows.Forms.Panel
        Me.PnlAction_Buttons.SuspendLayout()
        Me.SuspendLayout()
        '
        'PnlAction_Buttons
        '
        Me.PnlAction_Buttons.BackColor = System.Drawing.Color.FromArgb(CType(CType(174, Byte), Integer), CType(CType(186, Byte), Integer), CType(CType(186, Byte), Integer))
        Me.PnlAction_Buttons.Controls.Add(Me.BtImg_Next)
        Me.PnlAction_Buttons.Controls.Add(Me.BtCancell)
        Me.PnlAction_Buttons.Controls.Add(Me.BtImg_Previous)
        Me.PnlAction_Buttons.Location = New System.Drawing.Point(405, 36)
        Me.PnlAction_Buttons.Name = "PnlAction_Buttons"
        Me.PnlAction_Buttons.Size = New System.Drawing.Size(314, 56)
        Me.PnlAction_Buttons.TabIndex = 2
        Me.PnlAction_Buttons.Tag = "NO_SCAN"
        '
        'BtImg_Next
        '
        Me.BtImg_Next.BackColor = System.Drawing.SystemColors.Control
        Me.BtImg_Next.Enabled = False
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
        Me.BtCancell.Location = New System.Drawing.Point(245, 0)
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
        Me.CbCategorias.Visible = False
        '
        'PnlGaleria
        '
        Me.PnlGaleria.BackColor = System.Drawing.Color.FromArgb(CType(CType(174, Byte), Integer), CType(CType(186, Byte), Integer), CType(CType(186, Byte), Integer))
        Me.PnlGaleria.Location = New System.Drawing.Point(43, 93)
        Me.PnlGaleria.Name = "PnlGaleria"
        Me.PnlGaleria.Size = New System.Drawing.Size(676, 438)
        Me.PnlGaleria.TabIndex = 1
        '
        'frmReservas_SelectMenu
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), System.Drawing.Image)
        Me.CancelButton = Me.BtCancell
        Me.ClientSize = New System.Drawing.Size(761, 568)
        Me.Controls.Add(Me.PnlGaleria)
        Me.Controls.Add(Me.CbCategorias)
        Me.Controls.Add(Me.LblName)
        Me.Controls.Add(Me.PnlAction_Buttons)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmReservas_SelectMenu"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Seleccione el artículo a reservar"
        Me.PnlAction_Buttons.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents PnlAction_Buttons As System.Windows.Forms.Panel
    Friend WithEvents BtCancell As System.Windows.Forms.Button
    Friend WithEvents LblName As System.Windows.Forms.Label
    Friend WithEvents CbCategorias As System.Windows.Forms.ComboBox
    Friend WithEvents PnlGaleria As System.Windows.Forms.Panel
    Friend WithEvents BtImg_Next As System.Windows.Forms.Button
    Friend WithEvents BtImg_Previous As System.Windows.Forms.Button
End Class
