Public Class dyColorPicker
    'Dim lstSelections As List(Of dyFlatButton) = New List(Of dyFlatButton)
    Dim intBlockSize As Integer = 32
    Dim intSpacing As Integer = 5
    Dim dblBrightness As Double = 0.35
    Dim dblSaturation As Double = 0.7
    Dim colSelectedColor As Color = Color.Black
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


    Public Sub New()
        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        Recalculate()
    End Sub

    Sub Recalculate()
        Dim intBlocksX As Integer = CInt(Math.Floor(Me.Width / (intBlockSize + intSpacing)))
        Dim intBlocksY As Integer = CInt(Math.Floor(Me.Height / (intBlockSize + intSpacing)))
        Dim intCount As Integer = 0

        Me.Controls.Clear()

        For y As Integer = 1 To intBlocksY
            For x As Integer = 1 To intBlocksX
                Dim newBlock As dyFlatButton = New dyFlatButton()
                newBlock.Width = intBlockSize
                newBlock.Height = intBlockSize
                newBlock.Location = New Point((x - 1) * (intBlockSize + intSpacing) + intSpacing, (y - 1) * (intBlockSize + intSpacing) + intSpacing)

                Dim c As Color = FromAhsb(255, intCount * (360 / (intBlocksX * intBlocksY)), dblSaturation, dblBrightness)
                newBlock.BackColor = c
                newBlock.BorderWidth = 0

                AddHandler newBlock.Click, AddressOf OnColorSelect

                Me.Controls.Add(newBlock)

                intCount += 1
            Next
        Next
    End Sub

    Sub OnColorSelect(sender As Object, e As EventArgs)
        Dim but As dyFlatButton = Convert.ChangeType(sender, GetType(dyFlatButton))

        SelectedColor = but.BackColor
        RaiseEvent SelectedColorChanged()
    End Sub

    Protected Overrides Sub OnPaint(ByVal e As System.Windows.Forms.PaintEventArgs)
        MyBase.OnPaint(e)

        'Add your custom paint code here
    End Sub

    Protected Overrides Sub OnResize(e As EventArgs)
        Recalculate()
        MyBase.OnResize(e)
    End Sub

End Class
