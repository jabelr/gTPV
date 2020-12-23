Imports System.IO
Public Class frmSelect_Empleado
    Public Id_Ref As Integer = 0

    'Cuando controlar cuando es para repartidores
    Public swRepartidores As Boolean = False
    Public swWhoIS As Boolean = False

    'Private m_Data As gDevelop.m_dataform

#Region "Eventos Principales"
    Private Sub frmSelect_Empleado_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
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


        'Cargo el logotipo de la empresa
        Dim rst As ADODB.Recordset = My.m_db.GetRst("SELECT name_comercial,img,img_banner FROM app_empresa")
        Me.lblNameEmpresa.Text = rst("name_comercial").Value
        Dim imgLogo As Image = Nothing
        If Not IsNothing(rst("img_banner").Value) Then
            imgLogo = My.m_db.data_GetImgRow(rst("img_banner"))
        ElseIf Not IsNothing(rst("img").Value) Then
            imgLogo = My.m_db.data_GetImgRow(rst("img"))
        End If
        My.m_db.CloseRst(rst)

        If Not IsNothing(imgLogo) Then picLogo.Image = imgLogo

        Me.AddHandlers()


        Me.LblHour.Text = Now.ToString("HH:mm")
        Me.LblHour.Location = New Point((Me.Width - Me.LblHour.Width) - 40, (Me.SplitContainer.Panel2.Height - Me.LblHour.Height) - 30)
        Me.PnlLastTicket.Location = New Point((Me.Width - Me.PnlLastTicket.Width) - 40, 30)


        'Cargo el ultimo ticket
        rst = My.m_db.GetRst("SELECT TOP 3 db_tickets.id,db_usuarios.name,db_usuarios.img,total FROM db_tickets,db_usuarios WHERE db_usuarios.id=db_tickets.id_user AND db_tickets.id_caja=-1 ORDER BY db_tickets.id DESC")
        If rst.RecordCount > 0 Then
            Me.LblLastPVP.Text = Format(rst("total").Value, "0.00") & " " & System.Threading.Thread.CurrentThread.CurrentCulture.NumberFormat.CurrencySymbol
            Me.LblLastEmpleado.Text = rst("name").Value
            Me.PicImg.Image = My.m_db.data_GetImgRow(rst("img"))
            Me.PnlLastTicket.Visible = True
        End If

        'Cargo los usuarios
        Me.Load_Users()

        'Si es usuario de reparto
        If Me.swRepartidores Then
            Me.LblTitle.Text = "Selección de Repartidor"
            Me.LblName.Text = "Seleccione el Repartidor"
        End If
    End Sub
#End Region

