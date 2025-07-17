Imports System.Data.SqlClient
Imports Microsoft.Data.SqlClient
Public Class GlobalClass
    Dim conn As New SqlConnection("...")

    Public Enum Mode
        RefreshType
        CancelType
        DeleteType
        SaveType
        EditType
        NewType
        PrintType
    End Enum

    Public Class UserInfo
        Public Property Username As String
        Public Property Password As String
        Public Property AccessGranted As Boolean
        Public Property Connection As SqlConnection
        Public Property AppPosition As Integer
    End Class

    Public Class FormButtonHelper
        Public Shared Sub SetButtons(
        ByVal mode As Mode,
        ByVal btnNew As ToolStripButton,
        ByVal btnSave As ToolStripButton,
        ByVal btnEdit As ToolStripButton,
        ByVal btnCancel As ToolStripButton,
        ByVal btnDelete As ToolStripButton,
        ByVal btnPrint As ToolStripButton,
        ByVal btnRefresh As ToolStripButton
    )
            Select Case mode
                Case Mode.RefreshType, Mode.CancelType, Mode.DeleteType, Mode.PrintType, Mode.SaveType
                    btnNew.Enabled = True
                    btnSave.Enabled = False
                    btnEdit.Enabled = True
                    btnCancel.Enabled = False
                    btnDelete.Enabled = True
                    btnPrint.Enabled = True
                    btnRefresh.Enabled = True

                Case Mode.NewType, Mode.EditType
                    btnNew.Enabled = False
                    btnSave.Enabled = True
                    btnEdit.Enabled = False
                    btnCancel.Enabled = True
                    btnDelete.Enabled = False
                    btnPrint.Enabled = True
                    btnRefresh.Enabled = False
            End Select
        End Sub
    End Class

    Public Interface IFormWithMode
        Property ModeStatus As Mode
        Sub OnToolbarClick(ByVal modeCommand As Mode)
    End Interface

    Public Class FormStatusManager
        Private _currentMode As Mode = Mode.RefreshType

        Public Property CurrentMode() As Mode
            Get
                Return _currentMode
            End Get
            Set(ByVal value As Mode)
                _currentMode = value
            End Set
        End Property

        Public Function IsNew() As Boolean
            Return _currentMode = Mode.NewType
        End Function

        Public Function IsEdit() As Boolean
            Return _currentMode = Mode.EditType
        End Function

        Public Function IsRefresh() As Boolean
            Return _currentMode = Mode.RefreshType
        End Function

        Public Function IsSave() As Boolean
            Return _currentMode = Mode.SaveType
        End Function
        Public Function IsDelete() As Boolean
            Return _currentMode = Mode.DeleteType
        End Function
        Public Function IsPrint() As Boolean
            Return _currentMode = Mode.PrintType
        End Function
        Public Function IsCancel() As Boolean
            Return _currentMode = Mode.CancelType
        End Function
    End Class
End Class
