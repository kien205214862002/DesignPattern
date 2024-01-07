using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;

namespace CNPM
{
    public interface IObserver
    {
        void Notify(string message);
    }


    // Định nghĩa giao diện IObservable
    public interface IObservable
    {
        void Attach(IObserver observer);
        void Detach(IObserver observer);
        void Notice(string message);
    }

    // Lớp ConcreteObservable triển khai giao diện IObservable
    public class Operation : IObservable
    {
        private string message;
        private List<IObserver> _observers = new List<IObserver>();

        public string Message
        {
            get { return message; }
            set
            {
                if (message != value)
                {
                    message = value;
                    Notice(message);
                }
            }
        }

        public void Attach(IObserver observer)
        {
            _observers.Add(observer);
        }

        public void Detach(IObserver observer)
        {
            _observers.Remove(observer);
        }

        public void Notice(string message)
        {
            foreach (IObserver observer in _observers)
            {
                observer.Notify(message);
            }
        }
    }

    public class ShowMessage : IObserver
    {
        public void Notify(string message)
        {
            MessageBox.Show($"Thông báo từ hệ thống: {message}");
        }
    }
    public partial class KhachHangForm : Form
    {
        HoaDonBLT objHD = new HoaDonBLT();
        KhachHangBLT objKH = new KhachHangBLT();
        KhachHang dtoKH = new KhachHang();

          // Code thêm vào

   



        //-----------------------------------------------------------------------//

        private void CusTomGroupBoxPaint(object sender, PaintEventArgs e, int width = 2, Color? color = null)
        {
            color = color ?? Color.Gray;
            Graphics gfx = e.Graphics;
            GroupBox gb = (sender as GroupBox);
            Pen p = new Pen((Color)color, width);
            gfx.DrawLine(new Pen(p.Color, p.Width + 1), 0, 8, 0, e.ClipRectangle.Height - 2);
            gfx.DrawLine(p, 0, 8, 10, 8);
            gfx.DrawLine(p, gfx.MeasureString(gb.Text, gb.Font).Width, 8, e.ClipRectangle.Width - 2, 8);
            gfx.DrawLine(p, e.ClipRectangle.Width - 2, 8, e.ClipRectangle.Width - 2, e.ClipRectangle.Height - 2);
            gfx.DrawLine(p, e.ClipRectangle.Width - 2, e.ClipRectangle.Height - 2, 0, e.ClipRectangle.Height - 2);
        }

