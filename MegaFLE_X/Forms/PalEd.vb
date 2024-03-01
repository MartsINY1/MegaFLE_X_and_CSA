Option Explicit On

Friend Class PalEd
    Inherits System.Windows.Forms.Form

    'Objects that group many items
    '   CheckBox
    Private EffSw() As CheckBox
    '   NumericUpDown
    Private EffUD() As NumericUpDown
    '   PictureBox
    Private PAColPic() As PictureBox
    '   RadioButton
    Private PalSetOpt() As RadioButton
    '   TextBox
    Private ColTB() As TextBox
    Private AColTB() As TextBox
    Private PAColTB() As TextBox

    Private PrevSprTB_TextChanged_FirstCall As Boolean = True
    Private curcol As Integer
    Private palanimoff As Integer

    Private previewSprite As Integer

    Private PalSetUD_ValuePrevious As Integer
    Private PieceUD_ValuePrevious As Integer
    Private DelayUD_ValuePrevious As Integer
    Private FramesUD_ValuePrevious As Integer
    Private DstColUD_ValuePrevious As Integer
    Private PAIDUD_ValuePrevious As Integer
    Private EffUD_ValuePrevious() As Integer

    Private Sub Form_Initialize()
        'Objects that group many items
        '   CheckBox
        EffSw = New CheckBox() {_EffSw_0, _EffSw_1, _EffSw_2, _EffSw_3}
        '   NumericUpDown
        EffUD = New NumericUpDown() {_EffUD_0, _EffUD_1, _EffUD_2, _EffUD_3}
        '   PictureBox
        PAColPic = New PictureBox() {_PAColPic_0, _PAColPic_1, _PAColPic_2}
        '   RadioButton
        PalSetOpt = New RadioButton() {_PalSetOpt_0, _PalSetOpt_1}
        '   TextBox
        ColTB = New TextBox() {_ColTB_0, _ColTB_1, _ColTB_2, _ColTB_3, _ColTB_4, _ColTB_5,
                               _ColTB_6, _ColTB_7, _ColTB_8, _ColTB_9, _ColTB_10, _ColTB_11,
                               _ColTB_12, _ColTB_13, _ColTB_14, _ColTB_15}
        AColTB = New TextBox() {_AColTB_0, _AColTB_1, _AColTB_2, _AColTB_3, _AColTB_4, _AColTB_5,
                               _AColTB_6, _AColTB_7, _AColTB_8, _AColTB_9, _AColTB_10, _AColTB_11,
                               _AColTB_12, _AColTB_13, _AColTB_14, _AColTB_15}
        PAColTB = New TextBox() {_PAColTB_0, _PAColTB_1, _PAColTB_2}

        'Previous values that need to be stored
        PalSetUD_ValuePrevious = PalSetUD.Value
        PieceUD_ValuePrevious = PieceUD.Value
        DelayUD_ValuePrevious = DelayUD.Value
        FramesUD_ValuePrevious = FramesUD.Value
        DstColUD_ValuePrevious = DstColUD.Value
        PAIDUD_ValuePrevious = PAIDUD.Value
        EffUD_ValuePrevious = {_EffUD_0.Value, _EffUD_1.Value, _EffUD_2.Value, _EffUD_3.Value}
    End Sub

    'One-time initialize at program-driven point
    Public Sub Manual_Init()
        RenderModule.PB_Init(PalPic, pal_bmi)
        RenderModule.PB_Init(PalPic2, pal2_bmi)

        previewSprite = 1

        If MFLE_Main.Check2.CheckState = False Then
            PalSetUD.Maximum = offs(gem, 18)
        Else
            PalSetUD.Maximum = &HFFS
        End If

        If gem = 3 Then
            Label3.Visible = True
            Text5.Visible = True
            Command6.Visible = True
        End If
    End Sub

    Private Sub PalEd_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        If palchartClaim = Palchart_Claim.PalEd Then
            PalChart.Close()
        End If

        e.Cancel = True

        Me.Hide()
    End Sub

    Overloads Sub Update()
        'Called when opening window
        Dim a, x As Integer

        If gem = 3 Then
            PalSetChangeFrame.Visible = False
            tabPalWeapon.Visible = False
        End If

        If (gem = 0) Then
            DstColLab.Visible = True
            DstColUD.Visible = True
        End If

        Dim LoopMe As Byte
        If (gem = 0) Then LoopMe = 11
        If (gem = 1) Then LoopMe = 13
        If (gem = 2) Then LoopMe = 12
        WeaponList.Items.Clear()
        For a = 0 To LoopMe
            WeaponList.Items.Add(SrcString(rdata(dspa(d_weaponname3 + gem) + a)))
        Next a
        SetComboCool(WeaponList, 0)

        For x = 0 To 15
            'Draw all colors within Palette's Squares - Leave Black Borders untouched
            RenderModule.DrawRectangle(pal_bmi, (x * 32) + 2, 2, (x * 32) + 31, 31, x + &H50S)
            RenderModule.DrawRectangle(pal2_bmi, (x * 32) + 2, 2, (x * 32) + 31, 31, x)
            RenderModule.DrawLineH(pal2_bmi, (x * 32), (x * 32) + 33, 0, &H20S)
            RenderModule.DrawLineH(pal2_bmi, (x * 32), (x * 32) + 33, 1, &H20S)
            RenderModule.DrawLineH(pal2_bmi, (x * 32), (x * 32) + 33, 32, &H20S)
            RenderModule.DrawLineH(pal2_bmi, (x * 32), (x * 32) + 33, 33, &H20S)
            RenderModule.DrawLineV(pal2_bmi, (x * 32), 2, 31, &H20S)
            RenderModule.DrawLineV(pal2_bmi, (x * 32) + 1, 2, 31, &H20S)
            RenderModule.DrawLineV(pal2_bmi, (x * 32) + 32, 2, 31, &H20S)
            RenderModule.DrawLineV(pal2_bmi, (x * 32) + 33, 2, 31, &H20S)
        Next x

        pal_bmi.bytesRGB_UpdatedSinceLastRender = True
        pal2_bmi.bytesRGB_UpdatedSinceLastRender = True

        Update_Global_Pal() 'setup active color TB's.
        CurColSet()
        Update_Level()
        Update_PalSet()
        If tabPalWeapon.SelectedIndex = 0 Then
            Update_PalAnim()
        End If

        UpdatePChangeType()

    End Sub

    Private Sub UpdatePChangeType()
        Dim EnableManual, EnableOptions As Boolean
        If scenemode = True Then
            SetOptCool(PalSetOpt(1), True)
            EnableManual = True
            EnableOptions = False
        Else
            SetOptCool(PalSetOpt(palsetChangeType), True)
            If (palsetChangeType = 0) Then
                EnableManual = False
            Else
                EnableManual = True
            End If
            EnableOptions = True
        End If
        PalSetUD.Enabled = EnableManual
        PalSetOpt(0).Enabled = EnableOptions
        PalSetOpt(1).Enabled = EnableOptions
    End Sub

    Public Sub Update_RefreshAllBitmaps()
        RenderModule.RenderPic(PalPic, pal_bmi)
        RenderModule.RenderPic(PalPic2, pal2_bmi)
    End Sub

    Public Sub Update_Level()
        Dim setEffVis As Integer
        Dim a As Integer
        If (scenemode = True) Or (gem = 3) Then
            setEffVis = False
        Else
            setEffVis = True
        End If

        _EddLab_0.Visible = setEffVis
        _EddLab_1.Visible = setEffVis
        _EddLab_2.Visible = setEffVis
        _EddLab_3.Visible = setEffVis
        For a = 0 To 3
            EffSw(a).Visible = setEffVis
            EffUD(a).Visible = setEffVis
        Next a

        UpdatePChangeType()

    End Sub

    Public Sub Update_PalSet()
        Dim a As Integer
        Dim bitmap As Bitmap = CType(PalPic.Image, Bitmap)
        bitmap.GetPixel(0, 0)

        RenderModule.RenderPic(PalPic, pal_bmi)
        RenderModule.RenderPic(PalPic2, pal2_bmi)

        bitmap.GetPixel(0, 0)

        For a = 0 To 15
            If gem = 3 Then
                SetTBCoolText(ColTB(a), Hex(MFLE_Main.GetMM6Col(a)))
            Else
                SetTBCoolText(ColTB(a), Hex(romdat(arrayAdjuster + offs(gem, o_pal) + (palset * palsetWidth) + a)))
            End If
        Next a

        EffSw(0).Tag = "=)"
        For a = 0 To 3
            EffSw(a).CheckState = CShort(romdat(arrayAdjuster + offs(gem, o_pal) + (palset * palsetWidth) + &H10S + a) And &H80S) / &H80S
            SetUDCool(EffUD(a), Hex(romdat(arrayAdjuster + offs(gem, o_pal) + (palset * palsetWidth) + &H10S + a) And &H7FS), 2)
        Next a
        EffSw(0).Tag = ""

        SetUDCool_PalSetUD(PalSetUD, Hex(palset))

    End Sub

    Public Sub Update_BGPal()
        'Dim x
        'If upd Then
        '    MFX_Render.RenderPic PalPic, pal_bmi
        '    MFX_Render.RenderPic PalPic2, pal2_bmi
        'End If
        'For x = 0 To 15
        '    SetTBCoolText ColTB(x), hex$(Asc(mid$(romdat, offs(gem, o_pal) + (palset * palsetWidth) + x, 1)))
        'Next x
        'EffSw(0).Tag = "=)"
        'For x = 0 To 3
        'EffSw(x).Value = (Asc(mid$(romdat, offs(gem, o_pal) + (palset * palsetWidth) + &H10 + x, 1)) And &H80) / &H80
        'SetTBCoolText EffTB(x), hex$(Asc(mid$(romdat, offs(gem, o_pal) + (palset * palsetWidth) + &H10 + x, 1)) And &H7F)
        'Next x
        'EffSw(0).Tag = ""

        'MFX_Render.RenderPic PalPic, pal_bmi
        'MFX_Render.RenderPic PalPic2, pal2_bmi
        Update_PalSet()
    End Sub

    Public Sub Update_Global_Pal()
        Dim a As Integer
        For a = 0 To 15
            SetTBCoolText(AColTB(a), Hex(PPU_palette_val(a)))
        Next a
    End Sub

    Public Sub Update_PalAnim()
        Dim idoLo, idoHi As Integer
        If gem = 3 Then Exit Sub
        SetUDCool(PAIDUD, Hex(curpalanim), 2)
        Select Case gem
            Case 0
                palanimoff = offs(gem, 54) + romdat(arrayAdjuster + offs(gem, 53) + curpalanim)
            Case 1
                idoLo = romdat(arrayAdjuster + offs(gem, 53) + curpalanim)
                idoHi = romdat(arrayAdjuster + offs(gem, 54) + curpalanim)
                palanimoff = (((idoHi - &HA0S) + offs(gem, 55)) * &H100S) + idoLo + &H11S
            Case 2
                palanimoff = offs(gem, 54) + romdat(arrayAdjuster + offs(gem, 53) + curpalanim)
        End Select

        SetUDCool(DelayUD, Hex(romdat(arrayAdjuster + palanimoff + 1)), 2) 'delay tb
        SetUDCool(FramesUD, Hex(romdat(arrayAdjuster + palanimoff)), 2)
        SetUDCool(DstColUD, Hex(romdat(arrayAdjuster + palanimoff + 2)), 2) 'MM3 only
        FrameSelect.Maximum = (romdat(arrayAdjuster + palanimoff) + FrameSelect.LargeChange - 1)
        FrameSelect.Value = curpalanimframe
        If (Me.Visible = True) And (FrameSelect.Visible = True) Then
            Me.Activate() '< Fixes weird blinking
            FrameSelect.Focus() 'horizontal scroll >
        End If
        curpalanimframe = 0
        SetPAFrame()
    End Sub

    Private Sub PalEd_Activated(sender As Object, e As EventArgs) Handles MyBase.Activated
        If palchartClaim = Palchart_Claim.PalEd Then MFLE_Decl.PalChartToFront = True
    End Sub

    Private Sub SetPAFrame()
        Dim a, framepalptr As Integer
        If gem > 0 Then
            SetUDCool(PieceUD, Hex(romdat(arrayAdjuster + palanimoff + 2 + curpalanimframe)), 2)
            framepalptr = (romdat(arrayAdjuster + palanimoff + 2 + curpalanimframe) * 3)
        Else
            SetUDCool(PieceUD, Hex(romdat(arrayAdjuster + palanimoff + 3 + curpalanimframe)), 2)
            framepalptr = (romdat(arrayAdjuster + palanimoff + 3 + curpalanimframe) * 3)
        End If
        For a = 0 To (PAColPic.Length - 1)
            PAColPic(a).BackColor = System.Drawing.ColorTranslator.FromOle(RGBmirr(NESPAL(romdat(arrayAdjuster + offs(gem, 56) + framepalptr + a))))
            SetTBCoolText(PAColTB(a), Hex(romdat(arrayAdjuster + offs(gem, 56) + framepalptr + a)))
        Next a
    End Sub

    Private Sub CurColSet()
        Dim x As Integer

        'Recolor every Square around Colors to black (draw one pixel line at the time)
        For x = 0 To 15
            RenderModule.DrawLineH(pal_bmi, (x * 32), (x * 32) + 33, 0, &H20S)
            RenderModule.DrawLineH(pal_bmi, (x * 32), (x * 32) + 33, 1, &H20S)
            RenderModule.DrawLineH(pal_bmi, (x * 32), (x * 32) + 33, 32, &H20S)
            RenderModule.DrawLineH(pal_bmi, (x * 32), (x * 32) + 33, 33, &H20S)
            RenderModule.DrawLineV(pal_bmi, (x * 32), 2, 31, &H20S)
            RenderModule.DrawLineV(pal_bmi, (x * 32) + 1, 2, 31, &H20S)
            RenderModule.DrawLineV(pal_bmi, (x * 32) + 32, 2, 31, &H20S)
            RenderModule.DrawLineV(pal_bmi, (x * 32) + 33, 2, 31, &H20S)
        Next x

        'Color the Square around Selected Color to white (draw one pixel line at the time)
        RenderModule.DrawLineH(pal_bmi, (curcol * 32), (curcol * 32) + 33, 0, &H22S)
        RenderModule.DrawLineH(pal_bmi, (curcol * 32), (curcol * 32) + 33, 1, &H22S)
        RenderModule.DrawLineH(pal_bmi, (curcol * 32), (curcol * 32) + 33, 32, &H22S)
        RenderModule.DrawLineH(pal_bmi, (curcol * 32), (curcol * 32) + 33, 33, &H22S)
        RenderModule.DrawLineV(pal_bmi, (curcol * 32), 2, 31, &H22S)
        RenderModule.DrawLineV(pal_bmi, (curcol * 32) + 1, 2, 31, &H22S)
        RenderModule.DrawLineV(pal_bmi, (curcol * 32) + 32, 2, 31, &H22S)
        RenderModule.DrawLineV(pal_bmi, (curcol * 32) + 33, 2, 31, &H22S)

        pal_bmi.bytesRGB_UpdatedSinceLastRender = True
    End Sub

    Private Sub ColTB_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles _ColTB_9.TextChanged, _ColTB_8.TextChanged, _ColTB_7.TextChanged, _ColTB_6.TextChanged, _ColTB_5.TextChanged, _ColTB_4.TextChanged, _ColTB_3.TextChanged, _ColTB_2.TextChanged, _ColTB_15.TextChanged, _ColTB_14.TextChanged, _ColTB_13.TextChanged, _ColTB_12.TextChanged, _ColTB_11.TextChanged, _ColTB_10.TextChanged, _ColTB_1.TextChanged, _ColTB_0.TextChanged
        Dim Index As Short = 0

        For Each textBox As TextBox In ColTB
            If textBox.Name = eventSender.Name Then
                Exit For
            End If
            Index += 1
        Next

        If ColTB(Index).Tag <> "" Then Exit Sub

        ' Set it with function so rounding is done always the same way for every controls
        SetTBCoolNumWithValidation(ColTB(Index), ColTB(Index).Text, 63, 2, True)

        If gem = 3 Then
            MFLE_Main.SetMM6Col(Index, (Dec(ColTB(Index).Text) And &H3FS))
        Else
            romdat(arrayAdjuster + offs(gem, o_pal) + (palset * palsetWidth) + Index) = (Dec(ColTB(Index).Text) And &H3FS)
        End If
        SetColMumboJumbo(CInt(Index))
    End Sub

    Private Sub PalEd_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        Dim KeyCode As Short = eventArgs.KeyCode
        Dim Shift As Short = eventArgs.KeyData \ &H10000
        MFLE_Main.Global_KeyDown(KeyCode, Shift)
    End Sub

    Public Sub PCEvent()
        If gem = 3 Then
            MFLE_Main.SetMM6Col(curcol, palchart_col)
        Else
            romdat(arrayAdjuster + offs(gem, o_pal) + (palset * palsetWidth) + curcol) = palchart_col
        End If
        SetColMumboJumbo(curcol) 'Think its right.
    End Sub

    Private Sub FrameSelect_Change(ByVal newScrollValue As Integer)
        curpalanimframe = newScrollValue
        SetPAFrame()
    End Sub

    Private Sub FixPAPointers(ByRef newframes As Integer)
        Dim b, a, c, e As Integer
        Dim frbal As Single
        Dim piecedatend_pt As Integer
        Dim piecedatend_rom As Integer

        'Though simple change, complex procedure

        Select Case gem
            Case 0
                frbal = newframes - romdat(arrayAdjuster + palanimoff) 'Balance
                If frbal = 0 Then Exit Sub ':)

                b = 0
                For a = 0 To offs(gem, o_maxpa)
                    c = romdat(arrayAdjuster + offs(gem, o_paoffs) + a)
                    If (c <= offs(gem, o_paspace)) And (c > b) Then
                        b = c
                    End If
                Next a

                a = romdat(arrayAdjuster + offs(gem, o_padata) + b + 0)
                piecedatend_pt = (b + 3 + a)
                piecedatend_rom = offs(gem, o_padata) + (b + 3 + a)
                If frbal > (offs(gem, o_paspace) - piecedatend_pt) Then MsgBox("Not enough unused space, Kill some frames off other animations!") : Exit Sub

                For a = 0 To offs(gem, o_maxpa)
                    b = romdat(arrayAdjuster + offs(gem, o_paoffs) + a)
                    If ((b + offs(gem, o_padata)) > palanimoff) And (b <= offs(gem, o_paspace)) Then
                        romdat(arrayAdjuster + offs(gem, o_paoffs) + a) = VWidth(b + frbal, 0, &HFFS)
                    End If
                Next a

                c = romdat(arrayAdjuster + palanimoff)
                If frbal > 0 Then 'push or pull?
                    For a = 0 To (piecedatend_rom - (palanimoff + 3 + c)) '((piecedatend_rom - (palanimoff + 3 + c)) + Asc(mid$(romdat, palanimoff, 1)) - 1)
                        romdat(arrayAdjuster + (piecedatend_rom + frbal) - a) = romdat(arrayAdjuster + piecedatend_rom - a)
                    Next a

                    For a = 0 To (frbal - 1)
                        romdat(arrayAdjuster + palanimoff + 4 + c + a) = 1
                    Next a
                Else
                    b = (frbal - frbal) - frbal
                    For a = 0 To (piecedatend_rom - (palanimoff + 3 + c)) - 1
                        romdat(arrayAdjuster + (palanimoff + 3 + c) + a) = romdat(arrayAdjuster + (palanimoff + 3 + c) + a + b)
                    Next a
                End If

            Case 1
                frbal = newframes - romdat(arrayAdjuster + palanimoff) 'Balance
                If frbal = 0 Then Exit Sub ':)

                b = 0
                For a = 0 To offs(gem, o_maxpa)
                    e = romdat(arrayAdjuster + offs(gem, o_paoffs4H) + a)
                    c = (e * 256) + romdat(arrayAdjuster + offs(gem, o_paoffs4L) + a)
                    If (c < offs(gem, o_pa4end)) And (c > b) Then b = c
                Next a

                a = romdat(arrayAdjuster + b - (rdata(dspa(d_ex) + 19) * &H100S) + (offs(gem, o_paoffs4A) * &H100S) + &H11S)
                piecedatend_pt = (b + 2 + a) ' + (offs(gem, o_paoffs4A) * &H100)
                piecedatend_rom = (b + 2 + a) - (rdata(dspa(d_ex) + 19) * &H100S) + (offs(gem, o_paoffs4A) * &H100S) + &H11S
                If frbal > (offs(gem, o_pa4end) - piecedatend_pt - 1) Then MsgBox("Not enough unused space, Kill some frames off other animations!") : Exit Sub

                For a = 0 To offs(gem, o_maxpa)
                    b = romdat(arrayAdjuster + offs(gem, o_paoffs4H) + a)
                    c = (b - rdata(dspa(d_ex) + 19)) + offs(gem, o_paoffs4A)
                    b = (b * 256) + romdat(arrayAdjuster + offs(gem, o_paoffs4L) + a)
                    c = (c * 256) + romdat(arrayAdjuster + offs(gem, o_paoffs4L) + a) + &H11S
                    If (c > palanimoff) And (b < offs(gem, o_pa4end)) Then
                        romdat(arrayAdjuster + offs(gem, o_paoffs4H) + a) = (Int((b + frbal) / &H100S))
                        romdat(arrayAdjuster + offs(gem, o_paoffs4L) + a) = ((b + frbal) And &HFFS)
                    End If
                Next a

                c = romdat(arrayAdjuster + palanimoff)
                If frbal > 0 Then 'push or pull?
                    For a = 0 To (piecedatend_rom - (palanimoff + 2 + c))
                        romdat(arrayAdjuster + (piecedatend_rom + frbal) - a) = romdat(arrayAdjuster + piecedatend_rom - a)
                    Next a

                    For a = 0 To (frbal - 1)
                        romdat(arrayAdjuster + palanimoff + 3 + c + a) = 1
                    Next a
                Else
                    b = (frbal - frbal) - frbal
                    For a = 0 To (piecedatend_rom - (palanimoff + 2 + c)) - 1
                        romdat(arrayAdjuster + (palanimoff + 2 + c) + a) = romdat(arrayAdjuster + (palanimoff + 2 + c) + a + b)
                    Next a
                End If

            Case 2
                frbal = newframes - romdat(arrayAdjuster + palanimoff) 'Balance
                If frbal = 0 Then Exit Sub ';)

                b = 0
                For a = 0 To offs(gem, o_maxpa)
                    c = romdat(arrayAdjuster + offs(gem, o_paoffs) + a)
                    If (c <= offs(gem, o_paspace)) And (c > b) Then b = c
                Next a

                a = romdat(arrayAdjuster + offs(gem, o_padata) + b + 0)
                piecedatend_pt = (b + 2 + a)
                piecedatend_rom = offs(gem, o_padata) + (b + 2 + a)
                If frbal > (offs(gem, o_paspace) - piecedatend_pt) Then MsgBox("Not enough unused space, Kill some frames off other animations!") : Exit Sub

                For a = 0 To offs(gem, o_maxpa)
                    b = romdat(arrayAdjuster + offs(gem, o_paoffs) + a)
                    If ((b + offs(gem, o_padata)) > palanimoff) And (b <= offs(gem, o_paspace)) Then
                        romdat(arrayAdjuster + offs(gem, o_paoffs) + a) = VWidth(b + frbal, 0, &HFFS)
                    End If
                Next a

                c = romdat(arrayAdjuster + palanimoff)
                If frbal > 0 Then 'push or pull?
                    For a = 0 To (piecedatend_rom - (palanimoff + 2 + c))
                        romdat(arrayAdjuster + (piecedatend_rom + frbal) - a) = romdat(arrayAdjuster + piecedatend_rom - a)
                    Next a

                    For a = 0 To (frbal - 1)
                        romdat(arrayAdjuster + palanimoff + 3 + c + a) = 1
                    Next a
                Else
                    b = (frbal - frbal) - frbal
                    For a = 0 To (piecedatend_rom - (palanimoff + 2 + c)) - 1
                        romdat(arrayAdjuster + (palanimoff + 2 + c) + a) = romdat(arrayAdjuster + (palanimoff + 2 + c) + a + b)
                    Next a
                End If

        End Select

        romdat(arrayAdjuster + palanimoff) = newframes

        curpalanimframe = 0
        Update_PalAnim()
        'SetTBCoolText FramesTB, hex$(Asc(mid$(romdat, palanimoff, 1)))
    End Sub

    Private Sub PAColPic_MouseUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles _PAColPic_2.MouseUp, _PAColPic_1.MouseUp, _PAColPic_0.MouseUp
        Dim Button As Short = eventArgs.Button \ &H100000
        Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000

        Dim Index As Short = 0

        For Each pictureBox As PictureBox In PAColPic
            If pictureBox.Name = eventSender.Name Then
                Exit For
            End If
            Index += 1
        Next

        If tabPalWeapon.SelectedIndex = 1 Then GoTo Weapon_Color
        Dim framepalptr As Integer
        If gem > 0 Then
            framepalptr = (romdat(arrayAdjuster + palanimoff + 2 + curpalanimframe) * 3)
        Else
            framepalptr = (romdat(arrayAdjuster + palanimoff + 3 + curpalanimframe) * 3)
        End If
        Select Case Button
            Case 1 : SetTBCoolNumWithValidation(PAColTB(Index), Hex(romdat(arrayAdjuster + offs(gem, 56) + framepalptr + Index) + 1), &H3FS, 2, True)
            Case 2 : SetTBCoolNumWithValidation(PAColTB(Index), Hex(Math.Max(0, romdat(arrayAdjuster + offs(gem, 56) + framepalptr + Index) - 1)), &H3FS, 2, True)
        End Select

        romdat(arrayAdjuster + offs(gem, 56) + framepalptr + Index) = Dec(PAColTB(Index).Text)
        PAColPic(Index).BackColor = System.Drawing.ColorTranslator.FromOle(RGBmirr(NESPAL(romdat(arrayAdjuster + offs(gem, 56) + framepalptr + Index))))
        Exit Sub

