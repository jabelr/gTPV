Public Class frmPaneldePedidos
    Public idRef As Integer = -1                 'El id de referencia del registro
    Public idMesa As Integer = -1              'La mesa que es
    Public idUser As Integer = -1               'El id de usuario actual

    Public idPedido As Integer = -1             'El id del pedido
    Public idCliente As Integer = -1            'Que cliente hace el pedido

    Private _DblTotal As Double = 0.0

    Public swReload As Boolean = False             'Por si tengo que recargar los datos de la mesa en el formulario de Situacion
    Public swCajaDirecta As Boolean = False              'Indico si es caja directa
    Public swKill As Boolean = False                      'Para cuando he terminado el ticket
    Public swFinalizado As Boolean = False            'Si estoy editando un ticket terminado

    Public swChangeMesa As Boolean = False


    'Nº de articulos personalizados
    Public intNObs As Integer = 0

    'Para los borrados
    Private arrDelField(0) As Integer
    Private arrDelField_IdArt(0) As Integer
    Private arrDelField_Tipo(0) As Integer
    Private arrDelField_IdArtCombina(0) As Integer
    Private arrDelField_Ud(0) As Integer

    'Controlo cuando se han producido cambios en el ticket
    Private _Changes As Boolean = False
    Public Property swChange() As Boolean
        Get
            Return Me._Changes
        End Get
        Set(ByVal value As Boolean)
            Me.BtSave.Enabled = value
            If Me.swFinalizado Then Me.BtSave.Visible = False 'Si esta finalizado, no permito guardar, solo cobro
            Me._Changes = value

            'Cada vez que se produce un cambio, desactivo el modo invitación
            Me.swInvitacion = False
            Me.swEntrada_Refresco = False
            Me.swEntrada_Copa = False
        End Set
    End Property

    'Controlo cuando estoy en modo invitación
    Private _swInvitacion As Boolean = False
    Private _strTipoInvitacion As String = ""
    Public Property swInvitacion() As Boolean
        Get
            Return Me._swInvitacion
        End Get
        Set(ByVal value As Boolean)
            ''Selecciono el tipo de invitación, sino cancelo
            'If value Then
            '    frmPaneldeVentas_Invitacion.ShowDialog()
            '    If frmPaneldeVentas_Invitacion.DialogResult <> Windows.Forms.DialogResult.OK Then
            '        frmPaneldeVentas_Invitacion.Dispose()
            '        Exit Property
            '    End If
            '    Me._strTipoInvitacion = frmPaneldeVentas_Invitacion.strTipoInvitacion
            '    frmPaneldeVentas_Invitacion.Dispose()
            'Else
            '    Me._strTipoInvitacion = ""
            'End If

            'Me._swInvitacion = value
            'Me.LblInvitación.Visible = value
            'Me.BtAddInvitacion.Visible = value

            'If value Then Me.Tab.SelectedTab = Me.TabPage_Ticket

        End Set
    End Property

    'Controlo cuando estoy en modo de recoger entrada de Refresco
    Private _swEntrada_Refresco As Boolean = False
    Public Property swEntrada_Refresco() As Boolean
        Get
            Return Me._swEntrada_Refresco
        End Get
        Set(ByVal value As Boolean)
            Me._swEntrada_Refresco = value
            Me.lblEntrega_Entrada.Visible = value
            If value Then Me.Tab.SelectedTab = Me.TabPage_Ticket
        End Set
    End Property

    'Controlo cuando estoy en modo de recoger entrada de Copa
    Private _swEntrada_Copa As Boolean = False
    Public Property swEntrada_Copa() As Boolean
        Get
            Return Me._swEntrada_Copa
        End Get
        Set(ByVal value As Boolean)
            Me._swEntrada_Copa = value
            Me.lblEntrega_Entrada.Visible = value
            If value Then Me.Tab.SelectedTab = Me.TabPage_Ticket
        End Set
    End Property


    Private swPedidos As Boolean = False

#Region "Variables Constantes"
    '# Contantes comunes sobre el formulario

    Dim _x As Integer = 5
    Dim _y As Integer = 4

    'Localizacion de inicio para el primer boton
    Dim _left As Integer = 1
    Dim _top As Integer = 3
#End Region

#Region "Manejadores"
    'Manejador Principal (Shell)
    Private Sub ShellApp(ByVal app_form As String, Optional ByVal action As String = "")
        Dim app As String = app_form.ToUpper
        ''Antes de iniciar cualquier opcion compruebo si la demo es valida (fix change fh)

        Select Case app
            Case "TRASPASAR"
                frmPaneldeSituacion_Select.idRef = Me.idMesa
                frmPaneldeSituacion_Select.ShowDialog()
                If frmPaneldeSituacion_Select.DialogResult <> Windows.Forms.DialogResult.OK Then
                    frmPaneldeSituacion_Select.Dispose()
                    Exit Sub
                End If

                Me.idMesa = frmPaneldeSituacion_Select.idNew
                'Me.LblMesa.Text = "NUEVA UBICACIÓN"
                Me.swChangeMesa = True
                Me.swChange = True


                frmPaneldeSituacion_Select.Dispose()

            Case "INVITA_ALL"
                'If MsgBox("¿Esta seguro de que desea dar todas las consumiciones por invitadas.?", MsgBoxStyle.OkCancel + MsgBoxStyle.Question, "Invitación") <> MsgBoxResult.Ok Then Exit Sub
                ''Selecciono el tipo de invitación
                'frmPaneldeVentas_Invitacion.ShowDialog()
                'If frmPaneldeVentas_Invitacion.DialogResult <> Windows.Forms.DialogResult.OK Then
                '    frmPaneldeVentas_Invitacion.Dispose()
                '    Exit Sub
                'End If
                'Dim str As String = frmPaneldeVentas_Invitacion.strTipoInvitacion
                'frmPaneldeVentas_Invitacion.Dispose()

                ''Actualizo las lineas
                'For i As Integer = 0 To Me.LstLines.Items.Count - 1
                '    Me.LstLines.Items(i).SubItems(lst_Columns_Tickets.pvp_ud).Text = 0

                '    Me.LstLines.Items(i).SubItems(lst_Columns_Tickets.total).Text = Format(CDbl(Me.LstLines.Items(0).SubItems(lst_Columns_Tickets.pvp_ud).Text) * Me.LstLines.Items(0).SubItems(lst_Columns_Tickets.ud).Text, "0.00")
                '    Me.LstLines.Items(i).SubItems(lst_Columns_Tickets.tipo_invitacion).Text = str
                '    'Me.LstLines.Items(i).SubItems(lst_Columns_Tickets.tipo_invitacion).Text = Me._strTipoInvitacion
                '    Me.LstLines.Items(i).Checked = True
                'Next

                'Me.swChange = True
                'Me.Calcular_Totales()

            Case "ADDINVITACION"
                If MsgBox("¿Esta seguro de que desea dar la linea como invitación?", MsgBoxStyle.OkCancel + MsgBoxStyle.Question, "Invitación") <> MsgBoxResult.Ok Then Exit Sub

                frmPaneldeVentas_Invitacion.ShowDialog()
                If frmPaneldeVentas_Invitacion.DialogResult <> Windows.Forms.DialogResult.OK Then
                    frmPaneldeVentas_Invitacion.Dispose()
                    Exit Sub
                End If
                Dim str As String = frmPaneldeVentas_Invitacion.strTipoInvitacion
                frmPaneldeVentas_Invitacion.Dispose()

                ' Si establezco la linea actual de invitación, establezco el precio a 0

                Me.LstLines.SelectedItems(0).SubItems(lst_Columns_Tickets.pvp_ud).Text = 0

                Me.LstLines.SelectedItems(0).SubItems(lst_Columns_Tickets.total).Text = Format(CDbl(Me.LstLines.SelectedItems(0).SubItems(lst_Columns_Tickets.pvp_ud).Text) * Me.LstLines.SelectedItems(0).SubItems(lst_Columns_Tickets.ud).Text, "0.00")
                Me.LstLines.SelectedItems(0).SubItems(lst_Columns_Tickets.tipo_invitacion).Text = str
                Me.LstLines.SelectedItems(0).SubItems(lst_Columns_Tickets.tipo_invitacion).Text = Me._strTipoInvitacion
                Me.LstLines.SelectedItems(0).Checked = True
                Me.LstLines.Focus()

                Me.swChange = True
                Me.Calcular_Totales()



            Case "INVITACION"
                Me.swInvitacion = True

            Case "ENTRADA_REFRESCO"
                Me.swEntrada_Refresco = True

            Case "ENTRADA_COPA"
                Me.swEntrada_Copa = True

            Case "COBRO_PARCIAL"
                If Me.swChange Then
                    'Guardo y Recargo valores
                    Me.SaveTicket()
                    Me.LoadInfo_Ticket()
                    'MsgBox("Se han producido modificaciones en el ticket actual, para continuar se ha procedido a guardar los cambios", MsgBoxStyle.Information)
                End If

                frmPaneldeVentas_CobroParcial.Id_Ref = Me.idRef
                frmPaneldeVentas_CobroParcial.Id_User = Me.idUser
                frmPaneldeVentas_CobroParcial.ShowDialog(Me)

                'Compruebo si no quedan articulos en el ticket lo borro
                If frmPaneldeVentas_CobroParcial.swDeleteTicket Then
                    Me.swKill = True
                    My.m_db.Execute("DELETE * FROM db_tickets WHERE id=" & Me.idRef)

                    frmPaneldeVentas_CobroParcial.Dispose()
                    frmPaneldeVentas_CobroParcial = Nothing

                    Me.DialogResult = Windows.Forms.DialogResult.OK
                    Exit Sub
                End If


                'Si ha habido cambios recargo valores
                If frmPaneldeVentas_CobroParcial.swChanges Then
                    Me.LoadInfo_Ticket()
                    Me.LoadInfo_User()
                    Me.LoadInfo_Mesa()

                    Me.swChange = False
                    Me.swReload = True

                    frmPaneldeVentas_CobroParcial.Dispose()
                    frmPaneldeVentas_CobroParcial = Nothing

                    Me.DialogResult = Windows.Forms.DialogResult.OK
                    Exit Sub
                End If

                frmPaneldeVentas_CobroParcial.Dispose()
                frmPaneldeVentas_CobroParcial = Nothing


            Case "PESAJE"
                If Not My.MyHardware.Balanza_Enabled OrElse My.MyHardware.Balanza_Port = "NINGUNO" Then
                    My.m_msg.MessageError("No esta establecida ninguna configuración correcta de balanza PC.")
                    Exit Sub
                End If

                frmPaneldeVentas_Pesaje.IdRef = Me.LstLines.SelectedItems(0).SubItems(lst_Columns_Tickets.id_art).Text
                frmPaneldeVentas_Pesaje.ShowDialog(Me)
                If frmPaneldeVentas_Pesaje.DialogResult <> Windows.Forms.DialogResult.OK Then
                    frmPaneldeVentas_Pesaje.Dispose()
                    Exit Sub
                End If


                Me.LstLines.SelectedItems(0).SubItems(lst_Columns_Tickets.ud).Text = frmPaneldeVentas_Pesaje.LblPeso.Text
                Me.LstLines.SelectedItems(0).SubItems(lst_Columns_Tickets.total).Text = Format(CDbl(Me.LstLines.SelectedItems(0).SubItems(lst_Columns_Tickets.pvp_ud).Text) * Me.LstLines.SelectedItems(0).SubItems(lst_Columns_Tickets.ud).Text, "0.00#")

                frmPaneldeVentas_Pesaje.Dispose()

                Me.LstLines.SelectedItems(0).Checked = True
                Me.LstLines.Focus()
                Me.swChange = True
                Me.Calcular_Totales()

            Case "HISTORY"
                If Me.swChange AndAlso MsgBox("Se han producido modificaciones en el ticket actual, estos todavía no se reflejan en el historial del ticket." & vbCrLf & "¿Desea guardar estas modificaciones para poder apreciarlas en el historial?", MsgBoxStyle.OkCancel + MsgBoxStyle.Question) = MsgBoxResult.Ok Then
                    'Guardo y Recargo valores
                    Me.SaveTicket()
                    Me.LoadInfo_Ticket()
                End If
                frmPaneldeVentas_History.Id_Ref = Me.idRef
                frmPaneldeVentas_History.ShowDialog(Me)
                frmPaneldeVentas_History.Dispose()
                frmPaneldeVentas_History = Nothing

            Case "SETNAME"
                frmPaneldeVentas_Name.TxtName.Text = Me.LblMesa.Text
                frmPaneldeVentas_Name.ShowDialog(Me)
                If frmPaneldeVentas_Name.DialogResult <> Windows.Forms.DialogResult.OK Then
                    frmPaneldeVentas_Name.Dispose()
                    Exit Sub
                End If
                Me.LblMesa.Text = frmPaneldeVentas_Name.TxtName.Text.Replace("'", "")
                Me.swChange = True
                frmPaneldeVentas_Name.Dispose()

            Case "NUEVA_RESERVA"
                frmReservas_Evento.IdRef = 0
                frmReservas_Evento.fhEvento = Now
                frmReservas_Evento.ShowDialog(Me)
                If frmReservas_Evento.DialogResult <> Windows.Forms.DialogResult.OK Then
                    frmReservas_Evento.Dispose()
                    Exit Sub
                End If
                frmReservas_Evento.Dispose()

            Case "CERRAR_CAJA"
                If MsgBox("¿Esta seguro de que desea cerrar la caja actual?", MsgBoxStyle.OkCancel + MsgBoxStyle.Question) <> MsgBoxResult.Ok Then Exit Sub
                Me.CloseCajaActual()
                If Me.idMesa <> -1 Then
                    Me.swKill = True
                    Me.DialogResult = Windows.Forms.DialogResult.OK
                End If

            Case "GENERAR_FACTURA"
                ''Guardo y Recargo valores
                'Me.SaveTicket()
                'Me.LoadInfo_Ticket()

                ''Si no esta facturado, permito facturarlo
                'If Val(Me.LblIdFactura.Text) <= 0 Then
                '    'Muestro el formulario de facturar
                '    frmPaneldePedidos_Facturar.IdRef = Me.idRef
                '    frmPaneldePedidos_Facturar.ConfigureApp("facturar")
                '    frmPaneldePedidos_Facturar.ShowDialog(Me)
                '    If frmPaneldePedidos_Facturar.DialogResult = Windows.Forms.DialogResult.OK Then
                '        'Actualizo los estados
                '        Me.swKill = True
                '        Me.DialogResult = Windows.Forms.DialogResult.OK
                '    End If
                '    frmPaneldePedidos_Facturar.Dispose()
                'Else
                '    'Muestro la factura
                '    Dim FrmAux As New frmPreviewReport, StrSQL As String = ""
                '    FrmAux.StrName = "Generar Factura"
                '    FrmAux.StrSubName = "Generación de Facturas a Clientes"

                '    'Compongo la sql
                '    StrSQL &= IIf(StrSQL.Length > 0, " AND ", "") & " {app_empresa.id}=" & My.m_app.GetValue("id_empresa")
                '    StrSQL &= IIf(StrSQL.Length > 0, " AND ", "") & " {db_facturas.id}=" & Me.LblIdFactura.Text


                '    FrmAux.RptPrint = New crtFactura

                '    FrmAux.StrSQL = StrSQL
                '    FrmAux.ShowDialog(Me)
                'End If


            Case "FINALIZA_TICKET"
                'Guardo y Mato el Ticket
                Me.SaveTicket(True)
                My.OpenCajon()

                'Si es caja directa creo un nuevo ticket (siempre que no este editando un ticket finalizado)
                If Me.swCajaDirecta AndAlso Not Me.swFinalizado Then
                   
                    Me.NuevoTicket()
                    Me.LstLines.Visible = True
                    Exit Select
                End If

                Me.swKill = True
                Me.DialogResult = Windows.Forms.DialogResult.OK

            Case "CANCELATICKET"
                'Cancelo el ticket
                If MsgBox("¿Esta seguro de que desea anular el ticket?", MsgBoxStyle.OkCancel + MsgBoxStyle.Question, My.APP_NAME) <> MsgBoxResult.Ok Then Exit Select
                Me.CancelaTicket()

                'Si es caja directa creo un nuevo ticket (siempre que no este editando un ticket ya finalizado)
                If Me.swCajaDirecta AndAlso Not Me.swFinalizado Then
                    Me.NuevoTicket()
                    Exit Select
                End If


                Me.swKill = True
                Me.DialogResult = Windows.Forms.DialogResult.OK


            Case "COBRAR_TICKET"
                If Not CobroAvanzado() Then Exit Select

                'Si es caja directa creo un nuevo ticket (Siempre que no este editando un ticket finalizado)
                If Me.swCajaDirecta AndAlso Not Me.swFinalizado Then
                    Me.NuevoTicket()
                    Exit Select
                End If

                Me.DialogResult = Windows.Forms.DialogResult.OK

            Case "ADDFREE"
                Me.AddFreeArt()
                Me.swChange = True

            Case "PRINT_TICKET"
                Me.PrintTicket(0, False)

            Case "CHANGE_USER"
                Dim _id As Integer = My.ValidateUser()
                If _id = -1 Then Exit Select
                Me.idUser = _id
                Me.LoadInfo_User()

                Me.swChange = True

            Case "NUEVO_TICKET"
                If Me.LstLines.Items.Count > 0 Then If MsgBox("¿Esta seguro de que desea comenzar un nuevo ticket sin haber finalizado el actual?", MsgBoxStyle.OkCancel + MsgBoxStyle.Question, My.APP_NAME) <> MsgBoxResult.Ok Then Exit Select
                Me.NuevoTicket()

                Me.swChange = False

            Case "DEL_LINEA"
                If MsgBox("¿Esta seguro de que desea eliminar la linea seleccionada de '" & Me.LstLines.SelectedItems(0).SubItems(lst_Columns_Tickets.total).Text & " " & System.Threading.Thread.CurrentThread.CurrentCulture.NumberFormat.CurrencySymbol & "' del artículo '" & Me.LstLines.SelectedItems(0).SubItems(lst_Columns_Tickets.name).Text & "'?", MsgBoxStyle.YesNo + MsgBoxStyle.Question, My.APP_NAME) <> MsgBoxResult.Yes Then Exit Select
                Dim i As Integer = Me.LstLines.SelectedItems(0).Index

                If (Me.LstLines.SelectedItems(0).Text > 0) Then
                    ReDim Preserve arrDelField(UBound(arrDelField) + 1)
                    ReDim Preserve arrDelField_IdArt(UBound(arrDelField_IdArt) + 1)
                    ReDim Preserve arrDelField_Tipo(UBound(arrDelField_Tipo) + 1)
                    ReDim Preserve arrDelField_IdArtCombina(UBound(arrDelField_IdArtCombina) + 1)
                    ReDim Preserve arrDelField_Ud(UBound(arrDelField_Ud) + 1)
                    arrDelField(UBound(arrDelField)) = Me.LstLines.SelectedItems(0).SubItems(lst_Columns_Tickets.id).Text
                    arrDelField_IdArt(UBound(arrDelField_IdArt)) = Me.LstLines.SelectedItems(0).SubItems(lst_Columns_Tickets.id_art).Text
                    arrDelField_Tipo(UBound(arrDelField_Tipo)) = Me.LstLines.SelectedItems(0).SubItems(lst_Columns_Tickets.tipo).Text
                    arrDelField_IdArtCombina(UBound(arrDelField_IdArtCombina)) = Me.LstLines.SelectedItems(0).SubItems(lst_Columns_Tickets.id_art_combina).Text
                    arrDelField_Ud(UBound(arrDelField_Ud)) = Me.LstLines.SelectedItems(0).SubItems(lst_Columns_Tickets.ud_original).Text
                End If
                Me.LstLines.SelectedItems(0).Remove()

                i -= 1
                If i < 0 Then i = 0

                'Selecciono por defecto el anterior item
                Me.LstLines.SelectedItems.Clear()
                If Me.LstLines.Items.Count > 0 Then
                    Me.LstLines.Items(i).Selected = True
                    Me.LstLines.EnsureVisible(i)
                End If

                Me.Calcular_Totales()
                Me.swChange = True

            Case "N_UP"
                If Me.LstLines.SelectedItems(0).SubItems(lst_Columns_Tickets.id_art).Text > 0 AndAlso Me.LstLines.SelectedItems(0).SubItems(lst_Columns_Tickets.pvp_ud).Text > 0 Then
                    Me.ProcesaClick(Me.LstLines.SelectedItems(0).SubItems(lst_Columns_Tickets.id_art).Text, Me.LstLines.SelectedItems(0).SubItems(lst_Columns_Tickets.id_art_combina).Text, Me.LstLines.SelectedItems(0).SubItems(lst_Columns_Tickets.tipo).Text)
                Else
                    Me.LstLines.SelectedItems(0).SubItems(3).Text += 1
                    Me.LstLines.SelectedItems(0).SubItems(lst_Columns_Tickets.total).Text = Format(CDbl(Me.LstLines.SelectedItems(0).SubItems(lst_Columns_Tickets.pvp_ud).Text) * Me.LstLines.SelectedItems(0).SubItems(lst_Columns_Tickets.ud).Text, "0.00")
                End If

                Me.LstLines.SelectedItems(0).Checked = True
                Me.BtN_Down.Enabled = (Me.LstLines.SelectedItems(0).SubItems(lst_Columns_Tickets.ud).Text > 1)
                Me.LstLines.Focus()

                Me.swChange = True
                Me.Calcular_Totales()

            Case "N_DOWN"
                Me.LstLines.SelectedItems(0).SubItems(3).Text -= 1
                Me.LstLines.SelectedItems(0).SubItems(lst_Columns_Tickets.total).Text = Format(CDbl(Me.LstLines.SelectedItems(0).SubItems(lst_Columns_Tickets.pvp_ud).Text) * Me.LstLines.SelectedItems(0).SubItems(lst_Columns_Tickets.ud).Text, "0.00")
                'Me.ProcesaClick(Me.LstLines.SelectedItems(0).SubItems(lst_Columns_Tickets.id_art).Text, Me.LstLines.SelectedItems(0).SubItems(lst_Columns_Tickets.id_art_combina).Text)
                Me.LstLines.SelectedItems(0).Checked = True
                Me.BtN_Down.Enabled = (Me.LstLines.SelectedItems(0).SubItems(lst_Columns_Tickets.ud).Text > 1)
                Me.LstLines.Focus()

                Me.swChange = True

                Me.Calcular_Totales()

            Case "MINIMIZE"
                frm_AppIsMinimized.Show()

                Me.Owner.WindowState = FormWindowState.Minimized
                Me.WindowState = FormWindowState.Minimized

            Case "SAVE"
                Me.SaveTicket()
                Me.DialogResult = Windows.Forms.DialogResult.OK

            Case "KILL"
                Me.Close()

            Case "CLOSE"
                'Si tiene articulos guardo
                If Me.swChange AndAlso Me.LstLines.Items.Count > 0 Then
                    If Me.idMesa = -1 Then
                        If MsgBox("¿Esta seguro desea salir del Panel de Pedidos y cancelar el pedido actual?", MsgBoxStyle.OkCancel + MsgBoxStyle.Question, My.APP_NAME) <> MsgBoxResult.Ok Then Exit Select
                    Else
                        'Por si deseo Guardar los posibles cambios realizados
                        Dim resp As DialogResult = MsgBox("¿Desea guardar los cambios que ha realizado en el pedido Actual?", MsgBoxStyle.YesNoCancel + MsgBoxStyle.Question, My.APP_NAME)
                        If resp = Windows.Forms.DialogResult.Yes Then
                            Me.SaveTicket()
                            Me.DialogResult = Windows.Forms.DialogResult.OK
                        ElseIf resp = Windows.Forms.DialogResult.Cancel Then
                            Exit Select
                        End If
                    End If
                End If

                Me.Close()

            Case Else
                My.m_msg.MessageError(Me, "Tag no referenciado")
                'RaiseEvent Shell_App(app)
        End Select
    End Sub


    'Copruebo botones de estado
    Private Sub CheckStateButtons()
        Dim sw As Boolean = (Me.LstLines.Items.Count > 0)
        'Preservo acciones
        Me.GroupActions.Enabled = sw
        Me.GroupCobro.Enabled = sw

        'Acciones sobre la linea selecciona del ticket
        sw = (Me.LstLines.SelectedItems.Count > 0)
        Me.BtDel_Line.Enabled = sw
        Me.BtAddInvitacion.Enabled = sw
        Me.BtN_Up.Enabled = sw
        Me.BtPesaje.Enabled = sw
        Me.BtN_Down.Enabled = sw AndAlso (Me.LstLines.SelectedItems(0).SubItems(3).Text > 1)

        'Pos si fuera de pesaje
        If sw Then
            Me.BtN_Up.Visible = Not CBool(Me.LstLines.SelectedItems(0).SubItems(lst_Columns_Tickets.pesaje).Text)
            Me.BtN_Down.Visible = Not CBool(Me.LstLines.SelectedItems(0).SubItems(lst_Columns_Tickets.pesaje).Text)
            Me.BtPesaje.Visible = CBool(Me.LstLines.SelectedItems(0).SubItems(lst_Columns_Tickets.pesaje).Text)
        End If
    End Sub
