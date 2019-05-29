Imports MySql.Data.MySqlClient
Imports System.Data.DataTable
Public Class Form1
    Private dt As New DataTable
    Sub tampil()
        Dim tampil As New MySqlDataAdapter("select * from member ", dbcon)
        dt.Clear()
        tampil.Fill(dt)
        DataGridView1.DataSource = dt
    End Sub
    Sub bersih()
        Dim int As Integer
        Integer.TryParse(TextBox1.Text, int)
        TextBox1.Text = (int + 1)
        TextBox2.Text = ""
        DateTimePicker1.Text = ""
        TextBox3.Text = ""
        ComboBox1.Text = ""
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Call koneksi()
        Dim simpan As New MySqlCommand("insert into member(`id_member`, `nama`, `ttl`, `email`, `status`) VALUE('" & TextBox1.Text & "','" & TextBox2.Text & "','" & DateTimePicker1.Text & "','" & TextBox3.Text & "','" & ComboBox1.Text & "')", dbcon)
        Try
            If simpan.ExecuteNonQuery() = 1 Then
                MsgBox("Data Berhasil Disimpan")
                bersih()
                tampil()
                TextBox1.Focus()
                Exit Sub
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub DataGridView1_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        Dim isi As Integer
        isi = Me.DataGridView1.CurrentRow.Index
        With DataGridView1.Rows.Item(isi)
            TextBox1.Text = .Cells(0).Value
            TextBox2.Text = .Cells(1).Value
            DateTimePicker1.Text = .Cells(2).Value
            TextBox3.Text = .Cells(3).Value
            ComboBox1.Text = .Cells(4).Value
        End With
    End Sub

    Private Sub TabPage1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TabPage1.Click
        Call koneksi()
        Call tampil()
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Dim hapus As New MySqlCommand("DELETE FROM member WHERE id_member='" & TextBox1.Text & "'", dbcon)
        Try
            If hapus.ExecuteNonQuery() = 1 Then
                MsgBox("Data Berhasil Di Hapus")
                Call tampil()
                TextBox1.Text = ""
                TextBox2.Text = ""
                DateTimePicker1.Text = ""
                TextBox3.Text = ""
                ComboBox1.Text = ""
            End If
        Catch ex As Exception
            MsgBox("Data Gagal Di Hapus")
        End Try
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click

        Dim edit As New MySqlCommand("UPDATE member SET id_member='" & TextBox1.Text & "', nama='" & TextBox2.Text & "', ttl='" & DateTimePicker1.Text & "', email='" & TextBox3.Text & "', status='" & ComboBox1.Text & "' WHERE id_member='" & TextBox1.Text & "'", dbcon)
        Try
            If edit.ExecuteNonQuery() = 1 Then
                MsgBox("Edit Data Berhasil")
                Call tampil()
                Call bersih()


            End If
        Catch ex As Exception
            MsgBox("Edit Data Gagal")
        End Try

    End Sub

    Private Sub Button14_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button14.Click
        Call bersih()
    End Sub

    'Petugas'

    Private dp As New DataTable
    Sub tampilp()
        Dim tampilp As New MySqlDataAdapter("select * from petugas ", dbcon)
        dp.Clear()
        tampilp.Fill(dp)
        DataGridView2.DataSource = dp
    End Sub
    Sub bersihp()
        Dim int As Integer
        Integer.TryParse(TextBox6.Text, int)
        TextBox6.Text = (int + 1)
        TextBox5.Text = ""
        DateTimePicker2.Text = ""
        TextBox4.Text = ""
        ComboBox2.Text = ""
    End Sub

    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button6.Click
        Call koneksi()
        Dim simpanp As New MySqlCommand("insert into petugas(`id_petugas`, `nama`, `ttl`, `email`, `status`) VALUE('" & TextBox6.Text & "','" & TextBox5.Text & "','" & DateTimePicker2.Text & "','" & TextBox4.Text & "','" & ComboBox2.Text & "')", dbcon)
        Try
            If simpanp.ExecuteNonQuery() = 1 Then
                MsgBox("Data Berhasil Disimpan")
                bersihp()
                tampilp()
                TextBox6.Focus()
                Exit Sub
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        Dim editp As New MySqlCommand("UPDATE petugas SET id_petugas='" & TextBox6.Text & "', nama='" & TextBox5.Text & "', ttl='" & DateTimePicker2.Text & "', email='" & TextBox4.Text & "', status='" & ComboBox2.Text & "' WHERE id_petugas='" & TextBox6.Text & "'", dbcon)
        Try
            If editp.ExecuteNonQuery() = 1 Then
                MsgBox("Edit Data Berhasil")
                Call tampilp()
                Call bersihp()
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub DataGridView2_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView2.CellClick
        Dim isip As Integer
        isip = Me.DataGridView2.CurrentRow.Index
        With DataGridView2.Rows.Item(isip)
            TextBox6.Text = .Cells(0).Value
            TextBox5.Text = .Cells(1).Value
            DateTimePicker2.Text = .Cells(2).Value
            TextBox4.Text = .Cells(3).Value
            ComboBox2.Text = .Cells(4).Value
        End With
    End Sub

    Private Sub TabPage2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TabPage2.Click
        Call koneksi()
        Call tampilp()
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        Dim hapusp As New MySqlCommand("DELETE FROM petugas WHERE id_petugas='" & TextBox6.Text & "'", dbcon)
        Try
            If hapusp.ExecuteNonQuery() = 1 Then
                MsgBox("Data Berhasil Di Hapus")
                Call tampilp()
                TextBox6.Text = ""
                TextBox5.Text = ""
                DateTimePicker2.Text = ""
                TextBox4.Text = ""
                ComboBox2.Text = ""
            End If
        Catch ex As Exception
            MsgBox("Data Gagal Di Hapus")
        End Try
    End Sub

    Private Sub Button15_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button15.Click
        Call bersihp()
    End Sub

    Private db As New DataTable
    'Buku'
    Sub tampilb()
        Dim tampilb As New MySqlDataAdapter("select * from buku", dbcon)
        db.Clear()
        tampilb.Fill(db)
        DataGridView3.DataSource = db
    End Sub
    Sub bersihb()
        Dim int As Integer
        Integer.TryParse(TextBox7.Text, int)
        TextBox7.Text = (int + 1)
        TextBox8.Text = ""
        ComboBox3.Text = ""
        TextBox9.Text = ""
        TextBox10.Text = ""

    End Sub

    Private Sub Button9_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button9.Click
        Call koneksi()
        Dim simpanb As New MySqlCommand("insert into buku(`id_buku`, `judul`, `kategori`, `pengarang`, `stok`) VALUE('" & TextBox7.Text & "','" & TextBox8.Text & "','" & ComboBox3.Text & "','" & TextBox9.Text & "','" & TextBox10.Text & "')", dbcon)
        Try
            If simpanb.ExecuteNonQuery() = 1 Then
                MsgBox("Data Berhasil Disimpan")
                bersihb()
                tampilb()
                TextBox7.Focus()
                Exit Sub
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub Button8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button8.Click
        Dim editb As New MySqlCommand("UPDATE buku SET id_buku='" & TextBox7.Text & "', judul='" & TextBox8.Text & "', kategori='" & ComboBox3.Text & "', pengarang='" & TextBox9.Text & "', stok='" & TextBox10.Text & "' WHERE id_buku='" & TextBox7.Text & "'", dbcon)
        Try
            If editb.ExecuteNonQuery() = 1 Then
                MsgBox("Edit Data Berhasil")
                Call tampilb()
                Call bersihb()
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub DataGridView3_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView3.CellClick
        Dim isib As Integer
        isib = Me.DataGridView3.CurrentRow.Index
        With DataGridView3.Rows.Item(isib)
            TextBox7.Text = .Cells(0).Value
            TextBox8.Text = .Cells(1).Value
            ComboBox3.Text = .Cells(2).Value
            TextBox9.Text = .Cells(3).Value
            TextBox10.Text = .Cells(4).Value
        End With
    End Sub

    Private Sub TabPage3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TabPage3.Click
        Call koneksi()
        Call tampilb()
    End Sub

    Private Sub Button7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button7.Click
        Dim hapusb As New MySqlCommand("DELETE FROM buku WHERE id_buku='" & TextBox7.Text & "'", dbcon)
        Try
            If hapusb.ExecuteNonQuery() = 1 Then
                MsgBox("Data Berhasil Di Hapus")
                Call tampilb()
                TextBox7.Text = ""
                TextBox8.Text = ""
                ComboBox6.Text = ""
                TextBox9.Text = ""
                TextBox10.Text = ""
            End If
        Catch ex As Exception
            MsgBox("Data Gagal Di Hapus")
        End Try
    End Sub

    Private Sub Button16_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button16.Click
        Call bersihb()
    End Sub

    Private dpin As New DataTable
    Sub tampildpin()
        Dim tampildpin As New MySqlDataAdapter("select * from peminjaman", dbcon)
        dpin.Clear()
        tampildpin.Fill(dpin)
        DataGridView4.DataSource = dpin
    End Sub
    Sub bersihdpin()
        Dim int As Integer
        Integer.TryParse(TextBox7.Text, int)
        TextBox11.Text = (int + 1)
        ComboBox7.Text = ""
        ComboBox5.Text = ""
        ComboBox6.Text = ""
        DateTimePicker4.Text = ""
        DateTimePicker5.Text = ""
    End Sub

    Private Sub Button13_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button13.Click
        Call koneksi()
        Dim simpandpin As New MySqlCommand("insert into peminjaman(`id_peminjaman`, `nama_member`, `nama_petugas`, `tgl_pinjam`, `tgl_kembali`, `judul_buku`) VALUE('" & TextBox11.Text & "','" & ComboBox5.Text & "','" & ComboBox6.Text & "','" & DateTimePicker4.Text & "','" & DateTimePicker5.Text & "','" & ComboBox7.Text & "')", dbcon)
        Try
            If simpandpin.ExecuteNonQuery() = 1 Then
                MsgBox("Data Berhasil Disimpan")
                bersihdpin()
                tampildpin()
                TextBox11.Focus()
                Exit Sub
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub Button12_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button12.Click
        Call bersihdpin()
    End Sub

    Sub isiComboMember()
        koneksi()
        Dim r As New MySqlCommand("Select * from member where status='1'", dbcon)
        Try
            dbread = r.ExecuteReader
            While dbread.Read
                ComboBox5.Items.Add(dbread("nama"))
            End While
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Sub isiComboPetugas()
        koneksi()
        Dim q As New MySqlCommand("Select * from petugas where status='1'", dbcon)
        Try
            dbread = q.ExecuteReader
            While dbread.Read
                ComboBox6.Items.Add(dbread("nama"))
            End While
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Sub isiComboBuku()
        koneksi()
        Dim s As New MySqlCommand("Select * from buku", dbcon)
        Try
            dbread = s.ExecuteReader
            While dbread.Read
                ComboBox7.Items.Add(dbread("judul"))
                'ComboBox2.SelectedItem = row("tgl_pinj").ToString()'
            End While
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub TabPage5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TabPage5.Click
        Call koneksi()
        Call tampildpin()
        Call isiComboMember()
        Call isiComboPetugas()
        Call isiComboBuku()
    End Sub

    Private Sub Button17_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button17.Click
        Call bersihdpin()
    End Sub

    Private dpen As New DataTable
    Sub tampildpen()
        Dim tampildpen As New MySqlDataAdapter("select * from pengembalian", dbcon)
        dpen.Clear()
        tampildpen.Fill(dpen)
        DataGridView5.DataSource = dpen
    End Sub
    Sub bersihdpen()
        Dim int As Integer
        Integer.TryParse(ComboBox4.Text, int)
        ComboBox4.Text = (int + 1)
        DateTimePicker3.Text = ""
    End Sub

    Private Sub TabPage6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TabPage6.Click
        Call koneksi()
        Call tampildpen()
        Call isiCombo()
    End Sub

    Sub isiCombo()
        koneksi()
        Dim q As New MySqlCommand("Select * from peminjaman", dbcon)
        Try
            dbread = q.ExecuteReader
            While dbread.Read
                ComboBox4.Items.Add(dbread(0))
            End While
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub Button11_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button11.Click
        Call koneksi()
        Dim simpandpen As New MySqlCommand("insert into pengembalian(`id_peminjaman`, `tgl_kembali`) VALUE('" & ComboBox4.Text & "','" & DateTimePicker3.Text & "')", dbcon)
        Try
            If simpandpen.ExecuteNonQuery() = 1 Then
                MsgBox("Data Berhasil Disimpan")
                bersihdpen()
                tampildpen()
                TextBox11.Focus()
                Exit Sub
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub ComboBox4_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox4.SelectedIndexChanged
        koneksi()
        Dim q As New MySqlCommand("select * from peminjaman where id_peminjaman = '" & ComboBox4.SelectedItem & "'", dbcon)
        Try
            Dim row As MySqlDataReader = q.ExecuteReader()
            While row.Read()
                TextBox13.Text = row("judul_buku").ToString()
                TextBox14.Text = row("nama_member").ToString()
                TextBox15.Text = row("nama_petugas").ToString()
                DateTimePicker6.Text = row("tgl_pinjam").ToString()
                DateTimePicker7.Text = row("tgl_kembali").ToString()
                'ComboBox2.SelectedItem = "Belum Kembali"'
            End While
            row.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

End Class



