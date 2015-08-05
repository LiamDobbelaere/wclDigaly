Module ColorConversion

    ''' <summary>
    ''' Creates a Color from alpha, hue, saturation and brightness.
    ''' </summary>
    ''' <param name="alpha">The alpha channel value.</param>
    ''' <param name="hue">The hue value.</param>
    ''' <param name="saturation">The saturation value.</param>
    ''' <param name="brightness">The brightness value.</param>
    ''' <returns>A Color with the given values.</returns>
    Public Function FromAhsb(alpha As Integer, hue As Single, saturation As Single, brightness As Single) As Color
        If 0 > alpha OrElse 255 < alpha Then
            Throw New ArgumentOutOfRangeException("alpha", alpha, "Value must be within a range of 0 - 255.")
        End If

        If 0F > hue OrElse 360.0F < hue Then
            Throw New ArgumentOutOfRangeException("hue", hue, "Value must be within a range of 0 - 360.")
        End If

        If 0F > saturation OrElse 1.0F < saturation Then
            Throw New ArgumentOutOfRangeException("saturation", saturation, "Value must be within a range of 0 - 1.")
        End If

        If 0F > brightness OrElse 1.0F < brightness Then
            Throw New ArgumentOutOfRangeException("brightness", brightness, "Value must be within a range of 0 - 1.")
        End If

        If 0 = saturation Then
            Return Color.FromArgb(alpha, Convert.ToInt32(brightness * 255), Convert.ToInt32(brightness * 255), Convert.ToInt32(brightness * 255))
        End If

        Dim fMax As Single, fMid As Single, fMin As Single
        Dim iSextant As Integer, iMax As Integer, iMid As Integer, iMin As Integer

        If 0.5 < brightness Then
            fMax = brightness - (brightness * saturation) + saturation
            fMin = brightness + (brightness * saturation) - saturation
        Else
            fMax = brightness + (brightness * saturation)
            fMin = brightness - (brightness * saturation)
        End If

        iSextant = CInt(Math.Floor(hue / 60.0F))
        If 300.0F <= hue Then
            hue -= 360.0F
        End If

        hue /= 60.0F
        hue -= 2.0F * CSng(Math.Floor(((iSextant + 1.0F) Mod 6.0F) / 2.0F))
        If 0 = iSextant Mod 2 Then
            fMid = (hue * (fMax - fMin)) + fMin
        Else
            fMid = fMin - (hue * (fMax - fMin))
        End If

        iMax = Convert.ToInt32(fMax * 255)
        iMid = Convert.ToInt32(fMid * 255)
        iMin = Convert.ToInt32(fMin * 255)

        Select Case iSextant
            Case 1
                Return Color.FromArgb(alpha, iMid, iMax, iMin)
            Case 2
                Return Color.FromArgb(alpha, iMin, iMax, iMid)
            Case 3
                Return Color.FromArgb(alpha, iMin, iMid, iMax)
            Case 4
                Return Color.FromArgb(alpha, iMid, iMin, iMax)
            Case 5
                Return Color.FromArgb(alpha, iMax, iMin, iMid)
            Case Else
                Return Color.FromArgb(alpha, iMax, iMid, iMin)
        End Select
    End Function
End Module
