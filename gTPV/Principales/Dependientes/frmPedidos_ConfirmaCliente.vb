Public Class frmPedidos_ConfirmaCliente

    Public Id_Ref As Integer = 0

    Private m_Data As gDevelop.Lite.m_dataform

#Region "Eventos Principales"
    Private Sub frmPedidos_ConfirmaCliente_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Obtengo los datos del cliente
        Dim rst As ADODB.Recordset = My.m_db.GetRst("SELECT * FROM db_clientes WHERE id=" & Me.Id_Ref)
        Me.LblName.Text = rst("name_fiscal").Value
        Me.txtTlf.Text = rst("tlf").Value
        Me.TxtDir.Text = rst("dir").Value & ""
        Me.txtDirN.Text = rst("dir_n").Value & ""
        Me.txtDirBloque.Text = rst("dir_bloque").Value & ""

        My.m_db.CloseRst(rst)



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
    Private Sub evtButtons_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtOk.Click, BtCancell.Click
        Select Case True
            Case sender Is Me.BtOk
                'If Me.TxtDir.TextLength <= 0 Then
                '    MsgBox("Debe de establecer un nombre de zona válido.", MsgBoxStyle.Critical)
                '    Exit Sub
                'End If
                'Me.m_Data.data_SaveField()
                Me.DialogResult = Windows.Forms.DialogResult.OK

            Case sender Is Me.BtCancell
                Me.Close()
        End Select
    End Sub

    Private Sub TxtName_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtDir.GotFocus
        Me.TxtDir.SelectionStart = Me.TxtDir.TextLength
    End Sub

    Private Sub TxtTlf_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtTlf.KeyPress
        If e.KeyChar = Chr(13) Then Me.evtButtons_Click(Me.BtOk, New System.EventArgs)
    End Sub

    Private Sub TxtName_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtDir.TextChanged
        Me.BtOk.Enabled = (Me.TxtDir.TextLength > 0)
    End Sub
#End Region

    Private Sub BtOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub Tab_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Tab.SelectedIndexChanged
        Select Case True
            Case Me.Tab.SelectedTab Is Me.TabPage_Location
                'Cargo la ubicación en google maps
                Dim str As String = "http://maps.google.es/maps?f=q&source=s_q&hl=es&geocode=&q=" & Me.TxtDir.Text.ToLower & ", " & My.m_opt.company_cp & "&z=16&amp;output=embed"

                'str = "<iframe width=""425"" height=""350"" frameborder=""0"" scrolling=""no"" marginheight=""0"" marginwidth=""0"" src=""https://maps.google.es/maps?q=" & Me.TxtDir.Text & ", " & My.m_opt.company_cp & ";hl=es&amp;ie=UTF8&amp;geocode=es&amp;hnear=" & My.m_opt.company_cp & "&amp;t=m&amp;hq=&amp;z=14&amp;output=embed""></iframe><br /><small></small>"
                Me.txtLoc.Text = str
                Me.WebBrowser.Url = New System.Uri(str)
        End Select
    End Sub

    Private Sub frmPedidos_ConfirmaCliente_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles MyBase.KeyPress
        If e.KeyChar = Chr(13) Then
            My.Computer.Keyboard.SendKeys("{TAB}")
        End If
    End Sub
End Class