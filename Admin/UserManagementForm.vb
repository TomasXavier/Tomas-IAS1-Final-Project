Imports System.Windows.Forms.VisualStyles.VisualStyleElement
Imports System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel
Imports Google.Protobuf.WellKnownTypes
Imports MySql.Data.MySqlClient


Public Class UserManagementForm
    Dim conn As New MySqlConnection("server=localhost; userid=root; password=root; database=user_db")
    Private Sub btnRemove_Click(sender As Object, e As EventArgs) Handles btnRemove.Click
        MainViewForm.logoutTime.ResetTimer()

        Dim query As String = "DELETE FROM user_tbl WHERE id=@id"
        Try
            conn.Open()
            Using cmd As New MySqlCommand(query, conn)
                cmd.Parameters.AddWithValue("@id", Convert.ToInt32(txtID.Text))
                Dim rowsAffected = cmd.ExecuteNonQuery()
                If rowsAffected > 0 Then
                    MessageBox.Show("User removed successfully.")
                Else
                    MessageBox.Show("No user found with the specified ID.")
                End If
            End Using
            txtID.Clear()
            cmbStatus.Text = ""
        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message)
        Finally
            conn.Close()
        End Try
    End Sub

    Private Sub btnUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click
        MainViewForm.logoutTime.ResetTimer()

        Dim query As String = "UPDATE user_tbl SET status=@status WHERE id=@id"
        Try
            conn.Open()

            Using cmd As New MySqlCommand(query, conn)
                cmd.Parameters.AddWithValue("@status", cmbStatus.Text)
                cmd.Parameters.AddWithValue("@role", cmbRole.Text)
                cmd.Parameters.AddWithValue("@id", Convert.ToInt32(txtID.Text))
                cmd.Parameters.AddWithValue("username", txtusername.Text)
                cmd.Parameters.AddWithValue("password", txtPassword.Text)
                cmd.ExecuteNonQuery()
            End Using
            MessageBox.Show("User updated successfully.")
        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message)
        Finally
            conn.Close()
        End Try
    End Sub

    Private Sub btnView_Click(sender As Object, e As EventArgs) Handles btnView.Click
        MainViewForm.logoutTime.ResetTimer()

        Dim query As String = "SELECT id, username, password, status, role FROM user_tbl"
        Try
            conn.Open()
            Dim adapter As New MySqlDataAdapter(query, conn)
            Dim table As New DataTable()
            adapter.Fill(table)
            dgvUsers.DataSource = table
        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message)
        Finally
            conn.Close()
        End Try
    End Sub

    Private Sub Form2_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        MainViewForm.logoutTime.AddActionTimerTracking(Me)

        Dim query As String = "SELECT id, username, password, status, role FROM user_tbl"
        Try
            conn.Open()
            Dim adapter As New MySqlDataAdapter(query, conn)
            Dim table As New DataTable()
            adapter.Fill(table)
            dgvUsers.DataSource = table
        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message)
        Finally
            conn.Close()
        End Try
    End Sub

    Private Sub dgvAdminUser_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvUsers.CellContentDoubleClick
        MainViewForm.logoutTime.ResetTimer()

        If e.RowIndex >= 0 Then
            Dim selectedRow As DataGridViewRow = dgvUsers.Rows(e.RowIndex)
            txtID.Text = selectedRow.Cells("id").Value.ToString()
            cmbStatus.Text = selectedRow.Cells("status").Value.ToString()
            cmbRole.Text = selectedRow.Cells("role").Value.ToString()
        End If
    End Sub

    Private Sub LogoutToolStripMenuItem_Click(sender As Object, e As EventArgs) 
        Me.Close()
        LoginForm.Show()
    End Sub

    Private Sub AddProfileToolStripMenuItem_Click(sender As Object, e As EventArgs) 
        Me.Close()
        SignupForm.Show()
    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        MainViewForm.logoutTime.ResetTimer()

        Dim query As String = $"Select id, username, password, role, Status FROM `user_db`.`user_tbl` WHERE id Like '{txtID.Text}'"
        If txtID.Text = "" Then
            MessageBox.Show("No input on search bar")
        Else
            Try
                Using conn As New MySqlConnection("server=LocalHost; userid=root; password=root; database=user_db;")
                    Dim adapter As New MySqlDataAdapter(query, conn)
                    Dim table As New DataTable()
                    adapter.Fill(table)
                    dgvUsers.DataSource = table
                End Using
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        End If
    End Sub

    Private Sub DGVUserAdmin_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvUsers.CellContentClick
        MainViewForm.logoutTime.ResetTimer()

        If e.RowIndex >= 0 Then
            Dim row As DataGridViewRow = dgvUsers.Rows(e.RowIndex)
            txtID.Text = row.Cells("id").Value.ToString()
            txtusername.Text = row.Cells("username").Value.ToString()
            txtPassword.Text = row.Cells("password").Value.ToString()
            cmbStatus.Text = row.Cells("status").Value.ToString()
            cmbRole.Text = row.Cells("role").Value.ToString()
        End If
    End Sub
End Class