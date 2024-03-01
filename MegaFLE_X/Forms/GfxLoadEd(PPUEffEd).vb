Option Explicit On
Friend Class GfxLoadEd
	Inherits System.Windows.Forms.Form
	Private ReadOnly paltmpA(3) As Integer
	Private ReadOnly paltmpB(3) As Integer
	Private ReadOnly paltmpC(3) As Object
	'Private chrtmp(15) As Byte   'not used

	Private CurLoadPiece As Short
	Private NumCHRLoads As Integer
	Private LoadDataStart As Short
	
	Private PPUEffMode, ChunkSizeMode As Integer

    Private PPUEffDataBot As DataMoverBot

	Private LSDIDUD_ValuePrevious As Integer
	Private EffIDUD_ValuePrevious As Integer
	Private SrcBankUD_ValuePrevious As Integer
	Private SrcHiUD_ValuePrevious As Integer
	Private DstVRAMUD_ValuePrevious As Integer
	Private CopyTilesUD_ValuePrevious As Integer

	'Objects that group many items
	' PictureBox
	Private ColPic() As PictureBox
	' RadioButton
	Private PPUEffModeOpt() As RadioButton
	' TextBox
	Private ColTB() As TextBox

	' Initialisation
	'================

	Private Sub Form_Initialize()
		'Objects that group many items
		' PictureBox
		ColPic = New PictureBox() {_ColPic_0, _ColPic_1, _ColPic_2, _ColPic_3, _ColPic_4, _ColPic_5, _ColPic_6, _ColPic_7}
		' RadioButton
		PPUEffModeOpt = New RadioButton() {_PPUEffModeOpt_0, _PPUEffModeOpt_1, _PPUEffModeOpt_2, _PPUEffModeOpt_3}
		' TextBox
		ColTB = New TextBox() {_ColTB_0, _ColTB_1, _ColTB_2, _ColTB_3, _ColTB_4, _ColTB_5, _ColTB_6, _ColTB_7}

		'Previous values that need to be stored
		LSDIDUD_ValuePrevious = LSDIDUD.Value
		EffIDUD_ValuePrevious = EffIDUD.Value
		SrcBankUD_ValuePrevious = SrcBankUD.Value
		SrcHiUD_ValuePrevious = SrcHiUD.Value
		DstVRAMUD_ValuePrevious = DstVRAMUD.Value
		CopyTilesUD_ValuePrevious = CopyTilesUD.Value
	End Sub

	Public Sub Manual_Init()
		'Calling it ensure constructor above is called
	End Sub

	Private Sub GfxLoadEd_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
		e.Cancel = True

		Me.Hide()
	End Sub

	' Functions
	'================
	'================
	'================

	' Updates
	'================

	Public Sub Update_Frm()
		PPUEffDataBot = New DataMoverBot

		paltmpA(0) = RGB(&H20S, &H20S, &H20S)
		paltmpA(1) = RGB(&HF0S, &HF0S, &HF0S)
		paltmpA(2) = RGB(&HA0S, &HA0S, &HA0S)
		paltmpA(3) = RGB(&H60S, &H60S, &H60S)

		paltmpB(0) = RGB(0, 0, 0)
		paltmpB(1) = RGB(&H0S, &HBFS, &HFFS)
		paltmpB(2) = RGB(&H0S, &H5FS, &HBFS)
		paltmpB(3) = RGB(&H0S, &H1FS, &H7FS)

		'paltmpB(0) = RGB(0, 0, 0)
		'paltmpB(1) = RGB(&H0, &H60, &HF0)
		'paltmpB(2) = RGB(&H0, &H30, &HA0)
		'paltmpB(3) = RGB(&H0, &H0, &H60)

		paltmpC(0) = RGB(&H40S, &H0S, &H0S)
		paltmpC(1) = RGB(&HFFS, &HFFS, &HFFS)
		paltmpC(2) = RGB(&HF0S, &H80S, &H80S)
		paltmpC(3) = RGB(&H80S, &H0S, &H0S)

		' This is never set to 1 within MegaFLE_X Code
		If GetCfg("enableadvancedfeat") = 1 Then
			ResetBtn.Visible = True
		Else
			ResetBtn.Visible = False
		End If

		PPUEffMode = 0
		UpdPPUEffMode()
		UpdPPUEff()
	End Sub

	Public Sub Update_Level()
		If PPUEffMode = 0 Then
			PPUEffDataBot.CurEntry = level
			UpdPPUEff()
		End If
	End Sub
	
	Public Sub Update_PPUEff()
		If PPUEffMode = 2 Then
			PPUEffDataBot.CurEntry = romdat(arrayAdjuster + offs(gem, o_ddB) + curscroll)
			UpdPPUEff()
		End If
	End Sub

	Private Sub UpdPPUEffMode()
		SetOptCool(PPUEffModeOpt(PPUEffMode), True)

		LSDIDUD.Enabled = False
		EffIDUD.Enabled = False

		If PPUEffMode < 2 Then
			ChunkSizeMode = 1
			PPUEffDataBot.DataBotFeed(dspa(71))
		Else
			ChunkSizeMode = 0
			PPUEffDataBot.DataBotFeed(dspa(72))
		End If

		PPUEff_GetFreeSpace()

		Select Case PPUEffMode
			Case 0
			Case 1
				LSDIDUD.Enabled = True
				SetUDCool(LSDIDUD, Hex(curlsdid), 2)
			Case 3
				EffIDUD.Enabled = True
				SetUDCool(EffIDUD, Hex(curppueff), 2)
		End Select

	End Sub

	Private Sub UpdPPUEff()
		Select Case PPUEffMode
			Case 0
				PPUEffDataBot.CurEntry = level
			Case 1
				PPUEffDataBot.CurEntry = curlsdid
			Case 2
				PPUEffDataBot.CurEntry = romdat(arrayAdjuster + offs(gem, o_ddB) + curscroll)
			Case 3
				PPUEffDataBot.CurEntry = curppueff
		End Select

		'Select Case PPUEffMode
		'Case 0
		'a = Asc(mid$(romdat, rdata(dspa(d_ex) + 2) + level, 1))
		'b = Asc(mid$(romdat, rdata(dspa(d_ex) + 3) + level, 1))
		'ppueff_ptr = (b * &H100) + a
		'ppueff_rom = ((b - &HA0 + rdata(dspa(d_ex) + 4)) * &H100) + a + &H11
		'ppueff_ptrarr_count = &H6F
		'End Select

		If PPUEffDataBot.GetByte(0) >= &H80S Then
			LoadDataStart = 1
		Else
			LoadDataStart = 8
		End If

		UpdSprPal()

		CurLoadPiece = 0
		UpdCHRLoadList()

		UpdLoadPiece()
		UpdFreeSpaceLab()

	End Sub

	Private Sub UpdSprPal()
		Dim a As Short

		If PPUEffDataBot.GetByte(0) >= &H80S Then
			SetCheckCool(HasSprPalCheck, 0)
			For a = 0 To ColPic.Length - 1
				If a = 4 Then a += 1
				ColPic(a).Enabled = False
				ColTB(a).Enabled = False
			Next a
		Else
			SetCheckCool(HasSprPalCheck, 1)
			For a = 0 To ColPic.Length - 1
				If a = 4 Then a += 1
				ColPic(a).Enabled = True
				ColTB(a).Enabled = True
				ColPic(a).BackColor = System.Drawing.ColorTranslator.FromOle(RGBmirr(NESPAL(PPUEffDataBot.GetByte(a))))
				SetTBCoolText(ColTB(a), Hex(PPUEffDataBot.GetByte(a)))
			Next a
		End If

	End Sub

	Private Sub UpdCHRLoadList()
		Dim e, c, a, b, d, f As Integer
		b = 0
		f = 0
		CHRLoadList.Items.Clear()
		'If PPUEffDataBot.GetByte(0) >= &H80 Then b = 1 Else b = 8
		Do
			a = PPUEffDataBot.GetByte(LoadDataStart + b + 0)
			If a = &HFFS Then GoTo addlistdone
			c = PPUEffDataBot.GetByte(LoadDataStart + b + 1)
			d = PPUEffDataBot.GetByte(LoadDataStart + b + 2)
			e = PPUEffDataBot.GetByte(LoadDataStart + b + 3)
			CHRLoadList.Items.Add(CStr(f) & ": " & Hex(a) & ":" & Hex(d) & " -> " & Hex(e) & " (" & Hex(c) & ")")
			b += 4
			f += 1
		Loop Until (b >= &HFFS)
