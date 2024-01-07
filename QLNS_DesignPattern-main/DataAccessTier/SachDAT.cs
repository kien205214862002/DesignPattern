using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.OleDb;
using System.Data;
using System.Text;

namespace CNPM.DataAccessTier
{
    class SachDAT
    {
        public SachDAT() { }

        public DataTable getSachTable()
        {

            DBConnection conn = DBConnection.Instance;
            DataTable res = new DataTable();
            OleDbCommand cmd = new OleDbCommand("Select * from SACH", conn.getConn());
            conn.getConn().Open();
            (new OleDbDataAdapter(cmd)).Fill(res);
            conn.getConn().Close();
            return res;
        }

        public DataTable getTraCuuSachTable(Sach sach)
        {
            DataTable res = new DataTable();

            DBConnection conn = DBConnection.Instance;
            StringBuilder str = new StringBuilder("Select * from SACH where 1=1");
            if (!String.IsNullOrWhiteSpace(sach.TacGia))
                str.Append(" and TacGia LIKE '%" + sach.TacGia + "%'");
            if (!String.IsNullOrWhiteSpace(sach.TenSach))
                str.Append(" and TenSach LIKE '%" + sach.TenSach + "%'");
            if (!String.IsNullOrWhiteSpace(sach.TheLoai))
                str.Append(" and TheLoai = '" + sach.TheLoai + "'");
            OleDbCommand cmd = new OleDbCommand(str.ToString(), conn.getConn());
            conn.getConn().Open();
            (new OleDbDataAdapter(cmd)).Fill(res);
            conn.getConn().Close();
            return res;
        }

        public Sach getSach(int ma_sach)
        {

            DBConnection conn = DBConnection.Instance;
            conn.getConn().Open();
            Sach res = null;
            OleDbCommand cmd = new OleDbCommand("Select * from SACH where MaSach = " + ma_sach, conn.getConn());
            OleDbDataReader rd = cmd.ExecuteReader();
            if (rd.Read())
            {
                res = new Sach();
                res.MaSach = (int)rd["MaSach"];
                res.DonGia = (int)rd["DonGia"];
                res.SoLuongTon = (int)rd["SoLuongTon"];
                res.TacGia = rd["TacGia"].ToString();
                res.TenSach = rd["TenSach"].ToString();
                res.TheLoai = rd["TheLoai"].ToString();
                rd.Close();
            }
            conn.getConn().Close();
            return res;
        }

        public bool Check(int ma_sach)
        {

            DBConnection conn = DBConnection.Instance;
            conn.getConn().Open();
            OleDbCommand cmd = new OleDbCommand("Select count(*) from SACH where MaSach = " + ma_sach, conn.getConn());
            bool res = ((int)cmd.ExecuteScalar() > 0);
            conn.getConn().Close();
            return res;
        }
        public int Them(Sach sach)
        {

            DBConnection conn = DBConnection.Instance;
            conn.getConn().Open();
            OleDbCommand cmd = new OleDbCommand("Insert into SACH(TenSach, TacGia, TheLoai, DonGia) values (@1, @2, @3, @4)", conn.getConn());
            cmd.Parameters.Add("@1", OleDbType.BSTR).Value = sach.TenSach;
            cmd.Parameters.Add("@2", OleDbType.BSTR).Value = sach.TacGia;
            cmd.Parameters.Add("@3", OleDbType.BSTR).Value = sach.TheLoai;
            cmd.Parameters.Add("@4", OleDbType.Numeric).Value = sach.DonGia;
            if (cmd.ExecuteNonQuery() > 0)
                sach.MaSach = (int)(new OleDbCommand("SELECT @@IDENTITY;", conn.getConn())).ExecuteScalar();
            conn.getConn().Close();
            return sach.MaSach;
        }

        public bool Sua(Sach sach)
        {

            DBConnection conn = DBConnection.Instance;
            conn.getConn().Open();
            OleDbCommand cmd = new OleDbCommand("Update SACH set TenSach = @1, TacGia = @2, TheLoai = @3, DonGia = @4, SoLuongTon = @5 where MaSach = @6", conn.getConn());
            cmd.Parameters.Add("@1", OleDbType.BSTR).Value = sach.TenSach;
            cmd.Parameters.Add("@2", OleDbType.BSTR).Value = sach.TacGia;
            cmd.Parameters.Add("@3", OleDbType.BSTR).Value = sach.TheLoai;
            cmd.Parameters.Add("@4", OleDbType.Numeric).Value = sach.DonGia;
            cmd.Parameters.Add("@5", OleDbType.Numeric).Value = sach.SoLuongTon;
            cmd.Parameters.Add("@6", OleDbType.Numeric).Value = sach.MaSach;
            bool res = (cmd.ExecuteNonQuery() > 0);
            conn.getConn().Close();
            return res;
        }
    }
}
