Imports gTPV.My.appApoyo

Public Class frmReservas
    Private _day As Integer = -1
    Private _month As Integer = -1
    Private _year As Integer = -1

#Region "Variables Constantes"
    '# Contantes comunes sobre el formulario
    ' Nº de dias a lo ancho y a lo alto a mostrar
    Dim _x As Integer = 7
    Dim _y As Integer = 6

    'Localizacion de inicio para el primer boton
    Dim _left As Integer = 1
    Dim _top As Integer = 1

#End Region

#Region "Eventos Principales"
    Private Sub frmAgenda_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.Size = Screen.PrimaryScreen.WorkingArea.Size

        'Centro el body
        Me.PnlBody.Left = CType(Me.Owner, frmMain).PnlBody.Left
        Me.PnlBody.Top = CType(Me.Owner, frmMain).PnlBody.Top + (IIf(My.m_opt.swNoteBook, Me.SplitContainer.Panel1.Height, 0))
        Me.PnlBody.Visible = True

        'Por defecto muestro el mes actual
        Me._month = Now.Month
        Me._year = Now.Year

        Me.LoadMonth()

        Me.ConfiguraListas()


        Me.DtReservas_Desde.Value = Now.AddMonths(-1)



    End Sub
#End Region

#Region "Manejadores"
    'Manejador Principal (Shell)
    Private Sub ShellApp(ByVal command As String)
        Dim cmd As String = command.ToUpper

        Select Case cmd
            Case "TICKET"
                Me.PrintTicketMenu()

            Case "REPORT"
                Me.PrintReportMenu()

            Case "NOW"
                'Por defecto muestro el mes actual
                Me._month = Now.Month
                Me._year = Now.Year

                Me.LoadMonth()

            Case "MINIMIZE"
                frm_AppIsMinimized.Show()

                Me.Owner.WindowState = FormWindowState.Minimized
                Me.WindowState = FormWindowState.Minimized

            Case "CLOSE"
                Me.Close()

            Case Else
                My.m_msg.MessageError(Me, "Comando de acción de " & cmd & " no controlada.")
        End Select
    End Sub
#End Region

#Region "Eventos Auxiliares"
    Private Sub Buttons_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtGoToNow.Click, BtClose.Click, BtPrintMenu.Click, BtGenerateTicket.Click
        'Si no tiene establecido el tag mando un error
        If IsNothing(CType(sender, Button).Tag) OrElse CType(sender, Button).Tag.ToString.Length = 0 Then
            My.m_msg.MessageError(sender, "Tag de control de elemento no referenciado")
            Exit Sub
        End If

        ShellApp(CType(sender, Button).Tag.ToString)
    End Sub

    Private Sub LstEventos_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles LstEventos.DoubleClick
        If Me.LstEventos.SelectedItems.Count <= 0 Then Exit Sub
        Me.AccionButtons_Click(Me.BtEdit, New System.EventArgs)
    End Sub

    Private Sub LstEventos_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LstEventos.SelectedIndexChanged
        Dim sw As Boolean = (Me.LstEventos.SelectedItems.Count > 0)
        Me.BtEdit.Enabled = sw
        Me.BtDell.Enabled = sw

    End Sub
#End Region