addlistdone:

		NumCHRLoads = f

		If NumCHRLoads > 0 Then
			If CHRLoadList.Items.Count > CurLoadPiece Then
				SetListCool(CHRLoadList, CurLoadPiece)
			Else
				SetListCool(CHRLoadList, 0)
			End If
		End If
	End Sub

	Private Sub UpdLoadPiece()
		'SetTBCoolText SrcBankTB, hex$(Asc(mid$(romdat, (PPUEff_lddatstart + (CurLoadPiece * 4)), 1)))
		'SetTBCoolText SrcHiTB, hex$(Asc(mid$(romdat, (PPUEff_lddatstart + (CurLoadPiece * 4)) + 2, 1)))
		'SetTBCoolText DstVRAMTB, hex$(Asc(mid$(romdat, (PPUEff_lddatstart + (CurLoadPiece * 4)) + 3, 1)))
		'SetTBCoolText CopyTilesTB, hex$(Asc(mid$(romdat, (PPUEff_lddatstart + (CurLoadPiece * 4)) + 1, 1)))

		If NumCHRLoads > 0 Then
			SetUDCool(SrcBankUD, Hex(PPUEffDataBot.GetByte(LoadDataStart + (CurLoadPiece * 4))), 2)
			SetUDCool(SrcHiUD, Hex(PPUEffDataBot.GetByte(LoadDataStart + (CurLoadPiece * 4) + 2)), 2)
			SetUDCool(DstVRAMUD, Hex(PPUEffDataBot.GetByte(LoadDataStart + (CurLoadPiece * 4) + 3)), 2)
			SetUDCool(CopyTilesUD, Hex(PPUEffDataBot.GetByte(LoadDataStart + (CurLoadPiece * 4) + 1)), 2)
			SrcBankUD.Enabled = True
			SrcHiUD.Enabled = True
			DstVRAMUD.Enabled = True
			CopyTilesUD.Enabled = True
		Else
			SetUDCool(SrcBankUD, "", 2)
			SetUDCool(SrcHiUD, "", 2)
			SetUDCool(DstVRAMUD, "", 2)
			SetUDCool(CopyTilesUD, "", 2)
			SrcBankUD.Enabled = False
			SrcHiUD.Enabled = False
			DstVRAMUD.Enabled = False
			CopyTilesUD.Enabled = False
		End If

		'a = Asc(mid$(romdat, (PPUEff_lddatstart + (CurLoadPiece * 4)), 1))
		'a = a * &H2000
		'a = a + ((Asc(mid$(romdat, (PPUEff_lddatstart + (CurLoadPiece * 4)) + 2, 1)) - &H80) * &H100) + &H10
		'DrawSrcCHRWindow
		'If ChunkSizeMode = 0 Then
		'    DrawCHRWindow a, Asc(mid$(romdat, (PPUEff_lddatstart + (CurLoadPiece * 4)) + 1, 1))
		'Else
		'    DrawCHRWindow a, (Asc(mid$(romdat, (PPUEff_lddatstart + (CurLoadPiece * 4)) + 1, 1)) * &H10)
		'End If
		DrawSrcCHRWindow()
		DrawDstCHRWindow()
	End Sub

	Private Sub UpdFreeSpaceLab()
		FreeSpaceLab.Text = "$" & Hex(PPUEffDataBot.FreeSpace) & " bytes"
	End Sub

	' Drawing
	'================
	Private Sub DrawSrcCHRWindow()
		Dim offset As Integer
		Dim TilesHighlight As Short
		Dim x, Y As Integer
		Dim tmp_bmi As New BITMAPINFO()

		tmp_bmi.Initialize()

		tmp_bmi.pal(0) = RGBmirr(paltmpB(0))
		tmp_bmi.pal(1) = RGBmirr(paltmpB(1))
		tmp_bmi.pal(2) = RGBmirr(paltmpB(2))
		tmp_bmi.pal(3) = RGBmirr(paltmpB(3))
		tmp_bmi.pal(4) = RGBmirr(paltmpA(0))
		tmp_bmi.pal(5) = RGBmirr(paltmpA(1))
		tmp_bmi.pal(6) = RGBmirr(paltmpA(2))
		tmp_bmi.pal(7) = RGBmirr(paltmpA(3))

		tmp_bmi.palette_UpdatedSinceLastBytesRGB_Update = True

		RenderModule.PB_Init(TileSrcPic, tmp_bmi)

		If NumCHRLoads = 0 Then GoTo justdrawblank

		If PPUEffDataBot.GetByte(LoadDataStart + (CurLoadPiece * 4) + 2) < &H80S Then GoTo justdrawblank

		offset = PPUEffDataBot.GetByte(LoadDataStart + (CurLoadPiece * 4))
		'If PPUEffDataBot.GetByte(LoadDataStart + (CurLoadPiece * 4) + 2) >= &HC0 Then offset = &H3C
		offset *= &H2000S
		offset = offset + ((PPUEffDataBot.GetByte(LoadDataStart + (CurLoadPiece * 4) + 2) - &H80S) * &H100S) + &H10S

		If ChunkSizeMode = 0 Then
			TilesHighlight = PPUEffDataBot.GetByte(LoadDataStart + (CurLoadPiece * 4) + 1)
		Else
			TilesHighlight = (PPUEffDataBot.GetByte(LoadDataStart + (CurLoadPiece * 4) + 1) * &H10S)
		End If

		For Y = 0 To 31
			For x = 0 To 15
				'For a = 0 To 15
				'   chrtmp(a) = Asc(mid$(romdat, chrmap((y * 16) + x) + a + 1, 1))
				'Next a
				'chrtmp = mid$(romdat, (((Y * &H10) + X) * 16) + offset + 1, 16)
				If ((Y * 16) + x) >= TilesHighlight Then
					RenderModule.DrawTile(tmp_bmi, (((Y * &H10S) + x) * 16) + offset, 0, (x * 8), (Y * 8), romdat)
				Else
					RenderModule.DrawTile(tmp_bmi, (((Y * &H10S) + x) * 16) + offset, 1, (x * 8), (Y * 8), romdat)
				End If
			Next x
		Next Y

