Option Explicit On

Module MegaFLEX_Main
    Private ReadOnly Release As Boolean = True

    Private Sub MainCode()
        RefreshLock = False
        ShuttingDown = False
        RefreshPalLock = False
        PalChartToFront = False
        PALAnimEnable = 0
        CHRAnimEnable = 0

        ignore_scrlayout = False
        palsetChangeType = 0

        ANDtbl(0) = &H80S
        ANDtbl(1) = &H40S
        ANDtbl(2) = &H20S
        ANDtbl(3) = &H10S
        ANDtbl(4) = &H8S
        ANDtbl(5) = &H4S
        ANDtbl(6) = &H2S
        ANDtbl(7) = &H1S

        Common.Init(True)

        ChDir(My.Application.Info.DirectoryPath)
        LoadCfg(My.Application.Info.DirectoryPath & "\megaflex.cfg")

        ReloadNESPAL()

        If GetCfg("tsatbl_2x") = 1 Then
            tsatbl_blockwidthY = 8
            tsatbl_blockwidthX = 8
        Else
            If GetCfg("tsatbl_8x32") = 1 Then
                tsatbl_blockwidthY = 32
                tsatbl_blockwidthX = 8
            Else
                tsatbl_blockwidthY = 16
                tsatbl_blockwidthX = 16
            End If
        End If

        palsetWidth = &H14S

        MFLE_Decl.Initialize()

        MFLE_Main.Manual_Init()

        MFLE_Main.Show()

        MainTimedLoop()
    End Sub

    Public Sub Main()
        If Release Then
            Try
                MainCode()
            Catch ex As Exception
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Dim result As DialogResult = MessageBox.Show("Disable Autoloading modes?.", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question)

                If result = DialogResult.Yes Then
                    SetCfg("auto_loadrom", "")

                    Dim autoLoadASM_ModeConfig As String = GetCfg("auto_loadASM_Mode", False)

                    If (autoLoadASM_ModeConfig <> "") Then
                        SetCfg("auto_loadrom", "")
                    End If
                End If
            End Try
        Else
            MainCode()
        End If

    End Sub

    Public Sub MainTimedLoop()
        Dim a, Interval, Switch As Integer
        Dim checkDateStr As String
        Dim stopwatch As New Diagnostics.Stopwatch()

        checkfilechange_flag = GetCfg("checkfilechange")

        Interval = 16
        Switch = 0

        Do
            'So PalChart is always brought to front with its Parent Form
            If PalChartToFront And PalChart.Visible Then
                If palchartClaim = Palchart_Claim.PalEd Then
                    If PalEd.Visible Then
                        PalChart.BringToFront()
                        PalEd.BringToFront() ' Else some control of PalEd will be unclickable
                        PalChartToFront = False
                    End If
                Else
                    If EnemEd.Visible Then
                        PalChart.BringToFront()
                        EnemEd.BringToFront() ' Else some control of EnemEd will be unclickable
                        PalChartToFront = False
                    End If
                End If
            End If

            PalChartToFront = False

            If ShuttingDown = True Then Exit Sub
            stopwatch.Reset()
            stopwatch.Start()

            If checkfilechange_flag = 1 Then
                checkDateStr = CStr(FileDateTime(FileName))
                If (checkDateStr <> EditFile_SaveDateStr) Then
                    'MFLE_Main.SetFocus
                    'MFLE_Main.Show
                    a = MFLE_Main.GiveReloadQ
                    EditFile_SaveDateStr = CStr(FileDateTime(FileName))
                    If (a And 1) = 0 Then
                        MFLE_Main.File_ReLoad_Click()
                    End If
                End If
            End If

            ' MsgBox EditFile_SaveDateStr
            'a = FileDateTime(FileName)
            '
            'End
            'Change 03-31-11 (Matrixz): Made it to work in more direct way.
            If PALAnimEnable > 0 Then MFLE_Main.PalAnim_Handle()
            If (CHRAnimEnable > 0) And (CHR_Anim_Pause = False) Then MFLE_Main.CHRAnim_Handle()
            If EnemEd.Visible = True Then
                If EnemEd.AnimCheck.CheckState = 1 Then
                    EnemEd.SprAnimTB.Text = CStr(Switch)
                End If
            End If
            Switch = Switch Xor 1

            Application.DoEvents()
            Do While stopwatch.ElapsedMilliseconds < Interval
                ' Ensure we don't start doing code when too little time is left
                If (stopwatch.ElapsedMilliseconds + 5) < Interval Then
                    Application.DoEvents()
                End If
            Loop
        Loop

    End Sub

    Public Sub ReloadNESPAL()
        Dim eofMet As Boolean = False
        Dim PathBackup As String
        Dim lg, hg, a, hr, hb, lr, lb As Integer
        Dim g, r, b As Byte
        Dim darkGreenPercent, darkRedPercent, darkBluePercent As Integer
        Dim darkGreenRate, darkRedRate, darkBlueRate As Single

        PathBackup = CurDir()
        palfile = GetCfg("palfile")
        darkRedPercent = GetCfg("darkpal_percent_r")
        darkGreenPercent = GetCfg("darkpal_percent_g")
        darkBluePercent = GetCfg("darkpal_percent_b")
        darkRedRate = darkRedPercent / 100
        darkGreenRate = darkGreenPercent / 100
        darkBlueRate = darkBluePercent / 100

        If Not IO.File.Exists(palfile) Then
            ' Maybe computer was changed so check if same file exist in current directory
            '   Fetch file name
            Dim substring As String = palfile.Substring(palfile.LastIndexOf("\") + 1)
            ' Combine it with current path
            substring = CurDir() + "\" + substring

            If Not IO.File.Exists(substring) Then
                MessageBox.Show("Palette file not found, please select it." + vbNewLine + "Default one is normally fr_nesB.pal in program's folder.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Config.PALBrowse()

                palfile = GetCfg("palfile")
                If Not IO.File.Exists(palfile) Then
                    Throw New Exception("Need a valid palette file.")
                Else
                    MessageBox.Show("Now will need to select ROM.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                End If
            Else
                palfile = substring
            End If

            SetCfg("palfile", palfile)
        End If

            FileOpen(1, palfile, OpenMode.Binary)
        For a = 0 To &HFFS
            'Always reset to 0 value so if a EOF is met, they are already 0
            r = 0
            g = 0
            b = 0

            If (eofMet = False) Then
                Try
                    FileGet(1, r)
                    FileGet(1, g)
                    FileGet(1, b)
                Catch ex As Exception
                    eofMet = True
                End Try
            End If
            lr = r
            lg = g
            lb = b
            NESPAL(a) = RGB(b, g, r)
            'dr = VWidth(r - 70, 0, 255)
            'dg = VWidth(g - 70, 0, 255)
            'db = VWidth(b - 70, 0, 255)
            'NESPALD(a) = RGB(db, dg, dr)
            NESPALD(a) = RGB(Int(CSng(lb) * darkRedRate), Int(CSng(lg) * darkGreenRate), Int(CSng(lr) * darkBlueRate))
            'NESPALD(a) = RGB(Int(b / 1.7), Int(g / 1.7), Int(r / 1.7))
            hr = VWidth(lr + 80, 0, 255)
            hg = VWidth(lg + 80, 0, 255)
            hb = VWidth(lb + 80, 0, 255)
            NESPALL(a) = RGB(hb, hg, hr)
        Next a
        FileClose(1)
        ChDir(PathBackup)
    End Sub

    Public Function GetScreen() As Byte
        Dim uselayout As Boolean
        uselayout = True
        If scenemode = True Then
            If gem = 1 Then
                uselayout = True
            Else
                uselayout = False
            End If
        End If
        If ignore_scrlayout = True Then uselayout = False
        If gem = 3 Then uselayout = False
        If uselayout = True Then
            GetScreen = romdat(arrayAdjuster + offs(gem, 7) + curscreen)
        Else
            GetScreen = curscreen ' Since there is no screen preset
        End If
    End Function

    Public Function CalcTSA(Optional ByRef blockY As Integer = -1, Optional ByRef blockX As Integer = -1) As Byte
        If (blockY < 0) Then blockY = curblockY
        If (blockX < 0) Then blockX = curblockX
        If GetCfg("tsatbl_2x") = 0 Then
            CalcTSA = (blockY * tsatbl_blockwidthX) + blockX
        Else
            CalcTSA = (blockpage * 64) + (blockY * 8) + blockX
        End If
    End Function

    Public Sub SetCurTSA(ByRef block As Integer, Optional ByRef redrawEverything As Integer = False)
        Dim pageChange As Boolean
        If GetCfg("tsatbl_2x") = 0 Then
            pageChange = False
            oldblockY = curblockY
            oldblockX = curblockX
            curblockY = Int(block / tsatbl_blockwidthX)
            curblockX = block - (curblockY * tsatbl_blockwidthX)
        Else
            If (Not Int(block / 64) = blockpage) Or (redrawEverything = True) Then
                pageChange = True
                blockpage = Int(block / 64)
            Else
                pageChange = False
                oldblockY = curblockY
                oldblockX = curblockX
            End If
            curblockY = Int((block - (blockpage * 64)) / 8)
            curblockX = block - (blockpage * 64) - (curblockY * 8)
        End If
        If redrawEverything = True Then
            If MetatileTable.Visible Then MetatileTable.Update_Frm()
        Else
            If (pageChange = True) Then
                If MetatileTable.Visible Then MetatileTable.Update_Level()
            Else
                If MetatileTable.Visible Then MetatileTable.Update_CurBlock()
            End If
        End If
    End Sub

    Public Sub SpriteDraw(ByRef sprbank As Integer, ByRef spr As Integer, ByRef frame As Integer, ByRef x As Integer, ByRef y As Integer, ByRef palbase As Integer, ByRef bmi As BITMAPINFO, ByRef cl_bmi As BITMAPINFO, Optional ByRef clear As Integer = 0)
        Dim coordref, frameset, offL, bankoff, offH, sprframe, tmp, coorpage As Integer
        Dim froff, sproff, coff As Integer
        Dim dstchrbnk, srcchrbnk As Integer

        Select Case gem
            Case 0 'MEGA MAN 3
                offL = romdat(arrayAdjuster + offs(gem, 43 + sprbank) + spr)
                offH = romdat(arrayAdjuster + offs(gem, 46 + sprbank) + spr)
                offH = (offH - &H80S) + offs(gem, 38 + sprbank)
                sproff = (offH * 256) + offL + &H11S
                sprframe = romdat(arrayAdjuster + sproff + 2 + frame)
                offL = romdat(arrayAdjuster + offs(gem, 28 + sprbank) + sprframe)
                offH = romdat(arrayAdjuster + offs(gem, 31 + sprbank) + sprframe)
                offH = (offH - &H80S) + offs(gem, 38 + sprbank) '&H340
                froff = (offH * 256) + offL + &H11S
                tmp = romdat(arrayAdjuster + froff)
                If (tmp And &H80S) Then coorpage = 1 Else coorpage = 0
                coordref = romdat(arrayAdjuster + froff + 1)
                offL = romdat(arrayAdjuster + offs(gem, 34 + coorpage) + coordref)
                offH = romdat(arrayAdjuster + offs(gem, 36 + coorpage) + coordref)
                offH = (offH - &HA0S) + offs(gem, 41 + coorpage)
                coff = (offH * 256) + offL + &H11S
                DrawSpriteTile(tmp, froff, coff, 0, 1, 2, 3, clear, palbase, x, y, bmi, cl_bmi)

            Case 1 'MEGA MAN 4
                bankoff = ((sprbank - 1) * &H2000S) + &H11S
                offL = romdat(arrayAdjuster + offs(gem, 43) + bankoff + spr)
                offH = romdat(arrayAdjuster + offs(gem, 46) + bankoff + spr)
                sproff = ((offH - &H80S) * 256) + offL + bankoff
                sprframe = romdat(arrayAdjuster + sproff + 2 + frame)
                If romdat(arrayAdjuster + sproff) >= &H80S Then frameset = 1 Else frameset = 0
                offL = romdat(arrayAdjuster + offs(gem, 31 + frameset) + bankoff + sprframe)
                offH = romdat(arrayAdjuster + offs(gem, 33 + frameset) + bankoff + sprframe)
                froff = ((offH - &H80S) * 256) + offL + bankoff
                tmp = romdat(arrayAdjuster + froff)
                coordref = romdat(arrayAdjuster + froff + 1)
                offL = romdat(arrayAdjuster + offs(gem, 35) + bankoff + coordref)
                offH = romdat(arrayAdjuster + offs(gem, 36) + bankoff + coordref)
                coff = ((offH - &H80S) * 256) + offL + bankoff
                DrawSpriteTile(tmp, froff, coff, 0, 1, 2, 3, clear, palbase, x, y, bmi, cl_bmi)

            Case 2 'MEGA MAN 5
                bankoff = (sprbank * &H2000S) + &H11S
                offL = romdat(arrayAdjuster + offs(gem, 43) + bankoff + spr)
                offH = romdat(arrayAdjuster + offs(gem, 46) + bankoff + spr)
                sproff = ((offH - &H80S) * 256) + offL + bankoff
                sprframe = romdat(arrayAdjuster + sproff + 2 + frame)
                If romdat(arrayAdjuster + sproff) >= &H80S Then frameset = 1 Else frameset = 0
                offL = romdat(arrayAdjuster + offs(gem, 31 + frameset) + bankoff + sprframe)
                offH = romdat(arrayAdjuster + offs(gem, 33 + frameset) + bankoff + sprframe)
                froff = ((offH - &H80S) * 256) + offL + bankoff
                dstchrbnk = romdat(arrayAdjuster + froff + 3) And &HC0S
                srcchrbnk = romdat(arrayAdjuster + froff)
                If dstchrbnk = &H40S Then GoTo edmm5_skipsetgfx
                For a = 0 To &H3FS
                    chrmap(&H100S + dstchrbnk + a) = (srcchrbnk * &H400S) + offs(gem, 2) + (a * &H10S)
                    If dstchrbnk = &H80S Then
                        chrmap(&H140S + dstchrbnk + a) = ((srcchrbnk + 1) * &H400S) + offs(gem, 2) + (a * &H10S)
                    End If
                Next a
edmm5_skipsetgfx:
                tmp = romdat(arrayAdjuster + froff + 1)
                coordref = romdat(arrayAdjuster + froff + 2)
                offL = romdat(arrayAdjuster + offs(gem, 35) + bankoff + coordref)
                offH = romdat(arrayAdjuster + offs(gem, 36) + bankoff + coordref)
                coff = ((offH - &H80S) * 256) + offL + bankoff
                DrawSpriteTile(tmp, froff, coff, 0, 1, 3, 4, clear, palbase, x, y, bmi, cl_bmi)

            Case 3 'MEGA MAN 6

                bankoff = (sprbank * &H2000S) + &H11S
                offL = romdat(arrayAdjuster + offs(gem, 43) + bankoff + spr)
                offH = romdat(arrayAdjuster + offs(gem, 46) + bankoff + spr)
                sproff = ((offH - &H80S) * 256) + offL + bankoff
                sprframe = romdat(arrayAdjuster + sproff + 1 + (frame * 2))
                If romdat(arrayAdjuster + sproff) >= &H80S Then frameset = 1 Else frameset = 0
                offL = romdat(arrayAdjuster + offs(gem, 31 + frameset) + bankoff + sprframe)
                offH = romdat(arrayAdjuster + offs(gem, 33 + frameset) + bankoff + sprframe)
                froff = ((offH - &H80S) * 256) + offL + bankoff
                tmp = romdat(arrayAdjuster + froff + 0)
                coordref = romdat(arrayAdjuster + froff + 1)
                offL = romdat(arrayAdjuster + offs(gem, 35) + bankoff + coordref)
                offH = romdat(arrayAdjuster + offs(gem, 36) + bankoff + coordref)
                coff = ((offH - &H80S) * 256) + offL + bankoff
                DrawSpriteTile(tmp, froff, coff, 0, 1, 2, 3, clear, palbase, x, y, bmi, cl_bmi)

        End Select
    End Sub

    Private Sub DrawSpriteTile(ByRef count As Integer, ByRef froff As Integer, ByRef coff As Integer, ByRef base_ry As Integer, ByRef base_rx As Integer, ByRef base_tile As Integer, ByRef base_palflip As Integer, ByRef clear As Integer, ByRef palbase As Integer, ByRef x As Integer, ByRef y As Integer, ByRef bmi As BITMAPINFO, ByRef cl_bmi As BITMAPINFO)
        Dim fy, ry, tile, a, b, pal, rx, fx As Integer
        For a = (count And &H7FS) To 0 Step -1
            b = (a * 2)
            tile = romdat(arrayAdjuster + froff + b + base_tile)
            pal = romdat(arrayAdjuster + froff + b + base_palflip) And 3
            If romdat(arrayAdjuster + froff + b + base_palflip) And &H80S Then fy = 1 Else fy = 0
            If romdat(arrayAdjuster + froff + b + base_palflip) And &H40S Then fx = 1 Else fx = 0
            ry = romdat(arrayAdjuster + coff + b + base_ry) + 1
            rx = romdat(arrayAdjuster + coff + b + base_rx)
            If ry >= &H80S Then ry = -1 - (&HFFS - ry)
            If rx >= &H80S Then rx = -1 - (&HFFS - rx)
            If clear Then
                RenderModule.ClearSprTile(bmi, chrmap(tile + &H100S), x + rx, y + ry, fy, fx, cl_bmi)
            Else
                RenderModule.DrawSprTile(bmi, chrmap(tile + &H100S), x + rx, y + ry, fy, fx, pal + palbase)
            End If
        Next a

        bmi.bytesRGB_UpdatedSinceLastRender = True
    End Sub

#Region "WasALreadyUnused"
    'Public Function AscR(ByRef str As String)
    'Dim a, b, c
    'a = VarPtr(str)
    'c = VarPtr(b)
    'CopyMem b, str, 1
    'AscR = b
    'End Function
#End Region
End Module