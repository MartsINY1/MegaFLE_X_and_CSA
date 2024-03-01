Option Explicit On

Friend Class Support
	Inherits System.Windows.Forms.Form

	Public Sub Refresh_GameList()
		Dim folderPath As String = My.Application.Info.DirectoryPath + GetCfg("support_folder")
		Dim txtFiles As String() = IO.Directory.GetFiles(folderPath, "*.txt")

		For Each txtFile As String In txtFiles
			SupFLB.Items.Add(IO.Path.GetFileName(txtFile))
		Next
	End Sub

	Private Sub ExitBtn_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles ExitBtn.Click
		Me.Close()
	End Sub

	Private Sub Support_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
		Dim KeyCode As Short = eventArgs.KeyCode
		Dim Shift As Short = eventArgs.KeyData \ &H10000
		If KeyCode = System.Windows.Forms.Keys.Return Then
			Game_Selected()
		End If
	End Sub

	Private Sub GoBtn_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles GoBtn.Click
		If SupFLB.SelectedIndex = -1 Then Exit Sub
		Game_Selected()
	End Sub

	Private Sub Game_Selected()
		CSA_Main.supfile = My.Application.Info.DirectoryPath + GetCfg("support_folder") + "\" + SupFLB.SelectedItem.ToString()
		Me.Close()
	End Sub

	Private Sub SupFLB_DoubleClick(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles SupFLB.DoubleClick
		Game_Selected()
	End Sub
End Class