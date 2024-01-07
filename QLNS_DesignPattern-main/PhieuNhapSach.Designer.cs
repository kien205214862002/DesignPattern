namespace CNPM
{
    partial class PhieuNhapSach
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label1 = new System.Windows.Forms.Label();
            this.btnLap = new System.Windows.Forms.Button();
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.MaSach = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TenSach = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SoLuongTon = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SoLuongNhap = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DonGia = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ThanhTien = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lb_Ngay = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lb_TongTien = new System.Windows.Forms.Label();
            this.panel = new System.Windows.Forms.Panel();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.gb = new CNPM.BorderBox();
            this.txt_QĐ1A = new CNPM.NumberInput();
            this.txt_QĐ1B = new CNPM.NumberInput();
            this.txt_DonGia = new CNPM.NumberInput();
            this.txt_SoLuongTon = new CNPM.NumberInput();
            this.txt_TheLoai = new System.Windows.Forms.TextBox();
            this.txt_TacGia = new System.Windows.Forms.TextBox();
            this.txt_TenSach = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.glowBox7 = new CNPM.GlowBox();
            this.cb_MaSach = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.glowBox2 = new CNPM.GlowBox();
            this.txt_SoLuongNhap = new CNPM.NumberInput();
            this.btnThem = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.btnXoa = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.panel.SuspendLayout();
            this.gb.SuspendLayout();
            this.glowBox7.SuspendLayout();
            this.glowBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(40, 234);
            this.label1.Margin = new System.Windows.Forms.Padding(0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(172, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "Ngày Lập Phiếu:";
            // 
            // btnLap
            // 
            this.btnLap.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnLap.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLap.ForeColor = System.Drawing.Color.Black;
            this.btnLap.Location = new System.Drawing.Point(100, 326);
            this.btnLap.Margin = new System.Windows.Forms.Padding(0);
            this.btnLap.Name = "btnLap";
            this.btnLap.Size = new System.Drawing.Size(220, 62);
            this.btnLap.TabIndex = 6;
            this.btnLap.Text = "Lập phiếu";
            this.btnLap.UseVisualStyleBackColor = false;
            // 
            // dataGridView
            // 
            this.dataGridView.AllowUserToAddRows = false;
            this.dataGridView.AllowUserToDeleteRows = false;
            this.dataGridView.AllowUserToResizeColumns = false;
            this.dataGridView.AllowUserToResizeRows = false;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.MaSach,
            this.TenSach,
            this.SoLuongTon,
            this.SoLuongNhap,
            this.DonGia,
            this.ThanhTien});
            this.dataGridView.Location = new System.Drawing.Point(13, 425);
            this.dataGridView.Margin = new System.Windows.Forms.Padding(0);
            this.dataGridView.MultiSelect = false;
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.ReadOnly = true;
            this.dataGridView.RowHeadersWidth = 51;
            this.dataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView.Size = new System.Drawing.Size(1040, 308);
            this.dataGridView.TabIndex = 10;
            // 
            // MaSach
            // 
            this.MaSach.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.MaSach.HeaderText = "Mã Sách";
            this.MaSach.MinimumWidth = 6;
            this.MaSach.Name = "MaSach";
            this.MaSach.ReadOnly = true;
            this.MaSach.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.MaSach.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // TenSach
            // 
            this.TenSach.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.TenSach.HeaderText = "Tên Sách";
            this.TenSach.MinimumWidth = 6;
            this.TenSach.Name = "TenSach";
            this.TenSach.ReadOnly = true;
            this.TenSach.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.TenSach.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // SoLuongTon
            // 
            this.SoLuongTon.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.SoLuongTon.HeaderText = "Số Lượng Tồn";
            this.SoLuongTon.MinimumWidth = 6;
            this.SoLuongTon.Name = "SoLuongTon";
            this.SoLuongTon.ReadOnly = true;
            this.SoLuongTon.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.SoLuongTon.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // SoLuongNhap
            // 
            this.SoLuongNhap.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.SoLuongNhap.HeaderText = "Số Lượng Nhập";
            this.SoLuongNhap.MinimumWidth = 6;
            this.SoLuongNhap.Name = "SoLuongNhap";
            this.SoLuongNhap.ReadOnly = true;
            this.SoLuongNhap.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.SoLuongNhap.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // DonGia
            // 
            this.DonGia.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.DonGia.HeaderText = "Đơn Giá";
            this.DonGia.MinimumWidth = 6;
            this.DonGia.Name = "DonGia";
            this.DonGia.ReadOnly = true;
            this.DonGia.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.DonGia.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // ThanhTien
            // 
            this.ThanhTien.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ThanhTien.HeaderText = "Thành Tiền";
            this.ThanhTien.MinimumWidth = 6;
            this.ThanhTien.Name = "ThanhTien";
            this.ThanhTien.ReadOnly = true;
            this.ThanhTien.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.ThanhTien.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // lb_Ngay
            // 
            this.lb_Ngay.AutoSize = true;
            this.lb_Ngay.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_Ngay.Location = new System.Drawing.Point(240, 234);
            this.lb_Ngay.Margin = new System.Windows.Forms.Padding(0);
            this.lb_Ngay.Name = "lb_Ngay";
            this.lb_Ngay.Size = new System.Drawing.Size(53, 25);
            this.lb_Ngay.TabIndex = 11;
            this.lb_Ngay.Text = "label";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(40, 277);
            this.label3.Margin = new System.Windows.Forms.Padding(0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(122, 25);
            this.label3.TabIndex = 2;
            this.label3.Text = "Tổng cộng:";
            // 
            // lb_TongTien
            // 
            this.lb_TongTien.AutoSize = true;
            this.lb_TongTien.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_TongTien.Location = new System.Drawing.Point(240, 277);
            this.lb_TongTien.Margin = new System.Windows.Forms.Padding(0);
            this.lb_TongTien.Name = "lb_TongTien";
            this.lb_TongTien.Size = new System.Drawing.Size(23, 25);
            this.lb_TongTien.TabIndex = 13;
            this.lb_TongTien.Text = "0";
            // 
            // panel
            // 
            this.panel.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.panel.Controls.Add(this.label12);
            this.panel.Controls.Add(this.label11);
            this.panel.Location = new System.Drawing.Point(33, 25);
            this.panel.Margin = new System.Windows.Forms.Padding(0);
            this.panel.Name = "panel";
            this.panel.Size = new System.Drawing.Size(353, 185);
            this.panel.TabIndex = 15;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.BackColor = System.Drawing.Color.Transparent;
            this.label12.Font = new System.Drawing.Font("Times New Roman", 27.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.Color.Red;
            this.label12.Location = new System.Drawing.Point(107, 86);
            this.label12.Margin = new System.Windows.Forms.Padding(0);
            this.label12.MaximumSize = new System.Drawing.Size(267, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(223, 52);
            this.label12.TabIndex = 16;
            this.label12.Text = "nhập sách";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.BackColor = System.Drawing.Color.Transparent;
            this.label11.Font = new System.Drawing.Font("Times New Roman", 27.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.Red;
            this.label11.Location = new System.Drawing.Point(7, 31);
            this.label11.Margin = new System.Windows.Forms.Padding(0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(221, 52);
            this.label11.TabIndex = 0;
            this.label11.Text = "Lập phiếu";
            // 
            // gb
            // 
            this.gb.BorderColor = System.Drawing.Color.Gray;
            this.gb.BorderWidth = 2F;
            this.gb.Controls.Add(this.txt_QĐ1A);
            this.gb.Controls.Add(this.txt_QĐ1B);
            this.gb.Controls.Add(this.txt_DonGia);
            this.gb.Controls.Add(this.txt_SoLuongTon);
            this.gb.Controls.Add(this.txt_TheLoai);
            this.gb.Controls.Add(this.txt_TacGia);
            this.gb.Controls.Add(this.txt_TenSach);
            this.gb.Controls.Add(this.label4);
            this.gb.Controls.Add(this.glowBox7);
            this.gb.Controls.Add(this.label6);
            this.gb.Controls.Add(this.label10);
            this.gb.Controls.Add(this.label9);
            this.gb.Controls.Add(this.label5);
            this.gb.Controls.Add(this.label2);
            this.gb.Controls.Add(this.glowBox2);
            this.gb.Controls.Add(this.btnThem);
            this.gb.Controls.Add(this.label8);
            this.gb.Controls.Add(this.btnXoa);
            this.gb.Controls.Add(this.label7);
            this.gb.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.75F);
            this.gb.Location = new System.Drawing.Point(420, 12);
            this.gb.Margin = new System.Windows.Forms.Padding(0);
            this.gb.Name = "gb";
            this.gb.Padding = new System.Windows.Forms.Padding(0);
            this.gb.Size = new System.Drawing.Size(627, 400);
            this.gb.TabIndex = 16;
            this.gb.TabStop = false;
            this.gb.Text = "Chi tiết nhập sách";
            // 
            // txt_QĐ1A
            // 
            this.txt_QĐ1A.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.txt_QĐ1A.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.txt_QĐ1A.ForeColor = System.Drawing.Color.Green;
            this.txt_QĐ1A.Location = new System.Drawing.Point(493, 247);
            this.txt_QĐ1A.Margin = new System.Windows.Forms.Padding(0);
            this.txt_QĐ1A.Name = "txt_QĐ1A";
            this.txt_QĐ1A.ReadOnly = true;
            this.txt_QĐ1A.Size = new System.Drawing.Size(105, 29);
            this.txt_QĐ1A.TabIndex = 45;
            // 
            // txt_QĐ1B
            // 
            this.txt_QĐ1B.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.txt_QĐ1B.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.txt_QĐ1B.ForeColor = System.Drawing.Color.Green;
            this.txt_QĐ1B.Location = new System.Drawing.Point(493, 204);
            this.txt_QĐ1B.Margin = new System.Windows.Forms.Padding(0);
            this.txt_QĐ1B.Name = "txt_QĐ1B";
            this.txt_QĐ1B.ReadOnly = true;
            this.txt_QĐ1B.Size = new System.Drawing.Size(105, 29);
            this.txt_QĐ1B.TabIndex = 44;
            // 
            // txt_DonGia
            // 
            this.txt_DonGia.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.txt_DonGia.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.txt_DonGia.ForeColor = System.Drawing.Color.Firebrick;
            this.txt_DonGia.Location = new System.Drawing.Point(187, 290);
            this.txt_DonGia.Margin = new System.Windows.Forms.Padding(0);
            this.txt_DonGia.Name = "txt_DonGia";
            this.txt_DonGia.ReadOnly = true;
            this.txt_DonGia.Size = new System.Drawing.Size(359, 29);
            this.txt_DonGia.TabIndex = 0;
            // 
            // txt_SoLuongTon
            // 
            this.txt_SoLuongTon.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.txt_SoLuongTon.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.txt_SoLuongTon.ForeColor = System.Drawing.Color.Firebrick;
            this.txt_SoLuongTon.Location = new System.Drawing.Point(187, 204);
            this.txt_SoLuongTon.Margin = new System.Windows.Forms.Padding(0);
            this.txt_SoLuongTon.Name = "txt_SoLuongTon";
            this.txt_SoLuongTon.ReadOnly = true;
            this.txt_SoLuongTon.Size = new System.Drawing.Size(199, 29);
            this.txt_SoLuongTon.TabIndex = 0;
            // 
            // txt_TheLoai
            // 
            this.txt_TheLoai.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.txt_TheLoai.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.txt_TheLoai.ForeColor = System.Drawing.Color.Firebrick;
            this.txt_TheLoai.Location = new System.Drawing.Point(187, 161);
            this.txt_TheLoai.Margin = new System.Windows.Forms.Padding(0);
            this.txt_TheLoai.Name = "txt_TheLoai";
            this.txt_TheLoai.ReadOnly = true;
            this.txt_TheLoai.Size = new System.Drawing.Size(359, 29);
            this.txt_TheLoai.TabIndex = 0;
            // 
            // txt_TacGia
            // 
            this.txt_TacGia.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.txt_TacGia.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.txt_TacGia.ForeColor = System.Drawing.Color.Firebrick;
            this.txt_TacGia.Location = new System.Drawing.Point(187, 118);
            this.txt_TacGia.Margin = new System.Windows.Forms.Padding(0);
            this.txt_TacGia.Name = "txt_TacGia";
            this.txt_TacGia.ReadOnly = true;
            this.txt_TacGia.Size = new System.Drawing.Size(359, 29);
            this.txt_TacGia.TabIndex = 2;
            // 
            // txt_TenSach
            // 
            this.txt_TenSach.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.txt_TenSach.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_TenSach.ForeColor = System.Drawing.Color.Firebrick;
            this.txt_TenSach.Location = new System.Drawing.Point(187, 75);
            this.txt_TenSach.Margin = new System.Windows.Forms.Padding(0);
            this.txt_TenSach.Name = "txt_TenSach";
            this.txt_TenSach.ReadOnly = true;
            this.txt_TenSach.Size = new System.Drawing.Size(359, 29);
            this.txt_TenSach.TabIndex = 2;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(393, 209);
            this.label4.Margin = new System.Windows.Forms.Padding(0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(89, 20);
            this.label4.TabIndex = 43;
            this.label4.Text = "Quy định:";
            // 
            // glowBox7
            // 
            this.glowBox7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.glowBox7.Controls.Add(this.cb_MaSach);
            this.glowBox7.Cursor = System.Windows.Forms.Cursors.Default;
            this.glowBox7.GlowColor = System.Drawing.Color.PowderBlue;
            this.glowBox7.GlowOn = false;
            this.glowBox7.Location = new System.Drawing.Point(180, 26);
            this.glowBox7.Margin = new System.Windows.Forms.Padding(0);
            this.glowBox7.Name = "glowBox7";
            this.glowBox7.Size = new System.Drawing.Size(209, 42);
            this.glowBox7.TabIndex = 42;
            // 
            // cb_MaSach
            // 
            this.cb_MaSach.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.cb_MaSach.FormattingEnabled = true;
            this.cb_MaSach.Location = new System.Drawing.Point(5, 5);
            this.cb_MaSach.Margin = new System.Windows.Forms.Padding(0);
            this.cb_MaSach.Name = "cb_MaSach";
            this.cb_MaSach.Size = new System.Drawing.Size(199, 32);
            this.cb_MaSach.TabIndex = 0;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(36, 37);
            this.label6.Margin = new System.Windows.Forms.Padding(0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(132, 20);
            this.label6.TabIndex = 41;
            this.label6.Text = "Mã sách nhập:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(88, 166);
            this.label10.Margin = new System.Windows.Forms.Padding(0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(82, 20);
            this.label10.TabIndex = 40;
            this.label10.Text = "Thể loại:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(93, 123);
            this.label9.Margin = new System.Windows.Forms.Padding(0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(77, 20);
            this.label9.TabIndex = 39;
            this.label9.Text = "Tác giả:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(93, 295);
            this.label5.Margin = new System.Windows.Forms.Padding(0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(79, 20);
            this.label5.TabIndex = 36;
            this.label5.Text = "Đơn giá:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(49, 209);
            this.label2.Margin = new System.Windows.Forms.Padding(0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(120, 20);
            this.label2.TabIndex = 35;
            this.label2.Text = "Số lượng tồn:";
            // 
            // glowBox2
            // 
            this.glowBox2.Controls.Add(this.txt_SoLuongNhap);
            this.glowBox2.GlowColor = System.Drawing.Color.PowderBlue;
            this.glowBox2.GlowOn = false;
            this.glowBox2.Location = new System.Drawing.Point(180, 241);
            this.glowBox2.Margin = new System.Windows.Forms.Padding(0);
            this.glowBox2.Name = "glowBox2";
            this.glowBox2.Size = new System.Drawing.Size(209, 39);
            this.glowBox2.TabIndex = 32;
            // 
            // txt_SoLuongNhap
            // 
            this.txt_SoLuongNhap.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.txt_SoLuongNhap.Location = new System.Drawing.Point(5, 5);
            this.txt_SoLuongNhap.Margin = new System.Windows.Forms.Padding(0);
            this.txt_SoLuongNhap.Name = "txt_SoLuongNhap";
            this.txt_SoLuongNhap.Size = new System.Drawing.Size(199, 29);
            this.txt_SoLuongNhap.TabIndex = 25;
            // 
            // btnThem
            // 
            this.btnThem.BackColor = System.Drawing.Color.Teal;
            this.btnThem.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThem.ForeColor = System.Drawing.Color.White;
            this.btnThem.Location = new System.Drawing.Point(347, 338);
            this.btnThem.Margin = new System.Windows.Forms.Padding(0);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(213, 49);
            this.btnThem.TabIndex = 29;
            this.btnThem.Text = "Thêm chi tiết";
            this.btnThem.UseVisualStyleBackColor = false;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(32, 252);
            this.label8.Margin = new System.Windows.Forms.Padding(0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(134, 20);
            this.label8.TabIndex = 28;
            this.label8.Text = "Số lượng nhập:";
            // 
            // btnXoa
            // 
            this.btnXoa.BackColor = System.Drawing.Color.Teal;
            this.btnXoa.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnXoa.ForeColor = System.Drawing.Color.White;
            this.btnXoa.Location = new System.Drawing.Point(67, 338);
            this.btnXoa.Margin = new System.Windows.Forms.Padding(0);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(213, 49);
            this.btnXoa.TabIndex = 30;
            this.btnXoa.Text = "Xóa chi tiết";
            this.btnXoa.UseVisualStyleBackColor = false;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(28, 80);
            this.label7.Margin = new System.Windows.Forms.Padding(0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(138, 20);
            this.label7.TabIndex = 27;
            this.label7.Text = "Tên sách nhập:";
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Checked = true;
            this.radioButton1.Location = new System.Drawing.Point(33, 2);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(126, 20);
            this.radioButton1.TabIndex = 17;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "Điều kiện nhập 1";
            this.radioButton1.UseVisualStyleBackColor = true;
            this.radioButton1.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Location = new System.Drawing.Point(165, 2);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(126, 20);
            this.radioButton2.TabIndex = 18;
            this.radioButton2.Text = "Điều kiện nhập 2";
            this.radioButton2.UseVisualStyleBackColor = true;
            this.radioButton2.CheckedChanged += new System.EventHandler(this.radioButton2_CheckedChanged);
            // 
            // PhieuNhapSach
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(1067, 738);
            this.Controls.Add(this.radioButton2);
            this.Controls.Add(this.radioButton1);
            this.Controls.Add(this.gb);
            this.Controls.Add(this.panel);
            this.Controls.Add(this.lb_TongTien);
            this.Controls.Add(this.lb_Ngay);
            this.Controls.Add(this.dataGridView);
            this.Controls.Add(this.btnLap);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "PhieuNhapSach";
            this.Text = "Lập Phiếu Nhập Sách";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.panel.ResumeLayout(false);
            this.panel.PerformLayout();
            this.gb.ResumeLayout(false);
            this.gb.PerformLayout();
            this.glowBox7.ResumeLayout(false);
            this.glowBox2.ResumeLayout(false);
            this.glowBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnLap;
        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.Label lb_Ngay;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lb_TongTien;
        private System.Windows.Forms.Panel panel;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private BorderBox gb;
        private GlowBox glowBox7;
        private System.Windows.Forms.ComboBox cb_MaSach;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txt_TheLoai;
        private System.Windows.Forms.TextBox txt_TacGia;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label2;
        private NumberInput txt_DonGia;
        private NumberInput txt_SoLuongTon;
        private GlowBox glowBox2;
        private NumberInput txt_SoLuongNhap;
        private System.Windows.Forms.TextBox txt_TenSach;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaSach;
        private System.Windows.Forms.DataGridViewTextBoxColumn TenSach;
        private System.Windows.Forms.DataGridViewTextBoxColumn SoLuongTon;
        private System.Windows.Forms.DataGridViewTextBoxColumn SoLuongNhap;
        private System.Windows.Forms.DataGridViewTextBoxColumn DonGia;
        private System.Windows.Forms.DataGridViewTextBoxColumn ThanhTien;
        private NumberInput txt_QĐ1A;
        private NumberInput txt_QĐ1B;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.RadioButton radioButton2;
    }
}