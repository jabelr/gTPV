Public Class frmConfigure
    Private m_data As gDevelop.Lite.m_dataform

    Private m_data_distribuidor As gDevelop.Lite.m_dataform     'Datos de personalizacion del Distribuidor

    Private m_data_ticket As gDevelop.Lite.m_dataform     'Para la pestaña del ticket
    Private m_data_options As gDevelop.Lite.m_dataform     'Para la pestaña de opciones
    Private m_data_facturacion As gDevelop.Lite.m_dataform     'Para la pestaña de facturacion

    Private _admin As Boolean = False          'Para saber si tengo o no que mostrar determinadas cosas

    Private swChange As Boolean = False          'Si se cambia algo, se informa sobre que se ha producido un cambio

#Region "Manejadores"
    'Manejador Principal (Shell) 
    Private Sub ShellApp(ByVal app_form As String, Optional ByVal action As String = "")
        Dim app As String = app_form.ToUpper

        ''Antes de iniciar cualquier opcion compruebo si la demo es valida (fix change fh)

        Select Case app
            Case "BACKUP"
                'Seleccionamos la ruta de destino de la copia de seguridad
                Dim StrDir As String = My.Computer.FileSystem.SpecialDirectories.MyDocuments
                Dim DirDb As FolderBrowserDialog
