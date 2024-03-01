Option Explicit On
Friend Class MetametatileTable
	Inherits System.Windows.Forms.Form

	Private Sub Form_Initialize()
	End Sub

	Public Sub Manual_Init()
		'Fix 4-27-11: Fixes Black window on open.
		RenderModule.PB_Init(StrPic, str_bmi)
	End Sub

	Private Sub StrTable_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
		Dim KeyCode As Short = eventArgs.KeyCode
		Dim Shift As Short = eventArgs.KeyData \ &H10000
		MFLE_Main.Global_KeyDown(KeyCode, Shift)
	End Sub

	Public Sub UpdateFrm()
		Update_Level()
		'Update_BGPal 1
	End Sub

	Public Sub Update_RefreshAllBitmaps()
		Update_Level() ' Needs to be done for Mega Man 5 when changing screen
		RenderModule.RenderPic(StrPic, str_bmi)
	End Sub

	Public Sub Update_Level()
		Dim Y, blocknum, blockY, strY, strX, blockX, tilepal, x As Integer
		'Dim perftimeS, perftimeE, perftime

		'perftimeS = timeGetTime
		For strY = 0 To 15
			For strX = 0 To 15
				For blockY = 0 To 1
					For blockX = 0 To 1
						blocknum = romdat(arrayAdjuster + offs(gem, 5) + (((strY * 16) + strX) * 4) + ((blockY * 2) + blockX))
						tilepal = Nibble(romdat(arrayAdjuster + offs(gem, 4) + blocknum), 1) And 3
						Y = ((strY * 32) + blockY * 16)
						x = ((strX * 32) + blockX * 16)
						RenderModule.DrawTile(str_bmi, chrmap(romdat(arrayAdjuster + offs(gem, 3) + 0 + blocknum)), tilepal, x, Y, romdat)
						RenderModule.DrawTile(str_bmi, chrmap(romdat(arrayAdjuster + offs(gem, 3) + &H100S + blocknum)), tilepal, x + 8, Y, romdat)
						RenderModule.DrawTile(str_bmi, chrmap(romdat(arrayAdjuster + offs(gem, 3) + &H200S + blocknum)), tilepal, x, Y + 8, romdat)
						RenderModule.DrawTile(str_bmi, chrmap(romdat(arrayAdjuster + offs(gem, 3) + &H300S + blocknum)), tilepal, x + 8, Y + 8, romdat)
					Next blockX
				Next blockY
			Next strX
		Next strY
		DrawGrid()

		'Bitmap render performance check: Calc MS used to draw Structure Table.
		'perftimeE = timeGetTime
		'perftime = (perftimeE - perftimeS)
		'MsgBox CStr(perftime) + " ms used to draw Structure Table"

		str_bmi.bytesRGB_UpdatedSinceLastRender = True

		RenderModule.RenderPic(StrPic, str_bmi)
	End Sub

	Public Sub Update_Block(ByRef ublock As Integer)
		Dim Y, tileY, blocknum, blockY, strY, strX, blockX, tilepal, tileX, x As Integer
		'screen = Asc(mid$(romdat, (offs(gem, 7) + curscreen), 1))
		For strY = 0 To 15
			For strX = 0 To 15
				'strnum = Asc(mid$(romdat, (offs(gem, 6) + (screen * 64) + ((strY * 8) + strX)), 1))
				'strnum =
				For blockY = 0 To 1
					For blockX = 0 To 1
						blocknum = romdat(arrayAdjuster + offs(gem, 5) + (((strY * 16) + strX) * 4) + ((blockY * 2) + blockX))
						If Not blocknum = ublock Then GoTo skipblock
						tilepal = Nibble(romdat(arrayAdjuster + offs(gem, 4) + blocknum), 1) And 3
						Y = ((strY * 32) + blockY * 16)
						x = ((strX * 32) + blockX * 16)
						For tileY = 0 To 1
							For tileX = 0 To 1
								'tilenum =
								RenderModule.DrawTile(str_bmi, chrmap(romdat(arrayAdjuster + offs(gem, 3) + (((tileY * 2) + tileX) * &H100S) + blocknum)), tilepal, x + (tileX * 8), Y + (tileY * 8), romdat)
							Next tileX
						Next tileY
