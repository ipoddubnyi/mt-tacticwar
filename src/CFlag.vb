
Public Class CFlag
    Friend IsFlag As Boolean = False
    Friend X, Y As Integer

    'Рисование флага
    Friend Sub Draw(ByVal Colr As Color)
        Dim myGraphics As Graphics = FrmMain.Field.CreateGraphics()
        Dim myPen As New System.Drawing.Pen(Colr)

        'линии (3 линии сверху вниз: 1 (штатив) сверху вниз, 2 - флаг)
        myGraphics.DrawLine(myPen, X + LenCell \ 3, Y + 3, X + LenCell \ 3, Y + LenCell - 3)
        myGraphics.DrawLine(myPen, X + LenCell \ 3 + 1, Y + 3, X + LenCell * 2 \ 3, Y + LenCell \ 2)
        myGraphics.DrawLine(myPen, X + LenCell \ 3 + 1, Y + LenCell \ 2, X + LenCell * 2 \ 3, Y + LenCell \ 2)

        myPen.Dispose()
        myGraphics.Dispose()
    End Sub

    'Удаление флага
    Friend Sub Remove()
        Dim tmpLand As New Landscape(Scheme.LAND)

        tmpLand.X = X
        tmpLand.Y = Y

        LandMas(Y \ LenCell, X \ LenCell).Draw()
    End Sub

End Class