#Region "Control sobre el mes"
    Private Sub BtMonth_Move_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtMonth_Previous.Click, BtMonth_Next.Click
        Select Case True
            Case sender Is Me.BtMonth_Previous
                Me._month -= 1
                If Me._month <= 0 Then Me._month = 12 : Me._year -= 1

            Case sender Is Me.BtMonth_Next
                Me._month += 1
                If Me._month > 12 Then Me._month = 1 : Me._year += 1

        End Select

        Me.LoadMonth()
    End Sub

    Private Sub LoadMonth()
        Me.PnlDays.Visible = False
        Me.PnlAgenda.Visible = False
        Me.BtPrintMenu.Visible = False
        Me.BtGenerateTicket.Visible = False
        Me.LblMonth.Text = CDate("01/" & Me._month & "/" & Me._year).ToString("MMMM").ToUpper & " de " & Me._year

        Me._day = -1

        'Variables Auxiliares
        Dim i As Integer = 0, j As Integer = 0, n As Integer
        Dim rst As ADODB.Recordset = Nothing, str As String = ""

        '### Limpio anteriores controltes
        For i = Me.PnlDays.Controls.Count - 1 To 0 Step -1
            Me.PnlDays.Controls(i).Dispose()
        Next

        '### Agrego los botones de las imagenes
        i = CDate("01/" & Me._month & "/" & Me._year).DayOfWeek - 1
        If i < 0 Then i = 6

        Dim _fontstyle As FontStyle = FontStyle.Regular, sw As Boolean = False

        n = 1
        While n <= Date.DaysInMonth(Me._year, Me._month)
            ' Si es un dia pasado lo tacho
            sw = True
            _fontstyle = FontStyle.Regular
            If DateDiff(DateInterval.Day, Now, CDate(n.ToString("00") & "/" & Me._month.ToString("00") & "/" & Me._year)) >= 0 Then sw = False


            ' Creo y configuro el nuevo boton
            Dim bt As RadioButton
            bt = New RadioButton
            bt.Appearance = Appearance.Button

            If sw Then _fontstyle = FontStyle.Strikeout
            bt.Font = New Font("Verdana", IIf(sw, 7, 10), _fontstyle)

            bt.ImageAlign = ContentAlignment.TopCenter
            bt.Margin = New Padding(0)
            bt.Name = "day_" & n
            bt.Size = New Size(80, 74)
            bt.TabIndex = n
            bt.Location = New Point(_left + (bt.Width * i), _top + (bt.Height * j))
            bt.Text = " " & n & " "
            bt.TextAlign = ContentAlignment.BottomCenter
            bt.Tag = n
            bt.UseVisualStyleBackColor = True
            bt.UseMnemonic = False

            'Si tiene Resevas lo marco
            Dim rstTmp As ADODB.Recordset = My.m_db.GetRst("SELECT COUNT(id) as n FROM db_reservas WHERE fh_reserva=#" & CDate(n & "/" & Me._month & "/" & Me._year).ToString("MM-dd-yyyy") & "#")
            If rstTmp("n").Value > 0 Then
                bt.Image = Me.ImageList_day.Images(0)
                _fontstyle = FontStyle.Bold
                If sw Then _fontstyle = FontStyle.Bold + FontStyle.Strikeout
                bt.Font = New Font("Verdana", 12, _fontstyle)
            End If
            My.m_db.CloseRst(rstTmp)

            'Si es el dia actual lo marco
            If Me._month = Now.Month AndAlso n = Now.Day Then
                bt.Font = New Font("Verdana", 20, FontStyle.Bold)
                bt.Checked = True
                BtProcesaDay_Click(bt, New System.EventArgs)
            End If

            'Si es una reserva pasada lo marco
            If Me._month = Now.Month AndAlso n = Now.Day Then
                If sw Then _fontstyle = FontStyle.Bold + FontStyle.Strikeout
                bt.Font = New Font("Verdana", 16, _fontstyle)
            End If

            ' Asigno Eventos
            AddHandler bt.Click, AddressOf BtProcesaDay_Click

            Me.PnlDays.Controls.Add(bt)
            bt.Visible = True

            'Extra info por el tooltip
            'str = rst("name").Value
            'str &= vbCrLf & Space(7) & "Precio: " & Format(rst("pvp_iva").Value, "0.00") & " €"
            ''str &= vbCrLf
            'str &= vbCrLf & Space(7) & "Usos: " & IIf(rst("n_veces").Value = 0, "SIN USAR", rst("n_veces").Value & " usos")
            str = n
            Me.ToolTip.SetToolTip(bt, str)

            i += 1
            If i = _x Then
                i = 0
                j += 1
                If j >= _y Then Exit While
            End If


            n += 1
        End While
        Me.PnlDays.Visible = True
    End Sub

    ' Proceso el dia seleccionado
    Private Sub BtProcesaDay_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.LblDaySelect.Text = CDate(CType(sender, RadioButton).Tag & "/" & Format(Me._month, "00") & "/" & Me._year).ToString("dddd, dd \de MMMM \de yyyy")
        Me._day = CType(sender, RadioButton).Tag
        Me.LoadEventsDay()
        Me.PnlAgenda.Visible = True
        Me.BtPrintMenu.Visible = True
        Me.BtGenerateTicket.Visible = True

        'Permito operar en los controles del grupo si es un dia pasado
        'Me.GroupEdit.Enabled = Not CType(sender, RadioButton).Font.Strikeout
        'Me.BtNew.Enabled = Not CType(sender, RadioButton).Font.Strikeout
    End Sub

    ''Muestro un nuevo sobre el dia agregado
    'Private Sub BtProcesaDay_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs)
    '    Me.BtProcesaDay_Click(sender, e)
    '    Me.AccionButtons_Click(Me.BtNew, e)
    'End Sub

    Private Sub ChkShow_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChkShow_Reservas.CheckedChanged, ChkShow_Notas.CheckedChanged
        CType(sender, CheckBox).ImageIndex = IIf(CType(sender, CheckBox).Checked, 1, 0)
        If Me.Visible Then Me.LoadMonth()
    End Sub
#End Region