Weapon_Color:
        Dim coloffset As Integer
        'megaman 3 format
        If gem = 0 Then
            Select Case WeaponList.SelectedIndex
                Case 0 To 2 : coloffset = WeaponList.SelectedIndex * 8
                Case 3 To 5 : coloffset = (WeaponList.SelectedIndex - 2) * 8 - 4
                Case 6 To 8 : coloffset = (WeaponList.SelectedIndex * 8) - 24
                Case 9 To 11 : coloffset = (WeaponList.SelectedIndex * 8) - 44
            End Select
            GoTo Done_Calculating
        End If

        'megaman 4 format
        If gem = 1 Then coloffset = WeaponList.SelectedIndex * 4

        'megaman 5 format
        If gem = 2 Then
            Select Case WeaponList.SelectedIndex
                Case 0 To 5 : coloffset = WeaponList.SelectedIndex * 4
                Case 6 To 11 : coloffset = (WeaponList.SelectedIndex * 4) + 8
                Case 12 : coloffset = (WeaponList.SelectedIndex * 4) - 24
            End Select
            GoTo Done_Calculating
        End If

Done_Calculating:
        Select Case Button
            Case 1 : SetTBCoolNumWithValidation(PAColTB(Index), Hex(romdat(arrayAdjuster + offs(gem, 65) + coloffset + Index) + 1), &H3FS, 2, True)
            Case 2 : SetTBCoolNumWithValidation(PAColTB(Index), Hex(Math.Max(0, romdat(arrayAdjuster + offs(gem, 65) + coloffset + Index) - 1)), &H3FS, 2, True)
        End Select

        romdat(arrayAdjuster + offs(gem, 65) + coloffset + Index) = Dec(PAColTB(Index).Text)
        PAColPic(Index).BackColor = System.Drawing.ColorTranslator.FromOle(RGBmirr(NESPAL(romdat(arrayAdjuster + offs(gem, 65) + coloffset + Index))))

        Draw_MM_Weapon_Preview(coloffset)
    End Sub

    Private Sub PAColTB_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles _PAColTB_2.TextChanged, _PAColTB_1.TextChanged, _PAColTB_0.TextChanged
        Dim Index As Short = 0

        For Each textBox As TextBox In PAColTB
            If textBox.Name = eventSender.Name Then
                Exit For
            End If
            Index += 1
        Next

        If PAColTB(Index).Tag <> "" Then Exit Sub

        ' Set it with function so rounding is done always the same way for every controls
        SetTBCoolNumWithValidation(PAColTB(Index), PAColTB(Index).Text, 63, 2, True)

        If tabPalWeapon.SelectedIndex = 1 Then GoTo Weapon_Color
        Dim framepalptr As Integer
        If gem > 0 Then
            framepalptr = (romdat(arrayAdjuster + palanimoff + 2 + curpalanimframe) * 3)
        Else
            framepalptr = (romdat(arrayAdjuster + palanimoff + 3 + curpalanimframe) * 3)
        End If
        romdat(arrayAdjuster + offs(gem, 56) + framepalptr + Index) = (Dec(PAColTB(Index).Text) And &H3FS)
        PAColPic(Index).BackColor = System.Drawing.ColorTranslator.FromOle(RGBmirr(NESPAL(romdat(arrayAdjuster + offs(gem, 56) + framepalptr + Index))))
        SetTBCoolText(PAColTB(Index), Hex(romdat(arrayAdjuster + offs(gem, 56) + framepalptr + Index)))
        Exit Sub

