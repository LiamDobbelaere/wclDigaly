Imports System.ComponentModel

'<ToolboxItem(False)>
Public Class dyTitlebarButton
    Public Enum ButtonMode
        Cross
        Minimize
        Maximize
    End Enum

    Private MaxHoverColor As Color = Color.FromArgb(231, 231, 231)
    Private HoverColor As Color = Color.FromArgb(224, 67, 67)
    Private MaxClickColor As Color = Color.FromArgb(78, 166, 234)
    Private ClickColor As Color = Color.FromArgb(153, 61, 61)
    Private State As Byte = 0
    Private bmButtonType As ButtonMode = ButtonMode.Cross
    Private useLightTheme As Boolean = True

    Public Property ButtonType As ButtonMode
        Get
            Return bmButtonType
        End Get
        Set(value As ButtonMode)
            bmButtonType = value
            Invalidate()
        End Set
    End Property

    Public Property LightTheme As Boolean
        Get
            Return useLightTheme
        End Get
        Set(value As Boolean)
            useLightTheme = value
        End Set
    End Property

    Public Sub New()
        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        Me.Width = 45
        Me.Height = 30
    End Sub

    Protected Overrides Sub OnPaint(ByVal e As System.Windows.Forms.PaintEventArgs)
        MyBase.OnPaint(e)

        Dim p As Pen
        If useLightTheme Then
            If State > 0 Then
                If bmButtonType = ButtonMode.Maximize Or bmButtonType = ButtonMode.Minimize Then
                    If State = 1 Then
                        p = New Pen(Color.FromArgb(51, 51, 51), 1)
                    Else
                        p = New Pen(Color.White, 1)
                    End If
                Else
                    p = New Pen(Color.White, 1)
                End If
            Else
                If bmButtonType = ButtonMode.Maximize Or bmButtonType = ButtonMode.Minimize Then
                    p = New Pen(Color.FromArgb(204, 204, 204), 1)
                Else
                    p = New Pen(Color.FromArgb(204, 204, 204), 1)
                End If
            End If
        Else
            If State > 0 Then
                If bmButtonType = ButtonMode.Maximize Or bmButtonType = ButtonMode.Minimize Then
                    If State = 1 Then
                        p = New Pen(Color.White, 1)
                    Else
                        p = New Pen(Color.White, 1)
                    End If
                Else
                    p = New Pen(Color.White, 1)
                End If
            Else
                If bmButtonType = ButtonMode.Maximize Or bmButtonType = ButtonMode.Minimize Then
                    p = New Pen(Color.White, 1)
                Else
                    p = New Pen(Color.White, 1)
                End If
            End If
        End If

        Dim ins As Integer = 10

        e.Graphics.SmoothingMode = Drawing2D.SmoothingMode.None

        If useLightTheme Then
            If State = 1 Then
                If bmButtonType = ButtonMode.Maximize Or bmButtonType = ButtonMode.Minimize Then
                    e.Graphics.FillRectangle(New SolidBrush(MaxHoverColor), e.Graphics.ClipBounds)
                Else
                    e.Graphics.FillRectangle(New SolidBrush(HoverColor), e.Graphics.ClipBounds)
                End If
            ElseIf State = 2 Then
                If bmButtonType = ButtonMode.Maximize Or bmButtonType = ButtonMode.Minimize Then
                    e.Graphics.FillRectangle(New SolidBrush(MaxClickColor), e.Graphics.ClipBounds)
                Else
                    e.Graphics.FillRectangle(New SolidBrush(ClickColor), e.Graphics.ClipBounds)
                End If
            Else
                e.Graphics.FillRectangle(Brushes.White, e.Graphics.ClipBounds)
            End If
        Else
            e.Graphics.FillRectangle(New SolidBrush(BackColor), e.Graphics.ClipBounds)
            If State = 1 Then
                e.Graphics.FillRectangle(New SolidBrush(Color.FromArgb(50, 0, 0, 0)), e.Graphics.ClipBounds)
            ElseIf State = 2 Then
                e.Graphics.FillRectangle(New SolidBrush(Color.FromArgb(100, 0, 0, 0)), e.Graphics.ClipBounds)
            End If
        End If


        If bmButtonType = ButtonMode.Cross Then
            e.Graphics.SmoothingMode = Drawing2D.SmoothingMode.AntiAlias
            e.Graphics.DrawLine(p, 17, 9, 26, 18)
            e.Graphics.DrawLine(p, 17, 18, 26, 9)
        ElseIf bmButtonType = ButtonMode.Maximize
            e.Graphics.DrawRectangle(p, 17, 9, 9, 9)
            'e.Graphics.FillRectangle(New SolidBrush(p.Color), ins, ins, ins, 3)
        ElseIf bmButtonType = ButtonMode.Minimize
            e.Graphics.DrawLine(p, 18, 14, 27, 14)
        End If
    End Sub

    Protected Overrides Sub OnMouseClick(e As MouseEventArgs)
        MyBase.OnMouseClick(e)

        If bmButtonType = ButtonMode.Cross Then
            Me.FindForm().Close()
        ElseIf bmButtonType = ButtonMode.Maximize Then
            If Me.FindForm().WindowState = FormWindowState.Normal Then
                Me.FindForm().WindowState = FormWindowState.Maximized
            Else
                Me.FindForm().WindowState = FormWindowState.Normal
            End If
        ElseIf bmButtonType = ButtonMode.Minimize Then
            Me.FindForm().WindowState = FormWindowState.Minimized
        End If
    End Sub

    Protected Overrides Sub OnRegionChanged(e As EventArgs)
        MyBase.OnRegionChanged(e)
        Invalidate()
    End Sub

    Protected Overrides Sub OnMouseEnter(e As EventArgs)
        MyBase.OnMouseEnter(e)
        State = 1
        Invalidate()
    End Sub

    Protected Overrides Sub OnMouseLeave(e As EventArgs)
        MyBase.OnMouseEnter(e)
        State = 0
        Invalidate()
    End Sub

    Protected Overrides Sub OnMouseDown(e As MouseEventArgs)
        MyBase.OnMouseDown(e)
        State = 2
        Invalidate()
    End Sub

    Protected Overrides Sub OnMouseUp(e As MouseEventArgs)
        MyBase.OnMouseUp(e)
        State = 1
        Invalidate()
    End Sub
End Class
