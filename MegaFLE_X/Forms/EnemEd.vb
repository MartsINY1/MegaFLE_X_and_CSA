Option Explicit On

Friend Class EnemEd
	Inherits System.Windows.Forms.Form

	Private TypeUD_Location_GeneralPan As Point
	Private TypeUD_Location_WeaponPan As Point
	Private lblEnemyName_Location_GeneralPan As Point
	Private lblEnemyName_Location_WeaponPan As Point

	Private WeaponImagesMissing As Boolean = False
	Private ReadOnly WeaponImagesMissingErrorMsg As String = "One or more images missing for weapons (Enemy Editor form) - Normally in Icons folder of program."

	Private CurScrnTBMaximum As Integer
	Private cursprpal, ScreenPicY, ScreenPicX, cursprcol As Integer
	Private ReadOnly FGFXMap(255) As Integer
	Private ReadOnly tmpFGFXMap(255) As Boolean
	Private ReadOnly GFXEnemListArray(255) As Integer
	Private ReadOnly FavEnemListArray(255) As Byte
	Private FavEnemListCount As Integer
	'Previous values for Numeric Up and Down
	Private CurEnemUD_ValuePrevious As Integer
	Private TypeUD_ValuePrevious As Integer
	Private EnemDmgUD_ValuePrevious As Integer
	Private HPUD_ValuePrevious As Integer
	Private WeaponDmgUD_ValuePrevious As Integer
	Private GFXSetUD_ValuePrevious As Integer
	Private Bank0UD_ValuePrevious As Integer
	Private Bank1UD_ValuePrevious As Integer
	Private XUD_ValuePrevious As Integer
	Private YUD_ValuePrevious As Integer
	Private ScrUD_ValuePrevious As Integer
	Private ScrnPresUD_ValuePrevious As Integer
	Private PalSetUD_ValuePrevious As Integer
	Private EffUD_ValuePrevious As Integer
	Private BGPalUD_ValuePrevious As Integer
	Private EffSprUD_ValuePrevious() As Integer

	'Objects that group many items
	'   Button
	Private EffSprAEdBtn() As Button
	'   CheckBox
	Private SettingsCheck() As CheckBox
	'   GroupBox
	Private GemFrame() As GroupBox
	'   NumericUpDown
	Private EffSprUD() As NumericUpDown
	'   PictureBox
	Private EffSprColPic() As PictureBox
	'   RadioButton
	Private EffSprSlot() As RadioButton
	Private EffSprTypeOpt() As RadioButton
	'	TextBox
	Private EffSprColTB() As TextBox

	Private Sub Form_Initialize()
		'Objects that group many items
		' Button
		EffSprAEdBtn = New Button() {_EffSprAEdBtn_0, _EffSprAEdBtn_1}
		' CheckBox
		SettingsCheck = New CheckBox() {_SettingsCheck_0, _SettingsCheck_1}
		' GroupBox
		GemFrame = New GroupBox() {_GemFrame_0, _GemFrame_1, _GemFrame_2}
		' PictureBox
		EffSprColPic = New PictureBox() {_EffSprColPic_1, _EffSprColPic_2, _EffSprColPic_3}
		' RadioButton
		EffSprSlot = New RadioButton() {_EffSprSlot_0, _EffSprSlot_1, _EffSprSlot_2, _EffSprSlot_3}
		EffSprTypeOpt = New RadioButton() {_EffSprTypeOpt_0, _EffSprTypeOpt_1, _EffSprTypeOpt_2, _EffSprTypeOpt_3}
		' TextBox
		EffSprColTB = New TextBox() {_EffSprColTB_1, _EffSprColTB_2, _EffSprColTB_3}
		' NumericUpDown
		EffSprUD = New NumericUpDown() {_EffSprUD_0, _EffSprUD_1, _EffSprUD_2, _EffSprUD_3, _EffSprUD_4, _EffSprUD_5}

		CurEnemUD_ValuePrevious = CurEnemUD.Value
		TypeUD_ValuePrevious = TypeUD.Value
		EnemDmgUD_ValuePrevious = EnemDmgUD.Value
		HPUD_ValuePrevious = HPUD.Value
		WeaponDmgUD_ValuePrevious = WeaponDmgUD.Value
		XUD_ValuePrevious = XUD.Value
		PalSetUD_ValuePrevious = PalSetUD.Value
		BGPalUD_ValuePrevious = BGPalUD.Value
		EffSprUD_ValuePrevious = {_EffSprUD_0.Value, _EffSprUD_1.Value, _EffSprUD_2.Value, _EffSprUD_3.Value, _EffSprUD_4.Value, _EffSprUD_5.Value}

		RenderModule.PB_Init((ScreenPic), enem_scr_bmi)
		RenderModule.PB_Init((ScreenPic), enem_scrb_bmi)
		RenderModule.PB_Init((TilePic), enem_tile_bmi)
		RenderModule.PB_Init((PalPic), enem_pal_bmi)

		CurEnemUD.Maximum = offs(gem, 19)
		CurScrnTBMaximum = offs(gem, 16)

		If GetCfg("enemcountfmthex") = 1 Then
			CurEnemUD.Hexadecimal = True
		Else
			CurEnemUD.Hexadecimal = False
		End If

		FavEnemListCount = -1 ' 0 means 1 item

		' This numericUpDown is same transferred between pans
		' We remember the position it has in General Tab and we will need to calculate from its label
		'	the position it will have in Weapon Damage Tab
		TypeUD_Location_GeneralPan = TypeUD.Location
		TypeUD_Location_WeaponPan = TypeUD_Location_GeneralPan - lblTypeGeneralPan.Location + lblTypeWeaponDamagePan.Location
		lblEnemyName_Location_GeneralPan = lblEnemyName.Location
		lblEnemyName_Location_WeaponPan = lblDamageToMegaMan.Location
		lblEnemyName_Location_WeaponPan.Y -= 18
	End Sub

	Public Sub Manual_Init()
		Dim a As Object
		Dim LoopMe As Byte
		If (gem = 0) Then LoopMe = 8
		If (gem = 1) Then LoopMe = 13
		If (gem = 2) Then LoopMe = 12
		For a = 0 To LoopMe
			WeaponList.Items.Add(SrcString(rdata(dspa(d_weaponname3 + gem) + a)))
		Next a
		WeaponList.SelectedIndex = 0
		If gem = 3 Then
			TabControlEnemEd.TabPages.RemoveAt(1)

			Label1.Visible = False
			ScrnPresUD.Visible = False
		End If

		If gem <> 0 Then GemFrame(0).Visible = False
		If gem <> 1 Then GemFrame(1).Visible = False
		If gem <> 2 Then GemFrame(2).Visible = False

		Dim showEnemyGfxStuff As Boolean
		If (gem = 0) Or (gem = 1) Then
			showEnemyGfxStuff = True
		Else
			showEnemyGfxStuff = False
		End If

		Label6.Visible = showEnemyGfxStuff
		GFXEnemList.Visible = showEnemyGfxStuff
		FindGFXBtn.Visible = showEnemyGfxStuff
		AutoSetCheck.Visible = showEnemyGfxStuff
	End Sub
	Private Sub EnemEd_Activated(sender As Object, e As EventArgs) Handles MyBase.Activated
		If palchartClaim = Palchart_Claim.EnemEd Then MFLE_Decl.PalChartToFront = True
	End Sub

	Private Sub EnemEd_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
		e.Cancel = True

		Me.Hide()
	End Sub

	'Updaters
	'====================================================================================================================

	Public Sub UpdateFnc()
		Dim a, b As Integer
		ScrnScroll.Maximum = (offs(gem, 16) + ScrnScroll.LargeChange - 1)

		'Restore Favourite Enemy List if closed/re-opened
		FavEnemList.Items.Clear()
		For a = 0 To FavEnemListCount
			b = FavEnemListArray(a)

			If b <= offs(gem, 58) Then
				FavEnemList.Items.Add(Hex(b) & ": " & SrcString(rdata(dspa(d_enames + gem) + b)))
			Else
				FavEnemList.Items.Add(Hex(b))
			End If
		Next a

		Update_Scrn()
		Update_BGPal(1)
	End Sub

	Public Sub Update_RefreshAllBitmaps()
		RenderModule.RenderPic(ScreenPic, enem_scr_bmi)
		RenderModule.RenderPic(TilePic, enem_tile_bmi)
		RenderModule.RenderPic(PalPic, enem_pal_bmi)
	End Sub

	Public Sub Update_Scrn()
		ScrnScroll.Tag = "=D"
		If curscreen <= (ScrnScroll.Maximum - ScrnScroll.LargeChange + 1) Then ScrnScroll.Value = curscreen
		ScrnScroll.Tag = vbNullString

		SetTBCoolText(CurScrnTB, Hex(curscreen))

		If gem < 3 Then
			SetUDCool(ScrnPresUD, Hex(romdat(arrayAdjuster + offs(gem, 7) + curscreen)), 2)
		End If

		Dim tstr As String
		If GetCfg("enemcountfmthex") = 1 Then
			tstr = Hex(curscroll)
		Else
			tstr = CStr(curscroll)
		End If

		CurScrollLabel.Text = "Scroll Map Position: " & tstr

		EnemsetWrite()

		ScreenDraw()

		EnemDraw(0)

		RenderModule.RenderPic(ScreenPic, enem_scr_bmi)
	End Sub

	Public Sub Update_BGPal(ByRef upd As Integer)
		Dim a, b As Integer

		If gem = 2 Then
			a = romdat(arrayAdjuster + offs(gem, o_ddA) + curscroll)
			SetCheckCool(BDCheck, Int(CShort(a And &H80S) / &H80S))
			SetCheckCool(SBCheck, Int(CShort(a And &H40S) / &H40S))
			b = a And &H3FS
			SetUDCool(PalSetUD, Hex(b), 2)
			If b > 0 Then
				BGPalUD.Enabled = True
				SetUDCool(BGPalUD, Hex(romdat(arrayAdjuster + offs(gem, 27) + ((b - 1) * 8)) And &H7FS), 2)
				BGPalCheck.Enabled = True
				SetCheckCool(BGPalCheck, Int(CShort(romdat(arrayAdjuster + offs(gem, 27) + ((b - 1) * 8)) And &H80S) / &H80S))
			Else
				BGPalUD.Enabled = False
				SetUDCool(BGPalUD, "", 2)
				BGPalCheck.Enabled = False
			End If
		End If

		If upd Then
			RenderModule.RenderPic(ScreenPic, enem_scr_bmi)
			RenderModule.RenderPic(PalPic, enem_pal_bmi)
		End If
	End Sub

	Public Sub Update_Global_Pal()
		If EffSprEdFrame.Visible = True Then
			Repaint_EffSprEd_Cols()
		End If
	End Sub

	Public Sub Update_ScrnStr(ByRef ustrY As Integer, ByRef ustrX As Integer)
		Dim blocknum, blockY, strX, strY, strnum, blockX, tilepal As Integer
		Dim x, tilenum, tileY, tileX, Y, screen As Integer
		EnemDraw(1)
		screen = MegaFLEX_Main.GetScreen
		For strY = 0 To 7
			For strX = 0 To 7
				If Not strY = ustrY Then GoTo skipstr
				If Not strX = ustrX Then GoTo skipstr
				If gem < 3 Then
					strnum = romdat(arrayAdjuster + offs(gem, 6) + (screen * 64) + ((strY * 8) + strX))
				Else
					strnum = romdat(arrayAdjuster + offs(gem, 6) + (screen * 8) + ((strY * 256) + strX))
				End If
				For blockY = 0 To 1
					For blockX = 0 To 1
						blocknum = romdat(arrayAdjuster + offs(gem, 5) + (strnum * 4) + ((blockY * 2) + blockX))
						tilepal = Nibble(romdat(arrayAdjuster + offs(gem, 4) + blocknum), 1) And 3
						For tileY = 0 To 1
							For tileX = 0 To 1
								tilenum = romdat(arrayAdjuster + offs(gem, 3) + (((tileY * 2) + tileX) * &H100S) + blocknum)
								Y = (((strY * 32) + blockY * 16) + tileY * 8)
								x = (((strX * 32) + blockX * 16) + tileX * 8)
								RenderModule.DrawTile(enem_scr_bmi, chrmap(tilenum), tilepal + &H4S, x, Y, romdat)
							Next tileX
						Next tileY
					Next blockX
				Next blockY
skipstr:
			Next strX
		Next strY

		Array.Copy(enem_scr_bmi.bytesPal_ByPixelID, enem_scrb_bmi.bytesPal_ByPixelID, enem_scr_bmi.bytesPal_ByPixelID.Length)
		Array.Copy(enem_scr_bmi.bytesRGB_ByPixelID, enem_scrb_bmi.bytesRGB_ByPixelID, enem_scr_bmi.bytesRGB_ByPixelID.Length)

		enem_scr_bmi.bytesRGB_UpdatedSinceLastRender = True
		enem_scrb_bmi.bytesRGB_UpdatedSinceLastRender = True
		EnemDraw(0)
		RenderModule.RenderPic(ScreenPic, enem_scr_bmi)
	End Sub

	Public Sub Update_StrBlock(ByRef ustr As Integer, ByRef ublock As Integer)
		Dim blocknum, blockY, strX, strY, strnum, blockX, tilepal As Integer
		Dim x, tilenum, tileY, tileX, Y, screen As Integer
		EnemDraw(1)
		screen = MegaFLEX_Main.GetScreen
		For strY = 0 To 7
			For strX = 0 To 7
				If gem < 3 Then
					strnum = romdat(arrayAdjuster + offs(gem, 6) + (screen * 64) + ((strY * 8) + strX))
				Else
					strnum = romdat(arrayAdjuster + offs(gem, 6) + (screen * 8) + ((strY * 256) + strX))
				End If
				If Not strnum = ustr Then GoTo skipstr
				For blockY = 0 To 1
					For blockX = 0 To 1
						If Not (blockY * 2) + blockX = ublock Then GoTo skipblock
						blocknum = romdat(arrayAdjuster + offs(gem, 5) + (strnum * 4) + ((blockY * 2) + blockX))
						tilepal = Nibble(romdat(arrayAdjuster + offs(gem, 4) + blocknum), 1) And 3
						For tileY = 0 To 1
							For tileX = 0 To 1
								tilenum = romdat(arrayAdjuster + offs(gem, 3) + (((tileY * 2) + tileX) * &H100S) + blocknum)
								Y = (((strY * 32) + blockY * 16) + tileY * 8)
								x = (((strX * 32) + blockX * 16) + tileX * 8)
								RenderModule.DrawTile(enem_scr_bmi, chrmap(tilenum), tilepal + &H4S, x, Y, romdat)
							Next tileX
						Next tileY
skipblock:
					Next blockX
				Next blockY
skipstr:
			Next strX
		Next strY

		Array.Copy(enem_scr_bmi.bytesPal_ByPixelID, enem_scrb_bmi.bytesPal_ByPixelID, enem_scr_bmi.bytesPal_ByPixelID.Length)
		Array.Copy(enem_scr_bmi.bytesRGB_ByPixelID, enem_scrb_bmi.bytesRGB_ByPixelID, enem_scr_bmi.bytesRGB_ByPixelID.Length)

		enem_scr_bmi.bytesRGB_UpdatedSinceLastRender = True
		enem_scrb_bmi.bytesRGB_UpdatedSinceLastRender = True
		EnemDraw(0)
		RenderModule.RenderPic(ScreenPic, enem_scr_bmi)
	End Sub

	Public Sub Update_Block(ByRef ublock As Integer)
		Dim blocknum, blockY, strX, strY, strnum, blockX, tilepal As Integer
		Dim x, tilenum, tileY, tileX, Y, screen As Integer
		EnemDraw(1)
		screen = MegaFLEX_Main.GetScreen
		For strY = 0 To 7
			For strX = 0 To 7
				If gem < 3 Then
					strnum = romdat(arrayAdjuster + offs(gem, 6) + (screen * 64) + ((strY * 8) + strX))
				Else
					strnum = romdat(arrayAdjuster + offs(gem, 6) + (screen * 8) + ((strY * 256) + strX))
				End If
				For blockY = 0 To 1
					For blockX = 0 To 1
						blocknum = romdat(arrayAdjuster + offs(gem, 5) + (strnum * 4) + ((blockY * 2) + blockX))
						If Not blocknum = ublock Then GoTo skipblock
						tilepal = Nibble(romdat(arrayAdjuster + offs(gem, 4) + blocknum), 1) And 3
						For tileY = 0 To 1
							For tileX = 0 To 1
								tilenum = romdat(arrayAdjuster + offs(gem, 3) + (((tileY * 2) + tileX) * &H100S) + blocknum)
								Y = (((strY * 32) + blockY * 16) + tileY * 8)
								x = (((strX * 32) + blockX * 16) + tileX * 8)
								RenderModule.DrawTile(enem_scr_bmi, chrmap(tilenum), tilepal + &H4S, x, Y, romdat)
							Next tileX
						Next tileY
