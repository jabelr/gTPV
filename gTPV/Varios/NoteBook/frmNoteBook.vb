Public Class frmNoteBook
    Private WithEvents mfrm_Ventas As frmNoteBook_Ventas
    Private WithEvents mfrm_Reservas As frmNoteBook_Reservas

    ' Color de los botones activado/desactivado
    Private _btcolor As Color = Color.FromKnownColor(KnownColor.ActiveCaption)
    Private _btcolor_alt As Color = Color.FromKnownColor(KnownColor.InactiveCaption)
    Private _btcolor_restore As Color = Color.FromKnownColor(KnownColor.Control)

#Region "Shell"
    Private Sub m_Work(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtVentas.Click, BtReservas.Click, BtEmpresa.Click
        Select Case True
            Case sender Is Me.BtVentas
                If Val(Me.BtVentas.Tag) = 0 Then
                    Me.mfrm_Ventas = New frmNoteBook_Ventas

                    'Si no esta cargado cargo los datos
                    'If Not Me.m_Form_Cat.Load_Config("categorias") Then Exit Sub
                    Me.BtVentas.Tag = 1
                End If


                With Me.mfrm_Ventas
                    'Le asigno los eventos
                    AddHandler .Activated, AddressOf mEvent_ActiveForm
                    AddHandler .Deactivate, AddressOf mEvent_DesactivateForm
                    AddHandler .FormClosed, AddressOf mEvent_CloseForm
                    AddHandler .Load, AddressOf mEvent_LoadForm

                    'Preconfiguro y muestro
                    .MdiParent = Me
                    .Dock = DockStyle.Fill
                    .Show()
                    .Select()
                End With

            Case sender Is Me.BtEmpresa
                Dim frmCfg As New frmConfigure
                frmCfg.ShowDialog(Me)
                frmCfg.Dispose()

                ' Para bien o para mal, recargo valores de configuracion de la aplicacion
                My.LoadAppConfig()
                My.Load_OptionsHardware()
        End Select
    End Sub
#End Region

#Region "Eventos de Formularios Hijos"
    'Funcion que me controla cuando carga el formulario hijo
    Private Sub mEvent_LoadForm(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Select Case CType(sender, Form).Text.ToUpper
            Case "VENTAS"

        End Select
    End Sub

    'Funcion que me controla cuando cierro un formulario hijo
    Private Sub mEvent_CloseForm(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs)
        Dim StrAux As String = CType(sender, Form).Text.ToUpper
        Dim _color As Color = Color.FromKnownColor(KnownColor.Control)
        Dim bt As ToolStripButton = Nothing
        'Suprimo el formulario y restauro botones
        Try
            CType(sender, Form).Dispose()
        Catch ex As Exception
        End Try

        Select Case StrAux
            Case "VENTAS" : bt = Me.BtVentas
        End Select

        If Not IsNothing(bt) Then
            bt.BackColor = Me._btcolor_restore
            bt.Tag = 0
        End If

        'Compruebo si hay formularios activos
        Dim sw As Boolean = (Not IsNothing(Me.ActiveMdiChild))
        'If Me.ActiveMdiChild Is m_BackGround Then sw = False

        Me.ToolStripButton_Close.Enabled = sw


        'If Not sw Then Me.Text = My.APP_NAME.CONST_APLICATION_NAME & " - " & MyCfg.Str_NameEmpresa

        Me.LblDetalles.Text = My.APP_NAME & " [" & My.Application.Info.Version.Major & "." & My.Application.Info.Version.Minor & "." & My.Application.Info.Version.Build & "]"
    End Sub

    'Funcion que me controla cuando se desactiva el formulario activo
    Private Sub mEvent_DesactivateForm(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim bt As ToolStripButton = Nothing

        Select Case CType(sender, Form).Text.ToUpper
            Case Me.BtVentas.Text.ToUpper : bt = Me.BtVentas

        End Select

        If Not IsNothing(bt) Then bt.BackColor = Me._btcolor_alt
    End Sub

    'Funcion que me controla cuando se activa un formulario hijo
    Private Sub mEvent_ActiveForm(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim bt As ToolStripButton = Nothing
        Dim StrAux As String = ""

        Select Case CType(sender, Form).Text.ToUpper
            Case "VENTAS" : bt = Me.BtVentas
        End Select

        If Not IsNothing(bt) Then
            bt.BackColor = Me._btcolor
            StrAux = bt.Text
        End If

        If StrAux.Length <= 0 Then Exit Sub

        Me.ToolStripButton_Close.Enabled = True

        Me.LblDetalles.Text = StrAux
    End Sub
#End Region

#Region "Eventos Principales"
    Private Sub frmNoteBook_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.LblDetalles.Text = My.APP_NAME & " [" & My.Application.Info.Version.Major & "." & My.Application.Info.Version.Minor & "." & My.Application.Info.Version.Build & "]"
    End Sub

#End Region

#Region "Eventos Auxiliares"
    Private Sub ToolStripButton_Close_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton_Close.Click
        Form.ActiveForm.ActiveMdiChild.Close()
    End Sub

    Private Sub ToolStripMenu_Register_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenu_Register.Click
        Dim FrmReg As frmRegisterApp
        FrmReg = New frmRegisterApp
        FrmReg.ShowDialog(Me)
        If FrmReg.DialogResult = Windows.Forms.DialogResult.OK Then
            MsgBox("Se debe reiniciar la aplicación para que los cambios tengan efecto", MsgBoxStyle.Exclamation)
            End
        End If
        FrmReg.Dispose()
    End Sub
#End Region

End Class