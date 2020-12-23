Public Class frmWizard_Configure
    Private m_DataBase As gDevelop.Lite.m_database

    Private m_Data_Empresa As gDevelop.Lite.m_dataform
    Private m_Data_Ticket As gDevelop.Lite.m_dataform
    Private m_Data_Facturacion As gDevelop.Lite.m_dataform
    Private m_Data_Options As gDevelop.Lite.m_dataform

    Private m_Data_Distribuidor As gDevelop.Lite.m_dataform


    'Indice de la imagen de los estados del check box
    Private Const state_ball_green = 7
    Private Const state_ball_red = 8

    Private swServer As Boolean = True            ' Valor predeterminado para establecer el tipo de conexion que se va a usar

#Region "Funciones"
    Private Function ConfigureLocalDb() As Boolean
        Dim sql As String = ""
        Dim id As Integer = -1

        '####### Dependiendo del tipo de Conexión: Access o MySQL
        If Me.RbtConexion_Access.Checked Then
            'Conexion atraves de base de datos Access
            Me.m_DataBase = New gDevelop.Lite.m_database(gDevelop.Lite.m_EnumTypes.DatabaseConnection.Access)

            If Me.RbtServer.Checked Then
                Me.m_DataBase.Database_SourceHost = Me.LblLocalMdb.Text
            Else
                Me.m_DataBase.Database_SourceHost = Me.LblNetworkMdb.Text
            End If

            Me.m_DataBase.Database_Name = My.APP_DATABASE

        Else
            Me.m_DataBase = New gDevelop.Lite.m_database(gDevelop.Lite.m_EnumTypes.DatabaseConnection.MySQL)
            Me.m_DataBase.Database_SourceHost = Me.TxtMySQLHost.Text
            Me.m_DataBase.Database_Name = My.APP_DATABASE
            Me.m_DataBase.Database_User = Me.TxtMySQLUser.Text
            Me.m_DataBase.Database_Pass = Me.TxtMySQLPass.Text
        End If

        'Trato de conectar con la Base de Datos
        If Not Me.m_DataBase.Connect() Then
            My.m_msg.MessageError(Me, "Imposible conectar con la Base de Datos")
            Return False
        End If

        '####### Cargo el nº total de empresas
        Dim rst As ADODB.Recordset = Me.m_DataBase.GetRst("SELECT id,name_comercial FROM app_empresa ORDER BY id ASC")
        If rst.RecordCount = 0 Then
            'Si no hay empresa creada, la creo
            sql = "INSERT INTO app_empresa (id,name_comercial,name_fiscal,maestra,fh_alta)"
            sql &= " VALUES (1,'NOMBRE DE LA EMPRESA','NOMBRE FISCAL DE LA EMPRESA',1,'" & Format(Now, "yyyy-MM-dd HH:mm") & "')"

            Me.m_DataBase.Execute(sql)
            rst.Requery()
        End If
        Me.CbEmpresas.Items.Clear()
        While Not rst.EOF
            Me.CbEmpresas.Items.Add(rst("name_comercial").Value & Space(150) & rst("id").Value)
            rst.MoveNext()
        End While
        Me.CbEmpresas.Enabled = (rst.RecordCount > 1)
        Me.CbEmpresas.SelectedIndex = 0
        Me.m_DataBase.CloseRst(rst)

        Return True
    End Function

    'Cargo todos la información relativa a la empresa
    Private Sub CbEmpresas_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CbEmpresas.SelectedIndexChanged
        Dim sql As String = "", rst As ADODB.Recordset
        Dim id_empresa As Integer = -1, id_aux As Integer = -1, id_distribuidor As Integer = -1

        '####### Cargo la configuración de la EMPRESA
        id_empresa = My.m_app.GetValue("id_empresa", Me.CbEmpresas.Text.Substring(150).Trim)
        id_distribuidor = 1              'El distribuidor es identico para todos

        If IsNothing(Me.m_Data_Empresa) Then
            Me.m_Data_Empresa = New gDevelop.Lite.m_dataform(Me.m_DataBase)
            Me.m_Data_Empresa.DbTable = "app_empresa"
            Me.m_Data_Empresa.ConfigureDataForm(Me.Group_Empresa.Controls)
        End If

        Me.m_Data_Empresa.data_EditField(id_empresa)

        'Habilito los groups para poderlos modificar si por defecto si no tiene establecida contraseña
        Me.Group_Empresa.Enabled = (Me.TxtEmpresa_Pass.TextLength = 0)
        Me.Group_Ticket.Enabled = Me.Group_Empresa.Enabled
        Me.Group_Facturacion.Enabled = Me.Group_Empresa.Enabled
        Me.Group_Options.Enabled = Me.Group_Empresa.Enabled
        Me.PnlEmpresa_Security.Visible = (Me.TxtEmpresa_Pass.TextLength > 0)


        Me.BtSelectImg_Empresa.Image = Me.PicImg_empresa.Image
        If Not IsNothing(Me.BtSelectImg_Empresa.Image) Then Me.BtSelectImg_Empresa.Text = ""



        '####### Cargo la configuración del TICKET
        ' Compruebo si la empresa tiene un ticket relacionado
        rst = Me.m_DataBase.GetRst("SELECT id FROM app_ticket WHERE id_empresa=" & id_empresa)
        If rst.RecordCount = 0 Then
            'Si no hay empresa creada, la creo
            sql = "INSERT INTO app_ticket (id_empresa,ticket_cab_1,ticket_cab_5,ticket_center_1,ticket_center_5,ticket_strong_1,ticket_Print_TotalRed,ticket_Print_IVA,fh_alta)"
            sql &= " VALUES (" & id_empresa & ",'NOMBRE DE LA EMPRESA','Gracias por su visita',1,1,1,1,1,'" & Format(Now, "yyyy-MM-dd HH:mm") & "')"

            Me.m_DataBase.Execute(sql)
            rst.Requery()
        End If
        id_aux = rst("id").Value
        Me.m_DataBase.CloseRst(rst)

        ' Configuro el formulario
        If IsNothing(Me.m_Data_Ticket) Then
            Me.m_Data_Ticket = New gDevelop.Lite.m_dataform(Me.m_DataBase)
            Me.m_Data_Ticket.DbTable = "app_ticket"
            Me.m_Data_Ticket.ConfigureDataForm(Me.Group_Ticket.Controls)
        End If

        Me.m_Data_Ticket.data_EditField(id_aux)



        '####### Cargo la configuración de la FACTURACION
        ' Compruebo si la empresa tiene un periodo contable relacionado
        rst = Me.m_DataBase.GetRst("SELECT id FROM app_contabilidad WHERE id_empresa=" & id_empresa)
        If rst.RecordCount = 0 Then
            'Si no hay empresa creada, la creo
            sql = "INSERT INTO app_contabilidad (id_empresa,name,fact_contador,ticket_contador,year_contable,factb_contador,factc_contador,iva_general,iva_medio,iva_basico,recargo_general,recargo_medio,recargo_basico,fh_alta,caja_serie,caja_contador)"
            sql &= " VALUES (" & id_empresa & ",'PERIODO INICIAL',1,1," & Now.Year & ",1,1,21,10,4,4,1,0,'" & Format(Now, "yyyy-MM-dd HH:mm") & "','',1)"

            Me.m_DataBase.Execute(sql)
            rst.Requery()
        End If
        id_aux = rst("id").Value
        Me.m_DataBase.CloseRst(rst)

        ' Configuro el formulario
        If IsNothing(Me.m_Data_Facturacion) Then
            Me.m_Data_Facturacion = New gDevelop.Lite.m_dataform(Me.m_DataBase)
            Me.m_Data_Facturacion.DbTable = "app_contabilidad"
            Me.m_Data_Facturacion.ConfigureDataForm(Me.Group_Facturacion.Controls)
        End If

        Me.m_Data_Facturacion.data_EditField(id_aux)

        'Establezco el id del periodo contable por defecto
        My.m_app.SetValue("id_contable") = id_aux


        '####### Cargo la configuración de las OPCIONES
        ' Compruebo si la empresa tiene el registro de opciones relacionado
        rst = Me.m_DataBase.GetRst("SELECT id FROM app_options WHERE id_empresa=" & id_empresa)
        If rst.RecordCount = 0 Then
            'Si no hay empresa creada, la creo
            sql = "INSERT INTO app_options (id_empresa,n_limit_registros,fh_alta)"
            sql &= " VALUES (" & id_empresa & ",100,'" & Format(Now, "yyyy-MM-dd HH:mm") & "')"

            Me.m_DataBase.Execute(sql)
            rst.Requery()
        End If
        id_aux = rst("id").Value
        Me.m_DataBase.CloseRst(rst)

        ' Configuro el formulario
        If IsNothing(Me.m_Data_Options) Then
            Me.m_Data_Options = New gDevelop.Lite.m_dataform(Me.m_DataBase)
            Me.m_Data_Options.DbTable = "app_options"
            Me.m_Data_Options.ConfigureDataForm(Me.Group_Options.Controls)
        End If

        Me.m_Data_Options.data_EditField(id_aux)


        '####### Cargo la configuración del DISTRIBUIDOR
        rst = Me.m_DataBase.GetRst("SELECT id FROM app_distribuidor WHERE id=" & id_distribuidor)
        If rst.RecordCount = 0 Then
            'Si no hay empresa creada, la creo
            sql = "INSERT INTO app_distribuidor (id,name_comercial,fh_alta)"
            sql &= " VALUES (" & id_distribuidor & ",'NOMBRE DE QUIEN DISTRIBUYE','" & Format(Now, "yyyy-MM-dd HH:mm") & "')"

            Me.m_DataBase.Execute(sql)
            rst.Requery()
        End If
        id_aux = rst("id").Value
        Me.m_DataBase.CloseRst(rst)

        ' Configuro el formulario
        If IsNothing(Me.m_Data_Distribuidor) Then
            Me.m_Data_Distribuidor = New gDevelop.Lite.m_dataform(Me.m_DataBase)
            Me.m_Data_Distribuidor.DbTable = "app_distribuidor"
            Me.m_Data_Distribuidor.ConfigureDataForm(Me.Group_Distribuidor.Controls)
        End If

        Me.m_Data_Distribuidor.data_EditField(id_aux)

        Me.Group_Distribuidor.Enabled = (Me.TxtDistribuidor_Pass.TextLength = 0)
        Me.PnlDistribuidor_Pass.Visible = (Me.TxtDistribuidor_Pass.TextLength > 0)

        Me.BtSelectImg_Distribuidor.Image = Me.PicImg_Distribuidor.Image
        If Not IsNothing(Me.BtSelectImg_Distribuidor.Image) Then Me.BtSelectImg_Distribuidor.Text = ""

    End Sub