repeat:
                DirDb = New FolderBrowserDialog
                DirDb.Description = "Seleccione la ubicación donde se guardara la copia de seguridad de la base de datos"
                DirDb.ShowNewFolderButton = True
                DirDb.SelectedPath = StrDir
                If DirDb.ShowDialog() = Windows.Forms.DialogResult.Cancel Then Exit Sub

                Dim strAux As String = DirDb.SelectedPath
                If Not strAux.EndsWith("\") Then strAux &= "\"
                DirDb.Dispose()

                'Genero el nombre de copia de la copia de seguridad
                StrDir = strAux & Format(Now, "yyyyMMdd") & "_" & My.APP_DATABASE & ".tbck"

                'Obtengo origen y compruebo que el destino este limpio
                Dim StrOrigen As String = My.m_app.GetValue("local_mdb") & My.APP_DATABASE & ".mdb"
                If My.Computer.FileSystem.FileExists(StrDir) Then
                    If MsgBox("En el direcctorio especificado existe ya una copia de seguridad del dia de hoy, si continua esta se sobreescribira. ¿Esta seguro de que desea continuar?", MsgBoxStyle.Question + MsgBoxStyle.OkCancel, "Copia de seguridad") <> MsgBoxResult.Ok Then Exit Sub
                    My.Computer.FileSystem.DeleteFile(StrDir)
                End If

                My.Computer.FileSystem.CopyFile(StrOrigen, StrDir)
                MsgBox("Copia de seguridad realizada correctamente.", MsgBoxStyle.Information)

            Case "INITMAIN"
                ' Reseteo de la aplicacion
                If MsgBox("¿Esta seguro de que desea realizar una limpieza de la aplicación?", MsgBoxStyle.YesNo + MsgBoxStyle.Question, My.APP_NAME) <> MsgBoxResult.Yes Then Exit Select
                If MsgBox("¿Sabe lo que conlleva dicha acción?", MsgBoxStyle.YesNo + MsgBoxStyle.Question, My.APP_NAME) <> MsgBoxResult.Yes Then Exit Select

                MsgBox("Bien!, tenga en cuenta que hasta que no se haya completado el proceso no se tomara ninguna acción. Asi que comenzemos.", MsgBoxStyle.Information)

                If MsgBox("Existen dos posibilidades de limpieza de la aplicación: superficial y completa." & vbCrLf & _
                          "  - SUPERFICIAL, conlleva una limpieza de [Cajas-Ticket] y reorganización de series." & vbCrLf & _
                          "  - COMPLETA, incluye la superficial y, ademas, produce la limpieza de [Artículos-Familias]." & vbCrLf & _
                          "" & vbCrLf & _
                          "¿Desea cotinuar?", vbQuestion + vbYesNoCancel) <> MsgBoxResult.Yes Then Exit Select

                If MsgBox("¿Desea realizar una limpieza SUPERFICIAL del software?", MsgBoxStyle.YesNo + MsgBoxStyle.Question, My.APP_NAME) = MsgBoxResult.Yes Then
                    MsgBox("Realizo borrado superficial")
                ElseIf MsgBox("¿Desea realizar una limpieza COMPLETA del software?", MsgBoxStyle.YesNo + MsgBoxStyle.Question, My.APP_NAME) = MsgBoxResult.Yes Then
                    MsgBox("Realizo borrado tottal")
                End If


                If MsgBox("Existen categorías y productos, si borramos estos, partimos de cero ¿realizar una limpieza de la aplicación?", MsgBoxStyle.YesNo + MsgBoxStyle.Question, My.APP_NAME) <> MsgBoxResult.Yes Then Exit Select

                If MsgBox("¿Esta seguro de que desea realizar una limpieza de la aplicación?", MsgBoxStyle.YesNo + MsgBoxStyle.Question, My.APP_NAME) <> MsgBoxResult.Yes Then Exit Select

                If MsgBox("Pero esta muy, muy seguro de lo que desea hacer. ¿Es consciente de que inicializara la aplicación con los valores recomendados por defecto?", MsgBoxStyle.OkCancel + MsgBoxStyle.Question, My.APP_NAME) <> MsgBoxResult.Ok Then Exit Select

                MsgBox("limpio la base de datos")


                '# DISTRIBUIDOR
            Case "OK_DISTRIBUIDOR"
                Me.m_data_distribuidor.data_SaveField()
                Me.m_data_distribuidor.data_LoadField(1)

                Me.BtDistribuidor_Edit.Enabled = True
                Me.BtDistribuidor_OK.Enabled = False
                Me.BtDistribuidor_Cancell.Enabled = False

                Me.ConfigureTab(Me.TabPage_Distribuidor, True)
                Me.swChange = True

            Case "CANCELL_DISTRIBUIDOR"
                Me.m_data_distribuidor.data_LoadField(1)

                Me.BtDistribuidor_Edit.Enabled = True
                Me.BtDistribuidor_OK.Enabled = False
                Me.BtDistribuidor_Cancell.Enabled = False
                Me.ConfigureTab(Me.TabPage_Distribuidor, True)

            Case "EDIT_DISTRIBUIDOR"
                Me.BtSelectImg_Distribuidor.Image = Me.PicImg_Distribuidor.Image

                Me.m_data_distribuidor.data_EditField(1)

                Me.BtDistribuidor_Edit.Enabled = False
                Me.BtDistribuidor_OK.Enabled = True
                Me.BtDistribuidor_Cancell.Enabled = True

                Me.ConfigureTab(Me.TabPage_Distribuidor, False)



                '# CAJA
            Case "OK_CAJA"
                Me.m_data_facturacion.data_SaveField()
                Me.m_data_facturacion.data_LoadField(My.m_app.GetValue("id_contable"))

                Me.BtCaja_Edit.Enabled = True
                Me.BtCaja_Ok.Enabled = False
                Me.BtCaja_Cancell.Enabled = False

                Me.ConfigureTab(Me.TabPage_Facturacion, True)
                Me.swChange = True

            Case "CANCELL_CAJA"

                Me.m_data_facturacion.data_LoadField(My.m_app.GetValue("id_contable"))

                Me.BtCaja_Edit.Enabled = True
                Me.BtCaja_Ok.Enabled = False
                Me.BtCaja_Cancell.Enabled = False
                Me.ConfigureTab(Me.TabPage_Facturacion, True)

            Case "EDIT_CAJA"
                Me.m_data_facturacion.data_EditField(My.m_app.GetValue("id_contable"))

                Me.BtCaja_Edit.Enabled = False
                Me.BtCaja_Ok.Enabled = True
                Me.BtCaja_Cancell.Enabled = True

                Me.ConfigureTab(Me.TabPage_Facturacion, False)



                '# OPCIONES
            Case "OK_OPTIONS"
                'Si he marcado el modo seguro compruebo de que existen usuarios y tienen contraseña
                If Me.ChkOption_ModeSegure.Checked Then
                    Dim rst As ADODB.Recordset = My.m_db.GetRst("SELECT id FROM db_usuarios WHERE tipo_user='MAESTRO' AND estado='ACTIVADO' AND len(pass)>0")
                    If rst.RecordCount = 0 Then
                        My.m_msg.MessageError(Me, "Para poder activar el ""Modo Seguro"" debe de haber creado un usuario con privilegios de maestro que se encuentre activado y tenga establecida una contraseña." & vbCrLf & vbCrLf & "Puede crear o modificar uno existente desde la opción de ""Usuarios y Empleados"" de la pantalla de inicio.")
                        My.m_db.CloseRst(rst)
                        Exit Select
                    End If

                    My.m_db.CloseRst(rst)
                End If
                If Me.CbCompatibilidad.SelectedIndex = -1 Then Me.CbCompatibilidad.SelectedIndex = 0
                Me.m_data_options.data_SaveField()

                My.m_app.SetValue("id_portlector") = Me.CbPortLector.SelectedIndex
                My.m_app.SetValue("swlector") = Me.ChkLector.Checked
                My.m_app.SetValue("codlector") = Me.TxtPrefijo.Text

                Me.m_data_options.data_LoadField(My.m_app.GetValue("id_empresa"))


                Me.BtEdit_Options.Enabled = True
                Me.BtOk_Options.Enabled = False
                Me.BtCancell_Options.Enabled = False

                Me.ConfigureTab(Me.TabPage_Opciones, True)
                My.LoadAppConfig()
                My.Load_OptionsHardware()
                Me.swChange = True

            Case "CANCELL_OPTIONS"

                Me.m_data_options.data_LoadField(My.m_app.GetValue("id_empresa"))

                Me.BtEdit_Options.Enabled = True
                Me.BtOk_Options.Enabled = False
                Me.BtCancell_Options.Enabled = False
                Me.ConfigureTab(Me.TabPage_Opciones, True)

            Case "EDIT_OPTIONS"
                Me.m_data_options.data_EditField(My.m_app.GetValue("id_empresa"))

                Me.BtEdit_Options.Enabled = False
                Me.BtOk_Options.Enabled = True
                Me.BtCancell_Options.Enabled = True

                Me.ConfigureTab(Me.TabPage_Opciones, False)



                '# TICKET
            Case "OK_TICKET"
                Me.m_data_ticket.data_SaveField()
                Me.m_data_ticket.data_LoadField(My.m_app.GetValue("id_empresa"))

                'Guardo los detalles de la impresora de tickets
                My.m_app.SetValue("id_printer") = Me.CbPrinterModel.Text.Substring(50).Trim
                My.m_app.SetValue("id_portprinter") = Me.CbPrinterPort.SelectedIndex
                My.m_app.SetValue("portname") = Me.CbPrinterPort.Text

                'Guardo los detalles de la impresora de tickets
                My.m_app.SetValue("id_comandas") = Me.CbComandasModel.Text.Substring(50).Trim
                My.m_app.SetValue("id_portcomandas") = Me.CbComandasPort.SelectedIndex
                My.m_app.SetValue("portnamecomandas") = Me.CbComandasPort.Text


                'Guardo los valores del Cash Drawer Directo
                My.m_app.SetValue("cd_enabled") = Me.ChkCashDrawer.Checked
                My.m_app.SetValue("cd_port_address") = Me.TxtCD_Address.Text
                My.m_app.SetValue("cd_port_open") = Me.TxtCD_Open.Text
                My.m_app.SetValue("cd_port_close") = Me.TxtCD_Close.Text
                My.m_app.SetValue("cd_port_sbit") = Me.TxtCD_SBit.Text

                My.m_app.SetValue("ccom_enabled") = Me.ChkCashDrawerCOM.Checked
                My.m_app.SetValue("ccom_port") = Me.cbCOMDirecto.SelectedIndex


                'Guardo los valores de la balanza PC
                My.m_app.SetValue("balanza_port") = Me.CbBalanza.Text
                My.m_app.SetValue("balanza_enabled") = ChkBalanza.Checked
                My.m_app.SetValue("balanza_tipo") = Me.cbBalanzaTipo.Text

                My.m_app.SetValue("cashlogy_enabled") = Me.chkCashlogic.Checked
                My.m_app.SetValue("cashlogy_ip") = Me.txtCashlogic_ip.Text
                My.m_app.SetValue("cashlogy_port") = Me.txtCashlogic_port.Text

                My.Load_OptionsHardware()

                Me.BtEdit_Ticket.Enabled = True
                Me.BtOk_Ticket.Enabled = False
                Me.BtCancell_Ticket.Enabled = False



                Me.ConfigureTab(Me.TabPage_Ticket, True)
                Me.swChange = True

            Case "CANCELL_TICKET"

                Me.m_data_ticket.data_LoadField(My.m_app.GetValue("id_empresa"))

                Me.BtEdit_Ticket.Enabled = True
                Me.BtOk_Ticket.Enabled = False
                Me.BtCancell_Ticket.Enabled = False
                Me.ConfigureTab(Me.TabPage_Ticket, True)

            Case "EDIT_TICKET"
                Me.m_data_ticket.data_EditField(My.m_app.GetValue("id_empresa"))

                Me.BtEdit_Ticket.Enabled = False
                Me.BtOk_Ticket.Enabled = True
                Me.BtCancell_Ticket.Enabled = True

                Me.ConfigureTab(Me.TabPage_Ticket, False)



                '# EMPRESA
            Case "OK_EMPRESA"
                Me.m_data.data_SaveField()
                Me.m_data.data_LoadField(My.m_app.GetValue("id_empresa"))

                Me.BtEdit_Empresa.Enabled = True
                Me.BtOk_Empresa.Enabled = False
                Me.BtCancell_Empresa.Enabled = False

                ConfigureTab(Me.TabPage_Empresa, True)
                Me.swChange = True

            Case "CANCELL_EMPRESA"

                Me.m_data.data_LoadField(My.m_app.GetValue("id_empresa"))

                Me.BtEdit_Empresa.Enabled = True
                Me.BtOk_Empresa.Enabled = False
                Me.BtCancell_Empresa.Enabled = False
                ConfigureTab(Me.TabPage_Empresa, True)

            Case "EDIT_EMPRESA"
                Me.BtImg_Empresa.Image = Me.PicImg_Empresa.Image

                Me.m_data.data_EditField(My.m_app.GetValue("id_empresa"))

                Me.BtEdit_Empresa.Enabled = False
                Me.BtOk_Empresa.Enabled = True
                Me.BtCancell_Empresa.Enabled = True

                ConfigureTab(Me.TabPage_Empresa, False)



                '# BASE
            Case "MINIMIZE"
                frm_AppIsMinimized.Show()

                Me.Owner.WindowState = FormWindowState.Minimized
                Me.WindowState = FormWindowState.Minimized

            Case "CLOSE"
                Me.Close()
            Case Else
                My.m_msg.MessageError(Me, "Tag no referenciado")
                'RaiseEvent Shell_App(app)
        End Select
    End Sub

#End Region

#Region "Funciones"
    'Funcion para configurar el tab cuando estamos editando o trabajando sobre un tab
    Private Sub ConfigureTab(ByVal tabPage As TabPage, ByVal Add As Boolean)
        Dim i As Integer

        If Add Then
            'Elimino el actual para agregarlo conforme su orden
            Me.Tab.SuspendLayout()
            Me.Tab.Visible = False

            'Me.Tab.TabPages.Remove(tabPage)
            Me.Tab.TabPages.Clear()

            'Los agregon en orden
            Me.Tab.TabPages.Add(Me.TabPage_Main)
            Me.Tab.TabPages.Add(Me.TabPage_Empresa)
            Me.Tab.TabPages.Add(Me.TabPage_Ticket)
            Me.Tab.TabPages.Add(Me.TabPage_Facturacion)
            Me.Tab.TabPages.Add(Me.TabPage_Opciones)
            Me.Tab.TabPages.Add(Me.TabPage_Zonas)
            Me.Tab.TabPages.Add(Me.TabPage_Galeria)
            Me.Tab.TabPages.Add(Me.TabPage_Distribuidor)
            If Me._admin Then
                Me.Tab.TabPages.Add(Me.TabPage_MoreInfo)
            End If
            Me.Tab.TabPages.Add(Me.TabPage_Diseño)
            Me.Tab.TabPages.Add(Me.TabPage_operaciones)

            'Selecciono el actual
            Me.Tab.SelectedTab = tabPage
            Me.Tab.Visible = True
            Me.Tab.ResumeLayout()

        Else
            For i = Me.Tab.TabCount - 1 To 0 Step -1
                If Not Me.Tab.TabPages(i) Is tabPage Then Me.Tab.TabPages.Remove(Me.Tab.TabPages(i))
            Next
        End If
    End Sub
#End Region

#Region "Eventos Principales"
    ' Formulario de Carga
    Private Sub m_Shell_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'Configuro el formulario
        Me.Size = Screen.PrimaryScreen.WorkingArea.Size

        'Centro el body
        Me.PnlBody.Left = (Me.Width - Me.PnlBody.Width) / 2
        Me.PnlBody.Top = (Me.SplitContainer.Panel2.Height - Me.PnlBody.Height) / 2 + (IIf(My.m_opt.swNoteBook, Me.SplitContainer.Panel1.Height, 0))

        Me.PnlBody.Visible = True

        ''Cargo datos del distribuidor
        'Dim rst As ADODB.Recordset = My.m_db.GetRst("SELECT img FROM app_distribuidor")
        'Me.PicLogo.Image = My.m_db.data_GetImgRow(rst("img"))
        'My.m_db.CloseRst(rst)

        Me.CbCompatibilidad.SelectedIndex = 0

        ' Cargo la configuración
        Me.m_data = New gDevelop.Lite.m_dataform(My.m_db)

        Me.m_data.DbTable = "app_empresa"
        Me.m_data.ConfigureDataForm(Me.TabPage_Empresa.Controls)

        Me.m_data.data_LoadField(My.m_app.GetValue("id_empresa"))

        Me.ConfigureTab(Me.TabPage_Main, True)


        Me.GroupRegister.Visible = Not My.m_app.IsRegister
        Me.btUnlockTicket.Visible = My.m_app.IsRegister

        Me.AddHandlers()

        'Comprobamos estado de registro para activar botones
        Me.checkState(Not My.m_app.IsRegister)

        'Aplico idioma
        Select Case My.m_app.GetValue("lng").ToUpper
            Case "GL-ES" : Me.rbtPais_ESGA.Checked = True
            Case "ES-ES" : Me.rbtPais_ESES.Checked = True
            Case "ES-MX" : Me.rbtPais_ESMX.Checked = True
            Case "FR-FR" : Me.rbtPais_FRFR.Checked = True
        End Select

        'CIERRO EL CASHLOGIC SI LO TENGO ABIERTO
        If Not IsNothing(My.Application.sckCashlogy) Then
            My.Application.sckCashlogy.Close()
            My.Application.sckCashlogy = Nothing

            My.Application.sIOCashlogy.Close()
            My.Application.sIOCashlogy = Nothing

        End If

    End Sub

    Private Sub Tab_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Tab.SelectedIndexChanged
        Select Case True
            Case Me.Tab.SelectedTab Is Me.TabPage_Galeria : Me.LoadCat_GaleriaImg()
            Case Me.Tab.SelectedTab Is Me.TabPage_Opciones : Me.LoadApp_Options()
            Case Me.Tab.SelectedTab Is Me.TabPage_Facturacion : Me.LoadApp_Facturacion()
            Case Me.Tab.SelectedTab Is Me.TabPage_Ticket : Me.LoadApp_Ticket()
            Case Me.Tab.SelectedTab Is Me.TabPage_Diseño : Me.LoadCat_DesignImg()
            Case Me.Tab.SelectedTab Is Me.TabPage_Distribuidor : Me.LoadApp_Distribuidor()
            Case Me.Tab.SelectedTab Is Me.TabPage_Zonas : Me.LoadOrganizacion()
        End Select
    End Sub

    ' Limpieza de objetos
    Private Sub frmConfigure_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If Not IsNothing(Me.m_data) Then
            Me.m_data.Dispose()
            Me.m_data = Nothing
        End If
        If Not IsNothing(Me.m_data_ticket) Then
            Me.m_data_ticket.Dispose()
            Me.m_data_ticket = Nothing
        End If

        If Not IsNothing(Me.m_data_options) Then
            Me.m_data_options.Dispose()
            Me.m_data_options = Nothing
        End If

        If Not IsNothing(Me.m_data_facturacion) Then
            Me.m_data_facturacion.Dispose()
            Me.m_data_facturacion = Nothing
        End If

        If Not IsNothing(Me.m_data_distribuidor) Then
            Me.m_data_distribuidor.Dispose()
            Me.m_data_distribuidor = Nothing
        End If

        If Not IsNothing(Me.sckCliente) Then
            If Me.sckCliente.Connected Then
                Me.sckCliente.Close()
            End If
            Me.sckCliente = Nothing
        End If

        If Me.swChange Then MsgBox("Tenga en cuenta que ha realizado cambios en la configuración de la aplicación" & vbCrLf & vbCrLf & "Por ello se va a proceder a recargar automaticamente los valores en este puesto Cliente pero no en los demas puestos Cliente, para estos sera necesario que reinicien la aplicación para cargar los nuevos valores.", MsgBoxStyle.Information)
    End Sub
#End Region

#Region "Eventos Delegados"

    ''Para controlar el caso del nuevo
    'Public Sub OnNewField()
    '    Me.LblFh_Alta.Visible = False
    '    Me.LblFh_Alta_nfo.Visible = False
    '    Me.BtSelectImg.Image = Nothing
    'End Sub
    ''Cada vez que cargo un registro
    'Public Sub OnLoadField(ByVal id As Integer)
    '    Me._id = id
    '    Me.LblId.Text = "Ref. " & id

    '    Me.TxtName_Comercial.Select()
    '    Me.Tab.SelectedIndex = 0

    '    Me.LblSubTitle.Text = "Visualizando el registro de """ & Me.TxtName_Comercial.Text & """"                 ' Submensaje"
    '    'if me.PicImg.Image isnot nothing andalso not isnothing(Me.BtSelectImg.Image = Me. then 
    '    'Me.BtSelectImg.Image = Me.PicImg.Image

    '    'Compruebo foto
    '    Me.BtSelectImg.Text = IIf(IsNothing(Me.BtSelectImg.Image), "Click para seleccionar Imagen", "")

    '    'Establezco estados
    '    Me.LblFh_Alta.Visible = True
    '    Me.LblFh_Alta_nfo.Visible = True
    'End Sub

    ''Comprobaciones antes de guardar
    'Public Sub OnSaveField(ByRef cancell As Boolean)
    '    If Me.TxtName_Comercial.TextLength <= 0 Then
    '        My.m_msg.MessageError(Me.Owner, "Debe de establecer el nombre del proveedor para poder guardar.")
    '        Me.TxtName_Comercial.SelectAll()
    '        cancell = True
    '        Exit Sub
    '    End If
    '    'cancell = True
    'End Sub

    'Public Sub StateForm(ByVal action As gDevelop.m_EnumTypes.TypeAction)
    '    Select Case action
    '        Case gDevelop.m_EnumTypes.TypeAction._Unknown

    '        Case gDevelop.m_EnumTypes.TypeAction.OnNew, gDevelop.m_EnumTypes.TypeAction.OnEdit
    '            Me.TxtName_Comercial.Select()

    '            Exit Sub
    '        Case gDevelop.m_EnumTypes.TypeAction.OnCancell, gDevelop.m_EnumTypes.TypeAction.OnSave
    '            End Select

    'End Sub


#End Region

#Region "Eventos Auxiliares"
    Private Sub m_logo_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles m_logo.DoubleClick, PictureBox13.DoubleClick
        Me._admin = True
        Me.ConfigureTab(Me.TabPage_Main, True)
        Me.pnlEgg.Visible = True
        Me.picLuh.Visible = True
        Me.PicCovimatic.Visible = True
        Me.picPCopas.Visible = True

        'My.m_msg.MessageNfo("Se han agregado nuevas funcionalidades al sistema... tenga cuidado con su uso!!!!")
        MsgBox("Se han agregado nuevas funcionalidades al sistema... tenga cuidado con su uso!!!!", MsgBoxStyle.Information)
    End Sub

    Private Sub CbImg_Cat_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CbImg_Cat.SelectedIndexChanged
        Me._galeria_pag = 0
        Me.Load_GaleriaImg()
    End Sub

    Private Sub CbDesign_Cat_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CbDesignImg.SelectedIndexChanged
        Me._design_pag = 0
        Me.Load_DesigImg()
    End Sub

    Private Sub Buttons_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtClose.Click, BtEdit_Empresa.Click, BtOk_Empresa.Click, BtCancell_Empresa.Click, BtOk_Ticket.Click, BtEdit_Ticket.Click, BtCancell_Ticket.Click, BtOk_Options.Click, BtEdit_Options.Click, BtCancell_Options.Click, BtCaja_Ok.Click, BtCaja_Edit.Click, BtCaja_Cancell.Click, BtDistribuidor_OK.Click, BtDistribuidor_Edit.Click, BtDistribuidor_Cancell.Click, BtInitSystem.Click, BtBackUp.Click
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

    Private Sub Chk_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChkOption_CajaDirecta.CheckedChanged, ChkOption_ModeSegure.CheckedChanged, ChkOption_RequireUser.CheckedChanged, CheckBox9.CheckedChanged, CheckBox8.CheckedChanged, CheckBox7.CheckedChanged, CheckBox6.CheckedChanged, CheckBox5.CheckedChanged, CheckBox4.CheckedChanged, CheckBox32.CheckedChanged, CheckBox31.CheckedChanged, CheckBox30.CheckedChanged, CheckBox3.CheckedChanged, CheckBox29.CheckedChanged, CheckBox28.CheckedChanged, CheckBox27.CheckedChanged, CheckBox26.CheckedChanged, CheckBox25.CheckedChanged, CheckBox24.CheckedChanged, CheckBox23.CheckedChanged, CheckBox22.CheckedChanged, CheckBox21.CheckedChanged, CheckBox20.CheckedChanged, CheckBox2.CheckedChanged, CheckBox19.CheckedChanged, CheckBox18.CheckedChanged, CheckBox17.CheckedChanged, CheckBox16.CheckedChanged, CheckBox15.CheckedChanged, CheckBox14.CheckedChanged, CheckBox13.CheckedChanged, CheckBox12.CheckedChanged, CheckBox11.CheckedChanged, CheckBox10.CheckedChanged, CheckBox1.CheckedChanged, ChkOption_AutoClose.CheckedChanged, RbtShowInfo_Distribuidor.CheckedChanged, ChkOption_CloseCajaUser.CheckedChanged, ChkCashDrawer.CheckedChanged, ChkBalanza.CheckedChanged, chkNotNameImg.CheckedChanged, chkMySQL_Remoto.CheckedChanged, chkModeSeguro_secciones.CheckedChanged, chkTicketAvanzado.CheckedChanged, CheckBox33.CheckedChanged, chkResponsive.CheckedChanged, CheckBox34.CheckedChanged, chkRecargo.CheckedChanged, CheckBox35.CheckedChanged, chkNotDelete.CheckedChanged, ChkCashDrawerCOM.CheckedChanged, chkModeRPT.CheckedChanged, chkCashlogic.CheckedChanged
        CType(sender, CheckBox).ImageIndex = IIf(CType(sender, CheckBox).Checked, 1, 0)
        Me.PnlCashDrawer.Visible = Me.ChkCashDrawer.Checked

        If Me.ChkBalanza.Checked Then
            Me.BtBalanzaCheck.Visible = True
            '    Me.CbBalanza.Enabled = True
        Else
            Me.BtBalanzaCheck.Visible = False
            '    Me.CbBalanza.Enabled = False
            '    Me.CbBalanza.SelectedIndex = 0
        End If

        Me.groupConexion_MySQL.Visible = Me.chkMySQL_Remoto.Checked
        Me.groupLector.Visible = Me.chkMySQL_Remoto.Checked


        Me.cbCOMDirecto.Visible = Me.ChkCashDrawerCOM.Checked


        Me.GroupCashlogic.Enabled = Me.chkCashlogic.Checked


    End Sub


    Private Sub chkNotOrden_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkNotOrden.CheckedChanged
        CType(sender, CheckBox).ImageIndex = IIf(CType(sender, CheckBox).Checked, 1, 0)
    End Sub

    Private Sub BtValidar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtValidar.Click
        frmRegisterApp.ShowDialog()

        'Si el codigo no es valido, cancelo el inicio de la aplicacion
        If frmRegisterApp.DialogResult = Windows.Forms.DialogResult.OK Then Me.PnlDemo.Visible = False
    End Sub

#End Region

#Region "Handlers"
    'Funcion que me agrega manejadores de los textbox
    Private Sub AddHandlers()
        AddHandler Me.TxtIVA_General.KeyPress, AddressOf gDevelop.Lite.m_OverridesEvents.TxtValidaEuro_KeyPress
        AddHandler Me.TxtIVA_Medio.KeyPress, AddressOf gDevelop.Lite.m_OverridesEvents.TxtValidaEuro_KeyPress
        AddHandler Me.TxtIVA_Basico.KeyPress, AddressOf gDevelop.Lite.m_OverridesEvents.TxtValidaEuro_KeyPress

        AddHandler Me.TxtRecargo_General.KeyPress, AddressOf gDevelop.Lite.m_OverridesEvents.TxtValidaEuro_KeyPress
        AddHandler Me.TxtRecargo_Medio.KeyPress, AddressOf gDevelop.Lite.m_OverridesEvents.TxtValidaEuro_KeyPress
        AddHandler Me.TxtRecargo_Basico.KeyPress, AddressOf gDevelop.Lite.m_OverridesEvents.TxtValidaEuro_KeyPress

        AddHandler Me.TxtContador_Facturas.KeyPress, AddressOf gDevelop.Lite.m_OverridesEvents.TxtValidaNumeric_KeyPress
        AddHandler Me.TxtContador_Tickets.KeyPress, AddressOf gDevelop.Lite.m_OverridesEvents.TxtValidaNumeric_KeyPress
        AddHandler Me.TxtContador_Cajas.KeyPress, AddressOf gDevelop.Lite.m_OverridesEvents.TxtValidaNumeric_KeyPress

        AddHandler Me.TxtFacturacion_Year.KeyPress, AddressOf gDevelop.Lite.m_OverridesEvents.TxtValidaNumeric_KeyPress

        AddHandler Me.TxtEntradaNormal.KeyPress, AddressOf gDevelop.Lite.m_OverridesEvents.TxtValidaEuro_KeyPress
        AddHandler Me.TxtEntradaEspecial.KeyPress, AddressOf gDevelop.Lite.m_OverridesEvents.TxtValidaEuro_KeyPress

        AddHandler Me.txtNCopias.KeyPress, AddressOf gDevelop.Lite.m_OverridesEvents.TxtValidaNumeric_KeyPress
        AddHandler Me.txtIncIngredientes.KeyPress, AddressOf gDevelop.Lite.m_OverridesEvents.TxtValidaEuro_KeyPress

        AddHandler Me.txtEstanco_contador.KeyPress, AddressOf gDevelop.Lite.m_OverridesEvents.TxtValidaNumeric_KeyPress

        'AddHandler Me.TxtOpcion_NLimit.KeyPress, AddressOf gDevelop.m_OverridesEvents.TxtValidaNumeric_KeyPress
    End Sub
#End Region

#Region "Tratamiento de Logo"
    '# Selecciono el Logo de la empresa
    Private Sub BtSelectImg_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtImg_Empresa.Click
        'Dim myStream As IO.Stream
        Dim dlg As New OpenFileDialog()

        dlg.Filter = "Archivos de imagen jpg (*.jpg)|*.jpg"
        dlg.FilterIndex = 0
        dlg.RestoreDirectory = False

        If dlg.ShowDialog() <> Windows.Forms.DialogResult.OK Then Exit Sub

        Me.BtImg_Empresa.Image = Image.FromFile(gDevelop.Lite.m_Functions.resize_image(dlg.FileName, 170))
        Me.PicImg_Empresa.Image = Me.BtImg_Empresa.Image

        Me.BtImg_Empresa.Text = ""
    End Sub

    '# Selecciono el Banner de la empresa
    Private Sub BtSelectImgBanner_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtImgBanner_Empresa.Click
        'Dim myStream As IO.Stream
        Dim dlg As New OpenFileDialog()

        dlg.Filter = "Archivos de imagen jpg (*.jpg)|*.jpg"
        dlg.FilterIndex = 0
        dlg.RestoreDirectory = False

        If dlg.ShowDialog() <> Windows.Forms.DialogResult.OK Then Exit Sub

        Me.BtImgBanner_Empresa.Image = Image.FromFile(gDevelop.Lite.m_Functions.resize_image(dlg.FileName, 360))
        Me.PicImgBanner_Empresa.Image = Me.BtImgBanner_Empresa.Image

        Me.BtImgBanner_Empresa.Text = ""
    End Sub

    Private Sub LnkEmpresa_ClearImg_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LnkEmpresa_ClearImg.LinkClicked
        Me.PicImg_Empresa.Image = Nothing
        Me.BtImg_Empresa.Image = Nothing
        Me.BtImg_Empresa.Text = "Click para seleccionar Imagen"
    End Sub

    Private Sub LnkEmpresa_ClearImg_Banner_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LnkEmpresa_ClearImgBanner.LinkClicked
        Me.PicImgBanner_Empresa.Image = Nothing
        Me.BtImgBanner_Empresa.Image = Nothing
        Me.BtImg_Empresa.Text = "Click para seleccionar Imagen"
    End Sub
#End Region

#Region "Pestaña de Galeria de Imagenes"
    Private _galeria_tot As Integer = 0
    Private _galeria_pag As Integer = 0

    Private Sub LoadCat_GaleriaImg()
        Dim rst As ADODB.Recordset = My.m_db.GetRst("SELECT * FROM app_imgs_categorias ORDER BY name ASC")

        Me.CbImg_Cat.Items.Clear()
        Me.CbImg_Cat.Items.Add("Mostror TODOS" & Space(100) & "0")
        While Not rst.EOF
            Me.CbImg_Cat.Items.Add(rst("name").Value & Space(100) & rst("id").Value)
            rst.MoveNext()
        End While
        Me.CbImg_Cat.SelectedIndex = 0
        My.m_db.CloseRst(rst)
    End Sub

    Private Sub Load_GaleriaImg()
        Me.BtImg_Previous.Enabled = (Me._galeria_pag > 0)
        Me.BtImg_Next.Enabled = False

        ' Nº de productos a lo ancho y a lo alto a mostrar
        Dim _x As Integer = 7
        Dim _y As Integer = 4

        'Localizacion de inicio para el primer boton
        Dim _left As Integer = 47
        Dim _top As Integer = 16

        'Variables Auxiliares
        Dim i As Integer = 0, j As Integer = 0, n As Integer
        Dim rst As ADODB.Recordset
        Dim sql As String

        '### Paginacion
        sql = "SELECT count(id) as tot FROM app_imgs"
        If Me.CbImg_Cat.SelectedIndex > 0 Then sql &= " WHERE id_categoria=" & Me.CbImg_Cat.Text.Substring(100).Trim
        rst = My.m_db.GetRst(sql)
        Me._galeria_tot = rst("tot").Value
        My.m_db.CloseRst(rst)

        '### Limpio anteriores controltes
        For i = Me.Group_Galeria.Controls.Count - 1 To 0 Step -1
            Me.Group_Galeria.Controls(i).Dispose()
        Next


        '### Obtengo las imagenes de la categoria seleccionada
        sql = "SELECT * FROM app_imgs"
        If Me.CbImg_Cat.SelectedIndex > 0 Then sql &= " WHERE id_categoria=" & Me.CbImg_Cat.Text.Substring(100).Trim
        sql &= " ORDER BY id desc"
        rst = My.m_db.GetRst(sql)


        '### Agrego los botones de las imagenes
        i = 0
        While Not rst.EOF
            If (n >= (Me._galeria_pag * (_x * _y))) Then
                ' Creo y configuro el nuevo boton
                Dim bt As Button
                bt = New Button
                bt.Font = New Font("Verdana", 7)
                bt.Image = My.m_db.data_GetImgRow(rst("img"))
                bt.Margin = New Padding(0)
                bt.Name = n
                bt.Size = New Size(112, 109)
                bt.TabIndex = n
                bt.Location = New Point(_left + (bt.Width * i), _top + (bt.Height * j))
                bt.Text = rst("name").Value
                bt.TextAlign = ContentAlignment.BottomCenter
                bt.Tag = rst("id").Value
                bt.UseVisualStyleBackColor = True

                ' Asigno Eventos
                AddHandler bt.Click, AddressOf BtImg_Edit_Click

                Group_Galeria.Controls.Add(bt)
                bt.Visible = True

                i += 1
                If i = _x Then
                    i = 0
                    j += 1
                    If j >= _y Then
                        Me.BtImg_Next.Enabled = True
                        Exit While
                    End If
                End If
            End If
            n += 1

            rst.MoveNext()
        End While
        My.m_db.CloseRst(rst)

    End Sub

    Private Sub BtImg_New_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtImg_New.Click
        'Muestro el formulario de lineas
        With frmConfigure_ImgGalery
            .Id_Ref = 0
            .ShowDialog(Me)
            If .DialogResult <> Windows.Forms.DialogResult.OK Then
                .Dispose()
                Exit Sub
            End If

            'Vuelvo a cargar las imagenes
            Me.Load_GaleriaImg()
            .Dispose()
        End With
    End Sub

    Private Sub BtImg_Edit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'Muestro la opcion de editar
        With frmConfigure_ImgGalery
            .Id_Ref = CType(sender, Button).Tag

            .ShowDialog(Me)
            If .DialogResult <> Windows.Forms.DialogResult.OK Then
                .Dispose()
                Exit Sub
            End If

            'Vuelvo a cargar las imagenes
            Me.Load_GaleriaImg()

            .Dispose()
        End With

    End Sub

    Private Sub BtImg_Move_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtImg_Next.Click, BtImg_Previous.Click
        Select Case True
            Case sender Is Me.BtImg_Previous
                Me._galeria_pag -= 1

            Case sender Is Me.BtImg_Next
                Me._galeria_pag += 1
        End Select

        Load_GaleriaImg()
    End Sub
#End Region

#Region "Pestaña de Imagenes de Diseño"
    Private _design_tot As Integer = 0
    Private _design_pag As Integer = 0

    Private Sub LoadCat_DesignImg()
        Dim rst As ADODB.Recordset = My.m_db.GetRst("SELECT * FROM app_design_categorias ORDER BY name ASC")

        Me.CbDesignImg.Items.Clear()
        Me.CbDesignImg.Items.Add("Mostror TODOS" & Space(100) & "0")
        While Not rst.EOF
            Me.CbDesignImg.Items.Add(rst("name").Value & Space(100) & rst("id").Value)
            rst.MoveNext()
        End While
        Me.CbDesignImg.SelectedIndex = 0
        My.m_db.CloseRst(rst)
    End Sub

    Private Sub Load_DesigImg()
        Me.BtDesign_Prev.Enabled = (Me._design_pag > 0)
        Me.BtDesign_Next.Enabled = False

        ' Nº de productos a lo ancho y a lo alto a mostrar
        Dim _x As Integer = 7
        Dim _y As Integer = 4

        'Localizacion de inicio para el primer boton
        Dim _left As Integer = 47
        Dim _top As Integer = 16

        'Variables Auxiliares
        Dim i As Integer = 0, j As Integer = 0, n As Integer
        Dim rst As ADODB.Recordset
        Dim sql As String

        '### Paginacion
        sql = "SELECT count(id) as tot FROM app_design"
        If Me.CbDesignImg.SelectedIndex > 0 Then sql &= " WHERE id_categoria=" & Me.CbDesignImg.Text.Substring(100).Trim
        rst = My.m_db.GetRst(sql)
        Me._design_tot = rst("tot").Value
        My.m_db.CloseRst(rst)

        '### Limpio anteriores controltes
        For i = Me.Group_Diseño.Controls.Count - 1 To 0 Step -1
            Me.Group_Diseño.Controls(i).Dispose()
        Next


        '### Obtengo las imagenes de la categoria seleccionada
        sql = "SELECT * FROM app_design"
        If Me.CbDesignImg.SelectedIndex > 0 Then sql &= " WHERE id_categoria=" & Me.CbDesignImg.Text.Substring(100).Trim
        sql &= " ORDER BY id desc"
        rst = My.m_db.GetRst(sql)


        '### Agrego los botones de las imagenes
        i = 0
        While Not rst.EOF
            If (n >= (Me._design_pag * (_x * _y))) Then
                ' Creo y configuro el nuevo boton
                Dim bt As Button
                bt = New Button
                bt.Font = New Font("Verdana", 7)
                bt.Image = My.m_db.data_GetImgRow(rst("img"))
                bt.Margin = New Padding(0)
                bt.Name = n
                bt.Size = New Size(112, 109)
                bt.TabIndex = n
                bt.Location = New Point(_left + (bt.Width * i), _top + (bt.Height * j))
                bt.Text = rst("name").Value
                bt.TextAlign = ContentAlignment.BottomCenter
                bt.Tag = rst("id").Value
                bt.UseVisualStyleBackColor = True

                ' Asigno Eventos
                AddHandler bt.Click, AddressOf BtDesign_Edit_Click

                Me.Group_Diseño.Controls.Add(bt)
                bt.Visible = True

                i += 1
                If i = _x Then
                    i = 0
                    j += 1
                    If j >= _y Then
                        Me.BtDesign_Next.Enabled = True
                        Exit While
                    End If
                End If
            End If
            n += 1

            rst.MoveNext()
        End While
        My.m_db.CloseRst(rst)

    End Sub

    Private Sub BtDesign_New_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtDesign_New.Click
        'Muestro el formulario de lineas
        With frmConfigure_DesignGalery
            .Id_Ref = 0
            .ShowDialog(Me)
            If .DialogResult <> Windows.Forms.DialogResult.OK Then
                .Dispose()
                Exit Sub
            End If

            'Vuelvo a cargar las imagenes
            Me.Load_DesigImg()
            .Dispose()
        End With
    End Sub

    Private Sub BtDesign_Edit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'Muestro la opcion de editar
        With frmConfigure_DesignGalery
            .Id_Ref = CType(sender, Button).Tag

            .ShowDialog(Me)
            If .DialogResult <> Windows.Forms.DialogResult.OK Then
                .Dispose()
                Exit Sub
            End If

            'Vuelvo a cargar las imagenes
            Me.Load_DesigImg()

            .Dispose()
        End With

    End Sub

    Private Sub BtDesign_Move_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtDesign_Next.Click, BtDesign_Prev.Click
        Select Case True
            Case sender Is Me.BtImg_Previous
                Me._design_pag -= 1

            Case sender Is Me.BtImg_Next
                Me._design_pag += 1
        End Select

        Me.Load_DesigImg()
    End Sub
#End Region

#Region "Pestaña de configuración del Ticket"
    Private Sub LoadApp_Ticket()
        ' Creo el objeto, escaneo si no esta creado
        If IsNothing(Me.m_data_ticket) Then
            Me.m_data_ticket = New gDevelop.Lite.m_dataform(My.m_db)

            Me.m_data_ticket.DbTable = "app_ticket"
            Me.m_data_ticket.ConfigureDataForm(Me.TabPage_Ticket.Controls)
        End If

        ' Cargo valores del tickets
        Me.m_data_ticket.data_LoadField(My.m_app.GetValue("id_empresa"))

        '####### Cargo la configuración de la IMPRESORA DE TICKET
        Dim rst As ADODB.Recordset = My.m_db.GetRst("SELECT id,name FROM app_printers")
        Me.CbPrinterModel.Items.Clear()
        While Not rst.EOF
            Me.CbPrinterModel.Items.Add(rst("name").Value & Space(50) & rst("id").Value)
            If rst("id").Value = My.m_app.GetValue("id_printer", 0) Then Me.CbPrinterModel.SelectedIndex = Me.CbPrinterModel.Items.Count - 1


            Me.CbComandasModel.Items.Add(rst("name").Value & Space(50) & rst("id").Value)
            If rst("id").Value = My.m_app.GetValue("id_comandas", 0) Then Me.CbComandasModel.SelectedIndex = Me.CbComandasModel.Items.Count - 1

            rst.MoveNext()
        End While
        My.m_db.CloseRst(rst)
        Me.CbPrinterPort.SelectedIndex = My.m_app.GetValue("id_portprinter", 0)
        Me.CbComandasPort.SelectedIndex = My.m_app.GetValue("id_portcomandas", 0)


        '####### Cargo la configuración del CASH DRAWER
        Me.ChkCashDrawer.Checked = CBool(My.m_app.GetValue("cd_enabled"))
        Me.TxtCD_Address.Text = My.m_app.GetValue("cd_port_address")
        Me.TxtCD_Open.Text = My.m_app.GetValue("cd_port_open")
        Me.TxtCD_Close.Text = My.m_app.GetValue("cd_port_close")
        Me.TxtCD_SBit.Text = My.m_app.GetValue("cd_port_sbit")

        Me.ChkCashDrawerCOM.Checked = My.m_app.GetValue("ccom_enabled")
        Me.cbCOMDirecto.SelectedIndex = My.m_app.GetValue("ccom_port", 0)


        '####### Cargo la configuración de la balanza
        Me.GroupBalanza.Visible = (My.m_opt.modo_compatibilidad = "COMERCIO")
        Me.ChkBalanza.Checked = CBool(My.m_app.GetValue("balanza_enabled"))
        Me.cbBalanzaTipo.Text = My.m_app.GetValue("balanza_tipo", "0")
        Me.CbBalanza.Text = My.m_app.GetValue("balanza_port")


        '####### Cargo la configuración CASHLOGIC
        Me.chkCashlogic.Checked = CBool(My.m_app.GetValue("cashlogy_enabled", False))
        Me.txtCashlogic_ip.Text = My.m_app.GetValue("cashlogy_ip", "127.0.0.1")
        Me.txtCashlogic_port.Text = My.m_app.GetValue("cashlogy_port", 8092)

    End Sub

    Private Sub BtTicket_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtTicket.Click
        My.PreviewTicket()
    End Sub

    Private Sub BtComandas_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtComanda.Click
        My.PreviewComanda()
    End Sub

    Private Sub BtPrinter_Del_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtPrinter_Del.Click
        Dim rst As ADODB.Recordset = My.m_db.GetRst("SELECT * FROM app_printers WHERE id=" & Me.CbPrinterModel.Text.Substring(50).Trim)
        If rst.RecordCount <= 0 Then
            MsgBox("Imposible eliminar la impresora seleccionada porque no se ha localizado.", MsgBoxStyle.Critical)
            Exit Sub
        End If

        'Compruebo si se puede eliminar
        If CBool(rst("Notdelete").Value) Then
            MsgBox("Imposible eliminar una impresora de sistema.", MsgBoxStyle.Critical)
            Exit Sub
        End If
        My.m_db.CloseRst(rst)

        If MsgBox("¿Esta seguro de que desea eliminar la impresora seleccionada?", MsgBoxStyle.OkCancel + MsgBoxStyle.Question) <> MsgBoxResult.Ok Then Exit Sub

        My.m_db.Execute("DELETE FROM printers WHERE id=" & Me.CbPrinterModel.Text.Substring(50).Trim)

        Me.LoadApp_Ticket()
        Me.Buttons_Click(Me.BtEdit_Ticket, New System.EventArgs)
    End Sub

    Private Sub BtComandas_Del_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtComandas_del.Click
        Dim rst As ADODB.Recordset = My.m_db.GetRst("SELECT * FROM app_printers WHERE id=" & Me.CbComandasModel.Text.Substring(50).Trim)
        If rst.RecordCount <= 0 Then
            MsgBox("Imposible eliminar la impresora seleccionada porque no se ha localizado.", MsgBoxStyle.Critical)
            Exit Sub
        End If

        'Compruebo si se puede eliminar
        If CBool(rst("Notdelete").Value) Then
            MsgBox("Imposible eliminar una impresora de sistema.", MsgBoxStyle.Critical)
            Exit Sub
        End If
        My.m_db.CloseRst(rst)

        If MsgBox("¿Esta seguro de que desea eliminar la impresora seleccionada?", MsgBoxStyle.OkCancel + MsgBoxStyle.Question) <> MsgBoxResult.Ok Then Exit Sub

        My.m_db.Execute("DELETE FROM printers WHERE id=" & Me.CbComandasModel.Text.Substring(50).Trim)

        Me.LoadApp_Ticket()
        Me.Buttons_Click(Me.BtEdit_Ticket, New System.EventArgs)
    End Sub


    Private Sub BtPrinter_Add_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtPrinter_Add.Click
        frmConfigurePrinter.IdRef = 0
        frmConfigurePrinter.ShowDialog(Me)
        If frmConfigurePrinter.DialogResult <> Windows.Forms.DialogResult.OK Then
            frmConfigurePrinter.Dispose()
            Exit Sub
        End If
        frmConfigurePrinter.Dispose()
        Me.LoadApp_Ticket()
        Me.Buttons_Click(Me.BtEdit_Ticket, New System.EventArgs)
    End Sub

    Private Sub BtComandas_Add_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtComandas_Add.Click
        frmConfigurePrinter.IdRef = 0
        frmConfigurePrinter.ShowDialog(Me)
        If frmConfigurePrinter.DialogResult <> Windows.Forms.DialogResult.OK Then
            frmConfigurePrinter.Dispose()
            Exit Sub
        End If
        frmConfigurePrinter.Dispose()
        Me.LoadApp_Ticket()
        Me.Buttons_Click(Me.BtEdit_Ticket, New System.EventArgs)
    End Sub

    Private Sub BtPrinter_Edit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtPrinter_Edit.Click
        frmConfigurePrinter.IdRef = Me.CbPrinterModel.Text.Substring(50).Trim
        frmConfigurePrinter.ShowDialog(Me)
        If frmConfigurePrinter.DialogResult <> Windows.Forms.DialogResult.OK Then
            frmConfigurePrinter.Dispose()
            Exit Sub
        End If
        frmConfigurePrinter.Dispose()

        Dim idAux As Integer = Me.CbPrinterModel.SelectedIndex

        'Recargo valores
        If Me.CbPrinterModel.Text.Substring(50).Trim = My.MyHardware.IdPrinter Then My.Load_OptionsHardware()
        Me.LoadApp_Ticket()
        Me.Buttons_Click(Me.BtEdit_Ticket, New System.EventArgs)

        Me.CbPrinterModel.SelectedIndex = idAux
    End Sub

    Private Sub BtComandas_Edit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtComandas_edit.Click
        frmConfigurePrinter.IdRef = Me.CbComandasModel.Text.Substring(50).Trim
        frmConfigurePrinter.ShowDialog(Me)
        If frmConfigurePrinter.DialogResult <> Windows.Forms.DialogResult.OK Then
            frmConfigurePrinter.Dispose()
            Exit Sub
        End If
        frmConfigurePrinter.Dispose()

        Dim idAux As Integer = Me.CbComandasModel.SelectedIndex

        'Recargo valores
        If Me.CbComandasModel.Text.Substring(50).Trim = My.MyComanda.IdPrinter Then My.Load_OptionsHardware()
        Me.LoadApp_Ticket()
        Me.Buttons_Click(Me.BtEdit_Ticket, New System.EventArgs)

        Me.CbComandasModel.SelectedIndex = idAux
    End Sub

    Private Sub BtBalanzaCheck_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtBalanzaCheck.Click
        If Me.CbBalanza.SelectedIndex <= 0 Then
            MsgBox("Debe de establecer un puerto válido para testear la balanza", MsgBoxStyle.Exclamation)
            Exit Sub
        End If
        frmConfigure_BalanzaCheck.strPort = Me.CbBalanza.Text
        frmConfigure_BalanzaCheck.ShowDialog(Me)
        frmConfigure_BalanzaCheck.Dispose()
    End Sub
#End Region

#Region "Pestaña de Opciones"
    Private Sub LoadApp_Options()
        ' Creo el objeto, escaneo si no esta creado
        If IsNothing(Me.m_data_options) Then
            Me.m_data_options = New gDevelop.Lite.m_dataform(My.m_db)

            Me.m_data_options.DbTable = "app_options"
            Me.m_data_options.ConfigureDataForm(Me.GroupOptions.Controls)
        End If

        ' Cargo valores del tickets
        Me.m_data_options.data_LoadField(My.m_app.GetValue("id_empresa"))

        'Cargo los datos del lector de codigos de barras
        Me.ChkLector.Checked = My.MyLector.Sw_Lector
        Me.TxtPrefijo.Text = My.MyLector.Str_CodLector

        Me.CbPortLector.SelectedIndex = My.m_app.GetValue("id_portlector", 0)
    End Sub


    Private Sub BtCheckHost_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtCheckHost.Click
        Dim db As MySql.Data.MySqlClient.MySqlConnection
        Dim sql As String = ""

        Dim cmd As MySql.Data.MySqlClient.MySqlCommand = Nothing
        Dim reader As MySql.Data.MySqlClient.MySqlDataReader = Nothing

        Dim strConnect As String = ""
        strConnect = "Database=" & Me.TxtMySQLCliente_Db.Text & ";Data Source=" & Me.TxtMySQLCliente_Host.Text & ";User Id=" & Me.TxtMySQLCliente_User.Text & ";Password=" & Me.TxtMySQLCliente_Pass.Text

        db = New MySql.Data.MySqlClient.MySqlConnection(strConnect)

        'Compruebo la conexión
        Try
            db.Open()
        Catch ex As Exception
            MsgBox("Error al tratar de conectar, los motivos son:" & vbCrLf & ex.Message, MsgBoxStyle.Critical, "MySQL Remoto")
            Exit Sub
        End Try

        MsgBox("Conexión establecida correctamente.", MsgBoxStyle.Information)
    End Sub

    Private Sub btCheckLector_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btCheckLector.Click
        Dim idPort As Integer = Me.CbPortLector.SelectedIndex

        If idPort <= 0 Then
            MsgBox("Puerto no Valido")
            Exit Sub
        End If

        frmConfigure_GetCodeGP20.IdPort = idPort
        frmConfigure_GetCodeGP20.ShowDialog(Me)
        If frmConfigure_GetCodeGP20.DialogResult <> Windows.Forms.DialogResult.OK Then
            frmConfigure_GetCodeGP20.Dispose()
            Exit Sub
        End If

        MsgBox("El código leido es: " & frmConfigure_GetCodeGP20.StrCode & ".", MsgBoxStyle.Information)

        frmConfigure_GetCodeGP20.Dispose()
    End Sub
#End Region

#Region "Pestaña de Facturacion"
    Private Sub LoadApp_Facturacion()
        ' Creo el objeto, escaneo si no esta creado
        If IsNothing(Me.m_data_facturacion) Then
            Me.m_data_facturacion = New gDevelop.Lite.m_dataform(My.m_db)

            Me.m_data_facturacion.DbTable = "app_contabilidad"
            Me.m_data_facturacion.ConfigureDataForm(Me.Group_Facturacion.Controls)
        End If

        ' Cargo valores del tickets
        Me.m_data_facturacion.data_LoadField(My.m_app.GetValue("id_contable"))

    End Sub
#End Region

#Region "Pestaña del Distribuidor"
    Private Sub LoadApp_Distribuidor()
        Dim swLock As Boolean = False

        ' Creo el objeto, escaneo si no esta creado
        If IsNothing(Me.m_data_distribuidor) Then
            Me.m_data_distribuidor = New gDevelop.Lite.m_dataform(My.m_db)

            Me.m_data_distribuidor.DbTable = "app_distribuidor"
            Me.m_data_distribuidor.ConfigureDataForm(Me.Group_Distribuidor.Controls)

            swLock = True
        End If

        ' Cargo valores del tickets
        Me.m_data_distribuidor.data_LoadField(1)

        If swLock Then
            Dim sw As Boolean = (Me.TxtDistribuidor_Pass.TextLength > 0)
            Me.PnlDistribuidor_Pass.Visible = sw
            Me.GroupSecure.Visible = Not sw
        End If
    End Sub

    Private Sub BtUnlockDistribuidor_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtUnlockDistribuidor.Click
        If Not Me.TxtDistribuidor_Pass.Text.ToUpper = Me.TxtPassEdit.Text.ToUpper Then Exit Sub

        Me.BtDistribuidor_Edit.Enabled = True
        Me.GroupSecure.Visible = True

        Me.PnlDistribuidor_Pass.Visible = False
    End Sub

    Private Sub TxtPassEdit_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtPassEdit.KeyPress
        If e.KeyChar = Chr(13) Then
            e.Handled = True
            BtUnlockDistribuidor_Click(sender, e)
        End If
    End Sub

    Private Sub TxtPassEdit_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtPassEdit.TextChanged
        Me.BtUnlockDistribuidor.Enabled = (Me.TxtPassEdit.TextLength > 0)
    End Sub

    Private Sub ChkShowPass_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChkShowPass.CheckedChanged
        Me.TxtDistribuidor_Pass.PasswordChar = IIf(Me.ChkShowPass.Checked, "", "*")
    End Sub

#Region "Selección de Imagen"
    Private Sub BtSelectImg_Distribuidor_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtSelectImg_Distribuidor.Click
        Dim dlg As New OpenFileDialog()

        dlg.Filter = "Archivos de imagen jpg (*.jpg)|*.jpg"
        dlg.FilterIndex = 0
        dlg.RestoreDirectory = False

        If dlg.ShowDialog() <> Windows.Forms.DialogResult.OK Then Exit Sub

        Me.BtSelectImg_Distribuidor.Image = Image.FromFile(gDevelop.Lite.m_Functions.resize_image(dlg.FileName, 350))
        Me.PicImg_Distribuidor.Image = Me.BtSelectImg_Distribuidor.Image

        Me.PicImg_Distribuidor.Text = ""
    End Sub
#End Region

#End Region

#Region "Pestaña de Organización"
    Private Sub LoadOrganizacion()
        Dim m_Table As DataTable            'Tabla de datos
        Dim rst As ADODB.Recordset
        Dim da As Data.OleDb.OleDbDataAdapter
        Dim ColStyle As DataGridViewColumn
        Dim Cell As DataGridViewCell = New DataGridViewTextBoxCell()

        'El estilo de las celdas
        Dim m_Style As New DataGridViewCellStyle
        With m_Style
            .BackColor = Color.FromKnownColor(KnownColor.GradientActiveCaption)
            .ForeColor = Color.Black
            .Font = New Font("Verdana", 20)
            .Padding = New Padding(3, 1, 1, 0)
        End With

        Dim m_Style_alt As New DataGridViewCellStyle
        With m_Style_alt
            .BackColor = Color.FromKnownColor(KnownColor.GradientInactiveCaption)
            .ForeColor = Color.Black
            .Font = New Font("Verdana", 20)
            .Padding = New Padding(3, 1, 1, 0)
        End With

        'Preconfiguramos el grid de las zonas
        With Me.GridZonas
            .Columns.Clear()
            .AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells
            .AutoGenerateColumns = False

            'El id
            ColStyle = New DataGridViewColumn()
            ColStyle.DataPropertyName = "id"
            ColStyle.HeaderText = "Ref."
            ColStyle.Width = 55
            ColStyle.DefaultCellStyle = m_Style
            ColStyle.CellTemplate = Cell
            .Columns.Add(ColStyle)

            'El articulo
            ColStyle = New DataGridViewColumn()
            ColStyle.DataPropertyName = "name"
            ColStyle.HeaderText = "Zona"
            ColStyle.Width = 500
            ColStyle.DefaultCellStyle = m_Style
            ColStyle.CellTemplate = Cell
            .Columns.Add(ColStyle)


            .DefaultCellStyle = m_Style
            .AlternatingRowsDefaultCellStyle = m_Style_alt
        End With

        'Asignamos los datos
        rst = My.m_db.GetRst("SELECT id,name FROM db_zonas ORDER BY name ASC")
        If IsNothing(rst) Then Exit Sub

        m_Table = New DataTable("m_tabla")
        da = New Data.OleDb.OleDbDataAdapter
        da.Fill(m_Table, rst)
        Me.GridZonas.DataSource = m_Table

        Me.BtZonas_Edit.Enabled = (Me.GridZonas.RowCount > 0)
        Me.BtZonas_Del.Enabled = (Me.GridZonas.RowCount > 0)


        'Preconfiguramos el grid de los conceptos varios
        With Me.gridVarios
            .Columns.Clear()
            .AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells
            .AutoGenerateColumns = False

            'El id
            ColStyle = New DataGridViewColumn()
            ColStyle.DataPropertyName = "id"
            ColStyle.HeaderText = "Ref."
            ColStyle.Width = 55
            ColStyle.DefaultCellStyle = m_Style
            ColStyle.CellTemplate = Cell
            .Columns.Add(ColStyle)

            'El articulo
            ColStyle = New DataGridViewColumn()
            ColStyle.DataPropertyName = "name"
            ColStyle.HeaderText = "Zona"
            ColStyle.Width = 500
            ColStyle.DefaultCellStyle = m_Style
            ColStyle.CellTemplate = Cell
            .Columns.Add(ColStyle)


            .DefaultCellStyle = m_Style
            .AlternatingRowsDefaultCellStyle = m_Style_alt
        End With

        'Asignamos los datos
        rst = My.m_db.GetRst("SELECT id,name FROM db_vv ORDER BY name ASC")
        If IsNothing(rst) Then Exit Sub

        m_Table = New DataTable("m_tabla")
        da = New Data.OleDb.OleDbDataAdapter
        da.Fill(m_Table, rst)
        Me.gridVarios.DataSource = m_Table

        Me.BtVarios_edit.Enabled = (Me.gridVarios.RowCount > 0)
        Me.BtVarios_del.Enabled = (Me.gridVarios.RowCount > 0)
    End Sub

    'Botonera de las Zonas
    Private Sub BtZonas_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtZonas_Add.Click, BtZonas_Edit.Click, BtZonas_Del.Click
        Select Case True
            Case sender Is Me.BtZonas_Add
                'Muestro el formulario de las zonas
                With frmConfigure_Zonas
                    .Id_Ref = 0
                    .ShowDialog(Me)
                    If .DialogResult <> Windows.Forms.DialogResult.OK Then
                        .Dispose()
                        Exit Sub
                    End If

                    'Vuelvo a cargar las imagenes
                    Me.LoadOrganizacion()
                    .Dispose()
                End With
            Case sender Is Me.BtZonas_Edit
                'Muestro el formulario de las zonas
                With frmConfigure_Zonas
                    .Id_Ref = Me.GridZonas.CurrentRow.Cells(0).Value
                    .ShowDialog(Me)
                    If .DialogResult <> Windows.Forms.DialogResult.OK Then
                        .Dispose()
                        Exit Sub
                    End If

                    'Vuelvo a cargar las imagenes
                    Me.LoadOrganizacion()
                    .Dispose()
                End With
            Case sender Is Me.BtZonas_Del
                If IsNothing(Me.GridZonas.CurrentRow) Then Exit Select
                If Me.GridZonas.CurrentRow.Cells(0).Value = 1 Then
                    MsgBox("Imposible eliminar la zona por defecto de gTPV.", MsgBoxStyle.Critical)
                    Exit Select
                End If
                If MsgBox("¿Esta seguro de que desea eliminar la zona seleccionada?", MsgBoxStyle.Question + MsgBoxStyle.YesNo) <> MsgBoxResult.Yes Then Exit Select

                ''Compruebo si tiene articulos la categoria
                'Dim rst As ADODB.Recordset = My.Application.m_Db.GetRst("SELECT id FROM articulos WHERE id_categoria=" & Me.Grid_CatArticulos.CurrentRow.Cells(0).Value)
                'If rst.RecordCount > 0 AndAlso MsgBox("Mire que la categoría esta asignada actualmente a " & rst.RecordCount & " artículos.  ¿Esta seguro de que desea continuar?", MsgBoxStyle.Question + MsgBoxStyle.YesNo) <> MsgBoxResult.Yes Then Exit Select
                'My.Application.m_Db.CloseRst(rst)

                My.m_db.Execute("DELETE FROM db_zonas WHERE id=" & Me.GridZonas.CurrentRow.Cells(0).Value)

                Me.LoadOrganizacion()
        End Select
    End Sub

    'Botonera de las Conceptos Varios
    Private Sub BtVarios_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtVarios_Add.Click, BtVarios_edit.Click, BtVarios_del.Click
        Select Case True
            Case sender Is Me.BtVarios_Add
                'Muestro el formulario de las varios
                With frmConfigure_ConceptoVarios
                    .Id_Ref = 0
                    .ShowDialog(Me)
                    If .DialogResult <> Windows.Forms.DialogResult.OK Then
                        .Dispose()
                        Exit Sub
                    End If

                    'Vuelvo a cargar las imagenes
                    Me.LoadOrganizacion()
                    .Dispose()
                End With
            Case sender Is Me.BtVarios_edit
                'Muestro el formulario de las varios
                With frmConfigure_ConceptoVarios
                    .Id_Ref = Me.gridVarios.CurrentRow.Cells(0).Value
                    .ShowDialog(Me)
                    If .DialogResult <> Windows.Forms.DialogResult.OK Then
                        .Dispose()
                        Exit Sub
                    End If

                    'Vuelvo a cargar las imagenes
                    Me.LoadOrganizacion()
                    .Dispose()
                End With
            Case sender Is Me.BtVarios_del
                If IsNothing(Me.gridVarios.CurrentRow) Then Exit Select
                If MsgBox("¿Esta seguro de que desea eliminar el concepto seleccionado?", MsgBoxStyle.Question + MsgBoxStyle.YesNo) <> MsgBoxResult.Yes Then Exit Select

                My.m_db.Execute("DELETE FROM db_vv WHERE id=" & Me.gridVarios.CurrentRow.Cells(0).Value)

                Me.LoadOrganizacion()
        End Select

    End Sub

    Private Sub GridZonas_CellMouseDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles GridZonas.CellMouseDoubleClick
        Me.BtZonas_Click(Me.BtZonas_Edit, New System.EventArgs)
    End Sub

    Private Sub GridVarios_CellMouseDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles gridVarios.CellMouseDoubleClick
        Me.BtVarios_Click(Me.BtVarios_edit, New System.EventArgs)
    End Sub
#End Region

#Region "CASHLOGIC"

    Private sckCliente As System.Net.Sockets.TcpClient
    Private sIOCashlogy As System.Net.Sockets.NetworkStream
    'Private WithEvents tmrCashlogy As System.Windows.Forms.Timer

    Public bytes() As Byte = Nothing
    Private sCadena As String

    Private Sub btCashLogicTest_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btCashLogicTest.Click
        'tmrCashlogy = New System.Windows.Forms.Timer
        'tmrCashlogy.Enabled = False

        Dim i As Integer = 0


        Me.sckCliente = New System.Net.Sockets.TcpClient
        Try
            Me.sckCliente.Connect(System.Net.IPAddress.Parse(Me.txtCashlogic_ip.Text), Me.txtCashlogic_port.Text)
            'System.Windows.Forms.Application.DoEvents()
        Catch ex As Exception
            MsgBox("Imposible conectar, el motivo es: " & ex.Message, MsgBoxStyle.Critical)
            Exit Sub
        End Try
        sIOCashlogy = Me.sckCliente.GetStream

        sCadena = "#I#"
        bytes = System.Text.Encoding.ASCII.GetBytes(sCadena)
        sIOCashlogy.Write(bytes, 0, bytes.Length)

        sCadena = ""
        bytes = Nothing


        'Realizo lectura del buffer (OK de inicializacion)
        Threading.Thread.Sleep(1000)
        While True
            If Not sIOCashlogy.DataAvailable Then
                Threading.Thread.Sleep(1000)
                i += 1

                If i > 60 Then
                    MsgBox("Imposible inicializar, tiempo de espera agotado.", MsgBoxStyle.Critical)
                    Me.sckCliente.Close()
                    Me.sckCliente = Nothing
                    Exit Sub
                End If
            Else

                ReDim bytes(Me.sckCliente.ReceiveBufferSize)
                sIOCashlogy.Read(bytes, 0, bytes.Length)
                sCadena = System.Text.Encoding.ASCII.GetString(bytes, 0, bytes.Length)

                If sCadena.Substring(0, 8) <> "#0#2.01#" Then
                    MsgBox("Imposible inicializar, comando no reconocido: " & sCadena, MsgBoxStyle.Critical)
                    Me.sckCliente.Close()
                    Me.sckCliente = Nothing
                    Exit Sub
                Else
                    ' TODO OK
                    Exit While
                End If
            End If
        End While


        'Realizo lectura del buffer (OK de inicializacion)
        bytes = Nothing
        sCadena = ""

        sCadena = "#E#"
        bytes = System.Text.Encoding.ASCII.GetBytes(sCadena)
        sIOCashlogy.Write(bytes, 0, bytes.Length)
        i = 0

        sCadena = ""
        bytes = Nothing

        Threading.Thread.Sleep(1000)
        While True
            If Not sIOCashlogy.DataAvailable Then
                Threading.Thread.Sleep(1000)
                i += 1

                If i > 50 Then
                    MsgBox("Imposible inicializar, tiempo de espera agotado.", MsgBoxStyle.Critical)
                    Me.sckCliente.Close()
                    Me.sckCliente = Nothing
                    Exit Sub
                End If
            Else

                ReDim bytes(Me.sckCliente.ReceiveBufferSize)
                sIOCashlogy.Read(bytes, 0, bytes.Length)
                sCadena = System.Text.Encoding.ASCII.GetString(bytes, 0, bytes.Length)

                If sCadena.Substring(0, 3) <> "#0#" Then
                    MsgBox("Imposible finalizar, comando no reconocido: " & sCadena, MsgBoxStyle.Critical)
                    Me.sckCliente.Close()
                    Me.sckCliente = Nothing
                    Exit Sub
                Else
                    ' TODO OK
                    Exit While
                End If
            End If
        End While

        MsgBox("Conexión correcta, TEST pasado correctamente.", MsgBoxStyle.Information)
        'tmrCashlogy.Interval = 1000
        'tmrCashlogy.Enabled = True
        'tmrCashlogy.Start()

    End Sub

    'Private Sub tmrCashlogy_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tmrCashlogy.Tick
    '    If IsNothing(Me.sckCliente) Then Exit Sub

    '    If Not Me.sckCliente.Connected Then Exit Sub
    '    If Not sIOCashlogy.DataAvailable Then
    '        bytes = Nothing
    '        sCadena = ""
    '        Exit Sub
    '    End If

    '    ReDim bytes(Me.sckCliente.ReceiveBufferSize)
    '    sIOCashlogy.Read(bytes, 0, bytes.Length)
    '    sCadena = System.Text.Encoding.ASCII.GetString(bytes, 0, bytes.Length)


    '    If sCadena.Substring(0, 8) = "#0#2.01#" Then
    '        sCadena = "#E#"
    '        bytes = System.Text.Encoding.ASCII.GetBytes(sCadena)
    '        sIOCashlogy.Write(bytes, 0, bytes.Length)


    '    ElseIf sCadena.Substring(0, 3) = "#0#" Then
    '        MsgBox("Conexión completada correctamente.", MsgBoxStyle.Information)

    '        sCadena = ""
    '        bytes = Nothing

    '        Me.tmrCashlogy.Stop()
    '        Me.tmrCashlogy.Enabled = False

    '        Me.sckCliente.Close()
    '        Me.sckCliente = Nothing
    '    Else
    '        MsgBox(sCadena, MsgBoxStyle.Critical)
    '    End If

    'End Sub

#End Region

    Private Sub lnkImportaDB_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles lnkImportaDB.LinkClicked
        Dim fileExists As Boolean = False, StrDir As String = Me.lblImporta_Ruta.Text

        Dim DirDb As FolderBrowserDialog
repeat:
        DirDb = New FolderBrowserDialog
        DirDb.Description = "Seleccione la ubicacion local donde se encuenta la base de datos: '" & My.APP_DATABASE & ".mdb' de la que se van a importar los tiques"
        DirDb.ShowNewFolderButton = False
        DirDb.RootFolder = Environment.SpecialFolder.Desktop
        DirDb.SelectedPath = StrDir
        If DirDb.ShowDialog() = Windows.Forms.DialogResult.Cancel Then Exit Sub

        Dim strAux As String = DirDb.SelectedPath
        If Not strAux.EndsWith("\") Then strAux &= "\"
        DirDb.Dispose()

        StrDir = strAux & My.APP_DATABASE & ".mdb"
        fileExists = My.Computer.FileSystem.FileExists(StrDir)

        If fileExists Then          'Guardo opciones
            Me.lblImporta_Ruta.Text = strAux
        Else
            If MsgBox("No se ha podido establer conexión con la base de Datos en '" & StrDir & "'." & Chr(13) & Chr(13) & "¿Desea probar de nuevo?", MsgBoxStyle.YesNo + MsgBoxStyle.Critical) = MsgBoxResult.Yes Then GoTo repeat
            Exit Sub
        End If

        'Configuro el listView
        With Me.lstImporta.Columns
            .Clear()
            .Add("", 40, HorizontalAlignment.Left)
            .Add("Ref.", 0, HorizontalAlignment.Left)
            .Add("Ticket", 80, HorizontalAlignment.Left)
            .Add("Hora", 100, HorizontalAlignment.Left)
            .Add("Importe", 80, HorizontalAlignment.Right)
        End With

        '# Agrego tickets
        Dim dbOrigen As gDevelop.Lite.m_database = New gDevelop.Lite.m_database(gDevelop.Lite.m_EnumTypes.DatabaseConnection.Access)
        dbOrigen.Database_SourceHost = strAux
        dbOrigen.Database_Name = My.APP_DATABASE & ".mdb"
        If Not dbOrigen.Connect() Then
            MsgBox("Error al tratar de conectar con la base de datos.", MsgBoxStyle.Critical)
            Exit Sub
        End If

        Dim rst As ADODB.Recordset = dbOrigen.GetRst("SELECT * FROM db_tickets WHERE id_caja=-1")
        Dim rstAux As ADODB.Recordset = Nothing
        Dim i As Integer = 0, dbl As Double = 0

        Me.lstImporta.CheckBoxes = True

        While Not rst.EOF
            With Me.lstImporta
                .Items.Add("")
                .Items(i).SubItems.Add(rst("id").Value)
                .Items(i).SubItems.Add(rst("n_ticket").Value)
                .Items(i).SubItems.Add(Format(rst("fh_update").Value, "dd/MMM HH:mm"))
                .Items(i).SubItems.Add(rst("total").Value)

                dbl += rst("total").Value
                .Items(i).Checked = True
                .Items(i).EnsureVisible()
                .Refresh()
            End With

            i += 1
            rst.MoveNext()
        End While
        dbOrigen.CloseRst(rst)

        dbOrigen.Dispose()
        dbOrigen = Nothing

        MsgBox("Se han encontrado " & i & " tickets por un importe de " & dbl & "" & System.Threading.Thread.CurrentThread.CurrentCulture.NumberFormat.CurrencySymbol, MsgBoxStyle.Information)
        Me.btImport_Importa.Enabled = True
    End Sub

    Private Sub btImport_Importa_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btImport_Importa.Click
        Dim dbOrigen As gDevelop.Lite.m_database = New gDevelop.Lite.m_database(gDevelop.Lite.m_EnumTypes.DatabaseConnection.Access)
        dbOrigen.Database_SourceHost = Me.lblImporta_Ruta.Text
        dbOrigen.Database_Name = My.APP_DATABASE & ".mdb"
        If Not dbOrigen.Connect() Then
            MsgBox("Error al tratar de conectar con la base de datos.", MsgBoxStyle.Critical)
            Exit Sub
        End If

        Dim rstOrigen As ADODB.Recordset = Nothing, rstDestino As ADODB.Recordset = Nothing
        Dim rstOrigen_Lines As ADODB.Recordset = Nothing, rstDestino_Lines As ADODB.Recordset = Nothing
        Dim j As Integer = 0, n As Integer = 0

        rstDestino = My.m_db.GetRst("SELECT * FROM db_tickets WHERE id=-1")

        For i As Integer = 0 To Me.lstImporta.Items.Count - 1
            'Duplico tickets
            rstOrigen = dbOrigen.GetRst("SELECT * FROM db_tickets WHERE id=" & Me.lstImporta.Items(i).SubItems(1).Text)
            If Not rstOrigen.EOF Then
                'Duplico el ticket
                rstDestino.AddNew()
                For j = 1 To rstOrigen.Fields.Count - 1
                    rstDestino(rstOrigen.Fields(j).Name).Value = rstOrigen.Fields(j).Value
                Next
                rstDestino.Update()

                'Duplico las lineas del tickets
                rstOrigen_Lines = dbOrigen.GetRst("SELECT * FROM db_tickets_lines WHERE id_ticket=" & Me.lstImporta.Items(i).SubItems(1).Text)
                rstDestino_Lines = My.m_db.GetRst("SELECT * FROM db_tickets_lines WHERE id=-1")

                If Not rstOrigen_Lines.EOF Then
                    rstDestino_Lines.AddNew()
                    For j = 1 To rstOrigen_Lines.Fields.Count - 1
                        rstDestino_Lines(rstOrigen_Lines.Fields(j).Name).Value = rstOrigen_Lines.Fields(j).Value
                    Next
                    rstDestino_Lines("id_ticket").Value = rstDestino("id").Value
                    rstDestino_Lines.Update()

                    'Actualizo el almacen
                    If rstDestino_Lines("id_articulo").Value > 0 Then My.UpdateAlmacen(rstDestino_Lines("id_articulo").Value, rstDestino_Lines("ud").Value, rstDestino_Lines("tipo").Value)
                    If rstDestino_Lines("id_articulo_combina").Value > 0 Then My.UpdateAlmacen(rstDestino_Lines("id_articulo_combina").Value, rstDestino_Lines("ud").Value, rstDestino_Lines("tipo").Value)
                End If
                dbOrigen.CloseRst(rstOrigen_Lines)

                n += 1
            End If
            dbOrigen.CloseRst(rstOrigen)
        Next

        'Duplico las entradas
        rstOrigen = dbOrigen.GetRst("SELECT * FROM db_cajas_entradas WHERE id_caja=-1")
        rstDestino = My.m_db.GetRst("SELECT * FROM db_cajas_entradas WHERE id=-1")

        'Duplico las entradas
        For i As Integer = 0 To rstOrigen.RecordCount - 1
            rstDestino.AddNew()
            For j = 1 To rstOrigen.Fields.Count - 1
                rstDestino(rstOrigen.Fields(j).Name).Value = rstOrigen.Fields(j).Value
            Next
            rstDestino.Update()
        Next


        dbOrigen.Dispose()
        dbOrigen = Nothing


        MsgBox("Proceso de importación terminado." & vbCrLf & vbCrLf & "Importados " & n & " tickets.", MsgBoxStyle.Information)
        Me.lstImporta.Items.Clear()
    End Sub



    'Cambio de tarifa
    Private Sub txtIdTarifa_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtIdTarifa.TextChanged
        Me.cbTarifa.SelectedIndex = Val(Me.txtIdTarifa.Text)
    End Sub

    Private Sub cbTarifa_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbTarifa.SelectedIndexChanged
        Me.txtIdTarifa.Text = Me.cbTarifa.SelectedIndex
    End Sub

    Private Sub picFacturacionHelp_MouseDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs)
        Me.btSincronizaIVA.Visible = True
    End Sub

    Private Sub btSincronizaIVA_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btSincronizaIVA.Click
        If MsgBox("¿Esta seguro de que desea proceder a la sincronización de precios PVP?", MsgBoxStyle.Question + MsgBoxStyle.OkCancel) <> MsgBoxResult.Ok Then Exit Sub

        'Sincronizo artículos
        Dim str As String = ""

        str = "UPDATE db_articulos SET iva=" & Me.TxtIVA_General.Text.Replace(",", ".") & ",pvp=format(pvp_iva/" & My.GetMultiplicadorIVA(Me.TxtIVA_General.Text).ToString.Replace(",", ".") & ",'0.00#') WHERE iva=18 or iva=16"
        My.m_db.Execute(str)

        str = "UPDATE db_articulos SET iva=" & Me.TxtIVA_Medio.Text.Replace(",", ".") & ",pvp=format(pvp_iva/" & My.GetMultiplicadorIVA(Me.TxtIVA_Medio.Text).ToString.Replace(",", ".") & ",'0.00#') WHERE iva=8 or iva=7"
        My.m_db.Execute(str)

        str = "UPDATE db_articulos SET iva=" & Me.TxtIVA_Basico.Text.Replace(",", ".") & ",pvp=format(pvp_iva/" & My.GetMultiplicadorIVA(Me.TxtIVA_Basico.Text).ToString.Replace(",", ".") & ",'0.00#') WHERE iva=4"
        My.m_db.Execute(str)


        'My.m_db.Execute("UPDATE db_articulos SET iva=" & Me.TxtIVA_General.Text.Replace(",", ".") & " WHERE iva=" & My.m_opt.IVA_Medio)
        'My.m_db.Execute("UPDATE db_articulos SET iva=" & Me.TxtIVA_General.Text.Replace(",", ".") & " WHERE iva=" & My.m_opt.IVA_Basico)


        MsgBox("Proceso terminado!", MsgBoxStyle.Information)
    End Sub

    Private Sub ChkLector_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChkLector.CheckedChanged
        Me.PnlLector.Enabled = Me.ChkLector.Checked
    End Sub







#Region "Idioma"
    Private Sub rbtPais_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbtPais_ESES.CheckedChanged, rbtPais_FRFR.CheckedChanged, rbtPais_ESMX.CheckedChanged, rbtPais_ESGA.CheckedChanged
        If Not CType(sender, RadioButton).Checked Then Exit Sub

        Dim str As String = "es-ES"
        Select Case True
            Case sender Is Me.rbtPais_ESES : str = "es-ES"
            Case sender Is Me.rbtPais_ESMX : str = "es-MX"
            Case sender Is Me.rbtPais_ESGA : str = "gl-ES"

            Case sender Is Me.rbtPais_FRFR : str = "fr-FR"
        End Select

        'Me.rbtPais_ESES.Checked = False
        'Me.rbtPais_ESMX.Checked = False
        'Me.rbtPais_ESGA.Checked = False
        'Me.rbtPais_FRFR.Checked = False



        'Cambio idioma
        System.Threading.Thread.CurrentThread.CurrentCulture = New System.Globalization.CultureInfo(str)
        System.Threading.Thread.CurrentThread.CurrentUICulture = New System.Globalization.CultureInfo(str)


        'Establezco el idioma por defecto
        My.m_app.SetValue("lng") = str

        'Aplico el idioma
        Me.AplicarIdioma()

        'Establezco valores
        'CType(sender, RadioButton).Checked = True

    End Sub

    'Función para establecer el idioma
    Private Sub AplicarIdioma()

    End Sub
#End Region

    Private Sub frmConfigure_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyValue = Keys.Escape Then Me.Close()
    End Sub






    ' OPCIONES activadas (Registrado unas vs )
    Private Sub checkState(ByVal state As Boolean)
        Me.txtCIF.Enabled = state
        Me.txtNameFiscal.Enabled = state
        Me.txtNameComercial.Enabled = state
        Me.TxtTicket_Cab1.Enabled = state
        Me.TxtTicket_Cab2.Enabled = state
        Me.TxtTicket_Cab3.Enabled = state
        Me.TxtTicket_Cab4.Enabled = state

        Me.CbCompatibilidad.Visible = state
        Me.lblCompatibilidad.Visible = state
        Me.groupIVA.Enabled = state

        Me.pnlActionsOrginacion.Enabled = state
    End Sub

    Private Sub btUnlockTicket_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btUnlockTicket.Click
        Dim idUsr As Integer = My.IdentificaUser(True)
        If idUsr <> -7 Then Exit Sub


        'Activamos TODO
        Me.checkState(True)
        MsgBox("Activado modo admin", MsgBoxStyle.Information)
    End Sub



End Class