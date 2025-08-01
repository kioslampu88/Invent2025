Imports Invent2025.GlobalClass

Public Class frmPenjualan
    Inherits Form
    Implements IFormWithMode

    Private formState As New FormStatusManager()

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

            Case Mode.EditType
                ' Aktifkan edit

            Case Mode.SaveType
                ' Simpan data

            Case Mode.DeleteType
                ' Aktifkan edit

            Case Mode.PrintType
                ' Cetak

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
                .DataSource = resultSets(1)

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
            ' Contoh: selectedRow = dlgSearch.SelectedRow
            MsgBox("Masuk")
        End If
    End Sub
End Class