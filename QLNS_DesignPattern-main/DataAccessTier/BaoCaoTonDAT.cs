using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.OleDb;
using System.Data;
using System.Text;

namespace CNPM.DataAccessTier
{
    class BaoCaoTonDAT
    {
        public BaoCaoTonDAT() { }

        public DataTable getBaoCaoTable(DateTime from, DateTime to)
        {

            DBConnection conn = DBConnection.Instance;
            DataTable res = new DataTable();
            OleDbCommand cmd = new OleDbCommand("Select MaSach, TenSach, IIF(IsNull(SoLuongNhap), 0, SoLuongNhap) as SoLuongNhap, IIF(IsNull(SoLuongBan), 0, SoLuongBan) as SoLuongBan, (SoLuongTon - IIF(IsNull(NhapCuoiThang), 0, NhapCuoiThang) + IIF(IsNull(BanCuoiThang), 0, BanCuoiThang)) as TonCuoiThang from (Select sach.MaSach, TenSach, " +
                "(Select sum(ctns.SoLuongNhap) from (CHITIETNHAPSACH ctns inner join PHIEUNHAP pn on ctns.MaPhieuNhap = pn.MaPhieuNhap) where ctns.MaSach = sach.MaSach and pn.NgayNhap between @1 and @2 group by sach.MaSach) as SoLuongNhap, " +
                "(Select sum(cthd.SoLuongBan) from (CHITIETHOADON cthd inner join HOADON hd on cthd.MaHoaDon = hd.MaHoaDon) where cthd.MaSach = sach.MaSach and hd.NgayLap between @1 and @2 group by sach.MaSach) as SoLuongBan, " +
                "(Select sum(ctns.SoLuongNhap) from (CHITIETNHAPSACH ctns inner join PHIEUNHAP pn on ctns.MaPhieuNhap = pn.MaPhieuNhap) where ctns.MaSach = sach.MaSach and pn.NgayNhap > @2 group by sach.MaSach) as NhapCuoiThang, " + 
                "(Select sum(cthd.SoLuongBan) from (CHITIETHOADON cthd inner join HOADON hd on cthd.MaHoaDon = hd.MaHoaDon) where cthd.MaSach = sach.MaSach and hd.NgayLap > @2 group by sach.MaSach) as BanCuoiThang, " +
                "SoLuongTon from SACH sach) baocao", conn.getConn());
            cmd.Parameters.Add("@1", OleDbType.Date).Value = from;
            cmd.Parameters.Add("@2", OleDbType.Date).Value = to;
            conn.getConn().Open();
            (new OleDbDataAdapter(cmd)).Fill(res);
            conn.getConn().Close();
            return res;
        }

        //public DataTable getBaoCaoTable(DateTime date)
        //{
        //    DataTable res = new DataTable();
        //    DateTime from_date = new DateTime(date.Year, date.Month, 1);
        //    DateTime to_date = from_date.AddMonths(1);
        //    OleDbCommand cmd = new OleDbCommand("Select sach.MaSach, sach.TenSach, " +
        //        "(Select sum(ctns.SoLuongNhap) from (CHITIETNHAPSACH ctns inner join PHIEUNHAP pn on ctns.MaPhieuNhap = pn.MaPhieuNhap) where ctns.MaSach = sach.MaSach and pn.NgayNhap between @1 and @2 group by sach.MaSach) as SoLuongNhap, " +
        //        "IIF(IsNull((Select sum(cthd.SoLuongBan) from (CHITIETHOADON cthd inner join HOADON hd on cthd.MaHoaDon = hd.MaHoaDon) where cthd.MaSach = sach.MaSach and hd.NgayLap between @1 and @2 group by sach.MaSach)), 0, 1) as SoLuongBan, " +
        //        "(sach.SoLuongTon - (Select sum(ctns.SoLuongNhap) from (CHITIETNHAPSACH ctns inner join PHIEUNHAP pn on ctns.MaPhieuNhap = pn.MaPhieuNhap) where ctns.MaSach = sach.MaSach and pn.NgayNhap > @2 group by sach.MaSach) + (Select sum(cthd.SoLuongBan) from (CHITIETHOADON cthd inner join HOADON hd on cthd.MaHoaDon = hd.MaHoaDon) where cthd.MaSach = sach.MaSach and hd.NgayLap > @2 group by sach.MaSach)) as TonCuoiThang " +
        //        "from SACH sach", conn);
        //    cmd.Parameters.Add("@1", OleDbType.Date).Value = from_date;
        //    cmd.Parameters.Add("@2", OleDbType.Date).Value = to_date;
        //    conn.Open();
        //    (new OleDbDataAdapter(cmd)).Fill(res);
        //    conn.Close();
        //    return res;
        //}
    }
}
