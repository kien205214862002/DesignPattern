using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using CNPM.DataAccessTier;

namespace CNPM
{
    class KhachHangBLT
    {
        KhachHangDAT objKhachHang = new KhachHangDAT();

        public DataTable getTable(KhachHang khach_hang = null)
        {
            if(khach_hang == null)
                return objKhachHang.getKhachHangTable();
            else
                return objKhachHang.getTraCuuKhachHangTable(khach_hang);
        }

        public KhachHang getKhachHangbyID(int ma_khach_hang)
        {
            if (objKhachHang.Check(ma_khach_hang))
                return objKhachHang.getKhachHang(ma_khach_hang);
            return null;
        }

        public bool Them(KhachHang khach_hang)
        {
            return objKhachHang.Them(khach_hang);
        }

        public bool Sua(KhachHang khach_hang)
        {
            if (objKhachHang.Check(khach_hang.MaKhachHang))
                return objKhachHang.Sua(khach_hang);
            return false;
        }
    }
}
