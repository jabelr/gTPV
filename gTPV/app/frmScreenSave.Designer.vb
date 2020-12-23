<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmScreenSave
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmScreenSave))
        Me.pnlBody = New System.Windows.Forms.Panel()
        Me.LblTotal = New System.Windows.Forms.Label()
        Me.picLogo = New System.Windows.Forms.PictureBox()
        Me.lblName = New System.Windows.Forms.Label()
        Me.lblNameFiscal = New System.Windows.Forms.Label()
        Me.pnlBody.SuspendLayout()
        CType(Me.picLogo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'pnlBody
        '
        Me.pnlBody.BackColor = System.Drawing.Color.White
        Me.pnlBody.Controls.Add(Me.lblNameFiscal)
        Me.pnlBody.Controls.Add(Me.lblName)
        Me.pnlBody.Controls.Add(Me.LblTotal)
        Me.pnlBody.Controls.Add(Me.picLogo)
        Me.pnlBody.Location = New System.Drawing.Point(72, 57)
        Me.pnlBody.Name = "pnlBody"
        Me.pnlBody.Size = New System.Drawing.Size(573, 192)
        Me.pnlBody.TabIndex = 0
        '
        'LblTotal
        '
        Me.LblTotal.BackColor = System.Drawing.Color.FromArgb(CType(CType(101, Byte), Integer), CType(CType(137, Byte), Integer), CType(CType(213, Byte), Integer))
        Me.LblTotal.Font = New System.Drawing.Font("Tahoma", 36.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblTotal.Location = New System.Drawing.Point(194, 114)
        Me.LblTotal.Name = "LblTotal"
        Me.LblTotal.Size = New System.Drawing.Size(363, 63)
        Me.LblTotal.TabIndex = 17
        Me.LblTotal.Text = "0,00 €"
        Me.LblTotal.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'picLogo
        '
        Me.picLogo.Image = CType(resources.GetObject("picLogo.Image"), System.Drawing.Image)
        Me.picLogo.Location = New System.Drawing.Point(24, 123)
        Me.picLogo.Name = "picLogo"
        Me.picLogo.Size = New System.Drawing.Size(149, 41)
        Me.picLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.picLogo.TabIndex = 0
        Me.picLogo.TabStop = False
        '
        'lblName
        '
        Me.lblName.Font = New System.Drawing.Font("Tahoma", 24.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblName.Location = New System.Drawing.Point(17, 10)
        Me.lblName.Name = "lblName"
        Me.lblName.Size = New System.Drawing.Size(553, 49)
        Me.lblName.TabIndex = 18
        Me.lblName.Text = "Label1"
        '
        'lblNameFiscal
        '
        Me.lblNameFiscal.Font = New System.Drawing.Font("Tahoma", 18.0!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNameFiscal.Location = New System.Drawing.Point(33, 59)
        Me.lblNameFiscal.Name = "lblNameFiscal"
        Me.lblNameFiscal.Size = New System.Drawing.Size(537, 32)
        Me.lblNameFiscal.TabIndex = 19
        Me.lblNameFiscal.Text = "Label1"
        '
        'frmScreenSave
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Black
        Me.ClientSize = New System.Drawing.Size(805, 514)
        Me.Controls.Add(Me.pnlBody)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.KeyPreview = True
        Me.Name = "frmScreenSave"
        Me.Text = "frmScreenSave"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.pnlBody.ResumeLayout(False)
        CType(Me.picLogo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents pnlBody As System.Windows.Forms.Panel
    Friend WithEvents picLogo As System.Windows.Forms.PictureBox
    Friend WithEvents LblTotal As System.Windows.Forms.Label
    Friend WithEvents lblName As System.Windows.Forms.Label
    Friend WithEvents lblNameFiscal As System.Windows.Forms.Label
End Class
