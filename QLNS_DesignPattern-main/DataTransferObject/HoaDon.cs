using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CNPM
{
    class HoaDon
    {
        public int MaHoaDon, MaKhachHang, TriGia, SoTienTra;
        public DateTime NgayLap;

        public HoaDon()
        {
            TriGia = 0;
            MaHoaDon = 0;
            SoTienTra = 0;
            MaKhachHang = 0;
            NgayLap = DateTime.Now;
        }
    }
}
