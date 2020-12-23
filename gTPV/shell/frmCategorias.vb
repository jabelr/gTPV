Public Class frmCategorias
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
        Me.PnlBody.Top = CType(Me.Owner, m_Shell).PnlBody.Top '+ (IIf(My.m_opt.swNoteBook, Me.SplitContainer.Panel1.Height, 0)) '(Me.SplitContainer.Panel2.Height - Me.PnlBody.Height) / 2
        Me.PnlBody.Visible = True

        'Cargo los valores informativos de configuracion
        'Me.LblTitle.Text = Me.m_data.cfg_GetValue("title")
        'Me.LblName.Text = Me.m_data.cfg_GetValue("title")
        'Me.LblSubTitle.Text = Me.m_data.cfg_GetValue("subtitle")


        Me.chkPedidos.Visible = (My.m_opt.modo_compatibilidad = "REPARTO")
    End Sub

#End Region

#Region "Eventos Delegados"
    'Para controlar el caso del nuevo
    Public Sub OnNewField()
        Me.LblFh_Alta.Visible = False
        Me.LblFh_Alta_nfo.Visible = False
        Me.BtSelectImg.Image = Nothing

        Me._id = 0
    End Sub

    'Cada vez que cargo un registro
    Public Sub OnLoadField(ByVal id As Integer)
        Me._id = id
        Me.LblId.Text = "Ref. " & id

        Me.TxtName.Select()
        Me.Tab.SelectedIndex = 0

        Me.LblSubTitle.Text = "Visualizando el registro de """ & Me.TxtName.Text & """"                 ' Submensaje"
        'if me.PicImg.Image isnot nothing andalso not isnothing(Me.BtSelectImg.Image = Me. then
        'Me.BtSelectImg.Image = Me.PicImg.Image

        'Compruebo foto
        Me.BtSelectImg.Text = IIf(IsNothing(Me.BtSelectImg.Image), "Click para seleccionar Imagen", "")

        'Establezco estados
        Me.LblFh_Alta.Visible = True
        Me.LblFh_Alta_nfo.Visible = True
    End Sub

    'Comprobaciones antes de guardar
    Public Sub OnSaveField(ByRef cancell As Boolean)
        If Me.TxtName.TextLength <= 0 Then
            My.m_msg.MessageError(Me.Owner, "Debe de establecer el nombre de la categoria para poder guardar.")
            Me.TxtName.SelectAll()
            cancell = True
            Exit Sub
        End If
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

                Me.BtSelectImg.Text = ""

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


                Me.BtSelectImg.Image = Me.PicImg.Image
                Me.PicImg.Visible = False

                Me.BtClose.Visible = False

                Me.LblSubTitle.Text = "Editando " & Me.TxtName.Text                 ' Submensaje

                If action = gDevelop.Lite.m_EnumTypes.TypeAction.OnNew Then
                    Me.LblSubTitle.Text = "Nuevo Registro"
                    Me.LblId.Visible = False
                    Me.LblNofM.Visible = False


                    'Me.BtSelectImg.Image = Nothing
                End If

                Me.TxtName.Select()

                Exit Sub
            Case gDevelop.Lite.m_EnumTypes.TypeAction.OnCancell, gDevelop.Lite.m_EnumTypes.TypeAction.OnSave
                Me.BtNew.Enabled = True
                Me.BtEdit.Enabled = True
                Me.BtDel.Enabled = True

                Me.BtCancell.Enabled = False
                Me.BtOk.Enabled = False

                Me.BtSelectImg.Text = ""

                Me.LblNofM.Visible = True
                Me.LblId.Visible = True

                FieldPosition(Me._n, Me._m)
        End Select

        ' Estados fijos a no ser que retornemos la funcion
        Me.PicImg.Visible = True
        Me.BtClose.Visible = True

        'Limpio controles
        Me.BtSelectImg.Image = Nothing
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

#Region "Imagen de familia"
    Private Sub BtSelectImg_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtSelectImg.Click
        Dim dlg As New OpenFileDialog()

        dlg.Filter = "Archivos de imagen jpg (*.jpg)|*.jpg"
        dlg.FilterIndex = 0
        dlg.RestoreDirectory = False



        If dlg.ShowDialog() <> Windows.Forms.DialogResult.OK Then Exit Sub

        Me.BtSelectImg.Image = Image.FromFile(gDevelop.Lite.m_Functions.resize_image(dlg.FileName, 110))
        Me.PicImg.Image = Me.BtSelectImg.Image

        Me.BtSelectImg.Text = ""
    End Sub

    Private Sub LnkDelImg_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LnkDelImg.LinkClicked
        Me.BtSelectImg.Image = Nothing
        Me.PicImg.Image = Nothing
        Me.BtSelectImg.Text = "Click para seleccionar Imagen"
    End Sub
#End Region

    Private Sub frmCategorias_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyValue = Keys.Escape Then Me.Close()
    End Sub
End Class