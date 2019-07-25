Public Class FrmMain

    Dim selX, selY As Integer
    Dim Player() As CPlayer

    Private Sub FrmMain_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Field.Visible = False
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        ReDim OtryadMas(FieldSize - 1, FieldSize - 1)
        ReDim LandMas(FieldSize - 1, FieldSize - 1)
        ReDim EnableMas(FieldSize - 1, FieldSize - 1)
        ReDim Player(0)

        Player(0) = New CPlayer(0)

        Dim i, j As Integer

        For i = 0 To FieldSize - 1
            For j = 0 To FieldSize - 1
                OtryadMas(i, j) = Nothing
            Next
        Next

        Field.Left = 10
        Field.Top = 10
        Field.Width = FieldSize * LenCell + 1
        Field.Height = FieldSize * LenCell + 1
        Field.Visible = True

        'изменение размера формы
        'Me.Width = Field.Width + Field.Left + 50 + Button1.Width
        'Me.Height = Field.Height + Field.Top + 50

        '+++++++++++++++++++++++++++++++++++

        CreateMap()

    End Sub

    'Карта
    Private Sub CreateMap()
        Dim i, j As Integer
        Dim mapa As String = "00000000000000011111000000022222000000002000000000000000000011000000000003333000000000300000000330000000000000"
        Dim unitdis As String = "00000002000002000000200002000000000000000000000000000000000000000000000100000010000100001000000000000000000000"

        For i = 0 To FieldSize - 1
            For j = 0 To FieldSize - 1
                LandMas(i, j) = New Landscape(Scheme.LAND)

                LandMas(i, j).LandType = CInt(Mid(mapa, i * FieldSize + j + 1, 1))
                LandMas(i, j).X = LenCell * j
                LandMas(i, j).Y = LenCell * i
                LandMas(i, j).Draw()
            Next
        Next

        '=============================
        '  = = = = = = = = = = = = =
        '=============================

        For i = 0 To FieldSize - 1
            For j = 0 To FieldSize - 1
                If Mid(unitdis, i * FieldSize + j + 1, 1) = "1" Then

                    OtryadMas(i, j) = New COtryad(Player(0), "175-я Новгородская")
                    OtryadMas(i, j).Xpix = LenCell * j
                    OtryadMas(i, j).Ypix = LenCell * i
                    'UnitMas(i, j).ReSumParam()
                    OtryadMas(i, j).Draw()

                    Player(0).unitList.Add(OtryadMas(i, j))
                    LandMas(i, j).IsUnit = True
                End If
            Next
        Next
    End Sub

    'Щелчок по полю
    Private Sub Field_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Field.Click
        If Not IsNothing(OtryadMas(selY, selX)) Then
            SelectOtryad = OtryadMas(selY, selX)
            SelectOtryad.UnitSelect()
            IsUnitSelect = True

            ListBox1.Items.Clear()

            Dim i As Integer
            For i = 0 To SelectOtryad.Units.Count - 1
                ListBox1.Items.Add(SelectOtryad.Units.Item(i).Name)
            Next

            SelectOtryad.ReSumMoves() 'selX, selY)

            txtInfo.Text = "SelectOtryad.Name = " & SelectOtryad.Name & vbCrLf
            txtInfo.Text += "SelectOtryad.Armor = " & SelectOtryad.Armor & vbCrLf
            txtInfo.Text += "SelectOtryad.Health = " & SelectOtryad.Health & vbCrLf
            txtInfo.Text += "SelectOtryad.Power = " & SelectOtryad.Power & vbCrLf
            txtInfo.Text += "SelectOtryad.Steps = " & SelectOtryad.Steps & vbCrLf

            txtInfo.Text += vbCrLf & "SelectOtryad.X = " & SelectOtryad.X & vbCrLf
            txtInfo.Text += "SelectOtryad.Y = " & SelectOtryad.Y & vbCrLf
            txtInfo.Text += "SelectOtryad.Xpix = " & SelectOtryad.Xpix & vbCrLf
            txtInfo.Text += "SelectOtryad.Ypix = " & SelectOtryad.Ypix & vbCrLf
        ElseIf IsUnitSelect Then
            'ReSumMoves(SelectOtryad.X, SelectOtryad.Y) 'selX, selY)

            'Dim tmpU As Otryad = GetSelectedUnit()

            If (EnableMas(SelectOtryad.X, SelectOtryad.Y) = 1000) Then ' <= SelectOtryad.Steps) Then
                UnitMoveFlag(True)
                Label1.Text = "Шагов: " + CStr(EnableMas(SelectOtryad.X, SelectOtryad.Y))
            Else
                UnitMoveFlag(False)
                Label1.Text = "НЕ ХВАТАЕТ ШАГОВ!"
            End If
        End If
    End Sub

    'Выбор места передвижения
    Private Sub UnitMoveFlag(ByVal CanMove As Boolean)
        If IsUnitSelect Then
            Dim IsMoving As Boolean = False

            If flag.IsFlag Then
                flag.Remove() 'стераем флаг
                flag.IsFlag = False

                'если в этом месте уже есть флаг
                If (flag.X = selX * LenCell) And (flag.Y = selY * LenCell) Then
                    'Dim q As MsgBoxResult = MsgBox("", MsgBoxStyle.Question, MsgBoxStyle.YesNo)

                    Dim ThisTank As COtryad = GetSelectedUnit()
                    ThisTank.Remove()
                    ThisTank.IsSelect = False

                    'удаление из массива юнита
                    OtryadMas(ThisTank.Ypix \ LenCell, ThisTank.Xpix \ LenCell) = Nothing
                    ThisTank.Xpix = flag.X
                    ThisTank.Ypix = flag.Y

                    'запись его в новое место массива
                    OtryadMas(flag.Y \ LenCell, flag.X \ LenCell) = ThisTank
                    ThisTank.Draw()

                    IsMoving = True
                    IsUnitSelect = False
                End If
            End If

            'если было перемещение - то флаг рисовать не надо!
            If Not IsMoving Then
                flag.X = selX * LenCell
                flag.Y = selY * LenCell

                If CanMove Then
                    flag.Draw(Color.Red)
                    flag.IsFlag = True
                Else
                    flag.Draw(Color.Blue)
                    flag.IsFlag = True
                End If
            End If
        End If
    End Sub

    'узнать, какой юнит выделен
    Private Function GetSelectedUnit() As COtryad
        Dim i As Integer

        'снимаем выделение со всех юнитов
        For i = 0 To Player(0).unitList.Count - 1
            If Player(0).unitList(i).IsSelect Then
                Return Player(0).unitList(i)
            End If
        Next

        Return Nothing
    End Function

    'Смена курсора
    Private Sub Field_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Field.MouseMove
        If (e.X <> FieldSize * LenCell) And (e.Y <> FieldSize * LenCell) _
                        And (e.X <> 0) And (e.Y <> 0) Then

            selX = e.X \ LenCell
            selY = e.Y \ LenCell

            If Not IsNothing(OtryadMas(selY, selX)) Then
                'если в этой ячейке есть юнит
                Field.Cursor = Cursors.Hand
            Else
                'если в этой ячейке нет юнита

                'если есть выделенный юнит
                If IsUnitSelect Then
                    'если доступное место
                    'If EnableMas(selY, selX) = 1 Then
                    Field.Cursor = Cursors.Cross
                    'Else
                    'Field.Cursor = Cursors.No
                    'End If
                Else
                    Field.Cursor = Cursors.Default
                End If
            End If
        End If
    End Sub

End Class
