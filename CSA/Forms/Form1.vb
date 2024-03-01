Option Explicit On

Friend Class Form1
	Inherits System.Windows.Forms.Form

	Private InitialWidth As Integer
	Private CHR_ViewLastPal As Integer = 0
	Private CHR_ViewZoom As Integer = 1
	Private ReadOnly BtnMoreOptionsLessOptionsText = "Less Options"
	Private ReadOnly BtnMoreOptionsMoreOptionsText = "More Options"
	Private ReadOnly BtnUsedByAnimationsText = "Used by Animations..."
	Private ReadOnly BtnUsedBySpritesText = "Used by Sprites..."
	Private ReadOnly BtnUsedByHideText = "Hide"
	Private oldtileX As Integer
	Private oldtileY As Integer
	Private Manual_Init_Later_Happened As Boolean = False
	Private usingCHR_FileForTileMap As Boolean = False
	Private ASM_FileModeOn As Boolean = False
	Private ASM_FileModeSpriteLoaded As Boolean = False
	Private ASM_FileModeInitiated As Boolean = False
	Private LstASM_Mode_AnimationsInitialLeft As Integer
	Private LstASM_Mode_SpritesInitialLeft As Integer
	Private LstASM_Mode_CoordinatesInitialLeft As Integer
	Private LstASM_Mode_AnimationsInitialWidth As Integer
	Private LstASM_Mode_AnimationsExtendedWidth As Integer
	Public ASM_ModeConfigFileNotAuto As String = "="    ' This value indicates that it at least exists - but no files will be automatically loaded
	Private ASM_ModeAnimFile As String
	Private ASM_ModeCHR_File As String
	Private ASM_ModeCHR_FileStartOffset As Integer
	Private animationsArray As AnimationData() = Array.Empty(Of AnimationData)()
	Private spritesArray As SpriteData() = Array.Empty(Of SpriteData)()
	Private coordinatesArray As CoordinateData() = Array.Empty(Of CoordinateData)()
	Private currentAnimation As AnimationData = Nothing
	Private currentSprite As SpriteData = Nothing
	Private currentCoordinate As CoordinateData = Nothing

	Private KeepSelTile As Boolean
	Private KeepSelFrame As Boolean

	Private ScrollBars_ProgramChange As Boolean

	Private ReadOnly tilePicTileWidth As Integer = 16
	Private ReadOnly tileSize As Integer = 8

	Private WorkPic_lastbmx As Integer
	Private WorkPic_lastbmy As Integer

	Private CursorBlinkState As Integer

	Private PatEdColor As Byte

	'Objects that group many items
	'   PictureBox
	Private PalPic() As PictureBox
	'   RadioButton
	Private AnimSpeedOpt() As RadioButton
	Private CursorTypeOpt() As RadioButton
	Private FramePageOpt() As RadioButton
	Private PalOpt() As RadioButton
	Private TilePrioOpt() As RadioButton
	Private ZoomOpt() As RadioButton
	Private ZoomOptCHR_Map() As RadioButton
	'	TextBox
	Private BGColTB() As TextBox
	Private PalTB() As TextBox


	Public Sub Manual_Init()
		'Objects that group many items
		'   PictureBox
		PalPic = New PictureBox() {_PalPic_0, _PalPic_1, _PalPic_2, _PalPic_3, _PalPic_4, _PalPic_5, _PalPic_6, _PalPic_7, _PalPic_8, _PalPic_9, _PalPic_10, _PalPic_11}
		'   RadioButton
		AnimSpeedOpt = New RadioButton() {_AnimSpeedOpt_0, _AnimSpeedOpt_1, _AnimSpeedOpt_2}
		CursorTypeOpt = New RadioButton() {_CursorTypeOpt_0, _CursorTypeOpt_1}
		FramePageOpt = New RadioButton() {_FramePageOpt_0, _FramePageOpt_1}
		PalOpt = New RadioButton() {_PalOpt_0, _PalOpt_1, _PalOpt_2, _PalOpt_3}
		TilePrioOpt = New RadioButton() {_TilePrioOpt_0, _TilePrioOpt_1}
		ZoomOpt = New RadioButton() {_ZoomOpt_0, _ZoomOpt_1, _ZoomOpt_2, _ZoomOpt_3}
		ZoomOptCHR_Map = New RadioButton() {_ZoomOptCHR_Map_0, _ZoomOptCHR_Map_1, _ZoomOptCHR_Map_2, _ZoomOptCHR_Map_3}
		'	TextBox
		BGColTB = New TextBox() {_BGColTB_0, _BGColTB_1, _BGColTB_2}
		PalTB = New TextBox() {_PalTB_0, _PalTB_1, _PalTB_2, _PalTB_3, _PalTB_4, _PalTB_5, _PalTB_6, _PalTB_7, _PalTB_8, _PalTB_9, _PalTB_10, _PalTB_11}

		BtnMoreOptions.Text = BtnMoreOptionsMoreOptionsText
		InitialWidth = BtnMoreOptions.Left + BtnMoreOptions.Width + 30
		Me.Height = PnlMoreOptions.Top + PnlMoreOptions.Height + 40
	End Sub

	Public Sub Manual_Init_Later()
		Dim index As Integer = 0

		_ZoomOptCHR_Map_3.Checked = True

		LstASM_Mode_AnimationsInitialLeft = LstASM_Mode_Animations.Left
		LstASM_Mode_SpritesInitialLeft = LstASM_Mode_Sprites.Left
		LstASM_Mode_CoordinatesInitialLeft = LstASM_Mode_Coordinates.Left
		LstASM_Mode_AnimationsInitialWidth = LstASM_Mode_Animations.Width
		LstASM_Mode_AnimationsExtendedWidth = LstASM_Mode_Coordinates.Left - LstASM_Mode_Animations.Left + LstASM_Mode_Coordinates.Width

		For Each textBox As TextBox In PalTB
			PalTB(index).Text = CStr(Hex((GetCfg(PalTB(index).Name))))
			index += 1
		Next

		Manual_Init_Later_Happened = True
	End Sub

	Public Sub InitAutoLoadChk()
		Dim autoLoadASM_ModeConfig = GetCfg("auto_loadASM_Mode", False)
		ChkAutoloadROM.Checked = If(GetCfg("auto_loadrom") = "", False, True)
		If autoLoadASM_ModeConfig = "" Then
			SpecialToolStripMenuItem.Visible = False
			SwitchToAsmFileModeToolStripMenuItem.Visible = False
		ElseIf autoLoadASM_ModeConfig <> ASM_ModeConfigFileNotAuto Then
			ChkAutoloadASM_ModeAndFiles.Checked = True
		End If
	End Sub

	'Refresh -----------------------------------------------------------------------------

	Public Sub Refresh_All()
		Dim c, a, b, d As Integer

		KeepSelTile = False
		KeepSelFrame = False

		CursorBlinkState = 0
		PatEdColor = 0

		SprAddrTB.ForeColor = System.Drawing.ColorTranslator.FromOle(RGB(&HA0S, 0, 0))
		FrameAddrTB.ForeColor = System.Drawing.ColorTranslator.FromOle(RGB(&HA0S, 0, 0))
		CoordAddrTB.ForeColor = System.Drawing.ColorTranslator.FromOle(RGB(&HA0S, 0, 0))

		If ASM_FileModeOn = False And autoLoadASM_ModeOff Then
			SprBankCombo.Items.Clear()
			For a = 0 To BankReg_last
				SprBankCombo.Items.Add(Hex(BankReg(a)))
			Next a
			SetComboCool(SprBankCombo, CObj(BankPtrSelect))

			Refresh_BankChange()
		End If

		If DataMovable = 0 Then
			AddFrameBtn.Enabled = False
			DelFrameBtn.Enabled = False
			NewTileBtn.Enabled = False
			RemTileBtn.Enabled = False
			'SprNewBtn.Enabled = False
			SprKillBtn.Enabled = False
			'FrameNewBtn.Enabled = False
			FrameKillBtn.Enabled = False
			'CoordNewBtn.Enabled = False
			CoordKillBtn.Enabled = False
			CleanUpBtn.Enabled = False
		End If

		If CoordPairs = 0 Then
			PairCheck.Visible = False
		End If

		If ResetAll_Enabled = False Then
			MTools_ResetAll.Enabled = False
		End If

		SetOptCool(ZoomOpt(ViewZoom - 1), True)
		ScrollBars_ProgramChange = True
		PicHScroll.Minimum = ViewMinX
		PicHScroll.Maximum = (ViewMaxX + PicHScroll.LargeChange - 1)
		PicVScroll.Minimum = ViewMinY
		PicVScroll.Maximum = (ViewMaxY + PicVScroll.LargeChange - 1)
		ScrollBars_ProgramChange = False
		Refresh_ViewXY()

		Me.Text = "Capcom Sprite Assembler - " & filename

		For a = 0 To 3
			For b = 0 To 2
				c = ((a * 3) + b)
				d = ((a * 4) + b + 1)
				PalPic(c).BackColor = System.Drawing.ColorTranslator.FromOle(RGBmirr(NESPAL(SprPal(d))))
				SetTBCoolText(PalTB(c), Hex(SprPal(d)))
			Next b
		Next a

		SetOptCool(TilePrioOpt(TileZPrio), True)

		SetCheckCool(MoveAllTilesCheck, MoveAllTiles)

		SetCheckCool(CursorCheck, ShowCursors)
		SetCheckCool(GridCheck, ShowGrid)
		SetOptCool(CursorTypeOpt(CursorType), True)

		SetOptCool(AnimSpeedOpt(AnimSpeed), True)

		SetCheckCool(DisableCoordCheck, DisableCoordInsDel)

		Refresh_PatternEdColor()

		SetTBCoolText(BGColTB(0), Hex(BGCol_R))
		SetTBCoolText(BGColTB(1), Hex(BGCol_G))
		SetTBCoolText(BGColTB(2), Hex(BGCol_B))

		CursorBlinkTimer.Enabled = True
	End Sub

	'User changes Bank
	Public Sub Refresh_BankChange()
		Dim a As Integer

		SetComboCool(SprBankCombo, CObj(BankPtrSelect))
		BankPtr(0) = Dec((SprBankCombo.Text))
		Update_Address_Classes()

		BuildSprFrameUsageList()
		BuildCoordLists()

		CoordList.Items.Clear()

		For a = 0 To &HFFS
			CoordList.Items.Add(Hex(a) & " - (" & CStr(CoordTileCount(a)) & " t)")
		Next a

		MakeUsageMap()

		Refresh_SpriteChange()
		Refresh_FreeSpaceInfo()
	End Sub

	'Change of current Sprite
	Public Sub Refresh_SpriteChange()
		SupInp.Load_Sprite_Patterns()
		SetTBCoolText(SprTB, Hex(Sprite))

		If ASM_FileModeOn Then
			If LstASM_Mode_Animations.Items.Count > 0 Then
				AnimationDelay = Dec(animationsArray(LstASM_Mode_Animations.SelectedIndex)._delay)
				AnimationFrames = Dec(animationsArray(LstASM_Mode_Animations.SelectedIndex)._qtySprites)
			End If
		Else
			SprAddr.lo = Rd(BankPtr(SprPtrBank) + BaseSprLo + Sprite, romdat)
			SprAddr.hi = Rd(BankPtr(SprPtrBank) + BaseSprHi + Sprite, romdat)
			SetTBCoolText(SprAddrTB, Hex(SprAddr.Mem))
			AnimationFrames = (Rd(SprAddr.Rom, romdat) And &H7FS)
			AnimationDelay = (Rd(SprAddr.Rom + 1, romdat))
		End If

		SetUDCool(DelayUD, Hex(AnimationDelay), 2)

		Refresh_FramePageChange()
	End Sub

	'* Change of Sprite
	'* User changes Frame Page
	Public Sub Refresh_FramePageChange()
		If ASM_FileModeOn Then Exit Sub
		Dim a As Integer
		Select Case FramePageMethod
			Case 0 'MM4, DwD
				FramePage = CShort(Rd(SprAddr.Rom, romdat) And &H80S) / &H80S
			Case 1 'MM2
				FramePage = CShort(Sprite And &H80S) / &H80S
		End Select

		SetOptCool(FramePageOpt(FramePage), True)

		FrameList.Items.Clear()
		For a = 0 To (Rd(SprAddr.Rom, romdat) And &H7FS)
			If Rd(SprAddr.Rom + 2 + a, romdat) > 0 Then
				FrameList.Items.Add(Hex(Rd(SprAddr.Rom + 2 + a, romdat) + (FramePage * &H100S)))
			Else
				FrameList.Items.Add("-STOP-")
			End If
		Next a

		If KeepSelFrame = True Then
			KeepSelFrame = False
		Else
			Frame = 0
		End If
		SetListCool(FrameList, Frame)

		FrameSelList.Items.Clear()
		FrameSelList.Items.Add("-STOP-")
		For a = 1 To &HFFS
			FrameSelList.Items.Add(Hex(a + (FramePage * &H100S)))
		Next a

		Refresh_FrameChange()
	End Sub

	'User (or program) changes current Sprite's Frame.
	'Or: user changes Frame ID.
	Public Sub Refresh_FrameChange()
		If (ASM_FileModeOn) Then
			SelTile = 0
			HoverTile = 0

			If LstASM_Mode_Sprites.SelectedIndex <> -1 Then
				If LstASM_Mode_Sprites.SelectedIndex < LstASM_Mode_Sprites.Items.Count - 1 Then
					LstASM_Mode_Sprites.SelectedIndex += 1
				Else
					LstASM_Mode_Sprites.SelectedIndex = 0
				End If
			End If
		Else
			Dim a As Integer

			If (KeepSelTile = True) Then
				KeepSelTile = False
			Else
				SelTile = 0
			End If

			HoverTile = 0

			SetListCool(FrameList, Frame)

			FrameID = Rd(SprAddr.Rom + 2 + Frame, romdat) Or (FramePage * &H100S)

			FrameAddr.lo = Rd(BankPtr(FramePtrBank) + BaseFrameLo + FrameID, romdat)
			FrameAddr.hi = Rd(BankPtr(FramePtrBank) + BaseFrameHi + FrameID, romdat)
			FrameAddr.Mem += FramePointerAdd

			SetTBCoolText(FrameSelTB, Hex(FrameID))
			SetListCool(FrameSelList, (FrameID And &HFFS))

			Select Case CoordinateBankSelect
				Case 0 'All other games
					FrameLastTile = Rd(FrameAddr.Rom + 0, romdat) - FrameTileNumofBase
				Case 1 'Mighty Final Fight & Mega Man 3
					FrameLastTile = CShort(Rd(FrameAddr.Rom + 0, romdat) And &H7FS) - FrameTileNumofBase
					a = CShort(Rd(FrameAddr.Rom, romdat) And &H80S) / &H80S
					BankPtr(1) = CoordBankReg(a)
					Update_Address_Classes_CoordBank(a)
			End Select

			SetTBCoolText(FrameAddrTB, Hex(FrameAddr.Mem))

			Refresh_ReportFrameUsage()

			'Refresh_RedrawSprite   'Done in Refresh_CoordID
			'Refresh_SelTile        'Done in Refresh_CoordID

			Refresh_CoordID()
		End If
	End Sub

	'User changes Coordinate ID.
	Public Sub Refresh_CoordID()
		Refresh_CoordID_Pointers()
		Refresh_CoordID_Interface()
	End Sub

	Public Sub Refresh_CoordID_Pointers()
		CoordID = Rd(FrameAddr.Rom + 1, romdat)

		CoordAddr.lo = Rd(BankPtr(CoordPtrBank) + BaseCoordLo + CoordID, romdat)
		CoordAddr.hi = Rd(BankPtr(CoordPtrBank) + BaseCoordHi + CoordID, romdat)
		CoordAddr.Mem += CoordPointerAdd

		If CoordPairs = 1 Then
			CoordID2 = (CoordID + 1) And &HFFS

			Coord2Addr.lo = Rd(BankPtr(CoordPtrBank) + BaseCoordLo + CoordID2, romdat)
			Coord2Addr.hi = Rd(BankPtr(CoordPtrBank) + BaseCoordHi + CoordID2, romdat)
			Coord2Addr.Mem += CoordPointerAdd
		End If

	End Sub

	Public Sub Refresh_CoordID_Interface()
		Dim boa As Boolean
		Dim a As Integer

		If CoordPairs = 1 Then
			boa = CheckCoordinateIsPair()
			PairCheck.Text = "Paired with " & Hex(CoordID2)
			If boa = True Then
				SetCheckCool(PairCheck, 1)
			Else
				SetCheckCool(PairCheck, 0)
			End If
		End If

		If CoordTileCount(CoordID) > 0 Then
			TileCountLab.Text = CStr(CoordTileCount(CoordID))
		Else
			TileCountLab.Text = "Unknown"
		End If

		If CoordTileCount(CoordID) = (FrameLastTile + 1) Then
			CoordStatusLab.Text = "Status: Compatible with Sprite ID"
			CoordStatusLab.ForeColor = System.Drawing.ColorTranslator.FromOle(RGB(0, 0, 0))
		Else
			CoordStatusLab.Text = "Status: INCOMPATIBLE WITH SPRITE ID!"
			CoordStatusLab.ForeColor = System.Drawing.ColorTranslator.FromOle(RGB(128, 0, 0))
		End If

		SetTBCoolText(CoordSelTB, Hex(CoordID))
		SetListCool(CoordList, CoordID)

		SetTBCoolText(CoordAddrTB, Hex(CoordAddr.Mem))

		CoordUseList.Items.Clear()
		For a = 0 To &H1FFS
			If FrameCoordUsage(a, CoordID) = True Then
				CoordUseList.Items.Add(Hex(a))
			End If
			If FrameCoordPairUsage(a, CoordID) = True Then
				CoordUseList.Items.Add(Hex(a) & " (pair)")
			End If
		Next a

		Refresh_RedrawSprite()
		Refresh_SelTile()
	End Sub

	'User changes Frame ID.
	Public Sub Refresh_FrameIDChange()
		Dim a As Integer
		a = Rd(SprAddr.Rom + 2 + Frame, romdat) + (FramePage * &H100S)
		If a = 0 OrElse a = &H100S Then
			FrameList.Items(FrameList.SelectedIndex) = "-STOP-"
		Else
			FrameList.Items(FrameList.SelectedIndex) = Hex(a)
		End If
	End Sub

	Public Sub Refresh_RedrawSprite()
		Draw_Sprite()
		Refresh_ReBlit()
	End Sub

	Public Sub Refresh_ReBlit()
		If ShowGrid = 1 Then
			RenderModule.Blit2(spr_bm, grid_bm, WorkPic, main_bmi, ViewZoom, ViewX, ViewY)
		Else
			RenderModule.Blit1(spr_bm, WorkPic, main_bmi, ViewZoom, ViewX, ViewY)
		End If

		main_bmi.palette_UpdatedSinceLastBytesRGB_Update = True
		RenderModule.RenderPic((Me.WorkPic), main_bmi)
	End Sub

	'Reflect Zoom option change.
	Public Sub Refresh_ZoomChange()
		Refresh_RedrawSprite()
		ScrollBars_ProgramChange = True
		PicHScroll.Minimum = ViewMinX
		PicHScroll.Maximum = (ViewMaxX + PicHScroll.LargeChange - 1)
		PicVScroll.Minimum = ViewMinY
		PicVScroll.Maximum = (ViewMaxY + PicVScroll.LargeChange - 1)
		ScrollBars_ProgramChange = False
		Refresh_ViewXY()
	End Sub

	'Reflect ViewX and ViewY change.
	Public Sub Refresh_ViewXY()
		SetTBCoolText(ViewXTB, CStr(ViewX))
		SetTBCoolText(ViewYTB, CStr(ViewY))
		ViewXTB.Refresh()
		ViewYTB.Refresh()
		ScrollBars_ProgramChange = True
		PicHScroll.Value = ViewX
		PicVScroll.Value = ViewY
		ScrollBars_ProgramChange = False
	End Sub

	Public Sub Refresh_TileMap(Optional _CHR_ViewLastPal As Integer = -1)
		Dim col(3) As Byte
		Dim x, Y As Integer

		' Resize PictureBox to fit just the image
		PicBTileMap.Width = 16 * (1 + tileSize * CHR_ViewZoom) + 1
		PicBTileMap.Height = PicBTileMap.Width

		' Size change, adjust BITMAPINFO
		RenderModule.PB_Init((PicBTileMap), tt_bmi)

		If (_CHR_ViewLastPal >= 0) Then CHR_ViewLastPal = _CHR_ViewLastPal

		For Y = 0 To 15
			For x = 0 To 15
				If usingCHR_FileForTileMap Or autoLoadASM_ModeOff = False Then
					RenderModule.DrawTile(tt_bmi, (Y * 16 * 16) + (x * 16), CHR_ViewLastPal, 1 + x * ((CHR_ViewZoom * tileSize) + 1), 1 + Y * ((CHR_ViewZoom * tileSize) + 1), CHR_FilePatternMap, CHR_ViewZoom)
				Else
					RenderModule.DrawTile(tt_bmi, PatternMap((Y * 16 * 16) + (x * 16)), CHR_ViewLastPal, 1 + x * ((CHR_ViewZoom * tileSize) + 1), 1 + Y * ((CHR_ViewZoom * tileSize) + 1), romdat, CHR_ViewZoom)
				End If
			Next x
		Next Y
		' Lenght(pixels) =	  1 line of (1 pixel)						-> 1
		'					+ 16 tiles of (8 pixels * CHR_ViewZoom)		-> 16*(8*CHR_ViewZoom) -> 128*(CHR_ViewZoom)
		'					+ 16 lines of (1 pixel)						-> 16
		' Spacing(pixels) =	  (Position of tile drawn)
		'					+ (Position of tile drawn)(8 pixels * CHR_ViewZoom)
		For x = 0 To 16
			RenderModule.DrawLineHUsingWxH(tt_bmi, 0, x * (1 + tileSize * CHR_ViewZoom), 17 + (16 * tileSize * CHR_ViewZoom), &H40S)
			RenderModule.DrawLineVUsingWxH(tt_bmi, x * (1 + tileSize * CHR_ViewZoom), 0, 17 + (16 * tileSize * CHR_ViewZoom), &H40S)
		Next x
		tt_bmi.palette_UpdatedSinceLastBytesRGB_Update = True
		RenderModule.RenderPic(PicBTileMap, tt_bmi)
	End Sub

	'Reflect change of currently selected tile (pink frame)
	'Or: reflect change of data for selected tile.
	Public Sub Refresh_SelTile()
		Dim x, y, attrbyte, patbyte As Integer

		If ASM_FileModeOn Then
			If ASM_FileModeSpriteLoaded Then
				x = Dec(currentCoordinate._X(SelTile))
				y = Dec(currentCoordinate._Y(SelTile))
				patbyte = Dec(currentSprite._tilesID(SelTile))
				attrbyte = Dec(currentSprite._tilesAttributes(SelTile))
			End If
		Else
			x = (Rd(CoordAddr.Rom + (SelTile * 2) + 1, romdat))
			y = Rd(CoordAddr.Rom + (SelTile * 2) + 0, romdat)
			patbyte = Rd(FrameAddr.Rom + (SelTile * 2) + 2, romdat)
			attrbyte = Rd(FrameAddr.Rom + (SelTile * 2) + 3, romdat)
		End If

		TileIndexLab.Text = "Tile: " & (Hex(SelTile).ToString()).PadLeft(2, "0"c) & " / " & (Hex(FrameLastTile)).PadLeft(2, "0"c)
		SetUDCool(TileXUD, Hex(x), 2)
		SetUDCool(TileYUD, Hex(y), 2)
		SetUDCool(TilePatUD, Hex(patbyte), 2)
		SetCheckCool(VFlipCheck, CShort(attrbyte And &H80S) / &H80S)
		SetCheckCool(HFlipCheck, CShort(attrbyte And &H40S) / &H40S)
		SetCheckCool(BGPrioCheck, CShort(attrbyte And &H20S) / &H20S)
		Refresh_ChangeTilePal()
		'If SelTile = 0 Then
		'    PrevTileBtn.Enabled = False
		'Else
		'    PrevTileBtn.Enabled = True
		'End If
		'If SelTile = FrameLastTile Then
		'    NextTileBtn.Enabled = False
		'Else
		'    NextTileBtn.Enabled = True
		'End If

		Refresh_EditTile()
	End Sub

	'* Tile Edit field is to be updated.
	Public Sub Refresh_EditTile()
		Dim b0, y, a, x, b1, x1, y1 As Integer
		Dim tilePicTileWidth As Integer = 16
		Dim tilePicTileWidthMinusGridLine As Integer = tilePicTileWidth - 2
		Dim attrbyte As Integer
		Dim patbyte As Integer
		Dim palID As Integer

		If ASM_FileModeOn Or autoLoadASM_ModeOff = False Then
			If ASM_FileModeSpriteLoaded Then
				patbyte = Dec(currentSprite._tilesID(SelTile))
				attrbyte = Dec(currentSprite._tilesAttributes(SelTile))
			End If
		Else
			patbyte = Rd(FrameAddr.Rom + (SelTile * 2) + 2, romdat)
			attrbyte = Rd(FrameAddr.Rom + (SelTile * 2) + 3, romdat)
		End If

		For y = 0 To 7
			b0 = ReadPatternMap((patbyte * &H10S) + 0 + y)
			b1 = ReadPatternMap((patbyte * &H10S) + 8 + y)
			For x = 0 To 7
				x1 = x * tilePicTileWidth + 1 ' To Allow black line at left and top
				y1 = y * tilePicTileWidth + 1 ' To Allow black line at left and top
				a = ((b0 And ANDtbl(x)) <> 0 And 1) Or ((b1 And ANDtbl(x)) <> 0 And 1 * 2)
				If a Then
					RenderModule.DrawRectangle(tile_bmi, x1, y1, x1 + tilePicTileWidthMinusGridLine, y1 + tilePicTileWidthMinusGridLine, ((CShort(attrbyte And 3) * 4) + a))
				Else 'background
					RenderModule.DrawRectangle(tile_bmi, x1, y1, x1 + tilePicTileWidthMinusGridLine, y1 + tilePicTileWidthMinusGridLine, 0)
				End If
			Next x
		Next y

		tile_bmi.bytesRGB_UpdatedSinceLastRender = True
		RenderModule.RenderPic(PicBTile, tile_bmi)

		' Palette choice
		For a = 0 To 3
			If (a = 0) Then
				palID = 0
			Else
				palID = CShort((attrbyte And 3) * 4) + a
			End If
			RenderModule.DrawRectangleUsingWxH(pal_bmi, 2, (25 * a) + 2, 21, 23, palID)
		Next a

		Refresh_PatternEdColor()
	End Sub

	Private Sub DrawRectangleAround_PatternEdColor(bmip As BITMAPINFO, a As Integer, palID As Integer)
		RenderModule.DrawLineHUsingWxH(bmip, 0, (25 * a), 25, palID)
		RenderModule.DrawLineHUsingWxH(bmip, 0, (25 * a) + 1, 25, palID)
		RenderModule.DrawLineHUsingWxH(bmip, 0, (25 * (a + 1)), 25, palID)
		RenderModule.DrawLineHUsingWxH(bmip, 0, (25 * (a + 1)) + 1, 25, palID)
		RenderModule.DrawLineVUsingWxH(bmip, 0, (25 * a) + 2, 23, palID)
		RenderModule.DrawLineVUsingWxH(bmip, 1, (25 * a) + 2, 23, palID)
		RenderModule.DrawLineVUsingWxH(bmip, 23, (25 * a) + 2, 23, palID)
		RenderModule.DrawLineVUsingWxH(bmip, 24, (25 * a) + 2, 23, palID)
	End Sub

	' User changes Pattern Editor RGBcolor
	Public Sub Refresh_PatternEdColor()
		Dim a As Integer

		For a = 0 To 3
			If a <> PatEdColor Then
				DrawRectangleAround_PatternEdColor(pal_bmi, a, &H40S)
			End If
		Next a

		' Draw last so its outline are over non highlighted ones
		DrawRectangleAround_PatternEdColor(pal_bmi, PatEdColor, &H45S)

		pal_bmi.bytesRGB_UpdatedSinceLastRender = True
		RenderModule.RenderPic(PicBPal, pal_bmi)
	End Sub

	Public Sub Refresh_ChangeTilePal()
		Dim a As Integer
		Dim b, bMax As Integer

		If ASM_FileModeOn Then
			If ASM_FileModeSpriteLoaded Then
				a = Dec(currentSprite._tilesAttributes(SelTile))
			End If
		Else
			a = Rd(FrameAddr.Rom + (SelTile * 2) + 3, romdat)
		End If
		SetTBCoolText(TilePalTB, CStr(a And 3))

		bMax = PalOpt.Length - 1
		For b = 0 To bMax
			If (a And 3) <> b Then
				If PalOpt(b).Checked = True Then
					PalOpt(b).Checked = False
				End If
			End If
		Next

		SetOptCool(PalOpt(a And 3), True)
	End Sub

	Public Sub Refresh_ReportFrameUsage()
		Dim tmpspr As Integer
		FrameUseList.Items.Clear()
		For tmpspr = 0 To &HFFS
			If SpriteFrameUsage(tmpspr, FrameID) = True Then
				FrameUseList.Items.Add(Hex(tmpspr))
			End If
		Next tmpspr

	End Sub

	Public Sub Refresh_FreeSpaceInfo()
		Dim a As Integer
		FreeSpaceList.Items.Clear()
		For a = 0 To DataSegLast
			FreeSpaceList.Items.Add("Seg " & Str(a) & ": $" & Hex(DataSegs(a).Start) & " - $" & Hex(DataSegs(a).EndValue) & ": $" & Hex(gPtrDataMove.SegFreeSpace(a)) & " bytes")
		Next
	End Sub



	'Events ------------------------------------------------------------------------------

	Private Sub Form1_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
		Dim KeyCode As Short = eventArgs.KeyCode
		Dim Shift As Short = eventArgs.KeyData \ &H10000
		Select Case KeyCode
			Case System.Windows.Forms.Keys.Insert
				If DataMovable = 1 Then NewTileBtn_Click(NewTileBtn, New System.EventArgs())
			Case System.Windows.Forms.Keys.Delete
				If DataMovable = 1 Then RemTileBtn_Click(RemTileBtn, New System.EventArgs())
		End Select
	End Sub

	Private Sub SaveBtn_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles SaveBtn.Click
		FileOpen(1, filename, OpenMode.Binary)
		FilePut(1, romdat)
		FileClose(1)
	End Sub

	Private Sub ReloadBtn_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles ReloadBtn.Click
		FileOpen(1, filename, OpenMode.Binary)
		FileGet(1, romdat)
		FileClose(1)
		Refresh_BankChange()
	End Sub

	Private Sub SprBankCombo_SelectedIndexChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles SprBankCombo.SelectedIndexChanged
		If SprBankCombo.Tag <> "" Then Exit Sub
		BankPtrSelect = SprBankCombo.SelectedIndex
		Refresh_BankChange()
	End Sub

	Private Sub FramePageOpt_CheckedChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles _FramePageOpt_0.CheckedChanged, _FramePageOpt_1.CheckedChanged
		If eventSender.Checked Then
			Dim Index As Short = 0

			For Each radioButton As RadioButton In FramePageOpt
				If radioButton.Name = eventSender.Name Then
					Exit For
				End If
				Index += 1
			Next

			If FramePageOpt(Index).Tag <> "" Then Exit Sub
			If FramePageMethod = 0 Then
				Wr(SprAddr.Rom, (Rd(SprAddr.Rom, romdat) And &H7FS) Or (Index * &H80S))
				BuildSprFrameUsageList()
			End If
			Refresh_FramePageChange()
		End If
	End Sub







	Private Sub SprTB_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles SprTB.TextChanged
		If SprTB.Tag <> "" Then Exit Sub
		SetTBCoolNumWithValidation(SprTB, SprTB.Text, &HFFS, 2, True)
		Sprite = VWidth(Dec((SprTB.Text)) And &HFFS, 0, MaxSprite)
		Refresh_SpriteChange()
	End Sub

	Private Sub SprPlusBtn_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles SprPlusBtn.Click
		If (Sprite = MaxSprite) Then Exit Sub
		Sprite += 1
		Refresh_SpriteChange()
	End Sub

	Private Sub SprMinusBtn_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles SprMinusBtn.Click
		If (Sprite = 0) Then Exit Sub
		Sprite -= 1
		Refresh_SpriteChange()
	End Sub

	Private Sub SprAddrTB_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles SprAddrTB.TextChanged
		Dim a As Integer
		If SprAddrTB.Tag <> "" Then Exit Sub
		SetTBCoolNumWithValidation(SprAddrTB, SprAddrTB.Text, 65535, 4, True)
		a = Dec((SprAddrTB.Text))
		Wr((BankPtr(SprPtrBank) + BaseSprLo + Sprite), (a And &HFFS))
		Wr((BankPtr(SprPtrBank) + BaseSprHi + Sprite), (Int(a / &H100S) And &HFFS))
		Refresh_SpriteChange()
	End Sub

	Private Sub SprNewBtn_Click()
		Dim a As Integer
		MsgBox("illegal function of certain doom.")
		a = Sprite
		While a < &HFFS
			TmpAddr.lo = Rd(BankPtr(SprPtrBank) + BaseSprLo + a, romdat)
			TmpAddr.hi = Rd(BankPtr(SprPtrBank) + BaseSprHi + a, romdat)
			'todo: pointer must be legal
			a += 1
		End While
	End Sub

	Private Sub SprKillBtn_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles SprKillBtn.Click
		If SprAddr.Mem >= SprAddrLowBound And SprAddr.Mem <= SprAddrHighBound Then
			gPtrDataMove.IDPointer = SprAddr.Mem
			gPtrDataMove.Pointer = SprAddr.Mem
			gPtrDataMove.Delete(3 + AnimationFrames)
			Wr((BankPtr(SprPtrBank) + BaseSprLo + Sprite), 0)
			Wr((BankPtr(SprPtrBank) + BaseSprHi + Sprite), 0)
			Update_Pointers()
			Refresh_SpriteChange()
			Refresh_FreeSpaceInfo()
		End If
	End Sub

	Private Sub FrameList_SelectedIndexChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles FrameList.SelectedIndexChanged
		If FrameList.Tag <> "" Then Exit Sub
		Frame = FrameList.SelectedIndex
		Refresh_FrameChange()
	End Sub

	Private Sub FrameNextBtn_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles FrameNextBtn.Click
		Frame = Wrap(Frame + 1, 0, AnimationFrames)
		Refresh_FrameChange()
	End Sub

	Private Sub FramePrevBtn_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles FramePrevBtn.Click
		Frame = Wrap(Frame - 1, 0, AnimationFrames)
		Refresh_FrameChange()
	End Sub

	Private Sub AddFrameBtn_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles AddFrameBtn.Click
		Dim a As Integer
		If (AnimationFrames = 127) Then Exit Sub
		gPtrDataMove.IDPointer = SprAddr.Mem
		gPtrDataMove.Pointer = SprAddr.Mem + 2 + Frame
		a = gPtrDataMove.InsertB(1)
		If (a > 0) Then
			MsgBox("Not enough free space in segment " & Str(a - 1))
		Else
			AnimationFrames += 1
			a = Rd(SprAddr.Rom, romdat) And &H80S
			Wr((SprAddr.Rom), AnimationFrames Or a)
			Update_Pointers()
			KeepSelFrame = True
			Refresh_SpriteChange()
			Refresh_FreeSpaceInfo()
		End If
	End Sub

	Private Sub DelFrameBtn_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles DelFrameBtn.Click
		Dim a As Integer
		If (AnimationFrames = 0) Then Exit Sub
		gPtrDataMove.IDPointer = SprAddr.Mem
		gPtrDataMove.Pointer = SprAddr.Mem + 2 + Frame
		gPtrDataMove.Delete(1)
		AnimationFrames -= 1
		a = Rd(SprAddr.Rom, romdat) And &H80S
		Wr((SprAddr.Rom), AnimationFrames Or a)
		If Frame > AnimationFrames Then
			Frame -= 1
		End If
		KeepSelFrame = True
		Refresh_SpriteChange()
		Refresh_FreeSpaceInfo()
	End Sub

	Private Sub FrameSelList_SelectedIndexChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles FrameSelList.SelectedIndexChanged
		If FrameSelList.Tag <> "" Then Exit Sub
		Wr((SprAddr.Rom + 2 + Frame), FrameSelList.SelectedIndex)
		BuildSprFrameUsageList()
		Refresh_FrameIDChange()
		Refresh_FrameChange()
	End Sub

	Private Sub FrameSelTB_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles FrameSelTB.TextChanged
		If FrameSelTB.Tag <> "" Then Exit Sub
		SetTBCoolNumWithValidation(FrameSelTB, FrameSelTB.Text, &HFFS, 2, True)
		Wr((SprAddr.Rom + 2 + Frame), (Dec((FrameSelTB.Text)) And &HFFS))

		BuildSprFrameUsageList()

		Refresh_FrameIDChange()
		Refresh_FrameChange()
	End Sub

	Private Sub FindFrameBtn_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles FindFrameBtn.Click
		Dim tmpframecount, tmpframe, tmpspr As Integer
		tmpframe = (FrameID + 1) And &HFFS
		For tmpframecount = 0 To &HFFS
			For tmpspr = 0 To &HFFS
				If SpriteFrameUsage(tmpspr, tmpframe Or (FramePage * &H100S)) = True Then
					GoTo checknextframe
				End If
			Next tmpspr
			GoTo foundfree
