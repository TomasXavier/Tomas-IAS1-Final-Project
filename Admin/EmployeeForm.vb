Imports System.Text.RegularExpressions
Imports MySql.Data.MySqlClient

Public Class EmployeeForm
    Private employeeID As Integer
    Private Sub EmployeeForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        MainViewForm.logoutTime.AddActionTimerTracking(Me)
        ListEmployeeDGV()
    End Sub

    Private Function ValidateEmployeeForm() As Boolean
        Dim fields As New Dictionary(Of String, TextBox) From {
            {"First Name", txtFirstName},
            {"Last Name", txtLastName},
            {"Email", txtEmail},
            {"Contact Number", txtContactNumber}
        }

        For Each field In fields
            If String.IsNullOrWhiteSpace(field.Value.Text) Then
                MessageBox.Show(
                    field.Key & " cannot be empty.",
                    "Validation Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                )
                field.Value.Focus()
                Return False
            End If
        Next

        Dim namePattern As String = "^[A-Za-z .]+$"

        If Not Regex.IsMatch(txtFirstName.Text, namePattern) Then
            MessageBox.Show(
                "First Name can only contain letters, spaces, and periods.",
                "Invalid Input",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error
            )
            txtFirstName.Focus()
            Return False
        End If

        If Not Regex.IsMatch(txtLastName.Text, namePattern) Then
            MessageBox.Show(
                "Last Name can only contain letters, spaces, and periods.",
                "Invalid Input",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error
            )
            txtLastName.Focus()
            Return False
        End If


        Dim email As String = txtEmail.Text

        Dim atCount As Integer = email.Count(Function(c) c = "@"c)
        If atCount <> 1 Then
            MessageBox.Show(
                "Email must contain exactly one '@' symbol.",
                "Invalid Email",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error
            )
            txtEmail.Focus()
            Return False
        End If

        Dim emailPattern As String = "^[A-Za-z][A-Za-z0-9._%+-]*@[A-Za-z0-9.-]+\.[A-Za-z]{2,}$"
        If Not Regex.IsMatch(txtEmail.Text, emailPattern) Then
            MessageBox.Show("Please provide a valid email address." & Environment.NewLine & Environment.NewLine &
                            "Must begin with letter." & Environment.NewLine &
                            "Must have at least """"@""""." & Environment.NewLine &
                            "Must end with a """".com"""".", "Invalid Email",
                        MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        End If

        Dim contactPattern As String = "^[0-9()+ ]+$"

        If Not Regex.IsMatch(txtContactNumber.Text, contactPattern) Then
            MessageBox.Show("Contact number can contain only numbers, plus (+), parentheses (), and spaces.",
                        "Invalid Contact Number", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        End If

        If txtContactNumber.Text.Length < 11 OrElse txtContactNumber.Text.Length > 13 Then
            MessageBox.Show("Contact number must be 11 to 13 characters long.", "Invalid Contact Number Length",
                        MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        End If

        'MessageBox.Show(
        '    "Employee information is valid.",
        '    "Validation Successful",
        '    MessageBoxButtons.OK,
        '    MessageBoxIcon.Information
        ')

        Return True
    End Function

    Private Sub LogEmployeeDetails(name As String)
        Auditing.Log(name, "" &
        "first name='" & txtFirstName.Text & "', " &
        "last name='" & txtLastName.Text & "', " &
        "email='" & txtEmail.Text & "', " &
        "contact='" & txtContactNumber.Text & "'")
    End Sub

    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        MainViewForm.logoutTime.ResetTimer()

        If ValidateEmployeeForm() Then
            Try
                Using konekt As MySqlConnection = BastaSQL.Konekt()
                    konekt.Open()

                    Using cmd As New MySqlCommand("INSERT INTO Employees" &
                        "(FirstName, LastName, ContactNumber, Email) VALUES " &
                        "(@FirstName, @LastName, @ContactNumber, @Email);",
                        konekt)

                        cmd.Parameters.AddWithValue("@FirstName", txtFirstName.Text)
                        cmd.Parameters.AddWithValue("@LastName", txtLastName.Text)
                        cmd.Parameters.AddWithValue("@ContactNumber", txtContactNumber.Text)
                        cmd.Parameters.AddWithValue("@Email", txtEmail.Text)
                        cmd.ExecuteNonQuery()

                        LogEmployeeDetails("Added new Employee")
                        MessageBox.Show($"User '{txtFirstName.Text}' was addedd successfully.", "User Addition Successful", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        ListEmployeeDGV()
                    End Using
                End Using
            Catch ex As Exception
                LogEmployeeDetails("Failed attempt at add new Employee")
                MessageBox.Show(ex.Message, "Error adding user", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End If
    End Sub

    Private Sub btnUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click
        MainViewForm.logoutTime.ResetTimer()

        If ValidateEmployeeForm() Then
            Try
                Using konekt As MySqlConnection = BastaSQL.Konekt()
                    konekt.Open()

                    Using cmd As New MySqlCommand("UPDATE Employees SET " &
                        "FirstName=@FirstName, " &
                        "LastName=@LastName, " &
                        "ContactNumber=@ContactNumber, " &
                        "Email=@Email " &
                        "WHERE ID=@ID", konekt)


                        cmd.Parameters.AddWithValue("@ID", employeeID)
                        cmd.Parameters.AddWithValue("@FirstName", txtFirstName.Text)
                        cmd.Parameters.AddWithValue("@LastName", txtLastName.Text)
                        cmd.Parameters.AddWithValue("@ContactNumber", txtContactNumber.Text)
                        cmd.Parameters.AddWithValue("@Email", txtEmail.Text)
                        cmd.ExecuteNonQuery()

                        LogEmployeeDetails("Employee info was altered")
                        MessageBox.Show($"User was altered successfully.", "User Alteration Successful", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        ListEmployeeDGV()
                    End Using
                End Using
            Catch ex As Exception
                LogEmployeeDetails("Failed attempt at altering new Employee")
                MessageBox.Show(ex.Message, "Error Updating User", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        Else
            LogEmployeeDetails("Failed attempt at altering new Employee")
        End If
    End Sub

    Private Sub dgvEmployees_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvEmployees.CellClick
        TransferEmployeeInfoToTextboxes(dgvEmployees.CurrentRow.Index)
    End Sub

    Private Sub GetDGV_RowValue(textbox As TextBox, rowIndex As Integer, columnName As String)
        textbox.Text = dgvEmployees.Rows(rowIndex).Cells(columnName).Value.ToString()
    End Sub

    Private Sub TransferEmployeeInfoToTextboxes(rowIndex As Integer)
        If rowIndex > 0 Then
            GetDGV_RowValue(txtFirstName, rowIndex, "FirstName")
            GetDGV_RowValue(txtLastName, rowIndex, "LastName")
            GetDGV_RowValue(txtContactNumber, rowIndex, "ContactNumber")
            GetDGV_RowValue(txtEmail, rowIndex, "Email")

            employeeID = Integer.Parse(dgvEmployees.Rows(rowIndex).Cells("ID").Value)
            'MessageBox.Show(employeeID)
        End If
    End Sub

    Private Sub ListEmployeeDGV()
        Try
            Using konekt As MySqlConnection = BastaSQL.Konekt()
                konekt.Open()

                Using cmd As New MySqlCommand("SELECT * FROM Employees;", konekt)
                    Dim adapter As New MySqlDataAdapter(cmd)
                    Dim dataTable As New DataTable()
                    adapter.Fill(dataTable)
                    dgvEmployees.DataSource = dataTable
                    dgvEmployees.Columns("ID").Visible = False
                End Using
            End Using
        Catch ex As Exception
            LogEmployeeDetails("Failed to view Employee list")
            MessageBox.Show(ex.Message, "Employees Listing Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        MainViewForm.logoutTime.ResetTimer()

        Try
            Using konekt As MySqlConnection = BastaSQL.Konekt()
                konekt.Open()

                Using cmd As New MySqlCommand("DELETE FROM Employees WHERE ID=@ID", konekt)
                    cmd.ExecuteNonQuery()

                    LogEmployeeDetails("Employee deleted succesfully")
                    MessageBox.Show($"User was deleted successfully.", "User Deletion Successful", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    ListEmployeeDGV()
                End Using
            End Using
        Catch ex As Exception
            LogEmployeeDetails("Failed attempt at deleting new Employee")
            MessageBox.Show(ex.Message, "Error Deleting User", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click
        MainViewForm.logoutTime.ResetTimer()

    End Sub
End Class