Public Class frmGestion

#Region "Eventos Principales"
    Private Sub frmListados_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.Size = Screen.PrimaryScreen.WorkingArea.Size

        'Centro el body
        Me.PnlBody.Left = CType(Me.Owner, frmMain).PnlBody.Left
        Me.PnlBody.Top = CType(Me.Owner, frmMain).PnlBody.Top
        Me.PnlBody.Visible = True

        Dim FhDesde As Date = CDate("01/" & Format(Now, "MM/yyyy"))
        Dim FhHasta As Date = FhDesde.AddMonths(1).AddDays(-1)

        'Me.FhGeneral_Desde.SetDate(FhDesde)
        'Me.FhGeneral_Hasta.SetDate(FhHasta)

        Me.FhCaja_Desde.Value = FhDesde
        Me.FhCaja_Hasta.Value = FhHasta

        Me.FhDesde_Facturas.Value = FhDesde
        Me.FhHasta_Facturas.Value = FhHasta


        'Cargo los filtros
        Me.Load_Filters()

        Me.CbTipo.SelectedIndex = 0
    End Sub

    Private Sub BtGenerar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtGenerar.Click
        Select Case True
            Case Me.rbtTipo_General.Checked
                Me.Preview_Generales()

            Case Me.rbtTipo_Almacen.Checked
                Me.Preview_Almacen()

            Case Me.rbtTipo_Caja.Checked
                Me.Preview_Caja()

            Case Me.rbtTipo_Facturacion.Checked
                Me.Preview_Facturacion()

        End Select
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
                My.m_msg.MessageError(Me, "Comando de acción de " & cmd & "no controlada.")
        End Select
    End Sub
#End Region

#Region "Eventos Auxiliares"
    Private Sub Buttons_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtMin.Click, BtClose.Click
        'Si no tiene establecido el tag mando un error
        If IsNothing(CType(sender, Button).Tag) OrElse CType(sender, Button).Tag.ToString.Length = 0 Then
            My.m_msg.MessageError(sender, "Tag de control de elemento no referenciado")
            Exit Sub
        End If

        ShellApp(CType(sender, Button).Tag.ToString)
    End Sub

    Private Sub m_logo_MouseDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles m_logo.MouseDoubleClick
        Me.PnlTipoB.Visible = True
    End Sub
#End Region

#Region "Codigo de Generales"
    Private Sub Preview_Generales()
        Dim FrmAux As New frmPreviewReport
        FrmAux.StrName = "Listados Generales"


        Dim StrCab As String = "" ', StrSubCab As String = ""
        Dim StrSQL As String = ""

        'Compongo la sql
        StrSQL &= IIf(StrSQL.Length > 0, " AND ", "") & " {app_empresa.id}=" & My.m_app.GetValue("id_empresa")

        Select Case True
            Case Me.rbtGenerales_Clientes.Checked
                FrmAux.StrSubName = "Listado General de Clientes"

                'Filtrado entre fechas
                'StrSQL &= " AND {db_proveedores_facturas.fh_factura}>=#" & Format(Me.FhGeneral_Desde.SelectionStart, "MM-dd-yyyy") & " 00:00#"
                'StrSQL &= " AND {db_proveedores_facturas.fh_factura}<=#" & Format(Me.FhGeneral_Hasta.SelectionStart, "MM-dd-yyyy") & " 23:59#"

                FrmAux.RptPrint = New crtGeneral_Clientes
                CType(FrmAux.RptPrint, crtGeneral_Clientes).DataDefinition.FormulaFields("CabName").Text = "'Listado de Clientes'"
                CType(FrmAux.RptPrint, crtGeneral_Clientes).DataDefinition.FormulaFields("SubCabName").Text = "'Ordenando por Nombre'"

            Case Me.rbtGenerales_Prov.Checked
                FrmAux.StrSubName = "Listado General de Proveedores"
                FrmAux.RptPrint = New crtGeneral_Proveedores
                CType(FrmAux.RptPrint, crtGeneral_Proveedores).DataDefinition.FormulaFields("CabName").Text = "'Listado de Proveedores'"
                CType(FrmAux.RptPrint, crtGeneral_Proveedores).DataDefinition.FormulaFields("SubCabName").Text = "'Ordenando por Nombre Fiscal'"

            Case Me.rbtGenerales_Usuarios.Checked
                FrmAux.StrSubName = "Listado General de Usuarios"
                FrmAux.RptPrint = New crtGeneral_Usuarios
                CType(FrmAux.RptPrint, crtGeneral_Usuarios).DataDefinition.FormulaFields("CabName").Text = "'Listado de Usuarios'"
                CType(FrmAux.RptPrint, crtGeneral_Usuarios).DataDefinition.FormulaFields("SubCabName").Text = "'Ordenando por Nombre'"

                '            CType(FrmAux.RptPrint, Crystal_Compras_Sencillo).DataDefinition.FormulaFields("Fh_Desde").Text = "'" & Format(Me.FhGeneral_Desde.SelectionStart, "dd/MMMM/yyyy") & "'"
                '            CType(FrmAux.RptPrint, Crystal_Compras_Sencillo).DataDefinition.FormulaFields("Fh_Hasta").Text = "'" & Format(Me.FhGeneral_Hasta.SelectionStart, "dd/MMMM/yyyy") & "'"

                '        Case Me.Rbt_Cajas_Sencillas.Checked
                '            'Filtrado entre fechas
                '            StrSQL = "{db_cajas.fh_caja_desde}>=#" & Format(Me.FhGeneral_Desde.SelectionStart, "MM-dd-yyyy") & " 00:00#"
                '            StrSQL &= " AND {db_cajas.fh_caja_hasta}<=#" & Format(Me.FhGeneral_Hasta.SelectionStart, "MM-dd-yyyy") & " 23:59#"

                '            FrmAux.RptPrint = New Crystal_Cajas_Sencillo
                '            CType(FrmAux.RptPrint, Crystal_Cajas_Sencillo).DataDefinition.FormulaFields("CabName").Text = "'Listado de Cajas'"
                '            CType(FrmAux.RptPrint, Crystal_Cajas_Sencillo).DataDefinition.FormulaFields("SubCabName").Text = "'Mostrando entre fecha de apertura y fecha de cerrado'"

                '            CType(FrmAux.RptPrint, Crystal_Cajas_Sencillo).DataDefinition.FormulaFields("Fh_Desde").Text = "'" & Format(Me.FhGeneral_Desde.SelectionStart, "dd/MMMM/yyyy") & "'"
                '            CType(FrmAux.RptPrint, Crystal_Cajas_Sencillo).DataDefinition.FormulaFields("Fh_Hasta").Text = "'" & Format(Me.FhGeneral_Hasta.SelectionStart, "dd/MMMM/yyyy") & "'"
        End Select

        FrmAux.StrSQL = StrSQL
        FrmAux.ShowDialog(Me)
    End Sub

#End Region

