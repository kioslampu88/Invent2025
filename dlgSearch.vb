Imports Invent2025.GlobalClass
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
            Dim inputList As New List(Of Object)

            SimpanParamKeDataTable(udgvParam1.InnerDGV, myParamTable)

            For Each row As DataRow In myParamTable.Rows
                inputList.Add(row("ParamDefValue"))
            Next


            Dim resultSets As List(Of DataTable)
            Dim outputResults As Dictionary(Of String, Object)

            If ExecSP1_Urutan(strSPName, inputList, Nothing, outputResults, resultSets) Then
                udgvData.DataSource = resultSets(0)
            End If

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



            With udgvParam1

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
                '.DataSource = resultSets(1)

                myParamTableHeader = resultSets(0)
                myParamTable = resultSets(1)

            End With

            ApplyParamSettingsToDataGridView(udgvParam1, resultSets(1))


        End If


    End Sub

    Public Sub ApplyParamSettingsToDataGridView(ByVal dgv As ucInventDataGridView, ByVal paramTable As DataTable)

        With dgv
            .Columns.Clear()
            .Rows.Clear()

            ' Kolom untuk nama parameter
            .Columns.Add(New DataGridViewTextBoxColumn() With {
                .Name = "ParamName",
                .HeaderText = "Parameter"
            })

            ' Kolom untuk nilai / input (akan kita set jenis cell-nya nanti)
            .Columns.Add(New DataGridViewTextBoxColumn() With {
                .Name = "ParamDefValue",
                .HeaderText = "Nilai"
            })
        End With

        Dim setFocusRow As Integer = -1

        For i As Integer = 0 To paramTable.Rows.Count - 1
            Dim rowData As DataRow = paramTable.Rows(i)
            Dim displayType As String = rowData("ParamDisplayType").ToString().ToUpper()

            ' Tambahkan baris kosong dulu
            Dim idx As Integer = dgv.Rows.Add()
            Dim row As DataGridViewRow = dgv.Rows(idx)

            row.Cells("ParamName").Value = rowData("ParamDisplay").ToString()

            ' Ganti tipe cell sesuai displayType
            Select Case displayType
                Case "COMBO"
                    Dim comboCell As New DataGridViewComboBoxCell()
                    'Dim items As String()
                    Dim dtCombo As List(Of DataTable)
                    'Dim outputResults As Dictionary(Of String, Object)

                    ExecSP1_Urutan("LxSrcComboParam", New List(Of Object) From {rowData("ParamComboData")}, Nothing, Nothing, dtCombo)


                    comboCell.DataSource = dtCombo(0)
                    comboCell.DisplayMember = "ItemDisplay"
                    comboCell.ValueMember = "ItemId"
                    comboCell.Tag = "COMBO"
                    comboCell.Style.BackColor = Color.LightCyan

                    row.Cells("ParamDefValue") = comboCell

                    ' Set default value langsung
                    row.Cells("ParamDefValue").Value = rowData("ParamDefValue").ToString()

                Case "MASK"
                    Dim buttonCell As New DataGridViewButtonCell()
                    buttonCell.Value = ""
                    buttonCell.Tag = "MASK"
                    buttonCell.Style.BackColor = Color.LightYellow
                    row.Cells("ParamDefValue") = buttonCell

                Case Else ' TextBox default
                    row.Cells("ParamDefValue").Value = ""
            End Select

            ' Set Fokus
            If Not IsDBNull(rowData("SetFocus")) AndAlso rowData("SetFocus") = 1 Then
                setFocusRow = idx
            End If
        Next

        dgv.ExtendLastCol()

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

        AddHandler udgvParam1.InnerDGV.CellClick, AddressOf dgv_CellClick
        AddHandler udgvParam1.CellButtonClick, AddressOf Grid_TanggalClick
        'AddHandler udgvParam1.InnerDGV.DataError, AddressOf dgv_Dataerror

    End Sub

    Private Sub dgv_CellClick(sender As Object, e As DataGridViewCellEventArgs)
        If e.RowIndex < 0 OrElse e.ColumnIndex < 0 Then Exit Sub


        Dim dgv = udgvParam1.InnerDGV

        If e.RowIndex = dgv.Rows.Count - 1 Then Exit Sub

        If dgv.Columns(e.ColumnIndex).Name = "ParamDefValue" And dgv.Rows(e.RowIndex).Cells("ParamDefValue").Tag = "MASK" Then
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
        Dim dgv = udgvParam1.InnerDGV
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

    Private Sub HandleDataError(sender As Object, e As DataGridViewDataErrorEventArgs)
        e.Cancel = True
    End Sub

    Public Sub SimpanParamKeDataTable(ByVal dgv As DataGridView, ByVal dt As DataTable)
        Debug.Print("dgv.Rows.Count = " & dgv.Rows.Count)
        Debug.Print("dt.Rows.Count = " & dt.Rows.Count)

        For i As Integer = 0 To dgv.Rows.Count - 1
            Dim dgvRow As DataGridViewRow = dgv.Rows(i)

            Dim dtRow As DataRow
            If i < dt.Rows.Count Then
                dtRow = dt.Rows(i)
            Else
                Exit For
            End If
            'Dim dtRow As DataRow = dt.Rows(i)

            Dim cellValue As Object = dgvRow.Cells("ParamDefValue").Value

            If TypeOf cellValue Is ComboItem Then
                dtRow("ParamDefValue") = CType(cellValue, ComboItem).Value
            Else
                dtRow("ParamDefValue") = cellValue
            End If


        Next
    End Sub
End Class