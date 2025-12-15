using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoAnTinHoc_Nhom6
{
    [Serializable]
    public class CSanPham
    {

        #region Attributes
        private string maSanPham = Guid.NewGuid().ToString();
        private string tenSanPham = "";
        private decimal donGia;
        private int soLuong;
        private string nhaCungCap = "";
        private DateTime ngayNhap;
        #endregion

        #region Properties
        public string MaMatHang
        {
            get { return maSanPham; }
            set { maSanPham = value; }
        }
        public string TenHang
        {
            get { return tenSanPham; }
            set { tenSanPham = value; }
        }
        public decimal DonGia
        {
            get { return donGia; }
            set { donGia = value; }
        }
        public int SoLuong
        {
            get { return soLuong; }
            set { soLuong = value; }
        }

        public string NhaCungCap
        {
            get { return nhaCungCap; }
            set { nhaCungCap = value; }
        }
        public DateTime NgayNhap
        {
            get { return ngayNhap; }
            set { ngayNhap = value; }
        }
        #endregion

        #region Methods
        // Constructors
        public CSanPham()
        {
            maSanPham = "";
            tenSanPham = "";
            donGia = 0;
            soLuong = 0;
            nhaCungCap = "";
            ngayNhap = DateTime.Now;
        }

        public CSanPham(string mamathang ,string tenHang, decimal donGia, int soLuong, string nhaCungCap, DateTime ngayNhap)
        {
            this.maSanPham = mamathang;
            this.TenHang = tenHang;
            this.DonGia = donGia;
            this.SoLuong = soLuong;
            this.NhaCungCap = nhaCungCap;
            this.NgayNhap = ngayNhap;
        }
        #endregion
    }
}




