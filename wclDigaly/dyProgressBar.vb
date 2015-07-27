Imports System.Drawing.Drawing2D

Public Class dyProgressBar
    Dim dyValue As Byte
    Dim intAnim As Integer
    Dim blnIsMarquee As Boolean = True
    Dim intSizeFactor As Integer = 3

    Property Value As Byte
        Get
            Return dyValue
        End Get
        Set(value As Byte)
            If value > 100 Or value < 0 Then
                Throw New Exception("Progress value must be a value from 0 - 100.")
            End If

            dyValue = value
            Me.Invalidate()
        End Set
    End Property

    Public Property SizeFactor As Integer
        Get
            Return intSizeFactor
        End Get
        Set(value As Integer)
            intSizeFactor = value
            Me.Invalidate()
        End Set
    End Property

    Property Marquee As Boolean
        Get
            Return blnIsMarquee
        End Get
        Set(value As Boolean)
            blnIsMarquee = value
        End Set
    End Property

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        intAnim = 0
        Dim t As Threading.Thread = New Threading.Thread(New Threading.ThreadStart(AddressOf AnimateBar))
        t.Start()
        'AnimateBar()
    End Sub

    Public Sub AnimateBar()
        While True
            intAnim += 1
            Me.Invalidate()
            If intAnim >= Me.Width + CInt(Me.Width / intSizeFactor) Then
                System.Threading.Thread.Sleep(500)
                intAnim = 0
            End If

            System.Threading.Thread.Sleep(5)
        End While
    End Sub

    Protected Overrides Sub OnPaint(ByVal e As System.Windows.Forms.PaintEventArgs)
        MyBase.OnPaint(e)
        MyBase.DoubleBuffered = True

        e.Graphics.SmoothingMode = SmoothingMode.AntiAlias

        Dim c As Color = Color.FromArgb(128, 255, 255, 255)

        'Background
        e.Graphics.FillRectangle(New SolidBrush(BackColor), 0, 0, Me.Width, Me.Height)

        'Progress
        If blnIsMarquee Then
            e.Graphics.FillRectangle(New SolidBrush(ForeColor), CInt(intAnim - (Me.Width / intSizeFactor)), 0, CInt(Me.Width / intSizeFactor), Me.Height)
        Else
            e.Graphics.FillRectangle(New SolidBrush(ForeColor), 0, 0, CInt(Me.Width * (Value / 100)), Me.Height)
        End If



    End Sub

End Class
