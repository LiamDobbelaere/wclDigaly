Public Class dyColorPicker
    'Dim lstSelections As List(Of dyFlatButton) = New List(Of dyFlatButton)
    Dim intBlockSize As Integer = 32
    Dim intSpacing As Integer = 5
    Dim dblBrightness As Double = 0.35
    Dim dblSaturation As Double = 0.7
    Dim colSelectedColor As Color = Color.Black
    Dim colorTable As List(Of ColorTableEntry) = New List(Of ColorTableEntry)
    Private intHoverColor As Integer = -1
    Private intSelectedColor As Integer = -1
    Public Event SelectedColorChanged()

    Public Property BlockSize As Integer
        Get
            Return intBlockSize
        End Get
        Set(value As Integer)
            intBlockSize = value
            Recalculate()
        End Set
    End Property

    Public Property Spacing As Integer
        Get
            Return intSpacing
        End Get
        Set(value As Integer)
            intSpacing = value
            Recalculate()
        End Set
    End Property

    Public Property Brightness As Integer
        Get
            Return dblBrightness * 255
        End Get
        Set(value As Integer)
            dblBrightness = value / 255
            Recalculate()
        End Set
    End Property

    Public Property Saturation As Integer
        Get
            Return dblSaturation * 255
        End Get
        Set(value As Integer)
            dblSaturation = value / 255
            Recalculate()
        End Set
    End Property

    Public Property SelectedColor As Color
        Get
            Return colSelectedColor
        End Get
        Set(value As Color)
            colSelectedColor = value
        End Set
    End Property

    Structure ColorTableEntry
        Dim Color As Color
        Dim Location As Point
    End Structure

    Public Sub New()
        ' This call is required by the designer.
        InitializeComponent()
        DoubleBuffered = True
        ' Add any initialization after the InitializeComponent() call.
        Recalculate()
    End Sub

    Sub Recalculate()
        Dim intBlocksX As Integer = CInt(Math.Floor(Me.Width / (intBlockSize + intSpacing)))
        Dim intBlocksY As Integer = CInt(Math.Floor(Me.Height / (intBlockSize + intSpacing)))
        Dim intCount As Integer = 0

        colorTable.Clear()
        For y As Integer = 1 To intBlocksY
            For x As Integer = 1 To intBlocksX
                Dim tableEntry As ColorTableEntry = New ColorTableEntry()


                tableEntry.Location = New Point((x - 1) * (intBlockSize + intSpacing) + intSpacing, (y - 1) * (intBlockSize + intSpacing) + intSpacing)
                tableEntry.Color = FromAhsb(255, intCount * (360 / (intBlocksX * intBlocksY)), dblSaturation, dblBrightness)

                colorTable.Add(tableEntry)

                intCount += 1
            Next
        Next

        Invalidate()
    End Sub

    Protected Overrides Sub OnPaint(ByVal e As System.Windows.Forms.PaintEventArgs)
        MyBase.OnPaint(e)

        Dim p As Pen = New Pen(BackColor)
        p.Width = 2

        For i As Integer = 0 To colorTable.Count - 1
            e.Graphics.FillRectangle(New SolidBrush(colorTable(i).Color), New Rectangle(colorTable(i).Location.X, colorTable(i).Location.Y, intBlockSize, intBlockSize))

            If i = intSelectedColor Then
                e.Graphics.DrawRectangle(p, New Rectangle(colorTable(i).Location.X + p.Width * 2, colorTable(i).Location.Y + p.Width * 2, intBlockSize - p.Width * 4, intBlockSize - p.Width * 4))
            End If

            If i = intHoverColor Then
                e.Graphics.FillRectangle(New SolidBrush(Color.FromArgb(50, 0, 0, 0)), New Rectangle(colorTable(i).Location.X, colorTable(i).Location.Y, intBlockSize, intBlockSize))
            End If
        Next

        'Add your custom paint code here
    End Sub

    Protected Overrides Sub OnResize(e As EventArgs)
        Recalculate()
        MyBase.OnResize(e)
    End Sub

    Protected Overrides Sub OnMouseClick(e As MouseEventArgs)
        MyBase.OnMouseClick(e)

        Dim blocksPerRow As Integer = CInt(Math.Floor(Me.Width / (intBlockSize + intSpacing)))
        For i As Integer = 0 To colorTable.Count - 1
            If e.X >= colorTable(i).Location.X And e.X < colorTable(i).Location.X + intBlockSize And e.Y >= colorTable(i).Location.Y And e.Y <= colorTable(i).Location.Y + intBlockSize Then
                intSelectedColor = i
                SelectedColor = colorTable(i).Color
                RaiseEvent SelectedColorChanged()
                Invalidate()
                Return
            End If
        Next
    End Sub

    Protected Overrides Sub OnMouseLeave(e As EventArgs)
        MyBase.OnMouseLeave(e)

        intHoverColor = -1
        Invalidate()
    End Sub

    Protected Overrides Sub OnMouseMove(e As MouseEventArgs)
        MyBase.OnMouseMove(e)

        intHoverColor = -1

        Dim blocksPerRow As Integer = CInt(Math.Floor(Me.Width / (intBlockSize + intSpacing)))
        For i As Integer = 0 To colorTable.Count - 1
            If e.X >= colorTable(i).Location.X And e.X < colorTable(i).Location.X + intBlockSize And e.Y >= colorTable(i).Location.Y And e.Y <= colorTable(i).Location.Y + intBlockSize Then
                intHoverColor = i
                Invalidate()
                Return
            End If
        Next

        Invalidate()
    End Sub

End Class
