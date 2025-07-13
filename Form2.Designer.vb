<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmLogin
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        txtUser = New TextBox()
        txtPassword = New TextBox()
        SuspendLayout()
        ' 
        ' txtUser
        ' 
        txtUser.Location = New Point(130, 49)
        txtUser.Name = "txtUser"
        txtUser.Size = New Size(184, 23)
        txtUser.TabIndex = 0
        ' 
        ' txtPassword
        ' 
        txtPassword.Location = New Point(130, 78)
        txtPassword.Name = "txtPassword"
        txtPassword.Size = New Size(184, 23)
        txtPassword.TabIndex = 1
        ' 
        ' frmLogin
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(502, 286)
        Controls.Add(txtPassword)
        Controls.Add(txtUser)
        FormBorderStyle = FormBorderStyle.None
        Name = "frmLogin"
        Text = "Login"
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents txtUser As TextBox
    Friend WithEvents txtPassword As TextBox
End Class
