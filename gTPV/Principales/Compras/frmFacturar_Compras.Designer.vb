<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmFacturar_Compras
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
        Dim GroupFacturar As System.Windows.Forms.GroupBox
        Dim GroupPVPs As System.Windows.Forms.GroupBox
        Dim Label4 As System.Windows.Forms.Label
        Dim Label13 As System.Windows.Forms.Label
        Dim Label10 As System.Windows.Forms.Label
        Dim Label8 As System.Windows.Forms.Label
        Dim Label6 As System.Windows.Forms.Label
        Dim Label3 As System.Windows.Forms.Label
        Dim ToolStrip As System.Windows.Forms.ToolStrip
        Dim LblSubName As System.Windows.Forms.Label
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmFacturar_Compras))
        Me.TxtFactura = New System.Windows.Forms.TextBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.TxtObs = New System.Windows.Forms.TextBox
        Me.DtFactura = New System.Windows.Forms.DateTimePicker
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.LblIVA_Basico = New System.Windows.Forms.Label
        Me.LblIVA_Medio = New System.Windows.Forms.Label
        Me.LblIVA_General = New System.Windows.Forms.Label
        Me.LblNfoIVA_Basico = New System.Windows.Forms.Label
        Me.LblPvp_Base_Basico = New System.Windows.Forms.Label
        Me.LblPvp_Total_Basico = New System.Windows.Forms.Label
        Me.LblPvp_Iva_Basico = New System.Windows.Forms.Label
        Me.LblNfoIVA_Medio = New System.Windows.Forms.Label
        Me.LblPvp_Base_Medio = New System.Windows.Forms.Label
        Me.LblPvp_Total_Medio = New System.Windows.Forms.Label
        Me.LblPvp_Iva_Medio = New System.Windows.Forms.Label
        Me.LblNfoIVA_General = New System.Windows.Forms.Label
        Me.LblPvp_Base_General = New System.Windows.Forms.Label
        Me.LblPvp_Total_General = New System.Windows.Forms.Label
        Me.LblPvp_Iva_General = New System.Windows.Forms.Label
        Me.LblTitle = New System.Windows.Forms.ToolStripLabel
        Me.BtOk = New System.Windows.Forms.Button
        Me.BtCancell = New System.Windows.Forms.Button
        Me.Group_Albaranes = New System.Windows.Forms.GroupBox
        Me.LstAlbaranes = New System.Windows.Forms.ListView
        Me.Col_id = New System.Windows.Forms.ColumnHeader
        Me.Col_Fh = New System.Windows.Forms.ColumnHeader
        Me.Col_Albaran = New System.Windows.Forms.ColumnHeader
        Me.Col_Base_General = New System.Windows.Forms.ColumnHeader
        Me.Col_Base_Medio = New System.Windows.Forms.ColumnHeader
        Me.Col_Base_Basico = New System.Windows.Forms.ColumnHeader
        Me.Col_Iva_General = New System.Windows.Forms.ColumnHeader
        Me.Col_Iva_Medio = New System.Windows.Forms.ColumnHeader
        Me.Col_Iva_Basico = New System.Windows.Forms.ColumnHeader
        Me.Col_Total = New System.Windows.Forms.ColumnHeader
        Me.LblPvp_Total = New System.Windows.Forms.Label
        Me.SplitContainer = New System.Windows.Forms.SplitContainer
        Me.LblId = New System.Windows.Forms.Label
        Me.PicImg = New System.Windows.Forms.PictureBox
        Me.LblName = New System.Windows.Forms.Label
        GroupFacturar = New System.Windows.Forms.GroupBox
        GroupPVPs = New System.Windows.Forms.GroupBox
        Label4 = New System.Windows.Forms.Label
        Label13 = New System.Windows.Forms.Label
        Label10 = New System.Windows.Forms.Label
        Label8 = New System.Windows.Forms.Label
        Label6 = New System.Windows.Forms.Label
        Label3 = New System.Windows.Forms.Label
        ToolStrip = New System.Windows.Forms.ToolStrip
        LblSubName = New System.Windows.Forms.Label
        GroupFacturar.SuspendLayout()
        GroupPVPs.SuspendLayout()
        ToolStrip.SuspendLayout()
        Me.Group_Albaranes.SuspendLayout()
        Me.SplitContainer.Panel1.SuspendLayout()
        Me.SplitContainer.Panel2.SuspendLayout()
        Me.SplitContainer.SuspendLayout()
        CType(Me.PicImg, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupFacturar
        '
        GroupFacturar.Controls.Add(Me.TxtFactura)
        GroupFacturar.Controls.Add(Me.Label5)
        GroupFacturar.Controls.Add(Me.TxtObs)
        GroupFacturar.Controls.Add(Me.DtFactura)
        GroupFacturar.Controls.Add(Me.Label2)
        GroupFacturar.Controls.Add(Me.Label1)
        GroupFacturar.Location = New System.Drawing.Point(9, 223)
        GroupFacturar.Name = "GroupFacturar"
        GroupFacturar.Size = New System.Drawing.Size(469, 198)
        GroupFacturar.TabIndex = 0
        GroupFacturar.TabStop = False
        GroupFacturar.Text = "Detalles de la factura"
        '
        'TxtFactura
        '
        Me.TxtFactura.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtFactura.Location = New System.Drawing.Point(111, 18)
        Me.TxtFactura.MaxLength = 50
        Me.TxtFactura.Name = "TxtFactura"
        Me.TxtFactura.Size = New System.Drawing.Size(184, 27)
        Me.TxtFactura.TabIndex = 6
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(6, 26)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(83, 13)
        Me.Label5.TabIndex = 5
        Me.Label5.Text = "Nº de la factura"
        '
        'TxtObs
        '
        Me.TxtObs.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtObs.Location = New System.Drawing.Point(111, 84)
        Me.TxtObs.Multiline = True
        Me.TxtObs.Name = "TxtObs"
        Me.TxtObs.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.TxtObs.Size = New System.Drawing.Size(352, 103)
        Me.TxtObs.TabIndex = 1
        '
        'DtFactura
        '
        Me.DtFactura.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DtFactura.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DtFactura.Location = New System.Drawing.Point(111, 51)
        Me.DtFactura.Name = "DtFactura"
        Me.DtFactura.Size = New System.Drawing.Size(184, 27)
        Me.DtFactura.TabIndex = 0
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(6, 86)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(78, 13)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "Observaciones"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(6, 60)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(100, 13)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "Fecha de la factura"
        '
        'GroupPVPs
        '
        GroupPVPs.Controls.Add(Me.LblIVA_Basico)
        GroupPVPs.Controls.Add(Me.LblIVA_Medio)
        GroupPVPs.Controls.Add(Me.LblIVA_General)
        GroupPVPs.Controls.Add(Label4)
        GroupPVPs.Controls.Add(Me.LblNfoIVA_Basico)
        GroupPVPs.Controls.Add(Me.LblPvp_Base_Basico)
        GroupPVPs.Controls.Add(Me.LblPvp_Total_Basico)
        GroupPVPs.Controls.Add(Me.LblPvp_Iva_Basico)
        GroupPVPs.Controls.Add(Me.LblNfoIVA_Medio)
        GroupPVPs.Controls.Add(Me.LblPvp_Base_Medio)
        GroupPVPs.Controls.Add(Me.LblPvp_Total_Medio)
        GroupPVPs.Controls.Add(Me.LblPvp_Iva_Medio)
        GroupPVPs.Controls.Add(Me.LblNfoIVA_General)
        GroupPVPs.Controls.Add(Me.LblPvp_Base_General)
        GroupPVPs.Controls.Add(Label13)
        GroupPVPs.Controls.Add(Me.LblPvp_Total_General)
        GroupPVPs.Controls.Add(Label10)
        GroupPVPs.Controls.Add(Label8)
        GroupPVPs.Controls.Add(Me.LblPvp_Iva_General)
        GroupPVPs.Controls.Add(Label6)
        GroupPVPs.Location = New System.Drawing.Point(9, 427)
        GroupPVPs.Name = "GroupPVPs"
        GroupPVPs.Size = New System.Drawing.Size(469, 104)
        GroupPVPs.TabIndex = 72
        GroupPVPs.TabStop = False
        GroupPVPs.Text = "Resumen"
        '
        'LblIVA_Basico
        '
        Me.LblIVA_Basico.BackColor = System.Drawing.Color.Lavender
        Me.LblIVA_Basico.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.LblIVA_Basico.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblIVA_Basico.Location = New System.Drawing.Point(257, 75)
        Me.LblIVA_Basico.Margin = New System.Windows.Forms.Padding(0)
        Me.LblIVA_Basico.Name = "LblIVA_Basico"
        Me.LblIVA_Basico.Size = New System.Drawing.Size(41, 20)
        Me.LblIVA_Basico.TabIndex = 101
        Me.LblIVA_Basico.Tag = ""
        Me.LblIVA_Basico.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'LblIVA_Medio
        '
        Me.LblIVA_Medio.BackColor = System.Drawing.Color.Lavender
        Me.LblIVA_Medio.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.LblIVA_Medio.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblIVA_Medio.Location = New System.Drawing.Point(257, 55)
        Me.LblIVA_Medio.Margin = New System.Windows.Forms.Padding(0)
        Me.LblIVA_Medio.Name = "LblIVA_Medio"
        Me.LblIVA_Medio.Size = New System.Drawing.Size(41, 20)
        Me.LblIVA_Medio.TabIndex = 100
        Me.LblIVA_Medio.Tag = ""
        Me.LblIVA_Medio.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'LblIVA_General
        '
        Me.LblIVA_General.BackColor = System.Drawing.Color.Lavender
        Me.LblIVA_General.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.LblIVA_General.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblIVA_General.Location = New System.Drawing.Point(257, 35)
        Me.LblIVA_General.Margin = New System.Windows.Forms.Padding(0)
        Me.LblIVA_General.Name = "LblIVA_General"
        Me.LblIVA_General.Size = New System.Drawing.Size(41, 20)
        Me.LblIVA_General.TabIndex = 99
        Me.LblIVA_General.Tag = ""
        Me.LblIVA_General.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label4
        '
        Label4.BackColor = System.Drawing.Color.LightSteelBlue
        Label4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Label4.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Label4.Location = New System.Drawing.Point(257, 16)
        Label4.Margin = New System.Windows.Forms.Padding(0)
        Label4.Name = "Label4"
        Label4.Size = New System.Drawing.Size(41, 19)
        Label4.TabIndex = 98
        Label4.Text = "% IVA"
        Label4.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'LblNfoIVA_Basico
        '
        Me.LblNfoIVA_Basico.BackColor = System.Drawing.Color.Lavender
        Me.LblNfoIVA_Basico.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.LblNfoIVA_Basico.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblNfoIVA_Basico.Location = New System.Drawing.Point(190, 75)
        Me.LblNfoIVA_Basico.Margin = New System.Windows.Forms.Padding(0)
        Me.LblNfoIVA_Basico.Name = "LblNfoIVA_Basico"
        Me.LblNfoIVA_Basico.Size = New System.Drawing.Size(67, 20)
        Me.LblNfoIVA_Basico.TabIndex = 81
        Me.LblNfoIVA_Basico.Tag = ""
        Me.LblNfoIVA_Basico.Text = "BÁSICO"
        Me.LblNfoIVA_Basico.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'LblPvp_Base_Basico
        '
        Me.LblPvp_Base_Basico.BackColor = System.Drawing.Color.Lavender
        Me.LblPvp_Base_Basico.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.LblPvp_Base_Basico.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblPvp_Base_Basico.Location = New System.Drawing.Point(112, 75)
        Me.LblPvp_Base_Basico.Margin = New System.Windows.Forms.Padding(0)
        Me.LblPvp_Base_Basico.Name = "LblPvp_Base_Basico"
        Me.LblPvp_Base_Basico.Size = New System.Drawing.Size(78, 20)
        Me.LblPvp_Base_Basico.TabIndex = 78
        Me.LblPvp_Base_Basico.Tag = "pvp_base_basico"
        Me.LblPvp_Base_Basico.Text = "0,00"
        Me.LblPvp_Base_Basico.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'LblPvp_Total_Basico
        '
        Me.LblPvp_Total_Basico.BackColor = System.Drawing.Color.LightBlue
        Me.LblPvp_Total_Basico.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.LblPvp_Total_Basico.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblPvp_Total_Basico.Location = New System.Drawing.Point(365, 75)
        Me.LblPvp_Total_Basico.Margin = New System.Windows.Forms.Padding(0)
        Me.LblPvp_Total_Basico.Name = "LblPvp_Total_Basico"
        Me.LblPvp_Total_Basico.Size = New System.Drawing.Size(90, 20)
        Me.LblPvp_Total_Basico.TabIndex = 77
        Me.LblPvp_Total_Basico.Tag = "pvp_total_basico"
        Me.LblPvp_Total_Basico.Text = "0,00"
        Me.LblPvp_Total_Basico.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'LblPvp_Iva_Basico
        '
        Me.LblPvp_Iva_Basico.BackColor = System.Drawing.Color.Lavender
        Me.LblPvp_Iva_Basico.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.LblPvp_Iva_Basico.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblPvp_Iva_Basico.Location = New System.Drawing.Point(298, 75)
        Me.LblPvp_Iva_Basico.Margin = New System.Windows.Forms.Padding(0)
        Me.LblPvp_Iva_Basico.Name = "LblPvp_Iva_Basico"
        Me.LblPvp_Iva_Basico.Size = New System.Drawing.Size(67, 20)
        Me.LblPvp_Iva_Basico.TabIndex = 76
        Me.LblPvp_Iva_Basico.Tag = "pvp_iva_basico"
        Me.LblPvp_Iva_Basico.Text = "0,00"
        Me.LblPvp_Iva_Basico.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'LblNfoIVA_Medio
        '
        Me.LblNfoIVA_Medio.BackColor = System.Drawing.Color.Lavender
        Me.LblNfoIVA_Medio.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.LblNfoIVA_Medio.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblNfoIVA_Medio.Location = New System.Drawing.Point(190, 55)
        Me.LblNfoIVA_Medio.Margin = New System.Windows.Forms.Padding(0)
        Me.LblNfoIVA_Medio.Name = "LblNfoIVA_Medio"
        Me.LblNfoIVA_Medio.Size = New System.Drawing.Size(67, 20)
        Me.LblNfoIVA_Medio.TabIndex = 57
        Me.LblNfoIVA_Medio.Tag = ""
        Me.LblNfoIVA_Medio.Text = "MEDIO"
        Me.LblNfoIVA_Medio.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'LblPvp_Base_Medio
        '
        Me.LblPvp_Base_Medio.BackColor = System.Drawing.Color.Lavender
        Me.LblPvp_Base_Medio.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.LblPvp_Base_Medio.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblPvp_Base_Medio.Location = New System.Drawing.Point(112, 55)
        Me.LblPvp_Base_Medio.Margin = New System.Windows.Forms.Padding(0)
        Me.LblPvp_Base_Medio.Name = "LblPvp_Base_Medio"
        Me.LblPvp_Base_Medio.Size = New System.Drawing.Size(78, 20)
        Me.LblPvp_Base_Medio.TabIndex = 54
        Me.LblPvp_Base_Medio.Tag = "pvp_base_medio"
        Me.LblPvp_Base_Medio.Text = "0,00"
        Me.LblPvp_Base_Medio.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'LblPvp_Total_Medio
        '
        Me.LblPvp_Total_Medio.BackColor = System.Drawing.Color.LightBlue
        Me.LblPvp_Total_Medio.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.LblPvp_Total_Medio.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblPvp_Total_Medio.Location = New System.Drawing.Point(365, 55)
        Me.LblPvp_Total_Medio.Margin = New System.Windows.Forms.Padding(0)
        Me.LblPvp_Total_Medio.Name = "LblPvp_Total_Medio"
        Me.LblPvp_Total_Medio.Size = New System.Drawing.Size(90, 20)
        Me.LblPvp_Total_Medio.TabIndex = 53
        Me.LblPvp_Total_Medio.Tag = "pvp_total_medio"
        Me.LblPvp_Total_Medio.Text = "0,00"
        Me.LblPvp_Total_Medio.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'LblPvp_Iva_Medio
        '
        Me.LblPvp_Iva_Medio.BackColor = System.Drawing.Color.Lavender
        Me.LblPvp_Iva_Medio.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.LblPvp_Iva_Medio.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblPvp_Iva_Medio.Location = New System.Drawing.Point(298, 55)
        Me.LblPvp_Iva_Medio.Margin = New System.Windows.Forms.Padding(0)
        Me.LblPvp_Iva_Medio.Name = "LblPvp_Iva_Medio"
        Me.LblPvp_Iva_Medio.Size = New System.Drawing.Size(67, 20)
        Me.LblPvp_Iva_Medio.TabIndex = 52
        Me.LblPvp_Iva_Medio.Tag = "pvp_iva_medio"
        Me.LblPvp_Iva_Medio.Text = "0,00"
        Me.LblPvp_Iva_Medio.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'LblNfoIVA_General
        '
        Me.LblNfoIVA_General.BackColor = System.Drawing.Color.Lavender
        Me.LblNfoIVA_General.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.LblNfoIVA_General.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblNfoIVA_General.Location = New System.Drawing.Point(190, 35)
        Me.LblNfoIVA_General.Margin = New System.Windows.Forms.Padding(0)
        Me.LblNfoIVA_General.Name = "LblNfoIVA_General"
        Me.LblNfoIVA_General.Size = New System.Drawing.Size(67, 20)
        Me.LblNfoIVA_General.TabIndex = 51
        Me.LblNfoIVA_General.Tag = ""
        Me.LblNfoIVA_General.Text = "GENERAL"
        Me.LblNfoIVA_General.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'LblPvp_Base_General
        '
        Me.LblPvp_Base_General.BackColor = System.Drawing.Color.Lavender
        Me.LblPvp_Base_General.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.LblPvp_Base_General.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblPvp_Base_General.Location = New System.Drawing.Point(112, 35)
        Me.LblPvp_Base_General.Margin = New System.Windows.Forms.Padding(0)
        Me.LblPvp_Base_General.Name = "LblPvp_Base_General"
        Me.LblPvp_Base_General.Size = New System.Drawing.Size(78, 20)
        Me.LblPvp_Base_General.TabIndex = 39
        Me.LblPvp_Base_General.Tag = "pvp_base_general"
        Me.LblPvp_Base_General.Text = "0,00"
        Me.LblPvp_Base_General.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label13
        '
        Label13.BackColor = System.Drawing.Color.LightSteelBlue
        Label13.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Label13.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Label13.Location = New System.Drawing.Point(112, 16)
        Label13.Margin = New System.Windows.Forms.Padding(0)
        Label13.Name = "Label13"
        Label13.Size = New System.Drawing.Size(78, 19)
        Label13.TabIndex = 38
        Label13.Text = "BaseImponible"
        Label13.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'LblPvp_Total_General
        '
        Me.LblPvp_Total_General.BackColor = System.Drawing.Color.LightBlue
        Me.LblPvp_Total_General.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.LblPvp_Total_General.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblPvp_Total_General.Location = New System.Drawing.Point(365, 35)
        Me.LblPvp_Total_General.Margin = New System.Windows.Forms.Padding(0)
        Me.LblPvp_Total_General.Name = "LblPvp_Total_General"
        Me.LblPvp_Total_General.Size = New System.Drawing.Size(90, 20)
        Me.LblPvp_Total_General.TabIndex = 36
        Me.LblPvp_Total_General.Tag = "pvp_total_general"
        Me.LblPvp_Total_General.Text = "0,00"
        Me.LblPvp_Total_General.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label10
        '
        Label10.BackColor = System.Drawing.Color.LightSteelBlue
        Label10.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Label10.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Label10.Location = New System.Drawing.Point(365, 16)
        Label10.Margin = New System.Windows.Forms.Padding(0)
        Label10.Name = "Label10"
        Label10.Size = New System.Drawing.Size(90, 19)
        Label10.TabIndex = 35
        Label10.Text = "TOTAL"
        Label10.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Label8
        '
        Label8.BackColor = System.Drawing.Color.LightSteelBlue
        Label8.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Label8.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Label8.Location = New System.Drawing.Point(190, 16)
        Label8.Margin = New System.Windows.Forms.Padding(0)
        Label8.Name = "Label8"
        Label8.Size = New System.Drawing.Size(67, 19)
        Label8.TabIndex = 33
        Label8.Text = "Tipo de IVA"
        Label8.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'LblPvp_Iva_General
        '
        Me.LblPvp_Iva_General.BackColor = System.Drawing.Color.Lavender
        Me.LblPvp_Iva_General.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.LblPvp_Iva_General.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblPvp_Iva_General.Location = New System.Drawing.Point(298, 35)
        Me.LblPvp_Iva_General.Margin = New System.Windows.Forms.Padding(0)
        Me.LblPvp_Iva_General.Name = "LblPvp_Iva_General"
        Me.LblPvp_Iva_General.Size = New System.Drawing.Size(67, 20)
        Me.LblPvp_Iva_General.TabIndex = 32
        Me.LblPvp_Iva_General.Tag = "pvp_iva_general"
        Me.LblPvp_Iva_General.Text = "0,00"
        Me.LblPvp_Iva_General.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label6
        '
        Label6.BackColor = System.Drawing.Color.LightSteelBlue
        Label6.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Label6.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Label6.Location = New System.Drawing.Point(298, 16)
        Label6.Margin = New System.Windows.Forms.Padding(0)
        Label6.Name = "Label6"
        Label6.Size = New System.Drawing.Size(67, 19)
        Label6.TabIndex = 31
        Label6.Text = "Importe IVA"
        Label6.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Label3
        '
        Label3.BackColor = System.Drawing.Color.LightSteelBlue
        Label3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Label3.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Label3.Location = New System.Drawing.Point(485, 168)
        Label3.Margin = New System.Windows.Forms.Padding(0)
        Label3.Name = "Label3"
        Label3.Size = New System.Drawing.Size(153, 19)
        Label3.TabIndex = 98
        Label3.Text = "Importe TOTAL"
        Label3.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'ToolStrip
        '
        ToolStrip.Dock = System.Windows.Forms.DockStyle.Bottom
        ToolStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        ToolStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.LblTitle})
        ToolStrip.Location = New System.Drawing.Point(0, 66)
        ToolStrip.Name = "ToolStrip"
        ToolStrip.Size = New System.Drawing.Size(647, 25)
        ToolStrip.TabIndex = 40
        '
        'LblTitle
        '
        Me.LblTitle.AutoSize = False
        Me.LblTitle.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblTitle.Name = "LblTitle"
        Me.LblTitle.Size = New System.Drawing.Size(280, 22)
        Me.LblTitle.Text = "FACTURACIÓN"
        Me.LblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'LblSubName
        '
        LblSubName.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        LblSubName.Location = New System.Drawing.Point(74, 31)
        LblSubName.Name = "LblSubName"
        LblSubName.Size = New System.Drawing.Size(508, 27)
        LblSubName.TabIndex = 6
        LblSubName.Text = "Facturación de los Albaranes de compra de los proveedores"
        '
        'BtOk
        '
        Me.BtOk.Image = CType(resources.GetObject("BtOk.Image"), System.Drawing.Image)
        Me.BtOk.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtOk.Location = New System.Drawing.Point(484, 24)
        Me.BtOk.Name = "BtOk"
        Me.BtOk.Size = New System.Drawing.Size(154, 51)
        Me.BtOk.TabIndex = 1
        Me.BtOk.Text = "Facturar"
        Me.BtOk.UseVisualStyleBackColor = True
        '
        'BtCancell
        '
        Me.BtCancell.Image = CType(resources.GetObject("BtCancell.Image"), System.Drawing.Image)
        Me.BtCancell.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtCancell.Location = New System.Drawing.Point(484, 81)
        Me.BtCancell.Name = "BtCancell"
        Me.BtCancell.Size = New System.Drawing.Size(154, 43)
        Me.BtCancell.TabIndex = 2
        Me.BtCancell.Text = "Cancelar"
        Me.BtCancell.UseVisualStyleBackColor = True
        '
        'Group_Albaranes
        '
        Me.Group_Albaranes.Controls.Add(Me.LstAlbaranes)
        Me.Group_Albaranes.Location = New System.Drawing.Point(9, 5)
        Me.Group_Albaranes.Name = "Group_Albaranes"
        Me.Group_Albaranes.Size = New System.Drawing.Size(469, 212)
        Me.Group_Albaranes.TabIndex = 3
        Me.Group_Albaranes.TabStop = False
        Me.Group_Albaranes.Text = "Albaranes Pendientes de Facturar"
        '
        'LstAlbaranes
        '
        Me.LstAlbaranes.BackColor = System.Drawing.Color.FromArgb(CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer))
        Me.LstAlbaranes.CheckBoxes = True
        Me.LstAlbaranes.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.Col_id, Me.Col_Fh, Me.Col_Albaran, Me.Col_Base_General, Me.Col_Base_Medio, Me.Col_Base_Basico, Me.Col_Iva_General, Me.Col_Iva_Medio, Me.Col_Iva_Basico, Me.Col_Total})
        Me.LstAlbaranes.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LstAlbaranes.FullRowSelect = True
        Me.LstAlbaranes.HideSelection = False
        Me.LstAlbaranes.Location = New System.Drawing.Point(9, 19)
        Me.LstAlbaranes.Name = "LstAlbaranes"
        Me.LstAlbaranes.Size = New System.Drawing.Size(454, 186)
        Me.LstAlbaranes.TabIndex = 4
        Me.LstAlbaranes.UseCompatibleStateImageBehavior = False
        Me.LstAlbaranes.View = System.Windows.Forms.View.Details
        '
        'Col_id
        '
        Me.Col_id.Text = "Ref."
        Me.Col_id.Width = 80
        '
        'Col_Fh
        '
        Me.Col_Fh.Text = "Fecha"
        Me.Col_Fh.Width = 120
        '
        'Col_Albaran
        '
        Me.Col_Albaran.Text = "Albarán"
        Me.Col_Albaran.Width = 120
        '
        'Col_Base_General
        '
        Me.Col_Base_General.Text = "Base General"
        Me.Col_Base_General.Width = 0
        '
        'Col_Base_Medio
        '
        Me.Col_Base_Medio.Text = "Base Medio"
        Me.Col_Base_Medio.Width = 0
        '
        'Col_Base_Basico
        '
        Me.Col_Base_Basico.Text = "Base Basico"
        Me.Col_Base_Basico.Width = 0
        '
        'Col_Iva_General
        '
        Me.Col_Iva_General.Text = "IVA general"
        Me.Col_Iva_General.Width = 0
        '
        'Col_Iva_Medio
        '
        Me.Col_Iva_Medio.Text = "IVA Medio"
        Me.Col_Iva_Medio.Width = 0
        '
        'Col_Iva_Basico
        '
        Me.Col_Iva_Basico.Text = "IVA Basico"
        Me.Col_Iva_Basico.Width = 0
        '
        'Col_Total
        '
        Me.Col_Total.Text = "Total"
        Me.Col_Total.Width = 90
        '
        'LblPvp_Total
        '
        Me.LblPvp_Total.BackColor = System.Drawing.Color.Lavender
        Me.LblPvp_Total.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.LblPvp_Total.Font = New System.Drawing.Font("Verdana", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblPvp_Total.Location = New System.Drawing.Point(485, 187)
        Me.LblPvp_Total.Margin = New System.Windows.Forms.Padding(0)
        Me.LblPvp_Total.Name = "LblPvp_Total"
        Me.LblPvp_Total.Size = New System.Drawing.Size(153, 30)
        Me.LblPvp_Total.TabIndex = 71
        Me.LblPvp_Total.Tag = "pvp_total"
        Me.LblPvp_Total.Text = "0,00"
        Me.LblPvp_Total.TextAlign = System.Drawing.ContentAlignment.TopCenter
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
        Me.SplitContainer.Panel1.Controls.Add(ToolStrip)
        Me.SplitContainer.Panel1.Controls.Add(Me.LblId)
        Me.SplitContainer.Panel1.Controls.Add(Me.PicImg)
        Me.SplitContainer.Panel1.Controls.Add(Me.LblName)
        Me.SplitContainer.Panel1.Controls.Add(LblSubName)
        '
        'SplitContainer.Panel2
        '
        Me.SplitContainer.Panel2.Controls.Add(Me.Group_Albaranes)
        Me.SplitContainer.Panel2.Controls.Add(GroupPVPs)
        Me.SplitContainer.Panel2.Controls.Add(Label3)
        Me.SplitContainer.Panel2.Controls.Add(GroupFacturar)
        Me.SplitContainer.Panel2.Controls.Add(Me.LblPvp_Total)
        Me.SplitContainer.Panel2.Controls.Add(Me.BtOk)
        Me.SplitContainer.Panel2.Controls.Add(Me.BtCancell)
        Me.SplitContainer.Size = New System.Drawing.Size(647, 647)
        Me.SplitContainer.SplitterDistance = 91
        Me.SplitContainer.SplitterWidth = 1
        Me.SplitContainer.TabIndex = 99
        '
        'LblId
        '
        Me.LblId.Font = New System.Drawing.Font("Tahoma", 6.0!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblId.Location = New System.Drawing.Point(406, 9)
        Me.LblId.Name = "LblId"
        Me.LblId.Size = New System.Drawing.Size(76, 12)
        Me.LblId.TabIndex = 39
        Me.LblId.Tag = "id"
        Me.LblId.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'PicImg
        '
        Me.PicImg.Image = CType(resources.GetObject("PicImg.Image"), System.Drawing.Image)
        Me.PicImg.Location = New System.Drawing.Point(5, 5)
        Me.PicImg.Name = "PicImg"
        Me.PicImg.Size = New System.Drawing.Size(48, 48)
        Me.PicImg.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.PicImg.TabIndex = 38
        Me.PicImg.TabStop = False
        '
        'LblName
        '
        Me.LblName.AutoSize = True
        Me.LblName.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblName.Location = New System.Drawing.Point(64, 9)
        Me.LblName.Name = "LblName"
        Me.LblName.Size = New System.Drawing.Size(293, 19)
        Me.LblName.TabIndex = 7
        Me.LblName.Text = "Generación de Facturas de Compra"
        '
        'frmFacturar_Compras
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Window
        Me.ClientSize = New System.Drawing.Size(647, 647)
        Me.Controls.Add(Me.SplitContainer)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmFacturar_Compras"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Facturar Albaranes"
        GroupFacturar.ResumeLayout(False)
        GroupFacturar.PerformLayout()
        GroupPVPs.ResumeLayout(False)
        ToolStrip.ResumeLayout(False)
        ToolStrip.PerformLayout()
        Me.Group_Albaranes.ResumeLayout(False)
        Me.SplitContainer.Panel1.ResumeLayout(False)
        Me.SplitContainer.Panel1.PerformLayout()
        Me.SplitContainer.Panel2.ResumeLayout(False)
        Me.SplitContainer.ResumeLayout(False)
        CType(Me.PicImg, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents BtOk As System.Windows.Forms.Button
    Friend WithEvents BtCancell As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents TxtObs As System.Windows.Forms.TextBox
    Friend WithEvents DtFactura As System.Windows.Forms.DateTimePicker
    Friend WithEvents Group_Albaranes As System.Windows.Forms.GroupBox
    Friend WithEvents LstAlbaranes As System.Windows.Forms.ListView
    Friend WithEvents Col_id As System.Windows.Forms.ColumnHeader
    Friend WithEvents Col_Fh As System.Windows.Forms.ColumnHeader
    Friend WithEvents Col_Base_General As System.Windows.Forms.ColumnHeader
    Friend WithEvents Col_Base_Medio As System.Windows.Forms.ColumnHeader
    Friend WithEvents LblPvp_Total As System.Windows.Forms.Label
    Friend WithEvents LblNfoIVA_Basico As System.Windows.Forms.Label
    Friend WithEvents LblPvp_Base_Basico As System.Windows.Forms.Label
    Friend WithEvents LblPvp_Total_Basico As System.Windows.Forms.Label
    Friend WithEvents LblPvp_Iva_Basico As System.Windows.Forms.Label
    Friend WithEvents LblNfoIVA_Medio As System.Windows.Forms.Label
    Friend WithEvents LblPvp_Base_Medio As System.Windows.Forms.Label
    Friend WithEvents LblPvp_Total_Medio As System.Windows.Forms.Label
    Friend WithEvents LblPvp_Iva_Medio As System.Windows.Forms.Label
    Friend WithEvents LblNfoIVA_General As System.Windows.Forms.Label
    Friend WithEvents LblPvp_Base_General As System.Windows.Forms.Label
    Friend WithEvents LblPvp_Total_General As System.Windows.Forms.Label
    Friend WithEvents LblPvp_Iva_General As System.Windows.Forms.Label
    Friend WithEvents Col_Base_Basico As System.Windows.Forms.ColumnHeader
    Friend WithEvents Col_Iva_General As System.Windows.Forms.ColumnHeader
    Friend WithEvents Col_Iva_Medio As System.Windows.Forms.ColumnHeader
    Friend WithEvents Col_Iva_Basico As System.Windows.Forms.ColumnHeader
    Friend WithEvents LblIVA_Basico As System.Windows.Forms.Label
    Friend WithEvents LblIVA_Medio As System.Windows.Forms.Label
    Friend WithEvents LblIVA_General As System.Windows.Forms.Label
    Friend WithEvents SplitContainer As System.Windows.Forms.SplitContainer
    Friend WithEvents LblTitle As System.Windows.Forms.ToolStripLabel
    Friend WithEvents LblId As System.Windows.Forms.Label
    Friend WithEvents PicImg As System.Windows.Forms.PictureBox
    Friend WithEvents LblName As System.Windows.Forms.Label
    Friend WithEvents TxtFactura As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Col_Albaran As System.Windows.Forms.ColumnHeader
    Friend WithEvents Col_Total As System.Windows.Forms.ColumnHeader
End Class
