Option Explicit On
Friend Class DoorEd
    Inherits System.Windows.Forms.Form

    Private Const arraySize As Integer = 3
    Private Const GridLineXSize As Integer = 15
    Private Const GridLineYSize As Integer = 14

    Public currentTsa As Integer
    Public whatToMove As Integer

    Public doorPoint As Integer
    Public relScreen As Integer

    'Objects that group many items
    '   Button
    Private PalBtn() As Button
    '   Picture Box
    Private TSAPic() As PictureBox
    '   RadioButton
    Private DoorPointOpt() As RadioButton
    Private TSASelect() As RadioButton
    Private NTBase() As RadioButton
    Private WTMOpt() As RadioButton

    Private Sub Form_Initialize()
        'Objects that group many items
        '   Button
        PalBtn = New Button() {_PalBtn_0, _PalBtn_1, _PalBtn_2, _PalBtn_3}
        '   Picture Box
        TSAPic = New PictureBox() {
            _TSAPic_0,
            _TSAPic_1,
            _TSAPic_2,
            _TSAPic_3,
            _TSAPic_4,
            _TSAPic_5,
            _TSAPic_6,
            _TSAPic_7
        }
        '   RadioButton
        DoorPointOpt = New RadioButton() {_DoorPointOpt_0, _DoorPointOpt_1}
        TSASelect = New RadioButton() {_TSASelect_0, _TSASelect_1, _TSASelect_2, _TSASelect_3, _TSASelect_4, _TSASelect_5, _TSASelect_6, _TSASelect_7}
        NTBase = New RadioButton() {_NTBase_0, _NTBase_1, _NTBase_2, _NTBase_3}
        WTMOpt = New RadioButton() {_WTMOpt_0, _WTMOpt_1}

        ' Subscribe every control to MouseClick event
        SubscribeToMouseClickEventAndMouseMove(Me)
    End Sub

