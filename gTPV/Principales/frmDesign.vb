Public Class frmDesign
    Private _arrImgs() As PictureBox = Nothing
    Private _arrNames() As Label = Nothing

    Private _arrCount(0, 1) As Integer                    'Para el contador de cada tipo de objeto puesto


    Private _swChanges As Boolean = False             'Para controlar cuando hay cambios
    Private Property swChanges() As Boolean
        Get
            Return Me._swChanges
        End Get
        Set(ByVal value As Boolean)
            Me._swChanges = value
            Me.BtCancell.Enabled = value
            Me.BtOk.Enabled = value
        End Set
    End Property


#Region "Variables Constantes"
    '# Contantes comunes sobre el formulario
    ' Nº de dias a lo ancho y a lo alto a mostrar
    Dim _x As Integer = 7
    Dim _y As Integer = 6

    'Localizacion de inicio para el primer boton
    Dim _left As Integer = 1
    Dim _top As Integer = 1

#End Region

#Region "Eventos Principales"
    Private Sub frmDesign_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.Size = Screen.PrimaryScreen.WorkingArea.Size

        'Inicializo entorno
        Me.PnlBody.Left = CType(Me.Owner, frmMain).PnlBody.Left
        Me.PnlBody.Top = CType(Me.Owner, frmMain).PnlBody.Top + (IIf(My.m_opt.swNoteBook, Me.SplitContainer.Panel1.Height, 0))
        Me.PnlBody.Visible = True

        Me.InicializateDragDrop(Me.PnlData.Controls)
        'ReDim _arrImgs(-1)
        'ReDim _arrNames(-1)

        ' Cargo las categorias de filtro
        Dim rst As ADODB.Recordset = My.m_db.GetRst("SELECT * FROM app_design_categorias ORDER BY name ASC")
        Dim i As Integer = 0

        ReDim Me._arrCount(rst.RecordCount - 1, 1)
        Me.CbImg_Cat.Items.Clear()

        Me.CbImg_Cat.Items.Add("TOD@S" & Space(100) & "0")
        While Not rst.EOF
            Me.CbImg_Cat.Items.Add(rst("name").Value & Space(100) & rst("id").Value)
            Me._arrCount(i, 0) = rst("id").Value
            Me._arrCount(i, 1) = 0

            i += 1
            rst.MoveNext()
        End While
        Me.CbImg_Cat.SelectedIndex = 0
        My.m_db.CloseRst(rst)

        ' Cargo las zonas disponibles
        rst = My.m_db.GetRst("SELECT * FROM db_zonas ORDER BY id ASC")
        Me.CbZonas.Items.Clear()
        While Not rst.EOF
            Me.CbZonas.Items.Add(rst("name").Value & Space(100) & rst("id").Value)
            i += 1
            rst.MoveNext()
        End While
        Me.CbZonas.SelectedIndex = 0
        Me.CbZonas.Enabled = (Me.CbZonas.Items.Count > 1)
        My.m_db.CloseRst(rst)

        ''Cargo las mesas guardadas
        'rst = My.m_db.GetRst("SELECT db_design.*,app_design.img FROM db_design,app_design WHERE app_design.id=db_design.id_img ORDER BY db_design.id")
        'While Not rst.EOF
        '    i = Me.AddItem(rst("id_img").Value, My.m_db.data_GetImgRow(rst("img")), rst("pos_x").Value, rst("pos_y").Value)
        '    Me._arrImgs(i).Name = rst("id").Value
        '    Me._arrNames(i).Text = rst("name").Value
        '    rst.MoveNext()
        'End While
        'My.m_db.CloseRst(rst)

        Me.PnlCategorias.Location = New Point(0, 2)
        Me.PnlModeLineON.Location = New Point(0, 2)
    End Sub
#End Region