#End Region

#Region "Eventos Principales"
    ' Formulario de Carga
    Private Sub m_Shell_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'Configuro el formulario y Centro el body
        Me.Size = Screen.PrimaryScreen.WorkingArea.Size
        Me.PnlBody.Left = (Me.Width - Me.PnlBody.Width) / 2
        Me.PnlBody.Top = (Me.SplitContainer.Panel2.Height - Me.PnlBody.Height) / 2 + (IIf(My.m_opt.swNoteBook, Me.SplitContainer.Panel1.Height, 0))

        'Cargo producto y configuro
        Me.ConfiguraTicket()
        Me.Load_CatProductos()

        Select Case Me._idCat
            Case -2
                Me.Load_ArticulosPedidos()
            Case -1                         'Ultimos articulos usados
                Me.Load_ArticulosbyMostUsed()
            Case Else
                Me.Load_ArticulosFromCat(Me._idCat)
        End Select



        'Caso de caja directa o nueva ticket de mesa
        If Me.idMesa = -1 OrElse Me.idRef = -1 Then
            Me.NuevoTicket(True)
            Me.BtCancelaTicket.Enabled = False
        Else
            Me.BtNewTicket.Enabled = False
        End If

        Me.BtAsignaNombre.Enabled = Not (Me.idMesa = -1)
        Me.BtCobroParcial.Enabled = Not (Me.idMesa = -1)

        'Cargo valores de informacion
        Me.LoadInfo_Ticket()
        Me.LoadInfo_User()
        Me.LoadInfo_Mesa()

        'Dependiendo de si es caja directa o es una mesa
        Me.BtSave.Visible = (Me.idMesa <> -1 And Me.idRef > 0)
        If Me.swFinalizado Then Me.BtSave.Visible = False 'Si esta finalizado, no permito guardar, solo cobro


        'If Me.idMesa = -1 OrElse Me.swFinalizado Then Me.BtCobroDirecto.Location = Me.BtSave.Location

        Me.BtCloseUserCaja.Enabled = My.m_opt.cajadirecta_closeuser



        Me.PnlBody.Visible = True

        Me.LblHour.Text = Now.ToString("HH:mm")
        Me.TmHour.Enabled = True
    End Sub


    ' Limpieza de objetos
    Private Sub frmPaneldePedidos_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        'If Not IsNothing(Me.m_data) Then
        '    Me.m_data.Dispose()
        '    Me.m_data = Nothing
        'End If
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
    Private Sub Buttons_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtClose.Click, BtPrint.Click, BtNewTicket.Click, BtDel_Line.Click, BtCobrar.Click, BtChangeUser.Click, BtN_Up.Click, BtN_Down.Click, BtSave.Click, BtFreeArt.Click, BtCobroDirecto.Click, BtCancelaTicket.Click, BtFactTicket.Click, BtAddReserva.Click, BtCloseUserCaja.Click, BtAsignaNombre.Click, BtHistory.Click, BtCobroParcial.Click, BtPesaje.Click, BtInvitación.Click, BtAddInvitacion.Click, Button6.Click, Button5.Click, BtTraspasar.Click, BtInvita_All.Click
        'Si no tiene establecido el tag mando un error
        If IsNothing(CType(sender, Button).Tag) OrElse CType(sender, Button).Tag.ToString.Length = 0 Then
            My.m_msg.MessageError(sender, "Tag de control de elemento no referenciado")
            Exit Sub
        End If

        ShellApp(CType(sender, Button).Tag.ToString)
    End Sub

    'Vuelvo a agregar el ultimo articulo
    Private Sub BtLastArticulo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtLastArticulo.Click
        Me.ProcesaClick(Me._lastUse_id, Me._lastUse_idCombina)
    End Sub

    Private Sub m_Shell_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        Me.Left = 0
        Me.Top = 0

        Me.LstLines.Select()
    End Sub

    Private Sub TmrAvisoPvp_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TmrAvisoPvp.Tick
        Me.TmrAvisoPvp.Enabled = False
        'Me.LblTotal.BackColor = Color.IndianRed
        'Me.LblNfo_Total.BackColor = Me.LblTotal.BackColor

        Me.PnlPVP.BackColor = Color.IndianRed
        Me.LblTotal.BackColor = Color.IndianRed
        Me.LblTotal.Font = New Font("Tahoma", 18.0!, FontStyle.Bold)


        Me.BtLastArticulo.Font = New System.Drawing.Font("Tahoma", 6.75!, System.Drawing.FontStyle.Bold)
        Me.BtLastArticulo.Text = Me.BtLastArticulo.Tag

    End Sub

    Private Sub LstLines_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LstLines.SelectedIndexChanged
        CheckStateButtons()
    End Sub

    Private Sub TmrCloseSesion_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If Not Me.swChange Then Me.ShellApp("KILL")
    End Sub

    Private Sub m_logo_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles m_logo.DoubleClick
        My.OpenCajon()
    End Sub

    Private Sub TmHour_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TmHour.Tick
        Me.LblHour.Text = Now.ToString("HH:mm")
    End Sub

#End Region