#Region "Functions"
    Public Sub Manual_Init()
        Dim Y, X As Integer
        Dim PicBGShapeArea As Integer = PicBGShape.Width * PicBGShape.Height
        Dim BGShapeBITMAPINFO As New BITMAPINFO()

        ' By default all palettes will be black - will only set the one we want
        BGShapeBITMAPINFO.Initialize()
        BGShapeBITMAPINFO.RedimPixelBytes(PicBGShapeArea)
        RenderModule.PB_Init(PicBGShape, BGShapeBITMAPINFO)
        ' Only need to have grey in palette 1 (pal(0) is likely black and will be if needed since all pixel
        ' are already having palette value 0)
        BGShapeBITMAPINFO.pal(1) = Color.Gray.ToArgb()

        For Y = 0 To (GridLineYSize)
            RenderModule.DrawLineH(BGShapeBITMAPINFO,
                                 0,
                                 PicBGShape.Width - 1,
                                 16 * Y,
                                 1
                                 )
        Next Y

        For X = 0 To (GridLineXSize)
            RenderModule.DrawLineV(BGShapeBITMAPINFO,
                                 16 * X,
                                 0,
                                 PicBGShape.Height - 1,
                                 1
                                 )
        Next X

        BGShapeBITMAPINFO.palette_UpdatedSinceLastBytesRGB_Update = True
        BGShapeBITMAPINFO.bytesRGB_UpdatedSinceLastRender = True
        RenderModule.RenderPicAlwaysIfItWasChangedSinceLastupdate(PicBGShape, BGShapeBITMAPINFO)

        If gem = 2 Then
            TSAPic(3).Visible = False
            TSAPic(5).Visible = False
            TSAPic(6).Visible = False
            TSAPic(7).Visible = False
            TSASelect(3).Visible = False
            TSASelect(5).Visible = False
            TSASelect(6).Visible = False
            TSASelect(7).Visible = False

            OpenShape.Height = 16 * 3 - 1
            CloseShape.Height = 16 * 3 - 1

            PaletteFrame.Visible = False ' MM5 uses Palette property directly from TSA data.
        End If

        If Not gem = 0 Then
            MM3Frame1.Visible = False
            MM3Frame2.Visible = False
        End If
    End Sub
    Public Sub MoveDoorPosition()
        Dim nt_addressTO, nt_addressTC As Integer
        Dim preset As Integer
        Dim a As Integer

        Select Case gem
            Case 0
                preset = GetMM3preset()
                nt_addressTO = Word(romdat(arrayAdjuster + rdata(dspa(d_ex) + dex_mm3DoorOpenT) + preset + 0), romdat(arrayAdjuster + rdata(dspa(d_ex) + dex_mm3DoorOpenT) + preset + 1))
                SetShapes_FromNT(nt_addressTO, 0)
                nt_addressTC = Word(romdat(arrayAdjuster + rdata(dspa(d_ex) + dex_mm3DoorCloseT) + preset + 0), romdat(arrayAdjuster + rdata(dspa(d_ex) + dex_mm3DoorCloseT) + preset + 1))
                SetShapes_FromNT(nt_addressTC, 1)
            Case 1
                nt_addressTO = Word(romdat(arrayAdjuster + offs(gem, o_door1) + 0), romdat(arrayAdjuster + offs(gem, o_door1) + 1))
                SetShapes_FromNT(nt_addressTO, 0)
                nt_addressTC = Word(romdat(arrayAdjuster + offs(gem, o_door2) + 0), romdat(arrayAdjuster + offs(gem, o_door2) + 1))
                SetShapes_FromNT(nt_addressTC, 1)
            Case 2
                a = rdata(dspa(d_ex) + dex_mm5DoorOpen) + (level * 8)
                nt_addressTO = (romdat(arrayAdjuster + a) * &H100S) + romdat(arrayAdjuster + a + 1)
                SetShapes_FromNT(nt_addressTO, 0)
                a = rdata(dspa(d_ex) + dex_mm5DoorClose) + (level * 5)
                nt_addressTC = (romdat(arrayAdjuster + a) * &H100S) + romdat(arrayAdjuster + a + 1)
                SetShapes_FromNT(nt_addressTC, 1)
        End Select
    End Sub

    Public Sub Update_Frm()
        MoveDoorPosition()
        UpdateTSAs()
        SetOptCool(TSASelect(currentTsa), True)
        UpdateCurrentTSAstats()
        SetOptCool(WTMOpt(whatToMove), True)

        If scenemode = True Then Me.Text = dummy & "door Editor"

        Dim dpscreen As Integer
        Dim preset As Single
        If gem = 0 Then
            SetOptCool(DoorPointOpt(doorPoint), True)

            If doorPoint = 0 Then
                dpscreen = romdat(arrayAdjuster + offs(gem, o_door1))
            Else
                dpscreen = romdat(arrayAdjuster + offs(gem, o_door2))
            End If
            SetTBCoolNumWithValidation(DPScreenTB, Hex(dpscreen), &HFFS, 2, True)

            preset = (GetMM3preset() / 6)
            SetTBCoolNumWithValidation(PresetTB, Hex(preset), &HFFS, 2, True)
        End If
    End Sub

    Private Sub UpdateTSAs()
        Dim tmp_bmi(7) As BITMAPINFO

        Dim a, b As Integer
        Dim tilenum, Y, tileY, tsa, tileX, x, pal As Integer

        For a = 0 To 7
            If (gem = 2) Then
                If (a = 3) Or (a > 4) Then
                    GoTo Next_
                End If
            End If
            RenderModule.PB_Init(TSAPic(a), tmp_bmi(a))

            'stepVar = GetStep(a)

            'tilepal = nibble(romdat(arrayAdjuster + offs(gem, 4) + blocknum), 1)

            tsa = GetTsa(a)

            pal = GetPal(a, tsa)

            tmp_bmi(a).pal = New Integer(arraySize) {}

            For b = 0 To arraySize
                tmp_bmi(a).pal(b) = NESPAL(romdat(arrayAdjuster + offs(gem, o_pal) + 0 + (pal * 4) + b))
            Next b
            'tmp_bmi(a).pal(0) = 0
            'tmp_bmi(a).pal(1) = RGB(255, 255, 255)
            'tmp_bmi(a).pal(2) = RGB(150, 150, 150)
            'tmp_bmi(a).pal(3) = RGB(75, 75, 75)

            tmp_bmi(a).palette_UpdatedSinceLastBytesRGB_Update = True

            For tileY = 0 To 1
                For tileX = 0 To 1
                    tilenum = romdat(arrayAdjuster + offs(gem, 3) + (((tileY * 2) + tileX) * &H100S) + tsa)
                    Y = (tileY * 16)
                    x = (tileX * 16)
                    RenderModule.DrawTile(tmp_bmi(a), chrmap(tilenum), 0, x, Y, romdat, 2)
                Next tileX
            Next tileY

            tmp_bmi(a).bytesRGB_UpdatedSinceLastRender = True
            RenderModule.RenderPicAlwaysIfItWasChangedSinceLastupdate(TSAPic(a), tmp_bmi(a))
            TSAPic(a).Refresh()
