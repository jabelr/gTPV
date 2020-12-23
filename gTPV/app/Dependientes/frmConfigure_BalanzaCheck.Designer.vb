<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmConfigure_BalanzaCheck
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmConfigure_BalanzaCheck))
        Me.BtOpen = New System.Windows.Forms.Button()
        Me.BtWrite = New System.Windows.Forms.Button()
        Me.Lst = New System.Windows.Forms.ListBox()
        Me.LblName = New System.Windows.Forms.Label()
        Me.GroupEntrega = New System.Windows.Forms.GroupBox()
        Me.Txt = New System.Windows.Forms.TextBox()
        Me.Panel = New System.Windows.Forms.Panel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.tmr = New System.Windows.Forms.Timer(Me.components)
        Me.GroupEntrega.SuspendLayout()
        Me.Panel.SuspendLayout()
        Me.SuspendLayout()
        '
        'BtOpen
        '
        Me.BtOpen.Font = New System.Drawing.Font("Tahoma", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtOpen.Image = CType(resources.GetObject("BtOpen.Image"), System.Drawing.Image)
        Me.BtOpen.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtOpen.Location = New System.Drawing.Point(58, 75)
        Me.BtOpen.Name = "BtOpen"
        Me.BtOpen.Size = New System.Drawing.Size(276, 58)
        Me.BtOpen.TabIndex = 0
        Me.BtOpen.Text = "Abrir Conexión"
        Me.BtOpen.UseVisualStyleBackColor = True
        '
        'BtWrite
        '
        Me.BtWrite.Enabled = False
        Me.BtWrite.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtWrite.Location = New System.Drawing.Point(198, 17)
        Me.BtWrite.Name = "BtWrite"
        Me.BtWrite.Size = New System.Drawing.Size(104, 46)
        Me.BtWrite.TabIndex = 1
        Me.BtWrite.Text = "Pesar!"
        Me.BtWrite.UseVisualStyleBackColor = True
        '
        'Lst
        '
        Me.Lst.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lst.FormattingEnabled = True
        Me.Lst.ItemHeight = 20
        Me.Lst.Location = New System.Drawing.Point(3, 105)
        Me.Lst.Name = "Lst"
        Me.Lst.Size = New System.Drawing.Size(308, 244)
        Me.Lst.TabIndex = 2
        '
        'LblName
        '
        Me.LblName.BackColor = System.Drawing.Color.Transparent
        Me.LblName.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblName.Location = New System.Drawing.Point(43, 35)
        Me.LblName.Name = "LblName"
        Me.LblName.Size = New System.Drawing.Size(210, 23)
        Me.LblName.TabIndex = 35
        Me.LblName.Text = "Balanza PC"
        Me.LblName.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'GroupEntrega
        '
        Me.GroupEntrega.Controls.Add(Me.Txt)
        Me.GroupEntrega.Controls.Add(Me.BtWrite)
        Me.GroupEntrega.Location = New System.Drawing.Point(3, 3)
        Me.GroupEntrega.Name = "GroupEntrega"
        Me.GroupEntrega.Size = New System.Drawing.Size(308, 73)
        Me.GroupEntrega.TabIndex = 36
        Me.GroupEntrega.TabStop = False
        Me.GroupEntrega.Text = "Importe"
        '
        'Txt
        '
        Me.Txt.Font = New System.Drawing.Font("Tahoma", 24.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt.Location = New System.Drawing.Point(6, 17)
        Me.Txt.MaxLength = 10
        Me.Txt.Name = "Txt"
        Me.Txt.Size = New System.Drawing.Size(186, 46)
        Me.Txt.TabIndex = 0
        Me.Txt.Tag = ""
        Me.Txt.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Panel
        '
        Me.Panel.Controls.Add(Me.Label1)
        Me.Panel.Controls.Add(Me.GroupEntrega)
        Me.Panel.Controls.Add(Me.Lst)
        Me.Panel.Location = New System.Drawing.Point(43, 75)
        Me.Panel.Name = "Panel"
        Me.Panel.Size = New System.Drawing.Size(315, 354)
        Me.Panel.TabIndex = 37
        Me.Panel.Visible = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(6, 89)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(99, 13)
        Me.Label1.TabIndex = 37
        Me.Label1.Text = "Detalles de Lectura"
        '
        'tmr
        '
        Me.tmr.Interval = 1000
        '
        'frmConfigure_BalanzaCheck
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(174, Byte), Integer), CType(CType(186, Byte), Integer), CType(CType(186, Byte), Integer))
        Me.BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), System.Drawing.Image)
        Me.ClientSize = New System.Drawing.Size(399, 458)
        Me.Controls.Add(Me.LblName)
        Me.Controls.Add(Me.BtOpen)
        Me.Controls.Add(Me.Panel)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmConfigure_BalanzaCheck"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Chequeo de la balanza PC"
        Me.GroupEntrega.ResumeLayout(False)
        Me.GroupEntrega.PerformLayout()
        Me.Panel.ResumeLayout(False)
        Me.Panel.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents BtOpen As System.Windows.Forms.Button
    Friend WithEvents BtWrite As System.Windows.Forms.Button
    Friend WithEvents Lst As System.Windows.Forms.ListBox
    Friend WithEvents LblName As System.Windows.Forms.Label
    Friend WithEvents GroupEntrega As System.Windows.Forms.GroupBox
    Friend WithEvents Txt As System.Windows.Forms.TextBox
    Friend WithEvents Panel As System.Windows.Forms.Panel
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents tmr As System.Windows.Forms.Timer

End Class
