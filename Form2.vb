Imports System.ComponentModel

Public Class frmLogin


    Private Sub btnOK_Click(sender As Object, e As EventArgs) Handles btnOK.Click

        CurrentUser.Username = txtUser.Text
        CurrentUser.Password = txtPassword.Text

        DialogResult = DialogResult.OK
        Me.Close()

    End Sub

    Private Sub frmLogin_Closed(sender As Object, e As EventArgs) Handles Me.Closed



    End Sub

    Private Sub frmLogin_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing

    End Sub
End Class