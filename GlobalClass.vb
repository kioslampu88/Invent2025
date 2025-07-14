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

End Class
