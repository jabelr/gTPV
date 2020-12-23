Public Class frmPaneldeSituacion
    Private _arrImgs() As PictureBox = Nothing
    Private _arrNames() As Label = Nothing

#Region "Variables Constantes"
    '# Contantes comunes sobre el formulario

    'Localizacion de inicio para el primer boton
    Dim _left As Integer = 1
    Dim _top As Integer = 1

    Private _default_color As Color = Color.YellowGreen
#End Region

#Region "Eventos Principales"
    Private Sub frmPaneldeSituacion_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyValue = Keys.Escape Then Me.Close()
    End Sub

    Private Sub frmPaneldeSituacion_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.Size = Screen.PrimaryScreen.WorkingArea.Size

        'Inicializo entorno
        If Not IsNothing(Me.Owner) Then
            Me.PnlBody.Left = CType(Me.Owner, frmMain).PnlBody.Left
            Me.PnlBody.Top = CType(Me.Owner, frmMain).PnlBody.Top
        Else
            Me.PnlBody.Left = (Me.Width - Me.PnlBody.Width) / 2
            Me.PnlBody.Top = (Me.SplitContainer.Panel2.Height - Me.PnlBody.Height) / 2 + (IIf(My.m_opt.swNoteBook, Me.SplitContainer.Panel1.Height, 0))
        End If

        Me.PnlBody.Visible = True

        'ReDim _arrImgs(-1)
        'ReDim _arrNames(-1)
        Dim i As Integer = -1
        Dim rst As ADODB.Recordset ', rstAux As ADODB.Recordset

        ''### Si la aplicacion no esta registrada 
        'If Not My.m_app.IsRegister AndAlso DateDiff(DateInterval.Day, My.m_app.GetDate_AppCode, Now) >= 7 Then
        '    Me.PnlDemo.Visible = Not My.m_app.IsRegister
        '    Me.LblDemoTime.Text = "Quedan " & DateDiff(DateInterval.Day, Now, My.m_app.GetDate_AppCode.AddDays(gDevelop.m_app.DAYS_EXPIRE)) & " días para que caduque el código de aplicación."
        'End If

        ' CASHLOGY
        Me.pnlCashLogy.Left = 10
        Me.pnlCashLogy.Top = 5
        Me.BtHistory_Edit.Enabled = Not My.MyHardware.cashlogy_sw

        '### Cargo las zonas
        ' Cargo las zonas disponibles
        rst = My.m_db.GetRst("SELECT * FROM db_zonas ORDER BY id ASC")
        Me.CbZonas.Items.Clear()
        While Not rst.EOF
            Me.CbZonas.Items.Add(rst("name").Value & Space(100) & rst("id").Value)
            rst.MoveNext()
        End While
        If My.m_app.GetValue("refZona", 0) >= Me.CbZonas.Items.Count Then
            Me.CbZonas.SelectedIndex = 0
        Else
            Me.CbZonas.SelectedIndex = My.m_app.GetValue("refZona", 0)
        End If

        Me.CbZonas.Enabled = (Me.CbZonas.Items.Count > 1)
        Me.PnlZonas.Visible = (Me.CbZonas.Items.Count > 1)
        My.m_db.CloseRst(rst)

        'Cargo el historial de tickets
        Me.Load_TicketsHistory(True)

        'Compruebo el número de ticket actuales
        If Me.rstHistory.RecordCount > My.N_TICKETSHISTORY Then MsgBox("Atención, en la caja actual ha alcanzado la cifra de " & Me.rstHistory.RecordCount & " tickets, por ello se le notifica que es una cifra superior a los " & My.N_TICKETSHISTORY & " tickets recomendados por caja." & vbCrLf & vbCrLf & "Un cierre de Caja de vez en cuando es recomendable :)", MsgBoxStyle.Exclamation)

        'Establezco la fecha y hora
        Me.LblHour.Text = Now.ToString("HH:mm")
        Me.TmHour.Enabled = True

        Me.BtHistory_Print.Enabled = Not (My.MyHardware.IdPort = 0)

        Me.BtReparto.Visible = (My.m_opt.modo_compatibilidad = "REPARTO")
    End Sub
#End Region

