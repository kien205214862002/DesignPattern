using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.OleDb;
using System.Data;
using System.Text;

namespace CNPM.DataAccessTier
{
    class ThamSoDAT
    {
        public ThamSoDAT()
        {

        }

        public int GetQD1A()
        {

            DBConnection conn = DBConnection.Instance;
            conn.getConn().Open();
            OleDbCommand cmd = new OleDbCommand("SELECT SoLuongNhapItNhat FROM THAMSO", conn.getConn());
            int temp = (int)cmd.ExecuteScalar();
            conn.getConn().Close();
            return temp;
        }

        public int GetQD1B()
        {

            DBConnection conn = DBConnection.Instance;
            conn.getConn().Open();
            OleDbCommand cmd = new OleDbCommand("SELECT LuongTonItNhatTruocKhiNhap FROM THAMSO", conn.getConn());
            int temp = (int)cmd.ExecuteScalar();
            conn.getConn().Close();
            return temp;
        }

        public int GetQD2A()
        {

            DBConnection conn = DBConnection.Instance;
            conn.getConn().Open();
            OleDbCommand cmd = new OleDbCommand("SELECT NoToiDa FROM THAMSO", conn.getConn());
            int temp = (int)cmd.ExecuteScalar();
            conn.getConn().Close();
            return temp;
        }

        public int GetQD2B()
        {

            DBConnection conn = DBConnection.Instance;
            conn.getConn().Open();
            OleDbCommand cmd = new OleDbCommand("SELECT LuongTonItNhatSauKhiBan FROM THAMSO", conn.getConn());
            int temp = (int)cmd.ExecuteScalar();
            conn.getConn().Close();
            return temp;
        }

        public bool GetQD4()
        {

            DBConnection conn = DBConnection.Instance;
            conn.getConn().Open();
            OleDbCommand cmd = new OleDbCommand("SELECT CoTheThuTienQuaSoNo FROM THAMSO", conn.getConn());
            bool temp = (bool)cmd.ExecuteScalar();
            conn.getConn().Close();
            return temp;
        }

        public void Save(ThamSo s)
        {

            DBConnection conn = DBConnection.Instance;
            conn.getConn().Open();
            OleDbCommand cmd = new OleDbCommand("Update THAMSO set SoLuongNhapItNhat = @1, LuongTonItNhatTruocKhiNhap = @2, NoToiDa = @3, LuongTonItNhatSauKhiBan = @4, CoTheThuTienQuaSoNo = @5", conn.getConn());
            cmd.Parameters.Add("@1", OleDbType.Numeric).Value = s.QD1A;
            cmd.Parameters.Add("@2", OleDbType.Numeric).Value = s.QD1B;
            cmd.Parameters.Add("@3", OleDbType.Numeric).Value = s.QD2A;
            cmd.Parameters.Add("@4", OleDbType.Numeric).Value = s.QD2B;
            cmd.Parameters.Add("@5", OleDbType.Boolean).Value = s.QD4;
            cmd.ExecuteNonQuery();
            conn.getConn().Close();
        }
    }
}
