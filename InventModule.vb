Imports System.Configuration
Imports Microsoft



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

    ' Tambahkan class model user login


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

End Module