#Region "Articulos"
#Region "Categorias de Productos"
    Private _idCat As Integer = 0           'Categoria actual
    Private _First_idCat As Integer = 0   'Id de la primera categoria

    'Registros para la paginación
    'Private _cat_tot As Integer = 0
    Private _cat_pag As Integer = 0

    Private Sub Load_CatProductos()
        Me.BtCat_Previous.Enabled = (Me._cat_pag > 0)
        Me.BtCat_Next.Enabled = False

        ' Nº de productos a lo ancho a mostrar
        Dim _x As Integer = 4

        'Localizacion de inicio para el primer boton
        Dim _left As Integer = 80
        Dim _top As Integer = 3

        'Variables Auxiliares
        Dim i As Integer = 0, n As Integer = 0
        Dim rst As ADODB.Recordset ', rstTmp As ADODB.Recordset = Nothing
        Dim sql As String

        ''### Paginacion
        'sql = "SELECT count(id) as tot FROM db_categorias"
        'rst = My.m_db.GetRst(sql)
        'Me._cat_tot = rst("tot").Value + 1            '(La categoria extra es de funciones especiales: Articulos mas usados)
        'My.m_db.CloseRst(rst)

        '### Limpio anteriores controltes
        For i = Me.PnlCategorias.Controls.Count - 1 To 2 Step -1
            Me.PnlCategorias.Controls(i).Dispose()
        Next


        '### Obtengo las imagenes de la categoria seleccionada
        'sql = "SELECT db_categorias.*,app_imgs.img FROM db_categorias LEFT JOIN app_imgs"
        'sql &= " ON db_categorias.id=app_imgs.id"
        'sql &= " ORDER BY db_categorias.n_veces ASC,name ASC"

        sql = "SELECT * FROM db_categorias"
        sql &= " ORDER BY swPedidos ASC,n_veces DESC,name ASC"
        rst = My.m_db.GetRst(sql)


        '### Agrego los botones de las imagenes
        i = 0
        n = 2 'Total de categorias especiales

        'Primera categoria de la Pagina 1: Articulos mas usados
        If Me._cat_pag = 0 Then
            n = 1
            ' Agrego el boton de mas usados
            Dim bt As Button
            bt = New Button
            bt.Font = New Font("Verdana", 10, FontStyle.Bold)
            'bt.Image = My.m_db.data_GetImgRow(rst("img"))
            bt.Margin = New Padding(0)
            bt.Name = n
            bt.Size = New Size(112, 109)
            bt.TabIndex = n
            bt.Location = New Point(_left + (bt.Width * i) + (4 * i), _top)
            bt.Text = "Artículos Pedido"
            bt.TextAlign = ContentAlignment.MiddleCenter
            bt.Tag = -2
            bt.UseVisualStyleBackColor = True
            bt.UseMnemonic = False

            ' Asigno Eventos, sitio y valores de estado
            AddHandler bt.Click, AddressOf BtCatProductos_Click
            Me.PnlCategorias.Controls.Add(bt)

            'Establezco valores de comportamiento
            i = n
            If Me._First_idCat = 0 Then
                Me._idCat = -2
                Me._First_idCat = rst("id").Value
            End If

            n = 2
            ' Agrego el boton de mas usados
            bt = New Button
            bt.Font = New Font("Verdana", 10, FontStyle.Bold)
            'bt.Image = My.m_db.data_GetImgRow(rst("img"))
            bt.Margin = New Padding(0)
            bt.Name = n
            bt.Size = New Size(112, 109)
            bt.TabIndex = n
            bt.Location = New Point(_left + (bt.Width * i) + (4 * i), _top)
            bt.Text = "Artículos mas Usados"
            bt.TextAlign = ContentAlignment.MiddleCenter
            bt.Tag = -1
            bt.UseVisualStyleBackColor = True
            bt.UseMnemonic = False

            ' Asigno Eventos, sitio y valores de estado
            AddHandler bt.Click, AddressOf BtCatProductos_Click
            Me.PnlCategorias.Controls.Add(bt)

            'Establezco valores de comportamiento
            i = n
            'If Me._First_idCat = 0 Then
            '    Me._idCat = -1
            '    Me._First_idCat = rst("id").Value
            'End If
        End If

        While Not rst.EOF
            'Compruebo que la categoria tenga algun producto para mostrarla
            'rstTmp = My.m_db.GetRst("SELECT COUNT(id) as ntot FROM db_articulos WHERE id_categoria=" & rst("id").Value)
            'If rstTmp("ntot").Value > 0 Then

            If (n >= (Me._cat_pag * _x)) Then
                'Si es la primera categoria guardo cual es
                If Me._First_idCat = 0 Then
                    Me._idCat = rst("id").Value
                    Me._First_idCat = rst("id").Value
                End If

                ' Creo y configuro el nuevo boton
                Dim bt As Button
                bt = New Button
                bt.Font = New Font("Verdana", 7, FontStyle.Bold)
                bt.Image = My.m_db.data_GetImgRow(rst("img"))
                bt.Margin = New Padding(0)
                bt.Name = n
                bt.Size = New Size(112, 109)
                bt.TabIndex = n
                bt.Location = New Point(_left + (bt.Width * i) + (4 * i), _top)
                bt.Text = rst("name").Value
                bt.TextAlign = ContentAlignment.BottomCenter
                bt.Tag = rst("id").Value
                bt.UseVisualStyleBackColor = True
                bt.UseMnemonic = False

                ' Asigno Eventos
                AddHandler bt.Click, AddressOf BtCatProductos_Click

                Me.PnlCategorias.Controls.Add(bt)
                bt.Visible = True

                i += 1
                If i = _x Then
                    i = 0
                    rst.MoveNext()
                    Me.BtCat_Next.Enabled = Not rst.EOF
                    Exit While
                End If
            End If
            n += 1
            'End If
            'My.m_db.CloseRst(rstTmp)
            rst.MoveNext()
        End While
        My.m_db.CloseRst(rst)
    End Sub

    Private Sub BtCat_Move_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtCat_Previous.Click, BtCat_Next.Click
        Select Case True
            Case sender Is Me.BtCat_Previous
                Me._cat_pag -= 1

            Case sender Is Me.BtCat_Next
                Me._cat_pag += 1
        End Select

        Me._First_idCat = 0

        Me.Load_CatProductos()
        Me.Load_ArticulosFromCat(Me._First_idCat)
    End Sub

    ' Muestro los articulos de una categoria
    Private Sub BtCatProductos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me._idCat = CStr(CType(sender, Button).Tag & "")

        Me._articulos_tot = 0
        Me._articulos_pag = 0

        'Categorias especiales o carga normal
        Select Case Me._idCat
            Case -1
                Me.Load_ArticulosbyMostUsed()
            Case -2
                Me.Load_ArticulosPedidos()
            Case Else
                Me.Load_ArticulosFromCat(CStr(CType(sender, Button).Tag & ""))
        End Select
    End Sub
#End Region

#Region "Geleria de Imagenes"
    Private _articulos_tot As Integer = 0
    Private _articulos_pag As Integer = 0

    'Funcion para cargar los articulos de una categoria real
    Private Sub Load_ArticulosFromCat(ByVal id_cat As Integer)
        Me.PnlArticulos.Visible = False
        Me.PnlArticulos.SuspendLayout()

        'Variables Auxiliares
        Dim i As Integer = 0, j As Integer = 0, n As Integer
        Dim rst As ADODB.Recordset
        Dim sql As String, str As String = ""


        '### Obtengo información sobre la categoria
        sql = "SELECT name FROM db_categorias WHERE id=" & id_cat
        rst = My.m_db.GetRst(sql)
        Me.LblNameCat.Text = "Familia: " & rst("name").Value
        Me.lblNameCategoria.Text = rst("name").Value
        My.m_db.CloseRst(rst)


        Me.BtArticulos_Prev.Enabled = (Me._articulos_pag > 0)
        Me.BtArticulos_Next.Enabled = False


        '### Paginacion
        sql = "SELECT count(id) as tot FROM db_articulos"
        sql &= " WHERE id_categoria=" & id_cat
        rst = My.m_db.GetRst(sql)
        Me._articulos_tot = rst("tot").Value
        My.m_db.CloseRst(rst)

        Me.LblNofM.Text = "Mostrando " & Me._articulos_tot & " artículos en página " & (Me._articulos_pag + 1) & " de " & Format((Me._articulos_tot / (_x * _y)) + 1, "0") & " páginas"

        '### Limpio anteriores controltes
        For i = Me.PnlArticulos.Controls.Count - 1 To 2 Step -1
            Me.PnlArticulos.Controls(i).Dispose()
        Next

        '### Obtengo las articulos de la categoria seleccionada
        sql = "SELECT db_articulos.*,app_imgs.img FROM db_articulos LEFT JOIN app_imgs"
        sql &= " ON db_articulos.id_img=app_imgs.id "
        sql &= " WHERE db_articulos.id_categoria=" & id_cat
        sql &= " ORDER BY db_articulos.n_veces DESC,db_articulos.name ASC"
        rst = My.m_db.GetRst(sql)


        '### Agrego los botones de las imagenes
        i = 0
        While Not rst.EOF
            If (n >= (Me._articulos_pag * (_x * _y))) Then
                ' Creo y configuro el nuevo boton
                Dim bt As Button
                bt = New Button
                bt.Image = My.m_db.data_GetImgRow(rst("img"))
                bt.ImageAlign = ContentAlignment.TopCenter
                bt.Margin = New Padding(0)
                bt.Name = "articulo_" & n
                bt.Size = New Size(112, 109)
                bt.TabIndex = n
                bt.Location = New Point(_left + (bt.Width * i), _top + (bt.Height * j))
                If rst("id_img").Value = 0 Then            'Si no tiene imagen
                    bt.Text = rst("name").Value
                    bt.TextAlign = ContentAlignment.MiddleCenter
                    bt.Font = New Font("Verdana", 9, FontStyle.Bold)
                Else
                    bt.Text = ""
                End If
                bt.Tag = rst("id").Value
                bt.UseVisualStyleBackColor = True
                bt.UseMnemonic = False

                ' Asigno Eventos
                AddHandler bt.Click, AddressOf BtProcesaArticulo_Click

                'Creo y configuro la etiqueta
                Dim lbl As Label
                lbl = New Label
                With lbl
                    .AutoSize = False
                    .BackColor = Color.Black
                    .Font = New Font("Arial", 6, FontStyle.Regular)
                    .ForeColor = Color.YellowGreen
                    .Location = New Point(_left + (bt.Width * i) + 8, _top + (bt.Height * j) + (bt.Height - 22))
                    .Size = New Size(96, 14)
                    .Text = rst("name").Value
                    .TextAlign = ContentAlignment.MiddleCenter
                    If rst("id_img").Value = 0 Then .Visible = False
                End With


                Me.PnlArticulos.Controls.Add(lbl)
                Me.PnlArticulos.Controls.Add(bt)

                bt.Visible = True

                If CBool(rst("valoracion").Value) Then
                    'Creo y configuro la etiqueta
                    Dim btOpt As Button
                    btOpt = New Button
                    With btOpt
                        .Image = Me.PicExtra.Image
                        .Size = New Size(24, 24)

                        .Location = New Point(_left + (bt.Width * i) + (bt.Width - btOpt.Width - 5), _top + (bt.Height * j) + 5)
                        .FlatStyle = FlatStyle.Popup
                        .Tag = rst("id").Value
                        .Visible = True


                        ' Asigno Evento
                        AddHandler .Click, AddressOf ClickMoreOptions
                    End With


                    Me.PnlArticulos.Controls.Add(btOpt)
                    btOpt.BringToFront()
                End If

                'Extra info por el tooltip
                str = rst("name").Value
                str &= vbCrLf & Space(7) & "Precio: " & Format(rst("pvp_iva").Value, "0.00") & " " & System.Threading.Thread.CurrentThread.CurrentCulture.NumberFormat.CurrencySymbol
                'str &= vbCrLf
                str &= vbCrLf & Space(7) & "Usos: " & IIf(rst("n_veces").Value = 0, "SIN USAR", rst("n_veces").Value & " usos")
                Me.ToolTip.SetToolTip(bt, str)

                i += 1
                If i = _x Then
                    i = 0
                    j += 1
                    If j >= _y Then
                        Me.BtArticulos_Next.Enabled = ((Me._articulos_tot / (_x * _y)) > 1)
                        Exit While
                    End If
                End If
            End If

            n += 1
            rst.MoveNext()
        End While
        My.m_db.CloseRst(rst)

        Me.BtArticulos_Prev.BringToFront()
        Me.BtArticulos_Next.BringToFront()


        Me.PnlArticulos.ResumeLayout()
        Me.PnlArticulos.Visible = True
    End Sub

    'Funcion para obtener los articulos mas usados
    Private Sub Load_ArticulosbyMostUsed()
        'Variables Auxiliares e Inicializacion
        Dim i As Integer = 0, j As Integer = 0, n As Integer = 0
        Dim rst As ADODB.Recordset = Nothing
        Dim sql As String = "", str As String = ""

        Me.PnlArticulos.Visible = False
        Me.PnlArticulos.SuspendLayout()

        Me.BtArticulos_Prev.Enabled = False
        Me.BtArticulos_Next.Enabled = False

        Me.LblNofM.Text = "" '"Mostrando los #20 Artículos mas usados"
        Me.LblNameCat.Text = "Mostrando los #20 Artículos mas usados"
        Me.lblNameCategoria.Text = "Artículos mas usados"

        '### Limpio anteriores controltes
        For i = Me.PnlArticulos.Controls.Count - 1 To 2 Step -1
            Me.PnlArticulos.Controls(i).Dispose()
        Next

        ''### Obtengo las articulos de la categoria seleccionada
        sql = "SELECT db_articulos.*,app_imgs.img FROM db_articulos LEFT JOIN app_imgs"
        sql &= " ON db_articulos.id_img=app_imgs.id "
        'sql &= " WHERE db_articulos.id_categoria=" & id_cat
        sql &= " ORDER BY db_articulos.n_veces DESC,db_articulos.name ASC"
        rst = My.m_db.GetRst(sql)


        '### Agrego los botones de las imagenes
        i = 0
        While Not rst.EOF
            If (n >= (Me._articulos_pag * (_x * _y))) Then
                ' Creo y configuro el nuevo boton
                Dim bt As Button
                bt = New Button
                bt.Image = My.m_db.data_GetImgRow(rst("img"))
                bt.ImageAlign = ContentAlignment.TopCenter
                bt.Margin = New Padding(0)
                bt.Name = "articulo_" & n
                bt.Size = New Size(112, 109)
                bt.TabIndex = n
                bt.Location = New Point(_left + (bt.Width * i), _top + (bt.Height * j))
                If rst("id_img").Value = 0 Then            'Si no tiene imagen
                    bt.Text = rst("name").Value
                    bt.TextAlign = ContentAlignment.MiddleCenter
                    bt.Font = New Font("Verdana", 9, FontStyle.Bold)
                Else
                    bt.Text = ""
                End If
                bt.Tag = rst("id").Value
                bt.UseVisualStyleBackColor = True
                bt.UseMnemonic = False

                ' Asigno Eventos
                AddHandler bt.Click, AddressOf BtProcesaArticulo_Click

                'Creo y configuro la etiqueta
                Dim lbl As Label
                lbl = New Label
                With lbl
                    .AutoSize = False
                    .BackColor = Color.Black
                    .Font = New Font("Arial", 6, FontStyle.Regular)
                    .ForeColor = Color.YellowGreen
                    .Location = New Point(_left + (bt.Width * i) + 8, _top + (bt.Height * j) + (bt.Height - 22))
                    .Size = New Size(96, 14)
                    .Text = rst("name").Value
                    .TextAlign = ContentAlignment.MiddleCenter
                    If rst("id_img").Value = 0 OrElse My.m_opt.swNoNameImg Then .Visible = False
                End With

                Me.PnlArticulos.Controls.Add(lbl)
                Me.PnlArticulos.Controls.Add(bt)
                bt.Visible = True

                If CBool(rst("valoracion").Value) Then
                    'Creo y configuro la etiqueta
                    Dim btOpt As Button
                    btOpt = New Button
                    With btOpt
                        .Image = Me.PicExtra.Image
                        .Size = New Size(24, 24)

                        .Location = New Point(_left + (bt.Width * i) + (bt.Width - btOpt.Width - 5), _top + (bt.Height * j) + 5)
                        .FlatStyle = FlatStyle.Popup
                        .Tag = rst("id").Value
                        .Visible = True


                        ' Asigno Evento
                        AddHandler .Click, AddressOf ClickMoreOptions
                    End With


                    Me.PnlArticulos.Controls.Add(btOpt)
                    btOpt.BringToFront()
                End If


                'Extra info por el tooltip
                str = rst("name").Value
                str &= vbCrLf & Space(7) & "Precio: " & Format(rst("pvp_iva").Value, "0.00") & " " & System.Threading.Thread.CurrentThread.CurrentCulture.NumberFormat.CurrencySymbol
                'str &= vbCrLf
                str &= vbCrLf & Space(7) & "Usos: " & IIf(rst("n_veces").Value = 0, "SIN USAR", rst("n_veces").Value & " usos")
                'str &= vbCrLf & Space(7) & "#" & Format(rst("n_veces").Value, "0")
                Me.ToolTip.SetToolTip(bt, str)

                i += 1
                If i = _x Then
                    i = 0
                    j += 1
                    If j >= _y Then
                        Me.BtArticulos_Next.Enabled = ((Me._articulos_tot / (_x * _y)) > 1)
                        Exit While
                    End If
                End If
            End If

            n += 1
            rst.MoveNext()
        End While
        My.m_db.CloseRst(rst)

        Me.BtArticulos_Prev.BringToFront()
        Me.BtArticulos_Next.BringToFront()

        Me.PnlArticulos.ResumeLayout()
        Me.PnlArticulos.Visible = True
    End Sub

    'Funcion para obtener los articulos de pedido
    Private Sub Load_ArticulosPedidos()
        'Variables Auxiliares e Inicializacion
        Dim i As Integer = 0, j As Integer = 0, n As Integer = 0
        Dim rst As ADODB.Recordset = Nothing
        Dim sql As String = "", str As String = ""

        Me.PnlArticulos.Visible = False
        Me.PnlArticulos.SuspendLayout()

        Me.BtArticulos_Prev.Enabled = False
        Me.BtArticulos_Next.Enabled = False

        Me.LblNofM.Text = "" '"Mostrando los #20 Artículos mas usados"
        Me.LblNameCat.Text = "Artículos de Pedido"
        Me.lblNameCategoria.Text = "Artículos de Pedido"

        '### Limpio anteriores controltes
        For i = Me.PnlArticulos.Controls.Count - 1 To 2 Step -1
            Me.PnlArticulos.Controls(i).Dispose()
        Next

        ''### Obtengo las articulos de la categoria seleccionada
        sql = "SELECT db_articulos.*,app_imgs.img FROM db_articulos LEFT JOIN app_imgs"
        sql &= " ON db_articulos.id_img=app_imgs.id "
        sql &= " WHERE db_articulos.swPedido=TRUE"
        sql &= " ORDER BY db_articulos.name ASC"
        rst = My.m_db.GetRst(sql)


        '### Agrego los botones de las imagenes
        i = 0
        While Not rst.EOF
            If (n >= (Me._articulos_pag * (_x * _y))) Then
                ' Creo y configuro el nuevo boton
                Dim bt As Button
                bt = New Button
                bt.Image = My.m_db.data_GetImgRow(rst("img"))
                bt.ImageAlign = ContentAlignment.TopCenter
                bt.Margin = New Padding(0)
                bt.Name = "articulo_" & n
                bt.Size = New Size(112, 109)
                bt.TabIndex = n
                bt.Location = New Point(_left + (bt.Width * i), _top + (bt.Height * j))
                If rst("id_img").Value = 0 Then            'Si no tiene imagen
                    bt.Text = rst("name").Value
                    bt.TextAlign = ContentAlignment.MiddleCenter
                    bt.Font = New Font("Verdana", 9, FontStyle.Bold)
                Else
                    bt.Text = ""
                End If
                bt.Tag = rst("id").Value
                bt.UseVisualStyleBackColor = True
                bt.UseMnemonic = False

                ' Asigno Eventos
                AddHandler bt.Click, AddressOf BtProcesaArticulo_Click

                'Creo y configuro la etiqueta
                Dim lbl As Label
                lbl = New Label
                With lbl
                    .AutoSize = False
                    .BackColor = Color.Black
                    .Font = New Font("Arial", 6, FontStyle.Regular)
                    .ForeColor = Color.YellowGreen
                    .Location = New Point(_left + (bt.Width * i) + 8, _top + (bt.Height * j) + (bt.Height - 22))
                    .Size = New Size(96, 14)
                    .Text = rst("name").Value
                    .TextAlign = ContentAlignment.MiddleCenter
                    If rst("id_img").Value = 0 OrElse My.m_opt.swNoNameImg Then .Visible = False
                End With

                Me.PnlArticulos.Controls.Add(lbl)
                Me.PnlArticulos.Controls.Add(bt)
                bt.Visible = True

                If CBool(rst("valoracion").Value) Then
                    'Creo y configuro la etiqueta
                    Dim btOpt As Button
                    btOpt = New Button
                    With btOpt
                        .Image = Me.PicExtra.Image
                        .Size = New Size(24, 24)

                        .Location = New Point(_left + (bt.Width * i) + (bt.Width - btOpt.Width - 5), _top + (bt.Height * j) + 5)
                        .FlatStyle = FlatStyle.Popup
                        .Tag = rst("id").Value
                        .Visible = True


                        ' Asigno Evento
                        AddHandler .Click, AddressOf ClickMoreOptions
                    End With


                    Me.PnlArticulos.Controls.Add(btOpt)
                    btOpt.BringToFront()
                End If


                'Creo y configuro el boton de detalles
                If CBool(rst("swObs").Value) Then
                    Dim btOptObs As Button
                    btOptObs = New Button
                    With btOptObs
                        .Image = Me.picObs.Image
                        .Size = New Size(24, 24)

                        .Location = New Point(_left + (bt.Width * i) + (bt.Width - btOptObs.Width - 5), _top + (bt.Height * j) + (bt.Height - btOptObs.Height - 5))
                        .FlatStyle = FlatStyle.Popup
                        .Tag = rst("id").Value
                        .Visible = True


                        ' Asigno Evento
                        AddHandler .Click, AddressOf ClickObs
                    End With

                    Me.PnlArticulos.Controls.Add(btOptObs)
                    btOptObs.BringToFront()
                End If

                'Extra info por el tooltip
                str = rst("name").Value
                str &= vbCrLf & Space(7) & "Precio: " & Format(rst("pvp_iva").Value, "0.00") & " " & System.Threading.Thread.CurrentThread.CurrentCulture.NumberFormat.CurrencySymbol
                'str &= vbCrLf
                str &= vbCrLf & Space(7) & "Usos: " & IIf(rst("n_veces").Value = 0, "SIN USAR", rst("n_veces").Value & " usos")
                'str &= vbCrLf & Space(7) & "#" & Format(rst("n_veces").Value, "0")
                Me.ToolTip.SetToolTip(bt, str)

                i += 1
                If i = _x Then
                    i = 0
                    j += 1
                    If j >= _y Then
                        Me.BtArticulos_Next.Enabled = ((Me._articulos_tot / (_x * _y)) > 1)
                        Exit While
                    End If
                End If
            End If

            n += 1
            rst.MoveNext()
        End While
        My.m_db.CloseRst(rst)

        Me.BtArticulos_Prev.BringToFront()
        Me.BtArticulos_Next.BringToFront()

        Me.PnlArticulos.ResumeLayout()
        Me.PnlArticulos.Visible = True
    End Sub

    ' Muestro los articulos de una categoria
    Private Sub BtProcesaArticulo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        ProcesaClick(CStr(CType(sender, Button).Tag & ""))
    End Sub

    Private Sub BtArticulos_Move_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtArticulos_Prev.Click, BtArticulos_Next.Click
        Select Case True
            Case sender Is Me.BtArticulos_Prev
                Me._articulos_pag -= 1

            Case sender Is Me.BtArticulos_Next
                Me._articulos_pag += 1
        End Select

        Me.Load_ArticulosFromCat(Me._idCat)
    End Sub