#Region "Codigo de Almacen"
    Private Sub Preview_Almacen()

        'Caso de que sea un resumen del estanco
        If Me.rbtAlmacen_Estanco.Checked Then
            generalAlmacenEstanco()
            Exit Sub
        End If


        Dim StrCab As String = "", StrSQL As String = ""
        Dim FrmAux As New frmPreviewReport

        'Preconfiguro valores personalizados
        FrmAux.StrName = "Listados de Almacén"
        FrmAux.StrSubName = "Listado General de Almacén"

        'Compongo la sql
        StrSQL &= IIf(StrSQL.Length > 0, " AND ", "") & " {app_empresa.id}=" & My.m_app.GetValue("id_empresa")

        'Agrego filtros
        If Me.CbAlmacen_Categoria.SelectedIndex > 0 Then
            StrCab = " y Filtrado por " & Me.CbAlmacen_Categoria.Text.Substring(0, 100).Trim & ""
            StrSQL &= IIf(StrSQL.Length > 0, " AND ", "") & "{db_articulos.id_categoria}=" & Me.CbAlmacen_Categoria.Text.Substring(100).Trim
        End If

        If Me.ChkAlmacen_Estocables.Checked Then
            StrSQL &= IIf(StrSQL.Length > 0, " AND ", "") & " {db_articulos.estocable}=true"

            'Por defecto es la tabla de articulos, a no ser que sea uno especifico de tallas y colores
            Dim strTable As String = "db_articulos"
            Select Case True
                Case Me.Rbt_Stock_01.Checked  'Todos los articulos
                    StrCab &= " # Sin filtro"

                Case Me.Rbt_Stock_02.Checked   'Articulos sin existencias
                    StrSQL &= IIf(StrSQL.Length > 0, " AND ", "") & " {" & strTable & ".ud}<=0"
                    StrCab &= " # Sin existencias"

                Case Me.Rbt_Stock_03.Checked  'Articulos con existencias
                    StrSQL &= IIf(StrSQL.Length > 0, " AND ", "") & " {" & strTable & ".ud}>0"
                    StrCab &= " # Con existencias"

                Case Me.Rbt_Stock_04.Checked  'Articulos bajo optimos
                    StrSQL &= IIf(StrSQL.Length > 0, " AND ", "") & " {" & strTable & ".ud}<={db_articulos.ud_opt}"
                    StrCab &= " # Bajo optimos"

                Case Me.Rbt_Stock_05.Checked  'Articulos bajo minimos
                    StrSQL &= IIf(StrSQL.Length > 0, " AND ", "") & " {" & strTable & ".ud}<={db_articulos.ud_min}"
                    StrCab &= " # Bajo minimos"
            End Select
        End If

        'Dependiendo del tipo de listado....
        Select Case True
            Case Me.rbtAlmacen_Simple.Checked
                FrmAux.RptPrint = New crtAlmacen_General
                CType(FrmAux.RptPrint, crtAlmacen_General).DataDefinition.FormulaFields("CabName").Text = "'Listado de Almacén'"
                CType(FrmAux.RptPrint, crtAlmacen_General).DataDefinition.FormulaFields("SubCabName").Text = "'Ordenando por Nombre" & StrCab & "'"

            Case Me.rbtAlmacen_Agrupado.Checked
                FrmAux.RptPrint = New crtAlmacen_Agrupado
                CType(FrmAux.RptPrint, crtAlmacen_Agrupado).DataDefinition.FormulaFields("CabName").Text = "'Listado de Almacén Agrupado'"
                CType(FrmAux.RptPrint, crtAlmacen_Agrupado).DataDefinition.FormulaFields("SubCabName").Text = "'Ordenando por Nombre de Artículo'"

            Case Me.rbtAlmacen_SimpleValoracion.Checked
                FrmAux.RptPrint = New crtAlmacen_General_stock
                CType(FrmAux.RptPrint, crtAlmacen_General_stock).DataDefinition.FormulaFields("CabName").Text = "'Listado de Almacén Valorativo'"
                CType(FrmAux.RptPrint, crtAlmacen_General_stock).DataDefinition.FormulaFields("SubCabName").Text = "'Ordenando por Nombre de Artículo'"

        End Select

        FrmAux.StrSQL = StrSQL
        FrmAux.ShowDialog(Me)
    End Sub

    'Funcion para imprimir por la impresora de ticket del almacen del estanco
    Private Sub generalAlmacenEstanco()
        If My.MyHardware.IdPort = 0 Then
            MsgBox("No hay configurada ninguna impresora de tickets para realizar la impresión.", MsgBoxStyle.Critical)
            Exit Sub
        End If

        Dim rst As ADODB.Recordset = Nothing, strSQL As String = ""

        'Comprongo los filtros
        strSQL &= IIf(strSQL.Length > 0, " AND ", "") & " activo = True"
        If Me.ChkAlmacen_Estocables.Checked Then
            'strSQL &= IIf(strSQL.Length > 0, " AND ", "") & " {db_articulos.estocable}=true"

            Select Case True
                Case Me.Rbt_Stock_01.Checked  'Todos los articulos


                Case Me.Rbt_Stock_02.Checked   'Articulos sin existencias
                    strSQL &= IIf(strSQL.Length > 0, " AND ", "") & " ud_x10<=0"
                    'StrCab &= " # Sin existencias"

                Case Me.Rbt_Stock_03.Checked  'Articulos con existencias
                    strSQL &= IIf(strSQL.Length > 0, " AND ", "") & " ud_x10>0"
                    'StrCab &= " # Con existencias"

                Case Me.Rbt_Stock_04.Checked  'Articulos bajo optimos
                    strSQL &= IIf(strSQL.Length > 0, " AND ", "") & " ud_x10<=ud_opt"
                    'StrCab &= " # Bajo optimos"

                Case Me.Rbt_Stock_05.Checked  'Articulos bajo minimos
                    strSQL &= IIf(strSQL.Length > 0, " AND ", "") & " ud_x10<=ud_min"
                    'StrCab &= " # Bajo minimos"
            End Select
        Else
            MsgBox("Debe de filtrar los resultados de marcas por artículos estocables, la opción contraria no esta permitida.", MsgBoxStyle.Critical)
            Exit Sub
        End If

        'Cargo los datos
        rst = My.m_db.GetRst("SELECT * FROM estanco_marcas WHERE " & strSQL)


        '<!--### IMPRESIÓN POR LA IMPRESORA DE NOMBRE TICKETS ###-->
        Dim strPrinter As String = "tickets"
        Dim strCod As String = "", strAux As String = ""
        Dim i As Integer = 0, j As Integer = 0

        If My.MyHardware.CodEsc_Init.Length > 0 Then My.RawPrinterHelper.SendStringToPrinter(strPrinter, My.MyHardware.CodEsc_Init & My.MyHardware.CodEsc_Cr)
        strCod = ""

        '###Imprimo los detalles de la Empresa
        ' > Nombre Fiscal
        StrAux = My.m_opt.company_name
        If StrAux.Length > My.MyHardware.Ancho Then StrAux = StrAux.Substring(1, My.MyHardware.Ancho)
        My.RawPrinterHelper.SendStringToPrinter(strPrinter, strCod & My.MyHardware.CodEsc_Negrita_True & StrAux & My.MyHardware.CodEsc_Negrita_True & My.MyHardware.CodEsc_Cr)

        ' > Nombre Fiscal
        'StrAux = "Fecha: " & Format(Me.FhCaja_Desde.Value, "dd/mm/yyyy") & " - " & Format(Me.FhCaja_Hasta.Value, "dd/mm/yyyy")
        'My.RawPrinterHelper.SendStringToPrinter(strPrinter, StrAux & My.MyHardware.CodEsc_Cr)


        StrAux = My.MyHardware.CodEsc_TextNormal & " " & My.MyHardware.CodEsc_Subrayado_True & Space(My.MyHardware.Ancho - 2) & My.MyHardware.CodEsc_Subrayado_False
        My.RawPrinterHelper.SendStringToPrinter(strPrinter, StrAux & My.MyHardware.CodEsc_Cr)

        ' Imprimo la cabecera
        strAux = " " & My.MyHardware.CodEsc_Subrayado_True & "Marca" & My.MyHardware.CodEsc_Subrayado_False
        strAux &= Space(My.MyHardware.Ancho - 15) & My.MyHardware.CodEsc_Subrayado_True & "udTot" & My.MyHardware.CodEsc_Subrayado_False
        'StrAux &= Space(2) & My.MyHardware.CodEsc_Subrayado_True & "udCom" & My.MyHardware.CodEsc_Subrayado_False
        'StrAux &= Space(2) & My.MyHardware.CodEsc_Subrayado_True & "Total" & My.MyHardware.CodEsc_Subrayado_False
        My.RawPrinterHelper.SendStringToPrinter(strPrinter, StrAux & My.MyHardware.CodEsc_Cr)

        While Not rst.EOF
            StrAux = " " & rst("name").Value
            If strAux.Length > My.MyHardware.Ancho - 14 Then strAux = strAux.Substring(0, My.MyHardware.Ancho - 14)
            strAux &= Space(My.MyHardware.Ancho - 24 - strAux.Length)

            strAux &= Space(6 - Format(rst("ud_x10").Value, "###0").Length) & Format(rst("ud_x10").Value, "###0")
            'StrAux &= Space(7 - Format(rst("ud_combina").Value, "####").Length) & Format(rst("ud_combina").Value, "###0")

            'j = (6 - Format(rst("importe").Value, "##0.00").Length)
            'If j < 0 Then j = 0

            'StrAux &= " " & Space(j) & Format(rst("importe").Value, "##0.00")

            My.RawPrinterHelper.SendStringToPrinter(strPrinter, StrAux & My.MyHardware.CodEsc_Cr)
            'rstLines.MoveNext()

            'dblTot += rst("importe").Value
            rst.MoveNext()
        End While

        StrAux = My.MyHardware.CodEsc_TextNormal & " " & My.MyHardware.CodEsc_Subrayado_True & Space(My.MyHardware.Ancho - 2) & My.MyHardware.CodEsc_Subrayado_False
        My.RawPrinterHelper.SendStringToPrinter(strPrinter, StrAux & My.MyHardware.CodEsc_Cr)

        'StrAux = My.MyHardware.CodEsc_Rojo & Space(My.MyHardware.Ancho - 11) & My.MyHardware.CodEsc_TextGrande & My.MyHardware.CodEsc_Negrita_True & Space(i) & Format(dblTot, "###0.00") & " E" & My.MyHardware.CodEsc_Negrita_False & My.MyHardware.CodEsc_TextNormal
        'My.RawPrinterHelper.SendStringToPrinter(strPrinter, StrAux & My.MyHardware.CodEsc_Cr)

        'i = (6 - Format(dblTot, "###0.00").Length)
        'If i < 0 Then i = 0

        My.RawPrinterHelper.SendStringToPrinter(strPrinter, My.MyHardware.CodEsc_Salto & My.MyHardware.CodEsc_Cr)
        If Len(My.MyHardware.CodEsc_Cut) > 0 Then My.RawPrinterHelper.SendStringToPrinter(strPrinter, My.MyHardware.CodEsc_Cut & My.MyHardware.CodEsc_Cr)




    End Sub
#End Region

