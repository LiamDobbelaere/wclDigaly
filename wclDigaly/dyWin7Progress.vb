Imports System.Drawing.Drawing2D

Public Class dyWin7Progress

    Protected intValue As Integer
    Dim intMpos As Integer = 0

    Public Property Value As Integer
        Get
            Return intValue
        End Get
        Set(value As Integer)
            If value > 100 Or value < 0 Then
                Throw New Exception("Value must be between 0 and 100")
            End If

            intValue = value
            Me.Invalidate()
        End Set
    End Property

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        intMpos = 0
        Dim t As Threading.Thread = New Threading.Thread(New Threading.ThreadStart(AddressOf AnimateBar))
        t.Start()
        'AnimateBar()
    End Sub

    Public Sub AnimateBar()
        While True
            intMpos += 1
            Me.Invalidate()
            If intMpos >= Me.Width + (CInt(Me.Width / 8) * 2) Then
                intMpos = 0
            End If

            System.Threading.Thread.Sleep(5)
        End While
    End Sub

    Protected Overrides Sub OnPaint(ByVal e As System.Windows.Forms.PaintEventArgs)
        MyBase.OnPaint(e)
        Me.DoubleBuffered = True

        'e.Graphics.SmoothingMode = Drawing2D.SmoothingMode.AntiAlias

        e.Graphics.DrawLine(Pens.Gray, 1, 0, Me.Width - 2, 0)
        e.Graphics.DrawLine(Pens.Gray, 1, Me.Height - 1, Me.Width - 2, Me.Height - 1)
        e.Graphics.DrawLine(Pens.Gray, 0, 1, 0, Me.Height - 2)
        e.Graphics.DrawLine(Pens.Gray, Me.Width - 1, 1, Me.Width - 1, Me.Height - 2)

        e.Graphics.FillRectangle(New SolidBrush(BackColor), 1, 1, Me.Width - 2, Me.Height - 2)

        e.Graphics.FillRectangle(New SolidBrush(ForeColor), 1, 1, CInt((intValue / 100) * (Me.Width - 2)), Me.Height - 2)

        e.Graphics.FillRectangle(New LinearGradientBrush( _
                 New Point(CInt((Me.Width - 3) / 2), 1), _
                 New Point(CInt((Me.Width - 3) / 2), 9), _
                 Color.White, _
                 Color.Transparent), _
             1, 1, Me.Width - 2, 8)

        e.Graphics.FillRectangle(New LinearGradientBrush( _
                New Point(CInt((Me.Width - 3) / 2), Me.Height - 2 - 9), _
                New Point(CInt((Me.Width - 3) / 2), Me.Height - 1), _
                Color.Transparent, _
                Drawing.Color.FromArgb(128, 255, 255, 255)), _
            1, Me.Height - 2 - 8, Me.Width - 2, 8)

        e.Graphics.FillRectangle(New LinearGradientBrush( _
                         New Point(1, CInt((Me.Height - 2) / 2)), _
                         New Point(21, CInt((Me.Height - 2) / 2)), _
                         Drawing.Color.FromArgb(25, 0, 0, 0), _
                         Color.Transparent), _
                     1, 1, 20, Me.Height - 2)

        e.Graphics.FillRectangle(New LinearGradientBrush( _
                         New Point(Me.Width - 21, CInt((Me.Height - 2) / 2)), _
                         New Point(Me.Width - 1, CInt((Me.Height - 2) / 2)), _
                         Color.Transparent, _
                         Drawing.Color.FromArgb(25, 0, 0, 0)), _
                     Me.Width - 21, 1, 20, Me.Height - 2)

        Dim clipRect As Rectangle = New Rectangle(1, 1, CInt((intValue / 100) * (Me.Width - 2)), Me.Height - 2)
        e.Graphics.SetClip(clipRect)

        'Marquee glow
        Dim r As Rectangle = New Rectangle(New Point(intMpos - (CInt(Me.Width / 8) * 2), 0), New Size(CInt(Me.Width / 8), Me.Height - 2))
        Dim r2 As Rectangle = New Rectangle(New Point(intMpos - CInt(Me.Width / 8), 0), New Size(CInt(Me.Width / 8), Me.Height - 2))

        e.Graphics.FillRectangle(New LinearGradientBrush(r, Color.Transparent, Drawing.Color.FromArgb(124, 255, 255, 255), 0), intMpos - (CInt(Me.Width / 8) * 2), 1, CInt(Me.Width / 8), Me.Height - 2)
        e.Graphics.FillRectangle(New LinearGradientBrush(r, Drawing.Color.FromArgb(124, 255, 255, 255), Color.Transparent, 0), intMpos - CInt(Me.Width / 8), 1, CInt(Me.Width / 8), Me.Height - 2)
    End Sub

End Class
