Public Class uctrlInventDataGrid
    ''' <summary>
    ''' Mode: "Baru" → buat 21 baris kosong dari struktur DataTable
    '''        "Restore" → tampilkan data apa adanya
    ''' </summary>
    Public Property ModeTransaksi As String = "Restore" ' Default

    ''' <summary>
    ''' Data yang dikirim dari luar, bisa berupa hasil dari SP atau buatan manual
    ''' </summary>
    Public Property SumberData As DataTable

    ''' <summary>
    ''' Daftar nama kolom yang memiliki tombol 'Cari' per baris
    ''' </summary>
    Public Property KolomDenganTombolCari As List(Of String)

    Public Sub TampilkanGrid()
        If SumberData Is Nothing Then Exit Sub

        ' Clone struktur kolom untuk customisasi
        Dim dtStruktur As DataTable = SumberData.Clone()
        SetupKolom(dtStruktur)

        ' Mode Restore → pakai data asli
        If ModeTransaksi = "Restore" Then
            DataGridView1.DataSource = SumberData
        ElseIf ModeTransaksi = "Baru" Then
            Dim dtKosong As DataTable = dtStruktur.Clone()
            For i As Integer = 1 To 21
                dtKosong.Rows.Add(dtKosong.NewRow())
            Next
            DataGridView1.DataSource = dtKosong
        End If
    End Sub

    Private Sub SetupKolom(dt As DataTable)
        DataGridView1.Columns.Clear()

        For Each col As DataColumn In dt.Columns
            Dim gridCol As New DataGridViewTextBoxColumn()
            gridCol.Name = col.ColumnName
            gridCol.HeaderText = col.ColumnName
            gridCol.DataPropertyName = col.ColumnName

            If IsNumericType(col.DataType) Then
                gridCol.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                gridCol.DefaultCellStyle.Format = "C0"
            Else
                gridCol.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            End If

            DataGridView1.Columns.Add(gridCol)

            If KolomDenganTombolCari IsNot Nothing AndAlso KolomDenganTombolCari.Contains(col.ColumnName) Then
                Dim btnCol As New DataGridViewButtonColumn()
                btnCol.Name = "btn_" & col.ColumnName
                btnCol.HeaderText = ""
                btnCol.Text = "Cari"
                btnCol.Width = 50
                btnCol.UseColumnTextForButtonValue = True
                DataGridView1.Columns.Add(btnCol)
            End If
        Next
    End Sub


End Class
