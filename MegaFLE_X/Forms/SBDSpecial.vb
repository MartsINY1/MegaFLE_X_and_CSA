Option Explicit On
Friend Class SBDSpecial
	Inherits System.Windows.Forms.Form

	Private MaskBlockEnable As Byte
	Private MaskBlock As Byte

	Private Imported As Boolean
	Private Local_MaxScrPreset As Integer
	Private Local_StrPtr As Integer
	Private Local_ScrPtr As Integer

	Private LBBrush As Integer
	Private RBBrush As Integer

	Private CurObjUD_ValuePrevious As Integer

	' Object that groups many items
	' RadioButton
	Private LBrushOpt() As RadioButton
	Private RBrushOpt() As RadioButton

	Private Sub Form_Initialize()
		' Object that groups many items
		' RadioButton
		LBrushOpt = New RadioButton() {_LBrushOpt_0, _LBrushOpt_1, _LBrushOpt_2, _LBrushOpt_3}
		RBrushOpt = New RadioButton() {_RBrushOpt_0, _RBrushOpt_1, _RBrushOpt_2, _RBrushOpt_3}

		'Previous values that need to be stored
		CurObjUD_ValuePrevious = CurObjUD.Value
	End Sub

	Public Sub Manual_Init()
		RenderModule.PB_Init(ScreenPic, sbds_scr_bmi)
		RenderModule.PB_Init(ObjPic, sbds_obj_bmi)

		MaskBlockEnable = 0
		MaskBlock = 0

		LBBrush = 0
		RBBrush = 1

		'Imported = False
		'ScrnScroll.max = 0
		'ScrnScroll.Enabled = False
	End Sub

	Private Sub ConvBtn_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles ConvBtn.Click

		Dim UsedStrs, a, checkstr As Integer
		Dim strcountX, scrcount, strcountY As Integer
		Dim blockcount As Integer
		Dim blockscrtmp(&HFFS) As Byte
		Dim tmpblockarr(3) As Short
		Dim str_buffer(&H400S) As Byte
		Dim scr_buffer(&H27S, &H3FS) As Byte
		Dim Limit_Flag As Byte
		Dim Write_Flag As Byte

		If Imported = False Then
			MsgBox("No imported data. Import first.")
			Exit Sub
		End If

		'givenlimitmsg = False

		UsedStrs = 0
		Limit_Flag = 0

		If GetCfg("sbdspecial_ignorebottomrow") = 1 Then

			For strcountY = 0 To 7
				For strcountX = 0 To 7

					For scrcount = 0 To Local_MaxScrPreset

						'copy base data
						tmpblockarr(0) = SBD_Base(scrcount, (strcountY * &H20S) + (strcountX * 2) + 0)
						tmpblockarr(1) = SBD_Base(scrcount, (strcountY * &H20S) + (strcountX * 2) + 1)
						tmpblockarr(2) = SBD_Base(scrcount, (strcountY * &H20S) + (strcountX * 2) + &H10S)
						tmpblockarr(3) = SBD_Base(scrcount, (strcountY * &H20S) + (strcountX * 2) + &H11S)

						'Make structures based on the screen's arrangement of blocks
						'If a similiar structure exist, use it, else create a new. (if there are space.)

						For checkstr = 0 To (UsedStrs - 1)

							'Fix 3-21-11 : Must check bottom row, at least for MM4

							For blockcount = 0 To 3
								If tmpblockarr(blockcount) <> str_buffer((checkstr * 4) + blockcount) Then GoTo nextcheckstr_alg2
							Next blockcount

							a = checkstr
							GoTo decidedstr_alg2

nextcheckstr_alg2:
						Next checkstr

						If (UsedStrs = 256) Then
							Limit_Flag = 1
							a = 0
							GoTo decidedstr_alg2
						End If

						For blockcount = 0 To 3
							str_buffer((UsedStrs * 4) + blockcount) = tmpblockarr(blockcount)
						Next blockcount

						a = UsedStrs
						UsedStrs += 1

decidedstr_alg2:
						scr_buffer(scrcount, (strcountY * 8) + strcountX) = a

					Next scrcount

				Next strcountX
			Next strcountY

		Else
			For scrcount = 0 To Local_MaxScrPreset

				'copy base data
				For a = 0 To &HFFS
					blockscrtmp(a) = SBD_Base(scrcount, a)
				Next a

				'Make structures based on the screen's arrangement of blocks
				'If a similiar structure exist, use it, else create a new. (if there are space.)
				For strcountY = 0 To 7
					For strcountX = 0 To 7

						tmpblockarr(0) = blockscrtmp((strcountY * 32) + (strcountX * 2) + 0)
						tmpblockarr(1) = blockscrtmp((strcountY * 32) + (strcountX * 2) + 1)
						tmpblockarr(2) = blockscrtmp((strcountY * 32) + (strcountX * 2) + &H10S)
						tmpblockarr(3) = blockscrtmp((strcountY * 32) + (strcountX * 2) + &H11S)

						For checkstr = 0 To (UsedStrs - 1)

							'Fix 3-21-11 : Must check bottom row, at least for MM4

							For blockcount = 0 To 3
								If tmpblockarr(blockcount) <> str_buffer((checkstr * 4) + blockcount) Then GoTo nextcheckstr
							Next blockcount

							a = checkstr
							GoTo decidedstr

nextcheckstr:
						Next checkstr

						If (UsedStrs = 256) Then
							Limit_Flag = 1
							a = 0
							GoTo decidedstr
						End If

						For blockcount = 0 To 3
							str_buffer((UsedStrs * 4) + blockcount) = tmpblockarr(blockcount)
						Next blockcount

						a = UsedStrs
						UsedStrs += 1

