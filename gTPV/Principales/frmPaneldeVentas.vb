Public Class frmPaneldeVentas
    Public idRef As Integer = -1                 'El id de referencia del registro
    Public idMesa As Integer = -1              'La mesa que es
    Public idUser As Integer = -1               'El id de usuario actual

    Private _DblTotal As Double = 0.0

    Public swReload As Boolean = False             'Por si tengo que recargar los datos de la mesa en el formulario de Situacion
    Public swCajaDirecta As Boolean = False              'Indico si es caja directa
    Public swKill As Boolean = False                      'Para cuando he terminado el ticket
    Public swFinalizado As Boolean = False            'Si estoy editando un ticket terminado

    Public swChangeMesa As Boolean = False


    'Para los borrados
    Private arrDelField(0) As Integer
    Private arrDelField_IdArt(0) As Integer
    Private arrDelField_Tipo(0) As Integer
    Private arrDelField_IdArtCombina(0) As Integer
    Private arrDelField_Ud(0) As Integer

    Private arrDelField_Marca(0) As Integer

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
            'Selecciono el tipo de invitación, sino cancelo
            If value Then
                frmPaneldeVentas_Invitacion.ShowDialog()
                If frmPaneldeVentas_Invitacion.DialogResult <> Windows.Forms.DialogResult.OK Then
                    frmPaneldeVentas_Invitacion.Dispose()
                    Exit Property
                End If
                Me._strTipoInvitacion = frmPaneldeVentas_Invitacion.strTipoInvitacion
                frmPaneldeVentas_Invitacion.Dispose()
            Else
                Me._strTipoInvitacion = ""
            End If

            Me._swInvitacion = value
            Me.LblInvitación.Visible = value
            Me.BtAddInvitacion.Visible = value

            If value Then Me.Tab.SelectedTab = Me.TabPage_Ticket

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
            Case "DTO"
                frmPaneldeVentas_Dto.TxtPVP.Text = Format(CDbl(Me.lblDto.Tag), "0.00")
                frmPaneldeVentas_Dto.ShowDialog()
                If frmPaneldeVentas_Dto.DialogResult <> Windows.Forms.DialogResult.OK Then
                    frmPaneldeVentas_Dto.Dispose()
                    frmPaneldeVentas_Dto = Nothing
                    Exit Sub
                End If
                Dim dbl As Double = frmPaneldeVentas_Dto.TxtPVP.Text
                frmPaneldeVentas_Dto.Dispose()
                frmPaneldeVentas_Dto = Nothing


                Me.lblDto.Text = "Dto.: " & Format(dbl, "0.00") & " %"
                Me.lblDto.Tag = dbl
                Me.lblDto.Visible = (dbl <> 0)

                Me.Calcular_Totales()
                Me.swChange = True

            Case "TRASPASAR"
                frmPaneldeSituacion_Select.idRef = Me.idMesa
                frmPaneldeSituacion_Select.ShowDialog()
                If frmPaneldeSituacion_Select.DialogResult <> Windows.Forms.DialogResult.OK Then
                    frmPaneldeSituacion_Select.Dispose()
                    Exit Sub
                End If

                Me.idMesa = frmPaneldeSituacion_Select.idNew
                If Not frmPaneldeSituacion_Select.chkMantenerNombre.Checked Then
                    Dim rstMesa As ADODB.Recordset = My.m_db.GetRst("SELECT name FROM db_design WHERE id=" & frmPaneldeSituacion_Select.idNew)
                    Me.LblMesa.Text = rstMesa("name").Value
                    My.m_db.CloseRst(rstMesa)
                End If
                Me.swChangeMesa = True
                Me.swChange = True


                frmPaneldeSituacion_Select.Dispose()

            Case "INVITA_ALL"
                If MsgBox("¿Esta seguro de que desea dar todas las consumiciones por invitadas.?", MsgBoxStyle.OkCancel + MsgBoxStyle.Question, "Invitación") <> MsgBoxResult.Ok Then Exit Sub
                'Selecciono el tipo de invitación
                frmPaneldeVentas_Invitacion.ShowDialog()
                If frmPaneldeVentas_Invitacion.DialogResult <> Windows.Forms.DialogResult.OK Then
                    frmPaneldeVentas_Invitacion.Dispose()
                    Exit Sub
                End If
                Dim str As String = frmPaneldeVentas_Invitacion.strTipoInvitacion
                frmPaneldeVentas_Invitacion.Dispose()

                'Actualizo las lineas
                For i As Integer = 0 To Me.LstLines.Items.Count - 1
                    Me.LstLines.Items(i).SubItems(lst_Columns_Tickets.pvp_ud).Text = 0

                    Me.LstLines.Items(i).SubItems(lst_Columns_Tickets.total).Text = Format(CDbl(Me.LstLines.Items(0).SubItems(lst_Columns_Tickets.pvp_ud).Text) * Me.LstLines.Items(0).SubItems(lst_Columns_Tickets.ud).Text, "0.00")
                    Me.LstLines.Items(i).SubItems(lst_Columns_Tickets.tipo_invitacion).Text = str
                    'Me.LstLines.Items(i).SubItems(lst_Columns_Tickets.tipo_invitacion).Text = Me._strTipoInvitacion
                    Me.LstLines.Items(i).Checked = True
                Next

                Me.swChange = True
                Me.Calcular_Totales()

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
                'Guardo y Recargo valores
                Me.SaveTicket()
                Me.LoadInfo_Ticket()

                'Si no esta facturado, permito facturarlo
                If Val(Me.LblIdFactura.Text) <= 0 Then
                    'Muestro el formulario de facturar
                    frmPaneldeVentas_Facturar.IdRef = Me.idRef
                    frmPaneldeVentas_Facturar.ConfigureApp("facturar")
                    frmPaneldeVentas_Facturar.ShowDialog(Me)
                    If frmPaneldeVentas_Facturar.DialogResult = Windows.Forms.DialogResult.OK Then
                        'Actualizo los estados
                        Me.swKill = True
                        Me.DialogResult = Windows.Forms.DialogResult.OK
                    End If
                    frmPaneldeVentas_Facturar.Dispose()
                Else
                    'Muestro la factura
                    Dim FrmAux As New frmPreviewReport, StrSQL As String = ""
                    FrmAux.StrName = "Generar Factura"
                    FrmAux.StrSubName = "Generación de Facturas a Clientes"

                    'Compongo la sql
                    StrSQL &= IIf(StrSQL.Length > 0, " AND ", "") & " {app_empresa.id}=" & My.m_app.GetValue("id_empresa")
                    StrSQL &= IIf(StrSQL.Length > 0, " AND ", "") & " {db_facturas.id}=" & Me.LblIdFactura.Text


                    FrmAux.RptPrint = New crtFactura

                    FrmAux.StrSQL = StrSQL
                    FrmAux.ShowDialog(Me)
                End If


            Case "FINALIZA_TICKET"
                'Guardo y Mato el Ticket 
                Me.SaveTicket(True)
                My.OpenCajon()

                'Si es caja directa creo un nuevo ticket (siempre que no este editando un ticket finalizado)
                If Me.swCajaDirecta AndAlso Not Me.swFinalizado Then
                    'Muestro el precio del ultimo ticket
                    Me.PnlLastTicket.Visible = True
                    Me.LblLastPVP.Text = Me.LblTotal.Text
                    Me.LblLastRef.Text = Me.idRef
                    Me.LblLastEmpleado.Text = Me.LblEmpleado.Text

                    Me.LblCambio.Text = ""

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
                    Me.PnlLastTicket.Visible = False

                    Me.NuevoTicket()
                    Exit Select
                End If


                Me.swKill = True
                Me.DialogResult = Windows.Forms.DialogResult.OK


            Case "COBRAR_TICKET"
                If Not CobroAvanzado() Then Exit Select

                'Si es caja directa creo un nuevo ticket (Siempre que no este editando un ticket finalizado)
                If Me.swCajaDirecta AndAlso Not Me.swFinalizado Then
                    'Muestro el precio del ultimo ticket
                    Me.PnlLastTicket.Visible = True
                    Me.LblLastPVP.Text = Me.LblTotal.Text
                    Me.LblLastRef.Text = Me.idRef
                    Me.LblLastEmpleado.Text = Me.LblEmpleado.Text

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
                    ReDim Preserve arrDelField_Marca(UBound(arrDelField_Marca) + 1)

                    arrDelField(UBound(arrDelField)) = Me.LstLines.SelectedItems(0).SubItems(lst_Columns_Tickets.id).Text
                    arrDelField_IdArt(UBound(arrDelField_IdArt)) = Me.LstLines.SelectedItems(0).SubItems(lst_Columns_Tickets.id_art).Text
                    arrDelField_Tipo(UBound(arrDelField_Tipo)) = Me.LstLines.SelectedItems(0).SubItems(lst_Columns_Tickets.tipo).Text
                    arrDelField_IdArtCombina(UBound(arrDelField_IdArtCombina)) = Me.LstLines.SelectedItems(0).SubItems(lst_Columns_Tickets.id_art_combina).Text
                    arrDelField_Ud(UBound(arrDelField_Ud)) = Me.LstLines.SelectedItems(0).SubItems(lst_Columns_Tickets.ud_original).Text
                    arrDelField_Marca(UBound(arrDelField_Marca)) = Me.LstLines.SelectedItems(0).SubItems(lst_Columns_Tickets.id_tabaco).Text

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
                ElseIf Me.LstLines.SelectedItems(0).SubItems(lst_Columns_Tickets.id_art).Text = -2 Then
                    Me.ProcesaClick_Tabaco(Me.LstLines.SelectedItems(0).SubItems(lst_Columns_Tickets.id_tabaco).Text)
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
                        If MsgBox("¿Esta seguro desea salir del Panel de Ventas sin haber finalizado el ticket actual?", MsgBoxStyle.OkCancel + MsgBoxStyle.Question, My.APP_NAME) <> MsgBoxResult.Ok Then Exit Select
                    Else
                        'Por si deseo Guardar los posibles cambios realizados
                        Dim resp As DialogResult = MsgBox("¿Desea guardar los cambios que haya realizado sobre el Ticket Actual?", MsgBoxStyle.YesNoCancel + MsgBoxStyle.Question, My.APP_NAME)
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


        Me.LstLines.Focus()
    End Sub


    'Copruebo botones de estado
    Private Sub CheckStateButtons()
        Dim sw As Boolean = (Me.LstLines.Items.Count > 0)
        'Preservo acciones
        'Me.GroupActions.Enabled = sw
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

        Me.LstLines.Focus()
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

        Me.PnlLastTicket.Left = 0 ' = Me.BtCobroDirecto.Location

        If Me.idMesa = -1 OrElse Me.swFinalizado Then Me.BtCobroDirecto.Location = Me.BtSave.Location

        Me.BtCloseUserCaja.Enabled = My.m_opt.cajadirecta_closeuser



        Me.PnlBody.Visible = True

        Me.btEstancos.Visible = (My.m_opt.modo_compatibilidad = "ESTANCO")
        Me.pnlEstanco.Top = 25

        Me.pnlEstanco.Left = 0
        Me.pnlEstanco.Top = 0

        Me.pnlEstanco.Height = 650
        Me.pnlEstanco.Height = Me.PnlBody.Height

        Me.pnlEstanco.Width = 670


        Me.pnlLstArticulos.Left = 0
        Me.pnlLstArticulos.Top = 0

        Me.pnlLstArticulos.Height = 650
        Me.pnlLstArticulos.Height = Me.PnlBody.Height

        Me.pnlLstArticulos.Width = 670


        Me.load_HistoryMesa()


        Me.LblHour.Text = Now.ToString("HH:mm")
        Me.TmHour.Enabled = True
    End Sub


    ' Limpieza de objetos
    Private Sub frmPaneldeVentas_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
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
    Private Sub Buttons_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtClose.Click, BtPrint.Click, BtNewTicket.Click, BtDel_Line.Click, BtCobrar.Click, BtChangeUser.Click, BtN_Up.Click, BtN_Down.Click, BtSave.Click, BtFreeArt.Click, BtCobroDirecto.Click, BtCancelaTicket.Click, BtFactTicket.Click, BtAddReserva.Click, BtCloseUserCaja.Click, BtAsignaNombre.Click, BtHistory.Click, BtCobroParcial.Click, BtPesaje.Click, BtInvitación.Click, BtAddInvitacion.Click, Button6.Click, Button5.Click, BtTraspasar.Click, BtInvita_All.Click, Button7.Click
        'Si no tiene establecido el tag mando un error
        If IsNothing(CType(sender, Button).Tag) OrElse CType(sender, Button).Tag.ToString.Length = 0 Then
            My.m_msg.MessageError(sender, "Tag de control de elemento no referenciado")
            Exit Sub
        End If

        ShellApp(CType(sender, Button).Tag.ToString)

        Me.LstLines.Focus()
    End Sub

    'Vuelvo a agregar el ultimo articulo
    Private Sub BtLastArticulo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtLastArticulo.Click

        If Me.LstLines.SelectedItems.Count <= 0 Then Exit Sub

        frmPaneldeVentas_Num.lblName.Text = Me.BtLastArticulo.Tag
        frmPaneldeVentas_Num.TxtUD.Text = Me.LstLines.SelectedItems(0).SubItems(lst_Columns_Tickets.ud).Text
        frmPaneldeVentas_Num.ShowDialog(Me)
        If frmPaneldeVentas_Num.DialogResult <> Windows.Forms.DialogResult.OK Then
            frmPaneldeVentas_Num.Dispose()
            Exit Sub
        End If

        Dim ud As Double = 0

        If frmPaneldeVentas_Num.swAdd Then
            ud = Me.LstLines.SelectedItems(0).SubItems(lst_Columns_Tickets.ud).Text + CDbl(frmPaneldeVentas_Num.TxtUD.Text)
        Else
            ud = CDbl(frmPaneldeVentas_Num.TxtUD.Text)
        End If

        Me.LstLines.SelectedItems(0).Checked = True
        Me.LstLines.SelectedItems(0).SubItems(lst_Columns_Tickets.ud).Text = Format(ud, "0.##")
        Me.LstLines.SelectedItems(0).SubItems(lst_Columns_Tickets.total).Text = Format(CDbl(Me.LstLines.SelectedItems(0).SubItems(lst_Columns_Tickets.pvp_ud).Text) * Me.LstLines.SelectedItems(0).SubItems(lst_Columns_Tickets.ud).Text, "0.00")
        frmPaneldeVentas_Num.Dispose()

        'Se han producido cambios
        Me.swChange = True
        Me.Calcular_Totales()

        ''Muestro opciones sobre la linea
        'MsgBox("Muestro opcioens sobre la linea")
        Exit Sub

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

        Me.PnlPVP.BackColor = Me.LblNfo_Total.BackColor
        Me.LblTotal.BackColor = Me.LblNfo_Total.BackColor
        Me.LblTotal.Font = New Font("Tahoma", 24.0!, FontStyle.Bold)


        Me.BtLastArticulo.Font = New System.Drawing.Font("Tahoma", 6.75!, System.Drawing.FontStyle.Bold)
        Me.BtLastArticulo.Text = Me.BtLastArticulo.Tag

    End Sub

    Private Sub LstLines_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LstLines.SelectedIndexChanged

        'Me._lastUse_id = 0
        'Me._lastUse_idCombina = 0
        'Me._lastUse_idMarca = 0


        '' Compongo el ultimo articulo nuevo agregado (obtengo imagen y muestro)
        Me.BtLastArticulo.Image = Nothing
        Me.BtLastArticulo.Text = ""
        Me.BtLastArticulo.Tag = ""

        If Me.LstLines.SelectedItems.Count > 0 Then
            Dim rst As ADODB.Recordset = My.m_db.GetRst("SELECT id_img FROM db_articulos WHERE id=" & Me.LstLines.SelectedItems(0).SubItems(lst_Columns_Tickets.id_art).Text)

            If rst.RecordCount > 0 Then
                If rst("id_img").Value > 0 Then
                    Dim RstAux As ADODB.Recordset = My.m_db.GetRst("SELECT img FROM app_imgs WHERE id=" & rst("id_img").Value)
                    Me.BtLastArticulo.Image = My.m_db.data_GetImgRow(RstAux("img"))
                    My.m_db.CloseRst(RstAux)
                End If
            End If

            Me.BtLastArticulo.Enabled = True
            Me.BtLastArticulo.Text = Me.LstLines.SelectedItems(0).SubItems(lst_Columns_Tickets.name).Text
            Me.BtLastArticulo.Tag = Me.LstLines.SelectedItems(0).SubItems(lst_Columns_Tickets.name).Text
            ''Me.BtLastArticulo.Text = "Último Artículo Agregado" & vbCrLf & vbCrLf & vbCrLf & vbCrLf & vbCrLf & rst("name").Value & StrCombina
            'Me.BtLastArticulo.TextAlign = ContentAlignment.BottomCenter

        End If


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

    Private Sub BtPrintLastTicket_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtPrintLastTicket.Click
        My.PrintTicket(Me.LblLastRef.Text)
        Me.LstLines.Select()
    End Sub

    Private Sub BtEditTicket_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtEditTicket.Click
        Me.LstLines.Select()
        If MsgBox("¿Esta seguro de que desea de modificar el último ticket cobrado?", MsgBoxStyle.OkCancel + MsgBoxStyle.Question) <> MsgBoxResult.Ok Then Exit Sub

        'Err.Raise(21591, "Panel de Ventas", "Acción no procesable")

        'Configuro el panel de ventas
        With Me
            .idRef = Me.LblLastRef.Text
            .idMesa = -1
            .idUser = Me.idUser
            .swCajaDirecta = True

            '.swFinalizado = True

            'Cargo valores de informacion
            Me.LoadInfo_Ticket()
            Me.LoadInfo_User()
            Me.LoadInfo_Mesa()
        End With

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

        sql = "SELECT * FROM db_categorias WHERE swDescatalogada=FALSE "
        sql &= " ORDER BY n_veces DESC,name ASC"
        rst = My.m_db.GetRst(sql)


        '### Agrego los botones de las imagenes
        i = 0
        n = 1 'Total de categorias especiales

        'Primera categoria de la Pagina 1: Articulos mas usados
        If Me._cat_pag = 0 Then
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
            If Me._First_idCat = 0 Then
                Me._idCat = -1
                Me._First_idCat = rst("id").Value
            End If

        End If

        'CASO DE ESTANCO
        If Me._cat_pag = 0 AndAlso My.m_opt.modo_compatibilidad = "ESTANCO" Then
            n += 1
            ' Agrego el boton de tabaco
            Dim bt As Button
            bt = New Button
            bt.Font = New Font("Verdana", 10, FontStyle.Bold)
            'bt.Image = My.m_db.data_GetImgRow(rst("img"))
            bt.Margin = New Padding(0)
            bt.Name = n
            bt.Size = New Size(112, 109)
            bt.TabIndex = n
            bt.Location = New Point(_left + (bt.Width * i) + (4 * i), _top)
            bt.Text = "Estanco"
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
                Me._idCat = -1
                Me._First_idCat = rst("id").Value
            End If



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

        Me.LstLines.Focus()
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

        Me.LstLines.Focus()
    End Sub

    ' Muestro los articulos de una categoria
    Private Sub BtCatProductos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me._idCat = CStr(CType(sender, Button).Tag & "")

        Me._articulos_tot = 0
        Me._articulos_pag = 0

        Me._tabaco_tot = 0
        Me._tabaco_pag = 0

        Me._artTOP_tot = 0
        Me._artTOP_pag = 0

        Select Case Me._idCat
            Case -1                     'Categoria de Ultimos articulos usados
                Me.Load_ArticulosbyMostUsed()

            Case -2                     'Categoria de Tabacos
                Me.Load_ArticulosTabaco()

            Case Else
                Me.Load_ArticulosFromCat(CStr(CType(sender, Button).Tag & ""))
        End Select

        Me.LstLines.Focus()
    End Sub
