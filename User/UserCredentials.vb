Module UserCredentials
    Public UserID
    Public Username
    Public UserRole

    Public Sub Logout()
        MainViewForm.logoutTime.StopTimer()
        Auditing.Log("Logged out")
        UserID = -1
        Username = ""
        UserRole = ""
        LoginForm.Show()

        CloseNonLoginForms()
    End Sub

    Private Sub CloseNonLoginForms()
        Dim openForms() As Form = Application.OpenForms.Cast(Of Form)().ToArray()

        For Each f As Form In openForms
            If f.Name <> "LoginForm" Then
                f.Close()
            End If
        Next
    End Sub

End Module