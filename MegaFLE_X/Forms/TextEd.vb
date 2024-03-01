Option Explicit On
Friend Class TextEd
	Inherits System.Windows.Forms.Form

	Dim oldntloc4, oldntloc2, value, oldtxtlist, oldntloc3, restrict As Object
	Private PageUD_ValuePrevious As Integer
	Private PageUD_ValueChangedFirstCall As Boolean = True

	' Object that groups many items
	' TextBox
	Private LnNT() As TextBox

	Private Sub Form_Initialize()
		' Object that groups many items
		' TextBox
		LnNT = New TextBox() {_LnNT_0, _LnNT_1, _LnNT_2, _LnNT_3}

		'Previous values that need to be stored
		PageUD_ValuePrevious = PageUD.Value
	End Sub

	Public Sub Manual_Init()
	End Sub

	Private Sub Update_Text()
		'MM3: Add support Boss Selected text, Ending2 text
		'MM4: Fix Nametable info for City Intro, Cossack, ending2
		'MM5: Fix Nametable info for Dr Wily Returns
		'MM5: Add support boss selected, ending 2
		Dim cycle, x, c, a, b, TableText, Y, NTLoc As Object
		Dim TempString As Object
		Dim TempString2 As String

		a = Nothing
		NTLoc = Nothing

		restrict = 1 'disable writes to the nametable boxes
		Line2TB.Text = CStr(Nothing) : Line3TB.Text = CStr(Nothing) : Line4TB.Text = CStr(Nothing)
		LnNT(0).Text = CStr(Nothing) : LnNT(1).Text = CStr(Nothing) : LnNT(2).Text = CStr(Nothing) : LnNT(3).Text = CStr(Nothing)
		Y = 1
		c = 0
		offs(gem, 65) = (rdata(dspa(d_textstrings3 + gem) + value))
		cycle = (rdata(dspa(d_textstrings3 + gem) + value + 1))
		Do While cycle > 0
			restrict = 1 'still disable writes until updating is DONE
			If gem = 0 Then If CurTextCombo.SelectedIndex = 6 Then GoTo format1
			If CurTextCombo.SelectedIndex >= 4 Then GoTo format2

format1:
			For b = 0 To 28
				TableText = CDec(romdat(arrayAdjuster + offs(gem, 65) + Y))
				If TableText >= 253 Then GoTo continue_Renamed
				If (gem = 1) And (TableText = 176 Or TableText = 127) Then
					Y += 2 : GoTo continue_Renamed
				End If
				If (gem = 2) And (TableText = 0) Then
					Y += 2 : GoTo continue_Renamed
				End If
				Y += 1
				If CurTextCombo.SelectedIndex = 6 Then TableText += 48
				TableText = SrcString(rdata(dspa(d_texttable3 + gem) + TableText))
				a &= TableText
			Next b

format2:
			x = CDec(romdat(arrayAdjuster + offs(gem, 65) + Y - 1))
			If gem = 2 Then If CurTextCombo.SelectedIndex = 7 Then x = 28
			For b = 0 To x
				TableText = CDec(romdat(arrayAdjuster + offs(gem, 65) + Y))
				If TableText >= 254 Then GoTo continue_Renamed
				If gem = 2 Then If CurTextCombo.SelectedIndex = 7 Then If TableText = 46 Or TableText = 92 Then GoTo continue_Renamed
				Y += 1
				If gem = 0 Then If CurTextCombo.SelectedIndex >= 5 Then TableText += 48
				If gem = 1 Then TableText -= 80
				TableText = SrcString(rdata(dspa(d_texttable3 + gem) + TableText))
				a &= TableText
			Next b

