<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmNoteBook
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
        Dim MenuStrip As System.Windows.Forms.MenuStrip
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmNoteBook))
        Dim ToolStripMenuItem2 As System.Windows.Forms.ToolStripSeparator
        Dim ToolStripSeparator7 As System.Windows.Forms.ToolStripSeparator
        Dim ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
        Dim ToolStripSeparator4 As System.Windows.Forms.ToolStripSeparator
        Dim ToolStripSeparator8 As System.Windows.Forms.ToolStripSeparator
        Dim ToolStrip As System.Windows.Forms.ToolStrip
        Dim ToolStripLabel_Trash As System.Windows.Forms.ToolStripLabel
        Dim ToolStripSeparator5 As System.Windows.Forms.ToolStripSeparator
        Me.MnArchivo = New System.Windows.Forms.ToolStripMenuItem
        Me.BtMnEventos = New System.Windows.Forms.ToolStripMenuItem
        Me.BtMnVentas = New System.Windows.Forms.ToolStripMenuItem
        Me.BtMnSalir = New System.Windows.Forms.ToolStripMenuItem
        Me.AcercaDeToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripMenu_Register = New System.Windows.Forms.ToolStripMenuItem
        Me.BtMnCondiciones = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripMenu_About = New System.Windows.Forms.ToolStripMenuItem
        Me.ManualDeAyudaDeUsuarioToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripButton_Close = New System.Windows.Forms.ToolStripButton
        Me.ToolStripButton_Help = New System.Windows.Forms.ToolStripButton
        Me.LblDetalles = New System.Windows.Forms.ToolStripLabel
        Me.ToolStrip_Reservas = New System.Windows.Forms.ToolStripButton
        Me.ToolStrip_Sidebar = New System.Windows.Forms.ToolStrip
        Me.PicSabor = New System.Windows.Forms.ToolStripLabel
        Me.BtVentas = New System.Windows.Forms.ToolStripButton
        Me.BtReservas = New System.Windows.Forms.ToolStripButton
        Me.PicLogo = New System.Windows.Forms.ToolStripLabel
        Me.BtEmpresa = New System.Windows.Forms.ToolStripButton
        MenuStrip = New System.Windows.Forms.MenuStrip
        ToolStripMenuItem2 = New System.Windows.Forms.ToolStripSeparator
        ToolStripSeparator7 = New System.Windows.Forms.ToolStripSeparator
        ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator
        ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator
        ToolStripSeparator8 = New System.Windows.Forms.ToolStripSeparator
        ToolStrip = New System.Windows.Forms.ToolStrip
        ToolStripLabel_Trash = New System.Windows.Forms.ToolStripLabel
        ToolStripSeparator5 = New System.Windows.Forms.ToolStripSeparator
        MenuStrip.SuspendLayout()
        ToolStrip.SuspendLayout()
        Me.ToolStrip_Sidebar.SuspendLayout()
        Me.SuspendLayout()
        '
        'MenuStrip
        '
        MenuStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MnArchivo, Me.AcercaDeToolStripMenuItem})
        MenuStrip.Location = New System.Drawing.Point(0, 0)
        MenuStrip.Name = "MenuStrip"
        MenuStrip.Size = New System.Drawing.Size(792, 24)
        MenuStrip.TabIndex = 2
        MenuStrip.Text = "MenuStrip1"
        '
        'MnArchivo
        '
        Me.MnArchivo.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BtMnEventos, Me.BtMnVentas, ToolStripMenuItem2, Me.BtMnSalir})
        Me.MnArchivo.Image = CType(resources.GetObject("MnArchivo.Image"), System.Drawing.Image)
        Me.MnArchivo.Name = "MnArchivo"
        Me.MnArchivo.Size = New System.Drawing.Size(71, 20)
        Me.MnArchivo.Text = "Archivo"
        '
        'BtMnEventos
        '
        Me.BtMnEventos.Image = CType(resources.GetObject("BtMnEventos.Image"), System.Drawing.Image)
        Me.BtMnEventos.Name = "BtMnEventos"
        Me.BtMnEventos.Size = New System.Drawing.Size(165, 22)
        Me.BtMnEventos.Text = "Agenda/Eventos"
        '
        'BtMnVentas
        '
        Me.BtMnVentas.Image = CType(resources.GetObject("BtMnVentas.Image"), System.Drawing.Image)
        Me.BtMnVentas.Name = "BtMnVentas"
        Me.BtMnVentas.Size = New System.Drawing.Size(165, 22)
        Me.BtMnVentas.Text = "Ventas"
        '
        'ToolStripMenuItem2
        '
        ToolStripMenuItem2.Name = "ToolStripMenuItem2"
        ToolStripMenuItem2.Size = New System.Drawing.Size(162, 6)
        '
        'BtMnSalir
        '
        Me.BtMnSalir.Image = CType(resources.GetObject("BtMnSalir.Image"), System.Drawing.Image)
        Me.BtMnSalir.Name = "BtMnSalir"
        Me.BtMnSalir.ShortcutKeys = CType((System.Windows.Forms.Keys.Alt Or System.Windows.Forms.Keys.F4), System.Windows.Forms.Keys)
        Me.BtMnSalir.Size = New System.Drawing.Size(165, 22)
        Me.BtMnSalir.Text = "Salir"
        '
        'AcercaDeToolStripMenuItem
        '
        Me.AcercaDeToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripMenu_Register, ToolStripSeparator7, Me.BtMnCondiciones, ToolStripSeparator3, Me.ToolStripMenu_About, Me.ManualDeAyudaDeUsuarioToolStripMenuItem})
        Me.AcercaDeToolStripMenuItem.Image = CType(resources.GetObject("AcercaDeToolStripMenuItem.Image"), System.Drawing.Image)
        Me.AcercaDeToolStripMenuItem.Name = "AcercaDeToolStripMenuItem"
        Me.AcercaDeToolStripMenuItem.Size = New System.Drawing.Size(92, 20)
        Me.AcercaDeToolStripMenuItem.Text = "Información"
        '
        'ToolStripMenu_Register
        '
        Me.ToolStripMenu_Register.Image = CType(resources.GetObject("ToolStripMenu_Register.Image"), System.Drawing.Image)
        Me.ToolStripMenu_Register.Name = "ToolStripMenu_Register"
        Me.ToolStripMenu_Register.Size = New System.Drawing.Size(183, 22)
        Me.ToolStripMenu_Register.Text = "Código de Aplicación"
        '
        'ToolStripSeparator7
        '
        ToolStripSeparator7.Name = "ToolStripSeparator7"
        ToolStripSeparator7.Size = New System.Drawing.Size(180, 6)
        ToolStripSeparator7.Visible = False
        '
        'BtMnCondiciones
        '
        Me.BtMnCondiciones.Image = CType(resources.GetObject("BtMnCondiciones.Image"), System.Drawing.Image)
        Me.BtMnCondiciones.Name = "BtMnCondiciones"
        Me.BtMnCondiciones.Size = New System.Drawing.Size(183, 22)
        Me.BtMnCondiciones.Text = "Condiciones de Uso"
        Me.BtMnCondiciones.Visible = False
        '
        'ToolStripSeparator3
        '
        ToolStripSeparator3.Name = "ToolStripSeparator3"
        ToolStripSeparator3.Size = New System.Drawing.Size(180, 6)
        ToolStripSeparator3.Visible = False
        '
        'ToolStripMenu_About
        '
        Me.ToolStripMenu_About.Image = CType(resources.GetObject("ToolStripMenu_About.Image"), System.Drawing.Image)
        Me.ToolStripMenu_About.Name = "ToolStripMenu_About"
        Me.ToolStripMenu_About.Size = New System.Drawing.Size(183, 22)
        Me.ToolStripMenu_About.Text = "Acerca de..."
        Me.ToolStripMenu_About.Visible = False
        '
        'ManualDeAyudaDeUsuarioToolStripMenuItem
        '
        Me.ManualDeAyudaDeUsuarioToolStripMenuItem.Image = CType(resources.GetObject("ManualDeAyudaDeUsuarioToolStripMenuItem.Image"), System.Drawing.Image)
        Me.ManualDeAyudaDeUsuarioToolStripMenuItem.Name = "ManualDeAyudaDeUsuarioToolStripMenuItem"
        Me.ManualDeAyudaDeUsuarioToolStripMenuItem.Size = New System.Drawing.Size(183, 22)
        Me.ManualDeAyudaDeUsuarioToolStripMenuItem.Text = "Ayuda al usuario"
        Me.ManualDeAyudaDeUsuarioToolStripMenuItem.Visible = False
        '
        'ToolStripSeparator4
        '
        ToolStripSeparator4.Margin = New System.Windows.Forms.Padding(0, 0, 0, 3)
        ToolStripSeparator4.Name = "ToolStripSeparator4"
        ToolStripSeparator4.Size = New System.Drawing.Size(171, 6)
        '
        'ToolStripSeparator8
        '
        ToolStripSeparator8.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        ToolStripSeparator8.Name = "ToolStripSeparator8"
        ToolStripSeparator8.Size = New System.Drawing.Size(171, 6)
        '
        'ToolStrip
        '
        ToolStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        ToolStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripButton_Close, Me.ToolStripButton_Help, ToolStripLabel_Trash, Me.LblDetalles, ToolStripSeparator5, Me.ToolStrip_Reservas})
        ToolStrip.Location = New System.Drawing.Point(173, 24)
        ToolStrip.Name = "ToolStrip"
        ToolStrip.Size = New System.Drawing.Size(619, 25)
        ToolStrip.TabIndex = 19
        ToolStrip.Text = "ToolStrip1"
        '
        'ToolStripButton_Close
        '
        Me.ToolStripButton_Close.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.ToolStripButton_Close.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton_Close.Enabled = False
        Me.ToolStripButton_Close.Image = CType(resources.GetObject("ToolStripButton_Close.Image"), System.Drawing.Image)
        Me.ToolStripButton_Close.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton_Close.Name = "ToolStripButton_Close"
        Me.ToolStripButton_Close.Size = New System.Drawing.Size(23, 22)
        Me.ToolStripButton_Close.Text = "Cerrar Formulario"
        '
        'ToolStripButton_Help
        '
        Me.ToolStripButton_Help.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.ToolStripButton_Help.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton_Help.Image = CType(resources.GetObject("ToolStripButton_Help.Image"), System.Drawing.Image)
        Me.ToolStripButton_Help.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton_Help.Margin = New System.Windows.Forms.Padding(0, 1, 3, 2)
        Me.ToolStripButton_Help.Name = "ToolStripButton_Help"
        Me.ToolStripButton_Help.Size = New System.Drawing.Size(23, 22)
        Me.ToolStripButton_Help.Text = "Ayuda"
        Me.ToolStripButton_Help.Visible = False
        '
        'ToolStripLabel_Trash
        '
        ToolStripLabel_Trash.AutoSize = False
        ToolStripLabel_Trash.Name = "ToolStripLabel_Trash"
        ToolStripLabel_Trash.Size = New System.Drawing.Size(7, 22)
        '
        'LblDetalles
        '
        Me.LblDetalles.AutoSize = False
        Me.LblDetalles.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblDetalles.Name = "LblDetalles"
        Me.LblDetalles.Size = New System.Drawing.Size(115, 22)
        Me.LblDetalles.Text = "gTPV"
        Me.LblDetalles.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'ToolStripSeparator5
        '
        ToolStripSeparator5.Name = "ToolStripSeparator5"
        ToolStripSeparator5.Size = New System.Drawing.Size(6, 25)
        '
        'ToolStrip_Reservas
        '
        Me.ToolStrip_Reservas.Image = CType(resources.GetObject("ToolStrip_Reservas.Image"), System.Drawing.Image)
        Me.ToolStrip_Reservas.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStrip_Reservas.Name = "ToolStrip_Reservas"
        Me.ToolStrip_Reservas.Size = New System.Drawing.Size(101, 22)
        Me.ToolStrip_Reservas.Tag = "reservas"
        Me.ToolStrip_Reservas.Text = "Nueva Reserva"
        '
        'ToolStrip_Sidebar
        '
        Me.ToolStrip_Sidebar.AutoSize = False
        Me.ToolStrip_Sidebar.CanOverflow = False
        Me.ToolStrip_Sidebar.Dock = System.Windows.Forms.DockStyle.Left
        Me.ToolStrip_Sidebar.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.ToolStrip_Sidebar.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.PicSabor, ToolStripSeparator4, Me.BtVentas, Me.BtReservas, Me.PicLogo, ToolStripSeparator8, Me.BtEmpresa})
        Me.ToolStrip_Sidebar.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.VerticalStackWithOverflow
        Me.ToolStrip_Sidebar.Location = New System.Drawing.Point(0, 24)
        Me.ToolStrip_Sidebar.Name = "ToolStrip_Sidebar"
        Me.ToolStrip_Sidebar.Size = New System.Drawing.Size(173, 492)
        Me.ToolStrip_Sidebar.TabIndex = 17
        '
        'PicSabor
        '
        Me.PicSabor.AutoSize = False
        Me.PicSabor.Image = CType(resources.GetObject("PicSabor.Image"), System.Drawing.Image)
        Me.PicSabor.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.PicSabor.IsLink = True
        Me.PicSabor.Margin = New System.Windows.Forms.Padding(3)
        Me.PicSabor.Name = "PicSabor"
        Me.PicSabor.Size = New System.Drawing.Size(162, 50)
        Me.PicSabor.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.PicSabor.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage
        Me.PicSabor.ToolTipText = "Tu sabor... Disfrutalo!!!"
        '
        'BtVentas
        '
        Me.BtVentas.AutoSize = False
        Me.BtVentas.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtVentas.Image = CType(resources.GetObject("BtVentas.Image"), System.Drawing.Image)
        Me.BtVentas.ImageAlign = System.Drawing.ContentAlignment.TopLeft
        Me.BtVentas.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.BtVentas.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BtVentas.Margin = New System.Windows.Forms.Padding(0, -3, 0, 2)
        Me.BtVentas.Name = "BtVentas"
        Me.BtVentas.Size = New System.Drawing.Size(159, 54)
        Me.BtVentas.Tag = "0"
        Me.BtVentas.Text = " gTPV"
        Me.BtVentas.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'BtReservas
        '
        Me.BtReservas.AutoSize = False
        Me.BtReservas.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtReservas.Image = CType(resources.GetObject("BtReservas.Image"), System.Drawing.Image)
        Me.BtReservas.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtReservas.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.BtReservas.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BtReservas.Name = "BtReservas"
        Me.BtReservas.Size = New System.Drawing.Size(159, 40)
        Me.BtReservas.Tag = "0"
        Me.BtReservas.Text = "Agenda/Reservas"
        '
        'PicLogo
        '
        Me.PicLogo.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.PicLogo.AutoSize = False
        Me.PicLogo.Image = CType(resources.GetObject("PicLogo.Image"), System.Drawing.Image)
        Me.PicLogo.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.PicLogo.IsLink = True
        Me.PicLogo.Margin = New System.Windows.Forms.Padding(3)
        Me.PicLogo.Name = "PicLogo"
        Me.PicLogo.Size = New System.Drawing.Size(162, 50)
        Me.PicLogo.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.PicLogo.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage
        Me.PicLogo.ToolTipText = "Making it Simple! Keeping it Simple!!" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Doble click para ir a software.gdevelop." & _
            "es"
        '
        'BtEmpresa
        '
        Me.BtEmpresa.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.BtEmpresa.AutoSize = False
        Me.BtEmpresa.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtEmpresa.Image = CType(resources.GetObject("BtEmpresa.Image"), System.Drawing.Image)
        Me.BtEmpresa.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtEmpresa.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.BtEmpresa.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BtEmpresa.Name = "BtEmpresa"
        Me.BtEmpresa.Size = New System.Drawing.Size(159, 64)
        Me.BtEmpresa.Tag = "0"
        Me.BtEmpresa.Text = "Configuración"
        Me.BtEmpresa.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BtEmpresa.TextImageRelation = System.Windows.Forms.TextImageRelation.Overlay
        '
        'frmNoteBook
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(792, 516)
        Me.Controls.Add(ToolStrip)
        Me.Controls.Add(Me.ToolStrip_Sidebar)
        Me.Controls.Add(MenuStrip)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.IsMdiContainer = True
        Me.MaximizeBox = False
        Me.Name = "frmNoteBook"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "gTPV - Módulo para NoteBook"
        MenuStrip.ResumeLayout(False)
        MenuStrip.PerformLayout()
        ToolStrip.ResumeLayout(False)
        ToolStrip.PerformLayout()
        Me.ToolStrip_Sidebar.ResumeLayout(False)
        Me.ToolStrip_Sidebar.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents MnArchivo As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents BtMnVentas As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents BtMnSalir As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AcercaDeToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenu_Register As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents BtMnCondiciones As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenu_About As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ManualDeAyudaDeUsuarioToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents BtMnEventos As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStrip_Sidebar As System.Windows.Forms.ToolStrip
    Friend WithEvents PicSabor As System.Windows.Forms.ToolStripLabel
    Friend WithEvents BtVentas As System.Windows.Forms.ToolStripButton
    Friend WithEvents BtReservas As System.Windows.Forms.ToolStripButton
    Friend WithEvents PicLogo As System.Windows.Forms.ToolStripLabel
    Friend WithEvents ToolStripButton_Close As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripButton_Help As System.Windows.Forms.ToolStripButton
    Friend WithEvents LblDetalles As System.Windows.Forms.ToolStripLabel
    Friend WithEvents ToolStrip_Reservas As System.Windows.Forms.ToolStripButton
    Friend WithEvents BtEmpresa As System.Windows.Forms.ToolStripButton
End Class
