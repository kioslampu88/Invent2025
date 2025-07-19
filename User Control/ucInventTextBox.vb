Imports Invent2025.GlobalClass
Imports System.ComponentModel
Imports System.Data
Imports System.Windows.Forms
Public Class ucInventTextBox
    Inherits UserControl

    Implements IFormWithModeSupport

    Private WithEvents tbo As New TextBox()

    ' --- Properti kontrol aktif pada mode tertentu ---
    Private _enabledOnModes As New List(Of Mode)
    Private _disabledOnModes As New List(Of Mode)
    Private _modeSaatIni As Mode
    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        tbo.Dock = DockStyle.Fill
        Me.Controls.Add(tbo)

        ' Atur ukuran UserControl mengikuti ComboBox
        Me.Height = tbo.PreferredHeight
        Me.Width = 150 ' Default width, bisa diubah di Designer


    End Sub

    Public Sub ClearSelection()

        tbo.ResetText()
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
            tbo.Enabled = False
        ElseIf _enabledOnModes.Count > 0 Then
            tbo.Enabled = _enabledOnModes.Contains(_modeSaatIni)
        Else
            tbo.Enabled = True
        End If

        Dim isEnabled As Boolean = tbo.Enabled

        ' Warna ketika disable atau enable
        If isEnabled Then
            tbo.BackColor = SystemColors.Window
            tbo.ForeColor = SystemColors.ControlText
        Else
            tbo.BackColor = Color.LightGray  ' warna lebih tua
            tbo.ForeColor = Color.DarkGray
        End If
    End Sub
    Public Overrides Property Text As String
        Get
            Return tbo.Text
        End Get
        Set(value As String)
            tbo.Text = value
        End Set
    End Property
End Class