decidedstr:
						scr_buffer(scrcount, (strcountY * 8) + strcountX) = a

					Next strcountX
				Next strcountY

			Next scrcount

		End If

		'MFLE_Main.Update_Level

		Write_Flag = 1
		If Limit_Flag = 1 Then
			a = MsgBox("Structure use past limit. Resulting conversion might be corrupt. Overwrite level with conversion?" & Chr(&HAS) & Chr(&HAS) & "(to try keep below structure limit, make screens blank or make design less complicated)", MsgBoxStyle.YesNo, "Convert to normal data")
			If (a <> 6) Then
				Write_Flag = 0
			End If
		End If

		If Write_Flag = 1 Then
			'clear structure data
			'For a = 0 To &H3FF
			'romdat(arrayAdjuster + Local_StrPtr + a) = 0
			'Next a

			For a = 0 To &H3FFS
				romdat(arrayAdjuster + Local_StrPtr + a) = str_buffer(a)
			Next a

			For scrcount = 0 To Local_MaxScrPreset
				For strcountY = 0 To 7
					For strcountX = 0 To 7
						a = scr_buffer(scrcount, (strcountY * 8) + strcountX)
						If gem < 3 Then
							romdat(arrayAdjuster + Local_ScrPtr + (scrcount * 64) + ((strcountY * 8) + strcountX)) = a
						Else
							romdat(arrayAdjuster + Local_ScrPtr + (scrcount * 8) + ((strcountY * 256) + strcountX)) = a
						End If
					Next strcountX
				Next strcountY
			Next scrcount

			If MetametatileTable.Visible Then MetametatileTable.Update_Level()
			If EnemEd.Visible = True Then EnemEd.Update_Scrn()
			If ScreenEd.Visible = True Then ScreenEd.Update_Scrn()
		End If

	End Sub


	Private Sub FillBlockBtn_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles FillBlockBtn.Click
		Dim a As Integer
		For a = 0 To 255
			SetSBDBase(sbdscreen, a, CalcTSA)
		Next a
		ScreenDraw()
	End Sub

	Private Sub FillObjBtn_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles FillObjBtn.Click
		Dim x, a, Y As Integer
		Dim obj_countY, object_height, object_width, obj_countX As Integer
		For Y = 7 To 0 Step -1
			For x = 7 To 0 Step -1
				If SBD_Objects(SBDCurObj, (Y * 8) + x) > 0 Then
					object_height = (Y + 1)
					GoTo object_height_set
				End If
			Next x
		Next Y
		object_height = 1
object_height_set:
		For x = 7 To 0 Step -1
			For Y = 7 To 0 Step -1
				If SBD_Objects(SBDCurObj, (Y * 8) + x) > 0 Then
					object_width = (x + 1)
					GoTo object_width_set
				End If
			Next Y
		Next x
		object_width = 1
