Public Class MainViewForm
    Public Shared logoutTime As LogoutTimer

    Public Sub New()
        InitializeComponent()
        logoutTime = New LogoutTimer
    End Sub

    Private Sub MainViewForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        logoutTime.SetLabel(lblInActivityTimer)
        logoutTime.AddActionTimerTracking(Me)
    End Sub

    Public Shared Sub UpdateView(formToView As Form, panel As Panel)
        formToView.Dock = DockStyle.Fill
        formToView.FormBorderStyle = FormBorderStyle.None
        formToView.TopLevel = False
        panel.Controls.Clear()
        panel.Controls.Add(formToView)
        formToView.Show()
    End Sub


    Private Sub btnLogout_Click(sender As Object, e As EventArgs) Handles btnLogout.Click
        Logout()
        Me.Close()
    End Sub

    Private Sub EmployeeManagementToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EmployeeManagementToolStripMenuItem.Click
        MainViewForm.logoutTime.ResetTimer()

        UpdateView(EmployeeForm, windowPanel)
    End Sub

    Private Sub BackupRestoreToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles BackupRestoreToolStripMenuItem.Click
        MainViewForm.logoutTime.ResetTimer()

        UpdateView(BackUpForm, windowPanel)
    End Sub

    Private Sub AuditTrailingToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AuditTrailingToolStripMenuItem.Click
        MainViewForm.logoutTime.ResetTimer()

        UpdateView(AuditForm, windowPanel)
    End Sub
End Class