Public Class MainViewForm

    Public Shared Sub UpdateView(formToView As Form, panel As Panel)
        formToView.Dock = DockStyle.Fill
        formToView.FormBorderStyle = FormBorderStyle.None
        formToView.TopLevel = False
        panel.Controls.Clear()
        panel.Controls.Add(formToView)
        formToView.Show()
    End Sub


    Private Sub btnLogout_Click(sender As Object, e As EventArgs) Handles btnLogout.Click

    End Sub
End Class