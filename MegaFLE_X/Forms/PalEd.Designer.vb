<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> Partial Class PalEd
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
    Public WithEvents PalSetChangeFrame As System.Windows.Forms.GroupBox
    Public WithEvents _AColTB_15 As System.Windows.Forms.TextBox
    Public WithEvents _AColTB_14 As System.Windows.Forms.TextBox
    Public WithEvents _AColTB_13 As System.Windows.Forms.TextBox
    Public WithEvents _AColTB_12 As System.Windows.Forms.TextBox
    Public WithEvents _AColTB_11 As System.Windows.Forms.TextBox
    Public WithEvents _AColTB_10 As System.Windows.Forms.TextBox
    Public WithEvents _AColTB_9 As System.Windows.Forms.TextBox
    Public WithEvents _AColTB_8 As System.Windows.Forms.TextBox
    Public WithEvents _AColTB_7 As System.Windows.Forms.TextBox
    Public WithEvents _AColTB_6 As System.Windows.Forms.TextBox
    Public WithEvents _AColTB_5 As System.Windows.Forms.TextBox
    Public WithEvents _AColTB_4 As System.Windows.Forms.TextBox
    Public WithEvents _AColTB_3 As System.Windows.Forms.TextBox
    Public WithEvents _AColTB_2 As System.Windows.Forms.TextBox
    Public WithEvents _AColTB_1 As System.Windows.Forms.TextBox
    Public WithEvents _AColTB_0 As System.Windows.Forms.TextBox
    Public WithEvents _ColTB_15 As System.Windows.Forms.TextBox
    Public WithEvents _ColTB_14 As System.Windows.Forms.TextBox
    Public WithEvents _ColTB_13 As System.Windows.Forms.TextBox
    Public WithEvents _ColTB_12 As System.Windows.Forms.TextBox
    Public WithEvents _ColTB_11 As System.Windows.Forms.TextBox
    Public WithEvents _ColTB_10 As System.Windows.Forms.TextBox
    Public WithEvents _ColTB_9 As System.Windows.Forms.TextBox
    Public WithEvents _ColTB_8 As System.Windows.Forms.TextBox
    Public WithEvents _ColTB_7 As System.Windows.Forms.TextBox
    Public WithEvents _ColTB_6 As System.Windows.Forms.TextBox
    Public WithEvents _ColTB_5 As System.Windows.Forms.TextBox
    Public WithEvents _ColTB_4 As System.Windows.Forms.TextBox
    Public WithEvents _ColTB_3 As System.Windows.Forms.TextBox
    Public WithEvents _ColTB_2 As System.Windows.Forms.TextBox
    Public WithEvents _ColTB_1 As System.Windows.Forms.TextBox
    Public WithEvents _ColTB_0 As System.Windows.Forms.TextBox
    Public WithEvents PalPic2 As System.Windows.Forms.PictureBox
    Public WithEvents _EffSw_3 As System.Windows.Forms.CheckBox
    Public WithEvents _EffSw_2 As System.Windows.Forms.CheckBox
    Public WithEvents _EffSw_1 As System.Windows.Forms.CheckBox
    Public WithEvents _EffSw_0 As System.Windows.Forms.CheckBox
    Public WithEvents PCShowCmd As System.Windows.Forms.Button
    Public WithEvents _EffUD_0 As System.Windows.Forms.NumericUpDown
    Public WithEvents _EffUD_1 As System.Windows.Forms.NumericUpDown
    Public WithEvents _EffUD_2 As System.Windows.Forms.NumericUpDown
    Public WithEvents _EffUD_3 As System.Windows.Forms.NumericUpDown
    Public WithEvents _EddLab_0 As System.Windows.Forms.Label
    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(PalEd))
        Me.PalSetChangeFrame = New System.Windows.Forms.GroupBox()
        Me._PalSetOpt_1 = New System.Windows.Forms.RadioButton()
        Me._PalSetOpt_0 = New System.Windows.Forms.RadioButton()
        Me.PalSetUD = New System.Windows.Forms.NumericUpDown()
        Me._AColTB_15 = New System.Windows.Forms.TextBox()
        Me._AColTB_14 = New System.Windows.Forms.TextBox()
        Me._AColTB_13 = New System.Windows.Forms.TextBox()
        Me._AColTB_12 = New System.Windows.Forms.TextBox()
        Me._AColTB_11 = New System.Windows.Forms.TextBox()
        Me._AColTB_10 = New System.Windows.Forms.TextBox()
        Me._AColTB_9 = New System.Windows.Forms.TextBox()
        Me._AColTB_8 = New System.Windows.Forms.TextBox()
        Me._AColTB_7 = New System.Windows.Forms.TextBox()
        Me._AColTB_6 = New System.Windows.Forms.TextBox()
        Me._AColTB_5 = New System.Windows.Forms.TextBox()
        Me._AColTB_4 = New System.Windows.Forms.TextBox()
        Me._AColTB_3 = New System.Windows.Forms.TextBox()
        Me._AColTB_2 = New System.Windows.Forms.TextBox()
        Me._AColTB_1 = New System.Windows.Forms.TextBox()
        Me._AColTB_0 = New System.Windows.Forms.TextBox()
        Me._ColTB_15 = New System.Windows.Forms.TextBox()
        Me._ColTB_14 = New System.Windows.Forms.TextBox()
        Me._ColTB_13 = New System.Windows.Forms.TextBox()
        Me._ColTB_12 = New System.Windows.Forms.TextBox()
        Me._ColTB_11 = New System.Windows.Forms.TextBox()
        Me._ColTB_10 = New System.Windows.Forms.TextBox()
        Me._ColTB_9 = New System.Windows.Forms.TextBox()
        Me._ColTB_8 = New System.Windows.Forms.TextBox()
        Me._ColTB_7 = New System.Windows.Forms.TextBox()
        Me._ColTB_6 = New System.Windows.Forms.TextBox()
        Me._ColTB_5 = New System.Windows.Forms.TextBox()
        Me._ColTB_4 = New System.Windows.Forms.TextBox()
        Me._ColTB_3 = New System.Windows.Forms.TextBox()
        Me._ColTB_2 = New System.Windows.Forms.TextBox()
        Me._ColTB_1 = New System.Windows.Forms.TextBox()
        Me._ColTB_0 = New System.Windows.Forms.TextBox()
        Me.PalPic2 = New System.Windows.Forms.PictureBox()
        Me._EffSw_3 = New System.Windows.Forms.CheckBox()
        Me._EffSw_2 = New System.Windows.Forms.CheckBox()
        Me._EffSw_1 = New System.Windows.Forms.CheckBox()
        Me._EffSw_0 = New System.Windows.Forms.CheckBox()
        Me.PCShowCmd = New System.Windows.Forms.Button()
        Me._EffUD_0 = New System.Windows.Forms.NumericUpDown()
        Me._EffUD_1 = New System.Windows.Forms.NumericUpDown()
        Me._EffUD_2 = New System.Windows.Forms.NumericUpDown()
        Me._EffUD_3 = New System.Windows.Forms.NumericUpDown()
        Me._EddLab_0 = New System.Windows.Forms.Label()
        Me.tabPalWeapon = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.gbxPalAnim = New System.Windows.Forms.GroupBox()
        Me.PieceUD = New System.Windows.Forms.NumericUpDown()
        Me.DelayUD = New System.Windows.Forms.NumericUpDown()
        Me.FrameSelect = New System.Windows.Forms.HScrollBar()
        Me.Label1 = New System.Windows.Forms.Label()
        Me._PAColPic_2 = New System.Windows.Forms.PictureBox()
        Me._PAColPic_1 = New System.Windows.Forms.PictureBox()
        Me._PAColPic_0 = New System.Windows.Forms.PictureBox()
        Me.DstColUD = New System.Windows.Forms.NumericUpDown()
        Me._PAColTB_2 = New System.Windows.Forms.TextBox()
        Me._PAColTB_1 = New System.Windows.Forms.TextBox()
        Me._PAColTB_0 = New System.Windows.Forms.TextBox()
        Me.FramesUD = New System.Windows.Forms.NumericUpDown()
        Me.PAIDUD = New System.Windows.Forms.NumericUpDown()
        Me.DstColLab = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.gbxWeaponSelected = New System.Windows.Forms.GroupBox()
        Me.Preview = New System.Windows.Forms.PictureBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.WeaponIcon = New System.Windows.Forms.PictureBox()
        Me.PrevWP_SprBtn = New System.Windows.Forms.Button()
        Me.PrevSprTB = New System.Windows.Forms.TextBox()
        Me.WeaponList = New System.Windows.Forms.ComboBox()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.Text5 = New System.Windows.Forms.TextBox()
        Me.PalPic = New System.Windows.Forms.PictureBox()
        Me._EddLab_1 = New System.Windows.Forms.Label()
        Me._EddLab_2 = New System.Windows.Forms.Label()
        Me._EddLab_3 = New System.Windows.Forms.Label()
        Me.Command6 = New System.Windows.Forms.Button()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.PalSetChangeFrame.SuspendLayout()
        CType(Me.PalSetUD, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PalPic2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me._EffUD_0, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me._EffUD_1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me._EffUD_2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me._EffUD_3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tabPalWeapon.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.gbxPalAnim.SuspendLayout()
        CType(Me.PieceUD, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DelayUD, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me._PAColPic_2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me._PAColPic_1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me._PAColPic_0, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DstColUD, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.FramesUD, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PAIDUD, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage2.SuspendLayout()
        Me.gbxWeaponSelected.SuspendLayout()
        CType(Me.Preview, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.WeaponIcon, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PalPic, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PalSetChangeFrame
        '
        Me.PalSetChangeFrame.BackColor = System.Drawing.SystemColors.Control
        Me.PalSetChangeFrame.Controls.Add(Me._PalSetOpt_1)
        Me.PalSetChangeFrame.Controls.Add(Me._PalSetOpt_0)
        Me.PalSetChangeFrame.Controls.Add(Me.PalSetUD)
        Me.PalSetChangeFrame.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.PalSetChangeFrame.ForeColor = System.Drawing.SystemColors.ControlText
        Me.PalSetChangeFrame.Location = New System.Drawing.Point(362, 181)
        Me.PalSetChangeFrame.Name = "PalSetChangeFrame"
        Me.PalSetChangeFrame.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.PalSetChangeFrame.Size = New System.Drawing.Size(151, 95)
        Me.PalSetChangeFrame.TabIndex = 75
        Me.PalSetChangeFrame.TabStop = False
        Me.PalSetChangeFrame.Text = " Palette Set change: "
        '
        '_PalSetOpt_1
        '
        Me._PalSetOpt_1.BackColor = System.Drawing.SystemColors.Control
        Me._PalSetOpt_1.Cursor = System.Windows.Forms.Cursors.Default
        Me._PalSetOpt_1.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._PalSetOpt_1.ForeColor = System.Drawing.SystemColors.ControlText
        Me._PalSetOpt_1.Location = New System.Drawing.Point(12, 40)
        Me._PalSetOpt_1.Name = "_PalSetOpt_1"
        Me._PalSetOpt_1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._PalSetOpt_1.Size = New System.Drawing.Size(97, 17)
        Me._PalSetOpt_1.TabIndex = 81
        Me._PalSetOpt_1.TabStop = True
        Me._PalSetOpt_1.Text = "Manual Select:"
        Me._PalSetOpt_1.UseVisualStyleBackColor = False
        '
        '_PalSetOpt_0
        '
        Me._PalSetOpt_0.BackColor = System.Drawing.SystemColors.Control
        Me._PalSetOpt_0.Cursor = System.Windows.Forms.Cursors.Default
        Me._PalSetOpt_0.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._PalSetOpt_0.ForeColor = System.Drawing.SystemColors.ControlText
        Me._PalSetOpt_0.Location = New System.Drawing.Point(12, 21)
        Me._PalSetOpt_0.Name = "_PalSetOpt_0"
        Me._PalSetOpt_0.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._PalSetOpt_0.Size = New System.Drawing.Size(97, 17)
        Me._PalSetOpt_0.TabIndex = 80
        Me._PalSetOpt_0.TabStop = True
        Me._PalSetOpt_0.Text = "Auto"
        Me._PalSetOpt_0.UseVisualStyleBackColor = False
        '
        'PalSetUD
        '
        Me.PalSetUD.Font = New System.Drawing.Font("Arial", 14.0!, System.Drawing.FontStyle.Bold)
        Me.PalSetUD.Hexadecimal = True
        Me.PalSetUD.Location = New System.Drawing.Point(39, 60)
        Me.PalSetUD.Maximum = New Decimal(New Integer() {256, 0, 0, 0})
        Me.PalSetUD.Name = "PalSetUD"
        Me.PalSetUD.Size = New System.Drawing.Size(70, 34)
        Me.PalSetUD.TabIndex = 83
        Me.PalSetUD.Tag = ""
        '
        '_AColTB_15
        '
        Me._AColTB_15.AcceptsReturn = True
        Me._AColTB_15.BackColor = System.Drawing.SystemColors.Window
        Me._AColTB_15.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._AColTB_15.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._AColTB_15.ForeColor = System.Drawing.SystemColors.WindowText
        Me._AColTB_15.Location = New System.Drawing.Point(483, 127)
        Me._AColTB_15.MaxLength = 0
        Me._AColTB_15.Name = "_AColTB_15"
        Me._AColTB_15.ReadOnly = True
        Me._AColTB_15.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._AColTB_15.Size = New System.Drawing.Size(33, 23)
        Me._AColTB_15.TabIndex = 72
        '
        '_AColTB_14
        '
        Me._AColTB_14.AcceptsReturn = True
        Me._AColTB_14.BackColor = System.Drawing.SystemColors.Window
        Me._AColTB_14.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._AColTB_14.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._AColTB_14.ForeColor = System.Drawing.SystemColors.WindowText
        Me._AColTB_14.Location = New System.Drawing.Point(451, 127)
        Me._AColTB_14.MaxLength = 0
        Me._AColTB_14.Name = "_AColTB_14"
        Me._AColTB_14.ReadOnly = True
        Me._AColTB_14.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._AColTB_14.Size = New System.Drawing.Size(33, 23)
        Me._AColTB_14.TabIndex = 71
        '
        '_AColTB_13
        '
        Me._AColTB_13.AcceptsReturn = True
        Me._AColTB_13.BackColor = System.Drawing.SystemColors.Window
        Me._AColTB_13.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._AColTB_13.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._AColTB_13.ForeColor = System.Drawing.SystemColors.WindowText
        Me._AColTB_13.Location = New System.Drawing.Point(419, 127)
        Me._AColTB_13.MaxLength = 0
        Me._AColTB_13.Name = "_AColTB_13"
        Me._AColTB_13.ReadOnly = True
        Me._AColTB_13.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._AColTB_13.Size = New System.Drawing.Size(33, 23)
        Me._AColTB_13.TabIndex = 70
        '
        '_AColTB_12
        '
        Me._AColTB_12.AcceptsReturn = True
        Me._AColTB_12.BackColor = System.Drawing.SystemColors.Window
        Me._AColTB_12.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._AColTB_12.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._AColTB_12.ForeColor = System.Drawing.SystemColors.WindowText
        Me._AColTB_12.Location = New System.Drawing.Point(387, 127)
        Me._AColTB_12.MaxLength = 0
        Me._AColTB_12.Name = "_AColTB_12"
        Me._AColTB_12.ReadOnly = True
        Me._AColTB_12.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._AColTB_12.Size = New System.Drawing.Size(33, 23)
        Me._AColTB_12.TabIndex = 69
        '
        '_AColTB_11
        '
        Me._AColTB_11.AcceptsReturn = True
        Me._AColTB_11.BackColor = System.Drawing.SystemColors.Window
        Me._AColTB_11.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._AColTB_11.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._AColTB_11.ForeColor = System.Drawing.SystemColors.WindowText
        Me._AColTB_11.Location = New System.Drawing.Point(355, 127)
        Me._AColTB_11.MaxLength = 0
        Me._AColTB_11.Name = "_AColTB_11"
        Me._AColTB_11.ReadOnly = True
        Me._AColTB_11.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._AColTB_11.Size = New System.Drawing.Size(33, 23)
        Me._AColTB_11.TabIndex = 68
        '
        '_AColTB_10
        '
        Me._AColTB_10.AcceptsReturn = True
        Me._AColTB_10.BackColor = System.Drawing.SystemColors.Window
        Me._AColTB_10.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._AColTB_10.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._AColTB_10.ForeColor = System.Drawing.SystemColors.WindowText
        Me._AColTB_10.Location = New System.Drawing.Point(323, 127)
        Me._AColTB_10.MaxLength = 0
        Me._AColTB_10.Name = "_AColTB_10"
        Me._AColTB_10.ReadOnly = True
        Me._AColTB_10.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._AColTB_10.Size = New System.Drawing.Size(33, 23)
        Me._AColTB_10.TabIndex = 67
        '
        '_AColTB_9
        '
        Me._AColTB_9.AcceptsReturn = True
        Me._AColTB_9.BackColor = System.Drawing.SystemColors.Window
        Me._AColTB_9.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._AColTB_9.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._AColTB_9.ForeColor = System.Drawing.SystemColors.WindowText
        Me._AColTB_9.Location = New System.Drawing.Point(291, 127)
        Me._AColTB_9.MaxLength = 0
        Me._AColTB_9.Name = "_AColTB_9"
        Me._AColTB_9.ReadOnly = True
        Me._AColTB_9.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._AColTB_9.Size = New System.Drawing.Size(33, 23)
        Me._AColTB_9.TabIndex = 66
        '
        '_AColTB_8
        '
        Me._AColTB_8.AcceptsReturn = True
        Me._AColTB_8.BackColor = System.Drawing.SystemColors.Window
        Me._AColTB_8.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._AColTB_8.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._AColTB_8.ForeColor = System.Drawing.SystemColors.WindowText
        Me._AColTB_8.Location = New System.Drawing.Point(259, 127)
        Me._AColTB_8.MaxLength = 0
        Me._AColTB_8.Name = "_AColTB_8"
        Me._AColTB_8.ReadOnly = True
        Me._AColTB_8.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._AColTB_8.Size = New System.Drawing.Size(33, 23)
        Me._AColTB_8.TabIndex = 65
        '
        '_AColTB_7
        '
        Me._AColTB_7.AcceptsReturn = True
        Me._AColTB_7.BackColor = System.Drawing.SystemColors.Window
        Me._AColTB_7.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._AColTB_7.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._AColTB_7.ForeColor = System.Drawing.SystemColors.WindowText
        Me._AColTB_7.Location = New System.Drawing.Point(227, 127)
        Me._AColTB_7.MaxLength = 0
        Me._AColTB_7.Name = "_AColTB_7"
        Me._AColTB_7.ReadOnly = True
        Me._AColTB_7.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._AColTB_7.Size = New System.Drawing.Size(33, 23)
        Me._AColTB_7.TabIndex = 64
        '
        '_AColTB_6
        '
        Me._AColTB_6.AcceptsReturn = True
        Me._AColTB_6.BackColor = System.Drawing.SystemColors.Window
        Me._AColTB_6.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._AColTB_6.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._AColTB_6.ForeColor = System.Drawing.SystemColors.WindowText
        Me._AColTB_6.Location = New System.Drawing.Point(195, 127)
        Me._AColTB_6.MaxLength = 0
        Me._AColTB_6.Name = "_AColTB_6"
        Me._AColTB_6.ReadOnly = True
        Me._AColTB_6.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._AColTB_6.Size = New System.Drawing.Size(33, 23)
        Me._AColTB_6.TabIndex = 63
        '
        '_AColTB_5
        '
        Me._AColTB_5.AcceptsReturn = True
        Me._AColTB_5.BackColor = System.Drawing.SystemColors.Window
        Me._AColTB_5.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._AColTB_5.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._AColTB_5.ForeColor = System.Drawing.SystemColors.WindowText
        Me._AColTB_5.Location = New System.Drawing.Point(163, 127)
        Me._AColTB_5.MaxLength = 0
        Me._AColTB_5.Name = "_AColTB_5"
        Me._AColTB_5.ReadOnly = True
        Me._AColTB_5.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._AColTB_5.Size = New System.Drawing.Size(33, 23)
        Me._AColTB_5.TabIndex = 62
        '
        '_AColTB_4
        '
        Me._AColTB_4.AcceptsReturn = True
        Me._AColTB_4.BackColor = System.Drawing.SystemColors.Window
        Me._AColTB_4.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._AColTB_4.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._AColTB_4.ForeColor = System.Drawing.SystemColors.WindowText
        Me._AColTB_4.Location = New System.Drawing.Point(131, 127)
        Me._AColTB_4.MaxLength = 0
        Me._AColTB_4.Name = "_AColTB_4"
        Me._AColTB_4.ReadOnly = True
        Me._AColTB_4.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._AColTB_4.Size = New System.Drawing.Size(33, 23)
        Me._AColTB_4.TabIndex = 61
        '
        '_AColTB_3
        '
        Me._AColTB_3.AcceptsReturn = True
        Me._AColTB_3.BackColor = System.Drawing.SystemColors.Window
        Me._AColTB_3.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._AColTB_3.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._AColTB_3.ForeColor = System.Drawing.SystemColors.WindowText
        Me._AColTB_3.Location = New System.Drawing.Point(99, 127)
        Me._AColTB_3.MaxLength = 0
        Me._AColTB_3.Name = "_AColTB_3"
        Me._AColTB_3.ReadOnly = True
        Me._AColTB_3.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._AColTB_3.Size = New System.Drawing.Size(33, 23)
        Me._AColTB_3.TabIndex = 60
        '
        '_AColTB_2
        '
        Me._AColTB_2.AcceptsReturn = True
        Me._AColTB_2.BackColor = System.Drawing.SystemColors.Window
        Me._AColTB_2.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._AColTB_2.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._AColTB_2.ForeColor = System.Drawing.SystemColors.WindowText
        Me._AColTB_2.Location = New System.Drawing.Point(67, 127)
        Me._AColTB_2.MaxLength = 0
        Me._AColTB_2.Name = "_AColTB_2"
        Me._AColTB_2.ReadOnly = True
        Me._AColTB_2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._AColTB_2.Size = New System.Drawing.Size(33, 23)
        Me._AColTB_2.TabIndex = 59
        '
        '_AColTB_1
        '
        Me._AColTB_1.AcceptsReturn = True
        Me._AColTB_1.BackColor = System.Drawing.SystemColors.Window
        Me._AColTB_1.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._AColTB_1.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._AColTB_1.ForeColor = System.Drawing.SystemColors.WindowText
        Me._AColTB_1.Location = New System.Drawing.Point(35, 127)
        Me._AColTB_1.MaxLength = 0
        Me._AColTB_1.Name = "_AColTB_1"
        Me._AColTB_1.ReadOnly = True
        Me._AColTB_1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._AColTB_1.Size = New System.Drawing.Size(33, 23)
        Me._AColTB_1.TabIndex = 58
        '
        '_AColTB_0
        '
        Me._AColTB_0.AcceptsReturn = True
        Me._AColTB_0.BackColor = System.Drawing.SystemColors.Window
        Me._AColTB_0.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._AColTB_0.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._AColTB_0.ForeColor = System.Drawing.SystemColors.WindowText
        Me._AColTB_0.Location = New System.Drawing.Point(3, 127)
        Me._AColTB_0.MaxLength = 0
        Me._AColTB_0.Name = "_AColTB_0"
        Me._AColTB_0.ReadOnly = True
        Me._AColTB_0.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._AColTB_0.Size = New System.Drawing.Size(33, 23)
        Me._AColTB_0.TabIndex = 57
        '
        '_ColTB_15
        '
        Me._ColTB_15.AcceptsReturn = True
        Me._ColTB_15.BackColor = System.Drawing.SystemColors.Window
        Me._ColTB_15.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._ColTB_15.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._ColTB_15.ForeColor = System.Drawing.SystemColors.WindowText
        Me._ColTB_15.Location = New System.Drawing.Point(483, 38)
        Me._ColTB_15.MaxLength = 0
        Me._ColTB_15.Name = "_ColTB_15"
        Me._ColTB_15.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._ColTB_15.Size = New System.Drawing.Size(33, 23)
        Me._ColTB_15.TabIndex = 56
        '
        '_ColTB_14
        '
        Me._ColTB_14.AcceptsReturn = True
        Me._ColTB_14.BackColor = System.Drawing.SystemColors.Window
        Me._ColTB_14.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._ColTB_14.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._ColTB_14.ForeColor = System.Drawing.SystemColors.WindowText
        Me._ColTB_14.Location = New System.Drawing.Point(451, 38)
        Me._ColTB_14.MaxLength = 0
        Me._ColTB_14.Name = "_ColTB_14"
        Me._ColTB_14.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._ColTB_14.Size = New System.Drawing.Size(33, 23)
        Me._ColTB_14.TabIndex = 55
        '
        '_ColTB_13
        '
        Me._ColTB_13.AcceptsReturn = True
        Me._ColTB_13.BackColor = System.Drawing.SystemColors.Window
        Me._ColTB_13.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._ColTB_13.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._ColTB_13.ForeColor = System.Drawing.SystemColors.WindowText
        Me._ColTB_13.Location = New System.Drawing.Point(419, 38)
        Me._ColTB_13.MaxLength = 0
        Me._ColTB_13.Name = "_ColTB_13"
        Me._ColTB_13.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._ColTB_13.Size = New System.Drawing.Size(33, 23)
        Me._ColTB_13.TabIndex = 54
        '
        '_ColTB_12
        '
        Me._ColTB_12.AcceptsReturn = True
        Me._ColTB_12.BackColor = System.Drawing.SystemColors.Window
        Me._ColTB_12.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._ColTB_12.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._ColTB_12.ForeColor = System.Drawing.SystemColors.WindowText
        Me._ColTB_12.Location = New System.Drawing.Point(387, 38)
        Me._ColTB_12.MaxLength = 0
        Me._ColTB_12.Name = "_ColTB_12"
        Me._ColTB_12.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._ColTB_12.Size = New System.Drawing.Size(33, 23)
        Me._ColTB_12.TabIndex = 53
        '
        '_ColTB_11
        '
        Me._ColTB_11.AcceptsReturn = True
        Me._ColTB_11.BackColor = System.Drawing.SystemColors.Window
        Me._ColTB_11.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._ColTB_11.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._ColTB_11.ForeColor = System.Drawing.SystemColors.WindowText
        Me._ColTB_11.Location = New System.Drawing.Point(355, 38)
        Me._ColTB_11.MaxLength = 0
        Me._ColTB_11.Name = "_ColTB_11"
        Me._ColTB_11.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._ColTB_11.Size = New System.Drawing.Size(33, 23)
        Me._ColTB_11.TabIndex = 52
        '
        '_ColTB_10
        '
        Me._ColTB_10.AcceptsReturn = True
        Me._ColTB_10.BackColor = System.Drawing.SystemColors.Window
        Me._ColTB_10.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._ColTB_10.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._ColTB_10.ForeColor = System.Drawing.SystemColors.WindowText
        Me._ColTB_10.Location = New System.Drawing.Point(323, 38)
        Me._ColTB_10.MaxLength = 0
        Me._ColTB_10.Name = "_ColTB_10"
        Me._ColTB_10.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._ColTB_10.Size = New System.Drawing.Size(33, 23)
        Me._ColTB_10.TabIndex = 51
        '
        '_ColTB_9
        '
        Me._ColTB_9.AcceptsReturn = True
        Me._ColTB_9.BackColor = System.Drawing.SystemColors.Window
        Me._ColTB_9.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._ColTB_9.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._ColTB_9.ForeColor = System.Drawing.SystemColors.WindowText
        Me._ColTB_9.Location = New System.Drawing.Point(291, 38)
        Me._ColTB_9.MaxLength = 0
        Me._ColTB_9.Name = "_ColTB_9"
        Me._ColTB_9.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._ColTB_9.Size = New System.Drawing.Size(33, 23)
        Me._ColTB_9.TabIndex = 50
        '
        '_ColTB_8
        '
        Me._ColTB_8.AcceptsReturn = True
        Me._ColTB_8.BackColor = System.Drawing.SystemColors.Window
        Me._ColTB_8.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._ColTB_8.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._ColTB_8.ForeColor = System.Drawing.SystemColors.WindowText
        Me._ColTB_8.Location = New System.Drawing.Point(259, 38)
        Me._ColTB_8.MaxLength = 0
        Me._ColTB_8.Name = "_ColTB_8"
        Me._ColTB_8.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._ColTB_8.Size = New System.Drawing.Size(33, 23)
        Me._ColTB_8.TabIndex = 49
        '
        '_ColTB_7
        '
        Me._ColTB_7.AcceptsReturn = True
        Me._ColTB_7.BackColor = System.Drawing.SystemColors.Window
        Me._ColTB_7.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._ColTB_7.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._ColTB_7.ForeColor = System.Drawing.SystemColors.WindowText
        Me._ColTB_7.Location = New System.Drawing.Point(227, 38)
        Me._ColTB_7.MaxLength = 0
        Me._ColTB_7.Name = "_ColTB_7"
        Me._ColTB_7.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._ColTB_7.Size = New System.Drawing.Size(33, 23)
        Me._ColTB_7.TabIndex = 48
        '
        '_ColTB_6
        '
        Me._ColTB_6.AcceptsReturn = True
        Me._ColTB_6.BackColor = System.Drawing.SystemColors.Window
        Me._ColTB_6.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._ColTB_6.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._ColTB_6.ForeColor = System.Drawing.SystemColors.WindowText
        Me._ColTB_6.Location = New System.Drawing.Point(195, 38)
        Me._ColTB_6.MaxLength = 0
        Me._ColTB_6.Name = "_ColTB_6"
        Me._ColTB_6.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._ColTB_6.Size = New System.Drawing.Size(33, 23)
        Me._ColTB_6.TabIndex = 47
        '
        '_ColTB_5
        '
        Me._ColTB_5.AcceptsReturn = True
        Me._ColTB_5.BackColor = System.Drawing.SystemColors.Window
        Me._ColTB_5.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._ColTB_5.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._ColTB_5.ForeColor = System.Drawing.SystemColors.WindowText
        Me._ColTB_5.Location = New System.Drawing.Point(163, 38)
        Me._ColTB_5.MaxLength = 0
        Me._ColTB_5.Name = "_ColTB_5"
        Me._ColTB_5.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._ColTB_5.Size = New System.Drawing.Size(33, 23)
        Me._ColTB_5.TabIndex = 46
        '
        '_ColTB_4
        '
        Me._ColTB_4.AcceptsReturn = True
        Me._ColTB_4.BackColor = System.Drawing.SystemColors.Window
        Me._ColTB_4.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._ColTB_4.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._ColTB_4.ForeColor = System.Drawing.SystemColors.WindowText
        Me._ColTB_4.Location = New System.Drawing.Point(131, 38)
        Me._ColTB_4.MaxLength = 0
        Me._ColTB_4.Name = "_ColTB_4"
        Me._ColTB_4.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._ColTB_4.Size = New System.Drawing.Size(33, 23)
        Me._ColTB_4.TabIndex = 45
        '
        '_ColTB_3
        '
        Me._ColTB_3.AcceptsReturn = True
        Me._ColTB_3.BackColor = System.Drawing.SystemColors.Window
        Me._ColTB_3.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._ColTB_3.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._ColTB_3.ForeColor = System.Drawing.SystemColors.WindowText
        Me._ColTB_3.Location = New System.Drawing.Point(99, 38)
        Me._ColTB_3.MaxLength = 0
        Me._ColTB_3.Name = "_ColTB_3"
        Me._ColTB_3.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._ColTB_3.Size = New System.Drawing.Size(33, 23)
        Me._ColTB_3.TabIndex = 44
        '
        '_ColTB_2
        '
        Me._ColTB_2.AcceptsReturn = True
        Me._ColTB_2.BackColor = System.Drawing.SystemColors.Window
        Me._ColTB_2.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._ColTB_2.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._ColTB_2.ForeColor = System.Drawing.SystemColors.WindowText
        Me._ColTB_2.Location = New System.Drawing.Point(67, 38)
        Me._ColTB_2.MaxLength = 0
        Me._ColTB_2.Name = "_ColTB_2"
        Me._ColTB_2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._ColTB_2.Size = New System.Drawing.Size(33, 23)
        Me._ColTB_2.TabIndex = 43
        '
        '_ColTB_1
        '
        Me._ColTB_1.AcceptsReturn = True
        Me._ColTB_1.BackColor = System.Drawing.SystemColors.Window
        Me._ColTB_1.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._ColTB_1.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._ColTB_1.ForeColor = System.Drawing.SystemColors.WindowText
        Me._ColTB_1.Location = New System.Drawing.Point(35, 38)
        Me._ColTB_1.MaxLength = 0
        Me._ColTB_1.Name = "_ColTB_1"
        Me._ColTB_1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._ColTB_1.Size = New System.Drawing.Size(33, 23)
        Me._ColTB_1.TabIndex = 42
        '
        '_ColTB_0
        '
        Me._ColTB_0.AcceptsReturn = True
        Me._ColTB_0.BackColor = System.Drawing.SystemColors.Window
        Me._ColTB_0.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._ColTB_0.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._ColTB_0.ForeColor = System.Drawing.SystemColors.WindowText
        Me._ColTB_0.Location = New System.Drawing.Point(3, 38)
        Me._ColTB_0.MaxLength = 0
        Me._ColTB_0.Name = "_ColTB_0"
        Me._ColTB_0.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._ColTB_0.Size = New System.Drawing.Size(33, 23)
        Me._ColTB_0.TabIndex = 41
        '
        'PalPic2
        '
        Me.PalPic2.BackColor = System.Drawing.SystemColors.Control
        Me.PalPic2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.PalPic2.Cursor = System.Windows.Forms.Cursors.Default
        Me.PalPic2.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.PalPic2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.PalPic2.Location = New System.Drawing.Point(0, 87)
        Me.PalPic2.Name = "PalPic2"
        Me.PalPic2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.PalPic2.Size = New System.Drawing.Size(518, 38)
        Me.PalPic2.TabIndex = 15
        Me.PalPic2.TabStop = False
        '
        '_EffSw_3
        '
        Me._EffSw_3.BackColor = System.Drawing.SystemColors.Control
        Me._EffSw_3.Cursor = System.Windows.Forms.Cursors.Default
        Me._EffSw_3.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._EffSw_3.ForeColor = System.Drawing.SystemColors.ControlText
        Me._EffSw_3.Location = New System.Drawing.Point(496, 64)
        Me._EffSw_3.Name = "_EffSw_3"
        Me._EffSw_3.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._EffSw_3.Size = New System.Drawing.Size(17, 17)
        Me._EffSw_3.TabIndex = 14
        Me._EffSw_3.UseVisualStyleBackColor = False
        '
        '_EffSw_2
        '
        Me._EffSw_2.BackColor = System.Drawing.SystemColors.Control
        Me._EffSw_2.Cursor = System.Windows.Forms.Cursors.Default
        Me._EffSw_2.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._EffSw_2.ForeColor = System.Drawing.SystemColors.ControlText
        Me._EffSw_2.Location = New System.Drawing.Point(368, 64)
        Me._EffSw_2.Name = "_EffSw_2"
        Me._EffSw_2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._EffSw_2.Size = New System.Drawing.Size(17, 17)
        Me._EffSw_2.TabIndex = 13
        Me._EffSw_2.UseVisualStyleBackColor = False
        '
        '_EffSw_1
        '
        Me._EffSw_1.BackColor = System.Drawing.SystemColors.Control
        Me._EffSw_1.Cursor = System.Windows.Forms.Cursors.Default
        Me._EffSw_1.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._EffSw_1.ForeColor = System.Drawing.SystemColors.ControlText
        Me._EffSw_1.Location = New System.Drawing.Point(240, 64)
        Me._EffSw_1.Name = "_EffSw_1"
        Me._EffSw_1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._EffSw_1.Size = New System.Drawing.Size(17, 17)
        Me._EffSw_1.TabIndex = 12
        Me._EffSw_1.UseVisualStyleBackColor = False
        '
        '_EffSw_0
        '
        Me._EffSw_0.BackColor = System.Drawing.SystemColors.Control
        Me._EffSw_0.Cursor = System.Windows.Forms.Cursors.Default
        Me._EffSw_0.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._EffSw_0.ForeColor = System.Drawing.SystemColors.ControlText
        Me._EffSw_0.Location = New System.Drawing.Point(112, 64)
        Me._EffSw_0.Name = "_EffSw_0"
        Me._EffSw_0.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._EffSw_0.Size = New System.Drawing.Size(17, 17)
        Me._EffSw_0.TabIndex = 11
        Me._EffSw_0.UseVisualStyleBackColor = False
        '
        'PCShowCmd
        '
        Me.PCShowCmd.BackColor = System.Drawing.SystemColors.Control
        Me.PCShowCmd.Cursor = System.Windows.Forms.Cursors.Default
        Me.PCShowCmd.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.PCShowCmd.ForeColor = System.Drawing.SystemColors.ControlText
        Me.PCShowCmd.Location = New System.Drawing.Point(368, 150)
        Me.PCShowCmd.Name = "PCShowCmd"
        Me.PCShowCmd.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.PCShowCmd.Size = New System.Drawing.Size(145, 26)
        Me.PCShowCmd.TabIndex = 1
        Me.PCShowCmd.Text = "Palette Chart.."
        Me.PCShowCmd.UseVisualStyleBackColor = False
        '
        '_EffUD_0
        '
        Me._EffUD_0.Hexadecimal = True
        Me._EffUD_0.Location = New System.Drawing.Point(67, 62)
        Me._EffUD_0.Maximum = New Decimal(New Integer() {127, 0, 0, 0})
        Me._EffUD_0.Name = "_EffUD_0"
        Me._EffUD_0.Size = New System.Drawing.Size(45, 23)
        Me._EffUD_0.TabIndex = 2
        Me._EffUD_0.Tag = ""
        '
        '_EffUD_1
        '
        Me._EffUD_1.Hexadecimal = True
        Me._EffUD_1.Location = New System.Drawing.Point(195, 62)
        Me._EffUD_1.Maximum = New Decimal(New Integer() {127, 0, 0, 0})
        Me._EffUD_1.Name = "_EffUD_1"
        Me._EffUD_1.Size = New System.Drawing.Size(45, 23)
        Me._EffUD_1.TabIndex = 6
        Me._EffUD_1.Tag = ""
        '
        '_EffUD_2
        '
        Me._EffUD_2.Hexadecimal = True
        Me._EffUD_2.Location = New System.Drawing.Point(323, 62)
        Me._EffUD_2.Maximum = New Decimal(New Integer() {127, 0, 0, 0})
        Me._EffUD_2.Name = "_EffUD_2"
        Me._EffUD_2.Size = New System.Drawing.Size(45, 23)
        Me._EffUD_2.TabIndex = 8
        Me._EffUD_2.Tag = ""
        '
        '_EffUD_3
        '
        Me._EffUD_3.Hexadecimal = True
        Me._EffUD_3.Location = New System.Drawing.Point(451, 62)
        Me._EffUD_3.Maximum = New Decimal(New Integer() {127, 0, 0, 0})
        Me._EffUD_3.Name = "_EffUD_3"
        Me._EffUD_3.Size = New System.Drawing.Size(45, 23)
        Me._EffUD_3.TabIndex = 10
        Me._EffUD_3.Tag = ""
        '
        '_EddLab_0
        '
        Me._EddLab_0.BackColor = System.Drawing.SystemColors.Control
        Me._EddLab_0.Cursor = System.Windows.Forms.Cursors.Default
        Me._EddLab_0.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._EddLab_0.ForeColor = System.Drawing.SystemColors.ControlText
        Me._EddLab_0.Location = New System.Drawing.Point(4, 64)
        Me._EddLab_0.Name = "_EddLab_0"
        Me._EddLab_0.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._EddLab_0.Size = New System.Drawing.Size(65, 17)
        Me._EddLab_0.TabIndex = 4
        Me._EddLab_0.Text = "Effect 0:"
        '
        'tabPalWeapon
        '
        Me.tabPalWeapon.Controls.Add(Me.TabPage1)
        Me.tabPalWeapon.Controls.Add(Me.TabPage2)
        Me.tabPalWeapon.Location = New System.Drawing.Point(8, 156)
        Me.tabPalWeapon.Name = "tabPalWeapon"
        Me.tabPalWeapon.SelectedIndex = 0
        Me.tabPalWeapon.Size = New System.Drawing.Size(340, 150)
        Me.tabPalWeapon.TabIndex = 76
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.gbxPalAnim)
        Me.TabPage1.Location = New System.Drawing.Point(4, 25)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(332, 121)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Pal Animation"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'gbxPalAnim
        '
        Me.gbxPalAnim.Controls.Add(Me.PieceUD)
        Me.gbxPalAnim.Controls.Add(Me.DelayUD)
        Me.gbxPalAnim.Controls.Add(Me.FrameSelect)
        Me.gbxPalAnim.Controls.Add(Me.Label1)
        Me.gbxPalAnim.Controls.Add(Me._PAColPic_2)
        Me.gbxPalAnim.Controls.Add(Me._PAColPic_1)
        Me.gbxPalAnim.Controls.Add(Me._PAColPic_0)
        Me.gbxPalAnim.Controls.Add(Me.DstColUD)
        Me.gbxPalAnim.Controls.Add(Me._PAColTB_2)
        Me.gbxPalAnim.Controls.Add(Me._PAColTB_1)
        Me.gbxPalAnim.Controls.Add(Me._PAColTB_0)
        Me.gbxPalAnim.Controls.Add(Me.FramesUD)
        Me.gbxPalAnim.Controls.Add(Me.PAIDUD)
        Me.gbxPalAnim.Controls.Add(Me.DstColLab)
        Me.gbxPalAnim.Controls.Add(Me.Label6)
        Me.gbxPalAnim.Controls.Add(Me.Label5)
        Me.gbxPalAnim.Controls.Add(Me.Label4)
        Me.gbxPalAnim.Location = New System.Drawing.Point(2, 1)
        Me.gbxPalAnim.Name = "gbxPalAnim"
        Me.gbxPalAnim.Size = New System.Drawing.Size(329, 121)
        Me.gbxPalAnim.TabIndex = 0
        Me.gbxPalAnim.TabStop = False
        Me.gbxPalAnim.Text = "Palette Animation Editor"
        '
        'PieceUD
        '
        Me.PieceUD.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
        Me.PieceUD.Hexadecimal = True
        Me.PieceUD.Location = New System.Drawing.Point(282, 45)
        Me.PieceUD.Name = "PieceUD"
        Me.PieceUD.Size = New System.Drawing.Size(45, 25)
        Me.PieceUD.TabIndex = 54
        Me.PieceUD.Tag = ""
        '
        'DelayUD
        '
        Me.DelayUD.Hexadecimal = True
        Me.DelayUD.Location = New System.Drawing.Point(97, 45)
        Me.DelayUD.Maximum = New Decimal(New Integer() {255, 0, 0, 0})
        Me.DelayUD.Name = "DelayUD"
        Me.DelayUD.Size = New System.Drawing.Size(45, 23)
        Me.DelayUD.TabIndex = 42
        Me.DelayUD.Tag = ""
        Me.ToolTip1.SetToolTip(Me.DelayUD, "Number of frames to delay each animation cycle")
        '
        'FrameSelect
        '
        Me.FrameSelect.Cursor = System.Windows.Forms.Cursors.Default
        Me.FrameSelect.LargeChange = 1
        Me.FrameSelect.Location = New System.Drawing.Point(154, 26)
        Me.FrameSelect.Maximum = 32767
        Me.FrameSelect.Name = "FrameSelect"
        Me.FrameSelect.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.FrameSelect.Size = New System.Drawing.Size(169, 12)
        Me.FrameSelect.TabIndex = 53
        Me.FrameSelect.TabStop = True
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.SystemColors.Control
        Me.Label1.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label1.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label1.Location = New System.Drawing.Point(167, 45)
        Me.Label1.Name = "Label1"
        Me.Label1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label1.Size = New System.Drawing.Size(146, 21)
        Me.Label1.TabIndex = 52
        Me.Label1.Text = "Source Palette Piece:"
        '
        '_PAColPic_2
        '
        Me._PAColPic_2.BackColor = System.Drawing.Color.FromArgb(CType(CType(15, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me._PAColPic_2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me._PAColPic_2.Cursor = System.Windows.Forms.Cursors.Default
        Me._PAColPic_2.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._PAColPic_2.ForeColor = System.Drawing.SystemColors.ControlText
        Me._PAColPic_2.Location = New System.Drawing.Point(226, 69)
        Me._PAColPic_2.Name = "_PAColPic_2"
        Me._PAColPic_2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._PAColPic_2.Size = New System.Drawing.Size(33, 25)
        Me._PAColPic_2.TabIndex = 51
        Me._PAColPic_2.TabStop = False
        '
        '_PAColPic_1
        '
        Me._PAColPic_1.BackColor = System.Drawing.Color.FromArgb(CType(CType(15, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me._PAColPic_1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me._PAColPic_1.Cursor = System.Windows.Forms.Cursors.Default
        Me._PAColPic_1.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._PAColPic_1.ForeColor = System.Drawing.SystemColors.ControlText
        Me._PAColPic_1.Location = New System.Drawing.Point(194, 69)
        Me._PAColPic_1.Name = "_PAColPic_1"
        Me._PAColPic_1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._PAColPic_1.Size = New System.Drawing.Size(33, 25)
        Me._PAColPic_1.TabIndex = 50
        Me._PAColPic_1.TabStop = False
        '
        '_PAColPic_0
        '
        Me._PAColPic_0.BackColor = System.Drawing.Color.FromArgb(CType(CType(15, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me._PAColPic_0.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me._PAColPic_0.Cursor = System.Windows.Forms.Cursors.Default
        Me._PAColPic_0.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._PAColPic_0.ForeColor = System.Drawing.SystemColors.ControlText
        Me._PAColPic_0.Location = New System.Drawing.Point(162, 69)
        Me._PAColPic_0.Name = "_PAColPic_0"
        Me._PAColPic_0.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._PAColPic_0.Size = New System.Drawing.Size(33, 25)
        Me._PAColPic_0.TabIndex = 49
        Me._PAColPic_0.TabStop = False
        '
        'DstColUD
        '
        Me.DstColUD.Hexadecimal = True
        Me.DstColUD.Location = New System.Drawing.Point(97, 93)
        Me.DstColUD.Maximum = New Decimal(New Integer() {255, 0, 0, 0})
        Me.DstColUD.Name = "DstColUD"
        Me.DstColUD.Size = New System.Drawing.Size(45, 23)
        Me.DstColUD.TabIndex = 47
        Me.DstColUD.Tag = ""
        Me.ToolTip1.SetToolTip(Me.DstColUD, "Location of pallete to begin the palette animation (0-F)")
        Me.DstColUD.Visible = False
        '
        '_PAColTB_2
        '
        Me._PAColTB_2.AcceptsReturn = True
        Me._PAColTB_2.BackColor = System.Drawing.SystemColors.Window
        Me._PAColTB_2.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._PAColTB_2.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._PAColTB_2.ForeColor = System.Drawing.SystemColors.WindowText
        Me._PAColTB_2.Location = New System.Drawing.Point(226, 93)
        Me._PAColTB_2.MaxLength = 0
        Me._PAColTB_2.Name = "_PAColTB_2"
        Me._PAColTB_2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._PAColTB_2.Size = New System.Drawing.Size(33, 23)
        Me._PAColTB_2.TabIndex = 46
        '
        '_PAColTB_1
        '
        Me._PAColTB_1.AcceptsReturn = True
        Me._PAColTB_1.BackColor = System.Drawing.SystemColors.Window
        Me._PAColTB_1.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._PAColTB_1.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._PAColTB_1.ForeColor = System.Drawing.SystemColors.WindowText
        Me._PAColTB_1.Location = New System.Drawing.Point(194, 93)
        Me._PAColTB_1.MaxLength = 0
        Me._PAColTB_1.Name = "_PAColTB_1"
        Me._PAColTB_1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._PAColTB_1.Size = New System.Drawing.Size(33, 23)
        Me._PAColTB_1.TabIndex = 45
        '
        '_PAColTB_0
        '
        Me._PAColTB_0.AcceptsReturn = True
        Me._PAColTB_0.BackColor = System.Drawing.SystemColors.Window
        Me._PAColTB_0.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._PAColTB_0.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._PAColTB_0.ForeColor = System.Drawing.SystemColors.WindowText
        Me._PAColTB_0.Location = New System.Drawing.Point(162, 93)
        Me._PAColTB_0.MaxLength = 0
        Me._PAColTB_0.Name = "_PAColTB_0"
        Me._PAColTB_0.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._PAColTB_0.Size = New System.Drawing.Size(33, 23)
        Me._PAColTB_0.TabIndex = 44
        '
        'FramesUD
        '
        Me.FramesUD.Hexadecimal = True
        Me.FramesUD.Location = New System.Drawing.Point(97, 69)
        Me.FramesUD.Maximum = New Decimal(New Integer() {255, 0, 0, 0})
        Me.FramesUD.Name = "FramesUD"
        Me.FramesUD.Size = New System.Drawing.Size(45, 23)
        Me.FramesUD.TabIndex = 43
        Me.FramesUD.Tag = ""
        Me.ToolTip1.SetToolTip(Me.FramesUD, "Number of frames current pallete animation uses (Cycles)")
        '
        'PAIDUD
        '
        Me.PAIDUD.Hexadecimal = True
        Me.PAIDUD.Location = New System.Drawing.Point(29, 21)
        Me.PAIDUD.Maximum = New Decimal(New Integer() {127, 0, 0, 0})
        Me.PAIDUD.Name = "PAIDUD"
        Me.PAIDUD.Size = New System.Drawing.Size(45, 23)
        Me.PAIDUD.TabIndex = 39
        '
        'DstColLab
        '
        Me.DstColLab.BackColor = System.Drawing.SystemColors.Control
        Me.DstColLab.Cursor = System.Windows.Forms.Cursors.Default
        Me.DstColLab.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DstColLab.ForeColor = System.Drawing.SystemColors.ControlText
        Me.DstColLab.Location = New System.Drawing.Point(7, 93)
        Me.DstColLab.Name = "DstColLab"
        Me.DstColLab.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.DstColLab.Size = New System.Drawing.Size(84, 17)
        Me.DstColLab.TabIndex = 48
        Me.DstColLab.Text = "Dst. Color:"
        Me.DstColLab.Visible = False
        '
        'Label6
        '
        Me.Label6.BackColor = System.Drawing.SystemColors.Control
        Me.Label6.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label6.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label6.Location = New System.Drawing.Point(7, 69)
        Me.Label6.Name = "Label6"
        Me.Label6.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label6.Size = New System.Drawing.Size(98, 23)
        Me.Label6.TabIndex = 41
        Me.Label6.Text = "# of Frames:"
        '
        'Label5
        '
        Me.Label5.BackColor = System.Drawing.SystemColors.Control
        Me.Label5.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label5.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label5.Location = New System.Drawing.Point(7, 45)
        Me.Label5.Name = "Label5"
        Me.Label5.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label5.Size = New System.Drawing.Size(49, 23)
        Me.Label5.TabIndex = 40
        Me.Label5.Text = "Delay:"
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.SystemColors.Control
        Me.Label4.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label4.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label4.Location = New System.Drawing.Point(5, 21)
        Me.Label4.Name = "Label4"
        Me.Label4.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label4.Size = New System.Drawing.Size(49, 17)
        Me.Label4.TabIndex = 38
        Me.Label4.Text = "ID:"
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.gbxWeaponSelected)
        Me.TabPage2.Location = New System.Drawing.Point(4, 25)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(332, 121)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Weapon Menu"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'gbxWeaponSelected
        '
        Me.gbxWeaponSelected.Controls.Add(Me.Preview)
        Me.gbxWeaponSelected.Controls.Add(Me.Label2)
        Me.gbxWeaponSelected.Controls.Add(Me.WeaponIcon)
        Me.gbxWeaponSelected.Controls.Add(Me.PrevWP_SprBtn)
        Me.gbxWeaponSelected.Controls.Add(Me.PrevSprTB)
        Me.gbxWeaponSelected.Controls.Add(Me.WeaponList)
        Me.gbxWeaponSelected.Location = New System.Drawing.Point(2, 1)
        Me.gbxWeaponSelected.Name = "gbxWeaponSelected"
        Me.gbxWeaponSelected.Size = New System.Drawing.Size(329, 121)
        Me.gbxWeaponSelected.TabIndex = 1
        Me.gbxWeaponSelected.TabStop = False
        Me.gbxWeaponSelected.Text = "Weapon Selected"
        '
        'Preview
        '
        Me.Preview.BackColor = System.Drawing.SystemColors.Control
        Me.Preview.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Preview.Cursor = System.Windows.Forms.Cursors.Default
        Me.Preview.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Preview.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Preview.Location = New System.Drawing.Point(194, 29)
        Me.Preview.Name = "Preview"
        Me.Preview.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Preview.Size = New System.Drawing.Size(40, 40)
        Me.Preview.TabIndex = 41
        Me.Preview.TabStop = False
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.SystemColors.Control
        Me.Label2.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label2.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label2.Location = New System.Drawing.Point(189, 12)
        Me.Label2.Name = "Label2"
        Me.Label2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label2.Size = New System.Drawing.Size(70, 23)
        Me.Label2.TabIndex = 78
        Me.Label2.Text = "Preview:"
        '
        'WeaponIcon
        '
        Me.WeaponIcon.Cursor = System.Windows.Forms.Cursors.Default
        Me.WeaponIcon.Location = New System.Drawing.Point(266, 74)
        Me.WeaponIcon.Name = "WeaponIcon"
        Me.WeaponIcon.Size = New System.Drawing.Size(32, 32)
        Me.WeaponIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.WeaponIcon.TabIndex = 77
        Me.WeaponIcon.TabStop = False
        '
        'PrevWP_SprBtn
        '
        Me.PrevWP_SprBtn.BackColor = System.Drawing.SystemColors.Control
        Me.PrevWP_SprBtn.Cursor = System.Windows.Forms.Cursors.Default
        Me.PrevWP_SprBtn.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.PrevWP_SprBtn.ForeColor = System.Drawing.SystemColors.ControlText
        Me.PrevWP_SprBtn.Location = New System.Drawing.Point(15, 40)
        Me.PrevWP_SprBtn.Name = "PrevWP_SprBtn"
        Me.PrevWP_SprBtn.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.PrevWP_SprBtn.Size = New System.Drawing.Size(121, 26)
        Me.PrevWP_SprBtn.TabIndex = 76
        Me.PrevWP_SprBtn.Text = "Change preview Spr:"
        Me.PrevWP_SprBtn.UseVisualStyleBackColor = False
        '
        'PrevSprTB
        '
        Me.PrevSprTB.AcceptsReturn = True
        Me.PrevSprTB.BackColor = System.Drawing.SystemColors.Window
        Me.PrevSprTB.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.PrevSprTB.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.PrevSprTB.ForeColor = System.Drawing.SystemColors.WindowText
        Me.PrevSprTB.Location = New System.Drawing.Point(141, 40)
        Me.PrevSprTB.MaxLength = 0
        Me.PrevSprTB.Name = "PrevSprTB"
        Me.PrevSprTB.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.PrevSprTB.Size = New System.Drawing.Size(41, 23)
        Me.PrevSprTB.TabIndex = 75
        Me.PrevSprTB.Text = "1"
        '
        'WeaponList
        '
        Me.WeaponList.BackColor = System.Drawing.SystemColors.Window
        Me.WeaponList.Cursor = System.Windows.Forms.Cursors.Default
        Me.WeaponList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.WeaponList.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.WeaponList.ForeColor = System.Drawing.SystemColors.WindowText
        Me.WeaponList.Location = New System.Drawing.Point(7, 82)
        Me.WeaponList.Name = "WeaponList"
        Me.WeaponList.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.WeaponList.Size = New System.Drawing.Size(141, 24)
        Me.WeaponList.TabIndex = 40
        '
        'Text5
        '
        Me.Text5.AcceptsReturn = True
        Me.Text5.BackColor = System.Drawing.SystemColors.Window
        Me.Text5.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.Text5.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Text5.ForeColor = System.Drawing.SystemColors.WindowText
        Me.Text5.Location = New System.Drawing.Point(450, 284)
        Me.Text5.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.Text5.MaxLength = 0
        Me.Text5.Name = "Text5"
        Me.Text5.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Text5.Size = New System.Drawing.Size(33, 23)
        Me.Text5.TabIndex = 80
        Me.Text5.Text = "0"
        Me.ToolTip1.SetToolTip(Me.Text5, "For Mega Man 6: Load a Palette Id. (they are used for all palettes in the game). " &
        "Once loaded, it can be edited in the Palette Editor. It will not modify the leve" &
        "l.")
        Me.Text5.Visible = False
        '
        'PalPic
        '
        Me.PalPic.BackColor = System.Drawing.SystemColors.Control
        Me.PalPic.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.PalPic.Cursor = System.Windows.Forms.Cursors.Default
        Me.PalPic.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.PalPic.ForeColor = System.Drawing.SystemColors.ControlText
        Me.PalPic.Location = New System.Drawing.Point(0, 0)
        Me.PalPic.Name = "PalPic"
        Me.PalPic.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.PalPic.Size = New System.Drawing.Size(518, 38)
        Me.PalPic.TabIndex = 0
        Me.PalPic.TabStop = False
        '
        '_EddLab_1
        '
        Me._EddLab_1.BackColor = System.Drawing.SystemColors.Control
        Me._EddLab_1.Cursor = System.Windows.Forms.Cursors.Default
        Me._EddLab_1.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._EddLab_1.ForeColor = System.Drawing.SystemColors.ControlText
        Me._EddLab_1.Location = New System.Drawing.Point(132, 64)
        Me._EddLab_1.Name = "_EddLab_1"
        Me._EddLab_1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._EddLab_1.Size = New System.Drawing.Size(65, 17)
        Me._EddLab_1.TabIndex = 77
        Me._EddLab_1.Text = "Effect 1:"
        '
        '_EddLab_2
        '
        Me._EddLab_2.BackColor = System.Drawing.SystemColors.Control
        Me._EddLab_2.Cursor = System.Windows.Forms.Cursors.Default
        Me._EddLab_2.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._EddLab_2.ForeColor = System.Drawing.SystemColors.ControlText
        Me._EddLab_2.Location = New System.Drawing.Point(260, 64)
        Me._EddLab_2.Name = "_EddLab_2"
        Me._EddLab_2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._EddLab_2.Size = New System.Drawing.Size(65, 17)
        Me._EddLab_2.TabIndex = 78
        Me._EddLab_2.Text = "Effect 2:"
        '
        '_EddLab_3
        '
        Me._EddLab_3.BackColor = System.Drawing.SystemColors.Control
        Me._EddLab_3.Cursor = System.Windows.Forms.Cursors.Default
        Me._EddLab_3.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._EddLab_3.ForeColor = System.Drawing.SystemColors.ControlText
        Me._EddLab_3.Location = New System.Drawing.Point(388, 64)
        Me._EddLab_3.Name = "_EddLab_3"
        Me._EddLab_3.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._EddLab_3.Size = New System.Drawing.Size(65, 17)
        Me._EddLab_3.TabIndex = 79
        Me._EddLab_3.Text = "Effect 3:"
        '
        'Command6
        '
        Me.Command6.BackColor = System.Drawing.SystemColors.Control
        Me.Command6.Cursor = System.Windows.Forms.Cursors.Default
        Me.Command6.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Command6.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Command6.Location = New System.Drawing.Point(482, 284)
        Me.Command6.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.Command6.Name = "Command6"
        Me.Command6.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Command6.Size = New System.Drawing.Size(32, 17)
        Me.Command6.TabIndex = 81
        Me.Command6.Text = "Do"
        Me.Command6.UseVisualStyleBackColor = False
        Me.Command6.Visible = False
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.SystemColors.Control
        Me.Label3.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label3.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label3.Location = New System.Drawing.Point(351, 284)
        Me.Label3.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label3.Size = New System.Drawing.Size(145, 19)
        Me.Label3.TabIndex = 82
        Me.Label3.Text = "Force MM6 Palette:"
        Me.Label3.Visible = False
        '
        'PalEd
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), System.Drawing.Image)
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.ClientSize = New System.Drawing.Size(518, 310)
        Me.Controls.Add(Me.Command6)
        Me.Controls.Add(Me.Text5)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me._EffUD_0)
        Me.Controls.Add(Me._EffUD_1)
        Me.Controls.Add(Me._EffUD_2)
        Me.Controls.Add(Me._EffUD_3)
        Me.Controls.Add(Me._EddLab_3)
        Me.Controls.Add(Me._EddLab_2)
        Me.Controls.Add(Me._EddLab_1)
        Me.Controls.Add(Me.tabPalWeapon)
        Me.Controls.Add(Me.PalSetChangeFrame)
        Me.Controls.Add(Me._AColTB_15)
        Me.Controls.Add(Me._AColTB_14)
        Me.Controls.Add(Me._AColTB_13)
        Me.Controls.Add(Me._AColTB_12)
        Me.Controls.Add(Me._AColTB_11)
        Me.Controls.Add(Me._AColTB_10)
        Me.Controls.Add(Me._AColTB_9)
        Me.Controls.Add(Me._AColTB_8)
        Me.Controls.Add(Me._AColTB_7)
        Me.Controls.Add(Me._AColTB_6)
        Me.Controls.Add(Me._AColTB_5)
        Me.Controls.Add(Me._AColTB_4)
        Me.Controls.Add(Me._AColTB_3)
        Me.Controls.Add(Me._AColTB_2)
        Me.Controls.Add(Me._AColTB_1)
        Me.Controls.Add(Me._AColTB_0)
        Me.Controls.Add(Me._ColTB_15)
        Me.Controls.Add(Me._ColTB_14)
        Me.Controls.Add(Me._ColTB_13)
        Me.Controls.Add(Me._ColTB_12)
        Me.Controls.Add(Me._ColTB_11)
        Me.Controls.Add(Me._ColTB_10)
        Me.Controls.Add(Me._ColTB_9)
        Me.Controls.Add(Me._ColTB_8)
        Me.Controls.Add(Me._ColTB_7)
        Me.Controls.Add(Me._ColTB_6)
        Me.Controls.Add(Me._ColTB_5)
        Me.Controls.Add(Me._ColTB_4)
        Me.Controls.Add(Me._ColTB_3)
        Me.Controls.Add(Me._ColTB_2)
        Me.Controls.Add(Me._ColTB_1)
        Me.Controls.Add(Me._ColTB_0)
        Me.Controls.Add(Me.PalPic2)
        Me.Controls.Add(Me._EffSw_3)
        Me.Controls.Add(Me._EffSw_2)
        Me.Controls.Add(Me._EffSw_1)
        Me.Controls.Add(Me._EffSw_0)
        Me.Controls.Add(Me.PCShowCmd)
        Me.Controls.Add(Me.PalPic)
        Me.Controls.Add(Me._EddLab_0)
        Me.Cursor = System.Windows.Forms.Cursors.Default
        Me.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.Location = New System.Drawing.Point(3, 28)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "PalEd"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Text = " Palette Editor"
        Me.PalSetChangeFrame.ResumeLayout(False)
        CType(Me.PalSetUD, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PalPic2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me._EffUD_0, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me._EffUD_1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me._EffUD_2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me._EffUD_3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tabPalWeapon.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.gbxPalAnim.ResumeLayout(False)
        Me.gbxPalAnim.PerformLayout()
        CType(Me.PieceUD, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DelayUD, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me._PAColPic_2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me._PAColPic_1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me._PAColPic_0, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DstColUD, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.FramesUD, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PAIDUD, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage2.ResumeLayout(False)
        Me.gbxWeaponSelected.ResumeLayout(False)
        Me.gbxWeaponSelected.PerformLayout()
        CType(Me.Preview, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.WeaponIcon, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PalPic, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents TabPage1 As TabPage
    Friend WithEvents TabPage2 As TabPage
    Friend WithEvents tabPalWeapon As TabControl
    Public WithEvents _PalSetOpt_1 As RadioButton
    Public WithEvents _PalSetOpt_0 As RadioButton
    Public WithEvents PalSetUD As NumericUpDown
    Friend WithEvents ToolTip1 As ToolTip
    Public WithEvents PalPic As PictureBox
    Public WithEvents _EddLab_1 As Label
    Public WithEvents _EddLab_2 As Label
    Public WithEvents _EddLab_3 As Label
    Friend WithEvents gbxPalAnim As GroupBox
    Friend WithEvents gbxWeaponSelected As GroupBox
    Public WithEvents Preview As PictureBox
    Public WithEvents WeaponList As ComboBox
    Public WithEvents Label1 As Label
    Public WithEvents _PAColPic_2 As PictureBox
    Public WithEvents _PAColPic_1 As PictureBox
    Public WithEvents _PAColPic_0 As PictureBox
    Public WithEvents DstColUD As NumericUpDown
    Public WithEvents _PAColTB_2 As TextBox
    Public WithEvents _PAColTB_1 As TextBox
    Public WithEvents _PAColTB_0 As TextBox
    Public WithEvents FramesUD As NumericUpDown
    Public WithEvents DelayUD As NumericUpDown
    Public WithEvents PAIDUD As NumericUpDown
    Public WithEvents DstColLab As Label
    Public WithEvents Label6 As Label
    Public WithEvents Label5 As Label
    Public WithEvents Label4 As Label
    Public WithEvents PrevWP_SprBtn As Button
    Public WithEvents PrevSprTB As TextBox
    Public WithEvents PieceUD As NumericUpDown
    Public WithEvents FrameSelect As HScrollBar
    Public WithEvents WeaponIcon As PictureBox
    Public WithEvents Label2 As Label
    Public WithEvents Command6 As Button
    Public WithEvents Text5 As TextBox
    Public WithEvents Label3 As Label
#End Region
End Class