using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.OleDb;
using System.Data;
using System.Text;

namespace CNPM.DataAccessTier
{
    class NhapSachDAT
    {
        public NhapSachDAT() { }

        public int ThemPhieuNhap(NhapSach s)
        {

            DBConnection conn = DBConnection.Instance;
            OleDbCommand cmd = new OleDbCommand("Insert into PHIEUNHAP(NgayNhap, TriGia) values (@1, @2)", conn.getConn());
            cmd.Parameters.Add("@1", OleDbType.Date).Value = DateTime.Now;
            cmd.Parameters.Add("@2", OleDbType.Numeric).Value = s.TriGia;
            conn.getConn().Open();
            if (cmd.ExecuteNonQuery() > 0)
                s.MaPhieuNhap = (int)(new OleDbCommand("SELECT @@IDENTITY;", conn.getConn())).ExecuteScalar();
            conn.getConn().Close();
            return s.MaPhieuNhap;
        }

        public DataTable getNhapSachTable()
        {

            DBConnection conn = DBConnection.Instance;
            DataTable res = new DataTable();
            conn.getConn().Open();
            (new OleDbDataAdapter(new OleDbCommand("Select * from PHIEUNHAP", conn.getConn()))).Fill(res);
            conn.getConn().Close();
            return res;
        }

        public int ThemChiTietNhapSach(ChiTietNhapSach s)
        {

            DBConnection conn = DBConnection.Instance;
            OleDbCommand cmd = new OleDbCommand("Insert into CHITIETNHAPSACH(MaPhieuNhap, MaSach, SoLuongNhap) values (@1, @2, @3)", conn.getConn());
            cmd.Parameters.Add("@1", OleDbType.Numeric).Value = s.MaPhieuNhap;
            cmd.Parameters.Add("@2", OleDbType.Numeric).Value = s.MaSach;
            cmd.Parameters.Add("@3", OleDbType.Numeric).Value = s.SoLuongNhap;
            conn.getConn().Open();
            if (cmd.ExecuteNonQuery() > 0)
                s.MaChiTiet = (int)(new OleDbCommand("SELECT @@IDENTITY;", conn.getConn())).ExecuteScalar();
            conn.getConn().Close();
            return s.MaChiTiet;
        }
    }
}