#Region "Manejadores"
    'Manejador Principal (Shell)
    Private Sub ShellApp(ByVal command As String)
        Dim cmd As String = command.ToUpper

        Select Case cmd
            Case "OK"
                Dim sql As String = ""
                Dim i As Integer = 0
                For i = 0 To Me._arrImgs.Length - 1
                    If Not IsNothing(Me._arrImgs(i).Image) Then
                        If Val(Me._arrImgs(i).Name) = 0 Then                  'Es Nuevo
                            sql = "INSERT INTO db_design (id_zona,id_img,pos_x,pos_y,name,fh_alta) "
                            sql &= "VALUES (" & Me.CbZonas.Text.Substring(100).Trim & "," & Me._arrImgs(i).Tag & "," & Me._arrImgs(i).Left & "," & Me._arrImgs(i).Top & ",'" & Me._arrNames(i).Text & "',#" & Now.ToString("MM-dd-yyyy") & "#)"
                            My.m_db.Execute(sql)
                        Else                                              'Modifico un registro actual
                            sql = "UPDATE db_design SET pos_x=" & Me._arrImgs(i).Left & ",pos_y=" & Me._arrImgs(i).Top
                            sql &= ", name='" & Me._arrNames(Me._arrImgs(i).Text).Text & "'"
                            sql &= " WHERE id=" & Me._arrImgs(i).Name
                            My.m_db.Execute(sql)
                        End If
                    ElseIf Val(Me._arrImgs(i).Name) > 0 Then                    ' Si Tengo que borrar de la db
                        sql = "DELETE FROM db_design WHERE id=" & Me._arrImgs(i).Name
                        My.m_db.Execute(sql)
                    End If
                Next
                Me.swChanges = False

            Case "CANCEL"
                If MsgBox("¿Esta seguro que desea descartar los cambios que haya realizado y volver a recargar los valores iniciales?", MsgBoxStyle.YesNo + MsgBoxStyle.Question, My.APP_NAME) <> MsgBoxResult.Yes Then Exit Select
                Me.LoadMesas(True)


            Case "MINIMIZE"
                frm_AppIsMinimized.Show()

                Me.Owner.WindowState = FormWindowState.Minimized
                Me.WindowState = FormWindowState.Minimized

            Case "CLOSE"
                Me.Close()
            Case Else
                My.m_msg.MessageError(Me, "Comando de acción de " & cmd & "no controlada.")
        End Select
    End Sub
#End Region

#Region "Eventos Auxiliares"
    Private Sub Buttons_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtMin.Click, BtClose.Click, BtOk.Click, BtCancell.Click
        'Si no tiene establecido el tag mando un error
        If IsNothing(CType(sender, Button).Tag) OrElse CType(sender, Button).Tag.ToString.Length = 0 Then
            My.m_msg.MessageError(sender, "Tag de control de elemento no referenciado")
            Exit Sub
        End If

        ShellApp(CType(sender, Button).Tag.ToString)
    End Sub

    Private Sub CbImg_Cat_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CbImg_Cat.SelectedIndexChanged
        Me._galeria_pag = 0
        Me.Load_GaleriaImg()
    End Sub

    Private Sub ChkModeLine_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChkModeLine.CheckedChanged
        Me.ChkModeLine.ImageIndex = IIf(Me.ChkModeLine.Checked, 1, 0)
        Me.PnlCategorias.Visible = Not Me.ChkModeLine.Checked
        Me.PnlModeLineON.Visible = Me.ChkModeLine.Checked
        For Each c As Control In Me.PicPlano.Controls
            c.Enabled = Not Me.ChkModeLine.Checked
        Next

    End Sub

    Private Sub CbZonas_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CbZonas.SelectedIndexChanged
        Me.LoadMesas()
    End Sub
#End Region