#Region "Manejadores"
    'Manejador Principal (Shell)
    Private Sub ShellApp(ByVal command As String)
        Dim cmd As String = command.ToUpper

        Select Case cmd
            Case "CAJADIRECTA"
                'Obtengo Camarero
                Dim id As Integer = My.ValidateUser()
                If id = -1 Then Exit Sub

                If Not My.m_opt.swResponsive Then
                    'Muestro panel de ventas
                    With My.Forms.frmPaneldeVentas
                        .idRef = -1
                        .idMesa = -1
                        .idUser = id
                        .swCajaDirecta = True

                        .ShowDialog(Me)
                        .Dispose()
                    End With
                Else
                    'Muestro panel de ventas
                    With My.Forms.frmPaneldeVentasResponsive
                        .idRef = -1
                        .idMesa = -1
                        .idUser = id
                        .swCajaDirecta = True

                        .ShowDialog(Me)
                        .Dispose()
                    End With
                End If
                'Recargo valores
                Me.Load_TicketsHistory(True)

            Case "REPARTO"
                'Compruebo si hay usuarios marcados para el reparto
                Dim rst As ADODB.Recordset = Nothing
                rst = My.m_db.GetRst("SELECT id FROM db_usuarios WHERE swRepartidor=TRUE")
                If rst.RecordCount = 0 Then
                    MsgBox("No se ha establecido ningun empleado como repartidor, establezca uno para poder continuar.", MsgBoxStyle.Critical)
                    My.m_db.CloseRst(rst)
                    Exit Sub
                End If
                My.m_db.CloseRst(rst)

                frmPedidos.ShowDialog()
                frmPedidos.Dispose()

                'Cargo historial 
                Me.Load_TicketsHistory(True)

                Exit Sub
                'Selecciono el cliente
                frmPedidos_SelectCliente.IdRef = -1
                frmPedidos_SelectCliente.ConfigureApp("clientes")
                frmPedidos_SelectCliente.ShowDialog(Me)
                If frmPedidos_SelectCliente.DialogResult <> Windows.Forms.DialogResult.OK Then
                    frmPedidos_SelectCliente.Dispose()
                    frmPedidos_SelectCliente = Nothing
                    Exit Sub
                End If

                frmPaneldeVentas_Facturar.Dispose()
                frmPedidos_SelectCliente = Nothing


                'Obtengo el repartidor
                Dim id As Integer = My.ValidateUser(True)
                If id = -1 Then Exit Sub


                MsgBox("reparto para " & id)

            Case "CANCEL"
                If MsgBox("¿Esta seguro que desea descartar los cambios que haya realizado?", MsgBoxStyle.YesNo + MsgBoxStyle.Question, My.APP_NAME) <> MsgBoxResult.Yes Then Exit Select
                Me.Close()

            Case "MINIMIZE"
                frm_AppIsMinimized.Show()

                Me.Owner.WindowState = FormWindowState.Minimized
                Me.WindowState = FormWindowState.Minimized

            Case "CLOSE"
                Me.Close()
            Case Else
                My.m_msg.MessageError(Me, "Comando de acción de " & cmd & " no controlado.")
        End Select
    End Sub
#End Region

#Region "Eventos Auxiliares"
    Private Sub Buttons_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtClose.Click, BtCajaDirecta.Click, BtReparto.Click
        'Si no tiene establecido el tag mando un error
        If IsNothing(CType(sender, Button).Tag) OrElse CType(sender, Button).Tag.ToString.Length = 0 Then
            My.m_msg.MessageError(sender, "Tag de control de elemento no referenciado")
            Exit Sub
        End If

        ShellApp(CType(sender, Button).Tag.ToString)
    End Sub

    Private Sub m_logo_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles m_logo.DoubleClick
        My.OpenCajon()
    End Sub

    Private Sub TmHour_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TmHour.Tick
        Me.LblHour.Text = Now.ToString("HH:mm")
        Me.checkStates()
    End Sub

    Private Sub BtPrintLastTicket_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        My.PrintTicket(Me.LblLastRef.Text)
    End Sub
#End Region

