Imports MySql.Data.MySqlClient
Imports System.Data.DataTable

Module Module1

    Public dbcon As MySqlConnection
    Public dbcom As MySqlCommand
    Public dbadapter As MySqlDataAdapter
    Public dbread As MySqlDataReader

    Sub koneksi()
        dbcon = New MySqlConnection("server=localhost; user id=root; password=; database=24_perpus;Convert Zero Datetime=True")
        Try
            If dbcon.State = ConnectionState.Closed Then
                dbcon.Open()
            End If
        Catch ex As Exception
            MessageBox.Show("terjadi kesalahan koneksi")
        End Try
    End Sub
End Module
