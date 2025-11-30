Imports System.Runtime.Remoting.Contexts
Imports MySql.Data.MySqlClient

Public Class Auditing
    Public Shared Sub Log(UserID As Integer, Username As String, Role As String, LogName As String, Details As String)
        Try
            Using konekt As MySqlConnection = BastaSQL.Konekt()
                konekt.Open()
                Using cmd As New MySqlCommand(
                "INSERT INTO AuditLogs (" &
                "UserID, Username, Role, LogName, Details, Date) VALUES" &
                "(@id, @username, @role, @name, @details, NOW());", konekt)
                    cmd.Parameters.AddWithValue("@id", UserID)
                    cmd.Parameters.AddWithValue("@username", Username)
                    cmd.Parameters.AddWithValue("@role", Role)
                    cmd.Parameters.AddWithValue("@name", LogName)
                    cmd.Parameters.AddWithValue("@details", Details)
                    cmd.ExecuteNonQuery()
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Log Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Public Shared Sub Log(LogName As String, Details As String)
        Log(UserID, Username, UserRole, LogName, Details)
    End Sub

    Public Shared Sub Log(LogName As String)
        Log(LogName, "")
    End Sub
End Class