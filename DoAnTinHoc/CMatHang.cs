using System;

namespace DoAn
{
    public class MatHang
    {
        #region Attributes
        private string maMatHang;
        private string tenMatHang = "";
        private decimal donGia;
        private int soLuong;

        private string nhaCungCap = "";
        private DateTime ngayNhap;
        #endregion

        #region Properties
        public string MaMatHang
        {
            get { return maMatHang; }
            set { maMatHang = value; }
        }
        public string TenHang
        {
            get { return tenMatHang; }
            set { tenMatHang = value; }
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
        public MatHang()
        {
            maMatHang = "";
            tenMatHang = "";
            donGia = 0;
            soLuong = 0;
            nhaCungCap = "";
            ngayNhap = DateTime.Now;
        }

        public MatHang(string maMatHang, string tenHang, decimal donGia, int soLuong, string nhaCungCap, DateTime ngayNhap)
        {
            this.MaMatHang = maMatHang;
            this.TenHang = tenHang;
            this.DonGia = donGia;
            this.SoLuong = soLuong;
            this.NhaCungCap = nhaCungCap;
            this.NgayNhap = ngayNhap;
        }
        #endregion
    }
}
