<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmPenjualan
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
        Label1 = New Label()
        Label2 = New Label()
        Label3 = New Label()
        UctrlInventDataGrid1 = New uctrlInventDataGrid()
        SuspendLayout()
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Location = New Point(14, 10)
        Label1.Name = "Label1"
        Label1.Size = New Size(81, 16)
        Label1.TabIndex = 0
        Label1.Text = "No. Faktur:"
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Location = New Point(15, 41)
        Label2.Name = "Label2"
        Label2.Size = New Size(80, 16)
        Label2.TabIndex = 1
        Label2.Text = "Pelanggan:"
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.Location = New Point(15, 82)
        Label3.Name = "Label3"
        Label3.Size = New Size(93, 16)
        Label3.TabIndex = 2
        Label3.Text = "Pembayaran:"
        ' 
        ' UctrlInventDataGrid1
        ' 
        UctrlInventDataGrid1.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
        UctrlInventDataGrid1.KolomDenganTombolCari = Nothing
        UctrlInventDataGrid1.Location = New Point(3, 111)
        UctrlInventDataGrid1.ModeTransaksi = "Restore"
        UctrlInventDataGrid1.Name = "UctrlInventDataGrid1"
        UctrlInventDataGrid1.Size = New Size(907, 357)
        UctrlInventDataGrid1.SumberData = Nothing
        UctrlInventDataGrid1.TabIndex = 3
        ' 
        ' frmPenjualan
        ' 
        AutoScaleDimensions = New SizeF(8F, 16F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(914, 480)
        Controls.Add(UctrlInventDataGrid1)
        Controls.Add(Label3)
        Controls.Add(Label2)
        Controls.Add(Label1)
        Font = New Font("Verdana", 9.75F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Name = "frmPenjualan"
        Text = "PENJUALAN"
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents UctrlInventDataGrid1 As uctrlInventDataGrid
End Class