Next_:
        Next a

    End Sub

    Private Sub UpdateCurrentTSAstats()
        Dim valu As Integer

        valu = GetTsa(currentTsa)
        SetTBCoolText(TsaIdText, Hex(valu))

        If (gem = 1) Or (gem = 0) Then
            valu = GetPal(currentTsa)
            SetTBCoolText(TsaPalText, Hex(valu))
        End If
    End Sub

    Private Function GetStep(ByRef a As Integer) As Integer
        If (a >= 4) Then
            If gem = 2 Then
                GetStep = 0
            Else
                GetStep = a And 3
            End If
        Else
            If gem = 2 Then
                GetStep = 2 - CShort(a And 3)
            Else
                GetStep = 3 - CShort(a And 3)
            End If
        End If
    End Function

    Private Sub SetShapes_FromNT(ByRef address As Integer, ByRef openOrClose As Integer)
        Dim Y, a, x As Integer
        a = address And &H3FFS
        Y = (a / &H40S)
        If openOrClose = 0 Then
            If gem = 2 Then
                Y -= 2
            Else
                Y -= 3
            End If
        End If
        x = CShort(a And &H1ES) / 2
        If openOrClose = 0 Then
            OpenShape.Left = PicBGShape.Left + (x * 16) + 1
            OpenShape.Top = PicBGShape.Top + (Y * 16) + 1
        Else
            CloseShape.Left = PicBGShape.Left + (x * 16) + 1
            CloseShape.Top = PicBGShape.Top + (Y * 16) + 1
        End If
    End Sub

    Private Function CreateNT(ByRef x As Integer, ByRef Y As Integer) As Integer
        CreateNT = (Y * &H40S) + (x * 2)
    End Function

    Private Function CreateQuad(ByRef x As Integer, ByRef Y As Integer) As Integer
        CreateQuad = ((CShort(Y And &HFES) / 2) * 8) Or (CShort(x And &HFES) / 2)
    End Function

    Private Function CreateBeginInQuad(ByRef x As Integer, ByRef Y As Integer) As Integer
        CreateBeginInQuad = (CShort(Y And 1) * 2) + CShort(x And 1)
    End Function

    Private Sub SetNewDoorLocation(ByRef x As Integer, ByRef Y As Integer)
        Dim a As Integer
        Dim quadByte, nt_base, nt, new_nt, beginInQuad As Integer
        Dim palCache(3) As Integer

        Dim nta, preset, ata As Integer
        Select Case gem
            Case 0

                preset = GetMM3preset()

                If whatToMove = 0 Then
                    Y += 3
                    nta = rdata(dspa(d_ex) + dex_mm3DoorOpenT) + preset
                    ata = rdata(dspa(d_ex) + dex_mm3DoorOpenA) + preset
                    palCache(0) = GetPal(0)
                    palCache(1) = GetPal(1)
                    palCache(2) = GetPal(2)
                    palCache(3) = GetPal(3)
                Else
                    nta = rdata(dspa(d_ex) + dex_mm3DoorCloseT) + preset
                    ata = rdata(dspa(d_ex) + dex_mm3DoorCloseA) + preset
                    palCache(0) = GetPal(4)
                    palCache(1) = GetPal(5)
                    palCache(2) = GetPal(6)
                    palCache(3) = GetPal(7)
                End If
                nt_base = Word(romdat(arrayAdjuster + nta), romdat(arrayAdjuster + nta + 1)) And &HFC00S
                new_nt = CreateNT(x, Y) Or nt_base
                beginInQuad = CreateBeginInQuad(x, Y)
                quadByte = CreateQuad(x, Y)
                If whatToMove = 1 Then
                    new_nt += 1
                End If
                romdat(arrayAdjuster + nta + 0) = Int(new_nt / &H100S)
                romdat(arrayAdjuster + nta + 1) = new_nt And &HFFS
                romdat(arrayAdjuster + ata + 0) = quadByte
                romdat(arrayAdjuster + ata + 1) = beginInQuad
                If whatToMove = 0 Then
                    SetPal(0, palCache(0))
                    SetPal(1, palCache(1))
                    SetPal(2, palCache(2))
                    SetPal(3, palCache(3))
                Else
                    SetPal(4, palCache(0))
                    SetPal(5, palCache(1))
                    SetPal(6, palCache(2))
                    SetPal(7, palCache(3))
                End If
            Case 1
                If whatToMove = 0 Then
                    Y += 3
                    a = offs(gem, o_door1)
                    palCache(0) = GetPal(0)
                    palCache(1) = GetPal(1)
                    palCache(2) = GetPal(2)
                    palCache(3) = GetPal(3)
                Else
                    a = offs(gem, o_door2)
                    palCache(0) = GetPal(4)
                    palCache(1) = GetPal(5)
                    palCache(2) = GetPal(6)
                    palCache(3) = GetPal(7)
                End If
                nt = (romdat(arrayAdjuster + a) * &H100S) + romdat(arrayAdjuster + a + 1)
                nt_base = (nt And &HFC00S)
                new_nt = CreateNT(x, Y) Or nt_base
                quadByte = CreateQuad(x, Y)
                beginInQuad = CreateBeginInQuad(x, Y)
                If (whatToMove = 1) Then
                    new_nt += 1
                End If
                romdat(arrayAdjuster + a) = Int(new_nt / &H100S)
                romdat(arrayAdjuster + a + 1) = new_nt And &HFFS
                romdat(arrayAdjuster + a + 6) = quadByte
                romdat(arrayAdjuster + a + 7) = beginInQuad
                If whatToMove = 0 Then
                    SetPal(0, palCache(0))
                    SetPal(1, palCache(1))
                    SetPal(2, palCache(2))
                    SetPal(3, palCache(3))
                Else
                    SetPal(4, palCache(0))
                    SetPal(5, palCache(1))
                    SetPal(6, palCache(2))
                    SetPal(7, palCache(3))
                End If
            Case 2
                If whatToMove = 0 Then
                    Y += 2
                    a = rdata(dspa(d_ex) + dex_mm5DoorOpen) + (level * 8)
                Else
                    a = rdata(dspa(d_ex) + dex_mm5DoorClose) + (level * 5)
                End If
                nt = (romdat(arrayAdjuster + a) * &H100S) + romdat(arrayAdjuster + a + 1)
                nt_base = (nt And &HFC00S)
                new_nt = CreateNT(x, Y) Or nt_base
                If (whatToMove = 1) Then
                    new_nt += 1
                End If
                romdat(arrayAdjuster + a) = Int(new_nt / &H100S)
                romdat(arrayAdjuster + a + 1) = new_nt And &HFFS
                quadByte = CreateQuad(x, Y)
                beginInQuad = CreateBeginInQuad(x, Y)
                romdat(arrayAdjuster + a + 2) = quadByte
                romdat(arrayAdjuster + a + 3) = beginInQuad

        End Select

        MoveDoorPosition()
    End Sub

    Private Function GetTsa(ByRef a As Integer) As Integer
        Dim closingValue, preset As Integer
        GetTsa = 0

        If (a >= 4) Then
            closingValue = True
        Else
            closingValue = False
        End If
        Dim stepValue As Integer

        stepValue = GetStep(a)

        Select Case gem
            Case 0
                preset = GetMM3preset()
                If (closingValue = False) Then
                    GetTsa = romdat(arrayAdjuster + rdata(dspa(d_ex) + dex_mm3DoorOpenT) + preset + 2 + stepValue)
                Else
                    GetTsa = romdat(arrayAdjuster + rdata(dspa(d_ex) + dex_mm3DoorCloseT) + preset + 2 + stepValue)

                End If
            Case 1
                If (closingValue = False) Then
                    GetTsa = romdat(arrayAdjuster + offs(gem, o_door1) + stepValue + 2)
                Else
                    GetTsa = romdat(arrayAdjuster + offs(gem, o_door2) + stepValue + 2)
                End If
            Case 2
                If (closingValue = False) Then
                    GetTsa = romdat(arrayAdjuster + rdata(dspa(d_ex) + dex_mm5DoorOpen) + (level * 8) + 4 + stepValue)
                Else
                    GetTsa = romdat(arrayAdjuster + rdata(dspa(d_ex) + dex_mm5DoorClose) + (level * 5) + 4)
                End If
        End Select
    End Function

    Private Sub SetTsa(ByRef a As Integer, ByRef newv As Integer)
        Dim closingValue As Integer
        If (a >= 4) Then
            closingValue = True
        Else
            closingValue = False
        End If

        Dim stepValue As Integer

        stepValue = GetStep(a)


        Dim preset As Integer
        Select Case gem
            Case 0
                preset = GetMM3preset()
                If (closingValue = False) Then
                    romdat(arrayAdjuster + rdata(dspa(d_ex) + dex_mm3DoorOpenT) + preset + 2 + stepValue) = newv
                Else
                    romdat(arrayAdjuster + rdata(dspa(d_ex) + dex_mm3DoorCloseT) + preset + 2 + stepValue) = newv
                End If
            Case 1
                If (closingValue = False) Then
                    romdat(arrayAdjuster + offs(gem, o_door1) + stepValue + 2) = newv
                Else
                    romdat(arrayAdjuster + offs(gem, o_door2) + stepValue + 2) = newv
                End If
            Case 2
                If (closingValue = False) Then
                    romdat(arrayAdjuster + rdata(dspa(d_ex) + dex_mm5DoorOpen) + (level * 8) + 4 + stepValue) = newv
                Else
                    romdat(arrayAdjuster + rdata(dspa(d_ex) + dex_mm5DoorClose) + (level * 5) + 4) = newv
                End If
        End Select
    End Sub

    Private Sub SetPal(ByRef Index As Integer, ByRef valu As Integer)
        Dim palSubQuad, stepValue, newPal As Integer

        stepValue = GetStep(Index)
        Dim preset, base As Integer
        Select Case gem
            Case 0
                preset = GetMM3preset()
                If (Index < 4) Then
                    base = rdata(dspa(d_ex) + dex_mm3DoorOpenA) + preset
                Else
                    base = rdata(dspa(d_ex) + dex_mm3DoorCloseA) + preset
                End If
                palSubQuad = romdat(arrayAdjuster + base + 1)
                palSubQuad = palSubQuad Xor (CShort(stepValue And 1) * 2)
                newPal = valu * (4 ^ palSubQuad)
                romdat(arrayAdjuster + base + 2 + stepValue) = newPal

            Case 1
                If (Index < 4) Then
                    palSubQuad = romdat(arrayAdjuster + offs(gem, o_door1) + 7)
                Else
                    palSubQuad = romdat(arrayAdjuster + offs(gem, o_door2) + 7)
                End If
                palSubQuad = palSubQuad Xor (CShort(stepValue And 1) * 2)
                newPal = valu * (4 ^ palSubQuad)
                If (Index < 4) Then
                    romdat(arrayAdjuster + offs(gem, o_door1) + 8 + stepValue) = newPal
                Else
                    romdat(arrayAdjuster + offs(gem, o_door2) + 8 + stepValue) = newPal
                End If
        End Select
    End Sub

    Private Function GetPal(ByRef Index As Integer, Optional ByRef tsaId As Integer = 0) As Integer
        Dim preset, stepValue, base As Integer
        Dim palByte, palSubQuad As Integer

        stepValue = GetStep(Index)
        GetPal = 0
        Select Case gem
            Case 0
                preset = GetMM3preset()
                If (Index < 4) Then
                    base = rdata(dspa(d_ex) + dex_mm3DoorOpenA) + preset
                    palByte = romdat(arrayAdjuster + base + 2 + stepValue)
                    palSubQuad = romdat(arrayAdjuster + base + 1)
                Else
                    base = rdata(dspa(d_ex) + dex_mm3DoorCloseA) + preset
                    palByte = romdat(arrayAdjuster + base + 2 + stepValue)
                    palSubQuad = romdat(arrayAdjuster + base + 1)
                End If
                palSubQuad = palSubQuad Xor (CShort(stepValue And 1) * 2)
                If (palSubQuad = 0) Then
                    GetPal = palByte And 3
                Else
                    GetPal = Int(palByte / (4 ^ palSubQuad))
                End If
            Case 1
                If (Index < 4) Then
                    palByte = romdat(arrayAdjuster + offs(gem, o_door1) + 8 + stepValue)
                    palSubQuad = romdat(arrayAdjuster + offs(gem, o_door1) + 7)
                Else
                    palByte = romdat(arrayAdjuster + offs(gem, o_door2) + 8 + stepValue)
                    palSubQuad = romdat(arrayAdjuster + offs(gem, o_door2) + 7)
                End If
                palSubQuad = palSubQuad Xor (CShort(stepValue And 1) * 2)
                If (palSubQuad = 0) Then
                    GetPal = palByte And 3
                Else
                    GetPal = Int(palByte / (4 ^ palSubQuad))
                End If
            Case 2
                GetPal = Nibble(romdat(arrayAdjuster + offs(gem, 4) + tsaId), 1)
        End Select

    End Function

    Private Function GetMM3preset() As Integer
        If (doorPoint = 0) Then
            GetMM3preset = romdat(arrayAdjuster + offs(gem, o_door1) + 1 + relScreen)
        Else
            GetMM3preset = romdat(arrayAdjuster + offs(gem, o_door2) + 1 + relScreen)
        End If
    End Function
