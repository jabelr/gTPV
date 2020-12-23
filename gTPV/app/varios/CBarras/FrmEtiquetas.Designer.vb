<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmEtiquetas
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
        Dim GroupData As System.Windows.Forms.GroupBox
        Dim Label2 As System.Windows.Forms.Label
        Dim Label1 As System.Windows.Forms.Label
        Dim Group_Barras As System.Windows.Forms.GroupBox
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmEtiquetas))
        Me.ChkPrint_Name = New System.Windows.Forms.CheckBox
        Me.CbPrint_N = New System.Windows.Forms.ComboBox
        Me.CbPrint = New System.Windows.Forms.ComboBox
        Me.PicBarCode = New System.Windows.Forms.PictureBox
        Me.BtOk = New System.Windows.Forms.Button
        Me.BtCancell = New System.Windows.Forms.Button
        GroupData = New System.Windows.Forms.GroupBox
        Label2 = New System.Windows.Forms.Label
        Label1 = New System.Windows.Forms.Label
        Group_Barras = New System.Windows.Forms.GroupBox
        GroupData.SuspendLayout()
        Group_Barras.SuspendLayout()
        CType(Me.PicBarCode, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupData
        '
        GroupData.Controls.Add(Me.ChkPrint_Name)
        GroupData.Controls.Add(Me.CbPrint_N)
        GroupData.Controls.Add(Label2)
        GroupData.Controls.Add(Me.CbPrint)
        GroupData.Controls.Add(Label1)
        GroupData.Location = New System.Drawing.Point(12, 122)
        GroupData.Name = "GroupData"
        GroupData.Size = New System.Drawing.Size(366, 107)
        GroupData.TabIndex = 2
        GroupData.TabStop = False
        GroupData.Text = "Opciones de impresión"
        '
        'ChkPrint_Name
        '
        Me.ChkPrint_Name.AutoSize = True
        Me.ChkPrint_Name.Location = New System.Drawing.Point(21, 80)
        Me.ChkPrint_Name.Name = "ChkPrint_Name"
        Me.ChkPrint_Name.Size = New System.Drawing.Size(180, 17)
        Me.ChkPrint_Name.TabIndex = 6
        Me.ChkPrint_Name.Text = "Incluir nombre y precio al imprimir"
        Me.ChkPrint_Name.UseVisualStyleBackColor = True
        '
        'CbPrint_N
        '
        Me.CbPrint_N.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CbPrint_N.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CbPrint_N.FormattingEnabled = True
        Me.CbPrint_N.Items.AddRange(New Object() {"4", "8", "12", "16", "20", "24", "28", "32", "36", "40"})
        Me.CbPrint_N.Location = New System.Drawing.Point(131, 53)
        Me.CbPrint_N.Name = "CbPrint_N"
        Me.CbPrint_N.Size = New System.Drawing.Size(97, 21)
        Me.CbPrint_N.TabIndex = 5
        '
        'Label2
        '
        Label2.AutoSize = True
        Label2.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Label2.Location = New System.Drawing.Point(18, 56)
        Label2.Name = "Label2"
        Label2.Size = New System.Drawing.Size(107, 13)
        Label2.TabIndex = 4
        Label2.Text = "Numero de etiquetas"
        '
        'CbPrint
        '
        Me.CbPrint.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CbPrint.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CbPrint.FormattingEnabled = True
        Me.CbPrint.Location = New System.Drawing.Point(131, 26)
        Me.CbPrint.Name = "CbPrint"
        Me.CbPrint.Size = New System.Drawing.Size(222, 21)
        Me.CbPrint.TabIndex = 3
        '
        'Label1
        '
        Label1.AutoSize = True
        Label1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Label1.Location = New System.Drawing.Point(18, 29)
        Label1.Name = "Label1"
        Label1.Size = New System.Drawing.Size(94, 13)
        Label1.TabIndex = 0
        Label1.Text = "Impresora destino"
        '
        'Group_Barras
        '
        Group_Barras.Controls.Add(Me.PicBarCode)
        Group_Barras.Location = New System.Drawing.Point(12, 10)
        Group_Barras.Name = "Group_Barras"
        Group_Barras.Size = New System.Drawing.Size(228, 106)
        Group_Barras.TabIndex = 5
        Group_Barras.TabStop = False
        Group_Barras.Text = "Código de Barras"
        '
        'PicBarCode
        '
        Me.PicBarCode.BackColor = System.Drawing.Color.White
        Me.PicBarCode.Location = New System.Drawing.Point(12, 19)
        Me.PicBarCode.Name = "PicBarCode"
        Me.PicBarCode.Size = New System.Drawing.Size(205, 74)
        Me.PicBarCode.TabIndex = 6
        Me.PicBarCode.TabStop = False
        '
        'BtOk
        '
        Me.BtOk.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtOk.Image = CType(resources.GetObject("BtOk.Image"), System.Drawing.Image)
        Me.BtOk.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtOk.Location = New System.Drawing.Point(246, 12)
        Me.BtOk.Name = "BtOk"
        Me.BtOk.Size = New System.Drawing.Size(132, 58)
        Me.BtOk.TabIndex = 3
        Me.BtOk.Text = "Imprimir"
        Me.BtOk.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BtOk.UseVisualStyleBackColor = True
        '
        'BtCancell
        '
        Me.BtCancell.Image = CType(resources.GetObject("BtCancell.Image"), System.Drawing.Image)
        Me.BtCancell.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtCancell.Location = New System.Drawing.Point(246, 73)
        Me.BtCancell.Name = "BtCancell"
        Me.BtCancell.Size = New System.Drawing.Size(132, 43)
        Me.BtCancell.TabIndex = 4
        Me.BtCancell.Text = "Cancelar"
        Me.BtCancell.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BtCancell.UseVisualStyleBackColor = True
        '
        'FrmEtiquetas
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(388, 239)
        Me.Controls.Add(Group_Barras)
        Me.Controls.Add(Me.BtCancell)
        Me.Controls.Add(Me.BtOk)
        Me.Controls.Add(GroupData)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmEtiquetas"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Impresión de etiquetas"
        GroupData.ResumeLayout(False)
        GroupData.PerformLayout()
        Group_Barras.ResumeLayout(False)
        CType(Me.PicBarCode, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents CbPrint As System.Windows.Forms.ComboBox
    Friend WithEvents BtOk As System.Windows.Forms.Button
    Friend WithEvents BtCancell As System.Windows.Forms.Button
    Friend WithEvents CbPrint_N As System.Windows.Forms.ComboBox
    Friend WithEvents ChkPrint_Name As System.Windows.Forms.CheckBox
    Friend WithEvents PicBarCode As System.Windows.Forms.PictureBox
End Class
