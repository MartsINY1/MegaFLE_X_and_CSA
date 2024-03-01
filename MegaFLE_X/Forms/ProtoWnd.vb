Option Explicit On

Friend Class ProtoWnd
	Inherits System.Windows.Forms.Form

	Public passVar As Integer

	Private Mode As Integer
	Private ReadOnly _ArrFileListView_0_FileName As String = "*.txt"
	Private _ArrFileListView_1_Path As String
	Private _ArrFileListView_1_FileName As String

	Private Structure PatchByteType
		Dim Type As Byte
		Dim Src As Byte
	End Structure

	Private Structure PatchSegType
		Dim Start As Integer
		Dim NumBytes As Integer
		Dim PByte() As PatchByteType
	End Structure

	Private Structure PatchType
		Dim Loaded As Boolean
		Dim NumSegs As Integer
		Dim Seg() As PatchSegType
		Dim Description As String
		Dim AuthorInfo As String
		Dim PatchText As String
	End Structure

	Private Patch As PatchType

	Private Selected_Level As Integer

	Private ReadOnly Level_DB(255) As Short
	Private ReadOnly EnemID_DB(255, 255) As Short

	Private Const Mode_EnemUsageStat As Short = 0
	Private Const Mode_Patcher As Short = 1
	Private Const Mode_SpriteGroup As Short = 2
	Private Const ArrBtnSize As Short = 4
	Private Const ArrComboSize As Short = 2
	Private Const ArrListSize As Short = 3
	Private Const ArrLabSize As Short = 3
	Private Const ArrFileListViewSize As Short = 2
	Private Const ArrTBSize As Short = 4

	' Object that groups many items
	' Button
	Private ArrBtn() As Button
	' ComboBox
	Private ArrCombo() As ComboBox
	' Label
	Private ArrLab() As Label
	' ListBox
	Private ArrList() As ListBox
	' ListView
	Private ArrFileListView() As ListView
	' TextBox
	Private ArrTB() As TextBox

	Private Sub Form_Initialize()
		ReDim ArrBtn(ArrBtnSize)
		ReDim ArrCombo(ArrComboSize)
		ReDim ArrList(ArrListSize)
		ReDim ArrLab(ArrLabSize)
		ReDim ArrFileListView(ArrFileListViewSize)
		ReDim ArrTB(ArrTBSize)

		' Object that groups many items
		' Button
		ArrBtn(0) = _ArrBtn_0
		' ComboBox
		ArrCombo(0) = _ArrCombo_0
		' Label
		ArrLab(0) = _ArrLab_0
		' ListBox
		ArrList(0) = _ArrList_0
		'   ListView
		ArrFileListView(0) = _ArrFileListView_0
		' TextBox
		ArrTB(0) = _ArrTB_0

		_ArrFileListView_0.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize)
		_ArrFileListView_0.Columns(0).Width = _ArrFileListView_0.Width - 21 - (_ArrFileListView_0.Padding.Left + _ArrFileListView_0.Padding.Right)
	End Sub

	Public Sub Manual_Init()
		'Calling it ensure constructor above is called
	End Sub

	Public Sub ReadPatchFile(ByRef file As String)
		Dim t1 As New String(" "c, 1)
		FileOpen(1, file, OpenMode.Binary)
		Dim segCount As Integer
		Dim byteCount As Integer
		Dim SpaceIgnore, Mode As Integer
		Dim blockContent, blockName, ofsBuild, valBuild As String
		Dim skipParseNL As Byte

		blockName = ""
		blockContent = ""
		ofsBuild = ""

		SpaceIgnore = 0
		skipParseNL = 0
		Mode = 0

		Patch.PatchText = ""
		Patch.AuthorInfo = ""
		Patch.Description = ""

		valBuild = ""

		While Not EOF(1)
			FileGet(1, t1)

			If (SpaceIgnore > 0) Then
				SpaceIgnore -= 1
				GoTo patchNextByte
			End If

			If (skipParseNL And 1) Then
				If (Asc(t1) = &HDS) Then
					skipParseNL = 2
					GoTo patchNextByte
				End If
			ElseIf (skipParseNL And 2) Then
				skipParseNL = 0
				If (Asc(t1) = &HAS) Then
					GoTo patchNextByte
				End If
			End If

			If (Mode >= 4) And (Not t1 = "}") Then
				Patch.PatchText &= t1
			End If

			Select Case Mode
				Case 0 'Look for Block
					If IsSymbol(t1) Then
						blockName = t1
						Mode += 1
					End If
				Case 1 'Look for blank space
					If Not IsSymbol(t1) Then
						Mode += 1
					Else
						blockName &= t1
					End If
				Case 2 'Look for left bracket
					If t1 = "{" Then
						If blockName = "patchdata" Then
							Mode = 4
							segCount = 0
						Else
							Mode = 3
						End If
						skipParseNL = 1
						blockContent = ""
					End If
				Case 3 'read Block content
					If t1 = "}" Then
						Select Case blockName
							Case "description" : Patch.Description = blockContent
							Case "origin" : Patch.AuthorInfo = blockContent
						End Select
						Mode = 0
					Else
						blockContent &= t1
					End If
				Case 4
					If t1 = "}" Then
						Patch.NumSegs = segCount
						Mode = 0
					ElseIf IsSymbol(t1) Then
						ofsBuild = t1
						Mode = 5
					End If
				Case 5
					If (Not IsSymbol(t1)) Or (t1 = ":") Then
						If (t1 = ":") Then
							Mode = 7
						Else
							Mode = 6
						End If
						ReDim Preserve Patch.Seg(segCount)
						Patch.Seg(segCount).Start = Dec(ofsBuild)
						byteCount = 0
					Else
						ofsBuild &= t1
					End If
				Case 6
					If t1 = ":" Then Mode = 7
				Case 7
					If IsSymbol(t1) Then
						valBuild = t1
						Mode = 8
					End If
				Case 8

					If (t1 = ",") Or (t1 = ";") Or (Not IsSymbol(t1)) Then
						ReDim Preserve Patch.Seg(segCount).PByte(byteCount)

						If Common.Left(valBuild, 1) = "?" Then
							Patch.Seg(segCount).PByte(byteCount).Type = 1
						Else
							Patch.Seg(segCount).PByte(byteCount).Type = 0
							Patch.Seg(segCount).PByte(byteCount).Src = Dec(valBuild)
						End If

						If t1 = ";" Then
							Patch.Seg(segCount).NumBytes = byteCount + 1
							Mode = 4
							segCount += 1
						Else
							byteCount += 1
							Mode = 7
						End If
					Else
						valBuild &= t1
					End If

			End Select
