Public Class frmReservas_Evento
    Public IdRef As Integer = 0
    Public idUser As Integer = 0
    Public fhEvento As Date

    'Articulos eliminados
    Private _arrDelete(0) As Integer

    Public swPrint As Boolean = False

    Private m_Data As gDevelop.Lite.m_dataform

#Region "Eventos Principales"
    Private Sub frmAgenda_Evento_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        '####### Cargo las categorias de Imagen
        'Dim rst As ADODB.Recordset = My.m_db.GetRst("SELECT * FROM app_imgs_categorias ORDER BY name ASC")

        'Me.CbImg_Cat.Items.Clear()
        'While Not rst.EOF
        '    Me.CbImg_Cat.Items.Add(rst("name").Value & Space(100) & rst("id").Value)
        '    rst.MoveNext()
        'End While
        'My.m_db.CloseRst(rst)

        'Me.CbImg_Cat.SelectedIndex = 0


        ''####### Cargo la configuración de las lineas de facturas de proveedores
        Me.m_Data = New gDevelop.Lite.m_dataform(My.m_db)
        Me.m_Data.DbTable = "db_reservas"
        Me.m_Data.ConfigureDataForm(Me.PnlReservas.Controls)

        If Me.IdRef = 0 Then           'Caso del nuevo
            Me.m_Data.data_NewField()

            'Establezco estados
            Me.LblName.Text = "Nuevo Evento"
            Me.LblFhEvento.Text = Format(Me.fhEvento, "dd \de MMMM \de yyyy").ToUpper

            Me.LblFh_Alta_nfo.Visible = False
            Me.LblFh_Alta.Visible = False

            Me.DtFhReserva.Value = Me.fhEvento
        Else      'Caso de la edicion
            Me.m_Data.data_EditField(Me.IdRef)
        End If

        Me.txtIDUsuario.Text = Me.idUser

        ' Configuro lista de Menu
        With Me.LstMenu.Columns
            .Clear()
            .Add("id", 0, HorizontalAlignment.Right)
            .Add("Ref.", 0, HorizontalAlignment.Right)
            .Add("Concepto", 300, HorizontalAlignment.Left)
            .Add("Ud.", 70, HorizontalAlignment.Left)
        End With

        'Cargo las lineas
        Dim rst As ADODB.Recordset = My.m_db.GetRst("SELECT db_reservas_menu.*,db_articulos.name FROM db_reservas_menu,db_articulos WHERE db_articulos.id=db_reservas_menu.id_articulo AND id_reserva=" & Me.IdRef)
        Dim i As Integer
        While Not rst.EOF
            i = Me.LstMenu.Items.Count
            Me.LstMenu.Items.Add(rst("id").Value)
            Me.LstMenu.Items(i).SubItems.Add(rst("id_articulo").Value)
            Me.LstMenu.Items(i).SubItems.Add(rst("concepto").Value)
            Me.LstMenu.Items(i).SubItems.Add(rst("ud").Value)

            rst.MoveNext()
        End While
        My.m_db.CloseRst(rst)

        Me.btOKPrint.Visible = Not (My.MyHardware.IdPort = 0)

        Me.AddHandlers()
    End Sub
#End Region

