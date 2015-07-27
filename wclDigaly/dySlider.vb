Public Class dySlider
    Dim intBallX As Integer = 0
    Dim blnIsSliding As Boolean = False

    Public Event ValueChanged()

    Public Property Value As Byte
        Get
            Return CByte(((intBallX) / (Me.Width - 16)) * 100)
        End Get
        Set(value As Byte)
            intBallX = CInt((Me.Width) * (value / 100))
        End Set
    End Property

    Protected Overrides Sub OnPaint(ByVal e As System.Windows.Forms.PaintEventArgs)
        MyBase.OnPaint(e)
        Me.DoubleBuffered = True

        e.Graphics.SmoothingMode = Drawing2D.SmoothingMode.HighQuality
        e.Graphics.FillRectangle(Brushes.LightGray, 0, CInt(Me.Height / 2) - 2, Me.Width, 2)
        e.Graphics.FillRectangle(New SolidBrush(ForeColor), 0, CInt(Me.Height / 2) - 2, intBallX, 2)
        e.Graphics.FillEllipse(New SolidBrush(ForeColor), intBallX, CInt(Me.Height / 2) - 8, 16, 16)

        'Add your custom paint code here
    End Sub

    Public Shadows Sub OnMouseMove(sender As Object, e As System.EventArgs) Handles Me.MouseMove
        Dim pntPos As Point = Me.PointToClient(MousePosition)

        If blnIsSliding Then
            If pntPos.X + 8 <= Me.Width - 1 Then
                If pntPos.X - 8 >= 0 Then
                    intBallX = pntPos.X - 8
                    Me.Invalidate()
                    RaiseEvent ValueChanged()
                End If
            End If
        End If

    End Sub

    Public Shadows Sub OnMouseDown(sender As Object, e As System.EventArgs) Handles Me.MouseDown
        blnIsSliding = True
    End Sub

    Public Shadows Sub OnMouseUp(sender As Object, e As System.EventArgs) Handles Me.MouseUp
        blnIsSliding = False
    End Sub

End Class
