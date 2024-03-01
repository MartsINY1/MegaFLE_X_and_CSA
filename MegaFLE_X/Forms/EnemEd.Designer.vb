<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> Partial Class EnemEd
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
	Public WithEvents SprAnimTB As System.Windows.Forms.TextBox
	Public WithEvents AnimCheck As System.Windows.Forms.CheckBox
	Public WithEvents SprGroupBtn As System.Windows.Forms.Button
	Public WithEvents DelEnemBtn As System.Windows.Forms.Button
	Public WithEvents InsEnemBtn As System.Windows.Forms.Button
	Public WithEvents FavLoadBtn As System.Windows.Forms.Button
	Public WithEvents FavSaveBtn As System.Windows.Forms.Button
    Public WithEvents RemFavBtn As System.Windows.Forms.Button
    Public WithEvents AddFavBtn As System.Windows.Forms.Button
    Public WithEvents FavEnemList As System.Windows.Forms.ListBox
    Public WithEvents AutoSetCheck As System.Windows.Forms.CheckBox
    Public WithEvents FindGFXBtn As System.Windows.Forms.Button
    Public WithEvents ScrnPresUD As System.Windows.Forms.NumericUpDown
    Public WithEvents CurScrnTB As System.Windows.Forms.TextBox
    Public WithEvents PCShowCmd As System.Windows.Forms.Button
    Public WithEvents ScrnScroll As System.Windows.Forms.HScrollBar
    Public WithEvents PalPic As System.Windows.Forms.PictureBox
    Public WithEvents Label11 As System.Windows.Forms.Label
    Public WithEvents CurScrollLabel As System.Windows.Forms.Label
    Public WithEvents Label1 As System.Windows.Forms.Label
    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(EnemEd))
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.CurScrnTB = New System.Windows.Forms.TextBox()
        Me.SBCheck = New System.Windows.Forms.CheckBox()
        Me.CurEnemUD = New System.Windows.Forms.NumericUpDown()
        Me.YUD = New System.Windows.Forms.NumericUpDown()
        Me.XUD = New System.Windows.Forms.NumericUpDown()
        Me.HPUD = New System.Windows.Forms.NumericUpDown()
        Me.TypeUD = New System.Windows.Forms.NumericUpDown()
        Me.WeaponDmgUD = New System.Windows.Forms.NumericUpDown()
        Me.EnemDmgUD = New System.Windows.Forms.NumericUpDown()
        Me.ScrUD = New System.Windows.Forms.NumericUpDown()
        Me.ScreenPic = New System.Windows.Forms.PictureBox()
        Me.SprAnimTB = New System.Windows.Forms.TextBox()
        Me.AnimCheck = New System.Windows.Forms.CheckBox()
        Me.SprGroupBtn = New System.Windows.Forms.Button()
        Me.DelEnemBtn = New System.Windows.Forms.Button()
        Me.InsEnemBtn = New System.Windows.Forms.Button()
        Me.FavLoadBtn = New System.Windows.Forms.Button()
        Me.FavSaveBtn = New System.Windows.Forms.Button()
        Me.RemFavBtn = New System.Windows.Forms.Button()
        Me.AddFavBtn = New System.Windows.Forms.Button()
        Me.FavEnemList = New System.Windows.Forms.ListBox()
        Me.AutoSetCheck = New System.Windows.Forms.CheckBox()
        Me.FindGFXBtn = New System.Windows.Forms.Button()
        Me.ScrnPresUD = New System.Windows.Forms.NumericUpDown()
        Me.PCShowCmd = New System.Windows.Forms.Button()
        Me.ScrnScroll = New System.Windows.Forms.HScrollBar()
        Me.PalPic = New System.Windows.Forms.PictureBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.CurScrollLabel = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TabControlEnemEd = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.gbxGeneral = New System.Windows.Forms.GroupBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.lblEnemyName = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.lblTypeGeneralPan = New System.Windows.Forms.Label()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.gbxWeapon = New System.Windows.Forms.GroupBox()
        Me.lblTypeWeaponDamagePan = New System.Windows.Forms.Label()
        Me.WeaponList = New System.Windows.Forms.ComboBox()
        Me._SettingsCheck_0 = New System.Windows.Forms.CheckBox()
        Me._SettingsCheck_1 = New System.Windows.Forms.CheckBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.WeaponIcon = New System.Windows.Forms.PictureBox()
        Me.Line1 = New System.Windows.Forms.Label()
        Me.lblDamageToMegaMan = New System.Windows.Forms.Label()
        Me.TilePic = New System.Windows.Forms.PictureBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.GFXEnemList = New System.Windows.Forms.ListBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.BGPalUD = New System.Windows.Forms.NumericUpDown()
        Me.PalSetUD = New System.Windows.Forms.NumericUpDown()
        Me.BDCheck = New System.Windows.Forms.CheckBox()
        Me.BGPalCheck = New System.Windows.Forms.CheckBox()
        Me._GemFrame_2 = New System.Windows.Forms.GroupBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.EffUD = New System.Windows.Forms.NumericUpDown()
        Me._GemFrame_1 = New System.Windows.Forms.GroupBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.TopLabel = New System.Windows.Forms.Label()
        Me.BottomLabel = New System.Windows.Forms.Label()
        Me.Shape1 = New System.Windows.Forms.Label()
        Me._EffSprUD_5 = New System.Windows.Forms.NumericUpDown()
        Me._EffSprUD_4 = New System.Windows.Forms.NumericUpDown()
        Me._EffSprUD_1 = New System.Windows.Forms.NumericUpDown()
        Me._EffSprTypeOpt_1 = New System.Windows.Forms.RadioButton()
        Me._EffSprTypeOpt_0 = New System.Windows.Forms.RadioButton()
        Me._EffSprColTB_1 = New System.Windows.Forms.TextBox()
        Me._EffSprColTB_2 = New System.Windows.Forms.TextBox()
        Me._EffSprColTB_3 = New System.Windows.Forms.TextBox()
        Me._EffSprColPic_1 = New System.Windows.Forms.PictureBox()
        Me._EffSprColPic_2 = New System.Windows.Forms.PictureBox()
        Me._EffSprColPic_3 = New System.Windows.Forms.PictureBox()
        Me.Frame2 = New System.Windows.Forms.Panel()
        Me._EffSprSlot_3 = New System.Windows.Forms.RadioButton()
        Me._EffSprSlot_2 = New System.Windows.Forms.RadioButton()
        Me._EffSprSlot_1 = New System.Windows.Forms.RadioButton()
        Me._EffSprSlot_0 = New System.Windows.Forms.RadioButton()
        Me._EffSprUD_2 = New System.Windows.Forms.NumericUpDown()
        Me._EffSprTypeOpt_2 = New System.Windows.Forms.RadioButton()
        Me.EffSprEdFrame = New System.Windows.Forms.GroupBox()
        Me._EffSprTypeOpt_3 = New System.Windows.Forms.RadioButton()
        Me._EffSprAEdBtn_1 = New System.Windows.Forms.Button()
        Me._EffSprAEdBtn_0 = New System.Windows.Forms.Button()
        Me._EffSprUD_0 = New System.Windows.Forms.NumericUpDown()
        Me._EffSprUD_3 = New System.Windows.Forms.NumericUpDown()
        Me._GemFrame_0 = New System.Windows.Forms.GroupBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Bank1UD = New System.Windows.Forms.NumericUpDown()
        Me.Bank0UD = New System.Windows.Forms.NumericUpDown()
        Me.GFXSetUD = New System.Windows.Forms.NumericUpDown()
        Me.Label7 = New System.Windows.Forms.Label()
        CType(Me.CurEnemUD, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.YUD, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.XUD, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.HPUD, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TypeUD, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.WeaponDmgUD, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EnemDmgUD, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ScrUD, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ScreenPic, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ScrnPresUD, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PalPic, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabControlEnemEd.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.gbxGeneral.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        Me.gbxWeapon.SuspendLayout()
        CType(Me.WeaponIcon, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TilePic, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BGPalUD, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PalSetUD, System.ComponentModel.ISupportInitialize).BeginInit()
        Me._GemFrame_2.SuspendLayout()
        CType(Me.EffUD, System.ComponentModel.ISupportInitialize).BeginInit()
        Me._GemFrame_1.SuspendLayout()
        CType(Me._EffSprUD_5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me._EffSprUD_4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me._EffSprUD_1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me._EffSprColPic_1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me._EffSprColPic_2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me._EffSprColPic_3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Frame2.SuspendLayout()
        CType(Me._EffSprUD_2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.EffSprEdFrame.SuspendLayout()
        CType(Me._EffSprUD_0, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me._EffSprUD_3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me._GemFrame_0.SuspendLayout()
        CType(Me.Bank1UD, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Bank0UD, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GFXSetUD, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ToolTip1
        '
        Me.ToolTip1.AutoPopDelay = 10000
        Me.ToolTip1.InitialDelay = 500
        Me.ToolTip1.ReshowDelay = 100
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
        Me.CurScrnTB.TabIndex = 5
        Me.ToolTip1.SetToolTip(Me.CurScrnTB, "Current Screen Number displaying in the above window.")
        '
        'SBCheck
        '
        Me.SBCheck.BackColor = System.Drawing.SystemColors.Control
        Me.SBCheck.Cursor = System.Windows.Forms.Cursors.Default
        Me.SBCheck.Enabled = False
        Me.SBCheck.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SBCheck.ForeColor = System.Drawing.SystemColors.ControlText
        Me.SBCheck.Location = New System.Drawing.Point(4, 29)
        Me.SBCheck.Name = "SBCheck"
        Me.SBCheck.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.SBCheck.Size = New System.Drawing.Size(121, 19)
        Me.SBCheck.TabIndex = 51
        Me.SBCheck.Text = "Scroll Back Enable"
        Me.ToolTip1.SetToolTip(Me.SBCheck, "Leftward scrolltype")
        Me.SBCheck.UseVisualStyleBackColor = False
        Me.SBCheck.Visible = False
        '
        'CurEnemUD
        '
        Me.CurEnemUD.Location = New System.Drawing.Point(54, 0)
        Me.CurEnemUD.Maximum = New Decimal(New Integer() {127, 0, 0, 0})
        Me.CurEnemUD.Name = "CurEnemUD"
        Me.CurEnemUD.Size = New System.Drawing.Size(45, 20)
        Me.CurEnemUD.TabIndex = 1
        Me.ToolTip1.SetToolTip(Me.CurEnemUD, "Current Enemy number selected in the stage.")
        '
        'YUD
        '
        Me.YUD.Hexadecimal = True
        Me.YUD.Location = New System.Drawing.Point(129, 96)
        Me.YUD.Maximum = New Decimal(New Integer() {256, 0, 0, 0})
        Me.YUD.Name = "YUD"
        Me.YUD.Size = New System.Drawing.Size(45, 20)
        Me.YUD.TabIndex = 108
        Me.ToolTip1.SetToolTip(Me.YUD, "Vertical position on the screen")
        '
        'XUD
        '
        Me.XUD.Hexadecimal = True
        Me.XUD.Location = New System.Drawing.Point(129, 72)
        Me.XUD.Maximum = New Decimal(New Integer() {256, 0, 0, 0})
        Me.XUD.Name = "XUD"
        Me.XUD.Size = New System.Drawing.Size(45, 20)
        Me.XUD.TabIndex = 107
        Me.ToolTip1.SetToolTip(Me.XUD, "Horizontal position on the screen")
        '
        'HPUD
        '
        Me.HPUD.Hexadecimal = True
        Me.HPUD.Location = New System.Drawing.Point(129, 24)
        Me.HPUD.Maximum = New Decimal(New Integer() {256, 0, 0, 0})
        Me.HPUD.Name = "HPUD"
        Me.HPUD.Size = New System.Drawing.Size(45, 20)
        Me.HPUD.TabIndex = 102
        Me.ToolTip1.SetToolTip(Me.HPUD, "Number of hits a sprite can sustain")
        '
        'TypeUD
        '
        Me.TypeUD.Hexadecimal = True
        Me.TypeUD.Location = New System.Drawing.Point(54, 24)
        Me.TypeUD.Maximum = New Decimal(New Integer() {256, 0, 0, 0})
        Me.TypeUD.Name = "TypeUD"
        Me.TypeUD.Size = New System.Drawing.Size(45, 20)
        Me.TypeUD.TabIndex = 2
        Me.ToolTip1.SetToolTip(Me.TypeUD, "Sprite type ID number")
        '
        'WeaponDmgUD
        '
        Me.WeaponDmgUD.Hexadecimal = True
        Me.WeaponDmgUD.Location = New System.Drawing.Point(129, 76)
        Me.WeaponDmgUD.Maximum = New Decimal(New Integer() {256, 0, 0, 0})
        Me.WeaponDmgUD.Name = "WeaponDmgUD"
        Me.WeaponDmgUD.Size = New System.Drawing.Size(45, 20)
        Me.WeaponDmgUD.TabIndex = 99
        Me.ToolTip1.SetToolTip(Me.WeaponDmgUD, "Damage a weapon does to a enemy")
        '
        'EnemDmgUD
        '
        Me.EnemDmgUD.Hexadecimal = True
        Me.EnemDmgUD.Location = New System.Drawing.Point(129, 36)
        Me.EnemDmgUD.Maximum = New Decimal(New Integer() {256, 0, 0, 0})
        Me.EnemDmgUD.Name = "EnemDmgUD"
        Me.EnemDmgUD.Size = New System.Drawing.Size(45, 20)
        Me.EnemDmgUD.TabIndex = 85
        Me.ToolTip1.SetToolTip(Me.EnemDmgUD, "Damage that a enemy does to Megaman")
        '
        'ScrUD
        '
        Me.ScrUD.Hexadecimal = True
        Me.ScrUD.Location = New System.Drawing.Point(129, 120)
        Me.ScrUD.Maximum = New Decimal(New Integer() {256, 0, 0, 0})
        Me.ScrUD.Name = "ScrUD"
        Me.ScrUD.Size = New System.Drawing.Size(45, 20)
        Me.ScrUD.TabIndex = 110
        Me.ToolTip1.SetToolTip(Me.ScrUD, "Screen number current sprite appears on.")
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
        Me.ScreenPic.Size = New System.Drawing.Size(260, 260)
        Me.ScreenPic.TabIndex = 0
        Me.ScreenPic.TabStop = False
        '
        'SprAnimTB
        '
        Me.SprAnimTB.AcceptsReturn = True
        Me.SprAnimTB.BackColor = System.Drawing.SystemColors.Window
        Me.SprAnimTB.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.SprAnimTB.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SprAnimTB.ForeColor = System.Drawing.SystemColors.WindowText
        Me.SprAnimTB.Location = New System.Drawing.Point(632, 344)
        Me.SprAnimTB.MaxLength = 0
        Me.SprAnimTB.Name = "SprAnimTB"
        Me.SprAnimTB.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.SprAnimTB.Size = New System.Drawing.Size(49, 20)
        Me.SprAnimTB.TabIndex = 96
        Me.SprAnimTB.Visible = False
        '
        'AnimCheck
        '
        Me.AnimCheck.BackColor = System.Drawing.SystemColors.Control
        Me.AnimCheck.Cursor = System.Windows.Forms.Cursors.Default
        Me.AnimCheck.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.AnimCheck.ForeColor = System.Drawing.SystemColors.ControlText
        Me.AnimCheck.Location = New System.Drawing.Point(512, 337)
        Me.AnimCheck.Name = "AnimCheck"
        Me.AnimCheck.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.AnimCheck.Size = New System.Drawing.Size(169, 17)
        Me.AnimCheck.TabIndex = 95
        Me.AnimCheck.Text = "Animate Sprites"
        Me.AnimCheck.UseVisualStyleBackColor = False
        '
        'SprGroupBtn
        '
        Me.SprGroupBtn.BackColor = System.Drawing.SystemColors.Control
        Me.SprGroupBtn.Cursor = System.Windows.Forms.Cursors.Default
        Me.SprGroupBtn.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SprGroupBtn.ForeColor = System.Drawing.SystemColors.ControlText
        Me.SprGroupBtn.Location = New System.Drawing.Point(400, 315)
        Me.SprGroupBtn.Name = "SprGroupBtn"
        Me.SprGroupBtn.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.SprGroupBtn.Size = New System.Drawing.Size(106, 25)
        Me.SprGroupBtn.TabIndex = 94
        Me.SprGroupBtn.Text = "Insert Sprite Group"
        Me.SprGroupBtn.UseVisualStyleBackColor = False
        '
        'DelEnemBtn
        '
        Me.DelEnemBtn.BackColor = System.Drawing.SystemColors.Control
        Me.DelEnemBtn.Cursor = System.Windows.Forms.Cursors.Default
        Me.DelEnemBtn.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DelEnemBtn.ForeColor = System.Drawing.SystemColors.ControlText
        Me.DelEnemBtn.Location = New System.Drawing.Point(304, 315)
        Me.DelEnemBtn.Name = "DelEnemBtn"
        Me.DelEnemBtn.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.DelEnemBtn.Size = New System.Drawing.Size(89, 25)
        Me.DelEnemBtn.TabIndex = 93
        Me.DelEnemBtn.Text = "Delete Enemy"
        Me.DelEnemBtn.UseVisualStyleBackColor = False
        '
        'InsEnemBtn
        '
        Me.InsEnemBtn.BackColor = System.Drawing.SystemColors.Control
        Me.InsEnemBtn.Cursor = System.Windows.Forms.Cursors.Default
        Me.InsEnemBtn.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.InsEnemBtn.ForeColor = System.Drawing.SystemColors.ControlText
        Me.InsEnemBtn.Location = New System.Drawing.Point(208, 315)
        Me.InsEnemBtn.Name = "InsEnemBtn"
        Me.InsEnemBtn.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.InsEnemBtn.Size = New System.Drawing.Size(89, 25)
        Me.InsEnemBtn.TabIndex = 92
        Me.InsEnemBtn.Text = "Insert Enemy"
        Me.InsEnemBtn.UseVisualStyleBackColor = False
        '
        'FavLoadBtn
        '
        Me.FavLoadBtn.BackColor = System.Drawing.SystemColors.Control
        Me.FavLoadBtn.Cursor = System.Windows.Forms.Cursors.Default
        Me.FavLoadBtn.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FavLoadBtn.ForeColor = System.Drawing.SystemColors.ControlText
        Me.FavLoadBtn.Location = New System.Drawing.Point(597, 468)
        Me.FavLoadBtn.Name = "FavLoadBtn"
        Me.FavLoadBtn.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.FavLoadBtn.Size = New System.Drawing.Size(105, 25)
        Me.FavLoadBtn.TabIndex = 91
        Me.FavLoadBtn.Text = "Load List.."
        Me.FavLoadBtn.UseVisualStyleBackColor = False
        '
        'FavSaveBtn
        '
        Me.FavSaveBtn.BackColor = System.Drawing.SystemColors.Control
        Me.FavSaveBtn.Cursor = System.Windows.Forms.Cursors.Default
        Me.FavSaveBtn.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FavSaveBtn.ForeColor = System.Drawing.SystemColors.ControlText
        Me.FavSaveBtn.Location = New System.Drawing.Point(597, 436)
        Me.FavSaveBtn.Name = "FavSaveBtn"
        Me.FavSaveBtn.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.FavSaveBtn.Size = New System.Drawing.Size(105, 25)
        Me.FavSaveBtn.TabIndex = 90
        Me.FavSaveBtn.Text = "Save List.."
        Me.FavSaveBtn.UseVisualStyleBackColor = False
        '
        'RemFavBtn
        '
        Me.RemFavBtn.BackColor = System.Drawing.SystemColors.Control
        Me.RemFavBtn.Cursor = System.Windows.Forms.Cursors.Default
        Me.RemFavBtn.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RemFavBtn.ForeColor = System.Drawing.SystemColors.ControlText
        Me.RemFavBtn.Location = New System.Drawing.Point(597, 404)
        Me.RemFavBtn.Name = "RemFavBtn"
        Me.RemFavBtn.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.RemFavBtn.Size = New System.Drawing.Size(105, 25)
        Me.RemFavBtn.TabIndex = 49
        Me.RemFavBtn.Text = "Remove Selected"
        Me.RemFavBtn.UseVisualStyleBackColor = False
        '
        'AddFavBtn
        '
        Me.AddFavBtn.BackColor = System.Drawing.SystemColors.Control
        Me.AddFavBtn.Cursor = System.Windows.Forms.Cursors.Default
        Me.AddFavBtn.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.AddFavBtn.ForeColor = System.Drawing.SystemColors.ControlText
        Me.AddFavBtn.Location = New System.Drawing.Point(597, 372)
        Me.AddFavBtn.Name = "AddFavBtn"
        Me.AddFavBtn.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.AddFavBtn.Size = New System.Drawing.Size(105, 25)
        Me.AddFavBtn.TabIndex = 48
        Me.AddFavBtn.Text = "Add to Favourites"
        Me.AddFavBtn.UseVisualStyleBackColor = False
        '
        'FavEnemList
        '
        Me.FavEnemList.BackColor = System.Drawing.SystemColors.Window
        Me.FavEnemList.Cursor = System.Windows.Forms.Cursors.Default
        Me.FavEnemList.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FavEnemList.ForeColor = System.Drawing.SystemColors.WindowText
        Me.FavEnemList.ItemHeight = 14
        Me.FavEnemList.Location = New System.Drawing.Point(472, 373)
        Me.FavEnemList.Name = "FavEnemList"
        Me.FavEnemList.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.FavEnemList.Size = New System.Drawing.Size(121, 116)
        Me.FavEnemList.TabIndex = 47
        '
        'AutoSetCheck
        '
        Me.AutoSetCheck.BackColor = System.Drawing.SystemColors.Control
        Me.AutoSetCheck.Cursor = System.Windows.Forms.Cursors.Default
        Me.AutoSetCheck.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.AutoSetCheck.ForeColor = System.Drawing.SystemColors.ControlText
        Me.AutoSetCheck.Location = New System.Drawing.Point(584, 288)
        Me.AutoSetCheck.Name = "AutoSetCheck"
        Me.AutoSetCheck.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.AutoSetCheck.Size = New System.Drawing.Size(113, 17)
        Me.AutoSetCheck.TabIndex = 10
        Me.AutoSetCheck.Text = "Find Automatically"
        Me.AutoSetCheck.UseVisualStyleBackColor = False
        '
        'FindGFXBtn
        '
        Me.FindGFXBtn.BackColor = System.Drawing.SystemColors.Control
        Me.FindGFXBtn.Cursor = System.Windows.Forms.Cursors.Default
        Me.FindGFXBtn.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FindGFXBtn.ForeColor = System.Drawing.SystemColors.ControlText
        Me.FindGFXBtn.Location = New System.Drawing.Point(544, 241)
        Me.FindGFXBtn.Name = "FindGFXBtn"
        Me.FindGFXBtn.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.FindGFXBtn.Size = New System.Drawing.Size(158, 41)
        Me.FindGFXBtn.TabIndex = 9
        Me.FindGFXBtn.Text = "Find GFX Set for Enemies in Scroll Map"
        Me.FindGFXBtn.UseVisualStyleBackColor = False
        '
        'ScrnPresUD
        '
        Me.ScrnPresUD.Hexadecimal = True
        Me.ScrnPresUD.Location = New System.Drawing.Point(236, 294)
        Me.ScrnPresUD.Maximum = New Decimal(New Integer() {39, 0, 0, 0})
        Me.ScrnPresUD.Name = "ScrnPresUD"
        Me.ScrnPresUD.Size = New System.Drawing.Size(40, 20)
        Me.ScrnPresUD.TabIndex = 8
        '
        'PCShowCmd
        '
        Me.PCShowCmd.BackColor = System.Drawing.SystemColors.Control
        Me.PCShowCmd.Cursor = System.Windows.Forms.Cursors.Default
        Me.PCShowCmd.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.PCShowCmd.ForeColor = System.Drawing.SystemColors.ControlText
        Me.PCShowCmd.Location = New System.Drawing.Point(544, 307)
        Me.PCShowCmd.Name = "PCShowCmd"
        Me.PCShowCmd.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.PCShowCmd.Size = New System.Drawing.Size(158, 26)
        Me.PCShowCmd.TabIndex = 4
        Me.PCShowCmd.Text = "Palette Chart.."
        Me.PCShowCmd.UseVisualStyleBackColor = False
        '
        'ScrnScroll
        '
        Me.ScrnScroll.CausesValidation = False
        Me.ScrnScroll.Cursor = System.Windows.Forms.Cursors.Default
        Me.ScrnScroll.LargeChange = 4
        Me.ScrnScroll.Location = New System.Drawing.Point(32, 272)
        Me.ScrnScroll.Maximum = 32770
        Me.ScrnScroll.Name = "ScrnScroll"
        Me.ScrnScroll.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.ScrnScroll.Size = New System.Drawing.Size(233, 17)
        Me.ScrnScroll.TabIndex = 3
        '
        'PalPic
        '
        Me.PalPic.BackColor = System.Drawing.SystemColors.Control
        Me.PalPic.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.PalPic.Cursor = System.Windows.Forms.Cursors.Default
        Me.PalPic.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.PalPic.ForeColor = System.Drawing.SystemColors.ControlText
        Me.PalPic.Location = New System.Drawing.Point(280, 274)
        Me.PalPic.Name = "PalPic"
        Me.PalPic.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.PalPic.Size = New System.Drawing.Size(262, 39)
        Me.PalPic.TabIndex = 2
        Me.PalPic.TabStop = False
        '
        'Label11
        '
        Me.Label11.BackColor = System.Drawing.SystemColors.Control
        Me.Label11.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label11.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label11.Location = New System.Drawing.Point(472, 357)
        Me.Label11.Name = "Label11"
        Me.Label11.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label11.Size = New System.Drawing.Size(57, 17)
        Me.Label11.TabIndex = 50
        Me.Label11.Text = "Favourites:"
        '
        'CurScrollLabel
        '
        Me.CurScrollLabel.BackColor = System.Drawing.SystemColors.Control
        Me.CurScrollLabel.Cursor = System.Windows.Forms.Cursors.Default
        Me.CurScrollLabel.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CurScrollLabel.ForeColor = System.Drawing.SystemColors.ControlText
        Me.CurScrollLabel.Location = New System.Drawing.Point(552, 16)
        Me.CurScrollLabel.Name = "CurScrollLabel"
        Me.CurScrollLabel.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.CurScrollLabel.Size = New System.Drawing.Size(145, 17)
        Me.CurScrollLabel.TabIndex = 12
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.SystemColors.Control
        Me.Label1.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label1.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label1.Location = New System.Drawing.Point(158, 294)
        Me.Label1.Name = "Label1"
        Me.Label1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label1.Size = New System.Drawing.Size(82, 20)
        Me.Label1.TabIndex = 6
        Me.Label1.Text = "Screen Preset:"
        '
        'TabControlEnemEd
        '
        Me.TabControlEnemEd.Controls.Add(Me.TabPage1)
        Me.TabControlEnemEd.Controls.Add(Me.TabPage2)
        Me.TabControlEnemEd.Location = New System.Drawing.Point(8, 292)
        Me.TabControlEnemEd.Name = "TabControlEnemEd"
        Me.TabControlEnemEd.SelectedIndex = 0
        Me.TabControlEnemEd.Size = New System.Drawing.Size(193, 211)
        Me.TabControlEnemEd.TabIndex = 97
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.gbxGeneral)
        Me.TabPage1.Location = New System.Drawing.Point(4, 23)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(185, 184)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "General"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'gbxGeneral
        '
        Me.gbxGeneral.BackColor = System.Drawing.SystemColors.Control
        Me.gbxGeneral.Controls.Add(Me.ScrUD)
        Me.gbxGeneral.Controls.Add(Me.YUD)
        Me.gbxGeneral.Controls.Add(Me.XUD)
        Me.gbxGeneral.Controls.Add(Me.Label2)
        Me.gbxGeneral.Controls.Add(Me.Label3)
        Me.gbxGeneral.Controls.Add(Me.Label4)
        Me.gbxGeneral.Controls.Add(Me.lblEnemyName)
        Me.gbxGeneral.Controls.Add(Me.HPUD)
        Me.gbxGeneral.Controls.Add(Me.TypeUD)
        Me.gbxGeneral.Controls.Add(Me.Label8)
        Me.gbxGeneral.Controls.Add(Me.lblTypeGeneralPan)
        Me.gbxGeneral.Controls.Add(Me.CurEnemUD)
        Me.gbxGeneral.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbxGeneral.ForeColor = System.Drawing.SystemColors.ControlText
        Me.gbxGeneral.Location = New System.Drawing.Point(5, 6)
        Me.gbxGeneral.Name = "gbxGeneral"
        Me.gbxGeneral.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.gbxGeneral.Size = New System.Drawing.Size(177, 174)
        Me.gbxGeneral.TabIndex = 101
        Me.gbxGeneral.TabStop = False
        Me.gbxGeneral.Text = "Enemy"
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.SystemColors.Control
        Me.Label2.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label2.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label2.Location = New System.Drawing.Point(8, 72)
        Me.Label2.Name = "Label2"
        Me.Label2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label2.Size = New System.Drawing.Size(90, 17)
        Me.Label2.TabIndex = 106
        Me.Label2.Text = "X Position"
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.SystemColors.Control
        Me.Label3.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label3.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label3.Location = New System.Drawing.Point(8, 96)
        Me.Label3.Name = "Label3"
        Me.Label3.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label3.Size = New System.Drawing.Size(90, 17)
        Me.Label3.TabIndex = 105
        Me.Label3.Text = "Y Position"
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.SystemColors.Control
        Me.Label4.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label4.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label4.Location = New System.Drawing.Point(8, 120)
        Me.Label4.Name = "Label4"
        Me.Label4.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label4.Size = New System.Drawing.Size(90, 17)
        Me.Label4.TabIndex = 104
        Me.Label4.Text = "Screen"
        '
        'lblEnemyName
        '
        Me.lblEnemyName.BackColor = System.Drawing.SystemColors.Control
        Me.lblEnemyName.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblEnemyName.Font = New System.Drawing.Font("Arial", 8.0!)
        Me.lblEnemyName.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblEnemyName.Location = New System.Drawing.Point(8, 48)
        Me.lblEnemyName.Name = "lblEnemyName"
        Me.lblEnemyName.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblEnemyName.Size = New System.Drawing.Size(161, 17)
        Me.lblEnemyName.TabIndex = 103
        Me.lblEnemyName.Text = "Enemy Name"
        '
        'Label8
        '
        Me.Label8.BackColor = System.Drawing.SystemColors.Control
        Me.Label8.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label8.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label8.Location = New System.Drawing.Point(108, 24)
        Me.Label8.Name = "Label8"
        Me.Label8.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label8.Size = New System.Drawing.Size(26, 20)
        Me.Label8.TabIndex = 95
        Me.Label8.Text = "HP"
        '
        'lblTypeGeneralPan
        '
        Me.lblTypeGeneralPan.BackColor = System.Drawing.SystemColors.Control
        Me.lblTypeGeneralPan.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblTypeGeneralPan.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTypeGeneralPan.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblTypeGeneralPan.Location = New System.Drawing.Point(8, 24)
        Me.lblTypeGeneralPan.Name = "lblTypeGeneralPan"
        Me.lblTypeGeneralPan.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblTypeGeneralPan.Size = New System.Drawing.Size(43, 20)
        Me.lblTypeGeneralPan.TabIndex = 94
        Me.lblTypeGeneralPan.Text = "Type"
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.gbxWeapon)
        Me.TabPage2.Location = New System.Drawing.Point(4, 23)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(185, 184)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Weapon/Damage"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'gbxWeapon
        '
        Me.gbxWeapon.BackColor = System.Drawing.SystemColors.Control
        Me.gbxWeapon.Controls.Add(Me.lblTypeWeaponDamagePan)
        Me.gbxWeapon.Controls.Add(Me.WeaponList)
        Me.gbxWeapon.Controls.Add(Me._SettingsCheck_0)
        Me.gbxWeapon.Controls.Add(Me._SettingsCheck_1)
        Me.gbxWeapon.Controls.Add(Me.Label15)
        Me.gbxWeapon.Controls.Add(Me.WeaponDmgUD)
        Me.gbxWeapon.Controls.Add(Me.WeaponIcon)
        Me.gbxWeapon.Controls.Add(Me.Line1)
        Me.gbxWeapon.Controls.Add(Me.lblDamageToMegaMan)
        Me.gbxWeapon.Controls.Add(Me.EnemDmgUD)
        Me.gbxWeapon.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbxWeapon.ForeColor = System.Drawing.SystemColors.ControlText
        Me.gbxWeapon.Location = New System.Drawing.Point(5, 6)
        Me.gbxWeapon.Name = "gbxWeapon"
        Me.gbxWeapon.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.gbxWeapon.Size = New System.Drawing.Size(185, 182)
        Me.gbxWeapon.TabIndex = 100
        Me.gbxWeapon.TabStop = False
        Me.gbxWeapon.Text = "Damage Data"
        '
        'lblTypeWeaponDamagePan
        '
        Me.lblTypeWeaponDamagePan.BackColor = System.Drawing.SystemColors.Control
        Me.lblTypeWeaponDamagePan.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblTypeWeaponDamagePan.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTypeWeaponDamagePan.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblTypeWeaponDamagePan.Location = New System.Drawing.Point(2, 99)
        Me.lblTypeWeaponDamagePan.Name = "lblTypeWeaponDamagePan"
        Me.lblTypeWeaponDamagePan.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblTypeWeaponDamagePan.Size = New System.Drawing.Size(44, 20)
        Me.lblTypeWeaponDamagePan.TabIndex = 104
        Me.lblTypeWeaponDamagePan.Text = "Type"
        '
        'WeaponList
        '
        Me.WeaponList.BackColor = System.Drawing.SystemColors.Window
        Me.WeaponList.Cursor = System.Windows.Forms.Cursors.Default
        Me.WeaponList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.WeaponList.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.WeaponList.ForeColor = System.Drawing.SystemColors.WindowText
        Me.WeaponList.Location = New System.Drawing.Point(64, 143)
        Me.WeaponList.Name = "WeaponList"
        Me.WeaponList.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.WeaponList.Size = New System.Drawing.Size(105, 22)
        Me.WeaponList.TabIndex = 103
        '
        '_SettingsCheck_0
        '
        Me._SettingsCheck_0.BackColor = System.Drawing.SystemColors.Control
        Me._SettingsCheck_0.Cursor = System.Windows.Forms.Cursors.Default
        Me._SettingsCheck_0.Enabled = False
        Me._SettingsCheck_0.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._SettingsCheck_0.ForeColor = System.Drawing.SystemColors.ControlText
        Me._SettingsCheck_0.Location = New System.Drawing.Point(8, 143)
        Me._SettingsCheck_0.Name = "_SettingsCheck_0"
        Me._SettingsCheck_0.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._SettingsCheck_0.Size = New System.Drawing.Size(72, 23)
        Me._SettingsCheck_0.TabIndex = 102
        Me._SettingsCheck_0.Text = "Repel"
        Me._SettingsCheck_0.UseVisualStyleBackColor = False
        '
        '_SettingsCheck_1
        '
        Me._SettingsCheck_1.BackColor = System.Drawing.SystemColors.Control
        Me._SettingsCheck_1.Cursor = System.Windows.Forms.Cursors.Default
        Me._SettingsCheck_1.Enabled = False
        Me._SettingsCheck_1.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._SettingsCheck_1.ForeColor = System.Drawing.SystemColors.ControlText
        Me._SettingsCheck_1.Location = New System.Drawing.Point(8, 126)
        Me._SettingsCheck_1.Name = "_SettingsCheck_1"
        Me._SettingsCheck_1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._SettingsCheck_1.Size = New System.Drawing.Size(161, 17)
        Me._SettingsCheck_1.TabIndex = 101
        Me._SettingsCheck_1.Text = "Spark Shock Freeze (MM3)"
        Me._SettingsCheck_1.UseVisualStyleBackColor = False
        '
        'Label15
        '
        Me.Label15.BackColor = System.Drawing.SystemColors.Control
        Me.Label15.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label15.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label15.Location = New System.Drawing.Point(2, 76)
        Me.Label15.Name = "Label15"
        Me.Label15.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label15.Size = New System.Drawing.Size(88, 20)
        Me.Label15.TabIndex = 100
        Me.Label15.Text = "Damage From:"
        '
        'WeaponIcon
        '
        Me.WeaponIcon.Cursor = System.Windows.Forms.Cursors.Default
        Me.WeaponIcon.Location = New System.Drawing.Point(90, 64)
        Me.WeaponIcon.Name = "WeaponIcon"
        Me.WeaponIcon.Size = New System.Drawing.Size(32, 32)
        Me.WeaponIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.WeaponIcon.TabIndex = 98
        Me.WeaponIcon.TabStop = False
        '
        'Line1
        '
        Me.Line1.BackColor = System.Drawing.SystemColors.WindowText
        Me.Line1.Location = New System.Drawing.Point(8, 60)
        Me.Line1.Name = "Line1"
        Me.Line1.Size = New System.Drawing.Size(160, 1)
        Me.Line1.TabIndex = 97
        '
        'lblDamageToMegaMan
        '
        Me.lblDamageToMegaMan.BackColor = System.Drawing.SystemColors.Control
        Me.lblDamageToMegaMan.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblDamageToMegaMan.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDamageToMegaMan.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblDamageToMegaMan.Location = New System.Drawing.Point(2, 36)
        Me.lblDamageToMegaMan.Name = "lblDamageToMegaMan"
        Me.lblDamageToMegaMan.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblDamageToMegaMan.Size = New System.Drawing.Size(126, 20)
        Me.lblDamageToMegaMan.TabIndex = 95
        Me.lblDamageToMegaMan.Text = "Damage To Mega Man:"
        '
        'TilePic
        '
        Me.TilePic.BackColor = System.Drawing.SystemColors.Control
        Me.TilePic.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.TilePic.Cursor = System.Windows.Forms.Cursors.Default
        Me.TilePic.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TilePic.ForeColor = System.Drawing.SystemColors.ControlText
        Me.TilePic.Location = New System.Drawing.Point(280, 8)
        Me.TilePic.Name = "TilePic"
        Me.TilePic.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.TilePic.Size = New System.Drawing.Size(260, 260)
        Me.TilePic.TabIndex = 1
        Me.TilePic.TabStop = False
        '
        'Label6
        '
        Me.Label6.BackColor = System.Drawing.SystemColors.Control
        Me.Label6.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label6.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label6.Location = New System.Drawing.Point(552, 128)
        Me.Label6.Name = "Label6"
        Me.Label6.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label6.Size = New System.Drawing.Size(129, 17)
        Me.Label6.TabIndex = 20
        Me.Label6.Text = "Enemies using GFX:"
        '
        'GFXEnemList
        '
        Me.GFXEnemList.BackColor = System.Drawing.SystemColors.Window
        Me.GFXEnemList.Cursor = System.Windows.Forms.Cursors.Default
        Me.GFXEnemList.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GFXEnemList.ForeColor = System.Drawing.SystemColors.WindowText
        Me.GFXEnemList.ItemHeight = 14
        Me.GFXEnemList.Location = New System.Drawing.Point(544, 144)
        Me.GFXEnemList.Name = "GFXEnemList"
        Me.GFXEnemList.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.GFXEnemList.Size = New System.Drawing.Size(153, 60)
        Me.GFXEnemList.TabIndex = 19
        '
        'Label13
        '
        Me.Label13.BackColor = System.Drawing.SystemColors.Control
        Me.Label13.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label13.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label13.Location = New System.Drawing.Point(4, 51)
        Me.Label13.Name = "Label13"
        Me.Label13.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label13.Size = New System.Drawing.Size(111, 23)
        Me.Label13.TabIndex = 59
        Me.Label13.Text = "Sprite Palette Set"
        '
        'BGPalUD
        '
        Me.BGPalUD.Hexadecimal = True
        Me.BGPalUD.Location = New System.Drawing.Point(105, 83)
        Me.BGPalUD.Maximum = New Decimal(New Integer() {256, 0, 0, 0})
        Me.BGPalUD.Name = "BGPalUD"
        Me.BGPalUD.Size = New System.Drawing.Size(49, 20)
        Me.BGPalUD.TabIndex = 57
        Me.BGPalUD.Visible = False
        '
        'PalSetUD
        '
        Me.PalSetUD.Hexadecimal = True
        Me.PalSetUD.Location = New System.Drawing.Point(105, 51)
        Me.PalSetUD.Maximum = New Decimal(New Integer() {63, 0, 0, 0})
        Me.PalSetUD.Name = "PalSetUD"
        Me.PalSetUD.Size = New System.Drawing.Size(49, 20)
        Me.PalSetUD.TabIndex = 56
        '
        'BDCheck
        '
        Me.BDCheck.BackColor = System.Drawing.SystemColors.Control
        Me.BDCheck.Cursor = System.Windows.Forms.Cursors.Default
        Me.BDCheck.Enabled = False
        Me.BDCheck.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BDCheck.ForeColor = System.Drawing.SystemColors.ControlText
        Me.BDCheck.Location = New System.Drawing.Point(4, 8)
        Me.BDCheck.Name = "BDCheck"
        Me.BDCheck.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.BDCheck.Size = New System.Drawing.Size(113, 17)
        Me.BDCheck.TabIndex = 52
        Me.BDCheck.Text = "Boss Door Effect"
        Me.BDCheck.UseVisualStyleBackColor = False
        Me.BDCheck.Visible = False
        '
        'BGPalCheck
        '
        Me.BGPalCheck.BackColor = System.Drawing.SystemColors.Control
        Me.BGPalCheck.Cursor = System.Windows.Forms.Cursors.Default
        Me.BGPalCheck.Enabled = False
        Me.BGPalCheck.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BGPalCheck.ForeColor = System.Drawing.SystemColors.ControlText
        Me.BGPalCheck.Location = New System.Drawing.Point(4, 83)
        Me.BGPalCheck.Name = "BGPalCheck"
        Me.BGPalCheck.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.BGPalCheck.Size = New System.Drawing.Size(98, 20)
        Me.BGPalCheck.TabIndex = 55
        Me.BGPalCheck.Text = "Change BG Pal"
        Me.BGPalCheck.UseVisualStyleBackColor = False
        Me.BGPalCheck.Visible = False
        '
        '_GemFrame_2
        '
        Me._GemFrame_2.BackColor = System.Drawing.SystemColors.Control
        Me._GemFrame_2.Controls.Add(Me.PalSetUD)
        Me._GemFrame_2.Controls.Add(Me.BGPalCheck)
        Me._GemFrame_2.Controls.Add(Me.BDCheck)
        Me._GemFrame_2.Controls.Add(Me.SBCheck)
        Me._GemFrame_2.Controls.Add(Me.BGPalUD)
        Me._GemFrame_2.Controls.Add(Me.Label13)
        Me._GemFrame_2.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._GemFrame_2.ForeColor = System.Drawing.SystemColors.ControlText
        Me._GemFrame_2.Location = New System.Drawing.Point(544, 9)
        Me._GemFrame_2.Name = "_GemFrame_2"
        Me._GemFrame_2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._GemFrame_2.Size = New System.Drawing.Size(158, 116)
        Me._GemFrame_2.TabIndex = 46
        Me._GemFrame_2.TabStop = False
        '
        'Label9
        '
        Me.Label9.BackColor = System.Drawing.SystemColors.Control
        Me.Label9.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label9.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label9.Location = New System.Drawing.Point(0, 0)
        Me.Label9.Name = "Label9"
        Me.Label9.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label9.Size = New System.Drawing.Size(86, 17)
        Me.Label9.TabIndex = 23
        Me.Label9.Text = "Scroll Gfx Load:"
        '
        'EffUD
        '
        Me.EffUD.Hexadecimal = True
        Me.EffUD.Location = New System.Drawing.Point(97, 0)
        Me.EffUD.Maximum = New Decimal(New Integer() {79, 0, 0, 0})
        Me.EffUD.Name = "EffUD"
        Me.EffUD.Size = New System.Drawing.Size(45, 20)
        Me.EffUD.TabIndex = 25
        '
        '_GemFrame_1
        '
        Me._GemFrame_1.BackColor = System.Drawing.SystemColors.Control
        Me._GemFrame_1.Controls.Add(Me.EffUD)
        Me._GemFrame_1.Controls.Add(Me.Label9)
        Me._GemFrame_1.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._GemFrame_1.ForeColor = System.Drawing.SystemColors.ControlText
        Me._GemFrame_1.Location = New System.Drawing.Point(552, 40)
        Me._GemFrame_1.Name = "_GemFrame_1"
        Me._GemFrame_1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._GemFrame_1.Size = New System.Drawing.Size(150, 28)
        Me._GemFrame_1.TabIndex = 22
        Me._GemFrame_1.TabStop = False
        '
        'Label10
        '
        Me.Label10.BackColor = System.Drawing.SystemColors.Control
        Me.Label10.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label10.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label10.Location = New System.Drawing.Point(8, 16)
        Me.Label10.Name = "Label10"
        Me.Label10.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label10.Size = New System.Drawing.Size(49, 17)
        Me.Label10.TabIndex = 34
        Me.Label10.Text = "Pal. Slot:"
        '
        'TopLabel
        '
        Me.TopLabel.BackColor = System.Drawing.SystemColors.Control
        Me.TopLabel.Cursor = System.Windows.Forms.Cursors.Default
        Me.TopLabel.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TopLabel.ForeColor = System.Drawing.SystemColors.ControlText
        Me.TopLabel.Location = New System.Drawing.Point(175, 111)
        Me.TopLabel.Name = "TopLabel"
        Me.TopLabel.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.TopLabel.Size = New System.Drawing.Size(30, 17)
        Me.TopLabel.TabIndex = 99
        Me.TopLabel.Text = "Top:"
        '
        'BottomLabel
        '
        Me.BottomLabel.BackColor = System.Drawing.SystemColors.Control
        Me.BottomLabel.Cursor = System.Windows.Forms.Cursors.Default
        Me.BottomLabel.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BottomLabel.ForeColor = System.Drawing.SystemColors.ControlText
        Me.BottomLabel.Location = New System.Drawing.Point(175, 133)
        Me.BottomLabel.Name = "BottomLabel"
        Me.BottomLabel.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.BottomLabel.Size = New System.Drawing.Size(30, 17)
        Me.BottomLabel.TabIndex = 101
        Me.BottomLabel.Text = "Btm.:"
        '
        'Shape1
        '
        Me.Shape1.BackColor = System.Drawing.Color.Transparent
        Me.Shape1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Shape1.Location = New System.Drawing.Point(167, 108)
        Me.Shape1.Name = "Shape1"
        Me.Shape1.Size = New System.Drawing.Size(90, 48)
        Me.Shape1.TabIndex = 106
        '
        '_EffSprUD_5
        '
        Me._EffSprUD_5.Hexadecimal = True
        Me._EffSprUD_5.Location = New System.Drawing.Point(208, 133)
        Me._EffSprUD_5.Maximum = New Decimal(New Integer() {256, 0, 0, 0})
        Me._EffSprUD_5.Name = "_EffSprUD_5"
        Me._EffSprUD_5.Size = New System.Drawing.Size(45, 20)
        Me._EffSprUD_5.TabIndex = 105
        '
        '_EffSprUD_4
        '
        Me._EffSprUD_4.Hexadecimal = True
        Me._EffSprUD_4.Location = New System.Drawing.Point(208, 111)
        Me._EffSprUD_4.Maximum = New Decimal(New Integer() {256, 0, 0, 0})
        Me._EffSprUD_4.Name = "_EffSprUD_4"
        Me._EffSprUD_4.Size = New System.Drawing.Size(45, 20)
        Me._EffSprUD_4.TabIndex = 100
        '
        '_EffSprUD_1
        '
        Me._EffSprUD_1.Hexadecimal = True
        Me._EffSprUD_1.Location = New System.Drawing.Point(10, 113)
        Me._EffSprUD_1.Maximum = New Decimal(New Integer() {127, 0, 0, 0})
        Me._EffSprUD_1.Name = "_EffSprUD_1"
        Me._EffSprUD_1.Size = New System.Drawing.Size(45, 20)
        Me._EffSprUD_1.TabIndex = 33
        '
        '_EffSprTypeOpt_1
        '
        Me._EffSprTypeOpt_1.BackColor = System.Drawing.SystemColors.Control
        Me._EffSprTypeOpt_1.Cursor = System.Windows.Forms.Cursors.Default
        Me._EffSprTypeOpt_1.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._EffSprTypeOpt_1.ForeColor = System.Drawing.SystemColors.ControlText
        Me._EffSprTypeOpt_1.Location = New System.Drawing.Point(2, 85)
        Me._EffSprTypeOpt_1.Name = "_EffSprTypeOpt_1"
        Me._EffSprTypeOpt_1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._EffSprTypeOpt_1.Size = New System.Drawing.Size(105, 18)
        Me._EffSprTypeOpt_1.TabIndex = 30
        Me._EffSprTypeOpt_1.TabStop = True
        Me._EffSprTypeOpt_1.Text = "3-Color Palette"
        Me._EffSprTypeOpt_1.UseVisualStyleBackColor = False
        '
        '_EffSprTypeOpt_0
        '
        Me._EffSprTypeOpt_0.BackColor = System.Drawing.SystemColors.Control
        Me._EffSprTypeOpt_0.Cursor = System.Windows.Forms.Cursors.Default
        Me._EffSprTypeOpt_0.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._EffSprTypeOpt_0.ForeColor = System.Drawing.SystemColors.ControlText
        Me._EffSprTypeOpt_0.Location = New System.Drawing.Point(2, 40)
        Me._EffSprTypeOpt_0.Name = "_EffSprTypeOpt_0"
        Me._EffSprTypeOpt_0.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._EffSprTypeOpt_0.Size = New System.Drawing.Size(146, 20)
        Me._EffSprTypeOpt_0.TabIndex = 31
        Me._EffSprTypeOpt_0.TabStop = True
        Me._EffSprTypeOpt_0.Text = "Palette Animation"
        Me._EffSprTypeOpt_0.UseVisualStyleBackColor = False
        '
        '_EffSprColTB_1
        '
        Me._EffSprColTB_1.AcceptsReturn = True
        Me._EffSprColTB_1.BackColor = System.Drawing.SystemColors.Window
        Me._EffSprColTB_1.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._EffSprColTB_1.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._EffSprColTB_1.ForeColor = System.Drawing.SystemColors.WindowText
        Me._EffSprColTB_1.Location = New System.Drawing.Point(64, 135)
        Me._EffSprColTB_1.MaxLength = 0
        Me._EffSprColTB_1.Name = "_EffSprColTB_1"
        Me._EffSprColTB_1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._EffSprColTB_1.Size = New System.Drawing.Size(33, 20)
        Me._EffSprColTB_1.TabIndex = 35
        '
        '_EffSprColTB_2
        '
        Me._EffSprColTB_2.AcceptsReturn = True
        Me._EffSprColTB_2.BackColor = System.Drawing.SystemColors.Window
        Me._EffSprColTB_2.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._EffSprColTB_2.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._EffSprColTB_2.ForeColor = System.Drawing.SystemColors.WindowText
        Me._EffSprColTB_2.Location = New System.Drawing.Point(96, 135)
        Me._EffSprColTB_2.MaxLength = 0
        Me._EffSprColTB_2.Name = "_EffSprColTB_2"
        Me._EffSprColTB_2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._EffSprColTB_2.Size = New System.Drawing.Size(33, 20)
        Me._EffSprColTB_2.TabIndex = 36
        '
        '_EffSprColTB_3
        '
        Me._EffSprColTB_3.AcceptsReturn = True
        Me._EffSprColTB_3.BackColor = System.Drawing.SystemColors.Window
        Me._EffSprColTB_3.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._EffSprColTB_3.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._EffSprColTB_3.ForeColor = System.Drawing.SystemColors.WindowText
        Me._EffSprColTB_3.Location = New System.Drawing.Point(128, 135)
        Me._EffSprColTB_3.MaxLength = 0
        Me._EffSprColTB_3.Name = "_EffSprColTB_3"
        Me._EffSprColTB_3.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._EffSprColTB_3.Size = New System.Drawing.Size(33, 20)
        Me._EffSprColTB_3.TabIndex = 37
        '
        '_EffSprColPic_1
        '
        Me._EffSprColPic_1.BackColor = System.Drawing.Color.FromArgb(CType(CType(15, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me._EffSprColPic_1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me._EffSprColPic_1.Cursor = System.Windows.Forms.Cursors.Default
        Me._EffSprColPic_1.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._EffSprColPic_1.ForeColor = System.Drawing.SystemColors.ControlText
        Me._EffSprColPic_1.Location = New System.Drawing.Point(64, 111)
        Me._EffSprColPic_1.Name = "_EffSprColPic_1"
        Me._EffSprColPic_1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._EffSprColPic_1.Size = New System.Drawing.Size(33, 25)
        Me._EffSprColPic_1.TabIndex = 38
        Me._EffSprColPic_1.TabStop = False
        '
        '_EffSprColPic_2
        '
        Me._EffSprColPic_2.BackColor = System.Drawing.Color.FromArgb(CType(CType(15, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me._EffSprColPic_2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me._EffSprColPic_2.Cursor = System.Windows.Forms.Cursors.Default
        Me._EffSprColPic_2.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._EffSprColPic_2.ForeColor = System.Drawing.SystemColors.ControlText
        Me._EffSprColPic_2.Location = New System.Drawing.Point(96, 111)
        Me._EffSprColPic_2.Name = "_EffSprColPic_2"
        Me._EffSprColPic_2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._EffSprColPic_2.Size = New System.Drawing.Size(33, 25)
        Me._EffSprColPic_2.TabIndex = 39
        Me._EffSprColPic_2.TabStop = False
        '
        '_EffSprColPic_3
        '
        Me._EffSprColPic_3.BackColor = System.Drawing.Color.FromArgb(CType(CType(15, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me._EffSprColPic_3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me._EffSprColPic_3.Cursor = System.Windows.Forms.Cursors.Default
        Me._EffSprColPic_3.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._EffSprColPic_3.ForeColor = System.Drawing.SystemColors.ControlText
        Me._EffSprColPic_3.Location = New System.Drawing.Point(128, 111)
        Me._EffSprColPic_3.Name = "_EffSprColPic_3"
        Me._EffSprColPic_3.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._EffSprColPic_3.Size = New System.Drawing.Size(33, 25)
        Me._EffSprColPic_3.TabIndex = 40
        Me._EffSprColPic_3.TabStop = False
        '
        'Frame2
        '
        Me.Frame2.BackColor = System.Drawing.SystemColors.Control
        Me.Frame2.Controls.Add(Me._EffSprSlot_3)
        Me.Frame2.Controls.Add(Me._EffSprSlot_2)
        Me.Frame2.Controls.Add(Me._EffSprSlot_1)
        Me.Frame2.Controls.Add(Me._EffSprSlot_0)
        Me.Frame2.Cursor = System.Windows.Forms.Cursors.Default
        Me.Frame2.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Frame2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Frame2.Location = New System.Drawing.Point(56, 16)
        Me.Frame2.Name = "Frame2"
        Me.Frame2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Frame2.Size = New System.Drawing.Size(126, 20)
        Me.Frame2.TabIndex = 41
        '
        '_EffSprSlot_3
        '
        Me._EffSprSlot_3.BackColor = System.Drawing.SystemColors.Control
        Me._EffSprSlot_3.Cursor = System.Windows.Forms.Cursors.Default
        Me._EffSprSlot_3.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._EffSprSlot_3.ForeColor = System.Drawing.SystemColors.ControlText
        Me._EffSprSlot_3.Location = New System.Drawing.Point(99, 2)
        Me._EffSprSlot_3.Name = "_EffSprSlot_3"
        Me._EffSprSlot_3.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._EffSprSlot_3.Size = New System.Drawing.Size(25, 17)
        Me._EffSprSlot_3.TabIndex = 45
        Me._EffSprSlot_3.TabStop = True
        Me._EffSprSlot_3.Text = "4"
        Me._EffSprSlot_3.UseVisualStyleBackColor = False
        '
        '_EffSprSlot_2
        '
        Me._EffSprSlot_2.BackColor = System.Drawing.SystemColors.Control
        Me._EffSprSlot_2.Cursor = System.Windows.Forms.Cursors.Default
        Me._EffSprSlot_2.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._EffSprSlot_2.ForeColor = System.Drawing.SystemColors.ControlText
        Me._EffSprSlot_2.Location = New System.Drawing.Point(67, 2)
        Me._EffSprSlot_2.Name = "_EffSprSlot_2"
        Me._EffSprSlot_2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._EffSprSlot_2.Size = New System.Drawing.Size(25, 17)
        Me._EffSprSlot_2.TabIndex = 44
        Me._EffSprSlot_2.TabStop = True
        Me._EffSprSlot_2.Text = "3"
        Me._EffSprSlot_2.UseVisualStyleBackColor = False
        '
        '_EffSprSlot_1
        '
        Me._EffSprSlot_1.BackColor = System.Drawing.SystemColors.Control
        Me._EffSprSlot_1.Cursor = System.Windows.Forms.Cursors.Default
        Me._EffSprSlot_1.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._EffSprSlot_1.ForeColor = System.Drawing.SystemColors.ControlText
        Me._EffSprSlot_1.Location = New System.Drawing.Point(35, 2)
        Me._EffSprSlot_1.Name = "_EffSprSlot_1"
        Me._EffSprSlot_1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._EffSprSlot_1.Size = New System.Drawing.Size(25, 17)
        Me._EffSprSlot_1.TabIndex = 43
        Me._EffSprSlot_1.TabStop = True
        Me._EffSprSlot_1.Text = "2"
        Me._EffSprSlot_1.UseVisualStyleBackColor = False
        '
        '_EffSprSlot_0
        '
        Me._EffSprSlot_0.BackColor = System.Drawing.SystemColors.Control
        Me._EffSprSlot_0.Cursor = System.Windows.Forms.Cursors.Default
        Me._EffSprSlot_0.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._EffSprSlot_0.ForeColor = System.Drawing.SystemColors.ControlText
        Me._EffSprSlot_0.Location = New System.Drawing.Point(3, 2)
        Me._EffSprSlot_0.Name = "_EffSprSlot_0"
        Me._EffSprSlot_0.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._EffSprSlot_0.Size = New System.Drawing.Size(25, 17)
        Me._EffSprSlot_0.TabIndex = 42
        Me._EffSprSlot_0.TabStop = True
        Me._EffSprSlot_0.Text = "1"
        Me._EffSprSlot_0.UseVisualStyleBackColor = False
        '
        '_EffSprUD_2
        '
        Me._EffSprUD_2.Hexadecimal = True
        Me._EffSprUD_2.Location = New System.Drawing.Point(139, 63)
        Me._EffSprUD_2.Maximum = New Decimal(New Integer() {7, 0, 0, 0})
        Me._EffSprUD_2.Name = "_EffSprUD_2"
        Me._EffSprUD_2.Size = New System.Drawing.Size(45, 20)
        Me._EffSprUD_2.TabIndex = 61
        '
        '_EffSprTypeOpt_2
        '
        Me._EffSprTypeOpt_2.BackColor = System.Drawing.SystemColors.Control
        Me._EffSprTypeOpt_2.Cursor = System.Windows.Forms.Cursors.Default
        Me._EffSprTypeOpt_2.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._EffSprTypeOpt_2.ForeColor = System.Drawing.SystemColors.ControlText
        Me._EffSprTypeOpt_2.Location = New System.Drawing.Point(131, 40)
        Me._EffSprTypeOpt_2.Name = "_EffSprTypeOpt_2"
        Me._EffSprTypeOpt_2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._EffSprTypeOpt_2.Size = New System.Drawing.Size(126, 20)
        Me._EffSprTypeOpt_2.TabIndex = 63
        Me._EffSprTypeOpt_2.TabStop = True
        Me._EffSprTypeOpt_2.Text = "CHR Animation"
        Me._EffSprTypeOpt_2.UseVisualStyleBackColor = False
        '
        'EffSprEdFrame
        '
        Me.EffSprEdFrame.BackColor = System.Drawing.SystemColors.Control
        Me.EffSprEdFrame.Controls.Add(Me.BottomLabel)
        Me.EffSprEdFrame.Controls.Add(Me.TopLabel)
        Me.EffSprEdFrame.Controls.Add(Me._EffSprTypeOpt_3)
        Me.EffSprEdFrame.Controls.Add(Me._EffSprTypeOpt_2)
        Me.EffSprEdFrame.Controls.Add(Me._EffSprAEdBtn_1)
        Me.EffSprEdFrame.Controls.Add(Me._EffSprUD_2)
        Me.EffSprEdFrame.Controls.Add(Me.Frame2)
        Me.EffSprEdFrame.Controls.Add(Me._EffSprColPic_3)
        Me.EffSprEdFrame.Controls.Add(Me._EffSprColPic_2)
        Me.EffSprEdFrame.Controls.Add(Me._EffSprColPic_1)
        Me.EffSprEdFrame.Controls.Add(Me._EffSprColTB_3)
        Me.EffSprEdFrame.Controls.Add(Me._EffSprColTB_2)
        Me.EffSprEdFrame.Controls.Add(Me._EffSprColTB_1)
        Me.EffSprEdFrame.Controls.Add(Me._EffSprTypeOpt_0)
        Me.EffSprEdFrame.Controls.Add(Me._EffSprTypeOpt_1)
        Me.EffSprEdFrame.Controls.Add(Me._EffSprAEdBtn_0)
        Me.EffSprEdFrame.Controls.Add(Me._EffSprUD_0)
        Me.EffSprEdFrame.Controls.Add(Me._EffSprUD_1)
        Me.EffSprEdFrame.Controls.Add(Me._EffSprUD_4)
        Me.EffSprEdFrame.Controls.Add(Me._EffSprUD_3)
        Me.EffSprEdFrame.Controls.Add(Me._EffSprUD_5)
        Me.EffSprEdFrame.Controls.Add(Me.Shape1)
        Me.EffSprEdFrame.Controls.Add(Me.Label10)
        Me.EffSprEdFrame.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.EffSprEdFrame.ForeColor = System.Drawing.SystemColors.ControlText
        Me.EffSprEdFrame.Location = New System.Drawing.Point(203, 344)
        Me.EffSprEdFrame.Name = "EffSprEdFrame"
        Me.EffSprEdFrame.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.EffSprEdFrame.Size = New System.Drawing.Size(262, 159)
        Me.EffSprEdFrame.TabIndex = 26
        Me.EffSprEdFrame.TabStop = False
        Me.EffSprEdFrame.Text = "Effect Sprite Editor"
        Me.EffSprEdFrame.Visible = False
        '
        '_EffSprTypeOpt_3
        '
        Me._EffSprTypeOpt_3.BackColor = System.Drawing.SystemColors.Control
        Me._EffSprTypeOpt_3.Cursor = System.Windows.Forms.Cursors.Default
        Me._EffSprTypeOpt_3.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._EffSprTypeOpt_3.ForeColor = System.Drawing.SystemColors.ControlText
        Me._EffSprTypeOpt_3.Location = New System.Drawing.Point(96, 85)
        Me._EffSprTypeOpt_3.Name = "_EffSprTypeOpt_3"
        Me._EffSprTypeOpt_3.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._EffSprTypeOpt_3.Size = New System.Drawing.Size(113, 18)
        Me._EffSprTypeOpt_3.TabIndex = 97
        Me._EffSprTypeOpt_3.TabStop = True
        Me._EffSprTypeOpt_3.Text = "CHR Bank Preset:"
        Me._EffSprTypeOpt_3.UseVisualStyleBackColor = False
        '
        '_EffSprAEdBtn_1
        '
        Me._EffSprAEdBtn_1.BackColor = System.Drawing.SystemColors.Control
        Me._EffSprAEdBtn_1.Cursor = System.Windows.Forms.Cursors.Default
        Me._EffSprAEdBtn_1.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._EffSprAEdBtn_1.ForeColor = System.Drawing.SystemColors.ControlText
        Me._EffSprAEdBtn_1.Location = New System.Drawing.Point(186, 62)
        Me._EffSprAEdBtn_1.Name = "_EffSprAEdBtn_1"
        Me._EffSprAEdBtn_1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._EffSprAEdBtn_1.Size = New System.Drawing.Size(69, 22)
        Me._EffSprAEdBtn_1.TabIndex = 62
        Me._EffSprAEdBtn_1.Text = "--> Edit.."
        Me._EffSprAEdBtn_1.UseVisualStyleBackColor = False
        '
        '_EffSprAEdBtn_0
        '
        Me._EffSprAEdBtn_0.BackColor = System.Drawing.SystemColors.Control
        Me._EffSprAEdBtn_0.Cursor = System.Windows.Forms.Cursors.Default
        Me._EffSprAEdBtn_0.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._EffSprAEdBtn_0.ForeColor = System.Drawing.SystemColors.ControlText
        Me._EffSprAEdBtn_0.Location = New System.Drawing.Point(58, 62)
        Me._EffSprAEdBtn_0.Name = "_EffSprAEdBtn_0"
        Me._EffSprAEdBtn_0.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._EffSprAEdBtn_0.Size = New System.Drawing.Size(69, 22)
        Me._EffSprAEdBtn_0.TabIndex = 28
        Me._EffSprAEdBtn_0.Text = "--> Edit.."
        Me._EffSprAEdBtn_0.UseVisualStyleBackColor = False
        '
        '_EffSprUD_0
        '
        Me._EffSprUD_0.Hexadecimal = True
        Me._EffSprUD_0.Location = New System.Drawing.Point(9, 63)
        Me._EffSprUD_0.Maximum = New Decimal(New Integer() {127, 0, 0, 0})
        Me._EffSprUD_0.Name = "_EffSprUD_0"
        Me._EffSprUD_0.Size = New System.Drawing.Size(45, 20)
        Me._EffSprUD_0.TabIndex = 32
        '
        '_EffSprUD_3
        '
        Me._EffSprUD_3.Hexadecimal = True
        Me._EffSprUD_3.Location = New System.Drawing.Point(208, 85)
        Me._EffSprUD_3.Maximum = New Decimal(New Integer() {55, 0, 0, 0})
        Me._EffSprUD_3.Name = "_EffSprUD_3"
        Me._EffSprUD_3.Size = New System.Drawing.Size(45, 20)
        Me._EffSprUD_3.TabIndex = 103
        '
        '_GemFrame_0
        '
        Me._GemFrame_0.BackColor = System.Drawing.SystemColors.Control
        Me._GemFrame_0.Controls.Add(Me.Label5)
        Me._GemFrame_0.Controls.Add(Me.Bank1UD)
        Me._GemFrame_0.Controls.Add(Me.Bank0UD)
        Me._GemFrame_0.Controls.Add(Me.GFXSetUD)
        Me._GemFrame_0.Controls.Add(Me.Label7)
        Me._GemFrame_0.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._GemFrame_0.ForeColor = System.Drawing.SystemColors.ControlText
        Me._GemFrame_0.Location = New System.Drawing.Point(550, 16)
        Me._GemFrame_0.Name = "_GemFrame_0"
        Me._GemFrame_0.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._GemFrame_0.Size = New System.Drawing.Size(129, 93)
        Me._GemFrame_0.TabIndex = 99
        Me._GemFrame_0.TabStop = False
        Me._GemFrame_0.Text = "GFX Set"
        '
        'Label5
        '
        Me.Label5.BackColor = System.Drawing.SystemColors.Control
        Me.Label5.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label5.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label5.Location = New System.Drawing.Point(6, 50)
        Me.Label5.Name = "Label5"
        Me.Label5.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label5.Size = New System.Drawing.Size(41, 17)
        Me.Label5.TabIndex = 22
        Me.Label5.Text = "Bank 1"
        '
        'Bank1UD
        '
        Me.Bank1UD.Hexadecimal = True
        Me.Bank1UD.Location = New System.Drawing.Point(67, 50)
        Me.Bank1UD.Maximum = New Decimal(New Integer() {127, 0, 0, 0})
        Me.Bank1UD.Name = "Bank1UD"
        Me.Bank1UD.Size = New System.Drawing.Size(42, 20)
        Me.Bank1UD.TabIndex = 18
        '
        'Bank0UD
        '
        Me.Bank0UD.Hexadecimal = True
        Me.Bank0UD.Location = New System.Drawing.Point(67, 25)
        Me.Bank0UD.Maximum = New Decimal(New Integer() {127, 0, 0, 0})
        Me.Bank0UD.Name = "Bank0UD"
        Me.Bank0UD.Size = New System.Drawing.Size(42, 20)
        Me.Bank0UD.TabIndex = 16
        '
        'GFXSetUD
        '
        Me.GFXSetUD.Hexadecimal = True
        Me.GFXSetUD.Location = New System.Drawing.Point(67, 0)
        Me.GFXSetUD.Maximum = New Decimal(New Integer() {57, 0, 0, 0})
        Me.GFXSetUD.Name = "GFXSetUD"
        Me.GFXSetUD.Size = New System.Drawing.Size(42, 20)
        Me.GFXSetUD.TabIndex = 21
        '
        'Label7
        '
        Me.Label7.BackColor = System.Drawing.SystemColors.Control
        Me.Label7.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label7.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label7.Location = New System.Drawing.Point(6, 25)
        Me.Label7.Name = "Label7"
        Me.Label7.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label7.Size = New System.Drawing.Size(41, 17)
        Me.Label7.TabIndex = 14
        Me.Label7.Text = "Bank 0"
        '
        'EnemEd
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 14.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.ClientSize = New System.Drawing.Size(704, 507)
        Me.Controls.Add(Me._GemFrame_2)
        Me.Controls.Add(Me._GemFrame_1)
        Me.Controls.Add(Me._GemFrame_0)
        Me.Controls.Add(Me.ScrnPresUD)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.TabControlEnemEd)
        Me.Controls.Add(Me.SprAnimTB)
        Me.Controls.Add(Me.AnimCheck)
        Me.Controls.Add(Me.SprGroupBtn)
        Me.Controls.Add(Me.DelEnemBtn)
        Me.Controls.Add(Me.InsEnemBtn)
        Me.Controls.Add(Me.FavLoadBtn)
        Me.Controls.Add(Me.FavSaveBtn)
        Me.Controls.Add(Me.RemFavBtn)
        Me.Controls.Add(Me.AddFavBtn)
        Me.Controls.Add(Me.FavEnemList)
        Me.Controls.Add(Me.EffSprEdFrame)
        Me.Controls.Add(Me.GFXEnemList)
        Me.Controls.Add(Me.AutoSetCheck)
        Me.Controls.Add(Me.FindGFXBtn)
        Me.Controls.Add(Me.CurScrnTB)
        Me.Controls.Add(Me.PCShowCmd)
        Me.Controls.Add(Me.ScrnScroll)
        Me.Controls.Add(Me.PalPic)
        Me.Controls.Add(Me.TilePic)
        Me.Controls.Add(Me.ScreenPic)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.CurScrollLabel)
        Me.Cursor = System.Windows.Forms.Cursors.Default
        Me.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.Location = New System.Drawing.Point(3, 28)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "EnemEd"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Text = " Enemy Editor"
        CType(Me.CurEnemUD, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.YUD, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.XUD, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.HPUD, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TypeUD, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.WeaponDmgUD, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EnemDmgUD, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ScrUD, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ScreenPic, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ScrnPresUD, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PalPic, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabControlEnemEd.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.gbxGeneral.ResumeLayout(False)
        Me.TabPage2.ResumeLayout(False)
        Me.gbxWeapon.ResumeLayout(False)
        CType(Me.WeaponIcon, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TilePic, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BGPalUD, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PalSetUD, System.ComponentModel.ISupportInitialize).EndInit()
        Me._GemFrame_2.ResumeLayout(False)
        CType(Me.EffUD, System.ComponentModel.ISupportInitialize).EndInit()
        Me._GemFrame_1.ResumeLayout(False)
        CType(Me._EffSprUD_5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me._EffSprUD_4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me._EffSprUD_1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me._EffSprColPic_1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me._EffSprColPic_2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me._EffSprColPic_3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Frame2.ResumeLayout(False)
        CType(Me._EffSprUD_2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.EffSprEdFrame.ResumeLayout(False)
        Me.EffSprEdFrame.PerformLayout()
        CType(Me._EffSprUD_0, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me._EffSprUD_3, System.ComponentModel.ISupportInitialize).EndInit()
        Me._GemFrame_0.ResumeLayout(False)
        CType(Me.Bank1UD, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Bank0UD, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GFXSetUD, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents TabControlEnemEd As TabControl
    Friend WithEvents TabPage2 As TabPage
    Public WithEvents ScreenPic As PictureBox
    Public WithEvents TilePic As PictureBox
    Public WithEvents Label6 As Label
    Public WithEvents GFXEnemList As ListBox
    Public WithEvents Label13 As Label
    Public WithEvents BGPalUD As NumericUpDown
    Public WithEvents PalSetUD As NumericUpDown
    Public WithEvents SBCheck As CheckBox
    Public WithEvents BDCheck As CheckBox
    Public WithEvents BGPalCheck As CheckBox
    Public WithEvents _GemFrame_2 As GroupBox
    Public WithEvents Label9 As Label
    Public WithEvents EffUD As NumericUpDown
    Public WithEvents _GemFrame_1 As GroupBox
    Public WithEvents Label10 As Label
    Public WithEvents TopLabel As Label
    Public WithEvents BottomLabel As Label
    Public WithEvents Shape1 As Label
    Public WithEvents _EffSprUD_5 As NumericUpDown
    Public WithEvents _EffSprUD_4 As NumericUpDown
    Public WithEvents _EffSprUD_1 As NumericUpDown
    Public WithEvents _EffSprTypeOpt_1 As RadioButton
    Public WithEvents _EffSprTypeOpt_0 As RadioButton
    Public WithEvents _EffSprColTB_1 As TextBox
    Public WithEvents _EffSprColTB_2 As TextBox
    Public WithEvents _EffSprColTB_3 As TextBox
    Public WithEvents _EffSprColPic_1 As PictureBox
    Public WithEvents _EffSprColPic_2 As PictureBox
    Public WithEvents _EffSprColPic_3 As PictureBox
    Public WithEvents Frame2 As Panel
    Public WithEvents _EffSprSlot_3 As RadioButton
    Public WithEvents _EffSprSlot_2 As RadioButton
    Public WithEvents _EffSprSlot_1 As RadioButton
    Public WithEvents _EffSprSlot_0 As RadioButton
    Public WithEvents _EffSprUD_2 As NumericUpDown
    Public WithEvents _EffSprTypeOpt_2 As RadioButton
    Public WithEvents EffSprEdFrame As GroupBox
    Public WithEvents _EffSprTypeOpt_3 As RadioButton
    Public WithEvents _EffSprAEdBtn_1 As Button
    Public WithEvents _EffSprAEdBtn_0 As Button
    Public WithEvents _EffSprUD_0 As NumericUpDown
    Public WithEvents _EffSprUD_3 As NumericUpDown
    Public WithEvents gbxWeapon As GroupBox
    Public WithEvents EnemDmgUD As NumericUpDown
    Public WithEvents lblDamageToMegaMan As Label
    Public WithEvents Line1 As Label
    Public WithEvents WeaponDmgUD As NumericUpDown
    Public WithEvents WeaponIcon As PictureBox
    Public WithEvents Label15 As Label
    Public WithEvents WeaponList As ComboBox
    Public WithEvents _SettingsCheck_0 As CheckBox
    Public WithEvents _SettingsCheck_1 As CheckBox
    Friend WithEvents TabPage1 As TabPage
    Public WithEvents gbxGeneral As GroupBox
    Public WithEvents YUD As NumericUpDown
    Public WithEvents XUD As NumericUpDown
    Public WithEvents Label2 As Label
    Public WithEvents Label3 As Label
    Public WithEvents Label4 As Label
    Public WithEvents lblEnemyName As Label
    Public WithEvents HPUD As NumericUpDown
    Public WithEvents TypeUD As NumericUpDown
    Public WithEvents Label8 As Label
    Public WithEvents lblTypeGeneralPan As Label
    Public WithEvents CurEnemUD As NumericUpDown
    Public WithEvents lblTypeWeaponDamagePan As Label
    Public WithEvents _GemFrame_0 As GroupBox
    Public WithEvents Label5 As Label
    Public WithEvents Bank1UD As NumericUpDown
    Public WithEvents Bank0UD As NumericUpDown
    Public WithEvents GFXSetUD As NumericUpDown
    Public WithEvents Label7 As Label
    Public WithEvents ScrUD As NumericUpDown
#End Region
End Class