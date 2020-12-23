Imports System.IO
Public Class frmArticulos_SelectImgGalery
    Public Id_Ref As Integer = 0

    'Private m_Data As gDevelop.m_dataform

#Region "Eventos Principales"
    Private Sub frmArticulos_SelectImgGalery_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        '####### Cargo las categorias de Imagen
        Dim rst As ADODB.Recordset = My.m_db.GetRst("SELECT * FROM app_imgs_categorias ORDER BY name ASC")

        Me.lst.Items.Add("TODAS" & Space(100) & "0")

        While Not rst.EOF
            Me.lst.Items.Add(rst("name").Value & Space(100) & rst("id").Value)
            rst.MoveNext()
        End While
        My.m_db.CloseRst(rst)

        Me.lst.SelectedIndex = 0


        ''####### Cargo la configuración de las lineas de facturas de proveedores
        'Me.m_Data = New gDevelop.m_dataform(My.m_db)
        'Me.m_Data.DbTable = "app_imgs"
        'Me.m_Data.ConfigureDataForm(Me.Controls)

        'If Me.Id_Ref = 0 Then           'Caso del nuevo
        '    'Establezco estados
        '    Me.LblFh_Alta_nfo.Visible = False
        '    Me.LblFh_Alta.Visible = False

        '    Me.m_Data.data_NewField()

        '    Me.CbImg_Cat.SelectedIndex = 0
        '    Me.ChkNotDelete.Checked = False

        'Else      'Caso de la edicion
        '    Me.m_Data.data_EditField(Me.Id_Ref)

        '    'Establezco la categoria que es
        '    Dim i As Integer
        '    For i = 0 To Me.CbImg_Cat.Items.Count - 1
        '        If Me.TxtId_Categoria.Text = Me.CbImg_Cat.Items(i).Substring(100).Trim Then Me.CbImg_Cat.SelectedIndex = i
        '    Next

        'End If

        Me.AddHandlers()

        'Me.BtDell.Enabled = (Not Me.ChkNotDelete.Checked)
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

    'Private Sub frmArticulos_SelectImgGalery_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
    '    Me.m_Data.Dispose()
    '    m_Data = Nothing
    'End Sub


    Private Sub CbImg_Cat_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'Me._galeria_pag = 0
        'Load_GaleriaImg()
    End Sub
#End Region

#Region "Handlers"
    Private Sub AddHandlers()

    End Sub
#End Region

#Region "Pestaña de Geleria de Imagenes"
    Private _galeria_tot As Integer = 0
    Private _galeria_pag As Integer = 0

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

    Private Sub Load_GaleriaImg()
        Me.PnlGaleria.Visible = False

        Me.BtImg_Previous.Enabled = (Me._galeria_pag > 0)
        Me.BtImg_Next.Enabled = False

        ' Nº de productos a lo ancho y a lo alto a mostrar
        Dim _x As Integer = 5
        Dim _y As Integer = 4

        'Localizacion de inicio para el primer boton
        Dim _left As Integer = 0
        Dim _top As Integer = 0

        'Variables Auxiliares
        Dim i As Integer = 0, j As Integer = 0, n As Integer
        Dim rst As ADODB.Recordset
        Dim sql As String

        '### Paginacion
        sql = "SELECT count(id) as tot FROM app_imgs"
        sql &= " WHERE 1=1 "
        If Me.lst.SelectedIndex > 0 Then sql &= " AND id_categoria=" & Me.lst.Text.Substring(100).Trim
        If Me.txtFilter.TextLength > 0 Then sql &= " AND name LIKE '%" & Me.txtFilter.Text & "%'"
        rst = My.m_db.GetRst(sql)
        Me._galeria_tot = rst("tot").Value
        My.m_db.CloseRst(rst)

        '### Limpio anteriores controltes
        For i = Me.PnlGaleria.Controls.Count - 1 To 0 Step -1
            Me.PnlGaleria.Controls(i).Dispose()
        Next

        '### Obtengo las imagenes de la categoria seleccionada
        sql = "SELECT * FROM app_imgs"
        sql &= " WHERE 1=1 "
        If Me.lst.Text.Substring(100).Trim <> 0 Then sql &= " AND id_categoria=" & Me.lst.Text.Substring(100).Trim
        If Me.txtFilter.TextLength > 0 Then sql &= " AND name LIKE '%" & Me.txtFilter.Text & "%'"
        sql &= " ORDER BY name ASC"
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

        Me.lblNofM.Text = (Me._galeria_pag + 1) & "/" & Format(Me._galeria_tot / (_x * _y), "0") & " >" & (Me._galeria_tot + 1)

        Me.PnlGaleria.Visible = True
    End Sub

    Private Sub BtImg_Move_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtImg_Next.Click, BtImg_Previous.Click
        Select Case True
            Case sender Is Me.BtImg_Previous
                Me._galeria_pag -= 1

            Case sender Is Me.BtImg_Next
                Me._galeria_pag += 1
        End Select

        Load_GaleriaImg()
    End Sub

    Private Sub BtImg_Select_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'Muestro la opcion de editar
        'With frmConfigure_ImgGalery
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

    
    Private Sub lst_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lst.SelectedIndexChanged
        Me._galeria_pag = 0
        Load_GaleriaImg()
    End Sub

    Private Sub txtFilter_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtFilter.TextChanged
        Me._galeria_pag = 0
        Load_GaleriaImg()
    End Sub
End Class