#Region "Codigo de las Cajas y los Tickets"
    Private Sub Preview_Caja()
        Dim StrCab As String = "", StrSQL As String = ""
        Dim FrmAux As New frmPreviewReport

        'Preconfiguro valores personalizados
        FrmAux.StrName = "Listados de Cajas y Tickets"


        'Compongo la sql
        StrSQL &= IIf(StrSQL.Length > 0, " AND ", "") & " {app_empresa.id}=" & My.m_app.GetValue("id_empresa")


        'StrCab = " entre el " & Format(Me.FhCaja_Desde.Value, "dd/MMyyyy") & " y " & Format(Me.FhCaja_Hasta.Value, "dd/MMyyyy")

        'If Me.CbAlmacen_Categoria.SelectedIndex > 0 Then
        '    StrCab = " y Filtrado por " & Me.CbAlmacen_Categoria.Text.Substring(0, 100).Trim & ""
        '    StrSQL &= IIf(StrSQL.Length > 0, " AND ", "") & "{db_articulos.id_categoria}=" & Me.CbAlmacen_Categoria.Text.Substring(100).Trim
        'End If

        'Dependiendo del tipo de listado....
        Select Case True
            Case Me.rbtCaja_Simple.Checked
                FrmAux.StrSubName = "Listado General de las Cajas y de los Tickets"

                'Agrego filtros: entre fechas
                StrSQL &= " AND {db_cajas.fh_alta}>=#" & Format(Me.FhCaja_Desde.Value, "MM-dd-yyyy") & " 00:00#"
                StrSQL &= " AND {db_cajas.fh_alta}<=#" & Format(Me.FhCaja_Hasta.Value, "MM-dd-yyyy") & " 23:59#"

                FrmAux.RptPrint = New crtCaja_Lista
                CType(FrmAux.RptPrint, crtCaja_Lista).DataDefinition.FormulaFields("CabName").Text = "'Listado de Caja'"
                CType(FrmAux.RptPrint, crtCaja_Lista).DataDefinition.FormulaFields("SubCabName").Text = "'Filtrando por Fecha de la Caja" & StrCab & "'"

                CType(FrmAux.RptPrint, crtCaja_Lista).DataDefinition.FormulaFields("Fh_Desde").Text = "'" & Format(Me.FhCaja_Desde.Value, "dd/MMMM/yyyy") & "'"
                CType(FrmAux.RptPrint, crtCaja_Lista).DataDefinition.FormulaFields("Fh_Hasta").Text = "'" & Format(Me.FhCaja_Hasta.Value, "dd/MMMM/yyyy") & "'"


            Case Me.rbtCaja_Resumen.Checked
                Me.PrintCajaResumenGeneral()
                Exit Sub

            Case Me.rbtCaja_TicketsDia.Checked
                FrmAux.StrSubName = "Listado General de Tickets acumulados por Caja"

                ''Agrego filtros: entre fechas
                'StrSQL &= " AND {db_tickets.fh_finaliza}>=#" & Format(Me.FhCaja_Desde.Value, "MM-dd-yyyy") & " 00:00#"
                'StrSQL &= " AND {db_tickets.fh_finaliza}<=#" & Format(Me.FhCaja_Hasta.Value, "MM-dd-yyyy") & " 23:59#"

                'Agrego filtros: entre fechas
                StrSQL &= " AND {db_cajas.fh_alta}>=#" & Format(Me.FhCaja_Desde.Value, "MM-dd-yyyy") & " 00:00#"
                StrSQL &= " AND {db_cajas.fh_alta}<=#" & Format(Me.FhCaja_Hasta.Value, "MM-dd-yyyy") & " 23:59#"

                FrmAux.RptPrint = New crtCaja_TicketsCaja
                CType(FrmAux.RptPrint, crtCaja_TicketsCaja).DataDefinition.FormulaFields("CabName").Text = "'Listado de Ticket'"
                CType(FrmAux.RptPrint, crtCaja_TicketsCaja).DataDefinition.FormulaFields("SubCabName").Text = "'" & StrCab & "'"

                CType(FrmAux.RptPrint, crtCaja_TicketsCaja).DataDefinition.FormulaFields("Fh_Desde").Text = "'" & Format(Me.FhCaja_Desde.Value, "dd/MMMM/yyyy") & "'"
                CType(FrmAux.RptPrint, crtCaja_TicketsCaja).DataDefinition.FormulaFields("Fh_Hasta").Text = "'" & Format(Me.FhCaja_Hasta.Value, "dd/MMMM/yyyy") & "'"

            Case Me.rbtCaja_Actual.Checked
                StrCab = "Listado de Tickets de la Caja Actual"
                FrmAux.StrSubName = StrCab

                ''Agrego filtros: entre fechas
                'StrSQL &= " AND {db_tickets.fh_finaliza}>=#" & Format(Me.FhCaja_Desde.Value, "MM-dd-yyyy") & " 00:00#"
                'StrSQL &= " AND {db_tickets.fh_finaliza}<=#" & Format(Me.FhCaja_Hasta.Value, "MM-dd-yyyy") & " 23:59#"

                'Agrego filtros: entre fechas
                'StrSQL &= " AND {db_cajas.fh_alta}>=#" & Format(Me.FhCaja_Desde.Value, "MM-dd-yyyy") & " 00:00#"
                'StrSQL &= " AND {db_cajas.fh_alta}<=#" & Format(Me.FhCaja_Hasta.Value, "MM-dd-yyyy") & " 23:59#"

                StrSQL &= " AND {db_tickets.id_caja}=-1"

                FrmAux.RptPrint = New crtCaja_CajaActual
                CType(FrmAux.RptPrint, crtCaja_CajaActual).DataDefinition.FormulaFields("CabName").Text = "'Listado de Ticket'"
                CType(FrmAux.RptPrint, crtCaja_CajaActual).DataDefinition.FormulaFields("SubCabName").Text = "'" & StrCab & "'"

                'CType(FrmAux.RptPrint, crtCaja_CajaActual).DataDefinition.FormulaFields("Fh_Desde").Text = "'" & Format(Me.FhCaja_Desde.Value, "dd/MMMM/yyyy") & "'"
                'CType(FrmAux.RptPrint, crtCaja_CajaActual).DataDefinition.FormulaFields("Fh_Hasta").Text = "'" & Format(Me.FhCaja_Hasta.Value, "dd/MMMM/yyyy") & "'"

            Case Me.rbtCaja_Usuario.Checked
                FrmAux.StrSubName = "Cajas por Usuarios"

                'Agrego filtros: entre fechas
                StrSQL &= " AND {db_cajas.fh_alta}>=#" & Format(Me.FhCaja_Desde.Value, "MM-dd-yyyy") & " 00:00#"
                StrSQL &= " AND {db_cajas.fh_alta}<=#" & Format(Me.FhCaja_Hasta.Value, "MM-dd-yyyy") & " 23:59#"

                FrmAux.RptPrint = New crtCaja_Usuarios
                CType(FrmAux.RptPrint, crtCaja_Usuarios).DataDefinition.FormulaFields("CabName").Text = "'Caja por Usuarios'"
                CType(FrmAux.RptPrint, crtCaja_Usuarios).DataDefinition.FormulaFields("SubCabName").Text = "'Filtrando por Fecha de la Caja" & StrCab & "'"

                CType(FrmAux.RptPrint, crtCaja_Usuarios).DataDefinition.FormulaFields("Fh_Desde").Text = "'" & Format(Me.FhCaja_Desde.Value, "dd/MMMM/yyyy") & "'"
                CType(FrmAux.RptPrint, crtCaja_Usuarios).DataDefinition.FormulaFields("Fh_Hasta").Text = "'" & Format(Me.FhCaja_Hasta.Value, "dd/MMMM/yyyy") & "'"


            Case Me.rbtCaja_UsuarioDetallado.Checked
                FrmAux.StrSubName = "Cajas por Usuarios Detallado"

                'Agrego filtros: entre fechas
                StrSQL &= " AND {db_cajas.fh_alta}>=#" & Format(Me.FhCaja_Desde.Value, "MM-dd-yyyy") & " 00:00#"
                StrSQL &= " AND {db_cajas.fh_alta}<=#" & Format(Me.FhCaja_Hasta.Value, "MM-dd-yyyy") & " 23:59#"

                FrmAux.RptPrint = New crtCaja_UsuariosDetallado
                CType(FrmAux.RptPrint, crtCaja_UsuariosDetallado).DataDefinition.FormulaFields("CabName").Text = "'Caja por Usuarios Detallado'"
                CType(FrmAux.RptPrint, crtCaja_UsuariosDetallado).DataDefinition.FormulaFields("SubCabName").Text = "'Filtrando por Fecha de la Caja" & StrCab & "'"

                CType(FrmAux.RptPrint, crtCaja_UsuariosDetallado).DataDefinition.FormulaFields("Fh_Desde").Text = "'" & Format(Me.FhCaja_Desde.Value, "dd/MMMM/yyyy") & "'"
                CType(FrmAux.RptPrint, crtCaja_UsuariosDetallado).DataDefinition.FormulaFields("Fh_Hasta").Text = "'" & Format(Me.FhCaja_Hasta.Value, "dd/MMMM/yyyy") & "'"

            Case Me.rbtCajas_UsuarioEntradas.Checked
                FrmAux.StrSubName = "Accesos de Usuario"

                'Agrego filtros: entre fechas
                StrSQL &= " AND {db_cajas.fh_alta}>=#" & Format(Me.FhCaja_Desde.Value, "MM-dd-yyyy") & " 00:00#"
                StrSQL &= " AND {db_cajas.fh_alta}<=#" & Format(Me.FhCaja_Hasta.Value, "MM-dd-yyyy") & " 23:59#"

                FrmAux.RptPrint = New crtCaja_UsuariosEntrada
                CType(FrmAux.RptPrint, crtCaja_UsuariosEntrada).DataDefinition.FormulaFields("CabName").Text = "'Accesos de Usuario'"
                CType(FrmAux.RptPrint, crtCaja_UsuariosEntrada).DataDefinition.FormulaFields("SubCabName").Text = "'Filtrando por Fecha de la Caja" & StrCab & "'"

                CType(FrmAux.RptPrint, crtCaja_UsuariosEntrada).DataDefinition.FormulaFields("Fh_Desde").Text = "'" & Format(Me.FhCaja_Desde.Value, "dd/MMMM/yyyy") & "'"
                CType(FrmAux.RptPrint, crtCaja_UsuariosEntrada).DataDefinition.FormulaFields("Fh_Hasta").Text = "'" & Format(Me.FhCaja_Hasta.Value, "dd/MMMM/yyyy") & "'"

            Case Me.rbtCajas_Consumiciones.Checked
                FrmAux.StrSubName = "Entradas de Consumición"

                'Agrego filtros: entre fechas
                StrSQL &= " AND {db_cajas.fh_alta}>=#" & Format(Me.FhCaja_Desde.Value, "MM-dd-yyyy") & " 00:00#"
                StrSQL &= " AND {db_cajas.fh_alta}<=#" & Format(Me.FhCaja_Hasta.Value, "MM-dd-yyyy") & " 23:59#"

                FrmAux.RptPrint = New crtCaja_Entradas
                CType(FrmAux.RptPrint, crtCaja_Entradas).DataDefinition.FormulaFields("CabName").Text = "'Entradas de Consumición'"
                CType(FrmAux.RptPrint, crtCaja_Entradas).DataDefinition.FormulaFields("SubCabName").Text = "'Filtrando por Fecha de la Caja" & StrCab & "'"

                CType(FrmAux.RptPrint, crtCaja_Entradas).DataDefinition.FormulaFields("Fh_Desde").Text = "'" & Format(Me.FhCaja_Desde.Value, "dd/MMMM/yyyy") & "'"
                CType(FrmAux.RptPrint, crtCaja_Entradas).DataDefinition.FormulaFields("Fh_Hasta").Text = "'" & Format(Me.FhCaja_Hasta.Value, "dd/MMMM/yyyy") & "'"

            Case Me.rbtCajas_Consumo.Checked
                FrmAux.StrSubName = "Consumo por Caja"

                'Genero el consumo
                My.m_db_temp.Execute("DELETE * FROM consumos")

                'Prepara filtros
                Dim sFilter As String = ""
                If Me.rbtCajas_Consumo_Estanco.Checked Then sFilter &= ""

                Dim rst As ADODB.Recordset = Nothing
                If Not Me.chkCajas_SoloTickets.Checked Then
                    rst = My.m_db.GetRst("SELECT db_cajas.id,db_tickets.id as idTicket FROM db_cajas,db_tickets WHERE db_tickets.id_caja=db_cajas.id AND db_cajas.fh_alta>=#" & Format(Me.FhCaja_Desde.Value, "MM-dd-yyyy") & " 00:00# and db_cajas.fh_alta<=#" & Format(Me.FhCaja_Hasta.Value, "MM-dd-yyyy") & " 00:00#" & IIf(sFilter.Length > 0, " AND", "") & sFilter)
                Else
                    rst = My.m_db.GetRst("SELECT db_tickets.id as idTicket FROM db_tickets WHERE db_tickets.fh_finaliza>=#" & Format(Me.FhCaja_Desde.Value, "MM-dd-yyyy") & " 00:00# and db_tickets.fh_finaliza<=#" & Format(Me.FhCaja_Hasta.Value, "MM-dd-yyyy") & " 00:00#" & IIf(sFilter.Length > 0, " AND", "") & sFilter)
                End If

                Me.pbBar.Maximum = rst.RecordCount
                Me.pbBar.Value = 0
                Me.pbBar.Visible = True

                Dim rstLines As ADODB.Recordset = Nothing, rstConsumo As ADODB.Recordset = Nothing, rstArticulo As ADODB.Recordset = Nothing, rstTMP As ADODB.Recordset
                Dim sw As Boolean = False
                If rst.RecordCount > 0 Then
                    If Me.chkResumenConcepto.Checked Then
                        While Not rst.EOF

                            sFilter = ""
                            If Me.rbtCajas_Consumo_Estanco.Checked Then
                                sFilter = " AND id_marca>0"
                            ElseIf Me.rbtCajas_Consumo_Local.Checked Then
                                sFilter = " AND id_marca=0"
                            End If
                            rstLines = My.m_db.GetRst("SELECT * FROM db_tickets_lines WHERE id_ticket=" & rst("idTicket").Value & sFilter)

                            While Not rstLines.EOF
                                sw = False
                                'Compruebo si es un artículo de pedido
                                If Me.chkResumenPedidos.Checked Then

                                End If

                                'Compruebo si por ese concepto esta agregado ya
                                rstTMP = My.m_db_temp.GetRst("SELECT id FROM consumos WHERE name='" & rstLines("name").Value & "'")
                                If rstTMP.EOF Then
                                    My.m_db_temp.Execute("INSERT INTO consumos (id_articulo,name,ud,importe) VALUES(" & rstLines("id_articulo").Value & ",'" & rstLines("name").Value & "'," & rstLines("ud").Value.ToString.Replace(",", ".") & "," & rstLines("total").Value.ToString.Replace(",", ".") & ")")
                                Else
                                    My.m_db_temp.Execute("UPDATE consumos SET ud=ud+" & rstLines("ud").Value.ToString.Replace(",", ".") & ",importe=importe+" & rstLines("total").Value.ToString.Replace(",", ".") & " WHERE id=" & rstTMP("id").Value)
                                End If
                                My.m_db_temp.CloseRst(rstTMP)


                                rstLines.MoveNext()
                            End While

                            rst.MoveNext()

                            Me.pbBar.Value += 1
                            Me.pbBar.Refresh()

                        End While
                    Else
                        While Not rst.EOF

                            sFilter = ""
                            If Me.rbtCajas_Consumo_Estanco.Checked Then
                                sFilter = " AND id_marca>0"
                            ElseIf Me.rbtCajas_Consumo_Local.Checked Then
                                sFilter = " AND id_marca=0"
                            End If

                            rstLines = My.m_db.GetRst("SELECT * FROM db_tickets_lines WHERE id_ticket=" & rst("idTicket").Value & sFilter)
                            While Not rstLines.EOF
                                'If rstLines("id_articulo").Value = 28 Then
                                '    MsgBox("")
                                'End If
                                'Compruebo si ya esta agregado el articulo
                                rstConsumo = My.m_db_temp.GetRst("SELECT * FROM consumos WHERE id_articulo=" & rstLines("id_articulo").Value)
                                If rstConsumo.EOF Then
                                    'Distingo el articulo varios y agrego el registro
                                    If rstLines("id_articulo").Value = -1 Then
                                        My.m_db_temp.Execute("INSERT INTO consumos (id_articulo,name,ud,importe) VALUES(" & rstLines("id_articulo").Value & ",'" & rstLines("name").Value & "'," & rstLines("ud").Value.ToString.Replace(",", ".") & "," & rstLines("total").Value.ToString.Replace(",", ".") & ")")
                                    Else
                                        'Obtengo el nombre del articulo y lo agrego
                                        rstArticulo = My.m_db.GetRst("SELECT name FROM db_articulos WHERE id=" & rstLines("id_articulo").Value)
                                        If Not rstArticulo.EOF Then My.m_db_temp.Execute("INSERT INTO consumos (id_articulo,name,ud,importe) VALUES(" & rstLines("id_articulo").Value & ",'" & rstArticulo("name").Value & "'," & rstLines("ud").Value & "," & rstLines("total").Value.ToString.Replace(",", ".") & ")")
                                        My.m_db.CloseRst(rstArticulo)
                                    End If
                                Else
                                    If rstLines("id_articulo").Value = -1 Then
                                        'Compruebo si por ese concepto esta agregado ya
                                        rstTMP = My.m_db_temp.GetRst("SELECT id FROM consumos WHERE name='" & rstLines("name").Value & "'")
                                        If rstTMP.EOF Then
                                            My.m_db_temp.Execute("INSERT INTO consumos (id_articulo,name,ud,importe) VALUES(" & rstLines("id_articulo").Value & ",'" & rstLines("name").Value & "'," & rstLines("ud").Value.ToString.Replace(",", ".") & "," & rstLines("total").Value.ToString.Replace(",", ".") & ")")
                                        Else
                                            My.m_db_temp.Execute("UPDATE consumos SET ud=ud+" & rstLines("ud").Value.ToString.Replace(",", ".") & ",importe=importe+" & rstLines("total").Value.ToString.Replace(",", ".") & " WHERE id=" & rstTMP("id").Value)
                                        End If
                                        My.m_db_temp.CloseRst(rstTMP)

                                    Else
                                        'Actualizo las unidades
                                        My.m_db_temp.Execute("UPDATE consumos SET ud=ud+" & rstLines("ud").Value.ToString.Replace(",", ".") & ",importe=importe+" & rstLines("total").Value.ToString.Replace(",", ".") & " WHERE id_articulo=" & rstLines("id_articulo").Value)
                                    End If
                                End If
                                My.m_db.CloseRst(rstConsumo)

                                'Compruebo si tiene artículo de combinacion
                                If rstLines("id_articulo_combina").Value > 0 Then
                                    'Compruebo si ya esta agregado el articulo
                                    rstConsumo = My.m_db_temp.GetRst("SELECT * FROM consumos WHERE id_articulo=" & rstLines("id_articulo_combina").Value)
                                    If rstConsumo.EOF Then
                                        'Obtengo el nombre del articulo y lo agrego
                                        rstArticulo = My.m_db.GetRst("SELECT name FROM db_articulos WHERE id=" & rstLines("id_articulo_combina").Value)
                                        If Not rstArticulo.EOF Then My.m_db_temp.Execute("INSERT INTO consumos (id_articulo,name,ud,ud_combina) VALUES(" & rstLines("id_articulo_combina").Value & ",'" & rstArticulo("name").Value & "'," & rstLines("ud").Value & "," & rstLines("ud").Value & ")")
                                        My.m_db.CloseRst(rstArticulo)
                                    Else
                                        'Actualizo las unidades
                                        My.m_db_temp.Execute("UPDATE consumos SET ud=ud+" & rstLines("ud").Value & ",ud_combina=ud_combina+" & rstLines("ud").Value & " WHERE id_articulo=" & rstLines("id_articulo_combina").Value)
                                    End If
                                    My.m_db.CloseRst(rstConsumo)
                                End If

                                rstLines.MoveNext()
                            End While
                            My.m_db.CloseRst(rstLines)
                            rst.MoveNext()

                            Me.pbBar.Value += 1
                            Me.pbBar.Refresh()

                        End While
                    End If
                End If
                My.m_db.CloseRst(rst)

                Me.pbBar.Visible = False

                'Genero la impresión por la impresora de tickets
                If Me.chkPrintTicket.Checked Then
                    If My.MyHardware.IdPort = 0 Then
                        MsgBox("No hay configurada ninguna impresora de tickets para realizar la impresión.", MsgBoxStyle.Critical)
                        Exit Sub
                    End If

                    rst = My.m_db_temp.GetRst("SELECT * FROM consumos ORDER BY name ASC")
                    If rst.RecordCount = 0 Then
                        MsgBox("No existe nada que mostrar, compruebe las fechas de selección de cajas.", MsgBoxStyle.Exclamation)
                        My.m_db_temp.CloseRst(rst)
                        Exit Sub
                    End If

                    Dim StrAux As String, i As Integer, j As Integer, strCod As String = ""

                    Dim dblTot As Double = 0

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



                            If My.MyHardware.CodEsc_Init.Length > 0 Then _port.Write(My.MyHardware.CodEsc_Init & My.MyHardware.CodEsc_Cr)
                            strCod = ""

                            '###Imprimo los detalles de la Empresa
                            ' > Nombre Fiscal
                            StrAux = My.m_opt.company_name
                            If StrAux.Length > My.MyHardware.Ancho Then StrAux = StrAux.Substring(1, My.MyHardware.Ancho)
                            _port.Write(strCod & StrAux & My.MyHardware.CodEsc_Cr)

                            StrAux = My.MyHardware.CodEsc_TextNormal & " " & My.MyHardware.CodEsc_Subrayado_True & Space(My.MyHardware.Ancho - 2) & My.MyHardware.CodEsc_Subrayado_False
                            _port.Write(StrAux & My.MyHardware.CodEsc_Cr)

                            ' Imprimo la cabecera
                            StrAux = " " & My.MyHardware.CodEsc_Subrayado_True & "Articulo" & My.MyHardware.CodEsc_Subrayado_False
                            StrAux &= Space(My.MyHardware.Ancho - 29) & My.MyHardware.CodEsc_Subrayado_True & "udTot" & My.MyHardware.CodEsc_Subrayado_False
                            StrAux &= Space(2) & My.MyHardware.CodEsc_Subrayado_True & "udCom" & My.MyHardware.CodEsc_Subrayado_False
                            StrAux &= Space(2) & My.MyHardware.CodEsc_Subrayado_True & "Total" & My.MyHardware.CodEsc_Subrayado_False
                            _port.Write(StrAux & My.MyHardware.CodEsc_Cr)

                            While Not rst.EOF
                                StrAux = " " & rst("name").Value
                                If StrAux.Length > My.MyHardware.Ancho - 20 Then StrAux = StrAux.Substring(0, My.MyHardware.Ancho - 20)
                                StrAux &= Space(My.MyHardware.Ancho - 20 - StrAux.Length)

                                StrAux &= Space(6 - Format(rst("ud").Value, "###0").Length) & Format(rst("ud").Value, "###0")
                                StrAux &= Space(7 - Format(rst("ud_combina").Value, "####").Length) & Format(rst("ud_combina").Value, "###0")

                                j = (6 - Format(rst("importe").Value, "##0.00").Length)
                                If j < 0 Then j = 0

                                StrAux &= " " & Space(j) & Format(rst("importe").Value, "##0.00")

                                _port.Write(StrAux & My.MyHardware.CodEsc_Cr)
                                'rstLines.MoveNext()

                                dblTot += rst("importe").Value
                                rst.MoveNext()
                            End While

                            StrAux = My.MyHardware.CodEsc_TextNormal & " " & My.MyHardware.CodEsc_Subrayado_True & Space(My.MyHardware.Ancho - 2) & My.MyHardware.CodEsc_Subrayado_False
                            _port.Write(StrAux & My.MyHardware.CodEsc_Cr)


                            StrAux = My.MyHardware.CodEsc_TextNormal & " " & My.MyHardware.CodEsc_Subrayado_True & Space(My.MyHardware.Ancho - 2) & My.MyHardware.CodEsc_Subrayado_False
                            _port.Write(StrAux & My.MyHardware.CodEsc_Cr)

                            i = (6 - Format(dblTot, "###0.00").Length)
                            If i < 0 Then i = 0

                            StrAux = My.MyHardware.CodEsc_Rojo & Space(My.MyHardware.Ancho - 11) & My.MyHardware.CodEsc_TextGrande & My.MyHardware.CodEsc_Negrita_True & Space(i) & Format(dblTot, "###0.00") & " E" & My.MyHardware.CodEsc_Negrita_False & My.MyHardware.CodEsc_TextNormal
                            _port.Write(StrAux & My.MyHardware.CodEsc_Cr)


                            _port.Write(My.MyHardware.CodEsc_Salto & My.MyHardware.CodEsc_Cr)
                            If Len(My.MyHardware.CodEsc_Cut) > 0 Then _port.Write(My.MyHardware.CodEsc_Cut & My.MyHardware.CodEsc_Cr)

                            _port.Close()
                            _port.Dispose()

                        Catch ex As Exception
                            MsgBox(ex.Message)
                        End Try

                    ElseIf My.MyHardware.PortName.Substring(0, 3) = "LPT" Then
                        '<!--### IMPRESIÓN POR PUERTO PARALELO ###-->
                        Dim _port As m_Crypto.ioParerellPort
                        _port = New m_Crypto.ioParerellPort("LPT" & My.MyHardware.IdPort)

                        If My.MyHardware.CodEsc_Init.Length > 0 Then _port.Write(My.MyHardware.CodEsc_Init & My.MyHardware.CodEsc_Cr)
                        strCod = ""

                        '###Imprimo los detalles de la Empresa
                        ' > Nombre Fiscal
                        StrAux = My.m_opt.company_name & ""
                        If StrAux.Length > My.MyHardware.Ancho Then StrAux = StrAux.Substring(1, My.MyHardware.Ancho)
                        _port.Write(strCod & StrAux & My.MyHardware.CodEsc_Cr)

                        StrAux = My.MyHardware.CodEsc_TextNormal & " " & My.MyHardware.CodEsc_Subrayado_True & Space(My.MyHardware.Ancho - 2) & My.MyHardware.CodEsc_Subrayado_False
                        _port.Write(StrAux & My.MyHardware.CodEsc_Cr)


                        ' Imprimo la cabecera
                        StrAux = " " & My.MyHardware.CodEsc_Subrayado_True & "Articulo" & My.MyHardware.CodEsc_Subrayado_False
                        StrAux &= Space(My.MyHardware.Ancho - 29) & My.MyHardware.CodEsc_Subrayado_True & "udTot" & My.MyHardware.CodEsc_Subrayado_False
                        StrAux &= Space(2) & My.MyHardware.CodEsc_Subrayado_True & "udCom" & My.MyHardware.CodEsc_Subrayado_False
                        StrAux &= Space(2) & My.MyHardware.CodEsc_Subrayado_True & "Total" & My.MyHardware.CodEsc_Subrayado_False
                        _port.Write(StrAux & My.MyHardware.CodEsc_Cr)

                        While Not rst.EOF
                            StrAux = " " & rst("name").Value
                            If StrAux.Length > My.MyHardware.Ancho - 20 Then StrAux = StrAux.Substring(0, My.MyHardware.Ancho - 20)
                            StrAux &= Space(My.MyHardware.Ancho - 20 - StrAux.Length)

                            StrAux &= Space(6 - Format(rst("ud").Value, "###0").Length) & Format(rst("ud").Value, "###0")
                            StrAux &= Space(7 - Format(rst("ud_combina").Value, "####").Length) & Format(rst("ud_combina").Value, "###0")

                            j = (6 - Format(rst("importe").Value, "##0.00").Length)
                            If j < 0 Then j = 0

                            StrAux &= " " & Space(j) & Format(rst("importe").Value, "##0.00")

                            _port.Write(StrAux & My.MyHardware.CodEsc_Cr)
                            'rst.MoveNext()

                            dblTot += rst("importe").Value
                            rst.MoveNext()
                        End While

                        StrAux = My.MyHardware.CodEsc_TextNormal & " " & My.MyHardware.CodEsc_Subrayado_True & Space(My.MyHardware.Ancho - 2) & My.MyHardware.CodEsc_Subrayado_False
                        _port.Write(StrAux & My.MyHardware.CodEsc_Cr)


                        StrAux = My.MyHardware.CodEsc_TextNormal & " " & My.MyHardware.CodEsc_Subrayado_True & Space(My.MyHardware.Ancho - 2) & My.MyHardware.CodEsc_Subrayado_False
                        _port.Write(StrAux & My.MyHardware.CodEsc_Cr)

                        i = (6 - Format(dblTot, "###0.00").Length)
                        If i < 0 Then i = 0

                        StrAux = My.MyHardware.CodEsc_Rojo & Space(My.MyHardware.Ancho - 11) & My.MyHardware.CodEsc_TextGrande & My.MyHardware.CodEsc_Negrita_True & Space(i) & Format(dblTot, "###0.00") & " E" & My.MyHardware.CodEsc_Negrita_False & My.MyHardware.CodEsc_TextNormal
                        _port.Write(StrAux & My.MyHardware.CodEsc_Cr)

                        _port.Write(My.MyHardware.CodEsc_Salto & My.MyHardware.CodEsc_Cr)
                        If Len(My.MyHardware.CodEsc_Cut) > 0 Then _port.Write(My.MyHardware.CodEsc_Cut & My.MyHardware.CodEsc_Cr)

                        _port.Dispose()

                    Else
                        '<!--### IMPRESIÓN POR LA IMPRESORA DE NOMBRE TICKETS ###-->
                        Dim strPrinter As String = "tickets"
                        If My.MyHardware.CodEsc_Init.Length > 0 Then My.RawPrinterHelper.SendStringToPrinter(strPrinter, My.MyHardware.CodEsc_Init & My.MyHardware.CodEsc_Cr)
                        strCod = ""

                        '###Imprimo los detalles de la Empresa
                        ' > Nombre Fiscal
                        StrAux = My.m_opt.company_name
                        If StrAux.Length > My.MyHardware.Ancho Then StrAux = StrAux.Substring(1, My.MyHardware.Ancho)
                        My.RawPrinterHelper.SendStringToPrinter(strPrinter, strCod & My.MyHardware.CodEsc_Negrita_True & StrAux & My.MyHardware.CodEsc_Negrita_True & My.MyHardware.CodEsc_Cr)

                        ' > Nombre Fiscal
                        StrAux = "Fecha: " & Format(Me.FhCaja_Desde.Value, "dd/MM/yyyy") & " - " & Format(Me.FhCaja_Hasta.Value, "dd/MM/yyyy")
                        My.RawPrinterHelper.SendStringToPrinter(strPrinter, StrAux & My.MyHardware.CodEsc_Cr)


                        StrAux = My.MyHardware.CodEsc_TextNormal & " " & My.MyHardware.CodEsc_Subrayado_True & Space(My.MyHardware.Ancho - 2) & My.MyHardware.CodEsc_Subrayado_False
                        My.RawPrinterHelper.SendStringToPrinter(strPrinter, StrAux & My.MyHardware.CodEsc_Cr)


                        ' Imprimo la cabecera
                        StrAux = " " & My.MyHardware.CodEsc_Subrayado_True & "Articulo" & My.MyHardware.CodEsc_Subrayado_False
                        StrAux &= Space(My.MyHardware.Ancho - IIf(My.MyHardware.Ancho < 40, 16, 29)) & My.MyHardware.CodEsc_Subrayado_True & "udTot" & My.MyHardware.CodEsc_Subrayado_False
                        StrAux &= Space(2) & My.MyHardware.CodEsc_Subrayado_True & "udCom" & My.MyHardware.CodEsc_Subrayado_False
                        StrAux &= Space(2) & My.MyHardware.CodEsc_Subrayado_True & "Total" & My.MyHardware.CodEsc_Subrayado_False
                        My.RawPrinterHelper.SendStringToPrinter(strPrinter, StrAux & My.MyHardware.CodEsc_Cr)

                        While Not rst.EOF
                            StrAux = " " & rst("name").Value
                            IIf(My.MyHardware.Ancho < 40, 10, 29)

                            If StrAux.Length > My.MyHardware.Ancho - IIf(My.MyHardware.Ancho < 40, 7, 20) Then StrAux = StrAux.Substring(0, My.MyHardware.Ancho - IIf(My.MyHardware.Ancho < 40, 7, 20))
                            If My.MyHardware.Ancho - IIf(My.MyHardware.Ancho < 40, 9, 22) - StrAux.Length < 0 Then
                                StrAux = StrAux.Substring(0, My.MyHardware.Ancho - IIf(My.MyHardware.Ancho < 40, 10, 23))
                                StrAux &= Space(My.MyHardware.Ancho - IIf(My.MyHardware.Ancho < 40, 9, 22) - StrAux.Length)
                            Else
                                StrAux &= Space(My.MyHardware.Ancho - IIf(My.MyHardware.Ancho < 40, 9, 22) - StrAux.Length)
                            End If


                            StrAux &= Space(6 - Format(rst("ud").Value, "###0").Length) & Format(rst("ud").Value, "###0")
                            StrAux &= Space(7 - Format(rst("ud_combina").Value, "####").Length) & Format(rst("ud_combina").Value, "###0")

                            j = (6 - Format(rst("importe").Value, "##0.00").Length)
                            If j < 0 Then j = 0

                            StrAux &= " " & Space(j) & Format(rst("importe").Value, "##0.00")

                            My.RawPrinterHelper.SendStringToPrinter(strPrinter, StrAux & My.MyHardware.CodEsc_Cr)
                            'rstLines.MoveNext()

                            dblTot += rst("importe").Value
                            rst.MoveNext()
                        End While

                        StrAux = My.MyHardware.CodEsc_TextNormal & " " & My.MyHardware.CodEsc_Subrayado_True & Space(My.MyHardware.Ancho - 2) & My.MyHardware.CodEsc_Subrayado_False
                        My.RawPrinterHelper.SendStringToPrinter(strPrinter, StrAux & My.MyHardware.CodEsc_Cr)

                        StrAux = My.MyHardware.CodEsc_Rojo & Space(My.MyHardware.Ancho - 11) & My.MyHardware.CodEsc_TextGrande & My.MyHardware.CodEsc_Negrita_True & Space(i) & Format(dblTot, "###0.00") & " E" & My.MyHardware.CodEsc_Negrita_False & My.MyHardware.CodEsc_TextNormal
                        My.RawPrinterHelper.SendStringToPrinter(strPrinter, StrAux & My.MyHardware.CodEsc_Cr)

                        i = (6 - Format(dblTot, "###0.00").Length)
                        If i < 0 Then i = 0

                        My.RawPrinterHelper.SendStringToPrinter(strPrinter, My.MyHardware.CodEsc_Salto & My.MyHardware.CodEsc_Cr)
                        If Len(My.MyHardware.CodEsc_Cut) > 0 Then My.RawPrinterHelper.SendStringToPrinter(strPrinter, My.MyHardware.CodEsc_Cut & My.MyHardware.CodEsc_Cr)

                    End If


                    Exit Sub
                Else

                    FrmAux.RptPrint = New crtCaja_Consumo
                    CType(FrmAux.RptPrint, crtCaja_Consumo).DataDefinition.FormulaFields("CabName").Text = "'Consumos Acumulados'"
                    CType(FrmAux.RptPrint, crtCaja_Consumo).DataDefinition.FormulaFields("SubCabName").Text = "'Consumos acumulados filtrados por Fecha de Caja" & StrCab & "'"

                    CType(FrmAux.RptPrint, crtCaja_Consumo).DataDefinition.FormulaFields("Fh_Desde").Text = "'" & Format(Me.FhCaja_Desde.Value, "dd/MMMM/yyyy") & "'"
                    CType(FrmAux.RptPrint, crtCaja_Consumo).DataDefinition.FormulaFields("Fh_Hasta").Text = "'" & Format(Me.FhCaja_Hasta.Value, "dd/MMMM/yyyy") & "'"
                End If

            Case Else
                MsgBox("No se encuentra el informe destino.", MsgBoxStyle.Critical)
                Exit Sub

        End Select

        FrmAux.StrSQL = StrSQL
        FrmAux.ShowDialog(Me)
    End Sub

