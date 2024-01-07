//using System;
//using System.Collections.Generic;
//using System.Data;
//using System.Text;
//using CNPM.DataAccessTier;

//namespace CNPM
//{

//    interface ISachFactory
//    {
//        DataTable getTable(Sach sach = null);
//        Sach getSachbyID(int ma_sach);
//        int Them(Sach sach);
//        bool Sua(Sach sach);
//    }
//    class SachBLT:ISachFactory
//    {
//        SachDAT objSach = new SachDAT();

//        public DataTable getTable(Sach sach = null)
//        {
//            if (sach == null)
//                return objSach.getSachTable();
//            else
//                return objSach.getTraCuuSachTable(sach);
//        }

//        public Sach getSachbyID(int ma_sach)
//        {
//            return objSach.getSach(ma_sach);
//        }

//        public int Them(Sach sach)
//        {
//            return objSach.Them(sach);
//        }

//        public bool Sua(Sach sach)
//        {
//            if (objSach.Check(sach.MaSach))
//                return objSach.Sua(sach);
//            return false;
//        }
//    }
//}

using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using CNPM.DataAccessTier;

namespace CNPM
{//Builder
    interface ISachFactory
    {
        DataTable getTable(Sach sach = null);
        Sach getSachbyID(int ma_sach);
        int Them(Sach sach);
        bool Sua(Sach sach);
    }

    class SachBLT : ISachFactory
    {
        SachDAT objSach = new SachDAT();

        public DataTable getTable(Sach sach = null)
        {
            if (sach == null)
                return objSach.getSachTable();
            else
                return objSach.getTraCuuSachTable(sach);
        }

        public Sach getSachbyID(int ma_sach)
        {
            return objSach.getSach(ma_sach);
        }

        public int Them(Sach sach)
        {
            return objSach.Them(sach);
        }

        public bool Sua(Sach sach)
        {
            if (objSach.Check(sach.MaSach))
                return objSach.Sua(sach);
            return false;
        }

        // Thêm phương thức TạoSachBuilder
        public SachBuilder TaoSachBuilder()
        {
            return new SachBuilder();
        }
    }

    public interface ISachBuilder
    {
        ISachBuilder SetTenSach(string tenSach);
        ISachBuilder SetTacGia(string tacGia);
        ISachBuilder SetTheLoai(string theLoai);
        ISachBuilder SetDonGia(int donGia);

        Sach Build();
    }

    // Tạo lớp SachBuilder
    public class SachBuilder : ISachBuilder
    {
        //private Sach _sach;

        //public SachBuilder()
        //{
        //    _sach = new Sach();
        //}

        public int MaSach, DonGia, SoLuongTon;
        public string TenSach, TacGia, TheLoai;

        public ISachBuilder SetTenSach(string tenSach)
        {
            this.TenSach = tenSach;
            return this;
        }

        public ISachBuilder SetTacGia(string tacGia)
        {
            this.TacGia = tacGia;
            return this;
        }

        public ISachBuilder SetTheLoai(string theLoai)
        {
            this.TheLoai = theLoai;
            return this;
        }

        public ISachBuilder SetDonGia(int donGia)
        {
            this.DonGia = donGia;
            return this;
        }

        // ... Thêm các phương thức setter khác cho các thuộc tính của Sach

        public Sach Build()
        {
            return new Sach(MaSach, DonGia, SoLuongTon, TenSach, TacGia, TheLoai);
        }
    }


}




