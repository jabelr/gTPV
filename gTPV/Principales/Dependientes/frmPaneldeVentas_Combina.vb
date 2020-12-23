Imports System.IO
Public Class frmPaneldeVentas_Combina
    Public Id_Ref As Integer = 0
    Public Id_CatRef As Integer = 0
    Public StrName As String = ""

    Private swOrderBYFijo As Boolean = True


#Region "Eventos Principales"
    Private Sub frmPaneldeVentas_Combina_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        StrName = ""

        Dim i As Integer = 0

        '####### Cargo las categorias de Imagen
        Dim rst As ADODB.Recordset = My.m_db.GetRst("SELECT * FROM db_categorias ORDER BY name ASC")

        Me.CbCategorias.Items.Clear()
        While Not rst.EOF
            Me.CbCategorias.Items.Add(rst("name").Value & Space(100) & rst("id").Value)
            If rst("id").Value = Me.Id_CatRef Then i = Me.CbCategorias.Items.Count - 1
            rst.MoveNext()
        End While
        My.m_db.CloseRst(rst)

        Me.CbCategorias.SelectedIndex = i

    End Sub
#End Region

#Region "Eventos Auxiliares"
    Private Sub Buttons_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtCancell.Click, BtSolo.Click
        Select Case True
            Case sender Is Me.BtCancell
                Me.Close()
            Case sender Is Me.BtSolo
                Me.Id_Ref = 0
                Me.DialogResult = Windows.Forms.DialogResult.OK
        End Select
    End Sub

    Private Sub frmPaneldeVentas_Combina_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed

    End Sub

    Private Sub CbCategorias_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CbCategorias.SelectedIndexChanged
        Me._galeria_pag = 0
        Me._idCat = Me.CbCategorias.Text.Substring(100).Trim
        Load_GaleriaImg(Me._idCat)
    End Sub
#End Region

#Region "Handlers"
    Private Sub AddHandlers()

    End Sub
#End Region

#Region "Geleria de Imagenes"
    Private _galeria_tot As Integer = 0
    Private _galeria_pag As Integer = 0

    Private _idCat As Integer = 0

    'Private Sub LoadCat_GaleriaImg()
    '    Dim rst As ADODB.Recordset = My.m_db.GetRst("SELECT * FROM app_imgs_categorias ORDER BY name ASC")

    '    Me.CbImg_Cat.Items.Clear()
    '    Me.CbImg_Cat.Items.Add("Mostror TODOS" & Space(100) & "0")
    '    While Not rst.EOF
    '        Me.CbImg_Cat.Items.Add(rst("name").Value & Space(100) & rst("id").Value)
    '        rst.MoveNext()
    '    End While
    '    Me.CbImg_Cat.SelectedIndex = 0
    '    My.m_db.CloseRst(rst)
    'End Sub

    Private Sub Load_GaleriaImg(ByVal id_cat As Integer)
        Me.PnlGaleria.Visible = False

        Me.BtImg_Previous.Enabled = (Me._galeria_pag > 0)
        Me.BtImg_Next.Enabled = False

        ' Nº de productos a lo ancho y a lo alto a mostrar
        Dim _x As Integer = 6
        Dim _y As Integer = 4

        'Localizacion de inicio para el primer boton
        Dim _left As Integer = 0
        Dim _top As Integer = 0

        'Variables Auxiliares
        Dim i As Integer = 0, j As Integer = 0, n As Integer
        Dim rst As ADODB.Recordset
        Dim sql As String

        '### Paginacion
        sql = "SELECT count(id) as tot FROM db_articulos"
        If Me.CbCategorias.SelectedIndex > 0 Then sql &= " WHERE id_categoria=" & Me.CbCategorias.Text.Substring(100).Trim
        rst = My.m_db.GetRst(sql)
        Me._galeria_tot = rst("tot").Value
        My.m_db.CloseRst(rst)

        '### Limpio anteriores controltes
        For i = Me.PnlGaleria.Controls.Count - 1 To 0 Step -1
            Me.PnlGaleria.Controls(i).Dispose()
        Next

        '### Obtengo las imagenes de la categoria seleccionada
        'sql = "SELECT * FROM app_imgs"
        'sql &= " WHERE id_categoria=" & Me.CbCategorias.Text.Substring(100).Trim
        'sql &= " ORDER BY id desc"
        sql = "SELECT db_articulos.*,app_imgs.img FROM db_articulos LEFT JOIN app_imgs"
        sql &= " ON db_articulos.id_img=app_imgs.id "
        sql &= " WHERE db_articulos.id_categoria=" & id_cat

        If Not Me.swOrderBYFijo Then
            sql &= " ORDER BY db_articulos.n_veces DESC,db_articulos.name ASC"
        Else
            sql &= " ORDER BY db_articulos.n_orden DESC,db_articulos.name ASC"
        End If

        rst = My.m_db.GetRst(sql)


        '### Agrego los botones de las imagenes
        i = 0
        While Not rst.EOF
            If (n >= (Me._galeria_pag * (_x * _y))) Then
                ' Creo y configuro el nuevo boton
                Dim bt As Button
                bt = New Button
                bt.Font = New Font("Verdana", 7)
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
                    'bt.Text = ""
                    bt.UseVisualStyleBackColor = True
                End If


                ' Asigno Eventos
                AddHandler bt.Click, AddressOf BtImg_Select_Click

                PnlGaleria.Controls.Add(bt)
                bt.Visible = True

                i += 1
                If i = _x Then
                    i = 0
                    j += 1
                    If j >= _y Then
                        Me.BtImg_Next.Enabled = ((Me._galeria_tot / (_x * _y)) > 1)
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
                Me._galeria_pag -= 1

            Case sender Is Me.BtImg_Next
                Me._galeria_pag += 1
        End Select

        Me.Load_GaleriaImg(Me._idCat)
    End Sub

    Private Sub BtImg_Select_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'Muestro la opcion de editar
        'With frmConfigure_ImgGalery
        Me.StrName = CType(sender, Button).Text
        Me.Id_Ref = CType(sender, Button).Tag
        Me.DialogResult = Windows.Forms.DialogResult.OK

        '    .ShowDialog(Me)
        '    If .DialogResult <> Windows.Forms.DialogResult.OK Then
        '        .Dispose()
        '        Exit Sub
        '    End If

        '    'Vuelvo a cargar las imagenes
        '    Me.Load_GaleriaImg()

        '    .Dispose()
        'End With

    End Sub

#End Region



End Class