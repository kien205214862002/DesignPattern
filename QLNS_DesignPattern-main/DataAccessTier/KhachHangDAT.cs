using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.OleDb;
using System.Data;
using System.Text;

namespace CNPM.DataAccessTier
{
    
    class KhachHangDAT
    {
        public KhachHangDAT() { }

        public DataTable getKhachHangTable()
        {
            
            DBConnection conn = DBConnection.Instance;
            DataTable res = new DataTable();
            OleDbCommand cmd = new OleDbCommand("Select * from KHACHHANG", conn.getConn());
            conn.getConn().Open();
            (new OleDbDataAdapter(cmd)).Fill(res);
            conn.getConn().Close();
            return res;
        }

        public DataTable getTraCuuKhachHangTable(KhachHang khach_hang)
        {

            DBConnection conn = DBConnection.Instance;
            DataTable res = new DataTable();
            StringBuilder str = new StringBuilder("Select * from KHACHHANG where 1=1");
            if (!String.IsNullOrWhiteSpace(khach_hang.TenKhachHang))
                str.Append(" and HoTenKhachHang LIKE '%" + khach_hang.TenKhachHang + "%'");
            if (!String.IsNullOrWhiteSpace(khach_hang.DienThoai))
                str.Append(" and DienThoai LIKE '%" + khach_hang.DienThoai + "%'");
            OleDbCommand cmd = new OleDbCommand(str.ToString(), conn.getConn());
            conn.getConn().Open();
            (new OleDbDataAdapter(cmd)).Fill(res);
            conn.getConn().Close();
            return res;
        }

        public KhachHang getKhachHang(int ma_khach_hang)
        {

            DBConnection conn = DBConnection.Instance;
            KhachHang res = null;
            OleDbCommand cmd = new OleDbCommand("Select * from KHACHHANG where MaKhachHang = " + ma_khach_hang, conn.getConn());
            conn.getConn().Open();
            OleDbDataReader rd = cmd.ExecuteReader();
            if (rd.Read())
            {
                res = new KhachHang();
                res.MaKhachHang = (int)rd["MaKhachHang"];
                res.SoTienNo = (int)rd["SoTienNo"];
                res.Email = rd["Email"].ToString();
                res.DiaChi = rd["DiaChi"].ToString();
                res.DienThoai = rd["DienThoai"].ToString();
                res.TenKhachHang = rd["HoTenKhachHang"].ToString();
                rd.Close();
            }
            conn.getConn().Close();
            return res;
        }

        public bool Check(int ma_khach_hang)
        {

            DBConnection conn = DBConnection.Instance;
            conn.getConn().Open();
            OleDbCommand cmd = new OleDbCommand("Select Count(*) from KHACHHANG where MaKhachHang = " + ma_khach_hang, conn.getConn());
            bool res = ((int)cmd.ExecuteScalar() > 0);
            conn.getConn().Close();
            return res;
        }

        public bool Them(KhachHang khach_hang)
        {

            DBConnection conn = DBConnection.Instance;
            conn.getConn().Open();
            OleDbCommand cmd = new OleDbCommand("Insert into KHACHHANG(HoTenKhachHang, Email, DiaChi, DienThoai) values (@1, @2, @3, @4)", conn.getConn());
            cmd.Parameters.Add("@1", OleDbType.BSTR).Value = khach_hang.TenKhachHang;
            cmd.Parameters.Add("@2", OleDbType.BSTR).Value = khach_hang.Email;
            cmd.Parameters.Add("@3", OleDbType.BSTR).Value = khach_hang.DiaChi;
            cmd.Parameters.Add("@4", OleDbType.BSTR).Value = khach_hang.DienThoai;
            bool res = (cmd.ExecuteNonQuery() > 0);
            conn.getConn().Close();
            return res;
        }

        public bool Sua(KhachHang khach_hang)
        {

            DBConnection conn = DBConnection.Instance;
            conn.getConn().Open();
            OleDbCommand cmd = new OleDbCommand("Update KHACHHANG set HoTenKhachHang = @1, Email = @2, DiaChi = @3, DienThoai = @4, SoTienNo = @5 where MaKhachHang = @6", conn.getConn());
            cmd.Parameters.Add("@1", OleDbType.BSTR).Value = khach_hang.TenKhachHang;
            cmd.Parameters.Add("@2", OleDbType.BSTR).Value = khach_hang.Email;
            cmd.Parameters.Add("@3", OleDbType.BSTR).Value = khach_hang.DiaChi;
            cmd.Parameters.Add("@4", OleDbType.BSTR).Value = khach_hang.DienThoai;
            cmd.Parameters.Add("@5", OleDbType.Numeric).Value = khach_hang.SoTienNo;
            cmd.Parameters.Add("@6", OleDbType.Numeric).Value = khach_hang.MaKhachHang;
            bool res = (cmd.ExecuteNonQuery() > 0);
            conn.getConn().Close();
            return res;
        }
    }

}
