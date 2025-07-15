Imports System.Configuration
Imports System.Security.Cryptography
Imports System.Text
Imports System.Windows.Forms.VisualStyles.VisualStyleElement
Imports Invent2025.GlobalClass
Imports Microsoft
Imports Microsoft.Data.SqlClient



Module InventModule

    Dim strServer As String
    Dim strDBName As String
    Dim blnActivateLogin As Boolean
    Dim strStoreName As String
    Dim strCity As String
    Dim strAddress As String
    Dim strPhoneNumber As String
    Dim strPrintLogo As String
    Dim strPrinterName As String
    Public CurrentUser As UserInfo

    Public Sub InitializeModule()
        ' Inisialisasi module jika diperlukan
        GetProfileSetting()

        UserLogin("MDIForm") ' Fungsi login yang modern

        If CurrentUser.AccessGranted Then

            'MenuAkses()
            'ButtonSet(Mode.RefreshType)
            MDIForm.Visible = True

        Else
            Application.Exit() ' Tutup jika login gagal
        End If

    End Sub

    Public Sub GetProfileSetting()

        Try
            strServer = ConfigurationManager.AppSettings("ServerName")
            strDBName = ConfigurationManager.AppSettings("DBName")
            blnActivateLogin = Convert.ToBoolean(ConfigurationManager.AppSettings("ActivateLogin"))
            strStoreName = ConfigurationManager.AppSettings("StoreName")
            strCity = ConfigurationManager.AppSettings("City")
            strAddress = ConfigurationManager.AppSettings("Address")
            strPhoneNumber = ConfigurationManager.AppSettings("PhoneNumber")
            strPrintLogo = ConfigurationManager.AppSettings("PrintLogo")
            strPrinterName = ConfigurationManager.AppSettings("PrinterName")

        Catch ex As Exception
            MessageBox.Show("Gagal mengambil konfigurasi aplikasi: " & ex.Message,
                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Public Sub UserLogin(strMenu As String, Optional ShowForm As Boolean = True)

        Dim connectionString As String

        Dim strUserSQL As String = "sa"
        Dim strPassSQL As String = "testing"

        CurrentUser = New UserInfo()

        Do
            If blnActivateLogin And ShowForm Then
                frmLogin.ShowDialog()
                If frmLogin.DialogResult = 1 Then

                Else
                    CurrentUser.AccessGranted = False
                End If
            Else
                CurrentUser.Username = "admin"
                CurrentUser.Password = "testing"
            End If

            connectionString = $"Data Source={strServer};Initial Catalog={strDBName};User ID=" & strUserSQL & ";Password= " & strPassSQL & ";TrustServerCertificate=True"

            Try
                Dim conn As New SqlConnection(connectionString)
                conn.Open()
                CurrentUser.Connection = conn

                'Cek akses menu (buat function tambahan)
                If GetMenuAkses(strMenu) Then

                    CurrentUser.AccessGranted = True

                Else
                    MessageBox.Show("Akses ke menu ditolak.", "Akses", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    conn.Close()
                End If

            Catch ex As Exception
                MessageBox.Show("Koneksi gagal: " & ex.Message, "Login Gagal", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try

        Loop Until CurrentUser.AccessGranted


    End Sub

    Public Function ExecSP1(
    ByVal storedProcName As String,
    ByVal inputParams As Dictionary(Of String, Object),
    ByVal outputParams As Dictionary(Of String, SqlDbType),
    ByRef outputResults As Dictionary(Of String, Object),
    ByRef resultSets As List(Of DataTable)
) As Boolean
        Try
            ' --- Validasi koneksi dulu ---
            If CurrentUser.Connection Is Nothing Then
                Throw New Exception("Koneksi ke database belum diinisialisasi.")
            End If

            If CurrentUser.Connection.State <> ConnectionState.Open Then
                CurrentUser.Connection.Open()
            End If

            Using cmd As New SqlCommand(storedProcName, CurrentUser.Connection)
                cmd.CommandType = CommandType.StoredProcedure

                ' --- Tambah input parameters ---
                If inputParams IsNot Nothing Then
                    For Each pair In inputParams
                        If outputParams Is Nothing OrElse Not outputParams.ContainsKey(pair.Key) Then
                            Dim p As New SqlParameter(pair.Key, pair.Value)
                            If TypeOf pair.Value Is String AndAlso pair.Value.ToString().Length > 4000 Then
                                p.SqlDbType = SqlDbType.VarChar
                                p.Size = -1 ' varchar(max)
                            End If
                            p.Direction = ParameterDirection.Input
                            cmd.Parameters.Add(p)
                        End If
                    Next
                End If

                ' --- Tambah output parameters ---
                If outputParams IsNot Nothing Then
                    For Each pair In outputParams
                        Dim p As New SqlParameter(pair.Key, pair.Value)
                        p.Direction = ParameterDirection.Output
                        If pair.Value = SqlDbType.VarChar OrElse pair.Value = SqlDbType.NVarChar Then
                            p.Size = 500
                        End If
                        cmd.Parameters.Add(p)
                    Next
                End If

                ' --- Eksekusi dan tangkap RAISERROR jika ada ---
                Dim resultIndex As Integer = 1
                resultSets = New List(Of DataTable)()

                Using da As New SqlDataAdapter(cmd)
                    Dim ds As New DataSet()
                    da.Fill(ds)

                    For Each dt As DataTable In ds.Tables
                        resultSets.Add(dt)
                        frmHasilDataTable.DataGridView1.DataSource = dt
                        frmHasilDataTable.ShowDialog()
                    Next
                End Using

                ' --- Ambil output parameter ---
                outputResults = New Dictionary(Of String, Object)
                    If outputParams IsNot Nothing Then
                        For Each pair In outputParams
                            outputResults(pair.Key) = cmd.Parameters(pair.Key).Value
                        Next
                    End If

                    Return True ' ✅ sukses

                End Using

        Catch exSql As SqlException
            ' --- Tangkap RAISERROR dari SQL Server ---
            Dim message As String = "SQL Error (" & exSql.Number & "): " & exSql.Message
            MsgBox(message, MsgBoxStyle.Critical, "SQL Server Error")
            outputResults = Nothing
            resultSets = Nothing
            Return False

        Catch ex As Exception
            ' --- Tangkap error biasa ---
            MsgBox("Error: " & ex.Message, MsgBoxStyle.Critical, "Error")
            outputResults = Nothing
            resultSets = Nothing
            Return False
        End Try
    End Function

    Private Function getSha256Hash(ByVal input As String) As String
        Using sha256 As SHA256 = sha256.Create()
            Dim bytes As Byte() = sha256.ComputeHash(Encoding.UTF8.GetBytes(input))
            Dim sb As New StringBuilder()
            For Each b As Byte In bytes
                sb.Append(b.ToString("x2"))
            Next
            Return sb.ToString()
        End Using
    End Function

    Function getMd5Hash(ByVal input As String) As String
        ' Create a new instance of the MD5 object.
        Dim md5Hasher As MD5 = MD5.Create()

        ' Convert the input string to a byte array and compute the hash.
        Dim data As Byte() = md5Hasher.ComputeHash(Encoding.Default.GetBytes(input))

        ' Create a new Stringbuilder to collect the bytes
        ' and create a string.
        Dim sBuilder As New StringBuilder()

        ' Loop through each byte of the hashed data 
        ' and format each one as a hexadecimal string.
        Dim i As Integer
        For i = 0 To data.Length - 1
            sBuilder.Append(data(i).ToString("x2"))
        Next i

        ' Return the hexadecimal string.
        Return sBuilder.ToString()

    End Function

    Public Function GetObjectAkses(ByVal ObjForm As Form) As Boolean
        Dim strPassword As String = getMd5Hash(CurrentUser.Password)


        Dim strSPName As String = "LxUserLogin"
        Dim inputParams As New Dictionary(Of String, Object) From {
            {"@V16", CurrentUser.Username},                        ' Username
            {"@V32", strPassword},                      ' Password hash
            {"@I", DBNull.Value},                       ' Output Param Placeholder
            {"@V50", ObjForm.Name}                      ' Nama Form
        }

        ' Output param "@I|O|" jadi param output
        Dim outputParams As New Dictionary(Of String, SqlDbType) From {
            {"@I", SqlDbType.Int}
        }

        Dim outputResults As Dictionary(Of String, Object)
        Dim resultSets As List(Of DataTable)

        If ExecSP1(strSPName, inputParams, outputParams, outputResults, resultSets) Then
            Dim status As Integer = Convert.ToInt32(outputResults("@I"))

            If status = 0 Then
                GetObjectAkses = True

                ' Ambil DataTable hasil SELECT kedua
                If resultSets IsNot Nothing AndAlso resultSets.Count > 0 Then
                    Dim dtAkses As DataTable = resultSets(0)
                    For Each row As DataRow In dtAkses.Rows
                        Dim controlName As String = row(0).ToString()

                        ' Sembunyikan control jika ditemukan
                        If ObjForm.Controls.ContainsKey(controlName) Then
                            ObjForm.Controls(controlName).Visible = False
                        End If
                    Next
                End If

            ElseIf status = 2 Then
                MsgBox("User tidak dapat mengakses menu ini!", vbCritical)
                GetObjectAkses = False
            Else
                MsgBox("Kombinasi user dan password salah", vbCritical)
                GetObjectAkses = False
            End If
        Else
            GetObjectAkses = False
        End If

    End Function

    Private Function GetMenuAkses(ByVal strFormName As String) As Boolean

        Dim strPassword As String = getMd5Hash(CurrentUser.Password)

        Dim strSPName As String = "LxUserLogin"
        ' === INPUT PARAMETERS ===
        Dim inputParams As New Dictionary(Of String, Object) From {
            {"@pcLoginName", CurrentUser.Username},             ' Username
            {"@pcPassword", strPassword},                      ' Password hash
            {"@pcfrmName", strFormName}                       ' Nama form/menu
        }

        ' === OUTPUT PARAMETERS ===
        Dim outputParams As New Dictionary(Of String, SqlDbType) From {
            {"@pnResultCode", SqlDbType.Int}
        }

        ' === TEMP RESULT HOLDER ===
        Dim outputResults As Dictionary(Of String, Object)
        Dim resultSets As List(Of DataTable)

        If ExecSP1(strSPName, inputParams, outputParams, outputResults, resultSets) Then
            Dim status As Integer = Convert.ToInt32(outputResults("@pnResultCode"))

            If status = 0 Then
                GetMenuAkses = True

                ' === Ambil hasil SELECT ===
                Dim dtUserLogin As DataTable = Nothing
                Dim dtMenu As DataTable = Nothing

                If resultSets.Count >= 1 Then
                    dtUserLogin = resultSets(0)
                    If dtUserLogin.Rows.Count > 0 Then

                        CurrentUser.AppPosition = Convert.ToInt32(dtUserLogin.Rows(0)("AppPosition"))

                    End If
                End If

                If resultSets.Count >= 2 Then
                    dtMenu = resultSets(1)
                    FilterMenuByDataTable(MDIForm.MnuStripInvent, dtMenu)
                End If

            ElseIf status = 2 Then
                MsgBox("User tidak dapat mengakses menu ini!", vbCritical)
                GetMenuAkses = False
            Else
                MsgBox("Kombinasi user dan password salah", vbCritical)
                GetMenuAkses = False
            End If
        Else
            GetMenuAkses = False
        End If
    End Function
    Private Sub FilterMenuByDataTable(menuStrip As MenuStrip, dtMenu As DataTable)
        ' Ambil daftar nama menu yang diizinkan dari DataTable
        Dim allowedMenus As New HashSet(Of String)(StringComparer.OrdinalIgnoreCase)

        For Each row As DataRow In dtMenu.Rows
            If dtMenu.Columns.Contains("ObjectType") Then
                allowedMenus.Add(row("ObjectType").ToString().Trim())
            End If
        Next

        ' Loop semua menu di MenuStrip dan sembunyikan jika tidak ada di daftar
        For Each topItem As ToolStripMenuItem In menuStrip.Items
            FilterMenuItem(topItem, allowedMenus)
        Next
    End Sub

    Private Sub FilterMenuItem(menuItem As ToolStripMenuItem, allowedMenus As HashSet(Of String))
        ' Cek apakah menu ini diizinkan
        menuItem.Visible = allowedMenus.Contains(menuItem.Name.Trim())

        ' Rekursif ke submenu
        For Each subItem As ToolStripItem In menuItem.DropDownItems
            If TypeOf subItem Is ToolStripMenuItem Then
                FilterMenuItem(DirectCast(subItem, ToolStripMenuItem), allowedMenus)
            End If
        Next
    End Sub

End Module
