Public Class frmSeleccionaDB
    Public Event ReloadData()           'Evento para que me recarge los valroes de empresa fuera del form

    Public idDB As Integer = 0


#Region "Eventos Principales"
    Private Sub frmSeleccionaDB_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ''Cargo las empresas
        'Dim rst As ADODB.Recordset = My.m_db_app.GetRst("Select id,name FROM app ORDER BY name ASC")
        'While Not rst.EOF
        '    Me.CbEmpresas.Items.Add(rst("name").Value & Space(100) & rst("id").Value)
        '    '    If rst("id").Value = My.m_app.GetValue("id_empresa") Then Me.CbEmpresas.SelectedIndex = Me.CbEmpresas.Items.Count - 1
        '    rst.MoveNext()
        'End While
        'My.m_db_app.CloseRst(rst)


        'Muestro algunos detalles de información
        'Me.Text &= " en " & My.MyApplication.CONST_APLICATION_NAME
    End Sub
#End Region

#Region "Eventos Auxiliares"
    Private Sub frmSeleccionaDB_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        Me.CbEmpresas.SelectAll()
        Me.CbEmpresas.Focus()
    End Sub

    Private Sub frmSeleccionaDB_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
        If e.KeyChar = Chr(27) Then Me.DialogResult = Windows.Forms.DialogResult.Cancel
    End Sub

    Private Sub BtCancell_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtCancell.Click
        Me.Close()
    End Sub

    Private Sub BtSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtOk.Click
        'Verifico que ha seleccionado empresa
        If Me.CbEmpresas.SelectedIndex = -1 Then
            MsgBox("Debe de especificar una empresa de inicio.", MsgBoxStyle.Critical)
            Me.CbEmpresas.SelectAll()
            Me.CbEmpresas.Focus()
            Exit Sub
        End If
        'If Me.CbUsers.SelectedIndex = -1 Then
        '    MsgBox("Debe de especificar de un usuario para poder iniciar sesión.", MsgBoxStyle.Critical)
        '    Me.CbUsers.SelectAll()
        '    Me.CbUsers.Focus()
        '    Exit Sub
        'End If

        ''Valido el usuario
        'Dim rst As ADODB.Recordset = My.Application.m_Db.GetRst("SELECT id,login,pass FROM usuarios WHERE id=" & Me.CbUsers.Text.Substring(100).Trim)
        'If rst.RecordCount = 0 Then
        '    MsgBox("Usuario no localizado.", MsgBoxStyle.Critical)
        '    Exit Sub
        'End If
        'If rst("pass").Value & "" <> Me.TxtPass.Text Then
        '    MsgBox("La contraseña especificada no es valida. Intentelo de nuevo.", MsgBoxStyle.Critical)
        '    AsignarFoco(Me.TxtPass)
        '    Exit Sub
        'End If
        'MyCfg.Id_user = rst("id").Value
        'MyCfg.strNameUser = rst("login").Value
        'My.Application.m_Db.CloseRst(rst)

        'My.Application.m_app.SetValue("id_empresa") = Me.CbEmpresas.Text.Substring(100).Trim
        'My.Application.m_app.SetValue("id_contable") = Me.CbPeriodo.Text.Substring(100).Trim

        Me.idDB = Me.CbEmpresas.Text.Substring(100).Trim

        RaiseEvent ReloadData()
        Me.DialogResult = Windows.Forms.DialogResult.OK
    End Sub


    Private Sub CbEmpresas_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CbEmpresas.SelectedIndexChanged
        'Me.CbPeriodo.Items.Clear()

        'Dim id As Integer = Me.CbEmpresas.Text.Substring(100).Trim()

        'Dim RstAux As ADODB.Recordset = My.Application.m_Db.GetRst("Select id,name,year_contable FROM contabilidad WHERE id_empresa=" & id & " ORDER BY year_contable desc")
        ''Compruebo si la empresa tiene periodos contables, sino le creo uno por defecto
        'If RstAux.RecordCount = 0 Then
        '    My.Application.m_Db.Execute("INSERT INTO contabilidad (name,id_empresa,year_contable,fact_contador,ticket_contador,factb_contador,factc_contador,iva_general,iva_medio,iva_basico,recargo_general,recargo_medio,recargo_basico,retencion) VALUES ('PERIODO DE PRUEBAS'," & id & ",'1900',1,1,1,1,18,8,4,4,1,0.5,4)")
        '    RstAux.Requery()
        'End If

        'While Not RstAux.EOF
        '    Me.CbPeriodo.Items.Add(RstAux("name").Value & " [" & RstAux("year_contable").Value & "]" & Space(100) & RstAux("id").Value)
        '    If RstAux("id").Value = My.Application.m_app.GetValue("id_contable") Then Me.CbPeriodo.SelectedIndex = Me.CbPeriodo.Items.Count - 1
        '    RstAux.MoveNext()
        'End While
        'My.Application.m_Db.CloseRst(RstAux)

        'Me.BtOk.Enabled = (Me.CbPeriodo.Items.Count)
        'If Me.CbPeriodo.SelectedIndex = -1 Then Me.CbPeriodo.SelectedIndex = 0
        ''If Not (Me.CbPeriodo.Items.Count) Then
        ''    MsgBox("No existe ningún periodo contable para la empresa." & vbCrLf & vbCrLf)
        ''    End
        ''End If
    End Sub

    'Eag East >> Por si no se la contraseña del usuario
    Private Sub PicImg_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles PicImg.MouseDown
        'If Me.CbUsers.SelectedIndex = -1 Then Exit Sub
        'If Control.ModifierKeys <> Keys.Control OrElse e.Button <> Windows.Forms.MouseButtons.Right OrElse e.Clicks < 2 Then Exit Sub
        'Dim rst As ADODB.Recordset = My.Application.m_Db.GetRst("SELECT id,login,pass FROM usuarios WHERE id=" & Me.CbUsers.Text.Substring(100).Trim)
        'Me.TxtPass.Text = rst("pass").Value & ""
        'My.Application.m_Db.CloseRst(rst)
    End Sub
#End Region

End Class