#End Region

#Region "Codigo de la Facturación"
    Private Sub Preview_Facturacion()
        Dim StrCab As String = "", StrSQL As String = ""
        Dim FrmAux As New frmPreviewReport

        'Preconfiguro valores personalizados
        FrmAux.StrName = "Listados de Facturacoin"


        'Compongo la sql
        StrSQL &= IIf(StrSQL.Length > 0, " AND ", "") & " {app_empresa.id}=" & My.m_app.GetValue("id_empresa")


        'If Me.CbAlmacen_Categoria.SelectedIndex > 0 Then
        '    StrCab = " y Filtrado por " & Me.CbAlmacen_Categoria.Text.Substring(0, 100).Trim & ""
        '    StrSQL &= IIf(StrSQL.Length > 0, " AND ", "") & "{db_articulos.id_categoria}=" & Me.CbAlmacen_Categoria.Text.Substring(100).Trim
        'End If

        'Dependiendo del tipo de listado....
        Select Case True
            Case Me.rbtFacturacion_FtraCompras.Checked
                FrmAux.StrSubName = "Listado de Facturas de Compras"

                'Agrego filtros: entre fechas
                StrSQL &= " AND {db_facturas_compra.fh_factura}>=#" & Format(Me.FhDesde_Facturas.Value, "MM-dd-yyyy") & " 00:00#"
                StrSQL &= " AND {db_facturas_compra.fh_factura}<=#" & Format(Me.FhHasta_Facturas.Value, "MM-dd-yyyy") & " 23:59#"

                FrmAux.RptPrint = New crtFacturacion_FtraCompras
                CType(FrmAux.RptPrint, crtFacturacion_FtraCompras).DataDefinition.FormulaFields("CabName").Text = "'Listado de Facturas de Compra'"
                CType(FrmAux.RptPrint, crtFacturacion_FtraCompras).DataDefinition.FormulaFields("SubCabName").Text = "'Filtrando por Fecha Factura " & StrCab & "'"

                CType(FrmAux.RptPrint, crtFacturacion_FtraCompras).DataDefinition.FormulaFields("Fh_Desde").Text = "'" & Format(Me.FhDesde_Facturas.Value, "dd/MMMM/yyyy") & "'"
                CType(FrmAux.RptPrint, crtFacturacion_FtraCompras).DataDefinition.FormulaFields("Fh_Hasta").Text = "'" & Format(Me.FhHasta_Facturas.Value, "dd/MMMM/yyyy") & "'"

                'Case Me.rbtAlmacen_Agrupado.Checked
                '    FrmAux.RptPrint = New crtAlmacen_Agrupado
                '    CType(FrmAux.RptPrint, crtAlmacen_Agrupado).DataDefinition.FormulaFields("CabName").Text = "'Listado de Almacén Agrupado'"
                '    CType(FrmAux.RptPrint, crtAlmacen_Agrupado).DataDefinition.FormulaFields("SubCabName").Text = "'Ordenando por Nombre de Artículo'"

            Case Me.rbtFacturacion_FtraCompras_ACT.Checked
                Me.print_AlbaranesCompraTickets()
                Exit Sub


        End Select

        FrmAux.StrSQL = StrSQL
        FrmAux.ShowDialog(Me)
    End Sub

