
Public Class CPlayer
    Dim N As Integer
    Dim Name As String
    Public unitList As List(Of COtryad)
    Friend PlayerColor As Color
    Friend PlayerSelectedColor As Color

    'Новый игрок
    ' Параметры:
    '   ByVal num As Integer - номер игрока
    Friend Sub New(ByVal num As Integer)
        unitList = New List(Of COtryad)
        N = num

        Select Case N
            Case 0
                PlayerColor = Color.Green
                PlayerSelectedColor = Color.DarkGreen
            Case 1
                PlayerColor = Color.Red
                PlayerSelectedColor = Color.DarkRed
            Case Else
                PlayerColor = Color.White
                PlayerSelectedColor = Color.Black
        End Select

    End Sub

End Class
