<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSolicita_Pass
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
        Me.components = New System.ComponentModel.Container
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmSolicita_Pass))
        Me.LblName = New System.Windows.Forms.Label
        Me.PnlGaleria = New System.Windows.Forms.Panel
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.BtClear = New System.Windows.Forms.Button
        Me.BtCancell = New System.Windows.Forms.Button
        Me.BtOK = New System.Windows.Forms.Button
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.TxtPass = New System.Windows.Forms.TextBox
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.Bt_7 = New System.Windows.Forms.Button
        Me.Bt_8 = New System.Windows.Forms.Button
        Me.Bt_9 = New System.Windows.Forms.Button
        Me.Bt_0 = New System.Windows.Forms.Button
        Me.Bt_4 = New System.Windows.Forms.Button
        Me.Bt_3 = New System.Windows.Forms.Button
        Me.Bt_5 = New System.Windows.Forms.Button
        Me.Bt_2 = New System.Windows.Forms.Button
        Me.Bt_6 = New System.Windows.Forms.Button
        Me.Bt_1 = New System.Windows.Forms.Button
        Me.SplitContainer = New System.Windows.Forms.SplitContainer
        Me.m_logo = New System.Windows.Forms.PictureBox
        Me.PnlButton_Shell = New System.Windows.Forms.Panel
        Me.BtUnlock = New System.Windows.Forms.Button
        Me.BtClose = New System.Windows.Forms.Button
        Me.LblSubTitle = New System.Windows.Forms.Label
        Me.LblTitle = New System.Windows.Forms.Label
        Me.PnlBody = New System.Windows.Forms.Panel
        Me.lbl = New System.Windows.Forms.Label
        Me.LblHour = New System.Windows.Forms.Label
        Me.TmHour = New System.Windows.Forms.Timer(Me.components)
        Me.PnlGaleria.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.SplitContainer.Panel1.SuspendLayout()
        Me.SplitContainer.Panel2.SuspendLayout()
        Me.SplitContainer.SuspendLayout()
        CType(Me.m_logo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PnlButton_Shell.SuspendLayout()
        Me.PnlBody.SuspendLayout()
        Me.SuspendLayout()
        '
        'LblName
        '
        Me.LblName.BackColor = System.Drawing.Color.Transparent
        Me.LblName.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblName.Location = New System.Drawing.Point(350, 40)
        Me.LblName.Name = "LblName"
        Me.LblName.Size = New System.Drawing.Size(322, 23)
        Me.LblName.TabIndex = 34
        Me.LblName.Text = "Contraseña de Usuario"
        Me.LblName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'PnlGaleria
        '
        Me.PnlGaleria.BackColor = System.Drawing.Color.FromArgb(CType(CType(174, Byte), Integer), CType(CType(186, Byte), Integer), CType(CType(186, Byte), Integer))
        Me.PnlGaleria.Controls.Add(Me.GroupBox3)
        Me.PnlGaleria.Controls.Add(Me.GroupBox2)
        Me.PnlGaleria.Controls.Add(Me.GroupBox1)
        Me.PnlGaleria.Location = New System.Drawing.Point(66, 59)
        Me.PnlGaleria.Name = "PnlGaleria"
        Me.PnlGaleria.Size = New System.Drawing.Size(318, 347)
        Me.PnlGaleria.TabIndex = 42
        Me.PnlGaleria.Visible = False
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.BtClear)
        Me.GroupBox3.Controls.Add(Me.BtCancell)
        Me.GroupBox3.Controls.Add(Me.BtOK)
        Me.GroupBox3.Location = New System.Drawing.Point(209, 70)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(106, 269)
        Me.GroupBox3.TabIndex = 57
        Me.GroupBox3.TabStop = False
        '
        'BtClear
        '
        Me.BtClear.BackColor = System.Drawing.SystemColors.Control
        Me.BtClear.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtClear.Image = CType(resources.GetObject("BtClear.Image"), System.Drawing.Image)
        Me.BtClear.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.BtClear.Location = New System.Drawing.Point(6, 14)
        Me.BtClear.Name = "BtClear"
        Me.BtClear.Size = New System.Drawing.Size(94, 55)
        Me.BtClear.TabIndex = 54
        Me.BtClear.Tag = "clear"
        Me.BtClear.Text = "Limpia"
        Me.BtClear.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.BtClear.UseVisualStyleBackColor = False
        '
        'BtCancell
        '
        Me.BtCancell.BackColor = System.Drawing.SystemColors.Control
        Me.BtCancell.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.BtCancell.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtCancell.Image = CType(resources.GetObject("BtCancell.Image"), System.Drawing.Image)
        Me.BtCancell.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.BtCancell.Location = New System.Drawing.Point(6, 75)
        Me.BtCancell.Name = "BtCancell"
        Me.BtCancell.Size = New System.Drawing.Size(94, 58)
        Me.BtCancell.TabIndex = 0
        Me.BtCancell.Tag = "cancell"
        Me.BtCancell.Text = "Cancela"
        Me.BtCancell.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.BtCancell.UseVisualStyleBackColor = False
        '
        'BtOK
        '
        Me.BtOK.Enabled = False
        Me.BtOK.Font = New System.Drawing.Font("Tahoma", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtOK.Image = CType(resources.GetObject("BtOK.Image"), System.Drawing.Image)
        Me.BtOK.Location = New System.Drawing.Point(6, 139)
        Me.BtOK.Name = "BtOK"
        Me.BtOK.Size = New System.Drawing.Size(94, 122)
        Me.BtOK.TabIndex = 53
        Me.BtOK.Text = "Valida!"
        Me.BtOK.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.BtOK.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.TxtPass)
        Me.GroupBox2.Location = New System.Drawing.Point(3, 1)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(312, 63)
        Me.GroupBox2.TabIndex = 56
        Me.GroupBox2.TabStop = False
        '
        'TxtPass
        '
        Me.TxtPass.Font = New System.Drawing.Font("Tahoma", 24.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtPass.Location = New System.Drawing.Point(6, 11)
        Me.TxtPass.MaxLength = 10
        Me.TxtPass.Name = "TxtPass"
        Me.TxtPass.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.TxtPass.Size = New System.Drawing.Size(300, 46)
        Me.TxtPass.TabIndex = 54
        Me.TxtPass.Tag = "pass"
        Me.TxtPass.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Bt_7)
        Me.GroupBox1.Controls.Add(Me.Bt_8)
        Me.GroupBox1.Controls.Add(Me.Bt_9)
        Me.GroupBox1.Controls.Add(Me.Bt_0)
        Me.GroupBox1.Controls.Add(Me.Bt_4)
        Me.GroupBox1.Controls.Add(Me.Bt_3)
        Me.GroupBox1.Controls.Add(Me.Bt_5)
        Me.GroupBox1.Controls.Add(Me.Bt_2)
        Me.GroupBox1.Controls.Add(Me.Bt_6)
        Me.GroupBox1.Controls.Add(Me.Bt_1)
        Me.GroupBox1.Location = New System.Drawing.Point(3, 70)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(200, 269)
        Me.GroupBox1.TabIndex = 55
        Me.GroupBox1.TabStop = False
        '
        'Bt_7
        '
        Me.Bt_7.Font = New System.Drawing.Font("Tahoma", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Bt_7.Location = New System.Drawing.Point(6, 11)
        Me.Bt_7.Name = "Bt_7"
        Me.Bt_7.Size = New System.Drawing.Size(58, 58)
        Me.Bt_7.TabIndex = 42
        Me.Bt_7.Text = "7"
        Me.Bt_7.UseVisualStyleBackColor = True
        '
        'Bt_8
        '
        Me.Bt_8.Font = New System.Drawing.Font("Tahoma", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Bt_8.Location = New System.Drawing.Point(70, 11)
        Me.Bt_8.Name = "Bt_8"
        Me.Bt_8.Size = New System.Drawing.Size(58, 58)
        Me.Bt_8.TabIndex = 43
        Me.Bt_8.Text = "8"
        Me.Bt_8.UseVisualStyleBackColor = True
        '
        'Bt_9
        '
        Me.Bt_9.Font = New System.Drawing.Font("Tahoma", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Bt_9.Location = New System.Drawing.Point(134, 11)
        Me.Bt_9.Name = "Bt_9"
        Me.Bt_9.Size = New System.Drawing.Size(58, 58)
        Me.Bt_9.TabIndex = 44
        Me.Bt_9.Text = "9"
        Me.Bt_9.UseVisualStyleBackColor = True
        '
        'Bt_0
        '
        Me.Bt_0.Font = New System.Drawing.Font("Tahoma", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Bt_0.Location = New System.Drawing.Point(6, 203)
        Me.Bt_0.Name = "Bt_0"
        Me.Bt_0.Size = New System.Drawing.Size(122, 58)
        Me.Bt_0.TabIndex = 51
        Me.Bt_0.Text = "0"
        Me.Bt_0.UseVisualStyleBackColor = True
        '
        'Bt_4
        '
        Me.Bt_4.Font = New System.Drawing.Font("Tahoma", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Bt_4.Location = New System.Drawing.Point(6, 75)
        Me.Bt_4.Name = "Bt_4"
        Me.Bt_4.Size = New System.Drawing.Size(58, 58)
        Me.Bt_4.TabIndex = 45
        Me.Bt_4.Text = "4"
        Me.Bt_4.UseVisualStyleBackColor = True
        '
        'Bt_3
        '
        Me.Bt_3.Font = New System.Drawing.Font("Tahoma", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Bt_3.Location = New System.Drawing.Point(134, 139)
        Me.Bt_3.Name = "Bt_3"
        Me.Bt_3.Size = New System.Drawing.Size(58, 58)
        Me.Bt_3.TabIndex = 50
        Me.Bt_3.Text = "3"
        Me.Bt_3.UseVisualStyleBackColor = True
        '
        'Bt_5
        '
        Me.Bt_5.Font = New System.Drawing.Font("Tahoma", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Bt_5.Location = New System.Drawing.Point(70, 75)
        Me.Bt_5.Name = "Bt_5"
        Me.Bt_5.Size = New System.Drawing.Size(58, 58)
        Me.Bt_5.TabIndex = 46
        Me.Bt_5.Text = "5"
        Me.Bt_5.UseVisualStyleBackColor = True
        '
        'Bt_2
        '
        Me.Bt_2.Font = New System.Drawing.Font("Tahoma", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Bt_2.Location = New System.Drawing.Point(70, 139)
        Me.Bt_2.Name = "Bt_2"
        Me.Bt_2.Size = New System.Drawing.Size(58, 58)
        Me.Bt_2.TabIndex = 49
        Me.Bt_2.Text = "2"
        Me.Bt_2.UseVisualStyleBackColor = True
        '
        'Bt_6
        '
        Me.Bt_6.Font = New System.Drawing.Font("Tahoma", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Bt_6.Location = New System.Drawing.Point(134, 75)
        Me.Bt_6.Name = "Bt_6"
        Me.Bt_6.Size = New System.Drawing.Size(58, 58)
        Me.Bt_6.TabIndex = 47
        Me.Bt_6.Text = "6"
        Me.Bt_6.UseVisualStyleBackColor = True
        '
        'Bt_1
        '
        Me.Bt_1.Font = New System.Drawing.Font("Tahoma", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Bt_1.Location = New System.Drawing.Point(6, 139)
        Me.Bt_1.Name = "Bt_1"
        Me.Bt_1.Size = New System.Drawing.Size(58, 58)
        Me.Bt_1.TabIndex = 48
        Me.Bt_1.Text = "1"
        Me.Bt_1.UseVisualStyleBackColor = True
        '
        'SplitContainer
        '
        Me.SplitContainer.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer.FixedPanel = System.Windows.Forms.FixedPanel.Panel1
        Me.SplitContainer.ForeColor = System.Drawing.SystemColors.ActiveCaption
        Me.SplitContainer.IsSplitterFixed = True
        Me.SplitContainer.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainer.Name = "SplitContainer"
        Me.SplitContainer.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'SplitContainer.Panel1
        '
        Me.SplitContainer.Panel1.Controls.Add(Me.m_logo)
        Me.SplitContainer.Panel1.Controls.Add(Me.PnlButton_Shell)
        Me.SplitContainer.Panel1.Controls.Add(Me.LblSubTitle)
        Me.SplitContainer.Panel1.Controls.Add(Me.LblTitle)
        '
        'SplitContainer.Panel2
        '
        Me.SplitContainer.Panel2.AutoScroll = True
        Me.SplitContainer.Panel2.BackColor = System.Drawing.Color.Black
        Me.SplitContainer.Panel2.BackgroundImage = Global.gTPV.My.Resources.Resources.admin_login_icon
        Me.SplitContainer.Panel2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.SplitContainer.Panel2.Controls.Add(Me.PnlBody)
        Me.SplitContainer.Panel2.Controls.Add(Me.LblHour)
        Me.SplitContainer.Panel2.Tag = "233; 248; 250"
        Me.SplitContainer.Size = New System.Drawing.Size(1075, 670)
        Me.SplitContainer.SplitterDistance = 64
        Me.SplitContainer.SplitterWidth = 1
        Me.SplitContainer.TabIndex = 44
        '
        'm_logo
        '
        Me.m_logo.Cursor = System.Windows.Forms.Cursors.Hand
        Me.m_logo.Image = CType(resources.GetObject("m_logo.Image"), System.Drawing.Image)
        Me.m_logo.Location = New System.Drawing.Point(3, 3)
        Me.m_logo.Name = "m_logo"
        Me.m_logo.Size = New System.Drawing.Size(48, 48)
        Me.m_logo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.m_logo.TabIndex = 32
        Me.m_logo.TabStop = False
        '
        'PnlButton_Shell
        '
        Me.PnlButton_Shell.Controls.Add(Me.BtUnlock)
        Me.PnlButton_Shell.Controls.Add(Me.BtClose)
        Me.PnlButton_Shell.Dock = System.Windows.Forms.DockStyle.Right
        Me.PnlButton_Shell.Location = New System.Drawing.Point(604, 0)
        Me.PnlButton_Shell.Name = "PnlButton_Shell"
        Me.PnlButton_Shell.Size = New System.Drawing.Size(471, 64)
        Me.PnlButton_Shell.TabIndex = 2
        '
        'BtUnlock
        '
        Me.BtUnlock.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.BtUnlock.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtUnlock.Image = CType(resources.GetObject("BtUnlock.Image"), System.Drawing.Image)
        Me.BtUnlock.Location = New System.Drawing.Point(125, 3)
        Me.BtUnlock.Name = "BtUnlock"
        Me.BtUnlock.Size = New System.Drawing.Size(170, 58)
        Me.BtUnlock.TabIndex = 8
        Me.BtUnlock.Tag = "unlock"
        Me.BtUnlock.Text = "unlock"
        Me.BtUnlock.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.BtUnlock.UseVisualStyleBackColor = True
        Me.BtUnlock.Visible = False
        '
        'BtClose
        '
        Me.BtClose.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.BtClose.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtClose.Image = CType(resources.GetObject("BtClose.Image"), System.Drawing.Image)
        Me.BtClose.Location = New System.Drawing.Point(301, 4)
        Me.BtClose.Name = "BtClose"
        Me.BtClose.Size = New System.Drawing.Size(170, 58)
        Me.BtClose.TabIndex = 7
        Me.BtClose.Tag = "close"
        Me.BtClose.Text = "Cerrar"
        Me.BtClose.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.BtClose.UseVisualStyleBackColor = True
        '
        'LblSubTitle
        '
        Me.LblSubTitle.ForeColor = System.Drawing.SystemColors.InactiveCaption
        Me.LblSubTitle.Location = New System.Drawing.Point(64, 30)
        Me.LblSubTitle.Name = "LblSubTitle"
        Me.LblSubTitle.Size = New System.Drawing.Size(290, 31)
        Me.LblSubTitle.TabIndex = 1
        Me.LblSubTitle.Text = "Especifique su Contraseña de Acceso para poder continuar"
        '
        'LblTitle
        '
        Me.LblTitle.AutoSize = True
        Me.LblTitle.Font = New System.Drawing.Font("Tahoma", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblTitle.Location = New System.Drawing.Point(57, 4)
        Me.LblTitle.Name = "LblTitle"
        Me.LblTitle.Size = New System.Drawing.Size(219, 23)
        Me.LblTitle.TabIndex = 0
        Me.LblTitle.Text = "Contraseña de Acceso"
        '
        'PnlBody
        '
        Me.PnlBody.BackColor = System.Drawing.Color.Transparent
        Me.PnlBody.Controls.Add(Me.lbl)
        Me.PnlBody.Controls.Add(Me.PnlGaleria)
        Me.PnlBody.Location = New System.Drawing.Point(136, 65)
        Me.PnlBody.Name = "PnlBody"
        Me.PnlBody.Size = New System.Drawing.Size(454, 430)
        Me.PnlBody.TabIndex = 43
        '
        'lbl
        '
        Me.lbl.Cursor = System.Windows.Forms.Cursors.Hand
        Me.lbl.Dock = System.Windows.Forms.DockStyle.Top
        Me.lbl.Font = New System.Drawing.Font("Verdana", 26.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl.Location = New System.Drawing.Point(0, 0)
        Me.lbl.Name = "lbl"
        Me.lbl.Size = New System.Drawing.Size(454, 46)
        Me.lbl.TabIndex = 43
        Me.lbl.Text = "Contraseña de Acceso"
        Me.lbl.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'LblHour
        '
        Me.LblHour.Font = New System.Drawing.Font("Verdana", 24.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblHour.ForeColor = System.Drawing.Color.DimGray
        Me.LblHour.Image = CType(resources.GetObject("LblHour.Image"), System.Drawing.Image)
        Me.LblHour.ImageAlign = System.Drawing.ContentAlignment.TopLeft
        Me.LblHour.Location = New System.Drawing.Point(3, 8)
        Me.LblHour.Name = "LblHour"
        Me.LblHour.Size = New System.Drawing.Size(140, 54)
        Me.LblHour.TabIndex = 34
        Me.LblHour.Text = "00:00"
        Me.LblHour.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'TmHour
        '
        Me.TmHour.Interval = 30000
        '
        'frmSolicita_Pass
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Black
        Me.ClientSize = New System.Drawing.Size(1075, 670)
        Me.Controls.Add(Me.SplitContainer)
        Me.Controls.Add(Me.LblName)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmSolicita_Pass"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Solicitud de Contraseña del Usuario"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.PnlGaleria.ResumeLayout(False)
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.SplitContainer.Panel1.ResumeLayout(False)
        Me.SplitContainer.Panel1.PerformLayout()
        Me.SplitContainer.Panel2.ResumeLayout(False)
        Me.SplitContainer.ResumeLayout(False)
        CType(Me.m_logo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PnlButton_Shell.ResumeLayout(False)
        Me.PnlBody.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents BtCancell As System.Windows.Forms.Button
    Friend WithEvents LblName As System.Windows.Forms.Label
    Friend WithEvents PnlGaleria As System.Windows.Forms.Panel
    Friend WithEvents BtOK As System.Windows.Forms.Button
    Friend WithEvents Bt_0 As System.Windows.Forms.Button
    Friend WithEvents Bt_3 As System.Windows.Forms.Button
    Friend WithEvents Bt_2 As System.Windows.Forms.Button
    Friend WithEvents Bt_1 As System.Windows.Forms.Button
    Friend WithEvents Bt_6 As System.Windows.Forms.Button
    Friend WithEvents Bt_5 As System.Windows.Forms.Button
    Friend WithEvents Bt_4 As System.Windows.Forms.Button
    Friend WithEvents Bt_9 As System.Windows.Forms.Button
    Friend WithEvents Bt_8 As System.Windows.Forms.Button
    Friend WithEvents Bt_7 As System.Windows.Forms.Button
    Friend WithEvents TxtPass As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents BtClear As System.Windows.Forms.Button
    Friend WithEvents SplitContainer As System.Windows.Forms.SplitContainer
    Friend WithEvents m_logo As System.Windows.Forms.PictureBox
    Friend WithEvents PnlButton_Shell As System.Windows.Forms.Panel
    Friend WithEvents BtClose As System.Windows.Forms.Button
    Friend WithEvents LblSubTitle As System.Windows.Forms.Label
    Friend WithEvents LblTitle As System.Windows.Forms.Label
    Friend WithEvents LblHour As System.Windows.Forms.Label
    Friend WithEvents PnlBody As System.Windows.Forms.Panel
    Friend WithEvents TmHour As System.Windows.Forms.Timer
    Friend WithEvents lbl As System.Windows.Forms.Label
    Friend WithEvents BtUnlock As System.Windows.Forms.Button
End Class
