Imports System.Runtime.InteropServices

Public Class dyTextbox
    Public Const WM_NCPAINT As Integer = &H85
    Dim colBorder As Color = Color.CornflowerBlue

    <Flags()>
    Private Enum RedrawWindowFlags As UInteger
        Invalidate = &H1
        InternalPaint = &H2
        [Erase] = &H4
        Validate = &H8
        NoInternalPaint = &H10
        NoErase = &H20
        NoChildren = &H40
        AllChildren = &H80
        UpdateNow = &H100
        EraseNow = &H200
        Frame = &H400
        NoFrame = &H800
    End Enum

    <DllImport("User32.dll")>
    Public Shared Function GetWindowDC(ByVal hWnd As IntPtr) As IntPtr
    End Function

    <DllImport("user32.dll")>
    Private Shared Function ReleaseDC(ByVal hWnd As IntPtr, ByVal hDC As IntPtr) As Boolean
    End Function

    <DllImport("user32.dll")>
    Private Shared Function RedrawWindow(hWnd As IntPtr, lprcUpdate As IntPtr, hrgnUpdate As IntPtr, flags As RedrawWindowFlags) As Boolean
    End Function

    Public Sub New()
        BorderStyle = BorderStyle.Fixed3D
        Me.DoubleBuffered = True
    End Sub

    Protected Overrides Sub OnResize(e As System.EventArgs)
        MyBase.OnResize(e)
        RedrawWindow(Handle, IntPtr.Zero, IntPtr.Zero, RedrawWindowFlags.Frame Or RedrawWindowFlags.UpdateNow Or RedrawWindowFlags.Invalidate)
    End Sub

    Public Property BorderColor As Color
        Get
            Return colBorder
        End Get
        Set(value As Color)
            colBorder = value
        End Set
    End Property

    Protected Overrides Sub WndProc(ByRef m As Message)

        If m.Msg = WM_NCPAINT Then
            Dim hDC As IntPtr = GetWindowDC(m.HWnd)
            Using g As Graphics = Graphics.FromHdc(hDC)
                If Focused Then
                    g.DrawRectangle(New Pen(colBorder, 1), New Rectangle(0, 0, Width - 1, Height - 1))
                Else
                    g.DrawRectangle(Pens.LightGray, New Rectangle(-1, 0, Width, Height - 1))
                End If
                g.DrawRectangle(SystemPens.Window, New Rectangle(1, 1, Width - 3, Height - 3))
            End Using
            ReleaseDC(m.HWnd, hDC)
        End If

        MyBase.WndProc(m)

    End Sub


End Class
