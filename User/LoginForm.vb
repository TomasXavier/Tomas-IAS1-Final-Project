Imports System.Security.Cryptography
Imports System.Text
Imports MySql.Data.MySqlClient

Public Class LoginForm
    Public Function ComputeSHA256Hash(ByVal rawData As String) As String
        Using sha256Hash As SHA256 = SHA256.Create()
            Dim bytes As Byte() = sha256Hash.ComputeHash(Encoding.UTF32.GetBytes(rawData))
            Dim builder As New StringBuilder()
            For Each b As Byte In bytes
                builder.Append(b.ToString("x2"))
            Next
            Return builder.ToString()
        End Using
    End Function
    Dim conn As New MySqlConnection("server=localhost; userid=root; password=root; database=user_db;")
    Private loginAttempts As Integer = 0
    Private maxtAttempts As Integer = 3

    Private Sub btnLogin_Click(sender As Object, e As EventArgs) Handles btnLogin.Click
        Dim query As String = "SELECT * FROM user_tbl WHERE username=@username AND password=@password"
        Dim conn As New MySqlConnection("server=localhost; userid=root; password=root; database=user_db")

        Try
            conn.Open()
            Dim cmd As New MySqlCommand(query, conn)
            cmd.Parameters.AddWithValue("@username", txtUsername.Text)
            cmd.Parameters.AddWithValue("@password", ComputeSHA256Hash(txtPassword.Text))

            Dim reader As MySqlDataReader = cmd.ExecuteReader()

            If reader.Read() Then
                Dim Status = reader.GetString("status")

                If Status = "Authorized" Then
                    MessageBox.Show("Login successful. Your account is Authorized.", "Access Granted", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Me.Hide()
                    MainViewForm.UpdateView(UserManagementForm, MainViewForm.windowPanel)
                    MainViewForm.Show()

                ElseIf Status = "Pending" Then
                    MessageBox.Show("Your account is Pending.", "Access Denied", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Else
                    MessageBox.Show("Login successful. Your account is Unauthorized.", "Access Granted", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Me.Hide()
                    UnauthorizedForm.Show()
                End If
                txtUsername.Text = ""
                txtPassword.Text = ""
            Else
                loginAttempts += 1
                If loginAttempts >= maxtAttempts Then
                    MessageBox.Show("Too many failed attempts. Please try again tomorrow.", "Access Locked", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Application.Exit()
                Else
                    MessageBox.Show("Invalid username or password. Attempts left: " & (maxtAttempts - loginAttempts), "Access Denied", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
            End If

            reader.Close()

        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            If conn.State() = ConnectionState.Open Then conn.Close()
        End Try
    End Sub
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        txtPassword.UseSystemPasswordChar = True
    End Sub
    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        Application.Exit()
    End Sub
    Private Sub Lcreate_Click(sender As Object, e As EventArgs) Handles Lcreate.Click
        Me.Hide()
        SignupForm.Show()
        txtUsername.Text = ""
        txtPassword.Text = ""
        chkShowPassword.Checked = False
    End Sub
    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles chkShowPassword.CheckedChanged
        If chkShowPassword.Checked Then
            txtPassword.UseSystemPasswordChar = False
        Else
            txtPassword.UseSystemPasswordChar = True
        End If
    End Sub
End Class
