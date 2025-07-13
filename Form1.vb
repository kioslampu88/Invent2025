Imports Invent2025.GlobalClass

Public Class MDIForm
    Private Sub MDIForm_Load(sender As Object, e As EventArgs) Handles Me.Load
        Me.Visible = False

        Dim userInfo As UserInfo = UserLogin("MDIForm") ' Fungsi login yang modern

        If userInfo IsNot Nothing AndAlso userInfo.AccessGranted Then
            CurrentUser = userInfo
            'MenuAkses()
            'ButtonSet(Mode.RefreshType)
            Me.Visible = True

        Else
            Me.Dispose() ' Tutup jika login gagal
        End If

    End Sub
End Class
