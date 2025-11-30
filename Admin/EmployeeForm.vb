Imports System.Text.RegularExpressions

Public Class EmployeeForm
    Private Sub EmployeeForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load

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

        Dim emailPattern As String = "^[^@\s]+@[^@\s]+\.[^@\s]+$"

        If Not Regex.IsMatch(email, emailPattern) Then
            MessageBox.Show(
                "Please enter a valid email address (example: name@email.com).",
                "Invalid Email",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error
            )
            txtEmail.Focus()
            Return False
        End If

        MessageBox.Show(
            "Employee information is valid.",
            "Validation Successful",
            MessageBoxButtons.OK,
            MessageBoxIcon.Information
        )

        Return True
    End Function
End Class