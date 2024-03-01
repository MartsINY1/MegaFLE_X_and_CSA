Option Explicit On

Friend Class ClsDialog
	Public Enum DialogFlags
		PROHIBEREADONLY = &B1
		CHECKFILEEXISTS = &B10
		CHECKPATHEXISTS = &B100
	End Enum

	Private LastFileName As String
	Public Function ShowOpen(ByVal Frm As Form, ByVal Title As String, ByRef flags As DialogFlags, Optional ByVal InitDir As String = "", Optional ByVal DefExt As String = "", Optional ByVal Filter As String = "All Files (*.*)|*.*|") As String
		Dim openFileDialog As New OpenFileDialog()
		Dim dialogResult As DialogResult

		ShowOpen = ""
		If InitDir.Length = 0 Then InitDir = LastFileName
		If DefExt <> "" Then openFileDialog.DefaultExt = DefExt
		If (flags And DialogFlags.CHECKPATHEXISTS) = DialogFlags.CHECKPATHEXISTS Then openFileDialog.CheckPathExists = True
		If (flags And DialogFlags.CHECKFILEEXISTS) = DialogFlags.CHECKFILEEXISTS Then openFileDialog.CheckFileExists = True
		openFileDialog.Title = Title
		openFileDialog.InitialDirectory = InitDir
		openFileDialog.Filter = Filter
		openFileDialog.Multiselect = False

		If Frm Is Nothing Then
			dialogResult = openFileDialog.ShowDialog()
		Else
			dialogResult = openFileDialog.ShowDialog(Frm)
		End If

		If dialogResult = DialogResult.OK Then
			If (flags And DialogFlags.PROHIBEREADONLY) = DialogFlags.PROHIBEREADONLY Then
				Dim fi As New System.IO.FileInfo(openFileDialog.FileName)
				If fi.IsReadOnly Then
					Throw New Exception("Read-only files are not allowed.")
				End If
			End If
			ShowOpen = openFileDialog.FileName
		End If

		If Len(ShowOpen) > 0 Then LastFileName = ShowOpen
	End Function

	Public Function ShowSave(ByVal Frm As Form, ByVal Title As String, ByRef flags As DialogFlags, Optional ByVal InitDir As String = "", Optional ByVal DefExt As String = "", Optional ByVal Filter As String = "All Files (*.*)|*.*|") As String
		Dim openFileDialog As New SaveFileDialog()
		ShowSave = ""
		If InitDir.Length = 0 Then InitDir = LastFileName
		If DefExt <> "" Then openFileDialog.DefaultExt = DefExt
		If (flags And DialogFlags.CHECKPATHEXISTS) = DialogFlags.CHECKPATHEXISTS Then openFileDialog.CheckPathExists = True
		If (flags And DialogFlags.CHECKFILEEXISTS) = DialogFlags.CHECKFILEEXISTS Then openFileDialog.CheckFileExists = True
		openFileDialog.Title = Title
		openFileDialog.InitialDirectory = InitDir
		openFileDialog.Filter = Filter
		If openFileDialog.ShowDialog(Frm) = DialogResult.OK Then
			If (flags And DialogFlags.PROHIBEREADONLY) = DialogFlags.PROHIBEREADONLY Then
				Dim fi As New System.IO.FileInfo(openFileDialog.FileName)
				If fi.IsReadOnly Then
					Throw New Exception("Read-only files are not allowed.")
				End If
			End If
			ShowSave = openFileDialog.FileName
		End If
		If Len(ShowSave) > 0 Then LastFileName = ShowSave
	End Function

