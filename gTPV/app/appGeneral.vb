Namespace My
    Module appApoyo

#Region "Apis"
        Public Declare Function ShellExecute Lib "shell32.dll" Alias "ShellExecuteA" (ByVal hwnd As Integer, ByVal lpOperation As String, ByVal lpFile As String, ByVal lpParameters As String, ByVal lpDirectory As String, ByVal nShowCmd As Integer) As Integer
        Public Declare Function SetForegroundWindow Lib "user32" (ByVal hwnd As Long) As Long

        'Public Declare Function SetPortVal Lib "WinIo.dll" (ByVal PortAddr As Integer, ByVal PortVal As Long, ByVal bSize As Byte) As Boolean
#End Region

#Region "Carga de Configuración y Opciones Generales"
        ' Estructura para almacenar los valores generales
        Friend Structure options
            '# Info general de empresa
            Public company_name As String
            Public company_namefiscal As String
            Public company_cp As String
            Public company_cif As String

            '# Opciones GENERALES/PRINCIPALES sobre la aplicacion
            Public modo_seguro As Boolean
            Public modo_seguro_secciones As Boolean
            Public autoclose As Boolean
            Public ticketAvanzado As Boolean
            Public fechaCierreOnDate As Boolean

            Public responsive As Boolean

            'Public modo_seguro_OnlyPass As Boolean


            '# Opciones sobre la CAJA
            Public cajadirecta As Boolean
            Public cajadirecta_requeriridentificacion As Boolean           '(Tras cada venta se vuelve a solicitar el usuario)
            Public cajadirecta_closeuser As Boolean

            '# Valores sobre la Configuración
            Public IVA_General As Double
            Public IVA_Medio As Double
            Public IVA_Basico As Double
            Public IVA_Libre As Double

            Public IVA_Recargo_General As Double
            Public IVA_Recargo_Medio As Double
            Public IVA_Recargo_Basico As Double
            Public IVA_Recargo_Libre As Double

            Public swRecargo As Boolean

            Public dblIncVarIngredientes As Double


            Public id_tarifa As Integer
            Public modo_compatibilidad As String
            Public nPrintCopiaPedidos As Integer
            Public swNoteBook As Boolean
            Public swResponsive As Boolean
            Public swBlockAut As Boolean
            Public swPrintResumen As Boolean

            Public swNotDelete As Boolean

            Public swNoNameImg As Boolean
            Public swNotOrder As Boolean

            Public entrada_normal As Double
            Public entrada_especial As Double


            Public lector_sw As Boolean
            Public lector_port As Integer

            Public mysql_host As String
            Public mysql_user As String
            Public mysql_pass As String
            Public mysql_db As String
            Public mysql_id As String
        End Structure
        Public m_opt As options

        ' Funcion de chequeo y carga de los valores de configuración generales
        Public Function LoadAppConfig() As Boolean
            On Error Resume Next
            ' Declaración de trash
            Dim rst As ADODB.Recordset
            m_opt = New options


            '<!-- Cargo las informacion general sobre la empresa -->
            If My.Application.swDebug Then MsgBox("Cargo valores de empresa")
            rst = My.m_db.GetRst("SELECT * FROM app_empresa")
            m_opt.company_name = rst("name_comercial").Value
            m_opt.company_namefiscal = rst("name_fiscal").Value
            m_opt.company_cif = rst("cif").Value
            m_opt.company_cp = rst("cp").Value
            My.m_db.CloseRst(rst)


            '<!--- Cargo las opciones generales del programa -->
            If My.Application.swDebug Then MsgBox("Cargo opciones")
            rst = My.m_db.GetRst("SELECT * FROM app_options")


            '# Opciones GENERALES/PRINCIPALES
            m_opt.modo_seguro = rst("modo_seguro").Value
            If Not IsDBNull(rst("modo_seguro_secciones").Value) Then
                m_opt.modo_seguro_secciones = rst("modo_seguro_secciones").Value
            Else
                m_opt.modo_seguro_secciones = False
            End If

            If Not IsDBNull(rst("swTicketAvanzado").Value) Then
                m_opt.ticketAvanzado = rst("swTicketAvanzado").Value
            Else
                m_opt.ticketAvanzado = False
            End If

            If Not IsDBNull(rst("swResponsive").Value) Then
                m_opt.swResponsive = rst("swResponsive").Value
            Else
                m_opt.swResponsive = False
            End If

            If Not IsDBNull(rst("swBlockAut").Value) Then
                m_opt.swBlockAut = rst("swBlockAut").Value
            Else
                m_opt.swBlockAut = False
            End If

            If Not IsDBNull(rst("swPrintResumen").Value) Then
                m_opt.swPrintResumen = rst("swPrintResumen").Value
            Else
                m_opt.swPrintResumen = False
            End If

            If Not IsDBNull(rst("swNotDelete").Value) Then
                m_opt.swNotDelete = rst("swNotDelete").Value
            Else
                m_opt.swNotDelete = False
            End If

            If Not IsDBNull(rst("incVarIngredientes").Value) Then
                m_opt.dblIncVarIngredientes = rst("incVarIngredientes").Value
            Else
                m_opt.dblIncVarIngredientes = 0
            End If


            m_opt.fechaCierreOnDate = rst("swCierreCajaOnDate").Value

            m_opt.autoclose = rst("autoclose").Value
            'm_opt.modo_seguro_OnlyPass = rst("only_pass").Value
            Select Case rst("modo_compatibilidad").Value & ""
                Case "HOSTELERIA" : m_opt.modo_compatibilidad = "HOSTELERIA"
                Case "COMERCIO" : m_opt.modo_compatibilidad = "COMERCIO"
                Case "DISCOTECA" : m_opt.modo_compatibilidad = "DISCOTECA"
                Case "REPARTO" : m_opt.modo_compatibilidad = "REPARTO"
                Case "ESTANCO" : m_opt.modo_compatibilidad = "ESTANCO"
                Case Else : m_opt.modo_compatibilidad = "ESTANDAR"
            End Select

            m_opt.id_tarifa = rst("id_tarifa_aplicada").Value

            '# Opciones sobre la CAJA
            m_opt.cajadirecta = rst("cajadirecta").Value
            m_opt.cajadirecta_requeriridentificacion = rst("cajadirecta_requeriridentificacion").Value
            m_opt.cajadirecta_closeuser = rst("swclose_cajauser").Value

            m_opt.nPrintCopiaPedidos = rst("nPrintCopiaPedidos").Value

            '# Opciones Varias
            m_opt.swNoNameImg = rst("notNameImg").Value
            m_opt.swNotOrder = rst("swNotOrden").Value


            '# Lector de tarjetas
            If CBool(rst("mysql_sw").Value) Then
                m_opt.lector_sw = True
                m_opt.lector_port = My.m_app.GetValue("id_portlector", 0)

                m_opt.mysql_host = rst("mysql_host").Value & ""
                m_opt.mysql_user = rst("mysql_user").Value & ""
                m_opt.mysql_pass = rst("mysql_pass").Value & ""
                m_opt.mysql_db = rst("mysql_db").Value & ""
                m_opt.mysql_id = rst("mysql_id").Value & ""
            End If

            My.m_db.CloseRst(rst)


            '<!-- Cargo detalles sobre la Facturación y la Contabilidad -->
            If My.Application.swDebug Then MsgBox("Cargo valores contables")
            rst = My.m_db.GetRst("SELECT * FROM app_contabilidad")
            m_opt.IVA_General = rst("iva_general").Value
            m_opt.IVA_Medio = rst("iva_medio").Value
            m_opt.IVA_Basico = rst("iva_basico").Value

            m_opt.IVA_Recargo_General = rst("recargo_general").Value
            m_opt.IVA_Recargo_Medio = rst("recargo_medio").Value
            m_opt.IVA_Recargo_Basico = rst("recargo_basico").Value

            m_opt.swRecargo = rst("swRecargo").Value

            m_opt.entrada_normal = rst("pvp_entrada_normal").Value
            m_opt.entrada_especial = rst("pvp_entrada_especial").Value

            My.m_db.CloseRst(rst)

            '<!-- Leo Opciones generales de Sistema -->
            m_opt.swNoteBook = (Screen.PrimaryScreen.Bounds.Width = 1024 AndAlso Screen.PrimaryScreen.Bounds.Height = 600)



            Dim str As String = My.m_app.GetValue("lng", "es-ES")
            'Select Case True
            '    Case sender Is Me.btChangeLenguaje_ESAN : str = "an-ES"
            '    Case sender Is Me.btChangeLenguaje_ESES : str = "es-ES"
            '    Case sender Is Me.btChangeLenguaje_ESMX : str = "es-MX"
            '    Case sender Is Me.btChangeLenguaje_ESGA : str = "gl-ES"

            '    Case sender Is Me.btChangeLenguaje_FRFR : str = "fr-FR"
            'End Select

            'Cambio idioma
            System.Threading.Thread.CurrentThread.CurrentCulture = New System.Globalization.CultureInfo(str)
            System.Threading.Thread.CurrentThread.CurrentUICulture = New System.Globalization.CultureInfo(str)


            Return True
        End Function

        'Funcion en plan bonito para recargas los valores de la aplicacion
        Public Function ReloadAppConfig() As Boolean
            Return LoadAppConfig()
        End Function
#End Region

