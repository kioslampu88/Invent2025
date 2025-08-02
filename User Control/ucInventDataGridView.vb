Imports Invent2025.GlobalClass

Public Class ucInventDataGridView
    Inherits UserControl

    Implements IFormWithModeSupport

    Private WithEvents dgv As New DataGridView()
    Public Event CellButtonClick(sender As Object, e As DataGridViewCellEventArgs)

    Private _enabledOnModes As New List(Of Mode)
    Private _disabledOnModes As New List(Of Mode)
    Private _modeSaatIni As Mode
    Private _isGridEnabled As Boolean = True


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

        AddHandler dgv.EditingControlShowing, AddressOf dgv_EditingControlShowing
        AddHandler dgv.CellClick, AddressOf DGV_CellClick
    End Sub

    ' === PROPERTY MODE ===
    Public ReadOnly Property Rows As DataGridViewRowCollection
        Get
            Return dgv.Rows
        End Get
    End Property

    Public ReadOnly Property Grid As DataGridView
        Get
            Return dgv
        End Get
    End Property

    Public Property CurrentCell As DataGridViewCell
        Get
            Return dgv.CurrentCell
        End Get
        Set(value As DataGridViewCell)
            dgv.CurrentCell = value
        End Set
    End Property



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
        Dim isReadOnly As Boolean


        _isGridEnabled = Not isReadOnly

        If _disabledOnModes.Contains(_modeSaatIni) Then
            isReadOnly = True
        ElseIf _enabledOnModes.Count > 0 Then
            isReadOnly = Not _enabledOnModes.Contains(_modeSaatIni)
        Else
            isReadOnly = False
        End If

        dgv.ReadOnly = isReadOnly
        'dgv.DefaultCellStyle.BackColor = If(isReadOnly, Color.LightGray, SystemColors.Window)
        'dgv.DefaultCellStyle.ForeColor = If(isReadOnly, Color.DarkGray, SystemColors.ControlText)

        ' Supaya tidak bisa fokus baris saat readonly
        'If isReadOnly Then
        '    dgv.ClearSelection()
        '    dgv.CurrentCell = Nothing
        'End If
    End Sub

    Public Event ButtonClicked(sender As Object, row As DataGridViewRow, columnName As String)

    Private Sub dgv_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgv.CellContentClick
        If Not _isGridEnabled Then
            ' Blok klik saat disable
            Return
        End If

        ' Jika kolom yang diklik adalah kolom tombol, lakukan sesuatu
        If dgv.Columns(e.ColumnIndex) IsNot Nothing AndAlso
       TypeOf dgv.Columns(e.ColumnIndex) Is DataGridViewButtonColumn Then

            Dim colName = dgv.Columns(e.ColumnIndex).Name
            ' Raise event atau logic khusus
            RaiseEvent ButtonClicked(Me, dgv.Rows(e.RowIndex), colName)
        End If
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

    Public Sub BeginEdit(Optional selectAll As Boolean = True)
        dgv.BeginEdit(selectAll)
    End Sub

    Private Sub dgv_EditingControlShowing(sender As Object, e As DataGridViewEditingControlShowingEventArgs)

        '' Hanya untuk kolom "ParamDefValue"
        If dgv.CurrentCell IsNot Nothing AndAlso dgv.Columns(dgv.CurrentCell.ColumnIndex).Name = "ParamDefValue" Then
            ' Cek apakah sudah ada masked editor sebelumnya
            Dim oldMasked = dgv.Controls.OfType(Of MaskedTextBox).FirstOrDefault()
            If oldMasked IsNot Nothing Then
                dgv.Controls.Remove(oldMasked)
            End If

            ' Ambil mask dari Cell.Tag (jika tersedia)
            Dim maskFormat As String = "00-00-0000"
            If dgv.CurrentCell.Tag IsNot Nothing Then
                maskFormat = dgv.CurrentCell.Tag.ToString()
            End If

            ' Buat MaskedTextBox
            If TypeOf e.Control Is TextBox Then
                Dim tb As TextBox = DirectCast(e.Control, TextBox)
                ' Lanjutkan logic khusus untuk TextBox (misal pasang MaskedTextBox)
                Dim masked As New MaskedTextBox()
                masked.Mask = maskFormat
                masked.Text = CType(e.Control, TextBox).Text
                masked.Name = "maskedEditor"
                masked.Dock = DockStyle.Fill

                ' Tambahkan ke kontrol
                AddHandler masked.Validating, AddressOf Masked_Validating
                dgv.Controls.Add(masked)
                masked.Focus()
            End If



        End If
    End Sub

    Private Sub Masked_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs)
        Dim masked = DirectCast(sender, MaskedTextBox)
        If dgv.CurrentCell IsNot Nothing Then
            dgv.CurrentCell.Value = masked.Text
            dgv.Controls.Remove(masked)
        End If
    End Sub

    Public ReadOnly Property InnerDGV As DataGridView
        Get
            Return Me.dgv
        End Get
    End Property

    Private Sub DGV_CellClick(sender As Object, e As DataGridViewCellEventArgs)
        If e.RowIndex >= 0 AndAlso dgv.Columns(e.ColumnIndex).Name = "Tanggal" Then
            RaiseEvent CellButtonClick(Me, e)
        End If
    End Sub

End Class