#Region "Old code which only works if project is compiled for x86"
	'Private Declare Function GetOpenFileName Lib "comdlg32.dll" Alias "GetOpenFileNameA" (ByRef pOpenfilename As OPENFILENAME) As Integer
	'Private Declare Function GetSaveFileName Lib "comdlg32.dll" Alias "GetSaveFileNameA" (ByRef pOpenfilename As OPENFILENAME) As Integer
	'Private cdlg As OPENFILENAME
	'Private Structure OPENFILENAME
	'	Dim lStructSize As Integer
	'	Dim hwndOwner As Integer
	'	Dim hInstance As Integer
	'	Dim lpstrFilter As String
	'	Dim lpstrCustomFilter As String
	'	Dim nMaxCustFilter As Integer
	'	Dim nFilterIndex As Integer
	'	Dim lpstrFile As String
	'	Dim nMaxFile As Integer
	'	Dim lpstrFileTitle As String
	'	Dim nMaxFileTitle As Integer
	'	Dim lpstrInitialDir As String
	'	Dim lpstrTitle As String
	'	Dim flags As Integer
	'	Dim nFileOffset As Short
	'	Dim nFileExtension As Short
	'	Dim lpstrDefExt As String
	'	Dim lCustData As Integer
	'	Dim lpfnHook As Integer
	'	Dim lpTemplateName As String
	'End Structure
	'
	'Private Const OFN_ALLOWMULTISELECT As Short = &H200S
	'Private Const OFN_CREATEPROMPT As Short = &H2000S
	'Private Const OFN_ENABLEHOOK As Short = &H20S
	'Private Const OFN_ENABLETEMPLATE As Short = &H40S
	'Private Const OFN_ENABLETEMPLATEHANDLE As Short = &H80S
	'Private Const OFN_EXPLORER As Integer = &H80000 '  new look commdlg
	'Private Const OFN_EXTENSIONDIFFERENT As Short = &H400S
	'Private Const OFN_FILEMUSTEXIST As Short = &H1000S
	'Private Const OFN_HIDEREADONLY As Short = &H4S
	'Private Const OFN_LONGNAMES As Integer = &H200000 '  force long names for 3.x modules
	'Private Const OFN_NOCHANGEDIR As Short = &H8S
	'Private Const OFN_NODEREFERENCELINKS As Integer = &H100000
	'Private Const OFN_NOLONGNAMES As Integer = &H40000 '  force no long names for 4.x modules
	'Private Const OFN_NONETWORKBUTTON As Integer = &H20000
	'Private Const OFN_NOREADONLYRETURN As Short = &H8000S
	'Private Const OFN_NOTESTFILECREATE As Integer = &H10000
	'Private Const OFN_NOVALIDATE As Short = &H100S
	'Private Const OFN_OVERWRITEPROMPT As Short = &H2S
	'Private Const OFN_PATHMUSTEXIST As Short = &H800S
	'Private Const OFN_READONLY As Short = &H1S
	'Private Const OFN_SHAREAWARE As Short = &H4000S
	'Private Const OFN_SHAREFALLTHROUGH As Short = 2
	'Private Const OFN_SHARENOWARN As Short = 1
	'Private Const OFN_SHAREWARN As Short = 0
	'Private Const OFN_SHOWHELP As Short = &H10S
	'
	'Public Enum DialogFlags
	'	ALLOWMULTISELECT = OFN_ALLOWMULTISELECT
	'	CREATEPROMPT = OFN_CREATEPROMPT
	'	ENABLEHOOK = OFN_ENABLEHOOK
	'	ENABLETEMPLATE = OFN_ENABLETEMPLATE
	'	ENABLETEMPLATEHANDLE = OFN_ENABLETEMPLATEHANDLE
	'	EXPLORER = OFN_EXPLORER
	'	EXTENSIONDIFFERENT = OFN_EXTENSIONDIFFERENT
	'	FILEMUSTEXIST = OFN_FILEMUSTEXIST
	'	HIDEREADONLY = OFN_HIDEREADONLY
	'	LONGNAMES = OFN_LONGNAMES
	'	NOCHANGEDIR = OFN_NOCHANGEDIR
	'	NODEREFERENCELINKS = OFN_NODEREFERENCELINKS
	'	NOLONGNAMES = OFN_NOLONGNAMES
	'	NONETWORKBUTTON = OFN_NONETWORKBUTTON
	'	NOREADONLYRETURN = OFN_NOREADONLYRETURN
	'	NOTESTFILECREATE = OFN_NOTESTFILECREATE
	'	NOVALIDATE = OFN_NOVALIDATE
	'	OVERWRITEPROMPT = OFN_OVERWRITEPROMPT
	'	PATHMUSTEXIST = OFN_PATHMUSTEXIST
	'	ReadOnly_Renamed = OFN_READONLY
	'	SHAREAWARE = OFN_SHAREAWARE
	'	SHAREFALLTHROUGH = OFN_SHAREFALLTHROUGH
	'	SHARENOWARN = OFN_SHARENOWARN
	'	SHAREWARN = OFN_SHAREWARN
	'	SHOWHELP = OFN_SHOWHELP
	'End Enum
	'
	'Public Function ShowOpen(ByVal Form_hWnd As Integer, ByVal Title As String, Optional ByVal InitDir As String = "", Optional ByVal Filter_Renamed As String = "All Files (*.*)|*.*|", Optional ByRef flags As DialogFlags = DialogFlags.FILEMUSTEXIST Or DialogFlags.PATHMUSTEXIST) As String
	'	Filter_Renamed = Replace(Filter_Renamed, "|", Chr(0))
	'	If Right(Filter_Renamed, 1) <> Chr(0) Then Filter_Renamed &= Chr(0)
	'	If Len(InitDir) = 0 Then InitDir = LastFileName
	'	cdlg.lStructSize = Len(cdlg)
	'	cdlg.hwndOwner = Form_hWnd
	'	cdlg.hInstance = GetHInstance()
	'	cdlg.lpstrFilter = Filter_Renamed
	'	cdlg.lpstrFile = Space(254)
	'	cdlg.nMaxFile = 255
	'	cdlg.lpstrFileTitle = Space(254)
	'	cdlg.nMaxFileTitle = 255
	'	cdlg.lpstrInitialDir = InitDir
	'	cdlg.lpstrTitle = Title
	'	cdlg.flags = flags
	'	ShowOpen = IIf(GetOpenFileName(cdlg), Trim(cdlg.lpstrFile), "")
	'	If Len(ShowOpen) > 0 Then LastFileName = ShowOpen
	'End Function
	'
	'Public Function ShowSave(ByVal Form_hWnd As Integer, ByVal Title As String, Optional ByVal InitDir As String = "", Optional ByVal Filter_Renamed As String = "All Files (*.*)|*.*|", Optional ByVal DefExt As String = "", Optional ByRef flags As DialogFlags = DialogFlags.OVERWRITEPROMPT) As String
	'	Filter_Renamed = Replace(Filter_Renamed, "|", Chr(0))
	'	If Right(Filter_Renamed, 1) <> Chr(0) Then Filter_Renamed = Filter_Renamed & Chr(0)
	'	If Len(InitDir) = 0 Then InitDir = LastFileName
	'	cdlg.lStructSize = Len(cdlg)
	'	cdlg.lpstrTitle = Title
	'	cdlg.hwndOwner = Form_hWnd
	'	cdlg.hInstance = GetHInstance()
	'	cdlg.lpstrFilter = Filter_Renamed
	'	cdlg.lpstrDefExt = DefExt
	'	cdlg.lpstrFile = Space(254)
	'	cdlg.nMaxFile = 255
	'	cdlg.lpstrFileTitle = Space(254)
	'	cdlg.nMaxFileTitle = 255
	'	cdlg.lpstrInitialDir = InitDir
	'	cdlg.flags = flags
	'	ShowSave = IIf(GetSaveFileName(cdlg), Trim(cdlg.lpstrFile), "")
	'	If Len(ShowSave) > 0 Then LastFileName = ShowSave
	'End Function
#End Region
End Class