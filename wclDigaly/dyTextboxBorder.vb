Imports System.ComponentModel

Public Class dyTextboxBorder
    Dim fntTextbox As Font = New Font(FontFamily.GenericSansSerif, 8.5)
    Dim colTextFore As Color = Color.Black
    Dim colTextBorder As Color = Color.CornflowerBlue
    Dim blnMultiline As Boolean = False
    Dim intBorderWidth As Integer = 5

    <Browsable(False)>
    Public Overloads Property BackgroundImage As Bitmap
        Get
            Return Nothing
        End Get
        Set(value As Bitmap)

        End Set
    End Property

    <Browsable(False)>
    Public Overloads Property Font As Font
        Get
            Return Nothing
        End Get
        Set(value As Font)

        End Set
    End Property

    <Browsable(False)>
    Public Overloads Property ForeColor As Color
        Get
            Return Nothing
        End Get
        Set(value As Color)

        End Set
    End Property

    <Browsable(False)>
    Public Overloads Property BackColor As Color
        Get
            Return Nothing
        End Get
        Set(value As Color)

        End Set
    End Property

    Public Property ForeColorTextbox As Color
        Get
            Return colTextFore
        End Get
        Set(value As Color)
            colTextFore = value
            Invalidate()
        End Set
    End Property

    Public Property BorderColorTextbox As Color
        Get
            Return colTextBorder
        End Get
        Set(value As Color)
            colTextBorder = value
            Invalidate()
        End Set
    End Property

    Public Property FontTextbox As Font
        Get
            Return fntTextbox
        End Get
        Set(value As Font)
            fntTextbox = value
            Invalidate()
        End Set
    End Property

    Public Property MultiLine As Boolean
        Get
            Return blnMultiline
        End Get
        Set(value As Boolean)
            blnMultiline = value
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
    Public Overrides Property Text As String
        Get
            Return DyTextbox1.Text
        End Get
        Set(value As String)
            DyTextbox1.Text = value
            Invalidate()
        End Set
    End Property

    Protected Overrides Sub SetBoundsCore(x As Integer, y As Integer, width As Integer, height As Integer, specified As BoundsSpecified)
        ' EDIT: ADD AN EXTRA HEIGHT VALIDATION TO AVOID INITIALIZATION PROBLEMS
        ' BITWISE 'AND' OPERATION: IF ZERO THEN HEIGHT IS NOT INVOLVED IN THIS OPERATION
        If Not blnMultiline Then
            If (specified And BoundsSpecified.Height) = 0 OrElse height = DyTextbox1.Height Then
                MyBase.SetBoundsCore(x, y, width, DyTextbox1.Height, specified)
            Else
                MyBase.SetBoundsCore(x, y, width, height, specified)
                Return
            End If
        Else
            MyBase.SetBoundsCore(x, y, width, height, specified)
        End If
    End Sub

    Private Sub dyTextboxBorder_Paint(sender As Object, e As PaintEventArgs) Handles MyBase.Paint
        DyTextbox1.Font = fntTextbox
        DyTextbox1.ForeColor = colTextFore
        DyTextbox1.BorderColor = colTextBorder

        If blnMultiline Then
            DyTextbox1.Dock = DockStyle.Fill
            DyTextbox1.Multiline = True
        Else
            DyTextbox1.Dock = DockStyle.Top
            DyTextbox1.Multiline = False
        End If

        Panel1.BackColor = DyTextbox1.BorderColor
        Height = DyTextbox1.Height

        TableLayoutPanel1.ColumnStyles(0).Width = intBorderWidth
    End Sub
End Class