skipblock:
					Next blockX
				Next blockY
			Next strX
		Next strY

		Array.Copy(enem_scr_bmi.bytesPal_ByPixelID, enem_scrb_bmi.bytesPal_ByPixelID, enem_scr_bmi.bytesPal_ByPixelID.Length)
		Array.Copy(enem_scr_bmi.bytesRGB_ByPixelID, enem_scrb_bmi.bytesRGB_ByPixelID, enem_scr_bmi.bytesRGB_ByPixelID.Length)

		enem_scr_bmi.bytesRGB_UpdatedSinceLastRender = True
		enem_scrb_bmi.bytesRGB_UpdatedSinceLastRender = True

		EnemDraw(0)
		RenderModule.RenderPic(ScreenPic, enem_scr_bmi)
	End Sub

	Public Sub Update_TileRange(ByRef min As Integer, ByRef max As Integer)
		Dim blocknum, blockY, strX, strY, strnum, blockX, tilepal As Integer
		Dim x, tilenum, tileY, tileX, Y, screen As Integer
		EnemDraw(1)
		screen = MegaFLEX_Main.GetScreen
		For strY = 0 To 7
			For strX = 0 To 7
				If gem < 3 Then
					strnum = romdat(arrayAdjuster + offs(gem, 6) + (screen * 64) + ((strY * 8) + strX))
				Else
					strnum = romdat(arrayAdjuster + offs(gem, 6) + (screen * 8) + ((strY * 256) + strX))
				End If
				For blockY = 0 To 1
					For blockX = 0 To 1
						blocknum = romdat(arrayAdjuster + offs(gem, 5) + (strnum * 4) + ((blockY * 2) + blockX))
						tilepal = Nibble(romdat(arrayAdjuster + offs(gem, 4) + blocknum), 1) And 3
						For tileY = 0 To 1
							For tileX = 0 To 1
								tilenum = romdat(arrayAdjuster + offs(gem, 3) + (((tileY * 2) + tileX) * &H100S) + blocknum)
								If tilenum >= min And tilenum <= max Then
									Y = (((strY * 32) + blockY * 16) + tileY * 8)
									x = (((strX * 32) + blockX * 16) + tileX * 8)
									RenderModule.DrawTile(enem_scr_bmi, chrmap(tilenum), tilepal + &H4S, x, Y, romdat)
								End If
							Next tileX
						Next tileY
					Next blockX
				Next blockY
			Next strX
		Next strY

		Array.Copy(enem_scr_bmi.bytesPal_ByPixelID, enem_scrb_bmi.bytesPal_ByPixelID, enem_scr_bmi.bytesPal_ByPixelID.Length)
		Array.Copy(enem_scr_bmi.bytesRGB_ByPixelID, enem_scrb_bmi.bytesRGB_ByPixelID, enem_scr_bmi.bytesRGB_ByPixelID.Length)

		enem_scr_bmi.bytesRGB_UpdatedSinceLastRender = True
		enem_scrb_bmi.bytesRGB_UpdatedSinceLastRender = True

		EnemDraw(0)
		RenderModule.RenderPic(ScreenPic, enem_scr_bmi)
	End Sub

	'PalChart Form Event
	'====================================================================================================================

	Public Sub PCEvent()
		If cursprcol = 0 Then Exit Sub
		'Dim enemset
		'enemset = Asc(mid$(romdat, offs(gem, o_ddA) + (curscroll * 2) + 0, 1))
		If gem = 3 Then
			MFLE_Main.SetMM6Col((&H18S + (cursprpal * 4) + cursprcol), palchart_col)
			glob_pal(cursprcol + (cursprpal * 4) + &H48S) = NESPAL(MFLE_Main.GetMM6Col(&H18S + (cursprpal * 4) + cursprcol))
			PPU_palette_val(cursprcol + (cursprpal * 4) + &H18S) = MFLE_Main.GetMM6Col(&H18S + (cursprpal * 4) + cursprcol)
		Else
			romdat(arrayAdjuster + sprpaloff((cursprpal * 4) + cursprcol)) = palchart_col
			glob_pal(cursprcol + (cursprpal * 4) + &H48S) = NESPAL(romdat(arrayAdjuster + sprpaloff((cursprpal * 4) + cursprcol)))
			PPU_palette_val(cursprcol + (cursprpal * 4) + &H18S) = romdat(arrayAdjuster + sprpaloff((cursprpal * 4) + cursprcol))
		End If
		MFLE_Main.Update_Global_Pal(False) 'Only refresh manually in Enemy Editor.
		RenderModule.RenderPic(PalPic, enem_pal_bmi)
		RenderModule.RenderPic(ScreenPic, enem_scr_bmi)
		RenderModule.RenderPic(TilePic, enem_tile_bmi)
	End Sub

	'Interface Events
	'================

	Private Sub AddFavBtn_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles AddFavBtn.Click
		Dim a, c As Integer
		Dim tstr As String
		a = romdat(arrayAdjuster + offs(gem, 14) + curenem)
		tstr = Hex(a) & ": " & SrcString(rdata(dspa(d_enames + gem) + a))
		For c = 0 To FavEnemListCount
			If tstr = FavEnemList.Items(c) Then Exit Sub
		Next c
		If a <= offs(gem, 58) Then
			FavEnemList.Items.Add(tstr)
		Else
			FavEnemList.Items.Add(Hex(a))
		End If
		FavEnemListCount += 1
		FavEnemListArray(FavEnemListCount) = a
	End Sub

	Private Sub FavLoadBtn_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles FavLoadBtn.Click
		Dim FileName As String
		Dim NiceDialog As New clsDialog
		Dim numfav As Integer
		Dim tbyte As Byte
		Dim a As Integer
		Dim PathBackup As String = CurDir()
		Dim Title As String = "Choose a file."
		Dim InitDir As String = ""
		Dim DefExt As String = ""
		Dim Filter As String = ".LST files|*.lst|All files|*.*"
		Dim flags As clsDialog.DialogFlags = clsDialog.DialogFlags.CHECKFILEEXISTS Or clsDialog.DialogFlags.CHECKPATHEXISTS

		FileName = NiceDialog.ShowOpen(Me, Title, flags, InitDir, DefExt, Filter)
		If Len(FileName) = 0 Then GoTo exitme
		FileName = Common.Left(FileName, Len(FileName))

		FileOpen(1, FileName, OpenMode.Binary)
		FavEnemList.Items.Clear()
		FileGet(1, numfav)

		If numfav = -1 Then GoTo stopread

		For a = 0 To (numfav)
			FileGet(1, tbyte)

			If tbyte <= offs(gem, 58) Then
				FavEnemList.Items.Add(Hex(tbyte) & ": " & SrcString(rdata(dspa(d_enames + gem) + tbyte)))
			Else
				FavEnemList.Items.Add(Hex(tbyte))
			End If
			FavEnemListArray(a) = tbyte
		Next a

stopread:
		FileClose(1)
		FavEnemListCount = numfav

exitme:
		ChDir(PathBackup)
	End Sub

	Private Sub FavSaveBtn_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles FavSaveBtn.Click
		Dim FileName As String
		Dim NiceDialog As New clsDialog
		Dim numfav As Integer
		Dim tbyte As Byte
		Dim a As Integer
		Dim PathBackup As String = CurDir()
		Dim Title As String = "Choose a file."
		Dim InitDir As String = ""
		Dim DefExt As String = ""
		Dim Filter As String = ".LST files|*.lst|All files|*.*"
		Dim flags As clsDialog.DialogFlags = clsDialog.DialogFlags.CHECKPATHEXISTS

		FileName = NiceDialog.ShowSave(Me, Title, flags, InitDir, DefExt, Filter)
		If Len(FileName) = 0 Then GoTo exitme
		FileName = Common.Left(FileName, Len(FileName))

		Killifexistandopen(FileName, 1)
		'Open FileName For Binary As #1
		numfav = FavEnemListCount
		FilePut(1, numfav)
		For a = 0 To numfav
			tbyte = FavEnemListArray(a)
			FilePut(1, tbyte)
		Next a
		FileClose(1)
