using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.OleDb;
using System.Data;
using System.Linq;
using System.Text;
using System.IO;
using System.Runtime.CompilerServices;

namespace CNPM.DataAccessTier
{
    public class DBConnection
    {
        private static DBConnection _instance;
        private OleDbConnection conn;

        //singleton
        private DBConnection()
        {
            conn = new OleDbConnection("Provider=Microsoft.Jet.OleDB.4.0;Data Source=" + Directory.GetCurrentDirectory() + @"\QuanLiNhaSach.mdb");
            
        }
        public OleDbConnection getConn()
        {
            return conn;
        }

        public static DBConnection Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new DBConnection();
                }
                return _instance;
            }
        }
    }
}
