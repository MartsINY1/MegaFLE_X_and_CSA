<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> Partial Class MiscEd
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
	Public WithEvents _ScCHRUD_1 As System.Windows.Forms.NumericUpDown
    Public WithEvents _ScCHRUD_0 As System.Windows.Forms.NumericUpDown
    Public WithEvents GlIdUD As System.Windows.Forms.NumericUpDown
    Public WithEvents _ScCHRLab_1 As System.Windows.Forms.Label
    Public WithEvents _ScCHRLab_0 As System.Windows.Forms.Label
    Public WithEvents GlIdLabel As System.Windows.Forms.Label
    Public WithEvents SceneFrame As System.Windows.Forms.GroupBox
    Public WithEvents MuPDisCheck As System.Windows.Forms.CheckBox
    Public WithEvents _MuPUD_0 As System.Windows.Forms.NumericUpDown
    Public WithEvents _MuPUD_1 As System.Windows.Forms.NumericUpDown
    Public WithEvents _MuPUD_2 As System.Windows.Forms.NumericUpDown
    Public WithEvents _MuPUD_3 As System.Windows.Forms.NumericUpDown
    Public WithEvents MuPIDUD As System.Windows.Forms.NumericUpDown
    Public WithEvents MuPDTypeLab As System.Windows.Forms.Label
    Public WithEvents _MuPLab_1 As System.Windows.Forms.Label
    Public WithEvents _MuPLab_0 As System.Windows.Forms.Label
    Public WithEvents MuPFrame As System.Windows.Forms.GroupBox
    Public WithEvents SBDCombo As System.Windows.Forms.ComboBox
    Public WithEvents _MPCheckScreenUD_1 As System.Windows.Forms.NumericUpDown
    Public WithEvents _MPUD_4 As System.Windows.Forms.NumericUpDown
    Public WithEvents _MPUD_5 As System.Windows.Forms.NumericUpDown
    Public WithEvents _MPUD_6 As System.Windows.Forms.NumericUpDown
    Public WithEvents _MPUD_7 As System.Windows.Forms.NumericUpDown
    Public WithEvents Line3 As System.Windows.Forms.Label
    Public WithEvents BPLab4 As System.Windows.Forms.Label
    Public WithEvents BPLab3 As System.Windows.Forms.Label
    Public WithEvents Label7 As System.Windows.Forms.Label
    Public WithEvents Label6 As System.Windows.Forms.Label
    Public WithEvents BPLab2 As System.Windows.Forms.Label
    Public WithEvents BPFrame As System.Windows.Forms.GroupBox
    Public WithEvents _MPCheckScreenUD_0 As System.Windows.Forms.NumericUpDown
    Public WithEvents _MPUD_0 As System.Windows.Forms.NumericUpDown
    Public WithEvents _MPUD_1 As System.Windows.Forms.NumericUpDown
    Public WithEvents _MPUD_2 As System.Windows.Forms.NumericUpDown
    Public WithEvents _MPUD_3 As System.Windows.Forms.NumericUpDown
    Public WithEvents Line2 As System.Windows.Forms.Label
    Public WithEvents MPLab4 As System.Windows.Forms.Label
    Public WithEvents MPLab3 As System.Windows.Forms.Label
    Public WithEvents MPLab2 As System.Windows.Forms.Label
    Public WithEvents Label3 As System.Windows.Forms.Label
    Public WithEvents Label2 As System.Windows.Forms.Label
    Public WithEvents MPFrame As System.Windows.Forms.GroupBox
    Public WithEvents MusicCombo As System.Windows.Forms.ComboBox
    Public WithEvents MusicUD As System.Windows.Forms.NumericUpDown
    Public WithEvents SBDUD As System.Windows.Forms.NumericUpDown
    Public WithEvents Line1 As System.Windows.Forms.Label
    Public WithEvents CurLevLab As System.Windows.Forms.Label
    Public WithEvents SBDLab As System.Windows.Forms.Label
    Public WithEvents MusicLabel As System.Windows.Forms.Label
    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MiscEd))
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.MusicCombo = New System.Windows.Forms.ComboBox()
        Me.SceneFrame = New System.Windows.Forms.GroupBox()
        Me._ScCHRUD_1 = New System.Windows.Forms.NumericUpDown()
        Me._ScCHRUD_0 = New System.Windows.Forms.NumericUpDown()
        Me.GlIdUD = New System.Windows.Forms.NumericUpDown()
        Me._ScCHRLab_1 = New System.Windows.Forms.Label()
        Me._ScCHRLab_0 = New System.Windows.Forms.Label()
        Me.GlIdLabel = New System.Windows.Forms.Label()
        Me.MuPFrame = New System.Windows.Forms.GroupBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.MuPDisCheck = New System.Windows.Forms.CheckBox()
        Me._MuPUD_0 = New System.Windows.Forms.NumericUpDown()
        Me._MuPUD_1 = New System.Windows.Forms.NumericUpDown()
        Me._MuPUD_2 = New System.Windows.Forms.NumericUpDown()
        Me._MuPUD_3 = New System.Windows.Forms.NumericUpDown()
        Me.MuPIDUD = New System.Windows.Forms.NumericUpDown()
        Me.MuPDTypeLab = New System.Windows.Forms.Label()
        Me._MuPLab_1 = New System.Windows.Forms.Label()
        Me._MuPLab_0 = New System.Windows.Forms.Label()
        Me.SBDCombo = New System.Windows.Forms.ComboBox()
        Me.BPFrame = New System.Windows.Forms.GroupBox()
        Me._MPCheckScreenUD_1 = New System.Windows.Forms.NumericUpDown()
        Me._MPUD_4 = New System.Windows.Forms.NumericUpDown()
        Me._MPUD_5 = New System.Windows.Forms.NumericUpDown()
        Me._MPUD_6 = New System.Windows.Forms.NumericUpDown()
        Me._MPUD_7 = New System.Windows.Forms.NumericUpDown()
        Me.Line3 = New System.Windows.Forms.Label()
        Me.BPLab4 = New System.Windows.Forms.Label()
        Me.BPLab3 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.BPLab2 = New System.Windows.Forms.Label()
        Me.MPFrame = New System.Windows.Forms.GroupBox()
        Me._MPCheckScreenUD_0 = New System.Windows.Forms.NumericUpDown()
        Me._MPUD_0 = New System.Windows.Forms.NumericUpDown()
        Me._MPUD_1 = New System.Windows.Forms.NumericUpDown()
        Me._MPUD_2 = New System.Windows.Forms.NumericUpDown()
        Me._MPUD_3 = New System.Windows.Forms.NumericUpDown()
        Me.Line2 = New System.Windows.Forms.Label()
        Me.MPLab4 = New System.Windows.Forms.Label()
        Me.MPLab3 = New System.Windows.Forms.Label()
        Me.MPLab2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.MusicUD = New System.Windows.Forms.NumericUpDown()
        Me.SBDUD = New System.Windows.Forms.NumericUpDown()
        Me.Line1 = New System.Windows.Forms.Label()
        Me.CurLevLab = New System.Windows.Forms.Label()
        Me.SBDLab = New System.Windows.Forms.Label()
        Me.MusicLabel = New System.Windows.Forms.Label()
        Me.SceneFrame.SuspendLayout()
        CType(Me._ScCHRUD_1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me._ScCHRUD_0, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GlIdUD, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.MuPFrame.SuspendLayout()
        CType(Me._MuPUD_0, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me._MuPUD_1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me._MuPUD_2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me._MuPUD_3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.MuPIDUD, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.BPFrame.SuspendLayout()
        CType(Me._MPCheckScreenUD_1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me._MPUD_4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me._MPUD_5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me._MPUD_6, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me._MPUD_7, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.MPFrame.SuspendLayout()
        CType(Me._MPCheckScreenUD_0, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me._MPUD_0, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me._MPUD_1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me._MPUD_2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me._MPUD_3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.MusicUD, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SBDUD, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'MusicCombo
        '
        Me.MusicCombo.BackColor = System.Drawing.SystemColors.Window
        Me.MusicCombo.Cursor = System.Windows.Forms.Cursors.Default
        Me.MusicCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.MusicCombo.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MusicCombo.ForeColor = System.Drawing.SystemColors.WindowText
        Me.MusicCombo.Location = New System.Drawing.Point(80, 40)
        Me.MusicCombo.Name = "MusicCombo"
        Me.MusicCombo.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.MusicCombo.Size = New System.Drawing.Size(193, 22)
        Me.MusicCombo.TabIndex = 1
        Me.ToolTip1.SetToolTip(Me.MusicCombo, "Song to play during stage.")
        '
        'SceneFrame
        '
        Me.SceneFrame.BackColor = System.Drawing.SystemColors.Control
        Me.SceneFrame.Controls.Add(Me._ScCHRUD_1)
        Me.SceneFrame.Controls.Add(Me._ScCHRUD_0)
        Me.SceneFrame.Controls.Add(Me.GlIdUD)
        Me.SceneFrame.Controls.Add(Me._ScCHRLab_1)
        Me.SceneFrame.Controls.Add(Me._ScCHRLab_0)
        Me.SceneFrame.Controls.Add(Me.GlIdLabel)
        Me.SceneFrame.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SceneFrame.ForeColor = System.Drawing.SystemColors.ControlText
        Me.SceneFrame.Location = New System.Drawing.Point(378, 36)
        Me.SceneFrame.Name = "SceneFrame"
        Me.SceneFrame.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.SceneFrame.Size = New System.Drawing.Size(168, 89)
        Me.SceneFrame.TabIndex = 73
        Me.SceneFrame.TabStop = False
        Me.SceneFrame.Text = " Scene Screen "
        '
        '_ScCHRUD_1
        '
        Me._ScCHRUD_1.Hexadecimal = True
        Me._ScCHRUD_1.Location = New System.Drawing.Point(108, 64)
        Me._ScCHRUD_1.Maximum = New Decimal(New Integer() {255, 0, 0, 0})
        Me._ScCHRUD_1.Name = "_ScCHRUD_1"
        Me._ScCHRUD_1.Size = New System.Drawing.Size(45, 20)
        Me._ScCHRUD_1.TabIndex = 82
        '
        '_ScCHRUD_0
        '
        Me._ScCHRUD_0.Hexadecimal = True
        Me._ScCHRUD_0.Location = New System.Drawing.Point(108, 40)
        Me._ScCHRUD_0.Maximum = New Decimal(New Integer() {255, 0, 0, 0})
        Me._ScCHRUD_0.Name = "_ScCHRUD_0"
        Me._ScCHRUD_0.Size = New System.Drawing.Size(45, 20)
        Me._ScCHRUD_0.TabIndex = 79
        '
        'GlIdUD
        '
        Me.GlIdUD.Hexadecimal = True
        Me.GlIdUD.Location = New System.Drawing.Point(108, 16)
        Me.GlIdUD.Maximum = New Decimal(New Integer() {255, 0, 0, 0})
        Me.GlIdUD.Name = "GlIdUD"
        Me.GlIdUD.Size = New System.Drawing.Size(45, 20)
        Me.GlIdUD.TabIndex = 74
        '
        '_ScCHRLab_1
        '
        Me._ScCHRLab_1.BackColor = System.Drawing.SystemColors.Control
        Me._ScCHRLab_1.Cursor = System.Windows.Forms.Cursors.Default
        Me._ScCHRLab_1.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._ScCHRLab_1.ForeColor = System.Drawing.SystemColors.ControlText
        Me._ScCHRLab_1.Location = New System.Drawing.Point(8, 64)
        Me._ScCHRLab_1.Name = "_ScCHRLab_1"
        Me._ScCHRLab_1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._ScCHRLab_1.Size = New System.Drawing.Size(103, 19)
        Me._ScCHRLab_1.TabIndex = 80
        Me._ScCHRLab_1.Text = "BG CHR Bank 1:"
        '
        '_ScCHRLab_0
        '
        Me._ScCHRLab_0.BackColor = System.Drawing.SystemColors.Control
        Me._ScCHRLab_0.Cursor = System.Windows.Forms.Cursors.Default
        Me._ScCHRLab_0.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._ScCHRLab_0.ForeColor = System.Drawing.SystemColors.ControlText
        Me._ScCHRLab_0.Location = New System.Drawing.Point(8, 40)
        Me._ScCHRLab_0.Name = "_ScCHRLab_0"
        Me._ScCHRLab_0.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._ScCHRLab_0.Size = New System.Drawing.Size(89, 17)
        Me._ScCHRLab_0.TabIndex = 77
        Me._ScCHRLab_0.Text = "BG CHR Bank 0:"
        '
        'GlIdLabel
        '
        Me.GlIdLabel.BackColor = System.Drawing.SystemColors.Control
        Me.GlIdLabel.Cursor = System.Windows.Forms.Cursors.Default
        Me.GlIdLabel.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GlIdLabel.ForeColor = System.Drawing.SystemColors.ControlText
        Me.GlIdLabel.Location = New System.Drawing.Point(8, 16)
        Me.GlIdLabel.Name = "GlIdLabel"
        Me.GlIdLabel.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.GlIdLabel.Size = New System.Drawing.Size(103, 23)
        Me.GlIdLabel.TabIndex = 76
        Me.GlIdLabel.Text = "Graphics Load Id:"
        '
        'MuPFrame
        '
        Me.MuPFrame.BackColor = System.Drawing.SystemColors.Control
        Me.MuPFrame.Controls.Add(Me.Label4)
        Me.MuPFrame.Controls.Add(Me.Label1)
        Me.MuPFrame.Controls.Add(Me.MuPDisCheck)
        Me.MuPFrame.Controls.Add(Me._MuPUD_0)
        Me.MuPFrame.Controls.Add(Me._MuPUD_1)
        Me.MuPFrame.Controls.Add(Me._MuPUD_2)
        Me.MuPFrame.Controls.Add(Me._MuPUD_3)
        Me.MuPFrame.Controls.Add(Me.MuPIDUD)
        Me.MuPFrame.Controls.Add(Me.MuPDTypeLab)
        Me.MuPFrame.Controls.Add(Me._MuPLab_1)
        Me.MuPFrame.Controls.Add(Me._MuPLab_0)
        Me.MuPFrame.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MuPFrame.ForeColor = System.Drawing.SystemColors.ControlText
        Me.MuPFrame.Location = New System.Drawing.Point(376, 96)
        Me.MuPFrame.Name = "MuPFrame"
        Me.MuPFrame.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.MuPFrame.Size = New System.Drawing.Size(176, 153)
        Me.MuPFrame.TabIndex = 39
        Me.MuPFrame.TabStop = False
        Me.MuPFrame.Text = " Multi-Path:            "
        Me.MuPFrame.Visible = False
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.SystemColors.Control
        Me.Label4.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label4.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label4.Location = New System.Drawing.Point(5, 64)
        Me.Label4.Name = "Label4"
        Me.Label4.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label4.Size = New System.Drawing.Size(108, 24)
        Me.Label4.TabIndex = 55
        Me.Label4.Text = "Direction (A --> B):"
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.SystemColors.Control
        Me.Label1.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label1.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label1.Location = New System.Drawing.Point(10, 128)
        Me.Label1.Name = "Label1"
        Me.Label1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label1.Size = New System.Drawing.Size(103, 21)
        Me.Label1.TabIndex = 54
        Me.Label1.Text = "Scroll Map B:"
        '
        'MuPDisCheck
        '
        Me.MuPDisCheck.BackColor = System.Drawing.SystemColors.Control
        Me.MuPDisCheck.Cursor = System.Windows.Forms.Cursors.Default
        Me.MuPDisCheck.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MuPDisCheck.ForeColor = System.Drawing.SystemColors.ControlText
        Me.MuPDisCheck.Location = New System.Drawing.Point(8, 18)
        Me.MuPDisCheck.Name = "MuPDisCheck"
        Me.MuPDisCheck.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.MuPDisCheck.Size = New System.Drawing.Size(162, 19)
        Me.MuPDisCheck.TabIndex = 52
        Me.MuPDisCheck.Text = "Disable (and following IDs)"
        Me.MuPDisCheck.UseVisualStyleBackColor = False
        '
        '_MuPUD_0
        '
        Me._MuPUD_0.Hexadecimal = True
        Me._MuPUD_0.Location = New System.Drawing.Point(116, 40)
        Me._MuPUD_0.Maximum = New Decimal(New Integer() {255, 0, 0, 0})
        Me._MuPUD_0.Name = "_MuPUD_0"
        Me._MuPUD_0.Size = New System.Drawing.Size(45, 20)
        Me._MuPUD_0.TabIndex = 46
        '
        '_MuPUD_1
        '
        Me._MuPUD_1.Hexadecimal = True
        Me._MuPUD_1.Location = New System.Drawing.Point(116, 64)
        Me._MuPUD_1.Maximum = New Decimal(New Integer() {255, 0, 0, 0})
        Me._MuPUD_1.Name = "_MuPUD_1"
        Me._MuPUD_1.Size = New System.Drawing.Size(45, 20)
        Me._MuPUD_1.TabIndex = 47
        '
        '_MuPUD_2
        '
        Me._MuPUD_2.Hexadecimal = True
        Me._MuPUD_2.Location = New System.Drawing.Point(116, 104)
        Me._MuPUD_2.Maximum = New Decimal(New Integer() {255, 0, 0, 0})
        Me._MuPUD_2.Name = "_MuPUD_2"
        Me._MuPUD_2.Size = New System.Drawing.Size(45, 20)
        Me._MuPUD_2.TabIndex = 48
        '
        '_MuPUD_3
        '
        Me._MuPUD_3.Hexadecimal = True
        Me._MuPUD_3.Location = New System.Drawing.Point(116, 128)
        Me._MuPUD_3.Maximum = New Decimal(New Integer() {255, 0, 0, 0})
        Me._MuPUD_3.Name = "_MuPUD_3"
        Me._MuPUD_3.Size = New System.Drawing.Size(45, 20)
        Me._MuPUD_3.TabIndex = 49
        '
        'MuPIDUD
        '
        Me.MuPIDUD.Hexadecimal = True
        Me.MuPIDUD.Location = New System.Drawing.Point(84, 0)
        Me.MuPIDUD.Maximum = New Decimal(New Integer() {255, 0, 0, 0})
        Me.MuPIDUD.Name = "MuPIDUD"
        Me.MuPIDUD.Size = New System.Drawing.Size(45, 20)
        Me.MuPIDUD.TabIndex = 51
        '
        'MuPDTypeLab
        '
        Me.MuPDTypeLab.BackColor = System.Drawing.SystemColors.Control
        Me.MuPDTypeLab.Cursor = System.Windows.Forms.Cursors.Default
        Me.MuPDTypeLab.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MuPDTypeLab.ForeColor = System.Drawing.SystemColors.ControlText
        Me.MuPDTypeLab.Location = New System.Drawing.Point(16, 88)
        Me.MuPDTypeLab.Name = "MuPDTypeLab"
        Me.MuPDTypeLab.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.MuPDTypeLab.Size = New System.Drawing.Size(137, 17)
        Me.MuPDTypeLab.TabIndex = 53
        '
        '_MuPLab_1
        '
        Me._MuPLab_1.BackColor = System.Drawing.SystemColors.Control
        Me._MuPLab_1.Cursor = System.Windows.Forms.Cursors.Default
        Me._MuPLab_1.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._MuPLab_1.ForeColor = System.Drawing.SystemColors.ControlText
        Me._MuPLab_1.Location = New System.Drawing.Point(8, 104)
        Me._MuPLab_1.Name = "_MuPLab_1"
        Me._MuPLab_1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._MuPLab_1.Size = New System.Drawing.Size(105, 23)
        Me._MuPLab_1.TabIndex = 41
        Me._MuPLab_1.Text = "Screen Position B:"
        '
        '_MuPLab_0
        '
        Me._MuPLab_0.BackColor = System.Drawing.SystemColors.Control
        Me._MuPLab_0.Cursor = System.Windows.Forms.Cursors.Default
        Me._MuPLab_0.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._MuPLab_0.ForeColor = System.Drawing.SystemColors.ControlText
        Me._MuPLab_0.Location = New System.Drawing.Point(8, 40)
        Me._MuPLab_0.Name = "_MuPLab_0"
        Me._MuPLab_0.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._MuPLab_0.Size = New System.Drawing.Size(105, 23)
        Me._MuPLab_0.TabIndex = 40
        Me._MuPLab_0.Text = "Screen Position A:"
        '
        'SBDCombo
        '
        Me.SBDCombo.BackColor = System.Drawing.SystemColors.Window
        Me.SBDCombo.Cursor = System.Windows.Forms.Cursors.Default
        Me.SBDCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.SBDCombo.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SBDCombo.ForeColor = System.Drawing.SystemColors.WindowText
        Me.SBDCombo.Location = New System.Drawing.Point(80, 72)
        Me.SBDCombo.Name = "SBDCombo"
        Me.SBDCombo.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.SBDCombo.Size = New System.Drawing.Size(193, 22)
        Me.SBDCombo.TabIndex = 24
        Me.SBDCombo.Visible = False
        '
        'BPFrame
        '
        Me.BPFrame.BackColor = System.Drawing.SystemColors.Control
        Me.BPFrame.Controls.Add(Me._MPCheckScreenUD_1)
        Me.BPFrame.Controls.Add(Me._MPUD_4)
        Me.BPFrame.Controls.Add(Me._MPUD_5)
        Me.BPFrame.Controls.Add(Me._MPUD_6)
        Me.BPFrame.Controls.Add(Me._MPUD_7)
        Me.BPFrame.Controls.Add(Me.Line3)
        Me.BPFrame.Controls.Add(Me.BPLab4)
        Me.BPFrame.Controls.Add(Me.BPLab3)
        Me.BPFrame.Controls.Add(Me.Label7)
        Me.BPFrame.Controls.Add(Me.Label6)
        Me.BPFrame.Controls.Add(Me.BPLab2)
        Me.BPFrame.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BPFrame.ForeColor = System.Drawing.SystemColors.ControlText
        Me.BPFrame.Location = New System.Drawing.Point(192, 104)
        Me.BPFrame.Name = "BPFrame"
        Me.BPFrame.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.BPFrame.Size = New System.Drawing.Size(175, 145)
        Me.BPFrame.TabIndex = 12
        Me.BPFrame.TabStop = False
        Me.BPFrame.Text = "Level Boss-Point"
        Me.BPFrame.Visible = False
        '
        '_MPCheckScreenUD_1
        '
        Me._MPCheckScreenUD_1.Hexadecimal = True
        Me._MPCheckScreenUD_1.Location = New System.Drawing.Point(124, 16)
        Me._MPCheckScreenUD_1.Maximum = New Decimal(New Integer() {255, 0, 0, 0})
        Me._MPCheckScreenUD_1.Name = "_MPCheckScreenUD_1"
        Me._MPCheckScreenUD_1.Size = New System.Drawing.Size(45, 20)
        Me._MPCheckScreenUD_1.TabIndex = 58
        '
        '_MPUD_4
        '
        Me._MPUD_4.Hexadecimal = True
        Me._MPUD_4.Location = New System.Drawing.Point(124, 40)
        Me._MPUD_4.Maximum = New Decimal(New Integer() {255, 0, 0, 0})
        Me._MPUD_4.Name = "_MPUD_4"
        Me._MPUD_4.Size = New System.Drawing.Size(45, 20)
        Me._MPUD_4.TabIndex = 16
        '
        '_MPUD_5
        '
        Me._MPUD_5.Hexadecimal = True
        Me._MPUD_5.Location = New System.Drawing.Point(124, 64)
        Me._MPUD_5.Maximum = New Decimal(New Integer() {255, 0, 0, 0})
        Me._MPUD_5.Name = "_MPUD_5"
        Me._MPUD_5.Size = New System.Drawing.Size(45, 20)
        Me._MPUD_5.TabIndex = 17
        '
        '_MPUD_6
        '
        Me._MPUD_6.Hexadecimal = True
        Me._MPUD_6.Location = New System.Drawing.Point(124, 88)
        Me._MPUD_6.Maximum = New Decimal(New Integer() {255, 0, 0, 0})
        Me._MPUD_6.Name = "_MPUD_6"
        Me._MPUD_6.Size = New System.Drawing.Size(45, 20)
        Me._MPUD_6.TabIndex = 18
        '
        '_MPUD_7
        '
        Me._MPUD_7.Hexadecimal = True
        Me._MPUD_7.Location = New System.Drawing.Point(124, 112)
        Me._MPUD_7.Maximum = New Decimal(New Integer() {255, 0, 0, 0})
        Me._MPUD_7.Name = "_MPUD_7"
        Me._MPUD_7.Size = New System.Drawing.Size(45, 20)
        Me._MPUD_7.TabIndex = 33
        '
        'Line3
        '
        Me.Line3.BackColor = System.Drawing.SystemColors.WindowText
        Me.Line3.Location = New System.Drawing.Point(8, 36)
        Me.Line3.Name = "Line3"
        Me.Line3.Size = New System.Drawing.Size(152, 1)
        Me.Line3.TabIndex = 60
        '
        'BPLab4
        '
        Me.BPLab4.BackColor = System.Drawing.SystemColors.Control
        Me.BPLab4.Cursor = System.Windows.Forms.Cursors.Default
        Me.BPLab4.Enabled = False
        Me.BPLab4.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BPLab4.ForeColor = System.Drawing.SystemColors.ControlText
        Me.BPLab4.Location = New System.Drawing.Point(8, 16)
        Me.BPLab4.Name = "BPLab4"
        Me.BPLab4.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.BPLab4.Size = New System.Drawing.Size(120, 17)
        Me.BPLab4.TabIndex = 57
        Me.BPLab4.Text = "Happens by Screen:"
        '
        'BPLab3
        '
        Me.BPLab3.BackColor = System.Drawing.SystemColors.Control
        Me.BPLab3.Cursor = System.Windows.Forms.Cursors.Default
        Me.BPLab3.Enabled = False
        Me.BPLab3.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BPLab3.ForeColor = System.Drawing.SystemColors.ControlText
        Me.BPLab3.Location = New System.Drawing.Point(8, 112)
        Me.BPLab3.Name = "BPLab3"
        Me.BPLab3.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.BPLab3.Size = New System.Drawing.Size(120, 17)
        Me.BPLab3.TabIndex = 31
        Me.BPLab3.Text = "Palette Set:"
        '
        'Label7
        '
        Me.Label7.BackColor = System.Drawing.SystemColors.Control
        Me.Label7.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label7.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label7.Location = New System.Drawing.Point(8, 40)
        Me.Label7.Name = "Label7"
        Me.Label7.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label7.Size = New System.Drawing.Size(120, 17)
        Me.Label7.TabIndex = 21
        Me.Label7.Text = "Screen Position:"
        '
        'Label6
        '
        Me.Label6.BackColor = System.Drawing.SystemColors.Control
        Me.Label6.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label6.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label6.Location = New System.Drawing.Point(8, 64)
        Me.Label6.Name = "Label6"
        Me.Label6.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label6.Size = New System.Drawing.Size(120, 23)
        Me.Label6.TabIndex = 20
        Me.Label6.Text = "Scroll Map Data:"
        '
        'BPLab2
        '
        Me.BPLab2.BackColor = System.Drawing.SystemColors.Control
        Me.BPLab2.Cursor = System.Windows.Forms.Cursors.Default
        Me.BPLab2.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BPLab2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.BPLab2.Location = New System.Drawing.Point(8, 88)
        Me.BPLab2.Name = "BPLab2"
        Me.BPLab2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.BPLab2.Size = New System.Drawing.Size(120, 17)
        Me.BPLab2.TabIndex = 19
        Me.BPLab2.Text = "Graphics Set ID:"
        '
        'MPFrame
        '
        Me.MPFrame.BackColor = System.Drawing.SystemColors.Control
        Me.MPFrame.Controls.Add(Me._MPCheckScreenUD_0)
        Me.MPFrame.Controls.Add(Me._MPUD_0)
        Me.MPFrame.Controls.Add(Me._MPUD_1)
        Me.MPFrame.Controls.Add(Me._MPUD_2)
        Me.MPFrame.Controls.Add(Me._MPUD_3)
        Me.MPFrame.Controls.Add(Me.Line2)
        Me.MPFrame.Controls.Add(Me.MPLab4)
        Me.MPFrame.Controls.Add(Me.MPLab3)
        Me.MPFrame.Controls.Add(Me.MPLab2)
        Me.MPFrame.Controls.Add(Me.Label3)
        Me.MPFrame.Controls.Add(Me.Label2)
        Me.MPFrame.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MPFrame.ForeColor = System.Drawing.SystemColors.ControlText
        Me.MPFrame.Location = New System.Drawing.Point(8, 104)
        Me.MPFrame.Name = "MPFrame"
        Me.MPFrame.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.MPFrame.Size = New System.Drawing.Size(175, 145)
        Me.MPFrame.TabIndex = 2
        Me.MPFrame.TabStop = False
        Me.MPFrame.Text = "Level Mid-Point"
        Me.MPFrame.Visible = False
        '
        '_MPCheckScreenUD_0
        '
        Me._MPCheckScreenUD_0.Hexadecimal = True
        Me._MPCheckScreenUD_0.Location = New System.Drawing.Point(124, 16)
        Me._MPCheckScreenUD_0.Maximum = New Decimal(New Integer() {255, 0, 0, 0})
        Me._MPCheckScreenUD_0.Name = "_MPCheckScreenUD_0"
        Me._MPCheckScreenUD_0.Size = New System.Drawing.Size(45, 20)
        Me._MPCheckScreenUD_0.TabIndex = 56
        '
        '_MPUD_0
        '
        Me._MPUD_0.Hexadecimal = True
        Me._MPUD_0.Location = New System.Drawing.Point(124, 40)
        Me._MPUD_0.Maximum = New Decimal(New Integer() {255, 0, 0, 0})
        Me._MPUD_0.Name = "_MPUD_0"
        Me._MPUD_0.Size = New System.Drawing.Size(45, 20)
        Me._MPUD_0.TabIndex = 7
        '
        '_MPUD_1
        '
        Me._MPUD_1.Hexadecimal = True
        Me._MPUD_1.Location = New System.Drawing.Point(124, 64)
        Me._MPUD_1.Maximum = New Decimal(New Integer() {255, 0, 0, 0})
        Me._MPUD_1.Name = "_MPUD_1"
        Me._MPUD_1.Size = New System.Drawing.Size(45, 20)
        Me._MPUD_1.TabIndex = 9
        '
        '_MPUD_2
        '
        Me._MPUD_2.Hexadecimal = True
        Me._MPUD_2.Location = New System.Drawing.Point(124, 88)
        Me._MPUD_2.Maximum = New Decimal(New Integer() {255, 0, 0, 0})
        Me._MPUD_2.Name = "_MPUD_2"
        Me._MPUD_2.Size = New System.Drawing.Size(45, 20)
        Me._MPUD_2.TabIndex = 11
        '
        '_MPUD_3
        '
        Me._MPUD_3.Hexadecimal = True
        Me._MPUD_3.Location = New System.Drawing.Point(124, 112)
        Me._MPUD_3.Maximum = New Decimal(New Integer() {255, 0, 0, 0})
        Me._MPUD_3.Name = "_MPUD_3"
        Me._MPUD_3.Size = New System.Drawing.Size(45, 20)
        Me._MPUD_3.TabIndex = 30
        '
        'Line2
        '
        Me.Line2.BackColor = System.Drawing.SystemColors.WindowText
        Me.Line2.Location = New System.Drawing.Point(8, 36)
        Me.Line2.Name = "Line2"
        Me.Line2.Size = New System.Drawing.Size(152, 1)
        Me.Line2.TabIndex = 57
        '
        'MPLab4
        '
        Me.MPLab4.BackColor = System.Drawing.SystemColors.Control
        Me.MPLab4.Cursor = System.Windows.Forms.Cursors.Default
        Me.MPLab4.Enabled = False
        Me.MPLab4.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MPLab4.ForeColor = System.Drawing.SystemColors.ControlText
        Me.MPLab4.Location = New System.Drawing.Point(8, 16)
        Me.MPLab4.Name = "MPLab4"
        Me.MPLab4.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.MPLab4.Size = New System.Drawing.Size(120, 17)
        Me.MPLab4.TabIndex = 54
        Me.MPLab4.Text = "Happens by Screen:"
        '
        'MPLab3
        '
        Me.MPLab3.BackColor = System.Drawing.SystemColors.Control
        Me.MPLab3.Cursor = System.Windows.Forms.Cursors.Default
        Me.MPLab3.Enabled = False
        Me.MPLab3.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MPLab3.ForeColor = System.Drawing.SystemColors.ControlText
        Me.MPLab3.Location = New System.Drawing.Point(8, 112)
        Me.MPLab3.Name = "MPLab3"
        Me.MPLab3.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.MPLab3.Size = New System.Drawing.Size(120, 17)
        Me.MPLab3.TabIndex = 28
        Me.MPLab3.Text = "Palette Set:"
        '
        'MPLab2
        '
        Me.MPLab2.BackColor = System.Drawing.SystemColors.Control
        Me.MPLab2.Cursor = System.Windows.Forms.Cursors.Default
        Me.MPLab2.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MPLab2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.MPLab2.Location = New System.Drawing.Point(8, 88)
        Me.MPLab2.Name = "MPLab2"
        Me.MPLab2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.MPLab2.Size = New System.Drawing.Size(120, 17)
        Me.MPLab2.TabIndex = 5
        Me.MPLab2.Text = "Graphics Set ID:"
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.SystemColors.Control
        Me.Label3.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label3.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label3.Location = New System.Drawing.Point(8, 64)
        Me.Label3.Name = "Label3"
        Me.Label3.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label3.Size = New System.Drawing.Size(120, 17)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "Scroll Map Data:"
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.SystemColors.Control
        Me.Label2.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label2.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label2.Location = New System.Drawing.Point(8, 40)
        Me.Label2.Name = "Label2"
        Me.Label2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label2.Size = New System.Drawing.Size(120, 17)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Screen Position:"
        '
        'MusicUD
        '
        Me.MusicUD.Location = New System.Drawing.Point(273, 40)
        Me.MusicUD.Minimum = New Decimal(New Integer() {5, 0, 0, -2147483648})
        Me.MusicUD.Name = "MusicUD"
        Me.MusicUD.ReadOnly = True
        Me.MusicUD.Size = New System.Drawing.Size(17, 20)
        Me.MusicUD.TabIndex = 25
        '
        'SBDUD
        '
        Me.SBDUD.Location = New System.Drawing.Point(273, 72)
        Me.SBDUD.Minimum = New Decimal(New Integer() {5, 0, 0, -2147483648})
        Me.SBDUD.Name = "SBDUD"
        Me.SBDUD.ReadOnly = True
        Me.SBDUD.Size = New System.Drawing.Size(17, 20)
        Me.SBDUD.TabIndex = 26
        Me.SBDUD.Visible = False
        '
        'Line1
        '
        Me.Line1.BackColor = System.Drawing.SystemColors.WindowText
        Me.Line1.Location = New System.Drawing.Point(0, 32)
        Me.Line1.Name = "Line1"
        Me.Line1.Size = New System.Drawing.Size(552, 1)
        Me.Line1.TabIndex = 74
        '
        'CurLevLab
        '
        Me.CurLevLab.BackColor = System.Drawing.SystemColors.Control
        Me.CurLevLab.Cursor = System.Windows.Forms.Cursors.Default
        Me.CurLevLab.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CurLevLab.ForeColor = System.Drawing.SystemColors.ControlText
        Me.CurLevLab.Location = New System.Drawing.Point(8, 8)
        Me.CurLevLab.Name = "CurLevLab"
        Me.CurLevLab.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.CurLevLab.Size = New System.Drawing.Size(297, 17)
        Me.CurLevLab.TabIndex = 27
        '
        'SBDLab
        '
        Me.SBDLab.BackColor = System.Drawing.SystemColors.Control
        Me.SBDLab.Cursor = System.Windows.Forms.Cursors.Default
        Me.SBDLab.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SBDLab.ForeColor = System.Drawing.SystemColors.ControlText
        Me.SBDLab.Location = New System.Drawing.Point(8, 72)
        Me.SBDLab.Name = "SBDLab"
        Me.SBDLab.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.SBDLab.Size = New System.Drawing.Size(89, 23)
        Me.SBDLab.TabIndex = 23
        Me.SBDLab.Text = "SBD Bank:"
        Me.SBDLab.Visible = False
        '
        'MusicLabel
        '
        Me.MusicLabel.BackColor = System.Drawing.SystemColors.Control
        Me.MusicLabel.Cursor = System.Windows.Forms.Cursors.Default
        Me.MusicLabel.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MusicLabel.ForeColor = System.Drawing.SystemColors.ControlText
        Me.MusicLabel.Location = New System.Drawing.Point(8, 40)
        Me.MusicLabel.Name = "MusicLabel"
        Me.MusicLabel.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.MusicLabel.Size = New System.Drawing.Size(89, 23)
        Me.MusicLabel.TabIndex = 0
        Me.MusicLabel.Text = "Music Track:"
        '
        'MiscEd
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 14.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.ClientSize = New System.Drawing.Size(560, 262)
        Me.Controls.Add(Me.SceneFrame)
        Me.Controls.Add(Me.MuPFrame)
        Me.Controls.Add(Me.SBDCombo)
        Me.Controls.Add(Me.BPFrame)
        Me.Controls.Add(Me.MPFrame)
        Me.Controls.Add(Me.MusicCombo)
        Me.Controls.Add(Me.MusicUD)
        Me.Controls.Add(Me.SBDUD)
        Me.Controls.Add(Me.Line1)
        Me.Controls.Add(Me.CurLevLab)
        Me.Controls.Add(Me.SBDLab)
        Me.Controls.Add(Me.MusicLabel)
        Me.Cursor = System.Windows.Forms.Cursors.Default
        Me.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.Location = New System.Drawing.Point(3, 28)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "MiscEd"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Text = "Level - Miscellaneous"
        Me.SceneFrame.ResumeLayout(False)
        CType(Me._ScCHRUD_1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me._ScCHRUD_0, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GlIdUD, System.ComponentModel.ISupportInitialize).EndInit()
        Me.MuPFrame.ResumeLayout(False)
        CType(Me._MuPUD_0, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me._MuPUD_1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me._MuPUD_2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me._MuPUD_3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.MuPIDUD, System.ComponentModel.ISupportInitialize).EndInit()
        Me.BPFrame.ResumeLayout(False)
        CType(Me._MPCheckScreenUD_1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me._MPUD_4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me._MPUD_5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me._MPUD_6, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me._MPUD_7, System.ComponentModel.ISupportInitialize).EndInit()
        Me.MPFrame.ResumeLayout(False)
        CType(Me._MPCheckScreenUD_0, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me._MPUD_0, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me._MPUD_1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me._MPUD_2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me._MPUD_3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.MusicUD, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SBDUD, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Public WithEvents Label4 As Label
    Public WithEvents Label1 As Label
#End Region
End Class