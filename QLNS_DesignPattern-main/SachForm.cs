using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Xml;
using System.IO;

namespace CNPM
{
    public partial class SachForm : Form
    {
        SachBLT bltSach = new SachBLT();
       
        Sach dtoS = new Sach();
        int SoLuongToiThieu = 100;

        public SachForm()
        {
            InitializeComponent();
            txt_sua_TheLoai.KeyPress += (s, e) => { e.Handled = true; };
            txt_them_TheLoai.KeyPress += (s, e) => { e.Handled = true; };
            txt_tracuu_TheLoai.KeyPress += (s, e) => { e.Handled = true; };
            dgv_Sach.DataSource = bltSach.getTable();
            dgv_Sach.Columns[0].HeaderText = "Mã Sách";
            dgv_Sach.Columns[1].HeaderText = "Tên Sách";
            dgv_Sach.Columns[2].HeaderText = "Thể Loại";
            dgv_Sach.Columns[3].HeaderText = "Tác Giả";
            dgv_Sach.Columns[4].HeaderText = "Số Lượng Tồn";
            dgv_Sach.Columns[5].HeaderText = "Đơn Giá";
            foreach (DataGridViewColumn column in dgv_Sach.Columns)
            {
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
                column.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }
            dgv_Sach.SelectionChanged += (s, e) => showSelected();
            btnSua.Click += (s, e) =>
            {
                if (string.IsNullOrWhiteSpace(txt_sua_TenSach.Text) || string.IsNullOrWhiteSpace(txt_sua_TacGia.Text))
                    MessageBox.Show("Phải điền đầy đủ thông tin", "Sửa sách thất bại", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                {
                    dtoS.TacGia = txt_sua_TacGia.Text;
                    dtoS.TenSach = txt_sua_TenSach.Text;
                    dtoS.TheLoai = txt_sua_TheLoai.Text;
                    dtoS.DonGia = Convert.ToInt32(txt_sua_DonGia.Text);
                    dtoS.SoLuongTon = Convert.ToInt32(txt_sua_SoLuong.Text);
                    string maS = dtoS.MaSach.ToString();
                    if (bltSach.Sua(dtoS))
                    {
                        dgv_Sach.DataSource = bltSach.getTable();
                        foreach (DataGridViewRow row in dgv_Sach.Rows)
                            if (row.Cells["MaSach"].Value.ToString() == maS)
                                dgv_Sach.CurrentCell = dgv_Sach.Rows[row.Index].Cells[0];
                        showSelected();
                        MessageBox.Show("Sửa thành công");
                    }
                    else
                        MessageBox.Show("Sửa thất bại");
                }
            };
            btnTraCuu.Click += (s, e) =>
            {
                dtoS.TacGia = txt_tracuu_TacGia.Text;
                dtoS.TenSach = txt_tracuu_TenSach.Text;
                dtoS.TheLoai = txt_tracuu_TheLoai.Text;
                dgv_Sach.DataSource = bltSach.getTable(dtoS);
            };
            //btnThem.Click += (s, e) =>
            //{
            //    if (string.IsNullOrWhiteSpace(txt_them_TenSach.Text) || string.IsNullOrWhiteSpace(txt_them_TacGia.Text) || string.IsNullOrWhiteSpace(txt_them_DonGia.Text))
            //        MessageBox.Show("Phải điền đầy đủ thông tin", "Sửa sách thất bại", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    else
            //    {
            //        dtoS.TacGia = txt_them_TacGia.Text;
            //        dtoS.TenSach = txt_them_TenSach.Text;
            //        dtoS.TheLoai = txt_them_TheLoai.Text;
            //        dtoS.DonGia = Convert.ToInt32(txt_them_DonGia.Text);
            //        int ma_sach = bltSach.Them(dtoS);
            //        if (ma_sach > 0)
            //        {
            //            string maS = ma_sach.ToString();
            //            dgv_Sach.DataSource = bltSach.getTable();
            //            foreach (DataGridViewRow row in dgv_Sach.Rows)
            //                if (row.Cells["MaSach"].Value.ToString() == maS)
            //                    dgv_Sach.CurrentCell = dgv_Sach.Rows[row.Index].Cells[0];
            //            showSelected();
            //            MessageBox.Show("Thêm thành công");
            //            txt_them_TacGia.Text = "";
            //            txt_them_DonGia.Text = "";
            //            txt_them_TenSach.Text = "";
            //            txt_them_TheLoai.Text = "";
            //        }
            //        else
            //            MessageBox.Show("Thêm thất bại");
            //    }
            //};
            btnThem.Click += (s, e) =>
            {
                if (string.IsNullOrWhiteSpace(txt_them_TenSach.Text) || string.IsNullOrWhiteSpace(txt_them_TacGia.Text) || string.IsNullOrWhiteSpace(txt_them_DonGia.Text))
                    MessageBox.Show("Phải điền đầy đủ thông tin", "Sửa sách thất bại", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                {
                    // Tạo đối tượng sách
                    Sach sach = new SachBuilder().SetTenSach(txt_them_TenSach.Text)
                               .SetTacGia(txt_them_TacGia.Text)
                               .SetTheLoai(txt_them_TheLoai.Text)
                               .SetDonGia(Convert.ToInt32(txt_them_DonGia.Text)).Build();

                    int ma_sach = bltSach.Them(sach);
                    if (ma_sach > 0)
                    {
                        string maS = ma_sach.ToString();
                        dgv_Sach.DataSource = bltSach.getTable();
                        foreach (DataGridViewRow row in dgv_Sach.Rows)
                            if (row.Cells["MaSach"].Value.ToString() == maS)
                                dgv_Sach.CurrentCell = dgv_Sach.Rows[row.Index].Cells[0];
                        showSelected();
                        MessageBox.Show("Thêm thành công");
                        txt_them_TacGia.Text = "";
                        txt_them_DonGia.Text = "";
                        txt_them_TenSach.Text = "";
                        txt_them_TheLoai.Text = "";
                    }
                    else
                        MessageBox.Show("Thêm thất bại");
                }
            };
            btn_filter.Click += (s, e) =>
            {
                int.TryParse(txt_filter_SoLuong.Text, out SoLuongToiThieu);
                dgv_Sach.DataSource = bltSach.getTable();
                for (int i = dgv_Sach.Rows.Count - 1; i >= 0; i--)
                {
                    if ((bltSach.getSachbyID(Convert.ToInt32(dgv_Sach.Rows[i].Cells[0].Value))).SoLuongTon < SoLuongToiThieu)
                        foreach (DataGridViewCell cell in dgv_Sach.Rows[i].Cells)
                            cell.Style.ForeColor = Color.Red;
                    else
                        dgv_Sach.Rows.RemoveAt(i);
                }
                tabControl.SelectedIndex = 0;
            };
            txt_filter_SoLuong.Text = SoLuongToiThieu.ToString();

            Load();

        }
        
         private void Load()
        {
           
        }
        private void showSelected()
        {
            try
            {
                dtoS.MaSach = Convert.ToInt32(dgv_Sach.CurrentRow.Cells[0].Value);
                txt_sua_TenSach.Text = dgv_Sach.CurrentRow.Cells[1].Value.ToString();
                txt_sua_TheLoai.Text = dgv_Sach.CurrentRow.Cells[2].Value.ToString();
                txt_sua_TacGia.Text = dgv_Sach.CurrentRow.Cells[3].Value.ToString();
                txt_sua_SoLuong.Text = dgv_Sach.CurrentRow.Cells[4].Value.ToString();
                txt_sua_DonGia.Text = dgv_Sach.CurrentRow.Cells[5].Value.ToString();
            }
            catch { 

            }
        }
    }
}