#End Region

#Region "Articulos de Categoria"
    Private swArticulosCat As Boolean = False
    Private swArticulosTabaco As Boolean = False
    Private swArticulosTOP As Boolean = True

    Private _articulos_tot As Integer = 0
    Private _articulos_pag As Integer = 0

    'Funcion para cargar los articulos de una categoria real
    Private Sub Load_ArticulosFromCat(ByVal id_cat As Integer)
        Me.swArticulosCat = True
        Me.swArticulosTabaco = False
        Me.swArticulosTOP = False

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
                bt.ForeColor = Color.Black
                bt.BackColor = Color.FromName("control")

                If rst("id_img").Value = 0 Then            'Si no tiene imagen
                    bt.Text = rst("name").Value
                    bt.TextAlign = ContentAlignment.MiddleCenter

                    If rst("n_veces").Value > 0 Then
                        bt.Font = New Font("Verdana", 9, FontStyle.Bold)
                    Else
                        bt.Font = New Font("Times New Roman", 8, FontStyle.Regular)
                    End If

                    If Not IsDBNull(rst("color_letra")) Then
                        If IsNumeric(rst("color_letra").Value) Then bt.ForeColor = Color.FromArgb(rst("color_letra").Value)
                    End If

                    If Not IsDBNull(rst("color_fondo")) Then
                        If IsNumeric(rst("color_fondo").Value) Then
                            bt.BackColor = Color.FromArgb(rst("color_fondo").Value)
                            bt.UseVisualStyleBackColor = False
                        End If
                    End If
                Else
                    bt.Text = ""
                    bt.UseVisualStyleBackColor = True
                End If
                bt.Tag = rst("id").Value

                bt.UseMnemonic = False

                ' Asigno Eventos
                AddHandler bt.Click, AddressOf BtProcesaArticulo_Click
                AddHandler bt.MouseDown, AddressOf BtProcesaArticulo_MouseDown

                'Creo y configuro la etiqueta
                Dim lbl As Label
                lbl = New Label
                With lbl
                    .AutoSize = False
                    .BackColor = Color.Black

                    If rst("n_veces").Value > 0 Then
                        .Font = New Font("Arial", 6, FontStyle.Regular)
                    Else
                        .Font = New Font("Times New Roman", 6, FontStyle.Bold)
                    End If

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
                If Not My.m_opt.modo_seguro_secciones Then str &= vbCrLf & Space(7) & "Usos: " & IIf(rst("n_veces").Value = 0, "SIN USAR", rst("n_veces").Value & " usos")
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


    Private _artTOP_tot As Integer = 0
    Private _artTOP_pag As Integer = 0

    'Funcion para obtener los articulos mas usados
    Private Sub Load_ArticulosbyMostUsed()
        Me.swArticulosCat = False
        Me.swArticulosTabaco = False
        Me.swArticulosTOP = True

        'Variables Auxiliares e Inicializacion
        Dim i As Integer = 0, j As Integer = 0, n As Integer = 0
        Dim rst As ADODB.Recordset = Nothing
        Dim sql As String = "", str As String = ""

        Me.PnlArticulos.Visible = False
        Me.PnlArticulos.SuspendLayout()

        Me.BtArticulos_Prev.Enabled = False
        Me.BtArticulos_Next.Enabled = False

        Me.LblNofM.Text = "" '"Mostrando los #20 Artículos mas usados"
        Me.LblNameCat.Text = "Mostrando los Artículos mas usados"

        Me.BtArticulos_Prev.Enabled = (Me._artTOP_pag > 0)
        Me.BtArticulos_Next.Enabled = False


        '### Paginacion
        sql = "SELECT count(db_articulos.id) as tot FROM db_articulos"
        'sql &= " WHERE 1=1 ORDER BY n_veces DESC,name ASC"
        rst = My.m_db.GetRst(sql)
        Me._artTOP_tot = rst("tot").Value
        My.m_db.CloseRst(rst)

        Me.LblNofM.Text = "Mostrando " & Me._artTOP_tot & " artículos en página " & (Me._artTOP_pag + 1) & " de " & Format((Me._artTOP_tot / (_x * _y)) + 1, "0") & " páginas"

        '### Limpio anteriores controltes
        For i = Me.PnlArticulos.Controls.Count - 1 To 2 Step -1
            Me.PnlArticulos.Controls(i).Dispose()
        Next

        ''### Obtengo las articulos de la categoria seleccionada
        sql = "SELECT db_articulos.*,app_imgs.img FROM db_articulos LEFT JOIN app_imgs"
        sql &= " ON db_articulos.id_img=app_imgs.id "
        sql &= " WHERE db_articulos.swNotDisplay=FALSE"
        sql &= " ORDER BY db_articulos.n_veces DESC,db_articulos.name ASC"
        rst = My.m_db.GetRst(sql)


        '### Agrego los botones de las imagenes
        i = 0
        While Not rst.EOF
            If (n >= (Me._artTOP_pag * (_x * _y))) Then
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
                bt.ForeColor = Color.Black
                bt.BackColor = Color.FromName("control")

                If rst("id_img").Value = 0 Then            'Si no tiene imagen
                    bt.Text = rst("name").Value
                    bt.TextAlign = ContentAlignment.MiddleCenter


                    If rst("n_veces").Value > 0 Then
                        bt.Font = New Font("Verdana", 9, FontStyle.Bold)
                    Else
                        bt.Font = New Font("Times New Roman", 8, FontStyle.Regular)
                    End If

                    If Not IsDBNull(rst("color_letra")) Then
                        If IsNumeric(rst("color_letra").Value) Then bt.ForeColor = Color.FromArgb(rst("color_letra").Value)
                    End If
                    If Not IsDBNull(rst("color_fondo")) Then
                        If IsNumeric(rst("color_fondo").Value) Then
                            bt.BackColor = Color.FromArgb(rst("color_fondo").Value)
                            bt.UseVisualStyleBackColor = False
                        End If
                    End If

                Else
                    bt.Text = ""
                    bt.UseVisualStyleBackColor = True
                End If
                bt.Tag = rst("id").Value
                bt.UseMnemonic = False

                ' Asigno Eventos
                AddHandler bt.Click, AddressOf BtProcesaArticulo_Click

                'Creo y configuro la etiqueta
                Dim lbl As Label
                lbl = New Label
                With lbl
                    .AutoSize = False
                    .BackColor = Color.Black

                    If rst("n_veces").Value > 0 Then
                        .Font = New Font("Arial", 6, FontStyle.Regular)
                    Else
                        .Font = New Font("Times New Roman", 6, FontStyle.Bold)
                    End If

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
                If Not My.m_opt.modo_seguro_secciones Then str &= vbCrLf & Space(7) & "Usos: " & IIf(rst("n_veces").Value = 0, "SIN USAR", rst("n_veces").Value & " usos")
                'str &= vbCrLf & Space(7) & "#" & Format(rst("n_veces").Value, "0")
                Me.ToolTip.SetToolTip(bt, str)

                i += 1
                If i = _x Then
                    i = 0
                    j += 1
                    If j >= _y Then
                        Me.BtArticulos_Next.Enabled = ((Me._artTOP_tot / (_x * _y)) > 1)
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

    ' Muestro opciones de agregar articulo
    Private Sub BtProcesaArticulo_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs)

    End Sub


    Private Sub BtArticulos_Move_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtArticulos_Prev.Click, BtArticulos_Next.Click
        If Me.swArticulosCat Then
            Select Case True
                Case sender Is Me.BtArticulos_Prev
                    Me._articulos_pag -= 1

                Case sender Is Me.BtArticulos_Next
                    Me._articulos_pag += 1
            End Select

            Me.Load_ArticulosFromCat(Me._idCat)

        End If
    End Sub

    Private Sub BtArticulosTOP_Move_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtArticulos_Prev.Click, BtArticulos_Next.Click
        If Me.swArticulosTOP Then
            Select Case True
                Case sender Is Me.BtArticulos_Prev
                    Me._artTOP_pag -= 1

                Case sender Is Me.BtArticulos_Next
                    Me._artTOP_pag += 1
            End Select

            Me.Load_ArticulosbyMostUsed()

        End If
    End Sub
#End Region

