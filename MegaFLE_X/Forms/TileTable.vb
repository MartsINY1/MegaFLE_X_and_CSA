Option Explicit On

Friend Class TileTable
	Inherits System.Windows.Forms.Form

	Private ReadOnly borderSize As Integer = 2

	Private initialFormWidth As Integer
	Private initialFormHeight As Integer
	Private ReadOnly BtnMoreOptionsLessOptionsString = "Less Options"
	Private ReadOnly BtnMoreOptionsMoreOptionsString = "More Options"

	Private curcol, curpal As Integer
	Private ReadOnly tilemem(63) As Byte
	Private ReadOnly drawpalmap(255) As Byte

	Private DelayUD_ValuePrevious As Integer
	Private FramesUD_ValuePrevious As Integer
	Private CHRIDUD_ValuePrevious As Integer
	Private BGCHRUD_ValuePrevious() As Integer

	' Object that groups many items
	' Label
	Private ColShape() As Label
	Private ColShapeBorder() As Label
	Private PalShapeBorder() As Label
	Private PalShape() As Label
	Private PalShapeDefaultLeft() As Integer
	Private PalShapeDefaultTop() As Integer
	Private PalShapeDefaultWidth() As Integer
	Private PalShapeDefaultHeight() As Integer
	'   NumericUpDown
	Private BGCHRUD() As NumericUpDown
	'   RadioButton
	Private BGDst() As RadioButton

	Private Sub Form_Initialize()
		' Object that groups many items
		' Label
		ColShapeBorder = New Label() {_ColShapeBorder_0, _ColShapeBorder_1, _ColShapeBorder_2, _ColShapeBorder_3}
		PalShapeBorder = New Label() {_PalShapeBorder_0, _PalShapeBorder_1, _PalShapeBorder_2, _PalShapeBorder_3}
		PalShape = New Label() {_PalShape_0, _PalShape_1, _PalShape_2, _PalShape_3, _PalShape_4, _PalShape_5, _PalShape_6, _PalShape_7, _PalShape_8, _PalShape_9, _PalShape_10, _PalShape_11, _PalShape_12, _PalShape_13, _PalShape_14, _PalShape_15}
		'   NumericUpDown
		BGCHRUD = New NumericUpDown() {_BGCHRUD_0, _BGCHRUD_1}
		' RadioButton
		BGDst = New RadioButton() {_BGDst_0, _BGDst_1}

		'Previous values that need to be stored
		DelayUD_ValuePrevious = DelayUD.Value
		FramesUD_ValuePrevious = FramesUD.Value
		CHRIDUD_ValuePrevious = CHRIDUD.Value
		BGCHRUD_ValuePrevious = {_BGCHRUD_0.Value, _BGCHRUD_1.Value}

		' This is for the highlight effect
		ColShape = New Label(ColShapeBorder.Length - 1) {}
		PalShapeDefaultLeft = New Integer(PalShape.Length - 1) {}
		PalShapeDefaultTop = New Integer(PalShape.Length - 1) {}
		PalShapeDefaultWidth = New Integer(PalShape.Length - 1) {}
		PalShapeDefaultHeight = New Integer(PalShape.Length - 1) {}
	End Sub

	Public Sub Manual_Init()
		Dim a As Integer

		RenderModule.PB_Init(pic1, tt_bmi)
		RenderModule.PB_Init(TilePic, edittile_bmi)

		For a = 0 To 63
			tilemem(a) = 0
		Next a
		curpal = 0
		curcol = 0

		'Labels on the form are only for the border color. Need to create label over all of those that will contain actual colors
		For a = 0 To ColShapeBorder.Length - 1
			ColShape(a) = New Label With {
				.Name = "_ColShape_" + CStr(a),
				.Left = ColShapeBorder(a).Left + borderSize,
				.Top = ColShapeBorder(a).Top + borderSize,
				.Width = ColShapeBorder(a).Width - (borderSize * 2),
				.Height = ColShapeBorder(a).Height - (borderSize * 2),
				.Visible = True
			}

			Me.Controls.Add(ColShape(a))
			ColShape(a).BringToFront()
		Next a

		For a = 0 To PalShape.Length - 1
			PalShapeDefaultLeft(a) = PalShape(a).Left
			PalShapeDefaultTop(a) = PalShape(a).Top
			PalShapeDefaultWidth(a) = PalShape(a).Width
			PalShapeDefaultHeight(a) = PalShape(a).Height
		Next a


		' Subscribe every control to MouseClick event
		SubscribeToMouseClickEventAndMouseMove(Me)

		Me.Width = BtnMoreOptions.Left + BtnMoreOptions.Width + 25
		initialFormWidth = Me.Width
		Me.Height = BtnMoreOptions.Top + BtnMoreOptions.Height + 50
		initialFormHeight = Me.Height
		BtnMoreOptions.Text = BtnMoreOptionsMoreOptionsString

		'CHR Animation
		If (gem = 2) And (scenemode = False) Then
			CHRAnimFrame.Visible = True
		End If
	End Sub

	Private Sub TileTable_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
		If (ActiveControl.Name = Text7.Name) Then Exit Sub

		Dim KeyCode As Short = eventArgs.KeyCode
		Dim Shift As Short = eventArgs.KeyData \ &H10000
		MFLE_Main.Global_KeyDown(KeyCode, Shift)
	End Sub

	Public Sub Update_Frm()
		Update_Level()
		UpdateEditTile()
		UpdateEditTilePals()
		Update_TileEd_CurCol()
		Update_TileEd_CurPal()
		CurTileLab.Text = "Tile: " + Hex((curtileY * 16) + curtileX)
	End Sub

	Public Sub Update_RefreshAllBitmaps()
		Update_Level() ' Needs to be done for Mega Man 5 when changing screen
		RenderModule.RenderPic(pic1, tt_bmi)
		RenderModule.RenderPic(TilePic, edittile_bmi)
	End Sub

	Public Sub Update_Level()
		Dim block, x, Y, stru, bpal As Integer
		Dim tileY, tileX As Integer
		Dim col(3) As Byte

		ShowHide()

		'Dim perftimeS, perftimeE, perftime

		'perftimeS = timeGetTime

		For Y = 0 To 15
			For x = 0 To 15

				block = 0
tiletbldfl:
				If romdat(arrayAdjuster + (offs(gem, 3) + 0) + block) = ((Y * 16) + x) Then stru = 0 : GoTo tiletbldfsl
				If romdat(arrayAdjuster + (offs(gem, 3) + &H100S) + block) = ((Y * 16) + x) Then stru = 0 : GoTo tiletbldfsl
				If romdat(arrayAdjuster + (offs(gem, 3) + &H200S) + block) = ((Y * 16) + x) Then stru = 0 : GoTo tiletbldfsl
				If romdat(arrayAdjuster + (offs(gem, 3) + &H300S) + block) = ((Y * 16) + x) Then stru = 0 : GoTo tiletbldfsl
				block += 1
				If Not block = 255 Then GoTo tiletbldfl
				block = 0
				GoTo tiletbldff
