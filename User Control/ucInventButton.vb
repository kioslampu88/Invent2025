Imports Invent2025.GlobalClass

Public Class ucInventButton
    Inherits UserControl

    Implements IFormWithModeSupport

    Private WithEvents btn As New Button
    ' --- Properti kontrol aktif pada mode tertentu ---
    Private _enabledOnModes As New List(Of Mode)
    Private _disabledOnModes As New List(Of Mode)
    Private _modeSaatIni As Mode
    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        btn.Dock = DockStyle.Fill
        Me.Controls.Add(btn)

        ' Atur ukuran UserControl mengikuti ComboBox
        'Me.Height = btn.PreferredHeight
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
            btn.Enabled = False
        ElseIf _enabledOnModes.Count > 0 Then
            btn.Enabled = _enabledOnModes.Contains(_modeSaatIni)
        Else
            btn.Enabled = True
        End If

        Dim isEnabled As Boolean = btn.Enabled

        ' Warna ketika disable atau enable
        If isEnabled Then
            btn.BackColor = SystemColors.Window
            btn.ForeColor = SystemColors.ControlText
        Else
            btn.BackColor = Color.LightGray  ' warna lebih tua
            btn.ForeColor = Color.DarkGray
        End If
    End Sub



    Public Overrides Property Text As String
        Get
            Return btn.Text
        End Get
        Set(value As String)
            btn.Text = value
        End Set
    End Property
    Public Property ButtonText As String
        Get
            Return btn.Text
        End Get
        Set(value As String)
            btn.Text = value
        End Set
    End Property
End Class
