Option Explicit On

Imports MegaFLE_X.clsDialog
Friend Class Config
	Inherits System.Windows.Forms.Form

	'Objects that group many items
	'   RadioButton
	Private TsaTRes() As RadioButton

	Private Sub Form_Initialize()
		'Objects that group many items
		'   RadioButton
		TsaTRes = New RadioButton() {_TsaTRes_0, _TsaTRes_1, _TsaTRes_2}
	End Sub

	'Calling it ensure constructor above is called
	Public Sub Manual_Init()
		ChkAutoloadROM.Checked = If(GetCfg("auto_loadrom") = "", 0, 1)
	End Sub

	Public Sub SetLocation(y As Integer)
		Me.Location = New Point(Me.Location.X, y)
	End Sub

	Public Sub Update_Frm()
		SetTBCoolText(EmuTB, GetCfg("emufname"))
		SetTBCoolText(PALTB, GetCfg("palfile"))
		SetTBCoolText(ShellTB, GetCfg("shellcmd"))
		SetCheckCool(DetectChangeCheck, GetCfg("checkfilechange"))
		SetCheckCool(PACheck, GetCfg("palanim"))
		SetCheckCool(CACheck, GetCfg("chranim"))
		SetCheckCool(EffSprSimCheck, GetCfg("effsprsim"))
		SetCheckCool(TileEdGridCheck, GetCfg("tileed_grid"))
		SetCheckCool(TSAEdGridCheck, GetCfg("tsaed_grid"))
		SetCheckCool(ScrEdGridCheck, GetCfg("scrned_grid"))
		SetCheckCool(Scroll0Check, GetCfg("alwaysskipscrollzero"))
		SetCheckCool(ScrollSearchCheck, GetCfg("autoscrollsearch"))
		SetCheckCool(SBDAlg2Check, GetCfg("sbdspecial_ignorebottomrow"))
		SetCheckCool(SortScrCheck, GetCfg("auto_enemscrsort"))
		SetCheckCool(SortXCheck, GetCfg("auto_enemxsort"))
		SetCheckCool(ScrSprCheck, GetCfg("auto_scrsprsort"))
		SetCheckCool(ScrSprAllCheck, GetCfg("scrsprsort_all"))
		SetCheckCool(StealFocusCheck, GetCfg("enemed_scrstealfocus"))
		SetCheckCool(EnemCountFmtCheck, GetCfg("enemcountfmthex"))
		SetCheckCool(MM5GManCheck, GetCfg("gravityman_hardchranim_emu"))
		SetCheckCool(MM4RainbowCheck, GetCfg("ringman_palanim_emu"))
		If GetCfg("tsatbl_2x") = 1 Then
			SetOptCool(TsaTRes(0), False)
			SetOptCool(TsaTRes(1), False)
			SetOptCool(TsaTRes(2), True)
		Else
			SetOptCool(TsaTRes(2), False)
			If GetCfg("tsatbl_8x32") = 1 Then
				SetOptCool(TsaTRes(1), True)
			Else
				SetOptCool(TsaTRes(0), True)
			End If
		End If

		If GetCfg("enemcountfmthex") = 1 Then
			EnemEd.CurEnemUD.Hexadecimal = True
		Else
			EnemEd.CurEnemUD.Hexadecimal = False
		End If
		'SetOptCool DatLoadOpt(GetCfg("datloadtype")), True
		'SetTBCoolOLD SRCTB, GetCfg("datfile")
	End Sub

	Private Sub Config_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
		e.Cancel = True

		Me.Hide()
	End Sub