#End Region

    'Private Sub Preview_Generales()
    '    Dim FrmAux As New frmPreviewReport
    '    FrmAux.StrName = "[FACTURAS DE COMPRAS]"
    '    Dim StrCab As String = "" ', StrSubCab As String = ""
    '    Dim StrSQL As String = ""

    '    'Compongo la sql
    '    StrSQL &= IIf(StrSQL.Length > 0, " AND ", "") & " {app_empresa.id}=" & My.m_app.GetValue("id_empresa")

    '    Select Case True
    '        Case Me.Rbt_Proveedores_Facturas.Checked
    '            'Filtrado entre fechas
    '            StrSQL &= " AND {db_proveedores_facturas.fh_factura}>=#" & Format(Me.FhGeneral_Desde.SelectionStart, "MM-dd-yyyy") & " 00:00#"
    '            StrSQL &= " AND {db_proveedores_facturas.fh_factura}<=#" & Format(Me.FhGeneral_Hasta.SelectionStart, "MM-dd-yyyy") & " 23:59#"

    '            FrmAux.RptPrint = New Crystal_Compras_Sencillo
    '            CType(FrmAux.RptPrint, Crystal_Compras_Sencillo).DataDefinition.FormulaFields("CabName").Text = "'Listado de Facturas de Compra'"
    '            CType(FrmAux.RptPrint, Crystal_Compras_Sencillo).DataDefinition.FormulaFields("SubCabName").Text = "'Ordenando por fecha de Factura'"

    '            CType(FrmAux.RptPrint, Crystal_Compras_Sencillo).DataDefinition.FormulaFields("Fh_Desde").Text = "'" & Format(Me.FhGeneral_Desde.SelectionStart, "dd/MMMM/yyyy") & "'"
    '            CType(FrmAux.RptPrint, Crystal_Compras_Sencillo).DataDefinition.FormulaFields("Fh_Hasta").Text = "'" & Format(Me.FhGeneral_Hasta.SelectionStart, "dd/MMMM/yyyy") & "'"

    '        Case Me.Rbt_Cajas_Sencillas.Checked
    '            'Filtrado entre fechas
    '            StrSQL = "{db_cajas.fh_caja_desde}>=#" & Format(Me.FhGeneral_Desde.SelectionStart, "MM-dd-yyyy") & " 00:00#"
    '            StrSQL &= " AND {db_cajas.fh_caja_hasta}<=#" & Format(Me.FhGeneral_Hasta.SelectionStart, "MM-dd-yyyy") & " 23:59#"

    '            FrmAux.RptPrint = New Crystal_Cajas_Sencillo
    '            CType(FrmAux.RptPrint, Crystal_Cajas_Sencillo).DataDefinition.FormulaFields("CabName").Text = "'Listado de Cajas'"
    '            CType(FrmAux.RptPrint, Crystal_Cajas_Sencillo).DataDefinition.FormulaFields("SubCabName").Text = "'Mostrando entre fecha de apertura y fecha de cerrado'"

    '            CType(FrmAux.RptPrint, Crystal_Cajas_Sencillo).DataDefinition.FormulaFields("Fh_Desde").Text = "'" & Format(Me.FhGeneral_Desde.SelectionStart, "dd/MMMM/yyyy") & "'"
    '            CType(FrmAux.RptPrint, Crystal_Cajas_Sencillo).DataDefinition.FormulaFields("Fh_Hasta").Text = "'" & Format(Me.FhGeneral_Hasta.SelectionStart, "dd/MMMM/yyyy") & "'"
    '    End Select

    '    FrmAux.StrSQL = StrSQL
    '    FrmAux.ShowDialog(Me)
    'End Sub