justdrawblank:
		tmp_bmi.bytesRGB_UpdatedSinceLastRender = True
		RenderModule.RenderPicAlwaysIfItWasChangedSinceLastupdate(TileSrcPic, tmp_bmi)
		TileSrcPic.Refresh()
	End Sub

	Private Sub DrawDstCHRWindow()
		Dim offset As Integer
		Dim bpal, Y, d, b, a, c, x, block, stru As Integer
		Dim tmp_bmi As New BITMAPINFO()
		Dim hassprpal As Boolean

		tmp_bmi.Initialize()

		'tmp_bmi.pal(0) = NESPALD(Asc(mid$(romdat, offs(gem, 15) + (palset * 4), 1)))
		'tmp_bmi.pal(1) = NESPALD(Asc(mid$(romdat, offs(gem, 15) + (palset * 4) + 1, 1)))
		'tmp_bmi.pal(2) = NESPALD(Asc(mid$(romdat, offs(gem, 15) + (palset * 4) + 2, 1)))
		'tmp_bmi.pal(3) = NESPALD(Asc(mid$(romdat, offs(gem, 15) + (palset * 4) + 3, 1)))
		'tmp_bmi.pal(4) = RGBmirr(paltmpA(0))
		'tmp_bmi.pal(5) = RGBmirr(paltmpA(1))
		'tmp_bmi.pal(6) = RGBmirr(paltmpA(2))
		'tmp_bmi.pal(7) = RGBmirr(paltmpA(3))
		'tmp_bmi.pal(4) = NESPALL(Asc(mid$(romdat, offs(gem, 15) + (palset * 4), 1)))
		'tmp_bmi.pal(5) = NESPALL(Asc(mid$(romdat, offs(gem, 15) + (palset * 4) + 1, 1)))
		'tmp_bmi.pal(6) = NESPALL(Asc(mid$(romdat, offs(gem, 15) + (palset * 4) + 2, 1)))
		'tmp_bmi.pal(7) = NESPALL(Asc(mid$(romdat, offs(gem, 15) + (palset * 4) + 3, 1)))
		'tmp_bmi.pal(8) = NESPAL(

		If (PPUEffDataBot.GetByte(0) And &H80S) > 0 Then
			hassprpal = False
		Else
			hassprpal = True
		End If

		For a = 0 To &HFS
			'Fixed palsets from 1 and up (04-22-11)
			tmp_bmi.pal(&H10S + a) = NESPALL(romdat(arrayAdjuster + offs(gem, 15) + (palset * palsetWidth) + a))
			tmp_bmi.pal(a) = NESPALD(romdat(arrayAdjuster + offs(gem, 15) + (palset * palsetWidth) + a))
			If (a < 8) Then
				If (a And 3) = 0 Then
					tmp_bmi.pal(&H20S + a) = NESPALL(&H4S)
					tmp_bmi.pal(&H30S + a) = NESPALD(&H4S)
					tmp_bmi.pal(&H28S + a) = NESPALL(&H4S)
					tmp_bmi.pal(&H38S + a) = NESPALD(&H4S)
				Else
					tmp_bmi.pal(&H20S + a) = NESPALL(romdat(arrayAdjuster + offs(gem, o_mmpal) + a))
					tmp_bmi.pal(&H30S + a) = NESPALD(romdat(arrayAdjuster + offs(gem, o_mmpal) + a))
					If hassprpal = True Then
						tmp_bmi.pal(&H28S + a) = NESPALL(PPUEffDataBot.GetByte(a))
						tmp_bmi.pal(&H38S + a) = NESPALD(PPUEffDataBot.GetByte(a))
					Else
						tmp_bmi.pal(&H28S + a) = NESPALL(romdat(arrayAdjuster + offs(gem, o_mmpal) + a))
						tmp_bmi.pal(&H38S + a) = NESPALD(romdat(arrayAdjuster + offs(gem, o_mmpal) + a))
					End If
				End If
			End If
		Next a

		tmp_bmi.palette_UpdatedSinceLastBytesRGB_Update = True

		RenderModule.PB_Init(TileDstPic, tmp_bmi)

		a = 0 'PPUEff_lddatstart
		b = 0
		Do
			c = PPUEffDataBot.GetByte(LoadDataStart + a)
			If c >= &H80S Then GoTo drawdstchrdone

			If PPUEffDataBot.GetByte(LoadDataStart + a + 2) < &H80S Then GoTo skipdraw

			offset = PPUEffDataBot.GetByte(LoadDataStart + a)
			'If PPUEffDataBot.GetByte(LoadDataStart + (CurLoadPiece * 4) + 2) >= &HC0 Then offset = &H3C
			offset *= &H2000S
			offset = offset + ((PPUEffDataBot.GetByte(LoadDataStart + a + 2) - &H80S) * &H100S) + &H10S

			If ChunkSizeMode = 0 Then
				d = PPUEffDataBot.GetByte(LoadDataStart + a + 1)
			Else
				d = (PPUEffDataBot.GetByte(LoadDataStart + a + 1) * &H10S)
			End If

			For c = 0 To (d - 1)
				Y = PPUEffDataBot.GetByte(LoadDataStart + a + 3) + Int(c / &H10S)
				x = c And &HFS

				If Y >= &H10S Then GoTo noblockpal
				block = 0
