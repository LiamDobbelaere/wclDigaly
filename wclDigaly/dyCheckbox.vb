Public Class dyCheckbox

    Private bytState As Byte = 0

    Protected Overrides Sub OnPaint(ByVal e As System.Windows.Forms.PaintEventArgs)
        MyBase.OnPaint(e)

        'Hide old box
        e.Graphics.FillRectangle(New SolidBrush(Parent.BackColor), New Rectangle(0, 0, 14, Height))

        'e.Graphics.FillRectangle(Brushes.Red, New Rectangle(0, Height / 2 - 6, 13, 13))

        e.Graphics.FillRectangle(New SolidBrush(Color.FromArgb(50 * bytState, 0, 0, 0)), New Rectangle(0, Height / 2 - 6, 13, 13))

        e.Graphics.DrawRectangle(New Pen(ForeColor), New Rectangle(0, Height / 2 - 6, 13, 13))

        If Checked Then
            e.Graphics.FillRectangle(New SolidBrush(ForeColor), New Rectangle(2, Height / 2 - 4, 10, 10))
        End If


        'Add your custom paint code here
    End Sub

    Protected Overrides Sub OnMouseEnter(eventargs As EventArgs)
        MyBase.OnMouseEnter(eventargs)

        bytState = 1
    End Sub

    Protected Overrides Sub OnMouseLeave(eventargs As EventArgs)
        MyBase.OnMouseLeave(eventargs)

        bytState = 0
    End Sub

    Protected Overrides Sub OnMouseDown(mevent As MouseEventArgs)
        MyBase.OnMouseDown(mevent)

        bytState = 2
    End Sub

    Protected Overrides Sub OnMouseUp(mevent As MouseEventArgs)
        MyBase.OnMouseUp(mevent)

        bytState = 1
        Invalidate()
    End Sub

End Class
