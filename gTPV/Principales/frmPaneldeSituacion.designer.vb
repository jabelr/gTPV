<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmPaneldeSituacion
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
        Dim Label6 As System.Windows.Forms.Label
        Dim Label1 As System.Windows.Forms.Label
        Dim LblEmpleado As System.Windows.Forms.Label
        Dim Label2 As System.Windows.Forms.Label
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmPaneldeSituacion))
        Me.LblHistory_Empleado = New System.Windows.Forms.Label()
        Me.PnlLast = New System.Windows.Forms.Panel()
        Me.LblLastRef = New System.Windows.Forms.Label()
        Me.BtPrintLastTicket = New System.Windows.Forms.Button()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.LblMesa = New System.Windows.Forms.Label()
        Me.LblTotal = New System.Windows.Forms.Label()
        Me.SplitContainer = New System.Windows.Forms.SplitContainer()
        Me.BtKeyBoard = New System.Windows.Forms.Button()
        Me.LblHour = New System.Windows.Forms.Label()
        Me.m_logo = New System.Windows.Forms.PictureBox()
        Me.PnlButton_Shell = New System.Windows.Forms.Panel()
        Me.BtCajaDirecta = New System.Windows.Forms.Button()
        Me.BtClose = New System.Windows.Forms.Button()
        Me.BtReparto = New System.Windows.Forms.Button()
        Me.LblSubTitle = New System.Windows.Forms.Label()
        Me.LblTitle = New System.Windows.Forms.Label()
        Me.pnlCashLogy = New System.Windows.Forms.Panel()
        Me.ctCashlogy_config = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.ctCashlogy_DarCambio = New System.Windows.Forms.Button()
        Me.PnlBody = New System.Windows.Forms.Panel()
        Me.PnlData = New System.Windows.Forms.Panel()
        Me.PnlZonas = New System.Windows.Forms.Panel()
        Me.BtZona_Right = New System.Windows.Forms.Button()
        Me.BtZona_Left = New System.Windows.Forms.Button()
        Me.CbZonas = New System.Windows.Forms.ComboBox()
        Me.PnlAction_Buttons = New System.Windows.Forms.Panel()
        Me.Group_Last = New System.Windows.Forms.GroupBox()
        Me.PnlHistory = New System.Windows.Forms.Panel()
        Me.GroupHistory = New System.Windows.Forms.GroupBox()
        Me.BtHistory_Edit = New System.Windows.Forms.Button()
        Me.BtHistory_Print = New System.Windows.Forms.Button()
        Me.LblHistory_Fh = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.LblHistory_Mesa = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.LblHistory_Total = New System.Windows.Forms.Label()
        Me.LblHistory_Ref = New System.Windows.Forms.Label()
        Me.BtHistory_Next = New System.Windows.Forms.Button()
        Me.BtHistory_Previous = New System.Windows.Forms.Button()
        Me.PicPlano = New System.Windows.Forms.PictureBox()
        Me.ToolTip = New System.Windows.Forms.ToolTip(Me.components)
        Me.TmHour = New System.Windows.Forms.Timer(Me.components)
        Me.tmrMesas = New System.Windows.Forms.Timer(Me.components)
        Label6 = New System.Windows.Forms.Label()
        Label1 = New System.Windows.Forms.Label()
        LblEmpleado = New System.Windows.Forms.Label()
        Label2 = New System.Windows.Forms.Label()
        Me.PnlLast.SuspendLayout()
        Me.SplitContainer.Panel1.SuspendLayout()
        Me.SplitContainer.Panel2.SuspendLayout()
        Me.SplitContainer.SuspendLayout()
        CType(Me.m_logo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PnlButton_Shell.SuspendLayout()
        Me.pnlCashLogy.SuspendLayout()
        Me.PnlBody.SuspendLayout()
        Me.PnlData.SuspendLayout()
        Me.PnlZonas.SuspendLayout()
        Me.PnlAction_Buttons.SuspendLayout()
        Me.Group_Last.SuspendLayout()
        Me.PnlHistory.SuspendLayout()
        Me.GroupHistory.SuspendLayout()
        CType(Me.PicPlano, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label6
        '
        Label6.AutoSize = True
        Label6.Font = New System.Drawing.Font("Tahoma", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Label6.Location = New System.Drawing.Point(5, 4)
        Label6.Name = "Label6"
        Label6.Size = New System.Drawing.Size(41, 11)
        Label6.TabIndex = 18
        Label6.Text = "Panel de"
        '
        'Label1
        '
        Label1.AutoSize = True
        Label1.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Label1.ForeColor = System.Drawing.Color.Black
        Label1.Location = New System.Drawing.Point(11, 15)
        Label1.Name = "Label1"
        Label1.Size = New System.Drawing.Size(78, 18)
        Label1.TabIndex = 21
        Label1.Text = "Situación"
        '
        'LblEmpleado
        '
        LblEmpleado.AutoSize = True
        LblEmpleado.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        LblEmpleado.Location = New System.Drawing.Point(3, 46)
        LblEmpleado.Name = "LblEmpleado"
        LblEmpleado.Size = New System.Drawing.Size(66, 13)
        LblEmpleado.TabIndex = 35
        LblEmpleado.Text = "EMPLEADO"
        '
        'Label2
        '
        Label2.AutoSize = True
        Label2.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Label2.Location = New System.Drawing.Point(3, 4)
        Label2.Name = "Label2"
        Label2.Size = New System.Drawing.Size(122, 16)
        Label2.TabIndex = 24
        Label2.Text = "Zonas Disponibles"
        '
        'LblHistory_Empleado
        '
        Me.LblHistory_Empleado.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblHistory_Empleado.ForeColor = System.Drawing.Color.DimGray
        Me.LblHistory_Empleado.Location = New System.Drawing.Point(56, 41)
        Me.LblHistory_Empleado.Name = "LblHistory_Empleado"
        Me.LblHistory_Empleado.Size = New System.Drawing.Size(108, 13)
        Me.LblHistory_Empleado.TabIndex = 35
        Me.LblHistory_Empleado.Text = "EMPLEADO"
        '
        'PnlLast
        '
        Me.PnlLast.Controls.Add(Me.LblLastRef)
        Me.PnlLast.Controls.Add(Me.BtPrintLastTicket)
        Me.PnlLast.Controls.Add(Me.Label7)
        Me.PnlLast.Controls.Add(LblEmpleado)
        Me.PnlLast.Controls.Add(Me.Label4)
        Me.PnlLast.Controls.Add(Me.Label3)
        Me.PnlLast.Controls.Add(Me.LblMesa)
        Me.PnlLast.Controls.Add(Me.LblTotal)
        Me.PnlLast.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PnlLast.Location = New System.Drawing.Point(3, 14)
        Me.PnlLast.Name = "PnlLast"
        Me.PnlLast.Size = New System.Drawing.Size(265, 60)
        Me.PnlLast.TabIndex = 0
        Me.PnlLast.Visible = False
        '
        'LblLastRef
        '
        Me.LblLastRef.BackColor = System.Drawing.Color.Tan
        Me.LblLastRef.Font = New System.Drawing.Font("Tahoma", 6.0!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblLastRef.Location = New System.Drawing.Point(6, 23)
        Me.LblLastRef.Name = "LblLastRef"
        Me.LblLastRef.Size = New System.Drawing.Size(38, 10)
        Me.LblLastRef.TabIndex = 39
        Me.LblLastRef.Text = "Ref.: 0"
        Me.LblLastRef.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'BtPrintLastTicket
        '
        Me.BtPrintLastTicket.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtPrintLastTicket.Image = CType(resources.GetObject("BtPrintLastTicket.Image"), System.Drawing.Image)
        Me.BtPrintLastTicket.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtPrintLastTicket.Location = New System.Drawing.Point(164, 0)
        Me.BtPrintLastTicket.Name = "BtPrintLastTicket"
        Me.BtPrintLastTicket.Size = New System.Drawing.Size(98, 35)
        Me.BtPrintLastTicket.TabIndex = 38
        Me.BtPrintLastTicket.Text = "    Imprimir"
        Me.BtPrintLastTicket.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.BtPrintLastTicket.UseVisualStyleBackColor = True
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Tahoma", 6.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(7, 37)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(43, 10)
        Me.Label7.TabIndex = 36
        Me.Label7.Text = "EMPLEADO"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Tan
        Me.Label4.Font = New System.Drawing.Font("Tahoma", 6.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(7, 4)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(43, 10)
        Me.Label4.TabIndex = 34
        Me.Label4.Text = "IMPORTE"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Tahoma", 6.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(150, 37)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(24, 10)
        Me.Label3.TabIndex = 32
        Me.Label3.Text = "MESA"
        '
        'LblMesa
        '
        Me.LblMesa.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblMesa.Location = New System.Drawing.Point(146, 47)
        Me.LblMesa.Name = "LblMesa"
        Me.LblMesa.Size = New System.Drawing.Size(115, 12)
        Me.LblMesa.TabIndex = 31
        Me.LblMesa.Text = "CAJA DIRECTA"
        '
        'LblTotal
        '
        Me.LblTotal.BackColor = System.Drawing.Color.Tan
        Me.LblTotal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LblTotal.Font = New System.Drawing.Font("Tahoma", 17.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblTotal.Location = New System.Drawing.Point(3, 1)
        Me.LblTotal.Name = "LblTotal"
        Me.LblTotal.Size = New System.Drawing.Size(155, 34)
        Me.LblTotal.TabIndex = 37
        Me.LblTotal.Text = "0,00 €"
        Me.LblTotal.TextAlign = System.Drawing.ContentAlignment.MiddleRight
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
        Me.SplitContainer.Panel1.Controls.Add(Me.BtKeyBoard)
        Me.SplitContainer.Panel1.Controls.Add(Me.LblHour)
        Me.SplitContainer.Panel1.Controls.Add(Me.m_logo)
        Me.SplitContainer.Panel1.Controls.Add(Me.PnlButton_Shell)
        Me.SplitContainer.Panel1.Controls.Add(Me.LblSubTitle)
        Me.SplitContainer.Panel1.Controls.Add(Me.LblTitle)
        '
        'SplitContainer.Panel2
        '
        Me.SplitContainer.Panel2.AutoScroll = True
        Me.SplitContainer.Panel2.BackColor = System.Drawing.Color.Black
        Me.SplitContainer.Panel2.Controls.Add(Me.pnlCashLogy)
        Me.SplitContainer.Panel2.Controls.Add(Me.PnlBody)
        Me.SplitContainer.Panel2.Tag = "233; 248; 250"
        Me.SplitContainer.Size = New System.Drawing.Size(1020, 770)
        Me.SplitContainer.SplitterDistance = 64
        Me.SplitContainer.SplitterWidth = 1
        Me.SplitContainer.TabIndex = 2
        '
        'BtKeyBoard
        '
        Me.BtKeyBoard.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.BtKeyBoard.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtKeyBoard.Image = CType(resources.GetObject("BtKeyBoard.Image"), System.Drawing.Image)
        Me.BtKeyBoard.Location = New System.Drawing.Point(55, 28)
        Me.BtKeyBoard.Name = "BtKeyBoard"
        Me.BtKeyBoard.Size = New System.Drawing.Size(35, 32)
        Me.BtKeyBoard.TabIndex = 49
        Me.BtKeyBoard.Tag = "last"
        Me.BtKeyBoard.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.BtKeyBoard.UseVisualStyleBackColor = True
        '
        'LblHour
        '
        Me.LblHour.Font = New System.Drawing.Font("Verdana", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblHour.ForeColor = System.Drawing.Color.DimGray
        Me.LblHour.Image = CType(resources.GetObject("LblHour.Image"), System.Drawing.Image)
        Me.LblHour.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.LblHour.Location = New System.Drawing.Point(360, 4)
        Me.LblHour.Name = "LblHour"
        Me.LblHour.Size = New System.Drawing.Size(104, 28)
        Me.LblHour.TabIndex = 34
        Me.LblHour.Text = "00:00"
        Me.LblHour.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'm_logo
        '
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
        Me.PnlButton_Shell.Controls.Add(Me.BtCajaDirecta)
        Me.PnlButton_Shell.Controls.Add(Me.BtClose)
        Me.PnlButton_Shell.Controls.Add(Me.BtReparto)
        Me.PnlButton_Shell.Dock = System.Windows.Forms.DockStyle.Right
        Me.PnlButton_Shell.Location = New System.Drawing.Point(470, 0)
        Me.PnlButton_Shell.Name = "PnlButton_Shell"
        Me.PnlButton_Shell.Size = New System.Drawing.Size(550, 64)
        Me.PnlButton_Shell.TabIndex = 2
        '
        'BtCajaDirecta
        '
        Me.BtCajaDirecta.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.BtCajaDirecta.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Bold)
        Me.BtCajaDirecta.Image = CType(resources.GetObject("BtCajaDirecta.Image"), System.Drawing.Image)
        Me.BtCajaDirecta.Location = New System.Drawing.Point(153, 6)
        Me.BtCajaDirecta.Name = "BtCajaDirecta"
        Me.BtCajaDirecta.Size = New System.Drawing.Size(212, 57)
        Me.BtCajaDirecta.TabIndex = 8
        Me.BtCajaDirecta.Tag = "CAJADIRECTA"
        Me.BtCajaDirecta.Text = "Caja Directa"
        Me.BtCajaDirecta.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BtCajaDirecta.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.BtCajaDirecta.UseVisualStyleBackColor = True
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
        'BtReparto
        '
        Me.BtReparto.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.BtReparto.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtReparto.Image = CType(resources.GetObject("BtReparto.Image"), System.Drawing.Image)
        Me.BtReparto.Location = New System.Drawing.Point(3, 4)
        Me.BtReparto.Name = "BtReparto"
        Me.BtReparto.Size = New System.Drawing.Size(146, 58)
        Me.BtReparto.TabIndex = 6
        Me.BtReparto.Tag = "reparto"
        Me.BtReparto.Text = "Pedidos"
        Me.BtReparto.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.BtReparto.UseVisualStyleBackColor = True
        Me.BtReparto.Visible = False
        '
        'LblSubTitle
        '
        Me.LblSubTitle.ForeColor = System.Drawing.SystemColors.InactiveCaption
        Me.LblSubTitle.Location = New System.Drawing.Point(96, 32)
        Me.LblSubTitle.Name = "LblSubTitle"
        Me.LblSubTitle.Size = New System.Drawing.Size(290, 31)
        Me.LblSubTitle.TabIndex = 1
        Me.LblSubTitle.Text = "Situación del Diseño del local y consumiciones activas, con la posibilidad de ini" & _
            "ciar el Modo Caja Directa."
        '
        'LblTitle
        '
        Me.LblTitle.AutoSize = True
        Me.LblTitle.Font = New System.Drawing.Font("Tahoma", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblTitle.Location = New System.Drawing.Point(57, 4)
        Me.LblTitle.Name = "LblTitle"
        Me.LblTitle.Size = New System.Drawing.Size(186, 23)
        Me.LblTitle.TabIndex = 0
        Me.LblTitle.Text = "Panel de Situación"
        '
        'pnlCashLogy
        '
        Me.pnlCashLogy.BackColor = System.Drawing.Color.DimGray
        Me.pnlCashLogy.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlCashLogy.Controls.Add(Me.ctCashlogy_config)
        Me.pnlCashLogy.Controls.Add(Me.Button1)
        Me.pnlCashLogy.Controls.Add(Me.ctCashlogy_DarCambio)
        Me.pnlCashLogy.Location = New System.Drawing.Point(3, 137)
        Me.pnlCashLogy.Name = "pnlCashLogy"
        Me.pnlCashLogy.Size = New System.Drawing.Size(142, 219)
        Me.pnlCashLogy.TabIndex = 1
        Me.pnlCashLogy.Visible = False
        '
        'ctCashlogy_config
        '
        Me.ctCashlogy_config.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ctCashlogy_config.ForeColor = System.Drawing.Color.Black
        Me.ctCashlogy_config.Image = CType(resources.GetObject("ctCashlogy_config.Image"), System.Drawing.Image)
        Me.ctCashlogy_config.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.ctCashlogy_config.Location = New System.Drawing.Point(3, 150)
        Me.ctCashlogy_config.Name = "ctCashlogy_config"
        Me.ctCashlogy_config.Size = New System.Drawing.Size(134, 53)
        Me.ctCashlogy_config.TabIndex = 41
        Me.ctCashlogy_config.Text = "    BackOffice"
        Me.ctCashlogy_config.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.ctCashlogy_config.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.ForeColor = System.Drawing.Color.Black
        Me.Button1.Image = CType(resources.GetObject("Button1.Image"), System.Drawing.Image)
        Me.Button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Button1.Location = New System.Drawing.Point(3, 61)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(134, 53)
        Me.Button1.TabIndex = 40
        Me.Button1.Text = "    Dar Cambio"
        Me.Button1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.Button1.UseVisualStyleBackColor = True
        Me.Button1.Visible = False
        '
        'ctCashlogy_DarCambio
        '
        Me.ctCashlogy_DarCambio.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ctCashlogy_DarCambio.ForeColor = System.Drawing.Color.Black
        Me.ctCashlogy_DarCambio.Image = CType(resources.GetObject("ctCashlogy_DarCambio.Image"), System.Drawing.Image)
        Me.ctCashlogy_DarCambio.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.ctCashlogy_DarCambio.Location = New System.Drawing.Point(3, 7)
        Me.ctCashlogy_DarCambio.Name = "ctCashlogy_DarCambio"
        Me.ctCashlogy_DarCambio.Size = New System.Drawing.Size(134, 53)
        Me.ctCashlogy_DarCambio.TabIndex = 39
        Me.ctCashlogy_DarCambio.Text = "    Dar Cambio"
        Me.ctCashlogy_DarCambio.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.ctCashlogy_DarCambio.UseVisualStyleBackColor = True
        '
        'PnlBody
        '
        Me.PnlBody.BackColor = System.Drawing.SystemColors.Control
        Me.PnlBody.BackgroundImage = CType(resources.GetObject("PnlBody.BackgroundImage"), System.Drawing.Image)
        Me.PnlBody.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PnlBody.Controls.Add(Me.PnlData)
        Me.PnlBody.ForeColor = System.Drawing.Color.Black
        Me.PnlBody.Location = New System.Drawing.Point(12, 14)
        Me.PnlBody.Name = "PnlBody"
        Me.PnlBody.Size = New System.Drawing.Size(982, 669)
        Me.PnlBody.TabIndex = 0
        Me.PnlBody.Visible = False
        '
        'PnlData
        '
        Me.PnlData.BackColor = System.Drawing.Color.FromArgb(CType(CType(174, Byte), Integer), CType(CType(186, Byte), Integer), CType(CType(186, Byte), Integer))
        Me.PnlData.Controls.Add(Me.PnlZonas)
        Me.PnlData.Controls.Add(Me.PnlAction_Buttons)
        Me.PnlData.Controls.Add(Me.PnlHistory)
        Me.PnlData.Controls.Add(Me.PicPlano)
        Me.PnlData.Location = New System.Drawing.Point(37, 34)
        Me.PnlData.Name = "PnlData"
        Me.PnlData.Size = New System.Drawing.Size(908, 603)
        Me.PnlData.TabIndex = 38
        '
        'PnlZonas
        '
        Me.PnlZonas.BackColor = System.Drawing.Color.FromArgb(CType(CType(174, Byte), Integer), CType(CType(186, Byte), Integer), CType(CType(186, Byte), Integer))
        Me.PnlZonas.Controls.Add(Me.BtZona_Right)
        Me.PnlZonas.Controls.Add(Me.BtZona_Left)
        Me.PnlZonas.Controls.Add(Label2)
        Me.PnlZonas.Controls.Add(Me.CbZonas)
        Me.PnlZonas.Location = New System.Drawing.Point(493, 3)
        Me.PnlZonas.Name = "PnlZonas"
        Me.PnlZonas.Size = New System.Drawing.Size(412, 77)
        Me.PnlZonas.TabIndex = 41
        '
        'BtZona_Right
        '
        Me.BtZona_Right.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtZona_Right.Image = CType(resources.GetObject("BtZona_Right.Image"), System.Drawing.Image)
        Me.BtZona_Right.Location = New System.Drawing.Point(365, 23)
        Me.BtZona_Right.Name = "BtZona_Right"
        Me.BtZona_Right.Size = New System.Drawing.Size(43, 39)
        Me.BtZona_Right.TabIndex = 26
        Me.BtZona_Right.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.BtZona_Right.UseVisualStyleBackColor = True
        '
        'BtZona_Left
        '
        Me.BtZona_Left.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtZona_Left.Image = CType(resources.GetObject("BtZona_Left.Image"), System.Drawing.Image)
        Me.BtZona_Left.Location = New System.Drawing.Point(321, 23)
        Me.BtZona_Left.Name = "BtZona_Left"
        Me.BtZona_Left.Size = New System.Drawing.Size(43, 39)
        Me.BtZona_Left.TabIndex = 25
        Me.BtZona_Left.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.BtZona_Left.UseVisualStyleBackColor = True
        '
        'CbZonas
        '
        Me.CbZonas.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CbZonas.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CbZonas.FormattingEnabled = True
        Me.CbZonas.Location = New System.Drawing.Point(21, 23)
        Me.CbZonas.Name = "CbZonas"
        Me.CbZonas.Size = New System.Drawing.Size(298, 39)
        Me.CbZonas.TabIndex = 23
        '
        'PnlAction_Buttons
        '
        Me.PnlAction_Buttons.BackColor = System.Drawing.Color.FromArgb(CType(CType(174, Byte), Integer), CType(CType(186, Byte), Integer), CType(CType(186, Byte), Integer))
        Me.PnlAction_Buttons.Controls.Add(Me.Group_Last)
        Me.PnlAction_Buttons.Controls.Add(Label1)
        Me.PnlAction_Buttons.Controls.Add(Label6)
        Me.PnlAction_Buttons.Location = New System.Drawing.Point(532, 88)
        Me.PnlAction_Buttons.Name = "PnlAction_Buttons"
        Me.PnlAction_Buttons.Size = New System.Drawing.Size(369, 80)
        Me.PnlAction_Buttons.TabIndex = 37
        Me.PnlAction_Buttons.Tag = "NO_SCAN"
        Me.PnlAction_Buttons.Visible = False
        '
        'Group_Last
        '
        Me.Group_Last.BackColor = System.Drawing.Color.FromArgb(CType(CType(174, Byte), Integer), CType(CType(186, Byte), Integer), CType(CType(186, Byte), Integer))
        Me.Group_Last.Controls.Add(Me.PnlLast)
        Me.Group_Last.Enabled = False
        Me.Group_Last.Font = New System.Drawing.Font("Tahoma", 6.75!)
        Me.Group_Last.Location = New System.Drawing.Point(95, 0)
        Me.Group_Last.Name = "Group_Last"
        Me.Group_Last.Size = New System.Drawing.Size(271, 77)
        Me.Group_Last.TabIndex = 22
        Me.Group_Last.TabStop = False
        Me.Group_Last.Text = "Último Ticket Cobrado"
        '
        'PnlHistory
        '
        Me.PnlHistory.BackColor = System.Drawing.Color.Gainsboro
        Me.PnlHistory.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.PnlHistory.Controls.Add(Me.GroupHistory)
        Me.PnlHistory.Controls.Add(Me.BtHistory_Next)
        Me.PnlHistory.Controls.Add(Me.BtHistory_Previous)
        Me.PnlHistory.Location = New System.Drawing.Point(0, 1)
        Me.PnlHistory.Name = "PnlHistory"
        Me.PnlHistory.Size = New System.Drawing.Size(487, 79)
        Me.PnlHistory.TabIndex = 40
        '
        'GroupHistory
        '
        Me.GroupHistory.BackColor = System.Drawing.Color.Gainsboro
        Me.GroupHistory.Controls.Add(Me.BtHistory_Edit)
        Me.GroupHistory.Controls.Add(Me.BtHistory_Print)
        Me.GroupHistory.Controls.Add(Me.LblHistory_Fh)
        Me.GroupHistory.Controls.Add(Me.Label16)
        Me.GroupHistory.Controls.Add(Me.Label17)
        Me.GroupHistory.Controls.Add(Me.LblHistory_Mesa)
        Me.GroupHistory.Controls.Add(Me.Label14)
        Me.GroupHistory.Controls.Add(Me.LblHistory_Total)
        Me.GroupHistory.Controls.Add(Me.LblHistory_Empleado)
        Me.GroupHistory.Controls.Add(Me.LblHistory_Ref)
        Me.GroupHistory.Font = New System.Drawing.Font("Tahoma", 6.75!)
        Me.GroupHistory.Location = New System.Drawing.Point(55, 1)
        Me.GroupHistory.Name = "GroupHistory"
        Me.GroupHistory.Size = New System.Drawing.Size(371, 71)
        Me.GroupHistory.TabIndex = 23
        Me.GroupHistory.TabStop = False
        Me.GroupHistory.Text = "Historial de Tickets"
        '
        'BtHistory_Edit
        '
        Me.BtHistory_Edit.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtHistory_Edit.Image = CType(resources.GetObject("BtHistory_Edit.Image"), System.Drawing.Image)
        Me.BtHistory_Edit.Location = New System.Drawing.Point(316, 38)
        Me.BtHistory_Edit.Name = "BtHistory_Edit"
        Me.BtHistory_Edit.Size = New System.Drawing.Size(49, 31)
        Me.BtHistory_Edit.TabIndex = 2
        Me.BtHistory_Edit.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.BtHistory_Edit.UseVisualStyleBackColor = True
        '
        'BtHistory_Print
        '
        Me.BtHistory_Print.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtHistory_Print.Image = CType(resources.GetObject("BtHistory_Print.Image"), System.Drawing.Image)
        Me.BtHistory_Print.Location = New System.Drawing.Point(316, 7)
        Me.BtHistory_Print.Name = "BtHistory_Print"
        Me.BtHistory_Print.Size = New System.Drawing.Size(49, 31)
        Me.BtHistory_Print.TabIndex = 1
        Me.BtHistory_Print.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.BtHistory_Print.UseVisualStyleBackColor = True
        '
        'LblHistory_Fh
        '
        Me.LblHistory_Fh.BackColor = System.Drawing.Color.Gainsboro
        Me.LblHistory_Fh.Font = New System.Drawing.Font("Tahoma", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblHistory_Fh.Location = New System.Drawing.Point(7, 27)
        Me.LblHistory_Fh.Name = "LblHistory_Fh"
        Me.LblHistory_Fh.Size = New System.Drawing.Size(150, 12)
        Me.LblHistory_Fh.TabIndex = 41
        Me.LblHistory_Fh.Text = "Fecha: 09/09/2008 00:00"
        Me.LblHistory_Fh.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.BackColor = System.Drawing.Color.Silver
        Me.Label16.Font = New System.Drawing.Font("Tahoma", 5.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.Location = New System.Drawing.Point(165, 9)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(37, 8)
        Me.Label16.TabIndex = 34
        Me.Label16.Text = "IMPORTE"
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Font = New System.Drawing.Font("Tahoma", 6.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.ForeColor = System.Drawing.Color.Black
        Me.Label17.Location = New System.Drawing.Point(11, 56)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(27, 10)
        Me.Label17.TabIndex = 32
        Me.Label17.Text = "MESA:"
        '
        'LblHistory_Mesa
        '
        Me.LblHistory_Mesa.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblHistory_Mesa.ForeColor = System.Drawing.Color.DimGray
        Me.LblHistory_Mesa.Location = New System.Drawing.Point(56, 54)
        Me.LblHistory_Mesa.Name = "LblHistory_Mesa"
        Me.LblHistory_Mesa.Size = New System.Drawing.Size(167, 15)
        Me.LblHistory_Mesa.TabIndex = 31
        Me.LblHistory_Mesa.Text = "CAJA DIRECTA"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Tahoma", 6.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.ForeColor = System.Drawing.Color.Black
        Me.Label14.Location = New System.Drawing.Point(11, 43)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(46, 10)
        Me.Label14.TabIndex = 36
        Me.Label14.Text = "EMPLEADO:"
        '
        'LblHistory_Total
        '
        Me.LblHistory_Total.BackColor = System.Drawing.Color.Silver
        Me.LblHistory_Total.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LblHistory_Total.Font = New System.Drawing.Font("Tahoma", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblHistory_Total.Location = New System.Drawing.Point(161, 8)
        Me.LblHistory_Total.Name = "LblHistory_Total"
        Me.LblHistory_Total.Size = New System.Drawing.Size(142, 34)
        Me.LblHistory_Total.TabIndex = 0
        Me.LblHistory_Total.Text = "0"
        Me.LblHistory_Total.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'LblHistory_Ref
        '
        Me.LblHistory_Ref.BackColor = System.Drawing.Color.Gainsboro
        Me.LblHistory_Ref.Font = New System.Drawing.Font("Tahoma", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblHistory_Ref.Location = New System.Drawing.Point(7, 13)
        Me.LblHistory_Ref.Name = "LblHistory_Ref"
        Me.LblHistory_Ref.Size = New System.Drawing.Size(129, 12)
        Me.LblHistory_Ref.TabIndex = 39
        Me.LblHistory_Ref.Text = "Ref.: 0"
        Me.LblHistory_Ref.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'BtHistory_Next
        '
        Me.BtHistory_Next.BackColor = System.Drawing.SystemColors.Control
        Me.BtHistory_Next.Enabled = False
        Me.BtHistory_Next.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtHistory_Next.Image = CType(resources.GetObject("BtHistory_Next.Image"), System.Drawing.Image)
        Me.BtHistory_Next.Location = New System.Drawing.Point(432, 1)
        Me.BtHistory_Next.Name = "BtHistory_Next"
        Me.BtHistory_Next.Size = New System.Drawing.Size(50, 73)
        Me.BtHistory_Next.TabIndex = 1
        Me.BtHistory_Next.Tag = ""
        Me.BtHistory_Next.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtHistory_Next.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage
        Me.BtHistory_Next.UseVisualStyleBackColor = False
        '
        'BtHistory_Previous
        '
        Me.BtHistory_Previous.BackColor = System.Drawing.SystemColors.Control
        Me.BtHistory_Previous.Enabled = False
        Me.BtHistory_Previous.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtHistory_Previous.Image = CType(resources.GetObject("BtHistory_Previous.Image"), System.Drawing.Image)
        Me.BtHistory_Previous.Location = New System.Drawing.Point(0, 1)
        Me.BtHistory_Previous.Name = "BtHistory_Previous"
        Me.BtHistory_Previous.Size = New System.Drawing.Size(49, 73)
        Me.BtHistory_Previous.TabIndex = 0
        Me.BtHistory_Previous.Tag = ""
        Me.BtHistory_Previous.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BtHistory_Previous.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.BtHistory_Previous.UseVisualStyleBackColor = False
        '
        'PicPlano
        '
        Me.PicPlano.BackColor = System.Drawing.Color.Black
        Me.PicPlano.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.PicPlano.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PicPlano.Location = New System.Drawing.Point(0, 81)
        Me.PicPlano.Name = "PicPlano"
        Me.PicPlano.Size = New System.Drawing.Size(908, 522)
        Me.PicPlano.TabIndex = 0
        Me.PicPlano.TabStop = False
        '
        'TmHour
        '
        Me.TmHour.Interval = 30000
        '
        'tmrMesas
        '
        Me.tmrMesas.Interval = 30000
        '
        'frmPaneldeSituacion
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoScroll = True
        Me.BackColor = System.Drawing.Color.Black
        Me.ClientSize = New System.Drawing.Size(1020, 770)
        Me.Controls.Add(Me.SplitContainer)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.KeyPreview = True
        Me.Name = "frmPaneldeSituacion"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.PnlLast.ResumeLayout(False)
        Me.PnlLast.PerformLayout()
        Me.SplitContainer.Panel1.ResumeLayout(False)
        Me.SplitContainer.Panel1.PerformLayout()
        Me.SplitContainer.Panel2.ResumeLayout(False)
        Me.SplitContainer.ResumeLayout(False)
        CType(Me.m_logo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PnlButton_Shell.ResumeLayout(False)
        Me.pnlCashLogy.ResumeLayout(False)
        Me.PnlBody.ResumeLayout(False)
        Me.PnlData.ResumeLayout(False)
        Me.PnlZonas.ResumeLayout(False)
        Me.PnlZonas.PerformLayout()
        Me.PnlAction_Buttons.ResumeLayout(False)
        Me.PnlAction_Buttons.PerformLayout()
        Me.Group_Last.ResumeLayout(False)
        Me.PnlHistory.ResumeLayout(False)
        Me.GroupHistory.ResumeLayout(False)
        Me.GroupHistory.PerformLayout()
        CType(Me.PicPlano, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents SplitContainer As System.Windows.Forms.SplitContainer
    Friend WithEvents m_logo As System.Windows.Forms.PictureBox
    Friend WithEvents PnlButton_Shell As System.Windows.Forms.Panel
    Friend WithEvents BtClose As System.Windows.Forms.Button
    Friend WithEvents BtReparto As System.Windows.Forms.Button
    Friend WithEvents LblSubTitle As System.Windows.Forms.Label
    Friend WithEvents LblTitle As System.Windows.Forms.Label
    Friend WithEvents PnlBody As System.Windows.Forms.Panel
    Friend WithEvents PnlData As System.Windows.Forms.Panel
    Friend WithEvents ToolTip As System.Windows.Forms.ToolTip
    Friend WithEvents PicPlano As System.Windows.Forms.PictureBox
    Friend WithEvents PnlAction_Buttons As System.Windows.Forms.Panel
    Friend WithEvents BtCajaDirecta As System.Windows.Forms.Button
    Friend WithEvents LblHour As System.Windows.Forms.Label
    Friend WithEvents TmHour As System.Windows.Forms.Timer
    Friend WithEvents Group_Last As System.Windows.Forms.GroupBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents LblMesa As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents LblTotal As System.Windows.Forms.Label
    Friend WithEvents BtPrintLastTicket As System.Windows.Forms.Button
    Friend WithEvents LblLastRef As System.Windows.Forms.Label
    Friend WithEvents PnlLast As System.Windows.Forms.Panel
    Friend WithEvents PnlHistory As System.Windows.Forms.Panel
    Friend WithEvents GroupHistory As System.Windows.Forms.GroupBox
    Friend WithEvents BtHistory_Edit As System.Windows.Forms.Button
    Friend WithEvents LblHistory_Ref As System.Windows.Forms.Label
    Friend WithEvents BtHistory_Print As System.Windows.Forms.Button
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents LblHistory_Mesa As System.Windows.Forms.Label
    Friend WithEvents LblHistory_Total As System.Windows.Forms.Label
    Friend WithEvents BtHistory_Next As System.Windows.Forms.Button
    Friend WithEvents BtHistory_Previous As System.Windows.Forms.Button
    Friend WithEvents LblHistory_Fh As System.Windows.Forms.Label
    Friend WithEvents LblHistory_Empleado As System.Windows.Forms.Label
    Friend WithEvents PnlZonas As System.Windows.Forms.Panel
    Friend WithEvents CbZonas As System.Windows.Forms.ComboBox
    Friend WithEvents BtZona_Left As System.Windows.Forms.Button
    Friend WithEvents BtZona_Right As System.Windows.Forms.Button
    Friend WithEvents BtKeyBoard As System.Windows.Forms.Button
    Friend WithEvents tmrMesas As System.Windows.Forms.Timer
    Friend WithEvents pnlCashLogy As System.Windows.Forms.Panel
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents ctCashlogy_DarCambio As System.Windows.Forms.Button
    Friend WithEvents ctCashlogy_config As System.Windows.Forms.Button
End Class