tiletbldfl:
				If romdat(arrayAdjuster + (offs(gem, 3) + 0) + block) = ((Y * 16) + x) Then stru = 0 : GoTo tiletbldfsl
				If romdat(arrayAdjuster + (offs(gem, 3) + &H100S) + block) = ((Y * 16) + x) Then stru = 0 : GoTo tiletbldfsl
				If romdat(arrayAdjuster + (offs(gem, 3) + &H200S) + block) = ((Y * 16) + x) Then stru = 0 : GoTo tiletbldfsl
				If romdat(arrayAdjuster + (offs(gem, 3) + &H300S) + block) = ((Y * 16) + x) Then stru = 0 : GoTo tiletbldfsl
				block += 1
				If Not block = 255 Then GoTo tiletbldfl
				block = 0
				GoTo tiletbldff
tiletbldfsl:
				If romdat(arrayAdjuster + offs(gem, 5) + (stru * 4) + 0) = block Then GoTo tiletbldff
				If romdat(arrayAdjuster + offs(gem, 5) + (stru * 4) + 1) = block Then GoTo tiletbldff
				If romdat(arrayAdjuster + offs(gem, 5) + (stru * 4) + 2) = block Then GoTo tiletbldff
				If romdat(arrayAdjuster + offs(gem, 5) + (stru * 4) + 3) = block Then GoTo tiletbldff
				stru += 1
				If Not stru = 255 Then GoTo tiletbldfsl
				block += 1
				If Not block = 255 Then GoTo tiletbldfl
				block = 0

tiletbldff:
				'tilepal =
				bpal = (Nibble(romdat(arrayAdjuster + offs(gem, 4) + block), 1) And 3)