#Region "Funciones"
    Private Sub Load_Filters()
        Dim rst As ADODB.Recordset

        '####### Cargo las categorias de producto
        rst = My.m_db.GetRst("SELECT * FROM db_categorias ORDER BY name ASC")
        Me.CbAlmacen_Categoria.Items.Clear()
        Me.CbAlmacen_Categoria.Items.Add("Mostrar Todos" & Space(100) & "0")
        While Not rst.EOF
            Me.CbAlmacen_Categoria.Items.Add(rst("name").Value & Space(100) & rst("id").Value)
            rst.MoveNext()
        End While
        My.m_db.CloseRst(rst)
        Me.CbAlmacen_Categoria.SelectedIndex = 0

    End Sub
#End Region

    Private Sub rbtTipo_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbtTipo_General.CheckedChanged, rbtTipo_Facturacion.CheckedChanged, rbtTipo_Caja.CheckedChanged, rbtTipo_Almacen.CheckedChanged, rbtTipo_Empresa.CheckedChanged
        Me.groupGenerales.Enabled = Me.rbtTipo_General.Checked
        Me.groupAlmacen.Enabled = Me.rbtTipo_Almacen.Checked
        Me.groupCajas.Enabled = Me.rbtTipo_Caja.Checked
        Me.groupFacturacion.Enabled = Me.rbtTipo_Facturacion.Checked
    End Sub

    Private Sub ChkAlmacen_Estocables_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChkAlmacen_Estocables.CheckedChanged
        Me.groupAlmacen_Estocable.Enabled = Me.ChkAlmacen_Estocables.Checked
    End Sub

    Private Sub rbtCajas_Consumo_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbtCajas_Consumo.CheckedChanged
        Me.chkPrintTicket.Enabled = Me.rbtCajas_Consumo.Checked

        Me.chkResumenConcepto.Enabled = Me.rbtCajas_Consumo.Checked
        Me.chkResumenPedidos.Enabled = Me.rbtCajas_Consumo.Checked
    End Sub

    Private Sub rbtCajas_ConsumoID_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbtCaja_ConsumoID.CheckedChanged, rbtCaja_Actual.CheckedChanged
        If sender Is Me.rbtCaja_ConsumoID Then
            Me.txtCajaID.Enabled = Me.rbtCaja_ConsumoID.Checked
            If Me.rbtCaja_ConsumoID.Checked Then My.AsignarFoco(Me.txtCajaID)
        End If

        Me.groupCajas_fh.Enabled = Not CType(sender, RadioButton).Checked

    End Sub



    Private Sub rbtAlmacen_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbtAlmacen_Simple.CheckedChanged, rbtAlmacen_SimpleValoracion.CheckedChanged, rbtAlmacen_Agrupado.CheckedChanged, rbtAlmacen_Estanco.CheckedChanged
        Me.CbAlmacen_Categoria.Enabled = Not Me.rbtAlmacen_Estanco.Checked
    End Sub