#Region "Eventos Auxiliares"
    Private Sub Buttons_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtCancell.Click, BtClose.Click, BtAcceso.Click, btAccesoDirecto.Click, BtLogout.Click
        '# Inicio de sesion
        If (sender Is Me.btAccesoDirecto Or sender Is Me.BtAcceso) Then
            'Compruebo el acceso
            Dim id As Integer = My.IdentificaUser()
            If id = -1 Then Exit Sub

            If id = -3 Then
                Me.Id_Ref = -3
                Me.DialogResult = Windows.Forms.DialogResult.OK
                Exit Sub
            End If

            'My.AppIdUser = id

            'Compruebo si esta ya agregado el usuario
            Dim rst As ADODB.Recordset = My.m_db.GetRst("SELECT id FROM db_cajas_acceso WHERE id_caja=-1 AND id_usuario=" & id & " AND NOT isdate(fh_fin)")
            If rst.RecordCount > 0 Then
                MsgBox("El usuario se encuentra ya activo en la caja actual.", MsgBoxStyle.Information)
                My.m_db.CloseRst(rst)
                Exit Sub
            End If
            My.m_db.CloseRst(rst)


            ' Activo el Usuario y Recargo
            Dim sql As String = ""
            sql = "INSERT INTO db_cajas_acceso (id_caja,id_usuario,fh_acceso) VALUES (-1," & id & ",'" & Format(Now, "dd/MM/yyyy HH:mm:ss") & "')"
            My.m_db.Execute(sql)
            Me.Load_Users()
            Exit Sub
        End If

        'El usuario sale

        If sender Is Me.BtLogout Then
            'Compruebo el usuario que quiere salir
            Dim id As Integer = My.IdentificaUser()
            If id = -1 Then Exit Sub

            'Compruebo que el usuario esta logeado
            Dim sql As String = "SELECT id FROM db_cajas_acceso WHERE id_usuario=" & id & " AND id_caja=-1 AND NOT isdate(fh_fin)"
            Dim rst As ADODB.Recordset = My.m_db.GetRst(sql)
            If rst.EOF Then
                MsgBox("El usuario especificado no ha iniciado sesión en la caja actual.", MsgBoxStyle.Critical)
                My.m_db.CloseRst(rst)
            End If


            'Finalizo el último acceso
            sql = "UPDATE db_cajas_acceso SET fh_fin='" & Format(Now, "dd/MM/yyyy HH:mm:ss") & "' WHERE NOT isdate(fh_fin) AND id_usuario = " & id
            My.m_db.Execute(sql)
            My.m_db.CloseRst(rst)

            Me.Load_Users()
            Exit Sub
        End If

        Me.Close()
    End Sub

    'Private Sub frmSelect_Empleado_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
    '    Me.m_Data.Dispose()
    '    m_Data = Nothing
    'End Sub

#End Region

#Region "Handlers"
    Private Sub AddHandlers()

    End Sub
#End Region

