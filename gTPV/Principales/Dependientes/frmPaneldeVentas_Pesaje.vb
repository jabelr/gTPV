Public Class frmPaneldeVentas_Pesaje
    Public IdRef As Integer

    Private _swPrecioFijado As Boolean = False
    Private _dblPrecio As Double = 0

#Region "Puerto"
    Private WithEvents m_io As IO.Ports.SerialPort
    Private _strLast As String = ""

    'Funcion que me abre el puerto de la balanza
    Private Sub OpenPort()
        Try
            'Preconfiguro y abro el puerto
            Me.m_io = New IO.Ports.SerialPort
            With Me.m_io
                .PortName = My.MyHardware.Balanza_Port
                .BaudRate = 9600
                .Parity = IO.Ports.Parity.None
                .DataBits = 8
                .StopBits = 1
                .Handshake = IO.Ports.Handshake.None

                .DiscardNull = True
                .DtrEnable = True
                .ReadTimeout = 0
                .WriteBufferSize = 1024
                .Open()

                If My.MyHardware.Balanza_tipo = 2 Then
                    .NewLine = Chr(13)
                End If
            End With
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error conectando")
            Exit Sub
        End Try
    End Sub

    'Funcion para testear el precio
    Private Sub CheckPort()
        If My.MyHardware.Balanza_tipo = 2 Then Exit Sub

        On Error Resume Next
        Dim StrTrama As String = ""
        Dim pvp As String = Format(CDbl(Me.LblPrecio.Text), "000.00").Replace(",", "")


        '98PPPPPCCrLf
        StrTrama &= 9                 '9 - 0x38h
        StrTrama &= 8                 '8 - 0x39h
        StrTrama &= pvp                 'PPPPP - Precio (Sin coma)

        StrTrama &= CheckSUM(StrTrama)

        StrTrama &= Chr(13)                 'Cr
        StrTrama &= Chr(10)                 'Lf

        Me.m_io.Write(StrTrama)
    End Sub

    'Proceso la lectura
    Private Sub m_io_DataReceived(ByVal sender As Object, ByVal e As System.IO.Ports.SerialDataReceivedEventArgs) Handles m_io.DataReceived
        Dim StrAux As String = "", str As String = ""
        Select Case e.EventType
            Case IO.Ports.SerialData.Chars
                Try
                    StrAux = Me.m_io.ReadLine
                Catch ex As Exception
                    GoTo ErrHandler
                End Try

                'Elimino caracteres raro
                StrAux = StrAux.Replace(Chr(2), "")
                StrAux = StrAux.Replace(Chr(3), "")
                StrAux = StrAux.Replace(Chr(10), "")
                StrAux = StrAux.Replace(Chr(13), "")

                If StrAux.Length <= 0 Then Exit Sub

                'Tipo de balanza sobre importe total
                If My.MyHardware.Balanza_tipo = 1 Then
                    If StrAux.Length <> 31 Then Exit Sub

                    If StrAux.Substring(0, 2) <> "@B" Then Exit Sub
                    If StrAux.Substring(16, 1) <> "U" Then Exit Sub
                    If StrAux.Substring(23, 1) <> "T" Then Exit Sub

                    'If StrAux.Substring(StrAux.Length - 8, 1) <> "T" Then Exit Sub
                    'StrAux = StrAux.Substring(StrAux.Length - 7)
                ElseIf My.MyHardware.Balanza_tipo = 2 Then
                    StrAux = StrAux.Replace("A", "")
                    StrAux = StrAux.Replace(Chr(32), "")
                    If Not IsNumeric(StrAux) Then Exit Sub
                End If

                If _strLast = StrAux Then Exit Sub
                _strLast = StrAux

                If My.MyHardware.Balanza_tipo = 0 Then
                    'Obtengo el peso de la bascula
                    str = StrAux.Substring(3, 5)
                    Me.LblPeso.Text = CInt(str.Substring(0, 2)) & "," & str.Substring(2)

                    'Obtengo el importe
                    str = StrAux.Substring(9, 6)
                    Me.LblImporte.Text = CInt(str.Substring(0, 4)) & "," & str.Substring(4)
                Else

                    'Obtengo el peso de la bascula
                    If My.MyHardware.Balanza_tipo = 2 Then
                        Me.LblPeso.Text = Format(CDbl(StrAux.Replace(".", ",")), "0.000")
                    Else
                        Me.LblPeso.Text = Format(CDbl(StrAux.Substring(2, 7).Replace(".", ",")), "0.000")
                    End If


                    'Si es de marcar precio en la balanza o no
                    If Me._swPrecioFijado Then

                        Me.LblImporte.Text = Format(Me._dblPrecio * CDbl(Me.LblPeso.Text), "0.00")

                    Else
                        'Obtengo el precio marcado
                        Me.LblPrecio.Text = Format(CDbl(StrAux.Substring(17, 6).Replace(".", ",")), "0.00")

                        'Obtengo el importe
                        Me.LblImporte.Text = Format(CDbl(StrAux.Substring(24).Replace(".", ",")), "0.00")
                    End If




                    ''Obtengo el importe
                    'str = StrAux
                    'Me.LblImporte.Text = Format(CDbl(str.Replace(".", ",")), "0.00")



                End If

            Case IO.Ports.SerialData.Eof
        End Select