        public KhachHangForm()
        {
            InitializeComponent();

            Operation notifyTracker= new Operation();

            ShowMessage observer= new ShowMessage();

            notifyTracker.Attach(observer);


            
            gb_add.Paint += (s, e) => CusTomGroupBoxPaint(s, e);
            gb_info.Paint += (s, e) => CusTomGroupBoxPaint(s, e);
            gb_filter.Paint += (s, e) => CusTomGroupBoxPaint(s, e);
            rbtn_tracuu_ten.CheckedChanged += (s, e) =>
            {
                if (rbtn_tracuu_ten.Checked)
                {
                    txt_filter_HoTen.Enabled = true;
                    txt_filter_DienThoai.Enabled = false;
                    txt_filter_HoTen.Focus();
                }
            };
            rbtn_tracuu_dt.CheckedChanged += (s, e) =>
            {
                if (rbtn_tracuu_dt.Checked)
                {
                    txt_filter_HoTen.Enabled = false;
                    txt_filter_DienThoai.Enabled = true;
                    txt_filter_DienThoai.Focus();
                }
            };
            rbtn_tracuu_ten.Checked = true;
            btnSua.Click += (s, e) =>
            {
                if (string.IsNullOrWhiteSpace(txt_info_HoTen.Text))
                    notifyTracker.Notice("Sửa thất bại");
                else
                {
                    dtoKH.TenKhachHang = txt_info_HoTen.Text.Trim();
                    dtoKH.Email = txt_info_Email.Text.Trim();
                    dtoKH.DiaChi = txt_info_DiaChi.Text.Trim();
                    dtoKH.DienThoai = txt_info_DienThoai.Text.Trim();
                    string maKH = dtoKH.MaKhachHang.ToString();
                    if (objKH.Sua(dtoKH))
                    {
                        dgv_KhachHang_info.DataSource = objKH.getTable();
                        foreach (DataGridViewRow row in dgv_KhachHang_info.Rows)
                            if (row.Cells["MaKhachHang"].Value.ToString() == maKH)
                                dgv_KhachHang_info.CurrentCell = dgv_KhachHang_info.Rows[row.Index].Cells[0];
                       notifyTracker.Notice("Sửa thành công");
                        showSelected();
                    }
                    else
                        notifyTracker.Notice("Sửa thất bại");
                }
            };
            btn_add.Click += (s, e) =>
            {
                if (string.IsNullOrWhiteSpace(txt_add_HoTen.Text))
                    notifyTracker.Notice("Thêm thất bại");
                else
                {
                    dtoKH.TenKhachHang = txt_add_HoTen.Text.Trim();
                    dtoKH.Email = txt_add_Email.Text.Trim();
                    dtoKH.DiaChi = txt_add_DiaChi.Text.Trim();
                    dtoKH.DienThoai = txt_add_DienThoai.Text.Trim();
                    if (objKH.Them(dtoKH))
                    {
                        dgv_KhachHang_info.DataSource = objKH.getTable();
                        notifyTracker.Notice("Thêm thành công");
                        txt_add_HoTen.Text = "";
                        txt_add_Email.Text = "";
                        txt_add_DiaChi.Text = "";
                        txt_add_DienThoai.Text = "";
                    }
                    else
                       notifyTracker.Notice("Thêm thất bại");
                }
            };
            btn_filter.Click += (s, e) =>
            {
                KhachHang khach_hang = new KhachHang();
                if (rbtn_tracuu_ten.Checked)
                    khach_hang.TenKhachHang = txt_filter_HoTen.Text;
                if (rbtn_tracuu_dt.Checked)
                    khach_hang.DienThoai = txt_filter_DienThoai.Text;
                dgv_KhachHang_info.DataSource = objKH.getTable(khach_hang);
            };
            dgv_KhachHang_info.DataSource = objKH.getTable();
            dgv_KhachHang_info.Columns[0].HeaderText = "Mã Khách Hàng";
            dgv_KhachHang_info.Columns[1].HeaderText = "Tên Khách Hàng";
            dgv_KhachHang_info.Columns[2].HeaderText = "Số Tiền Nợ";
            dgv_KhachHang_info.Columns[3].HeaderText = "Địa Chỉ";
            dgv_KhachHang_info.Columns[4].HeaderText = "Điện Thoại";
            dgv_KhachHang_info.MultiSelect = false;
            dgv_KhachHang_info.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            foreach (DataGridViewColumn column in dgv_KhachHang_info.Columns)
            {
                //column.SortMode = DataGridViewColumnSortMode.NotSortable;
                column.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }
            dgv_KhachHang_info.SelectionChanged += (s, e) => showSelected();
            dgv_KhachHang_HoaDon.DefaultCellStyle.Font = new Font(dgv_KhachHang_HoaDon.DefaultCellStyle.Font.Name, 9);
            dgv_KhachHang_HoaDon.ColumnHeadersDefaultCellStyle.Font = new Font(dgv_KhachHang_HoaDon.ColumnHeadersDefaultCellStyle.Font.Name, 8, FontStyle.Bold);
        }

        private void showSelected()
        {
            try
            {
                dtoKH.MaKhachHang = Convert.ToInt32(dgv_KhachHang_info.CurrentRow.Cells[0].Value);
                txt_info_HoTen.Text = Convert.ToString(dgv_KhachHang_info.CurrentRow.Cells[1].Value);
                txt_info_DiaChi.Text = Convert.ToString(dgv_KhachHang_info.CurrentRow.Cells[3].Value);
                txt_info_DienThoai.Text = Convert.ToString(dgv_KhachHang_info.CurrentRow.Cells[4].Value);
                txt_info_Email.Text = Convert.ToString(dgv_KhachHang_info.CurrentRow.Cells[5].Value);
                dgv_KhachHang_HoaDon.DataSource = objHD.getTable(dtoKH.MaKhachHang);
                dgv_KhachHang_HoaDon.Columns[0].HeaderText = "Mã Hóa Đơn";
                dgv_KhachHang_HoaDon.Columns[1].Visible = false;
                dgv_KhachHang_HoaDon.Columns[2].HeaderText = "Ngày Lập";
                dgv_KhachHang_HoaDon.Columns[3].HeaderText = "Trị Giá";
                dgv_KhachHang_HoaDon.Columns[4].HeaderText = "Số Tiềm Trả";
                foreach (DataGridViewColumn column in dgv_KhachHang_HoaDon.Columns)
                    column.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }catch{
            }
        }

        private void btn_add_Click(object sender, EventArgs e)
        {

        }
    }
}
