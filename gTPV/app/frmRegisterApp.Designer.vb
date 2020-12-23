<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmRegisterApp
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
        Dim PictureBox10 As System.Windows.Forms.PictureBox
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmRegisterApp))
        Dim Label55 As System.Windows.Forms.Label
        Me.ImageList = New System.Windows.Forms.ImageList(Me.components)
        Me.Panel10 = New System.Windows.Forms.Panel()
        Me.BtOk = New System.Windows.Forms.Button()
        Me.BtUnLock = New System.Windows.Forms.Button()
        Me.Label57 = New System.Windows.Forms.Label()
        Me.GroupBox9 = New System.Windows.Forms.GroupBox()
        Me.lblCode = New System.Windows.Forms.Label()
        Me.TxtUnLock = New System.Windows.Forms.TextBox()
        Me.LblAux = New System.Windows.Forms.Label()
        Me.TxtLock = New System.Windows.Forms.TextBox()
        Me.GroupBox8 = New System.Windows.Forms.GroupBox()
        Me.PicImg_gDev = New System.Windows.Forms.PictureBox()
        Me.LnkMail_me = New System.Windows.Forms.LinkLabel()
        Me.LnkMail_Software = New System.Windows.Forms.LinkLabel()
        Me.LnkMail_Contacto = New System.Windows.Forms.LinkLabel()
        Me.LnkWeb = New System.Windows.Forms.LinkLabel()
        Me.Label72 = New System.Windows.Forms.Label()
        Me.Label73 = New System.Windows.Forms.Label()
        PictureBox10 = New System.Windows.Forms.PictureBox()
        Label55 = New System.Windows.Forms.Label()
        CType(PictureBox10, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel10.SuspendLayout()
        Me.GroupBox9.SuspendLayout()
        Me.GroupBox8.SuspendLayout()
        CType(Me.PicImg_gDev, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PictureBox10
        '
        PictureBox10.Image = CType(resources.GetObject("PictureBox10.Image"), System.Drawing.Image)
        PictureBox10.Location = New System.Drawing.Point(17, 9)
        PictureBox10.Name = "PictureBox10"
        PictureBox10.Size = New System.Drawing.Size(48, 48)
        PictureBox10.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        PictureBox10.TabIndex = 8
        PictureBox10.TabStop = False
        '
        'Label55
        '
        Label55.Location = New System.Drawing.Point(86, 35)
        Label55.Name = "Label55"
        Label55.Size = New System.Drawing.Size(310, 34)
        Label55.TabIndex = 6
        Label55.Text = "Registre su copia de la aplicación y suprima los límites de la versión de Demostr" & _
            "ación"
        '
        'ImageList
        '
        Me.ImageList.ImageStream = CType(resources.GetObject("ImageList.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageList.Images.SetKeyName(0, "lock.ico")
        '
        'Panel10
        '
        Me.Panel10.BackColor = System.Drawing.SystemColors.InactiveCaption
        Me.Panel10.Controls.Add(Me.BtOk)
        Me.Panel10.Controls.Add(PictureBox10)
        Me.Panel10.Controls.Add(Me.BtUnLock)
        Me.Panel10.Controls.Add(Label55)
        Me.Panel10.Controls.Add(Me.Label57)
        Me.Panel10.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel10.Location = New System.Drawing.Point(0, 0)
        Me.Panel10.Name = "Panel10"
        Me.Panel10.Size = New System.Drawing.Size(626, 80)
        Me.Panel10.TabIndex = 2
        '
        'BtOk
        '
        Me.BtOk.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.BtOk.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtOk.Image = CType(resources.GetObject("BtOk.Image"), System.Drawing.Image)
        Me.BtOk.Location = New System.Drawing.Point(510, 5)
        Me.BtOk.Name = "BtOk"
        Me.BtOk.Size = New System.Drawing.Size(98, 67)
        Me.BtOk.TabIndex = 1
        Me.BtOk.Tag = ""
        Me.BtOk.Text = "Cancelar - Salir"
        Me.BtOk.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.BtOk.UseVisualStyleBackColor = True
        '
        'BtUnLock
        '
        Me.BtUnLock.Enabled = False
        Me.BtUnLock.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtUnLock.Image = CType(resources.GetObject("BtUnLock.Image"), System.Drawing.Image)
        Me.BtUnLock.Location = New System.Drawing.Point(406, 6)
        Me.BtUnLock.Name = "BtUnLock"
        Me.BtUnLock.Size = New System.Drawing.Size(98, 67)
        Me.BtUnLock.TabIndex = 0
        Me.BtUnLock.Tag = ""
        Me.BtUnLock.Text = "Liberar Aplicación"
        Me.BtUnLock.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.BtUnLock.UseVisualStyleBackColor = True
        '
        'Label57
        '
        Me.Label57.AutoSize = True
        Me.Label57.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label57.Location = New System.Drawing.Point(76, 13)
        Me.Label57.Name = "Label57"
        Me.Label57.Size = New System.Drawing.Size(206, 20)
        Me.Label57.TabIndex = 7
        Me.Label57.Text = "Registro de la aplicación"
        '
        'GroupBox9
        '
        Me.GroupBox9.Controls.Add(Me.lblCode)
        Me.GroupBox9.Controls.Add(Me.TxtUnLock)
        Me.GroupBox9.Controls.Add(Me.LblAux)
        Me.GroupBox9.Controls.Add(Me.TxtLock)
        Me.GroupBox9.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox9.Location = New System.Drawing.Point(12, 86)
        Me.GroupBox9.Name = "GroupBox9"
        Me.GroupBox9.Size = New System.Drawing.Size(601, 145)
        Me.GroupBox9.TabIndex = 0
        Me.GroupBox9.TabStop = False
        Me.GroupBox9.Text = "Registro de la Aplicación"
        '
        'lblCode
        '
        Me.lblCode.BackColor = System.Drawing.Color.LightBlue
        Me.lblCode.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblCode.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCode.Location = New System.Drawing.Point(28, 72)
        Me.lblCode.Margin = New System.Windows.Forms.Padding(0)
        Me.lblCode.Name = "lblCode"
        Me.lblCode.Size = New System.Drawing.Size(546, 17)
        Me.lblCode.TabIndex = 6
        Me.lblCode.Text = "Código de Liberación"
        Me.lblCode.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'TxtUnLock
        '
        Me.TxtUnLock.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtUnLock.Font = New System.Drawing.Font("Tahoma", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtUnLock.Location = New System.Drawing.Point(28, 89)
        Me.TxtUnLock.Margin = New System.Windows.Forms.Padding(0)
        Me.TxtUnLock.Name = "TxtUnLock"
        Me.TxtUnLock.Size = New System.Drawing.Size(545, 33)
        Me.TxtUnLock.TabIndex = 0
        Me.TxtUnLock.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'LblAux
        '
        Me.LblAux.BackColor = System.Drawing.Color.SkyBlue
        Me.LblAux.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.LblAux.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblAux.Location = New System.Drawing.Point(28, 23)
        Me.LblAux.Margin = New System.Windows.Forms.Padding(0)
        Me.LblAux.Name = "LblAux"
        Me.LblAux.Size = New System.Drawing.Size(546, 17)
        Me.LblAux.TabIndex = 4
        Me.LblAux.Text = "Código de Aplicación"
        Me.LblAux.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'TxtLock
        '
        Me.TxtLock.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtLock.Font = New System.Drawing.Font("Tahoma", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtLock.Location = New System.Drawing.Point(28, 40)
        Me.TxtLock.Margin = New System.Windows.Forms.Padding(0)
        Me.TxtLock.Name = "TxtLock"
        Me.TxtLock.ReadOnly = True
        Me.TxtLock.Size = New System.Drawing.Size(545, 33)
        Me.TxtLock.TabIndex = 1
        Me.TxtLock.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'GroupBox8
        '
        Me.GroupBox8.Controls.Add(Me.PicImg_gDev)
        Me.GroupBox8.Controls.Add(Me.LnkMail_me)
        Me.GroupBox8.Controls.Add(Me.LnkMail_Software)
        Me.GroupBox8.Controls.Add(Me.LnkMail_Contacto)
        Me.GroupBox8.Controls.Add(Me.LnkWeb)
        Me.GroupBox8.Controls.Add(Me.Label72)
        Me.GroupBox8.Controls.Add(Me.Label73)
        Me.GroupBox8.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox8.Location = New System.Drawing.Point(12, 237)
        Me.GroupBox8.Name = "GroupBox8"
        Me.GroupBox8.Size = New System.Drawing.Size(601, 205)
        Me.GroupBox8.TabIndex = 3
        Me.GroupBox8.TabStop = False
        Me.GroupBox8.Text = "Información de Contacto"
        '
        'PicImg_gDev
        '
        Me.PicImg_gDev.BackColor = System.Drawing.Color.White
        Me.PicImg_gDev.Cursor = System.Windows.Forms.Cursors.Help
        Me.PicImg_gDev.Image = CType(resources.GetObject("PicImg_gDev.Image"), System.Drawing.Image)
        Me.PicImg_gDev.Location = New System.Drawing.Point(395, 142)
        Me.PicImg_gDev.Name = "PicImg_gDev"
        Me.PicImg_gDev.Size = New System.Drawing.Size(196, 58)
        Me.PicImg_gDev.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PicImg_gDev.TabIndex = 20
        Me.PicImg_gDev.TabStop = False
        '
        'LnkMail_me
        '
        Me.LnkMail_me.AutoSize = True
        Me.LnkMail_me.Enabled = False
        Me.LnkMail_me.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LnkMail_me.Location = New System.Drawing.Point(326, 118)
        Me.LnkMail_me.Name = "LnkMail_me"
        Me.LnkMail_me.Size = New System.Drawing.Size(179, 16)
        Me.LnkMail_me.TabIndex = 18
        Me.LnkMail_me.TabStop = True
        Me.LnkMail_me.Text = "joseabel@gdevelop.net"
        Me.LnkMail_me.Visible = False
        '
        'LnkMail_Software
        '
        Me.LnkMail_Software.AutoSize = True
        Me.LnkMail_Software.Enabled = False
        Me.LnkMail_Software.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LnkMail_Software.Location = New System.Drawing.Point(144, 70)
        Me.LnkMail_Software.Name = "LnkMail_Software"
        Me.LnkMail_Software.Size = New System.Drawing.Size(174, 16)
        Me.LnkMail_Software.TabIndex = 17
        Me.LnkMail_Software.TabStop = True
        Me.LnkMail_Software.Text = "software@gdevelop.es"
        Me.LnkMail_Software.Visible = False
        '
        'LnkMail_Contacto
        '
        Me.LnkMail_Contacto.AutoSize = True
        Me.LnkMail_Contacto.Enabled = False
        Me.LnkMail_Contacto.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LnkMail_Contacto.Location = New System.Drawing.Point(321, 56)
        Me.LnkMail_Contacto.Name = "LnkMail_Contacto"
        Me.LnkMail_Contacto.Size = New System.Drawing.Size(142, 16)
        Me.LnkMail_Contacto.TabIndex = 16
        Me.LnkMail_Contacto.TabStop = True
        Me.LnkMail_Contacto.Text = "corp@gdevelop.es"
        Me.LnkMail_Contacto.Visible = False
        '
        'LnkWeb
        '
        Me.LnkWeb.AutoSize = True
        Me.LnkWeb.Enabled = False
        Me.LnkWeb.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LnkWeb.Location = New System.Drawing.Point(210, 151)
        Me.LnkWeb.Name = "LnkWeb"
        Me.LnkWeb.Size = New System.Drawing.Size(166, 16)
        Me.LnkWeb.TabIndex = 15
        Me.LnkWeb.TabStop = True
        Me.LnkWeb.Text = "software.gdevelop.es"
        Me.LnkWeb.Visible = False
        '
        'Label72
        '
        Me.Label72.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label72.Location = New System.Drawing.Point(2, 184)
        Me.Label72.Name = "Label72"
        Me.Label72.Size = New System.Drawing.Size(290, 16)
        Me.Label72.TabIndex = 5
        Me.Label72.Text = "mercenario [gDevelop Entertainment® 2021]"
        Me.Label72.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'Label73
        '
        Me.Label73.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label73.Location = New System.Drawing.Point(25, 23)
        Me.Label73.Name = "Label73"
        Me.Label73.Size = New System.Drawing.Size(548, 152)
        Me.Label73.TabIndex = 14
        Me.Label73.Text = resources.GetString("Label73.Text")
        Me.Label73.Visible = False
        '
        'frmRegisterApp
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Window
        Me.ClientSize = New System.Drawing.Size(626, 452)
        Me.Controls.Add(Me.GroupBox8)
        Me.Controls.Add(Me.GroupBox9)
        Me.Controls.Add(Me.Panel10)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmRegisterApp"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Registro"
        Me.TopMost = True
        CType(PictureBox10, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel10.ResumeLayout(False)
        Me.Panel10.PerformLayout()
        Me.GroupBox9.ResumeLayout(False)
        Me.GroupBox9.PerformLayout()
        Me.GroupBox8.ResumeLayout(False)
        Me.GroupBox8.PerformLayout()
        CType(Me.PicImg_gDev, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ImageList As System.Windows.Forms.ImageList
    Friend WithEvents Panel10 As System.Windows.Forms.Panel
    Friend WithEvents Label57 As System.Windows.Forms.Label
    Friend WithEvents GroupBox9 As System.Windows.Forms.GroupBox
    Friend WithEvents lblCode As System.Windows.Forms.Label
    Friend WithEvents TxtUnLock As System.Windows.Forms.TextBox
    Friend WithEvents LblAux As System.Windows.Forms.Label
    Friend WithEvents TxtLock As System.Windows.Forms.TextBox
    Friend WithEvents BtOk As System.Windows.Forms.Button
    Friend WithEvents BtUnLock As System.Windows.Forms.Button
    Friend WithEvents GroupBox8 As System.Windows.Forms.GroupBox
    Friend WithEvents PicImg_gDev As System.Windows.Forms.PictureBox
    Friend WithEvents LnkMail_me As System.Windows.Forms.LinkLabel
    Friend WithEvents LnkMail_Software As System.Windows.Forms.LinkLabel
    Friend WithEvents LnkMail_Contacto As System.Windows.Forms.LinkLabel
    Friend WithEvents LnkWeb As System.Windows.Forms.LinkLabel
    Friend WithEvents Label72 As System.Windows.Forms.Label
    Friend WithEvents Label73 As System.Windows.Forms.Label
End Class
