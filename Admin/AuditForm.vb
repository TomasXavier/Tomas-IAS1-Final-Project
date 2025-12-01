Imports MySql.Data.MySqlClient

Public Class AuditForm
    Private Sub AuditForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        MainViewForm.logoutTime.AddActionTimerTracking(Me)
        ListAuditLogs("")
        MainViewForm.logoutTime.AddActionTimerTracking(Me)
    End Sub

    Private Sub dtpFrom_ValueChanged(sender As Object, e As EventArgs) Handles dtpFrom.ValueChanged
        MainViewForm.logoutTime.ResetTimer()
    End Sub

    Private Sub dtpTo_ValueChanged(sender As Object, e As EventArgs) Handles dtpTo.ValueChanged
        MainViewForm.logoutTime.ResetTimer()
    End Sub

    Private Sub btnRefresh_Click(sender As Object, e As EventArgs) Handles btnRefresh.Click
        MainViewForm.logoutTime.ResetTimer()
        ListAuditLogs("")
    End Sub


    Private Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        MainViewForm.logoutTime.ResetTimer()
        ListAuditLogs("AND (LogName LIKE @search OR Details LIKE @search)")
    End Sub

    Private Sub ListAuditLogs(queryEnd As String)
        Using conn As New MySqlConnection("server=localhost; userid=root; password=root; database=user_db;")
            conn.Open()
            Try
                Using cmd As New MySqlCommand("SELECT * FROM auditlogs WHERE Date >= @fromDate AND Date <= @toDate " & queryEnd, conn)

                    Dim datetime As DateTime = dtpFrom.Value
                    cmd.Parameters.AddWithValue("@fromDate", datetime)

                    datetime = dtpTo.Value
                    cmd.Parameters.AddWithValue("@toDate", datetime)

                    If queryEnd <> "" Then
                        cmd.Parameters.AddWithValue("@search", "%" & txtSearch.Text & "%")
                        MsgBox(txtSearch.Text)
                    End If

                    Dim adapter As New MySqlDataAdapter(cmd)
                    Dim table As New DataTable()
                    adapter.Fill(table)
                    dgvAudit.DataSource = table
                End Using
            Catch ex As Exception
                MessageBox.Show("Error: " & ex.Message)
            Finally
                conn.Close()
            End Try
        End Using
    End Sub

    Private Sub dgvAudit_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvAudit.CellClick
        MainViewForm.logoutTime.ResetTimer()

    End Sub

    Private Sub dgvAudit_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvAudit.CellContentClick
        MainViewForm.logoutTime.ResetTimer()

    End Sub

    Private Sub dgvAudit_CellContentDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvAudit.CellContentDoubleClick
        MainViewForm.logoutTime.ResetTimer()

    End Sub

    Private Sub dtpFrom_MouseMove(sender As Object, e As MouseEventArgs) Handles dtpFrom.MouseMove
        MainViewForm.logoutTime.ResetTimer()

    End Sub

    Private Sub dtpTo_MouseMove(sender As Object, e As MouseEventArgs) Handles dtpTo.MouseMove
        MainViewForm.logoutTime.ResetTimer()

    End Sub

    Private Sub dtpTo_MouseHover(sender As Object, e As EventArgs) Handles dtpTo.MouseHover
        MainViewForm.logoutTime.ResetTimer()

    End Sub

    Private Sub dtpFrom_MouseHover(sender As Object, e As EventArgs) Handles dtpFrom.MouseHover
        MainViewForm.logoutTime.ResetTimer()

    End Sub

    Private Sub dgvAudit_CellMouseMove(sender As Object, e As DataGridViewCellMouseEventArgs) Handles dgvAudit.CellMouseMove
        MainViewForm.logoutTime.ResetTimer()

    End Sub

    Private Sub dtpFrom_MouseEnter(sender As Object, e As EventArgs) Handles dtpFrom.MouseEnter
        MainViewForm.logoutTime.ResetTimer()

    End Sub

    Private Sub dtpFrom_MouseLeave(sender As Object, e As EventArgs) Handles dtpFrom.MouseLeave
        MainViewForm.logoutTime.ResetTimer()

    End Sub

    Private Sub dtpTo_MouseEnter(sender As Object, e As EventArgs) Handles dtpTo.MouseEnter
        MainViewForm.logoutTime.ResetTimer()

    End Sub

    Private Sub dtpTo_MouseLeave(sender As Object, e As EventArgs) Handles dtpTo.MouseLeave
        MainViewForm.logoutTime.ResetTimer()

    End Sub

    Private Sub dgvAudit_MouseEnter(sender As Object, e As EventArgs) Handles dgvAudit.MouseEnter
        MainViewForm.logoutTime.ResetTimer()

    End Sub

    Private Sub dgvAudit_MouseHover(sender As Object, e As EventArgs) Handles dgvAudit.MouseHover
        MainViewForm.logoutTime.ResetTimer()

    End Sub

    Private Sub dgvAudit_MouseMove(sender As Object, e As MouseEventArgs) Handles dgvAudit.MouseMove
        MainViewForm.logoutTime.ResetTimer()

    End Sub

    Private Sub dgvAudit_CellMouseLeave(sender As Object, e As DataGridViewCellEventArgs) Handles dgvAudit.CellMouseLeave
        MainViewForm.logoutTime.ResetTimer()

    End Sub

    Private Sub dgvAudit_CellMouseClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles dgvAudit.CellMouseClick
        MainViewForm.logoutTime.ResetTimer()

    End Sub

    Private Sub dgvAudit_CellMouseDoubleClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles dgvAudit.CellMouseDoubleClick
        MainViewForm.logoutTime.ResetTimer()

    End Sub

    Private Sub dgvAudit_Click(sender As Object, e As EventArgs) Handles dgvAudit.Click
        MainViewForm.logoutTime.ResetTimer()

    End Sub
End Class