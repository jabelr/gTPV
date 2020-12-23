Public Class frmPaneldeVentas_CobraCashlogy
    Public Id_Ref As Integer = 0
    Public strTicket As String = ""
    Public DblTotal As Double = 0.0

    Public swPrintTicket As Boolean = False

    Public swPagoTarjeta As Boolean = False

    Public swPagoEfectivo As Boolean = True
    Public swNota As Boolean = False


    Public id_User As Integer = 0


    Private _swUserIS As Boolean = False


    Private _arrCash As String()

#Region "AYUDA"
    '    6.4.3 Realización de cobros sin mostrar las pantallas de Cashlogy Connector.
    'La realización de los cobros en Cashlogy Connector se puede hacer sin mostrar las pantallas que presenta esta aplicación.
    'Para ello, se deberá actuar de la siguiente forma:
    ' Una vez que el TPV ha realizado una venta, debe activar la admisión de billetes y monedas mediante el comando #B#
    ' A continuación, el TPV deberá ir consultando periódicamente el importe introducido mediante el comando #Q#. Se deberá presentar este valor en formato adecuado para el usuario.
    ' Una vez que el efectivo introducido ha alcanzado el importe de la venta, se deberá finalizar el proceso de admisión mediante el comando #J#.
    ' A continuación, el TPV deberá calcular el importe a devolver (en caso de que no se haya introducido la cantidad exacta) y devolverlo mediante el comando #P# e indicando 0 en el parámetro de mostrar pantalla.


    '6.3.12
    'Cadena que se envía: #B#a#b#c#
#End Region

#Region "Eventos Principales"

    Private Sub frmPaneldeVentas_CobraCashlogy_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
        If e.KeyChar = Chr(27) Then Me.Close()
    End Sub

    Private Sub frmPaneldeVentas_Cobra_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Doy formatos
        Me.lblTotal.Text = Format(Me.DblTotal, "0.00")

        Me.getInfoUser()
        'Me.BtCobraPrint.Enabled = (My.MyHardware.IdPort > 0)

        'Realizo lectura del buffer (OK de inicializacion)
        'My.Application.cashlogy_bytes = Nothing
        'My.Application.cashlogy_sCadena = ""

        'My.Application.cashlogy_sCadena = "#B#"
        'My.Application.cashlogy_bytes = System.Text.Encoding.ASCII.GetBytes(My.Application.cashlogy_sCadena)
        'My.Application.sIOCashlogy.Write(My.Application.cashlogy_bytes, 0, My.Application.cashlogy_bytes.Length)


        'My.Application.cashlogy_sCadena = ""
        'My.Application.cashlogy_bytes = Nothing

        Dim str As String = ""
        'Cadena que se envía: #B#a#b#c#


        Me.ViewCash()



        'Mandamos a cobrar
        My.cashlogy_Send("#B#0#0#0#")
        str = My.cashlogy_read()

        Me.tmrStatus.Enabled = True

        'If str.Substring(0, 10) = "#WR:LEVEL#" Then
        '    'Me.PnlTab.Visible = False
        '    Me.PnlStartCL.Visible = True
        '    My.cashlogy_Send("#J#")

        '    ' Pauso para que cierre la tobera
        '    Threading.Thread.Sleep(4000)

        '    ' REALIZO RECUENTO DE MONEDAS
        '    Me.ViewCash()

        '    MsgBox("Hay que realizar una inicialización de efectivo.", MsgBoxStyle.Exclamation)
        '    'Me.lblWait.Text = "INIT"



        '    Exit Sub
        'End If

        '' INIALIALIZO EL TEMPORIZADOR
        'My.Application.tmrCashlogy = New System.Windows.Forms.Timer
        'My.Application.tmrCashlogy.Enabled = True
        'My.Application.tmrCashlogy.Interval = 1000
        'My.Application.tmrCashlogy.Start()
        'AddHandler My.Application.tmrCashlogy.Tick, AddressOf tmrcashlogy_Tick

        Me.tmrCheck.Enabled = True
        Me.tmrCheck.Start()
        Me.trmCheck_Tick(Me.tmrCheck, New System.EventArgs)
    End Sub
#End Region

#Region "Eventos Auxiliares"

    Private Sub frmPaneldeVentas_Cobra_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        'Me.m_Data.Dispose()
        'm_Data = Nothing
        'My.Application.tmrCashlogy
        Me.tmrCheck.Stop()
        If Not IsNothing(My.Application.tmrCashlogy) Then
            My.Application.tmrCashlogy.Stop()
            My.Application.tmrCashlogy.Enabled = False
            RemoveHandler My.Application.tmrCashlogy.Tick, AddressOf tmrcashlogy_Tick
        End If

        My.cashlogy_Send("#J#")

    End Sub

