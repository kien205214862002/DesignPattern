using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using System.Globalization;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Data;
using System.Linq;
using System.Text;

namespace CNPM
{
    class ShippingFee
    {
        private int distance;
        public ShippingFee(int distance) {
            this.distance = distance;
        }
        public int Calc()
        {
            return 100 * this.distance;
        }
    }
    class Fee
    {
        private int amount, value;
        public Fee(int value,int amount) {
            this.value = value;
            this.amount = amount;
                
                }
        public int Calc()
        {
            return this.amount * this.value;
        }
    }

    class facadeTinhTien
    {
        private ShippingFee objSF;
        private Fee objF;

        public int getTotal(int value = 0, int distance = 0, int amount = 0)
        {
            this.objF = new Fee(value, amount);
            this.objSF = new ShippingFee(distance);
            return objSF.Calc() + objF.Calc();
        }
    }
    public partial class PhieuNhapSach : Form
    {
        SachBLT bltSach = new SachBLT();
        ThamSoBLT bltThamSo = new ThamSoBLT();
        //Client của mẫu State
        NhapSachBLT bltNS = new NhapSachBLT(new DefaultNhapSachState());
        int check = 1;

        int TongTien = 0;
        
        public PhieuNhapSach()
        {
            InitializeComponent();
            lb_Ngay.Text =  DateTime.Now.ToString("d", new CultureInfo("pt-BR"));
            txt_QĐ1B.Text = (" ≤ " + bltThamSo.GetQD1B().ToString());
            txt_QĐ1A.Text = (" ≥ " + bltThamSo.GetQD1A().ToString());
            DataTable dt = bltSach.getTable();
            //dt.Columns.Add("FullName", typeof(string), "MaSach + ' - ' + TenSach");
            cb_MaSach.DataSource = dt;
            cb_MaSach.DisplayMember = "MaSach";
            cb_MaSach.ValueMember = "MaSach";
            cb_MaSach.TextChanged += (s, e) => cb_MaSach_on_TextChanged();
            cb_MaSach.SelectedIndex = 1;
            cb_MaSach.SelectedIndex = 0;
            panel.BackgroundImage = Gradient2D(panel.ClientRectangle, Color.LawnGreen, Color.LightSkyBlue, Color.GreenYellow, Color.Teal);
            btnThem.Click += (s, e) =>
            {
                if (check == 1)
                {
                    int so_luong_nhap = 0;
                    int so_luong_ton = 0;
                    if (String.IsNullOrWhiteSpace(txt_TenSach.Text) || !int.TryParse(txt_SoLuongTon.Text, out so_luong_ton))
                        MessageBox.Show("Mã sách không có trong cơ sở dữ liệu", "Thêm chi tiết nhập sách thất bại");
                    else if (!int.TryParse(txt_SoLuongNhap.Text, out so_luong_nhap) || so_luong_nhap < bltThamSo.GetQD1A())
                        MessageBox.Show("Phải có số lượng nhập phải lớn hơn " + bltThamSo.GetQD1A(), "Thêm chi tiết nhập sách thất bại");
                    else if (so_luong_ton > bltThamSo.GetQD1B())
                        MessageBox.Show("Số lượng tồn lớn hơn số lượng cần thiết để nhập", "Thêm chi tiết nhập sách thất bại");
                    else
                    {
                        bool add = true;
                        foreach (DataGridViewRow dr in dataGridView.Rows)
                            if (dr.Cells["MaSach"].Value.ToString() == cb_MaSach.Text)
                            {
                                dr.Cells["SoLuongNhap"].Value = txt_SoLuongNhap.Text;
                                add = false;
                                break;
                            }
                        if (add)
                        {
                            var index = dataGridView.Rows.Add();
                            dataGridView.Rows[index].Cells["MaSach"].Value = cb_MaSach.Text;
                            dataGridView.Rows[index].Cells["TenSach"].Value = txt_TenSach.Text;
                            dataGridView.Rows[index].Cells["SoLuongTon"].Value = txt_SoLuongTon.Text;
                            dataGridView.Rows[index].Cells["SoLuongNhap"].Value = txt_SoLuongNhap.Text;
                            dataGridView.Rows[index].Cells["DonGia"].Value = txt_DonGia.Text;
                        }

                        foreach (DataGridViewRow dr in dataGridView.Rows)
                        {
                            so_luong_nhap = Convert.ToInt32(dr.Cells["SoLuongNhap"].Value);
                            dr.Cells["ThanhTien"].Value = so_luong_nhap * Convert.ToInt32(dr.Cells["DonGia"].Value);
                        }
                        TinhTongTien();
                    }
                }
                else
                {
                    int so_luong_nhap = 0;
                    int so_luong_ton = 0;
                    if (String.IsNullOrWhiteSpace(txt_TenSach.Text) || !int.TryParse(txt_SoLuongTon.Text, out so_luong_ton))
                        MessageBox.Show("Mã sách không có trong cơ sở dữ liệu", "Thêm chi tiết nhập sách thất bại");
                    else if (!int.TryParse(txt_SoLuongNhap.Text, out so_luong_nhap) || so_luong_nhap < bltThamSo.GetQD2A())
                        MessageBox.Show("Phải có số lượng nhập phải lớn hơn " + bltThamSo.GetQD2A(), "Thêm chi tiết nhập sách thất bại");
                    else if (so_luong_ton > bltThamSo.GetQD2B())
                        MessageBox.Show("Số lượng tồn lớn hơn số lượng cần thiết để nhập", "Thêm chi tiết nhập sách thất bại");
                    else
                    {
                        bool add = true;
                        foreach (DataGridViewRow dr in dataGridView.Rows)
                            if (dr.Cells["MaSach"].Value.ToString() == cb_MaSach.Text)
                            {
                                dr.Cells["SoLuongNhap"].Value = txt_SoLuongNhap.Text;
                                add = false;
                                break;
                            }
                        if (add)
                        {
                            var index = dataGridView.Rows.Add();
                            dataGridView.Rows[index].Cells["MaSach"].Value = cb_MaSach.Text;
                            dataGridView.Rows[index].Cells["TenSach"].Value = txt_TenSach.Text;
                            dataGridView.Rows[index].Cells["SoLuongTon"].Value = txt_SoLuongTon.Text;
                            dataGridView.Rows[index].Cells["SoLuongNhap"].Value = txt_SoLuongNhap.Text;
                            dataGridView.Rows[index].Cells["DonGia"].Value = txt_DonGia.Text;
                        }

                        foreach (DataGridViewRow dr in dataGridView.Rows)
                        {
                            so_luong_nhap = Convert.ToInt32(dr.Cells["SoLuongNhap"].Value);
                            dr.Cells["ThanhTien"].Value = (new facadeTinhTien()).getTotal(Convert.ToInt32(dr.Cells["DonGia"].Value),15, so_luong_nhap);
                        }
                        TinhTongTien();
                    }
                }

            };
            btnXoa.Click += (s, e) =>
            {
                foreach (DataGridViewCell oneCell in dataGridView.SelectedCells)
                    if (oneCell.Selected && !dataGridView.Rows[oneCell.RowIndex].IsNewRow)
                        dataGridView.Rows.RemoveAt(oneCell.RowIndex);
                TinhTongTien();
            };
            btnLap.Click += (s, e) =>
            {
                List<ChiTietNhapSach> list = new List<ChiTietNhapSach>();
                for (int i = 0; i < dataGridView.Rows.Count; ++i)
                {
                    ChiTietNhapSach ctns = new ChiTietNhapSach();
                    ctns.MaSach = Convert.ToInt32(dataGridView.Rows[i].Cells[0].Value);
                    ctns.SoLuongNhap = Convert.ToInt32(dataGridView.Rows[i].Cells["SoLuongNhap"].Value);
                    list.Add(ctns);
                }
                if (list.Count < 1)
                    MessageBox.Show("Không có chi tiết nhập sách để thực hiện nhập sách", "Nhập sách thất bại", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else if (bltNS.Them(new NhapSach(TongTien), list))
                {
                    MessageBox.Show("Thành công", "", MessageBoxButtons.OK);
                    Close();
                }
            };
        }

        void TinhTongTien()
        {
            TongTien = 0;
            foreach (DataGridViewRow dr in dataGridView.Rows)
                TongTien += Convert.ToInt32(dr.Cells["ThanhTien"].Value);
            lb_TongTien.Text = String.Format("{0:n0}", TongTien);
        }

        void cb_MaSach_on_TextChanged()
        {
            try
            {
                Sach sach = bltSach.getSachbyID(Convert.ToInt32(cb_MaSach.Text));
                txt_TacGia.Text = sach.TacGia;
                txt_TheLoai.Text = sach.TheLoai;
                txt_TenSach.Text = sach.TenSach;
                txt_DonGia.Text = sach.DonGia.ToString();
                txt_SoLuongTon.Text = sach.SoLuongTon.ToString();
            }
            catch
            {
                txt_DonGia.Text = "";
                txt_TacGia.Text = "";
                txt_TheLoai.Text = "";
                txt_TenSach.Text = "";
                txt_SoLuongTon.Text = "";
            }
        }

        Bitmap Gradient2D(Rectangle r, Color c1, Color c2, Color c3, Color c4)
        {
            Bitmap bmp = new Bitmap(r.Width, r.Height);

            float delta12R = 1f * (c2.R - c1.R) / r.Height;
            float delta12G = 1f * (c2.G - c1.G) / r.Height;
            float delta12B = 1f * (c2.B - c1.B) / r.Height;
            float delta34R = 1f * (c4.R - c3.R) / r.Height;
            float delta34G = 1f * (c4.G - c3.G) / r.Height;
            float delta34B = 1f * (c4.B - c3.B) / r.Height;
            using (Graphics G = Graphics.FromImage(bmp))
                for (int y = 0; y < r.Height; y++)
                {
                    Color c12 = Color.FromArgb(255, c1.R + (int)(y * delta12R),
                          c1.G + (int)(y * delta12G), c1.B + (int)(y * delta12B));
                    Color c34 = Color.FromArgb(255, c3.R + (int)(y * delta34R),
                          c3.G + (int)(y * delta34G), c3.B + (int)(y * delta34B));
                    using (LinearGradientBrush lgBrush = new LinearGradientBrush(
                          new Rectangle(0, y, r.Width, 1), c12, c34, 0f))
                    { G.FillRectangle(lgBrush, 0, y, r.Width, 1); }
                }
            return bmp;
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            bltNS= new NhapSachBLT(new DefaultNhapSachState());
            check = 1;
            txt_QĐ1B.Text = (" ≤ " + bltThamSo.GetQD1B().ToString());
            txt_QĐ1A.Text = (" ≥ " + bltThamSo.GetQD1A().ToString());

        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            
            bltNS= new NhapSachBLT(new BackupNhapSachState());
            check = 2;
            txt_QĐ1B.Text = (" ≤ " + bltThamSo.GetQD2B().ToString());
            txt_QĐ1A.Text = (" ≥ " + bltThamSo.GetQD2A().ToString());
        }
    }
}
