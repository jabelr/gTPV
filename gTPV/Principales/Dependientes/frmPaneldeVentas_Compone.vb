Imports System.IO
Public Class frmPaneldeVentas_Compone

    Public Id_Ref As Integer = 0
    'Public Id_CatRef As Integer = 0
    Public StrName As String = ""

    Public sCombina As String = ""
    Public arrCombinaDefault() As Boolean

    Public swArticulo As Boolean = False

    ' Coso de articulos MIXTOS
    Public swMixto As Boolean = False
    Public Id_CatRef As Integer = 0

    Public _swInc As Boolean = False

    Private swOrderBYFijo As Boolean = True

#Region "Eventos Principales"
    Private Sub frmPaneldeVentas_Combina_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        StrName = ""

        Dim i As Integer = 0

        '####### Cargo las categorias de Imagen
        Dim rst As ADODB.Recordset = Nothing
        If Not Me.swMixto Then


            rst = My.m_db.GetRst("SELECT * FROM db_categorias WHERE swExtras=TRUE ORDER BY name ASC")

            Me.CbCategorias.Items.Clear()
            While Not rst.EOF
                Me.CbCategorias.Items.Add(rst("name").Value & Space(100) & rst("id").Value)
                If rst("id").Value = Me.Id_CatRef Then i = Me.CbCategorias.Items.Count - 1
                rst.MoveNext()
            End While
            My.m_db.CloseRst(rst)
            If Me.CbCategorias.Items.Count > 0 Then Me.CbCategorias.SelectedIndex = i

        Else
            '####### Cargo las categorias de Imagen
            rst = My.m_db.GetRst("SELECT * FROM db_categorias ORDER BY name ASC")

            Me.CbCategorias.Items.Clear()
            While Not rst.EOF
                Me.CbCategorias.Items.Add(rst("name").Value & Space(100) & rst("id").Value)
                If rst("id").Value = Me.Id_CatRef Then i = Me.CbCategorias.Items.Count - 1
                rst.MoveNext()
            End While
            My.m_db.CloseRst(rst)

            Me.CbCategorias.SelectedIndex = i

        End If

        Me.lblPrecio.Visible = Not Me.swArticulo


        'Cargo el combinado
        If sCombina.Length > 1 Then

            Dim sCompleta As String = "", rstCompose As ADODB.Recordset = Nothing
            Dim arr() As String = gDevelop.Lite.m_Functions.SplitString(sCombina)

            ReDim Preserve Me.arrCombinaDefault(UBound(arr))

            For k As Integer = 0 To arr.Length - 1
                rstCompose = My.m_db.GetRst("SELECT name,pvp_iva FROM db_articulos WHERE id=" & arr(k))
                If Not rstCompose.EOF Then
                    'sCompleta &= "    - " & rstCompose("name").Value & IIf(rstCompose("pvp_iva").Value > 0, "(+" & rstCompose("pvp_iva").Value & ")", "") & My.MyHardware.CodEsc_Cr

                    Me.lst.Items.Add(rstCompose("name").Value & Space(100) & arr(k))


                    Me.arrCombinaDefault(k) = True
                End If
            Next
            'If sCompleta.Length > 0 Then strText &= My.FixCHARISO(sCompleta) & My.MyHardware.CodEsc_Cr


        End If
    End Sub
#End Region