#End Region

    Private Sub BtCobraPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If Me.DblTotal < 0 Then
            MsgBox("Imposible cobrar un importe inferior a 0.", MsgBoxStyle.Critical)
            Exit Sub
        End If

        Me.swPagoEfectivo = True

        Me.swPrintTicket = True
        Me.DialogResult = Windows.Forms.DialogResult.OK
    End Sub

    Private Sub BtCobra_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If Me.DblTotal < 0 Then
            MsgBox("Imposible cobrar un importe inferior a 0.", MsgBoxStyle.Critical)
            Exit Sub
        End If

        Me.DialogResult = Windows.Forms.DialogResult.OK
    End Sub





    Private Sub btAnota_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If Me.DblTotal < 0 Then
            MsgBox("Imposible cobrar un importe inferior a 0.", MsgBoxStyle.Critical)
            Exit Sub
        End If

        Me.swPagoEfectivo = True
        Me.swNota = True

        Me.DialogResult = Windows.Forms.DialogResult.OK
    End Sub



    Dim _swColor As Boolean = True
    Private Sub tmrcashlogy_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'Me.lblWait.ForeColor = If(_swColor, Color.OrangeRed, Color.DarkSeaGreen)
        Me._swColor = Not Me._swColor




        'My.Application.cashlogy_bytes = Nothing
        'My.Application.cashlogy_sCadena = ""

        'Threading.Thread.Sleep(1000)

        If My.Application.sIOCashlogy.DataAvailable Then
            Dim str As String = My.cashlogy_read()
            'MsgBox(str)
            'lst.Items.Add(str)

        End If



        'My.Application.cashlogy_sCadena = ""
        'My.Application.cashlogy_bytes = Nothing
    End Sub

    Private Sub trmCheck_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tmrCheck.Tick
        Dim str As String = ""
        My.cashlogy_Send("#Q#")
        str = My.cashlogy_read()

        Me._arrCash = Split(str, "#")

        If Me._arrCash.Length > 5 Then Exit Sub
        If Not IsNumeric(Me._arrCash(2)) Then Exit Sub

        Me.lblTotActual.Text = Format(Val(Me._arrCash(2) / 100), "0.00")

        Me.ViewCash()
    End Sub

    Private Sub PnlStartCL_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles PnlStartCL.Paint

    End Sub

    ' Show cash actually in Cashlogi
    Private _initCashlogi As Boolean = True
    Private Sub ViewCash()
        Dim str As String
        Dim aStr As String()
        Dim aCash As String()
        Dim aCash_billetes As String()
        Dim aStaker As String()
        Dim aStaker_billetes As String()
        Dim sTMP As String()

