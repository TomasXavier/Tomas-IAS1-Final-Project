Public Class BackUpForm
    Private Sub btnBackUp_Click(sender As Object, e As EventArgs) Handles btnBackUp.Click
        MainViewForm.logoutTime.ResetTimer()
        BackUp.Save()
        MainViewForm.logoutTime.ResetTimer()
    End Sub

    Private Sub btnRestore_Click(sender As Object, e As EventArgs) Handles btnRestore.Click
        MainViewForm.logoutTime.ResetTimer()
        BackUp.Load()
        MainViewForm.logoutTime.ResetTimer()
    End Sub

    Private Sub BackUpForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        MainViewForm.logoutTime.AddActionTimerTracking(Me)
    End Sub
End Class