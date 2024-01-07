using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.OleDb;
using System.Data;
using System.Text;

namespace CNPM.DataAccessTier
{
    class HoaDonDAT
    {
        public HoaDonDAT(){ }

        public int ThemHoaDon(HoaDon s)
        {
            DBConnection conn = DBConnection.Instance;
            OleDbCommand cmd = new OleDbCommand("Insert into HOADON(MaKhachHang, NgayLap, TriGia, SoTienTra) values (@1, @2, @3, @4)", conn.getConn());
            cmd.Parameters.Add("@1", OleDbType.Numeric).Value = s.MaKhachHang;
            cmd.Parameters.Add("@2", OleDbType.Date).Value = DateTime.Now;
            cmd.Parameters.Add("@3", OleDbType.Numeric).Value = s.TriGia;
            cmd.Parameters.Add("@4", OleDbType.Numeric).Value = s.SoTienTra;
            conn.getConn().Open();
            if(cmd.ExecuteNonQuery() > 0)
                s.MaHoaDon = (int)(new OleDbCommand("SELECT @@IDENTITY;", conn.getConn()).ExecuteScalar());
            conn.getConn().Close();
            return s.MaHoaDon;
        }

        public DataTable getHoaDonTable()
        {

            DBConnection conn = DBConnection.Instance;
            DataTable res = new DataTable();
            conn.getConn().Open();
            (new OleDbDataAdapter(new OleDbCommand("Select * from HOADON", conn.getConn()))).Fill(res);
            conn.getConn().Close();
            return res;
        }

        public DataTable getHoaDonTheoMaKhachHangTable(int ma_khach_hang)
        {

            DBConnection conn = DBConnection.Instance;
            DataTable res = new DataTable();
            conn.getConn().Open();
            (new OleDbDataAdapter(new OleDbCommand("Select * from HOADON where MaKhachHang = " + ma_khach_hang, conn.getConn()))).Fill(res);
            conn.getConn().Close();
            return res;
        }

        public int ThemChiTietHoaDon(ChiTietHoaDon s)
        {

            DBConnection conn = DBConnection.Instance;
            OleDbCommand cmd = new OleDbCommand("Insert into CHITIETHOADON(MaHoaDon, MaSach, SoLuongBan) values (@1, @2, @3)", conn.getConn());
            cmd.Parameters.Add("@1", OleDbType.Numeric).Value = s.MaHoaDon;
            cmd.Parameters.Add("@2", OleDbType.Numeric).Value = s.MaSach;
            cmd.Parameters.Add("@3", OleDbType.Numeric).Value = s.SoLuongBan;
            conn.getConn().Open();
            if (cmd.ExecuteNonQuery() > 0)
                s.MaChiTiet = (int)(new OleDbCommand("SELECT @@IDENTITY;", conn.getConn())).ExecuteScalar();
            conn.getConn().Close();
            return s.MaChiTiet;
        }
    }
}