#Region "Tabaco"
    Private _tabaco_tot As Integer = 0
    Private _tabaco_pag As Integer = 0

    'Funcion para cargar los articulos de una categoria real
    Private Sub Load_ArticulosTabaco()
        Me.swArticulosCat = False
        Me.swArticulosTabaco = True
        Me.swArticulosTOP = False

        Me.PnlArticulos.Visible = False
        Me.PnlArticulos.SuspendLayout()

        'Variables Auxiliares
        Dim i As Integer = 0, j As Integer = 0, n As Integer
        Dim rst As ADODB.Recordset
        Dim sql As String, str As String = ""


        Me.LblNameCat.Text = "Marcas de Tabaco"


        Me.BtArticulos_Prev.Enabled = (Me._tabaco_pag > 0)
        Me.BtArticulos_Next.Enabled = False


        '### Paginacion
        sql = "SELECT count(id) as tot FROM estanco_marcas"
        'sql &= " WHERE 1=1"
        sql &= " WHERE activo=TRUE"
        rst = My.m_db.GetRst(sql)
        Me._tabaco_tot = rst("tot").Value
        My.m_db.CloseRst(rst)

        Me.LblNofM.Text = "Mostrando " & Me._tabaco_tot & " marcas en página " & (Me._tabaco_pag + 1) & " de " & Format((Me._tabaco_tot / (_x * _y)) + 1, "0") & " páginas"

        '### Limpio anteriores controltes
        For i = Me.PnlArticulos.Controls.Count - 1 To 2 Step -1
            Me.PnlArticulos.Controls(i).Dispose()
        Next

        '### Obtengo las articulos del estanco
        sql = "SELECT *FROM estanco_marcas"
        'sql &= " WHERE 1=1"
        sql &= " WHERE activo=TRUE"
        sql &= " ORDER BY usos DESC, name ASC"
        rst = My.m_db.GetRst(sql)


        '### Agrego los botones de las imagenes
        i = 0
        While Not rst.EOF
            If (n >= (Me._tabaco_pag * (_x * _y))) Then
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
                If IsDBNull(rst("img").Value) Then            'Si no tiene imagen
                    bt.Text = rst("name").Value
                    bt.TextAlign = ContentAlignment.MiddleCenter



                    If rst("usos").Value > 0 Then
                        bt.Font = New Font("Verdana", 9, FontStyle.Bold)
                    Else
                        bt.Font = New Font("Times New Roman", 8, FontStyle.Regular)
                    End If
                Else
                    bt.Text = ""
                End If
                bt.Tag = rst("id").Value
                bt.UseVisualStyleBackColor = True
                bt.UseMnemonic = False

                ' Asigno Eventos
                AddHandler bt.Click, AddressOf BtProcesaArticuloEstanco_Click
                'AddHandler bt.MouseDown, AddressOf BtProcesaArticulo_MouseDown

                'Creo y configuro la etiqueta
                Dim lbl As Label
                lbl = New Label
                With lbl
                    .AutoSize = False
                    .BackColor = Color.Black

                    If rst("usos").Value > 0 Then
                        .Font = New Font("Arial", 6, FontStyle.Regular)
                    Else
                        .Font = New Font("Times New Roman", 6, FontStyle.Bold)
                    End If

                    .ForeColor = Color.YellowGreen
                    .Location = New Point(_left + (bt.Width * i) + 8, _top + (bt.Height * j) + (bt.Height - 22))
                    .Size = New Size(96, 14)
                    .Text = rst("name").Value
                    .TextAlign = ContentAlignment.MiddleCenter
                    If IsDBNull(rst("img").Value) Then .Visible = False
                End With

                'Creo y configuro la etiqueta del Carton
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
                    AddHandler .Click, AddressOf ClickX10
                End With


                Me.PnlArticulos.Controls.Add(btOpt)
                btOpt.BringToFront()

                Me.PnlArticulos.Controls.Add(lbl)
                Me.PnlArticulos.Controls.Add(bt)

                bt.Visible = True


                'Extra info por el tooltip
                str = rst("name").Value
                str &= vbCrLf & Space(7) & "Precio: " & Format(rst("precio").Value, "0.00") & " " & System.Threading.Thread.CurrentThread.CurrentCulture.NumberFormat.CurrencySymbol
                If Not My.m_opt.modo_seguro_secciones Then str &= vbCrLf & Space(7) & "Usos: " & rst("usos").Value
                Me.ToolTip.SetToolTip(bt, str)

                i += 1
                If i = _x Then
                    i = 0
                    j += 1
                    If j >= _y Then
                        Me.BtArticulos_Next.Enabled = ((Me._tabaco_tot / (_x * _y)) > 1)
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
    Private Sub BtProcesaArticuloEstanco_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.ProcesaClick_Tabaco(CStr(CType(sender, Button).Tag & ""))
    End Sub


    Private Sub BtArticulosEstanco_Move_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtArticulos_Prev.Click, BtArticulos_Next.Click
        If Not Me.swArticulosTabaco Then Exit Sub
        Select Case True
            Case sender Is Me.BtArticulos_Prev
                Me._tabaco_pag -= 1

            Case sender Is Me.BtArticulos_Next
                Me._tabaco_pag += 1
        End Select

        Me.Load_ArticulosTabaco()
    End Sub
#End Region

#End Region

