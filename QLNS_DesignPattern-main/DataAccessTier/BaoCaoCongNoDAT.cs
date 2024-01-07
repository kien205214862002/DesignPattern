using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.OleDb;
using System.Data;
using System.Text;

namespace CNPM.DataAccessTier
{
    class BaoCaoCongNoDAT 
    {
        
        public BaoCaoCongNoDAT(){ }

        public DataTable getBaoCaoTable(DateTime from, DateTime to)
        {
            // Tạo đối tượng DBConnection thông qua Singleton
            DBConnection conn = DBConnection.Instance;

            DataTable res = new DataTable();
            OleDbCommand cmd = new OleDbCommand("Select MaKhachHang, HoTenKhachHang, (IIF(IsNull(ThemNo), 0, ThemNo) - IIF(IsNull(ThuNo), 0, ThuNo)) as PhatSinh, (SoTienNo + IIF(IsNull(ThuNoCuoiThang), 0, ThuNoCuoiThang) - IIF(IsNull(ThemNoCuoiThang), 0, ThemNoCuoiThang)) as NoCuoiThang from (Select kh.MaKhachHang, HoTenKhachHang, " +
                "(Select sum(hd.TriGia - hd.SoTienTra) from HOADON hd where hd.TriGia > hd.SoTienTra and hd.MaKhachHang = kh.MaKhachHang and hd.NgayLap between @1 and @2 group by kh.MaKhachHang) as ThemNo, " +
                "(Select sum(tt.SoTienThu) from THUTIEN tt where tt.MaKhachHang = kh.MaKhachHang and tt.NgayThu between @1 and @2 group by kh.MaKhachHang) as ThuNo, " +
                "(Select sum(hd.TriGia - hd.SoTienTra) from HOADON hd where hd.TriGia > hd.SoTienTra and hd.MaKhachHang = kh.MaKhachHang and hd.NgayLap > @2 group by kh.MaKhachHang) as ThemNoCuoiThang, " +
                "(Select sum(tt.SoTienThu) from THUTIEN tt where tt.MaKhachHang = kh.MaKhachHang and tt.NgayThu > @2 group by kh.MaKhachHang) as ThuNoCuoiThang, " +
                "SoTienNo from KHACHHANG kh) baocao", conn.getConn());
            cmd.Parameters.Add("@1", OleDbType.Date).Value = from;
            cmd.Parameters.Add("@2", OleDbType.Date).Value = to;
            conn.getConn().Open();
            (new OleDbDataAdapter(cmd)).Fill(res);
            conn.getConn().Close();
            return res;
        }
    }
}
