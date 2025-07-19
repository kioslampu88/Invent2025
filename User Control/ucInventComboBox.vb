Imports System.ComponentModel
Imports System.Data
Imports System.Windows.Forms

<ToolboxItem(True)>
Public Class ucComboBox
    Inherits UserControl

    Private WithEvents cbo As New ComboBox()

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
End Class
