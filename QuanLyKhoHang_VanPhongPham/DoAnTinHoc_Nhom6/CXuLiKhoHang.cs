using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace DoAnTinHoc_Nhom6
{
    [Serializable]
    public class CXuLiKhoHang
    {
        private Dictionary<string, CSanPham> dsHang;
        string filepath = @"D:\DH52301381\DoAnTinHocNhom6\DoAnTinHoc_Nhom6\bin\Debug\abc.txt";
        public CXuLiKhoHang()
        {
            dsHang = new Dictionary<string, CSanPham>();
        }
        public CXuLiKhoHang(Dictionary<string, CSanPham> dsHang)
        {
            this.dsHang = dsHang;
          
        }
        public Dictionary<string, CSanPham> DS
        {
            get { return this.dsHang; }
            set { this.dsHang = value; }
        }

        public void ThemSanPham(CSanPham sp)
        {
            if (!dsHang.ContainsKey(sp.MaMatHang))
            {
                dsHang[sp.MaMatHang] = sp;
            }
            else
            {
                throw new Exception(" San Pham Da Ton Tai ");
            }
        }
        public List<CSanPham> xemKho()
        {
            return dsHang.Values.ToList();
        }
        public CSanPham TimSanPham(string maMatHang)
        {
            if (dsHang.ContainsKey(maMatHang))
                return dsHang[maMatHang];
            return null;
        }
        public void CapNhatSoLuong(string mamathang, int soluongmoi)
        {
            if (dsHang.ContainsKey(mamathang))
                dsHang[mamathang].SoLuong = soluongmoi;
            else
            {
                throw new Exception("Khong tim thay san pham de cap mhat");
            }
        }
        public void XoaSanPham(string maMatHang)
        {
            if (dsHang.ContainsKey(maMatHang))
                dsHang.Remove(maMatHang);
            else
                throw new Exception("khong tim thay san pham");
        }
        public string TaoMaMatHang(DateTime ngayNhap)
        {
            string mahang = "MH" + ngayNhap.ToString("yyyyMMdd");
            string uuid = Guid.NewGuid().ToString("N").Substring(0, 8).ToUpper();
            return $"{mahang}-{uuid}";
        }
        public List<CSanPham> TimSanPhamTheoMa(string ma)
        {
            List<CSanPham> dsKetQua = new List<CSanPham>();
            ma = ma.ToLower();
            foreach (CSanPham sp in dsHang.Values)
            {
                if (sp.MaMatHang.ToLower().Contains(ma))
                {
                    dsKetQua.Add(sp);
                }
            }
            return dsKetQua;
        }
        public List<CSanPham> TimSanPhamTheoTen(string ten)
        {
            List<CSanPham> dsKetQua = new List<CSanPham>();
            ten = ten.ToLower();
            foreach (CSanPham sp in dsHang.Values)
            {
                if (sp.TenHang.ToLower().Contains(ten))
                    dsKetQua.Add(sp);
            }
            return dsKetQua;
        }
        public void docfile()
        {
            if (!File.Exists(filepath))
                return;
            string[] lines = File.ReadAllLines(filepath);
            foreach (string line in lines)
            {
                if (string.IsNullOrWhiteSpace(line))
                    continue;
                string[] parts = line.Split("|");
                if (parts.Length >= 6)
                {
                    ThemSanPham(new CSanPham(parts[0], parts[1], decimal.Parse(parts[2]), int.Parse(parts[3]), parts[4], DateTime.Parse(parts[5])));
                }
            }
        }
        public void ghifile()
        {
            using (StreamWriter sw = new StreamWriter(filepath))
            {
                foreach (CSanPham sp in xemKho())
                {
                    sw.WriteLine($"{sp.MaMatHang}|{sp.TenHang}|{sp.DonGia}|{sp.SoLuong}|{sp.NhaCungCap}|{sp.NgayNhap}");
                }
            }
        }
    }
}
