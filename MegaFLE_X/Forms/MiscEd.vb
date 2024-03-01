Option Explicit On
Friend Class MiscEd
    Inherits System.Windows.Forms.Form

    Private multipath As Integer

    Private GlIdUD_ValuePrevious As Integer
    Private MusicUD_ValuePrevious As Integer
    Private SBDUD_ValuePrevious As Integer
    Private MuPIDUD_ValuePrevious As Integer
    Private MPCheckScreenUD_ValuePrevious() As Integer
    Private ScCHRUD_ValuePrevious() As Integer
    Private MuPUD_ValuePrevious() As Integer
    Private MPUD_ValuePrevious() As Integer

    ' Object that groups many items
    '   Label
    Private MuPLab() As Label
    Private ScCHRLab() As Label
    '   NumericUpDown
    Private ScCHRUD() As NumericUpDown
    Private MPCheckScreenUD() As NumericUpDown
    Private MuPUD() As NumericUpDown
    Private MPUD() As NumericUpDown

    Private Sub Form_Initialize()
        ' Object that group many items=
        ' Label
        MuPLab = New Label() {_MuPLab_0, _MuPLab_1}
        ScCHRLab = New Label() {_ScCHRLab_0, _ScCHRLab_1}
        '   NumericUpDown
        ScCHRUD = New NumericUpDown() {_ScCHRUD_0, _ScCHRUD_1}
        MPCheckScreenUD = New NumericUpDown() {_MPCheckScreenUD_0, _MPCheckScreenUD_1}
        MuPUD = New NumericUpDown() {_MuPUD_0, _MuPUD_1, _MuPUD_2, _MuPUD_3}
        MPUD = New NumericUpDown() {_MPUD_0, _MPUD_1, _MPUD_2, _MPUD_3, _MPUD_4, _MPUD_5, _MPUD_6, _MPUD_7}

        'Previous values that need to be stored
        GlIdUD_ValuePrevious = GlIdUD.Value
        MusicUD_ValuePrevious = MusicUD.Value
        SBDUD_ValuePrevious = SBDUD.Value
        MuPIDUD_ValuePrevious = MuPIDUD.Value
        MPCheckScreenUD_ValuePrevious = {_MPCheckScreenUD_0.Value, _MPCheckScreenUD_1.Value}
        ScCHRUD_ValuePrevious = {_ScCHRUD_0.Value, _ScCHRUD_1.Value}
        MuPUD_ValuePrevious = {_MuPUD_0.Value, _MuPUD_1.Value, _MuPUD_2.Value, _MuPUD_3.Value}
        MPUD_ValuePrevious = {_MPUD_0.Value, _MPUD_1.Value, _MPUD_2.Value, _MPUD_3.Value, _MPUD_4.Value, _MPUD_5.Value, _MPUD_6.Value, _MPUD_7.Value}
    End Sub

    Public Sub Manual_Init()
        'Calling it ensure constructor above is called
    End Sub

    Private Sub MiscEd_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        e.Cancel = True

        Me.Hide()
    End Sub

    Public Sub Update_Frm()
        Dim a As Integer
        multipath = 0

        MusicCombo.Items.Clear()

        For a = 0 To offs(gem, 57) - 1
            If rdata(dspa(d_soundt + gem) + a) = 1 Then
                MusicCombo.Items.Add("M:" & Hex(a) & ": " & SrcString(rdata(dspa(d_sound + gem) + a)))
            Else
                MusicCombo.Items.Add("S:" & Hex(a) & ": " & SrcString(rdata(dspa(d_sound + gem) + a)))
            End If
        Next a

        SceneFrame.SetBounds(MusicLabel.Left, MusicLabel.Top, 0, 0, Windows.Forms.BoundsSpecified.X Or Windows.Forms.BoundsSpecified.Y)

        If (gem = 0) Or (gem = 2) Then
            For a = 0 To offs(gem, 62)
                SBDCombo.Items.Add(Hex(a) & ": " & SrcString(rdata(dspa(d_sbdnames + gem) + a)))
            Next a
        End If

        If gem = 1 Then
            MPLab3.Enabled = True
            BPLab3.Enabled = True
            _MPUD_3.Enabled = True
            _MPUD_7.Enabled = True

            MPLab4.Enabled = True
            BPLab4.Enabled = True
            _MPCheckScreenUD_0.Enabled = True
            _MPCheckScreenUD_1.Enabled = True
        End If

        Select Case gem
            Case 0
                MPLab2.Text = "Enemy Position#:"
                BPLab2.Text = "Enemy Position#:"
            Case 1
                MPLab2.Text = "Initial CHR Load ID:"
                BPLab2.Text = "Initial CHR Load ID:"
        End Select

        Update_Level()
    End Sub

    Public Sub Update_Level()
        Dim a As Integer
        multipath = 0

        HideOrShow()

        If scenemode = True Then
            CurLevLab.Text = "Editing scene level: " & CStr(level) & ": Bank " & Hex(rdata(rdata(dspa(d_scenesbank) + gem) + a))
        Else
            CurLevLab.Text = "Editing level: " & CStr(level) & ": " & SrcString(rdata(dspa(d_levnames + gem) + level))
        End If

        If scenemode = False Then

            If romdat(arrayAdjuster + offs(gem, 22) + level) < MusicCombo.Items.Count Then
                SetComboCool(MusicCombo, romdat(arrayAdjuster + offs(gem, 22) + level))
            End If
            If (gem = 0) Or (gem = 2) Then
                If romdat(arrayAdjuster + offs(gem, 26) + level) < SBDCombo.Items.Count Then
                    SetComboCool(SBDCombo, romdat(arrayAdjuster + offs(gem, 26) + level))
                End If
            End If

            Select Case gem
                Case 0
                    For a = 0 To 1
                        SetUDCool(MPUD((a * 4) + 0), Hex(romdat(arrayAdjuster + offs(gem, 51) + a)), 2)
                        SetUDCool(MPUD((a * 4) + 1), Hex(romdat(arrayAdjuster + offs(gem, 50) + a)), 2)
                        SetUDCool(MPUD((a * 4) + 2), Hex(romdat(arrayAdjuster + offs(gem, 52) + a)), 2)
                    Next a
                Case 1
                    For a = 0 To 7
                        SetUDCool(MPUD(a), Hex(romdat(arrayAdjuster + rdata(dspa(d_ex) + 31) + (level * 8) + a)), 2)
                    Next a
                    For a = 0 To 1
                        SetUDCool(MPCheckScreenUD(a), Hex(romdat(arrayAdjuster + rdata(dspa(d_ex) + 32) + (level * 2) + a)), 2)
                    Next a
                Case 2
                    For a = 0 To 2
                        SetUDCool(MPUD(0 + a), Hex(romdat(arrayAdjuster + rdata(dspa(d_ex) + 33) + (level * 6) + 0 + a)), 2)
                        SetUDCool(MPUD(4 + a), Hex(romdat(arrayAdjuster + rdata(dspa(d_ex) + 33) + (level * 6) + 3 + a)), 2)
                    Next a
            End Select

            If (gem = 1) Or (gem = 2) Then Update_MultiPath()

        Else

            'Set up values for Scene Screen Mode

            'The zero-value checks are just a measure to prevent errors,
            'because this code is executed once *before* the pointers
            'are actually set to something nonzero.

            If gem = 1 Then

                If (SceneModeInfo.gfxLoadId_Ptr) Then
                    SetUDCool(GlIdUD, Hex(romdat(arrayAdjuster + SceneModeInfo.gfxLoadId_Ptr)), 2)
                End If

                GlIdUD.Enabled = SceneModeInfo.canChangeId
                If SceneModeInfo.canChangeId = True Then
                    ToolTip1.SetToolTip(GlIdLabel, "")
                Else
                    ToolTip1.SetToolTip(GlIdLabel, "Sorry, changing the value for the current screen is disabled because of side-effects.")
                End If
            Else

                If (SceneModeInfo.other_Ptr1) Then
                    SetUDCool(ScCHRUD(0), Hex(romdat(arrayAdjuster + SceneModeInfo.other_Ptr1)), 2)
                End If
                If (SceneModeInfo.other_Ptr2) Then
                    SetUDCool(ScCHRUD(1), Hex(romdat(arrayAdjuster + SceneModeInfo.other_Ptr2)), 2)
                End If

            End If
        End If
    End Sub

    Private Sub HideOrShow()
        Dim showSceneMM35, showSceneMM4 As Boolean
        Dim a As Integer

        'Continue point edit
        If (gem = 3) Or (scenemode = True) Then
            MPFrame.Visible = False
            BPFrame.Visible = False
        Else
            MPFrame.Visible = True
            BPFrame.Visible = True
        End If

        'Multi-path edit
        If (scenemode = False) And ((gem = 1) Or (gem = 2)) Then
            MuPFrame.Visible = True
        Else
            MuPFrame.Visible = False
        End If

        'BGM change
        MusicLabel.Visible = Not scenemode
        MusicCombo.Visible = Not scenemode
        MusicUD.Visible = Not scenemode

        'SBD Bank Change
        If (scenemode = False) And ((gem = 0) Or (gem = 2)) Then
            SBDLab.Visible = True
            SBDCombo.Visible = True
            SBDUD.Visible = True
        Else
            SBDLab.Visible = False
            SBDCombo.Visible = False
            SBDUD.Visible = False
        End If

        'Scene Mode hide/show's

        SceneFrame.Visible = scenemode

        If (gem = 0) Or (gem = 2) Then
            showSceneMM35 = scenemode
            showSceneMM4 = False
        Else
            showSceneMM35 = False
            showSceneMM4 = scenemode
        End If

        GlIdLabel.Visible = showSceneMM4
        GlIdUD.Visible = showSceneMM4
        For a = 0 To 1
            ScCHRLab(a).Visible = showSceneMM35
        Next a

        _ScCHRUD_0.Visible = showSceneMM35
        _ScCHRUD_1.Visible = showSceneMM35

    End Sub

    Public Sub Update_MultiPath()
        Dim a As Integer
        SetUDCool(MuPIDUD, Hex(multipath), 2)
        'If Asc(mid$(romdat, offs(gem, 21) + (multipath * 4) + a, 1)) = &HFF Then
        '    MuPDisCheck.Value = 1
        'Else
        '    MuPDisCheck.Value = 0
        'End If
        a = ((romdat(arrayAdjuster + offs(gem, 21) + (multipath * 4) + a) And &H80S) = &H80S)
        SetCheckCool(MuPDisCheck, (a - a - a))
        For a = 0 To 3 '(offs(gem, 23) - 1)
            SetUDCool(MuPUD(a), Hex(romdat(arrayAdjuster + offs(gem, 21) + (multipath * 4) + a)), 2)
        Next a
        If gem < 2 Then
            MuPDTypeLab.Text = "(" & SrcString(rdata(dspa(d_dtypedat34) + Int(romdat(arrayAdjuster + offs(gem, 21) + (multipath * 4) + 1) / &H10S))) & " x " & CStr(CShort(romdat(arrayAdjuster + offs(gem, 21) + (multipath * 4) + 1) And &HFS) + 1) & ")"
        Else
            MuPDTypeLab.Text = "(" & SrcString(rdata(dspa(d_dtypedat5) + Int(romdat(arrayAdjuster + offs(gem, 21) + (multipath * 4) + 1) / &H20S))) & " x " & CStr(CShort(romdat(arrayAdjuster + offs(gem, 21) + (multipath * 4) + 1) And &H1FS) + 1) & ")"
        End If
    End Sub

    Private Sub MiscEd_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        Dim KeyCode As Short = eventArgs.KeyCode
        Dim Shift As Short = eventArgs.KeyData \ &H10000
        MFLE_Main.Global_KeyDown(KeyCode, Shift)
    End Sub

    Private Sub MuPDisCheck_CheckStateChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MuPDisCheck.CheckStateChanged
        Dim a As Integer
        If MuPDisCheck.Tag <> "" Then Exit Sub
        a = ((romdat(arrayAdjuster + offs(gem, 21) + (multipath * 4) + 0) And &H80S) = &H80S)
        romdat(arrayAdjuster + offs(gem, 21) + (multipath * 4) + 0) = ((romdat(arrayAdjuster + offs(gem, 21) + (multipath * 4) + 0) And &H7FS) Or (CShort((a - a - a) Xor 1) * &H80S))
        Update_MultiPath()
    End Sub

    Private Sub MusicCombo_SelectedIndexChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MusicCombo.SelectedIndexChanged
        If MusicCombo.Tag <> "" Then Exit Sub
        romdat(arrayAdjuster + offs(gem, 22) + level) = MusicCombo.SelectedIndex
    End Sub

    Private Sub SBDCombo_SelectedIndexChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles SBDCombo.SelectedIndexChanged
        If SBDCombo.Tag <> "" Then Exit Sub
        romdat(arrayAdjuster + offs(gem, 26) + level) = SBDCombo.SelectedIndex
        MFLE_Main.Update_Level()
    End Sub






    'NumericUpDown
    '================


    Private Sub GlIdUD_ActionUponNewValue()
        If GlIdUD.Tag <> "" Then Exit Sub
        If GlIdUD_ValuePrevious = GlIdUD.Value Then Exit Sub

        GlIdUD_ValuePrevious = GlIdUD.Value

        romdat(arrayAdjuster + SceneModeInfo.gfxLoadId_Ptr) = Dec((GlIdUD.Text)) And &HFFS
        MFLE_Main.Update_Scrn()
    End Sub

    Private Sub GlIdUD_ValueChanged(sender As Object, e As EventArgs) Handles GlIdUD.ValueChanged
        If UpdateUDCool(sender) Then
            ' When here, Value was validated
            GlIdUD_ActionUponNewValue()
        End If
    End Sub

    Private Sub GlIdUD_KeyUp(sender As Object, e As KeyEventArgs) Handles GlIdUD.KeyUp
        ' Set new value (with validations)
        SetUDCool(CType(sender, NumericUpDown), sender.Text, 2)

        ' When here, Value was validated
        GlIdUD_ActionUponNewValue()
    End Sub

    Private Sub MPCheckScreenUD_ActionUponNewValue(sender As Object)
        Dim Index As Short = 0

        For Each nuemricUpDown As NumericUpDown In MPCheckScreenUD
            If nuemricUpDown.Name = sender.Name Then
                Exit For
            End If
            Index += 1
        Next

        If MPCheckScreenUD(Index).Tag <> "" Then Exit Sub

        If MPCheckScreenUD_ValuePrevious(Index) = MPCheckScreenUD(Index).Value Then Exit Sub

        MPCheckScreenUD_ValuePrevious(Index) = MPCheckScreenUD(Index).Value

        Dim a As Integer
        a = Index
        romdat(arrayAdjuster + rdata(dspa(d_ex) + 32) + (level * 2) + a) = (Dec(MPCheckScreenUD(Index).Text) And &HFFS)
        SetUDCool(MPCheckScreenUD(a), Hex(romdat(arrayAdjuster + rdata(dspa(d_ex) + 32) + (level * 2) + a)), 2)
    End Sub

    Private Sub MPCheckScreenUD_ValueChanged(sender As Object, e As EventArgs) Handles _MPCheckScreenUD_0.ValueChanged, _MPCheckScreenUD_1.ValueChanged
        If UpdateUDCool(sender) Then
            ' When here, Value was validated
            MPCheckScreenUD_ActionUponNewValue(sender)
        End If
    End Sub

    Private Sub MPCheckScreenUD_KeyUp(sender As Object, e As KeyEventArgs) Handles _MPCheckScreenUD_0.KeyUp, _MPCheckScreenUD_1.KeyUp
        ' Set new value (with validations)
        SetUDCool(CType(sender, NumericUpDown), sender.Text, 2)

        ' When here, Value was validated
        MPCheckScreenUD_ActionUponNewValue(sender)
    End Sub

    Private Sub MPUD_ActionUponNewValue(sender As Object)
        Dim Index As Short = 0

        For Each nuemricUpDown As NumericUpDown In MPUD
            If nuemricUpDown.Name = sender.Name Then
                Exit For
            End If
            Index += 1
        Next

        If MPUD(Index).Tag <> "" Then Exit Sub

        If MPUD_ValuePrevious(Index) = MPUD(Index).Value Then Exit Sub

        MPUD_ValuePrevious(Index) = MPUD(Index).Value



        Dim a, c As Integer
        Dim gem0boxoffst As Object
        gem0boxoffst = New Object() {51, 50, 52}
        Select Case gem
            Case 0
                a = Int(Index / 4)
                c = gem0boxoffst(Index And 3)
                romdat(arrayAdjuster + offs(gem, c) + a) = (Dec(MPUD(Index).Text) And &HFFS)
                SetUDCool(MPUD(Index), Hex(romdat(arrayAdjuster + offs(gem, c) + a)), 2)
            Case 1
                a = Index
                romdat(arrayAdjuster + rdata(dspa(d_ex) + 31) + (level * 8) + a) = (Dec(MPUD(Index).Text) And &HFFS)
                SetUDCool(MPUD(a), Hex(romdat(arrayAdjuster + rdata(dspa(d_ex) + 31) + (level * 8) + a)), 2)
            Case 2
                a = Int(Index / 4)
                c = (Index And 3)
                romdat(arrayAdjuster + rdata(dspa(d_ex) + 33) + (level * 6) + (a * 3) + c) = (Dec(MPUD(Index).Text) And &HFFS)
                SetUDCool(MPUD(Index), Hex(romdat(arrayAdjuster + rdata(dspa(d_ex) + 33) + (level * 6) + (a * 3) + c)), 2)
        End Select
    End Sub

    Private Sub MPUD_ValueChanged(sender As Object, e As EventArgs) Handles _MPUD_0.ValueChanged, _MPUD_1.ValueChanged, _MPUD_2.ValueChanged, _MPUD_3.ValueChanged, _MPUD_7.ValueChanged, _MPUD_6.ValueChanged, _MPUD_5.ValueChanged, _MPUD_4.ValueChanged
        If UpdateUDCool(sender) Then
            ' When here, Value was validated
            MPUD_ActionUponNewValue(sender)
        End If
    End Sub

    Private Sub MPUD_KeyUp(sender As Object, e As KeyEventArgs) Handles _MPUD_0.KeyUp, _MPUD_1.KeyUp, _MPUD_2.KeyUp, _MPUD_3.KeyUp, _MPUD_7.KeyUp, _MPUD_6.KeyUp, _MPUD_5.KeyUp, _MPUD_4.KeyUp
        ' Set new value (with validations)
        SetUDCool(CType(sender, NumericUpDown), sender.Text, 2)

        ' When here, Value was validated
        MPUD_ActionUponNewValue(sender)
    End Sub

    Private Sub MuPIDUD_ActionUponNewValue()
        If MuPIDUD.Tag <> "" Then Exit Sub
        If MuPIDUD_ValuePrevious = MuPIDUD.Value Then Exit Sub

        multipath = VWidth(Dec((MuPIDUD.Text)) And &HFFS, 0, offs(gem, 23))
        Update_MultiPath()
    End Sub
    Private Sub MuPIDUD_ValueChanged(sender As Object, e As EventArgs) Handles MuPIDUD.ValueChanged
        If UpdateUDCool(sender) Then
            ' When here, Value was validated
            MuPIDUD_ActionUponNewValue()
        End If
    End Sub
    Private Sub MuPIDUD_KeyUp(sender As Object, e As KeyEventArgs) Handles MuPIDUD.KeyUp
        ' Set new value (with validations)
        SetUDCool(CType(sender, NumericUpDown), sender.Text, 2)

        ' When here, Value was validated
        MuPIDUD_ActionUponNewValue()
    End Sub
    Private Sub MuPUD_ActionUponNewValue(sender As Object)
        Dim Index As Short = 0

        For Each nuemricUpDown As NumericUpDown In MuPUD
            If nuemricUpDown.Name = sender.Name Then
                Exit For
            End If
            Index += 1
        Next

        If MuPUD(Index).Tag <> "" Then Exit Sub

        If MuPUD_ValuePrevious(Index) = MuPUD(Index).Value Then Exit Sub

        MuPUD_ValuePrevious(Index) = MuPUD(Index).Value

        romdat(arrayAdjuster + offs(gem, 21) + (multipath * 4) + Index) = (Dec(MuPUD(Index).Text) And &HFFS)
        Update_MultiPath()
    End Sub

    Private Sub MuPUD_ValueChanged(sender As Object, e As EventArgs) Handles _MuPUD_0.ValueChanged, _MuPUD_1.ValueChanged, _MuPUD_2.ValueChanged, _MuPUD_3.ValueChanged
        If UpdateUDCool(sender) Then
            ' When here, Value was validated
            MuPUD_ActionUponNewValue(sender)
        End If
    End Sub

    Private Sub MuPUD_KeyUp(sender As Object, e As KeyEventArgs) Handles _MuPUD_0.KeyUp, _MuPUD_1.KeyUp, _MuPUD_2.KeyUp, _MuPUD_3.KeyUp
        ' Set new value (with validations)
        SetUDCool(CType(sender, NumericUpDown), sender.Text, 2)

        ' When here, Value was validated
        MuPUD_ActionUponNewValue(sender)
    End Sub

    Private Sub ScCHRUD_ActionUponNewValue(sender As Object)
        Dim Index As Short = 0

        For Each nuemricUpDown As NumericUpDown In ScCHRUD
            If nuemricUpDown.Name = sender.Name Then
                Exit For
            End If
            Index += 1
        Next

        If ScCHRUD_ValuePrevious(Index) = ScCHRUD(Index).Value Then Exit Sub

        ScCHRUD_ValuePrevious(Index) = ScCHRUD(Index).Value

        If Index = 0 Then
            romdat(arrayAdjuster + SceneModeInfo.other_Ptr1) = Dec(ScCHRUD(0).Text) And &HFFS
        Else
            romdat(arrayAdjuster + SceneModeInfo.other_Ptr2) = Dec(ScCHRUD(1).Text) And &HFFS
        End If
        MFLE_Main.Update_Scrn()
    End Sub

    Private Sub ScCHRUD_ValueChanged(sender As Object, e As EventArgs) Handles _ScCHRUD_0.ValueChanged, _ScCHRUD_1.ValueChanged
        If UpdateUDCool(sender) Then
            ' When here, Value was validated
            ScCHRUD_ActionUponNewValue(sender)
        End If
    End Sub

    Private Sub ScCHRUD_KeyUp(sender As Object, e As KeyEventArgs) Handles _ScCHRUD_0.KeyUp, _ScCHRUD_1.KeyUp
        ' Set new value (with validations)
        SetUDCool(CType(sender, NumericUpDown), sender.Text, 2)

        ' When here, Value was validated
        ScCHRUD_ActionUponNewValue(sender)
    End Sub























    Private Sub SBDUD_UpClick()
        romdat(arrayAdjuster + offs(gem, 26) + level) = VWidth(romdat(arrayAdjuster + offs(gem, 26) + level) - 1, 0, offs(gem, 62))
        'SetComboCool SBDCombo, romdat(arrayAdjuster + offs(gem, 26) + level)
        MFLE_Main.Update_Level()
    End Sub

    Private Sub SBDUD_DownClick()
        romdat(arrayAdjuster + offs(gem, 26) + level) = VWidth(romdat(arrayAdjuster + offs(gem, 26) + level) + 1, 0, offs(gem, 62))
        'SetComboCool SBDCombo, romdat(arrayAdjuster + offs(gem, 26) + level)
        MFLE_Main.Update_Level()
    End Sub

    Private Sub SBDUD_ValueChanged(sender As Object, e As EventArgs) Handles SBDUD.ValueChanged
        ' We only allow it to go to 1 or -1 to check if it's a Up/Down click. Then we set it back to 0.
        '   So when we set it to 0, this will call again this function and we ignore this call
        If SBDUD.Value <> 0 Then
            If SBDUD_ValuePrevious < SBDUD.Value Then SBDUD_DownClick()
            If SBDUD_ValuePrevious > SBDUD.Value Then SBDUD_UpClick()

            ' Always set again value to 0
            SBDUD.Value = 0
            SBDUD_ValuePrevious = SBDUD.Value
        End If
    End Sub

    Private Sub MusicUD_UpClick()
        romdat(arrayAdjuster + offs(gem, 22) + level) = VWidth(romdat(arrayAdjuster + offs(gem, 22) + level) - 1, 0, offs(gem, 57) - 1)
        SetComboCool(MusicCombo, romdat(arrayAdjuster + offs(gem, 22) + level))
    End Sub

    Private Sub MusicUD_DownClick()
        romdat(arrayAdjuster + offs(gem, 22) + level) = VWidth(romdat(arrayAdjuster + offs(gem, 22) + level) + 1, 0, offs(gem, 57) - 1)
        SetComboCool(MusicCombo, romdat(arrayAdjuster + offs(gem, 22) + level))
    End Sub

    Private Sub MusicUD_ValueChanged(sender As Object, e As EventArgs) Handles MusicUD.ValueChanged
        ' We only allow it to go to 1 or -1 to check if it's a Up/Down click. Then we set it back to 0.
        '   So when we set it to 0, this will call again this function and we ignore this call
        If MusicUD.Value <> 0 Then
            If MusicUD_ValuePrevious < MusicUD.Value Then MusicUD_DownClick()
            If MusicUD_ValuePrevious > MusicUD.Value Then MusicUD_UpClick()

            ' Always set again value to 0
            MusicUD.Value = 0
            MusicUD_ValuePrevious = MusicUD.Value
        End If
    End Sub
End Class