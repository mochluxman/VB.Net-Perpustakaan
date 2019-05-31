Imports MySql.Data.MySqlClient
Public Class Form2
    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        If MessageBox.Show("Yakin Ingin Membatalkan Login?", "Konfirmasi", MessageBoxButtons.YesNo, MessageBoxIcon.Information) = Windows.Forms.DialogResult.Yes Then
            Me.Close()
        End If
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Try
            Call koneksi()
            Dim str As String
            str = "select * from petugas where email = '" & TextBox1.Text & "' and nama = '" & TextBox2.Text & "'"
            dbcom = New MySqlCommand(str, dbcon)
            dbread = dbcom.ExecuteReader
            If dbread.HasRows Then
                Form1.Visible = True
                Form1.Enabled = True
                Me.Hide()
                Form1.Show()
            Else
                dbread.Close()
                MessageBox.Show("Login gagal, username atau Password salah", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                TextBox1.Text = ""
                TextBox2.Text = ""
                TextBox1.Focus()
            End If
        Catch ex As Exception
        End Try
    End Sub
End Class