patchNextByte:
		End While
		FileClose(1)

		Patch.Loaded = True
	End Sub

	Private Sub EnemStatUpdate()
		ArrLab(2).Text = "Total # of Enemies: " & CStr(Level_DB(Selected_Level))

		Dim a, b As Integer
		Dim s As String

		ArrList(2).Items.Clear()
		For a = 0 To 255
			b = EnemID_DB(Selected_Level, a)
			If (b > 0) Then
				s = SrcString(rdata(dspa(d_enames + gem) + a))
				ArrList(2).Items.Add(CStr(b) & " * " & s)
			End If
		Next a
	End Sub

	Public Sub InitMode_Patcher()
		Dim files() As String
		Dim gempatchfolder As String = ""
		Dim a As Integer

		ArrCombo(1) = New ComboBox With {
			.Name = "cbx1",
			.Top = 120 / 15,
			.Width = 4095 / 15,
			.Left = 120 / 15,
			.Visible = True
		}
		Me.Controls.Add(ArrCombo(1))
		AddHandler ArrCombo(1).TextChanged, AddressOf ArrCombo_TextChanged
		AddHandler ArrCombo(1).SelectedIndexChanged, AddressOf ArrCombo_SelectedIndexChanged
		ArrTB(1) = New TextBox With {
			.Name = "tb1",
			.Width = 4095 / 15,
			.Top = 600 / 15,
			.Left = 120 / 15,
			.Height = 1455 / 15,
			.Multiline = True,
			.Visible = True
		}
		Me.Controls.Add(ArrTB(1))
		ArrTB(2) = New TextBox With {
			.Name = "tb2",
			.Width = 4095 / 15,
			.Top = 2280 / 15,
			.Left = 120 / 15,
			.Height = 1815 / 15,
			.Multiline = True,
			.Visible = True
		}
		Me.Controls.Add(ArrTB(2))
		ArrTB(3) = New TextBox With {
			.Name = "tb3",
			.Width = 4095 / 15,
			.Top = 4200 / 15,
			.Left = 120 / 15,
			.Height = 375 / 15,
			.Visible = True
		}
		Me.Controls.Add(ArrTB(3))
		ArrBtn(1) = New Button With {
			.Name = "btn1",
			.Width = 1815 / 15,
			.Top = 120 / 15,
			.Left = 4560 / 15,
			.Height = 495 / 15,
			.Text = "Apply!",
			.Visible = True
		}
		ArrBtn(1).Font = New Font(ArrBtn(1).Font.FontFamily, 9.75, ArrBtn(1).Font.Style Or FontStyle.Bold)
		Me.Controls.Add(ArrBtn(1))
		AddHandler ArrBtn(1).Click, AddressOf ArrBtn_Click

		' It needs to exist since it is checked in a loop in the button array
		ArrBtn(2) = New Button
		'Load ArrBtn(2)
		'ArrBtn(2).width = 2175
		'ArrBtn(2).Top = 840
		'ArrBtn(2).Left = 4560
		'ArrBtn(2).height = 615
		'ArrBtn(2).Caption = "Revert data to original ROM."
		'ArrBtn(2).Visible = True
		ArrBtn(3) = New Button With {
			.Name = "btn3",
			.Width = 1935 / 15,
			.Top = 3600 / 15,
			.Left = 4560 / 15,
			.Height = 495 / 15,
			.Text = "Close",
			.Visible = True
		}
		ArrBtn(3).Font = New Font(ArrBtn(3).Font.FontFamily, 9.75, ArrBtn(3).Font.Style)
		Me.Controls.Add(ArrBtn(3))
		AddHandler ArrBtn(3).Click, AddressOf ArrBtn_Click
		ArrBtn(3).Font = New Font(ArrBtn(3).Font, FontStyle.Bold)

		ArrFileListView(1) = New ListView With {
			.Name = "lstV1"
		}
		Me.Controls.Add(ArrFileListView(1))
		ArrFileListView(1).Visible = False
		Select Case gem
			Case 0 : gempatchfolder = "mm3"
			Case 1 : gempatchfolder = "mm4"
			Case 2 : gempatchfolder = "mm5"
			Case 3 : gempatchfolder = "mm6"
		End Select
		_ArrFileListView_1_Path = My.Application.Info.DirectoryPath & "\patches\" & gempatchfolder
		_ArrFileListView_1_FileName = "*.txt"

		ArrFileListView(1).Items.Clear() ' Clear existing items

		files = IO.Directory.GetFiles(_ArrFileListView_1_Path, _ArrFileListView_1_FileName)

		For Each file As String In files
			Dim fileName As String = IO.Path.GetFileName(file)
			ArrFileListView(1).Items.Add(fileName)
		Next

		Me.Text = "Patches"


		For a = 0 To ArrFileListView(1).Items.Count - 1
			'tstr = ArrFileListView(1).list(a)

			ArrCombo(1).Items.Add(ArrFileListView(1).Items(a).Text)
		Next a

		Mode = Mode_Patcher
	End Sub

	Public Sub InitMode_SpriteGroup()
		ArrList(1) = New ListBox With {
			.Name = "lstB1",
			.Left = 120 / 15,
			.Top = 120 / 15,
			.Width = 3500 / 15,
			.Height = 2000 / 15,
			.Visible = True
		}
		Me.Controls.Add(ArrList(1))
		ArrBtn(1) = New Button With {
			.Name = "btn1",
			.Left = 120 / 15,
			.Top = ArrList(1).Top + ArrList(1).Height + (80 / 15),
			.Width = ArrList(1).Width,
			.Text = "Accept",
			.Visible = True
		}
		Me.Controls.Add(ArrBtn(1))
		AddHandler ArrBtn(1).Click, AddressOf ArrBtn_Click


		passVar = -1

		Me.Width = ArrList(1).Width + (ArrList(1).Left * 2) + (370 / 15)
		Me.Height = ArrList(1).Height + ArrList(1).Top + (1170 / 15)
		Me.Text = "Choose sprite group"

		Mode = Mode_SpriteGroup

		Dim counter As Integer
		Dim strp As Integer
		counter = 0
		Do
			strp = rdata(dspa(d_sprgroup + gem) + (counter * 2))
			If (rdata(strp)) Then
				ArrList(1).Items.Add(SrcString(strp))
			End If
			counter += 1
		Loop Until (rdata(strp) = 0) Or (counter > 1000)
	End Sub

	Public Sub InitMode_EnemUsageStat()
		'This has been dropped.

		Dim b, a, c As Integer
		Dim tmplevel, tmpspr As Integer
		Dim spry_ptr, sprscr_ptr, sprx_ptr, sprtype_ptr As Integer

		For b = 0 To offs(gem, 0)
			Level_DB(b) = 0
			For a = 0 To &HFFS
				EnemID_DB(b, a) = 0
			Next a
		Next b

		For tmplevel = 0 To offs(gem, 0)

			sprscr_ptr = rdata(dspa(gem) + 1) + (tmplevel * &H2000S) + rdata(dspa(gem) + 11)
			sprx_ptr = rdata(dspa(gem) + 1) + (tmplevel * &H2000S) + rdata(dspa(gem) + 12)
			spry_ptr = rdata(dspa(gem) + 1) + (tmplevel * &H2000S) + rdata(dspa(gem) + 13)
			sprtype_ptr = rdata(dspa(gem) + 1) + (tmplevel * &H2000S) + rdata(dspa(gem) + 14)

			b = 0
			For tmpspr = 0 To offs(gem, o_sprmax)
				If romdat(arrayAdjuster + sprscr_ptr + tmpspr) = &HFFS Then GoTo last_spr
				b += 1
				c = romdat(arrayAdjuster + sprtype_ptr + tmpspr)
				EnemID_DB(tmplevel, c) = EnemID_DB(tmplevel, c) + 1
			Next tmpspr
