Public Class dyGrid
    Dim intSpacing As Integer = 16

    Public Property GridSize As Integer
        Get
            Return intSpacing
        End Get
        Set(value As Integer)
            If value > 1 Then
                intSpacing = value
                Me.Invalidate()
            End If
        End Set
    End Property

    Protected Overrides Sub OnPaint(ByVal e As System.Windows.Forms.PaintEventArgs)
        MyBase.OnPaint(e)
        Me.DoubleBuffered = True

        e.Graphics.SmoothingMode = Drawing2D.SmoothingMode.AntiAlias

        If intSpacing > 1 Then
            Dim intMaxLines As Integer

            If Me.Width >= Me.Height Then
                intMaxLines = Me.Width / intSpacing
            Else
                intMaxLines = Me.Height / intSpacing
            End If

            For intLine As Integer = 1 To intMaxLines
                e.Graphics.DrawLine(New Pen(ForeColor), 0, intSpacing * intLine, Me.Width, intSpacing * intLine)
                e.Graphics.DrawLine(New Pen(ForeColor), intSpacing * intLine, 0, intSpacing * intLine, Me.Height)
            Next
        End If

        'Add your custom paint code here
    End Sub

    Protected Overrides Sub OnResize(e As EventArgs)
        MyBase.OnResize(e)

        Me.Invalidate()
    End Sub

End Class