#End Region

#Region "Manejadores"
    'Manejador Principal (Shell) 
    Private Sub ShellApp(ByVal app_form As String, Optional ByVal action As String = "")
        Dim app As String = app_form.ToUpper

        ' Inicializo el estado de los botones
        Me.BtPrevious.Enabled = True
        Me.BtNext.Enabled = True
        Me.BtMain.Enabled = True

        Select Case app
            Case "END"
                ' Guardo los valores de configuración
                If Me.Group_Empresa.Enabled Then         'Si puedo editarlo, puedo guardar 
                    Me.m_Data_Empresa.data_SaveField()
                    Me.m_Data_Ticket.data_SaveField()
                    Me.m_Data_Facturacion.data_SaveField()
                    Me.m_Data_Options.data_SaveField()
                End If

                If Me.Group_Distribuidor.Enabled Then Me.m_Data_Distribuidor.data_SaveField()

                'Guardo los valores de configuracion
                My.m_app.SetValue("local_mdb") = Me.LblLocalMdb.Text
                My.m_app.SetValue("network_mdb") = Me.LblNetworkMdb.Text

                My.m_app.SetValue("host_mysql") = Me.TxtMySQLHost.Text
                My.m_app.SetValue("port_mysql") = Me.TxtMySQLPort.Text
                My.m_app.SetValue("user_mysql") = Me.TxtMySQLUser.Text
                My.m_app.SetValue("pass_mysql") = Me.TxtMySQLPass.Text

                My.m_app.SetValue("id_empresa") = Me.CbEmpresas.Text.Substring(150).Trim

                My.m_app.SetValue("tipo_db") = IIf(Me.RbtConexion_Access.Checked, 0, 1)
                My.m_app.SetValue("modo_db") = IIf(Me.RbtServer.Checked, 0, 1)

                Me.DialogResult = Windows.Forms.DialogResult.OK
            Case "NEXT"
                ' Caso del SIGUIENTE: Agrego el tab si no exite
                Select Case True
                    Case Me.Tab.SelectedTab Is Me.TabPage_Main
                        If Not Me.Tab.TabPages.Contains(Me.TabPage_Conexion) Then Me.Tab.TabPages.Add(Me.TabPage_Conexion)
                        Me.Tab.SelectedTab = Me.TabPage_Conexion

                    Case Me.Tab.SelectedTab Is Me.TabPage_Conexion
                        ' Elimino todos los tabs siguientes
                        'Dim i As Integer
                        'For i = Me.Tab.TabPages.Count - 1 To 2 Step -1
                        '    Me.Tab.TabPages.Remove(Me.Tab.TabPages(i))
                        'Next

                        If Me.RbtCliente.Checked Then
                            Me.swServer = False

                            ' Configuro las opciones locales y conecto con la base de datos del servidor
                        End If

                        ' Al escoger metodo de conexion, configuro la base de datos
                        If Not Me.ConfigureLocalDb() Then Exit Sub

                        'Una vez configurada la conexion impido que se puedan modificar los datos
                        Me.GroupConexion.Enabled = False

                        If Not Me.Tab.TabPages.Contains(Me.TabPage_Empresa) Then Me.Tab.TabPages.Add(Me.TabPage_Empresa)

                        Me.Tab.SelectedTab = Me.TabPage_Empresa


                    Case Me.Tab.SelectedTab Is Me.TabPage_Empresa
                        If Not Me.Tab.TabPages.Contains(Me.TabPage_Ticket) Then Me.Tab.TabPages.Add(Me.TabPage_Ticket)
                        Me.Tab.SelectedTab = Me.TabPage_Ticket

                    Case Me.Tab.SelectedTab Is Me.TabPage_Ticket
                        If Not Me.Tab.TabPages.Contains(Me.TabPage_Facturacion) Then Me.Tab.TabPages.Add(Me.TabPage_Facturacion)
                        Me.Tab.SelectedTab = Me.TabPage_Facturacion

                    Case Me.Tab.SelectedTab Is Me.TabPage_Facturacion
                        If Not Me.Tab.TabPages.Contains(Me.TabPage_Opciones) Then Me.Tab.TabPages.Add(Me.TabPage_Opciones)
                        Me.Tab.SelectedTab = Me.TabPage_Opciones

                    Case Me.Tab.SelectedTab Is Me.TabPage_Opciones
                        If Not Me.Tab.TabPages.Contains(Me.TabPage_Distribuidor) Then Me.Tab.TabPages.Add(Me.TabPage_Distribuidor)
                        Me.Tab.SelectedTab = Me.TabPage_Distribuidor

                    Case Me.Tab.SelectedTab Is Me.TabPage_Distribuidor
                        If Not Me.Tab.TabPages.Contains(Me.TabPage_Register) Then Me.Tab.TabPages.Add(Me.TabPage_Register)
                        Me.Tab.SelectedTab = Me.TabPage_Register

                    Case Me.Tab.SelectedTab Is Me.TabPage_Register
                        If Not Me.Tab.TabPages.Contains(Me.TabPage_Finish) Then Me.Tab.TabPages.Add(Me.TabPage_Finish)
                        Me.Tab.SelectedTab = Me.TabPage_Finish
                End Select

            Case "PREVIOUS"
                ' Caso del ANTERIOR, selecciono el tab anteriro
                Select Case True
                    Case Me.Tab.SelectedTab Is Me.TabPage_Conexion
                        Me.Tab.SelectedTab = Me.TabPage_Main

                    Case Me.Tab.SelectedTab Is Me.TabPage_Empresa
                        Me.Tab.SelectedTab = Me.TabPage_Conexion

                        'Case Me.Tab.SelectedTab Is Me.TabPage_Facturacion
                        '    Me.Tab.SelectedTab = Me.TabPage_Empresa

                    Case Me.Tab.SelectedTab Is Me.TabPage_Ticket
                        Me.Tab.SelectedTab = Me.TabPage_Empresa

                    Case Me.Tab.SelectedTab Is Me.TabPage_Facturacion
                        Me.Tab.SelectedTab = Me.TabPage_Ticket

                    Case Me.Tab.SelectedTab Is Me.TabPage_Opciones
                        Me.Tab.SelectedTab = Me.TabPage_Facturacion

                    Case Me.Tab.SelectedTab Is Me.TabPage_Distribuidor
                        Me.Tab.SelectedTab = Me.TabPage_Opciones

                    Case Me.Tab.SelectedTab Is Me.TabPage_Register
                        Me.Tab.SelectedTab = Me.TabPage_Distribuidor

                    Case Me.Tab.SelectedTab Is Me.TabPage_Finish
                        Me.Tab.SelectedTab = Me.TabPage_Register

                End Select

            Case "MAIN"
                Me.Tab.SelectedTab = Me.TabPage_Main

            Case Else

                Select Case True
                    Case Me.Tab.SelectedTab Is Me.TabPage_Main
                        Me.BtPrevious.Enabled = False
                        Me.BtMain.Enabled = False
                        Me.BtEnd.Enabled = False

                    Case Me.Tab.SelectedTab Is Me.TabPage_Finish
                        Me.BtNext.Enabled = False
                        Me.BtEnd.Enabled = True
                End Select
        End Select
    End Sub

