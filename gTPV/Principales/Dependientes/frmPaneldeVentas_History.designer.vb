<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmPaneldeVentas_History
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmPaneldeVentas_History))
        Me.LblName = New System.Windows.Forms.Label
        Me.PnlGaleria = New System.Windows.Forms.Panel
        Me.LstLines = New System.Windows.Forms.ListView
        Me.PnlGaleria.SuspendLayout()
        Me.SuspendLayout()
        '
        'LblName
        '
        Me.LblName.BackColor = System.Drawing.Color.Transparent
        Me.LblName.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblName.Location = New System.Drawing.Point(37, 36)
        Me.LblName.Name = "LblName"
        Me.LblName.Size = New System.Drawing.Size(451, 23)
        Me.LblName.TabIndex = 34
        Me.LblName.Text = "Historial del Ticket"
        Me.LblName.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'PnlGaleria
        '
        Me.PnlGaleria.BackColor = System.Drawing.Color.FromArgb(CType(CType(174, Byte), Integer), CType(CType(186, Byte), Integer), CType(CType(186, Byte), Integer))
        Me.PnlGaleria.Controls.Add(Me.LstLines)
        Me.PnlGaleria.Location = New System.Drawing.Point(41, 75)
        Me.PnlGaleria.Name = "PnlGaleria"
        Me.PnlGaleria.Size = New System.Drawing.Size(447, 367)
        Me.PnlGaleria.TabIndex = 0
        '
        'LstLines
        '
        Me.LstLines.BackColor = System.Drawing.Color.LightSteelBlue
        Me.LstLines.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LstLines.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LstLines.FullRowSelect = True
        Me.LstLines.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable
        Me.LstLines.HideSelection = False
        Me.LstLines.Location = New System.Drawing.Point(0, 0)
        Me.LstLines.MultiSelect = False
        Me.LstLines.Name = "LstLines"
        Me.LstLines.Size = New System.Drawing.Size(447, 367)
        Me.LstLines.TabIndex = 26
        Me.LstLines.UseCompatibleStateImageBehavior = False
        Me.LstLines.View = System.Windows.Forms.View.Details
        '
        'frmPaneldeVentas_History
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), System.Drawing.Image)
        Me.ClientSize = New System.Drawing.Size(529, 478)
        Me.Controls.Add(Me.PnlGaleria)
        Me.Controls.Add(Me.LblName)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmPaneldeVentas_History"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Historial de Artículos"
        Me.PnlGaleria.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents LblName As System.Windows.Forms.Label
    Friend WithEvents PnlGaleria As System.Windows.Forms.Panel
    Friend WithEvents LstLines As System.Windows.Forms.ListView
End Class
