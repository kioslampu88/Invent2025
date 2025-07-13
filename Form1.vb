Imports Invent2025.GlobalClass

Public Class MDIForm
    Private Sub MDIForm_Load(sender As Object, e As EventArgs) Handles Me.Load

        Me.Visible = False
        InventModule.InitializeModule()

    End Sub
End Class