#Region "Galeria de Imagenes de Diseño"
    'Registros para la paginación
    Private _galeria_tot As Integer = 0
    Private _galeria_pag As Integer = 0

    Private Sub Load_GaleriaImg()
        Me.BtCat_Previous.Enabled = (Me._galeria_pag > 0)
        Me.BtCat_Next.Enabled = False

        ' Nº de productos a lo ancho a mostrar
        Dim _x As Integer = 6

        'Localizacion de inicio para el primer boton
        Dim _left As Integer = 72
        Dim _top As Integer = 3

        'Variables Auxiliares
        Dim i As Integer = 0, n As Integer = 0
        Dim rst As ADODB.Recordset
        Dim sql As String

        '### Paginacion
        sql = "SELECT count(id) as tot FROM app_design"
        If Me.CbImg_Cat.SelectedIndex > 0 Then sql &= " WHERE id_categoria=" & Me.CbImg_Cat.Text.Substring(100).Trim
        rst = My.m_db.GetRst(sql)
        Me._galeria_tot = rst("tot").Value + 1            '(La categoria extra es de funciones especiales: Articulos mas usados)
        My.m_db.CloseRst(rst)

        '### Limpio anteriores controltes
        For i = Me.PnlCategorias.Controls.Count - 1 To 2 Step -1
            Me.PnlCategorias.Controls(i).Dispose()
        Next


        '### Obtengo las imagenes de la categoria seleccionada
        'sql = "SELECT db_categorias.*,app_imgs.img FROM db_categorias LEFT JOIN app_imgs"
        'sql &= " ON db_categorias.id=app_imgs.id"
        'sql &= " ORDER BY db_categorias.n_veces ASC,name ASC"

        sql = "SELECT * FROM app_design"
        If Me.CbImg_Cat.SelectedIndex > 0 Then sql &= " WHERE id_categoria=" & Me.CbImg_Cat.Text.Substring(100).Trim
        sql &= " ORDER BY name ASC"
        rst = My.m_db.GetRst(sql)


        '### Agrego los botones de las imagenes
        i = 0
        n = 1 'Total de categorias especiales

        While Not rst.EOF
            If (n >= (Me._galeria_pag * _x)) Then
                ' Creo y configuro el nuevo boton
                Dim pic As PictureBox
                pic = New PictureBox
                With pic
                    .BackColor = Color.Black
                    '.BorderStyle = BorderStyle.Fixed3D
                    .Cursor = Cursors.Hand
                    .SizeMode = PictureBoxSizeMode.StretchImage
                    .Margin = New Padding(0)
                    .Name = 0
                    .Size = New Size(93, 90)
                    .Size = New Size(70, 67)
                    .TabIndex = n
                    .Location = New Point(_left + (pic.Width * i) + (4 * i), _top)
                    .Tag = rst("id").Value             'El id de la imagen de la galeria de mesas
                    .Image = My.m_db.data_GetImgRow(rst("img"))

                    AddHandler .MouseDown, AddressOf PicImgObject_MouseDown
                    AddHandler .DragOver, AddressOf Drag_Over
                    AddHandler .GiveFeedback, AddressOf SetCursorFeedback
                End With

                Me.ToolTip.SetToolTip(pic, "Nombre: " & rst("name").Value & vbCrLf & vbCrLf & "Pinchar y Mantener pulsado para Arrastrar y Colocar en el Plano")

                Me.PnlCategorias.Controls.Add(pic)
                pic.Visible = True

                i += 1
                If i = _x Then
                    i = 0
                    rst.MoveNext()
                    Me.BtCat_Next.Enabled = Not rst.EOF
                    Exit While
                End If
            End If
            n += 1

            rst.MoveNext()
        End While
        My.m_db.CloseRst(rst)
    End Sub

    Private Sub BtCat_Move_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtCat_Previous.Click, BtCat_Next.Click
        Select Case True
            Case sender Is Me.BtCat_Previous
                Me._galeria_pag -= 1

            Case sender Is Me.BtCat_Next
                Me._galeria_pag += 1
        End Select

        Me.Load_GaleriaImg()
    End Sub
#End Region

#Region "Drag&Drop"
    Private Const _thumWidth As Integer = 70
    Private Const _thumHeight As Integer = 70

    Private _IdTempImg As Integer = 0          'app_design.id = el id de la imagen de la galeria
    Private _PosPicMove As Integer = -1           'db_design.id = id del registro

