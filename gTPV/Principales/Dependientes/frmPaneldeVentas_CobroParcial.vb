Public Class frmPaneldeVentas_CobroParcial
    Public Id_Ref As Integer = 0
    Public Id_User As Integer = 0

    Private arrDelField(0) As Integer

    Public swChanges As Boolean = False
    Public swDeleteTicket As Boolean = False




    'Private arrId(0) As Integer
    'Private arrIdArt(0) As Integer

    'Private arrUd_Ticket(0) As Integer
    'Private arrUd_Parcial(0) As Integer
    'Private arrPvp(0) As Double

    Private _LastBt As Button
    Private arrLst(0) As stc_Columns_Tickets


#Region "Eventos Principales"
    Private Sub frmAgenda_SelectMenu_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Size = Screen.PrimaryScreen.WorkingArea.Size

        'Inicializo entorno
        If Not My.m_opt.swResponsive Then
            Me.PnlBody.Left = CType(Me.Owner, frmPaneldeVentas).PnlBody.Left
            Me.PnlBody.Top = CType(Me.Owner, frmPaneldeVentas).PnlBody.Top
        Else
            Me.PnlBody.Left = (Me.Width - Me.PnlBody.Width) / 2
            Me.PnlBody.Top = (Me.SplitContainer.Panel2.Height - Me.PnlBody.Height) / 2 + (IIf(My.m_opt.swNoteBook, Me.SplitContainer.Panel1.Height, 0))
        End If
        Me.PnlBody.Visible = True

        'StrName = ""

        'Dim i As Integer = 0

        ''####### Cargo las categorias de Imagen
        'Dim rst As ADODB.Recordset = My.m_db.GetRst("SELECT * FROM db_categorias ORDER BY name ASC")
        'Dim rstTmp As ADODB.Recordset = Nothing

        'Me.CbCategorias.Items.Clear()
        'While Not rst.EOF
        '    rstTmp = My.m_db.GetRst("SELECT COUNT(id) as ntot FROM db_articulos WHERE is_menu=true AND id_categoria=" & rst("id").Value)
        '    If rstTmp("ntot").Value > 0 Then Me.CbCategorias.Items.Add(rst("name").Value & Space(100) & rst("id").Value)
        '    rst.MoveNext()
        'End While
        'My.m_db.CloseRst(rst)

        '' Si existen artículos de menu
        'If Me.CbCategorias.Items.Count > 0 Then
        '    Me.CbCategorias.SelectedIndex = 0
        '    Me.CbCategorias.Visible = True
        'End If

        'Configuro los listView y Cargo el ticket actual
        Me.ConfigureLst()
        Me.LoadTicket()
        Me.Calcular_Totales()





        Me.Load_GaleriaImg()
    End Sub
#End Region

#Region "Eventos Auxiliares"
    Private Sub Buttons_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtClose.Click, BtCobrar.Click, btCobraTarjeta.Click
        Select Case True
            Case sender Is Me.BtCobrar
                Me.Cobra_Ticket()

            Case sender Is Me.btCobraTarjeta
                Me.Cobra_Ticket(True)

            Case sender Is Me.BtClose
                Me.Close()
        End Select
    End Sub

    Private Sub LstTicket_Original_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LstTicket_Original.SelectedIndexChanged
        Me.BtMove_Right.Enabled = (Me.LstTicket_Original.SelectedItems.Count > 0)
        Me.BtMove_Mas.Enabled = (Me.LstTicket_Original.SelectedItems.Count > 0)
    End Sub

    Private Sub LstTicket_New_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LstTicket_Parcial.SelectedIndexChanged
        Me.BtMove_Left.Enabled = (Me.LstTicket_Parcial.SelectedItems.Count > 0)
        Me.BtMove_Menos.Enabled = (Me.LstTicket_Parcial.SelectedItems.Count > 0)
    End Sub

    Private Sub TmrAvisoPvp_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TmrAvisoPvp.Tick
        Me.TmrAvisoPvp.Enabled = False

        Me._LastBt.Font = New Font("Verdana", 14, FontStyle.Bold)
    End Sub
#End Region

#Region "Handlers"
    Private Sub AddHandlers()

    End Sub
#End Region

