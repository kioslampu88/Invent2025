Imports Invent2025.GlobalClass

Public Class frmPenjualan
    Inherits Form
    Implements IFormWithMode

    Private formState As New FormStatusManager()

    Public Property ModeStatus As Mode Implements IFormWithMode.ModeStatus
        Get
            Return formState.CurrentMode
        End Get
        Set(value As Mode)
            formState.CurrentMode = value
            ' Optional: handle internal UI di sini
        End Set
    End Property

    Public Sub OnToolbarClick(modeCommand As Mode) Implements IFormWithMode.OnToolbarClick

        formState.CurrentMode = modeCommand
        Select Case modeCommand
            Case Mode.NewType
                ' Bersihkan form
                ClearAllInputs(Me)

            Case Mode.EditType
                ' Aktifkan edit

            Case Mode.SaveType
                ' Simpan data

            Case Mode.DeleteType
                ' Aktifkan edit

            Case Mode.PrintType
                ' Cetak

            Case Mode.CancelType
                ' Batalkan perubahan

            Case Mode.RefreshType
                ' Refresh data

        End Select

        ' Setelah update, suruh MDI update tombol
        CType(Me.MdiParent, MDIForm).UpdateToolbarFromChild()
    End Sub
End Class