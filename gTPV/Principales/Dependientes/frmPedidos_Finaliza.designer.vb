<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmPedidos_Finaliza
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmPedidos_Finaliza))
        Me.BtCancell = New System.Windows.Forms.Button
        Me.BtOk = New System.Windows.Forms.Button
        Me.LblName = New System.Windows.Forms.Label
        Me.PnlGaleria = New System.Windows.Forms.Panel
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.lnkPedidos_None = New System.Windows.Forms.LinkLabel
        Me.lnkPedidos_ALL = New System.Windows.Forms.LinkLabel
        Me.Label330 = New System.Windows.Forms.Label
        Me.lstPedidos = New System.Windows.Forms.ListView
        Me.PnlTotal = New System.Windows.Forms.Panel
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.lblTotal = New System.Windows.Forms.Label
        Me.PnlGaleria.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.PnlTotal.SuspendLayout()
        Me.SuspendLayout()
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
        Me.PnlGaleria.Controls.Add(Me.GroupBox1)
        Me.PnlGaleria.Location = New System.Drawing.Point(48, 69)
        Me.PnlGaleria.Name = "PnlGaleria"
        Me.PnlGaleria.Size = New System.Drawing.Size(640, 446)
        Me.PnlGaleria.TabIndex = 0
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.PnlTotal)
        Me.GroupBox1.Controls.Add(Me.lnkPedidos_None)
        Me.GroupBox1.Controls.Add(Me.lnkPedidos_ALL)
        Me.GroupBox1.Controls.Add(Me.Label330)
        Me.GroupBox1.Controls.Add(Me.lstPedidos)
        Me.GroupBox1.Location = New System.Drawing.Point(3, 3)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(629, 439)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        '
        'lnkPedidos_None
        '
        Me.lnkPedidos_None.AutoSize = True
        Me.lnkPedidos_None.BackColor = System.Drawing.Color.LightSteelBlue
        Me.lnkPedidos_None.Location = New System.Drawing.Point(448, 18)
        Me.lnkPedidos_None.Name = "lnkPedidos_None"
        Me.lnkPedidos_None.Size = New System.Drawing.Size(87, 13)
        Me.lnkPedidos_None.TabIndex = 45
        Me.lnkPedidos_None.TabStop = True
        Me.lnkPedidos_None.Text = "Desmarcar todos"
        '
        'lnkPedidos_ALL
        '
        Me.lnkPedidos_ALL.AutoSize = True
        Me.lnkPedidos_ALL.BackColor = System.Drawing.Color.LightSteelBlue
        Me.lnkPedidos_ALL.Location = New System.Drawing.Point(539, 18)
        Me.lnkPedidos_ALL.Name = "lnkPedidos_ALL"
        Me.lnkPedidos_ALL.Size = New System.Drawing.Size(69, 13)
        Me.lnkPedidos_ALL.TabIndex = 44
        Me.lnkPedidos_ALL.TabStop = True
        Me.lnkPedidos_ALL.Text = "Marcar todos"
        '
        'Label330
        '
        Me.Label330.BackColor = System.Drawing.Color.LightSteelBlue
        Me.Label330.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label330.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label330.Location = New System.Drawing.Point(14, 16)
        Me.Label330.Name = "Label330"
        Me.Label330.Size = New System.Drawing.Size(598, 19)
        Me.Label330.TabIndex = 43
        Me.Label330.Tag = ""
        Me.Label330.Text = " PEDIDOS PENDIENTES"
        Me.Label330.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lstPedidos
        '
        Me.lstPedidos.BackColor = System.Drawing.Color.Beige
        Me.lstPedidos.CheckBoxes = True
        Me.lstPedidos.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lstPedidos.FullRowSelect = True
        Me.lstPedidos.HideSelection = False
        Me.lstPedidos.Location = New System.Drawing.Point(14, 35)
        Me.lstPedidos.Name = "lstPedidos"
        Me.lstPedidos.Size = New System.Drawing.Size(598, 342)
        Me.lstPedidos.TabIndex = 42
        Me.lstPedidos.UseCompatibleStateImageBehavior = False
        Me.lstPedidos.View = System.Windows.Forms.View.Details
        '
        'PnlTotal
        '
        Me.PnlTotal.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.PnlTotal.BackgroundImage = CType(resources.GetObject("PnlTotal.BackgroundImage"), System.Drawing.Image)
        Me.PnlTotal.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.PnlTotal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PnlTotal.Controls.Add(Me.Label2)
        Me.PnlTotal.Controls.Add(Me.Label3)
        Me.PnlTotal.Controls.Add(Me.lblTotal)
        Me.PnlTotal.Location = New System.Drawing.Point(390, 382)
        Me.PnlTotal.Name = "PnlTotal"
        Me.PnlTotal.Size = New System.Drawing.Size(222, 51)
        Me.PnlTotal.TabIndex = 63
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(166, 1)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(45, 13)
        Me.Label2.TabIndex = 60
        Me.Label2.Text = "Cobrar"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Verdana", 24.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Location = New System.Drawing.Point(177, 15)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(40, 38)
        Me.Label3.TabIndex = 61
        Me.Label3.Text = System.Threading.Thread.CurrentThread.CurrentCulture.NumberFormat.CurrencySymbol
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'lblTotal
        '
        Me.lblTotal.BackColor = System.Drawing.Color.Transparent
        Me.lblTotal.Font = New System.Drawing.Font("Verdana", 27.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotal.ForeColor = System.Drawing.Color.Black
        Me.lblTotal.Location = New System.Drawing.Point(6, 1)
        Me.lblTotal.Name = "lblTotal"
        Me.lblTotal.Size = New System.Drawing.Size(175, 51)
        Me.lblTotal.TabIndex = 58
        Me.lblTotal.Text = "0,00"
        Me.lblTotal.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'frmPedidos_Finaliza
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
        Me.Name = "frmPedidos_Finaliza"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Verificación de Entrega de Pedidos"
        Me.PnlGaleria.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.PnlTotal.ResumeLayout(False)
        Me.PnlTotal.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents LblName As System.Windows.Forms.Label
    Friend WithEvents PnlGaleria As System.Windows.Forms.Panel
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents BtCancell As System.Windows.Forms.Button
    Friend WithEvents BtOk As System.Windows.Forms.Button
    Friend WithEvents lnkPedidos_None As System.Windows.Forms.LinkLabel
    Friend WithEvents lnkPedidos_ALL As System.Windows.Forms.LinkLabel
    Friend WithEvents Label330 As System.Windows.Forms.Label
    Friend WithEvents lstPedidos As System.Windows.Forms.ListView
    Friend WithEvents PnlTotal As System.Windows.Forms.Panel
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents lblTotal As System.Windows.Forms.Label
End Class
