<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> Partial Class Config
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
    Public WithEvents ShellTB As System.Windows.Forms.TextBox
    Public WithEvents MM4RainbowCheck As System.Windows.Forms.CheckBox
    Public WithEvents MM5GManCheck As System.Windows.Forms.CheckBox
    Public WithEvents Frame4 As System.Windows.Forms.GroupBox
    Public WithEvents _TsaTRes_2 As System.Windows.Forms.RadioButton
    Public WithEvents _TsaTRes_1 As System.Windows.Forms.RadioButton
    Public WithEvents _TsaTRes_0 As System.Windows.Forms.RadioButton
    Public WithEvents Frame3 As System.Windows.Forms.GroupBox
    Public WithEvents TSAEdGridCheck As System.Windows.Forms.CheckBox
    Public WithEvents TileEdGridCheck As System.Windows.Forms.CheckBox
    Public WithEvents ScrEdGridCheck As System.Windows.Forms.CheckBox
    Public WithEvents Frame2 As System.Windows.Forms.GroupBox
    Public WithEvents EnemCountFmtCheck As System.Windows.Forms.CheckBox
    Public WithEvents StealFocusCheck As System.Windows.Forms.CheckBox
    Public WithEvents ScrSprAllCheck As System.Windows.Forms.CheckBox
    Public WithEvents ScrSprCheck As System.Windows.Forms.CheckBox
    Public WithEvents SortXCheck As System.Windows.Forms.CheckBox
    Public WithEvents SortScrCheck As System.Windows.Forms.CheckBox
    Public WithEvents Frame1 As System.Windows.Forms.GroupBox
    Public WithEvents PALReloadBtn As System.Windows.Forms.Button
    Public WithEvents PALBrowseBtn As System.Windows.Forms.Button
    Public WithEvents EmuBrowseBtn As System.Windows.Forms.Button
    Public WithEvents PALTB As System.Windows.Forms.TextBox
    Public WithEvents EmuTB As System.Windows.Forms.TextBox
    Public WithEvents Label3 As System.Windows.Forms.Label
    Public WithEvents Label2 As System.Windows.Forms.Label
    Public WithEvents Label1 As System.Windows.Forms.Label
    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Config))
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.PALTB = New System.Windows.Forms.TextBox()
        Me.EmuTB = New System.Windows.Forms.TextBox()
        Me.ChkAutoloadROM = New System.Windows.Forms.CheckBox()
        Me.ShellTB = New System.Windows.Forms.TextBox()
        Me.Frame4 = New System.Windows.Forms.GroupBox()
        Me.MM4RainbowCheck = New System.Windows.Forms.CheckBox()
        Me.MM5GManCheck = New System.Windows.Forms.CheckBox()
        Me.Frame3 = New System.Windows.Forms.GroupBox()
        Me._TsaTRes_2 = New System.Windows.Forms.RadioButton()
        Me._TsaTRes_1 = New System.Windows.Forms.RadioButton()
        Me._TsaTRes_0 = New System.Windows.Forms.RadioButton()
        Me.Frame2 = New System.Windows.Forms.GroupBox()
        Me.TSAEdGridCheck = New System.Windows.Forms.CheckBox()
        Me.TileEdGridCheck = New System.Windows.Forms.CheckBox()
        Me.ScrEdGridCheck = New System.Windows.Forms.CheckBox()
        Me.Frame1 = New System.Windows.Forms.GroupBox()
        Me.EnemCountFmtCheck = New System.Windows.Forms.CheckBox()
        Me.StealFocusCheck = New System.Windows.Forms.CheckBox()
        Me.ScrSprAllCheck = New System.Windows.Forms.CheckBox()
        Me.ScrSprCheck = New System.Windows.Forms.CheckBox()
        Me.SortXCheck = New System.Windows.Forms.CheckBox()
        Me.SortScrCheck = New System.Windows.Forms.CheckBox()
        Me.PALReloadBtn = New System.Windows.Forms.Button()
        Me.PALBrowseBtn = New System.Windows.Forms.Button()
        Me.EmuBrowseBtn = New System.Windows.Forms.Button()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.EffSprSimCheck = New System.Windows.Forms.CheckBox()
        Me.DetectChangeCheck = New System.Windows.Forms.CheckBox()
        Me.ScrollSearchCheck = New System.Windows.Forms.CheckBox()
        Me.SBDAlg2Check = New System.Windows.Forms.CheckBox()
        Me.Scroll0Check = New System.Windows.Forms.CheckBox()
        Me.CACheck = New System.Windows.Forms.CheckBox()
        Me.PACheck = New System.Windows.Forms.CheckBox()
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.Frame4.SuspendLayout()
        Me.Frame3.SuspendLayout()
        Me.Frame2.SuspendLayout()
        Me.Frame1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'PALTB
        '
        Me.PALTB.AcceptsReturn = True
        Me.PALTB.BackColor = System.Drawing.SystemColors.Window
        Me.PALTB.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.PALTB.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.PALTB.ForeColor = System.Drawing.SystemColors.WindowText
        Me.PALTB.Location = New System.Drawing.Point(116, 75)
        Me.PALTB.MaxLength = 0
        Me.PALTB.Name = "PALTB"
        Me.PALTB.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.PALTB.Size = New System.Drawing.Size(446, 20)
        Me.PALTB.TabIndex = 3
        Me.ToolTip1.SetToolTip(Me.PALTB, "Directory of default or custom Palette ")
        '
        'EmuTB
        '
        Me.EmuTB.AcceptsReturn = True
        Me.EmuTB.BackColor = System.Drawing.SystemColors.Window
        Me.EmuTB.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.EmuTB.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.EmuTB.ForeColor = System.Drawing.SystemColors.WindowText
        Me.EmuTB.Location = New System.Drawing.Point(16, 22)
        Me.EmuTB.MaxLength = 0
        Me.EmuTB.Name = "EmuTB"
        Me.EmuTB.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.EmuTB.Size = New System.Drawing.Size(546, 20)
        Me.EmuTB.TabIndex = 1
        Me.ToolTip1.SetToolTip(Me.EmuTB, "Directory of the emulator")
        '
        'ChkAutoloadROM
        '
        Me.ChkAutoloadROM.BackColor = System.Drawing.SystemColors.Control
        Me.ChkAutoloadROM.Cursor = System.Windows.Forms.Cursors.Default
        Me.ChkAutoloadROM.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ChkAutoloadROM.ForeColor = System.Drawing.SystemColors.ControlText
        Me.ChkAutoloadROM.Location = New System.Drawing.Point(16, 17)
        Me.ChkAutoloadROM.Name = "ChkAutoloadROM"
        Me.ChkAutoloadROM.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.ChkAutoloadROM.Size = New System.Drawing.Size(610, 25)
        Me.ChkAutoloadROM.TabIndex = 75
        Me.ChkAutoloadROM.Text = "Autoload current ROM everytime"
        Me.ToolTip1.SetToolTip(Me.ChkAutoloadROM, "When checked, current game will be opened by default at next opening")
        Me.ChkAutoloadROM.UseVisualStyleBackColor = False
        '
        'ShellTB
        '
        Me.ShellTB.AcceptsReturn = True
        Me.ShellTB.BackColor = System.Drawing.SystemColors.Window
        Me.ShellTB.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.ShellTB.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ShellTB.ForeColor = System.Drawing.SystemColors.WindowText
        Me.ShellTB.Location = New System.Drawing.Point(178, 48)
        Me.ShellTB.MaxLength = 0
        Me.ShellTB.Name = "ShellTB"
        Me.ShellTB.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.ShellTB.Size = New System.Drawing.Size(384, 20)
        Me.ShellTB.TabIndex = 32
        '
        'Frame4
        '
        Me.Frame4.BackColor = System.Drawing.SystemColors.Control
        Me.Frame4.Controls.Add(Me.MM4RainbowCheck)
        Me.Frame4.Controls.Add(Me.MM5GManCheck)
        Me.Frame4.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Frame4.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Frame4.Location = New System.Drawing.Point(8, 641)
        Me.Frame4.Name = "Frame4"
        Me.Frame4.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Frame4.Size = New System.Drawing.Size(633, 69)
        Me.Frame4.TabIndex = 28
        Me.Frame4.TabStop = False
        Me.Frame4.Text = " Special "
        '
        'MM4RainbowCheck
        '
        Me.MM4RainbowCheck.BackColor = System.Drawing.SystemColors.Control
        Me.MM4RainbowCheck.Cursor = System.Windows.Forms.Cursors.Default
        Me.MM4RainbowCheck.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MM4RainbowCheck.ForeColor = System.Drawing.SystemColors.ControlText
        Me.MM4RainbowCheck.Location = New System.Drawing.Point(16, 17)
        Me.MM4RainbowCheck.Name = "MM4RainbowCheck"
        Me.MM4RainbowCheck.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.MM4RainbowCheck.Size = New System.Drawing.Size(610, 25)
        Me.MM4RainbowCheck.TabIndex = 37
        Me.MM4RainbowCheck.Text = "Mega Man 4 - Enable copy of Ringman Palette Animation to Spr palette."
        Me.MM4RainbowCheck.UseVisualStyleBackColor = False
        '
        'MM5GManCheck
        '
        Me.MM5GManCheck.BackColor = System.Drawing.SystemColors.Control
        Me.MM5GManCheck.Cursor = System.Windows.Forms.Cursors.Default
        Me.MM5GManCheck.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MM5GManCheck.ForeColor = System.Drawing.SystemColors.ControlText
        Me.MM5GManCheck.Location = New System.Drawing.Point(16, 37)
        Me.MM5GManCheck.Name = "MM5GManCheck"
        Me.MM5GManCheck.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.MM5GManCheck.Size = New System.Drawing.Size(610, 25)
        Me.MM5GManCheck.TabIndex = 29
        Me.MM5GManCheck.Text = "Mega Man 5 - Enable emulation of Hard-coded Gravityman CHR Anim."
        Me.MM5GManCheck.UseVisualStyleBackColor = False
        '
        'Frame3
        '
        Me.Frame3.BackColor = System.Drawing.SystemColors.Control
        Me.Frame3.Controls.Add(Me._TsaTRes_2)
        Me.Frame3.Controls.Add(Me._TsaTRes_1)
        Me.Frame3.Controls.Add(Me._TsaTRes_0)
        Me.Frame3.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Frame3.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Frame3.Location = New System.Drawing.Point(8, 337)
        Me.Frame3.Name = "Frame3"
        Me.Frame3.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Frame3.Size = New System.Drawing.Size(633, 71)
        Me.Frame3.TabIndex = 25
        Me.Frame3.TabStop = False
        Me.Frame3.Text = "Metatiles Table Block Resolution "
        '
        '_TsaTRes_2
        '
        Me._TsaTRes_2.BackColor = System.Drawing.SystemColors.Control
        Me._TsaTRes_2.Cursor = System.Windows.Forms.Cursors.Default
        Me._TsaTRes_2.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._TsaTRes_2.ForeColor = System.Drawing.SystemColors.ControlText
        Me._TsaTRes_2.Location = New System.Drawing.Point(16, 36)
        Me._TsaTRes_2.Name = "_TsaTRes_2"
        Me._TsaTRes_2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._TsaTRes_2.Size = New System.Drawing.Size(129, 25)
        Me._TsaTRes_2.TabIndex = 36
        Me._TsaTRes_2.TabStop = True
        Me._TsaTRes_2.Text = "Large 8x8"
        Me._TsaTRes_2.UseVisualStyleBackColor = False
        '
        '_TsaTRes_1
        '
        Me._TsaTRes_1.BackColor = System.Drawing.SystemColors.Control
        Me._TsaTRes_1.Cursor = System.Windows.Forms.Cursors.Default
        Me._TsaTRes_1.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._TsaTRes_1.ForeColor = System.Drawing.SystemColors.ControlText
        Me._TsaTRes_1.Location = New System.Drawing.Point(136, 17)
        Me._TsaTRes_1.Name = "_TsaTRes_1"
        Me._TsaTRes_1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._TsaTRes_1.Size = New System.Drawing.Size(225, 17)
        Me._TsaTRes_1.TabIndex = 27
        Me._TsaTRes_1.TabStop = True
        Me._TsaTRes_1.Text = "Small 8x32 (Aligned collumns)"
        Me._TsaTRes_1.UseVisualStyleBackColor = False
        '
        '_TsaTRes_0
        '
        Me._TsaTRes_0.BackColor = System.Drawing.SystemColors.Control
        Me._TsaTRes_0.Cursor = System.Windows.Forms.Cursors.Default
        Me._TsaTRes_0.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._TsaTRes_0.ForeColor = System.Drawing.SystemColors.ControlText
        Me._TsaTRes_0.Location = New System.Drawing.Point(16, 17)
        Me._TsaTRes_0.Name = "_TsaTRes_0"
        Me._TsaTRes_0.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._TsaTRes_0.Size = New System.Drawing.Size(105, 17)
        Me._TsaTRes_0.TabIndex = 26
        Me._TsaTRes_0.TabStop = True
        Me._TsaTRes_0.Text = "Small 16x16"
        Me._TsaTRes_0.UseVisualStyleBackColor = False
        '
        'Frame2
        '
        Me.Frame2.BackColor = System.Drawing.SystemColors.Control
        Me.Frame2.Controls.Add(Me.TSAEdGridCheck)
        Me.Frame2.Controls.Add(Me.TileEdGridCheck)
        Me.Frame2.Controls.Add(Me.ScrEdGridCheck)
        Me.Frame2.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Frame2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Frame2.Location = New System.Drawing.Point(8, 412)
        Me.Frame2.Name = "Frame2"
        Me.Frame2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Frame2.Size = New System.Drawing.Size(633, 46)
        Me.Frame2.TabIndex = 18
        Me.Frame2.TabStop = False
        Me.Frame2.Text = " Enable Grid "
        '
        'TSAEdGridCheck
        '
        Me.TSAEdGridCheck.BackColor = System.Drawing.SystemColors.Control
        Me.TSAEdGridCheck.Cursor = System.Windows.Forms.Cursors.Default
        Me.TSAEdGridCheck.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TSAEdGridCheck.ForeColor = System.Drawing.SystemColors.ControlText
        Me.TSAEdGridCheck.Location = New System.Drawing.Point(16, 17)
        Me.TSAEdGridCheck.Name = "TSAEdGridCheck"
        Me.TSAEdGridCheck.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.TSAEdGridCheck.Size = New System.Drawing.Size(89, 17)
        Me.TSAEdGridCheck.TabIndex = 34
        Me.TSAEdGridCheck.Text = "TSA Table"
        Me.TSAEdGridCheck.UseVisualStyleBackColor = False
        '
        'TileEdGridCheck
        '
        Me.TileEdGridCheck.BackColor = System.Drawing.SystemColors.Control
        Me.TileEdGridCheck.Cursor = System.Windows.Forms.Cursors.Default
        Me.TileEdGridCheck.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TileEdGridCheck.ForeColor = System.Drawing.SystemColors.ControlText
        Me.TileEdGridCheck.Location = New System.Drawing.Point(337, 17)
        Me.TileEdGridCheck.Name = "TileEdGridCheck"
        Me.TileEdGridCheck.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.TileEdGridCheck.Size = New System.Drawing.Size(89, 17)
        Me.TileEdGridCheck.TabIndex = 20
        Me.TileEdGridCheck.Text = "Tile Table"
        Me.TileEdGridCheck.UseVisualStyleBackColor = False
        '
        'ScrEdGridCheck
        '
        Me.ScrEdGridCheck.BackColor = System.Drawing.SystemColors.Control
        Me.ScrEdGridCheck.Cursor = System.Windows.Forms.Cursors.Default
        Me.ScrEdGridCheck.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ScrEdGridCheck.ForeColor = System.Drawing.SystemColors.ControlText
        Me.ScrEdGridCheck.Location = New System.Drawing.Point(161, 17)
        Me.ScrEdGridCheck.Name = "ScrEdGridCheck"
        Me.ScrEdGridCheck.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.ScrEdGridCheck.Size = New System.Drawing.Size(120, 17)
        Me.ScrEdGridCheck.TabIndex = 19
        Me.ScrEdGridCheck.Text = "Screen Editor"
        Me.ScrEdGridCheck.UseVisualStyleBackColor = False
        '
        'Frame1
        '
        Me.Frame1.BackColor = System.Drawing.SystemColors.Control
        Me.Frame1.Controls.Add(Me.EnemCountFmtCheck)
        Me.Frame1.Controls.Add(Me.StealFocusCheck)
        Me.Frame1.Controls.Add(Me.ScrSprAllCheck)
        Me.Frame1.Controls.Add(Me.ScrSprCheck)
        Me.Frame1.Controls.Add(Me.SortXCheck)
        Me.Frame1.Controls.Add(Me.SortScrCheck)
        Me.Frame1.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Frame1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Frame1.Location = New System.Drawing.Point(8, 462)
        Me.Frame1.Name = "Frame1"
        Me.Frame1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Frame1.Size = New System.Drawing.Size(633, 175)
        Me.Frame1.TabIndex = 14
        Me.Frame1.TabStop = False
        Me.Frame1.Text = "Enemy Editor"
        '
        'EnemCountFmtCheck
        '
        Me.EnemCountFmtCheck.BackColor = System.Drawing.SystemColors.Control
        Me.EnemCountFmtCheck.Cursor = System.Windows.Forms.Cursors.Default
        Me.EnemCountFmtCheck.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.EnemCountFmtCheck.ForeColor = System.Drawing.SystemColors.ControlText
        Me.EnemCountFmtCheck.Location = New System.Drawing.Point(16, 137)
        Me.EnemCountFmtCheck.Name = "EnemCountFmtCheck"
        Me.EnemCountFmtCheck.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.EnemCountFmtCheck.Size = New System.Drawing.Size(610, 25)
        Me.EnemCountFmtCheck.TabIndex = 30
        Me.EnemCountFmtCheck.Text = "Show Enemy Count in Hexidecimal (off = Decimal)"
        Me.EnemCountFmtCheck.UseVisualStyleBackColor = False
        '
        'StealFocusCheck
        '
        Me.StealFocusCheck.BackColor = System.Drawing.SystemColors.Control
        Me.StealFocusCheck.Cursor = System.Windows.Forms.Cursors.Default
        Me.StealFocusCheck.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.StealFocusCheck.ForeColor = System.Drawing.SystemColors.ControlText
        Me.StealFocusCheck.Location = New System.Drawing.Point(16, 117)
        Me.StealFocusCheck.Name = "StealFocusCheck"
        Me.StealFocusCheck.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.StealFocusCheck.Size = New System.Drawing.Size(610, 25)
        Me.StealFocusCheck.TabIndex = 23
        Me.StealFocusCheck.Text = "Allow level screen to steal focus when below cursor."
        Me.StealFocusCheck.UseVisualStyleBackColor = False
        '
        'ScrSprAllCheck
        '
        Me.ScrSprAllCheck.BackColor = System.Drawing.SystemColors.Control
        Me.ScrSprAllCheck.Cursor = System.Windows.Forms.Cursors.Default
        Me.ScrSprAllCheck.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ScrSprAllCheck.ForeColor = System.Drawing.SystemColors.ControlText
        Me.ScrSprAllCheck.Location = New System.Drawing.Point(36, 97)
        Me.ScrSprAllCheck.Name = "ScrSprAllCheck"
        Me.ScrSprAllCheck.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.ScrSprAllCheck.Size = New System.Drawing.Size(610, 25)
        Me.ScrSprAllCheck.TabIndex = 22
        Me.ScrSprAllCheck.Text = "Set data for all screens, rather than to stop at screen with last enemy."
        Me.ScrSprAllCheck.UseVisualStyleBackColor = False
        '
        'ScrSprCheck
        '
        Me.ScrSprCheck.BackColor = System.Drawing.SystemColors.Control
        Me.ScrSprCheck.Cursor = System.Windows.Forms.Cursors.Default
        Me.ScrSprCheck.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ScrSprCheck.ForeColor = System.Drawing.SystemColors.ControlText
        Me.ScrSprCheck.Location = New System.Drawing.Point(16, 57)
        Me.ScrSprCheck.Name = "ScrSprCheck"
        Me.ScrSprCheck.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.ScrSprCheck.Size = New System.Drawing.Size(610, 44)
        Me.ScrSprCheck.TabIndex = 17
        Me.ScrSprCheck.Text = "Update Screen Sprite Reference when ins/del/move." & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "(data is used when starting at" &
    " Continue Points)"
        Me.ScrSprCheck.UseVisualStyleBackColor = False
        '
        'SortXCheck
        '
        Me.SortXCheck.BackColor = System.Drawing.SystemColors.Control
        Me.SortXCheck.Cursor = System.Windows.Forms.Cursors.Default
        Me.SortXCheck.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SortXCheck.ForeColor = System.Drawing.SystemColors.ControlText
        Me.SortXCheck.Location = New System.Drawing.Point(16, 37)
        Me.SortXCheck.Name = "SortXCheck"
        Me.SortXCheck.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.SortXCheck.Size = New System.Drawing.Size(610, 25)
        Me.SortXCheck.TabIndex = 16
        Me.SortXCheck.Text = "Sort Enemy Order by X Coordinate when moving on/between screens."
        Me.SortXCheck.UseVisualStyleBackColor = False
        '
        'SortScrCheck
        '
        Me.SortScrCheck.BackColor = System.Drawing.SystemColors.Control
        Me.SortScrCheck.Cursor = System.Windows.Forms.Cursors.Default
        Me.SortScrCheck.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SortScrCheck.ForeColor = System.Drawing.SystemColors.ControlText
        Me.SortScrCheck.Location = New System.Drawing.Point(16, 17)
        Me.SortScrCheck.Name = "SortScrCheck"
        Me.SortScrCheck.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.SortScrCheck.Size = New System.Drawing.Size(610, 25)
        Me.SortScrCheck.TabIndex = 15
        Me.SortScrCheck.Text = "Sort Enemy Order by Screen when moving enemies between screens."
        Me.SortScrCheck.UseVisualStyleBackColor = False
        '
        'PALReloadBtn
        '
        Me.PALReloadBtn.BackColor = System.Drawing.SystemColors.Control
        Me.PALReloadBtn.Cursor = System.Windows.Forms.Cursors.Default
        Me.PALReloadBtn.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.PALReloadBtn.ForeColor = System.Drawing.SystemColors.ControlText
        Me.PALReloadBtn.Location = New System.Drawing.Point(527, 100)
        Me.PALReloadBtn.Name = "PALReloadBtn"
        Me.PALReloadBtn.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.PALReloadBtn.Size = New System.Drawing.Size(114, 24)
        Me.PALReloadBtn.TabIndex = 7
        Me.PALReloadBtn.Text = "Reload Now"
        Me.PALReloadBtn.UseVisualStyleBackColor = False
        '
        'PALBrowseBtn
        '
        Me.PALBrowseBtn.BackColor = System.Drawing.SystemColors.Control
        Me.PALBrowseBtn.Cursor = System.Windows.Forms.Cursors.Default
        Me.PALBrowseBtn.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.PALBrowseBtn.ForeColor = System.Drawing.SystemColors.ControlText
        Me.PALBrowseBtn.Location = New System.Drawing.Point(568, 73)
        Me.PALBrowseBtn.Name = "PALBrowseBtn"
        Me.PALBrowseBtn.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.PALBrowseBtn.Size = New System.Drawing.Size(73, 24)
        Me.PALBrowseBtn.TabIndex = 5
        Me.PALBrowseBtn.Text = "Browse.."
        Me.PALBrowseBtn.UseVisualStyleBackColor = False
        '
        'EmuBrowseBtn
        '
        Me.EmuBrowseBtn.BackColor = System.Drawing.SystemColors.Control
        Me.EmuBrowseBtn.Cursor = System.Windows.Forms.Cursors.Default
        Me.EmuBrowseBtn.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.EmuBrowseBtn.ForeColor = System.Drawing.SystemColors.ControlText
        Me.EmuBrowseBtn.Location = New System.Drawing.Point(568, 22)
        Me.EmuBrowseBtn.Name = "EmuBrowseBtn"
        Me.EmuBrowseBtn.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.EmuBrowseBtn.Size = New System.Drawing.Size(73, 24)
        Me.EmuBrowseBtn.TabIndex = 4
        Me.EmuBrowseBtn.Text = "Browse.."
        Me.EmuBrowseBtn.UseVisualStyleBackColor = False
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.SystemColors.Control
        Me.Label3.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label3.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label3.Location = New System.Drawing.Point(11, 48)
        Me.Label3.Name = "Label3"
        Me.Label3.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label3.Size = New System.Drawing.Size(209, 24)
        Me.Label3.TabIndex = 31
        Me.Label3.Text = "Defined Shell Command (F11):"
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.SystemColors.Control
        Me.Label2.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label2.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label2.Location = New System.Drawing.Point(11, 75)
        Me.Label2.Name = "Label2"
        Me.Label2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label2.Size = New System.Drawing.Size(138, 23)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "NES Palette File:"
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.SystemColors.Control
        Me.Label1.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label1.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label1.Location = New System.Drawing.Point(11, 3)
        Me.Label1.Name = "Label1"
        Me.Label1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label1.Size = New System.Drawing.Size(625, 22)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Emulator full filename for Test feature (F9) (emulator must support rom name at c" &
    "ommand line):"
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.SystemColors.Control
        Me.GroupBox1.Controls.Add(Me.ChkAutoloadROM)
        Me.GroupBox1.Controls.Add(Me.EffSprSimCheck)
        Me.GroupBox1.Controls.Add(Me.DetectChangeCheck)
        Me.GroupBox1.Controls.Add(Me.ScrollSearchCheck)
        Me.GroupBox1.Controls.Add(Me.SBDAlg2Check)
        Me.GroupBox1.Controls.Add(Me.Scroll0Check)
        Me.GroupBox1.Controls.Add(Me.CACheck)
        Me.GroupBox1.Controls.Add(Me.PACheck)
        Me.GroupBox1.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.GroupBox1.Location = New System.Drawing.Point(8, 103)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.GroupBox1.Size = New System.Drawing.Size(633, 230)
        Me.GroupBox1.TabIndex = 75
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Misc"
        '
        'EffSprSimCheck
        '
        Me.EffSprSimCheck.BackColor = System.Drawing.SystemColors.Control
        Me.EffSprSimCheck.Cursor = System.Windows.Forms.Cursors.Default
        Me.EffSprSimCheck.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.EffSprSimCheck.ForeColor = System.Drawing.SystemColors.ControlText
        Me.EffSprSimCheck.Location = New System.Drawing.Point(16, 117)
        Me.EffSprSimCheck.Name = "EffSprSimCheck"
        Me.EffSprSimCheck.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.EffSprSimCheck.Size = New System.Drawing.Size(610, 25)
        Me.EffSprSimCheck.TabIndex = 42
        Me.EffSprSimCheck.Text = "Enable Simulation of effect sprites (for MM4 / MM5)"
        Me.EffSprSimCheck.UseVisualStyleBackColor = False
        '
        'DetectChangeCheck
        '
        Me.DetectChangeCheck.BackColor = System.Drawing.SystemColors.Control
        Me.DetectChangeCheck.Cursor = System.Windows.Forms.Cursors.Default
        Me.DetectChangeCheck.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DetectChangeCheck.ForeColor = System.Drawing.SystemColors.ControlText
        Me.DetectChangeCheck.Location = New System.Drawing.Point(16, 47)
        Me.DetectChangeCheck.Name = "DetectChangeCheck"
        Me.DetectChangeCheck.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.DetectChangeCheck.Size = New System.Drawing.Size(610, 25)
        Me.DetectChangeCheck.TabIndex = 41
        Me.DetectChangeCheck.Text = "Detect change to loaded file by other programs and ask to Re-load."
        Me.DetectChangeCheck.UseVisualStyleBackColor = False
        '
        'ScrollSearchCheck
        '
        Me.ScrollSearchCheck.BackColor = System.Drawing.SystemColors.Control
        Me.ScrollSearchCheck.Cursor = System.Windows.Forms.Cursors.Default
        Me.ScrollSearchCheck.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ScrollSearchCheck.ForeColor = System.Drawing.SystemColors.ControlText
        Me.ScrollSearchCheck.Location = New System.Drawing.Point(16, 147)
        Me.ScrollSearchCheck.Name = "ScrollSearchCheck"
        Me.ScrollSearchCheck.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.ScrollSearchCheck.Size = New System.Drawing.Size(610, 24)
        Me.ScrollSearchCheck.TabIndex = 40
        Me.ScrollSearchCheck.Text = "Automatic Scroll Map Position search."
        Me.ScrollSearchCheck.UseVisualStyleBackColor = False
        '
        'SBDAlg2Check
        '
        Me.SBDAlg2Check.BackColor = System.Drawing.SystemColors.Control
        Me.SBDAlg2Check.Cursor = System.Windows.Forms.Cursors.Default
        Me.SBDAlg2Check.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SBDAlg2Check.ForeColor = System.Drawing.SystemColors.ControlText
        Me.SBDAlg2Check.Location = New System.Drawing.Point(16, 197)
        Me.SBDAlg2Check.Name = "SBDAlg2Check"
        Me.SBDAlg2Check.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.SBDAlg2Check.Size = New System.Drawing.Size(610, 25)
        Me.SBDAlg2Check.TabIndex = 39
        Me.SBDAlg2Check.Text = "SBD Editor - Convert order 2 (May lower probability of reaching Metametatiles lim" &
    "it). "
        Me.SBDAlg2Check.UseVisualStyleBackColor = False
        '
        'Scroll0Check
        '
        Me.Scroll0Check.BackColor = System.Drawing.SystemColors.Control
        Me.Scroll0Check.Cursor = System.Windows.Forms.Cursors.Default
        Me.Scroll0Check.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Scroll0Check.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Scroll0Check.Location = New System.Drawing.Point(16, 167)
        Me.Scroll0Check.Name = "Scroll0Check"
        Me.Scroll0Check.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Scroll0Check.Size = New System.Drawing.Size(610, 25)
        Me.Scroll0Check.TabIndex = 38
        Me.Scroll0Check.Text = "Skip Scroll Map with Type 0 when editing corresponding screens"
        Me.Scroll0Check.UseVisualStyleBackColor = False
        '
        'CACheck
        '
        Me.CACheck.BackColor = System.Drawing.SystemColors.Control
        Me.CACheck.Cursor = System.Windows.Forms.Cursors.Default
        Me.CACheck.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CACheck.ForeColor = System.Drawing.SystemColors.ControlText
        Me.CACheck.Location = New System.Drawing.Point(16, 97)
        Me.CACheck.Name = "CACheck"
        Me.CACheck.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.CACheck.Size = New System.Drawing.Size(610, 25)
        Me.CACheck.TabIndex = 37
        Me.CACheck.Text = "Enable Simulation of CHR Animations"
        Me.CACheck.UseVisualStyleBackColor = False
        '
        'PACheck
        '
        Me.PACheck.BackColor = System.Drawing.SystemColors.Control
        Me.PACheck.Cursor = System.Windows.Forms.Cursors.Default
        Me.PACheck.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.PACheck.ForeColor = System.Drawing.SystemColors.ControlText
        Me.PACheck.Location = New System.Drawing.Point(16, 77)
        Me.PACheck.Name = "PACheck"
        Me.PACheck.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.PACheck.Size = New System.Drawing.Size(610, 25)
        Me.PACheck.TabIndex = 36
        Me.PACheck.Text = "Enable Simulation of Palette-Animations"
        Me.PACheck.UseVisualStyleBackColor = False
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(61, 4)
        '
        'Config
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 14.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.ClientSize = New System.Drawing.Size(647, 717)
        Me.Controls.Add(Me.PALReloadBtn)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.ShellTB)
        Me.Controls.Add(Me.Frame4)
        Me.Controls.Add(Me.Frame3)
        Me.Controls.Add(Me.Frame2)
        Me.Controls.Add(Me.Frame1)
        Me.Controls.Add(Me.PALBrowseBtn)
        Me.Controls.Add(Me.EmuBrowseBtn)
        Me.Controls.Add(Me.PALTB)
        Me.Controls.Add(Me.EmuTB)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Cursor = System.Windows.Forms.Cursors.Default
        Me.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.Location = New System.Drawing.Point(3, 29)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Config"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Text = "Configuration"
        Me.Frame4.ResumeLayout(False)
        Me.Frame3.ResumeLayout(False)
        Me.Frame2.ResumeLayout(False)
        Me.Frame1.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Public WithEvents GroupBox1 As GroupBox
    Public WithEvents EffSprSimCheck As CheckBox
    Public WithEvents DetectChangeCheck As CheckBox
    Public WithEvents ScrollSearchCheck As CheckBox
    Public WithEvents SBDAlg2Check As CheckBox
    Public WithEvents Scroll0Check As CheckBox
    Public WithEvents CACheck As CheckBox
    Public WithEvents PACheck As CheckBox
    Public WithEvents ChkAutoloadROM As CheckBox
    Friend WithEvents ContextMenuStrip1 As ContextMenuStrip
#End Region
End Class