exitme:

		ChDir(PathBackup)
	End Sub

	Private Sub DelEnemBtn_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles DelEnemBtn.Click
		DelEnem()
	End Sub

	Private Sub InsEnemBtn_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles InsEnemBtn.Click
		InsEnem()
	End Sub

	Private Sub EffSprAEdBtn_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles _EffSprAEdBtn_1.Click, _EffSprAEdBtn_0.Click
		Dim Index As Short = 0

		For Each button As Button In EffSprAEdBtn
			If button.Name = eventSender.Name Then
				Exit For
			End If
			Index += 1
		Next

		Dim a As Integer
		a = romdat(arrayAdjuster + offs(gem, 14) + curenem) And &H3FS
		If gem = 1 Then curpalanim = romdat(arrayAdjuster + rdata(dspa(d_ex) + 9) + a) And &H7FS
		Select Case Index
			Case 0 : If gem = 2 Then curpalanim = romdat(arrayAdjuster + rdata(dspa(d_ex) + 13) + a) And &H7FS
				PalEd.Update()
				PalEd.Show()
				PalEd.Activate()
			Case 1 : If gem = 2 Then TileTable.CHRIDUD.Text = EffSprUD(2).Text
				MiscEd.Update_Frm()
				MiscEd.Show()
				MiscEd.Activate()
		End Select
	End Sub

	Private Sub PCShowCmd_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles PCShowCmd.Click
		MFLE_Decl.PalChartToFront = True
		Dim pnt As New Point(Me.Right, Me.Top)

		PalChart.Location = pnt

		'This prevent it from showing too fast - sometime is shown quickly at wrong position
		Do
		Loop While (PalChart.Location <> pnt)

		If PalChart.Visible = False Then PalChart.Show() 'Else it causes infinite calls
		palchartClaim = Palchart_Claim.EnemEd
	End Sub

	Private Sub SprGroupBtn_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles SprGroupBtn.Click
		Dim SprGrWnd As ProtoWnd
		SprGrWnd = New ProtoWnd
		SprGrWnd.InitMode_SpriteGroup()
		SprGrWnd.ShowDialog()
		Dim Y, a, p, p2, etype, x As Integer
		p = SprGrWnd.passVar
		If (p > 0) Then
			p2 = 0
			Do
				a = rdata(p + p2)
				If Not (a >= &H100S) Then
					etype = a
					x = rdata(p + p2 + 1)
					Y = rdata(p + p2 + 2)
					InsEnem(True, x, Y, etype)
					p2 += 3
				End If
			Loop Until (a >= &H100S) Or (p2 > 1000)
		End If
	End Sub

	Private Sub TabControlEnemEd_SelectedIndexChanged(sender As Object, e As EventArgs) Handles TabControlEnemEd.SelectedIndexChanged
		Dim Sprstring As String = ""
		Select Case gem
			Case 0 : Sprstring = My.Application.Info.DirectoryPath & "\Icons\" & WeaponList.SelectedIndex & ".gif"
			Case 1 : Sprstring = My.Application.Info.DirectoryPath & "\Icons\" & WeaponList.SelectedIndex & ".ico"
			Case 2 : Sprstring = My.Application.Info.DirectoryPath & "\Icons\" & WeaponList.SelectedIndex & ".bmp"
		End Select
		Try
			WeaponIcon.Image = System.Drawing.Image.FromFile(Sprstring)
		Catch ex As Exception
			If WeaponImagesMissing = False Then
				MessageBox.Show(WeaponImagesMissingErrorMsg, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
			End If
			WeaponImagesMissing = True
		End Try

		' Some controls are shared between the Tabs, remove it where it is now and then add it back on the appropriate
		'	GroupBox
		If gbxGeneral.Controls.Contains(TypeUD) Then
			gbxGeneral.Controls.Remove(TypeUD)
		ElseIf gbxWeapon.Controls.Contains(TypeUD) Then
			gbxWeapon.Controls.Remove(TypeUD)
		End If

		If gbxGeneral.Controls.Contains(lblEnemyName) Then
			gbxGeneral.Controls.Remove(lblEnemyName)
		ElseIf gbxWeapon.Controls.Contains(lblEnemyName) Then
			gbxWeapon.Controls.Remove(lblEnemyName)
		End If

		If TabControlEnemEd.SelectedIndex = 0 Then
			gbxGeneral.Controls.Add(TypeUD)
			TypeUD.Location = TypeUD_Location_GeneralPan
			gbxGeneral.Controls.Add(lblEnemyName)
			lblEnemyName.Location = lblEnemyName_Location_GeneralPan
		Else
			gbxWeapon.Controls.Add(TypeUD)
			TypeUD.Location = TypeUD_Location_WeaponPan
			gbxWeapon.Controls.Add(lblEnemyName)
			lblEnemyName.Location = lblEnemyName_Location_WeaponPan
		End If

		' To be sure it is not behind label
		TypeUD.BringToFront()
		lblEnemyName.BringToFront()
	End Sub

	Private Sub RemFavBtn_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles RemFavBtn.Click
		Dim a As Integer
		If FavEnemList.SelectedIndex > -1 Then
			If FavEnemList.SelectedIndex < FavEnemListCount Then
				For a = FavEnemList.SelectedIndex To (FavEnemListCount - 1)
					FavEnemListArray(a) = FavEnemListArray(a + 1)
				Next a
			End If
			FavEnemList.Items.RemoveAt(FavEnemList.SelectedIndex)
			FavEnemListCount -= 1
		End If
	End Sub

	Private Sub FindGFXBtn_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles FindGFXBtn.Click
		EnemDraw(1)
		FindGFX_Update()
		EnemDraw(0)
		RenderModule.RenderPic(ScreenPic, enem_scr_bmi)
	End Sub

	Private Sub EffSprColTB_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles _EffSprColTB_3.TextChanged, _EffSprColTB_2.TextChanged, _EffSprColTB_1.TextChanged
		Dim Index As Short = 0

		For Each textBox As TextBox In EffSprColTB
			If textBox.Name = eventSender.Name Then
				Exit For
			End If
			Index += 1
		Next

		If EffSprColTB(Index).Tag <> "" Then Exit Sub

		SetTBCoolNumWithValidation(EffSprColTB(Index), EffSprColTB(Index).Text, &H3FS, 2, True)



		Dim a, b As Integer

		a = romdat(arrayAdjuster + offs(gem, 14) + curenem) And &H3FS
		Select Case gem
			Case 1 : b = romdat(arrayAdjuster + rdata(dspa(d_ex) + 9) + a) And &H7FS
				romdat(arrayAdjuster + rdata(dspa(d_ex) + 10) + (b * 4) + Index) = Dec(EffSprColTB(Index).Text)
				EffSprColPic(Index).BackColor = System.Drawing.ColorTranslator.FromOle(RGBmirr(NESPAL(romdat(arrayAdjuster + rdata(dspa(d_ex) + 10) + (b * 4) + Index))))
			Case 2 : b = romdat(arrayAdjuster + rdata(dspa(d_ex) + 13) + a) And &H7FS
				romdat(arrayAdjuster + rdata(dspa(d_ex) + 15) + (b * 4) + Index) = Dec(EffSprColTB(Index).Text)
				EffSprColPic(Index).BackColor = System.Drawing.ColorTranslator.FromOle(RGBmirr(NESPAL(romdat(arrayAdjuster + rdata(dspa(d_ex) + 15) + (b * 4) + Index))))
		End Select
	End Sub

	Private Sub SprAnimTB_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles SprAnimTB.TextChanged
		'Dim a, b, c, x, y, edscrpos, width, height, my, mx, py, px
		'Dim etype, spr, sprbank, bankoff, offH, offL, sprframe, frameset, tmp, tile, pal, coordref, coorpage, ry, rx, fy, fx
		'Dim sproff As Long, froff As Long, coff As Long
		'Dim eff_flag, dstchrbnk, srcchrbnk

		Dim eff_flag, frames, offH, sprbank, etype, spr, offL, sproff, framelength, bankoff As Integer
		Dim b As Integer

		EnemDraw(1)

		For etype = 0 To &HFFS
			Select Case gem
				Case 0
					spr = romdat(arrayAdjuster + rdata(dspa(d_ex) + dex_mm3_enemsprid) + etype)
					If spr And &H80S Then
						sprbank = 1
					Else
						sprbank = 0
						If etype >= &H47S And etype <= &H4ES Then sprbank = 2
						If etype >= &H5ES And etype <= &H5FS Then sprbank = 2
						If etype >= &H68S And etype <= &H6FS Then sprbank = 2
						If etype >= &H79S And etype <= &H89S Then sprbank = 2 'org &H81
					End If
					spr = spr And &H7FS
					offL = romdat(arrayAdjuster + offs(gem, 43 + sprbank) + spr)
					offH = romdat(arrayAdjuster + offs(gem, 46 + sprbank) + spr)
					offH = (offH - &H80S) + offs(gem, 38 + sprbank)
					sproff = (offH * 256) + offL + &H11S
					frames = romdat(arrayAdjuster + sproff + 0)
					framelength = romdat(arrayAdjuster + sproff + 1)
					Spr_Anim_Handle_Advance(etype, frames, framelength)
				Case 1
					spr = romdat(arrayAdjuster + offs(gem, 29) + etype)
					eff_flag = rdata(dspa(d_greenframe4) + etype)
					If etype >= &HC0S Or eff_flag = 1 Then
						GoTo no_advance
					End If
					If etype = 3 Then spr = &H14S
					If etype = &H30S Then spr = &H67S
					If etype = &H4FS Then spr = &HA9S
					If etype = &H73S Then spr = &H9ES
					If etype = &H79S Then spr = &H44S + level
					sprbank = romdat(arrayAdjuster + offs(gem, 30) + romdat(arrayAdjuster + offs(gem, 28) + etype))
					bankoff = ((sprbank - 1) * &H2000S) + &H11S
					offL = romdat(arrayAdjuster + offs(gem, 43) + bankoff + spr)
					offH = romdat(arrayAdjuster + offs(gem, 46) + bankoff + spr)
					sproff = ((offH - &H80S) * 256) + offL + bankoff
					frames = romdat(arrayAdjuster + sproff + 0) And &H7FS
					framelength = romdat(arrayAdjuster + sproff + 1)
					Spr_Anim_Handle_Advance(etype, frames, framelength)
				Case 2
					spr = romdat(arrayAdjuster + offs(gem, 29) + etype)
					eff_flag = rdata(dspa(d_greenframe5) + etype)
					If etype >= &HC0S Or eff_flag = 1 Then
						GoTo no_advance
					End If
					sprbank = romdat(arrayAdjuster + offs(gem, 30) + romdat(arrayAdjuster + offs(gem, 28) + etype))
					bankoff = (sprbank * &H2000S) + &H11S
					offL = romdat(arrayAdjuster + offs(gem, 43) + bankoff + spr)
					offH = romdat(arrayAdjuster + offs(gem, 46) + bankoff + spr)
					sproff = ((offH - &H80S) * 256) + offL + bankoff
					frames = romdat(arrayAdjuster + sproff + 0) And &H7FS
					framelength = romdat(arrayAdjuster + sproff + 1)
					Spr_Anim_Handle_Advance(etype, frames, framelength)
				Case 3
					eff_flag = 0
					If (etype = &H80S) Or (eff_flag = 1) Then
						GoTo no_advance
					End If
					b = (romdat(arrayAdjuster + &H744DA + etype) * &H2000) + ((romdat(arrayAdjuster + &H743DA + etype) - &H80S) * &H100S) + romdat(arrayAdjuster + &H742DA + etype) + &H11S
					spr = romdat(arrayAdjuster + b - 6)
					sprbank = romdat(arrayAdjuster + offs(gem, 30) + Int(etype / &H10S))
					bankoff = (sprbank * &H2000S) + &H11S
					offL = romdat(arrayAdjuster + offs(gem, 43) + bankoff + spr)
					offH = romdat(arrayAdjuster + offs(gem, 46) + bankoff + spr)
					sproff = ((offH - &H80S) * 256) + offL + bankoff
					frames = (CShort(romdat(arrayAdjuster + sproff + 0) And &H7FS) / 2) - 1
					framelength = romdat(arrayAdjuster + sproff + 2 + (spranim_fc_reg(etype) * 2)) + 0
					Spr_Anim_Handle_Advance(etype, frames, framelength)
			End Select
no_advance:
		Next etype

		EnemDraw(0)
		EnemDatWrite()
		RenderModule.RenderPic(ScreenPic, enem_scr_bmi)

		'If clear Then
		'    MFX_Render.ClearSprTile ScreenPic, enem_scr_bmi, enem_scrb_bmi, chrmap(tile + &H100), x + rx, y + ry, fy, fx
		'Else
		'    MFX_Render.DrawSprTile ScreenPic, enem_scr_bmi, chrmap(tile + &H100), pal + &H10, x + rx, y + ry, fy, fx
		'End If

	End Sub

	Private Sub CurScrnTB_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles CurScrnTB.TextChanged
		If CurScrnTB.Tag = "" Then
			SetTBCoolNumWithValidation(CurScrnTB, CurScrnTB.Text, CurScrnTBMaximum, 2, True)
			curscreen = Dec(CurScrnTB.Text)
			ScrnScroll_Change(curscreen)
			MFLE_Main.Update_Scrn()
		End If
	End Sub

	'MM5: Toggle Boss Door
	Private Sub BDCheck_CheckStateChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles BDCheck.CheckStateChanged
		Dim a As Integer
		If BDCheck.Tag <> "" Then Exit Sub
		a = romdat(arrayAdjuster + offs(gem, o_ddA) + curscroll)
		romdat(arrayAdjuster + offs(gem, o_ddA) + curscroll) = (CShort(a And &H7FS) + (BDCheck.CheckState * &H80S))
	End Sub

	Private Sub BGPalCheck_CheckStateChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles BGPalCheck.CheckStateChanged
		If BGPalCheck.Tag <> "" Then Exit Sub
		romdat(arrayAdjuster + sprpaloff(0)) = CShort(romdat(arrayAdjuster + sprpaloff(0)) And &H7FS) + (BGPalCheck.CheckState * &H80S)
		MFLE_Main.Update_PalSet()
	End Sub

	Private Sub SBCheck_CheckStateChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles SBCheck.CheckStateChanged
		Dim a As Integer
		If SBCheck.Tag <> "" Then Exit Sub
		a = romdat(arrayAdjuster + offs(gem, o_ddA) + curscroll)
		romdat(arrayAdjuster + offs(gem, o_ddA) + curscroll) = (CShort(a And &HBFS) + (BDCheck.CheckState * &H40S))
	End Sub

	Private Sub EffSprSlot_CheckedChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles _EffSprSlot_3.CheckedChanged, _EffSprSlot_2.CheckedChanged, _EffSprSlot_1.CheckedChanged, _EffSprSlot_0.CheckedChanged
		If eventSender.Checked Then
			Dim Index As Short = 0

			For Each radioButton As RadioButton In EffSprSlot
				If radioButton.Name = eventSender.Name Then
					Exit For
				End If
				Index += 1
			Next



			Dim a, b As Integer
			a = romdat(arrayAdjuster + offs(gem, 14) + curenem) And &H3FS
			If gem = 1 Then romdat(arrayAdjuster + rdata(dspa(d_ex) + 8) + a) = Int(Index)
			If gem = 2 Then
				b = romdat(arrayAdjuster + rdata(dspa(d_ex) + 13) + a)
				If b >= &H80S Then romdat(arrayAdjuster + rdata(dspa(d_ex) + 12) + a) = Int(Index)
				If b <= &H7FS Then romdat(arrayAdjuster + rdata(dspa(d_ex) + 12) + a) = Int(Index * 4)
			End If
		End If
	End Sub
	Private Sub EffSprTypeOpt_CheckedChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles _EffSprTypeOpt_3.CheckedChanged, _EffSprTypeOpt_2.CheckedChanged, _EffSprTypeOpt_1.CheckedChanged, _EffSprTypeOpt_0.CheckedChanged
		If eventSender.Checked Then
			Dim Index As Short = 0

			For Each radioButton As RadioButton In EffSprTypeOpt
				If radioButton.Name = eventSender.Name Then
					Exit For
				End If
				Index += 1
			Next

			Dim a, b As Integer
			If EffSprTypeOpt(Index).Tag <> "" Then Exit Sub
			a = romdat(arrayAdjuster + offs(gem, 14) + curenem) And &H3FS
			EnemDraw(1)
			Select Case gem
				Case 1 : b = romdat(arrayAdjuster + rdata(dspa(d_ex) + 9) + a)
					romdat(arrayAdjuster + rdata(dspa(d_ex) + 9) + a) = (CShort(b And &H7FS) + (CShort(Index Xor 1) * &H80S))
				Case 2
					If Index = 2 Then
						b = romdat(arrayAdjuster + rdata(dspa(d_ex) + 12) + a)
						romdat(arrayAdjuster + rdata(dspa(d_ex) + 12) + a) = (CShort(b And &H7FS) + (&H80S))
					End If
					If Index = 3 Then
						romdat(arrayAdjuster + rdata(dspa(d_ex) + 12) + a) = &H10S
					End If
					If (Index = 0) Or (Index = 1) Then
						romdat(arrayAdjuster + rdata(dspa(d_ex) + 12) + a) = 0 'reset the index value.
						b = romdat(arrayAdjuster + rdata(dspa(d_ex) + 13) + a)
						romdat(arrayAdjuster + rdata(dspa(d_ex) + 13) + a) = (CShort(b And &H7FS) + (CShort(Index Xor 1) * &H80S))
					End If
			End Select
			EnemDraw(0)
			EnemDatWrite()
			RenderModule.RenderPic(ScreenPic, enem_scr_bmi)
			EnemDatWrite()
		End If
	End Sub

	Private Sub GFXEnemList_SelectedIndexChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles GFXEnemList.SelectedIndexChanged
		EnemDraw(1)
		romdat(arrayAdjuster + offs(gem, 14) + curenem) = (GFXEnemListArray(GFXEnemList.SelectedIndex))
		If AutoSetCheck.CheckState = 1 Then FindGFX_Update()
		EnemDraw(0)
		EnemDatWrite()
		RenderModule.RenderPic(ScreenPic, enem_scr_bmi)
	End Sub

	Private Sub FavEnemList_SelectedIndexChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles FavEnemList.SelectedIndexChanged
		If (FavEnemList.SelectedIndex <> -1) Then
			EnemDraw(1)
			romdat(arrayAdjuster + offs(gem, 14) + curenem) = (FavEnemListArray(FavEnemList.SelectedIndex))
			If AutoSetCheck.CheckState = 1 Then FindGFX_Update()
			EnemDraw(0)
			EnemDatWrite()
			RenderModule.RenderPic(ScreenPic, enem_scr_bmi)
		End If
	End Sub

	Private Function ScreenPic_KeyDown(ByRef KeyCode As Short) As Boolean
		ScreenPic_KeyDown = True

		If KeyCode = System.Windows.Forms.Keys.Delete Then
			DelEnem()
		ElseIf KeyCode = System.Windows.Forms.Keys.Insert Then
			InsEnem()
		ElseIf KeyCode = System.Windows.Forms.Keys.Up Then
			If romdat(arrayAdjuster + offs(gem, 13) + curenem) > 0 Then EnemDraw(1) : romdat(arrayAdjuster + offs(gem, 13) + curenem) = (romdat(arrayAdjuster + offs(gem, 13) + curenem) - 1) : EnemDraw(0) : RenderModule.RenderPic(ScreenPic, enem_scr_bmi)
		ElseIf KeyCode = System.Windows.Forms.Keys.Down Then
			If romdat(arrayAdjuster + offs(gem, 13) + curenem) < 256 Then EnemDraw(1) : romdat(arrayAdjuster + offs(gem, 13) + curenem) = (romdat(arrayAdjuster + offs(gem, 13) + curenem) + 1) : EnemDraw(0) : RenderModule.RenderPic(ScreenPic, enem_scr_bmi)
		ElseIf KeyCode = System.Windows.Forms.Keys.Left Then
			If romdat(arrayAdjuster + offs(gem, 12) + curenem) > 0 Then
				EnemDraw(1)
				romdat(arrayAdjuster + offs(gem, 12) + curenem) = (romdat(arrayAdjuster + offs(gem, 12) + curenem) - 1)
				If GetCfg("auto_enemxsort") = 1 Then EnemSortByX(curenem)
				EnemDraw(0)
				EnemDatWrite()
				RenderModule.RenderPic(ScreenPic, enem_scr_bmi)
			End If
		ElseIf KeyCode = System.Windows.Forms.Keys.Right Then
			If romdat(arrayAdjuster + offs(gem, 12) + curenem) < 256 Then
				EnemDraw(1)
				romdat(arrayAdjuster + offs(gem, 12) + curenem) = (romdat(arrayAdjuster + offs(gem, 12) + curenem) + 1)
				If GetCfg("auto_enemxsort") = 1 Then EnemSortByX(curenem)
				EnemDraw(0)
				EnemDatWrite()
				RenderModule.RenderPic(ScreenPic, enem_scr_bmi)
			End If
		ElseIf KeyCode = System.Windows.Forms.Keys.W Then
			If romdat(arrayAdjuster + offs(gem, 14) + curenem) < &HF0S Then EnemDraw(1) : romdat(arrayAdjuster + offs(gem, 14) + curenem) = (romdat(arrayAdjuster + offs(gem, 14) + curenem) + &H10S) : EnemDraw(0) : RenderModule.RenderPic(ScreenPic, enem_scr_bmi)
		ElseIf KeyCode = System.Windows.Forms.Keys.S Then
			If romdat(arrayAdjuster + offs(gem, 14) + curenem) > 15 Then EnemDraw(1) : romdat(arrayAdjuster + offs(gem, 14) + curenem) = (romdat(arrayAdjuster + offs(gem, 14) + curenem) - &H10S) : EnemDraw(0) : RenderModule.RenderPic(ScreenPic, enem_scr_bmi)
		ElseIf KeyCode = System.Windows.Forms.Keys.D Then
			If romdat(arrayAdjuster + offs(gem, 14) + curenem) < &HFFS Then EnemDraw(1) : romdat(arrayAdjuster + offs(gem, 14) + curenem) = (romdat(arrayAdjuster + offs(gem, 14) + curenem) + 1) : EnemDraw(0) : RenderModule.RenderPic(ScreenPic, enem_scr_bmi)
		ElseIf KeyCode = System.Windows.Forms.Keys.A Then
			If romdat(arrayAdjuster + offs(gem, 14) + curenem) > 0 Then EnemDraw(1) : romdat(arrayAdjuster + offs(gem, 14) + curenem) = (romdat(arrayAdjuster + offs(gem, 14) + curenem) - 1) : EnemDraw(0) : RenderModule.RenderPic(ScreenPic, enem_scr_bmi)
		Else
			ScreenPic_KeyDown = False
		End If
	End Function

	Private Sub ScreenPic_PreviewKeyDown(sender As Object, e As PreviewKeyDownEventArgs) Handles ScreenPic.PreviewKeyDown
		Dim keyHandled As Boolean = False

		If (ScreenPic.Name = ActiveControl.Name) Then
			keyHandled = ScreenPic_KeyDown(e.KeyCode)
		End If

		If keyHandled Then
			e.IsInputKey = True
		Else
			Dim KeyCode As Short = e.KeyCode
			Dim Shift As Short = e.KeyData \ &H10000
			MFLE_Main.Global_KeyDown(KeyCode, Shift)
		End If
	End Sub

	Private Sub FavEnemList_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles FavEnemList.KeyDown
		Dim KeyCode As Short = eventArgs.KeyCode
		Dim Shift As Short = eventArgs.KeyData \ &H10000
		If KeyCode = System.Windows.Forms.Keys.Delete Then RemFavBtn_Click(RemFavBtn, New System.EventArgs())
	End Sub

	Private Sub ScreenPic_MouseMove(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles ScreenPic.MouseMove
		Dim Button As Short = eventArgs.Button \ &H100000
		Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
		Dim x As Single = eventArgs.X
		Dim Y As Single = eventArgs.Y
		Dim eX, edscrpos, enem, eY As Integer
		ScreenPicX = VWidth(CInt(x), 0, 255)
		ScreenPicY = VWidth(CInt(Y), 0, 255)

		If GetCfg("enemed_scrstealfocus") = 1 Then ScreenPic.Focus()
		If Button = 1 Then
			ScreenPic_MouseDown(ScreenPic, New System.Windows.Forms.MouseEventArgs(Button * &H100000, 0, x, Y, 0))
		Else
			edscrpos = 0
			For enem = 0 To offs(gem, 19)
				If romdat(arrayAdjuster + offs(gem, 11) + enem) > edscrpos Then edscrpos = romdat(arrayAdjuster + offs(gem, 11) + enem)
				If romdat(arrayAdjuster + offs(gem, 11) + enem) < edscrpos Then GoTo sprfindS
				If romdat(arrayAdjuster + offs(gem, 11) + enem) = curscreen Then
					eX = romdat(arrayAdjuster + offs(gem, 12) + enem)
					eY = romdat(arrayAdjuster + offs(gem, 13) + enem)
					If eX >= x - 8 And eX <= x + 8 And eY >= Y - 8 And eY <= Y + 8 Then
						curenem = enem
						EnemDatWrite()
						Exit Sub
					End If
				End If
sprfindS:
			Next enem
		End If
	End Sub

	Private Sub PalPic_MouseUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles PalPic.MouseUp
		Dim Button As Short = eventArgs.Button \ &H100000
		Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
		Dim x As Single = eventArgs.X
		Dim Y As Single = eventArgs.Y
		Dim a, oldsprpal As Integer
		'Dim enemset
		'enemset = Asc(mid$(romdat, offs(gem, o_ddA) + (curscroll * 2) + 0, 1))
		oldsprpal = cursprpal
		cursprpal = VWidth(Int(x / 128), 0, 1)
		If cursprcol + (oldsprpal * 4) = Int(x / 32) And cursprcol > 0 Then
			If gem = 3 Then
				a = MFLE_Main.GetMM6Col(&H18S + (cursprpal * 4) + cursprcol)
				If Button = 1 Then
					If a = &H3FS Then a = 0 Else a += 1
				Else
					If a = 0 Then a = &H3FS Else a -= 1
				End If
				MFLE_Main.SetMM6Col((&H18S + (cursprpal * 4) + cursprcol), a)
				glob_pal(cursprcol + (cursprpal * 4) + &H48S) = NESPAL(MFLE_Main.GetMM6Col(&H18S + (cursprpal * 4) + cursprcol))
				PPU_palette_val(cursprcol + (cursprpal * 4) + &H18S) = MFLE_Main.GetMM6Col(&H18S + (cursprpal * 4) + cursprcol)
			Else
				If Button = 1 Then
					romdat(arrayAdjuster + sprpaloff((cursprpal * 4) + cursprcol)) = (romdat(arrayAdjuster + sprpaloff((cursprpal * 4) + cursprcol)) + 1)
					If romdat(arrayAdjuster + sprpaloff((cursprpal * 4) + cursprcol)) = &H40S Then romdat(arrayAdjuster + sprpaloff((cursprpal * 4) + cursprcol)) = &H0S
					'mid$(romdat, offs(gem, 27) + (enemset * 8) + (cursprpal * 4) + cursprcol) = chr$(Asc(mid$(romdat, offs(gem, 27) + (enemset * 8) + (cursprpal * 4) + cursprcol, 1)) + 1)
					'If Asc(mid$(romdat, offs(gem, 27) + (enemset * 8) + (cursprpal * 4) + cursprcol, 1)) = &H40 Then mid$(romdat, offs(gem, 27) + (enemset * 8) + (cursprpal * 4) + cursprcol) = chr$(&H0)
				Else
					If romdat(arrayAdjuster + sprpaloff((cursprpal * 4) + cursprcol)) = 0 Then romdat(arrayAdjuster + sprpaloff((cursprpal * 4) + cursprcol)) = &H40S
					romdat(arrayAdjuster + sprpaloff((cursprpal * 4) + cursprcol)) = (romdat(arrayAdjuster + sprpaloff((cursprpal * 4) + cursprcol)) - 1)
				End If
				glob_pal(cursprcol + (cursprpal * 4) + &H48S) = NESPAL(romdat(arrayAdjuster + sprpaloff((cursprpal * 4) + cursprcol)))
				PPU_palette_val(cursprcol + (cursprpal * 4) + &H18S) = romdat(arrayAdjuster + sprpaloff((cursprpal * 4) + cursprcol))
			End If
			MFLE_Main.Update_Global_Pal(False) 'Dont refresh everywhere.
			RenderModule.RenderPic(ScreenPic, enem_scr_bmi)
			RenderModule.RenderPic(TilePic, enem_tile_bmi)
		End If
		cursprcol = Int(x / 32) - (cursprpal * 4)
		If cursprcol > 3 Then cursprcol = 3
		CurSprColSet()
		RenderModule.RenderPic(PalPic, enem_pal_bmi)
		If oldsprpal <> cursprpal Then DrawSprTiles() : RenderModule.RenderPic(TilePic, enem_tile_bmi)
		palchartClaim = Palchart_Claim.EnemEd
	End Sub

	Private Sub EffprColPic_MouseUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles _EffSprColPic_3.MouseUp, _EffSprColPic_2.MouseUp, _EffSprColPic_1.MouseUp
		Dim Button As Short = eventArgs.Button \ &H100000
		Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
		Dim Index As Short = 0

		For Each pictureBox As PictureBox In EffSprColPic
			If pictureBox.Name = eventSender.Name Then
				Exit For
			End If
			Index += 1
		Next

		Dim a, b As Integer
		If EffSprColTB(Index).Tag <> "" Then Exit Sub
		a = romdat(arrayAdjuster + offs(gem, 14) + curenem) And &H3FS
		Select Case gem
			Case 1 : b = romdat(arrayAdjuster + rdata(dspa(d_ex) + 9) + a) And &H7FS
				Select Case Button
					Case 1 : romdat(arrayAdjuster + rdata(dspa(d_ex) + 10) + (b * 4) + Index) = VWidth(romdat(arrayAdjuster + rdata(dspa(d_ex) + 10) + (b * 4) + Index) + 1, 0, &H3FS)
					Case 2 : romdat(arrayAdjuster + rdata(dspa(d_ex) + 10) + (b * 4) + Index) = VWidth(romdat(arrayAdjuster + rdata(dspa(d_ex) + 10) + (b * 4) + Index) - 1, 0, &H3FS)
				End Select
				EffSprColPic(Index).BackColor = System.Drawing.ColorTranslator.FromOle(RGBmirr(NESPAL(romdat(arrayAdjuster + rdata(dspa(d_ex) + 10) + (b * 4) + Index))))
				SetTBCoolText(EffSprColTB(Index), Hex(romdat(arrayAdjuster + rdata(dspa(d_ex) + 10) + (b * 4) + Index)))

			Case 2 : b = romdat(arrayAdjuster + rdata(dspa(d_ex) + 13) + a) And &H7FS
				Select Case Button
					Case 1 : romdat(arrayAdjuster + rdata(dspa(d_ex) + 15) + (b * 4) + Index) = VWidth(romdat(arrayAdjuster + rdata(dspa(d_ex) + 15) + (b * 4) + Index) + 1, 0, &H3FS)
					Case 2 : romdat(arrayAdjuster + rdata(dspa(d_ex) + 15) + (b * 4) + Index) = VWidth(romdat(arrayAdjuster + rdata(dspa(d_ex) + 15) + (b * 4) + Index) - 1, 0, &H3FS)
				End Select
				EffSprColPic(Index).BackColor = System.Drawing.ColorTranslator.FromOle(RGBmirr(NESPAL(romdat(arrayAdjuster + rdata(dspa(d_ex) + 15) + (b * 4) + Index))))
				SetTBCoolText(EffSprColTB(Index), Hex(romdat(arrayAdjuster + rdata(dspa(d_ex) + 15) + (b * 4) + Index)))
		End Select
	End Sub

	Private Sub ScreenPic_MouseDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles ScreenPic.MouseDown
		Dim Button As Short = eventArgs.Button \ &H100000
		Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
		Dim x As Single = eventArgs.X
		Dim Y As Single = eventArgs.Y
		Dim a, b As Integer

		Select Case Button
			Case 1
				EnemDraw(1)
				Y = VWidth(CInt(Y), 0, 255)
				x = VWidth(CInt(x), 0, 255)
				romdat(arrayAdjuster + offs(gem, 13) + curenem) = Y
				romdat(arrayAdjuster + offs(gem, 12) + curenem) = x
				If curscreen <> romdat(arrayAdjuster + offs(gem, 11) + curenem) Then
					romdat(arrayAdjuster + offs(gem, 11) + curenem) = curscreen
					If GetCfg("auto_enemscrsort") = 1 Then EnemSortByScreen(curenem)
					If GetCfg("auto_scrsprsort") = 1 Then
						If (gem = 1) Or (gem = 2) Then UpdateScrSprOrder()
					End If
				End If
				If GetCfg("auto_enemxsort") = 1 Then EnemSortByX(curenem)
				EnemDraw(0)
				EnemDatWrite()
				RenderModule.RenderPic(ScreenPic, enem_scr_bmi)
			Case 2
				EnemDraw(1)
				'Bugfix 06-23-2008: Fix value overflows from causing crashes
				a = romdat(arrayAdjuster + offs(gem, 13) + curenem)
				b = VWidth(CShort(a And &HFCS) + (CShort(a And 2) * 2), 0, 255)
				romdat(arrayAdjuster + offs(gem, 13) + curenem) = b
				a = romdat(arrayAdjuster + offs(gem, 12) + curenem)
				b = VWidth(CShort(a And &HFCS) + (CShort(a And 2) * 2), 0, 255)
				romdat(arrayAdjuster + offs(gem, 12) + curenem) = b
				If curscreen <> romdat(arrayAdjuster + offs(gem, 11) + curenem) Then
					romdat(arrayAdjuster + offs(gem, 11) + curenem) = curscreen
					If GetCfg("auto_enemscrsort") = 1 Then EnemSortByScreen(curenem)
					If GetCfg("auto_scrsprsort") = 1 Then
						If (gem = 1) Or (gem = 2) Then UpdateScrSprOrder()
					End If
				End If
				If GetCfg("auto_enemxsort") = 1 Then EnemSortByX(curenem)
				EnemDraw(0)
				EnemDatWrite()
				RenderModule.RenderPic(ScreenPic, enem_scr_bmi)
			Case 4
				DelEnem()
		End Select
	End Sub

	Private Sub ScrnScroll_Scroll(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.ScrollEventArgs) Handles ScrnScroll.Scroll
		Select Case eventArgs.Type
			Case System.Windows.Forms.ScrollEventType.EndScroll
				ScrnScroll_Change(eventArgs.NewValue)
		End Select
	End Sub

	'NumericUpDown
	'================

	Private Sub CurEnemUD_ActionUponNewValue()
		If CurEnemUD_ValuePrevious = CurEnemUD.Value Then Exit Sub

		Dim a As Integer

		' Current enemy has to be stored in hex/decimal depending on choice that is made
		curenem = CurEnemUD.Value

		CurEnemUD_ValuePrevious = CurEnemUD.Value

		' Matrixz: fix 07-13-08: dont break program if enemy is over screen limit.
		a = romdat(arrayAdjuster + offs(gem, 11) + curenem)
		If (a <> curscreen) And (a <= offs(gem, o_scrmax)) Then
			curscreen = a
			MFLE_Main.Update_Scrn()
		End If

		' This is not actually to write data but to load data - it's all in one function
		EnemDatWrite()
	End Sub
	Private Sub CurEnemUD_KeyUp(sender As Object, e As KeyEventArgs) Handles CurEnemUD.KeyUp
		' Set new value (with validations)
		SetUDCool(CType(sender, NumericUpDown), sender.Text, If(sender.Hexadecimal, 2, 3))

		' When here, Value was validated
		CurEnemUD_ActionUponNewValue()
	End Sub
	Private Sub CurEnemUD_ValueChanged(sender As Object, e As EventArgs) Handles CurEnemUD.ValueChanged
		If UpdateUDCool(sender) Then
			' When here, Value was validated
			CurEnemUD_ActionUponNewValue()
		End If
	End Sub

	Private Sub TypeUD_ActionUponNewValue()
		If TypeUD.Tag <> "" Then Exit Sub
		If TypeUD_ValuePrevious = TypeUD.Value Then Exit Sub

		TypeUD_ValuePrevious = TypeUD.Value

		EnemDraw(1)
		romdat(arrayAdjuster + offs(gem, 14) + curenem) = TypeUD.Value
		If AutoSetCheck.CheckState = 1 Then FindGFX_Update()
		EnemDraw(0)
		EnemDatWrite()
		RenderModule.RenderPic(ScreenPic, enem_scr_bmi)
	End Sub
	Private Sub TypeUD_ValueChanged(sender As Object, e As EventArgs) Handles TypeUD.ValueChanged
		If UpdateUDCool(sender) Then
			' When here, Value was validated
			TypeUD_ActionUponNewValue()
		End If
	End Sub
	Private Sub TypeUD_KeyUp(sender As Object, e As KeyEventArgs) Handles TypeUD.KeyUp
		' Set new value (with validations)
		SetUDCool(CType(sender, NumericUpDown), sender.Text, 2)

		' When here, Value was validated
		TypeUD_ActionUponNewValue()
	End Sub

	Private Sub HPUD_ActionUponNewValue()
		If HPUD_ValuePrevious = HPUD.Value Then Exit Sub

		HPUD_ValuePrevious = HPUD.Value

		If gem = 3 Then
			romdat(arrayAdjuster + offs(gem, 63)) = (Dec((HPUD.Text)) And &HFFS Or &H0S)
		Else : romdat(arrayAdjuster + offs(gem, 63) + TypeUD.Value) = (Dec((HPUD.Text)) And &HFFS Or &H0S)
		End If
		EnemDraw(0)
		EnemDatWrite()
	End Sub

	Private Sub HPUD_ValueChanged(sender As Object, e As EventArgs) Handles HPUD.ValueChanged
		If UpdateUDCool(sender) Then
			' When here, Value was validated
			HPUD_ActionUponNewValue()
		End If
	End Sub

	Private Sub HPUD_KeyUp(sender As Object, e As KeyEventArgs) Handles HPUD.KeyUp
		' Set new value (with validations)
		SetUDCool(CType(sender, NumericUpDown), sender.Text, 2)

		' When here, Value was validated
		HPUD_ActionUponNewValue()
	End Sub

	Private Sub XUD_ActionUponNewValue()
		If XUD_ValuePrevious = XUD.Value Then Exit Sub

		XUD_ValuePrevious = XUD.Value

		EnemDraw(1)
		romdat(arrayAdjuster + offs(gem, 12) + curenem) = (Dec((XUD.Text)) And &HFFS)
		If GetCfg("auto_enemxsort") = 1 Then EnemSortByX(curenem)
		EnemDraw(0)
		EnemDatWrite()
		RenderModule.RenderPic(ScreenPic, enem_scr_bmi)
	End Sub

	Private Sub XUD_ValueChanged(sender As Object, e As EventArgs) Handles XUD.ValueChanged
		If UpdateUDCool(sender) Then
			' When here, Value was validated
			XUD_ActionUponNewValue()
		End If
	End Sub

	Private Sub XUD_KeyUp(sender As Object, e As KeyEventArgs) Handles XUD.KeyUp
		' Set new value (with validations)
		SetUDCool(CType(sender, NumericUpDown), sender.Text, 2)

		' When here, Value was validated
		XUD_ActionUponNewValue()
	End Sub

	Private Sub YUD_ActionUponNewValue()
		If YUD_ValuePrevious = YUD.Value Then Exit Sub

		YUD_ValuePrevious = YUD.Value

		EnemDraw(1)
		romdat(arrayAdjuster + offs(gem, 13) + curenem) = (Dec((YUD.Text)) And &HFFS)
		EnemDraw(0)
		EnemDatWrite()
		RenderModule.RenderPic(ScreenPic, enem_scr_bmi)
	End Sub

	Private Sub YUD_ValueChanged(sender As Object, e As EventArgs) Handles YUD.ValueChanged
		If UpdateUDCool(sender) Then
			' When here, Value was validated
			YUD_ActionUponNewValue()
		End If
	End Sub

	Private Sub YUD_KeyUp(sender As Object, e As KeyEventArgs) Handles YUD.KeyUp
		' Set new value (with validations)
		SetUDCool(CType(sender, NumericUpDown), sender.Text, 2)

		' When here, Value was validated
		YUD_ActionUponNewValue()
	End Sub

	Private Sub ScrUD_ActionUponNewValue()
		If ScrUD_ValuePrevious = ScrUD.Value Then Exit Sub

		ScrUD_ValuePrevious = ScrUD.Value

		Dim a, b As Integer
		a = romdat(arrayAdjuster + offs(gem, 11) + curenem)
		romdat(arrayAdjuster + offs(gem, 11) + curenem) = (Dec((ScrUD.Text)) And &HFFS)
		b = romdat(arrayAdjuster + offs(gem, 11) + curenem)
		'fix 07-13-08: no program break on set to value over screen limit.
		If b <= offs(gem, o_scrmax) Then
			curscreen = b
		End If
		If Not a = romdat(arrayAdjuster + offs(gem, 11) + curenem) Then
			If GetCfg("auto_enemscrsort") = 1 Then EnemSortByScreen(curenem)
			If GetCfg("auto_enemxsort") = 1 Then EnemSortByX(curenem)
			If GetCfg("auto_scrsprsort") = 1 Then
				If (gem = 1) Or (gem = 2) Then UpdateScrSprOrder()
			End If
			MFLE_Main.Update_Scrn()
		End If
	End Sub

	Private Sub ScrUD_ValueChanged(sender As Object, e As EventArgs) Handles ScrUD.ValueChanged
		If UpdateUDCool(sender) Then
			' When here, Value was validated
			ScrUD_ActionUponNewValue()
		End If
	End Sub

	Private Sub ScrUD_KeyUp(sender As Object, e As KeyEventArgs) Handles ScrUD.KeyUp
		' Set new value (with validations)
		SetUDCool(CType(sender, NumericUpDown), sender.Text, 2)

		' When here, Value was validated
		ScrUD_ActionUponNewValue()
	End Sub

	Private Sub ScrnPresUD_ActionUponNewValue()
		If ScrnPresUD_ValuePrevious = ScrnPresUD.Value Then Exit Sub

		ScrnPresUD_ValuePrevious = ScrnPresUD.Value

		If gem = 3 Then Exit Sub
		If ScrnPresUD.Tag = "" Then
			romdat(arrayAdjuster + offs(gem, 7) + curscreen) = ((ScrnPresUD.Value) And &HFFS)
			If romdat(arrayAdjuster + offs(gem, 7) + curscreen) > offs(gem, 17) Then romdat(arrayAdjuster + offs(gem, 7) + curscreen) = offs(gem, 17)
			MFLE_Main.Update_Scrn()
		End If
	End Sub

	Private Sub ScrnPresUD_ValueChanged(sender As Object, e As EventArgs) Handles ScrnPresUD.ValueChanged
		If UpdateUDCool(sender) Then
			' When here, Value was validated
			ScrnPresUD_ActionUponNewValue()
		End If
	End Sub

	Private Sub ScrnPresUD_KeyUp(sender As Object, e As KeyEventArgs) Handles ScrnPresUD.KeyUp
		' Set new value (with validations)
		SetUDCool(CType(sender, NumericUpDown), sender.Text, 2)

		' When here, Value was validated
		ScrnPresUD_ActionUponNewValue()
	End Sub

	Private Sub EnemDmgUD_ActionUponNewValue()
		If EnemDmgUD.Tag <> "" Then Exit Sub
		If EnemDmgUD_ValuePrevious = EnemDmgUD.Value Then Exit Sub

		EnemDmgUD_ValuePrevious = EnemDmgUD.Value

		Dim a As Integer
		If gem = 2 Then offs(gem, 64) = 230868 Else If gem = 1 Then offs(gem, 64) = 476196
		a = TypeUD.Value + (rdata(dspa(d_enemdmgoffs3 + gem) + TypeUD.Value))
		romdat(arrayAdjuster + offs(gem, 64) + a) = (Dec((EnemDmgUD.Text)) And &HFFS Or &H0S)
		If gem = 2 Then offs(gem, 64) = 2065 Else If gem = 1 Then offs(gem, 64) = 268049
		EnemDraw(0)
		EnemDatWrite()
	End Sub

	Private Sub EnemDmgUD_ValueChanged(sender As Object, e As EventArgs) Handles EnemDmgUD.ValueChanged
		If UpdateUDCool(sender) Then
			' When here, Value was validated
			EnemDmgUD_ActionUponNewValue()
		End If
	End Sub

	Private Sub EnemDmgUD_KeyUp(sender As Object, e As KeyEventArgs) Handles EnemDmgUD.KeyUp
		' Set new value (with validations)
		SetUDCool(CType(sender, NumericUpDown), sender.Text, 2)

		' When here, Value was validated
		EnemDmgUD_ActionUponNewValue()
	End Sub

	Private Sub WeaponDmgUD_ActionUponNewValue()
		If WeaponDmgUD.Tag <> "" Then GoTo checkboxcheck

		If WeaponDmgUD_ValuePrevious = WeaponDmgUD.Value Then Exit Sub

		WeaponDmgUD_ValuePrevious = WeaponDmgUD.Value

		Dim a, b As Integer
		Select Case gem
			Case 0 : a = TypeUD.Value + 256 + WeaponList.SelectedIndex * 256 + (rdata(dspa(d_enemdmgoffs3 + gem) + TypeUD.Value))
			Case 1 To 2 : b = WeaponList.SelectedIndex
				a = TypeUD.Value + (b * 8192) + (rdata(dspa(d_enemdmgoffs3 + gem) + TypeUD.Value))
		End Select
		romdat(arrayAdjuster + offs(gem, 64) + a) = (Dec((WeaponDmgUD.Text)) And &HFFS Or &H0S)
		EnemDraw(0)
		EnemDatWrite()
checkboxcheck:
		a = Dec(WeaponDmgUD.Text)
		Select Case a
			Case 0 : SettingsCheck(0).CheckState = System.Windows.Forms.CheckState.Checked : SettingsCheck(1).CheckState = System.Windows.Forms.CheckState.Unchecked
			Case 128 : If gem = 2 Then If WeaponList.SelectedIndex = 8 Then SettingsCheck(1).Text = "MM <-> Enemy Swap (MM5)" Else SettingsCheck(1).Text = "Weapon Dmg Null (MM5)"
			Case 1 To 255 : If gem = 1 Then If WeaponList.SelectedIndex = 12 Then SettingsCheck(1).Text = "Flash Stopper Freeze (MM4)" : SettingsCheck(1).CheckState = System.Windows.Forms.CheckState.Checked Else SettingsCheck(1).CheckState = System.Windows.Forms.CheckState.Unchecked
		End Select
		If gem = 0 Then If a = CDbl("88") Then If WeaponList.SelectedIndex = 7 Then SettingsCheck(1).CheckState = System.Windows.Forms.CheckState.Checked Else SettingsCheck(1).CheckState = System.Windows.Forms.CheckState.Unchecked Else SettingsCheck(1).CheckState = System.Windows.Forms.CheckState.Unchecked
		If gem = 2 Then If a = CDbl("128") Then SettingsCheck(1).CheckState = System.Windows.Forms.CheckState.Checked Else SettingsCheck(1).CheckState = System.Windows.Forms.CheckState.Unchecked
		If WeaponDmgUD.Text > "0" Then SettingsCheck(0).CheckState = System.Windows.Forms.CheckState.Unchecked
	End Sub

	Private Sub WeaponDmgUD_ValueChanged(sender As Object, e As EventArgs) Handles WeaponDmgUD.ValueChanged
		If UpdateUDCool(sender) Then
			' When here, Value was validated
			WeaponDmgUD_ActionUponNewValue()
		End If
	End Sub

	Private Sub WeaponDmgUD_KeyUp(sender As Object, e As KeyEventArgs) Handles WeaponDmgUD.KeyUp
		' Set new value (with validations)
		SetUDCool(CType(sender, NumericUpDown), sender.Text, 2)

		' When here, Value was validated
		WeaponDmgUD_ActionUponNewValue()
	End Sub

	Private Sub GFXSetUD_ActionUponNewValue()
		If GFXSetUD.Tag <> "" Then Exit Sub
		If GFXSetUD_ValuePrevious = GFXSetUD.Value Then Exit Sub

		GFXSetUD_ValuePrevious = GFXSetUD.Value

		EnemDraw(1)
		romdat(arrayAdjuster + offs(gem, o_ddA) + (curscroll * 2) + 0) = (Dec((GFXSetUD.Text)) And &HFFS)
		MFLE_Main.SprCHRPALSetup()
		EnemsetWrite()
		EnemDraw(0)
		RenderModule.RenderPic(ScreenPic, enem_scr_bmi)
	End Sub

	Private Sub GFXSetUD_ValueChanged(sender As Object, e As EventArgs) Handles GFXSetUD.ValueChanged
		If UpdateUDCool(sender) Then
			' When here, Value was validated
			GFXSetUD_ActionUponNewValue()
		End If
	End Sub

	Private Sub GFXSetUD_KeyUp(sender As Object, e As KeyEventArgs) Handles GFXSetUD.KeyUp
		' Set new value (with validations)
		SetUDCool(CType(sender, NumericUpDown), sender.Text, 2)

		' When here, Value was validated
		GFXSetUD_ActionUponNewValue()
	End Sub

	Private Sub Bank0UD_ActionUponNewValue()
		'Asc(mid$(romdat, rdata(dspa(d_ex) + 0) + (Asc(mid$(romdat, offs(gem, o_ddA) + (curscroll * 2) + 0, 1)) * 2), 1))
		If Bank0UD.Tag <> "" Then Exit Sub
		If Bank0UD_ValuePrevious = Bank0UD.Value Then Exit Sub

		Bank0UD_ValuePrevious = Bank0UD.Value

		EnemDraw(1)
		romdat(arrayAdjuster + rdata(dspa(d_ex) + 0) + (romdat(arrayAdjuster + offs(gem, o_ddA) + (curscroll * 2) + 0) * 2)) = (Dec((Bank0UD.Text)) And &HFFS)
		MFLE_Main.SprCHRPALSetup()
		EnemsetWrite()
		EnemDraw(0)
		RenderModule.RenderPic(ScreenPic, enem_scr_bmi)
	End Sub

	Private Sub Bank0UD_ValueChanged(sender As Object, e As EventArgs) Handles Bank0UD.ValueChanged
		If UpdateUDCool(sender) Then
			' When here, Value was validated
			Bank0UD_ActionUponNewValue()
		End If
	End Sub

	Private Sub Bank0UD_KeyUp(sender As Object, e As KeyEventArgs) Handles Bank0UD.KeyUp
		' Set new value (with validations)
		SetUDCool(CType(sender, NumericUpDown), sender.Text, 2)

		' When here, Value was validated
		Bank0UD_ActionUponNewValue()
	End Sub

	Private Sub Bank1UD_ActionUponNewValue()
		'Asc(mid$(romdat, rdata(dspa(d_ex) + 0) + (Asc(mid$(romdat, offs(gem, o_ddA) + (curscroll * 2) + 0, 1)) * 2), 1))
		If Bank1UD.Tag <> "" Then Exit Sub
		If Bank1UD_ValuePrevious = Bank1UD.Value Then Exit Sub

		Bank1UD_ValuePrevious = Bank1UD.Value

		EnemDraw(1)
		romdat(arrayAdjuster + rdata(dspa(d_ex) + 0) + (romdat(arrayAdjuster + offs(gem, o_ddA) + (curscroll * 2) + 0) * 2) + 1) = (Dec((Bank1UD.Text)) And &HFFS)
		MFLE_Main.SprCHRPALSetup()
		EnemsetWrite()
		EnemDraw(0)
		RenderModule.RenderPic(ScreenPic, enem_scr_bmi)
	End Sub

	Private Sub Bank1UD_ValueChanged(sender As Object, e As EventArgs) Handles Bank1UD.ValueChanged
		If UpdateUDCool(sender) Then
			' When here, Value was validated
			Bank1UD_ActionUponNewValue()
		End If
	End Sub

	Private Sub Bank1UD_KeyUp(sender As Object, e As KeyEventArgs) Handles Bank1UD.KeyUp
		' Set new value (with validations)
		SetUDCool(CType(sender, NumericUpDown), sender.Text, 2)

		' When here, Value was validated
		Bank1UD_ActionUponNewValue()
	End Sub

	Private Sub EffUD_ActionUponNewValue()
		If EffUD.Tag <> "" Then Exit Sub
		If EffUD_ValuePrevious = EffUD.Value Then Exit Sub

		EffUD_ValuePrevious = EffUD.Value

		'EnemDraw 1
		romdat(arrayAdjuster + offs(gem, o_ddB) + curscroll) = VWidth(Dec((EffUD.Text)), 0, rdata(dspa(d_ex) + 11))
		MFLE_Main.ScrollEffectLoad(curscroll) 'Asc(mid$(romdat, offs(gem, o_ddB) + curscroll, 1)),
		MFLE_Main.Update_Scrn()
		'EnemsetWrite
		'EnemDraw 0
		'MFX_Render.RenderPic ScreenPic, enem_scr_bmi
	End Sub

	Private Sub EffUD_ValueChanged(sender As Object, e As EventArgs) Handles EffUD.ValueChanged
		If UpdateUDCool(sender) Then
			' When here, Value was validated
			EffUD_ActionUponNewValue()
		End If
	End Sub

	Private Sub EffUD_KeyUp(sender As Object, e As KeyEventArgs) Handles EffUD.KeyUp
		' Set new value (with validations)
		SetUDCool(CType(sender, NumericUpDown), sender.Text, 2)

		' When here, Value was validated
		EffUD_ActionUponNewValue()
	End Sub

	Private Sub PalSetUD_ActionUponNewValue()
		If PalSetUD.Tag <> "" Then Exit Sub

		If PalSetUD_ValuePrevious = PalSetUD.Value Then Exit Sub

		PalSetUD_ValuePrevious = PalSetUD.Value

		Dim a As Integer
		a = romdat(arrayAdjuster + offs(gem, o_ddA) + curscroll)
		romdat(arrayAdjuster + offs(gem, o_ddA) + curscroll) = (CShort(a And &HC0S) + (VWidth((PalSetUD.Value), 0, rdata(dspa(d_ex) + 14))))
		MFLE_Main.SprCHRPALSetup()
		MFLE_Main.Update_PalSet()
	End Sub

	Private Sub PalSetUD_ValueChanged(sender As Object, e As EventArgs) Handles PalSetUD.ValueChanged
		If UpdateUDCool(sender) Then
			' When here, Value was validated
			PalSetUD_ActionUponNewValue()
		End If
	End Sub

	Private Sub PalSetUD_KeyUp(sender As Object, e As KeyEventArgs) Handles PalSetUD.KeyUp
		' Set new value (with validations)
		SetUDCool(CType(sender, NumericUpDown), sender.Text, 2)

		' When here, Value was validated
		PalSetUD_ActionUponNewValue()
	End Sub

	Private Sub BGPalUD_ActionUponNewValue()
		If BGPalUD.Tag <> "" Then Exit Sub

		If BGPalUD_ValuePrevious = BGPalUD.Value Then Exit Sub

		BGPalUD_ValuePrevious = BGPalUD.Value

		romdat(arrayAdjuster + sprpaloff(0)) = (romdat(arrayAdjuster + sprpaloff(0) And &H80S) + VWidth((BGPalUD.Value), 0, &H7FS))
		MFLE_Main.Update_PalSet()
	End Sub

	Private Sub BGPalUD_ValueChanged(sender As Object, e As EventArgs) Handles BGPalUD.ValueChanged
		If UpdateUDCool(sender) Then
			' When here, Value was validated
			BGPalUD_ActionUponNewValue()
		End If
	End Sub

	Private Sub BGPalUD_KeyUp(sender As Object, e As KeyEventArgs) Handles BGPalUD.KeyUp
		' Set new value (with validations)
		SetUDCool(CType(sender, NumericUpDown), sender.Text, 2)

		' When here, Value was validated
		BGPalUD_ActionUponNewValue()
	End Sub

	Private Sub EffSprUD_ActionUponNewValue(sender As Object)
		Dim Index As Short = 0

		For Each numericUpDown As NumericUpDown In EffSprUD
			If numericUpDown.Name = sender.Name Then
				Exit For
			End If
			Index += 1
		Next

		If EffSprUD(Index).Tag <> "" Then Exit Sub

		If EffSprUD_ValuePrevious(Index) = EffSprUD(Index).Value Then Exit Sub

		EffSprUD_ValuePrevious(Index) = EffSprUD(Index).Value



		Dim b, a, c As Integer

		a = romdat(arrayAdjuster + offs(gem, 14) + curenem) And &H3FS
		Select Case gem
			Case 1 : b = romdat(arrayAdjuster + rdata(dspa(d_ex) + 9) + a) And &H80S
				romdat(arrayAdjuster + rdata(dspa(d_ex) + 9) + a) = (b + VWidth(Dec(EffSprUD(Index).Text), 0, &H7FS))
			Case 2
				If (Index = 0) Or (Index = 1) Then
					b = romdat(arrayAdjuster + rdata(dspa(d_ex) + 13) + a) And &H80S
					romdat(arrayAdjuster + rdata(dspa(d_ex) + 13) + a) = (b + VWidth(Dec(EffSprUD(Index).Text), 0, &H7FS))
				End If
				If Index = 3 Then
					b = VWidth((Dec(EffSprUD(Index).Text) * 2) + &H10S, &H10S, &H7ES)
					romdat(arrayAdjuster + rdata(dspa(d_ex) + 12) + a) = b
				End If
				If Index >= 4 Then
					b = romdat(arrayAdjuster + rdata(dspa(d_ex) + 12) + a)
					c = Index And 1
					romdat(arrayAdjuster + rdata(dspa(d_ex) + 16) + b + c) = Dec(EffSprUD(Index).Text) And &HFFS
				End If
				If Index = 2 Then
					b = romdat(arrayAdjuster + rdata(dspa(d_ex) + 12) + a) And &H80S
					romdat(arrayAdjuster + rdata(dspa(d_ex) + 12) + a) = (b + VWidth(Dec(EffSprUD(Index).Text), 0, &H7S))
				End If
		End Select
		EnemDatWrite()
	End Sub

	Private Sub EffSprUD_ValueChanged(sender As Object, e As EventArgs) Handles _EffSprUD_5.ValueChanged, _EffSprUD_4.ValueChanged, _EffSprUD_3.ValueChanged, _EffSprUD_2.ValueChanged, _EffSprUD_1.ValueChanged, _EffSprUD_0.ValueChanged
		If UpdateUDCool(sender) Then
			' When here, Value was validated
			EffSprUD_ActionUponNewValue(sender)
		End If
	End Sub

	Private Sub EffSprUD_KeyUp(sender As Object, e As KeyEventArgs) Handles _EffSprUD_5.KeyUp, _EffSprUD_4.KeyUp, _EffSprUD_3.KeyUp, _EffSprUD_2.KeyUp, _EffSprUD_1.KeyUp, _EffSprUD_0.KeyUp
		' Set new value (with validations)
		If sender.Maximum >= 10 Then
			SetUDCool(CType(sender, NumericUpDown), sender.Text, 2)
		Else
			SetUDCool(CType(sender, NumericUpDown), sender.Text, 1)
		End If

		' When here, Value was validated
		EffSprUD_ActionUponNewValue(sender)
	End Sub




	'Sub-Functions
	'====================================================================================================================

	' Handle Screen Scroll Change
	Public Sub ScrnScroll_Change(ByVal newScrollValue As Integer)
		If ScrnScroll.Tag = "" Then
			curscreen = newScrollValue
			MFLE_Main.Update_Scrn()
		End If
	End Sub

	'Draw Enemy Sprites (All)
	Public Sub EnemDraw(clear As Integer)
		Dim edscrpos As Integer
		Dim enem As Integer
		edscrpos = 0
		For enem = 0 To offs(gem, 19)
			If romdat(arrayAdjuster + offs(gem, 11) + enem) > edscrpos Then edscrpos = romdat(arrayAdjuster + offs(gem, 11) + enem)
			If romdat(arrayAdjuster + offs(gem, 11) + enem) < edscrpos Then GoTo sprdrawS
			If romdat(arrayAdjuster + offs(gem, 11) + enem) = curscreen Then
				SngEnemDraw(enem, clear)
			End If
sprdrawS:
		Next enem

		If (clear = 0) And (gem = 2) Then
			DrawSprTiles()
			RenderModule.RenderPic(TilePic, enem_tile_bmi)
		End If

		' NO! This would change NumericUpDown values before their KeyUp event fires
		'If clear = 0 Then EnemDatWrite()
	End Sub

	'Draw Single Enemy Sprite
	Private Sub SngEnemDraw(ByRef enem As Integer, ByRef clear As Integer)
		Dim widthVal, Y, c, a, b, x, heightVal As Integer
		Dim frame, etype, spr, sprbank As Integer
		Dim eff_flag As Integer
		x = romdat(arrayAdjuster + offs(gem, 12) + enem)
		Y = romdat(arrayAdjuster + offs(gem, 13) + enem)
		etype = romdat(arrayAdjuster + offs(gem, 14) + enem)
		Dim foundflag As Integer
		Select Case gem
			Case 0
				'Mega Man 3
				spr = romdat(arrayAdjuster + rdata(dspa(d_ex) + dex_mm3_enemsprid) + etype)
				If spr And &H80S Then
					sprbank = 1
				Else
					sprbank = 0
					a = 0
					foundflag = False
					While ((rdata(dspa(93) + a) < &H100S) And (a < 256) And (foundflag = False))
						If etype = rdata(dspa(93) + a) Then
							sprbank = 2
							foundflag = True
						End If
						a += 1
					End While

					'If etype >= &H47 And etype <= &H4E Then sprbank = 2
					'If etype >= &H5E And etype <= &H5F Then sprbank = 2
					'If etype >= &H68 And etype <= &H6F Then sprbank = 2
					'If etype >= &H79 And etype <= &H89 Then sprbank = 2
				End If
				spr = spr And &H7FS
				frame = spranim_frame_reg(etype)
				MegaFLEX_Main.SpriteDraw(sprbank, spr, frame, x, Y, &H10S, enem_scr_bmi, enem_scrb_bmi, clear)

			Case 1
				'Mega Man 4
				spr = romdat(arrayAdjuster + offs(gem, 29) + etype)
				eff_flag = rdata(dspa(d_greenframe4) + etype)
				If etype >= &HC0S Or eff_flag = 1 Then
					Select Case clear
						Case 0
							a = Int(romdat(arrayAdjuster + rdata(dspa(d_ex) + 9) + CShort(etype And &H3FS)) / &H80S) + &H23S
							If eff_flag = 1 Then a = &H25S
							EnemDraw_DrawEffBox(clear, a, etype, Y, x)
						Case 1
							EnemDraw_DrawEffBox(clear, a, etype, Y, x)
					End Select
					Exit Sub
				End If
				If etype = 3 Then spr = &H14S
				If etype = &H30S Then spr = &H67S
				If etype = &H4FS Then spr = &HA9S
				If etype = &H73S Then spr = &H9ES
				If etype = &H79S Then spr = &H44S + level
				sprbank = romdat(arrayAdjuster + offs(gem, 30) + romdat(arrayAdjuster + offs(gem, 28) + etype))
				frame = spranim_frame_reg(etype)
				MegaFLEX_Main.SpriteDraw(sprbank, spr, frame, x, Y, &H10S, enem_scr_bmi, enem_scrb_bmi, clear)

			Case 2
				'Mega Man 5
				spr = romdat(arrayAdjuster + offs(gem, 29) + etype)
				eff_flag = rdata(dspa(d_greenframe5) + etype)
				If etype >= &HC0S Or eff_flag = 1 Then
					widthVal = enem_scr_bmi.Header.biWidth
					heightVal = enem_scr_bmi.Header.biHeight
					Select Case clear
						Case 0
							b = romdat(arrayAdjuster + rdata(dspa(d_ex) + 12) + CShort(etype And &H3FS))
							If b >= &H80S Then
								a = &H26S
							Else
								If b >= &H10S Then
									a = &H27S
								Else
									c = romdat(arrayAdjuster + rdata(dspa(d_ex) + 13) + CShort(etype And &H3FS))
									If c >= &H80S Then a = &H24S Else a = &H23S
								End If
							End If
							If eff_flag = 1 Then a = &H25S
							EnemDraw_DrawEffBox(clear, a, etype, Y, x)
						Case 1
							EnemDraw_DrawEffBox(clear, a, etype, Y, x)
					End Select
					Exit Sub
				End If
				sprbank = romdat(arrayAdjuster + offs(gem, 30) + romdat(arrayAdjuster + offs(gem, 28) + etype))
				frame = spranim_frame_reg(etype)
				MegaFLEX_Main.SpriteDraw(sprbank, spr, frame, x, Y, &H10S, enem_scr_bmi, enem_scrb_bmi, clear)

			Case 3
				'Mega Man 6
				eff_flag = 0
				If (etype = &H80S) Or (eff_flag = 1) Then
					widthVal = ScreenPic.Width * 15
					heightVal = ScreenPic.Height * 15
					Select Case clear
						Case 0
							a = &H25S
							EnemDraw_DrawEffBox(clear, a, etype, Y, x)
						Case 1
							EnemDraw_DrawEffBox(clear, a, etype, Y, x)
					End Select
					Exit Sub
				End If
				b = (romdat(arrayAdjuster + &H744DA + etype) * &H2000) + ((romdat(arrayAdjuster + &H743DA + etype) - &H80S) * &H100S) + romdat(arrayAdjuster + &H742DA + etype) + &H11S
				spr = romdat(arrayAdjuster + b - 6)
				sprbank = romdat(arrayAdjuster + offs(gem, 30) + Int(etype / &H10S))
				frame = spranim_frame_reg(etype)
				MegaFLEX_Main.SpriteDraw(sprbank, spr, frame, x, Y, &H10S, enem_scr_bmi, enem_scrb_bmi, clear)
		End Select
		'sprdrawS:
	End Sub

	Private Sub EnemDraw_DrawEffBox(ByRef clear As Integer, ByRef color As Integer, ByRef etype As Integer, ByRef Y As Integer, ByRef x As Integer)
		Dim widthVal, py, myVal, mx, px, heightVal As Integer
		widthVal = enem_scr_bmi.Header.biWidth
		heightVal = -enem_scr_bmi.Header.biHeight
		Select Case clear
			Case 0
				RenderModule.DrawRectangle(enem_scr_bmi, x, Y, x + 42, Y + 15, &H20S)
				RenderModule.DrawLineH(enem_scr_bmi, x, x + 42, Y, color)
				RenderModule.DrawLineH(enem_scr_bmi, x, x + 42, Y + 15, color)
				RenderModule.DrawLineV(enem_scr_bmi, x, Y + 1, Y + 14, color)
				RenderModule.DrawLineV(enem_scr_bmi, x + 42, Y + 1, Y + 14, color)
				For py = 0 To 4
					For px = 0 To 9
						For myVal = 0 To 1 : For mx = 0 To 1
								RenderModule.DrawPixel(enem_scr_bmi, (px * 2) + x + 3 + mx, (py * 2) + Y + 3 + myVal, &H20S + rdata(dspa(d_efflab) + (py * 10) + px) * 2)
								'enem_scr_bmi.bits((((py * 2) + y + 3 + my) * width) + (px * 2) + x + 3 + mx) = &H20 + rdata(dspa(d_efflab) + (py * 10) + px) * 2
								If px <= 2 Then
									RenderModule.DrawPixel(enem_scr_bmi, (px * 2) + x + &H1AS + mx, (py * 2) + Y + 3 + myVal, &H20S + rdata(dspa(d_minihex) + (Nibble(CByte(etype), 0) * 15) + (py * 3) + px) * 2)
									RenderModule.DrawPixel(enem_scr_bmi, (px * 2) + x + &H22S + mx, (py * 2) + Y + 3 + myVal, &H20S + rdata(dspa(d_minihex) + (Nibble(CByte(etype), 1) * 15) + (py * 3) + px) * 2)
									'enem_scr_bmi.bits((((py * 2) + y + 3 + my) * width) + (px * 2) + &H1A + x + mx) = &H20 + rdata(dspa(d_minihex) + (nibble(CByte(etype), 0) * 15) + (py * 3) + px) * 2
									'enem_scr_bmi.bits((((py * 2) + y + 3 + my) * width) + (px * 2) + &H22 + x + mx) = &H20 + rdata(dspa(d_minihex) + (nibble(CByte(etype), 1) * 15) + (py * 3) + px) * 2
								End If
							Next mx : Next myVal
					Next px
				Next py
			Case 1
				Dim pos As Integer

				For py = Y To (Y + 15)
					For px = x To (x + 42)
						If ((py * widthVal) + px) < (widthVal * heightVal) And ((py * widthVal) + px) > -1 Then
							pos = (py * widthVal) + px

							enem_scr_bmi.PalIDSave(pos, enem_scrb_bmi.bytesPal_ByPixelID(pos))
						End If
					Next px
				Next py
		End Select

		enem_scr_bmi.bytesRGB_UpdatedSinceLastRender = True
	End Sub

	Private Sub Spr_Anim_Handle_Advance(ByRef etype As Integer, ByRef frames As Integer, ByRef framelength As Integer)
		spranim_fc_reg(etype) = spranim_fc_reg(etype) + 1
		If spranim_fc_reg(etype) > framelength Then
			spranim_fc_reg(etype) = 0
			spranim_frame_reg(etype) = spranim_frame_reg(etype) + 1
			If spranim_frame_reg(etype) > frames Then
				spranim_frame_reg(etype) = 0
			End If
		End If
	End Sub

	Public Sub EnemDatWrite()
		Dim a As Object
		Dim b, c, Toggle As Integer
		If CurEnemUD.Hexadecimal Then
			SetUDCool(CurEnemUD, Hex(curenem), 2)
		Else
			SetUDCool(CurEnemUD, curenem, 3)
		End If
		SetUDCool(TypeUD, Hex(romdat(arrayAdjuster + offs(gem, 14) + curenem)), 2)
		If (rdata(dspa(d_enemdmgoffs3 + gem) + TypeUD.Value)) = 255 Then GoTo disablebuttons
		Toggle = True
		a = TypeUD.Value + (rdata(dspa(d_enemdmgoffs3 + gem) + TypeUD.Value))

		Select Case gem
			Case 0
				SetUDCool(EnemDmgUD, Hex(romdat(arrayAdjuster + offs(gem, 64) + a)), 2)
				SetUDCool(WeaponDmgUD, Hex(romdat(arrayAdjuster + offs(gem, 64) + a + 256 + WeaponList.SelectedIndex * 256)), 2)
			Case 1 : offs(gem, 64) = 476196
				SetUDCool(EnemDmgUD, Hex(romdat(arrayAdjuster + offs(gem, 64) + a)), 2)
				offs(gem, 64) = 268049
			Case 2 : offs(gem, 64) = 230868
				SetUDCool(EnemDmgUD, Hex(romdat(arrayAdjuster + offs(gem, 64) + a)), 2)
				offs(gem, 64) = 2065
		End Select
		Select Case gem
			Case 1 To 2 : b = WeaponList.SelectedIndex
				SetUDCool(WeaponDmgUD, Hex(romdat(arrayAdjuster + offs(gem, 64) + a + (b * 8192))), 2)
		End Select
		GoTo setbuttons

disablebuttons:
		Toggle = False

setbuttons:
		WeaponDmgUD.Enabled = Toggle
		EnemDmgUD.Enabled = Toggle
		WeaponList.Enabled = Toggle

		If gem = 3 Then
			a = Hex(romdat(arrayAdjuster + 476122 + (TypeUD.Value))) & Common.Right("00" & Hex(romdat(arrayAdjuster + 475866 + (TypeUD.Value))), 2)
			a = CDec("&H" & a)
			b = CDec(romdat(arrayAdjuster + 476378 + TypeUD.Value))
			offs(gem, 63) = (b * 8192) + 16 + a - 32769
			SetUDCool(HPUD, Hex(romdat(arrayAdjuster + offs(gem, 63))), 2)
		Else : SetUDCool(HPUD, Hex(romdat(arrayAdjuster + offs(gem, 63) + TypeUD.Value)), 2)
		End If


		If romdat(arrayAdjuster + offs(gem, 14) + curenem) <= offs(gem, 58) Then
			lblEnemyName.Text = SrcString(rdata(dspa(d_enames + gem) + romdat(arrayAdjuster + offs(gem, 14) + curenem)))
		Else
			lblEnemyName.Text = ""
		End If

		SetUDCool(XUD, Hex(romdat(arrayAdjuster + offs(gem, 12) + curenem)), 2)
		SetUDCool(YUD, Hex(romdat(arrayAdjuster + offs(gem, 13) + curenem)), 2)
		SetUDCool(ScrUD, Hex(romdat(arrayAdjuster + offs(gem, 11) + curenem)), 2)

		If gem = 0 Or gem = 3 Then Exit Sub

		'Effect Enemy/Sprite stuff here ---->

		Dim bankLo, bankHi As Integer
		If romdat(arrayAdjuster + offs(gem, 14) + curenem) >= &HC0S Then
			EffSprEdFrame.Visible = True
			Repaint_EffSprEd_Cols()

			Select Case gem
				Case 1
					EffSprTypeOpt(2).Enabled = False
					EffSprTypeOpt(3).Enabled = False

					a = romdat(arrayAdjuster + offs(gem, 14) + curenem) And &H3FS
					b = romdat(arrayAdjuster + rdata(dspa(d_ex) + 8) + a) And 3
					c = romdat(arrayAdjuster + rdata(dspa(d_ex) + 9) + a)
				Case 2
					a = romdat(arrayAdjuster + offs(gem, 14) + curenem) And &H3FS
					c = romdat(arrayAdjuster + rdata(dspa(d_ex) + 12) + a)
					If c >= &H80S Then GoTo mm5CHRSetup
					If c >= &H10S Then GoTo mm5CHRSwapSetup
					c = romdat(arrayAdjuster + rdata(dspa(d_ex) + 13) + a)
					If c >= &H80S Then
						b = romdat(arrayAdjuster + rdata(dspa(d_ex) + 12) + a) And 3
					Else
						b = romdat(arrayAdjuster + rdata(dspa(d_ex) + 12) + a) / 4
					End If
			End Select
			EffSprSlot(b).Checked = True
			GoTo PalSetup
mm5CHRSwapSetup:
			For a = 0 To 3
				EffSprSlot(a).Enabled = False
			Next a
			_EffSprUD_2.Enabled = False
			_EffSprUD_1.Enabled = False
			For a = 0 To (EffSprColPic.Length - 1)
				EffSprColPic(a).Enabled = False
				EffSprColTB(a).Enabled = False
			Next a
			_EffSprUD_0.Enabled = False
			SetUDCool(EffSprUD(0), 0, 2)
			SetUDCool(EffSprUD(1), 0, 2)
			SetUDCool(EffSprUD(2), 0, 2)

			SetOptCool(EffSprTypeOpt(3), True)
			SetUDCool(EffSprUD(3), Hex((c - &H10S) / 2), 2)
			_EffSprUD_3.Enabled = True
			_EffSprUD_4.Enabled = True
			_EffSprUD_5.Enabled = True
			TopLabel.Enabled = True
			BottomLabel.Enabled = True
			bankLo = romdat(arrayAdjuster + rdata(dspa(d_ex) + 16) + c + 0)
			bankHi = romdat(arrayAdjuster + rdata(dspa(d_ex) + 16) + c + 1)
			SetUDCool(EffSprUD(4), Hex(bankLo), 2)
			SetUDCool(EffSprUD(5), Hex(bankHi), 2)
			Exit Sub

mm5CHRSetup:
			For a = 0 To 3
				EffSprSlot(a).Enabled = False
			Next a
			SetOptCool(EffSprTypeOpt(2), True)
			_EffSprUD_0.Enabled = False
			_EffSprUD_1.Enabled = False
			_EffSprUD_2.Enabled = True
			SetUDCool(EffSprUD(0), 0, 2)
			SetUDCool(EffSprUD(1), 0, 2)
			SetUDCool(EffSprUD(2), (c And &H7FS), 2)
			For a = 0 To (EffSprColPic.Length - 1)
				EffSprColPic(a).Enabled = False
				EffSprColTB(a).Enabled = False
			Next a
			_EffSprUD_3.Enabled = False
			_EffSprUD_4.Enabled = False
			_EffSprUD_5.Enabled = False
			SetUDCool(EffSprUD(3), 0, 2)
			SetUDCool(EffSprUD(4), 0, 2)
			SetUDCool(EffSprUD(5), 0, 2)
			Exit Sub

PalSetup:
			For a = 0 To 3
				EffSprSlot(a).Enabled = True
			Next a
			If c >= &H80S Then
				SetOptCool(EffSprTypeOpt(0), True)
				SetUDCool(EffSprUD(0), Hex((c And &H7FS)), 2)
				SetUDCool(EffSprUD(1), 0, 2)
				SetUDCool(EffSprUD(2), 0, 2)
				SetUDCool(EffSprUD(3), 0, 2)
				SetUDCool(EffSprUD(4), 0, 2)
				SetUDCool(EffSprUD(5), 0, 2)
				_EffSprUD_0.Enabled = True
				_EffSprUD_1.Enabled = False
				_EffSprUD_2.Enabled = False
				_EffSprUD_3.Enabled = False
				_EffSprUD_4.Enabled = False
				_EffSprUD_5.Enabled = False
				TopLabel.Enabled = False
				BottomLabel.Enabled = False
				For a = 0 To (EffSprColPic.Length - 1)
					EffSprColPic(a).Enabled = False
					EffSprColTB(a).Enabled = False
				Next a
			Else
				SetOptCool(EffSprTypeOpt(1), True)
				SetUDCool(EffSprUD(1), Hex(c And &H7FS), 2)
				_EffSprUD_1.Enabled = True
				SetUDCool(EffSprUD(0), 0, 2)
				SetUDCool(EffSprUD(2), 0, 2)
				SetUDCool(EffSprUD(3), 0, 2)
				SetUDCool(EffSprUD(4), 0, 2)
				SetUDCool(EffSprUD(5), 0, 2)
				_EffSprUD_0.Enabled = False
				_EffSprUD_2.Enabled = False
				_EffSprUD_3.Enabled = False
				_EffSprUD_4.Enabled = False
				_EffSprUD_5.Enabled = False
				TopLabel.Enabled = False
				BottomLabel.Enabled = False
				For a = 0 To (EffSprColPic.Length - 1)
					EffSprColPic(a).Enabled = True
					EffSprColTB(a).Enabled = True
					Select Case gem
						Case 1
							EffSprColPic(a).BackColor = System.Drawing.ColorTranslator.FromOle(RGBmirr(NESPAL(romdat(arrayAdjuster + rdata(dspa(d_ex) + 10) + (c * 4) + a))))
							SetTBCoolText(EffSprColTB(a), Hex(romdat(arrayAdjuster + rdata(dspa(d_ex) + 10) + (c * 4) + a)))
						Case 2
							EffSprColPic(a).BackColor = System.Drawing.ColorTranslator.FromOle(RGBmirr(NESPAL(romdat(arrayAdjuster + rdata(dspa(d_ex) + 15) + (c * 4) + a))))
							SetTBCoolText(EffSprColTB(a), Hex(romdat(arrayAdjuster + rdata(dspa(d_ex) + 15) + (c * 4) + a)))
					End Select
				Next a
			End If
		Else
			EffSprEdFrame.Visible = False
		End If

	End Sub

	Private Sub Repaint_EffSprEd_Cols()
		Dim a As Integer
		Dim aMax As Integer = EffSprSlot.Length - 1
		For a = 0 To aMax
			EffSprSlot(a).ForeColor = System.Drawing.ColorTranslator.FromOle(RGBmirr(glob_pal((a * 4) + 1)))
			EffSprSlot(a).BackColor = System.Drawing.ColorTranslator.FromOle(RGBmirr(glob_pal((a * 4) + 2)))
		Next a
	End Sub


	Private Sub DelEnem()
		Dim enem, enemcount As Integer
		If gem < 3 Then
			EnemDraw(1)
			For enem = curenem To offs(gem, 19)
				romdat(arrayAdjuster + offs(gem, 11) + enem) = romdat(arrayAdjuster + offs(gem, 11) + enem + 1)
				romdat(arrayAdjuster + offs(gem, 12) + enem) = romdat(arrayAdjuster + offs(gem, 12) + enem + 1)
				romdat(arrayAdjuster + offs(gem, 13) + enem) = romdat(arrayAdjuster + offs(gem, 13) + enem + 1)
				romdat(arrayAdjuster + offs(gem, 14) + enem) = romdat(arrayAdjuster + offs(gem, 14) + enem + 1)
				If romdat(arrayAdjuster + offs(gem, 11) + enem) = &HFFS Then GoTo DelEnemDone
			Next enem
DelEnemDone:
			EnemDraw(0)
			EnemDatWrite()
			RenderModule.RenderPic(ScreenPic, enem_scr_bmi)
			If GetCfg("auto_scrsprsort") = 1 Then
				If (gem = 1) Or (gem = 2) Then UpdateScrSprOrder()
			End If
		Else
			EnemDraw(1)
			enemcount = romdat(arrayAdjuster + rdata(dspa(d_ex) + 34) + level)
			EnemDataBot.RemoveBytes(1 + curenem, 1)
			EnemDataBot.RemoveBytes(1 + enemcount + curenem, 1)
			EnemDataBot.RemoveBytes(1 + enemcount + enemcount + curenem, 1)
			EnemDataBot.RemoveBytes(1 + enemcount + enemcount + enemcount + curenem, 1)
			enemcount = VWidth(enemcount - 1, 0, &HFFS)
			romdat(arrayAdjuster + rdata(dspa(d_ex) + 34) + level) = enemcount
			offs(3, 11) = EnemDataBot.EntryROMPtr + 2
			offs(3, 12) = EnemDataBot.EntryROMPtr + enemcount + 3
			offs(3, 13) = EnemDataBot.EntryROMPtr + enemcount + enemcount + 4
			offs(3, 14) = EnemDataBot.EntryROMPtr + enemcount + enemcount + enemcount + 5
			offs(3, 19) = (enemcount - 1)
			EnemDraw(0)
			EnemDatWrite()
			RenderModule.RenderPic(ScreenPic, enem_scr_bmi)
		End If
	End Sub

	Private Sub InsEnem(Optional ByRef manual As Boolean = False, Optional ByRef x As Integer = 0, Optional ByRef Y As Integer = 0, Optional ByRef etype As Integer = 0)
		Dim enemend, clenem, enem, a, clenems, enemcount As Integer
		If gem < 3 Then
			For enem = 0 To offs(gem, 19) - 1
				If romdat(arrayAdjuster + offs(gem, 11) + enem) = &HFFS Then GoTo InsEnemFound
			Next enem
InsEnemFound:
			enemend = enem

			clenem = 0
			clenems = 0
			For a = 0 To enemend - 1
				If romdat(arrayAdjuster + offs(gem, 11) + a) >= clenems And romdat(arrayAdjuster + offs(gem, 11) + a) <= curscreen Then clenem = a + 1 : clenems = romdat(arrayAdjuster + offs(gem, 11) + a)
			Next a

			'enem = offs(gem, 19) - 1
			If clenem < enem Then
				Do
					romdat(arrayAdjuster + offs(gem, 11) + enem + 1) = romdat(arrayAdjuster + offs(gem, 11) + enem)
					romdat(arrayAdjuster + offs(gem, 12) + enem + 1) = romdat(arrayAdjuster + offs(gem, 12) + enem)
					romdat(arrayAdjuster + offs(gem, 13) + enem + 1) = romdat(arrayAdjuster + offs(gem, 13) + enem)
					romdat(arrayAdjuster + offs(gem, 14) + enem + 1) = romdat(arrayAdjuster + offs(gem, 14) + enem)
					enem -= 1
				Loop Until enem < clenem
			End If
			'mid$(romdat, offs(gem, 13) + curenem, 1) = mid$(romdat, offs(gem, 13) + enem, 1)

			romdat(arrayAdjuster + offs(gem, 11) + clenem) = curscreen
			If (manual = True) Then
				romdat(arrayAdjuster + offs(gem, 12) + clenem) = x
				romdat(arrayAdjuster + offs(gem, 13) + clenem) = Y
				romdat(arrayAdjuster + offs(gem, 14) + clenem) = etype
			Else
				romdat(arrayAdjuster + offs(gem, 12) + clenem) = ScreenPicX
				romdat(arrayAdjuster + offs(gem, 13) + clenem) = ScreenPicY
				romdat(arrayAdjuster + offs(gem, 14) + clenem) = 0
			End If

			curenem = clenem

			If GetCfg("auto_enemxsort") = 1 Then EnemSortByX(curenem)

			EnemDraw(0)
			EnemDatWrite()
			RenderModule.RenderPic(ScreenPic, enem_scr_bmi)

			If GetCfg("auto_scrsprsort") = 1 Then
				If (gem = 1) Or (gem = 2) Then UpdateScrSprOrder()
			End If
		Else
			enemcount = romdat(arrayAdjuster + rdata(dspa(d_ex) + 34) + level)
			'MsgBox Hex(EnemDataBot.GetByte(1 + enemcount))

			clenem = 0
			clenems = 0
			For a = 0 To enemcount - 1
				If romdat(arrayAdjuster + offs(gem, 11) + a) >= clenems And romdat(arrayAdjuster + offs(gem, 11) + a) <= curscreen Then
					clenem = a + 1
					clenems = romdat(arrayAdjuster + offs(gem, 11) + a)
				End If
			Next a

			'MsgBox Hex$(clenem)

			'fix 04-26-11
			EnemDataBot.InsertByte(1 + clenem, CByte(curscreen))
			EnemDataBot.InsertByte(3 + enemcount + clenem, CByte(ScreenPicX))
			EnemDataBot.InsertByte(5 + enemcount + enemcount + clenem, CByte(ScreenPicY))
			EnemDataBot.InsertByte(7 + enemcount + enemcount + enemcount + clenem, 0)

			'MsgBox Hex(EnemDataBot.GetByte(7 + enemcount + enemcount + enemcount + enemcount))

			enemcount = VWidth(enemcount + 1, 0, &HFFS)
			romdat(arrayAdjuster + rdata(dspa(d_ex) + 34) + level) = enemcount
			offs(3, 11) = EnemDataBot.EntryROMPtr + 2
			offs(3, 12) = EnemDataBot.EntryROMPtr + enemcount + 3
			offs(3, 13) = EnemDataBot.EntryROMPtr + enemcount + enemcount + 4
			offs(3, 14) = EnemDataBot.EntryROMPtr + enemcount + enemcount + enemcount + 5
			offs(3, 19) = (enemcount - 1)

			curenem = clenem

			If GetCfg("auto_enemxsort") = 1 Then EnemSortByX(curenem)

			EnemDraw(0)
			EnemDatWrite()
			RenderModule.RenderPic(ScreenPic, enem_scr_bmi)
		End If
	End Sub

	Private Sub EnemsetWrite()
		Dim enemset, b, a, c, x As Integer
		Select Case gem
			Case 0
				enemset = romdat(arrayAdjuster + offs(gem, o_ddA) + (curscroll * 2) + 0)

				SetUDCool(GFXSetUD, Hex(enemset), 2)
				SetUDCool(Bank0UD, Hex(romdat(arrayAdjuster + rdata(dspa(d_ex) + 0) + (enemset * 2))), 2)
				SetUDCool(Bank1UD, Hex(romdat(arrayAdjuster + rdata(dspa(d_ex) + 0) + (enemset * 2) + 1)), 2)

				GFXEnemList.Items.Clear()
				For x = 0 To &H8FS
					If rdata(dspa(d_echrb0) + x) = 0 And rdata(dspa(d_echrb1) + x) = 0 Then GoTo esw_next
					If romdat(arrayAdjuster + rdata(dspa(d_ex) + 0) + (enemset * 2)) = rdata(dspa(d_echrb0) + x) Or rdata(dspa(d_echrb0) + x) = 0 Then
						If romdat(arrayAdjuster + rdata(dspa(d_ex) + 0) + (enemset * 2) + 1) = rdata(dspa(d_echrb1) + x) Or rdata(dspa(d_echrb1) + x) = 0 Then
							GFXEnemList.Items.Add((Hex(x) & ": " & SrcString(rdata(dspa(d_enames + gem) + x))))
							GFXEnemListArray(GFXEnemList.Items.Count - 1) = x
						End If
					End If
esw_next:
					If romdat(arrayAdjuster + rdata(dspa(d_ex) + 0) + (enemset * 2) + 1) = rdata(dspa(d_echrb1x) + x) Then GFXEnemList.Items.Add(Hex(x))
				Next x

			Case 1
				SetUDCool(EffUD, Hex(romdat(arrayAdjuster + offs(gem, o_ddB) + curscroll)), 2)

				GFXEnemList.Items.Clear()
				b = romdat(arrayAdjuster + offs(gem, o_ddB) + curscroll)
				If b > rdata(dspa(d_ex) + 11) Then GoTo esw1_listaddend
				For a = 0 To &HFFS
					c = rdata(rdata(dspa(d_effenem4) + b) + a)
					If c = &HFFS Then GoTo esw1_listaddend
					GFXEnemList.Items.Add((Hex(c) & ": " & SrcString(rdata(dspa(d_enames + gem) + c))))
					GFXEnemListArray(GFXEnemList.Items.Count - 1) = c
				Next a
esw1_listaddend:
		End Select

		For x = 0 To 7
			RenderModule.DrawRectangle(enem_pal_bmi, (x * 32) + 2, 2, (x * 32) + 31, 31, x + &H48S)

		Next x

		enem_pal_bmi.bytesRGB_UpdatedSinceLastRender = True

		'List2.clear
		'For a = 0 To 7
		'List2.AddItem hex$((a + 8) * &H10) + ": " + hex$(chrmap(&H180 + (a * &H10)))
		'Next a

		CurSprColSet()

		DrawSprTiles()

		RenderModule.RenderPic(TilePic, enem_tile_bmi)
		RenderModule.RenderPic(PalPic, enem_pal_bmi)
	End Sub

	Private Sub CurSprColSet()
		Dim x As Integer
		For x = 0 To 7
			RenderModule.DrawLineH(enem_pal_bmi, (x * 32), (x * 32) + 33, 0, &H20S)
			RenderModule.DrawLineH(enem_pal_bmi, (x * 32), (x * 32) + 33, 1, &H20S)
			RenderModule.DrawLineH(enem_pal_bmi, (x * 32), (x * 32) + 33, 32, &H20S)
			RenderModule.DrawLineH(enem_pal_bmi, (x * 32), (x * 32) + 33, 33, &H20S)
			RenderModule.DrawLineV(enem_pal_bmi, (x * 32), 2, 31, &H20S)
			RenderModule.DrawLineV(enem_pal_bmi, (x * 32) + 1, 2, 31, &H20S)
			RenderModule.DrawLineV(enem_pal_bmi, (x * 32) + 32, 2, 31, &H20S)
			RenderModule.DrawLineV(enem_pal_bmi, (x * 32) + 33, 2, 31, &H20S)
		Next x

		RenderModule.DrawLineH(enem_pal_bmi, (cursprpal * 128), (cursprpal * 128) + 129, 0, &H21S)
		RenderModule.DrawLineH(enem_pal_bmi, (cursprpal * 128), (cursprpal * 128) + 129, 1, &H21S)
		RenderModule.DrawLineH(enem_pal_bmi, (cursprpal * 128), (cursprpal * 128) + 129, 32, &H21S)
		RenderModule.DrawLineH(enem_pal_bmi, (cursprpal * 128), (cursprpal * 128) + 129, 33, &H21S)
		RenderModule.DrawLineV(enem_pal_bmi, (cursprpal * 128), 2, 31, &H21S)
		RenderModule.DrawLineV(enem_pal_bmi, (cursprpal * 128) + 1, 2, 31, &H21S)
		RenderModule.DrawLineV(enem_pal_bmi, (cursprpal * 128) + 128, 2, 31, &H21S)
		RenderModule.DrawLineV(enem_pal_bmi, (cursprpal * 128) + 129, 2, 31, &H21S)

		RenderModule.DrawLineH(enem_pal_bmi, (cursprpal * 128) + (cursprcol * 32), (cursprpal * 128) + (cursprcol * 32) + 33, 0, &H22S)
		RenderModule.DrawLineH(enem_pal_bmi, (cursprpal * 128) + (cursprcol * 32), (cursprpal * 128) + (cursprcol * 32) + 33, 1, &H22S)
		RenderModule.DrawLineH(enem_pal_bmi, (cursprpal * 128) + (cursprcol * 32), (cursprpal * 128) + (cursprcol * 32) + 33, 32, &H22S)
		RenderModule.DrawLineH(enem_pal_bmi, (cursprpal * 128) + (cursprcol * 32), (cursprpal * 128) + (cursprcol * 32) + 33, 33, &H22S)
		RenderModule.DrawLineV(enem_pal_bmi, (cursprpal * 128) + (cursprcol * 32), 2, 31, &H22S)
		RenderModule.DrawLineV(enem_pal_bmi, (cursprpal * 128) + (cursprcol * 32) + 1, 2, 31, &H22S)
		RenderModule.DrawLineV(enem_pal_bmi, (cursprpal * 128) + (cursprcol * 32) + 32, 2, 31, &H22S)
		RenderModule.DrawLineV(enem_pal_bmi, (cursprpal * 128) + (cursprcol * 32) + 33, 2, 31, &H22S)

		enem_scr_bmi.bytesRGB_UpdatedSinceLastRender = True
	End Sub

	Private Sub DrawSprTiles()
		Dim Y, x As Integer
		For Y = 0 To 15
			For x = 0 To 15
				RenderModule.DrawTile(enem_tile_bmi, chrmap((Y * 16) + x + &H100S), cursprpal + &H12S, (x * 16), (Y * 16), romdat, 2)
			Next x
		Next Y
		enem_tile_bmi.bytesRGB_UpdatedSinceLastRender = True
	End Sub

	Private Sub ScreenDraw()
		'ScrnLab.Caption = Hex$(curscreen)
		Dim blocknum, blockY, strX, strY, strnum, blockX, tilepal As Integer
		Dim x, tilenum, tileY, tileX, Y, screen As Integer
		screen = MegaFLEX_Main.GetScreen
		For strY = 0 To 7
			For strX = 0 To 7
				If gem < 3 Then
					strnum = romdat(arrayAdjuster + offs(gem, 6) + (screen * 64) + ((strY * 8) + strX))
				Else
					strnum = romdat(arrayAdjuster + offs(gem, 6) + (screen * 8) + ((strY * 256) + strX))
				End If
				For blockY = 0 To 1
					For blockX = 0 To 1
						blocknum = romdat(arrayAdjuster + offs(gem, 5) + (strnum * 4) + ((blockY * 2) + blockX))
						tilepal = romdat(arrayAdjuster + offs(gem, 4) + blocknum) And 3
						For tileY = 0 To 1
							For tileX = 0 To 1
								tilenum = romdat(arrayAdjuster + offs(gem, 3) + (((tileY * 2) + tileX) * &H100S) + blocknum)
								Y = (((strY * 32) + blockY * 16) + tileY * 8)
								x = (((strX * 32) + blockX * 16) + tileX * 8)
								RenderModule.DrawTile(enem_scr_bmi, chrmap(tilenum), tilepal + &H4S, x, Y, romdat)
							Next tileX
						Next tileY
					Next blockX
				Next blockY
			Next strX
		Next strY
		Array.Copy(enem_scr_bmi.bytesPal_ByPixelID, enem_scrb_bmi.bytesPal_ByPixelID, enem_scr_bmi.bytesPal_ByPixelID.Length)
		Array.Copy(enem_scr_bmi.bytesRGB_ByPixelID, enem_scrb_bmi.bytesRGB_ByPixelID, enem_scr_bmi.bytesRGB_ByPixelID.Length)

		enem_scr_bmi.bytesRGB_UpdatedSinceLastRender = True
		enem_scrb_bmi.bytesRGB_UpdatedSinceLastRender = True
		'MFX_Render.RenderPic ScreenPic, enem_scr_bmi
	End Sub


	Private Sub EnemSortByScreen(ByRef enem As Integer)
		Dim b, a, c As Integer
		Dim d(2) As Integer
		d(0) = romdat(arrayAdjuster + offs(gem, 12) + enem)
		d(1) = romdat(arrayAdjuster + offs(gem, 13) + enem)
		d(2) = romdat(arrayAdjuster + offs(gem, 14) + enem)
		a = romdat(arrayAdjuster + offs(gem, 11) + enem)
		If enem > 0 Then
			If romdat(arrayAdjuster + offs(gem, 11) + enem - 1) > a Then GoTo seekback
			If romdat(arrayAdjuster + offs(gem, 11) + enem - 1) < a Then GoTo seekforward
			Exit Sub
		End If
seekforward:
		b = 0
seekforward_loop:
		If (enem + b) < offs(gem, 19) Then
			If romdat(arrayAdjuster + offs(gem, 11) + enem + 1 + b) < a Then b += 1 : GoTo seekforward_loop
		End If
		If b = 0 Then Exit Sub
		'b decides move width
		For c = 0 To (b - 1)
			romdat(arrayAdjuster + offs(gem, 11) + enem + c) = romdat(arrayAdjuster + offs(gem, 11) + enem + c + 1)
			romdat(arrayAdjuster + offs(gem, 12) + enem + c) = romdat(arrayAdjuster + offs(gem, 12) + enem + c + 1)
			romdat(arrayAdjuster + offs(gem, 13) + enem + c) = romdat(arrayAdjuster + offs(gem, 13) + enem + c + 1)
			romdat(arrayAdjuster + offs(gem, 14) + enem + c) = romdat(arrayAdjuster + offs(gem, 14) + enem + c + 1)
		Next c
		romdat(arrayAdjuster + offs(gem, 11) + enem + b) = a
		romdat(arrayAdjuster + offs(gem, 12) + enem + b) = d(0)
		romdat(arrayAdjuster + offs(gem, 13) + enem + b) = d(1)
		romdat(arrayAdjuster + offs(gem, 14) + enem + b) = d(2)
		curenem += b
		Exit Sub
seekback:
		b = 0
seekback_loop:
		If (enem - b) > 0 Then
			If romdat(arrayAdjuster + offs(gem, 11) + enem - 1 - b) > a Then b += 1 : GoTo seekback_loop
		End If
		If b = 0 Then Exit Sub
		For c = 0 To (b - 1)
			romdat(arrayAdjuster + offs(gem, 11) + enem - c) = romdat(arrayAdjuster + offs(gem, 11) + enem - c - 1)
			romdat(arrayAdjuster + offs(gem, 12) + enem - c) = romdat(arrayAdjuster + offs(gem, 12) + enem - c - 1)
			romdat(arrayAdjuster + offs(gem, 13) + enem - c) = romdat(arrayAdjuster + offs(gem, 13) + enem - c - 1)
			romdat(arrayAdjuster + offs(gem, 14) + enem - c) = romdat(arrayAdjuster + offs(gem, 14) + enem - c - 1)
		Next c
		romdat(arrayAdjuster + offs(gem, 11) + enem - b) = a
		romdat(arrayAdjuster + offs(gem, 12) + enem - b) = d(0)
		romdat(arrayAdjuster + offs(gem, 13) + enem - b) = d(1)
		romdat(arrayAdjuster + offs(gem, 14) + enem - b) = d(2)
		curenem -= b
	End Sub

	Private Sub EnemSortByX(ByRef enem As Integer)
		Dim c, a, b, e As Integer
		Dim d(1) As Integer
		a = romdat(arrayAdjuster + offs(gem, 12) + enem)
		e = romdat(arrayAdjuster + offs(gem, 11) + enem)
		d(0) = romdat(arrayAdjuster + offs(gem, 13) + enem)
		d(1) = romdat(arrayAdjuster + offs(gem, 14) + enem)
		If enem > 0 Then
			If romdat(arrayAdjuster + offs(gem, 11) + enem - 1) < e Then GoTo seekforward
			If romdat(arrayAdjuster + offs(gem, 12) + enem - 1) > a Then GoTo seekback
			If romdat(arrayAdjuster + offs(gem, 12) + enem - 1) < a Then GoTo seekforward
			Exit Sub
		End If
seekforward:
		b = 0
seekforward_loop:
		If (enem + b) < offs(gem, 19) Then
			If romdat(arrayAdjuster + offs(gem, 11) + enem + 1 + b) = e Then
				If romdat(arrayAdjuster + offs(gem, 12) + enem + 1 + b) < a Then b += 1 : GoTo seekforward_loop
			End If
		End If
		If b = 0 Then Exit Sub
		'b decides move width
		For c = 0 To (b - 1)
			romdat(arrayAdjuster + offs(gem, 11) + enem + c) = romdat(arrayAdjuster + offs(gem, 11) + enem + c + 1)
			romdat(arrayAdjuster + offs(gem, 12) + enem + c) = romdat(arrayAdjuster + offs(gem, 12) + enem + c + 1)
			romdat(arrayAdjuster + offs(gem, 13) + enem + c) = romdat(arrayAdjuster + offs(gem, 13) + enem + c + 1)
			romdat(arrayAdjuster + offs(gem, 14) + enem + c) = romdat(arrayAdjuster + offs(gem, 14) + enem + c + 1)
		Next c
		romdat(arrayAdjuster + offs(gem, 11) + enem + b) = e
		romdat(arrayAdjuster + offs(gem, 12) + enem + b) = a
		romdat(arrayAdjuster + offs(gem, 13) + enem + b) = d(0)
		romdat(arrayAdjuster + offs(gem, 14) + enem + b) = d(1)
		curenem += b
		Exit Sub
seekback:
		b = 0
seekback_loop:
		If (enem - b) > 0 Then
			If romdat(arrayAdjuster + offs(gem, 11) + enem - 1 - b) = e Then
				If romdat(arrayAdjuster + offs(gem, 12) + enem - 1 - b) > a Then b += 1 : GoTo seekback_loop
			End If
		End If
		If b = 0 Then Exit Sub
		For c = 0 To (b - 1)
			romdat(arrayAdjuster + offs(gem, 11) + enem - c) = romdat(arrayAdjuster + offs(gem, 11) + enem - c - 1)
			romdat(arrayAdjuster + offs(gem, 12) + enem - c) = romdat(arrayAdjuster + offs(gem, 12) + enem - c - 1)
			romdat(arrayAdjuster + offs(gem, 13) + enem - c) = romdat(arrayAdjuster + offs(gem, 13) + enem - c - 1)
			romdat(arrayAdjuster + offs(gem, 14) + enem - c) = romdat(arrayAdjuster + offs(gem, 14) + enem - c - 1)
		Next c
		romdat(arrayAdjuster + offs(gem, 11) + enem - b) = e
		romdat(arrayAdjuster + offs(gem, 12) + enem - b) = a
		romdat(arrayAdjuster + offs(gem, 13) + enem - b) = d(0)
		romdat(arrayAdjuster + offs(gem, 14) + enem - b) = d(1)
		curenem -= b
	End Sub

	Private Sub ScreenPic_Click(sender As Object, e As EventArgs) Handles ScreenPic.Click
		ScreenPic.Focus()
	End Sub

	Private Sub UpdateScrSprOrder()
		Dim d, a, c, e As Integer
		romdat(arrayAdjuster + offs(gem, 24) + 0) = 0
		d = 0
		For a = 0 To offs(gem, 19)
			c = romdat(arrayAdjuster + offs(gem, 11) + a)
			If c > offs(gem, 16) Then GoTo fill
			If c > d Then
				For e = (d + 1) To c
					romdat(arrayAdjuster + offs(gem, 24) + e) = a
				Next e
				d = c
			End If
		Next a
		a = offs(gem, 19)
fill:
		If GetCfg("scrsprsort_all") = 1 Then
			For e = (d + 1) To offs(gem, 16)
				romdat(arrayAdjuster + offs(gem, 24) + e) = a
			Next e
		End If
	End Sub

	'Find Graphics for Enemies, then redraw stuff
	Private Function FindGFX_Update() As Integer
		FindGFX_Update = 0

		Select Case gem
			Case 0
				romdat(arrayAdjuster + offs(gem, o_ddA) + (curscroll * 2) + 0) = FindGFX_Rtn()
				MFLE_Main.SprCHRPALSetup()
			Case 1
				romdat(arrayAdjuster + offs(gem, o_ddB) + curscroll) = FindGFX_Rtn()
				MFLE_Main.ScrollEffectLoad(curscroll)
		End Select
		EnemsetWrite()
	End Function

	'Find Graphics for Enemies.
	Private Function FindGFX_Rtn() As Integer
		Dim ookay, fspr, x, a, Y, lspr, anymatch As Integer

		FindGFX_Rtn = 0

		'find first sprite in ScrollMap
		For x = 0 To offs(gem, 19)
			If romdat(arrayAdjuster + offs(gem, 11) + x) >= curscroll_sscrn Then fspr = x : GoTo ffs_ok
		Next x
ffs_ok:
		For Y = x To offs(gem, 19)
			If romdat(arrayAdjuster + offs(gem, 11) + Y) >= nextscroll_sscrn Then lspr = Y - 1 : GoTo fls_ok
		Next Y
fls_ok:
		Dim loopCount As Integer
		Select Case gem
			Case 0
				For x = 0 To rdata(dspa(d_ex) + 1) : FGFXMap(x) = False : Next x
				For x = 0 To rdata(dspa(d_ex) + 1)
					If rdata(dspa(d_echrb0) + romdat(arrayAdjuster + offs(gem, 14) + fspr)) = romdat(arrayAdjuster + rdata(dspa(d_ex) + 0) + (x * 2) + 0) Then ookay = 1 Else ookay = 0
					If rdata(dspa(d_echrb0) + romdat(arrayAdjuster + offs(gem, 14) + fspr)) = 0 Then ookay = 1
					If ookay = 0 Then GoTo fgb_next
					If rdata(dspa(d_echrb1) + romdat(arrayAdjuster + offs(gem, 14) + fspr)) = romdat(arrayAdjuster + rdata(dspa(d_ex) + 0) + (x * 2) + 1) Then ookay = 1 Else ookay = 0
					If rdata(dspa(d_echrb1) + romdat(arrayAdjuster + offs(gem, 14) + fspr)) = 0 Then ookay = 1
					'If ookay = 1 Then GoTo fgb_good
fgb_next:
					If ookay = 1 Then FGFXMap(x) = True
				Next x
				'tstr = ""
				'For x = 0 To rdata(dspa(d_ex) + 1): If FGFXMap(x) = True Then tstr = tstr + "!" Else tstr = tstr + "."
				'Next x
fg_filtermore:
				fspr += 1
				If fspr > lspr Then GoTo fg_done
				anymatch = 0
				For x = 0 To rdata(dspa(d_ex) + 1) : tmpFGFXMap(x) = False : Next x
				For x = 0 To rdata(dspa(d_ex) + 1)
					If FGFXMap(x) = True Then
						If rdata(dspa(d_echrb0) + romdat(arrayAdjuster + offs(gem, 14) + fspr)) = romdat(arrayAdjuster + rdata(dspa(d_ex) + 0) + (x * 2) + 0) Then ookay = 1 Else ookay = 0
						If rdata(dspa(d_echrb0) + romdat(arrayAdjuster + offs(gem, 14) + fspr)) = 0 Then ookay = 1
						If ookay = 0 Then GoTo fgbn_next
						If rdata(dspa(d_echrb1) + romdat(arrayAdjuster + offs(gem, 14) + fspr)) = romdat(arrayAdjuster + rdata(dspa(d_ex) + 0) + (x * 2) + 1) Then ookay = 1 Else ookay = 0
						If rdata(dspa(d_echrb1) + romdat(arrayAdjuster + offs(gem, 14) + fspr)) = 0 Then ookay = 1
						If ookay = 1 Then anymatch = 1 : tmpFGFXMap(x) = True
					End If
fgbn_next:
				Next x
				If anymatch = 1 Then For x = 0 To rdata(dspa(d_ex) + 1) : FGFXMap(x) = tmpFGFXMap(x) : Next x
				GoTo fg_filtermore
fg_done:
				'tstr = ""
				'For x = 0 To rdata(dspa(d_ex) + 1): If FGFXMap(x) = True Then tstr = tstr + "!" Else tstr = tstr + "."
				'Next x
				loopCount = 0
				Y = romdat(arrayAdjuster + offs(gem, o_ddA) + (curscroll * 2) + 0) + 1
fg_browsewrap:
				For x = Y To rdata(dspa(d_ex) + 1)
					If FGFXMap(x) = True Then FindGFX_Rtn = x : Exit Function
					loopCount += 1
				Next x
				Y = 0
				If loopCount > rdata(dspa(d_ex) + 1) Then
					FindGFX_Rtn = romdat(arrayAdjuster + offs(gem, o_ddA) + (curscroll * 2) + 0)
					Exit Function
				End If
				GoTo fg_browsewrap
			Case 1
				For x = 0 To rdata(dspa(d_ex) + 11) : FGFXMap(x) = True : Next x
				'    anymatch = 0
				'    For X = 0 To rdata(dspa(d_ex) + 11): tmpFGFXMap(X) = False: Next X
				'    For X = 0 To rdata(dspa(d_ex) + 11)
				'    For a = 0 To &HFF
				'    If rdata(rdata(dspa(34) + X) + a) = &HFF Then GoTo fg1_loopdone
				'    If rdata(rdata(dspa(34) + X) + a) = Asc(mid$(romdat, offs(gem, 14) + fspr, 1)) Then anymatch = 1: tmpFGFXMap(X) = True
				'    Next a
				'fg1_loopdone:
				'    Next X
				'    If anymatch = 1 Then For X = 0 To rdata(dspa(d_ex) + 11): FGFXMap(X) = tmpFGFXMap(X): Next X
				'    'tstr = ""
				'    'For x = 0 To rdata(dspa(d_ex) + 1): If FGFXMap(x) = True Then tstr = tstr + "!" Else tstr = tstr + "."
				'    'Next x
fg1_filtermore:
				If fspr > lspr Then GoTo fg1_done
				anymatch = 0
				For x = 0 To rdata(dspa(d_ex) + 11) : tmpFGFXMap(x) = False : Next x
				For x = 0 To rdata(dspa(d_ex) + 11)
					If FGFXMap(x) = True Then
						For a = 0 To &HFFS
							If rdata(rdata(dspa(d_effenem4) + x) + a) = &HFFS Then GoTo fg1fm_loopdone
							If rdata(rdata(dspa(d_effenem4) + x) + a) = romdat(arrayAdjuster + offs(gem, 14) + fspr) Then anymatch = 1 : tmpFGFXMap(x) = True
						Next a
fg1fm_loopdone:
						'If ookay = 1 Then anymatch = 1: tmpFGFXMap(X) = True
					End If
				Next x
				If anymatch = 1 Then For x = 0 To rdata(dspa(d_ex) + 11) : FGFXMap(x) = tmpFGFXMap(x) : Next x
				fspr += 1 : GoTo fg1_filtermore
fg1_done:
				'tstr = ""
				'For x = 0 To rdata(dspa(d_ex) + 1): If FGFXMap(x) = True Then tstr = tstr + "!" Else tstr = tstr + "."
				'Next x
				a = 0
				Y = romdat(arrayAdjuster + offs(gem, o_ddB) + curscroll) + 1
fg1_browsewrap:
				For x = Y To rdata(dspa(d_ex) + 11)
					If FGFXMap(x) = True Then FindGFX_Rtn = x : Exit Function
					a += 1 : If a > rdata(dspa(d_ex) + 11) + 1 Then FindGFX_Rtn = 0 : Exit Function
				Next x
				Y = 0
				GoTo fg1_browsewrap
		End Select
	End Function
End Class