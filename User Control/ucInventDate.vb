Imports Invent2025.GlobalClass

Public Class ucInventDate
    Inherits UserControl

    Implements IFormWithModeSupport

    Private WithEvents dte As New DateTimePicker

    ' --- Properti kontrol aktif pada mode tertentu ---
    Private _enabledOnModes As New List(Of Mode)
    Private _disabledOnModes As New List(Of Mode)
    Private _modeSaatIni As Mode
    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' 🌐 Set format tanggal
        dte.Format = DateTimePickerFormat.Custom
        dte.Value = DateTime.Today
        dte.CustomFormat = "dd-MM-yyyy"


        ' Add any initialization after the InitializeComponent() call.
        dte.Dock = DockStyle.Fill
        Me.Controls.Add(dte)

        ' Atur ukuran UserControl mengikuti ComboBox
        Me.Height = dte.PreferredHeight
        Me.Width = 150 ' Default width, bisa diubah di Designer


    End Sub
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

    Private Sub UpdateEnabledState()


        If _disabledOnModes.Contains(_modeSaatIni) Then
            dte.Enabled = False
        ElseIf _enabledOnModes.Count > 0 Then
            dte.Enabled = _enabledOnModes.Contains(_modeSaatIni)
        Else
            dte.Enabled = True
        End If

        Dim isEnabled As Boolean = dte.Enabled

        ' Warna ketika disable atau enable
        If isEnabled Then
            dte.BackColor = SystemColors.Window
            dte.ForeColor = SystemColors.ControlText
        Else
            dte.BackColor = Color.LightGray  ' warna lebih tua
            dte.ForeColor = Color.DarkGray
        End If
    End Sub

    Public ReadOnly Property TanggalFormatted As String
        Get
            Return dte.Value.ToString("yyyyMMdd")
        End Get
    End Property

    Public Property Value As Date
        Get
            Return dte.Value
        End Get
        Set(value As Date)
            dte.Value = value
        End Set
    End Property
End Class
