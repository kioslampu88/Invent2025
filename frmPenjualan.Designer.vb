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
        TextBox1 = New TextBox()
        TextBox2 = New TextBox()
        CheckBox1 = New CheckBox()
        Button1 = New Button()
        Button2 = New Button()
        Button3 = New Button()
        NumericUpDown1 = New NumericUpDown()
        Label4 = New Label()
        UcInventComboBox1 = New ucInventComboBox()
        CType(NumericUpDown1, ComponentModel.ISupportInitialize).BeginInit()
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
        Label3.Location = New Point(15, 113)
        Label3.Name = "Label3"
        Label3.Size = New Size(93, 16)
        Label3.TabIndex = 2
        Label3.Text = "Pembayaran:"
        ' 
        ' UctrlInventDataGrid1
        ' 
        UctrlInventDataGrid1.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
        UctrlInventDataGrid1.KolomDenganTombolCari = Nothing
        UctrlInventDataGrid1.Location = New Point(3, 153)
        UctrlInventDataGrid1.ModeTransaksi = "Restore"
        UctrlInventDataGrid1.Name = "UctrlInventDataGrid1"
        UctrlInventDataGrid1.Size = New Size(907, 315)
        UctrlInventDataGrid1.SumberData = Nothing
        UctrlInventDataGrid1.TabIndex = 3
        ' 
        ' TextBox1
        ' 
        TextBox1.Location = New Point(128, 7)
        TextBox1.Name = "TextBox1"
        TextBox1.Size = New Size(361, 23)
        TextBox1.TabIndex = 4
        ' 
        ' TextBox2
        ' 
        TextBox2.Location = New Point(128, 36)
        TextBox2.Name = "TextBox2"
        TextBox2.Size = New Size(361, 23)
        TextBox2.TabIndex = 5
        ' 
        ' CheckBox1
        ' 
        CheckBox1.AutoSize = True
        CheckBox1.Location = New Point(134, 63)
        CheckBox1.Name = "CheckBox1"
        CheckBox1.Size = New Size(97, 20)
        CheckBox1.TabIndex = 7
        CheckBox1.Text = "CheckBox1"
        CheckBox1.UseVisualStyleBackColor = True
        ' 
        ' Button1
        ' 
        Button1.Location = New Point(237, 65)
        Button1.Name = "Button1"
        Button1.Size = New Size(252, 31)
        Button1.TabIndex = 8
        Button1.Text = "Ambil Harga Terakhir"
        Button1.UseVisualStyleBackColor = True
        ' 
        ' Button2
        ' 
        Button2.Location = New Point(495, 7)
        Button2.Name = "Button2"
        Button2.Size = New Size(114, 23)
        Button2.TabIndex = 9
        Button2.Text = "Search"
        Button2.UseVisualStyleBackColor = True
        ' 
        ' Button3
        ' 
        Button3.Location = New Point(495, 34)
        Button3.Name = "Button3"
        Button3.Size = New Size(114, 23)
        Button3.TabIndex = 10
        Button3.Text = "Search"
        Button3.UseVisualStyleBackColor = True
        ' 
        ' NumericUpDown1
        ' 
        NumericUpDown1.Location = New Point(396, 111)
        NumericUpDown1.Name = "NumericUpDown1"
        NumericUpDown1.Size = New Size(55, 23)
        NumericUpDown1.TabIndex = 11
        ' 
        ' Label4
        ' 
        Label4.AutoSize = True
        Label4.Location = New Point(454, 114)
        Label4.Name = "Label4"
        Label4.Size = New Size(31, 16)
        Label4.TabIndex = 12
        Label4.Text = "hari"
        ' 
        ' UcInventComboBox1
        ' 
        UcInventComboBox1.DataSource = Nothing
        UcInventComboBox1.DisplayMember = ""
        UcInventComboBox1.Location = New Point(114, 111)
        UcInventComboBox1.Name = "UcInventComboBox1"
        UcInventComboBox1.Size = New Size(276, 25)
        UcInventComboBox1.TabIndex = 13
        UcInventComboBox1.ValueMember = ""
        ' 
        ' frmPenjualan
        ' 
        AutoScaleDimensions = New SizeF(8F, 16F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(914, 480)
        Controls.Add(UcInventComboBox1)
        Controls.Add(Label4)
        Controls.Add(NumericUpDown1)
        Controls.Add(Button3)
        Controls.Add(Button2)
        Controls.Add(Button1)
        Controls.Add(CheckBox1)
        Controls.Add(TextBox2)
        Controls.Add(TextBox1)
        Controls.Add(UctrlInventDataGrid1)
        Controls.Add(Label3)
        Controls.Add(Label2)
        Controls.Add(Label1)
        Font = New Font("Verdana", 9.75F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Name = "frmPenjualan"
        Text = "PENJUALAN"
        CType(NumericUpDown1, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents UctrlInventDataGrid1 As uctrlInventDataGrid
    Friend WithEvents TextBox1 As TextBox
    Friend WithEvents TextBox2 As TextBox
    Friend WithEvents CheckBox1 As CheckBox
    Friend WithEvents Button1 As Button
    Friend WithEvents Button2 As Button
    Friend WithEvents Button3 As Button
    Friend WithEvents NumericUpDown1 As NumericUpDown
    Friend WithEvents Label4 As Label
    Friend WithEvents UcInventComboBox1 As ucInventComboBox
End Class
