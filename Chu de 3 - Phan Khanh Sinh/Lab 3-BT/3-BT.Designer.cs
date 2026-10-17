namespace Lab_3_BT
{
    partial class Form1
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
            this.components = new System.ComponentModel.Container();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dtpNgaySinh = new System.Windows.Forms.DateTimePicker();
            this.radNu = new System.Windows.Forms.RadioButton();
            this.radNam = new System.Windows.Forms.RadioButton();
            this.cmbLop = new System.Windows.Forms.ComboBox();
            this.btnThoat = new System.Windows.Forms.Button();
            this.btnCapNhat = new System.Windows.Forms.Button();
            this.btnThemMoi = new System.Windows.Forms.Button();
            this.btnTim = new System.Windows.Forms.Button();
            this.txbTen = new System.Windows.Forms.TextBox();
            this.txbHo = new System.Windows.Forms.TextBox();
            this.txbDiaChi = new System.Windows.Forms.TextBox();
            this.lblGioiTinh = new System.Windows.Forms.Label();
            this.lblLop = new System.Windows.Forms.Label();
            this.lblTen = new System.Windows.Forms.Label();
            this.lblNgaySinh = new System.Windows.Forms.Label();
            this.lblSoDT = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblDiaChi = new System.Windows.Forms.Label();
            this.lblSoCMND = new System.Windows.Forms.Label();
            this.lblHo = new System.Windows.Forms.Label();
            this.lblMSSV = new System.Windows.Forms.Label();
            this.mtxbMSSV = new System.Windows.Forms.MaskedTextBox();
            this.mtxbCMND = new System.Windows.Forms.MaskedTextBox();
            this.mtxbSDT = new System.Windows.Forms.MaskedTextBox();
            this.clbMonHoc = new System.Windows.Forms.CheckedListBox();
            this.contextMenuMonHoc = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.menuThemMon = new System.Windows.Forms.ToolStripMenuItem();
            this.menuXoaMon = new System.Windows.Forms.ToolStripMenuItem();
            this.grbDSSV = new System.Windows.Forms.GroupBox();
            this.lvDSSV = new System.Windows.Forms.ListView();
            this.contextMenuListView = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.menuXoaSV = new System.Windows.Forms.ToolStripMenuItem();
            this.btnRefresh = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.contextMenuMonHoc.SuspendLayout();
            this.grbDSSV.SuspendLayout();
            this.contextMenuListView.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.groupBox1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.grbDSSV);
            this.splitContainer1.Size = new System.Drawing.Size(1024, 979);
            this.splitContainer1.SplitterDistance = 592;
            this.splitContainer1.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnRefresh);
            this.groupBox1.Controls.Add(this.dtpNgaySinh);
            this.groupBox1.Controls.Add(this.radNu);
            this.groupBox1.Controls.Add(this.radNam);
            this.groupBox1.Controls.Add(this.cmbLop);
            this.groupBox1.Controls.Add(this.btnThoat);
            this.groupBox1.Controls.Add(this.btnCapNhat);
            this.groupBox1.Controls.Add(this.btnThemMoi);
            this.groupBox1.Controls.Add(this.btnTim);
            this.groupBox1.Controls.Add(this.txbTen);
            this.groupBox1.Controls.Add(this.txbHo);
            this.groupBox1.Controls.Add(this.txbDiaChi);
            this.groupBox1.Controls.Add(this.lblGioiTinh);
            this.groupBox1.Controls.Add(this.lblLop);
            this.groupBox1.Controls.Add(this.lblTen);
            this.groupBox1.Controls.Add(this.lblNgaySinh);
            this.groupBox1.Controls.Add(this.lblSoDT);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.lblDiaChi);
            this.groupBox1.Controls.Add(this.lblSoCMND);
            this.groupBox1.Controls.Add(this.lblHo);
            this.groupBox1.Controls.Add(this.lblMSSV);
            this.groupBox1.Controls.Add(this.mtxbMSSV);
            this.groupBox1.Controls.Add(this.mtxbCMND);
            this.groupBox1.Controls.Add(this.mtxbSDT);
            this.groupBox1.Controls.Add(this.clbMonHoc);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(2, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1019, 581);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // dtpNgaySinh
            // 
            this.dtpNgaySinh.CustomFormat = "MM/dd/yyyy hh:mm:ss";
            this.dtpNgaySinh.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpNgaySinh.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpNgaySinh.Location = new System.Drawing.Point(224, 165);
            this.dtpNgaySinh.Name = "dtpNgaySinh";
            this.dtpNgaySinh.Size = new System.Drawing.Size(242, 30);
            this.dtpNgaySinh.TabIndex = 5;
            // 
            // radNu
            // 
            this.radNu.AutoSize = true;
            this.radNu.Location = new System.Drawing.Point(699, 58);
            this.radNu.Name = "radNu";
            this.radNu.Size = new System.Drawing.Size(58, 29);
            this.radNu.TabIndex = 4;
            this.radNu.TabStop = true;
            this.radNu.Text = "Nữ";
            this.radNu.UseVisualStyleBackColor = true;
            // 
            // radNam
            // 
            this.radNam.AutoSize = true;
            this.radNam.Location = new System.Drawing.Point(596, 58);
            this.radNam.Name = "radNam";
            this.radNam.Size = new System.Drawing.Size(74, 29);
            this.radNam.TabIndex = 4;
            this.radNam.TabStop = true;
            this.radNam.Text = "Nam";
            this.radNam.UseVisualStyleBackColor = true;
            // 
            // cmbLop
            // 
            this.cmbLop.FormattingEnabled = true;
            this.cmbLop.Location = new System.Drawing.Point(596, 167);
            this.cmbLop.Name = "cmbLop";
            this.cmbLop.Size = new System.Drawing.Size(251, 33);
            this.cmbLop.TabIndex = 3;
            // 
            // btnThoat
            // 
            this.btnThoat.Font = new System.Drawing.Font("Arial", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThoat.Location = new System.Drawing.Point(846, 510);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(125, 48);
            this.btnThoat.TabIndex = 2;
            this.btnThoat.Text = "Thoát";
            this.btnThoat.UseVisualStyleBackColor = true;
            this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);
            // 
            // btnCapNhat
            // 
            this.btnCapNhat.Font = new System.Drawing.Font("Arial", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCapNhat.Location = new System.Drawing.Point(699, 510);
            this.btnCapNhat.Name = "btnCapNhat";
            this.btnCapNhat.Size = new System.Drawing.Size(125, 48);
            this.btnCapNhat.TabIndex = 2;
            this.btnCapNhat.Text = "Cập nhật";
            this.btnCapNhat.UseVisualStyleBackColor = true;
            this.btnCapNhat.Click += new System.EventHandler(this.btnCapNhat_Click);
            // 
            // btnThemMoi
            // 
            this.btnThemMoi.Font = new System.Drawing.Font("Arial", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThemMoi.Location = new System.Drawing.Point(545, 510);
            this.btnThemMoi.Name = "btnThemMoi";
            this.btnThemMoi.Size = new System.Drawing.Size(125, 48);
            this.btnThemMoi.TabIndex = 2;
            this.btnThemMoi.Text = "Thêm mới";
            this.btnThemMoi.UseVisualStyleBackColor = true;
            this.btnThemMoi.Click += new System.EventHandler(this.btnThemMoi_Click);
            // 
            // btnTim
            // 
            this.btnTim.Font = new System.Drawing.Font("Arial", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTim.Location = new System.Drawing.Point(381, 510);
            this.btnTim.Name = "btnTim";
            this.btnTim.Size = new System.Drawing.Size(125, 48);
            this.btnTim.TabIndex = 2;
            this.btnTim.Text = "Tìm kiếm";
            this.btnTim.UseVisualStyleBackColor = true;
            this.btnTim.Click += new System.EventHandler(this.btnTim_Click);
            // 
            // txbTen
            // 
            this.txbTen.Location = new System.Drawing.Point(596, 111);
            this.txbTen.Name = "txbTen";
            this.txbTen.Size = new System.Drawing.Size(251, 30);
            this.txbTen.TabIndex = 1;
            // 
            // txbHo
            // 
            this.txbHo.Location = new System.Drawing.Point(224, 111);
            this.txbHo.Name = "txbHo";
            this.txbHo.Size = new System.Drawing.Size(242, 30);
            this.txbHo.TabIndex = 1;
            // 
            // txbDiaChi
            // 
            this.txbDiaChi.Location = new System.Drawing.Point(224, 276);
            this.txbDiaChi.Name = "txbDiaChi";
            this.txbDiaChi.Size = new System.Drawing.Size(623, 30);
            this.txbDiaChi.TabIndex = 1;
            // 
            // lblGioiTinh
            // 
            this.lblGioiTinh.AutoSize = true;
            this.lblGioiTinh.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGioiTinh.Location = new System.Drawing.Point(490, 61);
            this.lblGioiTinh.Name = "lblGioiTinh";
            this.lblGioiTinh.Size = new System.Drawing.Size(91, 23);
            this.lblGioiTinh.TabIndex = 0;
            this.lblGioiTinh.Text = "Giới tính:";
            // 
            // lblLop
            // 
            this.lblLop.AutoSize = true;
            this.lblLop.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLop.Location = new System.Drawing.Point(490, 171);
            this.lblLop.Name = "lblLop";
            this.lblLop.Size = new System.Drawing.Size(51, 23);
            this.lblLop.TabIndex = 0;
            this.lblLop.Text = "Lớp:";
            // 
            // lblTen
            // 
            this.lblTen.AutoSize = true;
            this.lblTen.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTen.Location = new System.Drawing.Point(490, 115);
            this.lblTen.Name = "lblTen";
            this.lblTen.Size = new System.Drawing.Size(49, 23);
            this.lblTen.TabIndex = 0;
            this.lblTen.Text = "Tên:";
            // 
            // lblNgaySinh
            // 
            this.lblNgaySinh.AutoSize = true;
            this.lblNgaySinh.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNgaySinh.Location = new System.Drawing.Point(41, 171);
            this.lblNgaySinh.Name = "lblNgaySinh";
            this.lblNgaySinh.Size = new System.Drawing.Size(101, 23);
            this.lblNgaySinh.TabIndex = 0;
            this.lblNgaySinh.Text = "Ngày sinh:";
            // 
            // lblSoDT
            // 
            this.lblSoDT.AutoSize = true;
            this.lblSoDT.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSoDT.Location = new System.Drawing.Point(490, 225);
            this.lblSoDT.Name = "lblSoDT";
            this.lblSoDT.Size = new System.Drawing.Size(70, 23);
            this.lblSoDT.TabIndex = 0;
            this.lblSoDT.Text = "Số ĐT:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(41, 391);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(166, 23);
            this.label2.TabIndex = 0;
            this.label2.Text = "Môn học đăng ký:";
            // 
            // lblDiaChi
            // 
            this.lblDiaChi.AutoSize = true;
            this.lblDiaChi.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDiaChi.Location = new System.Drawing.Point(41, 280);
            this.lblDiaChi.Name = "lblDiaChi";
            this.lblDiaChi.Size = new System.Drawing.Size(141, 23);
            this.lblDiaChi.TabIndex = 0;
            this.lblDiaChi.Text = "Địa chỉ liên lạc:";
            // 
            // lblSoCMND
            // 
            this.lblSoCMND.AutoSize = true;
            this.lblSoCMND.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSoCMND.Location = new System.Drawing.Point(41, 225);
            this.lblSoCMND.Name = "lblSoCMND";
            this.lblSoCMND.Size = new System.Drawing.Size(104, 23);
            this.lblSoCMND.TabIndex = 0;
            this.lblSoCMND.Text = "Số CMND:";
            // 
            // lblHo
            // 
            this.lblHo.AutoSize = true;
            this.lblHo.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHo.Location = new System.Drawing.Point(41, 115);
            this.lblHo.Name = "lblHo";
            this.lblHo.Size = new System.Drawing.Size(126, 23);
            this.lblHo.TabIndex = 0;
            this.lblHo.Text = "Họ và tên lót:";
            // 
            // lblMSSV
            // 
            this.lblMSSV.AutoSize = true;
            this.lblMSSV.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMSSV.Location = new System.Drawing.Point(41, 61);
            this.lblMSSV.Name = "lblMSSV";
            this.lblMSSV.Size = new System.Drawing.Size(71, 23);
            this.lblMSSV.TabIndex = 0;
            this.lblMSSV.Text = "MSSV:";
            // 
            // mtxbMSSV
            // 
            this.mtxbMSSV.Location = new System.Drawing.Point(224, 58);
            this.mtxbMSSV.Mask = "0000000";
            this.mtxbMSSV.Name = "mtxbMSSV";
            this.mtxbMSSV.Size = new System.Drawing.Size(242, 30);
            this.mtxbMSSV.TabIndex = 6;
            // 
            // mtxbCMND
            // 
            this.mtxbCMND.Location = new System.Drawing.Point(224, 222);
            this.mtxbCMND.Mask = "000000000";
            this.mtxbCMND.Name = "mtxbCMND";
            this.mtxbCMND.Size = new System.Drawing.Size(242, 30);
            this.mtxbCMND.TabIndex = 7;
            // 
            // mtxbSDT
            // 
            this.mtxbSDT.Location = new System.Drawing.Point(596, 222);
            this.mtxbSDT.Mask = "0000.000.000";
            this.mtxbSDT.Name = "mtxbSDT";
            this.mtxbSDT.Size = new System.Drawing.Size(251, 30);
            this.mtxbSDT.TabIndex = 8;
            // 
            // clbMonHoc
            // 
            this.clbMonHoc.CheckOnClick = true;
            this.clbMonHoc.ColumnWidth = 300;
            this.clbMonHoc.ContextMenuStrip = this.contextMenuMonHoc;
            this.clbMonHoc.FormattingEnabled = true;
            this.clbMonHoc.Items.AddRange(new object[] {
            "Mạng máy tính",
            "Hệ điều hành",
            "Lập trình CSDL",
            "Lập trình mạng",
            "Đồ án cơ sở",
            "Phương pháp NCKH",
            "Lập trình trên thiết bị di động",
            "An toàn và bảo mật hệ thống"});
            this.clbMonHoc.Location = new System.Drawing.Point(224, 334);
            this.clbMonHoc.MultiColumn = true;
            this.clbMonHoc.Name = "clbMonHoc";
            this.clbMonHoc.Size = new System.Drawing.Size(747, 154);
            this.clbMonHoc.TabIndex = 9;
            // 
            // contextMenuMonHoc
            // 
            this.contextMenuMonHoc.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuMonHoc.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuThemMon,
            this.menuXoaMon});
            this.contextMenuMonHoc.Name = "contextMenuMonHoc";
            this.contextMenuMonHoc.Size = new System.Drawing.Size(213, 52);
            // 
            // menuThemMon
            // 
            this.menuThemMon.Name = "menuThemMon";
            this.menuThemMon.Size = new System.Drawing.Size(212, 24);
            this.menuThemMon.Text = "Thêm môn học";
            // 
            // menuXoaMon
            // 
            this.menuXoaMon.Name = "menuXoaMon";
            this.menuXoaMon.Size = new System.Drawing.Size(212, 24);
            this.menuXoaMon.Text = "Xóa môn đang chọn";
            // 
            // grbDSSV
            // 
            this.grbDSSV.Controls.Add(this.lvDSSV);
            this.grbDSSV.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grbDSSV.Location = new System.Drawing.Point(4, 5);
            this.grbDSSV.Name = "grbDSSV";
            this.grbDSSV.Size = new System.Drawing.Size(1017, 377);
            this.grbDSSV.TabIndex = 0;
            this.grbDSSV.TabStop = false;
            this.grbDSSV.Text = "Danh sách sinh viên";
            // 
            // lvDSSV
            // 
            this.lvDSSV.CheckBoxes = true;
            this.lvDSSV.ContextMenuStrip = this.contextMenuListView;
            this.lvDSSV.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvDSSV.FullRowSelect = true;
            this.lvDSSV.GridLines = true;
            this.lvDSSV.HideSelection = false;
            this.lvDSSV.Location = new System.Drawing.Point(3, 26);
            this.lvDSSV.Name = "lvDSSV";
            this.lvDSSV.Size = new System.Drawing.Size(1011, 348);
            this.lvDSSV.TabIndex = 0;
            this.lvDSSV.UseCompatibleStateImageBehavior = false;
            this.lvDSSV.View = System.Windows.Forms.View.Details;
            // 
            // contextMenuListView
            // 
            this.contextMenuListView.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuListView.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuXoaSV});
            this.contextMenuListView.Name = "contextMenuListView";
            this.contextMenuListView.Size = new System.Drawing.Size(301, 28);
            // 
            // menuXoaSV
            // 
            this.menuXoaSV.Name = "menuXoaSV";
            this.menuXoaSV.Size = new System.Drawing.Size(300, 24);
            this.menuXoaSV.Text = "Xóa sinh viên đã chọn (Checkbox)";
            // 
            // btnRefresh
            // 
            this.btnRefresh.Location = new System.Drawing.Point(224, 510);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(124, 48);
            this.btnRefresh.TabIndex = 10;
            this.btnRefresh.Text = "Làm mới";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1024, 979);
            this.Controls.Add(this.splitContainer1);
            this.Name = "Form1";
            this.Text = "Nhập thông tin sinh viên";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.contextMenuMonHoc.ResumeLayout(false);
            this.grbDSSV.ResumeLayout(false);
            this.contextMenuListView.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.GroupBox grbDSSV;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lblMSSV;
        private System.Windows.Forms.Label lblGioiTinh;
        private System.Windows.Forms.Label lblLop;
        private System.Windows.Forms.Label lblTen;
        private System.Windows.Forms.Label lblNgaySinh;
        private System.Windows.Forms.Label lblSoDT;
        private System.Windows.Forms.Label lblSoCMND;
        private System.Windows.Forms.Label lblHo;
        private System.Windows.Forms.TextBox txbDiaChi;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblDiaChi;
        private System.Windows.Forms.TextBox txbTen;
        private System.Windows.Forms.TextBox txbHo;
        private System.Windows.Forms.Button btnTim;
        private System.Windows.Forms.Button btnThoat;
        private System.Windows.Forms.Button btnCapNhat;
        private System.Windows.Forms.Button btnThemMoi;
        private System.Windows.Forms.ComboBox cmbLop;
        private System.Windows.Forms.RadioButton radNu;
        private System.Windows.Forms.RadioButton radNam;
        private System.Windows.Forms.DateTimePicker dtpNgaySinh;

        private System.Windows.Forms.MaskedTextBox mtxbMSSV;
        private System.Windows.Forms.MaskedTextBox mtxbCMND;
        private System.Windows.Forms.MaskedTextBox mtxbSDT;
        private System.Windows.Forms.CheckedListBox clbMonHoc;
        private System.Windows.Forms.ListView lvDSSV;

        private System.Windows.Forms.ContextMenuStrip contextMenuMonHoc;
        private System.Windows.Forms.ToolStripMenuItem menuThemMon;
        private System.Windows.Forms.ToolStripMenuItem menuXoaMon;
        private System.Windows.Forms.ContextMenuStrip contextMenuListView;
        private System.Windows.Forms.ToolStripMenuItem menuXoaSV;
        private System.Windows.Forms.Button btnRefresh;
    }
}

