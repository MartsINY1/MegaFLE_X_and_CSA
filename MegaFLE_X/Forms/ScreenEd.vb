Option Explicit On

Friend Class ScreenEd
	Inherits System.Windows.Forms.Form

	Private EditScrollMap As Integer
	
	Private oldClickedStrY As Integer
	Private oldClickedStrX As Integer

	Private BGPalUD_ValuePrevious As Integer
	Private botCHR_UD_ValuePrevious As Integer
	Private DDAUD_ValuePrevious As Integer
	Private DDBUD_ValuePrevious As Integer
	Private PalSetUD_ValuePrevious As Integer
	Private ScrnPresUD_ValuePrevious As Integer
	Private ScrnPresUDForSwap_ValuePrevious As Integer
	Private ScrollMapUD_ValuePrevious As Integer
	Private SLenUD_ValuePrevious As Integer
	Private STUD_ValuePrevious As Integer
	Dim initialHeight As Integer

	Private ReadOnly BtnMoreOptionsLessOptionsString = "Less Options"
	Private ReadOnly BtnMoreOptionsMoreOptionsString = "More Options"

	'Private XSMD_Dat0(&HFF)
	'Private XSMD_Dat1(&HFF)
	'Private XSMD_Dir(&HFF)
	'Private XSMD_Split(&HFF) As Boolean
	'Private XSMD_ls

	' Object that groups many items
	' Button
	Private MPSetTB() As Button

	Private Sub Form_Initialize()
		' Object that groups many items
		' Button
		MPSetTB = New Button() {_MPSetTB_0, _MPSetTB_1}

		'Previous values that need to be stored
		BGPalUD_ValuePrevious = BGPalUD.Value
		botCHR_UD_ValuePrevious = botCHR_UD.Value
		DDAUD_ValuePrevious = DDAUD.Value
		DDBUD_ValuePrevious = DDBUD.Value
		PalSetUD_ValuePrevious = PalSetUD.Value
		ScrnPresUD_ValuePrevious = ScrnPresUD.Value
		ScrollMapUD_ValuePrevious = ScrollMapUD.Value
		SLenUD_ValuePrevious = SLenUD.Value
		STUD_ValuePrevious = STUD.Value
	End Sub

	Public Sub Manual_Init()
		RenderModule.PB_Init(ScreenPic, scrn_scr_bmi)
		RenderModule.PB_Init(CurStrPic, scrn_curstr_bmi)

		STLab.Visible = True
		STUD.Visible = True
		SLenUD.Visible = True

		DDALab.Top = 2160 / 15
		DDAUD.Top = 2160 / 15
		DDBLab.Top = 2520 / 15
		DDBUD.Top = 2520 / 15

		Select Case gem
			Case 0
				DDALab.Text = "Enemy GFX Set"
				DDBLab.Text = "BG Palette"
				Gem2Frame.Visible = False
			Case 1
				DDALab.Text = "BG Palette"
				DDBLab.Text = "Scroll GFX Load"
				Gem2Frame.Visible = False
			Case 2
				'DDALab.Caption = "Palette Set"
				'DDBLab.Caption = "BG Palette"
				'DDBLab.Left = DDBLab.Left + 150
				'DDBTB.Left = DDBTB.Left + 150
				'DDBUD.Left = DDBUD.Left + 150
				DDALab.Visible = False
				DDAUD.Visible = False
				DDBLab.Visible = False
				DDBUD.Visible = False
				Gem2Frame.Visible = True
			Case 3
				ScrnPresUD.Visible = False
				LblScreenPreset.Visible = False
		End Select

		oldClickedStrY = 8
		oldClickedStrX = 8

		ScrnPresUDForSwap.Maximum = offs(gem, 17)


		If gem < 2 Then
			SLenUD.Maximum = &HFS
		Else
			SLenUD.Maximum = &H1FS
		End If

		initialHeight = BtnMoreOptions.Top + BtnMoreOptions.Height + 43
		Me.Height = initialHeight
	End Sub

	Private Sub ScreenEd_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
		e.Cancel = True

		Me.Hide()
	End Sub

	Public Sub Update_Frm()
		RefreshLock = True

		Update_Level()

		Update_Scrn()
		Update_CurStr()
		Update_BGPal()
		Update_PalSet()
		RefreshLock = False

		Update_RefreshAllBitmaps()
	End Sub

	Public Sub Update_Level()
		'When user changes to/from Scene Screen mode (window is open)
		Dim a As Integer
		If scenemode = True Then
			a = offs(gem, 17) 'Max screen patterns
		Else
			a = offs(gem, 16) 'Max screen positions
		End If
		ScrnScroll.Tag = "=D"
		ScrnScroll.Maximum = (a + ScrnScroll.LargeChange - 1)
		ScrnScroll.Value = 0
		ScrnScroll.Tag = ""

		If (scenemode = True) Or (gem = 3) Then
			Gem3hideframe.Visible = True
			Gem3hideframe.Width = 3335 / 15
			Gem3hideframe.Height = 3620 / 15
		Else
			Gem3hideframe.Visible = False
		End If

		Dim showPreset As Boolean
		If (gem = 3) Or ((scenemode = True) And ((gem = 0) Or (gem = 2))) Then
			showPreset = False
		Else
			showPreset = True
		End If
		'showPreset = (Not scenemode) Or (Not ((gem = 2) Or (gem = 0)))
		LblScreenPreset.Visible = showPreset
		ScrnPresUD.Visible = showPreset

		Dim showMPBtns As Boolean
		showMPBtns = (Not (gem = 3)) And (Not scenemode)
		MPSetTB(0).Visible = showMPBtns
		MPSetTB(1).Visible = showMPBtns
	End Sub

	Public Sub Update_RefreshAllBitmaps()
		RenderModule.RenderPic(ScreenPic, scrn_scr_bmi)
		RenderModule.RenderPic(CurStrPic, scrn_curstr_bmi)
	End Sub

	Public Sub Update_Scrn()
		If GetCfg("autoscrollsearch") = 1 Then
			If (ScrollInfoChangeFlag = False) Or (EditScrollMap = oldscroll) Then ' And (curscroll <> EditScrollMap)) Then
				EditScrollMap = curscroll
			End If
		End If

		ScrnScroll.Value = curscreen

		UpdateScrollStuff()

		SetTBCoolText(CurScrnTB, Hex(curscreen))
		If gem < 3 Then SetUDCool(ScrnPresUD, Hex(romdat(arrayAdjuster + offs(gem, 7) + curscreen)), 2)
		ScreenDraw()
		Update_CurStr()

		RenderModule.RenderPic(ScreenPic, scrn_scr_bmi)
	End Sub

	Private Sub UpdateScrollStuff()
		Dim c, a, b, d As Integer

		SetUDCool(ScrollMapUD, Hex(EditScrollMap), 2)

		If gem < 2 Then
			SetUDCool(STUD, Hex(Int(romdat(arrayAdjuster + offs(gem, o_dirtype) + EditScrollMap) / &H10S)), 2)
			SetUDCool(SLenUD, CStr(romdat(arrayAdjuster + offs(gem, o_dirtype) + EditScrollMap) And &HFS), 2)
			ScrollInfLab.Text = "(" & SrcString(rdata(dspa(d_dtypedat34) + Int(romdat(arrayAdjuster + offs(gem, o_dirtype) + EditScrollMap) / &H10S))) & " x $" & CStr(CShort(romdat(arrayAdjuster + offs(gem, o_dirtype) + EditScrollMap) And &HFS) + 1) & ")"
		Else
			SetUDCool(STUD, Hex(CStr(Int(romdat(arrayAdjuster + offs(gem, o_dirtype) + EditScrollMap) / &H20S))), 2)
			SetUDCool(SLenUD, Hex(CStr(romdat(arrayAdjuster + offs(gem, o_dirtype) + EditScrollMap) And &H1FS)), 2)
			ScrollInfLab.Text = "(" & SrcString(rdata(dspa(d_dtypedat5) + Int(romdat(arrayAdjuster + offs(gem, o_dirtype) + EditScrollMap) / &H20S))) & " x $" & CStr(CShort(romdat(arrayAdjuster + offs(gem, o_dirtype) + EditScrollMap) And &H1FS) + 1) & ")"
		End If

		Select Case gem
			Case 0
				SetUDCool(DDAUD, Hex(romdat(arrayAdjuster + offs(gem, o_ddA) + (EditScrollMap * 2) + 0)), 2)
				SetUDCool(DDBUD, Hex(romdat(arrayAdjuster + offs(gem, o_ddA) + (EditScrollMap * 2) + 1)), 2)
			Case 1
				SetUDCool(DDAUD, Hex(romdat(arrayAdjuster + offs(gem, o_ddA) + EditScrollMap)), 2)
				SetUDCool(DDBUD, Hex(romdat(arrayAdjuster + offs(gem, o_ddB) + EditScrollMap)), 2)
			Case 2
				a = romdat(arrayAdjuster + offs(gem, o_ddA) + EditScrollMap)
				SetCheckCool(BDCheck, Int(CShort(a And &H80S) / &H80S))
				SetCheckCool(SBCheck, Int(CShort(a And &H40S) / &H40S))
				b = a And &H3FS
				SetUDCool(PalSetUD, Hex(b), 2)
				If b > 0 Then
					c = romdat(arrayAdjuster + offs(gem, 27) + ((b - 1) * 8))
					d = romdat(arrayAdjuster + offs(gem, 27) + ((b - 1) * 8) + 4)
					BGPalUD.Enabled = True
					SetUDCool(BGPalUD, Hex(c And &H7FS), 2)
					BGPalCheck.Enabled = True
					SetCheckCool(BGPalCheck, Int(CShort(c And &H80S) / &H80S))
					SetUDCool(botCHR_UD, Hex(d), 2)
					botCHR_UD.Enabled = True
				Else
					BGPalUD.Enabled = False
					SetUDCool(BGPalUD, "", 2)
					BGPalCheck.Enabled = False
					SetUDCool(botCHR_UD, "", 2)
					botCHR_UD.Enabled = False
				End If
		End Select

	End Sub

	Public Sub Update_PalSet()
		UpdateScrollStuff()

		RenderModule.RenderPic(ScreenPic, scrn_scr_bmi)
	End Sub

	Public Sub Update_BGPal()
		Update_PalSet()
	End Sub

	Public Sub Update_StrBlock(ByRef ustr As Integer, ByRef ublock As Integer)
		Dim x, tilenum, tileY, blocknum, blockY, strX, strY, strnum, blockX, tilepal, tileX, y, screen As Integer
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
								y = (((strY * 32) + blockY * 16) + tileY * 8)
								x = (((strX * 32) + blockX * 16) + tileX * 8)
								RenderModule.DrawTile(scrn_scr_bmi, chrmap(tilenum), tilepal, x, y, romdat)
							Next tileX
						Next tileY
