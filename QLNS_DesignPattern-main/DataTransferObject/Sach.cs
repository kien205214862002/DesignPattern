using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CNPM
{
    public class Sach
    {
        public int MaSach, DonGia, SoLuongTon;
        public string TenSach, TacGia, TheLoai;

        public Sach()
        {
            MaSach = 0;
            DonGia = 0;
            SoLuongTon = 0;

            TacGia = "";
            TenSach = "";
            TheLoai = "";
        }
        public Sach(int maSach, int donGia, int soLuongTon, string tenSach, string tacGia, string theLoai)
        {
            MaSach = maSach;
            DonGia = donGia;
            SoLuongTon = soLuongTon;
            TenSach = tenSach;
            TacGia = tacGia;
            TheLoai = theLoai;
        }
    }
}