#Region "Ticket"
    'Private _lastindex As Integer = -1
    Private _lastUse_id As Integer = 0
    Private _lastUse_idCombina As Integer = 0
    Private _lastUse_idMarca As Integer = 0

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
        id_tabaco = 16
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
            .Add("id_tabaco", 0, HorizontalAlignment.Left)
        End With

        If My.m_opt.ticketAvanzado Then
            Me.LstLines.Columns(lst_Columns_Tickets.ud).Width = 50
            Me.LstLines.Columns(lst_Columns_Tickets.name).Width = 180
            Me.LstLines.Columns(lst_Columns_Tickets.total).Width = 0

            Me.LstLines.Font = New Font("Tahoma", 14.0!, FontStyle.Regular)

            'Me.GroupInfo.BackColor = Color.Maroon
        End If

        'Si es sabor comercio doy configuración especial
        If My.m_opt.modo_compatibilidad = "COMERCIO" Then
            'Me.LstLines.Columns(lst_Columns_Tickets.ud).Text = "Ud/Peso"
            Me.LstLines.Columns(lst_Columns_Tickets.ud).Width = 55
            Me.LstLines.Columns(lst_Columns_Tickets.name).Width = 130
            Me.LstLines.Columns(lst_Columns_Tickets.total).Width = 55
        End If
    End Sub

    'Función para agregar una linea al ticket
    Private Sub ProcesaClick(ByVal id As Integer, Optional ByVal idCombinaCon As Integer = 0, Optional ByVal tipo As Integer = 0)
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

            'If My.MyHardware.Balanza_tipo = 0 Then
            ud = frmPaneldeVentas_Pesaje.LblPeso.Text
            pvp = frmPaneldeVentas_Pesaje.LblPrecio.Text

            If My.MyHardware.Balanza_tipo = 1 Then
                pvp_ud = pvp
            End If

            'Else
            '    ud = 1
            '    pvp = CDbl(frmPaneldeVentas_Pesaje.LblImporte.Text)
            'End If



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
                If tipo <= 0 Then
                    .Items(i).SubItems.Add(Format((rst("pvp").Value + pvp_inc_Base), "0.00#####"))
                Else
                    .Items(i).SubItems.Add(Format(((Format(pvp_ud / CDbl("1," & Format(rst("iva").Value, "00")), "0.00#")) + pvp_inc_Base), "0.00#####"))
                End If

                .Items(i).SubItems.Add(rst("iva").Value)
                .Items(i).SubItems.Add(rst("swpesaje").Value)
                .Items(i).SubItems.Add(tipo)
                .Items(i).SubItems.Add(strEntrada)
                .Items(i).SubItems.Add(Me._strTipoInvitacion)
                .Items(i).SubItems.Add(0)

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
        Me._lastUse_idMarca = 0


        My.m_db.CloseRst(rst)


        'Paso funciones de interconexion entre capas
        Me.CheckStateButtons()
        Me.Calcular_Totales()
    End Sub

    'Inicializacion del ticket
    Private Sub NuevoTicket(Optional ByVal notValidate As Boolean = False)
        ' Establezco valores por defecto y configuro para el nuevo Ticket
        Me._DblTotal = 0
        Me.LblInfo.Text = "[NUEVO TICKET]"
        Me.LblFh_Alta.Text = Format(Now, "dd/MM/yyyy HH:mm")
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

        Me._idCat = -1
        Me.Load_ArticulosbyMostUsed()

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

        Me.LblCambio.Text = ""

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
        Me.SaveTicket(True, frmPaneldeVentas_Cobra.swPagoEfectivo, frmPaneldeVentas_Cobra.swNota)

        'Actualizo si hay entradas
        If Val(frmPaneldeVentas_Cobra.lblEntrada_normal.Text) > 0 Then My.m_db.Execute("INSERT INTO db_cajas_entradas (id_caja,id_ticket,n,fh,tipo) VALUES(-1," & Me.idRef & "," & frmPaneldeVentas_Cobra.lblEntrada_normal.Text & ",'" & Format(Now, "dd/MM/yyyy HH:mm:ss") & "','NORMAL')")
        If Val(frmPaneldeVentas_Cobra.lblEntrada_especial.Text) > 0 Then My.m_db.Execute("INSERT INTO db_cajas_entradas (id_caja,id_ticket,n,fh,tipo) VALUES(-1," & Me.idRef & "," & frmPaneldeVentas_Cobra.lblEntrada_especial.Text & ",'" & Format(Now, "dd/MM/yyyy HH:mm:ss") & "','ESPECIAL')")

        Me.swKill = True

        'Imprimo el ticket 
        If frmPaneldeVentas_Cobra.swPrintTicket Then
            Dim DblEntrega As Double = 0
            If IsNumeric(frmPaneldeVentas_Cobra.TxtEntrega.Text) Then DblEntrega = CDbl(frmPaneldeVentas_Cobra.TxtEntrega.Text)
            'Me.PrintTicket(DblEntrega)
            My.PrintTicket(Me.idRef, DblEntrega)
        Else
            My.OpenCajon()
        End If

        If IsNumeric(frmPaneldeVentas_Cobra.TxtEntrega.Text) AndAlso CDbl(frmPaneldeVentas_Cobra.TxtEntrega.Text) <> 0 Then Me.LblCambio.Text = frmPaneldeVentas_Cobra.LblCambio.Text & "€"

        frmPaneldeVentas_Cobra.Dispose()

        'Actualizo los articulos mas usados



        'Finalizo el ticket


        Return True
    End Function

    'Funcion para Guardar el ticket
    Private Sub SaveTicket(Optional ByVal kill As Boolean = False, Optional ByVal swPagoEfectivo As Boolean = True, Optional ByVal swNota As Boolean = False)
        ' ### Nota: Deberia haber echo un INSERT INTO y un UPDATE SET, pero por vagueza en MICROSOFT JET hago un SELECT
        Dim i As Integer, swNew As Boolean = False
        Dim rst As ADODB.Recordset, sql As String

        'BORRO y descuento los artículos eliminados
        For i = 1 To UBound(arrDelField)
            'Inserto el log
            rst = My.m_db.GetRst("SELECT * FROM db_tickets_lines where id=" & arrDelField(i))
            If rst.RecordCount > 0 Then
                My.m_db.Execute("INSERT INTO db_tickets_loglines (id_ticket,id_articulo,id_articulo_combina,concepto,name,ud,fh) VALUES(" & rst("id_ticket").Value & "," & rst("id_articulo").Value & "," & rst("id_articulo_combina").Value & ",'LINEA BORRADA','" & rst("name").Value & "'," & rst("ud").Value * -1 & ",'" & Format(Now, "HH:mm:ss") & "')")
            End If
            My.m_db.CloseRst(rst)

            My.m_db.Execute("DELETE FROM db_tickets_lines where id=" & arrDelField(i))
            If arrDelField_IdArt(i) > 0 Then

                If Me.idUser <> -3 Then My.UpdateAlmacen(arrDelField_IdArt(i), arrDelField_Ud(i) * -1, arrDelField_Tipo(i))
                If arrDelField_IdArtCombina(i) > 0 AndAlso Me.idUser <> -3 Then My.UpdateAlmacen(arrDelField_IdArtCombina(i), arrDelField_Ud(i) * -1)

            ElseIf arrDelField_IdArt(i) = -2 Then       'Actualizo stock de tabaco
                My.UpdateAlmacen_Tabaco(arrDelField_Marca(i), arrDelField_Ud(i) * -1)
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
            rst("id_pedido").Value = 0
            rst("n_ticket").Value = My.Get_Contador("TICKET")
            rst("estado").Value = "PENDIENTE"

            'Si no tiene mesa la fecha del ticket es la acual
            rst("fh_alta").Value = IIf(Me.idMesa = -1, Now, CDate(Me.LblFh_Alta.Text))
        End If

        rst("id_referencia").Value = Me.idMesa
        rst("name_mesa").Value = Me.LblMesa.Text

        rst("tipo").Value = swNota

        rst("id_user").Value = Me.idUser
        rst("fh_update").Value = Now
        rst("total").Value = CDbl(Format(Me._DblTotal, "0.00"))


        rst("dto").Value = CDbl(Me.lblDto.Tag)

        If kill Then
            rst("estado").Value = "FINALIZADO"
            rst("fh_finaliza").Value = Now
            rst("tipo_cobro").Value = IIf(swPagoEfectivo, "EFECTIVO", "TARJETA")
        Else
            Me.swReload = True
        End If
        rst.Update()

        Me.idRef = rst("id").Value
        My.m_db.CloseRst(rst)

        '### PROCESO LAS LINEAS
        'Guardo las lineas
        For i = 0 To Me.LstLines.Items.Count - 1
            If Me.LstLines.Items(i).Text = 0 Then               'Si es NUEVO
                sql = "INSERT INTO db_tickets_lines (id_ticket,id_articulo,id_articulo_combina,id_marca,name,ud,pvp_base,iva,pvp_ud,total,swcomanda,tipo,entrada,tipo_invitacion) "
                sql &= "VALUES (" & Me.idRef & ","
                sql &= Me.LstLines.Items(i).SubItems(lst_Columns_Tickets.id_art).Text & ","           'El id del articulo
                sql &= Me.LstLines.Items(i).SubItems(lst_Columns_Tickets.id_art_combina).Text & ","           'El id del articulo con el que ha combinado
                sql &= Me.LstLines.Items(i).SubItems(lst_Columns_Tickets.id_tabaco).Text & ","           'El id del articulo de la marca de tabaco
                sql &= "'" & Me.LstLines.Items(i).SubItems(lst_Columns_Tickets.name).Text & "',"           'El nombre
                sql &= Me.LstLines.Items(i).SubItems(lst_Columns_Tickets.ud).Text.Replace(",", ".") & ","           'El id del articulo con el que ha combinado

                sql &= Me.LstLines.Items(i).SubItems(lst_Columns_Tickets.pvp_base).Text.Replace(",", ".") & ","           'La base imponible
                sql &= Me.LstLines.Items(i).SubItems(lst_Columns_Tickets.iva).Text.Replace(",", ".") & ","           'El iva del articulo
                sql &= Me.LstLines.Items(i).SubItems(lst_Columns_Tickets.pvp_ud).Text.Replace(",", ".") & ","           'El precio unitario
                sql &= Me.LstLines.Items(i).SubItems(lst_Columns_Tickets.total).Text.Replace(",", ".") & ","           'El precio total

                sql &= Me.LstLines.Items(i).SubItems(lst_Columns_Tickets.comanda).Text & ","             'Por si es comanda
                sql &= Me.LstLines.Items(i).SubItems(lst_Columns_Tickets.tipo).Text & ","  'El tipo de descuento de stock (PUTO TUTELA)
                sql &= "'" & Me.LstLines.Items(i).SubItems(lst_Columns_Tickets.entrada).Text & "',"
                sql &= "'" & Me.LstLines.Items(i).SubItems(lst_Columns_Tickets.tipo_invitacion).Text & "'"
                sql &= ")"
                My.m_db.Execute(sql)

                'Actualizo el log de las lineas sino estoy finalizando el ticket y es nuevo
                If Not (swNew AndAlso kill) Then My.m_db.Execute("INSERT INTO db_tickets_loglines (id_ticket,id_articulo,id_articulo_combina,concepto,name,ud,fh) VALUES(" & Me.idRef & "," & Me.LstLines.Items(i).SubItems(lst_Columns_Tickets.id_art).Text & "," & Me.LstLines.Items(i).SubItems(lst_Columns_Tickets.id_art_combina).Text & ",'NUEVA LINEA','" & Me.LstLines.Items(i).SubItems(lst_Columns_Tickets.name).Text.Replace("'", "") & "'," & Me.LstLines.Items(i).SubItems(lst_Columns_Tickets.ud).Text.Replace(",", ".") & ",'" & Format(Now, "HH:mm:ss") & "')")

                'Actualizo el stock y las unidades usadas si no es un articulo libre
                If Me.LstLines.Items(i).SubItems(lst_Columns_Tickets.id_art).Text > 0 Then
                    My.m_db.Execute("UPDATE db_articulos SET n_veces=n_veces+" & Replace(Me.LstLines.Items(i).SubItems(lst_Columns_Tickets.ud).Text, ",", ".") & ",fh_last_venta='" & Format(Now, "dd/MM/yyyy HH:mm:ss") & "',imp_acum_venta=imp_acum_venta+" & Me.LstLines.Items(i).SubItems(lst_Columns_Tickets.total).Text.Replace(",", ".") & " WHERE id=" & Me.LstLines.Items(i).SubItems(lst_Columns_Tickets.id_art).Text)

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
                        My.m_db.Execute("UPDATE db_articulos SET n_veces=n_veces+" & Replace(Me.LstLines.Items(i).SubItems(lst_Columns_Tickets.ud).Text, ",", ".") & ",fh_last_venta='" & Format(Now, "dd/MM/yyyy HH:mm:ss") & "'  WHERE id=" & Me.LstLines.Items(i).SubItems(lst_Columns_Tickets.id_art_combina).Text)
                        If Me.idUser <> -3 Then My.UpdateAlmacen(Me.LstLines.Items(i).SubItems(lst_Columns_Tickets.id_art_combina).Text, Replace(Me.LstLines.Items(i).SubItems(lst_Columns_Tickets.ud).Text, ",", "."))

                    End If
                ElseIf Me.LstLines.Items(i).SubItems(lst_Columns_Tickets.id_art).Text = -2 Then
                    My.m_db.Execute("UPDATE estanco_marcas SET usos=usos+" & Replace(Me.LstLines.Items(i).SubItems(lst_Columns_Tickets.ud).Text, ",", ".") & " WHERE id=" & Me.LstLines.Items(i).SubItems(lst_Columns_Tickets.id_tabaco).Text)

                    My.UpdateAlmacen_Tabaco(Me.LstLines.Items(i).SubItems(lst_Columns_Tickets.id_tabaco).Text, Replace(Me.LstLines.Items(i).SubItems(lst_Columns_Tickets.ud).Text, ",", "."))
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
                sql &= " WHERE id=" & Me.LstLines.Items(i).Text
                My.m_db.Execute(sql)

                If Not (swNew AndAlso kill) Then My.m_db.Execute("INSERT INTO db_tickets_loglines (id_ticket,id_articulo,id_articulo_combina,concepto,name,ud,fh) VALUES(" & Me.idRef & "," & Me.LstLines.Items(i).SubItems(lst_Columns_Tickets.id_art).Text & "," & Me.LstLines.Items(i).SubItems(lst_Columns_Tickets.id_art_combina).Text & ",'ACTUALIZA LINEA','" & Me.LstLines.Items(i).SubItems(lst_Columns_Tickets.name).Text.Replace("'", "") & "'," & Replace(CDbl(Me.LstLines.Items(i).SubItems(lst_Columns_Tickets.ud).Text) - CDbl(Me.LstLines.Items(i).SubItems(lst_Columns_Tickets.ud_original).Text), ",", ".") & ",'" & Format(Now, "HH:mm:ss") & "')")

                'Actualizo el almacen si es un articulo oficial
                If Me.LstLines.Items(i).SubItems(lst_Columns_Tickets.id_art).Text > 0 Then
                    My.m_db.Execute("UPDATE db_articulos SET n_veces=n_veces+" & (Me.LstLines.Items(i).SubItems(lst_Columns_Tickets.ud).Text - Me.LstLines.Items(i).SubItems(lst_Columns_Tickets.ud_original).Text) & ",fh_last_venta='" & Format(Now, "dd/MM/yyyy HH:mm:ss") & "',imp_acum_venta=imp_acum_venta+" & Me.LstLines.Items(i).SubItems(lst_Columns_Tickets.total).Text.Replace(",", ".") & "  WHERE id=" & Me.LstLines.Items(i).SubItems(lst_Columns_Tickets.id_art).Text)

                    'My.m_db.Execute("UPDATE db_articulos SET ud=ud-" & Replace(CDbl(Me.LstLines.Items(i).SubItems(lst_Columns_Tickets.ud).Text) - CDbl(Me.LstLines.Items(i).SubItems(lst_Columns_Tickets.ud_original).Text), ",", ".") & " WHERE estocable=true and id=" & Me.LstLines.Items(i).SubItems(lst_Columns_Tickets.id_art).Text)

                    If Me.idUser <> -3 Then My.UpdateAlmacen(Me.LstLines.Items(i).SubItems(lst_Columns_Tickets.id_art).Text, Replace(CDbl(Me.LstLines.Items(i).SubItems(lst_Columns_Tickets.ud).Text) - CDbl(Me.LstLines.Items(i).SubItems(lst_Columns_Tickets.ud_original).Text), ",", "."), Me.LstLines.Items(i).SubItems(lst_Columns_Tickets.tipo).Text)
                    If Me.LstLines.Items(i).SubItems(lst_Columns_Tickets.id_art_combina).Text > 0 AndAlso Me.idUser <> -3 Then My.UpdateAlmacen(Me.LstLines.Items(i).SubItems(lst_Columns_Tickets.id_art_combina).Text, Replace(CDbl(Me.LstLines.Items(i).SubItems(lst_Columns_Tickets.ud).Text) - CDbl(Me.LstLines.Items(i).SubItems(lst_Columns_Tickets.ud_original).Text), ",", "."))

                ElseIf Me.LstLines.Items(i).SubItems(lst_Columns_Tickets.id_art).Text = -2 Then
                    My.m_db.Execute("UPDATE estanco_marcas SET usos=usos+" & (Me.LstLines.Items(i).SubItems(lst_Columns_Tickets.ud).Text - Me.LstLines.Items(i).SubItems(lst_Columns_Tickets.ud_original).Text) & " WHERE id=" & Me.LstLines.Items(i).SubItems(lst_Columns_Tickets.id_tabaco).Text)
                End If
                If Me.LstLines.Items(i).SubItems(lst_Columns_Tickets.id_categoria).Text > 0 Then   'Vaya que sea un artículo libro
                    My.m_db.Execute("UPDATE db_categorias SET n_veces=n_veces+" & Replace(Me.LstLines.Items(i).SubItems(lst_Columns_Tickets.ud).Text, ",", ".") & " WHERE  id=" & Me.LstLines.Items(i).SubItems(lst_Columns_Tickets.id_categoria).Text)
                End If


            End If
        Next

        ' Imprimo articulos de comandas
        If My.MyComanda.IdPortComandas > 0 Then
            Dim strComanda As String = "", strAux As String = "", strCod As String = ""
            Dim strPrinter As String = "comandas"
            Dim str As String = ""


            For i = 0 To Me.LstLines.Items.Count - 1
                If CBool(Me.LstLines.Items(i).SubItems(lst_Columns_Tickets.comanda).Text) Then
                    strComanda &= " - " & Format((Me.LstLines.Items(i).SubItems(lst_Columns_Tickets.ud).Text - Me.LstLines.Items(i).SubItems(lst_Columns_Tickets.ud_original).Text)) & " " & Me.LstLines.Items(i).SubItems(lst_Columns_Tickets.name).Text & My.MyHardware.CodEsc_Cr
                End If
            Next
            If strComanda.Length > 0 Then

                If My.MyHardware.CodEsc_Init.Length > 0 Then My.RawPrinterHelper.SendStringToPrinter(strPrinter, My.MyHardware.CodEsc_Init & My.MyHardware.CodEsc_Cr)
                strCod = ""

                '###Imprimo los detalles de la Empresa
                ' > Nombre Fiscal
                strAux = My.m_opt.company_name
                If strAux.Length > My.MyHardware.Ancho Then strAux = strAux.Substring(1, My.MyHardware.Ancho)
                str &= strCod & My.MyHardware.CodEsc_Negrita_True & strAux & My.MyHardware.CodEsc_Negrita_True & My.MyHardware.CodEsc_Cr

                strAux = My.MyHardware.CodEsc_TextNormal & " " & My.MyHardware.CodEsc_Subrayado_True & Space(My.MyHardware.Ancho - 2) & My.MyHardware.CodEsc_Subrayado_False
                str &= strAux & My.MyHardware.CodEsc_Cr

                ' MeSA y Camarero
                str &= My.MyHardware.CodEsc_TextGrande & Me.LblMesa.Text & My.MyHardware.CodEsc_TextNormal & My.MyHardware.CodEsc_Cr
                str &= Me.LblEmpleado.Text & My.MyHardware.CodEsc_TextNormal & My.MyHardware.CodEsc_Cr

                strAux = My.MyHardware.CodEsc_TextNormal & " " & My.MyHardware.CodEsc_Subrayado_True & Space(My.MyHardware.Ancho - 2) & My.MyHardware.CodEsc_Subrayado_False
                str &= strAux & My.MyHardware.CodEsc_Cr

                str &= strComanda & My.MyHardware.CodEsc_Cr

                str &= My.MyHardware.CodEsc_Salto & My.MyHardware.CodEsc_Cr
                If Len(My.MyHardware.CodEsc_Cut) > 0 Then str &= My.MyHardware.CodEsc_Cut & My.MyHardware.CodEsc_Cr


                strAux = My.MyHardware.CodEsc_TextNormal & " " & My.MyHardware.CodEsc_Subrayado_True & Space(My.MyHardware.Ancho - 2) & My.MyHardware.CodEsc_Subrayado_False
                str &= "by gDevelop" & My.MyHardware.CodEsc_Cr

                My.RawPrinterHelper.SendStringToPrinter(strPrinter, str & My.MyHardware.CodEsc_Cr)
            End If

        End If


        Me._Changes = False

    End Sub

    ' Cancelo el ticket
    Private Sub CancelaTicket()
        If Me.idRef = -1 Then Exit Sub

        'Actualizo el estado
        My.m_db.Execute("UPDATE db_tickets SET estado='CANCELADO',fh_finaliza=#" & Format(Now, "MM/dd/yyyy HH:mm") & "#,id_user=" & Me.idUser & " WHERE id=" & Me.idRef)

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
                .Items(i).SubItems.Add(Format(frmPaneldeVentas_ArticuloLibre.LstLines.Items(x).Text / My.GetMultiplicadorIVA(CDbl(frmPaneldeVentas_ArticuloLibre.LstLines.Items(x).SubItems(2).Text)), "0.00#####"))         'Obtengo la base imponible
                .Items(i).SubItems.Add(CDbl(frmPaneldeVentas_ArticuloLibre.LstLines.Items(x).SubItems(2).Text))         'Tipo de IVA
                .Items(i).SubItems.Add(False)
                .Items(i).SubItems.Add(0)
                .Items(i).SubItems.Add("")
                .Items(i).SubItems.Add("")
                .Items(i).SubItems.Add(0)

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
            Me.PicCamarero.Image = My.Resources.g
            Me.LblEmpleado.Text = "gDevBoy"
            Exit Sub
        End If

        'Cargo los datos del empleado
        Dim rst As ADODB.Recordset = My.m_db.GetRst("SELECT id,name,img,color FROM db_usuarios WHERE id=" & Me.idUser)
        If rst.RecordCount > 0 Then
            Me.LblEmpleado.Text = rst("name").Value
            'Me.PicCamarero.BackColor = Color.FromArgb(rst("color").Value)
            Me.PicCamarero.Image = My.m_db.data_GetImgRow(rst("img"))
            Me.LblEmpleado.ForeColor = Color.FromArgb(rst("color").Value)
        Else
            Me.LblEmpleado.Text = "--DELETE--"
            Me.PicCamarero.Image = Nothing
            Me.LblEmpleado.ForeColor = Color.Red
        End If
        My.m_db.CloseRst(rst)
    End Sub

    ' Funcion para cargar la infomación relativa al ticket
    Private Sub LoadInfo_Ticket()
        Me.LblNTicket.Visible = False
        If Me.idRef = -1 Then Exit Sub

        Dim i As Integer, rst As ADODB.Recordset = Nothing

        '### Cargo los datos de CABECERA del Ticket
        rst = My.m_db.GetRst("SELECT * FROM db_tickets WHERE id=" & Me.idRef)
        Me.LblRef.Text = "Ref.: " & rst("id").Value
        Me.LblMesa.Text = rst("name_mesa").Value
        'Me.LblEmpleado.Text = rst("name").Value
        Me.LblIdFactura.Text = rst("id_factura").Value
        Me.LblNTicket.Text = rst("n_ticket").Value
        If rst("estado").Value = "FINALIZADO" Then
            Me.LblFh_Alta.Text = Format(rst("fh_finaliza").Value, "dd/MM/yyyy HH:mm")
        Else
            Me.LblFh_Alta.Text = Format(rst("fh_alta").Value, "dd/MM/yyyy HH:mm")
        End If

        'Cargo el descuento aplicado

        If IsDBNull(rst("dto").Value) OrElse rst("dto").Value = 0 Then
            Me.lblDto.Text = ""
            Me.lblDto.Tag = 0
            Me.lblDto.Visible = False
        Else
            Me.lblDto.Text = "Dto.: " & Format(rst("dto").Value, "0.00") & "%"
            Me.lblDto.Tag = rst("dto").Value
            Me.lblDto.Visible = True
        End If



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
                .Items(i).SubItems.Add(rst("id_marca").Value)

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
                .Items(i).SubItems.Add(0)

                ' Quito los anteriores seleccionados y muestro el ultimo agregado
                .SelectedItems.Clear()
                .Items(i).Selected = True
                .EnsureVisible(i)
            End With
            i += 1
            rst.MoveNext()
        End While
        My.m_db.CloseRst(rst)

        '### Cargo las LINEAS de las MARCAS de TABACo
        rst = My.m_db.GetRst("SELECT * FROM db_tickets_lines WHERE id_articulo=-2 AND id_ticket=" & Me.idRef)
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
                .Items(i).SubItems.Add(rst("id_marca").Value)

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

        Dim dbl As Double = 0

        For i = 0 To Me.LstLines.Items.Count - 1
            dbl += (CDbl(Me.LstLines.Items(i).SubItems(lst_Columns_Tickets.pvp_base).Text) * CDbl(Me.LstLines.Items(i).SubItems(lst_Columns_Tickets.ud).Text))
            DblTotal += CDbl(Me.LstLines.Items(i).SubItems(lst_Columns_Tickets.total).Text)

            'If DblTotal <> Format(dbl * 1.1, "0.00") Then
            '    MsgBox("Error cuadrando importes: " & Me.LstLines.Items(i).SubItems(lst_Columns_Tickets.name).Text)
            'End If
        Next



        'Aplico descuento
        If CDbl(Me.lblDto.Tag) <> 0 Then
            DblTotal = DblTotal - (DblTotal * CDbl(Me.lblDto.Tag)) / 100
        End If

        If DblLastPVP <> DblTotal Then           'Si se ha modificado el precio muestro el aviso
            Me.TmrAvisoPvp.Enabled = True
            Me.LblTotal.BackColor = Color.FromArgb(255, 128, 128)
            Me.PnlPVP.BackColor = Color.FromArgb(255, 128, 128)
            Me.LblTotal.Font = New Font("Tahoma", 28.0!, FontStyle.Bold)
        End If

        'Establezco estados
        Dim sw As Boolean = Not (Me.LstLines.Items.Count = 0)
        Me.BtCobrar.Enabled = sw
        Me.BtNewTicket.Enabled = sw
        Me.BtPrint.Enabled = sw
        Me.BtFactTicket.Enabled = sw 'AndAlso Me.idMesa <> -1

        Me.BtSave.Visible = ((Me.idRef > 0 AndAlso Me.LstLines.Items.Count = 0) OrElse (sw AndAlso Me.idMesa <> -1))
        If Me.swFinalizado Then Me.BtSave.Visible = False 'Si esta finalizado, no permito guardar, solo cobro
        Me.BtCobroDirecto.Visible = sw

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

        Dim dblBase_4 As Double = 0, dblBase_7 As Double = 0, dblBase_16 As Double = 0
        Dim dblIVA_4 As Double = 0, dblIVA_7 As Double = 0, dblIVA_16 As Double = 0


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
                StrAux &= Space(My.MyHardware.Ancho - StrAux.Length - Me.LblFh_Alta.Text.Length) & Me.LblFh_Alta.Text
                _port.Write(StrAux & My.MyHardware.CodEsc_Cr)
                _port.Close()
                _port.Open()

                Select Case My.m_opt.modo_compatibilidad
                    Case "COMERCIO"
                        StrAux = My.MyHardware.CodEsc_TextNormal & "Servicio: " & Me.LblMesa.Text
                        _port.Write(StrAux & My.MyHardware.CodEsc_Cr)

                        _port.Write(" " & My.MyHardware.CodEsc_Cr)
                    Case Else
                        If DateDiff(DateInterval.Minute, CDate(Me.LblFh_Alta.Text), Now) > 1 Then
                            StrAux = My.MyHardware.CodEsc_TextNormal & "Hora: " & Format(Now, "dd/MM/yyyy HH:mm")
                            _port.Write(StrAux & My.MyHardware.CodEsc_Cr)
                        End If
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
            StrAux &= Space(My.MyHardware.Ancho - StrAux.Length - Me.LblFh_Alta.Text.Length) & Me.LblFh_Alta.Text
            _port.Write(StrAux & My.MyHardware.CodEsc_Cr)

            Select Case My.m_opt.modo_compatibilidad
                Case "COMERCIO"
                    StrAux = My.MyHardware.CodEsc_TextNormal & "Servicio: " & Me.LblMesa.Text
                    _port.Write(StrAux & My.MyHardware.CodEsc_Cr)

                    _port.Write(" " & My.MyHardware.CodEsc_Cr)

                Case Else
                    If DateDiff(DateInterval.Minute, CDate(Me.LblFh_Alta.Text), Now) > 1 Then
                        StrAux = My.MyHardware.CodEsc_TextNormal & "Hora: " & Format(Now, "dd/MM/yyyy HH:mm")
                        _port.Write(StrAux & My.MyHardware.CodEsc_Cr)
                    End If
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
            Dim strText As String = ""

            If My.MyHardware.CodEsc_Init.Length > 0 Then strText &= My.MyHardware.CodEsc_Init & My.MyHardware.CodEsc_Cr
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
                If My.MyHardware.StrCab(i).Length <> 0 Then strText &= StrCod & StrAux & My.MyHardware.CodEsc_Cr
            Next
            strText &= My.MyHardware.CodEsc_Cr

            'Imprimo info sobre el ticket
            StrAux = My.MyHardware.CodEsc_TextNormal & "Factura: " & Me.LblNTicket.Text
            StrAux &= Space(My.MyHardware.Ancho - StrAux.Length - Me.LblFh_Alta.Text.Length) & Me.LblFh_Alta.Text
            strText &= StrAux & My.MyHardware.CodEsc_Cr

            StrAux = My.MyHardware.CodEsc_TextNormal & "Ref.: " & Format(Me.idRef, "000000")
            strText &= StrAux & My.MyHardware.CodEsc_Cr

            Select Case My.m_opt.modo_compatibilidad
                Case "COMERCIO", "ESTANCO"
                    StrAux = My.MyHardware.CodEsc_TextNormal & "Servicio: " & Me.LblMesa.Text
                    strText &= StrAux & My.MyHardware.CodEsc_Cr

                    strText &= " " & My.MyHardware.CodEsc_Cr

                Case Else
                    If DateDiff(DateInterval.Minute, CDate(Me.LblFh_Alta.Text), Now) > 1 Then
                        StrAux = My.MyHardware.CodEsc_TextNormal & "Hora: " & Format(Now, "dd/MM/yyyy HH:mm")
                        strText &= StrAux & My.MyHardware.CodEsc_Cr
                    End If
                    StrAux = My.MyHardware.CodEsc_TextNormal & "Le atendio: " & Me.LblEmpleado.Text
                    strText &= StrAux & My.MyHardware.CodEsc_Cr

                    StrAux = My.MyHardware.CodEsc_TextNormal & "Mesa: " & Me.LblMesa.Text
                    strText &= StrAux & My.MyHardware.CodEsc_Cr

                    My.RawPrinterHelper.SendStringToPrinter(strPrinter, " " & My.MyHardware.CodEsc_Cr)
            End Select
            Select Case My.m_opt.modo_compatibilidad
                Case "COMERCIO", "ESTANCO"
                    StrAux = " " & My.MyHardware.CodEsc_Subrayado_True & "Concepto" & My.MyHardware.CodEsc_Subrayado_False
                    StrAux &= Space(My.MyHardware.Ancho - 29) & " " & My.MyHardware.CodEsc_Subrayado_True & "Cant." & My.MyHardware.CodEsc_Subrayado_False
                    StrAux &= Space(1) & My.MyHardware.CodEsc_Subrayado_True & "Precio" & My.MyHardware.CodEsc_Subrayado_False
                    StrAux &= Space(2) & My.MyHardware.CodEsc_Subrayado_True & "Total" & My.MyHardware.CodEsc_Subrayado_False
                    strText &= StrAux & My.MyHardware.CodEsc_Cr

                Case Else
                    StrAux = " " & My.MyHardware.CodEsc_Subrayado_True & "Articulo" & My.MyHardware.CodEsc_Subrayado_False
                    StrAux &= Space(My.MyHardware.Ancho - 20) & My.MyHardware.CodEsc_Subrayado_True & "Ud." & My.MyHardware.CodEsc_Subrayado_False
                    StrAux &= Space(2) & My.MyHardware.CodEsc_Subrayado_True & "Total" & My.MyHardware.CodEsc_Subrayado_False
                    strText &= StrAux & My.MyHardware.CodEsc_Cr
            End Select

            For i = 0 To Me.LstLines.Items.Count - 1
                Select Case My.m_opt.modo_compatibilidad
                    Case "COMERCIO", "ESTANCO"
                        StrAux = " " & Me.LstLines.Items(i).SubItems(lst_Columns_Tickets.name).Text.Replace("Ñ", "N")
                        If StrAux.Length > My.MyHardware.Ancho - 22 Then StrAux = StrAux.Substring(0, My.MyHardware.Ancho - 22)
                        StrAux &= Space(My.MyHardware.Ancho - 21 - StrAux.Length)

                        StrAux &= Space(7 - Me.LstLines.Items(i).SubItems(lst_Columns_Tickets.ud).Text.Length) & Me.LstLines.Items(i).SubItems(lst_Columns_Tickets.ud).Text
                        StrAux &= Space(6 - Me.LstLines.Items(i).SubItems(lst_Columns_Tickets.pvp_ud).Text.Length) & Me.LstLines.Items(i).SubItems(lst_Columns_Tickets.pvp_ud).Text

                        j = (6 - Format(CDbl(Me.LstLines.Items(i).SubItems(lst_Columns_Tickets.total).Text), "0.00").Length)
                        If j < 0 Then j = 0

                        StrAux &= " " & Space(j) & Format(CDbl(Me.LstLines.Items(i).SubItems(lst_Columns_Tickets.total).Text), "0.00")
                        strText &= My.FixCHARISO(StrAux) & My.MyHardware.CodEsc_Cr

                    Case Else
                        StrAux = " " & Me.LstLines.Items(i).SubItems(lst_Columns_Tickets.name).Text.Replace("Ñ", "N")
                        If StrAux.Length > My.MyHardware.Ancho - 13 Then StrAux = StrAux.Substring(0, My.MyHardware.Ancho - 13)
                        StrAux &= Space(My.MyHardware.Ancho - 11 - StrAux.Length)
                        StrAux &= Space(3 - Me.LstLines.Items(i).SubItems(lst_Columns_Tickets.ud).Text.Length) & Me.LstLines.Items(i).SubItems(lst_Columns_Tickets.ud).Text

                        j = (6 - Me.LstLines.Items(i).SubItems(lst_Columns_Tickets.total).Text.Length)
                        If j < 0 Then j = 0

                        StrAux &= " " & Space(j) & Me.LstLines.Items(i).SubItems(lst_Columns_Tickets.total).Text
                        strText &= My.FixCHARISO(StrAux) & My.MyHardware.CodEsc_Cr
                End Select

                'Compongo las bases
                Select Case Me.LstLines.Items(i).SubItems(lst_Columns_Tickets.iva).Text
                    Case My.m_opt.IVA_General : dblBase_16 += (CDbl(Me.LstLines.Items(i).SubItems(lst_Columns_Tickets.pvp_base).Text) * CDbl(Me.LstLines.Items(i).SubItems(lst_Columns_Tickets.ud).Text))
                    Case My.m_opt.IVA_Medio : dblBase_7 += (CDbl(Me.LstLines.Items(i).SubItems(lst_Columns_Tickets.pvp_base).Text) * CDbl(Me.LstLines.Items(i).SubItems(lst_Columns_Tickets.ud).Text))
                    Case My.m_opt.IVA_Basico : dblBase_4 += (CDbl(Me.LstLines.Items(i).SubItems(lst_Columns_Tickets.pvp_base).Text) * CDbl(Me.LstLines.Items(i).SubItems(lst_Columns_Tickets.ud).Text))
                End Select
            Next


            StrAux = My.MyHardware.CodEsc_TextNormal & " " & My.MyHardware.CodEsc_Subrayado_True & Space(My.MyHardware.Ancho - 2) & My.MyHardware.CodEsc_Subrayado_False
            strText &= StrAux & My.MyHardware.CodEsc_Cr

            i = (6 - Me.LblTotal.Text.Length)
            If i < 0 Then i = 0

            StrAux = My.MyHardware.CodEsc_Rojo & Space(My.MyHardware.Ancho - 11) & My.MyHardware.CodEsc_TextGrande & My.MyHardware.CodEsc_Negrita_True & Space(i) & Me.LblTotal.Text.Replace("€", "E") & My.MyHardware.CodEsc_Negrita_False & My.MyHardware.CodEsc_TextNormal
            strText &= StrAux & My.MyHardware.CodEsc_Cr

            If Me.lblDto.Visible Then          'Tengo descuento
                StrAux = "Dto: " & My.MyHardware.CodEsc_TextGrande & Format(Me.lblDto.Text, "0.00") & My.MyHardware.CodEsc_TextNormal
                StrAux = Space(My.MyHardware.Ancho - StrAux.Length - 1) & StrAux
                strText &= My.MyHardware.CodEsc_Negro & StrAux & My.MyHardware.CodEsc_Cr
            End If

            If DblEntrega <> 0 Then          'He entregado algo
                StrAux = "Entrega: " & Format(DblEntrega, "###0.00")
                StrAux = Space(My.MyHardware.Ancho - StrAux.Length - 1) & StrAux
                strText &= My.MyHardware.CodEsc_Negro & StrAux & My.MyHardware.CodEsc_Cr

                StrAux = "Cambio: " & Format(DblEntrega - CDbl(Me.LblTotal.Text), "###0.00")
                StrAux = Space(My.MyHardware.Ancho - StrAux.Length - 1) & StrAux
                strText &= StrAux & My.MyHardware.CodEsc_Cr
            End If


            StrAux = My.MyHardware.CodEsc_Negro & Space(My.MyHardware.Ancho - 14) & "(IVA INCLUIDO)"
            strText &= StrAux & My.MyHardware.CodEsc_Cr

            strText &= My.MyHardware.CodEsc_Negro & My.MyHardware.CodEsc_Cr


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
            strText &= StrAux & My.MyHardware.CodEsc_Cr
            If dblBase_4 > 0 Then
                StrAux = " " & Format(dblBase_4, "0.00")
                StrAux &= Space(My.MyHardware.Ancho - 22 - StrAux.Length)
                StrAux &= Space(5 - Format(My.m_opt.IVA_Basico, "#0.00").Length) & Format(My.m_opt.IVA_Basico, "#0.00")
                StrAux &= Space(1)
                StrAux &= Space(7 - Format(dblIVA_4, "0.00").Length) & Format(dblIVA_4, "0.00")
                StrAux &= Space(1)
                StrAux &= Space(7 - Format(dblBase_4 + dblIVA_4, "0.00").Length) & Format(dblBase_4 + dblIVA_4, "0.00")
                strText &= StrAux & My.MyHardware.CodEsc_Cr
            End If

            If dblBase_7 > 0 Then
                StrAux = " " & Format(dblBase_7, "0.00")
                StrAux &= Space(My.MyHardware.Ancho - 22 - StrAux.Length)
                StrAux &= Space(5 - Format(My.m_opt.IVA_Medio, "#0.00").Length) & Format(My.m_opt.IVA_Medio, "#0.00")
                StrAux &= Space(1)
                StrAux &= Space(7 - Format(dblIVA_7, "0.00").Length) & Format(dblIVA_7, "0.00")
                StrAux &= Space(1)
                StrAux &= Space(7 - Format(dblBase_7 + dblIVA_7, "0.00").Length) & Format(dblBase_7 + dblIVA_7, "0.00")
                strText &= StrAux & My.MyHardware.CodEsc_Cr
            End If

            If dblBase_16 > 0 Then
                StrAux = " " & Format(dblBase_16, "0.00")
                StrAux &= Space(My.MyHardware.Ancho - 22 - StrAux.Length)
                StrAux &= Space(5 - Format(My.m_opt.IVA_General, "#0.00").Length) & Format(My.m_opt.IVA_General, "#0.00")
                StrAux &= Space(1)
                StrAux &= Space(7 - Format(dblIVA_16).Length) & Format(dblIVA_16, "0.00")
                StrAux &= Space(1)
                StrAux &= Space(7 - Format(dblBase_16 + dblIVA_16, "0.00").Length) & Format(dblBase_16 + dblIVA_16, "0.00")
                strText &= StrAux & My.MyHardware.CodEsc_Cr
            End If
            StrAux = Space(My.MyHardware.Ancho - 15) & My.MyHardware.CodEsc_Subrayado_True & Space(14) & My.MyHardware.CodEsc_Subrayado_False
            strText &= StrAux & My.MyHardware.CodEsc_Cr

            ' Resumen Final
            StrAux = Space(My.MyHardware.Ancho - 31) & My.MyHardware.CodEsc_Subrayado_True & Space(27) & My.MyHardware.CodEsc_Subrayado_False
            strText &= StrAux & My.MyHardware.CodEsc_Cr

            StrAux = Space(My.MyHardware.Ancho - 29) & My.MyHardware.CodEsc_Subrayado_True & Space(29) & My.MyHardware.CodEsc_Subrayado_False
            strText &= StrAux & My.MyHardware.CodEsc_Cr




            'Imprimo las lineas
            For i = 5 To 8
                StrAux = My.MyHardware.StrCab(i)
                StrCod = ""
                If StrAux.Length > My.MyHardware.Ancho Then StrAux = StrAux.Substring(1, My.MyHardware.Ancho)
                StrCod = My.Ticket_ConfigTextColor(StrCod, My.MyHardware.SwRed(i))
                StrCod = My.Ticket_ConfigTextStrong(StrCod, My.MyHardware.SwNegrita(i))
                StrCod = My.Ticket_ConfigTextSize(StrCod, My.MyHardware.SwGrande(i))
                StrAux = My.Ticket_ConfigTextAling(StrAux, IIf(My.MyHardware.SwCenter(i), 2, 0), My.MyHardware.SwGrande(i))
                If StrAux.Length <> 0 Then strText &= StrCod & StrAux & My.MyHardware.CodEsc_Cr
            Next

            'Resumen final
            StrAux = My.MyHardware.CodEsc_TextNormal & " " & My.MyHardware.CodEsc_Subrayado_True & Space(My.MyHardware.Ancho - 2) & My.MyHardware.CodEsc_Subrayado_False
            strText &= StrAux & My.MyHardware.CodEsc_Cr

            strText &= My.MyHardware.CodEsc_Negrita_True & My.Ticket_ConfigTextAling(" * _ FACTURA SIMPLIFICADA _ *", HorizontalAlignment.Center) & My.MyHardware.CodEsc_Negrita_False & My.MyHardware.CodEsc_Cr
            strText &= My.Ticket_ConfigTextAling(" gTPV.v" & My.Application.Info.Version.Major & "." & My.Application.Info.Version.Minor & "." & My.Application.Info.Version.Build) & "" & My.MyHardware.CodEsc_Cr


            strText &= My.MyHardware.CodEsc_Salto & My.MyHardware.CodEsc_Cr
            My.RawPrinterHelper.SendStringToPrinter(strPrinter, strText)

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

    Private Sub ClickComposicion(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub ClickMoreOptions(ByVal sender As System.Object, ByVal e As System.EventArgs)
        frmPaneldeVentas_ValoraArt.IdRef = CType(sender, Button).Tag
        frmPaneldeVentas_ValoraArt.ShowDialog(Me)
        If frmPaneldeVentas_ValoraArt.DialogResult <> Windows.Forms.DialogResult.OK Then
            frmPaneldeVentas_ValoraArt.Dispose()
            Me.LstLines.Focus()
            Exit Sub
        End If

        Me.ProcesaClick(CType(sender, Button).Tag, 0, frmPaneldeVentas_ValoraArt.intTipo)
        frmPaneldeVentas_ValoraArt.Dispose()

        Me.LstLines.Focus()
    End Sub

    Private Sub LblHour_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LblHour.Click
        My.OpenCajon()
    End Sub

    Private Sub ClickX10(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.ProcesaClick_Tabaco(CType(sender, Button).Tag, 10)
    End Sub



#Region "Estancos"
    Private Sub Load_Marcas()
        Dim m_Table As DataTable            'Tabla de datos
        Dim rst As ADODB.Recordset
        Dim da As Data.OleDb.OleDbDataAdapter
        Dim ColStyle As DataGridViewColumn
        Dim Cell As DataGridViewCell = New DataGridViewTextBoxCell()

        Dim strWhere As String = ""

        'El estilo de las celdas
        Dim m_Style As New DataGridViewCellStyle
        With m_Style
            .BackColor = System.Drawing.SystemColors.GradientActiveCaption
            .ForeColor = System.Drawing.SystemColors.ControlText
            .Font = New System.Drawing.Font("Verdana", 10)
            .Padding = New Padding(3, 3, 3, 3)
        End With

        Dim m_Style_alt As New DataGridViewCellStyle
        With m_Style_alt
            .BackColor = System.Drawing.SystemColors.GradientInactiveCaption
            .ForeColor = System.Drawing.SystemColors.ControlText
            .Font = New System.Drawing.Font("Verdana", 10)
            .Padding = New Padding(3, 3, 3, 3)
        End With

        'Preconfiguramos el grid de las ventas
        With Me.gridMarcas
            .Columns.Clear()
            .AutoGenerateColumns = False
            .AlternatingRowsDefaultCellStyle = m_Style_alt
            .RowTemplate.Height = 30

            'El id
            ColStyle = New DataGridViewColumn()
            ColStyle.DataPropertyName = "id"
            ColStyle.HeaderText = "Id."
            ColStyle.Width = 0
            ColStyle.Visible = False
            ColStyle.DefaultCellStyle = m_Style
            ColStyle.CellTemplate = Cell
            .Columns.Add(ColStyle)

            'Las marcas
            ColStyle = New DataGridViewColumn()
            ColStyle.DataPropertyName = "name"
            ColStyle.HeaderText = "Marca"
            ColStyle.Width = 280
            ColStyle.DefaultCellStyle = m_Style
            ColStyle.CellTemplate = Cell
            .Columns.Add(ColStyle)

            'El precio
            ColStyle = New DataGridViewColumn()
            ColStyle.DataPropertyName = "precio"
            ColStyle.HeaderText = "Precio"
            ColStyle.Width = 90
            ColStyle.DefaultCellStyle = m_Style
            ColStyle.CellTemplate = Cell
            .Columns.Add(ColStyle)

            ''El precio + recargo
            'ColStyle = New DataGridViewColumn()
            'ColStyle.DataPropertyName = "precio_recargo"
            'ColStyle.HeaderText = "Precio Recargo"
            'ColStyle.Width = 90
            'ColStyle.DefaultCellStyle = m_Style
            'ColStyle.CellTemplate = Cell
            '.Columns.Add(ColStyle)

            'Fecha de creacion
            ColStyle = New DataGridViewColumn()
            ColStyle.DataPropertyName = "fh_updatePrecio"
            ColStyle.HeaderText = "Fh. Actualización"
            ColStyle.Width = 160
            ColStyle.DefaultCellStyle = m_Style
            ColStyle.CellTemplate = Cell
            .Columns.Add(ColStyle)


        End With

        strWhere &= " AND activo=TRUE "

        'Filtro especial de letras (cuando esta visible y he aplicado un filtro de letra)
        If Me.PnlFilter.Visible AndAlso Not Me.Rbt_Filter_All.Checked Then
            strWhere &= " AND name LIKE '" & Me.PnlFilter.Tag & "%'"
        End If

        'Filtro por nombre
        For Each strAux As String In Me.TxtFindEstanco.Text.Split(" ")
            strAux = strAux.Trim
            If strAux.Length > 0 Then
                'Sql &= IIf(Sql.Length = 0, "", " AND ") & " name LIKE '%" & strAux & "%'"
                strWhere &= " AND " & " name LIKE '%" & strAux & "%'"
            End If
        Next

        'Filtro de nombre
        'strWhere &= " AND name LIKE '%" & Me.TxtFindEstanco.Text & "%'"

        'strWhere &= " AND (fh_updatePrecio>=#" & Format(Me.dtFhUpdate.Value, "MM-dd-yyyy") & " 00:00# OR isnull(fh_updatePrecio))"

        'Asignamos los datos
        rst = My.m_db.GetRst("SELECT id,cod_barras,name,precio,precio_recargo,fh_updatePrecio FROM estanco_marcas WHERE 1=1 " & strWhere & " ORDER BY name ASC")
        If IsNothing(rst) Then Exit Sub

        m_Table = New DataTable("m_tabla")
        da = New Data.OleDb.OleDbDataAdapter
        da.Fill(m_Table, rst)
        Me.gridMarcas.DataSource = m_Table


        Me.lblTotMarcas.Text = rst.RecordCount

        'Permito borrar y volver a imprimir resumen
        Dim sw As Boolean = (Me.gridMarcas.RowCount > 0)
        'Me.btMarca_edit.Enabled = sw
        'Me.btMarca_del.Enabled = sw

        Me.LstLines.Focus()
    End Sub

    'Seleccion de filtro
    Private Sub rbtFilter_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Rbt_Filter_All.CheckedChanged, Rbt_Filter_V.CheckedChanged, Rbt_Filter_Z.CheckedChanged, Rbt_Filter_Y.CheckedChanged, Rbt_Filter_X.CheckedChanged, Rbt_Filter_W.CheckedChanged, Rbt_Filter_U.CheckedChanged, Rbt_Filter_T.CheckedChanged, Rbt_Filter_S.CheckedChanged, Rbt_Filter_R.CheckedChanged, Rbt_Filter_Q.CheckedChanged, Rbt_Filter_P.CheckedChanged, Rbt_Filter_O.CheckedChanged, Rbt_Filter_N.CheckedChanged, Rbt_Filter_M.CheckedChanged, Rbt_Filter_L.CheckedChanged, Rbt_Filter_K.CheckedChanged, Rbt_Filter_J.CheckedChanged, Rbt_Filter_I.CheckedChanged, Rbt_Filter_H.CheckedChanged, Rbt_Filter_G.CheckedChanged, Rbt_Filter_F.CheckedChanged, Rbt_Filter_E.CheckedChanged, Rbt_Filter_D.CheckedChanged, Rbt_Filter_C.CheckedChanged, Rbt_Filter_B.CheckedChanged, Rbt_Filter_A.CheckedChanged
        'Caso de que no este chequeado restauro valores
        If Not CType(sender, RadioButton).Checked Then
            CType(sender, RadioButton).Font = New Font("Microsoft Sans Serif", 8.25)
            Exit Sub
        End If

        'Si he seleccionado uno, quito 
        CType(sender, RadioButton).Font = New Font("Microsoft Sans Serif", 8, FontStyle.Bold)
        Me.PnlFilter.Tag = CType(sender, RadioButton).Text

        Me.Load_Marcas()

        My.AsignarFoco(Me.TxtFindEstanco)
    End Sub

    Private Sub btEstancos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btEstancos.Click
        Me.pnlEstanco.Visible = Not Me.pnlEstanco.Visible
        Me.pnlLstArticulos.Visible = False

        If Me.pnlEstanco.Visible Then
            My.AsignarFoco(Me.TxtFindEstanco)

            Me.Load_Marcas()
        End If

        Me.LstLines.Focus()
    End Sub

    Private Sub TxtFindEstanco_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtFindEstanco.TextChanged
        Me.Load_Marcas()
    End Sub





    Private Sub gridMarcas_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles gridMarcas.CellDoubleClick
        ProcesaClick_Tabaco(Me.gridMarcas.SelectedRows(0).Cells(0).Value)
        Me.LstLines.Focus()
    End Sub



    Private Sub ProcesaClick_Tabaco(ByVal id As Integer, Optional ByVal ud10 As Boolean = False)
        Dim i As Integer, sw As Boolean = False
        Dim rst As ADODB.Recordset
        Dim sql As String
        Dim pvp_ud As Double = 0, pvp_inc As Double = 0, pvp_inc_Base As Double = 0


        'Las unidades por defecto 1
        Dim ud As Double = 1 ', pvp As Double = 0


        ' Por defecto, seleccionamos la pagina del tab de tickets
        Me.Tab.SelectedTab = Me.TabPage_Ticket


        '### Obtengo información sobre el artículo
        sql = "SELECT * FROM estanco_marcas WHERE id=" & id
        rst = My.m_db.GetRst(sql)

        pvp_ud = rst("precio").Value

        '' ''If tipo <= 0 Then
        '' ''    pvp_ud = rst("pvp_iva").Value

        '' ''    'Si tengo establecido una tarifa
        '' ''    If My.m_opt.id_tarifa > 0 Then
        '' ''        If CBool(rst("swTarifas").Value) Then
        '' ''            pvp_ud = rst("tarifa_" & My.m_opt.id_tarifa & "_pvp").Value
        '' ''        End If
        '' ''    End If

        '' ''    'Compruebo si el articulo combinable tiene incremento de precio
        '' ''    If idCombinaCon > 0 Then
        '' ''        Dim rstTMP As ADODB.Recordset = My.m_db.GetRst("SELECT id,swIncCombina,iva,pvp_IncCombina FROM db_articulos WHERE id=" & idCombinaCon)
        '' ''        If CBool(rstTMP("swIncCombina").Value) Then pvp_ud += rstTMP("pvp_IncCombina").Value
        '' ''        My.m_db.CloseRst(rstTMP)
        '' ''    End If

        '' ''Else
        '' ''    pvp_ud = rst("vlcaso" & tipo & "_pvp").Value            'PUTO TUTELA
        '' ''    strTipo = " - " & rst("vlcaso" & tipo & "_name").Value
        '' ''End If

        '' ''If Me.swInvitacion Then pvp_ud = 0
        '' ''If Me.swEntrada_Refresco Then pvp_ud = 0
        '' ''If Me.swEntrada_Copa Then pvp_ud = 0




        ud *= IIf(ud10, 10, 1)

        '### Compruebo si esta agregado ya (Excepto cuando es de pesaje)
        For i = 0 To Me.LstLines.Items.Count - 1
            If Me.LstLines.Items(i).SubItems(lst_Columns_Tickets.id_art).Text = "-2" AndAlso _
                 Me.LstLines.Items(i).SubItems(lst_Columns_Tickets.id_tabaco).Text = id AndAlso _
                 Me.LstLines.Items(i).SubItems(lst_Columns_Tickets.id_art_combina).Text = 0 AndAlso _
                    Me.LstLines.Items(i).SubItems(lst_Columns_Tickets.tipo).Text = 0 AndAlso _
                    CDbl(Me.LstLines.Items(i).SubItems(lst_Columns_Tickets.pvp_ud).Text) = pvp_ud Then       'Si el articulo esta agregado

                Me.LstLines.Items(i).SubItems(lst_Columns_Tickets.name).Text = (IIf(ud + Me.LstLines.Items(i).SubItems(lst_Columns_Tickets.ud).Text >= 10, "[" & Format((ud + Me.LstLines.Items(i).SubItems(lst_Columns_Tickets.ud).Text) / 10, "0") & " CART] ", "") & rst("name").Value)
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



        If Not sw Then           'No esta agregado asi que lo agrego
            With Me.LstLines
                .Items.Add(0)
                .Items(i).SubItems.Add("-2")
                .Items(i).SubItems.Add(0)
                .Items(i).SubItems.Add(Format(ud, "0.###"))
                .Items(i).SubItems.Add(0)
                .Items(i).SubItems.Add(IIf(ud10, "[" & Format(ud / 10, "0") & " CART] ", "") & rst("name").Value)              'Si no es combinado la cadena combina esta vacia
                .Items(i).SubItems.Add(Format(pvp_ud, "0.00#"))
                .Items(i).SubItems.Add(Format((pvp_ud * ud), "0.00#"))
                .Items(i).SubItems.Add(False)
                .Items(i).SubItems.Add(0)
                .Items(i).SubItems.Add(Format((rst("precio").Value / CDbl("1," & Format(My.m_opt.IVA_General, "00"))), "0.00#####"))
                .Items(i).SubItems.Add(My.m_opt.IVA_General)
                .Items(i).SubItems.Add(False)
                .Items(i).SubItems.Add(0)
                .Items(i).SubItems.Add("")
                .Items(i).SubItems.Add(Me._strTipoInvitacion)

                .Items(i).SubItems.Add(id)

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
        Me.BtLastArticulo.Image = My.m_db.data_GetImgRow(rst("img"))
        'If rst("id_img").Value > 0 Then
        '    Dim RstAux As ADODB.Recordset = My.m_db.GetRst("SELECT img FROM app_imgs WHERE id=" & rst("id_img").Value)
        '    Me.BtLastArticulo.Image = My.m_db.data_GetImgRow(RstAux("img"))
        '    My.m_db.CloseRst(RstAux)
        'End If

        Me.BtLastArticulo.Enabled = True
        Me.BtLastArticulo.Font = New System.Drawing.Font("Tahoma", 10.75!, System.Drawing.FontStyle.Bold)
        Me.BtLastArticulo.Text = "+" & Me.LstLines.SelectedItems(0).SubItems(lst_Columns_Tickets.ud).Text & vbCrLf & rst("name").Value
        Me.BtLastArticulo.Tag = rst("name").Value
        'Me.BtLastArticulo.Text = "Último Artículo Agregado" & vbCrLf & vbCrLf & vbCrLf & vbCrLf & vbCrLf & rst("name").Value & StrCombina
        Me.BtLastArticulo.TextAlign = ContentAlignment.BottomCenter

        Me._lastUse_id = -2
        Me._lastUse_idCombina = 0
        Me._lastUse_idMarca = id


        My.m_db.CloseRst(rst)


        'Paso funciones de interconexion entre capas
        Me.CheckStateButtons()
        Me.Calcular_Totales()

        Me.LstLines.Focus()
    End Sub


    Private Sub TxtFindEstanco_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtFindEstanco.KeyPress
        If e.KeyChar = Chr(Keys.Enter) Then
            e.Handled = True
            If Me.lblTotMarcas.Text = 1 Then
                'Agrego el producto
                Me.ProcesaClick_Tabaco(Me.gridMarcas.SelectedRows(0).Cells(0).Value)
            Else
                Me.Load_Marcas()
            End If
        End If
    End Sub
#End Region

#Region "Productos"

    Private Sub Load_Productos()
        Dim m_Table As DataTable            'Tabla de datos
        Dim rst As ADODB.Recordset
        Dim da As Data.OleDb.OleDbDataAdapter
        Dim ColStyle As DataGridViewColumn
        Dim Cell As DataGridViewCell = New DataGridViewTextBoxCell()

        Dim strWhere As String = ""

        'El estilo de las celdas
        Dim m_Style As New DataGridViewCellStyle
        With m_Style
            .BackColor = System.Drawing.SystemColors.GradientActiveCaption
            .ForeColor = System.Drawing.SystemColors.ControlText
            .Font = New System.Drawing.Font("Verdana", 12)
            .Padding = New Padding(3, 5, 3, 7)
        End With

        Dim m_Style_alt As New DataGridViewCellStyle
        With m_Style_alt
            .BackColor = System.Drawing.SystemColors.GradientInactiveCaption
            .ForeColor = System.Drawing.SystemColors.ControlText
            .Font = New System.Drawing.Font("Verdana", 12)
            .Padding = New Padding(3, 5, 3, 7)
        End With

        'Preconfiguramos el grid de las ventas
        With Me.gridProductos
            .Columns.Clear()
            .AutoGenerateColumns = False
            .AlternatingRowsDefaultCellStyle = m_Style_alt
            .RowTemplate.Height = 40

            'El id
            ColStyle = New DataGridViewColumn()
            ColStyle.DataPropertyName = "id"
            ColStyle.HeaderText = "Id."
            ColStyle.Width = 0
            ColStyle.Visible = False
            ColStyle.DefaultCellStyle = m_Style
            ColStyle.CellTemplate = Cell
            .Columns.Add(ColStyle)

            'Las marcas
            ColStyle = New DataGridViewColumn()
            ColStyle.DataPropertyName = "name"
            ColStyle.HeaderText = "Producto"
            ColStyle.Width = 380
            ColStyle.DefaultCellStyle = m_Style
            ColStyle.CellTemplate = Cell
            .Columns.Add(ColStyle)

            'El precio
            ColStyle = New DataGridViewColumn()
            ColStyle.DataPropertyName = "pvp_iva"
            ColStyle.HeaderText = "Precio"
            ColStyle.Width = 90
            ColStyle.DefaultCellStyle = m_Style
            ColStyle.CellTemplate = Cell
            .Columns.Add(ColStyle)

            ''El precio + recargo
            'ColStyle = New DataGridViewColumn()
            'ColStyle.DataPropertyName = "precio_recargo"
            'ColStyle.HeaderText = "Precio Recargo"
            'ColStyle.Width = 90
            'ColStyle.DefaultCellStyle = m_Style
            'ColStyle.CellTemplate = Cell
            '.Columns.Add(ColStyle)

            ''Fecha de creacion
            'ColStyle = New DataGridViewColumn()
            'ColStyle.DataPropertyName = "fh_updatePrecio"
            'ColStyle.HeaderText = "Fh. Actualización"
            'ColStyle.Width = 160
            'ColStyle.DefaultCellStyle = m_Style
            'ColStyle.CellTemplate = Cell
            '.Columns.Add(ColStyle)


        End With

        'Filtro especial de letras (cuando esta visible y he aplicado un filtro de letra)
        If Me.PnlFilterProductos.Visible AndAlso Not Me.rbtFilterProducto_all.Checked Then
            strWhere &= " AND name LIKE '" & Me.PnlFilterProductos.Tag & "%'"
        End If

        'Filtro de nombre
        strWhere &= " AND name LIKE '%" & Me.TxtFindProducto.Text & "%'"
        'strWhere &= " AND (fh_updatePrecio>=#" & Format(Me.dtFhUpdate.Value, "MM-dd-yyyy") & " 00:00# OR isnull(fh_updatePrecio))"


        '## Filtro por categoria
        If Me.cbCategorias.SelectedIndex >= 0 Then
            strWhere &= " AND id_categoria=" & Me.cbCategorias.Text.Substring(100).Trim
        End If



        'Asignamos los datos
        rst = My.m_db.GetRst("SELECT id,name,pvp_iva FROM db_articulos WHERE 1=1 " & strWhere & " ORDER BY name ASC")
        If IsNothing(rst) Then Exit Sub

        m_Table = New DataTable("m_tabla")
        da = New Data.OleDb.OleDbDataAdapter
        da.Fill(m_Table, rst)
        Me.gridProductos.DataSource = m_Table


        Me.lblTotProductos.Text = rst.RecordCount

        'Permito borrar y volver a imprimir resumen
        Dim sw As Boolean = (Me.gridProductos.RowCount > 0)
        'Me.btMarca_edit.Enabled = sw
        'Me.btMarca_del.Enabled = sw


        Me.LstLines.Focus()
    End Sub

    'Seleccion de filtro
    Private Sub rbtFilterProductos_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbtFilterProducto_all.CheckedChanged, rbtFilterProducto_V.CheckedChanged, rbtFilterProducto_Z.CheckedChanged, rbtFilterProducto_Y.CheckedChanged, rbtFilterProducto_X.CheckedChanged, rbtFilterProducto_W.CheckedChanged, rbtFilterProducto_U.CheckedChanged, rbtFilterProducto_T.CheckedChanged, rbtFilterProducto_S.CheckedChanged, rbtFilterProducto_R.CheckedChanged, rbtFilterProducto_Q.CheckedChanged, rbtFilterProducto_P.CheckedChanged, rbtFilterProducto_O.CheckedChanged, rbtFilterProducto_N.CheckedChanged, rbtFilterProducto_M.CheckedChanged, rbtFilterProducto_L.CheckedChanged, rbtFilterProducto_K.CheckedChanged, rbtFilterProducto_J.CheckedChanged, rbtFilterProducto_I.CheckedChanged, rbtFilterProducto_H.CheckedChanged, rbtFilterProducto_G.CheckedChanged, rbtFilterProducto_F.CheckedChanged, rbtFilterProducto_E.CheckedChanged, rbtFilterProducto_D.CheckedChanged, rbtFilterProducto_C.CheckedChanged, rbtFilterProducto_B.CheckedChanged, rbtFilterProducto_A.CheckedChanged
        'Caso de que no este chequeado restauro valores
        If Not CType(sender, RadioButton).Checked Then
            CType(sender, RadioButton).Font = New Font("Microsoft Sans Serif", 8.25)
            Exit Sub
        End If

        'Si he seleccionado uno, quito 
        CType(sender, RadioButton).Font = New Font("Microsoft Sans Serif", 8, FontStyle.Bold)
        Me.PnlFilterProductos.Tag = CType(sender, RadioButton).Text

        Me.Load_Productos()

        My.AsignarFoco(Me.TxtFindProducto)
    End Sub


    Private Sub btProductos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btProductos.Click
        Me.pnlLstArticulos.Visible = Not Me.pnlLstArticulos.Visible
        Me.pnlEstanco.Visible = False

        If Me.pnlLstArticulos.Visible Then

            'Cargo las categorias
            Dim rst As ADODB.Recordset = My.m_db.GetRst("SELECT * FROM db_categorias ORDER BY name ASC")
            Me.cbCategorias.Items.Clear()
            While Not rst.EOF
                Me.cbCategorias.Items.Add(rst("name").Value & Space(100) & rst("id").Value)
                rst.MoveNext()
            End While
            My.m_db.CloseRst(rst)


            Me.Load_Productos()

            My.AsignarFoco(Me.TxtFindProducto)
        End If

    End Sub

    Private Sub TxtFindProductos_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtFindProducto.TextChanged
        Me.Load_Productos()
    End Sub

    Private Sub TxtFindProducto_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtFindProducto.KeyPress
        If e.KeyChar = Chr(Keys.Enter) AndAlso Control.ModifierKeys <> Keys.Control Then
            e.Handled = True
            If Me.lblTotProductos.Text = 1 Then
                'Agrego el producto
                ProcesaClick(Me.gridProductos.SelectedRows(0).Cells(0).Value)
            Else
                Me.Load_Productos()
            End If
        End If

        If e.KeyChar = Chr(27) Then
            e.Handled = True

            Me.TxtFindProducto.Text = ""
            'Me.Load_Productos()
        End If
    End Sub

    Private Sub gridProductos_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles gridProductos.CellDoubleClick
        ProcesaClick(Me.gridProductos.SelectedRows(0).Cells(0).Value)
    End Sub


    Private Sub cbCategorias_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbCategorias.SelectedIndexChanged
        If Me.cbCategorias.SelectedIndex < 0 Then Exit Sub

        'Cargo productos de la categoria
        Me.Load_Productos()
    End Sub

#End Region




#Region "Control de Códigos de Barras"
    'Variables de control para la lectura de codigos de barras
    Dim SwLectura As Boolean = False
    Dim StrLectorCodigos As String = ""

    Dim strCode As String = ""

    Private Sub fmrPaneldeVentas_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles MyBase.KeyPress

        If Me.TxtFindProducto.Focus OrElse Me.TxtFindEstanco.Focus Then Exit Sub

        If My.MyLector.Sw_Lector AndAlso (e.KeyChar = My.MyLector.Str_CodLector Or (My.MyLector.Str_CodLector.Length = 0 AndAlso Not Me.SwLectura AndAlso IsNumeric(e.KeyChar))) Then
            Me.SwLectura = True

            StrLectorCodigos = IIf(IsNumeric(e.KeyChar), e.KeyChar, "")

            Me.strCode &= e.KeyChar

            e.Handled = True
            e.KeyChar = ""
            TmrCodBarras.Enabled = True
            Exit Sub
        End If

        If Me.SwLectura Then
            If My.MyLector.Str_CodLector.Length <> 0 Then e.Handled = True
            If e.KeyChar = Chr(13) AndAlso StrLectorCodigos.Length >= 6 Then
                TmrCodBarras.Enabled = False
                Me.SwLectura = False
                System.Threading.Thread.Sleep(350)
                Me.CheckCodeBar(StrLectorCodigos)
                Me.strCode = ""
                e.Handled = True
                Exit Sub
            End If
            If Not IsNumeric(e.KeyChar) Then
                TmrCodBarras.Enabled = False
                Me.SwLectura = False
                Exit Sub
            End If

            Me.strCode &= e.KeyChar


            StrLectorCodigos &= e.KeyChar
            If My.MyLector.Str_CodLector.Length <> 0 Then e.KeyChar = ""
            e.KeyChar = ""
            e.Handled = True
        Else
            'If e.KeyChar = Chr(Keys.Enter) Then
            '    Me.TxtFind.Text.Replace("$", "")
            '    If MyLector.Sw_Lector Then
            '        If IsNumeric(Me.TxtFind.Text) AndAlso Me.TxtFind.Text.Length >= 8 Then
            '            Dim swTmp As Boolean = CheckCodeBar(Me.TxtFind.Text)
            '            Me.TxtFind.Text = ""
            '            e.Handled = True
            '            If Me.Grid.RowCount > 0 AndAlso swTmp Then Me.ValidateItem(Me.BtToolShow, New System.EventArgs)
            '            Exit Sub
            '        End If
            '    End If

            '    e.Handled = True

            'End If
            'MsgBox("Entro aqui")
        End If
    End Sub

    Private Function CheckCodeBar(ByVal StrCod As String) As Boolean
        On Error Resume Next
        Dim CodBarras As String
        CheckCodeBar = False
        'Compruebo que corresponde a un cbarras 

        'Chequeo que el articulo exista si es de tabaco
        Dim RstAux As ADODB.Recordset = My.m_db.GetRst("SELECT id,cod_barras,cod_barras_x10 FROM estanco_marcas WHERE cod_barras='" & StrCod & "' OR cod_barras_x10='" & StrCod & "'")
        If RstAux.RecordCount > 0 Then
            CheckCodeBar = True

            'Agrego el articulo
            Me.ProcesaClick_Tabaco(RstAux("id").Value, IIf(StrCod = (RstAux("cod_barras_x10").Value & ""), True, False))
            My.m_db.CloseRst(RstAux)
            Return True
        End If

        'Chequeo que el codigo de barras sea de articulo
        If StrCod.Length > 6 AndAlso StrCod.Substring(0, 5) = "11111" Then
            'Codigo de barras personalizado

            RstAux = My.m_db.GetRst("SELECT id FROM db_articulos_ WHERE id=" & Val(StrCod.Substring(6, 6)))
            If RstAux.RecordCount > 0 Then
                CheckCodeBar = True

                'Agrego el articulo
                Me.ProcesaClick(RstAux("id").Value)
                My.m_db.CloseRst(RstAux)
                Return True
            End If



        Else
            'Codigo de barras agregado al articulo
            RstAux = My.m_db.GetRst("SELECT id_articulo FROM db_articulos_cod_barras WHERE cod_barras='" & StrCod & "'")
            If RstAux.RecordCount > 0 Then
                CheckCodeBar = True

                'Agrego el articulo
                Me.ProcesaClick(RstAux("id_articulo").Value)
                My.m_db.CloseRst(RstAux)
                Return True
            End If

        End If



        If CheckCodeBar = False Then
            MsgBox("Código de barras no localizado", MsgBoxStyle.Critical)
            Exit Function
        End If


        ''Muestro el formulario de lineas
        'With frmEstanco_Marca
        '    .Id_Ref = RstAux("id").Value
        '    .ShowDialog(Me)
        '    If .DialogResult <> Windows.Forms.DialogResult.OK Then
        '        .Dispose()
        '        Exit Function
        '    End If
        '    .Dispose()
        'End With

        'Me.LblHour.Text = Now.ToString("HH:mm")
        'Me.TmHour.Enabled = True

        'Me.Load_Marcas()
        My.m_db.CloseRst(RstAux)



        ''Agrego el artículo
        'frmClientes_Precios.IdRef = 0
        'frmClientes_Precios.IdArticulo = Val(CodBarras)
        'frmClientes_Precios.ShowDialog(Me)
        'If frmClientes_Precios.DialogResult <> Windows.Forms.DialogResult.OK Then
        '    frmClientes_Precios.Dispose()
        '    Exit Function
        'End If

        ''### Duplicado en el evento del boton
        'My.Application.m_Db.Execute("INSERT INTO clientes_precios (id_cliente,id_articulo,pvp_1) VALUES(" & Me.LblId.Text & "," & CodBarras & "," & frmClientes_Precios.TxtPvp.Text.Replace(",", ".") & ")")
        'frmClientes_Precios.Dispose()

        'Me.LoadPvpPersonalizados()
    End Function

    Private Sub TmrCodBarras_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TmrCodBarras.Tick
        TmrCodBarras.Enabled = False
        Me.SwLectura = False
        Me.StrLectorCodigos = ""
    End Sub
#End Region




    'Private Sub frmPaneldeVentas_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles MyBase.KeyPress
    '    If e.KeyChar = Chr(27) Then
    '        Me.Close()
    '        Exit Sub
    '    End If
    'End Sub

    Private Sub frmPaneldeVentas_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        'If e.KeyCode = Keys.Escape Then
        '    Me.Close()
        'End If

        If e.KeyCode = Keys.F1 Then
            Me.btProductos_Click(Me.btProductos, New System.EventArgs)
        End If

        If e.KeyValue = Keys.Escape Then Me.Close()

    End Sub


    Private Sub lstHistory_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lstHistory.SelectedIndexChanged

    End Sub

    Private Sub btFacturarTickets_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btFacturarTickets.Click
        Dim sw As Boolean = False
        For i As Integer = 0 To Me.lstHistory.Items.Count - 1
            If Me.lstHistory.Items(i).Checked Then
                sw = True
                Exit For
            End If
        Next
        If Not sw Then
            MsgBox("Imposible facturar, no ha seleccionado ningún ticket.", MsgBoxStyle.Information)
            Exit Sub
        End If

        If MsgBox("¿Esta seguro de que desea facturar los tickets seleccionados?", MsgBoxStyle.YesNo + MsgBoxStyle.Question) <> MsgBoxResult.Yes Then Exit Sub




        'Muestro el formulario de facturar
        Dim idCliente As Integer = My.Exporta("CLIENTES")
        If idCliente <= 0 Then Exit Sub

        ' Creo la factura al cliente
        Dim rst As ADODB.Recordset = My.m_db.GetRst("SELECT * FROM db_facturas WHERE id=-1")
        rst.AddNew()
        rst("id_contable").Value = My.m_app.GetValue("id_contable")
        rst("id_cliente").Value = idCliente
        rst("id_ticket").Value = -1
        rst("id_caja").Value = -1
        rst("n_factura").Value = Now.ToString("yy") & "/" & My.Get_Contador("FACTURA_A")
        rst("fh_factura").Value = Now.ToString("dd-MM-yyyy")
        rst("fh_alta").Value = Now
        rst.Update()

        Dim id As Integer = rst("id").Value
        My.m_db.CloseRst(rst)

        For i As Integer = 0 To Me.lstHistory.Items.Count - 1
            If Me.lstHistory.Items(i).Checked Then My.m_db.Execute("UPDATE db_tickets SET estado='FACTURADO', id_factura=" & id & " WHERE id=" & Me.lstHistory.Items(i).SubItems(1).Text)
        Next



        'Muestro la factura
        Dim FrmAux As New frmPreviewReport, StrSQL As String = ""
        FrmAux.StrName = "Generar Factura"
        FrmAux.StrSubName = "Generación de Facturas a Clientes"

        'Compongo la sql
        StrSQL &= IIf(StrSQL.Length > 0, " AND ", "") & " {app_empresa.id}=" & My.m_app.GetValue("id_empresa")
        StrSQL &= IIf(StrSQL.Length > 0, " AND ", "") & " {db_facturas.id}=" & id


        FrmAux.RptPrint = New crtFactura

        FrmAux.StrSQL = StrSQL
        FrmAux.ShowDialog(Me)

        Me.load_HistoryMesa()
    End Sub



    Private Sub load_HistoryMesa()
        'Configuro listas
        With Me.lstHistory
            .Items.Clear()

            .Columns.Clear()
            .Columns.Add("#", 30, HorizontalAlignment.Right)
            .Columns.Add("Ref.", 50, HorizontalAlignment.Left)
            .Columns.Add("Fecha", 90, HorizontalAlignment.Left)
            .Columns.Add("Total", 50, HorizontalAlignment.Right)
            .CheckBoxes = True
        End With

        Dim rst As ADODB.Recordset = My.m_db.GetRst("SELECT id,fh_update,total FROM db_tickets WHERE id_caja=-1 AND estado='FINALIZADO' AND id<>" & Me.idRef & " AND id_referencia=" & Me.idMesa & " ORDER BY fh_update ASC")
        Dim dblTotal As Double = 0
        While Not rst.EOF
            Me.lstHistory.Items.Add("")
            With Me.lstHistory.Items(Me.lstHistory.Items.Count - 1)
                .SubItems.Add(rst("id").Value)
                .SubItems.Add(Format(rst("fh_update").Value, "dd/MM HH:mm"))
                .SubItems.Add(Format(rst("total").Value, "0.00"))
            End With

            dblTotal += rst("total").Value
            rst.MoveNext()
        End While
        My.m_db.CloseRst(rst)

        Me.lblHistoryTotal.Text = Format(dblTotal, "0.00")
    End Sub


    Private Sub GroupInfo_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GroupInfo.Enter

    End Sub





End Class