Weapon_Color:
        Dim coloffset As Integer
        'megaman 3 format
        If gem = 0 Then
            Select Case WeaponList.SelectedIndex
                Case 0 To 2 : coloffset = WeaponList.SelectedIndex * 8
                Case 3 To 5 : coloffset = (WeaponList.SelectedIndex - 2) * 8 - 4
                Case 6 To 8 : coloffset = (WeaponList.SelectedIndex * 8) - 24
                Case 9 To 11 : coloffset = (WeaponList.SelectedIndex * 8) - 44
            End Select
            GoTo Done_Calculating
        End If

        'megaman 4 format
        If gem = 1 Then coloffset = WeaponList.SelectedIndex * 4

        'megaman 5 format
        If gem = 2 Then
            Select Case WeaponList.SelectedIndex
                Case 0 To 5 : coloffset = WeaponList.SelectedIndex * 4
                Case 6 To 11 : coloffset = (WeaponList.SelectedIndex * 4) + 8
                Case 12 : coloffset = (WeaponList.SelectedIndex * 4) - 24
            End Select
            GoTo Done_Calculating
        End If
Done_Calculating:
        romdat(arrayAdjuster + offs(gem, 65) + coloffset + Index) = (Dec(PAColTB(Index).Text) And &H3FS)
        PAColPic(Index).BackColor = System.Drawing.ColorTranslator.FromOle(RGBmirr(NESPAL(romdat(arrayAdjuster + offs(gem, 65) + coloffset + Index))))
        SetTBCoolText(PAColTB(Index), Hex(romdat(arrayAdjuster + offs(gem, 65) + coloffset + Index)))

        Draw_MM_Weapon_Preview(coloffset)
    End Sub

    Private Sub PalPic_MouseUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles PalPic.MouseUp
        Dim Button As Short = eventArgs.Button \ &H100000
        Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
        Dim x As Single = eventArgs.X
        Dim Y As Single = eventArgs.Y
        Dim a As Integer
        If curcol = VWidth(Int(x / 32), 0, 15) Then
            If gem = 3 Then
                a = MFLE_Main.GetMM6Col(curcol)
                If Button = 1 Then
                    If a = &H3FS Then a = 0 Else a += 1
                Else
                    If a = 0 Then a = &H3FS Else a -= 1
                End If
                MFLE_Main.SetMM6Col(curcol, a)
            Else
                If Button = 1 Then
                    romdat(arrayAdjuster + offs(gem, o_pal) + (palset * palsetWidth) + curcol) = (romdat(arrayAdjuster + offs(gem, o_pal) + (palset * palsetWidth) + curcol) + 1)
                    If romdat(arrayAdjuster + offs(gem, o_pal) + (palset * palsetWidth) + curcol) = &H40S Then romdat(arrayAdjuster + offs(gem, o_pal) + (palset * palsetWidth) + curcol) = &H0S
                Else
                    If romdat(arrayAdjuster + offs(gem, o_pal) + (palset * palsetWidth) + curcol) = 0 Then romdat(arrayAdjuster + offs(gem, o_pal) + (palset * palsetWidth) + curcol) = &H40S
                    romdat(arrayAdjuster + offs(gem, o_pal) + (palset * palsetWidth) + curcol) = (romdat(arrayAdjuster + offs(gem, o_pal) + (palset * palsetWidth) + curcol) - 1)
                End If
            End If
            SetColMumboJumbo(curcol)
            'glob_pal(cursprcol + (cursprpal * 4) + &H48) = NESPAL(Asc(mid$(romdat, offs(gem, 27) + (enemset * 8) + (cursprpal * 4) + cursprcol, 1)))
            'MFLE_Main.Update_BGPal 1, 0
            'MFX_Render.RenderPic ScreenPic, enem_scr_bmi
            'MFX_Render.RenderPic TilePic, enem_tile_bmi
        End If
        curcol = VWidth(Int(x / 32), 0, 15)
        CurColSet()
        RenderModule.RenderPic(PalPic, pal_bmi)
        palchartClaim = Palchart_Claim.PalEd
    End Sub

    Private Sub SetColMumboJumbo(ByRef col As Integer)
        Dim b, a, c As Integer
        If (col And 3) = 0 Then
            If col = 0 Then
                If gem = 3 Then
                    a = NESPAL(MFLE_Main.GetMM6Col(0))
                    b = NESPALD(MFLE_Main.GetMM6Col(0))
                    c = NESPALL(MFLE_Main.GetMM6Col(0))
                    PPU_palette_val(0) = MFLE_Main.GetMM6Col(0)
                    PPU_palette_val(4) = MFLE_Main.GetMM6Col(0)
                    PPU_palette_val(8) = MFLE_Main.GetMM6Col(0)
                    PPU_palette_val(&HCS) = MFLE_Main.GetMM6Col(0)
                Else
                    a = NESPAL(romdat(arrayAdjuster + offs(gem, o_pal) + (palset * palsetWidth) + 0))
                    b = NESPALD(romdat(arrayAdjuster + offs(gem, o_pal) + (palset * palsetWidth) + 0))
                    c = NESPALL(romdat(arrayAdjuster + offs(gem, o_pal) + (palset * palsetWidth) + 0))
                    PPU_palette_val(0) = romdat(arrayAdjuster + offs(gem, o_pal) + (palset * palsetWidth) + 0)
                End If
                glob_pal(0) = a : glob_pal(4) = a : glob_pal(8) = a : glob_pal(&HCS) = a
                glob_pal(&H10S) = b : glob_pal(&H14S) = b : glob_pal(&H18S) = b : glob_pal(&H1CS) = b
                glob_pal(&H30S) = c : glob_pal(&H34S) = c : glob_pal(&H38S) = c : glob_pal(&H3CS) = c
                glob_pal(&H50S) = a : glob_pal(&H54S) = a : glob_pal(&H58S) = a : glob_pal(&H5CS) = a
            End If
        Else
            If gem = 3 Then
                glob_pal(col) = NESPAL(MFLE_Main.GetMM6Col(col))
                glob_pal(col + &H10S) = NESPALD(MFLE_Main.GetMM6Col(col))
                glob_pal(col + &H30S) = NESPALL(MFLE_Main.GetMM6Col(col))
                glob_pal(col + &H50S) = NESPAL(MFLE_Main.GetMM6Col(col))
                PPU_palette_val(col) = MFLE_Main.GetMM6Col(col)
            Else
                glob_pal(col) = NESPAL(romdat(arrayAdjuster + offs(gem, o_pal) + (palset * palsetWidth) + col))
                glob_pal(col + &H10S) = NESPALD(romdat(arrayAdjuster + offs(gem, o_pal) + (palset * palsetWidth) + col))
                glob_pal(col + &H30S) = NESPALL(romdat(arrayAdjuster + offs(gem, o_pal) + (palset * palsetWidth) + col))
                glob_pal(col + &H50S) = NESPAL(romdat(arrayAdjuster + offs(gem, o_pal) + (palset * palsetWidth) + col))
                PPU_palette_val(col) = romdat(arrayAdjuster + offs(gem, o_pal) + (palset * palsetWidth) + col)
            End If
        End If
        MFLE_Main.Update_Global_Pal(True)
        MFLE_Main.Update_BGPal(1) 'Needed?
        'If PalEd.Visible Then PalEd.Update_BGPal 1
        'If TileTable.Visible Then TileTable.Update_BGPal 1
        'If MetatileTable.Visible Then MetatileTable.Update_BGPal 1
        'If MetametatileTable.Visible Then MetametatileTable.Update_BGPal 1
        'If ScreenEd.Visible Then ScreenEd.Update_BGPal 1
        'If EnemEd.Visible Then EnemEd.Update_BGPal 1
    End Sub

    Private Sub EffSw_CheckStateChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles _EffSw_3.CheckStateChanged, _EffSw_2.CheckStateChanged, _EffSw_1.CheckStateChanged, _EffSw_0.CheckStateChanged
        Dim Index As Short = 0

        For Each checkBox As CheckBox In EffSw
            If checkBox.Name = eventSender.Name Then
                Exit For
            End If
            Index += 1
        Next

        ' Unless I'm wrong, it wasn't called anymore so I commented it
        If EffSw(0).Tag <> "" Then Exit Sub
        romdat(arrayAdjuster + offs(gem, o_pal) + (palset * palsetWidth) + &H10S + Index) = (CShort(romdat(arrayAdjuster + offs(gem, o_pal) + (palset * palsetWidth) + &H10S + Index) And &H7FS) + (EffSw(Index).CheckState * &H80S))
        MFLE_Main.Update_RefreshPalSet(True)
    End Sub

    Private Sub PrevWP_SprBtn_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles PrevWP_SprBtn.Click
        Dim a As Integer
        previewSprite = Dec((PrevSprTB.Text)) And &HFFS
        a = previewSprite + 1
        SetTBCoolText(PrevSprTB, Hex(a))
    End Sub

    Private Sub TabControlPalEd_Click(sender As Object, e As EventArgs) Handles tabPalWeapon.Click
        Dim Index As Integer = 0
        Dim Toggle As Integer
        Dim Sprstring As String = ""
        Select Case gem
            Case 0 : Sprstring = My.Application.Info.DirectoryPath & "\Icons\" & WeaponList.SelectedIndex & ".gif"
            Case 1 : Sprstring = My.Application.Info.DirectoryPath & "\Icons\" & WeaponList.SelectedIndex & ".ico"
            Case 2 : Sprstring = My.Application.Info.DirectoryPath & "\Icons\" & WeaponList.SelectedIndex & ".bmp"
        End Select
        WeaponIcon.Image = System.Drawing.Image.FromFile(Sprstring)
        If tabPalWeapon.SelectedIndex = 1 Then
            Toggle = False
            WeaponList_SelectedIndexChanged(WeaponList, New System.EventArgs())
        Else
            Toggle = True
            Update_PalAnim()
        End If
        If gem = 0 Then
            DstColLab.Visible = Toggle
            DstColUD.Visible = Toggle
        End If





        ' Some controls are shared between the Tabs, remove it where it is now and then add it back on the appropriate
        '	GroupBox
        For Index = 0 To PAColPic.Length - 1
            If gbxPalAnim.Controls.Contains(PAColPic(Index)) Then
                gbxPalAnim.Controls.Remove(PAColPic(Index))
            ElseIf gbxWeaponSelected.Controls.Contains(PAColPic(Index)) Then
                gbxWeaponSelected.Controls.Remove(PAColPic(Index))
            End If

            If gbxPalAnim.Controls.Contains(PAColTB(Index)) Then
                gbxPalAnim.Controls.Remove(PAColTB(Index))
            ElseIf gbxWeaponSelected.Controls.Contains(PAColTB(Index)) Then
                gbxWeaponSelected.Controls.Remove(PAColTB(Index))
            End If

            If tabPalWeapon.SelectedIndex = 0 Then
                gbxPalAnim.Controls.Add(PAColPic(Index))
                gbxPalAnim.Controls.Add(PAColTB(Index))
            Else
                gbxWeaponSelected.Controls.Add(PAColPic(Index))
                gbxWeaponSelected.Controls.Add(PAColTB(Index))
            End If

            ' To be sure it is not behind label
            PAColPic(Index).BringToFront()
            PAColTB(Index).BringToFront()
        Next
    End Sub

    Private Sub WeaponList_SelectedIndexChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles WeaponList.SelectedIndexChanged
        If WeaponList.Tag <> "" Then Exit Sub
        If gem = 3 Then Exit Sub
        Dim a, b As Integer
        Dim Sprstring As String = ""
        Select Case gem
            Case 0 : Sprstring = My.Application.Info.DirectoryPath & "\Icons\" & WeaponList.SelectedIndex & ".gif"
            Case 1 : Sprstring = My.Application.Info.DirectoryPath & "\Icons\" & WeaponList.SelectedIndex & ".ico"
            Case 2 : Sprstring = My.Application.Info.DirectoryPath & "\Icons\" & WeaponList.SelectedIndex & ".bmp"
        End Select
        WeaponIcon.Image = System.Drawing.Image.FromFile(Sprstring)

        'megaman 3 format
        If gem = 0 Then
            Select Case WeaponList.SelectedIndex
                Case 0 To 2 : b = WeaponList.SelectedIndex * 8
                Case 3 To 5 : b = (WeaponList.SelectedIndex - 2) * 8 - 4
                Case 6 To 8 : b = (WeaponList.SelectedIndex * 8) - 24
                Case 9 To 11 : b = (WeaponList.SelectedIndex * 8) - 44
            End Select
            GoTo Done_Calculating
        End If

        'megaman 4 format
        If gem = 1 Then b = WeaponList.SelectedIndex * 4

        'megaman 5 format
        If gem = 2 Then
            Select Case WeaponList.SelectedIndex
                Case 0 To 5 : b = WeaponList.SelectedIndex * 4
                Case 6 To 11 : b = (WeaponList.SelectedIndex * 4) + 8
                Case 12 : b = (WeaponList.SelectedIndex * 4) - 24
            End Select
            GoTo Done_Calculating
        End If