ErrHandler:
    End Sub

    'Funcion para obtenerme el CheckSUM del precio
    Private Function CheckSUM(ByVal str As String) As String
        Dim i As Integer = 0, res = 0
        Dim n As Integer = 0

        For i = 0 To str.Length - 1
            res = Hex(("&H" & res) Xor ("&H" & Hex(Asc(str(i)))))
        Next
        Return Chr(CLng("&H" & res))

        'Referencia: http://www.clubdelphi.com/foros/showthread.php?t=63904
    End Function

#End Region

#Region "Eventos Principales"
    Private Sub frmConfigure_BalanzaCheck_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'Cargo los detalles del articulo
        Dim rst As ADODB.Recordset = My.m_db.GetRst("SELECT id,name,pvp_iva FROM db_articulos WHERE id=" & Me.IdRef)
        Me.LblName.Text = rst("name").Value
        Me.LblPrecio.Text = Format(rst("pvp_iva").Value, "0.00")
        Me._swPrecioFijado = (rst("pvp_iva").Value > 0)
        Me._dblPrecio = rst("pvp_iva").Value
        My.m_db.CloseRst(rst)

        'Establezco la conexión con la balanza y realizo una prelectura
        Me.OpenPort()
        Me.CheckPort()

        'Asigno manejadores
        Me.AddHandlers()

        'Para evitar que de error por acceso desde subprocesos
        Control.CheckForIllegalCrossThreadCalls = False

        'Habilito un temporizador para ir chequeando el puerto
        Me.Tmr.Enabled = True


        'Me.groupPeso.Visible = (My.MyHardware.Balanza_tipo = 0)
    End Sub
#End Region

#Region "Eventos Auxiliares"
    Private Sub frmConfigure_BalanzaCheck_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        On Error Resume Next
        If Not IsNothing(Me.m_io) Then
            Me.m_io.Close()
            Me.m_io = Nothing
        End If
    End Sub

    Private Sub BtRefresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtRefresh.Click
        Me.CheckPort()
    End Sub

    Private Sub Tmr_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Tmr.Tick
        Me.CheckPort()
    End Sub

    Private Sub BtOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtOK.Click
        Me.DialogResult = Windows.Forms.DialogResult.OK
    End Sub
#End Region

#Region "Manejadores"
    Private Sub AddHandlers()
        'AddHandler Me.Txt.KeyPress, AddressOf gDevelop.Lite.m_OverridesEvents.TxtValidaEuro_KeyPress
    End Sub
#End Region
    
    Private Sub LblName_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LblName.Click
        Me.Tmr.Enabled = False
        Me.LblPeso.Text = Format(CDbl(InputBox("Introduzca el pesaje manualmente:", "Pesaje Manual").Replace(".", ",")), "0.00#")
        'Me.DialogResult = Windows.Forms.DialogResult.OK

        Me.LblImporte.Text = Format(Me._dblPrecio * CDbl(Me.LblPeso.Text), "0.00")
    End Sub

    
    Private Sub btPrecio_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btPrecio.Click
        Me.Tmr.Enabled = False
        Me._dblPrecio = CDbl(InputBox("Introduzca el precio manualmente:", "Precio Manual").Replace(".", ","))
        Me.LblPrecio.Text = Format(Me._dblPrecio, "0.00")

        Me.LblImporte.Text = Format(Me._dblPrecio * CDbl(Me.LblPeso.Text), "0.00")

    End Sub
End Class
