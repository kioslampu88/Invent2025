Imports System.Drawing.Printing
Imports Invent2025.GlobalClass


Public Class frmPenjualan
    Inherits Form
    Implements IFormWithMode

    Private formState As New FormStatusManager()
    Private printRowIndex As Integer = 0
    Private dtGrid As DataTable

    Dim SellId As Integer

    Public Property ModeStatus As Mode Implements IFormWithMode.ModeStatus
        Get
            Return formState.CurrentMode
        End Get
        Set(value As Mode)
            formState.CurrentMode = value
            ' Optional: handle internal UI di sini
        End Set
    End Property

    Public Sub OnToolbarClick(modeCommand As Mode) Implements IFormWithMode.OnToolbarClick

        formState.CurrentMode = modeCommand

        Select Case modeCommand
            Case Mode.NewType
                ' Bersihkan form
                ClearAllInputs(Me, formState)
                DataGrid_Refill(0)

            Case Mode.EditType
                ' Aktifkan edit

            Case Mode.SaveType
                ' Simpan data

            Case Mode.DeleteType
                ' Aktifkan edit

            Case Mode.PrintType
                ' Cetak
                CetakFormTransaksi(txtntCode.Text,
                       cmbnaEntity.Text,
                       mskDateTgl.Value,
                       cmbnaSalesman.Text,
                       UcInventDataGridView1)

            Case Mode.CancelType
                ' Batalkan perubahan
                ClearAllInputs(Me, formState)

            Case Mode.RefreshType
                ' Refresh data

        End Select

        ' Setelah update, suruh MDI update tombol
        CType(Me.MdiParent, MDIForm).UpdateToolbarFromChild()
        SetAllControlsByMode(Me, ModeStatus)
    End Sub

    Private Sub frmPenjualan_Load(sender As Object, e As EventArgs) Handles Me.Load

        SetAllControlsByMode(Me, ModeStatus)

        IsiCombo(GetObjectTypeSelect(8000), ucmbPembayaran, "ObjectDescription", "ObjectTypeId")
        IsiCombo(GetObjectTypeSelect(-2), cmbnaSalesman, "ObjectDescription", "ObjectTypeId")
        'IsiCombo(GetObjectTypeSelect(8000), ucmbPembayaran, "ObjectDescription", "ObjectTypeId")

        DataGrid_Refill(-1)

    End Sub

    Private Sub DataGrid_Refill(ByVal intSellId As Integer)

        Dim strSPName As String = "LxTranSellSelect"
        ' === INPUT PARAMETERS ===
        Dim inputParams As New Dictionary(Of String, Object) From {
            {"@SellId", intSellId}            'Object
            }

        ' === OUTPUT PARAMETERS ===
        Dim outputParams As New Dictionary(Of String, SqlDbType) From {
           }


        ' === TEMP RESULT HOLDER ===
        Dim outputResults As Dictionary(Of String, Object)
        Dim resultSets As List(Of DataTable)

        If ExecSP1(strSPName, inputParams, outputParams, outputResults, resultSets) Then


            If resultSets(0).Rows.Count > 0 Then
                txtntCode.Text = If(IsDBNull(resultSets(0).Rows(0)("TransactionCode")), "", resultSets(0).Rows(0)("TransactionCode").ToString())
                mskDateTgl.Value = If(IsDBNull(resultSets(0).Rows(0)("TransactionDate")), DateTime.Now, Convert.ToDateTime(resultSets(0).Rows(0)("TransactionDate")))
                mskDueDate.Value = If(IsDBNull(resultSets(0).Rows(0)("DueDate")), DateTime.Now, Convert.ToDateTime(resultSets(0).Rows(0)("DueDate")))
                cmbnaEntity.SelectedValue = If(IsDBNull(resultSets(0).Rows(0)("EntityId")), -1, Convert.ToInt32(resultSets(0).Rows(0)("EntityId")))
                ucmbPembayaran.SelectedValue = If(IsDBNull(resultSets(0).Rows(0)("ClassId")), -1, Convert.ToInt32(resultSets(0).Rows(0)("ClassId")))
                cmbnaSalesman.SelectedValue = If(IsDBNull(resultSets(0).Rows(0)("SalesId")), -1, Convert.ToInt32(resultSets(0).Rows(0)("SalesId")))
            End If

            With UcInventDataGridView1

                .VisibleColumns = New List(Of String) From {"Num", "QbItemName", "button1", "ItemName", "Quantity", "PriceNet", "TotalPriceNet"}

                .ColumnWidths = New Dictionary(Of String, Integer) From {
                    {"Num", 50},
                    {"QbItemName", 250},
                    {"ItemName", 500},
                    {"Quantity", 100},
                    {"PriceNet", 100},
                    {"TotalPriceNet", 100}
                }
                .ColumnAliases = New Dictionary(Of String, String) From {
                    {"Num", "No."},
                    {"QbItemName", "Kode Brg"},
                    {"button1", " "},
                    {"ItemName", "Nama Barang"},
                    {"Quantity", "Qty"},
                    {"PriceNet", "Hrg"},
                    {"TotalPriceNet", "Tot"}
                }

                .ButtonColumnName = "button1"
                dtGrid = resultSets(1)
                .DataSource = dtGrid

            End With
        End If


    End Sub



    Private Sub cmdSearchDoc_Click(sender As Object, e As EventArgs) Handles cmdSearchDoc.Click
        'dlgSearch.Show(Me)
        dlgSearch.DataGrid_Refill("SrcCreateInvoice")

        ' Tampilkan sebagai dialog modal
        Dim result = dlgSearch.ShowDialog(Me)

        ' (Opsional) Cek jika user menekan OK
        If result = DialogResult.OK Then
            ' Ambil data dari dlgSearch jika diperlukan


            DataGrid_Refill(dlgSearch.IDSrc)
        End If
    End Sub



    Public Sub CetakFormTransaksi(ByVal faktur As String,
                              ByVal pelanggan As String,
                              ByVal tglTransaksi As DateTime,
                              ByVal seller As String,
                              ByVal dgv As ucInventDataGridView)

        Dim pd As New PrintDocument()

        ' Kertas 1/4 A4 (A6 portrait)
        Dim paper As New PaperSize("A6", 413, 584)
        pd.DefaultPageSettings.PaperSize = paper

        AddHandler pd.PrintPage,
    Sub(sender As Object, e As PrintPageEventArgs)

        Dim g As Graphics = e.Graphics
        Dim fShopName As New Font("Arial", 9, FontStyle.Bold)
        Dim fHeader As New Font("Arial", 7, FontStyle.Bold)
        Dim fNormal As New Font("Arial", 7)

        Dim marginLeft As Integer = 10
        Dim marginRight As Integer = 25
        Dim marginTop As Integer = 5
        Dim marginBottom As Integer = 20

        Dim y As Integer = marginTop
        Dim rightLimit As Integer = e.PageBounds.Width - marginRight
        Dim pageWidth As Integer = e.MarginBounds.Width
        Dim fmtRight As New StringFormat() With {.Alignment = StringAlignment.Far}

        ' --- Header hanya di halaman pertama ---
        If printRowIndex = 0 Then
            g.DrawString("BANCEUY ELEKTRIK", fShopName, Brushes.Black, rightLimit - 150, y)
            y += 15
            g.DrawString("gg. Suniraja", fHeader, Brushes.Black, rightLimit - 150, y)
            y += 15
            g.DrawString("WA/HP: 085923232287", fHeader, Brushes.Black, rightLimit - 150, y)
            y += 25

            g.DrawString("FAKTUR PENJUALAN", fHeader, Brushes.Black, marginLeft, y)
            g.DrawString("No: " & faktur, fNormal, Brushes.Black, rightLimit - 150, y)
            y += 15



            g.DrawString("Pelanggan: " & pelanggan, fNormal, Brushes.Black, marginLeft, y) : y += 15

            g.DrawString("Seller   : " & seller, fNormal, Brushes.Black, marginLeft, y)
            g.DrawString("Tanggal  : " & tglTransaksi.ToString("dd-MM-yyyy"), fNormal, Brushes.Black, rightLimit - 150, y) : y += 15
        End If

        ' --- Judul tabel ---
        g.DrawString("No", fNormal, Brushes.Black, marginLeft, y)
        g.DrawString("Barang", fNormal, Brushes.Black, marginLeft + 20, y)

        ' Posisi angka rata kanan
        g.DrawString("Qty", fNormal, Brushes.Black, rightLimit - 150, y, fmtRight)
        g.DrawString("Harga", fNormal, Brushes.Black, rightLimit - 100, y, fmtRight)
        g.DrawString("Total", fNormal, Brushes.Black, rightLimit - 25, y, fmtRight)

        y += 15
        g.DrawLine(Pens.Black, marginLeft, y, rightLimit - 10, y)
        y += 5

        ' --- Isi Data ---
        Dim rowNo As Integer = printRowIndex + 1
        Dim grandTotal As Decimal = 0

        For i As Integer = printRowIndex To dgv.Rows.Count - 1
            Dim row As DataGridViewRow = dgv.Rows(i)
            If row.IsNewRow Then Continue For

            Dim nama As String = If(row.Cells("ItemName").Value, "").ToString()
            Dim qty As Decimal = If(IsDBNull(row.Cells("Quantity").Value) OrElse row.Cells("Quantity").Value Is Nothing, 0, Convert.ToDecimal(row.Cells("Quantity").Value))
            Dim harga As Decimal = If(IsDBNull(row.Cells("PriceNet").Value) OrElse row.Cells("PriceNet").Value Is Nothing, 0, Convert.ToDecimal(row.Cells("PriceNet").Value))
            Dim total As Decimal = If(IsDBNull(row.Cells("TotalPriceNet").Value) OrElse row.Cells("TotalPriceNet").Value Is Nothing, 0, Convert.ToDecimal(row.Cells("TotalPriceNet").Value))


            g.DrawString(rowNo.ToString(), fNormal, Brushes.Black, marginLeft, y)
            g.DrawString(nama, fNormal, Brushes.Black, marginLeft + 20, y)

            g.DrawString(qty.ToString("N0"), fNormal, Brushes.Black, rightLimit - 150, y, fmtRight)

            ' Harga
            g.DrawString(harga.ToString("N0"), fNormal, Brushes.Black, rightLimit - 100, y, fmtRight)

            ' Total (paling kanan)
            g.DrawString(total.ToString("N0"), fNormal, Brushes.Black, rightLimit - 25, y, fmtRight)

            y += 15
            rowNo += 1
            grandTotal += total
            printRowIndex = i + 1

            ' page break
            Dim bottomLimit As Integer = e.PageBounds.Bottom - 20 ' lebih dekat ke tepi kertas
            If y > bottomLimit Then
                e.HasMorePages = True
                Exit Sub
            End If
        Next

        ' --- Grand Total (hanya di halaman terakhir) ---
        'y += 10
        'g.DrawLine(Pens.Black, marginLeft, y, marginLeft + 360, y)
        'y += 5
        y += 5
        g.DrawLine(Pens.Black, marginLeft, y, rightLimit - 10, y)
        y += 5
        g.DrawString("GRAND TOTAL:", fShopName, Brushes.Black, rightLimit - 200, y)
        g.DrawString(grandTotal.ToString("N0"), fShopName, Brushes.Black, rightLimit - 25, y, fmtRight)


        ' Selesai, reset index
        printRowIndex = 0
        e.HasMorePages = False
    End Sub


        ' === Pilihan pakai MsgBox ===
        Dim pilihan As MsgBoxResult = MsgBox("Tampilkan preview sebelum print?", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "Cetak Faktur")

        If pilihan = MsgBoxResult.Yes Then
            ' Preview
            Dim preview As New PrintPreviewDialog()
            preview.Document = pd
            preview.WindowState = FormWindowState.Maximized
            preview.PrintPreviewControl.Zoom = 1.0
            preview.ShowDialog()
        Else
            ' Langsung print (dengan dialog pilih printer)
            Dim dlg As New PrintDialog()
            dlg.Document = pd
            If dlg.ShowDialog() = DialogResult.OK Then
                pd.PrinterSettings = dlg.PrinterSettings
                pd.DefaultPageSettings.PaperSize = paper
                pd.Print()
            End If
        End If
    End Sub



    Private Sub UcInventDataGridView1_CellButtonClick(sender As Object, e As DataGridViewCellEventArgs) Handles UcInventDataGridView1.CellButtonClick
        If e.RowIndex < 0 OrElse e.ColumnIndex < 0 Then Exit Sub

        MessageBox.Show(UcInventDataGridView1._isGridEnabled)
        ' Cek apakah kolom yang diklik adalah button1
        If UcInventDataGridView1.Columns(e.ColumnIndex).Name = "button1" Then


            MessageBox.Show("Tombol di baris " & e.RowIndex & " diklik.")
            dlgSearch.DataGrid_Refill("SrcItem")

            ' Tampilkan sebagai dialog modal
            Dim result = dlgSearch.ShowDialog(Me)

            ' (Opsional) Cek jika user menekan OK
            If result = DialogResult.OK Then
                ' Ambil data dari dlgSearch jika diperlukan
                MessageBox.Show("Data terpilih: " & dlgSearch.IDSrc)
                'MsgBox("Masuk")

                Dim ItemPick As DataTable = GetItemData(dlgSearch.IDSrc, "")
                Dim r As DataRow = ItemPick.Rows(0)

                dtGrid.Rows(e.RowIndex)("QbItemName") = r("QBItemId")
                dtGrid.Rows(e.RowIndex)("ItemName") = r("ItemName")
                dtGrid.Rows(e.RowIndex)("PriceNet") = r("SellPrice")
                dtGrid.Rows(e.RowIndex)("MasterItemId") = r("MasterItemId")
                dtGrid.Rows(e.RowIndex)("CheckHarga") = r("CheckHarga")
                dtGrid.Rows(e.RowIndex)("CheckSerial") = r("CheckSerialNum")
            End If
        End If
    End Sub
End Class