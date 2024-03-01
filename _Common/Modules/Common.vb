Option Explicit On

Module Common
	Public dspa() As Short
	Public rdata() As Integer
	Public rdata_size As Short
	Public dspc As Byte

	Public cfgID(255) As String
	Public cfgv(255) As Object
	Public cfgtype(255) As Byte
	Public cidc As Byte

	Private cfgfile As String

	Public sse As New String(" "c, 1)

	Public Sub Init(ByRef init_rdata As Boolean)
		'Wasn't used: odoa = Chr(&HAS) ' + Chr$(&HA)
		sse = Chr(&H22S)
		'Wasn't used: stab = Chr(9)
		If init_rdata = True Then
			ReDim rdata(65535)
			ReDim dspa(255)
		End If
	End Sub

#Region "VB6_Replacement_Functions"
	' Made to replace equivalent un deprecated VB6 Function
	Public Function Right(text As String, length As Integer) As String
		Return text.Substring(text.Length - length)
	End Function

	' Made to replace equivalent un deprecated VB6 Function
	Public Function Left(text As String, length As Integer) As String
		Return text.Substring(0, length)
	End Function

	' Made to replace equivalent un deprecated VB6 Control
	Public Sub RefreshListBoxAsFileListBox(ByRef list As ListView, pattern As String, currentDirectory As String)
		Dim file As String

		list.Items.Clear()

		file = Dir(currentDirectory & "\" & pattern) ' Get the first file in the current directory

		While file <> ""
			list.Items.Add(New ListViewItem({file, currentDirectory}))
			file = Dir() ' Get the next file in the directory
		End While

		list.Refresh()
	End Sub
#End Region

	' Common code when showing a Form - Ensure it is brought to front
	Public Sub Show(frm As Form)
		If frm.Visible = False Then
			'Else it can causes infinite calls if form is already there (because of event Activated)
			frm.Show()
		Else
			frm.BringToFront()
		End If
	End Sub

	' Implement the logic to convert the color index to an RGB color value
	Public Function GetColorFromIndex(index As Integer) As Color
		Dim red As Integer = (index And 255)
		Dim green As Integer = ((index >> 8) And 255)
		Dim blue As Integer = ((index >> 16) And 255)
		Return Color.FromArgb(red, green, blue)
	End Function

	Public Function IsSymbol(ByRef charParam As String) As Boolean
		Dim a As Integer
		a = Asc(charParam)
		If (a < &H21S) Then
			IsSymbol = False
		Else
			IsSymbol = True
		End If
	End Function

	Public Function IsHexadecimalKeyCode(keyCode As Keys) As Boolean
		Dim isNumericKey As Boolean = (keyCode >= Keys.D0 AndAlso keyCode <= Keys.D9)
		Dim isAlphabeticKey As Boolean = (keyCode >= Keys.A AndAlso keyCode <= Keys.F)
		Dim isNumericPadKey As Boolean = (keyCode >= Keys.NumPad0 AndAlso keyCode <= Keys.NumPad9)

		Return isNumericKey OrElse isAlphabeticKey OrElse isNumericPadKey
	End Function

	Public Function ConvertKeyCodeToHexString(keyCode As Keys) As String
		If keyCode >= Keys.D0 AndAlso keyCode <= Keys.D9 Then
			Return (keyCode - Keys.D0).ToString()
		ElseIf keyCode >= Keys.A AndAlso keyCode <= Keys.F Then
			Return ChrW(AscW("A") + (keyCode - Keys.A)).ToString()
		ElseIf keyCode >= Keys.NumPad0 AndAlso keyCode <= Keys.NumPad9 Then
			Return (keyCode - Keys.NumPad0).ToString()
		End If

		Return ""
	End Function

	' Make a decimal value out of a string of bits
	Public Function Bitval(ByRef bitv As String, ByRef bits As Byte) As Integer
		Dim a As Integer
		Dim xbit As Byte
		Dim pvParam, bv As Integer
		pvParam = 1 : For a = 1 To (bits - 1) : pvParam *= 2 : Next a
		For xbit = 1 To bits
			If Mid(bitv, xbit, 1) = "1" Then bv += pvParam
			pvParam /= 2
		Next xbit
		Bitval = bv
	End Function

	' Make a decimal value out a hexidecimal value
	Function Dec(ByRef hexstr As String) As Integer
		Dim hexchar As String
		Dim sendstring As String
		Dim a, hexcharasc As Integer

		sendstring = "&H"
		For a = 1 To Len(hexstr)
			hexchar = Mid(hexstr, a, 1)
			hexcharasc = Asc(hexchar)
			If (hexcharasc < &H30S) Then GoTo nextchar
			If (hexcharasc > &H39S) And (hexcharasc < &H41S) Then GoTo nextchar
			If (hexcharasc > &H46S) And (hexcharasc < &H61S) Then GoTo nextchar
			If (hexcharasc > &H66S) Then GoTo nextchar
			sendstring &= hexchar
nextchar:
		Next a
		If Not sendstring = "&H" Then
			Dec = CInt(sendstring)
		Else
			Dec = 0
		End If
	End Function

	' Make a decimal value out a hexidecimal digit
	Public Function Decval(ByRef hexval As String) As Byte
		Decval = 0

		'Fixes all ranges of characters which is not hex characters.
		If Len(hexval) = 0 Then Exit Function
		If (Asc(hexval) < &H30S) Then Exit Function
		If (Asc(hexval) > &H39S) And (Asc(hexval) < &H41S) Then Exit Function
		If (Asc(hexval) > &H46S) And (Asc(hexval) < &H61S) Then Exit Function
		If (Asc(hexval) > &H66S) Then Exit Function
		'If hexval > "f" Or hexval < "0" Then Exit Function
		Decval = CShort("&H" & hexval)
	End Function

	' Make a nibble out of a byte
	Public Function Nibble(ByRef num As Byte, ByRef part As Integer) As Byte
		Select Case part
			Case 0
				Nibble = Int(num / &H10S)
			Case 1
				Nibble = num And &HFS
			Case Else
				Nibble = 0
		End Select
	End Function

	Public Function BoolBit(ByRef bool As Boolean) As String
		If bool Then BoolBit = "1" Else BoolBit = "0"
	End Function

	Public Function VWidth(ByRef var As Integer, ByRef min As Integer, ByRef max As Integer) As Integer
		If var < min Then var = min
		If var > max Then var = max
		VWidth = var
	End Function

	Public Function Word(ByRef hi As Byte, ByRef low As Byte) As Integer
		Word = hi
		Word *= &H100S
		Word += low
	End Function

	Public Function SrcString(ByRef StrPos As Integer) As String
		Dim a, b As Integer
		Dim tstr As String = ""

		a = 0
		Do
			b = rdata(StrPos + a)
			a += 1
			If b >= 255 Then GoTo SrcString_le
			tstr &= Chr(b)
			If (a >= &H100S) Then GoTo SrcString_le
		Loop
SrcString_le:
		SrcString = tstr
	End Function

	Public Function GetCfg(ByRef id As String, Optional showWarningMessage As Boolean = True) As Object
		Dim a As Integer
		GetCfg = ""

		Do
			If cfgID(a) = id Then
				GetCfg = cfgv(a)
				Exit Function
			End If
			a += 1
		Loop Until a = cidc

		If (showWarningMessage) Then MessageBox.Show("Cant find config ID: " & id, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
	End Function

	Public Sub LoadCfg(ByRef file As String)
		Dim tint As Short
		Dim tstr As String
		Dim PathBackup As String
		Dim t1 As New String(" "c, 1)

		PathBackup = CurDir()
		cfgfile = file
		ChDir(My.Application.Info.DirectoryPath)
		FileOpen(1, cfgfile, OpenMode.Binary)
cfgl:
		Do
			FileGet(1, t1)
			If t1 = "=" Then GoTo cfgeq
			If t1 = "/" Then GoTo cfge
			cfgID(cidc) &= t1
		Loop Until EOF(1)
		GoTo cfge
cfgeq:
		FileGet(1, t1)
		Select Case t1
			Case "#"
				cfgtype(cidc) = 0
				tstr = ""
				Do
					FileGet(1, t1)
					If t1 = ";" Then
						cfgv(cidc) = Val(tstr)
						cidc += 1
						FileGet(1, tint) : GoTo cfgl
					End If
					tstr &= t1
				Loop Until EOF(1)
			Case sse
				cfgtype(cidc) = 1
				tstr = ""
				Do
					FileGet(1, t1)
					If t1 = sse Then
						cfgv(cidc) = tstr
						cidc += 1
						FileGet(1, tint)
						GoTo cfgl
					End If
					tstr &= t1
				Loop Until EOF(1)
		End Select
cfge:
		FileClose(1)

		ChDir(PathBackup)
	End Sub

	Public Sub SetCfg(ByRef id As String, ByRef value As Object)
		Dim PathBackup As String
		PathBackup = CurDir()
		ChDir(My.Application.Info.DirectoryPath)

		Dim a As Integer
		a = 0
		Do
			If cfgID(a) = id Then
				cfgv(a) = value : GoTo savecfg
			End If
			a += 1
		Loop Until a = cidc
		MsgBox("Cant set config ID: " & id)
		GoTo revert_path
savecfg:

		FileOpen(1, cfgfile, OpenMode.Output)
		For a = 0 To (cidc - 1)
			Select Case cfgtype(a)
				Case 0
					PrintLine(1, cfgID(a) & "=#" & CStr(cfgv(a)) & ";")
				Case 1
					PrintLine(1, cfgID(a) & "=" & sse + cfgv(a) + sse)
			End Select
		Next a
		PrintLine(1, "/")
		FileClose(1)

revert_path:
		ChDir(PathBackup)
	End Sub

	Public Function Wrap(ByRef inv As Integer, ByRef min As Integer, ByRef max As Integer) As Integer
		Dim a As Integer
		If inv < min Then
			a = (max - min) + 1
			While (inv < min)
				inv += a
			End While
		ElseIf inv > max Then
			a = (max - min) + 1
			While (inv > max)
				inv -= a
			End While
		End If
		Wrap = inv
	End Function




	'The following routines are used to identify if a control's value has been changed by the user
	'or by the program. Convenient as it is, Visual Basic calls _Change routine in both cases, which does
	'unneccesary updating and can even result in infinitie loops. Set(Control)Cool is called to modify a
	'Controls Value and identify that the program did, using tag property. Then, a line is placed in all
	'relevant _Change routines that quits if the tag property is set.

	'Return False if no update must be done
	Public Function UpdateUDCool(ByRef numericUpDown As NumericUpDown) As Boolean
		' Tag is used to prevent this function from triggering itself
		If numericUpDown.Tag <> vbNullString Then Return False

		If numericUpDown.Hexadecimal Then
			' Text property will be used farther
			numericUpDown.Text = CInt(numericUpDown.Value).ToString("X")
		Else
			' Text property will be used farther
			numericUpDown.Text = CStr(numericUpDown.Value)
		End If

		Return True
	End Function

	Public Sub SetUDCool(ByRef numericUpDown As NumericUpDown, text As String, maxLength As Integer)
		numericUpDown.Tag = ":)" 'disable Change_Value Event by using .Tag

		Dim textBox As TextBox = TryCast(numericUpDown.Controls(1), TextBox)

		SetTBCoolNumWithValidation(textBox, text, numericUpDown.Maximum, maxLength, numericUpDown.Hexadecimal, numericUpDown)

		numericUpDown.Tag = vbNullString 're-enable Change_Value Event

		' Old way
		''Remember cursor position
		'Dim cursorPos As Integer
		'Dim textBox As TextBox = TryCast(numericUpDown.Controls(1), TextBox)
		'cursorPos = textBox.SelectionStart

		''Filter every minus symbol
		'text = text.Replace("-", "")

		'If text = "" Then text = "0"

		'If text.Length > maxLength Then
		'	' Idea was not applied
		'	'text = If(lastAddedHex = "", "0", lastAddedHex)
		'	text = text.Substring(0, Math.Min(text.Length, maxLength))

		'	'Put cursor back at start if at end
		'	If cursorPos >= maxLength Then cursorPos = 0
		'End If

		'If numericUpDown.Hexadecimal Then
		'	'Value must not be beyond maximum allowed in NumericUpDown
		'	If Convert.ToInt32(text, 16) > numericUpDown.Maximum Then text = Convert.ToString(CInt(numericUpDown.Maximum), 16)

		'	numericUpDown.Text = text
		'	numericUpDown.Value = Convert.ToInt32(text, 16)
		'Else
		'	'Value must not be beyond maximum allowed in NumericUpDown
		'	If CDec(text) > numericUpDown.Maximum Then text = CStr(numericUpDown.Maximum)

		'	numericUpDown.Text = text
		'	numericUpDown.Value = CDec(text)
		'End If

		'' Set back Cursor Position
		'numericUpDown.Select(cursorPos, 0)

		'numericUpDown.Tag = vbNullString 're-enable Change_Value Event
	End Sub

	Public Sub SetTBCoolText(ByRef tb As System.Windows.Forms.TextBox, ByRef text As String)
		tb.Tag = ":)" 'disable tb_Change routine's action by using .Tag
		Dim spos As Integer
		spos = tb.SelectionStart
		If Len(tb.Text) = 0 Then spos = 1
		tb.Text = text 'set
		tb.SelectionStart = spos 'restore current cursor position
		tb.Tag = vbNullString 're-enable tb_Change
	End Sub

	Public Sub SetTBCoolNumWithValidation(ByRef textBox As TextBox, text As String, maxValue As Integer, maxLength As Integer, Optional hexadecimal As Boolean = True, Optional numericUpDown As NumericUpDown = Nothing)
		textBox.Tag = ":)" 'disable tb_Change routine's action by using .Tag

		'Remember cursor position
		Dim cursorPos As Integer
		cursorPos = textBox.SelectionStart

		'Filter every minus symbol
		text = text.Replace("-", "")

		If text = "" Then text = "0"

		If text.Length > maxLength Then
			' Idea was not applied
			'text = If(lastAddedHex = "", "0", lastAddedHex)
			text = text.Substring(0, Math.Min(text.Length, maxLength))

			'Put cursor back at start if at end
			If cursorPos >= maxLength Then cursorPos = 0
		End If

		If hexadecimal Then
			'Value must not be beyond maximum allowed in NumericUpDown
			text = Hex(VWidth(Dec(text), 0, maxValue))

			textBox.Text = text

			If numericUpDown IsNot Nothing Then numericUpDown.Value = Convert.ToInt32(text, 16)
		Else
			'Value must not be beyond maximum allowed in NumericUpDown
			text = VWidth(CInt(text), 0, maxValue)

			textBox.Text = text

			If numericUpDown IsNot Nothing Then numericUpDown.Value = CDec(text)
		End If

		' Set back Cursor Position
		textBox.Select(cursorPos, 0)

		textBox.Tag = vbNullString 're-enable Change_Value Event

		' Old way
		'textBox.Tag = ":)" 'disable tb_Change routine's action by using .Tag
		'Dim spos As Integer
		'spos = textBox.SelectionStart
		'If Len(textBox.Text) = 0 Then spos = 1
		'textBox.Text = text 'set
		'textBox.SelectionStart = spos 'restore current cursor position
		'textBox.Tag = vbNullString 're-enable tb_Change
	End Sub

	Public Sub SetOptCool(ByRef opt As System.Windows.Forms.RadioButton, ByRef oval As Boolean)
		opt.Tag = ":)"
		opt.Checked = oval
		opt.Tag = vbNullString
	End Sub

	Public Sub SetCheckCool(ByRef check As System.Windows.Forms.CheckBox, ByRef value As Byte)
		check.Tag = ":)"
		check.CheckState = value
		check.Tag = vbNullString
	End Sub

	Public Sub SetListCool(ByRef list As System.Windows.Forms.ListBox, ByRef value As Short)
		list.Tag = ":)"
		list.SelectedIndex = value
		list.Tag = vbNullString
	End Sub

	Public Sub SetComboCool(ByRef combo As System.Windows.Forms.ComboBox, ByRef value As Object)
		combo.Tag = ":)"
		combo.SelectedIndex = value
		combo.Tag = vbNullString
	End Sub






	Public Function RGBmirr(ByRef col As Integer) As Integer
		RGBmirr = RGB(Int(col / 65536) And 255, Int(col / 256) And 255, col And 255)
		'RGBmirr = ((col And &HFF) * 65536) + (((col / &H100) And &HFF) * 256) + ((col / &H10000) And &HFF)
	End Function

	Public Function GetCtrlBottom(ByRef ctrl As System.Windows.Forms.Control) As Integer
		GetCtrlBottom = ctrl.Top + ctrl.Height
	End Function

	Public Sub LoadResDat(ByRef file As String)
		Dim tdspt(255) As String
		Dim Index(255) As Short
		Dim index_count, mf As Integer
		Dim tstr As String
		Dim b, a, c As Integer
		Dim tdspa(255) As Integer
		Dim PathBackup As String
		Dim t1 As New String(" "c, 1)

		dspc = 0

		PathBackup = CurDir()
		FileOpen(1, file, OpenMode.Binary)
		Do
			FileGet(1, t1)
			Select Case t1
				Case "/"
					Do
						FileGet(1, t1)
					Loop Until t1 = "/" Or EOF(1)
				Case "{"
					index_count = 0
					tdspa(dspc) = a
					Do
						FileGet(1, t1)
						If Not t1 = "_" Then
							If Asc(t1) < Asc("a") Or Asc(t1) > Asc("z") Then
								If Asc(t1) < Asc("0") Or Asc(t1) > Asc("9") Then GoTo dspl_nb
							End If
						End If
						tdspt(dspc) &= t1
					Loop Until EOF(1)
				Case "}"
					'Followiung would just write text directly on the form. If needed, write it somewhere better
					'If dbug Then outform.Print("$", Hex(tdspa(dspc)), ": ", tdspt(dspc))
					dspc += 1
					If index_count Then
						tdspa(dspc) = a
						tdspt(dspc) = tdspt(dspc - 1) & "&index"
						For b = 1 To index_count
							rdata(a) = Index(b - 1)
							a += 1
						Next b
						'Followiung would just write text directly on the form. If needed, write it somewhere better
						'If dbug Then outform.Print("$", Hex(tdspa(dspc)), ": ", tdspt(dspc))
						dspc += 1
					End If
				Case "!"
morenum:
					tstr = ""
					FileGet(1, t1)
					If t1 = "-" Then
						mf = 1
						FileGet(1, t1)
					Else
						mf = 0
					End If
					Do
						If t1 = "#" Then t1 = "1"
						If t1 = "." Then t1 = "0"
						If Asc(t1) < Asc("0") Or Asc(t1) > Asc("9") Then
							If Asc(t1) < Asc("A") Or Asc(t1) > Asc("F") Then GoTo dspl_bytedone
						End If
						tstr &= t1
						FileGet(1, t1)
					Loop Until EOF(1)
dspl_bytedone:
					rdata(a) = 0
					c = 1
					For b = 0 To Len(tstr) - 1
						rdata(a) += (Dec(Mid(tstr, Len(tstr) - b, 1)) * c)
						c *= 16
					Next b
					If mf Then rdata(a) = rdata(a) - rdata(a) - rdata(a)
					a += 1
					If t1 = "!" Then GoTo morenum
				Case Chr(34)
					Do
						FileGet(1, t1)
						If Asc(t1) = 34 Then
							rdata(a) = 255
							a += 1
							GoTo dspl_nb
						End If
						rdata(a) = Asc(t1)
						a += 1
					Loop Until EOF(1)
				Case "&"
					Index(index_count) = a
					index_count += 1
				Case "%"
					tstr = ""
					Do
						FileGet(1, t1)
						If t1 = "=" Then GoTo dspl_mapnd
						tstr &= t1
					Loop Until EOF(1)
dspl_mapnd:
					b = Val(tstr)
					tstr = ""
					Do
						FileGet(1, t1)
						If Not t1 = "_" And Not t1 = "&" Then
							If Asc(t1) < Asc("a") Or Asc(t1) > Asc("z") Then
								If Asc(t1) < Asc("0") Or Asc(t1) > Asc("9") Then GoTo dspl_maptd
							End If
						End If
						tstr &= t1
					Loop Until EOF(1)
dspl_maptd:
					For c = 0 To dspc - 1
						If tdspt(c) = tstr Then GoTo dspl_mapftd
					Next c
dspl_mapftd:
					dspa(b) = tdspa(c)
				Case Else
			End Select
dspl_nb:
		Loop Until EOF(1)
		rdata_size = a
		FileClose(1)
		ChDir(PathBackup)
	End Sub

	Public Function GetFileString(ByRef chn As Byte) As String
		Dim ctstr As Integer
		Dim ct1 As String
		GetFileString = ""
		ct1 = " "
		Do
			FileGet(chn, ct1)
			If Asc(ct1) = &HDS Then GetFileString = CStr(ctstr) : Exit Function
			If Asc(ct1) = &HAS Then GetFileString = CStr(ctstr) : Exit Function
			If Asc(ct1) = &H9S Then GetFileString = CStr(ctstr) : Exit Function
			If Asc(ct1) = &H20S Then GetFileString = CStr(ctstr) : Exit Function
			ctstr += CDbl(ct1)
		Loop Until EOF(chn)
	End Function

	Public Sub DumpString(ByRef strParam As String)
		Dim PathBackup As String
		PathBackup = CurDir()
		ChDir(My.Application.Info.DirectoryPath)
		If Dir("dump.log") <> "" Then Kill("dump.log")
		FileOpen(1, "dump.log", OpenMode.Binary)
		FilePut(1, strParam)
		FileClose(1)
		ChDir(PathBackup)
	End Sub

	Public Sub Killifexistandopen(ByRef FileName As String, ByRef port As Byte)
		If Dir(FileName) <> "" Then Kill(FileName)
		FileOpen(port, FileName, OpenMode.Binary)
	End Sub

#Region "WasAlreadyCommented"
	'Simple NES tile painter
	'Sub NEStiledraw(ByRef object_Renamed As System.Windows.Forms.PictureBox, ByRef Y As Short, ByRef X As Short, ByRef ScaleX As Byte, ByRef ScaleY As Byte, ByRef FlipY As Integer, ByRef FlipX As Integer, ByRef layerflag As Integer, ByRef Source As String, ByRef palette() As Object)
	'    Dim high, valbA, byteA, pixY, pixX, byteB, valbB, bitX As Integer
	'    For pixY = 0 To 7
	'		byteA = Asc(Mid(Source, System.Math.Abs((FlipY * 7) - pixY) + 1, 1)) 'Asc(mid$(romdat, Source + Abs((FlipY * 7) - pixY) + 1, 1))
	'		byteB = Asc(Mid(Source, System.Math.Abs((FlipY * 7) - pixY) + 9, 1)) 'Asc(mid$(romdat, Source + Abs((FlipY * 7) - pixY) + 9, 1))
	'		valbA = 0 : valbB = 0 : high = 128
	'		For pixX = 0 To 7
	'			bitX = CShort((byteA And (2 ^ (7 - System.Math.Abs((FlipX * 7) - pixX)))) > 0 And 1) + CShort((byteB And (2 ^ (7 - System.Math.Abs((FlipX * 7) - pixX)))) > 0 And 1 * 2)
	'			If bitX Or layerflag Then
	'                'object_Renamed.Line((X + pixX) * ScaleX, (Y + pixY) * ScaleY) - (((X + pixX) * ScaleX) + (ScaleX - 1), ((Y + pixY) * ScaleY) + (ScaleY - 1)), palette(bitX), BF
	'            End If
	'			high /= 2
	'		Next pixX
	'	Next pixY
	'End Sub

	'Public Sub SetBarCool(bar As Slider, val As Long)
	'bar.Tag = ":)"
	'bar.Value = val
	'bar.Tag = ""
	'End Sub
#End Region
End Module