<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmPaneldeVentas_Invitacion
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmPaneldeVentas_Invitacion))
        Me.PnlAction_Buttons = New System.Windows.Forms.Panel
        Me.BtCancell = New System.Windows.Forms.Button
        Me.LblName = New System.Windows.Forms.Label
        Me.PnlGaleria = New System.Windows.Forms.Panel
        Me.BtInvitacion_Rotura = New System.Windows.Forms.Button
        Me.BtInvitacion_Consumo = New System.Windows.Forms.Button
        Me.BtInvitacion_Normal = New System.Windows.Forms.Button
        Me.BtInvitacion_Socio = New System.Windows.Forms.Button
        Me.PnlAction_Buttons.SuspendLayout()
        Me.PnlGaleria.SuspendLayout()
        Me.SuspendLayout()
        '
        'PnlAction_Buttons
        '
        Me.PnlAction_Buttons.BackColor = System.Drawing.Color.Transparent
        Me.PnlAction_Buttons.Controls.Add(Me.BtCancell)
        Me.PnlAction_Buttons.Location = New System.Drawing.Point(365, 31)
        Me.PnlAction_Buttons.Name = "PnlAction_Buttons"
        Me.PnlAction_Buttons.Size = New System.Drawing.Size(230, 70)
        Me.PnlAction_Buttons.TabIndex = 1
        Me.PnlAction_Buttons.Tag = "NO_SCAN"
        '
        'BtCancell
        '
        Me.BtCancell.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.BtCancell.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.BtCancell.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtCancell.Image = CType(resources.GetObject("BtCancell.Image"), System.Drawing.Image)
        Me.BtCancell.Location = New System.Drawing.Point(157, 4)
        Me.BtCancell.Name = "BtCancell"
        Me.BtCancell.Size = New System.Drawing.Size(67, 63)
        Me.BtCancell.TabIndex = 2
        Me.BtCancell.Tag = "cancell"
        Me.BtCancell.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.BtCancell.UseVisualStyleBackColor = True
        '
        'LblName
        '
        Me.LblName.BackColor = System.Drawing.Color.Transparent
        Me.LblName.Font = New System.Drawing.Font("Verdana", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblName.Location = New System.Drawing.Point(47, 38)
        Me.LblName.Name = "LblName"
        Me.LblName.Size = New System.Drawing.Size(312, 23)
        Me.LblName.TabIndex = 34
        Me.LblName.Text = "Tipo de Invitación"
        '
        'PnlGaleria
        '
        Me.PnlGaleria.BackColor = System.Drawing.Color.FromArgb(CType(CType(174, Byte), Integer), CType(CType(186, Byte), Integer), CType(CType(186, Byte), Integer))
        Me.PnlGaleria.Controls.Add(Me.BtInvitacion_Socio)
        Me.PnlGaleria.Controls.Add(Me.BtInvitacion_Rotura)
        Me.PnlGaleria.Controls.Add(Me.BtInvitacion_Consumo)
        Me.PnlGaleria.Controls.Add(Me.BtInvitacion_Normal)
        Me.PnlGaleria.Location = New System.Drawing.Point(40, 105)
        Me.PnlGaleria.Name = "PnlGaleria"
        Me.PnlGaleria.Size = New System.Drawing.Size(559, 104)
        Me.PnlGaleria.TabIndex = 0
        '
        'BtInvitacion_Rotura
        '
        Me.BtInvitacion_Rotura.BackColor = System.Drawing.SystemColors.Control
        Me.BtInvitacion_Rotura.Font = New System.Drawing.Font("Tahoma", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtInvitacion_Rotura.Location = New System.Drawing.Point(271, 3)
        Me.BtInvitacion_Rotura.Name = "BtInvitacion_Rotura"
        Me.BtInvitacion_Rotura.Size = New System.Drawing.Size(128, 89)
        Me.BtInvitacion_Rotura.TabIndex = 18
        Me.BtInvitacion_Rotura.Tag = ""
        Me.BtInvitacion_Rotura.Text = "Rotura"
        Me.BtInvitacion_Rotura.UseVisualStyleBackColor = False
        '
        'BtInvitacion_Consumo
        '
        Me.BtInvitacion_Consumo.BackColor = System.Drawing.SystemColors.Control
        Me.BtInvitacion_Consumo.Font = New System.Drawing.Font("Tahoma", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtInvitacion_Consumo.Location = New System.Drawing.Point(137, 3)
        Me.BtInvitacion_Consumo.Name = "BtInvitacion_Consumo"
        Me.BtInvitacion_Consumo.Size = New System.Drawing.Size(128, 89)
        Me.BtInvitacion_Consumo.TabIndex = 17
        Me.BtInvitacion_Consumo.Tag = ""
        Me.BtInvitacion_Consumo.Text = "Consumo"
        Me.BtInvitacion_Consumo.UseVisualStyleBackColor = False
        '
        'BtInvitacion_Normal
        '
        Me.BtInvitacion_Normal.BackColor = System.Drawing.SystemColors.Control
        Me.BtInvitacion_Normal.Font = New System.Drawing.Font("Tahoma", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtInvitacion_Normal.Location = New System.Drawing.Point(3, 3)
        Me.BtInvitacion_Normal.Name = "BtInvitacion_Normal"
        Me.BtInvitacion_Normal.Size = New System.Drawing.Size(128, 89)
        Me.BtInvitacion_Normal.TabIndex = 16
        Me.BtInvitacion_Normal.Tag = ""
        Me.BtInvitacion_Normal.Text = "Invitación"
        Me.BtInvitacion_Normal.UseVisualStyleBackColor = False
        '
        'BtInvitacion_Socio
        '
        Me.BtInvitacion_Socio.BackColor = System.Drawing.SystemColors.Control
        Me.BtInvitacion_Socio.Font = New System.Drawing.Font("Tahoma", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtInvitacion_Socio.Location = New System.Drawing.Point(405, 3)
        Me.BtInvitacion_Socio.Name = "BtInvitacion_Socio"
        Me.BtInvitacion_Socio.Size = New System.Drawing.Size(128, 89)
        Me.BtInvitacion_Socio.TabIndex = 19
        Me.BtInvitacion_Socio.Tag = ""
        Me.BtInvitacion_Socio.Text = "Socio"
        Me.BtInvitacion_Socio.UseVisualStyleBackColor = False
        '
        'frmPaneldeVentas_Invitacion
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), System.Drawing.Image)
        Me.ClientSize = New System.Drawing.Size(638, 250)
        Me.Controls.Add(Me.PnlGaleria)
        Me.Controls.Add(Me.LblName)
        Me.Controls.Add(Me.PnlAction_Buttons)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmPaneldeVentas_Invitacion"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Tipo de Invitación"
        Me.PnlAction_Buttons.ResumeLayout(False)
        Me.PnlGaleria.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents PnlAction_Buttons As System.Windows.Forms.Panel
    Friend WithEvents LblName As System.Windows.Forms.Label
    Friend WithEvents PnlGaleria As System.Windows.Forms.Panel
    Friend WithEvents BtCancell As System.Windows.Forms.Button
    Friend WithEvents BtInvitacion_Normal As System.Windows.Forms.Button
    Friend WithEvents BtInvitacion_Rotura As System.Windows.Forms.Button
    Friend WithEvents BtInvitacion_Consumo As System.Windows.Forms.Button
    Friend WithEvents BtInvitacion_Socio As System.Windows.Forms.Button
End Class