#Region "Funciones"
    'Estructura para las columnas de la lista 
    Private Structure stc_Columns_Tickets
        Public id As Integer
        Public id_art As Integer
        Public id_art_combina As Integer
        Public ud As Integer
        Public ud_original As Integer
        Public name As String
        Public pvp_ud As Double
        Public total As Double
        Public comanda As Boolean
        Public id_categoria As Integer
        Public pvp_base As Double
        Public iva As Double
    End Structure

    'Enumeracion para las columnas de la lista 
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
    End Enum

    ' Configuración de los ListView
    Private Sub ConfigureLst()
        With Me.LstTicket_Original.Columns
            .Clear()
            .Add("Ref.", 0, HorizontalAlignment.Right)
            .Add("Id Art", 0, HorizontalAlignment.Right)      'id_articulo
            .Add("Id Art Combina", 0, HorizontalAlignment.Right)      'id_articulo
            .Add("Ud", 40, HorizontalAlignment.Right)
            .Add("Ud Original", 0, HorizontalAlignment.Right)
            .Add("Artículo", 165, HorizontalAlignment.Left)
            .Add("Pvp/Ud", 0, HorizontalAlignment.Right)
            .Add("Total", 55, HorizontalAlignment.Right)
            .Add("Comanda", 0, HorizontalAlignment.Center)
            .Add("Id Categoria", 0, HorizontalAlignment.Center)
            .Add("Base imponible", 0, HorizontalAlignment.Left)
            .Add("IVA", 0, HorizontalAlignment.Left)
        End With

        With Me.LstTicket_Parcial.Columns
            .Clear()
            .Add("Ref.", 0, HorizontalAlignment.Right)
            .Add("Id Art", 0, HorizontalAlignment.Right)      'id_articulo
            .Add("Id Art Combina", 0, HorizontalAlignment.Right)      'id_articulo
            .Add("Ud", 40, HorizontalAlignment.Right)
            .Add("Ud Original", 0, HorizontalAlignment.Right)
            .Add("Artículo", 165, HorizontalAlignment.Left)
            .Add("Pvp/Ud", 0, HorizontalAlignment.Right)
            .Add("Total", 55, HorizontalAlignment.Right)
            .Add("Comanda", 0, HorizontalAlignment.Center)
            .Add("Id Categoria", 0, HorizontalAlignment.Center)
            .Add("Base imponible", 0, HorizontalAlignment.Left)
            .Add("IVA", 0, HorizontalAlignment.Left)
        End With
    End Sub

    'Funcion que me carga el ticket actual
    Private Sub LoadTicket()
        Dim rst As ADODB.Recordset = Nothing
        Dim i As Integer = 0

        '### Cargo las LINEAS
        i = 0
        Me.LstTicket_Original.Items.Clear()
        Me.LstTicket_Parcial.Items.Clear()
        ReDim arrDelField(0)
        ReDim arrLst(0)


        rst = My.m_db.GetRst("SELECT db_tickets_lines.*,db_articulos.id_categoria FROM db_tickets_lines,db_articulos WHERE db_articulos.id=db_tickets_lines.id_articulo AND id_ticket=" & Me.Id_Ref & " ORDER BY db_tickets_lines.id ASC")
        While Not rst.EOF
            With Me.LstTicket_Original
                .Items.Add(rst("id").Value)
                .Items(i).SubItems.Add(rst("id_articulo").Value)
                .Items(i).SubItems.Add(rst("id_articulo_combina").Value)
                .Items(i).SubItems.Add(rst("ud").Value)
                .Items(i).SubItems.Add(rst("ud").Value)
                .Items(i).SubItems.Add(rst("name").Value)              'Si no es combinado la cadena combina esta vacia
                .Items(i).SubItems.Add(Format(rst("pvp_ud").Value, "0.00"))
                .Items(i).SubItems.Add(Format(rst("total").Value, "0.00"))
                .Items(i).SubItems.Add(rst("swcomanda").Value)
                .Items(i).SubItems.Add(rst("id_categoria").Value)
                .Items(i).SubItems.Add(rst("pvp_base").Value)
                .Items(i).SubItems.Add(rst("iva").Value)

                ' Quito los anteriores seleccionados y muestro el ultimo agregado
                .SelectedItems.Clear()
            End With
            i += 1
            rst.MoveNext()
        End While
        My.m_db.CloseRst(rst)

        '### Cargo las LINEAS de los ARTICULOS LIBRE
        rst = My.m_db.GetRst("SELECT * FROM db_tickets_lines WHERE id_articulo=-1 AND id_ticket=" & Me.Id_Ref)
        While Not rst.EOF
            With Me.LstTicket_Original
                .Items.Add(rst("id").Value)
                .Items(i).SubItems.Add(rst("id_articulo").Value)
                .Items(i).SubItems.Add(rst("id_articulo_combina").Value)
                .Items(i).SubItems.Add(rst("ud").Value)
                .Items(i).SubItems.Add(rst("ud").Value)
                .Items(i).SubItems.Add(rst("name").Value)              'Si no es combinado la cadena combina esta vacia
                .Items(i).SubItems.Add(Format(rst("pvp_ud").Value, "0.00"))
                .Items(i).SubItems.Add(Format(rst("total").Value, "0.00"))
                .Items(i).SubItems.Add(rst("swcomanda").Value)
                .Items(i).SubItems.Add(-1)
                .Items(i).SubItems.Add(rst("pvp_base").Value)
                .Items(i).SubItems.Add(rst("iva").Value)

                ' Quito los anteriores seleccionados y muestro el ultimo agregado
                .SelectedItems.Clear()
            End With
            i += 1
            rst.MoveNext()
        End While
        My.m_db.CloseRst(rst)
    End Sub

    'Funcion para calcular totales
    Private Sub Calcular_Totales()
        Dim i As Integer = 0
        Dim Dbl As Double = 0

        'Sumo los importes del Ticket Original
        For i = 0 To Me.LstTicket_Original.Items.Count - 1
            Dbl += CDbl(Me.LstTicket_Original.Items(i).SubItems(lst_Columns_Tickets.total).Text)
        Next
        Me.LblTotal_Original.Text = Format(Dbl, "0.00")


        'Sumo los importes del Ticket Parcial
        Dbl = 0
        For i = 0 To Me.LstTicket_Parcial.Items.Count - 1
            Dbl += CDbl(Me.LstTicket_Parcial.Items(i).SubItems(lst_Columns_Tickets.total).Text)
        Next
        Me.LblTotal_Parcial.Text = Format(Dbl, "0.00")
    End Sub
