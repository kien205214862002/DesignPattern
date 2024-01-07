using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.OleDb;
using System.Data;
using System.Text;

namespace CNPM.DataAccessTier
{
    class ThuTienDAT
    {
        public ThuTienDAT(){ }

        public void Them(ThuTien s)
        {

            DBConnection conn = DBConnection.Instance;
            OleDbCommand cmd = new OleDbCommand("Insert into THUTIEN(MaKhachHang, SoTienThu, NgayThu) values (@1, @2, @3)", conn.getConn());
            cmd.Parameters.Add("@1", OleDbType.BSTR).Value = s.MaKhachHang;
            cmd.Parameters.Add("@2", OleDbType.BSTR).Value = s.SoTienThu;
            cmd.Parameters.Add("@3", OleDbType.Date).Value = DateTime.Now;
            conn.getConn().Open();
            cmd.ExecuteNonQuery();
            conn    .getConn().Close();
        }
    }
}
