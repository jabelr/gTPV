<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmGetCodBarras
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
        Me.components = New System.ComponentModel.Container
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmGetCodBarras))
        Me.LblWait = New System.Windows.Forms.Label
        Me.Timer = New System.Windows.Forms.Timer(Me.components)
        Me.SuspendLayout()
        '
        'LblWait
        '
        Me.LblWait.AutoSize = True
        Me.LblWait.Font = New System.Drawing.Font("Verdana", 20.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblWait.Location = New System.Drawing.Point(12, 19)
        Me.LblWait.Name = "LblWait"
        Me.LblWait.Size = New System.Drawing.Size(334, 32)
        Me.LblWait.TabIndex = 0
        Me.LblWait.Text = "ESPERANDO CÓDIGO"
        '
        'Timer
        '
        Me.Timer.Interval = 600
        '
        'frmGetCodBarras
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Window
        Me.ClientSize = New System.Drawing.Size(381, 67)
        Me.Controls.Add(Me.LblWait)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmGetCodBarras"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Pase el lector sobre el código de barras"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents LblWait As System.Windows.Forms.Label
    Friend WithEvents Timer As System.Windows.Forms.Timer
End Class
