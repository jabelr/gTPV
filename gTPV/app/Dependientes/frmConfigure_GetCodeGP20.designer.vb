<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmConfigure_GetCodeGP20
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmConfigure_GetCodeGP20))
        Me.LblWait = New System.Windows.Forms.Label
        Me.BtCancell = New System.Windows.Forms.Button
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
        'BtCancell
        '
        Me.BtCancell.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtCancell.Image = CType(resources.GetObject("BtCancell.Image"), System.Drawing.Image)
        Me.BtCancell.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtCancell.Location = New System.Drawing.Point(362, 12)
        Me.BtCancell.Name = "BtCancell"
        Me.BtCancell.Size = New System.Drawing.Size(137, 46)
        Me.BtCancell.TabIndex = 1
        Me.BtCancell.Text = "Cancelar"
        Me.BtCancell.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BtCancell.UseVisualStyleBackColor = True
        '
        'Timer
        '
        Me.Timer.Interval = 600
        '
        'frmConfigure_GetCodeGP20
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(502, 67)
        Me.Controls.Add(Me.BtCancell)
        Me.Controls.Add(Me.LblWait)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmConfigure_GetCodeGP20"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Pase la tarjeta/llavero por el lector de proximidad ahora"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents LblWait As System.Windows.Forms.Label
    Friend WithEvents BtCancell As System.Windows.Forms.Button
    Friend WithEvents Timer As System.Windows.Forms.Timer
End Class
