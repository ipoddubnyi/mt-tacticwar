
'Подразделение
Public Class COtryad

    Friend Name As String 'номер бригады (175-я Новгородская)
    Friend Player As CPlayer
    Friend Units As List(Of CUnit)
    'Dim Number As Integer 'кол-во юнитов

    Friend Xpix As Integer
    Friend Ypix As Integer

    Friend X As Integer
    Friend Y As Integer

    Friend Power As Integer
    Friend Armor As Integer
    Friend Health As Integer
    'Dim Wins As Integer
    Friend Steps As Integer 'шаги

    Friend IsSelect As Boolean 'выделена ли

    'Конструктор (создание нового отряда)
    ' Параметры:
    '   ByVal plr As Players - игрок, которому будет принадлежать отряд
    Friend Sub New(ByVal plr As CPlayer, ByVal otrName As String)
        Player = plr

        X = Xpix \ LenCell
        Y = Ypix \ LenCell

        Name = otrName

        Units = New List(Of CUnit)
        Units.Add(New CUnitTankT72())
        Units.Add(New CUnitTankT80U())
        Units.Add(New CUnitTankT90())
        Units.Add(New CUnitTankT95())

        ReSumParam()
    End Sub

    'Рисование отряда на поле боя
    Friend Sub Draw()
        Dim TColor As Color

        If IsSelect Then
            TColor = Player.PlayerSelectedColor
        Else
            TColor = Player.PlayerColor
        End If

        Dim myGraphics As Graphics = FrmMain.Field.CreateGraphics()
        Dim myPen As New System.Drawing.Pen(TColor)

        'гусеницы (4 линии сверху вниз: 3 одинаковые, 1 покороче)
        'линии рисуются слева направо
        myGraphics.DrawLine(myPen, Xpix + 2, Ypix + LenCell - 5, Xpix + LenCell - 1, Ypix + LenCell - 5)
        myGraphics.DrawLine(myPen, Xpix + 2, Ypix + LenCell - 4, Xpix + LenCell - 1, Ypix + LenCell - 4)
        myGraphics.DrawLine(myPen, Xpix + 2, Ypix + LenCell - 3, Xpix + LenCell - 1, Ypix + LenCell - 3)
        myGraphics.DrawLine(myPen, Xpix + 3, Ypix + LenCell - 2, Xpix + LenCell - 2, Ypix + LenCell - 2)

        'башня (3 линии сверху вниз: короткая - длинная (ствол), средняя)
        'линии рисуются слева направо
        myGraphics.DrawLine(myPen, Xpix + 7, Ypix + LenCell - 8, Xpix + LenCell - 5, Ypix + LenCell - 8)
        myGraphics.DrawLine(myPen, Xpix + 1, Ypix + LenCell - 7, Xpix + LenCell - 4, Ypix + LenCell - 7)
        myGraphics.DrawLine(myPen, Xpix + 5, Ypix + LenCell - 6, Xpix + LenCell - 4, Ypix + LenCell - 6)

        myPen.Dispose()
        myGraphics.Dispose()
    End Sub

    'Удаление юнита
    Friend Sub Remove()
        Dim tmpLand As New Landscape(Scheme.LAND)

        tmpLand.X = Xpix
        tmpLand.Y = Ypix

        LandMas(Ypix \ LenCell, Xpix \ LenCell).Draw()
    End Sub

    'пересчитать все параметры подразделения
    Friend Sub ReSumParam()
        Dim i As Integer

        'Number = Units.Count
        Power = 0
        Armor = 0
        Health = 0
        Steps = 99

        For i = 0 To Units.Count - 1
            Units.Item(i).LevelUp()
            Power += Units.Item(i).Power
            Armor += Units.Item(i).Armor
            Health += Units.Item(i).Health

            If Steps > Units.Item(i).Steps Then Steps = Units.Item(i).Steps
        Next

        Power = Power \ Units.Count
        Armor = Armor \ Units.Count
        Health = Health \ Units.Count
        Steps = 5 'временно
    End Sub

    'победа в сражении
    Private Sub WinBattle()
        Dim i As Integer

        For i = 0 To Units.Count - 1
            Units.Item(i).WinBattle()
        Next
    End Sub

    'выделение юнита
    Friend Sub UnitSelect()
        Dim i As Integer
        Dim sel As Boolean = False

        If IsSelect Then sel = True
        IsUnitSelect = False
        IsSelect = False

        'снимаем выделение со всех юнитов
        For i = 0 To Player.unitList.Count - 1
            Player.unitList(i).IsSelect = False
            Player.unitList(i).Draw()

            'и стереть флаг
            If flag.IsFlag Then
                flag.Remove()
                flag.IsFlag = False
            End If
        Next

        'выделяем конкретного юнита, если он ещё не выделен
        If Not sel Then
            IsSelect = True
            IsUnitSelect = True
            Draw()
        End If
    End Sub

    'пересчёт возможных ходов
    Friend Sub ReSumMoves()
        Dim i, j As Integer

        'обнуление массива доступности
        For i = 0 To FieldSize - 1
            For j = 0 To FieldSize - 1
                EnableMas(i, j) = 0

                If ((LandMas(i, j).LandType <> 1) And (LandMas(i, j).LandType <> 3)) Then EnableMas(i, j) = 1000
                If Not IsNothing(OtryadMas(i, j)) Then EnableMas(i, j) = 1000
            Next
        Next

        myStep()

        'рекурсивное определение доступных ходов
        'Dim mov As Integer = 0
        'RekursStep(X, Y, mov)
    End Sub

    Private Sub myStep()
        Dim n, m As Integer

        For m = -Steps To Steps
            For n = -Steps To Steps
                If n + m <= Steps Then
                    If canStep(n, m) Then EnableMas(X + n, Y + m) = 1000
                End If
            Next
        Next
    End Sub

    Private Function canStep(ByVal n As Integer, ByVal m As Integer) As Boolean
        'за границами
        If ((X + n > FieldSize - 1) Or (X + n < 0)) Then Return False
        If ((Y + m > FieldSize - 1) Or (Y + m < 0)) Then Return False

        'непроходимая земля
        If ((LandMas(X + n, Y + m).LandType = 1) Or (LandMas(X + n, Y + m).LandType = 3)) Then Return False

        Return True
    End Function

    'Посчитать шаги от данной клетки до отряда
    Public Function CountSteps(ByVal cellX As Integer, ByVal cellY As Integer) As Integer
        Dim stepN As Integer = 0

        CountStepsReqFun(cellX, cellY, stepN)

        Return stepN
    End Function

    'Рекурсивная функция
    Public Sub CountStepsReqFun(ByVal cellX As Integer, ByVal cellY As Integer, ByRef stepN As Integer)
        'влево
        If (cellX <> 0) Then
            stepN += 1

            If (((cellX - 1) <> X) Or (cellY <> Y)) Then
                CountStepsReqFun(cellX - 1, Y, stepN)
            Else
                Return
            End If
        End If
    End Sub

End Class
