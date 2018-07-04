namespace QLKS_Winform
{
    partial class SuDungDV
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SuDungDV));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dgvDanhSachDV = new System.Windows.Forms.DataGridView();
            this.MaDV = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TenDV = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GiaDV = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DVT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dgvKhach = new System.Windows.Forms.DataGridView();
            this.CMND = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MaPhong = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HoTenKH = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtMaPhong = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtTenDV = new System.Windows.Forms.TextBox();
            this.btnTimKiemPhong = new System.Windows.Forms.Button();
            this.btnRefreshPhong = new System.Windows.Forms.Button();
            this.btnTimKiemDV = new System.Windows.Forms.Button();
            this.btnRefreshDV = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.txtDVT = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtGiaDV = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtSoLuong = new System.Windows.Forms.TextBox();
            this.txtTDV = new System.Windows.Forms.TextBox();
            this.txtMaDV = new System.Windows.Forms.TextBox();
            this.txtCMND = new System.Windows.Forms.TextBox();
            this.txtMP = new System.Windows.Forms.TextBox();
            this.dtpNgaySD = new System.Windows.Forms.DateTimePicker();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.dgvSDDV = new System.Windows.Forms.DataGridView();
            this.MP = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Chungminhnhandan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Madichvu = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Tendichvu = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SoLuong = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NgaySD = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TongTienDV = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ThanhToan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.btnThoat = new System.Windows.Forms.Button();
            this.btnKLuu = new System.Windows.Forms.Button();
            this.btnLuu = new System.Windows.Forms.Button();
            this.btnSua = new System.Windows.Forms.Button();
            this.btnXoa = new System.Windows.Forms.Button();
            this.btnThem = new System.Windows.Forms.Button();
            this.label11 = new System.Windows.Forms.Label();
            this.txtSDDVCMND = new System.Windows.Forms.TextBox();
            this.btnLocSDDV = new System.Windows.Forms.Button();
            this.btnResSDDV = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDanhSachDV)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvKhach)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSDDV)).BeginInit();
            this.groupBox5.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dgvDanhSachDV);
            this.groupBox1.Location = new System.Drawing.Point(327, 109);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(848, 178);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Danh sách dịch vụ";
            // 
            // dgvDanhSachDV
            // 
            this.dgvDanhSachDV.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvDanhSachDV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDanhSachDV.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.MaDV,
            this.TenDV,
            this.GiaDV,
            this.DVT});
            this.dgvDanhSachDV.Location = new System.Drawing.Point(0, 19);
            this.dgvDanhSachDV.Name = "dgvDanhSachDV";
            this.dgvDanhSachDV.Size = new System.Drawing.Size(848, 159);
            this.dgvDanhSachDV.TabIndex = 0;
            this.dgvDanhSachDV.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDanhSachDV_RowEnter);
            // 
            // MaDV
            // 
            this.MaDV.DataPropertyName = "MaDV";
            this.MaDV.HeaderText = "Mã dịch vụ";
            this.MaDV.Name = "MaDV";
            // 
            // TenDV
            // 
            this.TenDV.DataPropertyName = "TenDV";
            this.TenDV.HeaderText = "Tên dịch vụ";
            this.TenDV.Name = "TenDV";
            // 
            // GiaDV
            // 
            this.GiaDV.DataPropertyName = "GiaDV";
            this.GiaDV.HeaderText = "Giá dịch vụ";
            this.GiaDV.Name = "GiaDV";
            // 
            // DVT
            // 
            this.DVT.DataPropertyName = "DVT";
            this.DVT.HeaderText = "Đơn vị tính";
            this.DVT.Name = "DVT";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dgvKhach);
            this.groupBox2.Location = new System.Drawing.Point(12, 109);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(287, 178);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Danh sách phòng sử dụng";
            // 
            // dgvKhach
            // 
            this.dgvKhach.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvKhach.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvKhach.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.CMND,
            this.MaPhong,
            this.HoTenKH});
            this.dgvKhach.Location = new System.Drawing.Point(0, 19);
            this.dgvKhach.Name = "dgvKhach";
            this.dgvKhach.Size = new System.Drawing.Size(287, 159);
            this.dgvKhach.TabIndex = 0;
            this.dgvKhach.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvKhach_RowEnter);
            // 
            // CMND
            // 
            this.CMND.DataPropertyName = "CMND";
            this.CMND.HeaderText = "CMND";
            this.CMND.Name = "CMND";
            // 
            // MaPhong
            // 
            this.MaPhong.DataPropertyName = "MaPhong";
            this.MaPhong.HeaderText = "Mã phòng";
            this.MaPhong.Name = "MaPhong";
            // 
            // HoTenKH
            // 
            this.HoTenKH.DataPropertyName = "HotenKH";
            this.HoTenKH.HeaderText = "Họ tên";
            this.HoTenKH.Name = "HoTenKH";
            // 
            // txtMaPhong
            // 
            this.txtMaPhong.Location = new System.Drawing.Point(117, 81);
            this.txtMaPhong.Name = "txtMaPhong";
            this.txtMaPhong.Size = new System.Drawing.Size(100, 20);
            this.txtMaPhong.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.SteelBlue;
            this.label1.Location = new System.Drawing.Point(12, 81);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(93, 20);
            this.label1.TabIndex = 28;
            this.label1.Text = "Mã phòng:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.SteelBlue;
            this.label2.Location = new System.Drawing.Point(332, 79);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(105, 20);
            this.label2.TabIndex = 29;
            this.label2.Text = "Tên dịch vụ:";
            // 
            // txtTenDV
            // 
            this.txtTenDV.Location = new System.Drawing.Point(443, 81);
            this.txtTenDV.Name = "txtTenDV";
            this.txtTenDV.Size = new System.Drawing.Size(136, 20);
            this.txtTenDV.TabIndex = 30;
            // 
            // btnTimKiemPhong
            // 
            this.btnTimKiemPhong.BackColor = System.Drawing.SystemColors.Control;
            this.btnTimKiemPhong.Image = ((System.Drawing.Image)(resources.GetObject("btnTimKiemPhong.Image")));
            this.btnTimKiemPhong.Location = new System.Drawing.Point(223, 74);
            this.btnTimKiemPhong.Name = "btnTimKiemPhong";
            this.btnTimKiemPhong.Size = new System.Drawing.Size(35, 33);
            this.btnTimKiemPhong.TabIndex = 31;
            this.btnTimKiemPhong.UseVisualStyleBackColor = false;
            this.btnTimKiemPhong.Click += new System.EventHandler(this.btnTimKiemPhong_Click);
            this.btnTimKiemPhong.MouseHover += new System.EventHandler(this.btnTimKiemPhong_MouseHover);
            // 
            // btnRefreshPhong
            // 
            this.btnRefreshPhong.BackColor = System.Drawing.SystemColors.Control;
            this.btnRefreshPhong.Image = ((System.Drawing.Image)(resources.GetObject("btnRefreshPhong.Image")));
            this.btnRefreshPhong.Location = new System.Drawing.Point(264, 74);
            this.btnRefreshPhong.Name = "btnRefreshPhong";
            this.btnRefreshPhong.Size = new System.Drawing.Size(35, 33);
            this.btnRefreshPhong.TabIndex = 32;
            this.btnRefreshPhong.UseVisualStyleBackColor = false;
            this.btnRefreshPhong.Click += new System.EventHandler(this.btnRefreshPhong_Click);
            this.btnRefreshPhong.MouseHover += new System.EventHandler(this.btnRefreshPhong_MouseHover);
            // 
            // btnTimKiemDV
            // 
            this.btnTimKiemDV.BackColor = System.Drawing.SystemColors.Control;
            this.btnTimKiemDV.Image = ((System.Drawing.Image)(resources.GetObject("btnTimKiemDV.Image")));
            this.btnTimKiemDV.Location = new System.Drawing.Point(585, 74);
            this.btnTimKiemDV.Name = "btnTimKiemDV";
            this.btnTimKiemDV.Size = new System.Drawing.Size(35, 33);
            this.btnTimKiemDV.TabIndex = 33;
            this.btnTimKiemDV.UseVisualStyleBackColor = false;
            this.btnTimKiemDV.Click += new System.EventHandler(this.btnTimKiemDV_Click);
            this.btnTimKiemDV.MouseHover += new System.EventHandler(this.btnTimKiemDV_MouseHover);
            // 
            // btnRefreshDV
            // 
            this.btnRefreshDV.BackColor = System.Drawing.SystemColors.Control;
            this.btnRefreshDV.Image = ((System.Drawing.Image)(resources.GetObject("btnRefreshDV.Image")));
            this.btnRefreshDV.Location = new System.Drawing.Point(626, 74);
            this.btnRefreshDV.Name = "btnRefreshDV";
            this.btnRefreshDV.Size = new System.Drawing.Size(35, 33);
            this.btnRefreshDV.TabIndex = 34;
            this.btnRefreshDV.UseVisualStyleBackColor = false;
            this.btnRefreshDV.Click += new System.EventHandler(this.btnRefreshDV_Click);
            this.btnRefreshDV.MouseHover += new System.EventHandler(this.btnRefreshDV_MouseHover);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.txtDVT);
            this.groupBox3.Controls.Add(this.label10);
            this.groupBox3.Controls.Add(this.txtGiaDV);
            this.groupBox3.Controls.Add(this.label9);
            this.groupBox3.Controls.Add(this.txtSoLuong);
            this.groupBox3.Controls.Add(this.txtTDV);
            this.groupBox3.Controls.Add(this.txtMaDV);
            this.groupBox3.Controls.Add(this.txtCMND);
            this.groupBox3.Controls.Add(this.txtMP);
            this.groupBox3.Controls.Add(this.dtpNgaySD);
            this.groupBox3.Controls.Add(this.label8);
            this.groupBox3.Controls.Add(this.label7);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Location = new System.Drawing.Point(12, 303);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(287, 297);
            this.groupBox3.TabIndex = 35;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Kiểm tra thông tin";
            // 
            // txtDVT
            // 
            this.txtDVT.Enabled = false;
            this.txtDVT.Location = new System.Drawing.Point(105, 222);
            this.txtDVT.Name = "txtDVT";
            this.txtDVT.Size = new System.Drawing.Size(172, 20);
            this.txtDVT.TabIndex = 49;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.SteelBlue;
            this.label10.Location = new System.Drawing.Point(6, 222);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(99, 20);
            this.label10.TabIndex = 48;
            this.label10.Text = "Đơn vị tính:";
            // 
            // txtGiaDV
            // 
            this.txtGiaDV.Enabled = false;
            this.txtGiaDV.Location = new System.Drawing.Point(105, 184);
            this.txtGiaDV.Name = "txtGiaDV";
            this.txtGiaDV.Size = new System.Drawing.Size(172, 20);
            this.txtGiaDV.TabIndex = 47;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.SteelBlue;
            this.label9.Location = new System.Drawing.Point(6, 182);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(103, 20);
            this.label9.TabIndex = 46;
            this.label9.Text = "Giá dịch vụ:";
            // 
            // txtSoLuong
            // 
            this.txtSoLuong.Enabled = false;
            this.txtSoLuong.Location = new System.Drawing.Point(105, 148);
            this.txtSoLuong.Name = "txtSoLuong";
            this.txtSoLuong.Size = new System.Drawing.Size(172, 20);
            this.txtSoLuong.TabIndex = 45;
            // 
            // txtTDV
            // 
            this.txtTDV.Enabled = false;
            this.txtTDV.Location = new System.Drawing.Point(105, 114);
            this.txtTDV.Name = "txtTDV";
            this.txtTDV.Size = new System.Drawing.Size(172, 20);
            this.txtTDV.TabIndex = 44;
            // 
            // txtMaDV
            // 
            this.txtMaDV.Enabled = false;
            this.txtMaDV.Location = new System.Drawing.Point(105, 80);
            this.txtMaDV.Name = "txtMaDV";
            this.txtMaDV.Size = new System.Drawing.Size(172, 20);
            this.txtMaDV.TabIndex = 43;
            // 
            // txtCMND
            // 
            this.txtCMND.Enabled = false;
            this.txtCMND.Location = new System.Drawing.Point(105, 49);
            this.txtCMND.Name = "txtCMND";
            this.txtCMND.Size = new System.Drawing.Size(172, 20);
            this.txtCMND.TabIndex = 42;
            // 
            // txtMP
            // 
            this.txtMP.Enabled = false;
            this.txtMP.Location = new System.Drawing.Point(105, 18);
            this.txtMP.Name = "txtMP";
            this.txtMP.Size = new System.Drawing.Size(172, 20);
            this.txtMP.TabIndex = 36;
            // 
            // dtpNgaySD
            // 
            this.dtpNgaySD.CustomFormat = "\'Ngày\' dd \'Tháng\' MM \'Năm\' yyyy";
            this.dtpNgaySD.Enabled = false;
            this.dtpNgaySD.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpNgaySD.Location = new System.Drawing.Point(96, 264);
            this.dtpNgaySD.Name = "dtpNgaySD";
            this.dtpNgaySD.Size = new System.Drawing.Size(181, 20);
            this.dtpNgaySD.TabIndex = 41;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.SteelBlue;
            this.label8.Location = new System.Drawing.Point(9, 265);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(84, 20);
            this.label8.TabIndex = 40;
            this.label8.Text = "Ngày SD:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.SteelBlue;
            this.label7.Location = new System.Drawing.Point(6, 146);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(85, 20);
            this.label7.TabIndex = 39;
            this.label7.Text = "Số lượng:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.SteelBlue;
            this.label6.Location = new System.Drawing.Point(6, 112);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(105, 20);
            this.label6.TabIndex = 38;
            this.label6.Text = "Tên dịch vụ:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.SteelBlue;
            this.label5.Location = new System.Drawing.Point(6, 78);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(99, 20);
            this.label5.TabIndex = 36;
            this.label5.Text = "Mã dịch vụ:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.SteelBlue;
            this.label4.Location = new System.Drawing.Point(6, 47);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 20);
            this.label4.TabIndex = 37;
            this.label4.Text = "CMND:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.SteelBlue;
            this.label3.Location = new System.Drawing.Point(6, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(93, 20);
            this.label3.TabIndex = 36;
            this.label3.Text = "Mã phòng:";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.dgvSDDV);
            this.groupBox4.Location = new System.Drawing.Point(327, 334);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(848, 297);
            this.groupBox4.TabIndex = 36;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Sử dụng dịch vụ";
            // 
            // dgvSDDV
            // 
            this.dgvSDDV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSDDV.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.MP,
            this.Chungminhnhandan,
            this.Madichvu,
            this.Tendichvu,
            this.SoLuong,
            this.NgaySD,
            this.TongTienDV,
            this.ThanhToan});
            this.dgvSDDV.Location = new System.Drawing.Point(0, 18);
            this.dgvSDDV.Name = "dgvSDDV";
            this.dgvSDDV.Size = new System.Drawing.Size(848, 279);
            this.dgvSDDV.TabIndex = 0;
            // 
            // MP
            // 
            this.MP.DataPropertyName = "MaPhong";
            this.MP.HeaderText = "Mã phòng";
            this.MP.Name = "MP";
            // 
            // Chungminhnhandan
            // 
            this.Chungminhnhandan.DataPropertyName = "CMND";
            this.Chungminhnhandan.HeaderText = "CMND";
            this.Chungminhnhandan.Name = "Chungminhnhandan";
            // 
            // Madichvu
            // 
            this.Madichvu.DataPropertyName = "MaDV";
            this.Madichvu.HeaderText = "Mã dịch vụ";
            this.Madichvu.Name = "Madichvu";
            // 
            // Tendichvu
            // 
            this.Tendichvu.DataPropertyName = "TenDV";
            this.Tendichvu.HeaderText = "Tên dịch vụ";
            this.Tendichvu.Name = "Tendichvu";
            // 
            // SoLuong
            // 
            this.SoLuong.DataPropertyName = "SoLuong";
            this.SoLuong.HeaderText = "Số lượng";
            this.SoLuong.Name = "SoLuong";
            // 
            // NgaySD
            // 
            this.NgaySD.DataPropertyName = "NgaySD";
            this.NgaySD.HeaderText = "Ngày sử dụng";
            this.NgaySD.Name = "NgaySD";
            // 
            // TongTienDV
            // 
            this.TongTienDV.DataPropertyName = "TongTienDV";
            this.TongTienDV.HeaderText = "Tổng tiền";
            this.TongTienDV.Name = "TongTienDV";
            // 
            // ThanhToan
            // 
            this.ThanhToan.DataPropertyName = "ThanhToan";
            this.ThanhToan.HeaderText = "Thanh toán";
            this.ThanhToan.Name = "ThanhToan";
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.btnThoat);
            this.groupBox5.Controls.Add(this.btnKLuu);
            this.groupBox5.Controls.Add(this.btnLuu);
            this.groupBox5.Controls.Add(this.btnSua);
            this.groupBox5.Controls.Add(this.btnXoa);
            this.groupBox5.Controls.Add(this.btnThem);
            this.groupBox5.Location = new System.Drawing.Point(327, 637);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(252, 54);
            this.groupBox5.TabIndex = 37;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Chức năng";
            // 
            // btnThoat
            // 
            this.btnThoat.BackColor = System.Drawing.SystemColors.Control;
            this.btnThoat.Image = ((System.Drawing.Image)(resources.GetObject("btnThoat.Image")));
            this.btnThoat.Location = new System.Drawing.Point(211, 15);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(35, 33);
            this.btnThoat.TabIndex = 39;
            this.btnThoat.UseVisualStyleBackColor = false;
            this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);
            this.btnThoat.MouseHover += new System.EventHandler(this.btnThoat_MouseHover);
            // 
            // btnKLuu
            // 
            this.btnKLuu.BackColor = System.Drawing.SystemColors.Control;
            this.btnKLuu.Image = ((System.Drawing.Image)(resources.GetObject("btnKLuu.Image")));
            this.btnKLuu.Location = new System.Drawing.Point(170, 15);
            this.btnKLuu.Name = "btnKLuu";
            this.btnKLuu.Size = new System.Drawing.Size(35, 33);
            this.btnKLuu.TabIndex = 38;
            this.btnKLuu.UseVisualStyleBackColor = false;
            this.btnKLuu.Click += new System.EventHandler(this.btnKLuu_Click);
            this.btnKLuu.MouseHover += new System.EventHandler(this.btnKLuu_MouseHover);
            // 
            // btnLuu
            // 
            this.btnLuu.BackColor = System.Drawing.SystemColors.Control;
            this.btnLuu.Image = ((System.Drawing.Image)(resources.GetObject("btnLuu.Image")));
            this.btnLuu.Location = new System.Drawing.Point(129, 15);
            this.btnLuu.Name = "btnLuu";
            this.btnLuu.Size = new System.Drawing.Size(35, 33);
            this.btnLuu.TabIndex = 37;
            this.btnLuu.UseVisualStyleBackColor = false;
            this.btnLuu.Click += new System.EventHandler(this.btnLuu_Click);
            this.btnLuu.MouseHover += new System.EventHandler(this.btnLuu_MouseHover);
            // 
            // btnSua
            // 
            this.btnSua.BackColor = System.Drawing.SystemColors.Control;
            this.btnSua.Image = ((System.Drawing.Image)(resources.GetObject("btnSua.Image")));
            this.btnSua.Location = new System.Drawing.Point(88, 14);
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(35, 33);
            this.btnSua.TabIndex = 36;
            this.btnSua.UseVisualStyleBackColor = false;
            this.btnSua.Click += new System.EventHandler(this.btnSua_Click);
            this.btnSua.MouseHover += new System.EventHandler(this.btnSua_MouseHover);
            // 
            // btnXoa
            // 
            this.btnXoa.BackColor = System.Drawing.SystemColors.Control;
            this.btnXoa.Image = ((System.Drawing.Image)(resources.GetObject("btnXoa.Image")));
            this.btnXoa.Location = new System.Drawing.Point(47, 15);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(35, 33);
            this.btnXoa.TabIndex = 35;
            this.btnXoa.UseVisualStyleBackColor = false;
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            this.btnXoa.MouseHover += new System.EventHandler(this.btnXoa_MouseHover);
            // 
            // btnThem
            // 
            this.btnThem.BackColor = System.Drawing.SystemColors.Control;
            this.btnThem.Image = ((System.Drawing.Image)(resources.GetObject("btnThem.Image")));
            this.btnThem.Location = new System.Drawing.Point(6, 14);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(35, 33);
            this.btnThem.TabIndex = 34;
            this.btnThem.UseVisualStyleBackColor = false;
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            this.btnThem.MouseHover += new System.EventHandler(this.btnThem_MouseHover);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.SteelBlue;
            this.label11.Location = new System.Drawing.Point(332, 303);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(65, 20);
            this.label11.TabIndex = 38;
            this.label11.Text = "CMND:";
            // 
            // txtSDDVCMND
            // 
            this.txtSDDVCMND.Location = new System.Drawing.Point(403, 303);
            this.txtSDDVCMND.Name = "txtSDDVCMND";
            this.txtSDDVCMND.Size = new System.Drawing.Size(100, 20);
            this.txtSDDVCMND.TabIndex = 39;
            // 
            // btnLocSDDV
            // 
            this.btnLocSDDV.BackColor = System.Drawing.SystemColors.Control;
            this.btnLocSDDV.Image = ((System.Drawing.Image)(resources.GetObject("btnLocSDDV.Image")));
            this.btnLocSDDV.Location = new System.Drawing.Point(509, 298);
            this.btnLocSDDV.Name = "btnLocSDDV";
            this.btnLocSDDV.Size = new System.Drawing.Size(35, 33);
            this.btnLocSDDV.TabIndex = 40;
            this.btnLocSDDV.UseVisualStyleBackColor = false;
            this.btnLocSDDV.Click += new System.EventHandler(this.btnLocSDDV_Click);
            this.btnLocSDDV.MouseHover += new System.EventHandler(this.btnLocSDDV_MouseHover);
            // 
            // btnResSDDV
            // 
            this.btnResSDDV.BackColor = System.Drawing.SystemColors.Control;
            this.btnResSDDV.Image = ((System.Drawing.Image)(resources.GetObject("btnResSDDV.Image")));
            this.btnResSDDV.Location = new System.Drawing.Point(550, 298);
            this.btnResSDDV.Name = "btnResSDDV";
            this.btnResSDDV.Size = new System.Drawing.Size(35, 33);
            this.btnResSDDV.TabIndex = 41;
            this.btnResSDDV.UseVisualStyleBackColor = false;
            this.btnResSDDV.Click += new System.EventHandler(this.btnResSDDV_Click);
            this.btnResSDDV.MouseHover += new System.EventHandler(this.btnResSDDV_MouseHover);
            // 
            // SuDungDV
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1187, 703);
            this.Controls.Add(this.btnResSDDV);
            this.Controls.Add(this.btnLocSDDV);
            this.Controls.Add(this.txtSDDVCMND);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.btnRefreshDV);
            this.Controls.Add(this.btnTimKiemDV);
            this.Controls.Add(this.btnRefreshPhong);
            this.Controls.Add(this.btnTimKiemPhong);
            this.Controls.Add(this.txtTenDV);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtMaPhong);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "SuDungDV";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Sử dụng dịch vụ";
            this.Load += new System.EventHandler(this.SuDungDV_Load);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDanhSachDV)).EndInit();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvKhach)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvSDDV)).EndInit();
            this.groupBox5.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dgvDanhSachDV;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaDV;
        private System.Windows.Forms.DataGridViewTextBoxColumn TenDV;
        private System.Windows.Forms.DataGridViewTextBoxColumn GiaDV;
        private System.Windows.Forms.DataGridViewTextBoxColumn DVT;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView dgvKhach;
        private System.Windows.Forms.TextBox txtMaPhong;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtTenDV;
        private System.Windows.Forms.Button btnTimKiemPhong;
        private System.Windows.Forms.Button btnRefreshPhong;
        private System.Windows.Forms.Button btnTimKiemDV;
        private System.Windows.Forms.Button btnRefreshDV;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox txtSoLuong;
        private System.Windows.Forms.TextBox txtTDV;
        private System.Windows.Forms.TextBox txtMaDV;
        private System.Windows.Forms.TextBox txtCMND;
        private System.Windows.Forms.TextBox txtMP;
        private System.Windows.Forms.DateTimePicker dtpNgaySD;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.DataGridView dgvSDDV;
        private System.Windows.Forms.TextBox txtDVT;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtGiaDV;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Button btnSua;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.Button btnThoat;
        private System.Windows.Forms.Button btnKLuu;
        private System.Windows.Forms.Button btnLuu;
        private System.Windows.Forms.DataGridViewTextBoxColumn MP;
        private System.Windows.Forms.DataGridViewTextBoxColumn Chungminhnhandan;
        private System.Windows.Forms.DataGridViewTextBoxColumn Madichvu;
        private System.Windows.Forms.DataGridViewTextBoxColumn Tendichvu;
        private System.Windows.Forms.DataGridViewTextBoxColumn SoLuong;
        private System.Windows.Forms.DataGridViewTextBoxColumn NgaySD;
        private System.Windows.Forms.DataGridViewTextBoxColumn TongTienDV;
        private System.Windows.Forms.DataGridViewTextBoxColumn ThanhToan;
        private System.Windows.Forms.DataGridViewTextBoxColumn CMND;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaPhong;
        private System.Windows.Forms.DataGridViewTextBoxColumn HoTenKH;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtSDDVCMND;
        private System.Windows.Forms.Button btnLocSDDV;
        private System.Windows.Forms.Button btnResSDDV;
    }
}