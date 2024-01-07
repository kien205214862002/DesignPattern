using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using System.Globalization;
using System.Data.OleDb;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Data;
using System.Linq;
using System.Text;

namespace CNPM
{
    public partial class LapHoaDon : Form
    {
        int TongTien = 0;
        int TienThoi = 0;
        SachBLT objS = new SachBLT();
        HoaDonBLT objHD = new HoaDonBLT();
        ThamSoBLT bltThamSo = new ThamSoBLT();
        KhachHangBLT objKH = new KhachHangBLT();

        public LapHoaDon()
        {
            InitializeComponent();
            cb_MaSach.TextChanged += (s, e) =>
            {
                try
                {
                    Sach sach = objS.getSachbyID(Convert.ToInt32(cb_MaSach.Text));
                    txt_SoLuongTon.Text = sach.SoLuongTon.ToString();
                    txt_DonGiaBan.Text = ((int)(sach.DonGia * 1.05)).ToString();
                    txt_TenSach.Text = sach.TenSach;
                    txt_TheLoai.Text = sach.TheLoai;
                    txt_TacGia.Text = sach.TacGia;
                    TinhLuongTonSauKhiBan();
                }
                catch
                {
                    txt_SoLuongTon.Text = "";
                    txt_DonGiaBan.Text = "";
                    txt_TenSach.Text = "";
                    txt_TheLoai.Text = "";
                    txt_TacGia.Text = "";
                }
            };
            cb_MaKhachHang.TextChanged += (s, e) =>
            {
                try
                {
                    KhachHang khach_hang = objKH.getKhachHangbyID(Convert.ToInt32(cb_MaKhachHang.Text));
                    txt_TenKhachHang.Text = khach_hang.TenKhachHang;
                    txt_DienThoai.Text = khach_hang.DienThoai;
                    txt_SoTienNo.Text = khach_hang.SoTienNo.ToString();
                }
                catch
                {
                    txt_TenKhachHang.Text = "";
                    txt_DienThoai.Text = "";
                    txt_SoTienNo.Text = "";
                }
            };
            txt_TienTra.TextChanged += (s, e) => TinhTienThoi();
            txt_SoLuongBan.TextChanged += (s, e) => TinhLuongTonSauKhiBan();
            txt_SoLuongTon.TextChanged += (s, e) => TinhLuongTonSauKhiBan();
            dataGridView.CellClick += (s, e) => ShowData();
            btn_reload.Click += (s, e) => LoadData();
            btn_BoSung.Click += (s, e) =>
            {
                if (String.IsNullOrWhiteSpace(txt_TenSach.Text))
                    MessageBox.Show("Mã sách không có trong cơ sở dữ liệu");
                else if (String.IsNullOrWhiteSpace(txt_SoLuongBan.Text))
                    MessageBox.Show("Phải có số lượng bán");
                else if (Convert.ToInt32(txt_SoLuongBan.Text) <= 0)
                    MessageBox.Show("Số lượng bán phải lớn hơn 0");
                else if (Convert.ToInt32(txt_SoLuongTon.Text) - Convert.ToInt32(txt_SoLuongBan.Text) < bltThamSo.GetQD2B())
                    MessageBox.Show("Số lượng bán không thỏa mãn số lượng tồn tối thiểu sau khi bán");
                else
                {
                    bool add = true;
                    foreach (DataGridViewRow dr in dataGridView.Rows)
                        if (dr.Cells[0].Value.ToString() == cb_MaSach.Text)
                        {
                            dr.Cells["SoLuongBan"].Value = txt_SoLuongBan.Text;
                            add = false;
                            break;
                        }
                    if (add)
                    {
                        var index = dataGridView.Rows.Add();
                        dataGridView.Rows[index].Cells["MaSach"].Value = cb_MaSach.Text;
                        dataGridView.Rows[index].Cells["TenSach"].Value = txt_TenSach.Text;
                        dataGridView.Rows[index].Cells["SoLuongTon"].Value = txt_SoLuongTon.Text;
                        dataGridView.Rows[index].Cells["SoLuongBan"].Value = txt_SoLuongBan.Text;
                        dataGridView.Rows[index].Cells["DonGiaBan"].Value = txt_DonGiaBan.Text;
                        
                    }
                    foreach (DataGridViewRow dr in dataGridView.Rows)
                    {
                        int so_luong_ban = Convert.ToInt32(dr.Cells["SoLuongBan"].Value);
                        int don_gia_ban = Convert.ToInt32(dr.Cells["DonGiaBan"].Value);
                        dr.Cells["ThanhTien"].Value = so_luong_ban*don_gia_ban;
                    }
                    TinhTongTien();
                }
            };
            btnXoa.Click += (s, e) =>
            {
                cb_MaSach.Text = "";
                foreach (DataGridViewCell oneCell in dataGridView.SelectedCells)
                    if (oneCell.Selected && !dataGridView.Rows[oneCell.RowIndex].IsNewRow)
                        dataGridView.Rows.RemoveAt(oneCell.RowIndex);
                ShowData();
                TinhTongTien();
            };
            btnLap.Click += (s, e) =>
            {
                if (String.IsNullOrWhiteSpace(txt_TenKhachHang.Text))
                {
                    MessageBox.Show("Mã khách hàng không có trong cơ sở dữ liệu");
                    return;
                }
                else if (dataGridView.Rows.Count < 1)
                {
                    MessageBox.Show("Không có chi tiết hóa đơn để thực hiện lập hóa đơn");
                    return;
                }
                else if (Convert.ToInt32(txt_TienThoi.Text.Replace(",", "")) < 0)
                {
                    MessageBox.Show("Tiền trả không được bé hơn tổng tiền");
                    return;
                }
                List<ChiTietHoaDon> list = new List<ChiTietHoaDon>();
                for (int i = 0; i < dataGridView.Rows.Count; i++)
                {
                    ChiTietHoaDon cthd = new ChiTietHoaDon();
                    cthd.MaSach = Convert.ToInt32(dataGridView.Rows[i].Cells["MaSach"].Value);
                    cthd.SoLuongBan = Convert.ToInt32(dataGridView.Rows[i].Cells["SoLuongBan"].Value);
                    list.Add(cthd);
                }
                HoaDon hoa_don = new HoaDon();
                hoa_don.MaKhachHang = int.Parse(cb_MaKhachHang.Text);
                hoa_don.TriGia = TongTien;
                hoa_don.SoTienTra = int.Parse(txt_TienTra.Text);
                if (objHD.Them(hoa_don, list))
                {
                    MessageBox.Show("Lập hóa đơn thành công");
                    LoadData();
                }
                else
                    MessageBox.Show("Lập hóa đơn thất bại");
            };
            panel.Paint += (s, e) =>
            {
                LinearGradientBrush linearGradientBrush = new LinearGradientBrush(panel.ClientRectangle, Color.Red, Color.Yellow, 45);
                ColorBlend cblend = new ColorBlend(3);
                cblend.Colors = new Color[3] { Color.DarkSeaGreen, Color.SkyBlue, Color.MediumSpringGreen };
                cblend.Positions = new float[3] { 0f, 0.5f, 1f };
                linearGradientBrush.InterpolationColors = cblend;
                e.Graphics.FillRectangle(linearGradientBrush, panel.ClientRectangle);
            };
            LoadData();
        }

