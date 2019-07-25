
'Типы юнитов
Public Enum UnitType
    INFANTRY
    'CAR
    ARMOURED 'бронерованные
    PLANE
End Enum

'Юнит
Public Class CUnit

    Friend Name As String
    Protected Type As UnitType
    Friend Power As Integer
    Friend Armor As Integer
    Friend Health As Integer
    Protected Wins As Integer
    Protected Cost As Integer
    Friend Steps As Integer 'шаги

    Protected Rang As Integer

    Protected Info As String

    'победа в сражении
    Friend Sub WinBattle()
        Wins += 1
        LevelUp()
    End Sub

    'повышение уровня
    Friend Sub LevelUp()
        Select Case Wins
            Case 5 To 9
                Rang = 1
            Case 10 To 19
                Rang = 2
            Case Is >= 20
                Rang = 3
            Case Else
                Rang = 0
        End Select

        Power += Rang
        Armor += Rang
    End Sub

End Class

#Region "ЮНИТ - ПЕХОТА"

'новобранец
Public Class CUnitTroopRekrut
    Inherits CUnit

    Friend Sub New()
        Name = "Новобранец"
        Power = 1
        Armor = 1
        Health = 10
        Wins = 0
        Cost = 10
        Rang = 0
        Info = ""
        Steps = 4
    End Sub
End Class

'ветеран
Public Class CUnitTroopVeteran
    Inherits CUnit

    Friend Sub New()
        Name = "Ветеран"
        Power = 3
        Armor = 2
        Health = 10
        Wins = 0
        Cost = 20
        Rang = 0
        Info = ""
        Steps = 5
    End Sub
End Class

'партизан
Public Class CUnitTroopPartizan
    Inherits CUnit

    Friend Sub New()
        Name = "Партизан"
        Power = 2
        Armor = 3
        Health = 12
        Wins = 0
        Cost = 15
        Rang = 0
        Info = ""
        Steps = 6
    End Sub
End Class

'спецназ
Public Class CUnitTroopCommando
    Inherits CUnit

    Friend Sub New()
        Name = "Спецназ"
        Power = 7
        Armor = 7
        Health = 17
        Wins = 0
        Cost = 30
        Rang = 0
        Info = ""
        Steps = 6
    End Sub
End Class

'диверсант
Public Class CUnitTroopDiversant
    Inherits CUnit

    Friend Sub New()
        Name = "Диверсант"
        Power = 10
        Armor = 7
        Health = 15
        Wins = 0
        Cost = 35
        Rang = 0
        Info = ""
        Steps = 7
    End Sub
End Class

#End Region

#Region "ЮНИТ - ТАНКИ"

'Т-72
Public Class CUnitTankT72
    Inherits CUnit

    Friend Sub New()
        Name = "Т-72"
        Power = 30
        Armor = 30
        Health = 30
        Wins = 0
        Cost = 50
        Rang = 0
        Steps = 14

        Info = "ОСНОВНОЙ БОЕВОЙ ТАНК (1973)" + vbCrLf + _
                "Боевая масса: 46 т" + vbCrLf + _
                "Экипаж: 3 чел." + vbCrLf + _
                "Длина: 9500" + vbCrLf + _
                "Ширина: 3600" + vbCrLf + _
                "Высота: 2226" + vbCrLf + _
                "Максимальная скорость: 60 км/ч" + vbCrLf + _
                "Запас хода: 550-650 км" + vbCrLf + _
                "Вооружение: 1 пушка (125 мм), 1 пулемет (12,7 мм), 1 пулемет (7,62)"
    End Sub
End Class

'Т-80У
Public Class CUnitTankT80U
    Inherits CUnit

    Friend Sub New()
        Name = "Т-80У"
        Power = 33
        Armor = 33
        Health = 31
        Wins = 0
        Cost = 60
        Rang = 0
        Steps = 15

        Info = "ОСНОВНОЙ БОЕВОЙ ТАНК (1985)" + vbCrLf + _
                "Боевая масса: 46 т" + vbCrLf + _
                "Экипаж: 3 чел." + vbCrLf + _
                "Длина: 9530" + vbCrLf + _
                "Ширина: 3460" + vbCrLf + _
                "Высота: 2202" + vbCrLf + _
                "Максимальная скорость: 70 км/ч" + vbCrLf + _
                "Запас хода: 400 км" + vbCrLf + _
                "Вооружение: 1 пушка (125 мм), 1 пулемет (12,7 мм), 1 пулемет (7,62), 8 дымовых гранатомётов"
    End Sub
End Class

'Т-90
Public Class CUnitTankT90
    Inherits CUnit

    Friend Sub New()
        Name = "Т-90"
        Power = 37
        Armor = 37
        Health = 32
        Wins = 0
        Cost = 80
        Rang = 0
        Steps = 14

        Info = "ОСНОВНОЙ БОЕВОЙ ТАНК (1993)" + vbCrLf + _
                "Боевая масса: 46,5 т" + vbCrLf + _
                "Экипаж: 3 чел." + vbCrLf + _
                "Длина: 9530" + vbCrLf + _
                "Ширина: 3460" + vbCrLf + _
                "Высота: 2230" + vbCrLf + _
                "Максимальная скорость: 60 км/ч" + vbCrLf + _
                "Запас хода: 500 км" + vbCrLf + _
                "Вооружение: 1 пушка (125 мм), 1 пулемет (12,7 мм), 1 пулемет (7,62), 12 дымовых гранатомётов"
    End Sub
End Class

'Т-95 "Чёрный Орёл"
Public Class CUnitTankT95
    Inherits CUnit

    Friend Sub New()
        Name = "Т-95 'Чёрный Орёл'"
        Power = 40
        Armor = 40
        Health = 35
        Wins = 0
        Cost = 100
        Rang = 0
        Steps = 14

        Info = "ОСНОВНОЙ БОЕВОЙ ТАНК" + vbCrLf + _
                "Боевая масса: 50 т" + vbCrLf + _
                "Экипаж: 3 чел." + vbCrLf + _
                "Максимальная скорость: 60 км/ч" + vbCrLf + _
                "Запас хода: 500 км" + vbCrLf + _
                "Вооружение: 1 пушка (152 мм), 1 пулемет (12,7 мм), комплекс активной защиты 'Дрозд-2', комплекс пассивной защиты 'Штора-2'"
    End Sub
End Class

#End Region
