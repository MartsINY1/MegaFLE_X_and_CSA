Option Explicit On
Module MFLE_Decl
	Enum Palchart_Claim
		PalEd = 0
		EnemEd = 1
	End Enum

	Structure SceneModeInfo_Type
		Dim gfxLoadId_Ptr As Integer
		Dim canChangeId As Boolean
		Dim other_Ptr1 As Integer
		Dim other_Ptr2 As Integer
	End Structure
	Public SceneModeInfo As SceneModeInfo_Type

	Public Const offsnum As Short = 69

	Public ShuttingDown As Boolean
	Public PALAnimEnable As Byte
	Public CHRAnimEnable As Byte

	Public RefreshPalLock As Boolean ' Global disable bitmap palette copy and some refreshes when set.
	Public PalChartToFront As Boolean ' Used to prevent some bringing of palette chart to front (with form events,
	' could cause conflicts and problems)
	Public glob_pal_updated As Boolean = False
	Public MegaManEngineMode As Boolean = False

	Public SecondsUsed As Integer

	Public FileName As String
	Public romdat() As Byte

	'Since VB6 array index start at 1, need an adjuster for every reading/write
	Public arrayAdjuster As Integer = -1
	Public checkfilechange_flag As Integer
	Public EditFile_SaveDateStr As String

	Public chrmap(&H1FFS) As Integer
	Public offs(3, offsnum) As Integer
	Public ANDtbl(7) As Integer

	Public NESPAL(&HFFS) As Integer
	Public NESPALD(&HFFS) As Integer
	Public NESPALL(&HFFS) As Integer
	Public glob_pal(255) As Integer
	Public PPU_palette_val(&H1FS) As Integer 'Current NES Palette color values

	Public ScrollInfoChangeFlag As Boolean

	Public ignore_scrlayout As Boolean
	Public scenemode As Boolean

	Public level As Integer
	Public storelevel As Integer
	Public leveloff As Single
	Public sbdoff As Single
	Public gem As Integer = -1
	Public dummy As String
	Public oldscr As Integer

	Public curscreen As Integer
	Public curscroll As Integer
	Public oldscroll As Integer
	Public curstrY As Integer
	Public curstrX As Integer
	Public oldstrY As Integer
	Public oldstrX As Integer
	Public blockpage As Integer
	Public curblockY As Integer
	Public curblockX As Integer
	Public oldblockY As Integer
	Public oldblockX As Integer
	Public curtileY As Integer
	Public curtileX As Integer
	Public oldtileY As Integer
	Public oldtileX As Integer
	Public curenem As Integer
	Public curscroll_sscrn As Integer
	Public nextscroll_sscrn As Integer
	Public palset As Integer
	Public palsetWidth As Integer '= 0x14 usually. 0x10 in Scene Screen Mode.
	Public palsetChangeType As Integer
	Public curpalanim As Integer
	Public chranimoff As Integer
	Public curpalanimframe As Integer
	Public sbdscreen As Integer
	Public curlsdid As Integer
	Public curppueff As Integer

	Public tsatbl_blockwidthY As Integer
	Public tsatbl_blockwidthX As Integer

	Public sprpaloff(7) As Integer

	Public PA_ID(3) As Byte
	Public PA_DelayC(3) As Byte
	Public PA_FrameN(3) As Byte

	Public CA_ID As UInt16
	Public CA_DelayC As Byte
	Public CA_FrameN As Byte

	Public CHR_Anim_Pause As Boolean

	Public spranim_fc_reg(&HFFS) As Byte
	Public spranim_frame_reg(&HFFS) As Byte

	Public palchart_col As Byte

	Public Const const_MM6_scroll_info_maxnum As Short = 32
	Public MM6PalMap(&H1FS) As Integer
	Public MM6_scroll_info_count As Integer
	Public MM6_scroll_info_segdir(31) As Byte
	Public MM6_scroll_info_CHRload(31) As Byte
	Public MM6_scroll_info_PALload(31) As Byte
	Public MM6_scroll_info_scr(31) As Byte

	Public palchartClaim As Palchart_Claim
	Public EnemDataBot As DataMoverBot 'Make public for Enemy Data insert/delete


	Public palfile As String

	Public pal_bmi As New BITMAPINFO()
	Public pal2_bmi As New BITMAPINFO()
	Public tt_bmi As New BITMAPINFO()
	Public edittile_bmi As New BITMAPINFO()
	Public tsat_bmi As New BITMAPINFO()
	Public tsat_pal_bmi As New BITMAPINFO()
	Public sbds_scr_bmi As New BITMAPINFO()
	Public sbds_obj_bmi As New BITMAPINFO()
	Public str_bmi As New BITMAPINFO()
	Public scrn_scr_bmi As New BITMAPINFO()
	Public scrn_curstr_bmi As New BITMAPINFO()
	Public enem_scr_bmi As New BITMAPINFO()
	Public enem_scrb_bmi As New BITMAPINFO()
	Public enem_tile_bmi As New BITMAPINFO()
	Public enem_pal_bmi As New BITMAPINFO()

	Public SBD_Base(&H27S, &HFFS) As Byte
	Public SBD_Objects(&HFFS, &H3FS) As Short

	Public SBDCurObj As Integer

	'megafle.dat - Offs segments entries
	Public Const o_levels As Short = 0
	Public Const o_levoffs As Short = 1
	Public Const o_chroffs As Short = 2
	Public Const o_tsatile As Short = 3
	Public Const o_tsatype As Short = 4
	Public Const o_str As Short = 5
	Public Const o_scrp As Short = 6
	Public Const o_scrlay As Short = 7
	Public Const o_dirtype As Short = 8
	Public Const o_ddA As Short = 9
	Public Const o_ddB As Short = 10
	Public Const o_sprscr As Short = 11
	Public Const o_sprX As Short = 12
	Public Const o_sprY As Short = 13
	Public Const o_sprtype As Short = 14
	Public Const o_pal As Short = 15
	Public Const o_scrmax As Short = 16
	Public Const o_scrpmax As Short = 17
	Public Const o_palmax As Short = 18
	Public Const o_sprmax As Short = 19
	Public Const o_scenebanks As Short = 20
	Public Const o_music As Short = 22
	Public Const o_chrpt As Short = 25
	Public Const o_sbd As Short = 26
	Public Const o_sprpal As Short = 27
	Public Const o_sfrmL0 As Short = 28
	Public Const o_sfrmL1 As Short = 29
	Public Const o_sfrmLB As Short = 30
	Public Const o_sfrmH0 As Short = 31
	Public Const o_sfrmH1 As Short = 32
	Public Const o_sfrmHB As Short = 33
	Public Const o_scorL0 As Short = 34
	Public Const o_scorL1 As Short = 35
	Public Const o_scorH0 As Short = 36
	Public Const o_scorH1 As Short = 37
	Public Const o_sfrmA0 As Short = 38
	Public Const o_sfrmA1 As Short = 39
	Public Const o_sfrmAB As Short = 40
	Public Const o_scorA0 As Short = 41
	Public Const o_scorA1 As Short = 42
	Public Const o_ssprL0 As Short = 43
	Public Const o_ssprL1 As Short = 44
	Public Const o_ssprLB As Short = 45
	Public Const o_ssprH0 As Short = 46
	Public Const o_ssprH1 As Short = 47
	Public Const o_ssprHB As Short = 48
	Public Const o_mmpal As Short = 49
	Public Const o_cpscroll As Short = 50
	Public Const o_cpscrn As Short = 51
	Public Const o_cpspr As Short = 52
	Public Const o_paoffs As Short = 53
	Public Const o_paoffs4L As Short = 53
	Public Const o_padata As Short = 54
	Public Const o_paoffs4H As Short = 54
	Public Const o_paoffs4A As Short = 55
	Public Const o_papal As Short = 56
	Public Const o_maxpa As Short = 59
	Public Const o_paspace As Short = 60
	Public Const o_pa4end As Short = 60
	Public Const o_maxsmp As Short = 61
	Public Const o_door1 As Short = 66
	Public Const o_door2 As Short = 67
	Public Const o_MM_sprBank As Short = 68

	'megafle.dat segment pointers
	Public Const d_offst As Short = 4
	Public Const d_blocktypes As Short = 9
	Public Const d_ex As Short = 13
	Public Const d_echrb0 As Short = 15
	Public Const d_echrb1 As Short = 16
	Public Const d_echrb1x As Short = 17
	Public Const d_enames As Short = 22
	Public Const d_dtypedat34 As Short = 26
	Public Const d_dtypedat5 As Short = 27
	Public Const d_sound As Short = 32
	Public Const d_soundt As Short = 36
	Public Const d_efflab As Short = 40
	Public Const d_minihex As Short = 41
	Public Const d_effenem4 As Short = 42
	Public Const d_greenframe4 As Short = 43
	Public Const d_greenframe5 As Short = 44
	Public Const d_sbdnames As Short = 48
	Public Const d_identsign As Short = 51
	Public Const d_syspal As Short = 52
	Public Const d_levnames As Short = 53
	Public Const d_offstname As Short = 57
	Public Const d_scenesbank As Short = 73
	Public Const d_textstrings3 As Short = 75
	Public Const d_texttable3 As Short = 78
	Public Const d_textselect As Short = 81
	Public Const d_textname3 As Short = 82
	Public Const d_enemdmgoffs3 As Short = 86
	Public Const d_weaponname3 As Short = 90
	Public Const d_sbded_cross As Short = 93
	Public Const d_scenesdata As Short = 94
	Public Const d_sprgroup As Short = 98

	'megafle.dat "datax" entries
	Public Const dex_mm3_enemsprid As Short = 35
	Public Const dex_mm3DoorOpenT As Short = 36
	Public Const dex_mm3DoorOpenA As Short = 37
	Public Const dex_mm3DoorCloseT As Short = 38
	Public Const dex_mm3DoorCloseA As Short = 39
	Public Const dex_mm5DoorOpen As Short = 40
	Public Const dex_mm5DoorClose As Short = 41

	Public Sub Initialize()
		'Need to initiate all the MFLE_Decl objects that need to be set (in original
		'0, it seems like those are created
		'   by default at one point, but in VS2022, those need to be initialized):
		pal_bmi.Initialize()
		pal2_bmi.Initialize()
		tt_bmi.Initialize()
		edittile_bmi.Initialize()
		tsat_bmi.Initialize()
		tsat_pal_bmi.Initialize()
		sbds_scr_bmi.Initialize()
		sbds_obj_bmi.Initialize()
		str_bmi.Initialize()
		scrn_scr_bmi.Initialize()
		scrn_curstr_bmi.Initialize()
		enem_scr_bmi.Initialize()
		enem_scrb_bmi.Initialize()
		enem_tile_bmi.Initialize()
		enem_pal_bmi.Initialize()
	End Sub

#Region "Unused"
	'Type PlacedObjBlocksType
	'    Ystretch As Byte
	'    Xstretch As Byte
	'End Type

	'Type PlacedObjType
	'    objID As Byte
	'    objY As Byte
	'    objX As Byte
	'    blocks(&H3F) As PlacedObjBlocksType
	'End Type

	'Type ScrObjUseType
	'    UsedObjs As Byte
	'    ScrObj(&HFF) As PlacedObjType
	'End Type

	'Type BlockObjType
	'    block(&H3F) As Byte
	'End Type

	'Public SBD_Object_Use(&H27) As ScrObjUseType   'not used yet, probably wont be
#End Region
End Module