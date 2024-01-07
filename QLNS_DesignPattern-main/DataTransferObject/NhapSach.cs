using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CNPM
{
    class NhapSach
    {
        public int MaPhieuNhap, TriGia;
        public DateTime NgayNhap;

        public NhapSach()
        {
            MaPhieuNhap = 0;
            TriGia = 0;
            NgayNhap = DateTime.Now;
        }

        public NhapSach(int tri_gia) : this()
        {
            TriGia = tri_gia;
        }
    }
}
