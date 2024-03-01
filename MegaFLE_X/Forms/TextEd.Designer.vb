<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> Partial Class TextEd
#Region "Windows Form Designer generated code "
	<System.Diagnostics.DebuggerNonUserCode()> Public Sub New()
		MyBase.New()
        'This call is required by the Windows Form Designer.
        InitializeComponent()
        Form_Initialize()
    End Sub
	'Form overrides dispose to clean up the component list.
	<System.Diagnostics.DebuggerNonUserCode()> Protected Overloads Overrides Sub Dispose(ByVal Disposing As Boolean)
		If Disposing Then
			If Not components Is Nothing Then
				components.Dispose()
			End If
		End If
		MyBase.Dispose(Disposing)
	End Sub
	'Required by the Windows Form Designer
	Private components As System.ComponentModel.IContainer
	Public ToolTip1 As System.Windows.Forms.ToolTip
	Public WithEvents _LnNT_3 As System.Windows.Forms.TextBox
	Public WithEvents _LnNT_2 As System.Windows.Forms.TextBox
	Public WithEvents _LnNT_1 As System.Windows.Forms.TextBox
	Public WithEvents _LnNT_0 As System.Windows.Forms.TextBox
	Public WithEvents Label2 As System.Windows.Forms.Label
	Public WithEvents Frame2 As System.Windows.Forms.GroupBox
    Public WithEvents PageUD As System.Windows.Forms.NumericUpDown
    Public WithEvents CurTextCombo As System.Windows.Forms.ComboBox
	Public WithEvents MaxPage As System.Windows.Forms.Label
	Public WithEvents Frame1 As System.Windows.Forms.GroupBox
	Public WithEvents Line3TB As System.Windows.Forms.TextBox
	Public WithEvents Line2TB As System.Windows.Forms.TextBox
	Public WithEvents UpdText As System.Windows.Forms.Button
	Public WithEvents Line1TB As System.Windows.Forms.TextBox
	Public WithEvents Line4TB As System.Windows.Forms.TextBox
	Public WithEvents Ln4 As System.Windows.Forms.Label
	Public WithEvents Ln2 As System.Windows.Forms.Label
	Public WithEvents Ln3 As System.Windows.Forms.Label
	Public WithEvents Ln1 As System.Windows.Forms.Label
    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(TextEd))
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me._LnNT_3 = New System.Windows.Forms.TextBox()
        Me._LnNT_2 = New System.Windows.Forms.TextBox()
        Me._LnNT_1 = New System.Windows.Forms.TextBox()
        Me._LnNT_0 = New System.Windows.Forms.TextBox()
        Me.PageUD = New System.Windows.Forms.NumericUpDown()
        Me.Frame2 = New System.Windows.Forms.GroupBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Frame1 = New System.Windows.Forms.GroupBox()
        Me.CurTextCombo = New System.Windows.Forms.ComboBox()
        Me.MaxPage = New System.Windows.Forms.Label()
        Me.Line3TB = New System.Windows.Forms.TextBox()
        Me.Line2TB = New System.Windows.Forms.TextBox()
        Me.UpdText = New System.Windows.Forms.Button()
        Me.Line1TB = New System.Windows.Forms.TextBox()
        Me.Line4TB = New System.Windows.Forms.TextBox()
        Me.Ln4 = New System.Windows.Forms.Label()
        Me.Ln2 = New System.Windows.Forms.Label()
        Me.Ln3 = New System.Windows.Forms.Label()
        Me.Ln1 = New System.Windows.Forms.Label()
        CType(Me.PageUD, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Frame2.SuspendLayout()
        Me.Frame1.SuspendLayout()
        Me.SuspendLayout()
        '
        '_LnNT_3
        '
        Me._LnNT_3.AcceptsReturn = True
        Me._LnNT_3.BackColor = System.Drawing.SystemColors.Window
        Me._LnNT_3.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._LnNT_3.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._LnNT_3.ForeColor = System.Drawing.SystemColors.WindowText
        Me._LnNT_3.Location = New System.Drawing.Point(136, 40)
        Me._LnNT_3.MaxLength = 4
        Me._LnNT_3.Name = "_LnNT_3"
        Me._LnNT_3.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._LnNT_3.Size = New System.Drawing.Size(33, 23)
        Me._LnNT_3.TabIndex = 17
        Me.ToolTip1.SetToolTip(Me._LnNT_3, "Position on screen for line 4 text")
        '
        '_LnNT_2
        '
        Me._LnNT_2.AcceptsReturn = True
        Me._LnNT_2.BackColor = System.Drawing.SystemColors.Window
        Me._LnNT_2.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._LnNT_2.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._LnNT_2.ForeColor = System.Drawing.SystemColors.WindowText
        Me._LnNT_2.Location = New System.Drawing.Point(136, 16)
        Me._LnNT_2.MaxLength = 4
        Me._LnNT_2.Name = "_LnNT_2"
        Me._LnNT_2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._LnNT_2.Size = New System.Drawing.Size(33, 23)
        Me._LnNT_2.TabIndex = 16
        Me.ToolTip1.SetToolTip(Me._LnNT_2, "Position on screen for line 3 text")
        '
        '_LnNT_1
        '
        Me._LnNT_1.AcceptsReturn = True
        Me._LnNT_1.BackColor = System.Drawing.SystemColors.Window
        Me._LnNT_1.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._LnNT_1.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._LnNT_1.ForeColor = System.Drawing.SystemColors.WindowText
        Me._LnNT_1.Location = New System.Drawing.Point(48, 40)
        Me._LnNT_1.MaxLength = 4
        Me._LnNT_1.Name = "_LnNT_1"
        Me._LnNT_1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._LnNT_1.Size = New System.Drawing.Size(33, 23)
        Me._LnNT_1.TabIndex = 15
        Me.ToolTip1.SetToolTip(Me._LnNT_1, "Position on screen for line 2 text")
        '
        '_LnNT_0
        '
        Me._LnNT_0.AcceptsReturn = True
        Me._LnNT_0.BackColor = System.Drawing.SystemColors.Window
        Me._LnNT_0.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._LnNT_0.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._LnNT_0.ForeColor = System.Drawing.SystemColors.WindowText
        Me._LnNT_0.Location = New System.Drawing.Point(48, 16)
        Me._LnNT_0.MaxLength = 4
        Me._LnNT_0.Name = "_LnNT_0"
        Me._LnNT_0.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._LnNT_0.Size = New System.Drawing.Size(33, 23)
        Me._LnNT_0.TabIndex = 13
        Me.ToolTip1.SetToolTip(Me._LnNT_0, "Position on screen for Line 1 text")
        '
        'PageUD
        '
        Me.PageUD.Location = New System.Drawing.Point(41, 16)
        Me.PageUD.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.PageUD.Name = "PageUD"
        Me.PageUD.ReadOnly = True
        Me.PageUD.Size = New System.Drawing.Size(45, 23)
        Me.PageUD.TabIndex = 10
        Me.ToolTip1.SetToolTip(Me.PageUD, "Current Page Number of Selected Text String")
        Me.PageUD.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'Frame2
        '
        Me.Frame2.BackColor = System.Drawing.SystemColors.Control
        Me.Frame2.Controls.Add(Me._LnNT_3)
        Me.Frame2.Controls.Add(Me._LnNT_1)
        Me.Frame2.Controls.Add(Me.Label4)
        Me.Frame2.Controls.Add(Me.Label3)
        Me.Frame2.Controls.Add(Me._LnNT_2)
        Me.Frame2.Controls.Add(Me.Label1)
        Me.Frame2.Controls.Add(Me._LnNT_0)
        Me.Frame2.Controls.Add(Me.Label2)
        Me.Frame2.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Frame2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Frame2.Location = New System.Drawing.Point(144, 8)
        Me.Frame2.Name = "Frame2"
        Me.Frame2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Frame2.Size = New System.Drawing.Size(193, 73)
        Me.Frame2.TabIndex = 12
        Me.Frame2.TabStop = False
        Me.Frame2.Text = "Nametable Location"
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.SystemColors.Control
        Me.Label4.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label4.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label4.Location = New System.Drawing.Point(96, 40)
        Me.Label4.Name = "Label4"
        Me.Label4.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label4.Size = New System.Drawing.Size(53, 21)
        Me.Label4.TabIndex = 22
        Me.Label4.Text = "Line 4:"
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.SystemColors.Control
        Me.Label3.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label3.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label3.Location = New System.Drawing.Point(8, 40)
        Me.Label3.Name = "Label3"
        Me.Label3.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label3.Size = New System.Drawing.Size(53, 21)
        Me.Label3.TabIndex = 21
        Me.Label3.Text = "Line 3:"
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.SystemColors.Control
        Me.Label1.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label1.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label1.Location = New System.Drawing.Point(96, 16)
        Me.Label1.Name = "Label1"
        Me.Label1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label1.Size = New System.Drawing.Size(53, 21)
        Me.Label1.TabIndex = 20
        Me.Label1.Text = "Line 2:"
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.SystemColors.Control
        Me.Label2.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label2.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label2.Location = New System.Drawing.Point(8, 16)
        Me.Label2.Name = "Label2"
        Me.Label2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label2.Size = New System.Drawing.Size(53, 21)
        Me.Label2.TabIndex = 14
        Me.Label2.Text = "Line 1:"
        '
        'Frame1
        '
        Me.Frame1.BackColor = System.Drawing.SystemColors.Control
        Me.Frame1.Controls.Add(Me.PageUD)
        Me.Frame1.Controls.Add(Me.CurTextCombo)
        Me.Frame1.Controls.Add(Me.MaxPage)
        Me.Frame1.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Frame1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Frame1.Location = New System.Drawing.Point(8, 8)
        Me.Frame1.Name = "Frame1"
        Me.Frame1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Frame1.Size = New System.Drawing.Size(129, 73)
        Me.Frame1.TabIndex = 7
        Me.Frame1.TabStop = False
        Me.Frame1.Text = "Text Selection"
        '
        'CurTextCombo
        '
        Me.CurTextCombo.BackColor = System.Drawing.SystemColors.Window
        Me.CurTextCombo.Cursor = System.Windows.Forms.Cursors.Default
        Me.CurTextCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CurTextCombo.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CurTextCombo.ForeColor = System.Drawing.SystemColors.WindowText
        Me.CurTextCombo.Location = New System.Drawing.Point(8, 40)
        Me.CurTextCombo.Name = "CurTextCombo"
        Me.CurTextCombo.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.CurTextCombo.Size = New System.Drawing.Size(113, 24)
        Me.CurTextCombo.TabIndex = 8
        '
        'MaxPage
        '
        Me.MaxPage.BackColor = System.Drawing.SystemColors.Control
        Me.MaxPage.Cursor = System.Windows.Forms.Cursors.Default
        Me.MaxPage.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MaxPage.ForeColor = System.Drawing.SystemColors.ControlText
        Me.MaxPage.Location = New System.Drawing.Point(8, 16)
        Me.MaxPage.Name = "MaxPage"
        Me.MaxPage.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.MaxPage.Size = New System.Drawing.Size(113, 17)
        Me.MaxPage.TabIndex = 9
        Me.MaxPage.Text = "Page:                 Of"
        '
        'Line3TB
        '
        Me.Line3TB.AcceptsReturn = True
        Me.Line3TB.BackColor = System.Drawing.SystemColors.Window
        Me.Line3TB.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.Line3TB.Enabled = False
        Me.Line3TB.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Line3TB.ForeColor = System.Drawing.SystemColors.WindowText
        Me.Line3TB.Location = New System.Drawing.Point(56, 136)
        Me.Line3TB.MaxLength = 31
        Me.Line3TB.Name = "Line3TB"
        Me.Line3TB.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Line3TB.Size = New System.Drawing.Size(201, 23)
        Me.Line3TB.TabIndex = 5
        '
        'Line2TB
        '
        Me.Line2TB.AcceptsReturn = True
        Me.Line2TB.BackColor = System.Drawing.SystemColors.Window
        Me.Line2TB.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.Line2TB.Enabled = False
        Me.Line2TB.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Line2TB.ForeColor = System.Drawing.SystemColors.WindowText
        Me.Line2TB.Location = New System.Drawing.Point(56, 112)
        Me.Line2TB.MaxLength = 31
        Me.Line2TB.Name = "Line2TB"
        Me.Line2TB.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Line2TB.Size = New System.Drawing.Size(201, 23)
        Me.Line2TB.TabIndex = 3
        '
        'UpdText
        '
        Me.UpdText.BackColor = System.Drawing.SystemColors.Control
        Me.UpdText.Cursor = System.Windows.Forms.Cursors.Default
        Me.UpdText.Enabled = False
        Me.UpdText.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.UpdText.ForeColor = System.Drawing.SystemColors.ControlText
        Me.UpdText.Location = New System.Drawing.Point(112, 183)
        Me.UpdText.Name = "UpdText"
        Me.UpdText.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.UpdText.Size = New System.Drawing.Size(81, 26)
        Me.UpdText.TabIndex = 1
        Me.UpdText.Text = "Update Text"
        Me.UpdText.UseVisualStyleBackColor = False
        '
        'Line1TB
        '
        Me.Line1TB.AcceptsReturn = True
        Me.Line1TB.BackColor = System.Drawing.SystemColors.Window
        Me.Line1TB.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.Line1TB.Enabled = False
        Me.Line1TB.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Line1TB.ForeColor = System.Drawing.SystemColors.WindowText
        Me.Line1TB.Location = New System.Drawing.Point(56, 88)
        Me.Line1TB.MaxLength = 31
        Me.Line1TB.Name = "Line1TB"
        Me.Line1TB.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Line1TB.Size = New System.Drawing.Size(201, 23)
        Me.Line1TB.TabIndex = 0
        '
        'Line4TB
        '
        Me.Line4TB.AcceptsReturn = True
        Me.Line4TB.BackColor = System.Drawing.SystemColors.Window
        Me.Line4TB.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.Line4TB.Enabled = False
        Me.Line4TB.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Line4TB.ForeColor = System.Drawing.SystemColors.WindowText
        Me.Line4TB.Location = New System.Drawing.Point(56, 160)
        Me.Line4TB.MaxLength = 31
        Me.Line4TB.Name = "Line4TB"
        Me.Line4TB.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Line4TB.Size = New System.Drawing.Size(201, 23)
        Me.Line4TB.TabIndex = 6
        '
        'Ln4
        '
        Me.Ln4.BackColor = System.Drawing.SystemColors.Control
        Me.Ln4.Cursor = System.Windows.Forms.Cursors.Default
        Me.Ln4.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Ln4.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Ln4.Location = New System.Drawing.Point(16, 160)
        Me.Ln4.Name = "Ln4"
        Me.Ln4.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Ln4.Size = New System.Drawing.Size(38, 17)
        Me.Ln4.TabIndex = 19
        Me.Ln4.Text = "Line 4:"
        '
        'Ln2
        '
        Me.Ln2.BackColor = System.Drawing.SystemColors.Control
        Me.Ln2.Cursor = System.Windows.Forms.Cursors.Default
        Me.Ln2.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Ln2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Ln2.Location = New System.Drawing.Point(16, 112)
        Me.Ln2.Name = "Ln2"
        Me.Ln2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Ln2.Size = New System.Drawing.Size(38, 17)
        Me.Ln2.TabIndex = 18
        Me.Ln2.Text = "Line 2:"
        '
        'Ln3
        '
        Me.Ln3.BackColor = System.Drawing.SystemColors.Control
        Me.Ln3.Cursor = System.Windows.Forms.Cursors.Default
        Me.Ln3.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Ln3.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Ln3.Location = New System.Drawing.Point(16, 136)
        Me.Ln3.Name = "Ln3"
        Me.Ln3.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Ln3.Size = New System.Drawing.Size(38, 17)
        Me.Ln3.TabIndex = 4
        Me.Ln3.Text = "Line 3:"
        '
        'Ln1
        '
        Me.Ln1.BackColor = System.Drawing.SystemColors.Control
        Me.Ln1.Cursor = System.Windows.Forms.Cursors.Default
        Me.Ln1.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Ln1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Ln1.Location = New System.Drawing.Point(16, 88)
        Me.Ln1.Name = "Ln1"
        Me.Ln1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Ln1.Size = New System.Drawing.Size(38, 17)
        Me.Ln1.TabIndex = 2
        Me.Ln1.Text = "Line 1:"
        '
        'TextEd
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.ClientSize = New System.Drawing.Size(355, 213)
        Me.Controls.Add(Me.Frame2)
        Me.Controls.Add(Me.Frame1)
        Me.Controls.Add(Me.Line3TB)
        Me.Controls.Add(Me.Line2TB)
        Me.Controls.Add(Me.UpdText)
        Me.Controls.Add(Me.Line1TB)
        Me.Controls.Add(Me.Line4TB)
        Me.Controls.Add(Me.Ln4)
        Me.Controls.Add(Me.Ln2)
        Me.Controls.Add(Me.Ln3)
        Me.Controls.Add(Me.Ln1)
        Me.Cursor = System.Windows.Forms.Cursors.Default
        Me.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.Location = New System.Drawing.Point(3, 29)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "TextEd"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Text = "Text Editor"
        CType(Me.PageUD, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Frame2.ResumeLayout(False)
        Me.Frame2.PerformLayout()
        Me.Frame1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Public WithEvents Label1 As Label
    Public WithEvents Label4 As Label
    Public WithEvents Label3 As Label
#End Region
End Class