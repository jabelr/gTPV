Public Class frmPaneldeSituacion_Select
    'El ID de la mesa y a la que se realiza el cambio
    Public idRef As Integer = 0
    Public idNew As Integer = 0

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
    Private Sub frmPaneldeSituacion_Select_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
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

        Dim i As Integer = -1
        Dim rst As ADODB.Recordset ', rstAux As ADODB.Recordset

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

    End Sub
#End Region

#Region "Manejadores"
    'Manejador Principal (Shell)
    Private Sub ShellApp(ByVal command As String)
        Dim cmd As String = command.ToUpper

        Select Case cmd
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
    Private Sub Buttons_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtClose.Click
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
        Me.idNew = CType(sender, PictureBox).Name
        Me.DialogResult = Windows.Forms.DialogResult.OK
        ''Obtengo Camarero
        'Dim id As Integer = My.ValidateUser()
        'If id = -1 Then Exit Sub

        ''Muestro panel de ventas
        'With My.Forms.frmPaneldeVentas
        '    .idRef = CType(sender, PictureBox).Tag               'El id del ticket
        '    .idMesa = CType(sender, PictureBox).Name          'El id de la mesa
        '    .idUser = id                                                    'El usuario que edita la mesa
        '    .swCajaDirecta = False

        '    .ShowDialog(Me)
        '    If .DialogResult = Windows.Forms.DialogResult.OK Then
        '        If .swKill Then
        '            'Pongo estado por defecto
        '            Me.UpdateState_Ticket(CType(sender, PictureBox).Text, -1)

        '        ElseIf .swReload Then
        '            'Actualizo valores
        '            Me.UpdateState_Ticket(CType(sender, PictureBox).Text, .idRef)
        '        End If
        '    End If
        '    .Dispose()
        'End With
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
                Me._arrImgs(i).Enabled = False

                'Modifico los valores de la etiqueta
                With Me._arrNames(i)
                    .Font = New Font("Verdana", 10, FontStyle.Bold)
                    .ForeColor = Color.FromArgb(rst("color").Value)
                    .Text = rst("name_mesa").Value
                End With
                Exit For
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
                    Me._arrImgs(i).Enabled = False

                    'Modifico los valores de la etiqueta
                    With Me._arrNames(i)
                        .Font = New Font("Verdana", 10, FontStyle.Bold)
                        .ForeColor = Color.FromArgb(rst("color").Value)
                        .Text = rst("name_mesa").Value
                        .Enabled = False
                    End With
                    Exit For
                End If
            Next
            rst.MoveNext()
        End While
        My.m_db.CloseRst(rst)
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


End Class