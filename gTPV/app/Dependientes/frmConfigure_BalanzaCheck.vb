Public Class frmConfigure_BalanzaCheck
    Public strPort As String = ""



#Region "Puerto"
    Private WithEvents m_io As IO.Ports.SerialPort

    Private _strLast As String = ""

    Dim sRead As String = ""
    Private Sub m_io_DataReceived(ByVal sender As Object, ByVal e As System.IO.Ports.SerialDataReceivedEventArgs) Handles m_io.DataReceived
        'On Error GoTo ErrHandler
        Dim StrAux As String = ""
        Select Case e.EventType
            Case IO.Ports.SerialData.Chars
                Try
                    ''StrAux = Me.m_io.ReadLine
                    'If My.MyHardware.Balanza_tipo = 2 Then
                    '    'sRead &= Me.m_io.ReadExisting

                    '    'For i As Integer = 0 To 20
                    '    '    MsgBox(Asc(sRead.Chars(i)) & "-" & sRead.Chars(i))
                    '    'Next

                    '    StrAux = Me.m_io.ReadLine

                    '    Exit Sub
                    'Else
                    '    StrAux = Me.m_io.ReadLine
                    'End If

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


                'Depende del tipo de balanza compruebo
                If My.MyHardware.Balanza_tipo = 1 Then
                    'Trama de lectura: @B000.000+400.000+U000.00+T0000.00
                    '                   PESO     ??      Pvp/kb  Total
                    If StrAux.Length <> 31 Then Exit Sub

                    'Verificaciones varias de que la cadena leida esta correcta
                    If StrAux.Substring(0, 2) <> "@B" Then Exit Sub

                    If StrAux.Substring(16, 1) <> "U" Then Exit Sub

                    If StrAux.Substring(23, 1) <> "T" Then Exit Sub


                    'T0000.00

                    'If StrAux.Substring(StrAux.Length - 8, 1) <> "T" Then Exit Sub
                    'StrAux = StrAux.Substring(StrAux.Length - 8)
                ElseIf My.MyHardware.Balanza_tipo = 2 Then
                    StrAux = StrAux.Replace("A", "")
                    StrAux = StrAux.Replace(Chr(32), "")
                    If Not IsNumeric(StrAux) Then Exit Sub

                    'For i As Integer = 0 To 20
                    '    MsgBox(Asc(StrAux.Chars(i)) & "-" & StrAux.Chars(i))
                    'Next


                End If


                'Genero el evento de lectura del codigo
                If _strLast = StrAux Then Exit Sub
                _strLast = StrAux
                Me.Lst.Items.Add(StrAux)

                Me.Lst.SelectedIndex = Me.Lst.Items.Count - 1
            Case IO.Ports.SerialData.Eof
        End Select
ErrHandler:
        Me.sRead = ""
    End Sub
#End Region

    Private Sub frmConfigure_BalanzaCheck_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If Not IsNothing(Me.m_io) Then Me.m_io.Close()
    End Sub


    Private Sub frmConfigure_BalanzaCheck_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'Para evitar que de error por acceso desde subprocesos
        Control.CheckForIllegalCrossThreadCalls = False



        AddHandler Me.Txt.KeyPress, AddressOf gDevelop.Lite.m_OverridesEvents.TxtValidaEuro_KeyPress
    End Sub

    Private Sub BtOpen_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtOpen.Click
        Try
            'Preconfiguro y abro el puerto
            Me.m_io = New IO.Ports.SerialPort
            With Me.m_io
                .PortName = Me.strPort
                .BaudRate = 9600
                .Parity = IO.Ports.Parity.None
                .DataBits = 8
                .StopBits = 1

                .Handshake = IO.Ports.Handshake.None

                .DiscardNull = True
                .DtrEnable = True
                .ReadTimeout = 0
                .WriteBufferSize = 1024

                If My.MyHardware.Balanza_tipo = 2 Then
                    'MsgBox(Asc(.NewLine))
                    .NewLine = Chr(13)

                    '.ReceivedBytesThreshold = 1
                End If



                'If My.MyHardware.Balanza_tipo = 0 Then
                '    .Handshake = IO.Ports.Handshake.None

                '    .DiscardNull = True
                '    .DtrEnable = True
                '    .ReadTimeout = 0
                '    .WriteBufferSize = 1024

                'Else
                '    .Handshake = IO.Ports.Handshake.XOnXOff

                '    .DiscardNull = True
                '    .DtrEnable = False
                '    .RtsEnable = False

                '    '.ReadBufferSize = 1024

                '    '.ReadTimeout = 10

                '    '.BreakState = True
                '    .Encoding = System.Text.Encoding.UTF8
                'End If




                .Open()
            End With

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error conectando")
            Exit Sub
        End Try

        Me.BtOpen.Visible = False
        Me.BtWrite.Enabled = True
        Me.Panel.Visible = True

        If My.MyHardware.Balanza_tipo = 2 Then
            Me.tmr.Enabled = True
        End If

        My.AsignarFoco(Me.Txt)

        Me.GroupEntrega.Enabled = (My.MyHardware.Balanza_tipo = 0)
    End Sub

    Private Sub BtWrite_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtWrite.Click
        If Not IsNumeric(Me.Txt.Text) Then
            MsgBox("Debe de estrablecer un precio correcto")
            Exit Sub
        End If

        Dim StrTrama As String = ""
        Dim pvp As String = Format(CDbl(Me.Txt.Text), "000.00").Replace(",", "")


        '98PPPPPCCrLf
        StrTrama &= 9                 '9 - 0x38h
        StrTrama &= 8                 '8 - 0x39h
        StrTrama &= pvp                 'PPPPP - Precio (Sin coma)

        StrTrama &= CheckSUM(StrTrama)

        StrTrama &= Chr(13)                 'Cr
        StrTrama &= Chr(10)                 'Lf

        Me.m_io.Write(StrTrama)

        My.AsignarFoco(Me.Txt)
    End Sub

    Private Function CheckSUM(ByVal str As String) As String
        Dim i As Integer = 0, res = 0
        Dim n As Integer = 0

        For i = 0 To str.Length - 1
            res = Hex(("&H" & res) Xor ("&H" & Hex(Asc(str(i)))))
        Next
        Return Chr(CLng("&H" & res))

        'Referencia: http://www.clubdelphi.com/foros/showthread.php?t=63904
    End Function

    Private Sub Txt_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Txt.KeyPress
        'If e.KeyChar = "." Then
        '    e.Handled = True
        '    Me.Txt.Text &= ","
        '    Me.Txt.SelectionStart = Me.Txt.TextLength
        'End If

        If e.KeyChar = Chr(13) Then Me.BtWrite_Click(Me.BtWrite, New System.EventArgs)
    End Sub

    Private Sub tmr_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tmr.Tick
        'If IsNothing(Me.m_io) Then Exit Sub
        'Dim str As String = Me.m_io.ReadLine

        'Me.Lst.Items.Add(Me.m_io.ReadLine)
    End Sub
End Class
