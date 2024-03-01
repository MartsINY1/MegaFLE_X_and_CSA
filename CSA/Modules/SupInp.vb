Option Explicit On

Module SupInp
	'Support File Interpreter
	'========================
	'The format is very unpredictable and can't be broken down into
	'basic building blocks.
	'But.. it does the job.
	'I tried a more structured approach, but the result was structuredness
	'which compromized user-friendliness.

	'Private FileBuf As String
	'Private FileBufSize As Long
	'Private FileBufPtr As Long

	Private SupfBuf As ClsTxtParser

	Private Preset_Name() As String
	Private Preset_Data() As String
	Private Preset_last As Integer

	Private CHR_info_defined As Boolean
	Private CHR_info() As Integer
	Private CHR_info_ptr As Integer
	Private Bank_CHR_info_ptr() As Integer

	'Takes care of loading graphics for a sprite, as determined by the
	'support .TXT file.
	Public Sub Load_Sprite_Patterns()
		Dim c, a, b, d As Integer

		If CHR_info_defined = False Then Exit Sub

		CHR_info_ptr = Bank_CHR_info_ptr(BankPtrSelect)
		If CHR_info_ptr = -1 Then Exit Sub

		While (CHR_info_get() >= 0) And (CHR_info_ok())
			a = CHR_info_get_move()
			b = CHR_info_get_move()
			c = CHR_info_get_move()

			If (Sprite >= a) And (Sprite <= b) Then
				While (CHR_info_get() >= 0) And (CHR_info_ok())
					a = CHR_info_get_move()
					b = CHR_info_get_move()
					c = CHR_info_get_move()

					For d = 0 To (c - 1)
						If (b >= 0) And (b <= &HFFFS) Then
							PatternMap(b + d) = a + d
						End If
					Next d
				End While
				CHR_info_ptr += 1
			Else
				CHR_info_ptr += c
			End If
		End While
	End Sub

	Public Sub Load(ByRef filename As String)
		Dim chr_info_backup_ptr As Integer
		Dim b, a, c As Integer
		Dim stra, strb As String
		Dim ca As String

		SupfBuf = New ClsTxtParser

		SupfBuf.Load_file(filename)

		For a = 0 To &HFFFS
			PatternMap(a) = a + &H10S
		Next a

		CHR_info_ptr = 0

		Preset_last = -1

		BankReg_last = -1
		BankPtrSelect = 0

		BankPtr(2) = &H7C010

		DataBank = 0
		SprPtrBank = 0
		FramePtrBank = 0
		CoordPtrBank = 0

		'BaseData = 0
		'BaseDataSz = &H3800
		BaseSprLo = &H3E00S
		BaseSprHi = &H3F00S
		BaseFrameLo = &H3800S
		BaseFrameHi = &H3A00S
		BaseCoordLo = &H3C00S
		BaseCoordHi = &H3D00S

		DataMovable = 0

		DataSegLast = -1
		PtrSegLast = -1

		CoordPointerAdd = 0
		FramePointerAdd = 0
		FrameTileNumofBase = 0
		FramePageMethod = 0
		CoordinateBankSelect = 0
		CoordPairs = 0
		DataParseSensitive = 1

		ResetAll_Enabled = False

		Sprite = 0
		MaxSprite = &HFFS

		While (SupfBuf.Ok)
			SupfBuf.Seek_symbol()
			stra = LCase(SupfBuf.Getstring)
			Select Case stra
				Case "banks"
					SupfBuf.Seek_symbol()
					SupfBuf.Move(1)
					SupfBuf.Seek_symbol()
					While (Not SupfBuf.Getc = "}") And (SupfBuf.Ok)
						stra = SupfBuf.Gets_until_chars(",} ")
						BankReg_last += 1
						ReDim Preserve BankReg(BankReg_last)
						BankReg(BankReg_last) = Dec(stra)
						ca = SupfBuf.Getc
						If (ca = ",") Then
							SupfBuf.Move(1)
						End If
						SupfBuf.Seek_symbol()
					End While
					SupfBuf.Move(1)
				Case "pattern_load"
					SupfBuf.Seek_symbol()
					SupfBuf.Move(1)
					SupfBuf.Seek_symbol()
					a = 0
					While (Not SupfBuf.Getc = "}") And (SupfBuf.Ok)
						stra = SupfBuf.Gets_until_chars(",} ")
						c = Dec(stra)
						If (a < &H10S) Then
							For b = 0 To &HFFS
								PatternMap((a * &H100S) + b) = c + b
							Next b
						End If
						a += 1
						ca = SupfBuf.Getc
						If (ca = ",") Then
							SupfBuf.Move(1)
						End If
						SupfBuf.Seek_symbol()
					End While
					SupfBuf.Move(1)
				Case "spr_pal"
					SupfBuf.Seek_symbol()
					SupfBuf.Move(1)
					SupfBuf.Seek_symbol()
					a = 0
					While (Not SupfBuf.Getc = "}") And (SupfBuf.Ok)
						stra = SupfBuf.Gets_until_chars(",} ")
						If (a < &H10S) Then
							SprPal(a) = Dec(stra)
							SprPalInitial(a) = SprPal(a)
						End If
						a += 1
						ca = SupfBuf.Getc
						If (ca = ",") Then
							SupfBuf.Move(1)
						End If
						SupfBuf.Seek_symbol()
					End While
					SupfBuf.Move(1)
				Case "chr_info"
					CHR_info_defined = True
					ReDim Bank_CHR_info_ptr(BankReg_last)
					For a = 0 To BankReg_last
						Bank_CHR_info_ptr(a) = -1
					Next a
					SupfBuf.Seek_symbol()
					SupfBuf.Move(1)
					SupfBuf.Seek_symbol()
					While (Not SupfBuf.Getc = "}") And (SupfBuf.Ok)
						stra = LCase(SupfBuf.Getstring)
						Select Case stra
							Case "presets"
								SupfBuf.Seek_symbol()
								SupfBuf.Move(1)
								SupfBuf.Seek_symbol()
								While (Not SupfBuf.Getc = "}") And (SupfBuf.Ok)
									stra = SupfBuf.Getstring
									SupfBuf.Seek_symbol()
									SupfBuf.Move(1)
									SupfBuf.Seek_symbol()
									strb = SupfBuf.Gets_until_chars("}")
									SupfBuf.Move(1)
									Preset_last += 1
									ReDim Preserve Preset_Name(Preset_last)
									ReDim Preserve Preset_Data(Preset_last)
									Preset_Name(Preset_last) = LCase(stra)
									Preset_Data(Preset_last) = strb
									SupfBuf.Seek_symbol()
								End While
								SupfBuf.Move(1)
							Case "bank"
								SupfBuf.Seek_symbol()
								stra = SupfBuf.Getstring
								a = Get_BankReg_Index(Dec(stra))
								If (a >= 0) Then
									Bank_CHR_info_ptr(a) = CHR_info_ptr
									SupfBuf.Seek_symbol()
									SupfBuf.Move(1)
									SupfBuf.Seek_symbol()
									While (Not SupfBuf.Getc = "}") And (SupfBuf.Ok)
										If (SupfBuf.Getc) = ">" Then
											SupfBuf.Move(1)
										Else
											stra = SupfBuf.Gets_until_chars(",")
											a = InStr(1, stra, "-")
											If (a > 1) Then
												b = Dec(Mid(stra, 1, a - 1))
												c = Dec(Right(stra, Len(stra) - a))
											Else
												b = Dec(stra)
												c = b
											End If
											CHR_info_add(b)
											CHR_info_add(c)
											chr_info_backup_ptr = CHR_info_ptr
											CHR_info_add(0)
											SupfBuf.Move(1)
											SupfBuf.Seek_symbol()
											If SupfBuf.Getc = "{" Then
												SupfBuf.Move(1)
												stra = SupfBuf.Gets_until_chars("}")
												Interpret_CHR_info_block((stra))
												SupfBuf.Move(1)
											Else
												stra = LCase(SupfBuf.Getstring)
												For a = 0 To Preset_last
													If stra = Preset_Name(a) Then
														Exit For
													End If
												Next a
												Interpret_CHR_info_block((Preset_Data(a)))
											End If
											a = (CHR_info_ptr - chr_info_backup_ptr) - 1
											CHR_info_set_at(chr_info_backup_ptr, a)
										End If
										SupfBuf.Seek_symbol()
									End While
									CHR_info_add(-1)
									SupfBuf.Move(1)
								End If
						End Select
						SupfBuf.Seek_symbol()
					End While
					SupfBuf.Move(1)
				Case "datasegs"
					DataSegLast = -1
					SupfBuf.Seek_symbol()
					SupfBuf.Move(1)
					SupfBuf.Seek_symbol()
					While (Not SupfBuf.Getc = "}") And (SupfBuf.Ok)
						If (SupfBuf.Getc) = ">" Then
							SupfBuf.Move(1)
							SupfBuf.Seek_symbol()
							DataSegLast += 1
							ReDim Preserve DataSegs(DataSegLast)
							While (Not SupfBuf.Getc = "}") And (Not SupfBuf.Getc = ">") And (SupfBuf.Ok)
								stra = SupfBuf.Getstring
								Select Case stra
									Case "start"
										DataSegs(DataSegLast).Start = Get_Value()
									Case "end"
										DataSegs(DataSegLast).EndValue = Get_Value()
								End Select
								SupfBuf.Seek_symbol()
							End While
						Else
							SupfBuf.Move(1) 'Prevent freeze on typos
						End If
					End While
					SupfBuf.Move(1)
				Case "ptrsegs"
					PtrSegLast = -1
					SupfBuf.Seek_symbol()
					SupfBuf.Move(1)
					SupfBuf.Seek_symbol()
					While (Not SupfBuf.Getc = "}") And (SupfBuf.Ok)
						If (SupfBuf.Getc) = ">" Then
							SupfBuf.Move(1)
							SupfBuf.Seek_symbol()
							PtrSegLast += 1
							ReDim Preserve PtrSegs(PtrSegLast)
							While (Not SupfBuf.Getc = "}") And (Not SupfBuf.Getc = ">") And (SupfBuf.Ok)
								stra = SupfBuf.Getstring
								Select Case stra
									Case "lo_ptr"
										PtrSegs(PtrSegLast).loptr = Get_Value()
									Case "hi_ptr"
										PtrSegs(PtrSegLast).hiptr = Get_Value()
									Case "entries"
										PtrSegs(PtrSegLast).entries = Get_Value()
								End Select
								SupfBuf.Seek_symbol()
							End While
						Else
							SupfBuf.Move(1) 'Prevent freeze on typos
						End If
					End While
					SupfBuf.Move(1)
				Case "first_bank"
					a = Get_Value()
					a = Get_BankReg_Index(a)
					If (a >= 0) Then
						BankPtrSelect = a
					End If

				Case "coordbank0" : CoordBankReg(0) = Get_Value()
				Case "coordbank1" : CoordBankReg(1) = Get_Value()

				Case "hard_bank" : BankPtr(2) = Get_Value()

				Case "databank" : DataBank = Get_Value()
				Case "sprptrbank" : SprPtrBank = Get_Value()
				Case "frameptrbank" : FramePtrBank = Get_Value()
				Case "coordptrbank" : CoordPtrBank = Get_Value()

				Case "basedata" : a = Get_Value()
				Case "basedatasz" : a = Get_Value()
				Case "basesprlo" : BaseSprLo = Get_Value()
				Case "basesprhi" : BaseSprHi = Get_Value()
				Case "baseframelo" : BaseFrameLo = Get_Value()
				Case "baseframehi" : BaseFrameHi = Get_Value()
				Case "basecoordlo" : BaseCoordLo = Get_Value()
				Case "basecoordhi" : BaseCoordHi = Get_Value()

				Case "datamovable" : DataMovable = Get_Value()

				Case "coordpointeradd" : CoordPointerAdd = Get_Value()
				Case "framepointeradd" : FramePointerAdd = Get_Value()
				Case "frametilenumofbase" : FrameTileNumofBase = Get_Value()
				Case "framepagemethod" : FramePageMethod = Get_Value()
				Case "coordinatebankselect" : CoordinateBankSelect = Get_Value()
				Case "coordpairs" : CoordPairs = Get_Value()
				Case "dataparsesensitive" : DataParseSensitive = Get_Value()

				Case "reset"
					ResetAll_Enabled = True
					SupfBuf.Seek_symbol()
					SupfBuf.Move(1)
					SupfBuf.Seek_symbol()
					ResetAreas = -1
					While (Not SupfBuf.Getc = "}") And (SupfBuf.Ok)
						ResetAreas += 1
						ReDim Preserve ResetArea_Start(ResetAreas)
						ReDim Preserve ResetArea_Size(ResetAreas)
						ResetArea_Start(ResetAreas) = Get_Value_Plain()
						SupfBuf.Seek_symbol()
						ResetArea_Size(ResetAreas) = Get_Value_Plain()
						SupfBuf.Seek_symbol()
					End While
					SupfBuf.Move(1)

				Case "start_sprite" : Sprite = Get_Value()
				Case "max_sprite" : MaxSprite = Get_Value()
			End Select
		End While
	End Sub

	Private Sub Interpret_CHR_info_block(ByRef block As String)
		Dim tmpTP As ClsTxtParser
		Dim stra As String

		tmpTP = New ClsTxtParser

		tmpTP.Load_string(block)

		tmpTP.Seek_symbol()

		While (tmpTP.Ok And Not (tmpTP.Getc = "}"))
			If tmpTP.Getc = ">" Then
				tmpTP.Move(1)
			Else
				stra = tmpTP.Gets_until_chars(", }>")
				CHR_info_add(Dec(stra))
				If tmpTP.Getc = "," Then
					tmpTP.Move(1)
				End If
			End If
			tmpTP.Seek_symbol()
		End While
		CHR_info_add(-1)
	End Sub

	Private Sub CHR_info_add(ByRef valu As Integer)
		ReDim Preserve CHR_info(CHR_info_ptr)
		CHR_info(CHR_info_ptr) = valu
		CHR_info_ptr += 1
	End Sub

	Private Sub CHR_info_set_at(ByRef ptr As Integer, ByRef valu As Integer)
		CHR_info(ptr) = valu
	End Sub

	Private Function CHR_info_get_move() As Integer
		If (CHR_info_ptr <= UBound(CHR_info)) Then
			CHR_info_get_move = CHR_info(CHR_info_ptr)
			CHR_info_ptr += 1
		End If
	End Function

	Private Function CHR_info_get() As Integer
		If (CHR_info_ptr <= UBound(CHR_info)) Then
			CHR_info_get = CHR_info(CHR_info_ptr)
		End If
	End Function

	Private Function CHR_info_ok() As Boolean
		CHR_info_ok = True
		If (CHR_info_ptr > UBound(CHR_info)) Then
			CHR_info_ok = False
		End If
	End Function

	Private Function Get_Value() As Integer
		Dim stra As String
		SupfBuf.Seek_symbol()
		SupfBuf.Move(1)
		SupfBuf.Seek_symbol()
		stra = SupfBuf.Gets_until_chars(", " & Chr(&HDS) & Chr(&HAS))
		If SupfBuf.Getc = "," Then
			SupfBuf.Move(1)
		End If
		Get_Value = Dec(stra)
	End Function

	Private Function Get_Value_Plain() As Integer
		Dim stra As String
		stra = SupfBuf.Gets_until_chars(", " & Chr(&HDS) & Chr(&HAS))
		If SupfBuf.Getc = "," Then
			SupfBuf.Move(1)
		End If
		Get_Value_Plain = dec(stra)
	End Function
End Module