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
        btnNew = New ToolStripButton()
        btnEdit = New ToolStripButton()
        btnSave = New ToolStripButton()
        btnDelete = New ToolStripButton()
        btnPrint = New ToolStripButton()
        btnCancel = New ToolStripButton()
        btnRefresh = New ToolStripButton()
        TabControl1 = New TabControl()
        MnuStripInvent.SuspendLayout()
        ToolStrip1.SuspendLayout()
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
        ToolStrip1.Items.AddRange(New ToolStripItem() {btnNew, btnEdit, btnSave, btnDelete, btnPrint, btnCancel, btnRefresh})
        ToolStrip1.Location = New Point(0, 24)
        ToolStrip1.Name = "ToolStrip1"
        ToolStrip1.Size = New Size(942, 57)
        ToolStrip1.TabIndex = 4
        ToolStrip1.Text = "ToolStrip1"
        ' 
        ' btnNew
        ' 
        btnNew.DisplayStyle = ToolStripItemDisplayStyle.Image
        btnNew.Image = CType(resources.GetObject("btnNew.Image"), Image)
        btnNew.ImageTransparentColor = Color.Magenta
        btnNew.Name = "btnNew"
        btnNew.Size = New Size(54, 54)
        btnNew.Text = "New"
        ' 
        ' btnEdit
        ' 
        btnEdit.DisplayStyle = ToolStripItemDisplayStyle.Image
        btnEdit.Image = CType(resources.GetObject("btnEdit.Image"), Image)
        btnEdit.ImageTransparentColor = Color.Magenta
        btnEdit.Name = "btnEdit"
        btnEdit.Size = New Size(54, 54)
        btnEdit.Text = "Edit"
        ' 
        ' btnSave
        ' 
        btnSave.DisplayStyle = ToolStripItemDisplayStyle.Image
        btnSave.Image = CType(resources.GetObject("btnSave.Image"), Image)
        btnSave.ImageTransparentColor = Color.Magenta
        btnSave.Name = "btnSave"
        btnSave.Size = New Size(54, 54)
        btnSave.Text = "Save"
        ' 
        ' btnDelete
        ' 
        btnDelete.DisplayStyle = ToolStripItemDisplayStyle.Image
        btnDelete.Image = CType(resources.GetObject("btnDelete.Image"), Image)
        btnDelete.ImageTransparentColor = Color.Magenta
        btnDelete.Name = "btnDelete"
        btnDelete.Size = New Size(54, 54)
        btnDelete.Text = "Delete"
        ' 
        ' btnPrint
        ' 
        btnPrint.DisplayStyle = ToolStripItemDisplayStyle.Image
        btnPrint.Image = CType(resources.GetObject("btnPrint.Image"), Image)
        btnPrint.ImageTransparentColor = Color.Magenta
        btnPrint.Name = "btnPrint"
        btnPrint.Size = New Size(54, 54)
        btnPrint.Text = "Print"
        ' 
        ' btnCancel
        ' 
        btnCancel.DisplayStyle = ToolStripItemDisplayStyle.Image
        btnCancel.Image = CType(resources.GetObject("btnCancel.Image"), Image)
        btnCancel.ImageTransparentColor = Color.Magenta
        btnCancel.Name = "btnCancel"
        btnCancel.Size = New Size(54, 54)
        btnCancel.Text = "Cancel"
        ' 
        ' btnRefresh
        ' 
        btnRefresh.DisplayStyle = ToolStripItemDisplayStyle.Image
        btnRefresh.Image = CType(resources.GetObject("btnRefresh.Image"), Image)
        btnRefresh.ImageTransparentColor = Color.Magenta
        btnRefresh.Name = "btnRefresh"
        btnRefresh.Size = New Size(54, 54)
        btnRefresh.Text = "Refresh"
        ' 
        ' TabControl1
        ' 
        TabControl1.Dock = DockStyle.Top
        TabControl1.DrawMode = TabDrawMode.OwnerDrawFixed
        TabControl1.Location = New Point(0, 81)
        TabControl1.Name = "TabControl1"
        TabControl1.SelectedIndex = 0
        TabControl1.Size = New Size(942, 40)
        TabControl1.SizeMode = TabSizeMode.Fixed
        TabControl1.TabIndex = 6
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
    Friend WithEvents btnSave As ToolStripButton
    Friend WithEvents btnNew As ToolStripButton
    Friend WithEvents btnDelete As ToolStripButton
    Friend WithEvents btnPrint As ToolStripButton
    Friend WithEvents btnCancel As ToolStripButton
    Friend WithEvents btnRefresh As ToolStripButton
    Friend WithEvents TabControl1 As TabControl
    Friend WithEvents PembelianBarangToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents btnEdit As ToolStripButton

End Class
