Imports Invent2025.GlobalClass

Public Class MDIForm
    Private Sub MDIForm_Load(sender As Object, e As EventArgs) Handles Me.Load

        Me.Visible = False
        InventModule.InitializeModule()

    End Sub

    Private Sub MDIForm_Closed(sender As Object, e As EventArgs) Handles Me.Closed
        End
    End Sub
End Class
