<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmPaneldeVentas_Pesaje
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmPaneldeVentas_Pesaje))
        Me.LblName = New System.Windows.Forms.Label()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.PnlPrecio = New System.Windows.Forms.Panel()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.LblPrecio = New System.Windows.Forms.Label()
        Me.PnlImporte = New System.Windows.Forms.Panel()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.LblImporte = New System.Windows.Forms.Label()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.btPrecio = New System.Windows.Forms.Button()
        Me.BtCancela = New System.Windows.Forms.Button()
        Me.BtOK = New System.Windows.Forms.Button()
        Me.BtRefresh = New System.Windows.Forms.Button()
        Me.PicImg = New System.Windows.Forms.PictureBox()
        Me.groupPeso = New System.Windows.Forms.GroupBox()
        Me.PnlPeso = New System.Windows.Forms.Panel()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.LblPeso = New System.Windows.Forms.Label()
        Me.Tmr = New System.Windows.Forms.Timer(Me.components)
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lblPrecioKG = New System.Windows.Forms.Label()
        Me.GroupBox4.SuspendLayout()
        Me.PnlPrecio.SuspendLayout()
        Me.PnlImporte.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        CType(Me.PicImg, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.groupPeso.SuspendLayout()
        Me.PnlPeso.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'LblName
        '
        Me.LblName.BackColor = System.Drawing.Color.Transparent
        Me.LblName.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblName.Location = New System.Drawing.Point(39, 37)
        Me.LblName.Name = "LblName"
        Me.LblName.Size = New System.Drawing.Size(317, 23)
        Me.LblName.TabIndex = 0
        Me.LblName.Text = "Balanza PC"
        Me.LblName.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.PnlPrecio)
        Me.GroupBox4.Controls.Add(Me.PnlImporte)
        Me.GroupBox4.Location = New System.Drawing.Point(43, 70)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(221, 153)
        Me.GroupBox4.TabIndex = 1
        Me.GroupBox4.TabStop = False
        '
        'PnlPrecio
        '
        Me.PnlPrecio.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.PnlPrecio.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PnlPrecio.Controls.Add(Me.Label2)
        Me.PnlPrecio.Controls.Add(Me.LblPrecio)
        Me.PnlPrecio.Location = New System.Drawing.Point(6, 20)
        Me.PnlPrecio.Name = "PnlPrecio"
        Me.PnlPrecio.Size = New System.Drawing.Size(209, 51)
        Me.PnlPrecio.TabIndex = 0
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.Label2.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(3, 5)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(45, 13)
        Me.Label2.TabIndex = 60
        Me.Label2.Text = "Precio:"
        '
        'LblPrecio
        '
        Me.LblPrecio.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.LblPrecio.Font = New System.Drawing.Font("Verdana", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblPrecio.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.LblPrecio.Location = New System.Drawing.Point(6, 5)
        Me.LblPrecio.Name = "LblPrecio"
        Me.LblPrecio.Size = New System.Drawing.Size(197, 39)
        Me.LblPrecio.TabIndex = 0
        Me.LblPrecio.Text = "0,00 €"
        Me.LblPrecio.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'PnlImporte
        '
        Me.PnlImporte.BackColor = System.Drawing.SystemColors.InactiveCaption
        Me.PnlImporte.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.PnlImporte.Controls.Add(Me.Label3)
        Me.PnlImporte.Controls.Add(Me.LblImporte)
        Me.PnlImporte.Location = New System.Drawing.Point(6, 77)
        Me.PnlImporte.Name = "PnlImporte"
        Me.PnlImporte.Size = New System.Drawing.Size(209, 57)
        Me.PnlImporte.TabIndex = 1
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.SystemColors.InactiveCaption
        Me.Label3.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(3, 5)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(57, 13)
        Me.Label3.TabIndex = 60
        Me.Label3.Text = "Importe:"
        '
        'LblImporte
        '
        Me.LblImporte.BackColor = System.Drawing.SystemColors.InactiveCaption
        Me.LblImporte.Font = New System.Drawing.Font("Verdana", 24.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblImporte.ForeColor = System.Drawing.SystemColors.Highlight
        Me.LblImporte.Location = New System.Drawing.Point(6, 7)
        Me.LblImporte.Name = "LblImporte"
        Me.LblImporte.Size = New System.Drawing.Size(197, 42)
        Me.LblImporte.TabIndex = 61
        Me.LblImporte.Text = "0,00 €"
        Me.LblImporte.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.btPrecio)
        Me.GroupBox3.Controls.Add(Me.BtCancela)
        Me.GroupBox3.Controls.Add(Me.BtOK)
        Me.GroupBox3.Controls.Add(Me.BtRefresh)
        Me.GroupBox3.Location = New System.Drawing.Point(270, 70)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(88, 348)
        Me.GroupBox3.TabIndex = 3
        Me.GroupBox3.TabStop = False
        '
        'btPrecio
        '
        Me.btPrecio.Font = New System.Drawing.Font("Tahoma", 26.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btPrecio.Image = CType(resources.GetObject("btPrecio.Image"), System.Drawing.Image)
        Me.btPrecio.Location = New System.Drawing.Point(6, 165)
        Me.btPrecio.Name = "btPrecio"
        Me.btPrecio.Size = New System.Drawing.Size(76, 68)
        Me.btPrecio.TabIndex = 3
        Me.btPrecio.UseVisualStyleBackColor = True
        '
        'BtCancela
        '
        Me.BtCancela.BackColor = System.Drawing.SystemColors.Control
        Me.BtCancela.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.BtCancela.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtCancela.Image = CType(resources.GetObject("BtCancela.Image"), System.Drawing.Image)
        Me.BtCancela.Location = New System.Drawing.Point(6, 17)
        Me.BtCancela.Name = "BtCancela"
        Me.BtCancela.Size = New System.Drawing.Size(76, 68)
        Me.BtCancela.TabIndex = 0
        Me.BtCancela.Tag = ""
        Me.BtCancela.UseVisualStyleBackColor = False
        '
        'BtOK
        '
        Me.BtOK.Font = New System.Drawing.Font("Tahoma", 26.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtOK.Image = CType(resources.GetObject("BtOK.Image"), System.Drawing.Image)
        Me.BtOK.Location = New System.Drawing.Point(6, 264)
        Me.BtOK.Name = "BtOK"
        Me.BtOK.Size = New System.Drawing.Size(76, 68)
        Me.BtOK.TabIndex = 2
        Me.BtOK.UseVisualStyleBackColor = True
        '
        'BtRefresh
        '
        Me.BtRefresh.Font = New System.Drawing.Font("Tahoma", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtRefresh.Image = CType(resources.GetObject("BtRefresh.Image"), System.Drawing.Image)
        Me.BtRefresh.Location = New System.Drawing.Point(6, 91)
        Me.BtRefresh.Name = "BtRefresh"
        Me.BtRefresh.Size = New System.Drawing.Size(76, 68)
        Me.BtRefresh.TabIndex = 1
        Me.BtRefresh.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BtRefresh.UseVisualStyleBackColor = True
        '
        'PicImg
        '
        Me.PicImg.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PicImg.Location = New System.Drawing.Point(284, 12)
        Me.PicImg.Name = "PicImg"
        Me.PicImg.Size = New System.Drawing.Size(112, 109)
        Me.PicImg.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage
        Me.PicImg.TabIndex = 40
        Me.PicImg.TabStop = False
        Me.PicImg.Tag = ""
        Me.PicImg.Visible = False
        '
        'groupPeso
        '
        Me.groupPeso.Controls.Add(Me.PnlPeso)
        Me.groupPeso.Location = New System.Drawing.Point(43, 229)
        Me.groupPeso.Name = "groupPeso"
        Me.groupPeso.Size = New System.Drawing.Size(221, 84)
        Me.groupPeso.TabIndex = 2
        Me.groupPeso.TabStop = False
        '
        'PnlPeso
        '
        Me.PnlPeso.BackColor = System.Drawing.Color.DarkSeaGreen
        Me.PnlPeso.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PnlPeso.Controls.Add(Me.Label4)
        Me.PnlPeso.Controls.Add(Me.LblPeso)
        Me.PnlPeso.Location = New System.Drawing.Point(6, 19)
        Me.PnlPeso.Name = "PnlPeso"
        Me.PnlPeso.Size = New System.Drawing.Size(209, 51)
        Me.PnlPeso.TabIndex = 62
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.DarkSeaGreen
        Me.Label4.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(3, 5)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(37, 13)
        Me.Label4.TabIndex = 60
        Me.Label4.Text = "Peso:"
        '
        'LblPeso
        '
        Me.LblPeso.BackColor = System.Drawing.Color.DarkSeaGreen
        Me.LblPeso.Font = New System.Drawing.Font("Verdana", 24.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblPeso.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.LblPeso.Location = New System.Drawing.Point(6, 5)
        Me.LblPeso.Name = "LblPeso"
        Me.LblPeso.Size = New System.Drawing.Size(197, 39)
        Me.LblPeso.TabIndex = 58
        Me.LblPeso.Text = "0,00"
        Me.LblPeso.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'Tmr
        '
        Me.Tmr.Interval = 1500
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Panel1)
        Me.GroupBox1.Location = New System.Drawing.Point(43, 334)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(221, 84)
        Me.GroupBox1.TabIndex = 41
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Visible = False
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.SeaGreen
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.lblPrecioKG)
        Me.Panel1.Location = New System.Drawing.Point(6, 19)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(209, 51)
        Me.Panel1.TabIndex = 62
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.SeaGreen
        Me.Label1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(3, 5)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(62, 13)
        Me.Label1.TabIndex = 60
        Me.Label1.Text = "Precio/Kg"
        '
        'lblPrecioKG
        '
        Me.lblPrecioKG.BackColor = System.Drawing.Color.SeaGreen
        Me.lblPrecioKG.Font = New System.Drawing.Font("Verdana", 24.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPrecioKG.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.lblPrecioKG.Location = New System.Drawing.Point(6, 5)
        Me.lblPrecioKG.Name = "lblPrecioKG"
        Me.lblPrecioKG.Size = New System.Drawing.Size(197, 39)
        Me.lblPrecioKG.TabIndex = 58
        Me.lblPrecioKG.Text = "0,00"
        Me.lblPrecioKG.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'frmPaneldeVentas_Pesaje
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(174, Byte), Integer), CType(CType(186, Byte), Integer), CType(CType(186, Byte), Integer))
        Me.BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), System.Drawing.Image)
        Me.ClientSize = New System.Drawing.Size(399, 458)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.groupPeso)
        Me.Controls.Add(Me.GroupBox4)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.LblName)
        Me.Controls.Add(Me.PicImg)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmPaneldeVentas_Pesaje"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Pesaje de Balanza"
        Me.GroupBox4.ResumeLayout(False)
        Me.PnlPrecio.ResumeLayout(False)
        Me.PnlPrecio.PerformLayout()
        Me.PnlImporte.ResumeLayout(False)
        Me.PnlImporte.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        CType(Me.PicImg, System.ComponentModel.ISupportInitialize).EndInit()
        Me.groupPeso.ResumeLayout(False)
        Me.PnlPeso.ResumeLayout(False)
        Me.PnlPeso.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents LblName As System.Windows.Forms.Label
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents PnlPrecio As System.Windows.Forms.Panel
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents LblPrecio As System.Windows.Forms.Label
    Friend WithEvents PnlImporte As System.Windows.Forms.Panel
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents LblImporte As System.Windows.Forms.Label
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents BtCancela As System.Windows.Forms.Button
    Friend WithEvents BtOK As System.Windows.Forms.Button
    Friend WithEvents BtRefresh As System.Windows.Forms.Button
    Friend WithEvents PicImg As System.Windows.Forms.PictureBox
    Friend WithEvents groupPeso As System.Windows.Forms.GroupBox
    Friend WithEvents PnlPeso As System.Windows.Forms.Panel
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents LblPeso As System.Windows.Forms.Label
    Friend WithEvents Tmr As System.Windows.Forms.Timer
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents lblPrecioKG As System.Windows.Forms.Label
    Friend WithEvents btPrecio As System.Windows.Forms.Button

End Class