#Region "Control de Situacion"
    Private Function AddDesignItem(ByVal id_img As Integer, ByVal img As Bitmap, ByVal pos_x As Integer, ByVal pos_y As Integer) As Integer
        'Return: el id de imagen

        '### Creo y agrego la imagen y el label de información
        Dim pos As Integer = Me._arrImgs.Length
        ReDim Preserve Me._arrImgs(pos)
        ReDim Preserve Me._arrNames(pos)

        'Configuro la imagen
        Me._arrImgs(pos) = New PictureBox
        With Me._arrImgs(pos)
            .AllowDrop = False
            .Cursor = Cursors.Hand
            .Image = img
            .Location = New Point(pos_x, pos_y)
            .SizeMode = PictureBoxSizeMode.AutoSize
            .Text = pos                'Posicion dentro del array
            .Visible = True
        End With

        'Configuro la etiqueta
        Me._arrNames(pos) = New Label
        With Me._arrNames(pos)
            .AutoSize = False
            .Font = New Font("Verdana", 9, FontStyle.Bold)
            .ForeColor = Me._default_color
            .Location = New Point(Me._arrImgs(pos).Left - (Me._arrImgs(pos).Width / 2), Me._arrImgs(pos).Top + Me._arrImgs(pos).Height + 1)
            .Size = New Size(Me._arrImgs(pos).Width * 2, 16)
            .TextAlign = ContentAlignment.MiddleCenter
            .BackColor = Color.Transparent
        End With

        Me.PicPlano.Controls.Add(Me._arrImgs(pos))
        Me.PicPlano.Controls.Add(Me._arrNames(pos))

        'Asigno Eventos
        AddHandler Me._arrImgs(pos).Click, AddressOf ObjectImg_Click
        'AddHandler Me._arrImgs(pos).MouseDown, AddressOf PicObjectMove_MouseDown
        'AddHandler Me._arrImgs(pos).DragOver, AddressOf Drag_Over
        'AddHandler Me._arrImgs(pos).GiveFeedback, AddressOf SetCursorFeedback
        Return pos
    End Function

    ' Click sobre imagen de la mesa
    Private Sub ObjectImg_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'Obtengo Camarero
        Dim id As Integer = My.ValidateUser()
        If id = -1 Then Exit Sub

        If Not My.m_opt.swResponsive Then
            'Muestro panel de ventas
            With My.Forms.frmPaneldeVentas
                .idRef = CType(sender, PictureBox).Tag               'El id del ticket
                .idMesa = CType(sender, PictureBox).Name          'El id de la mesa
                .idUser = id                                                    'El usuario que edita la mesa
                .swCajaDirecta = False

                .ShowDialog(Me)
                If .DialogResult = Windows.Forms.DialogResult.OK Then
                    If .swKill Then
                        'Pongo estado por defecto
                        Me.UpdateState_Ticket(CType(sender, PictureBox).Text, -1)

                        Me.LoadInfo_LastTicket(.idRef)

                        Me.Load_TicketsHistory(True)

                    ElseIf .swReload Then
                        'Actualizo valores
                        Me.UpdateState_Ticket(CType(sender, PictureBox).Text, .idRef)

                        If .swChangeMesa Then Me.LoadZonas()
                    End If
                End If
                .Dispose()
            End With

        Else

            'Muestro panel de ventas
            With My.Forms.frmPaneldeVentasResponsive
                .idRef = CType(sender, PictureBox).Tag               'El id del ticket
                .idMesa = CType(sender, PictureBox).Name          'El id de la mesa
                .idUser = id                                                    'El usuario que edita la mesa
                .swCajaDirecta = False

                .ShowDialog(Me)
                If .DialogResult = Windows.Forms.DialogResult.OK Then
                    If .swKill Then
                        'Pongo estado por defecto
                        Me.UpdateState_Ticket(CType(sender, PictureBox).Text, -1)

                        Me.LoadInfo_LastTicket(.idRef)

                        Me.Load_TicketsHistory(True)

                    ElseIf .swReload Then
                        'Actualizo valores
                        Me.UpdateState_Ticket(CType(sender, PictureBox).Text, .idRef)

                        If .swChangeMesa Then Me.LoadZonas()
                    End If
                End If
                .Dispose()
            End With

        End If

        Me.LblHour.Text = Now.ToString("HH:mm")
        Me.TmHour.Enabled = True
    End Sub

    'Funcion para cargarme los datos de una mesa
    Private Sub UpdateState_Ticket(ByVal idArray As Integer, ByVal id As Integer)
        Dim i As Integer = -1

        If id = -1 Then
            'Restuaro mesa a estado inicial
            Me._arrImgs(idArray).Tag = -1

            'Modifico los valores de la etiqueta
            With Me._arrNames(idArray)
                .Font = New Font("Verdana", 9, FontStyle.Bold)
                .ForeColor = Me._default_color
                .Text = .Tag
            End With
            Exit Sub
        End If

        'Tengo que cargar los nuevos datos de la mesa
        Dim idAux As Integer = -1, sql As String = ""

        'Compongo la sql y proceso datos
        sql = "SELECT db_tickets.id,db_tickets.id_referencia,db_tickets.name_mesa,db_usuarios.color "
        sql &= "FROM db_tickets,db_usuarios "
        sql &= "WHERE db_usuarios.id=db_tickets.id_user AND db_tickets.id=" & id
        'sql &= "WHERE db_usuarios.id=db_tickets.id_user AND db_tickets.estado='PENDIENTE' AND id_caja=" & My.ID_CAJA

        Dim rst As ADODB.Recordset = My.m_db.GetRst(sql)
        'Compruebo todas las mesas hasta dar con la usada
        For i = 0 To Me._arrImgs.Length - 1
            If Me._arrImgs(i).Name = rst("id_referencia").Value Then
                Me._arrImgs(i).Tag = id

                'Modifico los valores de la etiqueta
                With Me._arrNames(i)
                    .Font = New Font("Verdana", 10, FontStyle.Bold)
                    .ForeColor = Color.FromArgb(rst("color").Value)
                    .Text = rst("name_mesa").Value
                End With
                Exit For
                'ElseIf Val(Me._arrNames(i).Tag) = 0 Then
                '    'Actualizo el estado por defecto
                '    With Me._arrNames(i)
                '        .Enabled = True
                '        .Font = New Font("Verdana", 9, FontStyle.Bold)
                '        .ForeColor = Me._default_color
                '        '.Text = rst("name_mesa").Value
                '    End With
            End If
        Next
    End Sub

    'Funcion para cargar todos los tickets pendientes
    Private Sub Load_TicketsPendientes()
        Dim i As Integer = -1, idAux As Integer = -1, sql As String = ""

        'Compongo la sql y proceso datos
        sql = "SELECT db_tickets.id,db_tickets.id_referencia,db_tickets.name_mesa,db_usuarios.color "
        sql &= "FROM db_tickets,db_usuarios "
        sql &= "WHERE db_usuarios.id=db_tickets.id_user AND db_tickets.estado='PENDIENTE' AND id_caja=-1"

        Dim rst As ADODB.Recordset = My.m_db.GetRst(sql)
        While Not rst.EOF
            idAux = rst("id_referencia").Value
            For i = 0 To Me._arrImgs.Length - 1
                If Me._arrImgs(i).Name = idAux Then
                    Me._arrImgs(i).Tag = rst("id").Value

                    'Modifico los valores de la etiqueta
                    With Me._arrNames(i)
                        .Font = New Font("Verdana", 10, FontStyle.Bold)
                        .ForeColor = Color.FromArgb(rst("color").Value)
                        .Text = rst("name_mesa").Value
                    End With
                    Exit For
                End If
            Next
            rst.MoveNext()
        End While
        My.m_db.CloseRst(rst)
    End Sub

    'Cargo información sobre el último ticket abierto
    Private Sub LoadInfo_LastTicket(ByVal id_ticket As Integer)
        Me.LblMesa.Text = ""
        Me.LblTotal.Text = ""
        Me.LblLastRef.Text = ""
        Me.PnlLast.Visible = (id_ticket <> -1)

        If id_ticket = -1 Then Exit Sub
        Dim sql As String = "SELECT db_tickets.id_referencia,db_tickets.total,db_usuarios.name FROM db_tickets,db_usuarios WHERE db_usuarios.id=db_tickets.id_user AND db_tickets.id=" & id_ticket
        Dim rst As ADODB.Recordset = My.m_db.GetRst(sql)
        If rst.RecordCount <= 0 Then Exit Sub
        Me.LblMesa.Text = rst("name").Value
        Me.LblTotal.Text = Format(rst("total").Value, "0.00") & " " & System.Threading.Thread.CurrentThread.CurrentCulture.NumberFormat.CurrencySymbol

        If rst("id_referencia").Value = -1 Then         'Si es caja directa
            Me.LblMesa.Text = "CAJA DIRECTA"
            sql = ""
        Else
            sql = "SELECT name FROM db_design WHERE id=" & rst("id_referencia").Value
        End If
        My.m_db.CloseRst(rst)

        If sql.Length > 0 Then     'Obtengo el nombre de la mesa
            rst = My.m_db.GetRst(sql)
            Me.LblMesa.Text = rst("name").Value
            My.m_db.CloseRst(rst)
        End If

        Me.LblLastRef.Text = id_ticket
        Me.PnlLast.Visible = True
        Me.Group_Last.Enabled = True
    End Sub

    'Chequeo el estado de las mesas
    Private Sub checkStates()
        Dim i As Integer = 0, sql As String = "", rst As ADODB.Recordset = Nothing

        'Compongo la sql para procesar datos
        sql = "SELECT db_tickets.id,db_tickets.id_referencia,db_tickets.name_mesa,db_usuarios.color "
        sql &= "FROM db_tickets,db_usuarios "
        sql &= "WHERE db_usuarios.id=db_tickets.id_user AND db_tickets.estado='PENDIENTE' AND id_caja=-1 AND db_tickets.id_referencia="

        For i = 0 To Me._arrImgs.Length - 1
            rst = My.m_db.GetRst(sql & Me._arrImgs(i).Name)

            'Si no encuentra nada es porque la mesa esta vacia
            If rst.RecordCount = 0 Then
                Me._arrImgs(i).Tag = -1

                'Modifico los valores de la etiqueta
                With Me._arrNames(i)
                    .Font = New Font("Verdana", 9, FontStyle.Bold)
                    .ForeColor = Me._default_color
                    .Text = .Tag
                End With
            Else
                Me._arrImgs(i).Tag = rst("id").Value

                'Modifico los valores de la etiqueta
                With Me._arrNames(i)
                    .Font = New Font("Verdana", 10, FontStyle.Bold)
                    .ForeColor = Color.FromArgb(rst("color").Value)
                    .Text = rst("name_mesa").Value
                End With
            End If
        Next
    End Sub