Done_Calculating:
        For a = 0 To 2
            PAColPic(a).BackColor = System.Drawing.ColorTranslator.FromOle(RGBmirr(NESPAL(romdat(arrayAdjuster + offs(gem, 65) + a + b))))
            SetTBCoolText(PAColTB(a), Hex(romdat(arrayAdjuster + offs(gem, 65) + a + b)))
        Next a

        Draw_MM_Weapon_Preview(b)
    End Sub

    Private Sub Draw_MM_Weapon_Preview(ByRef weaponPalOffset As Integer)
        Dim a As Integer

        Dim tmp_bmi As New BITMAPINFO()

        tmp_bmi.Initialize()

        'If Not (gem = 2) Then Exit Sub

        For a = 0 To 2
            tmp_bmi.pal(1 + a) = NESPAL(romdat(arrayAdjuster + offs(gem, 65) + a + weaponPalOffset))
            tmp_bmi.pal(5 + a) = glob_pal(&H45S + a)
        Next a

        tmp_bmi.palette_UpdatedSinceLastBytesRGB_Update = True

        RenderModule.PB_Init(Preview, tmp_bmi)

        'draw Megaman's sprite

        MegaFLEX_Main.SpriteDraw(offs(gem, o_MM_sprBank), previewSprite, 0, 20, 14, 0, tmp_bmi, tmp_bmi)

        RenderModule.RenderPicAlwaysIfItWasChangedSinceLastupdate(Preview, tmp_bmi)
        Preview.Refresh()

    End Sub
    Private Sub FrameSelect_Scroll(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.ScrollEventArgs) Handles FrameSelect.Scroll
        Select Case eventArgs.Type
            Case System.Windows.Forms.ScrollEventType.EndScroll
                FrameSelect_Change(eventArgs.NewValue)
        End Select
    End Sub

    Private Sub SetUDCool_PalSetUD(ByRef numericUpDown As NumericUpDown, text As String)
        SetUDCool(numericUpDown, text, If(scenemode, 2, 1))
    End Sub


