<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmArticulos_SelectImgGalery
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
        Dim Label1 As System.Windows.Forms.Label
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmArticulos_SelectImgGalery))
        Me.PnlAction_Buttons = New System.Windows.Forms.Panel()
        Me.BtImg_Next = New System.Windows.Forms.Button()
        Me.BtImg_Previous = New System.Windows.Forms.Button()
        Me.BtCancell = New System.Windows.Forms.Button()
        Me.LblName = New System.Windows.Forms.Label()
        Me.PnlGaleria = New System.Windows.Forms.Panel()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.lst = New System.Windows.Forms.ListBox()
        Me.lblNofM = New System.Windows.Forms.Label()
        Me.txtFilter = New System.Windows.Forms.TextBox()
        Label1 = New System.Windows.Forms.Label()
        Me.PnlAction_Buttons.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label1
        '
        Label1.AutoSize = True
        Label1.BackColor = System.Drawing.Color.Transparent
        Label1.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Label1.Location = New System.Drawing.Point(48, 81)
        Label1.Name = "Label1"
        Label1.Size = New System.Drawing.Size(71, 18)
        Label1.TabIndex = 40
        Label1.Text = "Filtrar por"
        '
        'PnlAction_Buttons
        '
        Me.PnlAction_Buttons.BackColor = System.Drawing.Color.Transparent
        Me.PnlAction_Buttons.Controls.Add(Me.BtImg_Next)
        Me.PnlAction_Buttons.Controls.Add(Me.BtImg_Previous)
        Me.PnlAction_Buttons.Controls.Add(Me.BtCancell)
        Me.PnlAction_Buttons.Location = New System.Drawing.Point(389, 35)
        Me.PnlAction_Buttons.Name = "PnlAction_Buttons"
        Me.PnlAction_Buttons.Size = New System.Drawing.Size(206, 64)
        Me.PnlAction_Buttons.TabIndex = 3
        Me.PnlAction_Buttons.Tag = "NO_SCAN"
        '
        'BtImg_Next
        '
        Me.BtImg_Next.BackColor = System.Drawing.SystemColors.Control
        Me.BtImg_Next.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtImg_Next.Image = CType(resources.GetObject("BtImg_Next.Image"), System.Drawing.Image)
        Me.BtImg_Next.Location = New System.Drawing.Point(68, 3)
        Me.BtImg_Next.Name = "BtImg_Next"
        Me.BtImg_Next.Size = New System.Drawing.Size(60, 55)
        Me.BtImg_Next.TabIndex = 16
        Me.BtImg_Next.Tag = ""
        Me.BtImg_Next.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtImg_Next.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage
        Me.BtImg_Next.UseVisualStyleBackColor = False
        '
        'BtImg_Previous
        '
        Me.BtImg_Previous.BackColor = System.Drawing.SystemColors.Control
        Me.BtImg_Previous.Enabled = False
        Me.BtImg_Previous.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtImg_Previous.Image = CType(resources.GetObject("BtImg_Previous.Image"), System.Drawing.Image)
        Me.BtImg_Previous.Location = New System.Drawing.Point(4, 3)
        Me.BtImg_Previous.Name = "BtImg_Previous"
        Me.BtImg_Previous.Size = New System.Drawing.Size(60, 55)
        Me.BtImg_Previous.TabIndex = 15
        Me.BtImg_Previous.Tag = ""
        Me.BtImg_Previous.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BtImg_Previous.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.BtImg_Previous.UseVisualStyleBackColor = False
        '
        'BtCancell
        '
        Me.BtCancell.BackColor = System.Drawing.SystemColors.Control
        Me.BtCancell.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.BtCancell.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtCancell.Image = CType(resources.GetObject("BtCancell.Image"), System.Drawing.Image)
        Me.BtCancell.Location = New System.Drawing.Point(140, 3)
        Me.BtCancell.Name = "BtCancell"
        Me.BtCancell.Size = New System.Drawing.Size(60, 55)
        Me.BtCancell.TabIndex = 0
        Me.BtCancell.Tag = "cancell"
        Me.BtCancell.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.BtCancell.UseVisualStyleBackColor = False
        '
        'LblName
        '
        Me.LblName.BackColor = System.Drawing.Color.Transparent
        Me.LblName.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblName.Location = New System.Drawing.Point(47, 38)
        Me.LblName.Name = "LblName"
        Me.LblName.Size = New System.Drawing.Size(291, 23)
        Me.LblName.TabIndex = 34
        Me.LblName.Text = "Imagenes de Almacén"
        '
        'PnlGaleria
        '
        Me.PnlGaleria.BackColor = System.Drawing.Color.FromArgb(CType(CType(174, Byte), Integer), CType(CType(186, Byte), Integer), CType(CType(186, Byte), Integer))
        Me.PnlGaleria.Location = New System.Drawing.Point(41, 119)
        Me.PnlGaleria.Name = "PnlGaleria"
        Me.PnlGaleria.Size = New System.Drawing.Size(557, 445)
        Me.PnlGaleria.TabIndex = 42
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.White
        Me.Panel1.Controls.Add(Me.lst)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Right
        Me.Panel1.Location = New System.Drawing.Point(639, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(296, 599)
        Me.Panel1.TabIndex = 61
        '
        'lst
        '
        Me.lst.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lst.Font = New System.Drawing.Font("Tahoma", 21.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lst.FormattingEnabled = True
        Me.lst.ItemHeight = 35
        Me.lst.Location = New System.Drawing.Point(0, 0)
        Me.lst.Name = "lst"
        Me.lst.Size = New System.Drawing.Size(296, 599)
        Me.lst.TabIndex = 59
        '
        'lblNofM
        '
        Me.lblNofM.BackColor = System.Drawing.Color.FromArgb(CType(CType(174, Byte), Integer), CType(CType(186, Byte), Integer), CType(CType(186, Byte), Integer))
        Me.lblNofM.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNofM.Location = New System.Drawing.Point(457, 102)
        Me.lblNofM.Name = "lblNofM"
        Me.lblNofM.Size = New System.Drawing.Size(141, 14)
        Me.lblNofM.TabIndex = 62
        Me.lblNofM.Text = "Label2"
        Me.lblNofM.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtFilter
        '
        Me.txtFilter.Font = New System.Drawing.Font("Tahoma", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFilter.Location = New System.Drawing.Point(126, 74)
        Me.txtFilter.MaxLength = 10
        Me.txtFilter.Name = "txtFilter"
        Me.txtFilter.Size = New System.Drawing.Size(257, 40)
        Me.txtFilter.TabIndex = 63
        Me.txtFilter.Tag = ""
        '
        'frmArticulos_SelectImgGalery
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), System.Drawing.Image)
        Me.CancelButton = Me.BtCancell
        Me.ClientSize = New System.Drawing.Size(935, 599)
        Me.Controls.Add(Me.txtFilter)
        Me.Controls.Add(Me.lblNofM)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.PnlGaleria)
        Me.Controls.Add(Label1)
        Me.Controls.Add(Me.LblName)
        Me.Controls.Add(Me.PnlAction_Buttons)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmArticulos_SelectImgGalery"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Galeria de Imagenes de Almacén"
        Me.PnlAction_Buttons.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents PnlAction_Buttons As System.Windows.Forms.Panel
    Friend WithEvents BtCancell As System.Windows.Forms.Button
    Friend WithEvents LblName As System.Windows.Forms.Label
    Friend WithEvents BtImg_Next As System.Windows.Forms.Button
    Friend WithEvents BtImg_Previous As System.Windows.Forms.Button
    Friend WithEvents PnlGaleria As System.Windows.Forms.Panel
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents lst As System.Windows.Forms.ListBox
    Friend WithEvents lblNofM As System.Windows.Forms.Label
    Friend WithEvents txtFilter As System.Windows.Forms.TextBox
End Class