#Region "Resumen de conceptos por impresora de tickets"
    Private Sub PrintCajaResumenGeneral()
        If My.MyHardware.IdPort = 0 Then
            MsgBox("No se ha detectado ningún puerto de Impresión.", MsgBoxStyle.Critical)
            Exit Sub
        End If


        Dim strCod As String = "", strAux As String = "", str As String = ""
        Dim strPrint As String = ""
        Dim rstTMP As ADODB.Recordset = Nothing, rstAux As ADODB.Recordset = Nothing
        Dim dblTotal As Double = 0

        'Cargo los datos de la empresa
        Dim rstEmpresa As ADODB.Recordset = My.m_db.GetRst("SELECT * FROM app_empresa")
        If rstEmpresa.RecordCount <= 0 Then
            MsgBox("Detalles de empresa no localizados")
            Exit Sub
        End If

        Dim rstCajas As ADODB.Recordset = My.m_db.GetRst("SELECT * FROM db_cajas WHERE db_cajas.fh_alta>=#" & Format(Me.FhCaja_Desde.Value, "MM-dd-yyyy") & " 00:00# and db_cajas.fh_alta<=#" & Format(Me.FhCaja_Hasta.Value, "MM-dd-yyyy") & " 00:00#")
        If rstCajas.RecordCount = 0 Then
            MsgBox("No se han encontrado cajas en el periodo establecido.", MsgBoxStyle.Critical)
            Exit Sub
        End If

        

        If My.MyHardware.PortName = "tickets" Then
            Dim strPrinter As String = "tickets"
            If My.MyHardware.CodEsc_Init.Length > 0 Then My.RawPrinterHelper.SendStringToPrinter(strPrinter, My.MyHardware.CodEsc_Init & My.MyHardware.CodEsc_Cr)
            StrCod = ""

            '###Imprimo los detalles de la Empresa
            ' > Nombre Fiscal
            StrAux = rstEmpresa("name_fiscal").Value
            If StrAux.Length > My.MyHardware.Ancho Then StrAux = StrAux.Substring(1, My.MyHardware.Ancho)
            strCod = My.Ticket_ConfigTextStrong("", True)
            strAux = My.Ticket_ConfigTextAling(strAux, HorizontalAlignment.Center)
            strPrint &= strCod & strAux & My.MyHardware.CodEsc_Cr
            'My.RawPrinterHelper.SendStringToPrinter(strPrinter, strCod & strAux & My.MyHardware.CodEsc_Cr)

            ' > Nombre Comercial
            StrAux = """" & rstEmpresa("name_comercial").Value & """"
            If StrAux.Length > My.MyHardware.Ancho Then StrAux = StrAux.Substring(1, My.MyHardware.Ancho)
            strCod = My.Ticket_ConfigTextStrong("", False)
            strAux = My.Ticket_ConfigTextAling(strAux, HorizontalAlignment.Center)
            strPrint &= strCod & strAux & My.MyHardware.CodEsc_Cr
            'My.RawPrinterHelper.SendStringToPrinter(strPrinter, strCod & strAux & My.MyHardware.CodEsc_Cr)

            'Imprimo linea de separacion
            str = My.MyHardware.CodEsc_TextNormal & " " & My.MyHardware.CodEsc_Subrayado_True & Space(38) & My.MyHardware.CodEsc_Subrayado_False
            strPrint &= str & My.MyHardware.CodEsc_Cr


            str = My.MyHardware.CodEsc_TextGrande & My.MyHardware.CodEsc_Negrita_True & "Resumen de Cajas por Conceptos" & My.MyHardware.CodEsc_Negrita_False & My.MyHardware.CodEsc_TextNormal
            strPrint &= str & My.MyHardware.CodEsc_Cr

            str = My.MyHardware.CodEsc_TextNormal & "Periodo: " & Format(Me.FhCaja_Desde.Value, "dd/MMM/yyyy") & "-" & Format(Me.FhCaja_Hasta.Value, "dd/MMM/yyyy")
            strPrint &= str & My.MyHardware.CodEsc_Cr


            'Imprimo linea de separacion
            str = My.MyHardware.CodEsc_TextNormal & " " & My.MyHardware.CodEsc_Subrayado_True & Space(38) & My.MyHardware.CodEsc_Subrayado_False
            strPrint &= str & My.MyHardware.CodEsc_Cr

            '### IMPRIMO LAS CAJAS AFECTADAS
            str = " " & My.MyHardware.CodEsc_Subrayado_True & "Cajas afectadas" & My.MyHardware.CodEsc_Subrayado_False
            strPrint &= str & My.MyHardware.CodEsc_Cr
            While Not rstCajas.EOF
                str = "  > " & Format(rstCajas("fh_alta").Value, "dd/MM/yyyy") & " - " & rstCajas("ncaja").Value
                strPrint &= str & My.MyHardware.CodEsc_Cr

                rstCajas.MoveNext()
            End While
            rstCajas.MoveFirst()

            strPrint &= " " & My.MyHardware.CodEsc_Cr


            '### IMPRIMO RESUMEN POR FAMILIAS
            str = " " & My.MyHardware.CodEsc_Subrayado_True & "Resumen por Conceptos" & My.MyHardware.CodEsc_Subrayado_False
            strPrint &= str & My.MyHardware.CodEsc_Cr

            rstTMP = My.m_db.GetRst("SELECT * FROM db_categorias ORDER BY name ASC")
            dblTotal = 0
            While Not rstTMP.EOF
                rstCajas.MoveFirst()
                dblTotal = 0

                'Obtengo el total de la categoria en cada caja
                While Not rstCajas.EOF
                    rstAux = My.m_db.GetRst("SELECT db_tickets_lines.total FROM db_tickets,db_tickets_lines,db_categorias,db_articulos WHERE db_categorias.id=db_articulos.id_categoria AND db_articulos.id=db_tickets_lines.id_articulo AND db_tickets_lines.id_ticket=db_tickets.id AND db_tickets.id_caja=" & rstCajas("id").Value & " AND db_tickets.estado<>'CANCELADO'" & " AND db_categorias.id=" & rstTMP("id").Value)
                    While Not rstAux.EOF
                        dblTotal += rstAux("total").Value
                        rstAux.MoveNext()
                    End While
                    My.m_db.CloseRst(rstAux)

                    rstCajas.MoveNext()
                End While

                If dblTotal > 0 Then
                    If My.MyHardware.Ancho < 40 AndAlso CStr(rstTMP("name").Value).Length > 21 Then
                        str = "   - " & CStr(rstTMP("name").Value).Substring(0, 20) & ": " & Format(dblTotal, "0.00")
                    Else
                        str = "   - " & rstTMP("name").Value & ": " & Format(dblTotal, "0.00")
                    End If

                    strPrint &= str & My.MyHardware.CodEsc_Cr
                End If

                rstTMP.MoveNext()
            End While
            My.m_db.CloseRst(rstTMP)



            '### IMPRIMO RESUMEN DE ARTICULOS VARIOS
            rstCajas.MoveFirst()
            Dim strIdCaja As String = ""
            While Not rstCajas.EOF
                strIdCaja &= IIf(strIdCaja.Length > 0, " OR ", " ") & " db_tickets.id_caja=" & rstCajas("id").Value

                rstCajas.MoveNext()
            End While

            rstTMP = My.m_db.GetRst("SELECT DISTINCT(db_tickets_lines.name) FROM db_tickets,db_tickets_lines WHERE db_tickets_lines.id_ticket=db_tickets.id AND db_tickets_lines.id_articulo=-1 AND (" & strIdCaja & ")")
            dblTotal = 0
            If rstTMP.RecordCount > 0 Then
                strPrint &= "---" & My.MyHardware.CodEsc_Cr

                While Not rstTMP.EOF
                    rstAux = My.m_db.GetRst("SELECT SUM(db_tickets_lines.total) as nTotal FROM db_tickets,db_tickets_lines WHERE db_tickets_lines.id_ticket=db_tickets.id AND db_tickets_lines.id_articulo=-1 AND (" & strIdCaja & ") AND db_tickets_lines.name='" & rstTMP("name").Value & "'")
                    If IsNumeric(rstAux("nTotal").Value) Then
                        If My.MyHardware.Ancho < 40 AndAlso CStr(rstTMP("name").Value).Length > 21 Then
                            str = "   - " & CStr(rstTMP("name").Value).Substring(0, 20) & ": " & Format(dblTotal, "0.00")
                        Else
                            str = "   - " & rstTMP("name").Value & ": " & Format(dblTotal, "0.00")
                        End If

                        strPrint &= str & My.MyHardware.CodEsc_Cr
                    End If
                    

                    rstTMP.MoveNext()
                End While

            End If
            My.m_db.CloseRst(rstTMP)

            '### CASO DE ESTANCO
            If My.m_opt.modo_compatibilidad = "ESTANCO" Then
                strPrint &= "---" & My.MyHardware.CodEsc_Cr

                rstAux = My.m_db.GetRst("SELECT db_tickets_lines.total FROM db_tickets,db_tickets_lines WHERE db_tickets_lines.id_ticket=db_tickets.id AND (" & strIdCaja & ") AND db_tickets.estado<>'CANCELADO'" & " AND db_tickets_lines.id_marca>0")
                dblTotal = 0
                While Not rstAux.EOF
                    dblTotal += rstAux("total").Value
                    rstAux.MoveNext()
                End While
                If dblTotal > 0 Then
                    str = "   - ESTANCO: " & Format(dblTotal, "0.00")
                    strPrint &= str & My.MyHardware.CodEsc_Cr
                End If
            End If

            'Imprimo linea de separacion
            str = My.MyHardware.CodEsc_TextNormal & " " & My.MyHardware.CodEsc_Subrayado_True & Space(38) & My.MyHardware.CodEsc_Subrayado_False
            strPrint &= str & My.MyHardware.CodEsc_Cr

            '# Imprimo espameo, pego salto y corte
            str = My.MyHardware.CodEsc_Negrita_True & My.Ticket_ConfigTextAling("gTPV " & My.Application.Info.Version.Major & "." & My.Application.Info.Version.Minor & "." & My.Application.Info.Version.Build, HorizontalAlignment.Center) & My.MyHardware.CodEsc_Negrita_False
            strPrint &= My.Ticket_ConfigTextStrong(str, True) & My.MyHardware.CodEsc_Cr

            str = My.MyHardware.CodEsc_Negrita_True & My.Ticket_ConfigTextAling("gDevelop Entertainment", HorizontalAlignment.Center) & My.MyHardware.CodEsc_Negrita_False
            strPrint &= My.Ticket_ConfigTextStrong(str, True) & My.MyHardware.CodEsc_Cr

            strPrint &= My.MyHardware.CodEsc_Salto & My.MyHardware.CodEsc_Cr
            If Len(My.MyHardware.CodEsc_Cut) > 0 Then strPrint &= My.MyHardware.CodEsc_Cut & My.MyHardware.CodEsc_Cr

            '## Imprimo el resumen
            My.RawPrinterHelper.SendStringToPrinter(strPrinter, strPrint)

        Else
            MsgBox("No se ha localizado ninguna impresora de tickets configurada.", MsgBoxStyle.Critical)
        End If

        'Cierro
        My.m_db.CloseRst(rstEmpresa)
        My.m_db.CloseRst(rstCajas)

        MsgBox("Resumen de conceptos impreso correctamente.", MsgBoxStyle.Information)
    End Sub
