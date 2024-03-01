Option Explicit On
Imports System.IO
Imports System.Reflection
Module CSA_Main
	Private ReadOnly Release As Boolean = True
	Public autoLoadASM_ModeOff As Boolean = True
	Public filename As String
	Public supfile As String = ""
	Public romdat() As Byte
	Public romsize As Integer
	Public NESPAL(&HFFS) As Integer
	Public NESPALL(&HFFS) As Integer
	Public NESPALD(&HFFS) As Integer
	Public BankReg() As Integer
	Public BankReg_last As Integer
	Public CoordBankReg(1) As Integer
	Public BankPtr(2) As Integer
	Public BaseSprLo As Integer
	Public BaseSprHi As Integer
	Public BaseFrameLo As Integer
	Public BaseFrameHi As Integer
	Public BaseCoordLo As Integer
	Public BaseCoordHi As Integer
	Public DataBank As Integer
	Public SprPtrBank As Integer
	Public FramePtrBank As Integer
	Public CoordPtrBank As Integer
	Public SprAddrLowBound As Integer
	Public SprAddrHighBound As Integer
	Public FrameAddrLowBound As Integer
	Public FrameAddrHighBound As Integer
	Public CoordAddrLowBound As Integer
	Public CoordAddrHighBound As Integer
	Public MaxSprite As Integer
	Public DataMovable As Integer
	Public Structure DataSegsType
		Dim Start As Integer
		Dim EndValue As Integer
		Dim Free As Integer
	End Structure
	Public DataSegLast As Integer
	Public DataSegs() As DataSegsType
	Public Structure PtrSegsType
		Dim loptr As Integer
		Dim hiptr As Integer
		Dim entries As Integer
	End Structure
	Public PtrSegLast As Integer
	Public PtrSegs() As PtrSegsType
	Public CoordPointerAdd As Integer
	Public FramePointerAdd As Integer
	Public FrameTileNumofBase As Integer
	Public FramePageMethod As Integer
	Public CoordinateBankSelect As Integer
	Public CoordPairs As Integer
	Public DataParseSensitive As Integer

	'CoordPointerAdd : Correction to Coordinate data pointer. Used for MM2.
	'FramePointerAdd : Correction to Frame data pointer. Used for MM5.
	'FrameTileNumofBase : Base of value in frame data which tells number of tiles
	'   the frame contains. (0 for 0-based or 1 for 1-based).
	'   1-based: MM2
	'   0-based: All others.
	'FramePageMethod : Method of determining Frame Page.
	'   0 : Determined by MSB bit 0 of Sprite Data. (All except Megaman 2)
	'   1 : Determinde by Sprite ID. (Megaman 2)
	'       Sprite ID = 00-7F : Frame Page = 0 (00-FF)
	'       Sprite ID = 80-FF : Frame Page = 1 (100-1FF)
	'CoordinateBankSelect : Specifies if the 2nd switchable bank of the MMC3 mapper
	'   is changeable for use for coordinate data. The bank used is decided by the
	'   1st byte of Frame data, MSB bit 0.
	'CoordPairs : Option for if game utilizes pairs of coordinate data for left
	'   and right facing directions. Some games uses pairs of data, other games
	'   handle the X coordinate invertion on the fly.
	'   0: MM2, MM5, ??
	'   1: MM4, Darkwing Duck
	'DataParseSensitive : Just a work-around option for Darkwing Duck for free space
	'   to be calculated correcly. When 1, it stops reading Sprite ID's when one of
	'   its containing Frame ID's has a bad pointer. Darkwing Duck has this in the
	'   middle of the Sprite ID's. When 0, it will stop reading Sprite ID's when the
	'   Sprite pointer itself is bad only.
	'   0: Darkwing Duck
	'   1: All others.
	'   (Default value is 1)

	Public ResetAll_Enabled As Boolean
	Public ResetAreas As Integer
	Public ResetArea_Start() As Integer
	Public ResetArea_Size() As Integer
	Public BankPtrSelect As Integer
	'Public BankPtr As Long
	Public Sprite As Byte
	Public FramePage As Integer
	Public Frame As Integer
	Public FrameID As Integer
	Public CoordID As Integer
	Public CoordID2 As Integer
	Public AnimationFrames As Integer
	Public AnimationDelay As Integer
	Public FrameLastTile As Integer
	Public SelTile As Integer
	Public HoverTile As Integer
	Public AnimateFC As Integer
	Public SprAddr As ClsNESAddr
	Public FrameAddr As ClsNESAddr
	Public CoordAddr As ClsNESAddr
	Public Coord2Addr As ClsNESAddr
	Public TmpAddr As ClsNESAddr
	Public gPtrDataMove As ClsPtrDataMove
	Public FrameCoordClipboardSz As Integer
	Public FrameClipBoard() As Byte
	Public CoordClipBoard() As Byte
	Public SpriteFrameUsage(&HFFS, &H1FFS) As Boolean
	Public FrameCoordUsage(&H1FFS, &HFFS) As Boolean
	Public FrameCoordPairUsage(&H1FFS, &HFFS) As Boolean
	Public CoordTileCount(&HFFS) As Short
	Public UsageMap(&H7FFFS) As Byte
	Public MoveAllTiles As Byte
	Public TileZPrio As Integer
	Public ViewZoom As Integer
	Public ViewX As Integer
	Public ViewY As Integer
	Public ViewMinX As Integer
	Public ViewMinY As Integer
	Public ViewMaxX As Integer
	Public ViewMaxY As Integer
	Public Animate As Byte
	Public AnimSpeed As Byte
	Public AnimRepeatA As Byte
	Public CursorType As Integer
	Public ShowCursors As Byte
	Public ShowGrid As Byte
	Public DisableCoordInsDel As Byte
	Public SprPal(&HFS) As Byte
	Public SprPalInitial(&HFS) As Byte
	Public CHR_FilePatternMap(&HFFFS) As Byte ' Contains every byte of the CHR file loaded
	Public PatternMap(&HFFFS) As Integer ' Contains every ROM address of each byte in the loaded CHR map
	' For example, if we load 40010, then we have in decimal value the following hex values: 40010, 40011, etc.

	'Public Background_RGB As Long
	Public BGCol_R As Integer
	Public BGCol_G As Integer
	Public BGCol_B As Integer
	Public PatClipboard(&HFS) As Byte
	Public grid_bm As Bmbuffer
	Public spr_bm As Bmbuffer
	Public main_bmi As BITMAPINFO
	Public tile_bmi As BITMAPINFO
	Public tt_bmi As BITMAPINFO
	Public pal_bmi As BITMAPINFO
	Public ANDtbl(7) As Integer
	Public InvANDtbl(7) As Integer

	Private Sub MainCode()
		Dim Title As String = "Select ROM"
		Dim InitDir As String = ""
		Dim DefExt As String = ""
		Dim Filter As String = "nes roms (*.nes)|*.nes|all files (*.*)|*.*"
		Dim flags As ClsDialog.DialogFlags = ClsDialog.DialogFlags.CHECKFILEEXISTS Or ClsDialog.DialogFlags.CHECKPATHEXISTS Or ClsDialog.DialogFlags.PROHIBEREADONLY
		Dim autoloadRom As String
		Dim autoloadRomValues() As String
		Common.Init(True)
		LoadCfg("csa.cfg")
		Form1.Manual_Init()
		ANDtbl(0) = &H80S
		ANDtbl(1) = &H40S
		ANDtbl(2) = &H20S
		ANDtbl(3) = &H10S
		ANDtbl(4) = &H8S
		ANDtbl(5) = &H4S
		ANDtbl(6) = &H2S
		ANDtbl(7) = &H1S
		InvANDtbl(0) = &H7FS
		InvANDtbl(1) = &HBFS
		InvANDtbl(2) = &HDFS
		InvANDtbl(3) = &HEFS
		InvANDtbl(4) = &HF7S
		InvANDtbl(5) = &HFBS
		InvANDtbl(6) = &HFDS
		InvANDtbl(7) = &HFES
		If GetCfg("warning") = 0 Then
			MessageBox.Show("Note: Please make sure to backup your work before making any changes to it with this editor. Its very easy to end up with corrupted sprite data. It can happen to sprites anywhere in the game (in the same bank) as a result of changing something else. I do not take respnosbility for any consequences the use of this program may have on your project. This is a one-time warning notification.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
			SetCfg("warning", 1)
		End If
		ReloadNESPAL()

		'ChDir App.Path

		'FileName = "megaman2.nes"
		'GoTo debug_init

		'	Auto ASM mode has priority
		autoLoadASM_ModeOff = (GetCfg("auto_loadASM_Mode", False).ToString().Contains("<") = False)

		If autoLoadASM_ModeOff Then
			autoloadRom = GetCfg("auto_loadrom")
			If (autoloadRom = "") Then
				Dim openwnd As New ClsDialog
				filename = openwnd.ShowOpen(Nothing, Title, flags, InitDir, DefExt, Filter)
				If Len(filename) = 0 Then End
				filename = Left(filename, Len(filename))
			Else
				autoloadRomValues = autoloadRom.Split("<"c)
				filename = autoloadRomValues(0)
				supfile = autoloadRomValues(1)
				If Not IO.File.Exists(filename) Or Not IO.File.Exists(supfile) Then
					Throw New Exception("One of file used for autoload is not accessible.")
				End If
			End If

			FileOpen(1, filename, OpenMode.Binary)
			romsize = (LOF(1) - 1)
			ReDim romdat(romsize)
			FileGet(1, romdat)
			FileClose(1)
			If (autoloadRom = "") Then
				Support.Refresh_GameList()
				Support.Activate()
				Support.ShowDialog()
			End If
			If supfile <> "" Then
				Init2(supfile)
			End If
		Else
			Init2CommonPart()
		End If

		' Only do AutoLoad Rom check here - because it's change of status will trigger a check change event,
		'	and we need to have filled filename before
		Form1.InitAutoLoadChk()
		Form1.StartPosition = FormStartPosition.CenterScreen
	End Sub
	Public Sub Main()
		If Release Then
			Try
				MainCode()
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
				Dim result As DialogResult = MessageBox.Show("Disable Autoloading modes?.", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
				If result = DialogResult.Yes Then
					SetCfg("auto_loadrom", "")
					Dim autoLoadASM_ModeConfig As String = GetCfg("auto_loadASM_Mode", False)
					If (autoLoadASM_ModeConfig <> "") Then
						SetCfg("auto_loadASM_Mode", Form1.ASM_ModeConfigFileNotAuto)
					End If
				End If
			End Try
		Else
			MainCode()
		End If
	End Sub
	Public Sub Init2CommonPart()
		MoveAllTiles = 0
		TileZPrio = 0
		AnimSpeed = 0
		Form1.Timer1.Interval = 16
		AnimRepeatA = 0
		Animate = 0
		ViewZoom = 4
		Form1.RecalcViewXY()
		ShowCursors = 1
		ShowGrid = 1
		CursorType = 0
		DisableCoordInsDel = 0

		FrameCoordClipboardSz = -1

		'Initialize RAW Buffers
		RenderModule.RAW_Init(grid_bm, (8 * 32), (8 * 32))
		RenderModule.RAW_Init(spr_bm, (8 * 32), (8 * 32))

		'Create grid BM
		For a = 0 To 31
			For b = 0 To 31
				RenderModule.RAW_LineH(grid_bm, (b * 8), (b * 8) + 7, (a * 8), &H41S)
				RenderModule.RAW_LineV(grid_bm, (b * 8), (a * 8), (a * 8) + 7, &H41S)
			Next b
		Next a
		RenderModule.RAW_LineV(grid_bm, 128, 0, 255, &H42S)
		RenderModule.RAW_LineH(grid_bm, 0, 255, 128, &H42S)
		BGCol_R = GetCfg("bgcolor_r")
		BGCol_G = GetCfg("bgcolor_g")
		BGCol_B = GetCfg("bgcolor_b")
		'Background_RGB = GetCfg("bgcolor_r") Or (GetCfg("bgcolor_g") * 256) Or (GetCfg("bgcolor_b") * 65536)
		'Background_RGB = RGB(&H60, &H0, &H60)   '60, 0, 60

		RenderModule.PB_Init_WithClientRectangle((Form1.WorkPic), main_bmi)
		RenderModule.PB_Init((Form1.PicBTile), tile_bmi)
		RenderModule.PB_Init((Form1.PicBPal), pal_bmi)
		RenderModule.PB_Init((Form1.PicBTileMap), tt_bmi)
		Init_Bitmap_Palettes_And_More()
		Form1.Refresh_All()
		Form1.Manual_Init_Later()
		Form1.Activate()
	End Sub
	Public Sub Init2(ByRef supFileName As String)
		supfile = supFileName

		'Mega Man 3 uses a bank arrangement where the sprite
		'banks is not straight 16k banks, and can't be supported
		'by the current system.
		'To be supported.

		'Mighty Final Fight uses a bankswitching scheme for sprites
		'which changes the 2nd switchable bank of the MMC3.
		'To be supported later.

		SupInp.Load(supfile)
		SprAddrLowBound = (&H8000 + (SprPtrBank * &H4000S))
		SprAddrHighBound = (&HC000 + (SprPtrBank * &H4000S)) - 1
		FrameAddrLowBound = (&H8000 + (FramePtrBank * &H4000S))
		FrameAddrHighBound = (&HC000 + (FramePtrBank * &H4000S)) - 1
		CoordAddrLowBound = (&H8000 + (CoordPtrBank * &H4000S))
		CoordAddrHighBound = (&HC000 + (CoordPtrBank * &H4000S)) - 1

		'a = &H8000& + (DataBank * &H4000) + BaseData
		'gPtrDataMove.DataStart = a
		'gPtrDataMove.DataEnd = a + BaseDataSz - 1
		gPtrDataMove = New ClsPtrDataMove With {
.RegardFreeSpace = True
}
		FeedSegmentInfo()
		Init_Address_Classes()

		Init2CommonPart()
	End Sub
	Public Sub FeedSegmentInfo()
		'Pass information about data segments and pointer tables to global PtrDataMove class.
		'Data segments : Areas of sprite data. Can be divided up through the bank, otherwise
		'   there is always just one segment. The start pointer and size for each segment
		'   is passed to the class.
		'Pointer tables : Sprite data uses 3 pointer tables. (Sprite, Frame, Coordinate).
		'   The size and offset information for each table is passed to the class.
		'At the moment, all the data is temporarily stored in arrays generated by SupInp,
		'then converted to a more basic format here and passed as arguments to the class
		'sub/method "SetSegments".
		Dim PtrSegArrTmp() As Integer = New Integer() {}
		Dim DataSegArrTmp() As Integer = New Integer() {}
		Dim a, b As Integer
		If DataSegLast >= 0 Then
			b = 0
			ReDim DataSegArrTmp((DataSegLast * 2) + 1)
			For a = 0 To DataSegLast
				DataSegArrTmp(b) = DataSegs(a).Start
				DataSegArrTmp(b + 1) = DataSegs(a).EndValue
				b += 2
			Next a
		End If
		If PtrSegLast >= 0 Then
			b = 0
			ReDim PtrSegArrTmp((PtrSegLast * 3) + 2)
			For a = 0 To PtrSegLast
				PtrSegArrTmp(b) = PtrSegs(a).loptr
				PtrSegArrTmp(b + 1) = PtrSegs(a).hiptr
				PtrSegArrTmp(b + 2) = PtrSegs(a).entries
				b += 3
			Next a
		End If
		If (DataSegLast >= 0) And (PtrSegLast >= 0) Then
			gPtrDataMove.SetSegments(DataSegArrTmp, PtrSegArrTmp)
		End If
	End Sub
	Public Function Init_Address_Classes() As Integer
		Dim tmpaddrref As ClsNESAddr
		SprAddr = New ClsNESAddr
		FrameAddr = New ClsNESAddr
		CoordAddr = New ClsNESAddr
		Coord2Addr = New ClsNESAddr
		TmpAddr = New ClsNESAddr
		Update_Address_Classes()
		SprAddr.InitSegsCDEF(BankPtr(2)) 'For games that use hard-wired bank.
		FrameAddr.InitSegsCDEF(BankPtr(2)) 'For games that use hard-wired bank.
		CoordAddr.InitSegsCDEF(BankPtr(2)) 'For games that use hard-wired bank.
		Coord2Addr.InitSegsCDEF(BankPtr(2)) 'For games that use hard-wired bank.
		TmpAddr.InitSegsCDEF(BankPtr(2)) 'For games that use hard-wired bank.

		tmpaddrref = gPtrDataMove.GetNESAddrRef
		tmpaddrref.InitSegsCDEF(BankPtr(2))
		tmpaddrref = gPtrDataMove.GetNESAddr2Ref
		tmpaddrref.InitSegsCDEF(BankPtr(2))
	End Function

	'BankPtr(0) changed.
	Public Function Update_Address_Classes() As Integer
		Dim tmpaddrref As ClsNESAddr
		Select Case CoordinateBankSelect
			Case 0
				SprAddr.InitSegs89AB(BankPtr(0))
				FrameAddr.InitSegs89AB(BankPtr(0))
				CoordAddr.InitSegs89AB(BankPtr(0))
				Coord2Addr.InitSegs89AB(BankPtr(0))
				TmpAddr.InitSegs89AB(BankPtr(0))

				tmpaddrref = gPtrDataMove.GetNESAddrRef
				tmpaddrref.InitSegs89AB(BankPtr(0))
				tmpaddrref = gPtrDataMove.GetNESAddr2Ref
				tmpaddrref.InitSegs89AB(BankPtr(0))
			Case 1
				SprAddr.InitSegs89(BankPtr(0))
				FrameAddr.InitSegs89(BankPtr(0))
				CoordAddr.InitSegs89(BankPtr(0))
				Coord2Addr.InitSegs89(BankPtr(0))
				TmpAddr.InitSegs89(BankPtr(0))
				tmpaddrref = gPtrDataMove.GetNESAddrRef
				tmpaddrref.InitSegs89(BankPtr(0))
				tmpaddrref = gPtrDataMove.GetNESAddr2Ref
				tmpaddrref.InitSegs89(BankPtr(0))
		End Select
	End Function

	Public Function Update_Address_Classes_CoordBank(ByRef bankselect As Integer) As Integer
		Dim a As Integer
		Dim tmpaddrref As ClsNESAddr
		a = CoordBankReg(bankselect)
		SprAddr.InitSegsAB(a)
		FrameAddr.InitSegsAB(a)
		CoordAddr.InitSegsAB(a)
		Coord2Addr.InitSegsAB(a)
		TmpAddr.InitSegsAB(a)

		tmpaddrref = gPtrDataMove.GetNESAddrRef
		tmpaddrref.InitSegsAB(a)
		tmpaddrref = gPtrDataMove.GetNESAddr2Ref
		tmpaddrref.InitSegsAB(a)
	End Function

	Public Sub InitTmpNESAddr(ByRef nesaddrclass As ClsNESAddr)
		nesaddrclass = New ClsNESAddr
		nesaddrclass.InitSegs89AB(BankPtr(0))
		nesaddrclass.InitSegsCDEF(BankPtr(2))
	End Sub
	Public Sub Init_One_Bitmap_Background_Palettes(bmix As BITMAPINFO, RGBcolor As Integer)
		bmix.pal(0) = RGBcolor
		bmix.pal(4) = RGBcolor
		bmix.pal(8) = RGBcolor
		bmix.pal(12) = RGBcolor
	End Sub
	Private Sub Init_One_Bitmap_Palettes(bmix As BITMAPINFO)
		Init_One_Bitmap_Background_Palettes(bmix, RGBmirr(RGB(BGCol_R, BGCol_G, BGCol_B)))
		bmix.pal(&H40S) = RGB(0, 0, 0)
		bmix.pal(&H41S) = RGB(&H68S, &H68S, &H68S)
		bmix.pal(&H42S) = RGB(&HC0S, &HC0S, &HC0S)
		bmix.pal(&H43S) = RGB(&H0S, &HFFS, &H0S)
		bmix.pal(&H44S) = RGB(&HFFS, &H0S, &HFFS)
		bmix.pal(&H45S) = RGB(&HFFS, &HFFS, &HFFS)
	End Sub

	'Set standard colors + standard sprite palette
	'Onto all BITMAPINFO structs.
	'Note: All BITMAPINFO structs are initialized on startup.
	Public Function Init_Bitmap_Palettes_And_More() As Integer
		main_bmi.Initialize()
		tile_bmi.Initialize()
		pal_bmi.Initialize()
		tt_bmi.Initialize()
		Reload_Bitmap_Palettes()
		Init_One_Bitmap_Palettes(main_bmi)
		Init_One_Bitmap_Palettes(tile_bmi)
		Init_One_Bitmap_Palettes(pal_bmi)
		Init_One_Bitmap_Palettes(tt_bmi)
	End Function
	Private Sub Reload_Bitmap_Palettes_For_One_BITMAPINFO(bmip As BITMAPINFO)
		Dim a As Integer
		For a = 1 To &HFS
			If a <> 4 And a <> 8 And a <> 12 Then
				bmip.pal(a) = NESPAL(SprPal(a))
				bmip.pal(a + &H80S) = NESPALL(SprPal(a))
				bmip.pal(a + &HC0S) = NESPALD(SprPal(a))
			End If
		Next a
	End Sub
	Public Function Reload_Bitmap_Palettes() As Integer
		Reload_Bitmap_Palettes_For_One_BITMAPINFO(main_bmi)
		Reload_Bitmap_Palettes_For_One_BITMAPINFO(tile_bmi)
		Reload_Bitmap_Palettes_For_One_BITMAPINFO(pal_bmi)
		Reload_Bitmap_Palettes_For_One_BITMAPINFO(tt_bmi)
	End Function
	Public Sub Wr(ByRef addr As Integer, ByRef v As Byte)
		If (addr <= UBound(romdat)) Then
			romdat(addr) = v
			'    If Form1.Visible Then
			'        Form1.WriteList.AddItem (Hex(addr) + " = " + Hex(v))
			'        Form1.WriteList.ListIndex = (Form1.WriteList.ListCount - 1)
			'    End If
		End If
	End Sub
	Public Sub ReloadNESPAL()
		Dim PathBackup As String
		Dim palfile As String
		Dim hg, a, hr, hb As Integer
		Dim br As Byte
		Dim bg As Byte
		Dim bb As Byte

		PathBackup = CurDir()
		ChDir(My.Application.Info.DirectoryPath)
		palfile = GetCfg("palfile")
		FileOpen(1, palfile, OpenMode.Binary)
		For a = 0 To &H3FS
			FileGet(1, br)
			FileGet(1, bg)
			FileGet(1, bb)
			NESPAL(a) = RGB(bb, bg, br)
			NESPALD(a) = RGB(Int(bb / 1.5), Int(bg / 1.5), Int(br / 1.5))
			hr = VWidth(br + 80, 0, 255)
			hg = VWidth(bg + 80, 0, 255)
			hb = VWidth(bb + 80, 0, 255)
			NESPALL(a) = RGB(hb, hg, hr)
		Next a
		FileClose(1)
		ChDir(PathBackup)
	End Sub
	Public Function Get_BankReg_Index(ByRef bank As Integer) As Integer
		Dim a As Integer
		For a = 0 To BankReg_last
			If bank = BankReg(a) Then
				Get_BankReg_Index = a
				Exit Function
			End If
		Next a
		Get_BankReg_Index = -1
	End Function
End Module