#End Region

#End Region

#Region "Ticket"
    'Private _lastindex As Integer = -1
    Private _lastUse_id As Integer = 0
    Private _lastUse_idCombina As Integer = 0

    'Enumeracion para las columnas de la lista de materiales
    Private Enum lst_Columns_Tickets
        id = 0
        id_art = 1
        id_art_combina = 2
        ud = 3
        ud_original = 4
        name = 5
        pvp_ud = 6
        total = 7
        comanda = 8
        id_categoria = 9
        pvp_base = 10
        iva = 11
        pesaje = 12
        tipo = 13           'Puto Tutela (por la gracia del pendejo)
        entrada = 14
        tipo_invitacion = 15
        obs = 16
    End Enum

    'Funcion para Configurar el Ticket
    Private Sub ConfiguraTicket()
        With Me.LstLines.Columns
            .Clear()
            .Add("Ref.", 0, HorizontalAlignment.Right)
            .Add("Id Art", 0, HorizontalAlignment.Right)      'id_articulo
            .Add("Id Art Combina", 0, HorizontalAlignment.Right)      'id_articulo
            .Add("Ud", 30, HorizontalAlignment.Right)
            .Add("Ud Original", 0, HorizontalAlignment.Right)
            .Add("Artículo", 150, HorizontalAlignment.Left)
            .Add("Pvp/Ud", 0, HorizontalAlignment.Right)
            .Add("Total", 50, HorizontalAlignment.Right)
            .Add("Comanda", 0, HorizontalAlignment.Center)
            .Add("Id Categoria", 0, HorizontalAlignment.Center)
            .Add("Base imponible", 0, HorizontalAlignment.Left)
            .Add("IVA", 0, HorizontalAlignment.Left)
            .Add("Pesaje", 0, HorizontalAlignment.Left)
            .Add("tipo", 0, HorizontalAlignment.Left)
            .Add("Entrada", 0, HorizontalAlignment.Left)
            .Add("Tipo Invitación", 0, HorizontalAlignment.Left)
            .Add("Obs", 0, HorizontalAlignment.Left)
        End With

        'Si es sabor comercio doy configuración especial
        If My.m_opt.modo_compatibilidad = "COMERCIO" Then
            'Me.LstLines.Columns(lst_Columns_Tickets.ud).Text = "Ud/Peso"
            Me.LstLines.Columns(lst_Columns_Tickets.ud).Width = 55
            Me.LstLines.Columns(lst_Columns_Tickets.name).Width = 130
            Me.LstLines.Columns(lst_Columns_Tickets.total).Width = 55
        End If
    End Sub

    'Función para agregar una linea al ticket
    Private Sub ProcesaClick(ByVal id As Integer, Optional ByVal idCombinaCon As Integer = 0, Optional ByVal tipo As Integer = 0, Optional ByVal strObs As String = "")
        Dim i As Integer, sw As Boolean = False
        Dim rst As ADODB.Recordset
        Dim sql As String, id_combina As Integer = idCombinaCon, StrCombina As String = "", strTipo As String = ""
        Dim pvp_ud As Double = 0, pvp_inc As Double = 0, pvp_inc_Base As Double = 0


        'Las unidades por defecto 1
        Dim ud As Double = 1 ', pvp As Double = 0


        ' Por defecto, seleccionamos la pagina del tab de tickets
        Me.Tab.SelectedTab = Me.TabPage_Ticket

        '### Obtengo información sobre el artículo
        'sql = "SELECT name,pvp,iva,pvp_iva,combinable,id_categoria,id_categoria_combina,id_img,swcomanda,swpesaje"
        'If tipo > 0 Then sql &= ",vlcaso" & tipo & "_name,vlcaso" & tipo & "_pvp"
        'sql &= " FROM db_articulos WHERE id=" & id

        sql = "SELECT * FROM db_articulos WHERE id=" & id
        rst = My.m_db.GetRst(sql)

        If tipo <= 0 Then
            pvp_ud = rst("pvp_iva").Value

            'Si tengo establecido una tarifa
            If My.m_opt.id_tarifa > 0 Then
                If CBool(rst("swTarifas").Value) Then
                    pvp_ud = rst("tarifa_" & My.m_opt.id_tarifa & "_pvp").Value
                End If
            End If

            'Compruebo si el articulo combinable tiene incremento de precio
            If idCombinaCon > 0 Then
                Dim rstTMP As ADODB.Recordset = My.m_db.GetRst("SELECT id,swIncCombina,iva,pvp_IncCombina FROM db_articulos WHERE id=" & idCombinaCon)
                If CBool(rstTMP("swIncCombina").Value) Then pvp_ud += rstTMP("pvp_IncCombina").Value
                My.m_db.CloseRst(rstTMP)
            End If

            'Tipo de caso con comentarios
            If tipo <= -2 Then
                strTipo = " - PERSONALIZADO"
            End If
        Else
            pvp_ud = rst("vlcaso" & tipo & "_pvp").Value            'PUTO TUTELA
            strTipo = " - " & rst("vlcaso" & tipo & "_name").Value
        End If

        If Me.swInvitacion Then pvp_ud = 0
        If Me.swEntrada_Refresco Then pvp_ud = 0
        If Me.swEntrada_Copa Then pvp_ud = 0


        'Si es un articulo de pesaje y el modo compatibilidad es comercio
        If My.m_opt.modo_compatibilidad = "COMERCIO" AndAlso rst("swpesaje").Value Then
            If Not My.MyHardware.Balanza_Enabled OrElse My.MyHardware.Balanza_Port = "NINGUNO" Then
                My.m_msg.MessageError("No esta establecida ninguna configuración correcta de balanza PC.")
                Exit Sub
            End If

            Dim pvp As Double = 0

            frmPaneldeVentas_Pesaje.IdRef = id
            frmPaneldeVentas_Pesaje.ShowDialog(Me)
            If frmPaneldeVentas_Pesaje.DialogResult <> Windows.Forms.DialogResult.OK Then
                frmPaneldeVentas_Pesaje.Dispose()
                Exit Sub
            End If

            ud = frmPaneldeVentas_Pesaje.LblPeso.Text
            pvp = frmPaneldeVentas_Pesaje.LblPrecio.Text

            frmPaneldeVentas_Pesaje.Dispose()
            frmPaneldeVentas_Pesaje = Nothing

            'Establezco el item nuevo
            i = Me.LstLines.Items.Count
        Else
            '### Si combina >> Muestro el formulario de lineas
            If rst("combinable").Value AndAlso (idCombinaCon <= 0 AndAlso tipo = 0) Then
                With frmPaneldeVentas_Combina
                    .Id_CatRef = rst("id_categoria_combina").Value
                    .ShowDialog(Me)
                    If .DialogResult <> Windows.Forms.DialogResult.OK Then
                        .Dispose()
                        Exit Sub
                    End If
                    id_combina = .Id_Ref
                    If .Id_Ref > 0 Then
                        StrCombina = " + " & .StrName 'El nombre del articulo seleccionado
                        'Compruebo si incrementa el precio
                        Dim rstTMP As ADODB.Recordset = My.m_db.GetRst("SELECT id,swIncCombina,iva,pvp_IncCombina FROM db_articulos WHERE id=" & .Id_Ref)
                        If CBool(rstTMP("swIncCombina").Value) Then
                            pvp_inc = rstTMP("pvp_IncCombina").Value
                            pvp_inc_Base = Format(rstTMP("pvp_IncCombina").Value / CDbl("1," & Format(rstTMP("iva").Value, "00")), "0.00#")

                        End If
                        My.m_db.CloseRst(rstTMP)
                    End If
                    .Dispose()
                End With
            End If

            '### Compruebo si esta agregado ya (Excepto cuando es de pesaje)
            For i = 0 To Me.LstLines.Items.Count - 1
                If Me.LstLines.Items(i).SubItems(lst_Columns_Tickets.id_art).Text = id AndAlso _
                Me.LstLines.Items(i).SubItems(lst_Columns_Tickets.id_art_combina).Text = id_combina AndAlso _
                Me.LstLines.Items(i).SubItems(lst_Columns_Tickets.tipo).Text = tipo AndAlso _
                CDbl(Me.LstLines.Items(i).SubItems(lst_Columns_Tickets.pvp_ud).Text) = pvp_ud Then       'Si el articulo esta agregado
                    Me.LstLines.Items(i).SubItems(lst_Columns_Tickets.ud).Text += ud
                    Me.LstLines.Items(i).SubItems(lst_Columns_Tickets.total).Text = Format(CDbl(Me.LstLines.Items(i).SubItems(lst_Columns_Tickets.pvp_ud).Text) * Me.LstLines.Items(i).SubItems(lst_Columns_Tickets.ud).Text, "0.00#")

                    ' Selecciono la linea
                    Me.LstLines.SelectedItems.Clear()
                    Me.LstLines.Items(i).Selected = True
                    Me.LstLines.Items(i).Checked = True
                    Me.LstLines.EnsureVisible(i)
                    sw = True
                End If
            Next
        End If

        Dim strEntrada As String = ""
        If Me.swEntrada_Refresco Then
            strEntrada = "REFRESCO"
        ElseIf Me.swEntrada_Copa Then
            strEntrada = "COPA"
        End If


        If Not sw Then           'No esta agregado asi que lo agrego
            With Me.LstLines
                .Items.Add(0)
                .Items(i).SubItems.Add(id)
                .Items(i).SubItems.Add(id_combina)
                .Items(i).SubItems.Add(Format(ud, "0.###"))
                .Items(i).SubItems.Add(0)
                .Items(i).SubItems.Add(rst("name").Value & strTipo & StrCombina)              'Si no es combinado la cadena combina esta vacia
                .Items(i).SubItems.Add(Format(pvp_ud + pvp_inc, "0.00#"))
                .Items(i).SubItems.Add(Format(((pvp_ud + pvp_inc) * ud), "0.00#"))
                .Items(i).SubItems.Add(rst("swcomanda").Value)
                .Items(i).SubItems.Add(rst("id_categoria").Value)
                .Items(i).SubItems.Add(Format((rst("pvp").Value + pvp_inc_Base), "0.00###"))
                .Items(i).SubItems.Add(rst("iva").Value)
                .Items(i).SubItems.Add(rst("swpesaje").Value)
                .Items(i).SubItems.Add(tipo)
                .Items(i).SubItems.Add(strEntrada)
                .Items(i).SubItems.Add(Me._strTipoInvitacion)

                .Items(i).SubItems.Add(strObs)

                ' Quito los anteriores seleccionados y muestro el ultimo agregado
                .SelectedItems.Clear()
                .Items(i).Selected = True
                .EnsureVisible(i)
            End With
        End If

        'Cuando llega aqui es que se van a producir cambios
        Me.swChange = True

        ' Compongo el ultimo articulo nuevo agregado (obtengo imagen y muestro)
        Me.BtLastArticulo.Image = Nothing
        If rst("id_img").Value > 0 Then
            Dim RstAux As ADODB.Recordset = My.m_db.GetRst("SELECT img FROM app_imgs WHERE id=" & rst("id_img").Value)
            Me.BtLastArticulo.Image = My.m_db.data_GetImgRow(RstAux("img"))
            My.m_db.CloseRst(RstAux)
        End If

        Me.BtLastArticulo.Enabled = True
        Me.BtLastArticulo.Font = New System.Drawing.Font("Tahoma", 10.75!, System.Drawing.FontStyle.Bold)
        Me.BtLastArticulo.Text = "+" & Me.LstLines.SelectedItems(0).SubItems(lst_Columns_Tickets.ud).Text & vbCrLf & rst("name").Value & StrCombina
        Me.BtLastArticulo.Tag = rst("name").Value & StrCombina
        'Me.BtLastArticulo.Text = "Último Artículo Agregado" & vbCrLf & vbCrLf & vbCrLf & vbCrLf & vbCrLf & rst("name").Value & StrCombina
        Me.BtLastArticulo.TextAlign = ContentAlignment.BottomCenter

        Me._lastUse_id = id
        Me._lastUse_idCombina = id_combina


        My.m_db.CloseRst(rst)


        'Paso funciones de interconexion entre capas
        Me.CheckStateButtons()
        Me.Calcular_Totales()
    End Sub

    'Inicializacion del ticket
    Private Sub NuevoTicket(Optional ByVal notValidate As Boolean = False)
        ' Establezco valores por defecto y configuro para el nuevo Ticket
        Me._DblTotal = 0
        Me.LblInfo.Text = "[NUEVO PEDIDO]"
        Me.Tab.SelectedIndex = 0
        Me.swReload = False
        Me.LblNTicket.Visible = False
        Me.LstLines.Items.Clear()

        Me.LblHour.Text = Now.ToString("HH:mm")

        ReDim arrDelField(0)
        ReDim arrDelField_IdArt(0)
        ReDim arrDelField_IdArtCombina(0)
        ReDim arrDelField_Ud(0)

        If Me.swCajaDirecta Then Me.idRef = -1

        ' Limpio el ultimo artículado usado
        Me.BtLastArticulo.Text = "Último Artículo Agregado"
        Me.BtLastArticulo.TextAlign = ContentAlignment.MiddleCenter
        Me.BtLastArticulo.Enabled = False
        Me.BtLastArticulo.Image = Nothing
        Me._lastUse_id = 0
        Me._lastUse_idCombina = 0

        'Paso funciones de inicializacion
        Me.CheckStateButtons()
        Me.Calcular_Totales()

        Me._idCat = -2
        Me.Load_ArticulosPedidos()

        'Por si tengo k requerir especificacion del camarero para una nueva venta
        'If My.m_opt.cajadirecta AndAlso Not notValidate AndAlso (My.m_opt.cajadirecta_requeriridentificacion OrElse Me.idUser <> -1) Then
        If (My.m_opt.cajadirecta OrElse swCajaDirecta) AndAlso Not notValidate AndAlso (My.m_opt.cajadirecta_requeriridentificacion OrElse Me.idUser <> -1) Then
            Dim _id As Integer = -1
            'While _id = -1
            _id = My.ValidateUser()
            If _id = -1 Then
                Me.Close()
                Exit Sub
            End If

            Me.idUser = _id
            Me.LoadInfo_User()
            'End While
        End If

        Me.LstLines.Select()
    End Sub

    'Funcion para guardado y finalizacion con opciones
    Private Function CobroAvanzado() As Boolean

        'Muestro la pantalla de cobro
        frmPaneldeVentas_Cobra.Id_Ref = Me.idRef
        frmPaneldeVentas_Cobra.strTicket = Me.LblNTicket.Text
        frmPaneldeVentas_Cobra.DblTotal = Me._DblTotal
        frmPaneldeVentas_Cobra.ShowDialog()
        If frmPaneldeVentas_Cobra.DialogResult <> Windows.Forms.DialogResult.OK Then
            frmPaneldeVentas_Cobra.Dispose()
            Return False
        End If

        'Actualizo importes y agrego entradas si las tiene
        Me._DblTotal = frmPaneldeVentas_Cobra.DblTotal


        'Si es pago por tarjeta
        If frmPaneldeVentas_Cobra.swPagoTarjeta Then
            For i As Integer = 0 To Me.LstLines.Items.Count - 1
                Me.LstLines.Items(i).SubItems(lst_Columns_Tickets.pvp_ud).Text = 0

                Me.LstLines.Items(i).SubItems(lst_Columns_Tickets.total).Text = Format(CDbl(Me.LstLines.Items(0).SubItems(lst_Columns_Tickets.pvp_ud).Text) * Me.LstLines.Items(0).SubItems(lst_Columns_Tickets.ud).Text, "0.00")
                Me.LstLines.Items(i).SubItems(lst_Columns_Tickets.tipo_invitacion).Text = "TARJETA"

                Me.LstLines.Items(i).Checked = True
            Next
        End If

        Me.Calcular_Totales()

        'Guardo y Mato el Ticket
        Me.SaveTicket(True)

        'Actualizo si hay entradas
        If Val(frmPaneldeVentas_Cobra.lblEntrada_normal.Text) > 0 Then My.m_db.Execute("INSERT INTO db_cajas_entradas (id_caja,id_ticket,n,fh,tipo) VALUES(-1," & Me.idRef & "," & frmPaneldeVentas_Cobra.lblEntrada_normal.Text & ",'" & Format(Now, "dd/MM/yyyy HH:mm:ss") & "','NORMAL')")
        If Val(frmPaneldeVentas_Cobra.lblEntrada_especial.Text) > 0 Then My.m_db.Execute("INSERT INTO db_cajas_entradas (id_caja,id_ticket,n,fh,tipo) VALUES(-1," & Me.idRef & "," & frmPaneldeVentas_Cobra.lblEntrada_especial.Text & ",'" & Format(Now, "dd/MM/yyyy HH:mm:ss") & "','ESPECIAL')")

        Me.swKill = True

        'Imprimo el ticket
        If frmPaneldeVentas_Cobra.swPrintTicket Then
            Dim DblEntrega As Double = 0
            If IsNumeric(frmPaneldeVentas_Cobra.TxtEntrega.Text) Then DblEntrega = CDbl(frmPaneldeVentas_Cobra.TxtEntrega.Text)
            Me.PrintTicket(DblEntrega)
        Else
            My.OpenCajon()
        End If

        frmPaneldeVentas_Cobra.Dispose()

        'Actualizo los articulos mas usados



        'Finalizo el ticket


        Return True
    End Function

    'Funcion para Guardar el ticket
    Private Sub SaveTicket(Optional ByVal kill As Boolean = False)
        ' ### Nota: Deberia haber echo un INSERT INTO y un UPDATE SET, pero por vagueza en MICROSOFT JET hago un SELECT
        Dim i As Integer, swNew As Boolean = False
        Dim rst As ADODB.Recordset, rstPedido As ADODB.Recordset = Nothing, sql As String

        'BORRO y descuento los artículos eliminados
        For i = 1 To UBound(arrDelField)
            'Inserto el log
            rst = My.m_db.GetRst("SELECT * FROM db_tickets_lines where id=" & arrDelField(i))
            If rst.RecordCount > 0 Then My.m_db.Execute("INSERT INTO db_tickets_loglines (id_ticket,id_articulo,id_articulo_combina,concepto,name,ud,fh) VALUES(" & rst("id_ticket").Value & "," & rst("id_articulo").Value & "," & rst("id_articulo_combina").Value & ",'LINEA BORRADA','" & rst("name").Value & "'," & rst("ud").Value * -1 & ",'" & Format(Now, "HH:mm:ss") & "')")
            My.m_db.CloseRst(rst)

            My.m_db.Execute("DELETE FROM db_tickets_lines where id=" & arrDelField(i))
            If arrDelField_IdArt(i) > 0 Then
                If Me.idUser <> -3 Then My.UpdateAlmacen(arrDelField_IdArt(i), arrDelField_Ud(i) * -1, arrDelField_Tipo(i))
                If arrDelField_IdArtCombina(i) > 0 AndAlso Me.idUser <> -3 Then My.UpdateAlmacen(arrDelField_IdArtCombina(i), arrDelField_Ud(i) * -1)
            End If
        Next

        'GUARDO de una forma u otra dependiendo de si es nuevo o tengo que actualizar
        sql = "SELECT * FROM db_tickets WHERE id=" & Me.idRef
        rst = My.m_db.GetRst(sql)

        'Si es nuevo establezco valores de ticket
        If Me.idRef = -1 Then
            swNew = True

            rst.AddNew()
            rst("id_contable").Value = My.m_app.GetValue("id_contable", 1)
            rst("id_caja").Value = -1
            rst("n_ticket").Value = My.Get_Contador("TICKET")
            rst("estado").Value = "PENDIENTE"
            rst("fh_alta").Value = Now
            rst("id_pedido").Value = 0

        End If

        rst("id_referencia").Value = Me.idMesa
        rst("name_mesa").Value = Me.LblMesa.Text

        rst("id_user").Value = Me.idUser
        rst("fh_update").Value = Now
        rst("total").Value = CDbl(Format(Me._DblTotal, "0.00"))

        If kill Then
            rst("estado").Value = "FINALIZADO"
            rst("fh_finaliza").Value = Now
        Else
            Me.swReload = True
        End If
        rst.Update()

        'Genero el nuevo pedido
        rstPedido = My.m_db.GetRst("SELECT * FROM db_pedidos WHERE id=" & Me.idPedido)
        If Me.idRef = -1 Then
            rstPedido.AddNew()

            rstPedido("id_ticket").Value = rst("id").Value
            rstPedido("id_cliente").Value = Me.idCliente
            rstPedido("estado").Value = "PENDIENTE"
            rstPedido("tlf").Value = Me.lblPedido_Tlf.Text
            rstPedido("dir").Value = Me.lblPedido_Dir.Text
            rstPedido("dir_n").Value = Me.lblPedido_DirN.Text
            rstPedido("dir_bloque").Value = Me.lblPedido_DirBLoque.Text
            rstPedido("fh_alta").Value = Now

            rstPedido.Update()
        ElseIf kill Then
            rstPedido("estado").Value = "FINALIZADO"
            rstPedido("fh_finaliza").Value = Now
            rstPedido.Update()
        End If

        'Actualizo los datos del pedido
        rst("id_pedido").Value = rstPedido("id").Value
        rst.Update()

        Me.idRef = rst("id").Value
        My.m_db.CloseRst(rst)

        '### PROCESO LAS LINEAS
        'Guardo las lineas
        For i = 0 To Me.LstLines.Items.Count - 1
            If Me.LstLines.Items(i).Text = 0 Then               'Si es NUEVO
                sql = "INSERT INTO db_tickets_lines (id_ticket,id_articulo,id_articulo_combina,name,ud,pvp_base,iva,pvp_ud,total,swcomanda,tipo,entrada,tipo_invitacion,obs) "
                sql &= "VALUES (" & Me.idRef & ","
                sql &= Me.LstLines.Items(i).SubItems(lst_Columns_Tickets.id_art).Text & ","           'El id del articulo
                sql &= Me.LstLines.Items(i).SubItems(lst_Columns_Tickets.id_art_combina).Text & ","           'El id del articulo con el que ha combinado
                sql &= "'" & Me.LstLines.Items(i).SubItems(lst_Columns_Tickets.name).Text & "',"           'El nombre
                sql &= Me.LstLines.Items(i).SubItems(lst_Columns_Tickets.ud).Text.Replace(",", ".") & ","           'El id del articulo con el que ha combinado

                sql &= Me.LstLines.Items(i).SubItems(lst_Columns_Tickets.pvp_base).Text.Replace(",", ".") & ","           'La base imponible
                sql &= Me.LstLines.Items(i).SubItems(lst_Columns_Tickets.iva).Text.Replace(",", ".") & ","           'El iva del articulo
                sql &= Me.LstLines.Items(i).SubItems(lst_Columns_Tickets.pvp_ud).Text.Replace(",", ".") & ","           'El precio unitario
                sql &= Me.LstLines.Items(i).SubItems(lst_Columns_Tickets.total).Text.Replace(",", ".") & ","           'El precio total

                sql &= Me.LstLines.Items(i).SubItems(lst_Columns_Tickets.comanda).Text & ","             'Por si es comanda
                sql &= Me.LstLines.Items(i).SubItems(lst_Columns_Tickets.tipo).Text & ","  'El tipo de descuento de stock (PUTO TUTELA)
                sql &= "'" & Me.LstLines.Items(i).SubItems(lst_Columns_Tickets.entrada).Text & "',"
                sql &= "'" & Me.LstLines.Items(i).SubItems(lst_Columns_Tickets.tipo_invitacion).Text & "','"
                sql &= Me.LstLines.Items(i).SubItems(lst_Columns_Tickets.obs).Text.Replace("'", "") & "'"           'Los detalles
                sql &= ")"
                My.m_db.Execute(sql)

                'Actualizo el log de las lineas sino estoy finalizando el ticket y es nuevo
                If Not (swNew AndAlso kill) Then My.m_db.Execute("INSERT INTO db_tickets_loglines (id_ticket,id_articulo,id_articulo_combina,concepto,name,ud,fh) VALUES(" & Me.idRef & "," & Me.LstLines.Items(i).SubItems(lst_Columns_Tickets.id_art).Text & "," & Me.LstLines.Items(i).SubItems(lst_Columns_Tickets.id_art_combina).Text & ",'NUEVA LINEA','" & Me.LstLines.Items(i).SubItems(lst_Columns_Tickets.name).Text & "'," & Me.LstLines.Items(i).SubItems(lst_Columns_Tickets.ud).Text.Replace(",", ".") & ",'" & Format(Now, "HH:mm:ss") & "')")

                'Actualizo el stock y las unidades usadas si no es un articulo libre
                If Me.LstLines.Items(i).SubItems(lst_Columns_Tickets.id_art).Text > 0 Then
                    My.m_db.Execute("UPDATE db_articulos SET n_veces=n_veces+" & Replace(Me.LstLines.Items(i).SubItems(lst_Columns_Tickets.ud).Text, ",", ".") & " WHERE id=" & Me.LstLines.Items(i).SubItems(lst_Columns_Tickets.id_art).Text)

                    If Me.idUser <> -3 Then My.UpdateAlmacen(Me.LstLines.Items(i).SubItems(lst_Columns_Tickets.id_art).Text, Replace(Me.LstLines.Items(i).SubItems(lst_Columns_Tickets.ud).Text, ",", "."), Me.LstLines.Items(i).SubItems(lst_Columns_Tickets.tipo).Text)

                    ''Selecciono los detalles de almacen del articulo
                    'rst = My.m_db.GetRst("SELECT ud,tipo_ud,ud_fraccion,ud_fraccion_uso FROM db_articulos WHERE estocable=TRUE AND id=" & Me.LstLines.Items(i).SubItems(lst_Columns_Tickets.id_art).Text)
                    'If rst.RecordCount > 0 Then
                    '    If rst("tipo_ud").Value = "UNITARIO" Then
                    '        My.m_db.Execute("UPDATE db_articulos SET ud=ud-" & Replace(Me.LstLines.Items(i).SubItems(lst_Columns_Tickets.ud).Text, ",", ".") & " WHERE estocable=true and id=" & Me.LstLines.Items(i).SubItems(lst_Columns_Tickets.id_art).Text)
                    '    Else
                    '        rst("ud_fraccion_uso").Value += 1
                    '        If rst("ud_fraccion_uso").Value >= rst("ud_fraccion").Value Then
                    '            rst("ud_fraccion_uso").Value = 0
                    '            rst("ud_fraccion").Value -= 1
                    '        End If
                    '        rst.Update()
                    '    End If
                    'End If
                    'My.m_db.CloseRst(rst)


                    'Si ha combinado con otro articulo, descuento del stock
                    If Me.LstLines.Items(i).SubItems(lst_Columns_Tickets.id_art_combina).Text > 0 Then
                        My.m_db.Execute("UPDATE db_articulos SET n_veces=n_veces+" & Replace(Me.LstLines.Items(i).SubItems(lst_Columns_Tickets.ud).Text, ",", ".") & " WHERE id=" & Me.LstLines.Items(i).SubItems(lst_Columns_Tickets.id_art_combina).Text)
                        If Me.idUser <> -3 Then My.UpdateAlmacen(Me.LstLines.Items(i).SubItems(lst_Columns_Tickets.id_art_combina).Text, Replace(Me.LstLines.Items(i).SubItems(lst_Columns_Tickets.ud).Text, ",", "."))

                    End If
                End If

                If Me.LstLines.Items(i).SubItems(lst_Columns_Tickets.id_categoria).Text > 0 Then   'Vaya que sea un artículo libre
                    My.m_db.Execute("UPDATE db_categorias SET n_veces=n_veces+" & Replace(Me.LstLines.Items(i).SubItems(lst_Columns_Tickets.ud).Text, ",", ".") & " WHERE id=" & Me.LstLines.Items(i).SubItems(lst_Columns_Tickets.id_categoria).Text)
                End If

            ElseIf Me.LstLines.Items(i).Checked Then
                'Caso del EDITAR
                sql = "UPDATE db_tickets_lines SET "
                sql &= "ud=" & Replace(Me.LstLines.Items(i).SubItems(lst_Columns_Tickets.ud).Text, ",", ".")
                sql &= ",pvp_ud=" & Replace(Me.LstLines.Items(i).SubItems(lst_Columns_Tickets.pvp_ud).Text, ",", ".")
                sql &= ",total=" & Replace(Me.LstLines.Items(i).SubItems(lst_Columns_Tickets.total).Text, ",", ".")
                sql &= ",tipo_invitacion='" & Me.LstLines.Items(i).SubItems(lst_Columns_Tickets.tipo_invitacion).Text & "'"
                sql &= ",obs='" & Me.LstLines.Items(i).SubItems(lst_Columns_Tickets.obs).Text.Replace("'", "") & "'"
                sql &= " WHERE id=" & Me.LstLines.Items(i).Text
                My.m_db.Execute(sql)

                If Not (swNew AndAlso kill) Then My.m_db.Execute("INSERT INTO db_tickets_loglines (id_ticket,id_articulo,id_articulo_combina,concepto,name,ud,fh) VALUES(" & Me.idRef & "," & Me.LstLines.Items(i).SubItems(lst_Columns_Tickets.id_art).Text & "," & Me.LstLines.Items(i).SubItems(lst_Columns_Tickets.id_art_combina).Text & ",'ACTUALIZA LINEA','" & Me.LstLines.Items(i).SubItems(lst_Columns_Tickets.name).Text & "'," & Replace(CDbl(Me.LstLines.Items(i).SubItems(lst_Columns_Tickets.ud).Text) - CDbl(Me.LstLines.Items(i).SubItems(lst_Columns_Tickets.ud_original).Text), ",", ".") & ",'" & Format(Now, "HH:mm:ss") & "')")

                'Actualizo el almacen si es un articulo oficial
                If Me.LstLines.Items(i).SubItems(lst_Columns_Tickets.id_art).Text > 0 Then
                    My.m_db.Execute("UPDATE db_articulos SET n_veces=n_veces+" & (Me.LstLines.Items(i).SubItems(lst_Columns_Tickets.ud).Text - Me.LstLines.Items(i).SubItems(lst_Columns_Tickets.ud_original).Text) & " WHERE id=" & Me.LstLines.Items(i).SubItems(lst_Columns_Tickets.id_art).Text)

                    'My.m_db.Execute("UPDATE db_articulos SET ud=ud-" & Replace(CDbl(Me.LstLines.Items(i).SubItems(lst_Columns_Tickets.ud).Text) - CDbl(Me.LstLines.Items(i).SubItems(lst_Columns_Tickets.ud_original).Text), ",", ".") & " WHERE estocable=true and id=" & Me.LstLines.Items(i).SubItems(lst_Columns_Tickets.id_art).Text)

                    If Me.idUser <> -3 Then My.UpdateAlmacen(Me.LstLines.Items(i).SubItems(lst_Columns_Tickets.id_art).Text, Replace(CDbl(Me.LstLines.Items(i).SubItems(lst_Columns_Tickets.ud).Text) - CDbl(Me.LstLines.Items(i).SubItems(lst_Columns_Tickets.ud_original).Text), ",", "."), Me.LstLines.Items(i).SubItems(lst_Columns_Tickets.tipo).Text)
                    If Me.LstLines.Items(i).SubItems(lst_Columns_Tickets.id_art_combina).Text > 0 AndAlso Me.idUser <> -3 Then My.UpdateAlmacen(Me.LstLines.Items(i).SubItems(lst_Columns_Tickets.id_art_combina).Text, Replace(CDbl(Me.LstLines.Items(i).SubItems(lst_Columns_Tickets.ud).Text) - CDbl(Me.LstLines.Items(i).SubItems(lst_Columns_Tickets.ud_original).Text), ",", "."))
                End If
                If Me.LstLines.Items(i).SubItems(lst_Columns_Tickets.id_categoria).Text > 0 Then   'Vaya que sea un artículo libro
                    My.m_db.Execute("UPDATE db_categorias SET n_veces=n_veces+" & Replace(Me.LstLines.Items(i).SubItems(lst_Columns_Tickets.ud).Text, ",", ".") & " WHERE  id=" & Me.LstLines.Items(i).SubItems(lst_Columns_Tickets.id_categoria).Text)
                End If


            End If
        Next

        Me._Changes = False

    End Sub

    ' Cancelo el ticket
    Private Sub CancelaTicket()
        If Me.idRef = -1 Then Exit Sub

        'Actualizo el estado
        My.m_db.Execute("UPDATE db_tickets SET estado='CANCELADO',fh_finaliza=#" & Now & "#,id_user=" & Me.idUser & " WHERE id=" & Me.idRef)

        'Restauro el estocaje de articulos borrados
        Dim i As Integer
        For i = 1 To UBound(arrDelField)
            If arrDelField_IdArt(i) > 0 Then
                If Me.idUser <> -3 Then My.UpdateAlmacen(arrDelField_IdArt(i), arrDelField_Ud(i) * -1)
                If arrDelField_IdArtCombina(i) > 0 AndAlso Me.idUser <> -3 Then My.UpdateAlmacen(arrDelField_IdArtCombina(i), arrDelField_Ud(i) * -1, arrDelField_Tipo(i))
            End If
        Next

        'Restauro el estocaque de las lineas
        For i = 0 To Me.LstLines.Items.Count - 1
            If Me.LstLines.Items(i).SubItems(lst_Columns_Tickets.id_art).Text > 0 Then
                If Me.idUser <> -3 Then My.UpdateAlmacen(Me.LstLines.Items(i).SubItems(lst_Columns_Tickets.id_art).Text, Me.LstLines.Items(i).SubItems(lst_Columns_Tickets.ud_original).Text * -1, Me.LstLines.Items(i).SubItems(lst_Columns_Tickets.tipo).Text)
                If Me.LstLines.Items(i).SubItems(lst_Columns_Tickets.id_art_combina).Text > 0 AndAlso Me.idUser <> -3 Then My.UpdateAlmacen(Me.LstLines.Items(i).SubItems(lst_Columns_Tickets.id_art_combina).Text, Me.LstLines.Items(i).SubItems(lst_Columns_Tickets.ud_original).Text * -1)
            End If
        Next
    End Sub

    'Funcion para agregar un articulo libre
    Private Sub AddFreeArt()
        frmPaneldeVentas_ArticuloLibre.ShowDialog(Me)
        If frmPaneldeVentas_ArticuloLibre.DialogResult <> Windows.Forms.DialogResult.OK Then
            frmPaneldeVentas_ArticuloLibre.Dispose()
            Exit Sub
        End If
        For x As Integer = 0 To frmPaneldeVentas_ArticuloLibre.LstLines.Items.Count - 1
            Dim i As Integer = -1
            With Me.LstLines
                i = .Items.Count
                .Items.Add(0)
                .Items(i).SubItems.Add(-1)
                .Items(i).SubItems.Add(0)
                .Items(i).SubItems.Add(1)
                .Items(i).SubItems.Add(1)
                .Items(i).SubItems.Add(frmPaneldeVentas_ArticuloLibre.LstLines.Items(x).SubItems(1).Text)             'Si no es combinado la cadena combina esta vacia
                .Items(i).SubItems.Add(frmPaneldeVentas_ArticuloLibre.LstLines.Items(x).Text)
                .Items(i).SubItems.Add(frmPaneldeVentas_ArticuloLibre.LstLines.Items(x).Text)
                .Items(i).SubItems.Add(False)
                .Items(i).SubItems.Add(-1)
                .Items(i).SubItems.Add(Format(frmPaneldeVentas_ArticuloLibre.LstLines.Items(x).Text / My.m_opt.IVA_General, "0.00###"))         'Obtengo la base imponible
                .Items(i).SubItems.Add(My.m_opt.IVA_General)         'Obtengo la base imponible
                .Items(i).SubItems.Add(False)
                .Items(i).SubItems.Add(0)
                .Items(i).SubItems.Add("")
                .Items(i).SubItems.Add("")

                ' Quito los anteriores seleccionados y muestro el ultimo agregado
                .SelectedItems.Clear()
                .Items(i).Selected = True
                .EnsureVisible(i)
            End With
        Next
        frmPaneldeVentas_ArticuloLibre.Dispose()

        'Paso funciones de interconexion entre capas
        Me.CheckStateButtons()
        Me.Calcular_Totales()

    End Sub