tiletbldfsl:
				If romdat(arrayAdjuster + offs(gem, 5) + (stru * 4) + 0) = block Then GoTo tiletbldff
				If romdat(arrayAdjuster + offs(gem, 5) + (stru * 4) + 1) = block Then GoTo tiletbldff
				If romdat(arrayAdjuster + offs(gem, 5) + (stru * 4) + 2) = block Then GoTo tiletbldff
				If romdat(arrayAdjuster + offs(gem, 5) + (stru * 4) + 3) = block Then GoTo tiletbldff
				stru += 1
				If Not stru = 255 Then GoTo tiletbldfsl
				block += 1
				If Not block = 255 Then GoTo tiletbldfl
				block = 0

tiletbldff:

				bpal = (Nibble(romdat(arrayAdjuster + offs(gem, 4) + block), 1) And &H3S)
				drawpalmap((Y * 16) + x) = bpal

				RenderModule.DrawTile(tt_bmi, chrmap((Y * 16) + x), bpal, (x * 16), (Y * 16), romdat, 2)
			Next x
		Next Y

		If GetCfg("tileed_grid") = 1 Then
			For tileY = 0 To 15
				For tileX = 0 To 15
					RenderModule.DrawLineH(tt_bmi, (tileX * 16), (tileX * 16) + 16, (tileY * 16), &H20S)
					RenderModule.DrawLineV(tt_bmi, (tileX * 16), (tileY * 16), (tileY * 16) + 16, &H20S)
				Next tileX
			Next tileY
		End If

		CurTile_DrawGfx()

		tt_bmi.bytesRGB_UpdatedSinceLastRender = True

		RenderModule.RenderPic(pic1, tt_bmi)

		If (gem = 0) Or (gem = 2) Then
			SetUDCool(BGCHRUD(0), Hex(romdat(arrayAdjuster + offs(gem, 25) + 0)), 2)
			SetUDCool(BGCHRUD(1), Hex(romdat(arrayAdjuster + offs(gem, 25) + 1)), 2)
		End If

		If gem = 2 Then Update_CHRanim()

		'DrawTile2 performance check
		'perftimeE = timeGetTime
		'perftime = (perftimeE - perftimeS)
		'MsgBox perftime
	End Sub

	Private Sub ShowHide()
		Dim showCHRAnimControls As Boolean
		If gem = 2 Then
			showCHRAnimControls = True
		Else
			showCHRAnimControls = False
		End If

		CHRAnimCtrlLab.Visible = showCHRAnimControls
		CHRAnimSS.Visible = showCHRAnimControls
		CHRAnimFrame.Visible = showCHRAnimControls
	End Sub

	Public Sub Update_BGPal(ByRef upd As Integer)
		If upd = 1 Then RenderModule.RenderPic(pic1, tt_bmi)
	End Sub

	Public Sub Update_Global_Pal()
		UpdateEditTilePals()
	End Sub

	Public Sub Update_TileRange(ByRef min As Integer, ByRef max As Integer)
		Dim col(3) As Byte
		Dim x, Y, bpal As Integer
		Dim tileY, tileX As Integer

		'CurTileROMPtr.Caption = "$" + Hex$(chrmap((curtileY * 16) + curtileX)) 'Should be done elsewhere too, ofcourse.

		For Y = 0 To 15
			For x = 0 To 15
				If ((Y * 16) + x) < min Or ((Y * 16) + x) > max Then GoTo nexttile

				'tilepal =

				'bpal = nibble(mid$(romdat, offs(gem, 4) + block, 1), 1)
				bpal = drawpalmap((Y * 16) + x)

				RenderModule.DrawTile(tt_bmi, chrmap((Y * 16) + x), bpal, (x * 16), (Y * 16), romdat, 2)
