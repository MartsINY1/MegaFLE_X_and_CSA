<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> Partial Class DoorEd
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
    Public WithEvents _NTBase_3 As System.Windows.Forms.RadioButton
    Public WithEvents _NTBase_1 As System.Windows.Forms.RadioButton
    Public WithEvents _NTBase_2 As System.Windows.Forms.RadioButton
    Public WithEvents _NTBase_0 As System.Windows.Forms.RadioButton
    Public WithEvents Frame2 As System.Windows.Forms.GroupBox
    Public WithEvents TsaPalText As System.Windows.Forms.TextBox
    Public WithEvents _PalBtn_0 As System.Windows.Forms.Button
    Public WithEvents _PalBtn_1 As System.Windows.Forms.Button
    Public WithEvents _PalBtn_2 As System.Windows.Forms.Button
    Public WithEvents _PalBtn_3 As System.Windows.Forms.Button
    Public WithEvents PaletteFrame As System.Windows.Forms.GroupBox
    Public WithEvents TsaIdText As System.Windows.Forms.TextBox
    Public WithEvents SetToCurTsa As System.Windows.Forms.Button
    Public WithEvents Label2 As System.Windows.Forms.Label
    Public WithEvents Frame1 As System.Windows.Forms.GroupBox
    Public WithEvents _WTMOpt_0 As System.Windows.Forms.RadioButton
    Public WithEvents _WTMOpt_1 As System.Windows.Forms.RadioButton
    Public WithEvents Frame4 As System.Windows.Forms.GroupBox
    Public WithEvents _TSASelect_7 As System.Windows.Forms.RadioButton
    Public WithEvents _TSASelect_6 As System.Windows.Forms.RadioButton
    Public WithEvents _TSASelect_5 As System.Windows.Forms.RadioButton
    Public WithEvents _TSASelect_4 As System.Windows.Forms.RadioButton
    Public WithEvents _TSASelect_3 As System.Windows.Forms.RadioButton
    Public WithEvents _TSASelect_2 As System.Windows.Forms.RadioButton
    Public WithEvents _TSASelect_1 As System.Windows.Forms.RadioButton
    Public WithEvents _TSAPic_7 As System.Windows.Forms.PictureBox
    Public WithEvents _TSAPic_6 As System.Windows.Forms.PictureBox
    Public WithEvents _TSAPic_5 As System.Windows.Forms.PictureBox
    Public WithEvents _TSAPic_4 As System.Windows.Forms.PictureBox
    Public WithEvents _TSAPic_3 As System.Windows.Forms.PictureBox
    Public WithEvents _TSAPic_2 As System.Windows.Forms.PictureBox
    Public WithEvents _TSAPic_1 As System.Windows.Forms.PictureBox
    Public WithEvents PresetTB As System.Windows.Forms.TextBox
    Public WithEvents DPScreenTB As System.Windows.Forms.TextBox
    Public WithEvents Line1 As System.Windows.Forms.Label
    Public WithEvents Label8 As System.Windows.Forms.Label
    Public WithEvents Label6 As System.Windows.Forms.Label
    Public WithEvents MM3Frame2 As System.Windows.Forms.GroupBox
    Public WithEvents ScreenScroll As System.Windows.Forms.HScrollBar
    Public WithEvents _DoorPointOpt_1 As System.Windows.Forms.RadioButton
    Public WithEvents _DoorPointOpt_0 As System.Windows.Forms.RadioButton
    Public WithEvents Label9 As System.Windows.Forms.Label
    Public WithEvents MM3Frame1 As System.Windows.Forms.GroupBox
    Public WithEvents _TSASelect_0 As System.Windows.Forms.RadioButton
    Public WithEvents _TSAPic_0 As System.Windows.Forms.PictureBox
    Public WithEvents OpenShape As System.Windows.Forms.Label
    Public WithEvents CloseShape As System.Windows.Forms.Label
    Public WithEvents Label5 As System.Windows.Forms.Label
    Public WithEvents Label4 As System.Windows.Forms.Label
    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(DoorEd))
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.Frame2 = New System.Windows.Forms.GroupBox()
        Me._NTBase_3 = New System.Windows.Forms.RadioButton()
        Me._NTBase_1 = New System.Windows.Forms.RadioButton()
        Me._NTBase_2 = New System.Windows.Forms.RadioButton()
        Me._NTBase_0 = New System.Windows.Forms.RadioButton()
        Me.PaletteFrame = New System.Windows.Forms.GroupBox()
        Me.TsaPalText = New System.Windows.Forms.TextBox()
        Me._PalBtn_0 = New System.Windows.Forms.Button()
        Me._PalBtn_1 = New System.Windows.Forms.Button()
        Me._PalBtn_2 = New System.Windows.Forms.Button()
        Me._PalBtn_3 = New System.Windows.Forms.Button()
        Me.Frame1 = New System.Windows.Forms.GroupBox()
        Me.TsaIdText = New System.Windows.Forms.TextBox()
        Me.SetToCurTsa = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Frame4 = New System.Windows.Forms.GroupBox()
        Me._WTMOpt_0 = New System.Windows.Forms.RadioButton()
        Me._WTMOpt_1 = New System.Windows.Forms.RadioButton()
        Me._TSASelect_7 = New System.Windows.Forms.RadioButton()
        Me._TSASelect_6 = New System.Windows.Forms.RadioButton()
        Me._TSASelect_5 = New System.Windows.Forms.RadioButton()
        Me._TSASelect_4 = New System.Windows.Forms.RadioButton()
        Me._TSASelect_3 = New System.Windows.Forms.RadioButton()
        Me._TSASelect_2 = New System.Windows.Forms.RadioButton()
        Me._TSASelect_1 = New System.Windows.Forms.RadioButton()
        Me._TSAPic_7 = New System.Windows.Forms.PictureBox()
        Me._TSAPic_6 = New System.Windows.Forms.PictureBox()
        Me._TSAPic_5 = New System.Windows.Forms.PictureBox()
        Me._TSAPic_4 = New System.Windows.Forms.PictureBox()
        Me._TSAPic_3 = New System.Windows.Forms.PictureBox()
        Me._TSAPic_2 = New System.Windows.Forms.PictureBox()
        Me._TSAPic_1 = New System.Windows.Forms.PictureBox()
        Me.MM3Frame2 = New System.Windows.Forms.GroupBox()
        Me.PresetTB = New System.Windows.Forms.TextBox()
        Me.DPScreenTB = New System.Windows.Forms.TextBox()
        Me.Line1 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.MM3Frame1 = New System.Windows.Forms.GroupBox()
        Me.ScreenScroll = New System.Windows.Forms.HScrollBar()
        Me._DoorPointOpt_1 = New System.Windows.Forms.RadioButton()
        Me._DoorPointOpt_0 = New System.Windows.Forms.RadioButton()
        Me.Label9 = New System.Windows.Forms.Label()
        Me._TSASelect_0 = New System.Windows.Forms.RadioButton()
        Me._TSAPic_0 = New System.Windows.Forms.PictureBox()
        Me.OpenShape = New System.Windows.Forms.Label()
        Me.CloseShape = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.PicBGShape = New System.Windows.Forms.PictureBox()
        Me.Frame2.SuspendLayout()
        Me.PaletteFrame.SuspendLayout()
        Me.Frame1.SuspendLayout()
        Me.Frame4.SuspendLayout()
        CType(Me._TSAPic_7, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me._TSAPic_6, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me._TSAPic_5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me._TSAPic_4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me._TSAPic_3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me._TSAPic_2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me._TSAPic_1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.MM3Frame2.SuspendLayout()
        Me.MM3Frame1.SuspendLayout()
        CType(Me._TSAPic_0, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PicBGShape, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Frame2
        '
        Me.Frame2.BackColor = System.Drawing.SystemColors.Control
        Me.Frame2.Controls.Add(Me._NTBase_3)
        Me.Frame2.Controls.Add(Me._NTBase_1)
        Me.Frame2.Controls.Add(Me._NTBase_2)
        Me.Frame2.Controls.Add(Me._NTBase_0)
        Me.Frame2.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Frame2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Frame2.Location = New System.Drawing.Point(336, 8)
        Me.Frame2.Name = "Frame2"
        Me.Frame2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Frame2.Size = New System.Drawing.Size(137, 57)
        Me.Frame2.TabIndex = 41
        Me.Frame2.TabStop = False
        Me.Frame2.Text = " Nametable Base Addr. "
        Me.Frame2.Visible = False
        '
        '_NTBase_3
        '
        Me._NTBase_3.BackColor = System.Drawing.SystemColors.Control
        Me._NTBase_3.Cursor = System.Windows.Forms.Cursors.Default
        Me._NTBase_3.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._NTBase_3.ForeColor = System.Drawing.SystemColors.ControlText
        Me._NTBase_3.Location = New System.Drawing.Point(72, 32)
        Me._NTBase_3.Name = "_NTBase_3"
        Me._NTBase_3.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._NTBase_3.Size = New System.Drawing.Size(57, 17)
        Me._NTBase_3.TabIndex = 45
        Me._NTBase_3.TabStop = True
        Me._NTBase_3.Text = "2C00"
        Me._NTBase_3.UseVisualStyleBackColor = False
        '
        '_NTBase_1
        '
        Me._NTBase_1.BackColor = System.Drawing.SystemColors.Control
        Me._NTBase_1.Cursor = System.Windows.Forms.Cursors.Default
        Me._NTBase_1.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._NTBase_1.ForeColor = System.Drawing.SystemColors.ControlText
        Me._NTBase_1.Location = New System.Drawing.Point(72, 16)
        Me._NTBase_1.Name = "_NTBase_1"
        Me._NTBase_1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._NTBase_1.Size = New System.Drawing.Size(57, 17)
        Me._NTBase_1.TabIndex = 44
        Me._NTBase_1.TabStop = True
        Me._NTBase_1.Text = "2400"
        Me._NTBase_1.UseVisualStyleBackColor = False
        '
        '_NTBase_2
        '
        Me._NTBase_2.BackColor = System.Drawing.SystemColors.Control
        Me._NTBase_2.Cursor = System.Windows.Forms.Cursors.Default
        Me._NTBase_2.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._NTBase_2.ForeColor = System.Drawing.SystemColors.ControlText
        Me._NTBase_2.Location = New System.Drawing.Point(8, 32)
        Me._NTBase_2.Name = "_NTBase_2"
        Me._NTBase_2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._NTBase_2.Size = New System.Drawing.Size(57, 17)
        Me._NTBase_2.TabIndex = 43
        Me._NTBase_2.TabStop = True
        Me._NTBase_2.Text = "2800"
        Me._NTBase_2.UseVisualStyleBackColor = False
        '
        '_NTBase_0
        '
        Me._NTBase_0.BackColor = System.Drawing.SystemColors.Control
        Me._NTBase_0.Cursor = System.Windows.Forms.Cursors.Default
        Me._NTBase_0.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._NTBase_0.ForeColor = System.Drawing.SystemColors.ControlText
        Me._NTBase_0.Location = New System.Drawing.Point(8, 16)
        Me._NTBase_0.Name = "_NTBase_0"
        Me._NTBase_0.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._NTBase_0.Size = New System.Drawing.Size(57, 17)
        Me._NTBase_0.TabIndex = 42
        Me._NTBase_0.TabStop = True
        Me._NTBase_0.Text = "2000"
        Me._NTBase_0.UseVisualStyleBackColor = False
        '
        'PaletteFrame
        '
        Me.PaletteFrame.BackColor = System.Drawing.SystemColors.Control
        Me.PaletteFrame.Controls.Add(Me.TsaPalText)
        Me.PaletteFrame.Controls.Add(Me._PalBtn_0)
        Me.PaletteFrame.Controls.Add(Me._PalBtn_1)
        Me.PaletteFrame.Controls.Add(Me._PalBtn_2)
        Me.PaletteFrame.Controls.Add(Me._PalBtn_3)
        Me.PaletteFrame.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.PaletteFrame.ForeColor = System.Drawing.SystemColors.ControlText
        Me.PaletteFrame.Location = New System.Drawing.Point(8, 280)
        Me.PaletteFrame.Name = "PaletteFrame"
        Me.PaletteFrame.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.PaletteFrame.Size = New System.Drawing.Size(185, 73)
        Me.PaletteFrame.TabIndex = 35
        Me.PaletteFrame.TabStop = False
        Me.PaletteFrame.Text = " Palette:"
        '
        'TsaPalText
        '
        Me.TsaPalText.AcceptsReturn = True
        Me.TsaPalText.BackColor = System.Drawing.SystemColors.Window
        Me.TsaPalText.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.TsaPalText.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TsaPalText.ForeColor = System.Drawing.SystemColors.WindowText
        Me.TsaPalText.Location = New System.Drawing.Point(56, 0)
        Me.TsaPalText.MaxLength = 0
        Me.TsaPalText.Name = "TsaPalText"
        Me.TsaPalText.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.TsaPalText.Size = New System.Drawing.Size(49, 26)
        Me.TsaPalText.TabIndex = 40
        '
        '_PalBtn_0
        '
        Me._PalBtn_0.BackColor = System.Drawing.SystemColors.Control
        Me._PalBtn_0.Cursor = System.Windows.Forms.Cursors.Default
        Me._PalBtn_0.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._PalBtn_0.ForeColor = System.Drawing.SystemColors.ControlText
        Me._PalBtn_0.Location = New System.Drawing.Point(8, 32)
        Me._PalBtn_0.Name = "_PalBtn_0"
        Me._PalBtn_0.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._PalBtn_0.Size = New System.Drawing.Size(33, 25)
        Me._PalBtn_0.TabIndex = 39
        Me._PalBtn_0.Text = "0"
        Me._PalBtn_0.UseVisualStyleBackColor = False
        '
        '_PalBtn_1
        '
        Me._PalBtn_1.BackColor = System.Drawing.SystemColors.Control
        Me._PalBtn_1.Cursor = System.Windows.Forms.Cursors.Default
        Me._PalBtn_1.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._PalBtn_1.ForeColor = System.Drawing.SystemColors.ControlText
        Me._PalBtn_1.Location = New System.Drawing.Point(48, 32)
        Me._PalBtn_1.Name = "_PalBtn_1"
        Me._PalBtn_1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._PalBtn_1.Size = New System.Drawing.Size(33, 25)
        Me._PalBtn_1.TabIndex = 38
        Me._PalBtn_1.Text = "1"
        Me._PalBtn_1.UseVisualStyleBackColor = False
        '
        '_PalBtn_2
        '
        Me._PalBtn_2.BackColor = System.Drawing.SystemColors.Control
        Me._PalBtn_2.Cursor = System.Windows.Forms.Cursors.Default
        Me._PalBtn_2.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._PalBtn_2.ForeColor = System.Drawing.SystemColors.ControlText
        Me._PalBtn_2.Location = New System.Drawing.Point(88, 32)
        Me._PalBtn_2.Name = "_PalBtn_2"
        Me._PalBtn_2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._PalBtn_2.Size = New System.Drawing.Size(33, 25)
        Me._PalBtn_2.TabIndex = 37
        Me._PalBtn_2.Text = "2"
        Me._PalBtn_2.UseVisualStyleBackColor = False
        '
        '_PalBtn_3
        '
        Me._PalBtn_3.BackColor = System.Drawing.SystemColors.Control
        Me._PalBtn_3.Cursor = System.Windows.Forms.Cursors.Default
        Me._PalBtn_3.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._PalBtn_3.ForeColor = System.Drawing.SystemColors.ControlText
        Me._PalBtn_3.Location = New System.Drawing.Point(128, 32)
        Me._PalBtn_3.Name = "_PalBtn_3"
        Me._PalBtn_3.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._PalBtn_3.Size = New System.Drawing.Size(33, 25)
        Me._PalBtn_3.TabIndex = 36
        Me._PalBtn_3.Text = "3"
        Me._PalBtn_3.UseVisualStyleBackColor = False
        '
        'Frame1
        '
        Me.Frame1.BackColor = System.Drawing.SystemColors.Control
        Me.Frame1.Controls.Add(Me.TsaIdText)
        Me.Frame1.Controls.Add(Me.SetToCurTsa)
        Me.Frame1.Controls.Add(Me.Label2)
        Me.Frame1.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Frame1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Frame1.Location = New System.Drawing.Point(8, 184)
        Me.Frame1.Name = "Frame1"
        Me.Frame1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Frame1.Size = New System.Drawing.Size(195, 169)
        Me.Frame1.TabIndex = 31
        Me.Frame1.TabStop = False
        Me.Frame1.Text = " Edit properties "
        '
        'TsaIdText
        '
        Me.TsaIdText.AcceptsReturn = True
        Me.TsaIdText.BackColor = System.Drawing.SystemColors.Window
        Me.TsaIdText.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.TsaIdText.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TsaIdText.ForeColor = System.Drawing.SystemColors.WindowText
        Me.TsaIdText.Location = New System.Drawing.Point(80, 24)
        Me.TsaIdText.MaxLength = 0
        Me.TsaIdText.Name = "TsaIdText"
        Me.TsaIdText.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.TsaIdText.Size = New System.Drawing.Size(49, 26)
        Me.TsaIdText.TabIndex = 33
        '
        'SetToCurTsa
        '
        Me.SetToCurTsa.BackColor = System.Drawing.SystemColors.Control
        Me.SetToCurTsa.Cursor = System.Windows.Forms.Cursors.Default
        Me.SetToCurTsa.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SetToCurTsa.ForeColor = System.Drawing.SystemColors.ControlText
        Me.SetToCurTsa.Location = New System.Drawing.Point(5, 56)
        Me.SetToCurTsa.Name = "SetToCurTsa"
        Me.SetToCurTsa.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.SetToCurTsa.Size = New System.Drawing.Size(185, 34)
        Me.SetToCurTsa.TabIndex = 32
        Me.SetToCurTsa.Text = "Copy from Current Metatile selection"
        Me.SetToCurTsa.UseVisualStyleBackColor = False
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.SystemColors.Control
        Me.Label2.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label2.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label2.Location = New System.Drawing.Point(8, 24)
        Me.Label2.Name = "Label2"
        Me.Label2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label2.Size = New System.Drawing.Size(73, 17)
        Me.Label2.TabIndex = 34
        Me.Label2.Text = "Metatile Id:"
        '
        'Frame4
        '
        Me.Frame4.BackColor = System.Drawing.SystemColors.Control
        Me.Frame4.Controls.Add(Me._WTMOpt_0)
        Me.Frame4.Controls.Add(Me._WTMOpt_1)
        Me.Frame4.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Frame4.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Frame4.Location = New System.Drawing.Point(216, 8)
        Me.Frame4.Name = "Frame4"
        Me.Frame4.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Frame4.Size = New System.Drawing.Size(113, 57)
        Me.Frame4.TabIndex = 28
        Me.Frame4.TabStop = False
        Me.Frame4.Text = " What to move: "
        '
        '_WTMOpt_0
        '
        Me._WTMOpt_0.BackColor = System.Drawing.SystemColors.Control
        Me._WTMOpt_0.Cursor = System.Windows.Forms.Cursors.Default
        Me._WTMOpt_0.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._WTMOpt_0.ForeColor = System.Drawing.SystemColors.ControlText
        Me._WTMOpt_0.Location = New System.Drawing.Point(8, 16)
        Me._WTMOpt_0.Name = "_WTMOpt_0"
        Me._WTMOpt_0.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._WTMOpt_0.Size = New System.Drawing.Size(97, 17)
        Me._WTMOpt_0.TabIndex = 30
        Me._WTMOpt_0.TabStop = True
        Me._WTMOpt_0.Text = "Opening hatch"
        Me._WTMOpt_0.UseVisualStyleBackColor = False
        '
        '_WTMOpt_1
        '
        Me._WTMOpt_1.BackColor = System.Drawing.SystemColors.Control
        Me._WTMOpt_1.Cursor = System.Windows.Forms.Cursors.Default
        Me._WTMOpt_1.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._WTMOpt_1.ForeColor = System.Drawing.SystemColors.ControlText
        Me._WTMOpt_1.Location = New System.Drawing.Point(8, 32)
        Me._WTMOpt_1.Name = "_WTMOpt_1"
        Me._WTMOpt_1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._WTMOpt_1.Size = New System.Drawing.Size(97, 17)
        Me._WTMOpt_1.TabIndex = 29
        Me._WTMOpt_1.TabStop = True
        Me._WTMOpt_1.Text = "Closing hatch"
        Me._WTMOpt_1.UseVisualStyleBackColor = False
        '
        '_TSASelect_7
        '
        Me._TSASelect_7.BackColor = System.Drawing.SystemColors.Control
        Me._TSASelect_7.Cursor = System.Windows.Forms.Cursors.Default
        Me._TSASelect_7.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._TSASelect_7.ForeColor = System.Drawing.SystemColors.ControlText
        Me._TSASelect_7.Location = New System.Drawing.Point(104, 128)
        Me._TSASelect_7.Name = "_TSASelect_7"
        Me._TSASelect_7.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._TSASelect_7.Size = New System.Drawing.Size(17, 25)
        Me._TSASelect_7.TabIndex = 27
        Me._TSASelect_7.TabStop = True
        Me._TSASelect_7.UseVisualStyleBackColor = False
        '
        '_TSASelect_6
        '
        Me._TSASelect_6.BackColor = System.Drawing.SystemColors.Control
        Me._TSASelect_6.Cursor = System.Windows.Forms.Cursors.Default
        Me._TSASelect_6.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._TSASelect_6.ForeColor = System.Drawing.SystemColors.ControlText
        Me._TSASelect_6.Location = New System.Drawing.Point(104, 96)
        Me._TSASelect_6.Name = "_TSASelect_6"
        Me._TSASelect_6.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._TSASelect_6.Size = New System.Drawing.Size(17, 25)
        Me._TSASelect_6.TabIndex = 26
        Me._TSASelect_6.TabStop = True
        Me._TSASelect_6.UseVisualStyleBackColor = False
        '
        '_TSASelect_5
        '
        Me._TSASelect_5.BackColor = System.Drawing.SystemColors.Control
        Me._TSASelect_5.Cursor = System.Windows.Forms.Cursors.Default
        Me._TSASelect_5.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._TSASelect_5.ForeColor = System.Drawing.SystemColors.ControlText
        Me._TSASelect_5.Location = New System.Drawing.Point(104, 64)
        Me._TSASelect_5.Name = "_TSASelect_5"
        Me._TSASelect_5.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._TSASelect_5.Size = New System.Drawing.Size(17, 25)
        Me._TSASelect_5.TabIndex = 25
        Me._TSASelect_5.TabStop = True
        Me._TSASelect_5.UseVisualStyleBackColor = False
        '
        '_TSASelect_4
        '
        Me._TSASelect_4.BackColor = System.Drawing.SystemColors.Control
        Me._TSASelect_4.Cursor = System.Windows.Forms.Cursors.Default
        Me._TSASelect_4.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._TSASelect_4.ForeColor = System.Drawing.SystemColors.ControlText
        Me._TSASelect_4.Location = New System.Drawing.Point(104, 32)
        Me._TSASelect_4.Name = "_TSASelect_4"
        Me._TSASelect_4.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._TSASelect_4.Size = New System.Drawing.Size(17, 25)
        Me._TSASelect_4.TabIndex = 24
        Me._TSASelect_4.TabStop = True
        Me._TSASelect_4.UseVisualStyleBackColor = False
        '
        '_TSASelect_3
        '
        Me._TSASelect_3.BackColor = System.Drawing.SystemColors.Control
        Me._TSASelect_3.Cursor = System.Windows.Forms.Cursors.Default
        Me._TSASelect_3.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._TSASelect_3.ForeColor = System.Drawing.SystemColors.ControlText
        Me._TSASelect_3.Location = New System.Drawing.Point(24, 128)
        Me._TSASelect_3.Name = "_TSASelect_3"
        Me._TSASelect_3.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._TSASelect_3.Size = New System.Drawing.Size(17, 25)
        Me._TSASelect_3.TabIndex = 23
        Me._TSASelect_3.TabStop = True
        Me._TSASelect_3.UseVisualStyleBackColor = False
        '
        '_TSASelect_2
        '
        Me._TSASelect_2.BackColor = System.Drawing.SystemColors.Control
        Me._TSASelect_2.Cursor = System.Windows.Forms.Cursors.Default
        Me._TSASelect_2.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._TSASelect_2.ForeColor = System.Drawing.SystemColors.ControlText
        Me._TSASelect_2.Location = New System.Drawing.Point(24, 96)
        Me._TSASelect_2.Name = "_TSASelect_2"
        Me._TSASelect_2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._TSASelect_2.Size = New System.Drawing.Size(17, 25)
        Me._TSASelect_2.TabIndex = 22
        Me._TSASelect_2.TabStop = True
        Me._TSASelect_2.UseVisualStyleBackColor = False
        '
        '_TSASelect_1
        '
        Me._TSASelect_1.BackColor = System.Drawing.SystemColors.Control
        Me._TSASelect_1.Cursor = System.Windows.Forms.Cursors.Default
        Me._TSASelect_1.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._TSASelect_1.ForeColor = System.Drawing.SystemColors.ControlText
        Me._TSASelect_1.Location = New System.Drawing.Point(24, 64)
        Me._TSASelect_1.Name = "_TSASelect_1"
        Me._TSASelect_1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._TSASelect_1.Size = New System.Drawing.Size(17, 25)
        Me._TSASelect_1.TabIndex = 21
        Me._TSASelect_1.TabStop = True
        Me._TSASelect_1.UseVisualStyleBackColor = False
        '
        '_TSAPic_7
        '
        Me._TSAPic_7.BackColor = System.Drawing.SystemColors.Control
        Me._TSAPic_7.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me._TSAPic_7.Cursor = System.Windows.Forms.Cursors.Default
        Me._TSAPic_7.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._TSAPic_7.ForeColor = System.Drawing.SystemColors.ControlText
        Me._TSAPic_7.Location = New System.Drawing.Point(128, 128)
        Me._TSAPic_7.Name = "_TSAPic_7"
        Me._TSAPic_7.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._TSAPic_7.Size = New System.Drawing.Size(32, 32)
        Me._TSAPic_7.TabIndex = 20
        Me._TSAPic_7.TabStop = False
        '
        '_TSAPic_6
        '
        Me._TSAPic_6.BackColor = System.Drawing.SystemColors.Control
        Me._TSAPic_6.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me._TSAPic_6.Cursor = System.Windows.Forms.Cursors.Default
        Me._TSAPic_6.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._TSAPic_6.ForeColor = System.Drawing.SystemColors.ControlText
        Me._TSAPic_6.Location = New System.Drawing.Point(128, 96)
        Me._TSAPic_6.Name = "_TSAPic_6"
        Me._TSAPic_6.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._TSAPic_6.Size = New System.Drawing.Size(32, 32)
        Me._TSAPic_6.TabIndex = 19
        Me._TSAPic_6.TabStop = False
        '
        '_TSAPic_5
        '
        Me._TSAPic_5.BackColor = System.Drawing.SystemColors.Control
        Me._TSAPic_5.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me._TSAPic_5.Cursor = System.Windows.Forms.Cursors.Default
        Me._TSAPic_5.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._TSAPic_5.ForeColor = System.Drawing.SystemColors.ControlText
        Me._TSAPic_5.Location = New System.Drawing.Point(128, 64)
        Me._TSAPic_5.Name = "_TSAPic_5"
        Me._TSAPic_5.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._TSAPic_5.Size = New System.Drawing.Size(32, 32)
        Me._TSAPic_5.TabIndex = 18
        Me._TSAPic_5.TabStop = False
        '
        '_TSAPic_4
        '
        Me._TSAPic_4.BackColor = System.Drawing.SystemColors.Control
        Me._TSAPic_4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me._TSAPic_4.Cursor = System.Windows.Forms.Cursors.Default
        Me._TSAPic_4.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._TSAPic_4.ForeColor = System.Drawing.SystemColors.ControlText
        Me._TSAPic_4.Location = New System.Drawing.Point(128, 32)
        Me._TSAPic_4.Name = "_TSAPic_4"
        Me._TSAPic_4.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._TSAPic_4.Size = New System.Drawing.Size(32, 32)
        Me._TSAPic_4.TabIndex = 17
        Me._TSAPic_4.TabStop = False
        '
        '_TSAPic_3
        '
        Me._TSAPic_3.BackColor = System.Drawing.SystemColors.Control
        Me._TSAPic_3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me._TSAPic_3.Cursor = System.Windows.Forms.Cursors.Default
        Me._TSAPic_3.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._TSAPic_3.ForeColor = System.Drawing.SystemColors.ControlText
        Me._TSAPic_3.Location = New System.Drawing.Point(48, 128)
        Me._TSAPic_3.Name = "_TSAPic_3"
        Me._TSAPic_3.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._TSAPic_3.Size = New System.Drawing.Size(32, 32)
        Me._TSAPic_3.TabIndex = 16
        Me._TSAPic_3.TabStop = False
        '
        '_TSAPic_2
        '
        Me._TSAPic_2.BackColor = System.Drawing.SystemColors.Control
        Me._TSAPic_2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me._TSAPic_2.Cursor = System.Windows.Forms.Cursors.Default
        Me._TSAPic_2.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._TSAPic_2.ForeColor = System.Drawing.SystemColors.ControlText
        Me._TSAPic_2.Location = New System.Drawing.Point(48, 96)
        Me._TSAPic_2.Name = "_TSAPic_2"
        Me._TSAPic_2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._TSAPic_2.Size = New System.Drawing.Size(32, 32)
        Me._TSAPic_2.TabIndex = 15
        Me._TSAPic_2.TabStop = False
        '
        '_TSAPic_1
        '
        Me._TSAPic_1.BackColor = System.Drawing.SystemColors.Control
        Me._TSAPic_1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me._TSAPic_1.Cursor = System.Windows.Forms.Cursors.Default
        Me._TSAPic_1.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._TSAPic_1.ForeColor = System.Drawing.SystemColors.ControlText
        Me._TSAPic_1.Location = New System.Drawing.Point(48, 64)
        Me._TSAPic_1.Name = "_TSAPic_1"
        Me._TSAPic_1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._TSAPic_1.Size = New System.Drawing.Size(32, 32)
        Me._TSAPic_1.TabIndex = 14
        Me._TSAPic_1.TabStop = False
        '
        'MM3Frame2
        '
        Me.MM3Frame2.BackColor = System.Drawing.SystemColors.Control
        Me.MM3Frame2.Controls.Add(Me.PresetTB)
        Me.MM3Frame2.Controls.Add(Me.DPScreenTB)
        Me.MM3Frame2.Controls.Add(Me.Line1)
        Me.MM3Frame2.Controls.Add(Me.Label8)
        Me.MM3Frame2.Controls.Add(Me.Label6)
        Me.MM3Frame2.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MM3Frame2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.MM3Frame2.Location = New System.Drawing.Point(480, 160)
        Me.MM3Frame2.Name = "MM3Frame2"
        Me.MM3Frame2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.MM3Frame2.Size = New System.Drawing.Size(129, 153)
        Me.MM3Frame2.TabIndex = 7
        Me.MM3Frame2.TabStop = False
        Me.MM3Frame2.Text = " Modify data "
        '
        'PresetTB
        '
        Me.PresetTB.AcceptsReturn = True
        Me.PresetTB.BackColor = System.Drawing.SystemColors.Window
        Me.PresetTB.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.PresetTB.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.PresetTB.ForeColor = System.Drawing.SystemColors.WindowText
        Me.PresetTB.Location = New System.Drawing.Point(16, 112)
        Me.PresetTB.MaxLength = 0
        Me.PresetTB.Name = "PresetTB"
        Me.PresetTB.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.PresetTB.Size = New System.Drawing.Size(57, 20)
        Me.PresetTB.TabIndex = 13
        '
        'DPScreenTB
        '
        Me.DPScreenTB.AcceptsReturn = True
        Me.DPScreenTB.BackColor = System.Drawing.SystemColors.Window
        Me.DPScreenTB.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.DPScreenTB.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DPScreenTB.ForeColor = System.Drawing.SystemColors.WindowText
        Me.DPScreenTB.Location = New System.Drawing.Point(16, 40)
        Me.DPScreenTB.MaxLength = 0
        Me.DPScreenTB.Name = "DPScreenTB"
        Me.DPScreenTB.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.DPScreenTB.Size = New System.Drawing.Size(33, 20)
        Me.DPScreenTB.TabIndex = 12
        '
        'Line1
        '
        Me.Line1.BackColor = System.Drawing.SystemColors.WindowText
        Me.Line1.Location = New System.Drawing.Point(0, 72)
        Me.Line1.Name = "Line1"
        Me.Line1.Size = New System.Drawing.Size(128, 1)
        Me.Line1.TabIndex = 14
        '
        'Label8
        '
        Me.Label8.BackColor = System.Drawing.SystemColors.Control
        Me.Label8.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label8.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label8.Location = New System.Drawing.Point(8, 24)
        Me.Label8.Name = "Label8"
        Me.Label8.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label8.Size = New System.Drawing.Size(113, 17)
        Me.Label8.TabIndex = 11
        Me.Label8.Text = "Screen of Door Point:"
        '
        'Label6
        '
        Me.Label6.BackColor = System.Drawing.SystemColors.Control
        Me.Label6.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label6.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label6.Location = New System.Drawing.Point(8, 80)
        Me.Label6.Name = "Label6"
        Me.Label6.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label6.Size = New System.Drawing.Size(113, 33)
        Me.Label6.TabIndex = 8
        Me.Label6.Text = "Preset to use for relative screen:"
        '
        'MM3Frame1
        '
        Me.MM3Frame1.BackColor = System.Drawing.SystemColors.Control
        Me.MM3Frame1.Controls.Add(Me.ScreenScroll)
        Me.MM3Frame1.Controls.Add(Me._DoorPointOpt_1)
        Me.MM3Frame1.Controls.Add(Me._DoorPointOpt_0)
        Me.MM3Frame1.Controls.Add(Me.Label9)
        Me.MM3Frame1.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MM3Frame1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.MM3Frame1.Location = New System.Drawing.Point(480, 8)
        Me.MM3Frame1.Name = "MM3Frame1"
        Me.MM3Frame1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.MM3Frame1.Size = New System.Drawing.Size(129, 161)
        Me.MM3Frame1.TabIndex = 4
        Me.MM3Frame1.TabStop = False
        Me.MM3Frame1.Text = " Selection "
        '
        'ScreenScroll
        '
        Me.ScreenScroll.Cursor = System.Windows.Forms.Cursors.Default
        Me.ScreenScroll.LargeChange = 1
        Me.ScreenScroll.Location = New System.Drawing.Point(8, 96)
        Me.ScreenScroll.Maximum = 6
        Me.ScreenScroll.Name = "ScreenScroll"
        Me.ScreenScroll.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.ScreenScroll.Size = New System.Drawing.Size(105, 17)
        Me.ScreenScroll.TabIndex = 10
        Me.ScreenScroll.TabStop = True
        '
        '_DoorPointOpt_1
        '
        Me._DoorPointOpt_1.BackColor = System.Drawing.SystemColors.Control
        Me._DoorPointOpt_1.Cursor = System.Windows.Forms.Cursors.Default
        Me._DoorPointOpt_1.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._DoorPointOpt_1.ForeColor = System.Drawing.SystemColors.ControlText
        Me._DoorPointOpt_1.Location = New System.Drawing.Point(8, 40)
        Me._DoorPointOpt_1.Name = "_DoorPointOpt_1"
        Me._DoorPointOpt_1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._DoorPointOpt_1.Size = New System.Drawing.Size(89, 17)
        Me._DoorPointOpt_1.TabIndex = 6
        Me._DoorPointOpt_1.TabStop = True
        Me._DoorPointOpt_1.Text = "Door Point 2"
        Me._DoorPointOpt_1.UseVisualStyleBackColor = False
        '
        '_DoorPointOpt_0
        '
        Me._DoorPointOpt_0.BackColor = System.Drawing.SystemColors.Control
        Me._DoorPointOpt_0.Cursor = System.Windows.Forms.Cursors.Default
        Me._DoorPointOpt_0.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._DoorPointOpt_0.ForeColor = System.Drawing.SystemColors.ControlText
        Me._DoorPointOpt_0.Location = New System.Drawing.Point(8, 24)
        Me._DoorPointOpt_0.Name = "_DoorPointOpt_0"
        Me._DoorPointOpt_0.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._DoorPointOpt_0.Size = New System.Drawing.Size(89, 17)
        Me._DoorPointOpt_0.TabIndex = 5
        Me._DoorPointOpt_0.TabStop = True
        Me._DoorPointOpt_0.Text = "Door Point 1"
        Me._DoorPointOpt_0.UseVisualStyleBackColor = False
        '
        'Label9
        '
        Me.Label9.BackColor = System.Drawing.SystemColors.Control
        Me.Label9.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label9.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label9.Location = New System.Drawing.Point(8, 64)
        Me.Label9.Name = "Label9"
        Me.Label9.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label9.Size = New System.Drawing.Size(105, 33)
        Me.Label9.TabIndex = 9
        Me.Label9.Text = "Screen (relative to Door Point):"
        '
        '_TSASelect_0
        '
        Me._TSASelect_0.BackColor = System.Drawing.SystemColors.Control
        Me._TSASelect_0.Cursor = System.Windows.Forms.Cursors.Default
        Me._TSASelect_0.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._TSASelect_0.ForeColor = System.Drawing.SystemColors.ControlText
        Me._TSASelect_0.Location = New System.Drawing.Point(24, 32)
        Me._TSASelect_0.Name = "_TSASelect_0"
        Me._TSASelect_0.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._TSASelect_0.Size = New System.Drawing.Size(17, 25)
        Me._TSASelect_0.TabIndex = 1
        Me._TSASelect_0.TabStop = True
        Me._TSASelect_0.UseVisualStyleBackColor = False
        '
        '_TSAPic_0
        '
        Me._TSAPic_0.BackColor = System.Drawing.SystemColors.Control
        Me._TSAPic_0.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me._TSAPic_0.Cursor = System.Windows.Forms.Cursors.Default
        Me._TSAPic_0.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._TSAPic_0.ForeColor = System.Drawing.SystemColors.ControlText
        Me._TSAPic_0.Location = New System.Drawing.Point(48, 32)
        Me._TSAPic_0.Name = "_TSAPic_0"
        Me._TSAPic_0.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._TSAPic_0.Size = New System.Drawing.Size(32, 32)
        Me._TSAPic_0.TabIndex = 0
        Me._TSAPic_0.TabStop = False
        '
        'OpenShape
        '
        Me.OpenShape.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.OpenShape.Location = New System.Drawing.Point(231, 80)
        Me.OpenShape.Name = "OpenShape"
        Me.OpenShape.Size = New System.Drawing.Size(15, 63)
        Me.OpenShape.TabIndex = 42
        '
        'CloseShape
        '
        Me.CloseShape.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.CloseShape.Location = New System.Drawing.Point(216, 80)
        Me.CloseShape.Name = "CloseShape"
        Me.CloseShape.Size = New System.Drawing.Size(15, 63)
        Me.CloseShape.TabIndex = 43
        '
        'Label5
        '
        Me.Label5.BackColor = System.Drawing.SystemColors.Control
        Me.Label5.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label5.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label5.Location = New System.Drawing.Point(120, 8)
        Me.Label5.Name = "Label5"
        Me.Label5.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label5.Size = New System.Drawing.Size(49, 21)
        Me.Label5.TabIndex = 3
        Me.Label5.Text = "Closing:"
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.SystemColors.Control
        Me.Label4.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label4.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label4.Location = New System.Drawing.Point(32, 8)
        Me.Label4.Name = "Label4"
        Me.Label4.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label4.Size = New System.Drawing.Size(57, 21)
        Me.Label4.TabIndex = 2
        Me.Label4.Text = "Opening:"
        '
        'PicBGShape
        '
        Me.PicBGShape.BackColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.PicBGShape.Location = New System.Drawing.Point(216, 80)
        Me.PicBGShape.Name = "PicBGShape"
        Me.PicBGShape.Size = New System.Drawing.Size(256, 240)
        Me.PicBGShape.TabIndex = 0
        Me.PicBGShape.TabStop = False
        '
        'DoorEd
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 14.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.ClientSize = New System.Drawing.Size(629, 371)
        Me.Controls.Add(Me.CloseShape)
        Me.Controls.Add(Me.OpenShape)
        Me.Controls.Add(Me.PicBGShape)
        Me.Controls.Add(Me.Frame2)
        Me.Controls.Add(Me.PaletteFrame)
        Me.Controls.Add(Me.Frame1)
        Me.Controls.Add(Me.Frame4)
        Me.Controls.Add(Me._TSASelect_7)
        Me.Controls.Add(Me._TSASelect_6)
        Me.Controls.Add(Me._TSASelect_5)
        Me.Controls.Add(Me._TSASelect_4)
        Me.Controls.Add(Me._TSASelect_3)
        Me.Controls.Add(Me._TSASelect_2)
        Me.Controls.Add(Me._TSASelect_1)
        Me.Controls.Add(Me._TSAPic_7)
        Me.Controls.Add(Me._TSAPic_6)
        Me.Controls.Add(Me._TSAPic_5)
        Me.Controls.Add(Me._TSAPic_4)
        Me.Controls.Add(Me._TSAPic_3)
        Me.Controls.Add(Me._TSAPic_2)
        Me.Controls.Add(Me._TSAPic_1)
        Me.Controls.Add(Me.MM3Frame2)
        Me.Controls.Add(Me.MM3Frame1)
        Me.Controls.Add(Me._TSASelect_0)
        Me.Controls.Add(Me._TSAPic_0)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Cursor = System.Windows.Forms.Cursors.Default
        Me.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.Location = New System.Drawing.Point(3, 22)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "DoorEd"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Text = " Door Editor"
        Me.Frame2.ResumeLayout(False)
        Me.PaletteFrame.ResumeLayout(False)
        Me.PaletteFrame.PerformLayout()
        Me.Frame1.ResumeLayout(False)
        Me.Frame1.PerformLayout()
        Me.Frame4.ResumeLayout(False)
        CType(Me._TSAPic_7, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me._TSAPic_6, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me._TSAPic_5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me._TSAPic_4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me._TSAPic_3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me._TSAPic_2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me._TSAPic_1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.MM3Frame2.ResumeLayout(False)
        Me.MM3Frame2.PerformLayout()
        Me.MM3Frame1.ResumeLayout(False)
        CType(Me._TSAPic_0, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PicBGShape, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents PicBGShape As PictureBox
#End Region
End Class