#End Region

#Region "Carga de valores de Información"
    ' Funcion para cargar la info sobre el camarero
    Private Sub LoadInfo_User()
        If Me.idUser = -1 Then Exit Sub

        If Me.idUser = -3 Then
            Me.LblEmpleado.Text = "gDevBoy"
            Exit Sub
        End If

        On Error Resume Next
        'Cargo los datos del empleado
        Dim rst As ADODB.Recordset = My.m_db.GetRst("SELECT id,name,img,color FROM db_usuarios WHERE id=" & Me.idUser)
        Me.LblEmpleado.Text = rst("name").Value
        'Me.PicCamarero.BackColor = Color.FromArgb(rst("color").Value)
        Me.LblEmpleado.ForeColor = Color.FromArgb(rst("color").Value)
        My.m_db.CloseRst(rst)
    End Sub

    ' Funcion para cargar la infomación relativa al ticket
    Private Sub LoadInfo_Ticket()
        Me.LblNTicket.Visible = False
        If Me.idRef = -1 Then Exit Sub

        Dim i As Integer, rst As ADODB.Recordset = Nothing

        '### Cargo los datos del PEDIDO
        rst = My.m_db.GetRst("SELECT db_pedidos.*,db_clientes.name_fiscal FROM db_pedidos,db_clientes WHERE db_pedidos.id_cliente=db_clientes.id AND db_pedidos.id=" & Me.idPedido)
        If Not rst.EOF Then
            Me.lblPedido_Name.Text = rst("name_fiscal").Value
            Me.lblPedido_Tlf.Text = rst("tlf").Value
            Me.lblPedido_Dir.Text = rst("dir").Value
            Me.lblPedido_DirN.Text = rst("dir_n").Value
            Me.lblPedido_DirBLoque.Text = rst("dir_bloque").Value

            swPedidos = True
        Else
            Me.lblPedido_Name.Text = ""
            Me.lblPedido_Tlf.Text = ""
            Me.lblPedido_Dir.Text = ""
            Me.lblPedido_DirN.Text = ""
            Me.lblPedido_DirBLoque.Text = ""



            MsgBox("Pedido no localizado.", MsgBoxStyle.Critical)
        End If
        My.m_db.CloseRst(rst)


        '### Cargo los datos de CABECERA del Ticket
        rst = My.m_db.GetRst("SELECT * FROM db_tickets WHERE id=" & Me.idRef)
        Me.LblMesa.Text = rst("name_mesa").Value
        'Me.LblEmpleado.Text = rst("name").Value
        Me.LblIdFactura.Text = rst("id_factura").Value
        Me.LblNTicket.Text = rst("n_ticket").Value
        My.m_db.CloseRst(rst)

        '### Cargo las LINEAS
        i = 0
        Me.LstLines.Items.Clear()

        rst = My.m_db.GetRst("SELECT db_tickets_lines.*,db_articulos.id_categoria,db_articulos.swpesaje FROM db_tickets_lines,db_articulos WHERE db_articulos.id=db_tickets_lines.id_articulo AND id_ticket=" & Me.idRef)
        While Not rst.EOF
            With Me.LstLines
                .Items.Add(rst("id").Value)
                .Items(i).SubItems.Add(rst("id_articulo").Value)
                .Items(i).SubItems.Add(rst("id_articulo_combina").Value)
                .Items(i).SubItems.Add(rst("ud").Value)
                .Items(i).SubItems.Add(rst("ud").Value)
                .Items(i).SubItems.Add(rst("name").Value)              'Si no es combinado la cadena combina esta vacia
                .Items(i).SubItems.Add(Format(rst("pvp_ud").Value, "0.00#"))
                .Items(i).SubItems.Add(Format(rst("total").Value, "0.00#"))
                .Items(i).SubItems.Add(rst("swcomanda").Value)
                .Items(i).SubItems.Add(rst("id_categoria").Value)
                .Items(i).SubItems.Add(rst("pvp_base").Value)
                .Items(i).SubItems.Add(rst("iva").Value)
                .Items(i).SubItems.Add(rst("swpesaje").Value)
                .Items(i).SubItems.Add(rst("tipo").Value)
                .Items(i).SubItems.Add(rst("entrada").Value)
                .Items(i).SubItems.Add(rst("tipo_invitacion").Value)
                .Items(i).SubItems.Add(rst("obs").Value & "")

                ' Quito los anteriores seleccionados y muestro el ultimo agregado
                .SelectedItems.Clear()
                .Items(i).Selected = True
                .EnsureVisible(i)
            End With
            i += 1
            rst.MoveNext()
        End While
        My.m_db.CloseRst(rst)

        '### Cargo las LINEAS de los ARTICULOS LIBRE
        rst = My.m_db.GetRst("SELECT * FROM db_tickets_lines WHERE id_articulo=-1 AND id_ticket=" & Me.idRef)
        While Not rst.EOF
            With Me.LstLines
                .Items.Add(rst("id").Value)
                .Items(i).SubItems.Add(rst("id_articulo").Value)
                .Items(i).SubItems.Add(rst("id_articulo_combina").Value)
                .Items(i).SubItems.Add(rst("ud").Value)
                .Items(i).SubItems.Add(rst("ud").Value)
                .Items(i).SubItems.Add(rst("name").Value)              'Si no es combinado la cadena combina esta vacia
                .Items(i).SubItems.Add(Format(rst("pvp_ud").Value, "0.00#"))
                .Items(i).SubItems.Add(Format(rst("total").Value, "0.00#"))
                .Items(i).SubItems.Add(rst("swcomanda").Value)
                .Items(i).SubItems.Add(-1)
                .Items(i).SubItems.Add(rst("pvp_base").Value)
                .Items(i).SubItems.Add(rst("iva").Value)
                .Items(i).SubItems.Add(False)
                .Items(i).SubItems.Add(0)
                .Items(i).SubItems.Add("")
                .Items(i).SubItems.Add("")

                ' Quito los anteriores seleccionados y muestro el ultimo agregado
                .SelectedItems.Clear()
                .Items(i).Selected = True
                .EnsureVisible(i)
            End With
            i += 1
            rst.MoveNext()
        End While
        My.m_db.CloseRst(rst)

        'Paso funciones de interconexion entre capas
        Me.CheckStateButtons()
        Me.Calcular_Totales()

        'Establezco estados
        Me.BtTraspasar.Enabled = True
        Me.LblNTicket.Visible = True
        Me.swReload = True                                      'Haga lo que haga recargo valores luego
    End Sub

    Private Sub LoadInfo_Mesa()
        'No permito traspasar si desde caja directa
        Me.BtTraspasar.Visible = Me.idMesa > 0

        'Si es caja directa
        If Me.idMesa = -1 Then
            Me.LblMesa.Text = "CAJA DIRECTA"
            Exit Sub
        End If

        'Si es reparto a domicilio
        If Me.idMesa = -2 Then
            Me.LblMesa.Text = "REPARTO A DOMICILIO"
            Exit Sub
        End If

        'Si es nuevo cargo el nombre de la mesa
        If Me.idRef > 0 Then Exit Sub

        'Cargo los datos sobra la mesa
        Dim rst As ADODB.Recordset = My.m_db.GetRst("SELECT id,name FROM db_design WHERE id=" & Me.idMesa)
        Me.LblMesa.Text = rst("name").Value
        My.m_db.CloseRst(rst)
    End Sub
