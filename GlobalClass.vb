Imports System.Data.SqlClient
Imports Microsoft.Data.SqlClient
Public Class GlobalClass
    Dim conn As New SqlConnection("...")

    Public Class UserInfo
        Public Property Username As String
        Public Property Password As String
        Public Property AccessGranted As Boolean
        Public Property Connection As SqlConnection

        Public Property AppPosition As Integer
    End Class

    Public Class FormStatusManager
        ' Enum untuk status form
        Public Enum FormStatus
            [None]     ' Default / belum ditentukan
            Refresh
            [New]
            Edit
        End Enum

        ' Property untuk menyimpan status sekarang
        Private _currentStatus As FormStatus = FormStatus.None

        ' Property publik untuk akses status
        Public Property CurrentStatus() As FormStatus
            Get
                Return _currentStatus
            End Get
            Set(ByVal value As FormStatus)
                _currentStatus = value
            End Set
        End Property

        ' Fungsi bantu
        Public Function IsNew() As Boolean
            Return _currentStatus = FormStatus.New
        End Function

        Public Function IsEdit() As Boolean
            Return _currentStatus = FormStatus.Edit
        End Function

        Public Function IsRefresh() As Boolean
            Return _currentStatus = FormStatus.Refresh
        End Function

        Public Function IsNone() As Boolean
            Return _currentStatus = FormStatus.None
        End Function
    End Class

End Class
