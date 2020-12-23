<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCodBarras
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
        Dim ToolStrip As System.Windows.Forms.ToolStrip
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmCodBarras))
        Dim PictureBox1 As System.Windows.Forms.PictureBox
        Dim Label12 As System.Windows.Forms.Label
        Me.LblTitle = New System.Windows.Forms.ToolStripLabel()
        Me.ToolStripButton_Help = New System.Windows.Forms.ToolStripButton()
        Me.ToolStrip_Cancell = New System.Windows.Forms.ToolStripButton()
        Me.ToolStrip_Save = New System.Windows.Forms.ToolStripButton()
        Me.ToolStrip_Next = New System.Windows.Forms.ToolStripButton()
        Me.ToolStrip_Prev = New System.Windows.Forms.ToolStripButton()
        Me.Group_Art = New System.Windows.Forms.GroupBox()
        Me.cbTipo = New System.Windows.Forms.ComboBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.CbTipoImpresiones = New System.Windows.Forms.ComboBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Bt_select = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Lst_Contable = New System.Windows.Forms.ListView()
        Me.Col_ID = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Col_Ref = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Col_N = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Col_Name = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Col_inc = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Col_pvp = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Col_swTalla = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Col_talla = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Col_ean = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Bt_Del = New System.Windows.Forms.Button()
        Me.Bt_Add = New System.Windows.Forms.Button()
        Me.Bt_Edit = New System.Windows.Forms.Button()
        Me.Group_CfgPrinter = New System.Windows.Forms.GroupBox()
        Me.PnlEtiquetas = New System.Windows.Forms.Panel()
        Me.CbTipoEtiquta = New System.Windows.Forms.ComboBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.ChkPrintDirect = New System.Windows.Forms.CheckBox()
        Me.CbPrint = New System.Windows.Forms.ComboBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Group_Generate = New System.Windows.Forms.GroupBox()
        Me.PnlPrint = New System.Windows.Forms.Panel()
        Me.btPreview = New System.Windows.Forms.Button()
        Me.BtNew = New System.Windows.Forms.Button()
        Me.PicBarCode = New System.Windows.Forms.PictureBox()
        Me.BtClose = New System.Windows.Forms.Button()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.PBar_Generate = New System.Windows.Forms.ProgressBar()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.BackgroundWorker = New System.ComponentModel.BackgroundWorker()
        Me.Group_CfgEtiquetadora = New System.Windows.Forms.GroupBox()
        Me.CbTamanoEtiqueta = New System.Windows.Forms.ComboBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.ChkPrintDirect_Etiquetadora = New System.Windows.Forms.CheckBox()
        Me.CbPrint_Etiquetadora = New System.Windows.Forms.ComboBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.SplitContainer = New System.Windows.Forms.SplitContainer()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.Label11 = New System.Windows.Forms.Label()
        ToolStrip = New System.Windows.Forms.ToolStrip()
        PictureBox1 = New System.Windows.Forms.PictureBox()
        Label12 = New System.Windows.Forms.Label()
        ToolStrip.SuspendLayout()
        CType(PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Group_Art.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.Group_CfgPrinter.SuspendLayout()
        Me.Group_Generate.SuspendLayout()
        Me.PnlPrint.SuspendLayout()
        CType(Me.PicBarCode, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Group_CfgEtiquetadora.SuspendLayout()
        Me.SplitContainer.Panel1.SuspendLayout()
        Me.SplitContainer.Panel2.SuspendLayout()
        Me.SplitContainer.SuspendLayout()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ToolStrip
        '
        ToolStrip.Dock = System.Windows.Forms.DockStyle.Bottom
        ToolStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        ToolStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.LblTitle, Me.ToolStripButton_Help, Me.ToolStrip_Cancell, Me.ToolStrip_Save, Me.ToolStrip_Next, Me.ToolStrip_Prev})
        ToolStrip.Location = New System.Drawing.Point(0, 59)
        ToolStrip.Name = "ToolStrip"
        ToolStrip.Size = New System.Drawing.Size(621, 25)
        ToolStrip.TabIndex = 5
        '
        'LblTitle
        '
        Me.LblTitle.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblTitle.Name = "LblTitle"
        Me.LblTitle.Size = New System.Drawing.Size(196, 22)
        Me.LblTitle.Text = "Selección de Artículos [PASO 1/3]"
        Me.LblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
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
        '
        'ToolStrip_Cancell
        '
        Me.ToolStrip_Cancell.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.ToolStrip_Cancell.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStrip_Cancell.Image = CType(resources.GetObject("ToolStrip_Cancell.Image"), System.Drawing.Image)
        Me.ToolStrip_Cancell.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStrip_Cancell.Name = "ToolStrip_Cancell"
        Me.ToolStrip_Cancell.Size = New System.Drawing.Size(23, 22)
        Me.ToolStrip_Cancell.Tag = "cancelar"
        Me.ToolStrip_Cancell.Text = "Cerrar"
        '
        'ToolStrip_Save
        '
        Me.ToolStrip_Save.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.ToolStrip_Save.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStrip_Save.Image = CType(resources.GetObject("ToolStrip_Save.Image"), System.Drawing.Image)
        Me.ToolStrip_Save.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStrip_Save.Name = "ToolStrip_Save"
        Me.ToolStrip_Save.Size = New System.Drawing.Size(23, 22)
        Me.ToolStrip_Save.Tag = "guardar"
        Me.ToolStrip_Save.Text = "Guardar"
        Me.ToolStrip_Save.Visible = False
        '
        'ToolStrip_Next
        '
        Me.ToolStrip_Next.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.ToolStrip_Next.Enabled = False
        Me.ToolStrip_Next.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ToolStrip_Next.Image = CType(resources.GetObject("ToolStrip_Next.Image"), System.Drawing.Image)
        Me.ToolStrip_Next.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStrip_Next.Name = "ToolStrip_Next"
        Me.ToolStrip_Next.Size = New System.Drawing.Size(80, 22)
        Me.ToolStrip_Next.Text = "Siguiente"
        Me.ToolStrip_Next.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage
        '
        'ToolStrip_Prev
        '
        Me.ToolStrip_Prev.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.ToolStrip_Prev.Enabled = False
        Me.ToolStrip_Prev.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ToolStrip_Prev.Image = CType(resources.GetObject("ToolStrip_Prev.Image"), System.Drawing.Image)
        Me.ToolStrip_Prev.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStrip_Prev.Name = "ToolStrip_Prev"
        Me.ToolStrip_Prev.Size = New System.Drawing.Size(74, 22)
        Me.ToolStrip_Prev.Text = "Anterior"
        '
        'PictureBox1
        '
        PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        PictureBox1.Location = New System.Drawing.Point(14, 23)
        PictureBox1.Name = "PictureBox1"
        PictureBox1.Size = New System.Drawing.Size(35, 50)
        PictureBox1.TabIndex = 1
        PictureBox1.TabStop = False
        '
        'Label12
        '
        Label12.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Label12.Location = New System.Drawing.Point(74, 31)
        Label12.Name = "Label12"
        Label12.Size = New System.Drawing.Size(508, 22)
        Label12.TabIndex = 6
        Label12.Text = "Configuración y personalización de etiquetas de Productos y Servicios"
        '
        'Group_Art
        '
        Me.Group_Art.Controls.Add(Me.cbTipo)
        Me.Group_Art.Controls.Add(Me.Label13)
        Me.Group_Art.Controls.Add(Me.CbTipoImpresiones)
        Me.Group_Art.Controls.Add(Me.Label7)
        Me.Group_Art.Controls.Add(Me.GroupBox1)
        Me.Group_Art.Location = New System.Drawing.Point(7, 7)
        Me.Group_Art.Name = "Group_Art"
        Me.Group_Art.Size = New System.Drawing.Size(605, 506)
        Me.Group_Art.TabIndex = 6
        Me.Group_Art.TabStop = False
        Me.Group_Art.Text = "Detalles"
        '
        'cbTipo
        '
        Me.cbTipo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbTipo.Enabled = False
        Me.cbTipo.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbTipo.FormattingEnabled = True
        Me.cbTipo.Items.AddRange(New Object() {"Códigos de Barras", "Etiqueta QR"})
        Me.cbTipo.Location = New System.Drawing.Point(432, 42)
        Me.cbTipo.Name = "cbTipo"
        Me.cbTipo.Size = New System.Drawing.Size(163, 26)
        Me.cbTipo.TabIndex = 9
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(404, 19)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(112, 16)
        Me.Label13.TabIndex = 8
        Me.Label13.Text = "Tipo de Etiquetas:"
        '
        'CbTipoImpresiones
        '
        Me.CbTipoImpresiones.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CbTipoImpresiones.Enabled = False
        Me.CbTipoImpresiones.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CbTipoImpresiones.FormattingEnabled = True
        Me.CbTipoImpresiones.Items.AddRange(New Object() {"PAPEL PEGATINA DE ETIQUETAS", "IMPRESORA DE ETIQUETAS"})
        Me.CbTipoImpresiones.Location = New System.Drawing.Point(34, 42)
        Me.CbTipoImpresiones.Name = "CbTipoImpresiones"
        Me.CbTipoImpresiones.Size = New System.Drawing.Size(331, 26)
        Me.CbTipoImpresiones.TabIndex = 7
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(13, 19)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(117, 16)
        Me.Label7.TabIndex = 6
        Me.Label7.Text = "Tipo de Impresión:"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Bt_select)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.Lst_Contable)
        Me.GroupBox1.Controls.Add(Me.Bt_Del)
        Me.GroupBox1.Controls.Add(Me.Bt_Add)
        Me.GroupBox1.Controls.Add(Me.Bt_Edit)
        Me.GroupBox1.Location = New System.Drawing.Point(6, 87)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(593, 410)
        Me.GroupBox1.TabIndex = 5
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Artículos a Imprimir"
        '
        'Bt_select
        '
        Me.Bt_select.Image = CType(resources.GetObject("Bt_select.Image"), System.Drawing.Image)
        Me.Bt_select.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Bt_select.Location = New System.Drawing.Point(467, 190)
        Me.Bt_select.Name = "Bt_select"
        Me.Bt_select.Size = New System.Drawing.Size(122, 26)
        Me.Bt_select.TabIndex = 5
        Me.Bt_select.Text = "Seleccionar"
        Me.Bt_select.UseVisualStyleBackColor = True
        Me.Bt_select.Visible = False
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(7, 21)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(565, 16)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "Seleccione los artículos que desee y establezca el nº de etiquetas por artículo p" & _
            "ara imprimir el código de barras."
        '
        'Lst_Contable
        '
        Me.Lst_Contable.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.Col_ID, Me.Col_Ref, Me.Col_N, Me.Col_Name, Me.Col_inc, Me.Col_pvp, Me.Col_swTalla, Me.Col_talla, Me.Col_ean})
        Me.Lst_Contable.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lst_Contable.FullRowSelect = True
        Me.Lst_Contable.HideSelection = False
        Me.Lst_Contable.Location = New System.Drawing.Point(10, 53)
        Me.Lst_Contable.MultiSelect = False
        Me.Lst_Contable.Name = "Lst_Contable"
        Me.Lst_Contable.Size = New System.Drawing.Size(451, 335)
        Me.Lst_Contable.TabIndex = 0
        Me.Lst_Contable.UseCompatibleStateImageBehavior = False
        Me.Lst_Contable.View = System.Windows.Forms.View.Details
        '
        'Col_ID
        '
        Me.Col_ID.Text = "Id."
        Me.Col_ID.Width = 0
        '
        'Col_Ref
        '
        Me.Col_Ref.Text = "Ref."
        Me.Col_Ref.Width = 0
        '
        'Col_N
        '
        Me.Col_N.Text = "#"
        Me.Col_N.Width = 50
        '
        'Col_Name
        '
        Me.Col_Name.Text = "Artículo"
        Me.Col_Name.Width = 350
        '
        'Col_inc
        '
        Me.Col_inc.Text = "Incluir Datos"
        Me.Col_inc.Width = 0
        '
        'Col_pvp
        '
        Me.Col_pvp.Text = "Pvp"
        Me.Col_pvp.Width = 0
        '
        'Col_swTalla
        '
        Me.Col_swTalla.Text = "swTalla"
        Me.Col_swTalla.Width = 0
        '
        'Col_talla
        '
        Me.Col_talla.Text = "talla"
        Me.Col_talla.Width = 0
        '
        'Col_ean
        '
        Me.Col_ean.Text = "Ean"
        Me.Col_ean.Width = 0
        '
        'Bt_Del
        '
        Me.Bt_Del.Enabled = False
        Me.Bt_Del.Image = CType(resources.GetObject("Bt_Del.Image"), System.Drawing.Image)
        Me.Bt_Del.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Bt_Del.Location = New System.Drawing.Point(467, 140)
        Me.Bt_Del.Name = "Bt_Del"
        Me.Bt_Del.Size = New System.Drawing.Size(122, 26)
        Me.Bt_Del.TabIndex = 3
        Me.Bt_Del.Text = "Eliminar"
        Me.Bt_Del.UseVisualStyleBackColor = True
        '
        'Bt_Add
        '
        Me.Bt_Add.Image = CType(resources.GetObject("Bt_Add.Image"), System.Drawing.Image)
        Me.Bt_Add.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Bt_Add.Location = New System.Drawing.Point(467, 76)
        Me.Bt_Add.Name = "Bt_Add"
        Me.Bt_Add.Size = New System.Drawing.Size(122, 26)
        Me.Bt_Add.TabIndex = 1
        Me.Bt_Add.Text = "Agregar"
        Me.Bt_Add.UseVisualStyleBackColor = True
        '
        'Bt_Edit
        '
        Me.Bt_Edit.Enabled = False
        Me.Bt_Edit.Image = CType(resources.GetObject("Bt_Edit.Image"), System.Drawing.Image)
        Me.Bt_Edit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Bt_Edit.Location = New System.Drawing.Point(467, 108)
        Me.Bt_Edit.Name = "Bt_Edit"
        Me.Bt_Edit.Size = New System.Drawing.Size(122, 26)
        Me.Bt_Edit.TabIndex = 2
        Me.Bt_Edit.Text = "Editar"
        Me.Bt_Edit.UseVisualStyleBackColor = True
        '
        'Group_CfgPrinter
        '
        Me.Group_CfgPrinter.Controls.Add(Me.PnlEtiquetas)
        Me.Group_CfgPrinter.Controls.Add(Me.CbTipoEtiquta)
        Me.Group_CfgPrinter.Controls.Add(Me.Label6)
        Me.Group_CfgPrinter.Controls.Add(Me.ChkPrintDirect)
        Me.Group_CfgPrinter.Controls.Add(Me.CbPrint)
        Me.Group_CfgPrinter.Controls.Add(Me.Label5)
        Me.Group_CfgPrinter.Controls.Add(Me.Label2)
        Me.Group_CfgPrinter.Location = New System.Drawing.Point(7, 7)
        Me.Group_CfgPrinter.Name = "Group_CfgPrinter"
        Me.Group_CfgPrinter.Size = New System.Drawing.Size(605, 506)
        Me.Group_CfgPrinter.TabIndex = 7
        Me.Group_CfgPrinter.TabStop = False
        Me.Group_CfgPrinter.Text = "Configuración de la Impresión"
        Me.Group_CfgPrinter.Visible = False
        '
        'PnlEtiquetas
        '
        Me.PnlEtiquetas.BackColor = System.Drawing.Color.White
        Me.PnlEtiquetas.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.PnlEtiquetas.Location = New System.Drawing.Point(20, 137)
        Me.PnlEtiquetas.Name = "PnlEtiquetas"
        Me.PnlEtiquetas.Size = New System.Drawing.Size(568, 362)
        Me.PnlEtiquetas.TabIndex = 13
        '
        'CbTipoEtiquta
        '
        Me.CbTipoEtiquta.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CbTipoEtiquta.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CbTipoEtiquta.FormattingEnabled = True
        Me.CbTipoEtiquta.Items.AddRange(New Object() {"Tipo ""48.5 x 25.4"" mm, 4 ancho x 11 alto (44 etiquetas con margen)", "Tipo ""52.5 x 29.7"" mm, 4 ancho x 10 alto (40 etiquetas)", "Tipo ""70.0 x 37.0"" mm, 3 ancho x 8 alto (24 etiquetas)", "Tipo Decorativo ""52.5 x 29.7"" mm, 4 ancho x 10 alto (40 etiquetas)", "Tipo Decorativo ""70.0 x 37.0"" mm, 3 ancho x 8 alto (24 etiquetas)", "Tipo Ingredientes, 3 ancho x 8 alto (24 etiquetas, con margen)"})
        Me.CbTipoEtiquta.Location = New System.Drawing.Point(42, 72)
        Me.CbTipoEtiquta.Name = "CbTipoEtiquta"
        Me.CbTipoEtiquta.Size = New System.Drawing.Size(557, 27)
        Me.CbTipoEtiquta.TabIndex = 12
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(17, 52)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(148, 13)
        Me.Label6.TabIndex = 11
        Me.Label6.Text = "Seleccione el tipo de Etiqueta"
        '
        'ChkPrintDirect
        '
        Me.ChkPrintDirect.AutoSize = True
        Me.ChkPrintDirect.Location = New System.Drawing.Point(470, 29)
        Me.ChkPrintDirect.Name = "ChkPrintDirect"
        Me.ChkPrintDirect.Size = New System.Drawing.Size(125, 17)
        Me.ChkPrintDirect.TabIndex = 10
        Me.ChkPrintDirect.Text = "Imprimir directamente"
        Me.ChkPrintDirect.UseVisualStyleBackColor = True
        '
        'CbPrint
        '
        Me.CbPrint.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CbPrint.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CbPrint.FormattingEnabled = True
        Me.CbPrint.Location = New System.Drawing.Point(202, 24)
        Me.CbPrint.Name = "CbPrint"
        Me.CbPrint.Size = New System.Drawing.Size(262, 21)
        Me.CbPrint.TabIndex = 8
        '
        'Label5
        '
        Me.Label5.Location = New System.Drawing.Point(17, 111)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(454, 22)
        Me.Label5.TabIndex = 7
        Me.Label5.Text = "Seleccione la posicíon donde comenzara la impresión de etiquetas en el papel"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(17, 27)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(156, 13)
        Me.Label2.TabIndex = 5
        Me.Label2.Text = "Seleccione la impresora destino"
        '
        'Group_Generate
        '
        Me.Group_Generate.Controls.Add(Me.PnlPrint)
        Me.Group_Generate.Controls.Add(Me.PBar_Generate)
        Me.Group_Generate.Controls.Add(Me.Label3)
        Me.Group_Generate.Location = New System.Drawing.Point(7, 7)
        Me.Group_Generate.Name = "Group_Generate"
        Me.Group_Generate.Size = New System.Drawing.Size(605, 506)
        Me.Group_Generate.TabIndex = 8
        Me.Group_Generate.TabStop = False
        Me.Group_Generate.Text = "Generando Etiquetas"
        Me.Group_Generate.Visible = False
        '
        'PnlPrint
        '
        Me.PnlPrint.Controls.Add(Me.btPreview)
        Me.PnlPrint.Controls.Add(Me.BtNew)
        Me.PnlPrint.Controls.Add(Me.PicBarCode)
        Me.PnlPrint.Controls.Add(Me.BtClose)
        Me.PnlPrint.Controls.Add(PictureBox1)
        Me.PnlPrint.Controls.Add(Me.Label4)
        Me.PnlPrint.Location = New System.Drawing.Point(20, 113)
        Me.PnlPrint.Name = "PnlPrint"
        Me.PnlPrint.Size = New System.Drawing.Size(561, 387)
        Me.PnlPrint.TabIndex = 8
        Me.PnlPrint.Visible = False
        '
        'btPreview
        '
        Me.btPreview.Image = CType(resources.GetObject("btPreview.Image"), System.Drawing.Image)
        Me.btPreview.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btPreview.Location = New System.Drawing.Point(70, 343)
        Me.btPreview.Name = "btPreview"
        Me.btPreview.Size = New System.Drawing.Size(174, 41)
        Me.btPreview.TabIndex = 11
        Me.btPreview.Text = "Previsualizar"
        Me.btPreview.UseVisualStyleBackColor = True
        '
        'BtNew
        '
        Me.BtNew.Image = CType(resources.GetObject("BtNew.Image"), System.Drawing.Image)
        Me.BtNew.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtNew.Location = New System.Drawing.Point(250, 343)
        Me.BtNew.Name = "BtNew"
        Me.BtNew.Size = New System.Drawing.Size(174, 41)
        Me.BtNew.TabIndex = 10
        Me.BtNew.Text = "Empezar de nuevo"
        Me.BtNew.UseVisualStyleBackColor = True
        '
        'PicBarCode
        '
        Me.PicBarCode.BackColor = System.Drawing.Color.White
        Me.PicBarCode.Image = CType(resources.GetObject("PicBarCode.Image"), System.Drawing.Image)
        Me.PicBarCode.Location = New System.Drawing.Point(14, 76)
        Me.PicBarCode.Name = "PicBarCode"
        Me.PicBarCode.Size = New System.Drawing.Size(205, 74)
        Me.PicBarCode.TabIndex = 9
        Me.PicBarCode.TabStop = False
        Me.PicBarCode.Visible = False
        '
        'BtClose
        '
        Me.BtClose.Image = CType(resources.GetObject("BtClose.Image"), System.Drawing.Image)
        Me.BtClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtClose.Location = New System.Drawing.Point(430, 343)
        Me.BtClose.Name = "BtClose"
        Me.BtClose.Size = New System.Drawing.Size(128, 41)
        Me.BtClose.TabIndex = 3
        Me.BtClose.Text = "Terminar"
        Me.BtClose.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(49, 24)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(447, 49)
        Me.Label4.TabIndex = 0
        Me.Label4.Text = "Se han generado las etiquetas y han sido enviadas a la impresora"
        '
        'PBar_Generate
        '
        Me.PBar_Generate.Location = New System.Drawing.Point(20, 55)
        Me.PBar_Generate.Name = "PBar_Generate"
        Me.PBar_Generate.Size = New System.Drawing.Size(561, 40)
        Me.PBar_Generate.TabIndex = 7
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(17, 30)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(454, 22)
        Me.Label3.TabIndex = 6
        Me.Label3.Text = "Espere mientras se generan las etiquetas...." & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        '
        'BackgroundWorker
        '
        Me.BackgroundWorker.WorkerSupportsCancellation = True
        '
        'Group_CfgEtiquetadora
        '
        Me.Group_CfgEtiquetadora.Controls.Add(Me.CbTamanoEtiqueta)
        Me.Group_CfgEtiquetadora.Controls.Add(Me.Label9)
        Me.Group_CfgEtiquetadora.Controls.Add(Me.ChkPrintDirect_Etiquetadora)
        Me.Group_CfgEtiquetadora.Controls.Add(Me.CbPrint_Etiquetadora)
        Me.Group_CfgEtiquetadora.Controls.Add(Me.Label8)
        Me.Group_CfgEtiquetadora.Location = New System.Drawing.Point(7, 7)
        Me.Group_CfgEtiquetadora.Name = "Group_CfgEtiquetadora"
        Me.Group_CfgEtiquetadora.Size = New System.Drawing.Size(605, 506)
        Me.Group_CfgEtiquetadora.TabIndex = 9
        Me.Group_CfgEtiquetadora.TabStop = False
        Me.Group_CfgEtiquetadora.Text = "Configuración de la Impresión por Etiquetadora"
        Me.Group_CfgEtiquetadora.Visible = False
        '
        'CbTamanoEtiqueta
        '
        Me.CbTamanoEtiqueta.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CbTamanoEtiqueta.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CbTamanoEtiqueta.FormattingEnabled = True
        Me.CbTamanoEtiqueta.Items.AddRange(New Object() {"40 mm de ancho x 24 mm de alto", "49 mm de ancho x 38 mm de alto", "62 mm de ancho x 29 mm de alto"})
        Me.CbTamanoEtiqueta.Location = New System.Drawing.Point(201, 84)
        Me.CbTamanoEtiqueta.Name = "CbTamanoEtiqueta"
        Me.CbTamanoEtiqueta.Size = New System.Drawing.Size(342, 27)
        Me.CbTamanoEtiqueta.TabIndex = 15
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(17, 87)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(177, 13)
        Me.Label9.TabIndex = 14
        Me.Label9.Text = "Seleccione el tamaño de la Etiqueta"
        '
        'ChkPrintDirect_Etiquetadora
        '
        Me.ChkPrintDirect_Etiquetadora.AutoSize = True
        Me.ChkPrintDirect_Etiquetadora.Enabled = False
        Me.ChkPrintDirect_Etiquetadora.Location = New System.Drawing.Point(202, 51)
        Me.ChkPrintDirect_Etiquetadora.Name = "ChkPrintDirect_Etiquetadora"
        Me.ChkPrintDirect_Etiquetadora.Size = New System.Drawing.Size(202, 17)
        Me.ChkPrintDirect_Etiquetadora.TabIndex = 13
        Me.ChkPrintDirect_Etiquetadora.Text = "Imprimir directamente sin previsualizar"
        Me.ChkPrintDirect_Etiquetadora.UseVisualStyleBackColor = True
        '
        'CbPrint_Etiquetadora
        '
        Me.CbPrint_Etiquetadora.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CbPrint_Etiquetadora.Enabled = False
        Me.CbPrint_Etiquetadora.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CbPrint_Etiquetadora.FormattingEnabled = True
        Me.CbPrint_Etiquetadora.Location = New System.Drawing.Point(202, 24)
        Me.CbPrint_Etiquetadora.Name = "CbPrint_Etiquetadora"
        Me.CbPrint_Etiquetadora.Size = New System.Drawing.Size(342, 21)
        Me.CbPrint_Etiquetadora.TabIndex = 12
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(17, 27)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(156, 13)
        Me.Label8.TabIndex = 11
        Me.Label8.Text = "Seleccione la impresora destino"
        '
        'SplitContainer
        '
        Me.SplitContainer.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer.FixedPanel = System.Windows.Forms.FixedPanel.Panel1
        Me.SplitContainer.IsSplitterFixed = True
        Me.SplitContainer.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainer.Name = "SplitContainer"
        Me.SplitContainer.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'SplitContainer.Panel1
        '
        Me.SplitContainer.Panel1.BackColor = System.Drawing.SystemColors.InactiveCaption
        Me.SplitContainer.Panel1.Controls.Add(Me.Label10)
        Me.SplitContainer.Panel1.Controls.Add(ToolStrip)
        Me.SplitContainer.Panel1.Controls.Add(Me.PictureBox2)
        Me.SplitContainer.Panel1.Controls.Add(Me.Label11)
        Me.SplitContainer.Panel1.Controls.Add(Label12)
        '
        'SplitContainer.Panel2
        '
        Me.SplitContainer.Panel2.Controls.Add(Me.Group_Art)
        Me.SplitContainer.Panel2.Controls.Add(Me.Group_Generate)
        Me.SplitContainer.Panel2.Controls.Add(Me.Group_CfgEtiquetadora)
        Me.SplitContainer.Panel2.Controls.Add(Me.Group_CfgPrinter)
        Me.SplitContainer.Size = New System.Drawing.Size(621, 607)
        Me.SplitContainer.SplitterDistance = 84
        Me.SplitContainer.SplitterWidth = 1
        Me.SplitContainer.TabIndex = 24
        '
        'Label10
        '
        Me.Label10.Font = New System.Drawing.Font("Tahoma", 6.0!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(406, 9)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(76, 12)
        Me.Label10.TabIndex = 39
        Me.Label10.Tag = "id"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'PictureBox2
        '
        Me.PictureBox2.Image = CType(resources.GetObject("PictureBox2.Image"), System.Drawing.Image)
        Me.PictureBox2.Location = New System.Drawing.Point(5, 5)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(48, 48)
        Me.PictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.PictureBox2.TabIndex = 38
        Me.PictureBox2.TabStop = False
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(64, 9)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(208, 19)
        Me.Label11.TabIndex = 7
        Me.Label11.Text = "Generación de Etiquetas"
        '
        'frmCodBarras
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(238, Byte), Integer), CType(CType(238, Byte), Integer), CType(CType(238, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(621, 607)
        Me.Controls.Add(Me.SplitContainer)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "frmCodBarras"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Generación de Etiquetas"
        ToolStrip.ResumeLayout(False)
        ToolStrip.PerformLayout()
        CType(PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Group_Art.ResumeLayout(False)
        Me.Group_Art.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.Group_CfgPrinter.ResumeLayout(False)
        Me.Group_CfgPrinter.PerformLayout()
        Me.Group_Generate.ResumeLayout(False)
        Me.PnlPrint.ResumeLayout(False)
        CType(Me.PicBarCode, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Group_CfgEtiquetadora.ResumeLayout(False)
        Me.Group_CfgEtiquetadora.PerformLayout()
        Me.SplitContainer.Panel1.ResumeLayout(False)
        Me.SplitContainer.Panel1.PerformLayout()
        Me.SplitContainer.Panel2.ResumeLayout(False)
        Me.SplitContainer.ResumeLayout(False)
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents LblTitle As System.Windows.Forms.ToolStripLabel
    Friend WithEvents ToolStrip_Cancell As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStrip_Save As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStrip_Next As System.Windows.Forms.ToolStripButton
    Friend WithEvents Group_Art As System.Windows.Forms.GroupBox
    Friend WithEvents Bt_Del As System.Windows.Forms.Button
    Friend WithEvents Bt_Edit As System.Windows.Forms.Button
    Friend WithEvents Bt_Add As System.Windows.Forms.Button
    Friend WithEvents Lst_Contable As System.Windows.Forms.ListView
    Friend WithEvents Col_ID As System.Windows.Forms.ColumnHeader
    Friend WithEvents Col_N As System.Windows.Forms.ColumnHeader
    Friend WithEvents Col_Name As System.Windows.Forms.ColumnHeader
    Friend WithEvents Col_inc As System.Windows.Forms.ColumnHeader
    Friend WithEvents Col_pvp As System.Windows.Forms.ColumnHeader
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Col_Ref As System.Windows.Forms.ColumnHeader
    Friend WithEvents Group_CfgPrinter As System.Windows.Forms.GroupBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents ToolStrip_Prev As System.Windows.Forms.ToolStripButton
    Friend WithEvents Group_Generate As System.Windows.Forms.GroupBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents PBar_Generate As System.Windows.Forms.ProgressBar
    Friend WithEvents BackgroundWorker As System.ComponentModel.BackgroundWorker
    Friend WithEvents PnlPrint As System.Windows.Forms.Panel
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents CbPrint As System.Windows.Forms.ComboBox
    Friend WithEvents BtClose As System.Windows.Forms.Button
    Friend WithEvents PicBarCode As System.Windows.Forms.PictureBox
    Friend WithEvents BtNew As System.Windows.Forms.Button
    Friend WithEvents ChkPrintDirect As System.Windows.Forms.CheckBox
    Friend WithEvents CbTipoEtiquta As System.Windows.Forms.ComboBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents PnlEtiquetas As System.Windows.Forms.Panel
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents CbTipoImpresiones As System.Windows.Forms.ComboBox
    Friend WithEvents Group_CfgEtiquetadora As System.Windows.Forms.GroupBox
    Friend WithEvents ChkPrintDirect_Etiquetadora As System.Windows.Forms.CheckBox
    Friend WithEvents CbPrint_Etiquetadora As System.Windows.Forms.ComboBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents CbTamanoEtiqueta As System.Windows.Forms.ComboBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents SplitContainer As System.Windows.Forms.SplitContainer
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents PictureBox2 As System.Windows.Forms.PictureBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents ToolStripButton_Help As System.Windows.Forms.ToolStripButton
    Friend WithEvents cbTipo As System.Windows.Forms.ComboBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Bt_select As System.Windows.Forms.Button
    Friend WithEvents btPreview As System.Windows.Forms.Button
    Friend WithEvents Col_swTalla As System.Windows.Forms.ColumnHeader
    Friend WithEvents Col_talla As System.Windows.Forms.ColumnHeader
    Friend WithEvents Col_ean As System.Windows.Forms.ColumnHeader
End Class