#Region "Events"

    Private Sub PCShowCmd_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles PCShowCmd.Click
        MFLE_Decl.PalChartToFront = True
        Dim pnt As New Point(Me.Right, Me.Top)

        PalChart.Location = pnt

        'This prevent it from showing too fast - sometime is shown quickly at wrong position
        Do
        Loop While (PalChart.Location <> pnt)

        If PalChart.Visible = False Then PalChart.Show() 'Else it causes infinite calls
        palchartClaim = Palchart_Claim.PalEd
    End Sub

    Private Sub PalSetOpt_CheckedChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles _PalSetOpt_0.CheckedChanged, _PalSetOpt_1.CheckedChanged
        If eventSender.Checked Then
            Dim Index As Short = 0

            For Each radioButton As RadioButton In PalSetOpt
                If radioButton.Name = eventSender.Name Then
                    Exit For
                End If
                Index += 1
            Next

            palsetChangeType = Index
            UpdatePChangeType()
        End If
    End Sub

#Region "NumericUpDown"
    Private Sub DelayUD_ActionUponNewValue()
        If DelayUD.Tag <> "" Then Exit Sub
        If DelayUD_ValuePrevious = DelayUD.Value Then Exit Sub

        DelayUD_ValuePrevious = DelayUD.Value

        romdat(arrayAdjuster + palanimoff + 1) = (Dec(DelayUD.Text) And &HFFS)
        SetUDCool(DelayUD, Hex(romdat(arrayAdjuster + palanimoff + 1)), 2)
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

    Private Sub DstColUD_ActionUponNewValue()
        If DstColUD.Tag <> "" Then Exit Sub
        If DstColUD_ValuePrevious = DstColUD.Value Then Exit Sub

        DstColUD_ValuePrevious = DstColUD.Value

        romdat(arrayAdjuster + palanimoff + 2) = (Dec(DstColUD.Text) And &HFFS)
        SetUDCool(DstColUD, Hex(romdat(arrayAdjuster + palanimoff + 2)), 2)
    End Sub

    Private Sub DstColUD_ValueChanged(sender As Object, e As EventArgs) Handles DstColUD.ValueChanged
        If UpdateUDCool(sender) Then
            ' When here, Value was validated
            DstColUD_ActionUponNewValue()
        End If
    End Sub

    Private Sub DstColUD_KeyUp(sender As Object, e As KeyEventArgs) Handles DstColUD.KeyUp
        ' Set new value (with validations)
        SetUDCool(CType(sender, NumericUpDown), sender.Text, 2)

        ' When here, Value was validated
        DstColUD_ActionUponNewValue()
    End Sub

    Private Sub EffUD_ActionUponNewValue(sender As Object)
        Dim Index As Short = 0

        For Each nuemricUpDown As NumericUpDown In EffUD
            If nuemricUpDown.Name = sender.Name Then
                Exit For
            End If
            Index += 1
        Next

        If EffUD(Index).Tag <> "" Then Exit Sub

        If EffUD_ValuePrevious(Index) = EffUD(Index).Value Then Exit Sub

        EffUD_ValuePrevious(Index) = EffUD(Index).Value

        romdat(arrayAdjuster + offs(gem, o_pal) + (palset * palsetWidth) + &H10S + Index) = (CShort(romdat(arrayAdjuster + offs(gem, o_pal) + (palset * palsetWidth) + &H10S + Index) And &H80S) + VWidth(Dec(EffUD(Index).Text), 0, &H7FS))
        MFLE_Main.Update_RefreshPalSet(True)
    End Sub

    Private Sub EffUD_ValueChanged(sender As Object, e As EventArgs) Handles _EffUD_0.ValueChanged, _EffUD_1.ValueChanged, _EffUD_2.ValueChanged, _EffUD_3.ValueChanged
        If UpdateUDCool(sender) Then
            ' When here, Value was validated
            EffUD_ActionUponNewValue(sender)
        End If
    End Sub

    Private Sub EffUD_KeyUp(sender As Object, e As KeyEventArgs) Handles _EffUD_0.KeyUp, _EffUD_1.KeyUp, _EffUD_2.KeyUp, _EffUD_3.KeyUp
        ' Set new value (with validations)
        SetUDCool(CType(sender, NumericUpDown), sender.Text, 2)

        ' When here, Value was validated
        EffUD_ActionUponNewValue(sender)
    End Sub

    Private Sub FramesUD_ActionUponNewValue()
        If FramesUD.Tag <> "" Then Exit Sub
        If FramesUD_ValuePrevious = FramesUD.Value Then Exit Sub

        FramesUD_ValuePrevious = FramesUD.Value

        FixPAPointers((Dec((FramesUD.Text)) And &HFFS))
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

    Private Sub PAIDUD_ActionUponNewValue()
        If PAIDUD.Tag <> "" Then Exit Sub
        If PAIDUD_ValuePrevious = PAIDUD.Value Then Exit Sub

        PAIDUD_ValuePrevious = PAIDUD.Value

        curpalanim = (Dec((PAIDUD.Text)) And &H7FS)
        Update_PalAnim()
    End Sub

    Private Sub PAIDUD_ValueChanged(sender As Object, e As EventArgs) Handles PAIDUD.ValueChanged
        If UpdateUDCool(sender) Then
            ' When here, Value was validated
            PAIDUD_ActionUponNewValue()
        End If
    End Sub

    Private Sub PAIDUD_KeyUp(sender As Object, e As KeyEventArgs) Handles PAIDUD.KeyUp
        ' Set new value (with validations)
        SetUDCool(CType(sender, NumericUpDown), sender.Text, 2)

        ' When here, Value was validated
        PAIDUD_ActionUponNewValue()
    End Sub

    Private Sub PalSetUD_ActionUponNewValue()
        palset = PalSetUD.Value

        MFLE_Main.Update_RefreshPalSet(True)
    End Sub

    Private Sub PalSetUD_ValueChanged(sender As Object, e As EventArgs) Handles PalSetUD.ValueChanged
        If UpdateUDCool(sender) Then
            'When here, PalSetUD.Value was validated
            PalSetUD_ActionUponNewValue()
        End If
    End Sub

    Private Sub PalSetUD_KeyUp(sender As Object, e As KeyEventArgs) Handles PalSetUD.KeyUp
        'Set new value (with validations)
        SetUDCool_PalSetUD(CType(sender, NumericUpDown), sender.Text)

        'When here, PalSetUD.Value was validated
        PalSetUD_ActionUponNewValue()
    End Sub

    Private Sub PieceUD_ActionUponNewValue()
        If PieceUD_ValuePrevious = PieceUD.Value Then Exit Sub

        PieceUD_ValuePrevious = PieceUD.Value

        If gem > 0 Then
            romdat(arrayAdjuster + palanimoff + 2 + curpalanimframe) = ((PieceUD.Value) And &HFFS)
        Else
            romdat(arrayAdjuster + palanimoff + 3 + curpalanimframe) = ((PieceUD.Value) And &HFFS)
        End If
        SetPAFrame()
    End Sub

    Private Sub PieceUD_ValueChanged(sender As Object, e As EventArgs) Handles PieceUD.ValueChanged
        If UpdateUDCool(sender) Then
            ' When here, Value was validated
            PieceUD_ActionUponNewValue()
        End If
    End Sub

    Private Sub PieceUD_KeyUp(sender As Object, e As KeyEventArgs) Handles PieceUD.KeyUp
        ' Set new value (with validations)
        SetUDCool(CType(sender, NumericUpDown), sender.Text, 2)

        ' When here, Value was validated
        PieceUD_ActionUponNewValue()
    End Sub

    Private Sub Text5_TextChanged(sender As Object, e As EventArgs) Handles Text5.TextChanged
        If Text5.Tag <> "" Then Exit Sub
        SetTBCoolNumWithValidation(Text5, Text5.Text, 65535, 4, True)
    End Sub

    Private Sub Command6_Click(sender As Object, e As EventArgs) Handles Command6.Click
        If gem = 3 Then
            MFLE_Main.LoadMM6Pal(0, Dec((Text5.Text)))

            MFLE_Main.Update_Global_Pal(False)
            MFLE_Main.PalAnim_Reset()

            If Me.Visible Then Me.Update_BGPal() ' 1 'upd
            If TileTable.Visible Then TileTable.Update_BGPal(1)
            If MetatileTable.Visible Then MetatileTable.Update_BGPal(1)
            If MetametatileTable.Visible Then MetametatileTable.Update_BGPal(1)
            If ScreenEd.Visible Then ScreenEd.Update_BGPal()
            If EnemEd.Visible Then EnemEd.Update_BGPal(1)
            If SBDSpecial.Visible Then SBDSpecial.Update_BGPal(1)

        End If

        Text5.Text = vbNullString
        Text5.Focus()
    End Sub

    Private Sub PrevSprTB_TextChanged(sender As Object, e As EventArgs) Handles PrevSprTB.TextChanged
        If PrevSprTB_TextChanged_FirstCall Then
            PrevSprTB_TextChanged_FirstCall = False
        Else
            SetTBCoolNumWithValidation(PrevSprTB, PrevSprTB.Text, &H3FS, 2, True)
            previewSprite = Dec((PrevSprTB.Text)) And &HFFS
            WeaponList_SelectedIndexChanged(WeaponList, New System.EventArgs())
        End If
    End Sub
#End Region
#End Region
End Class