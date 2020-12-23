<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSelect_Empleado
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmSelect_Empleado))
        Me.SplitContainer = New System.Windows.Forms.SplitContainer()
        Me.m_logo = New System.Windows.Forms.PictureBox()
        Me.PnlButton_Shell = New System.Windows.Forms.Panel()
        Me.BtLogout = New System.Windows.Forms.Button()
        Me.BtAcceso = New System.Windows.Forms.Button()
        Me.BtClose = New System.Windows.Forms.Button()
        Me.LblSubTitle = New System.Windows.Forms.Label()
        Me.LblTitle = New System.Windows.Forms.Label()
        Me.PnlLastTicket = New System.Windows.Forms.Panel()
        Me.PicImg = New System.Windows.Forms.PictureBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.LblLastEmpleado = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.LblLastPVP = New System.Windows.Forms.Label()
        Me.LblHour = New System.Windows.Forms.Label()
        Me.PnlBody = New System.Windows.Forms.Panel()
        Me.lblNameEmpresa = New System.Windows.Forms.Label()
        Me.picLogo = New System.Windows.Forms.PictureBox()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.LblName = New System.Windows.Forms.Label()
        Me.PnlGaleria = New System.Windows.Forms.Panel()
        Me.btAccesoDirecto = New System.Windows.Forms.Button()
        Me.PnlAction_Buttons = New System.Windows.Forms.Panel()
        Me.BtImg_Next = New System.Windows.Forms.Button()
        Me.BtImg_Previous = New System.Windows.Forms.Button()
        Me.BtCancell = New System.Windows.Forms.Button()
        Me.TmHour = New System.Windows.Forms.Timer(Me.components)
        Me.SplitContainer.Panel1.SuspendLayout()
        Me.SplitContainer.Panel2.SuspendLayout()
        Me.SplitContainer.SuspendLayout()
        CType(Me.m_logo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PnlButton_Shell.SuspendLayout()
        Me.PnlLastTicket.SuspendLayout()
        CType(Me.PicImg, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PnlBody.SuspendLayout()
        CType(Me.picLogo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.PnlGaleria.SuspendLayout()
        Me.PnlAction_Buttons.SuspendLayout()
        Me.SuspendLayout()
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
        Me.SplitContainer.Panel2.Controls.Add(Me.PnlLastTicket)
        Me.SplitContainer.Panel2.Controls.Add(Me.LblHour)
        Me.SplitContainer.Panel2.Controls.Add(Me.PnlBody)
        Me.SplitContainer.Panel2.Tag = "233; 248; 250"
        Me.SplitContainer.Size = New System.Drawing.Size(1002, 762)
        Me.SplitContainer.SplitterDistance = 64
        Me.SplitContainer.SplitterWidth = 1
        Me.SplitContainer.TabIndex = 43
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
        Me.PnlButton_Shell.Controls.Add(Me.BtLogout)
        Me.PnlButton_Shell.Controls.Add(Me.BtAcceso)
        Me.PnlButton_Shell.Controls.Add(Me.BtClose)
        Me.PnlButton_Shell.Dock = System.Windows.Forms.DockStyle.Right
        Me.PnlButton_Shell.Location = New System.Drawing.Point(484, 0)
        Me.PnlButton_Shell.Name = "PnlButton_Shell"
        Me.PnlButton_Shell.Size = New System.Drawing.Size(518, 64)
        Me.PnlButton_Shell.TabIndex = 2
        '
        'BtLogout
        '
        Me.BtLogout.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.BtLogout.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtLogout.Image = CType(resources.GetObject("BtLogout.Image"), System.Drawing.Image)
        Me.BtLogout.Location = New System.Drawing.Point(-8, 5)
        Me.BtLogout.Name = "BtLogout"
        Me.BtLogout.Size = New System.Drawing.Size(166, 58)
        Me.BtLogout.TabIndex = 9
        Me.BtLogout.Tag = "Deslogue"
        Me.BtLogout.Text = "  Cerrar Sesión"
        Me.BtLogout.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BtLogout.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.BtLogout.UseVisualStyleBackColor = True
        '
        'BtAcceso
        '
        Me.BtAcceso.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.BtAcceso.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtAcceso.Image = CType(resources.GetObject("BtAcceso.Image"), System.Drawing.Image)
        Me.BtAcceso.Location = New System.Drawing.Point(164, 4)
        Me.BtAcceso.Name = "BtAcceso"
        Me.BtAcceso.Size = New System.Drawing.Size(166, 58)
        Me.BtAcceso.TabIndex = 8
        Me.BtAcceso.Tag = "Logueo"
        Me.BtAcceso.Text = "  Acceso"
        Me.BtAcceso.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BtAcceso.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.BtAcceso.UseVisualStyleBackColor = True
        '
        'BtClose
        '
        Me.BtClose.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.BtClose.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtClose.Image = CType(resources.GetObject("BtClose.Image"), System.Drawing.Image)
        Me.BtClose.Location = New System.Drawing.Point(336, 4)
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
        Me.LblSubTitle.Text = "Seleccione el empleado desde el que va a iniciar la venta o active uno"
        '
        'LblTitle
        '
        Me.LblTitle.AutoSize = True
        Me.LblTitle.Font = New System.Drawing.Font("Tahoma", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblTitle.Location = New System.Drawing.Point(57, 4)
        Me.LblTitle.Name = "LblTitle"
        Me.LblTitle.Size = New System.Drawing.Size(229, 23)
        Me.LblTitle.TabIndex = 0
        Me.LblTitle.Text = "Selección de Empleado"
        '
        'PnlLastTicket
        '
        Me.PnlLastTicket.BackColor = System.Drawing.Color.Black
        Me.PnlLastTicket.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.PnlLastTicket.Controls.Add(Me.PicImg)
        Me.PnlLastTicket.Controls.Add(Me.Label7)
        Me.PnlLastTicket.Controls.Add(Me.LblLastEmpleado)
        Me.PnlLastTicket.Controls.Add(Me.Label5)
        Me.PnlLastTicket.Controls.Add(Me.LblLastPVP)
        Me.PnlLastTicket.ForeColor = System.Drawing.Color.Black
        Me.PnlLastTicket.Location = New System.Drawing.Point(12, 128)
        Me.PnlLastTicket.Name = "PnlLastTicket"
        Me.PnlLastTicket.Size = New System.Drawing.Size(143, 219)
        Me.PnlLastTicket.TabIndex = 35
        Me.PnlLastTicket.Visible = False
        '
        'PicImg
        '
        Me.PicImg.BackColor = System.Drawing.Color.White
        Me.PicImg.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.PicImg.Location = New System.Drawing.Point(14, 86)
        Me.PicImg.Name = "PicImg"
        Me.PicImg.Size = New System.Drawing.Size(112, 109)
        Me.PicImg.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage
        Me.PicImg.TabIndex = 19
        Me.PicImg.TabStop = False
        Me.PicImg.Tag = "img"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Tahoma", 6.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.DimGray
        Me.Label7.Location = New System.Drawing.Point(9, 58)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(43, 10)
        Me.Label7.TabIndex = 45
        Me.Label7.Text = "EMPLEADO"
        '
        'LblLastEmpleado
        '
        Me.LblLastEmpleado.AutoSize = True
        Me.LblLastEmpleado.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblLastEmpleado.ForeColor = System.Drawing.Color.DimGray
        Me.LblLastEmpleado.Location = New System.Drawing.Point(5, 66)
        Me.LblLastEmpleado.Name = "LblLastEmpleado"
        Me.LblLastEmpleado.Size = New System.Drawing.Size(66, 13)
        Me.LblLastEmpleado.TabIndex = 44
        Me.LblLastEmpleado.Text = "EMPLEADO"
        '
        'Label5
        '
        Me.Label5.BackColor = System.Drawing.Color.Gray
        Me.Label5.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label5.Font = New System.Drawing.Font("Tahoma", 6.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(0, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(139, 13)
        Me.Label5.TabIndex = 40
        Me.Label5.Text = "ÚLTIMO TICKET"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'LblLastPVP
        '
        Me.LblLastPVP.BackColor = System.Drawing.Color.Silver
        Me.LblLastPVP.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LblLastPVP.Font = New System.Drawing.Font("Tahoma", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblLastPVP.ForeColor = System.Drawing.Color.DimGray
        Me.LblLastPVP.Location = New System.Drawing.Point(2, 15)
        Me.LblLastPVP.Name = "LblLastPVP"
        Me.LblLastPVP.Size = New System.Drawing.Size(135, 39)
        Me.LblLastPVP.TabIndex = 41
        Me.LblLastPVP.Text = "0,00 €"
        Me.LblLastPVP.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
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
        'PnlBody
        '
        Me.PnlBody.BackColor = System.Drawing.SystemColors.Control
        Me.PnlBody.BackgroundImage = CType(resources.GetObject("PnlBody.BackgroundImage"), System.Drawing.Image)
        Me.PnlBody.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.PnlBody.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PnlBody.Controls.Add(Me.lblNameEmpresa)
        Me.PnlBody.Controls.Add(Me.picLogo)
        Me.PnlBody.Controls.Add(Me.Panel1)
        Me.PnlBody.ForeColor = System.Drawing.Color.Black
        Me.PnlBody.Location = New System.Drawing.Point(130, -1)
        Me.PnlBody.Name = "PnlBody"
        Me.PnlBody.Size = New System.Drawing.Size(668, 690)
        Me.PnlBody.TabIndex = 0
        Me.PnlBody.Visible = False
        '
        'lblNameEmpresa
        '
        Me.lblNameEmpresa.BackColor = System.Drawing.Color.White
        Me.lblNameEmpresa.Font = New System.Drawing.Font("Tahoma", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNameEmpresa.Location = New System.Drawing.Point(108, 9)
        Me.lblNameEmpresa.Name = "lblNameEmpresa"
        Me.lblNameEmpresa.Size = New System.Drawing.Size(456, 23)
        Me.lblNameEmpresa.TabIndex = 3
        Me.lblNameEmpresa.Text = "Label1"
        Me.lblNameEmpresa.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'picLogo
        '
        Me.picLogo.BackColor = System.Drawing.Color.White
        Me.picLogo.Image = CType(resources.GetObject("picLogo.Image"), System.Drawing.Image)
        Me.picLogo.Location = New System.Drawing.Point(53, 44)
        Me.picLogo.Name = "picLogo"
        Me.picLogo.Size = New System.Drawing.Size(561, 162)
        Me.picLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.picLogo.TabIndex = 2
        Me.picLogo.TabStop = False
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.Transparent
        Me.Panel1.Controls.Add(Me.LblName)
        Me.Panel1.Controls.Add(Me.PnlGaleria)
        Me.Panel1.Controls.Add(Me.PnlAction_Buttons)
        Me.Panel1.Location = New System.Drawing.Point(13, 245)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(641, 421)
        Me.Panel1.TabIndex = 1
        '
        'LblName
        '
        Me.LblName.BackColor = System.Drawing.Color.Transparent
        Me.LblName.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblName.Location = New System.Drawing.Point(50, 37)
        Me.LblName.Name = "LblName"
        Me.LblName.Size = New System.Drawing.Size(291, 23)
        Me.LblName.TabIndex = 43
        Me.LblName.Text = "Seleccione el empleado"
        '
        'PnlGaleria
        '
        Me.PnlGaleria.BackColor = System.Drawing.Color.Transparent
        Me.PnlGaleria.Controls.Add(Me.btAccesoDirecto)
        Me.PnlGaleria.Location = New System.Drawing.Point(40, 74)
        Me.PnlGaleria.Name = "PnlGaleria"
        Me.PnlGaleria.Size = New System.Drawing.Size(561, 327)
        Me.PnlGaleria.TabIndex = 42
        '
        'btAccesoDirecto
        '
        Me.btAccesoDirecto.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btAccesoDirecto.Font = New System.Drawing.Font("Verdana", 48.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btAccesoDirecto.Image = CType(resources.GetObject("btAccesoDirecto.Image"), System.Drawing.Image)
        Me.btAccesoDirecto.ImageAlign = System.Drawing.ContentAlignment.TopLeft
        Me.btAccesoDirecto.Location = New System.Drawing.Point(10, 55)
        Me.btAccesoDirecto.Name = "btAccesoDirecto"
        Me.btAccesoDirecto.Size = New System.Drawing.Size(537, 151)
        Me.btAccesoDirecto.TabIndex = 9
        Me.btAccesoDirecto.Tag = "Logueo"
        Me.btAccesoDirecto.Text = "Acceso"
        Me.btAccesoDirecto.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btAccesoDirecto.UseVisualStyleBackColor = True
        '
        'PnlAction_Buttons
        '
        Me.PnlAction_Buttons.BackColor = System.Drawing.Color.Transparent
        Me.PnlAction_Buttons.Controls.Add(Me.BtImg_Next)
        Me.PnlAction_Buttons.Controls.Add(Me.BtImg_Previous)
        Me.PnlAction_Buttons.Controls.Add(Me.BtCancell)
        Me.PnlAction_Buttons.Location = New System.Drawing.Point(391, 26)
        Me.PnlAction_Buttons.Name = "PnlAction_Buttons"
        Me.PnlAction_Buttons.Size = New System.Drawing.Size(206, 50)
        Me.PnlAction_Buttons.TabIndex = 3
        Me.PnlAction_Buttons.Tag = "NO_SCAN"
        Me.PnlAction_Buttons.Visible = False
        '
        'BtImg_Next
        '
        Me.BtImg_Next.BackColor = System.Drawing.SystemColors.Control
        Me.BtImg_Next.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtImg_Next.Image = CType(resources.GetObject("BtImg_Next.Image"), System.Drawing.Image)
        Me.BtImg_Next.Location = New System.Drawing.Point(68, 5)
        Me.BtImg_Next.Name = "BtImg_Next"
        Me.BtImg_Next.Size = New System.Drawing.Size(60, 41)
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
        Me.BtImg_Previous.Location = New System.Drawing.Point(4, 5)
        Me.BtImg_Previous.Name = "BtImg_Previous"
        Me.BtImg_Previous.Size = New System.Drawing.Size(60, 41)
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
        Me.BtCancell.Location = New System.Drawing.Point(140, 5)
        Me.BtCancell.Name = "BtCancell"
        Me.BtCancell.Size = New System.Drawing.Size(60, 41)
        Me.BtCancell.TabIndex = 0
        Me.BtCancell.Tag = "cancell"
        Me.BtCancell.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.BtCancell.UseVisualStyleBackColor = False
        '
        'TmHour
        '
        Me.TmHour.Interval = 30000
        '
        'frmSelect_Empleado
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Black
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.CancelButton = Me.BtCancell
        Me.ClientSize = New System.Drawing.Size(1002, 762)
        Me.Controls.Add(Me.SplitContainer)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmSelect_Empleado"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Selección de camarero"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.SplitContainer.Panel1.ResumeLayout(False)
        Me.SplitContainer.Panel1.PerformLayout()
        Me.SplitContainer.Panel2.ResumeLayout(False)
        Me.SplitContainer.ResumeLayout(False)
        CType(Me.m_logo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PnlButton_Shell.ResumeLayout(False)
        Me.PnlLastTicket.ResumeLayout(False)
        Me.PnlLastTicket.PerformLayout()
        CType(Me.PicImg, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PnlBody.ResumeLayout(False)
        CType(Me.picLogo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.PnlGaleria.ResumeLayout(False)
        Me.PnlAction_Buttons.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents PnlAction_Buttons As System.Windows.Forms.Panel
    Friend WithEvents BtImg_Next As System.Windows.Forms.Button
    Friend WithEvents BtImg_Previous As System.Windows.Forms.Button
    Friend WithEvents PnlGaleria As System.Windows.Forms.Panel
    Friend WithEvents SplitContainer As System.Windows.Forms.SplitContainer
    Friend WithEvents LblHour As System.Windows.Forms.Label
    Friend WithEvents m_logo As System.Windows.Forms.PictureBox
    Friend WithEvents PnlButton_Shell As System.Windows.Forms.Panel
    Friend WithEvents BtClose As System.Windows.Forms.Button
    Friend WithEvents LblSubTitle As System.Windows.Forms.Label
    Friend WithEvents LblTitle As System.Windows.Forms.Label
    Friend WithEvents PnlBody As System.Windows.Forms.Panel
    Friend WithEvents BtCancell As System.Windows.Forms.Button
    Friend WithEvents TmHour As System.Windows.Forms.Timer
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents picLogo As System.Windows.Forms.PictureBox
    Friend WithEvents LblName As System.Windows.Forms.Label
    Friend WithEvents lblNameEmpresa As System.Windows.Forms.Label
    Friend WithEvents BtAcceso As System.Windows.Forms.Button
    Friend WithEvents btAccesoDirecto As System.Windows.Forms.Button
    Friend WithEvents BtLogout As System.Windows.Forms.Button
    Friend WithEvents PnlLastTicket As System.Windows.Forms.Panel
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents LblLastEmpleado As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents LblLastPVP As System.Windows.Forms.Label
    Friend WithEvents PicImg As System.Windows.Forms.PictureBox
End Class
