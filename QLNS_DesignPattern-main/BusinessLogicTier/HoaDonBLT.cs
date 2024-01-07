using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Diagnostics;
using System.Data;
using System.Text;
using CNPM.DataAccessTier;

namespace CNPM
{

    class HoaDonBLT
    {
        SachDAT objSach;
        ThamSoDAT objThamSo;
        HoaDonDAT objHoaDon;
        KhachHangDAT objKhachHang;
        public HoaDonBLT() {
            objSach = new SachDAT();
            objThamSo = new ThamSoDAT();
            objHoaDon = new HoaDonDAT();
            objKhachHang = new KhachHangDAT();
        }
        public bool Them(HoaDon hoa_don, List<ChiTietHoaDon> list_cthd)
        {
            for (int i = 0; i < list_cthd.Count; i++)
            {
                Sach sach = objSach.getSach(list_cthd[i].MaSach);
                if (sach == null)
                {
                    MessageBox.Show("Mã sách không có trong cơ sở dữ liệu");
                    return false;
                }
                else if ((sach.SoLuongTon - list_cthd[i].SoLuongBan) < objThamSo.GetQD2B())
                {
                    MessageBox.Show("Số lượng tồn " + sach.SoLuongTon + " và số lượng bán " + list_cthd[i].SoLuongBan + " không thỏa mãn số lượng tối thiểu sau khi bán");
                    return false;
                }
            }

            KhachHang khach_hang = objKhachHang.getKhachHang(hoa_don.MaKhachHang);
            if (khach_hang == null)
            {
                MessageBox.Show("Mã khách hàng không có trong cơ sở dữ liệu");
                return false;
            }
            else if (khach_hang.SoTienNo > objThamSo.GetQD2A())
            {
                MessageBox.Show("Số tiền nợ vượt quá số tiền nợ tối đa");
                return false;
            }
            else if (hoa_don.SoTienTra < hoa_don.TriGia)
            {
                khach_hang.SoTienNo += hoa_don.TriGia;
                khach_hang.SoTienNo -= hoa_don.SoTienTra;
                objKhachHang.Sua(khach_hang);
            }

            hoa_don.MaHoaDon = objHoaDon.ThemHoaDon(hoa_don);
            for (int i = 0; i < list_cthd.Count; i++)
            {
                list_cthd[i].MaHoaDon = hoa_don.MaHoaDon;
                objHoaDon.ThemChiTietHoaDon(list_cthd[i]);
                Sach sach = objSach.getSach(list_cthd[i].MaSach);
                sach.SoLuongTon -= list_cthd[i].SoLuongBan;
                objSach.Sua(sach);
            }
            Debug.WriteLine("Lập hóa đơn thành công - Nợ của khách hàng" + khach_hang.TenKhachHang + " tăng lên " + (hoa_don.TriGia - hoa_don.SoTienTra) + " thành " + khach_hang.SoTienNo);
            return true;
        }

        public DataTable getTable(int? ma_khach_hang = null)
        {
            if (ma_khach_hang == null)
                return objHoaDon.getHoaDonTable();
            else
                return objHoaDon.getHoaDonTheoMaKhachHangTable((int)ma_khach_hang);
        }
    }
}
