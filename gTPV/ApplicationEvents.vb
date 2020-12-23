Namespace My
    Partial Friend Class MyApplication
        'Ruta de la base de datos
        Public app_Path As String = ""
        'El id de la base de datos de APP
        Public app_ID As Integer = 0

        'Modo de depuración de aplicación
        Public swDebug As Boolean = False
        Public swNotRPT As Boolean = True               ' Impresión por codigos de ESC

        'Cashlogic
        Public sckCashlogy As System.Net.Sockets.TcpClient
        Public sIOCashlogy As System.Net.Sockets.NetworkStream
        Public WithEvents tmrCashlogy As System.Windows.Forms.Timer

        Public cashlogy_bytes() As Byte = Nothing
        Public cashlogy_sCadena As String



        Public arrSoft() As String = New String() {"PYMEGEST.V3", "GTPV.V2", "GSAD.V2", "GRUTAMAHI.V2", "OTHERS"}
        Public arrTipo() As String = New String() {"SERVIDOR", "CLIENTE", "TERMINAL", "PLUS", "ANONYMOUS", "MONTH"}
        Public arrVersiones() As String = New String() {"NINGUNO", "ESTANDAR", "LITE", "COMERCIO", "STECNICO", "MAYORISTA", "PELUQUERIA", "HERMANDADES", "TALLERES", "ACADEMIAS", "CONTABILIDAD", "FACTURACION", "REALSTATE", "ENTRADAS", "OTROS", "GDV"}

        'Inicio la aplicacion
        Private Sub MyApplication_Startup(ByVal sender As Object, ByVal e As Microsoft.VisualBasic.ApplicationServices.StartupEventArgs) Handles Me.Startup

            'Compruebo si he habilitado la opción de depuración de errores
            If My.Application.CommandLineArgs.Count > 0 AndAlso My.Application.CommandLineArgs(0).ToUpper = "-DEBUG" Then
                Me.swDebug = True
                MsgBox("debug ON", MsgBoxStyle.Information)
            End If


            ' Requisitos minimos para poder iniciar: resolucion
            If Me.swDebug Then MsgBox("Requisitos mínimos")
            If (Screen.PrimaryScreen.Bounds.Width < 1024 OrElse Screen.PrimaryScreen.Bounds.Height < 768) AndAlso Not (Screen.PrimaryScreen.Bounds.Width = 1024 AndAlso Screen.PrimaryScreen.Bounds.Height = 600) Then MsgBox("El Software '" & My.APP_NAME & "' esta desarrollado y diseñado para trabajar en una resolucion mínima de '1024x768', cambie la configuración de la pantalla para poder iniciar", MsgBoxStyle.Critical) : e.Cancel = True

            Dim swFirst As Boolean = False

            'Inicializo clase de mensajes
            If Me.swDebug Then MsgBox("m_msg")
            m_msg = New gDevelop.Lite.m_msg

            Try
                ' Inicializamos la clase de valores locales de la aplicacion
                My.m_app = New gDevelop.Lite.m_app

                If Me.swDebug Then MsgBox("Activar versión demo")
                My.m_app.WithVersionDemo = True                ' Limitado a version de prueba

            Catch ex As Exception
                If Me.swDebug Then MsgBox("Se ha producido un error al arrancar m_msg")
                If Err.Number = 21 Then             'Version demo caducada
                    If Me.swDebug Then MsgBox("Versión caducada")

                    If IO.File.Exists(My.Computer.FileSystem.SpecialDirectories.CurrentUserApplicationData & "\gdv") Then Exit Try


                    My.m_msg.MessageError(Me, Err.Description)
                    frmRegisterApp.ShowDialog()

                    'Si el codigo no es valido, cancelo el inicio de la aplicacion
                    If frmRegisterApp.DialogResult <> DialogResult.OK Then e.Cancel = True : Exit Sub
                Else
                    My.m_msg.MessageError(Me, Err.Description, True)
                    e.Cancel = True
                    Exit Sub
                End If
            End Try

            ''Abro base de datos de configuracion de Empresa/Aplicación
            'If Me.swDebug Then MsgBox("Abro app.db")
            'My.m_db_app = New gDevelop.Lite.m_database(gDevelop.Lite.m_EnumTypes.DatabaseConnection.Access)
            'My.m_db_app.Database_SourceHost = My.Application.Info.DirectoryPath
            'My.m_db_app.Database_Name = My.APP_DATABASE_CFG

            'If Not My.m_db_app.Connect() Then
            '    e.Cancel = True
            '    End
            'End If



            ''Compruebo si tiene multiple empresa
            'If Me.swDebug Then MsgBox("Multiple empresa")
            'Dim rst As ADODB.Recordset = My.m_db_app.GetRst("SELECT * FROM app ORDER BY name ASC")
            'If rst.RecordCount > 1 Then

            '    'Selecciono la base de datos
            '    frmSeleccionaDB.ShowDialog()
            '    If frmSeleccionaDB.DialogResult <> DialogResult.OK Then
            '        frmSeleccionaDB.Dispose()
            '        End
            '    End If
            '    app_ID = frmSeleccionaDB.idDB
            '    frmSeleccionaDB.Dispose()
            '    frmSeleccionaDB = Nothing

            'ElseIf rst.RecordCount = 1 Then
            '    app_ID = rst("id").Value
            'Else
            '    MsgBox("No se ha encontrada ninguna confiración de empresa, imposible continuar.", MsgBoxStyle.Critical)
            '    End
            'End If
            'My.m_db_app.CloseRst(rst)

            ''Obtengo la ruta de la base de datos
            'If Me.swDebug Then MsgBox("Compruebo ruta de la base de datos")
            'rst = My.m_db_app.GetRst("SELECT * FROM app WHERE id=" & app_ID)
            'If rst.EOF Then
            '    MsgBox("Error localizando registro de aplicación.", MsgBoxStyle.Critical)
            '    Exit Sub
            'End If
            'Me.app_Path = rst("path").Value & ""
            'My.m_db_app.CloseRst(rst)
            'If Me.swDebug Then MsgBox("La base de datos esta en " & Me.app_Path)


            ' Primer Inicio de la aplicacion, tengo que configurar la aplicacion por huevos xD
            If Not My.m_app.isset_Value("fh_first") OrElse (My.Application.CommandLineArgs.Count > 0 AndAlso My.Application.CommandLineArgs(0).ToUpper = "-WIZARD") Then
                If Me.swDebug Then MsgBox("Primera ejecución del programa, no encuentra la ruta en el registro.")
                Dim frm As New frmWizard_Configure
                frm.ShowDialog()
                If frm.DialogResult <> DialogResult.OK Then
                    e.Cancel = True
                    frm.Dispose()
                    Exit Sub
                End If

                'Si es la primera ejecucion del tpv tengo que configurar y actualizar valores
                If Not My.m_app.isset_Value("fh_first") Then swFirst = True

                My.m_app.SetValue("fh_first") = Format(Now, "dd/MM/yyyy HH:mm")
                frm.Dispose()


                'Actualizo la ruta de la base de datos (Por si he modificado la ruta de donde esta)
                Select Case My.m_app.GetValue("modo_db", 0)
                    Case gDevelop.Lite.m_EnumTypes.DatabaseModeConnection.servidor

                        'My.m_db_app.Execute("UPDATE app SET path='" & My.m_app.GetValue("local_mdb") & "' WHERE id=" & Me.app_ID)
                        'Me.app_Path = My.m_app.GetValue("local_mdb")

                        '    Case gDevelop.Lite.m_EnumTypes.DatabaseModeConnection.cliente
                End Select

                If My.Application.CommandLineArgs.Count > 0 Then End
            Else
                'Actulizo la ruta de acceso
                Select Case My.m_app.GetValue("modo_db", 0)
                    Case gDevelop.Lite.m_EnumTypes.DatabaseModeConnection.servidor
                        'My.m_app.SetValue("local_mdb") = Me.app_Path
                        Me.app_Path = My.m_app.GetValue("local_mdb")
                End Select

            End If

            'Actualizo la ruta de la base de datos
            'My.m_db_app.Execute("UPDATE app SET path='" & My.m_app.GetValue("local_mdb") & "' WHERE id=" & Me.app_ID)

            'My.m_app.GetValue("local_mdb")



            If Me.swDebug Then MsgBox("Abro la base de datos según tipo de conexión.")
            ' Obtengo el tipo de conexion (Por defecto Access)
            Select Case My.m_app.GetValue("tipo_db", gDevelop.Lite.m_EnumTypes.DatabaseConnection.Access)
                Case gDevelop.Lite.m_EnumTypes.DatabaseConnection.Access                                                            ' Conexion Access
                    My.m_db = New gDevelop.Lite.m_database(gDevelop.Lite.m_EnumTypes.DatabaseConnection.Access)

                    If My.m_app.GetValue("modo_db") = 0 Then
                        My.m_db.Database_SourceHost = My.m_app.GetValue("local_mdb")
                    Else
                        My.m_db.Database_SourceHost = My.m_app.GetValue("network_mdb")
                    End If

                    My.m_db.Database_Name = My.APP_DATABASE

                    If Not My.m_db.Connect() Then e.Cancel = True

                Case gDevelop.Lite.m_EnumTypes.DatabaseConnection.MySQL                                                            ' Conexion MySQL
                    MsgBox("mysqldb not support")
                    e.Cancel = True

                Case Else
                    ' Sino detecta el tipo de gestor de base de datos no inicio

                    My.m_msg.MessageError(My.m_db, "Configuración de gestor de base de datos no localizado.")
                    e.Cancel = True

            End Select
            If e.Cancel Then Exit Sub

            If Me.swDebug Then MsgBox("Una vez llegados aquí ya hemos podido conectar con la base de datos que usara el programa.", MsgBoxStyle.Information)

            'Cargo las opciones globales sobre el programa, de Impresion
            If Me.swDebug Then MsgBox("Cargo configuración de Empresa y opciones de aplicación")
            My.LoadAppConfig()

            If Me.swDebug Then MsgBox("Cargo Hardware")
            My.Load_OptionsHardware()


            ''Chequeo valores pre-configurados
            'If Not My.m_app.isset_Value("balanza_enabled") Then My.m_app.SetValue("balanza_enabled") = "False"
            'If Not My.m_app.isset_Value("balanza_port") Then My.m_app.SetValue("balanza_port") = "NINGUNO"


            'Si es la primera vez que ejecuta configuro la base de datos
            If swFirst AndAlso My.m_app.GetValue("modo_db") = 0 Then
                '### Inicializacion de la Base de Datos
                'Dim msg As String = "Al ser la primera vez que ejecuta """ & My.APP_NAME & """ se le presenta la posibilidad de iniciar la aplicación de dos maneras:" & vbCrLf & vbCrLf & _
                '                                "    - Con ""Valores pre-Configurados"" por Defecto, " & _
                '                                    "como tickets creados, cajas realizadas, clientes con facturas, proveedores con pedidos, reservas realizadas y un diseño del local" & vbCrLf & vbCrLf & _
                '                                "    - O iniciar la aplicación ""Preparada y lista para usar"", empezando a trabajar con datos reales desde este momento. " & vbCrLf & "(Esta posibilidad es accesible desde el menú de ""Configuración"")" & vbCrLf & vbCrLf & vbCrLf & vbCrLf & _
                '                                "¿Desea iniciar """ & My.APP_NAME & """ por primera vez con los ""Valores pre-Configurados""? " & vbCrLf & vbCrLf & "Si Cancela, empezara con la base de datos en limpio a excepción de categorias y artículos."


                'If MsgBox(msg, MsgBoxStyle.OkCancel + MsgBoxStyle.Question, My.APP_NAME) = MsgBoxResult.Ok Then
                '    'Elimino tickes y lineas de prueba
                '    My.m_db.Execute("DELETE FROM db_tickets")
                '    My.m_db.Execute("DELETE FROM db_tickets_lines")

                '    My.m_db.Execute("DELETE FROM db_reservas")
                '    My.m_db.Execute("DELETE FROM db_reservas_menu")

                '    My.m_db.Equals("DELETE FROM db_clientes")
                '    My.m_db.Execute("DELETE FROM db_proveedores")

                '    My.m_db.Execute("DELETE FROM db_design")
                'End If


                'Agrego valores iniciales de la aplicación
                My.m_db.Execute("INSERT INTO db_reservas (name,about,fh_alta,fh_reserva) VALUES ('" & My.APP_NAME & "','Bienvenido por su primera visita al sistema de administración de locales de hosteria: " & My.APP_NAME & "!!!',#" & Now & "#,#" & Now.ToString("dd/MM/yyyy") & "#)")

                'Actualizo valores
                If MsgBox("¿Desea inicializar el software con la base de datos limpia?", MsgBoxStyle.Question + MsgBoxStyle.OkCancel) = MsgBoxResult.Ok Then
                    My.m_db.Execute("UPDATE db_articulos SET ud=0,n_veces=0")
                    My.m_db.Execute("UPDATE db_categorias SET n_veces=0")
                End If
            End If

            'Si tengo activado el modo seguro, valido al usuario antes
            If Me.swDebug Then MsgBox("Compruebo si tiene modo seguro de inicio")
            If My.m_opt.modo_seguro Then
                If My.m_app.GetValue("modo_db") = 0 Then
                    My.AppIdUser = My.IdentificaUser()
                    If My.AppIdUser = -1 Then e.Cancel = True
                Else
                    'Al ser modo cliente y si esta activado el modo seguro solo permito conectar al Panel de Ventas
                    My.RunPaneldeVentas()
                    e.Cancel = True
                End If
            End If

            'Precargo el crystal reports
            If Me.swDebug Then MsgBox("Cargo CR")
            Me.LoadCR()



            '# CHECK REGISTER
            If My.m_app.IsRegister Then
                Dim m_crypt As New gDevelop.Lite.Crypto_Rijndael
                Dim sw As Boolean = False
                If My.m_app.GetValue("crypt_name") <> m_crypt.Crypt(My.m_opt.company_name) Then sw = True
                If My.m_app.GetValue("crypt_fiscal") <> m_crypt.Crypt(My.m_opt.company_namefiscal) Then sw = True
                If My.m_app.GetValue("crypt_cif") <> m_crypt.Crypt(My.m_opt.company_cif) Then sw = True
                If My.m_app.GetValue("crypt_cab0") <> m_crypt.Crypt(My.MyHardware.StrCab(1)) Then sw = True
                If My.m_app.GetValue("crypt_cab1") <> m_crypt.Crypt(My.MyHardware.StrCab(2)) Then sw = True

                'My.m_app.SetValue("crypt_name") = m_crypt.Crypt(My.m_opt.company_name)
                'My.m_app.SetValue("crypt_fiscal") = m_crypt.Crypt(My.m_opt.company_namefiscal)
                'My.m_app.SetValue("crypt_cif") = m_crypt.Crypt(My.m_opt.company_namefiscal)
                'My.m_app.SetValue("crypt_cab0") = m_crypt.Crypt(My.MyHardware.StrCab(0))
                'My.m_app.SetValue("crypt_cab1") = m_crypt.Crypt(My.MyHardware.StrCab(1))                   
                If sw Then
                    MsgBox("Don't Hack, próximamente END", MsgBoxStyle.Critical)
                    If MsgBox("¿Sabe que lo que próximamente no se le dejará usar la aplicación?" & vbCrLf & "Ahora pulse RETRY para continuar.", MsgBoxStyle.Critical + MsgBoxStyle.RetryCancel) <> MsgBoxResult.Retry Then End
                    'If MsgBox("Ahora pulse NO", MsgBoxStyle.Critical + MsgBoxStyle.RetryCancel) <> MsgBoxResult.Retry Then End
                    Dim rnd1 As New Random(DateTime.Now.Millisecond * 23)
                    Dim rnd2 As New Random(DateTime.Now.Millisecond)
                    Dim n1 As Integer = rnd1.Next(0, 99)
                    Dim n2 As Integer = rnd2.Next(0, 99)

                    If InputBox("Ahora resuelva la siguiente operación: " & n1 & "+" & n2, "Operación de control") <> n1 + n2 Then
                        MsgBox("Error, vuelva a empezar.", MsgBoxStyle.Critical)
                        End
                    End If

                    MsgBox("Recuerde que puede solucionar estos inconvenientes hablando con su distribuidor de software. Que pase buen día.", MsgBoxStyle.Information)
                End If

            End If
            ''Si es versión de EPC
            'If True Or (Screen.PrimaryScreen.Bounds.Width = 1024 AndAlso Screen.PrimaryScreen.Bounds.Height = 600) Then
            '    frmNoteBook.ShowDialog()
            '    frmNoteBook.Dispose()
            '    e.Cancel = True
            'End If


            'Abro base de datos temporal
            If Me.swDebug Then MsgBox("Abro db.temp")
            My.m_db_temp = New gDevelop.Lite.m_database(gDevelop.Lite.m_EnumTypes.DatabaseConnection.Access)
            My.m_db_temp.Database_SourceHost = My.Application.Info.DirectoryPath
            My.m_db_temp.Database_Name = My.APP_DATABASE_TMP

            If Not My.m_db_temp.Connect() Then
                e.Cancel = True
                End
            End If

            Dim rst As ADODB.Recordset
            Dim rstNew As ADODB.Recordset
            Dim rstCat As ADODB.Recordset

            'rst = My.m_db.GetRst("SELECT * FROM familias ORDER BY Campo2 ASC")
            'rstNew = My.m_db.GetRst("SELECT * FROM db_categorias WHERE id=-1")
            'While Not rst.EOF
            '    rstNew.AddNew()
            '    rstNew("name").Value = rst("Campo2").Value
            '    rstNew("cod").Value = rst("Campo1").Value
            '    rstNew.Update()

            '    rst.MoveNext()
            'End While
            Exit Sub

            Dim idCat As Integer = 0

            rst = My.m_db.GetRst("SELECT * FROM articulos1 ORDER BY Campo2 ASC")
            rstNew = My.m_db.GetRst("SELECT * FROM db_articulos WHERE id=-1")

            While Not rst.EOF
                rstCat = My.m_db.GetRst("SELECT id FROM db_categorias WHERE cod='" & rst("Campo5").Value & "'")
                If rstCat.RecordCount <= 0 Then
                    idCat = 19
                Else
                    idCat = rstCat("id").Value
                End If

                rstNew.AddNew()
                rstNew("id_empresa").Value = 1
                rstNew("name").Value = rst("Campo2").Value
                rstNew("id_categoria").Value = idCat

                rstNew("pvp").Value = rst("Campo22").Value.ToString.Replace(",", ".")
                rstNew("iva").Value = 21
                rstNew("pvp_iva").Value = Format(rstNew("pvp").Value * 1.21, "0.00").ToString.Replace(",", ".")

                rstNew("fh_alta").Value = Now
                rstNew.Update()

                rst.MoveNext()
            End While



            Exit Sub

            ''# Conecto a la base de datos
            'Dim sConn As String = "Driver={Microsoft dBASE Driver (*.dbf)};DriverID=277;Dbq=" & _
            '        System.IO.Path.GetDirectoryName("C:\temp\it") & ";"

            ''sConn = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" & System.IO.Path.GetDirectoryName(Me.lblImporta_file.Text) & ";Extended Properties=dBASE IV;User ID=Admin;Password=;"
            ''sConn = "Provider=vfpoledb;Data Source=" & System.IO.Path.GetDirectoryName(Me.lblImporta_file.Text) & ";Collating Sequence=machine;"

            'sConn = "Driver={Microsoft Visual FoxPro Driver};SourceType=DBF;SourceDB=" & System.IO.Path.GetDirectoryName("C:\temp\it") & "\;Exclusive=No; Collate=Machine;NULL=NO;DELETED=NO;BACKGROUNDFETCH=NO;"

            'Dim dbConn As New ADODB.Connection
            'Try
            '    dbConn.Open(sConn)
            'Catch ex As Exception
            '    MessageBox.Show("Error al abrir la base de datos de origen" & vbCrLf & ex.Message)
            '    Exit Sub
            'End Try

            ''# CARGO CATEGORIAS
            'Dim rstIT As ADODB.Recordset
            'Dim rstITNew As ADODB.Recordset
            'Dim i As Integer = 0

            'rstIT = New ADODB.Recordset
            'rstIT.Open("SELECT * FROM familias.dbf", dbConn, ADODB.CursorTypeEnum.adOpenForwardOnly, ADODB.LockTypeEnum.adLockReadOnly)
            'rstITNew = My.m_db.GetRst("SELECT * FROM db_categorias WHERE id=-1")
            'While Not rstIT.EOF
            '    rstITNew.AddNew()
            '    rstITNew("cod").Value = rstIT("CODIGO").Value
            '    rstITNew("name").Value = rstIT("CODIGO").Value

            '    rstITNew.Update()


            '    rstIT.MoveNext()
            'End While





            Exit Sub


            ''##########
            ' ''IMPORTO DATOS DE ESTANCO
            'Dim db As gDevelop.Lite.m_database
            'db = New gDevelop.Lite.m_database(gDevelop.Lite.m_EnumTypes.DatabaseConnection.Access)
            'db.Database_SourceHost = My.Application.Info.DirectoryPath
            'db.Database_Name = "Shop1"

            'If Not db.Connect() Then
            '    e.Cancel = True
            '    End
            'End If

            'Dim rstCat As ADODB.Recordset = Nothing, rstCatNew As ADODB.Recordset = Nothing
            'Dim rst As ADODB.Recordset = Nothing, rstAux As ADODB.Recordset = Nothing
            'Dim rstNew As ADODB.Recordset = Nothing, rstTMP As ADODB.Recordset = Nothing

            'Dim idCatNew As Integer = 0, n As Integer = 0


            ' ''### Paso primero los artículos que no son de TABACO
            ''rstCat = db.GetRst("SELECT * FROM Familias WHERE Familia<>'TA1' AND Familia<>'AF1'")
            ''While Not rstCat.EOF
            ''    rst = db.GetRst("SELECT * FROM Artículos WHERE LEFT(FamSub,3)='" & rstCat("Familia").Value & "'")

            ''    If rst.RecordCount > 0 Then
            ''        While Not rst.EOF

            ''            If rst("Artículo").Value.ToString.Length < 8 Then

            ''                ' Compruebo si la familia existe y obtengo el codigo de familia
            ''                rstAux = My.m_db.GetRst("SELECT * FROM db_categorias WHERE cod='" & Left(rst("FamSub").Value, 3) & "'")
            ''                If rstAux.RecordCount = 0 Then
            ''                    rstAux.AddNew()
            ''                    rstAux("name").Value = rstCat("Descripción").Value
            ''                    rstAux("cod").Value = rstCat("Familia").Value
            ''                    rstAux("fh_alta").Value = Now

            ''                    rstAux.Update()
            ''                    idCatNew = rstAux("id").Value
            ''                Else
            ''                    idCatNew = rstAux("id").Value
            ''                End If
            ''                My.m_db.CloseRst(rstAux)

            ''                ' Compruebo si el producto existe
            ''                rstNew = My.m_db.GetRst("SELECT * FROM db_articulos WHERE cod='" & rst("Artículo").Value & "'")
            ''                If rstNew.RecordCount = 0 Then
            ''                    If rst("Descripción").Value.ToString.Length > 0 Then
            ''                        rstNew.AddNew()
            ''                        rstNew("id_empresa").Value = 1
            ''                        rstNew("id_categoria").Value = idCatNew
            ''                        rstNew("name").Value = rst("Descripción").Value.ToString.ToUpper.Replace("Ñ", "N")
            ''                        rstNew("tipo_ud").Value = "UNITARIO"

            ''                        If rst("Ivaven").Value <> 0 Then
            ''                            rstNew("pvp").Value = CDbl(Format(rst("pvp1").Value / CDbl("1," & Format(rst("Ivaven").Value, "0")), "0.00#####"))
            ''                        Else
            ''                            rstNew("pvp").Value = rst("pvp1").Value
            ''                        End If
            ''                        rstNew("iva").Value = rst("Ivaven").Value
            ''                        rstNew("pvp_iva").Value = rst("pvp1").Value


            ''                        rstNew("cod").Value = rst("Artículo").Value
            ''                        rstNew("fh_alta").Value = Now

            ''                        rstNew.Update()


            ''                        'Agrego el codigo de barras
            ''                        rstTMP = db.GetRst("SELECT * FROM Asignación WHERE Artículo='" & rst("Artículo").Value & "'")
            ''                        If rstTMP.RecordCount > 0 Then
            ''                            Try
            ''                                rstAux = My.m_db.GetRst("SELECT * FROM db_articulos_cod_barras WHERE id_articulo=" & rstNew("id").Value & " AND cod_barras='" & rstTMP("Codasig").Value & "'")
            ''                                If rstAux.RecordCount = 0 Then
            ''                                    My.m_db.Execute("INSERT INTO db_articulos_cod_barras (id_articulo,cod_barras) VALUES(" & rstNew("id").Value & ",'" & rstTMP("Codasig").Value & "')")
            ''                                End If
            ''                            Catch ex As Exception

            ''                            End Try
            ''                        End If
            ''                    End If
            ''                End If
            ''                My.m_db.CloseRst(rstNew)
            ''            End If

            ''            ' MsgBox(rstCat("Descripción").Value & " - " & rst.RecordCount)

            ''            rst.MoveNext()
            ''        End While
            ''    End If
            ''    rst.Close()


            ''    rstCat.MoveNext()
            ''End While



            ' ''### Paso primero los artículos que SON de TABACO
            ''rstCat = db.GetRst("SELECT * FROM Familias WHERE Familia='TA1' OR Familia='AF1'")
            ''While Not rstCat.EOF
            ''    rst = db.GetRst("SELECT * FROM Artículos WHERE LEFT(FamSub,3)='" & rstCat("Familia").Value & "'")

            ''    If rst.RecordCount > 0 Then
            ''        While Not rst.EOF

            ''            If rst("Artículo").Value.ToString.Length > 6 Then

            ''                rstAux = My.m_db.GetRst("SELECT * FROM estanco_marcas WHERE cod_barras='" & rst("Artículo").Value & "'")
            ''                If rstAux.RecordCount > 0 Then
            ''                    rstAux("activo").Value = True
            ''                    rstAux.Update()

            ''                    n += 1
            ''                    Debug.Print(rst("Descripción").Value)
            ''                End If

            ''            End If

            ''            rst.MoveNext()
            ''        End While
            ''    End If
            ''    rst.Close()


            ''    rstCat.MoveNext()
            ''End While



            ''### Paso los artículos que SON de TABACO desde la tabla de intercambio
            'rstCat = db.GetRst("SELECT * FROM Asignación")
            'While Not rstCat.EOF
            '    rstAux = My.m_db.GetRst("SELECT * FROM estanco_marcas WHERE cod_barras='" & rstCat("Codasig").Value & "'")
            '    If rstAux.RecordCount > 0 Then
            '        rstAux("activo").Value = True
            '        rstAux.Update()

            '        n += 1
            '        Debug.Print(rstCat("Descripción").Value)
            '    End If


            '    rstCat.MoveNext()
            'End While



            'MsgBox("Importado los artículos. " & n)


            ''##########
            ' ''IMPORTO DATOS DE AMHOTEL
            ''Dim db As gDevelop.Lite.m_database
            ''db = New gDevelop.Lite.m_database(gDevelop.Lite.m_EnumTypes.DatabaseConnection.Access)
            ''db.Database_SourceHost = My.Application.Info.DirectoryPath
            ''db.Database_Name = "HOT12101"

            ''If Not db.Connect() Then
            ''    e.Cancel = True
            ''    End
            ''End If

            ''Dim rst As ADODB.Recordset = Nothing, rstAux As ADODB.Recordset = Nothing
            ''Dim rstNew As ADODB.Recordset = Nothing


            ' ''Cargo todos los articulos
            ''rst = db.GetRst("SELECT * FROM articulo")
            ''While Not rst.EOF
            ''    rstNew = My.m_db.GetRst("SELECT * FROM db_articulos WHERE id=-1")
            ''    rstNew.AddNew()
            ''    rstNew("id_empresa").Value = 1
            ''    rstNew("id_categoria").Value = Val(rst("familia").Value)
            ''    rstNew("name").Value = rst("Nombre").Value.ToString.ToUpper.Replace("Ñ", "N")
            ''    rstNew("tipo_ud").Value = "UNITARIO"

            ''    'Obtengo el precio
            ''    rstAux = db.GetRst("SELECT * FROM ArticuloTarifas where articulo='" & rst("Codigo").Value & "'")
            ''    If rstAux.RecordCount > 0 Then
            ''        rstNew("pvp").Value = CDbl(Format(rstAux("precio2").Value / CDbl("1,10"), "0.00###"))
            ''        rstNew("iva").Value = 10
            ''        rstNew("pvp_iva").Value = rstAux("precio2").Value
            ''    Else
            ''        MsgBox("código no localizado: " & rst("Nombre").Value)
            ''    End If


            ''    rstNew("fh_alta").Value = Now

            ''    rstNew.Update()

            ''    rst.MoveNext()
            ''End While

        End Sub

        'Cierro la aplicacion
        Private Sub MyApplication_Shutdown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shutdown
            My.m_db_temp.Dispose()
            'My.m_db_app.Dispose()
            My.m_db.Dispose()
        End Sub