continue_Renamed:
			Select Case c
				Case "0"
					Line1TB.Text = a
					TempString = Hex(romdat(arrayAdjuster + offs(gem, 65) + NTLoc + 1 - rdata(dspa(d_textstrings3 + gem) + value + 3)))
					TempString2 = Common.Right("00" & Hex(romdat(arrayAdjuster + offs(gem, 65) + NTLoc + 2 - rdata(dspa(d_textstrings3 + gem) + value + 3))), 2)
					LnNT(0).Text = Common.Right("0000" + (TempString + TempString2), 4)
					If (IsNumeric(TempString)) Then
						If TempString >= 30 Or TempString < 20 Then LnNT(0).Enabled = False Else LnNT(0).Enabled = True
					Else
						LnNT(0).Enabled = False
					End If

				Case "1"
					Line2TB.Text = a
					oldntloc2 = NTLoc
					TempString = Hex(romdat(arrayAdjuster + offs(gem, 65) + NTLoc - rdata(dspa(d_textstrings3 + gem) + value + 3)))
					TempString2 = Common.Right("00" & Hex(romdat(arrayAdjuster + offs(gem, 65) + NTLoc + 1 - rdata(dspa(d_textstrings3 + gem) + value + 3))), 2)
					LnNT(1).Text = Common.Right("0000" + (TempString + TempString2), 4)
					If (IsNumeric(TempString)) Then
						If TempString >= 30 Or TempString < 20 Then LnNT(1).Enabled = False Else LnNT(1).Enabled = True
					Else
						LnNT(1).Enabled = False
					End If

				Case "2"
					Line3TB.Text = a
					oldntloc3 = NTLoc
					TempString = Hex(romdat(arrayAdjuster + offs(gem, 65) + NTLoc - rdata(dspa(d_textstrings3 + gem) + value + 3)))
					TempString2 = Common.Right("00" & Hex(romdat(arrayAdjuster + offs(gem, 65) + NTLoc + 1 - rdata(dspa(d_textstrings3 + gem) + value + 3))), 2)
					LnNT(2).Text = Common.Right("0000" + (TempString + TempString2), 4)
					If (IsNumeric(TempString)) Then
						If TempString >= 30 Or TempString < 20 Then LnNT(2).Enabled = False Else LnNT(2).Enabled = True
					Else
						LnNT(2).Enabled = False
					End If

				Case "3"
					Line4TB.Text = a
					oldntloc4 = NTLoc
					TempString = Hex(romdat(arrayAdjuster + offs(gem, 65) + NTLoc - rdata(dspa(d_textstrings3 + gem) + value + 3)))
					TempString2 = Common.Right("00" & Hex(romdat(arrayAdjuster + offs(gem, 65) + NTLoc + 1 - rdata(dspa(d_textstrings3 + gem) + value + 3))), 2)
					LnNT(3).Text = Common.Right("0000" + (TempString + TempString2), 4)
					If (IsNumeric(TempString)) Then
						If TempString >= 30 Or TempString < 20 Then LnNT(3).Enabled = False Else LnNT(3).Enabled = True
					Else
						LnNT(3).Enabled = False
					End If
			End Select

			restrict = 0 'now writes may be allowed
			TableText = Hex(romdat(arrayAdjuster + offs(gem, 65) + Y))
			Y += 3
			If gem > 0 Then
				Y -= 2
				If CurTextCombo.SelectedIndex >= 4 Then Y += 2
			End If
			If gem = 1 Then If CurTextCombo.SelectedIndex = 3 Then Y += 1
			If gem = 1 Then If CurTextCombo.SelectedIndex >= 7 Then Y -= 1
			NTLoc = Y
			If TableText = "FF" Then
				cycle -= 1
				Y += 1
				NTLoc = Y
			End If
			If gem = 2 Then
				If CurTextCombo.SelectedIndex = 7 Then
					If TableText = "2E" Or TableText = "5C" Then
						cycle -= 1
						Y += 0
						NTLoc = Y
					End If
				End If
			End If
			If cycle <= 0 Then Exit Sub
			a = Nothing
			c += 1
			If c > 3 Then Exit Sub
		Loop
	End Sub

	Public Sub CurTextCombo_SelectedIndexChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles CurTextCombo.SelectedIndexChanged
		Dim a As Object
		If CDbl(PageUD.Text) > 1 Then
			a = (CDbl(PageUD.Text) - 1) * 4
		Else
			a = 0
		End If
		If oldtxtlist <> CurTextCombo.SelectedIndex Then
			PageUD.Text = CStr(1)
			a = 0
		End If
		value = Hex(rdata(dspa(d_textstrings3 + gem) + CurTextCombo.SelectedIndex)) + a
		MaxPage.Text = "Page:                 Of " & (rdata(dspa(d_textstrings3 + gem) + value + 2))
		oldtxtlist = CurTextCombo.SelectedIndex
		Update_Text()
	End Sub



	Private Sub TextEd_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
		Dim KeyCode As Short = eventArgs.KeyCode
		Dim Shift As Short = eventArgs.KeyData \ &H10000
		MFLE_Main.Global_KeyDown(KeyCode, Shift)
	End Sub

	Public Sub TextEd_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
		Dim a As Object
		For a = 0 To (rdata(dspa(d_textselect) + gem))
			CurTextCombo.Items.Add(SrcString(rdata(dspa(d_textname3 + gem) + a)))
		Next a
		CurTextCombo.SelectedIndex = 0
	End Sub

	Private Sub LnNT_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles _LnNT_3.TextChanged, _LnNT_2.TextChanged, _LnNT_1.TextChanged, _LnNT_0.TextChanged
		Dim Index As Short = 0
		Dim paddedAddress As String

		For Each textBox As TextBox In LnNT
			If textBox.Name = eventSender.Name Then
				Exit For
			End If
			Index += 1
		Next

		Dim a As Object = Nothing
		If restrict = 1 Then Exit Sub
		If Index = 0 Then
			a += 1
		Else
			If Index = 1 Then
				a = oldntloc2
			Else
				If Index = 2 Then
					a = oldntloc3
				Else
					If Index = 3 Then a = oldntloc4
				End If
			End If
		End If
		paddedAddress = LnNT(Index).Text.PadLeft(4, "0")
		romdat(arrayAdjuster + offs(gem, 65) + 0 + a - rdata(dspa(d_textstrings3 + gem) + value + 3)) = Dec(Common.Left(paddedAddress, 2))
		romdat(arrayAdjuster + offs(gem, 65) + 1 + a - rdata(dspa(d_textstrings3 + gem) + value + 3)) = Dec(Common.Right(paddedAddress, 2))
	End Sub

	Private Sub PageUD_ActionUponNewValue()
		If PageUD_ValuePrevious = PageUD.Value Then Exit Sub

		PageUD_ValuePrevious = PageUD.Value

		CurTextCombo_SelectedIndexChanged(PageUD, New EventArgs())
	End Sub

	Private Sub PageUD_ValueChanged(sender As Object, e As EventArgs) Handles PageUD.ValueChanged
		If (PageUD_ValueChangedFirstCall) Then
			PageUD_ValueChangedFirstCall = False
		Else
			PageUD.Maximum = rdata(dspa(d_textstrings3 + gem) + value + 2)
			If UpdateUDCool(sender) Then
				' When here, Value was validated
				PageUD_ActionUponNewValue()
			End If
		End If
	End Sub

	Private Sub TextEd_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
		e.Cancel = True

		Me.Hide()
	End Sub
End Class