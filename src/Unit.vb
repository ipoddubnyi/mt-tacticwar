Imports System.Drawing

Module ModulUnit

    Friend Const LenCell = 15
    Friend LandMas(,) As Landscape

    Friend flag As New CFlag

    Friend OtryadMas(,) As COtryad
    Friend EnableMas(,) As Integer
    Friend FieldSize As Integer = 10
    Friend IsUnitSelect As Boolean = False

    Friend SelectOtryad As COtryad 'выделенный отряд

    '=================================

    'рекурсивное определение доступных ходов
    Private Sub RekursStep(ByVal sx As Integer, ByVal sy As Integer, ByVal mov As Integer)

        '!!!!!!!!!!!!!!!!!
        'И С П Р А В И Т Ь
        '!!!!!!!!!!!!!!!!!

        'влево
        If CanStep1(sx - 1, sy) Then
            mov += 1
            If (EnableMas(sy, sx - 1) > mov) Or (EnableMas(sy, sx - 1) = 0) Then
                EnableMas(sy, sx - 1) += mov
                RekursStep(sx - 1, sy, mov)
            End If
        End If

        'вправо
        If CanStep1(sx + 1, sy) Then
            mov += 1
            If (EnableMas(sy, sx + 1) > mov) Or (EnableMas(sy, sx + 1) = 0) Then
                EnableMas(sy, sx + 1) += mov
                RekursStep(sx + 1, sy, mov)
            End If
        End If

        'вверх
        If CanStep1(sx, sy - 1) Then
            mov += 1
            If (EnableMas(sy - 1, sx) > mov) Or (EnableMas(sy - 1, sx) = 0) Then
                EnableMas(sy - 1, sx) += mov
                RekursStep(sx, sy - 1, mov)
            End If
        End If

        'вниз
        If CanStep1(sx, sy + 1) Then
            mov += 1
            If (EnableMas(sy + 1, sx) > mov) Or (EnableMas(sy + 1, sx) = 0) Then
                EnableMas(sy + 1, sx) += mov
                RekursStep(sx, sy + 1, mov)
            End If
        End If

    End Sub

    'можно ли ступить
    Private Function CanStep1(ByVal sx As Integer, ByVal sy As Integer) As Boolean
        Dim res As Boolean = False

        'если ячейка в границах массива
        If ((sx < FieldSize) And (sx >= 0) And (sy < FieldSize) And (sy >= 0)) Then
            'если в ячейке не стоит юнит
            If IsNothing(OtryadMas(sy, sx)) Then
                'если не вода и не камни
                If ((LandMas(sy, sx).LandType <> 1) And (LandMas(sy, sx).LandType <> 3)) Then
                    res = True
                End If
            End If
        End If

        CanStep1 = res
    End Function

#Region "ЛАНДШАФТ"

    'Типы схемы
    Enum Scheme
        LAND
        CITY
        SNOW
    End Enum

    'Схема (земля, город, снег)
    Friend Class LandScheme

        Dim Type As Scheme

        'Конструктор
        Friend Sub New(ByVal schm As Scheme)
            Type = schm
        End Sub

        'Вернуть имя схемы
        'Friend Function GetName() As String
        '    Return Type.ToString
        'End Function

        'Вернуть цвет элемента схемы
        Friend Function GetColor(ByVal LandType As Integer) As Color
            If Type = Scheme.CITY Then 'город
                Select Case LandType
                    Case 1
                        Return Color.SeaGreen 'рисуем воду
                    Case 2
                        Return Color.LightGray 'рисуем дорогу
                    Case 3
                        Return Color.Gray 'рисуем дома
                    Case Else
                        Return Color.LightGreen 'рисуем зелень
                End Select
            ElseIf Type = Scheme.SNOW Then 'снег
                Select Case LandType
                    Case 1
                        Return Color.SkyBlue 'рисуем воду
                    Case 2
                        Return Color.Snow  'рисуем тропу
                    Case 3
                        Return Color.Gray 'рисуем камни
                    Case Else
                        Return Color.White 'рисуем снег
                End Select
            Else 'обычная земля
                Select Case LandType
                    Case 1
                        Return Color.LightBlue 'рисуем воду
                    Case 2
                        Return Color.LightYellow 'рисуем песок
                    Case 3
                        Return Color.LightGray 'рисуем камни
                    Case Else
                        Return Color.LightGreen 'рисуем зелень
                End Select
            End If
        End Function

    End Class

    'Ландшафт
    Friend Class Landscape

        Dim Name As String 'имя
        Dim TypeScheme As LandScheme 'цветовая схема (зелень, город, снег)
        Friend LandType As Integer 'тип (зелень (0), вода (1), песок (2), камни (3))
        Dim Hill As Integer 'высота
        Dim Cost As Integer 'сколько шагов жрёт

        Friend X, Y As Integer

        Friend IsUnit As Boolean = False 'стоит ли юнит

        '=====================================

        'Конструктор
        Friend Sub New(ByVal schm As Scheme)
            TypeScheme = New LandScheme(schm)
            Name = schm.ToString
        End Sub

        'Рисование
        Friend Sub Draw()
            Dim lColor As Color

            lColor = TypeScheme.GetColor(LandType)

            Dim myGraphics As Graphics = FrmMain.Field.CreateGraphics()
            Dim myBrush As New System.Drawing.SolidBrush(lColor)
            Dim myPen As New System.Drawing.Pen(lColor)
            Dim i As Integer

            'линии (3 линии сверху вниз: 1 (штатив) сверху вниз, 2 - флаг)
            'For i = 0 To LenCell \ 2 - 1
            '    myGraphics.DrawLine(myPen, X + i, Y, X + i, Y)
            '    myGraphics.DrawLine(myPen, X, Y + 2 * i, X, Y + 2 * i)
            '    myGraphics.DrawLine(myPen, X + 2 * i, Y + LenCell, X + 2 * i, Y + LenCell)
            '    myGraphics.DrawLine(myPen, X + LenCell, Y + 2 * i, X + LenCell, Y + 2 * i)
            'Next

            Dim myRect As New Rectangle(X, Y, LenCell, LenCell)

            myGraphics.FillRectangle(myBrush, myRect)

            myPen.Dispose()
            myGraphics.Dispose()
        End Sub

    End Class

#End Region

End Module
