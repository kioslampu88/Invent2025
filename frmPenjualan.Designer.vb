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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmPenjualan))
        Label1 = New Label()
        Label2 = New Label()
        Label3 = New Label()
        UctrlInventDataGrid1 = New uctrlInventDataGrid()
        chkTanpaNama = New CheckBox()
        NumericUpDown1 = New NumericUpDown()
        Label4 = New Label()
        ucmbPembayaran = New ucInventComboBox()
        Label5 = New Label()
        Label6 = New Label()
        Label7 = New Label()
        cmbnaSalesman = New ucInventComboBox()
        cmbAccount = New ucInventComboBox()
        Label8 = New Label()
        txtntCode = New ucInventTextBox()
        cmbnaEntity = New ucInventComboBox()
        cmdSearchDoc = New ucInventButton()
        cmdSearchEntity = New ucInventButton()
        mskDateTgl = New ucInventDate()
        mskDueDate = New ucInventDate()
        UcInventButton1 = New ucInventButton()
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
        UctrlInventDataGrid1.Size = New Size(1139, 315)
        UctrlInventDataGrid1.SumberData = Nothing
        UctrlInventDataGrid1.TabIndex = 3
        ' 
        ' chkTanpaNama
        ' 
        chkTanpaNama.AutoSize = True
        chkTanpaNama.Checked = True
        chkTanpaNama.CheckState = CheckState.Checked
        chkTanpaNama.Location = New Point(134, 71)
        chkTanpaNama.Name = "chkTanpaNama"
        chkTanpaNama.Size = New Size(141, 20)
        chkTanpaNama.TabIndex = 7
        chkTanpaNama.Text = "Cetak Nama Toko"
        chkTanpaNama.UseVisualStyleBackColor = True
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
        ' ucmbPembayaran
        ' 
        ucmbPembayaran.DataSource = Nothing
        ucmbPembayaran.DisabledOnModes = CType(resources.GetObject("ucmbPembayaran.DisabledOnModes"), List(Of GlobalClass.Mode))
        ucmbPembayaran.DisplayMember = ""
        ucmbPembayaran.DropDownStyle = ComboBoxStyle.DropDown
        ucmbPembayaran.EnabledOnModes = CType(resources.GetObject("ucmbPembayaran.EnabledOnModes"), List(Of GlobalClass.Mode))
        ucmbPembayaran.Location = New Point(114, 111)
        ucmbPembayaran.ModeSaatIni = GlobalClass.Mode.RefreshType
        ucmbPembayaran.Name = "ucmbPembayaran"
        ucmbPembayaran.SelectedIndex = -1
        ucmbPembayaran.Size = New Size(276, 25)
        ucmbPembayaran.TabIndex = 13
        ucmbPembayaran.ValueMember = ""
        ' 
        ' Label5
        ' 
        Label5.AutoSize = True
        Label5.Location = New Point(701, 10)
        Label5.Name = "Label5"
        Label5.Size = New Size(97, 16)
        Label5.TabIndex = 14
        Label5.Text = "Tgl. Transaksi"
        ' 
        ' Label6
        ' 
        Label6.AutoSize = True
        Label6.Location = New Point(727, 72)
        Label6.Name = "Label6"
        Label6.Size = New Size(43, 16)
        Label6.TabIndex = 15
        Label6.Text = "Seller"
        ' 
        ' Label7
        ' 
        Label7.AutoSize = True
        Label7.Location = New Point(727, 113)
        Label7.Name = "Label7"
        Label7.Size = New Size(67, 16)
        Label7.TabIndex = 16
        Label7.Text = "Kode Kas"
        ' 
        ' cmbnaSalesman
        ' 
        cmbnaSalesman.DataSource = Nothing
        cmbnaSalesman.DisabledOnModes = CType(resources.GetObject("cmbnaSalesman.DisabledOnModes"), List(Of GlobalClass.Mode))
        cmbnaSalesman.DisplayMember = ""
        cmbnaSalesman.DropDownStyle = ComboBoxStyle.DropDown
        cmbnaSalesman.EnabledOnModes = CType(resources.GetObject("cmbnaSalesman.EnabledOnModes"), List(Of GlobalClass.Mode))
        cmbnaSalesman.Location = New Point(858, 68)
        cmbnaSalesman.ModeSaatIni = GlobalClass.Mode.RefreshType
        cmbnaSalesman.Name = "cmbnaSalesman"
        cmbnaSalesman.SelectedIndex = -1
        cmbnaSalesman.Size = New Size(241, 23)
        cmbnaSalesman.TabIndex = 17
        cmbnaSalesman.ValueMember = ""
        ' 
        ' cmbAccount
        ' 
        cmbAccount.DataSource = Nothing
        cmbAccount.DisabledOnModes = CType(resources.GetObject("cmbAccount.DisabledOnModes"), List(Of GlobalClass.Mode))
        cmbAccount.DisplayMember = ""
        cmbAccount.DropDownStyle = ComboBoxStyle.DropDown
        cmbAccount.EnabledOnModes = CType(resources.GetObject("cmbAccount.EnabledOnModes"), List(Of GlobalClass.Mode))
        cmbAccount.Location = New Point(858, 106)
        cmbAccount.ModeSaatIni = GlobalClass.Mode.RefreshType
        cmbAccount.Name = "cmbAccount"
        cmbAccount.SelectedIndex = -1
        cmbAccount.Size = New Size(241, 23)
        cmbAccount.TabIndex = 18
        cmbAccount.ValueMember = ""
        ' 
        ' Label8
        ' 
        Label8.AutoSize = True
        Label8.Location = New Point(701, 39)
        Label8.Name = "Label8"
        Label8.Size = New Size(120, 16)
        Label8.TabIndex = 19
        Label8.Text = "Tgl. Jatuh Tempo"
        ' 
        ' txtntCode
        ' 
        txtntCode.DisabledOnModes = CType(resources.GetObject("txtntCode.DisabledOnModes"), List(Of GlobalClass.Mode))
        txtntCode.EnabledOnModes = CType(resources.GetObject("txtntCode.EnabledOnModes"), List(Of GlobalClass.Mode))
        txtntCode.Location = New Point(114, 5)
        txtntCode.ModeSaatIni = GlobalClass.Mode.RefreshType
        txtntCode.Name = "txtntCode"
        txtntCode.Size = New Size(375, 23)
        txtntCode.TabIndex = 22
        ' 
        ' cmbnaEntity
        ' 
        cmbnaEntity.DataSource = Nothing
        cmbnaEntity.DisabledOnModes = CType(resources.GetObject("cmbnaEntity.DisabledOnModes"), List(Of GlobalClass.Mode))
        cmbnaEntity.DisplayMember = ""
        cmbnaEntity.DropDownStyle = ComboBoxStyle.DropDown
        cmbnaEntity.EnabledOnModes = CType(resources.GetObject("cmbnaEntity.EnabledOnModes"), List(Of GlobalClass.Mode))
        cmbnaEntity.Location = New Point(116, 34)
        cmbnaEntity.ModeSaatIni = GlobalClass.Mode.RefreshType
        cmbnaEntity.Name = "cmbnaEntity"
        cmbnaEntity.SelectedIndex = -1
        cmbnaEntity.Size = New Size(373, 23)
        cmbnaEntity.TabIndex = 23
        cmbnaEntity.ValueMember = ""
        ' 
        ' cmdSearchDoc
        ' 
        cmdSearchDoc.ButtonText = "Search"
        cmdSearchDoc.DisabledOnModes = CType(resources.GetObject("cmdSearchDoc.DisabledOnModes"), List(Of GlobalClass.Mode))
        cmdSearchDoc.EnabledOnModes = CType(resources.GetObject("cmdSearchDoc.EnabledOnModes"), List(Of GlobalClass.Mode))
        cmdSearchDoc.Location = New Point(495, 5)
        cmdSearchDoc.ModeSaatIni = GlobalClass.Mode.RefreshType
        cmdSearchDoc.Name = "cmdSearchDoc"
        cmdSearchDoc.Size = New Size(114, 23)
        cmdSearchDoc.TabIndex = 24
        ' 
        ' cmdSearchEntity
        ' 
        cmdSearchEntity.ButtonText = "Search"
        cmdSearchEntity.DisabledOnModes = CType(resources.GetObject("cmdSearchEntity.DisabledOnModes"), List(Of GlobalClass.Mode))
        cmdSearchEntity.EnabledOnModes = CType(resources.GetObject("cmdSearchEntity.EnabledOnModes"), List(Of GlobalClass.Mode))
        cmdSearchEntity.Location = New Point(495, 34)
        cmdSearchEntity.ModeSaatIni = GlobalClass.Mode.RefreshType
        cmdSearchEntity.Name = "cmdSearchEntity"
        cmdSearchEntity.Size = New Size(114, 23)
        cmdSearchEntity.TabIndex = 25
        ' 
        ' mskDateTgl
        ' 
        mskDateTgl.DisabledOnModes = CType(resources.GetObject("mskDateTgl.DisabledOnModes"), List(Of GlobalClass.Mode))
        mskDateTgl.EnabledOnModes = CType(resources.GetObject("mskDateTgl.EnabledOnModes"), List(Of GlobalClass.Mode))
        mskDateTgl.Location = New Point(949, 5)
        mskDateTgl.ModeSaatIni = GlobalClass.Mode.RefreshType
        mskDateTgl.Name = "mskDateTgl"
        mskDateTgl.Size = New Size(150, 23)
        mskDateTgl.TabIndex = 26
        mskDateTgl.Value = New Date(2025, 7, 19, 22, 36, 44, 573)
        ' 
        ' mskDueDate
        ' 
        mskDueDate.DisabledOnModes = CType(resources.GetObject("mskDueDate.DisabledOnModes"), List(Of GlobalClass.Mode))
        mskDueDate.EnabledOnModes = CType(resources.GetObject("mskDueDate.EnabledOnModes"), List(Of GlobalClass.Mode))
        mskDueDate.Location = New Point(949, 34)
        mskDueDate.ModeSaatIni = GlobalClass.Mode.RefreshType
        mskDueDate.Name = "mskDueDate"
        mskDueDate.Size = New Size(150, 23)
        mskDueDate.TabIndex = 27
        mskDueDate.Value = New Date(2025, 7, 19, 22, 36, 53, 545)
        ' 
        ' UcInventButton1
        ' 
        UcInventButton1.ButtonText = "Ambil Harga Terakhir"
        UcInventButton1.DisabledOnModes = CType(resources.GetObject("UcInventButton1.DisabledOnModes"), List(Of GlobalClass.Mode))
        UcInventButton1.EnabledOnModes = CType(resources.GetObject("UcInventButton1.EnabledOnModes"), List(Of GlobalClass.Mode))
        UcInventButton1.Location = New Point(281, 68)
        UcInventButton1.ModeSaatIni = GlobalClass.Mode.RefreshType
        UcInventButton1.Name = "UcInventButton1"
        UcInventButton1.Size = New Size(208, 37)
        UcInventButton1.TabIndex = 28
        ' 
        ' frmPenjualan
        ' 
        AutoScaleDimensions = New SizeF(8F, 16F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(1146, 480)
        Controls.Add(UcInventButton1)
        Controls.Add(mskDueDate)
        Controls.Add(mskDateTgl)
        Controls.Add(cmdSearchEntity)
        Controls.Add(cmdSearchDoc)
        Controls.Add(cmbnaEntity)
        Controls.Add(txtntCode)
        Controls.Add(Label8)
        Controls.Add(cmbAccount)
        Controls.Add(cmbnaSalesman)
        Controls.Add(Label7)
        Controls.Add(Label6)
        Controls.Add(Label5)
        Controls.Add(ucmbPembayaran)
        Controls.Add(Label4)
        Controls.Add(NumericUpDown1)
        Controls.Add(chkTanpaNama)
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
    Friend WithEvents chkTanpaNama As CheckBox
    Friend WithEvents NumericUpDown1 As NumericUpDown
    Friend WithEvents Label4 As Label
    Friend WithEvents ucmbPembayaran As ucInventComboBox
    Friend WithEvents Label5 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents cmbnaSalesman As ucInventComboBox
    Friend WithEvents cmbAccount As ucInventComboBox
    Friend WithEvents Label8 As Label
    Friend WithEvents txtntCode As ucInventTextBox
    Friend WithEvents cmbnaEntity As ucInventComboBox
    Friend WithEvents cmdSearchDoc As ucInventButton
    Friend WithEvents cmdSearchEntity As ucInventButton
    Friend WithEvents mskDateTgl As ucInventDate
    Friend WithEvents mskDueDate As ucInventDate
    Friend WithEvents UcInventButton1 As ucInventButton
End Class
