<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmProveedores_Facturas
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
        Dim Label2 As System.Windows.Forms.Label
        Dim Label1 As System.Windows.Forms.Label
        Dim Label3 As System.Windows.Forms.Label
        Dim Label4 As System.Windows.Forms.Label
        Dim Label5 As System.Windows.Forms.Label
        Dim Label6 As System.Windows.Forms.Label
        Dim Label8 As System.Windows.Forms.Label
        Dim Label12 As System.Windows.Forms.Label
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmProveedores_Facturas))
        Me.LblFh_Alta = New System.Windows.Forms.Label
        Me.LblFh_Alta_nfo = New System.Windows.Forms.Label
        Me.PnlAction_Buttons = New System.Windows.Forms.Panel
        Me.BtCancell = New System.Windows.Forms.Button
        Me.BtOk = New System.Windows.Forms.Button
        Me.TxtFactura = New System.Windows.Forms.TextBox
        Me.DtFh_Compra = New System.Windows.Forms.DateTimePicker
        Me.DtFh_Factura = New System.Windows.Forms.DateTimePicker
        Me.TxtBase_7 = New System.Windows.Forms.TextBox
        Me.TxtBase_16 = New System.Windows.Forms.TextBox
        Me.LblIVA_7 = New System.Windows.Forms.Label
        Me.LblIVA_16 = New System.Windows.Forms.Label
        Me.LblTotal_7 = New System.Windows.Forms.Label
        Me.LblTotal_16 = New System.Windows.Forms.Label
        Me.LblTotal = New System.Windows.Forms.Label
        Me.TxtId_Contable = New System.Windows.Forms.TextBox
        Me.TxtId_Proveedor = New System.Windows.Forms.TextBox
        Me.TxtIVA_7 = New System.Windows.Forms.TextBox
        Me.TxtIVA_16 = New System.Windows.Forms.TextBox
        Me.TxtImporte_7 = New System.Windows.Forms.TextBox
        Me.TxtImporte_16 = New System.Windows.Forms.TextBox
        Me.TxtTotal = New System.Windows.Forms.TextBox
        Label2 = New System.Windows.Forms.Label
        Label1 = New System.Windows.Forms.Label
        Label3 = New System.Windows.Forms.Label
        Label4 = New System.Windows.Forms.Label
        Label5 = New System.Windows.Forms.Label
        Label6 = New System.Windows.Forms.Label
        Label8 = New System.Windows.Forms.Label
        Label12 = New System.Windows.Forms.Label
        Me.PnlAction_Buttons.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label2
        '
        Label2.AutoSize = True
        Label2.BackColor = System.Drawing.Color.Transparent
        Label2.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Label2.Location = New System.Drawing.Point(46, 174)
        Label2.Name = "Label2"
        Label2.Size = New System.Drawing.Size(124, 18)
        Label2.TabIndex = 16
        Label2.Text = "Fecha de Compra"
        '
        'Label1
        '
        Label1.AutoSize = True
        Label1.BackColor = System.Drawing.Color.Transparent
        Label1.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Label1.Location = New System.Drawing.Point(46, 88)
        Label1.Name = "Label1"
        Label1.Size = New System.Drawing.Size(111, 18)
        Label1.TabIndex = 18
        Label1.Text = "Nº de Factura"
        '
        'Label3
        '
        Label3.AutoSize = True
        Label3.BackColor = System.Drawing.Color.Transparent
        Label3.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Label3.Location = New System.Drawing.Point(46, 127)
        Label3.Name = "Label3"
        Label3.Size = New System.Drawing.Size(122, 18)
        Label3.TabIndex = 20
        Label3.Text = "Fecha de Factura"
        '
        'Label4
        '
        Label4.AutoSize = True
        Label4.BackColor = System.Drawing.Color.Transparent
        Label4.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Label4.Location = New System.Drawing.Point(45, 250)
        Label4.Name = "Label4"
        Label4.Size = New System.Drawing.Size(60, 18)
        Label4.TabIndex = 21
        Label4.Text = "IVA 7%"
        '
        'Label5
        '
        Label5.AutoSize = True
        Label5.BackColor = System.Drawing.Color.Transparent
        Label5.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Label5.Location = New System.Drawing.Point(46, 289)
        Label5.Name = "Label5"
        Label5.Size = New System.Drawing.Size(68, 18)
        Label5.TabIndex = 22
        Label5.Text = "IVA 16%"
        '
        'Label6
        '
        Label6.BackColor = System.Drawing.Color.Transparent
        Label6.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Label6.Location = New System.Drawing.Point(182, 220)
        Label6.Name = "Label6"
        Label6.Size = New System.Drawing.Size(122, 18)
        Label6.TabIndex = 25
        Label6.Text = "Base Imponible"
        Label6.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Label8
        '
        Label8.BackColor = System.Drawing.Color.Transparent
        Label8.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Label8.Location = New System.Drawing.Point(310, 220)
        Label8.Name = "Label8"
        Label8.Size = New System.Drawing.Size(111, 18)
        Label8.TabIndex = 27
        Label8.Text = "I.V.A."
        Label8.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Label12
        '
        Label12.BackColor = System.Drawing.Color.Transparent
        Label12.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Label12.Location = New System.Drawing.Point(427, 220)
        Label12.Name = "Label12"
        Label12.Size = New System.Drawing.Size(111, 18)
        Label12.TabIndex = 31
        Label12.Text = "TOTAL"
        Label12.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'LblFh_Alta
        '
        Me.LblFh_Alta.BackColor = System.Drawing.Color.Transparent
        Me.LblFh_Alta.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblFh_Alta.Location = New System.Drawing.Point(139, 405)
        Me.LblFh_Alta.Name = "LblFh_Alta"
        Me.LblFh_Alta.Size = New System.Drawing.Size(179, 13)
        Me.LblFh_Alta.TabIndex = 6
        Me.LblFh_Alta.Tag = "fh_alta"
        Me.LblFh_Alta.Text = "00/00/0000"
        '
        'LblFh_Alta_nfo
        '
        Me.LblFh_Alta_nfo.AutoSize = True
        Me.LblFh_Alta_nfo.BackColor = System.Drawing.Color.Transparent
        Me.LblFh_Alta_nfo.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblFh_Alta_nfo.Location = New System.Drawing.Point(47, 405)
        Me.LblFh_Alta_nfo.Name = "LblFh_Alta_nfo"
        Me.LblFh_Alta_nfo.Size = New System.Drawing.Size(88, 13)
        Me.LblFh_Alta_nfo.TabIndex = 5
        Me.LblFh_Alta_nfo.Text = "Fecha de alta:"
        '
        'PnlAction_Buttons
        '
        Me.PnlAction_Buttons.BackColor = System.Drawing.Color.Transparent
        Me.PnlAction_Buttons.Controls.Add(Me.BtCancell)
        Me.PnlAction_Buttons.Controls.Add(Me.BtOk)
        Me.PnlAction_Buttons.Location = New System.Drawing.Point(449, 35)
        Me.PnlAction_Buttons.Name = "PnlAction_Buttons"
        Me.PnlAction_Buttons.Size = New System.Drawing.Size(146, 70)
        Me.PnlAction_Buttons.TabIndex = 7
        Me.PnlAction_Buttons.Tag = "NO_SCAN"
        '
        'BtCancell
        '
        Me.BtCancell.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.BtCancell.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtCancell.Image = CType(resources.GetObject("BtCancell.Image"), System.Drawing.Image)
        Me.BtCancell.Location = New System.Drawing.Point(3, 3)
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
        Me.BtOk.Location = New System.Drawing.Point(76, 3)
        Me.BtOk.Name = "BtOk"
        Me.BtOk.Size = New System.Drawing.Size(67, 63)
        Me.BtOk.TabIndex = 1
        Me.BtOk.Tag = "ok"
        Me.BtOk.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.BtOk.UseVisualStyleBackColor = True
        '
        'TxtFactura
        '
        Me.TxtFactura.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtFactura.Font = New System.Drawing.Font("Tahoma", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtFactura.Location = New System.Drawing.Point(185, 79)
        Me.TxtFactura.MaxLength = 25
        Me.TxtFactura.Name = "TxtFactura"
        Me.TxtFactura.Size = New System.Drawing.Size(204, 33)
        Me.TxtFactura.TabIndex = 0
        Me.TxtFactura.Tag = "factura"
        '
        'DtFh_Compra
        '
        Me.DtFh_Compra.Font = New System.Drawing.Font("Tahoma", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DtFh_Compra.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DtFh_Compra.Location = New System.Drawing.Point(185, 164)
        Me.DtFh_Compra.Name = "DtFh_Compra"
        Me.DtFh_Compra.Size = New System.Drawing.Size(282, 33)
        Me.DtFh_Compra.TabIndex = 2
        Me.DtFh_Compra.Tag = "fh_compra"
        '
        'DtFh_Factura
        '
        Me.DtFh_Factura.Font = New System.Drawing.Font("Tahoma", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DtFh_Factura.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DtFh_Factura.Location = New System.Drawing.Point(185, 118)
        Me.DtFh_Factura.Name = "DtFh_Factura"
        Me.DtFh_Factura.Size = New System.Drawing.Size(282, 33)
        Me.DtFh_Factura.TabIndex = 1
        Me.DtFh_Factura.Tag = "fh_factura"
        '
        'TxtBase_7
        '
        Me.TxtBase_7.Font = New System.Drawing.Font("Tahoma", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtBase_7.Location = New System.Drawing.Point(185, 241)
        Me.TxtBase_7.MaxLength = 25
        Me.TxtBase_7.Name = "TxtBase_7"
        Me.TxtBase_7.Size = New System.Drawing.Size(119, 33)
        Me.TxtBase_7.TabIndex = 3
        Me.TxtBase_7.Tag = "base_7"
        Me.TxtBase_7.Text = "0.00"
        '
        'TxtBase_16
        '
        Me.TxtBase_16.Font = New System.Drawing.Font("Tahoma", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtBase_16.Location = New System.Drawing.Point(185, 280)
        Me.TxtBase_16.MaxLength = 25
        Me.TxtBase_16.Name = "TxtBase_16"
        Me.TxtBase_16.Size = New System.Drawing.Size(119, 33)
        Me.TxtBase_16.TabIndex = 4
        Me.TxtBase_16.Tag = "base_16"
        Me.TxtBase_16.Text = "0.00"
        '
        'LblIVA_7
        '
        Me.LblIVA_7.BackColor = System.Drawing.Color.Silver
        Me.LblIVA_7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LblIVA_7.Font = New System.Drawing.Font("Tahoma", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblIVA_7.Location = New System.Drawing.Point(310, 241)
        Me.LblIVA_7.Name = "LblIVA_7"
        Me.LblIVA_7.Size = New System.Drawing.Size(111, 33)
        Me.LblIVA_7.TabIndex = 26
        Me.LblIVA_7.Tag = "iva_7"
        Me.LblIVA_7.Text = "0.00"
        Me.LblIVA_7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'LblIVA_16
        '
        Me.LblIVA_16.BackColor = System.Drawing.Color.Silver
        Me.LblIVA_16.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LblIVA_16.Font = New System.Drawing.Font("Tahoma", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblIVA_16.Location = New System.Drawing.Point(310, 280)
        Me.LblIVA_16.Name = "LblIVA_16"
        Me.LblIVA_16.Size = New System.Drawing.Size(111, 33)
        Me.LblIVA_16.TabIndex = 28
        Me.LblIVA_16.Tag = "iva_16"
        Me.LblIVA_16.Text = "0.00"
        Me.LblIVA_16.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'LblTotal_7
        '
        Me.LblTotal_7.BackColor = System.Drawing.Color.Silver
        Me.LblTotal_7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LblTotal_7.Font = New System.Drawing.Font("Tahoma", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblTotal_7.Location = New System.Drawing.Point(427, 241)
        Me.LblTotal_7.Name = "LblTotal_7"
        Me.LblTotal_7.Size = New System.Drawing.Size(111, 33)
        Me.LblTotal_7.TabIndex = 29
        Me.LblTotal_7.Tag = "importe_7"
        Me.LblTotal_7.Text = "0.00"
        Me.LblTotal_7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'LblTotal_16
        '
        Me.LblTotal_16.BackColor = System.Drawing.Color.Silver
        Me.LblTotal_16.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LblTotal_16.Font = New System.Drawing.Font("Tahoma", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblTotal_16.Location = New System.Drawing.Point(427, 280)
        Me.LblTotal_16.Name = "LblTotal_16"
        Me.LblTotal_16.Size = New System.Drawing.Size(111, 33)
        Me.LblTotal_16.TabIndex = 30
        Me.LblTotal_16.Tag = "importe_16"
        Me.LblTotal_16.Text = "0.00"
        Me.LblTotal_16.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'LblTotal
        '
        Me.LblTotal.BackColor = System.Drawing.Color.DarkGray
        Me.LblTotal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LblTotal.Font = New System.Drawing.Font("Tahoma", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblTotal.Location = New System.Drawing.Point(427, 319)
        Me.LblTotal.Name = "LblTotal"
        Me.LblTotal.Size = New System.Drawing.Size(111, 33)
        Me.LblTotal.TabIndex = 32
        Me.LblTotal.Tag = "total"
        Me.LblTotal.Text = "0.00"
        Me.LblTotal.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'TxtId_Contable
        '
        Me.TxtId_Contable.Font = New System.Drawing.Font("Tahoma", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtId_Contable.Location = New System.Drawing.Point(483, 385)
        Me.TxtId_Contable.MaxLength = 25
        Me.TxtId_Contable.Name = "TxtId_Contable"
        Me.TxtId_Contable.Size = New System.Drawing.Size(112, 33)
        Me.TxtId_Contable.TabIndex = 33
        Me.TxtId_Contable.Tag = "id_contable"
        Me.TxtId_Contable.Text = "id_contable"
        Me.TxtId_Contable.Visible = False
        '
        'TxtId_Proveedor
        '
        Me.TxtId_Proveedor.Font = New System.Drawing.Font("Tahoma", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtId_Proveedor.Location = New System.Drawing.Point(365, 385)
        Me.TxtId_Proveedor.MaxLength = 25
        Me.TxtId_Proveedor.Name = "TxtId_Proveedor"
        Me.TxtId_Proveedor.Size = New System.Drawing.Size(112, 33)
        Me.TxtId_Proveedor.TabIndex = 34
        Me.TxtId_Proveedor.Tag = "id_prov"
        Me.TxtId_Proveedor.Text = "id_prov"
        Me.TxtId_Proveedor.Visible = False
        '
        'TxtIVA_7
        '
        Me.TxtIVA_7.Font = New System.Drawing.Font("Tahoma", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtIVA_7.Location = New System.Drawing.Point(351, 241)
        Me.TxtIVA_7.MaxLength = 25
        Me.TxtIVA_7.Name = "TxtIVA_7"
        Me.TxtIVA_7.Size = New System.Drawing.Size(70, 33)
        Me.TxtIVA_7.TabIndex = 35
        Me.TxtIVA_7.Tag = "iva_7"
        Me.TxtIVA_7.Text = "iva_7"
        Me.TxtIVA_7.Visible = False
        '
        'TxtIVA_16
        '
        Me.TxtIVA_16.Font = New System.Drawing.Font("Tahoma", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtIVA_16.Location = New System.Drawing.Point(351, 280)
        Me.TxtIVA_16.MaxLength = 25
        Me.TxtIVA_16.Name = "TxtIVA_16"
        Me.TxtIVA_16.Size = New System.Drawing.Size(70, 33)
        Me.TxtIVA_16.TabIndex = 36
        Me.TxtIVA_16.Tag = "iva_16"
        Me.TxtIVA_16.Text = "iva_16"
        Me.TxtIVA_16.Visible = False
        '
        'TxtImporte_7
        '
        Me.TxtImporte_7.Font = New System.Drawing.Font("Tahoma", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtImporte_7.Location = New System.Drawing.Point(468, 241)
        Me.TxtImporte_7.MaxLength = 25
        Me.TxtImporte_7.Name = "TxtImporte_7"
        Me.TxtImporte_7.Size = New System.Drawing.Size(100, 33)
        Me.TxtImporte_7.TabIndex = 37
        Me.TxtImporte_7.Tag = "importe_7"
        Me.TxtImporte_7.Text = "importe_7"
        Me.TxtImporte_7.Visible = False
        '
        'TxtImporte_16
        '
        Me.TxtImporte_16.Font = New System.Drawing.Font("Tahoma", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtImporte_16.Location = New System.Drawing.Point(468, 280)
        Me.TxtImporte_16.MaxLength = 25
        Me.TxtImporte_16.Name = "TxtImporte_16"
        Me.TxtImporte_16.Size = New System.Drawing.Size(100, 33)
        Me.TxtImporte_16.TabIndex = 38
        Me.TxtImporte_16.Tag = "importe_16"
        Me.TxtImporte_16.Text = "importe_16"
        Me.TxtImporte_16.Visible = False
        '
        'TxtTotal
        '
        Me.TxtTotal.Font = New System.Drawing.Font("Tahoma", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtTotal.Location = New System.Drawing.Point(468, 319)
        Me.TxtTotal.MaxLength = 25
        Me.TxtTotal.Name = "TxtTotal"
        Me.TxtTotal.Size = New System.Drawing.Size(100, 33)
        Me.TxtTotal.TabIndex = 39
        Me.TxtTotal.Tag = "total"
        Me.TxtTotal.Text = "total"
        Me.TxtTotal.Visible = False
        '
        'frmProveedores_Facturas
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), System.Drawing.Image)
        Me.ClientSize = New System.Drawing.Size(639, 451)
        Me.Controls.Add(Me.TxtTotal)
        Me.Controls.Add(Me.TxtImporte_16)
        Me.Controls.Add(Me.TxtImporte_7)
        Me.Controls.Add(Me.TxtIVA_16)
        Me.Controls.Add(Me.TxtIVA_7)
        Me.Controls.Add(Me.TxtId_Proveedor)
        Me.Controls.Add(Me.TxtId_Contable)
        Me.Controls.Add(Me.LblTotal)
        Me.Controls.Add(Label12)
        Me.Controls.Add(Me.LblTotal_16)
        Me.Controls.Add(Me.LblTotal_7)
        Me.Controls.Add(Me.LblIVA_16)
        Me.Controls.Add(Label8)
        Me.Controls.Add(Me.LblIVA_7)
        Me.Controls.Add(Label6)
        Me.Controls.Add(Me.TxtBase_16)
        Me.Controls.Add(Me.TxtBase_7)
        Me.Controls.Add(Label5)
        Me.Controls.Add(Label4)
        Me.Controls.Add(Me.DtFh_Factura)
        Me.Controls.Add(Label3)
        Me.Controls.Add(Me.DtFh_Compra)
        Me.Controls.Add(Me.TxtFactura)
        Me.Controls.Add(Label1)
        Me.Controls.Add(Label2)
        Me.Controls.Add(Me.PnlAction_Buttons)
        Me.Controls.Add(Me.LblFh_Alta)
        Me.Controls.Add(Me.LblFh_Alta_nfo)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmProveedores_Facturas"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Facturas de Compra de..."
        Me.PnlAction_Buttons.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents LblFh_Alta As System.Windows.Forms.Label
    Friend WithEvents LblFh_Alta_nfo As System.Windows.Forms.Label
    Friend WithEvents PnlAction_Buttons As System.Windows.Forms.Panel
    Friend WithEvents BtCancell As System.Windows.Forms.Button
    Friend WithEvents BtOk As System.Windows.Forms.Button
    Friend WithEvents TxtFactura As System.Windows.Forms.TextBox
    Friend WithEvents DtFh_Compra As System.Windows.Forms.DateTimePicker
    Friend WithEvents DtFh_Factura As System.Windows.Forms.DateTimePicker
    Friend WithEvents TxtBase_7 As System.Windows.Forms.TextBox
    Friend WithEvents TxtBase_16 As System.Windows.Forms.TextBox
    Friend WithEvents LblIVA_7 As System.Windows.Forms.Label
    Friend WithEvents LblIVA_16 As System.Windows.Forms.Label
    Friend WithEvents LblTotal_7 As System.Windows.Forms.Label
    Friend WithEvents LblTotal_16 As System.Windows.Forms.Label
    Friend WithEvents LblTotal As System.Windows.Forms.Label
    Friend WithEvents TxtId_Contable As System.Windows.Forms.TextBox
    Friend WithEvents TxtId_Proveedor As System.Windows.Forms.TextBox
    Friend WithEvents TxtIVA_7 As System.Windows.Forms.TextBox
    Friend WithEvents TxtIVA_16 As System.Windows.Forms.TextBox
    Friend WithEvents TxtImporte_7 As System.Windows.Forms.TextBox
    Friend WithEvents TxtImporte_16 As System.Windows.Forms.TextBox
    Friend WithEvents TxtTotal As System.Windows.Forms.TextBox
End Class
