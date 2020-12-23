Public Class frmTmpCajas
    'Private WithEvents m_data As gDevelop.m_dataform
    Private _app As String = ""             'El modulo que cargamos por defecto

    Private _id As Integer = 0

    Private _n As Integer = 0
    Private _m As Integer = 0

    Public Event Shell_App(ByVal app_form As String)         'Para controlar las acciones de los botones desde el formulario padre






#Region "Funciones"
    ''' <summary>Funcion para preconfigurar el formulario</summary>
    Public Function ConfigureApp(ByVal app As String, ByVal name As String) As Boolean
        Me._app = app

        Me.LblTitle.Text = name
        Me.LblName.Text = name
    End Function
#End Region

#Region "Manejadores"
    'Manejador Principal (Shell)
    Private Sub ShellApp(ByVal app_form As String, Optional ByVal action As String = "")
        Dim app As String = app_form.ToUpper

        ''Antes de iniciar cualquier opcion compruebo si la demo es valida (fix change fh)

        Select Case app
            Case "MINIMIZE"
                frm_AppIsMinimized.Show()

                Me.Owner.WindowState = FormWindowState.Minimized
                Me.WindowState = FormWindowState.Minimized

            Case "CLOSE"
                Me.Close()
            Case Else
                RaiseEvent Shell_App(app)
        End Select
    End Sub

#End Region

#Region "Eventos Principales"
    Private Sub m_Shell_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        If (Not IsNothing(m_KeyBoard)) Then m_KeyBoard.Close()
    End Sub
    Private Sub m_Shell_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'Configuro el formulario
        Me.Size = Screen.PrimaryScreen.WorkingArea.Size

        'Centro el body
        Me.PnlBody.Left = CType(Me.Owner, m_Shell).PnlBody.Left         '(Me.Width - Me.PnlBody.Width) / 2
        Me.PnlBody.Top = CType(Me.Owner, m_Shell).PnlBody.Top '(Me.SplitContainer.Panel2.Height - Me.PnlBody.Height) / 2
        Me.PnlBody.Visible = True

        'Cargo los valores informativos de configuracion
        'Me.LblTitle.Text = Me.m_data.cfg_GetValue("title")
        'Me.LblName.Text = Me.m_data.cfg_GetValue("title")
        'Me.LblSubTitle.Text = Me.m_data.cfg_GetValue("subtitle")

        Me.AddHandlers()
    End Sub

#End Region

#Region "Eventos Delegados"

    'Para controlar el caso del nuevo
    Public Sub OnNewField()
        Me.LblFh_Alta.Visible = False
        Me.LblFh_Alta_nfo.Visible = False
    End Sub
    'Cada vez que cargo un registro
    Public Sub OnLoadField(ByVal id As Integer)
        Me._id = id
        Me.LblId.Text = "Ref. " & id

        Me.TxtName_Comercial.Select()
        Me.Tab.SelectedIndex = 0

        Me.LblSubTitle.Text = "Visualizando el registro de """ & Me.TxtName_Comercial.Text & """"                 ' Submensaje"
        'if me.PicImg.Image isnot nothing andalso not isnothing(Me.BtSelectImg.Image = Me. then
        'Me.BtSelectImg.Image = Me.PicImg.Image

        'Compruebo foto

        'Establezco estados
        Me.LblFh_Alta.Visible = True
        Me.LblFh_Alta_nfo.Visible = True
    End Sub

    'Comprobaciones antes de guardar
    Public Sub OnSaveField(ByRef cancell As Boolean)
        'If Me.TxtName_Comercial.TextLength <= 0 Then
        '    My.m_msg.MessageError(Me.Owner, "Debe de establecer el nombre del proveedor para poder guardar.")
        '    Me.TxtName_Comercial.SelectAll()
        '    cancell = True
        '    Exit Sub
        'End If
        'cancell = True
    End Sub

    Public Sub StateForm(ByVal action As gDevelop.Lite.m_EnumTypes.TypeAction)
        Select Case action
            Case gDevelop.Lite.m_EnumTypes.TypeAction._Unknown
                Me.BtNew.Enabled = True
                Me.BtEdit.Enabled = True
                Me.BtDel.Enabled = True

                Me.BtCancell.Enabled = False
                Me.BtOk.Enabled = False

                Me.BtCancell.Enabled = False
                Me.BtOk.Enabled = False


                'Me.LblSubTitle.Text = "Mostrando " & Me.TxtName.Text

            Case gDevelop.Lite.m_EnumTypes.TypeAction.OnNew, gDevelop.Lite.m_EnumTypes.TypeAction.OnEdit
                Me.BtNew.Enabled = False
                Me.BtEdit.Enabled = False
                Me.BtDel.Enabled = False

                Me.BtCancell.Enabled = True
                Me.BtOk.Enabled = True

                Me.BtFirst.Enabled = False
                Me.BtPrevious.Enabled = False

                Me.BtNext.Enabled = False
                Me.BtLast.Enabled = False


                Me.BtClose.Visible = False

                Me.LblSubTitle.Text = "Editando " & Me.TxtName_Comercial.Text                 ' Submensaje

                If action = gDevelop.Lite.m_EnumTypes.TypeAction.OnNew Then
                    Me.LblSubTitle.Text = "Nuevo Registro"
                    Me.LblId.Visible = False
                    Me.LblNofM.Visible = False


                    Me.DtFh_Apertura.Value = Now
                    Me.DtFh_Cerrado.Value = Now
                End If

                Me.TxtName_Comercial.Select()

                Exit Sub
            Case gDevelop.Lite.m_EnumTypes.TypeAction.OnCancell, gDevelop.Lite.m_EnumTypes.TypeAction.OnSave
                Me.BtNew.Enabled = True
                Me.BtEdit.Enabled = True
                Me.BtDel.Enabled = True

                Me.BtCancell.Enabled = False
                Me.BtOk.Enabled = False

                Me.LblNofM.Visible = True
                Me.LblId.Visible = True

                FieldPosition(Me._n, Me._m)
        End Select

        ' Estados fijos a no ser que retornemos la funcion
        Me.BtClose.Visible = True

    End Sub

    Public Sub FieldPosition(ByVal n As Integer, ByVal m As Integer)
        Me.LblNofM.Text = n & "/" & m

        'Establezco el estado de los botones de movimiento
        Me.BtFirst.Enabled = (n > 1)
        Me.BtPrevious.Enabled = (n > 1)

        Me.BtNext.Enabled = (n < m)
        Me.BtLast.Enabled = (n < m)

        Me._n = n
        Me._m = m
        'MsgBox("hola")
    End Sub

    'Delegacion para el control de teclas
    Private Sub form_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        Select Case e.KeyCode
            Case Keys.Escape
                If Not m_KeyBoard Is Nothing Then
                    m_KeyBoard.Dispose()
                    Exit Select
                End If
                Me.Dispose()
        End Select

    End Sub

#End Region

#Region "Eventos Auxiliares"
    Private Sub Buttons_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtClose.Click, BtEdit.Click, BtDel.Click, BtPrevious.Click, BtNext.Click, BtLast.Click, BtFirst.Click, BtOk.Click, BtNew.Click, BtCancell.Click
        'Si no tiene establecido el tag mando un error
        If IsNothing(CType(sender, Button).Tag) OrElse CType(sender, Button).Tag.ToString.Length = 0 Then
            My.m_msg.MessageError(sender, "Tag de control de elemento no referenciado")
            Exit Sub
        End If

        ShellApp(CType(sender, Button).Tag.ToString)
    End Sub

    Private Sub m_Shell_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        Me.Left = 0
        Me.Top = 0

        Me.PnlData.Visible = True
    End Sub

#End Region

#Region "Handlers"
    Private Sub AddHandlers()
        AddHandler Me.TxtBase.KeyPress, AddressOf gDevelop.Lite.m_OverridesEvents.TxtValidaEuro_KeyPress

        AddHandler Me.TxtN_Tickets.KeyPress, AddressOf gDevelop.Lite.m_OverridesEvents.TxtValidaNumeric_KeyPress
    End Sub
#End Region

    Private Sub TxtBase_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtBase.LostFocus
        Me.CalcularTotales()
    End Sub


    'Funcion para calcular y validar totales
    Private Sub CalcularTotales()
        '' Calculo el 16% de IVA
        'If Not IsNumeric(Me.TxtBase.Text) Then Me.TxtBase.Text = 0
        'Me.TxtBase.Text = Format(CDbl(Me.TxtBase.Text), "0.00")
        'Me.TxtIVA.Text = Format((Me.TxtBase.Text * My.IVA_16) / 100, "0.00")
        'Me.TxtTotal.Text = Format(CDbl(Me.TxtBase.Text) + CDbl(Me.TxtIVA.Text), "0.00")

        'Me.LblIVA.Text = Me.TxtIVA.Text
        'Me.LblTotal.Text = Me.TxtTotal.Text

    End Sub
    
End Class