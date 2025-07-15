<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class MDIForm
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(disposing As Boolean)
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MDIForm))
        MnuStripInvent = New MenuStrip()
        DataToolStripMenuItem = New ToolStripMenuItem()
        TransaksiToolStripMenuItem = New ToolStripMenuItem()
        PembelianBarangToolStripMenuItem = New ToolStripMenuItem()
        PenjualanToolStripMenuItem = New ToolStripMenuItem()
        KeuanganToolStripMenuItem = New ToolStripMenuItem()
        PembayaranToolStripMenuItem = New ToolStripMenuItem()
        LaporanToolStripMenuItem = New ToolStripMenuItem()
        GantiPasswordToolStripMenuItem = New ToolStripMenuItem()
        DatabaseToolStripMenuItem = New ToolStripMenuItem()
        ToolStrip1 = New ToolStrip()
        ToolStripButton2 = New ToolStripButton()
        ToolStripButton1 = New ToolStripButton()
        ToolStripButton3 = New ToolStripButton()
        ToolStripButton4 = New ToolStripButton()
        ToolStripButton5 = New ToolStripButton()
        ToolStripButton6 = New ToolStripButton()
        TabControl1 = New TabControl()
        TabPage1 = New TabPage()
        TabPage2 = New TabPage()
        MnuStripInvent.SuspendLayout()
        ToolStrip1.SuspendLayout()
        TabControl1.SuspendLayout()
        SuspendLayout()
        ' 
        ' MnuStripInvent
        ' 
        MnuStripInvent.Font = New Font("Verdana", 9F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        MnuStripInvent.Items.AddRange(New ToolStripItem() {DataToolStripMenuItem, TransaksiToolStripMenuItem, KeuanganToolStripMenuItem, PembayaranToolStripMenuItem, LaporanToolStripMenuItem, GantiPasswordToolStripMenuItem, DatabaseToolStripMenuItem})
        MnuStripInvent.Location = New Point(0, 0)
        MnuStripInvent.Name = "MnuStripInvent"
        MnuStripInvent.Padding = New Padding(7, 2, 0, 2)
        MnuStripInvent.Size = New Size(942, 24)
        MnuStripInvent.TabIndex = 2
        MnuStripInvent.Text = "MenuStrip1"
        ' 
        ' DataToolStripMenuItem
        ' 
        DataToolStripMenuItem.Name = "DataToolStripMenuItem"
        DataToolStripMenuItem.Size = New Size(49, 20)
        DataToolStripMenuItem.Text = "DATA"
        ' 
        ' TransaksiToolStripMenuItem
        ' 
        TransaksiToolStripMenuItem.DropDownItems.AddRange(New ToolStripItem() {PembelianBarangToolStripMenuItem, PenjualanToolStripMenuItem})
        TransaksiToolStripMenuItem.Name = "TransaksiToolStripMenuItem"
        TransaksiToolStripMenuItem.Size = New Size(88, 20)
        TransaksiToolStripMenuItem.Text = "TRANSAKSI"
        ' 
        ' PembelianBarangToolStripMenuItem
        ' 
        PembelianBarangToolStripMenuItem.Name = "PembelianBarangToolStripMenuItem"
        PembelianBarangToolStripMenuItem.Size = New Size(145, 22)
        PembelianBarangToolStripMenuItem.Text = "PEMBELIAN"
        ' 
        ' PenjualanToolStripMenuItem
        ' 
        PenjualanToolStripMenuItem.Name = "PenjualanToolStripMenuItem"
        PenjualanToolStripMenuItem.Size = New Size(145, 22)
        PenjualanToolStripMenuItem.Text = "PENJUALAN"
        ' 
        ' KeuanganToolStripMenuItem
        ' 
        KeuanganToolStripMenuItem.Name = "KeuanganToolStripMenuItem"
        KeuanganToolStripMenuItem.Size = New Size(87, 20)
        KeuanganToolStripMenuItem.Text = "KEUANGAN"
        ' 
        ' PembayaranToolStripMenuItem
        ' 
        PembayaranToolStripMenuItem.Name = "PembayaranToolStripMenuItem"
        PembayaranToolStripMenuItem.Size = New Size(101, 20)
        PembayaranToolStripMenuItem.Text = "PEMBAYARAN"
        ' 
        ' LaporanToolStripMenuItem
        ' 
        LaporanToolStripMenuItem.Name = "LaporanToolStripMenuItem"
        LaporanToolStripMenuItem.Size = New Size(77, 20)
        LaporanToolStripMenuItem.Text = "LAPORAN"
        ' 
        ' GantiPasswordToolStripMenuItem
        ' 
        GantiPasswordToolStripMenuItem.Name = "GantiPasswordToolStripMenuItem"
        GantiPasswordToolStripMenuItem.Size = New Size(133, 20)
        GantiPasswordToolStripMenuItem.Text = "GANTI PASSWORD"
        ' 
        ' DatabaseToolStripMenuItem
        ' 
        DatabaseToolStripMenuItem.Name = "DatabaseToolStripMenuItem"
        DatabaseToolStripMenuItem.Size = New Size(81, 20)
        DatabaseToolStripMenuItem.Text = "DATABASE"
        ' 
        ' ToolStrip1
        ' 
        ToolStrip1.ImageScalingSize = New Size(50, 50)
        ToolStrip1.Items.AddRange(New ToolStripItem() {ToolStripButton2, ToolStripButton1, ToolStripButton3, ToolStripButton4, ToolStripButton5, ToolStripButton6})
        ToolStrip1.Location = New Point(0, 24)
        ToolStrip1.Name = "ToolStrip1"
        ToolStrip1.Size = New Size(942, 57)
        ToolStrip1.TabIndex = 4
        ToolStrip1.Text = "ToolStrip1"
        ' 
        ' ToolStripButton2
        ' 
        ToolStripButton2.DisplayStyle = ToolStripItemDisplayStyle.Image
        ToolStripButton2.Image = CType(resources.GetObject("ToolStripButton2.Image"), Image)
        ToolStripButton2.ImageTransparentColor = Color.Magenta
        ToolStripButton2.Name = "ToolStripButton2"
        ToolStripButton2.Size = New Size(54, 54)
        ToolStripButton2.Text = "New"
        ' 
        ' ToolStripButton1
        ' 
        ToolStripButton1.DisplayStyle = ToolStripItemDisplayStyle.Image
        ToolStripButton1.Image = CType(resources.GetObject("ToolStripButton1.Image"), Image)
        ToolStripButton1.ImageTransparentColor = Color.Magenta
        ToolStripButton1.Name = "ToolStripButton1"
        ToolStripButton1.Size = New Size(54, 54)
        ToolStripButton1.Text = "Save"
        ' 
        ' ToolStripButton3
        ' 
        ToolStripButton3.DisplayStyle = ToolStripItemDisplayStyle.Image
        ToolStripButton3.Image = CType(resources.GetObject("ToolStripButton3.Image"), Image)
        ToolStripButton3.ImageTransparentColor = Color.Magenta
        ToolStripButton3.Name = "ToolStripButton3"
        ToolStripButton3.Size = New Size(54, 54)
        ToolStripButton3.Text = "Delete"
        ' 
        ' ToolStripButton4
        ' 
        ToolStripButton4.DisplayStyle = ToolStripItemDisplayStyle.Image
        ToolStripButton4.Image = CType(resources.GetObject("ToolStripButton4.Image"), Image)
        ToolStripButton4.ImageTransparentColor = Color.Magenta
        ToolStripButton4.Name = "ToolStripButton4"
        ToolStripButton4.Size = New Size(54, 54)
        ToolStripButton4.Text = "Print"
        ' 
        ' ToolStripButton5
        ' 
        ToolStripButton5.DisplayStyle = ToolStripItemDisplayStyle.Image
        ToolStripButton5.Image = CType(resources.GetObject("ToolStripButton5.Image"), Image)
        ToolStripButton5.ImageTransparentColor = Color.Magenta
        ToolStripButton5.Name = "ToolStripButton5"
        ToolStripButton5.Size = New Size(54, 54)
        ToolStripButton5.Text = "Cancel"
        ' 
        ' ToolStripButton6
        ' 
        ToolStripButton6.DisplayStyle = ToolStripItemDisplayStyle.Image
        ToolStripButton6.Image = CType(resources.GetObject("ToolStripButton6.Image"), Image)
        ToolStripButton6.ImageTransparentColor = Color.Magenta
        ToolStripButton6.Name = "ToolStripButton6"
        ToolStripButton6.Size = New Size(54, 54)
        ToolStripButton6.Text = "Refresh"
        ' 
        ' TabControl1
        ' 
        TabControl1.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
        TabControl1.Controls.Add(TabPage1)
        TabControl1.Controls.Add(TabPage2)
        TabControl1.Location = New Point(0, 90)
        TabControl1.Name = "TabControl1"
        TabControl1.SelectedIndex = 0
        TabControl1.Size = New Size(942, 486)
        TabControl1.TabIndex = 6
        ' 
        ' TabPage1
        ' 
        TabPage1.Location = New Point(4, 25)
        TabPage1.Name = "TabPage1"
        TabPage1.Padding = New Padding(3)
        TabPage1.Size = New Size(934, 457)
        TabPage1.TabIndex = 0
        TabPage1.Text = "TabPage1"
        TabPage1.UseVisualStyleBackColor = True
        ' 
        ' TabPage2
        ' 
        TabPage2.Location = New Point(4, 24)
        TabPage2.Name = "TabPage2"
        TabPage2.Padding = New Padding(3)
        TabPage2.Size = New Size(934, 458)
        TabPage2.TabIndex = 1
        TabPage2.Text = "TabPage2"
        TabPage2.UseVisualStyleBackColor = True
        ' 
        ' MDIForm
        ' 
        AutoScaleDimensions = New SizeF(8F, 16F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(942, 578)
        Controls.Add(TabControl1)
        Controls.Add(ToolStrip1)
        Controls.Add(MnuStripInvent)
        Font = New Font("Verdana", 9.75F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        IsMdiContainer = True
        MainMenuStrip = MnuStripInvent
        Name = "MDIForm"
        Text = "Invent 2025"
        WindowState = FormWindowState.Maximized
        MnuStripInvent.ResumeLayout(False)
        MnuStripInvent.PerformLayout()
        ToolStrip1.ResumeLayout(False)
        ToolStrip1.PerformLayout()
        TabControl1.ResumeLayout(False)
        ResumeLayout(False)
        PerformLayout()
    End Sub
    Friend WithEvents MnuStripInvent As MenuStrip
    Friend WithEvents DataToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents TransaksiToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents KeuanganToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents PembayaranToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents LaporanToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents GantiPasswordToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents DatabaseToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents PenjualanToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ToolStrip1 As ToolStrip
    Friend WithEvents ToolStripButton1 As ToolStripButton
    Friend WithEvents ToolStripButton2 As ToolStripButton
    Friend WithEvents ToolStripButton3 As ToolStripButton
    Friend WithEvents ToolStripButton4 As ToolStripButton
    Friend WithEvents ToolStripButton5 As ToolStripButton
    Friend WithEvents ToolStripButton6 As ToolStripButton
    Friend WithEvents TabControl1 As TabControl
    Friend WithEvents TabPage1 As TabPage
    Friend WithEvents TabPage2 As TabPage
    Friend WithEvents PembelianBarangToolStripMenuItem As ToolStripMenuItem

End Class
