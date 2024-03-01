Option Explicit On
Friend Class ClsPtrDataMove
	'clsPtrDataMove

	'Class for handling movement of data by insertion / deletion,
	'and pointer correction.

	'External:
	'Rd(ptr) - ROM address read
	'Wr(ptr, data) - ROM address write

	'Dependencies:
	'clsNESAddr

	Private prPointer As Integer
	Private prIDPointer As Integer

	Private prPtrSeg_Count As Integer
	Private prPtrSeg_Lo() As Integer
	Private prPtrSeg_Hi() As Integer
	Private prPtrSeg_Entries() As Integer

	Private prDataSeg_Count As Integer
	Private prDataSeg_Start() As Integer
	Private prDataSeg_End() As Integer
	Private prDataSeg_Free() As Integer

	Private prRegardFreeSpace As Boolean

	Private myNESAddr As ClsNESAddr
	Private myNESAddr2 As ClsNESAddr

	Public Function InsertB(ByRef value As Byte) As Integer
		InsertB = InsertMove(1)
		If (InsertB > 0) Then Exit Function
		WrMem(prPointer, value)
	End Function

	Public Sub Delete(ByRef numbytes As Integer)
		DeleteMove(numbytes)
	End Sub

	'Public Sub SetDataSegs(startinp() As Long, endinp() As Long, numof)
	'prDataSegs_start = startinp
	'prDataSegs_end = endinp
	'prDataSegs_numof = numof
	'End Sub

	Public Function GetNESAddrRef() As ClsNESAddr
		GetNESAddrRef = myNESAddr
	End Function

	Public Function GetNESAddr2Ref() As ClsNESAddr
		GetNESAddr2Ref = myNESAddr2
	End Function


	Public Property RegardFreeSpace() As Boolean
		Get
			RegardFreeSpace = prRegardFreeSpace
		End Get
		Set(ByVal Value As Boolean)
			prRegardFreeSpace = Value
		End Set
	End Property


	Public Property SegFreeSpace(ByVal Index As Integer) As Integer
		Get
			If Index <= UBound(prDataSeg_Free) Then
				SegFreeSpace = prDataSeg_Free(Index)
			End If
		End Get
		Set(ByVal Value As Integer)
			If Index <= UBound(prDataSeg_Free) Then
				prDataSeg_Free(Index) = Value
			End If
		End Set
	End Property


	Public Property Pointer() As Object
		Get
			Pointer = prPointer
		End Get
		Set(ByVal Value As Object)
			prPointer = Value
		End Set
	End Property


	Public Property IDPointer() As Object
		Get
			IDPointer = prIDPointer
		End Get
		Set(ByVal Value As Object)
			prIDPointer = Value
		End Set
	End Property

	'Public Property Let DataStart(a)
	'pDataStart = a
	'End Property

	'Public Property Get DataStart()
	'DataStart = prDataStart
	'End Property

	Public Sub SetSegments(ByRef SrcDataSegArr() As Integer, ByRef SrcPtrSegArr() As Integer)
		Dim a As Integer
		a = 0
		prDataSeg_Count = 0
		While Not (a > UBound(SrcDataSegArr))
			ReDim Preserve prDataSeg_Start(prDataSeg_Count)
			ReDim Preserve prDataSeg_End(prDataSeg_Count)
			ReDim Preserve prDataSeg_Free(prDataSeg_Count)
			prDataSeg_Start(prDataSeg_Count) = SrcDataSegArr(a + 0)
			prDataSeg_End(prDataSeg_Count) = SrcDataSegArr(a + 1)
			a += 2
			prDataSeg_Count += 1
		End While

		a = 0
		prPtrSeg_Count = 0
		While Not (a > UBound(SrcPtrSegArr))
			ReDim Preserve prPtrSeg_Lo(prPtrSeg_Count)
			ReDim Preserve prPtrSeg_Hi(prPtrSeg_Count)
			ReDim Preserve prPtrSeg_Entries(prPtrSeg_Count)
			prPtrSeg_Lo(prPtrSeg_Count) = SrcPtrSegArr(a + 0)
			prPtrSeg_Hi(prPtrSeg_Count) = SrcPtrSegArr(a + 1)
			prPtrSeg_Entries(prPtrSeg_Count) = SrcPtrSegArr(a + 2)
			a += 3
			prPtrSeg_Count += 1
		End While
	End Sub

	'Public Property Let DataEnd(a)
	'prDataEnd = a
	'End Property

	'Public Property Get DataEnd()
	'DataEnd = prDataEnd
	'End Property

	Private Sub Class_Initialize()
		myNESAddr = New ClsNESAddr
		myNESAddr2 = New ClsNESAddr
		prRegardFreeSpace = False
	End Sub
	Public Sub New()
		MyBase.New()
		Class_Initialize()
	End Sub

	'* Private Subs/Functions --------------------------------------------->

	Private Function InsertMove(ByRef bytes As Integer) As Integer
		Dim a, b As Integer
		InsertMove = 0
		For b = 0 To (prDataSeg_Count - 1)
			If (prPointer >= prDataSeg_Start(b)) And (prPointer <= prDataSeg_End(b)) Then
				If prRegardFreeSpace = True Then
					If bytes > prDataSeg_Free(b) Then
						InsertMove = 1 + b
						Exit Function
					End If
					prDataSeg_Free(b) = prDataSeg_Free(b) - bytes
				End If
				For a = 0 To ((prDataSeg_End(b) - prPointer) - bytes)
					WrMem((prDataSeg_End(b) - a), RdMem(prDataSeg_End(b) - a - bytes))
				Next a
				MovePointers(bytes, b)
			End If
		Next b
	End Function

	Private Sub DeleteMove(ByRef bytes As Integer)
		Dim a, b As Integer
		For b = 0 To (prDataSeg_Count - 1)
			If (prPointer >= prDataSeg_Start(b)) And (prPointer <= prDataSeg_End(b)) Then
				For a = 0 To ((prDataSeg_End(b) - prPointer) - bytes)
					WrMem((prPointer + a), RdMem(prPointer + a + bytes))
				Next a
				MovePointers(-bytes, b)
				If prRegardFreeSpace = True Then
					prDataSeg_Free(b) = prDataSeg_Free(b) + bytes
				End If
			End If
		Next b
	End Sub

	Private Sub MovePointers(ByRef bytes As Integer, ByRef dataseg As Integer)
		Dim a, b As Integer
		'Select Case prPtrType
		'Case 0
		'Low and High split
		For b = 0 To (prPtrSeg_Count - 1)
			For a = 0 To (prPtrSeg_Entries(b) - 1)
				myNESAddr.Mem = prPtrSeg_Lo(b) + a
				myNESAddr2.lo = Rd(myNESAddr.Rom, romdat)
				myNESAddr.Mem = prPtrSeg_Hi(b) + a
				myNESAddr2.hi = Rd(myNESAddr.Rom, romdat)
				If (myNESAddr2.Mem >= prDataSeg_Start(dataseg)) And (myNESAddr2.Mem <= prDataSeg_End(dataseg)) And (myNESAddr2.Mem > prIDPointer) Then
					myNESAddr2.Mem += bytes
					Wr(myNESAddr.Rom, (myNESAddr2.hi))
					myNESAddr.Mem = prPtrSeg_Lo(b) + a
					Wr(myNESAddr.Rom, (myNESAddr2.lo))
				End If
			Next a
		Next b
		'End Select
	End Sub

	Private Sub WrMem(ByRef mema As Integer, ByRef data As Byte)
		myNESAddr.Mem = mema
		Wr(myNESAddr.Rom, data)
	End Sub

	Private Function RdMem(ByRef mema As Integer) As Byte
		myNESAddr.Mem = mema
		RdMem = Rd(myNESAddr.Rom, romdat)
	End Function

	' <---------------------------------------------------------------------


#Region "Was_ALready_Unused"
	'	Public Sub InsertA(ByRef numbytes As Integer)
	'		Dim a As Integer
	'		a = InsertMove(numbytes)
	'		'For Each a In values

	'		'Next a
	'	End Sub
	'	Public Sub PadInsert(ByRef numbytes As Integer)
	'		Dim a As Integer
	'		a = InsertMove(numbytes)
	'	End Sub

	'	Public Sub DeleteB()
	'		DeleteMove(1)
	'	End Sub
#End Region
End Class