#Region "Events"
#Region "CheckBoxes"
	Private Sub CACheck_CheckStateChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles CACheck.CheckStateChanged
		If CACheck.Tag <> "" Then Exit Sub
		SetCfg(("chranim"), (CACheck.CheckState))
		CHRAnimEnable = GetCfg("chranim")
		Me.Update_Frm()
	End Sub

	Private Sub ChkAutoloadROM_CheckStateChanged(sender As Object, e As EventArgs) Handles ChkAutoloadROM.CheckStateChanged
		Dim autoLoadRomValue As String = ""

		If ChkAutoloadROM.Checked = True Then
			autoLoadRomValue = FileName
		End If

		SetCfg("auto_loadrom", autoLoadRomValue)
	End Sub

	Private Sub Config_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
		If (ActiveControl.Name = EmuTB.Name Or ActiveControl.Name = ShellTB.Name Or ActiveControl.Name = PALTB.Name) Then Exit Sub

		Dim KeyCode As Short = eventArgs.KeyCode
		Dim Shift As Short = eventArgs.KeyData \ &H10000
		MFLE_Main.Global_KeyDown(KeyCode, Shift)
	End Sub

	Private Sub DetectChangeCheck_CheckStateChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles DetectChangeCheck.CheckStateChanged
		If DetectChangeCheck.Tag <> "" Then Exit Sub
		SetCfg(("checkfilechange"), (DetectChangeCheck.CheckState))
		checkfilechange_flag = DetectChangeCheck.CheckState
		Me.Update_Frm()
	End Sub

	Private Sub EffSprSimCheck_CheckStateChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles EffSprSimCheck.CheckStateChanged
		If EffSprSimCheck.Tag <> "" Then Exit Sub
		SetCfg(("effsprsim"), (EffSprSimCheck.CheckState))
		Me.Update_Frm()
	End Sub

	Private Sub EnemCountFmtCheck_CheckStateChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles EnemCountFmtCheck.CheckStateChanged
		If EnemCountFmtCheck.Tag <> "" Then Exit Sub
		SetCfg(("enemcountfmthex"), (EnemCountFmtCheck.CheckState))
		Me.Update_Frm()
	End Sub

	Private Sub MM4RainbowCheck_CheckStateChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MM4RainbowCheck.CheckStateChanged
		If MM4RainbowCheck.Tag <> "" Then Exit Sub
		SetCfg(("ringman_palanim_emu"), (MM4RainbowCheck.CheckState))
		Me.Update_Frm()
	End Sub

	Private Sub MM5GManCheck_CheckStateChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MM5GManCheck.CheckStateChanged
		If MM5GManCheck.Tag <> "" Then Exit Sub
		SetCfg(("gravityman_hardchranim_emu"), (MM5GManCheck.CheckState))
		Me.Update_Frm()
	End Sub

	Private Sub PACheck_CheckStateChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles PACheck.CheckStateChanged
		If PACheck.Tag <> "" Then Exit Sub
		SetCfg(("palanim"), (PACheck.CheckState))
		PALAnimEnable = GetCfg("palanim")
		Me.Update_Frm()
	End Sub

	Private Sub SBDAlg2Check_CheckStateChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles SBDAlg2Check.CheckStateChanged
		If SBDAlg2Check.Tag <> "" Then Exit Sub
		SetCfg(("sbdspecial_ignorebottomrow"), (SBDAlg2Check.CheckState))
		Me.Update_Frm()
	End Sub

	Private Sub ScrEdGridCheck_CheckStateChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles ScrEdGridCheck.CheckStateChanged
		If ScrEdGridCheck.Tag <> "" Then Exit Sub
		SetCfg(("scrned_grid"), (ScrEdGridCheck.CheckState))
		Me.Update_Frm()
		If ScreenEd.Visible Then ScreenEd.Update_Frm()
	End Sub

	Private Sub ScrSprAllCheck_CheckStateChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles ScrSprAllCheck.CheckStateChanged
		If ScrSprAllCheck.Tag <> "" Then Exit Sub
		SetCfg(("scrsprsort_all"), (ScrSprAllCheck.CheckState))
		Me.Update_Frm()
	End Sub

	Private Sub ScrSprCheck_CheckStateChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles ScrSprCheck.CheckStateChanged
		If ScrSprCheck.Tag <> "" Then Exit Sub
		SetCfg(("auto_scrsprsort"), (ScrSprCheck.CheckState))
		Me.Update_Frm()
	End Sub

	Private Sub Scroll0Check_CheckStateChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Scroll0Check.CheckStateChanged
		If Scroll0Check.Tag <> "" Then Exit Sub
		SetCfg(("alwaysskipscrollzero"), (Scroll0Check.CheckState))
		Me.Update_Frm()
	End Sub

	Private Sub ScrollSearchCheck_CheckStateChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles ScrollSearchCheck.CheckStateChanged
		If ScrollSearchCheck.Tag <> "" Then Exit Sub
		SetCfg(("autoscrollsearch"), (ScrollSearchCheck.CheckState))
		Me.Update_Frm()
	End Sub

	Private Sub ShellTB_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles ShellTB.TextChanged
		If ShellTB.Tag <> "" Then Exit Sub
		SetCfg(("shellcmd"), (ShellTB.Text))
		Me.Update_Frm()
	End Sub

	Private Sub SortScrCheck_CheckStateChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles SortScrCheck.CheckStateChanged
		If SortScrCheck.Tag <> "" Then Exit Sub
		SetCfg(("auto_enemscrsort"), (SortScrCheck.CheckState))
		Me.Update_Frm()
	End Sub

	Private Sub SortXCheck_CheckStateChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles SortXCheck.CheckStateChanged
		If SortXCheck.Tag <> "" Then Exit Sub
		SetCfg(("auto_enemxsort"), (SortXCheck.CheckState))
		Me.Update_Frm()
	End Sub

	Private Sub StealFocusCheck_CheckStateChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles StealFocusCheck.CheckStateChanged
		If StealFocusCheck.Tag <> "" Then Exit Sub
		SetCfg(("enemed_scrstealfocus"), (StealFocusCheck.CheckState))
		Me.Update_Frm()
	End Sub

	Private Sub TileEdGridCheck_CheckStateChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles TileEdGridCheck.CheckStateChanged
		If TileEdGridCheck.Tag <> "" Then Exit Sub
		SetCfg(("tileed_grid"), (TileEdGridCheck.CheckState))
		Me.Update_Frm()
		If TileTable.Visible Then TileTable.Update_Level()
	End Sub

	Private Sub TSAEdGridCheck_CheckStateChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles TSAEdGridCheck.CheckStateChanged
		If TSAEdGridCheck.Tag <> "" Then Exit Sub
		SetCfg(("tsaed_grid"), (TSAEdGridCheck.CheckState))
		Me.Update_Frm()
		If MetatileTable.Visible Then MetatileTable.Update_Level()
	End Sub
	Private Sub TSATRes_CheckedChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles _TsaTRes_2.CheckedChanged, _TsaTRes_1.CheckedChanged, _TsaTRes_0.CheckedChanged
		If eventSender.Checked Then
			Dim Index As Short = 0
			Dim tsa_full As Integer

			For Each radioButton As RadioButton In TsaTRes
				If radioButton.Name = eventSender.Name Then
					Exit For
				End If
				Index += 1
			Next

			If TsaTRes(Index).Tag <> "" Then Exit Sub
			tsa_full = CalcTSA()
			If (Index < 2) Then
				SetCfg(("tsatbl_8x32"), CInt(Index))
				SetCfg(("tsatbl_2x"), 0)
			Else
				SetCfg(("tsatbl_2x"), 1)
			End If
			Me.Update_Frm()
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
			'If MetatileTable.Visible = True Then MetatileTable.Update_Frm

			SetCurTSA(tsa_full, True)
		End If
	End Sub
