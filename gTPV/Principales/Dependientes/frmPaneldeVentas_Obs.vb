Public Class frmPaneldeVentas_Obs
    Public IdRef As Integer

#Region "Eventos Principales"

    Private Sub frmPaneldeVentas_Obs_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        My.AsignarFoco(Me.txtObs)
    End Sub

    Private Sub frmConfigure_BalanzaCheck_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        '    'Cargo los detalles del articulo
        '    Dim rst As ADODB.Recordset = My.m_db.GetRst("SELECT * FROM db_articulos WHERE id=" & Me.IdRef)
        '    Me.Text = rst("name").Value

        '    If rst("vlcaso1_sw").Value Then
        '        Me.Rbt_1.Text = rst("vlcaso1_name").Value
        '        Me.Rbt_1.Visible = True
        '    End If

        '    If rst("vlcaso2_sw").Value Then
        '        Me.Rbt_2.Text = rst("vlcaso2_name").Value
        '        Me.Rbt_2.Visible = True
        '    End If

        '    If rst("vlcaso3_sw").Value Then
        '        Me.Rbt_3.Text = rst("vlcaso3_name").Value
        '        Me.Rbt_3.Visible = True
        '    End If

        '    Me.pnlObs.Visible = rst("swObs").Value

        '    My.m_db.CloseRst(rst)

    End Sub
#End Region

#Region "Eventos Auxiliares"
    Private Sub BtOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtOK.Click
        Me.DialogResult = Windows.Forms.DialogResult.OK
    End Sub
#End Region

#Region "Manejadores"
    Private Sub AddHandlers()
        'AddHandler Me.Txt.KeyPress, AddressOf gDevelop.Lite.m_OverridesEvents.TxtValidaEuro_KeyPress
    End Sub
#End Region


    Private Sub txtObs_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtObs.TextChanged
        Me.BtOK.Enabled = (Me.txtObs.TextLength > 0)
    End Sub
End Class
