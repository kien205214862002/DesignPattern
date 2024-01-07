using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CNPM
{
    class ThuTien
    {
        public int MaThuTien, MaKhachHang, SoTienThu;
        public DateTime NgayThu;

        public ThuTien()
        {
            MaThuTien = 0;
            MaKhachHang = 0;
            SoTienThu = 0;

            NgayThu = DateTime.Now;
        }

        public ThuTien(int ma_khach_hang, int so_tien_thu) : this()
        {
            MaKhachHang = ma_khach_hang;
            SoTienThu = so_tien_thu;
        }
    }
}
