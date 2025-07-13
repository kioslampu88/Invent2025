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




    Private Sub GetProfileSetting()

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

    Public Function UserLogin(strMenu As String, Optional ShowForm As Boolean = True) As UserInfo
        Dim userInfo As New UserInfo
        Dim server As String = strServer
        Dim dbName As String = strDBName
        Dim useLogin As Boolean = blnActivateLogin
        Dim connectionString As String
        Dim loginOK As Boolean = False

        Do
            If useLogin And ShowForm Then
                frmLogin.ShowDialog()
                If frmLogin.DialogResult = DialogResult.OK Then
                    userInfo.Username = frmLogin.txtUser.Text
                    userInfo.Password = frmLogin.txtPassword.Text
                Else
                    Return Nothing
                End If
            Else
                userInfo.Username = "admin"
                userInfo.Password = "testing"
            End If

            connectionString = $"Data Source={server};Initial Catalog={dbName};User ID={userInfo.Username};Password={userInfo.Password};TrustServerCertificate=True"

            Try
                Dim conn As New SqlConnection(connectionString)
                conn.Open()

                ' Cek akses menu (buat function tambahan)
                'If CheckMenuAccess(conn, strMenu, userInfo.Username) Then
                userInfo.Connection = conn
                userInfo.AccessGranted = True
                '    loginOK = True
                'Else
                '    MessageBox.Show("Akses ke menu ditolak.", "Akses", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                '    conn.Close()
                'End If

            Catch ex As Exception
                MessageBox.Show("Koneksi gagal: " & ex.Message, "Login Gagal", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try

        Loop Until loginOK = True

        Return userInfo
    End Function

End Module