#Region "Control de Agenda"
    Private Sub ConfiguraListas()
        ' Eventos del dia seleccionado
        With Me.LstEventos.Columns
            .Clear()
            .Add("Ref.", 0, HorizontalAlignment.Right)
            .Add("Persona", 160, HorizontalAlignment.Left)
            .Add("Teléfono", 95, HorizontalAlignment.Left)
            .Add("#", 25, HorizontalAlignment.Right)
        End With
    End Sub

    Private Sub LoadEventsDay()
        ' Inicializo y limpio
        Me.LstEventos.Items.Clear()

        Dim i As Integer

        'Cargo los eventos del dia especificado
        Dim rstTmp As ADODB.Recordset, rst As ADODB.Recordset = My.m_db.GetRst("SELECT id,name,telefono FROM db_reservas WHERE fh_reserva=#" & CDate(Me._day & "/" & Me._month & "/" & Me._year).ToString("MM-dd-yyyy") & "#")
        While Not rst.EOF
            i = Me.LstEventos.Items.Count
            Me.LstEventos.Items.Add(rst("id").Value)
            Me.LstEventos.Items(i).SubItems.Add(rst("name").Value)
            Me.LstEventos.Items(i).SubItems.Add(rst("telefono").Value & "")

            'Obtengo el nº de articulos reservados
            rstTmp = My.m_db.GetRst("SELECT sum(ud) as tot FROM db_reservas_menu WHERE id_reserva=" & rst("id").Value)
            If IsDBNull(rstTmp("tot").Value) Then
                Me.LstEventos.Items(i).SubItems.Add(0)
            Else
                Me.LstEventos.Items(i).SubItems.Add(rstTmp("tot").Value)
            End If
            My.m_db.CloseRst(rstTmp)

            rst.MoveNext()
        End While
        My.m_db.CloseRst(rst)

        If Me.LstEventos.Items.Count > 0 Then Me.LstEventos.Items(0).Selected = True

        Me.BtPrintMenu.Enabled = (Me.LstEventos.Items.Count > 0)
        Me.BtGenerateTicket.Enabled = (Me.LstEventos.Items.Count > 0)


        Dim sw As Boolean = (Me.LstEventos.SelectedItems.Count > 0)
        Me.BtEdit.Enabled = sw
        Me.BtDell.Enabled = sw






        ' Si hay elementos 
        'If Me.LstEventos.Items.Count > 0 Then
        '    'Sino tiene ningun evento en ese dia, por defecto NUEVO EVENTO
        '    'If Me.LstEventos.Items.Count <= 0 AndAlso Me.Visible Then AccionButtons_Click(Me.BtNew, New System.EventArgs)

        '    '' Cargo el acumulado de menus 
        '    'rst = My.m_db.GetRst("SELECT DISTINCT db_reservas_menu.id_articulo,db_articulos.name FROM db_reservas,db_reservas_menu,db_articulos WHERE db_articulos.id=db_reservas_menu.id_articulo AND db_reservas_menu.id_reserva=db_reservas_menu.id AND db_reservas.fh_reserva=#" & CDate(Me._day & "/" & Me._month & "/" & Me._year).ToString("MM-dd-yyyy") & "#")
        '    'While Not rst.EOF
        '    '    i = Me.LstAcumulados.Items.Count
        '    '    With Me.LstAcumulados.Items
        '    '        .Add(0)
        '    '        .Add(rst("name").Value)
        '    '    End With
        '    '    'rsttmp= my.m_db.GetRst("
        '    '    rst.MoveNext()
        '    'End While
        '    'My.m_db.CloseRst(rst)

        '    Me.BtPrintMenu.Enabled = True
        'End If
    End Sub

    'Contols de los botones sobre el "day"
    Private Sub AccionButtons_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtNew.Click, BtEdit.Click, BtDell.Click
        Select Case True
            Case sender Is Me.BtNew
                Dim _id As Integer = My.ValidateUser()
                If _id = -1 Then Exit Sub


                frmReservas_Evento.IdRef = 0
                frmReservas_Evento.idUser = _id
                frmReservas_Evento.fhEvento = CDate(Me._day & "/" & Me._month & "/" & Me._year)
                frmReservas_Evento.ShowDialog(Me)
                If frmReservas_Evento.DialogResult <> Windows.Forms.DialogResult.OK Then
                    frmReservas_Evento.Dispose()
                    Exit Sub
                End If
                If frmReservas_Evento.swPrint Then Me.PrintTicketReserva(frmReservas_Evento.IdRef)

                frmReservas_Evento.Dispose()
                CType(Me.PnlDays.Controls("day_" & Me._day), RadioButton).Image = Me.ImageList_day.Images(0)
                CType(Me.PnlDays.Controls("day_" & Me._day), RadioButton).Font = New Font("Verdana", 12, FontStyle.Bold)
                Me.LoadEventsDay()

            Case sender Is Me.BtEdit
                Dim _id As Integer = My.ValidateUser()
                If _id = -1 Then Exit Sub


                If Me.LstEventos.SelectedItems.Count <= 0 Then Exit Select
                frmReservas_Evento.IdRef = Me.LstEventos.SelectedItems(0).Text
                frmReservas_Evento.idUser = _id
                frmReservas_Evento.fhEvento = CDate(Me._day & "/" & Me._month & "/" & Me._year)
                frmReservas_Evento.ShowDialog(Me)
                If frmReservas_Evento.DialogResult <> Windows.Forms.DialogResult.OK Then
                    frmReservas_Evento.Dispose()
                    Exit Sub
                End If

                If frmReservas_Evento.swPrint Then Me.PrintTicketReserva(frmReservas_Evento.IdRef)

                frmReservas_Evento.Dispose()
                Me.LoadEventsDay()

            Case sender Is Me.BtDell
                If Me.LstEventos.SelectedItems.Count <= 0 Then Exit Select
                If MsgBox("¿Esta seguro de que desea eliminar el evento '" & Me.LstEventos.SelectedItems(0).SubItems(1).Text & "'?", MsgBoxStyle.OkCancel + MsgBoxStyle.Question) <> MsgBoxResult.Ok Then Exit Select
                'Elimino la linea seleccionado y cargo
                Dim str As String
                str = "DELETE * FROM db_reservas WHERE id=" & Me.LstEventos.SelectedItems(0).Text
                My.m_db.Execute(str)

                str = "DELETE * FROM db_reservas_menu WHERE id_reserva=" & Me.LstEventos.SelectedItems(0).Text
                My.m_db.Execute(str)

                Me.LoadEventsDay()
                If Me.LstEventos.Items.Count = 0 Then CType(Me.PnlDays.Controls("day_" & Me._day), RadioButton).Image = Nothing

                Me.LstEventos_SelectedIndexChanged(Me.LstEventos, New System.EventArgs)
        End Select
    End Sub