#End Region

#Region "Eventos Principales"
    Private Sub frmWizard_Configure_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim str As String = """" & My.APP_NAME & """"
        Me.Text &= " " & str

        Me.LblTitle_Main.Text &= str

        ' Oculto todas las paginas del tab
        Dim i As Integer
        For i = Me.Tab.TabPages.Count - 1 To 1 Step -1
            Me.Tab.TabPages.Remove(Me.Tab.TabPages(i))
        Next


        'Dim sql As String = ""
        Dim idAux As Integer = -1

        '####### Cargo valores pre-establecidos
        Me.LblLocalMdb.Text = My.m_app.GetValue("local_mdb", My.Application.app_Path)
        'Me.LblLocalMdb.Text = My.m_app.GetValue("local_mdb", My.Application.Info.DirectoryPath & "\")
        Me.LblNetworkMdb.Text = My.m_app.GetValue("network_mdb")

        Me.TxtMySQLHost.Text = My.m_app.GetValue("host_mysql", "localhost")
        Me.TxtMySQLPort.Text = My.m_app.GetValue("port_mysql", "3306")
        Me.TxtMySQLUser.Text = My.m_app.GetValue("user_mysql", "")
        Me.TxtMySQLPass.Text = My.m_app.GetValue("pass_mysql", "")


        '####### Cargo la configuración de CONEXION
        idAux = My.m_app.GetValue("tipo_db", 0)

        Select Case idAux             ' Dependiendo del Tipo de base de datos
            Case gDevelop.Lite.m_EnumTypes.DatabaseConnection.Access
                ' Tipo de conexión Access
                Me.RbtConexion_Access.Checked = True

                idAux = My.m_app.GetValue("modo_db", gDevelop.Lite.m_EnumTypes.DatabaseModeConnection.servidor)
                Select Case idAux           ' Dependiendo del modo de conexion: Cliente-Servidor
                    Case gDevelop.Lite.m_EnumTypes.DatabaseModeConnection.servidor
                        Me.RbtServer.Checked = True

                        Me.BtNext.Enabled = (IO.File.Exists(Me.LblLocalMdb.Text & "\" & My.APP_DATABASE & ".mdb"))

                    Case gDevelop.Lite.m_EnumTypes.DatabaseModeConnection.cliente
                        Me.RbtCliente.Checked = True

                        Me.BtNext.Enabled = (IO.File.Exists(Me.LblNetworkMdb.Text & "/" & My.APP_DATABASE & ".mdb"))

                End Select

            Case gDevelop.Lite.m_EnumTypes.DatabaseConnection.MySQL
                ' Tipo de conexión MySQL
                Me.RbtConexion_MySQL.Checked = True
                Me.BtNext.Enabled = False
        End Select


        Me.TxtLock.Text = My.m_app.GetAppcode
        Me.LblInfo_1.Text &= """" & My.APP_NAME & """"

        Me.AddHandlers()

        Me.BtNext.Enabled = ChkOkLicencia.Checked
    End Sub
#End Region

#Region "Eventos Auxiliares"
    'Limpio y cierro
    Private Sub frmWizard_Configure_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If Not IsNothing(Me.m_Data_Empresa) Then
            Me.m_Data_Empresa.Dispose()
            Me.m_Data_Empresa = Nothing
        End If

        If Not IsNothing(Me.m_Data_Ticket) Then
            Me.m_Data_Ticket.Dispose()
            Me.m_Data_Ticket = Nothing
        End If

        If Not IsNothing(Me.m_Data_Facturacion) Then
            Me.m_Data_Facturacion.Dispose()
            Me.m_Data_Facturacion = Nothing
        End If

        If Not IsNothing(Me.m_Data_Options) Then
            Me.m_Data_Options.Dispose()
            Me.m_Data_Options = Nothing
        End If


        If Not IsNothing(Me.m_Data_Distribuidor) Then
            Me.m_Data_Distribuidor.Dispose()
            Me.m_Data_Distribuidor = Nothing
        End If

        If Not IsNothing(Me.m_DataBase) Then
            Me.m_DataBase.Dispose()
            Me.m_DataBase = Nothing
        End If
    End Sub

    Private Sub Buttons_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtPrevious.Click, BtNext.Click, BtMain.Click, BtEnd.Click
        'Si no tiene establecido el tag mando un error
        If IsNothing(CType(sender, Button).Tag) OrElse CType(sender, Button).Tag.ToString.Length = 0 Then
            My.m_msg.MessageError(sender, "Tag de control de elemento no referenciado")
            Exit Sub
        End If

        ShellApp(CType(sender, Button).Tag.ToString)
    End Sub

    Private Sub ChkEmpresaPass_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChkEmpresaPass.CheckedChanged
        Me.TxtEmpresa_Pass.PasswordChar = IIf(Me.ChkEmpresaPass.Checked, "", "*")
    End Sub

    Private Sub frmWizard_Configure_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        Me.PnlData.Visible = True
    End Sub

    Private Sub CheckBox_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBox1.CheckedChanged, CheckBox8.CheckedChanged, CheckBox7.CheckedChanged, CheckBox6.CheckedChanged, CheckBox4.CheckedChanged, CheckBox32.CheckedChanged, CheckBox31.CheckedChanged, CheckBox30.CheckedChanged, CheckBox28.CheckedChanged, CheckBox27.CheckedChanged, CheckBox26.CheckedChanged, CheckBox24.CheckedChanged, CheckBox23.CheckedChanged, CheckBox22.CheckedChanged, CheckBox20.CheckedChanged, CheckBox2.CheckedChanged, CheckBox19.CheckedChanged, CheckBox18.CheckedChanged, CheckBox16.CheckedChanged, CheckBox15.CheckedChanged, CheckBox14.CheckedChanged, CheckBox12.CheckedChanged, CheckBox11.CheckedChanged, CheckBox10.CheckedChanged, RbtShowInfo_Distribuidor.CheckedChanged, CheckBox9.CheckedChanged, CheckBox5.CheckedChanged, CheckBox3.CheckedChanged, CheckBox29.CheckedChanged, CheckBox25.CheckedChanged, CheckBox21.CheckedChanged, CheckBox17.CheckedChanged, CheckBox13.CheckedChanged
        CType(sender, CheckBox).ImageIndex = IIf(CType(sender, CheckBox).Checked, state_ball_green, state_ball_red)

    End Sub

    Private Sub TxtFacturacion_SerieF_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtFacturacion_SerieF.GotFocus
        Me.LblSerie_Facturas.Visible = True
    End Sub

    Private Sub TxtFacturacion_SerieF_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtFacturacion_SerieF.LostFocus
        Me.LblSerie_Facturas.Visible = False
    End Sub

    Private Sub TxtFacturacion_SerieT_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtFacturacion_SerieT.GotFocus
        Me.LblSerieTicket.Visible = True
    End Sub

    Private Sub TxtFacturacion_SerieT_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtFacturacion_SerieT.LostFocus
        Me.LblSerieTicket.Visible = False
    End Sub

    Private Sub Tab_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Tab.SelectedIndexChanged
        Me.ShellApp("UNKNOW")

        Select Case True
            Case Me.Tab.SelectedTab Is Me.TabPage_Empresa
                Me.TxtName_Comercial.Select()


            Case Me.Tab.SelectedTab Is Me.TabPage_Ticket
                Me.TxtTicket_Cab1.Select()
        End Select
    End Sub

    Private Sub RbtMDB_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RbtServer.CheckedChanged, RbtCliente.CheckedChanged
        CType(sender, RadioButton).ImageIndex = IIf(CType(sender, RadioButton).Checked, state_ball_green, state_ball_red)

        Me.LnkChange_NetworkMdb.Enabled = Me.RbtCliente.Checked
        Me.LnkChange_LocalMdb.Enabled = Me.RbtServer.Checked
    End Sub

    Private Sub ChkShowPass_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChkShowPass.CheckedChanged
        Me.TxtDistribuidor_Pass.PasswordChar = IIf(Me.ChkShowPass.Checked, "", "*")
    End Sub

    Private Sub BtUnlockDistribuidor_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtUnlockDistribuidor.Click
        If Not Me.TxtDistribuidor_Pass.Text.ToUpper = Me.TxtPassEdit.Text.ToUpper Then Exit Sub

        Me.PnlDistribuidor_Pass.Visible = False
        Me.Group_Distribuidor.Enabled = True
    End Sub

    Private Sub BtUnLockEmpresa_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtUnLockEmpresa.Click
        If Not Me.TxtEmpresa_Pass.Text.ToUpper = Me.TxtEmpresa_PassEdit.Text.ToUpper Then Exit Sub

        Me.PnlEmpresa_Security.Visible = False

        ' Permito la modificacion de los tabs
        Me.Group_Empresa.Enabled = True
        Me.Group_Ticket.Enabled = True
        Me.Group_Facturacion.Enabled = True
        Me.Group_Options.Enabled = True


    End Sub
#End Region


#Region "Selección de Imagen"
    Private Sub BtSelectImg_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtSelectImg_Empresa.Click
        'Dim myStream As IO.Stream
        Dim dlg As New OpenFileDialog()

        dlg.Filter = "Archivos de imagen jpg (*.jpg)|*.jpg"
        dlg.FilterIndex = 0
        dlg.RestoreDirectory = False



        If dlg.ShowDialog() <> Windows.Forms.DialogResult.OK Then Exit Sub

        Me.BtSelectImg_Empresa.Image = Image.FromFile(gDevelop.Lite.m_Functions.resize_image(dlg.FileName, 170))
        Me.PicImg_empresa.Image = Me.BtSelectImg_Empresa.Image

        Me.BtSelectImg_Empresa.Text = ""

    End Sub


    Private Sub BtSelectImg_Distribuidor_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtSelectImg_Distribuidor.Click
        'Dim myStream As IO.Stream
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

#Region "Pestaña de Conexion"
    Private Sub RbtConexion_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RbtConexion_Access.CheckedChanged, RbtConexion_MySQL.CheckedChanged
        Me.Group_ModeAccess.Enabled = (Me.RbtConexion_Access.Checked)
        Me.Group_ModeMyODBC.Enabled = (Me.RbtConexion_MySQL.Checked)

        CType(sender, RadioButton).ImageIndex = IIf(CType(sender, RadioButton).Checked, state_ball_green, state_ball_red)

    End Sub

    Private Sub LnkChange_LocalMdb_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LnkChange_LocalMdb.LinkClicked
        Dim fileExists As Boolean = False, StrDir As String = Me.LblLocalMdb.Text

        Dim DirDb As FolderBrowserDialog
repeat:
        DirDb = New FolderBrowserDialog
        DirDb.Description = "Seleccione la ubicacion local donde se encuenta la base de datos: '" & My.APP_DATABASE & ".mdb'"
        DirDb.ShowNewFolderButton = False
        DirDb.RootFolder = Environment.SpecialFolder.MyComputer
        DirDb.SelectedPath = StrDir
        If DirDb.ShowDialog() = Windows.Forms.DialogResult.Cancel Then Exit Sub

        Dim strAux As String = DirDb.SelectedPath
        If Not strAux.EndsWith("\") Then strAux &= "\"
        DirDb.Dispose()

        StrDir = strAux & My.APP_DATABASE & ".mdb"
        fileExists = My.Computer.FileSystem.FileExists(StrDir)

        If fileExists Then          'Guardo opciones
            Me.LblLocalMdb.Text = strAux
        Else
            If MsgBox("No se ha podido establer conexión con la base de Datos en '" & StrDir & "'." & Chr(13) & Chr(13) & "¿Desea probar de nuevo?", MsgBoxStyle.YesNo + MsgBoxStyle.Critical) = MsgBoxResult.Yes Then GoTo repeat
        End If
    End Sub

    Private Sub LnkChange_NetworkMdb_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LnkChange_NetworkMdb.LinkClicked
        Dim fileExists As Boolean = False, StrDir As String = Me.LblNetworkMdb.Text

        Dim DirDb As FolderBrowserDialog
repeat:
        DirDb = New FolderBrowserDialog
        DirDb.Description = "Seleccione la ubicacion dentro de la red local donde se encuenta la base de datos: '" & My.APP_DATABASE & ".mdb'"
        DirDb.ShowNewFolderButton = False
        'DirDb.RootFolder = CType("0x0012", System.Environment.SpecialFolder)

        Dim t As Type = DirDb.GetType()
        Dim fi As System.Reflection.FieldInfo = t.GetField("rootFolder", System.Reflection.BindingFlags.Instance Or System.Reflection.BindingFlags.NonPublic)
        fi.SetValue(DirDb, DirectCast(18, Environment.SpecialFolder))

        DirDb.SelectedPath = StrDir
        If DirDb.ShowDialog() = Windows.Forms.DialogResult.Cancel Then Exit Sub

        Dim strAux As String = DirDb.SelectedPath
        If Not strAux.EndsWith("\") Then strAux &= "\"
        DirDb.Dispose()

        StrDir = strAux & My.APP_DATABASE & ".mdb"
        fileExists = My.Computer.FileSystem.FileExists(StrDir)

        If fileExists Then          'Guardo opciones
            Me.LblNetworkMdb.Text = strAux
        Else
            If MsgBox("No se ha podido establer conexión con la base de Datos en '" & StrDir & "'." & Chr(13) & Chr(13) & "¿Desea probar de nuevo?", MsgBoxStyle.YesNo + MsgBoxStyle.Critical) = MsgBoxResult.Yes Then GoTo repeat
        End If
    End Sub

#End Region

#Region "Handlers"
    'Funcion que me agrega manejadores de los textbox
    Private Sub AddHandlers()
        AddHandler Me.TxtIVA_General.KeyPress, AddressOf gDevelop.Lite.m_OverridesEvents.TxtValidaEuro_KeyPress
        AddHandler Me.TxtIVA_Medio.KeyPress, AddressOf gDevelop.Lite.m_OverridesEvents.TxtValidaEuro_KeyPress
        AddHandler Me.TxtIVA_Basico.KeyPress, AddressOf gDevelop.Lite.m_OverridesEvents.TxtValidaEuro_KeyPress

        AddHandler Me.TxtFacturacion_Year.KeyPress, AddressOf gDevelop.Lite.m_OverridesEvents.TxtValidaNumeric_KeyPress
        'AddHandler Me.TxtOpcion_NLimit.KeyPress, AddressOf gDevelop.m_OverridesEvents.TxtValidaNumeric_KeyPress
    End Sub
#End Region

 


    Private Sub ChkOkLicencia_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChkOkLicencia.CheckedChanged
        Me.BtNext.Enabled = ChkOkLicencia.Checked
    End Sub
End Class