#Region "Carga de Usuarios"
    Private _users_tot As Integer = 0
    Private _users_pag As Integer = 0

    Private Sub Load_Users()

        Me.BtImg_Previous.Enabled = (Me._users_pag > 0)
        Me.BtImg_Next.Enabled = False

        ' Nº de productos a lo ancho y a lo alto a mostrar
        Dim _x As Integer = 5
        Dim _y As Integer = 3

        'Localizacion de inicio para el primer boton
        Dim _left As Integer = 0
        Dim _top As Integer = 0

        'Variables Auxiliares
        Dim i As Integer = 0, j As Integer = 0, n As Integer
        Dim rst As ADODB.Recordset
        Dim sql As String, swValida As Boolean = False



        '##### SI ES MODO SEGURO LOS USUARIOS TIENEN QUE VALIDAR
        If (My.m_opt.modo_seguro AndAlso Me.swRepartidores = False) OrElse Me.swWhoIS Then
            '### Paginacion
            sql = "SELECT db_usuarios.id FROM db_usuarios,db_cajas_acceso"
            sql &= " WHERE db_usuarios.estado='ACTIVADO' AND " & _
                    "db_cajas_acceso.id_usuario=db_usuarios.id AND " & _
                    "NOT isdate(db_cajas_acceso.fh_fin) AND " & _
                    "db_cajas_acceso.id_caja=-1"

            'If My.m_opt.modo_seguro Then sql &= " AND pass <>''"

            rst = My.m_db.GetRst(sql)
            Me._users_tot = rst.RecordCount
            My.m_db.CloseRst(rst)

            '### Limpio anteriores controltes
            For i = Me.PnlGaleria.Controls.Count - 1 To 1 Step -1
                Me.PnlGaleria.Controls(i).Dispose()
            Next

            '### Obtengo las imagenes de la categoria seleccionada
            sql = "SELECT db_usuarios.* FROM db_usuarios,db_cajas_acceso"
            sql &= " WHERE " & _
                    "estado='ACTIVADO' AND " & _
                    "db_cajas_acceso.id_usuario=db_usuarios.id AND " & _
                    "NOT isdate(db_cajas_acceso.fh_fin) AND " & _
                    "db_cajas_acceso.id_caja=-1 "

            If My.m_opt.modo_seguro Then sql &= " AND pass <>''"

            sql &= " ORDER BY name asc"
            rst = My.m_db.GetRst(sql)

            Me.btAccesoDirecto.Visible = True
            Me.BtLogout.Visible = True
            Me.BtAcceso.Visible = True
        Else

            '### Paginacion
            sql = "SELECT db_usuarios.id FROM db_usuarios"
            sql &= " WHERE db_usuarios.estado='ACTIVADO'"
            'If Me.swRepartidores Then sql &= " AND swRepartidor=TRUE"
            sql &= " AND swRepartidor=" & Me.swRepartidores

            rst = My.m_db.GetRst(sql)
            Me._users_tot = rst.RecordCount
            My.m_db.CloseRst(rst)

            '### Limpio anteriores controltes
            For i = Me.PnlGaleria.Controls.Count - 1 To 1 Step -1
                Me.PnlGaleria.Controls(i).Dispose()
            Next

            '### Obtengo las imagenes de la categoria seleccionada
            sql = "SELECT db_usuarios.* FROM db_usuarios"
            sql &= " WHERE " & _
                        "estado='ACTIVADO'"
            'If Me.swRepartidores Then sql &= " AND swRepartidor=TRUE"
            sql &= " AND swRepartidor=" & Me.swRepartidores
            sql &= " ORDER BY name asc"
            rst = My.m_db.GetRst(sql)

            Me.btAccesoDirecto.Visible = False
            Me.BtLogout.Visible = False
            Me.BtAcceso.Visible = False
        End If

        '### Agrego los botones de las imagenes
        i = 0
        While Not rst.EOF
            If (n >= (Me._users_pag * (_x * _y))) Then
                ' Creo y configuro el nuevo boton
                Dim bt As Button
                bt = New Button

                bt.Font = New Font("Verdana", 8, FontStyle.Bold)
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

                bt.ForeColor = Color.FromArgb(rst("color").Value)

                ' Asigno Eventos
                AddHandler bt.Click, AddressOf BtImg_Select_Click

                PnlGaleria.Controls.Add(bt)
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

        Me.btAccesoDirecto.Visible = IIf(i > 0 OrElse n > 0, False, True)
    End Sub

    Private Sub BtImg_Move_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtImg_Next.Click, BtImg_Previous.Click
        Select Case True
            Case sender Is Me.BtImg_Previous
                Me._users_pag -= 1

            Case sender Is Me.BtImg_Next
                Me._users_pag += 1
        End Select

        Me.Load_Users()
    End Sub

    Private Sub BtImg_Select_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        ''Si tiene activado el modo seguro, soliticito la contraseña
        'If My.m_opt.modo_seguro Then
        '    frmSolicita_Pass.Id_Ref = CType(sender, Button).Tag
        '    frmSolicita_Pass.ShowDialog(Me)
        '    If frmSolicita_Pass.DialogResult <> Windows.Forms.DialogResult.OK Then
        '        frmSolicita_Pass.Dispose()
        '        Exit Sub
        '    End If
        '    frmSolicita_Pass.Dispose()
        'End If
        'Retorno el usuario ya validado
        Me.Id_Ref = CType(sender, Button).Tag
        Me.DialogResult = Windows.Forms.DialogResult.OK
    End Sub

#End Region

    Private Sub TmHour_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TmHour.Tick
        Me.LblHour.Text = Now.ToString("HH:mm")
    End Sub

    Private Sub m_logo_MouseDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles m_logo.MouseDoubleClick, m_logo.DoubleClick
        Me.Id_Ref = -3
        Me.DialogResult = Windows.Forms.DialogResult.OK
    End Sub

    Private Sub m_logo_MouseDoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles m_logo.DoubleClick
        Me.Id_Ref = -3
        Me.DialogResult = Windows.Forms.DialogResult.OK
    End Sub
End Class