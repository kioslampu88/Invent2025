Public Class frmHasilDataTable
    Private Sub frmHasilDataTable_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        With DataGridView1
            .EnableHeadersVisualStyles = False ' biar warna header bisa diubah
            .ColumnHeadersDefaultCellStyle.BackColor = Color.DarkBlue
            .ColumnHeadersDefaultCellStyle.ForeColor = Color.White
            .ColumnHeadersDefaultCellStyle.Font = New Font("VERDANA", 9, FontStyle.Bold)
            .ColumnHeadersHeight = 30

            .GridColor = Color.Black
            .CellBorderStyle = DataGridViewCellBorderStyle.Single
            .RowHeadersVisible = False
            .BackgroundColor = Color.White
            .DefaultCellStyle.BackColor = Color.White
            .DefaultCellStyle.ForeColor = Color.Black
            .DefaultCellStyle.SelectionBackColor = Color.LightBlue
            .DefaultCellStyle.SelectionForeColor = Color.Black

        End With
    End Sub

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick

    End Sub

    Private Sub DataGridView1_DataBindingComplete(sender As Object, e As DataGridViewBindingCompleteEventArgs) Handles DataGridView1.DataBindingComplete
        With DataGridView1
            ' Pastikan tidak resize otomatis semua kolom
            .AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None

            ' Set kolom terakhir agar "mengisi sisa ruang"
            If .Columns.Count > 0 Then
                For i As Integer = 0 To .Columns.Count - 2
                    .Columns(i).AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                    .Columns(i).Width = 100 ' atau sesuai kebutuhan
                Next

                ' Kolom terakhir pakai Fill
                .Columns(.Columns.Count - 1).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            End If

            ' Tambahan styling jika mau
            .ColumnHeadersDefaultCellStyle.BackColor = Color.DarkBlue
            .ColumnHeadersDefaultCellStyle.ForeColor = Color.White
            .EnableHeadersVisualStyles = False
        End With

        Dim dgv As DataGridView = CType(sender, DataGridView)

        For Each col As DataGridViewColumn In dgv.Columns
            ' Deteksi tipe data dari kolom
            Dim colType As Type = col.ValueType

            If colType IsNot Nothing Then
                If colType = GetType(String) Then
                    col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft

                ElseIf colType = GetType(Integer) OrElse
                       colType = GetType(Decimal) OrElse
                       colType = GetType(Double) OrElse
                       colType = GetType(Single) OrElse
                       colType = GetType(Long) Then
                    col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    col.DefaultCellStyle.Format = "N0" ' Tambahkan format jika mau

                ElseIf colType = GetType(Date) OrElse colType = GetType(DateTime) Then
                    col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                    col.DefaultCellStyle.Format = "dd/MM/yyyy" ' optional
                End If
            End If
        Next
    End Sub
End Class