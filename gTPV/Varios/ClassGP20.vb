Public Class ClassGP20
    Private WithEvents m_GP20 As IO.Ports.SerialPort
    Private _comtPort_GP20 As String
    
    'Evento para cada vez que leo un codigo
    Public Event CodeRead_GP20(ByVal code As String)

    Public Sub New()
    End Sub

    Public Sub Open(ByVal comPort_GP20 As String)
        On Error GoTo ErrHandler

        Me._comtPort_GP20 = comPort_GP20

        'Preconfiguro y abro el puerto
        m_GP20 = New IO.Ports.SerialPort
        m_GP20.PortName = Me._comtPort_GP20
        'm_GP20.DiscardNull = True
        'm_GP20.DtrEnable = True
        m_GP20.ReadTimeout = 0


        'm_GP20

        m_GP20.Open()

        'Asigno el manejador de evento de lectura
        AddHandler m_GP20.DataReceived, AddressOf Read_LectorGP20
        Return
ErrHandler:
        MsgBox(Err.Description, MsgBoxStyle.Critical, "Error abriendo dispositivo")
    End Sub

    Public Sub Dispose()
        If Not isnothing(m_GP20) Then
            If m_GP20.IsOpen Then
                RemoveHandler m_GP20.DataReceived, AddressOf Read_LectorGP20
                m_GP20.DiscardInBuffer()
                m_GP20.Close()
            End If
            m_GP20.Dispose()
        End If
    End Sub

    Private Sub Read_LectorGP20(ByVal sender As Object, ByVal e As System.IO.Ports.SerialDataReceivedEventArgs)
        'On Error GoTo ErrHandler

        'dim t as no
        'my.Computer.Name
        System.Threading.Thread.Sleep(500)

        Dim StrAux As String = ""
        Select Case e.EventType
            Case IO.Ports.SerialData.Chars
                Try
                    'StrAux = m_GP20.ReadLine
                    StrAux = m_GP20.ReadExisting

                Catch ex As Exception
                    GoTo ErrHandler
                End Try

                'Elimino caracteres raro
                StrAux = StrAux.Replace(Chr(2), "")
                StrAux = StrAux.Replace(Chr(3), "")
                StrAux = StrAux.Replace(Chr(10), "")
                StrAux = StrAux.Replace(Chr(13), "")

                If StrAux.Length <= 0 Then Exit Sub

                'Genero el evento de lectura del codigo
                RaiseEvent CodeRead_GP20(StrAux)
            Case IO.Ports.SerialData.Eof
        End Select
ErrHandler:
    End Sub
End Class
