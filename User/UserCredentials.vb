Module UserCredentials
    Public UserID
    Public Username
    Public UserRole

    Public Sub Logout()
        Auditing.Log("Logged out")
        UserID = -1
        Username = ""
        UserRole = ""
        LoginForm.Show()
    End Sub

End Module