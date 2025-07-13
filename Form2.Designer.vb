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
        btnOK = New Button()
        Label1 = New Label()
        Label2 = New Label()
        SuspendLayout()
        ' 
        ' txtUser
        ' 
        txtUser.Location = New Point(317, 98)
        txtUser.Name = "txtUser"
        txtUser.Size = New Size(210, 23)
        txtUser.TabIndex = 0
        ' 
        ' txtPassword
        ' 
        txtPassword.Location = New Point(317, 129)
        txtPassword.Name = "txtPassword"
        txtPassword.PasswordChar = "*"c
        txtPassword.Size = New Size(210, 23)
        txtPassword.TabIndex = 1
        ' 
        ' btnOK
        ' 
        btnOK.Location = New Point(315, 163)
        btnOK.Name = "btnOK"
        btnOK.Size = New Size(211, 61)
        btnOK.TabIndex = 2
        btnOK.Text = "OK"
        btnOK.UseMnemonic = False
        btnOK.UseVisualStyleBackColor = True
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Location = New Point(234, 101)
        Label1.Name = "Label1"
        Label1.Size = New Size(77, 16)
        Label1.TabIndex = 3
        Label1.Text = "Username:"
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Location = New Point(234, 132)
        Label2.Name = "Label2"
        Label2.Size = New Size(75, 16)
        Label2.TabIndex = 4
        Label2.Text = "Password:"
        ' 
        ' frmLogin
        ' 
        AutoScaleDimensions = New SizeF(8F, 16F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(574, 305)
        Controls.Add(Label2)
        Controls.Add(Label1)
        Controls.Add(btnOK)
        Controls.Add(txtPassword)
        Controls.Add(txtUser)
        Font = New Font("Verdana", 9.75F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        FormBorderStyle = FormBorderStyle.FixedDialog
        MaximizeBox = False
        MdiChildrenMinimizedAnchorBottom = False
        MinimizeBox = False
        Name = "frmLogin"
        StartPosition = FormStartPosition.CenterScreen
        Text = "Login"
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents txtUser As TextBox
    Friend WithEvents txtPassword As TextBox
    Friend WithEvents btnOK As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
End Class
