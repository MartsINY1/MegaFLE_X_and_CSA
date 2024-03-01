Option Explicit On

Friend Class MFLE_Main
	Inherits System.Windows.Forms.Form

	Private updlevel As Integer
	Private Gman_FC As Byte
	Private Gman_OF As Byte
	Private ReadOnly File1FileName As String = "*.ofs"

	'Objects that group many items
	'   Button
	Private Command3() As Button
	'   Button
	Private DumpBM_selection() As ToolStripMenuItem

	Private Sub Form_Initialize()
		' Object that groups many items
		' Button
		Command3 = New Button() {_Command3_0, _Command3_1}
		' ToolStripMenuItem
		DumpBM_selection = New ToolStripMenuItem() {_DumpBM_selection_0, _DumpBM_selection_1, _DumpBM_selection_2, _DumpBM_selection_3, _DumpBM_selection_4, _DumpBM_selection_5, _DumpBM_selection_6, _DumpBM_selection_7, _DumpBM_selection_8, _DumpBM_selection_9, _DumpBM_selection_10, _DumpBM_selection_11, _DumpBM_selection_12, _DumpBM_selection_13, _DumpBM_selection_14}

		'Ensure that if on form ListView size is changed, columns size follow
		File1.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize)
		File1.Columns(0).Width = File1.Width - 21 - (File1.Padding.Left + File1.Padding.Right)
		File1.Columns(1).Width = 0
		RefreshListBoxAsFileListBox(File1, File1FileName, CurDir())
	End Sub

	Public Function GiveReloadQ() As Byte
		GiveReloadQ = MsgBox("File was modified by another program. Reload changed file?", MsgBoxStyle.YesNo)
	End Function

	Public Sub Global_KeyDown(ByRef KeyCode As Short, ByRef Shift As Short)
		If KeyCode = System.Windows.Forms.Keys.F7 Then Me.Level_Next_Click()
		If KeyCode = System.Windows.Forms.Keys.F6 Then Me.Level_Previous_Click()
		If KeyCode = System.Windows.Forms.Keys.F4 Then Me.File_ReLoad_Click()
		If KeyCode = System.Windows.Forms.Keys.F5 Then Me.File_Save_Click()
		If KeyCode = System.Windows.Forms.Keys.F3 Then Me.File_Back_Click()
		If KeyCode = System.Windows.Forms.Keys.F9 Then Me.Tools_Test_Click()
		If KeyCode = System.Windows.Forms.Keys.F11 Then Me.Tools_RunShell_Click()
		If KeyCode = System.Windows.Forms.Keys.F12 Then Me.Menu_Config_Click()
		If Shift = 1 Then
			If KeyCode = System.Windows.Forms.Keys.P Then Me.View_PalEd_Click()
			If KeyCode = System.Windows.Forms.Keys.T Then Me.View_TT_Click()
			If KeyCode = System.Windows.Forms.Keys.B Then Me.View_TSAT_Click()
			If KeyCode = System.Windows.Forms.Keys.R Then Me.View_StrT_Click()
			If KeyCode = System.Windows.Forms.Keys.S Then Me.View_ScreenEd_Click()
			If KeyCode = System.Windows.Forms.Keys.E Then Me.View_EnemEd_Click()
			If KeyCode = System.Windows.Forms.Keys.M Then Me.Level_Misc_Click()
			If KeyCode = System.Windows.Forms.Keys.D Then View_DoorEd_Click()
			If KeyCode = System.Windows.Forms.Keys.X Then Me.Activate()
			If KeyCode = System.Windows.Forms.Keys.Z Then View_SBD_Click(View_SBD, New System.EventArgs())
		End If
	End Sub

	Private Sub Writehex()
		Dim a As Integer
		Dim tstr As String
		tstr = PatDataTB.Text
		For a = 0 To 31
			If ((a * 2) + 2) > Len(tstr) Then Exit Sub
			romdat(arrayAdjuster + Dec((PatOffsTB.Text)) + a) = Dec(Mid(tstr, (a * 2) + 1, 1) & Mid(tstr, (a * 2) + 2, 1))
		Next a
	End Sub

	Private Sub ShowSpecialCase(frm As Form)
		Common.Show(frm)

		EnemEd.EnemDatWrite()
	End Sub

	Private Sub Command1_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Command1.Click
		If File1.SelectedItems.Count > 0 Or File1.Items.Count = 0 Then
			FileOpen(1, Text14.Text, OpenMode.Binary)
			FilePut(1, offs)
			FileClose(1)
			RefreshListBoxAsFileListBox(File1, File1FileName, CurDir())
		Else
			MessageBox.Show("No Item selected in the list", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
		End If
	End Sub

	Private Sub Command18_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Command18.Click
		'Not covered:
		' * MM6 Enemy Data
		' * System bitmap colors
		' * Megaman's palette
		' * OffsType names
		' * Level names
		Dim a As Integer

		Dim PathBackup As String
		PathBackup = CurDir()
		ChDir(My.Application.Info.DirectoryPath)
		LoadResDat(GetCfg("datfile"))
		Update_Level()
		ChDir(PathBackup)

		For a = 0 To offsnum
			If rdata(dspa(d_offst) + a) = 0 Then offs(gem, a) = rdata(dspa(gem) + a)
		Next a
	End Sub

	Private Sub Command4_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Command4.Click
		If File1.SelectedItems.Count > 0 Then
			FileOpen(1, Text14.Text, OpenMode.Binary)
			FileGet(1, offs)
			FileClose(1)
		Else
			MessageBox.Show("No Item selected in the list", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
		End If

	End Sub

	Private Sub CurLevCombo_SelectedIndexChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles CurLevCombo.SelectedIndexChanged
		If CurLevCombo.Tag <> "" Then Exit Sub
		level = CurLevCombo.SelectedIndex
		EnemEd.ScrnScroll_Change(0)
		Me.Update_Level()
	End Sub

	Public Sub DumpBM_selection_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles _DumpBM_selection_5.Click, _DumpBM_selection_4.Click, _DumpBM_selection_3.Click, _DumpBM_selection_2.Click, _DumpBM_selection_14.Click, _DumpBM_selection_13.Click, _DumpBM_selection_12.Click, _DumpBM_selection_11.Click, _DumpBM_selection_10.Click, _DumpBM_selection_1.Click, _DumpBM_selection_0.Click, _DumpBM_selection_9.Click, _DumpBM_selection_8.Click, _DumpBM_selection_7.Click, _DumpBM_selection_6.Click
		Dim Index As Short = 0

		For Each radioButton As ToolStripMenuItem In DumpBM_selection
			If radioButton.Name = eventSender.Name Then
				Exit For
			End If
			Index += 1
		Next
		Select Case Index
			Case 0 : Dump_Bitmap_Sub(pal_bmi)
			Case 1 : Dump_Bitmap_Sub(pal2_bmi)
			Case 2 : Dump_Bitmap_Sub(tt_bmi)
			Case 3 : Dump_Bitmap_Sub(edittile_bmi)
			Case 4 : Dump_Bitmap_Sub(tsat_bmi)
			Case 5 : Dump_Bitmap_Sub(tsat_pal_bmi)
			Case 6 : Dump_Bitmap_Sub(sbds_scr_bmi)
			Case 7 : Dump_Bitmap_Sub(sbds_obj_bmi)
			Case 8 : Dump_Bitmap_Sub(str_bmi)
			Case 9 : Dump_Bitmap_Sub(scrn_scr_bmi)
			Case 10 : Dump_Bitmap_Sub(scrn_curstr_bmi)
			Case 11 : Dump_Bitmap_Sub(enem_scr_bmi)
			Case 12 : Dump_Bitmap_Sub(enem_scrb_bmi)
			Case 13 : Dump_Bitmap_Sub(enem_tile_bmi)
			Case 14 : Dump_Bitmap_Sub(enem_pal_bmi)
		End Select
	End Sub

	Private Sub Dump_Bitmap_Sub(bmix As BITMAPINFO)
		Dim bmfile As String
		Dim NiceDialog As New clsDialog
		Dim Title As String = "Write to.."
		Dim InitDir As String = ""
		Dim DefExt As String = ""
		Dim Filter As String = ".BMP files|*.bmp"
		Dim flags As clsDialog.DialogFlags

		bmfile = NiceDialog.ShowSave(Me, Title, flags, InitDir, DefExt, Filter)
		If Len(bmfile) = 0 Then
			Exit Sub
		End If
		bmfile = Common.Left(bmfile, Len(bmfile))

		' Adjust Picture Box to image
		picBoxDumping.Width = bmix.Header.biWidth
		picBoxDumping.Height = -bmix.Header.biHeight

		RenderModule.RenderPicEvenIfNoChange(picBoxDumping, bmix)

		picBoxDumping.Image?.Save(bmfile, System.Drawing.Imaging.ImageFormat.Bmp)
	End Sub

	Public Sub File_ReLoad_Click() Handles File_ReLoad.Click
		Try
			Dim sizeValue As Integer

			FileOpen(1, FileName, OpenMode.Binary)
			sizeValue = LOF(1)
			ReDim romdat(arrayAdjuster + sizeValue)
			FileGet(1, romdat)
			FileClose(1)

			GetMMCols()
			Update_Level()
			If GfxLoadEd.Visible Then GfxLoadEd.Update_Frm()
			If (gem = 2) Then
				' Always reload 0 since some other of its associated properties are reloaded on ROM reload, but not current one
				TileTable.CHRIDUD.Value = TileTable.CHRIDUD.Minimum + 1
				'	Vanue need to change to trigger a reloading of properties
				TileTable.CHRIDUD.Value = TileTable.CHRIDUD.Minimum
			End If
		Catch ex As Exception
			MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
		End Try
	End Sub

	Private Sub File1_SelectedIndexChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles File1.SelectedIndexChanged
		Try
			Text14.Text = File1.Items(File1.SelectedIndices(0)).SubItems(0).Text
		Catch ex As Exception
			Text14.Text = ""
		End Try
	End Sub

	Private Sub MFLE_Main_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
		If (ActiveControl.Name = Text14.Name) Then Exit Sub

		Dim KeyCode As Short = eventArgs.KeyCode
		Dim Shift As Short = eventArgs.KeyData \ &H10000
		Me.Global_KeyDown(KeyCode, Shift)
	End Sub

	Public Sub Manual_Init()
		Dim tstr As String
		Dim b, a, c As Integer
		Dim fileOpened As Boolean
		Dim Title As String = "Select ROM"
		Dim InitDir As String = ""
		Dim DefExt As String = ""
		Dim Filter As String = "nes roms (*.nes)|*.nes|all files (*.*)|*.*"
		Dim flags As clsDialog.DialogFlags = clsDialog.DialogFlags.CHECKFILEEXISTS Or clsDialog.DialogFlags.CHECKPATHEXISTS Or clsDialog.DialogFlags.PROHIBEREADONLY

		'FileName = "megaman6.nes"
		'gem = 1
		'GoTo debuginit

		Dim cdl As New clsDialog

		Do
			Try
				FileName = GetCfg("auto_loadrom")
				If (FileName = "") Then
					FileName = cdl.ShowOpen(Me, Title, flags, InitDir, DefExt, Filter)
					If Len(FileName) = 0 Then File_Exit_Click(File_Exit, New System.EventArgs()) : End
					FileName = Common.Left(FileName, Len(FileName))
				End If

				'debuginit:
				FileOpen(1, FileName, OpenMode.Binary)
				fileOpened = True
			Catch ex As Exception
				fileOpened = False
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
			End Try
		Loop Until (fileOpened)
		b = LOF(1)
		ReDim romdat(arrayAdjuster + b)
		FileGet(1, romdat)
		FileClose(1)

		EditFile_SaveDateStr = CStr(FileDateTime(FileName))

		ChDir(My.Application.Info.DirectoryPath)
		LoadResDat(GetCfg("datfile"))

		If (romdat(7) = 8) Then
			MegaManEngineMode = True
			gem = 2
			GoTo gamemodefound
		End If

		For a = 0 To 3
			c = rdata(dspa(d_identsign) + a)
			For b = 0 To (rdata(c + 1) - 1)
				If (rdata(c) + b) > UBound(romdat) Then GoTo notthisgame
				If Not romdat(arrayAdjuster + rdata(c) + b + 1) = rdata(c + 2 + b) Then GoTo notthisgame
			Next b
			gem = a : GoTo gamemodefound
notthisgame:
		Next a

		tstr = LCase(InputBox("Couldn't detect game, Input Editing Mode ('mm3', 'mm4', 'mm5' or 'mm6')."))
		If tstr = "mm3" Then gem = 0
		If tstr = "mm4" Then gem = 1
		If tstr = "mm5" Then gem = 2
		If tstr = "mm6" Then gem = 3

		If gem = -1 Then
			MessageBox.Show("Not a valid game mode, mm5 will be picked)", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
			gem = 2
		End If

gamemodefound:

		If gem <> 1 Then
			Other_GfxLoadEd.Enabled = False
		End If
		If gem = 3 Then
			Other_TextEd.Enabled = False
			Stats_EnemUsage.Enabled = False
		End If

		lblGamePath1.Text = "Opened " & sse & FileName & sse
		lblGamePath2.Text = "Editing mode: Mega Man " & CStr(3 + gem)

		dummy = " " & Mid(File_Back.Text, 6, 4)

		If gem = 3 Then
			EnemDataBot = New DataMoverBot
			EnemDataBot.DataBotFeed(dspa(58))

			b = (EnemDataBot.TblEntries - 1)
			EnemDataBot.CurEntry = b
			a = romdat(arrayAdjuster + rdata(dspa(d_ex) + 34) + b)

			b = EnemDataBot.EntryMEMPtr
			c = EnemDataBot.DataEndMEMPtr - (b + 5 + a + a + a + a)
			EnemDataBot.FreeSpace = c
		End If

		'Load bitmap colors (system colors)
		For a = 0 To 6
			glob_pal(&H21S + a) = rdata(dspa(d_syspal) + a)
		Next a

		For a = 0 To offsnum
			If rdata(dspa(d_offst) + a) = 0 Then offs(gem, a) = rdata(dspa(gem) + a)
		Next a

		GetMMCols()

		level = 0
		storelevel = 0
		curlsdid = 0
		curppueff = 0

		For a = 0 To 27
			OffsTypeCombo.Items.Add(SrcString(rdata(dspa(d_offstname) + a)))
		Next a
		OffsTypeCombo.SelectedIndex = 0
		SetTBCoolText(OffsDatTB, Hex(offs(gem, OffsTypeCombo.SelectedIndex)))

		'Here, we will start doing stuff with the forms, initialise all of them
		Config.Manual_Init()
		DoorEd.Manual_Init()
		EnemEd.Manual_Init()
		GfxLoadEd.Manual_Init()
		MiscEd.Manual_Init()
		PalChart.Manual_Init()
		PalEd.Manual_Init()
		ProtoWnd.Manual_Init()
		SBDSpecial.Manual_Init()
		ScreenEd.Manual_Init()
		MetametatileTable.Manual_Init()
		TextEd.Manual_Init()
		TileTable.Manual_Init()
		MetatileTable.Manual_Init()


		CurLevCombo.Items.Clear()
		For a = 0 To offs(gem, 0)
			CurLevCombo.Items.Add(CStr(a) & ": " & SrcString(rdata(dspa(d_levnames + gem) + a)))
		Next a

		Update_Level() 'This triggers Form_Load for every Form.

		'ReDim SBD_Base(15, &H3F, &HFF)    'Dim 1: Level
		't = Asc(mid$(romdat, 1 + leveloff + rdata(dspa(gem) + 25), 1))

		PALAnimEnable = GetCfg("palanim")
		CHRAnimEnable = GetCfg("chranim")

		'MainTimedLoop
		'Enabled = True

		If gem = 1 Then
			FrameMegaMan4.Visible = True
		End If
		If gem = 3 Then
			FrameMegaMan6.Visible = True
		End If
	End Sub

	Public Sub GetMMCols()
		Dim col As Integer
		If gem < 3 Then
			For col = 0 To &HFS
				If (col And 3) = 0 Then
					glob_pal(col + &H40S) = RGB(&H80S, 0, &H80S)
				Else
					If col < 8 Then
						glob_pal(col + &H40S) = NESPAL(romdat(arrayAdjuster + offs(gem, o_mmpal) + col))
						PPU_palette_val(&H10S + col) = romdat(arrayAdjuster + offs(gem, o_mmpal) + col)
					End If
				End If
			Next col
		End If
		Update_Global_Pal(False)
	End Sub

	Public Sub Update_Level()
		Dim a, t As Integer

		RefreshLock = True

		For a = 0 To offsnum
			If rdata(dspa(d_offst) + a) = 0 Then offs(gem, a) = rdata(dspa(gem) + a)
		Next a

		If gem = 3 Then Update_LevelMM6() : GoTo skipifMM6

		If scenemode = False Then
			leveloff = rdata(dspa(gem) + 1) + (level * &H2000S)
		Else
			a = rdata(rdata(dspa(d_scenesbank) + gem) + level)
			leveloff = rdata(dspa(gem) + 1) + (a * &H2000S)
		End If

		'Set up pointers for level data
		For a = 0 To offsnum
			If rdata(dspa(d_offst) + a) = 1 Then offs(gem, a) = leveloff + rdata(dspa(gem) + a)
		Next a

		If scenemode = True Then
			a = rdata(rdata(dspa(d_scenesbank) + gem) + level)
			sbdoff = rdata(dspa(gem) + 1) + (a * &H2000S)
		Else
			If (gem = 0) Or (gem = 2) Then
				a = romdat(arrayAdjuster + offs(gem, o_sbd) + level)
				sbdoff = rdata(dspa(gem) + 1) + (a * &H2000S)
			Else
				sbdoff = leveloff
			End If
		End If

		'Set up pointers for level graphics data (SBD)
		For a = 0 To offsnum
			If rdata(dspa(d_offst) + a) = 2 Then offs(gem, a) = sbdoff + rdata(dspa(gem) + a)
		Next a

skipifMM6:

		For a = 0 To 3 : PA_ID(a) = 0 : Next a
		CA_ID = 0

		Dim chrbankoffs1, chrbankoffs2 As Integer

		If (gem = 0) Or (gem = 2) Then
			chrbankoffs1 = (CInt(romdat(arrayAdjuster + offs(gem, o_chrpt) + 0)) * &H400S)
			chrbankoffs2 = (CInt(romdat(arrayAdjuster + offs(gem, o_chrpt) + 1)) * &H400S)
			'obscure --->
			'If scenemode = True Then
			'    a = 0
			'    c = 0
			'findscenescreen_loop:
			'    b = rdata(rdata(dspa(d_scenesdata + gem) + level) + (a * 4))
			'    If b = &HFF Then GoTo findscenescreen_done
			'    If b <= curscreen Then c = a
			'    a = a + 1
			'    GoTo findscenescreen_loop
			'findscenescreen_done:
			'    chrbankoffs1 = rdata(rdata(dspa(d_scenesdata + gem) + level) + (c * 4) + 1)
			'    chrbankoffs1 = chrbankoffs1 * &H400
			'    chrbankoffs2 = rdata(rdata(dspa(d_scenesdata + gem) + level) + (c * 4) + 2)
			'    chrbankoffs2 = chrbankoffs2 * &H400
			'Else

			'End If
			'<----

			For t = 0 To 127
				chrmap(t) = offs(gem, o_chroffs) + chrbankoffs1 + (t * &H10S)
				chrmap(t + 128) = offs(gem, o_chroffs) + chrbankoffs2 + (t * &H10S)
			Next t
		End If

		'Load default sprite tiles
		If gem = 0 Then
			For t = 0 To 63
				chrmap(t + &H100S) = offs(gem, o_chroffs) + (rdata(dspa(d_ex) + 28) * &H400S) + (t * 16)
				chrmap(t + &H140S) = offs(gem, o_chroffs) + (rdata(dspa(d_ex) + 29) * &H400S) + (t * 16)
			Next t
		End If

		'Load default sprite tiles
		If gem = 2 Then
			For t = 0 To 63
				chrmap(t + &H100S) = offs(gem, o_chroffs) + (t * 16)
				chrmap(t + &H140S) = offs(gem, o_chroffs) + &H1800 + (t * 16)
			Next t
		End If

		If scenemode = False Then
			If gem = 1 Then InitEffectLoad()
		End If

		If gem = 3 Then
			a = romdat(arrayAdjuster + rdata(dspa(d_ex) + 26) + level)
			MM6CHRLoad(0)
			MM6CHRLoad(1)
			MM6CHRLoad(a)
			LoadMM6Pal(0, rdata(dspa(d_ex) + 30)) '9
		End If

		'If scenemode = True Then
		'    offs(gem, o_pal) = &H1840D + 1
		'End If

		SetComboCool(CurLevCombo, level)

		If GetCfg("cllevelscr") > 0 Then curscreen = 0

		sbdscreen = 0
		SBDCurObj = 0


		'Some Update_Level routines do refreshes, becouse it makes things less complicated.
		'So turn RefreshLock off here.
		RefreshLock = False

		' This wasn't in original MegaFLE_X but since images were always rendered, it was not noticeable
		'	(New level would be shown quickly with wrong Palettes)
		Update_PalSet()

		updlevel = True
		Update_Scrn()
		updlevel = False

		If PalEd.Visible Then PalEd.Update_Level()
		If TileTable.Visible Then TileTable.Update_Level()
		If MetatileTable.Visible Then MetatileTable.Update_Level()
		If MetametatileTable.Visible Then MetametatileTable.Update_Level()
		If MiscEd.Visible Then MiscEd.Update_Level()
		If SBDSpecial.Visible Then SBDSpecial.Update_Level()
		If GfxLoadEd.Visible Then GfxLoadEd.Update_Level()
		If ScreenEd.Visible Then ScreenEd.Update_Level()
		If DoorEd.Visible Then DoorEd.Update_Frm()
	End Sub

	Public Sub Update_LevelMM6()
		'See, MM6 is so unique, it needs its own routine.
		Dim gfxbankoff, scrbankoff As Integer ', a As Long
		Dim tmpscr, e, c, a, b, d, f, enem As Integer

		'gfxbankoff = Asc(mid$(romdat, rdata(dspa(d_ex) + 20), 1))
		'gfxbankoff = (gfxbankoff * &H2000&) + &H11
		gfxbankoff = (romdat(arrayAdjuster + rdata(dspa(d_ex) + 20) + level) * &H2000) + &H11S

		a = ((romdat(arrayAdjuster + rdata(dspa(d_ex) + 22) + level) - &H80S) * &H100S)
		offs(3, 3) = gfxbankoff + a
		offs(3, 4) = gfxbankoff + a + &H400S
		a = ((romdat(arrayAdjuster + rdata(dspa(d_ex) + 24) + level) - &H80S) * &H100S)
		offs(3, 5) = gfxbankoff + a

		scrbankoff = (romdat(arrayAdjuster + rdata(dspa(d_ex) + 21) + level) * &H2000) + &H11S
		a = ((romdat(arrayAdjuster + rdata(dspa(d_ex) + 23) + level) - &HA0S) * &H100S)
		offs(3, 6) = scrbankoff + a

		For a = 7 To 14
			offs(3, a) = 1
		Next a

		EnemDataBot.CurEntry = level

		a = romdat(arrayAdjuster + rdata(dspa(d_ex) + 34) + level)
		offs(3, 11) = EnemDataBot.EntryROMPtr + 2
		offs(3, 12) = EnemDataBot.EntryROMPtr + a + 3
		offs(3, 13) = EnemDataBot.EntryROMPtr + a + a + 4
		offs(3, 14) = EnemDataBot.EntryROMPtr + a + a + a + 5
		offs(3, 19) = (a - 1)

		'Load CHR/PAL events for whole level into database
		MM6_scroll_info_count = 0
		For enem = 0 To offs(gem, 19)
			e = romdat(arrayAdjuster + offs(gem, 11) + enem)
			'If (a = curscreen) Then
			a = romdat(arrayAdjuster + offs(gem, 14) + enem)
			If (a = &H80S) Then
				a = romdat(arrayAdjuster + offs(gem, 13) + enem)
				b = &H72011 + ((romdat(arrayAdjuster + &H7237C + a) - &H80S) * &H100S) + romdat(arrayAdjuster + &H722FC + a)
				'Here comes a (hopefully working) algorith simulator for the most non-sense data ever..
				c = 1
				a = romdat(arrayAdjuster + b)
				If a <= &H7FS Then GoTo setstart
				'Special routine call is done here
				d = ((romdat(arrayAdjuster + b + 0) - &H80S) * &H100S) + romdat(arrayAdjuster + b + 1)
				d += &H8000
				If d = &H849B Then GoTo findeffsprnext6 'Fix Flameman & Plantman glitch-up
				c = 3
setstart:
				d = c + 2
				'xAC = d
				'd = xAC
readAC:
				f = romdat(arrayAdjuster + b + d)
				If (f >= &H1S) And (f <= &H7FS) Then
					MM6_scroll_info_segdir(MM6_scroll_info_count) = f
					a = romdat(arrayAdjuster + b + d + 1)
					MM6_scroll_info_CHRload(MM6_scroll_info_count) = a
					a = romdat(arrayAdjuster + b + d + 2)
					MM6_scroll_info_PALload(MM6_scroll_info_count) = a
					a = romdat(arrayAdjuster + b + d + 3)
					d += 3
					If a <= &H7FS Then
						tmpscr = e
						'mm6_readscrollevent_jumpnextseg:
					Else
						tmpscr = (a And &H7FS)
						d += 1
					End If
					If (f = 3) Or (f = 4) Then
						'tmpscr = tmpscr - 1
						GoTo readAC 'dont register backwards scroll events
					Else
						tmpscr += 1
					End If
					MM6_scroll_info_scr(MM6_scroll_info_count) = tmpscr
					MM6_scroll_info_count += 1
					If MM6_scroll_info_count = const_MM6_scroll_info_maxnum Then
						GoTo donefindeffspr6
					End If
					GoTo readAC
				End If
			End If
findeffsprnext6:
		Next enem
donefindeffspr6:

	End Sub


	Public Sub Update_Scrn()
		Dim spscreen, spsmap, a As Integer
		Dim stack_RefreshLock As Boolean
		Dim stack_RefreshPalLock As Boolean
		Dim scrolltype, scrollscrs As Integer

		stack_RefreshLock = RefreshLock
		stack_RefreshPalLock = RefreshPalLock
		RefreshLock = True
		RefreshPalLock = True

		oldscroll = curscroll

		'Locate Screen's Scroll Map
		spscreen = 0
		curscroll_sscrn = 0
		For spsmap = 0 To offs(gem, o_maxsmp)
			scrolltype = CShort(romdat(arrayAdjuster + offs(gem, o_dirtype) + spsmap) And &HE0S) / 32
			If gem = 2 Then
				scrollscrs = romdat(arrayAdjuster + offs(gem, o_dirtype) + spsmap) And &H1FS
			Else
				scrollscrs = romdat(arrayAdjuster + offs(gem, o_dirtype) + spsmap) And &HFS
			End If
			If scrolltype = 0 Then
				If GetCfg("alwaysskipscrollzero") = 1 Then
					GoTo spsmapskip
				End If
			End If
			For a = 0 To scrollscrs
				If spscreen = curscreen Then GoTo spsmapfound
				spscreen += 1
			Next a
			curscroll_sscrn = spscreen
spsmapskip:
			'Prevent current scroll from becoming 1 above max.
			If (spsmap = offs(gem, o_maxsmp)) Then GoTo spsmapfound
		Next spsmap
spsmapfound:
		If (curscroll <> spsmap) And (gem = 1) Then
			If spsmap = 0 Then
				InitEffectLoad() 'Load graphics which is loaded at beginning of level.
			Else
				ScrollEffectLoad(spsmap) 'Load graphics for Scroll Map
			End If
		End If

		curscroll = spsmap
		nextscroll_sscrn = curscroll_sscrn + scrollscrs + 1

		If GfxLoadEd.Visible = True Then GfxLoadEd.Update_PPUEff()

		If scenemode = True Then
			SceneMode_LoadScrSetup()
		Else
			SprCHRPALSetup() 'Set up Sprite CHR and Palette for screen
			Update_PalSet()
			EffSpriteSimulate() 'Simulate effect sprites in Scroll Map
		End If

		'Update_BGPal 1, 1 'Might not be needed done every screen, but do for now.

		If EnemEd.Visible = True Then EnemEd.Update_Scrn()
		If ScreenEd.Visible = True Then ScreenEd.Update_Scrn()

		If scenemode = True Then
			If MetametatileTable.Visible = True Then MetametatileTable.Update_Level()
			If TileTable.Visible = True Then TileTable.Update_Level()
			If MetatileTable.Visible = True Then MetatileTable.Update_Level()
			If SBDSpecial.Visible = True Then SBDSpecial.Update_Level()
			If MiscEd.Visible = True Then MiscEd.Update_Level()
		End If

		RefreshPalLock = stack_RefreshPalLock

		'Update_Frm bitmap palette arrays and other palette related stuff,
		'but wait with refresh to PictureBox, let RefreshAllBitmaps do it.
		Update_Global_Pal(True)

		RefreshLock = stack_RefreshLock

		Update_RefreshAllBitmaps()

		'RefreshLock = stack_RefreshLock
	End Sub

	Private Sub SceneMode_LoadScrSetup()
		Dim c, a, b As Integer
		Dim chrbankoffs1, chrbankoffs2 As Integer

		a = 0
		c = 0
findscenescreen_loop:
		b = rdata(rdata(dspa(d_scenesdata + gem) + level) + (a * 4))
		If b = &HFFS Then GoTo findscenescreen_done
		If b <= curscreen Then c = a
		a += 1
		GoTo findscenescreen_loop
findscenescreen_done:

		Dim canChangeId As Integer
		If (gem = 0) Or (gem = 2) Then

			a = rdata(rdata(dspa(d_scenesdata + gem) + level) + (c * 4) + 1) + 1
			'offs(gem, o_chrpt) = a
			SceneModeInfo.other_Ptr1 = a
			b = romdat(arrayAdjuster + a)
			chrbankoffs1 = b * &H400S
			a = rdata(rdata(dspa(d_scenesdata + gem) + level) + (c * 4) + 2) + 1
			SceneModeInfo.other_Ptr2 = a
			b = romdat(arrayAdjuster + a)
			chrbankoffs2 = b * &H400S

			For b = 0 To 127
				chrmap(b) = offs(gem, o_chroffs) + chrbankoffs1 + (b * &H10S)
				chrmap(b + 128) = offs(gem, o_chroffs) + chrbankoffs2 + (b * &H10S)
			Next b

		Else

			a = rdata(rdata(dspa(d_scenesdata + gem) + level) + (c * 4) + 1) + 1
			b = romdat(arrayAdjuster + a)
			InitEffectLoad_Specified(b)
			SceneModeInfo.gfxLoadId_Ptr = a
			canChangeId = rdata(rdata(dspa(d_scenesdata + gem) + level) + (c * 4) + 2) '
			If canChangeId = 1 Then
				SceneModeInfo.canChangeId = False
			Else
				SceneModeInfo.canChangeId = True
			End If

		End If

		offs(gem, o_pal) = (rdata(rdata(dspa(d_scenesdata + gem) + level) + (c * 4) + 3) + 1)

		Update_RefreshPalSet(True)

	End Sub

	Public Sub Update_PalSet()
		'Notes: Update_Frm new palette set, based on current scroll map
		Dim a As Integer
		Dim b, c As Integer
		Dim palupdflag As Boolean
		Dim sm_palset As Integer

		palupdflag = False
		Select Case gem
			Case 0
				a = romdat(arrayAdjuster + offs(gem, o_ddA) + (curscroll * 2) + 1)
				If (a <= offs(gem, o_palmax)) Then
					sm_palset = a
					palupdflag = True
				End If
			Case 1
				a = romdat(arrayAdjuster + offs(gem, o_ddA) + curscroll)
				If curscroll = 0 Then a = 0
				If (curscroll = 0) Or (updlevel = True) Then
					palupdflag = True
					sm_palset = a
				ElseIf (a > 0) And (a <= offs(gem, o_palmax)) Then
					palupdflag = True
					sm_palset = a
				End If
			Case 2
				If curscroll = 0 Or updlevel = True Then
					palupdflag = True
					sm_palset = 0
				End If
				a = romdat(arrayAdjuster + offs(gem, o_ddA) + curscroll) And &H3FS
				If a > 0 Then
					b = romdat(arrayAdjuster + offs(gem, 27) + ((a - 1) * 8))
					If b >= &H80S Then
						c = (b And &H7FS)
						If (c <= offs(gem, o_palmax)) Then
							palupdflag = True
							sm_palset = c
						End If
					End If
					b = romdat(arrayAdjuster + offs(gem, 27) + ((a - 1) * 8) + 4)
					If b > 0 Then
						b *= &H400S
						For c = 0 To 127
							chrmap(c + 128) = offs(gem, o_chroffs) + b + (c * &H10S)
						Next c
					End If
				End If
				'palupdflag = True
				'For b = 0 To 3: PA_ID(b) = Asc(mid$(romdat, offs(gem, o_pal) + (palset * palsetWidth) + &H10 + b, 1)): Next b
			Case 3
				sm_palset = 0
				palupdflag = True
		End Select

		If palsetChangeType = 0 Then
			palset = sm_palset
		End If
		Update_RefreshPalSet(palupdflag)
	End Sub

	'Note: This is called when the user has used the
	'"Force Palette Set" function and are updating the palette set's contents.
	'Update_PalSet would revert the palette set back to the one in the current scroll
	'map. This is now called instead to refresh stuff without changing the palette set.
	Public Sub Update_RefreshPalSet(ByRef palupdflag As Boolean)
		Dim a As Integer
		Dim col As Integer

		PalAnim_Reset()

		If gem < 3 Then
			If palupdflag = True Then
				For col = 0 To &HFS
					If (col And 3) = 0 Then
						a = romdat(arrayAdjuster + offs(gem, o_pal) + (palset * palsetWidth) + 0)
						glob_pal(col) = NESPAL(a)
						glob_pal(col + &H10S) = NESPALD(a)
						glob_pal(col + &H30S) = NESPALL(a)
						glob_pal(col + &H50S) = NESPAL(a)
						PPU_palette_val(col) = a
					Else
						a = romdat(arrayAdjuster + offs(gem, o_pal) + (palset * palsetWidth) + col)
						glob_pal(col) = NESPAL(a)
						glob_pal(col + &H10S) = NESPALD(a)
						glob_pal(col + &H30S) = NESPALL(a)
						glob_pal(col + &H50S) = NESPAL(a)
						PPU_palette_val(col) = a
					End If
				Next col
				For a = 0 To 3 : PA_ID(a) = romdat(arrayAdjuster + offs(gem, o_pal) + (palset * palsetWidth) + &H10S + a) : Next a
			End If
		Else
			a = romdat(arrayAdjuster + rdata(dspa(d_ex) + 25) + level)
			If curscreen = 0 Then
				'Load at start of level, dont overwrite mid-level palette changes.
				LoadMM6Pal(0, a)
			End If
		End If

		Update_Global_Pal(False) 'Set to False, assume refreshes are done later.

		PalEd.Update_PalSet()

		If TileTable.Visible Then TileTable.Update_BGPal(1)
		If MetatileTable.Visible Then MetatileTable.Update_BGPal(1)
		If ScreenEd.Visible Then ScreenEd.Update_PalSet()
		If EnemEd.Visible Then EnemEd.Update_BGPal(1)
		If MetametatileTable.Visible Then MetametatileTable.Update_BGPal(1)
		If SBDSpecial.Visible Then SBDSpecial.Update_BGPal(1)
	End Sub

	Public Sub Update_BGPal(ByRef upd As Integer)
		'Update_Frm to the current palette.

		'Dim a As Long
		'Dim b, c, d, col, enem
		'Dim palupdflag As Boolean

		'Update_Global_Pal False

		If PalEd.Visible Then PalEd.Update_PalSet()
		If TileTable.Visible Then TileTable.Update_BGPal(upd)
		If MetatileTable.Visible Then MetatileTable.Update_BGPal(upd)
		If ScreenEd.Visible Then ScreenEd.Update_PalSet()
		If EnemEd.Visible Then EnemEd.Update_BGPal(upd)
		If MetametatileTable.Visible Then MetametatileTable.Update_BGPal(upd)
		If SBDSpecial.Visible Then SBDSpecial.Update_BGPal(upd)
	End Sub

	Public Sub EffSpriteSimulate()
		Dim edscrpos As Integer
		Dim enem, c, a, b, d, col As Integer
		Dim effsprsimenable As Integer
		Dim ID_taken_tmp(3) As Object

		effsprsimenable = GetCfg("effsprsim")
		If (Not gem = 3) And (effsprsimenable = 0) Then Exit Sub

		edscrpos = 0
		Select Case gem
			Case 1
				For enem = 0 To offs(gem, 19)
					a = romdat(arrayAdjuster + offs(gem, 11) + enem)
					If a > edscrpos Then edscrpos = a
					If a < edscrpos Then GoTo donefindeffspr4 'findeffsprnext4
					If a < curscreen Then GoTo findeffsprnext4
					'If a >= curscroll_sscrn And a < nextscroll_sscrn Then 'p = curscreen
					If a = curscreen Then
						If romdat(arrayAdjuster + offs(gem, 14) + enem) >= &HC0S Then
							a = romdat(arrayAdjuster + offs(gem, 14) + enem) And &H3FS
							b = romdat(arrayAdjuster + rdata(dspa(d_ex) + 8) + a) And 3
							c = romdat(arrayAdjuster + rdata(dspa(d_ex) + 9) + a)
							If c >= &H80S And ID_taken_tmp(b) = False Then
								ID_taken_tmp(b) = True
								PA_ID(b) = c
								PA_DelayC(b) = 0
								PA_FrameN(b) = 0
							Else
								For col = 1 To 3
									a = romdat(arrayAdjuster + rdata(dspa(d_ex) + 10) + (c * 4) + col)
									glob_pal((b * 4) + col) = NESPAL(a)
									glob_pal((b * 4) + col + &H10S) = NESPALD(a)
									glob_pal((b * 4) + col + &H30S) = NESPALL(a)
									glob_pal((b * 4) + col + &H50S) = NESPAL(a)
									PPU_palette_val((b * 4) + col) = a
								Next col
							End If
						End If
					End If
findeffsprnext4:
				Next enem
donefindeffspr4:
			Case 2
				For enem = 0 To offs(gem, 19)
					a = romdat(arrayAdjuster + offs(gem, 11) + enem)
					If a > edscrpos Then edscrpos = a
					If a < edscrpos Then GoTo donefindeffspr5 'findeffsprnext5
					If a < curscreen Then GoTo findeffsprnext5
					'If a >= curscroll_sscrn And a < nextscroll_sscrn Then 'p = curscreen
					If a = curscreen Then
						d = romdat(arrayAdjuster + offs(gem, 14) + enem)
						If d >= &HC0S Then
							c = (d And &H3FS)
							a = romdat(arrayAdjuster + rdata(dspa(d_ex) + 12) + c)
							If a >= &H80S Then
								CA_ID = a
								CA_DelayC = 0
								CA_FrameN = 0
							Else
								If a >= &H10S Then
putchrbank5:
									b = romdat(arrayAdjuster + rdata(dspa(d_ex) + 16) + a)
									c = romdat(arrayAdjuster + rdata(dspa(d_ex) + 16) + a + 1)
									b *= &H400S
									c *= &H400S
									For d = 0 To 127
										chrmap(d) = offs(gem, o_chroffs) + b + (d * &H10S)
										chrmap(d + 128) = offs(gem, o_chroffs) + c + (d * &H10S)
									Next d
									CA_ID = 0
									CA_DelayC = 0
									CA_FrameN = 0
								Else
									b = romdat(arrayAdjuster + rdata(dspa(d_ex) + 13) + c)
									If b >= &H80S Then
										If ID_taken_tmp(a) = False Then
											ID_taken_tmp(a) = True
											PA_ID(a) = b
											PA_DelayC(a) = 0
											PA_FrameN(a) = 0
										End If
									Else
										For col = 1 To 3
											c = romdat(arrayAdjuster + rdata(dspa(d_ex) + 15) + (b * 4) + col)
											glob_pal(a + col) = NESPAL(c)
											glob_pal(a + col + &H10S) = NESPALD(c)
											glob_pal(a + col + &H30S) = NESPALL(c)
											glob_pal(a + col + &H50S) = NESPAL(c)
											PPU_palette_val((a + col) And &H1FS) = c
										Next col
										c = Int(a / 4)
										If ID_taken_tmp(c) = False Then
											ID_taken_tmp(c) = True
											PA_ID(c) = 0
											PA_DelayC(c) = 0
											PA_FrameN(c) = 0
										End If
										c = romdat(arrayAdjuster + rdata(dspa(d_ex) + 15) + (b * 4))
										If c > 0 Then
											If c > &H80S Then
												glob_pal(0) = NESPAL(c And &H3FS)
												glob_pal(&H10S) = NESPALD(c And &H3FS)
												glob_pal(&H30S) = NESPALL(c And &H3FS)
												glob_pal(&H50S) = NESPAL(c And &H3FS)
												PPU_palette_val(0) = (c And &H3FS)
											Else
												a = c : GoTo putchrbank5
											End If
										End If
									End If
								End If
							End If
						End If
					End If
findeffsprnext5:
				Next enem
donefindeffspr5:
			Case 3

				For a = 0 To (MM6_scroll_info_count - 1)
					If (MM6_scroll_info_scr(a) = curscreen) And (effsprsimenable = 1) Then
						b = MM6_scroll_info_CHRload(a)
						If b >= &H80S Then MM6CHRLoad(b)
						b = MM6_scroll_info_PALload(a)
						If b > 0 Then LoadMM6Pal(0, b)
					End If
				Next a

				For enem = 0 To offs(gem, 19)
					a = romdat(arrayAdjuster + offs(gem, 11) + enem)
					If a > edscrpos Then edscrpos = a
					If a < edscrpos Then GoTo donefindeffspr6 'findeffsprnext5
					If a < curscreen Then GoTo findeffsprnext6
					'If a >= curscroll_sscrn And a < nextscroll_sscrn Then 'p = curscreen
					If (a = curscreen) Then
						a = romdat(arrayAdjuster + offs(gem, 14) + enem)
						If (Not a = &H80S) And (romdat(arrayAdjuster + &H743DA + a)) > 0 Then
							b = (romdat(arrayAdjuster + &H744DA + a) * &H2000) + ((romdat(arrayAdjuster + &H743DA + a) - &H80S) * &H100S) + romdat(arrayAdjuster + &H742DA + a) + &H11S
							c = romdat(arrayAdjuster + b - 4)
							If c > 0 Then MM6CHRLoad(c)
							c = romdat(arrayAdjuster + b - 5)
							If c > 0 Then LoadMM6Pal(0, c)
						End If
					End If
findeffsprnext6:
				Next enem
donefindeffspr6:
		End Select

		Update_Global_Pal(False)
	End Sub

	Public Sub InitEffectLoad()
		InitEffectLoad_Specified(level)
	End Sub

	Private Sub InitEffectLoad_Specified(ByRef id As Integer)
		Dim lidHi, lidLo, lidoff As Integer
		lidLo = romdat(arrayAdjuster + rdata(dspa(d_ex) + 2) + id)
		lidHi = romdat(arrayAdjuster + rdata(dspa(d_ex) + 3) + id)
		lidHi = (lidHi - &HA0S) + rdata(dspa(d_ex) + 4)
		lidoff = (lidHi * 256) + lidLo + &H11S
		EffectLoad(lidoff, &H10S)
	End Sub

	Public Sub EffectLoad(ByRef eoff As Integer, ByRef sizedim As Integer)
		Dim d, b, c, pt As Integer
		For c = 0 To 7
			pt += 1
			If romdat(arrayAdjuster + eoff + c) >= &H80S Then GoTo effload_paldone
			If (c And 3) > 0 Then
				sprpaloff(c) = eoff + c
				glob_pal(c + &H48S) = NESPAL(romdat(arrayAdjuster + eoff + c))
				PPU_palette_val(c + &H18S) = romdat(arrayAdjuster + eoff + c)
			End If
		Next c
effload_paldone:
		Update_Global_Pal(False)

		'0 = Source Bank
		'1 = Tiles/Rows to copy ($10/$100 bytes)
		'2 = Source High byte offset
		'3 = Dest. High byte Offset

effloadloop:
		If romdat(arrayAdjuster + eoff + 0 + pt) >= &H80S Then GoTo doneeffload
		c = romdat(arrayAdjuster + eoff + 0 + pt)
		d = romdat(arrayAdjuster + eoff + 2 + pt)
		If d >= &HC0S Then c = &H3CS
		If romdat(arrayAdjuster + eoff + 3 + pt) < &H20S Then
			For b = 0 To (romdat(arrayAdjuster + eoff + 1 + pt) * sizedim) - 1
				If (romdat(arrayAdjuster + eoff + 3 + pt) * &H10S) + b >= &H200S Then GoTo effloadnext
				chrmap((romdat(arrayAdjuster + eoff + 3 + pt) * &H10S) + b) = (c * &H2000S) + ((d - &H80S) * &H100S) + (b * &H10S) + &H10S
			Next b
		End If
effloadnext:
		pt += 4
		If pt < &H100S Then GoTo effloadloop
doneeffload:
	End Sub

	Public Sub MM6CHRLoad(ByRef setID As Object)
		Dim e, c, a, b, d, f As Integer
		b = (CShort(romdat(arrayAdjuster + rdata(dspa(d_ex) + 27) + (setID * 4) + 3) And &H80S) / &H80S)
		c = romdat(arrayAdjuster + rdata(dspa(d_ex) + 27) + (setID * 4) + 1)
		d = (romdat(arrayAdjuster + rdata(dspa(d_ex) + 27) + (setID * 4) + 3) And &H7FS)
		e = romdat(arrayAdjuster + rdata(dspa(d_ex) + 27) + (setID * 4) + 2)
		f = romdat(arrayAdjuster + rdata(dspa(d_ex) + 27) + (setID * 4) + 0)
		If f = 0 Then f = 256
		For a = 0 To (f - 1)
			chrmap((b * &H100) + c + a) = (d * &H1000) + (e * &H10S) + (a * &H10S) + &H10S
		Next a
	End Sub

	Public Sub LoadMM6Pal(ByRef bank As Byte, ByRef palid As Object)
		Dim MM6PalData As DataMoverBot
		Dim a As Short
		Dim b, c As Integer
		Dim start As Integer
		Dim col As Byte
		Dim eromptr As Integer

		MM6PalData = New DataMoverBot
		If bank = 0 Then
			MM6PalData.DataBotFeed(dspa(69))
		Else
			MM6PalData.DataBotFeed(dspa(70))
		End If

		MM6PalData.CurEntry = palid

		start = MM6PalData.GetByte(0)
		a = 1
		b = start
LoadMM6Pal_Loop:
		c = MM6PalData.GetByte(a)
		eromptr = MM6PalData.EntryROMPtr
		If ((c And &H40S) = &H40S) Then
			MM6PalMap(b) = 0
			'MM6PalMap(b + 1) = eromptr + a
			b += 1
			'a = a + 0
		End If
		If ((c And &H80S) = &H80S) Then
			MM6PalMap(b) = eromptr + a
			GoTo LoadMM6PalDoneMap
		End If
		MM6PalMap(b) = eromptr + a
		b += 1
		a += 1
		GoTo LoadMM6Pal_Loop

LoadMM6PalDoneMap:
		For col = 0 To &H1FS
			If col < &H10S Then
				If (col And 3) = 0 Then b = 0 Else b = col
				If MM6PalMap(b) = 0 Then
					a = &HFS
				Else
					a = (romdat(arrayAdjuster + MM6PalMap(b) + 1) And &H3FS)
				End If
				glob_pal(col) = NESPAL(a)
				glob_pal(col + &H10S) = NESPALD(a)
				glob_pal(col + &H30S) = NESPALL(a)
				glob_pal(col + &H50S) = NESPAL(a)
				PPU_palette_val(col) = a
			Else
				If (col And 3) = 0 Then
					glob_pal((col - &H10S) + &H40S) = RGB(&H80S, 0, &H80S)
				Else
					If MM6PalMap(col) = 0 Then
						a = &HFS
					Else
						a = (romdat(arrayAdjuster + MM6PalMap(col) + 1) And &H3FS)
					End If
					glob_pal((col - &H10S) + &H40S) = NESPAL(a)
					PPU_palette_val((&H10S + col) And &H1FS) = a 'Note: something weird is going on here (Check Blizzardman)
				End If
			End If
		Next col

		For a = 0 To 3 : PA_ID(a) = 0 : Next a 'Asc(mid$(romdat, offs(gem, o_pal) + (palset * palsetWidth) + &H10 + a, 1)): Next a
	End Sub

	Public Function GetMM6Col(ByRef col As Object) As Object
		If Not MM6PalMap(col) = 0 Then
			GetMM6Col = (romdat(arrayAdjuster + MM6PalMap(col) + 1) And &H3FS)
		Else
			GetMM6Col = &HFS
		End If
	End Function

	Public Sub SetMM6Col(ByRef col As Object, ByRef cval As Object)
		Dim a As Integer
		If Not MM6PalMap(col) = 0 Then
			a = romdat(arrayAdjuster + MM6PalMap(col) + 1) And &HC0S
			romdat(arrayAdjuster + MM6PalMap(col) + 1) = (a Or (cval And &H3FS))
		End If
	End Sub

	Public Sub PalAnim_Reset()
		Dim a As Integer
		For a = 0 To 3
			PA_DelayC(a) = 0
			PA_FrameN(a) = 0
		Next a
	End Sub

	Public Sub Update_Global_Pal(ByRef render As Boolean)
		If RefreshPalLock = True Then Exit Sub

		pal_bmi.palette_UpdatedSinceLastBytesRGB_Update = True
		pal2_bmi.palette_UpdatedSinceLastBytesRGB_Update = True
		tt_bmi.palette_UpdatedSinceLastBytesRGB_Update = True
		edittile_bmi.palette_UpdatedSinceLastBytesRGB_Update = True
		tsat_bmi.palette_UpdatedSinceLastBytesRGB_Update = True
		tsat_pal_bmi.palette_UpdatedSinceLastBytesRGB_Update = True
		sbds_scr_bmi.palette_UpdatedSinceLastBytesRGB_Update = True
		sbds_obj_bmi.palette_UpdatedSinceLastBytesRGB_Update = True
		str_bmi.palette_UpdatedSinceLastBytesRGB_Update = True
		scrn_scr_bmi.palette_UpdatedSinceLastBytesRGB_Update = True
		scrn_curstr_bmi.palette_UpdatedSinceLastBytesRGB_Update = True
		enem_scr_bmi.palette_UpdatedSinceLastBytesRGB_Update = True
		enem_scrb_bmi.palette_UpdatedSinceLastBytesRGB_Update = True
		enem_tile_bmi.palette_UpdatedSinceLastBytesRGB_Update = True
		enem_pal_bmi.palette_UpdatedSinceLastBytesRGB_Update = True

		' Global Palette needs to be copied
		Array.Copy(glob_pal, pal_bmi.pal, glob_pal.Length)
		Array.Copy(glob_pal, pal2_bmi.pal, glob_pal.Length)
		Array.Copy(glob_pal, tt_bmi.pal, glob_pal.Length)
		Array.Copy(glob_pal, edittile_bmi.pal, glob_pal.Length)
		Array.Copy(glob_pal, tsat_bmi.pal, glob_pal.Length)
		Array.Copy(glob_pal, tsat_pal_bmi.pal, glob_pal.Length)
		Array.Copy(glob_pal, sbds_scr_bmi.pal, glob_pal.Length)
		Array.Copy(glob_pal, sbds_obj_bmi.pal, glob_pal.Length)
		Array.Copy(glob_pal, str_bmi.pal, glob_pal.Length)
		Array.Copy(glob_pal, scrn_scr_bmi.pal, glob_pal.Length)
		Array.Copy(glob_pal, scrn_curstr_bmi.pal, glob_pal.Length)
		Array.Copy(glob_pal, enem_scr_bmi.pal, glob_pal.Length)
		Array.Copy(glob_pal, enem_scrb_bmi.pal, glob_pal.Length)
		Array.Copy(glob_pal, enem_tile_bmi.pal, glob_pal.Length)
		Array.Copy(glob_pal, enem_pal_bmi.pal, glob_pal.Length)

		If render = True Then
			If PalEd.Visible = True Then
				RenderModule.RenderPic((PalEd.PalPic), pal_bmi)
				RenderModule.RenderPic((PalEd.PalPic2), pal2_bmi)
				PalEd.Update_Global_Pal()
			End If
			If MetatileTable.Visible = True Then
				RenderModule.RenderPic((MetatileTable.tsapic), tsat_bmi)
				RenderModule.RenderPic((MetatileTable.PalPic), tsat_pal_bmi)
			End If
			If TileTable.Visible = True Then
				RenderModule.RenderPic((TileTable.pic1), tt_bmi)
				RenderModule.RenderPic((TileTable.TilePic), edittile_bmi)
				TileTable.Update_Global_Pal() 'Update_Frm tile editor palettes
			End If
			If SBDSpecial.Visible = True Then
				RenderModule.RenderPic((SBDSpecial.ScreenPic), sbds_scr_bmi)
				RenderModule.RenderPic((SBDSpecial.ObjPic), sbds_obj_bmi)
			End If
			If MetametatileTable.Visible = True Then
				RenderModule.RenderPic((MetametatileTable.StrPic), str_bmi)
			End If
			If ScreenEd.Visible = True Then
				RenderModule.RenderPic((ScreenEd.ScreenPic), scrn_scr_bmi)
				RenderModule.RenderPic((ScreenEd.CurStrPic), scrn_curstr_bmi)
			End If
			If EnemEd.Visible = True Then
				RenderModule.RenderPic((EnemEd.ScreenPic), enem_scr_bmi)
				EnemEd.Update_Global_Pal() 'Update_Frm effect sprite palette
			End If
		End If

		'For a = 0 To &HFF
		'b = glob_pal(a)
		'pal_bmi.pal(a) = b
		'tt_bmi.pal(a) = b
		'tsat_bmi.pal(a) = b
		'tsat_pal_bmi.pal(a) = b
		'sbds_scr_bmi.pal(a) = b
		'sbds_obj_bmi.pal(a) = b
		'str_bmi.pal(a) = b
		'scrn_scr_bmi.pal(a) = b
		'enem_scr_bmi.pal(a) = b
		'enem_scrb_bmi.pal(a) = b
		'enem_tile_bmi.pal(a) = b
		'enem_pal_bmi.pal(a) = b
		'Next a
	End Sub


	Public Sub Update_RefreshAllBitmaps()
		If ScreenEd.Visible = True Then ScreenEd.Update_RefreshAllBitmaps()
		If PalEd.Visible = True Then PalEd.Update_RefreshAllBitmaps()
		If SBDSpecial.Visible = True Then SBDSpecial.Update_RefreshAllBitmaps()
		If TileTable.Visible = True Then TileTable.Update_RefreshAllBitmaps()
		If MetatileTable.Visible = True Then MetatileTable.Update_RefreshAllBitmaps()
		If MetametatileTable.Visible = True Then MetametatileTable.Update_RefreshAllBitmaps()
		If EnemEd.Visible = True Then EnemEd.Update_RefreshAllBitmaps()
	End Sub

	Public Sub ScrollEffectLoad(ByRef scrollmap As Integer)
		Dim offHi, offLo, EffectOff As Integer
		offLo = romdat(arrayAdjuster + rdata(dspa(d_ex) + 5) + romdat(arrayAdjuster + offs(gem, o_ddB) + scrollmap))
		offHi = romdat(arrayAdjuster + rdata(dspa(d_ex) + 6) + romdat(arrayAdjuster + offs(gem, o_ddB) + scrollmap))
		EffectOff = (((offHi - &HA0S) + rdata(dspa(d_ex) + 7)) * &H100S) + offLo + &H11S
		EffectLoad(EffectOff, 1)
	End Sub

	Public Sub Update_StrBlock(ByRef strValue As Integer, ByRef block As Integer)
		If ScreenEd.Visible = True Then ScreenEd.Update_StrBlock(strValue, block)
		If EnemEd.Visible = True Then EnemEd.Update_StrBlock(strValue, block)
	End Sub

	Public Sub Update_ScrnStr(ByRef strY As Integer, ByRef strX As Integer)
		If EnemEd.Visible = True Then EnemEd.Update_ScrnStr(strY, strX)
	End Sub

	'Redraw TSA Block everywhere (block)
	Public Sub Update_Block(ByRef block As Integer)
		If MetametatileTable.Visible = True Then MetametatileTable.Update_Block(block)
		If ScreenEd.Visible = True Then ScreenEd.Update_Block(block)
		If EnemEd.Visible = True Then EnemEd.Update_Block(block)
		If SBDSpecial.Visible = True Then SBDSpecial.Update_Block(block)
	End Sub

	'Redraw range of tiles everywhere (min, max)
	Public Sub Update_TileRange(ByRef min As Integer, ByRef max As Integer)
		If TileTable.Visible = True Then TileTable.Update_TileRange(min, max)
		If MetatileTable.Visible = True Then MetatileTable.Update_TileRange(min, max)
		If MetametatileTable.Visible = True Then MetametatileTable.Update_TileRange(min, max)
		If ScreenEd.Visible = True Then ScreenEd.Update_TileRange(min, max)
		If EnemEd.Visible = True Then EnemEd.Update_TileRange(min, max)
		If SBDSpecial.Visible = True Then SBDSpecial.Update_TileRange(min, max)
	End Sub

	Public Sub Update_CurTile()
		If TileTable.Visible Then TileTable.Update_CurTile()
	End Sub

	Public Sub Update_CurStr()
		If MetametatileTable.Visible Then MetametatileTable.CurStrSet(1)
		If ScreenEd.Visible Then ScreenEd.Update_CurStr()
	End Sub

	Public Sub SprCHRPALSetup()
		Dim sprchrbankoffs1, sprchrbankoffs2 As Integer
		Dim sprpalset, enemset, col As Integer
		Dim t As Integer
		Select Case gem
			Case 0
				enemset = romdat(arrayAdjuster + offs(gem, o_ddA) + (curscroll * 2) + 0)
				sprchrbankoffs1 = romdat(arrayAdjuster + rdata(dspa(d_ex) + 0) + (enemset * 2))
				sprchrbankoffs1 *= &H400S
				sprchrbankoffs2 = romdat(arrayAdjuster + rdata(dspa(d_ex) + 0) + (enemset * 2) + 1)
				sprchrbankoffs2 *= &H400S

				For t = 0 To 63
					chrmap(t + &H180S) = rdata(dspa(gem) + 2) + sprchrbankoffs1 + (t * &H10S)
					chrmap(t + &H1C0S) = rdata(dspa(gem) + 2) + sprchrbankoffs2 + (t * &H10S)
				Next t

				For col = 0 To 7
					If (col And 3) Then
						sprpaloff(col) = offs(gem, 27) + (enemset * 8) + col
						glob_pal(col + &H48S) = NESPAL(romdat(arrayAdjuster + offs(gem, 27) + (enemset * 8) + col))
						PPU_palette_val(&H18S + col) = romdat(arrayAdjuster + offs(gem, 27) + (enemset * 8) + col)
					End If
				Next col
			Case 2
				sprpalset = romdat(arrayAdjuster + offs(gem, o_ddA) + curscroll) And &H3FS

				For col = 0 To 7
					If sprpalset > 0 Then
						sprpaloff(col) = offs(gem, 27) + ((sprpalset - 1) * 8) + col
						If (col And 3) > 0 Then
							glob_pal(col + &H48S) = NESPAL(romdat(arrayAdjuster + sprpaloff(col)))
							PPU_palette_val(&H18S + col) = romdat(arrayAdjuster + sprpaloff(col))
						End If
					Else
						sprpaloff(col) = offs(gem, 49) + 8 + col
						If (col And 3) > 0 Then
							glob_pal(col + &H48S) = NESPAL(romdat(arrayAdjuster + sprpaloff(col)))
							PPU_palette_val(&H18S + col) = romdat(arrayAdjuster + sprpaloff(col))
						End If
					End If
				Next col
		End Select

		Update_Global_Pal(False)
	End Sub

	Private Sub MFLE_Main_FormClosed(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
		Dim frm As System.Windows.Forms.Form
		ShuttingDown = True

		'Loop through all open forms and close them
		For Each frm In Application.OpenForms
			frm.Close()
		Next frm
	End Sub

	Public Sub Level_Misc_Click() Handles Level_Misc.Click
		'If MiscEd.Visible = False Then MiscEd.Update_Frm
		MiscEd.Update_Frm()
		' Does more than just show
		ShowSpecialCase(MiscEd)
	End Sub

	Public Sub Level_Next_Click() Handles Level_Next.Click
		If scenemode = True Then
			If Not level = offs(gem, o_scenebanks) Then level += 1 : Me.Update_Level()
		Else
			If Not level = offs(gem, 0) Then level += 1 : Me.Update_Level()
		End If
	End Sub

	Public Sub Level_Previous_Click() Handles Level_Previous.Click
		If Not level = 0 Then level -= 1 : Me.Update_Level()
	End Sub

	Public Sub File_Exit_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles File_Exit.Click
		Me.Close()
	End Sub

	Public Sub File_Save_Click() Handles File_Save.Click
		Dim a, b As Integer
		FileCopy(FileName, "backup.rom")
		Try
retry:
			FileOpen(1, FileName, OpenMode.Binary)
			FilePut(1, romdat)
			FileClose(1)
			EditFile_SaveDateStr = CStr(FileDateTime(FileName))
		Catch ex As Exception
err_hnd:
			FileClose(1)
			b = GetAttr(FileName)
			If (Err.Number = 75) And ((b And FileAttribute.ReadOnly) > 0) Then
				a = MsgBox("Can't save, Read-only flag set for file. Clear it and retry?", MsgBoxStyle.YesNo, Err.Description)
				If (a And 1) = 0 Then
					SetAttr(FileName, (b Xor (b And FileAttribute.ReadOnly)))
					GoTo retry
				End If
			Else
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
			End If
		End Try
	End Sub

	Public Sub File_Back_Click() Handles File_Back.Click
		If Dir("backup.rom") = "" Then MsgBox("No backup!") : Exit Sub
		FileOpen(1, "backup.rom", OpenMode.Binary)
		FileGet(1, romdat)
		FileClose(1)
		Update_Level()
	End Sub

	Public Sub Menu_Config_Click() Handles Menu_Config.Click
		If Config.Visible = False Then Config.Update_Frm()

		Config.SetLocation(Me.Location.Y)

		' Does more than just show
		ShowSpecialCase(Config)

		' Previous code (show) is stupid and move the form
		Config.SetLocation(Me.Location.Y)
	End Sub

	Private Sub OffsDatTB_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles OffsDatTB.TextChanged
		offs(gem, OffsTypeCombo.SelectedIndex) = Dec((OffsDatTB.Text))
	End Sub

	Private Sub OffsTypeCombo_SelectedIndexChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles OffsTypeCombo.SelectedIndexChanged
		SetTBCoolText(OffsDatTB, Hex(offs(gem, OffsTypeCombo.SelectedIndex)))
	End Sub

	Public Sub Other_GfxLoadEd_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Other_GfxLoadEd.Click
		GfxLoadEd.Update_Frm()

		' Does more than just show
		ShowSpecialCase(GfxLoadEd)
	End Sub

	Public Sub Other_Patches_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Other_Patches.Click
		Dim PatchWnd As ProtoWnd
		PatchWnd = New ProtoWnd
		PatchWnd.InitMode_Patcher()

		' Does more than just show
		PatchWnd.ShowDialog()
	End Sub

	Public Sub Other_TextEd_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Other_TextEd.Click
		' Does more than just show
		ShowSpecialCase(TextEd)
	End Sub

	Private Sub PatGetDataBtn_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles PatGetDataBtn.Click
		Dim a As Integer
		Dim tstr As String = ""
		For a = 0 To 31
			If romdat(arrayAdjuster + Dec((PatOffsTB.Text)) + a) >= &H10S Then
				tstr &= Hex(romdat(arrayAdjuster + Dec((PatOffsTB.Text)) + a))
			Else
				tstr = tstr & "0" & Hex(romdat(arrayAdjuster + Dec((PatOffsTB.Text)) + a))
			End If
		Next a
		SetTBCoolText(PatDataTB, tstr)
	End Sub

	Public Sub Special_Chargeman_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Special_Chargeman.Click
		Dim a As Integer
		For a = 0 To &H7FS
			chrmap(128 + a) = &H7C010 + (a * &H10S)
		Next a
		Me.Update_TileRange(128, 255)
	End Sub

	Public Sub Stats_EnemUsage_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Stats_EnemUsage.Click
		Dim StatsWnd As ProtoWnd
		StatsWnd = New ProtoWnd
		StatsWnd.InitMode_EnemUsageStat()

		' Does more than just show
		StatsWnd.ShowDialog()
	End Sub

	Private Sub Tools_ClearUTiles_Click(sender As Object, e As EventArgs)
		TileTable.ClearUnusedTiles()
		If TileTable.Visible = True Then TileTable.Update_Level()
	End Sub


	Public Sub Tools_ClearUTSA_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs)
		MetatileTable.ClearUnusedMetatiles()
		If MetatileTable.Visible = True Then MetatileTable.Update_Level()
	End Sub

	Private Sub Tools_ClearUStr_Click(sender As Object, e As EventArgs)
		MetametatileTable.ClearUnusedMetametatiles()
		If MetametatileTable.Visible = True Then MetametatileTable.Update_Level()
	End Sub

	Public Sub Tools_RunShell_Click() Handles Tools_RunShell.Click
		On Error GoTo err_hnd
		Me.Activate()
		Shell(GetCfg("shellcmd"), AppWinStyle.NormalFocus)
		Exit Sub

err_hnd:
		MsgBox("Error " & CStr(Err.Number) & ": " & CStr(Err.Description))
	End Sub

	Public Sub Tools_Test_Click() Handles Tools_Test.Click
		On Error GoTo err_hnd
		If GetCfg("emufname") = "" Then MsgBox("Set Emulator location in Config first!") : Exit Sub
		Shell(GetCfg("emufname") + " " + sse + FileName + sse, AppWinStyle.NormalFocus)
		Exit Sub

err_hnd:
		MsgBox("Error " & CStr(Err.Number) & ": " & CStr(Err.Description) + vbNewLine + "Ensure to set Emulator location in Config first!")
	End Sub

	Public Sub View_DoorEd_Click() Handles View_DoorEd.Click
		If gem = 3 Then
			MsgBox("Sorry, not supported for Mega Man 6.")
			Exit Sub
		End If
		DoorEd.Update_Frm()

		' Does more than just show
		ShowSpecialCase(DoorEd)
	End Sub

	Public Sub View_EnemEd_Click() Handles View_EnemEd.Click
		'If EnemEd.Visible = False Then EnemEd.Update_Frm
		EnemEd.UpdateFnc()
		'EnemEd.Show() 'find out why switching these two does funky stuff

		' Does more than just show
		ShowSpecialCase(EnemEd)
	End Sub

	Public Sub View_PalEd_Click() Handles View_PalEd.Click
		'If PalEd.Visible = False Then PalEd.Update_Frm
		PalEd.Update()

		' Does more than just show
		ShowSpecialCase(PalEd)
	End Sub

	Public Sub View_SBD_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles View_SBD.Click
		'If SBDSpecial.Visible = False Then SBDSpecial.Update_Frm
		SBDSpecial.Update_Frm()

		' Does more than just show
		ShowSpecialCase(SBDSpecial)
	End Sub

	Public Sub View_ScreenEd_Click() Handles View_ScreenEd.Click
		'If ScreenEd.Visible = False Then ScreenEd.Update_Frm
		ScreenEd.Update_Frm()

		' Does more than just show
		ShowSpecialCase(ScreenEd)
	End Sub

	Public Sub View_StrT_Click() Handles View_StrT.Click
		'If MetametatileTable.Visible = False Then MetametatileTable.Update_Frm
		MetametatileTable.UpdateFrm()

		' Does more than just show
		ShowSpecialCase(MetametatileTable)
	End Sub

	Public Sub View_TSAT_Click() Handles View_TSAT.Click
		'If MetatileTable.Visible = False Then MetatileTable.Update_Frm
		MetatileTable.Update_Frm()

		' Does more than just show
		ShowSpecialCase(MetatileTable)
	End Sub

	Public Sub View_TT_Click() Handles View_TT.Click
		'If TileTable.Visible = False Then TileTable.Update_Frm
		TileTable.Update_Frm()

		' Does more than just show
		ShowSpecialCase(TileTable)
	End Sub

	Public Sub CHRAnim_Handle()

		Dim id, c, a, b, idoff As Integer
		If Not gem = 2 Then Exit Sub
		If CA_ID >= &H80S Then
			id = CA_ID And &H7FS
			idoff = romdat(arrayAdjuster + rdata(dspa(d_ex) + 17) + id)
			CA_DelayC = (CA_DelayC + 1) And &HFFS
			If CA_DelayC >= romdat(arrayAdjuster + rdata(dspa(d_ex) + 18) + idoff + 1) Then
				CHRAnim_Advance(idoff)
			End If
		End If
		'Gravityman Special
		If GetCfg("gravityman_hardchranim_emu") = 1 Then
			If (level = 0) And (scenemode = False) Then
				a = Int(Gman_FC / 8) And 3
				If a <> Gman_OF Then
					Gman_OF = a
					b = romdat(arrayAdjuster + &H3DF60 + a)
					b *= &H400S
					For c = 0 To 127
						chrmap(c) = offs(gem, o_chroffs) + b + (c * &H10S)
					Next c
					Me.Update_TileRange(0, &H7FS)
				End If
				Gman_FC = ((Gman_FC + 1) And &HFFS)
			End If
		End If
	End Sub

	Public Sub CHRAnim_Advance(ByRef idoff As Integer)
		Dim c, a, b, d As Integer

		CA_DelayC = 0
		a = CA_FrameN
		CA_FrameN = (CA_FrameN + 1) And &HFFS
		If a >= romdat(arrayAdjuster + rdata(dspa(d_ex) + 18) + idoff) Then CA_FrameN = 0
		b = romdat(arrayAdjuster + rdata(dspa(d_ex) + 18) + idoff + 2)
		c = romdat(arrayAdjuster + rdata(dspa(d_ex) + 18) + idoff + 3 + CA_FrameN)
		c *= &H400S
		For d = 0 To 127
			If b <= 1 Then
				chrmap(d + (b * &H80S)) = offs(gem, o_chroffs) + c + (d * &H10S)
			End If
		Next d
		If b <= 1 Then Me.Update_TileRange((b * &H80S), (b * &H80S) + &H7FS)

	End Sub
	Public Sub PalAnim_Handle()
		Dim col, idoff, idoLo, slot, id, idoHi, framepalptr, a As Integer
		If scenemode = True Then Exit Sub
		Select Case gem
			Case 0
				For slot = 0 To 3
					If PA_ID(slot) >= &H80S Then
						id = PA_ID(slot) And &H7FS
						idoff = romdat(arrayAdjuster + offs(gem, 53) + id)
						If PA_DelayC(slot) >= romdat(arrayAdjuster + offs(gem, 54) + 1 + idoff) Then
							PA_DelayC(slot) = 0
							a = PA_FrameN(slot)
							PA_FrameN(slot) = (PA_FrameN(slot) + 1) And &HFFS
							If a >= romdat(arrayAdjuster + offs(gem, 54) + 0 + idoff) Then PA_FrameN(slot) = 0
							framepalptr = (romdat(arrayAdjuster + offs(gem, 54) + 3 + idoff + PA_FrameN(slot)) * 3) And &HFFS
							'If framepalptr = 0 Then PA_ID(slot) = 0: Exit Sub
							For col = 0 To 2
								glob_pal((romdat(arrayAdjuster + offs(gem, 54) + 2 + idoff) + col) And 15) = NESPAL(romdat(arrayAdjuster + offs(gem, 56) + framepalptr + col))
								glob_pal(CShort((romdat(arrayAdjuster + offs(gem, 54) + 2 + idoff) + col) And 15) + &H10S) = NESPALD(romdat(arrayAdjuster + offs(gem, 56) + framepalptr + col))
								glob_pal(CShort((romdat(arrayAdjuster + offs(gem, 54) + 2 + idoff) + col) And 15) + &H30S) = NESPALL(romdat(arrayAdjuster + offs(gem, 56) + framepalptr + col))
								PPU_palette_val((romdat(arrayAdjuster + offs(gem, 54) + 2 + idoff) + col) And 15) = romdat(arrayAdjuster + offs(gem, 56) + framepalptr + col)
								'tsat_bmi.pal(Asc(mid$(romdat, &H12621 + idoff, 1)) + col) = NESPAL(Asc(mid$(romdat, &H1259F + framepalptr + col, 1)))
								'tsat_pal_bmi.pal(Asc(mid$(romdat, &H12621 + idoff, 1)) + col) = NESPAL(Asc(mid$(romdat, &H1259F + framepalptr + col, 1)))
								'tt_bmi.pal(Asc(mid$(romdat, &H12621 + idoff, 1)) + col) = NESPAL(Asc(mid$(romdat, &H1259F + framepalptr + col, 1)))
								'sbds_scr_bmi.pal(Asc(mid$(romdat, &H12621 + idoff, 1)) + col) = NESPAL(Asc(mid$(romdat, &H1259F + framepalptr + col, 1)))
								'enem_scr_bmi.pal(Asc(mid$(romdat, &H12621 + idoff, 1)) + &H10 + col) = NESPALD(Asc(mid$(romdat, &H1259F + framepalptr + col, 1)))
							Next col
							'MFLE_Main.Update_g
							Update_Global_Pal(True)
						Else
							PA_DelayC(slot) = PA_DelayC(slot) + 1
						End If
					End If
				Next slot

			Case 1
				For slot = 0 To 3
					If PA_ID(slot) >= &H80S Then
						id = PA_ID(slot) And &H7FS
						idoLo = romdat(arrayAdjuster + offs(gem, 53) + id)
						idoHi = romdat(arrayAdjuster + offs(gem, 54) + id)
						idoff = (((idoHi - &HA0S) + offs(gem, 55)) * &H100S) + idoLo + &H11S
						If PA_DelayC(slot) >= romdat(arrayAdjuster + idoff + 1) Then
							PA_DelayC(slot) = 0
							a = PA_FrameN(slot)
							PA_FrameN(slot) = (PA_FrameN(slot) + 1) And &HFFS
							If a >= romdat(arrayAdjuster + idoff) Then PA_FrameN(slot) = 0
							framepalptr = (romdat(arrayAdjuster + idoff + 2 + PA_FrameN(slot)) * 3)
							If framepalptr = 0 Then PA_ID(slot) = 0 : Exit Sub
							For col = 0 To 2
								glob_pal(((slot * 4) + 1 + col) And 15) = NESPAL(romdat(arrayAdjuster + offs(gem, 56) + framepalptr + col))
								glob_pal(CShort(((slot * 4) + 1 + col) And 15) + &H10S) = NESPALD(romdat(arrayAdjuster + offs(gem, 56) + framepalptr + col))
								glob_pal(CShort(((slot * 4) + 1 + col) And 15) + &H30S) = NESPALL(romdat(arrayAdjuster + offs(gem, 56) + framepalptr + col))
								PPU_palette_val(((slot * 4) + 1 + col) And 15) = romdat(arrayAdjuster + offs(gem, 56) + framepalptr + col)
								If (id = 7) And (GetCfg("ringman_palanim_emu") = 1) Then
									glob_pal(&H49S + col) = NESPAL(romdat(arrayAdjuster + offs(gem, 56) + framepalptr + col))
								End If
								'tsat_bmi.pal(Asc(mid$(romdat, &H12621 + idoff, 1)) + col) = NESPAL(Asc(mid$(romdat, &H1259F + framepalptr + col, 1)))
								'tsat_pal_bmi.pal(Asc(mid$(romdat, &H12621 + idoff, 1)) + col) = NESPAL(Asc(mid$(romdat, &H1259F + framepalptr + col, 1)))
								'tt_bmi.pal(Asc(mid$(romdat, &H12621 + idoff, 1)) + col) = NESPAL(Asc(mid$(romdat, &H1259F + framepalptr + col, 1)))
								'sbds_scr_bmi.pal(Asc(mid$(romdat, &H12621 + idoff, 1)) + col) = NESPAL(Asc(mid$(romdat, &H1259F + framepalptr + col, 1)))
								'enem_scr_bmi.pal(Asc(mid$(romdat, &H12621 + idoff, 1)) + &H10 + col) = NESPALD(Asc(mid$(romdat, &H1259F + framepalptr + col, 1)))
							Next col
							Update_Global_Pal(True)
						Else
							PA_DelayC(slot) = PA_DelayC(slot) + 1
						End If
					End If
				Next slot

			Case 2
				For slot = 0 To 3
					If PA_ID(slot) >= &H80S Then
						id = PA_ID(slot) And &H7FS
						idoff = romdat(arrayAdjuster + offs(gem, 53) + id)
						If PA_DelayC(slot) >= romdat(arrayAdjuster + offs(gem, 54) + idoff + 1) Then
							PA_DelayC(slot) = 0
							a = PA_FrameN(slot)
							PA_FrameN(slot) = (PA_FrameN(slot) + 1) And &HFFS
							If a >= romdat(arrayAdjuster + offs(gem, 54) + idoff) Then PA_FrameN(slot) = 0
							framepalptr = (romdat(arrayAdjuster + offs(gem, 54) + idoff + 2 + PA_FrameN(slot)) * 3) And &HFFS
							If framepalptr = 0 Then PA_ID(slot) = 0 : Exit Sub
							For col = 0 To 2
								glob_pal(((slot * 4) + 1 + col) And 15) = NESPAL(romdat(arrayAdjuster + offs(gem, 56) + framepalptr + col))
								glob_pal(CShort(((slot * 4) + 1 + col) And 15) + &H10S) = NESPALD(romdat(arrayAdjuster + offs(gem, 56) + framepalptr + col))
								glob_pal(CShort(((slot * 4) + 1 + col) And 15) + &H30S) = NESPALL(romdat(arrayAdjuster + offs(gem, 56) + framepalptr + col))
								PPU_palette_val(((slot * 4) + 1 + col) And 15) = romdat(arrayAdjuster + offs(gem, 56) + framepalptr + col)
								'tsat_bmi.pal(Asc(mid$(romdat, &H12621 + idoff, 1)) + col) = NESPAL(Asc(mid$(romdat, &H1259F + framepalptr + col, 1)))
								'tsat_pal_bmi.pal(Asc(mid$(romdat, &H12621 + idoff, 1)) + col) = NESPAL(Asc(mid$(romdat, &H1259F + framepalptr + col, 1)))
								'tt_bmi.pal(Asc(mid$(romdat, &H12621 + idoff, 1)) + col) = NESPAL(Asc(mid$(romdat, &H1259F + framepalptr + col, 1)))
								'sbds_scr_bmi.pal(Asc(mid$(romdat, &H12621 + idoff, 1)) + col) = NESPAL(Asc(mid$(romdat, &H1259F + framepalptr + col, 1)))
								'enem_scr_bmi.pal(Asc(mid$(romdat, &H12621 + idoff, 1)) + &H10 + col) = NESPALD(Asc(mid$(romdat, &H1259F + framepalptr + col, 1)))
							Next col
							Update_Global_Pal(True)
						Else
							PA_DelayC(slot) = PA_DelayC(slot) + 1
						End If
					End If
				Next slot

		End Select
	End Sub

	Private Sub Check2_CheckStateChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Check2.CheckStateChanged
		Dim a As Integer
		If Check2.Tag <> "" Then Exit Sub

		If gem = 3 Then
			MsgBox("Scene screen mode is not supported for Mega Man 6.")
			SetCheckCool(Check2, 0)
			Exit Sub
		End If

		a = level
		level = storelevel
		storelevel = a
		scenemode = Check2.CheckState
		palset = 0

		CurLevCombo.Items.Clear()
		If scenemode = False Then
			PalEd.PalSetUD.Maximum = offs(gem, 18)
			For a = 0 To offs(gem, 0)
				CurLevCombo.Items.Add(CStr(a) & ": " & SrcString(rdata(dspa(d_levnames + gem) + a)))
			Next a
		Else
			PalEd.PalSetUD.Maximum = &HFFS
			For a = 0 To offs(gem, o_scenebanks)
				CurLevCombo.Items.Add(CStr(a) & ": Bank " & Hex(rdata(rdata(dspa(d_scenesbank) + gem) + a)))
			Next a
		End If

		If scenemode = True Then
			If EnemEd.Visible Then EnemEd.Hide()
			View_EnemEd.Enabled = False
			If DoorEd.Visible Then DoorEd.Hide()
			View_DoorEd.Enabled = False
		Else
			View_EnemEd.Enabled = True
			View_DoorEd.Enabled = True
		End If

		If scenemode = True Then
			palsetWidth = &H10S
		Else
			palsetWidth = &H14S
		End If

		Update_Level()

		TileTable.AdjustControlsVisibility()
	End Sub

	Private Sub Command13_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Command13.Click
		SetTBCoolText(Text2, Hex(UBound(romdat) - 1))
	End Sub

	Private Sub Command15_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Command15.Click
		Dim a, b As Integer

		b = Dec((Text11.Text))
		a = rdata(dspa(gem) + 1)
		sbdoff = (b * &H2000S) + a

		For b = 0 To 2
			For a = 0 To offsnum
				If rdata(dspa(d_offst) + a) = 2 Then offs(b, a) = sbdoff + rdata(dspa(b) + a)
			Next a
		Next b

		If PalEd.Visible Then PalEd.Update_Level()
		If TileTable.Visible Then TileTable.Update_Level()
		If MetatileTable.Visible Then MetatileTable.Update_Level()
		If MetametatileTable.Visible Then MetametatileTable.Update_Level()
		'If SBDSpecial.Visible Then SBDSpecial.Update_Level
		If GfxLoadEd.Visible Then GfxLoadEd.Update_Level()

		If GetCfg("cllevelscr") > 0 Then curscreen = 0

		updlevel = True
		Update_Scrn()
		updlevel = False

		SetTBCoolText(Text11, CStr(0))
		Text11.Focus()
	End Sub

	Private Sub Command16_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Command16.Click
		Dim c, a, d As Integer
		Dim PathBackup As String

		PathBackup = CurDir()
		FileOpen(1, Text10.Text, OpenMode.Binary)
		Seek(1, 1)
		c = Dec((Text1.Text))
		d = Dec((Text2.Text))
		For a = c To d
			FilePut(1, romdat(arrayAdjuster + a + 1))
		Next a
		FileClose(1)

		ChDir(PathBackup)
	End Sub

	Private Sub Command17_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Command17.Click
		Dim c, a, d As Integer
		Dim PathBackup As String

		PathBackup = CurDir()
		FileOpen(1, Text10.Text, OpenMode.Binary)
		Seek(1, 1)
		c = Dec((Text1.Text))
		d = Dec((Text2.Text))
		For a = c To d
			FileGet(1, romdat(arrayAdjuster + a + 1))
			'romdat(arrayAdjuster + a + 1) = ba
		Next a
		FileClose(1)
		Me.Update_Level()

		ChDir(PathBackup)
	End Sub

	Private Sub Command2_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Command2.Click
		Dim offHi, a, offLo, EffectOff As Integer
		a = Dec((Text12.Text))
		offLo = romdat(arrayAdjuster + rdata(dspa(d_ex) + 5) + a)
		offHi = romdat(arrayAdjuster + rdata(dspa(d_ex) + 6) + a)
		EffectOff = (((offHi - &HA0S) + rdata(dspa(d_ex) + 7)) * &H100S) + offLo + &H11S
		EffectLoad(EffectOff, 1)
		Me.Update_TileRange(0, 255)
		Text12.Text = vbNullString
		Text12.Focus()
	End Sub

	Private Sub Command3_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles _Command3_1.Click, _Command3_0.Click
		Dim Index As Short = 0

		For Each button As Button In Command3
			If button.Name = eventSender.Name Then
				Exit For
			End If
			Index += 1
		Next

		Writehex()
		If Index = 1 Then Me.Update_TileRange(0, 255)
	End Sub

	Private Sub Command8_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Command8.Click
		SetTBCoolText(PatOffsTB, Hex(offs(gem, OffsTypeCombo.SelectedIndex)))
	End Sub

	Private Sub Text2_TextChanged(sender As Object, e As EventArgs) Handles Text2.TextChanged
		If Text2.Tag <> "" Then Exit Sub
		SetTBCoolNumWithValidation(Text2, Text2.Text, 1048575, 5, True)
	End Sub

	Private Sub Text1_TextChanged(sender As Object, e As EventArgs) Handles Text1.TextChanged
		If Text1.Tag <> "" Then Exit Sub
		SetTBCoolNumWithValidation(Text1, Text1.Text, 1048575, 5, True)
	End Sub

	Private Sub PatOffsTB_TextChanged(sender As Object, e As EventArgs) Handles PatOffsTB.TextChanged
		If PatOffsTB.Tag <> "" Then Exit Sub
		SetTBCoolNumWithValidation(PatOffsTB, PatOffsTB.Text, 1048575, 5, True)
	End Sub

	Private Sub Text13_TextChanged(sender As Object, e As EventArgs) Handles Text13.TextChanged
		If Text13.Tag <> "" Then Exit Sub
		SetTBCoolNumWithValidation(Text13, Text13.Text, 255, 2, True)
	End Sub

	Private Sub Text12_TextChanged(sender As Object, e As EventArgs) Handles Text12.TextChanged
		If Text12.Tag <> "" Then Exit Sub
		SetTBCoolNumWithValidation(Text12, Text12.Text, 255, 2, True)
	End Sub

	Private Sub Text11_TextChanged(sender As Object, e As EventArgs) Handles Text11.TextChanged
		If Text11.Tag <> "" Then Exit Sub
		SetTBCoolNumWithValidation(Text11, Text11.Text, 255, 2, True)
	End Sub

	Public Sub Tools_ConvSCR_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Tools_ConvSCR.Click
		Dim FileName As String
		Dim NiceDialog As New clsDialog
		Dim PathBackup As String
		Dim Tmp_SBD_Base(&H27S, &HFFS) As Byte
		Dim a, b As Integer
		Dim Title As String = "Choose a file with old format."
		Dim InitDir As String = ""
		Dim DefExt As String = ""
		Dim Filter As String = ".SCR files|*.scr|All files|*.*"
		Dim flags As ClsDialog.DialogFlags = ClsDialog.DialogFlags.CHECKFILEEXISTS Or ClsDialog.DialogFlags.CHECKPATHEXISTS

		MsgBox("This will convert .SCR files saved with version 0.42 and earlier to work in versions 0.5 and later.")

		PathBackup = CurDir()
		FileName = NiceDialog.ShowOpen(Me, Title, flags, InitDir, DefExt, Filter)
		If Len(FileName) = 0 Then
			MsgBox("Action canceled.")
			GoTo exitme
		End If
		FileName = Common.Left(FileName, Len(FileName))

		a = FileLen(FileName)
		If a = 0 Then
			MsgBox("File is empty or couldn't be opened.")
			GoTo exitme
		End If

		FileOpen(1, FileName, OpenMode.Binary)
		For a = 0 To &H27S
			For b = 0 To &HFFS
				Seek(1, a + (b * &H28S) + 1)
				FileGet(1, Tmp_SBD_Base(a, b))
			Next b
		Next a
		FileClose(1)

		Title = "Choose output file."
		InitDir = ""
		DefExt = ""
		Filter = ".SCR files|*.scr|All files|*.*"
		flags = ClsDialog.DialogFlags.CHECKPATHEXISTS

		FileName = NiceDialog.ShowSave(Me, Title, flags, InitDir, DefExt, Filter)
		If Len(FileName) = 0 Then
			MsgBox("Action canceled.")
			GoTo exitme
		End If
		FileName = Common.Left(FileName, Len(FileName))

		FileOpen(1, FileName, OpenMode.Binary)
		For a = 0 To &H27S
			For b = 0 To &HFFS
				FilePut(1, Tmp_SBD_Base(a, b))
			Next b
		Next a
		FileClose(1)
		MsgBox("Converted!")

exitme:
		ChDir(PathBackup)
	End Sub

	Private Sub Command12_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Command12.Click
		Dim a As Integer
		a = Dec((Text13.Text))
		MM6CHRLoad(a)
		Me.Update_TileRange(0, 255)
		Text13.Text = vbNullString
		Text13.Focus()
	End Sub

	Private Sub MFLE_Main_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
		MegaManEngineMode = False
		MegaFLEX_Main.Main()
	End Sub

	Private Sub AboutToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AboutToolStripMenuItem.Click
		About.ShowDialog()
	End Sub


#Region "OldWay"
	'Private Sub Dump_Bitmap_Sub(ByRef bmi As BITMAPINFO)

	'	Dim bmfile As String
	'	Dim c, a, b, y As Integer
	'	Dim NiceDialog As New ClsDialog
	'	Dim Title As String = "Write to.."
	'	Dim InitDir As String = ""
	'	Dim DefExt As String = ""
	'	Dim Filter As String = ".BMP files|*.bmix|All files|*.*"
	'	Dim flags As ClsDialog.DialogFlags
	'	Dim readPalID As Byte

	'	bmfile = NiceDialog.ShowSave(Me, Title, flags, InitDir, DefExt, Filter)
	'	If Len(bmfile) = 0 Then
	'		Exit Sub
	'	End If
	'	bmfile = Common.Left(bmfile, Len(bmfile))

	'	'BMP handler, the rogue way.
	'	FileOpen(1, bmfile, OpenMode.Binary)
	'	FilePut(1, "BM6")
	'	FilePut(1, CByte(127))
	'	FilePut(1, CInt(0))
	'	FilePut(1, CShort(0))
	'	FilePut(1, CInt(&H436S))
	'	FilePut(1, CInt(&H28S))
	'	FilePut(1, bmi.Header.biWidth)
	'	FilePut(1, -bmi.Header.biHeight)
	'	FilePut(1, CShort(1))
	'	FilePut(1, CShort(8))
	'	FilePut(1, CInt(0))
	'	FilePut(1, bmi.Header.biSizeImage)
	'	For a = 1 To 4
	'		FilePut(1, CInt(0))
	'	Next a
	'	For a = 0 To 255
	'		FilePut(1, bmi.pal(a))
	'	Next a
	'	For y = (-bmi.Header.biHeight - 1) To 0 Step -1
	'		b = (y * bmi.Header.biWidth)
	'		c = ((y + 1) * bmi.Header.biWidth) - 1
	'		For a = b To c
	'			FilePut(1, readPalID)
	'			' Set PalID read ad 4 colors bytes
	'			bmi.PalIDSave(a, readPalID)
	'		Next a
	'	Next y

	'	bmi.bytesRGB_UpdatedSinceLastRender = True

	'	'Put #1, , bmi.bits
	'	FileClose(1)
	'End Sub
#End Region

#Region "Unused"

	'Public Sub PalAnimT_Timer()
	'PalAnimT.Enabled = False
	'PalAnim_Handle
	''Static tick
	''PalAnim
	''tick = tick + 66: If tick > 99 Then tick = tick - 100
	'End Sub
	'
	'Private Sub PalAnim()

	'Private Sub StatsTimer_Tick(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles StatsTimer.Tick
	'	'Static Tick
	'	'Tick = Tick + 1
	'	'If Tick = 1 Then
	'	'    SecondsUsed = SecondsUsed + 1
	'	'    Tick = 0
	'	'End If
	'	'Dim MinutesUsed As Long
	'	'MinutesUsed = Int(SecondsUsed / 60)
	'	'Label4.Caption = "Time Used: " & Format(CStr(MinutesUsed), "00") + ":" + Format(CStr(SecondsUsed - (MinutesUsed * 60)), "00")
	'End Sub

	'Public Sub CHRAnimT_Timer()
	'CHRAnimT.Enabled = False
	'CHRAnim_Handle
	'End Sub

	'Private Sub CHRAnimTB_Change()
	'	CHRAnim_Handle()
	'End Sub

	'	Public Sub Update_Scrn2()
	'		Dim spscreen, spsmap, a As Integer
	'		Dim stack_RefreshLock As Boolean
	'		Dim stack_RefreshPalLock As Boolean
	'		Dim scrolltype, scrollscrs As Integer

	'		stack_RefreshLock = RefreshLock
	'		stack_RefreshPalLock = RefreshPalLock
	'		RefreshLock = True
	'		RefreshPalLock = True

	'		oldscroll = curscroll

	'		'Locate Screen's Scroll Map
	'		spscreen = 0
	'		curscroll_sscrn = 0
	'		For spsmap = 0 To offs(gem, o_maxsmp)
	'			scrolltype = CShort(romdat(arrayAdjuster + offs(gem, o_dirtype) + spsmap) And &HE0S) / 32
	'			If gem = 2 Then
	'				scrollscrs = romdat(arrayAdjuster + offs(gem, o_dirtype) + spsmap) And &H1FS
	'			Else
	'				scrollscrs = romdat(arrayAdjuster + offs(gem, o_dirtype) + spsmap) And &HFS
	'			End If
	'			If scrolltype = 0 Then
	'				If GetCfg("alwaysskipscrollzero") = 1 Then
	'					GoTo spsmapskip
	'				End If
	'			End If
	'			For a = 0 To scrollscrs
	'				If spscreen = curscreen Then GoTo spsmapfound
	'				spscreen += 1
	'			Next a
	'			curscroll_sscrn = spscreen
	'spsmapskip:
	'			'Prevent current scroll from becoming 1 above max.
	'			If (spsmap = offs(gem, o_maxsmp)) Then GoTo spsmapfound
	'		Next spsmap
	'spsmapfound:
	'		If (curscroll <> spsmap) And (gem = 1) Then
	'			If spsmap = 0 Then
	'				InitEffectLoad() 'Load graphics which is loaded at beginning of level.
	'			Else
	'				ScrollEffectLoad(spsmap) 'Load graphics for Scroll Map
	'			End If
	'		End If

	'		curscroll = spsmap
	'		nextscroll_sscrn = curscroll_sscrn + scrollscrs + 1

	'		If GfxLoadEd.Visible = True Then GfxLoadEd.Update_PPUEff()

	'		If scenemode = True Then
	'			SceneMode_LoadScrSetup()
	'		Else
	'			SprCHRPALSetup() 'Set up Sprite CHR and Palette for screen
	'			Update_PalSet()
	'			EffSpriteSimulate() 'Simulate effect sprites in Scroll Map
	'		End If

	'		'Update_BGPal 1, 1 'Might not be needed done every screen, but do for now.

	'		If EnemEd.Visible = True Then EnemEd.Update_Scrn()
	'		If ScreenEd.Visible = True Then ScreenEd.Update_Scrn()

	'		If scenemode = True Then
	'			If MetametatileTable.Visible = True Then MetametatileTable.Update_Level()
	'			If TileTable.Visible = True Then TileTable.Update_Level()
	'			If MetatileTable.Visible = True Then MetatileTable.Update_Level()
	'			If SBDSpecial.Visible = True Then SBDSpecial.Update_Level()
	'			If MiscEd.Visible = True Then MiscEd.Update_Level()
	'		End If

	'		RefreshPalLock = stack_RefreshPalLock

	'		'Update_Frm bitmap palette arrays and other palette related stuff,
	'		'but wait with refresh to PictureBox, let RefreshAllBitmaps do it.
	'		Update_Global_Pal(True)

	'		RefreshLock = stack_RefreshLock

	'		Update_RefreshAllBitmaps()

	'		'RefreshLock = stack_RefreshLock
	'	End Sub

	'Private Sub Ready_Timer()
	'MainTimedLoop
	''Ready.Enabled = False
	'End Sub

	'Private Sub PalAnimTB_Change()
	'	PalAnim_Handle()
	'End Sub
#End Region
End Class