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
    public partial class NhapHang : Form
    {
        private CXuLiKhoHang XuLyKho;
        private List<CSanPham> dsTam = new List<CSanPham>();

        public NhapHang()
        {
            InitializeComponent();
            if (this.XuLyKho == null)
            {
                this.XuLyKho = new CXuLiKhoHang();
            }
        }
        public NhapHang(CXuLiKhoHang kho)
        {
            InitializeComponent();
            this.XuLyKho = kho;
        }

        private void btnThemHang_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(tbxTenHang.Text))
                {
                    MessageBox.Show("khong duoc bo trong ten hang, hay nhap thong tin ");
                    return;
                }
                if (!decimal.TryParse(TbxDonGia.Text, out decimal dongia) || dongia < 0)
                {
                    MessageBox.Show("Don gia khong hop le ");
                    return;
                }
                if (!int.TryParse(tbxSoLuong.Text, out int soLuong) || soLuong <= 0)
                {
                    MessageBox.Show("So luong khong hop le ");
                    return;
                }
                CSanPham sp = new CSanPham(txbMaHang.Text,
                    tbxTenHang.Text,
                    dongia,
                    soLuong,
                    tbxNhaCungCap.Text,
                    dpkNgayNhap.Value);

                sp.MaMatHang = XuLyKho.TaoMaMatHang(dpkNgayNhap.Value);
                dsTam.Add(sp);
                dgvThemHang.DataSource = null;
                dgvThemHang.DataSource = dsTam;


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "loi", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
        }

        private void btnXacNhan_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (var sp in dsTam)
                {
                    XuLyKho.ThemSanPham(sp);
                }
                MessageBox.Show("Da them vao kho thanh cong ");
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "loi");
            }
        }

        private void LoadKhoToGrid()
        {

        }
        private void btnXemKho_Click(object sender, EventArgs e)
        {

        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnThoat_Click_1(object sender, EventArgs e)
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
