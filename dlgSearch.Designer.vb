<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class dlgSearch
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(dlgSearch))
        udgvData = New ucInventDataGridView()
        udgvParam = New ucInventDataGridView()
        ucbtnRefresh = New ucInventButton()
        ucbtnExit = New ucInventButton()
        SuspendLayout()
        ' 
        ' udgvData
        ' 
        udgvData.ButtonColumnName = ""
        udgvData.ColumnAliases = CType(resources.GetObject("udgvData.ColumnAliases"), Dictionary(Of String, String))
        udgvData.ColumnWidths = CType(resources.GetObject("udgvData.ColumnWidths"), Dictionary(Of String, Integer))
        udgvData.DataSource = Nothing
        udgvData.DisabledOnModes = CType(resources.GetObject("udgvData.DisabledOnModes"), List(Of GlobalClass.Mode))
        udgvData.EnabledOnModes = CType(resources.GetObject("udgvData.EnabledOnModes"), List(Of GlobalClass.Mode))
        udgvData.Location = New Point(12, 197)
        udgvData.ModeSaatIni = GlobalClass.Mode.RefreshType
        udgvData.Name = "udgvData"
        udgvData.ReadOnly = False
        udgvData.Size = New Size(776, 356)
        udgvData.TabIndex = 0
        udgvData.VisibleColumns = CType(resources.GetObject("udgvData.VisibleColumns"), List(Of String))
        ' 
        ' udgvParam
        ' 
        udgvParam.ButtonColumnName = ""
        udgvParam.ColumnAliases = CType(resources.GetObject("udgvParam.ColumnAliases"), Dictionary(Of String, String))
        udgvParam.ColumnWidths = CType(resources.GetObject("udgvParam.ColumnWidths"), Dictionary(Of String, Integer))
        udgvParam.DataSource = Nothing
        udgvParam.DisabledOnModes = CType(resources.GetObject("udgvParam.DisabledOnModes"), List(Of GlobalClass.Mode))
        udgvParam.EnabledOnModes = CType(resources.GetObject("udgvParam.EnabledOnModes"), List(Of GlobalClass.Mode))
        udgvParam.Location = New Point(12, 12)
        udgvParam.ModeSaatIni = GlobalClass.Mode.RefreshType
        udgvParam.Name = "udgvParam"
        udgvParam.ReadOnly = False
        udgvParam.Size = New Size(569, 179)
        udgvParam.TabIndex = 1
        udgvParam.VisibleColumns = CType(resources.GetObject("udgvParam.VisibleColumns"), List(Of String))
        ' 
        ' ucbtnRefresh
        ' 
        ucbtnRefresh.BackgroundImageLayout = ImageLayout.Stretch
        ucbtnRefresh.BorderStyle = BorderStyle.Fixed3D
        ucbtnRefresh.ButtonText = "Refresh"
        ucbtnRefresh.DisabledOnModes = CType(resources.GetObject("ucbtnRefresh.DisabledOnModes"), List(Of GlobalClass.Mode))
        ucbtnRefresh.EnabledOnModes = CType(resources.GetObject("ucbtnRefresh.EnabledOnModes"), List(Of GlobalClass.Mode))
        ucbtnRefresh.Location = New Point(587, 12)
        ucbtnRefresh.ModeSaatIni = GlobalClass.Mode.RefreshType
        ucbtnRefresh.Name = "ucbtnRefresh"
        ucbtnRefresh.Picture = CType(resources.GetObject("ucbtnRefresh.Picture"), Image)
        ucbtnRefresh.Size = New Size(201, 81)
        ucbtnRefresh.TabIndex = 2
        ucbtnRefresh.UsePicture = True
        ' 
        ' ucbtnExit
        ' 
        ucbtnExit.ButtonText = "Exit"
        ucbtnExit.DisabledOnModes = CType(resources.GetObject("ucbtnExit.DisabledOnModes"), List(Of GlobalClass.Mode))
        ucbtnExit.EnabledOnModes = CType(resources.GetObject("ucbtnExit.EnabledOnModes"), List(Of GlobalClass.Mode))
        ucbtnExit.Location = New Point(587, 99)
        ucbtnExit.ModeSaatIni = GlobalClass.Mode.RefreshType
        ucbtnExit.Name = "ucbtnExit"
        ucbtnExit.Picture = CType(resources.GetObject("ucbtnExit.Picture"), Image)
        ucbtnExit.Size = New Size(201, 31)
        ucbtnExit.TabIndex = 3
        ucbtnExit.UsePicture = True
        ' 
        ' dlgSearch
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(800, 565)
        ControlBox = False
        Controls.Add(ucbtnExit)
        Controls.Add(ucbtnRefresh)
        Controls.Add(udgvParam)
        Controls.Add(udgvData)
        FormBorderStyle = FormBorderStyle.FixedDialog
        Name = "dlgSearch"
        ShowInTaskbar = False
        StartPosition = FormStartPosition.CenterScreen
        Text = "Searching..."
        ResumeLayout(False)
    End Sub

    Friend WithEvents udgvData As ucInventDataGridView
    Friend WithEvents udgvParam As ucInventDataGridView
    Friend WithEvents ucbtnRefresh As ucInventButton
    Friend WithEvents ucbtnExit As ucInventButton
End Class