skipblock:
					Next blockX
				Next blockY
skipstr:
			Next strX
		Next strY
		If GetCfg("scrned_grid") = 1 Then DrawGrid()

		scrn_scr_bmi.bytesRGB_UpdatedSinceLastRender = True

		RenderModule.RenderPic(ScreenPic, scrn_scr_bmi)
	End Sub

	Public Sub Update_Block(ByRef ublock As Integer)
		Dim x, tilenum, tileY, blocknum, blockY, strX, strY, strnum, blockX, tilepal, tileX, y, screen As Integer
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
								y = (((strY * 32) + blockY * 16) + tileY * 8)
								x = (((strX * 32) + blockX * 16) + tileX * 8)
								RenderModule.DrawTile(scrn_scr_bmi, chrmap(tilenum), tilepal, x, y, romdat)
							Next tileX
						Next tileY
skipblock:
					Next blockX
				Next blockY
			Next strX
		Next strY
		If GetCfg("scrned_grid") = 1 Then DrawGrid()

		scrn_scr_bmi.bytesRGB_UpdatedSinceLastRender = True

		RenderModule.RenderPic(ScreenPic, scrn_scr_bmi)
	End Sub

	Private Sub ScreenDraw()
		Dim x, tilenum, tileY, blocknum, blockY, strX, strY, strnum, blockX, tilepal, tileX, y, screen As Integer
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
								y = (((strY * 32) + blockY * 16) + tileY * 8)
								x = (((strX * 32) + blockX * 16) + tileX * 8)
								RenderModule.DrawTile(scrn_scr_bmi, chrmap(tilenum), tilepal, x, y, romdat)
							Next tileX
						Next tileY
					Next blockX
				Next blockY
			Next strX
		Next strY

		If GetCfg("scrned_grid") = 1 Then DrawGrid()

		scrn_scr_bmi.bytesRGB_UpdatedSinceLastRender = True

		'enem_scrb_bmi.bits = enem_scr_bmi.bits
	End Sub

	Public Sub Update_TileRange(ByRef min As Integer, ByRef max As Integer)
		Dim x, tilenum, tileY, blocknum, blockY, strX, strY, strnum, blockX, tilepal, tileX, y, screen As Integer
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
									y = (((strY * 32) + blockY * 16) + tileY * 8)
									x = (((strX * 32) + blockX * 16) + tileX * 8)
									RenderModule.DrawTile(scrn_scr_bmi, chrmap(tilenum), tilepal, x, y, romdat)
								End If
							Next tileX
						Next tileY
					Next blockX
				Next blockY
			Next strX
		Next strY

		If GetCfg("scrned_grid") = 1 Then DrawGrid()
		scrn_scr_bmi.bytesRGB_UpdatedSinceLastRender = True
		RenderModule.RenderPic(ScreenPic, scrn_scr_bmi)

		For blockY = 0 To 1
			For blockX = 0 To 1
				blocknum = romdat(arrayAdjuster + offs(gem, 5) + (((curstrY * 16) + curstrX) * 4) + ((blockY * 2) + blockX))
				tilepal = Nibble(romdat(arrayAdjuster + offs(gem, 4) + blocknum), 1) And 3
				For tileY = 0 To 1
					For tileX = 0 To 1
						tilenum = romdat(arrayAdjuster + offs(gem, 3) + (((tileY * 2) + tileX) * &H100S) + blocknum)
						If tilenum >= min And tilenum <= max Then
							y = (blockY * 32) + (tileY * 16)
							x = (blockX * 32) + (tileX * 16)
							RenderModule.DrawTile(scrn_curstr_bmi, chrmap(tilenum), tilepal, x + 2, y + 2, romdat, 2)
						End If
					Next tileX
				Next tileY
			Next blockX
		Next blockY
		scrn_scr_bmi.bytesRGB_UpdatedSinceLastRender = True
		RenderModule.RenderPic(CurStrPic, scrn_curstr_bmi)
	End Sub

	Public Sub Update_CurStr()
		Dim tileY, y, tilepal, blockX, blockY, blocknum, tilenum, x, tileX As Integer
		For blockY = 0 To 1
			For blockX = 0 To 1
				blocknum = romdat(arrayAdjuster + offs(gem, 5) + (((curstrY * 16) + curstrX) * 4) + ((blockY * 2) + blockX))
				tilepal = Nibble(romdat(arrayAdjuster + offs(gem, 4) + blocknum), 1) And 3
				For tileY = 0 To 1
					For tileX = 0 To 1
						tilenum = romdat(arrayAdjuster + offs(gem, 3) + (((tileY * 2) + tileX) * &H100S) + blocknum)
						y = (blockY * 32) + (tileY * 16)
						x = (blockX * 32) + (tileX * 16)
						RenderModule.DrawTile(scrn_curstr_bmi, chrmap(tilenum), tilepal, x + 2, y + 2, romdat, 2)
					Next tileX
				Next tileY
			Next blockX
		Next blockY

		scrn_scr_bmi.bytesRGB_UpdatedSinceLastRender = True
		RenderModule.RenderPic(CurStrPic, scrn_curstr_bmi)
	End Sub

	Private Sub DrawGrid()
		Dim a, b As Integer
		For a = 0 To 7
			For b = 0 To 7
				RenderModule.DrawLineH(scrn_scr_bmi, (b * 32), (b * 32) + 31, (a * 32), &H20S)
				RenderModule.DrawLineV(scrn_scr_bmi, (b * 32), (a * 32), (a * 32) + 31, &H20S)
			Next b
		Next a

		scrn_scr_bmi.bytesRGB_UpdatedSinceLastRender = True
	End Sub


	Private Sub BDCheck_CheckStateChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles BDCheck.CheckStateChanged
		Dim a As Integer
		If BDCheck.Tag <> "" Then Exit Sub
		a = romdat(arrayAdjuster + offs(gem, o_ddA) + EditScrollMap)
		romdat(arrayAdjuster + offs(gem, o_ddA) + EditScrollMap) = (a And &H7FS) Or (BDCheck.CheckState * &H80S)
	End Sub


	Private Sub MPSetTB_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles _MPSetTB_1.Click, _MPSetTB_0.Click
		Dim Index As Short = 0

		For Each button As Button In MPSetTB
			If button.Name = eventSender.Name Then
				Exit For
			End If
			Index += 1
		Next

		Dim a, b As Integer
		Select Case gem
			Case 0
				romdat(arrayAdjuster + offs(gem, 51) + Index) = curscreen
				romdat(arrayAdjuster + offs(gem, 50) + Index) = curscroll
				For a = 0 To offs(gem, 19)
					b = romdat(arrayAdjuster + offs(gem, 11) + a)
					If b >= curscreen Then GoTo setmp_enemposfound
				Next a
