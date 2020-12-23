<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmGestion
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
        Dim PictureBox1 As System.Windows.Forms.PictureBox
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmGestion))
        Dim PictureBox7 As System.Windows.Forms.PictureBox
        Dim PictureBox3 As System.Windows.Forms.PictureBox
        Me.groupGenerales = New System.Windows.Forms.GroupBox()
        Me.rbtGenerales_Usuarios = New System.Windows.Forms.RadioButton()
        Me.rbtGenerales_Prov = New System.Windows.Forms.RadioButton()
        Me.rbtGenerales_Clientes = New System.Windows.Forms.RadioButton()
        Me.groupAlmacen = New System.Windows.Forms.GroupBox()
        Me.rbtAlmacen_Estanco = New System.Windows.Forms.RadioButton()
        Me.rbtAlmacen_SimpleValoracion = New System.Windows.Forms.RadioButton()
        Me.ChkAlmacen_Estocables = New System.Windows.Forms.CheckBox()
        Me.CbAlmacen_Categoria = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.rbtAlmacen_Agrupado = New System.Windows.Forms.RadioButton()
        Me.rbtAlmacen_Simple = New System.Windows.Forms.RadioButton()
        Me.groupAlmacen_Estocable = New System.Windows.Forms.GroupBox()
        Me.Rbt_Stock_05 = New System.Windows.Forms.RadioButton()
        Me.Rbt_Stock_01 = New System.Windows.Forms.RadioButton()
        Me.Rbt_Stock_04 = New System.Windows.Forms.RadioButton()
        Me.Rbt_Stock_02 = New System.Windows.Forms.RadioButton()
        Me.Rbt_Stock_03 = New System.Windows.Forms.RadioButton()
        Me.groupCajas = New System.Windows.Forms.GroupBox()
        Me.rbtCaja_Resumen = New System.Windows.Forms.RadioButton()
        Me.RadioButton1 = New System.Windows.Forms.RadioButton()
        Me.rbtCaja_Actual = New System.Windows.Forms.RadioButton()
        Me.rbtCaja_ConsumoID = New System.Windows.Forms.RadioButton()
        Me.RadioButton6 = New System.Windows.Forms.RadioButton()
        Me.RadioButton3 = New System.Windows.Forms.RadioButton()
        Me.RadioButton2 = New System.Windows.Forms.RadioButton()
        Me.rbtCajas_Consumo = New System.Windows.Forms.RadioButton()
        Me.rbtCaja_UsuarioDetallado = New System.Windows.Forms.RadioButton()
        Me.groupCajas_fh = New System.Windows.Forms.GroupBox()
        Me.FhCaja_Desde = New System.Windows.Forms.DateTimePicker()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.FhCaja_Hasta = New System.Windows.Forms.DateTimePicker()
        Me.RadioButton7 = New System.Windows.Forms.RadioButton()
        Me.rbtCajas_Consumiciones = New System.Windows.Forms.RadioButton()
        Me.rbtCaja_TicketsDia = New System.Windows.Forms.RadioButton()
        Me.rbtCajas_UsuarioEntradas = New System.Windows.Forms.RadioButton()
        Me.rbtCaja_Usuario = New System.Windows.Forms.RadioButton()
        Me.rbtCaja_Simple = New System.Windows.Forms.RadioButton()
        Me.groupResumenCaja = New System.Windows.Forms.GroupBox()
        Me.txtCajaID = New System.Windows.Forms.TextBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.chkCajas_SoloTickets = New System.Windows.Forms.CheckBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.rbtCajas_Consumo_Local = New System.Windows.Forms.RadioButton()
        Me.rbtCajas_Consumo_Estanco = New System.Windows.Forms.RadioButton()
        Me.rbtCajas_Consumo_Pedidos = New System.Windows.Forms.RadioButton()
        Me.chkResumenConcepto = New System.Windows.Forms.CheckBox()
        Me.chkPrintTicket = New System.Windows.Forms.CheckBox()
        Me.chkResumenPedidos = New System.Windows.Forms.CheckBox()
        Me.PicImg_gDev = New System.Windows.Forms.PictureBox()
        Me.groupFacturacion = New System.Windows.Forms.GroupBox()
        Me.GroupBox6 = New System.Windows.Forms.GroupBox()
        Me.FhDesde_Facturas = New System.Windows.Forms.DateTimePicker()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.FhHasta_Facturas = New System.Windows.Forms.DateTimePicker()
        Me.rbtFacturacion_Facturas = New System.Windows.Forms.RadioButton()
        Me.rbtFacturacion_FtraCompras = New System.Windows.Forms.RadioButton()
        Me.PnlTipoB = New System.Windows.Forms.Panel()
        Me.CbTipo = New System.Windows.Forms.ComboBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.SplitContainer = New System.Windows.Forms.SplitContainer()
        Me.m_logo = New System.Windows.Forms.PictureBox()
        Me.PnlButton_Shell = New System.Windows.Forms.Panel()
        Me.BtClose = New System.Windows.Forms.Button()
        Me.BtGenerar = New System.Windows.Forms.Button()
        Me.BtMin = New System.Windows.Forms.Button()
        Me.LblSubTitle = New System.Windows.Forms.Label()
        Me.LblTitle = New System.Windows.Forms.Label()
        Me.PnlBody = New System.Windows.Forms.Panel()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Tab = New System.Windows.Forms.TabControl()
        Me.TabPage_Generales = New System.Windows.Forms.TabPage()
        Me.rbtTipo_Empresa = New System.Windows.Forms.RadioButton()
        Me.rbtTipo_Facturacion = New System.Windows.Forms.RadioButton()
        Me.rbtTipo_Caja = New System.Windows.Forms.RadioButton()
        Me.rbtTipo_Almacen = New System.Windows.Forms.RadioButton()
        Me.rbtTipo_General = New System.Windows.Forms.RadioButton()
        Me.Panel5 = New System.Windows.Forms.Panel()
        Me.pbBar = New System.Windows.Forms.ProgressBar()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.Label66 = New System.Windows.Forms.Label()
        Me.TabPage_Operaciones = New System.Windows.Forms.TabPage()
        Me.ImageList = New System.Windows.Forms.ImageList(Me.components)
        Me.rbtFacturacion_FtraCompras_ACT = New System.Windows.Forms.RadioButton()
        PictureBox1 = New System.Windows.Forms.PictureBox()
        PictureBox7 = New System.Windows.Forms.PictureBox()
        PictureBox3 = New System.Windows.Forms.PictureBox()
        CType(PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(PictureBox7, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(PictureBox3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.groupGenerales.SuspendLayout()
        Me.groupAlmacen.SuspendLayout()
        Me.groupAlmacen_Estocable.SuspendLayout()
        Me.groupCajas.SuspendLayout()
        Me.groupCajas_fh.SuspendLayout()
        Me.groupResumenCaja.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        CType(Me.PicImg_gDev, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.groupFacturacion.SuspendLayout()
        Me.GroupBox6.SuspendLayout()
        Me.PnlTipoB.SuspendLayout()
        Me.SplitContainer.Panel1.SuspendLayout()
        Me.SplitContainer.Panel2.SuspendLayout()
        Me.SplitContainer.SuspendLayout()
        CType(Me.m_logo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PnlButton_Shell.SuspendLayout()
        Me.PnlBody.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.Tab.SuspendLayout()
        Me.TabPage_Generales.SuspendLayout()
        Me.Panel5.SuspendLayout()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PictureBox1
        '
        PictureBox1.BackColor = System.Drawing.Color.White
        PictureBox1.Cursor = System.Windows.Forms.Cursors.Help
        PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        PictureBox1.Location = New System.Drawing.Point(454, 553)
        PictureBox1.Name = "PictureBox1"
        PictureBox1.Size = New System.Drawing.Size(125, 32)
        PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        PictureBox1.TabIndex = 22
        PictureBox1.TabStop = False
        '
        'PictureBox7
        '
        PictureBox7.Image = CType(resources.GetObject("PictureBox7.Image"), System.Drawing.Image)
        PictureBox7.Location = New System.Drawing.Point(764, -23)
        PictureBox7.Name = "PictureBox7"
        PictureBox7.Size = New System.Drawing.Size(151, 146)
        PictureBox7.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        PictureBox7.TabIndex = 39
        PictureBox7.TabStop = False
        '
        'PictureBox3
        '
        PictureBox3.BackColor = System.Drawing.Color.White
        PictureBox3.Cursor = System.Windows.Forms.Cursors.Help
        PictureBox3.Image = CType(resources.GetObject("PictureBox3.Image"), System.Drawing.Image)
        PictureBox3.Location = New System.Drawing.Point(759, 524)
        PictureBox3.Name = "PictureBox3"
        PictureBox3.Size = New System.Drawing.Size(159, 61)
        PictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        PictureBox3.TabIndex = 23
        PictureBox3.TabStop = False
        '
        'groupGenerales
        '
        Me.groupGenerales.Controls.Add(Me.rbtGenerales_Usuarios)
        Me.groupGenerales.Controls.Add(Me.rbtGenerales_Prov)
        Me.groupGenerales.Controls.Add(Me.rbtGenerales_Clientes)
        Me.groupGenerales.Enabled = False
        Me.groupGenerales.Location = New System.Drawing.Point(24, 82)
        Me.groupGenerales.Name = "groupGenerales"
        Me.groupGenerales.Size = New System.Drawing.Size(374, 87)
        Me.groupGenerales.TabIndex = 0
        Me.groupGenerales.TabStop = False
        Me.groupGenerales.Text = "Listados Generales"
        '
        'rbtGenerales_Usuarios
        '
        Me.rbtGenerales_Usuarios.AutoSize = True
        Me.rbtGenerales_Usuarios.Location = New System.Drawing.Point(19, 62)
        Me.rbtGenerales_Usuarios.Name = "rbtGenerales_Usuarios"
        Me.rbtGenerales_Usuarios.Size = New System.Drawing.Size(118, 17)
        Me.rbtGenerales_Usuarios.TabIndex = 2
        Me.rbtGenerales_Usuarios.Text = "Listado de Usuarios"
        Me.rbtGenerales_Usuarios.UseVisualStyleBackColor = True
        '
        'rbtGenerales_Prov
        '
        Me.rbtGenerales_Prov.AutoSize = True
        Me.rbtGenerales_Prov.Location = New System.Drawing.Point(19, 39)
        Me.rbtGenerales_Prov.Name = "rbtGenerales_Prov"
        Me.rbtGenerales_Prov.Size = New System.Drawing.Size(137, 17)
        Me.rbtGenerales_Prov.TabIndex = 1
        Me.rbtGenerales_Prov.Text = "Listado de Proveedores"
        Me.rbtGenerales_Prov.UseVisualStyleBackColor = True
        '
        'rbtGenerales_Clientes
        '
        Me.rbtGenerales_Clientes.AutoSize = True
        Me.rbtGenerales_Clientes.Checked = True
        Me.rbtGenerales_Clientes.Location = New System.Drawing.Point(19, 16)
        Me.rbtGenerales_Clientes.Name = "rbtGenerales_Clientes"
        Me.rbtGenerales_Clientes.Size = New System.Drawing.Size(114, 17)
        Me.rbtGenerales_Clientes.TabIndex = 0
        Me.rbtGenerales_Clientes.TabStop = True
        Me.rbtGenerales_Clientes.Text = "Listado de Clientes"
        Me.rbtGenerales_Clientes.UseVisualStyleBackColor = True
        '
        'groupAlmacen
        '
        Me.groupAlmacen.Controls.Add(Me.rbtAlmacen_Estanco)
        Me.groupAlmacen.Controls.Add(Me.rbtAlmacen_SimpleValoracion)
        Me.groupAlmacen.Controls.Add(Me.ChkAlmacen_Estocables)
        Me.groupAlmacen.Controls.Add(Me.CbAlmacen_Categoria)
        Me.groupAlmacen.Controls.Add(Me.Label1)
        Me.groupAlmacen.Controls.Add(Me.rbtAlmacen_Agrupado)
        Me.groupAlmacen.Controls.Add(Me.rbtAlmacen_Simple)
        Me.groupAlmacen.Controls.Add(Me.groupAlmacen_Estocable)
        Me.groupAlmacen.Enabled = False
        Me.groupAlmacen.Location = New System.Drawing.Point(24, 205)
        Me.groupAlmacen.Name = "groupAlmacen"
        Me.groupAlmacen.Size = New System.Drawing.Size(374, 258)
        Me.groupAlmacen.TabIndex = 1
        Me.groupAlmacen.TabStop = False
        Me.groupAlmacen.Text = "Tipo de listado"
        '
        'rbtAlmacen_Estanco
        '
        Me.rbtAlmacen_Estanco.AutoSize = True
        Me.rbtAlmacen_Estanco.Location = New System.Drawing.Point(19, 85)
        Me.rbtAlmacen_Estanco.Name = "rbtAlmacen_Estanco"
        Me.rbtAlmacen_Estanco.Size = New System.Drawing.Size(299, 17)
        Me.rbtAlmacen_Estanco.TabIndex = 40
        Me.rbtAlmacen_Estanco.Text = "Resumen de almacén de estanco por impresora de tickets"
        Me.rbtAlmacen_Estanco.UseVisualStyleBackColor = True
        '
        'rbtAlmacen_SimpleValoracion
        '
        Me.rbtAlmacen_SimpleValoracion.AutoSize = True
        Me.rbtAlmacen_SimpleValoracion.Location = New System.Drawing.Point(19, 62)
        Me.rbtAlmacen_SimpleValoracion.Name = "rbtAlmacen_SimpleValoracion"
        Me.rbtAlmacen_SimpleValoracion.Size = New System.Drawing.Size(223, 17)
        Me.rbtAlmacen_SimpleValoracion.TabIndex = 39
        Me.rbtAlmacen_SimpleValoracion.Text = "Listado de Almacén valorando existencias"
        Me.rbtAlmacen_SimpleValoracion.UseVisualStyleBackColor = True
        '
        'ChkAlmacen_Estocables
        '
        Me.ChkAlmacen_Estocables.AutoSize = True
        Me.ChkAlmacen_Estocables.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ChkAlmacen_Estocables.Location = New System.Drawing.Point(36, 158)
        Me.ChkAlmacen_Estocables.Name = "ChkAlmacen_Estocables"
        Me.ChkAlmacen_Estocables.Size = New System.Drawing.Size(215, 20)
        Me.ChkAlmacen_Estocables.TabIndex = 36
        Me.ChkAlmacen_Estocables.Text = "Solamente artículos estocables"
        Me.ChkAlmacen_Estocables.UseVisualStyleBackColor = True
        '
        'CbAlmacen_Categoria
        '
        Me.CbAlmacen_Categoria.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CbAlmacen_Categoria.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CbAlmacen_Categoria.FormattingEnabled = True
        Me.CbAlmacen_Categoria.Location = New System.Drawing.Point(28, 123)
        Me.CbAlmacen_Categoria.Name = "CbAlmacen_Categoria"
        Me.CbAlmacen_Categoria.Size = New System.Drawing.Size(267, 24)
        Me.CbAlmacen_Categoria.TabIndex = 35
        Me.CbAlmacen_Categoria.Tag = "ENABLED"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(24, 107)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(102, 13)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "Filtrar por familia de"
        '
        'rbtAlmacen_Agrupado
        '
        Me.rbtAlmacen_Agrupado.AutoSize = True
        Me.rbtAlmacen_Agrupado.Location = New System.Drawing.Point(19, 39)
        Me.rbtAlmacen_Agrupado.Name = "rbtAlmacen_Agrupado"
        Me.rbtAlmacen_Agrupado.Size = New System.Drawing.Size(220, 17)
        Me.rbtAlmacen_Agrupado.TabIndex = 1
        Me.rbtAlmacen_Agrupado.Text = "Listado de Almacén Agrupado por Familia"
        Me.rbtAlmacen_Agrupado.UseVisualStyleBackColor = True
        '
        'rbtAlmacen_Simple
        '
        Me.rbtAlmacen_Simple.AutoSize = True
        Me.rbtAlmacen_Simple.Checked = True
        Me.rbtAlmacen_Simple.Location = New System.Drawing.Point(19, 16)
        Me.rbtAlmacen_Simple.Name = "rbtAlmacen_Simple"
        Me.rbtAlmacen_Simple.Size = New System.Drawing.Size(152, 17)
        Me.rbtAlmacen_Simple.TabIndex = 0
        Me.rbtAlmacen_Simple.TabStop = True
        Me.rbtAlmacen_Simple.Text = "Listado de Almacen Simple"
        Me.rbtAlmacen_Simple.UseVisualStyleBackColor = True
        '
        'groupAlmacen_Estocable
        '
        Me.groupAlmacen_Estocable.Controls.Add(Me.Rbt_Stock_05)
        Me.groupAlmacen_Estocable.Controls.Add(Me.Rbt_Stock_01)
        Me.groupAlmacen_Estocable.Controls.Add(Me.Rbt_Stock_04)
        Me.groupAlmacen_Estocable.Controls.Add(Me.Rbt_Stock_02)
        Me.groupAlmacen_Estocable.Controls.Add(Me.Rbt_Stock_03)
        Me.groupAlmacen_Estocable.Enabled = False
        Me.groupAlmacen_Estocable.Location = New System.Drawing.Point(19, 162)
        Me.groupAlmacen_Estocable.Name = "groupAlmacen_Estocable"
        Me.groupAlmacen_Estocable.Size = New System.Drawing.Size(349, 88)
        Me.groupAlmacen_Estocable.TabIndex = 38
        Me.groupAlmacen_Estocable.TabStop = False
        '
        'Rbt_Stock_05
        '
        Me.Rbt_Stock_05.AutoSize = True
        Me.Rbt_Stock_05.Location = New System.Drawing.Point(189, 63)
        Me.Rbt_Stock_05.Name = "Rbt_Stock_05"
        Me.Rbt_Stock_05.Size = New System.Drawing.Size(134, 17)
        Me.Rbt_Stock_05.TabIndex = 4
        Me.Rbt_Stock_05.Tag = "4"
        Me.Rbt_Stock_05.Text = "Bajo unidades mínimas"
        Me.Rbt_Stock_05.UseVisualStyleBackColor = True
        '
        'Rbt_Stock_01
        '
        Me.Rbt_Stock_01.AutoSize = True
        Me.Rbt_Stock_01.Checked = True
        Me.Rbt_Stock_01.Location = New System.Drawing.Point(18, 17)
        Me.Rbt_Stock_01.Name = "Rbt_Stock_01"
        Me.Rbt_Stock_01.Size = New System.Drawing.Size(105, 17)
        Me.Rbt_Stock_01.TabIndex = 0
        Me.Rbt_Stock_01.TabStop = True
        Me.Rbt_Stock_01.Tag = "0"
        Me.Rbt_Stock_01.Text = "Todo el Almacén"
        Me.Rbt_Stock_01.UseVisualStyleBackColor = True
        '
        'Rbt_Stock_04
        '
        Me.Rbt_Stock_04.AutoSize = True
        Me.Rbt_Stock_04.Location = New System.Drawing.Point(18, 63)
        Me.Rbt_Stock_04.Name = "Rbt_Stock_04"
        Me.Rbt_Stock_04.Size = New System.Drawing.Size(131, 17)
        Me.Rbt_Stock_04.TabIndex = 3
        Me.Rbt_Stock_04.Tag = "3"
        Me.Rbt_Stock_04.Text = "Bajo unidades optimas"
        Me.Rbt_Stock_04.UseVisualStyleBackColor = True
        '
        'Rbt_Stock_02
        '
        Me.Rbt_Stock_02.AutoSize = True
        Me.Rbt_Stock_02.Location = New System.Drawing.Point(18, 40)
        Me.Rbt_Stock_02.Name = "Rbt_Stock_02"
        Me.Rbt_Stock_02.Size = New System.Drawing.Size(95, 17)
        Me.Rbt_Stock_02.TabIndex = 1
        Me.Rbt_Stock_02.Tag = "1"
        Me.Rbt_Stock_02.Text = "Sin existencias"
        Me.Rbt_Stock_02.UseVisualStyleBackColor = True
        '
        'Rbt_Stock_03
        '
        Me.Rbt_Stock_03.AutoSize = True
        Me.Rbt_Stock_03.Location = New System.Drawing.Point(189, 40)
        Me.Rbt_Stock_03.Name = "Rbt_Stock_03"
        Me.Rbt_Stock_03.Size = New System.Drawing.Size(99, 17)
        Me.Rbt_Stock_03.TabIndex = 2
        Me.Rbt_Stock_03.Tag = "2"
        Me.Rbt_Stock_03.Text = "Con existencias"
        Me.Rbt_Stock_03.UseVisualStyleBackColor = True
        '
        'groupCajas
        '
        Me.groupCajas.Controls.Add(Me.rbtCaja_Resumen)
        Me.groupCajas.Controls.Add(Me.RadioButton1)
        Me.groupCajas.Controls.Add(Me.rbtCaja_Actual)
        Me.groupCajas.Controls.Add(Me.rbtCaja_ConsumoID)
        Me.groupCajas.Controls.Add(Me.RadioButton6)
        Me.groupCajas.Controls.Add(Me.RadioButton3)
        Me.groupCajas.Controls.Add(Me.RadioButton2)
        Me.groupCajas.Controls.Add(Me.rbtCajas_Consumo)
        Me.groupCajas.Controls.Add(Me.rbtCaja_UsuarioDetallado)
        Me.groupCajas.Controls.Add(Me.groupCajas_fh)
        Me.groupCajas.Controls.Add(Me.RadioButton7)
        Me.groupCajas.Controls.Add(Me.rbtCajas_Consumiciones)
        Me.groupCajas.Controls.Add(Me.rbtCaja_TicketsDia)
        Me.groupCajas.Controls.Add(Me.rbtCajas_UsuarioEntradas)
        Me.groupCajas.Controls.Add(Me.rbtCaja_Usuario)
        Me.groupCajas.Controls.Add(Me.rbtCaja_Simple)
        Me.groupCajas.Controls.Add(Me.groupResumenCaja)
        Me.groupCajas.Controls.Add(Me.GroupBox1)
        Me.groupCajas.Enabled = False
        Me.groupCajas.Location = New System.Drawing.Point(445, 82)
        Me.groupCajas.Name = "groupCajas"
        Me.groupCajas.Size = New System.Drawing.Size(447, 434)
        Me.groupCajas.TabIndex = 4
        Me.groupCajas.TabStop = False
        Me.groupCajas.Text = "Tipo de listado"
        '
        'rbtCaja_Resumen
        '
        Me.rbtCaja_Resumen.AutoSize = True
        Me.rbtCaja_Resumen.Location = New System.Drawing.Point(19, 39)
        Me.rbtCaja_Resumen.Name = "rbtCaja_Resumen"
        Me.rbtCaja_Resumen.Size = New System.Drawing.Size(237, 17)
        Me.rbtCaja_Resumen.TabIndex = 34
        Me.rbtCaja_Resumen.Text = "Resumen de Caja por conceptos (imp. ticket)"
        Me.rbtCaja_Resumen.UseVisualStyleBackColor = True
        '
        'RadioButton1
        '
        Me.RadioButton1.AutoSize = True
        Me.RadioButton1.Location = New System.Drawing.Point(19, 62)
        Me.RadioButton1.Name = "RadioButton1"
        Me.RadioButton1.Size = New System.Drawing.Size(198, 17)
        Me.RadioButton1.TabIndex = 33
        Me.RadioButton1.Text = "Listado de Tickets impresos por Caja"
        Me.RadioButton1.UseVisualStyleBackColor = True
        '
        'rbtCaja_Actual
        '
        Me.rbtCaja_Actual.AutoSize = True
        Me.rbtCaja_Actual.Location = New System.Drawing.Point(263, 39)
        Me.rbtCaja_Actual.Name = "rbtCaja_Actual"
        Me.rbtCaja_Actual.Size = New System.Drawing.Size(79, 17)
        Me.rbtCaja_Actual.TabIndex = 32
        Me.rbtCaja_Actual.Text = "Caja Actual"
        Me.rbtCaja_Actual.UseVisualStyleBackColor = True
        '
        'rbtCaja_ConsumoID
        '
        Me.rbtCaja_ConsumoID.AutoSize = True
        Me.rbtCaja_ConsumoID.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbtCaja_ConsumoID.Location = New System.Drawing.Point(25, 390)
        Me.rbtCaja_ConsumoID.Name = "rbtCaja_ConsumoID"
        Me.rbtCaja_ConsumoID.Size = New System.Drawing.Size(263, 24)
        Me.rbtCaja_ConsumoID.TabIndex = 28
        Me.rbtCaja_ConsumoID.Text = "Resumen por Referencia de Caja"
        Me.rbtCaja_ConsumoID.UseVisualStyleBackColor = True
        '
        'RadioButton6
        '
        Me.RadioButton6.AutoSize = True
        Me.RadioButton6.Enabled = False
        Me.RadioButton6.Location = New System.Drawing.Point(263, 143)
        Me.RadioButton6.Name = "RadioButton6"
        Me.RadioButton6.Size = New System.Drawing.Size(187, 17)
        Me.RadioButton6.TabIndex = 25
        Me.RadioButton6.Text = "Acumulado de artículos en pedido"
        Me.RadioButton6.UseVisualStyleBackColor = True
        '
        'RadioButton3
        '
        Me.RadioButton3.AutoSize = True
        Me.RadioButton3.Enabled = False
        Me.RadioButton3.Location = New System.Drawing.Point(263, 119)
        Me.RadioButton3.Name = "RadioButton3"
        Me.RadioButton3.Size = New System.Drawing.Size(133, 17)
        Me.RadioButton3.TabIndex = 24
        Me.RadioButton3.Text = "Pedidos por Repartidor"
        Me.RadioButton3.UseVisualStyleBackColor = True
        '
        'RadioButton2
        '
        Me.RadioButton2.AutoSize = True
        Me.RadioButton2.Enabled = False
        Me.RadioButton2.Location = New System.Drawing.Point(263, 96)
        Me.RadioButton2.Name = "RadioButton2"
        Me.RadioButton2.Size = New System.Drawing.Size(128, 17)
        Me.RadioButton2.TabIndex = 23
        Me.RadioButton2.Text = "Pedidos en modo lista"
        Me.RadioButton2.UseVisualStyleBackColor = True
        Me.RadioButton2.Visible = False
        '
        'rbtCajas_Consumo
        '
        Me.rbtCajas_Consumo.AutoSize = True
        Me.rbtCajas_Consumo.Location = New System.Drawing.Point(19, 177)
        Me.rbtCajas_Consumo.Name = "rbtCajas_Consumo"
        Me.rbtCajas_Consumo.Size = New System.Drawing.Size(207, 17)
        Me.rbtCajas_Consumo.TabIndex = 11
        Me.rbtCajas_Consumo.Text = "Listado de consumo por fecha de Caja"
        Me.rbtCajas_Consumo.UseVisualStyleBackColor = True
        '
        'rbtCaja_UsuarioDetallado
        '
        Me.rbtCaja_UsuarioDetallado.AutoSize = True
        Me.rbtCaja_UsuarioDetallado.Location = New System.Drawing.Point(19, 131)
        Me.rbtCaja_UsuarioDetallado.Name = "rbtCaja_UsuarioDetallado"
        Me.rbtCaja_UsuarioDetallado.Size = New System.Drawing.Size(154, 17)
        Me.rbtCaja_UsuarioDetallado.TabIndex = 10
        Me.rbtCaja_UsuarioDetallado.Text = "Usuarios por Caja detallado"
        Me.rbtCaja_UsuarioDetallado.UseVisualStyleBackColor = True
        '
        'groupCajas_fh
        '
        Me.groupCajas_fh.Controls.Add(Me.FhCaja_Desde)
        Me.groupCajas_fh.Controls.Add(Me.Label3)
        Me.groupCajas_fh.Controls.Add(Me.Label2)
        Me.groupCajas_fh.Controls.Add(Me.FhCaja_Hasta)
        Me.groupCajas_fh.Location = New System.Drawing.Point(25, 281)
        Me.groupCajas_fh.Name = "groupCajas_fh"
        Me.groupCajas_fh.Size = New System.Drawing.Size(416, 87)
        Me.groupCajas_fh.TabIndex = 4
        Me.groupCajas_fh.TabStop = False
        Me.groupCajas_fh.Text = "Entre Fechas de Cajas"
        '
        'FhCaja_Desde
        '
        Me.FhCaja_Desde.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FhCaja_Desde.Location = New System.Drawing.Point(76, 18)
        Me.FhCaja_Desde.Name = "FhCaja_Desde"
        Me.FhCaja_Desde.Size = New System.Drawing.Size(305, 26)
        Me.FhCaja_Desde.TabIndex = 0
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(21, 59)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(44, 16)
        Me.Label3.TabIndex = 3
        Me.Label3.Text = "Hasta"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(21, 24)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(49, 16)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Desde"
        '
        'FhCaja_Hasta
        '
        Me.FhCaja_Hasta.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FhCaja_Hasta.Location = New System.Drawing.Point(76, 53)
        Me.FhCaja_Hasta.Name = "FhCaja_Hasta"
        Me.FhCaja_Hasta.Size = New System.Drawing.Size(305, 26)
        Me.FhCaja_Hasta.TabIndex = 2
        '
        'RadioButton7
        '
        Me.RadioButton7.AutoSize = True
        Me.RadioButton7.Enabled = False
        Me.RadioButton7.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RadioButton7.Location = New System.Drawing.Point(263, 166)
        Me.RadioButton7.Name = "RadioButton7"
        Me.RadioButton7.Size = New System.Drawing.Size(146, 17)
        Me.RadioButton7.TabIndex = 8
        Me.RadioButton7.Text = "Impresora de Tickets"
        Me.RadioButton7.UseVisualStyleBackColor = True
        Me.RadioButton7.Visible = False
        '
        'rbtCajas_Consumiciones
        '
        Me.rbtCajas_Consumiciones.AutoSize = True
        Me.rbtCajas_Consumiciones.Location = New System.Drawing.Point(263, 16)
        Me.rbtCajas_Consumiciones.Name = "rbtCajas_Consumiciones"
        Me.rbtCajas_Consumiciones.Size = New System.Drawing.Size(151, 17)
        Me.rbtCajas_Consumiciones.TabIndex = 7
        Me.rbtCajas_Consumiciones.Text = "Entrega de Consumiciones"
        Me.rbtCajas_Consumiciones.UseVisualStyleBackColor = True
        '
        'rbtCaja_TicketsDia
        '
        Me.rbtCaja_TicketsDia.AutoSize = True
        Me.rbtCaja_TicketsDia.Location = New System.Drawing.Point(19, 85)
        Me.rbtCaja_TicketsDia.Name = "rbtCaja_TicketsDia"
        Me.rbtCaja_TicketsDia.Size = New System.Drawing.Size(202, 17)
        Me.rbtCaja_TicketsDia.TabIndex = 3
        Me.rbtCaja_TicketsDia.Text = "Listado de Tickets agrupado por Caja"
        Me.rbtCaja_TicketsDia.UseVisualStyleBackColor = True
        '
        'rbtCajas_UsuarioEntradas
        '
        Me.rbtCajas_UsuarioEntradas.AutoSize = True
        Me.rbtCajas_UsuarioEntradas.Location = New System.Drawing.Point(19, 154)
        Me.rbtCajas_UsuarioEntradas.Name = "rbtCajas_UsuarioEntradas"
        Me.rbtCajas_UsuarioEntradas.Size = New System.Drawing.Size(120, 17)
        Me.rbtCajas_UsuarioEntradas.TabIndex = 2
        Me.rbtCajas_UsuarioEntradas.Text = "Accesos de Usuario"
        Me.rbtCajas_UsuarioEntradas.UseVisualStyleBackColor = True
        '
        'rbtCaja_Usuario
        '
        Me.rbtCaja_Usuario.AutoSize = True
        Me.rbtCaja_Usuario.Location = New System.Drawing.Point(19, 108)
        Me.rbtCaja_Usuario.Name = "rbtCaja_Usuario"
        Me.rbtCaja_Usuario.Size = New System.Drawing.Size(108, 17)
        Me.rbtCaja_Usuario.TabIndex = 1
        Me.rbtCaja_Usuario.Text = "Usuarios por Caja"
        Me.rbtCaja_Usuario.UseVisualStyleBackColor = True
        '
        'rbtCaja_Simple
        '
        Me.rbtCaja_Simple.AutoSize = True
        Me.rbtCaja_Simple.Checked = True
        Me.rbtCaja_Simple.Location = New System.Drawing.Point(19, 16)
        Me.rbtCaja_Simple.Name = "rbtCaja_Simple"
        Me.rbtCaja_Simple.Size = New System.Drawing.Size(103, 17)
        Me.rbtCaja_Simple.TabIndex = 0
        Me.rbtCaja_Simple.TabStop = True
        Me.rbtCaja_Simple.Text = "Listado de Cajas"
        Me.rbtCaja_Simple.UseVisualStyleBackColor = True
        '
        'groupResumenCaja
        '
        Me.groupResumenCaja.Controls.Add(Me.txtCajaID)
        Me.groupResumenCaja.Location = New System.Drawing.Point(9, 376)
        Me.groupResumenCaja.Name = "groupResumenCaja"
        Me.groupResumenCaja.Size = New System.Drawing.Size(428, 52)
        Me.groupResumenCaja.TabIndex = 30
        Me.groupResumenCaja.TabStop = False
        '
        'txtCajaID
        '
        Me.txtCajaID.Enabled = False
        Me.txtCajaID.Font = New System.Drawing.Font("Tahoma", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCajaID.Location = New System.Drawing.Point(296, 11)
        Me.txtCajaID.Name = "txtCajaID"
        Me.txtCajaID.Size = New System.Drawing.Size(124, 30)
        Me.txtCajaID.TabIndex = 29
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.chkCajas_SoloTickets)
        Me.GroupBox1.Controls.Add(Me.GroupBox2)
        Me.GroupBox1.Controls.Add(Me.chkResumenConcepto)
        Me.GroupBox1.Controls.Add(Me.chkPrintTicket)
        Me.GroupBox1.Controls.Add(Me.chkResumenPedidos)
        Me.GroupBox1.Location = New System.Drawing.Point(46, 182)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(391, 90)
        Me.GroupBox1.TabIndex = 31
        Me.GroupBox1.TabStop = False
        '
        'chkCajas_SoloTickets
        '
        Me.chkCajas_SoloTickets.AutoSize = True
        Me.chkCajas_SoloTickets.Location = New System.Drawing.Point(9, 69)
        Me.chkCajas_SoloTickets.Name = "chkCajas_SoloTickets"
        Me.chkCajas_SoloTickets.Size = New System.Drawing.Size(148, 17)
        Me.chkCajas_SoloTickets.TabIndex = 29
        Me.chkCajas_SoloTickets.Text = "Filtrar por fecha de tickets"
        Me.chkCajas_SoloTickets.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.rbtCajas_Consumo_Local)
        Me.GroupBox2.Controls.Add(Me.rbtCajas_Consumo_Estanco)
        Me.GroupBox2.Controls.Add(Me.rbtCajas_Consumo_Pedidos)
        Me.GroupBox2.Location = New System.Drawing.Point(192, 31)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(193, 55)
        Me.GroupBox2.TabIndex = 28
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Opciones"
        '
        'rbtCajas_Consumo_Local
        '
        Me.rbtCajas_Consumo_Local.AutoSize = True
        Me.rbtCajas_Consumo_Local.Location = New System.Drawing.Point(102, 15)
        Me.rbtCajas_Consumo_Local.Name = "rbtCajas_Consumo_Local"
        Me.rbtCajas_Consumo_Local.Size = New System.Drawing.Size(75, 17)
        Me.rbtCajas_Consumo_Local.TabIndex = 5
        Me.rbtCajas_Consumo_Local.Text = "Solo Local"
        Me.rbtCajas_Consumo_Local.UseVisualStyleBackColor = True
        '
        'rbtCajas_Consumo_Estanco
        '
        Me.rbtCajas_Consumo_Estanco.AutoSize = True
        Me.rbtCajas_Consumo_Estanco.Location = New System.Drawing.Point(10, 33)
        Me.rbtCajas_Consumo_Estanco.Name = "rbtCajas_Consumo_Estanco"
        Me.rbtCajas_Consumo_Estanco.Size = New System.Drawing.Size(88, 17)
        Me.rbtCajas_Consumo_Estanco.TabIndex = 4
        Me.rbtCajas_Consumo_Estanco.Text = "Solo Estanco"
        Me.rbtCajas_Consumo_Estanco.UseVisualStyleBackColor = True
        '
        'rbtCajas_Consumo_Pedidos
        '
        Me.rbtCajas_Consumo_Pedidos.AutoSize = True
        Me.rbtCajas_Consumo_Pedidos.Enabled = False
        Me.rbtCajas_Consumo_Pedidos.Location = New System.Drawing.Point(10, 15)
        Me.rbtCajas_Consumo_Pedidos.Name = "rbtCajas_Consumo_Pedidos"
        Me.rbtCajas_Consumo_Pedidos.Size = New System.Drawing.Size(87, 17)
        Me.rbtCajas_Consumo_Pedidos.TabIndex = 3
        Me.rbtCajas_Consumo_Pedidos.Text = "Solo Pedidos"
        Me.rbtCajas_Consumo_Pedidos.UseVisualStyleBackColor = True
        '
        'chkResumenConcepto
        '
        Me.chkResumenConcepto.AutoSize = True
        Me.chkResumenConcepto.Checked = True
        Me.chkResumenConcepto.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkResumenConcepto.Enabled = False
        Me.chkResumenConcepto.Location = New System.Drawing.Point(9, 15)
        Me.chkResumenConcepto.Name = "chkResumenConcepto"
        Me.chkResumenConcepto.Size = New System.Drawing.Size(173, 17)
        Me.chkResumenConcepto.TabIndex = 26
        Me.chkResumenConcepto.Text = "Generar resumen por concepto"
        Me.chkResumenConcepto.UseVisualStyleBackColor = True
        '
        'chkPrintTicket
        '
        Me.chkPrintTicket.AutoSize = True
        Me.chkPrintTicket.Enabled = False
        Me.chkPrintTicket.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkPrintTicket.Location = New System.Drawing.Point(198, 11)
        Me.chkPrintTicket.Name = "chkPrintTicket"
        Me.chkPrintTicket.Size = New System.Drawing.Size(192, 16)
        Me.chkPrintTicket.TabIndex = 22
        Me.chkPrintTicket.Text = "Generar por Impresora de Tickets"
        Me.chkPrintTicket.UseVisualStyleBackColor = True
        '
        'chkResumenPedidos
        '
        Me.chkResumenPedidos.AutoSize = True
        Me.chkResumenPedidos.Enabled = False
        Me.chkResumenPedidos.Location = New System.Drawing.Point(9, 35)
        Me.chkResumenPedidos.Name = "chkResumenPedidos"
        Me.chkResumenPedidos.Size = New System.Drawing.Size(162, 17)
        Me.chkResumenPedidos.TabIndex = 27
        Me.chkResumenPedidos.Text = "Generar resumen de pedidos"
        Me.chkResumenPedidos.UseVisualStyleBackColor = True
        '
        'PicImg_gDev
        '
        Me.PicImg_gDev.BackColor = System.Drawing.Color.White
        Me.PicImg_gDev.Cursor = System.Windows.Forms.Cursors.Help
        Me.PicImg_gDev.Image = CType(resources.GetObject("PicImg_gDev.Image"), System.Drawing.Image)
        Me.PicImg_gDev.Location = New System.Drawing.Point(829, 52)
        Me.PicImg_gDev.Name = "PicImg_gDev"
        Me.PicImg_gDev.Size = New System.Drawing.Size(89, 27)
        Me.PicImg_gDev.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PicImg_gDev.TabIndex = 21
        Me.PicImg_gDev.TabStop = False
        '
        'groupFacturacion
        '
        Me.groupFacturacion.Controls.Add(Me.rbtFacturacion_FtraCompras_ACT)
        Me.groupFacturacion.Controls.Add(Me.GroupBox6)
        Me.groupFacturacion.Controls.Add(Me.rbtFacturacion_Facturas)
        Me.groupFacturacion.Controls.Add(Me.rbtFacturacion_FtraCompras)
        Me.groupFacturacion.Enabled = False
        Me.groupFacturacion.Location = New System.Drawing.Point(24, 495)
        Me.groupFacturacion.Name = "groupFacturacion"
        Me.groupFacturacion.Size = New System.Drawing.Size(408, 91)
        Me.groupFacturacion.TabIndex = 6
        Me.groupFacturacion.TabStop = False
        Me.groupFacturacion.Text = "Tipo de listado"
        '
        'GroupBox6
        '
        Me.GroupBox6.Controls.Add(Me.FhDesde_Facturas)
        Me.GroupBox6.Controls.Add(Me.Label4)
        Me.GroupBox6.Controls.Add(Me.Label5)
        Me.GroupBox6.Controls.Add(Me.FhHasta_Facturas)
        Me.GroupBox6.Location = New System.Drawing.Point(25, 35)
        Me.GroupBox6.Name = "GroupBox6"
        Me.GroupBox6.Size = New System.Drawing.Size(377, 48)
        Me.GroupBox6.TabIndex = 4
        Me.GroupBox6.TabStop = False
        Me.GroupBox6.Text = "Entre Fechas"
        '
        'FhDesde_Facturas
        '
        Me.FhDesde_Facturas.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FhDesde_Facturas.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.FhDesde_Facturas.Location = New System.Drawing.Point(54, 16)
        Me.FhDesde_Facturas.Name = "FhDesde_Facturas"
        Me.FhDesde_Facturas.Size = New System.Drawing.Size(122, 22)
        Me.FhDesde_Facturas.TabIndex = 0
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(195, 23)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(35, 13)
        Me.Label4.TabIndex = 3
        Me.Label4.Text = "Hasta"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(10, 24)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(38, 13)
        Me.Label5.TabIndex = 1
        Me.Label5.Text = "Desde"
        '
        'FhHasta_Facturas
        '
        Me.FhHasta_Facturas.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FhHasta_Facturas.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.FhHasta_Facturas.Location = New System.Drawing.Point(239, 15)
        Me.FhHasta_Facturas.Name = "FhHasta_Facturas"
        Me.FhHasta_Facturas.Size = New System.Drawing.Size(122, 22)
        Me.FhHasta_Facturas.TabIndex = 2
        '
        'rbtFacturacion_Facturas
        '
        Me.rbtFacturacion_Facturas.AutoSize = True
        Me.rbtFacturacion_Facturas.Enabled = False
        Me.rbtFacturacion_Facturas.Location = New System.Drawing.Point(235, 16)
        Me.rbtFacturacion_Facturas.Name = "rbtFacturacion_Facturas"
        Me.rbtFacturacion_Facturas.Size = New System.Drawing.Size(167, 17)
        Me.rbtFacturacion_Facturas.TabIndex = 1
        Me.rbtFacturacion_Facturas.Text = "Listado de Facturas a Clientes"
        Me.rbtFacturacion_Facturas.UseVisualStyleBackColor = True
        '
        'rbtFacturacion_FtraCompras
        '
        Me.rbtFacturacion_FtraCompras.AutoSize = True
        Me.rbtFacturacion_FtraCompras.Checked = True
        Me.rbtFacturacion_FtraCompras.Location = New System.Drawing.Point(10, 16)
        Me.rbtFacturacion_FtraCompras.Name = "rbtFacturacion_FtraCompras"
        Me.rbtFacturacion_FtraCompras.Size = New System.Drawing.Size(172, 17)
        Me.rbtFacturacion_FtraCompras.TabIndex = 0
        Me.rbtFacturacion_FtraCompras.TabStop = True
        Me.rbtFacturacion_FtraCompras.Text = "Listado de Facturas de Compra"
        Me.rbtFacturacion_FtraCompras.UseVisualStyleBackColor = True
        '
        'PnlTipoB
        '
        Me.PnlTipoB.Controls.Add(Me.CbTipo)
        Me.PnlTipoB.Controls.Add(Me.Label6)
        Me.PnlTipoB.Location = New System.Drawing.Point(585, 550)
        Me.PnlTipoB.Name = "PnlTipoB"
        Me.PnlTipoB.Size = New System.Drawing.Size(209, 28)
        Me.PnlTipoB.TabIndex = 7
        Me.PnlTipoB.Visible = False
        '
        'CbTipo
        '
        Me.CbTipo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CbTipo.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CbTipo.FormattingEnabled = True
        Me.CbTipo.Items.AddRange(New Object() {"A", "B"})
        Me.CbTipo.Location = New System.Drawing.Point(133, 0)
        Me.CbTipo.Name = "CbTipo"
        Me.CbTipo.Size = New System.Drawing.Size(69, 24)
        Me.CbTipo.TabIndex = 6
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(6, 3)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(121, 16)
        Me.Label6.TabIndex = 5
        Me.Label6.Text = "Tipo de Facturación"
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
        Me.SplitContainer.Panel2.BackColor = System.Drawing.Color.Black
        Me.SplitContainer.Panel2.Controls.Add(Me.PnlBody)
        Me.SplitContainer.Panel2.Tag = "233; 248; 250"
        Me.SplitContainer.Size = New System.Drawing.Size(1020, 754)
        Me.SplitContainer.SplitterDistance = 64
        Me.SplitContainer.SplitterWidth = 1
        Me.SplitContainer.TabIndex = 2
        '
        'm_logo
        '
        Me.m_logo.Image = CType(resources.GetObject("m_logo.Image"), System.Drawing.Image)
        Me.m_logo.Location = New System.Drawing.Point(3, 3)
        Me.m_logo.Name = "m_logo"
        Me.m_logo.Size = New System.Drawing.Size(48, 47)
        Me.m_logo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.m_logo.TabIndex = 32
        Me.m_logo.TabStop = False
        '
        'PnlButton_Shell
        '
        Me.PnlButton_Shell.Controls.Add(Me.BtClose)
        Me.PnlButton_Shell.Controls.Add(Me.BtGenerar)
        Me.PnlButton_Shell.Controls.Add(Me.BtMin)
        Me.PnlButton_Shell.Dock = System.Windows.Forms.DockStyle.Right
        Me.PnlButton_Shell.Location = New System.Drawing.Point(470, 0)
        Me.PnlButton_Shell.Name = "PnlButton_Shell"
        Me.PnlButton_Shell.Size = New System.Drawing.Size(550, 64)
        Me.PnlButton_Shell.TabIndex = 2
        '
        'BtClose
        '
        Me.BtClose.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.BtClose.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtClose.Image = CType(resources.GetObject("BtClose.Image"), System.Drawing.Image)
        Me.BtClose.Location = New System.Drawing.Point(368, 4)
        Me.BtClose.Name = "BtClose"
        Me.BtClose.Size = New System.Drawing.Size(170, 58)
        Me.BtClose.TabIndex = 7
        Me.BtClose.Tag = "close"
        Me.BtClose.Text = "Cerrar"
        Me.BtClose.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.BtClose.UseVisualStyleBackColor = True
        '
        'BtGenerar
        '
        Me.BtGenerar.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.BtGenerar.Font = New System.Drawing.Font("Tahoma", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtGenerar.Image = CType(resources.GetObject("BtGenerar.Image"), System.Drawing.Image)
        Me.BtGenerar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtGenerar.Location = New System.Drawing.Point(176, 3)
        Me.BtGenerar.Name = "BtGenerar"
        Me.BtGenerar.Size = New System.Drawing.Size(185, 64)
        Me.BtGenerar.TabIndex = 134
        Me.BtGenerar.Tag = ""
        Me.BtGenerar.Text = "Generar y " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Previsualizar"
        Me.BtGenerar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BtGenerar.UseVisualStyleBackColor = False
        '
        'BtMin
        '
        Me.BtMin.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.BtMin.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtMin.Image = CType(resources.GetObject("BtMin.Image"), System.Drawing.Image)
        Me.BtMin.Location = New System.Drawing.Point(3, 4)
        Me.BtMin.Name = "BtMin"
        Me.BtMin.Size = New System.Drawing.Size(170, 58)
        Me.BtMin.TabIndex = 6
        Me.BtMin.Tag = "minimize"
        Me.BtMin.Text = "Minimizar"
        Me.BtMin.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.BtMin.UseVisualStyleBackColor = True
        Me.BtMin.Visible = False
        '
        'LblSubTitle
        '
        Me.LblSubTitle.ForeColor = System.Drawing.SystemColors.InactiveCaption
        Me.LblSubTitle.Location = New System.Drawing.Point(64, 30)
        Me.LblSubTitle.Name = "LblSubTitle"
        Me.LblSubTitle.Size = New System.Drawing.Size(321, 31)
        Me.LblSubTitle.TabIndex = 1
        Me.LblSubTitle.Text = "Gestión, configuración y personalización del software para la empresa"
        '
        'LblTitle
        '
        Me.LblTitle.AutoSize = True
        Me.LblTitle.Font = New System.Drawing.Font("Tahoma", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblTitle.Location = New System.Drawing.Point(57, 4)
        Me.LblTitle.Name = "LblTitle"
        Me.LblTitle.Size = New System.Drawing.Size(200, 23)
        Me.LblTitle.TabIndex = 0
        Me.LblTitle.Text = "Gestión de Empresa"
        '
        'PnlBody
        '
        Me.PnlBody.BackColor = System.Drawing.SystemColors.Control
        Me.PnlBody.BackgroundImage = CType(resources.GetObject("PnlBody.BackgroundImage"), System.Drawing.Image)
        Me.PnlBody.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PnlBody.Controls.Add(Me.Panel1)
        Me.PnlBody.ForeColor = System.Drawing.Color.Black
        Me.PnlBody.Location = New System.Drawing.Point(12, 14)
        Me.PnlBody.Name = "PnlBody"
        Me.PnlBody.Size = New System.Drawing.Size(981, 669)
        Me.PnlBody.TabIndex = 0
        Me.PnlBody.Visible = False
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(174, Byte), Integer), CType(CType(186, Byte), Integer), CType(CType(186, Byte), Integer))
        Me.Panel1.Controls.Add(Me.Tab)
        Me.Panel1.Location = New System.Drawing.Point(24, 24)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(932, 619)
        Me.Panel1.TabIndex = 136
        '
        'Tab
        '
        Me.Tab.Controls.Add(Me.TabPage_Generales)
        Me.Tab.Controls.Add(Me.TabPage_Operaciones)
        Me.Tab.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Tab.ImageList = Me.ImageList
        Me.Tab.Location = New System.Drawing.Point(0, 0)
        Me.Tab.Name = "Tab"
        Me.Tab.SelectedIndex = 0
        Me.Tab.Size = New System.Drawing.Size(932, 619)
        Me.Tab.TabIndex = 135
        '
        'TabPage_Generales
        '
        Me.TabPage_Generales.Controls.Add(PictureBox3)
        Me.TabPage_Generales.Controls.Add(PictureBox1)
        Me.TabPage_Generales.Controls.Add(Me.PnlTipoB)
        Me.TabPage_Generales.Controls.Add(Me.rbtTipo_Empresa)
        Me.TabPage_Generales.Controls.Add(Me.rbtTipo_Facturacion)
        Me.TabPage_Generales.Controls.Add(Me.rbtTipo_Caja)
        Me.TabPage_Generales.Controls.Add(Me.rbtTipo_Almacen)
        Me.TabPage_Generales.Controls.Add(Me.rbtTipo_General)
        Me.TabPage_Generales.Controls.Add(Me.PicImg_gDev)
        Me.TabPage_Generales.Controls.Add(Me.groupFacturacion)
        Me.TabPage_Generales.Controls.Add(Me.groupAlmacen)
        Me.TabPage_Generales.Controls.Add(Me.groupCajas)
        Me.TabPage_Generales.Controls.Add(Me.groupGenerales)
        Me.TabPage_Generales.Controls.Add(Me.Panel5)
        Me.TabPage_Generales.ImageIndex = 0
        Me.TabPage_Generales.Location = New System.Drawing.Point(4, 23)
        Me.TabPage_Generales.Name = "TabPage_Generales"
        Me.TabPage_Generales.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage_Generales.Size = New System.Drawing.Size(924, 592)
        Me.TabPage_Generales.TabIndex = 0
        Me.TabPage_Generales.Text = "Listados de Aplicación"
        Me.TabPage_Generales.UseVisualStyleBackColor = True
        '
        'rbtTipo_Empresa
        '
        Me.rbtTipo_Empresa.AutoSize = True
        Me.rbtTipo_Empresa.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbtTipo_Empresa.Location = New System.Drawing.Point(454, 526)
        Me.rbtTipo_Empresa.Name = "rbtTipo_Empresa"
        Me.rbtTipo_Empresa.Size = New System.Drawing.Size(177, 24)
        Me.rbtTipo_Empresa.TabIndex = 9
        Me.rbtTipo_Empresa.Text = "Listados de Empresa"
        Me.rbtTipo_Empresa.UseVisualStyleBackColor = True
        Me.rbtTipo_Empresa.Visible = False
        '
        'rbtTipo_Facturacion
        '
        Me.rbtTipo_Facturacion.AutoSize = True
        Me.rbtTipo_Facturacion.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbtTipo_Facturacion.Location = New System.Drawing.Point(8, 471)
        Me.rbtTipo_Facturacion.Name = "rbtTipo_Facturacion"
        Me.rbtTipo_Facturacion.Size = New System.Drawing.Size(190, 24)
        Me.rbtTipo_Facturacion.TabIndex = 7
        Me.rbtTipo_Facturacion.Text = "Facturación y Compras"
        Me.rbtTipo_Facturacion.UseVisualStyleBackColor = True
        '
        'rbtTipo_Caja
        '
        Me.rbtTipo_Caja.AutoSize = True
        Me.rbtTipo_Caja.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbtTipo_Caja.Location = New System.Drawing.Point(429, 52)
        Me.rbtTipo_Caja.Name = "rbtTipo_Caja"
        Me.rbtTipo_Caja.Size = New System.Drawing.Size(132, 24)
        Me.rbtTipo_Caja.TabIndex = 6
        Me.rbtTipo_Caja.Text = "Cajas y Tickets"
        Me.rbtTipo_Caja.UseVisualStyleBackColor = True
        '
        'rbtTipo_Almacen
        '
        Me.rbtTipo_Almacen.AutoSize = True
        Me.rbtTipo_Almacen.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbtTipo_Almacen.Location = New System.Drawing.Point(8, 176)
        Me.rbtTipo_Almacen.Name = "rbtTipo_Almacen"
        Me.rbtTipo_Almacen.Size = New System.Drawing.Size(175, 24)
        Me.rbtTipo_Almacen.TabIndex = 5
        Me.rbtTipo_Almacen.Text = "Listados de Almacén"
        Me.rbtTipo_Almacen.UseVisualStyleBackColor = True
        '
        'rbtTipo_General
        '
        Me.rbtTipo_General.AutoSize = True
        Me.rbtTipo_General.Checked = True
        Me.rbtTipo_General.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbtTipo_General.Location = New System.Drawing.Point(8, 52)
        Me.rbtTipo_General.Name = "rbtTipo_General"
        Me.rbtTipo_General.Size = New System.Drawing.Size(165, 24)
        Me.rbtTipo_General.TabIndex = 4
        Me.rbtTipo_General.TabStop = True
        Me.rbtTipo_General.Text = "Listados Generales"
        Me.rbtTipo_General.UseVisualStyleBackColor = True
        '
        'Panel5
        '
        Me.Panel5.BackColor = System.Drawing.SystemColors.InactiveCaption
        Me.Panel5.Controls.Add(Me.pbBar)
        Me.Panel5.Controls.Add(PictureBox7)
        Me.Panel5.Controls.Add(Me.PictureBox2)
        Me.Panel5.Controls.Add(Me.Label66)
        Me.Panel5.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel5.Location = New System.Drawing.Point(3, 3)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Size = New System.Drawing.Size(918, 41)
        Me.Panel5.TabIndex = 21
        '
        'pbBar
        '
        Me.pbBar.Location = New System.Drawing.Point(404, 15)
        Me.pbBar.Name = "pbBar"
        Me.pbBar.Size = New System.Drawing.Size(212, 23)
        Me.pbBar.TabIndex = 23
        Me.pbBar.Visible = False
        '
        'PictureBox2
        '
        Me.PictureBox2.Image = CType(resources.GetObject("PictureBox2.Image"), System.Drawing.Image)
        Me.PictureBox2.Location = New System.Drawing.Point(3, 3)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(48, 48)
        Me.PictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.PictureBox2.TabIndex = 38
        Me.PictureBox2.TabStop = False
        '
        'Label66
        '
        Me.Label66.AutoSize = True
        Me.Label66.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label66.Location = New System.Drawing.Point(57, 6)
        Me.Label66.Name = "Label66"
        Me.Label66.Size = New System.Drawing.Size(289, 19)
        Me.Label66.TabIndex = 7
        Me.Label66.Text = "Listados/Informes de la aplicación"
        '
        'TabPage_Operaciones
        '
        Me.TabPage_Operaciones.Location = New System.Drawing.Point(4, 23)
        Me.TabPage_Operaciones.Name = "TabPage_Operaciones"
        Me.TabPage_Operaciones.Size = New System.Drawing.Size(924, 592)
        Me.TabPage_Operaciones.TabIndex = 1
        Me.TabPage_Operaciones.Text = "Procesos"
        Me.TabPage_Operaciones.UseVisualStyleBackColor = True
        '
        'ImageList
        '
        Me.ImageList.ImageStream = CType(resources.GetObject("ImageList.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageList.Images.SetKeyName(0, "apps.png")
        Me.ImageList.Images.SetKeyName(1, "shop_cart.png")
        Me.ImageList.Images.SetKeyName(2, "calculator.png")
        Me.ImageList.Images.SetKeyName(3, "objects.png")
        Me.ImageList.Images.SetKeyName(4, "data.png")
        Me.ImageList.Images.SetKeyName(5, "paste.png")
        Me.ImageList.Images.SetKeyName(6, "note.png")
        Me.ImageList.Images.SetKeyName(7, "euro.png")
        '
        'rbtFacturacion_FtraCompras_ACT
        '
        Me.rbtFacturacion_FtraCompras_ACT.AutoSize = True
        Me.rbtFacturacion_FtraCompras_ACT.Location = New System.Drawing.Point(183, 16)
        Me.rbtFacturacion_FtraCompras_ACT.Name = "rbtFacturacion_FtraCompras_ACT"
        Me.rbtFacturacion_FtraCompras_ACT.Size = New System.Drawing.Size(46, 17)
        Me.rbtFacturacion_FtraCompras_ACT.TabIndex = 5
        Me.rbtFacturacion_FtraCompras_ACT.Text = "ACT"
        Me.rbtFacturacion_FtraCompras_ACT.UseVisualStyleBackColor = True
        '
        'frmGestion
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Black
        Me.ClientSize = New System.Drawing.Size(1020, 754)
        Me.Controls.Add(Me.SplitContainer)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "frmGestion"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(PictureBox7, System.ComponentModel.ISupportInitialize).EndInit()
        CType(PictureBox3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.groupGenerales.ResumeLayout(False)
        Me.groupGenerales.PerformLayout()
        Me.groupAlmacen.ResumeLayout(False)
        Me.groupAlmacen.PerformLayout()
        Me.groupAlmacen_Estocable.ResumeLayout(False)
        Me.groupAlmacen_Estocable.PerformLayout()
        Me.groupCajas.ResumeLayout(False)
        Me.groupCajas.PerformLayout()
        Me.groupCajas_fh.ResumeLayout(False)
        Me.groupCajas_fh.PerformLayout()
        Me.groupResumenCaja.ResumeLayout(False)
        Me.groupResumenCaja.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        CType(Me.PicImg_gDev, System.ComponentModel.ISupportInitialize).EndInit()
        Me.groupFacturacion.ResumeLayout(False)
        Me.groupFacturacion.PerformLayout()
        Me.GroupBox6.ResumeLayout(False)
        Me.GroupBox6.PerformLayout()
        Me.PnlTipoB.ResumeLayout(False)
        Me.PnlTipoB.PerformLayout()
        Me.SplitContainer.Panel1.ResumeLayout(False)
        Me.SplitContainer.Panel1.PerformLayout()
        Me.SplitContainer.Panel2.ResumeLayout(False)
        Me.SplitContainer.ResumeLayout(False)
        CType(Me.m_logo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PnlButton_Shell.ResumeLayout(False)
        Me.PnlBody.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.Tab.ResumeLayout(False)
        Me.TabPage_Generales.ResumeLayout(False)
        Me.TabPage_Generales.PerformLayout()
        Me.Panel5.ResumeLayout(False)
        Me.Panel5.PerformLayout()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents SplitContainer As System.Windows.Forms.SplitContainer
    Friend WithEvents m_logo As System.Windows.Forms.PictureBox
    Friend WithEvents PnlButton_Shell As System.Windows.Forms.Panel
    Friend WithEvents BtClose As System.Windows.Forms.Button
    Friend WithEvents BtMin As System.Windows.Forms.Button
    Friend WithEvents LblSubTitle As System.Windows.Forms.Label
    Friend WithEvents LblTitle As System.Windows.Forms.Label
    Friend WithEvents PnlBody As System.Windows.Forms.Panel
    Friend WithEvents BtGenerar As System.Windows.Forms.Button
    Friend WithEvents Tab As System.Windows.Forms.TabControl
    Friend WithEvents TabPage_Generales As System.Windows.Forms.TabPage
    Friend WithEvents rbtGenerales_Prov As System.Windows.Forms.RadioButton
    Friend WithEvents rbtGenerales_Clientes As System.Windows.Forms.RadioButton
    Friend WithEvents ImageList As System.Windows.Forms.ImageList
    Friend WithEvents rbtGenerales_Usuarios As System.Windows.Forms.RadioButton
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents rbtAlmacen_Agrupado As System.Windows.Forms.RadioButton
    Friend WithEvents rbtAlmacen_Simple As System.Windows.Forms.RadioButton
    Friend WithEvents CbAlmacen_Categoria As System.Windows.Forms.ComboBox
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents rbtCajas_UsuarioEntradas As System.Windows.Forms.RadioButton
    Friend WithEvents rbtCaja_Usuario As System.Windows.Forms.RadioButton
    Friend WithEvents rbtCaja_Simple As System.Windows.Forms.RadioButton
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents FhCaja_Hasta As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents FhCaja_Desde As System.Windows.Forms.DateTimePicker
    Friend WithEvents groupCajas_fh As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox6 As System.Windows.Forms.GroupBox
    Friend WithEvents FhDesde_Facturas As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents FhHasta_Facturas As System.Windows.Forms.DateTimePicker
    Friend WithEvents rbtFacturacion_Facturas As System.Windows.Forms.RadioButton
    Friend WithEvents rbtFacturacion_FtraCompras As System.Windows.Forms.RadioButton
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents PnlTipoB As System.Windows.Forms.Panel
    Friend WithEvents CbTipo As System.Windows.Forms.ComboBox
    Friend WithEvents rbtCaja_TicketsDia As System.Windows.Forms.RadioButton
    Friend WithEvents rbtTipo_Caja As System.Windows.Forms.RadioButton
    Friend WithEvents rbtTipo_Almacen As System.Windows.Forms.RadioButton
    Friend WithEvents rbtTipo_General As System.Windows.Forms.RadioButton
    Friend WithEvents rbtTipo_Facturacion As System.Windows.Forms.RadioButton
    Friend WithEvents groupGenerales As System.Windows.Forms.GroupBox
    Friend WithEvents groupAlmacen As System.Windows.Forms.GroupBox
    Friend WithEvents groupCajas As System.Windows.Forms.GroupBox
    Friend WithEvents groupFacturacion As System.Windows.Forms.GroupBox
    Friend WithEvents rbtTipo_Empresa As System.Windows.Forms.RadioButton
    Friend WithEvents ChkAlmacen_Estocables As System.Windows.Forms.CheckBox
    Friend WithEvents groupAlmacen_Estocable As System.Windows.Forms.GroupBox
    Friend WithEvents Rbt_Stock_05 As System.Windows.Forms.RadioButton
    Friend WithEvents Rbt_Stock_01 As System.Windows.Forms.RadioButton
    Friend WithEvents Rbt_Stock_04 As System.Windows.Forms.RadioButton
    Friend WithEvents Rbt_Stock_02 As System.Windows.Forms.RadioButton
    Friend WithEvents Rbt_Stock_03 As System.Windows.Forms.RadioButton
    Friend WithEvents RadioButton7 As System.Windows.Forms.RadioButton
    Friend WithEvents rbtCajas_Consumiciones As System.Windows.Forms.RadioButton
    Friend WithEvents rbtCaja_UsuarioDetallado As System.Windows.Forms.RadioButton
    Friend WithEvents rbtAlmacen_SimpleValoracion As System.Windows.Forms.RadioButton
    Friend WithEvents rbtCajas_Consumo As System.Windows.Forms.RadioButton
    Friend WithEvents PicImg_gDev As System.Windows.Forms.PictureBox
    Friend WithEvents chkPrintTicket As System.Windows.Forms.CheckBox
    Friend WithEvents pbBar As System.Windows.Forms.ProgressBar
    Friend WithEvents TabPage_Operaciones As System.Windows.Forms.TabPage
    Friend WithEvents Panel5 As System.Windows.Forms.Panel
    Friend WithEvents PictureBox2 As System.Windows.Forms.PictureBox
    Friend WithEvents Label66 As System.Windows.Forms.Label
    Friend WithEvents RadioButton6 As System.Windows.Forms.RadioButton
    Friend WithEvents RadioButton3 As System.Windows.Forms.RadioButton
    Friend WithEvents RadioButton2 As System.Windows.Forms.RadioButton
    Friend WithEvents chkResumenConcepto As System.Windows.Forms.CheckBox
    Friend WithEvents chkResumenPedidos As System.Windows.Forms.CheckBox
    Friend WithEvents txtCajaID As System.Windows.Forms.TextBox
    Friend WithEvents rbtCaja_ConsumoID As System.Windows.Forms.RadioButton
    Friend WithEvents groupResumenCaja As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents rbtCaja_Actual As System.Windows.Forms.RadioButton
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents rbtCajas_Consumo_Local As System.Windows.Forms.RadioButton
    Friend WithEvents rbtCajas_Consumo_Estanco As System.Windows.Forms.RadioButton
    Friend WithEvents rbtCajas_Consumo_Pedidos As System.Windows.Forms.RadioButton
    Friend WithEvents chkCajas_SoloTickets As System.Windows.Forms.CheckBox
    Friend WithEvents rbtAlmacen_Estanco As System.Windows.Forms.RadioButton
    Friend WithEvents RadioButton1 As System.Windows.Forms.RadioButton
    Friend WithEvents rbtCaja_Resumen As System.Windows.Forms.RadioButton
    Friend WithEvents rbtFacturacion_FtraCompras_ACT As System.Windows.Forms.RadioButton
End Class
