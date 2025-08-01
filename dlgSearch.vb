Public Class dlgSearch

    Private calendarRowIndex As Integer
    Private calendarColumnIndex As Integer

    Dim mySrcTable As DataTable
    Dim myParamTableHeader As DataTable
    Dim myParamTable As DataTable


    Dim popupForm As Form
    Dim popupCalendar As New MonthCalendar


    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub

    Private Sub ucbtnExit_Click(sender As Object, e As EventArgs) Handles ucbtnExit.Click
        Me.Dispose()
        Me.Close()
    End Sub

    Private Sub DataRefill()
        With myParamTableHeader
            Dim strSPName As String = .Rows(0)("SrcSprocName").ToString()


            Dim inputList As New List(Of Object) From {123, 45600}


            Dim resultSets As List(Of DataTable)
            Dim outputResults As Dictionary(Of String, Object)

            ExecSP1_Urutan(strSPName, inputList, Nothing, outputResults, resultSets)

        End With

    End Sub

    Public Sub DataGrid_Refill(ByVal strSrcName As String)

        Dim strSPName As String = "LxSrcMaster"
        ' === INPUT PARAMETERS ===
        Dim inputParams As New Dictionary(Of String, Object) From {
            {"@SrcName", strSrcName}            'Object
            }

        ' === OUTPUT PARAMETERS ===
        Dim outputParams As New Dictionary(Of String, SqlDbType) From {
           }


        ' === TEMP RESULT HOLDER ===
        Dim outputResults As Dictionary(Of String, Object)
        Dim resultSets As List(Of DataTable)

        If ExecSP1(strSPName, inputParams, outputParams, outputResults, resultSets) Then



            With udgvParam

                .VisibleColumns = New List(Of String) From {"ParamDisplay", "ParamDefValue"}

                .ColumnWidths = New Dictionary(Of String, Integer) From {
                    {"ParamDisplay", 100},
                    {"ParamDefValue", 250}
                }

                .ColumnAliases = New Dictionary(Of String, String) From {
                    {"ParamDisplay", "Key"},
                    {"ParamDefValue", "Value"}
                }

                '.ButtonColumnName = "button1"
                .DataSource = resultSets(1)

                myParamTableHeader = resultSets(0)
                myParamTable = resultSets(1)

            End With

            ApplyParamSettingsToDataGridView(udgvParam, resultSets(1))


        End If


    End Sub

    Public Sub ApplyParamSettingsToDataGridView(ByVal dgv As ucInventDataGridView, ByVal paramTable As DataTable)
        'dgv.Columns.Clear()
        'dgv.Rows.Clear()

        ' Tambah kolom ke-6 sebagai kolom target (misalnya untuk isian)
        'dgv.Columns.Add(New DataGridViewTextBoxColumn() With {.HeaderText = "Input", .Name = "InputCol"})

        Dim setFocusRow As Integer = -1

        For i As Integer = 0 To paramTable.Rows.Count - 1
            Dim rowData As DataRow = paramTable.Rows(i)
            Dim displayType As String = rowData("ParamDisplayType").ToString().ToUpper()

            ' Tambahkan baris baru
            'dgv.Rows.Add()
            Dim row As DataGridViewRow = dgv.Rows(i)

            ' Tentukan jenis kolom jika perlu
            Select Case displayType
                Case "MASK"

                    Dim combocell As New DataGridViewButtonCell
                    ' Gunakan CellFormatting atau kustom MaskedTextBox
                    row.Cells("ParamDefValue") = combocell
                    row.Cells("ParamDefValue").Value = ""
                    row.Cells("ParamDefValue").Tag = rowData("ParamFormat") ' Simpan format untuk dipakai saat edit
                    'row.Cells("ParamDefValue").Style.Format = rowData("ParamFormat").ToString()
                    row.Cells("ParamDefValue").Style.BackColor = Color.LightYellow


                Case "COMBO"
                    ' Ganti Cell jadi ComboBoxCell
                    Dim comboData As String = rowData("ParamComboData").ToString()
                    Dim comboItems As String() = comboData.Split(";"c)

                    Dim comboCell As New DataGridViewComboBoxCell()
                    comboCell.Items.AddRange(comboItems)
                    row.Cells("ParamDefValue") = comboCell
                    row.Cells("ParamDefValue").Style.BackColor = Color.LightCyan

                Case "HIDE"
                    row.Visible = False
            End Select

            ' Cek SetFocus
            If Not IsDBNull(rowData("SetFocus")) AndAlso rowData("SetFocus") = 1 Then
                setFocusRow = i
            End If
        Next

        ' Set fokus ke baris yang diminta
        If setFocusRow >= 0 Then
            dgv.CurrentCell = dgv.Rows(setFocusRow).Cells("ParamDefValue")
            dgv.BeginEdit(True)
        End If
    End Sub


    Private Sub dlgSearch_Load(sender As Object, e As EventArgs) Handles Me.Load

        popupCalendar = New MonthCalendar()
        popupCalendar.MaxSelectionCount = 1

        popupForm = New Form()
        popupForm.FormBorderStyle = FormBorderStyle.None
        popupForm.ShowInTaskbar = False
        popupForm.TopMost = True
        popupForm.StartPosition = FormStartPosition.Manual
        popupForm.AutoSize = True
        popupForm.AutoSizeMode = AutoSizeMode.GrowAndShrink

        popupForm.Controls.Add(popupCalendar)

        ' Optional: Event jika tanggal dipilih
        AddHandler popupCalendar.DateSelected, AddressOf popupCalendar_DateSelected
        AddHandler popupForm.Deactivate, AddressOf popupForm_LostFocus

        AddHandler udgvParam.InnerDGV.CellClick, AddressOf dgv_CellClick
        AddHandler udgvParam.CellButtonClick, AddressOf Grid_TanggalClick


    End Sub

    Private Sub dgv_CellClick(sender As Object, e As DataGridViewCellEventArgs)
        If e.RowIndex < 0 OrElse e.ColumnIndex < 0 Then Exit Sub


        Dim dgv = udgvParam.InnerDGV

        If e.RowIndex = dgv.Rows.Count - 1 Then Exit Sub

        If dgv.Columns(e.ColumnIndex).Name = "ParamDefValue" And dgv.Rows(e.RowIndex).Cells("ParamDataType").Value = "datetime" Then
            Dim cellRect = dgv.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, True)
            Dim screenPos = dgv.PointToScreen(New Point(cellRect.Left, cellRect.Bottom))

            calendarRowIndex = e.RowIndex
            calendarColumnIndex = e.ColumnIndex

            popupForm.Location = screenPos
            popupForm.Show()
            popupForm.BringToFront()
            popupForm.Focus()

        End If


    End Sub

    Private Sub popupCalendar_DateSelected(sender As Object, e As DateRangeEventArgs)
        Dim dgv = udgvParam.InnerDGV
        If popupForm.Visible Then popupForm.Hide()
        'popupCalendar.Visible = False
        dgv.Rows(calendarRowIndex).Cells(calendarColumnIndex).Value = e.Start.ToString("dd/MM/yyyy")
    End Sub

    Private Sub Grid_TanggalClick(sender As Object, e As DataGridViewCellEventArgs)
        Dim dgv = udgvData.InnerDGV

        MsgBox("Grid_TanggalClick: " & e.RowIndex & ", " & e.ColumnIndex)
        Dim cellRect = dgv.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, True)
        popupCalendar.Location = dgv.PointToScreen(New Point(cellRect.Left, cellRect.Bottom))
        popupCalendar.Visible = True

        calendarRowIndex = e.RowIndex
        calendarColumnIndex = e.ColumnIndex

    End Sub



    Private Sub popupForm_MouseDown(sender As Object, e As MouseEventArgs) Handles Me.MouseDown
        If popupForm.Visible Then popupForm.Hide()
    End Sub

    Private Sub popupForm_LostFocus(sender As Object, e As EventArgs)
        If popupForm.Visible Then popupForm.Hide()
    End Sub

    Private Sub ucbtnRefresh_Click(sender As Object, e As EventArgs) Handles ucbtnRefresh.Click
        DataRefill()
    End Sub
End Class