#End Region

#Region "Calculos"
    Private Sub Calcular_Totales()
        Dim i As Integer = 0
        Dim DblLastPVP As Double = Me._DblTotal
        Dim DblTotal As Double = 0

        For i = 0 To Me.LstLines.Items.Count - 1
            DblTotal += CDbl(Me.LstLines.Items(i).SubItems(lst_Columns_Tickets.total).Text)
        Next

        If DblLastPVP <> DblTotal Then           'Si se ha modificado el precio muestro el aviso
            Me.TmrAvisoPvp.Enabled = True
            Me.LblTotal.BackColor = Color.FromArgb(255, 128, 128)
            Me.PnlPVP.BackColor = Color.FromArgb(255, 128, 128)
            Me.LblTotal.Font = New Font("Tahoma", 20.0!, FontStyle.Bold)
        End If

        'Establezco estados
        Dim sw As Boolean = Not (Me.LstLines.Items.Count = 0)
        Me.BtCobrar.Enabled = sw
        Me.BtNewTicket.Enabled = sw
        Me.BtPrint.Enabled = sw
        Me.BtFactTicket.Enabled = sw AndAlso Me.idMesa <> -1

        Me.BtSave.Visible = ((Me.idRef > 0 AndAlso Me.LstLines.Items.Count = 0) OrElse (sw AndAlso Me.idMesa <> -1))
        If Me.swFinalizado Then Me.BtSave.Visible = False 'Si esta finalizado, no permito guardar, solo cobro
        Me.BtCobroDirecto.Visible = sw And Me.idRef > 0

        '
        Me.BtCancelaTicket.Enabled = (Me.idRef > 0 OrElse Me.LstLines.Items.Count > 0) AndAlso sw
        Me.BtHistory.Enabled = Me.BtCancelaTicket.Enabled
        Me.BtCobroParcial.Enabled = Me.BtCancelaTicket.Enabled

        _DblTotal = DblTotal
        Me.LblTotal.Text = Format(DblTotal, "##0.00") & " " & System.Threading.Thread.CurrentThread.CurrentCulture.NumberFormat.CurrencySymbol
    End Sub
#End Region

