Public Class frmPedidos_Finaliza

    'El id del repartidor
    Public Id_Ref As Integer = 0

    'Private m_Data As gDevelop.Lite.m_dataform

#Region "Eventos Principales"
    Private Sub frmPedidos_Finaliza_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim i As Integer = 0
        'Obtengo los datos del repartido
        Dim rst As ADODB.Recordset = My.m_db.GetRst("SELECT * FROM db_usuarios WHERE id=" & Me.Id_Ref)
        Me.LblName.Text = rst("name").Value
        My.m_db.CloseRst(rst)


        'Configuro el listView de Pedidos Pendientes
        With Me.lstPedidos
            .Items.Clear()
            .Columns.Clear()
            .Columns.Add("Ref.", 90, HorizontalAlignment.Right)
            .Columns.Add("Cliente", 380, HorizontalAlignment.Left)
            '.Columns.Add("Teléfono", 110, HorizontalAlignment.Right)
            .Columns.Add("Importe", 100, HorizontalAlignment.Right)
        End With

        'Agrego los pedidos pendientes del repartidor
        rst = My.m_db.GetRst("SELECT db_pedidos.*,db_clientes.name_fiscal,db_clientes.id AS idCliente,db_tickets.id AS idTicket,db_tickets.id_user AS idUser, db_tickets.total FROM db_pedidos,db_clientes,db_tickets WHERE db_tickets.id=db_pedidos.id_ticket AND db_pedidos.estado='PENDIENTE' AND db_pedidos.id_cliente=db_clientes.id AND db_tickets.id_caja=-1 ORDER BY db_pedidos.estado DESC,db_pedidos.id DESC, name_fiscal ASC")
        i = 0
        While Not rst.EOF
            Me.lstPedidos.Items.Add(rst("id").Value)
            Me.lstPedidos.Items(i).SubItems.Add(rst("name_fiscal").Value)
            Me.lstPedidos.Items(i).SubItems.Add(Format(rst("total").Value, "0.00"))

            Me.lstPedidos.Items(i).Checked = True

            i += 1
            rst.MoveNext()
        End While
        My.m_db.CloseRst(rst)


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
                Dim sw As Boolean = False
                For i As Integer = 0 To Me.lstPedidos.Items.Count - 1
                    If Me.lstPedidos.Items(i).Checked Then
                        sw = True
                        Exit For
                    End If
                Next
                If Not sw Then
                    MsgBox("No se ha seleccionado ningún pedido para finalizar la entrega.", MsgBoxStyle.Critical)
                    Exit Sub
                End If

                If MsgBox("¿Esta seguro que de desea dar por finalizados los pedidos seleccionados?", MsgBoxStyle.OkCancel + MsgBoxStyle.Question) <> MsgBoxResult.Ok Then Exit Sub

                'Finalizo los pedidos
                For i As Integer = 0 To Me.lstPedidos.Items.Count - 1
                    If Me.lstPedidos.Items(i).Checked Then
                        My.m_db.Execute("UPDATE db_pedidos SET estado='FINALIZADO',fh_finaliza=#" & Now & "# WHERE id=" & Me.lstPedidos.Items(i).Text)
                        My.m_db.Execute("UPDATE db_tickets SET estado='FINALIZADO',fh_finaliza=#" & Now & "# WHERE id_pedido=" & Me.lstPedidos.Items(i).Text)

                    End If
                Next
                Me.DialogResult = Windows.Forms.DialogResult.OK

            Case sender Is Me.BtCancell
                Me.Close()
        End Select
    End Sub
#End Region


    
    Private Sub lnkPedidos_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles lnkPedidos_None.LinkClicked, lnkPedidos_ALL.LinkClicked
        Dim sw As Boolean = sender Is Me.lnkPedidos_ALL
        For i As Integer = 0 To Me.lstPedidos.Items.Count - 1
            Me.lstPedidos.Items(i).Checked = sw
        Next
    End Sub

    Private Sub lstPedidos_ItemChecked(ByVal sender As Object, ByVal e As System.Windows.Forms.ItemCheckedEventArgs) Handles lstPedidos.ItemChecked
        Dim dbl As Double = 0
        For i As Integer = 0 To Me.lstPedidos.Items.Count - 1
            If Me.lstPedidos.Items(i).Checked Then dbl += CDbl(Me.lstPedidos.Items(i).SubItems(2).Text)
        Next

        Me.LblTotal.Text = Format(dbl, "0.00")
    End Sub


End Class