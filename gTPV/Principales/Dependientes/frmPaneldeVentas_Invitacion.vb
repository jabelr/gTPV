Public Class frmPaneldeVentas_Invitacion
    Public strTipoInvitacion As String = ""

#Region "Eventos Principales"
    Private Sub frmPaneldeVentas_Invitacion_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Me.m_Data = New gDevelop.Lite.m_dataform(My.m_db)
        'Me.m_Data.DbTable = "db_zonas"
        'Me.m_Data.ConfigureDataForm(Me.Controls)
        'If Me.Id_Ref = 0 Then           'Caso del nuevo
        '    Me.m_Data.data_NewField()
        'Else
        '    Me.m_Data.data_EditField(Me.Id_Ref)
        'End If
    End Sub
#End Region

#Region "Eventos Auxiliares"
    Private Sub evtButtons_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtCancell.Click
        Select Case True
            Case sender Is Me.BtCancell
                Me.Close()
        End Select
    End Sub

#End Region


    Private Sub BtInvitacion(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtInvitacion_Rotura.Click, BtInvitacion_Normal.Click, BtInvitacion_Consumo.Click, BtInvitacion_Socio.Click
        Select Case True
            Case sender Is Me.BtInvitacion_Normal : Me.strTipoInvitacion = "INVITACION"
            Case sender Is Me.BtInvitacion_Consumo : Me.strTipoInvitacion = "CONSUMO"
            Case sender Is Me.BtInvitacion_Rotura : Me.strTipoInvitacion = "ROTURA"
            Case sender Is Me.BtInvitacion_Socio : Me.strTipoInvitacion = "SOCIO"
            Case Else : Exit Sub

        End Select

        Me.DialogResult = Windows.Forms.DialogResult.OK
    End Sub
End Class