#End Region

#Region "REsumen de Compras por impresora de tickets"
    Private Sub print_AlbaranesCompraTickets()
        If My.MyHardware.IdPort = 0 Then
            MsgBox("No se ha detectado ningún puerto de Impresión.", MsgBoxStyle.Critical)
            Exit Sub
        End If



        Dim strCod As String = "", strAux As String = "", str As String = ""
        Dim strPrint As String = ""
        Dim rstTMP As ADODB.Recordset = Nothing, rstAux As ADODB.Recordset = Nothing
        Dim dblTotal As Double = 0

        'Cargo los datos de la empresa
        Dim rstEmpresa As ADODB.Recordset = My.m_db.GetRst("SELECT * FROM app_empresa")
        If rstEmpresa.RecordCount <= 0 Then
            MsgBox("Detalles de empresa no localizados")
            Exit Sub
        End If

        Dim rst As ADODB.Recordset = Nothing
        rst = My.m_db.GetRst("SELECT * FROM db_albaranes_compra WHERE db_albaranes_compra.fh_alta>=#" & Format(Me.FhDesde_Facturas.Value, "MM-dd-yyyy") & " 00:00# and db_albaranes_compra.fh_alta<=#" & Format(Me.FhHasta_Facturas.Value, "MM-dd-yyyy") & " 00:00#")


        If My.MyHardware.PortName = "tickets" Then
            Dim strPrinter As String = "tickets"
            If My.MyHardware.CodEsc_Init.Length > 0 Then My.RawPrinterHelper.SendStringToPrinter(strPrinter, My.MyHardware.CodEsc_Init & My.MyHardware.CodEsc_Cr)
            strCod = ""

            '###Imprimo los detalles de la Empresa
            ' > Nombre Fiscal
            strAux = rstEmpresa("name_fiscal").Value
            If strAux.Length > My.MyHardware.Ancho Then strAux = strAux.Substring(1, My.MyHardware.Ancho)
            strCod = My.Ticket_ConfigTextStrong("", True)
            strAux = My.Ticket_ConfigTextAling(strAux, HorizontalAlignment.Center)
            strPrint &= strCod & strAux & My.MyHardware.CodEsc_Cr
            'My.RawPrinterHelper.SendStringToPrinter(strPrinter, strCod & strAux & My.MyHardware.CodEsc_Cr)

            ' > Nombre Comercial
            strAux = """" & rstEmpresa("name_comercial").Value & """"
            If strAux.Length > My.MyHardware.Ancho Then strAux = strAux.Substring(1, My.MyHardware.Ancho)
            strCod = My.Ticket_ConfigTextStrong("", False)
            strAux = My.Ticket_ConfigTextAling(strAux, HorizontalAlignment.Center)
            strPrint &= strCod & strAux & My.MyHardware.CodEsc_Cr
            'My.RawPrinterHelper.SendStringToPrinter(strPrinter, strCod & strAux & My.MyHardware.CodEsc_Cr)

            'Imprimo linea de separacion
            str = My.MyHardware.CodEsc_TextNormal & " " & My.MyHardware.CodEsc_Subrayado_True & Space(38) & My.MyHardware.CodEsc_Subrayado_False
            strPrint &= str & My.MyHardware.CodEsc_Cr


            str = My.MyHardware.CodEsc_TextGrande & My.MyHardware.CodEsc_Negrita_True & "Resumen de Compras" & My.MyHardware.CodEsc_Negrita_False & My.MyHardware.CodEsc_TextNormal
            strPrint &= str & My.MyHardware.CodEsc_Cr

            str = My.MyHardware.CodEsc_TextNormal & "Periodo: " & Format(Me.FhDesde_Facturas.Value, "dd/MMM/yyyy") & "-" & Format(Me.FhHasta_Facturas.Value, "dd/MMM/yyyy")
            strPrint &= str & My.MyHardware.CodEsc_Cr


            'Imprimo linea de separacion
            str = My.MyHardware.CodEsc_TextNormal & " " & My.MyHardware.CodEsc_Subrayado_True & Space(38) & My.MyHardware.CodEsc_Subrayado_False
            strPrint &= str & My.MyHardware.CodEsc_Cr

            While Not rst.EOF
                str = My.MyHardware.CodEsc_TextNormal & "   - " & Format(rst("fh_alta").Value, "dd/MMM/yyyy") & ": " & Format(rst("total").Value, "0.00")
                strPrint &= str & My.MyHardware.CodEsc_Cr

                dblTotal += rst("total").Value
                rst.MoveNext()
            End While

            'Imprimo linea de separacion
            str = My.MyHardware.CodEsc_TextNormal & " " & My.MyHardware.CodEsc_Subrayado_True & Space(38) & My.MyHardware.CodEsc_Subrayado_False
            strPrint &= str & My.MyHardware.CodEsc_Cr

            'Imprimo linea de separacion
            str = My.MyHardware.CodEsc_TextNormal & " " & My.MyHardware.CodEsc_Subrayado_True & "Total" & My.MyHardware.CodEsc_Subrayado_False
            strPrint &= str & My.MyHardware.CodEsc_Cr

            '# Imprimo espameo, pego salto y corte
            str = "   " & My.MyHardware.CodEsc_TextGrande & My.MyHardware.CodEsc_Negrita_True & Format(dblTotal, "0.00") & My.MyHardware.CodEsc_Negrita_False
            str &= My.MyHardware.CodEsc_TextNormal & ""
            strPrint &= My.Ticket_ConfigTextStrong(str, True) & My.MyHardware.CodEsc_Cr

            strPrint &= My.MyHardware.CodEsc_Salto & My.MyHardware.CodEsc_Cr
            If Len(My.MyHardware.CodEsc_Cut) > 0 Then strPrint &= My.MyHardware.CodEsc_Cut & My.MyHardware.CodEsc_Cr

            '## Imprimo el resumen
            My.RawPrinterHelper.SendStringToPrinter(strPrinter, strPrint)
        Else
            MsgBox("No se ha localizado ninguna impresora de tickets configurada.", MsgBoxStyle.Critical)
        End If

        My.m_db.CloseRst(rstEmpresa)
        MsgBox("Resumen de compras impreso correctamente.", MsgBoxStyle.Information)
    End Sub
#End Region

    Private Sub frmGestion_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyValue = Keys.Escape Then Me.Close()
    End Sub
End Class