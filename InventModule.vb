Imports System.Configuration
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


                ' Cek akses menu (buat function tambahan)
                'If CheckMenuAccess(conn, strMenu, userInfo.Username) Then
                CurrentUser.Connection = conn
                CurrentUser.AccessGranted = True

                'Else
                '    MessageBox.Show("Akses ke menu ditolak.", "Akses", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                '    conn.Close()
                'End If

            Catch ex As Exception
                MessageBox.Show("Koneksi gagal: " & ex.Message, "Login Gagal", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try

        Loop Until CurrentUser.AccessGranted


    End Sub

End Module
