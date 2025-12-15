using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DoAnTinHoc_Nhom6
{
    public partial class Sua : Form
    {
        private CSanPham sanPham;
        public Sua(CSanPham sp)
        {
            InitializeComponent();
            sanPham = sp;
        }
        private void Sua_Load(object sender, EventArgs e)
        {
            // Đổ dữ liệu lên form
            txtMaMatHang.Text = sanPham.MaMatHang;
            txtTenHang.Text = sanPham.TenHang;
            txtDonGia.Text = sanPham.DonGia.ToString();
            txtSoLuong.Text = sanPham.SoLuong.ToString();
            txtNhaCungCap.Text = sanPham.NhaCungCap;
            dtNgayNhap.Value = sanPham.NgayNhap;

            txtMaMatHang.Enabled = false; // mã không cho sửa
        }
        public void loaddata(CSanPham sp)
        {
            txtMaMatHang.Text = sp.MaMatHang;
            txtTenHang.Text = sp.TenHang;
            txtDonGia.Text = sp.DonGia.ToString();
            txtSoLuong.Text = sp.SoLuong.ToString();
            txtNhaCungCap.Text = sp.NhaCungCap;
            dtNgayNhap.Value = sp.NgayNhap;

            txtMaMatHang.Enabled = false; // mã không cho sửa
        }

        private void btnCapnhat_Click(object sender, EventArgs e)
        {
            sanPham.TenHang = txtTenHang.Text;
            sanPham.DonGia = decimal.Parse(txtDonGia.Text);
            sanPham.SoLuong = int.Parse(txtSoLuong.Text);
            sanPham.NhaCungCap = txtNhaCungCap.Text;
            sanPham.NgayNhap = dtNgayNhap.Value;

            MessageBox.Show("Cập nhật thành công!");
            this.Close();
        }



        private void btnThoattt_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void guna2Panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
