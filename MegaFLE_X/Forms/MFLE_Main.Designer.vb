<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> Partial Class MFLE_Main
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
    Public WithEvents Check2 As System.Windows.Forms.CheckBox
    Public WithEvents Command2 As System.Windows.Forms.Button
    Public WithEvents Text12 As System.Windows.Forms.TextBox
    Public WithEvents Label23 As System.Windows.Forms.Label
    Public WithEvents FrameMegaMan4 As System.Windows.Forms.GroupBox
    Public WithEvents Command12 As System.Windows.Forms.Button
    Public WithEvents Text13 As System.Windows.Forms.TextBox
    Public WithEvents Label24 As System.Windows.Forms.Label
    Public WithEvents FrameMegaMan6 As System.Windows.Forms.GroupBox
    Public WithEvents Command17 As System.Windows.Forms.Button
    Public WithEvents Command16 As System.Windows.Forms.Button
    Public WithEvents Text1 As System.Windows.Forms.TextBox
    Public WithEvents Text2 As System.Windows.Forms.TextBox
    Public WithEvents Text10 As System.Windows.Forms.TextBox
    Public WithEvents Command13 As System.Windows.Forms.Button
    Public WithEvents Label2 As System.Windows.Forms.Label
    Public WithEvents Label1 As System.Windows.Forms.Label
    Public WithEvents Frame5 As System.Windows.Forms.GroupBox
    Public WithEvents CurLevCombo As System.Windows.Forms.ComboBox
    Public WithEvents Text14 As System.Windows.Forms.TextBox
    Public WithEvents Command4 As System.Windows.Forms.Button
    Public WithEvents Command1 As System.Windows.Forms.Button
    Public WithEvents OffsDatTB As System.Windows.Forms.TextBox
    Public WithEvents OffsTypeCombo As System.Windows.Forms.ComboBox
    Public WithEvents Label3 As System.Windows.Forms.Label
    Public WithEvents Line1 As System.Windows.Forms.Label
    Public WithEvents Label11 As System.Windows.Forms.Label
    Public WithEvents Frame2 As System.Windows.Forms.GroupBox
    Public WithEvents PatGetDataBtn As System.Windows.Forms.Button
    Public WithEvents Command8 As System.Windows.Forms.Button
    Public WithEvents _Command3_1 As System.Windows.Forms.Button
    Public WithEvents _Command3_0 As System.Windows.Forms.Button
    Public WithEvents PatOffsTB As System.Windows.Forms.TextBox
    Public WithEvents PatDataTB As System.Windows.Forms.TextBox
    Public WithEvents Label8 As System.Windows.Forms.Label
    Public WithEvents Label7 As System.Windows.Forms.Label
    Public WithEvents Frame1 As System.Windows.Forms.GroupBox
    Public WithEvents StatsTimer As System.Windows.Forms.Timer
    Public WithEvents Label9 As System.Windows.Forms.Label
    Public WithEvents File1 As System.Windows.Forms.ListView
    Public WithEvents File_Save As System.Windows.Forms.ToolStripMenuItem
    Public WithEvents File_ReLoad As System.Windows.Forms.ToolStripMenuItem
    Public WithEvents File_Back As System.Windows.Forms.ToolStripMenuItem
    Public WithEvents File_Exit As System.Windows.Forms.ToolStripMenuItem
    Public WithEvents Menu_File As System.Windows.Forms.ToolStripMenuItem
    Public WithEvents View_PalEd As System.Windows.Forms.ToolStripMenuItem
    Public WithEvents View_SBD As System.Windows.Forms.ToolStripMenuItem
    Public WithEvents View_TT As System.Windows.Forms.ToolStripMenuItem
    Public WithEvents View_TSAT As System.Windows.Forms.ToolStripMenuItem
    Public WithEvents View_StrT As System.Windows.Forms.ToolStripMenuItem
    Public WithEvents View_ScreenEd As System.Windows.Forms.ToolStripMenuItem
    Public WithEvents View_EnemEd As System.Windows.Forms.ToolStripMenuItem
    Public WithEvents View_DoorEd As System.Windows.Forms.ToolStripMenuItem
    Public WithEvents Level_Misc As System.Windows.Forms.ToolStripMenuItem
    Public WithEvents Level_bl0 As System.Windows.Forms.ToolStripSeparator
    Public WithEvents Level_Next As System.Windows.Forms.ToolStripMenuItem
    Public WithEvents Level_Previous As System.Windows.Forms.ToolStripMenuItem
    Public WithEvents Menu_View As System.Windows.Forms.ToolStripMenuItem
    Public WithEvents Other_GfxLoadEd As System.Windows.Forms.ToolStripMenuItem
    Public WithEvents Other_TextEd As System.Windows.Forms.ToolStripMenuItem
    Public WithEvents Other_Patches As System.Windows.Forms.ToolStripMenuItem
    Public WithEvents Menu_Other As System.Windows.Forms.ToolStripMenuItem
    Public WithEvents Special_Chargeman As System.Windows.Forms.ToolStripMenuItem
    Public WithEvents Menu_Special As System.Windows.Forms.ToolStripMenuItem
    Public WithEvents Tools_Test As System.Windows.Forms.ToolStripMenuItem
    Public WithEvents Tools_RunShell As System.Windows.Forms.ToolStripMenuItem
    Public WithEvents Tools_bl0 As System.Windows.Forms.ToolStripSeparator
    Public WithEvents Tools_ConvSCR As System.Windows.Forms.ToolStripMenuItem
    Public WithEvents Menu_Tools As System.Windows.Forms.ToolStripMenuItem
    Public WithEvents _DumpBM_selection_0 As System.Windows.Forms.ToolStripMenuItem
    Public WithEvents _DumpBM_selection_1 As System.Windows.Forms.ToolStripMenuItem
    Public WithEvents _DumpBM_selection_2 As System.Windows.Forms.ToolStripMenuItem
    Public WithEvents _DumpBM_selection_3 As System.Windows.Forms.ToolStripMenuItem
    Public WithEvents _DumpBM_selection_4 As System.Windows.Forms.ToolStripMenuItem
    Public WithEvents _DumpBM_selection_5 As System.Windows.Forms.ToolStripMenuItem
    Public WithEvents _DumpBM_selection_6 As System.Windows.Forms.ToolStripMenuItem
    Public WithEvents _DumpBM_selection_7 As System.Windows.Forms.ToolStripMenuItem
    Public WithEvents _DumpBM_selection_8 As System.Windows.Forms.ToolStripMenuItem
    Public WithEvents _DumpBM_selection_9 As System.Windows.Forms.ToolStripMenuItem
    Public WithEvents _DumpBM_selection_10 As System.Windows.Forms.ToolStripMenuItem
    Public WithEvents _DumpBM_selection_11 As System.Windows.Forms.ToolStripMenuItem
    Public WithEvents _DumpBM_selection_12 As System.Windows.Forms.ToolStripMenuItem
    Public WithEvents _DumpBM_selection_13 As System.Windows.Forms.ToolStripMenuItem
    Public WithEvents _DumpBM_selection_14 As System.Windows.Forms.ToolStripMenuItem
    Public WithEvents Dump_Bitmap As System.Windows.Forms.ToolStripMenuItem
    Public WithEvents Menu_Dump As System.Windows.Forms.ToolStripMenuItem
    Public WithEvents Stats_EnemUsage As System.Windows.Forms.ToolStripMenuItem
    Public WithEvents Menu_Stats As System.Windows.Forms.ToolStripMenuItem
    Public WithEvents Menu_Config As System.Windows.Forms.ToolStripMenuItem
    Public WithEvents MainMenu1 As System.Windows.Forms.MenuStrip
    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MFLE_Main))
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.OffsDatTB = New System.Windows.Forms.TextBox()
        Me.PatOffsTB = New System.Windows.Forms.TextBox()
        Me.PatDataTB = New System.Windows.Forms.TextBox()
        Me.LblInformations = New System.Windows.Forms.Label()
        Me.Check2 = New System.Windows.Forms.CheckBox()
        Me.FrameMegaMan4 = New System.Windows.Forms.GroupBox()
        Me.Command2 = New System.Windows.Forms.Button()
        Me.Text12 = New System.Windows.Forms.TextBox()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.FrameMegaMan6 = New System.Windows.Forms.GroupBox()
        Me.Command12 = New System.Windows.Forms.Button()
        Me.Text13 = New System.Windows.Forms.TextBox()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.Frame5 = New System.Windows.Forms.GroupBox()
        Me.Command18 = New System.Windows.Forms.Button()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Command17 = New System.Windows.Forms.Button()
        Me.Command16 = New System.Windows.Forms.Button()
        Me.Text1 = New System.Windows.Forms.TextBox()
        Me.Text2 = New System.Windows.Forms.TextBox()
        Me.Text10 = New System.Windows.Forms.TextBox()
        Me.Command13 = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.CurLevCombo = New System.Windows.Forms.ComboBox()
        Me.Frame2 = New System.Windows.Forms.GroupBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.File1 = New System.Windows.Forms.ListView()
        Me.ColumnHeader1 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader2 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Text14 = New System.Windows.Forms.TextBox()
        Me.Command4 = New System.Windows.Forms.Button()
        Me.Command1 = New System.Windows.Forms.Button()
        Me.OffsTypeCombo = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Line1 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Frame1 = New System.Windows.Forms.GroupBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.PatGetDataBtn = New System.Windows.Forms.Button()
        Me.Command8 = New System.Windows.Forms.Button()
        Me._Command3_1 = New System.Windows.Forms.Button()
        Me._Command3_0 = New System.Windows.Forms.Button()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.StatsTimer = New System.Windows.Forms.Timer(Me.components)
        Me.Label9 = New System.Windows.Forms.Label()
        Me._DumpBM_selection_0 = New System.Windows.Forms.ToolStripMenuItem()
        Me._DumpBM_selection_1 = New System.Windows.Forms.ToolStripMenuItem()
        Me._DumpBM_selection_2 = New System.Windows.Forms.ToolStripMenuItem()
        Me._DumpBM_selection_3 = New System.Windows.Forms.ToolStripMenuItem()
        Me._DumpBM_selection_4 = New System.Windows.Forms.ToolStripMenuItem()
        Me._DumpBM_selection_5 = New System.Windows.Forms.ToolStripMenuItem()
        Me._DumpBM_selection_6 = New System.Windows.Forms.ToolStripMenuItem()
        Me._DumpBM_selection_7 = New System.Windows.Forms.ToolStripMenuItem()
        Me._DumpBM_selection_8 = New System.Windows.Forms.ToolStripMenuItem()
        Me._DumpBM_selection_9 = New System.Windows.Forms.ToolStripMenuItem()
        Me._DumpBM_selection_10 = New System.Windows.Forms.ToolStripMenuItem()
        Me._DumpBM_selection_11 = New System.Windows.Forms.ToolStripMenuItem()
        Me._DumpBM_selection_12 = New System.Windows.Forms.ToolStripMenuItem()
        Me._DumpBM_selection_13 = New System.Windows.Forms.ToolStripMenuItem()
        Me._DumpBM_selection_14 = New System.Windows.Forms.ToolStripMenuItem()
        Me.MainMenu1 = New System.Windows.Forms.MenuStrip()
        Me.Menu_File = New System.Windows.Forms.ToolStripMenuItem()
        Me.File_Save = New System.Windows.Forms.ToolStripMenuItem()
        Me.File_ReLoad = New System.Windows.Forms.ToolStripMenuItem()
        Me.File_Back = New System.Windows.Forms.ToolStripMenuItem()
        Me.File_Exit = New System.Windows.Forms.ToolStripMenuItem()
        Me.Menu_View = New System.Windows.Forms.ToolStripMenuItem()
        Me.View_PalEd = New System.Windows.Forms.ToolStripMenuItem()
        Me.View_SBD = New System.Windows.Forms.ToolStripMenuItem()
        Me.View_TT = New System.Windows.Forms.ToolStripMenuItem()
        Me.View_TSAT = New System.Windows.Forms.ToolStripMenuItem()
        Me.View_StrT = New System.Windows.Forms.ToolStripMenuItem()
        Me.View_ScreenEd = New System.Windows.Forms.ToolStripMenuItem()
        Me.View_EnemEd = New System.Windows.Forms.ToolStripMenuItem()
        Me.View_DoorEd = New System.Windows.Forms.ToolStripMenuItem()
        Me.Level_Misc = New System.Windows.Forms.ToolStripMenuItem()
        Me.Level_bl0 = New System.Windows.Forms.ToolStripSeparator()
        Me.Level_Next = New System.Windows.Forms.ToolStripMenuItem()
        Me.Level_Previous = New System.Windows.Forms.ToolStripMenuItem()
        Me.Menu_Other = New System.Windows.Forms.ToolStripMenuItem()
        Me.Other_GfxLoadEd = New System.Windows.Forms.ToolStripMenuItem()
        Me.Other_TextEd = New System.Windows.Forms.ToolStripMenuItem()
        Me.Other_Patches = New System.Windows.Forms.ToolStripMenuItem()
        Me.AboutToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.Menu_Special = New System.Windows.Forms.ToolStripMenuItem()
        Me.Special_Chargeman = New System.Windows.Forms.ToolStripMenuItem()
        Me.Menu_Tools = New System.Windows.Forms.ToolStripMenuItem()
        Me.Tools_Test = New System.Windows.Forms.ToolStripMenuItem()
        Me.Tools_RunShell = New System.Windows.Forms.ToolStripMenuItem()
        Me.Tools_bl0 = New System.Windows.Forms.ToolStripSeparator()
        Me.Tools_ConvSCR = New System.Windows.Forms.ToolStripMenuItem()
        Me.Menu_Stats = New System.Windows.Forms.ToolStripMenuItem()
        Me.Stats_EnemUsage = New System.Windows.Forms.ToolStripMenuItem()
        Me.Menu_Dump = New System.Windows.Forms.ToolStripMenuItem()
        Me.Dump_Bitmap = New System.Windows.Forms.ToolStripMenuItem()
        Me.Menu_Config = New System.Windows.Forms.ToolStripMenuItem()
        Me.lblGamePath1 = New System.Windows.Forms.Label()
        Me.lblGamePath2 = New System.Windows.Forms.Label()
        Me.picBoxDumping = New System.Windows.Forms.PictureBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Command15 = New System.Windows.Forms.Button()
        Me.Text11 = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.btnAbout = New System.Windows.Forms.Button()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.FrameMegaMan4.SuspendLayout()
        Me.FrameMegaMan6.SuspendLayout()
        Me.Frame5.SuspendLayout()
        Me.Frame2.SuspendLayout()
        Me.Frame1.SuspendLayout()
        Me.MainMenu1.SuspendLayout()
        CType(Me.picBoxDumping, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'OffsDatTB
        '
        Me.OffsDatTB.AcceptsReturn = True
        Me.OffsDatTB.BackColor = System.Drawing.SystemColors.Window
        Me.OffsDatTB.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.OffsDatTB.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.OffsDatTB.ForeColor = System.Drawing.SystemColors.WindowText
        Me.OffsDatTB.Location = New System.Drawing.Point(136, 41)
        Me.OffsDatTB.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.OffsDatTB.MaxLength = 0
        Me.OffsDatTB.Name = "OffsDatTB"
        Me.OffsDatTB.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.OffsDatTB.Size = New System.Drawing.Size(96, 23)
        Me.OffsDatTB.TabIndex = 18
        Me.ToolTip1.SetToolTip(Me.OffsDatTB, "Reads the value of selected offset type from the Resource DAT file.")
        '
        'PatOffsTB
        '
        Me.PatOffsTB.AcceptsReturn = True
        Me.PatOffsTB.BackColor = System.Drawing.SystemColors.Window
        Me.PatOffsTB.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.PatOffsTB.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.PatOffsTB.ForeColor = System.Drawing.SystemColors.WindowText
        Me.PatOffsTB.Location = New System.Drawing.Point(64, 17)
        Me.PatOffsTB.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.PatOffsTB.MaxLength = 0
        Me.PatOffsTB.Name = "PatOffsTB"
        Me.PatOffsTB.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.PatOffsTB.Size = New System.Drawing.Size(56, 23)
        Me.PatOffsTB.TabIndex = 3
        Me.PatOffsTB.Text = "1"
        Me.ToolTip1.SetToolTip(Me.PatOffsTB, "Type a ROM offset")
        '
        'PatDataTB
        '
        Me.PatDataTB.AcceptsReturn = True
        Me.PatDataTB.BackColor = System.Drawing.SystemColors.Window
        Me.PatDataTB.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.PatDataTB.Font = New System.Drawing.Font("Lucida Console", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.PatDataTB.ForeColor = System.Drawing.SystemColors.WindowText
        Me.PatDataTB.Location = New System.Drawing.Point(44, 58)
        Me.PatDataTB.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.PatDataTB.MaxLength = 0
        Me.PatDataTB.Multiline = True
        Me.PatDataTB.Name = "PatDataTB"
        Me.PatDataTB.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.PatDataTB.Size = New System.Drawing.Size(232, 33)
        Me.PatDataTB.TabIndex = 2
        Me.ToolTip1.SetToolTip(Me.PatDataTB, "Shows the first 20 bytes of the specified offset box from above.")
        '
        'LblInformations
        '
        Me.LblInformations.AutoSize = True
        Me.LblInformations.Location = New System.Drawing.Point(252, 50)
        Me.LblInformations.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.LblInformations.Name = "LblInformations"
        Me.LblInformations.Size = New System.Drawing.Size(308, 51)
        Me.LblInformations.TabIndex = 76
        Me.LblInformations.Text = "Some controls have description" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "when mouse is held over them!" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Try with me!"
        Me.ToolTip1.SetToolTip(Me.LblInformations, "I'm a tip!")
        '
        'Check2
        '
        Me.Check2.BackColor = System.Drawing.SystemColors.Control
        Me.Check2.Cursor = System.Windows.Forms.Cursors.Default
        Me.Check2.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Check2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Check2.Location = New System.Drawing.Point(8, 27)
        Me.Check2.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.Check2.Name = "Check2"
        Me.Check2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Check2.Size = New System.Drawing.Size(152, 17)
        Me.Check2.TabIndex = 61
        Me.Check2.Text = "Scene Screen Mode"
        Me.Check2.UseVisualStyleBackColor = False
        '
        'FrameMegaMan4
        '
        Me.FrameMegaMan4.BackColor = System.Drawing.SystemColors.Control
        Me.FrameMegaMan4.Controls.Add(Me.Command2)
        Me.FrameMegaMan4.Controls.Add(Me.Text12)
        Me.FrameMegaMan4.Controls.Add(Me.Label23)
        Me.FrameMegaMan4.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FrameMegaMan4.ForeColor = System.Drawing.SystemColors.ControlText
        Me.FrameMegaMan4.Location = New System.Drawing.Point(309, 164)
        Me.FrameMegaMan4.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.FrameMegaMan4.Name = "FrameMegaMan4"
        Me.FrameMegaMan4.Padding = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.FrameMegaMan4.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.FrameMegaMan4.Size = New System.Drawing.Size(232, 41)
        Me.FrameMegaMan4.TabIndex = 53
        Me.FrameMegaMan4.TabStop = False
        Me.FrameMegaMan4.Text = " Megaman 4 "
        Me.FrameMegaMan4.Visible = False
        '
        'Command2
        '
        Me.Command2.BackColor = System.Drawing.SystemColors.Control
        Me.Command2.Cursor = System.Windows.Forms.Cursors.Default
        Me.Command2.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Command2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Command2.Location = New System.Drawing.Point(179, 17)
        Me.Command2.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.Command2.Name = "Command2"
        Me.Command2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Command2.Size = New System.Drawing.Size(32, 20)
        Me.Command2.TabIndex = 56
        Me.Command2.Text = "Do"
        Me.Command2.UseVisualStyleBackColor = False
        '
        'Text12
        '
        Me.Text12.AcceptsReturn = True
        Me.Text12.BackColor = System.Drawing.SystemColors.Window
        Me.Text12.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.Text12.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Text12.ForeColor = System.Drawing.SystemColors.WindowText
        Me.Text12.Location = New System.Drawing.Point(134, 17)
        Me.Text12.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.Text12.MaxLength = 0
        Me.Text12.Name = "Text12"
        Me.Text12.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Text12.Size = New System.Drawing.Size(42, 23)
        Me.Text12.TabIndex = 55
        Me.Text12.Text = "1"
        '
        'Label23
        '
        Me.Label23.BackColor = System.Drawing.SystemColors.Control
        Me.Label23.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label23.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label23.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label23.Location = New System.Drawing.Point(8, 17)
        Me.Label23.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label23.Name = "Label23"
        Me.Label23.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label23.Size = New System.Drawing.Size(145, 17)
        Me.Label23.TabIndex = 54
        Me.Label23.Text = "Load Scroll-GL ID:"
        '
        'FrameMegaMan6
        '
        Me.FrameMegaMan6.BackColor = System.Drawing.SystemColors.Control
        Me.FrameMegaMan6.Controls.Add(Me.Command12)
        Me.FrameMegaMan6.Controls.Add(Me.Text13)
        Me.FrameMegaMan6.Controls.Add(Me.Label24)
        Me.FrameMegaMan6.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FrameMegaMan6.ForeColor = System.Drawing.SystemColors.ControlText
        Me.FrameMegaMan6.Location = New System.Drawing.Point(309, 164)
        Me.FrameMegaMan6.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.FrameMegaMan6.Name = "FrameMegaMan6"
        Me.FrameMegaMan6.Padding = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.FrameMegaMan6.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.FrameMegaMan6.Size = New System.Drawing.Size(232, 41)
        Me.FrameMegaMan6.TabIndex = 57
        Me.FrameMegaMan6.TabStop = False
        Me.FrameMegaMan6.Text = " Megaman 6 "
        Me.FrameMegaMan6.Visible = False
        '
        'Command12
        '
        Me.Command12.BackColor = System.Drawing.SystemColors.Control
        Me.Command12.Cursor = System.Windows.Forms.Cursors.Default
        Me.Command12.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Command12.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Command12.Location = New System.Drawing.Point(179, 17)
        Me.Command12.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.Command12.Name = "Command12"
        Me.Command12.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Command12.Size = New System.Drawing.Size(32, 20)
        Me.Command12.TabIndex = 60
        Me.Command12.Text = "Do"
        Me.Command12.UseVisualStyleBackColor = False
        '
        'Text13
        '
        Me.Text13.AcceptsReturn = True
        Me.Text13.BackColor = System.Drawing.SystemColors.Window
        Me.Text13.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.Text13.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Text13.ForeColor = System.Drawing.SystemColors.WindowText
        Me.Text13.Location = New System.Drawing.Point(134, 17)
        Me.Text13.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.Text13.MaxLength = 0
        Me.Text13.Name = "Text13"
        Me.Text13.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Text13.Size = New System.Drawing.Size(42, 23)
        Me.Text13.TabIndex = 59
        Me.Text13.Text = "0"
        '
        'Label24
        '
        Me.Label24.BackColor = System.Drawing.SystemColors.Control
        Me.Label24.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label24.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label24.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label24.Location = New System.Drawing.Point(8, 17)
        Me.Label24.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label24.Name = "Label24"
        Me.Label24.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label24.Size = New System.Drawing.Size(138, 17)
        Me.Label24.TabIndex = 58
        Me.Label24.Text = "Load CHR-Load ID:"
        '
        'Frame5
        '
        Me.Frame5.BackColor = System.Drawing.SystemColors.Control
        Me.Frame5.Controls.Add(Me.Command18)
        Me.Frame5.Controls.Add(Me.Label12)
        Me.Frame5.Controls.Add(Me.Command17)
        Me.Frame5.Controls.Add(Me.Command16)
        Me.Frame5.Controls.Add(Me.Text1)
        Me.Frame5.Controls.Add(Me.Text2)
        Me.Frame5.Controls.Add(Me.Text10)
        Me.Frame5.Controls.Add(Me.Command13)
        Me.Frame5.Controls.Add(Me.Label2)
        Me.Frame5.Controls.Add(Me.Label1)
        Me.Frame5.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Frame5.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Frame5.Location = New System.Drawing.Point(309, 331)
        Me.Frame5.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.Frame5.Name = "Frame5"
        Me.Frame5.Padding = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.Frame5.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Frame5.Size = New System.Drawing.Size(225, 137)
        Me.Frame5.TabIndex = 45
        Me.Frame5.TabStop = False
        Me.Frame5.Text = "ROM Memory Extract/Insert"
        '
        'Command18
        '
        Me.Command18.BackColor = System.Drawing.SystemColors.Control
        Me.Command18.Cursor = System.Windows.Forms.Cursors.Default
        Me.Command18.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Command18.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Command18.Location = New System.Drawing.Point(27, 111)
        Me.Command18.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.Command18.Name = "Command18"
        Me.Command18.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Command18.Size = New System.Drawing.Size(152, 21)
        Me.Command18.TabIndex = 70
        Me.Command18.Text = "Reload .DAT file"
        Me.Command18.UseVisualStyleBackColor = False
        '
        'Label12
        '
        Me.Label12.BackColor = System.Drawing.SystemColors.Control
        Me.Label12.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label12.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label12.Location = New System.Drawing.Point(16, 65)
        Me.Label12.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label12.Name = "Label12"
        Me.Label12.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label12.Size = New System.Drawing.Size(72, 21)
        Me.Label12.TabIndex = 63
        Me.Label12.Text = "Filename:"
        '
        'Command17
        '
        Me.Command17.BackColor = System.Drawing.SystemColors.Control
        Me.Command17.Cursor = System.Windows.Forms.Cursors.Default
        Me.Command17.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Command17.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Command17.Location = New System.Drawing.Point(112, 87)
        Me.Command17.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.Command17.Name = "Command17"
        Me.Command17.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Command17.Size = New System.Drawing.Size(105, 21)
        Me.Command17.TabIndex = 52
        Me.Command17.Text = "ROM Insert"
        Me.Command17.UseVisualStyleBackColor = False
        '
        'Command16
        '
        Me.Command16.BackColor = System.Drawing.SystemColors.Control
        Me.Command16.Cursor = System.Windows.Forms.Cursors.Default
        Me.Command16.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Command16.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Command16.Location = New System.Drawing.Point(8, 87)
        Me.Command16.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.Command16.Name = "Command16"
        Me.Command16.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Command16.Size = New System.Drawing.Size(105, 21)
        Me.Command16.TabIndex = 51
        Me.Command16.Text = "ROM Extract"
        Me.Command16.UseVisualStyleBackColor = False
        '
        'Text1
        '
        Me.Text1.AcceptsReturn = True
        Me.Text1.BackColor = System.Drawing.SystemColors.Window
        Me.Text1.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.Text1.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Text1.ForeColor = System.Drawing.SystemColors.WindowText
        Me.Text1.Location = New System.Drawing.Point(56, 25)
        Me.Text1.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.Text1.MaxLength = 0
        Me.Text1.Name = "Text1"
        Me.Text1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Text1.Size = New System.Drawing.Size(56, 23)
        Me.Text1.TabIndex = 49
        Me.Text1.Text = "0"
        '
        'Text2
        '
        Me.Text2.AcceptsReturn = True
        Me.Text2.BackColor = System.Drawing.SystemColors.Window
        Me.Text2.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.Text2.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Text2.ForeColor = System.Drawing.SystemColors.WindowText
        Me.Text2.Location = New System.Drawing.Point(56, 41)
        Me.Text2.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.Text2.MaxLength = 0
        Me.Text2.Name = "Text2"
        Me.Text2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Text2.Size = New System.Drawing.Size(56, 23)
        Me.Text2.TabIndex = 48
        Me.Text2.Text = "0"
        '
        'Text10
        '
        Me.Text10.AcceptsReturn = True
        Me.Text10.BackColor = System.Drawing.SystemColors.Window
        Me.Text10.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.Text10.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Text10.ForeColor = System.Drawing.SystemColors.WindowText
        Me.Text10.Location = New System.Drawing.Point(96, 65)
        Me.Text10.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.Text10.MaxLength = 0
        Me.Text10.Name = "Text10"
        Me.Text10.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Text10.Size = New System.Drawing.Size(113, 23)
        Me.Text10.TabIndex = 47
        Me.Text10.Text = "dump.hex"
        '
        'Command13
        '
        Me.Command13.BackColor = System.Drawing.SystemColors.Control
        Me.Command13.Cursor = System.Windows.Forms.Cursors.Default
        Me.Command13.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Command13.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Command13.Location = New System.Drawing.Point(112, 41)
        Me.Command13.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.Command13.Name = "Command13"
        Me.Command13.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Command13.Size = New System.Drawing.Size(67, 23)
        Me.Command13.TabIndex = 46
        Me.Command13.Text = "LOF - 1"
        Me.Command13.UseVisualStyleBackColor = False
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.SystemColors.Control
        Me.Label2.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label2.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label2.Location = New System.Drawing.Point(16, 41)
        Me.Label2.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label2.Size = New System.Drawing.Size(72, 23)
        Me.Label2.TabIndex = 62
        Me.Label2.Text = "To:"
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.SystemColors.Control
        Me.Label1.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label1.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label1.Location = New System.Drawing.Point(16, 25)
        Me.Label1.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label1.Size = New System.Drawing.Size(41, 17)
        Me.Label1.TabIndex = 50
        Me.Label1.Text = "From:"
        '
        'CurLevCombo
        '
        Me.CurLevCombo.BackColor = System.Drawing.SystemColors.Window
        Me.CurLevCombo.Cursor = System.Windows.Forms.Cursors.Default
        Me.CurLevCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CurLevCombo.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CurLevCombo.ForeColor = System.Drawing.SystemColors.WindowText
        Me.CurLevCombo.Location = New System.Drawing.Point(8, 71)
        Me.CurLevCombo.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.CurLevCombo.Name = "CurLevCombo"
        Me.CurLevCombo.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.CurLevCombo.Size = New System.Drawing.Size(216, 26)
        Me.CurLevCombo.TabIndex = 20
        '
        'Frame2
        '
        Me.Frame2.BackColor = System.Drawing.SystemColors.Control
        Me.Frame2.Controls.Add(Me.Label16)
        Me.Frame2.Controls.Add(Me.File1)
        Me.Frame2.Controls.Add(Me.Text14)
        Me.Frame2.Controls.Add(Me.Command4)
        Me.Frame2.Controls.Add(Me.Command1)
        Me.Frame2.Controls.Add(Me.OffsDatTB)
        Me.Frame2.Controls.Add(Me.OffsTypeCombo)
        Me.Frame2.Controls.Add(Me.Label3)
        Me.Frame2.Controls.Add(Me.Line1)
        Me.Frame2.Controls.Add(Me.Label11)
        Me.Frame2.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Frame2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Frame2.Location = New System.Drawing.Point(8, 117)
        Me.Frame2.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.Frame2.Name = "Frame2"
        Me.Frame2.Padding = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.Frame2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Frame2.Size = New System.Drawing.Size(281, 212)
        Me.Frame2.TabIndex = 8
        Me.Frame2.TabStop = False
        Me.Frame2.Text = "Level Data Pointer Mod"
        '
        'Label16
        '
        Me.Label16.BackColor = System.Drawing.SystemColors.Control
        Me.Label16.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label16.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label16.Location = New System.Drawing.Point(8, 41)
        Me.Label16.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label16.Name = "Label16"
        Me.Label16.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label16.Size = New System.Drawing.Size(52, 22)
        Me.Label16.TabIndex = 70
        Me.Label16.Text = "Value:"
        '
        'File1
        '
        Me.File1.BackColor = System.Drawing.SystemColors.Window
        Me.File1.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader1, Me.ColumnHeader2})
        Me.File1.Cursor = System.Windows.Forms.Cursors.Default
        Me.File1.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.File1.ForeColor = System.Drawing.SystemColors.WindowText
        Me.File1.FullRowSelect = True
        Me.File1.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None
        Me.File1.HideSelection = False
        Me.File1.Location = New System.Drawing.Point(16, 121)
        Me.File1.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.File1.MultiSelect = False
        Me.File1.Name = "File1"
        Me.File1.Size = New System.Drawing.Size(242, 84)
        Me.File1.TabIndex = 68
        Me.File1.UseCompatibleStateImageBehavior = False
        Me.File1.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader1
        '
        Me.ColumnHeader1.Width = 500
        '
        'ColumnHeader2
        '
        Me.ColumnHeader2.Width = 500
        '
        'Text14
        '
        Me.Text14.AcceptsReturn = True
        Me.Text14.BackColor = System.Drawing.SystemColors.Window
        Me.Text14.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.Text14.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Text14.ForeColor = System.Drawing.SystemColors.WindowText
        Me.Text14.Location = New System.Drawing.Point(16, 97)
        Me.Text14.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.Text14.MaxLength = 0
        Me.Text14.Name = "Text14"
        Me.Text14.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Text14.Size = New System.Drawing.Size(242, 23)
        Me.Text14.TabIndex = 67
        Me.Text14.Text = "offs.ofs"
        '
        'Command4
        '
        Me.Command4.BackColor = System.Drawing.SystemColors.Control
        Me.Command4.Cursor = System.Windows.Forms.Cursors.Default
        Me.Command4.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Command4.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Command4.Location = New System.Drawing.Point(208, 76)
        Me.Command4.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.Command4.Name = "Command4"
        Me.Command4.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Command4.Size = New System.Drawing.Size(49, 20)
        Me.Command4.TabIndex = 66
        Me.Command4.Text = "Load"
        Me.Command4.UseVisualStyleBackColor = False
        '
        'Command1
        '
        Me.Command1.BackColor = System.Drawing.SystemColors.Control
        Me.Command1.Cursor = System.Windows.Forms.Cursors.Default
        Me.Command1.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Command1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Command1.Location = New System.Drawing.Point(160, 76)
        Me.Command1.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.Command1.Name = "Command1"
        Me.Command1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Command1.Size = New System.Drawing.Size(49, 20)
        Me.Command1.TabIndex = 65
        Me.Command1.Text = "Save"
        Me.Command1.UseVisualStyleBackColor = False
        '
        'OffsTypeCombo
        '
        Me.OffsTypeCombo.BackColor = System.Drawing.SystemColors.Window
        Me.OffsTypeCombo.Cursor = System.Windows.Forms.Cursors.Default
        Me.OffsTypeCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.OffsTypeCombo.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.OffsTypeCombo.ForeColor = System.Drawing.SystemColors.WindowText
        Me.OffsTypeCombo.Location = New System.Drawing.Point(96, 17)
        Me.OffsTypeCombo.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.OffsTypeCombo.Name = "OffsTypeCombo"
        Me.OffsTypeCombo.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.OffsTypeCombo.Size = New System.Drawing.Size(136, 24)
        Me.OffsTypeCombo.TabIndex = 17
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.SystemColors.Control
        Me.Label3.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label3.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label3.Location = New System.Drawing.Point(8, 81)
        Me.Label3.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label3.Size = New System.Drawing.Size(192, 17)
        Me.Label3.TabIndex = 64
        Me.Label3.Text = "Setting Save/Load:"
        '
        'Line1
        '
        Me.Line1.BackColor = System.Drawing.SystemColors.WindowText
        Me.Line1.Location = New System.Drawing.Point(8, 68)
        Me.Line1.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Line1.Name = "Line1"
        Me.Line1.Size = New System.Drawing.Size(256, 1)
        Me.Line1.TabIndex = 69
        '
        'Label11
        '
        Me.Label11.BackColor = System.Drawing.SystemColors.Control
        Me.Label11.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label11.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label11.Location = New System.Drawing.Point(8, 17)
        Me.Label11.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label11.Name = "Label11"
        Me.Label11.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label11.Size = New System.Drawing.Size(81, 21)
        Me.Label11.TabIndex = 9
        Me.Label11.Text = "Offs Type:"
        '
        'Frame1
        '
        Me.Frame1.BackColor = System.Drawing.SystemColors.Control
        Me.Frame1.Controls.Add(Me.Label13)
        Me.Frame1.Controls.Add(Me.PatDataTB)
        Me.Frame1.Controls.Add(Me.PatGetDataBtn)
        Me.Frame1.Controls.Add(Me.Command8)
        Me.Frame1.Controls.Add(Me._Command3_1)
        Me.Frame1.Controls.Add(Me._Command3_0)
        Me.Frame1.Controls.Add(Me.PatOffsTB)
        Me.Frame1.Controls.Add(Me.Label8)
        Me.Frame1.Controls.Add(Me.Label7)
        Me.Frame1.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Frame1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Frame1.Location = New System.Drawing.Point(8, 331)
        Me.Frame1.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.Frame1.Name = "Frame1"
        Me.Frame1.Padding = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.Frame1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Frame1.Size = New System.Drawing.Size(281, 137)
        Me.Frame1.TabIndex = 1
        Me.Frame1.TabStop = False
        Me.Frame1.Text = "ROM Memory Hex Patcher"
        '
        'Label13
        '
        Me.Label13.BackColor = System.Drawing.SystemColors.Control
        Me.Label13.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label13.Font = New System.Drawing.Font("Lucida Console", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label13.Location = New System.Drawing.Point(84, 43)
        Me.Label13.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label13.Name = "Label13"
        Me.Label13.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label13.Size = New System.Drawing.Size(189, 15)
        Me.Label13.TabIndex = 17
        Me.Label13.Text = "Note: Offset is base 1"
        '
        'PatGetDataBtn
        '
        Me.PatGetDataBtn.BackColor = System.Drawing.SystemColors.Control
        Me.PatGetDataBtn.Cursor = System.Windows.Forms.Cursors.Default
        Me.PatGetDataBtn.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.PatGetDataBtn.ForeColor = System.Drawing.SystemColors.ControlText
        Me.PatGetDataBtn.Location = New System.Drawing.Point(8, 38)
        Me.PatGetDataBtn.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.PatGetDataBtn.Name = "PatGetDataBtn"
        Me.PatGetDataBtn.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.PatGetDataBtn.Size = New System.Drawing.Size(72, 20)
        Me.PatGetDataBtn.TabIndex = 16
        Me.PatGetDataBtn.Text = "Get Data"
        Me.PatGetDataBtn.UseVisualStyleBackColor = False
        '
        'Command8
        '
        Me.Command8.BackColor = System.Drawing.SystemColors.Control
        Me.Command8.Cursor = System.Windows.Forms.Cursors.Default
        Me.Command8.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Command8.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Command8.Location = New System.Drawing.Point(120, 17)
        Me.Command8.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.Command8.Name = "Command8"
        Me.Command8.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Command8.Size = New System.Drawing.Size(156, 23)
        Me.Command8.TabIndex = 15
        Me.Command8.Text = "Set to Pointermod OffsType"
        Me.Command8.UseVisualStyleBackColor = False
        '
        '_Command3_1
        '
        Me._Command3_1.BackColor = System.Drawing.SystemColors.Control
        Me._Command3_1.Cursor = System.Windows.Forms.Cursors.Default
        Me._Command3_1.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._Command3_1.ForeColor = System.Drawing.SystemColors.ControlText
        Me._Command3_1.Location = New System.Drawing.Point(8, 113)
        Me._Command3_1.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me._Command3_1.Name = "_Command3_1"
        Me._Command3_1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Command3_1.Size = New System.Drawing.Size(161, 20)
        Me._Command3_1.TabIndex = 7
        Me._Command3_1.Text = "Apply changes (gfx refresh)"
        Me._Command3_1.UseVisualStyleBackColor = False
        '
        '_Command3_0
        '
        Me._Command3_0.BackColor = System.Drawing.SystemColors.Control
        Me._Command3_0.Cursor = System.Windows.Forms.Cursors.Default
        Me._Command3_0.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._Command3_0.ForeColor = System.Drawing.SystemColors.ControlText
        Me._Command3_0.Location = New System.Drawing.Point(8, 94)
        Me._Command3_0.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me._Command3_0.Name = "_Command3_0"
        Me._Command3_0.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Command3_0.Size = New System.Drawing.Size(161, 20)
        Me._Command3_0.TabIndex = 6
        Me._Command3_0.Text = "Apply changes (no refresh)"
        Me._Command3_0.UseVisualStyleBackColor = False
        '
        'Label8
        '
        Me.Label8.BackColor = System.Drawing.SystemColors.Control
        Me.Label8.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label8.Font = New System.Drawing.Font("Lucida Console", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label8.Location = New System.Drawing.Point(8, 58)
        Me.Label8.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label8.Name = "Label8"
        Me.Label8.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label8.Size = New System.Drawing.Size(46, 11)
        Me.Label8.TabIndex = 5
        Me.Label8.Text = "Data:"
        '
        'Label7
        '
        Me.Label7.BackColor = System.Drawing.SystemColors.Control
        Me.Label7.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label7.Font = New System.Drawing.Font("Lucida Console", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label7.Location = New System.Drawing.Point(8, 17)
        Me.Label7.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label7.Name = "Label7"
        Me.Label7.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label7.Size = New System.Drawing.Size(232, 41)
        Me.Label7.TabIndex = 4
        Me.Label7.Text = "Offset:"
        '
        'StatsTimer
        '
        Me.StatsTimer.Interval = 1000
        '
        'Label9
        '
        Me.Label9.BackColor = System.Drawing.SystemColors.Control
        Me.Label9.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label9.Font = New System.Drawing.Font("Arial", 10.0!)
        Me.Label9.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label9.Location = New System.Drawing.Point(8, 50)
        Me.Label9.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label9.Name = "Label9"
        Me.Label9.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label9.Size = New System.Drawing.Size(112, 17)
        Me.Label9.TabIndex = 19
        Me.Label9.Text = "Current Level:"
        '
        '_DumpBM_selection_0
        '
        Me._DumpBM_selection_0.Name = "_DumpBM_selection_0"
        Me._DumpBM_selection_0.Size = New System.Drawing.Size(245, 26)
        Me._DumpBM_selection_0.Text = "Palette (Main)"
        '
        '_DumpBM_selection_1
        '
        Me._DumpBM_selection_1.Name = "_DumpBM_selection_1"
        Me._DumpBM_selection_1.Size = New System.Drawing.Size(245, 26)
        Me._DumpBM_selection_1.Text = "Palette (Animation)"
        '
        '_DumpBM_selection_2
        '
        Me._DumpBM_selection_2.Name = "_DumpBM_selection_2"
        Me._DumpBM_selection_2.Size = New System.Drawing.Size(245, 26)
        Me._DumpBM_selection_2.Text = "Tile Table"
        '
        '_DumpBM_selection_3
        '
        Me._DumpBM_selection_3.Name = "_DumpBM_selection_3"
        Me._DumpBM_selection_3.Size = New System.Drawing.Size(245, 26)
        Me._DumpBM_selection_3.Text = "Tile Editor"
        '
        '_DumpBM_selection_4
        '
        Me._DumpBM_selection_4.Name = "_DumpBM_selection_4"
        Me._DumpBM_selection_4.Size = New System.Drawing.Size(245, 26)
        Me._DumpBM_selection_4.Text = "Metatile Table"
        '
        '_DumpBM_selection_5
        '
        Me._DumpBM_selection_5.Name = "_DumpBM_selection_5"
        Me._DumpBM_selection_5.Size = New System.Drawing.Size(245, 26)
        Me._DumpBM_selection_5.Text = "Metatile Table Palette"
        '
        '_DumpBM_selection_6
        '
        Me._DumpBM_selection_6.Name = "_DumpBM_selection_6"
        Me._DumpBM_selection_6.Size = New System.Drawing.Size(245, 26)
        Me._DumpBM_selection_6.Text = "SBD Editor (Screen)"
        '
        '_DumpBM_selection_7
        '
        Me._DumpBM_selection_7.Name = "_DumpBM_selection_7"
        Me._DumpBM_selection_7.Size = New System.Drawing.Size(245, 26)
        Me._DumpBM_selection_7.Text = "SBD Editor (Object)"
        '
        '_DumpBM_selection_8
        '
        Me._DumpBM_selection_8.Name = "_DumpBM_selection_8"
        Me._DumpBM_selection_8.Size = New System.Drawing.Size(245, 26)
        Me._DumpBM_selection_8.Text = "Metametatile Table"
        '
        '_DumpBM_selection_9
        '
        Me._DumpBM_selection_9.Name = "_DumpBM_selection_9"
        Me._DumpBM_selection_9.Size = New System.Drawing.Size(245, 26)
        Me._DumpBM_selection_9.Text = "Screen Editor"
        '
        '_DumpBM_selection_10
        '
        Me._DumpBM_selection_10.Name = "_DumpBM_selection_10"
        Me._DumpBM_selection_10.Size = New System.Drawing.Size(245, 26)
        Me._DumpBM_selection_10.Text = "Metametatile Current"
        '
        '_DumpBM_selection_11
        '
        Me._DumpBM_selection_11.Name = "_DumpBM_selection_11"
        Me._DumpBM_selection_11.Size = New System.Drawing.Size(245, 26)
        Me._DumpBM_selection_11.Text = "Enemy (Screen)"
        '
        '_DumpBM_selection_12
        '
        Me._DumpBM_selection_12.Name = "_DumpBM_selection_12"
        Me._DumpBM_selection_12.Size = New System.Drawing.Size(245, 26)
        Me._DumpBM_selection_12.Text = "Enemy (Screen) - buf. 2"
        '
        '_DumpBM_selection_13
        '
        Me._DumpBM_selection_13.Name = "_DumpBM_selection_13"
        Me._DumpBM_selection_13.Size = New System.Drawing.Size(245, 26)
        Me._DumpBM_selection_13.Text = "Enemy (Tiles)"
        '
        '_DumpBM_selection_14
        '
        Me._DumpBM_selection_14.Name = "_DumpBM_selection_14"
        Me._DumpBM_selection_14.Size = New System.Drawing.Size(245, 26)
        Me._DumpBM_selection_14.Text = "Enemy (Palette)"
        '
        'MainMenu1
        '
        Me.MainMenu1.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.MainMenu1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.Menu_File, Me.Menu_View, Me.Menu_Other, Me.Menu_Special, Me.Menu_Tools, Me.Menu_Stats, Me.Menu_Dump, Me.Menu_Config})
        Me.MainMenu1.Location = New System.Drawing.Point(0, 0)
        Me.MainMenu1.Name = "MainMenu1"
        Me.MainMenu1.Size = New System.Drawing.Size(560, 28)
        Me.MainMenu1.TabIndex = 70
        '
        'Menu_File
        '
        Me.Menu_File.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.File_Save, Me.File_ReLoad, Me.File_Back, Me.File_Exit})
        Me.Menu_File.Name = "Menu_File"
        Me.Menu_File.Size = New System.Drawing.Size(46, 24)
        Me.Menu_File.Text = "File"
        '
        'File_Save
        '
        Me.File_Save.Name = "File_Save"
        Me.File_Save.ShortcutKeys = System.Windows.Forms.Keys.F5
        Me.File_Save.Size = New System.Drawing.Size(209, 26)
        Me.File_Save.Text = "Save"
        '
        'File_ReLoad
        '
        Me.File_ReLoad.Name = "File_ReLoad"
        Me.File_ReLoad.ShortcutKeys = System.Windows.Forms.Keys.F4
        Me.File_ReLoad.Size = New System.Drawing.Size(209, 26)
        Me.File_ReLoad.Text = "Re-Load ROM"
        '
        'File_Back
        '
        Me.File_Back.Name = "File_Back"
        Me.File_Back.ShortcutKeys = System.Windows.Forms.Keys.F3
        Me.File_Back.Size = New System.Drawing.Size(209, 26)
        Me.File_Back.Text = "Load Backup"
        '
        'File_Exit
        '
        Me.File_Exit.Name = "File_Exit"
        Me.File_Exit.Size = New System.Drawing.Size(209, 26)
        Me.File_Exit.Text = "Exit"
        '
        'Menu_View
        '
        Me.Menu_View.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.View_PalEd, Me.View_SBD, Me.View_TT, Me.View_TSAT, Me.View_StrT, Me.View_ScreenEd, Me.View_EnemEd, Me.View_DoorEd, Me.Level_Misc, Me.Level_bl0, Me.Level_Next, Me.Level_Previous})
        Me.Menu_View.Name = "Menu_View"
        Me.Menu_View.Size = New System.Drawing.Size(57, 24)
        Me.Menu_View.Text = "Level"
        '
        'View_PalEd
        '
        Me.View_PalEd.Name = "View_PalEd"
        Me.View_PalEd.Size = New System.Drawing.Size(224, 26)
        Me.View_PalEd.Text = "Palette Editor"
        '
        'View_SBD
        '
        Me.View_SBD.Name = "View_SBD"
        Me.View_SBD.Size = New System.Drawing.Size(224, 26)
        Me.View_SBD.Text = "SBD Editor"
        '
        'View_TT
        '
        Me.View_TT.Name = "View_TT"
        Me.View_TT.Size = New System.Drawing.Size(224, 26)
        Me.View_TT.Text = "Tile Table"
        '
        'View_TSAT
        '
        Me.View_TSAT.Name = "View_TSAT"
        Me.View_TSAT.Size = New System.Drawing.Size(224, 26)
        Me.View_TSAT.Text = "Metatile Table"
        '
        'View_StrT
        '
        Me.View_StrT.Name = "View_StrT"
        Me.View_StrT.Size = New System.Drawing.Size(224, 26)
        Me.View_StrT.Text = "Metametatile Table"
        '
        'View_ScreenEd
        '
        Me.View_ScreenEd.Name = "View_ScreenEd"
        Me.View_ScreenEd.Size = New System.Drawing.Size(224, 26)
        Me.View_ScreenEd.Text = "Screen Editor"
        '
        'View_EnemEd
        '
        Me.View_EnemEd.Name = "View_EnemEd"
        Me.View_EnemEd.Size = New System.Drawing.Size(224, 26)
        Me.View_EnemEd.Text = "Enemy Editor"
        '
        'View_DoorEd
        '
        Me.View_DoorEd.Name = "View_DoorEd"
        Me.View_DoorEd.Size = New System.Drawing.Size(224, 26)
        Me.View_DoorEd.Text = "Door Editor"
        '
        'Level_Misc
        '
        Me.Level_Misc.Name = "Level_Misc"
        Me.Level_Misc.Size = New System.Drawing.Size(224, 26)
        Me.Level_Misc.Text = "Miscellaneous"
        '
        'Level_bl0
        '
        Me.Level_bl0.Name = "Level_bl0"
        Me.Level_bl0.Size = New System.Drawing.Size(221, 6)
        '
        'Level_Next
        '
        Me.Level_Next.Name = "Level_Next"
        Me.Level_Next.ShortcutKeys = System.Windows.Forms.Keys.F7
        Me.Level_Next.Size = New System.Drawing.Size(224, 26)
        Me.Level_Next.Text = "Next"
        '
        'Level_Previous
        '
        Me.Level_Previous.Name = "Level_Previous"
        Me.Level_Previous.ShortcutKeys = System.Windows.Forms.Keys.F6
        Me.Level_Previous.Size = New System.Drawing.Size(224, 26)
        Me.Level_Previous.Text = "Previous"
        '
        'Menu_Other
        '
        Me.Menu_Other.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.Other_GfxLoadEd, Me.Other_TextEd, Me.Other_Patches, Me.ToolStripSeparator2, Me.AboutToolStripMenuItem})
        Me.Menu_Other.Name = "Menu_Other"
        Me.Menu_Other.Size = New System.Drawing.Size(60, 24)
        Me.Menu_Other.Text = "Other"
        '
        'Other_GfxLoadEd
        '
        Me.Other_GfxLoadEd.Name = "Other_GfxLoadEd"
        Me.Other_GfxLoadEd.Size = New System.Drawing.Size(230, 26)
        Me.Other_GfxLoadEd.Text = "Graphics Load Editor"
        '
        'Other_TextEd
        '
        Me.Other_TextEd.Name = "Other_TextEd"
        Me.Other_TextEd.Size = New System.Drawing.Size(230, 26)
        Me.Other_TextEd.Text = "Text Editor"
        '
        'Other_Patches
        '
        Me.Other_Patches.Name = "Other_Patches"
        Me.Other_Patches.Size = New System.Drawing.Size(230, 26)
        Me.Other_Patches.Text = "Patches"
        '
        'AboutToolStripMenuItem
        '
        Me.AboutToolStripMenuItem.Name = "AboutToolStripMenuItem"
        Me.AboutToolStripMenuItem.Size = New System.Drawing.Size(230, 26)
        Me.AboutToolStripMenuItem.Text = "About"
        '
        'Menu_Special
        '
        Me.Menu_Special.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.Special_Chargeman})
        Me.Menu_Special.Name = "Menu_Special"
        Me.Menu_Special.Size = New System.Drawing.Size(71, 24)
        Me.Menu_Special.Text = "Special"
        '
        'Special_Chargeman
        '
        Me.Special_Chargeman.Name = "Special_Chargeman"
        Me.Special_Chargeman.Size = New System.Drawing.Size(351, 26)
        Me.Special_Chargeman.Text = "Load Chargeman train interior graphics"
        '
        'Menu_Tools
        '
        Me.Menu_Tools.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.Tools_Test, Me.Tools_RunShell, Me.Tools_bl0, Me.Tools_ConvSCR})
        Me.Menu_Tools.Name = "Menu_Tools"
        Me.Menu_Tools.Size = New System.Drawing.Size(58, 24)
        Me.Menu_Tools.Text = "Tools"
        '
        'Tools_Test
        '
        Me.Tools_Test.Name = "Tools_Test"
        Me.Tools_Test.ShortcutKeys = System.Windows.Forms.Keys.F9
        Me.Tools_Test.Size = New System.Drawing.Size(299, 26)
        Me.Tools_Test.Text = "Test!"
        '
        'Tools_RunShell
        '
        Me.Tools_RunShell.Name = "Tools_RunShell"
        Me.Tools_RunShell.ShortcutKeys = System.Windows.Forms.Keys.F11
        Me.Tools_RunShell.Size = New System.Drawing.Size(299, 26)
        Me.Tools_RunShell.Text = "Run Shell Command"
        '
        'Tools_bl0
        '
        Me.Tools_bl0.Name = "Tools_bl0"
        Me.Tools_bl0.Size = New System.Drawing.Size(296, 6)
        '
        'Tools_ConvSCR
        '
        Me.Tools_ConvSCR.Name = "Tools_ConvSCR"
        Me.Tools_ConvSCR.Size = New System.Drawing.Size(299, 26)
        Me.Tools_ConvSCR.Text = "Convert .SCR file to new format"
        '
        'Menu_Stats
        '
        Me.Menu_Stats.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.Stats_EnemUsage})
        Me.Menu_Stats.Name = "Menu_Stats"
        Me.Menu_Stats.Size = New System.Drawing.Size(55, 24)
        Me.Menu_Stats.Text = "Stats"
        '
        'Stats_EnemUsage
        '
        Me.Stats_EnemUsage.Name = "Stats_EnemUsage"
        Me.Stats_EnemUsage.Size = New System.Drawing.Size(200, 26)
        Me.Stats_EnemUsage.Text = "Enemy ID Usage"
        '
        'Menu_Dump
        '
        Me.Menu_Dump.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.Dump_Bitmap})
        Me.Menu_Dump.Name = "Menu_Dump"
        Me.Menu_Dump.Size = New System.Drawing.Size(64, 24)
        Me.Menu_Dump.Text = "Dump"
        '
        'Dump_Bitmap
        '
        Me.Dump_Bitmap.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me._DumpBM_selection_0, Me._DumpBM_selection_1, Me._DumpBM_selection_2, Me._DumpBM_selection_3, Me._DumpBM_selection_4, Me._DumpBM_selection_5, Me._DumpBM_selection_8, Me._DumpBM_selection_10, Me._DumpBM_selection_9, Me._DumpBM_selection_11, Me._DumpBM_selection_12, Me._DumpBM_selection_13, Me._DumpBM_selection_14, Me._DumpBM_selection_6, Me._DumpBM_selection_7})
        Me.Dump_Bitmap.Name = "Dump_Bitmap"
        Me.Dump_Bitmap.Size = New System.Drawing.Size(140, 26)
        Me.Dump_Bitmap.Text = "Bitmap"
        '
        'Menu_Config
        '
        Me.Menu_Config.Name = "Menu_Config"
        Me.Menu_Config.Size = New System.Drawing.Size(67, 24)
        Me.Menu_Config.Text = "Config"
        '
        'lblGamePath1
        '
        Me.lblGamePath1.AutoSize = True
        Me.lblGamePath1.Location = New System.Drawing.Point(13, 485)
        Me.lblGamePath1.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lblGamePath1.Name = "lblGamePath1"
        Me.lblGamePath1.Size = New System.Drawing.Size(138, 17)
        Me.lblGamePath1.TabIndex = 71
        Me.lblGamePath1.Text = "LabelGamePath"
        '
        'lblGamePath2
        '
        Me.lblGamePath2.AutoSize = True
        Me.lblGamePath2.Location = New System.Drawing.Point(13, 502)
        Me.lblGamePath2.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lblGamePath2.Name = "lblGamePath2"
        Me.lblGamePath2.Size = New System.Drawing.Size(138, 17)
        Me.lblGamePath2.TabIndex = 72
        Me.lblGamePath2.Text = "LabelGameMode"
        '
        'picBoxDumping
        '
        Me.picBoxDumping.Location = New System.Drawing.Point(320, 237)
        Me.picBoxDumping.Name = "picBoxDumping"
        Me.picBoxDumping.Size = New System.Drawing.Size(52, 59)
        Me.picBoxDumping.TabIndex = 75
        Me.picBoxDumping.TabStop = False
        Me.picBoxDumping.Visible = False
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.SystemColors.Control
        Me.GroupBox1.Controls.Add(Me.Command15)
        Me.GroupBox1.Controls.Add(Me.Text11)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.GroupBox1.Location = New System.Drawing.Point(309, 117)
        Me.GroupBox1.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Padding = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.GroupBox1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.GroupBox1.Size = New System.Drawing.Size(232, 41)
        Me.GroupBox1.TabIndex = 61
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = " SBD Bank"
        '
        'Command15
        '
        Me.Command15.BackColor = System.Drawing.SystemColors.Control
        Me.Command15.Cursor = System.Windows.Forms.Cursors.Default
        Me.Command15.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Command15.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Command15.Location = New System.Drawing.Point(179, 17)
        Me.Command15.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.Command15.Name = "Command15"
        Me.Command15.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Command15.Size = New System.Drawing.Size(32, 20)
        Me.Command15.TabIndex = 60
        Me.Command15.Text = "Do"
        Me.Command15.UseVisualStyleBackColor = False
        '
        'Text11
        '
        Me.Text11.AcceptsReturn = True
        Me.Text11.BackColor = System.Drawing.SystemColors.Window
        Me.Text11.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.Text11.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Text11.ForeColor = System.Drawing.SystemColors.WindowText
        Me.Text11.Location = New System.Drawing.Point(134, 17)
        Me.Text11.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.Text11.MaxLength = 0
        Me.Text11.Name = "Text11"
        Me.Text11.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Text11.Size = New System.Drawing.Size(42, 23)
        Me.Text11.TabIndex = 59
        Me.Text11.Text = "0"
        '
        'Label6
        '
        Me.Label6.BackColor = System.Drawing.SystemColors.Control
        Me.Label6.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label6.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label6.Location = New System.Drawing.Point(8, 17)
        Me.Label6.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label6.Name = "Label6"
        Me.Label6.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label6.Size = New System.Drawing.Size(138, 17)
        Me.Label6.TabIndex = 58
        Me.Label6.Text = "Force SBD Bank: "
        '
        'btnAbout
        '
        Me.btnAbout.Location = New System.Drawing.Point(428, 486)
        Me.btnAbout.Name = "btnAbout"
        Me.btnAbout.Size = New System.Drawing.Size(106, 23)
        Me.btnAbout.TabIndex = 77
        Me.btnAbout.Text = "About"
        Me.btnAbout.UseVisualStyleBackColor = True
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(227, 6)
        '
        'MFLE_Main
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(10.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.ClientSize = New System.Drawing.Size(560, 521)
        Me.Controls.Add(Me.btnAbout)
        Me.Controls.Add(Me.FrameMegaMan6)
        Me.Controls.Add(Me.FrameMegaMan4)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.LblInformations)
        Me.Controls.Add(Me.picBoxDumping)
        Me.Controls.Add(Me.lblGamePath2)
        Me.Controls.Add(Me.lblGamePath1)
        Me.Controls.Add(Me.Check2)
        Me.Controls.Add(Me.Frame5)
        Me.Controls.Add(Me.CurLevCombo)
        Me.Controls.Add(Me.Frame2)
        Me.Controls.Add(Me.Frame1)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.MainMenu1)
        Me.Cursor = System.Windows.Forms.Cursors.Default
        Me.Font = New System.Drawing.Font("Lucida Console", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.Location = New System.Drawing.Point(11, 37)
        Me.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.Name = "MFLE_Main"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "MegaFLE_X"
        Me.FrameMegaMan4.ResumeLayout(False)
        Me.FrameMegaMan4.PerformLayout()
        Me.FrameMegaMan6.ResumeLayout(False)
        Me.FrameMegaMan6.PerformLayout()
        Me.Frame5.ResumeLayout(False)
        Me.Frame5.PerformLayout()
        Me.Frame2.ResumeLayout(False)
        Me.Frame2.PerformLayout()
        Me.Frame1.ResumeLayout(False)
        Me.Frame1.PerformLayout()
        Me.MainMenu1.ResumeLayout(False)
        Me.MainMenu1.PerformLayout()
        CType(Me.picBoxDumping, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents lblGamePath1 As Label
    Friend WithEvents lblGamePath2 As Label
    Friend WithEvents ColumnHeader1 As ColumnHeader
    Friend WithEvents ColumnHeader2 As ColumnHeader
    Public WithEvents Label12 As Label
    Public WithEvents Label13 As Label
    Public WithEvents Label16 As Label
    Friend WithEvents picBoxDumping As PictureBox
    Friend WithEvents LblInformations As Label
    Public WithEvents Command18 As Button
    Public WithEvents GroupBox1 As GroupBox
    Public WithEvents Command15 As Button
    Public WithEvents Text11 As TextBox
    Public WithEvents Label6 As Label
    Friend WithEvents btnAbout As Button
    Friend WithEvents AboutToolStripMenuItem As ToolStripMenuItem
    Public WithEvents ToolStripSeparator2 As ToolStripSeparator
#End Region
End Class