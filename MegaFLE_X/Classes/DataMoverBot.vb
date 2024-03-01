Option Explicit On

Friend Class DataMoverBot
	'///////////////////////////////////////////////////////////////////////////////////////////////////////
	'DataMoverBot - Add/Remove data in an element of a pointer table, recalc all pointers in table.
	'///////////////////////////////////////////////////////////////////////////////////////////////////////

	Public MEMSegHi As Integer
	Public BankROMPtr As Integer
	Public PointerTblMEMPtr As Integer
	Public TblEntries As Integer
	Public DataEndMEMPtr As Integer
	Public SplitLoHI As Boolean
	'Public BigendianPtrs As Boolean 'to be implemented?
	Public FreeSpace As Integer
	Public SplitLoHiSpace As Integer 'New: # of bytes to Hi Table from Low Table.
	
	Public P_CurEntry As Integer
	
	Private PtrTblROMPtr As Integer
	Private P_EntryMEMPtr As Integer
	Private P_EntryROMPtr As Integer
	Private DataEndROMPtr As Integer

	Public Sub DataBotFeed(ByRef locdspa As Short)
		Dim a As Integer
		BankROMPtr = rdata(locdspa + 0)
		MEMSegHi = rdata(locdspa + 1)
		PointerTblMEMPtr = rdata(locdspa + 2)
		TblEntries = rdata(locdspa + 3)
		a = rdata(locdspa + 4)
		SplitLoHI = (a - a - a)
		DataEndMEMPtr = rdata(locdspa + 5)
		FreeSpace = rdata(locdspa + 6)
		CurEntry = rdata(locdspa + 7)
		SplitLoHiSpace = rdata(locdspa + 8)
	End Sub

	Public Property CurEntry() As Integer
		Get
			CurEntry = P_CurEntry
		End Get
		Set(ByVal Value As Integer)
			P_CurEntry = Value
			CalcPtrs(P_CurEntry)
		End Set
	End Property
	
	Public Function EntryMEMPtr() As Integer
		'CalcPtrs P_CurEntry
		EntryMEMPtr = P_EntryMEMPtr
	End Function
	
	Public Sub SetEntryMEMPtr(ByRef ptr As Integer)
		'CalcPtrs P_CurEntry
		If SplitLoHI = True Then
			romdat(arrayAdjuster + PtrTblROMPtr + TblEntries + P_CurEntry + 1) = (CShort(ptr And &HFF00) / &H100S)
			romdat(arrayAdjuster + PtrTblROMPtr + P_CurEntry + 1) = (ptr And &HFFS)
		End If
	End Sub

	Public Function EntryROMPtr() As Integer
		'CalcPtrs P_CurEntry
		EntryROMPtr = P_EntryROMPtr
	End Function

	Public Function InsertByte(ByRef enptr As Short, ByRef by As Byte) As Byte
		Dim arr(0) As Byte
		arr(0) = by
		InsertByte = InsertArr(enptr, arr)
	End Function

	Public Function InsertArr(ByRef enptr As Short, ByRef Src As Object) As Byte
		Dim b, a, c As Integer
		Dim strlen As Integer
		Dim tmpMEMPtr As Integer
		strlen = UBound(Src) + 1

		If strlen > FreeSpace Then
			a = MsgBox("Not enough free space, " & CStr(strlen - FreeSpace) & " bytes short! Continue anyway?", MsgBoxStyle.YesNo)
			If (a <> 6) Then
				InsertArr = 1
				Exit Function
			End If
		End If

		CalcPtrs(P_CurEntry)

		'It now moves all data, free space or not.

		b = P_EntryROMPtr + enptr + strlen
		c = DataEndROMPtr - 1
		For a = c To b Step -1
			romdat(arrayAdjuster + a) = romdat(arrayAdjuster + a - strlen)
		Next a

		'b = ((DataEndMEMPtr - (FreeSpace - strlen)) - (P_EntryMEMPtr + enptr) - strlen) - 1
		'c = DataEndROMPtr - (FreeSpace - strlen)
		'For a = 0 To b
		'If (c - a) < DataEndROMPtr Then 'failsafe for now.
		'    romdat(arrayAdjuster + c - a) = romdat(arrayAdjuster + c - a - strlen)
		'End If
		'Next a

		For a = 0 To strlen - 1
			romdat(arrayAdjuster + P_EntryROMPtr + enptr + 1 + a) = Src(a)
		Next a

		If SplitLoHI = True Then
			For a = 0 To (TblEntries - 1)
				tmpMEMPtr = romdat(arrayAdjuster + PtrTblROMPtr + SplitLoHiSpace + a + 1)
				tmpMEMPtr *= &H100S
				tmpMEMPtr += romdat(arrayAdjuster + PtrTblROMPtr + a + 1)
				If tmpMEMPtr > P_EntryMEMPtr Then '<- (Matrixz) fix 12-31-07
					tmpMEMPtr += strlen
					romdat(arrayAdjuster + PtrTblROMPtr + SplitLoHiSpace + a + 1) = (tmpMEMPtr And &HFF00) / &H100S
					romdat(arrayAdjuster + PtrTblROMPtr + a + 1) = (tmpMEMPtr And &HFFS)
				End If
			Next a
		Else

		End If

		FreeSpace -= strlen
		InsertArr = 0
	End Function

	'simply overwrite, no moving of bytes.
	Public Sub WriteArr(ByRef enptr As Short, ByRef Src As Object)
		Dim a As Integer
		CalcPtrs(P_CurEntry)
		For a = 0 To UBound(Src)
			romdat(arrayAdjuster + P_EntryROMPtr + enptr + 1 + a) = Src(a)
		Next a
	End Sub

	Public Function GetArr(ByRef enptr As Short, ByRef numchars As Integer) As Object
		Dim tarr As Object
		Dim a As Integer
		CalcPtrs(P_CurEntry)
		ReDim tarr(numchars - 1)
		For a = 0 To (numchars - 1)
			tarr(a) = romdat(arrayAdjuster + P_EntryROMPtr + enptr + 1 + a)
		Next a
		GetArr = tarr
	End Function

	Public Sub RemoveBytes(ByRef enptr As Short, ByRef NumBytes As Short)
		Dim b, a, c As Integer
		Dim tmpMEMPtr As Integer
		CalcPtrs(P_CurEntry)

		'It now moves all data, free space or not.

		'fix 04-26-11. affects MM6 enemy data and Gfx Load data.
		b = P_EntryROMPtr + enptr + 1
		c = DataEndROMPtr - NumBytes
		For a = b To c
			romdat(arrayAdjuster + a) = romdat(arrayAdjuster + a + NumBytes)
		Next a

		'For a = 0 To ((DataEndMEMPtr - FreeSpace - (P_EntryMEMPtr + enptr) - numbytes) - 1) '(P_EntryMEMPtr + enptr) - numbytes)
		'    romdat(arrayAdjuster + P_EntryROMPtr + enptr + a + 1) = romdat(arrayAdjuster + P_EntryROMPtr + enptr + numbytes + a + 1)
		'Next a

		'For a = 0 To ((FreeSpace + numbytes) - 1)
		'    romdat(arrayAdjuster + DataEndROMPtr - a) = 0
		'Next a

		If SplitLoHI = True Then
			For a = 0 To (TblEntries - 1)
				tmpMEMPtr = romdat(arrayAdjuster + PtrTblROMPtr + SplitLoHiSpace + a + 1)
				tmpMEMPtr *= &H100S
				tmpMEMPtr += romdat(arrayAdjuster + PtrTblROMPtr + a + 1)
				If tmpMEMPtr > P_EntryMEMPtr Then '<- fix 12-31-07
					tmpMEMPtr -= NumBytes
					romdat(arrayAdjuster + PtrTblROMPtr + SplitLoHiSpace + a + 1) = (tmpMEMPtr And &HFF00) / &H100S
					romdat(arrayAdjuster + PtrTblROMPtr + a + 1) = (tmpMEMPtr And &HFFS)
				End If
			Next a
		Else

		End If

		FreeSpace += NumBytes

	End Sub

	Public Function GetByte(ByRef Index As Object) As Integer
		CalcPtrs(P_CurEntry)
		GetByte = romdat(arrayAdjuster + P_EntryROMPtr + 1 + Index)
	End Function

	Public Sub SetByte(ByRef Index As Short, ByRef dat As Byte)
		CalcPtrs(P_CurEntry)
		romdat(arrayAdjuster + P_EntryROMPtr + 1 + Index) = dat
	End Sub

	Private Sub CalcPtrs(ByRef DesiredEntry As Integer)
		'PtrTblROMPtr = BankROMPtr 'ROMBank * &H2000
		PtrTblROMPtr = BankROMPtr + (PointerTblMEMPtr - (MEMSegHi * &H100S)) '+ &H10
		DataEndROMPtr = BankROMPtr + (DataEndMEMPtr - (MEMSegHi * &H100S)) '+ &H10
		If SplitLoHI = True Then
			'P_EntryMEMPtr = (Asc(mid$(romdat, PtrTblROMPtr + TblEntries + DesiredEntry + 1, 1)) * &H100) + Asc(mid$(romdat, PtrTblROMPtr + DesiredEntry + 1, 1))
			P_EntryMEMPtr = romdat(arrayAdjuster + PtrTblROMPtr + SplitLoHiSpace + DesiredEntry + 1)
			P_EntryMEMPtr *= &H100S
			P_EntryMEMPtr += romdat(arrayAdjuster + PtrTblROMPtr + DesiredEntry + 1)
		Else
			P_EntryMEMPtr = (romdat(arrayAdjuster + PtrTblROMPtr + (DesiredEntry * 2) + 2) * &H100S) + romdat(arrayAdjuster + PtrTblROMPtr + (DesiredEntry * 2) + 1)
		End If
		P_EntryROMPtr = BankROMPtr + (P_EntryMEMPtr - (MEMSegHi * &H100s)) '+ &H10
	End Sub
End Class