#Region "Manejador de Eventos"
    Private Sub Buttons_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtCancell.Click, BtOk.Click, BtNew.Click, BtDell.Click, BtN_Down.Click, BtN_Up.Click, btOKPrint.Click
        Select Case True
            Case sender Is Me.BtNew                                     '### Caso del Nuevo
                Dim i As Integer = 0
                With frmReservas_SelectMenu
                    .Id_Ref = 0
                    .ShowDialog(Me)
                    If .DialogResult <> Windows.Forms.DialogResult.OK Then
                        .Dispose()
                        Exit Sub
                    End If

                    ' Obtengo el articulo que es
                    Dim rst As ADODB.Recordset = My.m_db.GetRst("SELECT name FROM db_articulos WHERE id=" & .Id_Ref)
                    i = Me.LstMenu.Items.Count
                    Me.LstMenu.Items.Add(0)

                    Me.LstMenu.Items(i).SubItems.Add(.Id_Ref)
                    Me.LstMenu.Items(i).SubItems.Add(rst("name").Value)
                    Me.LstMenu.Items(i).SubItems.Add("1")

                    My.m_db.CloseRst(rst)

                    Me.LstMenu.SelectedItems.Clear()
                    Me.LstMenu.Items(i).Selected = True
                    Me.LstMenu.Items(i).Checked = True
                    Me.LstMenu.EnsureVisible(i)
                    Me.LstMenu.Focus()
                    .Dispose()
                End With

            Case sender Is Me.BtDell                                             '### Caso del ELIMINAR
                Dim Id_pos As Integer = Me.LstMenu.SelectedItems(0).Index

                If (Me.LstMenu.SelectedItems(0).Text <> 0) Then
                    ReDim Preserve Me._arrDelete(UBound(Me._arrDelete) + 1)
                    Me._arrDelete(UBound(Me._arrDelete)) = Me.LstMenu.SelectedItems(0).Text
                End If
                Me.LstMenu.SelectedItems(0).Remove()
                Me.LstMenu.SelectedItems.Clear()

                If Id_pos = Me.LstMenu.Items.Count Then Id_pos -= 1
                If Me.LstMenu.Items.Count Then Me.LstMenu.Items(Id_pos).Selected = True


            Case sender Is Me.BtN_Up                                       '### Caso del +1 UNIDAD 
                Me.LstMenu.SelectedItems(0).SubItems(3).Text += 1
                Me.LstMenu.SelectedItems(0).Checked = True
                Me.BtN_Down.Enabled = (Me.LstMenu.SelectedItems(0).SubItems(3).Text > 1)
                Me.LstMenu.Focus()

            Case sender Is Me.BtN_Down                                  '### Caso del -1 UNIDAD 
                Me.LstMenu.SelectedItems(0).SubItems(3).Text -= 1
                Me.LstMenu.SelectedItems(0).Checked = True
                Me.BtN_Down.Enabled = (Me.LstMenu.SelectedItems(0).SubItems(3).Text > 1)
                Me.LstMenu.Focus()

            Case sender Is Me.BtOk Or sender Is Me.btOKPrint           '### Caso del GUARDAR
                If Me.TxtName.TextLength = 0 Then
                    My.m_msg.MessageError(Me, "Imposible guardar, no se ha especificado el nombre del evento a guardar.")
                    Exit Sub
                End If
                'Guardo el registro
                Dim str As String
                Dim i As Integer, id As Integer = Me.m_Data.data_SaveField()

                If id = -1 Then
                    My.m_msg.MessageError(Me, "Error al guardar el Evento.")
                    Exit Sub
                End If

                'Elimino las lineas
                For i = 0 To UBound(Me._arrDelete) - 1
                    str = "DELETE * FROM db_reservas_menu WHERE id=" & Me._arrDelete(i)
                    My.m_db.Execute(str)
                Next

                'Guardo las lineas
                For i = 0 To Me.LstMenu.Items.Count - 1
                    If Me.LstMenu.Items(i).Text = 0 Then       'Caso del nuevo
                        str = "INSERT INTO db_reservas_menu (id_reserva,id_articulo,ud,concepto)"
                        str &= " VALUES (" & id & "," & Me.LstMenu.Items(i).SubItems(1).Text & "," & Me.LstMenu.Items(i).SubItems(3).Text & ",'" & Me.LstMenu.Items(i).SubItems(2).Text & "')"

                        My.m_db.Execute(str)
                    Else
                        If Me.LstMenu.Items(i).Checked Then               'Ha modificado las unidades
                            str = "UPDATE db_reservas_menu SET ud=" & Me.LstMenu.Items(i).SubItems(3).Text & ",concepto='" & Me.LstMenu.Items(i).SubItems(2).Text & "' WHERE id=" & id
                            My.m_db.Execute(str)
                        End If
                    End If
                Next
                Me.IdRef = id
                Me.swPrint = (sender Is Me.btOKPrint)
                Me.DialogResult = Windows.Forms.DialogResult.OK


            Case sender Is Me.BtCancell
                Me.Close()
        End Select
    End Sub
#End Region

#Region "Eventos Auxiliares"
    Private Sub frmReservas_Evento_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If Not IsNothing(m_KeyBoard) Then m_KeyBoard.Dispose()
    End Sub

    Private Sub LstMenu_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LstMenu.SelectedIndexChanged
        Dim sw As Boolean = (Me.LstMenu.SelectedItems.Count > 0)
        Me.BtDell.Enabled = sw
        Me.BtN_Up.Enabled = sw
        Me.BtN_Down.Enabled = sw AndAlso (Me.LstMenu.SelectedItems(0).SubItems(3).Text > 1)
    End Sub

    Private Sub TxtName_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtName.TextChanged
        Me.BtOk.Enabled = (Me.TxtName.TextLength > 0)
        Me.btOKPrint.Enabled = (Me.TxtName.TextLength > 0)
    End Sub
#End Region

#Region "Handlers"
    Private Sub AddHandlers()

    End Sub
#End Region

#Region "Control del Teclado Multimedia"
    Private Sub BtKeyBoard_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtKeyBoard.Click
        AddHandler m_KeyBoard.KeyBoard_Press, AddressOf KeyBoard_Press

        m_KeyBoard.Left = (Screen.PrimaryScreen.WorkingArea.Width - m_KeyBoard.Width) / 2
        m_KeyBoard.Top = Screen.PrimaryScreen.WorkingArea.Height - m_KeyBoard.Height - My.APP_NUMBER
        m_KeyBoard.Show()

        My.AsignarFoco(Me.TxtName)
    End Sub

    Private Sub KeyBoard_Press(ByVal key As String)
        If TypeName(Me.ActiveControl).ToUpper <> "TEXTBOX" Then Exit Sub


        Select Case key
            Case "SPACE"
                key = " "
            Case "DEL"
                If CType(Me.ActiveControl, TextBox).TextLength = 0 Then
                    m_KeyBoard.Activate()
                    Exit Sub
                End If
                CType(Me.ActiveControl, TextBox).Text = CType(Me.ActiveControl, TextBox).Text.Substring(0, CType(Me.ActiveControl, TextBox).Text.Length - 1)
                CType(Me.ActiveControl, TextBox).SelectionStart = CType(Me.ActiveControl, TextBox).TextLength
                m_KeyBoard.Activate()
                Exit Sub
                ' Case "OK"
                '     BtFilter_Click(Me.BtFilter, New EventArgs)
                '     Exit Sub

        End Select
        CType(Me.ActiveControl, TextBox).Text &= key
        CType(Me.ActiveControl, TextBox).SelectionStart = CType(Me.ActiveControl, TextBox).TextLength

        m_KeyBoard.Activate()


        'Me.Focus()
    End Sub
#End Region
End Class