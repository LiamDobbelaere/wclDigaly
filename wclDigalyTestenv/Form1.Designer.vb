<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form1))
        Me.DyTitleBar1 = New wclDigaly.dyTitleBar()
        Me.DyFlatButton1 = New wclDigaly.dyFlatButton()
        Me.DyFlatButton2 = New wclDigaly.dyFlatButton()
        Me.SuspendLayout()
        '
        'DyTitleBar1
        '
        Me.DyTitleBar1.BackColor = System.Drawing.Color.Green
        Me.DyTitleBar1.Dock = System.Windows.Forms.DockStyle.Top
        Me.DyTitleBar1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DyTitleBar1.LightTheme = False
        Me.DyTitleBar1.Location = New System.Drawing.Point(0, 0)
        Me.DyTitleBar1.Name = "DyTitleBar1"
        Me.DyTitleBar1.Size = New System.Drawing.Size(370, 30)
        Me.DyTitleBar1.TabIndex = 0
        Me.DyTitleBar1.Text = "Test"
        '
        'DyFlatButton1
        '
        Me.DyFlatButton1.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(170, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.DyFlatButton1.BackgroundImage = Nothing
        Me.DyFlatButton1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.DyFlatButton1.BorderWidth = 4
        Me.DyFlatButton1.ButtonImage = Nothing
        Me.DyFlatButton1.Font = New System.Drawing.Font("Segoe UI", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DyFlatButton1.ForeColor = System.Drawing.Color.White
        Me.DyFlatButton1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.DyFlatButton1.Inverted = False
        Me.DyFlatButton1.Location = New System.Drawing.Point(12, 36)
        Me.DyFlatButton1.Name = "DyFlatButton1"
        Me.DyFlatButton1.ScaleIcons = True
        Me.DyFlatButton1.Size = New System.Drawing.Size(124, 34)
        Me.DyFlatButton1.TabIndex = 1
        Me.DyFlatButton1.Text = "DyFlatButton1"
        '
        'DyFlatButton2
        '
        Me.DyFlatButton2.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(170, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.DyFlatButton2.BackgroundImage = Nothing
        Me.DyFlatButton2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.DyFlatButton2.BorderWidth = 4
        Me.DyFlatButton2.ButtonImage = Nothing
        Me.DyFlatButton2.Font = New System.Drawing.Font("Segoe UI", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DyFlatButton2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(170, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.DyFlatButton2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.DyFlatButton2.Inverted = True
        Me.DyFlatButton2.Location = New System.Drawing.Point(12, 76)
        Me.DyFlatButton2.Name = "DyFlatButton2"
        Me.DyFlatButton2.ScaleIcons = True
        Me.DyFlatButton2.Size = New System.Drawing.Size(124, 34)
        Me.DyFlatButton2.TabIndex = 2
        Me.DyFlatButton2.Text = "DyFlatButton2"
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.ClientSize = New System.Drawing.Size(370, 273)
        Me.Controls.Add(Me.DyFlatButton2)
        Me.Controls.Add(Me.DyFlatButton1)
        Me.Controls.Add(Me.DyTitleBar1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "Form1"
        Me.Text = "wclDigaly Test"
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents DyTitleBar1 As wclDigaly.dyTitleBar
    Friend WithEvents DyFlatButton1 As wclDigaly.dyFlatButton
    Friend WithEvents DyFlatButton2 As wclDigaly.dyFlatButton
End Class
