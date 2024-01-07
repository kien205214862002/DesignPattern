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
    public partial class QuiDinh : Form
    {
        ThamSoBLT objTS = new ThamSoBLT();

        public QuiDinh()
        {
            InitializeComponent();
            foreach (Control gb in this.Controls)
            {
                if (gb is GroupBox)
                {
                    foreach (Control tb in gb.Controls)
                    {
                        if (tb is TextBox)
                        {
                            tb.KeyPress += (s, e) =>
                            {
                                if (!Char.IsDigit(e.KeyChar) || e.KeyChar == 46)
                                    e.Handled = true;
                            };
                        }
                    }
                }
            }
            txt_QD1A.Text = objTS.GetQD1A().ToString();
            txt_QD1B.Text = objTS.GetQD1B().ToString();
            txt_QD2A.Text = objTS.GetQD2A().ToString();
            txt_QD2B.Text = objTS.GetQD2B().ToString();
            checkBox1.Checked = objTS.GetQD4();
            button2.Click += (s, e) => Close();
            button1.Click += (s, e) =>
            {
                int temp = 0, valid = 0;
                foreach (GroupBox gb in this.Controls.OfType<GroupBox>())
                    foreach (TextBox b in gb.Controls.OfType<TextBox>())
                        if (!int.TryParse(b.Text, out temp))
                            valid = 1;
                if (valid == 1)
                {
                    MessageBox.Show("Thông tin nhập không hợp lệ", "", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    return;
                }
                ThamSo thamso = new ThamSo();
                thamso.QD1A = int.Parse(txt_QD1A.Text);
                thamso.QD1B = int.Parse(txt_QD1B.Text);
                thamso.QD2A = int.Parse(txt_QD2A.Text);
                thamso.QD2B = int.Parse(txt_QD2B.Text);
                thamso.QD4 = checkBox1.Checked;
                objTS.Save(thamso);
                Close();
                DialogResult = DialogResult.OK;
            };
        }
    }
}