init:

        My.cashlogy_Send("#Y#")
        My.cashlogy_Send("#Y#")
        str = My.cashlogy_read()
        aStr = Split(str, "#")

        ' SEPARO MONEDAS DE BILLETES
        sTMP = Split(aStr(2), ";")
        'If sTMP.Length < 2 Then Exit Sub

        aCash = Split(sTMP(0), ",")
        Try
            aCash_billetes = Split(sTMP(1), ",")
        Catch ex As Exception

            GoTo init
        End Try


        sTMP = Split(aStr(3), ";")
        aStaker = Split(sTMP(0), ",")
        aStaker_billetes = Split(sTMP(1), ",")


        'aCash = Split(aStr(2), ",")
        'aStaker = Split(aStr(3), ",")
        Me.txtCashAllow_1ctms.Text = Val(Split(aCash(0), ":")(1)) + Val(Split(aStaker(0), ":")(1)) - Val(Me.txtCashFirst_1ctms.Text)
        Me.txtCashAllow_2ctms.Text = Val(Split(aCash(1), ":")(1)) + Val(Split(aStaker(1), ":")(1)) - Val(Me.txtCashFirst_2ctms.Text)
        Me.txtCashAllow_5ctms.Text = Val(Split(aCash(2), ":")(1)) + Val(Split(aStaker(2), ":")(1)) - Val(Me.txtCashFirst_5ctms.Text)
        Me.txtCashAllow_10ctms.Text = Val(Split(aCash(3), ":")(1)) + Val(Split(aStaker(3), ":")(1)) - Val(Me.txtCashFirst_10ctms.Text)
        Me.txtCashAllow_20ctms.Text = Val(Split(aCash(4), ":")(1)) + Val(Split(aStaker(4), ":")(1)) - Val(Me.txtCashFirst_20ctms.Text)
        Me.txtCashAllow_50ctms.Text = Val(Split(aCash(5), ":")(1)) + Val(Split(aStaker(5), ":")(1)) - Val(Me.txtCashFirst_50ctms.Text)
        Me.txtCashAllow_100ctms.Text = Val(Split(aCash(6), ":")(1)) + Val(Split(aStaker(6), ":")(1)) - Val(Me.txtCashFirst_100ctms.Text)
        Me.txtCashAllow_200ctms.Text = Val(Split(aCash(7), ":")(1)) + Val(Split(aStaker(7), ":")(1)) - Val(Me.txtCashFirst_200ctms.Text)

        Me.txtCashAllow_500ctms.Text = Val(Split(aCash_billetes(0), ":")(1)) + Val(Split(aStaker_billetes(0), ":")(1)) - Val(Me.txtCashFirst_500ctms.Text)
        Me.txtCashAllow_1000ctms.Text = Val(Split(aCash_billetes(1), ":")(1)) + Val(Split(aStaker_billetes(1), ":")(1)) - Val(Me.txtCashFirst_1000ctms.Text)
        Me.txtCashAllow_2000ctms.Text = Val(Split(aCash_billetes(2), ":")(1)) + Val(Split(aStaker_billetes(2), ":")(1)) - Val(Me.txtCashFirst_2000ctms.Text)
        Me.txtCashAllow_5000ctms.Text = Val(Split(aCash_billetes(3), ":")(1)) + Val(Split(aStaker_billetes(3), ":")(1)) - Val(Me.txtCashFirst_5000ctms.Text)
        Me.txtCashAllow_10000ctms.Text = Val(Split(aCash_billetes(4), ":")(1)) + Val(Split(aStaker_billetes(4), ":")(1)) - Val(Me.txtCashFirst_10000ctms.Text)
        Me.txtCashAllow_20000ctms.Text = Val(Split(aCash_billetes(5), ":")(1)) + Val(Split(aStaker_billetes(5), ":")(1)) - Val(Me.txtCashFirst_20000ctms.Text)
        Me.txtCashAllow_50000ctms.Text = Val(Split(aCash_billetes(6), ":")(1)) + Val(Split(aStaker_billetes(6), ":")(1)) - Val(Me.txtCashFirst_50000ctms.Text)



        Me.txtCashAllow_1ctms.Visible = True
        Me.txtCashAllow_2ctms.Visible = True
        Me.txtCashAllow_5ctms.Visible = True
        Me.txtCashAllow_10ctms.Visible = True
        Me.txtCashAllow_20ctms.Visible = True
        Me.txtCashAllow_50ctms.Visible = True
        Me.txtCashAllow_100ctms.Visible = True
        Me.txtCashAllow_200ctms.Visible = True

        Me.txtCashAllow_500ctms.Visible = True
        Me.txtCashAllow_1000ctms.Visible = True
        Me.txtCashAllow_2000ctms.Visible = True
        Me.txtCashAllow_5000ctms.Visible = True
        Me.txtCashAllow_10000ctms.Visible = True
        Me.txtCashAllow_20000ctms.Visible = True
        Me.txtCashAllow_50000ctms.Visible = True


        '' 5 ctmos
        'My.cashlogy_Send("#X#5#")
        'str = My.cashlogy_read()
        'aStr = Split(str, "#")
        'Me.txtCashAllow_5ctms.Text = Val(aStr(2)) + Val(aStr(3)) - Val(Me.txtCashFirst_5ctms.Text)
        'Me.txtCashAllow_5ctms.Visible = True

        '' 10 ctmos
        'My.cashlogy_Send("#X#10#")
        'str = My.cashlogy_read()
        'aStr = Split(str, "#")
        'Me.txtCashAllow_10ctms.Text = Val(aStr(2)) + Val(aStr(3)) - Val(Me.txtCashFirst_10ctms.Text)
        'Me.txtCashAllow_10ctms.Visible = True

        '' 20 ctmos
        'My.cashlogy_Send("#X#20#")
        'str = My.cashlogy_read()
        'aStr = Split(str, "#")
        'Me.txtCashAllow_20ctms.Text = Val(aStr(2)) + Val(aStr(3)) - Val(Me.txtCashFirst_20ctms.Text)
        'Me.txtCashAllow_20ctms.Visible = True

        '' 50 ctmos
        'My.cashlogy_Send("#X#50#")
        'str = My.cashlogy_read()
        'aStr = Split(str, "#")
        'Me.txtCashAllow_50ctms.Text = Val(aStr(2)) + Val(aStr(3)) - Val(Me.txtCashFirst_50ctms.Text)
        'Me.txtCashAllow_50ctms.Visible = True

        '' 100 ctmos (1€)
        'My.cashlogy_Send("#X#100#")
        'str = My.cashlogy_read()
        'aStr = Split(str, "#")
        'Me.txtCashAllow_100ctms.Text = Val(aStr(2)) + Val(aStr(3)) - Val(Me.txtCashFirst_100ctms.Text)
        'Me.txtCashAllow_100ctms.Visible = True


        '' 200 ctmos (2€)
        'My.cashlogy_Send("#X#200#")
        'str = My.cashlogy_read()
        'aStr = Split(str, "#")
        'Me.txtCashAllow_200ctms.Text = Val(aStr(2)) + Val(aStr(3)) - Val(Me.txtCashFirst_200ctms.Text)
        'Me.txtCashAllow_200ctms.Visible = True


        If _initCashlogi Then
            Me.txtCashAllow_1ctms.Text = 0
            Me.txtCashAllow_2ctms.Text = 0
            Me.txtCashAllow_5ctms.Text = 0
            Me.txtCashAllow_10ctms.Text = 0
            Me.txtCashAllow_20ctms.Text = 0
            Me.txtCashAllow_50ctms.Text = 0
            Me.txtCashAllow_100ctms.Text = 0
            Me.txtCashAllow_200ctms.Text = 0

            Me.txtCashAllow_500ctms.Text = 0
            Me.txtCashAllow_1000ctms.Text = 0
            Me.txtCashAllow_2000ctms.Text = 0
            Me.txtCashAllow_5000ctms.Text = 0
            Me.txtCashAllow_10000ctms.Text = 0
            Me.txtCashAllow_20000ctms.Text = 0
            Me.txtCashAllow_50000ctms.Text = 0

            My.cashlogy_Send("#Y#")
            str = My.cashlogy_read()
            aStr = Split(str, "#")

            ' SEPARO MONEDAS DE BILLETES
            sTMP = Split(aStr(2), ";")
            aCash = Split(sTMP(0), ",")
            aCash_billetes = Split(sTMP(1), ",")

            sTMP = Split(aStr(3), ";")
            aStaker = Split(sTMP(0), ",")
            aStaker_billetes = Split(sTMP(1), ",")


            'aCash_billetes = Split(aStr(2), ",")

            'aCash = Split(aStr(2), ",")
            'aStaker = Split(aStr(3), ",")
            Me.txtCashFirst_1ctms.Text = Val(Split(aCash(0), ":")(1)) + Val(Split(aStaker(0), ":")(1))
            Me.txtCashFirst_2ctms.Text = Val(Split(aCash(1), ":")(1)) + Val(Split(aStaker(1), ":")(1))
            Me.txtCashFirst_5ctms.Text = Val(Split(aCash(2), ":")(1)) + Val(Split(aStaker(2), ":")(1))
            Me.txtCashFirst_10ctms.Text = Val(Split(aCash(3), ":")(1)) + Val(Split(aStaker(3), ":")(1))
            Me.txtCashFirst_20ctms.Text = Val(Split(aCash(4), ":")(1)) + Val(Split(aStaker(4), ":")(1))
            Me.txtCashFirst_50ctms.Text = Val(Split(aCash(5), ":")(1)) + Val(Split(aStaker(5), ":")(1))
            Me.txtCashFirst_100ctms.Text = Val(Split(aCash(6), ":")(1)) + Val(Split(aStaker(6), ":")(1))
            Me.txtCashFirst_200ctms.Text = Val(Split(aCash(7), ":")(1)) + Val(Split(aStaker(7), ":")(1))

            Me.txtCashFirst_500ctms.Text = Val(Split(aCash_billetes(0), ":")(1)) + Val(Split(aStaker_billetes(0), ":")(1))
            Me.txtCashFirst_1000ctms.Text = Val(Split(aCash_billetes(1), ":")(1)) + Val(Split(aStaker_billetes(1), ":")(1))
            Me.txtCashFirst_2000ctms.Text = Val(Split(aCash_billetes(2), ":")(1)) + Val(Split(aStaker_billetes(2), ":")(1))
            Me.txtCashFirst_5000ctms.Text = Val(Split(aCash_billetes(3), ":")(1)) + Val(Split(aStaker_billetes(3), ":")(1))
            Me.txtCashFirst_10000ctms.Text = Val(Split(aCash_billetes(4), ":")(1)) + Val(Split(aStaker_billetes(4), ":")(1))
            Me.txtCashFirst_20000ctms.Text = Val(Split(aCash_billetes(5), ":")(1)) + Val(Split(aStaker_billetes(5), ":")(1))
            Me.txtCashFirst_50000ctms.Text = Val(Split(aCash_billetes(6), ":")(1)) + Val(Split(aStaker_billetes(6), ":")(1))


            Me.txtCashFirst_1ctms.Visible = True
            Me.txtCashFirst_2ctms.Visible = True
            Me.txtCashFirst_5ctms.Visible = True
            Me.txtCashFirst_10ctms.Visible = True
            Me.txtCashFirst_20ctms.Visible = True
            Me.txtCashFirst_50ctms.Visible = True
            Me.txtCashFirst_100ctms.Visible = True
            Me.txtCashFirst_200ctms.Visible = True

            Me.txtCashFirst_500ctms.Visible = True
            Me.txtCashFirst_1000ctms.Visible = True
            Me.txtCashFirst_2000ctms.Visible = True
            Me.txtCashFirst_5000ctms.Visible = True
            Me.txtCashFirst_10000ctms.Visible = True
            Me.txtCashFirst_20000ctms.Visible = True
            Me.txtCashFirst_50000ctms.Visible = True


            '' Cantidad que hay la primera vez
            'My.cashlogy_Send("#X#5#")
            'str = My.cashlogy_read()
            'aStr = Split(str, "#")
            'Me.txtCashFirst_5ctms.Text = Val(aStr(2)) + Val(aStr(3))
            'Me.txtCashFirst_5ctms.Visible = True

            'My.cashlogy_Send("#X#10#")
            'str = My.cashlogy_read()
            'aStr = Split(str, "#")
            'Me.txtCashFirst_10ctms.Text = Val(aStr(2)) + Val(aStr(3))
            'Me.txtCashFirst_10ctms.Visible = True

            'My.cashlogy_Send("#X#20#")
            'str = My.cashlogy_read()
            'aStr = Split(str, "#")
            'Me.txtCashFirst_20ctms.Text = Val(aStr(2)) + Val(aStr(3))
            'Me.txtCashFirst_20ctms.Visible = True

            'My.cashlogy_Send("#X#50#")
            'str = My.cashlogy_read()
            'aStr = Split(str, "#")
            'Me.txtCashFirst_50ctms.Text = Val(aStr(2)) + Val(aStr(3))
            'Me.txtCashFirst_50ctms.Visible = True

            'My.cashlogy_Send("#X#100#")
            'str = My.cashlogy_read()
            'aStr = Split(str, "#")
            'Me.txtCashFirst_100ctms.Text = Val(aStr(2)) + Val(aStr(3))
            'Me.txtCashFirst_100ctms.Visible = True

            'My.cashlogy_Send("#X#200#")
            'str = My.cashlogy_read()
            'aStr = Split(str, "#")
            'Me.txtCashFirst_200ctms.Text = Val(aStr(2)) + Val(aStr(3))
            'Me.txtCashFirst_200ctms.Visible = True


            _initCashlogi = False
        End If



        'CONSULTA DE ESTADOS
        My.cashlogy_Send("#GC#")
        str = My.cashlogy_read()
        aStr = Split(str, "#")

        ' SEPARO MONEDAS DE BILLETES (sTMP(0) > Monedas | sTMP(1) > Billetes)
        sTMP = Split(aStr(2), ";")
        aCash = Split(sTMP(0), ",")

        Me.lblNfo_1ctms.BackColor = getColorStatus(Val(Split(aCash(0), ":")(1)))
        Me.lblNfo_2ctms.BackColor = getColorStatus(Val(Split(aCash(1), ":")(1)))
        Me.lblNfo_5ctms.BackColor = getColorStatus(Val(Split(aCash(2), ":")(1)))
        Me.lblNfo_10ctms.BackColor = getColorStatus(Val(Split(aCash(3), ":")(1)))
        Me.lblNfo_20ctms.BackColor = getColorStatus(Val(Split(aCash(4), ":")(1)))
        Me.lblNfo_50ctms.BackColor = getColorStatus(Val(Split(aCash(5), ":")(1)))
        Me.lblNfo_100ctms.BackColor = getColorStatus(Val(Split(aCash(6), ":")(1)))
        Me.lblNfo_200ctms.BackColor = getColorStatus(Val(Split(aCash(7), ":")(1)))

        aCash = Split(sTMP(1), ",")
        Me.lblNfo_500ctms.BackColor = getColorStatus(Val(Split(aCash(0), ":")(1)))
        Me.lblNfo_1000ctms.BackColor = getColorStatus(Val(Split(aCash(1), ":")(1)))
        Me.lblNfo_2000ctms.BackColor = getColorStatus(Val(Split(aCash(2), ":")(1)))
        Me.lblNfo_5000ctms.BackColor = getColorStatus(Val(Split(aCash(3), ":")(1)))
        Me.lblNfo_10000ctms.BackColor = getColorStatus(Val(Split(aCash(4), ":")(1)))
        Me.lblNfo_20000ctms.BackColor = getColorStatus(Val(Split(aCash(5), ":")(1)))
        Me.lblNfo_50000ctms.BackColor = getColorStatus(Val(Split(aCash(6), ":")(1)))


    End Sub

    Private Sub btAddCash_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btAddCash.Click
        Me._initCashlogi = True
        Me.btAddCash.Enabled = False
        Me.lblStatus.Text = "ADD CASH"
        Me.btENDCash.Enabled = True
        My.cashlogy_Send("#A#2#")
        My.cashlogy_Send("#B#0#0#0#")

        If Not Me.tmrCheck.Enabled Then
            Me.tmrCheck.Enabled = True
            Me.tmrCheck.Start()
            Me.trmCheck_Tick(Me.tmrCheck, New System.EventArgs)
        End If
    End Sub

    Private Sub btENDCash_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btENDCash.Click
        'Me.tmrCheck.Enabled = False
        Me.lblStatus.Text = "COBRAR1"

        Dim str As String = ""
        My.cashlogy_Send("#J#")
        str = My.cashlogy_read()


        Me.btENDCash.Enabled = False
        Me.btAddCash.Enabled = True

        Me.lblTotActual.Text = Format(0, "0.00")

        Me._initCashlogi = True
        Me.ViewCash()

        ' AL FINALIZAR DEVUELVO EL IMPORTE CARGADO

    End Sub

    Private Sub btCashReload_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btCashReload.Click
        'Me.trmCheck_Tick(Me.tmrCheck, New System.EventArgs)
        Me._initCashlogi = True
        Me.ViewCash()

        MsgBox("Recarga terminada.", MsgBoxStyle.Information)
    End Sub

    Private Function getColorStatus(ByVal id As Integer) As System.Drawing.Color
        Dim color As System.Drawing.Color = color.CornflowerBlue
        Select Case id
            Case 0 : color = Me.lblNfo_0.BackColor
            Case 11 : color = Me.lblNfo_11.BackColor
            Case 12 : color = Me.lblNfo_12.BackColor
            Case 21 : color = Me.lblNfo_21.BackColor
            Case 22 : color = Me.lblNfo_22.BackColor

        End Select

        Return color
    End Function



    Private Sub btLoadCash_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btLoadCash.Click
        ' Abrimos tobera
        My.cashlogy_Send("#B#0#0#0#")
    End Sub


    Private Sub btSelectUser_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btSelectUser.Click
        Dim idUsr As Integer = My.IdentificaUser()
        If idUsr < 0 Then Exit Sub

        Me._swUserIS = True
        Me.id_User = idUsr
        Me.getInfoUser()
    End Sub

    Private Sub getInfoUser()
        Me.lblNameUser.Text = ""
        Dim rst As ADODB.Recordset = My.m_db.GetRst("SELECT * FROM db_usuarios WHERE id=" & Me.id_User)
        If Not rst.EOF Then
            Me.lblNameUser.Text = rst("name").Value
            Me.lblNameUser.ForeColor = Color.FromArgb(rst("color").Value)

            If Me._swUserIS Then Me.btAddCash.Enabled = True
        End If
        My.m_db.CloseRst(rst)
    End Sub

    Private Sub tmrStatus_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tmrStatus.Tick
        Me.lblStatus.BackColor = IIf(Me.lblStatus.BackColor = Color.LightBlue, Color.LemonChiffon, Color.LightBlue)
    End Sub

    Private Sub btCancela_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btCancela.Click
        Me.DialogResult = DialogResult.Cancel
    End Sub

End Class