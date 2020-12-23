Public Class frmMain

#Region "Funciones"
    Private Sub LoadInfo()
        Dim n As Integer = 0
        Dim rst As ADODB.Recordset, rstAux As ADODB.Recordset

        '### Si la aplicacion no esta registrada 
        If Not My.m_app.IsRegister AndAlso DateDiff(DateInterval.Day, My.m_app.GetDate_AppCode, Now) >= 7 Then
            Me.PnlDemo.Visible = Not My.m_app.IsRegister
            Me.LblDemoTime.Text = "Quedan " & DateDiff(DateInterval.Day, Now, My.m_app.GetDate_AppCode.AddDays(gDevelop.Lite.m_app.DAYS_EXPIRE)) & " días para que caduque el código de aplicación."
        End If



        '### Cargo datos del DISTRIBUIDOR
        rst = My.m_db.GetRst("SELECT * FROM app_distribuidor")
        If rst("swshow").Value Then
            Me.PicLogo.Image = My.m_db.data_GetImgRow(rst("img"))
            Me.LblDistribuidor_www.Text = rst("www").Value
            Me.LblDistribuidor_tlf.Text = rst("tlf").Value & ""
        End If
        My.m_db.CloseRst(rst)



        '### Obtengo información sobre la CAJA
        Me.LblInformation.Text = ""
        rst = My.m_db.GetRst("SELECT count(id) as n_tot FROM db_tickets WHERE id_caja=-1 AND id_user<>-3")
        Me.LblInformation.Text &= "Actualmente, se han realizado un total de " & rst("n_tot").Value & " tickets."
        My.m_db.CloseRst(rst)



        '### Obtengo información sobre las RESERVAS
        Me.LblReservas.Text = ""

        '#El dia de hoy
        rst = My.m_db.GetRst("SELECT id FROM db_reservas WHERE fh_reserva=#" & Now.ToString("yyyy-MM-dd") & "#")
        If rst.RecordCount > 0 Then
            Me.LblReservas.Text &= "Para Hoy tenemos " & rst.RecordCount & " reservas"
            n = 0

            'Obtengo el nº de menus
            While Not rst.EOF
                rstAux = My.m_db.GetRst("SELECT sum(ud) as tot FROM db_reservas_menu WHERE id_reserva=" & rst("id").Value)
                If Not IsDBNull(rstAux("tot").Value) Then n += rstAux("tot").Value
                rst.MoveNext()
            End While
            If n > 0 Then Me.LblReservas.Text &= " con " & n & " menus"
            If n > 0 Then Me.LblReservas.Text &= "." & vbCrLf
        End If
        My.m_db.CloseRst(rst)


        '#Mañana
        rst = My.m_db.GetRst("SELECT id FROM db_reservas WHERE fh_reserva=#" & Now.AddDays(1).ToString("yyyy-MM-dd") & "#")
        If rst.RecordCount > 0 Then
            Me.LblReservas.Text &= IIf(Me.LblReservas.Text.Length > 0, vbCrLf, "") & "Mañana tenemos " & rst.RecordCount & " reservas"
            n = 0

            'Obtengo el nº de menus
            While Not rst.EOF
                rstAux = My.m_db.GetRst("SELECT sum(ud) as tot FROM db_reservas_menu WHERE id_reserva=" & rst("id").Value)
                If Not IsDBNull(rstAux("tot").Value) Then n += rstAux("tot").Value
                rst.MoveNext()
            End While
            If n > 0 Then Me.LblReservas.Text &= " con " & n & " menus"
            If n > 0 Then Me.LblReservas.Text &= "." & vbCrLf
        End If
        My.m_db.CloseRst(rst)


        '#La semana que viene
        rst = My.m_db.GetRst("SELECT id FROM db_reservas WHERE fh_reserva>=#" & Now.AddDays(1).ToString("yyyy-MM-dd") & "# AND  fh_reserva<=#" & Now.AddDays(8).ToString("yyyy-MM-dd") & "#")
        If rst.RecordCount > 0 Then
            Me.LblReservas.Text &= IIf(Me.LblReservas.Text.Length > 0, vbCrLf, "") & "Para los próximos 7 días tenemos previstos un total de  " & rst.RecordCount & " reservas"
            n = 0

            'Obtengo el nº de menus
            While Not rst.EOF
                rstAux = My.m_db.GetRst("SELECT sum(ud) as tot FROM db_reservas_menu WHERE id_reserva=" & rst("id").Value)
                If Not IsDBNull(rstAux("tot").Value) Then n += rstAux("tot").Value
                rst.MoveNext()
            End While
            If n > 0 Then Me.LblReservas.Text &= " con " & n & " menus"
            If n > 0 Then Me.LblReservas.Text &= "." & vbCrLf
        End If
        My.m_db.CloseRst(rst)


        '#Si no tiene reservas previstas en los 7 siguientes dias, compruebo el mes
        If Me.LblReservas.Text.Length <= 0 Then
            'El mes que viene
            rst = My.m_db.GetRst("SELECT id FROM db_reservas WHERE fh_reserva>=#" & Now.ToString("yyyy-MM-dd") & "# AND  fh_reserva<=#" & Now.AddMonths(1).ToString("yyyy-MM-dd") & "#")
            If rst.RecordCount > 0 Then
                Me.LblReservas.Text &= IIf(Me.LblReservas.Text.Length > 0, vbCrLf, "") & "Para el próximo mes tenemos previstos un total de  " & rst.RecordCount & " reservas"
                n = 0

                'Obtengo el nº de menus
                While Not rst.EOF
                    rstAux = My.m_db.GetRst("SELECT sum(ud) as tot FROM db_reservas_menu WHERE id_reserva=" & rst("id").Value)
                    If Not IsDBNull(rstAux("tot").Value) Then n += rstAux("tot").Value
                    rst.MoveNext()
                End While
                If n > 0 Then Me.LblReservas.Text &= " con " & n & " menus"
                If n > 0 Then Me.LblReservas.Text &= "." & vbCrLf
            End If
            My.m_db.CloseRst(rst)

            'Si no hay reservas en el proximo mes, muestro información por defecto
            If Me.LblReservas.Text.Length <= 0 Then
                Me.LblReservas.Text = "Sin Reservas ni eventos previstos en el próximo mes."
                Me.LblReservas.Font = New Font("Tahoma", 8)
            End If
        End If


        'Varios
        Me.LblApp_Version.Text = My.m_opt.modo_compatibilidad & " - Versión " & My.Application.Info.Version.Major & "." & My.Application.Info.Version.Minor & "." & My.Application.Info.Version.Build & " (CodeName """ & My.APP_CODENAME & """)"


        If My.m_app.GetAppMode = gDevelop.Lite.m_DataTypes.m_AppModo.Cliente Then
            Me.BtTickets.Visible = False
            Me.BtFacturas.Visible = False

            Me.BtFamalias.Visible = False
            Me.BtClientes.Visible = False
            Me.BtProveedores.Visible = False
            Me.BtUsers.Visible = False

            Me.groupVarios.Visible = False
            Me.PnlButtons_Config.Visible = False
        End If



    End Sub
#End Region

#Region "Eventos Principales"
    Private Sub FrmMain_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Si tiene un fichero de nombre tickets.bat en el directorio de la aplición lo ejecuto (para montar la impresora)
        If IO.File.Exists(My.Application.Info.DirectoryPath & "\tickets.bat") Then Shell(My.Application.Info.DirectoryPath & "\tickets.bat", AppWinStyle.NormalFocus, True)


        Me.AplicarIdioma()

        Me.picFlag.Image = Me.imgFlags.Images(0)

        With Me
            'Establezco información
            .Text = My.APP_NAME
            .LblTitle.Text = My.APP_NAME & "  [" & My.Application.Info.Version.Major & "." & My.Application.Info.Version.Minor & "." & My.Application.Info.Version.Build & "]"
            '.LblSubTitle.Text = "Versión " & My.Application.Info.Version.ToString '& " bajo el CodeName """ & My.APP_CODENAME & """"
            .LblApp_Version.Text = My.m_opt.modo_compatibilidad & " - Versión " & My.Application.Info.Version.Major & "." & My.Application.Info.Version.Minor & "." & My.Application.Info.Version.Build & " (CodeName """ & My.APP_CODENAME & """)"


            .LblInfo.Text = "Con """ & My.APP_NAME & """ desde " & My.m_app.GetDate_AppCode & " - " & My.m_app.GetValue("local_mdb")
            .LblInfo.Text = "gTPV.v2 - " & My.Application.arrVersiones(My.m_app.GetAppSabor) & " [" & My.Application.arrTipo(My.m_app.GetAppMode).Substring(0, 1) & "]"

            .LblCode.Text = "Código de aplicación: " & My.m_app.GetAppcode

            'Centro el body y establezco tamaños
            .PnlBody.Left = (Me.Width - Me.PnlBody.Width) / 2
            .PnlBody.Top = (Me.SplitContainer.Panel2.Height - Me.PnlBody.Height) / 2 + (IIf(My.m_opt.swNoteBook, Me.SplitContainer.Panel1.Height, 0))
            .PnlBody.Visible = True
            .Size = Screen.PrimaryScreen.WorkingArea.Size

            'Limpio valores
            '.LblDistribuidor_www.Text = ""
            '.LblDistribuidor_tlf.Text = ""
        End With

        Me.LoadInfo()

        Me.AddHandlers()

        'Si es modo caja directa no permito modificar el diseño
        Me.BtDesign.Enabled = Not My.m_opt.cajadirecta


        'Me.btPedidos.Visible = (My.m_opt.modo_compatibilidad = "ESTANDAR") Or (My.m_opt.modo_compatibilidad = "HOSTELERIA") Or (My.m_opt.modo_compatibilidad = "REPARTO")
        Me.btEstancos.Visible = (My.m_opt.modo_compatibilidad = "ESTANCO")

        'Me.btEtiquetas.Visible = (My.m_opt.modo_compatibilidad = "COMERCIO")

        ''Botones de configuración
        'Me.BtConfiguration.Enabled = False
        'Me.BtListados.Enabled = False
        'Me.BtDesign.Enabled = False
        'Me.BtNotas.Enabled = True

        'Me.BtFacturas.Enabled = False
        'Me.BtUsers.Enabled = False
        'Me.BtClientes.Enabled = False
        'Me.BtFamalias.Enabled = False
        'Me.BtTickets.Enabled = False
        'Me.BtCompras.Enabled = False
        'Me.BtProveedores.Enabled = False

        'Me.BtArticulos.Enabled = False
        ''Me.BtTickets.Enabled = (rst("tipo_user").Value = "ENCARGADO")
        'Me.BtFacturas.Enabled = False

        Me.btPedidos.Visible = False

        'Si esta establecido el modo seguro, dependiendo de los privilegios del usuario activo o desactivo opciones
        If My.m_opt.modo_seguro Then
            Dim rst As ADODB.Recordset = My.m_db.GetRst("SELECT tipo_user FROM db_usuarios WHERE id=" & My.AppIdUser)
            If My.AppIdUser = 0 OrElse My.AppIdUser = -3 Then Exit Sub
            If rst.RecordCount = 0 Then Exit Sub
            Select Case rst("tipo_user").Value
                Case "MAESTRO"
                    Me.BtConfiguration.Enabled = True

                Case "ADMINISTRADOR"
                    Me.BtFacturas.Enabled = False
                    Me.BtUsers.Enabled = False

                    'Botones de configuración
                    Me.BtConfiguration.Enabled = False
                    Me.BtListados.Enabled = False
                    Me.BtDesign.Enabled = False
                    Me.BtNotas.Enabled = True


                Case Else
                    'Botones de configuración
                    Me.BtConfiguration.Enabled = False
                    Me.BtListados.Enabled = False
                    Me.BtDesign.Enabled = False
                    Me.BtNotas.Enabled = True

                    Me.BtFacturas.Enabled = False
                    Me.BtUsers.Enabled = False
                    Me.BtClientes.Enabled = False
                    Me.BtFamalias.Enabled = False
                    Me.BtTickets.Enabled = False
                    Me.BtCompras.Enabled = False
                    Me.BtProveedores.Enabled = False

                    Me.BtArticulos.Enabled = (rst("tipo_user").Value = "ENCARGADO")
                    'Me.BtTickets.Enabled = (rst("tipo_user").Value = "ENCARGADO")
                    Me.BtFacturas.Enabled = (rst("tipo_user").Value = "ENCARGADO")

                    'Me.PnlButtons_Gestion.Enabled = False


            End Select
            'If My.m_app.GetValue("modo_db") = 0 Then

            'Else

            'End If
        End If



        'Aplico el idioma
        Me.AplicarIdioma()
    End Sub

    Private Sub FrmMain_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        If Not IsNothing(frm_AppIsMinimized) Then frm_AppIsMinimized.Close()
        If Not IsNothing(m_Shell) Then
            My.Forms.m_Shell.Activate()
            My.Forms.m_Shell.WindowState = FormWindowState.Maximized
        End If
    End Sub
#End Region

#Region "Manejadores"
    'Manejador Principal (Shell)
    Private Sub ShellApp(ByVal app_form As String, Optional ByVal action As String = "")
        Dim app As String = app_form.ToUpper

        'Antes de iniciar cualquier opcion compruebo si la demo es valida (fix change fh)

        Select Case app
            Case "USERS"
                'Compruebo si tengo control de acceso
                If My.m_opt.modo_seguro_secciones Then

                    Dim idUser As Integer = My.IdentificaUser()
                    'My.ValidateUser(False, True)
                    If idUser <= 0 Then Exit Sub

                    If Not (idUser = -3 OrElse idUser = 99) Then
                        Dim rst As ADODB.Recordset = My.m_db.GetRst("SELECT tipo_user FROM db_usuarios WHERE id=" & idUser)

                        If Not rst("tipo_user").Value = "MAESTRO" AndAlso Not rst("tipo_user").Value = "ADMINISTRADOR" Then
                            MsgBox("SECCIÓN NO permitida por tipo de usuario.", MsgBoxStyle.Critical)
                            Exit Sub
                        End If
                        My.m_db.CloseRst(rst)
                    End If
                End If
                If Not m_Shell.ConfigureApp(app) Then Exit Select

                'Asigno manejadores
                AddHandler m_Shell.KeyDown, AddressOf form_KeyDown

                m_Shell.Show(Me)


            Case "CLIENTES", "PROVEEDORES", "CATEGORIAS", "ARTICULOS"                        'Formularios Estandar
                If Not m_Shell.ConfigureApp(app) Then Exit Select

                'Asigno manejadores
                AddHandler m_Shell.KeyDown, AddressOf form_KeyDown

                m_Shell.Show(Me)

            Case "PEDIDOS"
                'Compruebo si hay usuarios marcados para el reparto
                Dim rst As ADODB.Recordset = Nothing
                rst = My.m_db.GetRst("SELECT id FROM db_usuarios WHERE swRepartidor=TRUE")
                If rst.RecordCount = 0 Then
                    MsgBox("No se ha establecido ningun empleado como repartidor, establezca uno para poder continuar.", MsgBoxStyle.Critical)
                    My.m_db.CloseRst(rst)
                    Exit Sub
                End If
                My.m_db.CloseRst(rst)

                'Muestro pedidos
                frmPedidos.ShowDialog()
                frmPedidos.Dispose()

                'Recargo información sobre el nº de tickets
                Me.LoadInfo()


            Case "ESTANCO"
                'Muestro pedidos
                frmEstanco.ShowDialog()
                frmEstanco.Dispose()

                'Recargo información sobre el nº de tickets
                Me.LoadInfo()

            Case "RUNTPV"                      'Inicio el panel de ventas
                'SI tiene habilitado la conexion remota con tarjetas
                If My.m_opt.lector_sw Then
                    My.m_db_mysql = New MySql.Data.MySqlClient.MySqlConnection("Database=" & My.m_opt.mysql_db & ";Data Source=" & My.m_opt.mysql_host & ";User Id=" & My.m_opt.mysql_user & ";Password=" & My.m_opt.mysql_pass)
                    Try
                        My.m_db_mysql.Open()
                    Catch ex As Exception
                        MsgBox("Error al tratar de conectar con el Host remoto. Los motivos son: " & vbCrLf & ex.Message & vbCrLf & vbCrLf & "Se continuara pero sin la opción de cobro con tarjeta.", MsgBoxStyle.Critical)
                        My.m_opt.lector_sw = False
                    End Try

                End If

                If Not My.RunPaneldeVentas() Then Exit Select

                If My.m_opt.lector_sw AndAlso Not IsNothing(My.m_db_mysql) Then
                    My.m_db_mysql.Close()
                    My.m_db_mysql = Nothing
                End If

                'Recargo información sobre el nº de tickets
                Me.LoadInfo()

            Case "VALIDAR"
                frmRegisterApp.ShowDialog()

                'Si el codigo no es valido, cancelo el inicio de la aplicacion
                If frmRegisterApp.DialogResult <> Windows.Forms.DialogResult.OK Then Exit Select
                Me.PnlDemo.Visible = False

                'Recargo información sobre el nº de tickets
                Me.LoadInfo()

            Case "COMPRAS"
                'If Not m_Shell.ConfigureApp("albaranes_compra") Then Exit Select
                ''Asigno manejadores
                'AddHandler m_Shell.KeyDown, AddressOf form_KeyDown
                'm_Shell.Show(Me)

                Dim frmCompra As New frmAlbaranesCompras
                frmCompra.ShowDialog(Me)
                frmCompra.Dispose()


                ''Muestro el formulario de facturar
                'frmCompras_SelectProv.IdRef = 0
                'frmCompras_SelectProv.ConfigureApp("proveedores")
                'frmCompras_SelectProv.ShowDialog(Me)
                'If frmPaneldeVentas_Facturar.DialogResult = Windows.Forms.DialogResult.OK Then
                '    'Actualizo los estados
                '    Me.swKill = True
                '    Me.DialogResult = Windows.Forms.DialogResult.OK
                'End If
                'frmPaneldeVentas_Facturar.Dispose()

            Case "DESIGN"
                ' Diseño del local
                Dim frmCr As New frmDesign
                frmCr.ShowDialog(Me)
                frmCr.Dispose()
                frmCr = Nothing

            Case "FACTURACION"
                'Compruebo si tengo control de acceso
                If My.m_opt.modo_seguro_secciones Then
                    Dim idUser As Integer = My.IdentificaUser()
                    If idUser <= 0 Then Exit Sub
                    If Not (idUser = -3 OrElse idUser = 99) Then
                        Dim rst As ADODB.Recordset = My.m_db.GetRst("SELECT tipo_user FROM db_usuarios WHERE id=" & idUser)

                        If Not rst("tipo_user").Value = "MAESTRO" AndAlso Not rst("tipo_user").Value = "ADMINISTRADOR" Then
                            MsgBox("SECCIÓN NO permitida por tipo de usuario.", MsgBoxStyle.Critical)
                            Exit Sub
                        End If
                        My.m_db.CloseRst(rst)
                    End If
                End If


                Dim frmFact As New frmFacturacion
                frmFact.ShowDialog(Me)
                frmFact.Dispose()

            Case "CAJAS"
                    'Compruebo si tengo control de acceso
                    If My.m_opt.modo_seguro_secciones Then
                        Dim idUser As Integer = My.IdentificaUser()
                        If idUser <= 0 Then Exit Sub
                    If Not (idUser = -3 OrElse idUser = 99) Then
                        Dim rst As ADODB.Recordset = My.m_db.GetRst("SELECT tipo_user FROM db_usuarios WHERE id=" & idUser)

                        If Not rst("tipo_user").Value = "MAESTRO" AndAlso Not rst("tipo_user").Value = "ADMINISTRADOR" Then
                            MsgBox("SECCIÓN NO permitida por tipo de usuario.", MsgBoxStyle.Critical)
                            Exit Sub
                        End If
                        My.m_db.CloseRst(rst)
                    End If
                End If

                Dim frmCaja As New frmCajas
                frmCaja.ShowDialog(Me)
                frmCaja.Dispose()

                Me.LoadInfo()

            Case "AGENDA"
                    Dim frmCr As New frmReservas
                    frmCr.ShowDialog(Me)
                    frmCr.Dispose()

                    Me.LoadInfo()

            Case "LISTADOS"
                    'Compruebo si tengo control de acceso
                    If My.m_opt.modo_seguro_secciones Then
                        Dim idUser As Integer = My.IdentificaUser()
                        If idUser <= 0 Then Exit Sub
                    If Not (idUser = -3 OrElse idUser = 99) Then
                        Dim rst As ADODB.Recordset = My.m_db.GetRst("SELECT tipo_user FROM db_usuarios WHERE id=" & idUser)

                        If Not rst("tipo_user").Value = "MAESTRO" AndAlso Not rst("tipo_user").Value = "ADMINISTRADOR" Then
                            MsgBox("SECCIÓN NO permitida por tipo de usuario.", MsgBoxStyle.Critical)
                            Exit Sub
                        End If
                        My.m_db.CloseRst(rst)
                    End If
                End If

                ''Compruebo si tengo control de acceso
                'If My.m_opt.modo_seguro_secciones Then
                '    Dim idUser As Integer = My.IdentificaUser()
                '    If idUser <= 0 Then Exit Sub

                '    Dim rst As ADODB.Recordset = My.m_db.GetRst("SELECT tipo_user FROM db_usuarios WHERE id=" & idUser)

                '    If Not rst("tipo_user").Value = "MAESTRO" AndAlso Not rst("tipo_user").Value = "ADMINISTRADOR" Then
                '        MsgBox("SECCIÓN NO permitida por tipo de usuario.", MsgBoxStyle.Critical)
                '        Exit Sub
                '    End If
                '    My.m_db.CloseRst(rst)

                'End If

                Dim frmCr As New frmGestion
                AddHandler frmCr.KeyDown, AddressOf form_KeyDown
                frmCr.ShowDialog(Me)
                frmCr.Dispose()

            Case "CONFIGURE"
                    'Compruebo si tengo control de acceso
                    If My.m_opt.modo_seguro_secciones Then
                        Dim idUser As Integer = My.IdentificaUser()
                        If idUser <= 0 Then Exit Sub

                    If Not (idUser = -3 OrElse idUser = 99) Then
                        Dim rst As ADODB.Recordset = My.m_db.GetRst("SELECT tipo_user FROM db_usuarios WHERE id=" & idUser)

                        If Not rst("tipo_user").Value = "MAESTRO" AndAlso Not rst("tipo_user").Value = "ADMINISTRADOR" Then
                            MsgBox("SECCIÓN NO permitida por tipo de usuario.", MsgBoxStyle.Critical)
                            Exit Sub
                        End If
                        My.m_db.CloseRst(rst)
                    End If
                End If

                Dim frmCfg As New frmConfigure
                frmCfg.ShowDialog(Me)
                frmCfg.Dispose()

                ' Para bien o para mal, recargo valores de configuracion de la aplicacion
                My.LoadAppConfig()
                My.Load_OptionsHardware()

                'Aplico el idioma
                Me.AplicarIdioma()

                Me.LoadInfo()

            Case "CBARRAS"
                frmCodBarras.ShowDialog(Me)
                frmCodBarras.Dispose()
                frmCodBarras = Nothing

            Case "HELP"
                    'My.ShellExecute(Me.Handle.ToInt32, "OPEN", "http://software.gdevelop.es/gtpv/", Nothing, Nothing, 0)
                    Shell("help.exe", AppWinStyle.NormalFocus)

            Case "WIZARD"
                    Me.Visible = False

                    Dim frm As New frmWizard_Configure
                    frm.ShowDialog()
                    If frm.DialogResult <> Windows.Forms.DialogResult.OK Then
                        frm.Dispose()
                        Me.Visible = True
                        Exit Sub
                    End If
                    MsgBox("Es necesario necesario volver a iniciar la aplicación para cargar los nuevos cambios.", MsgBoxStyle.Information)
                    End

            Case "MINIMIZE"
                    frm_AppIsMinimized.Show()

                    Me.WindowState = FormWindowState.Minimized

            Case "CLOSE"
                    Me.Close()
            Case Else
                    MsgBox(app)
        End Select
    End Sub
#End Region

#Region "Manejadores de Eventos de formularios"
    'Funcin que me asigna los eventos y manejadores de los formularios
    Private Sub AddHandlers()
        'Manejadores del formulario de inicio
        AddHandler Me.KeyDown, AddressOf form_KeyDown
    End Sub

    Private Sub form_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        Select Case True
            Case sender Is m_Shell
                If Not m_KeyBoard Is Nothing Then
                    m_KeyBoard.Dispose()
                    Exit Sub
                End If
                'm_Shell.Close()

        End Select
        If e.KeyCode = Keys.Escape Then CType(sender, Form).Close()
    End Sub
#End Region

#Region "Eventos Auxiliares"
    Private Sub Buttons_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtArticulos.Click, BtUsers.Click, BtTickets.Click, BtProveedores.Click, BtMin.Click, BtListados.Click, BtGooo.Click, BtFamalias.Click, BtFacturas.Click, BtDesign.Click, BtConfiguration.Click, BtClose.Click, BtClientes.Click, BtHelp.Click, BtNotas.Click, BtUpdatePVPs.Click, BtValidar.Click, BtCompras.Click, btPedidos.Click, btWizard.Click, btEstancos.Click, btEtiquetas.Click
        'Si no tiene establecido el tag mando un error
        If IsNothing(CType(sender, Button).Tag) OrElse CType(sender, Button).Tag.ToString.Length = 0 Then
            My.m_msg.MessageError(sender, "Tag de control de elemento no referenciado")
            Exit Sub
        End If

        ShellApp(CType(sender, Button).Tag.ToString)
    End Sub

    Private Sub FrmMain_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If MsgBox("¿Esta seguro de que deséa finalizar " & My.APP_NAME & "?", MsgBoxStyle.OkCancel + MsgBoxStyle.Question, My.APP_NAME) <> MsgBoxResult.Ok Then e.Cancel = True
    End Sub

    Private Sub LblEgg_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles LblEgg.DoubleClick
        Me.PnlEgg.Visible = True
        Me.TmrEgg.Enabled = True

        My.swEgg = True

        If Not IO.File.Exists(My.Computer.FileSystem.SpecialDirectories.CurrentUserApplicationData & "\gdv") Then
            IO.File.Create(My.Computer.FileSystem.SpecialDirectories.CurrentUserApplicationData & "\gdv")
        End If

    End Sub

    Private Sub TmrEgg_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TmrEgg.Tick
        Me.LblEggText.ForeColor = IIf(Me.LblEggText.ForeColor = Color.Black, Color.DimGray, Color.Black)
    End Sub
#End Region

    Public Sub New()

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

    End Sub

    Private Sub BtKeyBoard_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtKeyBoard.Click
        'Static handle As Long = 0
        'Dim p As Process = Process.Start("osk.exe")
        ''Activo la ventana
        'If handle <> 0 Then My.SetForegroundWindow(handle)

        'handle = p.Handle.ToInt32

        ''SetForegroundWindow

        My.ShellExecute(0, "OPEN", "osk.exe", Nothing, Nothing, 9)
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        MsgBox("click")
        'If DateDiff(DateInterval.Second, _TimePress, Now) >= 1 Then
        '    MsgBox("more 2" & Me._nPress)
        'Else
        '    MsgBox("click go: " & _TimePress & " - " & Now & " " & Me._nPress)
        'End If
    End Sub

    Private _btPress As Button = Nothing
    Private _tmrPress As Timer = Nothing
    Private _nPress As Integer = 0

    'Private _TimePress As Date

    Private Sub Button1_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Button1.MouseDown
        'Inicializo valores del toque
        'Me._TimePress = Now
        Me._btPress = CType(sender, Button)
        Me._nPress = 0

        'Inicializo el contador de tiempo
        Me._tmrPress = New Timer
        AddHandler _tmrPress.Tick, AddressOf tmrPress_Tick
        Me._tmrPress.Interval = 450
        Me._tmrPress.Enabled = True
    End Sub

    Private Sub tmrPress_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me._nPress += 1

        If Me._nPress >= 2 Then
            Me._tmrPress.Dispose()
            Me.Button1_Click(Me._btPress, New System.EventArgs)
        End If
    End Sub





#Region "Idioma"
    'Función para establecer el idioma
    Private Sub AplicarIdioma()
        'Segun el idioma cargo la bandera del pais
        Dim str As String = My.m_app.GetValue("lng", "es-ES")
        Dim idFlag As Integer = 0
        Select Case str.ToUpper
            Case "ES-ES" : idFlag = 0
            Case "GL-ES" : idFlag = 1
            Case "FR-FR" : idFlag = 2
            Case "ES-MX" : idFlag = 3

        End Select
        Me.picFlag.Image = Me.imgFlags.Images(idFlag)


        '    Case sender Is Me.btChangeLenguaje_ESAN : str = "an-ES"
        '    Case sender Is Me.btChangeLenguaje_ESES : str = "es-ES"
        '    Case sender Is Me.btChangeLenguaje_ESMX : str = "es-MX"
        '    Case sender Is Me.btChangeLenguaje_ESGA : str = "gl-ES"

        '    Case sender Is Me.btChangeLenguaje_FRFR : str = "fr-FR"
        'End Select

    End Sub
#End Region

    Private Sub picTrilce_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles picTrilce.DoubleClick

        frmRegisterApp.ShowDialog()
    End Sub


End Class