#End Region

	Private Sub EmuTB_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles EmuTB.TextChanged
		If EmuTB.Tag <> "" Then Exit Sub
		SetCfg(("emufname"), (EmuTB.Text))
		Me.Update_Frm()
	End Sub

	Private Sub PALTB_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles PALTB.TextChanged
		If PALTB.Tag <> "" Then Exit Sub
		SetCfg(("palfile"), (PALTB.Text))
		Me.Update_Frm()
	End Sub

	Private Sub EmuBrowseBtn_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles EmuBrowseBtn.Click
		Dim tstr As String
		Dim cdl As New clsDialog
		Dim PathBackup As String = CurDir()
		Dim Title As String = "Pick the Emu.."
		Dim InitDir As String = ""
		Dim DefExt As String = ""
		Dim Filter As String = "Programs (*.exe)|*.exe|all files (*.*)|*.*"
		Dim flags As DialogFlags = DialogFlags.CHECKFILEEXISTS Or DialogFlags.CHECKPATHEXISTS

		tstr = cdl.ShowOpen(Me, Title, flags, InitDir, DefExt, Filter)
		If Len(tstr) = 0 Then GoTo exitme
		SetCfg(("emufname"), Common.Left(tstr, Len(tstr)))
exitme:
		ChDir(PathBackup)
		Me.Update_Frm()
	End Sub

	Public Sub PALBrowse()
		Dim tstr As String
		Dim cdl As New clsDialog
		Dim PathBackup As String = CurDir()
		Dim Title As String = "Pick the Palette.."
		Dim InitDir As String = ""
		Dim DefExt As String = ""
		Dim Filter As String = "NES Palettes (*.pal)|*.pal|all files (*.*)|*.*"
		Dim flags As DialogFlags = DialogFlags.CHECKFILEEXISTS Or DialogFlags.CHECKPATHEXISTS

		tstr = cdl.ShowOpen(Me, Title, flags, InitDir, DefExt, Filter)

		If Len(tstr) = 0 Then GoTo exitme
		SetCfg(("palfile"), CObj(tstr))
exitme:
		ChDir(PathBackup)
	End Sub

	Private Sub PALBrowseBtn_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles PALBrowseBtn.Click
		Me.Update_Frm()
	End Sub
	Private Sub PALReloadBtn_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles PALReloadBtn.Click
		ReloadNESPAL()
		MFLE_Main.GetMMCols()
		MFLE_Main.Update_Level()
		If PalChart.Visible = True Then PalChart.UpdateMe()
	End Sub

#End Region

End Class