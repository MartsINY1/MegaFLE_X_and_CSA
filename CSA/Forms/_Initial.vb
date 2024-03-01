Public Class _Initial
    Private Sub _Initial_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If (CSA_Main.MainCode()) Then
            Form1.ShowDialog()
        Else
            Support.ShowDialog()
        End If
        Me.Close()
    End Sub
End Class