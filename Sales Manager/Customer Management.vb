Imports System.Data.DataTable

Imports System.Data.SqlClient

Public Class frmCustomer_Management
    Dim Connection As String = "workstation id=anhvdps02128.mssql.somee.com;packet size=4096;user id=ps02128;pwd=anhvdps02128;data source=anhvdps02128.mssql.somee.com;persist security info=False;initial catalog=anhvdps02128"
    Dim anhvdps02128 As New DataTable

    Private Sub DataUpdateAll()
        Dim KetNoi As SqlConnection = New SqlConnection(Connection)
        Dim TruyVanChuyenDoi As New SqlDataAdapter("Select * from KhachHang", KetNoi)
        Try
            KetNoi.Open()
            TruyVanChuyenDoi.Fill(anhvdps02128)
        Catch ex As Exception

        End Try
        dgvDataGridView.DataSource = anhvdps02128
    End Sub

    Private Sub frmCustomer_Management_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        DataUpdateAll()
    End Sub

    Private Sub btnclose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnclose.Click
        Dim dialog As DialogResult = MessageBox.Show("You want to End Application?",
                                    "Customer Management!Anhvdps02128", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If (dialog = DialogResult.Yes) Then
            frmMain_Sales_Manager.Show()
            Me.Close()
        End If
    End Sub
End Class