#End Region

#Region "Botones de Movimiento"
    Private Sub BtMove_Right_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtMove_Right.Click

    End Sub

    Private Sub BtMove_Mas_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtMove_Mas.Click
        Dim i As Integer, index As Integer = Me.LstTicket_Original.SelectedItems(0).Index
        Dim sw As Boolean = True

        'Compruebo si esta ya agregado
        For i = 0 To Me.LstTicket_Parcial.Items.Count - 1
            If Me.LstTicket_Original.Items(index).SubItems(lst_Columns_Tickets.id_art).Text = Me.LstTicket_Parcial.Items(i).SubItems(lst_Columns_Tickets.id_art).Text AndAlso Me.LstTicket_Original.Items(index).SubItems(lst_Columns_Tickets.id_art_combina).Text = Me.LstTicket_Parcial.Items(i).SubItems(lst_Columns_Tickets.id_art_combina).Text Then
                Me.LstTicket_Original.Items(index).SubItems(lst_Columns_Tickets.ud).Text -= 1
                Me.LstTicket_Parcial.Items(i).SubItems(lst_Columns_Tickets.ud).Text += 1

                Me.LstTicket_Original.Items(index).SubItems(lst_Columns_Tickets.total).Text = Format(CDbl(Me.LstTicket_Original.Items(index).SubItems(lst_Columns_Tickets.pvp_ud).Text) * Me.LstTicket_Original.Items(index).SubItems(lst_Columns_Tickets.ud).Text, "0.00")
                Me.LstTicket_Parcial.Items(i).SubItems(lst_Columns_Tickets.total).Text = Format(CDbl(Me.LstTicket_Parcial.Items(i).SubItems(lst_Columns_Tickets.pvp_ud).Text) * Me.LstTicket_Parcial.Items(i).SubItems(lst_Columns_Tickets.ud).Text, "0.00")

                Me.LstTicket_Original.Items(index).Checked = True
                sw = False
                Exit For
            End If
        Next

        ' Tengo que agregar la linea
        If sw Then
            i = Me.LstTicket_Parcial.Items.Count
            Me.LstTicket_Parcial.Items.Add(0)
            Me.LstTicket_Parcial.Items(i).SubItems.Add(Me.LstTicket_Original.Items(index).SubItems(lst_Columns_Tickets.id_art).Text)
            Me.LstTicket_Parcial.Items(i).SubItems.Add(Me.LstTicket_Original.Items(index).SubItems(lst_Columns_Tickets.id_art_combina).Text)
            Me.LstTicket_Parcial.Items(i).SubItems.Add(1)
            Me.LstTicket_Parcial.Items(i).SubItems.Add(0)
            Me.LstTicket_Parcial.Items(i).SubItems.Add(Me.LstTicket_Original.Items(index).SubItems(lst_Columns_Tickets.name).Text)
            Me.LstTicket_Parcial.Items(i).SubItems.Add(Me.LstTicket_Original.Items(index).SubItems(lst_Columns_Tickets.pvp_ud).Text)
            Me.LstTicket_Parcial.Items(i).SubItems.Add(Me.LstTicket_Original.Items(index).SubItems(lst_Columns_Tickets.pvp_ud).Text)
            Me.LstTicket_Parcial.Items(i).SubItems.Add(Me.LstTicket_Original.Items(index).SubItems(lst_Columns_Tickets.comanda).Text)
            Me.LstTicket_Parcial.Items(i).SubItems.Add(Me.LstTicket_Original.Items(index).SubItems(lst_Columns_Tickets.id_categoria).Text)
            Me.LstTicket_Parcial.Items(i).SubItems.Add(Me.LstTicket_Original.Items(index).SubItems(lst_Columns_Tickets.pvp_base).Text)
            Me.LstTicket_Parcial.Items(i).SubItems.Add(Me.LstTicket_Original.Items(index).SubItems(lst_Columns_Tickets.iva).Text)


            Me.LstTicket_Original.Items(index).SubItems(lst_Columns_Tickets.ud).Text -= 1
            Me.LstTicket_Original.Items(index).SubItems(lst_Columns_Tickets.total).Text = Format(CDbl(Me.LstTicket_Original.Items(index).SubItems(lst_Columns_Tickets.pvp_ud).Text) * Me.LstTicket_Original.Items(index).SubItems(lst_Columns_Tickets.ud).Text, "0.00")
            Me.LstTicket_Original.Items(index).Checked = True
        End If

        'Si las unidades son 0 elimino el artículo de la lista
        If Me.LstTicket_Original.Items(index).SubItems(lst_Columns_Tickets.ud).Text = 0 Then
            ReDim Preserve Me.arrDelField(UBound(Me.arrDelField) + 1)
            Me.arrDelField(UBound(Me.arrDelField)) = Me.LstTicket_Original.Items(index).Text
            Me.LstTicket_Original.Items(index).Remove()
            Me.LstTicket_Original.SelectedItems.Clear()
        End If

        'Recalculo totales
        Me.Calcular_Totales()

        Me.LstTicket_Original.Focus()
    End Sub

    Private Sub BtMove_Menos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtMove_Menos.Click

    End Sub