#Region "Eventos Auxiliares"
    Private Sub Buttons_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtCancell.Click
        Select Case True
            Case sender Is Me.BtCancell
                Me.Close()
                'Case sender Is Me.BtSolo
                '    Me.Id_Ref = 0
                '    Me.DialogResult = Windows.Forms.DialogResult.OK
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
        sql = "SELECT count(id) as tot FROM db_articulos WHERE 1=1 "
        If Me.CbCategorias.SelectedIndex > 0 Then sql &= " AND id_categoria=" & Me.CbCategorias.Text.Substring(100).Trim
        sql &= IIf(Not Me.swMixto, " AND swComposicion=FALSE ", " AND swComposicion=TRUE ") & " AND swMixto=FALSE"
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
        sql &= IIf(Not Me.swMixto, " AND swComposicion=FALSE ", " AND swComposicion=TRUE ") & " AND swMixto=FALSE "

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
                    If Me.swArticulo Then
                        bt.Text = rst("name").Value
                    Else
                        bt.Text = rst("name").Value & IIf(rst("pvp_iva").Value > 0, " +" & Format(rst("pvp_iva").Value, "0.00"), "")
                    End If

                    'bt.Text = rst("name").Value
                    bt.TextAlign = ContentAlignment.MiddleCenter

                    If rst("n_veces").Value > 0 Then
                        bt.Font = New Font("Verdana", 9, FontStyle.Bold)
                    Else
                        bt.Font = New Font("Times New Roman", 8, FontStyle.Regular)
                    End If

                    'If rst("pvp_iva").Value > 0 Then
                    '    bt.Font = New Font("Tahoma", 10, FontStyle.Bold)
                    'End If

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
                    bt.Text = rst("name").Value & IIf(rst("pvp_iva").Value > 0, " +" & Format(rst("pvp_iva").Value, "0.00"), "")
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
        'Me.StrName = CType(sender, Button).Text
        'Me.Id_Ref = CType(sender, Button).Tag
        'Me.DialogResult = Windows.Forms.DialogResult.OK

        Dim rst As ADODB.Recordset = My.m_db.GetRst("SELECT pvp_iva FROM db_articulos WHERE id=" & CType(sender, Button).Tag)
        Me.lblPrecio.Text = Format(CDbl(Me.lblPrecio.Text) + rst("pvp_iva").Value, "0.00")

        If Not Me._swInc Then
            Me.lblPrecio.Text = Format(CDbl(Me.lblPrecio.Text) + My.m_opt.dblIncVarIngredientes, "0.00")
            Me._swInc = True
        End If


        ReDim Preserve arrCombinaDefault(UBound(Me.arrCombinaDefault) + 1)
        Me.arrCombinaDefault(UBound(Me.arrCombinaDefault)) = False
        Me.lst.Items.Add(CType(sender, Button).Text & Space(100) & CType(sender, Button).Tag)



        Me.BtOK.Enabled = True
    End Sub

#End Region



    Private Sub lst_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lst.DoubleClick
        If Me.lst.SelectedIndex < 0 Then Exit Sub
        For j As Integer = Me.lst.SelectedIndex To Me.lst.Items.Count - 2
            Me.arrCombinaDefault(j) = Me.arrCombinaDefault(j + 1)
        Next
        ReDim Preserve arrCombinaDefault(UBound(Me.arrCombinaDefault) - 1)

        Me.lst.Items.Remove(Me.lst.SelectedItem)

        Me.BtOK.Enabled = (Me.lst.Items.Count > 0)

        If Me.swArticulo Then Exit Sub


        'Recalculo importes
        Dim rst As ADODB.Recordset = Nothing
        Dim dbl As Double = 0
        For i As Integer = 0 To Me.lst.Items.Count - 1
            If Not Me.arrCombinaDefault(i) Then
                rst = My.m_db.GetRst("SELECT pvp_iva FROM db_articulos WHERE id=" & CStr(Me.lst.Items(i)).Substring(100).Trim)
                dbl += rst("pvp_iva").Value
            End If
        Next
        Me.lblPrecio.Text = Format(dbl, "0.00")

        'If My.m_opt.dblIncVarIngredientes Then

    End Sub

    Private Sub BtOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtOK.Click
        If Me.lst.Items.Count <= 0 Then Exit Sub
        Me.sCombina = ""

        For i As Integer = 0 To Me.lst.Items.Count - 1
            Me.sCombina &= CStr(Me.lst.Items(i)).Substring(100).Trim & ","

        Next

        Me.DialogResult = Windows.Forms.DialogResult.OK
    End Sub

    Private Sub lst_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lst.SelectedIndexChanged

    End Sub
End Class