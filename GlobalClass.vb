Imports System.Data.SqlClient
Public Class GlobalClass

    Public Class UserInfo
        Public Property Username As String
        Public Property Password As String
        Public Property AccessGranted As Boolean
        Public Property Connection As SqlConnection
    End Class

End Class
