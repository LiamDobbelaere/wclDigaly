Imports System.ComponentModel

Public Class dyFlatButton
    Dim bmpButtonImage As Bitmap
    Dim bytState As Byte = 0
    Dim blnScaleIcons As Boolean = True
    Dim alImageAlign As ContentAlignment = ContentAlignment.MiddleLeft
    Dim pdePadding As Padding = Padding.Empty
    Dim blnColorIcons As Boolean = False
    Dim colIconColor As Color = Color.White

    Public Property ButtonImage As Bitmap
        Get
            Return bmpButtonImage
        End Get
        Set(value As Bitmap)
            bmpButtonImage = value
            Invalidate()
        End Set
    End Property

    Public Property ScaleIcons As Boolean
        Get
            Return blnScaleIcons
        End Get
        Set(value As Boolean)
            blnScaleIcons = value
            Invalidate()
        End Set
    End Property

    Public Property ColorIcons As Boolean
        Get
            Return blnColorIcons
        End Get
        Set(value As Boolean)
            blnColorIcons = value
            Invalidate()
        End Set
    End Property

    Public Property ColorIconsColor As Color
        Get
            Return colIconColor
        End Get
        Set(value As Color)
            colIconColor = value
            Invalidate()
        End Set
    End Property

    Public Property ImageAlign As ContentAlignment
        Get
            Return alImageAlign
        End Get
        Set(value As ContentAlignment)
            If value = ContentAlignment.MiddleLeft Or value = ContentAlignment.MiddleCenter Or value = ContentAlignment.MiddleRight Then
                alImageAlign = value
            Else
                Throw New Exception("Aligning the image anywhere else instead of middle is not implemented right now. Sorry kiddo.")
            End If
            Invalidate()
        End Set
    End Property

    <Browsable(False)>
    Public Overloads Property BackgroundImage As Bitmap
        Get
            Return Nothing
        End Get
        Set(value As Bitmap)

        End Set
    End Property

    <Browsable(False)>
    Public Overloads Property BackgroundImageLayout As ImageLayout
        Get
            Return Nothing
        End Get
        Set(value As ImageLayout)

        End Set
    End Property


    Public Overloads Property Padding As Padding
        Get
            Return pdePadding
        End Get
        Set(value As Padding)
            pdePadding = value
            Invalidate()
        End Set
    End Property

    Public Sub New()
        InitializeComponent()

        SetStyle(ControlStyles.UserPaint, True)
        SetStyle(ControlStyles.SupportsTransparentBackColor, True)
    End Sub

    Protected Overrides Sub OnPaint(ByVal e As PaintEventArgs)
        MyBase.DoubleBuffered = True

        e.Graphics.SmoothingMode = Drawing2D.SmoothingMode.AntiAlias

        e.Graphics.FillRectangle(New SolidBrush(BackColor), 0, 0, Width, Height)

        If bytState = 1 Then
            e.Graphics.FillRectangle(New SolidBrush(Color.FromArgb(50, 0, 0, 0)), 0, 0, Width, Height)
        ElseIf bytState = 2 Then
            e.Graphics.FillRectangle(New SolidBrush(Color.FromArgb(100, 0, 0, 0)), 0, 0, Width, Height)
        End If

        If Focused Then
            For i As Integer = 0 To 3
                e.Graphics.DrawRectangle(New Pen(Color.FromArgb(128, 255, 255, 255)), 0 + i, 0 + i, Width - i * 2, Height - i * 2)
            Next
        End If

        If bmpButtonImage IsNot Nothing Then
            If blnScaleIcons Then
                Dim fltScale As Single = Math.Min(Width / bmpButtonImage.Width, Height / bmpButtonImage.Height)
                Dim intWidth As Integer = CInt(bmpButtonImage.Width * fltScale)
                Dim intHeight As Integer = CInt(bmpButtonImage.Height * fltScale)

                e.Graphics.InterpolationMode = Drawing2D.InterpolationMode.Bicubic

                If alImageAlign = ContentAlignment.MiddleLeft Then
                    e.Graphics.DrawImage(bmpButtonImage, pdePadding.Left, pdePadding.Top, intWidth - pdePadding.Right * 2, intHeight - pdePadding.Bottom * 2)
                ElseIf alImageAlign = ContentAlignment.MiddleCenter
                    e.Graphics.DrawImage(bmpButtonImage, CInt(Width / 2 - intWidth / 2) + pdePadding.Left, CInt(Height / 2 - intHeight / 2) + pdePadding.Top, intWidth - pdePadding.Right * 2, intHeight - pdePadding.Bottom * 2)
                ElseIf alImageAlign = ContentAlignment.MiddleRight
                    e.Graphics.DrawImage(bmpButtonImage, Width - intWidth + pdePadding.Left * 2 - pdePadding.Right, pdePadding.Top, intWidth - pdePadding.Right * 2, intHeight - pdePadding.Bottom * 2)
                End If
            Else
                If alImageAlign = ContentAlignment.MiddleLeft Then
                    e.Graphics.DrawImage(bmpButtonImage, pdePadding.Left, CInt(Height / 2 - bmpButtonImage.Height / 2), bmpButtonImage.Width, bmpButtonImage.Height)
                ElseIf alImageAlign = ContentAlignment.MiddleCenter
                    e.Graphics.DrawImage(bmpButtonImage, CInt(Width / 2 - bmpButtonImage.Width / 2) + pdePadding.Left, CInt(Height / 2 - bmpButtonImage.Height / 2) + pdePadding.Top, bmpButtonImage.Width, bmpButtonImage.Height)
                ElseIf alImageAlign = ContentAlignment.MiddleRight
                    e.Graphics.DrawImage(bmpButtonImage, Width - bmpButtonImage.Width - pdePadding.Right, CInt(Height / 2 - bmpButtonImage.Height / 2), bmpButtonImage.Width, bmpButtonImage.Height)
                End If
            End If

        End If


        Dim s As New StringFormat
        s.Alignment = StringAlignment.Center
        s.LineAlignment = StringAlignment.Center

        e.Graphics.TextRenderingHint = Drawing.Text.TextRenderingHint.ClearTypeGridFit
        e.Graphics.DrawString(Text, Font, New SolidBrush(ForeColor), New Point(Width / 2, Height / 2), s)
    End Sub



    Public Shadows Sub OnMouseEnter(sender As Object, e As System.EventArgs) Handles Me.MouseEnter
        bytState = 1
        Invalidate()
    End Sub

    Public Shadows Sub OnMouseLeave(sender As Object, e As System.EventArgs) Handles Me.MouseLeave
        bytState = 0
        Invalidate()
    End Sub

    Public Shadows Sub OnMouseDown(sender As Object, e As System.EventArgs) Handles Me.MouseDown
        bytState = 2
        Focus()
        Invalidate()
    End Sub

    Public Shadows Sub OnMouseUp(sender As Object, e As System.EventArgs) Handles Me.MouseUp
        bytState = 1
        Invalidate()
    End Sub

    Public Shadows Sub OnHandleCreated(sender As Object, e As System.EventArgs) Handles Me.HandleCreated
        Invalidate()
    End Sub

    Public Shadows Sub OnResize(sender As Object, e As System.EventArgs) Handles Me.Resize
        Invalidate()
    End Sub

    Public Shadows Sub OnTextChanged(sender As Object, e As System.EventArgs) Handles Me.TextChanged
        Invalidate()
    End Sub

    Public Shadows Sub OnGotFocus(sender As Object, e As System.EventArgs) Handles Me.GotFocus
        Invalidate()
    End Sub

    Public Shadows Sub OnLostFocus(sender As Object, e As System.EventArgs) Handles Me.LostFocus
        Invalidate()
    End Sub

    Public Shadows Sub OnKeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Space Or e.KeyCode = Keys.Enter Then
            bytState = 2
            Focus()
            Invalidate()
        End If
    End Sub

    Public Shadows Sub OnKeyUp(sender As Object, e As KeyEventArgs) Handles Me.KeyUp
        If e.KeyCode = Keys.Space Or e.KeyCode = Keys.Enter Then
            bytState = 0
            Invalidate()
            OnClick(EventArgs.Empty)
        End If
    End Sub

End Class
