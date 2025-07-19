Imports System.ComponentModel
Imports System.Data
Imports System.Windows.Forms
Imports Invent2025.GlobalClass

<ToolboxItem(True)>
Public Class ucInventComboBox
    Inherits UserControl

    Implements IFormWithModeSupport


    Private WithEvents cbo As New ComboBox()

    ' --- Properti kontrol aktif pada mode tertentu ---
    Private _enabledOnModes As New List(Of Mode)
    Private _disabledOnModes As New List(Of Mode)
    Private _modeSaatIni As Mode

    Public Sub New()
        ' Atur ComboBox
        cbo.Dock = DockStyle.Fill
        Me.Controls.Add(cbo)

        ' Atur ukuran UserControl mengikuti ComboBox
        Me.Height = cbo.PreferredHeight
        Me.Width = 150 ' Default width, bisa diubah di Designer
    End Sub

    ' Property: DataSource
    Public Property DataSource() As DataTable
        Get
            Return TryCast(cbo.DataSource, DataTable)
        End Get
        Set(value As DataTable)
            cbo.DataSource = value
        End Set
    End Property

    ' Property: DisplayMember
    Public Property DisplayMember() As String
        Get
            Return cbo.DisplayMember
        End Get
        Set(value As String)
            cbo.DisplayMember = value
        End Set
    End Property

    ' Property: ValueMember
    Public Property ValueMember() As String
        Get
            Return cbo.ValueMember
        End Get
        Set(value As String)
            cbo.ValueMember = value
        End Set
    End Property

    ' Property: SelectedValue
    <Browsable(False)>
    Public ReadOnly Property SelectedValue() As Object
        Get
            Return cbo.SelectedValue
        End Get
    End Property

    ' Property: SelectedText
    <Browsable(False)>
    Public ReadOnly Property SelectedText() As String
        Get
            Return cbo.Text
        End Get
    End Property

    ' Property: SelectedIndex
    Public Property SelectedIndex() As Integer
        Get
            Return cbo.SelectedIndex
        End Get
        Set(value As Integer)
            cbo.SelectedIndex = value
        End Set
    End Property

    ' Property: DropDownStyle
    Public Property DropDownStyle() As ComboBoxStyle
        Get
            Return cbo.DropDownStyle
        End Get
        Set(value As ComboBoxStyle)
            cbo.DropDownStyle = value
        End Set
    End Property

    ' Property: Enabled
    Public Shadows Property Enabled() As Boolean
        Get
            Return cbo.Enabled
        End Get
        Set(value As Boolean)
            cbo.Enabled = value
            MyBase.Enabled = value
        End Set
    End Property

    ' Event Forwarding
    Public Event SelectedIndexChanged As EventHandler

    Private Sub cbo_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbo.SelectedIndexChanged
        RaiseEvent SelectedIndexChanged(Me, e)
    End Sub

    Public Sub ClearSelection()
        cbo.SelectedIndex = -1
        cbo.ResetText()
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
            cbo.Enabled = False
        ElseIf _enabledOnModes.Count > 0 Then
            cbo.Enabled = _enabledOnModes.Contains(_modeSaatIni)
        Else
            cbo.Enabled = True
        End If

        Dim isEnabled As Boolean = cbo.Enabled

        ' Warna ketika disable atau enable
        If isEnabled Then
            cbo.BackColor = SystemColors.Window
            cbo.ForeColor = SystemColors.ControlText
        Else
            cbo.BackColor = Color.LightGray  ' warna lebih tua
            cbo.ForeColor = Color.DarkGray
        End If
    End Sub
End Class