nexttile:
			Next x
		Next Y

		If GetCfg("tileed_grid") = 1 Then
			For tileY = 0 To 15
				For tileX = 0 To 15
					RenderModule.DrawLineH(tt_bmi, (tileX * 16), (tileX * 16) + 15, (tileY * 16), &H20S)
					RenderModule.DrawLineV(tt_bmi, (tileX * 16), (tileY * 16), (tileY * 16) + 15, &H20S)
				Next tileX
			Next tileY
		End If

		tt_bmi.bytesRGB_UpdatedSinceLastRender = True

		CurTile_DrawGfx()
		RenderModule.RenderPic(pic1, tt_bmi)
	End Sub

	Public Sub Update_CurTile()
		CurTileSet()
		RenderModule.RenderPic(pic1, tt_bmi)
	End Sub

	Private Sub Draw_Tile(ByRef Y As Integer, ByRef x As Integer)
		Dim col(3) As Byte
		Dim bpal As Integer

		'tilepal =

		'bpal = nibble(mid$(romdat, offs(gem, 4) + block, 1), 1)
		bpal = drawpalmap((Y * 16) + x)

		RenderModule.DrawTile(tt_bmi, chrmap((Y * 16) + x), bpal, (x * 16), (Y * 16), romdat, 2)

		tt_bmi.bytesRGB_UpdatedSinceLastRender = True
	End Sub
	Public Sub UpdateMetatileTableCurrentTile()
		If MetatileTable.Visible Then
			'in the stretchblt, the + 1 is there to get rid of the black line
			'Following instruction replace this: : MetatileTable.CurTilePic.Cls()
			MetatileTable.CurTilePic.Image = Nothing
			'Ancient instruction here was: StretchBlt(MetatileTable.CurTilePic.hdc, 0, 0, 32, 32, pic1.hdc, (curtileX * 16) + 1, (curtileY * 16) + 1, 16, 16, vbSrcCopy)

			Dim bmpSrc As Bitmap = pic1.Image
			Dim bmpDest As New Bitmap(MetatileTable.CurTilePic.Width, MetatileTable.CurTilePic.Height)
			Dim bmpExtracted As Bitmap

			bmpExtracted = RenderModule.ExtractRegionFromBitmap(bmpSrc, (curtileX * 16) + 1, 16, (curtileY * 16) + 1, 16)

			'Scaling
			bmpDest = New Bitmap(bmpExtracted, bmpDest.Width, bmpDest.Height)

			'Dim graphics As Graphics = MetatileTable.CurTilePic.CreateGraphics()
			'Dim TSATableCurTilePichdc As IntPtr = graphics.GetHdc()
			'Dim graphics2 As Graphics = pic1.CreateGraphics()
			'Dim pic1hdc As IntPtr = graphics.GetHdc()
			'StretchBlt(TSATableCurTilePichdc, 0, 0, 32, 32, pic1hdc, (curtileX * 16) + 1, (curtileY * 16) + 1, 16, 16, CopyPixelOperation.SourceCopy)
			'MetatileTable.CurTilePic.Refresh()
			'Graphics.ReleaseHdc(TSATableCurTilePichdc)
			'Graphics.ReleaseHdc(pic1hdc)



			MetatileTable.CurTilePic.Image = bmpDest
			MetatileTable.CurTilePic.Refresh()
		End If
	End Sub

	Private Sub CurTileSet()
		CurTile_DrawGfx()

		UpdateMetatileTableCurrentTile()

		CurTileLab.Text = "Tile: " + Hex((curtileY * 16) + curtileX)
	End Sub

	Private Sub CurTile_DrawGfx()
		If GetCfg("tileed_grid") = 1 Then
			RenderModule.DrawLineH(tt_bmi, (oldtileX * 16), (oldtileX * 16) + 16, (oldtileY * 16), &H20S)
			RenderModule.DrawLineV(tt_bmi, (oldtileX * 16), (oldtileY * 16), (oldtileY * 16) + 16, &H20S)
			RenderModule.DrawLineH(tt_bmi, (oldtileX * 16), (oldtileX * 16) + 16, (oldtileY * 16) + 16, &H20S)
			RenderModule.DrawLineV(tt_bmi, (oldtileX * 16) + 16, (oldtileY * 16), (oldtileY * 16) + 16, &H20S)
		Else
			Draw_Tile(oldtileY, oldtileX)
			If oldtileX < 15 Then
				Draw_Tile(oldtileY, oldtileX + 1)
			End If
			If oldtileY < 15 Then
				Draw_Tile(oldtileY + 1, oldtileX)
				If oldtileX < 15 Then
					Draw_Tile(oldtileY + 1, oldtileX + 1)
				End If
			End If

			RenderModule.DrawLineV(tt_bmi, 256, 0, 256, &H20S)
			RenderModule.DrawLineH(tt_bmi, 0, 255, 256, &H20S)
		End If

		Draw_CurTile_Marker()

		tt_bmi.bytesRGB_UpdatedSinceLastRender = True
	End Sub

	Private Sub UpdateEditTile()
		Dim Y, x As Integer

		For Y = 0 To 7
			For x = 0 To 7
				RenderModule.DrawRectangle(edittile_bmi, (x * 16) + 1, (Y * 16) + 1, (x * 16) + 16, (Y * 16) + 16, (curpal * 4) + tilemem((Y * 8) + x))
			Next x
		Next Y

		edittile_bmi.bytesRGB_UpdatedSinceLastRender = True
		RenderModule.RenderPic(TilePic, edittile_bmi)
	End Sub

	Private Sub UpdateEditTilePals()
		Dim a, b As Integer

		For a = 0 To ColShapeBorder.Length - 1
			ColShape(a).BackColor = ColorTranslator.FromOle(RGBmirr(glob_pal((curpal * 4) + a)))

			For b = 0 To 3
				PalShape((a * 4) + b).BackColor = ColorTranslator.FromOle(RGBmirr(glob_pal((a * 4) + b)))
			Next b
		Next a

	End Sub

	Private Sub Update_TileEd_CurCol()
		Dim a As Integer

		For a = 0 To ColShapeBorder.Length - 1
			If curcol = a Then
				ColShapeBorder(a).BackColor = Color.White
				ColShapeBorder(a).BringToFront()
				ColShape(a).BringToFront()
			Else
				ColShapeBorder(a).BackColor = Color.Black
			End If
		Next a
	End Sub

	Private Sub Update_TileEd_CurPal()
		Dim a, b, c, d As Integer

		contourLabel.BringToFront()

		For a = 0 To 3
			b = a * 4

			For c = 0 To 3
				d = b + c
				PalShape(d).Left = PalShapeDefaultLeft(d)
				PalShape(d).Top = PalShapeDefaultTop(d)
				PalShape(d).Width = PalShapeDefaultWidth(d)
				PalShape(d).Height = PalShapeDefaultHeight(d)


				If curpal = a Then
					PalShape(d).Top += (borderSize - 1)
					PalShape(d).Height -= borderSize
				End If

				If ((curpal - 1) = a) Then
					PalShape(d).Height -= (borderSize - 1)
				End If
				If ((curpal + 1) = a) Then
					PalShape(d).Height -= (borderSize - 1)
					PalShape(d).Top += (borderSize - 1)
				End If
			Next c

			If curpal = a Then
				PalShape(b).Left += (borderSize - 1)
				PalShape(b).Width -= (borderSize - 1)
				PalShape(b + 3).Width -= (borderSize - 1)

				PalShapeBorder(a).BringToFront()
			End If
		Next a

		' Those must always be on top of everything
		For a = 0 To (PalShape.Length - 1)
			PalShape(a).BringToFront()
		Next a
	End Sub

	Private Sub CopyBtn_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles CopyBtn.Click
		Dim l1, x, Y, l2 As Integer
		For Y = 0 To 7
			l1 = romdat(arrayAdjuster + chrmap((curtileY * 16) + curtileX) + Y + 1)
			l2 = romdat(arrayAdjuster + chrmap((curtileY * 16) + curtileX) + Y + 9)
			For x = 0 To 7
				tilemem((Y * 8) + x) = CShort((l1 And (2 ^ (7 - x))) > 0 And 1) + CShort((l2 And (2 ^ (7 - x))) > 0 And 1 * 2)
			Next x
		Next Y
		curpal = drawpalmap((curtileY * 16) + curtileX)
		UpdateEditTilePals()
		Update_TileEd_CurPal()
		UpdateEditTile()
	End Sub

	Private Sub TileTable_MouseClick(sender As Object, EventArgs As MouseEventArgs)
		Dim x As Single
		Dim Y As Single
		Dim a As Integer

		' x and y must be position WITHIN form
		If (sender.Name <> Me.Name) Then
			x = EventArgs.X + sender.Left
			Y = EventArgs.Y + sender.Top
		Else
			' When Form is the caller, Left and Top are position within current Screen
			x = EventArgs.X
			Y = EventArgs.Y
		End If

		For a = 0 To 3
			If (x >= ColShapeBorder(a).Left) And (x <= (ColShapeBorder(a).Left + ColShapeBorder(a).Width)) And (Y >= ColShapeBorder(a).Top) And (Y <= ColShapeBorder(a).Top + ColShapeBorder(a).Height) Then
				curcol = a
				Update_TileEd_CurCol()
			End If
			If (x >= PalShapeBorder(a).Left) And (x <= (PalShapeBorder(a).Left + PalShapeBorder(a).Width)) And (Y >= PalShapeBorder(a).Top) And (Y <= (PalShapeBorder(a).Top + PalShapeBorder(a).Height)) Then
				curpal = a
				Update_TileEd_CurPal()
				'UpdateEditTilePals()
				UpdateEditTile()
			End If
		Next a
	End Sub

	Private Sub TileTable_MouseMove(sender As Object, EventArgs As MouseEventArgs)
		Dim Button As Short = EventArgs.Button \ &H100000
		Dim X As Single = EventArgs.X
		Dim Y As Single = EventArgs.Y
		If Button > 0 Then
			TileTable_MouseClick(Me, New System.Windows.Forms.MouseEventArgs(Button * &H100000, 0, X, Y, 0))
		End If
	End Sub
	Private Sub SubscribeToMouseClickEventAndMouseMove(control As Control)
		AddHandler control.MouseClick, AddressOf TileTable_MouseClick
		AddHandler control.MouseMove, AddressOf TileTable_MouseMove

		For Each childControl As Control In control.Controls
			SubscribeToMouseClickEventAndMouseMove(childControl)
		Next
	End Sub

	Private Sub PasteBtn_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles PasteBtn.Click
		Dim l2, Y, x, l1, a As Integer
		Dim tb As Integer
		For Y = 0 To 7
			l1 = 0
			l2 = 0
			For x = 0 To 7
				a = tilemem((Y * 8) + x)
				l1 = l1 Or CShort(a And 1) * 2 ^ (7 - x)
				l2 = l2 Or (CShort(a And 2) / 2) * (2 ^ (7 - x))
			Next x
			romdat(arrayAdjuster + chrmap((curtileY * 16) + curtileX) + Y + 1) = l1
			romdat(arrayAdjuster + chrmap((curtileY * 16) + curtileX) + Y + 9) = l2
		Next Y
		tb = ((curtileY * 16) + curtileX)
		drawpalmap(tb) = curpal
		MFLE_Main.Update_TileRange(tb, tb)
	End Sub

	Private Sub Pic1_MouseDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles pic1.MouseDown
		Dim Button As Short = eventArgs.Button \ &H100000
		Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
		Dim x As Single = eventArgs.X
		Dim Y As Single = eventArgs.Y
		oldtileY = curtileY
		oldtileX = curtileX
		curtileY = VWidth(Int(Y / 16), 0, 15)
		curtileX = VWidth(Int(x / 16), 0, 15)
		CurTileSet()
		RenderModule.RenderPic(pic1, tt_bmi)
	End Sub

	Private Sub Pic1_MouseMove(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles pic1.MouseMove
		Dim Button As Short = eventArgs.Button \ &H100000
		Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
		Dim x As Single = eventArgs.X
		Dim Y As Single = eventArgs.Y
		Static tileY As Integer
		Static tileX As Integer
		If Button And 1 Then
			If Int(Y / 16) <> tileY Or Int(x / 16) <> tileX Then
				Pic1_MouseDown(pic1, New System.Windows.Forms.MouseEventArgs(Button * &H100000, 0, x, Y, 0))
			End If
		End If
		tileY = Int(Y / 16)
		tileX = Int(x / 16)
	End Sub

	Private Sub TilePic_MouseDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles TilePic.MouseDown
		Dim Button As Short = eventArgs.Button \ &H100000
		Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
		Dim x As Single = eventArgs.X
		Dim Y As Single = eventArgs.Y
		Dim px, py As Integer
		px = VWidth(Int((x - 1) / 16), 0, 7)
		py = VWidth(Int((Y - 1) / 16), 0, 7)
		If (Button And 1) = 1 Then
			tilemem((py * 8) + px) = curcol
			RenderModule.DrawRectangle(edittile_bmi, (px * 16) + 1, (py * 16) + 1, (px * 16) + 16, (py * 16) + 16, (curpal * 4) + tilemem((py * 8) + px))
			edittile_bmi.bytesRGB_UpdatedSinceLastRender = True
			RenderModule.RenderPic(TilePic, edittile_bmi)
		ElseIf (Button And 2) = 2 Then
			curcol = tilemem((py * 8) + px)
			Update_TileEd_CurCol()
		End If
	End Sub

	Private Sub TilePic_MouseMove(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles TilePic.MouseMove
		Dim Button As Short = eventArgs.Button \ &H100000
		Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
		Dim x As Single = eventArgs.X
		Dim Y As Single = eventArgs.Y
		If Button > 0 Then
			TilePic_MouseDown(TilePic, New System.Windows.Forms.MouseEventArgs(Button * &H100000, 0, x, Y, 0))
		End If
	End Sub

	Private Sub TRotaBtn_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles TRotaBtn.Click
		Dim x, a, Y As Integer
		Dim tmpbuff(63) As Integer

		For a = 0 To 63
			tmpbuff(a) = tilemem(a)
		Next a
		For Y = 0 To 7
			For x = 0 To 7
				tilemem((Y * 8) + x) = tmpbuff(Y + ((7 - x) * 8))
			Next x
		Next Y

		UpdateEditTile()
	End Sub

	Private Sub TShiftHBtn_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles TShiftHBtn.Click
		Dim tmpbuff(7) As Integer
		Dim Y, x As Integer

		For Y = 0 To 7
			For x = 0 To 7
				tmpbuff(x) = tilemem((Y * 8) + x)
			Next x
			For x = 0 To 7
				tilemem((Y * 8) + x) = tmpbuff(7 - x)
			Next x
		Next Y

		UpdateEditTile()
	End Sub

	Private Sub TShiftVBtn_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles TShiftVBtn.Click
		Dim tmpbuff(7) As Integer
		Dim Y, x As Integer

		For x = 0 To 7
			For Y = 0 To 7
				tmpbuff(Y) = tilemem((Y * 8) + x)
			Next Y
			For Y = 0 To 7
				tilemem((Y * 8) + x) = tmpbuff(7 - Y)
			Next Y
		Next x

		UpdateEditTile()
	End Sub

	Private Sub CHRAnimFrame_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles CHRAnimFrame.Click
		If CHR_Anim_Pause Then
			Dim id, idoff As Integer
			If CA_ID >= &H80S Then
				id = CA_ID And &H7FS
				idoff = romdat(arrayAdjuster + rdata(dspa(d_ex) + 17) + id)
				MFLE_Main.CHRAnim_Advance(idoff)
			End If
		End If
	End Sub

	Private Sub CHRAnimSS_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles CHRAnimSS.Click
		If CHR_Anim_Pause Then
			CHRAnimSS.Text = "Stop"
		Else
			CHRAnimSS.Text = "Start"
		End If
		CHR_Anim_Pause = Not CHR_Anim_Pause
	End Sub

	' All duplicated Tiles will be replaced by their first occurence
	Public Function ReplaceDuplicatedTiles() As Boolean
		If gem = 0 Or gem = 2 Then
			If MFLE_Decl.CHR_Anim_Pause = False Then
				MessageBox.Show("Stop CHR animation to perform this action on the frame you want to Purge (in Tile Editor).", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
				Return False
			End If
		End If

		Dim a, b, c, aMax As Integer
		Dim isDuplicate
		Dim tmp_tilesmapDuplicateStatus(&HFFS) As Byte
		Dim tmp_tilesmapID_OfIdenticalTile(&HFFS) As Byte

		aMax = (&HFFS - 1)

		' Clear arrays

		For a = 0 To &HFFS
			tmp_tilesmapDuplicateStatus(a) = 0 ' Not duplicated (clear status)
			tmp_tilesmapID_OfIdenticalTile(a) = 0 ' Not a copy of any Tile ID for now
		Next a

		' First, find Tiles that are duplicated

		' Loop on Tile that will be the referenced Tile (that others are a copy of)
		For a = 0 To aMax
			' Loop on every following Tile
			For b = (a + 1) To &HFFS
				' If current Tile checked is not already a copy of another Tile
				If tmp_tilesmapDuplicateStatus(b) = 0 Then
					' Suppose Tile is a duplicate and we will adjust if not
					isDuplicate = True
					' Loop on every Pixel of the Tile and compare it with the referenced Tile
					For c = 0 To &HFS
						' If current Tile checked has one pixel different from the base Tile
						If (romdat(arrayAdjuster + chrmap(b) + c + 1) <> romdat(arrayAdjuster + chrmap(a) + c + 1)) Then
							isDuplicate = False
							Exit For
						End If
					Next c

					If isDuplicate Then
						' If here, current Tile checked is identical to the one checked right now
						tmp_tilesmapDuplicateStatus(b) = 1
						tmp_tilesmapID_OfIdenticalTile(b) = a
					End If
				End If
			Next b
		Next a

		' Loop through all array entry and stop on Tiles that are duplicate
		For a = 0 To &HFFS
			If tmp_tilesmapDuplicateStatus(a) = 1 Then
				' A duplicate Tile! We don't clear it in current function, but we will make it unused
				'	So after this current function call, calling function that clear unused Tiles will clear them
				' So find everywhere current Tile is used (check every Metatiles)
				'	and, in those Metatiles, use instead, the Reference Tile we defined above
				' So loop through every Metatile
				For b = 0 To &HFFS
					' If current Tile is used
					If romdat(arrayAdjuster + offs(gem, o_tsatile) + b + 0) = a Then
						' Put the reference Tile instead
						romdat(arrayAdjuster + offs(gem, o_tsatile) + b + 0) = tmp_tilesmapID_OfIdenticalTile(a)
					End If
					' If current Tile is used
					If romdat(arrayAdjuster + offs(gem, o_tsatile) + b + &H100S) = a Then
						' Put the reference Tile instead
						romdat(arrayAdjuster + offs(gem, o_tsatile) + b + &H100S) = tmp_tilesmapID_OfIdenticalTile(a)
					End If
					' If current Tile is used
					If romdat(arrayAdjuster + offs(gem, o_tsatile) + b + &H200S) = a Then
						' Put the reference Tile instead
						romdat(arrayAdjuster + offs(gem, o_tsatile) + b + &H200S) = tmp_tilesmapID_OfIdenticalTile(a)
					End If
					' If current Tile is used
					If romdat(arrayAdjuster + offs(gem, o_tsatile) + b + &H300S) = a Then
						' Put the reference Tile instead
						romdat(arrayAdjuster + offs(gem, o_tsatile) + b + &H300S) = tmp_tilesmapID_OfIdenticalTile(a)
					End If
				Next b
			End If
		Next

		' We were able to execute current function since Tiles were not animated
		Return True
	End Function
	Public Function ClearUnusedTiles() As Boolean
		If gem = 0 Or gem = 2 Then
			If MFLE_Decl.CHR_Anim_Pause = False Then
				MessageBox.Show("Stop CHR animation to perform this action on the frame you want to Purge (in Tile Editor).", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
				Return False
			End If
		End If

		Dim a, b As Integer
		Dim tmp_tilesmap(&HFFS) As Byte

		' Clear arrays

		For a = 0 To &HFFS
			tmp_tilesmap(a) = 0 'Not used (clear status)
		Next a

		For a = 0 To &HFFS
			tmp_tilesmap(romdat(arrayAdjuster + offs(gem, o_tsatile) + a + 0)) = 1
			tmp_tilesmap(romdat(arrayAdjuster + offs(gem, o_tsatile) + a + &H100S)) = 1
			tmp_tilesmap(romdat(arrayAdjuster + offs(gem, o_tsatile) + a + &H200S)) = 1
			tmp_tilesmap(romdat(arrayAdjuster + offs(gem, o_tsatile) + a + &H300S)) = 1
		Next a

		For a = 0 To &HFFS
			If tmp_tilesmap(a) = 0 Then
				For b = 0 To &HFS
					romdat(arrayAdjuster + chrmap(a) + b + 1) = 0
				Next b
			End If
		Next a

		Return True
	End Function

	Private Sub BtnClearUnusedTiles_Click(sender As Object, e As EventArgs) Handles BtnClearUnusedTiles.Click
		If ClearUnusedTiles() Then
			If Me.Visible = True Then Me.Update_Level()
		End If
	End Sub

	Private Sub Draw_CurTile_Marker()
		RenderModule.DrawLineH(tt_bmi, (curtileX * 16), (curtileX * 16) + 16, (curtileY * 16), &H22S)
		RenderModule.DrawLineV(tt_bmi, (curtileX * 16), (curtileY * 16), (curtileY * 16) + 16, &H22S)
		RenderModule.DrawLineH(tt_bmi, (curtileX * 16), (curtileX * 16) + 16, (curtileY * 16) + 16, &H22S)
		RenderModule.DrawLineV(tt_bmi, (curtileX * 16) + 16, (curtileY * 16), (curtileY * 16) + 16, &H22S)
	End Sub

	Private Sub BtnShowSelected_Click(sender As Object, e As EventArgs) Handles BtnShowSelected.Click
		Dim x As Integer
		Dim colorByte As Byte() = {&H20S, &H22S, &H26S, &H20S, &H22S, &H26S, &H20S, &H22S, &H26S}

		For x = 0 To (colorByte.Length - 1)
			RenderModule.DrawRectangle(tt_bmi, (curtileX * 16), (curtileY * 16), (curtileX * 16) + 16, (curtileY * 16) + 16, colorByte(x))

			tt_bmi.palette_UpdatedSinceLastBytesRGB_Update = True

			RenderModule.RenderPicAlwaysIfItWasChangedSinceLastupdate(pic1, tt_bmi)

			Threading.Thread.Sleep(100)
		Next

		' Redraw tile as it was
		Draw_Tile(curtileY, curtileX)
		If curtileX < 15 Then
			Draw_Tile(curtileY, curtileX + 1)
		End If
		If curtileY < 15 Then
			Draw_Tile(curtileY + 1, curtileX)
			If curtileX < 15 Then
				Draw_Tile(curtileY + 1, curtileX + 1)
			End If
		End If

		Draw_CurTile_Marker()

		RenderModule.RenderPic(pic1, tt_bmi)
	End Sub

	Private Sub BtnClearDuplicated_Click(sender As Object, e As EventArgs) Handles BtnClearDuplicated.Click
		If ReplaceDuplicatedTiles() Then
			BtnClearUnusedTiles_Click(sender, e)
		End If
	End Sub

	Public Sub AdjustControlsVisibility()
		GbxChrExportAsHex.Visible = False
		GbxChrExtract.Visible = False
		GbxCHR_AnimEd.Visible = False
		GbxBG_CHR_Bank.Visible = False
		GbxForceCHR_Bank.Visible = False
		GbxForceCHR_Anim.Visible = False

		If (BtnMoreOptions.Text = BtnMoreOptionsLessOptionsString) Then
			GbxChrExportAsHex.Visible = True
			GbxChrExtract.Visible = True
			If (gem = 0 Or gem = 2) Then
				GbxForceCHR_Bank.Visible = True
				If (gem = 2 And (scenemode = False)) Then
					GbxCHR_AnimEd.Visible = True
					GbxForceCHR_Anim.Visible = True
				End If
			End If
			If (gem = 0 Or gem = 2) Then
				GbxBG_CHR_Bank.Visible = True
			End If
		End If
	End Sub

	Private Sub BtnMoreOptions_Click(sender As Object, e As EventArgs) Handles BtnMoreOptions.Click
		Dim widthForAdjustment As Integer = GbxChrExportAsHex.Width + 10

		If (BtnMoreOptions.Text = BtnMoreOptionsMoreOptionsString) Then
			If (gem = 2) Then
				widthForAdjustment += GbxCHR_AnimEd.Width + 10
			End If

			BtnMoreOptions.Text = BtnMoreOptionsLessOptionsString
			Me.Width = initialFormWidth + widthForAdjustment
			Me.Height = initialFormHeight + CATB.Height + 18
		Else
			BtnMoreOptions.Text = BtnMoreOptionsMoreOptionsString
			Me.Width = initialFormWidth
			Me.Height = initialFormHeight
		End If

		If (gem = 1 Or gem = 3) Then
			Me.Height = initialFormHeight
		End If

		AdjustControlsVisibility()
	End Sub

	Private Sub Text6_TextChanged(sender As Object, e As EventArgs) Handles Text6.TextChanged
		If Text6.Tag <> "" Then Exit Sub
		SetTBCoolNumWithValidation(Text6, Text6.Text, 65535, 4, True)
	End Sub

	Private Sub Text4_TextChanged(sender As Object, e As EventArgs) Handles Text4.TextChanged
		If Text4.Tag <> "" Then Exit Sub
		SetTBCoolNumWithValidation(Text4, Text4.Text, 65535, 4, True)
	End Sub

	Private Sub Text3_TextChanged(sender As Object, e As EventArgs) Handles Text3.TextChanged
		If Text3.Tag <> "" Then Exit Sub
		SetTBCoolNumWithValidation(Text3, Text3.Text, 65535, 4, True)
	End Sub

	Private Sub ExtractCHR(fileCHR As String, offset As Integer, firstTile As Integer, lastTile As Integer, Optional MME As Boolean = False)
		Dim errorOnDeletionOfExistingFile As Boolean = False
		Dim a, b As Integer
		Dim ba As Byte
		Dim PathBackup As String

		PathBackup = CurDir()

		Try
			If MME Then
				If IO.File.Exists(fileCHR) Then
					' Delete the file
					IO.File.Delete(fileCHR)
				End If
			End If
		Catch ex As Exception
			MessageBox.Show("File exists, couldn't access it.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
			Exit Sub
		End Try

		If (errorOnDeletionOfExistingFile = False) Then
			Try
				FileOpen(1, fileCHR, OpenMode.Binary)

				Try
					Seek(1, offset + 1)
					For a = firstTile To lastTile
						For b = 0 To 15
							ba = romdat(arrayAdjuster + chrmap(a) + 1 + b)
							FilePut(1, ba)
						Next b
					Next a
				Catch ex As Exception
					MessageBox.Show("Parameters are invalid.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
				End Try

				FileClose(1)
			Catch ex As Exception
				MessageBox.Show("Parameters are invalid - couldn't open file.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
			End Try
		End If

		ChDir(PathBackup)
	End Sub

	Private Sub DumpCHR(Optional MME As Boolean = False)
		Dim fileCHR1, fileCHR2 As String

		If MME Then
			Dim fileASM, fileASM_Text, PathBackup, tilesNames As String
			tilesNames = Text7.Text
			fileASM = Text7.Text + ".asm"

			fileCHR1 = Text7.Text + "__PART_1.chr"
			fileCHR2 = Text7.Text + "__PART_2.chr"
			ExtractCHR(fileCHR1, 0, 0, &H7FS, True)
			ExtractCHR(fileCHR2, 0, &H80S, &HFFS, True)

			fileASM_Text = ""
			fileASM_Text += "ChrBnk_TILESET__" + tilesNames + " = Cur_CHR_BANK" & vbCrLf & vbCrLf
			fileASM_Text += ".base $8000" & vbCrLf & vbCrLf & vbCrLf & vbCrLf
			fileASM_Text += "	INCBIN Mega_Man_Time_Tangent\CHR_BANKS\DATA\TILESETS\" + tilesNames + "__PART_1.chr" & vbCrLf & vbCrLf
			fileASM_Text += "PAD $8800, $EA" & vbCrLf & vbCrLf
			fileASM_Text += ";For the next 800 chr bytes" & vbCrLf
			fileASM_Text += "Cur_CHR_BANK			= #Cur_CHR_BANK + #$01" & vbCrLf
			fileASM_Text += "Cur_CHR_BANK			= #Cur_CHR_BANK + #$01" & vbCrLf
			fileASM_Text += vbCrLf & vbCrLf & vbCrLf
			fileASM_Text += "	INCBIN Mega_Man_Time_Tangent\CHR_BANKS\DATA\TILESETS\" + tilesNames + "__PART_2.chr" & vbCrLf & vbCrLf
			fileASM_Text += "PAD $9000, $EA" & vbCrLf & vbCrLf
			fileASM_Text += ";For the next 800 chr bytes" & vbCrLf
			fileASM_Text += "Cur_CHR_BANK			= #Cur_CHR_BANK + #$01" & vbCrLf
			fileASM_Text += "Cur_CHR_BANK			= #Cur_CHR_BANK + #$01"
			fileASM_Text = fileASM_Text.TrimEnd({ControlChars.Cr, ControlChars.Lf})

			PathBackup = CurDir()

			Try
				IO.File.WriteAllText(fileASM, fileASM_Text)
			Catch ex As Exception
				MessageBox.Show("Parameters are invalid - couldn't open file.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
			End Try

			ChDir(PathBackup)
		Else
			fileCHR1 = Text7.Text + ".chr"
			ExtractCHR(fileCHR1, Dec((Text6.Text)), Dec((Text3.Text)), Dec((Text4.Text)))
		End If
	End Sub

	Private Sub Command9_Click(sender As Object, e As EventArgs) Handles Command9.Click
		DumpCHR()
	End Sub

	' When a tile is updated, many stuff to Redraw
	Public Sub TileUpdate()
		Update_Level()

		If MetatileTable.Visible = True Then MetatileTable.Update_Level()
		If MetametatileTable.Visible = True Then MetametatileTable.Update_Level()
		If ScreenEd.Visible = True Then ScreenEd.Update_Frm()
		If EnemEd.Visible = True Then EnemEd.Update_Scrn()
		If SBDSpecial.Visible = True Then SBDSpecial.Update_Frm()
	End Sub

	Private Sub Command14_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Command14.Click
		Dim a, b As Integer
		Dim ba As Byte
		'Dim tstr As String * &H10
		Dim PathBackup As String
		Dim fileCHR1 As String = Text7.Text + ".chr"

		PathBackup = CurDir()
		Try
			FileOpen(1, fileCHR1, OpenMode.Binary)

			Try
				Seek(1, Dec((Text6.Text)) + 1)
				For a = Dec((Text3.Text)) To Dec((Text4.Text))
					For b = 0 To 15
						FileGet(1, ba)
						romdat(arrayAdjuster + chrmap(a) + 1 + b) = ba
					Next b
				Next a
			Catch ex As Exception
				MessageBox.Show("Parameters are invalid.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
			End Try

			FileClose(1)
		Catch ex As Exception
			MessageBox.Show("Parameters are invalid - couldn't open file.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
		End Try

		ChDir(PathBackup)

		' Update tiles everywhere
		TileUpdate()
	End Sub

	Private Sub BtnMME_Extract_Click(sender As Object, e As EventArgs) Handles BtnMME_Extract.Click
		DumpCHR(True)
	End Sub

	Private Sub Command11_Click(sender As Object, e As EventArgs) Handles Command11.Click
		Dim a As Integer
		Dim b As Integer
		Dim PathBackup As String
		PathBackup = CurDir()

		Try
			FileOpen(1, Text9.Text, OpenMode.Binary)

			Try
				For a = 0 To &H1FFS
					FileGet(1, b)
					chrmap(a) = b
				Next a
			Catch ex As Exception
				MessageBox.Show("Parameters are invalid.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
			End Try

			FileClose(1)
		Catch ex As Exception
			MessageBox.Show("Parameters are invalid - couldn't open file.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
		End Try


		Me.Update_TileRange(0, 255)

		ChDir(PathBackup)

		' Update tiles everywhere
		TileUpdate()
	End Sub

	Private Sub Command5_Click(sender As Object, e As EventArgs) Handles Command5.Click
		Dim a As Integer
		Dim b As Integer
		Dim PathBackup As String

		PathBackup = CurDir()

		Try
			FileOpen(1, Text9.Text, OpenMode.Binary)

			Try
				For a = 0 To &H1FFS
					b = chrmap(a)
					FilePut(1, b)
				Next a
			Catch ex As Exception
				MessageBox.Show("Parameters are invalid.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
			End Try

			FileClose(1)
		Catch ex As Exception
			MessageBox.Show("Parameters are invalid - couldn't open file.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
		End Try

		ChDir(PathBackup)
	End Sub

	Private Sub CATB_TextChanged(sender As Object, e As EventArgs) Handles CATB.TextChanged
		If CATB.Tag <> "" Then Exit Sub
		SetTBCoolNumWithValidation(CATB, CATB.Text, 255, 2, True)
	End Sub

	Private Sub Command7_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Command7.Click
		CA_ID = Dec((CATB.Text)) + &H80S
		CA_DelayC = 0
		CA_FrameN = 0
		CATB.Text = vbNullString
		CATB.Focus()

		' Update tiles everywhere
		TileUpdate()
	End Sub
	Private Sub Text8_TextChanged(sender As Object, e As EventArgs) Handles Text8.TextChanged
		If Text8.Tag <> "" Then Exit Sub
		SetTBCoolNumWithValidation(Text8, Text8.Text, 255, 2, True)
	End Sub


	Private Sub CHRIDUD_ActionUponNewValue()
		If CHRIDUD.Tag <> "" Then Exit Sub
		If CHRIDUD_ValuePrevious = CHRIDUD.Value Then Exit Sub

		CHRIDUD_ValuePrevious = CHRIDUD.Value

		Dim value As Integer
		value = Dec((CHRIDUD.Text))
		SetUDCool(CHRIDUD, Hex(value), 1)
		BGFrameSelect.Value = 0
		Update_CHRanim()
	End Sub

	Private Sub CHRIDUD_ValueChanged(sender As Object, e As EventArgs) Handles CHRIDUD.ValueChanged
		If UpdateUDCool(sender) Then
			' When here, Value was validated
			CHRIDUD_ActionUponNewValue()
		End If
	End Sub

	Private Sub CHRIDUD_KeyUp(sender As Object, e As KeyEventArgs) Handles CHRIDUD.KeyUp
		' Set new value (with validations)
		SetUDCool(CType(sender, NumericUpDown), sender.Text, 1)

		' When here, Value was validated
		CHRIDUD_ActionUponNewValue()
	End Sub

	Private Sub BGCHRUD_ActionUponNewValue(sender As Object)
		Dim Index As Short = 0

		For Each nuemricUpDown As NumericUpDown In BGCHRUD
			If nuemricUpDown.Name = sender.Name Then
				Exit For
			End If
			Index += 1
		Next

		If BGCHRUD(Index).Tag <> "" Then Exit Sub

		If BGCHRUD_ValuePrevious(Index) = BGCHRUD(Index).Value Then Exit Sub

		BGCHRUD_ValuePrevious(Index) = BGCHRUD(Index).Value

		romdat(arrayAdjuster + offs(gem, 25) + Index) = (Dec(BGCHRUD(Index).Text) And &HFFS)
		SetUDCool(BGCHRUD(Index), Hex(romdat(arrayAdjuster + offs(gem, 25) + Index)), 2)
		BGCHRUD_ActionUponNewValue(Index, BGCHRUD(Index).Text)
	End Sub

	Private Sub BGCHRUD_ValueChanged(sender As Object, e As EventArgs) Handles _BGCHRUD_1.ValueChanged, _BGCHRUD_0.ValueChanged
		If UpdateUDCool(sender) Then
			' When here, Value was validated
			BGCHRUD_ActionUponNewValue(sender)

			' Update tiles everywhere
			TileUpdate()
		End If
	End Sub

	Private Sub BGCHRUD_KeyUp(sender As Object, e As KeyEventArgs) Handles _BGCHRUD_1.KeyUp, _BGCHRUD_0.KeyUp
		' Set new value (with validations)
		SetUDCool(CType(sender, NumericUpDown), sender.Text, 2)

		' When here, Value was validated
		BGCHRUD_ActionUponNewValue(sender)
	End Sub

	Public Sub BGCHRUD_ActionUponNewValue(Index As Integer, textValue As String)
		If Index = 0 Then _Option1_0.Checked = True Else _Option1_1.Checked = True
		Text8.Text = (textValue)
		Command10_Click(Nothing, New System.EventArgs())
	End Sub

	Private Sub BGFrameSelect_Scroll(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.ScrollEventArgs) Handles BGFrameSelect.Scroll
		Select Case eventArgs.Type
			Case System.Windows.Forms.ScrollEventType.EndScroll
				BGFrameSelect_Change(eventArgs.NewValue)
		End Select
	End Sub

	Private Sub BGSrcTB_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles BGSrcTB.TextChanged
		If BGSrcTB.Tag <> "" Then Exit Sub
		SetTBCoolNumWithValidation(BGSrcTB, BGSrcTB.Text, 255, 2, True)
		romdat(arrayAdjuster + rdata(dspa(d_ex) + 18) + 3 + chranimoff + BGFrameSelect.Value) = Dec(BGSrcTB.Text)
	End Sub

	Private Sub BGDst_CheckedChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles _BGDst_1.CheckedChanged, _BGDst_0.CheckedChanged
		If eventSender.Checked Then
			Dim value As Short = 0

			For Each radioButton As RadioButton In BGDst
				If radioButton.Name = eventSender.Name Then
					Exit For
				End If
				value += 1
			Next

			romdat(arrayAdjuster + rdata(dspa(d_ex) + 18) + 2 + chranimoff) = Int(value)
		End If
	End Sub

	Public Sub Update_CHRanim()
		Dim value As Integer
		chranimoff = (romdat(arrayAdjuster + rdata(dspa(d_ex) + 17) + CDbl(CHRIDUD.Text)))
		SetUDCool(DelayUD, Hex(romdat(arrayAdjuster + rdata(dspa(d_ex) + 18) + 1 + chranimoff)), 2)
		SetUDCool(FramesUD, CStr(romdat(arrayAdjuster + rdata(dspa(d_ex) + 18) + 0 + chranimoff)), 2)
		SetTBCoolText(BGSrcTB, Hex(romdat(arrayAdjuster + rdata(dspa(d_ex) + 18) + 3 + chranimoff)))
		value = romdat(arrayAdjuster + rdata(dspa(d_ex) + 18) + 2 + chranimoff) And 1

		'This is called before BGDst is initialized
		If Not (BGDst Is Nothing) Then
			SetOptCool(BGDst(value), True)
		End If
		'Me.BGDst.SetIndex(_BGDst_1, CType(1, Short))
		'Me.BGDst.SetIndex(_BGDst_0, CType(0, Short))
		'SetOptCool(BGDst(value), True)
		BGFrameSelect.Maximum = (FramesUD.Text + BGFrameSelect.LargeChange - 1)
	End Sub
	Private Sub BGFrameSelect_Change(ByVal newScrollValue As Integer)
		SetTBCoolText(BGSrcTB, Hex(romdat(arrayAdjuster + rdata(dspa(d_ex) + 18) + 3 + chranimoff + newScrollValue)))
	End Sub

	Public Sub Command10_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Command10.Click
		Dim chrbankoffs As Integer
		Dim t As Integer
		If (gem = 0) Or (gem = 2) Then
			chrbankoffs = Dec((Text8.Text))
			chrbankoffs *= &H400S

			For t = 0 To 127
				'if gem = 0 Then chrmap(t + 256) = offs(gem, o_chroffs) + (t * 16)
				If _Option1_0.Checked = True Then
					chrmap(t) = offs(gem, o_chroffs) + chrbankoffs + (t * &H10S)
				Else
					chrmap(t + 128) = offs(gem, o_chroffs) + chrbankoffs + (t * &H10S)
				End If
			Next t
		End If

		Me.Update_TileRange(0, 255)
		Text8.Text = vbNullString

		' Update tiles everywhere
		TileUpdate()
	End Sub
	Private Sub DelayUD_ActionUponNewValue()
		If DelayUD.Tag <> "" Then Exit Sub
		If DelayUD_ValuePrevious = DelayUD.Value Then Exit Sub

		DelayUD_ValuePrevious = DelayUD.Value

		romdat(arrayAdjuster + rdata(dspa(d_ex) + 18) + 1 + chranimoff) = (Dec((DelayUD.Text)) And &HFFS Or &H0S)
		SetUDCool(DelayUD, Hex(romdat(arrayAdjuster + rdata(dspa(d_ex) + 18) + 1 + chranimoff)), 2)
	End Sub

	Private Sub DelayUD_ValueChanged(sender As Object, e As EventArgs) Handles DelayUD.ValueChanged
		If UpdateUDCool(sender) Then
			' When here, Value was validated
			DelayUD_ActionUponNewValue()
		End If
	End Sub

	Private Sub DelayUD_KeyUp(sender As Object, e As KeyEventArgs) Handles DelayUD.KeyUp
		' Set new value (with validations)
		SetUDCool(CType(sender, NumericUpDown), sender.Text, 2)

		' When here, Value was validated
		DelayUD_ActionUponNewValue()
	End Sub
	Private Sub FramesUD_ActionUponNewValue()
		If FramesUD.Tag <> "" Then Exit Sub
		If FramesUD_ValuePrevious = FramesUD.Value Then Exit Sub

		FramesUD_ValuePrevious = FramesUD.Value

		romdat(arrayAdjuster + rdata(dspa(d_ex) + 18) + 1) = (Dec((FramesUD.Text)) And &HFFS Or &H0S)
		SetUDCool(FramesUD, Hex(romdat(arrayAdjuster + rdata(dspa(d_ex) + 18) + 1)), 2)
	End Sub

	Private Sub FramesUD_ValueChanged(sender As Object, e As EventArgs) Handles FramesUD.ValueChanged
		If UpdateUDCool(sender) Then
			' When here, Value was validated
			FramesUD_ActionUponNewValue()
		End If
	End Sub
	Private Sub FramesUD_KeyUp(sender As Object, e As KeyEventArgs) Handles FramesUD.KeyUp
		' Set new value (with validations)
		SetUDCool(CType(sender, NumericUpDown), sender.Text, 2)

		' When here, Value was validated
		FramesUD_ActionUponNewValue()
	End Sub

	Private Sub TileTable_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
		e.Cancel = True

		Me.Hide()
	End Sub
End Class