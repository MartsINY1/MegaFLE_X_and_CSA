Option Explicit On
Friend Class ClsTxtParser
	Private TxtBuf As String
	Private TxtBufSize As Integer
	Private TxtBufPtr As Integer

	'Public functions

	Public Sub Load_file(ByRef filename As String)
		Dim fport As Integer

		fport = FreeFile()
		FileOpen(fport, filename, OpenMode.Binary)
		TxtBufSize = LOF(fport)
		TxtBuf = Space(TxtBufSize)
		FileGet(1, TxtBuf)
		FileClose(1)

		TxtBufPtr = 0
	End Sub

	Public Sub Load_string(ByRef strarg As String)
		TxtBufSize = Len(strarg)
		TxtBuf = strarg
		TxtBufPtr = 0
	End Sub

	Public Function Getstring() As String
		Dim stra As String = ""
		Dim ca As String = ""
		While Ok()
			ca = Getc()

			If Not CharIsSymbol(ca) Then
				GoTo mao
			End If
			Move(1)
			stra &= ca
		End While
mao:
		Getstring = stra
	End Function

	Public Function Gets_until_chars(ByRef charlist As String) As String
		Dim stra As String = ""
		Dim ca As String
		Dim a As Integer

		While Ok()
			ca = Getc()

			For a = 1 To Len(charlist)
				If ca = Mid(charlist, a, 1) Then
					GoTo mao
				End If
			Next a
			Move(1)
			stra &= ca
		End While
mao:
		Gets_until_chars = stra
	End Function

	Public Sub Seek_symbol()
		While (Not CharIsSymbol(Getc)) And (Ok())
			Move(1)
		End While
	End Sub

	Public Function Getc() As String
		Getc = ""
		If TxtBufPtr < TxtBufSize Then
			Getc = Mid(TxtBuf, TxtBufPtr + 1, 1)
		End If
	End Function


	Public Sub Move(ByRef offset As Integer)
		TxtBufPtr += offset
	End Sub

	Public Function Ok() As Boolean
		Ok = True
		If TxtBufPtr >= TxtBufSize Then
			Ok = False
		End If
	End Function

	'Private functions

	Private Function CharIsSymbol(ByRef argchar As String) As Integer
		CharIsSymbol = True
		If argchar = "" Then
			CharIsSymbol = False
		Else
			If (Asc(argchar) <= &H20S) Then
				CharIsSymbol = False
			End If
		End If
	End Function

#Region "WasAlreadyUnused"
	'	Public Function Gets_line() As String
	'		Dim stra As String = ""
	'		Dim ca As String
	'		While Ok()
	'			ca = Getc()

	'			If (Asc(ca) = &HDS) Or (Asc(ca) = &HAS) Then
	'				GoTo mao
	'			End If
	'			Move(1)
	'			stra &= ca
	'		End While
	'mao:
	'		Gets_line = stra
	'		While (Getc() = Chr(&HDS)) Or (Getc() = Chr(&HAS))
	'			Move(1)
	'		End While
	'	End Function

	'Public Function Get_move() As String
	'	Get_move = ""
	'	If TxtBufPtr < TxtBufSize Then
	'		Get_move = Mid(TxtBuf, TxtBufPtr + 1, 1)
	'		Move(1)
	'	End If
	'End Function
#End Region
End Class