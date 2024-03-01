<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> Partial Class GfxLoadEd
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
	Public WithEvents Text1 As System.Windows.Forms.TextBox
	Public WithEvents LoadGfxBtn As System.Windows.Forms.Button
	Public WithEvents Command1 As System.Windows.Forms.Button
    Public WithEvents ResetBtn As System.Windows.Forms.Button
    Public WithEvents _PPUEffModeOpt_3 As System.Windows.Forms.RadioButton
	Public WithEvents TileDstPic As System.Windows.Forms.PictureBox
	Public WithEvents _ColTB_3 As System.Windows.Forms.TextBox
	Public WithEvents _ColTB_2 As System.Windows.Forms.TextBox
	Public WithEvents _ColTB_1 As System.Windows.Forms.TextBox
	Public WithEvents _ColTB_7 As System.Windows.Forms.TextBox
	Public WithEvents _ColTB_6 As System.Windows.Forms.TextBox
	Public WithEvents _ColTB_5 As System.Windows.Forms.TextBox
	Public WithEvents HasSprPalCheck As System.Windows.Forms.CheckBox
    Public WithEvents _PPUEffModeOpt_1 As System.Windows.Forms.RadioButton
    Public WithEvents TileSrcPic As System.Windows.Forms.PictureBox
    Public WithEvents CHRLoadRemBtn As System.Windows.Forms.Button
    Public WithEvents CHRLoadNewButton As System.Windows.Forms.Button
    Public WithEvents CHRLoadList As System.Windows.Forms.ListBox
    Public WithEvents _ColPic_7 As System.Windows.Forms.PictureBox
    Public WithEvents _ColPic_6 As System.Windows.Forms.PictureBox
    Public WithEvents _ColPic_5 As System.Windows.Forms.PictureBox
    Public WithEvents _ColPic_3 As System.Windows.Forms.PictureBox
    Public WithEvents _ColPic_2 As System.Windows.Forms.PictureBox
    Public WithEvents _ColPic_1 As System.Windows.Forms.PictureBox
    Public WithEvents EffIDUD As System.Windows.Forms.NumericUpDown
    Public WithEvents _PPUEffModeOpt_2 As System.Windows.Forms.RadioButton
    Public WithEvents _PPUEffModeOpt_0 As System.Windows.Forms.RadioButton
	Public WithEvents SrcBankUD As System.Windows.Forms.NumericUpDown
	Public WithEvents SrcHiUD As System.Windows.Forms.NumericUpDown
	Public WithEvents CopyTilesUD As System.Windows.Forms.NumericUpDown
	Public WithEvents DstVRAMUD As System.Windows.Forms.NumericUpDown
	Public WithEvents LSDIDUD As System.Windows.Forms.NumericUpDown
	Public WithEvents Line2 As System.Windows.Forms.Label
	Public WithEvents Line1 As System.Windows.Forms.Label
	Public WithEvents Label10 As System.Windows.Forms.Label
	Public WithEvents Label8 As System.Windows.Forms.Label
	Public WithEvents FreeSpaceLab As System.Windows.Forms.Label
	Public WithEvents Label7 As System.Windows.Forms.Label
	Public WithEvents Label5 As System.Windows.Forms.Label
	Public WithEvents Label4 As System.Windows.Forms.Label
	Public WithEvents Label3 As System.Windows.Forms.Label
	Public WithEvents Label2 As System.Windows.Forms.Label
	Public WithEvents Label1 As System.Windows.Forms.Label
    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(GfxLoadEd))
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.Text1 = New System.Windows.Forms.TextBox()
        Me.LoadGfxBtn = New System.Windows.Forms.Button()
        Me.Command1 = New System.Windows.Forms.Button()
        Me.ResetBtn = New System.Windows.Forms.Button()
        Me._PPUEffModeOpt_3 = New System.Windows.Forms.RadioButton()
        Me.TileDstPic = New System.Windows.Forms.PictureBox()
        Me._ColTB_3 = New System.Windows.Forms.TextBox()
        Me._ColTB_2 = New System.Windows.Forms.TextBox()
        Me._ColTB_1 = New System.Windows.Forms.TextBox()
        Me._ColTB_7 = New System.Windows.Forms.TextBox()
        Me._ColTB_6 = New System.Windows.Forms.TextBox()
        Me._ColTB_5 = New System.Windows.Forms.TextBox()
        Me.HasSprPalCheck = New System.Windows.Forms.CheckBox()
        Me._PPUEffModeOpt_1 = New System.Windows.Forms.RadioButton()
        Me.TileSrcPic = New System.Windows.Forms.PictureBox()
        Me.CHRLoadRemBtn = New System.Windows.Forms.Button()
        Me.CHRLoadNewButton = New System.Windows.Forms.Button()
        Me.CHRLoadList = New System.Windows.Forms.ListBox()
        Me._ColPic_7 = New System.Windows.Forms.PictureBox()
        Me._ColPic_6 = New System.Windows.Forms.PictureBox()
        Me._ColPic_5 = New System.Windows.Forms.PictureBox()
        Me._ColPic_3 = New System.Windows.Forms.PictureBox()
        Me._ColPic_2 = New System.Windows.Forms.PictureBox()
        Me._ColPic_1 = New System.Windows.Forms.PictureBox()
        Me.EffIDUD = New System.Windows.Forms.NumericUpDown()
        Me._PPUEffModeOpt_2 = New System.Windows.Forms.RadioButton()
        Me._PPUEffModeOpt_0 = New System.Windows.Forms.RadioButton()
        Me.SrcBankUD = New System.Windows.Forms.NumericUpDown()
        Me.SrcHiUD = New System.Windows.Forms.NumericUpDown()
        Me.CopyTilesUD = New System.Windows.Forms.NumericUpDown()
        Me.DstVRAMUD = New System.Windows.Forms.NumericUpDown()
        Me.LSDIDUD = New System.Windows.Forms.NumericUpDown()
        Me.Line2 = New System.Windows.Forms.Label()
        Me.Line1 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.FreeSpaceLab = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.CHRLoadDOWN = New System.Windows.Forms.Button()
        Me.CHRLoadUP = New System.Windows.Forms.Button()
        Me.Label6 = New System.Windows.Forms.Label()
        Me._ColTB_0 = New System.Windows.Forms.TextBox()
        Me._ColPic_0 = New System.Windows.Forms.PictureBox()
        Me._ColPic_4 = New System.Windows.Forms.PictureBox()
        Me._ColTB_4 = New System.Windows.Forms.TextBox()
        Me.BtnDumpSpriteChar = New System.Windows.Forms.Button()
        CType(Me.TileDstPic, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TileSrcPic, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me._ColPic_7, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me._ColPic_6, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me._ColPic_5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me._ColPic_3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me._ColPic_2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me._ColPic_1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EffIDUD, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SrcBankUD, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SrcHiUD, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CopyTilesUD, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DstVRAMUD, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LSDIDUD, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me._ColPic_0, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me._ColPic_4, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Text1
        '
        Me.Text1.AcceptsReturn = True
        Me.Text1.BackColor = System.Drawing.SystemColors.Window
        Me.Text1.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.Text1.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Text1.ForeColor = System.Drawing.SystemColors.WindowText
        Me.Text1.Location = New System.Drawing.Point(354, 168)
        Me.Text1.MaxLength = 0
        Me.Text1.Name = "Text1"
        Me.Text1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Text1.Size = New System.Drawing.Size(51, 23)
        Me.Text1.TabIndex = 47
        Me.Text1.Text = "chrmap.hex"
        Me.Text1.Visible = False
        '
        'LoadGfxBtn
        '
        Me.LoadGfxBtn.BackColor = System.Drawing.SystemColors.Control
        Me.LoadGfxBtn.Cursor = System.Windows.Forms.Cursors.Default
        Me.LoadGfxBtn.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LoadGfxBtn.ForeColor = System.Drawing.SystemColors.ControlText
        Me.LoadGfxBtn.Location = New System.Drawing.Point(245, 6)
        Me.LoadGfxBtn.Name = "LoadGfxBtn"
        Me.LoadGfxBtn.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.LoadGfxBtn.Size = New System.Drawing.Size(170, 33)
        Me.LoadGfxBtn.TabIndex = 46
        Me.LoadGfxBtn.Text = "Load as current level graphics (Primary Gfx Load only)."
        Me.LoadGfxBtn.UseVisualStyleBackColor = False
        '
        'Command1
        '
        Me.Command1.BackColor = System.Drawing.SystemColors.Control
        Me.Command1.Cursor = System.Windows.Forms.Cursors.Default
        Me.Command1.Enabled = False
        Me.Command1.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Command1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Command1.Location = New System.Drawing.Point(256, 129)
        Me.Command1.Name = "Command1"
        Me.Command1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Command1.Size = New System.Drawing.Size(153, 33)
        Me.Command1.TabIndex = 45
        Me.Command1.Text = "Dump CHR PointerMap:"
        Me.Command1.UseVisualStyleBackColor = False
        Me.Command1.Visible = False
        '
        'ResetBtn
        '
        Me.ResetBtn.BackColor = System.Drawing.SystemColors.Control
        Me.ResetBtn.Cursor = System.Windows.Forms.Cursors.Default
        Me.ResetBtn.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ResetBtn.ForeColor = System.Drawing.SystemColors.ControlText
        Me.ResetBtn.Location = New System.Drawing.Point(245, 45)
        Me.ResetBtn.Name = "ResetBtn"
        Me.ResetBtn.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.ResetBtn.Size = New System.Drawing.Size(170, 33)
        Me.ResetBtn.TabIndex = 43
        Me.ResetBtn.Text = "Create Entry (Make use of junk data)"
        Me.ResetBtn.UseVisualStyleBackColor = False
        '
        '_PPUEffModeOpt_3
        '
        Me._PPUEffModeOpt_3.BackColor = System.Drawing.SystemColors.Control
        Me._PPUEffModeOpt_3.Cursor = System.Windows.Forms.Cursors.Default
        Me._PPUEffModeOpt_3.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._PPUEffModeOpt_3.ForeColor = System.Drawing.SystemColors.ControlText
        Me._PPUEffModeOpt_3.Location = New System.Drawing.Point(8, 77)
        Me._PPUEffModeOpt_3.Name = "_PPUEffModeOpt_3"
        Me._PPUEffModeOpt_3.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._PPUEffModeOpt_3.Size = New System.Drawing.Size(182, 17)
        Me._PPUEffModeOpt_3.TabIndex = 40
        Me._PPUEffModeOpt_3.TabStop = True
        Me._PPUEffModeOpt_3.Text = "Scroll Gfx Load (Chosen ID):"
        Me._PPUEffModeOpt_3.UseVisualStyleBackColor = False
        '
        'TileDstPic
        '
        Me.TileDstPic.BackColor = System.Drawing.SystemColors.Control
        Me.TileDstPic.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.TileDstPic.Cursor = System.Windows.Forms.Cursors.Default
        Me.TileDstPic.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TileDstPic.ForeColor = System.Drawing.SystemColors.ControlText
        Me.TileDstPic.Location = New System.Drawing.Point(176, 306)
        Me.TileDstPic.Name = "TileDstPic"
        Me.TileDstPic.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.TileDstPic.Size = New System.Drawing.Size(133, 261)
        Me.TileDstPic.TabIndex = 37
        Me.TileDstPic.TabStop = False
        '
        '_ColTB_3
        '
        Me._ColTB_3.AcceptsReturn = True
        Me._ColTB_3.BackColor = System.Drawing.SystemColors.Window
        Me._ColTB_3.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._ColTB_3.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._ColTB_3.ForeColor = System.Drawing.SystemColors.WindowText
        Me._ColTB_3.Location = New System.Drawing.Point(80, 130)
        Me._ColTB_3.MaxLength = 0
        Me._ColTB_3.Name = "_ColTB_3"
        Me._ColTB_3.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._ColTB_3.Size = New System.Drawing.Size(33, 23)
        Me._ColTB_3.TabIndex = 35
        '
        '_ColTB_2
        '
        Me._ColTB_2.AcceptsReturn = True
        Me._ColTB_2.BackColor = System.Drawing.SystemColors.Window
        Me._ColTB_2.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._ColTB_2.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._ColTB_2.ForeColor = System.Drawing.SystemColors.WindowText
        Me._ColTB_2.Location = New System.Drawing.Point(48, 130)
        Me._ColTB_2.MaxLength = 0
        Me._ColTB_2.Name = "_ColTB_2"
        Me._ColTB_2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._ColTB_2.Size = New System.Drawing.Size(33, 23)
        Me._ColTB_2.TabIndex = 34
        '
        '_ColTB_1
        '
        Me._ColTB_1.AcceptsReturn = True
        Me._ColTB_1.BackColor = System.Drawing.SystemColors.Window
        Me._ColTB_1.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._ColTB_1.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._ColTB_1.ForeColor = System.Drawing.SystemColors.WindowText
        Me._ColTB_1.Location = New System.Drawing.Point(16, 130)
        Me._ColTB_1.MaxLength = 0
        Me._ColTB_1.Name = "_ColTB_1"
        Me._ColTB_1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._ColTB_1.Size = New System.Drawing.Size(33, 23)
        Me._ColTB_1.TabIndex = 33
        '
        '_ColTB_7
        '
        Me._ColTB_7.AcceptsReturn = True
        Me._ColTB_7.BackColor = System.Drawing.SystemColors.Window
        Me._ColTB_7.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._ColTB_7.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._ColTB_7.ForeColor = System.Drawing.SystemColors.WindowText
        Me._ColTB_7.Location = New System.Drawing.Point(208, 130)
        Me._ColTB_7.MaxLength = 0
        Me._ColTB_7.Name = "_ColTB_7"
        Me._ColTB_7.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._ColTB_7.Size = New System.Drawing.Size(33, 23)
        Me._ColTB_7.TabIndex = 32
        '
        '_ColTB_6
        '
        Me._ColTB_6.AcceptsReturn = True
        Me._ColTB_6.BackColor = System.Drawing.SystemColors.Window
        Me._ColTB_6.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._ColTB_6.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._ColTB_6.ForeColor = System.Drawing.SystemColors.WindowText
        Me._ColTB_6.Location = New System.Drawing.Point(176, 130)
        Me._ColTB_6.MaxLength = 0
        Me._ColTB_6.Name = "_ColTB_6"
        Me._ColTB_6.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._ColTB_6.Size = New System.Drawing.Size(33, 23)
        Me._ColTB_6.TabIndex = 31
        '
        '_ColTB_5
        '
        Me._ColTB_5.AcceptsReturn = True
        Me._ColTB_5.BackColor = System.Drawing.SystemColors.Window
        Me._ColTB_5.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._ColTB_5.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._ColTB_5.ForeColor = System.Drawing.SystemColors.WindowText
        Me._ColTB_5.Location = New System.Drawing.Point(144, 130)
        Me._ColTB_5.MaxLength = 0
        Me._ColTB_5.Name = "_ColTB_5"
        Me._ColTB_5.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._ColTB_5.Size = New System.Drawing.Size(33, 23)
        Me._ColTB_5.TabIndex = 30
        '
        'HasSprPalCheck
        '
        Me.HasSprPalCheck.BackColor = System.Drawing.SystemColors.Control
        Me.HasSprPalCheck.Cursor = System.Windows.Forms.Cursors.Default
        Me.HasSprPalCheck.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.HasSprPalCheck.ForeColor = System.Drawing.SystemColors.ControlText
        Me.HasSprPalCheck.Location = New System.Drawing.Point(257, 108)
        Me.HasSprPalCheck.Name = "HasSprPalCheck"
        Me.HasSprPalCheck.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.HasSprPalCheck.Size = New System.Drawing.Size(113, 19)
        Me.HasSprPalCheck.TabIndex = 29
        Me.HasSprPalCheck.Text = "Has Sprite Palette"
        Me.HasSprPalCheck.UseVisualStyleBackColor = False
        '
        '_PPUEffModeOpt_1
        '
        Me._PPUEffModeOpt_1.BackColor = System.Drawing.SystemColors.Control
        Me._PPUEffModeOpt_1.Cursor = System.Windows.Forms.Cursors.Default
        Me._PPUEffModeOpt_1.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._PPUEffModeOpt_1.ForeColor = System.Drawing.SystemColors.ControlText
        Me._PPUEffModeOpt_1.Location = New System.Drawing.Point(8, 31)
        Me._PPUEffModeOpt_1.Name = "_PPUEffModeOpt_1"
        Me._PPUEffModeOpt_1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._PPUEffModeOpt_1.Size = New System.Drawing.Size(201, 17)
        Me._PPUEffModeOpt_1.TabIndex = 26
        Me._PPUEffModeOpt_1.TabStop = True
        Me._PPUEffModeOpt_1.Text = "Primary Gfx Load (Chosen ID):"
        Me._PPUEffModeOpt_1.UseVisualStyleBackColor = False
        '
        'TileSrcPic
        '
        Me.TileSrcPic.BackColor = System.Drawing.SystemColors.Control
        Me.TileSrcPic.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.TileSrcPic.Cursor = System.Windows.Forms.Cursors.Default
        Me.TileSrcPic.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TileSrcPic.ForeColor = System.Drawing.SystemColors.ControlText
        Me.TileSrcPic.Location = New System.Drawing.Point(24, 306)
        Me.TileSrcPic.Name = "TileSrcPic"
        Me.TileSrcPic.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.TileSrcPic.Size = New System.Drawing.Size(133, 261)
        Me.TileSrcPic.TabIndex = 25
        Me.TileSrcPic.TabStop = False
        '
        'CHRLoadRemBtn
        '
        Me.CHRLoadRemBtn.BackColor = System.Drawing.SystemColors.Control
        Me.CHRLoadRemBtn.Cursor = System.Windows.Forms.Cursors.Default
        Me.CHRLoadRemBtn.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CHRLoadRemBtn.ForeColor = System.Drawing.SystemColors.ControlText
        Me.CHRLoadRemBtn.Location = New System.Drawing.Point(157, 199)
        Me.CHRLoadRemBtn.Name = "CHRLoadRemBtn"
        Me.CHRLoadRemBtn.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.CHRLoadRemBtn.Size = New System.Drawing.Size(57, 25)
        Me.CHRLoadRemBtn.TabIndex = 12
        Me.CHRLoadRemBtn.Text = "Remove"
        Me.CHRLoadRemBtn.UseVisualStyleBackColor = False
        '
        'CHRLoadNewButton
        '
        Me.CHRLoadNewButton.BackColor = System.Drawing.SystemColors.Control
        Me.CHRLoadNewButton.Cursor = System.Windows.Forms.Cursors.Default
        Me.CHRLoadNewButton.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CHRLoadNewButton.ForeColor = System.Drawing.SystemColors.ControlText
        Me.CHRLoadNewButton.Location = New System.Drawing.Point(157, 167)
        Me.CHRLoadNewButton.Name = "CHRLoadNewButton"
        Me.CHRLoadNewButton.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.CHRLoadNewButton.Size = New System.Drawing.Size(57, 25)
        Me.CHRLoadNewButton.TabIndex = 11
        Me.CHRLoadNewButton.Text = "New"
        Me.CHRLoadNewButton.UseVisualStyleBackColor = False
        '
        'CHRLoadList
        '
        Me.CHRLoadList.BackColor = System.Drawing.SystemColors.Window
        Me.CHRLoadList.Cursor = System.Windows.Forms.Cursors.Default
        Me.CHRLoadList.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CHRLoadList.ForeColor = System.Drawing.SystemColors.WindowText
        Me.CHRLoadList.ItemHeight = 16
        Me.CHRLoadList.Location = New System.Drawing.Point(16, 167)
        Me.CHRLoadList.Name = "CHRLoadList"
        Me.CHRLoadList.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.CHRLoadList.Size = New System.Drawing.Size(135, 116)
        Me.CHRLoadList.TabIndex = 10
        '
        '_ColPic_7
        '
        Me._ColPic_7.BackColor = System.Drawing.Color.FromArgb(CType(CType(15, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me._ColPic_7.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me._ColPic_7.Cursor = System.Windows.Forms.Cursors.Default
        Me._ColPic_7.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._ColPic_7.ForeColor = System.Drawing.SystemColors.ControlText
        Me._ColPic_7.Location = New System.Drawing.Point(208, 106)
        Me._ColPic_7.Name = "_ColPic_7"
        Me._ColPic_7.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._ColPic_7.Size = New System.Drawing.Size(33, 25)
        Me._ColPic_7.TabIndex = 9
        Me._ColPic_7.TabStop = False
        '
        '_ColPic_6
        '
        Me._ColPic_6.BackColor = System.Drawing.Color.FromArgb(CType(CType(15, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me._ColPic_6.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me._ColPic_6.Cursor = System.Windows.Forms.Cursors.Default
        Me._ColPic_6.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._ColPic_6.ForeColor = System.Drawing.SystemColors.ControlText
        Me._ColPic_6.Location = New System.Drawing.Point(176, 106)
        Me._ColPic_6.Name = "_ColPic_6"
        Me._ColPic_6.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._ColPic_6.Size = New System.Drawing.Size(33, 25)
        Me._ColPic_6.TabIndex = 8
        Me._ColPic_6.TabStop = False
        '
        '_ColPic_5
        '
        Me._ColPic_5.BackColor = System.Drawing.Color.FromArgb(CType(CType(15, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me._ColPic_5.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me._ColPic_5.Cursor = System.Windows.Forms.Cursors.Default
        Me._ColPic_5.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._ColPic_5.ForeColor = System.Drawing.SystemColors.ControlText
        Me._ColPic_5.Location = New System.Drawing.Point(144, 106)
        Me._ColPic_5.Name = "_ColPic_5"
        Me._ColPic_5.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._ColPic_5.Size = New System.Drawing.Size(33, 25)
        Me._ColPic_5.TabIndex = 7
        Me._ColPic_5.TabStop = False
        '
        '_ColPic_3
        '
        Me._ColPic_3.BackColor = System.Drawing.Color.FromArgb(CType(CType(15, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me._ColPic_3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me._ColPic_3.Cursor = System.Windows.Forms.Cursors.Default
        Me._ColPic_3.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._ColPic_3.ForeColor = System.Drawing.SystemColors.ControlText
        Me._ColPic_3.Location = New System.Drawing.Point(80, 106)
        Me._ColPic_3.Name = "_ColPic_3"
        Me._ColPic_3.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._ColPic_3.Size = New System.Drawing.Size(33, 25)
        Me._ColPic_3.TabIndex = 6
        Me._ColPic_3.TabStop = False
        '
        '_ColPic_2
        '
        Me._ColPic_2.BackColor = System.Drawing.Color.FromArgb(CType(CType(15, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me._ColPic_2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me._ColPic_2.Cursor = System.Windows.Forms.Cursors.Default
        Me._ColPic_2.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._ColPic_2.ForeColor = System.Drawing.SystemColors.ControlText
        Me._ColPic_2.Location = New System.Drawing.Point(48, 106)
        Me._ColPic_2.Name = "_ColPic_2"
        Me._ColPic_2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._ColPic_2.Size = New System.Drawing.Size(33, 25)
        Me._ColPic_2.TabIndex = 5
        Me._ColPic_2.TabStop = False
        '
        '_ColPic_1
        '
        Me._ColPic_1.BackColor = System.Drawing.Color.FromArgb(CType(CType(15, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me._ColPic_1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me._ColPic_1.Cursor = System.Windows.Forms.Cursors.Default
        Me._ColPic_1.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._ColPic_1.ForeColor = System.Drawing.SystemColors.ControlText
        Me._ColPic_1.Location = New System.Drawing.Point(16, 106)
        Me._ColPic_1.Name = "_ColPic_1"
        Me._ColPic_1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._ColPic_1.Size = New System.Drawing.Size(33, 25)
        Me._ColPic_1.TabIndex = 4
        Me._ColPic_1.TabStop = False
        '
        'EffIDUD
        '
        Me.EffIDUD.Hexadecimal = True
        Me.EffIDUD.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.EffIDUD.Location = New System.Drawing.Point(194, 76)
        Me.EffIDUD.Maximum = New Decimal(New Integer() {79, 0, 0, 0})
        Me.EffIDUD.Name = "EffIDUD"
        Me.EffIDUD.Size = New System.Drawing.Size(45, 23)
        Me.EffIDUD.TabIndex = 3
        '
        '_PPUEffModeOpt_2
        '
        Me._PPUEffModeOpt_2.BackColor = System.Drawing.SystemColors.Control
        Me._PPUEffModeOpt_2.Cursor = System.Windows.Forms.Cursors.Default
        Me._PPUEffModeOpt_2.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._PPUEffModeOpt_2.ForeColor = System.Drawing.SystemColors.ControlText
        Me._PPUEffModeOpt_2.Location = New System.Drawing.Point(8, 58)
        Me._PPUEffModeOpt_2.Name = "_PPUEffModeOpt_2"
        Me._PPUEffModeOpt_2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._PPUEffModeOpt_2.Size = New System.Drawing.Size(224, 17)
        Me._PPUEffModeOpt_2.TabIndex = 1
        Me._PPUEffModeOpt_2.TabStop = True
        Me._PPUEffModeOpt_2.Text = "Scroll Gfx Load (Current Scroll-Map)"
        Me._PPUEffModeOpt_2.UseVisualStyleBackColor = False
        '
        '_PPUEffModeOpt_0
        '
        Me._PPUEffModeOpt_0.BackColor = System.Drawing.SystemColors.Control
        Me._PPUEffModeOpt_0.Cursor = System.Windows.Forms.Cursors.Default
        Me._PPUEffModeOpt_0.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._PPUEffModeOpt_0.ForeColor = System.Drawing.SystemColors.ControlText
        Me._PPUEffModeOpt_0.Location = New System.Drawing.Point(8, 12)
        Me._PPUEffModeOpt_0.Name = "_PPUEffModeOpt_0"
        Me._PPUEffModeOpt_0.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._PPUEffModeOpt_0.Size = New System.Drawing.Size(201, 17)
        Me._PPUEffModeOpt_0.TabIndex = 0
        Me._PPUEffModeOpt_0.TabStop = True
        Me._PPUEffModeOpt_0.Text = "Primary Gfx Load (Current Level)"
        Me._PPUEffModeOpt_0.UseVisualStyleBackColor = False
        '
        'SrcBankUD
        '
        Me.SrcBankUD.Hexadecimal = True
        Me.SrcBankUD.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.SrcBankUD.Location = New System.Drawing.Point(303, 167)
        Me.SrcBankUD.Maximum = New Decimal(New Integer() {256, 0, 0, 0})
        Me.SrcBankUD.Name = "SrcBankUD"
        Me.SrcBankUD.Size = New System.Drawing.Size(45, 23)
        Me.SrcBankUD.TabIndex = 14
        '
        'SrcHiUD
        '
        Me.SrcHiUD.Hexadecimal = True
        Me.SrcHiUD.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.SrcHiUD.Location = New System.Drawing.Point(327, 199)
        Me.SrcHiUD.Maximum = New Decimal(New Integer() {256, 0, 0, 0})
        Me.SrcHiUD.Name = "SrcHiUD"
        Me.SrcHiUD.Size = New System.Drawing.Size(45, 23)
        Me.SrcHiUD.TabIndex = 18
        '
        'CopyTilesUD
        '
        Me.CopyTilesUD.Hexadecimal = True
        Me.CopyTilesUD.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.CopyTilesUD.Location = New System.Drawing.Point(351, 263)
        Me.CopyTilesUD.Maximum = New Decimal(New Integer() {256, 0, 0, 0})
        Me.CopyTilesUD.Name = "CopyTilesUD"
        Me.CopyTilesUD.Size = New System.Drawing.Size(45, 23)
        Me.CopyTilesUD.TabIndex = 21
        '
        'DstVRAMUD
        '
        Me.DstVRAMUD.Hexadecimal = True
        Me.DstVRAMUD.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.DstVRAMUD.Location = New System.Drawing.Point(359, 231)
        Me.DstVRAMUD.Maximum = New Decimal(New Integer() {256, 0, 0, 0})
        Me.DstVRAMUD.Name = "DstVRAMUD"
        Me.DstVRAMUD.Size = New System.Drawing.Size(45, 23)
        Me.DstVRAMUD.TabIndex = 24
        '
        'LSDIDUD
        '
        Me.LSDIDUD.Hexadecimal = True
        Me.LSDIDUD.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.LSDIDUD.Location = New System.Drawing.Point(193, 30)
        Me.LSDIDUD.Maximum = New Decimal(New Integer() {111, 0, 0, 0})
        Me.LSDIDUD.Name = "LSDIDUD"
        Me.LSDIDUD.Size = New System.Drawing.Size(45, 23)
        Me.LSDIDUD.TabIndex = 27
        '
        'Line2
        '
        Me.Line2.BackColor = System.Drawing.SystemColors.WindowText
        Me.Line2.Location = New System.Drawing.Point(304, 436)
        Me.Line2.Name = "Line2"
        Me.Line2.Size = New System.Drawing.Size(80, 1)
        Me.Line2.TabIndex = 48
        '
        'Line1
        '
        Me.Line1.BackColor = System.Drawing.SystemColors.WindowText
        Me.Line1.Location = New System.Drawing.Point(304, 308)
        Me.Line1.Name = "Line1"
        Me.Line1.Size = New System.Drawing.Size(80, 1)
        Me.Line1.TabIndex = 49
        '
        'Label10
        '
        Me.Label10.BackColor = System.Drawing.SystemColors.Control
        Me.Label10.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label10.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label10.Location = New System.Drawing.Point(312, 436)
        Me.Label10.Name = "Label10"
        Me.Label10.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label10.Size = New System.Drawing.Size(103, 36)
        Me.Label10.TabIndex = 42
        Me.Label10.Text = "SPR - $1000"
        '
        'Label8
        '
        Me.Label8.BackColor = System.Drawing.SystemColors.Control
        Me.Label8.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label8.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label8.Location = New System.Drawing.Point(312, 308)
        Me.Label8.Name = "Label8"
        Me.Label8.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label8.Size = New System.Drawing.Size(97, 23)
        Me.Label8.TabIndex = 41
        Me.Label8.Text = "BG  - $0000"
        '
        'FreeSpaceLab
        '
        Me.FreeSpaceLab.BackColor = System.Drawing.SystemColors.Control
        Me.FreeSpaceLab.Cursor = System.Windows.Forms.Cursors.Default
        Me.FreeSpaceLab.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FreeSpaceLab.ForeColor = System.Drawing.SystemColors.ControlText
        Me.FreeSpaceLab.Location = New System.Drawing.Point(321, 80)
        Me.FreeSpaceLab.Name = "FreeSpaceLab"
        Me.FreeSpaceLab.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.FreeSpaceLab.Size = New System.Drawing.Size(81, 17)
        Me.FreeSpaceLab.TabIndex = 39
        '
        'Label7
        '
        Me.Label7.BackColor = System.Drawing.SystemColors.Control
        Me.Label7.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label7.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label7.Location = New System.Drawing.Point(249, 80)
        Me.Label7.Name = "Label7"
        Me.Label7.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label7.Size = New System.Drawing.Size(81, 17)
        Me.Label7.TabIndex = 38
        Me.Label7.Text = "Free Space:"
        '
        'Label5
        '
        Me.Label5.BackColor = System.Drawing.SystemColors.Control
        Me.Label5.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label5.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label5.Location = New System.Drawing.Point(24, 290)
        Me.Label5.Name = "Label5"
        Me.Label5.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label5.Size = New System.Drawing.Size(133, 19)
        Me.Label5.TabIndex = 36
        Me.Label5.Text = "Source Chunk:"
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.SystemColors.Control
        Me.Label4.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label4.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label4.Location = New System.Drawing.Point(221, 231)
        Me.Label4.Name = "Label4"
        Me.Label4.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label4.Size = New System.Drawing.Size(173, 19)
        Me.Label4.TabIndex = 22
        Me.Label4.Text = "Destionation VRAM High:"
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.SystemColors.Control
        Me.Label3.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label3.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label3.Location = New System.Drawing.Point(221, 263)
        Me.Label3.Name = "Label3"
        Me.Label3.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label3.Size = New System.Drawing.Size(161, 23)
        Me.Label3.TabIndex = 19
        Me.Label3.Text = "Number of tiles to copy:"
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.SystemColors.Control
        Me.Label2.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label2.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label2.Location = New System.Drawing.Point(221, 199)
        Me.Label2.Name = "Label2"
        Me.Label2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label2.Size = New System.Drawing.Size(125, 25)
        Me.Label2.TabIndex = 16
        Me.Label2.Text = "Source PRG High:"
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.SystemColors.Control
        Me.Label1.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label1.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label1.Location = New System.Drawing.Point(221, 167)
        Me.Label1.Name = "Label1"
        Me.Label1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label1.Size = New System.Drawing.Size(108, 23)
        Me.Label1.TabIndex = 15
        Me.Label1.Text = "Source Bank:"
        '
        'CHRLoadDOWN
        '
        Me.CHRLoadDOWN.Image = CType(resources.GetObject("CHRLoadDOWN.Image"), System.Drawing.Image)
        Me.CHRLoadDOWN.Location = New System.Drawing.Point(157, 251)
        Me.CHRLoadDOWN.Name = "CHRLoadDOWN"
        Me.CHRLoadDOWN.Size = New System.Drawing.Size(20, 16)
        Me.CHRLoadDOWN.TabIndex = 50
        Me.CHRLoadDOWN.UseVisualStyleBackColor = True
        '
        'CHRLoadUP
        '
        Me.CHRLoadUP.Image = CType(resources.GetObject("CHRLoadUP.Image"), System.Drawing.Image)
        Me.CHRLoadUP.Location = New System.Drawing.Point(157, 234)
        Me.CHRLoadUP.Name = "CHRLoadUP"
        Me.CHRLoadUP.Size = New System.Drawing.Size(20, 16)
        Me.CHRLoadUP.TabIndex = 51
        Me.CHRLoadUP.UseVisualStyleBackColor = True
        '
        'Label6
        '
        Me.Label6.BackColor = System.Drawing.SystemColors.Control
        Me.Label6.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label6.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label6.Location = New System.Drawing.Point(176, 290)
        Me.Label6.Name = "Label6"
        Me.Label6.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label6.Size = New System.Drawing.Size(133, 19)
        Me.Label6.TabIndex = 52
        Me.Label6.Text = "VRAM Tile Layout:"
        '
        '_ColTB_0
        '
        Me._ColTB_0.AcceptsReturn = True
        Me._ColTB_0.BackColor = System.Drawing.SystemColors.Window
        Me._ColTB_0.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._ColTB_0.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._ColTB_0.ForeColor = System.Drawing.SystemColors.WindowText
        Me._ColTB_0.Location = New System.Drawing.Point(421, 104)
        Me._ColTB_0.MaxLength = 0
        Me._ColTB_0.Name = "_ColTB_0"
        Me._ColTB_0.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._ColTB_0.Size = New System.Drawing.Size(33, 23)
        Me._ColTB_0.TabIndex = 53
        Me._ColTB_0.Visible = False
        '
        '_ColPic_0
        '
        Me._ColPic_0.BackColor = System.Drawing.Color.FromArgb(CType(CType(15, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me._ColPic_0.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me._ColPic_0.Cursor = System.Windows.Forms.Cursors.Default
        Me._ColPic_0.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._ColPic_0.ForeColor = System.Drawing.SystemColors.ControlText
        Me._ColPic_0.Location = New System.Drawing.Point(421, 77)
        Me._ColPic_0.Name = "_ColPic_0"
        Me._ColPic_0.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._ColPic_0.Size = New System.Drawing.Size(33, 25)
        Me._ColPic_0.TabIndex = 54
        Me._ColPic_0.TabStop = False
        Me._ColPic_0.Visible = False
        '
        '_ColPic_4
        '
        Me._ColPic_4.BackColor = System.Drawing.Color.FromArgb(CType(CType(15, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me._ColPic_4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me._ColPic_4.Cursor = System.Windows.Forms.Cursors.Default
        Me._ColPic_4.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._ColPic_4.ForeColor = System.Drawing.SystemColors.ControlText
        Me._ColPic_4.Location = New System.Drawing.Point(469, 80)
        Me._ColPic_4.Name = "_ColPic_4"
        Me._ColPic_4.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._ColPic_4.Size = New System.Drawing.Size(33, 25)
        Me._ColPic_4.TabIndex = 55
        Me._ColPic_4.TabStop = False
        Me._ColPic_4.Visible = False
        '
        '_ColTB_4
        '
        Me._ColTB_4.AcceptsReturn = True
        Me._ColTB_4.BackColor = System.Drawing.SystemColors.Window
        Me._ColTB_4.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._ColTB_4.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._ColTB_4.ForeColor = System.Drawing.SystemColors.WindowText
        Me._ColTB_4.Location = New System.Drawing.Point(469, 111)
        Me._ColTB_4.MaxLength = 0
        Me._ColTB_4.Name = "_ColTB_4"
        Me._ColTB_4.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._ColTB_4.Size = New System.Drawing.Size(33, 23)
        Me._ColTB_4.TabIndex = 56
        Me._ColTB_4.Visible = False
        '
        'BtnDumpSpriteChar
        '
        Me.BtnDumpSpriteChar.Location = New System.Drawing.Point(316, 520)
        Me.BtnDumpSpriteChar.Name = "BtnDumpSpriteChar"
        Me.BtnDumpSpriteChar.Size = New System.Drawing.Size(80, 43)
        Me.BtnDumpSpriteChar.TabIndex = 57
        Me.BtnDumpSpriteChar.Text = "Dump Sprite CHR"
        Me.BtnDumpSpriteChar.UseVisualStyleBackColor = True
        '
        'GfxLoadEd
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.ClientSize = New System.Drawing.Size(422, 575)
        Me.Controls.Add(Me.BtnDumpSpriteChar)
        Me.Controls.Add(Me._ColTB_4)
        Me.Controls.Add(Me._ColPic_4)
        Me.Controls.Add(Me._ColPic_0)
        Me.Controls.Add(Me._ColTB_0)
        Me.Controls.Add(Me.TileDstPic)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.LSDIDUD)
        Me.Controls.Add(Me.CHRLoadUP)
        Me.Controls.Add(Me.CHRLoadDOWN)
        Me.Controls.Add(Me.Text1)
        Me.Controls.Add(Me.LoadGfxBtn)
        Me.Controls.Add(Me.Command1)
        Me.Controls.Add(Me.ResetBtn)
        Me.Controls.Add(Me._PPUEffModeOpt_3)
        Me.Controls.Add(Me._ColTB_3)
        Me.Controls.Add(Me._ColTB_2)
        Me.Controls.Add(Me._ColTB_1)
        Me.Controls.Add(Me._ColTB_7)
        Me.Controls.Add(Me._ColTB_6)
        Me.Controls.Add(Me._ColTB_5)
        Me.Controls.Add(Me.HasSprPalCheck)
        Me.Controls.Add(Me._PPUEffModeOpt_1)
        Me.Controls.Add(Me.TileSrcPic)
        Me.Controls.Add(Me.CHRLoadRemBtn)
        Me.Controls.Add(Me.CHRLoadNewButton)
        Me.Controls.Add(Me.CHRLoadList)
        Me.Controls.Add(Me._ColPic_7)
        Me.Controls.Add(Me._ColPic_6)
        Me.Controls.Add(Me._ColPic_5)
        Me.Controls.Add(Me._ColPic_3)
        Me.Controls.Add(Me._ColPic_2)
        Me.Controls.Add(Me._ColPic_1)
        Me.Controls.Add(Me.EffIDUD)
        Me.Controls.Add(Me._PPUEffModeOpt_2)
        Me.Controls.Add(Me._PPUEffModeOpt_0)
        Me.Controls.Add(Me.SrcBankUD)
        Me.Controls.Add(Me.SrcHiUD)
        Me.Controls.Add(Me.CopyTilesUD)
        Me.Controls.Add(Me.DstVRAMUD)
        Me.Controls.Add(Me.Line2)
        Me.Controls.Add(Me.Line1)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.FreeSpaceLab)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Cursor = System.Windows.Forms.Cursors.Default
        Me.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.Location = New System.Drawing.Point(3, 28)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "GfxLoadEd"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Text = "MM4 - Graphics Load Editor"
        CType(Me.TileDstPic, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TileSrcPic, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me._ColPic_7, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me._ColPic_6, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me._ColPic_5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me._ColPic_3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me._ColPic_2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me._ColPic_1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EffIDUD, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SrcBankUD, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SrcHiUD, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CopyTilesUD, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DstVRAMUD, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LSDIDUD, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me._ColPic_0, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me._ColPic_4, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents CHRLoadDOWN As Button
    Friend WithEvents CHRLoadUP As Button
    Public WithEvents Label6 As Label
    Public WithEvents _ColTB_0 As TextBox
    Public WithEvents _ColPic_0 As PictureBox
    Public WithEvents _ColPic_4 As PictureBox
    Public WithEvents _ColTB_4 As TextBox
    Friend WithEvents BtnDumpSpriteChar As Button
#End Region
End Class