#Region "Funciones"
    Private Sub InicializateDragDrop(ByVal CntContainer As Control.ControlCollection)
        For Each c As Control In CntContainer
            If c.Controls.Count Then InicializateDragDrop(c.Controls) 'Si es un contenedor de controles

            ' We must set all controls to allow drop if we want custom cursors
            ' Othereise default cursors are used for the controls that do not have
            ' allowdrop set to true
            ' This means we have to disallow drops in the code for DragOver
            c.AllowDrop = True

            'allow the cursor to be set for all controls on the form as we drag over.
            AddHandler c.DragOver, AddressOf Drag_Over
            AddHandler Me.DragOver, AddressOf Drag_Over

            'set the custom cursor when dragging:
            AddHandler c.GiveFeedback, AddressOf SetCursorFeedback
            AddHandler Me.GiveFeedback, AddressOf SetCursorFeedback
        Next
    End Sub

    Private Sub DrawPictureCursor(ByVal sender As Object)
        ' a system.drawing.image can create a thumbnail, which is nice...
        Dim cursorImage As System.Drawing.Image

        'can set the size of the thumbnail... use the trackbar to adjust imzise
        'note that there is much less lag starting the drag when it is a small thumbnail
        'Dim imsize As Double = uxCursorSize.Value / uxCursorSize.Maximum
        'Dim cursorWidth, cursorheight As Integer
        'cursorWidth = CInt(uxPictureSource.Size.Width * imsize)
        'cursorheight = CInt(uxPictureSource.Size.Height * imsize)
        Dim mycallback As System.Drawing.Image.GetThumbnailImageAbort 'not used, but required
        cursorImage = sender.Image.GetThumbnailImage(_thumWidth, _thumHeight, mycallback, IntPtr.Zero)

        Dim cursorImageCopy As Bitmap = DirectCast(cursorImage.Clone, Bitmap)
        MakeMoveCursor(cursorImageCopy)
        cursorImageCopy = DirectCast(cursorImage.Clone, Bitmap)
        MakeNoDropCursor(cursorImageCopy)
        cursorImageCopy = DirectCast(cursorImage.Clone, Bitmap)
        MakeCopyCursor(cursorImageCopy)
        cursorImage.Dispose()
        cursorImageCopy.Dispose()
    End Sub

    Private Sub MakeMoveCursor(ByVal baseImage As Bitmap)

        'the small picture thumbnails have small resolutions, making the cursor appear
        'small, so reset the resolution (to standard monitor resolution)
        baseImage.SetResolution(96.0F, 96.0F)

        'The move cursor:
        'draw an arrow pointer in the middle of the image
        Dim midPointX As Integer = baseImage.Width / 2
        Dim midPointY As Integer = baseImage.Height / 2

        Dim tempCursor As Bitmap
        tempCursor = GetCursorImage(Cursors.Arrow)

        Dim moveCursorGraphics As Graphics = Graphics.FromImage(baseImage)
        moveCursorGraphics.DrawImageUnscaled(tempCursor, midPointX, midPointY)
        moveCursor = New Cursor(baseImage.GetHicon)
        moveCursorGraphics.Dispose()
        baseImage.Dispose()
    End Sub

    Private Sub MakeNoDropCursor(ByVal baseImage As Bitmap)
        'the small picture thumbnails have small resolutions, making the cursor appear
        'small, so reset the resolution (to standard monitor resolution)
        baseImage.SetResolution(96.0F, 96.0F)

        'The move cursor:
        'draw an arrow pointer in the middle of the image
        Dim midPointX As Integer = baseImage.Width / 2
        Dim midPointY As Integer = baseImage.Height / 2

        Dim tempCursor As Bitmap
        tempCursor = GetCursorImage(Cursors.No)

        Dim nodropCursorGraphics As Graphics = Graphics.FromImage(baseImage)
        nodropCursorGraphics.DrawImageUnscaled(tempCursor, midPointX, midPointY)
        nodropCursor = New Cursor(baseImage.GetHicon)
        nodropCursorGraphics.Dispose()
        baseImage.Dispose()

    End Sub

    Private Sub MakeCopyCursor(ByVal baseImage As Bitmap)

        'the small picture thumbnails have small resolutions, making the cursor appear
        'small, so reset the resolution (to standard monitor resolution)
        baseImage.SetResolution(96.0F, 96.0F)


        'copy cursor
        'There is no cursor.copy, so start like the move cursor, and then draw on a +

        'draw an arrow pointer in the middle of the image
        Dim midPointX As Integer = baseImage.Width / 2
        Dim midPointY As Integer = baseImage.Height / 2

        Dim tempCursor As Bitmap
        tempCursor = GetCursorImage(Cursors.Arrow)

        Dim copyCursorGraphics As Graphics = Graphics.FromImage(baseImage)
        copyCursorGraphics.DrawImageUnscaled(tempCursor, midPointX, midPointY)

        'draw a + into a seperate bitmap
        Dim plusImage As New Bitmap(9, 9)
        Dim plusGraphics As Graphics = Graphics.FromImage(plusImage)
        Dim blackPen As New Pen(System.Drawing.Color.Black, -1)
        Dim rec As New Rectangle(0, 0, 8, 8)
        plusGraphics.Clear(Color.White)
        plusGraphics.DrawRectangle(blackPen, rec)
        plusGraphics.DrawLine(blackPen, 4.0F, 2.0F, 4.0F, 6.0F)
        plusGraphics.DrawLine(blackPen, 2.0F, 4.0F, 6.0F, 4.0F)
        'draw the plus onto the copycursor image to the lower right of the cursor
        copyCursorGraphics.DrawImageUnscaled(plusImage, _
        New Point(midPointX + tempCursor.Width + 1, midPointY + tempCursor.Height + 1))
        copyCursor = New Cursor(baseImage.GetHicon)
        'dispose of any remaining gdi objects
        blackPen.Dispose()
        plusGraphics.Dispose()
        plusImage.Dispose()
        copyCursorGraphics.Dispose()
        baseImage.Dispose()

    End Sub

    Private Function GetCursorImage(ByVal baseCursor As Cursor) As Bitmap

        'If you just draw the cursor on the bitmap with
        'cursor.arrow.draw - then it gets misaligned, so to get more control
        'We'll trim the cursor down.

        ' draw a the system arrow cursor to a bitmap
        ' trim off the blank space around it
        ' return the cursor with the "point" at the top left
        Dim cursorSize As New Size
        cursorSize = baseCursor.Size
        Dim cursorImage As New Bitmap(cursorSize.Width, cursorSize.Height)
        Dim cursorGraphics As Graphics = Graphics.FromImage(cursorImage)
        Dim rec As New Rectangle(0, 0, cursorSize.Width, cursorSize.Height)
        baseCursor.Draw(cursorGraphics, rec)

        'get the dimensions of the actual icon
        Dim cursorBackColor As Color = cursorImage.GetPixel(0, 0)
        Dim cursorTop As Integer = cursorImage.Height
        Dim cursorRight As Integer = 0
        Dim cursorLeft As Integer = cursorImage.Width
        Dim cursorBottom As Integer = 0

        For y As Integer = 0 To cursorSize.Height - 1
            For x As Integer = 0 To cursorSize.Width - 1
                If Not cursorImage.GetPixel(x, y).Equals(cursorBackColor) Then
                    If x < cursorLeft Then cursorLeft = x
                    If x > cursorRight Then cursorRight = x
                    If y < cursorTop Then cursorTop = y
                    If y > cursorBottom Then cursorBottom = y
                End If
            Next
        Next

        'define a rectangle that will contain the icon
        Dim cursorWidth As Integer = cursorRight - cursorLeft + 1
        Dim cursorHeight As Integer = cursorBottom - cursorTop + 1
        Dim destinationRec As Rectangle
        destinationRec = New Rectangle(0, 0, cursorWidth, cursorHeight)
        Dim cursorOut As New Bitmap(cursorWidth, cursorHeight)
        Dim cursorOutGraphics As Graphics = Graphics.FromImage(cursorOut)
        cursorOutGraphics.DrawImage(cursorImage, destinationRec, cursorLeft, cursorTop, _
        cursorWidth, cursorHeight, System.Drawing.GraphicsUnit.Pixel)
        cursorOutGraphics.Dispose()
        cursorGraphics.Dispose()
        cursorImage.Dispose()
        Return cursorOut
    End Function