#End Region

#Region "Procesamiento del Ticket"
    Private Sub BtCobra_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtCobra.Click, BtCobraPrint.Click
        Dim rstOriginal As ADODB.Recordset = Nothing, rstParcial As ADODB.Recordset = Nothing
        Dim rstOriginal_Lines As ADODB.Recordset = Nothing, rstParcial_Lines As ADODB.Recordset = Nothing
        Dim i As Integer = 0, sql As String = ""

        rstOriginal = My.m_db.GetRst("SELECT * FROM db_tickets WHERE id=" & Me.Id_Ref)
        rstParcial = My.m_db.GetRst("SELECT * FROM db_tickets WHERE id=-1")


        '### Guardo el ticket parcial
        'Guardo la cabecera del ticket original
        rstParcial.AddNew()
        rstParcial("id_contable").Value = rstOriginal("id_contable").Value
        rstParcial("id_user").Value = Me.Id_User
        rstParcial("id_referencia").Value = rstOriginal("id_referencia").Value
        rstParcial("id_factura").Value = 0
        rstParcial("id_caja").Value = -1
        rstParcial("n_ticket").Value = My.Get_Contador("TICKET")
        rstParcial("estado").Value = "FINALIZADO"
        rstParcial("name_mesa").Value = rstOriginal("name_mesa").Value
        rstParcial("total").Value = CDbl(Me.LblTotal_Parcial.Text)
        rstParcial("fh_alta").Value = Now
        rstParcial("fh_update").Value = Now
        rstParcial("fh_finaliza").Value = Now
        rstParcial.Update()

        'Guardo las lineas del ticket parcial
        'Guardo las lineas
        For i = 0 To Me.LstTicket_Parcial.Items.Count - 1
            sql = "INSERT INTO db_tickets_lines (id_ticket,id_articulo,id_articulo_combina,name,ud,pvp_base,iva,pvp_ud,total,swcomanda) "
            sql &= "VALUES (" & rstParcial("id").Value & ","
            sql &= Me.LstTicket_Parcial.Items(i).SubItems(lst_Columns_Tickets.id_art).Text & ","           'El id del articulo
            sql &= Me.LstTicket_Parcial.Items(i).SubItems(lst_Columns_Tickets.id_art_combina).Text & ","           'El id del articulo con el que ha combinado
            sql &= "'" & Me.LstTicket_Parcial.Items(i).SubItems(lst_Columns_Tickets.name).Text & "',"           'El nombre
            sql &= Me.LstTicket_Parcial.Items(i).SubItems(lst_Columns_Tickets.ud).Text & ","           'El id del articulo con el que ha combinado

            sql &= Me.LstTicket_Parcial.Items(i).SubItems(lst_Columns_Tickets.pvp_base).Text.Replace(",", ".") & ","           'La base imponible
            sql &= Me.LstTicket_Parcial.Items(i).SubItems(lst_Columns_Tickets.iva).Text.Replace(",", ".") & ","           'El iva del articulo
            sql &= Me.LstTicket_Parcial.Items(i).SubItems(lst_Columns_Tickets.pvp_ud).Text.Replace(",", ".") & ","           'El precio unitario
            sql &= Me.LstTicket_Parcial.Items(i).SubItems(lst_Columns_Tickets.total).Text.Replace(",", ".") & ","           'El precio total

            sql &= Me.LstTicket_Parcial.Items(i).SubItems(lst_Columns_Tickets.comanda).Text             'Por si es comanda
            sql &= ")"
            My.m_db.Execute(sql)
        Next



        '### Guardo del ticket original
        'Actualizo los datos de cabecera del ticket
        rstParcial("total").Value = CDbl(Me.LblTotal_Original.Text)
        rstParcial("fh_update").Value = Now
        rstParcial.Update()

        'Elimino las lineas que se han pasado completamente al ticket partcial
        For i = 1 To UBound(Me.arrDelField)
            My.m_db.Execute("DELETE FROM db_tickets_lines WHERE id=" & Me.arrDelField(i))
            'My.m_db.Execute("INSERT INTO db_tickets_loglines (id_ticket,id_articulo,id_articulo_combina,concepto,name,ud,fh) VALUES(" & Me.idRef & "," & Me.LstLines.Items(i).SubItems(lst_Columns_Tickets.id_art).Text & "," & Me.LstLines.Items(i).SubItems(lst_Columns_Tickets.id_art_combina).Text & ",'ACTUALIZA LINEA','" & Me.LstLines.Items(i).SubItems(lst_Columns_Tickets.name).Text & "'," & Replace(CDbl(Me.LstLines.Items(i).SubItems(lst_Columns_Tickets.ud).Text) - CDbl(Me.LstLines.Items(i).SubItems(lst_Columns_Tickets.ud_original).Text), ",", ".") & ",'" & Format(Now, "HH:mm:ss") & "')")
        Next

        'Actualizo las lineas modificadas del ticket actual
        'Guardo las lineas
        For i = 0 To Me.LstTicket_Original.Items.Count - 1
            If Me.LstTicket_Original.Items(i).Checked Then
                'Caso del EDITAR
                sql = "UPDATE db_tickets_lines SET "
                sql &= "ud=" & Replace(Me.LstTicket_Original.Items(i).SubItems(lst_Columns_Tickets.ud).Text, ",", ".")
                sql &= ",total=" & Replace(Me.LstTicket_Original.Items(i).SubItems(lst_Columns_Tickets.total).Text, ",", ".")
                sql &= " WHERE id=" & Me.LstTicket_Original.Items(i).Text
                My.m_db.Execute(sql)

                'My.m_db.Execute("INSERT INTO db_tickets_loglines (id_ticket,id_articulo,id_articulo_combina,concepto,name,ud,fh) VALUES(" & Me.idRef & "," & Me.LstLines.Items(i).SubItems(lst_Columns_Tickets.id_art).Text & "," & Me.LstLines.Items(i).SubItems(lst_Columns_Tickets.id_art_combina).Text & ",'ACTUALIZA LINEA','" & Me.LstLines.Items(i).SubItems(lst_Columns_Tickets.name).Text & "'," & Replace(CDbl(Me.LstLines.Items(i).SubItems(lst_Columns_Tickets.ud).Text) - CDbl(Me.LstLines.Items(i).SubItems(lst_Columns_Tickets.ud_original).Text), ",", ".") & ",'" & Format(Now, "HH:mm:ss") & "')")
            End If
        Next


        Me.swChanges = True

        'Abro el Cajon y Si es BtCobraPrint imprimir el ticket parcial
        My.OpenCajon()
        If sender Is Me.BtCobraPrint Then My.PrintTicket(rstParcial("id").Value)


        'Recargo valores
        Me.LoadTicket()
        Me.Calcular_Totales()
        ReDim arrDelField(0)
    End Sub

    'Funcion para procesar el Cobro del Ticket
    Private Sub Cobra_Ticket(Optional swTarjeta As Boolean = False)
        If CDbl(Me.LblTotal_Parcial.Text) = 0 Then Exit Sub

        If Not swTarjeta Then
            If My.MyHardware.cashlogy_sw Then
                Dim str As String = ""
                str = "#C"
                str &= "#" & Format(Now, "yyyyMMddHHss") 'numero operacion
                str &= "#" & Format(Now, "yyyyMMddHHss") 'Codigo caja
                str &= "#" & Format(CDbl(Me.LblTotal_Parcial.Text) * 100, "00") 'Importe

                My.cashlogy_Send(str & "#0#0#0#0#1#1#0#0#")
                'My.cashlogy_Send("#C#1#1#1000#0#0#0#0#1#1#0#0#")
                str = My.cashlogy_read()
                If str.Substring(0, 11) = "#WR:CANCEL#" Then Exit Sub

            Else
                'Muestro la pantalla de cobro
                frmPaneldeVentas_Cobra.DblTotal = CDbl(Me.LblTotal_Parcial.Text)
                frmPaneldeVentas_Cobra.ShowDialog()
                If frmPaneldeVentas_Cobra.DialogResult <> Windows.Forms.DialogResult.OK Then
                    frmPaneldeVentas_Cobra.Dispose()
                    Exit Sub
                End If
            End If
        End If

        'Declaración de variables usadas
        Dim rstOriginal As ADODB.Recordset = Nothing, rstParcial As ADODB.Recordset = Nothing
        Dim sql As String = "", i As Integer = 0

        rstOriginal = My.m_db.GetRst("SELECT * FROM db_tickets WHERE id=" & Me.Id_Ref)
        rstParcial = My.m_db.GetRst("SELECT * FROM db_tickets WHERE id=-1")


        '### Guardo el ticket parcial
        'Guardo la cabecera del ticket original
        rstParcial.AddNew()
        rstParcial("id_contable").Value = rstOriginal("id_contable").Value
        rstParcial("id_user").Value = Me.Id_User
        rstParcial("id_referencia").Value = rstOriginal("id_referencia").Value
        rstParcial("id_factura").Value = 0
        rstParcial("id_caja").Value = -1
        rstParcial("n_ticket").Value = My.Get_Contador("TICKET")
        rstParcial("estado").Value = "FINALIZADO"
        rstParcial("name_mesa").Value = rstOriginal("name_mesa").Value
        rstParcial("total").Value = CDbl(Me.LblTotal_Parcial.Text)
        rstParcial("fh_alta").Value = Now
        rstParcial("fh_update").Value = Now
        rstParcial("fh_finaliza").Value = Now
        rstParcial.Update()

        'Guardo las lineas del ticket parcial
        'Guardo las lineas
        For i = 0 To Me.LstTicket_Parcial.Items.Count - 1
            sql = "INSERT INTO db_tickets_lines (id_ticket,id_articulo,id_articulo_combina,name,ud,pvp_base,iva,pvp_ud,total,swcomanda) "
            sql &= "VALUES (" & rstParcial("id").Value & ","
            sql &= Me.LstTicket_Parcial.Items(i).SubItems(lst_Columns_Tickets.id_art).Text & ","           'El id del articulo
            sql &= Me.LstTicket_Parcial.Items(i).SubItems(lst_Columns_Tickets.id_art_combina).Text & ","           'El id del articulo con el que ha combinado
            sql &= "'" & Me.LstTicket_Parcial.Items(i).SubItems(lst_Columns_Tickets.name).Text & "',"           'El nombre
            sql &= Me.LstTicket_Parcial.Items(i).SubItems(lst_Columns_Tickets.ud).Text & ","           'El id del articulo con el que ha combinado

            sql &= Me.LstTicket_Parcial.Items(i).SubItems(lst_Columns_Tickets.pvp_base).Text.Replace(",", ".") & ","           'La base imponible
            sql &= Me.LstTicket_Parcial.Items(i).SubItems(lst_Columns_Tickets.iva).Text.Replace(",", ".") & ","           'El iva del articulo
            sql &= Me.LstTicket_Parcial.Items(i).SubItems(lst_Columns_Tickets.pvp_ud).Text.Replace(",", ".") & ","           'El precio unitario
            sql &= Me.LstTicket_Parcial.Items(i).SubItems(lst_Columns_Tickets.total).Text.Replace(",", ".") & ","           'El precio total

            sql &= Me.LstTicket_Parcial.Items(i).SubItems(lst_Columns_Tickets.comanda).Text             'Por si es comanda
            sql &= ")"
            My.m_db.Execute(sql)
        Next

        '### Guardo del ticket original
        'Actualizo los datos de cabecera del ticket
        rstOriginal("total").Value = CDbl(Me.LblTotal_Original.Text)
        rstOriginal("fh_update").Value = Now
        rstOriginal.Update()

        'Elimino las lineas que se han pasado completamente al ticket partcial
        For i = 1 To UBound(Me.arrDelField)
            My.m_db.Execute("DELETE FROM db_tickets_lines WHERE id=" & Me.arrDelField(i))
            'My.m_db.Execute("INSERT INTO db_tickets_loglines (id_ticket,id_articulo,id_articulo_combina,concepto,name,ud,fh) VALUES(" & Me.idRef & "," & Me.LstLines.Items(i).SubItems(lst_Columns_Tickets.id_art).Text & "," & Me.LstLines.Items(i).SubItems(lst_Columns_Tickets.id_art_combina).Text & ",'ACTUALIZA LINEA','" & Me.LstLines.Items(i).SubItems(lst_Columns_Tickets.name).Text & "'," & Replace(CDbl(Me.LstLines.Items(i).SubItems(lst_Columns_Tickets.ud).Text) - CDbl(Me.LstLines.Items(i).SubItems(lst_Columns_Tickets.ud_original).Text), ",", ".") & ",'" & Format(Now, "HH:mm:ss") & "')")
        Next

        'Actualizo las lineas modificadas del ticket actual
        'Guardo las lineas
        For i = 0 To Me.LstTicket_Original.Items.Count - 1
            If Me.LstTicket_Original.Items(i).Checked Then
                'Caso del EDITAR
                sql = "UPDATE db_tickets_lines SET "
                sql &= "ud=" & Replace(Me.LstTicket_Original.Items(i).SubItems(lst_Columns_Tickets.ud).Text, ",", ".")
                sql &= ",total=" & Replace(Me.LstTicket_Original.Items(i).SubItems(lst_Columns_Tickets.total).Text, ",", ".")
                sql &= " WHERE id=" & Me.LstTicket_Original.Items(i).Text
                My.m_db.Execute(sql)

                'My.m_db.Execute("INSERT INTO db_tickets_loglines (id_ticket,id_articulo,id_articulo_combina,concepto,name,ud,fh) VALUES(" & Me.idRef & "," & Me.LstLines.Items(i).SubItems(lst_Columns_Tickets.id_art).Text & "," & Me.LstLines.Items(i).SubItems(lst_Columns_Tickets.id_art_combina).Text & ",'ACTUALIZA LINEA','" & Me.LstLines.Items(i).SubItems(lst_Columns_Tickets.name).Text & "'," & Replace(CDbl(Me.LstLines.Items(i).SubItems(lst_Columns_Tickets.ud).Text) - CDbl(Me.LstLines.Items(i).SubItems(lst_Columns_Tickets.ud_original).Text), ",", ".") & ",'" & Format(Now, "HH:mm:ss") & "')")
            End If
        Next

        'Imprimo el ticket 
        If frmPaneldeVentas_Cobra.swPrintTicket Then
            Dim DblEntrega As Double = 0
            If IsNumeric(frmPaneldeVentas_Cobra.TxtEntrega.Text) Then DblEntrega = CDbl(frmPaneldeVentas_Cobra.TxtEntrega.Text)
            My.PrintTicket(rstParcial("id").Value, DblEntrega)
        Else
            My.OpenCajon()
        End If


        'Recargo valores
        Me.LoadTicket()
        Me.Calcular_Totales()

        Me.Load_GaleriaImg()

        frmPaneldeVentas_Cobra.Dispose()
        Me.swChanges = True

        'Si no queda ningun articulo
        If Me.LstTicket_Original.Items.Count = 0 Then
            Me.swDeleteTicket = True
            Me.DialogResult = Windows.Forms.DialogResult.OK
        End If

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

    ' Funcion para cargar los productos del ticket actual
    Private Sub Load_GaleriaImg()
        Me.PnlGaleria.Visible = False

        Me.BtImg_Previous.Enabled = (Me._galeria_pag > 0)
        Me.BtImg_Next.Enabled = False

        ' Nº de productos a lo ancho y a lo alto a mostrar
        Dim _x As Integer = 5
        Dim _y As Integer = 5

        'Localizacion de inicio para el primer boton
        Dim _left As Integer = 0
        Dim _top As Integer = 0

        'Variables Auxiliares
        Dim i As Integer = 0, j As Integer = 0, n As Integer
        Dim rst As ADODB.Recordset
        Dim sql As String

        '### Paginacion
        sql = "SELECT count(id) as tot FROM db_tickets_lines WHERE id_ticket=" & Me.Id_Ref

        rst = My.m_db.GetRst(sql)
        Me._galeria_tot = rst("tot").Value
        'ReDim Me.arrId(rst("tot").Value - 1)
        'ReDim Me.arrIdArt(rst("tot").Value - 1)
        'ReDim Me.arrUd_Ticket(rst("tot").Value - 1)
        'ReDim Me.arrUd_Parcial(rst("tot").Value - 1)
        'ReDim Me.arrPvp(rst("tot").Value - 1)

        ReDim Me.arrLst(rst("tot").Value - 1)
        My.m_db.CloseRst(rst)

        '### Limpio anteriores controltes
        For i = Me.PnlGaleria.Controls.Count - 1 To 0 Step -1
            Me.PnlGaleria.Controls(i).Enabled = True
            Me.PnlGaleria.Controls(i).Dispose()
        Next

        '### Obtengo las imagenes de la categoria seleccionada        
        sql = "SELECT db_tickets_lines.*,app_imgs.img FROM db_tickets_lines LEFT JOIN "
        sql &= "(db_articulos LEFT JOIN app_imgs ON db_articulos.id_img=app_imgs.id) "
        sql &= " ON db_tickets_lines.id_articulo = db_articulos.id"
        sql &= " WHERE db_tickets_lines.id_ticket=" & Me.Id_Ref
        sql &= " ORDER BY db_tickets_lines.id ASC"

        rst = My.m_db.GetRst(sql)


        '### Agrego los botones de las imagenes
        i = 0 : n = 0
        While Not rst.EOF
            If (n >= (Me._galeria_pag * (_x * _y))) Then
                ' Creo y configuro el nuevo boton
                Dim bt As Button
                bt = New Button
                bt.Enabled = True
                bt.Font = New Font("Verdana", 14, FontStyle.Bold)
                bt.Image = My.m_db.data_GetImgRow(rst("img"))
                bt.Margin = New Padding(0)
                bt.Name = n
                bt.Size = New Size(112, 109)
                bt.TabIndex = n
                bt.Location = New Point(_left + (bt.Width * i), _top + (bt.Height * j))
                'bt.Text = rst("name").Value
                bt.Text = "x" & rst("ud").Value
                bt.TextAlign = ContentAlignment.TopCenter
                bt.Tag = rst("id").Value
                bt.UseVisualStyleBackColor = True

                ' Asigno Eventos
                AddHandler bt.Click, AddressOf BtImg_Select_Click

                'Creo y configuro la etiqueta
                Dim lbl As Label
                lbl = New Label
                With lbl
                    .AutoSize = False
                    .BackColor = Color.Black
                    .Font = New Font("Arial", 6, FontStyle.Regular)
                    .ForeColor = Color.YellowGreen
                    .Location = New Point(_left + (bt.Width * i) + 8, _top + (bt.Height * j) + (bt.Height - 22))
                    .Size = New Size(96, 14)
                    .Text = rst("name").Value
                    .TextAlign = ContentAlignment.MiddleCenter
                    'If IsNothing(rst("img")) = 0 Then .Visible = False
                End With


                Me.PnlGaleria.Controls.Add(lbl)
                Me.PnlGaleria.Controls.Add(bt)
                bt.Visible = True

                'Guardo datos dinamicos
                'Me.arrId(n) = rst("id").Value
                'Me.arrIdArt(n) = rst("id_articulo").Value
                'Me.arrUd_Ticket(n) = rst("ud").Value
                'Me.arrUd_Parcial(n) = rst("ud").Value
                'Me.arrId(n) = rst("pvp_ud").Value

                'Guardo en un array las lineas
                Me.arrLst(n).id = rst("id").Value
                Me.arrLst(n).id_art = rst("id_articulo").Value
                Me.arrLst(n).id_art_combina = rst("id_articulo_combina").Value
                Me.arrLst(n).ud = rst("ud").Value
                Me.arrLst(n).ud_original = rst("ud").Value
                Me.arrLst(n).name = rst("name").Value
                Me.arrLst(n).pvp_ud = rst("pvp_ud").Value
                Me.arrLst(n).total = rst("pvp_ud").Value * rst("ud").Value
                Me.arrLst(n).comanda = rst("swcomanda").Value
                Me.arrLst(n).id_categoria = 0
                Me.arrLst(n).pvp_base = rst("pvp_base").Value
                Me.arrLst(n).iva = rst("iva").Value

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

        Me.Load_GaleriaImg()
    End Sub

    Private Sub BtImg_Select_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'Muestro la opcion de editar
        'With frmConfigure_ImgGalery
        'Me.StrName = CType(sender, Button).Text
        'Me.Id_Ref = CType(sender, Button).Tag
        'Me.DialogResult = Windows.Forms.DialogResult.OK

        '    .ShowDialog(Me)
        '    If .DialogResult <> Windows.Forms.DialogResult.OK Then
        '        .Dispose()
        '        Exit Sub
        '    End If

        '    'Vuelvo a cargar las imagenes
        '    Me.Load_GaleriaImg()

        '    .Dispose()
        'End With

        Dim index As Integer = (CType(sender, Button).Name)

        'Establezco el último boton pulsado
        Me._LastBt = CType(sender, Button)

        'Notifico el cambio
        Me._LastBt.Font = New System.Drawing.Font("Verdana", 18, System.Drawing.FontStyle.Bold)
        Me.TmrAvisoPvp.Enabled = True

        'Proceso el Click
        Me.ProcesaClick(index)
    End Sub