#Region "Impresión del Ticket"
    'Tener en cuenta que existe un duplicado de la función en app/appApoyo.vb
    Public Sub PrintTicket(ByVal DblEntrega As Double, Optional ByVal OpenCajon As Boolean = True)
        If My.MyHardware.IdPort = 0 Then Exit Sub

        Dim StrAux As String, i As Integer, StrCod As String, j As Integer
        Dim DblDto_Linea As Double = 0
        'Primero abro el cajon
        If OpenCajon Then My.OpenCajon()

        If My.MyHardware.PortName.Substring(0, 3) = "COM" Then
            '### IMPRESIÓN POR PUERTO SERIE
            Try
                Dim _port As IO.Ports.SerialPort
                _port = New IO.Ports.SerialPort(My.MyHardware.PortName, 9600, IO.Ports.Parity.None, 8, IO.Ports.StopBits.One)
                _port.DiscardNull = True
                _port.WriteBufferSize = 2024
                _port.DtrEnable = True
                _port.Handshake = IO.Ports.Handshake.None

                _port.Open()

                If My.MyHardware.CodEsc_Init.Length > 0 Then _port.Write(My.MyHardware.CodEsc_Init & My.MyHardware.CodEsc_Cr)
                StrCod = ""
                'Imprimo la cabezera
                For i = 1 To 4
                    StrAux = My.MyHardware.StrCab(i)
                    StrCod = ""
                    If StrAux.Length > My.MyHardware.Ancho Then StrAux = StrAux.Substring(1, My.MyHardware.Ancho)
                    StrCod = My.Ticket_ConfigTextColor(StrCod, My.MyHardware.SwRed(i))
                    StrCod = My.Ticket_ConfigTextStrong(StrCod, My.MyHardware.SwNegrita(i))
                    StrCod = My.Ticket_ConfigTextSize(StrCod, My.MyHardware.SwGrande(i))
                    StrAux = My.Ticket_ConfigTextAling(StrAux, IIf(My.MyHardware.SwCenter(i), 2, 0), My.MyHardware.SwGrande(i))
                    If My.MyHardware.StrCab(i).Length <> 0 Then _port.Write(StrCod & StrAux & My.MyHardware.CodEsc_Cr)
                Next
                _port.Write(My.MyHardware.CodEsc_Cr)
                _port.Close()
                _port.Open()


                'Imprimo info sobre el ticket
                StrAux = My.MyHardware.CodEsc_TextNormal & "Ref.: " & Format(Me.idRef, "000000")
                'StrAux &= Space(My.MyHardware.Ancho - StrAux.Length - Me.LblFh_Alta.Text.Length) & Me.LblFh_Alta.Text
                _port.Write(StrAux & My.MyHardware.CodEsc_Cr)
                _port.Close()
                _port.Open()

                Select Case My.m_opt.modo_compatibilidad
                    Case "COMERCIO"
                        StrAux = My.MyHardware.CodEsc_TextNormal & "Servicio: " & Me.LblMesa.Text
                        _port.Write(StrAux & My.MyHardware.CodEsc_Cr)

                        _port.Write(" " & My.MyHardware.CodEsc_Cr)
                    Case Else
                        'If DateDiff(DateInterval.Minute, CDate(Me.LblFh_Alta.Text), Now) > 1 Then
                        '    StrAux = My.MyHardware.CodEsc_TextNormal & "Hora: " & Format(Now, "dd/MM/yyyy HH:mm")
                        '    _port.Write(StrAux & My.MyHardware.CodEsc_Cr)
                        'End If
                        StrAux = My.MyHardware.CodEsc_TextNormal & "Camarero: " & Me.LblEmpleado.Text
                        _port.Write(StrAux & My.MyHardware.CodEsc_Cr)
                        StrAux = My.MyHardware.CodEsc_TextNormal & "Mesa: " & Me.LblMesa.Text
                        _port.Write(StrAux & My.MyHardware.CodEsc_Cr)

                        _port.Write(" " & My.MyHardware.CodEsc_Cr)
                End Select

                Select Case My.m_opt.modo_compatibilidad
                    Case "COMERCIO"
                        StrAux = " " & My.MyHardware.CodEsc_Subrayado_True & "Concepto" & My.MyHardware.CodEsc_Subrayado_False
                        StrAux &= Space(My.MyHardware.Ancho - 29) & My.MyHardware.CodEsc_Subrayado_True & "Precio" & My.MyHardware.CodEsc_Subrayado_False
                        StrAux &= Space(2) & My.MyHardware.CodEsc_Subrayado_True & "Cant." & My.MyHardware.CodEsc_Subrayado_False
                        StrAux &= Space(2) & My.MyHardware.CodEsc_Subrayado_True & "Total" & My.MyHardware.CodEsc_Subrayado_False
                        _port.Write(StrAux & My.MyHardware.CodEsc_Cr)
                        _port.Close()
                        _port.Open()
                    Case Else
                        StrAux = " " & My.MyHardware.CodEsc_Subrayado_True & "Articulo" & My.MyHardware.CodEsc_Subrayado_False
                        StrAux &= Space(My.MyHardware.Ancho - 20) & My.MyHardware.CodEsc_Subrayado_True & "Ud." & My.MyHardware.CodEsc_Subrayado_False
                        StrAux &= Space(2) & My.MyHardware.CodEsc_Subrayado_True & "Total" & My.MyHardware.CodEsc_Subrayado_False
                        _port.Write(StrAux & My.MyHardware.CodEsc_Cr)
                        _port.Close()
                        _port.Open()
                End Select

                For i = 0 To Me.LstLines.Items.Count - 1
                    Select Case My.m_opt.modo_compatibilidad
                        Case "COMERCIO"
                            StrAux = " " & Me.LstLines.Items(i).SubItems(lst_Columns_Tickets.name).Text.Replace("Ñ", "N")
                            If StrAux.Length > My.MyHardware.Ancho - 22 Then StrAux = StrAux.Substring(0, My.MyHardware.Ancho - 22)
                            StrAux &= Space(My.MyHardware.Ancho - 20 - StrAux.Length)

                            StrAux &= Space(6 - Me.LstLines.Items(i).SubItems(lst_Columns_Tickets.pvp_ud).Text.Length) & Me.LstLines.Items(i).SubItems(lst_Columns_Tickets.pvp_ud).Text
                            StrAux &= Space(7 - Me.LstLines.Items(i).SubItems(lst_Columns_Tickets.ud).Text.Length) & Me.LstLines.Items(i).SubItems(lst_Columns_Tickets.ud).Text

                            j = (6 - Format(CDbl(Me.LstLines.Items(i).SubItems(lst_Columns_Tickets.total).Text), "0.00").Length)
                            If j < 0 Then j = 0

                            StrAux &= " " & Space(j) & Format(CDbl(Me.LstLines.Items(i).SubItems(lst_Columns_Tickets.total).Text), "0.00")
                            _port.Write(My.FixCHARISO(StrAux) & My.MyHardware.CodEsc_Cr)

                        Case Else
                            StrAux = " " & Me.LstLines.Items(i).SubItems(lst_Columns_Tickets.name).Text.Replace("Ñ", "N")
                            If StrAux.Length > My.MyHardware.Ancho - 13 Then StrAux = StrAux.Substring(0, My.MyHardware.Ancho - 13)
                            StrAux &= Space(My.MyHardware.Ancho - 11 - StrAux.Length)
                            StrAux &= Space(3 - Me.LstLines.Items(i).SubItems(lst_Columns_Tickets.ud).Text.Length) & Me.LstLines.Items(i).SubItems(lst_Columns_Tickets.ud).Text

                            j = (6 - Me.LstLines.Items(i).SubItems(lst_Columns_Tickets.total).Text.Length)
                            If j < 0 Then j = 0

                            StrAux &= " " & Space(j) & Me.LstLines.Items(i).SubItems(lst_Columns_Tickets.total).Text
                            _port.Write(My.FixCHARISO(StrAux) & My.MyHardware.CodEsc_Cr)
                    End Select
                    _port.Close()
                    _port.Open()
                Next

                StrAux = My.MyHardware.CodEsc_TextNormal & " " & My.MyHardware.CodEsc_Subrayado_True & Space(My.MyHardware.Ancho - 2) & My.MyHardware.CodEsc_Subrayado_False
                _port.Write(StrAux & My.MyHardware.CodEsc_Cr)

                i = (6 - Me.LblTotal.Text.Length)
                If i < 0 Then i = 0

                StrAux = My.MyHardware.CodEsc_Rojo & Space(My.MyHardware.Ancho - 11) & My.MyHardware.CodEsc_TextGrande & My.MyHardware.CodEsc_Negrita_True & Space(i) & Me.LblTotal.Text.Replace("€", "E") & My.MyHardware.CodEsc_Negrita_False & My.MyHardware.CodEsc_TextNormal
                _port.Write(StrAux & My.MyHardware.CodEsc_Cr)
                _port.Close()
                _port.Open()


                If DblEntrega <> 0 Then          'He entregado algo
                    StrAux = "Entrega: " & Format(DblEntrega, "###0.00")
                    StrAux = Space(My.MyHardware.Ancho - StrAux.Length - 1) & StrAux
                    _port.Write(My.MyHardware.CodEsc_Negro & StrAux & My.MyHardware.CodEsc_Cr)

                    StrAux = "Cambio: " & Format(DblEntrega - CDbl(Me.LblTotal.Text), "###0.00")
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
                    StrCod = My.Ticket_ConfigTextColor(StrCod, My.MyHardware.SwRed(i))
                    StrCod = My.Ticket_ConfigTextStrong(StrCod, My.MyHardware.SwNegrita(i))
                    StrCod = My.Ticket_ConfigTextSize(StrCod, My.MyHardware.SwGrande(i))
                    StrAux = My.Ticket_ConfigTextAling(StrAux, IIf(My.MyHardware.SwCenter(i), 2, 0), My.MyHardware.SwGrande(i))
                    If StrAux.Length <> 0 Then _port.Write(StrCod & StrAux & My.MyHardware.CodEsc_Cr)
                Next
                _port.Write(My.MyHardware.CodEsc_Salto & My.MyHardware.CodEsc_Cr)
                If Len(My.MyHardware.CodEsc_Cut) > 0 Then _port.Write(My.MyHardware.CodEsc_Cut & My.MyHardware.CodEsc_Cr)
                _port.Close()
                _port.Dispose()
            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.Critical)
            End Try
        ElseIf My.MyHardware.PortName.Substring(0, 3) = "LPT" Then
            '### IMPRESIÓN POR PUERTO PARALELO
            Dim _port As m_Crypto.ioParerellPort
            _port = New m_Crypto.ioParerellPort("LPT" & My.MyHardware.IdPort)

            If My.MyHardware.CodEsc_Init.Length > 0 Then _port.Write(My.MyHardware.CodEsc_Init & My.MyHardware.CodEsc_Cr)
            StrCod = ""
            'Imprimo la cabezera
            For i = 1 To 4
                StrAux = My.MyHardware.StrCab(i)
                StrCod = ""
                If StrAux.Length > My.MyHardware.Ancho Then StrAux = StrAux.Substring(1, My.MyHardware.Ancho)
                StrCod = My.Ticket_ConfigTextColor(StrCod, My.MyHardware.SwRed(i))
                StrCod = My.Ticket_ConfigTextStrong(StrCod, My.MyHardware.SwNegrita(i))
                StrCod = My.Ticket_ConfigTextSize(StrCod, My.MyHardware.SwGrande(i))
                StrAux = My.Ticket_ConfigTextAling(StrAux, IIf(My.MyHardware.SwCenter(i), 2, 0), My.MyHardware.SwGrande(i))
                If My.MyHardware.StrCab(i).Length <> 0 Then _port.Write(StrCod & StrAux & My.MyHardware.CodEsc_Cr)
            Next
            _port.Write(My.MyHardware.CodEsc_Cr)

            'Imprimo info sobre el ticket
            StrAux = My.MyHardware.CodEsc_TextNormal & "Ref.: " & Format(Me.idRef, "000000")
            'StrAux &= Space(My.MyHardware.Ancho - StrAux.Length - Me.LblFh_Alta.Text.Length) & Me.LblFh_Alta.Text
            _port.Write(StrAux & My.MyHardware.CodEsc_Cr)

            Select Case My.m_opt.modo_compatibilidad
                Case "COMERCIO"
                    StrAux = My.MyHardware.CodEsc_TextNormal & "Servicio: " & Me.LblMesa.Text
                    _port.Write(StrAux & My.MyHardware.CodEsc_Cr)

                    _port.Write(" " & My.MyHardware.CodEsc_Cr)

                Case Else
                    'If DateDiff(DateInterval.Minute, CDate(Me.LblFh_Alta.Text), Now) > 1 Then
                    '    StrAux = My.MyHardware.CodEsc_TextNormal & "Hora: " & Format(Now, "dd/MM/yyyy HH:mm")
                    '    _port.Write(StrAux & My.MyHardware.CodEsc_Cr)
                    'End If
                    StrAux = My.MyHardware.CodEsc_TextNormal & "Camarero: " & Me.LblEmpleado.Text
                    _port.Write(StrAux & My.MyHardware.CodEsc_Cr)
                    StrAux = My.MyHardware.CodEsc_TextNormal & "Mesa: " & Me.LblMesa.Text
                    _port.Write(StrAux & My.MyHardware.CodEsc_Cr)

                    _port.Write(" " & My.MyHardware.CodEsc_Cr)
            End Select
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

            For i = 0 To Me.LstLines.Items.Count - 1
                Select Case My.m_opt.modo_compatibilidad
                    Case "COMERCIO"
                        StrAux = " " & Me.LstLines.Items(i).SubItems(lst_Columns_Tickets.name).Text.Replace("Ñ", "N")
                        If StrAux.Length > My.MyHardware.Ancho - 22 Then StrAux = StrAux.Substring(0, My.MyHardware.Ancho - 22)
                        StrAux &= Space(My.MyHardware.Ancho - 20 - StrAux.Length)

                        StrAux &= Space(6 - Me.LstLines.Items(i).SubItems(lst_Columns_Tickets.pvp_ud).Text.Length) & Me.LstLines.Items(i).SubItems(lst_Columns_Tickets.pvp_ud).Text
                        StrAux &= Space(7 - Me.LstLines.Items(i).SubItems(lst_Columns_Tickets.ud).Text.Length) & Me.LstLines.Items(i).SubItems(lst_Columns_Tickets.ud).Text

                        j = (6 - Format(CDbl(Me.LstLines.Items(i).SubItems(lst_Columns_Tickets.total).Text), "0.00").Length)
                        If j < 0 Then j = 0

                        StrAux &= " " & Space(j) & Format(CDbl(Me.LstLines.Items(i).SubItems(lst_Columns_Tickets.total).Text), "0.00")
                        _port.Write(My.FixCHARISO(StrAux) & My.MyHardware.CodEsc_Cr)

                    Case Else
                        StrAux = " " & Me.LstLines.Items(i).SubItems(lst_Columns_Tickets.name).Text.Replace("Ñ", "N")
                        If StrAux.Length > My.MyHardware.Ancho - 13 Then StrAux = StrAux.Substring(0, My.MyHardware.Ancho - 13)
                        StrAux &= Space(My.MyHardware.Ancho - 11 - StrAux.Length)
                        StrAux &= Space(3 - Me.LstLines.Items(i).SubItems(lst_Columns_Tickets.ud).Text.Length) & Me.LstLines.Items(i).SubItems(lst_Columns_Tickets.ud).Text

                        j = (6 - Me.LstLines.Items(i).SubItems(lst_Columns_Tickets.total).Text.Length)
                        If j < 0 Then j = 0

                        StrAux &= " " & Space(j) & Me.LstLines.Items(i).SubItems(lst_Columns_Tickets.total).Text
                        _port.Write(My.FixCHARISO(StrAux) & My.MyHardware.CodEsc_Cr)
                End Select
            Next


            StrAux = My.MyHardware.CodEsc_TextNormal & " " & My.MyHardware.CodEsc_Subrayado_True & Space(My.MyHardware.Ancho - 2) & My.MyHardware.CodEsc_Subrayado_False
            _port.Write(StrAux & My.MyHardware.CodEsc_Cr)

            i = (6 - Me.LblTotal.Text.Length)
            If i < 0 Then i = 0

            StrAux = My.MyHardware.CodEsc_Rojo & Space(My.MyHardware.Ancho - 11) & My.MyHardware.CodEsc_TextGrande & My.MyHardware.CodEsc_Negrita_True & Space(i) & Me.LblTotal.Text.Replace("€", "E") & My.MyHardware.CodEsc_Negrita_False & My.MyHardware.CodEsc_TextNormal
            _port.Write(StrAux & My.MyHardware.CodEsc_Cr)

            If DblEntrega <> 0 Then          'He entregado algo
                StrAux = "Entrega: " & Format(DblEntrega, "###0.00")
                StrAux = Space(My.MyHardware.Ancho - StrAux.Length - 1) & StrAux
                _port.Write(My.MyHardware.CodEsc_Negro & StrAux & My.MyHardware.CodEsc_Cr)

                StrAux = "Cambio: " & Format(DblEntrega - CDbl(Me.LblTotal.Text), "###0.00")
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
                StrCod = My.Ticket_ConfigTextColor(StrCod, My.MyHardware.SwRed(i))
                StrCod = My.Ticket_ConfigTextStrong(StrCod, My.MyHardware.SwNegrita(i))
                StrCod = My.Ticket_ConfigTextSize(StrCod, My.MyHardware.SwGrande(i))
                StrAux = My.Ticket_ConfigTextAling(StrAux, IIf(My.MyHardware.SwCenter(i), 2, 0), My.MyHardware.SwGrande(i))
                If StrAux.Length <> 0 Then _port.Write(StrCod & StrAux & My.MyHardware.CodEsc_Cr)
            Next
            _port.Write(My.MyHardware.CodEsc_Salto & My.MyHardware.CodEsc_Cr)
            If Len(My.MyHardware.CodEsc_Cut) > 0 Then _port.Write(My.MyHardware.CodEsc_Cut & My.MyHardware.CodEsc_Cr)
            _port.Dispose()

        Else
            '<!--### IMPRESIÓN POR LA IMPRESORA DE NOMBRE TICKETS ###-->
            Dim strPrinter As String = "tickets"

            If My.MyHardware.CodEsc_Init.Length > 0 Then My.RawPrinterHelper.SendStringToPrinter(strPrinter, My.MyHardware.CodEsc_Init & My.MyHardware.CodEsc_Cr)
            StrCod = ""
            'Imprimo la cabezera
            For i = 1 To 4
                StrAux = My.MyHardware.StrCab(i)
                StrCod = ""
                If StrAux.Length > My.MyHardware.Ancho Then StrAux = StrAux.Substring(1, My.MyHardware.Ancho)
                StrCod = My.Ticket_ConfigTextColor(StrCod, My.MyHardware.SwRed(i))
                StrCod = My.Ticket_ConfigTextStrong(StrCod, My.MyHardware.SwNegrita(i))
                StrCod = My.Ticket_ConfigTextSize(StrCod, My.MyHardware.SwGrande(i))
                StrAux = My.Ticket_ConfigTextAling(StrAux, IIf(My.MyHardware.SwCenter(i), 2, 0), My.MyHardware.SwGrande(i))
                If My.MyHardware.StrCab(i).Length <> 0 Then My.RawPrinterHelper.SendStringToPrinter(strPrinter, StrCod & StrAux & My.MyHardware.CodEsc_Cr)
            Next
            My.RawPrinterHelper.SendStringToPrinter(strPrinter, My.MyHardware.CodEsc_Cr)

            'Imprimo info sobre el ticket
            StrAux = My.MyHardware.CodEsc_TextNormal & "Ref.: " & Format(Me.idRef, "000000")
            'StrAux &= Space(My.MyHardware.Ancho - StrAux.Length - Me.LblFh_Alta.Text.Length) & Me.LblFh_Alta.Text
            My.RawPrinterHelper.SendStringToPrinter(strPrinter, StrAux & My.MyHardware.CodEsc_Cr)

            Select Case My.m_opt.modo_compatibilidad
                Case "COMERCIO"
                    StrAux = My.MyHardware.CodEsc_TextNormal & "Servicio: " & Me.LblMesa.Text
                    My.RawPrinterHelper.SendStringToPrinter(strPrinter, StrAux & My.MyHardware.CodEsc_Cr)

                    My.RawPrinterHelper.SendStringToPrinter(strPrinter, " " & My.MyHardware.CodEsc_Cr)

                Case Else
                    'If DateDiff(DateInterval.Minute, CDate(Me.LblFh_Alta.Text), Now) > 1 Then
                    '    StrAux = My.MyHardware.CodEsc_TextNormal & "Hora: " & Format(Now, "dd/MM/yyyy HH:mm")
                    '    My.RawPrinterHelper.SendStringToPrinter(strPrinter, StrAux & My.MyHardware.CodEsc_Cr)
                    'End If
                    StrAux = My.MyHardware.CodEsc_TextNormal & "Camarero: " & Me.LblEmpleado.Text
                    My.RawPrinterHelper.SendStringToPrinter(strPrinter, StrAux & My.MyHardware.CodEsc_Cr)
                    StrAux = My.MyHardware.CodEsc_TextNormal & "Mesa: " & Me.LblMesa.Text
                    My.RawPrinterHelper.SendStringToPrinter(strPrinter, StrAux & My.MyHardware.CodEsc_Cr)

                    My.RawPrinterHelper.SendStringToPrinter(strPrinter, " " & My.MyHardware.CodEsc_Cr)
            End Select
            Select Case My.m_opt.modo_compatibilidad
                Case "COMERCIO"
                    StrAux = " " & My.MyHardware.CodEsc_Subrayado_True & "Concepto" & My.MyHardware.CodEsc_Subrayado_False
                    StrAux &= Space(My.MyHardware.Ancho - 29) & My.MyHardware.CodEsc_Subrayado_True & "Precio" & My.MyHardware.CodEsc_Subrayado_False
                    StrAux &= Space(2) & My.MyHardware.CodEsc_Subrayado_True & "Cant." & My.MyHardware.CodEsc_Subrayado_False
                    StrAux &= Space(2) & My.MyHardware.CodEsc_Subrayado_True & "Total" & My.MyHardware.CodEsc_Subrayado_False
                    My.RawPrinterHelper.SendStringToPrinter(strPrinter, StrAux & My.MyHardware.CodEsc_Cr)

                Case Else
                    StrAux = " " & My.MyHardware.CodEsc_Subrayado_True & "Articulo" & My.MyHardware.CodEsc_Subrayado_False
                    StrAux &= Space(My.MyHardware.Ancho - 20) & My.MyHardware.CodEsc_Subrayado_True & "Ud." & My.MyHardware.CodEsc_Subrayado_False
                    StrAux &= Space(2) & My.MyHardware.CodEsc_Subrayado_True & "Total" & My.MyHardware.CodEsc_Subrayado_False
                    My.RawPrinterHelper.SendStringToPrinter(strPrinter, StrAux & My.MyHardware.CodEsc_Cr)
            End Select

            For i = 0 To Me.LstLines.Items.Count - 1
                Select Case My.m_opt.modo_compatibilidad
                    Case "COMERCIO"
                        StrAux = " " & Me.LstLines.Items(i).SubItems(lst_Columns_Tickets.name).Text.Replace("Ñ", "N")
                        If StrAux.Length > My.MyHardware.Ancho - 22 Then StrAux = StrAux.Substring(0, My.MyHardware.Ancho - 22)
                        StrAux &= Space(My.MyHardware.Ancho - 20 - StrAux.Length)

                        StrAux &= Space(6 - Me.LstLines.Items(i).SubItems(lst_Columns_Tickets.pvp_ud).Text.Length) & Me.LstLines.Items(i).SubItems(lst_Columns_Tickets.pvp_ud).Text
                        StrAux &= Space(7 - Me.LstLines.Items(i).SubItems(lst_Columns_Tickets.ud).Text.Length) & Me.LstLines.Items(i).SubItems(lst_Columns_Tickets.ud).Text

                        j = (6 - Format(CDbl(Me.LstLines.Items(i).SubItems(lst_Columns_Tickets.total).Text), "0.00").Length)
                        If j < 0 Then j = 0

                        StrAux &= " " & Space(j) & Format(CDbl(Me.LstLines.Items(i).SubItems(lst_Columns_Tickets.total).Text), "0.00")
                        My.RawPrinterHelper.SendStringToPrinter(strPrinter, My.FixCHARISO(StrAux) & My.MyHardware.CodEsc_Cr)

                    Case Else
                        StrAux = " " & Me.LstLines.Items(i).SubItems(lst_Columns_Tickets.name).Text.Replace("Ñ", "N")
                        If StrAux.Length > My.MyHardware.Ancho - 13 Then StrAux = StrAux.Substring(0, My.MyHardware.Ancho - 13)
                        StrAux &= Space(My.MyHardware.Ancho - 11 - StrAux.Length)
                        StrAux &= Space(3 - Me.LstLines.Items(i).SubItems(lst_Columns_Tickets.ud).Text.Length) & Me.LstLines.Items(i).SubItems(lst_Columns_Tickets.ud).Text

                        j = (6 - Me.LstLines.Items(i).SubItems(lst_Columns_Tickets.total).Text.Length)
                        If j < 0 Then j = 0

                        StrAux &= " " & Space(j) & Me.LstLines.Items(i).SubItems(lst_Columns_Tickets.total).Text
                        My.RawPrinterHelper.SendStringToPrinter(strPrinter, My.FixCHARISO(StrAux) & My.MyHardware.CodEsc_Cr)
                End Select
            Next


            StrAux = My.MyHardware.CodEsc_TextNormal & " " & My.MyHardware.CodEsc_Subrayado_True & Space(My.MyHardware.Ancho - 2) & My.MyHardware.CodEsc_Subrayado_False
            My.RawPrinterHelper.SendStringToPrinter(strPrinter, StrAux & My.MyHardware.CodEsc_Cr)

            i = (6 - Me.LblTotal.Text.Length)
            If i < 0 Then i = 0

            StrAux = My.MyHardware.CodEsc_Rojo & Space(My.MyHardware.Ancho - 11) & My.MyHardware.CodEsc_TextGrande & My.MyHardware.CodEsc_Negrita_True & Space(i) & Me.LblTotal.Text.Replace("€", "E") & My.MyHardware.CodEsc_Negrita_False & My.MyHardware.CodEsc_TextNormal
            My.RawPrinterHelper.SendStringToPrinter(strPrinter, StrAux & My.MyHardware.CodEsc_Cr)

            If DblEntrega <> 0 Then          'He entregado algo
                StrAux = "Entrega: " & Format(DblEntrega, "###0.00")
                StrAux = Space(My.MyHardware.Ancho - StrAux.Length - 1) & StrAux
                My.RawPrinterHelper.SendStringToPrinter(strPrinter, My.MyHardware.CodEsc_Negro & StrAux & My.MyHardware.CodEsc_Cr)

                StrAux = "Cambio: " & Format(DblEntrega - CDbl(Me.LblTotal.Text), "###0.00")
                StrAux = Space(My.MyHardware.Ancho - StrAux.Length - 1) & StrAux
                My.RawPrinterHelper.SendStringToPrinter(strPrinter, StrAux & My.MyHardware.CodEsc_Cr)
            End If


            StrAux = My.MyHardware.CodEsc_Negro & Space(My.MyHardware.Ancho - 14) & "(IVA INCLUIDO)"
            My.RawPrinterHelper.SendStringToPrinter(strPrinter, StrAux & My.MyHardware.CodEsc_Cr)

            My.RawPrinterHelper.SendStringToPrinter(strPrinter, My.MyHardware.CodEsc_Negro & My.MyHardware.CodEsc_Cr)

            'Imprimo las lineas
            For i = 5 To 8
                StrAux = My.MyHardware.StrCab(i)
                StrCod = ""
                If StrAux.Length > My.MyHardware.Ancho Then StrAux = StrAux.Substring(1, My.MyHardware.Ancho)
                StrCod = My.Ticket_ConfigTextColor(StrCod, My.MyHardware.SwRed(i))
                StrCod = My.Ticket_ConfigTextStrong(StrCod, My.MyHardware.SwNegrita(i))
                StrCod = My.Ticket_ConfigTextSize(StrCod, My.MyHardware.SwGrande(i))
                StrAux = My.Ticket_ConfigTextAling(StrAux, IIf(My.MyHardware.SwCenter(i), 2, 0), My.MyHardware.SwGrande(i))
                If StrAux.Length <> 0 Then My.RawPrinterHelper.SendStringToPrinter(strPrinter, StrCod & StrAux & My.MyHardware.CodEsc_Cr)
            Next
            My.RawPrinterHelper.SendStringToPrinter(strPrinter, My.MyHardware.CodEsc_Salto & My.MyHardware.CodEsc_Cr)
            If Len(My.MyHardware.CodEsc_Cut) > 0 Then My.RawPrinterHelper.SendStringToPrinter(strPrinter, My.MyHardware.CodEsc_Cut & My.MyHardware.CodEsc_Cr)

        End If
    End Sub

