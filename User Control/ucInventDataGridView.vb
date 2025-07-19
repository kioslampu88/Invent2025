Imports Invent2025.GlobalClass

Public Class ucInventDataGridView
    Inherits UserControl

    Implements IFormWithModeSupport

    Private WithEvents dgv As New DataGridView()

    Private _enabledOnModes As New List(Of Mode)
    Private _disabledOnModes As New List(Of Mode)
    Private _modeSaatIni As Mode

    ' Key = nama kolom asli di DataTable
    ' Value = nama header yang ditampilkan di DataGridView
    Public Property ColumnAliases As Dictionary(Of String, String) = New Dictionary(Of String, String)


    ' Kolom yang ingin ditampilkan
    Public Property VisibleColumns As List(Of String) = New List(Of String)

    ' Lebar kolom (optional)
    Public Property ColumnWidths As Dictionary(Of String, Integer) = New Dictionary(Of String, Integer)

    ' Kolom tombol cari
    Public Property ButtonColumnName As String = ""



    Public Sub New()
        InitializeComponent()
        dgv.Dock = DockStyle.Fill
        Me.Controls.Add(dgv)
        Me.Width = 150

        With dgv
            .EnableHeadersVisualStyles = False
            .ColumnHeadersDefaultCellStyle.BackColor = Color.DarkBlue
            .ColumnHeadersDefaultCellStyle.ForeColor = Color.White
            .ColumnHeadersDefaultCellStyle.Font = New Font("Verdana", 9, FontStyle.Bold)
            .ColumnHeadersHeight = 30
            .AllowUserToResizeRows = False

            .SelectionMode = DataGridViewSelectionMode.FullRowSelect
            .DefaultCellStyle.SelectionBackColor = Color.LightGray
            .DefaultCellStyle.SelectionForeColor = Color.Black

            .GridColor = Color.Black
            .CellBorderStyle = DataGridViewCellBorderStyle.Single
            .RowHeadersVisible = False
            .BackgroundColor = Color.White
            .DefaultCellStyle.BackColor = Color.White
            .DefaultCellStyle.ForeColor = Color.Black

        End With
    End Sub

    ' === PROPERTY MODE ===
    Public Property EnabledOnModes As List(Of Mode) Implements IFormWithModeSupport.EnabledOnModes
        Get
            Return _enabledOnModes
        End Get
        Set(value As List(Of Mode))
            _enabledOnModes = value
            UpdateEnabledState()
        End Set
    End Property

    Public Property DisabledOnModes As List(Of Mode) Implements IFormWithModeSupport.DisabledOnModes
        Get
            Return _disabledOnModes
        End Get
        Set(value As List(Of Mode))
            _disabledOnModes = value
            UpdateEnabledState()
        End Set
    End Property

    Public Property ModeSaatIni As Mode Implements IFormWithModeSupport.ModeSaatIni
        Get
            Return _modeSaatIni
        End Get
        Set(value As Mode)
            _modeSaatIni = value
            UpdateEnabledState()
        End Set
    End Property

    Public Property [ReadOnly] As Boolean
        Get
            Return dgv.ReadOnly
        End Get
        Set(value As Boolean)
            dgv.ReadOnly = value
        End Set
    End Property
    Private Sub UpdateEnabledState()
        If _disabledOnModes.Contains(_modeSaatIni) Then
            dgv.Enabled = False
        ElseIf _enabledOnModes.Count > 0 Then
            dgv.Enabled = _enabledOnModes.Contains(_modeSaatIni)
        Else
            dgv.Enabled = True
        End If

        Dim isEnabled As Boolean = dgv.Enabled
        dgv.BackColor = If(isEnabled, SystemColors.Window, Color.LightGray)
        dgv.ForeColor = If(isEnabled, SystemColors.ControlText, Color.DarkGray)
    End Sub

    ' === PROPERTY EKSPOS ===
    Public Property DataSource As Object
        Get
            Return dgv.DataSource
        End Get
        Set(value As Object)
            dgv.DataSource = Nothing
            dgv.Columns.Clear()

            dgv.DataSource = value
            SetupColumns()
        End Set
    End Property

    Public ReadOnly Property Columns As DataGridViewColumnCollection
        Get
            Return dgv.Columns
        End Get
    End Property

    Public Sub Clear()
        dgv.DataSource = Nothing
        dgv.Columns.Clear()
    End Sub

    ' === SETUP COLUMNS ===
    Private Sub SetupColumns()
        If dgv.DataSource Is Nothing OrElse Not TypeOf dgv.DataSource Is DataTable Then Exit Sub

        Dim dt As DataTable = CType(dgv.DataSource, DataTable)

        dgv.AutoGenerateColumns = False

        ' Sembunyikan semua kolom dulu
        For Each col As DataGridViewColumn In dgv.Columns
            col.Visible = False
        Next

        ' Tampilkan hanya kolom yang ditentukan dalam VisibleColumns
        For Each colName As String In VisibleColumns
            If dgv.Columns.Contains(colName) Then
                With dgv.Columns(colName)
                    .Visible = True

                    ' Ganti HeaderText jika ada alias
                    If ColumnAliases.ContainsKey(colName) Then
                        .HeaderText = ColumnAliases(colName)
                    Else
                        .HeaderText = colName
                    End If

                    ' Atur lebar kolom jika tersedia
                    If ColumnWidths.ContainsKey(colName) Then
                        .Width = ColumnWidths(colName)
                    End If

                    ' Format numerik rata kanan
                    Dim sampleRow = dt.Rows.Cast(Of DataRow).FirstOrDefault()
                    If sampleRow IsNot Nothing AndAlso IsNumeric(sampleRow(colName)) Then
                        .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                        .DefaultCellStyle.Format = "N0"
                    Else
                        .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                    End If
                End With
            End If
        Next

        ' Tambahkan tombol button jika ButtonColumnName diatur
        If Not String.IsNullOrEmpty(ButtonColumnName) AndAlso dgv.Columns.Contains(ButtonColumnName) Then
            Dim colIndex As Integer = dgv.Columns(ButtonColumnName).Index

            ' Hapus kolom dari DataTable agar tidak digenerate ulang
            If CType(dgv.DataSource, DataTable).Columns.Contains(ButtonColumnName) Then
                CType(dgv.DataSource, DataTable).Columns.Remove(ButtonColumnName)
            End If

            ' Hapus kolom asli
            dgv.Columns.RemoveAt(colIndex)

            ' Buat kolom button dengan nama yang sama
            Dim btnCol As New DataGridViewButtonColumn()
            btnCol.Name = ButtonColumnName
            btnCol.HeaderText = If(ColumnAliases.ContainsKey(ButtonColumnName), ColumnAliases(ButtonColumnName), ButtonColumnName)
            btnCol.Text = "..."
            btnCol.UseColumnTextForButtonValue = True
            btnCol.Width = If(ColumnWidths.ContainsKey(ButtonColumnName), ColumnWidths(ButtonColumnName), 30)

            ' Sisipkan kembali di posisi yang sama
            dgv.Columns.Insert(colIndex, btnCol)
        End If

        ' Extend kolom terakhir agar memenuhi lebar grid
        Dim lastVisible = dgv.Columns.Cast(Of DataGridViewColumn)().
                          Where(Function(c) c.Visible AndAlso Not TypeOf c Is DataGridViewButtonColumn).
                          LastOrDefault()

        If lastVisible IsNot Nothing Then
            lastVisible.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        End If
    End Sub


End Class