checknextframe:
			tmpframe = (tmpframe + 1) And &HFFS
		Next tmpframecount
		Exit Sub

foundfree:
		Wr((SprAddr.Rom + 2 + Frame), CByte(tmpframe))

		BuildSprFrameUsageList()
		Refresh_FrameIDChange()
		Refresh_FrameChange()
	End Sub

	Private Sub FrameAddrTB_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles FrameAddrTB.TextChanged
		Dim a As Integer
		If FrameAddrTB.Tag <> "" Then Exit Sub
		SetTBCoolNumWithValidation(FrameAddrTB, FrameAddrTB.Text, 65535, 4, True)
		a = Dec((FrameAddrTB.Text))
		Wr((BankPtr(FramePtrBank) + BaseFrameLo + FrameID), (a And &HFFS))
		Wr((BankPtr(FramePtrBank) + BaseFrameHi + FrameID), (Int(a / &H100S) And &HFFS))
		Refresh_FrameChange()
	End Sub

	Private Sub FrameKillBtn_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles FrameKillBtn.Click
		If FrameAddr.Mem >= FrameAddrLowBound And FrameAddr.Mem <= FrameAddrHighBound Then
			gPtrDataMove.IDPointer = FrameAddr.Mem
			gPtrDataMove.Pointer = FrameAddr.Mem
			gPtrDataMove.Delete(2 + ((FrameLastTile + 1) * 2))
			Wr((BankPtr(FramePtrBank) + BaseFrameLo + FrameID), 0)
			Wr((BankPtr(FramePtrBank) + BaseFrameHi + FrameID), 0)
			Update_Pointers()
			SetTBCoolText(SprAddrTB, Hex(SprAddr.Mem))
			Refresh_FrameChange()
			Refresh_FreeSpaceInfo()
		End If
	End Sub

	Private Sub FrameUseList_SelectedIndexChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles FrameUseList.SelectedIndexChanged
		Sprite = Dec((FrameUseList.Text))
		Refresh_SpriteChange()
	End Sub

	Private Sub PairCheck_CheckStateChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles PairCheck.CheckStateChanged
		If PairCheck.Tag <> "" Then Exit Sub
		SetCheckCool(PairCheck, PairCheck.CheckState Xor 1)
	End Sub

	Private Sub CoordSelTB_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles CoordSelTB.TextChanged
		If CoordSelTB.Tag <> "" Then Exit Sub
		SetTBCoolNumWithValidation(CoordSelTB, CoordSelTB.Text, &HFFS, 2, True)
		FrameCoordUsage(FrameID, CoordID) = False
		If (CoordPairs = 1) And (CheckCoordinateIsPair() = True) Then
			FrameCoordPairUsage(FrameID, CoordID2) = False
		End If
		Wr((FrameAddr.Rom + 1), (Dec((CoordSelTB.Text)) And &HFFS))
		Refresh_CoordID_Pointers()
		FrameCoordUsage(FrameID, CoordID) = True
		If (CoordPairs = 1) And (CheckCoordinateIsPair() = True) Then
			FrameCoordUsage(FrameID, CoordID2) = True
		End If
		Refresh_CoordID_Interface()
	End Sub

	Private Sub FindCoordBtn_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles FindCoordBtn.Click
		Dim tmpcoordcount, tmpcoord, tmpframe As Integer
		tmpcoord = (CoordID + 1) And &HFFS
		For tmpcoordcount = 0 To &HFFS
			For tmpframe = 0 To &H1FFS
				If FrameCoordUsage(tmpframe, tmpcoord) Or FrameCoordPairUsage(tmpframe, tmpcoord) Then
					GoTo trynextcoord
				End If
			Next tmpframe
			GoTo foundfree