object_width_set:
		obj_countY = 0
		obj_countX = 0
		For Y = 0 To 15
			For x = 0 To 15
				a = SBD_Objects(SBDCurObj, (obj_countY * 8) + obj_countX)
				If a > 0 Then
					SetSBDBase(sbdscreen, ((Y * 16) + x), (a - 1))
					'SBD_Base(sbdscreen, (y * 16) + x) = (a - 1)
				End If
				obj_countX += 1
				If obj_countX = object_width Then obj_countX = 0
			Next x
			obj_countX = 0
			obj_countY += 1
			If obj_countY = object_height Then obj_countY = 0
		Next Y
		ScreenDraw()

	End Sub

	Private Sub SetSBDBase(ByRef screenpos As Integer, ByRef blockpos As Integer, ByRef blockval As Integer)
		If MaskBlockEnable = 1 Then
			If SBD_Base(screenpos, blockpos) = MaskBlock Then
				SBD_Base(screenpos, blockpos) = blockval
			End If
		Else
			SBD_Base(screenpos, blockpos) = blockval
		End If
	End Sub

	Private Sub SBDSpecial_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load

		'MsgBox "load"
	End Sub

	Private Sub SBDSpecial_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
		Dim KeyCode As Short = eventArgs.KeyCode
		Dim Shift As Short = eventArgs.KeyData \ &H10000
		MFLE_Main.Global_KeyDown(KeyCode, Shift)
	End Sub

	'Automatically import at this point if not already done,
	'if already imported, keep data and restore control values.
	Public Sub Update_Frm()
		'ScrnScroll.Enabled = True
		If Imported = True Then
			ScrnScroll.Value = sbdscreen
		Else
			Import_Sub()
			ScrnScroll.Value = sbdscreen 'Is 0.
			'ScrnScroll.Enabled = False
			'ScrnScroll.value = 0
			'ScrnScroll.max = 0
		End If
		ScrnScroll.Maximum = (Local_MaxScrPreset + ScrnScroll.LargeChange - 1)

		SetOptCool(LBrushOpt(LBBrush), True)
		SetOptCool(RBrushOpt(RBBrush), True)

		UpdateRedrawStuff()
		UpdateMaskBlockStuff()
	End Sub
	'~
	Public Sub Update_RefreshAllBitmaps()
		RenderModule.RenderPic(ObjPic, sbds_obj_bmi)
		RenderModule.RenderPic(ScreenPic, sbds_scr_bmi)
	End Sub

	'Re-Import
	Public Sub Update_Level()
		Import_Sub()
		ScrnScroll.Value = sbdscreen 'Is 0.
		ScrnScroll.Maximum = (Local_MaxScrPreset + ScrnScroll.LargeChange - 1)
		UpdateRedrawStuff()
	End Sub

	Private Sub UpdateRedrawStuff()
		'For y = 0 To 7ScrnScroll.Min = 0

		'For x = 0 To 7
		'ScreenPic.Line (x * 32, y * 32)-((x * 32) + 32, (y * 32) + 32), 0, B
		'Next x
		'Next y
		'For y = 0 To 7
		'For x = 0 To 7
		'ObjPic.Line (x * 32, y * 32)-((x * 32) + 32, (y * 32) + 32), 0, B
		'Next x
		'Next y
		'For Y = 0 To 7
		'For X = 0 To 31
		'ObjBrowsePic.Line (X * 16, Y * 16)-((X * 16) + 16, (Y * 16) + 16), 0, B
		'Next X
		'Next Y
		'For Y = 0 To 1
		'For X = 0 To 7
		'ObjBrowsePic.Line (X * 64, Y * 64)-((X * 64) + 64, (Y * 64) + 64), RGB(255, 0, 0), B
		'Next X
		'Next Y

		'For a = 0 To 39
		'For b = 0 To 255
		'SBD_Base(a, b) = 0
		'Next b
		'Next a

		ScreenDraw()
		DrawObject()

		SetUDCool(CurObjUD, CStr(SBDCurObj), 2)

		'For Y = 0 To 7
		'For X = 0 To 7
		'MFX_Render.DrawLineH ObjPic, sbds_obj_bmi, X * 32, (X * 32) + 32, Y * 32, &H21
		'MFX_Render.DrawLineV ObjPic, sbds_obj_bmi, X * 32, Y * 32, (Y * 32) + 32, &H21
		'Next X
		'Next Y

		'MFX_Render.RenderPic ObjPic, sbds_obj_bmi  'Done in DrawObject

	End Sub

	Public Sub Update_BGPal(ByRef upd As Integer)
		If upd Then
			RenderModule.RenderPic(ObjPic, sbds_obj_bmi)
			RenderModule.RenderPic(ScreenPic, sbds_scr_bmi)
		End If
	End Sub

	Public Sub Update_Block(ByRef ublock As Integer)
		Dim Y, tileX, tilepal, blockX, blockY, blocknum, tileY, tilenum, x As Integer

		For blockY = 0 To 15
			For blockX = 0 To 15
				blocknum = SBD_Base(sbdscreen, (blockY * 16) + blockX)
				If blocknum = ublock Then
					tilepal = Nibble(romdat(arrayAdjuster + offs(gem, 4) + blocknum), 1) And 3
					For tileY = 0 To 1
						For tileX = 0 To 1
							tilenum = romdat(arrayAdjuster + offs(gem, 3) + (((tileY * 2) + tileX) * &H100S) + blocknum)
							Y = ((blockY * 16) + tileY * 8)
							x = ((blockX * 16) + tileX * 8)
							RenderModule.DrawTile(sbds_scr_bmi, chrmap(tilenum), tilepal, x, Y, romdat)
						Next tileX
					Next tileY
				End If
			Next blockX
		Next blockY

		GridDraw()

		For Y = 0 To 7
			For x = 0 To 7
				blocknum = SBD_Objects(SBDCurObj, (Y * 8) + x)
				If blocknum > 0 Then
					If (blocknum - 1) = ublock Then
						DrawObjectBlock(Y, x)
					End If
				End If
			Next x
		Next Y

		sbds_scr_bmi.bytesRGB_UpdatedSinceLastRender = True

		RenderModule.RenderPic(ObjPic, sbds_obj_bmi)
		RenderModule.RenderPic(ScreenPic, sbds_scr_bmi)
	End Sub

	Public Sub Update_TileRange(ByRef min As Integer, ByRef max As Integer)
		Dim blocknum, blockY, blockX, tilepal As Integer
		Dim Y, tileX, tileY, tilenum, x As Integer

		For blockY = 0 To 15
			For blockX = 0 To 15
				blocknum = SBD_Base(sbdscreen, (blockY * 16) + blockX)
				tilepal = Nibble(romdat(arrayAdjuster + offs(gem, 4) + blocknum), 1) And 3
				For tileY = 0 To 1
					For tileX = 0 To 1
						tilenum = romdat(arrayAdjuster + offs(gem, 3) + (((tileY * 2) + tileX) * &H100S) + blocknum)
						If (tilenum >= min) And (tilenum <= max) Then
							Y = ((blockY * 16) + tileY * 8)
							x = ((blockX * 16) + tileX * 8)
							RenderModule.DrawTile(sbds_scr_bmi, chrmap(tilenum), tilepal, x, Y, romdat)
						End If
					Next tileX
				Next tileY
			Next blockX
		Next blockY

		GridDraw()

		sbds_scr_bmi.bytesRGB_UpdatedSinceLastRender = True

		RenderModule.RenderPic(ScreenPic, sbds_scr_bmi)

		DrawObject_TileRange(min, max)
	End Sub

	Private Sub UpdateMaskBlockStuff()
		If MaskBlockEnable = 0 Then
			MBlockTB.Enabled = False
		Else
			MBlockTB.Enabled = True
		End If
		SetTBCoolText(MBlockTB, Hex(MaskBlock))
	End Sub

	Private Sub ImportAllBtn_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles ImportAllBtn.Click
		Import_Sub()
		sbdscreen = 0
		ScrnScroll.Value = 0
		ScrnScroll.Maximum = (Local_MaxScrPreset + ScrnScroll.LargeChange - 1)
		ScreenDraw()
	End Sub

	Private Sub Import_Sub()
		Dim blocknum, blockY, strX, strY, strnum, blockX, scrcount As Integer

		Local_MaxScrPreset = offs(gem, 17)
		Local_StrPtr = offs(gem, 5)
		Local_ScrPtr = offs(gem, 6)
		Imported = True

		For scrcount = 0 To offs(gem, 17)
			For strY = 0 To 7
				For strX = 0 To 7
					If gem < 3 Then
						strnum = romdat(arrayAdjuster + offs(gem, 6) + (scrcount * 64) + ((strY * 8) + strX))
					Else
						strnum = romdat(arrayAdjuster + offs(gem, 6) + (scrcount * 8) + ((strY * 256) + strX))
					End If
					For blockY = 0 To 1
						For blockX = 0 To 1
							blocknum = romdat(arrayAdjuster + offs(gem, 5) + (strnum * 4) + ((blockY * 2) + blockX))
							SBD_Base(scrcount, (strY * 32) + (strX * 2) + (blockY * 16) + blockX) = blocknum
						Next blockX
					Next blockY
				Next strX
			Next strY
		Next scrcount

	End Sub


	Private Sub LBrushOpt_CheckedChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles _LBrushOpt_3.CheckedChanged, _LBrushOpt_2.CheckedChanged, _LBrushOpt_1.CheckedChanged, _LBrushOpt_0.CheckedChanged
		If eventSender.Checked Then
			Dim Index As Short = 0

			For Each radioButton As RadioButton In LBrushOpt
				If radioButton.Name = eventSender.Name Then
					Exit For
				End If
				Index += 1
			Next

			LBBrush = Index
		End If
	End Sub

	Private Sub MBlockCheck_CheckStateChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MBlockCheck.CheckStateChanged
		If MBlockCheck.Tag <> "" Then Exit Sub
		MaskBlockEnable = MBlockCheck.CheckState
		UpdateMaskBlockStuff()
	End Sub

	Private Sub MBlockTB_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MBlockTB.TextChanged
		If MBlockTB.Tag <> "" Then Exit Sub
		MaskBlock = Dec((MBlockTB.Text)) And &HFFS
		UpdateMaskBlockStuff()
	End Sub

	Public Sub Menu_ObClear_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Menu_ObClear.Click
		Dim a, b As Integer

		'a = MsgBox("Clear? You sure?", vbYesNo, "Clear All Object Data")
		'If (a And 1) = 1 Then Exit Sub

		For a = 0 To &HFFS
			For b = 0 To &H3FS
				SBD_Objects(a, b) = 0
			Next b
		Next a

		DrawObject()
	End Sub

	Public Sub Menu_ObjLoad_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Menu_ObjLoad.Click
		Dim PathBackup As String
		Dim FileName As String
		Dim NiceDialog As New clsDialog
		Dim Title As String = "Choose a file containing object data."
		Dim InitDir As String = ""
		Dim DefExt As String = ""
		Dim Filter As String = ".OBJ files|*.obj|All files|*.*"
		Dim flags As clsDialog.DialogFlags = clsDialog.DialogFlags.CHECKFILEEXISTS Or clsDialog.DialogFlags.CHECKPATHEXISTS

		PathBackup = CurDir()
		FileName = NiceDialog.ShowOpen(Me, Title, flags, InitDir, DefExt, Filter)
		If Len(FileName) = 0 Then GoTo exitme

		FileName = Common.Left(FileName, Len(FileName))

		FileOpen(1, FileName, OpenMode.Binary)
		FileGet(1, SBD_Objects)
		FileClose(1)

		DrawObject()