setmp_enemposfound:
				romdat(arrayAdjuster + offs(gem, 52) + Index) = a
			Case 1
				a = Index
				b = (Index * 4)
				romdat(arrayAdjuster + rdata(dspa(d_ex) + 32) + (level * 2) + a) = curscreen
				romdat(arrayAdjuster + rdata(dspa(d_ex) + 31) + (level * 8) + b + 0) = curscreen
				romdat(arrayAdjuster + rdata(dspa(d_ex) + 31) + (level * 8) + b + 1) = curscroll
				'leave Initial CHR Load ID of mid-point data alone - is already good, or if not, this cant help it.
				'mid$(romdat, rdata(dspa(d_ex) + 31) + (level * 8) + b + 2, 1) = chr$(level)
				romdat(arrayAdjuster + rdata(dspa(d_ex) + 31) + (level * 8) + b + 3) = palset
			Case 2
				a = Index
				romdat(arrayAdjuster + rdata(dspa(d_ex) + 33) + (level * 6) + (a * 3) + 0) = curscreen
				romdat(arrayAdjuster + rdata(dspa(d_ex) + 33) + (level * 6) + (a * 3) + 1) = curscroll
				'Leave Graphics Set ID of mid-point data alone - no way to figure out good value besides current value
				'mid$(romdat, rdata(dspa(d_ex) + 33) + (level * 6) + (a * 3) + 2, 1) = chr$(0)
		End Select
		If Not (curscroll_sscrn = curscreen) Then MsgBox("This wont work very well. Make it at the start of a Scroll Map to have it work properly.")
		MiscEd.Update_Frm()
	End Sub

	Private Sub SBCheck_CheckStateChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles SBCheck.CheckStateChanged
		Dim a As Integer
		If SBCheck.Tag <> "" Then Exit Sub
		a = romdat(arrayAdjuster + offs(gem, o_ddA) + EditScrollMap)
		romdat(arrayAdjuster + offs(gem, o_ddA) + EditScrollMap) = (a And &HBFS) Or (SBCheck.CheckState * &H40S)
	End Sub



	'MM5: change of variables linked to sprite palette set ->

	Private Sub BGPalCheck_CheckStateChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles BGPalCheck.CheckStateChanged
		If BGPalCheck.Tag <> "" Then Exit Sub
		Dim tmp_sprpalset, bgpalchangeptr As Integer
		tmp_sprpalset = romdat(arrayAdjuster + offs(gem, o_ddA) + EditScrollMap) And &H3FS
		If tmp_sprpalset = 0 Then
			bgpalchangeptr = offs(gem, 49) + 8 + 0
		Else
			bgpalchangeptr = offs(gem, 27) + ((tmp_sprpalset - 1) * 8) + 0
		End If
		romdat(arrayAdjuster + bgpalchangeptr) = (CShort(romdat(arrayAdjuster + bgpalchangeptr) And &H7FS) + (BGPalCheck.CheckState * &H80S))
		MFLE_Main.Update_PalSet()
	End Sub

	Private Sub ScreenPic_DoubleClick(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles ScreenPic.DoubleClick
		'MsgBox "dont double click! its illegal!"

	End Sub



	Private Sub ScreenPic_MouseDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles ScreenPic.MouseDown
		Dim Button As Short = eventArgs.Button \ &H100000
		Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
		Dim x As Single = eventArgs.X
		Dim y As Single = eventArgs.Y
		Dim strY, tileY, blockY, blocknum, screen, a, strnum, tilepal, blockX, tileX, strX As Integer

		strY = VWidth(Int(y / 32), 0, 7)
		strX = VWidth(Int(x / 32), 0, 7)
		screen = MegaFLEX_Main.GetScreen

		If (Button And 1) And (Shift = 0) Then
			If gem < 3 Then
				romdat(arrayAdjuster + offs(gem, 6) + (screen * 64) + ((strY * 8) + strX)) = ((curstrY * 16) + curstrX)
				strnum = romdat(arrayAdjuster + offs(gem, 6) + (screen * 64) + ((strY * 8) + strX))
			Else
				romdat(arrayAdjuster + offs(gem, 6) + (screen * 8) + ((strY * 256) + strX)) = ((curstrY * 16) + curstrX)
				strnum = romdat(arrayAdjuster + offs(gem, 6) + (screen * 8) + ((strY * 256) + strX))
			End If
			'mid$(romdat, (offs(gem, 6) + (screen * 64) + ((strY * 8) + strX)), 1) = chr$((curstrY * 16) + curstrX)
			'strnum = Asc(mid$(romdat, (offs(gem, 6) + (screen * 64) + ((strY * 8) + strX)), 1))
			For blockY = 0 To 1
				For blockX = 0 To 1
					blocknum = romdat(arrayAdjuster + offs(gem, 5) + (strnum * 4) + ((blockY * 2) + blockX))
					tilepal = Nibble(romdat(arrayAdjuster + offs(gem, 4) + blocknum), 1) And 3
					For tileY = 0 To 1
						For tileX = 0 To 1
							RenderModule.DrawTile(scrn_scr_bmi, chrmap(romdat(arrayAdjuster + offs(gem, 3) + (((tileY * 2) + tileX) * &H100S) + blocknum)), tilepal, (((strX * 32) + blockX * 16) + tileX * 8), (((strY * 32) + blockY * 16) + tileY * 8), romdat)
						Next tileX
					Next tileY
				Next blockX
			Next blockY
			If GetCfg("scrned_grid") = 1 Then DrawGrid()

			scrn_scr_bmi.bytesRGB_UpdatedSinceLastRender = True
			RenderModule.RenderPic(ScreenPic, scrn_scr_bmi)
			'upd_scrnstr_strY = a
			'upd_scrnstr_strX = b
			MFLE_Main.Update_ScrnStr(strY, strX)
		End If
		If (Button And 2) And (Shift = 0) Then
			If gem < 3 Then
				a = romdat(arrayAdjuster + offs(gem, 6) + (screen * 64) + ((strY * 8) + strX))
			Else
				a = romdat(arrayAdjuster + offs(gem, 6) + (screen * 8) + ((strY * 256) + strX))
			End If
			oldstrY = curstrY
			oldstrX = curstrX
			curstrY = Int(a / 16)
			curstrX = a And 15
			MFLE_Main.Update_CurStr()
			'If MetametatileTable.Visible Then MetametatileTable.CurStrSet 1
			'curstrY = int(Y / 32)
		End If
	End Sub

	'implemented as "MouseUp" to avoid Double Click "conflicts"
	Private Sub ScreenPic_MouseUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles ScreenPic.MouseUp
		Dim Button As Short = eventArgs.Button \ &H100000
		Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
		Dim x As Single = eventArgs.X
		Dim y As Single = eventArgs.Y
		Dim strY, tileY, blockY, blocknum, screen, strnum, tilepal, blockX, tileX, strX As Integer

		strY = VWidth(Int(y / 32), 0, 7)
		strX = VWidth(Int(x / 32), 0, 7)
		screen = MegaFLEX_Main.GetScreen

		If (Button And 3) And (Shift > 0) Then

			If gem < 3 Then
				strnum = romdat(arrayAdjuster + offs(gem, 6) + (screen * 64) + ((strY * 8) + strX))
			Else
				strnum = romdat(arrayAdjuster + offs(gem, 6) + (screen * 8) + ((strY * 256) + strX))
			End If

			If (Button And 1) Then
				strnum = (strnum + 1) And &HFFS
			Else
				strnum = (strnum - 1) And &HFFS
			End If

			If gem < 3 Then
				romdat(arrayAdjuster + offs(gem, 6) + (screen * 64) + ((strY * 8) + strX)) = strnum
			Else
				romdat(arrayAdjuster + offs(gem, 6) + (screen * 8) + ((strY * 256) + strX)) = strnum
			End If

			For blockY = 0 To 1
				For blockX = 0 To 1
					blocknum = romdat(arrayAdjuster + offs(gem, 5) + (strnum * 4) + ((blockY * 2) + blockX))
					tilepal = Nibble(romdat(arrayAdjuster + offs(gem, 4) + blocknum), 1) And 3
					For tileY = 0 To 1
						For tileX = 0 To 1
							RenderModule.DrawTile(scrn_scr_bmi, chrmap(romdat(arrayAdjuster + offs(gem, 3) + (((tileY * 2) + tileX) * &H100S) + blocknum)), tilepal, (((strX * 32) + blockX * 16) + tileX * 8), (((strY * 32) + blockY * 16) + tileY * 8), romdat)
						Next tileX
					Next tileY
				Next blockX
			Next blockY
			If GetCfg("scrned_grid") = 1 Then DrawGrid()

			scrn_scr_bmi.bytesRGB_UpdatedSinceLastRender = True
			RenderModule.RenderPic(ScreenPic, scrn_scr_bmi)
			MFLE_Main.Update_ScrnStr(strY, strX)

		End If

	End Sub

	Private Sub ScreenPic_MouseMove(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles ScreenPic.MouseMove
		Dim Button As Short = eventArgs.Button \ &H100000
		Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
		Dim x As Single = eventArgs.X
		Dim y As Single = eventArgs.Y
		Dim strY As Integer
		Dim strX As Integer

		strY = VWidth(Int(y / 32), 0, 7)
		strX = VWidth(Int(x / 32), 0, 7)

		If Button Then
			If (strY <> oldClickedStrY) Or (strX <> oldClickedStrX) Then
				oldClickedStrY = strY
				oldClickedStrX = strX
				ScreenPic_MouseDown(ScreenPic, New System.Windows.Forms.MouseEventArgs(Button * &H100000, 0, x, y, 0))
				ScreenPic_MouseUp(ScreenPic, New System.Windows.Forms.MouseEventArgs(Button * &H100000, 0, x, y, 0))
			End If
		End If

		'If Button Then ScreenPic_MouseDown Button, Shift, x, y
	End Sub

	Private Sub ScreenEd_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
		Dim KeyCode As Short = eventArgs.KeyCode
		Dim Shift As Short = eventArgs.KeyData \ &H10000
		MFLE_Main.Global_KeyDown(KeyCode, Shift)
	End Sub


	Private Sub ScrnScroll_Change(ByVal newScrollValue As Integer)
		If ScrnScroll.Tag = "" Then
			curscreen = newScrollValue
			MFLE_Main.Update_Scrn()
		End If
	End Sub

	Private Sub ScrnScroll_Scroll(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.ScrollEventArgs) Handles ScrnScroll.Scroll
		Select Case eventArgs.Type
			Case System.Windows.Forms.ScrollEventType.EndScroll
				ScrnScroll_Change(eventArgs.NewValue)
		End Select
	End Sub

	Private Sub BtnDumpLevelMap_Click(sender As Object, e As EventArgs) Handles BtnDumpLevelMap.Click
		MessageBox.Show("Will eventually be implemented", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
	End Sub


	Private Sub CurScrnTB_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles CurScrnTB.TextChanged
		If CurScrnTB.Tag = "" Then

			If scenemode = True Then
				SetTBCoolNumWithValidation(CurScrnTB, CurScrnTB.Text, offs(gem, 17), 2, True)
			Else
				SetTBCoolNumWithValidation(CurScrnTB, CurScrnTB.Text, offs(gem, 16), 2, True)
			End If

			curscreen = Dec((CurScrnTB.Text))
			MFLE_Main.Update_Scrn()
		End If
	End Sub


	'NumericUpDown
	'================

	Private Sub BGPalUD_ActionUponNewValue()
		If BGPalUD.Tag <> "" Then Exit Sub
		If BGPalUD_ValuePrevious = BGPalUD.Value Then Exit Sub

		BGPalUD_ValuePrevious = BGPalUD.Value

		Dim tmp_sprpalset, bgpalchangeptr As Integer
		tmp_sprpalset = romdat(arrayAdjuster + offs(gem, o_ddA) + EditScrollMap) And &H3FS
		If tmp_sprpalset = 0 Then
			bgpalchangeptr = offs(gem, 49) + 8 + 0
		Else
			bgpalchangeptr = offs(gem, 27) + ((tmp_sprpalset - 1) * 8) + 0
		End If
		romdat(arrayAdjuster + bgpalchangeptr) = (CShort(romdat(arrayAdjuster + bgpalchangeptr) And &H80S) + VWidth(Dec((BGPalUD.Text)), 0, &H7FS))
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

	Private Sub BotCHR_UD_ActionUponNewValue()
		If botCHR_UD.Tag <> "" Then Exit Sub
		If botCHR_UD_ValuePrevious = botCHR_UD.Value Then Exit Sub

		botCHR_UD_ValuePrevious = botCHR_UD.Value

		ScrollInfoChangeFlag = True
		Dim changeptr, a, tmp_sprpalset As Integer
		tmp_sprpalset = romdat(arrayAdjuster + offs(gem, o_ddA) + EditScrollMap) And &H3FS
		changeptr = offs(gem, 27) + ((tmp_sprpalset - 1) * 8) + 4
		a = romdat(arrayAdjuster + changeptr)
		romdat(arrayAdjuster + changeptr) = Dec((botCHR_UD.Text)) And &HFFS
		MFLE_Main.Update_Scrn()
		ScrollInfoChangeFlag = False
	End Sub

	Private Sub BotCHR_UD_ValueChanged(sender As Object, e As EventArgs) Handles botCHR_UD.ValueChanged
		If UpdateUDCool(sender) Then
			' When here, Value was validated
			BotCHR_UD_ActionUponNewValue()
		End If
	End Sub

	Private Sub BotCHR_UD_KeyUp(sender As Object, e As KeyEventArgs) Handles botCHR_UD.KeyUp
		' Set new value (with validations)
		SetUDCool(CType(sender, NumericUpDown), sender.Text, 2)

		' When here, Value was validated
		BotCHR_UD_ActionUponNewValue()
	End Sub

	Private Sub DDAUD_ActionUponNewValue()
		If DDAUD.Tag <> "" Then Exit Sub
		If DDAUD_ValuePrevious = DDAUD.Value Then Exit Sub

		DDAUD_ValuePrevious = DDAUD.Value

		Select Case gem
			Case 0
				romdat(arrayAdjuster + offs(gem, o_ddA) + (EditScrollMap * 2) + 0) = (VWidth(Dec((DDAUD.Text)), 0, rdata(dspa(d_ex) + 1)))
				If EditScrollMap = curscroll Then
					MFLE_Main.SprCHRPALSetup()
					MFLE_Main.Update_Scrn()
				Else
					UpdateScrollStuff()
				End If
			Case 1
				romdat(arrayAdjuster + offs(gem, o_ddA) + EditScrollMap) = (VWidth(Dec((DDAUD.Text)), 0, offs(gem, 18)))
				MFLE_Main.Update_PalSet()
		End Select
	End Sub

	Private Sub DDAUD_ValueChanged(sender As Object, e As EventArgs) Handles DDAUD.ValueChanged
		If UpdateUDCool(sender) Then
			' When here, Value was validated
			DDAUD_ActionUponNewValue()
		End If
	End Sub

	Private Sub DDAUD_KeyUp(sender As Object, e As KeyEventArgs) Handles DDAUD.KeyUp
		' Set new value (with validations)
		SetUDCool(CType(sender, NumericUpDown), sender.Text, 2)

		' When here, Value was validated
		DDAUD_ActionUponNewValue()
	End Sub

	Private Sub DDBUD_ActionUponNewValue()
		If DDBUD.Tag <> "" Then Exit Sub
		If DDBUD_ValuePrevious = DDBUD.Value Then Exit Sub

		DDBUD_ValuePrevious = DDBUD.Value

		Select Case gem
			Case 0
				romdat(arrayAdjuster + offs(gem, o_ddA) + (EditScrollMap * 2) + 1) = (VWidth(Dec((DDBUD.Text)), 0, offs(gem, 18)))
				MFLE_Main.Update_PalSet()
			Case 1
				romdat(arrayAdjuster + offs(gem, o_ddB) + EditScrollMap) = (VWidth(Dec((DDBUD.Text)), 0, rdata(dspa(d_ex) + 11)))
				If EditScrollMap = curscroll Then
					MFLE_Main.ScrollEffectLoad(curscroll) 'Asc(mid$(romdat, offs(gem, o_ddB) + curscroll, 1)),
					MFLE_Main.Update_Scrn()
				Else
					UpdateScrollStuff()
				End If
		End Select
	End Sub

	Private Sub DDBUD_ValueChanged(sender As Object, e As EventArgs) Handles DDBUD.ValueChanged
		If UpdateUDCool(sender) Then
			' When here, Value was validated
			DDBUD_ActionUponNewValue()
		End If
	End Sub

	Private Sub DDBUD_KeyUp(sender As Object, e As KeyEventArgs) Handles DDBUD.KeyUp
		' Set new value (with validations)
		SetUDCool(CType(sender, NumericUpDown), sender.Text, 2)

		' When here, Value was validated
		DDBUD_ActionUponNewValue()
	End Sub

	Private Sub PalSetUD_ActionUponNewValue()
		If PalSetUD.Tag <> "" Then Exit Sub
		If PalSetUD_ValuePrevious = PalSetUD.Value Then Exit Sub

		PalSetUD_ValuePrevious = PalSetUD.Value

		Dim a As Integer
		a = romdat(arrayAdjuster + offs(gem, o_ddA) + EditScrollMap)
		romdat(arrayAdjuster + offs(gem, o_ddA) + EditScrollMap) = (a And &HC0S) Or (VWidth(Dec((PalSetUD.Text)), 0, rdata(dspa(d_ex) + 14)))
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

	Private Sub ScrnPresUDForSwap_ActionUponNewValue()
		If ScrnPresUDForSwap.Tag <> "" Then Exit Sub
		If ScrnPresUDForSwap_ValuePrevious = ScrnPresUDForSwap.Value Then Exit Sub

		ScrnPresUDForSwap_ValuePrevious = ScrnPresUDForSwap.Value
	End Sub

	Private Sub ScrnPresUD_ActionUponNewValue()
		If ScrnPresUD.Tag <> "" Then Exit Sub
		If ScrnPresUD_ValuePrevious = ScrnPresUD.Value Then Exit Sub

		ScrnPresUD_ValuePrevious = ScrnPresUD.Value

		If gem = 3 Then Exit Sub
		romdat(arrayAdjuster + offs(gem, 7) + curscreen) = Dec((ScrnPresUD.Text)) And &HFFS
		If romdat(arrayAdjuster + offs(gem, 7) + curscreen) > offs(gem, 17) Then romdat(arrayAdjuster + offs(gem, 7) + curscreen) = offs(gem, 17)
		MFLE_Main.Update_Scrn()
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

	Private Sub ScrollMapUD_ActionUponNewValue()
		If ScrollMapUD.Tag <> "" Then Exit Sub
		If ScrollMapUD_ValuePrevious = ScrollMapUD.Value Then Exit Sub

		ScrollMapUD_ValuePrevious = ScrollMapUD.Value

		EditScrollMap = VWidth(Dec((ScrollMapUD.Text)) And &HFFS, 0, offs(gem, 61))
		UpdateScrollStuff()
	End Sub

	Private Sub ScrollMapUD_ValueChanged(sender As Object, e As EventArgs) Handles ScrollMapUD.ValueChanged
		If UpdateUDCool(sender) Then
			' When here, Value was validated
			ScrollMapUD_ActionUponNewValue()
		End If
	End Sub

	Private Sub ScrollMapUD_KeyUp(sender As Object, e As KeyEventArgs) Handles ScrollMapUD.KeyUp
		' Set new value (with validations)
		SetUDCool(CType(sender, NumericUpDown), sender.Text, 2)

		' When here, Value was validated
		ScrollMapUD_ActionUponNewValue()
	End Sub

	Private Sub SLenUD_ActionUponNewValue()
		If SLenUD.Tag <> "" Then Exit Sub
		If SLenUD_ValuePrevious = SLenUD.Value Then Exit Sub

		SLenUD_ValuePrevious = SLenUD.Value

		ScrollInfoChangeFlag = True

		If gem < 2 Then
			romdat(arrayAdjuster + offs(gem, o_dirtype) + EditScrollMap) = (CShort(romdat(arrayAdjuster + offs(gem, o_dirtype) + EditScrollMap) And &HF0S) + CShort(Val(Dec(SLenUD.Text)) And SLenUD.Maximum))
		Else
			romdat(arrayAdjuster + offs(gem, o_dirtype) + EditScrollMap) = (CShort(romdat(arrayAdjuster + offs(gem, o_dirtype) + EditScrollMap) And &HE0S) + CShort(Val(Dec(SLenUD.Text)) And SLenUD.Maximum))
		End If

		MFLE_Main.Update_Scrn()
		ScrollInfoChangeFlag = False
	End Sub

	Private Sub SLenUD_ValueChanged(sender As Object, e As EventArgs) Handles SLenUD.ValueChanged
		If UpdateUDCool(sender) Then
			' When here, Value was validated
			SLenUD_ActionUponNewValue()
		End If
	End Sub

	Private Sub SLenUD_KeyUp(sender As Object, e As KeyEventArgs) Handles SLenUD.KeyUp
		' Set new value (with validations)
		SetUDCool(CType(sender, NumericUpDown), sender.Text, 2)

		' When here, Value was validated
		SLenUD_ActionUponNewValue()
	End Sub
	Private Sub STUD_ActionUponNewValue()
		If STUD.Tag <> "" Then Exit Sub
		If STUD_ValuePrevious = STUD.Value Then Exit Sub

		STUD_ValuePrevious = STUD.Value

		If gem < 2 Then
			romdat(arrayAdjuster + offs(gem, o_dirtype) + EditScrollMap) = (CShort(romdat(arrayAdjuster + offs(gem, o_dirtype) + EditScrollMap) And &HFS) + (CShort(Dec((STUD.Text)) And &HFS) * &H10S))
		Else
			romdat(arrayAdjuster + offs(gem, o_dirtype) + EditScrollMap) = (CShort(romdat(arrayAdjuster + offs(gem, o_dirtype) + EditScrollMap) And &H1FS) + (CShort(Val(STUD.Text) And 7) * &H20S))
		End If
		UpdateScrollStuff()
	End Sub

	Private Sub STUD_ValueChanged(sender As Object, e As EventArgs) Handles STUD.ValueChanged
		If UpdateUDCool(sender) Then
			' When here, Value was validated
			STUD_ActionUponNewValue()
		End If
	End Sub

	Private Sub STUD_KeyUp(sender As Object, e As KeyEventArgs) Handles STUD.KeyUp
		' Set new value (with validations)
		SetUDCool(CType(sender, NumericUpDown), sender.Text, 1)

		' When here, Value was validated
		STUD_ActionUponNewValue()
	End Sub

	Private Sub Button1_Click(sender As Object, e As EventArgs) Handles BtnExportScreensLayout.Click
		MessageBox.Show("Will eventually be implemented", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
	End Sub

	Private Sub BtnSwapScreenWithCurrent_Click(sender As Object, e As EventArgs) Handles BtnSwapScreenWithCurrent.Click
		If gem = 3 Then
			MessageBox.Show("Not supported for Mega Man 6", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
			Exit Sub
		End If

		Dim a, scr1, scr2 As Integer
		Dim tempID As Integer ' Will hold Metametatiles during copy between Screens

		scr1 = ScrnPresUD.Value
		scr2 = ScrnPresUDForSwap.Value

		' Loop through every Metametatiles of Screens
		For a = 0 To &H3FS
			' Swap them
			tempID = romdat(arrayAdjuster + offs(gem, o_scrp) + a + (scr1 * &H40S))
			romdat(arrayAdjuster + offs(gem, o_scrp) + a + (scr1 * &H40S)) = romdat(arrayAdjuster + offs(gem, o_scrp) + a + (scr2 * &H40S))
			romdat(arrayAdjuster + offs(gem, o_scrp) + a + (scr2 * &H40S)) = tempID
		Next

		' Refresh visuals
		Update_Frm()
	End Sub

	Private Sub ScrnPresUDForSwap_ValueChanged(sender As Object, e As EventArgs) Handles ScrnPresUDForSwap.ValueChanged
		If UpdateUDCool(sender) Then
			' When here, Value was validated
			ScrnPresUDForSwap_ActionUponNewValue()
		End If
	End Sub

	Private Sub ScrnPresUDForSwap_KeyUp(sender As Object, e As KeyEventArgs) Handles ScrnPresUDForSwap.KeyUp
		' Set new value (with validations)
		SetUDCool(CType(sender, NumericUpDown), sender.Text, 2)

		' When here, Value was validated
		ScrnPresUDForSwap_ActionUponNewValue()
	End Sub

	Private Sub CheckBox1_CheckStateChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles CheckBox1.CheckedChanged
		ignore_scrlayout = CheckBox1.CheckState

		ScrnPresUD.Visible = Not ignore_scrlayout
		LblScreenPreset.Visible = ScrnPresUD.Visible
	End Sub

	Private Sub BtnMoreOptions_Click(sender As Object, e As EventArgs) Handles BtnMoreOptions.Click
		If (BtnMoreOptions.Text = BtnMoreOptionsMoreOptionsString) Then
			BtnMoreOptions.Text = BtnMoreOptionsLessOptionsString
			Me.Height = GbxMoreOptions.Top + GbxMoreOptions.Height + 43
			GbxMoreOptions.Visible = True
		Else
			BtnMoreOptions.Text = BtnMoreOptionsMoreOptionsString
			Me.Height = initialHeight
			GbxMoreOptions.Visible = False
		End If
	End Sub

	Private Sub BtnFillScreenWithCurrentMetametatile_Click(sender As Object, e As EventArgs) Handles BtnFillScreenWithCurrentMetametatile.Click
		Dim strX, strY, screen As Integer

		screen = MegaFLEX_Main.GetScreen

		For strX = 0 To 7
			For strY = 0 To 7
				If gem < 3 Then
					romdat(arrayAdjuster + offs(gem, 6) + (screen * 64) + ((strY * 8) + strX)) = ((curstrY * 16) + curstrX)
				Else
					romdat(arrayAdjuster + offs(gem, 6) + (screen * 8) + ((strY * 256) + strX)) = ((curstrY * 16) + curstrX)
				End If
			Next strY
		Next strX
	End Sub



#Region "WasAlreadyCommented"
	'Private Sub DirList_Click()
	'If DirList.Tag = "" Then
	'    MakeXSMData
	'    XSMD_Dir(curscreen) = DirList.ListIndex
	'    ConvertXSMData
	'End If
	'End Sub
#End Region
End Class