<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> Partial Class ScreenEd
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
	Public WithEvents Label12 As System.Windows.Forms.Label
	Public WithEvents Gem3hideframe As System.Windows.Forms.Panel
	Public WithEvents Text6 As System.Windows.Forms.TextBox
	Public WithEvents UpDown3 As System.Windows.Forms.NumericUpDown
    Public WithEvents Check1 As System.Windows.Forms.CheckBox
    Public WithEvents UpDown2 As System.Windows.Forms.NumericUpDown
    Public WithEvents Option2 As System.Windows.Forms.RadioButton
    Public WithEvents Option1 As System.Windows.Forms.RadioButton
    Public WithEvents UpDown1 As System.Windows.Forms.NumericUpDown
    Public WithEvents List1 As System.Windows.Forms.ListBox
    Public WithEvents Text2 As System.Windows.Forms.TextBox
	Public WithEvents Text1 As System.Windows.Forms.TextBox
	Public WithEvents Label11 As System.Windows.Forms.Label
	Public WithEvents Label10 As System.Windows.Forms.Label
	Public WithEvents Label9 As System.Windows.Forms.Label
	Public WithEvents Label8 As System.Windows.Forms.Label
	Public WithEvents Label7 As System.Windows.Forms.Label
	Public WithEvents Label6 As System.Windows.Forms.Label
	Public WithEvents Label5 As System.Windows.Forms.Label
	Public WithEvents Label4 As System.Windows.Forms.Label
	Public WithEvents Gem3infoframe As System.Windows.Forms.Panel
    Public WithEvents _MPSetTB_1 As System.Windows.Forms.Button
    Public WithEvents _MPSetTB_0 As System.Windows.Forms.Button
    Public WithEvents CurStrPic As System.Windows.Forms.PictureBox
    Public WithEvents Frame1 As System.Windows.Forms.GroupBox
    Public WithEvents BGPalCheck As System.Windows.Forms.CheckBox
    Public WithEvents PalSetUD As System.Windows.Forms.NumericUpDown
    Public WithEvents BGPalUD As System.Windows.Forms.NumericUpDown
    Public WithEvents botCHR_UD As System.Windows.Forms.NumericUpDown
    Public WithEvents Label2 As System.Windows.Forms.Label
    Public WithEvents Label3 As System.Windows.Forms.Label
    Public WithEvents Label13 As System.Windows.Forms.Label
    Public WithEvents Frame2 As System.Windows.Forms.GroupBox
    Public WithEvents SBCheck As System.Windows.Forms.CheckBox
    Public WithEvents BDCheck As System.Windows.Forms.CheckBox
    Public WithEvents Gem2Frame As System.Windows.Forms.GroupBox
    Public WithEvents ScrnScroll As System.Windows.Forms.HScrollBar
    Public WithEvents CurScrnTB As System.Windows.Forms.TextBox
    Public WithEvents ScreenPic As System.Windows.Forms.PictureBox
    Public WithEvents ScrnPresUD As System.Windows.Forms.NumericUpDown
	Public WithEvents DDAUD As System.Windows.Forms.NumericUpDown
	Public WithEvents DDBUD As System.Windows.Forms.NumericUpDown
	Public WithEvents SLenUD As System.Windows.Forms.NumericUpDown
	Public WithEvents STUD As System.Windows.Forms.NumericUpDown
	Public WithEvents ScrollMapUD As System.Windows.Forms.NumericUpDown
	Public WithEvents SLenLab As System.Windows.Forms.Label
	Public WithEvents ScrollInfLab As System.Windows.Forms.Label
	Public WithEvents STLab As System.Windows.Forms.Label
	Public WithEvents DDALab As System.Windows.Forms.Label
	Public WithEvents DDBLab As System.Windows.Forms.Label
	Public WithEvents CurScrollLabel As System.Windows.Forms.Label
	Public WithEvents LblScreenPreset As System.Windows.Forms.Label
    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ScreenEd))
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.SBCheck = New System.Windows.Forms.CheckBox()
        Me.CurScrnTB = New System.Windows.Forms.TextBox()
        Me.ScrnPresUD = New System.Windows.Forms.NumericUpDown()
        Me.SLenUD = New System.Windows.Forms.NumericUpDown()
        Me.STUD = New System.Windows.Forms.NumericUpDown()
        Me.ScrnPresUDForSwap = New System.Windows.Forms.NumericUpDown()
        Me.BtnSwapScreenWithCurrent = New System.Windows.Forms.Button()
        Me.ScreenPic = New System.Windows.Forms.PictureBox()
        Me.Gem3hideframe = New System.Windows.Forms.Panel()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Gem3infoframe = New System.Windows.Forms.Panel()
        Me.Text6 = New System.Windows.Forms.TextBox()
        Me.UpDown3 = New System.Windows.Forms.NumericUpDown()
        Me.Check1 = New System.Windows.Forms.CheckBox()
        Me.UpDown2 = New System.Windows.Forms.NumericUpDown()
        Me.Option2 = New System.Windows.Forms.RadioButton()
        Me.Option1 = New System.Windows.Forms.RadioButton()
        Me.UpDown1 = New System.Windows.Forms.NumericUpDown()
        Me.List1 = New System.Windows.Forms.ListBox()
        Me.Text2 = New System.Windows.Forms.TextBox()
        Me.Text1 = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me._MPSetTB_1 = New System.Windows.Forms.Button()
        Me._MPSetTB_0 = New System.Windows.Forms.Button()
        Me.Frame1 = New System.Windows.Forms.GroupBox()
        Me.CurStrPic = New System.Windows.Forms.PictureBox()
        Me.Gem2Frame = New System.Windows.Forms.GroupBox()
        Me.Frame2 = New System.Windows.Forms.GroupBox()
        Me.BGPalCheck = New System.Windows.Forms.CheckBox()
        Me.PalSetUD = New System.Windows.Forms.NumericUpDown()
        Me.BGPalUD = New System.Windows.Forms.NumericUpDown()
        Me.botCHR_UD = New System.Windows.Forms.NumericUpDown()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.BDCheck = New System.Windows.Forms.CheckBox()
        Me.ScrnScroll = New System.Windows.Forms.HScrollBar()
        Me.DDAUD = New System.Windows.Forms.NumericUpDown()
        Me.DDBUD = New System.Windows.Forms.NumericUpDown()
        Me.ScrollMapUD = New System.Windows.Forms.NumericUpDown()
        Me.SLenLab = New System.Windows.Forms.Label()
        Me.ScrollInfLab = New System.Windows.Forms.Label()
        Me.STLab = New System.Windows.Forms.Label()
        Me.DDALab = New System.Windows.Forms.Label()
        Me.DDBLab = New System.Windows.Forms.Label()
        Me.CurScrollLabel = New System.Windows.Forms.Label()
        Me.LblScreenPreset = New System.Windows.Forms.Label()
        Me.BtnDumpLevelMap = New System.Windows.Forms.Button()
        Me.BtnExportScreensLayout = New System.Windows.Forms.Button()
        Me.BtnFillScreenWithCurrentMetametatile = New System.Windows.Forms.Button()
        Me.CheckBox1 = New System.Windows.Forms.CheckBox()
        Me.BtnMoreOptions = New System.Windows.Forms.Button()
        Me.GbxMoreOptions = New System.Windows.Forms.GroupBox()
        CType(Me.ScrnPresUD, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SLenUD, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.STUD, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ScrnPresUDForSwap, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ScreenPic, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Gem3hideframe.SuspendLayout()
        Me.Gem3infoframe.SuspendLayout()
        CType(Me.UpDown3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.UpDown2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.UpDown1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Frame1.SuspendLayout()
        CType(Me.CurStrPic, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Gem2Frame.SuspendLayout()
        Me.Frame2.SuspendLayout()
        CType(Me.PalSetUD, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BGPalUD, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.botCHR_UD, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DDAUD, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DDBUD, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ScrollMapUD, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GbxMoreOptions.SuspendLayout()
        Me.SuspendLayout()
        '
        'ToolTip1
        '
        Me.ToolTip1.AutoPopDelay = 10000
        Me.ToolTip1.InitialDelay = 500
        Me.ToolTip1.ReshowDelay = 100
        '
        'SBCheck
        '
        Me.SBCheck.BackColor = System.Drawing.SystemColors.Control
        Me.SBCheck.Cursor = System.Windows.Forms.Cursors.Default
        Me.SBCheck.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SBCheck.ForeColor = System.Drawing.SystemColors.ControlText
        Me.SBCheck.Location = New System.Drawing.Point(8, 26)
        Me.SBCheck.Name = "SBCheck"
        Me.SBCheck.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.SBCheck.Size = New System.Drawing.Size(137, 15)
        Me.SBCheck.TabIndex = 22
        Me.SBCheck.Text = "Scroll Back Enable"
        Me.ToolTip1.SetToolTip(Me.SBCheck, "Leftward scrolltype")
        Me.SBCheck.UseVisualStyleBackColor = False
        '
        'CurScrnTB
        '
        Me.CurScrnTB.AcceptsReturn = True
        Me.CurScrnTB.BackColor = System.Drawing.SystemColors.Window
        Me.CurScrnTB.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.CurScrnTB.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CurScrnTB.ForeColor = System.Drawing.SystemColors.WindowText
        Me.CurScrnTB.Location = New System.Drawing.Point(8, 272)
        Me.CurScrnTB.MaxLength = 0
        Me.CurScrnTB.Name = "CurScrnTB"
        Me.CurScrnTB.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.CurScrnTB.Size = New System.Drawing.Size(25, 20)
        Me.CurScrnTB.TabIndex = 3
        Me.ToolTip1.SetToolTip(Me.CurScrnTB, "Current Screen Number displaying in the above window.")
        '
        'ScrnPresUD
        '
        Me.ScrnPresUD.Hexadecimal = True
        Me.ScrnPresUD.Location = New System.Drawing.Point(203, 296)
        Me.ScrnPresUD.Maximum = New Decimal(New Integer() {40, 0, 0, 0})
        Me.ScrnPresUD.Name = "ScrnPresUD"
        Me.ScrnPresUD.Size = New System.Drawing.Size(45, 20)
        Me.ScrnPresUD.TabIndex = 1
        Me.ToolTip1.SetToolTip(Me.ScrnPresUD, "Current Screen Preset Number (different than screen number)")
        '
        'SLenUD
        '
        Me.SLenUD.Hexadecimal = True
        Me.SLenUD.Location = New System.Drawing.Point(377, 64)
        Me.SLenUD.Maximum = New Decimal(New Integer() {31, 0, 0, 0})
        Me.SLenUD.Name = "SLenUD"
        Me.SLenUD.Size = New System.Drawing.Size(45, 20)
        Me.SLenUD.TabIndex = 15
        Me.ToolTip1.SetToolTip(Me.SLenUD, "Number of screens to scroll on current Scroll Map/Direction")
        '
        'STUD
        '
        Me.STUD.Hexadecimal = True
        Me.STUD.Location = New System.Drawing.Point(377, 40)
        Me.STUD.Maximum = New Decimal(New Integer() {7, 0, 0, 0})
        Me.STUD.Name = "STUD"
        Me.STUD.Size = New System.Drawing.Size(45, 20)
        Me.STUD.TabIndex = 16
        Me.ToolTip1.SetToolTip(Me.STUD, "Direction type of current Scroll Map (up/down/right, etc)")
        '
        'ScrnPresUDForSwap
        '
        Me.ScrnPresUDForSwap.Hexadecimal = True
        Me.ScrnPresUDForSwap.Location = New System.Drawing.Point(283, 27)
        Me.ScrnPresUDForSwap.Name = "ScrnPresUDForSwap"
        Me.ScrnPresUDForSwap.Size = New System.Drawing.Size(45, 20)
        Me.ScrnPresUDForSwap.TabIndex = 56
        Me.ToolTip1.SetToolTip(Me.ScrnPresUDForSwap, "Current Screen Preset Number (different than screen number)")
        '
        'BtnSwapScreenWithCurrent
        '
        Me.BtnSwapScreenWithCurrent.Location = New System.Drawing.Point(189, 12)
        Me.BtnSwapScreenWithCurrent.Name = "BtnSwapScreenWithCurrent"
        Me.BtnSwapScreenWithCurrent.Size = New System.Drawing.Size(75, 45)
        Me.BtnSwapScreenWithCurrent.TabIndex = 55
        Me.BtnSwapScreenWithCurrent.Text = "Swap Screen"
        Me.ToolTip1.SetToolTip(Me.BtnSwapScreenWithCurrent, "Will Swap Screen chosen in text at right with Screen currently shown.")
        Me.BtnSwapScreenWithCurrent.UseVisualStyleBackColor = True
        '
        'ScreenPic
        '
        Me.ScreenPic.BackColor = System.Drawing.SystemColors.Control
        Me.ScreenPic.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.ScreenPic.Cursor = System.Windows.Forms.Cursors.Default
        Me.ScreenPic.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ScreenPic.ForeColor = System.Drawing.SystemColors.ControlText
        Me.ScreenPic.Location = New System.Drawing.Point(8, 8)
        Me.ScreenPic.Name = "ScreenPic"
        Me.ScreenPic.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.ScreenPic.Size = New System.Drawing.Size(261, 261)
        Me.ScreenPic.TabIndex = 0
        Me.ScreenPic.TabStop = False
        '
        'Gem3hideframe
        '
        Me.Gem3hideframe.BackColor = System.Drawing.SystemColors.Control
        Me.Gem3hideframe.Controls.Add(Me.Label12)
        Me.Gem3hideframe.Cursor = System.Windows.Forms.Cursors.Default
        Me.Gem3hideframe.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Gem3hideframe.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Gem3hideframe.Location = New System.Drawing.Point(272, 0)
        Me.Gem3hideframe.Name = "Gem3hideframe"
        Me.Gem3hideframe.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Gem3hideframe.Size = New System.Drawing.Size(17, 19)
        Me.Gem3hideframe.TabIndex = 51
        Me.Gem3hideframe.Text = "Frame2"
        '
        'Label12
        '
        Me.Label12.BackColor = System.Drawing.SystemColors.Control
        Me.Label12.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label12.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label12.Location = New System.Drawing.Point(144, 8)
        Me.Label12.Name = "Label12"
        Me.Label12.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label12.Size = New System.Drawing.Size(25, 17)
        Me.Label12.TabIndex = 52
        '
        'Gem3infoframe
        '
        Me.Gem3infoframe.BackColor = System.Drawing.SystemColors.Control
        Me.Gem3infoframe.Controls.Add(Me.Text6)
        Me.Gem3infoframe.Controls.Add(Me.UpDown3)
        Me.Gem3infoframe.Controls.Add(Me.Check1)
        Me.Gem3infoframe.Controls.Add(Me.UpDown2)
        Me.Gem3infoframe.Controls.Add(Me.Option2)
        Me.Gem3infoframe.Controls.Add(Me.Option1)
        Me.Gem3infoframe.Controls.Add(Me.UpDown1)
        Me.Gem3infoframe.Controls.Add(Me.List1)
        Me.Gem3infoframe.Controls.Add(Me.Text2)
        Me.Gem3infoframe.Controls.Add(Me.Text1)
        Me.Gem3infoframe.Controls.Add(Me.Label11)
        Me.Gem3infoframe.Controls.Add(Me.Label10)
        Me.Gem3infoframe.Controls.Add(Me.Label9)
        Me.Gem3infoframe.Controls.Add(Me.Label8)
        Me.Gem3infoframe.Controls.Add(Me.Label7)
        Me.Gem3infoframe.Controls.Add(Me.Label6)
        Me.Gem3infoframe.Controls.Add(Me.Label5)
        Me.Gem3infoframe.Controls.Add(Me.Label4)
        Me.Gem3infoframe.Cursor = System.Windows.Forms.Cursors.Default
        Me.Gem3infoframe.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Gem3infoframe.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Gem3infoframe.Location = New System.Drawing.Point(554, 279)
        Me.Gem3infoframe.Name = "Gem3infoframe"
        Me.Gem3infoframe.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Gem3infoframe.Size = New System.Drawing.Size(177, 251)
        Me.Gem3infoframe.TabIndex = 29
        Me.Gem3infoframe.Text = "Frame2"
        Me.Gem3infoframe.Visible = False
        '
        'Text6
        '
        Me.Text6.AcceptsReturn = True
        Me.Text6.BackColor = System.Drawing.SystemColors.Window
        Me.Text6.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.Text6.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Text6.ForeColor = System.Drawing.SystemColors.WindowText
        Me.Text6.Location = New System.Drawing.Point(112, 80)
        Me.Text6.MaxLength = 0
        Me.Text6.Name = "Text6"
        Me.Text6.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Text6.Size = New System.Drawing.Size(57, 20)
        Me.Text6.TabIndex = 48
        '
        'UpDown3
        '
        Me.UpDown3.Location = New System.Drawing.Point(47, 232)
        Me.UpDown3.Name = "UpDown3"
        Me.UpDown3.Size = New System.Drawing.Size(45, 20)
        Me.UpDown3.TabIndex = 46
        '
        'Check1
        '
        Me.Check1.BackColor = System.Drawing.SystemColors.Control
        Me.Check1.Cursor = System.Windows.Forms.Cursors.Default
        Me.Check1.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Check1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Check1.Location = New System.Drawing.Point(0, 216)
        Me.Check1.Name = "Check1"
        Me.Check1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Check1.Size = New System.Drawing.Size(169, 17)
        Me.Check1.TabIndex = 44
        Me.Check1.Text = "Cross Scroll Screen (-1):"
        Me.Check1.UseVisualStyleBackColor = False
        '
        'UpDown2
        '
        Me.UpDown2.Location = New System.Drawing.Point(119, 192)
        Me.UpDown2.Name = "UpDown2"
        Me.UpDown2.Size = New System.Drawing.Size(45, 20)
        Me.UpDown2.TabIndex = 43
        '
        'Option2
        '
        Me.Option2.BackColor = System.Drawing.SystemColors.Control
        Me.Option2.Cursor = System.Windows.Forms.Cursors.Default
        Me.Option2.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Option2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Option2.Location = New System.Drawing.Point(96, 160)
        Me.Option2.Name = "Option2"
        Me.Option2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Option2.Size = New System.Drawing.Size(81, 17)
        Me.Option2.TabIndex = 40
        Me.Option2.TabStop = True
        Me.Option2.Text = "Scroll End"
        Me.Option2.UseVisualStyleBackColor = False
        '
        'Option1
        '
        Me.Option1.BackColor = System.Drawing.SystemColors.Control
        Me.Option1.Cursor = System.Windows.Forms.Cursors.Default
        Me.Option1.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Option1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Option1.Location = New System.Drawing.Point(96, 144)
        Me.Option1.Name = "Option1"
        Me.Option1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Option1.Size = New System.Drawing.Size(73, 17)
        Me.Option1.TabIndex = 39
        Me.Option1.TabStop = True
        Me.Option1.Text = "Scroll Start"
        Me.Option1.UseVisualStyleBackColor = False
        '
        'UpDown1
        '
        Me.UpDown1.Location = New System.Drawing.Point(119, 120)
        Me.UpDown1.Name = "UpDown1"
        Me.UpDown1.Size = New System.Drawing.Size(45, 20)
        Me.UpDown1.TabIndex = 38
        '
        'List1
        '
        Me.List1.BackColor = System.Drawing.SystemColors.Window
        Me.List1.Cursor = System.Windows.Forms.Cursors.Default
        Me.List1.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.List1.ForeColor = System.Drawing.SystemColors.WindowText
        Me.List1.ItemHeight = 14
        Me.List1.Location = New System.Drawing.Point(8, 120)
        Me.List1.Name = "List1"
        Me.List1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.List1.Size = New System.Drawing.Size(65, 46)
        Me.List1.TabIndex = 34
        '
        'Text2
        '
        Me.Text2.AcceptsReturn = True
        Me.Text2.BackColor = System.Drawing.SystemColors.Window
        Me.Text2.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.Text2.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Text2.ForeColor = System.Drawing.SystemColors.WindowText
        Me.Text2.Location = New System.Drawing.Point(112, 56)
        Me.Text2.MaxLength = 0
        Me.Text2.Name = "Text2"
        Me.Text2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Text2.Size = New System.Drawing.Size(57, 20)
        Me.Text2.TabIndex = 33
        '
        'Text1
        '
        Me.Text1.AcceptsReturn = True
        Me.Text1.BackColor = System.Drawing.SystemColors.Window
        Me.Text1.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.Text1.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Text1.ForeColor = System.Drawing.SystemColors.WindowText
        Me.Text1.Location = New System.Drawing.Point(56, 32)
        Me.Text1.MaxLength = 0
        Me.Text1.Name = "Text1"
        Me.Text1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Text1.Size = New System.Drawing.Size(49, 20)
        Me.Text1.TabIndex = 31
        '
        'Label11
        '
        Me.Label11.BackColor = System.Drawing.SystemColors.Control
        Me.Label11.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label11.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label11.Location = New System.Drawing.Point(144, 8)
        Me.Label11.Name = "Label11"
        Me.Label11.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label11.Size = New System.Drawing.Size(25, 17)
        Me.Label11.TabIndex = 50
        '
        'Label10
        '
        Me.Label10.BackColor = System.Drawing.SystemColors.Control
        Me.Label10.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label10.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label10.Location = New System.Drawing.Point(0, 8)
        Me.Label10.Name = "Label10"
        Me.Label10.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label10.Size = New System.Drawing.Size(145, 17)
        Me.Label10.TabIndex = 49
        Me.Label10.Text = "Scroll Info: Scroll Data #"
        '
        'Label9
        '
        Me.Label9.BackColor = System.Drawing.SystemColors.Control
        Me.Label9.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label9.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label9.Location = New System.Drawing.Point(8, 80)
        Me.Label9.Name = "Label9"
        Me.Label9.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label9.Size = New System.Drawing.Size(105, 17)
        Me.Label9.TabIndex = 47
        Me.Label9.Text = "Continuous ASM Call:"
        '
        'Label8
        '
        Me.Label8.BackColor = System.Drawing.SystemColors.Control
        Me.Label8.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label8.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label8.Location = New System.Drawing.Point(88, 176)
        Me.Label8.Name = "Label8"
        Me.Label8.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label8.Size = New System.Drawing.Size(89, 17)
        Me.Label8.TabIndex = 41
        Me.Label8.Text = "CHR Load:"
        '
        'Label7
        '
        Me.Label7.BackColor = System.Drawing.SystemColors.Control
        Me.Label7.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label7.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label7.Location = New System.Drawing.Point(88, 104)
        Me.Label7.Name = "Label7"
        Me.Label7.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label7.Size = New System.Drawing.Size(81, 17)
        Me.Label7.TabIndex = 36
        Me.Label7.Text = "Palette Load:"
        '
        'Label6
        '
        Me.Label6.BackColor = System.Drawing.SystemColors.Control
        Me.Label6.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label6.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label6.Location = New System.Drawing.Point(8, 104)
        Me.Label6.Name = "Label6"
        Me.Label6.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label6.Size = New System.Drawing.Size(81, 17)
        Me.Label6.TabIndex = 35
        Me.Label6.Text = "Scroll Segment:"
        '
        'Label5
        '
        Me.Label5.BackColor = System.Drawing.SystemColors.Control
        Me.Label5.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label5.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label5.Location = New System.Drawing.Point(8, 56)
        Me.Label5.Name = "Label5"
        Me.Label5.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label5.Size = New System.Drawing.Size(89, 17)
        Me.Label5.TabIndex = 32
        Me.Label5.Text = "Primary ASM Call:"
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.SystemColors.Control
        Me.Label4.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label4.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label4.Location = New System.Drawing.Point(8, 32)
        Me.Label4.Name = "Label4"
        Me.Label4.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label4.Size = New System.Drawing.Size(49, 17)
        Me.Label4.TabIndex = 30
        Me.Label4.Text = "Direction:"
        '
        '_MPSetTB_1
        '
        Me._MPSetTB_1.BackColor = System.Drawing.SystemColors.Control
        Me._MPSetTB_1.Cursor = System.Windows.Forms.Cursors.Default
        Me._MPSetTB_1.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._MPSetTB_1.ForeColor = System.Drawing.SystemColors.ControlText
        Me._MPSetTB_1.Location = New System.Drawing.Point(404, 279)
        Me._MPSetTB_1.Name = "_MPSetTB_1"
        Me._MPSetTB_1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._MPSetTB_1.Size = New System.Drawing.Size(85, 25)
        Me._MPSetTB_1.TabIndex = 26
        Me._MPSetTB_1.Text = "Set Bosspoint"
        Me._MPSetTB_1.UseVisualStyleBackColor = False
        '
        '_MPSetTB_0
        '
        Me._MPSetTB_0.BackColor = System.Drawing.SystemColors.Control
        Me._MPSetTB_0.Cursor = System.Windows.Forms.Cursors.Default
        Me._MPSetTB_0.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._MPSetTB_0.ForeColor = System.Drawing.SystemColors.ControlText
        Me._MPSetTB_0.Location = New System.Drawing.Point(404, 248)
        Me._MPSetTB_0.Name = "_MPSetTB_0"
        Me._MPSetTB_0.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._MPSetTB_0.Size = New System.Drawing.Size(85, 25)
        Me._MPSetTB_0.TabIndex = 25
        Me._MPSetTB_0.Text = "Set MidPoint"
        Me._MPSetTB_0.UseVisualStyleBackColor = False
        '
        'Frame1
        '
        Me.Frame1.BackColor = System.Drawing.SystemColors.Control
        Me.Frame1.Controls.Add(Me.CurStrPic)
        Me.Frame1.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Frame1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Frame1.Location = New System.Drawing.Point(280, 240)
        Me.Frame1.Name = "Frame1"
        Me.Frame1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Frame1.Size = New System.Drawing.Size(113, 95)
        Me.Frame1.TabIndex = 23
        Me.Frame1.TabStop = False
        Me.Frame1.Text = "Metametatile"
        '
        'CurStrPic
        '
        Me.CurStrPic.BackColor = System.Drawing.SystemColors.Control
        Me.CurStrPic.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.CurStrPic.Cursor = System.Windows.Forms.Cursors.Default
        Me.CurStrPic.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CurStrPic.ForeColor = System.Drawing.SystemColors.ControlText
        Me.CurStrPic.Location = New System.Drawing.Point(15, 16)
        Me.CurStrPic.Name = "CurStrPic"
        Me.CurStrPic.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.CurStrPic.Size = New System.Drawing.Size(72, 73)
        Me.CurStrPic.TabIndex = 24
        Me.CurStrPic.TabStop = False
        '
        'Gem2Frame
        '
        Me.Gem2Frame.BackColor = System.Drawing.SystemColors.Control
        Me.Gem2Frame.Controls.Add(Me.Frame2)
        Me.Gem2Frame.Controls.Add(Me.SBCheck)
        Me.Gem2Frame.Controls.Add(Me.BDCheck)
        Me.Gem2Frame.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Gem2Frame.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Gem2Frame.Location = New System.Drawing.Point(280, 112)
        Me.Gem2Frame.Name = "Gem2Frame"
        Me.Gem2Frame.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Gem2Frame.Size = New System.Drawing.Size(209, 125)
        Me.Gem2Frame.TabIndex = 20
        Me.Gem2Frame.TabStop = False
        Me.Gem2Frame.Visible = False
        '
        'Frame2
        '
        Me.Frame2.BackColor = System.Drawing.SystemColors.Control
        Me.Frame2.Controls.Add(Me.BGPalCheck)
        Me.Frame2.Controls.Add(Me.PalSetUD)
        Me.Frame2.Controls.Add(Me.BGPalUD)
        Me.Frame2.Controls.Add(Me.botCHR_UD)
        Me.Frame2.Controls.Add(Me.Label2)
        Me.Frame2.Controls.Add(Me.Label3)
        Me.Frame2.Controls.Add(Me.Label13)
        Me.Frame2.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Frame2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Frame2.Location = New System.Drawing.Point(8, 45)
        Me.Frame2.Name = "Frame2"
        Me.Frame2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Frame2.Size = New System.Drawing.Size(193, 73)
        Me.Frame2.TabIndex = 53
        Me.Frame2.TabStop = False
        '
        'BGPalCheck
        '
        Me.BGPalCheck.BackColor = System.Drawing.SystemColors.Control
        Me.BGPalCheck.Cursor = System.Windows.Forms.Cursors.Default
        Me.BGPalCheck.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BGPalCheck.ForeColor = System.Drawing.SystemColors.ControlText
        Me.BGPalCheck.Location = New System.Drawing.Point(8, 24)
        Me.BGPalCheck.Name = "BGPalCheck"
        Me.BGPalCheck.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.BGPalCheck.Size = New System.Drawing.Size(17, 17)
        Me.BGPalCheck.TabIndex = 56
        Me.BGPalCheck.UseVisualStyleBackColor = False
        '
        'PalSetUD
        '
        Me.PalSetUD.Hexadecimal = True
        Me.PalSetUD.Location = New System.Drawing.Point(136, 0)
        Me.PalSetUD.Name = "PalSetUD"
        Me.PalSetUD.Size = New System.Drawing.Size(45, 20)
        Me.PalSetUD.TabIndex = 57
        '
        'BGPalUD
        '
        Me.BGPalUD.Hexadecimal = True
        Me.BGPalUD.Location = New System.Drawing.Point(142, 24)
        Me.BGPalUD.Maximum = New Decimal(New Integer() {127, 0, 0, 0})
        Me.BGPalUD.Name = "BGPalUD"
        Me.BGPalUD.Size = New System.Drawing.Size(45, 20)
        Me.BGPalUD.TabIndex = 58
        '
        'botCHR_UD
        '
        Me.botCHR_UD.Hexadecimal = True
        Me.botCHR_UD.Location = New System.Drawing.Point(142, 48)
        Me.botCHR_UD.Maximum = New Decimal(New Integer() {255, 0, 0, 0})
        Me.botCHR_UD.Name = "botCHR_UD"
        Me.botCHR_UD.Size = New System.Drawing.Size(45, 20)
        Me.botCHR_UD.TabIndex = 63
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.SystemColors.Control
        Me.Label2.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label2.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label2.Location = New System.Drawing.Point(8, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label2.Size = New System.Drawing.Size(97, 21)
        Me.Label2.TabIndex = 61
        Me.Label2.Text = "Sprite Palette Set"
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.SystemColors.Control
        Me.Label3.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label3.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label3.Location = New System.Drawing.Point(24, 24)
        Me.Label3.Name = "Label3"
        Me.Label3.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label3.Size = New System.Drawing.Size(113, 23)
        Me.Label3.TabIndex = 60
        Me.Label3.Text = "Change BG Pal"
        '
        'Label13
        '
        Me.Label13.BackColor = System.Drawing.SystemColors.Control
        Me.Label13.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label13.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label13.Location = New System.Drawing.Point(8, 48)
        Me.Label13.Name = "Label13"
        Me.Label13.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label13.Size = New System.Drawing.Size(134, 22)
        Me.Label13.TabIndex = 59
        Me.Label13.Text = "Change bottom-half CHR"
        '
        'BDCheck
        '
        Me.BDCheck.BackColor = System.Drawing.SystemColors.Control
        Me.BDCheck.Cursor = System.Windows.Forms.Cursors.Default
        Me.BDCheck.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BDCheck.ForeColor = System.Drawing.SystemColors.ControlText
        Me.BDCheck.Location = New System.Drawing.Point(8, 8)
        Me.BDCheck.Name = "BDCheck"
        Me.BDCheck.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.BDCheck.Size = New System.Drawing.Size(105, 17)
        Me.BDCheck.TabIndex = 21
        Me.BDCheck.Text = "Boss Door Effect"
        Me.BDCheck.UseVisualStyleBackColor = False
        '
        'ScrnScroll
        '
        Me.ScrnScroll.CausesValidation = False
        Me.ScrnScroll.Cursor = System.Windows.Forms.Cursors.Default
        Me.ScrnScroll.LargeChange = 4
        Me.ScrnScroll.Location = New System.Drawing.Point(34, 272)
        Me.ScrnScroll.Maximum = 32770
        Me.ScrnScroll.Name = "ScrnScroll"
        Me.ScrnScroll.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.ScrnScroll.Size = New System.Drawing.Size(233, 17)
        Me.ScrnScroll.TabIndex = 4
        Me.ScrnScroll.TabStop = True
        '
        'DDAUD
        '
        Me.DDAUD.Hexadecimal = True
        Me.DDAUD.Location = New System.Drawing.Point(383, 160)
        Me.DDAUD.Name = "DDAUD"
        Me.DDAUD.Size = New System.Drawing.Size(42, 20)
        Me.DDAUD.TabIndex = 6
        '
        'DDBUD
        '
        Me.DDBUD.Hexadecimal = True
        Me.DDBUD.Location = New System.Drawing.Point(383, 184)
        Me.DDBUD.Name = "DDBUD"
        Me.DDBUD.Size = New System.Drawing.Size(42, 20)
        Me.DDBUD.TabIndex = 10
        '
        'ScrollMapUD
        '
        Me.ScrollMapUD.Hexadecimal = True
        Me.ScrollMapUD.Location = New System.Drawing.Point(401, 16)
        Me.ScrollMapUD.Maximum = New Decimal(New Integer() {23, 0, 0, 0})
        Me.ScrollMapUD.Name = "ScrollMapUD"
        Me.ScrollMapUD.Size = New System.Drawing.Size(45, 20)
        Me.ScrollMapUD.TabIndex = 28
        '
        'SLenLab
        '
        Me.SLenLab.BackColor = System.Drawing.SystemColors.Control
        Me.SLenLab.Cursor = System.Windows.Forms.Cursors.Default
        Me.SLenLab.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SLenLab.ForeColor = System.Drawing.SystemColors.ControlText
        Me.SLenLab.Location = New System.Drawing.Point(288, 64)
        Me.SLenLab.Name = "SLenLab"
        Me.SLenLab.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.SLenLab.Size = New System.Drawing.Size(89, 23)
        Me.SLenLab.TabIndex = 18
        Me.SLenLab.Text = "Screen-Length"
        '
        'ScrollInfLab
        '
        Me.ScrollInfLab.BackColor = System.Drawing.SystemColors.Control
        Me.ScrollInfLab.Cursor = System.Windows.Forms.Cursors.Default
        Me.ScrollInfLab.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ScrollInfLab.ForeColor = System.Drawing.SystemColors.ControlText
        Me.ScrollInfLab.Location = New System.Drawing.Point(288, 88)
        Me.ScrollInfLab.Name = "ScrollInfLab"
        Me.ScrollInfLab.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.ScrollInfLab.Size = New System.Drawing.Size(153, 17)
        Me.ScrollInfLab.TabIndex = 19
        '
        'STLab
        '
        Me.STLab.BackColor = System.Drawing.SystemColors.Control
        Me.STLab.Cursor = System.Windows.Forms.Cursors.Default
        Me.STLab.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.STLab.ForeColor = System.Drawing.SystemColors.ControlText
        Me.STLab.Location = New System.Drawing.Point(288, 40)
        Me.STLab.Name = "STLab"
        Me.STLab.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.STLab.Size = New System.Drawing.Size(89, 23)
        Me.STLab.TabIndex = 17
        Me.STLab.Text = "Scroll Type"
        '
        'DDALab
        '
        Me.DDALab.BackColor = System.Drawing.SystemColors.Control
        Me.DDALab.Cursor = System.Windows.Forms.Cursors.Default
        Me.DDALab.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DDALab.ForeColor = System.Drawing.SystemColors.ControlText
        Me.DDALab.Location = New System.Drawing.Point(288, 160)
        Me.DDALab.Name = "DDALab"
        Me.DDALab.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.DDALab.Size = New System.Drawing.Size(89, 17)
        Me.DDALab.TabIndex = 12
        '
        'DDBLab
        '
        Me.DDBLab.BackColor = System.Drawing.SystemColors.Control
        Me.DDBLab.Cursor = System.Windows.Forms.Cursors.Default
        Me.DDBLab.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DDBLab.ForeColor = System.Drawing.SystemColors.ControlText
        Me.DDBLab.Location = New System.Drawing.Point(288, 184)
        Me.DDBLab.Name = "DDBLab"
        Me.DDBLab.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.DDBLab.Size = New System.Drawing.Size(89, 17)
        Me.DDBLab.TabIndex = 8
        '
        'CurScrollLabel
        '
        Me.CurScrollLabel.BackColor = System.Drawing.SystemColors.Control
        Me.CurScrollLabel.Cursor = System.Windows.Forms.Cursors.Default
        Me.CurScrollLabel.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CurScrollLabel.ForeColor = System.Drawing.SystemColors.ControlText
        Me.CurScrollLabel.Location = New System.Drawing.Point(272, 16)
        Me.CurScrollLabel.Name = "CurScrollLabel"
        Me.CurScrollLabel.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.CurScrollLabel.Size = New System.Drawing.Size(121, 17)
        Me.CurScrollLabel.TabIndex = 7
        Me.CurScrollLabel.Text = "Scroll Map Position:"
        '
        'LblScreenPreset
        '
        Me.LblScreenPreset.BackColor = System.Drawing.SystemColors.Control
        Me.LblScreenPreset.Cursor = System.Windows.Forms.Cursors.Default
        Me.LblScreenPreset.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblScreenPreset.ForeColor = System.Drawing.SystemColors.ControlText
        Me.LblScreenPreset.Location = New System.Drawing.Point(116, 296)
        Me.LblScreenPreset.Name = "LblScreenPreset"
        Me.LblScreenPreset.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.LblScreenPreset.Size = New System.Drawing.Size(103, 23)
        Me.LblScreenPreset.TabIndex = 5
        Me.LblScreenPreset.Text = "Screen Preset:"
        '
        'BtnDumpLevelMap
        '
        Me.BtnDumpLevelMap.Location = New System.Drawing.Point(24, 12)
        Me.BtnDumpLevelMap.Name = "BtnDumpLevelMap"
        Me.BtnDumpLevelMap.Size = New System.Drawing.Size(75, 45)
        Me.BtnDumpLevelMap.TabIndex = 52
        Me.BtnDumpLevelMap.Text = "Dump Level's Map"
        Me.BtnDumpLevelMap.UseVisualStyleBackColor = True
        '
        'BtnExportScreensLayout
        '
        Me.BtnExportScreensLayout.Location = New System.Drawing.Point(382, 12)
        Me.BtnExportScreensLayout.Name = "BtnExportScreensLayout"
        Me.BtnExportScreensLayout.Size = New System.Drawing.Size(75, 46)
        Me.BtnExportScreensLayout.TabIndex = 53
        Me.BtnExportScreensLayout.Text = "Export to ASM File"
        Me.BtnExportScreensLayout.UseVisualStyleBackColor = True
        '
        'BtnFillScreenWithCurrentMetametatile
        '
        Me.BtnFillScreenWithCurrentMetametatile.Location = New System.Drawing.Point(108, 12)
        Me.BtnFillScreenWithCurrentMetametatile.Name = "BtnFillScreenWithCurrentMetametatile"
        Me.BtnFillScreenWithCurrentMetametatile.Size = New System.Drawing.Size(75, 45)
        Me.BtnFillScreenWithCurrentMetametatile.TabIndex = 54
        Me.BtnFillScreenWithCurrentMetametatile.Text = "Fill with current Metametatile"
        Me.BtnFillScreenWithCurrentMetametatile.UseVisualStyleBackColor = True
        '
        'CheckBox1
        '
        Me.CheckBox1.BackColor = System.Drawing.SystemColors.Control
        Me.CheckBox1.Cursor = System.Windows.Forms.Cursors.Default
        Me.CheckBox1.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CheckBox1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.CheckBox1.Location = New System.Drawing.Point(24, 58)
        Me.CheckBox1.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.CheckBox1.Name = "CheckBox1"
        Me.CheckBox1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.CheckBox1.Size = New System.Drawing.Size(365, 19)
        Me.CheckBox1.TabIndex = 57
        Me.CheckBox1.Text = "Ignore Screen Layout Data (use Current# as ID)"
        Me.CheckBox1.UseVisualStyleBackColor = False
        '
        'BtnMoreOptions
        '
        Me.BtnMoreOptions.BackColor = System.Drawing.SystemColors.Control
        Me.BtnMoreOptions.Cursor = System.Windows.Forms.Cursors.Default
        Me.BtnMoreOptions.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnMoreOptions.ForeColor = System.Drawing.SystemColors.ControlText
        Me.BtnMoreOptions.Location = New System.Drawing.Point(404, 310)
        Me.BtnMoreOptions.Name = "BtnMoreOptions"
        Me.BtnMoreOptions.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.BtnMoreOptions.Size = New System.Drawing.Size(85, 25)
        Me.BtnMoreOptions.TabIndex = 58
        Me.BtnMoreOptions.Text = "More Options"
        Me.BtnMoreOptions.UseVisualStyleBackColor = False
        '
        'GbxMoreOptions
        '
        Me.GbxMoreOptions.Controls.Add(Me.BtnDumpLevelMap)
        Me.GbxMoreOptions.Controls.Add(Me.BtnExportScreensLayout)
        Me.GbxMoreOptions.Controls.Add(Me.BtnFillScreenWithCurrentMetametatile)
        Me.GbxMoreOptions.Controls.Add(Me.BtnSwapScreenWithCurrent)
        Me.GbxMoreOptions.Controls.Add(Me.CheckBox1)
        Me.GbxMoreOptions.Controls.Add(Me.ScrnPresUDForSwap)
        Me.GbxMoreOptions.Location = New System.Drawing.Point(12, 335)
        Me.GbxMoreOptions.Name = "GbxMoreOptions"
        Me.GbxMoreOptions.Size = New System.Drawing.Size(479, 80)
        Me.GbxMoreOptions.TabIndex = 59
        Me.GbxMoreOptions.TabStop = False
        Me.GbxMoreOptions.Visible = False
        '
        'ScreenEd
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 14.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.ClientSize = New System.Drawing.Size(496, 537)
        Me.Controls.Add(Me.Gem3infoframe)
        Me.Controls.Add(Me.GbxMoreOptions)
        Me.Controls.Add(Me.BtnMoreOptions)
        Me.Controls.Add(Me.Gem3hideframe)
        Me.Controls.Add(Me._MPSetTB_1)
        Me.Controls.Add(Me._MPSetTB_0)
        Me.Controls.Add(Me.Frame1)
        Me.Controls.Add(Me.Gem2Frame)
        Me.Controls.Add(Me.ScrnScroll)
        Me.Controls.Add(Me.CurScrnTB)
        Me.Controls.Add(Me.ScreenPic)
        Me.Controls.Add(Me.ScrnPresUD)
        Me.Controls.Add(Me.DDAUD)
        Me.Controls.Add(Me.DDBUD)
        Me.Controls.Add(Me.SLenUD)
        Me.Controls.Add(Me.STUD)
        Me.Controls.Add(Me.ScrollMapUD)
        Me.Controls.Add(Me.SLenLab)
        Me.Controls.Add(Me.ScrollInfLab)
        Me.Controls.Add(Me.STLab)
        Me.Controls.Add(Me.DDALab)
        Me.Controls.Add(Me.DDBLab)
        Me.Controls.Add(Me.CurScrollLabel)
        Me.Controls.Add(Me.LblScreenPreset)
        Me.Cursor = System.Windows.Forms.Cursors.Default
        Me.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.Location = New System.Drawing.Point(3, 29)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "ScreenEd"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Text = " Screen Editor"
        CType(Me.ScrnPresUD, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SLenUD, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.STUD, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ScrnPresUDForSwap, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ScreenPic, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Gem3hideframe.ResumeLayout(False)
        Me.Gem3infoframe.ResumeLayout(False)
        Me.Gem3infoframe.PerformLayout()
        CType(Me.UpDown3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.UpDown2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.UpDown1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Frame1.ResumeLayout(False)
        CType(Me.CurStrPic, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Gem2Frame.ResumeLayout(False)
        Me.Frame2.ResumeLayout(False)
        CType(Me.PalSetUD, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BGPalUD, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.botCHR_UD, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DDAUD, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DDBUD, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ScrollMapUD, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GbxMoreOptions.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents BtnDumpLevelMap As Button
    Friend WithEvents BtnExportScreensLayout As Button
    Friend WithEvents BtnFillScreenWithCurrentMetametatile As Button
    Friend WithEvents BtnSwapScreenWithCurrent As Button
    Public WithEvents ScrnPresUDForSwap As NumericUpDown
    Public WithEvents CheckBox1 As CheckBox
    Public WithEvents BtnMoreOptions As Button
    Friend WithEvents GbxMoreOptions As GroupBox
#End Region
End Class