#End Region

#Region "Events"
    Private Sub DoorEd_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        Dim KeyCode As Short = eventArgs.KeyCode
        Dim Shift As Short = eventArgs.KeyData \ &H10000
        MFLE_Main.Global_KeyDown(KeyCode, Shift)
    End Sub

    Private Sub DPScreenTB_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles DPScreenTB.TextChanged
        If DPScreenTB.Tag <> "" Then Exit Sub

        SetTBCoolNumWithValidation(DPScreenTB, DPScreenTB.Text, &HFFS, 2, True)

        Dim dpscreen As Integer
        dpscreen = Dec(DPScreenTB.Text) And &HFFS
        If doorPoint = 0 Then
            romdat(arrayAdjuster + offs(gem, o_door1)) = dpscreen
        Else
            romdat(arrayAdjuster + offs(gem, o_door2)) = dpscreen
        End If
        Update_Frm()
    End Sub

    Private Sub Control_MouseClick(sender As Object, EventArgs As MouseEventArgs)
        Dim x, y As Integer
        Dim realX, realY As Integer
        Dim reallyRealX, reallyRealY As Integer

        ' x and y must be position WITHIN form
        If (sender.Name <> Me.Name) Then
            x = EventArgs.X + sender.Left
            y = EventArgs.Y + sender.Top
        Else
            ' When Form is the caller, Left and Top are position within current Screen
            x = EventArgs.X
            y = EventArgs.Y
        End If


        If (x >= PicBGShape.Left) And (x < PicBGShape.Left + PicBGShape.Width) And (y >= PicBGShape.Top) And (y < (PicBGShape.Top + PicBGShape.Height)) Then
            realX = x - PicBGShape.Left
            realY = y - PicBGShape.Top
            reallyRealX = Int(realX / 16)
            reallyRealY = Int(realY / 16)

            SetNewDoorLocation(reallyRealX, reallyRealY)
        End If
    End Sub

    Private Sub Control_MouseMove(sender As Object, EventArgs As MouseEventArgs)
        Dim Button As Short = EventArgs.Button \ &H100000

        If Button Then Control_MouseClick(sender, EventArgs)
    End Sub

    Private Sub SubscribeToMouseClickEventAndMouseMove(control As Control)
        AddHandler control.MouseClick, AddressOf Control_MouseClick
        AddHandler control.MouseMove, AddressOf Control_MouseMove

        For Each childControl As Control In control.Controls
            SubscribeToMouseClickEventAndMouseMove(childControl)
        Next
    End Sub

    Private Sub PresetTB_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles PresetTB.TextChanged
        If PresetTB.Tag <> "" Then Exit Sub

        SetTBCoolNumWithValidation(PresetTB, PresetTB.Text, &HFFS / 6, 2, True)

        Dim realPreset As Integer
        Dim preset As Single
        preset = (GetMM3preset() / 6)
        If (Int(preset) = preset) Then
            realPreset = (Dec((PresetTB.Text)) * 6) And &HFFS
        Else
            realPreset = 0
        End If
        If (doorPoint = 0) Then
            romdat(arrayAdjuster + offs(gem, o_door1) + 1 + relScreen) = realPreset
        Else
            romdat(arrayAdjuster + offs(gem, o_door2) + 1 + relScreen) = realPreset
        End If
        Update_Frm()
    End Sub

    Private Sub ScreenScroll_Change(ByVal newScrollValue As Integer)
        relScreen = newScrollValue
        Update_Frm()
    End Sub

    Private Sub SetToCurTsa_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles SetToCurTsa.Click
        SetTsa(currentTsa, MegaFLEX_Main.CalcTSA)
        UpdateCurrentTSAstats()
        UpdateTSAs()
    End Sub

    Private Sub TsaIdText_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles TsaIdText.TextChanged
        If TsaIdText.Tag <> "" Then Exit Sub
        SetTBCoolNumWithValidation(TsaIdText, TsaIdText.Text, &HFFS, 2, True)
        SetTsa(currentTsa, Dec(TsaIdText.Text))
        UpdateCurrentTSAstats()
        UpdateTSAs()
    End Sub

    Private Sub TsaPalText_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles TsaPalText.TextChanged
        If TsaPalText.Tag <> "" Then Exit Sub
        SetTBCoolNumWithValidation(TsaPalText, TsaPalText.Text, 3, 1, True)
        SetPal(currentTsa, Dec(TsaPalText.Text))
        UpdateTSAs()
        UpdateCurrentTSAstats()
    End Sub

    Private Sub TSASelect_CheckedChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles _TSASelect_7.CheckedChanged, _TSASelect_6.CheckedChanged, _TSASelect_5.CheckedChanged, _TSASelect_4.CheckedChanged, _TSASelect_3.CheckedChanged, _TSASelect_2.CheckedChanged, _TSASelect_1.CheckedChanged, _TSASelect_0.CheckedChanged
        If eventSender.Checked Then
            Dim Index As Short = 0

            For Each radioButton As RadioButton In TSASelect
                If radioButton.Name = eventSender.Name Then
                    Exit For
                End If
                Index += 1
            Next


            currentTsa = Index
            UpdateCurrentTSAstats()
        End If
    End Sub

    Private Sub WTMOpt_CheckedChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles _WTMOpt_1.CheckedChanged, _WTMOpt_0.CheckedChanged
        If eventSender.Checked Then
            Dim Index As Short = 0

            For Each radioButton As RadioButton In WTMOpt
                If radioButton.Name = eventSender.Name Then
                    Exit For
                End If
                Index += 1
            Next

            If WTMOpt(Index).Tag <> "" Then Exit Sub
            whatToMove = Index
        End If
    End Sub

    Private Sub DoorPointOpt_CheckedChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles _DoorPointOpt_1.CheckedChanged, _DoorPointOpt_0.CheckedChanged
        If eventSender.Checked Then
            Dim Index As Short = 0

            For Each radioButton As RadioButton In DoorPointOpt
                If radioButton.Name = eventSender.Name Then
                    Exit For
                End If
                Index += 1
            Next
            doorPoint = Index
            Update_Frm()
        End If
    End Sub
    Private Sub ScreenScroll_Scroll(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.ScrollEventArgs) Handles ScreenScroll.Scroll
        Select Case eventArgs.Type
            Case System.Windows.Forms.ScrollEventType.EndScroll
                ScreenScroll_Change(eventArgs.NewValue)
        End Select
    End Sub

    Private Sub PalBtn_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles _PalBtn_3.Click, _PalBtn_2.Click, _PalBtn_1.Click, _PalBtn_0.Click
        Dim Index As Short = 0

        For Each button As Button In PalBtn
            If button.Name = eventSender.Name Then
                Exit For
            End If
            Index += 1
        Next

        SetPal(currentTsa, CInt(Index))
        UpdateTSAs()
        UpdateCurrentTSAstats()
    End Sub

    Private Sub DoorEd_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        e.Cancel = True

        Me.Hide()
    End Sub
#End Region

#Region "WasALreadyCommented"
    'Private Sub UpdateNTBase()
    'Dim nt, nt_address, preset, a
    'Select Case gem
    'Case 0
    '    preset = getMM3preset()
    '     nt_address = Word(romdat(arrayAdjuster + rdata(dspa(d_ex) + dex_mm3DoorOpenT) + preset + 0), _
    ''                 romdat(arrayAdjuster + rdata(dspa(d_ex) + dex_mm3DoorOpenT) + preset + 1))
    'Case 1
    '    nt_address = (romdat(arrayAdjuster + offs(gem, o_door1) + 0) * &H100) + _
    ''                    romdat(arrayAdjuster + offs(gem, o_door1) + 1)
    'Case 2
    '    a = rdata(dspa(d_ex) + dex_mm5DoorOpen) + (level * 8)
    '    nt_address = (romdat(arrayAdjuster + a) * &H100) + romdat(arrayAdjuster + a + 1)
    'End Select
    'nt = (nt_address And &HC00) / &H400
    'SetOptCool NTBase(nt), True
    'End Sub
#End Region
End Class