exitme:
		ChDir(PathBackup)
	End Sub

	Public Sub Menu_ObjSave_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Menu_ObjSave.Click
		Dim FileName As String
		Dim NiceDialog As New clsDialog
		Dim PathBackup As String
		Dim Title As String = "Choose a file to write object data to."
		Dim InitDir As String = ""
		Dim DefExt As String = ""
		Dim Filter As String = ".OBJ files|*.obj|All files|*.*"
		Dim flags As clsDialog.DialogFlags = clsDialog.DialogFlags.CHECKPATHEXISTS

		PathBackup = CurDir()
		FileName = NiceDialog.ShowSave(Me, Title, flags, InitDir, DefExt, Filter)
		If Len(FileName) = 0 Then GoTo exitme
		FileName = Common.Left(FileName, Len(FileName))

		FileOpen(1, FileName, OpenMode.Binary)
		FilePut(1, SBD_Objects)
		FileClose(1)

exitme:
		ChDir(PathBackup)
	End Sub



	Private Sub Menu_SngScrSave_Click()

	End Sub

	Public Sub Menu_Scr_Clear_All_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Menu_Scr_Clear_All.Click
		'a = MsgBox("Are you sure?", vbYesNo, "Clear All SBD Screen Data")
		'If (a And 1) = 1 Then Exit Sub

		ClearScrRange(0, &H27S)

	End Sub

	Public Sub Menu_Scr_Clear_Current_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Menu_Scr_Clear_Current.Click
		ClearScrRange(sbdscreen, sbdscreen)
	End Sub

	Public Sub Menu_Scr_Clear_Range_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Menu_Scr_Clear_Range.Click
		Dim a, b As Integer
		Dim bola As Boolean
		bola = InputScreenRange(a, b, "Clear range of screens")
		If bola = True Then
			ClearScrRange(a, b)
		End If
	End Sub

	Private Sub ClearScrRange(ByRef first As Integer, ByRef last As Integer)
		Dim a, b As Integer
		For a = first To last
			For b = 0 To &HFFS
				SBD_Base(a, b) = 0
			Next b
		Next a

		ScreenDraw()
	End Sub

	Private Function InputScreenRange(ByRef first As Integer, ByRef last As Integer, ByRef boxtitle As String) As Boolean
		Dim tstr1, tstr2 As String
		tstr1 = InputBox("First Screen (in Hex):", boxtitle)
		tstr2 = InputBox("Last Screen (in Hex):", boxtitle)
		first = Dec(tstr1)
		last = Dec(tstr2)
		If (tstr1 = "") Or (tstr2 = "") Then
			InputScreenRange = False
		Else
			InputScreenRange = True
		End If
	End Function

	Public Sub Menu_Scr_Load_All_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Menu_Scr_Load_All.Click
		LoadScreenRange(0, &H27S, False)
	End Sub

	Private Sub LoadScreenRange(ByRef first As Integer, ByRef last As Integer, ByRef askfilebase As Boolean)
		LockPictureBoxes()
		Dim b, a, filebase As Integer
		Dim FileName As String
		Dim NiceDialog As New clsDialog
		Dim PathBackup As String
		Dim Title As String = "Choose a file containing SBD screen data."
		Dim InitDir As String = ""
		Dim DefExt As String = ""
		Dim Filter As String = ".SCR files|*.scr|All files|*.*"
		Dim flags As clsDialog.DialogFlags = clsDialog.DialogFlags.CHECKFILEEXISTS Or clsDialog.DialogFlags.CHECKPATHEXISTS
		Dim tempVal As Byte

		PathBackup = CurDir()
		FileName = NiceDialog.ShowOpen(Me, Title, flags, InitDir, DefExt, Filter)
		If Len(FileName) = 0 Then GoTo exitme
		FileName = Common.Left(FileName, Len(FileName))

		If askfilebase = True Then
			filebase = Dec(InputBox("Offset Screen in file (Hex, 0 is beggining of file):", "Load range of screens from file", "0"))
		Else
			filebase = 0
		End If

		FileOpen(1, FileName, OpenMode.Binary)
		Seek(1, (filebase * &H100S) + 1)
		For a = first To last
			For b = 0 To &HFFS
				FileGet(1, tempVal)
				SBD_Base(a, b) = tempVal
			Next b
		Next a
		FileClose(1)

		ScreenDraw()
