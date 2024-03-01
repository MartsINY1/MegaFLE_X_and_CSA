<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> Partial Class MetatileTable
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
	Public WithEvents tsaPasteBtn As System.Windows.Forms.Button
	Public WithEvents tsaCopyBtn As System.Windows.Forms.Button
	Public WithEvents TSAScroll As System.Windows.Forms.VScrollBar
	Public WithEvents CurTilePic As System.Windows.Forms.PictureBox
	Public WithEvents Frame1 As System.Windows.Forms.GroupBox
	Public WithEvents BlockTypeList As System.Windows.Forms.ListBox
	Public WithEvents PalPic As System.Windows.Forms.PictureBox
	Public WithEvents tsapic As System.Windows.Forms.PictureBox
	'NOTE: The following procedure is required by the Windows Form Designer
	'It can be modified using the Windows Form Designer.
	'Do not modify it using the code editor.
	<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MetatileTable))
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.BtnClearUnusedMetatiles = New System.Windows.Forms.Button()
        Me.BtnClearDuplicated = New System.Windows.Forms.Button()
        Me.tsaPasteBtn = New System.Windows.Forms.Button()
        Me.tsaCopyBtn = New System.Windows.Forms.Button()
        Me.TSAScroll = New System.Windows.Forms.VScrollBar()
        Me.Frame1 = New System.Windows.Forms.GroupBox()
        Me.CurTilePic = New System.Windows.Forms.PictureBox()
        Me.BlockTypeList = New System.Windows.Forms.ListBox()
        Me.PalPic = New System.Windows.Forms.PictureBox()
        Me.tsapic = New System.Windows.Forms.PictureBox()
        Me.BtnShowSelected = New System.Windows.Forms.Button()
        Me.chkPaletteForEachTile = New System.Windows.Forms.CheckBox()
        Me.gbxSetPaletteForTile = New System.Windows.Forms.GroupBox()
        Me.rdSetPaletteForTile4 = New System.Windows.Forms.RadioButton()
        Me.rdSetPaletteForTile2 = New System.Windows.Forms.RadioButton()
        Me.rdSetPaletteForTile3 = New System.Windows.Forms.RadioButton()
        Me.rdSetPaletteForTile1 = New System.Windows.Forms.RadioButton()
        Me.rdSetPaletteForTileAll = New System.Windows.Forms.RadioButton()
        Me.PnlBlockTypeAndImageTilePalette = New System.Windows.Forms.Panel()
        Me.PnlSetPaletteForTileX = New System.Windows.Forms.Panel()
        Me.PnlButtons = New System.Windows.Forms.Panel()
        Me.PnlMetatiles = New System.Windows.Forms.Panel()
        Me.Frame1.SuspendLayout()
        CType(Me.CurTilePic, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PalPic, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tsapic, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbxSetPaletteForTile.SuspendLayout()
        Me.PnlBlockTypeAndImageTilePalette.SuspendLayout()
        Me.PnlSetPaletteForTileX.SuspendLayout()
        Me.PnlButtons.SuspendLayout()
        Me.PnlMetatiles.SuspendLayout()
        Me.SuspendLayout()
        '
        'BtnClearUnusedMetatiles
        '
        Me.BtnClearUnusedMetatiles.BackColor = System.Drawing.SystemColors.Control
        Me.BtnClearUnusedMetatiles.Cursor = System.Windows.Forms.Cursors.Default
        Me.BtnClearUnusedMetatiles.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold)
        Me.BtnClearUnusedMetatiles.ForeColor = System.Drawing.SystemColors.ControlText
        Me.BtnClearUnusedMetatiles.Location = New System.Drawing.Point(0, 122)
        Me.BtnClearUnusedMetatiles.Name = "BtnClearUnusedMetatiles"
        Me.BtnClearUnusedMetatiles.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.BtnClearUnusedMetatiles.Size = New System.Drawing.Size(92, 40)
        Me.BtnClearUnusedMetatiles.TabIndex = 8
        Me.BtnClearUnusedMetatiles.Text = "Clear Unused Metatiles"
        Me.ToolTip1.SetToolTip(Me.BtnClearUnusedMetatiles, "Clear all unused Metatiles.")
        Me.BtnClearUnusedMetatiles.UseVisualStyleBackColor = False
        '
        'BtnClearDuplicated
        '
        Me.BtnClearDuplicated.BackColor = System.Drawing.SystemColors.Control
        Me.BtnClearDuplicated.Cursor = System.Windows.Forms.Cursors.Default
        Me.BtnClearDuplicated.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold)
        Me.BtnClearDuplicated.ForeColor = System.Drawing.SystemColors.ControlText
        Me.BtnClearDuplicated.Location = New System.Drawing.Point(1, 162)
        Me.BtnClearDuplicated.Name = "BtnClearDuplicated"
        Me.BtnClearDuplicated.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.BtnClearDuplicated.Size = New System.Drawing.Size(91, 40)
        Me.BtnClearDuplicated.TabIndex = 10
        Me.BtnClearDuplicated.Text = "Clear duplicated Metatiles"
        Me.ToolTip1.SetToolTip(Me.BtnClearDuplicated, "Clear all duplicated AND unused Metatiles." & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Only first duplicated occurence met i" &
        "n the" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "list will be kept and Metametatiles will be" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "adjusted to use the one that" &
        " is kept.")
        Me.BtnClearDuplicated.UseVisualStyleBackColor = False
        '
        'tsaPasteBtn
        '
        Me.tsaPasteBtn.BackColor = System.Drawing.SystemColors.Control
        Me.tsaPasteBtn.Cursor = System.Windows.Forms.Cursors.Default
        Me.tsaPasteBtn.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tsaPasteBtn.ForeColor = System.Drawing.SystemColors.ControlText
        Me.tsaPasteBtn.Location = New System.Drawing.Point(1, 44)
        Me.tsaPasteBtn.Name = "tsaPasteBtn"
        Me.tsaPasteBtn.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.tsaPasteBtn.Size = New System.Drawing.Size(91, 40)
        Me.tsaPasteBtn.TabIndex = 7
        Me.tsaPasteBtn.Text = "Paste Metatile"
        Me.tsaPasteBtn.UseVisualStyleBackColor = False
        '
        'tsaCopyBtn
        '
        Me.tsaCopyBtn.BackColor = System.Drawing.SystemColors.Control
        Me.tsaCopyBtn.Cursor = System.Windows.Forms.Cursors.Default
        Me.tsaCopyBtn.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tsaCopyBtn.ForeColor = System.Drawing.SystemColors.ControlText
        Me.tsaCopyBtn.Location = New System.Drawing.Point(1, 4)
        Me.tsaCopyBtn.Name = "tsaCopyBtn"
        Me.tsaCopyBtn.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.tsaCopyBtn.Size = New System.Drawing.Size(91, 40)
        Me.tsaCopyBtn.TabIndex = 6
        Me.tsaCopyBtn.Text = "Copy Metatile"
        Me.tsaCopyBtn.UseVisualStyleBackColor = False
        '
        'TSAScroll
        '
        Me.TSAScroll.Cursor = System.Windows.Forms.Cursors.Default
        Me.TSAScroll.LargeChange = 1
        Me.TSAScroll.Location = New System.Drawing.Point(264, 0)
        Me.TSAScroll.Maximum = 32767
        Me.TSAScroll.Name = "TSAScroll"
        Me.TSAScroll.Size = New System.Drawing.Size(17, 265)
        Me.TSAScroll.TabIndex = 5
        Me.TSAScroll.TabStop = True
        Me.TSAScroll.Visible = False
        '
        'Frame1
        '
        Me.Frame1.BackColor = System.Drawing.SystemColors.Control
        Me.Frame1.Controls.Add(Me.CurTilePic)
        Me.Frame1.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Frame1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Frame1.Location = New System.Drawing.Point(80, 20)
        Me.Frame1.Name = "Frame1"
        Me.Frame1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Frame1.Size = New System.Drawing.Size(49, 57)
        Me.Frame1.TabIndex = 3
        Me.Frame1.TabStop = False
        Me.Frame1.Text = "Tile"
        '
        'CurTilePic
        '
        Me.CurTilePic.BackColor = System.Drawing.SystemColors.Control
        Me.CurTilePic.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.CurTilePic.Cursor = System.Windows.Forms.Cursors.Default
        Me.CurTilePic.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CurTilePic.ForeColor = System.Drawing.SystemColors.ControlText
        Me.CurTilePic.Location = New System.Drawing.Point(8, 12)
        Me.CurTilePic.Name = "CurTilePic"
        Me.CurTilePic.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.CurTilePic.Size = New System.Drawing.Size(33, 33)
        Me.CurTilePic.TabIndex = 4
        Me.CurTilePic.TabStop = False
        '
        'BlockTypeList
        '
        Me.BlockTypeList.BackColor = System.Drawing.SystemColors.Window
        Me.BlockTypeList.Cursor = System.Windows.Forms.Cursors.Default
        Me.BlockTypeList.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BlockTypeList.ForeColor = System.Drawing.SystemColors.WindowText
        Me.BlockTypeList.ItemHeight = 16
        Me.BlockTypeList.Location = New System.Drawing.Point(0, 80)
        Me.BlockTypeList.Name = "BlockTypeList"
        Me.BlockTypeList.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.BlockTypeList.Size = New System.Drawing.Size(129, 228)
        Me.BlockTypeList.TabIndex = 2
        '
        'PalPic
        '
        Me.PalPic.BackColor = System.Drawing.SystemColors.Control
        Me.PalPic.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.PalPic.Cursor = System.Windows.Forms.Cursors.Default
        Me.PalPic.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.PalPic.ForeColor = System.Drawing.SystemColors.ControlText
        Me.PalPic.Location = New System.Drawing.Point(0, 4)
        Me.PalPic.Name = "PalPic"
        Me.PalPic.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.PalPic.Size = New System.Drawing.Size(71, 70)
        Me.PalPic.TabIndex = 1
        Me.PalPic.TabStop = False
        '
        'tsapic
        '
        Me.tsapic.BackColor = System.Drawing.SystemColors.Control
        Me.tsapic.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.tsapic.Cursor = System.Windows.Forms.Cursors.Default
        Me.tsapic.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tsapic.ForeColor = System.Drawing.SystemColors.ControlText
        Me.tsapic.Location = New System.Drawing.Point(2, 0)
        Me.tsapic.Name = "tsapic"
        Me.tsapic.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.tsapic.Size = New System.Drawing.Size(262, 262)
        Me.tsapic.TabIndex = 0
        Me.tsapic.TabStop = False
        '
        'BtnShowSelected
        '
        Me.BtnShowSelected.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold)
        Me.BtnShowSelected.Location = New System.Drawing.Point(1, 264)
        Me.BtnShowSelected.Name = "BtnShowSelected"
        Me.BtnShowSelected.Size = New System.Drawing.Size(91, 40)
        Me.BtnShowSelected.TabIndex = 9
        Me.BtnShowSelected.Text = "Show Selected"
        Me.BtnShowSelected.UseVisualStyleBackColor = True
        '
        'chkPaletteForEachTile
        '
        Me.chkPaletteForEachTile.AutoSize = True
        Me.chkPaletteForEachTile.Location = New System.Drawing.Point(243, 17)
        Me.chkPaletteForEachTile.Name = "chkPaletteForEachTile"
        Me.chkPaletteForEachTile.Size = New System.Drawing.Size(18, 17)
        Me.chkPaletteForEachTile.TabIndex = 11
        Me.chkPaletteForEachTile.UseVisualStyleBackColor = True
        '
        'gbxSetPaletteForTile
        '
        Me.gbxSetPaletteForTile.Controls.Add(Me.rdSetPaletteForTile4)
        Me.gbxSetPaletteForTile.Controls.Add(Me.chkPaletteForEachTile)
        Me.gbxSetPaletteForTile.Controls.Add(Me.rdSetPaletteForTile2)
        Me.gbxSetPaletteForTile.Controls.Add(Me.rdSetPaletteForTile3)
        Me.gbxSetPaletteForTile.Controls.Add(Me.rdSetPaletteForTile1)
        Me.gbxSetPaletteForTile.Controls.Add(Me.rdSetPaletteForTileAll)
        Me.gbxSetPaletteForTile.Location = New System.Drawing.Point(3, 3)
        Me.gbxSetPaletteForTile.Name = "gbxSetPaletteForTile"
        Me.gbxSetPaletteForTile.Size = New System.Drawing.Size(272, 35)
        Me.gbxSetPaletteForTile.TabIndex = 12
        Me.gbxSetPaletteForTile.TabStop = False
        Me.gbxSetPaletteForTile.Text = "Set Palette for tile"
        Me.gbxSetPaletteForTile.Visible = False
        '
        'rdSetPaletteForTile4
        '
        Me.rdSetPaletteForTile4.AutoSize = True
        Me.rdSetPaletteForTile4.Location = New System.Drawing.Point(185, 15)
        Me.rdSetPaletteForTile4.Name = "rdSetPaletteForTile4"
        Me.rdSetPaletteForTile4.Size = New System.Drawing.Size(36, 20)
        Me.rdSetPaletteForTile4.TabIndex = 4
        Me.rdSetPaletteForTile4.Text = "4"
        Me.rdSetPaletteForTile4.UseVisualStyleBackColor = True
        '
        'rdSetPaletteForTile2
        '
        Me.rdSetPaletteForTile2.AutoSize = True
        Me.rdSetPaletteForTile2.Location = New System.Drawing.Point(105, 15)
        Me.rdSetPaletteForTile2.Name = "rdSetPaletteForTile2"
        Me.rdSetPaletteForTile2.Size = New System.Drawing.Size(36, 20)
        Me.rdSetPaletteForTile2.TabIndex = 3
        Me.rdSetPaletteForTile2.Text = "2"
        Me.rdSetPaletteForTile2.UseVisualStyleBackColor = True
        '
        'rdSetPaletteForTile3
        '
        Me.rdSetPaletteForTile3.AutoSize = True
        Me.rdSetPaletteForTile3.Location = New System.Drawing.Point(145, 15)
        Me.rdSetPaletteForTile3.Name = "rdSetPaletteForTile3"
        Me.rdSetPaletteForTile3.Size = New System.Drawing.Size(36, 20)
        Me.rdSetPaletteForTile3.TabIndex = 2
        Me.rdSetPaletteForTile3.Text = "3"
        Me.rdSetPaletteForTile3.UseVisualStyleBackColor = True
        '
        'rdSetPaletteForTile1
        '
        Me.rdSetPaletteForTile1.AutoSize = True
        Me.rdSetPaletteForTile1.Location = New System.Drawing.Point(65, 15)
        Me.rdSetPaletteForTile1.Name = "rdSetPaletteForTile1"
        Me.rdSetPaletteForTile1.Size = New System.Drawing.Size(36, 20)
        Me.rdSetPaletteForTile1.TabIndex = 1
        Me.rdSetPaletteForTile1.Text = "1"
        Me.rdSetPaletteForTile1.UseVisualStyleBackColor = True
        '
        'rdSetPaletteForTileAll
        '
        Me.rdSetPaletteForTileAll.AutoSize = True
        Me.rdSetPaletteForTileAll.Checked = True
        Me.rdSetPaletteForTileAll.Location = New System.Drawing.Point(18, 15)
        Me.rdSetPaletteForTileAll.Name = "rdSetPaletteForTileAll"
        Me.rdSetPaletteForTileAll.Size = New System.Drawing.Size(43, 20)
        Me.rdSetPaletteForTileAll.TabIndex = 0
        Me.rdSetPaletteForTileAll.TabStop = True
        Me.rdSetPaletteForTileAll.Text = "All"
        Me.rdSetPaletteForTileAll.UseVisualStyleBackColor = True
        '
        'PnlBlockTypeAndImageTilePalette
        '
        Me.PnlBlockTypeAndImageTilePalette.Controls.Add(Me.PalPic)
        Me.PnlBlockTypeAndImageTilePalette.Controls.Add(Me.BlockTypeList)
        Me.PnlBlockTypeAndImageTilePalette.Controls.Add(Me.Frame1)
        Me.PnlBlockTypeAndImageTilePalette.Location = New System.Drawing.Point(284, 0)
        Me.PnlBlockTypeAndImageTilePalette.Name = "PnlBlockTypeAndImageTilePalette"
        Me.PnlBlockTypeAndImageTilePalette.Size = New System.Drawing.Size(130, 310)
        Me.PnlBlockTypeAndImageTilePalette.TabIndex = 13
        '
        'PnlSetPaletteForTileX
        '
        Me.PnlSetPaletteForTileX.Controls.Add(Me.gbxSetPaletteForTile)
        Me.PnlSetPaletteForTileX.Location = New System.Drawing.Point(0, 0)
        Me.PnlSetPaletteForTileX.Name = "PnlSetPaletteForTileX"
        Me.PnlSetPaletteForTileX.Size = New System.Drawing.Size(278, 44)
        Me.PnlSetPaletteForTileX.TabIndex = 14
        '
        'PnlButtons
        '
        Me.PnlButtons.Controls.Add(Me.BtnClearUnusedMetatiles)
        Me.PnlButtons.Controls.Add(Me.tsaCopyBtn)
        Me.PnlButtons.Controls.Add(Me.tsaPasteBtn)
        Me.PnlButtons.Controls.Add(Me.BtnClearDuplicated)
        Me.PnlButtons.Controls.Add(Me.BtnShowSelected)
        Me.PnlButtons.Location = New System.Drawing.Point(420, 0)
        Me.PnlButtons.Name = "PnlButtons"
        Me.PnlButtons.Size = New System.Drawing.Size(96, 305)
        Me.PnlButtons.TabIndex = 15
        '
        'PnlMetatiles
        '
        Me.PnlMetatiles.Controls.Add(Me.tsapic)
        Me.PnlMetatiles.Controls.Add(Me.TSAScroll)
        Me.PnlMetatiles.Location = New System.Drawing.Point(0, 43)
        Me.PnlMetatiles.Name = "PnlMetatiles"
        Me.PnlMetatiles.Size = New System.Drawing.Size(283, 593)
        Me.PnlMetatiles.TabIndex = 16
        '
        'MetatileTable
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.ClientSize = New System.Drawing.Size(982, 309)
        Me.Controls.Add(Me.PnlMetatiles)
        Me.Controls.Add(Me.PnlButtons)
        Me.Controls.Add(Me.PnlSetPaletteForTileX)
        Me.Controls.Add(Me.PnlBlockTypeAndImageTilePalette)
        Me.Cursor = System.Windows.Forms.Cursors.Default
        Me.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.Location = New System.Drawing.Point(3, 27)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "MetatileTable"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Text = "Metatile Table"
        Me.Frame1.ResumeLayout(False)
        CType(Me.CurTilePic, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PalPic, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tsapic, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbxSetPaletteForTile.ResumeLayout(False)
        Me.gbxSetPaletteForTile.PerformLayout()
        Me.PnlBlockTypeAndImageTilePalette.ResumeLayout(False)
        Me.PnlSetPaletteForTileX.ResumeLayout(False)
        Me.PnlButtons.ResumeLayout(False)
        Me.PnlMetatiles.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Public WithEvents BtnClearUnusedMetatiles As Button
    Friend WithEvents BtnShowSelected As Button
    Public WithEvents BtnClearDuplicated As Button
    Friend WithEvents chkPaletteForEachTile As CheckBox
    Friend WithEvents gbxSetPaletteForTile As GroupBox
    Friend WithEvents rdSetPaletteForTile3 As RadioButton
    Friend WithEvents rdSetPaletteForTile1 As RadioButton
    Friend WithEvents rdSetPaletteForTileAll As RadioButton
    Friend WithEvents rdSetPaletteForTile4 As RadioButton
    Friend WithEvents rdSetPaletteForTile2 As RadioButton
    Friend WithEvents PnlBlockTypeAndImageTilePalette As Panel
    Friend WithEvents PnlSetPaletteForTileX As Panel
    Friend WithEvents PnlButtons As Panel
    Friend WithEvents PnlMetatiles As Panel
#End Region
End Class