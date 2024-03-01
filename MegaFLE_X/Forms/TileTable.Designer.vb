<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> Partial Class TileTable
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
	Public WithEvents CHRAnimFrame As System.Windows.Forms.Button
	Public WithEvents CHRAnimSS As System.Windows.Forms.Button
	Public WithEvents TRotaBtn As System.Windows.Forms.Button
	Public WithEvents TShiftVBtn As System.Windows.Forms.Button
	Public WithEvents TShiftHBtn As System.Windows.Forms.Button
	Public WithEvents CopyBtn As System.Windows.Forms.Button
	Public WithEvents PasteBtn As System.Windows.Forms.Button
	Public WithEvents TilePic As System.Windows.Forms.PictureBox
	Public WithEvents pic1 As System.Windows.Forms.PictureBox
	Public WithEvents CHRAnimCtrlLab As System.Windows.Forms.Label
    Public WithEvents CurTileLab As System.Windows.Forms.Label
    Public WithEvents _PalShape_15 As System.Windows.Forms.Label
    Public WithEvents _PalShape_14 As System.Windows.Forms.Label
    Public WithEvents _PalShape_13 As System.Windows.Forms.Label
    Public WithEvents _PalShape_12 As System.Windows.Forms.Label
    Public WithEvents _PalShapeBorder_3 As System.Windows.Forms.Label
    Public WithEvents _PalShape_11 As System.Windows.Forms.Label
    Public WithEvents _PalShape_10 As System.Windows.Forms.Label
    Public WithEvents _PalShape_9 As System.Windows.Forms.Label
    Public WithEvents _PalShape_8 As System.Windows.Forms.Label
    Public WithEvents _PalShapeBorder_2 As System.Windows.Forms.Label
    Public WithEvents _PalShape_7 As System.Windows.Forms.Label
    Public WithEvents _PalShape_6 As System.Windows.Forms.Label
    Public WithEvents _PalShape_5 As System.Windows.Forms.Label
    Public WithEvents _PalShape_4 As System.Windows.Forms.Label
    Public WithEvents _PalShapeBorder_1 As System.Windows.Forms.Label
    Public WithEvents _PalShape_3 As System.Windows.Forms.Label
    Public WithEvents _PalShape_2 As System.Windows.Forms.Label
    Public WithEvents _PalShape_1 As System.Windows.Forms.Label
    Public WithEvents _ColShapeBorder_3 As System.Windows.Forms.Label
    Public WithEvents _ColShapeBorder_2 As System.Windows.Forms.Label
    Public WithEvents _ColShapeBorder_1 As System.Windows.Forms.Label
    Public WithEvents _ColShapeBorder_0 As System.Windows.Forms.Label
    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(TileTable))
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.BtnClearUnusedTiles = New System.Windows.Forms.Button()
        Me.BtnClearDuplicated = New System.Windows.Forms.Button()
        Me.Text9 = New System.Windows.Forms.TextBox()
        Me.BGSrcTB = New System.Windows.Forms.TextBox()
        Me.CHRIDUD = New System.Windows.Forms.NumericUpDown()
        Me.DelayUD = New System.Windows.Forms.NumericUpDown()
        Me.Text8 = New System.Windows.Forms.TextBox()
        Me.CATB = New System.Windows.Forms.TextBox()
        Me._BGCHRUD_0 = New System.Windows.Forms.NumericUpDown()
        Me._BGCHRUD_1 = New System.Windows.Forms.NumericUpDown()
        Me.CHRAnimFrame = New System.Windows.Forms.Button()
        Me.CHRAnimSS = New System.Windows.Forms.Button()
        Me.CopyBtn = New System.Windows.Forms.Button()
        Me.PasteBtn = New System.Windows.Forms.Button()
        Me.CHRAnimCtrlLab = New System.Windows.Forms.Label()
        Me.CurTileLab = New System.Windows.Forms.Label()
        Me._PalShape_15 = New System.Windows.Forms.Label()
        Me._PalShape_14 = New System.Windows.Forms.Label()
        Me._PalShape_13 = New System.Windows.Forms.Label()
        Me._PalShape_12 = New System.Windows.Forms.Label()
        Me._PalShapeBorder_3 = New System.Windows.Forms.Label()
        Me._PalShape_11 = New System.Windows.Forms.Label()
        Me._PalShape_10 = New System.Windows.Forms.Label()
        Me._PalShape_9 = New System.Windows.Forms.Label()
        Me._PalShape_8 = New System.Windows.Forms.Label()
        Me._PalShapeBorder_2 = New System.Windows.Forms.Label()
        Me._PalShape_7 = New System.Windows.Forms.Label()
        Me._PalShape_6 = New System.Windows.Forms.Label()
        Me._PalShape_5 = New System.Windows.Forms.Label()
        Me._PalShape_4 = New System.Windows.Forms.Label()
        Me._PalShapeBorder_1 = New System.Windows.Forms.Label()
        Me._PalShape_3 = New System.Windows.Forms.Label()
        Me._PalShape_2 = New System.Windows.Forms.Label()
        Me._PalShape_1 = New System.Windows.Forms.Label()
        Me._ColShapeBorder_3 = New System.Windows.Forms.Label()
        Me._ColShapeBorder_2 = New System.Windows.Forms.Label()
        Me._ColShapeBorder_1 = New System.Windows.Forms.Label()
        Me._ColShapeBorder_0 = New System.Windows.Forms.Label()
        Me.TRotaBtn = New System.Windows.Forms.Button()
        Me.TShiftVBtn = New System.Windows.Forms.Button()
        Me.TShiftHBtn = New System.Windows.Forms.Button()
        Me.TilePic = New System.Windows.Forms.PictureBox()
        Me.pic1 = New System.Windows.Forms.PictureBox()
        Me.contourLabel = New System.Windows.Forms.Label()
        Me._PalShapeBorder_0 = New System.Windows.Forms.Label()
        Me._PalShape_0 = New System.Windows.Forms.Label()
        Me.BtnShowSelected = New System.Windows.Forms.Button()
        Me.BtnMoreOptions = New System.Windows.Forms.Button()
        Me.GbxChrExtract = New System.Windows.Forms.GroupBox()
        Me.BtnMME_Extract = New System.Windows.Forms.Button()
        Me.Command14 = New System.Windows.Forms.Button()
        Me.Command9 = New System.Windows.Forms.Button()
        Me.Text7 = New System.Windows.Forms.TextBox()
        Me.Text6 = New System.Windows.Forms.TextBox()
        Me.Text4 = New System.Windows.Forms.TextBox()
        Me.Text3 = New System.Windows.Forms.TextBox()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.GbxChrExportAsHex = New System.Windows.Forms.GroupBox()
        Me.Command5 = New System.Windows.Forms.Button()
        Me.Command11 = New System.Windows.Forms.Button()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.GbxCHR_AnimEd = New System.Windows.Forms.GroupBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me._BGDst_1 = New System.Windows.Forms.RadioButton()
        Me._BGDst_0 = New System.Windows.Forms.RadioButton()
        Me.BGFrameSelect = New System.Windows.Forms.HScrollBar()
        Me.FramesUD = New System.Windows.Forms.NumericUpDown()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.GbxForceCHR_Bank = New System.Windows.Forms.GroupBox()
        Me._Option1_1 = New System.Windows.Forms.RadioButton()
        Me._Option1_0 = New System.Windows.Forms.RadioButton()
        Me.Command10 = New System.Windows.Forms.Button()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.GbxForceCHR_Anim = New System.Windows.Forms.GroupBox()
        Me.Command7 = New System.Windows.Forms.Button()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.GbxBG_CHR_Bank = New System.Windows.Forms.GroupBox()
        Me.BGCHRLab1 = New System.Windows.Forms.Label()
        Me.BGCHRLab2 = New System.Windows.Forms.Label()
        CType(Me.CHRIDUD, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DelayUD, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me._BGCHRUD_0, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me._BGCHRUD_1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TilePic, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pic1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GbxChrExtract.SuspendLayout()
        Me.GbxChrExportAsHex.SuspendLayout()
        Me.GbxCHR_AnimEd.SuspendLayout()
        CType(Me.FramesUD, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GbxForceCHR_Bank.SuspendLayout()
        Me.GbxForceCHR_Anim.SuspendLayout()
        Me.GbxBG_CHR_Bank.SuspendLayout()
        Me.SuspendLayout()
        '
        'ToolTip1
        '
        Me.ToolTip1.AutoPopDelay = 5000
        Me.ToolTip1.InitialDelay = 500
        Me.ToolTip1.ReshowDelay = 100
        '
        'BtnClearUnusedTiles
        '
        Me.BtnClearUnusedTiles.BackColor = System.Drawing.SystemColors.Control
        Me.BtnClearUnusedTiles.Cursor = System.Windows.Forms.Cursors.Default
        Me.BtnClearUnusedTiles.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold)
        Me.BtnClearUnusedTiles.ForeColor = System.Drawing.SystemColors.ControlText
        Me.BtnClearUnusedTiles.Location = New System.Drawing.Point(471, 24)
        Me.BtnClearUnusedTiles.Name = "BtnClearUnusedTiles"
        Me.BtnClearUnusedTiles.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.BtnClearUnusedTiles.Size = New System.Drawing.Size(91, 53)
        Me.BtnClearUnusedTiles.TabIndex = 40
        Me.BtnClearUnusedTiles.Text = "Clear Unused Tiles"
        Me.ToolTip1.SetToolTip(Me.BtnClearUnusedTiles, "Clear all unused Tiles.")
        Me.BtnClearUnusedTiles.UseVisualStyleBackColor = False
        '
        'BtnClearDuplicated
        '
        Me.BtnClearDuplicated.BackColor = System.Drawing.SystemColors.Control
        Me.BtnClearDuplicated.Cursor = System.Windows.Forms.Cursors.Default
        Me.BtnClearDuplicated.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold)
        Me.BtnClearDuplicated.ForeColor = System.Drawing.SystemColors.ControlText
        Me.BtnClearDuplicated.Location = New System.Drawing.Point(471, 82)
        Me.BtnClearDuplicated.Name = "BtnClearDuplicated"
        Me.BtnClearDuplicated.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.BtnClearDuplicated.Size = New System.Drawing.Size(91, 53)
        Me.BtnClearDuplicated.TabIndex = 42
        Me.BtnClearDuplicated.Text = "Clear Duplicated Metatiles"
        Me.ToolTip1.SetToolTip(Me.BtnClearDuplicated, "Clear all duplicated AND unused Tiles." & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Only first duplicated occurence met in th" &
        "e" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "list will be kept and Metatiles will be" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "adjusted to use the one that is kept" &
        ".")
        Me.BtnClearDuplicated.UseVisualStyleBackColor = False
        '
        'Text9
        '
        Me.Text9.AcceptsReturn = True
        Me.Text9.BackColor = System.Drawing.SystemColors.Window
        Me.Text9.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.Text9.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Text9.ForeColor = System.Drawing.SystemColors.WindowText
        Me.Text9.Location = New System.Drawing.Point(112, 16)
        Me.Text9.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.Text9.MaxLength = 0
        Me.Text9.Name = "Text9"
        Me.Text9.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Text9.Size = New System.Drawing.Size(101, 23)
        Me.Text9.TabIndex = 43
        Me.Text9.Text = "chrmap.hex"
        Me.ToolTip1.SetToolTip(Me.Text9, "May be used to load custom graphic pages for screens.")
        '
        'BGSrcTB
        '
        Me.BGSrcTB.AcceptsReturn = True
        Me.BGSrcTB.BackColor = System.Drawing.SystemColors.Window
        Me.BGSrcTB.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.BGSrcTB.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BGSrcTB.ForeColor = System.Drawing.SystemColors.WindowText
        Me.BGSrcTB.Location = New System.Drawing.Point(25, 116)
        Me.BGSrcTB.MaxLength = 0
        Me.BGSrcTB.Name = "BGSrcTB"
        Me.BGSrcTB.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.BGSrcTB.Size = New System.Drawing.Size(25, 23)
        Me.BGSrcTB.TabIndex = 68
        Me.ToolTip1.SetToolTip(Me.BGSrcTB, "CHR Bank Page #")
        '
        'CHRIDUD
        '
        Me.CHRIDUD.Hexadecimal = True
        Me.CHRIDUD.Location = New System.Drawing.Point(44, 22)
        Me.CHRIDUD.Maximum = New Decimal(New Integer() {7, 0, 0, 0})
        Me.CHRIDUD.Name = "CHRIDUD"
        Me.CHRIDUD.Size = New System.Drawing.Size(45, 23)
        Me.CHRIDUD.TabIndex = 67
        Me.ToolTip1.SetToolTip(Me.CHRIDUD, "CHR Animation ID # to edit")
        '
        'DelayUD
        '
        Me.DelayUD.Hexadecimal = True
        Me.DelayUD.Location = New System.Drawing.Point(115, 46)
        Me.DelayUD.Maximum = New Decimal(New Integer() {255, 0, 0, 0})
        Me.DelayUD.Name = "DelayUD"
        Me.DelayUD.Size = New System.Drawing.Size(45, 23)
        Me.DelayUD.TabIndex = 66
        Me.ToolTip1.SetToolTip(Me.DelayUD, "Number of frames to wait between each swap")
        '
        'Text8
        '
        Me.Text8.AcceptsReturn = True
        Me.Text8.BackColor = System.Drawing.SystemColors.Window
        Me.Text8.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.Text8.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Text8.ForeColor = System.Drawing.SystemColors.WindowText
        Me.Text8.Location = New System.Drawing.Point(156, 10)
        Me.Text8.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.Text8.MaxLength = 0
        Me.Text8.Name = "Text8"
        Me.Text8.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Text8.Size = New System.Drawing.Size(42, 23)
        Me.Text8.TabIndex = 58
        Me.Text8.Text = "40"
        Me.ToolTip1.SetToolTip(Me.Text8, "Modifies CHR Bank without saving changes to the ROM.")
        '
        'CATB
        '
        Me.CATB.AcceptsReturn = True
        Me.CATB.BackColor = System.Drawing.SystemColors.Window
        Me.CATB.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.CATB.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CATB.ForeColor = System.Drawing.SystemColors.WindowText
        Me.CATB.Location = New System.Drawing.Point(117, 10)
        Me.CATB.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.CATB.MaxLength = 0
        Me.CATB.Name = "CATB"
        Me.CATB.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.CATB.Size = New System.Drawing.Size(42, 23)
        Me.CATB.TabIndex = 57
        Me.CATB.Text = "0"
        Me.ToolTip1.SetToolTip(Me.CATB, "Modifies CHR Animation Bank without saving changes to ROM (MM5, MM6)")
        '
        '_BGCHRUD_0
        '
        Me._BGCHRUD_0.Hexadecimal = True
        Me._BGCHRUD_0.Location = New System.Drawing.Point(111, 10)
        Me._BGCHRUD_0.Maximum = New Decimal(New Integer() {255, 0, 0, 0})
        Me._BGCHRUD_0.Name = "_BGCHRUD_0"
        Me._BGCHRUD_0.Size = New System.Drawing.Size(45, 23)
        Me._BGCHRUD_0.TabIndex = 81
        Me.ToolTip1.SetToolTip(Me._BGCHRUD_0, "NES PPU Tile 00-7F")
        '
        '_BGCHRUD_1
        '
        Me._BGCHRUD_1.Hexadecimal = True
        Me._BGCHRUD_1.Location = New System.Drawing.Point(266, 10)
        Me._BGCHRUD_1.Maximum = New Decimal(New Integer() {255, 0, 0, 0})
        Me._BGCHRUD_1.Name = "_BGCHRUD_1"
        Me._BGCHRUD_1.Size = New System.Drawing.Size(45, 23)
        Me._BGCHRUD_1.TabIndex = 82
        Me.ToolTip1.SetToolTip(Me._BGCHRUD_1, "NES PPU Tile 80-FF")
        '
        'CHRAnimFrame
        '
        Me.CHRAnimFrame.BackColor = System.Drawing.SystemColors.Control
        Me.CHRAnimFrame.Cursor = System.Windows.Forms.Cursors.Default
        Me.CHRAnimFrame.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CHRAnimFrame.ForeColor = System.Drawing.SystemColors.ControlText
        Me.CHRAnimFrame.Location = New System.Drawing.Point(417, 240)
        Me.CHRAnimFrame.Name = "CHRAnimFrame"
        Me.CHRAnimFrame.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.CHRAnimFrame.Size = New System.Drawing.Size(49, 22)
        Me.CHRAnimFrame.TabIndex = 11
        Me.CHRAnimFrame.Text = "Frame"
        Me.CHRAnimFrame.UseVisualStyleBackColor = False
        Me.CHRAnimFrame.Visible = False
        '
        'CHRAnimSS
        '
        Me.CHRAnimSS.BackColor = System.Drawing.SystemColors.Control
        Me.CHRAnimSS.Cursor = System.Windows.Forms.Cursors.Default
        Me.CHRAnimSS.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CHRAnimSS.ForeColor = System.Drawing.SystemColors.ControlText
        Me.CHRAnimSS.Location = New System.Drawing.Point(366, 240)
        Me.CHRAnimSS.Name = "CHRAnimSS"
        Me.CHRAnimSS.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.CHRAnimSS.Size = New System.Drawing.Size(49, 22)
        Me.CHRAnimSS.TabIndex = 10
        Me.CHRAnimSS.Text = "Stop"
        Me.CHRAnimSS.UseVisualStyleBackColor = False
        Me.CHRAnimSS.Visible = False
        '
        'CopyBtn
        '
        Me.CopyBtn.BackColor = System.Drawing.SystemColors.Control
        Me.CopyBtn.Cursor = System.Windows.Forms.Cursors.Default
        Me.CopyBtn.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CopyBtn.ForeColor = System.Drawing.SystemColors.ControlText
        Me.CopyBtn.Location = New System.Drawing.Point(264, 32)
        Me.CopyBtn.Name = "CopyBtn"
        Me.CopyBtn.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.CopyBtn.Size = New System.Drawing.Size(32, 57)
        Me.CopyBtn.TabIndex = 3
        Me.CopyBtn.Text = "=>"
        Me.CopyBtn.UseVisualStyleBackColor = False
        '
        'PasteBtn
        '
        Me.PasteBtn.BackColor = System.Drawing.SystemColors.Control
        Me.PasteBtn.Cursor = System.Windows.Forms.Cursors.Default
        Me.PasteBtn.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.PasteBtn.ForeColor = System.Drawing.SystemColors.ControlText
        Me.PasteBtn.Location = New System.Drawing.Point(264, 96)
        Me.PasteBtn.Name = "PasteBtn"
        Me.PasteBtn.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.PasteBtn.Size = New System.Drawing.Size(32, 57)
        Me.PasteBtn.TabIndex = 2
        Me.PasteBtn.Text = "<="
        Me.PasteBtn.UseVisualStyleBackColor = False
        '
        'CHRAnimCtrlLab
        '
        Me.CHRAnimCtrlLab.BackColor = System.Drawing.SystemColors.Control
        Me.CHRAnimCtrlLab.Cursor = System.Windows.Forms.Cursors.Default
        Me.CHRAnimCtrlLab.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CHRAnimCtrlLab.ForeColor = System.Drawing.SystemColors.ControlText
        Me.CHRAnimCtrlLab.Location = New System.Drawing.Point(265, 240)
        Me.CHRAnimCtrlLab.Name = "CHRAnimCtrlLab"
        Me.CHRAnimCtrlLab.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.CHRAnimCtrlLab.Size = New System.Drawing.Size(127, 20)
        Me.CHRAnimCtrlLab.TabIndex = 9
        Me.CHRAnimCtrlLab.Text = "CHR Anim Control:"
        Me.CHRAnimCtrlLab.Visible = False
        '
        'CurTileLab
        '
        Me.CurTileLab.BackColor = System.Drawing.SystemColors.Control
        Me.CurTileLab.Cursor = System.Windows.Forms.Cursors.Default
        Me.CurTileLab.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CurTileLab.ForeColor = System.Drawing.SystemColors.ControlText
        Me.CurTileLab.Location = New System.Drawing.Point(301, 5)
        Me.CurTileLab.Name = "CurTileLab"
        Me.CurTileLab.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.CurTileLab.Size = New System.Drawing.Size(98, 16)
        Me.CurTileLab.TabIndex = 7
        Me.CurTileLab.Text = "Tile:"
        '
        '_PalShape_15
        '
        Me._PalShape_15.BackColor = System.Drawing.Color.Black
        Me._PalShape_15.Location = New System.Drawing.Point(374, 216)
        Me._PalShape_15.Name = "_PalShape_15"
        Me._PalShape_15.Size = New System.Drawing.Size(25, 16)
        Me._PalShape_15.TabIndex = 12
        '
        '_PalShape_14
        '
        Me._PalShape_14.BackColor = System.Drawing.Color.Black
        Me._PalShape_14.Location = New System.Drawing.Point(349, 216)
        Me._PalShape_14.Name = "_PalShape_14"
        Me._PalShape_14.Size = New System.Drawing.Size(25, 16)
        Me._PalShape_14.TabIndex = 13
        '
        '_PalShape_13
        '
        Me._PalShape_13.BackColor = System.Drawing.Color.Black
        Me._PalShape_13.Location = New System.Drawing.Point(324, 216)
        Me._PalShape_13.Name = "_PalShape_13"
        Me._PalShape_13.Size = New System.Drawing.Size(25, 16)
        Me._PalShape_13.TabIndex = 14
        '
        '_PalShape_12
        '
        Me._PalShape_12.BackColor = System.Drawing.Color.Black
        Me._PalShape_12.Location = New System.Drawing.Point(299, 216)
        Me._PalShape_12.Name = "_PalShape_12"
        Me._PalShape_12.Size = New System.Drawing.Size(25, 16)
        Me._PalShape_12.TabIndex = 15
        '
        '_PalShapeBorder_3
        '
        Me._PalShapeBorder_3.BackColor = System.Drawing.Color.White
        Me._PalShapeBorder_3.Location = New System.Drawing.Point(298, 215)
        Me._PalShapeBorder_3.Name = "_PalShapeBorder_3"
        Me._PalShapeBorder_3.Size = New System.Drawing.Size(102, 18)
        Me._PalShapeBorder_3.TabIndex = 16
        '
        '_PalShape_11
        '
        Me._PalShape_11.BackColor = System.Drawing.Color.Black
        Me._PalShape_11.Location = New System.Drawing.Point(374, 200)
        Me._PalShape_11.Name = "_PalShape_11"
        Me._PalShape_11.Size = New System.Drawing.Size(25, 16)
        Me._PalShape_11.TabIndex = 17
        '
        '_PalShape_10
        '
        Me._PalShape_10.BackColor = System.Drawing.Color.Black
        Me._PalShape_10.Location = New System.Drawing.Point(349, 200)
        Me._PalShape_10.Name = "_PalShape_10"
        Me._PalShape_10.Size = New System.Drawing.Size(25, 16)
        Me._PalShape_10.TabIndex = 18
        '
        '_PalShape_9
        '
        Me._PalShape_9.BackColor = System.Drawing.Color.Black
        Me._PalShape_9.Location = New System.Drawing.Point(324, 200)
        Me._PalShape_9.Name = "_PalShape_9"
        Me._PalShape_9.Size = New System.Drawing.Size(25, 16)
        Me._PalShape_9.TabIndex = 19
        '
        '_PalShape_8
        '
        Me._PalShape_8.BackColor = System.Drawing.Color.Black
        Me._PalShape_8.Location = New System.Drawing.Point(299, 200)
        Me._PalShape_8.Name = "_PalShape_8"
        Me._PalShape_8.Size = New System.Drawing.Size(25, 16)
        Me._PalShape_8.TabIndex = 20
        '
        '_PalShapeBorder_2
        '
        Me._PalShapeBorder_2.BackColor = System.Drawing.Color.White
        Me._PalShapeBorder_2.Location = New System.Drawing.Point(298, 199)
        Me._PalShapeBorder_2.Name = "_PalShapeBorder_2"
        Me._PalShapeBorder_2.Size = New System.Drawing.Size(102, 18)
        Me._PalShapeBorder_2.TabIndex = 21
        '
        '_PalShape_7
        '
        Me._PalShape_7.BackColor = System.Drawing.Color.Black
        Me._PalShape_7.Location = New System.Drawing.Point(374, 184)
        Me._PalShape_7.Name = "_PalShape_7"
        Me._PalShape_7.Size = New System.Drawing.Size(25, 16)
        Me._PalShape_7.TabIndex = 22
        '
        '_PalShape_6
        '
        Me._PalShape_6.BackColor = System.Drawing.Color.Black
        Me._PalShape_6.Location = New System.Drawing.Point(349, 184)
        Me._PalShape_6.Name = "_PalShape_6"
        Me._PalShape_6.Size = New System.Drawing.Size(25, 16)
        Me._PalShape_6.TabIndex = 23
        '
        '_PalShape_5
        '
        Me._PalShape_5.BackColor = System.Drawing.Color.Black
        Me._PalShape_5.Location = New System.Drawing.Point(324, 184)
        Me._PalShape_5.Name = "_PalShape_5"
        Me._PalShape_5.Size = New System.Drawing.Size(25, 16)
        Me._PalShape_5.TabIndex = 24
        '
        '_PalShape_4
        '
        Me._PalShape_4.BackColor = System.Drawing.Color.Black
        Me._PalShape_4.Location = New System.Drawing.Point(299, 184)
        Me._PalShape_4.Name = "_PalShape_4"
        Me._PalShape_4.Size = New System.Drawing.Size(25, 16)
        Me._PalShape_4.TabIndex = 25
        '
        '_PalShapeBorder_1
        '
        Me._PalShapeBorder_1.BackColor = System.Drawing.Color.White
        Me._PalShapeBorder_1.Location = New System.Drawing.Point(298, 183)
        Me._PalShapeBorder_1.Name = "_PalShapeBorder_1"
        Me._PalShapeBorder_1.Size = New System.Drawing.Size(102, 18)
        Me._PalShapeBorder_1.TabIndex = 26
        '
        '_PalShape_3
        '
        Me._PalShape_3.BackColor = System.Drawing.Color.Black
        Me._PalShape_3.Location = New System.Drawing.Point(374, 168)
        Me._PalShape_3.Name = "_PalShape_3"
        Me._PalShape_3.Size = New System.Drawing.Size(25, 16)
        Me._PalShape_3.TabIndex = 27
        '
        '_PalShape_2
        '
        Me._PalShape_2.BackColor = System.Drawing.Color.Black
        Me._PalShape_2.Location = New System.Drawing.Point(349, 168)
        Me._PalShape_2.Name = "_PalShape_2"
        Me._PalShape_2.Size = New System.Drawing.Size(25, 16)
        Me._PalShape_2.TabIndex = 28
        '
        '_PalShape_1
        '
        Me._PalShape_1.BackColor = System.Drawing.Color.Black
        Me._PalShape_1.Location = New System.Drawing.Point(324, 168)
        Me._PalShape_1.Name = "_PalShape_1"
        Me._PalShape_1.Size = New System.Drawing.Size(25, 16)
        Me._PalShape_1.TabIndex = 29
        '
        '_ColShapeBorder_3
        '
        Me._ColShapeBorder_3.BackColor = System.Drawing.Color.Black
        Me._ColShapeBorder_3.Location = New System.Drawing.Point(436, 93)
        Me._ColShapeBorder_3.Name = "_ColShapeBorder_3"
        Me._ColShapeBorder_3.Size = New System.Drawing.Size(25, 25)
        Me._ColShapeBorder_3.TabIndex = 32
        '
        '_ColShapeBorder_2
        '
        Me._ColShapeBorder_2.BackColor = System.Drawing.Color.Black
        Me._ColShapeBorder_2.Location = New System.Drawing.Point(436, 70)
        Me._ColShapeBorder_2.Name = "_ColShapeBorder_2"
        Me._ColShapeBorder_2.Size = New System.Drawing.Size(25, 25)
        Me._ColShapeBorder_2.TabIndex = 33
        '
        '_ColShapeBorder_1
        '
        Me._ColShapeBorder_1.BackColor = System.Drawing.Color.Black
        Me._ColShapeBorder_1.Location = New System.Drawing.Point(436, 47)
        Me._ColShapeBorder_1.Name = "_ColShapeBorder_1"
        Me._ColShapeBorder_1.Size = New System.Drawing.Size(25, 25)
        Me._ColShapeBorder_1.TabIndex = 34
        '
        '_ColShapeBorder_0
        '
        Me._ColShapeBorder_0.BackColor = System.Drawing.Color.Black
        Me._ColShapeBorder_0.Location = New System.Drawing.Point(436, 24)
        Me._ColShapeBorder_0.Name = "_ColShapeBorder_0"
        Me._ColShapeBorder_0.Size = New System.Drawing.Size(25, 25)
        Me._ColShapeBorder_0.TabIndex = 35
        '
        'TRotaBtn
        '
        Me.TRotaBtn.BackColor = System.Drawing.SystemColors.Control
        Me.TRotaBtn.Cursor = System.Windows.Forms.Cursors.Default
        Me.TRotaBtn.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TRotaBtn.ForeColor = System.Drawing.SystemColors.ControlText
        Me.TRotaBtn.Image = CType(resources.GetObject("TRotaBtn.Image"), System.Drawing.Image)
        Me.TRotaBtn.Location = New System.Drawing.Point(408, 200)
        Me.TRotaBtn.Name = "TRotaBtn"
        Me.TRotaBtn.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.TRotaBtn.Size = New System.Drawing.Size(25, 25)
        Me.TRotaBtn.TabIndex = 6
        Me.TRotaBtn.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.TRotaBtn.UseVisualStyleBackColor = False
        '
        'TShiftVBtn
        '
        Me.TShiftVBtn.BackColor = System.Drawing.SystemColors.Control
        Me.TShiftVBtn.Cursor = System.Windows.Forms.Cursors.Default
        Me.TShiftVBtn.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TShiftVBtn.ForeColor = System.Drawing.SystemColors.ControlText
        Me.TShiftVBtn.Image = CType(resources.GetObject("TShiftVBtn.Image"), System.Drawing.Image)
        Me.TShiftVBtn.Location = New System.Drawing.Point(440, 168)
        Me.TShiftVBtn.Name = "TShiftVBtn"
        Me.TShiftVBtn.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.TShiftVBtn.Size = New System.Drawing.Size(25, 25)
        Me.TShiftVBtn.TabIndex = 5
        Me.TShiftVBtn.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.TShiftVBtn.UseVisualStyleBackColor = False
        '
        'TShiftHBtn
        '
        Me.TShiftHBtn.BackColor = System.Drawing.SystemColors.Control
        Me.TShiftHBtn.Cursor = System.Windows.Forms.Cursors.Default
        Me.TShiftHBtn.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TShiftHBtn.ForeColor = System.Drawing.SystemColors.ControlText
        Me.TShiftHBtn.Image = CType(resources.GetObject("TShiftHBtn.Image"), System.Drawing.Image)
        Me.TShiftHBtn.Location = New System.Drawing.Point(408, 168)
        Me.TShiftHBtn.Name = "TShiftHBtn"
        Me.TShiftHBtn.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.TShiftHBtn.Size = New System.Drawing.Size(25, 25)
        Me.TShiftHBtn.TabIndex = 4
        Me.TShiftHBtn.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.TShiftHBtn.UseVisualStyleBackColor = False
        '
        'TilePic
        '
        Me.TilePic.BackColor = System.Drawing.SystemColors.Control
        Me.TilePic.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.TilePic.Cursor = System.Windows.Forms.Cursors.Default
        Me.TilePic.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TilePic.ForeColor = System.Drawing.SystemColors.ControlText
        Me.TilePic.Location = New System.Drawing.Point(301, 24)
        Me.TilePic.Name = "TilePic"
        Me.TilePic.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.TilePic.Size = New System.Drawing.Size(135, 134)
        Me.TilePic.TabIndex = 1
        Me.TilePic.TabStop = False
        '
        'pic1
        '
        Me.pic1.BackColor = System.Drawing.SystemColors.Control
        Me.pic1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.pic1.Cursor = System.Windows.Forms.Cursors.Default
        Me.pic1.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.pic1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.pic1.Location = New System.Drawing.Point(0, 0)
        Me.pic1.Name = "pic1"
        Me.pic1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.pic1.Size = New System.Drawing.Size(262, 262)
        Me.pic1.TabIndex = 0
        Me.pic1.TabStop = False
        '
        'contourLabel
        '
        Me.contourLabel.BackColor = System.Drawing.Color.Black
        Me.contourLabel.Location = New System.Drawing.Point(298, 167)
        Me.contourLabel.Name = "contourLabel"
        Me.contourLabel.Size = New System.Drawing.Size(102, 66)
        Me.contourLabel.TabIndex = 36
        '
        '_PalShapeBorder_0
        '
        Me._PalShapeBorder_0.BackColor = System.Drawing.Color.White
        Me._PalShapeBorder_0.Location = New System.Drawing.Point(298, 167)
        Me._PalShapeBorder_0.Name = "_PalShapeBorder_0"
        Me._PalShapeBorder_0.Size = New System.Drawing.Size(102, 18)
        Me._PalShapeBorder_0.TabIndex = 31
        '
        '_PalShape_0
        '
        Me._PalShape_0.BackColor = System.Drawing.Color.Black
        Me._PalShape_0.Location = New System.Drawing.Point(299, 168)
        Me._PalShape_0.Name = "_PalShape_0"
        Me._PalShape_0.Size = New System.Drawing.Size(25, 16)
        Me._PalShape_0.TabIndex = 30
        '
        'BtnShowSelected
        '
        Me.BtnShowSelected.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold)
        Me.BtnShowSelected.Location = New System.Drawing.Point(471, 140)
        Me.BtnShowSelected.Name = "BtnShowSelected"
        Me.BtnShowSelected.Size = New System.Drawing.Size(91, 53)
        Me.BtnShowSelected.TabIndex = 41
        Me.BtnShowSelected.Text = "Show Selected"
        Me.BtnShowSelected.UseVisualStyleBackColor = True
        '
        'BtnMoreOptions
        '
        Me.BtnMoreOptions.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold)
        Me.BtnMoreOptions.Location = New System.Drawing.Point(471, 198)
        Me.BtnMoreOptions.Name = "BtnMoreOptions"
        Me.BtnMoreOptions.Size = New System.Drawing.Size(91, 53)
        Me.BtnMoreOptions.TabIndex = 43
        Me.BtnMoreOptions.Text = "More Options"
        Me.BtnMoreOptions.UseVisualStyleBackColor = True
        '
        'GbxChrExtract
        '
        Me.GbxChrExtract.BackColor = System.Drawing.SystemColors.Control
        Me.GbxChrExtract.Controls.Add(Me.BtnMME_Extract)
        Me.GbxChrExtract.Controls.Add(Me.Command14)
        Me.GbxChrExtract.Controls.Add(Me.Command9)
        Me.GbxChrExtract.Controls.Add(Me.Text7)
        Me.GbxChrExtract.Controls.Add(Me.Text6)
        Me.GbxChrExtract.Controls.Add(Me.Text4)
        Me.GbxChrExtract.Controls.Add(Me.Text3)
        Me.GbxChrExtract.Controls.Add(Me.Label20)
        Me.GbxChrExtract.Controls.Add(Me.Label19)
        Me.GbxChrExtract.Controls.Add(Me.Label18)
        Me.GbxChrExtract.Controls.Add(Me.Label17)
        Me.GbxChrExtract.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GbxChrExtract.ForeColor = System.Drawing.SystemColors.ControlText
        Me.GbxChrExtract.Location = New System.Drawing.Point(572, 118)
        Me.GbxChrExtract.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.GbxChrExtract.Name = "GbxChrExtract"
        Me.GbxChrExtract.Padding = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.GbxChrExtract.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.GbxChrExtract.Size = New System.Drawing.Size(232, 139)
        Me.GbxChrExtract.TabIndex = 44
        Me.GbxChrExtract.TabStop = False
        Me.GbxChrExtract.Text = "CHR! Tiles! Graphics!"
        Me.GbxChrExtract.Visible = False
        '
        'BtnMME_Extract
        '
        Me.BtnMME_Extract.BackColor = System.Drawing.SystemColors.Control
        Me.BtnMME_Extract.Cursor = System.Windows.Forms.Cursors.Default
        Me.BtnMME_Extract.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnMME_Extract.ForeColor = System.Drawing.SystemColors.ControlText
        Me.BtnMME_Extract.Location = New System.Drawing.Point(8, 110)
        Me.BtnMME_Extract.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.BtnMME_Extract.Name = "BtnMME_Extract"
        Me.BtnMME_Extract.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.BtnMME_Extract.Size = New System.Drawing.Size(209, 25)
        Me.BtnMME_Extract.TabIndex = 38
        Me.BtnMME_Extract.Text = "MME Extract"
        Me.BtnMME_Extract.UseVisualStyleBackColor = False
        '
        'Command14
        '
        Me.Command14.BackColor = System.Drawing.SystemColors.Control
        Me.Command14.Cursor = System.Windows.Forms.Cursors.Default
        Me.Command14.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Command14.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Command14.Location = New System.Drawing.Point(112, 86)
        Me.Command14.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.Command14.Name = "Command14"
        Me.Command14.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Command14.Size = New System.Drawing.Size(105, 25)
        Me.Command14.TabIndex = 36
        Me.Command14.Text = "Import CHR"
        Me.Command14.UseVisualStyleBackColor = False
        '
        'Command9
        '
        Me.Command9.BackColor = System.Drawing.SystemColors.Control
        Me.Command9.Cursor = System.Windows.Forms.Cursors.Default
        Me.Command9.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Command9.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Command9.Location = New System.Drawing.Point(8, 86)
        Me.Command9.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.Command9.Name = "Command9"
        Me.Command9.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Command9.Size = New System.Drawing.Size(105, 25)
        Me.Command9.TabIndex = 35
        Me.Command9.Text = "Extract CHR"
        Me.Command9.UseVisualStyleBackColor = False
        '
        'Text7
        '
        Me.Text7.AcceptsReturn = True
        Me.Text7.BackColor = System.Drawing.SystemColors.Window
        Me.Text7.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.Text7.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Text7.ForeColor = System.Drawing.SystemColors.WindowText
        Me.Text7.Location = New System.Drawing.Point(112, 64)
        Me.Text7.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.Text7.MaxLength = 0
        Me.Text7.Name = "Text7"
        Me.Text7.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Text7.Size = New System.Drawing.Size(96, 23)
        Me.Text7.TabIndex = 34
        Me.Text7.Text = "dump"
        '
        'Text6
        '
        Me.Text6.AcceptsReturn = True
        Me.Text6.BackColor = System.Drawing.SystemColors.Window
        Me.Text6.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.Text6.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Text6.ForeColor = System.Drawing.SystemColors.WindowText
        Me.Text6.Location = New System.Drawing.Point(112, 48)
        Me.Text6.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.Text6.MaxLength = 0
        Me.Text6.Name = "Text6"
        Me.Text6.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Text6.Size = New System.Drawing.Size(96, 23)
        Me.Text6.TabIndex = 32
        Me.Text6.Text = "0"
        '
        'Text4
        '
        Me.Text4.AcceptsReturn = True
        Me.Text4.BackColor = System.Drawing.SystemColors.Window
        Me.Text4.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.Text4.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Text4.ForeColor = System.Drawing.SystemColors.WindowText
        Me.Text4.Location = New System.Drawing.Point(112, 32)
        Me.Text4.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.Text4.MaxLength = 0
        Me.Text4.Name = "Text4"
        Me.Text4.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Text4.Size = New System.Drawing.Size(96, 23)
        Me.Text4.TabIndex = 29
        Me.Text4.Text = "FF"
        '
        'Text3
        '
        Me.Text3.AcceptsReturn = True
        Me.Text3.BackColor = System.Drawing.SystemColors.Window
        Me.Text3.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.Text3.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Text3.ForeColor = System.Drawing.SystemColors.WindowText
        Me.Text3.Location = New System.Drawing.Point(112, 16)
        Me.Text3.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.Text3.MaxLength = 0
        Me.Text3.Name = "Text3"
        Me.Text3.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Text3.Size = New System.Drawing.Size(96, 23)
        Me.Text3.TabIndex = 27
        Me.Text3.Text = "0"
        '
        'Label20
        '
        Me.Label20.BackColor = System.Drawing.SystemColors.Control
        Me.Label20.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label20.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label20.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label20.Location = New System.Drawing.Point(8, 48)
        Me.Label20.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label20.Name = "Label20"
        Me.Label20.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label20.Size = New System.Drawing.Size(98, 17)
        Me.Label20.TabIndex = 33
        Me.Label20.Text = "File Offset:"
        '
        'Label19
        '
        Me.Label19.BackColor = System.Drawing.SystemColors.Control
        Me.Label19.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label19.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label19.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label19.Location = New System.Drawing.Point(8, 64)
        Me.Label19.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label19.Name = "Label19"
        Me.Label19.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label19.Size = New System.Drawing.Size(72, 17)
        Me.Label19.TabIndex = 31
        Me.Label19.Text = "Filename:"
        '
        'Label18
        '
        Me.Label18.BackColor = System.Drawing.SystemColors.Control
        Me.Label18.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label18.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label18.Location = New System.Drawing.Point(8, 32)
        Me.Label18.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label18.Name = "Label18"
        Me.Label18.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label18.Size = New System.Drawing.Size(81, 17)
        Me.Label18.TabIndex = 30
        Me.Label18.Text = "Last Tile:"
        '
        'Label17
        '
        Me.Label17.BackColor = System.Drawing.SystemColors.Control
        Me.Label17.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label17.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label17.Location = New System.Drawing.Point(8, 16)
        Me.Label17.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label17.Name = "Label17"
        Me.Label17.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label17.Size = New System.Drawing.Size(89, 17)
        Me.Label17.TabIndex = 28
        Me.Label17.Text = "First Tile:"
        '
        'GbxChrExportAsHex
        '
        Me.GbxChrExportAsHex.BackColor = System.Drawing.SystemColors.Control
        Me.GbxChrExportAsHex.Controls.Add(Me.Text9)
        Me.GbxChrExportAsHex.Controls.Add(Me.Command5)
        Me.GbxChrExportAsHex.Controls.Add(Me.Command11)
        Me.GbxChrExportAsHex.Controls.Add(Me.Label15)
        Me.GbxChrExportAsHex.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GbxChrExportAsHex.ForeColor = System.Drawing.SystemColors.ControlText
        Me.GbxChrExportAsHex.Location = New System.Drawing.Point(572, 24)
        Me.GbxChrExportAsHex.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.GbxChrExportAsHex.Name = "GbxChrExportAsHex"
        Me.GbxChrExportAsHex.Padding = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.GbxChrExportAsHex.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.GbxChrExportAsHex.Size = New System.Drawing.Size(232, 75)
        Me.GbxChrExportAsHex.TabIndex = 45
        Me.GbxChrExportAsHex.TabStop = False
        Me.GbxChrExportAsHex.Text = "CHR PointerMap"
        '
        'Command5
        '
        Me.Command5.BackColor = System.Drawing.SystemColors.Control
        Me.Command5.Cursor = System.Windows.Forms.Cursors.Default
        Me.Command5.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Command5.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Command5.Location = New System.Drawing.Point(112, 40)
        Me.Command5.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.Command5.Name = "Command5"
        Me.Command5.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Command5.Size = New System.Drawing.Size(105, 25)
        Me.Command5.TabIndex = 42
        Me.Command5.Text = "Dump CHR PointerMap"
        Me.Command5.UseVisualStyleBackColor = False
        '
        'Command11
        '
        Me.Command11.BackColor = System.Drawing.SystemColors.Control
        Me.Command11.Cursor = System.Windows.Forms.Cursors.Default
        Me.Command11.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Command11.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Command11.Location = New System.Drawing.Point(8, 40)
        Me.Command11.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.Command11.Name = "Command11"
        Me.Command11.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Command11.Size = New System.Drawing.Size(105, 25)
        Me.Command11.TabIndex = 41
        Me.Command11.Text = "Import CHR PointerMap"
        Me.Command11.UseVisualStyleBackColor = False
        '
        'Label15
        '
        Me.Label15.BackColor = System.Drawing.SystemColors.Control
        Me.Label15.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label15.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label15.Location = New System.Drawing.Point(16, 16)
        Me.Label15.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label15.Name = "Label15"
        Me.Label15.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label15.Size = New System.Drawing.Size(72, 17)
        Me.Label15.TabIndex = 44
        Me.Label15.Text = "Filename:"
        '
        'GbxCHR_AnimEd
        '
        Me.GbxCHR_AnimEd.BackColor = System.Drawing.SystemColors.Control
        Me.GbxCHR_AnimEd.Controls.Add(Me.Label6)
        Me.GbxCHR_AnimEd.Controls.Add(Me.Label3)
        Me.GbxCHR_AnimEd.Controls.Add(Me._BGDst_1)
        Me.GbxCHR_AnimEd.Controls.Add(Me._BGDst_0)
        Me.GbxCHR_AnimEd.Controls.Add(Me.BGFrameSelect)
        Me.GbxCHR_AnimEd.Controls.Add(Me.BGSrcTB)
        Me.GbxCHR_AnimEd.Controls.Add(Me.CHRIDUD)
        Me.GbxCHR_AnimEd.Controls.Add(Me.DelayUD)
        Me.GbxCHR_AnimEd.Controls.Add(Me.FramesUD)
        Me.GbxCHR_AnimEd.Controls.Add(Me.Label1)
        Me.GbxCHR_AnimEd.Controls.Add(Me.Label5)
        Me.GbxCHR_AnimEd.Controls.Add(Me.Label4)
        Me.GbxCHR_AnimEd.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GbxCHR_AnimEd.ForeColor = System.Drawing.SystemColors.ControlText
        Me.GbxCHR_AnimEd.Location = New System.Drawing.Point(815, 24)
        Me.GbxCHR_AnimEd.Name = "GbxCHR_AnimEd"
        Me.GbxCHR_AnimEd.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.GbxCHR_AnimEd.Size = New System.Drawing.Size(178, 215)
        Me.GbxCHR_AnimEd.TabIndex = 80
        Me.GbxCHR_AnimEd.TabStop = False
        Me.GbxCHR_AnimEd.Text = "CHR Animation Editor"
        Me.GbxCHR_AnimEd.Visible = False
        '
        'Label6
        '
        Me.Label6.BackColor = System.Drawing.SystemColors.Control
        Me.Label6.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label6.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label6.Location = New System.Drawing.Point(24, 70)
        Me.Label6.Name = "Label6"
        Me.Label6.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label6.Size = New System.Drawing.Size(89, 22)
        Me.Label6.TabIndex = 74
        Me.Label6.Text = "# of Frames:"
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.SystemColors.Control
        Me.Label3.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label3.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label3.Location = New System.Drawing.Point(6, 92)
        Me.Label3.Name = "Label3"
        Me.Label3.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label3.Size = New System.Drawing.Size(86, 19)
        Me.Label3.TabIndex = 73
        Me.Label3.Text = "Source BG:"
        '
        '_BGDst_1
        '
        Me._BGDst_1.BackColor = System.Drawing.SystemColors.Control
        Me._BGDst_1.Cursor = System.Windows.Forms.Cursors.Default
        Me._BGDst_1.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._BGDst_1.ForeColor = System.Drawing.SystemColors.ControlText
        Me._BGDst_1.Location = New System.Drawing.Point(8, 183)
        Me._BGDst_1.Name = "_BGDst_1"
        Me._BGDst_1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._BGDst_1.Size = New System.Drawing.Size(105, 23)
        Me._BGDst_1.TabIndex = 72
        Me._BGDst_1.TabStop = True
        Me._BGDst_1.Text = "BG CHR Bank 1"
        Me._BGDst_1.UseVisualStyleBackColor = False
        '
        '_BGDst_0
        '
        Me._BGDst_0.BackColor = System.Drawing.SystemColors.Control
        Me._BGDst_0.Cursor = System.Windows.Forms.Cursors.Default
        Me._BGDst_0.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._BGDst_0.ForeColor = System.Drawing.SystemColors.ControlText
        Me._BGDst_0.Location = New System.Drawing.Point(8, 165)
        Me._BGDst_0.Name = "_BGDst_0"
        Me._BGDst_0.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._BGDst_0.Size = New System.Drawing.Size(105, 18)
        Me._BGDst_0.TabIndex = 71
        Me._BGDst_0.TabStop = True
        Me._BGDst_0.Text = "BG CHR Bank 0"
        Me._BGDst_0.UseVisualStyleBackColor = False
        '
        'BGFrameSelect
        '
        Me.BGFrameSelect.Cursor = System.Windows.Forms.Cursors.Default
        Me.BGFrameSelect.LargeChange = 1
        Me.BGFrameSelect.Location = New System.Drawing.Point(79, 126)
        Me.BGFrameSelect.Maximum = 32767
        Me.BGFrameSelect.Name = "BGFrameSelect"
        Me.BGFrameSelect.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.BGFrameSelect.Size = New System.Drawing.Size(81, 12)
        Me.BGFrameSelect.TabIndex = 69
        Me.BGFrameSelect.TabStop = True
        '
        'FramesUD
        '
        Me.FramesUD.Enabled = False
        Me.FramesUD.Hexadecimal = True
        Me.FramesUD.Location = New System.Drawing.Point(115, 70)
        Me.FramesUD.Maximum = New Decimal(New Integer() {255, 0, 0, 0})
        Me.FramesUD.Name = "FramesUD"
        Me.FramesUD.Size = New System.Drawing.Size(45, 23)
        Me.FramesUD.TabIndex = 65
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.SystemColors.Control
        Me.Label1.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label1.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label1.Location = New System.Drawing.Point(6, 144)
        Me.Label1.Name = "Label1"
        Me.Label1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label1.Size = New System.Drawing.Size(129, 16)
        Me.Label1.TabIndex = 70
        Me.Label1.Text = "BG Destination:"
        '
        'Label5
        '
        Me.Label5.BackColor = System.Drawing.SystemColors.Control
        Me.Label5.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label5.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label5.Location = New System.Drawing.Point(24, 46)
        Me.Label5.Name = "Label5"
        Me.Label5.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label5.Size = New System.Drawing.Size(53, 23)
        Me.Label5.TabIndex = 62
        Me.Label5.Text = "Delay:"
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.SystemColors.Control
        Me.Label4.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label4.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label4.Location = New System.Drawing.Point(6, 22)
        Me.Label4.Name = "Label4"
        Me.Label4.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label4.Size = New System.Drawing.Size(41, 17)
        Me.Label4.TabIndex = 60
        Me.Label4.Text = "ID:"
        '
        'GbxForceCHR_Bank
        '
        Me.GbxForceCHR_Bank.Controls.Add(Me.Text8)
        Me.GbxForceCHR_Bank.Controls.Add(Me._Option1_1)
        Me.GbxForceCHR_Bank.Controls.Add(Me._Option1_0)
        Me.GbxForceCHR_Bank.Controls.Add(Me.Command10)
        Me.GbxForceCHR_Bank.Controls.Add(Me.Label10)
        Me.GbxForceCHR_Bank.Location = New System.Drawing.Point(352, 263)
        Me.GbxForceCHR_Bank.Name = "GbxForceCHR_Bank"
        Me.GbxForceCHR_Bank.Size = New System.Drawing.Size(236, 34)
        Me.GbxForceCHR_Bank.TabIndex = 81
        Me.GbxForceCHR_Bank.TabStop = False
        '
        '_Option1_1
        '
        Me._Option1_1.BackColor = System.Drawing.SystemColors.Control
        Me._Option1_1.Cursor = System.Windows.Forms.Cursors.Default
        Me._Option1_1.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._Option1_1.ForeColor = System.Drawing.SystemColors.ControlText
        Me._Option1_1.Location = New System.Drawing.Point(127, 10)
        Me._Option1_1.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me._Option1_1.Name = "_Option1_1"
        Me._Option1_1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Option1_1.Size = New System.Drawing.Size(32, 17)
        Me._Option1_1.TabIndex = 61
        Me._Option1_1.TabStop = True
        Me._Option1_1.Text = "1"
        Me._Option1_1.UseVisualStyleBackColor = False
        '
        '_Option1_0
        '
        Me._Option1_0.BackColor = System.Drawing.SystemColors.Control
        Me._Option1_0.Checked = True
        Me._Option1_0.Cursor = System.Windows.Forms.Cursors.Default
        Me._Option1_0.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._Option1_0.ForeColor = System.Drawing.SystemColors.ControlText
        Me._Option1_0.Location = New System.Drawing.Point(100, 10)
        Me._Option1_0.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me._Option1_0.Name = "_Option1_0"
        Me._Option1_0.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Option1_0.Size = New System.Drawing.Size(32, 17)
        Me._Option1_0.TabIndex = 60
        Me._Option1_0.TabStop = True
        Me._Option1_0.Text = "0"
        Me._Option1_0.UseVisualStyleBackColor = False
        '
        'Command10
        '
        Me.Command10.BackColor = System.Drawing.SystemColors.Control
        Me.Command10.Cursor = System.Windows.Forms.Cursors.Default
        Me.Command10.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Command10.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Command10.Location = New System.Drawing.Point(200, 10)
        Me.Command10.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.Command10.Name = "Command10"
        Me.Command10.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Command10.Size = New System.Drawing.Size(32, 20)
        Me.Command10.TabIndex = 59
        Me.Command10.Text = "Do"
        Me.Command10.UseVisualStyleBackColor = False
        '
        'Label10
        '
        Me.Label10.BackColor = System.Drawing.SystemColors.Control
        Me.Label10.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label10.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label10.Location = New System.Drawing.Point(11, 10)
        Me.Label10.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label10.Name = "Label10"
        Me.Label10.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label10.Size = New System.Drawing.Size(145, 17)
        Me.Label10.TabIndex = 57
        Me.Label10.Text = "Force CHR Bank:"
        '
        'GbxForceCHR_Anim
        '
        Me.GbxForceCHR_Anim.Controls.Add(Me.CATB)
        Me.GbxForceCHR_Anim.Controls.Add(Me.Command7)
        Me.GbxForceCHR_Anim.Controls.Add(Me.Label14)
        Me.GbxForceCHR_Anim.Location = New System.Drawing.Point(607, 263)
        Me.GbxForceCHR_Anim.Name = "GbxForceCHR_Anim"
        Me.GbxForceCHR_Anim.Size = New System.Drawing.Size(197, 34)
        Me.GbxForceCHR_Anim.TabIndex = 82
        Me.GbxForceCHR_Anim.TabStop = False
        '
        'Command7
        '
        Me.Command7.BackColor = System.Drawing.SystemColors.Control
        Me.Command7.Cursor = System.Windows.Forms.Cursors.Default
        Me.Command7.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Command7.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Command7.Location = New System.Drawing.Point(161, 10)
        Me.Command7.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.Command7.Name = "Command7"
        Me.Command7.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Command7.Size = New System.Drawing.Size(32, 20)
        Me.Command7.TabIndex = 59
        Me.Command7.Text = "Do"
        Me.Command7.UseVisualStyleBackColor = False
        '
        'Label14
        '
        Me.Label14.BackColor = System.Drawing.SystemColors.Control
        Me.Label14.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label14.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label14.Location = New System.Drawing.Point(11, 10)
        Me.Label14.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label14.Name = "Label14"
        Me.Label14.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label14.Size = New System.Drawing.Size(121, 17)
        Me.Label14.TabIndex = 58
        Me.Label14.Text = "Force CHR Anim:"
        '
        'GbxBG_CHR_Bank
        '
        Me.GbxBG_CHR_Bank.Controls.Add(Me._BGCHRUD_0)
        Me.GbxBG_CHR_Bank.Controls.Add(Me._BGCHRUD_1)
        Me.GbxBG_CHR_Bank.Controls.Add(Me.BGCHRLab1)
        Me.GbxBG_CHR_Bank.Controls.Add(Me.BGCHRLab2)
        Me.GbxBG_CHR_Bank.Location = New System.Drawing.Point(0, 263)
        Me.GbxBG_CHR_Bank.Name = "GbxBG_CHR_Bank"
        Me.GbxBG_CHR_Bank.Size = New System.Drawing.Size(329, 34)
        Me.GbxBG_CHR_Bank.TabIndex = 83
        Me.GbxBG_CHR_Bank.TabStop = False
        '
        'BGCHRLab1
        '
        Me.BGCHRLab1.BackColor = System.Drawing.SystemColors.Control
        Me.BGCHRLab1.Cursor = System.Windows.Forms.Cursors.Default
        Me.BGCHRLab1.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BGCHRLab1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.BGCHRLab1.Location = New System.Drawing.Point(11, 10)
        Me.BGCHRLab1.Name = "BGCHRLab1"
        Me.BGCHRLab1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.BGCHRLab1.Size = New System.Drawing.Size(110, 17)
        Me.BGCHRLab1.TabIndex = 80
        Me.BGCHRLab1.Text = "BG CHR Bank 0:"
        '
        'BGCHRLab2
        '
        Me.BGCHRLab2.BackColor = System.Drawing.SystemColors.Control
        Me.BGCHRLab2.Cursor = System.Windows.Forms.Cursors.Default
        Me.BGCHRLab2.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BGCHRLab2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.BGCHRLab2.Location = New System.Drawing.Point(166, 10)
        Me.BGCHRLab2.Name = "BGCHRLab2"
        Me.BGCHRLab2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.BGCHRLab2.Size = New System.Drawing.Size(114, 17)
        Me.BGCHRLab2.TabIndex = 83
        Me.BGCHRLab2.Text = "BG CHR Bank 1:"
        '
        'TileTable
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.ClientSize = New System.Drawing.Size(1002, 330)
        Me.Controls.Add(Me.CurTileLab)
        Me.Controls.Add(Me.GbxBG_CHR_Bank)
        Me.Controls.Add(Me.GbxForceCHR_Anim)
        Me.Controls.Add(Me.GbxForceCHR_Bank)
        Me.Controls.Add(Me.GbxCHR_AnimEd)
        Me.Controls.Add(Me.GbxChrExportAsHex)
        Me.Controls.Add(Me.GbxChrExtract)
        Me.Controls.Add(Me.BtnMoreOptions)
        Me.Controls.Add(Me.BtnClearDuplicated)
        Me.Controls.Add(Me.BtnShowSelected)
        Me.Controls.Add(Me.BtnClearUnusedTiles)
        Me.Controls.Add(Me._PalShape_1)
        Me.Controls.Add(Me._PalShape_0)
        Me.Controls.Add(Me._PalShape_15)
        Me.Controls.Add(Me._PalShape_14)
        Me.Controls.Add(Me._PalShape_13)
        Me.Controls.Add(Me._PalShape_12)
        Me.Controls.Add(Me._PalShape_11)
        Me.Controls.Add(Me._PalShape_10)
        Me.Controls.Add(Me._PalShape_9)
        Me.Controls.Add(Me._PalShape_8)
        Me.Controls.Add(Me._PalShape_7)
        Me.Controls.Add(Me._PalShape_6)
        Me.Controls.Add(Me._PalShape_5)
        Me.Controls.Add(Me._PalShape_4)
        Me.Controls.Add(Me._PalShape_3)
        Me.Controls.Add(Me._PalShape_2)
        Me.Controls.Add(Me.CHRAnimFrame)
        Me.Controls.Add(Me.CHRAnimSS)
        Me.Controls.Add(Me.TRotaBtn)
        Me.Controls.Add(Me.TShiftVBtn)
        Me.Controls.Add(Me.TShiftHBtn)
        Me.Controls.Add(Me.CopyBtn)
        Me.Controls.Add(Me.PasteBtn)
        Me.Controls.Add(Me.TilePic)
        Me.Controls.Add(Me.pic1)
        Me.Controls.Add(Me.CHRAnimCtrlLab)
        Me.Controls.Add(Me._PalShapeBorder_3)
        Me.Controls.Add(Me._PalShapeBorder_2)
        Me.Controls.Add(Me._PalShapeBorder_1)
        Me.Controls.Add(Me._PalShapeBorder_0)
        Me.Controls.Add(Me._ColShapeBorder_3)
        Me.Controls.Add(Me._ColShapeBorder_2)
        Me.Controls.Add(Me._ColShapeBorder_1)
        Me.Controls.Add(Me._ColShapeBorder_0)
        Me.Controls.Add(Me.contourLabel)
        Me.Cursor = System.Windows.Forms.Cursors.Default
        Me.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.Location = New System.Drawing.Point(3, 27)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "TileTable"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Text = "Tile Table"
        CType(Me.CHRIDUD, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DelayUD, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me._BGCHRUD_0, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me._BGCHRUD_1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TilePic, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pic1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GbxChrExtract.ResumeLayout(False)
        Me.GbxChrExtract.PerformLayout()
        Me.GbxChrExportAsHex.ResumeLayout(False)
        Me.GbxChrExportAsHex.PerformLayout()
        Me.GbxCHR_AnimEd.ResumeLayout(False)
        Me.GbxCHR_AnimEd.PerformLayout()
        CType(Me.FramesUD, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GbxForceCHR_Bank.ResumeLayout(False)
        Me.GbxForceCHR_Bank.PerformLayout()
        Me.GbxForceCHR_Anim.ResumeLayout(False)
        Me.GbxForceCHR_Anim.PerformLayout()
        Me.GbxBG_CHR_Bank.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Public WithEvents contourLabel As Label
    Public WithEvents _PalShapeBorder_0 As Label
    Public WithEvents _PalShape_0 As Label
    Public WithEvents BtnClearUnusedTiles As Button
    Public WithEvents BtnClearDuplicated As Button
    Friend WithEvents BtnShowSelected As Button
    Friend WithEvents BtnMoreOptions As Button
    Public WithEvents GbxChrExtract As GroupBox
    Public WithEvents Command14 As Button
    Public WithEvents Command9 As Button
    Public WithEvents Text7 As TextBox
    Public WithEvents Text6 As TextBox
    Public WithEvents Text4 As TextBox
    Public WithEvents Text3 As TextBox
    Public WithEvents Label20 As Label
    Public WithEvents Label19 As Label
    Public WithEvents Label18 As Label
    Public WithEvents Label17 As Label
    Public WithEvents BtnMME_Extract As Button
    Public WithEvents GbxChrExportAsHex As GroupBox
    Public WithEvents Text9 As TextBox
    Public WithEvents Command5 As Button
    Public WithEvents Command11 As Button
    Public WithEvents Label15 As Label
    Public WithEvents GbxCHR_AnimEd As GroupBox
    Public WithEvents _BGDst_1 As RadioButton
    Public WithEvents _BGDst_0 As RadioButton
    Public WithEvents BGFrameSelect As HScrollBar
    Public WithEvents BGSrcTB As TextBox
    Public WithEvents CHRIDUD As NumericUpDown
    Public WithEvents DelayUD As NumericUpDown
    Public WithEvents FramesUD As NumericUpDown
    Public WithEvents Label1 As Label
    Public WithEvents Label5 As Label
    Public WithEvents Label4 As Label
    Friend WithEvents GbxForceCHR_Bank As GroupBox
    Public WithEvents Text8 As TextBox
    Public WithEvents _Option1_1 As RadioButton
    Public WithEvents _Option1_0 As RadioButton
    Public WithEvents Command10 As Button
    Public WithEvents Label10 As Label
    Friend WithEvents GbxForceCHR_Anim As GroupBox
    Public WithEvents CATB As TextBox
    Public WithEvents Command7 As Button
    Public WithEvents Label14 As Label
    Friend WithEvents GbxBG_CHR_Bank As GroupBox
    Public WithEvents BGCHRLab1 As Label
    Public WithEvents _BGCHRUD_0 As NumericUpDown
    Public WithEvents BGCHRLab2 As Label
    Public WithEvents _BGCHRUD_1 As NumericUpDown
    Public WithEvents Label6 As Label
    Public WithEvents Label3 As Label
#End Region
End Class