#End Region

#Region "Historial de Tickets"
    Private rstHistory As ADODB.Recordset = Nothing          'Controlo los tickets de la caja actual

    'Cargo información sobre el historico de tickets
    Private Sub Load_TicketsHistory(ByVal ReloadHistory As Boolean)
        'Limpio valores
        Me.LblHistory_Ref.Text = ""
        Me.LblHistory_Fh.Text = ""
        Me.LblHistory_Mesa.Text = ""
        Me.LblHistory_Empleado.Text = ""
        Me.LblHistory_Total.Text = ""

        'Si tengo que recargar la lista de tickets
        If ReloadHistory Then
            Me.rstHistory = My.m_db.GetRst("SELECT db_tickets.id,db_tickets.id_referencia,db_tickets.name_mesa,db_tickets.n_ticket,db_tickets.total,db_tickets.id_user,db_tickets.fh_finaliza,db_usuarios.name FROM db_tickets,db_usuarios WHERE db_usuarios.id=db_tickets.id_user AND id_caja=-1 AND db_tickets.estado='FINALIZADO' AND (db_tickets.id_pedido=0 OR isnull(db_tickets.id_pedido)) ORDER BY fh_finaliza DESC")
            If Me.rstHistory.RecordCount = 0 Then
                Me.PnlHistory.Enabled = False
                Exit Sub
            End If

            Me.BtHistory_Next.Enabled = Not (Me.rstHistory.Bookmark = 1)
            Me.BtHistory_Previous.Enabled = Not (Me.rstHistory.Bookmark = Me.rstHistory.RecordCount)
        End If

        'Asigno los valores del ticket
        Me.LblHistory_Ref.Tag = Me.rstHistory("id").Value
        If Not IsDBNull(Me.rstHistory("n_ticket").Value) AndAlso Len(Me.rstHistory("n_ticket").Value) > 0 Then
            Me.LblHistory_Ref.Text = "Ticket: " & Me.rstHistory("n_ticket").Value
        Else
            Me.LblHistory_Ref.Text = "Ref. Ticket: " & Me.rstHistory("id").Value
        End If
        Me.LblHistory_Fh.Text = "Fecha: " & Format(Me.rstHistory("fh_finaliza").Value, "dd/MM/yyyy HH:mm")
        Me.LblHistory_Empleado.Tag = Me.rstHistory("id_user").Value
        Me.LblHistory_Empleado.Text = Me.rstHistory("name").Value
        Me.LblHistory_Total.Text = Format(Me.rstHistory("total").Value, "0.00") & " " & System.Threading.Thread.CurrentThread.CurrentCulture.NumberFormat.CurrencySymbol
        Me.LblHistory_Mesa.Text = Me.rstHistory("name_mesa").Value


        Me.GroupHistory.Text = "Historial de Tickets (" & Me.rstHistory.Bookmark & "/" & Me.rstHistory.RecordCount & ")"

        'Obtengo la mesa en la que ha sido
        Me.LblHistory_Mesa.Tag = Me.rstHistory("id_referencia").Value
        'If Me.rstHistory("id_referencia").Value = -1 Then         'Si es caja directa
        '    Me.LblHistory_Mesa.Text = "CAJA DIRECTA"
        'Else
        '    Dim rst As ADODB.Recordset = My.m_db.GetRst("SELECT name FROM db_design WHERE id=" & Me.rstHistory("id_referencia").Value)
        '    Me.LblHistory_Mesa.Text = rst("name").Value
        '    My.m_db.CloseRst(rst)
        'End If

        Me.PnlHistory.Enabled = True
        'Me.GroupHistory.Visible = True


        'Me.LblLastRef.Text = id_ticket
        'Me.PnlLast.Visible = True
        'Me.Group_Last.Enabled = True
    End Sub

    'Me muevo en el historial de los tickets de la caja actual
    Private Sub BtHistory_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtHistory_Previous.Click, BtHistory_Next.Click
        'Hago el movimiento
        Select Case True
            Case sender Is Me.BtHistory_Next : Me.rstHistory.MovePrevious()
            Case sender Is Me.BtHistory_Previous : Me.rstHistory.MoveNext()
        End Select

        'Establezco estados y recargo
        'Me.BtHistory_Next.Enabled = Not Me.rstHistory.BOF
        'Me.BtHistory_Previous.Enabled = Not Me.rstHistory.BOF

        Me.BtHistory_Next.Enabled = Not (Me.rstHistory.Bookmark = 1)
        Me.BtHistory_Previous.Enabled = Not (Me.rstHistory.Bookmark = Me.rstHistory.RecordCount)
        Me.Load_TicketsHistory(False)

    End Sub

    Private Sub BtHistory_Print_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtHistory_Print.Click
        My.PrintTicket(Me.LblHistory_Ref.Tag)
    End Sub

    Private Sub BtHistory_Edit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtHistory_Edit.Click
        If Not My.m_opt.swResponsive Then
            'Muestro panel de ventas

            With My.Forms.frmPaneldeVentas
                .idRef = Me.LblHistory_Ref.Tag                           'El id del ticket
                .idMesa = Me.LblHistory_Mesa.Tag          'El id de la mesa
                .idUser = Me.LblHistory_Empleado.Tag        'El usuario que edita la mesa
                .swCajaDirecta = Not (Me.LblHistory_Mesa.Tag = -1)

                .swFinalizado = True

                .ShowDialog(Me)
                If .DialogResult = Windows.Forms.DialogResult.OK Then
                    Me.LoadInfo_LastTicket(.idRef)
                    Me.Load_TicketsHistory(True)
                End If
                .Dispose()
            End With
        Else
            'Muestro panel de ventas
            With My.Forms.frmPaneldeVentasResponsive
                .idRef = Me.LblHistory_Ref.Tag                           'El id del ticket
                .idMesa = Me.LblHistory_Mesa.Tag          'El id de la mesa
                .idUser = Me.LblHistory_Empleado.Tag        'El usuario que edita la mesa
                .swCajaDirecta = Not (Me.LblHistory_Mesa.Tag = -1)

                .swFinalizado = True

                .ShowDialog(Me)
                If .DialogResult = Windows.Forms.DialogResult.OK Then
                    Me.LoadInfo_LastTicket(.idRef)
                    Me.Load_TicketsHistory(True)
                End If
                .Dispose()
            End With
        End If
    End Sub