#End Region

#Region "Eventos Delegados"
    ' Visto en http://www.Planet-Source-Code.com/vb/scripts/ShowCode.asp?txtCodeId=3855&lngWId=10

    Private dragInitiator As String
    Dim moveCursor, nodropCursor, copyCursor As Cursor

    Private Sub PicImgObject_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs)
        CType(sender, PictureBox).BorderStyle = BorderStyle.Fixed3D
    End Sub

    Private Sub PicImgObject_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs)
        CType(sender, PictureBox).BorderStyle = BorderStyle.None
    End Sub

    Private Sub Drag_Over(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs)

        'Here we set the cursor effect to be used as the mouse moves over a control.

        'If the control is not a label or picturebox then set effect to nodrop
        If Not ((sender.GetType Is GetType(Label)) _
        OrElse (sender.GetType Is GetType(PictureBox))) Then
            e.Effect = DragDropEffects.None
            Return
        End If

        'If there is no text or image data in e.data then set effect to nodrop
        If e.Data.GetDataPresent(DataFormats.Text) = False _
        AndAlso e.Data.GetDataPresent(DataFormats.Bitmap) = False Then
            e.Effect = DragDropEffects.None
            Return
        End If

        'If there is text data but the control is a picture box then set effect to nodrop
        If e.Data.GetDataPresent(DataFormats.Text) AndAlso sender.GetType Is GetType(PictureBox) Then
            e.Effect = DragDropEffects.None
            Return
        End If

        'If there is image data but the control is a label then set effect to nodrop
        If e.Data.GetDataPresent(DataFormats.Bitmap) AndAlso sender.GetType Is GetType(Label) Then
            e.Effect = DragDropEffects.None
            Return
        End If

        If sender.name = dragInitiator Then
            'trying to drop onto self
            'this would work, but the control would then clear itself as it recieved the signal that
            'the move was ok...
            e.Effect = DragDropEffects.None
            Return
        End If
        'Check what keys are pressed. And change the effect accordingly

        If ((e.KeyState And 4) = 4 And _
        (e.AllowedEffect And DragDropEffects.Move) = DragDropEffects.Move) Then

            ' SHIFT KeyState for move.
            e.Effect = DragDropEffects.Move

        ElseIf ((e.KeyState And 8) = 8 And _
            (e.AllowedEffect And DragDropEffects.Copy) = DragDropEffects.Copy) Then

            ' CTL KeyState for copy.
            e.Effect = DragDropEffects.Copy

        ElseIf ((e.AllowedEffect And DragDropEffects.Move) = DragDropEffects.Move) Then

            ' By default, the drop action should be move, if allowed.
            e.Effect = DragDropEffects.Move

        Else
            e.Effect = DragDropEffects.None
        End If

    End Sub

    Private Sub SetCursorFeedback(ByVal sender As Object, ByVal e As System.Windows.Forms.GiveFeedbackEventArgs)
        'set the geedback cursor for the effect set in dragover
        e.UseDefaultCursors = False
        Select Case e.Effect
            Case DragDropEffects.Move
                Cursor.Current = moveCursor
            Case DragDropEffects.None
                Cursor.Current = nodropCursor
            Case DragDropEffects.Copy
                Cursor.Current = copyCursor
        End Select
    End Sub

    Private Sub PicObject_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs)
        CType(sender, PictureBox).BorderStyle = BorderStyle.Fixed3D
    End Sub

    Private Sub PicObject_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs)
        CType(sender, PictureBox).BorderStyle = BorderStyle.None
    End Sub