#End Region


#Region "Funciones de Procesamiento"
    'Funcion que me comprueba un articulo (Recibo el indice del array relacionado)
    Private Sub ProcesaClick(ByVal index As Integer)
        Dim i As Integer = 0, sw As Boolean = True

        '### TICKET PARCIAL
        'Compruebo si esta agregada la linea al ticket parcial
        For i = 0 To Me.LstTicket_Parcial.Items.Count - 1
            If Me.arrLst(index).id_art = Me.LstTicket_Parcial.Items(i).SubItems(lst_Columns_Tickets.id_art).Text AndAlso Me.arrLst(index).id_art_combina = Me.LstTicket_Parcial.Items(i).SubItems(lst_Columns_Tickets.id_art_combina).Text Then
                Me.LstTicket_Parcial.Items(i).SubItems(lst_Columns_Tickets.ud).Text = Me.LstTicket_Parcial.Items(i).SubItems(lst_Columns_Tickets.ud).Text + 1
                Me.LstTicket_Parcial.Items(i).SubItems(lst_Columns_Tickets.total).Text = Format(Me.LstTicket_Parcial.Items(i).SubItems(lst_Columns_Tickets.ud).Text * Me.LstTicket_Parcial.Items(i).SubItems(lst_Columns_Tickets.pvp_ud).Text, "0.00")
                sw = False
                Exit For
            End If
        Next

        ' Tengo que agregarlo como nuevo
        If sw Then
            With Me.LstTicket_Parcial
                i = .Items.Count
                .Items.Add(0)
                .Items(i).SubItems.Add(Me.arrLst(index).id_art)
                .Items(i).SubItems.Add(Me.arrLst(index).id_art_combina)
                .Items(i).SubItems.Add(1)
                .Items(i).SubItems.Add(0)
                .Items(i).SubItems.Add(Me.arrLst(index).name)
                .Items(i).SubItems.Add(Format(Me.arrLst(index).pvp_ud, "0.00"))
                .Items(i).SubItems.Add(Format(Me.arrLst(index).pvp_ud, "0.00"))
                .Items(i).SubItems.Add(Me.arrLst(index).comanda)
                .Items(i).SubItems.Add(0)
                .Items(i).SubItems.Add(Me.arrLst(index).pvp_base)
                .Items(i).SubItems.Add(Me.arrLst(index).iva)

                ' Quito los anteriores seleccionados y muestro el ultimo agregado
                .SelectedItems.Clear()
            End With
        End If


        '### TICKET ORIGINAL
        'Compruebo en el tickel original el articulo
        'For i = Me.LstTicket_Original.Items.Count - 1 To 0 Step -1
        For i = 0 To Me.LstTicket_Original.Items.Count - 1
            If Me.arrLst(index).id_art = Me.LstTicket_Original.Items(i).SubItems(lst_Columns_Tickets.id_art).Text AndAlso Me.arrLst(index).id_art_combina = Me.LstTicket_Original.Items(i).SubItems(lst_Columns_Tickets.id_art_combina).Text Then
                Me.LstTicket_Original.Items(i).SubItems(lst_Columns_Tickets.ud).Text = Me.LstTicket_Original.Items(i).SubItems(lst_Columns_Tickets.ud).Text - 1
                Me.LstTicket_Original.Items(i).SubItems(lst_Columns_Tickets.total).Text = Format(Me.LstTicket_Original.Items(i).SubItems(lst_Columns_Tickets.ud).Text * Me.LstTicket_Original.Items(i).SubItems(lst_Columns_Tickets.pvp_ud).Text, "0.00")
                Me.LstTicket_Original.Items(i).Checked = True

                'Si lo tengo que eliminar
                If Me.LstTicket_Original.Items(i).SubItems(lst_Columns_Tickets.ud).Text = 0 Then
                    ReDim Preserve Me.arrDelField(UBound(Me.arrDelField) + 1)
                    Me.arrDelField(UBound(Me.arrDelField)) = Me.LstTicket_Original.Items(index).Text

                    'Me.LstTicket_Original.Items(i).Remove()
                    Me.LstTicket_Original.SelectedItems.Clear()
                End If
                Exit For
            End If
        Next


        '### LISTA DE BOTONES
        'Deberia restar 1
        Me.arrLst(index).ud -= 1

        'Configuro formatos
        If Me.arrLst(index).ud > 0 Then
            Me._LastBt.Text = "x" & Me.arrLst(index).ud
        Else
            Me._LastBt.Text = ""
            Me._LastBt.Enabled = False
        End If

        Me.BtCobrar.Enabled = (Me.LstTicket_Parcial.Items.Count > 0)
        Me.btCobraTarjeta.Enabled = (Me.LstTicket_Parcial.Items.Count > 0)

        Me.Calcular_Totales()
    End Sub
#End Region
End Class