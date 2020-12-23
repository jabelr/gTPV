<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmReservas_Evento
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
        Dim Label2 As System.Windows.Forms.Label
        Dim Label4 As System.Windows.Forms.Label
        Dim Label3 As System.Windows.Forms.Label
        Dim Label5 As System.Windows.Forms.Label
        Dim Label6 As System.Windows.Forms.Label
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmReservas_Evento))
        Me.LblName = New System.Windows.Forms.Label()
        Me.PnlReservas = New System.Windows.Forms.Panel()
        Me.txtIDUsuario = New System.Windows.Forms.TextBox()
        Me.LblFh_Alta = New System.Windows.Forms.Label()
        Me.LblFh_Alta_nfo = New System.Windows.Forms.Label()
        Me.MaskedTextBox1 = New System.Windows.Forms.MaskedTextBox()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.DtFhReserva = New System.Windows.Forms.DateTimePicker()
        Me.TxtAbout = New System.Windows.Forms.TextBox()
        Me.TxtName = New System.Windows.Forms.TextBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.BtN_Down = New System.Windows.Forms.Button()
        Me.BtN_Up = New System.Windows.Forms.Button()
        Me.BtNew = New System.Windows.Forms.Button()
        Me.BtDell = New System.Windows.Forms.Button()
        Me.LstMenu = New System.Windows.Forms.ListView()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.btOKPrint = New System.Windows.Forms.Button()
        Me.BtCancell = New System.Windows.Forms.Button()
        Me.BtOk = New System.Windows.Forms.Button()
        Me.BtKeyBoard = New System.Windows.Forms.Button()
        Me.LblFhEvento = New System.Windows.Forms.Label()
        Label1 = New System.Windows.Forms.Label()
        Label2 = New System.Windows.Forms.Label()
        Label4 = New System.Windows.Forms.Label()
        Label3 = New System.Windows.Forms.Label()
        Label5 = New System.Windows.Forms.Label()
        Label6 = New System.Windows.Forms.Label()
        Me.PnlReservas.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label1
        '
        Label1.AutoSize = True
        Label1.BackColor = System.Drawing.Color.Transparent
        Label1.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Label1.Location = New System.Drawing.Point(45, 76)
        Label1.Name = "Label1"
        Label1.Size = New System.Drawing.Size(52, 18)
        Label1.TabIndex = 40
        Label1.Text = "Fecha:"
        '
        'Label2
        '
        Label2.AutoSize = True
        Label2.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Label2.Location = New System.Drawing.Point(7, 15)
        Label2.Name = "Label2"
        Label2.Size = New System.Drawing.Size(60, 18)
        Label2.TabIndex = 2
        Label2.Text = "Persona"
        '
        'Label4
        '
        Label4.AutoSize = True
        Label4.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Label4.Location = New System.Drawing.Point(356, 60)
        Label4.Name = "Label4"
        Label4.Size = New System.Drawing.Size(95, 18)
        Label4.TabIndex = 5
        Label4.Text = "Hora Prevista"
        '
        'Label3
        '
        Label3.AutoSize = True
        Label3.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Label3.Location = New System.Drawing.Point(4, 98)
        Label3.Name = "Label3"
        Label3.Size = New System.Drawing.Size(136, 18)
        Label3.TabIndex = 4
        Label3.Text = "Descripción/Detalles"
        '
        'Label5
        '
        Label5.AutoSize = True
        Label5.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Label5.Location = New System.Drawing.Point(7, 60)
        Label5.Name = "Label5"
        Label5.Size = New System.Drawing.Size(52, 18)
        Label5.TabIndex = 10
        Label5.Text = "Fecha "
        '
        'Label6
        '
        Label6.AutoSize = True
        Label6.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Label6.Location = New System.Drawing.Point(356, 15)
        Label6.Name = "Label6"
        Label6.Size = New System.Drawing.Size(65, 18)
        Label6.TabIndex = 11
        Label6.Text = "Teléfono"
        '
        'LblName
        '
        Me.LblName.BackColor = System.Drawing.Color.Transparent
        Me.LblName.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblName.Location = New System.Drawing.Point(47, 38)
        Me.LblName.Name = "LblName"
        Me.LblName.Size = New System.Drawing.Size(291, 23)
        Me.LblName.TabIndex = 34
        Me.LblName.Text = "Eventos"
        '
        'PnlReservas
        '
        Me.PnlReservas.BackColor = System.Drawing.Color.FromArgb(CType(CType(174, Byte), Integer), CType(CType(186, Byte), Integer), CType(CType(186, Byte), Integer))
        Me.PnlReservas.Controls.Add(Me.txtIDUsuario)
        Me.PnlReservas.Controls.Add(Me.LblFh_Alta)
        Me.PnlReservas.Controls.Add(Me.LblFh_Alta_nfo)
        Me.PnlReservas.Controls.Add(Me.MaskedTextBox1)
        Me.PnlReservas.Controls.Add(Me.TextBox1)
        Me.PnlReservas.Controls.Add(Label6)
        Me.PnlReservas.Controls.Add(Label5)
        Me.PnlReservas.Controls.Add(Me.DtFhReserva)
        Me.PnlReservas.Controls.Add(Label4)
        Me.PnlReservas.Controls.Add(Label3)
        Me.PnlReservas.Controls.Add(Me.TxtAbout)
        Me.PnlReservas.Controls.Add(Label2)
        Me.PnlReservas.Controls.Add(Me.TxtName)
        Me.PnlReservas.Location = New System.Drawing.Point(41, 100)
        Me.PnlReservas.Name = "PnlReservas"
        Me.PnlReservas.Size = New System.Drawing.Size(557, 289)
        Me.PnlReservas.TabIndex = 0
        '
        'txtIDUsuario
        '
        Me.txtIDUsuario.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtIDUsuario.Font = New System.Drawing.Font("Tahoma", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtIDUsuario.Location = New System.Drawing.Point(244, 15)
        Me.txtIDUsuario.MaxLength = 150
        Me.txtIDUsuario.Name = "txtIDUsuario"
        Me.txtIDUsuario.Size = New System.Drawing.Size(91, 33)
        Me.txtIDUsuario.TabIndex = 47
        Me.txtIDUsuario.Tag = "id_usuario"
        Me.txtIDUsuario.Text = "ID_USUARIO"
        Me.txtIDUsuario.Visible = False
        '
        'LblFh_Alta
        '
        Me.LblFh_Alta.BackColor = System.Drawing.Color.FromArgb(CType(CType(174, Byte), Integer), CType(CType(186, Byte), Integer), CType(CType(186, Byte), Integer))
        Me.LblFh_Alta.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblFh_Alta.Location = New System.Drawing.Point(365, 102)
        Me.LblFh_Alta.Name = "LblFh_Alta"
        Me.LblFh_Alta.Size = New System.Drawing.Size(179, 13)
        Me.LblFh_Alta.TabIndex = 46
        Me.LblFh_Alta.Tag = "fh_alta"
        Me.LblFh_Alta.Text = "00/00/0000"
        '
        'LblFh_Alta_nfo
        '
        Me.LblFh_Alta_nfo.AutoSize = True
        Me.LblFh_Alta_nfo.BackColor = System.Drawing.Color.FromArgb(CType(CType(174, Byte), Integer), CType(CType(186, Byte), Integer), CType(CType(186, Byte), Integer))
        Me.LblFh_Alta_nfo.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblFh_Alta_nfo.Location = New System.Drawing.Point(273, 102)
        Me.LblFh_Alta_nfo.Name = "LblFh_Alta_nfo"
        Me.LblFh_Alta_nfo.Size = New System.Drawing.Size(88, 13)
        Me.LblFh_Alta_nfo.TabIndex = 45
        Me.LblFh_Alta_nfo.Text = "Fecha de alta:"
        '
        'MaskedTextBox1
        '
        Me.MaskedTextBox1.Font = New System.Drawing.Font("Tahoma", 15.75!)
        Me.MaskedTextBox1.Location = New System.Drawing.Point(470, 51)
        Me.MaskedTextBox1.Mask = "00:00"
        Me.MaskedTextBox1.Name = "MaskedTextBox1"
        Me.MaskedTextBox1.Size = New System.Drawing.Size(80, 33)
        Me.MaskedTextBox1.TabIndex = 3
        Me.MaskedTextBox1.Tag = "hora"
        Me.MaskedTextBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.MaskedTextBox1.ValidatingType = GetType(Date)
        '
        'TextBox1
        '
        Me.TextBox1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TextBox1.Font = New System.Drawing.Font("Tahoma", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox1.Location = New System.Drawing.Point(429, 6)
        Me.TextBox1.MaxLength = 12
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(121, 33)
        Me.TextBox1.TabIndex = 1
        Me.TextBox1.Tag = "telefono"
        Me.TextBox1.Text = "000-000-000"
        '
        'DtFhReserva
        '
        Me.DtFhReserva.CalendarFont = New System.Drawing.Font("Tahoma", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DtFhReserva.CustomFormat = "dd-MMMM-yyyy"
        Me.DtFhReserva.Font = New System.Drawing.Font("Tahoma", 15.75!)
        Me.DtFhReserva.Location = New System.Drawing.Point(73, 51)
        Me.DtFhReserva.Name = "DtFhReserva"
        Me.DtFhReserva.Size = New System.Drawing.Size(270, 33)
        Me.DtFhReserva.TabIndex = 2
        Me.DtFhReserva.Tag = "fh_reserva"
        '
        'TxtAbout
        '
        Me.TxtAbout.Font = New System.Drawing.Font("Tahoma", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtAbout.Location = New System.Drawing.Point(35, 120)
        Me.TxtAbout.MaxLength = 0
        Me.TxtAbout.Multiline = True
        Me.TxtAbout.Name = "TxtAbout"
        Me.TxtAbout.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.TxtAbout.Size = New System.Drawing.Size(516, 166)
        Me.TxtAbout.TabIndex = 4
        Me.TxtAbout.Tag = "about"
        '
        'TxtName
        '
        Me.TxtName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtName.Font = New System.Drawing.Font("Tahoma", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtName.Location = New System.Drawing.Point(73, 6)
        Me.TxtName.MaxLength = 150
        Me.TxtName.Name = "TxtName"
        Me.TxtName.Size = New System.Drawing.Size(270, 33)
        Me.TxtName.TabIndex = 0
        Me.TxtName.Tag = "name"
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.FromArgb(CType(CType(174, Byte), Integer), CType(CType(186, Byte), Integer), CType(CType(186, Byte), Integer))
        Me.GroupBox1.Controls.Add(Me.BtN_Down)
        Me.GroupBox1.Controls.Add(Me.BtN_Up)
        Me.GroupBox1.Controls.Add(Me.BtNew)
        Me.GroupBox1.Controls.Add(Me.BtDell)
        Me.GroupBox1.Controls.Add(Me.LstMenu)
        Me.GroupBox1.Location = New System.Drawing.Point(50, 395)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(541, 172)
        Me.GroupBox1.TabIndex = 1
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Menú Reservado"
        '
        'BtN_Down
        '
        Me.BtN_Down.BackColor = System.Drawing.SystemColors.Control
        Me.BtN_Down.Enabled = False
        Me.BtN_Down.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.BtN_Down.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtN_Down.Image = CType(resources.GetObject("BtN_Down.Image"), System.Drawing.Image)
        Me.BtN_Down.Location = New System.Drawing.Point(481, 121)
        Me.BtN_Down.Name = "BtN_Down"
        Me.BtN_Down.Size = New System.Drawing.Size(51, 43)
        Me.BtN_Down.TabIndex = 4
        Me.BtN_Down.Tag = "N_DOWN"
        Me.BtN_Down.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BtN_Down.UseVisualStyleBackColor = False
        '
        'BtN_Up
        '
        Me.BtN_Up.BackColor = System.Drawing.SystemColors.Control
        Me.BtN_Up.Enabled = False
        Me.BtN_Up.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.BtN_Up.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtN_Up.Image = CType(resources.GetObject("BtN_Up.Image"), System.Drawing.Image)
        Me.BtN_Up.Location = New System.Drawing.Point(424, 121)
        Me.BtN_Up.Name = "BtN_Up"
        Me.BtN_Up.Size = New System.Drawing.Size(51, 43)
        Me.BtN_Up.TabIndex = 3
        Me.BtN_Up.Tag = "N_UP"
        Me.BtN_Up.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BtN_Up.UseVisualStyleBackColor = False
        '
        'BtNew
        '
        Me.BtNew.BackColor = System.Drawing.SystemColors.Control
        Me.BtNew.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.BtNew.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtNew.Image = CType(resources.GetObject("BtNew.Image"), System.Drawing.Image)
        Me.BtNew.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtNew.Location = New System.Drawing.Point(424, 19)
        Me.BtNew.Name = "BtNew"
        Me.BtNew.Size = New System.Drawing.Size(111, 42)
        Me.BtNew.TabIndex = 1
        Me.BtNew.Tag = "NEW"
        Me.BtNew.Text = "Agregar"
        Me.BtNew.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BtNew.UseVisualStyleBackColor = False
        '
        'BtDell
        '
        Me.BtDell.BackColor = System.Drawing.SystemColors.Control
        Me.BtDell.Enabled = False
        Me.BtDell.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.BtDell.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtDell.Image = CType(resources.GetObject("BtDell.Image"), System.Drawing.Image)
        Me.BtDell.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtDell.Location = New System.Drawing.Point(424, 67)
        Me.BtDell.Name = "BtDell"
        Me.BtDell.Size = New System.Drawing.Size(111, 42)
        Me.BtDell.TabIndex = 2
        Me.BtDell.Tag = "DEL"
        Me.BtDell.Text = "Eliminar"
        Me.BtDell.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BtDell.UseVisualStyleBackColor = False
        '
        'LstMenu
        '
        Me.LstMenu.BackColor = System.Drawing.Color.Beige
        Me.LstMenu.CheckBoxes = True
        Me.LstMenu.Font = New System.Drawing.Font("Tahoma", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LstMenu.FullRowSelect = True
        Me.LstMenu.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable
        Me.LstMenu.HideSelection = False
        Me.LstMenu.Location = New System.Drawing.Point(6, 19)
        Me.LstMenu.MultiSelect = False
        Me.LstMenu.Name = "LstMenu"
        Me.LstMenu.Size = New System.Drawing.Size(412, 147)
        Me.LstMenu.TabIndex = 0
        Me.LstMenu.UseCompatibleStateImageBehavior = False
        Me.LstMenu.View = System.Windows.Forms.View.Details
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(174, Byte), Integer), CType(CType(186, Byte), Integer), CType(CType(186, Byte), Integer))
        Me.Panel1.Controls.Add(Me.btOKPrint)
        Me.Panel1.Controls.Add(Me.BtCancell)
        Me.Panel1.Controls.Add(Me.BtOk)
        Me.Panel1.Location = New System.Drawing.Point(344, 29)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(250, 67)
        Me.Panel1.TabIndex = 2
        Me.Panel1.Tag = "NO_SCAN"
        '
        'btOKPrint
        '
        Me.btOKPrint.BackColor = System.Drawing.SystemColors.Control
        Me.btOKPrint.Enabled = False
        Me.btOKPrint.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btOKPrint.Image = CType(resources.GetObject("btOKPrint.Image"), System.Drawing.Image)
        Me.btOKPrint.Location = New System.Drawing.Point(167, 3)
        Me.btOKPrint.Name = "btOKPrint"
        Me.btOKPrint.Size = New System.Drawing.Size(81, 63)
        Me.btOKPrint.TabIndex = 48
        Me.btOKPrint.Tag = "print"
        Me.btOKPrint.Text = "Guardar e Imprimir"
        Me.btOKPrint.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btOKPrint.UseVisualStyleBackColor = False
        '
        'BtCancell
        '
        Me.BtCancell.BackColor = System.Drawing.SystemColors.Control
        Me.BtCancell.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.BtCancell.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtCancell.Image = CType(resources.GetObject("BtCancell.Image"), System.Drawing.Image)
        Me.BtCancell.Location = New System.Drawing.Point(11, 3)
        Me.BtCancell.Name = "BtCancell"
        Me.BtCancell.Size = New System.Drawing.Size(67, 63)
        Me.BtCancell.TabIndex = 0
        Me.BtCancell.Tag = "cancell"
        Me.BtCancell.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.BtCancell.UseVisualStyleBackColor = False
        '
        'BtOk
        '
        Me.BtOk.BackColor = System.Drawing.SystemColors.Control
        Me.BtOk.Enabled = False
        Me.BtOk.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtOk.Image = CType(resources.GetObject("BtOk.Image"), System.Drawing.Image)
        Me.BtOk.Location = New System.Drawing.Point(84, 2)
        Me.BtOk.Name = "BtOk"
        Me.BtOk.Size = New System.Drawing.Size(67, 63)
        Me.BtOk.TabIndex = 1
        Me.BtOk.Tag = "ok"
        Me.BtOk.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.BtOk.UseVisualStyleBackColor = False
        '
        'BtKeyBoard
        '
        Me.BtKeyBoard.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.BtKeyBoard.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtKeyBoard.Image = CType(resources.GetObject("BtKeyBoard.Image"), System.Drawing.Image)
        Me.BtKeyBoard.Location = New System.Drawing.Point(282, 32)
        Me.BtKeyBoard.Name = "BtKeyBoard"
        Me.BtKeyBoard.Size = New System.Drawing.Size(42, 28)
        Me.BtKeyBoard.TabIndex = 47
        Me.BtKeyBoard.Tag = "last"
        Me.BtKeyBoard.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.BtKeyBoard.UseVisualStyleBackColor = True
        '
        'LblFhEvento
        '
        Me.LblFhEvento.AutoSize = True
        Me.LblFhEvento.BackColor = System.Drawing.Color.Transparent
        Me.LblFhEvento.Font = New System.Drawing.Font("Tahoma", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblFhEvento.Location = New System.Drawing.Point(103, 72)
        Me.LblFhEvento.Name = "LblFhEvento"
        Me.LblFhEvento.Size = New System.Drawing.Size(72, 23)
        Me.LblFhEvento.TabIndex = 44
        Me.LblFhEvento.Text = "Fecha:"
        '
        'frmReservas_Evento
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), System.Drawing.Image)
        Me.ClientSize = New System.Drawing.Size(639, 599)
        Me.Controls.Add(Me.LblFhEvento)
        Me.Controls.Add(Me.BtKeyBoard)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.PnlReservas)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Label1)
        Me.Controls.Add(Me.LblName)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmReservas_Evento"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Gestor de Eventos"
        Me.PnlReservas.ResumeLayout(False)
        Me.PnlReservas.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents LblName As System.Windows.Forms.Label
    Friend WithEvents PnlReservas As System.Windows.Forms.Panel
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents BtCancell As System.Windows.Forms.Button
    Friend WithEvents BtOk As System.Windows.Forms.Button
    Friend WithEvents LblFhEvento As System.Windows.Forms.Label
    Friend WithEvents TxtName As System.Windows.Forms.TextBox
    Friend WithEvents TxtAbout As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents LstMenu As System.Windows.Forms.ListView
    Friend WithEvents BtNew As System.Windows.Forms.Button
    Friend WithEvents BtDell As System.Windows.Forms.Button
    Friend WithEvents BtN_Down As System.Windows.Forms.Button
    Friend WithEvents BtN_Up As System.Windows.Forms.Button
    Friend WithEvents DtFhReserva As System.Windows.Forms.DateTimePicker
    Friend WithEvents LblFh_Alta As System.Windows.Forms.Label
    Friend WithEvents LblFh_Alta_nfo As System.Windows.Forms.Label
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents MaskedTextBox1 As System.Windows.Forms.MaskedTextBox
    Friend WithEvents BtKeyBoard As System.Windows.Forms.Button
    Friend WithEvents txtIDUsuario As System.Windows.Forms.TextBox
    Friend WithEvents btOKPrint As System.Windows.Forms.Button
End Class
