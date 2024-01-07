using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Windows.Forms;
using System.Reflection;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;

namespace CNPM
{
    partial class PhieuThuTien : Form
    {
        KhachHangBLT blt_KhachHang = new KhachHangBLT();
        ThuTienBLT blt_ThuTien = new ThuTienBLT();
        ThamSoBLT blt_ThamSo = new ThamSoBLT();

        public PhieuThuTien()
        {
            InitializeComponent();
            lb_Ngay.Text = DateTime.Now.ToString("d", new CultureInfo("pt-BR"));
            panel.Paint += (s, e) =>
            {
                LinearGradientBrush linearGradientBrush = new LinearGradientBrush(panel.ClientRectangle, Color.Red, Color.Yellow, 60F);
                ColorBlend cblend = new ColorBlend(3);
                cblend.Colors = new Color[3] { Color.LightGreen, Color.Khaki, Color.Cyan };
                cblend.Positions = new float[3] { 0f, 0.9f, 1f };
                linearGradientBrush.InterpolationColors = cblend;
                e.Graphics.FillRectangle(linearGradientBrush, panel.ClientRectangle);
            };
            cb_MaKhachHang.TextChanged += (s, e) => cb_MaKhachHang_on_TextChanged();
            cb_MaKhachHang.DataSource = blt_KhachHang.getTable();
            cb_MaKhachHang.DisplayMember = "MaKhachHang";
            cb_MaKhachHang.ValueMember = "MaKhachHang";
            cb_MaKhachHang.SelectedIndex = 1;
            cb_MaKhachHang.SelectedIndex = 0;
            txt_SoTienNo.TextChanged += (s, e) => TinhNoSauThu();
            txt_SoTienThu.TextChanged += (s, e) => TinhNoSauThu();
            if (blt_ThamSo.GetQD4())
            {
                lb_QuyDinh.Text = "Có thể thu quá số tiền nợ";
                lb_QuyDinh.ForeColor = Color.Green;
            }
            else
            {
                lb_QuyDinh.Text = "Không được thu quá số tiền nợ";
                lb_QuyDinh.ForeColor = Color.Red;
            }
            btn.Click += (s, e) =>
            {
                int tien_no = 0;
                int tien_thu = 0;
                if(!int.TryParse(txt_SoTienNo.Text, out tien_no))
                    MessageBox.Show("Mã khách hàng không có trong cơ sở dữ liệu", "Lập phiếu thu tiền thất bại");
                else if(!int.TryParse(txt_SoTienThu.Text, out tien_thu) || tien_thu <= 0)
                    MessageBox.Show("Số tiền thu phải lớn hơn 0", "Lập phiếu thu tiền thất bại");
                else if (!blt_ThamSo.GetQD4() && (tien_thu > tien_no))
                    MessageBox.Show("Đang áp dụng quy định 4 - Tiền thu không được quá số tiền nợ", "Lập phiếu thu tiền thất bại");
                else
                {
                    if (blt_ThuTien.Them(new ThuTien(int.Parse(cb_MaKhachHang.Text), tien_thu)))
                    {
                        MessageBox.Show("Lập phiếu thu tiền thành công");
                        Close();
                    }
                    else
                        MessageBox.Show("Lập phiếu thu tiền thất bại");
                }
            };
        }

        void TinhNoSauThu()
        {
            int tien_no = 0;
            int tien_thu = 0;
            int.TryParse(txt_SoTienNo.Text, out tien_no);
            int.TryParse(txt_SoTienThu.Text, out tien_thu);
            txt_NoSauThu.Text = (tien_no - tien_thu).ToString();
        }

        void cb_MaKhachHang_on_TextChanged()
        {
            try
            {
                KhachHang khach_hang = blt_KhachHang.getKhachHangbyID(Convert.ToInt32(cb_MaKhachHang.Text));
                txt_TenKhachHang.Text = khach_hang.TenKhachHang;
                txt_DienThoai.Text = khach_hang.DienThoai;
                txt_DiaChi.Text = khach_hang.DiaChi;
                txt_SoTienNo.Text = khach_hang.SoTienNo.ToString();
            }
            catch
            {
                txt_TenKhachHang.Text = "";
                txt_DienThoai.Text = "";
                txt_DiaChi.Text = "";
                txt_SoTienNo.Text = "";
            }
        }
    }
}