noblockpal:

				If Y >= &H20S Then GoTo skipdraw
				If Y >= &H10S Then
					If b = CurLoadPiece Then
						RenderModule.DrawTile(tmp_bmi, offset + (c * &H10S), &HAS, (x * 8), (Y * 8), romdat)
					Else
						RenderModule.DrawTile(tmp_bmi, offset + (c * &H10S), &HAS + 4, (x * 8), (Y * 8), romdat)
					End If
				Else
					If b = CurLoadPiece Then
						RenderModule.DrawTile(tmp_bmi, offset + (c * &H10S), bpal + 4, (x * 8), (Y * 8), romdat)
					Else
						RenderModule.DrawTile(tmp_bmi, offset + (c * &H10S), bpal, (x * 8), (Y * 8), romdat)
					End If
				End If
				'If b = CurLoadPiece Then
				'    MFX_Render.DrawTile TileDstPic, tmp_bmi, offset + (c * &H10), 1, (X * 8), (Y * 8), 1
				'Else
				'    MFX_Render.DrawTile TileDstPic, tmp_bmi, offset + (c * &H10), 0, (X * 8), (Y * 8), 1
				'End If
			Next c
skipdraw:

			a += 4
			b += 1
		Loop Until (b >= &HFFS)
drawdstchrdone:

		tmp_bmi.bytesRGB_UpdatedSinceLastRender = True
		RenderModule.RenderPicAlwaysIfItWasChangedSinceLastupdate(TileDstPic, tmp_bmi)
		TileSrcPic.Refresh()
	End Sub

	' Misc
	'================

	Private Sub PPUEff_GetFreeSpace()
		'Find highest pointer. Its used to measure free space.
		Dim c, a, b, d As Integer
		c = 0
		d = 0
		For a = 0 To PPUEffDataBot.TblEntries - 1
			PPUEffDataBot.CurEntry = a
			b = PPUEffDataBot.EntryMEMPtr
			If (b < PPUEffDataBot.DataEndMEMPtr) And (b > c) Then
				d = a
			End If
		Next a
		PPUEffDataBot.CurEntry = d
		If PPUEffMode < 2 Then
			PPUEffDataBot.FreeSpace = ((rdata(dspa(71) + 5) - 1) - PPUEffDataBot.EntryMEMPtr)
		Else
			PPUEffDataBot.FreeSpace = ((rdata(dspa(72) + 5) - 1) - PPUEffDataBot.EntryMEMPtr)
		End If
	End Sub

	' Interface Events
	'=================

	Private Sub CHRLoadNewButton_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles CHRLoadNewButton.Click
		Dim a As Integer
		a = PPUEffDataBot.InsertArr(LoadDataStart + (NumCHRLoads * 4), New Object() {0, 1, &H80S, 0})
		If a = 1 Then Exit Sub
		UpdCHRLoadList()
		UpdFreeSpaceLab()
		UpdLoadPiece()
		'NumCHRLoads = NumCHRLoads + 1 'gotcha!
	End Sub

	Private Sub CHRLoadRemBtn_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles CHRLoadRemBtn.Click
		Dim a As Integer
		If NumCHRLoads > 0 Then
			If PPUEffDataBot.GetByte(0) >= &H80S Then a = 1 Else a = 8
			PPUEffDataBot.RemoveBytes((a + (CurLoadPiece * 4)), 4)
			'CHRLoadList.RemoveItem CHRLoadList.ListIndex
			If CurLoadPiece = (CHRLoadList.Items.Count - 1) Then CurLoadPiece = 0
			NumCHRLoads -= 1
			UpdCHRLoadList()
			UpdFreeSpaceLab()
			UpdLoadPiece()
		End If
	End Sub

	'Load the graphics load data being edited to the current graphcs (chrmap),
	'then update all the windows. Incomplete. (Scroll Gfx Load support missing.)
	Private Sub LoadGfxBtn_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles LoadGfxBtn.Click
		Dim f, d, b, a, c, e, g As Integer
		Dim dest As Integer
		'Dim la As Long
		If PPUEffMode >= 2 Then Exit Sub

		a = 0
		Do
			b = PPUEffDataBot.GetByte(LoadDataStart + a)
			If b >= &H80S Then GoTo rend
			g = PPUEffDataBot.GetByte(LoadDataStart + a + 1)
			c = PPUEffDataBot.GetByte(LoadDataStart + a + 2)
			d = PPUEffDataBot.GetByte(LoadDataStart + a + 3)
			If (c >= &H80S) Then
				For e = 0 To (g - 1)
					For f = 0 To &HFS
						dest = ((d * &H10S) + (e * &H10S) + f)
						If (dest < &H2000S) Then
							chrmap(dest) = (b * &H2000S) + ((c - &H80S) * &H100S) + (e * &H100S) + (f * &H10S) + &H10S
						End If
					Next f
				Next e
			End If
			a += 4
		Loop Until a > 1000
