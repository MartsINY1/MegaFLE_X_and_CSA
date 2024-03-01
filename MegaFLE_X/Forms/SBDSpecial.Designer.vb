<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> Partial Class SBDSpecial
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
	Public WithEvents _RBrushOpt_3 As System.Windows.Forms.RadioButton
	Public WithEvents _RBrushOpt_1 As System.Windows.Forms.RadioButton
	Public WithEvents _RBrushOpt_2 As System.Windows.Forms.RadioButton
	Public WithEvents _RBrushOpt_0 As System.Windows.Forms.RadioButton
	Public WithEvents Frame2 As System.Windows.Forms.GroupBox
	Public WithEvents _LBrushOpt_0 As System.Windows.Forms.RadioButton
	Public WithEvents _LBrushOpt_2 As System.Windows.Forms.RadioButton
	Public WithEvents _LBrushOpt_1 As System.Windows.Forms.RadioButton
	Public WithEvents _LBrushOpt_3 As System.Windows.Forms.RadioButton
	Public WithEvents Frame1 As System.Windows.Forms.GroupBox
	Public WithEvents MBlockCheck As System.Windows.Forms.CheckBox
	Public WithEvents MBlockTB As System.Windows.Forms.TextBox
	Public WithEvents SetCurAsMaskBlockBtn As System.Windows.Forms.Button
	Public WithEvents FillObjBtn As System.Windows.Forms.Button
	Public WithEvents CurObjUD As System.Windows.Forms.NumericUpDown
    Public WithEvents ImportAllBtn As System.Windows.Forms.Button
    Public WithEvents ObjPic As System.Windows.Forms.PictureBox
	Public WithEvents FillBlockBtn As System.Windows.Forms.Button
	Public WithEvents ImportBtn As System.Windows.Forms.Button
	Public WithEvents ConvBtn As System.Windows.Forms.Button
	Public WithEvents ViewBlocksBtn As System.Windows.Forms.Button
	Public WithEvents ScrnScroll As System.Windows.Forms.HScrollBar
	Public WithEvents ScreenPic As System.Windows.Forms.PictureBox
	Public WithEvents Label1 As System.Windows.Forms.Label
	Public WithEvents Label3 As System.Windows.Forms.Label
	Public WithEvents Label2 As System.Windows.Forms.Label
	Public WithEvents ScrnLab As System.Windows.Forms.Label
    Public WithEvents Menu_ObjLoad As System.Windows.Forms.ToolStripMenuItem
    Public WithEvents Menu_ObjSave As System.Windows.Forms.ToolStripMenuItem
	Public WithEvents Menu_ObjLi As System.Windows.Forms.ToolStripSeparator
	Public WithEvents Menu_ObClear As System.Windows.Forms.ToolStripMenuItem
	Public WithEvents Menu_Obj As System.Windows.Forms.ToolStripMenuItem
	Public WithEvents Menu_Scr_Clear_All As System.Windows.Forms.ToolStripMenuItem
	Public WithEvents Menu_Scr_Clear_Current As System.Windows.Forms.ToolStripMenuItem
	Public WithEvents Menu_Scr_Clear_Range As System.Windows.Forms.ToolStripMenuItem
	Public WithEvents Menu_Scr_Clear As System.Windows.Forms.ToolStripMenuItem
	Public WithEvents Menu_Scr_Load_All As System.Windows.Forms.ToolStripMenuItem
	Public WithEvents Menu_Scr_Load_Current As System.Windows.Forms.ToolStripMenuItem
	Public WithEvents Menu_Scr_Load_Range As System.Windows.Forms.ToolStripMenuItem
	Public WithEvents Menu_Scr_Load As System.Windows.Forms.ToolStripMenuItem
	Public WithEvents Menu_Scr_Save_All As System.Windows.Forms.ToolStripMenuItem
	Public WithEvents Menu_Scr_Save_Current As System.Windows.Forms.ToolStripMenuItem
	Public WithEvents Menu_Scr_Save_Range As System.Windows.Forms.ToolStripMenuItem
	Public WithEvents Menu_Scr_Save As System.Windows.Forms.ToolStripMenuItem
	Public WithEvents Menu_Scr As System.Windows.Forms.ToolStripMenuItem
	Public WithEvents MainMenu1 As System.Windows.Forms.MenuStrip
	'NOTE: The following procedure is required by the Windows Form Designer
	'It can be modified using the Windows Form Designer.
	'Do not modify it using the code editor.
	<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(SBDSpecial))
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.Frame2 = New System.Windows.Forms.GroupBox()
        Me._RBrushOpt_3 = New System.Windows.Forms.RadioButton()
        Me._RBrushOpt_1 = New System.Windows.Forms.RadioButton()
        Me._RBrushOpt_2 = New System.Windows.Forms.RadioButton()
        Me._RBrushOpt_0 = New System.Windows.Forms.RadioButton()
        Me.Frame1 = New System.Windows.Forms.GroupBox()
        Me._LBrushOpt_0 = New System.Windows.Forms.RadioButton()
        Me._LBrushOpt_2 = New System.Windows.Forms.RadioButton()
        Me._LBrushOpt_1 = New System.Windows.Forms.RadioButton()
        Me._LBrushOpt_3 = New System.Windows.Forms.RadioButton()
        Me.MBlockCheck = New System.Windows.Forms.CheckBox()
        Me.MBlockTB = New System.Windows.Forms.TextBox()
        Me.SetCurAsMaskBlockBtn = New System.Windows.Forms.Button()
        Me.FillObjBtn = New System.Windows.Forms.Button()
        Me.CurObjUD = New System.Windows.Forms.NumericUpDown()
        Me.ImportAllBtn = New System.Windows.Forms.Button()
        Me.ObjPic = New System.Windows.Forms.PictureBox()
        Me.FillBlockBtn = New System.Windows.Forms.Button()
        Me.ImportBtn = New System.Windows.Forms.Button()
        Me.ConvBtn = New System.Windows.Forms.Button()
        Me.ViewBlocksBtn = New System.Windows.Forms.Button()
        Me.ScrnScroll = New System.Windows.Forms.HScrollBar()
        Me.ScreenPic = New System.Windows.Forms.PictureBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.ScrnLab = New System.Windows.Forms.Label()
        Me.MainMenu1 = New System.Windows.Forms.MenuStrip()
        Me.Menu_Obj = New System.Windows.Forms.ToolStripMenuItem()
        Me.Menu_ObjLoad = New System.Windows.Forms.ToolStripMenuItem()
        Me.Menu_ObjSave = New System.Windows.Forms.ToolStripMenuItem()
        Me.Menu_ObjLi = New System.Windows.Forms.ToolStripSeparator()
        Me.Menu_ObClear = New System.Windows.Forms.ToolStripMenuItem()
        Me.Menu_Scr = New System.Windows.Forms.ToolStripMenuItem()
        Me.Menu_Scr_Clear = New System.Windows.Forms.ToolStripMenuItem()
        Me.Menu_Scr_Clear_All = New System.Windows.Forms.ToolStripMenuItem()
        Me.Menu_Scr_Clear_Current = New System.Windows.Forms.ToolStripMenuItem()
        Me.Menu_Scr_Clear_Range = New System.Windows.Forms.ToolStripMenuItem()
        Me.Menu_Scr_Load = New System.Windows.Forms.ToolStripMenuItem()
        Me.Menu_Scr_Load_All = New System.Windows.Forms.ToolStripMenuItem()
        Me.Menu_Scr_Load_Current = New System.Windows.Forms.ToolStripMenuItem()
        Me.Menu_Scr_Load_Range = New System.Windows.Forms.ToolStripMenuItem()
        Me.Menu_Scr_Save = New System.Windows.Forms.ToolStripMenuItem()
        Me.Menu_Scr_Save_All = New System.Windows.Forms.ToolStripMenuItem()
        Me.Menu_Scr_Save_Current = New System.Windows.Forms.ToolStripMenuItem()
        Me.Menu_Scr_Save_Range = New System.Windows.Forms.ToolStripMenuItem()
        Me.TimerUnlockPictureBoxes = New System.Windows.Forms.Timer(Me.components)
        Me.Frame2.SuspendLayout()
        Me.Frame1.SuspendLayout()
        CType(Me.CurObjUD, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ObjPic, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ScreenPic, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.MainMenu1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Frame2
        '
        Me.Frame2.BackColor = System.Drawing.SystemColors.Control
        Me.Frame2.Controls.Add(Me._RBrushOpt_3)
        Me.Frame2.Controls.Add(Me._RBrushOpt_1)
        Me.Frame2.Controls.Add(Me._RBrushOpt_2)
        Me.Frame2.Controls.Add(Me._RBrushOpt_0)
        Me.Frame2.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Frame2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Frame2.Location = New System.Drawing.Point(154, 388)
        Me.Frame2.Name = "Frame2"
        Me.Frame2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Frame2.Size = New System.Drawing.Size(154, 89)
        Me.Frame2.TabIndex = 22
        Me.Frame2.TabStop = False
        Me.Frame2.Text = "Right mousebutton brush:"
        '
        '_RBrushOpt_3
        '
        Me._RBrushOpt_3.BackColor = System.Drawing.SystemColors.Control
        Me._RBrushOpt_3.Cursor = System.Windows.Forms.Cursors.Default
        Me._RBrushOpt_3.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._RBrushOpt_3.ForeColor = System.Drawing.SystemColors.ControlText
        Me._RBrushOpt_3.Location = New System.Drawing.Point(8, 68)
        Me._RBrushOpt_3.Name = "_RBrushOpt_3"
        Me._RBrushOpt_3.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._RBrushOpt_3.Size = New System.Drawing.Size(89, 17)
        Me._RBrushOpt_3.TabIndex = 26
        Me._RBrushOpt_3.TabStop = True
        Me._RBrushOpt_3.Text = "Copy"
        Me._RBrushOpt_3.UseVisualStyleBackColor = False
        '
        '_RBrushOpt_1
        '
        Me._RBrushOpt_1.BackColor = System.Drawing.SystemColors.Control
        Me._RBrushOpt_1.Cursor = System.Windows.Forms.Cursors.Default
        Me._RBrushOpt_1.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._RBrushOpt_1.ForeColor = System.Drawing.SystemColors.ControlText
        Me._RBrushOpt_1.Location = New System.Drawing.Point(8, 36)
        Me._RBrushOpt_1.Name = "_RBrushOpt_1"
        Me._RBrushOpt_1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._RBrushOpt_1.Size = New System.Drawing.Size(89, 17)
        Me._RBrushOpt_1.TabIndex = 25
        Me._RBrushOpt_1.TabStop = True
        Me._RBrushOpt_1.Text = "Place Object"
        Me._RBrushOpt_1.UseVisualStyleBackColor = False
        '
        '_RBrushOpt_2
        '
        Me._RBrushOpt_2.BackColor = System.Drawing.SystemColors.Control
        Me._RBrushOpt_2.Cursor = System.Windows.Forms.Cursors.Default
        Me._RBrushOpt_2.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._RBrushOpt_2.ForeColor = System.Drawing.SystemColors.ControlText
        Me._RBrushOpt_2.Location = New System.Drawing.Point(8, 52)
        Me._RBrushOpt_2.Name = "_RBrushOpt_2"
        Me._RBrushOpt_2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._RBrushOpt_2.Size = New System.Drawing.Size(97, 17)
        Me._RBrushOpt_2.TabIndex = 24
        Me._RBrushOpt_2.TabStop = True
        Me._RBrushOpt_2.Text = "Object brush"
        Me._RBrushOpt_2.UseVisualStyleBackColor = False
        '
        '_RBrushOpt_0
        '
        Me._RBrushOpt_0.BackColor = System.Drawing.SystemColors.Control
        Me._RBrushOpt_0.Cursor = System.Windows.Forms.Cursors.Default
        Me._RBrushOpt_0.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._RBrushOpt_0.ForeColor = System.Drawing.SystemColors.ControlText
        Me._RBrushOpt_0.Location = New System.Drawing.Point(8, 20)
        Me._RBrushOpt_0.Name = "_RBrushOpt_0"
        Me._RBrushOpt_0.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._RBrushOpt_0.Size = New System.Drawing.Size(97, 17)
        Me._RBrushOpt_0.TabIndex = 23
        Me._RBrushOpt_0.TabStop = True
        Me._RBrushOpt_0.Text = "Current Block"
        Me._RBrushOpt_0.UseVisualStyleBackColor = False
        '
        'Frame1
        '
        Me.Frame1.BackColor = System.Drawing.SystemColors.Control
        Me.Frame1.Controls.Add(Me._LBrushOpt_0)
        Me.Frame1.Controls.Add(Me._LBrushOpt_2)
        Me.Frame1.Controls.Add(Me._LBrushOpt_1)
        Me.Frame1.Controls.Add(Me._LBrushOpt_3)
        Me.Frame1.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Frame1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Frame1.Location = New System.Drawing.Point(8, 388)
        Me.Frame1.Name = "Frame1"
        Me.Frame1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Frame1.Size = New System.Drawing.Size(140, 89)
        Me.Frame1.TabIndex = 17
        Me.Frame1.TabStop = False
        Me.Frame1.Text = "Left mousebutton brush:"
        '
        '_LBrushOpt_0
        '
        Me._LBrushOpt_0.BackColor = System.Drawing.SystemColors.Control
        Me._LBrushOpt_0.Cursor = System.Windows.Forms.Cursors.Default
        Me._LBrushOpt_0.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._LBrushOpt_0.ForeColor = System.Drawing.SystemColors.ControlText
        Me._LBrushOpt_0.Location = New System.Drawing.Point(8, 20)
        Me._LBrushOpt_0.Name = "_LBrushOpt_0"
        Me._LBrushOpt_0.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._LBrushOpt_0.Size = New System.Drawing.Size(97, 17)
        Me._LBrushOpt_0.TabIndex = 21
        Me._LBrushOpt_0.TabStop = True
        Me._LBrushOpt_0.Text = "Current Block"
        Me._LBrushOpt_0.UseVisualStyleBackColor = False
        '
        '_LBrushOpt_2
        '
        Me._LBrushOpt_2.BackColor = System.Drawing.SystemColors.Control
        Me._LBrushOpt_2.Cursor = System.Windows.Forms.Cursors.Default
        Me._LBrushOpt_2.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._LBrushOpt_2.ForeColor = System.Drawing.SystemColors.ControlText
        Me._LBrushOpt_2.Location = New System.Drawing.Point(8, 52)
        Me._LBrushOpt_2.Name = "_LBrushOpt_2"
        Me._LBrushOpt_2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._LBrushOpt_2.Size = New System.Drawing.Size(97, 17)
        Me._LBrushOpt_2.TabIndex = 20
        Me._LBrushOpt_2.TabStop = True
        Me._LBrushOpt_2.Text = "Object brush"
        Me._LBrushOpt_2.UseVisualStyleBackColor = False
        '
        '_LBrushOpt_1
        '
        Me._LBrushOpt_1.BackColor = System.Drawing.SystemColors.Control
        Me._LBrushOpt_1.Cursor = System.Windows.Forms.Cursors.Default
        Me._LBrushOpt_1.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._LBrushOpt_1.ForeColor = System.Drawing.SystemColors.ControlText
        Me._LBrushOpt_1.Location = New System.Drawing.Point(8, 36)
        Me._LBrushOpt_1.Name = "_LBrushOpt_1"
        Me._LBrushOpt_1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._LBrushOpt_1.Size = New System.Drawing.Size(89, 17)
        Me._LBrushOpt_1.TabIndex = 19
        Me._LBrushOpt_1.TabStop = True
        Me._LBrushOpt_1.Text = "Place Object"
        Me._LBrushOpt_1.UseVisualStyleBackColor = False
        '
        '_LBrushOpt_3
        '
        Me._LBrushOpt_3.BackColor = System.Drawing.SystemColors.Control
        Me._LBrushOpt_3.Cursor = System.Windows.Forms.Cursors.Default
        Me._LBrushOpt_3.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._LBrushOpt_3.ForeColor = System.Drawing.SystemColors.ControlText
        Me._LBrushOpt_3.Location = New System.Drawing.Point(8, 68)
        Me._LBrushOpt_3.Name = "_LBrushOpt_3"
        Me._LBrushOpt_3.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._LBrushOpt_3.Size = New System.Drawing.Size(89, 17)
        Me._LBrushOpt_3.TabIndex = 18
        Me._LBrushOpt_3.TabStop = True
        Me._LBrushOpt_3.Text = "Copy"
        Me._LBrushOpt_3.UseVisualStyleBackColor = False
        '
        'MBlockCheck
        '
        Me.MBlockCheck.BackColor = System.Drawing.SystemColors.Control
        Me.MBlockCheck.Cursor = System.Windows.Forms.Cursors.Default
        Me.MBlockCheck.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MBlockCheck.ForeColor = System.Drawing.SystemColors.ControlText
        Me.MBlockCheck.Location = New System.Drawing.Point(8, 484)
        Me.MBlockCheck.Name = "MBlockCheck"
        Me.MBlockCheck.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.MBlockCheck.Size = New System.Drawing.Size(105, 23)
        Me.MBlockCheck.TabIndex = 14
        Me.MBlockCheck.Text = "Mask Block:"
        Me.MBlockCheck.UseVisualStyleBackColor = False
        '
        'MBlockTB
        '
        Me.MBlockTB.AcceptsReturn = True
        Me.MBlockTB.BackColor = System.Drawing.SystemColors.Window
        Me.MBlockTB.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.MBlockTB.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MBlockTB.ForeColor = System.Drawing.SystemColors.WindowText
        Me.MBlockTB.Location = New System.Drawing.Point(103, 484)
        Me.MBlockTB.MaxLength = 0
        Me.MBlockTB.Name = "MBlockTB"
        Me.MBlockTB.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.MBlockTB.Size = New System.Drawing.Size(41, 23)
        Me.MBlockTB.TabIndex = 13
        '
        'SetCurAsMaskBlockBtn
        '
        Me.SetCurAsMaskBlockBtn.BackColor = System.Drawing.SystemColors.Control
        Me.SetCurAsMaskBlockBtn.Cursor = System.Windows.Forms.Cursors.Default
        Me.SetCurAsMaskBlockBtn.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SetCurAsMaskBlockBtn.ForeColor = System.Drawing.SystemColors.ControlText
        Me.SetCurAsMaskBlockBtn.Location = New System.Drawing.Point(163, 484)
        Me.SetCurAsMaskBlockBtn.Name = "SetCurAsMaskBlockBtn"
        Me.SetCurAsMaskBlockBtn.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.SetCurAsMaskBlockBtn.Size = New System.Drawing.Size(145, 25)
        Me.SetCurAsMaskBlockBtn.TabIndex = 12
        Me.SetCurAsMaskBlockBtn.Text = "Set current Block as Mask"
        Me.SetCurAsMaskBlockBtn.UseVisualStyleBackColor = False
        '
        'FillObjBtn
        '
        Me.FillObjBtn.BackColor = System.Drawing.SystemColors.Control
        Me.FillObjBtn.Cursor = System.Windows.Forms.Cursors.Default
        Me.FillObjBtn.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FillObjBtn.ForeColor = System.Drawing.SystemColors.ControlText
        Me.FillObjBtn.Location = New System.Drawing.Point(8, 356)
        Me.FillObjBtn.Name = "FillObjBtn"
        Me.FillObjBtn.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.FillObjBtn.Size = New System.Drawing.Size(161, 25)
        Me.FillObjBtn.TabIndex = 11
        Me.FillObjBtn.Text = "Fill Screen With Object"
        Me.FillObjBtn.UseVisualStyleBackColor = False
        '
        'CurObjUD
        '
        Me.CurObjUD.Location = New System.Drawing.Point(523, 288)
        Me.CurObjUD.Maximum = New Decimal(New Integer() {255, 0, 0, 0})
        Me.CurObjUD.Name = "CurObjUD"
        Me.CurObjUD.Size = New System.Drawing.Size(45, 23)
        Me.CurObjUD.TabIndex = 10
        '
        'ImportAllBtn
        '
        Me.ImportAllBtn.BackColor = System.Drawing.SystemColors.Control
        Me.ImportAllBtn.Cursor = System.Windows.Forms.Cursors.Default
        Me.ImportAllBtn.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ImportAllBtn.ForeColor = System.Drawing.SystemColors.ControlText
        Me.ImportAllBtn.Location = New System.Drawing.Point(336, 340)
        Me.ImportAllBtn.Name = "ImportAllBtn"
        Me.ImportAllBtn.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.ImportAllBtn.Size = New System.Drawing.Size(143, 25)
        Me.ImportAllBtn.TabIndex = 8
        Me.ImportAllBtn.Text = "Import (all screens)"
        Me.ImportAllBtn.UseVisualStyleBackColor = False
        '
        'ObjPic
        '
        Me.ObjPic.BackColor = System.Drawing.SystemColors.Control
        Me.ObjPic.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.ObjPic.Cursor = System.Windows.Forms.Cursors.Default
        Me.ObjPic.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ObjPic.ForeColor = System.Drawing.SystemColors.ControlText
        Me.ObjPic.Location = New System.Drawing.Point(296, 24)
        Me.ObjPic.Name = "ObjPic"
        Me.ObjPic.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.ObjPic.Size = New System.Drawing.Size(263, 262)
        Me.ObjPic.TabIndex = 6
        Me.ObjPic.TabStop = False
        '
        'FillBlockBtn
        '
        Me.FillBlockBtn.BackColor = System.Drawing.SystemColors.Control
        Me.FillBlockBtn.Cursor = System.Windows.Forms.Cursors.Default
        Me.FillBlockBtn.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FillBlockBtn.ForeColor = System.Drawing.SystemColors.ControlText
        Me.FillBlockBtn.Location = New System.Drawing.Point(8, 332)
        Me.FillBlockBtn.Name = "FillBlockBtn"
        Me.FillBlockBtn.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.FillBlockBtn.Size = New System.Drawing.Size(161, 25)
        Me.FillBlockBtn.TabIndex = 5
        Me.FillBlockBtn.Text = "Fill Screen With Current Block"
        Me.FillBlockBtn.UseVisualStyleBackColor = False
        '
        'ImportBtn
        '
        Me.ImportBtn.BackColor = System.Drawing.SystemColors.Control
        Me.ImportBtn.Cursor = System.Windows.Forms.Cursors.Default
        Me.ImportBtn.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ImportBtn.ForeColor = System.Drawing.SystemColors.ControlText
        Me.ImportBtn.Location = New System.Drawing.Point(448, 340)
        Me.ImportBtn.Name = "ImportBtn"
        Me.ImportBtn.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.ImportBtn.Size = New System.Drawing.Size(145, 25)
        Me.ImportBtn.TabIndex = 4
        Me.ImportBtn.Text = "Import Screen (this screen)"
        Me.ImportBtn.UseVisualStyleBackColor = False
        Me.ImportBtn.Visible = False
        '
        'ConvBtn
        '
        Me.ConvBtn.BackColor = System.Drawing.SystemColors.Control
        Me.ConvBtn.Cursor = System.Windows.Forms.Cursors.Default
        Me.ConvBtn.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ConvBtn.ForeColor = System.Drawing.SystemColors.ControlText
        Me.ConvBtn.Location = New System.Drawing.Point(336, 372)
        Me.ConvBtn.Name = "ConvBtn"
        Me.ConvBtn.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.ConvBtn.Size = New System.Drawing.Size(97, 49)
        Me.ConvBtn.TabIndex = 3
        Me.ConvBtn.Text = "Convert to Normal Data!"
        Me.ConvBtn.UseVisualStyleBackColor = False
        '
        'ViewBlocksBtn
        '
        Me.ViewBlocksBtn.BackColor = System.Drawing.SystemColors.Control
        Me.ViewBlocksBtn.Cursor = System.Windows.Forms.Cursors.Default
        Me.ViewBlocksBtn.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ViewBlocksBtn.ForeColor = System.Drawing.SystemColors.ControlText
        Me.ViewBlocksBtn.Location = New System.Drawing.Point(336, 288)
        Me.ViewBlocksBtn.Name = "ViewBlocksBtn"
        Me.ViewBlocksBtn.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.ViewBlocksBtn.Size = New System.Drawing.Size(97, 25)
        Me.ViewBlocksBtn.TabIndex = 2
        Me.ViewBlocksBtn.Text = "View Blocks.."
        Me.ViewBlocksBtn.UseVisualStyleBackColor = False
        '
        'ScrnScroll
        '
        Me.ScrnScroll.Cursor = System.Windows.Forms.Cursors.Default
        Me.ScrnScroll.LargeChange = 1
        Me.ScrnScroll.Location = New System.Drawing.Point(8, 290)
        Me.ScrnScroll.Maximum = 32767
        Me.ScrnScroll.Name = "ScrnScroll"
        Me.ScrnScroll.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.ScrnScroll.Size = New System.Drawing.Size(265, 25)
        Me.ScrnScroll.TabIndex = 1
        Me.ScrnScroll.TabStop = True
        '
        'ScreenPic
        '
        Me.ScreenPic.BackColor = System.Drawing.SystemColors.Control
        Me.ScreenPic.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.ScreenPic.Cursor = System.Windows.Forms.Cursors.Default
        Me.ScreenPic.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ScreenPic.ForeColor = System.Drawing.SystemColors.ControlText
        Me.ScreenPic.Location = New System.Drawing.Point(8, 24)
        Me.ScreenPic.Name = "ScreenPic"
        Me.ScreenPic.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.ScreenPic.Size = New System.Drawing.Size(262, 262)
        Me.ScreenPic.TabIndex = 0
        Me.ScreenPic.TabStop = False
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.SystemColors.Control
        Me.Label1.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label1.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label1.Location = New System.Drawing.Point(296, 8)
        Me.Label1.Name = "Label1"
        Me.Label1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label1.Size = New System.Drawing.Size(49, 17)
        Me.Label1.TabIndex = 27
        Me.Label1.Text = "Object:"
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.SystemColors.Control
        Me.Label3.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label3.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label3.Location = New System.Drawing.Point(336, 316)
        Me.Label3.Name = "Label3"
        Me.Label3.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label3.Size = New System.Drawing.Size(105, 17)
        Me.Label3.TabIndex = 16
        Me.Label3.Text = "Main functions:"
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.SystemColors.Control
        Me.Label2.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label2.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label2.Location = New System.Drawing.Point(8, 316)
        Me.Label2.Name = "Label2"
        Me.Label2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label2.Size = New System.Drawing.Size(79, 17)
        Me.Label2.TabIndex = 15
        Me.Label2.Text = "Draw tools:"
        '
        'ScrnLab
        '
        Me.ScrnLab.BackColor = System.Drawing.SystemColors.Control
        Me.ScrnLab.Cursor = System.Windows.Forms.Cursors.Default
        Me.ScrnLab.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ScrnLab.ForeColor = System.Drawing.SystemColors.ControlText
        Me.ScrnLab.Location = New System.Drawing.Point(280, 284)
        Me.ScrnLab.Name = "ScrnLab"
        Me.ScrnLab.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.ScrnLab.Size = New System.Drawing.Size(33, 25)
        Me.ScrnLab.TabIndex = 7
        '
        'MainMenu1
        '
        Me.MainMenu1.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.MainMenu1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.Menu_Obj, Me.Menu_Scr})
        Me.MainMenu1.Location = New System.Drawing.Point(0, 0)
        Me.MainMenu1.Name = "MainMenu1"
        Me.MainMenu1.Size = New System.Drawing.Size(573, 28)
        Me.MainMenu1.TabIndex = 28
        '
        'Menu_Obj
        '
        Me.Menu_Obj.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.Menu_ObjLoad, Me.Menu_ObjSave, Me.Menu_ObjLi, Me.Menu_ObClear})
        Me.Menu_Obj.Name = "Menu_Obj"
        Me.Menu_Obj.Size = New System.Drawing.Size(103, 24)
        Me.Menu_Obj.Text = "Object Data"
        '
        'Menu_ObjLoad
        '
        Me.Menu_ObjLoad.Name = "Menu_ObjLoad"
        Me.Menu_ObjLoad.Size = New System.Drawing.Size(224, 26)
        Me.Menu_ObjLoad.Text = "Load"
        '
        'Menu_ObjSave
        '
        Me.Menu_ObjSave.Name = "Menu_ObjSave"
        Me.Menu_ObjSave.Size = New System.Drawing.Size(224, 26)
        Me.Menu_ObjSave.Text = "Save"
        '
        'Menu_ObjLi
        '
        Me.Menu_ObjLi.Name = "Menu_ObjLi"
        Me.Menu_ObjLi.Size = New System.Drawing.Size(221, 6)
        '
        'Menu_ObClear
        '
        Me.Menu_ObClear.Name = "Menu_ObClear"
        Me.Menu_ObClear.Size = New System.Drawing.Size(224, 26)
        Me.Menu_ObClear.Text = "Clear"
        '
        'Menu_Scr
        '
        Me.Menu_Scr.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.Menu_Scr_Clear, Me.Menu_Scr_Load, Me.Menu_Scr_Save})
        Me.Menu_Scr.Name = "Menu_Scr"
        Me.Menu_Scr.Size = New System.Drawing.Size(103, 24)
        Me.Menu_Scr.Text = "Screen Data"
        '
        'Menu_Scr_Clear
        '
        Me.Menu_Scr_Clear.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.Menu_Scr_Clear_All, Me.Menu_Scr_Clear_Current, Me.Menu_Scr_Clear_Range})
        Me.Menu_Scr_Clear.Name = "Menu_Scr_Clear"
        Me.Menu_Scr_Clear.Size = New System.Drawing.Size(224, 26)
        Me.Menu_Scr_Clear.Text = "Clear"
        '
        'Menu_Scr_Clear_All
        '
        Me.Menu_Scr_Clear_All.Name = "Menu_Scr_Clear_All"
        Me.Menu_Scr_Clear_All.Size = New System.Drawing.Size(224, 26)
        Me.Menu_Scr_Clear_All.Text = "All Screens"
        '
        'Menu_Scr_Clear_Current
        '
        Me.Menu_Scr_Clear_Current.Name = "Menu_Scr_Clear_Current"
        Me.Menu_Scr_Clear_Current.Size = New System.Drawing.Size(224, 26)
        Me.Menu_Scr_Clear_Current.Text = "Current Screen"
        '
        'Menu_Scr_Clear_Range
        '
        Me.Menu_Scr_Clear_Range.Name = "Menu_Scr_Clear_Range"
        Me.Menu_Scr_Clear_Range.Size = New System.Drawing.Size(224, 26)
        Me.Menu_Scr_Clear_Range.Text = "Specify Range.."
        '
        'Menu_Scr_Load
        '
        Me.Menu_Scr_Load.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.Menu_Scr_Load_All, Me.Menu_Scr_Load_Current, Me.Menu_Scr_Load_Range})
        Me.Menu_Scr_Load.Name = "Menu_Scr_Load"
        Me.Menu_Scr_Load.Size = New System.Drawing.Size(224, 26)
        Me.Menu_Scr_Load.Text = "Load"
        '
        'Menu_Scr_Load_All
        '
        Me.Menu_Scr_Load_All.Name = "Menu_Scr_Load_All"
        Me.Menu_Scr_Load_All.Size = New System.Drawing.Size(224, 26)
        Me.Menu_Scr_Load_All.Text = "All Screens.."
        '
        'Menu_Scr_Load_Current
        '
        Me.Menu_Scr_Load_Current.Name = "Menu_Scr_Load_Current"
        Me.Menu_Scr_Load_Current.Size = New System.Drawing.Size(224, 26)
        Me.Menu_Scr_Load_Current.Text = "Current Screen.."
        '
        'Menu_Scr_Load_Range
        '
        Me.Menu_Scr_Load_Range.Name = "Menu_Scr_Load_Range"
        Me.Menu_Scr_Load_Range.Size = New System.Drawing.Size(224, 26)
        Me.Menu_Scr_Load_Range.Text = "Specify Range.."
        '
        'Menu_Scr_Save
        '
        Me.Menu_Scr_Save.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.Menu_Scr_Save_All, Me.Menu_Scr_Save_Current, Me.Menu_Scr_Save_Range})
        Me.Menu_Scr_Save.Name = "Menu_Scr_Save"
        Me.Menu_Scr_Save.Size = New System.Drawing.Size(224, 26)
        Me.Menu_Scr_Save.Text = "Save"
        '
        'Menu_Scr_Save_All
        '
        Me.Menu_Scr_Save_All.Name = "Menu_Scr_Save_All"
        Me.Menu_Scr_Save_All.Size = New System.Drawing.Size(224, 26)
        Me.Menu_Scr_Save_All.Text = "All Screens.."
        '
        'Menu_Scr_Save_Current
        '
        Me.Menu_Scr_Save_Current.Name = "Menu_Scr_Save_Current"
        Me.Menu_Scr_Save_Current.Size = New System.Drawing.Size(224, 26)
        Me.Menu_Scr_Save_Current.Text = "Current Screen.."
        '
        'Menu_Scr_Save_Range
        '
        Me.Menu_Scr_Save_Range.Name = "Menu_Scr_Save_Range"
        Me.Menu_Scr_Save_Range.Size = New System.Drawing.Size(224, 26)
        Me.Menu_Scr_Save_Range.Text = "Specify Range.."
        '
        'TimerUnlockPictureBoxes
        '
        '
        'SBDSpecial
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.ClientSize = New System.Drawing.Size(573, 511)
        Me.Controls.Add(Me.MBlockTB)
        Me.Controls.Add(Me.Frame2)
        Me.Controls.Add(Me.Frame1)
        Me.Controls.Add(Me.MBlockCheck)
        Me.Controls.Add(Me.SetCurAsMaskBlockBtn)
        Me.Controls.Add(Me.FillObjBtn)
        Me.Controls.Add(Me.CurObjUD)
        Me.Controls.Add(Me.ImportAllBtn)
        Me.Controls.Add(Me.ObjPic)
        Me.Controls.Add(Me.FillBlockBtn)
        Me.Controls.Add(Me.ImportBtn)
        Me.Controls.Add(Me.ConvBtn)
        Me.Controls.Add(Me.ViewBlocksBtn)
        Me.Controls.Add(Me.ScrnScroll)
        Me.Controls.Add(Me.ScreenPic)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.ScrnLab)
        Me.Controls.Add(Me.MainMenu1)
        Me.Cursor = System.Windows.Forms.Cursors.Default
        Me.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.Location = New System.Drawing.Point(10, 56)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "SBDSpecial"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Text = " SBD (Structure/Screen) Editor"
        Me.Frame2.ResumeLayout(False)
        Me.Frame1.ResumeLayout(False)
        CType(Me.CurObjUD, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ObjPic, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ScreenPic, System.ComponentModel.ISupportInitialize).EndInit()
        Me.MainMenu1.ResumeLayout(False)
        Me.MainMenu1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents TimerUnlockPictureBoxes As Timer
#End Region
End Class