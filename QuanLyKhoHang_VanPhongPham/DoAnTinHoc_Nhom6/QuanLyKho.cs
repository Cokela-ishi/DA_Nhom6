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
    public partial class frmQuanLyKhoHang : Form
    {

        private CXuLiKhoHang xulikho;
        public frmQuanLyKhoHang()
        {
            InitializeComponent();
            xulikho = new CXuLiKhoHang();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            NhapHang f = new NhapHang(xulikho);
            f.ShowDialog();
            LoadKhoToGrid();

        }
        private void LoadKhoToGrid()
        {
            dgvQuanLiKho.DataSource = null;
            dgvQuanLiKho.DataSource = xulikho.xemKho();
        }
        public void hienthi(DataGridView dgv, Dictionary<string,CSanPham>ds)
        {
            dgv.DataSource = ds.Values.ToList();
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

        private void btnXoa_Click(object sender, EventArgs e)
        {
            frmXoa f = new frmXoa(xulikho);
            f.ShowDialog();
            LoadKhoToGrid();
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            TimKiem f = new TimKiem(xulikho);
            f.ShowDialog();
            LoadKhoToGrid();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (dgvQuanLiKho.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn sản phẩm để sửa!");
                return;
            }
            // Lấy mã mặt hàng từ dòng được chọn
            string ma = dgvQuanLiKho.SelectedRows[0].Cells[0].Value.ToString();

            // Lấy đối tượng sản phẩm ra từ kho
            CSanPham sp = xulikho.TimSanPham(ma);

            if (sp == null)
            {
                MessageBox.Show("Không tìm thấy sản phẩm!");
                return;
            }

            // Mở form Sửa
            Sua f = new Sua(sp);
            f.loaddata(sp);
            f.ShowDialog();

            // Cập nhật lại datagridview
            LoadKhoToGrid();

        }

        private void btnGhiFile_Click(object sender, EventArgs e)
        {
            xulikho.ghifile();
            MessageBox.Show("Đã lưu file thành công!");
        }

        private void btnDocFile_Click(object sender, EventArgs e)
        {
            try
            {
                xulikho.docfile();
                LoadKhoToGrid();
                //hienthi(dgvQuanLiKho, xulikho.DS);
                MessageBox.Show("Đọc danh sách thành công!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi đọc file: " + ex.Message);
            }
        }
        
    }
}

