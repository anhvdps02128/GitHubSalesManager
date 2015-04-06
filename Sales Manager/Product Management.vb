Imports System.Data.SqlClient
Imports System.Data.DataTable

Public Class frmProduct_Management
    Dim Connection As String = "workstation id=anhvdps02128.mssql.somee.com;packet size=4096;user id=ps02128;pwd=anhvdps02128;data source=anhvdps02128.mssql.somee.com;persist security info=False;initial catalog=anhvdps02128"
    Dim anhvdps02128 As New DataTable

    Private Sub btnclose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnclose.Click
        Dim dialog As DialogResult = MessageBox.Show("You want to End Application?",
                                    "Product Management! Anhvdps02128", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If (dialog = DialogResult.Yes) Then
            frmMain_Sales_Manager.Show()
            Me.Close()
        End If
    End Sub
    Private Sub LoadDataUpdateAll()
        Dim KetNoi As SqlConnection = New SqlConnection(Connection)
        Dim TruyVanChuyenDoi As New SqlDataAdapter("Select * from SanPham", KetNoi)
        Try
            KetNoi.Open()
            TruyVanChuyenDoi.Fill(anhvdps02128)
        Catch ex As Exception

        End Try
        dgvConnect.DataSource = anhvdps02128
    End Sub

    Private Sub frmProduct_Management_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        LoadDataUpdateAll()

    End Sub

    Private Sub btnadd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnadd.Click
        
    End Sub

    Private Sub dgvConnect_CellClick(ByVal sender As System.Object, ByVal e As DataGridViewCellEventArgs) Handles dgvConnect.CellClick
        Dim Focus As Integer = dgvConnect.CurrentCell.RowIndex
        txtMasp.Text = dgvConnect.Item(0, Focus).Value.ToString()
        txtTensp.Text = dgvConnect.Item(1, Focus).Value.ToString()
        txtDongia.Text = dgvConnect.Item(2, Focus).Value.ToString()
        nudSoluong.Text = dgvConnect.Item(3, Focus).Value.ToString()
        txtChitiet.Text = dgvConnect.Item(4, Focus).Value.ToString()
        txtLoaiMaLoai.Text = dgvConnect.Item(5, Focus).Value.ToString()
        dtpNgayNhapHang.Text = dgvConnect.Item(6, Focus).Value.ToString()
    End Sub

    Private Sub btnedit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnedit.Click
        Dim KetNoi As SqlConnection = New SqlConnection(Connection)
        KetNoi.Open()
        Dim Edit As String = " Update SanPham set TenSanPham=@Ten, DonGia=@Gia, SoLuong=@SoLuong, ChiTietSP=@ChiTiet, LoaiSanPham_MaLoai= @MaLoai, NgayNhapHang=@Ngay Where MaSP=@Ma"
        Dim SPedit As New SqlCommand(Edit, KetNoi)
        Try
            SPedit.Parameters.AddWithValue("@Ten", txtTensp.Text)
            SPedit.Parameters.AddWithValue("@Gia", txtDongia.Text)
            SPedit.Parameters.AddWithValue("@SoLuong", nudSoluong.Text)
            SPedit.Parameters.AddWithValue("@ChiTiet", txtChitiet.Text)
            SPedit.Parameters.AddWithValue("@MaLoai", txtLoaiMaLoai.Text)
            SPedit.Parameters.AddWithValue("@Ngay", dtpNgayNhapHang.Text)
            SPedit.ExecuteNonQuery()
            KetNoi.Close()

        Catch ex As Exception

        End Try
        anhvdps02128.Clear()
        dgvConnect.DataSource = anhvdps02128
        dgvConnect.DataSource = Nothing
        LoadDataUpdateAll()
    End Sub

    Private Sub btnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDelete.Click
        Dim Ketnoi As New SqlConnection(Connection)
        Ketnoi.Open()
        Dim Delete As String = " Delete from SanPham where MaSanPham=@Ma"
        Dim SPdelete As New SqlCommand(Delete, Ketnoi)
        Try
            SPdelete.Parameters.AddWithValue("@Ma", txtMasp.Text)
            SPdelete.ExecuteNonQuery()
            Ketnoi.Close()

        Catch ex As Exception

        End Try
        anhvdps02128.Clear()
        dgvConnect.DataSource = anhvdps02128
        dgvConnect.DataSource = Nothing
        LoadDataUpdateAll()
    End Sub

    Private Sub txtDongia_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtDongia.KeyPress
        If Not Char.IsDigit(e.KeyChar) And Not Char.IsControl(e.KeyChar) Then
            e.Handled = True
        Else
            e.Handled = False
        End If
    End Sub
End Class