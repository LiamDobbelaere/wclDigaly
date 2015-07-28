Imports System.ComponentModel

Public Class dyFlatButton
    Private bmpButtonImage As Bitmap
    Private bytState As Byte = 0
    Private blnScaleIcons As Boolean = True
    Private alImageAlign As ContentAlignment = ContentAlignment.MiddleLeft
    Private intBorderWidth As Integer = 4
    Private blnInverted As Boolean = False

    Public Property Inverted As Boolean
        Get
            Return blnInverted
        End Get
        Set(value As Boolean)
            blnInverted = value
            Invalidate()
        End Set
    End Property

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

    Public Property BorderWidth As Integer
        Get
            Return intBorderWidth
        End Get
        Set(value As Integer)
            intBorderWidth = value
            Invalidate()
        End Set
    End Property

    <Browsable(True), DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)>
    Public Overloads Property Padding As Padding
        Get
            Return MyBase.Padding
        End Get
        Set(value As Padding)
            MyBase.Padding = value
            Invalidate()
        End Set
    End Property

    'BackgroundImage not used, hidden
    <Browsable(False)>
    Public Overloads Property BackgroundImage As Bitmap
        Get
            Return Nothing
        End Get
        Set(value As Bitmap)

        End Set
    End Property

    'BackgroundImageLayout not used, hidden
    <Browsable(False)>
    Public Overloads Property BackgroundImageLayout As ImageLayout
        Get
            Return Nothing
        End Get
        Set(value As ImageLayout)

        End Set
    End Property

    <Browsable(False)>
    Public Property ColorIcons As Boolean
        Get
            Return Nothing
        End Get
        Set(value As Boolean)

        End Set
    End Property

    <Browsable(False)>
    Public Property ColorIconsColor As Color
        Get
            Return Nothing
        End Get
        Set(value As Color)

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

        If blnInverted Then
            e.Graphics.FillRectangle(New SolidBrush(Color.White), 0, 0, Width, Height)
            If bytState = 1 Then
                e.Graphics.FillRectangle(New SolidBrush(Color.FromArgb(15, 0, 0, 0)), 0, 0, Width, Height)
            ElseIf bytState = 2 Then
                e.Graphics.FillRectangle(New SolidBrush(Color.FromArgb(25, 0, 0, 0)), 0, 0, Width, Height)
            End If
            For i As Integer = 0 To intBorderWidth - 1
                e.Graphics.DrawRectangle(New Pen(BackColor), i, i, Width - 1 - i * 2, Height - 1 - i * 2)
            Next
        Else
            e.Graphics.FillRectangle(New SolidBrush(BackColor), 0, 0, Width, Height)
        End If

        'Hover effect
        If Not blnInverted Then
            If bytState = 1 Then
                e.Graphics.FillRectangle(New SolidBrush(Color.FromArgb(50, 0, 0, 0)), 0, 0, Width, Height)
            ElseIf bytState = 2 Then
                e.Graphics.FillRectangle(New SolidBrush(Color.FromArgb(100, 0, 0, 0)), 0, 0, Width, Height)
            End If
        End If


        If Focused And Not blnInverted Then
            For i As Integer = 0 To intBorderWidth - 1
                e.Graphics.DrawRectangle(New Pen(Color.FromArgb(128, 255, 255, 255)), i, i, Width - 1 - i * 2, Height - 1 - i * 2)
            Next
        End If

        If bmpButtonImage IsNot Nothing Then
            If blnScaleIcons Then
                Dim fltScale As Single = Math.Min(Width / bmpButtonImage.Width, Height / bmpButtonImage.Height)
                Dim intWidth As Integer = CInt(bmpButtonImage.Width * fltScale)
                Dim intHeight As Integer = CInt(bmpButtonImage.Height * fltScale)

                e.Graphics.InterpolationMode = Drawing2D.InterpolationMode.Bicubic

                If alImageAlign = ContentAlignment.MiddleLeft Then
                    e.Graphics.DrawImage(bmpButtonImage, Padding.Left, Padding.Top, intWidth - Padding.Right * 2, intHeight - Padding.Bottom * 2)
                ElseIf alImageAlign = ContentAlignment.MiddleCenter
                    e.Graphics.DrawImage(bmpButtonImage, CInt(Width / 2 - intWidth / 2) + Padding.Left, CInt(Height / 2 - intHeight / 2) + Padding.Top, intWidth - Padding.Right * 2, intHeight - Padding.Bottom * 2)
                ElseIf alImageAlign = ContentAlignment.MiddleRight
                    e.Graphics.DrawImage(bmpButtonImage, Width - intWidth + Padding.Left * 2 - Padding.Right, Padding.Top, intWidth - Padding.Right * 2, intHeight - Padding.Bottom * 2)
                End If
            Else
                If alImageAlign = ContentAlignment.MiddleLeft Then
                    e.Graphics.DrawImage(bmpButtonImage, Padding.Left, CInt(Height / 2 - bmpButtonImage.Height / 2), bmpButtonImage.Width, bmpButtonImage.Height)
                ElseIf alImageAlign = ContentAlignment.MiddleCenter
                    e.Graphics.DrawImage(bmpButtonImage, CInt(Width / 2 - bmpButtonImage.Width / 2) + Padding.Left, CInt(Height / 2 - bmpButtonImage.Height / 2) + Padding.Top, bmpButtonImage.Width, bmpButtonImage.Height)
                ElseIf alImageAlign = ContentAlignment.MiddleRight
                    e.Graphics.DrawImage(bmpButtonImage, Width - bmpButtonImage.Width - Padding.Right, CInt(Height / 2 - bmpButtonImage.Height / 2), bmpButtonImage.Width, bmpButtonImage.Height)
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