#End Region

#Region "Impresión del Parte Diario"
    Private Sub PrintReportMenu()
        Dim StrCab As String = "" ', StrSubCab As String = ""
        Dim StrSQL As String = ""
        Dim fh As Date = CDate(Me._day & "-" & Format(Me._month, "00") & "-" & Me._year)

        Dim FrmAux As New frmPreviewReport
        FrmAux.StrName = "Reservas del Dia"
        FrmAux.StrSubName = "Reserva de mesas y de los Menus para " & Format(fh, "dd/MMMM/yyyy")


        'Compongo la sql
        'StrSQL &= IIf(StrSQL.Length > 0, " AND ", "") & " {app_empresa.id}=" & My.m_app.GetValue("id_empresa")

        'Filtrado entre fechas
        StrSQL &= " {db_reservas.fh_reserva}=#" & Format(fh, "MM-dd-yyyy") & "#"

        FrmAux.RptPrint = New Crystal_MenuReservas
        CType(FrmAux.RptPrint, Crystal_MenuReservas).DataDefinition.FormulaFields("CabName").Text = "'Hoja de Reservas'"
        CType(FrmAux.RptPrint, Crystal_MenuReservas).DataDefinition.FormulaFields("SubCabName").Text = "'Menus reservados para " & Format(fh, "dd/MMMM/yyyy") & "'"

        CType(FrmAux.RptPrint, Crystal_MenuReservas).DataDefinition.FormulaFields("Fh_Reserva").Text = "'" & Format(fh, "dd \de MMMM \de yyyy") & "'"


        FrmAux.StrSQL = StrSQL
        FrmAux.ShowDialog(Me)
    End Sub

    'Función para imprimirme la reserva
    Private Sub PrintTicketReserva(ByVal id As Integer)
        If My.MyHardware.IdPort = 0 Then
            MsgBox("No se ha seleccionado ninguna impresora de tickets.", MsgBoxStyle.Critical)
            Exit Sub
        End If

        Dim rst As ADODB.Recordset = My.m_db.GetRst("SELECT * FROM db_reservas WHERE id=" & id)
        If rst.RecordCount = 0 Then
            MsgBox("Reserva no localizada", vbCritical)
            Exit Sub
        End If

        Dim str As String = "", strAux As String = "", strCod As String = ""

        '<!--### IMPRESIÓN POR LA IMPRESORA DE NOMBRE TICKETS ###-->
        Dim strPrinter As String = "tickets"
        Dim strText As String = ""

        'Imprimo la cabezera
        For i As Integer = 1 To 1
            StrAux = My.MyHardware.StrCab(i)
            StrCod = ""
            If StrAux.Length > My.MyHardware.Ancho Then StrAux = StrAux.Substring(1, My.MyHardware.Ancho)
            StrCod = Ticket_ConfigTextColor(StrCod, My.MyHardware.SwRed(i))
            StrCod = Ticket_ConfigTextStrong(StrCod, My.MyHardware.SwNegrita(i))
            StrCod = Ticket_ConfigTextSize(StrCod, My.MyHardware.SwGrande(i))
            strAux = Ticket_ConfigTextAling(strAux, IIf(My.MyHardware.SwCenter(i), 2, 0), My.MyHardware.SwGrande(i))
            If My.MyHardware.StrCab(i).Length <> 0 Then strText &= StrCod & StrAux & My.MyHardware.CodEsc_Cr

        Next
        strText &= My.MyHardware.CodEsc_Cr

        'Imprimo linea de separacion
        str = My.MyHardware.CodEsc_TextNormal & " " & My.MyHardware.CodEsc_Subrayado_True & Space(My.MyHardware.Ancho - 2) & My.MyHardware.CodEsc_Subrayado_False
        strText &= str & My.MyHardware.CodEsc_Cr

        'Titulo de la impresion
        str = "DETALLE DE RESERVA #" & id
        If Str.Length > My.MyHardware.Ancho Then Str = Str.Substring(0, My.MyHardware.Ancho - 1)
        Str = My.Ticket_ConfigTextAling(Str, HorizontalAlignment.Center, False)
        Str = My.Ticket_ConfigTextStrong(Str, True)
        strText &= str & My.MyHardware.CodEsc_Cr

        strText &= My.MyHardware.CodEsc_TextNormal & My.MyHardware.CodEsc_Cr

        'Detalles de la anotacion
        str = "Cliente: " & My.MyHardware.CodEsc_TextGrande & My.MyHardware.CodEsc_Negrita_True & rst("name").Value & My.MyHardware.CodEsc_Negrita_False
        strText &= str & My.MyHardware.CodEsc_TextNormal & My.MyHardware.CodEsc_Cr

        str = "Telefono: " & My.MyHardware.CodEsc_Negrita_True & rst("telefono").Value & My.MyHardware.CodEsc_Negrita_False
        strText &= str & My.MyHardware.CodEsc_TextNormal & My.MyHardware.CodEsc_Cr

        'Imprimo linea de separacion
        str = My.MyHardware.CodEsc_TextNormal & " " & My.MyHardware.CodEsc_Subrayado_True & Space(My.MyHardware.Ancho - 2) & My.MyHardware.CodEsc_Subrayado_False
        strText &= str & My.MyHardware.CodEsc_Cr

        str = "Fecha: " & My.MyHardware.CodEsc_Negrita_True & rst("fh_reserva").Value & My.MyHardware.CodEsc_Negrita_False
        strText &= str & My.MyHardware.CodEsc_TextNormal & My.MyHardware.CodEsc_Cr

        If rst("hora").Value.ToString.Length > 0 Then
            str = "Hora:  " & My.MyHardware.CodEsc_Negrita_True & rst("hora").Value & My.MyHardware.CodEsc_Negrita_False
            strText &= str & My.MyHardware.CodEsc_TextNormal & My.MyHardware.CodEsc_Cr
        End If

        'Imprimo linea de separacion
        str = My.MyHardware.CodEsc_TextNormal & " " & My.MyHardware.CodEsc_Subrayado_True & Space(My.MyHardware.Ancho - 2) & My.MyHardware.CodEsc_Subrayado_False
        strText &= str & My.MyHardware.CodEsc_Cr

        str = "Detalles:  "
        strText &= str & My.MyHardware.CodEsc_TextNormal & My.MyHardware.CodEsc_Cr

        str = My.MyHardware.CodEsc_TextGrande & rst("about").Value & ""
        strText &= str & My.MyHardware.CodEsc_TextNormal & My.MyHardware.CodEsc_Cr

        'Imprimo linea de separacion
        str = My.MyHardware.CodEsc_TextNormal & " " & My.MyHardware.CodEsc_Subrayado_True & Space(My.MyHardware.Ancho - 2) & My.MyHardware.CodEsc_Subrayado_False
        strText &= str & My.MyHardware.CodEsc_Cr


        'Cierro el puerto
        strText &= My.MyHardware.CodEsc_Salto & My.MyHardware.CodEsc_Cr
        RawPrinterHelper.SendStringToPrinter(strPrinter, strText)

        If Len(My.MyHardware.CodEsc_Cut) > 0 Then RawPrinterHelper.SendStringToPrinter(strPrinter, My.MyHardware.CodEsc_Cut & My.MyHardware.CodEsc_Cr)

        strText &= My.MyHardware.CodEsc_Salto & My.MyHardware.CodEsc_Cr
        If Len(My.MyHardware.CodEsc_Cut) > 0 Then strText &= My.MyHardware.CodEsc_Cut & My.MyHardware.CodEsc_Cr


        'Cierro y limpio
        My.m_db.CloseRst(rst)

    End Sub

    'Función para imprimirme un resumen del parte diario por la impresora de tickets
    Private Sub PrintTicketMenu()
        If My.MyHardware.IdPort = 0 Then
            MsgBox("No se ha seleccionado ninguna impresora de tickets.", MsgBoxStyle.Critical)
            Exit Sub
        End If

        Dim fh As Date = CDate(Me._day & "-" & Format(Me._month, "00") & "-" & Me._year)
        Dim rst As ADODB.Recordset = My.m_db.GetRst("SELECT * FROM db_reservas WHERE fh_reserva=#" & CDate(Me._day & "/" & Me._month & "/" & Me._year).ToString("MM-dd-yyyy") & "# ORDER BY hora ASC, name ASC")
        Dim rstLines As ADODB.Recordset = Nothing
        Dim str As String = ""

        If rst.RecordCount = 0 Then
            MsgBox("No se han encontrado reservas en la fecha seleccionada.", MsgBoxStyle.Critical)
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


                'Titulo de la impresion
                str = "RESUMEN DE RESERVAS"
                If str.Length > My.MyHardware.Ancho Then str = str.Substring(0, My.MyHardware.Ancho - 1)
                str = My.Ticket_ConfigTextAling(str, HorizontalAlignment.Center, False)
                str = My.Ticket_ConfigTextStrong(str, True)
                _port.Write(str & My.MyHardware.CodEsc_Cr)

                'Titulo de la impresion
                str = Format(fh, "dd/MM/yyyy")
                If str.Length > My.MyHardware.Ancho Then str = str.Substring(0, My.MyHardware.Ancho - 1)
                str = My.Ticket_ConfigTextAling(str, HorizontalAlignment.Center, False)
                str = My.Ticket_ConfigTextStrong(str, True)
                _port.Write(str & My.MyHardware.CodEsc_Cr)

                _port.Write(My.MyHardware.CodEsc_TextNormal & My.MyHardware.CodEsc_Cr)

                _port.Close()
                _port.Open()

                While Not rst.EOF
                    'Imprimo quien ha reservado
                    str = rst("name").Value
                    If str.Length > (My.MyHardware.Ancho - 2) Then str = str.Substring(0, My.MyHardware.Ancho - 3)
                    _port.Write("> " & str & My.MyHardware.CodEsc_Cr)

                    ' Imprimo que ha reservado
                    rstLines = My.m_db.GetRst("SELECT db_reservas_menu.ud,db_articulos.name FROM db_reservas_menu,db_articulos WHERE db_articulos.id=db_reservas_menu.id_articulo AND db_reservas_menu.id_reserva=" & rst("id").Value)
                    If rstLines.RecordCount > 0 Then
                        str = "   " & rstLines("ud").Value & "x " & rstLines("name").Value
                        If str.Length > (My.MyHardware.Ancho) Then str = str.Substring(0, My.MyHardware.Ancho - 1)
                        _port.Write("" & str & My.MyHardware.CodEsc_Cr)
                    End If

                    ' Imprimo las observaciones si procede
                    If Len(rst("about").Value & "") > 0 Then
                        str = "   " & rst("about").Value
                        _port.Write("" & str & My.MyHardware.CodEsc_Cr)
                    End If

                    rst.MoveNext()
                End While

                _port.Close()
                _port.Open()

                'Imprimo linea de separacion
                str = My.MyHardware.CodEsc_TextNormal & " " & My.MyHardware.CodEsc_Subrayado_True & Space(My.MyHardware.Ancho - 2) & My.MyHardware.CodEsc_Subrayado_False
                _port.Write(str & My.MyHardware.CodEsc_Cr)

                'Imprimo espameo
                str = My.MyHardware.CodEsc_Negrita_True & My.Ticket_ConfigTextAling("gTPV " & My.Application.Info.Version.Major & "." & My.Application.Info.Version.Minor & "." & My.Application.Info.Version.Build, HorizontalAlignment.Center) & My.MyHardware.CodEsc_Negrita_False
                _port.Write(My.Ticket_ConfigTextStrong(str, True) & My.MyHardware.CodEsc_Cr)

                'Cierro el puerto
                _port.Write(My.MyHardware.CodEsc_Salto & My.MyHardware.CodEsc_Cr)
                If Len(My.MyHardware.CodEsc_Cut) > 0 Then _port.Write(My.MyHardware.CodEsc_Cut & My.MyHardware.CodEsc_Cr)
                _port.Dispose()


                _port.Open()
                _port.Write(My.MyHardware.CodEsc_Salto & My.MyHardware.CodEsc_Cr)
                If Len(My.MyHardware.CodEsc_Cut) > 0 Then _port.Write(My.MyHardware.CodEsc_Cut & My.MyHardware.CodEsc_Cr)
                _port.Close()
                _port.Dispose()
            Catch ex As Exception
            End Try
        ElseIf My.MyHardware.PortName.Substring(0, 3) = "LPT" Then
            '<!--### IMPRESIÓN POR PUERTO PARALELO ###-->
            Dim _port As m_Crypto.ioParerellPort
            _port = New m_Crypto.ioParerellPort("LPT" & My.MyHardware.IdPort)

            'Titulo de la impresion
            str = "RESUMEN DE RESERVAS"
            If str.Length > My.MyHardware.Ancho Then str = str.Substring(0, My.MyHardware.Ancho - 1)
            str = My.Ticket_ConfigTextAling(str, HorizontalAlignment.Center, False)
            str = My.Ticket_ConfigTextStrong(str, True)
            _port.Write(str & My.MyHardware.CodEsc_Cr)

            'Titulo de la impresion
            str = Format(fh, "dd/MM/yyyy")
            If str.Length > My.MyHardware.Ancho Then str = str.Substring(0, My.MyHardware.Ancho - 1)
            str = My.Ticket_ConfigTextAling(str, HorizontalAlignment.Center, False)
            str = My.Ticket_ConfigTextStrong(str, True)
            _port.Write(str & My.MyHardware.CodEsc_Cr)

            _port.Write(My.MyHardware.CodEsc_TextNormal & My.MyHardware.CodEsc_Cr)

            While Not rst.EOF
                'Imprimo quien ha reservado
                str = rst("hora").Value & "  "
                str &= My.Ticket_ConfigTextStrong(rst("name").Value)
                'If str.Length > (My.MyHardware.Ancho - 2) Then str = str.Substring(0, My.MyHardware.Ancho - 3)
                _port.Write("> " & str & My.MyHardware.CodEsc_Cr)

                ' Imprimo que ha reservado
                rstLines = My.m_db.GetRst("SELECT db_reservas_menu.ud,db_articulos.name FROM db_reservas_menu,db_articulos WHERE db_articulos.id=db_reservas_menu.id_articulo AND db_reservas_menu.id_reserva=" & rst("id").Value)
                If rstLines.RecordCount > 0 Then
                    str = "   " & rstLines("ud").Value & "x " & rstLines("name").Value
                    If str.Length > (My.MyHardware.Ancho) Then str = str.Substring(0, My.MyHardware.Ancho - 1)
                    _port.Write("" & str & My.MyHardware.CodEsc_Cr)
                End If

                ' Imprimo las observaciones si procede
                If Len(rst("about").Value & "") > 0 Then
                    str = "" & rst("about").Value
                    'str = str.Replace(vbCrLf, ", ")
                    'If str.Length > (My.MyHardware.Ancho) Then str = str.Substring(0, My.MyHardware.Ancho - 1)
                    _port.Write("" & str & My.MyHardware.CodEsc_Cr)
                End If

                rst.MoveNext()
            End While

            'Imprimo linea de separacion
            str = My.MyHardware.CodEsc_TextNormal & " " & My.MyHardware.CodEsc_Subrayado_True & Space(My.MyHardware.Ancho - 2) & My.MyHardware.CodEsc_Subrayado_False
            _port.Write(str & My.MyHardware.CodEsc_Cr)

            'Imprimo espameo
            str = My.MyHardware.CodEsc_Negrita_True & My.Ticket_ConfigTextAling("gTPV " & My.Application.Info.Version.Major & "." & My.Application.Info.Version.Minor & "." & My.Application.Info.Version.Build, HorizontalAlignment.Center) & My.MyHardware.CodEsc_Negrita_False
            _port.Write(My.Ticket_ConfigTextStrong(str, True) & My.MyHardware.CodEsc_Cr)

            'Cierro el puerto
            _port.Write(My.MyHardware.CodEsc_Salto & My.MyHardware.CodEsc_Cr)
            If Len(My.MyHardware.CodEsc_Cut) > 0 Then _port.Write(My.MyHardware.CodEsc_Cut & My.MyHardware.CodEsc_Cr)
            _port.Dispose()

        Else
            '<!--### IMPRESIÓN POR LA IMPRESORA DE NOMBRE TICKETS ###-->
            Dim strPrinter As String = "tickets"
            Dim strText As String = ""

            'Titulo de la impresion
            str = "RESUMEN DE RESERVAS"
            If str.Length > My.MyHardware.Ancho Then str = str.Substring(0, My.MyHardware.Ancho - 1)
            str = My.Ticket_ConfigTextAling(str, HorizontalAlignment.Center, False)
            str = My.Ticket_ConfigTextStrong(str, True)
            strText &= str & My.MyHardware.CodEsc_Cr

            'Titulo de la impresion
            str = Format(fh, "dd/MM/yyyy")
            If str.Length > My.MyHardware.Ancho Then str = str.Substring(0, My.MyHardware.Ancho - 1)
            str = My.Ticket_ConfigTextAling(str, HorizontalAlignment.Center, False)
            str = My.Ticket_ConfigTextStrong(str, True)
            strText &= str & My.MyHardware.CodEsc_Cr

            strText &= My.MyHardware.CodEsc_TextNormal & My.MyHardware.CodEsc_Cr

            While Not rst.EOF
                'Imprimo quien ha reservado
                str = rst("hora").Value & "  "
                str &= My.Ticket_ConfigTextStrong(rst("name").Value)
                'If str.Length > (My.MyHardware.Ancho - 2) Then str = str.Substring(0, My.MyHardware.Ancho - 3)
                strText &= "> " & str & My.MyHardware.CodEsc_Cr

                ' Imprimo que ha reservado
                rstLines = My.m_db.GetRst("SELECT db_reservas_menu.ud,db_articulos.name FROM db_reservas_menu,db_articulos WHERE db_articulos.id=db_reservas_menu.id_articulo AND db_reservas_menu.id_reserva=" & rst("id").Value)
                If rstLines.RecordCount > 0 Then
                    str = "   " & rstLines("ud").Value & "x " & rstLines("name").Value
                    If str.Length > (My.MyHardware.Ancho) Then str = str.Substring(0, My.MyHardware.Ancho - 1)
                    strText &= "" & str & My.MyHardware.CodEsc_Cr
                End If

                ' Imprimo las observaciones si procede
                If Len(rst("about").Value & "") > 0 Then
                    str = "" & rst("about").Value
                    'str = str.Replace(vbCrLf, ", ")
                    'If str.Length > (My.MyHardware.Ancho) Then str = str.Substring(0, My.MyHardware.Ancho - 1)
                    strText &= "" & str & My.MyHardware.CodEsc_Cr
                End If

                rst.MoveNext()
            End While

            'Imprimo linea de separacion
            str = My.MyHardware.CodEsc_TextNormal & " " & My.MyHardware.CodEsc_Subrayado_True & Space(My.MyHardware.Ancho - 2) & My.MyHardware.CodEsc_Subrayado_False
            strText &= str & My.MyHardware.CodEsc_Cr

            'Imprimo espameo
            str = My.MyHardware.CodEsc_Negrita_True & My.Ticket_ConfigTextAling("gTPV " & My.Application.Info.Version.Major & "." & My.Application.Info.Version.Minor & "." & My.Application.Info.Version.Build, HorizontalAlignment.Center) & My.MyHardware.CodEsc_Negrita_False
            strText &= My.Ticket_ConfigTextStrong(str, True) & My.MyHardware.CodEsc_Cr

            'Cierro el puerto
            strText &= My.MyHardware.CodEsc_Salto & My.MyHardware.CodEsc_Cr
            RawPrinterHelper.SendStringToPrinter(strPrinter, strText)

            If Len(My.MyHardware.CodEsc_Cut) > 0 Then RawPrinterHelper.SendStringToPrinter(strPrinter, My.MyHardware.CodEsc_Cut & My.MyHardware.CodEsc_Cr)


            strText &= My.MyHardware.CodEsc_Salto & My.MyHardware.CodEsc_Cr
            If Len(My.MyHardware.CodEsc_Cut) > 0 Then strText &= My.MyHardware.CodEsc_Cut & My.MyHardware.CodEsc_Cr


        End If

        'Cierro y limpio
        My.m_db.CloseRst(rst)

    End Sub
