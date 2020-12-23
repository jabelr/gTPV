Public Class frmPaneldeVentas_History
    Public Id_Ref As Integer = 0

#Region "Eventos Principales"
    Private Sub frmPaneldeVentas_History_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.LoadHistory()
    End Sub
#End Region

#Region "Eventos Auxiliares"

    Private Sub frmPaneldeVentas_History_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        'Me.m_Data.Dispose()
        'm_Data = Nothing
    End Sub
#End Region

#Region "Funciones"
    Private Sub LoadHistory()
        With Me.LstLines.Columns
            .Clear()
            .Add("Hora", 70, HorizontalAlignment.Left)
            .Add("Ud.", 40, HorizontalAlignment.Right)
            .Add("Detalle", 100, HorizontalAlignment.Left)
            .Add("Concepto", 220, HorizontalAlignment.Left)
        End With

        Dim i As Integer = 0

        Dim rst As ADODB.Recordset = My.m_db.GetRst("SELECT fh,concepto,ud,name FROM db_tickets_loglines WHERE id_ticket=" & Me.Id_Ref & " ORDER BY fh ASC,id ASC")
        While Not rst.EOF
            Me.LstLines.Items.Add(rst("fh").Value)
            Me.LstLines.Items(i).SubItems.Add(rst("ud").Value)
            Me.LstLines.Items(i).SubItems.Add(rst("concepto").Value)
            Me.LstLines.Items(i).SubItems.Add(rst("name").Value)

            i += 1
            rst.MoveNext()
        End While
        My.m_db.CloseRst(rst)
    End Sub
#End Region

End Class