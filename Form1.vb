Imports Invent2025.GlobalClass


Public Class MDIForm
    Private Sub MDIForm_Load(sender As Object, e As EventArgs) Handles Me.Load

        Me.Visible = False
        InventModule.InitializeModule()

    End Sub
    Private Sub BukaFormMDI(ByVal frm As Form)
        ' Cek apakah form sudah dibuka
        For Each f As Form In Me.MdiChildren
            If f.Name = frm.Name Then
                f.Activate()
                PilihTabForm(frm.Name)
                Return
            End If
        Next

        ' Set properties form
        frm.MinimizeBox = False
        frm.ControlBox = True ' Jika ingin tetap ada tombol [X]
        frm.FormBorderStyle = FormBorderStyle.FixedSingle
        frm.MaximizeBox = False
        frm.WindowState = FormWindowState.Maximized

        ' Tambahkan form sebagai MDI Child
        AddHandler frm.FormClosing, AddressOf FormTutup
        frm.MdiParent = Me
        frm.Show()



        ' Tambah Tab Navigasi
        Dim tab As New TabPage(frm.Text)
        tab.Name = frm.Name
        TabControl1.TabPages.Add(tab)
        TabControl1.SelectedTab = tab
    End Sub

    Private Sub FormTutup(sender As Object, e As FormClosingEventArgs)
        Dim frm As Form = CType(sender, Form)

        Dim result As DialogResult = MessageBox.Show("Yakin ingin menutup form '" & frm.Text & "'?", "Konfirmasi", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If result = DialogResult.No Then
            e.Cancel = True ' Batalkan penutupan
            Return
        End If

        For Each tab As TabPage In TabControl1.TabPages
            If tab.Name = frm.Name Then
                TabControl1.TabPages.Remove(tab)
                Exit For
            End If
        Next
    End Sub
    Private Sub PilihTabForm(namaForm As String)
        For Each tab As TabPage In TabControl1.TabPages
            If tab.Name = namaForm Then
                TabControl1.SelectedTab = tab
                Exit For
            End If
        Next
    End Sub

    Private Sub MDIForm_Closed(sender As Object, e As EventArgs) Handles Me.Closed
        End
    End Sub

    Private Sub PembelianBarangToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PembelianBarangToolStripMenuItem.Click
        BukaFormMDI(New frmPembelian)

    End Sub

    Private Sub PenjualanToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PenjualanToolStripMenuItem.Click
        BukaFormMDI(New frmPenjualan)

    End Sub

    Private Sub TabControl1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles TabControl1.SelectedIndexChanged
        If TabControl1.SelectedTab Is Nothing Then Exit Sub

        Dim namaForm As String = TabControl1.SelectedTab.Name

        For Each frm As Form In Me.MdiChildren
            If frm.Name = namaForm Then
                frm.WindowState = FormWindowState.Maximized
                frm.Activate()
                Exit For
            End If
        Next
    End Sub

    Private Sub TabControl1_DrawItem(sender As Object, e As DrawItemEventArgs) Handles TabControl1.DrawItem
        Dim tabPage = TabControl1.TabPages(e.Index)
        Dim tabRect = TabControl1.GetTabRect(e.Index)
        Dim isSelected = (e.Index = TabControl1.SelectedIndex)

        ' Pilih warna background
        Dim backBrush As Brush = If(isSelected, Brushes.SteelBlue, Brushes.LightGray)
        Dim textBrush As Brush = If(isSelected, Brushes.White, Brushes.Black)

        ' Gambar latar belakang tab
        e.Graphics.FillRectangle(backBrush, tabRect)

        ' Gambar teks tab
        Dim format As New StringFormat With {.Alignment = StringAlignment.Center, .LineAlignment = StringAlignment.Center}
        e.Graphics.DrawString(tabPage.Text, TabControl1.Font, textBrush, tabRect, format)
    End Sub


End Class