#End Region

    Private Sub PicImgObject_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs)
        If sender.Image Is Nothing Then Exit Sub ' nothing to drag
        DrawPictureCursor(sender)
        Dim result As DragDropEffects
        dragInitiator = sender.name 'keep track of the source of the drag
        'so that we can disallow drops onto self

        'If Val(CType(sender, PictureBox).Tag.ToString) > 0 Then
        '    MsgBox("arrastro uno existente")
        'End If
        Me._IdTempImg = CType(sender, PictureBox).Tag
        result = sender.DoDragDrop(sender.Image, DragDropEffects.All)
        'If result = DragDropEffects.Move Then
        '    sender.image = Nothing ' if you dropped on self, self would be cleared immediately afterwards.
        'End If
        sender.allowdrop = False
    End Sub

    Private Sub PicObjectMove_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs)
        If sender.Image Is Nothing Then Exit Sub ' nothing to drag

        Me._PosPicMove = CType(sender, PictureBox).Text
        'Me._IdTempImg = CType(sender, PictureBox).Tag

        If e.Button = Windows.Forms.MouseButtons.Right Then
            CType(sender, PictureBox).BorderStyle = BorderStyle.None

            With frmDesign_Object
                .Id_Ref = Me._PosPicMove
                .TxtName.Text = Me._arrNames(Me._PosPicMove).Text
                .ShowDialog(Me)
                Select Case .DialogResult
                    Case Windows.Forms.DialogResult.Ignore
                        'Oculto y Pongo en cola de borrado
                        Me._arrImgs(Me._PosPicMove).Image = Nothing
                        Me._arrImgs(Me._PosPicMove).Visible = False
                        Me._arrNames(Me._PosPicMove).Visible = False
                        Me.swChanges = True

                    Case Windows.Forms.DialogResult.Yes
                        Me._arrNames(Me._PosPicMove).Text = .TxtName.Text
                        Me.swChanges = True

                End Select

                .Dispose()
            End With
            Exit Sub
        End If

        DrawPictureCursor(sender)
        Dim result As DragDropEffects
        dragInitiator = sender.name 'keep track of the source of the drag


        CType(sender, PictureBox).BorderStyle = BorderStyle.Fixed3D
        Me._arrNames(Me._PosPicMove).Visible = False

        result = sender.DoDragDrop(sender.Image, DragDropEffects.Move)
        'If result = DragDropEffects.Move Then
        '    sender.image = Nothing ' if you dropped on self, self would be cleared immediately afterwards.
        'End If
        sender.allowdrop = False
    End Sub

    Private Sub PicPlano_DragDrop(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles PicPlano.DragDrop
        'sender.Image = CType((e.Data.GetData(DataFormats.Bitmap)), Bitmap)

        If e.AllowedEffect = DragDropEffects.Move Then               ' Muevo la imagen y la etiqueta de posicion
            Me._arrImgs(Me._PosPicMove).BorderStyle = BorderStyle.None
            Me._arrImgs(Me._PosPicMove).Location = New Point( _
                                                                    Me.PicPlano.PointToClient(Cursor.Position).X - (Me._arrImgs(Me._PosPicMove).Image.Width / 2), _
                                                                    Me.PicPlano.PointToClient(Cursor.Position).Y - (Me._arrImgs(Me._PosPicMove).Image.Height / 2) _
                                                                )
            Me._arrNames(Me._PosPicMove).Location = New Point(Me._arrImgs(Me._PosPicMove).Left - (Me._arrImgs(Me._PosPicMove).Width / 2), Me._arrImgs(Me._PosPicMove).Top + Me._arrImgs(Me._PosPicMove).Height + 1)
            Me._arrNames(Me._PosPicMove).Visible = True

            Me.swChanges = True
            Me._PosPicMove = -1
            Exit Sub
        End If

        Dim img As Bitmap = CType((e.Data.GetData(DataFormats.Bitmap)), Bitmap)

        Me.AddItem( _
                                Me._IdTempImg, _
                                img, _
                                Me.PicPlano.PointToClient(Cursor.Position).X - (img.Width / 2), _
                                Me.PicPlano.PointToClient(Cursor.Position).Y - (img.Height / 2))

        Me.swChanges = True
        Exit Sub
        'Dim pos As Integer = Me._arrImgs.Length
        'ReDim Preserve Me._arrImgs(pos)
        'ReDim Preserve Me._arrNames(pos)

        ''Configuro la imagen
        'Me._arrImgs(pos) = New PictureBox
        'With Me._arrImgs(pos)
        '    .AllowDrop = False
        '    .BorderStyle = BorderStyle.Fixed3D
        '    .Cursor = Cursors.Hand
        '    .Image = img
        '    .Location = New Point( _
        '                                        Me.PicPlano.PointToClient(Cursor.Position).X - (img.Width / 2), _
        '                                        Me.PicPlano.PointToClient(Cursor.Position).Y - (img.Height / 2) _
        '                                    )
        '    .SizeMode = PictureBoxSizeMode.AutoSize
        '    .Tag = 0
        '    .Name = pos
        '    .Text = p
        '    .Visible = True
        'End With
        'Me.PicPlano.Controls.Add(Me._arrImgs(pos))

        ''Obtengo datos para la etiqueta
        'Dim rst As ADODB.Recordset = My.m_db.GetRst("SELECT app_design_categorias.id,title FROM app_design,app_design_categorias WHERE app_design_categorias.id=app_design.id_categoria  AND app_design.id=" & Me._IdTempImg)
        ''Aumento el contado de nº de tipo puestas en +1
        'Dim i As Integer = 0
        'For i = 0 To Me._arrCount.GetLength(0) - 1
        '    If rst("id").Value = Me._arrCount(i, 0) Then
        '        Me._arrCount(i, 1) += 1
        '        Exit For
        '    End If
        'Next

        'Me._arrNames(pos) = New Label
        'With Me._arrNames(pos)
        '    .AutoSize = False
        '    .Font = New Font("Verdana", 9, FontStyle.Bold)
        '    .ForeColor = Color.GreenYellow
        '    .Location = New Point(Me._arrImgs(pos).Left - (Me._arrImgs(pos).Width / 2), Me._arrImgs(pos).Top + Me._arrImgs(pos).Height + 1)
        '    .Size = New Size(Me._arrImgs(pos).Width * 2, 16)
        '    .Text = rst("title").Value & " #" & Me._arrCount(i, 1)
        '    .TextAlign = ContentAlignment.MiddleCenter
        '    .BackColor = Color.Transparent
        'End With
        'Me.PicPlano.Controls.Add(Me._arrNames(pos))

        ''Asigno Eventos
        'AddHandler Me._arrImgs(pos).MouseDown, AddressOf PicObjectMove_MouseDown
        'AddHandler Me._arrImgs(pos).DragOver, AddressOf Drag_Over
        'AddHandler Me._arrImgs(pos).GiveFeedback, AddressOf SetCursorFeedback

        'Me.AddItem( _
        '                        0, _
        '                        CType((e.Data.GetData(DataFormats.Bitmap)), Bitmap), _
        '                        Me.PicPlano.Cursor.Position.X - (img.Width / 2), _
        '                        Me.PicPlano.Cursor.Position.Y - (img.Height / 2))

    End Sub

    Private Function AddItem(ByVal id_img As Integer, ByVal img As Bitmap, ByVal pos_x As Integer, ByVal pos_y As Integer) As Integer
        'Return: el id de imagen

        '### Creo y agrego la imagen y el label de información
        Dim pos As Integer = Me._arrImgs.Length
        ReDim Preserve Me._arrImgs(pos)
        ReDim Preserve Me._arrNames(pos)

        'Configuro la imagen
        Me._arrImgs(pos) = New PictureBox
        With Me._arrImgs(pos)
            .AllowDrop = False
            .Cursor = Cursors.Hand
            .Image = img
            .Location = New Point(pos_x, pos_y)
            .SizeMode = PictureBoxSizeMode.AutoSize
            .Tag = id_img            'id de la imagen
            .Name = 0                 'Id del registros
            .Text = pos                'Posicion dentro del array
            .Visible = True
        End With

        Me.ToolTip.SetToolTip(Me._arrImgs(pos), "Pinchar y Mantener pulsado para Arrastrar y Colocar en el Plano" & vbCrLf & vbCrLf & "Clic con el botón Secundario para Editar Detalles o Eliminar")

        'Obtengo datos para la etiqueta
        Dim rst As ADODB.Recordset = My.m_db.GetRst("SELECT app_design_categorias.id,title FROM app_design,app_design_categorias WHERE app_design_categorias.id=app_design.id_categoria  AND app_design.id=" & id_img)
        'Aumento el contado de nº de tipo puestas en +1
        Dim i As Integer = 0
        For i = 0 To Me._arrCount.GetLength(0) - 1
            If rst("id").Value = Me._arrCount(i, 0) Then
                Me._arrCount(i, 1) += 1
                Exit For
            End If
        Next

        'Configuro la etiqueta
        Me._arrNames(pos) = New Label
        With Me._arrNames(pos)
            .AutoSize = False
            .Font = New Font("Verdana", 9, FontStyle.Bold)
            .ForeColor = Color.GreenYellow
            .Location = New Point(Me._arrImgs(pos).Left - (Me._arrImgs(pos).Width / 2), Me._arrImgs(pos).Top + Me._arrImgs(pos).Height + 1)
            .Size = New Size(Me._arrImgs(pos).Width * 2, 16)
            .Text = rst("title").Value & " #" & Me._arrCount(i, 1)
            .TextAlign = ContentAlignment.MiddleCenter
            .BackColor = Color.Transparent

        End With
        My.m_db.CloseRst(rst)

        Me.PicPlano.Controls.Add(Me._arrImgs(pos))
        Me.PicPlano.Controls.Add(Me._arrNames(pos))

        'Asigno Eventos
        AddHandler Me._arrImgs(pos).MouseDown, AddressOf PicObjectMove_MouseDown
        AddHandler Me._arrImgs(pos).DragOver, AddressOf Drag_Over
        AddHandler Me._arrImgs(pos).GiveFeedback, AddressOf SetCursorFeedback

        Return pos
        'AddHandler Me._imgs(pos).MouseEnter, AddressOf PicObject_MouseEnter
        'AddHandler Me._imgs(pos).MouseLeave, AddressOf PicObject_MouseLeave
    End Function
#End Region

#Region "Carga de Zonas"
    Private Sub LoadMesas(Optional ByVal swNoSave As Boolean = False)
        'Al cambiar de zona controlo si tiene que guardar cambios
        Static swLoader As Boolean = False
        If swLoader AndAlso Not swNoSave AndAlso Me.swChanges Then
            Select Case MsgBox("Atencion, se han producido cambios en esta zona." & vbCrLf & "¿Desea guardar los cambios efecturados?", MsgBoxStyle.Question + MsgBoxStyle.YesNoCancel)
                Case MsgBoxResult.Yes : Me.Buttons_Click(Me.BtOk, New System.EventArgs)
                Case MsgBoxResult.Cancel : Exit Sub
            End Select
        End If
        swLoader = True

        Dim i As Integer
        Me.PicPlano.SuspendLayout()

        'Elimino imagenes de la zona anterior y reseteo valores
        If Not IsNothing(Me._arrImgs) Then
            For i = 0 To Me._arrImgs.Length - 1
                Me._arrImgs(i).Dispose()
                Me._arrNames(i).Dispose()
            Next
        End If
        ReDim _arrImgs(-1)
        ReDim _arrNames(-1)
        Me.swChanges = False


        'Cargo las mesas guardadas de la zona
        Dim rst As ADODB.Recordset = My.m_db.GetRst("SELECT db_design.*,app_design.img FROM db_design,app_design WHERE app_design.id=db_design.id_img AND db_design.id_zona=" & Me.CbZonas.Text.Substring(100).Trim & " ORDER BY db_design.id")
        While Not rst.EOF
            i = Me.AddItem(rst("id_img").Value, My.m_db.data_GetImgRow(rst("img")), rst("pos_x").Value, rst("pos_y").Value)
            Me._arrImgs(i).Name = rst("id").Value
            Me._arrNames(i).Text = rst("name").Value
            rst.MoveNext()
        End While
        My.m_db.CloseRst(rst)
        Me.PicPlano.ResumeLayout()
    End Sub
#End Region

End Class