rend:
		MFLE_Main.Update_TileRange(0, 255)
	End Sub

	Private Sub ColPic_MouseDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles _ColPic_7.MouseDown, _ColPic_6.MouseDown, _ColPic_5.MouseDown, _ColPic_3.MouseDown, _ColPic_2.MouseDown, _ColPic_1.MouseDown
		Dim Button As Short = eventArgs.Button \ &H100000
		Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
		Dim Index As Short = 0

		For Each pictureBox As PictureBox In ColPic
			If pictureBox.Name = eventSender.Name Then
				Exit For
			End If
			Index += 1
		Next


		'Case 1 : PPUEffDataBot.SetByte(Index, VWidth(PPUEffDataBot.GetByte(Index) + 1, 0, &H3FS))
		'Case 2 : PPUEffDataBot.SetByte(Index, VWidth(PPUEffDataBot.GetByte(Index) - 1, 0, &H3FS))


		Select Case Button
			Case 1 : SetTBCoolNumWithValidation(ColTB(Index), Hex(PPUEffDataBot.GetByte(Index) + 1), &H3FS, 2, True)
			Case 2 : SetTBCoolNumWithValidation(ColTB(Index), Hex(PPUEffDataBot.GetByte(Index) - 1), &H3FS, 2, True)
		End Select
		PPUEffDataBot.SetByte(Index, Dec(ColTB(Index).Text))
		ColPic(Index).BackColor = System.Drawing.ColorTranslator.FromOle(RGBmirr(NESPAL(PPUEffDataBot.GetByte(Index))))
	End Sub

	Private Sub GfxLoadEd_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
		Dim KeyCode As Short = eventArgs.KeyCode
		Dim Shift As Short = eventArgs.KeyData \ &H10000
		MFLE_Main.Global_KeyDown(KeyCode, Shift)
	End Sub

	Private Sub CHRLoadList_SelectedIndexChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles CHRLoadList.SelectedIndexChanged
		If CHRLoadList.Tag <> "" Then Exit Sub
		CurLoadPiece = CHRLoadList.SelectedIndex
		UpdLoadPiece()
	End Sub

	Private Sub HasSprPalCheck_CheckStateChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles HasSprPalCheck.CheckStateChanged
		Dim a As Integer
		If HasSprPalCheck.Tag <> "" Then Exit Sub
		If PPUEffDataBot.GetByte(0) >= &H80S Then
			a = PPUEffDataBot.InsertArr(1, New Object() {&HFS, &H20S, &H10S, &HFS, &HFS, &H36S, &H16S})
			If a = 0 Then
				PPUEffDataBot.SetByte(0, &HFS)
				LoadDataStart = 8
			End If
		Else
			PPUEffDataBot.RemoveBytes(1, 7)
			PPUEffDataBot.SetByte(0, &HFFS)
			LoadDataStart = 1
		End If
		UpdSprPal()
		UpdFreeSpaceLab()
	End Sub

	Private Sub PPUEffModeOpt_CheckedChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles _PPUEffModeOpt_1.CheckedChanged, _PPUEffModeOpt_0.CheckedChanged, _PPUEffModeOpt_3.CheckedChanged, _PPUEffModeOpt_2.CheckedChanged
		If eventSender.Checked Then
			Dim Index As Short = 0

			For Each radioButton As RadioButton In PPUEffModeOpt
				If radioButton.Name = eventSender.Name Then
					Exit For
				End If
				Index += 1
			Next

			If PPUEffModeOpt(Index).Tag <> "" Then Exit Sub
			PPUEffMode = Index
			UpdPPUEffMode()
			UpdPPUEff()
		End If
	End Sub
	Private Sub ColTB_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles _ColTB_7.TextChanged, _ColTB_6.TextChanged, _ColTB_5.TextChanged, _ColTB_3.TextChanged, _ColTB_2.TextChanged, _ColTB_1.TextChanged
		Dim Index As Short = 0

		For Each textBox As TextBox In ColTB
			If textBox.Name = eventSender.Name Then
				Exit For
			End If
			Index += 1
		Next

		If ColTB(Index).Tag <> "" Then Exit Sub
		SetTBCoolNumWithValidation(ColTB(Index), ColTB(Index).Text, &H3FS, 2, True)
		PPUEffDataBot.SetByte(Index, Dec(ColTB(Index).Text) And &H3FS)
		'mid$(romdat, ppueff_rom + index, 1) = chr$(dec(ColTB(index).text) And &H3F)
		ColPic(Index).BackColor = System.Drawing.ColorTranslator.FromOle(RGBmirr(NESPAL(PPUEffDataBot.GetByte(Index))))
	End Sub

	' NumericUpDown
	'================

	Private Sub CopyTilesUD_ActionUponNewValue()
		If CopyTilesUD.Tag <> "" Then Exit Sub

		If CopyTilesUD_ValuePrevious = CopyTilesUD.Value Then Exit Sub

		CopyTilesUD_ValuePrevious = CopyTilesUD.Value

		PPUEffDataBot.SetByte(LoadDataStart + (CurLoadPiece * 4) + 1, Dec((CopyTilesUD.Text)) And &HFFS)
		UpdCHRLoadList()
		UpdLoadPiece()
	End Sub

	Private Sub CopyTilesUD_ValueChanged(sender As Object, e As EventArgs) Handles CopyTilesUD.ValueChanged
		If UpdateUDCool(sender) Then
			' When here, Value was validated
			CopyTilesUD_ActionUponNewValue()
		End If
	End Sub

	Private Sub CopyTilesUD_KeyUp(sender As Object, e As KeyEventArgs) Handles CopyTilesUD.KeyUp
		' Set new value (with validations)
		SetUDCool(CType(sender, NumericUpDown), sender.Text, 2)

		' When here, Value was validated
		CopyTilesUD_ActionUponNewValue()
	End Sub

	Private Sub DstVRAMUD_ActionUponNewValue()
		If DstVRAMUD.Tag <> "" Then Exit Sub
		If DstVRAMUD_ValuePrevious = DstVRAMUD.Value Then Exit Sub

		DstVRAMUD_ValuePrevious = DstVRAMUD.Value

		PPUEffDataBot.SetByte(LoadDataStart + (CurLoadPiece * 4) + 3, Dec((DstVRAMUD.Text)) And &HFFS)
		UpdCHRLoadList()
		UpdLoadPiece()
	End Sub

	Private Sub DstVRAMUD_ValueChanged(sender As Object, e As EventArgs) Handles DstVRAMUD.ValueChanged
		If UpdateUDCool(sender) Then
			' When here, Value was validated
			DstVRAMUD_ActionUponNewValue()
		End If
	End Sub

	Private Sub DstVRAMUD_KeyUp(sender As Object, e As KeyEventArgs) Handles DstVRAMUD.KeyUp
		' Set new value (with validations)
		SetUDCool(CType(sender, NumericUpDown), sender.Text, 2)

		' When here, Value was validated
		DstVRAMUD_ActionUponNewValue()
	End Sub

	Private Sub EffIDUD_ActionUponNewValue()
		If EffIDUD.Tag <> "" Then Exit Sub
		If EffIDUD_ValuePrevious = EffIDUD.Value Then Exit Sub

		EffIDUD_ValuePrevious = EffIDUD.Value

		curppueff = Dec((EffIDUD.Text))
		SetUDCool(EffIDUD, Hex(curppueff), 2)
		UpdPPUEff()
	End Sub

	Private Sub EffIDUD_ValueChanged(sender As Object, e As EventArgs) Handles EffIDUD.ValueChanged
		If UpdateUDCool(sender) Then
			' When here, Value was validated
			EffIDUD_ActionUponNewValue()
		End If
	End Sub

	Private Sub EffIDUD_KeyUp(sender As Object, e As KeyEventArgs) Handles EffIDUD.KeyUp
		' Set new value (with validations)
		SetUDCool(CType(sender, NumericUpDown), sender.Text, 2)

		' When here, Value was validated
		EffIDUD_ActionUponNewValue()
	End Sub

	Private Sub LSDIDUD_ActionUponNewValue()
		If LSDIDUD.Tag <> "" Then Exit Sub
		If LSDIDUD_ValuePrevious = LSDIDUD.Value Then Exit Sub

		LSDIDUD_ValuePrevious = LSDIDUD.Value

		curlsdid = Dec((LSDIDUD.Text))
		SetUDCool(LSDIDUD, Hex(curlsdid), 2)
		UpdPPUEff()
	End Sub

	Private Sub LSDIDUD_ValueChanged(sender As Object, e As EventArgs) Handles LSDIDUD.ValueChanged
		If UpdateUDCool(sender) Then
			' When here, Value was validated
			LSDIDUD_ActionUponNewValue()
		End If
	End Sub

	Private Sub LSDIDUD_KeyUp(sender As Object, e As KeyEventArgs) Handles LSDIDUD.KeyUp
		' Set new value (with validations)
		SetUDCool(CType(sender, NumericUpDown), sender.Text, 2)

		' When here, Value was validated
		LSDIDUD_ActionUponNewValue()
	End Sub

	Private Sub SrcBankUD_ActionUponNewValue()
		If SrcBankUD.Tag <> "" Then Exit Sub
		If SrcBankUD_ValuePrevious = SrcBankUD.Value Then Exit Sub

		SrcBankUD_ValuePrevious = SrcBankUD.Value

		PPUEffDataBot.SetByte(LoadDataStart + (CurLoadPiece * 4) + 0, Dec((SrcBankUD.Text)) And &HFFS)
		UpdCHRLoadList()
		UpdLoadPiece()
	End Sub

	Private Sub SrcBankUD_ValueChanged(sender As Object, e As EventArgs) Handles SrcBankUD.ValueChanged
		If UpdateUDCool(sender) Then
			' When here, Value was validated
			SrcBankUD_ActionUponNewValue()
		End If
	End Sub

	Private Sub SrcBankUD_KeyUp(sender As Object, e As KeyEventArgs) Handles SrcBankUD.KeyUp
		' Set new value (with validations)
		SetUDCool(CType(sender, NumericUpDown), sender.Text, 2)

		' When here, Value was validated
		SrcBankUD_ActionUponNewValue()
	End Sub
	Private Sub SrcHiUD_ActionUponNewValue()
		If SrcHiUD_ValuePrevious = SrcHiUD.Value Then Exit Sub

		SrcHiUD_ValuePrevious = SrcHiUD.Value

		If SrcHiUD.Tag <> "" Then Exit Sub
		PPUEffDataBot.SetByte(LoadDataStart + (CurLoadPiece * 4) + 2, Dec((SrcHiUD.Text)) And &HFFS)
		UpdCHRLoadList()
		UpdLoadPiece()
	End Sub

	Private Sub SrcHiUD_ValueChanged(sender As Object, e As EventArgs) Handles SrcHiUD.ValueChanged
		If UpdateUDCool(sender) Then
			' When here, Value was validated
			SrcHiUD_ActionUponNewValue()
		End If
	End Sub

	Private Sub SrcHiUD_KeyUp(sender As Object, e As KeyEventArgs) Handles SrcHiUD.KeyUp
		' Set new value (with validations)
		SetUDCool(CType(sender, NumericUpDown), sender.Text, 2)

		' When here, Value was validated
		SrcHiUD_ActionUponNewValue()
	End Sub

	Private Sub CHRLoadUP_Click(sender As Object, e As EventArgs) Handles CHRLoadUP.Click
		Dim tarr1 As Object
		Dim tarr2 As Object
		If CurLoadPiece = 0 Then Exit Sub
		tarr1 = PPUEffDataBot.GetArr(LoadDataStart + ((CurLoadPiece - 1) * 4), 4)
		tarr2 = PPUEffDataBot.GetArr(LoadDataStart + (CurLoadPiece * 4), 4)
		PPUEffDataBot.WriteArr(LoadDataStart + ((CurLoadPiece - 1) * 4), tarr2)
		PPUEffDataBot.WriteArr(LoadDataStart + (CurLoadPiece * 4), tarr1)
		CurLoadPiece -= 1
		UpdCHRLoadList()
		UpdLoadPiece()
	End Sub

	Private Sub CHRLoadDOWN_Click(sender As Object, e As EventArgs) Handles CHRLoadDOWN.Click
		Dim tarr1 As Object
		Dim tarr2 As Object
		If NumCHRLoads = 0 Then Exit Sub 'fix 06-20-09
		If CurLoadPiece = (NumCHRLoads - 1) Then Exit Sub
		tarr1 = PPUEffDataBot.GetArr(LoadDataStart + (CurLoadPiece * 4), 4)
		tarr2 = PPUEffDataBot.GetArr(LoadDataStart + ((CurLoadPiece + 1) * 4), 4)
		PPUEffDataBot.WriteArr(LoadDataStart + (CurLoadPiece * 4), tarr2)
		PPUEffDataBot.WriteArr(LoadDataStart + ((CurLoadPiece + 1) * 4), tarr1)
		CurLoadPiece += 1
		UpdCHRLoadList()
		UpdLoadPiece()
	End Sub

