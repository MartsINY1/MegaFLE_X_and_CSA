Option Explicit On
Friend Class PalChart
	Inherits System.Windows.Forms.Form

#Region "Form_Events"
    Private Sub Form_Initialize()
    End Sub

    Public Sub Manual_Init()
        'Calling it ensure constructor above is called
    End Sub
    Private Sub PalChart_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
        UpdateMe()
    End Sub

    Private Sub PalChart_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        Dim KeyCode As Short = CShort(eventArgs.KeyCode)
        Dim Shift As Short = CShort(eventArgs.KeyData \ &H10000)
        MFLE_Main.Global_KeyDown(KeyCode, Shift)
    End Sub

    Private Sub PalChart_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        e.Cancel = True

        Me.Hide()
    End Sub
#End Region

    Public Sub UpdateMe()
        Dim y, x, index As Integer

        Dim color As Color
        Dim bitmap As New Bitmap(PalChartPic.Width, PalChartPic.Height)
        Dim g As Graphics = Graphics.FromImage(bitmap)

        If palchartClaim = Palchart_Claim.PalEd Then
            Me.Text = "NES P(" & palfile & ")"
        Else
            Me.Text = "NES E(" & palfile & ")"
        End If

        For y = 0 To 7
            For x = 0 To 3
                'Draw the square (left half)
                index = RGBmirr(NESPAL((x * 16) + y))
                color = GetColorFromIndex(index)
                Using rectangleBrush As New SolidBrush(color)
                    g.FillRectangle(rectangleBrush, x * 16, y * 16, 16, 16)
                End Using

                'Draw the square (right half)
                index = RGBmirr(NESPAL((x * 16) + 8 + y))
                color = GetColorFromIndex(index)
                Using rectangleBrush As New SolidBrush(color)
                    g.FillRectangle(rectangleBrush, x * 16 + 64, y * 16, 16, 16)
                End Using
            Next x
        Next y

        'Apply the image built
        PalChartPic.Image = bitmap

    End Sub

#Region "Events"

    Private Sub PalChartPic_MouseDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles PalChartPic.MouseDown
        Dim Button As Short = CShort(eventArgs.Button \ &H100000)
        Dim Shift As Short = CShort(System.Windows.Forms.Control.ModifierKeys \ &H10000)
        Dim x As Single = eventArgs.X
        Dim y As Single = eventArgs.Y
        palchart_col = CByte(CShort(CShort(CShort(x) And &H30S) + Int(y / &H10S)) + (CShort(CShort(x) And &H40S) / 8))
        Select Case palchartClaim
            Case Palchart_Claim.PalEd : If PalEd.Visible Then PalEd.PCEvent()
            Case Palchart_Claim.EnemEd : If EnemEd.Visible Then EnemEd.PCEvent()
        End Select
    End Sub

#End Region
End Class