        void ShowData()
        {
            if (dataGridView.Rows.Count <= 0)
                return;
            cb_MaSach.Text = Convert.ToString(dataGridView.CurrentRow.Cells[0].Value);
            txt_SoLuongTon.Text = Convert.ToString(dataGridView.CurrentRow.Cells[1].Value);
        }

        void TinhTongTien()
























































































































        {
            TongTien = 0;
            foreach (DataGridViewRow row in dataGridView.Rows)
                TongTien += (int)row.Cells["ThanhTien"].Value;
            txt_TongTien.Text = String.Format("{0:n0}", TongTien);
            TinhTienThoi();
        }

        void TinhTienThoi()
        {
            int tien_tra = 0;
            int.TryParse(txt_TienTra.Text, out tien_tra);
            TienThoi = tien_tra - TongTien;
            txt_TienThoi.Text = String.Format("{0:n0}", TienThoi);
        }

        //void TinhLuongTonSauKhiBan()
        //{
        //    int luong_ton = 0;
        //    int luong_ban = 0;
        //    int.TryParse(txt_SoLuongTon.Text, out luong_ton);
        //    int.TryParse(txt_SoLuongBan.Text, out luong_ban);
        //    txt_SoLuongSauKhiBan.Text = (luong_ton - luong_ban).ToString();
        //}

        void TinhLuongTonSauKhiBan()
        {
            if (!String.IsNullOrWhiteSpace(txt_SoLuongTon.Text) && !String.IsNullOrWhiteSpace(txt_SoLuongBan.Text))
                txt_SoLuongSauKhiBan.Text = (int.Parse(txt_SoLuongTon.Text) - int.Parse(txt_SoLuongBan.Text)).ToString();
            else
                txt_SoLuongSauKhiBan.Text = "";
        }

        void LoadData()
        {
            cb_MaSach.DataSource = objS.getTable();
            cb_MaSach.DisplayMember = "MaSach";
            cb_MaSach.ValueMember = "MaSach";
            cb_MaSach.SelectedIndex = 1;
            cb_MaSach.SelectedIndex = 0;
            cb_MaKhachHang.DataSource = objKH.getTable();
            cb_MaKhachHang.DisplayMember = "MaKhachHang";
            cb_MaKhachHang.ValueMember = "MaKhachHang";
            cb_MaKhachHang.SelectedIndex = 1;
            cb_MaKhachHang.SelectedIndex = 0;
            txt_QĐ2.Text = bltThamSo.GetQD2B().ToString();
            txt_NoToiDa.Text = bltThamSo.GetQD2A().ToString();
            txt_TienTra.Text = "";
            txt_SoLuongBan.Text = "";
            lb_Ngay.Text = DateTime.Now.ToString("d", new CultureInfo("pt-BR"));
            dataGridView.Rows.Clear();
            TinhTongTien();
        }
    }
}