#Region "Unused"
	'Private Sub DrawCHRWindow_(offset As Long, TilesHighlight As Integer)
	'Dim x, y

	'For y = 0 To 15
	'For x = 0 To 15
	''For a = 0 To 15
	' '   chrtmp(a) = Asc(mid$(romdat, chrmap((y * 16) + x) + a + 1, 1))
	''Next a
	'chrtmp = romdat(arrayAdjuster + ((y * &H10) + x) * 16) + offset + 1, 16)
	'If ((y * 16) + x) >= TilesHighlight Then
	'    'Common.NEStiledraw Picture1, (Y * 8), (X * 8), 1, 1, 0, 0, 1, chrtmp, paltmpB
	'Else
	'Common.NEStiledraw Picture1, (Y * 8), (X * 8), 1, 1, 0, 0, 1, chrtmp, paltmpA
	'End If
	'Next x
	'Next y

	'End Sub

	Private Sub Command1_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Command1.Click
		Dim f, d, b, a, c, e, g As Integer
		Dim la As Integer
		Dim tchrmap(&H200S) As Integer
		Dim PathBackup As String

		PathBackup = CurDir()
		For a = 0 To &H1FFS
			tchrmap(a) = &H20010
		Next a
		a = 0
loopedyloop:
		b = PPUEffDataBot.GetByte(LoadDataStart + a)
		If b >= &H80S Then GoTo dumpit
		g = PPUEffDataBot.GetByte(LoadDataStart + a + 1)
		c = PPUEffDataBot.GetByte(LoadDataStart + a + 2)
		d = PPUEffDataBot.GetByte(LoadDataStart + a + 3)
		For e = 0 To (g - 1)
			For f = 0 To &HFS
				tchrmap((d * &H10S) + (e * &H10S) + f) = (b * &H2000S) + ((c - &H80S) * &H100S) + (e * &H100S) + (f * &H10S) + &H10S
			Next f
		Next e
		a += 4
		GoTo loopedyloop
