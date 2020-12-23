<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSelect_Empleado_Original
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmSelect_Empleado_Original))
        Me.PnlAction_Buttons = New System.Windows.Forms.Panel
        Me.BtImg_Next = New System.Windows.Forms.Button
        Me.BtImg_Previous = New System.Windows.Forms.Button
        Me.BtCancell = New System.Windows.Forms.Button
        Me.LblName = New System.Windows.Forms.Label
        Me.PnlGaleria = New System.Windows.Forms.Panel
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.PnlAction_Buttons.SuspendLayout()
        Me.SuspendLayout()
        '
        'PnlAction_Buttons
        '
        Me.PnlAction_Buttons.BackColor = System.Drawing.Color.Transparent
        Me.PnlAction_Buttons.Controls.Add(Me.BtImg_Next)
        Me.PnlAction_Buttons.Controls.Add(Me.BtImg_Previous)
        Me.PnlAction_Buttons.Controls.Add(Me.BtCancell)
        Me.PnlAction_Buttons.Location = New System.Drawing.Point(389, 29)
        Me.PnlAction_Buttons.Name = "PnlAction_Buttons"
        Me.PnlAction_Buttons.Size = New System.Drawing.Size(206, 60)
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
        Me.BtImg_Next.Visible = False
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
        Me.BtImg_Previous.Visible = False
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
        Me.LblName.Text = "Seleccione el Camarero"
        '
        'PnlGaleria
        '
        Me.PnlGaleria.BackColor = System.Drawing.Color.FromArgb(CType(CType(174, Byte), Integer), CType(CType(186, Byte), Integer), CType(CType(186, Byte), Integer))
        Me.PnlGaleria.Location = New System.Drawing.Point(40, 90)
        Me.PnlGaleria.Name = "PnlGaleria"
        Me.PnlGaleria.Size = New System.Drawing.Size(559, 326)
        Me.PnlGaleria.TabIndex = 42
        '
        'Panel1
        '
        Me.Panel1.Location = New System.Drawing.Point(128, 157)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(539, 366)
        Me.Panel1.TabIndex = 43
        '
        'frmSelect_Empleado_Original
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Black
        Me.BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), System.Drawing.Image)
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.CancelButton = Me.BtCancell
        Me.ClientSize = New System.Drawing.Size(769, 538)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.PnlGaleria)
        Me.Controls.Add(Me.LblName)
        Me.Controls.Add(Me.PnlAction_Buttons)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmSelect_Empleado_Original"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Selección de camarero"
        Me.PnlAction_Buttons.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents PnlAction_Buttons As System.Windows.Forms.Panel
    Friend WithEvents BtCancell As System.Windows.Forms.Button
    Friend WithEvents LblName As System.Windows.Forms.Label
    Friend WithEvents BtImg_Next As System.Windows.Forms.Button
    Friend WithEvents BtImg_Previous As System.Windows.Forms.Button
    Friend WithEvents PnlGaleria As System.Windows.Forms.Panel
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
End Class