#Region "Funciones Generales a la Aplicación"
        'Funcion para iniciar el Panel de Ventas
        Public Function RunPaneldeVentas() As Boolean
            'Si es DEMO limito a 1999 Tickets
            If Not My.m_app.IsRegister Then
                If Not IO.File.Exists(My.Computer.FileSystem.SpecialDirectories.CurrentUserApplicationData & "\gdv") Then
                    Dim rstCount As ADODB.Recordset = My.m_db.GetRst("SELECT COUNT(id) AS ntot FROM db_tickets")
                    If rstCount("ntot").Value > 1000 And rstCount("ntot").Value <= 4999 Then
                        My.m_msg.MessageError("Recuerde que la versión DEMO de """ & My.APP_NAME & """ esta limitada aun máximo de 4999 Tickets y usted lleva " & rstCount("ntot").Value & ", para continuar usando la aplicación una vez superada esa cifra debe de registrarla." & vbCrLf & vbCrLf & "Lamentamos las molestias :)")
                    End If

                    If rstCount("ntot").Value >= 5000 Then
                        My.m_msg.MessageError("La versión DEMO de """ & My.APP_NAME & """ esta limitada aun máximo de 4999 Tickets, para continuar usando la aplicación debe de registrarla." & vbCrLf & vbCrLf & "Lamentamos las molestias :)")
                        Return False
                    End If
                    My.m_db.CloseRst(rstCount)
                End If
            End If


            ' Compruebo el cashlogic
            'If MyHardware.cashlogy_sw AndAlso IsNothing(My.Application.sckCashlogy) Then
            If MyHardware.cashlogy_sw Then

                If MsgBox("Esta habilitado el modo CASHLOGY, no se iniciara el terminal de ventas hasta que haya inicializado la máquina correctamente. ¿Deséa continuar?", MsgBoxStyle.OkCancel + MsgBoxStyle.Question) <> MsgBoxResult.Ok Then
                    Return False
                End If

                Dim i As Integer = 0
                My.Application.sckCashlogy = New System.Net.Sockets.TcpClient
                Try
                    My.Application.sckCashlogy.Connect(System.Net.IPAddress.Parse(MyHardware.cashlogy_ip), MyHardware.cashlogy_port)
                    'System.Windows.Forms.Application.DoEvents()
                Catch ex As Exception
                    MsgBox("Imposible conectar, el motivo es: " & ex.Message, MsgBoxStyle.Critical)
                    Return False
                End Try
                My.Application.sIOCashlogy = My.Application.sckCashlogy.GetStream

                My.Application.cashlogy_sCadena = "#I#"
                My.Application.cashlogy_bytes = System.Text.Encoding.ASCII.GetBytes(My.Application.cashlogy_sCadena)
                My.Application.sIOCashlogy.Write(My.Application.cashlogy_bytes, 0, My.Application.cashlogy_bytes.Length)

                My.Application.cashlogy_sCadena = ""
                My.Application.cashlogy_bytes = Nothing


                'Realizo lectura del buffer (OK de inicializacion)
                Threading.Thread.Sleep(1000)
                While True
                    If Not My.Application.sIOCashlogy.DataAvailable Then
                        Threading.Thread.Sleep(1000)
                        'System.Windows.Forms.Application.DoEvents()
                        i += 1

                        If i > 60 Then
                            MsgBox("Imposible inicializar CASHLOGY, tiempo de espera agotado.", MsgBoxStyle.Critical)
                            My.Application.sckCashlogy.Close()
                            My.Application.sckCashlogy = Nothing
                            Exit Function
                        End If
                    Else

                        ReDim My.Application.cashlogy_bytes(My.Application.sckCashlogy.ReceiveBufferSize)
                        My.Application.sIOCashlogy.Read(My.Application.cashlogy_bytes, 0, My.Application.cashlogy_bytes.Length)
                        My.Application.cashlogy_sCadena = System.Text.Encoding.ASCII.GetString(My.Application.cashlogy_bytes, 0, My.Application.cashlogy_bytes.Length)

                        If My.Application.cashlogy_sCadena.Substring(0, 9) = "#ER:BUSY#" Then
                            If cashlogy_reset() Then
                                MsgBox("Reseteado CashLogy, inicie de nuevo.", MsgBoxStyle.Information)
                                Exit Function
                            End If
                            'My.Application.sckCashlogy.Close()
                            'My.Application.sckCashlogy = Nothing

                            'My.Application.sIOCashlogy.Close()
                            'My.Application.sIOCashlogy = Nothing

                            Exit Function
                        ElseIf My.Application.cashlogy_sCadena.Substring(0, 8) <> "#0#2.01#" Then
                            MsgBox("Imposible inicializar CASHLOGIC, comando no reconocido: " & My.Application.cashlogy_sCadena, MsgBoxStyle.Critical)
                            My.Application.sckCashlogy.Close()
                            My.Application.sckCashlogy = Nothing

                            My.Application.sIOCashlogy.Close()
                            My.Application.sIOCashlogy = Nothing

                            Exit Function
                        Else
                            ' TODO OK
                            Exit While
                        End If
                    End If
                End While

                MsgBox("CASHLOGY inicializado correctamente. GOOOOO!!!", MsgBoxStyle.Information)

            End If

            If My.m_opt.cajadirecta Then
                Dim _id As Integer = My.ValidateUser()
                If _id = -1 Then Return False
                If Not My.m_opt.swResponsive AndAlso 1 = 0 Then

                    'Muestro panel de ventas
                    With My.Forms.frmPaneldeVentas
                        .idRef = -1
                        .idMesa = -1
                        .idUser = _id
                        .swCajaDirecta = True

                        .ShowDialog()
                        'If .DialogResult = Windows.Forms.DialogResult.OK Then MsgBox("recargo")

                        .Dispose()
                    End With

                Else
                    'Muestro panel de ventas
                    With My.Forms.frmPaneldeVentasResponsive
                        .idRef = -1
                        .idMesa = -1
                        .idUser = _id
                        .swCajaDirecta = True

                        .ShowDialog()
                        'If .DialogResult = Windows.Forms.DialogResult.OK Then MsgBox("recargo")

                        .Dispose()
                    End With

                End If
            Else
                My.Forms.frmPaneldeSituacion.ShowDialog()
                My.Forms.frmPaneldeSituacion.Dispose()
            End If


            ' Compruebo el cashlogic
            If MyHardware.cashlogy_sw Then
                Dim i As Integer = 0
                'Realizo lectura del buffer (OK de inicializacion)
                My.Application.cashlogy_bytes = Nothing
                My.Application.cashlogy_sCadena = ""

                My.Application.cashlogy_sCadena = "#E#"
                My.Application.cashlogy_bytes = System.Text.Encoding.ASCII.GetBytes(My.Application.cashlogy_sCadena)
                My.Application.sIOCashlogy.Write(My.Application.cashlogy_bytes, 0, My.Application.cashlogy_bytes.Length)
                i = 0

                My.Application.cashlogy_sCadena = ""
                My.Application.cashlogy_bytes = Nothing

                Threading.Thread.Sleep(1000)
                While True
                    If Not My.Application.sIOCashlogy.DataAvailable Then
                        Threading.Thread.Sleep(1000)
                        i += 1

                        If i > 50 Then
                            MsgBox("Imposible inicializar, tiempo de espera agotado.", MsgBoxStyle.Critical)
                            My.Application.sckCashlogy.Close()
                            My.Application.sckCashlogy = Nothing
                            Exit Function
                        End If
                    Else

                        ReDim My.Application.cashlogy_bytes(My.Application.sckCashlogy.ReceiveBufferSize)
                        My.Application.sIOCashlogy.Read(My.Application.cashlogy_bytes, 0, My.Application.cashlogy_bytes.Length)
                        My.Application.cashlogy_sCadena = System.Text.Encoding.ASCII.GetString(My.Application.cashlogy_bytes, 0, My.Application.cashlogy_bytes.Length)

                        'If My.Application.cashlogy_sCadena.Substring(0, 3) <> "#WR:LEVEL#0##0#" Then
                        If My.Application.cashlogy_sCadena.Substring(0, 3) <> "#0#" Then
                            MsgBox("Imposible finalizar, comando no reconocido: " & My.Application.cashlogy_sCadena, MsgBoxStyle.Critical)
                            My.Application.sckCashlogy.Close()
                            My.Application.sckCashlogy = Nothing

                            My.Application.sIOCashlogy.Close()
                            My.Application.sIOCashlogy = Nothing

                            Return True
                        Else
                            ' TODO OK
                            Exit While
                        End If
                    End If
                End While

                My.Application.sckCashlogy.Close()
                My.Application.sckCashlogy = Nothing

                My.Application.sIOCashlogy.Close()
                My.Application.sIOCashlogy = Nothing


                MsgBox("CASHLOGIC ha finalizado correctamente.", MsgBoxStyle.Information)
            End If

            Return True
        End Function

        ' Funcion descontar del almacen las unidades
        Public Sub UpdateAlmacen(ByVal id_articulo As Integer, ByVal ud As Integer, Optional ByVal tipo As Integer = 0)
            Dim rst As ADODB.Recordset = Nothing

            If id_articulo = 0 Then Exit Sub
            Dim sql As String = ""
            'Selecciono los detalles de almacen del articulo
            sql = "SELECT id,ud,tipo_ud,ud_fraccion,ud_fraccion_uso,ud_capacidad,ud_capacidad_uso,ud_capacidad_articulo"
            If tipo > 0 Then sql &= ", vlcaso" & tipo & "_ud " 'PUTO TUTELA
            sql &= " FROM db_articulos WHERE(estocable = True And id = " & id_articulo & ")"

            rst = My.m_db.GetRst(sql)

            If rst.RecordCount > 0 Then
                Select Case rst("tipo_ud").Value
                    Case "UNITARIO"
                        My.m_db.Execute("UPDATE db_articulos SET ud=ud-" & ud & " WHERE estocable=true and id=" & id_articulo)

                    Case "FRACCIONADO"
                        Dim aux As Integer = Math.Floor((rst("ud_fraccion_uso").Value + ud) / rst("ud_fraccion").Value)
                        rst("ud_fraccion_uso").Value += ud
                        If rst("ud_fraccion_uso").Value >= rst("ud_fraccion").Value OrElse rst("ud_fraccion_uso").Value < 0 Then
                            rst("ud_fraccion_uso").Value = (rst("ud_fraccion_uso").Value - (rst("ud_fraccion").Value * aux))
                            rst("ud").Value -= aux
                        End If
                        rst.Update()

                    Case "CAPACIDAD"
                        'PUTO TUTELA
                        Dim udCapacidad As Integer = 0
                        If tipo <= 0 Then
                            udCapacidad = rst("ud_capacidad_articulo").Value
                        Else
                            udCapacidad = rst("vlcaso" & tipo & "_ud").Value
                        End If

                        Dim aux As Integer = Math.Floor((rst("ud_capacidad_uso").Value + (ud * udCapacidad)) / rst("ud_capacidad").Value)

                        rst("ud_capacidad_uso").Value += (ud * udCapacidad)
                        If rst("ud_capacidad_uso").Value >= rst("ud_capacidad").Value OrElse rst("ud_capacidad_uso").Value < 0 Then
                            rst("ud_capacidad_uso").Value = (rst("ud_capacidad_uso").Value - (rst("ud_capacidad").Value * aux))
                            rst("ud").Value -= aux
                        End If
                        rst.Update()

                End Select
            End If
            My.m_db.CloseRst(rst)
        End Sub

        'Funcion para actualizar el stock de tabaco
        Public Sub UpdateAlmacen_Tabaco(ByVal id_marca As Integer, ByVal ud As Integer)
            If id_marca = 0 Then Exit Sub

            Dim rst As ADODB.Recordset = Nothing
            Dim sql As String = ""

            sql = "SELECT id,ud,ud_x10"
            sql &= " FROM estanco_marcas WHERE id=" & id_marca

            rst = My.m_db.GetRst(sql)

            If rst.RecordCount > 0 Then
                Dim aux As Integer = Math.Floor((rst("ud").Value - ud) / 10)
                rst("ud").Value -= ud
                If rst("ud").Value >= 10 OrElse rst("ud").Value < 0 Then
                    rst("ud").Value = (rst("ud").Value - (10 * aux))
                    rst("ud_x10").Value += aux
                End If
                rst.Update()

            End If
            My.m_db.CloseRst(rst)
        End Sub
        ' Funcion para verificar si la aplicacion esta en version demo o no
        'Public Function IsDemo() As Boolean
        '    'my.m_app.
        '    Return False
        'End Function

        'Funcion para identificar mediante la contraseña a un empleado (para el modo seguro)
        Public Function IdentificaUser(Optional ByVal swSupremo As Boolean = False) As Integer
            Dim id As Integer = -1

            frmSolicita_Pass.Id_Ref = -1
            frmSolicita_Pass.swSupremo = swSupremo
            frmSolicita_Pass.ShowDialog()
            If frmSolicita_Pass.DialogResult <> Windows.Forms.DialogResult.OK Then
                frmSolicita_Pass.Dispose()
                Return id
            End If
            id = frmSolicita_Pass.Id_Ref
            frmSolicita_Pass.Dispose()

            Return id
        End Function

        'Funcion para obtener el camarero y validarlo
        Public Function ValidateUser(Optional ByVal swRepartidores As Boolean = False, Optional ByVal swValidate As Boolean = False) As Integer
            '<!-- Si tiene activado el modo seguro, soliticito la contraseña -->
            Dim _id As Integer = -1

            ''Si es modo seguro verifico al usuario por contraseña
            'If My.m_opt.modo_seguro Then
            '    _id = My.IdentificaUser()
            '    Return _id
            'End If

            'Compruebo el nº total de usuarios y si solo hay uno retorno su id
            Dim rst As ADODB.Recordset = My.m_db.GetRst("SELECT id FROM db_usuarios WHERE estado='ACTIVADO' AND swRepartidor=" & swRepartidores)
            If rst.RecordCount = 0 Then            'Si no hay camareros no dejo pasar
                My.m_msg.MessageError("No hay usuarios activos, debe de crearlos antes.")
                My.m_db.CloseRst(rst)
                Return _id
            End If

            If rst.RecordCount = 1 Then            'Si solo hay uno selecciono automaticamente
                _id = rst("id").Value
                My.m_db.CloseRst(rst)
                Return _id
            End If
            My.m_db.CloseRst(rst)

            ''Compruebo el nº total de repartidores
            'rst = My.m_db.GetRst("SELECT id FROM db_usuarios WHERE estado='ACTIVADO' AND swRepartidor=" & swRepartidores)
            'If rst.RecordCount = 1 Then            'Si solo hay uno selecciono automaticamente
            '    _id = rst("id").Value
            '    My.m_db.CloseRst(rst)
            '    Return _id
            'End If
            'My.m_db.CloseRst(rst)

            With frmSelect_Empleado
                .swRepartidores = swRepartidores
                .swWhoIS = swValidate
                .ShowDialog()
                If .DialogResult <> Windows.Forms.DialogResult.OK Then
                    .Dispose()
                    Return _id
                    Exit Function
                End If
                _id = .Id_Ref
                .Dispose()
            End With

            Return _id
        End Function

        ' Funcion para obtener la IP del equipo
        Public Function GetIPAddress(Optional ByVal host As String = "localhost")
            Dim str As String = "", i As Integer
            If host = "localhost" Then host = System.Net.Dns.GetHostName()

            Dim IPs As System.Net.IPHostEntry = System.Net.Dns.GetHostByName(host)
            Dim Direcciones As System.Net.IPAddress() = IPs.AddressList

            'Se despliega la lista de IP's
            For i = 0 To i = Direcciones.Length
                str &= (Direcciones(i).ToString())
            Next
            Return str
        End Function

        ' Funcion para asignar el foco a un textbox
        Public Sub AsignarFoco(ByVal TxtDest As TextBox)
            TxtDest.Select()
            TxtDest.SelectionStart = 0
            TxtDest.SelectionLength = TxtDest.TextLength
        End Sub

        ' Funcion para asignar el foco a un ComboBox
        Public Sub AsignarFoco(ByVal txt As ComboBox)
            txt.Select()
            txt.SelectionStart = 0
            txt.SelectionLength = txt.Text.Length
        End Sub


        ''' <summary>
        ''' Funcion que me obtiene el multiplicador del iva para un determinado iva
        ''' </summary>
        Public Function GetMultiplicadorIVA(ByVal dbl As Double) As Double
            Dim str As String = dbl
            str = "1" & System.Threading.Thread.CurrentThread.CurrentCulture.NumberFormat.CurrencyDecimalSeparator & IIf(dbl < 10, "0", "") & str.Replace(System.Threading.Thread.CurrentThread.CurrentCulture.NumberFormat.CurrencyDecimalSeparator, "")
            Return CDbl(str)
        End Function



        'Funcion para configurar la exportación de un registro
        Public Function Exporta(ByVal configuracion As String, Optional ByVal filter As String = "") As Integer

            Dim id As Integer = -1
            With m_Shell
                'Preconfiguro y muestro
                If Not .ConfigureApp(configuracion, True) Then Return False
                'Preconfiguro y muestro
                'AddHandler .mData_ExportId, AddressOf mData_ExportId
                'AddHandler .mData_CancelExport, AddressOf mData_CancelExport

                '.MdiParent = Me
                '.m_Form.MdiParent = Me
                '.Dock = DockStyle.Fill
                .ShowDialog()
                id = ._exportID
                ' .Select()
            End With


            'On Error Resume Next
            'Dim frm As New FrmExporta, id As Integer = -1
            'frm.Configure(configuracion, filter)
            'If frm.ShowDialog = DialogResult.OK Then id = frm.id
            'frm.Dispose()
            'frm = Nothing

            Return id
        End Function



#End Region

#Region "Funciones Sobre Contabilidad"
        'Funcion para obtener el contador de facturas y tickets
        Public Function Get_Contador(ByVal StrTipo As String) As String
            Dim StrAux As String = "", RstAux As ADODB.Recordset = My.m_db.GetRst("SELECT * FROM app_contabilidad WHERE id=" & My.m_app.GetValue("id_contable", 1))
            If RstAux.RecordCount = 0 Then Return ""
            Select Case StrTipo.ToUpper
                Case "CAJA"
                    StrAux = Format(Now, "yy") & "/" & Format(RstAux("caja_contador").Value, "0000")
                    RstAux("caja_contador").Value += 1

                Case "TICKET"
                    'StrAux = RstAux("ticket_serie").Value & Format(RstAux("ticket_contador").Value, "00000")
                    StrAux = Format(Now, "yy") & "/" & Format(RstAux("ticket_contador").Value, "00000")

                    RstAux("ticket_contador").Value += 1

                Case "FACTURA_A"
                    StrAux = RstAux("fact_serie").Value & Format(RstAux("fact_contador").Value, "0000")
                    RstAux("fact_contador").Value += 1

                Case "FACTURA_B"
                    StrAux = RstAux("factb_serie").Value & Format(RstAux("factb_contador").Value, "0000")
                    RstAux("factb_contador").Value += 1

                Case "FACTURA_C"
                    StrAux = RstAux("factc_serie").Value & Format(RstAux("factc_contador").Value, "0000")
                    RstAux("factc_contador").Value += 1

                Case Else
                    My.m_msg.MessageError(StrTipo & " no Controlado.")
            End Select
            RstAux.Update()
            My.m_db.CloseRst(RstAux)
            Return StrAux
        End Function
#End Region



#Region "Hardware"
        Private StrCod As String = ""

#Region "Lector de Codigos de Barras"
        'Structura paar las opcioens locales
        Friend Structure Stc_LectorCodigos
            Public Sw_Lector As Boolean
            Public Str_CodLector As String
        End Structure

        Public MyLector As New Stc_LectorCodigos
#End Region

#Region "Estructura de la Impresora de Tickets"
        'Structura paar las opcioens locales
        Friend Structure Stc_Hardware
            Public StrCab() As String
            Public SwCenter() As Boolean
            Public SwRed() As Boolean
            Public SwNegrita() As Boolean
            'Public SwSubrayado() As Boolean
            Public SwGrande() As Boolean

            'Detalles de puerto
            Public IdPrinter As Integer
            Public IdPort As Integer
            Public PortName As String

            Public IdComandas As Integer
            Public IdPortComandas As Integer
            Public PortNameComandas As String
            Public comandasRPT As Boolean
            'Public Str_PortPrinter As String

            Public CodEsc_Negro As String
            Public CodEsc_Rojo As String
            Public CodEsc_Negrita_True As String
            Public CodEsc_Negrita_False As String
            Public CodEsc_Subrayado_True As String
            Public CodEsc_Subrayado_False As String
            Public CodEsc_Init As String
            Public CodEsc_Cut As String
            Public CodEsc_Salto As String
            Public CodEsc_Open As String
            Public CodEsc_TextNormal As String
            Public CodEsc_TextGrande As String

            Public CodEsc_Cr As String
            Public Ancho As Integer

            'Detalles para CashDrawer Directo
            Public swCashDrawer As Boolean
            Public CD_Port_Address As String
            Public CD_Port_Open As String
            Public CD_Port_Close As String
            Public CD_Port_SBit As String

            'Detales de la balanza PC
            Public Balanza_Enabled As Boolean
            Public Balanza_Port As String
            Public Balanza_tipo As Integer

            Public swCashDrawerCOM As Boolean
            Public ccom_port As Integer


            'Detalles de cashlogic
            Public cashlogy_sw As Boolean
            Public cashlogy_ip As String
            Public cashlogy_port As String
        End Structure

        Public MyHardware As New Stc_Hardware
        Public MyComanda As New Stc_Hardware
#End Region

#Region "Carga de Valores de Hardware"
        'Funcion que me lee la configuración de los codigos de escape de la impresora
        Public Function Load_OptionsHardware() As Boolean
            'Preconfiguramos los array de la impresora
            ReDim My.MyHardware.StrCab(8)
            ReDim My.MyHardware.SwCenter(8)
            ReDim My.MyHardware.SwNegrita(8)
            ReDim My.MyHardware.SwRed(8)
            ReDim My.MyHardware.SwGrande(8)
            My.MyHardware.CodEsc_Negro = ""
            My.MyHardware.CodEsc_Rojo = ""
            My.MyHardware.CodEsc_Negrita_True = ""
            My.MyHardware.CodEsc_Negrita_False = ""
            My.MyHardware.CodEsc_Subrayado_True = ""
            My.MyHardware.CodEsc_Subrayado_False = ""
            My.MyHardware.CodEsc_Init = ""
            My.MyHardware.CodEsc_Cut = ""
            My.MyHardware.CodEsc_Salto = ""
            My.MyHardware.CodEsc_Open = ""
            My.MyHardware.CodEsc_Cr = ""
            My.MyHardware.CodEsc_TextNormal = ""
            My.MyHardware.CodEsc_TextGrande = ""


            'Preconfiguramos los array de la impresora
            ReDim My.MyComanda.StrCab(8)
            ReDim My.MyComanda.SwCenter(8)
            ReDim My.MyComanda.SwNegrita(8)
            ReDim My.MyComanda.SwRed(8)
            ReDim My.MyComanda.SwGrande(8)
            My.MyComanda.CodEsc_Negro = ""
            My.MyComanda.CodEsc_Rojo = ""
            My.MyComanda.CodEsc_Negrita_True = ""
            My.MyComanda.CodEsc_Negrita_False = ""
            My.MyComanda.CodEsc_Subrayado_True = ""
            My.MyComanda.CodEsc_Subrayado_False = ""
            My.MyComanda.CodEsc_Init = ""
            My.MyComanda.CodEsc_Cut = ""
            My.MyComanda.CodEsc_Salto = ""
            My.MyComanda.CodEsc_Open = ""
            My.MyComanda.CodEsc_Cr = ""
            My.MyComanda.CodEsc_TextNormal = ""
            My.MyComanda.CodEsc_TextGrande = ""


            'Leo las opcioens locales
            My.MyHardware.IdPrinter = My.m_app.GetValue("id_printer", 1)          'Impresora default por defecto
            My.MyHardware.IdPort = My.m_app.GetValue("id_portprinter", 0)
            My.MyHardware.PortName = My.m_app.GetValue("portname", "NINGUNO")


            My.MyComanda.IdComandas = My.m_app.GetValue("id_comandas", 1)          'Impresora default por defecto
            My.MyComanda.IdPortComandas = My.m_app.GetValue("id_portcomandas", 0)
            My.MyComanda.PortNameComandas = My.m_app.GetValue("portnamecomandas", "NINGUNO")


            ' Cargo opciones de cashlogic
            My.MyHardware.cashlogy_sw = CBool(My.m_app.GetValue("cashlogy_enabled", False))
            My.MyHardware.cashlogy_ip = My.m_app.GetValue("cashlogy_ip", "127.0.0.1")
            My.MyHardware.cashlogy_port = My.m_app.GetValue("cashlogy_port", "8092")

            'My.m_app.SetValue("portname") = Me.CbPrinterPort.Text

            MyLector.Sw_Lector = My.m_app.GetValue("swlector", False)
            MyLector.Str_CodLector = My.m_app.GetValue("codlector", "$")

            'Cargamos la configuración del ticket
            Dim RstAux As ADODB.Recordset = My.m_db.GetRst("SELECT * FROM app_ticket WHERE id_empresa=" & My.m_app.GetValue("id_empresa"))
            If RstAux.RecordCount = 0 Then
                My.m_msg.MessageError("Error localizando la configuración del ticket")
                Return False
            End If

            Dim i As Integer
            For i = 1 To 8
                My.MyHardware.StrCab(i) = RstAux("ticket_cab_" & i).Value & ""
                My.MyHardware.SwCenter(i) = RstAux("ticket_center_" & i).Value & ""
                My.MyHardware.SwNegrita(i) = RstAux("ticket_strong_" & i).Value & ""
                My.MyHardware.SwRed(i) = RstAux("ticket_red_" & i).Value & ""
                My.MyHardware.SwGrande(i) = RstAux("ticket_grande_" & i).Value & ""

                My.MyComanda.StrCab(i) = RstAux("ticket_cab_" & i).Value & ""
                My.MyComanda.SwCenter(i) = RstAux("ticket_center_" & i).Value & ""
                My.MyComanda.SwNegrita(i) = RstAux("ticket_strong_" & i).Value & ""
                My.MyComanda.SwRed(i) = RstAux("ticket_red_" & i).Value & ""
                My.MyComanda.SwGrande(i) = RstAux("ticket_grande_" & i).Value & ""


            Next



            'My.MyComanda.comandasRPT = RstAux("swComandasRPT").Value







            'Cash Drawer
            My.MyHardware.swCashDrawer = My.m_app.GetValue("cd_enabled", False)
            My.MyHardware.CD_Port_Address = My.m_app.GetValue("cd_port_address", "4B8")
            My.MyHardware.CD_Port_Open = My.m_app.GetValue("cd_port_open", "0C")
            My.MyHardware.CD_Port_Close = My.m_app.GetValue("cd_port_close", "00")
            My.MyHardware.CD_Port_SBit = My.m_app.GetValue("cd_port_sbit", "20")

            My.MyHardware.swCashDrawerCOM = My.m_app.GetValue("ccom_enabled", False)
            My.MyHardware.ccom_port = My.m_app.GetValue("ccom_port", 0)

            'Balanza PC
            My.MyHardware.Balanza_Enabled = CBool(My.m_app.GetValue("balanza_enabled", False))
            My.MyHardware.Balanza_tipo = My.m_app.GetValue("balanza_tipo", 0)
            My.MyHardware.Balanza_Port = My.m_app.GetValue("balanza_port", "NINGUNO")

            My.m_db.CloseRst(RstAux)

            'Configuro el puerto
            'If Not IsNothing(MyPort) Then MyPort.Dispose()
            'MyPort = New m_Crypto.ioParerellPort(IIf(My.MyHardware.IdPort = 0, "", "LPT" & My.MyHardware.IdPort))




            'Si no tiene activado ningun puerto no cargo
            If My.MyHardware.IdPort = 0 Then Return False

            RstAux = My.m_db.GetRst("SELECT * FROM app_printers WHERE id=" & My.MyHardware.IdPrinter)

            For i = 1 To 5
                If Not (RstAux("black_" & i).Value) Is System.DBNull.Value AndAlso CStr(RstAux("black_" & i).Value).Length > 0 Then My.MyHardware.CodEsc_Negro &= Chr(RstAux("black_" & i).Value)
                If Not (RstAux("red_" & i).Value) Is System.DBNull.Value AndAlso CStr(RstAux("red_" & i).Value).Length > 0 Then My.MyHardware.CodEsc_Rojo &= Chr(RstAux("red_" & i).Value)
                If Not (RstAux("strong_activo_" & i).Value) Is System.DBNull.Value AndAlso CStr(RstAux("strong_activo_" & i).Value).Length > 0 Then My.MyHardware.CodEsc_Negrita_True &= Chr(RstAux("strong_activo_" & i).Value)
                If Not (RstAux("strong_desactivo_" & i).Value) Is System.DBNull.Value AndAlso CStr(RstAux("strong_desactivo_" & i).Value).Length > 0 Then My.MyHardware.CodEsc_Negrita_False &= Chr(RstAux("strong_desactivo_" & i).Value)


                'If CStr(RstAux("sub_desactivo_" & i).Value).Length > 0 Then My.MyHardware.CodEsc_Subrayado_False &= Chr(RstAux("sub_desactivo_" & i).Value)
                'If CStr(RstAux("sub_activo_" & i).Value).Length > 0 Then My.MyHardware.CodEsc_Subrayado_True &= Chr(RstAux("sub_activo_" & i).Value)

                If Not (RstAux("sub_activo_" & i).Value) Is System.DBNull.Value AndAlso CStr(RstAux("sub_activo_" & i).Value).Length > 0 Then My.MyHardware.CodEsc_Subrayado_True &= Chr(RstAux("sub_activo_" & i).Value)
                If Not (RstAux("sub_desactivo_" & i).Value) Is System.DBNull.Value AndAlso CStr(RstAux("sub_desactivo_" & i).Value).Length > 0 Then My.MyHardware.CodEsc_Subrayado_False &= Chr(RstAux("sub_desactivo_" & i).Value)

                If Not (RstAux("init_" & i).Value) Is System.DBNull.Value AndAlso CStr(RstAux("init_" & i).Value).Length > 0 Then My.MyHardware.CodEsc_Init &= Chr(RstAux("init_" & i).Value)
                If Not (RstAux("cut_" & i).Value) Is System.DBNull.Value AndAlso CStr(RstAux("cut_" & i).Value).Length > 0 Then My.MyHardware.CodEsc_Cut &= Chr(RstAux("cut_" & i).Value)
                If Not (RstAux("salto_" & i).Value) Is System.DBNull.Value AndAlso CStr(RstAux("salto_" & i).Value).Length > 0 Then My.MyHardware.CodEsc_Salto &= Chr(RstAux("salto_" & i).Value)
                If Not (RstAux("normal_" & i).Value) Is System.DBNull.Value AndAlso CStr(RstAux("normal_" & i).Value).Length > 0 Then My.MyHardware.CodEsc_TextNormal &= Chr(RstAux("normal_" & i).Value)
                If Not (RstAux("grande_" & i).Value) Is System.DBNull.Value AndAlso CStr(RstAux("grande_" & i).Value).Length > 0 Then My.MyHardware.CodEsc_TextGrande &= Chr(RstAux("grande_" & i).Value)
                If Not (RstAux("open_" & i).Value) Is System.DBNull.Value AndAlso CStr(RstAux("open_" & i).Value).Length > 0 Then My.MyHardware.CodEsc_Open &= Chr(RstAux("open_" & i).Value)


                '######## COMANDAS
                '##### Cargo la configuración de la impresora de COMANDAS
                If Not (RstAux("black_" & i).Value) Is System.DBNull.Value AndAlso CStr(RstAux("black_" & i).Value).Length > 0 Then My.MyComanda.CodEsc_Negro &= Chr(RstAux("black_" & i).Value)
                If Not (RstAux("red_" & i).Value) Is System.DBNull.Value AndAlso CStr(RstAux("red_" & i).Value).Length > 0 Then My.MyComanda.CodEsc_Rojo &= Chr(RstAux("red_" & i).Value)
                If Not (RstAux("strong_activo_" & i).Value) Is System.DBNull.Value AndAlso CStr(RstAux("strong_activo_" & i).Value).Length > 0 Then My.MyComanda.CodEsc_Negrita_True &= Chr(RstAux("strong_activo_" & i).Value)
                If Not (RstAux("strong_desactivo_" & i).Value) Is System.DBNull.Value AndAlso CStr(RstAux("strong_desactivo_" & i).Value).Length > 0 Then My.MyComanda.CodEsc_Negrita_False &= Chr(RstAux("strong_desactivo_" & i).Value)


                'If CStr(RstAux("sub_desactivo_" & i).Value).Length > 0 Then My.MyComanda.CodEsc_Subrayado_False &= Chr(RstAux("sub_desactivo_" & i).Value)
                'If CStr(RstAux("sub_activo_" & i).Value).Length > 0 Then My.MyComanda.CodEsc_Subrayado_True &= Chr(RstAux("sub_activo_" & i).Value)

                If Not (RstAux("sub_activo_" & i).Value) Is System.DBNull.Value AndAlso CStr(RstAux("sub_activo_" & i).Value).Length > 0 Then My.MyComanda.CodEsc_Subrayado_True &= Chr(RstAux("sub_activo_" & i).Value)
                If Not (RstAux("sub_desactivo_" & i).Value) Is System.DBNull.Value AndAlso CStr(RstAux("sub_desactivo_" & i).Value).Length > 0 Then My.MyComanda.CodEsc_Subrayado_False &= Chr(RstAux("sub_desactivo_" & i).Value)

                If Not (RstAux("init_" & i).Value) Is System.DBNull.Value AndAlso CStr(RstAux("init_" & i).Value).Length > 0 Then My.MyComanda.CodEsc_Init &= Chr(RstAux("init_" & i).Value)
                If Not (RstAux("cut_" & i).Value) Is System.DBNull.Value AndAlso CStr(RstAux("cut_" & i).Value).Length > 0 Then My.MyComanda.CodEsc_Cut &= Chr(RstAux("cut_" & i).Value)
                If Not (RstAux("salto_" & i).Value) Is System.DBNull.Value AndAlso CStr(RstAux("salto_" & i).Value).Length > 0 Then My.MyComanda.CodEsc_Salto &= Chr(RstAux("salto_" & i).Value)
                If Not (RstAux("normal_" & i).Value) Is System.DBNull.Value AndAlso CStr(RstAux("normal_" & i).Value).Length > 0 Then My.MyComanda.CodEsc_TextNormal &= Chr(RstAux("normal_" & i).Value)
                If Not (RstAux("grande_" & i).Value) Is System.DBNull.Value AndAlso CStr(RstAux("grande_" & i).Value).Length > 0 Then My.MyComanda.CodEsc_TextGrande &= Chr(RstAux("grande_" & i).Value)
                If Not (RstAux("open_" & i).Value) Is System.DBNull.Value AndAlso CStr(RstAux("open_" & i).Value).Length > 0 Then My.MyComanda.CodEsc_Open &= Chr(RstAux("open_" & i).Value)


            Next

            If Not (RstAux("cr_return").Value) Is System.DBNull.Value AndAlso CStr(RstAux("cr_return").Value).Length > 0 Then My.MyHardware.CodEsc_Cr = Chr(RstAux("cr_return").Value)
            If Not (RstAux("ancho").Value) Is System.DBNull.Value AndAlso CStr(RstAux("ancho").Value).Length > 0 Then My.MyHardware.Ancho = RstAux("ancho").Value

            If Not (RstAux("cr_return").Value) Is System.DBNull.Value AndAlso CStr(RstAux("cr_return").Value).Length > 0 Then My.MyComanda.CodEsc_Cr = Chr(RstAux("cr_return").Value)
            If Not (RstAux("ancho").Value) Is System.DBNull.Value AndAlso CStr(RstAux("ancho").Value).Length > 0 Then My.MyComanda.Ancho = RstAux("ancho").Value


            My.m_db.CloseRst(RstAux)

        End Function


        'Cargo en los combos las impresoras
        Public Sub LoadPrinters(ByVal cb As ComboBox)
            Dim i As Integer, StrAux As String = ""
            Dim srcPrint As New System.Drawing.Printing.PrinterSettings
            cb.Items.Clear()

            For i = 0 To Printing.PrinterSettings.InstalledPrinters.Count - 1
                StrAux = Printing.PrinterSettings.InstalledPrinters(i)
                cb.Items.Add(StrAux)

                'Selecciono la impresora por defecto
                If StrAux = srcPrint.PrinterName Then cb.SelectedIndex = cb.Items.Count - 1
            Next
        End Sub
#End Region

#Region "Cashlogy"
        Private _cashlogyLastComand As String = ""
        'ENVIO de COMANDO
        Public Sub cashlogy_Send(ByVal cmd As String)
            My.Application.cashlogy_bytes = Nothing
            My.Application.cashlogy_sCadena = ""

            My.Application.cashlogy_sCadena = cmd
            My.Application.cashlogy_bytes = System.Text.Encoding.ASCII.GetBytes(My.Application.cashlogy_sCadena)
            My.Application.sIOCashlogy.Write(My.Application.cashlogy_bytes, 0, My.Application.cashlogy_bytes.Length)

            My.Application.cashlogy_sCadena = ""
            My.Application.cashlogy_bytes = Nothing

            _cashlogyLastComand = cmd
        End Sub

        'LECTURA DE DATOS
        Public Function cashlogy_read(Optional ByVal MaxSecondsRetry As Integer = 50) As String
            Dim i As Integer = 0
            'Realizo lectura del buffer (OK de inicializacion)
start:
            Threading.Thread.Sleep(200)
            While True
                If Not My.Application.sIOCashlogy.DataAvailable Then
                    Threading.Thread.Sleep(1000)
                    i += 1

                    If i > MaxSecondsRetry Then
                        MsgBox("Imposible realizar lectura CASHLOGY, tiempo de espera agotado.", MsgBoxStyle.Critical)
                        Return Nothing
                    End If
                Else
                    ReDim My.Application.cashlogy_bytes(My.Application.sckCashlogy.ReceiveBufferSize)
                    My.Application.sIOCashlogy.Read(My.Application.cashlogy_bytes, 0, My.Application.cashlogy_bytes.Length)
                    My.Application.cashlogy_sCadena = System.Text.Encoding.ASCII.GetString(My.Application.cashlogy_bytes, 0, My.Application.cashlogy_bytes.Length)

                    If My.Application.cashlogy_sCadena.Substring(0, 9) = "#ER:BUSY#" Then
                        If MsgBox("ERROR:BUSY, ¿desea reintentar el comando: " & _cashlogyLastComand, MsgBoxStyle.Question + vbYesNo) <> vbYes Then Return My.Application.cashlogy_sCadena
                        cashlogy_Send(_cashlogyLastComand)
                        GoTo start
                    End If

                    Return My.Application.cashlogy_sCadena
                End If
            End While

            Return Nothing
        End Function

        'RESETEO CASHLOGY
        Private Function cashlogy_reset() As Boolean
            Dim i As Integer = 0
            My.Application.cashlogy_sCadena = "#Z#"
            My.Application.cashlogy_bytes = System.Text.Encoding.ASCII.GetBytes(My.Application.cashlogy_sCadena)
            My.Application.sIOCashlogy.Write(My.Application.cashlogy_bytes, 0, My.Application.cashlogy_bytes.Length)

            My.Application.cashlogy_sCadena = ""
            My.Application.cashlogy_bytes = Nothing


            'Realizo lectura del buffer (OK de inicializacion)
            Threading.Thread.Sleep(1000)
            While True
                If Not My.Application.sIOCashlogy.DataAvailable Then
                    Threading.Thread.Sleep(1000)
                    'System.Windows.Forms.Application.DoEvents()
                    i += 1

                    If i > 50 Then
                        MsgBox("Imposible resetear CASHLOGY, tiempo de espera agotado.", MsgBoxStyle.Critical)
                        My.Application.sckCashlogy.Close()
                        My.Application.sckCashlogy = Nothing
                        Exit Function
                    End If
                Else

                    ReDim My.Application.cashlogy_bytes(My.Application.sckCashlogy.ReceiveBufferSize)
                    My.Application.sIOCashlogy.Read(My.Application.cashlogy_bytes, 0, My.Application.cashlogy_bytes.Length)
                    My.Application.cashlogy_sCadena = System.Text.Encoding.ASCII.GetString(My.Application.cashlogy_bytes, 0, My.Application.cashlogy_bytes.Length)

                    If My.Application.cashlogy_sCadena.Substring(0, 3) = "#0#" Then
                        Return True
                    ElseIf My.Application.cashlogy_sCadena.Substring(0, 3) <> "#a#" Then
                        MsgBox("Imposible resetear CASHLOGIC, comando no reconocido: " & My.Application.cashlogy_sCadena, MsgBoxStyle.Critical)
                        My.Application.sckCashlogy.Close()
                        My.Application.sckCashlogy = Nothing

                        My.Application.sIOCashlogy.Close()
                        My.Application.sIOCashlogy = Nothing

                        Exit Function
                    Else
                        ' TODO OK
                        Return True
                    End If
                End If
            End While

            Return False
        End Function

#End Region


#Region "Impresion de Tickets"
        Public Sub PrintTicket(ByVal Id_Ticket As Integer, Optional ByVal dblEntrega As Double = 0, Optional ByVal NotOpenCajon As Boolean = False, Optional ByVal id_pedido As Integer = 0)
            If My.MyHardware.IdPort = 0 Then Exit Sub
            Dim StrAux As String, i As Integer, j As Integer

            Dim dblBase_4 As Double = 0, dblBase_7 As Double = 0, dblBase_16 As Double = 0
            Dim dblIVA_4 As Double = 0, dblIVA_7 As Double = 0, dblIVA_16 As Double = 0

            Dim rstCompose As ADODB.Recordset = Nothing

            If My.MyHardware.PortName = "REPORT" Then
                Dim RptPrint As CrystalDecisions.CrystalReports.Engine.ReportDocument
                RptPrint = New crtTicket
                'CType(RptPrint, crtTicket).DataDefinition.FormulaFields("Fh_Desde").Text = "'" & Format(Now.AddDays(-7), "dd/MMMM/yyyy") & "'"

                RptPrint.RecordSelectionFormula = "{db_tickets.id}=" & Id_Ticket
                RptPrint.PrintToPrinter(1, False, 0, 0)
                RptPrint.Dispose()
                'MsgBox("Genero por crystal")
                Exit Sub
            End If

            'Primero abro el cajon
            If Not NotOpenCajon Then OpenCajon()


            If My.MyHardware.PortName.Substring(0, 3) = "COM" Then
                '<!--### IMPRESIÓN POR PUERTO SERIE ###-->
                Try
                    Dim _port As IO.Ports.SerialPort
                    _port = New IO.Ports.SerialPort(My.MyHardware.PortName, 9600, IO.Ports.Parity.None, 8, IO.Ports.StopBits.One)
                    _port.DiscardNull = True
                    _port.WriteBufferSize = 2024
                    _port.DtrEnable = True
                    _port.Handshake = IO.Ports.Handshake.None

                    _port.Open()

                    Dim RstCab As ADODB.Recordset, RstLines As ADODB.Recordset
                    RstCab = My.m_db.GetRst("SELECT db_tickets.id,db_tickets.fh_alta,db_tickets.fh_finaliza,db_tickets.total,db_tickets.id_referencia,db_usuarios.name FROM db_tickets,db_usuarios WHERE db_usuarios.id=db_tickets.id_user AND db_tickets.id=" & Id_Ticket)
                    RstLines = My.m_db.GetRst("SELECT * FROM db_tickets_lines WHERE id_ticket=" & Id_Ticket & " ORDER BY id")
                    If RstCab.RecordCount = 0 Then
                        MsgBox("Error localizando el ticket.", MsgBoxStyle.Critical, "Imprimir Ticket")
                        Exit Sub
                    End If

                    If My.MyHardware.CodEsc_Init.Length > 0 Then _port.Write(My.MyHardware.CodEsc_Init & My.MyHardware.CodEsc_Cr)
                    StrCod = ""
                    'Imprimo la cabezera
                    For i = 1 To 4
                        StrAux = My.MyHardware.StrCab(i)
                        StrCod = ""
                        If StrAux.Length > My.MyHardware.Ancho Then StrAux = StrAux.Substring(1, My.MyHardware.Ancho)
                        StrCod = Ticket_ConfigTextColor(StrCod, My.MyHardware.SwRed(i))
                        StrCod = Ticket_ConfigTextStrong(StrCod, My.MyHardware.SwNegrita(i))
                        StrCod = Ticket_ConfigTextSize(StrCod, My.MyHardware.SwGrande(i))
                        StrAux = Ticket_ConfigTextAling(StrAux, IIf(My.MyHardware.SwCenter(i), 2, 0), My.MyHardware.SwGrande(i))
                        If My.MyHardware.StrCab(i).Length <> 0 Then _port.Write(StrCod & StrAux & My.MyHardware.CodEsc_Cr)
                    Next
                    _port.Write(My.MyHardware.CodEsc_Cr)
                    _port.Close()
                    _port.Open()

                    'Imprimo la cabezera
                    StrAux = My.MyHardware.CodEsc_TextNormal & "Ref.: " & Format(RstCab("id").Value, "000000")
                    StrAux &= Space(My.MyHardware.Ancho - StrAux.Length - Format(RstCab("fh_alta").Value, "dd/MM/yyyy HH:mm").Length) & Format(RstCab("fh_alta").Value, "dd/MM/yyyy HH:mm")
                    _port.Write(StrAux & My.MyHardware.CodEsc_Cr)

                    Select Case My.m_opt.modo_compatibilidad
                        Case "COMERCIO"
                            If RstCab("id_referencia").Value = -1 Then
                                StrAux = My.MyHardware.CodEsc_TextNormal & "Servicio: CAJA DIRECTA"
                            Else
                                'Obtengo la mesa
                                Dim rst As ADODB.Recordset = My.m_db.GetRst("SELECT name FROM db_design WHERE id=" & RstCab("id_referencia").Value)
                                StrAux = My.MyHardware.CodEsc_TextNormal & "Servicio: " & rst("name").Value
                                My.m_db.CloseRst(rst)
                            End If

                        Case Else
                            If Not IsDBNull(RstCab("fh_finaliza").Value) AndAlso DateDiff(DateInterval.Minute, CDate(RstCab("fh_alta").Value), CDate(RstCab("fh_finaliza").Value)) > 1 Then
                                StrAux = My.MyHardware.CodEsc_TextNormal & "Hora: " & Format(RstCab("fh_finaliza").Value, "dd/MM/yyyy HH:mm")
                                _port.Write(StrAux & My.MyHardware.CodEsc_Cr)
                            End If

                            StrAux = My.MyHardware.CodEsc_TextNormal & "Camarero: " & RstCab("name").Value
                            _port.Write(StrAux & My.MyHardware.CodEsc_Cr)
                            If RstCab("id_referencia").Value = -1 Then
                                StrAux = My.MyHardware.CodEsc_TextNormal & "Mesa: CAJA DIRECTA"
                            Else
                                'Obtengo la mesa
                                Dim rst As ADODB.Recordset = My.m_db.GetRst("SELECT name FROM db_design WHERE id=" & RstCab("id_referencia").Value)
                                StrAux = My.MyHardware.CodEsc_TextNormal & "Mesa: " & rst("name").Value
                                My.m_db.CloseRst(rst)
                            End If

                            _port.Write(" " & My.MyHardware.CodEsc_Cr)
                    End Select
                    _port.Close()
                    _port.Open()

                    Select Case My.m_opt.modo_compatibilidad
                        Case "COMERCIO"
                            StrAux = " " & My.MyHardware.CodEsc_Subrayado_True & "Concepto" & My.MyHardware.CodEsc_Subrayado_False
                            StrAux &= Space(My.MyHardware.Ancho - 29) & My.MyHardware.CodEsc_Subrayado_True & "Precio" & My.MyHardware.CodEsc_Subrayado_False
                            StrAux &= Space(2) & My.MyHardware.CodEsc_Subrayado_True & "Cant." & My.MyHardware.CodEsc_Subrayado_False
                            StrAux &= Space(2) & My.MyHardware.CodEsc_Subrayado_True & "Total" & My.MyHardware.CodEsc_Subrayado_False
                            _port.Write(StrAux & My.MyHardware.CodEsc_Cr)
                        Case Else
                            StrAux = " " & My.MyHardware.CodEsc_Subrayado_True & "Articulo" & My.MyHardware.CodEsc_Subrayado_False
                            StrAux &= Space(My.MyHardware.Ancho - 20) & My.MyHardware.CodEsc_Subrayado_True & "Ud." & My.MyHardware.CodEsc_Subrayado_False
                            StrAux &= Space(2) & My.MyHardware.CodEsc_Subrayado_True & "Total" & My.MyHardware.CodEsc_Subrayado_False
                            _port.Write(StrAux & My.MyHardware.CodEsc_Cr)
                    End Select
                    _port.Close()
                    _port.Open()

                    While Not RstLines.EOF
                        Select Case My.m_opt.modo_compatibilidad
                            Case "COMERCIO"
                                StrAux = " " & RstLines("name").Value
                                If StrAux.Length > My.MyHardware.Ancho - 22 Then StrAux = StrAux.Substring(0, My.MyHardware.Ancho - 22)
                                StrAux &= Space(My.MyHardware.Ancho - 20 - StrAux.Length)

                                StrAux &= Space(6 - Format(RstLines("pvp_ud").Value, "##0.00").Length) & Format(RstLines("pvp_ud").Value, "##0.00")
                                StrAux &= Space(7 - Format(RstLines("ud").Value, "##0.##").Length) & Format(RstLines("ud").Value, "##0.##")

                                j = (6 - Format(RstLines("total").Value, "##0.00").Length)
                                If j < 0 Then j = 0

                                StrAux &= " " & Space(j) & Format(RstLines("total").Value, "##0.00")

                            Case Else
                                StrAux = " " & RstLines("name").Value
                                If StrAux.Length > My.MyHardware.Ancho - 13 Then StrAux = StrAux.Substring(0, My.MyHardware.Ancho - 13)
                                StrAux &= Space(My.MyHardware.Ancho - 11 - StrAux.Length)
                                StrAux &= Space(3 - Format(RstLines("ud").Value, "##0").Length) & Format(RstLines("ud").Value, "##0")

                                j = (6 - Format(RstLines("total").Value, "##0.00").Length)
                                If j < 0 Then j = 0

                                StrAux &= " " & Space(j) & Format(RstLines("total").Value, "##0.00")
                        End Select

                        _port.Write(FixCHARISO(StrAux) & My.MyHardware.CodEsc_Cr)
                        _port.Close()
                        _port.Open()

                        RstLines.MoveNext()
                    End While

                    StrAux = My.MyHardware.CodEsc_TextNormal & " " & My.MyHardware.CodEsc_Subrayado_True & Space(My.MyHardware.Ancho - 2) & My.MyHardware.CodEsc_Subrayado_False
                    _port.Write(StrAux & My.MyHardware.CodEsc_Cr)
                    _port.Close()
                    _port.Open()

                    i = (6 - Format(RstCab("total").Value, "###0.00").Length)
                    If i < 0 Then i = 0

                    StrAux = My.MyHardware.CodEsc_Rojo & Space(My.MyHardware.Ancho - 11) & My.MyHardware.CodEsc_TextGrande & My.MyHardware.CodEsc_Negrita_True & Space(i) & Format(RstCab("total").Value, "###0.00") & " E" & My.MyHardware.CodEsc_Negrita_False & My.MyHardware.CodEsc_TextNormal
                    _port.Write(StrAux & My.MyHardware.CodEsc_Cr)

                    If dblEntrega <> 0 Then          'He entregado algo
                        StrAux = "Entrega: " & Format(dblEntrega, "###0.00")
                        StrAux = Space(My.MyHardware.Ancho - StrAux.Length - 1) & StrAux
                        _port.Write(My.MyHardware.CodEsc_Negro & StrAux & My.MyHardware.CodEsc_Cr)

                        StrAux = "Cambio: " & Format(dblEntrega - RstCab("total").Value, "###0.00")
                        StrAux = Space(My.MyHardware.Ancho - StrAux.Length - 1) & StrAux
                        _port.Write(StrAux & My.MyHardware.CodEsc_Cr)
                        _port.Close()
                        _port.Open()
                    End If


                    StrAux = My.MyHardware.CodEsc_Negro & Space(My.MyHardware.Ancho - 14) & "(IVA INCLUIDO)"
                    _port.Write(StrAux & My.MyHardware.CodEsc_Cr)

                    _port.Write(My.MyHardware.CodEsc_Negro & My.MyHardware.CodEsc_Cr)
                    _port.Close()
                    _port.Open()

                    'Imprimo las lineas
                    For i = 5 To 8
                        StrAux = My.MyHardware.StrCab(i)
                        StrCod = ""
                        If StrAux.Length > My.MyHardware.Ancho Then StrAux = StrAux.Substring(1, My.MyHardware.Ancho)
                        StrCod = Ticket_ConfigTextColor(StrCod, My.MyHardware.SwRed(i))
                        StrCod = Ticket_ConfigTextStrong(StrCod, My.MyHardware.SwNegrita(i))
                        StrCod = Ticket_ConfigTextSize(StrCod, My.MyHardware.SwGrande(i))
                        StrAux = Ticket_ConfigTextAling(StrAux, IIf(My.MyHardware.SwCenter(i), 2, 0), My.MyHardware.SwGrande(i))
                        If StrAux.Length <> 0 Then _port.Write(StrCod & StrAux & My.MyHardware.CodEsc_Cr)
                    Next
                    _port.Write(My.MyHardware.CodEsc_Salto & My.MyHardware.CodEsc_Cr)
                    If Len(My.MyHardware.CodEsc_Cut) > 0 Then _port.Write(My.MyHardware.CodEsc_Cut & My.MyHardware.CodEsc_Cr)
                    _port.Close()
                    _port.Dispose()

                Catch ex As Exception
                    MsgBox(ex.Message)
                End Try
            ElseIf My.MyHardware.PortName.Substring(0, 3) = "LPT" Then
                '<!--### IMPRESIÓN POR PUERTO PARALELO ###-->
                Dim _port As m_Crypto.ioParerellPort
                _port = New m_Crypto.ioParerellPort("LPT" & My.MyHardware.IdPort)

                Dim RstCab As ADODB.Recordset, RstLines As ADODB.Recordset
                RstCab = My.m_db.GetRst("SELECT db_tickets.id,db_tickets.fh_alta,db_tickets.fh_finaliza,db_tickets.total,db_tickets.id_referencia,db_usuarios.name FROM db_tickets,db_usuarios WHERE db_usuarios.id=db_tickets.id_user AND db_tickets.id=" & Id_Ticket)
                RstLines = My.m_db.GetRst("SELECT * FROM db_tickets_lines WHERE id_ticket=" & Id_Ticket & " ORDER BY id")
                If RstCab.RecordCount = 0 Then
                    MsgBox("Error localizando el ticket.", MsgBoxStyle.Critical, "Imprimir Ticket")
                    Exit Sub
                End If

                If My.MyHardware.CodEsc_Init.Length > 0 Then _port.Write(My.MyHardware.CodEsc_Init & My.MyHardware.CodEsc_Cr)
                StrCod = ""
                'Imprimo la cabezera
                For i = 1 To 4
                    StrAux = My.MyHardware.StrCab(i)
                    StrCod = ""
                    If StrAux.Length > My.MyHardware.Ancho Then StrAux = StrAux.Substring(1, My.MyHardware.Ancho)
                    StrCod = Ticket_ConfigTextColor(StrCod, My.MyHardware.SwRed(i))
                    StrCod = Ticket_ConfigTextStrong(StrCod, My.MyHardware.SwNegrita(i))
                    StrCod = Ticket_ConfigTextSize(StrCod, My.MyHardware.SwGrande(i))
                    StrAux = Ticket_ConfigTextAling(StrAux, IIf(My.MyHardware.SwCenter(i), 2, 0), My.MyHardware.SwGrande(i))
                    If My.MyHardware.StrCab(i).Length <> 0 Then _port.Write(StrCod & StrAux & My.MyHardware.CodEsc_Cr)
                Next
                _port.Write(My.MyHardware.CodEsc_Cr)

                'Si es un pedido imprimo los detalles
                If id_pedido > 0 Then
                    Dim rstPedido As ADODB.Recordset = My.m_db.GetRst("SELECT db_pedidos.*,db_clientes.name_fiscal FROM db_pedidos,db_clientes WHERE db_pedidos.id_cliente=db_clientes.id AND db_pedidos.id=" & id_pedido)
                    StrAux = My.MyHardware.CodEsc_TextNormal & "Cliente: " & vbCrLf & My.MyHardware.CodEsc_TextGrande & rstPedido("name_fiscal").Value & My.MyHardware.CodEsc_TextGrande & My.MyHardware.CodEsc_Cr
                    StrAux &= My.MyHardware.CodEsc_TextNormal & "Telefono: " & rstPedido("tlf").Value & My.MyHardware.CodEsc_Cr
                    StrAux &= My.MyHardware.CodEsc_TextNormal & "Direccion: " & My.MyHardware.CodEsc_Negrita_True & rstPedido("dir").Value & rstPedido("dir_n").Value & "" & rstPedido("dir_bloque").Value & "" & My.MyHardware.CodEsc_Negrita_False & My.MyHardware.CodEsc_Cr
                    _port.Write(FixCHARISO(StrAux) & My.MyHardware.CodEsc_Cr)
                End If


                'Imprimo la cabezera
                StrAux = My.MyHardware.CodEsc_TextNormal & "Ref.: " & Format(RstCab("id").Value, "000000")
                StrAux &= Space(My.MyHardware.Ancho - StrAux.Length - Format(RstCab("fh_alta").Value, "dd/MM/yyyy HH:mm").Length) & Format(RstCab("fh_alta").Value, "dd/MM/yyyy HH:mm")
                _port.Write(StrAux & My.MyHardware.CodEsc_Cr)

                Select Case My.m_opt.modo_compatibilidad
                    Case "COMERCIO"
                        If RstCab("id_referencia").Value = -1 Then
                            StrAux = My.MyHardware.CodEsc_TextNormal & "Servicio: CAJA DIRECTA"
                        Else
                            'Obtengo la mesa
                            Dim rst As ADODB.Recordset = My.m_db.GetRst("SELECT name FROM db_design WHERE id=" & RstCab("id_referencia").Value)
                            StrAux = My.MyHardware.CodEsc_TextNormal & "Servicio: " & rst("name").Value
                            My.m_db.CloseRst(rst)
                        End If

                    Case Else
                        If Not IsDBNull(RstCab("fh_finaliza").Value) AndAlso DateDiff(DateInterval.Minute, CDate(RstCab("fh_alta").Value), CDate(RstCab("fh_finaliza").Value)) > 1 Then
                            StrAux = My.MyHardware.CodEsc_TextNormal & "Hora: " & Format(RstCab("fh_finaliza").Value, "dd/MM/yyyy HH:mm")
                            _port.Write(StrAux & My.MyHardware.CodEsc_Cr)
                        End If
                        StrAux = My.MyHardware.CodEsc_TextNormal & "Camarero: " & RstCab("name").Value
                        _port.Write(StrAux & My.MyHardware.CodEsc_Cr)
                        If RstCab("id_referencia").Value = -1 Then
                            StrAux = My.MyHardware.CodEsc_TextNormal & "Mesa: CAJA DIRECTA"
                        Else
                            'Obtengo la mesa
                            Dim rst As ADODB.Recordset = My.m_db.GetRst("SELECT name FROM db_design WHERE id=" & RstCab("id_referencia").Value)
                            StrAux = My.MyHardware.CodEsc_TextNormal & "Mesa: " & rst("name").Value
                            My.m_db.CloseRst(rst)
                        End If

                        _port.Write(" " & My.MyHardware.CodEsc_Cr)
                End Select

                Select Case My.m_opt.modo_compatibilidad
                    Case "COMERCIO", "ESTANCO"
                        StrAux = " " & My.MyHardware.CodEsc_Subrayado_True & "Concepto" & My.MyHardware.CodEsc_Subrayado_False
                        StrAux &= Space(My.MyHardware.Ancho - 29) & My.MyHardware.CodEsc_Subrayado_True & "Precio" & My.MyHardware.CodEsc_Subrayado_False
                        StrAux &= Space(2) & My.MyHardware.CodEsc_Subrayado_True & "Cant." & My.MyHardware.CodEsc_Subrayado_False
                        StrAux &= Space(2) & My.MyHardware.CodEsc_Subrayado_True & "Total" & My.MyHardware.CodEsc_Subrayado_False
                        _port.Write(StrAux & My.MyHardware.CodEsc_Cr)
                    Case Else
                        StrAux = " " & My.MyHardware.CodEsc_Subrayado_True & "Articulo" & My.MyHardware.CodEsc_Subrayado_False
                        StrAux &= Space(My.MyHardware.Ancho - 20) & My.MyHardware.CodEsc_Subrayado_True & "Ud." & My.MyHardware.CodEsc_Subrayado_False
                        StrAux &= Space(2) & My.MyHardware.CodEsc_Subrayado_True & "Total" & My.MyHardware.CodEsc_Subrayado_False
                        _port.Write(StrAux & My.MyHardware.CodEsc_Cr)
                End Select
                While Not RstLines.EOF
                    Select Case My.m_opt.modo_compatibilidad
                        Case "COMERCIO", "ESTANCO"
                            StrAux = " " & RstLines("name").Value
                            If StrAux.Length > My.MyHardware.Ancho - 22 Then StrAux = StrAux.Substring(0, My.MyHardware.Ancho - 22)
                            StrAux &= Space(My.MyHardware.Ancho - 20 - StrAux.Length)

                            StrAux &= Space(6 - Format(RstLines("pvp_ud").Value, "##0.00").Length) & Format(RstLines("pvp_ud").Value, "##0.00")
                            StrAux &= Space(7 - Format(RstLines("ud").Value, "##0.##").Length) & Format(RstLines("ud").Value, "##0.##")

                            j = (6 - Format(RstLines("total").Value, "##0.00").Length)
                            If j < 0 Then j = 0

                            StrAux &= " " & Space(j) & Format(RstLines("total").Value, "##0.00")

                        Case Else
                            StrAux = " " & RstLines("name").Value
                            If StrAux.Length > My.MyHardware.Ancho - 13 Then StrAux = StrAux.Substring(0, My.MyHardware.Ancho - 13)
                            StrAux &= Space(My.MyHardware.Ancho - 11 - StrAux.Length)
                            StrAux &= Space(3 - Format(RstLines("ud").Value, "##0").Length) & Format(RstLines("ud").Value, "##0")

                            j = (6 - Format(RstLines("total").Value, "##0.00").Length)
                            If j < 0 Then j = 0

                            StrAux &= " " & Space(j) & Format(RstLines("total").Value, "##0.00")
                    End Select

                    _port.Write(FixCHARISO(StrAux) & My.MyHardware.CodEsc_Cr)

                    'Si tiene Obs
                    If CStr(RstLines("obs").Value & "").Length > 0 Then
                        _port.Write(addSpace(RstLines("obs").Value) & My.MyHardware.CodEsc_Cr)
                    End If

                    RstLines.MoveNext()
                End While

                StrAux = My.MyHardware.CodEsc_TextNormal & " " & My.MyHardware.CodEsc_Subrayado_True & Space(My.MyHardware.Ancho - 2) & My.MyHardware.CodEsc_Subrayado_False
                _port.Write(StrAux & My.MyHardware.CodEsc_Cr)

                i = (6 - Format(RstCab("total").Value, "###0.00").Length)
                If i < 0 Then i = 0

                StrAux = My.MyHardware.CodEsc_Rojo & Space(My.MyHardware.Ancho - 11) & My.MyHardware.CodEsc_TextGrande & My.MyHardware.CodEsc_Negrita_True & Space(i) & Format(RstCab("total").Value, "###0.00") & " E" & My.MyHardware.CodEsc_Negrita_False & My.MyHardware.CodEsc_TextNormal
                _port.Write(StrAux & My.MyHardware.CodEsc_Cr)

                If dblEntrega <> 0 Then          'He entregado algo
                    StrAux = "Entrega: " & Format(dblEntrega, "###0.00")
                    StrAux = Space(My.MyHardware.Ancho - StrAux.Length - 1) & StrAux
                    _port.Write(My.MyHardware.CodEsc_Negro & StrAux & My.MyHardware.CodEsc_Cr)

                    StrAux = "Cambio: " & Format(dblEntrega - RstCab("total").Value, "###0.00")
                    StrAux = Space(My.MyHardware.Ancho - StrAux.Length - 1) & StrAux
                    _port.Write(StrAux & My.MyHardware.CodEsc_Cr)
                End If



                StrAux = My.MyHardware.CodEsc_Negro & Space(My.MyHardware.Ancho - 14) & "(IVA INCLUIDO)"
                _port.Write(StrAux & My.MyHardware.CodEsc_Cr)

                _port.Write(My.MyHardware.CodEsc_Negro & My.MyHardware.CodEsc_Cr)

                'Imprimo las lineas
                For i = 5 To 8
                    StrAux = My.MyHardware.StrCab(i)
                    StrCod = ""
                    If StrAux.Length > My.MyHardware.Ancho Then StrAux = StrAux.Substring(1, My.MyHardware.Ancho)
                    StrCod = Ticket_ConfigTextColor(StrCod, My.MyHardware.SwRed(i))
                    StrCod = Ticket_ConfigTextStrong(StrCod, My.MyHardware.SwNegrita(i))
                    StrCod = Ticket_ConfigTextSize(StrCod, My.MyHardware.SwGrande(i))
                    StrAux = Ticket_ConfigTextAling(StrAux, IIf(My.MyHardware.SwCenter(i), 2, 0), My.MyHardware.SwGrande(i))
                    If StrAux.Length <> 0 Then _port.Write(StrCod & StrAux & My.MyHardware.CodEsc_Cr)
                Next
                _port.Write(My.MyHardware.CodEsc_Salto & My.MyHardware.CodEsc_Cr)
                If Len(My.MyHardware.CodEsc_Cut) > 0 Then _port.Write(My.MyHardware.CodEsc_Cut & My.MyHardware.CodEsc_Cr)
                _port.Dispose()

            Else
                '<!--### IMPRESIÓN POR LA IMPRESORA DE NOMBRE TICKETS ###-->
                Dim strPrinter As String = "tickets"
                Dim strText As String = ""

                Dim RstCab As ADODB.Recordset, RstLines As ADODB.Recordset
                RstCab = My.m_db.GetRst("SELECT db_tickets.id,db_tickets.fh_alta,db_tickets.n_ticket,db_tickets.dto,db_tickets.fh_finaliza,db_tickets.total,db_tickets.id_referencia,db_usuarios.name FROM db_tickets LEFT JOIN db_usuarios ON db_usuarios.id=db_tickets.id_user WHERE db_tickets.id=" & Id_Ticket)
                RstLines = My.m_db.GetRst("SELECT * FROM db_tickets_lines WHERE id_ticket=" & Id_Ticket & " ORDER BY id")
                If RstCab.RecordCount = 0 Then
                    MsgBox("Error localizando el ticket.", MsgBoxStyle.Critical, "Imprimir Ticket")
                    Exit Sub
                End If

                'If My.MyHardware.CodEsc_Init.Length > 0 Then RawPrinterHelper.SendStringToPrinter(strPrinter, My.MyHardware.CodEsc_Init & My.MyHardware.CodEsc_Cr)
                strText &= My.MyHardware.CodEsc_Init & My.MyHardware.CodEsc_Cr
                StrCod = ""

                'Imprimo la cabezera
                For i = 1 To 4
                    StrAux = My.MyHardware.StrCab(i)
                    StrCod = ""
                    If StrAux.Length > My.MyHardware.Ancho Then StrAux = StrAux.Substring(1, My.MyHardware.Ancho)
                    StrCod = Ticket_ConfigTextColor(StrCod, My.MyHardware.SwRed(i))
                    StrCod = Ticket_ConfigTextStrong(StrCod, My.MyHardware.SwNegrita(i))
                    StrCod = Ticket_ConfigTextSize(StrCod, My.MyHardware.SwGrande(i))
                    StrAux = Ticket_ConfigTextAling(StrAux, IIf(My.MyHardware.SwCenter(i), 2, 0), My.MyHardware.SwGrande(i))
                    'If My.MyHardware.StrCab(i).Length <> 0 Then RawPrinterHelper.SendStringToPrinter(strPrinter, StrCod & StrAux & My.MyHardware.CodEsc_Cr)
                    If My.MyHardware.StrCab(i).Length <> 0 Then strText &= StrCod & StrAux & My.MyHardware.CodEsc_Cr

                Next
                strText &= My.MyHardware.CodEsc_Cr


                'Si es un pedido imprimo los detalles
                If id_pedido > 0 Then
                    Dim rstPedido As ADODB.Recordset = My.m_db.GetRst("SELECT db_pedidos.*,db_clientes.name_fiscal FROM db_pedidos,db_clientes WHERE db_pedidos.id_cliente=db_clientes.id AND db_pedidos.id=" & id_pedido)
                    StrAux = My.MyHardware.CodEsc_TextNormal & "Cliente: " & vbCrLf & My.MyHardware.CodEsc_TextGrande & My.MyHardware.CodEsc_Negrita_True & rstPedido("name_fiscal").Value & My.MyHardware.CodEsc_Negrita_False & My.MyHardware.CodEsc_TextNormal & My.MyHardware.CodEsc_Cr
                    StrAux &= My.MyHardware.CodEsc_TextNormal & "Telefono:  " & My.MyHardware.CodEsc_TextGrande & rstPedido("tlf").Value & My.MyHardware.CodEsc_TextNormal & My.MyHardware.CodEsc_Cr
                    StrAux &= My.MyHardware.CodEsc_TextNormal & "Direccion: " & My.MyHardware.CodEsc_TextGrande & rstPedido("dir").Value & rstPedido("dir_n").Value & "" & rstPedido("dir_bloque").Value & "" & My.MyHardware.CodEsc_TextNormal & My.MyHardware.CodEsc_Cr
                    strText &= FixCHARISO(StrAux) & My.MyHardware.CodEsc_Cr
                End If

                'Imprimo la cabezera                
                StrAux = My.MyHardware.CodEsc_TextNormal & "Factura: " & My.MyHardware.CodEsc_Negrita_True & RstCab("n_ticket").Value & My.MyHardware.CodEsc_Negrita_False
                StrAux &= Space(My.MyHardware.Ancho - (StrAux.Length - My.MyHardware.CodEsc_Negrita_True.Length - My.MyHardware.CodEsc_Negrita_False.Length) - Format(RstCab("fh_alta").Value, "dd/MM/yyyy").Length) & IIf(My.MyHardware.Ancho < 40, My.MyHardware.CodEsc_Cr & "Fecha: ", "") & My.MyHardware.CodEsc_Negrita_True & Format(RstCab("fh_alta").Value, "dd/MM/yyyy") & My.MyHardware.CodEsc_Negrita_False
                'StrAux &= Space(My.MyHardware.Ancho - (StrAux.Length - My.MyHardware.CodEsc_Negrita_True.Length - My.MyHardware.CodEsc_Negrita_False.Length) - Format(RstCab("fh_alta").Value, "dd/MM/yyyy HH:mm").Length) & My.MyHardware.CodEsc_Negrita_True & Format(RstCab("fh_alta").Value, "dd/MM/yyyy") & My.MyHardware.CodEsc_Negrita_False & " " & Format(RstCab("fh_alta").Value, "HH:mm")
                'RawPrinterHelper.SendStringToPrinter(strPrinter, StrAux & My.MyHardware.CodEsc_Cr)
                strText &= StrAux & My.MyHardware.CodEsc_Cr

                'StrAux = My.MyHardware.CodEsc_TextNormal & "Ref.: " & Format(RstCab("id").Value, "000000")
                'strText &= StrAux & My.MyHardware.CodEsc_Cr



                Select Case My.m_opt.modo_compatibilidad
                    Case "COMERCIO", "ESTANCO"
                        If RstCab("id_referencia").Value = -1 Then
                            StrAux = My.MyHardware.CodEsc_TextNormal & "Servicio: CAJA DIRECTA"
                        Else
                            'Obtengo la mesa
                            Dim rst As ADODB.Recordset = My.m_db.GetRst("SELECT name FROM db_design WHERE id=" & RstCab("id_referencia").Value)
                            StrAux = My.MyHardware.CodEsc_TextNormal & "Servicio: " & rst("name").Value
                            My.m_db.CloseRst(rst)
                        End If

                    Case Else
                        If Not IsDBNull(RstCab("fh_finaliza").Value) AndAlso DateDiff(DateInterval.Minute, CDate(RstCab("fh_alta").Value), CDate(RstCab("fh_finaliza").Value)) > 1 Then
                            StrAux = My.MyHardware.CodEsc_TextNormal & "Hora: " & Format(RstCab("fh_finaliza").Value, "dd/MM/yyyy HH:mm")

                            'RawPrinterHelper.SendStringToPrinter(strPrinter, StrAux & My.MyHardware.CodEsc_Cr)
                            strText &= StrAux & My.MyHardware.CodEsc_Cr
                        End If

                        StrAux = My.MyHardware.CodEsc_TextNormal & "Le atendio: " & RstCab("name").Value
                        'RawPrinterHelper.SendStringToPrinter(strPrinter, StrAux & My.MyHardware.CodEsc_Cr)
                        strText &= StrAux & My.MyHardware.CodEsc_Cr

                        If RstCab("id_referencia").Value = -1 Then
                            StrAux = My.MyHardware.CodEsc_TextNormal & "Mesa: CAJA DIRECTA"
                        Else
                            'Obtengo la mesa
                            If RstCab("id_referencia").Value <> -2 Then
                                Dim rst As ADODB.Recordset = My.m_db.GetRst("SELECT name FROM db_design WHERE id=" & RstCab("id_referencia").Value)
                                StrAux = My.MyHardware.CodEsc_TextNormal & "Servido en: " & rst("name").Value
                                My.m_db.CloseRst(rst)
                            End If
                        End If

                        'RawPrinterHelper.SendStringToPrinter(strPrinter, " " & My.MyHardware.CodEsc_Cr)
                        strText &= StrAux & " " & My.MyHardware.CodEsc_Cr

                End Select

                Select Case My.m_opt.modo_compatibilidad
                    Case "COMERCIO", "ESTANCO"
                        StrAux = " " & My.MyHardware.CodEsc_Subrayado_True & "Concepto" & My.MyHardware.CodEsc_Subrayado_False
                        StrAux &= Space(My.MyHardware.Ancho - 29) & " " & My.MyHardware.CodEsc_Subrayado_True & "Cant." & My.MyHardware.CodEsc_Subrayado_False
                        StrAux &= Space(1) & My.MyHardware.CodEsc_Subrayado_True & "Precio" & My.MyHardware.CodEsc_Subrayado_False
                        StrAux &= Space(2) & My.MyHardware.CodEsc_Subrayado_True & "Total" & My.MyHardware.CodEsc_Subrayado_False
                        'RawPrinterHelper.SendStringToPrinter(strPrinter, StrAux & My.MyHardware.CodEsc_Cr)
                        strText &= StrAux & My.MyHardware.CodEsc_Cr

                    Case Else
                        StrAux = " " & My.MyHardware.CodEsc_Subrayado_True & "Articulo" & My.MyHardware.CodEsc_Subrayado_False
                        StrAux &= Space(My.MyHardware.Ancho - 20) & My.MyHardware.CodEsc_Subrayado_True & "Ud." & My.MyHardware.CodEsc_Subrayado_False
                        StrAux &= Space(2) & My.MyHardware.CodEsc_Subrayado_True & "Total" & My.MyHardware.CodEsc_Subrayado_False
                        'RawPrinterHelper.SendStringToPrinter(strPrinter, StrAux & My.MyHardware.CodEsc_Cr)
                        strText &= StrAux & My.MyHardware.CodEsc_Cr
                End Select


                While Not RstLines.EOF
                    Select Case My.m_opt.modo_compatibilidad
                        Case "COMERCIO", "ESTANCO"
                            StrAux = " " & RstLines("name").Value
                            If StrAux.Length > My.MyHardware.Ancho - 22 Then StrAux = StrAux.Substring(0, My.MyHardware.Ancho - 22)
                            StrAux &= Space(My.MyHardware.Ancho - 21 - StrAux.Length)

                            StrAux &= Space(7 - Format(RstLines("ud").Value, "##0.##").Length) & Format(RstLines("ud").Value, "##0.##")
                            StrAux &= Space(6 - Format(RstLines("pvp_ud").Value, "##0.00").Length) & Format(RstLines("pvp_ud").Value, "##0.00")


                            j = (6 - Format(RstLines("total").Value, "##0.00").Length)
                            If j < 0 Then j = 0

                            StrAux &= " " & Space(j) & Format(RstLines("total").Value, "##0.00")

                        Case Else
                            StrAux = " " & RstLines("name").Value
                            If StrAux.Length > My.MyHardware.Ancho - 13 Then StrAux = StrAux.Substring(0, My.MyHardware.Ancho - 13)
                            StrAux &= Space(My.MyHardware.Ancho - 11 - StrAux.Length)
                            StrAux &= Space(3 - Format(RstLines("ud").Value, "##0").Length) & Format(RstLines("ud").Value, "##0")

                            j = (6 - Format(RstLines("total").Value, "##0.00").Length)
                            If j < 0 Then j = 0

                            StrAux &= " " & Space(j) & Format(RstLines("total").Value, "##0.00")


                            Dim sCompleta As String = "", idArtCompose As Integer = 0
                            Dim swExist As Boolean = False
                            Dim arr() As String = gDevelop.Lite.m_Functions.SplitString(RstLines("composicion").Value & "")

                            If Not IsNothing(arr) Then
                                rstCompose = My.m_db.GetRst("SELECT composicion FROM db_articulos WHERE id=" & RstLines("id_articulo").Value)
                                Dim arrClone() As String = gDevelop.Lite.m_Functions.SplitString(rstCompose("composicion").Value & "")


                                For k As Integer = 0 To arr.Length - 1
                                    swExist = False
                                    For l As Integer = 0 To arrClone.Length - 1
                                        If arrClone(l) = arr(k) Then
                                            idArtCompose = arr(k)
                                            arr(k) = -1
                                            'arr(l) = -1
                                            arrClone(l) = -1
                                            swExist = True
                                            'Exit For
                                        End If
                                    Next
                                Next

                                ' COMPRUEBO ARTICULOS ELIMINADOS
                                For k As Integer = 0 To arrClone.Length - 1
                                    If arrClone(k) <> -1 Then
                                        rstCompose = My.m_db.GetRst("SELECT name,pvp_iva FROM db_articulos WHERE id=" & arrClone(k))
                                        If Not rstCompose.EOF Then sCompleta &= "    - (-) " & rstCompose("name").Value & My.MyHardware.CodEsc_Cr
                                    End If
                                Next


                                ' COMPRUEBO ARTICULOS EXTRA
                                For k As Integer = 0 To arr.Length - 1
                                    If arr(k) <> -1 Then
                                        rstCompose = My.m_db.GetRst("SELECT name,pvp_iva FROM db_articulos WHERE id=" & arr(k))
                                        If Not rstCompose.EOF Then sCompleta &= "    - (+) " & rstCompose("name").Value & My.MyHardware.CodEsc_Cr
                                    End If
                                Next

                                If sCompleta.Length > 0 Then strText &= My.FixCHARISO(sCompleta) & My.MyHardware.CodEsc_Cr

                            End If


                            arr = gDevelop.Lite.m_Functions.SplitString(RstLines("mixto").Value & "")
                            sCompleta = ""

                            If Not IsNothing(arr) Then
                                For k As Integer = 0 To arr.Length - 1
                                    rstCompose = My.m_db.GetRst("SELECT name,pvp_iva FROM db_articulos WHERE id=" & arr(k))
                                    If Not rstCompose.EOF Then sCompleta &= "    - " & rstCompose("name").Value & My.MyHardware.CodEsc_Cr
                                Next
                                If sCompleta.Length > 0 Then strText &= My.FixCHARISO(sCompleta) & My.MyHardware.CodEsc_Cr
                            End If

                    End Select

                    'RawPrinterHelper.SendStringToPrinter(strPrinter, FixCHARISO(StrAux) & My.MyHardware.CodEsc_Cr)
                    strText &= FixCHARISO(StrAux) & My.MyHardware.CodEsc_Cr


                    'Si tiene Obs
                    If CStr(RstLines("obs").Value & "").Length > 0 Then
                        'RawPrinterHelper.SendStringToPrinter(strPrinter, addSpace(RstLines("obs").Value) & My.MyHardware.CodEsc_Cr)
                        strText &= addSpace(RstLines("obs").Value) & My.MyHardware.CodEsc_Cr

                    End If


                    'Compongo las bases
                    Select Case RstLines("iva").Value
                        Case My.m_opt.IVA_General : dblBase_16 += (RstLines("pvp_base").Value * RstLines("ud").Value)
                        Case My.m_opt.IVA_Medio : dblBase_7 += (RstLines("pvp_base").Value * RstLines("ud").Value)
                        Case My.m_opt.IVA_Basico : dblBase_4 += (RstLines("pvp_base").Value * RstLines("ud").Value)
                    End Select

                    RstLines.MoveNext()
                End While

                StrAux = My.MyHardware.CodEsc_TextNormal & " " & My.MyHardware.CodEsc_Subrayado_True & Space(My.MyHardware.Ancho - 2) & My.MyHardware.CodEsc_Subrayado_False
                'RawPrinterHelper.SendStringToPrinter(strPrinter, StrAux & My.MyHardware.CodEsc_Cr)
                strText &= StrAux & My.MyHardware.CodEsc_Cr


                i = (6 - Format(RstCab("total").Value, "###0.00").Length)
                If i < 0 Then i = 0

                StrAux = My.MyHardware.CodEsc_Rojo & Space(My.MyHardware.Ancho - 11) & My.MyHardware.CodEsc_TextGrande & My.MyHardware.CodEsc_Negrita_True & Space(i) & Format(RstCab("total").Value, "###0.00") & " E" & My.MyHardware.CodEsc_Negrita_False & My.MyHardware.CodEsc_TextNormal
                'RawPrinterHelper.SendStringToPrinter(strPrinter, StrAux & My.MyHardware.CodEsc_Cr)
                strText &= StrAux & My.MyHardware.CodEsc_Cr

                If Not IsDBNull(RstCab("dto").Value) Then
                    If CDbl(RstCab("dto").Value) <> 0 Then          'He entregado algo
                        StrAux = "Dto: " & My.MyHardware.CodEsc_TextGrande & Format(RstCab("dto").Value, "###0.00") & My.MyHardware.CodEsc_TextNormal
                        StrAux = Space(My.MyHardware.Ancho - StrAux.Length - 1) & StrAux
                        strText &= My.MyHardware.CodEsc_Negro & StrAux & My.MyHardware.CodEsc_Cr
                    End If
                End If



                If dblEntrega <> 0 Then          'He entregado algo
                    StrAux = "Entrega: " & Format(dblEntrega, "###0.00")
                    StrAux = Space(My.MyHardware.Ancho - StrAux.Length - 1) & StrAux
                    'RawPrinterHelper.SendStringToPrinter(strPrinter, My.MyHardware.CodEsc_Negro & StrAux & My.MyHardware.CodEsc_Cr)
                    strText &= My.MyHardware.CodEsc_Negro & StrAux & My.MyHardware.CodEsc_Cr


                    StrAux = "Cambio: " & Format(dblEntrega - RstCab("total").Value, "###0.00")
                    StrAux = Space(My.MyHardware.Ancho - StrAux.Length - 1) & StrAux
                    'RawPrinterHelper.SendStringToPrinter(strPrinter, StrAux & My.MyHardware.CodEsc_Cr)
                    strText &= StrAux & My.MyHardware.CodEsc_Cr
                End If



                StrAux = My.MyHardware.CodEsc_Negro & Space(My.MyHardware.Ancho - 14) & "(IVA INCLUIDO)"
                'RawPrinterHelper.SendStringToPrinter(strPrinter, StrAux & My.MyHardware.CodEsc_Cr)
                strText &= StrAux & My.MyHardware.CodEsc_Cr


                'RawPrinterHelper.SendStringToPrinter(strPrinter, My.MyHardware.CodEsc_Negro & My.MyHardware.CodEsc_Cr)
                strText &= My.MyHardware.CodEsc_Negro & My.MyHardware.CodEsc_Cr

                ''Realizo la descomposición de los importes
                'StrAux = Space(My.MyHardware.Ancho - 28)
                'StrAux &= " " & My.MyHardware.CodEsc_Subrayado_True & "% IVA" & My.MyHardware.CodEsc_Subrayado_False
                'StrAux &= " " & My.MyHardware.CodEsc_Subrayado_True & "Precio Base" & My.MyHardware.CodEsc_Subrayado_False
                'StrAux &= " " & My.MyHardware.CodEsc_Subrayado_True & "    Cuota" & My.MyHardware.CodEsc_Subrayado_False
                'strText &= StrAux & My.MyHardware.CodEsc_Cr

                'StrAux = My.MyHardware.CodEsc_TextNormal & " " & My.MyHardware.CodEsc_Subrayado_True & Space(My.MyHardware.Ancho - 2) & My.MyHardware.CodEsc_Subrayado_False
                'RawPrinterHelper.SendStringToPrinter(strPrinter, StrAux & My.MyHardware.CodEsc_Cr)

                'Ajusto las bases imponibles
                dblBase_4 = Format(dblBase_4, "0.00")
                dblBase_7 = Format(dblBase_7, "0.00")
                dblBase_16 = Format(dblBase_16, "0.00")

                'Calculo el importe de iva
                dblIVA_4 = Format(((dblBase_4 * My.m_opt.IVA_Basico) / 100), "0.00")
                dblIVA_7 = Format(((dblBase_7 * My.m_opt.IVA_Medio) / 100), "0.00")
                dblIVA_16 = Format(((dblBase_16 * My.m_opt.IVA_General) / 100), "0.00")

                '### Imprimo las bases Imponibles
                StrAux = " " & My.MyHardware.CodEsc_Subrayado_True & "Base Imponible" & My.MyHardware.CodEsc_Subrayado_False
                StrAux &= Space(My.MyHardware.Ancho - IIf(My.MyHardware.Ancho < 40, 12, 20) - 17) & My.MyHardware.CodEsc_Subrayado_True & "% IVA" & My.MyHardware.CodEsc_Subrayado_False
                StrAux &= Space(1) & My.MyHardware.CodEsc_Subrayado_True & "Imp IVA" & My.MyHardware.CodEsc_Subrayado_False

                If My.MyHardware.Ancho >= 40 Then StrAux &= Space(1) & My.MyHardware.CodEsc_Subrayado_True & "  Total" & My.MyHardware.CodEsc_Subrayado_False
                strText &= StrAux & My.MyHardware.CodEsc_Cr
                If dblBase_4 > 0 Then
                    StrAux = " " & Format(dblBase_4, "0.00")
                    StrAux &= Space(My.MyHardware.Ancho - IIf(My.MyHardware.Ancho < 40, 14, 22) - StrAux.Length)
                    StrAux &= Space(5 - Format(My.m_opt.IVA_Basico, "#0.00").Length) & Format(My.m_opt.IVA_Basico, "#0.00")
                    StrAux &= Space(1)
                    StrAux &= Space(7 - Format(dblIVA_4, "0.00").Length) & Format(dblIVA_4, "0.00")
                    If My.MyHardware.Ancho >= 40 Then
                        StrAux &= Space(1)
                        StrAux &= Space(7 - Format(dblBase_4 + dblIVA_4, "0.00").Length) & Format(dblBase_4 + dblIVA_4, "0.00")
                    End If
                    strText &= StrAux & My.MyHardware.CodEsc_Cr
                End If

                If dblBase_7 > 0 Then
                    StrAux = " " & Format(dblBase_7, "0.00")
                    StrAux &= Space(My.MyHardware.Ancho - IIf(My.MyHardware.Ancho < 40, 14, 22) - StrAux.Length)
                    StrAux &= Space(5 - Format(My.m_opt.IVA_Medio, "#0.00").Length) & Format(My.m_opt.IVA_Medio, "#0.00")
                    StrAux &= Space(1)
                    StrAux &= Space(7 - Format(dblIVA_7, "0.00").Length) & Format(dblIVA_7, "0.00")
                    If My.MyHardware.Ancho >= 40 Then
                        StrAux &= Space(1)
                        StrAux &= Space(7 - Format(dblBase_7 + dblIVA_7, "0.00").Length) & Format(dblBase_7 + dblIVA_7, "0.00")
                    End If
                    strText &= StrAux & My.MyHardware.CodEsc_Cr
                End If

                If dblBase_16 > 0 Then
                    StrAux = " " & Format(dblBase_16, "0.00")
                    StrAux &= Space(My.MyHardware.Ancho - IIf(My.MyHardware.Ancho < 40, 14, 22) - StrAux.Length)
                    StrAux &= Space(5 - Format(My.m_opt.IVA_General, "#0.00").Length) & Format(My.m_opt.IVA_General, "#0.00")
                    StrAux &= Space(1)
                    StrAux &= Space(7 - Format(dblIVA_16).Length) & Format(dblIVA_16, "0.00")
                    If My.MyHardware.Ancho >= 40 Then
                        StrAux &= Space(1)
                        StrAux &= Space(7 - Format(dblBase_16 + dblIVA_16, "0.00").Length) & Format(dblBase_16 + dblIVA_16, "0.00")
                    End If
                    strText &= StrAux & My.MyHardware.CodEsc_Cr
                End If
                StrAux = Space(My.MyHardware.Ancho - IIf(My.MyHardware.Ancho < 40, 10, 15)) & My.MyHardware.CodEsc_Subrayado_True & Space(14) & My.MyHardware.CodEsc_Subrayado_False
                strText &= StrAux & My.MyHardware.CodEsc_Cr

                If My.MyHardware.Ancho >= 40 Then
                    ' Resumen Final
                    StrAux = Space(My.MyHardware.Ancho - 31) & My.MyHardware.CodEsc_Subrayado_True & Space(27) & My.MyHardware.CodEsc_Subrayado_False
                    strText &= StrAux & My.MyHardware.CodEsc_Cr

                    StrAux = Space(My.MyHardware.Ancho - 29) & My.MyHardware.CodEsc_Subrayado_True & Space(29) & My.MyHardware.CodEsc_Subrayado_False
                    strText &= StrAux & My.MyHardware.CodEsc_Cr
                End If

                'Imprimo las lineas
                For i = 5 To 8
                    StrAux = My.MyHardware.StrCab(i)
                    StrCod = ""
                    If StrAux.Length > My.MyHardware.Ancho Then StrAux = StrAux.Substring(1, My.MyHardware.Ancho)
                    StrCod = Ticket_ConfigTextColor(StrCod, My.MyHardware.SwRed(i))
                    StrCod = Ticket_ConfigTextStrong(StrCod, My.MyHardware.SwNegrita(i))
                    StrCod = Ticket_ConfigTextSize(StrCod, My.MyHardware.SwGrande(i))
                    StrAux = Ticket_ConfigTextAling(StrAux, IIf(My.MyHardware.SwCenter(i), 2, 0), My.MyHardware.SwGrande(i))
                    'If StrAux.Length <> 0 Then RawPrinterHelper.SendStringToPrinter(strPrinter, StrCod & StrAux & My.MyHardware.CodEsc_Cr)
                    strText &= StrCod & StrAux & My.MyHardware.CodEsc_Cr
                Next
                'RawPrinterHelper.SendStringToPrinter(strPrinter, My.MyHardware.CodEsc_Salto & My.MyHardware.CodEsc_Cr)

                'Resumen final
                StrAux = My.MyHardware.CodEsc_TextNormal & " " & My.MyHardware.CodEsc_Subrayado_True & Space(My.MyHardware.Ancho - 2) & My.MyHardware.CodEsc_Subrayado_False
                strText &= StrAux & My.MyHardware.CodEsc_Cr

                strText &= My.MyHardware.CodEsc_Negrita_True & My.Ticket_ConfigTextAling(" * _ FACTURA SIMPLIFICADA _ *", HorizontalAlignment.Center) & My.MyHardware.CodEsc_Negrita_False & My.MyHardware.CodEsc_Cr
                'strText &= My.Ticket_ConfigTextAling(" gTPV.v" & My.Application.Info.Version.Major & "." & My.Application.Info.Version.Minor & "." & My.Application.Info.Version.Build) & "" & My.MyHardware.CodEsc_Cr


                strText &= My.MyHardware.CodEsc_Salto & My.MyHardware.CodEsc_Cr
                RawPrinterHelper.SendStringToPrinter(strPrinter, strText)

                If Len(My.MyHardware.CodEsc_Cut) > 0 Then RawPrinterHelper.SendStringToPrinter(strPrinter, My.MyHardware.CodEsc_Cut & My.MyHardware.CodEsc_Cr)

            End If
        End Sub

        Public Sub PrintFactura(ByVal Id_Factura As Integer)
            If My.MyHardware.IdPort = 0 Then
                MsgBox("No se ha detectado ningún puerto de Impresión.", MsgBoxStyle.Critical)
                Exit Sub
            End If

            Dim StrAux As String, i As Integer, j As Integer
            Dim dblBase_4 As Double = 0, dblBase_7 As Double = 0, dblBase_16 As Double = 0
            Dim dblIVA_4 As Double = 0, dblIVA_7 As Double = 0, dblIVA_16 As Double = 0
            Dim dblTotal As Double = 0

            'Cargo los datos de la factura
            Dim rstFactura As ADODB.Recordset = My.m_db.GetRst("SELECT db_facturas.*,db_clientes.* FROM db_facturas,db_clientes WHERE db_clientes.id=db_facturas.id_cliente AND db_facturas.id=" & Id_Factura)
            If rstFactura.RecordCount <= 0 Then
                MsgBox("Detalles de factura no localizados")
                Exit Sub
            End If

            'Cargo los datos de la empresa
            Dim rstEmpresa As ADODB.Recordset = My.m_db.GetRst("SELECT * FROM app_empresa")
            If rstEmpresa.RecordCount <= 0 Then
                MsgBox("Detalles de empresa no localizados")
                Exit Sub
            End If

            If My.MyHardware.PortName.Substring(0, 3) = "COM" Then
                '<!--### IMPRESIÓN POR PUERTO SERIE ###-->
                Try
                    Dim _port As IO.Ports.SerialPort
                    _port = New IO.Ports.SerialPort(My.MyHardware.PortName, 9600, IO.Ports.Parity.None, 8, IO.Ports.StopBits.One)
                    _port.DiscardNull = True
                    _port.WriteBufferSize = 2024
                    _port.DtrEnable = True
                    _port.Handshake = IO.Ports.Handshake.None

                    _port.Open()

                    If My.MyHardware.CodEsc_Init.Length > 0 Then _port.Write(My.MyHardware.CodEsc_Init & My.MyHardware.CodEsc_Cr)

                    '###Imprimo los detalles de la Empresa
                    ' > Nombre Fiscal
                    StrAux = rstEmpresa("name_fiscal").Value
                    If StrAux.Length > My.MyHardware.Ancho Then StrAux = StrAux.Substring(1, My.MyHardware.Ancho)
                    StrCod = Ticket_ConfigTextStrong("", True)
                    StrAux = Ticket_ConfigTextAling(StrAux, HorizontalAlignment.Center)
                    _port.Write(StrCod & StrAux & My.MyHardware.CodEsc_Cr)

                    ' > Nombre Comercial
                    StrAux = """" & rstEmpresa("name_comercial").Value & """"
                    If StrAux.Length > My.MyHardware.Ancho Then StrAux = StrAux.Substring(1, My.MyHardware.Ancho)
                    StrCod = Ticket_ConfigTextStrong("", False)
                    StrAux = Ticket_ConfigTextAling(StrAux, HorizontalAlignment.Center)
                    _port.Write(StrCod & StrAux & My.MyHardware.CodEsc_Cr)

                    ' > El Cif
                    StrAux = "CIF/NIF: " & rstEmpresa("cif").Value
                    If StrAux.Length > My.MyHardware.Ancho Then StrAux = StrAux.Substring(1, My.MyHardware.Ancho)
                    StrCod = Ticket_ConfigTextStrong("", True)
                    StrAux = Ticket_ConfigTextAling(StrAux, HorizontalAlignment.Center)
                    _port.Write(StrCod & StrAux & My.MyHardware.CodEsc_Cr)

                    ' > La Direccion
                    StrAux = rstEmpresa("dir").Value
                    If StrAux.Length > My.MyHardware.Ancho Then StrAux = StrAux.Substring(1, My.MyHardware.Ancho)
                    StrCod = Ticket_ConfigTextStrong("", False)
                    StrAux = Ticket_ConfigTextAling(StrAux, HorizontalAlignment.Center)
                    _port.Write(StrCod & StrAux & My.MyHardware.CodEsc_Cr)

                    ' > El Codigo Postal y La localidad
                    StrAux = rstEmpresa("cp").Value & " - " & rstEmpresa("pob").Value
                    If StrAux.Length > My.MyHardware.Ancho Then StrAux = StrAux.Substring(1, My.MyHardware.Ancho)
                    StrCod = Ticket_ConfigTextStrong("", False)
                    StrAux = Ticket_ConfigTextAling(StrAux, HorizontalAlignment.Center)
                    _port.Write(StrCod & StrAux & My.MyHardware.CodEsc_Cr)

                    ' > La provincia
                    StrAux = rstEmpresa("prov").Value
                    If StrAux.Length > My.MyHardware.Ancho Then StrAux = StrAux.Substring(1, My.MyHardware.Ancho)
                    StrCod = Ticket_ConfigTextStrong("", False)
                    StrAux = Ticket_ConfigTextAling(StrAux, HorizontalAlignment.Center)
                    _port.Write(StrCod & StrAux & My.MyHardware.CodEsc_Cr)

                    _port.Close()
                    _port.Open()

                    _port.Write(" " & My.MyHardware.CodEsc_Cr)

                    '###Imprimo los detalles del Cliente
                    StrAux = " " & My.MyHardware.CodEsc_Subrayado_True & "Cliente:" & My.MyHardware.CodEsc_Subrayado_False
                    _port.Write(StrAux & My.MyHardware.CodEsc_Cr)
                    ' > Nombre Fiscal
                    StrAux = rstFactura("name_fiscal").Value
                    If StrAux.Length > My.MyHardware.Ancho Then StrAux = StrAux.Substring(1, My.MyHardware.Ancho)
                    StrCod = Ticket_ConfigTextStrong("", True)
                    _port.Write(StrCod & StrAux & My.MyHardware.CodEsc_Cr)

                    ' > El Cif
                    StrAux = "CIF/NIF: " & rstFactura("cif").Value
                    If StrAux.Length > My.MyHardware.Ancho Then StrAux = StrAux.Substring(1, My.MyHardware.Ancho)
                    StrCod = Ticket_ConfigTextStrong("", True)
                    _port.Write(StrCod & StrAux & My.MyHardware.CodEsc_Cr)

                    ' > La Direccion
                    StrAux = rstFactura("dir").Value
                    If StrAux.Length > My.MyHardware.Ancho Then StrAux = StrAux.Substring(1, My.MyHardware.Ancho)
                    StrCod = Ticket_ConfigTextStrong("", False)
                    _port.Write(StrCod & StrAux & My.MyHardware.CodEsc_Cr)

                    ' > El Codigo Postal y La localidad
                    StrAux = rstFactura("cp").Value & " - " & rstFactura("pob").Value
                    If StrAux.Length > My.MyHardware.Ancho Then StrAux = StrAux.Substring(1, My.MyHardware.Ancho)
                    StrCod = Ticket_ConfigTextStrong("", False)
                    _port.Write(StrCod & StrAux & My.MyHardware.CodEsc_Cr)

                    ' > La provincia
                    StrAux = rstFactura("prov").Value
                    If StrAux.Length > My.MyHardware.Ancho Then StrAux = StrAux.Substring(1, My.MyHardware.Ancho)
                    StrCod = Ticket_ConfigTextStrong("", False)
                    _port.Write(StrCod & StrAux & My.MyHardware.CodEsc_Cr)

                    _port.Close()
                    _port.Open()

                    _port.Write(" " & My.MyHardware.CodEsc_Cr)

                    '###Imprimo los detalles de la factura
                    StrAux = " " & My.MyHardware.CodEsc_Subrayado_True & "Detalles de la Factura:" & My.MyHardware.CodEsc_Subrayado_False
                    _port.Write(StrAux & My.MyHardware.CodEsc_Cr)

                    StrAux = rstFactura("n_factura").Value
                    If StrAux.Length > My.MyHardware.Ancho Then StrAux = StrAux.Substring(1, My.MyHardware.Ancho)
                    StrCod = Ticket_ConfigTextStrong("", True)
                    _port.Write(My.MyHardware.CodEsc_Negrita_False & "Numero: " & StrCod & StrAux & My.MyHardware.CodEsc_Cr)

                    StrAux = rstFactura("fh_factura").Value
                    If StrAux.Length > My.MyHardware.Ancho Then StrAux = StrAux.Substring(1, My.MyHardware.Ancho)
                    StrCod = Ticket_ConfigTextStrong("", True)
                    _port.Write(My.MyHardware.CodEsc_Negrita_False & "Fecha: " & StrCod & StrAux & My.MyHardware.CodEsc_Negrita_False & My.MyHardware.CodEsc_Cr)

                    _port.Close()
                    _port.Open()

                    _port.Write(" " & My.MyHardware.CodEsc_Cr)

                    '###Imprimo los detalles del ticket
                    Dim RstCab As ADODB.Recordset, RstLines As ADODB.Recordset
                    RstCab = My.m_db.GetRst("SELECT db_tickets.id,db_tickets.fh_alta,db_tickets.total,db_tickets.id_referencia,db_usuarios.name FROM db_tickets,db_usuarios WHERE db_usuarios.id=db_tickets.id_user AND db_tickets.id=" & rstFactura("id_ticket").Value)
                    RstLines = My.m_db.GetRst("SELECT * FROM db_tickets_lines WHERE id_ticket=" & rstFactura("id_ticket").Value & " ORDER BY id")
                    If RstCab.RecordCount = 0 Then
                        MsgBox("Error localizando el ticket.", MsgBoxStyle.Critical, "Imprimir Ticket")
                        Exit Sub
                    End If


                    StrAux = " " & My.MyHardware.CodEsc_Subrayado_True & "Articulo" & My.MyHardware.CodEsc_Subrayado_False
                    StrAux &= Space(My.MyHardware.Ancho - 14 - 10) & My.MyHardware.CodEsc_Subrayado_True & "IVA" & My.MyHardware.CodEsc_Subrayado_False
                    StrAux &= Space(1) & My.MyHardware.CodEsc_Subrayado_True & "Ud." & My.MyHardware.CodEsc_Subrayado_False
                    StrAux &= Space(1) & My.MyHardware.CodEsc_Subrayado_True & "Pvp/ud" & My.MyHardware.CodEsc_Subrayado_False
                    _port.Write(StrAux & My.MyHardware.CodEsc_Cr)
                    _port.Close()
                    _port.Open()

                    While Not RstLines.EOF
                        StrAux = " " & RstLines("name").Value
                        If StrAux.Length > (My.MyHardware.Ancho - 14 - 10) Then StrAux = StrAux.Substring(0, 16)
                        StrAux &= Space(My.MyHardware.Ancho - 17 - StrAux.Length)
                        StrAux &= Space(5 - Format(RstLines("iva").Value, "##.00").Length) & Format(RstLines("iva").Value, "##.00")
                        StrAux &= Space(1)
                        StrAux &= Space(3 - Format(RstLines("ud").Value, "##0").Length) & Format(RstLines("ud").Value, "##0")

                        j = (6 - Format(RstLines("pvp_base").Value, "##0.00#").Length)
                        If j < 0 Then j = 0

                        StrAux &= " " & Space(j) & Format(RstLines("pvp_base").Value, "##0.00#")

                        _port.Write(StrAux & My.MyHardware.CodEsc_Cr)
                        _port.Close()
                        _port.Open()

                        'Compongo las bases
                        Select Case RstLines("iva").Value
                            Case My.m_opt.IVA_General : dblBase_16 += (RstLines("pvp_base").Value * RstLines("ud").Value)
                            Case My.m_opt.IVA_Medio : dblBase_7 += (RstLines("pvp_base").Value * RstLines("ud").Value)
                            Case My.m_opt.IVA_Basico : dblBase_4 += (RstLines("pvp_base").Value * RstLines("ud").Value)
                        End Select

                        RstLines.MoveNext()
                    End While

                    StrAux = My.MyHardware.CodEsc_TextNormal & " " & My.MyHardware.CodEsc_Subrayado_True & Space(My.MyHardware.Ancho - 2) & My.MyHardware.CodEsc_Subrayado_False
                    _port.Write(StrAux & My.MyHardware.CodEsc_Cr)

                    'Ajusto las bases imponibles
                    dblBase_4 = Format(dblBase_4, "0.00")
                    dblBase_7 = Format(dblBase_7, "0.00")
                    dblBase_16 = Format(dblBase_16, "0.00")

                    'Calculo el importe de iva
                    dblIVA_4 = Format(((dblBase_4 * My.m_opt.IVA_Basico) / 100), "0.00")
                    dblIVA_7 = Format(((dblBase_7 * My.m_opt.IVA_Medio) / 100), "0.00")
                    dblIVA_16 = Format(((dblBase_16 * My.m_opt.IVA_General) / 100), "0.00")

                    '### Imprimo las bases Imponibles
                    StrAux = " " & My.MyHardware.CodEsc_Subrayado_True & "Base Imponible" & My.MyHardware.CodEsc_Subrayado_False
                    StrAux &= Space(My.MyHardware.Ancho - 20 - 17) & My.MyHardware.CodEsc_Subrayado_True & "% IVA" & My.MyHardware.CodEsc_Subrayado_False
                    StrAux &= Space(1) & My.MyHardware.CodEsc_Subrayado_True & "Imp IVA" & My.MyHardware.CodEsc_Subrayado_False
                    StrAux &= Space(1) & My.MyHardware.CodEsc_Subrayado_True & "  Total" & My.MyHardware.CodEsc_Subrayado_False
                    _port.Write(StrAux & My.MyHardware.CodEsc_Cr)
                    _port.Close()
                    _port.Open()

                    If dblBase_4 > 0 Then
                        StrAux = " " & Format(dblBase_4, "0.00")
                        StrAux &= Space(My.MyHardware.Ancho - 22 - StrAux.Length)
                        StrAux &= Space(5 - Format(My.m_opt.IVA_Basico, "#0.00").Length) & Format(My.m_opt.IVA_Basico, "#0.00")
                        StrAux &= Space(1)
                        StrAux &= Space(7 - Format(dblIVA_4, "0.00").Length) & Format(dblIVA_4, "0.00")
                        StrAux &= Space(1)
                        StrAux &= Space(7 - Format(dblBase_4 + dblIVA_4, "0.00").Length) & Format(dblBase_4 + dblIVA_4, "0.00")
                        _port.Write(StrAux & My.MyHardware.CodEsc_Cr)
                    End If

                    If dblBase_7 > 0 Then
                        StrAux = " " & Format(dblBase_7, "0.00")
                        StrAux &= Space(My.MyHardware.Ancho - 22 - StrAux.Length)
                        StrAux &= Space(5 - Format(My.m_opt.IVA_Medio, "#0.00").Length) & Format(My.m_opt.IVA_Medio, "#0.00")
                        StrAux &= Space(1)
                        StrAux &= Space(7 - Format(dblIVA_7, "0.00").Length) & Format(dblIVA_7, "0.00")
                        StrAux &= Space(1)
                        StrAux &= Space(7 - Format(dblBase_7 + dblIVA_7, "0.00").Length) & Format(dblBase_7 + dblIVA_7, "0.00")
                        _port.Write(StrAux & My.MyHardware.CodEsc_Cr)
                    End If

                    If dblBase_16 > 0 Then
                        StrAux = " " & Format(dblBase_16, "0.00")
                        StrAux &= Space(My.MyHardware.Ancho - 22 - StrAux.Length)
                        StrAux &= Space(5 - Format(My.m_opt.IVA_General, "#0.00").Length) & Format(My.m_opt.IVA_General, "#0.00")
                        StrAux &= Space(1)
                        StrAux &= Space(7 - Format(dblIVA_16).Length) & Format(dblIVA_16, "0.00")
                        StrAux &= Space(1)
                        StrAux &= Space(7 - Format(dblBase_16 + dblIVA_16, "0.00").Length) & Format(dblBase_16 + dblIVA_16, "0.00")
                        _port.Write(StrAux & My.MyHardware.CodEsc_Cr)
                    End If
                    StrAux = Space(My.MyHardware.Ancho - 15) & My.MyHardware.CodEsc_Subrayado_True & Space(14) & My.MyHardware.CodEsc_Subrayado_False
                    _port.Write(StrAux & My.MyHardware.CodEsc_Cr)
                    _port.Close()
                    _port.Open()

                    dblTotal = (dblBase_4 + dblIVA_4) + (dblBase_7 + dblIVA_7) + (dblBase_16 + dblIVA_16)

                    i = (6 - Format(dblTotal, "###0.00").Length)
                    If i < 0 Then i = 0

                    StrAux = My.MyHardware.CodEsc_Rojo & Space(My.MyHardware.Ancho - 11) & My.MyHardware.CodEsc_TextGrande & My.MyHardware.CodEsc_Negrita_True & Space(i) & Format(dblTotal, "###0.00") & " E" & My.MyHardware.CodEsc_Negrita_False & My.MyHardware.CodEsc_TextNormal
                    _port.Write(StrAux & My.MyHardware.CodEsc_Cr)
                    _port.Write(My.MyHardware.CodEsc_Negro & "  " & My.MyHardware.CodEsc_Subrayado_True & "Firma y Sello:" & My.MyHardware.CodEsc_Subrayado_False & My.MyHardware.CodEsc_Cr)
                    For i = 0 To 4
                        _port.Write(" " & My.MyHardware.CodEsc_Cr)
                    Next
                    _port.Close()
                    _port.Open()

                    'Imprimo las lineas
                    For i = 5 To 8
                        StrAux = My.MyHardware.StrCab(i)
                        StrCod = ""
                        If StrAux.Length > My.MyHardware.Ancho Then StrAux = StrAux.Substring(1, My.MyHardware.Ancho)
                        StrCod = Ticket_ConfigTextColor(StrCod, My.MyHardware.SwRed(i))
                        StrCod = Ticket_ConfigTextStrong(StrCod, My.MyHardware.SwNegrita(i))
                        StrCod = Ticket_ConfigTextSize(StrCod, My.MyHardware.SwGrande(i))
                        StrAux = Ticket_ConfigTextAling(StrAux, IIf(My.MyHardware.SwCenter(i), 2, 0), My.MyHardware.SwGrande(i))
                        If StrAux.Length <> 0 Then _port.Write(StrCod & StrAux & My.MyHardware.CodEsc_Cr)
                    Next
                    _port.Write(My.MyHardware.CodEsc_Salto & My.MyHardware.CodEsc_Cr)
                    If Len(My.MyHardware.CodEsc_Cut) > 0 Then _port.Write(My.MyHardware.CodEsc_Cut & My.MyHardware.CodEsc_Cr)
                    _port.Close()
                    _port.Dispose()

                Catch ex As Exception
                    MsgBox(ex.Message)
                End Try
            ElseIf My.MyHardware.PortName.Substring(0, 3) = "LPT" Then
                '### IMPRESIÓN POR PUERTO PARALELO
                Dim _port As m_Crypto.ioParerellPort
                _port = New m_Crypto.ioParerellPort("LPT" & My.MyHardware.IdPort)

                If My.MyHardware.CodEsc_Init.Length > 0 Then _port.Write(My.MyHardware.CodEsc_Init & My.MyHardware.CodEsc_Cr)
                StrCod = ""

                '###Imprimo los detalles de la Empresa
                ' > Nombre Fiscal
                StrAux = rstEmpresa("name_fiscal").Value
                If StrAux.Length > My.MyHardware.Ancho Then StrAux = StrAux.Substring(1, My.MyHardware.Ancho)
                StrCod = Ticket_ConfigTextStrong("", True)
                StrAux = Ticket_ConfigTextAling(StrAux, HorizontalAlignment.Center)
                _port.Write(StrCod & StrAux & My.MyHardware.CodEsc_Cr)

                ' > Nombre Comercial
                StrAux = """" & rstEmpresa("name_comercial").Value & """"
                If StrAux.Length > My.MyHardware.Ancho Then StrAux = StrAux.Substring(1, My.MyHardware.Ancho)
                StrCod = Ticket_ConfigTextStrong("", False)
                StrAux = Ticket_ConfigTextAling(StrAux, HorizontalAlignment.Center)
                _port.Write(StrCod & StrAux & My.MyHardware.CodEsc_Cr)

                ' > El Cif
                StrAux = "CIF/NIF: " & rstEmpresa("cif").Value
                If StrAux.Length > My.MyHardware.Ancho Then StrAux = StrAux.Substring(1, My.MyHardware.Ancho)
                StrCod = Ticket_ConfigTextStrong("", True)
                StrAux = Ticket_ConfigTextAling(StrAux, HorizontalAlignment.Center)
                _port.Write(StrCod & StrAux & My.MyHardware.CodEsc_Cr)

                ' > La Direccion
                StrAux = rstEmpresa("dir").Value
                If StrAux.Length > My.MyHardware.Ancho Then StrAux = StrAux.Substring(1, My.MyHardware.Ancho)
                StrCod = Ticket_ConfigTextStrong("", False)
                StrAux = Ticket_ConfigTextAling(StrAux, HorizontalAlignment.Center)
                _port.Write(StrCod & StrAux & My.MyHardware.CodEsc_Cr)

                ' > El Codigo Postal y La localidad
                StrAux = rstEmpresa("cp").Value & " - " & rstEmpresa("pob").Value
                If StrAux.Length > My.MyHardware.Ancho Then StrAux = StrAux.Substring(1, My.MyHardware.Ancho)
                StrCod = Ticket_ConfigTextStrong("", False)
                StrAux = Ticket_ConfigTextAling(StrAux, HorizontalAlignment.Center)
                _port.Write(StrCod & StrAux & My.MyHardware.CodEsc_Cr)

                ' > La provincia
                StrAux = rstEmpresa("prov").Value
                If StrAux.Length > My.MyHardware.Ancho Then StrAux = StrAux.Substring(1, My.MyHardware.Ancho)
                StrCod = Ticket_ConfigTextStrong("", False)
                StrAux = Ticket_ConfigTextAling(StrAux, HorizontalAlignment.Center)
                _port.Write(StrCod & StrAux & My.MyHardware.CodEsc_Cr)

                _port.Write(" " & My.MyHardware.CodEsc_Cr)

                '###Imprimo los detalles del Cliente
                StrAux = " " & My.MyHardware.CodEsc_Subrayado_True & "Cliente:" & My.MyHardware.CodEsc_Subrayado_False
                _port.Write(StrAux & My.MyHardware.CodEsc_Cr)
                ' > Nombre Fiscal
                StrAux = rstFactura("name_fiscal").Value
                If StrAux.Length > My.MyHardware.Ancho Then StrAux = StrAux.Substring(1, My.MyHardware.Ancho)
                StrCod = Ticket_ConfigTextStrong("", True)
                _port.Write(StrCod & StrAux & My.MyHardware.CodEsc_Cr)

                ' > El Cif
                StrAux = "CIF/NIF: " & rstFactura("cif").Value
                If StrAux.Length > My.MyHardware.Ancho Then StrAux = StrAux.Substring(1, My.MyHardware.Ancho)
                StrCod = Ticket_ConfigTextStrong("", True)
                _port.Write(StrCod & StrAux & My.MyHardware.CodEsc_Cr)

                ' > La Direccion
                StrAux = rstFactura("dir").Value
                If StrAux.Length > My.MyHardware.Ancho Then StrAux = StrAux.Substring(1, My.MyHardware.Ancho)
                StrCod = Ticket_ConfigTextStrong("", False)
                _port.Write(StrCod & StrAux & My.MyHardware.CodEsc_Cr)

                ' > El Codigo Postal y La localidad
                StrAux = rstFactura("cp").Value & " - " & rstFactura("pob").Value
                If StrAux.Length > My.MyHardware.Ancho Then StrAux = StrAux.Substring(1, My.MyHardware.Ancho)
                StrCod = Ticket_ConfigTextStrong("", False)
                _port.Write(StrCod & StrAux & My.MyHardware.CodEsc_Cr)

                ' > La provincia
                StrAux = rstFactura("prov").Value
                If StrAux.Length > My.MyHardware.Ancho Then StrAux = StrAux.Substring(1, My.MyHardware.Ancho)
                StrCod = Ticket_ConfigTextStrong("", False)
                _port.Write(StrCod & StrAux & My.MyHardware.CodEsc_Cr)

                _port.Write(" " & My.MyHardware.CodEsc_Cr)

                '###Imprimo los detalles de la factura
                StrAux = " " & My.MyHardware.CodEsc_Subrayado_True & "Detalles de la Factura:" & My.MyHardware.CodEsc_Subrayado_False
                _port.Write(StrAux & My.MyHardware.CodEsc_Cr)

                StrAux = rstFactura("n_factura").Value
                If StrAux.Length > My.MyHardware.Ancho Then StrAux = StrAux.Substring(1, My.MyHardware.Ancho)
                StrCod = Ticket_ConfigTextStrong("", True)
                _port.Write(My.MyHardware.CodEsc_Negrita_False & "Numero: " & StrCod & StrAux & My.MyHardware.CodEsc_Cr)

                StrAux = rstFactura("fh_factura").Value
                If StrAux.Length > My.MyHardware.Ancho Then StrAux = StrAux.Substring(1, My.MyHardware.Ancho)
                StrCod = Ticket_ConfigTextStrong("", True)
                _port.Write(My.MyHardware.CodEsc_Negrita_False & "Fecha: " & StrCod & StrAux & My.MyHardware.CodEsc_Negrita_False & My.MyHardware.CodEsc_Cr)

                _port.Write(" " & My.MyHardware.CodEsc_Cr)

                Dim RstCab As ADODB.Recordset, RstLines As ADODB.Recordset
                RstCab = My.m_db.GetRst("SELECT db_tickets.id,db_tickets.fh_alta,db_tickets.total,db_tickets.id_referencia,db_usuarios.name FROM db_tickets,db_usuarios WHERE db_usuarios.id=db_tickets.id_user AND db_tickets.id=" & rstFactura("id_ticket").Value)
                RstLines = My.m_db.GetRst("SELECT * FROM db_tickets_lines WHERE id_ticket=" & rstFactura("id_ticket").Value & " ORDER BY id")
                If RstCab.RecordCount = 0 Then
                    MsgBox("Error localizando el ticket.", MsgBoxStyle.Critical, "Imprimir Ticket")
                    Exit Sub
                End If

                StrAux = " " & My.MyHardware.CodEsc_Subrayado_True & "Articulo" & My.MyHardware.CodEsc_Subrayado_False
                StrAux &= Space(My.MyHardware.Ancho - 14 - 10) & My.MyHardware.CodEsc_Subrayado_True & "IVA" & My.MyHardware.CodEsc_Subrayado_False
                StrAux &= Space(1) & My.MyHardware.CodEsc_Subrayado_True & "Ud." & My.MyHardware.CodEsc_Subrayado_False
                StrAux &= Space(1) & My.MyHardware.CodEsc_Subrayado_True & "Pvp/ud" & My.MyHardware.CodEsc_Subrayado_False
                _port.Write(StrAux & My.MyHardware.CodEsc_Cr)

                While Not RstLines.EOF
                    StrAux = " " & RstLines("name").Value
                    If StrAux.Length > (My.MyHardware.Ancho - 14 - 10) Then StrAux = StrAux.Substring(0, 16)
                    StrAux &= Space(My.MyHardware.Ancho - 17 - StrAux.Length)
                    StrAux &= Space(5 - Format(RstLines("iva").Value, "##.00").Length) & Format(RstLines("iva").Value, "##.00")
                    StrAux &= Space(1)
                    StrAux &= Space(3 - Format(RstLines("ud").Value, "##0").Length) & Format(RstLines("ud").Value, "##0")

                    j = (6 - Format(RstLines("pvp_base").Value, "##0.00#").Length)
                    If j < 0 Then j = 0

                    StrAux &= " " & Space(j) & Format(RstLines("pvp_base").Value, "##0.00#")

                    _port.Write(StrAux & My.MyHardware.CodEsc_Cr)

                    'Compongo las bases
                    Select Case RstLines("iva").Value
                        Case My.m_opt.IVA_General : dblBase_16 += (RstLines("pvp_base").Value * RstLines("ud").Value)
                        Case My.m_opt.IVA_Medio : dblBase_7 += (RstLines("pvp_base").Value * RstLines("ud").Value)
                        Case My.m_opt.IVA_Basico : dblBase_4 += (RstLines("pvp_base").Value * RstLines("ud").Value)
                    End Select

                    RstLines.MoveNext()
                End While

                StrAux = My.MyHardware.CodEsc_TextNormal & " " & My.MyHardware.CodEsc_Subrayado_True & Space(My.MyHardware.Ancho - 2) & My.MyHardware.CodEsc_Subrayado_False
                _port.Write(StrAux & My.MyHardware.CodEsc_Cr)

                'Ajusto las bases imponibles
                dblBase_4 = Format(dblBase_4, "0.00")
                dblBase_7 = Format(dblBase_7, "0.00")
                dblBase_16 = Format(dblBase_16, "0.00")

                'Calculo el importe de iva
                dblIVA_4 = Format(((dblBase_4 * My.m_opt.IVA_Basico) / 100), "0.00")
                dblIVA_7 = Format(((dblBase_7 * My.m_opt.IVA_Medio) / 100), "0.00")
                dblIVA_16 = Format(((dblBase_16 * My.m_opt.IVA_General) / 100), "0.00")

                '### Imprimo las bases Imponibles
                StrAux = " " & My.MyHardware.CodEsc_Subrayado_True & "Base Imponible" & My.MyHardware.CodEsc_Subrayado_False
                StrAux &= Space(My.MyHardware.Ancho - 20 - 17) & My.MyHardware.CodEsc_Subrayado_True & "% IVA" & My.MyHardware.CodEsc_Subrayado_False
                StrAux &= Space(1) & My.MyHardware.CodEsc_Subrayado_True & "Imp IVA" & My.MyHardware.CodEsc_Subrayado_False
                StrAux &= Space(1) & My.MyHardware.CodEsc_Subrayado_True & "  Total" & My.MyHardware.CodEsc_Subrayado_False
                _port.Write(StrAux & My.MyHardware.CodEsc_Cr)
                If dblBase_4 > 0 Then
                    StrAux = " " & Format(dblBase_4, "0.00")
                    StrAux &= Space(My.MyHardware.Ancho - 22 - StrAux.Length)
                    StrAux &= Space(5 - Format(My.m_opt.IVA_Basico, "#0.00").Length) & Format(My.m_opt.IVA_Basico, "#0.00")
                    StrAux &= Space(1)
                    StrAux &= Space(7 - Format(dblIVA_4, "0.00").Length) & Format(dblIVA_4, "0.00")
                    StrAux &= Space(1)
                    StrAux &= Space(7 - Format(dblBase_4 + dblIVA_4, "0.00").Length) & Format(dblBase_4 + dblIVA_4, "0.00")
                    _port.Write(StrAux & My.MyHardware.CodEsc_Cr)
                End If

                If dblBase_7 > 0 Then
                    StrAux = " " & Format(dblBase_7, "0.00")
                    StrAux &= Space(My.MyHardware.Ancho - 22 - StrAux.Length)
                    StrAux &= Space(5 - Format(My.m_opt.IVA_Medio, "#0.00").Length) & Format(My.m_opt.IVA_Medio, "#0.00")
                    StrAux &= Space(1)
                    StrAux &= Space(7 - Format(dblIVA_7, "0.00").Length) & Format(dblIVA_7, "0.00")
                    StrAux &= Space(1)
                    StrAux &= Space(7 - Format(dblBase_7 + dblIVA_7, "0.00").Length) & Format(dblBase_7 + dblIVA_7, "0.00")
                    _port.Write(StrAux & My.MyHardware.CodEsc_Cr)
                End If

                If dblBase_16 > 0 Then
                    StrAux = " " & Format(dblBase_16, "0.00")
                    StrAux &= Space(My.MyHardware.Ancho - 22 - StrAux.Length)
                    StrAux &= Space(5 - Format(My.m_opt.IVA_General, "#0.00").Length) & Format(My.m_opt.IVA_General, "#0.00")
                    StrAux &= Space(1)
                    StrAux &= Space(7 - Format(dblIVA_16).Length) & Format(dblIVA_16, "0.00")
                    StrAux &= Space(1)
                    StrAux &= Space(7 - Format(dblBase_16 + dblIVA_16, "0.00").Length) & Format(dblBase_16 + dblIVA_16, "0.00")
                    _port.Write(StrAux & My.MyHardware.CodEsc_Cr)
                End If
                StrAux = Space(My.MyHardware.Ancho - 15) & My.MyHardware.CodEsc_Subrayado_True & Space(14) & My.MyHardware.CodEsc_Subrayado_False
                _port.Write(StrAux & My.MyHardware.CodEsc_Cr)

                dblTotal = (dblBase_4 + dblIVA_4) + (dblBase_7 + dblIVA_7) + (dblBase_16 + dblIVA_16)

                i = (6 - Format(dblTotal, "###0.00").Length)
                If i < 0 Then i = 0

                StrAux = My.MyHardware.CodEsc_Rojo & Space(My.MyHardware.Ancho - 11) & My.MyHardware.CodEsc_TextGrande & My.MyHardware.CodEsc_Negrita_True & Space(i) & Format(dblTotal, "###0.00") & " E" & My.MyHardware.CodEsc_Negrita_False & My.MyHardware.CodEsc_TextNormal
                _port.Write(StrAux & My.MyHardware.CodEsc_Cr)
                _port.Write(My.MyHardware.CodEsc_Negro & "  " & My.MyHardware.CodEsc_Subrayado_True & "Firma y Sello:" & My.MyHardware.CodEsc_Subrayado_False & My.MyHardware.CodEsc_Cr)
                For i = 0 To 4
                    _port.Write(" " & My.MyHardware.CodEsc_Cr)
                Next

                'Imprimo las lineas
                For i = 5 To 8
                    StrAux = My.MyHardware.StrCab(i)
                    StrCod = ""
                    If StrAux.Length > My.MyHardware.Ancho Then StrAux = StrAux.Substring(1, My.MyHardware.Ancho)
                    StrCod = Ticket_ConfigTextColor(StrCod, My.MyHardware.SwRed(i))
                    StrCod = Ticket_ConfigTextStrong(StrCod, My.MyHardware.SwNegrita(i))
                    StrCod = Ticket_ConfigTextSize(StrCod, My.MyHardware.SwGrande(i))
                    StrAux = Ticket_ConfigTextAling(StrAux, IIf(My.MyHardware.SwCenter(i), 2, 0), My.MyHardware.SwGrande(i))
                    If StrAux.Length <> 0 Then _port.Write(StrCod & StrAux & My.MyHardware.CodEsc_Cr)
                Next
                _port.Write(My.MyHardware.CodEsc_Salto & My.MyHardware.CodEsc_Cr)
                If Len(My.MyHardware.CodEsc_Cut) > 0 Then _port.Write(My.MyHardware.CodEsc_Cut & My.MyHardware.CodEsc_Cr)
                _port.Dispose()

            Else
                '<!--### IMPRESIÓN POR LA IMPRESORA DE NOMBRE TICKETS ###-->
                Dim strPrinter As String = "tickets"
                If My.MyHardware.CodEsc_Init.Length > 0 Then RawPrinterHelper.SendStringToPrinter(strPrinter, My.MyHardware.CodEsc_Init & My.MyHardware.CodEsc_Cr)
                StrCod = ""

                '###Imprimo los detalles de la Empresa
                ' > Nombre Fiscal
                StrAux = rstEmpresa("name_fiscal").Value
                If StrAux.Length > My.MyHardware.Ancho Then StrAux = StrAux.Substring(1, My.MyHardware.Ancho)
                StrCod = Ticket_ConfigTextStrong("", True)
                StrAux = Ticket_ConfigTextAling(StrAux, HorizontalAlignment.Center)
                RawPrinterHelper.SendStringToPrinter(strPrinter, StrCod & StrAux & My.MyHardware.CodEsc_Cr)

                ' > Nombre Comercial
                StrAux = """" & rstEmpresa("name_comercial").Value & """"
                If StrAux.Length > My.MyHardware.Ancho Then StrAux = StrAux.Substring(1, My.MyHardware.Ancho)
                StrCod = Ticket_ConfigTextStrong("", False)
                StrAux = Ticket_ConfigTextAling(StrAux, HorizontalAlignment.Center)
                RawPrinterHelper.SendStringToPrinter(strPrinter, StrCod & StrAux & My.MyHardware.CodEsc_Cr)

                ' > El Cif
                StrAux = "CIF/NIF: " & rstEmpresa("cif").Value
                If StrAux.Length > My.MyHardware.Ancho Then StrAux = StrAux.Substring(1, My.MyHardware.Ancho)
                StrCod = Ticket_ConfigTextStrong("", True)
                StrAux = Ticket_ConfigTextAling(StrAux, HorizontalAlignment.Center)
                RawPrinterHelper.SendStringToPrinter(strPrinter, StrCod & StrAux & My.MyHardware.CodEsc_Cr)

                ' > La Direccion
                StrAux = rstEmpresa("dir").Value
                If StrAux.Length > My.MyHardware.Ancho Then StrAux = StrAux.Substring(1, My.MyHardware.Ancho)
                StrCod = Ticket_ConfigTextStrong("", False)
                StrAux = Ticket_ConfigTextAling(StrAux, HorizontalAlignment.Center)
                RawPrinterHelper.SendStringToPrinter(strPrinter, StrCod & StrAux & My.MyHardware.CodEsc_Cr)

                ' > El Codigo Postal y La localidad
                StrAux = rstEmpresa("cp").Value & " - " & rstEmpresa("pob").Value
                If StrAux.Length > My.MyHardware.Ancho Then StrAux = StrAux.Substring(1, My.MyHardware.Ancho)
                StrCod = Ticket_ConfigTextStrong("", False)
                StrAux = Ticket_ConfigTextAling(StrAux, HorizontalAlignment.Center)
                RawPrinterHelper.SendStringToPrinter(strPrinter, StrCod & StrAux & My.MyHardware.CodEsc_Cr)

                ' > La provincia
                StrAux = rstEmpresa("prov").Value
                If StrAux.Length > My.MyHardware.Ancho Then StrAux = StrAux.Substring(1, My.MyHardware.Ancho)
                StrCod = Ticket_ConfigTextStrong("", False)
                StrAux = Ticket_ConfigTextAling(StrAux, HorizontalAlignment.Center)
                RawPrinterHelper.SendStringToPrinter(strPrinter, StrCod & StrAux & My.MyHardware.CodEsc_Cr)

                RawPrinterHelper.SendStringToPrinter(strPrinter, " " & My.MyHardware.CodEsc_Cr)

                '###Imprimo los detalles del Cliente
                StrAux = " " & My.MyHardware.CodEsc_Subrayado_True & "Cliente:" & My.MyHardware.CodEsc_Subrayado_False
                RawPrinterHelper.SendStringToPrinter(strPrinter, StrAux & My.MyHardware.CodEsc_Cr)
                ' > Nombre Fiscal
                StrAux = rstFactura("name_fiscal").Value
                If StrAux.Length > My.MyHardware.Ancho Then StrAux = StrAux.Substring(1, My.MyHardware.Ancho)
                StrCod = Ticket_ConfigTextStrong("", True)
                RawPrinterHelper.SendStringToPrinter(strPrinter, StrCod & StrAux & My.MyHardware.CodEsc_Cr)

                ' > El Cif
                StrAux = "CIF/NIF: " & rstFactura("cif").Value
                If StrAux.Length > My.MyHardware.Ancho Then StrAux = StrAux.Substring(1, My.MyHardware.Ancho)
                StrCod = Ticket_ConfigTextStrong("", True)
                RawPrinterHelper.SendStringToPrinter(strPrinter, StrCod & StrAux & My.MyHardware.CodEsc_Cr)

                ' > La Direccion
                StrAux = rstFactura("dir").Value
                If StrAux.Length > My.MyHardware.Ancho Then StrAux = StrAux.Substring(1, My.MyHardware.Ancho)
                StrCod = Ticket_ConfigTextStrong("", False)
                RawPrinterHelper.SendStringToPrinter(strPrinter, StrCod & StrAux & My.MyHardware.CodEsc_Cr)

                ' > El Codigo Postal y La localidad
                StrAux = rstFactura("cp").Value & " - " & rstFactura("pob").Value
                If StrAux.Length > My.MyHardware.Ancho Then StrAux = StrAux.Substring(1, My.MyHardware.Ancho)
                StrCod = Ticket_ConfigTextStrong("", False)
                RawPrinterHelper.SendStringToPrinter(strPrinter, StrCod & StrAux & My.MyHardware.CodEsc_Cr)

                ' > La provincia
                StrAux = rstFactura("prov").Value
                If StrAux.Length > My.MyHardware.Ancho Then StrAux = StrAux.Substring(1, My.MyHardware.Ancho)
                StrCod = Ticket_ConfigTextStrong("", False)
                RawPrinterHelper.SendStringToPrinter(strPrinter, StrCod & StrAux & My.MyHardware.CodEsc_Cr)

                RawPrinterHelper.SendStringToPrinter(strPrinter, " " & My.MyHardware.CodEsc_Cr)

                '###Imprimo los detalles de la factura
                StrAux = " " & My.MyHardware.CodEsc_Subrayado_True & "Detalles de la Factura:" & My.MyHardware.CodEsc_Subrayado_False
                RawPrinterHelper.SendStringToPrinter(strPrinter, StrAux & My.MyHardware.CodEsc_Cr)

                StrAux = rstFactura("n_factura").Value
                If StrAux.Length > My.MyHardware.Ancho Then StrAux = StrAux.Substring(1, My.MyHardware.Ancho)
                StrCod = Ticket_ConfigTextStrong("", True)
                RawPrinterHelper.SendStringToPrinter(strPrinter, My.MyHardware.CodEsc_Negrita_False & "Numero: " & StrCod & StrAux & My.MyHardware.CodEsc_Cr)

                StrAux = rstFactura("fh_factura").Value
                If StrAux.Length > My.MyHardware.Ancho Then StrAux = StrAux.Substring(1, My.MyHardware.Ancho)
                StrCod = Ticket_ConfigTextStrong("", True)
                RawPrinterHelper.SendStringToPrinter(strPrinter, My.MyHardware.CodEsc_Negrita_False & "Fecha: " & StrCod & StrAux & My.MyHardware.CodEsc_Negrita_False & My.MyHardware.CodEsc_Cr)

                If Not IsDBNull(rstFactura("obs").Value) Then
                    If rstFactura("obs").Value.ToString.Length > 0 Then
                        StrAux = rstFactura("obs").Value
                        RawPrinterHelper.SendStringToPrinter(strPrinter, My.MyHardware.CodEsc_Negrita_False & "Detalles: " & StrCod & StrAux & My.MyHardware.CodEsc_Negrita_False & My.MyHardware.CodEsc_Cr)
                    End If
                End If



                RawPrinterHelper.SendStringToPrinter(strPrinter, " " & My.MyHardware.CodEsc_Cr)

                Dim RstCab As ADODB.Recordset, RstLines As ADODB.Recordset
                RstCab = My.m_db.GetRst("SELECT db_tickets.id,db_tickets.fh_alta,db_tickets.total,db_tickets.id_referencia,db_usuarios.name FROM db_tickets,db_usuarios WHERE db_usuarios.id=db_tickets.id_user AND db_tickets.id=" & rstFactura("id_ticket").Value)
                RstLines = My.m_db.GetRst("SELECT * FROM db_tickets_lines WHERE id_ticket=" & rstFactura("id_ticket").Value & " ORDER BY id")
                If RstCab.RecordCount = 0 Then
                    MsgBox("Error localizando el ticket.", MsgBoxStyle.Critical, "Imprimir Ticket")
                    Exit Sub
                End If

                StrAux = " " & My.MyHardware.CodEsc_Subrayado_True & "Articulo" & My.MyHardware.CodEsc_Subrayado_False
                StrAux &= Space(My.MyHardware.Ancho - 14 - 10) & My.MyHardware.CodEsc_Subrayado_True & "IVA" & My.MyHardware.CodEsc_Subrayado_False
                StrAux &= Space(1) & My.MyHardware.CodEsc_Subrayado_True & "Ud." & My.MyHardware.CodEsc_Subrayado_False
                StrAux &= Space(1) & My.MyHardware.CodEsc_Subrayado_True & "Pre/ud" & My.MyHardware.CodEsc_Subrayado_False
                RawPrinterHelper.SendStringToPrinter(strPrinter, StrAux & My.MyHardware.CodEsc_Cr)

                While Not RstLines.EOF
                    StrAux = " " & RstLines("name").Value
                    If StrAux.Length > (My.MyHardware.Ancho - 14 - 10) Then StrAux = StrAux.Substring(0, 16)
                    StrAux &= Space(My.MyHardware.Ancho - 17 - StrAux.Length)
                    StrAux &= Space(5 - Format(RstLines("iva").Value, "##.00").Length) & Format(RstLines("iva").Value, "##.00")
                    StrAux &= Space(1)
                    StrAux &= Space(3 - Format(RstLines("ud").Value, "##0").Length) & Format(RstLines("ud").Value, "##0")

                    j = (6 - Format(RstLines("pvp_base").Value, "##0.00#").Length)
                    If j < 0 Then j = 0

                    StrAux &= " " & Space(j) & Format(RstLines("pvp_base").Value, "##0.00#")

                    RawPrinterHelper.SendStringToPrinter(strPrinter, StrAux & My.MyHardware.CodEsc_Cr)

                    'Compongo las bases
                    Select Case RstLines("iva").Value
                        Case My.m_opt.IVA_General : dblBase_16 += (RstLines("pvp_base").Value * RstLines("ud").Value)
                        Case My.m_opt.IVA_Medio : dblBase_7 += (RstLines("pvp_base").Value * RstLines("ud").Value)
                        Case My.m_opt.IVA_Basico : dblBase_4 += (RstLines("pvp_base").Value * RstLines("ud").Value)
                    End Select

                    RstLines.MoveNext()
                End While

                StrAux = My.MyHardware.CodEsc_TextNormal & " " & My.MyHardware.CodEsc_Subrayado_True & Space(My.MyHardware.Ancho - 2) & My.MyHardware.CodEsc_Subrayado_False
                RawPrinterHelper.SendStringToPrinter(strPrinter, StrAux & My.MyHardware.CodEsc_Cr)

                'Ajusto las bases imponibles
                dblBase_4 = Format(dblBase_4, "0.00")
                dblBase_7 = Format(dblBase_7, "0.00")
                dblBase_16 = Format(dblBase_16, "0.00")

                'Calculo el importe de iva
                dblIVA_4 = Format(((dblBase_4 * My.m_opt.IVA_Basico) / 100), "0.00")
                dblIVA_7 = Format(((dblBase_7 * My.m_opt.IVA_Medio) / 100), "0.00")
                dblIVA_16 = Format(((dblBase_16 * My.m_opt.IVA_General) / 100), "0.00")

                '### Imprimo las bases Imponibles
                StrAux = " " & My.MyHardware.CodEsc_Subrayado_True & "Base Imponible" & My.MyHardware.CodEsc_Subrayado_False
                StrAux &= Space(My.MyHardware.Ancho - 20 - 17) & My.MyHardware.CodEsc_Subrayado_True & "% IVA" & My.MyHardware.CodEsc_Subrayado_False
                StrAux &= Space(1) & My.MyHardware.CodEsc_Subrayado_True & "Imp IVA" & My.MyHardware.CodEsc_Subrayado_False
                StrAux &= Space(1) & My.MyHardware.CodEsc_Subrayado_True & "  Total" & My.MyHardware.CodEsc_Subrayado_False
                RawPrinterHelper.SendStringToPrinter(strPrinter, StrAux & My.MyHardware.CodEsc_Cr)
                If dblBase_4 > 0 Then
                    StrAux = " " & Format(dblBase_4, "0.00")
                    StrAux &= Space(My.MyHardware.Ancho - 22 - StrAux.Length)
                    StrAux &= Space(5 - Format(My.m_opt.IVA_Basico, "#0.00").Length) & Format(My.m_opt.IVA_Basico, "#0.00")
                    StrAux &= Space(1)
                    StrAux &= Space(7 - Format(dblIVA_4, "0.00").Length) & Format(dblIVA_4, "0.00")
                    StrAux &= Space(1)
                    StrAux &= Space(7 - Format(dblBase_4 + dblIVA_4, "0.00").Length) & Format(dblBase_4 + dblIVA_4, "0.00")
                    RawPrinterHelper.SendStringToPrinter(strPrinter, StrAux & My.MyHardware.CodEsc_Cr)
                End If

                If dblBase_7 > 0 Then
                    StrAux = " " & Format(dblBase_7, "0.00")
                    StrAux &= Space(My.MyHardware.Ancho - 22 - StrAux.Length)
                    StrAux &= Space(5 - Format(My.m_opt.IVA_Medio, "#0.00").Length) & Format(My.m_opt.IVA_Medio, "#0.00")
                    StrAux &= Space(1)
                    StrAux &= Space(7 - Format(dblIVA_7, "0.00").Length) & Format(dblIVA_7, "0.00")
                    StrAux &= Space(1)
                    StrAux &= Space(7 - Format(dblBase_7 + dblIVA_7, "0.00").Length) & Format(dblBase_7 + dblIVA_7, "0.00")
                    RawPrinterHelper.SendStringToPrinter(strPrinter, StrAux & My.MyHardware.CodEsc_Cr)
                End If

                If dblBase_16 > 0 Then
                    StrAux = " " & Format(dblBase_16, "0.00")
                    StrAux &= Space(My.MyHardware.Ancho - 22 - StrAux.Length)
                    StrAux &= Space(5 - Format(My.m_opt.IVA_General, "#0.00").Length) & Format(My.m_opt.IVA_General, "#0.00")
                    StrAux &= Space(1)
                    StrAux &= Space(7 - Format(dblIVA_16).Length) & Format(dblIVA_16, "0.00")
                    StrAux &= Space(1)
                    StrAux &= Space(7 - Format(dblBase_16 + dblIVA_16, "0.00").Length) & Format(dblBase_16 + dblIVA_16, "0.00")
                    RawPrinterHelper.SendStringToPrinter(strPrinter, StrAux & My.MyHardware.CodEsc_Cr)
                End If
                StrAux = Space(My.MyHardware.Ancho - 15) & My.MyHardware.CodEsc_Subrayado_True & Space(14) & My.MyHardware.CodEsc_Subrayado_False
                RawPrinterHelper.SendStringToPrinter(strPrinter, StrAux & My.MyHardware.CodEsc_Cr)

                dblTotal = (dblBase_4 + dblIVA_4) + (dblBase_7 + dblIVA_7) + (dblBase_16 + dblIVA_16)

                i = (6 - Format(dblTotal, "###0.00").Length)
                If i < 0 Then i = 0


                If Not IsDBNull(RstCab("dto").Value) Then
                    If CDbl(RstCab("dto").Value) <> 0 Then          'DTO
                        StrAux = "Dto: " & My.MyHardware.CodEsc_TextGrande & Format(RstCab("dto").Value, "###0.00") & My.MyHardware.CodEsc_TextNormal
                        StrAux = Space(My.MyHardware.Ancho - StrAux.Length - 1) & StrAux
                        RawPrinterHelper.SendStringToPrinter(strPrinter, My.MyHardware.CodEsc_Negro & StrAux & My.MyHardware.CodEsc_Cr)
                    End If
                End If

                StrAux = My.MyHardware.CodEsc_Rojo & Space(My.MyHardware.Ancho - 11) & My.MyHardware.CodEsc_TextGrande & My.MyHardware.CodEsc_Negrita_True & Space(i) & Format(dblTotal, "###0.00") & " E" & My.MyHardware.CodEsc_Negrita_False & My.MyHardware.CodEsc_TextNormal
                RawPrinterHelper.SendStringToPrinter(strPrinter, StrAux & My.MyHardware.CodEsc_Cr)
                RawPrinterHelper.SendStringToPrinter(strPrinter, My.MyHardware.CodEsc_Negro & "  " & My.MyHardware.CodEsc_Subrayado_True & "Firma y Sello:" & My.MyHardware.CodEsc_Subrayado_False & My.MyHardware.CodEsc_Cr)
                For i = 0 To 4
                    RawPrinterHelper.SendStringToPrinter(strPrinter, " " & My.MyHardware.CodEsc_Cr)
                Next

                'Imprimo las lineas
                For i = 5 To 8
                    StrAux = My.MyHardware.StrCab(i)
                    StrCod = ""
                    If StrAux.Length > My.MyHardware.Ancho Then StrAux = StrAux.Substring(1, My.MyHardware.Ancho)
                    StrCod = Ticket_ConfigTextColor(StrCod, My.MyHardware.SwRed(i))
                    StrCod = Ticket_ConfigTextStrong(StrCod, My.MyHardware.SwNegrita(i))
                    StrCod = Ticket_ConfigTextSize(StrCod, My.MyHardware.SwGrande(i))
                    StrAux = Ticket_ConfigTextAling(StrAux, IIf(My.MyHardware.SwCenter(i), 2, 0), My.MyHardware.SwGrande(i))
                    If StrAux.Length <> 0 Then RawPrinterHelper.SendStringToPrinter(strPrinter, StrCod & StrAux & My.MyHardware.CodEsc_Cr)
                Next
                RawPrinterHelper.SendStringToPrinter(strPrinter, My.MyHardware.CodEsc_Salto & My.MyHardware.CodEsc_Cr)
                If Len(My.MyHardware.CodEsc_Cut) > 0 Then RawPrinterHelper.SendStringToPrinter(strPrinter, My.MyHardware.CodEsc_Cut & My.MyHardware.CodEsc_Cr)

            End If
        End Sub

        'Impresion de un Ticket de Prueba
        Public Sub PreviewTicket()
            'Abro el cajon
            OpenCajon()

            If My.MyHardware.IdPort = 0 Then Exit Sub
            If My.MyHardware.PortName.Substring(0, 3) = "COM" Then
                Try
                    Dim _port As IO.Ports.SerialPort
                    _port = New IO.Ports.SerialPort(My.MyHardware.PortName, 9600, IO.Ports.Parity.None, 8, IO.Ports.StopBits.One)
                    _port.DiscardNull = True
                    _port.WriteBufferSize = 2024
                    _port.DtrEnable = True
                    _port.Handshake = IO.Ports.Handshake.None

                    _port.Open()


                    Dim StrAux As String, i As Integer
                    If My.MyHardware.CodEsc_Init.Length > 0 Then _port.Write(My.MyHardware.CodEsc_Init & My.MyHardware.CodEsc_Cr)
                    StrCod = ""
                    'Imprimo la cabezera
                    For i = 1 To 4
                        StrAux = My.MyHardware.StrCab(i)
                        StrCod = ""
                        If StrAux.Length > My.MyHardware.Ancho Then StrAux = StrAux.Substring(1, My.MyHardware.Ancho)
                        StrCod = Ticket_ConfigTextColor(StrCod, My.MyHardware.SwRed(i))
                        StrCod = Ticket_ConfigTextStrong(StrCod, My.MyHardware.SwNegrita(i))
                        StrCod = Ticket_ConfigTextSize(StrCod, My.MyHardware.SwGrande(i))
                        StrAux = Ticket_ConfigTextAling(StrAux, IIf(My.MyHardware.SwCenter(i), 2, 0), My.MyHardware.SwGrande(i))
                        If StrAux.Length <> 0 Then _port.Write(StrCod & StrAux & My.MyHardware.CodEsc_Cr)
                    Next
                    _port.Write(My.MyHardware.CodEsc_Cr)
                    _port.Close()
                    _port.Open()

                    StrAux = "Ref.: 000000"
                    StrAux &= Space(My.MyHardware.Ancho - StrAux.Length - Format(Now, "dd/MM/yyyy HH:mm").Length) & Format(Now, "dd/MM/yyyy HH:mm")
                    _port.Write(StrAux & My.MyHardware.CodEsc_Cr)
                    _port.Close()
                    _port.Open()

                    StrAux = " " & My.MyHardware.CodEsc_Subrayado_True & "Articulo" & My.MyHardware.CodEsc_Subrayado_False
                    StrAux &= Space(My.MyHardware.Ancho - 20) & My.MyHardware.CodEsc_Subrayado_True & "Ud." & My.MyHardware.CodEsc_Subrayado_False
                    StrAux &= Space(2) & My.MyHardware.CodEsc_Subrayado_True & "Total" & My.MyHardware.CodEsc_Subrayado_False
                    _port.Write(StrAux & My.MyHardware.CodEsc_Cr)
                    _port.Close()
                    _port.Open()


                    StrAux = " XXXXXXXXXXXXXXX"
                    StrAux &= Space(My.MyHardware.Ancho - 11 - StrAux.Length) & "1   999.99"
                    _port.Write(StrAux & My.MyHardware.CodEsc_Cr)
                    _port.Write(StrAux & My.MyHardware.CodEsc_Cr)

                    StrAux = Space(32) & "-------"
                    _port.Write(StrAux & My.MyHardware.CodEsc_Cr)

                    StrAux = My.MyHardware.CodEsc_Rojo & Space(29) & My.MyHardware.CodEsc_TextGrande & My.MyHardware.CodEsc_Negrita_True & "0000.00 E" & My.MyHardware.CodEsc_Negrita_False & My.MyHardware.CodEsc_TextNormal
                    _port.Write(StrAux & My.MyHardware.CodEsc_Cr)


                    StrAux = My.MyHardware.CodEsc_Negro & Space(My.MyHardware.Ancho - 14) & "(IVA INCLUIDO)"
                    _port.Write(StrAux & My.MyHardware.CodEsc_Cr)
                    _port.Write(" " & My.MyHardware.CodEsc_Cr)
                    _port.Write(My.MyHardware.CodEsc_Negro & My.MyHardware.CodEsc_Cr)
                    _port.Close()
                    _port.Open()


                    'Imprimo las lineas
                    For i = 5 To 8
                        StrAux = My.MyHardware.StrCab(i)
                        StrCod = ""
                        If StrAux.Length > My.MyHardware.Ancho Then StrAux = StrAux.Substring(1, My.MyHardware.Ancho)
                        StrCod = Ticket_ConfigTextColor(StrCod, My.MyHardware.SwRed(i))
                        StrCod = Ticket_ConfigTextStrong(StrCod, My.MyHardware.SwNegrita(i))
                        StrCod = Ticket_ConfigTextSize(StrCod, My.MyHardware.SwGrande(i))
                        StrAux = Ticket_ConfigTextAling(StrAux, IIf(My.MyHardware.SwCenter(i), 2, 0), My.MyHardware.SwGrande(i))
                        If StrAux.Length <> 0 Then _port.Write(StrCod & StrAux & My.MyHardware.CodEsc_Cr)
                    Next

                    _port.Write(My.MyHardware.CodEsc_Salto & My.MyHardware.CodEsc_Cr)
                    If Len(My.MyHardware.CodEsc_Cut) > 0 Then _port.Write(My.MyHardware.CodEsc_Cut & My.MyHardware.CodEsc_Cr)

                    _port.Close()
                    _port.Open()

                    _port.Dispose()
                Catch ex As Exception
                    MsgBox(ex.Message, MsgBoxStyle.Critical)
                End Try
            ElseIf My.MyHardware.PortName.Substring(0, 3) = "LPT" Then
                '### IMPRESIÓN POR PARALELO
                Dim _port As m_Crypto.ioParerellPort
                _port = New m_Crypto.ioParerellPort("LPT" & My.MyHardware.IdPort)


                Dim StrAux As String, i As Integer
                If My.MyHardware.CodEsc_Init.Length > 0 Then _port.Write(My.MyHardware.CodEsc_Init & My.MyHardware.CodEsc_Cr)
                StrCod = ""
                'Imprimo la cabezera
                For i = 1 To 4
                    StrAux = My.MyHardware.StrCab(i)
                    StrCod = ""
                    If StrAux.Length > My.MyHardware.Ancho Then StrAux = StrAux.Substring(1, My.MyHardware.Ancho)
                    StrCod = Ticket_ConfigTextColor(StrCod, My.MyHardware.SwRed(i))
                    StrCod = Ticket_ConfigTextStrong(StrCod, My.MyHardware.SwNegrita(i))
                    StrCod = Ticket_ConfigTextSize(StrCod, My.MyHardware.SwGrande(i))
                    StrAux = Ticket_ConfigTextAling(StrAux, IIf(My.MyHardware.SwCenter(i), 2, 0), My.MyHardware.SwGrande(i))
                    If StrAux.Length <> 0 Then _port.Write(StrCod & StrAux & My.MyHardware.CodEsc_Cr)
                Next
                _port.Write(My.MyHardware.CodEsc_Cr)


                StrAux = "Ref.: 000000"
                StrAux &= Space(My.MyHardware.Ancho - StrAux.Length - Format(Now, "dd/MM/yyyy HH:mm").Length) & Format(Now, "dd/MM/yyyy HH:mm")
                _port.Write(StrAux & My.MyHardware.CodEsc_Cr)


                StrAux = " " & My.MyHardware.CodEsc_Subrayado_True & "Articulo" & My.MyHardware.CodEsc_Subrayado_False
                StrAux &= Space(My.MyHardware.Ancho - 20) & My.MyHardware.CodEsc_Subrayado_True & "Ud." & My.MyHardware.CodEsc_Subrayado_False
                StrAux &= Space(2) & My.MyHardware.CodEsc_Subrayado_True & "Total" & My.MyHardware.CodEsc_Subrayado_False
                _port.Write(StrAux & My.MyHardware.CodEsc_Cr)

                StrAux = " XXXXXXXXXXXXXXX"
                StrAux &= Space(My.MyHardware.Ancho - 11 - StrAux.Length) & "1   999.99"
                _port.Write(StrAux & My.MyHardware.CodEsc_Cr)
                _port.Write(StrAux & My.MyHardware.CodEsc_Cr)

                StrAux = Space(32) & "-------"
                _port.Write(StrAux & My.MyHardware.CodEsc_Cr)

                StrAux = My.MyHardware.CodEsc_Rojo & Space(29) & My.MyHardware.CodEsc_TextGrande & My.MyHardware.CodEsc_Negrita_True & "0000.00 E" & My.MyHardware.CodEsc_Negrita_False & My.MyHardware.CodEsc_TextNormal
                _port.Write(StrAux & My.MyHardware.CodEsc_Cr)


                StrAux = My.MyHardware.CodEsc_Negro & Space(My.MyHardware.Ancho - 14) & "(IVA INCLUIDO)"
                _port.Write(StrAux & My.MyHardware.CodEsc_Cr)
                _port.Write(" " & My.MyHardware.CodEsc_Cr)
                _port.Write(My.MyHardware.CodEsc_Negro & My.MyHardware.CodEsc_Cr)

                'Imprimo las lineas
                For i = 5 To 8
                    StrAux = My.MyHardware.StrCab(i)
                    StrCod = ""
                    If StrAux.Length > My.MyHardware.Ancho Then StrAux = StrAux.Substring(1, My.MyHardware.Ancho)
                    StrCod = Ticket_ConfigTextColor(StrCod, My.MyHardware.SwRed(i))
                    StrCod = Ticket_ConfigTextStrong(StrCod, My.MyHardware.SwNegrita(i))
                    StrCod = Ticket_ConfigTextSize(StrCod, My.MyHardware.SwGrande(i))
                    StrAux = Ticket_ConfigTextAling(StrAux, IIf(My.MyHardware.SwCenter(i), 2, 0), My.MyHardware.SwGrande(i))
                    If StrAux.Length <> 0 Then _port.Write(StrCod & StrAux & My.MyHardware.CodEsc_Cr)
                Next
                _port.Write(My.MyHardware.CodEsc_Salto & My.MyHardware.CodEsc_Cr)
                If Len(My.MyHardware.CodEsc_Cut) > 0 Then _port.Write(My.MyHardware.CodEsc_Cut & My.MyHardware.CodEsc_Cr)
                _port.Dispose()
            Else
                '### IMPRESIÓN POR RAW
                Dim strPrinter As String = "tickets"

                Dim StrAux As String, i As Integer
                If My.MyHardware.CodEsc_Init.Length > 0 Then RawPrinterHelper.SendStringToPrinter(strPrinter, My.MyHardware.CodEsc_Init & My.MyHardware.CodEsc_Cr)
                StrCod = ""
                'Imprimo la cabezera
                For i = 1 To 4
                    StrAux = My.MyHardware.StrCab(i)
                    StrCod = ""
                    If StrAux.Length > My.MyHardware.Ancho Then StrAux = StrAux.Substring(1, My.MyHardware.Ancho)
                    StrCod = Ticket_ConfigTextColor(StrCod, My.MyHardware.SwRed(i))
                    StrCod = Ticket_ConfigTextStrong(StrCod, My.MyHardware.SwNegrita(i))
                    StrCod = Ticket_ConfigTextSize(StrCod, My.MyHardware.SwGrande(i))
                    StrAux = Ticket_ConfigTextAling(StrAux, IIf(My.MyHardware.SwCenter(i), 2, 0), My.MyHardware.SwGrande(i))
                    If StrAux.Length <> 0 Then RawPrinterHelper.SendStringToPrinter(strPrinter, StrCod & StrAux & My.MyHardware.CodEsc_Cr)
                Next
                RawPrinterHelper.SendStringToPrinter(strPrinter, My.MyHardware.CodEsc_Cr)


                StrAux = "Ref.: 000000"
                StrAux &= Space(My.MyHardware.Ancho - StrAux.Length - Format(Now, "dd/MM/yyyy HH:mm").Length) & Format(Now, "dd/MM/yyyy HH:mm")
                RawPrinterHelper.SendStringToPrinter(strPrinter, StrAux & My.MyHardware.CodEsc_Cr)


                StrAux = " " & My.MyHardware.CodEsc_Subrayado_True & "Articulo" & My.MyHardware.CodEsc_Subrayado_False
                StrAux &= Space(My.MyHardware.Ancho - 20) & My.MyHardware.CodEsc_Subrayado_True & "Ud." & My.MyHardware.CodEsc_Subrayado_False
                StrAux &= Space(2) & My.MyHardware.CodEsc_Subrayado_True & "Total" & My.MyHardware.CodEsc_Subrayado_False
                RawPrinterHelper.SendStringToPrinter(strPrinter, StrAux & My.MyHardware.CodEsc_Cr)

                StrAux = " XXXXXXXXXXXXXXX"
                StrAux &= Space(My.MyHardware.Ancho - 11 - StrAux.Length) & "1   999.99"
                RawPrinterHelper.SendStringToPrinter(strPrinter, StrAux & My.MyHardware.CodEsc_Cr)
                RawPrinterHelper.SendStringToPrinter(strPrinter, StrAux & My.MyHardware.CodEsc_Cr)

                StrAux = Space(32) & "-------"
                RawPrinterHelper.SendStringToPrinter(strPrinter, StrAux & My.MyHardware.CodEsc_Cr)

                StrAux = My.MyHardware.CodEsc_Rojo & Space(29) & My.MyHardware.CodEsc_TextGrande & My.MyHardware.CodEsc_Negrita_True & "0000.00 E" & My.MyHardware.CodEsc_Negrita_False & My.MyHardware.CodEsc_TextNormal
                RawPrinterHelper.SendStringToPrinter(strPrinter, StrAux & My.MyHardware.CodEsc_Cr)


                StrAux = My.MyHardware.CodEsc_Negro & Space(My.MyHardware.Ancho - 14) & "(IVA INCLUIDO)"
                RawPrinterHelper.SendStringToPrinter(strPrinter, StrAux & My.MyHardware.CodEsc_Cr)
                RawPrinterHelper.SendStringToPrinter(strPrinter, " " & My.MyHardware.CodEsc_Cr)
                RawPrinterHelper.SendStringToPrinter(strPrinter, My.MyHardware.CodEsc_Negro & My.MyHardware.CodEsc_Cr)

                'Imprimo las lineas
                For i = 5 To 8
                    StrAux = My.MyHardware.StrCab(i)
                    StrCod = ""
                    If StrAux.Length > My.MyHardware.Ancho Then StrAux = StrAux.Substring(1, My.MyHardware.Ancho)
                    StrCod = Ticket_ConfigTextColor(StrCod, My.MyHardware.SwRed(i))
                    StrCod = Ticket_ConfigTextStrong(StrCod, My.MyHardware.SwNegrita(i))
                    StrCod = Ticket_ConfigTextSize(StrCod, My.MyHardware.SwGrande(i))
                    StrAux = Ticket_ConfigTextAling(StrAux, IIf(My.MyHardware.SwCenter(i), 2, 0), My.MyHardware.SwGrande(i))
                    If StrAux.Length <> 0 Then RawPrinterHelper.SendStringToPrinter(strPrinter, StrCod & StrAux & My.MyHardware.CodEsc_Cr)
                Next
                RawPrinterHelper.SendStringToPrinter(strPrinter, My.MyHardware.CodEsc_Salto & My.MyHardware.CodEsc_Cr)
                If Len(My.MyHardware.CodEsc_Cut) > 0 Then RawPrinterHelper.SendStringToPrinter(strPrinter, My.MyHardware.CodEsc_Cut & My.MyHardware.CodEsc_Cr)

            End If
        End Sub

        'Impresion de un Ticket de Prueba
        Public Sub PreviewComanda()
            If My.MyComanda.IdPort = 0 Then Exit Sub
            If My.MyComanda.PortName.Substring(0, 3) = "COM" Then
                MsgBox("Modo No soportado, contacte con su distribuidor.", MsgBoxStyle.Critical)
            ElseIf My.MyComanda.PortName.Substring(0, 3) = "LPT" Then
                MsgBox("Modo No soportado, contacte con su distribuidor.", MsgBoxStyle.Critical)
            Else

                '### IMPRESIÓN POR RAW
                Dim strPrinter As String = "comandas"

                Dim StrAux As String, i As Integer
                If My.MyComanda.CodEsc_Init.Length > 0 Then RawPrinterHelper.SendStringToPrinter(strPrinter, My.MyComanda.CodEsc_Init & My.MyComanda.CodEsc_Cr)
                StrCod = ""
                'Imprimo la cabezera
                For i = 1 To 4
                    StrAux = My.MyComanda.StrCab(i)
                    StrCod = ""
                    If StrAux.Length > My.MyComanda.Ancho Then StrAux = StrAux.Substring(1, My.MyComanda.Ancho)
                    StrCod = Ticket_ConfigTextColor(StrCod, My.MyComanda.SwRed(i))
                    StrCod = Ticket_ConfigTextStrong(StrCod, My.MyComanda.SwNegrita(i))
                    StrCod = Ticket_ConfigTextSize(StrCod, My.MyComanda.SwGrande(i))
                    StrAux = Ticket_ConfigTextAling(StrAux, IIf(My.MyComanda.SwCenter(i), 2, 0), My.MyComanda.SwGrande(i))
                    If StrAux.Length <> 0 Then RawPrinterHelper.SendStringToPrinter(strPrinter, StrCod & StrAux & My.MyComanda.CodEsc_Cr)
                Next
                RawPrinterHelper.SendStringToPrinter(strPrinter, My.MyComanda.CodEsc_Cr)


                StrAux = "Ref.: 000000"
                StrAux &= Space(My.MyComanda.Ancho - StrAux.Length - Format(Now, "dd/MM/yyyy HH:mm").Length) & Format(Now, "dd/MM/yyyy HH:mm")
                RawPrinterHelper.SendStringToPrinter(strPrinter, StrAux & My.MyComanda.CodEsc_Cr)

                StrAux = "Mesa: Mesa 42"
                RawPrinterHelper.SendStringToPrinter(strPrinter, StrAux & My.MyComanda.CodEsc_Cr)


                StrAux = " " & My.MyComanda.CodEsc_Subrayado_True & "Comanda" & My.MyComanda.CodEsc_Subrayado_False
                StrAux &= Space(My.MyComanda.Ancho - 20) & My.MyComanda.CodEsc_Subrayado_True & "Ud." & My.MyComanda.CodEsc_Subrayado_False
                StrAux &= Space(2) & My.MyComanda.CodEsc_Subrayado_True & "" & My.MyComanda.CodEsc_Subrayado_False
                RawPrinterHelper.SendStringToPrinter(strPrinter, StrAux & My.MyComanda.CodEsc_Cr)

                StrAux = " XXXXXXXXXXXXXXXXXXX XXXXXXX"
                StrAux &= Space(My.MyComanda.Ancho - 11 - StrAux.Length) & "2"
                RawPrinterHelper.SendStringToPrinter(strPrinter, StrAux & My.MyComanda.CodEsc_Cr)
                RawPrinterHelper.SendStringToPrinter(strPrinter, StrAux & My.MyComanda.CodEsc_Cr)

                'StrAux = Space(32) & "-------"
                'RawPrinterHelper.SendStringToPrinter(strPrinter, StrAux & My.MyComanda.CodEsc_Cr)

                'StrAux = My.MyComanda.CodEsc_Rojo & Space(29) & My.MyComanda.CodEsc_TextGrande & My.MyComanda.CodEsc_Negrita_True & "0000.00 E" & My.MyComanda.CodEsc_Negrita_False & My.MyComanda.CodEsc_TextNormal
                'RawPrinterHelper.SendStringToPrinter(strPrinter, StrAux & My.MyComanda.CodEsc_Cr)


                'StrAux = My.MyComanda.CodEsc_Negro & Space(My.MyComanda.Ancho - 14) & "(IVA INCLUIDO)"
                'RawPrinterHelper.SendStringToPrinter(strPrinter, StrAux & My.MyComanda.CodEsc_Cr)
                'RawPrinterHelper.SendStringToPrinter(strPrinter, " " & My.MyComanda.CodEsc_Cr)
                'RawPrinterHelper.SendStringToPrinter(strPrinter, My.MyComanda.CodEsc_Negro & My.MyComanda.CodEsc_Cr)

                ''Imprimo las lineas
                'For i = 5 To 8
                '    StrAux = My.MyComanda.StrCab(i)
                '    StrCod = ""
                '    If StrAux.Length > My.MyComanda.Ancho Then StrAux = StrAux.Substring(1, My.MyComanda.Ancho)
                '    StrCod = Ticket_ConfigTextColor(StrCod, My.MyComanda.SwRed(i))
                '    StrCod = Ticket_ConfigTextStrong(StrCod, My.MyComanda.SwNegrita(i))
                '    StrCod = Ticket_ConfigTextSize(StrCod, My.MyComanda.SwGrande(i))
                '    StrAux = Ticket_ConfigTextAling(StrAux, IIf(My.MyComanda.SwCenter(i), 2, 0), My.MyComanda.SwGrande(i))
                '    If StrAux.Length <> 0 Then RawPrinterHelper.SendStringToPrinter(strPrinter, StrCod & StrAux & My.MyComanda.CodEsc_Cr)
                'Next

                RawPrinterHelper.SendStringToPrinter(strPrinter, My.MyComanda.CodEsc_Salto & My.MyComanda.CodEsc_Cr)
                If Len(My.MyComanda.CodEsc_Cut) > 0 Then RawPrinterHelper.SendStringToPrinter(strPrinter, My.MyComanda.CodEsc_Cut & My.MyComanda.CodEsc_Cr)


            End If
        End Sub

        'Función para solucionar el problema de los acentos
        Public Function FixCHARISO(ByVal str As String) As String
            Dim strOrig As String = "áéíóúÁÉÍÓÚñÑ€ºª"
            Dim strDest As String = "aeiouAEIOUnNeoa"
            Dim i As Integer = 0
            For i = 0 To strOrig.Length - 1
                str = str.Replace(strOrig(i), strDest(i))
            Next
            Return str
        End Function



        'Funcion para añadir espacios a la linea
        Private Function addSpace(ByVal strObs As String) As String
            Dim str As String = strObs.Replace(vbCrLf, vbCrLf & "   ")
            str = str.Replace(vbCr, vbCr & "   ")
            Return str
        End Function

#End Region

        '#Region "Impresion de Comandas"
        '        Public Sub PrintComanda(ByVal idTicket As Integer)
        '            Dim rst As ADODB.Recordset = Nothing
        '            rst = My.m_db.GetRst("SELECT * FROM WHERE 


        '        End Sub
        '#End Region

#Region "Apertura del Cajon"
#Region "API's para el Cash Drawer"
        'Declare Function MapPhysToLin Lib "WinIo.dll" (ByVal PhysAddr As Long, ByVal PhysSize As Long, ByRef PhysMemHandle) As Long
        'Private Declare Function MapPhysToLin Lib "WinIo.dll" (ByVal PhysAddr As Long, ByVal PhysSize As Long, ByRef PhysMemHandle As Long) As Long
        'Private Declare Function UnmapPhysicalMemory Lib "WinIo.dll" (ByVal PhysMemHandle, ByVal LinAddr) As Boolean
        'Private Declare Function GetPhysLong Lib "WinIo.dll" (ByVal PhysAddr As Long, ByRef PhysVal As Long) As Boolean
        'Private Declare Function SetPhysLong Lib "WinIo.dll" (ByVal PhysAddr As Long, ByVal PhysVal As Long) As Boolean
        'Private Declare Function GetPortVal Lib "WinIo.dll" (ByVal PortAddr As Integer, ByRef PortVal As Long, ByVal bSize As Byte) As Boolean
        'Private Declare Function SetPortVal Lib "WinIo.dll" (ByVal PortAddr As Integer, ByVal PortVal As Long, ByVal bSize As Byte) As Boolean
        Private Declare Function SetPortVal Lib "WinIo.dll" (ByVal PortAddr As Int16, ByVal PortVal As Int32, ByVal bSize As Byte) As Boolean
        Private Declare Function InitializeWinIo Lib "WinIo.dll" () As Boolean
        Private Declare Function ShutdownWinIo Lib "WinIo.dll" () As Boolean
        'Private Declare Function InstallWinIoDriver Lib "WinIo.dll" (ByVal DriverPath As String, ByVal Mode As Integer) As Boolean
        'Private Declare Function RemoveWinIoDriver Lib "WinIo.dll" () As Boolean
#End Region

        'Funcion que se supone k me abre el cajon portamonedas
        Public Sub OpenCajon()
            If My.MyHardware.cashlogy_sw Then Return
            If My.MyHardware.swCashDrawerCOM Then
                RawPrinterHelper.SendStringToPrinter("cajon", Chr(27) & Chr(112) & Chr(48) & Chr(50) & Chr(50))
                'If My.MyHardware.ccom_port = 0 Then Exit Sub
                'Try
                '    Dim _port As IO.Ports.SerialPort
                '    _port = New IO.Ports.SerialPort("COM" & My.MyHardware.ccom_port, 9600, IO.Ports.Parity.None, 8, IO.Ports.StopBits.One)
                '    _port.Open()
                '    _port.Write(My.MyHardware.CodEsc_Open)
                '    _port.Close()
                '    _port.Dispose()

                'Catch ex As Exception
                '    MsgBox("Apertura de cajón directo: " & ex.Message, MsgBoxStyle.Critical)
                'End Try


                Exit Sub
            End If

            If Not CBool(My.MyHardware.swCashDrawer) Then
                If My.MyHardware.IdPort = 0 Then Exit Sub

                'Apertura del cajon portamonedas a traves de impresora de tickets
                If My.MyHardware.PortName.Substring(0, 3) = "COM" Then
                    Try
                        Dim _port As IO.Ports.SerialPort
                        _port = New IO.Ports.SerialPort(My.MyHardware.PortName, 9600, IO.Ports.Parity.None, 8, IO.Ports.StopBits.One)
                        _port.Open()
                        _port.Write(My.MyHardware.CodEsc_Open)
                        _port.Close()
                        _port.Dispose()

                    Catch ex As Exception
                        MsgBox(ex.Message, MsgBoxStyle.Critical)
                    End Try
                ElseIf My.MyHardware.PortName.Substring(0, 3) = "LPT" Then
                    Dim _port As m_Crypto.ioParerellPort
                    _port = New m_Crypto.ioParerellPort("LPT" & My.MyHardware.IdPort)

                    _port.Write(My.MyHardware.CodEsc_Open)
                    _port.Dispose()
                Else
                    RawPrinterHelper.SendStringToPrinter("tickets", My.MyHardware.CodEsc_Open)
                End If
            Else
                'TENGO QUE PONER UNA OPCION PARA INICIALIZAR EL CASHDRAWER
                Try
                    'Apertura del Cash Drawer Directo
                    If Not InitializeWinIo() Then
                        'MsgBox("Imposible inicializar Winio", MsgBoxStyle.Critical)
                        Exit Sub
                    End If

                    If Not SetPortVal("&H" & My.MyHardware.CD_Port_Address, "&H" & My.MyHardware.CD_Port_Open, 2) Then
                        'MsgBox("Whoops!!! Un problema con SetPortByte.", MsgBoxStyle.Critical)
                        Exit Sub
                    End If

                    'SetPortVal("&H" + My.MyHardware.CD_Port_Address, "&H" + My.MyHardware.CD_Port_Close, 2)
                    ShutdownWinIo()

                    'Cierre del Cash Drawer Directo
                    If Not InitializeWinIo() Then
                        'MsgBox("Imposible inicializar Winio", MsgBoxStyle.Critical)
                        Exit Sub
                    End If

                    If Not SetPortVal("&H" & My.MyHardware.CD_Port_Address, "&H" & My.MyHardware.CD_Port_Close, 2) Then
                        ' MsgBox("Whoops!!! Un problema con SetPortByte.", MsgBoxStyle.Critical)
                        Exit Sub
                    End If

                    'SetPortVal("&H" + My.MyHardware.CD_Port_Address, "&H" + My.MyHardware.CD_Port_Close, 2)
                    ShutdownWinIo()
                Catch ex As Exception
                    MsgBox(ex.Message, MsgBoxStyle.Critical)
                End Try
            End If
        End Sub
#End Region

#Region "Funciones de Apoyo"
        'Fucnion que me alinea el texto
        Public Function Ticket_ConfigTextAling(ByVal StrText As String, Optional ByVal aling As HorizontalAlignment = HorizontalAlignment.Left, Optional ByVal SwSizeGrande As Boolean = False) As String
            Dim StrAux As String = StrText
            If StrAux.Length > My.MyHardware.Ancho Then StrAux = StrAux.Substring(1, My.MyHardware.Ancho)
            Dim n As Integer = 0
            Select Case aling
                Case HorizontalAlignment.Left

                Case HorizontalAlignment.Center
                    n = (My.MyHardware.Ancho - StrAux.Length - IIf(SwSizeGrande, StrAux.Length / 2, 0)) / 2
                    If n < 0 Then n = 0
                    StrAux = Space(n) & StrAux
                    If StrAux.Length > My.MyHardware.Ancho Then StrAux = StrAux.Substring(1, My.MyHardware.Ancho)
                Case HorizontalAlignment.Right
            End Select
            Return StrAux
        End Function

        'Funcion que me compone el color del texto    
        Public Function Ticket_ConfigTextSize(ByVal StrText As String, Optional ByVal SwSizeGrande As Boolean = False) As String
            Dim StrAux As String = StrText
            If SwSizeGrande Then
                StrAux = My.MyHardware.CodEsc_TextGrande & StrAux
            Else
                StrAux = My.MyHardware.CodEsc_TextNormal & StrAux
            End If
            Return StrAux
        End Function

        'Funcion que me compone el color del texto    
        Public Function Ticket_ConfigTextColor(ByVal StrText As String, Optional ByVal SwColorRed As Boolean = False) As String
            Dim StrAux As String = StrText
            If SwColorRed Then
                StrAux = My.MyHardware.CodEsc_Rojo & StrAux
            Else
                StrAux = My.MyHardware.CodEsc_Negro & StrAux
            End If
            Return StrAux
        End Function

        'Funcion que me pone en negrita el texto
        Public Function Ticket_ConfigTextStrong(ByVal StrText As String, Optional ByVal SwStrong As Boolean = False) As String
            Dim StrAux As String = StrText
            'If StrAux.Length > ANCHO Then StrAux = StrAux.Substring(1, ANCHO)
            If SwStrong Then
                StrAux = My.MyHardware.CodEsc_Negrita_True & StrAux
            Else
                StrAux = My.MyHardware.CodEsc_Negrita_False & StrAux
            End If
            Return StrAux
        End Function
#End Region

#End Region

        Public Class RawPrinterHelper
            ' Structure and API declarions:
            <StructLayout(LayoutKind.Sequential, CharSet:=CharSet.Unicode)> _
            Structure DOCINFOW
                <MarshalAs(UnmanagedType.LPWStr)> Public pDocName As String
                <MarshalAs(UnmanagedType.LPWStr)> Public pOutputFile As String
                <MarshalAs(UnmanagedType.LPWStr)> Public pDataType As String
            End Structure

            <DllImport("winspool.Drv", EntryPoint:="OpenPrinterW", _
               SetLastError:=True, CharSet:=CharSet.Unicode, _
               ExactSpelling:=True, CallingConvention:=CallingConvention.StdCall)> _
            Public Shared Function OpenPrinter(ByVal src As String, ByRef hPrinter As IntPtr, ByVal pd As Long) As Boolean
            End Function
            <DllImport("winspool.Drv", EntryPoint:="ClosePrinter", _
               SetLastError:=True, CharSet:=CharSet.Unicode, _
               ExactSpelling:=True, CallingConvention:=CallingConvention.StdCall)> _
            Public Shared Function ClosePrinter(ByVal hPrinter As IntPtr) As Boolean
            End Function
            <DllImport("winspool.Drv", EntryPoint:="StartDocPrinterW", _
               SetLastError:=True, CharSet:=CharSet.Unicode, _
               ExactSpelling:=True, CallingConvention:=CallingConvention.StdCall)> _
            Public Shared Function StartDocPrinter(ByVal hPrinter As IntPtr, ByVal level As Int32, ByRef pDI As DOCINFOW) As Boolean
            End Function
            <DllImport("winspool.Drv", EntryPoint:="EndDocPrinter", _
               SetLastError:=True, CharSet:=CharSet.Unicode, _
               ExactSpelling:=True, CallingConvention:=CallingConvention.StdCall)> _
            Public Shared Function EndDocPrinter(ByVal hPrinter As IntPtr) As Boolean
            End Function
            <DllImport("winspool.Drv", EntryPoint:="StartPagePrinter", _
               SetLastError:=True, CharSet:=CharSet.Unicode, _
               ExactSpelling:=True, CallingConvention:=CallingConvention.StdCall)> _
            Public Shared Function StartPagePrinter(ByVal hPrinter As IntPtr) As Boolean
            End Function
            <DllImport("winspool.Drv", EntryPoint:="EndPagePrinter", _
               SetLastError:=True, CharSet:=CharSet.Unicode, _
               ExactSpelling:=True, CallingConvention:=CallingConvention.StdCall)> _
            Public Shared Function EndPagePrinter(ByVal hPrinter As IntPtr) As Boolean
            End Function
            <DllImport("winspool.Drv", EntryPoint:="WritePrinter", _
               SetLastError:=True, CharSet:=CharSet.Unicode, _
               ExactSpelling:=True, CallingConvention:=CallingConvention.StdCall)> _
            Public Shared Function WritePrinter(ByVal hPrinter As IntPtr, ByVal pBytes As IntPtr, ByVal dwCount As Int32, ByRef dwWritten As Int32) As Boolean
            End Function

            ' SendBytesToPrinter()
            ' When the function is given a printer name and an unmanaged array of  
            ' bytes, the function sends those bytes to the print queue.
            ' Returns True on success or False on failure.
            Public Shared Function SendBytesToPrinter(ByVal szPrinterName As String, ByVal pBytes As IntPtr, ByVal dwCount As Int32) As Boolean
                Dim hPrinter As IntPtr      ' The printer handle.
                Dim dwError As Int32        ' Last error - in case there was trouble.
                Dim di As DOCINFOW          ' Describes your document (name, port, data type).
                Dim dwWritten As Int32      ' The number of bytes written by WritePrinter().
                Dim bSuccess As Boolean     ' Your success code.

                ' Set up the DOCINFO structure.
                With di
                    .pDocName = "My Visual Basic .NET RAW Document"
                    .pDataType = "RAW"
                End With
                ' Assume failure unless you specifically succeed.
                bSuccess = False
                If OpenPrinter(szPrinterName, hPrinter, 0) Then
                    If StartDocPrinter(hPrinter, 1, di) Then
                        If StartPagePrinter(hPrinter) Then
                            ' Write your printer-specific bytes to the printer.
                            bSuccess = WritePrinter(hPrinter, pBytes, dwCount, dwWritten)
                            EndPagePrinter(hPrinter)
                        End If
                        EndDocPrinter(hPrinter)
                    End If
                    ClosePrinter(hPrinter)
                End If
                ' If you did not succeed, GetLastError may give more information
                ' about why not.
                If bSuccess = False Then
                    dwError = Marshal.GetLastWin32Error()
                End If
                Return bSuccess
            End Function ' SendBytesToPrinter()

            ' SendFileToPrinter()
            ' When the function is given a file name and a printer name, 
            ' the function reads the contents of the file and sends the
            ' contents to the printer.
            ' Presumes that the file contains printer-ready data.
            ' Shows how to use the SendBytesToPrinter function.
            ' Returns True on success or False on failure.
            Public Shared Function SendFileToPrinter(ByVal szPrinterName As String, ByVal szFileName As String) As Boolean
                ' Open the file.
                Dim fs As New IO.FileStream(szFileName, IO.FileMode.Open)
                ' Create a BinaryReader on the file.
                Dim br As New IO.BinaryReader(fs)
                ' Dim an array of bytes large enough to hold the file's contents.
                Dim bytes(fs.Length) As Byte
                Dim bSuccess As Boolean
                ' Your unmanaged pointer.
                Dim pUnmanagedBytes As IntPtr

                ' Read the contents of the file into the array.
                bytes = br.ReadBytes(fs.Length)
                ' Allocate some unmanaged memory for those bytes.
                pUnmanagedBytes = Marshal.AllocCoTaskMem(fs.Length)
                ' Copy the managed byte array into the unmanaged array.
                Marshal.Copy(bytes, 0, pUnmanagedBytes, fs.Length)
                ' Send the unmanaged bytes to the printer.
                bSuccess = SendBytesToPrinter(szPrinterName, pUnmanagedBytes, fs.Length)
                ' Free the unmanaged memory that you allocated earlier.
                Marshal.FreeCoTaskMem(pUnmanagedBytes)
                Return bSuccess
            End Function ' SendFileToPrinter()

            ' When the function is given a string and a printer name,
            ' the function sends the string to the printer as raw bytes.
            Public Shared Function SendStringToPrinter(ByVal szPrinterName As String, ByVal szString As String)
                Dim pBytes As IntPtr
                Dim dwCount As Int32
                ' How many characters are in the string?
                dwCount = szString.Length()
                ' Assume that the printer is expecting ANSI text, and then convert
                ' the string to ANSI text.
                pBytes = Marshal.StringToCoTaskMemAnsi(szString)
                ' Send the converted ANSI string to the printer.
                SendBytesToPrinter(szPrinterName, pBytes, dwCount)
                Marshal.FreeCoTaskMem(pBytes)
            End Function


        End Class


#Region "Impresion Alternativa"
        Private Sub PrintTest()
            'dim print as Microsoft.p
        End Sub
#End Region



        'Public Function CerrarCaja(ByVal id As Integer, ByVal strName As String, ByVal fhCierre As Date) As Integer


        '    'Creo una nueva Caja
        '    Dim rst As ADODB.Recordset = My.m_db.GetRst("SELECT * FROM db_cajas WHERE id=" & id)
        '    If id <> -1 Then rst.AddNew()


        '    rst("id_contable").Value = My.m_app.GetValue("id_contable")
        '    rst("name").Value = Me.TxtName.Text
        '    rst("ncaja").Value = My.Get_Contador("CAJA")
        '    rst("fh_alta").Value = Me.fhCierre.Value.ToString("dd/MM/yyyy")
        '    rst("n_tickets").Value = Me.LblNTickets.Text
        '    rst("total").Value = CDbl(Me.TxtTotal.Text)           'El total ajustad
        '    rst("total_real").Value = CDbl(Me.LblTotalReal.Text)           'El total ajustado
        '    rst("total_banco").Value = CDbl(Me.lblTotalBanco.Text)           'El total del banco


        '    'Ajusto los importes desglosados
        '    rst("general_base").Value = CDbl(Me.LblPvp_Base_General.Text)
        '    rst("medio_base").Value = CDbl(Me.LblPvp_Base_Medio.Text)
        '    rst("basico_base").Value = CDbl(Me.LblPvp_Base_Basico.Text)

        '    rst("general_iva").Value = CDbl(Me.LblPvp_Iva_General.Text)
        '    rst("medio_iva").Value = CDbl(Me.LblPvp_Iva_Medio.Text)
        '    rst("basico_iva").Value = CDbl(Me.LblPvp_Iva_Basico.Text)

        '    rst("general_total").Value = CDbl(Me.LblPvp_Total_General.Text)
        '    rst("medio_total").Value = CDbl(Me.LblPvp_Total_Medio.Text)
        '    rst("basico_total").Value = CDbl(Me.LblPvp_Total_Basico.Text)

        '    rst.Update()

        '    CerrarCaja = rst("id").Value
        '    My.m_db.CloseRst(rst)

        '    Return CerrarCaja
        'End Function





    End Module

    
End Namespace