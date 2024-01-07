using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Data;
using System.Text;
using CNPM.DataAccessTier;

namespace CNPM
{
    class ThuTienBLT
    {
        ThamSoDAT objThamSo = new ThamSoDAT();
        ThuTienDAT objThuTien = new ThuTienDAT();
        KhachHangBLT objKhachHang = new KhachHangBLT();

        public bool Them(ThuTien thu_tien)
        {
            KhachHang khach_hang = objKhachHang.getKhachHangbyID(thu_tien.MaKhachHang);
            if (khach_hang == null)
            {
                MessageBox.Show("Mã khách hàng không có trong cơ sở dữ liệu");
                return false;
            }
            else if (khach_hang.SoTienNo < thu_tien.SoTienThu && !objThamSo.GetQD4())
            {
                MessageBox.Show("Không thỏa quy định 4");
                return false;
            }
            else
            {
                objThuTien.Them(thu_tien);
                khach_hang.SoTienNo -= thu_tien.SoTienThu;
                objKhachHang.Sua(khach_hang);
                return true;
            }
        }
    }
}