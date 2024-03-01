Option Explicit On
Friend Class MetatileTable
	Inherits System.Windows.Forms.Form

	Private MouseY, MouseX As Integer
	Private maskFilterPalettesChanged() As Integer = {&HF0S, &HFCS, 30, 40, 50}
	'Objects that group many items
	'   RadioButton
	Private rdGroupSetPaletteForTile() As RadioButton

	Private Structure CopyBufType
        Dim Type As Byte
        Dim pal As Byte
        <VBFixedArray(3)> Dim tile() As Byte

		Public Sub Initialize()
			ReDim tile(3)
		End Sub
	End Structure

	Private copyBuf As CopyBufType

	Private Sub Form_Initialize()
		'Objects that group many items
		' RadioButton
		rdGroupSetPaletteForTile = New RadioButton() {rdSetPaletteForTileAll, rdSetPaletteForTile1, rdSetPaletteForTile2, rdSetPaletteForTile3, rdSetPaletteForTile4}
	End Sub

	Public Sub Manual_Init()
		Dim a As Integer

		gbxSetPaletteForTile.Visible = MegaManEngineMode

		RenderModule.PB_Init(PalPic, tsat_pal_bmi)
		RenderModule.PB_Init(tsapic, tsat_bmi)

		'Note: This would cause "Invalid property value" errors in some cases.
		'Some of the games have random TSA Blocks with values greater than these settings,
		'which causes the editor to crash when they're clicked on.
		'(Megaman 3 Hardman's stage has some at the bottom of the table.)
		'So i set it back to load 16 entries for all games.

		'If gem = 0 Or gem = 2 Then b = 9
		'If gem = 1 Then b = 13
		'If gem = 3 Then b = 15
		For a = 0 To 15
			BlockTypeList.Items.Add(Hex(a) & ": " & SrcString(rdata(dspa(gem + d_blocktypes) + a)))
		Next a

		copyBuf.Initialize()

		If (GetCfg("onepalettepertile") = 1) Then
			chkPaletteForEachTile.Checked = True
		End If
	End Sub

	Private Sub TSATable_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs)
	End Sub

	Private Sub TSATable_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
		Dim KeyCode As Short = eventArgs.KeyCode
		Dim Shift As Short = eventArgs.KeyData \ &H10000
		MFLE_Main.Global_KeyDown(KeyCode, Shift)
	End Sub

	Public Sub Update_Frm()
		If GetCfg("tsatbl_2x") = 1 Then
			TSAScroll.Maximum = (3 + TSAScroll.LargeChange - 1)
			TSAScroll.Minimum = 0
			TSAScroll.Value = blockpage

			TSAScroll.Visible = True

			Me.Width = 540
			Me.Height = 356

			tsapic.Width = 260
			tsapic.Width = 260
			tsapic.Height = 261

			PnlSetPaletteForTileX.Left = 0
			PnlSetPaletteForTileX.Top = 0

			PnlMetatiles.Left = 0
			PnlMetatiles.Top = 43

			PnlBlockTypeAndImageTilePalette.Left = 284
			PnlBlockTypeAndImageTilePalette.Top = 0

			PnlButtons.Left = 420
			PnlButtons.Top = 0
		Else
			TSAScroll.Visible = False
			If GetCfg("tsatbl_8x32") = 1 Then
				Me.Width = 400
				Me.Height = 600

				tsapic.Width = 133
				tsapic.Height = 517

				PnlSetPaletteForTileX.Left = 0
				PnlSetPaletteForTileX.Top = 0

				PnlMetatiles.Left = 0
				PnlMetatiles.Top = 43

				PnlBlockTypeAndImageTilePalette.Left = tsapic.Left + tsapic.Width + 10
				PnlBlockTypeAndImageTilePalette.Top = PnlMetatiles.Top
				PnlBlockTypeAndImageTilePalette.BringToFront() ' It is over PnlMetatiles

				PnlButtons.Left = PnlBlockTypeAndImageTilePalette.Left + PnlBlockTypeAndImageTilePalette.Width + 10
				PnlButtons.Top = PnlMetatiles.Top
			Else
				Me.Width = 540
				Me.Height = 356

				tsapic.Width = 261
				tsapic.Height = 261

				PnlSetPaletteForTileX.Left = 0
				PnlSetPaletteForTileX.Top = 0

				PnlMetatiles.Left = 0
				PnlMetatiles.Top = 43

				PnlBlockTypeAndImageTilePalette.Left = 284
				PnlBlockTypeAndImageTilePalette.Top = 0

				PnlButtons.Left = 420
				PnlButtons.Top = 0
			End If
		End If

		'tsapic.Refresh

		RenderModule.PB_ReSizeInit(tsapic, tsat_bmi)

		'TSAScroll.value = blockpage

		Update_Level()
	End Sub

	Public Sub Update_RefreshAllBitmaps()
		Update_Level() ' Needs to be done for Mega Man 5 when changing screen
		RenderModule.RenderPic(PalPic, tsat_pal_bmi)
		RenderModule.RenderPic(tsapic, tsat_bmi)
	End Sub

	Public Sub Update_Level()
		Dim Y, blockX, blockY, x As Integer
		Dim col(3) As Byte

		For blockY = 0 To (tsatbl_blockwidthY - 1)
			For blockX = 0 To (tsatbl_blockwidthX - 1)
				Draw_Block(blockY, blockX, False)
			Next blockX
		Next blockY

		DrawGrid()

		For Y = 0 To 3
			For x = 0 To 3
				RenderModule.DrawRectangle(tsat_pal_bmi, (x * 16) + 2, (Y * 16) + 2, (x * 16) + 15, (Y * 16) + 15, ((Y * 4) + x))
			Next x
		Next Y

		tsat_pal_bmi.bytesRGB_UpdatedSinceLastRender = True

		Update_TSA_Stats()

		RenderModule.RenderPic(tsapic, tsat_bmi)
		RenderModule.RenderPic(PalPic, tsat_pal_bmi)
	End Sub

	Public Sub Update_BGPal(ByRef upd As Integer)
		If upd = 1 Then
			RenderModule.RenderPic(tsapic, tsat_bmi)
			RenderModule.RenderPic(PalPic, tsat_pal_bmi)

			If TileTable.Visible = True Then
				TileTable.UpdateMetatileTableCurrentTile()
			End If
		End If
	End Sub

	Public Sub Update_TileRange(ByRef min As Integer, ByRef max As Integer)
		Dim blockX, blockY As Integer

		For blockY = 0 To (tsatbl_blockwidthY - 1)
			For blockX = 0 To (tsatbl_blockwidthX - 1)
				Draw_Block(blockY, blockX, True, min, max)
			Next blockX
		Next blockY

		DrawGrid()

		RenderModule.RenderPic(tsapic, tsat_bmi)
	End Sub

	Public Sub Update_CurBlock()
		CurBlockSet()
		RenderModule.RenderPic(PalPic, tsat_pal_bmi)
		RenderModule.RenderPic(tsapic, tsat_bmi)
	End Sub

	Public Sub ClearUnusedMetatiles()
		Dim a As Integer
		Dim tmp_tsamap(&HFFS) As Byte

		' Clear arrays

		For a = 0 To &HFFS
			tmp_tsamap(a) = 0 'Not used (clear status)
		Next a

		For a = 0 To &HFFS
			tmp_tsamap(romdat(arrayAdjuster + offs(gem, o_str) + (a * 4) + 0)) = 1
			tmp_tsamap(romdat(arrayAdjuster + offs(gem, o_str) + (a * 4) + 1)) = 1
			tmp_tsamap(romdat(arrayAdjuster + offs(gem, o_str) + (a * 4) + 2)) = 1
			tmp_tsamap(romdat(arrayAdjuster + offs(gem, o_str) + (a * 4) + 3)) = 1
		Next a

		For a = 0 To &HFFS
			If tmp_tsamap(a) = 0 Then
				romdat(arrayAdjuster + offs(gem, o_tsatile) + a + 0) = 0
				romdat(arrayAdjuster + offs(gem, o_tsatile) + a + &H100S) = 0
				romdat(arrayAdjuster + offs(gem, o_tsatile) + a + &H200S) = 0
				romdat(arrayAdjuster + offs(gem, o_tsatile) + a + &H300S) = 0
				romdat(arrayAdjuster + offs(gem, o_tsatype) + a) = 0
			End If
		Next a
	End Sub

	Private Sub DrawGrid()
		Dim a, b As Integer

		If GetCfg("tsaed_grid") = 1 Then
			If GetCfg("tsatbl_2x") = 1 Then
				For a = 0 To (tsatbl_blockwidthY - 0)
					For b = 0 To (tsatbl_blockwidthX - 1)
						RenderModule.DrawLineH(tsat_bmi, (b * 32), (b * 32) + 31, (a * 32), &H20S)
						RenderModule.DrawLineV(tsat_bmi, (b * 32), (a * 32), (a * 32) + 31, &H20S)
					Next b
					RenderModule.DrawLineV(tsat_bmi, (b * 32), (a * 32), (a * 32) + 31, &H20S)
				Next a
			Else
				For a = 0 To (tsatbl_blockwidthY - 0)
					For b = 0 To (tsatbl_blockwidthX - 1)
						RenderModule.DrawLineH(tsat_bmi, (b * 16), (b * 16) + 15, (a * 16), &H20S)
						RenderModule.DrawLineV(tsat_bmi, (b * 16), (a * 16), (a * 16) + 15, &H20S)
					Next b
					RenderModule.DrawLineV(tsat_bmi, (b * 16), (a * 16), (a * 16) + 15, &H20S)
				Next a
			End If
		End If

		tsat_bmi.bytesRGB_UpdatedSinceLastRender = True

		Draw_CurBlock_Marker()
	End Sub

	Private Sub CurBlockSet()
		If GetCfg("tsaed_grid") = 1 Then
			If GetCfg("tsatbl_2x") = 1 Then
				RenderModule.DrawLineH(tsat_bmi, (oldblockX * 32), (oldblockX * 32) + 31, (oldblockY * 32), &H20S)
				RenderModule.DrawLineV(tsat_bmi, (oldblockX * 32), (oldblockY * 32), (oldblockY * 32) + 32, &H20S)
				RenderModule.DrawLineH(tsat_bmi, (oldblockX * 32), (oldblockX * 32) + 31, (oldblockY * 32) + 32, &H20S)
				RenderModule.DrawLineV(tsat_bmi, (oldblockX * 32) + 32, (oldblockY * 32), (oldblockY * 32) + 32, &H20S)
			Else
				RenderModule.DrawLineH(tsat_bmi, (oldblockX * 16), (oldblockX * 16) + 15, (oldblockY * 16), &H20S)
				RenderModule.DrawLineV(tsat_bmi, (oldblockX * 16), (oldblockY * 16), (oldblockY * 16) + 16, &H20S)
				RenderModule.DrawLineH(tsat_bmi, (oldblockX * 16), (oldblockX * 16) + 15, (oldblockY * 16) + 16, &H20S)
				RenderModule.DrawLineV(tsat_bmi, (oldblockX * 16) + 16, (oldblockY * 16), (oldblockY * 16) + 16, &H20S)
			End If
		Else
			Draw_Block(oldblockY, oldblockX, False)
			If oldblockX < (tsatbl_blockwidthX - 1) Then
				Draw_Block(oldblockY, oldblockX + 1, False)
			End If
			If oldblockY < (tsatbl_blockwidthY - 1) Then
				Draw_Block(oldblockY + 1, oldblockX, False)
				If oldblockX < (tsatbl_blockwidthX - 1) Then
					Draw_Block(oldblockY + 1, oldblockX + 1, False)
				End If
			End If

			If GetCfg("tsatbl_2x") = 1 Then
				RenderModule.DrawLineV(tsat_bmi, (32 * tsatbl_blockwidthX), 0, (32 * tsatbl_blockwidthY), &H20S)
				RenderModule.DrawLineH(tsat_bmi, 0, (32 * tsatbl_blockwidthX) - 1, (32 * tsatbl_blockwidthY), &H20S)
			Else
				RenderModule.DrawLineV(tsat_bmi, (16 * tsatbl_blockwidthX), 0, (16 * tsatbl_blockwidthY), &H20S)
				RenderModule.DrawLineH(tsat_bmi, 0, (16 * tsatbl_blockwidthX) - 1, (16 * tsatbl_blockwidthY), &H20S)
			End If
		End If

		tsat_bmi.bytesRGB_UpdatedSinceLastRender = True

		Draw_CurBlock_Marker()
		Update_TSA_Stats()
	End Sub

	Private Sub Update_TSA_Stats()
		Dim Y As Integer

		SetListCool(BlockTypeList, Nibble(romdat(arrayAdjuster + offs(gem, 4) + CalcTSA()), 0))

		For Y = 0 To 3
			RenderModule.DrawLineH(tsat_pal_bmi, 0, (4 * 16) + 1, (Y * 16) + 0, &H20S)
			RenderModule.DrawLineH(tsat_pal_bmi, 0, (4 * 16) + 1, (Y * 16) + 1, &H20S)
			RenderModule.DrawLineH(tsat_pal_bmi, 0, (4 * 16) + 1, (Y * 16) + 16, &H20S)
			RenderModule.DrawLineH(tsat_pal_bmi, 0, (4 * 16) + 1, (Y * 16) + 17, &H20S)
			RenderModule.DrawLineV(tsat_pal_bmi, 0, (Y * 16) + 1, (Y * 16) + 15, &H20S)
			RenderModule.DrawLineV(tsat_pal_bmi, 1, (Y * 16) + 1, (Y * 16) + 15, &H20S)
			RenderModule.DrawLineV(tsat_pal_bmi, (4 * 16) + 0, (Y * 16) + 2, (Y * 16) + 16, &H20S)
			RenderModule.DrawLineV(tsat_pal_bmi, (4 * 16) + 1, (Y * 16) + 2, (Y * 16) + 16, &H20S)
		Next Y
		Y = Nibble(romdat(arrayAdjuster + offs(gem, 4) + CalcTSA()), 1) And 3
		RenderModule.DrawLineH(tsat_pal_bmi, 0, (4 * 16) + 1, (Y * 16) + 0, &H21S)
		RenderModule.DrawLineH(tsat_pal_bmi, 0, (4 * 16) + 1, (Y * 16) + 1, &H21S)
		RenderModule.DrawLineH(tsat_pal_bmi, 0, (4 * 16) + 1, (Y * 16) + 16, &H21S)
		RenderModule.DrawLineH(tsat_pal_bmi, 0, (4 * 16) + 1, (Y * 16) + 17, &H21S)
		RenderModule.DrawLineV(tsat_pal_bmi, 0, (Y * 16) + 1, (Y * 16) + 15, &H21S)
		RenderModule.DrawLineV(tsat_pal_bmi, 1, (Y * 16) + 1, (Y * 16) + 15, &H21S)
		RenderModule.DrawLineV(tsat_pal_bmi, (4 * 16) + 0, (Y * 16) + 2, (Y * 16) + 16, &H21S)
		RenderModule.DrawLineV(tsat_pal_bmi, (4 * 16) + 1, (Y * 16) + 2, (Y * 16) + 16, &H21S)

		tsat_pal_bmi.bytesRGB_UpdatedSinceLastRender = True
	End Sub

	Private Sub Draw_CurBlock_Marker()
		If GetCfg("tsatbl_2x") = 1 Then
			RenderModule.DrawLineH(tsat_bmi, (curblockX * 32), (curblockX * 32) + 31, (curblockY * 32), &H22S)
			RenderModule.DrawLineV(tsat_bmi, (curblockX * 32), (curblockY * 32), (curblockY * 32) + 32, &H22S)
			RenderModule.DrawLineH(tsat_bmi, (curblockX * 32), (curblockX * 32) + 31, (curblockY * 32) + 32, &H22S)
			RenderModule.DrawLineV(tsat_bmi, (curblockX * 32) + 32, (curblockY * 32), (curblockY * 32) + 32, &H22S)
		Else
			RenderModule.DrawLineH(tsat_bmi, (curblockX * 16), (curblockX * 16) + 15, (curblockY * 16), &H22S)
			RenderModule.DrawLineV(tsat_bmi, (curblockX * 16), (curblockY * 16), (curblockY * 16) + 16, &H22S)
			RenderModule.DrawLineH(tsat_bmi, (curblockX * 16), (curblockX * 16) + 15, (curblockY * 16) + 16, &H22S)
			RenderModule.DrawLineV(tsat_bmi, (curblockX * 16) + 16, (curblockY * 16), (curblockY * 16) + 16, &H22S)
		End If

		tsat_bmi.bytesRGB_UpdatedSinceLastRender = True
	End Sub

	Private Sub Draw_Block(ByRef blockY As Integer, ByRef blockX As Integer, ByRef tilerange As Boolean, Optional ByRef min As Integer = 0, Optional ByRef max As Integer = 0)
		Dim Y, tileX, tilepal, blocknum, tileY, tilenum, x As Integer
		Dim pass As Boolean
		blocknum = CalcTSA(blockY, blockX)
		Select Case GetCfg("tsatbl_2x")
			Case 0
				tilepal = Nibble(romdat(arrayAdjuster + offs(gem, 4) + blocknum), 1) And 3
				For tileY = 0 To 1
					For tileX = 0 To 1
						tilenum = romdat(arrayAdjuster + offs(gem, 3) + (((tileY * 2) + tileX) * &H100S) + blocknum)
						pass = True
						If (tilerange = True) Then
							If (tilenum < min) Or (tilenum > max) Then
								pass = False
							End If
						End If
						If pass = True Then
							Y = ((blockY * 16) + tileY * 8)
							x = ((blockX * 16) + tileX * 8)
							RenderModule.DrawTile(tsat_bmi, chrmap(tilenum), tilepal, x, Y, romdat)
						End If
					Next tileX
				Next tileY
			Case 1
				tilepal = Nibble(romdat(arrayAdjuster + offs(gem, 4) + blocknum), 1) And 3
				For tileY = 0 To 1
					For tileX = 0 To 1
						tilenum = romdat(arrayAdjuster + offs(gem, 3) + (((tileY * 2) + tileX) * &H100S) + blocknum)
						pass = True
						If (tilerange = True) Then
							If (tilenum < min) And (tilenum > max) Then
								pass = False
							End If
						End If
						If pass = True Then
							Y = (blockY * 32) + (tileY * 16)
							x = (blockX * 32) + (tileX * 16)
							RenderModule.DrawTile(tsat_bmi, chrmap(tilenum), tilepal, x, Y, romdat, 2)
						End If
					Next tileX
				Next tileY
		End Select

		tsat_bmi.bytesRGB_UpdatedSinceLastRender = True
	End Sub

	Private Sub BlockTypeList_SelectedIndexChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles BlockTypeList.SelectedIndexChanged
		If BlockTypeList.Tag <> "" Then Exit Sub
		romdat(arrayAdjuster + offs(gem, 4) + CalcTSA()) = (CShort(romdat(arrayAdjuster + offs(gem, 4) + CalcTSA()) And &HFS) + (Val(CStr(BlockTypeList.SelectedIndex)) * 16))
	End Sub

	Private Sub PalPic_MouseDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles PalPic.MouseDown
		Dim Button As Short = eventArgs.Button \ &H100000
		Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
		Dim x As Single = eventArgs.X
		Dim Y As Single = eventArgs.Y
		Dim row As Integer
		Dim Index As Short = 0

		For Each radioButton As RadioButton In rdGroupSetPaletteForTile
			If radioButton.Checked = True Then
				Exit For
			End If
			Index += 1
		Next

		row = VWidth((Y - 8) / 16, 0, 3)

		romdat(arrayAdjuster + offs(gem, 4) + CalcTSA()) = (CShort(romdat(arrayAdjuster + offs(gem, 4) + CalcTSA()) And &HF0S) + row)

		Draw_Block(curblockY, curblockX, False)

		CurBlockSet()

		RenderModule.RenderPic(tsapic, tsat_bmi)
		RenderModule.RenderPic(PalPic, tsat_pal_bmi)
		MFLE_Main.Update_Block(CalcTSA)
	End Sub

	Private Sub PalPic_MouseMove(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles PalPic.MouseMove
		Dim Button As Short = eventArgs.Button \ &H100000
		Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
		Dim x As Single = eventArgs.X
		Dim Y As Single = eventArgs.Y
		If Button Then PalPic_MouseDown(PalPic, New System.Windows.Forms.MouseEventArgs(Button * &H100000, 0, x, Y, 0))
	End Sub

	Private Sub Tsapic_MouseDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles tsapic.MouseDown
		Dim Button As Short = eventArgs.Button \ &H100000
		Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
		Dim x As Single = eventArgs.X
		Dim Y As Single = eventArgs.Y
		Dim c, d As Integer
		Dim blockdim, tiledim As Integer

		If GetCfg("tsatbl_2x") = 1 Then
			blockdim = 32
			tiledim = 16
		Else
			blockdim = 16
			tiledim = 8
		End If

		Dim blockY, blockX As Integer
		Dim tile As Integer
		If Button And 1 Then
			oldblockY = curblockY
			oldblockX = curblockX
			curblockY = VWidth(Int(Y / blockdim), 0, tsatbl_blockwidthY - 1)
			curblockX = VWidth(Int(x / blockdim), 0, tsatbl_blockwidthX - 1)
			CurBlockSet()
			RenderModule.RenderPic(tsapic, tsat_bmi)
			RenderModule.RenderPic(PalPic, tsat_pal_bmi)
		ElseIf Button And (2 Or 4) Then
			blockY = VWidth(Int(Y / blockdim), 0, tsatbl_blockwidthY - 1)
			blockX = VWidth(Int(x / blockdim), 0, tsatbl_blockwidthX - 1)
			c = VWidth(Int((Y - (blockY * blockdim)) / tiledim), 0, 1) 'Fix 06-28-09
			d = VWidth(Int((x - (blockX * blockdim)) / tiledim), 0, 1) 'Fix 06-28-09
			If (Button And 2) Then
				romdat(arrayAdjuster + offs(gem, 3) + (((c * 2) + d) * &H100S) + CalcTSA(blockY, blockX)) = ((curtileY * 16) + curtileX)
				Draw_Block(blockY, blockX, False)
				'MFX_Render.DrawTile1 tsapic, tsat_bmi, chrmap(romdat(arrayAdjuster + offs(gem, 3) + (((c * 2) + d) * &H100) + calcTSA(blockY, blockX))), (romdat(arrayAdjuster + offs(gem, 4) + calcTSA(blockY, blockX)) And 3), (blockX * blockdim) + (d * tiledim), (blockY * blockdim) + (c * tiledim)
				DrawGrid()
				RenderModule.RenderPic(tsapic, tsat_bmi)
				MFLE_Main.Update_Block(CalcTSA(blockY, blockX))
			Else
				tile = romdat(arrayAdjuster + offs(gem, 3) + (((c * 2) + d) * &H100S) + CalcTSA(blockY, blockX))
				oldtileY = curtileY
				oldtileX = curtileX
				curtileY = Int(tile / 16)
				curtileX = tile And 15
				MFLE_Main.Update_CurTile()
			End If
		End If
	End Sub

	Private Sub Tsapic_MouseMove(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles tsapic.MouseMove
		Dim Button As Short = eventArgs.Button \ &H100000
		Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
		Dim x As Single = eventArgs.X
		Dim Y As Single = eventArgs.Y
		Static blockY As Integer
		Static blockX As Integer
		Static tileY As Integer
		Static tileX As Integer
		Dim blockdim, tiledim As Integer

		If GetCfg("tsatbl_2x") = 1 Then
			blockdim = 32
			tiledim = 16
		Else
			blockdim = 16
			tiledim = 8
		End If

		MouseX = x
		MouseY = Y
		If (Button And (2 Or 4)) Then
			If (Int(Y / tiledim) And 1) <> tileY Then GoTo settile
			If (Int(x / tiledim) And 1) <> tileX Then GoTo settile
		End If
		GoTo dontsettile
settile:
		Tsapic_MouseDown(tsapic, New System.Windows.Forms.MouseEventArgs(Button * &H100000, 0, x, Y, 0))
dontsettile:
		If Int(Y / blockdim) <> blockY Or Int(x / blockdim) <> blockX Then
			If (Button And 1) Then
				Tsapic_MouseDown(tsapic, New System.Windows.Forms.MouseEventArgs(Button * &H100000, 0, x, Y, 0))
			End If
		End If
		tileY = (Int(Y / tiledim) And 1)
		tileX = (Int(x / tiledim) And 1)
		blockY = Int(Y / blockdim)
		blockX = Int(x / blockdim)
	End Sub

	Private Sub TSAScroll_Change(ByVal newScrollValue As Integer)
		blockpage = newScrollValue
		Update_Level()
	End Sub

	Private Sub TSAScroll_Scroll_Event(ByVal newScrollValue As Integer)
		blockpage = newScrollValue
		Update_Level()
	End Sub

	Private Sub TsaCopyBtn_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles tsaCopyBtn.Click
		Dim a As Integer
		a = romdat(arrayAdjuster + offs(gem, 4) + CalcTSA())
		copyBuf.pal = (a And &H3S)
		copyBuf.Type = Int(a / 16)
		copyBuf.tile(0) = romdat(arrayAdjuster + offs(gem, 3) + (0 * &H100S) + CalcTSA())
		copyBuf.tile(1) = romdat(arrayAdjuster + offs(gem, 3) + (1 * &H100S) + CalcTSA())
		copyBuf.tile(2) = romdat(arrayAdjuster + offs(gem, 3) + (2 * &H100S) + CalcTSA())
		copyBuf.tile(3) = romdat(arrayAdjuster + offs(gem, 3) + (3 * &H100S) + CalcTSA())
	End Sub

	Private Sub TsaPasteBtn_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles tsaPasteBtn.Click
		romdat(arrayAdjuster + offs(gem, 3) + 0 + CalcTSA()) = copyBuf.tile(0)
		romdat(arrayAdjuster + offs(gem, 3) + &H100S + CalcTSA()) = copyBuf.tile(1)
		romdat(arrayAdjuster + offs(gem, 3) + &H200S + CalcTSA()) = copyBuf.tile(2)
		romdat(arrayAdjuster + offs(gem, 3) + &H300S + CalcTSA()) = copyBuf.tile(3)
		romdat(arrayAdjuster + offs(gem, 4) + CalcTSA()) = ((copyBuf.Type * 16) + copyBuf.pal)
		Draw_Block(curblockY, curblockX, False)
		DrawGrid()
		RenderModule.RenderPic(tsapic, tsat_bmi)
		MFLE_Main.Update_Block(CalcTSA)
	End Sub

	Private Sub TSATable_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
		e.Cancel = True

		Me.Hide()
	End Sub

	Private Sub BtnClearUnusedMetatiles_Click(sender As Object, e As EventArgs) Handles BtnClearUnusedMetatiles.Click
		ClearUnusedMetatiles()
		If Me.Visible = True Then Me.Update_Level()
	End Sub

	Private Sub BtnShowSelected_Click(sender As Object, e As EventArgs) Handles BtnShowSelected.Click
		Dim x, TSA_Scale, xPos, yPos As Integer
		Dim colorByte As Byte() = {&H20S, &H22S, &H26S, &H20S, &H22S, &H26S, &H20S, &H22S, &H26S}

		If GetCfg("tsatbl_2x") = 1 Then
			TSA_Scale = 32
		Else
			TSA_Scale = 16
		End If

		' Calculate those only once X and Y positions if cursor is changed before the end
		xPos = (curblockX * TSA_Scale)
		yPos = (curblockY * TSA_Scale)

		For x = 0 To (colorByte.Length - 1)
			RenderModule.DrawRectangle(tsat_bmi, xPos, yPos, xPos + TSA_Scale, yPos + TSA_Scale, colorByte(x))

			tsat_bmi.palette_UpdatedSinceLastBytesRGB_Update = True

			RenderModule.RenderPicAlwaysIfItWasChangedSinceLastupdate(tsapic, tsat_bmi)

			Threading.Thread.Sleep(100)
		Next

		' Reupdate form since we just fill current Metametatile's rectangle
		Draw_Block(curblockY, curblockX, False)
		If curblockX < (tsatbl_blockwidthX - 1) Then
			Draw_Block(curblockY, curblockX + 1, False)
		End If
		If curblockY < (tsatbl_blockwidthY - 1) Then
			Draw_Block(curblockY + 1, curblockX, False)
			If curblockX < (tsatbl_blockwidthX - 1) Then
				Draw_Block(curblockY + 1, curblockX + 1, False)
			End If
		End If

		Draw_CurBlock_Marker()

		RenderModule.RenderPic(tsapic, tsat_bmi)
	End Sub

	' All duplicated Metatiles will be replaced by their first occurence
	Public Sub ReplaceDuplicatedMetatiles()
		Dim a, b, c, aMax As Integer
		Dim isDuplicate
		Dim tmp_metatilesmapDuplicateStatus(&HFFS) As Byte
		Dim tmp_metatilesmapID_OfIdenticalTile(&HFFS) As Byte

		aMax = (&HFFS - 1)

		' Clear arrays

		For a = 0 To &HFFS
			tmp_metatilesmapDuplicateStatus(a) = 0 ' Not duplicated (clear status)
			tmp_metatilesmapID_OfIdenticalTile(a) = 0 ' Not a copy of any Metatile ID for now
		Next a

		' First, find Metatiles that are duplicated

		' Loop on Metatile that will be the referenced Metatile (that others are a copy of)
		For a = 0 To aMax
			' Loop on every following Metatile
			For b = (a + 1) To &HFFS
				' If current Metatile checked is not already a copy of another Tile
				If tmp_metatilesmapDuplicateStatus(b) = 0 Then
					' Suppose Metatile is a duplicate and we will adjust if not
					isDuplicate = True

					' Compare every Tiles between both Metatiles
					If romdat(arrayAdjuster + offs(gem, o_tsatile) + b + 0) <> romdat(arrayAdjuster + offs(gem, o_tsatile) + a + 0) Then
						isDuplicate = False
					End If
					If romdat(arrayAdjuster + offs(gem, o_tsatile) + b + &H100S) <> romdat(arrayAdjuster + offs(gem, o_tsatile) + a + &H100S) Then
						isDuplicate = False
					End If
					If romdat(arrayAdjuster + offs(gem, o_tsatile) + b + &H200S) <> romdat(arrayAdjuster + offs(gem, o_tsatile) + a + &H200S) Then
						isDuplicate = False
					End If
					If romdat(arrayAdjuster + offs(gem, o_tsatile) + b + &H300S) <> romdat(arrayAdjuster + offs(gem, o_tsatile) + a + &H300S) Then
						isDuplicate = False
					End If
					' Compare both Metatiles' type
					If romdat(arrayAdjuster + offs(gem, o_tsatype) + b) <> romdat(arrayAdjuster + offs(gem, o_tsatype) + a) Then
						isDuplicate = False
					End If

					If isDuplicate Then
						' If here, current Metatile checked is identical to the one checked right now
						tmp_metatilesmapDuplicateStatus(b) = 1
						tmp_metatilesmapID_OfIdenticalTile(b) = a
					End If
				End If
			Next b
		Next a

		' Loop through all array entry and stop on Metatiles that are duplicate
		For a = 0 To &HFFS
			If tmp_metatilesmapDuplicateStatus(a) = 1 Then
				' A duplicate Metatile! We don't clear it in current function, but we will make it unused
				'	So after this current function call, calling function that clear unused Metatiles will clear them
				' So find everywhere current Metatile is used (check every Metametatiles)
				'	and, in those Metametatiles, use instead, the Reference Metatile we defined above
				' So loop through every Metametatile
				For b = 0 To &HFFS
					' So loop through every Metametatile's Metatile
					For c = 0 To 3
						' If current Metatile is used
						If romdat(arrayAdjuster + offs(gem, o_str) + (b * 4) + c) = a Then
							' Put the reference Metatile instead
							romdat(arrayAdjuster + offs(gem, o_str) + (b * 4) + c) = tmp_metatilesmapID_OfIdenticalTile(a)
						End If
					Next
				Next b
            End If
		Next
	End Sub

	Private Sub BtnClearDuplicated_Click(sender As Object, e As EventArgs) Handles BtnClearDuplicated.Click
		ReplaceDuplicatedMetatiles()
		BtnClearUnusedMetatiles_Click(sender, e)
    End Sub

	Private Sub chkPaletteForEachTile_CheckedChanged(sender As Object, e As EventArgs) Handles chkPaletteForEachTile.CheckedChanged
		rdSetPaletteForTile1.Visible = chkPaletteForEachTile.Checked
		rdSetPaletteForTile2.Visible = chkPaletteForEachTile.Checked
		rdSetPaletteForTile3.Visible = chkPaletteForEachTile.Checked
		rdSetPaletteForTile4.Visible = chkPaletteForEachTile.Checked

		If chkPaletteForEachTile.Checked = False Then
			rdSetPaletteForTileAll.Checked = True
			SetCfg("onepalettepertile", "0")
		Else
			SetCfg("onepalettepertile", "1")
		End If
	End Sub

	Private Sub TSAScroll_Scroll(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.ScrollEventArgs) Handles TSAScroll.Scroll
		Select Case eventArgs.Type
			Case System.Windows.Forms.ScrollEventType.ThumbTrack
				TSAScroll_Scroll_Event(eventArgs.NewValue)
			Case System.Windows.Forms.ScrollEventType.EndScroll
				TSAScroll_Change(eventArgs.NewValue)
		End Select
	End Sub
End Class