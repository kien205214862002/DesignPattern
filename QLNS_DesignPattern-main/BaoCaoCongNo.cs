using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Data;
using System.Text;
using System.Linq;

namespace CNPM
{
    public partial class BaoCaoCongNo : Form
    {
        BaoCaoCongNoBLT blt_BaoCao = new BaoCaoCongNoBLT();

        public BaoCaoCongNo()
        {
            InitializeComponent();
            cb_Nam.DataSource = Enumerable.Range(DateTime.MinValue.Year, DateTime.MaxValue.Year - DateTime.MinValue.Year).ToList();
            cb_Thang.Text = DateTime.Now.Month.ToString();
            cb_Nam.Text = DateTime.Now.Year.ToString();
            cb_Nam.KeyPress += (s, e) => { e.Handled = true; };
            cb_Thang.KeyPress += (s, e) => { e.Handled = true; };
            cb_Nam.TextChanged += (s, e) => LoadData();
            cb_Thang.TextChanged += (s, e) => LoadData();
            cb_Nam.DropDownHeight = cb_Nam.Font.Height * 15;
            LoadData();
            dgv.ColumnHeadersDefaultCellStyle.Font = new Font("Microsoft Sans Serif", 10.5F, FontStyle.Regular);
            panel.Paint += (s, e) =>
            {
                LinearGradientBrush linearGradientBrush = new LinearGradientBrush(panel.ClientRectangle, Color.Red, Color.Yellow, 80F);
                ColorBlend cblend = new ColorBlend(3);
                cblend.Colors = new Color[3] { BackColor, BackColor, Color.MediumVioletRed };
                cblend.Positions = new float[3] { 0f, 0.6f, 1f };
                linearGradientBrush.InterpolationColors = cblend;
                e.Graphics.FillRectangle(linearGradientBrush, panel.ClientRectangle);
            };
        }

        void LoadData()
        {
            try
            {
                DataTable dt = blt_BaoCao.getTable(new DateTime(int.Parse(cb_Nam.Text), int.Parse(cb_Thang.Text), 1));
                dt.Columns.Add("NoDauThang", typeof(int), "NoCuoiThang - PhatSinh");
                dgv.DataSource = dt;
                dgv.Columns[0].HeaderText = "Mã khách hàng";
                dgv.Columns[1].HeaderText = "Tên khách hàng";
                dgv.Columns[2].HeaderText = "Phát sinh";
                dgv.Columns[3].HeaderText = "Nợ cuối Tháng";
                dgv.Columns[4].HeaderText = "Nợ đầu tháng";
                foreach (DataGridViewColumn column in dgv.Columns)
                    column.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                dgv.Columns["NoDauThang"].DisplayIndex = 2;
            }
            catch { }
        }
    }
}