#End Region

#Region "Funciones Varias"
    'Cierre de la caja Actual con valores por defecto
    Private Sub CloseCajaActual()
        'Obtengo los detalles
        Dim rstTmp As ADODB.Recordset = My.m_db.GetRst("SELECT count(id) AS n_tot FROM db_tickets WHERE  estado<>'PENDIENTE' AND id_caja=-1")
        Dim nTot As Integer = rstTmp("n_tot").Value
        My.m_db.CloseRst(rstTmp)

        'Obtengo los totales
        rstTmp = My.m_db.GetRst("SELECT sum(total) as tot FROM db_tickets WHERE  estado='FINALIZADO' AND id_caja=-1")

        'Creo una nueva Caja
        Dim rst As ADODB.Recordset = My.m_db.GetRst("SELECT * FROM db_cajas WHERE id=-1")
        rst.AddNew()
        rst("id_contable").Value = My.m_app.GetValue("id_contable")
        rst("ncaja").Value = My.Get_Contador("CAJA")
        rst("fh_alta").Value = Now
        rst("n_tickets").Value = nTot
        rst("total").Value = CDbl(Format(rstTmp("tot").Value, "0.00"))           'El total ajustad
        rst("total_real").Value = rst("total").Value
        rst.Update()

        Dim idAux As Integer = rst("id").Value
        My.m_db.CloseRst(rst)
        My.m_db.CloseRst(rstTmp)

        'Actualizo valores de los tickets
        My.m_db.Execute("UPDATE db_tickets SET id_caja=" & idAux & " WHERE estado<>'PENDIENTE' AND id_caja=-1")
    End Sub

#End Region


    Private Sub ClickObs(ByVal sender As System.Object, ByVal e As System.EventArgs)

        frmPaneldeVentas_Obs.IdRef = CType(sender, Button).Tag
        frmPaneldeVentas_Obs.ShowDialog(Me)
        If frmPaneldeVentas_Obs.DialogResult <> Windows.Forms.DialogResult.OK Then
            frmPaneldeVentas_Obs.Dispose()
            Exit Sub
        End If


        Me.ProcesaClick(CType(sender, Button).Tag, 0, -2 + -Me.LstLines.Items.Count, frmPaneldeVentas_Obs.txtObs.Text)
        frmPaneldeVentas_Obs.Dispose()
    End Sub

    Private Sub ClickMoreOptions(ByVal sender As System.Object, ByVal e As System.EventArgs)
        frmPaneldeVentas_ValoraArt.IdRef = CType(sender, Button).Tag
        frmPaneldeVentas_ValoraArt.ShowDialog(Me)
        If frmPaneldeVentas_ValoraArt.DialogResult <> Windows.Forms.DialogResult.OK Then
            frmPaneldeVentas_ValoraArt.Dispose()
            Exit Sub
        End If

        Me.ProcesaClick(CType(sender, Button).Tag, 0, frmPaneldeVentas_ValoraArt.intTipo)
        frmPaneldeVentas_ValoraArt.Dispose()
    End Sub

    Private Sub LblHour_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LblHour.Click
        My.OpenCajon()
    End Sub

    Private Sub TabPedido_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TabPedido.SelectedIndexChanged
        If Me.TabPedido.SelectedTab Is Me.TabPage_Localizacion Then
            'Cargo la ubicación en google maps
            Dim str As String = "http://maps.google.es/maps?f=q&source=s_q&hl=es&geocode=&q=" & Me.lblPedido_Dir.Text.ToLower & ", " & My.m_opt.company_cp & "&z=16&amp;output=embed"

            'str = "<iframe width=""425"" height=""350"" frameborder=""0"" scrolling=""no"" marginheight=""0"" marginwidth=""0"" src=""https://maps.google.es/maps?q=" & Me.TxtDir.Text & ", " & My.m_opt.company_cp & ";hl=es&amp;ie=UTF8&amp;geocode=es&amp;hnear=" & My.m_opt.company_cp & "&amp;t=m&amp;hq=&amp;z=14&amp;output=embed""></iframe><br /><small></small>"
            Me.WebBrowser.Url = New System.Uri(str)
        End If
    End Sub

    Private Sub LstLines_MouseDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles LstLines.MouseDoubleClick
        frmPaneldeVentas_Obs.txtObs.Text = Me.LstLines.SelectedItems(0).SubItems(lst_Columns_Tickets.obs).Text.Replace("'", "")
        frmPaneldeVentas_Obs.ShowDialog(Me)
        If frmPaneldeVentas_Obs.DialogResult <> Windows.Forms.DialogResult.OK Then
            frmPaneldeVentas_Obs.Dispose()
            Exit Sub
        End If

        'Guardo los cambios de las observaciones
        Me.LstLines.SelectedItems(0).SubItems(lst_Columns_Tickets.obs).Text = frmPaneldeVentas_Obs.txtObs.Text
        Me.LstLines.SelectedItems(0).Checked = True
        Me.LstLines.Focus()
        Me.swChange = True

        frmPaneldeVentas_Obs.Dispose()
    End Sub
End Class