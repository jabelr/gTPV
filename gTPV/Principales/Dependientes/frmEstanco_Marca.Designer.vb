<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmEstanco_Marca
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
        Dim Label3 As System.Windows.Forms.Label
        Dim Label1 As System.Windows.Forms.Label
        Dim Label4 As System.Windows.Forms.Label
        Dim Label7 As System.Windows.Forms.Label
        Dim Label8 As System.Windows.Forms.Label
        Dim Label9 As System.Windows.Forms.Label
        Dim lblUsos As System.Windows.Forms.Label
        Dim Label2 As System.Windows.Forms.Label
        Dim Label10 As System.Windows.Forms.Label
        Dim Label11 As System.Windows.Forms.Label
        Dim Label12 As System.Windows.Forms.Label
        Dim Label13 As System.Windows.Forms.Label
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmEstanco_Marca))
        Me.PnlAction_Buttons = New System.Windows.Forms.Panel()
        Me.BtDel = New System.Windows.Forms.Button()
        Me.BtCancell = New System.Windows.Forms.Button()
        Me.BtOk = New System.Windows.Forms.Button()
        Me.txtIdTipo = New System.Windows.Forms.TextBox()
        Me.LblName = New System.Windows.Forms.Label()
        Me.BtImg = New System.Windows.Forms.Button()
        Me.CbImg_Cat = New System.Windows.Forms.ComboBox()
        Me.TxtName = New System.Windows.Forms.TextBox()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.txtUD_opt = New System.Windows.Forms.TextBox()
        Me.txtUD_min = New System.Windows.Forms.TextBox()
        Me.txtUD = New System.Windows.Forms.TextBox()
        Me.txtUD_x10 = New System.Windows.Forms.TextBox()
        Me.BtCodBarrasx10_Add = New System.Windows.Forms.Button()
        Me.txtCodBarras_x10 = New System.Windows.Forms.TextBox()
        Me.BtCodBarras_Add = New System.Windows.Forms.Button()
        Me.txtCodBarras = New System.Windows.Forms.TextBox()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.txtPrecioRecargo = New System.Windows.Forms.TextBox()
        Me.txtPrecio = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.chkActivo = New System.Windows.Forms.CheckBox()
        Me.CheckBox1 = New System.Windows.Forms.CheckBox()
        Label3 = New System.Windows.Forms.Label()
        Label1 = New System.Windows.Forms.Label()
        Label4 = New System.Windows.Forms.Label()
        Label7 = New System.Windows.Forms.Label()
        Label8 = New System.Windows.Forms.Label()
        Label9 = New System.Windows.Forms.Label()
        lblUsos = New System.Windows.Forms.Label()
        Label2 = New System.Windows.Forms.Label()
        Label10 = New System.Windows.Forms.Label()
        Label11 = New System.Windows.Forms.Label()
        Label12 = New System.Windows.Forms.Label()
        Label13 = New System.Windows.Forms.Label()
        Me.PnlAction_Buttons.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label3
        '
        Label3.AutoSize = True
        Label3.BackColor = System.Drawing.Color.Transparent
        Label3.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Label3.Location = New System.Drawing.Point(9, 12)
        Label3.Name = "Label3"
        Label3.Size = New System.Drawing.Size(60, 18)
        Label3.TabIndex = 38
        Label3.Text = "Nombre"
        '
        'Label1
        '
        Label1.AutoSize = True
        Label1.BackColor = System.Drawing.Color.Transparent
        Label1.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Label1.Location = New System.Drawing.Point(9, 56)
        Label1.Name = "Label1"
        Label1.Size = New System.Drawing.Size(69, 18)
        Label1.TabIndex = 40
        Label1.Text = "Categoría"
        '
        'Label4
        '
        Label4.AutoSize = True
        Label4.BackColor = System.Drawing.Color.Transparent
        Label4.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Label4.Location = New System.Drawing.Point(9, 144)
        Label4.Name = "Label4"
        Label4.Size = New System.Drawing.Size(46, 18)
        Label4.TabIndex = 43
        Label4.Text = "Precio"
        '
        'Label7
        '
        Label7.AutoSize = True
        Label7.BackColor = System.Drawing.Color.Transparent
        Label7.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Label7.Location = New System.Drawing.Point(289, 144)
        Label7.Name = "Label7"
        Label7.Size = New System.Drawing.Size(104, 18)
        Label7.TabIndex = 47
        Label7.Text = "Precio Recargo"
        Label7.Visible = False
        '
        'Label8
        '
        Label8.AutoSize = True
        Label8.BackColor = System.Drawing.Color.Transparent
        Label8.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Label8.Location = New System.Drawing.Point(9, 100)
        Label8.Name = "Label8"
        Label8.Size = New System.Drawing.Size(87, 18)
        Label8.TabIndex = 49
        Label8.Text = "Código CMT"
        '
        'Label9
        '
        Label9.AutoSize = True
        Label9.BackColor = System.Drawing.Color.Transparent
        Label9.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Label9.Location = New System.Drawing.Point(9, 182)
        Label9.Name = "Label9"
        Label9.Size = New System.Drawing.Size(119, 18)
        Label9.TabIndex = 51
        Label9.Text = "Código de Barras"
        '
        'lblUsos
        '
        lblUsos.AutoSize = True
        lblUsos.BackColor = System.Drawing.Color.Transparent
        lblUsos.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        lblUsos.Location = New System.Drawing.Point(300, 35)
        lblUsos.Name = "lblUsos"
        lblUsos.Size = New System.Drawing.Size(38, 18)
        lblUsos.TabIndex = 52
        lblUsos.Tag = "usos"
        lblUsos.Text = "usos"
        '
        'Label2
        '
        Label2.AutoSize = True
        Label2.BackColor = System.Drawing.Color.Transparent
        Label2.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Label2.Location = New System.Drawing.Point(4, 246)
        Label2.Name = "Label2"
        Label2.Size = New System.Drawing.Size(148, 18)
        Label2.TabIndex = 55
        Label2.Text = "Código de Barras x10"
        '
        'Label10
        '
        Label10.AutoSize = True
        Label10.BackColor = System.Drawing.Color.Transparent
        Label10.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Label10.Location = New System.Drawing.Point(10, 16)
        Label10.Name = "Label10"
        Label10.Size = New System.Drawing.Size(31, 18)
        Label10.TabIndex = 57
        Label10.Text = "Ud."
        '
        'Label11
        '
        Label11.AutoSize = True
        Label11.BackColor = System.Drawing.Color.Transparent
        Label11.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Label11.Location = New System.Drawing.Point(117, 16)
        Label11.Name = "Label11"
        Label11.Size = New System.Drawing.Size(60, 18)
        Label11.TabIndex = 59
        Label11.Text = "Ud. x10"
        '
        'Label12
        '
        Label12.AutoSize = True
        Label12.BackColor = System.Drawing.Color.Transparent
        Label12.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Label12.Location = New System.Drawing.Point(6, 76)
        Label12.Name = "Label12"
        Label12.Size = New System.Drawing.Size(79, 16)
        Label12.TabIndex = 61
        Label12.Text = "Ud. mínimas"
        '
        'Label13
        '
        Label13.AutoSize = True
        Label13.BackColor = System.Drawing.Color.Transparent
        Label13.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Label13.Location = New System.Drawing.Point(113, 77)
        Label13.Name = "Label13"
        Label13.Size = New System.Drawing.Size(76, 16)
        Label13.TabIndex = 63
        Label13.Text = "Ud. optimas"
        '
        'PnlAction_Buttons
        '
        Me.PnlAction_Buttons.BackColor = System.Drawing.Color.FromArgb(CType(CType(174, Byte), Integer), CType(CType(186, Byte), Integer), CType(CType(186, Byte), Integer))
        Me.PnlAction_Buttons.Controls.Add(Me.BtDel)
        Me.PnlAction_Buttons.Controls.Add(Me.BtCancell)
        Me.PnlAction_Buttons.Controls.Add(Me.BtOk)
        Me.PnlAction_Buttons.Location = New System.Drawing.Point(357, 35)
        Me.PnlAction_Buttons.Name = "PnlAction_Buttons"
        Me.PnlAction_Buttons.Size = New System.Drawing.Size(238, 70)
        Me.PnlAction_Buttons.TabIndex = 1
        Me.PnlAction_Buttons.Tag = "NO_SCAN"
        '
        'BtDel
        '
        Me.BtDel.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.BtDel.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtDel.Image = CType(resources.GetObject("BtDel.Image"), System.Drawing.Image)
        Me.BtDel.Location = New System.Drawing.Point(3, 3)
        Me.BtDel.Name = "BtDel"
        Me.BtDel.Size = New System.Drawing.Size(67, 63)
        Me.BtDel.TabIndex = 2
        Me.BtDel.Tag = "delete"
        Me.BtDel.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.BtDel.UseVisualStyleBackColor = True
        '
        'BtCancell
        '
        Me.BtCancell.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.BtCancell.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.BtCancell.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtCancell.Image = CType(resources.GetObject("BtCancell.Image"), System.Drawing.Image)
        Me.BtCancell.Location = New System.Drawing.Point(94, 3)
        Me.BtCancell.Name = "BtCancell"
        Me.BtCancell.Size = New System.Drawing.Size(67, 63)
        Me.BtCancell.TabIndex = 0
        Me.BtCancell.Tag = "cancell"
        Me.BtCancell.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.BtCancell.UseVisualStyleBackColor = True
        '
        'BtOk
        '
        Me.BtOk.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.BtOk.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtOk.Image = CType(resources.GetObject("BtOk.Image"), System.Drawing.Image)
        Me.BtOk.Location = New System.Drawing.Point(167, 3)
        Me.BtOk.Name = "BtOk"
        Me.BtOk.Size = New System.Drawing.Size(67, 63)
        Me.BtOk.TabIndex = 1
        Me.BtOk.Tag = "ok"
        Me.BtOk.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.BtOk.UseVisualStyleBackColor = True
        '
        'txtIdTipo
        '
        Me.txtIdTipo.Font = New System.Drawing.Font("Tahoma", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtIdTipo.Location = New System.Drawing.Point(355, 45)
        Me.txtIdTipo.MaxLength = 25
        Me.txtIdTipo.Name = "txtIdTipo"
        Me.txtIdTipo.Size = New System.Drawing.Size(84, 33)
        Me.txtIdTipo.TabIndex = 33
        Me.txtIdTipo.Tag = "id_tipo"
        Me.txtIdTipo.Text = "id_tipo"
        Me.txtIdTipo.Visible = False
        '
        'LblName
        '
        Me.LblName.BackColor = System.Drawing.Color.Transparent
        Me.LblName.Cursor = System.Windows.Forms.Cursors.AppStarting
        Me.LblName.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblName.Location = New System.Drawing.Point(47, 38)
        Me.LblName.Name = "LblName"
        Me.LblName.Size = New System.Drawing.Size(291, 23)
        Me.LblName.TabIndex = 34
        Me.LblName.Text = "Marca de Tabaco"
        '
        'BtImg
        '
        Me.BtImg.Location = New System.Drawing.Point(446, 45)
        Me.BtImg.Margin = New System.Windows.Forms.Padding(0)
        Me.BtImg.Name = "BtImg"
        Me.BtImg.Size = New System.Drawing.Size(112, 109)
        Me.BtImg.TabIndex = 7
        Me.BtImg.Tag = "img"
        Me.BtImg.Text = "Click para seleccionar"
        Me.BtImg.UseVisualStyleBackColor = True
        '
        'CbImg_Cat
        '
        Me.CbImg_Cat.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CbImg_Cat.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CbImg_Cat.FormattingEnabled = True
        Me.CbImg_Cat.Location = New System.Drawing.Point(137, 45)
        Me.CbImg_Cat.Name = "CbImg_Cat"
        Me.CbImg_Cat.Size = New System.Drawing.Size(235, 37)
        Me.CbImg_Cat.TabIndex = 1
        '
        'TxtName
        '
        Me.TxtName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtName.Font = New System.Drawing.Font("Tahoma", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtName.Location = New System.Drawing.Point(87, 3)
        Me.TxtName.MaxLength = 35
        Me.TxtName.Name = "TxtName"
        Me.TxtName.Size = New System.Drawing.Size(471, 36)
        Me.TxtName.TabIndex = 0
        Me.TxtName.Tag = "name"
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(174, Byte), Integer), CType(CType(186, Byte), Integer), CType(CType(186, Byte), Integer))
        Me.Panel1.Controls.Add(Me.GroupBox1)
        Me.Panel1.Controls.Add(Me.BtCodBarrasx10_Add)
        Me.Panel1.Controls.Add(Label2)
        Me.Panel1.Controls.Add(Me.txtCodBarras_x10)
        Me.Panel1.Controls.Add(Me.BtCodBarras_Add)
        Me.Panel1.Controls.Add(Label9)
        Me.Panel1.Controls.Add(Me.txtCodBarras)
        Me.Panel1.Controls.Add(Label8)
        Me.Panel1.Controls.Add(Me.TextBox1)
        Me.Panel1.Controls.Add(Label7)
        Me.Panel1.Controls.Add(Me.txtPrecioRecargo)
        Me.Panel1.Controls.Add(Label4)
        Me.Panel1.Controls.Add(Me.txtPrecio)
        Me.Panel1.Controls.Add(Me.BtImg)
        Me.Panel1.Controls.Add(Label3)
        Me.Panel1.Controls.Add(Label1)
        Me.Panel1.Controls.Add(Me.txtIdTipo)
        Me.Panel1.Controls.Add(Me.TxtName)
        Me.Panel1.Controls.Add(Me.CbImg_Cat)
        Me.Panel1.Location = New System.Drawing.Point(41, 111)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(558, 305)
        Me.Panel1.TabIndex = 0
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.txtUD_opt)
        Me.GroupBox1.Controls.Add(Label13)
        Me.GroupBox1.Controls.Add(Me.txtUD_min)
        Me.GroupBox1.Controls.Add(Label12)
        Me.GroupBox1.Controls.Add(Me.txtUD)
        Me.GroupBox1.Controls.Add(Label11)
        Me.GroupBox1.Controls.Add(Label10)
        Me.GroupBox1.Controls.Add(Me.txtUD_x10)
        Me.GroupBox1.Location = New System.Drawing.Point(273, 175)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(277, 127)
        Me.GroupBox1.TabIndex = 9
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Almacén"
        '
        'txtUD_opt
        '
        Me.txtUD_opt.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtUD_opt.Font = New System.Drawing.Font("Tahoma", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtUD_opt.Location = New System.Drawing.Point(122, 93)
        Me.txtUD_opt.MaxLength = 35
        Me.txtUD_opt.Name = "txtUD_opt"
        Me.txtUD_opt.Size = New System.Drawing.Size(78, 30)
        Me.txtUD_opt.TabIndex = 3
        Me.txtUD_opt.Tag = "ud_opt"
        '
        'txtUD_min
        '
        Me.txtUD_min.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtUD_min.Font = New System.Drawing.Font("Tahoma", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtUD_min.Location = New System.Drawing.Point(15, 92)
        Me.txtUD_min.MaxLength = 35
        Me.txtUD_min.Name = "txtUD_min"
        Me.txtUD_min.Size = New System.Drawing.Size(78, 30)
        Me.txtUD_min.TabIndex = 2
        Me.txtUD_min.Tag = "ud_min"
        '
        'txtUD
        '
        Me.txtUD.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtUD.Font = New System.Drawing.Font("Tahoma", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtUD.Location = New System.Drawing.Point(15, 37)
        Me.txtUD.MaxLength = 35
        Me.txtUD.Name = "txtUD"
        Me.txtUD.Size = New System.Drawing.Size(78, 36)
        Me.txtUD.TabIndex = 0
        Me.txtUD.Tag = "ud"
        '
        'txtUD_x10
        '
        Me.txtUD_x10.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtUD_x10.Font = New System.Drawing.Font("Tahoma", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtUD_x10.Location = New System.Drawing.Point(122, 37)
        Me.txtUD_x10.MaxLength = 35
        Me.txtUD_x10.Name = "txtUD_x10"
        Me.txtUD_x10.Size = New System.Drawing.Size(78, 36)
        Me.txtUD_x10.TabIndex = 1
        Me.txtUD_x10.Tag = "ud_x10"
        '
        'BtCodBarrasx10_Add
        '
        Me.BtCodBarrasx10_Add.Image = CType(resources.GetObject("BtCodBarrasx10_Add.Image"), System.Drawing.Image)
        Me.BtCodBarrasx10_Add.Location = New System.Drawing.Point(221, 267)
        Me.BtCodBarrasx10_Add.Name = "BtCodBarrasx10_Add"
        Me.BtCodBarrasx10_Add.Size = New System.Drawing.Size(40, 36)
        Me.BtCodBarrasx10_Add.TabIndex = 8
        Me.BtCodBarrasx10_Add.Tag = "VISIBLE"
        Me.BtCodBarrasx10_Add.UseVisualStyleBackColor = True
        '
        'txtCodBarras_x10
        '
        Me.txtCodBarras_x10.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtCodBarras_x10.Font = New System.Drawing.Font("Tahoma", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCodBarras_x10.Location = New System.Drawing.Point(17, 267)
        Me.txtCodBarras_x10.MaxLength = 35
        Me.txtCodBarras_x10.Name = "txtCodBarras_x10"
        Me.txtCodBarras_x10.Size = New System.Drawing.Size(198, 36)
        Me.txtCodBarras_x10.TabIndex = 7
        Me.txtCodBarras_x10.Tag = "cod_barras_x10"
        '
        'BtCodBarras_Add
        '
        Me.BtCodBarras_Add.Image = CType(resources.GetObject("BtCodBarras_Add.Image"), System.Drawing.Image)
        Me.BtCodBarras_Add.Location = New System.Drawing.Point(221, 203)
        Me.BtCodBarras_Add.Name = "BtCodBarras_Add"
        Me.BtCodBarras_Add.Size = New System.Drawing.Size(40, 36)
        Me.BtCodBarras_Add.TabIndex = 6
        Me.BtCodBarras_Add.Tag = "VISIBLE"
        Me.BtCodBarras_Add.UseVisualStyleBackColor = True
        '
        'txtCodBarras
        '
        Me.txtCodBarras.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtCodBarras.Font = New System.Drawing.Font("Tahoma", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCodBarras.Location = New System.Drawing.Point(17, 203)
        Me.txtCodBarras.MaxLength = 35
        Me.txtCodBarras.Name = "txtCodBarras"
        Me.txtCodBarras.Size = New System.Drawing.Size(198, 36)
        Me.txtCodBarras.TabIndex = 5
        Me.txtCodBarras.Tag = "cod_barras"
        '
        'TextBox1
        '
        Me.TextBox1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TextBox1.Font = New System.Drawing.Font("Tahoma", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox1.Location = New System.Drawing.Point(137, 88)
        Me.TextBox1.MaxLength = 35
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(171, 36)
        Me.TextBox1.TabIndex = 2
        Me.TextBox1.Tag = "codigo"
        '
        'txtPrecioRecargo
        '
        Me.txtPrecioRecargo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtPrecioRecargo.Font = New System.Drawing.Font("Tahoma", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPrecioRecargo.Location = New System.Drawing.Point(319, 133)
        Me.txtPrecioRecargo.MaxLength = 35
        Me.txtPrecioRecargo.Name = "txtPrecioRecargo"
        Me.txtPrecioRecargo.Size = New System.Drawing.Size(100, 36)
        Me.txtPrecioRecargo.TabIndex = 4
        Me.txtPrecioRecargo.Tag = "precio_recargo"
        Me.txtPrecioRecargo.Visible = False
        '
        'txtPrecio
        '
        Me.txtPrecio.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtPrecio.Font = New System.Drawing.Font("Tahoma", 21.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPrecio.Location = New System.Drawing.Point(137, 130)
        Me.txtPrecio.MaxLength = 35
        Me.txtPrecio.Name = "txtPrecio"
        Me.txtPrecio.Size = New System.Drawing.Size(125, 43)
        Me.txtPrecio.TabIndex = 3
        Me.txtPrecio.Tag = "precio"
        '
        'Label6
        '
        Me.Label6.BackColor = System.Drawing.Color.FromArgb(CType(CType(174, Byte), Integer), CType(CType(186, Byte), Integer), CType(CType(186, Byte), Integer))
        Me.Label6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label6.Font = New System.Drawing.Font("Verdana", 12.0!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(211, 85)
        Me.Label6.Name = "Label6"
        Me.Label6.Padding = New System.Windows.Forms.Padding(3, 1, 0, 0)
        Me.Label6.Size = New System.Drawing.Size(127, 23)
        Me.Label6.TabIndex = 45
        Me.Label6.Tag = "fh_updatePrecio"
        Me.Label6.Text = "00/00/0000"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(160, 72)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(143, 13)
        Me.Label5.TabIndex = 44
        Me.Label5.Text = "Actualización de Precio:"
        '
        'chkActivo
        '
        Me.chkActivo.AutoSize = True
        Me.chkActivo.BackColor = System.Drawing.Color.FromArgb(CType(CType(174, Byte), Integer), CType(CType(186, Byte), Integer), CType(CType(186, Byte), Integer))
        Me.chkActivo.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkActivo.Location = New System.Drawing.Point(48, 69)
        Me.chkActivo.Name = "chkActivo"
        Me.chkActivo.Size = New System.Drawing.Size(81, 16)
        Me.chkActivo.TabIndex = 6
        Me.chkActivo.Tag = "activo"
        Me.chkActivo.Text = "Marca Activa"
        Me.chkActivo.UseVisualStyleBackColor = False
        '
        'CheckBox1
        '
        Me.CheckBox1.AutoSize = True
        Me.CheckBox1.BackColor = System.Drawing.Color.FromArgb(CType(CType(174, Byte), Integer), CType(CType(186, Byte), Integer), CType(CType(186, Byte), Integer))
        Me.CheckBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CheckBox1.Location = New System.Drawing.Point(48, 92)
        Me.CheckBox1.Name = "CheckBox1"
        Me.CheckBox1.Size = New System.Drawing.Size(115, 16)
        Me.CheckBox1.TabIndex = 53
        Me.CheckBox1.Tag = "descatolagada"
        Me.CheckBox1.Text = "Marca Descatalogada"
        Me.CheckBox1.UseVisualStyleBackColor = False
        '
        'frmEstanco_Marca
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), System.Drawing.Image)
        Me.CancelButton = Me.BtCancell
        Me.ClientSize = New System.Drawing.Size(639, 451)
        Me.Controls.Add(Me.CheckBox1)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.PnlAction_Buttons)
        Me.Controls.Add(lblUsos)
        Me.Controls.Add(Me.chkActivo)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.LblName)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmEstanco_Marca"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Marca de Estanco"
        Me.PnlAction_Buttons.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents PnlAction_Buttons As System.Windows.Forms.Panel
    Friend WithEvents BtCancell As System.Windows.Forms.Button
    Friend WithEvents BtOk As System.Windows.Forms.Button
    Friend WithEvents txtIdTipo As System.Windows.Forms.TextBox
    Friend WithEvents BtDel As System.Windows.Forms.Button
    Friend WithEvents LblName As System.Windows.Forms.Label
    Friend WithEvents BtImg As System.Windows.Forms.Button
    Friend WithEvents CbImg_Cat As System.Windows.Forms.ComboBox
    Friend WithEvents TxtName As System.Windows.Forms.TextBox
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents txtPrecio As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtPrecioRecargo As System.Windows.Forms.TextBox
    Friend WithEvents txtCodBarras As System.Windows.Forms.TextBox
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents chkActivo As System.Windows.Forms.CheckBox
    Friend WithEvents BtCodBarras_Add As System.Windows.Forms.Button
    Friend WithEvents BtCodBarrasx10_Add As System.Windows.Forms.Button
    Friend WithEvents txtCodBarras_x10 As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents txtUD As System.Windows.Forms.TextBox
    Friend WithEvents txtUD_x10 As System.Windows.Forms.TextBox
    Friend WithEvents CheckBox1 As System.Windows.Forms.CheckBox
    Friend WithEvents txtUD_opt As System.Windows.Forms.TextBox
    Friend WithEvents txtUD_min As System.Windows.Forms.TextBox
End Class