last_spr:
			Level_DB(tmplevel) = b
		Next tmplevel

		ArrList(1) = New ListBox With {
			.Name = "lstB1",
			.Height = 2400 / 15,
			.Top = 300 / 15,
			.Left = 150 / 15,
			.Width = 4020 / 15,
			.Visible = True
		}
		ArrList(1).Font = New Font("Lucida Console", ArrList(1).Font.Size, ArrList(1).Font.Style)
		Me.Controls.Add(ArrList(1))
		AddHandler ArrList(1).SelectedIndexChanged, AddressOf ArrList_SelectedIndexChanged
		For a = 0 To offs(gem, 0)
			ArrList(1).Items.Add(CStr(a) & ": " & SrcString(rdata(dspa(d_levnames + gem) + a)))
		Next a
		ArrLab(1) = New Label With {
			.Name = "lbl1",
			.Text = "Level list:",
			.Top = 100 / 15,
			.Left = 150 / 15,
			.Visible = True
		}
		Me.Controls.Add(ArrLab(1))

		Me.Height = 6000 / 15
		Me.Width = 4500 / 15
		Me.Text = "Enemy Id Usage"

		ArrLab(2) = New Label With {
			.Name = "lbl2",
			.Top = GetCtrlBottom(ArrList(1)) + (30 / 15),
			.Left = 150 / 15,
			.Height = 210 / 15,
			.Width = 3000 / 15,
			.Visible = True
		}
		Me.Controls.Add(ArrLab(2))

		ArrList(2) = New ListBox With {
			.Name = "lstB2",
			.Top = GetCtrlBottom(ArrLab(2)) + (15 / 15),
			.Left = 150 / 15,
			.Visible = True,
			.Width = 4020 / 15,
			.Height = 2400 / 15
		}
		ArrList(2).Font = New Font("Lucida Console", ArrList(2).Font.Size, ArrList(2).Font.Style)
		Me.Controls.Add(ArrList(2))
		AddHandler ArrList(2).SelectedIndexChanged, AddressOf ArrList_SelectedIndexChanged

		EnemStatUpdate()
	End Sub

	Private Sub ArrBtn_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles _ArrBtn_0.Click
		Dim Index As Short = 0

		For Each button As Button In ArrBtn
			If button.Name = eventSender.Name Then
				Exit For
			End If
			Index += 1
		Next
		Select Case Mode
			Case Mode_Patcher : Btn_Patcher(CInt(Index))
			Case Mode_SpriteGroup : Btn_SpriteGroup()
		End Select
	End Sub

	Private Sub ArrCombo_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles _ArrCombo_0.TextChanged
		Dim Index As Short = 0

		For Each comboBox As ComboBox In ArrCombo
			If comboBox.Name = eventSender.Name Then
				Exit For
			End If
			Index += 1
		Next

		Select Case Mode
			Case Mode_Patcher : Combo_Patcher(CInt(Index))
		End Select
	End Sub

	Private Sub ArrCombo_SelectedIndexChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles _ArrCombo_0.SelectedIndexChanged
		Dim Index As Short = 0

		For Each comboBox As ComboBox In ArrCombo
			If comboBox.Name = eventSender.Name Then
				Exit For
			End If
			Index += 1
		Next

		Select Case Mode
			Case Mode_Patcher : Combo_Patcher(CInt(Index))
		End Select
	End Sub

	Private Sub ArrList_SelectedIndexChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles _ArrList_0.SelectedIndexChanged
		Dim Index As Short = 0

		For Each listBox As ListBox In ArrList
			If listBox.Name = eventSender.Name Then
				Exit For
			End If
			Index += 1
		Next

		Select Case Mode
			Case Mode_EnemUsageStat : List_Stats(CInt(Index))
		End Select
	End Sub

	Private Sub Btn_Patcher(ByRef Index As Integer)
		Dim c, a, b, d As Integer
		Dim stra As String
		Select Case Index
			Case 1
				If Patch.Loaded = False Then Exit Sub
				For a = 0 To Patch.NumSegs - 1
					c = Patch.Seg(a).Start
					For b = 0 To Patch.Seg(a).NumBytes - 1
						If Patch.Seg(a).PByte(b).Type = 1 Then
							'User input
							stra = InputBox("Input hex value for byte " & Hex(b))
							d = Dec(stra)
							romdat(arrayAdjuster + c + b + 1) = d
						Else
							romdat(arrayAdjuster + c + b + 1) = Patch.Seg(a).PByte(b).Src
						End If
					Next b
				Next a
			Case 3
				Me.Close()
		End Select
	End Sub
	
	Private Sub Combo_Patcher(ByRef Index As Integer)
		Dim patchPath As String = ""
		Select Case gem
			Case 0 : patchPath = "mm3\"
			Case 1 : patchPath = "mm4\"
			Case 2 : patchPath = "mm5\"
			Case 3 : patchPath = "mm6\"
		End Select
		ReadPatchFile(My.Application.Info.DirectoryPath & "\patches\" & patchPath & ArrCombo(1).Text)
		ArrTB(1).Text = Patch.Description
		ArrTB(2).Text = Patch.PatchText
		ArrTB(3).Text = Patch.AuthorInfo
	End Sub

	Private Sub Btn_SpriteGroup()
		Dim a, p As Integer
		If ArrList(1).SelectedIndex < 0 Then
			Me.passVar = -1
		Else
			a = ArrList(1).SelectedIndex
			p = rdata(dspa(d_sprgroup + gem) + (a * 2) + 1)
			Me.passVar = p
		End If
		Me.Close()
	End Sub

	Private Sub List_Stats(ByRef Index As Integer)
		If Index = 1 Then
			Selected_Level = ArrList(Index).SelectedIndex
			EnemStatUpdate()
		End If
	End Sub
End Class