#End Region

#Region "Zonas"
    Private Sub LoadZonas()
        Dim i As Integer = 0

        'Elimino imagenes de la zona anterior y reseteo valores
        If Not IsNothing(Me._arrImgs) Then
            For i = 0 To Me._arrImgs.Length - 1
                Me._arrImgs(i).Dispose()
                Me._arrNames(i).Dispose()
            Next
        End If
        ReDim _arrImgs(-1)
        ReDim _arrNames(-1)

        '### Cargo las mesas guardadas
        Dim rst As ADODB.Recordset = My.m_db.GetRst("SELECT db_design.*,app_design.img FROM db_design,app_design WHERE app_design.id=db_design.id_img AND db_design.id_zona=" & Me.CbZonas.Text.Substring(100).Trim & " ORDER BY db_design.id")
        While Not rst.EOF
            i = Me.AddDesignItem(rst("id_img").Value, My.m_db.data_GetImgRow(rst("img")), rst("pos_x").Value, rst("pos_y").Value)
            Me._arrImgs(i).Name = rst("id").Value        'El id de la mesa
            Me._arrImgs(i).Tag = -1                        'El id del registro

            Me._arrNames(i).Text = rst("name").Value
            Me._arrNames(i).Tag = rst("name").Value
            Me.ToolTip.SetToolTip(Me._arrImgs(i), "Click Iniciar el proceso de venta")

            rst.MoveNext()
        End While
        My.m_db.CloseRst(rst)


        'Cargo los tickets pendientes 
        Me.Load_TicketsPendientes()
    End Sub

    Private Sub CbZonas_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CbZonas.SelectedIndexChanged
        My.m_app.SetValue("refZona") = Me.CbZonas.SelectedIndex

        Me.BtZona_Left.Enabled = (Me.CbZonas.SelectedIndex > 0)
        Me.BtZona_Right.Enabled = (Me.CbZonas.SelectedIndex < Me.CbZonas.Items.Count - 1)

        Me.LoadZonas()
    End Sub

    Private Sub BtZonas_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtZona_Left.Click, BtZona_Right.Click
        Select Case True
            Case sender Is Me.BtZona_Left : Me.CbZonas.SelectedIndex -= 1
            Case sender Is Me.BtZona_Right : Me.CbZonas.SelectedIndex += 1
        End Select
    End Sub

