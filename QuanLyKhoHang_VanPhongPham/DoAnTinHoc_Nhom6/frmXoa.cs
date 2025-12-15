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
    public partial class frmXoa : Form
    {
        private CXuLiKhoHang xulikho;
        public frmXoa()
        {
            InitializeComponent();
        }
        public frmXoa(CXuLiKhoHang kho)
        {
            InitializeComponent();
            xulikho = kho;
            LoadTatCaHang();
            LoadComBoBox();
        }
        private void LoadComBoBox()
        {
            cbLoaiTimKiem.Items.Add("Mã hàng hoá");
            cbLoaiTimKiem.Items.Add("Tên hàng hoá");
            cbLoaiTimKiem.Items.Add("Nhà Cung cấp");
            cbLoaiTimKiem.SelectedIndex = 0;

        }
        private void LoadTatCaHang()
        {
            dgvXoaHang.DataSource = null;
            dgvXoaHang.DataSource = xulikho.xemKho();
        }
        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (dgvXoaHang.CurrentRow == null)
            {
                MessageBox.Show("Hay chon mat hang de xoa");
                return;
            }
            string ma = dgvXoaHang.CurrentRow.Cells["MaMatHang"].Value.ToString();
            DialogResult xacnhan = MessageBox.Show(
                "Ban co chac chan muon xoa ",
                "Xac nhan xoa ",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);
            if (xacnhan == DialogResult.Yes)
            {
                xulikho.XoaSanPham(ma);
                MessageBox.Show("Xoa thanh cong ");
                LoadTatCaHang();
            }

        }

        private void btTimKiem_Click(object sender, EventArgs e)
        {
            string thongtin = tbxTimKiem.Text.ToLower().Trim();
            if (string.IsNullOrWhiteSpace(thongtin))
            {
                MessageBox.Show("Hay nhap thong tin de tim kiem");
                return;
            }
            var ds = xulikho.xemKho();
            List<CSanPham> ketqua = new List<CSanPham>();
            switch (cbLoaiTimKiem.SelectedItem.ToString())
            {
                case "Mã hàng hoá":
                    ketqua = ds.Where(h => h.MaMatHang.ToLower().Contains(thongtin)).ToList();
                    break;
                case "Tên hàng hoá":
                    ketqua = ds.Where(h => h.TenHang.ToLower().Contains(thongtin)).ToList();
                    break;
                case "Nhà Cung cấp":
                    ketqua = ds.Where(h => h.NhaCungCap.ToLower().Contains(thongtin)).ToList();
                    break;
            }
            dgvXoaHang.DataSource = null;
            dgvXoaHang.DataSource = ketqua;
        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            LoadTatCaHang();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(" Ban co chac chan muon thoat khoi chuong trinh",
                "Xac nhan thoat",
            MessageBoxButtons.YesNo,
            MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                Close();
            }
        }
    }
}

