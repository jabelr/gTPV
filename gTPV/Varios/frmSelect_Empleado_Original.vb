Imports System.IO
Public Class frmSelect_Empleado_Original
    Public Id_Ref As Integer = 0

    'Private m_Data As gDevelop.m_dataform

#Region "Eventos Principales"
    Private Sub frmSelect_Empleado_Original_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ''####### Cargo las categorias de Imagen
        'Dim rst As ADODB.Recordset = My.m_db.GetRst("SELECT * FROM app_imgs_categorias ORDER BY name ASC")

        'Me.CbImg_Cat.Items.Clear()
        'While Not rst.EOF
        '    Me.CbImg_Cat.Items.Add(rst("name").Value & Space(100) & rst("id").Value)
        '    rst.MoveNext()
        'End While
        'My.m_db.CloseRst(rst)

        'Me.CbImg_Cat.SelectedIndex = 0

        Me.Load_Users()

        Me.AddHandlers()
    End Sub
#End Region

#Region "Eventos Auxiliares"
    Private Sub Buttons_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtCancell.Click
        Select Case True
            'Case sender Is Me.BtOk
            '    'If Me.TxtFactura.TextLength = 0 Then
            '    '    My.m_msg.MessageError(Me, "Imposible guardar, no se ha especificado un número de factura correcto.")
            '    '    Exit Sub
            '    'End If
            '    'Me.CalcularTotales()

            '    'Me.m_Data.data_SaveField()
            '    Me.DialogResult = Windows.Forms.DialogResult.OK


            Case sender Is Me.BtCancell
                Me.Close()
        End Select
    End Sub

    'Private Sub frmSelect_Empleado_Original_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
    '    Me.m_Data.Dispose()
    '    m_Data = Nothing
    'End Sub

#End Region

#Region "Handlers"
    Private Sub AddHandlers()

    End Sub
#End Region

#Region "Imagenes de Usuarios"
    Private _users_tot As Integer = 0
    Private _users_pag As Integer = 0

    Private Sub Load_Users()
        Me.PnlGaleria.Visible = False

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
        Dim sql As String

        '### Paginacion
        sql = "SELECT count(id) as tot FROM db_usuarios"
        sql &= " WHERE estado='ACTIVADO'"
        'If My.m_opt.modo_seguro Then sql &= " AND pass <>''"

        rst = My.m_db.GetRst(sql)
        Me._users_tot = rst("tot").Value
        My.m_db.CloseRst(rst)

        '### Limpio anteriores controltes
        For i = Me.PnlGaleria.Controls.Count - 1 To 0 Step -1
            Me.PnlGaleria.Controls(i).Dispose()
        Next

        '### Obtengo las imagenes de la categoria seleccionada
        sql = "SELECT * FROM db_usuarios"
        sql &= " WHERE estado='ACTIVADO'"
        If My.m_opt.modo_seguro Then sql &= " AND pass <>''"
        sql &= " ORDER BY name asc"
        rst = My.m_db.GetRst(sql)


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

        Me.PnlGaleria.Visible = True
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


End Class