dumpit:
		FileOpen(1, "dumpcm.map", OpenMode.Binary)
		For a = 0 To &H1FFS
			la = tchrmap(a)
			FilePut(1, la)
		Next a
		FileClose(1)

		ChDir(PathBackup)
	End Sub

	Private Sub BtnDumpSpriteChar_Click(sender As Object, e As EventArgs) Handles BtnDumpSpriteChar.Click
		Dim a, aMax As Integer
		Dim FileName As String
		Dim NiceDialog As New clsDialog
		Dim PathBackup As String
		Dim Title As String = "Choose a file to write object data to."
		Dim InitDir As String = ""
		Dim DefExt As String = ""
		Dim Filter As String = ".CHR files|*.chr|All files|*.*"
		Dim flags As clsDialog.DialogFlags = clsDialog.DialogFlags.CHECKPATHEXISTS

		PathBackup = CurDir()
		FileName = NiceDialog.ShowSave(Me, Title, flags, InitDir, DefExt, Filter)

		'aMax = PatternMap.Length - 1

		If (FileName <> "") Then
			Try
				FileOpen(1, FileName, OpenMode.Binary)

				Try
					For a = 0 To aMax
						'FilePut(1, romdat(PatternMap(a)))
					Next a
				Catch ex As Exception
					MessageBox.Show("Parameters are invalid.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
				End Try

				FileClose(1)
			Catch ex As Exception
				MessageBox.Show("Parameters are invalid - couldn't open file.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
			End Try
		End If


		ChDir(PathBackup)
	End Sub

	Private Sub ResetBtn_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles ResetBtn.Click
		Dim b, a, c As Integer
		a = PPUEffDataBot.CurEntry
		If a > 0 Then
			PPUEffDataBot.CurEntry = a - 1
			b = PPUEffDataBot.GetByte(0)
			If ((b And &H80S) = &H80S) Then c = 1 Else c = 8
			While (((PPUEffDataBot.GetByte(c) And &H80S) = 0) And (c < &H100S))
				c += 4
			End While
			b = PPUEffDataBot.EntryMEMPtr
			PPUEffDataBot.CurEntry = a
			PPUEffDataBot.SetEntryMEMPtr((b + c + 1))
		End If
		'PPUEffDataBot.FreeSpace = ((rdata(dspa(71) + 5) - 1) - PPUEffDataBot.EntryMEMPtr)
		PPUEffDataBot.InsertArr(0, New Object() {&HFFS, &HFFS})
		UpdPPUEff()
	End Sub
#End Region


End Class