#Region "Precarga del Crystal Reports"
        Private WithEvents backWorker As System.ComponentModel.BackgroundWorker

        Private Sub LoadCR()
            On Error Resume Next
            backWorker = New System.ComponentModel.BackgroundWorker
            backWorker.RunWorkerAsync()
        End Sub

        Private Sub backWorker_DoWork(ByVal sender As Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles backWorker.DoWork
            On Error Resume Next
            Dim Viewer As New CrystalDecisions.Windows.Forms.CrystalReportViewer
            Dim rpt As CrystalDecisions.CrystalReports.Engine.ReportDocument = New crtPreLoad

            Dim li As CrystalDecisions.Shared.TableLogOnInfo, i As Integer
            Dim ci As CrystalDecisions.Shared.ConnectionInfo
            Dim ReturnCode As Boolean = True

            With rpt
                For i = 0 To .Database.Tables.Count - 1
                    li = .Database.Tables(i).LogOnInfo
                    ci = li.ConnectionInfo

                    ci.Password = ""
                    ci.UserID = "admin"

                    .Database.Tables(i).ApplyLogOnInfo(li)
                Next i
            End With
            Viewer.ReportSource = rpt

            ''Cierro limpiando
            'Viewer.Dispose()
            'Viewer = Nothing
            'rpt.Close()
            'rpt.Dispose()
            'rpt = Nothing
        End Sub
#End Region

    End Class
End Namespace