skipblock:
					Next blockX
				Next blockY
			Next strX
		Next strY
		DrawGrid()

		str_bmi.bytesRGB_UpdatedSinceLastRender = True
		RenderModule.RenderPic(StrPic, str_bmi)
	End Sub

	Public Sub Update_TileRange(ByRef min As Integer, ByRef max As Integer)
		Dim Y, tileY, tilepal, blockX, strX, strY, blockY, blocknum, tilenum, tileX, x As Integer
		For strY = 0 To 15
			For strX = 0 To 15
				For blockY = 0 To 1
					For blockX = 0 To 1
						blocknum = romdat(arrayAdjuster + offs(gem, 5) + (((strY * 16) + strX) * 4) + ((blockY * 2) + blockX))
						tilepal = Nibble(romdat(arrayAdjuster + offs(gem, 4) + blocknum), 1) And 3
						Y = ((strY * 32) + blockY * 16)
						x = ((strX * 32) + blockX * 16)
						For tileY = 0 To 1
							For tileX = 0 To 1
								tilenum = romdat(arrayAdjuster + offs(gem, 3) + (((tileY * 2) + tileX) * &H100S) + blocknum)
								If tilenum >= min And tilenum <= max Then RenderModule.DrawTile(str_bmi, chrmap(romdat(arrayAdjuster + offs(gem, 3) + (((tileY * 2) + tileX) * &H100S) + blocknum)), tilepal, x + (tileX * 8), Y + (tileY * 8), romdat)
							Next tileX
						Next tileY
					Next blockX
				Next blockY
			Next strX
		Next strY
		DrawGrid()

		str_bmi.bytesRGB_UpdatedSinceLastRender = True
		RenderModule.RenderPic(StrPic, str_bmi)
	End Sub

	Public Sub Update_BGPal(ByRef upd As Integer)
		If upd Then RenderModule.RenderPic(StrPic, str_bmi)
	End Sub

	Private Sub DrawGrid()
		Dim a, b As Integer
		For a = 0 To 15
			For b = 0 To 15
				RenderModule.DrawLineH(str_bmi, (b * 32), (b * 32) + 31, (a * 32), &H20S)
				RenderModule.DrawLineV(str_bmi, (b * 32), (a * 32), (a * 32) + 31, &H20S)
			Next b
		Next a

		str_bmi.bytesRGB_UpdatedSinceLastRender = True

		CurStrSet(0)
	End Sub

	Public Sub CurStrSet(ByRef upd As Integer)
		RenderModule.DrawLineH(str_bmi, (oldstrX * 32), (oldstrX * 32) + 31, (oldstrY * 32), &H20S)
		RenderModule.DrawLineV(str_bmi, (oldstrX * 32), (oldstrY * 32), (oldstrY * 32) + 32, &H20S)
		RenderModule.DrawLineH(str_bmi, (oldstrX * 32), (oldstrX * 32) + 31, (oldstrY * 32) + 32, &H20S)
		RenderModule.DrawLineV(str_bmi, (oldstrX * 32) + 32, (oldstrY * 32), (oldstrY * 32) + 32, &H20S)

		RenderModule.DrawLineH(str_bmi, (curstrX * 32), (curstrX * 32) + 31, (curstrY * 32), &H22S)
		RenderModule.DrawLineV(str_bmi, (curstrX * 32), (curstrY * 32), (curstrY * 32) + 32, &H22S)
		RenderModule.DrawLineH(str_bmi, (curstrX * 32), (curstrX * 32) + 31, (curstrY * 32) + 32, &H22S)
		RenderModule.DrawLineV(str_bmi, (curstrX * 32) + 32, (curstrY * 32), (curstrY * 32) + 32, &H22S)

		str_bmi.bytesRGB_UpdatedSinceLastRender = True
		If upd Then RenderModule.RenderPic(StrPic, str_bmi)
	End Sub

	Private Sub StrPic_MouseDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles StrPic.MouseDown
		Dim Button As Short = eventArgs.Button \ &H100000
		Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
		Dim x As Single = eventArgs.X
		Dim Y As Single = eventArgs.Y
		Dim tileY, d, b, a, c, blocknum, tileX As Integer
		If Button And 1 Then
			oldstrY = curstrY
			oldstrX = curstrX
			curstrY = VWidth(Int(Y / 32), 0, &HFS)
			curstrX = VWidth(Int(x / 32), 0, &HFS)
			MFLE_Main.Update_CurStr()
			'CurStrSet 1
		End If
		Dim tsa As Integer
		If Button And (2 + 4) Then
			If x < 0 Then x = 0 Else If x >= 512 Then x = 511
			If Y < 0 Then Y = 0 Else If Y >= 512 Then Y = 511
			a = Int(Y / 32)
			b = Int(x / 32)
			c = (Int(Y / 16) And 1)
			d = (Int(x / 16) And 1)
			If Button And 2 Then
				romdat(arrayAdjuster + offs(gem, 5) + (((a * 16) + b) * 4) + ((c * 2) + d)) = CalcTSA()
				blocknum = romdat(arrayAdjuster + offs(gem, 5) + (((a * 16) + b) * 4) + ((c * 2) + d))
				For tileY = 0 To 1
					For tileX = 0 To 1
						RenderModule.DrawTile(str_bmi, chrmap(romdat(arrayAdjuster + offs(gem, 3) + (((tileY * 2) + tileX) * &H100S) + blocknum)), Nibble(romdat(arrayAdjuster + offs(gem, 4) + blocknum), 1), (b * 32) + (d * 16) + (tileX * 8), (a * 32) + (c * 16) + (tileY * 8), romdat)
					Next tileX
				Next tileY
				CurStrSet(1)
				MFLE_Main.Update_StrBlock((a * 16) + b, (c * 2) + d)
			Else
				'Middle mouse button
				tsa = romdat(arrayAdjuster + offs(gem, 5) + (((a * 16) + b) * 4) + ((c * 2) + d))
				SetCurTSA(tsa)
			End If
		End If
		str_bmi.bytesRGB_UpdatedSinceLastRender = True
	End Sub

	Private Sub StrPic_MouseMove(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles StrPic.MouseMove
		Dim Button As Short = eventArgs.Button \ &H100000
		Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
		Dim x As Single = eventArgs.X
		Dim Y As Single = eventArgs.Y
		Dim tileY, tileX As Integer
		If Button = 1 Then StrPic_MouseDown(StrPic, New System.Windows.Forms.MouseEventArgs(Button * &H100000, 0, x, Y, 0))
		If Button = 2 Then
			If (Int(Y / 8) And 1) <> tileY Then GoTo settile
			If (Int(x / 8) And 1) <> tileX Then GoTo settile
		End If
settile:
		StrPic_MouseDown(StrPic, New System.Windows.Forms.MouseEventArgs(Button * &H100000, 0, x, Y, 0))
	End Sub

	Public Sub ClearUnusedMetametatiles()
		Dim a, scr, scrMax As Integer
		Dim tmp_metametatilemap(&HFFS) As Byte

		scrMax = offs(gem, 17)

		For a = 0 To &HFFS
			tmp_metametatilemap(a) = 0 'Not used (clear status)
		Next a

		For scr = 0 To scrMax
			For a = 0 To &H3FS
				tmp_metametatilemap(romdat(arrayAdjuster + offs(gem, o_scrp) + a + (scr * &H40S))) = 1
			Next a
		Next

		For a = 0 To &HFFS
			If tmp_metametatilemap(a) = 0 Then
				' So loop through every Metametatile's Metatile
				For b = 0 To 3
					romdat(arrayAdjuster + offs(gem, o_str) + (a * 4) + b) = 0
				Next b
			End If
		Next a
	End Sub

	Private Sub BtnClearUnusedMetametatiles_Click(sender As Object, e As EventArgs) Handles BtnClearUnusedMetametatiles.Click
		ClearUnusedMetametatiles()
		If Me.Visible = True Then Me.Update_Level()
	End Sub

	Private Sub StrTable_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
		e.Cancel = True

		Me.Hide()
	End Sub

	Private Sub BtnShowSelected_Click(sender As Object, e As EventArgs) Handles BtnShowSelected.Click
		Dim x As Integer
		Dim colorByte As Byte() = {&H20S, &H22S, &H26S, &H20S, &H22S, &H26S, &H20S, &H22S, &H26S}

		For x = 0 To (colorByte.Length - 1)
			RenderModule.DrawRectangle(str_bmi, (curstrX * 32), (curstrY * 32), (curstrX * 32) + 32, (curstrY * 32) + 32, colorByte(x))

			str_bmi.palette_UpdatedSinceLastBytesRGB_Update = True

			RenderModule.RenderPicAlwaysIfItWasChangedSinceLastupdate(StrPic, str_bmi)

			Threading.Thread.Sleep(100)
		Next

		' Reupdate form since we just fill current Metametatile's rectangle
		UpdateFrm()
	End Sub

	Public Sub ReplaceDuplicatedMetametatiles_ReplacingPart(scrMax As Integer, tmp_metametatilesmapDuplicateStatus As Byte(), tmp_metametatilesmapID_OfIdenticalTile As Byte())
		Dim scr As Integer

		' Loop through all array entry and stop on Metametatiles that are duplicate
		For a = 0 To &HFFS
			If tmp_metametatilesmapDuplicateStatus(a) = 1 Then
				' A duplicate Metametatile! We don't clear it in current function, but we will make it unused
				'	So after this current function call, calling function that clear unused Metametatiles will clear them
				' So find everywhere current Metametatile is used (check every Screen Layouts)
				'	and, in those Screen Layouts, use instead, the Reference Metametatile we defined above
				' So loop through every Screen Layouts
				For scr = 0 To scrMax
					' Then through every Metametatile within current Screen
					For b = 0 To &H3FS
						' If current Metametatile is used
						If romdat(arrayAdjuster + offs(gem, o_scrp) + b + (scr * &H40S)) = a Then
							' Put the reference Metametatile instead
							romdat(arrayAdjuster + offs(gem, o_scrp) + b + (scr * &H40S)) = tmp_metametatilesmapID_OfIdenticalTile(a)
						End If
					Next b
				Next
			End If
		Next
	End Sub

	' All duplicated Metametatiles will be replaced by their first occurence
	Public Sub ReplaceDuplicatedMetametatiles(Optional optimiseScreenLayoutLowerMetametatiles As Boolean = False)
		Dim a, b, c, aMax, scrMax As Integer
		Dim isDuplicate
		Dim tmp_metametatilesmapDuplicateStatus(&HFFS) As Byte
		Dim tmp_metametatilesmapID_OfIdenticalTile(&HFFS) As Byte

		aMax = (&HFFS - 1)
		scrMax = offs(gem, 17)

		' Clear arrays

		For a = 0 To &HFFS
			tmp_metametatilesmapDuplicateStatus(a) = 0 ' Not duplicated (clear status)
			tmp_metametatilesmapID_OfIdenticalTile(a) = 0 ' Not a copy of any Metametatile ID for now
		Next a

		If optimiseScreenLayoutLowerMetametatiles Then
			' Only care 
		Else
			' Loop on Metametatile that will be the referenced Metametatile (that others are a copy of)
			For a = 0 To aMax
				' Loop on every following Metametatile
				For b = (a + 1) To &HFFS
					' If current Metametatile checked is not already a copy of another Tile
					If tmp_metametatilesmapDuplicateStatus(b) = 0 Then
						' Suppose Metametatile is a duplicate and we will adjust if not
						isDuplicate = True

						' Compare every Metatiles between both Metametatiles
						For c = 0 To 3
							If romdat(arrayAdjuster + offs(gem, o_str) + (b * 4) + c) <> romdat(arrayAdjuster + offs(gem, o_str) + (a * 4) + c) Then
								isDuplicate = False
								Exit For
							End If
						Next c

						If isDuplicate Then
							' If here, current Metametatile checked is identical to the one checked right now
							tmp_metametatilesmapDuplicateStatus(b) = 1
							tmp_metametatilesmapID_OfIdenticalTile(b) = a
						End If
					End If
				Next b
			Next a
		End If

		ReplaceDuplicatedMetametatiles_ReplacingPart(scrMax, tmp_metametatilesmapDuplicateStatus, tmp_metametatilesmapID_OfIdenticalTile)
	End Sub

	' Metatiles only used in Screen's Lowest lines of Metatiles will be replaced by Metatiles used elsewhere (than lowest lines of screen)
	'	when they can be replaced by one with which they share the 2 top Metatiles
	'	(since for Screen's lowest lines, Metametatile bottom Metatiles are never seen
	Public Sub ReplaceScreenLowerLineMetametatiles()
		Dim a, b, c, scr, scrMax, aboveLowestLineLastMetametatileID, atLowestLineLastMetametatileID As Integer
		Dim isDuplicate
		Dim tmp_metametatilesmapExistAboveLowerScreensLine(&HFFS) As Byte
		Dim tmp_metametatilesmapExistInLowerScreensLine(&HFFS) As Byte
		Dim tmp_metametatilesmapDuplicateStatus(&HFFS) As Byte
		Dim tmp_metametatilesmapID_OfIdenticalTile(&HFFS) As Byte

		atLowestLineLastMetametatileID = (&H3FS)
		aboveLowestLineLastMetametatileID = (&H3FS - &H8S)
		scrMax = offs(gem, 17)

		' Clear arrays

		For a = 0 To &HFFS
			tmp_metametatilesmapExistAboveLowerScreensLine(a) = 0
			tmp_metametatilesmapExistInLowerScreensLine(a) = 0
			tmp_metametatilesmapDuplicateStatus(a) = 0 ' Not duplicated (clear status)
			tmp_metametatilesmapID_OfIdenticalTile(a) = 0 ' Not a copy of any Metametatile ID for now
		Next a

		' Loop thourgh every Screen Layout and then every Metatiles, and tag for each Metametatiles 2 properties:
		'	Is it used above lowest line of screen at one point?
		'	Is it used at lowest line of screen at one point?
		For scr = 0 To scrMax
			' Loop through every Metametatiles above lowest Line
			For b = 0 To aboveLowestLineLastMetametatileID
				' Tag current Metametatile
				tmp_metametatilesmapExistAboveLowerScreensLine(romdat(arrayAdjuster + offs(gem, o_scrp) + b + (scr * &H40S))) = 1
			Next

			' Loop through every Metametatiles at lowest Line
			For b = b To atLowestLineLastMetametatileID
				' Tag current Metametatile
				tmp_metametatilesmapExistInLowerScreensLine(romdat(arrayAdjuster + offs(gem, o_scrp) + b + (scr * &H40S))) = 1
			Next
		Next

		' Loop through all Metametatiles
		For a = 0 To &HFFS
			' If Metametatile is one only used in lowest line
			If (tmp_metametatilesmapExistAboveLowerScreensLine(a) = 0 And tmp_metametatilesmapExistInLowerScreensLine(a) = 1) Then
				' Now need to find if a Metametatile existing in above screen could replace if
				For b = 0 To &HFFS
					' If Metametatile is one used above lowest line
					If (tmp_metametatilesmapExistAboveLowerScreensLine(b) = 1) Then
						' Suppose it is a duplicate unless it isn't
						isDuplicate = True

						' Now check if both Metametatiles DON'T have the same top Metatiles
						For c = 0 To 1
							If (romdat(arrayAdjuster + offs(gem, o_str) + (a * 4) + c) <> romdat(arrayAdjuster + offs(gem, o_str) + (b * 4) + c)) Then
								' Current Metametatile cannot be used as a duplicate
								isDuplicate = False
								Exit For
							End If
						Next

						' Now check if both Metametatiles have the same top Metatiles
						If (isDuplicate) Then
							' Metametatile will be used for replacement
							tmp_metametatilesmapDuplicateStatus(a) = 1
							tmp_metametatilesmapID_OfIdenticalTile(a) = b

							Exit For
						End If
					End If
				Next b
			End If
		Next a

		' Now, check if any Lower Metametatile can be represented by another one that is a Lower Metametatile
		'	(If we could not find a Metametatile above lower line to replace it)
		For a = 0 To &HFFS
			' If Metametatile is one only used in lowest line
			If (tmp_metametatilesmapExistAboveLowerScreensLine(a) = 0 And tmp_metametatilesmapExistInLowerScreensLine(a) = 1) Then
				' If Metametatile hasn't found a duplicate one yet in the above line previously
				If tmp_metametatilesmapDuplicateStatus(a) = 0 Then
					' Now need to find if a Metametatile existing in screen lower line only could replace if
					For b = 0 To &HFFS
						' If Metametatile is one used at lowest line only (and is not current Metametatile)
						If ((a <> b) And (tmp_metametatilesmapExistAboveLowerScreensLine(b) = 0) And (tmp_metametatilesmapExistInLowerScreensLine(b) = 1)) Then
							' Suppose it is a duplicate unless it isn't
							isDuplicate = True

							' Now check if both Metametatiles DON'T have the same top Metatiles
							For c = 0 To 1
								If (romdat(arrayAdjuster + offs(gem, o_str) + (a * 4) + c) <> romdat(arrayAdjuster + offs(gem, o_str) + (b * 4) + c)) Then
									' Current Metametatile cannot be used as a duplicate
									isDuplicate = False
									Exit For
								End If
							Next

							' Now check if both Metametatiles have the same top Metatiles
							If (isDuplicate) Then
								' Metametatile will be used for replacement
								tmp_metametatilesmapDuplicateStatus(a) = 1
								tmp_metametatilesmapID_OfIdenticalTile(a) = b

								Exit For
							End If
						End If
					Next b
				End If
			End If
		Next a

		ReplaceDuplicatedMetametatiles_ReplacingPart(scrMax, tmp_metametatilesmapDuplicateStatus, tmp_metametatilesmapID_OfIdenticalTile)
	End Sub

	Private Sub BtnClearDuplicated_Click(sender As Object, e As EventArgs) Handles BtnClearDuplicated.Click
		ReplaceDuplicatedMetametatiles()
		BtnClearUnusedMetametatiles_Click(sender, e)
	End Sub

	Private Sub BtnOptimiseLowerMetametatilesUsage_Click(sender As Object, e As EventArgs) Handles BtnOptimiseLowerMetametatilesUsage.Click
		ReplaceScreenLowerLineMetametatiles()
		If ScreenEd.Visible = True Then ScreenEd.Update_Frm()
	End Sub
End Class