#End Region

    
    'Private Sub BtKeyBoard_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    My.ShellExecute(0, Nothing, "osk.exe", Nothing, Nothing, 0)
    'End Sub


    
    Private Sub tmrMesas_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tmrMesas.Tick
        Me.LoadZonas()
    End Sub

    Private Sub LblHour_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LblHour.Click
        My.OpenCajon()
    End Sub

    Private Sub LblSubTitle_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LblSubTitle.Click
        Dim id As Integer = My.ValidateUser()
        If id = -1 Then Exit Sub

        frmPaneldeVentas_CobraCashlogy.id_User = id
        frmPaneldeVentas_CobraCashlogy.DblTotal = CDbl("1,10")
        frmPaneldeVentas_CobraCashlogy.ShowDialog()
        frmPaneldeVentas_CobraCashlogy.Dispose()
        frmPaneldeVentas_CobraCashlogy = Nothing
    End Sub

    Private Sub BtKeyBoard_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtKeyBoard.Click
        If Not My.MyHardware.cashlogy_sw Then Exit Sub

        Dim _id As Integer = My.ValidateUser()
        If _id = -1 Then Exit Sub

        Dim rst As ADODB.Recordset = My.m_db.GetRst("SELECT tipo_user FROM db_usuarios WHERE id=" & _id)
        If rst.RecordCount = 0 Then
            MsgBox("Imposible localizar usuario.", MsgBoxStyle.Critical)
            Exit Sub
        End If

        Me.ctCashlogy_config.Enabled = (rst("tipo_user").Value = "MAESTRO")

        Me.pnlCashLogy.Visible = Not Me.pnlCashLogy.Visible



    End Sub

    Private Sub ctCashlogy_DarCambio_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ctCashlogy_DarCambio.Click
        Dim str As String = ""
        My.cashlogy_Send("#H#a#")
        str = My.cashlogy_read()

        If str.Substring(0, 11) <> "#WR:CANCEL#" Then

        End If

        Me.pnlCashLogy.Visible = False
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click

    End Sub

    Private Sub ctCashlogy_config_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ctCashlogy_config.Click
        Dim str As String = ""
        My.cashlogy_Send("#G#1#1#1#1#1#1#1#1#1#1#1#1#1#")
        'str = My.cashlogy_read()

        Me.pnlCashLogy.Visible = False
    End Sub
End Class