exitme:
		ChDir(PathBackup)
		UnlockPictureBoxes()
	End Sub

	Public Sub Menu_Scr_Load_Current_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Menu_Scr_Load_Current.Click
		LoadScreenRange(sbdscreen, sbdscreen, False)
	End Sub

	Public Sub Menu_Scr_Load_Range_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Menu_Scr_Load_Range.Click
		Dim a, b As Integer
		Dim bola As Boolean
		bola = InputScreenRange(a, b, "Load range of screens from file")
		If bola = True Then
			LoadScreenRange(a, b, True)
		End If
	End Sub

	Public Sub Menu_Scr_Save_All_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Menu_Scr_Save_All.Click
		SaveScreenRange(0, &H27S, False)
	End Sub

	Public Sub Menu_Scr_Save_Current_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Menu_Scr_Save_Current.Click
		SaveScreenRange(sbdscreen, sbdscreen, False)
	End Sub

	Public Sub Menu_Scr_Save_Range_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Menu_Scr_Save_Range.Click
		Dim a, b As Integer
		Dim bola As Boolean
		bola = InputScreenRange(a, b, "Save range of screens to file")
		If bola = True Then
			SaveScreenRange(a, b, True)
		End If
	End Sub

	Private Sub SaveScreenRange(ByRef first As Integer, ByRef last As Integer, ByRef askfilebase As Boolean)
		LockPictureBoxes()
		Dim b, a, filebase As Integer
		Dim FileName As String
		Dim NiceDialog As New clsDialog
		Dim PathBackup As String
		Dim Title As String = "Choose a file to write SBD screen data to."
		Dim InitDir As String = ""
		Dim DefExt As String = ""
		Dim Filter As String = ".SCR files|*.scr|All files|*.*"
		Dim flags As clsDialog.DialogFlags = clsDialog.DialogFlags.CHECKPATHEXISTS

		PathBackup = CurDir()
		FileName = NiceDialog.ShowSave(Me, Title, flags, InitDir, DefExt, Filter)
		If Len(FileName) = 0 Then GoTo exitme
		FileName = Common.Left(FileName, Len(FileName))

		If askfilebase = True Then
			filebase = Dec(InputBox("Offset Screen in file (Hex, 0 is beggining of file):", "Save range of screens to file", "0"))
		Else
			filebase = 0
		End If

		FileOpen(1, FileName, OpenMode.Binary)
		Seek(1, (filebase * &H100S) + 1)
		For a = first To last
			For b = 0 To &HFFS
				FilePut(1, SBD_Base(a, b))
			Next b
		Next a
		FileClose(1)

