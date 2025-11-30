Imports MySql.Data.MySqlClient

Public Class BastaSQL
    Public Shared Function PangalanNgDatabase()
        Return "user_db"
    End Function

    Public Shared Function Konekt()
        Return New MySqlConnection("server=localhost; userid=root; password=root; database=" & PangalanNgDatabase() & ";")
    End Function
End Class