#End Region




    Private Sub BtFilter_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtFilter.Click
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
        With Me.gridReservas
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
            ColStyle.HeaderText = "Nombre"
            ColStyle.Width = 340
            ColStyle.DefaultCellStyle = m_Style
            ColStyle.CellTemplate = Cell
            .Columns.Add(ColStyle)

            'El precio
            ColStyle = New DataGridViewColumn()
            ColStyle.DataPropertyName = "telefono"
            ColStyle.HeaderText = "Teléfono"
            ColStyle.Width = 110
            ColStyle.DefaultCellStyle = m_Style
            ColStyle.CellTemplate = Cell
            .Columns.Add(ColStyle)

            'Fecha de actualización
            ColStyle = New DataGridViewColumn()
            ColStyle.DataPropertyName = "fh_reserva"
            ColStyle.HeaderText = "Fh. Reserva"
            ColStyle.Width = 110
            ColStyle.DefaultCellStyle = m_Style
            ColStyle.CellTemplate = Cell
            .Columns.Add(ColStyle)


            'Usuarios
            ColStyle = New DataGridViewColumn()
            ColStyle.DataPropertyName = "nameUser"
            ColStyle.HeaderText = "Empleado"
            ColStyle.Width = 240
            ColStyle.DefaultCellStyle = m_Style
            ColStyle.CellTemplate = Cell
            .Columns.Add(ColStyle)

        End With

        'Filtros
        strWhere &= " AND (db_reservas.name LIKE '%" & Me.TxtFilter_name.Text & "%' AND db_reservas.telefono LIKE '%" & Me.txtFilter_tlf.Text & "%')"

        strWhere &= " AND db_reservas.fh_reserva>=#" & Format(Me.DtReservas_Desde.Value, "MM-dd-yyyy") & "#"

        'Asignamos los datos
        'rst = My.m_db.GetRst("SELECT db_reservas.id,db_reservas.name,db_reservas.telefono,db_reservas.fh_reserva,db_usuarios.name AS nameUser FROM db_reservas,db_usuarios WHERE db_reservas.id_usuario=db_usuarios.id " & strWhere & " AND db_reservas.fh_reserva>=#" & Me.DtCajaActual_Desde.Value & "# AND db_reservas.fh_reserva<=#" & Me.DtCajaActual_Hasta.Value & "# ORDER BY db_reservas.fh_reserva DESC, db_reservas.name ASC")
        rst = My.m_db.GetRst("SELECT db_reservas.id,db_reservas.name,db_reservas.telefono,db_reservas.fh_reserva,db_usuarios.name AS nameUser FROM db_reservas,db_usuarios WHERE db_reservas.id_usuario=db_usuarios.id " & strWhere & " ORDER BY db_reservas.fh_reserva DESC, db_reservas.name ASC")
        If IsNothing(rst) Then Exit Sub

        m_Table = New DataTable("m_tabla")
        da = New Data.OleDb.OleDbDataAdapter
        da.Fill(m_Table, rst)
        Me.gridReservas.DataSource = m_Table


        ''Permito borrar y volver a imprimir resumen
        'Dim sw As Boolean = (Me.gridMarcas.RowCount > 0)
        'Me.btMarca_edit.Enabled = sw
        'Me.btMarca_del.Enabled = sw

    End Sub

    Private Sub gridReservas_CellMouseDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles gridReservas.CellMouseDoubleClick
        frmReservas_Evento.IdRef = Me.gridReservas.SelectedRows(0).Cells(0).Value
        'frmReservas_Evento.fhEvento = CDate(Me._day & "/" & Me._month & "/" & Me._year)
        frmReservas_Evento.ShowDialog(Me)
        If frmReservas_Evento.DialogResult <> Windows.Forms.DialogResult.OK Then
            frmReservas_Evento.Dispose()
            Exit Sub
        End If

        frmReservas_Evento.Dispose()

    End Sub
End Class