trynextcoord:
			tmpcoord = (tmpcoord + 1) And &HFFS
		Next tmpcoordcount
		Exit Sub

foundfree:
		FrameCoordUsage(FrameID, CoordID) = False
		If (CoordPairs = 1) And (CheckCoordinateIsPair() = True) Then
			FrameCoordPairUsage(FrameID, CoordID2) = False
		End If
		Wr((FrameAddr.Rom + 1), CByte(tmpcoord))
		Refresh_CoordID_Pointers()
		FrameCoordUsage(FrameID, CoordID) = True
		If (CoordPairs = 1) And (CheckCoordinateIsPair() = True) Then
			FrameCoordUsage(FrameID, CoordID2) = True
		End If
		Refresh_CoordID_Interface()
	End Sub

	Private Sub CoordList_SelectedIndexChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles CoordList.SelectedIndexChanged
		If CoordList.SelectedIndex = -1 Then Exit Sub

		If CoordList.Tag <> "" Then Exit Sub
		FrameCoordUsage(FrameID, CoordID) = False
		If (CoordPairs = 1) And (CheckCoordinateIsPair() = True) Then
			FrameCoordPairUsage(FrameID, CoordID2) = False
		End If
		Wr((FrameAddr.Rom + 1), CoordList.SelectedIndex)
		Refresh_CoordID_Pointers()
		FrameCoordUsage(FrameID, CoordID) = True
		If (CoordPairs = 1) And (CheckCoordinateIsPair() = True) Then
			FrameCoordUsage(FrameID, CoordID2) = True
		End If
		Refresh_CoordID_Interface()
	End Sub

	Private Sub CoordAddrTB_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles CoordAddrTB.TextChanged
		Dim a As Integer
		If CoordAddrTB.Tag <> "" Then Exit Sub
		SetTBCoolNumWithValidation(CoordAddrTB, CoordAddrTB.Text, 65535, 4, True)
		a = Dec((CoordAddrTB.Text))
		Wr((BankPtr(CoordPtrBank) + BaseCoordLo + CoordID), (a And &HFFS))
		Wr((BankPtr(CoordPtrBank) + BaseCoordHi + CoordID), (Int(a / &H100S) And &HFFS))
		Refresh_CoordID()
	End Sub

	Private Sub CoordKillBtn_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles CoordKillBtn.Click
		Dim boa As Boolean
		If CoordAddr.Mem >= CoordAddrLowBound And CoordAddr.Mem <= CoordAddrHighBound Then
			boa = CheckCoordinateIsPair()
			gPtrDataMove.IDPointer = CoordAddr.Mem
			gPtrDataMove.Pointer = CoordAddr.Mem
			gPtrDataMove.Delete(((FrameLastTile + 1) * 2))
			Wr((BankPtr(CoordPtrBank) + BaseCoordLo + CoordID), 0)
			Wr((BankPtr(CoordPtrBank) + BaseCoordHi + CoordID), 0)
			Update_Pointers()
			If (boa = True) And (CoordPairs = 1) Then
				gPtrDataMove.IDPointer = Coord2Addr.Mem
				gPtrDataMove.Pointer = Coord2Addr.Mem
				gPtrDataMove.Delete(((FrameLastTile + 1) * 2))
				Wr((BankPtr(CoordPtrBank) + BaseCoordLo + CoordID2), 0)
				Wr((BankPtr(CoordPtrBank) + BaseCoordHi + CoordID2), 0)
				Update_Pointers()
			End If
			SetTBCoolText(SprAddrTB, Hex(SprAddr.Mem))
			SetTBCoolText(FrameAddrTB, Hex(FrameAddr.Mem))
			Refresh_CoordID()
			Refresh_FreeSpaceInfo()
		End If
	End Sub

	Private Sub NewTileBtn_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles NewTileBtn.Click
		Dim a As Integer
		Dim CoordinateWasPair As Boolean
		Dim ins_status As Integer
		Dim rombackup() As Byte

		ReDim rombackup(romsize)
		Array.Copy(romdat, rombackup, romdat.Length)

		ins_status = 0
		If DisableCoordInsDel = 0 Then
			CoordinateWasPair = CheckCoordinateIsPair()
			gPtrDataMove.IDPointer = CoordAddr.Mem
			gPtrDataMove.Pointer = CoordAddr.Mem + ((FrameLastTile + 1) * 2)
			ins_status = ins_status Or gPtrDataMove.InsertB(&HFCS)
			ins_status = ins_status Or gPtrDataMove.InsertB(&HFCS)
			Update_Pointers()
			If (CoordinateWasPair = True) And (CoordPairs = 1) Then
				gPtrDataMove.IDPointer = Coord2Addr.Mem
				gPtrDataMove.Pointer = Coord2Addr.Mem + ((FrameLastTile + 1) * 2)
				ins_status = ins_status Or gPtrDataMove.InsertB(&HFCS)
				ins_status = ins_status Or gPtrDataMove.InsertB(&HFCS)
				Update_Pointers()
			End If
		End If
		gPtrDataMove.IDPointer = FrameAddr.Mem
		gPtrDataMove.Pointer = FrameAddr.Mem + ((FrameLastTile + 1) * 2) + 2
		ins_status = ins_status Or gPtrDataMove.InsertB(0)
		ins_status = ins_status Or gPtrDataMove.InsertB(0)
		If ins_status > 0 Then
			MsgBox("Not enough free space.")
			Array.Copy(rombackup, romdat, rombackup.Length)
			Exit Sub
		End If
		Update_Pointers()
		Select Case CoordinateBankSelect
			Case 0 'All other games
				Wr(FrameAddr.Rom + 0, VWidth(Rd(FrameAddr.Rom + 0, romdat) + 1, 0, 255))
			Case 1 'Mighty Final Fight & Mega Man 3
				a = Rd(FrameAddr.Rom + 0, romdat) And &H80S
				Wr(FrameAddr.Rom + 0, VWidth(CShort(Rd(FrameAddr.Rom + 0, romdat) And &H7FS) + 1, 0, 127) Or a)
		End Select
		TileZPrio = 1
		FrameLastTile = VWidth(FrameLastTile + 1, 0, 255)
		SelTile = FrameLastTile
		KeepSelTile = True
		If DisableCoordInsDel = 0 Then
			CoordTileCount(CoordID) = CoordTileCount(CoordID) + 1S
			CoordList.Items(CoordID) = $"{Hex(CoordID)} - ({CoordTileCount(CoordID)} t)"
			If (CoordinateWasPair = True) And (CoordPairs = 1) Then
				CoordTileCount(CoordID2) = CoordTileCount(CoordID2) + 1
				CoordList.Items(CoordID2) = $"{Hex(CoordID2)} - ({CoordTileCount(CoordID2)} t)"
				' Old instruction - didn't work anyway so couldn't test it
				' VB6.SetItemString(CoordList, CoordID2, Hex(CoordID2) & " - (" & CStr(CoordTileCount(CoordID2)) & " t)")
			End If
		End If
		SetTBCoolText(SprAddrTB, Hex(SprAddr.Mem)) 'Might be changed
		Refresh_FrameChange()
		Refresh_FreeSpaceInfo()
		SetOptCool(TilePrioOpt(1), True)
	End Sub

	Private Sub RemTileBtn_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles RemTileBtn.Click
		Dim a As Integer
		Dim CoordinateWasPair As Boolean
		If DisableCoordInsDel = 0 Then
			CoordinateWasPair = CheckCoordinateIsPair()
			gPtrDataMove.IDPointer = CoordAddr.Mem
			gPtrDataMove.Pointer = CoordAddr.Mem + (SelTile * 2)
			gPtrDataMove.Delete(2)
			Update_Pointers()
			If (CoordinateWasPair = True) And (CoordPairs = 1) Then
				gPtrDataMove.IDPointer = Coord2Addr.Mem
				gPtrDataMove.Pointer = Coord2Addr.Mem + (SelTile * 2)
				gPtrDataMove.Delete(2)
				Update_Pointers()
			End If
		End If
		gPtrDataMove.IDPointer = FrameAddr.Mem
		gPtrDataMove.Pointer = FrameAddr.Mem + 2 + (SelTile * 2)
		gPtrDataMove.Delete(2)
		Update_Pointers()
		Select Case CoordinateBankSelect
			Case 0 'All other games
				Wr(FrameAddr.Rom + 0, VWidth(Rd(FrameAddr.Rom + 0, romdat) - 1, 0, 255))
			Case 1 'Mighty Final Fight & Mega Man 3
				a = Rd(FrameAddr.Rom + 0, romdat) And &H80S
				Wr(FrameAddr.Rom + 0, VWidth(CShort(Rd(FrameAddr.Rom + 0, romdat) And &H7FS) - 1, 0, 127) Or a)
		End Select
		FrameLastTile = VWidth(FrameLastTile - 1, 0, 255)
		SelTile = FrameLastTile
		KeepSelTile = True
		If DisableCoordInsDel = 0 Then
			CoordTileCount(CoordID) = CoordTileCount(CoordID) - 1
			CoordList.Items.RemoveAt(CoordID)
			CoordList.Items.Insert(CoordID, Hex(CoordID) & " - (" & CoordTileCount(CoordID).ToString() & " t)")
			' Old instruction - didn't work anyway so couldn't test it
			' VB6.SetItemString(CoordList, CoordID, Hex(CoordID) & " - (" & CStr(CoordTileCount(CoordID)) & " t)")
			If (CoordinateWasPair = True) And (CoordPairs = 1) Then
				CoordTileCount(CoordID2) = CoordTileCount(CoordID2) - 1
				' Old instruction - didn't work anyway so couldn't test it
				' VB6.SetItemString(CoordList, CoordID2, Hex(CoordID2) & " - (" & CStr(CoordTileCount(CoordID2)) & " t)")
				CoordList.Items.RemoveAt(CoordID2)
				CoordList.Items.Insert(CoordID2, $"{Hex(CoordID2)} - ({CoordTileCount(CoordID2)} t)")
			End If
		End If
		SetTBCoolText(SprAddrTB, Hex(SprAddr.Mem)) 'Might be changed
		Refresh_FrameChange()
		Refresh_FreeSpaceInfo()
	End Sub

	Private Sub PrevTileBtn_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles PrevTileBtn.Click
		If SelTile > 0 Then
			SelTile -= 1
		Else
			SelTile = FrameLastTile
		End If
		Refresh_SelTile()
		Refresh_RedrawSprite()
	End Sub

	Private Sub NextTileBtn_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles NextTileBtn.Click
		If SelTile < FrameLastTile Then
			SelTile += 1
		Else
			SelTile = 0
		End If
		Refresh_SelTile()
		Refresh_RedrawSprite()
	End Sub

	Private Sub BGPrioCheck_CheckStateChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles BGPrioCheck.CheckStateChanged
		If BGPrioCheck.Tag <> "" Then Exit Sub
		If ASM_FileModeOn Then
			If ASM_FileModeSpriteLoaded Then
				currentSprite._tilesAttributes(SelTile) = Hex(Dec(currentSprite._tilesAttributes(SelTile)) Xor &H20S).PadLeft(2, "0"c)
			End If
		Else
			Wr(FrameAddr.Rom + (SelTile * 2) + 3, (Rd(FrameAddr.Rom + (SelTile * 2) + 3, romdat) Xor &H20S))
		End If
		'Refresh_RedrawSprite
	End Sub

	Private Sub HFlipCheck_CheckStateChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles HFlipCheck.CheckStateChanged
		If HFlipCheck.Tag <> "" Then Exit Sub
		If ASM_FileModeOn Then
			If ASM_FileModeSpriteLoaded Then
				currentSprite._tilesAttributes(SelTile) = Hex(Dec(currentSprite._tilesAttributes(SelTile)) Xor &H40S).PadLeft(2, "0"c)
			End If
		Else
			Wr(FrameAddr.Rom + (SelTile * 2) + 3, (Rd(FrameAddr.Rom + (SelTile * 2) + 3, romdat) Xor &H40S))
		End If
		Refresh_RedrawSprite()
	End Sub

	Private Sub VFlipCheck_CheckStateChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles VFlipCheck.CheckStateChanged
		If VFlipCheck.Tag <> "" Then Exit Sub
		If ASM_FileModeOn Then
			If ASM_FileModeSpriteLoaded Then
				currentSprite._tilesAttributes(SelTile) = Hex(Dec(currentSprite._tilesAttributes(SelTile)) Xor &H80S).PadLeft(2, "0"c)
			End If
		Else
			Wr(FrameAddr.Rom + (SelTile * 2) + 3, (Rd(FrameAddr.Rom + (SelTile * 2) + 3, romdat) Xor &H80S))
		End If
		Refresh_RedrawSprite()
	End Sub

	Private Sub TilePalChange(index As Integer)
		Dim a As Integer
		If PalOpt(index).Tag <> "" Then Exit Sub
		If ASM_FileModeOn Then
			If ASM_FileModeSpriteLoaded Then
				a = Dec(currentSprite._tilesAttributes(SelTile)) And &HFCS
				currentSprite._tilesAttributes(SelTile) = Hex((index And &H3S) Or a)
			End If
		Else
			a = Rd(FrameAddr.Rom + (SelTile * 2) + 3, romdat) And &HFCS
			Wr((FrameAddr.Rom + (SelTile * 2) + 3), (index And &H3S) Or a)
		End If
		Refresh_ChangeTilePal()
		Refresh_EditTile()
		Refresh_RedrawSprite()
		CHR_MapChanged(index And &H3S)
	End Sub

	Private Sub PalOpt_CheckedChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles _PalOpt_0.CheckedChanged, _PalOpt_1.CheckedChanged, _PalOpt_2.CheckedChanged, _PalOpt_3.CheckedChanged
		If eventSender.Checked Then
			Dim Index As Short = 0

			For Each radioButton As RadioButton In PalOpt
				If radioButton.Name = eventSender.Name Then
					Exit For
				End If
				Index += 1
			Next

			TilePalChange(Index)
		End If
	End Sub

	Private Sub PalTB_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles _PalTB_0.TextChanged, _PalTB_1.TextChanged, _PalTB_2.TextChanged, _PalTB_3.TextChanged, _PalTB_4.TextChanged, _PalTB_5.TextChanged, _PalTB_6.TextChanged, _PalTB_7.TextChanged, _PalTB_8.TextChanged, _PalTB_9.TextChanged, _PalTB_10.TextChanged, _PalTB_11.TextChanged
		Dim Index As Short = 0
		Dim a, b As Integer

		For Each textBox As TextBox In PalTB
			If textBox.Name = eventSender.Name Then
				Exit For
			End If
			Index += 1
		Next

		' To prevent value to overwrite config file before we read from them during initialisation
		If Manual_Init_Later_Happened Then
			Try
				' When starting program, config file is opened so it would crash, the try then catches the error i, that case
				SetCfg((PalTB(Index).Name), CObj(Dec(PalTB(Index).Text)))
			Catch ex As Exception

			End Try
		End If

		If PalTB(Index).Tag <> "" Then Exit Sub

		SetTBCoolNumWithValidation(PalTB(Index), PalTB(Index).Text, &H3FS, 2, True)

		a = Int(Index / 3)
		b = (Index - (a * 3)) + 1 + (a * 4)
		SprPal(b) = (Dec(PalTB(Index).Text) And &H3FS)
		Reload_Bitmap_Palettes()
		PalPic(Index).BackColor = System.Drawing.ColorTranslator.FromOle(RGBmirr(NESPAL(SprPal(b))))
		CHR_MapChanged()
	End Sub

	Private Sub PalPic_MouseUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles _PalPic_0.MouseUp, _PalPic_1.MouseUp, _PalPic_2.MouseUp, _PalPic_3.MouseUp, _PalPic_4.MouseUp, _PalPic_5.MouseUp, _PalPic_6.MouseUp, _PalPic_7.MouseUp, _PalPic_8.MouseUp, _PalPic_9.MouseUp, _PalPic_10.MouseUp, _PalPic_11.MouseUp
		Dim Button As Short = eventArgs.Button \ &H100000
		Dim Index As Short = 0
		Dim a, b As Integer

		For Each pictureBox As PictureBox In PalPic
			If pictureBox.Name = eventSender.Name Then
				Exit For
			End If
			Index += 1
		Next

		a = Int(Index / 3)
		b = (Index - (a * 3)) + 1 + (a * 4)

		If (Button And 1) Then
			SprPal(b) = VWidth(SprPal(b) + 1, 0, &H3FS)
		End If
		If (Button And 2) Then
			SprPal(b) = VWidth(SprPal(b) - 1, 0, &H3FS)
		End If

		Reload_Bitmap_Palettes()
		PalPic(Index).BackColor = System.Drawing.ColorTranslator.FromOle(RGBmirr(NESPAL(SprPal(b))))
		SetTBCoolText(PalTB(Index), Hex(SprPal(b)))
		CHR_MapChanged()
	End Sub

	Private Sub PatCopyBtn_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles PatCopyBtn.Click
		If ASM_FileModeOn And ASM_FileModeSpriteLoaded = False Then Exit Sub

		Dim patbyte As Integer
		Dim a As Integer

		If ASM_FileModeSpriteLoaded Then
			patbyte = Dec(currentSprite._tilesID(SelTile))
		Else
			patbyte = Rd(FrameAddr.Rom + (SelTile * 2) + 2, romdat)
		End If

		For a = 0 To &HFS
			PatClipboard(a) = ReadPatternMap((patbyte * &H10S) + a)
		Next a

	End Sub

	Private Sub PatPasteBtn_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles PatPasteBtn.Click
		If ASM_FileModeOn And ASM_FileModeSpriteLoaded = False Then Exit Sub

		Dim patbyte As Integer
		Dim a As Integer

		If ASM_FileModeSpriteLoaded Then
			patbyte = Dec(currentSprite._tilesID(SelTile))
		Else
			patbyte = Rd(FrameAddr.Rom + (SelTile * 2) + 2, romdat)
		End If

		For a = 0 To &HFS
			WritePatternMap((patbyte * &H10S) + a, PatClipboard(a))
		Next a

		CHR_MapChanged()
	End Sub

	Private Sub CenterBtn_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles CenterBtn.Click
		Dim rely, xmin, ymin, x, a, y, ymax, xmax, relx As Integer
		Dim CoordinateWasPair As Boolean

		ymin = &HFFS
		xmin = &HFFS
		ymax = 0
		For a = 0 To FrameLastTile
			If ASM_FileModeOn Then
				If ASM_FileModeSpriteLoaded Then
					y = Wrap128(Dec(coordinatesArray(LstASM_Mode_Coordinates.SelectedIndex)._Y(a)))
					x = Wrap128(Dec(coordinatesArray(LstASM_Mode_Coordinates.SelectedIndex)._X(a)))
				End If
			Else
				y = Wrap128(Rd(CoordAddr.Rom + (a * 2) + 0, romdat))
				x = Wrap128(Rd(CoordAddr.Rom + (a * 2) + 1, romdat))
			End If
			If (y < ymin) Then ymin = y
			If (y + 8) > ymax Then ymax = (y + 8)
			If (x < xmin) Then xmin = x
			If (x + 8) > xmax Then xmax = (x + 8)
		Next a
		rely = ymin - (&H80S - Int((ymax - ymin) / 2))
		relx = xmin - (&H80S - Int((xmax - xmin) / 2))
		CoordinateWasPair = CheckCoordinateIsPair()

		For a = 0 To FrameLastTile
			If ASM_FileModeOn Then
				If ASM_FileModeSpriteLoaded Then
					coordinatesArray(LstASM_Mode_Coordinates.SelectedIndex)._Y(a) = Hex((Dec(coordinatesArray(LstASM_Mode_Coordinates.SelectedIndex)._Y(a)) - rely) And &HFFS).PadLeft(2, "0"c)
					coordinatesArray(LstASM_Mode_Coordinates.SelectedIndex)._X(a) = Hex((Dec(coordinatesArray(LstASM_Mode_Coordinates.SelectedIndex)._X(a)) - relx) And &HFFS).PadLeft(2, "0"c)
				End If
			Else
				y = ((Rd(CoordAddr.Rom + (a * 2) + 0, romdat) - rely) And &HFFS)
				x = ((Rd(CoordAddr.Rom + (a * 2) + 1, romdat) - relx) And &HFFS)
				Wr(CoordAddr.Rom + (a * 2) + 0, CByte(y))
				Wr(CoordAddr.Rom + (a * 2) + 1, CByte(x))
				If (CoordinateWasPair = True) And (CoordPairs = 1) Then
					Wr(Coord2Addr.Rom + (a * 2) + 0, CByte(y))
					Wr(Coord2Addr.Rom + (a * 2) + 1, X_Flip(x))
				End If
			End If
		Next a
		Refresh_SelTile() ' To Refresh Properties
		Refresh_RedrawSprite()
	End Sub

	Private Sub CleanUpBtn_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles CleanUpBtn.Click
		Dim a, b As Integer
		Dim gapcount, countmode, maprelative As Integer

		MakeUsageMap()

		maprelative = 0
		For a = &H0S To &H7FFFS
			Select Case countmode
				Case 0
					If UsageMap(a) = 0 Then
						countmode = 1
						gapcount = 1
					End If
				Case 1
					If UsageMap(a) > 0 Then
						b = (a - gapcount - maprelative) Or &H8000
						gPtrDataMove.IDPointer = b
						gPtrDataMove.Pointer = b
						gPtrDataMove.Delete(gapcount)
						maprelative += gapcount
						countmode = 0
					Else
						gapcount += 1
					End If
			End Select
		Next a
		Refresh_BankChange()
		Refresh_FreeSpaceInfo()
	End Sub

	Private Sub PMapDoBtn_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles PMapDoBtn.Click
		Dim d, b, a, c, e As Integer
		a = Dec((PMapFirstPat.Text)) And &HFFS
		b = Dec((PMapLastPat.Text)) And &HFFS
		c = Dec((PMapROMOffs.Text))
		For d = a To b
			For e = 0 To 15
				PatternMap((d * 16) + e) = c + e
			Next e
			c += 16
		Next d
		CHR_MapChanged()
	End Sub

	Private Sub TilePrioOpt_CheckedChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles _TilePrioOpt_0.CheckedChanged, _TilePrioOpt_1.CheckedChanged
		If eventSender.Checked Then
			Dim Index As Short = 0

			For Each radioButton As RadioButton In TilePrioOpt
				If radioButton.Name = eventSender.Name Then
					Exit For
				End If
				Index += 1
			Next
			TileZPrio = Index
		End If
	End Sub

	Private Sub MoveAllTilesCheck_CheckStateChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MoveAllTilesCheck.CheckStateChanged
		If MoveAllTilesCheck.Tag <> "" Then Exit Sub
		MoveAllTiles = MoveAllTilesCheck.CheckState
	End Sub

	Private Sub PicVScroll_Change(ByVal newScrollValue As Integer)
		If ScrollBars_ProgramChange = True Then Exit Sub
		ViewY = newScrollValue
		Refresh_ViewXY()
		Refresh_ReBlit()
	End Sub

	Private Sub PicHScroll_Change(ByVal newScrollValue As Integer)
		If ScrollBars_ProgramChange = True Then Exit Sub
		ViewX = newScrollValue
		Refresh_ViewXY()
		Refresh_ReBlit()
	End Sub

	Private Sub AnimateCheck_CheckStateChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles AnimateCheck.CheckStateChanged
		If AnimateCheck.Tag <> "" Then Exit Sub
		Animate = AnimateCheck.CheckState
		Timer1.Enabled = Animate
	End Sub

	Private Sub Timer1_Tick(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Timer1.Tick
		If (AnimateFC >= AnimationDelay) Then
			AnimateFC = 0
			If (Frame >= AnimationFrames) Then
				Frame = 0
			Else
				Frame += 1
			End If
			Refresh_FrameChange()
		Else
			AnimateFC += 1
		End If
	End Sub

	Private Sub AnimSpeedOpt_CheckedChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles _AnimSpeedOpt_0.CheckedChanged, _AnimSpeedOpt_1.CheckedChanged, _AnimSpeedOpt_2.CheckedChanged
		If eventSender.Checked Then
			Dim Index As Short = 0

			For Each radioButton As RadioButton In AnimSpeedOpt
				If radioButton.Name = eventSender.Name Then
					Exit For
				End If
				Index += 1
			Next
			AnimSpeed = Index
			Select Case AnimSpeed
				Case 0 : Timer1.Interval = 16
				Case 1 : Timer1.Interval = 32
				Case 2 : Timer1.Interval = 8
			End Select
		End If
	End Sub

	Private Sub ZoomOpt_CheckedChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles _ZoomOpt_0.CheckedChanged, _ZoomOpt_1.CheckedChanged, _ZoomOpt_2.CheckedChanged, _ZoomOpt_3.CheckedChanged
		If eventSender.Checked Then
			Dim Index As Short = 0

			For Each radioButton As RadioButton In ZoomOpt
				If radioButton.Name = eventSender.Name Then
					Exit For
				End If
				Index += 1
			Next
			If ZoomOpt(Index).Tag <> "" Then Exit Sub
			ViewZoom = (Index + 1)
			RecalcViewXY()
			Refresh_ZoomChange()
		End If
	End Sub
	Private Sub ZoomOptCHR_Map_CheckedChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles _ZoomOptCHR_Map_0.CheckedChanged, _ZoomOptCHR_Map_1.CheckedChanged, _ZoomOptCHR_Map_2.CheckedChanged, _ZoomOptCHR_Map_3.CheckedChanged
		If eventSender.Checked Then
			Dim Index As Short = 0

			For Each radioButton As RadioButton In ZoomOptCHR_Map
				If radioButton.Name = eventSender.Name Then
					Exit For
				End If
				Index += 1
			Next
			If ZoomOptCHR_Map(Index).Tag <> "" Then Exit Sub
			CHR_ViewZoom = (Index + 1)
			Refresh_TileMap()

			MeWidthAdjustment()
		End If
	End Sub

	Private Sub CursorCheck_CheckStateChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles CursorCheck.CheckStateChanged
		If CursorCheck.Tag <> "" Then Exit Sub
		ShowCursors = CursorCheck.CheckState
		Refresh_RedrawSprite()
	End Sub

	Private Sub CursorTypeOpt_CheckedChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles _CursorTypeOpt_0.CheckedChanged, _CursorTypeOpt_1.CheckedChanged
		If eventSender.Checked Then
			Dim Index As Short = 0

			For Each radioButton As RadioButton In CursorTypeOpt
				If radioButton.Name = eventSender.Name Then
					Exit For
				End If
				Index += 1
			Next
			If CursorTypeOpt(Index).Tag <> "" Then Exit Sub
			CursorType = Index
			Refresh_RedrawSprite()
		End If
	End Sub

	Private Sub GridCheck_CheckStateChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles GridCheck.CheckStateChanged
		If GridCheck.Tag <> "" Then Exit Sub
		ShowGrid = GridCheck.CheckState
		Refresh_RedrawSprite()
	End Sub

	Private Sub BGColTB_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles _BGColTB_0.TextChanged, _BGColTB_1.TextChanged, _BGColTB_2.TextChanged
		Dim Index As Short = 0
		Dim RGBcolor As Integer

		For Each textBox As TextBox In BGColTB
			If textBox.Name = eventSender.Name Then
				Exit For
			End If
			Index += 1
		Next

		If BGColTB(Index).Tag <> "" Then Exit Sub
		Select Case Index
			Case 0
				BGCol_R = Dec(BGColTB(0).Text) And &HFFS
				SetCfg(("bgcolor_r"), CObj(BGCol_R))
				SetTBCoolText(BGColTB(0), Hex(BGCol_R))
			Case 1
				BGCol_G = Dec(BGColTB(1).Text) And &HFFS
				SetCfg(("bgcolor_g"), CObj(BGCol_G))
				SetTBCoolText(BGColTB(1), Hex(BGCol_G))
			Case 2
				BGCol_B = Dec(BGColTB(2).Text) And &HFFS
				SetCfg(("bgcolor_b"), CObj(BGCol_B))
				SetTBCoolText(BGColTB(2), Hex(BGCol_B))
		End Select

		RGBcolor = RGBmirr(RGB(BGCol_R, BGCol_G, BGCol_B))
		Init_One_Bitmap_Background_Palettes(main_bmi, RGBcolor)
		Init_One_Bitmap_Background_Palettes(tile_bmi, RGBcolor)
		Init_One_Bitmap_Background_Palettes(pal_bmi, RGBcolor)
		Init_One_Bitmap_Background_Palettes(tt_bmi, RGBcolor)

		CHR_MapChanged()
	End Sub

	Private Sub DisableCoordCheck_CheckStateChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles DisableCoordCheck.CheckStateChanged
		If DisableCoordCheck.Tag <> "" Then Exit Sub
		DisableCoordInsDel = DisableCoordCheck.CheckState
	End Sub

	Private Sub WorkPic_MouseMove(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles WorkPic.MouseMove
		Dim Button As Short = eventArgs.Button \ &H100000
		Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
		Dim x As Single = eventArgs.X
		Dim y As Single = eventArgs.Y
		Dim tilex, bitmapx, bitmapy, tiley As Integer
		Dim HitTile, HitFlag As Integer
		Dim TileCount As Integer

		HitFlag = 0
		bitmapx = (Int(x / ViewZoom) + ViewX)
		bitmapy = (Int(y / ViewZoom) + ViewY)
		'Only conduct action if mouse has moved to a new actual bitmap pixel
		If (bitmapx = WorkPic_lastbmx) And (bitmapy = WorkPic_lastbmy) Then Exit Sub

		CurXLab.Text = Hex((bitmapx + &H80S) And &HFFS)
		CurYLab.Text = Hex((bitmapy + &H80S) And &HFFS)

		If Button Then
			If (Button And 1) Then
				If (ASM_ModeAnimFile = "" And ASM_FileModeOn) Then Exit Sub
				Move_Tile_X((bitmapx - WorkPic_lastbmx))
				Move_Tile_Y((bitmapy - WorkPic_lastbmy))
			End If
			If (Button And 2) Then
				'If ViewZoom > 1 Then
				'    ViewX = VWidth(ViewX - (bitmapx - WorkPic_lastbmx), 0, ViewMaxX)
				'    ViewY = VWidth(ViewY - (bitmapy - WorkPic_lastbmy), 0, ViewMaxY)
				'Else
				'    ViewX = VWidth(ViewX - (bitmapx - WorkPic_lastbmx), ViewMaxX, 0)
				'    ViewY = VWidth(ViewY - (bitmapy - WorkPic_lastbmy), ViewMaxY, 0)
				'End If
				ViewX = VWidth(ViewX - (bitmapx - WorkPic_lastbmx), ViewMinX, ViewMaxX)
				ViewY = VWidth(ViewY - (bitmapy - WorkPic_lastbmy), ViewMinY, ViewMaxY)
				bitmapx -= (bitmapx - WorkPic_lastbmx)
				bitmapy -= (bitmapy - WorkPic_lastbmy)
				Refresh_ViewXY()
				Refresh_ReBlit()
			End If

		Else

			Select Case TileZPrio
				Case 0
					For TileCount = 0 To FrameLastTile
						If ASM_FileModeOn Then
							If ASM_FileModeSpriteLoaded Then
								tilex = (Dec(currentCoordinate._X(TileCount)) + &H80S) And &HFFS
								tiley = (Dec(currentCoordinate._Y(TileCount)) + &H80S) And &HFFS
							End If
						Else
							tilex = (Rd(CoordAddr.Rom + (TileCount * 2) + 1, romdat) + &H80S) And &HFFS
							tiley = (Rd(CoordAddr.Rom + (TileCount * 2) + 0, romdat) + &H80S) And &HFFS
						End If
						If (bitmapx >= tilex) And (bitmapx <= (tilex + 7)) And (bitmapy >= tiley) And (bitmapy <= (tiley + 7)) Then
							HitTile = TileCount
							HitFlag = 1
							GoTo havehitsprite
						End If
					Next TileCount
				Case 1
					For TileCount = FrameLastTile To 0 Step -1
						If ASM_FileModeOn Then
							If ASM_FileModeSpriteLoaded Then
								tilex = (Dec(currentCoordinate._X(TileCount)) + &H80S) And &HFFS
								tiley = (Dec(currentCoordinate._Y(TileCount)) + &H80S) And &HFFS
							End If
						Else
							tilex = (Rd(CoordAddr.Rom + (TileCount * 2) + 1, romdat) + &H80S) And &HFFS
							tiley = (Rd(CoordAddr.Rom + (TileCount * 2) + 0, romdat) + &H80S) And &HFFS
						End If
						If (bitmapx >= tilex) And (bitmapx <= (tilex + 7)) And (bitmapy >= tiley) And (bitmapy <= (tiley + 7)) Then
							HitTile = TileCount
							HitFlag = 1
							GoTo havehitsprite
						End If
					Next TileCount
			End Select
havehitsprite:

			If (HitFlag = 1) And (HitTile <> HoverTile) Then
				HoverTile = HitTile
				Refresh_RedrawSprite()
			End If

		End If

		WorkPic_lastbmx = bitmapx
		WorkPic_lastbmy = bitmapy
	End Sub

	Private Sub WorkPic_MouseDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles WorkPic.MouseDown
		Dim Button As Short = eventArgs.Button \ &H100000
		Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
		Dim x As Single = eventArgs.X
		Dim y As Single = eventArgs.Y

		If (Button And 1) Then
			If (ASM_ModeAnimFile = "" And ASM_FileModeOn) Then Exit Sub
			SelTile = HoverTile
			Refresh_SelTile()
			Refresh_RedrawSprite()
		End If
		'One-click viewport move code
		'If (Button And 2) Then
		'bitmapx = Int(X / ViewZoom) + ViewX
		'bitmapy = Int(Y / ViewZoom) + ViewY
		'ViewX = bitmapx - ((Form1.WorkPic.ScaleWidth / 2) / ViewZoom)
		'ViewY = bitmapy - ((Form1.WorkPic.ScaleHeight / 2) / ViewZoom)
		'Refresh_ViewXY
		'CSA_Render.Blit2 spr_bm, grid_bm, WorkPic, main_bmi, ViewZoom, ViewX, ViewY
		'CSA_Render.RenderPic Form1.WorkPic, main_bmi
		'End If
	End Sub

	Private Sub CursorBlinkTimer_Tick(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles CursorBlinkTimer.Tick
		CursorBlinkState = CursorBlinkState Xor 1
		Refresh_RedrawSprite()
	End Sub

	Public Sub MTools_CopyData_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MTools_CopyData.Click
		Dim a, b As Integer
		a = ((FrameLastTile + 1) * 2) - 1
		FrameCoordClipboardSz = FrameLastTile
		ReDim FrameClipBoard(a)
		ReDim CoordClipBoard(a)
		For b = 0 To a
			FrameClipBoard(b) = Rd(FrameAddr.Rom + 2 + b, romdat)
			CoordClipBoard(b) = Rd(CoordAddr.Rom + b, romdat)
		Next b
	End Sub

	Public Sub MTools_PasteData_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MTools_PasteData.Click
		Dim a, b As Integer
		Dim bola As Boolean

		If FrameCoordClipboardSz < 0 Then Exit Sub
		If (FrameLastTile < FrameCoordClipboardSz) Then
			b = FrameLastTile
		Else
			b = FrameCoordClipboardSz
		End If
		bola = CheckCoordinateIsPair()

		For a = 0 To b
			Wr(FrameAddr.Rom + 2 + (a * 2), FrameClipBoard(a * 2))
			Wr(FrameAddr.Rom + 3 + (a * 2), FrameClipBoard((a * 2) + 1))
			Wr(CoordAddr.Rom + (a * 2), CoordClipBoard(a * 2))
			Wr(CoordAddr.Rom + (a * 2) + 1, CoordClipBoard((a * 2) + 1))
			If (bola = True) And (CoordPairs = 1) Then
				Wr(Coord2Addr.Rom + (a * 2), CoordClipBoard(a * 2))
				Wr(Coord2Addr.Rom + (a * 2) + 1, X_Flip(CInt(CoordClipBoard((a * 2) + 1))))
			End If
		Next a
		Refresh_FrameChange()
	End Sub

	Public Sub MTools_ResetAll_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MTools_ResetAll.Click
		Dim openwnd As New ClsDialog
		Dim srcfilename As String
		Dim b, a, c As Integer
		Dim ba As Byte
		Dim Title As String = "Specify unhacked ROM"

		Dim InitDir As String = ""
		Dim DefExt As String = ""
		Dim Filter As String = "nes roms (*.nes)|*.nes|all files (*.*)|*.*"
		Dim flags As ClsDialog.DialogFlags = ClsDialog.DialogFlags.CHECKFILEEXISTS Or ClsDialog.DialogFlags.CHECKPATHEXISTS

		LockPictureBoxes()

		srcfilename = openwnd.ShowOpen(Me, Title, flags, InitDir, DefExt, Filter)
		If Len(srcfilename) = 0 Then
			MsgBox("Thats not a filename!")
			Exit Sub
		End If
		srcfilename = Common.Left(srcfilename, Len(srcfilename))
		FileOpen(1, srcfilename, OpenMode.Binary)
		For a = 0 To ResetAreas
			c = ResetArea_Start(a)
			Seek(1, c + 1)
			For b = 0 To (ResetArea_Size(a) - 1)
				FileGet(1, ba)
				Wr(c, ba)
				c += 1
			Next b
		Next a
		FileClose(1)
		Refresh_BankChange()

		UnlockPictureBoxes()
	End Sub

	'Sub ---------------------------------------------------------------------------------

	Public Sub MakeUsageMap()
		Dim b, a, c As Integer
		'Dim spr_nesaddr As clsNESAddr
		Dim tmpspr, tmpframe As Integer
		Dim firstaddr As Integer

		'InitTmpNESAddr spr_nesaddr

		'Map out usage of memory bytes.
		'Used to determine free space, also used for "Clean up" function.

		'NESAddr classes and some other variables are overwritten,
		'so they must be refreshed after this.

		For a = 0 To &H7FFFS
			UsageMap(a) = 0
		Next a

		'Go through each sprite ID.
		For tmpspr = 0 To &HFFS
			SprAddr.lo = Rd(BankPtr(SprPtrBank) + BaseSprLo + tmpspr, romdat)
			SprAddr.hi = Rd(BankPtr(SprPtrBank) + BaseSprHi + tmpspr, romdat)
			If tmpspr = 0 Then
				firstaddr = SprAddr.Mem
			End If

			If (SprAddr.Mem >= firstaddr) And (SprAddr.Mem <= SprAddrHighBound) And (CheckSpriteGood(SprAddr, tmpspr) = True) Then

				a = Rd(SprAddr.Rom, romdat) And &H7FS

				For b = 0 To (2 + a)
					UsageMap((SprAddr.Mem + b) And &H7FFFS) = 1
				Next b
			Else
				Exit For
			End If
		Next tmpspr

		For tmpframe = 1 To &H1FFS
			If tmpframe = &H100S Then GoTo next_framedatausage
			TmpAddr.lo = Rd(BankPtr(FramePtrBank) + BaseFrameLo + tmpframe, romdat)
			TmpAddr.hi = Rd(BankPtr(FramePtrBank) + BaseFrameHi + tmpframe, romdat)
			If tmpframe = 1 Then
				firstaddr = TmpAddr.Mem
			End If
			TmpAddr.Mem += FramePointerAdd
			If (TmpAddr.Mem >= firstaddr) And (TmpAddr.Mem <= FrameAddrHighBound) And (CheckFrameIDGood(tmpframe) = True) Then


				If Not ASM_FileModeOn Then
					Select Case CoordinateBankSelect
						Case 0 'All other games
							FrameLastTile = Rd(TmpAddr.Rom + 0, romdat) - FrameTileNumofBase
						Case 1 'Mighty Final Fight & Mega Man 3
							FrameLastTile = CShort(Rd(TmpAddr.Rom + 0, romdat) And &H7FS) - FrameTileNumofBase
					End Select
				End If

				For a = 0 To ((FrameLastTile + 1) * 2) + 1
					UsageMap((TmpAddr.Mem + a) And &H7FFFS) = 2
				Next a

				a = Rd(TmpAddr.Rom + 1, romdat)

				CoordAddr.lo = Rd(BankPtr(CoordPtrBank) + BaseCoordLo + a, romdat)
				CoordAddr.hi = Rd(BankPtr(CoordPtrBank) + BaseCoordHi + a, romdat)
				CoordAddr.Mem += CoordPointerAdd

				If CoordPairs = 1 Then

					b = (a + 1) And &HFFS

					Coord2Addr.lo = Rd(BankPtr(CoordPtrBank) + BaseCoordLo + b, romdat)
					Coord2Addr.hi = Rd(BankPtr(CoordPtrBank) + BaseCoordHi + b, romdat)
					Coord2Addr.Mem += CoordPointerAdd

					If (Coord2Addr.Mem < CoordAddrLowBound) Or (Coord2Addr.Mem > CoordAddrHighBound) Then
						GoTo framedatausage_nopair
					End If

					If CheckCoordinateIsPair() = True Then
						For c = 0 To ((FrameLastTile + 1) * 2) - 1
							UsageMap((Coord2Addr.Mem + c) And &H7FFFS) = 4
						Next c
					End If

				End If
framedatausage_nopair:

				For c = 0 To ((FrameLastTile + 1) * 2) - 1
					UsageMap((CoordAddr.Mem + c) And &H7FFFS) = 3
				Next c
			Else
				If tmpframe >= &H100S Then
					Exit For
				Else
					tmpframe = &HFFS
				End If
			End If
next_framedatausage:
		Next tmpframe

		For a = 0 To DataSegLast
			b = DataSegs(a).EndValue
			c = 0
			While (UsageMap(b And &H7FFFS) = 0) And (b >= DataSegs(a).Start)
				c += 1
				b -= 1
			End While
			gPtrDataMove.SegFreeSpace(a) = c
			'DataSegs(a).Free = c
		Next a
	End Sub

	Public Sub BuildSprFrameUsageList()
		Dim tmpframe, firstaddr, tmpspr, tmpframepage As Integer
		Dim a, b As Integer
		Dim spr_nesaddr As ClsNESAddr = Nothing

		InitTmpNESAddr(spr_nesaddr)

		'Build Frame usage list
		For tmpspr = 0 To &HFFS
			For tmpframe = 0 To &HFFS
				SpriteFrameUsage(tmpspr, tmpframe) = False
			Next tmpframe
		Next tmpspr

		For tmpspr = 0 To &HFFS
			spr_nesaddr.lo = Rd(BankPtr(SprPtrBank) + BaseSprLo + tmpspr, romdat)
			spr_nesaddr.hi = Rd(BankPtr(SprPtrBank) + BaseSprHi + tmpspr, romdat)
			If tmpspr = 0 Then
				firstaddr = spr_nesaddr.Mem
			End If
			If (spr_nesaddr.Mem >= firstaddr) And (spr_nesaddr.Mem <= SprAddrHighBound) And (CheckSpriteGood(spr_nesaddr, tmpspr) = True) Then
				a = Rd(spr_nesaddr.Rom, romdat)
				Select Case FramePageMethod
					Case 0 'MM4, DwD
						tmpframepage = CShort(a And &H80S) * 2
					Case 1 'MM2
						tmpframepage = CShort(tmpspr And &H80S) * 2
				End Select

				For b = 0 To (a And &H7FS)
					tmpframe = Rd(spr_nesaddr.Rom + 2 + b, romdat) Or tmpframepage
					SpriteFrameUsage(tmpspr, tmpframe) = True
				Next b
			Else
				Exit For
			End If
		Next tmpspr

	End Sub

	Public Sub BuildCoordLists()
		Dim tmpcoord, tmpframe, firstaddr As Integer
		Dim a, b As Integer

		For tmpframe = 0 To &H1FFS
			For a = 0 To &HFFS
				FrameCoordUsage(tmpframe, a) = False
				FrameCoordPairUsage(tmpframe, a) = False
			Next a
		Next tmpframe

		For tmpcoord = 0 To &HFFS
			CoordTileCount(tmpcoord) = 0
		Next tmpcoord

		For tmpframe = 1 To &H1FFS
			If tmpframe = &H100S Then GoTo next_framecoord
			TmpAddr.lo = Rd(BankPtr(FramePtrBank) + BaseFrameLo + tmpframe, romdat)
			TmpAddr.hi = Rd(BankPtr(FramePtrBank) + BaseFrameHi + tmpframe, romdat)
			If tmpframe = 1 Then
				firstaddr = TmpAddr.Mem
			End If
			TmpAddr.Mem += FramePointerAdd
			If (TmpAddr.Mem >= firstaddr) And (TmpAddr.Mem <= FrameAddrHighBound) Then

				If Not ASM_FileModeOn Then
					Select Case CoordinateBankSelect
						Case 0 'All other games
							FrameLastTile = Rd(TmpAddr.Rom + 0, romdat) - FrameTileNumofBase
						Case 1 'Mighty Final Fight & Mega Man 3
							FrameLastTile = CShort(Rd(TmpAddr.Rom + 0, romdat) And &H7FS) - FrameTileNumofBase
					End Select
				End If

				a = Rd(TmpAddr.Rom + 1, romdat)

				If CoordPairs = 1 Then

					CoordAddr.lo = Rd(BankPtr(CoordPtrBank) + BaseCoordLo + a, romdat)
					CoordAddr.hi = Rd(BankPtr(CoordPtrBank) + BaseCoordHi + a, romdat)
					CoordAddr.Mem += CoordPointerAdd

					b = (a + 1) And &HFFS

					Coord2Addr.lo = Rd(BankPtr(CoordPtrBank) + BaseCoordLo + b, romdat)
					Coord2Addr.hi = Rd(BankPtr(CoordPtrBank) + BaseCoordHi + b, romdat)
					Coord2Addr.Mem += CoordPointerAdd

					If CheckCoordinateIsPair() = True Then
						FrameCoordPairUsage(tmpframe, b) = True
						If (FrameLastTile + 1) > CoordTileCount(b) Then
							CoordTileCount(b) = FrameLastTile + 1
						End If
					End If

				End If

				FrameCoordUsage(tmpframe, a) = True
				If (FrameLastTile + 1) > CoordTileCount(a) Then
					CoordTileCount(a) = FrameLastTile + 1
				End If
			Else
				If tmpframe >= &H100S Then
					Exit For
				Else
					tmpframe = &HFFS
				End If
			End If
next_framecoord:
		Next tmpframe

	End Sub

	Public Function CheckSpriteGood(ByRef sprnesaddr As ClsNESAddr, ByRef sprid As Integer) As Boolean
		Dim tmpframepage, tmpframe As Integer
		Dim a, b As Integer

		Select Case FramePageMethod
			Case 0 'MM4, DwD
				tmpframepage = CShort(Rd(sprnesaddr.Rom, romdat) And &H80S) / &H80S
			Case 1 'MM2
				tmpframepage = CShort(sprid And &H80S) / &H80S
		End Select

		a = Rd(sprnesaddr.Rom, romdat) And &H7FS

		'Detect fake sprite by bad status of any used Frame ID.
		For b = 0 To a
			tmpframe = Rd(sprnesaddr.Rom + 2 + b, romdat) Or (tmpframepage * &H100S)
			If CheckFrameIDGood(tmpframe) = False Then
				If DataParseSensitive = 1 Then GoTo fake_sprite
			End If
		Next b

		CheckSpriteGood = True
		Exit Function
fake_sprite:
		CheckSpriteGood = False
	End Function

	Public Function CheckFrameIDGood(ByRef argframeid As Integer) As Boolean
		Dim frame_nesaddr As ClsNESAddr = Nothing
		Dim tmpcoord As Integer
		Dim a As Integer
		InitTmpNESAddr(frame_nesaddr)

		frame_nesaddr.lo = Rd(BankPtr(FramePtrBank) + BaseFrameLo + argframeid, romdat)
		frame_nesaddr.hi = Rd(BankPtr(FramePtrBank) + BaseFrameHi + argframeid, romdat)
		If (frame_nesaddr.Mem < FrameAddrLowBound) Or (frame_nesaddr.Mem > FrameAddrHighBound) Then
			GoTo bad_frame
		End If
		'Not convinced, check tile count of Frame.
		Select Case CoordinateBankSelect
			Case 0 'All other games
				a = Rd(frame_nesaddr.Rom + 0, romdat) - FrameTileNumofBase
			Case 1 'Mighty Final Fight & Mega Man 3
				a = CShort(Rd(frame_nesaddr.Rom + 0, romdat) And &H7FS) - FrameTileNumofBase
		End Select
		If a >= &H40S Then GoTo bad_frame
		tmpcoord = Rd(frame_nesaddr.Rom + 1, romdat)
		If CheckCoordIDGood(tmpcoord) = False Then GoTo bad_frame
		CheckFrameIDGood = True
		Exit Function
bad_frame:
		CheckFrameIDGood = False
	End Function

	Public Function CheckCoordIDGood(ByRef argcoordid As Integer) As Boolean
		Dim coord_nesaddr As ClsNESAddr = Nothing
		InitTmpNESAddr(coord_nesaddr)
		coord_nesaddr.lo = Rd(BankPtr(CoordPtrBank) + BaseCoordLo + argcoordid, romdat)
		coord_nesaddr.hi = Rd(BankPtr(CoordPtrBank) + BaseCoordHi + argcoordid, romdat)
		coord_nesaddr.Mem += CoordPointerAdd
		CheckCoordIDGood = True
		If (coord_nesaddr.Mem < CoordAddrLowBound) Or (coord_nesaddr.Mem > CoordAddrHighBound) Then
			CheckCoordIDGood = False
		End If
	End Function

	'Refresh all memory pointers after data has been inserted or removed.
	Public Sub Update_Pointers()
		SprAddr.lo = Rd(BankPtr(SprPtrBank) + BaseSprLo + Sprite, romdat)
		SprAddr.hi = Rd(BankPtr(SprPtrBank) + BaseSprHi + Sprite, romdat)
		FrameAddr.lo = Rd(BankPtr(FramePtrBank) + BaseFrameLo + FrameID, romdat)
		FrameAddr.hi = Rd(BankPtr(FramePtrBank) + BaseFrameHi + FrameID, romdat)
		FrameAddr.Mem += FramePointerAdd
		CoordAddr.lo = Rd(BankPtr(CoordPtrBank) + BaseCoordLo + CoordID, romdat)
		CoordAddr.hi = Rd(BankPtr(CoordPtrBank) + BaseCoordHi + CoordID, romdat)
		CoordAddr.Mem += CoordPointerAdd
		If CoordPairs = 1 Then
			Coord2Addr.lo = Rd(BankPtr(CoordPtrBank) + BaseCoordLo + CoordID2, romdat)
			Coord2Addr.hi = Rd(BankPtr(CoordPtrBank) + BaseCoordHi + CoordID2, romdat)
			Coord2Addr.Mem += CoordPointerAdd
		End If
	End Sub

	Public Sub Draw_Sprite()
		Dim readFromROM As Boolean = True
		Dim TileCount As Integer
		Dim Tile, y, x, a, Attr As Integer
		Dim PatternMapBuffer(CHR_FilePatternMap.Length - 1) As Integer
		'Draw Sprite ID

		'Frame and Coordinate pointers are already initialized.

		RAW_ZeroBuffer(spr_bm)

		If FrameID = 0 Then Exit Sub

		If usingCHR_FileForTileMap Or ASM_FileModeOn Then
			readFromROM = False
			For a = 0 To CHR_FilePatternMap.Length - 1
				PatternMapBuffer(a) = CInt(CHR_FilePatternMap(a))
			Next
		Else
			PatternMapBuffer = PatternMap
		End If

		If ASM_FileModeOn Then
			If ASM_FileModeSpriteLoaded Then
				For TileCount = FrameLastTile To 0 Step -1
					If (TileCount <> SelTile) Then
						y = Dec(currentCoordinate._Y(TileCount))
						x = Dec(currentCoordinate._X(TileCount))
						Tile = Dec(currentSprite._tilesID(TileCount))
						Attr = Dec(currentSprite._tilesAttributes(TileCount))
						RAW_DrawSprTile(spr_bm, y, x, Tile, Attr, 0, PatternMapBuffer, romdat, readFromROM)
					End If
				Next TileCount

				y = Dec(currentCoordinate._Y(SelTile))
				x = Dec(currentCoordinate._X(SelTile))
				Tile = Dec(currentSprite._tilesID(SelTile))
				Attr = Dec(currentSprite._tilesAttributes(SelTile))
				If (ShowCursors = 1) And (CursorType = 1) Then
					RAW_DrawSprTile(spr_bm, y, x, Tile, Attr, (&H80S + (CursorBlinkState * &H40S)), PatternMapBuffer, romdat, readFromROM)
				Else
					RAW_DrawSprTile(spr_bm, y, x, Tile, Attr, 0, PatternMapBuffer, romdat, readFromROM)
				End If

				If (ShowCursors = 1) And (CursorType = 0) Then
					y = (Dec(currentCoordinate._Y(HoverTile)) + &H80S) And &HFFS
					x = (Dec(currentCoordinate._X(HoverTile)) + &H80S) And &HFFS
					RAW_LineH(spr_bm, x - 1, x + 8, y - 1, &H44S)
					RAW_LineH(spr_bm, x - 1, x + 8, y + 8, &H44S)
					RAW_LineV(spr_bm, x - 1, y - 1, y + 8, &H44S)
					RAW_LineV(spr_bm, x + 8, y - 1, y + 8, &H44S)

					y = (Dec(currentCoordinate._Y(SelTile)) + &H80S) And &HFFS
					x = (Dec(currentCoordinate._X(SelTile)) + &H80S) And &HFFS
					RAW_LineH(spr_bm, x - 1, x + 8, y - 1, &H43S)
					RAW_LineH(spr_bm, x - 1, x + 8, y + 8, &H43S)
					RAW_LineV(spr_bm, x - 1, y - 1, y + 8, &H43S)
					RAW_LineV(spr_bm, x + 8, y - 1, y + 8, &H43S)
				End If
			End If
		Else
			For TileCount = FrameLastTile To 0 Step -1
				If (TileCount <> SelTile) Then
					y = Rd(CoordAddr.Rom + (TileCount * 2) + 0, romdat)
					x = Rd(CoordAddr.Rom + (TileCount * 2) + 1, romdat)
					Tile = Rd(FrameAddr.Rom + (TileCount * 2) + 2, romdat)
					Attr = Rd(FrameAddr.Rom + (TileCount * 2) + 3, romdat)
					RAW_DrawSprTile(spr_bm, y, x, Tile, Attr, 0, PatternMapBuffer, romdat, readFromROM)
				End If
			Next TileCount

			y = Rd(CoordAddr.Rom + (SelTile * 2) + 0, romdat)
			x = Rd(CoordAddr.Rom + (SelTile * 2) + 1, romdat)
			Tile = Rd(FrameAddr.Rom + (SelTile * 2) + 2, romdat)
			Attr = Rd(FrameAddr.Rom + (SelTile * 2) + 3, romdat)
			If (ShowCursors = 1) And (CursorType = 1) Then
				RAW_DrawSprTile(spr_bm, y, x, Tile, Attr, (&H80S + (CursorBlinkState * &H40S)), PatternMapBuffer, romdat, readFromROM)
			Else
				RAW_DrawSprTile(spr_bm, y, x, Tile, Attr, 0, PatternMapBuffer, romdat, readFromROM)
			End If

			If (ShowCursors = 1) And (CursorType = 0) Then

				x = (Rd(CoordAddr.Rom + (HoverTile * 2) + 1, romdat) + &H80S) And &HFFS
				y = (Rd(CoordAddr.Rom + (HoverTile * 2) + 0, romdat) + &H80S) And &HFFS
				RAW_LineH(spr_bm, x - 1, x + 8, y - 1, &H44S)
				RAW_LineH(spr_bm, x - 1, x + 8, y + 8, &H44S)
				RAW_LineV(spr_bm, x - 1, y - 1, y + 8, &H44S)
				RAW_LineV(spr_bm, x + 8, y - 1, y + 8, &H44S)

				x = (Rd(CoordAddr.Rom + (SelTile * 2) + 1, romdat) + &H80S) And &HFFS
				y = (Rd(CoordAddr.Rom + (SelTile * 2) + 0, romdat) + &H80S) And &HFFS
				RAW_LineH(spr_bm, x - 1, x + 8, y - 1, &H43S)
				RAW_LineH(spr_bm, x - 1, x + 8, y + 8, &H43S)
				RAW_LineV(spr_bm, x - 1, y - 1, y + 8, &H43S)
				RAW_LineV(spr_bm, x + 8, y - 1, y + 8, &H43S)

			End If
		End If
	End Sub

	Public Sub RecalcViewXY()
		Select Case ViewZoom
			Case 1
				ViewX = -((Me.WorkPic.ClientRectangle.Width - 256) / 2)
				ViewY = -((Me.WorkPic.ClientRectangle.Height - 256) / 2)
				ViewMinX = -(WorkPic.ClientRectangle.Width - 256)
				ViewMinY = -(WorkPic.ClientRectangle.Height - 256)
				ViewMaxX = 0
				ViewMaxY = 0
			Case 2 To 4
				ViewX = 128 - ((Me.WorkPic.ClientRectangle.Width / 2) / ViewZoom)
				ViewY = 128 - ((Me.WorkPic.ClientRectangle.Height / 2) / ViewZoom)
				ViewMinX = 0
				ViewMinY = 0
				ViewMaxX = 255 - (WorkPic.ClientRectangle.Width / ViewZoom)
				ViewMaxY = 255 - (WorkPic.ClientRectangle.Height / ViewZoom)
		End Select
	End Sub

	'Common function for wrapping a 8-bit value by 128.
	Public Function Wrap128(ByRef inval As Integer) As Integer
		Wrap128 = (inval + &H80S) And &HFFS
	End Function

	Private Sub Move_Tile_X(ByRef rel As Integer)
		Dim a, b As Integer

		If (ASM_FileModeOn And ASM_FileModeInitiated) Then
			If MoveAllTiles = 0 Then
				a = Dec(currentCoordinate._X(SelTile))
				Change_Tile_X(((a + rel) And &HFFS))
			Else
				For b = 0 To FrameLastTile
					a = (Dec(currentCoordinate._X(b)) + rel) And &HFFS
					currentCoordinate._X(b) = Hex(a)
				Next b
				SetUDCool(TileXUD, Hex(Dec(currentCoordinate._X(SelTile))), 2)
				Refresh_RedrawSprite()
			End If
		Else
			If MoveAllTiles = 0 Then
				a = Rd(CoordAddr.Rom + (SelTile * 2) + 1, romdat)
				Change_Tile_X(((a + rel) And &HFFS))
			Else
				Dim bola = CheckCoordinateIsPair()

				For b = 0 To FrameLastTile
					a = (Rd(CoordAddr.Rom + (b * 2) + 1, romdat) + rel) And &HFFS
					Wr((CoordAddr.Rom + (b * 2) + 1), CByte(a))
					If (bola = True) And (CoordPairs = 1) Then
						Wr((Coord2Addr.Rom + (b * 2) + 1), X_Flip(a))
					End If
				Next b
				SetUDCool(TileXUD, Hex(Rd(CoordAddr.Rom + (SelTile * 2) + 1, romdat)), 2)
				Refresh_RedrawSprite()
			End If
		End If
	End Sub

	Private Sub Change_Tile_X(ByRef newx As Integer)

		If (ASM_FileModeOn And ASM_FileModeInitiated) Then
			If ASM_FileModeSpriteLoaded Then
				currentCoordinate._X(SelTile) = Hex(newx)
				SetUDCool(TileXUD, Hex(Dec(currentCoordinate._X(SelTile))), 2)
				Refresh_RedrawSprite()
			End If
		Else
			Dim bola = CheckCoordinateIsPair()
			Wr((CoordAddr.Rom + (SelTile * 2) + 1), CByte(newx))
			If (bola = True) And (CoordPairs = 1) Then
				Wr((Coord2Addr.Rom + (SelTile * 2) + 1), X_Flip(newx))
			End If
			SetUDCool(TileXUD, Hex(Rd(CoordAddr.Rom + (SelTile * 2) + 1, romdat)), 2)
			Refresh_RedrawSprite()
		End If
	End Sub

	Private Sub Move_Tile_Y(ByRef rel As Integer)
		Dim a, b As Integer

		If (ASM_FileModeOn And ASM_FileModeInitiated) Then
			If MoveAllTiles = 0 Then
				a = Dec(currentCoordinate._Y(SelTile))
				Change_Tile_Y(((a + rel) And &HFFS))
			Else
				For b = 0 To FrameLastTile
					a = (Dec(currentCoordinate._Y(b)) + rel) And &HFFS
					currentCoordinate._Y(b) = Hex(a)
				Next b
				SetUDCool(TileYUD, Hex(Dec(currentCoordinate._Y(SelTile))), 2)
				Refresh_RedrawSprite()
			End If
		Else
			If MoveAllTiles = 0 Then
				a = Rd(CoordAddr.Rom + (SelTile * 2) + 0, romdat)
				Change_Tile_Y(((a + rel) And &HFFS))
			Else
				Dim bola = CheckCoordinateIsPair()

				For b = 0 To FrameLastTile
					a = (Rd(CoordAddr.Rom + (b * 2) + 0, romdat) + rel) And &HFFS
					Wr((CoordAddr.Rom + (b * 2) + 0), CByte(a))
					If (bola = True) And (CoordPairs = 1) Then
						Wr((Coord2Addr.Rom + (b * 2) + 0), CByte(a))
					End If
				Next b
				SetUDCool(TileYUD, Hex(Rd(CoordAddr.Rom + (SelTile * 2) + 0, romdat)), 2)
				Refresh_RedrawSprite()
			End If
		End If
	End Sub

	Private Sub Change_Tile_Y(ByRef newy As Integer)
		If (ASM_FileModeOn And ASM_FileModeInitiated) Then
			If ASM_FileModeSpriteLoaded Then
				currentCoordinate._Y(SelTile) = Hex(newy)
				SetUDCool(TileYUD, Hex(Dec(currentCoordinate._Y(SelTile))), 2)
				Refresh_RedrawSprite()
			End If
		Else
			Dim bola = CheckCoordinateIsPair()
			Wr((CoordAddr.Rom + (SelTile * 2) + 0), CByte(newy))
			If (bola = True) And (CoordPairs = 1) Then
				Wr((Coord2Addr.Rom + (SelTile * 2) + 0), CByte(newy))
			End If
			SetUDCool(TileYUD, Hex(Rd(CoordAddr.Rom + (SelTile * 2) + 0, romdat)), 2)
			Refresh_RedrawSprite()
		End If
	End Sub

	Public Function CheckCoordinateIsPair() As Boolean
		If ASM_FileModeOn Then
			Return False
		End If

		Dim Y1, x1, a, x2, Y2 As Integer
		For a = 0 To FrameLastTile
			x1 = Rd(CoordAddr.Rom + (a * 2) + 1, romdat)
			x2 = Rd(Coord2Addr.Rom + (a * 2) + 1, romdat)
			If Not X_Flip(x1) = x2 Then
				CheckCoordinateIsPair = False
				Exit Function
			End If
			Y1 = Rd(CoordAddr.Rom + (a * 2) + 0, romdat)
			Y2 = Rd(Coord2Addr.Rom + (a * 2) + 0, romdat)
			If Not Y1 = Y2 Then
				CheckCoordinateIsPair = False
				Exit Function
			End If
		Next a
		CheckCoordinateIsPair = True
	End Function

	Public Function X_Flip(ByRef x As Integer) As Byte
		X_Flip = CByte((CShort(x Xor &HFFS) - 7) And &HFFS)
	End Function

	'-------------------------------------------------------------------------------------
	Private Sub PicVScroll_Scroll(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.ScrollEventArgs) Handles PicVScroll.Scroll
		Select Case eventArgs.Type
			Case System.Windows.Forms.ScrollEventType.EndScroll
				PicVScroll_Change(eventArgs.NewValue)
		End Select
	End Sub
	Private Sub PicHScroll_Scroll(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.ScrollEventArgs) Handles PicHScroll.Scroll
		Select Case eventArgs.Type
			Case System.Windows.Forms.ScrollEventType.EndScroll
				PicHScroll_Change(eventArgs.NewValue)
		End Select
	End Sub

	Private Sub DelayUD_ActionUponNewValue()
		AnimationDelay = (Dec((DelayUD.Text)) And &HFFS)
		If ASM_FileModeOn Then
			If ASM_FileModeSpriteLoaded Then
				animationsArray(LstASM_Mode_Animations.SelectedIndex)._delay = (Hex(AnimationDelay)).PadLeft(2, "0"c)
			End If
		Else
			Wr((SprAddr.Rom + 1), CByte(AnimationDelay))
		End If
	End Sub

	Private Sub DelayUD_KeyUp(sender As Object, e As KeyEventArgs) Handles DelayUD.KeyUp
		' Set new value (with validations)
		SetUDCool(CType(sender, NumericUpDown), sender.Text, 2)

		' When here, Value was validated
		DelayUD_ActionUponNewValue()
	End Sub

	Private Sub DelayUD_ValueChanged(sender As Object, e As EventArgs) Handles DelayUD.ValueChanged
		If UpdateUDCool(sender) Then
			' When here, Value was validated
			DelayUD_ActionUponNewValue()
		End If
	End Sub

	Private Sub TileXUD_ActionUponNewValue()
		Change_Tile_X((Dec((TileXUD.Text)) And &HFFS))
	End Sub

	Private Sub TileXUD_KeyUp(sender As Object, e As KeyEventArgs) Handles TileXUD.KeyUp
		' Set new value (with validations)
		SetUDCool(CType(sender, NumericUpDown), sender.Text, 2)

		' When here, Value was validated
		TileXUD_ActionUponNewValue()
	End Sub

	Private Sub TileXUD_ValueChanged(sender As Object, e As EventArgs) Handles TileXUD.ValueChanged
		If UpdateUDCool(sender) Then
			' When here, Value was validated
			TileXUD_ActionUponNewValue()
		End If
	End Sub

	Private Sub TileYUD_ActionUponNewValue()
		Change_Tile_Y((Dec((TileYUD.Text)) And &HFFS))
	End Sub

	Private Sub TileYUD_KeyUp(sender As Object, e As KeyEventArgs) Handles TileYUD.KeyUp
		' Set new value (with validations)
		SetUDCool(CType(sender, NumericUpDown), sender.Text, 2)

		' When here, Value was validated
		TileYUD_ActionUponNewValue()
	End Sub

	Private Sub TileYUD_ValueChanged(sender As Object, e As EventArgs) Handles TileYUD.ValueChanged
		If UpdateUDCool(sender) Then
			' When here, Value was validated
			TileYUD_ActionUponNewValue()
		End If
	End Sub

	Private Sub TilePatUD_ActionUponNewValue()
		If ASM_FileModeOn Then
			If ASM_FileModeSpriteLoaded Then
				currentSprite._tilesID(SelTile) = TilePatUD.Text.PadLeft(2, "0"c)
			Else
				Exit Sub
			End If
		Else
			Wr(FrameAddr.Rom + (SelTile * 2) + 2, Dec(TilePatUD.Text) And &HFFS)
		End If
		Refresh_ChangeTilePal()
		Refresh_EditTile()
		Refresh_RedrawSprite()
	End Sub

	Private Sub TilePatUD_KeyUp(sender As Object, e As KeyEventArgs) Handles TilePatUD.KeyUp
		' Set new value (with validations)
		SetUDCool(CType(sender, NumericUpDown), sender.Text, 2)

		' When here, Value was validated
		TilePatUD_ActionUponNewValue()
	End Sub

	Private Sub TilePatUD_ValueChanged(sender As Object, e As EventArgs) Handles TilePatUD.ValueChanged
		If UpdateUDCool(sender) Then
			' When here, Value was validated
			TilePatUD_ActionUponNewValue()
		End If
	End Sub

	Private Sub ChkAutoloadROM_CheckStateChanged(sender As Object, e As EventArgs) Handles ChkAutoloadROM.CheckStateChanged
		Dim autoLoadValue As String = ""

		If ChkAutoloadROM.Checked = True Then
			autoLoadValue = CSA_Main.filename + "<" + CSA_Main.supfile
		End If

		SetCfg("auto_loadrom", autoLoadValue)
	End Sub

	Private Sub PicBTile_MouseDown(sender As Object, e As MouseEventArgs) Handles PicBTile.MouseDown
		Dim x As Integer = e.Location.X
		Dim y As Integer = e.Location.Y
		Dim a, pixX, pixY, cmpx1, cmpx2, cmpy1, cmpy2 As Integer
		Dim patbyte As Integer
		Dim b0, b1 As Byte

		If ASM_FileModeOn And ASM_FileModeSpriteLoaded = False Then
			Exit Sub
		End If

		For pixY = 0 To 7
			For pixX = 0 To 7
				'TPixShapeIndex = (pixY * 8) Or pixX
				cmpx1 = pixX * tilePicTileWidth
				cmpx2 = cmpx1 + tilePicTileWidth
				cmpy1 = pixY * tilePicTileWidth
				cmpy2 = cmpy1 + tilePicTileWidth
				If (x >= cmpx1) And (x <= cmpx2) And (y >= cmpy1) And (y <= cmpy2) Then
					If ASM_FileModeOn Then
						patbyte = Dec(currentSprite._tilesID(SelTile))
					Else
						patbyte = Rd(FrameAddr.Rom + (SelTile * 2) + 2, romdat)
					End If
					If (e.Button And MouseButtons.Left) Then
						b1 = ReadPatternMap((patbyte * &H10S) + 8 + pixY)
						b0 = ReadPatternMap((patbyte * &H10S) + 0 + pixY)
						b0 = (b0 And InvANDtbl(pixX)) Or (CShort(PatEdColor And 1) * ANDtbl(pixX))
						b1 = (b1 And InvANDtbl(pixX)) Or (CShort(((PatEdColor And 2) <> 0) And 1) * ANDtbl(pixX))
						WritePatternMap(patbyte * &H10S, b0, 0 + pixY)
						WritePatternMap(patbyte * &H10S, b1, 8 + pixY)
						CHR_MapChanged()
					End If
					If (e.Button And MouseButtons.Right) Then
						b0 = ReadPatternMap((patbyte * &H10S) + 0 + pixY)
						b1 = ReadPatternMap((patbyte * &H10S) + 8 + pixY)
						a = ((b0 And ANDtbl(pixX)) <> 0 And 1) Or ((b1 And ANDtbl(pixX)) <> 0 And 1 * 2)
						PatEdColor = a
						Refresh_PatternEdColor()
					End If
					Exit Sub
					'b0 = Rd(PatternMap((patbyte * &H10) + 0 + y))
					'b1 = Rd(PatternMap((patbyte * &H10) + 8 + y))
					'For x = 0 To 7
					'    a = _
					''    ((b0 And ANDtbl(x)) <> 0 And 1) Or _
					''    ((b1 And ANDtbl(x)) <> 0 And 1 * 2)
				End If
			Next pixX
		Next pixY

		CHR_MapChanged()
	End Sub

	Private Sub PicBTile_MouseMove(sender As Object, e As MouseEventArgs) Handles PicBTile.MouseMove
		If e.Button Then
			PicBTile_MouseDown(sender, e)
		End If
	End Sub

	Private Sub PicBPal_MouseDown(sender As Object, e As MouseEventArgs) Handles PicBPal.MouseDown
		Dim y As Integer = e.Location.Y
		Dim a As Integer
		Dim cmpy1() As Integer = {0, 27, 52, 77}
		Dim cmpy2() As Integer = {26, 51, 76, 102}

		For a = 0 To 3
			If (y >= cmpy1(a) And y <= cmpy2(a)) Then
				PatEdColor = a
				Refresh_PatternEdColor()
				Exit For
			End If
		Next a
	End Sub

	Private Sub PicBPal_MouseMove(sender As Object, e As MouseEventArgs) Handles PicBPal.MouseMove
		If e.Button Then
			PicBPal_MouseDown(sender, e)
		End If
	End Sub

	Private Sub MeWidthAdjustment()
		If (BtnMoreOptions.Text = BtnMoreOptionsMoreOptionsText) Then
			Me.Width = InitialWidth
		Else
			Me.Width = Math.Max(PnlMoreOptions.Left + PicBTileMap.Width + 26,
								PnlMoreOptions.Left + ChkAutoloadROM.Left + ChkAutoloadROM.Width + 26)
		End If

		PnlModeASM_Files.Width = Me.Width
	End Sub

	Private Sub TileMapSelectorAroundTile(curtileX As Integer, curtileY As Integer, palID As Integer)
		Dim curtileFirstLineStartX, curtileFirstLineStartY As Integer

		' Calculate where to start drawing lines
		curtileFirstLineStartX = curtileX * (tileSize * CHR_ViewZoom + 1)
		curtileFirstLineStartY = curtileY * (tileSize * CHR_ViewZoom + 1)

		RenderModule.DrawLineHUsingWxH(tt_bmi, curtileFirstLineStartX, curtileFirstLineStartY, tileSize * CHR_ViewZoom + 2, palID)
		RenderModule.DrawLineVUsingWxH(tt_bmi, curtileFirstLineStartX, curtileFirstLineStartY, tileSize * CHR_ViewZoom + 2, palID)
		RenderModule.DrawLineHUsingWxH(tt_bmi, curtileFirstLineStartX, curtileFirstLineStartY + (tileSize * CHR_ViewZoom + 1), tileSize * CHR_ViewZoom + 2, palID)
		RenderModule.DrawLineVUsingWxH(tt_bmi, curtileFirstLineStartX + (tileSize * CHR_ViewZoom + 1), curtileFirstLineStartY, tileSize * CHR_ViewZoom + 2, palID)
	End Sub

	Private Function ReturnX_Or_Y_OfTileByCursorPositionInTileMap(z As Integer) As Integer
		' CHR_ViewZoom -> The + 1 is to compensatve for the line above. Value is maxed at 15 (could be lower since there is a last line
		'	on the right and bottom that wouldn't be considered belonging to any tile
		ReturnX_Or_Y_OfTileByCursorPositionInTileMap = VWidth(Int(z / ((tileSize * CHR_ViewZoom) + 1)), 0, 15)
	End Function

	Private Function CurTileID_FromCursorPosition(x As Integer, Y As Integer) As Integer
		Dim curtileX As Integer = ReturnX_Or_Y_OfTileByCursorPositionInTileMap(x)
		Dim curtileY As Integer = ReturnX_Or_Y_OfTileByCursorPositionInTileMap(Y)

		' Set Tile ID as current Tile
		CurTileID_FromCursorPosition = (curtileY * 16 + curtileX)
	End Function


	Private Sub CurTileMapSet(curtileX As Integer, curtileY As Integer)
		Dim tileID As Integer = (curtileY * 16 + curtileX)

		' Set Tile ID as current Tile
		TilePatUD.Value = tileID

		TileMapSelectorAroundTile(oldtileX, oldtileY, &H40S)
		TileMapSelectorAroundTile(curtileX, curtileY, &H45S)

		oldtileX = curtileX
		oldtileY = curtileY

		tt_bmi.palette_UpdatedSinceLastBytesRGB_Update = True
		RenderModule.RenderPic(PicBTileMap, tt_bmi)
	End Sub

	Private Sub PicBTileMap_TileClicked(x As Integer, Y As Integer)
		Dim curtileX As Integer = ReturnX_Or_Y_OfTileByCursorPositionInTileMap(x)
		Dim curtileY As Integer = ReturnX_Or_Y_OfTileByCursorPositionInTileMap(Y)

		CurTileMapSet(curtileX, curtileY)
	End Sub

	Private Sub PicBTileMap_MouseDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles PicBTileMap.MouseDown
		Dim Button As Short = eventArgs.Button \ &H100000
		Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
		PicBTileMap_TileClicked(eventArgs.X, eventArgs.Y)
	End Sub

	Private Sub PicBTileMap_MouseMove(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles PicBTileMap.MouseMove
		Dim Button As Short = eventArgs.Button \ &H100000
		If (Button And 1) Or (Button And 2) Then
			PicBTileMap_TileClicked(eventArgs.X, eventArgs.Y)
		End If

		LblCHR_MapTileNumber.Text = "Tile: " + Hex(CurTileID_FromCursorPosition(eventArgs.X, eventArgs.Y))
	End Sub

	Private Sub TileShift(shift As Integer)
		Dim x As Integer
		Dim previousValue, newValue As Integer

		For x = 0 To FrameLastTile

			If ASM_FileModeOn Then
				If ASM_FileModeSpriteLoaded Then
					previousValue = Dec(currentSprite._tilesID(x))
					newValue = VWidth(previousValue + shift, 0, &HFFS)
					currentSprite._tilesID(x) = (Hex(newValue)).PadLeft(2, "0"c)
				End If
			Else
				previousValue = Rd(FrameAddr.Rom + (x * 2) + 2, romdat)
				newValue = VWidth(previousValue + shift, 0, &HFFS)
				Wr(FrameAddr.Rom + (x * 2) + 2, newValue)
			End If

			If x = SelTile Then
				TilePatUD.Value = newValue
				Refresh_EditTile()
				Refresh_RedrawSprite()
			End If
		Next
	End Sub

	Private Sub BtnShiftTilesRight_Click(sender As Object, e As EventArgs) Handles BtnShiftTilesRight.Click
		TileShift(1)
	End Sub

	Private Sub BtnShiftTilesLeft_Click(sender As Object, e As EventArgs) Handles BtnShiftTilesLeft.Click
		TileShift(-1)
	End Sub

	Private Sub OutputToFileCHR(Optional useStoredFilename As Boolean = False)
		Dim a, aMax As Integer
		Dim FileName As String
		Dim NiceDialog As New ClsDialog
		Dim PathBackup As String
		Dim Title As String = "Choose a file to write object data to."
		Dim InitDir As String = ""
		Dim DefExt As String = ""
		Dim Filter As String = ".CHR files|*.chr|All files|*.*"
		Dim flags As ClsDialog.DialogFlags = ClsDialog.DialogFlags.CHECKPATHEXISTS

		LockPictureBoxes()

		PathBackup = CurDir()
		If useStoredFilename Then
			If ASM_ModeCHR_File = "" Then
				MessageBox.Show("No chr file was loaded, pick one.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
				FileName = NiceDialog.ShowSave(Me, Title, flags, InitDir, DefExt, Filter)
			Else
				FileName = ASM_ModeCHR_File
			End If
		Else
			FileName = NiceDialog.ShowSave(Me, Title, flags, InitDir, DefExt, Filter)
		End If

		If (FileName <> "") Then
			ASM_ModeCHR_File = FileName

			aMax = (((CInt(CHR_ExportEndOffsetUD.Value) + 1) * &H10S) - 1)

			If (FileName <> "") Then
				Try
					FileOpen(1, FileName, OpenMode.Binary)

					Try
						For a = (CInt(CHR_ExportStartOffsetUD.Value) * &H10S) To aMax
							If usingCHR_FileForTileMap Then
								FilePut(1, CHR_FilePatternMap(a))
							Else
								FilePut(1, romdat(PatternMap(a)))
							End If
						Next a
					Catch ex As Exception
						MessageBox.Show("Parameters are invalid.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
					End Try

					FileClose(1)
				Catch ex As Exception
					MessageBox.Show("Parameters are invalid - couldn't open file.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
				End Try
			End If
		End If

		ChDir(PathBackup)

		UnlockPictureBoxes()
	End Sub

	Private Sub BtnOutputToFileCHR_Click(sender As Object, e As EventArgs) Handles BtnOutputToFileCHR.Click
		OutputToFileCHR()
	End Sub

	Private Sub LoadCHR_File(FileName As String, Optional startOffset As String = "")
		Dim read As Byte = 0
		Dim z, zMax As Integer

		If (startOffset <> "") Then CHR_ImportStartOffsetUD.Value = startOffset

		zMax = (((CInt(CHR_ImportEndOffsetUD.Value) + 1) * &H10S) - 1)

		FileOpen(1, FileName, OpenMode.Binary)
		Try
			For z = (CInt(CHR_ImportStartOffsetUD.Value) * &H10S) To zMax
				FileGet(1, read)
				CHR_FilePatternMap(z) = read
			Next
		Catch ex As Exception
		End Try

		FileClose(1)

		ASM_ModeCHR_File = FileName

		If (ASM_FileModeOn) Then
			ASM_ModeCHR_FileStartOffset = CInt(CHR_ImportStartOffsetUD.Value)
			ChkAutoloadASM_ModeAndFilesUpdate()
		End If
	End Sub

	Private Sub BtnLoadCHR_Click(sender As Object, e As EventArgs) Handles BtnLoadCHR.Click
		Dim PathBackup As String
		Dim FileName As String
		Dim NiceDialog As New ClsDialog
		Dim Title As String = "Choose a file containing CHR."
		Dim InitDir As String = ""
		Dim DefExt As String = ""
		Dim Filter As String = ".CHR files|*.chr|All files|*.*"
		Dim flags As ClsDialog.DialogFlags = ClsDialog.DialogFlags.CHECKFILEEXISTS Or ClsDialog.DialogFlags.CHECKPATHEXISTS

		LockPictureBoxes()


		PathBackup = CurDir()
		FileName = NiceDialog.ShowOpen(Me, Title, flags, InitDir, DefExt, Filter)
		If Len(FileName) = 0 Then GoTo exitme

		FileName = Common.Left(FileName, Len(FileName))

		LoadCHR_File(FileName)

exitme:
		ChDir(PathBackup)

		CHR_MapChanged()

		UnlockPictureBoxes()
	End Sub

	Private Sub CHR_MapChanged(Optional _CHR_ViewLastPal As Integer = -1)
		Refresh_TileMap(_CHR_ViewLastPal)
		Refresh_EditTile()
		Refresh_RedrawSprite()
	End Sub

	Private Sub ChkUseCHR_CheckedChanged(sender As Object, e As EventArgs) Handles ChkUseCHR.CheckedChanged
		usingCHR_FileForTileMap = ChkUseCHR.Checked
		CHR_MapChanged()
	End Sub

	Private Sub CHR_ImportExportStartStopOffsetUD_KeyUp(sender As Object, e As KeyEventArgs) Handles CHR_ImportStartOffsetUD.KeyUp, CHR_ImportEndOffsetUD.KeyUp, CHR_ExportStartOffsetUD.KeyUp, CHR_ExportEndOffsetUD.KeyUp
		' Set new value (with validations)
		SetUDCool(CType(sender, NumericUpDown), sender.Text, 2)
	End Sub

	Private Sub BtnMoreOptionsClick()
		If (BtnMoreOptions.Text = BtnMoreOptionsMoreOptionsText) Then
			BtnMoreOptions.Text = BtnMoreOptionsLessOptionsText
			PnlMoreOptions.Visible = True
		Else
			BtnMoreOptions.Text = BtnMoreOptionsMoreOptionsText
			PnlMoreOptions.Visible = False
		End If

		MeWidthAdjustment()
	End Sub

	Private Sub BtnMoreOptions_Click(sender As Object, e As EventArgs) Handles BtnMoreOptions.Click
		BtnMoreOptionsClick()
	End Sub

	Private Function ReadPatternMap(index As Integer)
		If usingCHR_FileForTileMap Or autoLoadASM_ModeOff = False Then
			Return CHR_FilePatternMap(index)
		Else
			Return Rd(PatternMap(index), romdat)
		End If
	End Function

	Private Sub WritePatternMap(index As Integer, writeValue As Byte, Optional indexPart2 As Integer = 0)
		If usingCHR_FileForTileMap Then
			CHR_FilePatternMap(index + indexPart2) = writeValue
		Else
			Wr(PatternMap(index) + indexPart2, writeValue)
		End If
	End Sub

	Public Sub UnlockPictureBoxes()
		TimerUnlockPictureBoxes.Start()
	End Sub

	Private Sub LoopControlsAndChangePicBoxEnabled(controlList As Control, enableValue As Boolean)
		For Each control As Control In controlList.Controls
			If TypeOf control Is PictureBox Then
				control.Enabled = enableValue
			End If

			If control.HasChildren Then
				LoopControlsAndChangePicBoxEnabled(control, enableValue)
			End If
		Next
	End Sub

	Private Sub LockPictureBoxes()
		LoopControlsAndChangePicBoxEnabled(Me, False)
		TimerUnlockPictureBoxes.Stop()
		TimerUnlockPictureBoxes.Interval = 200
	End Sub

	Private Sub TimerUnlockPictureBoxes_Tick(sender As Object, e As EventArgs) Handles TimerUnlockPictureBoxes.Tick
		LoopControlsAndChangePicBoxEnabled(Me, True)
		TimerUnlockPictureBoxes.Stop()
	End Sub

	Private Sub MTools_DropDownOpened(sender As Object, e As EventArgs) Handles MTools.DropDownOpened
		LockPictureBoxes()
	End Sub

	Private Sub MTools_DropDownClosed(sender As Object, e As EventArgs) Handles MTools.DropDownClosed
		UnlockPictureBoxes()
	End Sub

#Region "Was_Already_Unused"
	'Private Sub Command1_Click()
	'	ChDir(My.Application.Info.DirectoryPath)
	'	FileOpen(1, "dump.hex", OpenMode.Binary)
	'	FilePut(1, UsageMap)
	'	FileClose(1)
	'End Sub

	'Not useful, thus removed from menu.
	Public Sub MTools_MakePair_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MTools_MakePair.Click
		Dim a As Integer
		If (CoordPairs = 1) Then
			For a = 0 To FrameLastTile
				Wr(Coord2Addr.Rom + (a * 2), Rd(CoordAddr.Rom + (a * 2), romdat))
				Wr(Coord2Addr.Rom + (a * 2) + 1, X_Flip(Rd(CoordAddr.Rom + (a * 2) + 1, romdat)))
			Next a
		End If
		Refresh_CoordID()
	End Sub

	Private Sub TilePalTB_TextChanged(sender As Object, e As EventArgs) Handles TilePalTB.TextChanged
		If TilePalTB.Tag = "" Then

			SetTBCoolNumWithValidation(TilePalTB, TilePalTB.Text, 3, 1, True)

			TilePalChange(Dec(TilePalTB.Text))
		End If
	End Sub

	Private Sub SwitchToAsmFileMode(Optional forceModeLoad As Boolean = False)
		Dim result As DialogResult = DialogResult.Yes

		If (forceModeLoad = False) Then
			result = MessageBox.Show("You will need to restart program to switch mode again." + vbNewLine + "Proceed?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
		End If

		' Set every control invisible and we only restore those we want after
		If result = DialogResult.Yes Then
			' Do this so if anything is using rom data it will warn programmer
			romdat = Nothing

			Dim buffer As Integer ' Used for few things
			Dim loweringNeeded As Integer = 90
			Dim PnlCHR_LoadDstH As Integer = TabCMapping.Left
			Dim PnlCHR_LoadDstV As Integer = TabCMapping.Top + 20
			Dim PnlMoreOptionsDstH As Integer = PnlMoreOptions.Left
			Dim PnlMoreOptionsDstV As Integer = PnlMoreOptions.Top
			Dim BtnMoreOptionsDstH As Integer = BtnMoreOptions.Left
			Dim BtnMoreOptionsDstV As Integer = BtnMoreOptions.Top
			Dim pnlGraphSpriteV As Integer = pnlGraphSprite.Top + loweringNeeded

			' Indicate ASM File Mode On
			ASM_FileModeOn = True

			' If forms options are extended, reduce them
			If (BtnMoreOptions.Text = BtnMoreOptionsLessOptionsText) Then
				BtnMoreOptionsClick()
			End If

			' Switch some control into the PnlModeASM
			PnlModeASM_Files.Controls.Add(PnlCHR_Load)
			PnlModeASM_Files.Controls.Add(PnlMoreOptions)
			PnlModeASM_Files.Controls.Add(BtnMoreOptions)
			PnlModeASM_Files.Controls.Add(PnlTileEditing1)
			PnlModeASM_Files.Controls.Add(PnlTileEditing2)
			PnlModeASM_Files.Controls.Add(PnlTileEditing3)
			PnlModeASM_Files.Controls.Add(PnlTileEditing4)
			PnlModeASM_Files.Controls.Add(PnlTileEditing5)
			PnlModeASM_Files.Controls.Add(GbxTileEditing1)
			PnlModeASM_Files.Controls.Add(pnlGraphSprite)
			PnlModeASM_Files.Controls.Add(pnlGraphSprite2)
			PnlModeASM_Files.Controls.Add(PnlAnimDelay)
			PnlModeASM_Files.Controls.Add(BtnLoadDefault)

			' Needs to reorder controls vertically for the group box of palettes quads
			GbxTileEditing1.Height = TilePalTB.Height +
				PnlPalQuad0.Height +
				PnlPalQuad1.Height +
				PnlPalQuad2.Height +
				PnlPalQuad3.Height +
				20
			GbxTileEditing1.Width = PnlPalQuad0.Width + 30
			buffer = PnlPalQuad2.Top - PnlPalQuad1.Top
			PnlPalQuad1.Top = PnlPalQuad0.Top + buffer
			PnlPalQuad2.Top = PnlPalQuad1.Top + buffer
			PnlPalQuad3.Top = PnlPalQuad2.Top + buffer
			PnlPalQuad1.Left = PnlPalQuad0.Left
			PnlPalQuad2.Left = PnlPalQuad0.Left
			PnlPalQuad3.Left = PnlPalQuad0.Left

			' Panel will cover whole form
			PnlModeASM_Files.Width = Me.Width
			PnlModeASM_Files.Height = Me.Height

			' Position those controls within PnlModeASM
			PnlCHR_Load.Location = New Point(PnlCHR_LoadDstH, PnlCHR_LoadDstV)
			LblLoading.Location = New Point(PnlCHR_Load.Location.X, PnlCHR_Load.Location.Y - 15)
			PnlMoreOptions.Location = New Point(PnlMoreOptionsDstH + PnlMoreOptionsDstV)
			BtnMoreOptions.Location = New Point(BtnMoreOptionsDstH, BtnMoreOptionsDstV)
			PnlTileEditing1.Location = New Point(10, pnlGraphSpriteV)
			PnlTileEditing2.Location = New Point(10, PnlTileEditing1.Top + PnlTileEditing1.Height)
			PnlTileEditing3.Location = New Point(10, PnlTileEditing2.Top + PnlTileEditing2.Height)
			PnlTileEditing4.Location = New Point(10, PnlTileEditing3.Top + PnlTileEditing3.Height)
			PnlTileEditing5.Location = New Point(10, PnlTileEditing4.Top + PnlTileEditing4.Height)
			GbxTileEditing1.Location = New Point(PnlTileEditing4.Left + PnlTileEditing4.Width + 10, PnlTileEditing1.Top)
			pnlGraphSprite.Location = New Point(GbxTileEditing1.Left + GbxTileEditing1.Width + 20, pnlGraphSpriteV)
			pnlGraphSprite2.Location = New Point(pnlGraphSprite.Left + pnlGraphSprite.Width + 10, pnlGraphSprite.Top)
			PnlAnimDelay.Location = New Point(PnlTileEditing1.Left + PnlTileEditing1.Width + 10, PnlTileEditing1.Top)
			BtnLoadDefault.Location = New Point(GbxTileEditing1.Left, GbxTileEditing1.Top + GbxTileEditing1.Height + 5)

			' Hide all unnecesary controls
			For Each control As Control In Me.Controls
				control.Visible = False
			Next

			' Current Panel that occupies the form
			PnlModeASM_Files.Visible = True
			PnlModeASM_Files.Location = New Point(0, 0)

			' Some specifig adjustments
			'	We are going to use CHR files
			ChkUseCHR.Checked = True
			'	This option to False always
			DisableCoordCheck.CheckState = False
			'	This one is in a panel that will remain visible, but this option needs to be removed
			ChkUseCHR.Visible = False
			'	Same for this
			ChkAutoloadROM.Visible = False
			'	Adjust some controls
			PnlCHR_Load.BorderStyle = BorderStyle.FixedSingle
			BtnLoadASM_File.Visible = True
			'	This control is adjusted here using variables - so if variables is changed, this will reflect
			LstASM_Mode_UsedBy.Left = LstASM_Mode_AnimationsInitialLeft
			LstASM_Mode_UsedBy.Width = LstASM_Mode_AnimationsExtendedWidth
			LstASM_Mode_UsedBy.Top = LstASM_Mode_Animations.Top

			' Default loading of file is set
			If (ASM_ModeAnimFile <> "") Then LoadASM_File(ASM_ModeAnimFile)
			If (ASM_ModeCHR_File <> "") Then LoadCHR_File(ASM_ModeCHR_File, ASM_ModeCHR_FileStartOffset)

			' Redraw graphics
			Refresh_EditTile()
			Refresh_RedrawSprite()
			Refresh_TileMap()   ' Else may not be updated when going into ASM mode

			' If there was a chr file loaded, we register it
			ChkAutoloadASM_ModeAndFilesUpdate()

			' Indicate ASM mode initiated
			ASM_FileModeInitiated = True

			' Not used and must not be 0
			FrameID = -1

			' Be sure that a palette must be selected
			If TilePalTB.Text = "" Then TilePalTB.Text = "0"
		End If
	End Sub

	Private Sub SwitchToAsmFileModeToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SwitchToAsmFileModeToolStripMenuItem.Click
		SwitchToAsmFileMode()
	End Sub

	Private Sub ASM_Mode_ClearLists()
		LstASM_Mode_Animations.Items.Clear()
		LstASM_Mode_Sprites.Items.Clear()
		LstASM_Mode_Coordinates.Items.Clear()
	End Sub

	Private Sub LoadASM_File(filename As String)
		Dim a, aIndex, qtyElements As Integer
		Dim prefix, line, buffer As String
		Dim lineSplit As String()

		Try
			Using reader As New IO.StreamReader(filename)
				While Not reader.EndOfStream
					line = reader.ReadLine()

					If (line.Length > 4) Then
						If (line.Contains(";") = False And line.Contains("_")) Then ' Ignore comment lines
							prefix = line.Substring(0, line.IndexOf("_"))
							Select Case prefix
								Case "Anm"
									Array.Resize(animationsArray, animationsArray.Length + 1)

									' Name
									buffer = line.Substring(prefix.Length + 1)
									animationsArray(animationsArray.Length - 1)._name = buffer.Substring(0, buffer.Length - 1)

									' Quantity sprites and delay
									line = reader.ReadLine()
									lineSplit = line.Split(" "c)
									animationsArray(animationsArray.Length - 1)._qtySprites = lineSplit(1)
									animationsArray(animationsArray.Length - 1)._delay = lineSplit(2)

									' Prepare array for next animations
									animationsArray(animationsArray.Length - 1)._sprites = Array.Empty(Of String)()
									Do
										line = reader.ReadLine()
										lineSplit = line.Split(" "c)
										If (lineSplit(0).Contains("DL")) Then ' To ignore some lines that can be put in between. Example: variable to know position of a specific sprite
											' Add one space in array
											Array.Resize(animationsArray(animationsArray.Length - 1)._sprites, animationsArray(animationsArray.Length - 1)._sprites.Length + 1)

											' Get name of Sprite without type of data prefix
											prefix = lineSplit(1).Substring(0, lineSplit(1).IndexOf("_"))
											buffer = lineSplit(1).Substring(prefix.Length + 1)

											' Now buffer is desired data
											animationsArray(animationsArray.Length - 1)._sprites(animationsArray(animationsArray.Length - 1)._sprites.Length - 1) = buffer
										ElseIf String.IsNullOrWhiteSpace(line) Then ' If there is anything on the line we keep going
											Exit Do
										End If
									Loop
								Case "Spr"
									Array.Resize(spritesArray, spritesArray.Length + 1)

									' Name
									buffer = line.Substring(prefix.Length + 1)
									spritesArray(spritesArray.Length - 1)._name = buffer.Substring(0, buffer.Length - 1)

									' Quantity tiles
									line = reader.ReadLine()
									' Since it was for Mega Man 5, they used to have a Char Bank for each sprite - this was removed
									If (line.Contains("ChrBnk")) Then
										line = reader.ReadLine()
									End If
									lineSplit = line.Split(" "c)
									spritesArray(spritesArray.Length - 1)._qtyTiles = lineSplit(1)

									' Coordinate pointer
									line = reader.ReadLine()
									lineSplit = line.Split(" "c)
									prefix = lineSplit(1).Substring(0, lineSplit(1).IndexOf("_"))
									buffer = lineSplit(1).Substring(prefix.Length + 1)
									spritesArray(spritesArray.Length - 1)._crdName = buffer

									' Prepare tiles arrays and read all the tiles data
									line = reader.ReadLine()
									lineSplit = line.Split(" "c)
									qtyElements = ((lineSplit.Length - 1) / 2)
									' Data 0 is the output word before the actual hex codes
									spritesArray(spritesArray.Length - 1)._tilesID = New String(qtyElements - 1) {}
									spritesArray(spritesArray.Length - 1)._tilesAttributes = New String(qtyElements - 1) {}
									For a = 1 To qtyElements
										aIndex = a * 2
										spritesArray(spritesArray.Length - 1)._tilesID(a - 1) = lineSplit(aIndex - 1)
										spritesArray(spritesArray.Length - 1)._tilesAttributes(a - 1) = lineSplit(aIndex)
									Next
								Case "Crd"
									Array.Resize(coordinatesArray, coordinatesArray.Length + 1)

									' Name
									buffer = line.Substring(prefix.Length + 1)
									coordinatesArray(coordinatesArray.Length - 1)._name = buffer.Substring(0, buffer.Length - 1)

									' Prepare coordinates arrays and read all the coordinates data
									line = reader.ReadLine()
									lineSplit = line.Split(" "c)
									qtyElements = ((lineSplit.Length - 1) / 2)
									' Data 0 is the output word before the actual hex codes
									coordinatesArray(coordinatesArray.Length - 1)._Y = New String(qtyElements - 1) {}
									coordinatesArray(coordinatesArray.Length - 1)._X = New String(qtyElements - 1) {}
									For a = 1 To qtyElements
										aIndex = a * 2
										coordinatesArray(coordinatesArray.Length - 1)._Y(a - 1) = lineSplit(aIndex - 1)
										coordinatesArray(coordinatesArray.Length - 1)._X(a - 1) = lineSplit(aIndex)
									Next
								Case Else
							End Select
						End If
					End If
				End While
			End Using

			ASM_ModeAnimFile = filename
			ChkAutoloadASM_ModeAndFilesUpdate()
		Catch ex As Exception
			MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
		End Try

		' Clear the lists before adding stuff to them
		ASM_Mode_ClearLists()

		For Each animationData In animationsArray
			LstASM_Mode_Animations.Items.Add(animationData._name)
		Next

		LstASM_Mode_Animations.SelectedIndex = 0

exitme:
	End Sub


	Private Sub BtnLoadASM_File_Click(sender As Object, e As EventArgs) Handles BtnLoadASM_File.Click
		Dim PathBackup As String
		Dim FileName As String
		Dim NiceDialog As New ClsDialog
		Dim Title As String = "Choose a asm file containing Animation's data."
		Dim InitDir As String = ""
		Dim DefExt As String = ""
		Dim Filter As String = ".ASM files|*.asm|All files|*.*"
		Dim flags As ClsDialog.DialogFlags = ClsDialog.DialogFlags.CHECKFILEEXISTS Or ClsDialog.DialogFlags.CHECKPATHEXISTS

		LockPictureBoxes()

		PathBackup = CurDir()
		FileName = NiceDialog.ShowOpen(Me, Title, flags, InitDir, DefExt, Filter)
		If Len(FileName) = 0 Then GoTo exitme

		FileName = Common.Left(FileName, Len(FileName))

		LoadASM_File(FileName)

exitme:

		ChDir(PathBackup)

		UnlockPictureBoxes()
	End Sub
	Private Sub ASM_Mode_ReduceExtendListBox_VisibilityToggle(toggle As Boolean)
		LblASM_Mode_Animations.Visible = toggle
		LblASM_Mode_Sprites.Visible = toggle
		LblASM_Mode_Coordinates.Visible = toggle
		BtnASM_Mode_Animations_Reduce.Visible = toggle
		BtnASM_Mode_Sprites_Reduce.Visible = toggle
		BtnASM_Mode_Coordinates_Reduce.Visible = toggle
		BtnASM_Mode_Animations_Extend.Visible = toggle
		BtnASM_Mode_Sprites_Extend.Visible = toggle
		BtnASM_Mode_Coordinates_Extend.Visible = toggle
		LstASM_Mode_Animations.Visible = toggle
		LstASM_Mode_Sprites.Visible = toggle
		LstASM_Mode_Coordinates.Visible = toggle
	End Sub

	Private Sub ASM_Mode_ReduceListBox()
		ASM_Mode_ReduceExtendListBox_VisibilityToggle(True)

		LstASM_Mode_Sprites.Left = LstASM_Mode_SpritesInitialLeft
		LstASM_Mode_Coordinates.Left = LstASM_Mode_CoordinatesInitialLeft

		LstASM_Mode_Animations.Width = LstASM_Mode_AnimationsInitialWidth
		LstASM_Mode_Sprites.Width = LstASM_Mode_AnimationsInitialWidth
		LstASM_Mode_Coordinates.Width = LstASM_Mode_AnimationsInitialWidth
	End Sub

	Private Sub ASM_Mode_ExtendListBox(index As Integer)
		ASM_Mode_ReduceExtendListBox_VisibilityToggle(False)

		Select Case index
			Case 0
				LblASM_Mode_Animations.Visible = True
				BtnASM_Mode_Animations_Reduce.Visible = True
				BtnASM_Mode_Animations_Extend.Visible = True
				LstASM_Mode_Animations.Visible = True
				LstASM_Mode_Animations.Width = LstASM_Mode_AnimationsExtendedWidth
			Case 1
				LblASM_Mode_Sprites.Visible = True
				BtnASM_Mode_Sprites_Reduce.Visible = True
				BtnASM_Mode_Sprites_Extend.Visible = True
				LstASM_Mode_Sprites.Visible = True
				LstASM_Mode_Sprites.Left = LstASM_Mode_AnimationsInitialLeft
				LstASM_Mode_Sprites.Width = LstASM_Mode_AnimationsExtendedWidth
			Case 2
				LblASM_Mode_Coordinates.Visible = True
				BtnASM_Mode_Coordinates_Reduce.Visible = True
				BtnASM_Mode_Coordinates_Extend.Visible = True
				LstASM_Mode_Coordinates.Visible = True
				LstASM_Mode_Coordinates.Left = LstASM_Mode_AnimationsInitialLeft
				LstASM_Mode_Coordinates.Width = LstASM_Mode_AnimationsExtendedWidth
		End Select
	End Sub

	Private Sub BtnASM_Mode_Animations_Reduce_Click(sender As Object, e As EventArgs) Handles BtnASM_Mode_Animations_Reduce.Click
		ASM_Mode_ReduceListBox()
	End Sub

	Private Sub BtnASM_Mode_Animations_Extend_Click(sender As Object, e As EventArgs) Handles BtnASM_Mode_Animations_Extend.Click
		ASM_Mode_ExtendListBox(0)
	End Sub

	Private Sub BtnASM_Mode_Sprites_Reduce_Click(sender As Object, e As EventArgs) Handles BtnASM_Mode_Sprites_Reduce.Click
		ASM_Mode_ReduceListBox()
	End Sub

	Private Sub BtnASM_Mode_Sprites_Extend_Click(sender As Object, e As EventArgs) Handles BtnASM_Mode_Sprites_Extend.Click
		ASM_Mode_ExtendListBox(1)
	End Sub

	Private Sub BtnASM_Mode_Coordinates_Reduce_Click(sender As Object, e As EventArgs) Handles BtnASM_Mode_Coordinates_Reduce.Click
		ASM_Mode_ReduceListBox()
	End Sub

	Private Sub BtnASM_Mode_Coordinates_Extend_Click(sender As Object, e As EventArgs) Handles BtnASM_Mode_Coordinates_Extend.Click
		ASM_Mode_ExtendListBox(2)
	End Sub

	Private Sub LstASM_Mode_Animations_SelectedIndexChanged(sender As Object, e As EventArgs) Handles LstASM_Mode_Animations.SelectedIndexChanged
		LstASM_Mode_Sprites.Items.Clear()
		LstASM_Mode_Coordinates.Items.Clear()

		For Each animationData In animationsArray
			If animationData._name = LstASM_Mode_Animations.SelectedItem.ToString() Then
				currentAnimation = animationData
				For Each sprite As String In animationData._sprites
					LstASM_Mode_Sprites.Items.Add(sprite)
				Next
				Exit For
			End If
		Next

		' To load delay of current Animation
		Refresh_SpriteChange()

		LstASM_Mode_Sprites.SelectedIndex = 0
	End Sub

	Private Sub LstASM_Mode_Sprites_SelectedIndexChanged(sender As Object, e As EventArgs) Handles LstASM_Mode_Sprites.SelectedIndexChanged
		LstASM_Mode_Coordinates.Items.Clear()

		For Each spriteData In spritesArray
			If spriteData._name = LstASM_Mode_Sprites.SelectedItem.ToString() Then
				currentSprite = spriteData
				FrameLastTile = Dec(currentSprite._qtyTiles)
				ASM_FileModeSpriteLoaded = True
				LstASM_Mode_Coordinates.Items.Add(spriteData._crdName)
				Exit For
			End If
		Next

		LstASM_Mode_Coordinates.SelectedIndex = 0

		Refresh_SelTile()
	End Sub

	Private Sub LstASM_Mode_Coordinates_SelectedIndexChanged(sender As Object, e As EventArgs) Handles LstASM_Mode_Coordinates.SelectedIndexChanged
		For Each coordinateData In coordinatesArray
			If coordinateData._name = LstASM_Mode_Coordinates.SelectedItem.ToString() Then
				currentCoordinate = coordinateData
				Exit For
			End If
		Next
	End Sub

	Private Sub ChkAutoloadASM_ModeAndFilesUpdate()
		If (ChkAutoloadASM_ModeAndFiles.Checked = True And ASM_FileModeInitiated) Then
			SetCfg("auto_loadASM_Mode", ASM_ModeAnimFile + "<" + ASM_ModeCHR_File + "<" + CStr(ASM_ModeCHR_FileStartOffset))
		End If
	End Sub

	Private Sub ChkAutoloadASM_ModeAndFiles_CheckStateChanged(sender As Object, e As EventArgs) Handles ChkAutoloadASM_ModeAndFiles.CheckStateChanged
		If (ChkAutoloadASM_ModeAndFiles.Checked = False) Then
			SetCfg("auto_loadASM_Mode", ASM_ModeConfigFileNotAuto)
		Else
			ChkAutoloadASM_ModeAndFilesUpdate()
		End If
	End Sub

	Private Sub Form1_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
		CSA_Main.Main()
		If (CSA_Main.supfile <> "" Or CSA_Main.autoLoadASM_ModeOff = False) Then
			' Center it using maximum width
			Me.Width = Math.Max(PnlMoreOptions.Left + PicBTileMap.Width + 26,
								PnlMoreOptions.Left + ChkAutoloadROM.Left + ChkAutoloadROM.Width + 26)
			Me.CenterToScreen()
			Me.Width = Me.InitialWidth

			Dim autoLoadASM_ModeConfig As String = GetCfg("auto_loadASM_Mode", False)

			If (autoLoadASM_ModeConfig <> "" And autoLoadASM_ModeConfig <> ASM_ModeConfigFileNotAuto) Then
				Dim autoLoadASM_ModeConfigValues As String() = autoLoadASM_ModeConfig.Split("<"c)
				ASM_ModeAnimFile = autoLoadASM_ModeConfigValues(0)
				ASM_ModeCHR_File = autoLoadASM_ModeConfigValues(1)
				If autoLoadASM_ModeConfigValues.Length >= 3 Then
					ASM_ModeCHR_FileStartOffset = CInt(autoLoadASM_ModeConfigValues(2))
				End If

				SwitchToAsmFileMode(True)
			End If
		Else
			Me.Close()
		End If
	End Sub

	Private Sub BtnUsedByAnimations_Click(sender As Object, e As EventArgs) Handles BtnUsedByAnimations.Click
		If (BtnUsedByAnimations.Text = BtnUsedByAnimationsText) Then
			If ASM_FileModeSpriteLoaded = False Then
				MessageBox.Show("No Sprite selected!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
				Exit Sub
			End If

			BtnUsedBySprites.Enabled = False

			BtnUsedByAnimations.Text = BtnUsedByHideText

			Dim notFound As Boolean
			LstASM_Mode_UsedBy.Items.Clear()
			For Each animation As AnimationData In animationsArray
				For Each sprite As String In animation._sprites
					If sprite = currentSprite._name Then
						notFound = True

						For Each item As String In LstASM_Mode_UsedBy.Items
							' Perform your desired condition check using an If statement
							If item = animation._name Then
								notFound = False
								Exit For
							End If
						Next
						If (notFound) Then
							LstASM_Mode_UsedBy.Items.Add(animation._name)
						End If
					End If
				Next
			Next

			LstASM_Mode_UsedBy.Visible = True
		Else
			BtnUsedBySprites.Enabled = True

			BtnUsedByAnimations.Text = BtnUsedByAnimationsText
			LstASM_Mode_UsedBy.Visible = False
		End If
	End Sub

	Private Sub BtnUsedBySprites_Click(sender As Object, e As EventArgs) Handles BtnUsedBySprites.Click
		If (BtnUsedBySprites.Text = BtnUsedBySpritesText) Then
			If ASM_FileModeSpriteLoaded = False Then
				MessageBox.Show("No Coordinate selected!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
				Exit Sub
			End If

			BtnUsedByAnimations.Enabled = False

			BtnUsedBySprites.Text = BtnUsedByHideText

			Dim notFound As Boolean
			LstASM_Mode_UsedBy.Items.Clear()
			For Each sprite As SpriteData In spritesArray
				If sprite._crdName = currentCoordinate._name Then
					notFound = True

					For Each item As String In LstASM_Mode_UsedBy.Items
						' Perform your desired condition check using an If statement
						If item = sprite._crdName Then
							notFound = False
							Exit For
						End If
					Next
					If (notFound) Then
						LstASM_Mode_UsedBy.Items.Add(sprite._name)
					End If
				End If
			Next

			LstASM_Mode_UsedBy.Visible = True
		Else
			BtnUsedByAnimations.Enabled = True

			BtnUsedBySprites.Text = BtnUsedBySpritesText
			LstASM_Mode_UsedBy.Visible = False
		End If
	End Sub

	Private Sub BtnLoadDefault_Click(sender As Object, e As EventArgs) Handles BtnLoadDefault.Click
		If (ASM_FileModeOn) Then
			PalTB(0).Text = "0F"
			PalTB(1).Text = "2C"
			PalTB(2).Text = "11"

			PalTB(3).Text = "0F"
			PalTB(4).Text = "30"
			PalTB(5).Text = "37"

			PalTB(6).Text = "0F"
			PalTB(7).Text = "20"
			PalTB(8).Text = "27"

			PalTB(9).Text = "0F"
			PalTB(10).Text = "20"
			PalTB(11).Text = "2A"
		Else
			PalTB(0).Text = Hex(SprPalInitial(1))
			PalTB(1).Text = Hex(SprPalInitial(2))
			PalTB(2).Text = Hex(SprPalInitial(3))

			PalTB(3).Text = Hex(SprPalInitial(5))
			PalTB(4).Text = Hex(SprPalInitial(6))
			PalTB(5).Text = Hex(SprPalInitial(7))

			PalTB(6).Text = Hex(SprPalInitial(9))
			PalTB(7).Text = Hex(SprPalInitial(10))
			PalTB(8).Text = Hex(SprPalInitial(11))

			PalTB(9).Text = Hex(SprPalInitial(13))
			PalTB(10).Text = Hex(SprPalInitial(14))
			PalTB(11).Text = Hex(SprPalInitial(15))
		End If
	End Sub

	Private Sub OutputToFileASM(Optional useStoredFilename As Boolean = False)
		Dim FileName As String
		Dim NiceDialog As New ClsDialog
		Dim PathBackup As String
		Dim Title As String = "Choose a file to write ASM data to."
		Dim InitDir As String = ""
		Dim DefExt As String = ""
		Dim Filter As String = ".ASM files|*.asm|All files|*.*"
		Dim flags As ClsDialog.DialogFlags = ClsDialog.DialogFlags.CHECKPATHEXISTS

		LockPictureBoxes()

		' Ensure we have data for each array
		If currentAnimation._name = Nothing Then
			MessageBox.Show("Need to have at least one Animation.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
		ElseIf currentSprite._name = Nothing Then
			MessageBox.Show("Need to have at least one Sprite.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
		ElseIf currentCoordinate._name = Nothing Then
			MessageBox.Show("Need to have at least one Coordinate.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
		Else
			PathBackup = CurDir()

			If useStoredFilename Then
				If ASM_ModeAnimFile = "" Then
					MessageBox.Show("No asm file was loaded, pick one.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
					FileName = NiceDialog.ShowSave(Me, Title, flags, InitDir, DefExt, Filter)
				Else
					FileName = ASM_ModeAnimFile
				End If
			Else
				FileName = NiceDialog.ShowSave(Me, Title, flags, InitDir, DefExt, Filter)
			End If

			If (FileName <> "") Then
				ASM_ModeAnimFile = FileName

				Using writer As New System.IO.StreamWriter(ASM_ModeAnimFile)
					Dim aMax As Integer

					For Each animationData In animationsArray
						writer.WriteLine("Anm_" + animationData._name + ":")
						writer.WriteLine(ControlChars.Tab + "HEX " + animationData._qtySprites.PadLeft(2, "0"c) + " " + animationData._delay.PadLeft(2, "0"c))

						For Each spriteData In animationData._sprites
							writer.WriteLine(ControlChars.Tab + "DL SprPtr_" + spriteData)
						Next

						writer.WriteLine()
					Next

					' More space before outputing sprites data
					writer.WriteLine()
					writer.WriteLine()

					For Each spriteData In spritesArray
						writer.WriteLine("Spr_" + spriteData._name + ":")
						writer.WriteLine(ControlChars.Tab + "HEX " + spriteData._qtyTiles.PadLeft(2, "0"c))
						writer.WriteLine(ControlChars.Tab + "DL CrdPtr_" + spriteData._crdName)

						aMax = spriteData._tilesAttributes.Length() - 1
						Dim line As String = ControlChars.Tab + "HEX"
						For a As Integer = 0 To aMax
							line += " " + spriteData._tilesID(a) + " " + spriteData._tilesAttributes(a)
						Next

						writer.WriteLine(line)
						writer.WriteLine()
					Next

					' More space before outputing coordinates data
					writer.WriteLine()
					writer.WriteLine()

					aMax = coordinatesArray.Length - 1
					For a As Integer = 0 To aMax
						writer.WriteLine("Crd_" + coordinatesArray(a)._name + ":")

						Dim bMax As Integer = coordinatesArray(a)._X.Length - 1
						Dim line As String = ControlChars.Tab + "HEX"
						For b As Integer = 0 To bMax
							line += " " + coordinatesArray(a)._Y(b) + " " + coordinatesArray(a)._X(b)
						Next

						If (a = aMax) Then
							writer.Write(line)
						Else
							writer.WriteLine(line)
						End If
					Next a
				End Using
			End If
			ChDir(PathBackup)
		End If

		UnlockPictureBoxes()
	End Sub

	Private Sub BtnSaveToLoadedFiles_Click(sender As Object, e As EventArgs) Handles BtnSaveToLoadedFiles.Click
		OutputToFileCHR(True)
		OutputToFileASM(True)
	End Sub

	Private Sub BtnSaveASM_Click(sender As Object, e As EventArgs) Handles BtnSaveASM.Click
		OutputToFileASM()
	End Sub

	Private Sub OutputPointersToFileASM(sprPage As Integer)
		Dim FileName As String
		Dim NiceDialog As New ClsDialog
		Dim PathBackup As String
		Dim Title As String = "Choose a file to write ASM data to."
		Dim InitDir As String = ""
		Dim DefExt As String = ""
		Dim Filter As String = ".ASM files|*.asm|All files|*.*"
		Dim flags As ClsDialog.DialogFlags = ClsDialog.DialogFlags.CHECKPATHEXISTS

		LockPictureBoxes()

		' Ensure we have data for each array
		If currentAnimation._name = Nothing Then
			MessageBox.Show("Need to have at least one Animation.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
		ElseIf currentSprite._name = Nothing Then
			MessageBox.Show("Need to have at least one Sprite.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
		ElseIf currentCoordinate._name = Nothing Then
			MessageBox.Show("Need to have at least one Coordinate.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
		Else
			PathBackup = CurDir()

			FileName = NiceDialog.ShowSave(Me, Title, flags, InitDir, DefExt, Filter)

			If (FileName <> "") Then
				Using writer As New System.IO.StreamWriter(FileName)
					Dim a, aMax As Integer
					Dim line As String
					For Each spriteData In spritesArray
						line = ""

						' Add the tabs
						aMax = 10
						For a = 0 To aMax
							line += vbTab
						Next

						line += "SprPtr_" + spriteData._name + " = <($ - Arr_SprPtr_L__Page_" + sprPage.ToString() + ")"

						writer.WriteLine(line)
						writer.WriteLine(vbTab + "DL Spr_" + spriteData._name)
					Next

					' More space before outputing DH ptrs
					writer.WriteLine()
					writer.WriteLine()
					writer.WriteLine()

					For Each spriteData In spritesArray
						writer.WriteLine(vbTab + "DH Spr_" + spriteData._name)
					Next



					' More space before outputing Coordinates data
					writer.WriteLine()
					writer.WriteLine()
					writer.WriteLine()

					For Each coordinateData In coordinatesArray
						line = ""

						' Add the tabs
						aMax = 10
						For a = 0 To aMax
							line += vbTab
						Next

						line += "CrdPtr_" + coordinateData._name + " = <($ - Arr_CrdPtr_L)"

						writer.WriteLine(line)
						writer.WriteLine(vbTab + "DL Crd_" + coordinateData._name)
					Next

					' More space before outputing DH ptrs
					writer.WriteLine()
					writer.WriteLine()
					writer.WriteLine()

					For Each coordinateData In coordinatesArray
						writer.WriteLine(vbTab + "DH Crd_" + coordinateData._name)
					Next



					' More space before outputing Animations data
					writer.WriteLine()
					writer.WriteLine()
					writer.WriteLine()



					For Each animation In animationsArray
						line = ""

						' Add the tabs
						aMax = 10
						For a = 0 To aMax
							line += vbTab
						Next

						line += "AnmPtr_" + animation._name + " = <($ - Arr_AnmPtr_L)"

						writer.WriteLine(line)
						writer.WriteLine(vbTab + "DL Anm_" + animation._name)
					Next



					' More space before outputing DH ptrs
					writer.WriteLine()
					writer.WriteLine()
					writer.WriteLine()

					aMax = animationsArray.Length - 1
					For a = 0 To aMax
						line = vbTab + "DH Anm_" + animationsArray(a)._name

						If (a = aMax) Then
							writer.Write(line)
						Else
							writer.WriteLine(line)
						End If
					Next a
				End Using
			End If
			ChDir(PathBackup)
		End If

		UnlockPictureBoxes()
	End Sub

	Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
		If RdSpritePtrPage1.Checked = True Then
			OutputPointersToFileASM(1)
		Else
			OutputPointersToFileASM(2)
		End If
	End Sub

	Private Sub AboutToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AboutToolStripMenuItem.Click
		About.ShowDialog()
	End Sub
#End Region
End Class