exitme:
		ChDir(PathBackup)
		UnlockPictureBoxes()
	End Sub

	Private Sub ObjPic_MouseDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles ObjPic.MouseDown
		Dim Button As Short = eventArgs.Button \ &H100000
		Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
		Dim x As Single = eventArgs.X
		Dim Y As Single = eventArgs.Y
		Dim blockX, blockY As Integer
		blockY = VWidth(Int(Y / 32), 0, 7)
		blockX = VWidth(Int(x / 32), 0, 7)
		If (Button And 1) = 1 Then
			SBD_Objects(SBDCurObj, (blockY * 8) + blockX) = CalcTSA() + 1
			DrawObjectBlock(blockY, blockX)
			RenderModule.RenderPic(ObjPic, sbds_obj_bmi)
		End If
		If (Button And 2) = 2 Then
			SBD_Objects(SBDCurObj, (blockY * 8) + blockX) = 0
			DrawObjectBlock(blockY, blockX)
			RenderModule.RenderPic(ObjPic, sbds_obj_bmi)
		End If
	End Sub

	Private Sub ObjPic_MouseMove(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles ObjPic.MouseMove
		Dim Button As Short = eventArgs.Button \ &H100000
		Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
		Dim x As Single = eventArgs.X
		Dim Y As Single = eventArgs.Y
		If Button Then
			ObjPic_MouseDown(ObjPic, New System.Windows.Forms.MouseEventArgs(Button * &H100000, 0, x, Y, 0))
		End If
	End Sub

	Private Sub RBrushOpt_CheckedChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles _RBrushOpt_3.CheckedChanged, _RBrushOpt_2.CheckedChanged, _RBrushOpt_1.CheckedChanged, _RBrushOpt_0.CheckedChanged
		If eventSender.Checked Then
			Dim Index As Short = 0

			For Each radioButton As RadioButton In RBrushOpt
				If radioButton.Name = eventSender.Name Then
					Exit For
				End If
				Index += 1
			Next
			RBBrush = Index
		End If
	End Sub

	Private Sub ScreenPic_MouseDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles ScreenPic.MouseDown
		Dim Button As Short = eventArgs.Button \ &H100000
		Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
		Dim x As Single = eventArgs.X
		Dim Y As Single = eventArgs.Y
		Dim blockY, blockX As Integer
		blockY = VWidth(Int(Y / 16), 0, 15)
		blockX = VWidth(Int(x / 16), 0, 15)
		'blockindex = (blockY * 16) + blockX
		If (Button And 1) = 1 Then
			ScrMouseAction(LBBrush, blockY, blockX)
		End If
		If (Button And 2) = 2 Then
			ScrMouseAction(RBBrush, blockY, blockX)
		End If
	End Sub

	Private Sub ScrMouseAction(ByRef action As Integer, ByRef blockY As Integer, ByRef blockX As Integer)
		Dim copyblockX, tmpX, tmpY, copyblockY As Integer
		Dim objblockX, objszX, objszY, objblockY, block As Integer
		Select Case action
			Case 0
				SetSBDBase(sbdscreen, (blockY * 16) + blockX, CalcTSA)
				DrawScreenBlock(blockY, blockX)
				RenderModule.DrawLineH(sbds_scr_bmi, (blockX * 16), (blockX * 16) + 16, (blockY * 16), &H20S)
				RenderModule.DrawLineV(sbds_scr_bmi, (blockX * 16), (blockY * 16), (blockY * 16) + 16, &H20S)
				sbds_scr_bmi.bytesRGB_UpdatedSinceLastRender = True
				RenderModule.RenderPic(ScreenPic, sbds_scr_bmi)
				'ConvBtn_Click
			Case 1
				For copyblockY = 0 To 7
					For copyblockX = 0 To 7
						tmpY = copyblockY + blockY
						tmpX = copyblockX + blockX
						If tmpY > 15 Then GoTo doneblock
						If tmpX > 15 Then GoTo doneblockY
						If SBD_Objects(SBDCurObj, (copyblockY * 8) + copyblockX) > 0 Then
							SetSBDBase(sbdscreen, (tmpY * 16) + tmpX, SBD_Objects(SBDCurObj, (copyblockY * 8) + copyblockX) - 1)
							'SBD_Base(sbdscreen, (tmpY * 16) + tmpX) = SBD_Objects(SBDCurObj, (copyblockY * 8) + copyblockX) - 1
							DrawScreenBlock(tmpY, tmpX)
							RenderModule.DrawLineH(sbds_scr_bmi, (tmpX * 16), (tmpX * 16) + 16, (tmpY * 16), &H20S)
							RenderModule.DrawLineV(sbds_scr_bmi, (tmpX * 16), (tmpY * 16), (tmpY * 16) + 16, &H20S)
						End If
					Next copyblockX
doneblockY:
				Next copyblockY
doneblock:
				sbds_scr_bmi.bytesRGB_UpdatedSinceLastRender = True
				RenderModule.RenderPic(ScreenPic, sbds_scr_bmi)
				'ConvBtn_Click
			Case 2
				objszY = 0
				objszX = 0
				For objblockY = 0 To 7
					For objblockX = 0 To 7
						If SBD_Objects(SBDCurObj, (objblockY * 8) + objblockX) Then
							If (objblockY + 1) > objszY Then objszY = objblockY + 1
							If (objblockX + 1) > objszX Then objszX = objblockX + 1
						End If
					Next objblockX
				Next objblockY
				If (objszY = 0) Or (objszX = 0) Then GoTo no_obj_brush
				tmpY = blockY - (Int(blockY / objszY) * objszY)
				tmpX = blockX - (Int(blockX / objszX) * objszX)
				block = SBD_Objects(SBDCurObj, (tmpY * 8) + tmpX)
				If block Then
					SetSBDBase(sbdscreen, (blockY * 16) + blockX, block - 1)
					DrawScreenBlock(blockY, blockX)
					RenderModule.DrawLineH(sbds_scr_bmi, (blockX * 16), (blockX * 16) + 16, (blockY * 16), &H20S)
					RenderModule.DrawLineV(sbds_scr_bmi, (blockX * 16), (blockY * 16), (blockY * 16) + 16, &H20S)
				End If
				sbds_scr_bmi.bytesRGB_UpdatedSinceLastRender = True
				RenderModule.RenderPic(ScreenPic, sbds_scr_bmi)
				'ConvBtn_Click
no_obj_brush:
			Case 3
				block = SBD_Base(sbdscreen, (blockY * 16) + blockX)
				'oldblockY = curblockY
				'oldblockX = curblockX
				'curblockY = Int(block / tsatbl_blockwidthX)
				'curblockX = block - (curblockY * tsatbl_blockwidthX)
				'If MetatileTable.Visible Then MetatileTable.Update_CurBlock
				SetCurTSA(block)
				'((curblockY * tsatbl_blockwidthX) + curblockX)
		End Select
	End Sub

	Private Sub ScreenPic_MouseMove(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles ScreenPic.MouseMove
		Dim Button As Short = eventArgs.Button \ &H100000
		Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
		Dim x As Single = eventArgs.X
		Dim Y As Single = eventArgs.Y
		If Button Then
			ScreenPic_MouseDown(ScreenPic, New System.Windows.Forms.MouseEventArgs(Button * &H100000, 0, x, Y, 0))
		End If
	End Sub

	Public Sub ScrnScroll_Change(ByVal newScrollValue As Integer)
		sbdscreen = newScrollValue
		ScreenDraw()
	End Sub

	Private Sub ScreenDraw()
		ScrnLab.Text = Hex(sbdscreen)

		Dim Y, tileX, tilepal, blockX, blockY, blocknum, tileY, tilenum, x As Integer
		For blockY = 0 To 15
			For blockX = 0 To 15
				blocknum = SBD_Base(sbdscreen, (blockY * 16) + blockX)
				tilepal = (romdat(arrayAdjuster + offs(gem, 4) + blocknum) And 3)
				For tileY = 0 To 1
					For tileX = 0 To 1
						tilenum = romdat(arrayAdjuster + offs(gem, 3) + (((tileY * 2) + tileX) * &H100S) + blocknum)
						Y = ((blockY * 16) + tileY * 8)
						x = ((blockX * 16) + tileX * 8)
						RenderModule.DrawTile(sbds_scr_bmi, chrmap(tilenum), tilepal, x, Y, romdat)
					Next tileX
				Next tileY
			Next blockX
		Next blockY

		GridDraw()

		sbds_scr_bmi.bytesRGB_UpdatedSinceLastRender = True

		RenderModule.RenderPic(ScreenPic, sbds_scr_bmi)
	End Sub

	Private Sub DrawScreenBlock(ByRef blockY As Integer, ByRef blockX As Integer)
		Dim x, tileX, tilepal, blocknum, tilenum, tileY, Y As Integer

		blocknum = SBD_Base(sbdscreen, (blockY * 16) + blockX)
		tilepal = (romdat(arrayAdjuster + offs(gem, 4) + blocknum) And 3)
		For tileY = 0 To 1
			For tileX = 0 To 1
				tilenum = romdat(arrayAdjuster + offs(gem, 3) + (((tileY * 2) + tileX) * &H100S) + blocknum)
				Y = ((blockY * 16) + tileY * 8)
				x = ((blockX * 16) + tileX * 8)
				RenderModule.DrawTile(sbds_scr_bmi, chrmap(tilenum), tilepal, x, Y, romdat)
			Next tileX
		Next tileY

		sbds_scr_bmi.bytesRGB_UpdatedSinceLastRender = True
	End Sub

	Private Sub DrawObject()
		'Dim perftimeS, perftimeE, perftime

		'perftimeS = timeGetTime
		Dim x, Y As Integer
		For Y = 0 To 7
			For x = 0 To 7
				DrawObjectBlock(Y, x)
			Next x
		Next Y

		'DrawObject performance check.
		'perftimeE = timeGetTime
		'perftime = perftimeE - perftimeS
		'MsgBox perftime
		RenderModule.RenderPic(ObjPic, sbds_obj_bmi)
	End Sub

	Private Sub DrawObjectBlock(ByRef blockY As Integer, ByRef blockX As Integer)
		Dim x, tileY, tilenum, blocknum, tilepal, tileX, a, Y As Integer

		blocknum = SBD_Objects(SBDCurObj, (blockY * 8) + blockX)
		If blocknum > 0 Then
			blocknum -= 1
			tilepal = (romdat(arrayAdjuster + offs(gem, 4) + blocknum) And 3)
			For tileY = 0 To 1
				For tileX = 0 To 1
					tilenum = romdat(arrayAdjuster + offs(gem, 3) + (((tileY * 2) + tileX) * &H100S) + blocknum)
					Y = ((blockY * 32) + tileY * 16)
					x = ((blockX * 32) + tileX * 16)
					RenderModule.DrawTile(sbds_obj_bmi, chrmap(tilenum), tilepal, x, Y, romdat, 2)
				Next tileX
			Next tileY
		Else
			'MFX_Render.DrawX ObjPic, sbds_obj_bmi, (blockX * 32), (blockY * 32)
			'y = (blockY * 32) + 0
			'x = (blockX * 32) + 0
			'MFX_Render.DrawTile ObjPic, sbds_obj_bmi, 0, &H18, x, y, 2
			'y = (blockY * 32) + 0
			'x = (blockX * 32) + 16
			'MFX_Render.DrawTile ObjPic, sbds_obj_bmi, 0, &H18, x, y, 2
			'y = (blockY * 32) + 16
			'x = (blockX * 32) + 0
			'MFX_Render.DrawTile ObjPic, sbds_obj_bmi, 0, &H18, x, y, 2
			'y = (blockY * 32) + 16
			'x = (blockX * 32) + 16
			'MFX_Render.DrawTile ObjPic, sbds_obj_bmi, 0, &H18, x, y, 2

			RenderModule.DrawRectangle(sbds_obj_bmi, (blockX * 32), (blockY * 32), (blockX * 32) + 31, (blockY * 32) + 31, &H20S)
			For a = 0 To 31
				RenderModule.DrawPixel(sbds_obj_bmi, (blockX * 32) + a, (blockY * 32) + a, &H21S)
				RenderModule.DrawPixel(sbds_obj_bmi, (blockX * 32) + a, (blockY * 32) + 31 - a, &H21S)
			Next a
		End If

		sbds_obj_bmi.bytesRGB_UpdatedSinceLastRender = True
	End Sub

	Private Sub DrawObject_TileRange(ByRef min As Integer, ByRef max As Integer)
		Dim x, tileY, tilepal, blocknum, blockX, blockY, tilenum, tileX, Y As Integer

		For blockY = 0 To 7
			For blockX = 0 To 7
				blocknum = SBD_Objects(SBDCurObj, (blockY * 8) + blockX)
				If blocknum > 0 Then
					blocknum -= 1
					tilepal = (romdat(arrayAdjuster + offs(gem, 4) + blocknum) And 3)
					For tileY = 0 To 1
						For tileX = 0 To 1
							tilenum = romdat(arrayAdjuster + offs(gem, 3) + (((tileY * 2) + tileX) * &H100S) + blocknum)
							If (tilenum >= min) And (tilenum <= max) Then
								Y = ((blockY * 32) + tileY * 16)
								x = ((blockX * 32) + tileX * 16)
								RenderModule.DrawTile(sbds_obj_bmi, chrmap(tilenum), tilepal, x, Y, romdat, 2)
							End If
						Next tileX
					Next tileY
				End If
			Next blockX
		Next blockY

		sbds_obj_bmi.bytesRGB_UpdatedSinceLastRender = True

		RenderModule.RenderPic(ObjPic, sbds_obj_bmi)
	End Sub

	Private Sub GridDraw()
		Dim a, b As Integer
		For a = 0 To 15
			For b = 0 To 15
				RenderModule.DrawLineH(sbds_scr_bmi, (b * 16), (b * 16) + 16, (a * 16), &H20S)
				RenderModule.DrawLineV(sbds_scr_bmi, (b * 16), (a * 16), (a * 16) + 16, &H20S)
			Next b
		Next a

		sbds_scr_bmi.bytesRGB_UpdatedSinceLastRender = True
	End Sub

	Private Sub SetCurAsMaskBlockBtn_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles SetCurAsMaskBlockBtn.Click
		MaskBlock = CalcTSA()
		UpdateMaskBlockStuff()
	End Sub

	Private Sub ViewBlocksBtn_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles ViewBlocksBtn.Click
		If MetatileTable.Visible = False Then MetatileTable.Update_Frm()
		MetatileTable.Show()
		MetatileTable.BringToFront()
	End Sub
	Private Sub ScrnScroll_Scroll(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.ScrollEventArgs) Handles ScrnScroll.Scroll
		Select Case eventArgs.Type
			Case System.Windows.Forms.ScrollEventType.EndScroll
				ScrnScroll_Change(eventArgs.NewValue)
		End Select
	End Sub

	Private Sub SBDSpecial_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
		e.Cancel = True

		Me.Hide()
	End Sub



	Private Sub CurObjUD_ActionUponNewValue()
		If CurObjUD_ValuePrevious = CurObjUD.Value Then Exit Sub

		CurObjUD_ValuePrevious = CurObjUD.Value

		SBDCurObj = CurObjUD.Value
		DrawObject()
	End Sub

	Private Sub CurObjUD_ValueChanged(sender As Object, e As EventArgs) Handles CurObjUD.ValueChanged
		CurObjUD_ActionUponNewValue()
	End Sub

	Private Sub CurObjUD_KeyUp(sender As Object, e As KeyEventArgs) Handles CurObjUD.KeyUp
		' Set new value (with validations)
		SetUDCool(CType(sender, NumericUpDown), sender.Text, 3)

		CurObjUD_ActionUponNewValue()
	End Sub

#Region "WasAlreadyUnused"
	' Button for it was never made visible apparently
	Private Sub ImportBtn_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles ImportBtn.Click
		Dim blockX, strnum, strY, strX, blockY, blocknum As Integer

		For strY = 0 To 7
			For strX = 0 To 7
				If gem = 3 Then
					strnum = romdat(arrayAdjuster + offs(gem, 6) + (sbdscreen * 8) + ((strY * 256) + strX))
				Else
					strnum = romdat(arrayAdjuster + offs(gem, 6) + (sbdscreen * 64) + ((strY * 8) + strX))
				End If
				For blockY = 0 To 1
					For blockX = 0 To 1
						blocknum = romdat(arrayAdjuster + offs(gem, 5) + (strnum * 4) + ((blockY * 2) + blockX))
						SBD_Base(sbdscreen, (strY * 32) + (strX * 2) + (blockY * 16) + blockX) = blocknum
					Next blockX
				Next blockY
			Next strX
		Next strY

		ScreenDraw()

	End Sub

	Public Sub UnlockPictureBoxes()
		TimerUnlockPictureBoxes.Start()
	End Sub

	' This is done to prevent menu clicking or clicking in the save window to impact content of SBD Editor
	'	Problem was encountered when I would load screens from file and Screen Layout was affected by my double clicking on the file to load
	'	MartsINY 2024-01-20
	Public Sub LockPictureBoxes()
		ScreenPic.Enabled = False
		ObjPic.Enabled = False
		TimerUnlockPictureBoxes.Stop()
		TimerUnlockPictureBoxes.Interval = 200
	End Sub

	Private Sub Menu_Obj_DropDownOpened(sender As Object, e As EventArgs) Handles Menu_Obj.DropDownOpened
		LockPictureBoxes()
	End Sub

	Private Sub Menu_Scr_DropDownOpened(sender As Object, e As EventArgs) Handles Menu_Scr.DropDownOpened
		LockPictureBoxes()
	End Sub

	Private Sub Menu_Obj_DropDownClosed(sender As Object, e As EventArgs) Handles Menu_Obj.DropDownClosed
		UnlockPictureBoxes()
	End Sub

	Private Sub Menu_Scr_DropDownClosed(sender As Object, e As EventArgs) Handles Menu_Scr.DropDownClosed
		UnlockPictureBoxes()
	End Sub

	Private Sub TimerUnlockPictureBoxes_Tick(sender As Object, e As EventArgs) Handles TimerUnlockPictureBoxes.Tick
		ScreenPic.Enabled = True
		ObjPic.Enabled = True
		TimerUnlockPictureBoxes.Stop()
	End Sub

	'Private Sub Menu_ScrNew_Click()
	'	Dim a, b As Integer

	'	'a = MsgBox("Clear? You sure?", vbYesNo, "Clear All SBD Screen Data")
	'	'If (a And 1) = 1 Then Exit Sub

	'	For a = 0 To &H27S
	'		For b = 0 To &HFFS
	'			SBD_Base(a, b) = 0
	'		Next b
	'	Next a

	'	ScreenDraw()
	'End Sub
#End Region
End Class