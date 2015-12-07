<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form1
    Inherits Form

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
        Me.DyFlatButton1 = New wclDigaly.dyFlatButton()
        Me.DyFlatButton2 = New wclDigaly.dyFlatButton()
        Me.DyTitleBar1 = New wclDigaly.dyTitleBar()
        Me.DyColorPicker1 = New wclDigaly.dyColorPicker()
        Me.DyColorPicker2 = New wclDigaly.dyColorPicker()
        Me.DyTextboxBorder1 = New wclDigaly.dyTextboxBorder()
        Me.DyTextboxBorder2 = New wclDigaly.dyTextboxBorder()
        Me.DyCheckbox1 = New wclDigaly.dyCheckbox()
        Me.SuspendLayout()
        '
        'DyFlatButton1
        '
        Me.DyFlatButton1.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(170, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.DyFlatButton1.BackgroundImage = Nothing
        Me.DyFlatButton1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.DyFlatButton1.BorderWidth = 4
        Me.DyFlatButton1.ButtonImage = Nothing
        Me.DyFlatButton1.ColorIcons = False
        Me.DyFlatButton1.ColorIconsColor = System.Drawing.Color.Empty
        Me.DyFlatButton1.Font = New System.Drawing.Font("Segoe UI", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DyFlatButton1.ForeColor = System.Drawing.Color.White
        Me.DyFlatButton1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.DyFlatButton1.ImagePadding = Nothing
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
        Me.DyFlatButton2.ColorIcons = False
        Me.DyFlatButton2.ColorIconsColor = System.Drawing.Color.Empty
        Me.DyFlatButton2.Font = New System.Drawing.Font("Segoe UI", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DyFlatButton2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(170, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.DyFlatButton2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.DyFlatButton2.ImagePadding = Nothing
        Me.DyFlatButton2.Inverted = True
        Me.DyFlatButton2.Location = New System.Drawing.Point(12, 76)
        Me.DyFlatButton2.Name = "DyFlatButton2"
        Me.DyFlatButton2.ScaleIcons = True
        Me.DyFlatButton2.Size = New System.Drawing.Size(124, 34)
        Me.DyFlatButton2.TabIndex = 2
        Me.DyFlatButton2.Text = "DyFlatButton2"
        '
        'DyTitleBar1
        '
        Me.DyTitleBar1.BackColor = System.Drawing.Color.Green
        Me.DyTitleBar1.Dock = System.Windows.Forms.DockStyle.Top
        Me.DyTitleBar1.Image = Global.wclDigalyTestenv.My.Resources.Resources.doko
        Me.DyTitleBar1.LightTheme = False
        Me.DyTitleBar1.Location = New System.Drawing.Point(0, 0)
        Me.DyTitleBar1.MaximizeButton = True
        Me.DyTitleBar1.MinimizeButton = True
        Me.DyTitleBar1.Name = "DyTitleBar1"
        Me.DyTitleBar1.ShowIcon = False
        Me.DyTitleBar1.Size = New System.Drawing.Size(558, 30)
        Me.DyTitleBar1.TabIndex = 3
        Me.DyTitleBar1.UseCustomIcon = False
        '
        'DyColorPicker1
        '
        Me.DyColorPicker1.BackColor = System.Drawing.Color.White
        Me.DyColorPicker1.BlockSize = 32
        Me.DyColorPicker1.Brightness = 100
        Me.DyColorPicker1.Location = New System.Drawing.Point(31, 129)
        Me.DyColorPicker1.Name = "DyColorPicker1"
        Me.DyColorPicker1.Saturation = 255
        Me.DyColorPicker1.SelectedColor = System.Drawing.Color.Black
        Me.DyColorPicker1.Size = New System.Drawing.Size(483, 112)
        Me.DyColorPicker1.Spacing = 5
        Me.DyColorPicker1.TabIndex = 4
        Me.DyColorPicker1.Text = "DyColorPicker1"
        '
        'DyColorPicker2
        '
        Me.DyColorPicker2.BlockSize = 32
        Me.DyColorPicker2.Brightness = 80
        Me.DyColorPicker2.Location = New System.Drawing.Point(31, 247)
        Me.DyColorPicker2.Name = "DyColorPicker2"
        Me.DyColorPicker2.Saturation = 178
        Me.DyColorPicker2.SelectedColor = System.Drawing.Color.Black
        Me.DyColorPicker2.Size = New System.Drawing.Size(483, 150)
        Me.DyColorPicker2.Spacing = 5
        Me.DyColorPicker2.TabIndex = 26
        Me.DyColorPicker2.Text = "DyColorPicker2"
        '
        'DyTextboxBorder1
        '
        Me.DyTextboxBorder1.BackgroundImage = Nothing
        Me.DyTextboxBorder1.BorderColorTextbox = System.Drawing.Color.CornflowerBlue
        Me.DyTextboxBorder1.BorderWidth = 5
        Me.DyTextboxBorder1.FontTextbox = New System.Drawing.Font("Microsoft Sans Serif", 8.5!)
        Me.DyTextboxBorder1.ForeColorTextbox = System.Drawing.Color.Black
        Me.DyTextboxBorder1.Location = New System.Drawing.Point(211, 76)
        Me.DyTextboxBorder1.MultiLine = False
        Me.DyTextboxBorder1.Name = "DyTextboxBorder1"
        Me.DyTextboxBorder1.Password = False
        Me.DyTextboxBorder1.Size = New System.Drawing.Size(131, 20)
        Me.DyTextboxBorder1.TabIndex = 27
        Me.DyTextboxBorder1.Text = "DyTextboxBorder1"
        '
        'DyTextboxBorder2
        '
        Me.DyTextboxBorder2.BackgroundImage = Nothing
        Me.DyTextboxBorder2.BorderColorTextbox = System.Drawing.Color.CornflowerBlue
        Me.DyTextboxBorder2.BorderWidth = 5
        Me.DyTextboxBorder2.FontTextbox = New System.Drawing.Font("Microsoft Sans Serif", 8.5!)
        Me.DyTextboxBorder2.ForeColorTextbox = System.Drawing.Color.Black
        Me.DyTextboxBorder2.Location = New System.Drawing.Point(211, 103)
        Me.DyTextboxBorder2.MultiLine = False
        Me.DyTextboxBorder2.Name = "DyTextboxBorder2"
        Me.DyTextboxBorder2.Password = True
        Me.DyTextboxBorder2.Size = New System.Drawing.Size(131, 20)
        Me.DyTextboxBorder2.TabIndex = 28
        Me.DyTextboxBorder2.Text = "DyTextboxBorder2"
        '
        'DyCheckbox1
        '
        Me.DyCheckbox1.AutoSize = True
        Me.DyCheckbox1.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DyCheckbox1.ForeColor = System.Drawing.Color.Blue
        Me.DyCheckbox1.Location = New System.Drawing.Point(428, 89)
        Me.DyCheckbox1.Name = "DyCheckbox1"
        Me.DyCheckbox1.Size = New System.Drawing.Size(43, 21)
        Me.DyCheckbox1.TabIndex = 30
        Me.DyCheckbox1.Text = "chi"
        Me.DyCheckbox1.UseVisualStyleBackColor = False
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(558, 409)
        Me.ControlBox = False
        Me.Controls.Add(Me.DyCheckbox1)
        Me.Controls.Add(Me.DyTextboxBorder2)
        Me.Controls.Add(Me.DyTextboxBorder1)
        Me.Controls.Add(Me.DyColorPicker2)
        Me.Controls.Add(Me.DyColorPicker1)
        Me.Controls.Add(Me.DyTitleBar1)
        Me.Controls.Add(Me.DyFlatButton2)
        Me.Controls.Add(Me.DyFlatButton1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximumSize = New System.Drawing.Size(1920, 1040)
        Me.Name = "Form1"
        Me.Text = "wclDigaly Test"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents DyFlatButton1 As wclDigaly.dyFlatButton
    Friend WithEvents DyFlatButton2 As wclDigaly.dyFlatButton
    Friend WithEvents DyTitleBar1 As wclDigaly.dyTitleBar
    Friend WithEvents DyColorPicker1 As wclDigaly.dyColorPicker
    Friend WithEvents DyColorPicker2 As wclDigaly.dyColorPicker
    Friend WithEvents DyTextboxBorder1 As wclDigaly.dyTextboxBorder
    Friend WithEvents DyTextboxBorder2 As wclDigaly.dyTextboxBorder
    Friend WithEvents DyCheckbox1 As wclDigaly.dyCheckbox
End Class
