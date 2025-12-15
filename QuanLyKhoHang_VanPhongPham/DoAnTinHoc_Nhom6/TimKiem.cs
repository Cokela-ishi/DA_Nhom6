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
    public partial class TimKiem : Form
    {
        private CXuLiKhoHang xulikho;

        // Truyền kho từ Form cha vào
        public TimKiem(CXuLiKhoHang kho)
        {
            InitializeComponent();
            xulikho = kho;
        }

        // Load toàn bộ kho khi form mở
        private void TimKiem_Load(object sender, EventArgs e)
        {
            LoadKhoToGrid();
        }
        // Hàm load DataGridView
        private void LoadKhoToGrid()
        {
            dgvDanhSach.DataSource = null;
            dgvDanhSach.DataSource = xulikho.xemKho();
        }
        private void btTimMa_Click_1(object sender, EventArgs e)
        {
            string ma = txtMaHang.Text.Trim(); //.Trim de loai bo khoang trong dau va cuoi
            if (string.IsNullOrEmpty(ma))
            {
                LoadKhoToGrid(); // o trong -> hien toan bo
            }
            else
            {
                var dsKetQua = xulikho.TimSanPhamTheoMa(ma);
                dgvDanhSach.DataSource = null;
                dgvDanhSach.DataSource = dsKetQua;
            }
        }
        private void btnTimTen_Click(object sender, EventArgs e)
        {
            string ten = txtTenHang.Text.Trim();
            if (string.IsNullOrEmpty(ten))
            {
                LoadKhoToGrid();
            }
            else
            {
                List<CSanPham> dsKetQua = xulikho.TimSanPhamTheoTen(ten);
                dgvDanhSach.DataSource = null;
                dgvDanhSach.DataSource = dsKetQua;
            }
        }

        private void dgvDanhSach_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            LoadKhoToGrid();
        }
        
        private void guna2Panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
