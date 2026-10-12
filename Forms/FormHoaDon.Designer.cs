namespace QuanCaPhe.Forms;

partial class FormHoaDon
{
    private System.ComponentModel.IContainer components = null;

    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null))
        {
            components.Dispose();
        }
        base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
        System.Windows.Forms.DataGridViewCellStyle dgvHeaderStyle = new System.Windows.Forms.DataGridViewCellStyle();
        System.Windows.Forms.DataGridViewCellStyle dgvRowStyle = new System.Windows.Forms.DataGridViewCellStyle();
        
        this.grpTimKiem = new System.Windows.Forms.GroupBox();
        this.lblTuNgay = new System.Windows.Forms.Label();
        this.dtpTuNgay = new System.Windows.Forms.DateTimePicker();
        this.lblDenNgay = new System.Windows.Forms.Label();
        this.dtpDenNgay = new System.Windows.Forms.DateTimePicker();
        this.lblLocSoBan = new System.Windows.Forms.Label();
        this.cboLocSoBan = new System.Windows.Forms.ComboBox();
        this.lblLocHinhThuc = new System.Windows.Forms.Label();
        this.cboLocHinhThuc = new System.Windows.Forms.ComboBox();
        this.lblLocTenMon = new System.Windows.Forms.Label();
        this.txtLocTenMon = new System.Windows.Forms.TextBox();
        this.btnTim = new System.Windows.Forms.Button();

        this.splMain = new System.Windows.Forms.SplitContainer();

        // Left Panel Controls
        this.lblTieuDeDanhSach = new System.Windows.Forms.Label();
        this.dgvHoaDon = new System.Windows.Forms.DataGridView();
        this.colMaHD = new System.Windows.Forms.DataGridViewTextBoxColumn();
        this.colNgayLap = new System.Windows.Forms.DataGridViewTextBoxColumn();
        this.colSoBan = new System.Windows.Forms.DataGridViewTextBoxColumn();
        this.colHinhThucTT = new System.Windows.Forms.DataGridViewTextBoxColumn();
        this.colTongTien = new System.Windows.Forms.DataGridViewTextBoxColumn();
        this.lblTongDoanhThu = new System.Windows.Forms.Label();
        this.pnlNutHoaDon = new System.Windows.Forms.FlowLayoutPanel();
        this.btnHoaDonMoi = new System.Windows.Forms.Button();
        this.btnSuaHoaDon = new System.Windows.Forms.Button();
        this.btnXoaHoaDon = new System.Windows.Forms.Button();

        // Right Panel Controls
        this.grpChiTiet = new System.Windows.Forms.GroupBox();
        this.pnlNhapHoaDon = new System.Windows.Forms.Panel();
        this.dtpNgayLap = new System.Windows.Forms.DateTimePicker();
        this.lblSoBan = new System.Windows.Forms.Label();
        this.cboSoBan = new System.Windows.Forms.ComboBox();
        this.radTienMat = new System.Windows.Forms.RadioButton();
        this.radChuyenKhoan = new System.Windows.Forms.RadioButton();
        this.lblGhiChu = new System.Windows.Forms.Label();
        this.txtGhiChu = new System.Windows.Forms.TextBox();
        this.pnlChonMon = new System.Windows.Forms.Panel();
        this.lblChonMon = new System.Windows.Forms.Label();
        this.cboMon = new System.Windows.Forms.ComboBox();
        this.lblSoLuong = new System.Windows.Forms.Label();
        this.numSoLuong = new System.Windows.Forms.NumericUpDown();
        this.btnThemMon = new System.Windows.Forms.Button();
        this.dgvChiTiet = new System.Windows.Forms.DataGridView();
        this.colSTT = new System.Windows.Forms.DataGridViewTextBoxColumn();
        this.colTenMon = new System.Windows.Forms.DataGridViewTextBoxColumn();
        this.colSL = new System.Windows.Forms.DataGridViewTextBoxColumn();
        this.colDonGia = new System.Windows.Forms.DataGridViewTextBoxColumn();
        this.colThanhTien = new System.Windows.Forms.DataGridViewTextBoxColumn();
        this.pnlTongChiTiet = new System.Windows.Forms.Panel();
        this.lblTongCong = new System.Windows.Forms.Label();
        this.pnlNutChiTiet = new System.Windows.Forms.FlowLayoutPanel();
        this.btnSuaSL = new System.Windows.Forms.Button();
        this.btnXoaMon = new System.Windows.Forms.Button();
        this.btnXemHoaDon = new System.Windows.Forms.Button();
        this.btnXuatPdf = new System.Windows.Forms.Button();
        this.btnIn = new System.Windows.Forms.Button();

        this.grpTimKiem.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)(this.splMain)).BeginInit();
        this.splMain.Panel1.SuspendLayout();
        this.splMain.Panel2.SuspendLayout();
        this.splMain.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)(this.dgvHoaDon)).BeginInit();
        this.pnlNutHoaDon.SuspendLayout();
        this.grpChiTiet.SuspendLayout();
        this.pnlNhapHoaDon.SuspendLayout();
        this.pnlChonMon.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)(this.numSoLuong)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.dgvChiTiet)).BeginInit();
        this.pnlTongChiTiet.SuspendLayout();
        this.pnlNutChiTiet.SuspendLayout();
        this.SuspendLayout();

        // 
        // grpTimKiem
        // 
        this.grpTimKiem.Controls.Add(this.btnTim);
        this.grpTimKiem.Controls.Add(this.txtLocTenMon);
        this.grpTimKiem.Controls.Add(this.lblLocTenMon);
        this.grpTimKiem.Controls.Add(this.cboLocHinhThuc);
        this.grpTimKiem.Controls.Add(this.lblLocHinhThuc);
        this.grpTimKiem.Controls.Add(this.cboLocSoBan);
        this.grpTimKiem.Controls.Add(this.lblLocSoBan);
        this.grpTimKiem.Controls.Add(this.dtpDenNgay);
        this.grpTimKiem.Controls.Add(this.lblDenNgay);
        this.grpTimKiem.Controls.Add(this.dtpTuNgay);
        this.grpTimKiem.Controls.Add(this.lblTuNgay);
        this.grpTimKiem.Dock = System.Windows.Forms.DockStyle.Top;
        this.grpTimKiem.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
        this.grpTimKiem.Location = new System.Drawing.Point(12, 12);
        this.grpTimKiem.Name = "grpTimKiem";
        this.grpTimKiem.Size = new System.Drawing.Size(1176, 80);
        this.grpTimKiem.TabIndex = 0;
        this.grpTimKiem.TabStop = false;
        this.grpTimKiem.Text = "Tìm kiếm hóa đơn";

        // lblTuNgay
        this.lblTuNgay.AutoSize = true;
        this.lblTuNgay.Location = new System.Drawing.Point(15, 23);
        this.lblTuNgay.Name = "lblTuNgay";
        this.lblTuNgay.Size = new System.Drawing.Size(52, 15);
        this.lblTuNgay.TabIndex = 0;
        this.lblTuNgay.Text = "Từ ngày:";

        // dtpTuNgay
        this.dtpTuNgay.CustomFormat = "dd/MM/yyyy";
        this.dtpTuNgay.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
        this.dtpTuNgay.Location = new System.Drawing.Point(15, 41);
        this.dtpTuNgay.Name = "dtpTuNgay";
        this.dtpTuNgay.Size = new System.Drawing.Size(115, 23);
        this.dtpTuNgay.TabIndex = 1;

        // lblDenNgay
        this.lblDenNgay.AutoSize = true;
        this.lblDenNgay.Location = new System.Drawing.Point(145, 23);
        this.lblDenNgay.Name = "lblDenNgay";
        this.lblDenNgay.Size = new System.Drawing.Size(60, 15);
        this.lblDenNgay.TabIndex = 2;
        this.lblDenNgay.Text = "Đến ngày:";

        // dtpDenNgay
        this.dtpDenNgay.CustomFormat = "dd/MM/yyyy";
        this.dtpDenNgay.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
        this.dtpDenNgay.Location = new System.Drawing.Point(145, 41);
        this.dtpDenNgay.Name = "dtpDenNgay";
        this.dtpDenNgay.Size = new System.Drawing.Size(115, 23);
        this.dtpDenNgay.TabIndex = 3;

        // lblLocSoBan
        this.lblLocSoBan.AutoSize = true;
        this.lblLocSoBan.Location = new System.Drawing.Point(275, 23);
        this.lblLocSoBan.Name = "lblLocSoBan";
        this.lblLocSoBan.Size = new System.Drawing.Size(46, 15);
        this.lblLocSoBan.TabIndex = 4;
        this.lblLocSoBan.Text = "Số bàn:";

        // cboLocSoBan
        this.cboLocSoBan.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
        this.cboLocSoBan.FormattingEnabled = true;
        this.cboLocSoBan.Location = new System.Drawing.Point(275, 41);
        this.cboLocSoBan.Name = "cboLocSoBan";
        this.cboLocSoBan.Size = new System.Drawing.Size(95, 23);
        this.cboLocSoBan.TabIndex = 5;

        // lblLocHinhThuc
        this.lblLocHinhThuc.AutoSize = true;
        this.lblLocHinhThuc.Location = new System.Drawing.Point(385, 23);
        this.lblLocHinhThuc.Name = "lblLocHinhThuc";
        this.lblLocHinhThuc.Size = new System.Drawing.Size(62, 15);
        this.lblLocHinhThuc.TabIndex = 6;
        this.lblLocHinhThuc.Text = "Hình thức:";

        // cboLocHinhThuc
        this.cboLocHinhThuc.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
        this.cboLocHinhThuc.FormattingEnabled = true;
        this.cboLocHinhThuc.Location = new System.Drawing.Point(385, 41);
        this.cboLocHinhThuc.Name = "cboLocHinhThuc";
        this.cboLocHinhThuc.Size = new System.Drawing.Size(125, 23);
        this.cboLocHinhThuc.TabIndex = 7;

        // lblLocTenMon
        this.lblLocTenMon.AutoSize = true;
        this.lblLocTenMon.Location = new System.Drawing.Point(525, 23);
        this.lblLocTenMon.Name = "lblLocTenMon";
        this.lblLocTenMon.Size = new System.Drawing.Size(56, 15);
        this.lblLocTenMon.TabIndex = 8;
        this.lblLocTenMon.Text = "Tên món:";

        // txtLocTenMon
        this.txtLocTenMon.Location = new System.Drawing.Point(525, 41);
        this.txtLocTenMon.Name = "txtLocTenMon";
        this.txtLocTenMon.Size = new System.Drawing.Size(200, 23);
        this.txtLocTenMon.TabIndex = 9;

        // btnTim
        this.btnTim.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(240)))), ((int)(((byte)(250)))));
        this.btnTim.Cursor = System.Windows.Forms.Cursors.Hand;
        this.btnTim.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this.btnTim.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
        this.btnTim.Location = new System.Drawing.Point(740, 39);
        this.btnTim.Name = "btnTim";
        this.btnTim.Size = new System.Drawing.Size(85, 27);
        this.btnTim.TabIndex = 10;
        this.btnTim.Text = "Tìm";
        this.btnTim.UseVisualStyleBackColor = false;

        // 
        // splMain
        // 
        this.splMain.Dock = System.Windows.Forms.DockStyle.Fill;
        this.splMain.Location = new System.Drawing.Point(12, 92);
        this.splMain.Name = "splMain";
        // 
        // splMain.Panel1 (Left Panel)
        // 
        this.splMain.Panel1.Controls.Add(this.dgvHoaDon);
        this.splMain.Panel1.Controls.Add(this.lblTongDoanhThu);
        this.splMain.Panel1.Controls.Add(this.pnlNutHoaDon);
        this.splMain.Panel1.Controls.Add(this.lblTieuDeDanhSach);
        // 
        // splMain.Panel2 (Right Panel)
        // 
        this.splMain.Panel2.Controls.Add(this.grpChiTiet);
        this.splMain.Size = new System.Drawing.Size(1176, 560);
        this.splMain.SplitterDistance = 530;
        this.splMain.TabIndex = 1;

        // 
        // Left Panel Setup
        // 
        this.lblTieuDeDanhSach.Dock = System.Windows.Forms.DockStyle.Top;
        this.lblTieuDeDanhSach.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
        this.lblTieuDeDanhSach.Location = new System.Drawing.Point(0, 0);
        this.lblTieuDeDanhSach.Name = "lblTieuDeDanhSach";
        this.lblTieuDeDanhSach.Padding = new System.Windows.Forms.Padding(0, 4, 0, 4);
        this.lblTieuDeDanhSach.Size = new System.Drawing.Size(530, 26);
        this.lblTieuDeDanhSach.TabIndex = 0;
        this.lblTieuDeDanhSach.Text = "Danh sách hóa đơn";

        // dgvHoaDon
        this.dgvHoaDon.AllowUserToAddRows = false;
        this.dgvHoaDon.AllowUserToDeleteRows = false;
        this.dgvHoaDon.AllowUserToResizeRows = false;
        this.dgvHoaDon.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
        this.dgvHoaDon.BackgroundColor = System.Drawing.SystemColors.Window;
        this.dgvHoaDon.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
        dgvHeaderStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
        dgvHeaderStyle.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
        this.dgvHoaDon.ColumnHeadersDefaultCellStyle = dgvHeaderStyle;
        this.dgvHoaDon.ColumnHeadersHeight = 30;
        this.dgvHoaDon.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colMaHD,
            this.colNgayLap,
            this.colSoBan,
            this.colHinhThucTT,
            this.colTongTien});
        this.dgvHoaDon.Dock = System.Windows.Forms.DockStyle.Fill;
        this.dgvHoaDon.Location = new System.Drawing.Point(0, 26);
        this.dgvHoaDon.MultiSelect = false;
        this.dgvHoaDon.Name = "dgvHoaDon";
        this.dgvHoaDon.ReadOnly = true;
        this.dgvHoaDon.RowHeadersVisible = false;
        this.dgvHoaDon.RowTemplate.Height = 26;
        this.dgvHoaDon.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
        this.dgvHoaDon.Size = new System.Drawing.Size(530, 440);
        this.dgvHoaDon.TabIndex = 1;

        // colMaHD
        this.colMaHD.DataPropertyName = "MaHDHienThi";
        this.colMaHD.FillWeight = 85F;
        this.colMaHD.HeaderText = "Mã HD";
        this.colMaHD.Name = "colMaHD";
        this.colMaHD.ReadOnly = true;
        this.colMaHD.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;

        // colNgayLap
        this.colNgayLap.DataPropertyName = "NgayLap";
        this.colNgayLap.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
        this.colNgayLap.DefaultCellStyle.Format = "dd/MM/yyyy HH:mm";
        this.colNgayLap.FillWeight = 125F;
        this.colNgayLap.HeaderText = "Ngày lập";
        this.colNgayLap.Name = "colNgayLap";
        this.colNgayLap.ReadOnly = true;

        // colSoBan
        this.colSoBan.DataPropertyName = "SoBan";
        this.colSoBan.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
        this.colSoBan.FillWeight = 55F;
        this.colSoBan.HeaderText = "Số bàn";
        this.colSoBan.Name = "colSoBan";
        this.colSoBan.ReadOnly = true;

        // colHinhThucTT
        this.colHinhThucTT.DataPropertyName = "HinhThucTT";
        this.colHinhThucTT.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
        this.colHinhThucTT.FillWeight = 95F;
        this.colHinhThucTT.HeaderText = "Hình thức TT";
        this.colHinhThucTT.Name = "colHinhThucTT";
        this.colHinhThucTT.ReadOnly = true;

        // colTongTien
        this.colTongTien.DataPropertyName = "TongTien";
        this.colTongTien.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
        this.colTongTien.DefaultCellStyle.Format = "N0";
        this.colTongTien.FillWeight = 90F;
        this.colTongTien.HeaderText = "Tổng tiền";
        this.colTongTien.Name = "colTongTien";
        this.colTongTien.ReadOnly = true;

        // lblTongDoanhThu
        this.lblTongDoanhThu.Dock = System.Windows.Forms.DockStyle.Bottom;
        this.lblTongDoanhThu.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
        this.lblTongDoanhThu.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(40)))), ((int)(((byte)(80)))));
        this.lblTongDoanhThu.Location = new System.Drawing.Point(0, 470);
        this.lblTongDoanhThu.Name = "lblTongDoanhThu";
        this.lblTongDoanhThu.Padding = new System.Windows.Forms.Padding(0, 8, 0, 4);
        this.lblTongDoanhThu.Size = new System.Drawing.Size(530, 42);
        this.lblTongDoanhThu.TabIndex = 2;
        this.lblTongDoanhThu.Text = "Tổng doanh thu đang hiển thị: 0 đ";

        // pnlNutHoaDon
        this.pnlNutHoaDon.Controls.Add(this.btnHoaDonMoi);
        this.pnlNutHoaDon.Controls.Add(this.btnSuaHoaDon);
        this.pnlNutHoaDon.Controls.Add(this.btnXoaHoaDon);
        this.pnlNutHoaDon.Dock = System.Windows.Forms.DockStyle.Bottom;
        this.pnlNutHoaDon.Location = new System.Drawing.Point(0, 512);
        this.pnlNutHoaDon.Name = "pnlNutHoaDon";
        this.pnlNutHoaDon.Size = new System.Drawing.Size(530, 48);
        this.pnlNutHoaDon.TabIndex = 3;

        // btnHoaDonMoi
        this.btnHoaDonMoi.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
        this.btnHoaDonMoi.Location = new System.Drawing.Point(3, 3);
        this.btnHoaDonMoi.Name = "btnHoaDonMoi";
        this.btnHoaDonMoi.Size = new System.Drawing.Size(100, 34);
        this.btnHoaDonMoi.TabIndex = 0;
        this.btnHoaDonMoi.Text = "Hóa đơn mới";
        this.btnHoaDonMoi.UseVisualStyleBackColor = true;

        // btnSuaHoaDon
        this.btnSuaHoaDon.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
        this.btnSuaHoaDon.Location = new System.Drawing.Point(109, 3);
        this.btnSuaHoaDon.Name = "btnSuaHoaDon";
        this.btnSuaHoaDon.Size = new System.Drawing.Size(95, 34);
        this.btnSuaHoaDon.TabIndex = 1;
        this.btnSuaHoaDon.Text = "Sửa hóa đơn";
        this.btnSuaHoaDon.UseVisualStyleBackColor = true;

        // btnXoaHoaDon
        this.btnXoaHoaDon.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
        this.btnXoaHoaDon.Location = new System.Drawing.Point(210, 3);
        this.btnXoaHoaDon.Name = "btnXoaHoaDon";
        this.btnXoaHoaDon.Size = new System.Drawing.Size(95, 34);
        this.btnXoaHoaDon.TabIndex = 2;
        this.btnXoaHoaDon.Text = "Xóa hóa đơn";
        this.btnXoaHoaDon.UseVisualStyleBackColor = true;

        // 
        // Right Panel Setup (grpChiTiet)
        // 
        this.grpChiTiet.Controls.Add(this.dgvChiTiet);
        this.grpChiTiet.Controls.Add(this.pnlTongChiTiet);
        this.grpChiTiet.Controls.Add(this.pnlNutChiTiet);
        this.grpChiTiet.Controls.Add(this.pnlChonMon);
        this.grpChiTiet.Controls.Add(this.pnlNhapHoaDon);
        this.grpChiTiet.Dock = System.Windows.Forms.DockStyle.Fill;
        this.grpChiTiet.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
        this.grpChiTiet.Location = new System.Drawing.Point(0, 0);
        this.grpChiTiet.Name = "grpChiTiet";
        this.grpChiTiet.Size = new System.Drawing.Size(642, 560);
        this.grpChiTiet.TabIndex = 0;
        this.grpChiTiet.TabStop = false;
        this.grpChiTiet.Text = "Chi tiết hóa đơn";

        // pnlNhapHoaDon
        this.pnlNhapHoaDon.Controls.Add(this.txtGhiChu);
        this.pnlNhapHoaDon.Controls.Add(this.lblGhiChu);
        this.pnlNhapHoaDon.Controls.Add(this.radChuyenKhoan);
        this.pnlNhapHoaDon.Controls.Add(this.radTienMat);
        this.pnlNhapHoaDon.Controls.Add(this.cboSoBan);
        this.pnlNhapHoaDon.Controls.Add(this.lblSoBan);
        this.pnlNhapHoaDon.Controls.Add(this.dtpNgayLap);
        this.pnlNhapHoaDon.Dock = System.Windows.Forms.DockStyle.Top;
        this.pnlNhapHoaDon.Location = new System.Drawing.Point(3, 19);
        this.pnlNhapHoaDon.Name = "pnlNhapHoaDon";
        this.pnlNhapHoaDon.Size = new System.Drawing.Size(636, 80);
        this.pnlNhapHoaDon.TabIndex = 0;

        // dtpNgayLap
        this.dtpNgayLap.CustomFormat = "dd/MM/yyyy HH:mm";
        this.dtpNgayLap.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
        this.dtpNgayLap.Location = new System.Drawing.Point(12, 12);
        this.dtpNgayLap.Name = "dtpNgayLap";
        this.dtpNgayLap.Size = new System.Drawing.Size(145, 23);
        this.dtpNgayLap.TabIndex = 0;

        // lblSoBan
        this.lblSoBan.AutoSize = true;
        this.lblSoBan.Location = new System.Drawing.Point(170, 16);
        this.lblSoBan.Name = "lblSoBan";
        this.lblSoBan.Size = new System.Drawing.Size(46, 15);
        this.lblSoBan.TabIndex = 1;
        this.lblSoBan.Text = "Số bàn:";

        // cboSoBan
        this.cboSoBan.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
        this.cboSoBan.FormattingEnabled = true;
        this.cboSoBan.Location = new System.Drawing.Point(220, 12);
        this.cboSoBan.Name = "cboSoBan";
        this.cboSoBan.Size = new System.Drawing.Size(60, 23);
        this.cboSoBan.TabIndex = 2;

        // radTienMat
        this.radTienMat.AutoSize = true;
        this.radTienMat.Checked = true;
        this.radTienMat.Location = new System.Drawing.Point(300, 14);
        this.radTienMat.Name = "radTienMat";
        this.radTienMat.Size = new System.Drawing.Size(70, 19);
        this.radTienMat.TabIndex = 3;
        this.radTienMat.TabStop = true;
        this.radTienMat.Text = "Tiền mặt";
        this.radTienMat.UseVisualStyleBackColor = true;

        // radChuyenKhoan
        this.radChuyenKhoan.AutoSize = true;
        this.radChuyenKhoan.Location = new System.Drawing.Point(380, 14);
        this.radChuyenKhoan.Name = "radChuyenKhoan";
        this.radChuyenKhoan.Size = new System.Drawing.Size(102, 19);
        this.radChuyenKhoan.TabIndex = 4;
        this.radChuyenKhoan.Text = "Chuyển khoản";
        this.radChuyenKhoan.UseVisualStyleBackColor = true;

        // lblGhiChu
        this.lblGhiChu.AutoSize = true;
        this.lblGhiChu.Location = new System.Drawing.Point(12, 46);
        this.lblGhiChu.Name = "lblGhiChu";
        this.lblGhiChu.Size = new System.Drawing.Size(51, 15);
        this.lblGhiChu.TabIndex = 5;
        this.lblGhiChu.Text = "Ghi chú:";

        // txtGhiChu
        this.txtGhiChu.Location = new System.Drawing.Point(70, 43);
        this.txtGhiChu.Multiline = true;
        this.txtGhiChu.Name = "txtGhiChu";
        this.txtGhiChu.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
        this.txtGhiChu.Size = new System.Drawing.Size(450, 30);
        this.txtGhiChu.TabIndex = 6;

        // pnlChonMon
        this.pnlChonMon.Controls.Add(this.btnThemMon);
        this.pnlChonMon.Controls.Add(this.numSoLuong);
        this.pnlChonMon.Controls.Add(this.lblSoLuong);
        this.pnlChonMon.Controls.Add(this.cboMon);
        this.pnlChonMon.Controls.Add(this.lblChonMon);
        this.pnlChonMon.Dock = System.Windows.Forms.DockStyle.Top;
        this.pnlChonMon.Location = new System.Drawing.Point(3, 99);
        this.pnlChonMon.Name = "pnlChonMon";
        this.pnlChonMon.Size = new System.Drawing.Size(636, 42);
        this.pnlChonMon.TabIndex = 1;

        // lblChonMon
        this.lblChonMon.AutoSize = true;
        this.lblChonMon.Location = new System.Drawing.Point(12, 13);
        this.lblChonMon.Name = "lblChonMon";
        this.lblChonMon.Size = new System.Drawing.Size(66, 15);
        this.lblChonMon.TabIndex = 0;
        this.lblChonMon.Text = "Chọn món:";

        // cboMon
        this.cboMon.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
        this.cboMon.FormattingEnabled = true;
        this.cboMon.Location = new System.Drawing.Point(82, 10);
        this.cboMon.Name = "cboMon";
        this.cboMon.Size = new System.Drawing.Size(240, 23);
        this.cboMon.TabIndex = 1;

        // lblSoLuong
        this.lblSoLuong.AutoSize = true;
        this.lblSoLuong.Location = new System.Drawing.Point(335, 13);
        this.lblSoLuong.Name = "lblSoLuong";
        this.lblSoLuong.Size = new System.Drawing.Size(23, 15);
        this.lblSoLuong.TabIndex = 2;
        this.lblSoLuong.Text = "SL:";

        // numSoLuong
        this.numSoLuong.Location = new System.Drawing.Point(362, 10);
        this.numSoLuong.Maximum = new decimal(new int[] { 50, 0, 0, 0 });
        this.numSoLuong.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
        this.numSoLuong.Name = "numSoLuong";
        this.numSoLuong.Size = new System.Drawing.Size(60, 23);
        this.numSoLuong.TabIndex = 3;
        this.numSoLuong.Value = new decimal(new int[] { 1, 0, 0, 0 });

        // btnThemMon
        this.btnThemMon.Location = new System.Drawing.Point(435, 8);
        this.btnThemMon.Name = "btnThemMon";
        this.btnThemMon.Size = new System.Drawing.Size(85, 27);
        this.btnThemMon.TabIndex = 4;
        this.btnThemMon.Text = "Thêm món";
        this.btnThemMon.UseVisualStyleBackColor = true;

        // dgvChiTiet
        this.dgvChiTiet.AllowUserToAddRows = false;
        this.dgvChiTiet.AllowUserToDeleteRows = false;
        this.dgvChiTiet.AllowUserToResizeRows = false;
        this.dgvChiTiet.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
        this.dgvChiTiet.BackgroundColor = System.Drawing.SystemColors.Window;
        this.dgvChiTiet.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
        this.dgvChiTiet.ColumnHeadersDefaultCellStyle = dgvHeaderStyle;
        this.dgvChiTiet.ColumnHeadersHeight = 30;
        this.dgvChiTiet.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colSTT,
            this.colTenMon,
            this.colSL,
            this.colDonGia,
            this.colThanhTien});
        this.dgvChiTiet.Dock = System.Windows.Forms.DockStyle.Fill;
        this.dgvChiTiet.Location = new System.Drawing.Point(3, 141);
        this.dgvChiTiet.MultiSelect = false;
        this.dgvChiTiet.Name = "dgvChiTiet";
        this.dgvChiTiet.ReadOnly = true;
        this.dgvChiTiet.RowHeadersVisible = false;
        this.dgvChiTiet.RowTemplate.Height = 26;
        this.dgvChiTiet.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
        this.dgvChiTiet.Size = new System.Drawing.Size(636, 325);
        this.dgvChiTiet.TabIndex = 2;

        // colSTT
        this.colSTT.DataPropertyName = "STT";
        this.colSTT.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
        this.colSTT.FillWeight = 40F;
        this.colSTT.HeaderText = "STT";
        this.colSTT.Name = "colSTT";
        this.colSTT.ReadOnly = true;

        // colTenMon
        this.colTenMon.DataPropertyName = "TenMon";
        this.colTenMon.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
        this.colTenMon.FillWeight = 160F;
        this.colTenMon.HeaderText = "Tên món";
        this.colTenMon.Name = "colTenMon";
        this.colTenMon.ReadOnly = true;

        // colSL
        this.colSL.DataPropertyName = "SoLuong";
        this.colSL.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
        this.colSL.FillWeight = 45F;
        this.colSL.HeaderText = "SL";
        this.colSL.Name = "colSL";
        this.colSL.ReadOnly = true;

        // colDonGia
        this.colDonGia.DataPropertyName = "DonGia";
        this.colDonGia.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
        this.colDonGia.DefaultCellStyle.Format = "N0";
        this.colDonGia.FillWeight = 85F;
        this.colDonGia.HeaderText = "Đơn giá";
        this.colDonGia.Name = "colDonGia";
        this.colDonGia.ReadOnly = true;

        // colThanhTien
        this.colThanhTien.DataPropertyName = "ThanhTien";
        this.colThanhTien.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
        this.colThanhTien.DefaultCellStyle.Format = "N0";
        this.colThanhTien.FillWeight = 95F;
        this.colThanhTien.HeaderText = "Thành tiền";
        this.colThanhTien.Name = "colThanhTien";
        this.colThanhTien.ReadOnly = true;

        // pnlTongChiTiet
        this.pnlTongChiTiet.Controls.Add(this.lblTongCong);
        this.pnlTongChiTiet.Dock = System.Windows.Forms.DockStyle.Bottom;
        this.pnlTongChiTiet.Location = new System.Drawing.Point(3, 466);
        this.pnlTongChiTiet.Name = "pnlTongChiTiet";
        this.pnlTongChiTiet.Size = new System.Drawing.Size(636, 42);
        this.pnlTongChiTiet.TabIndex = 3;

        // lblTongCong
        this.lblTongCong.Dock = System.Windows.Forms.DockStyle.Right;
        this.lblTongCong.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
        this.lblTongCong.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
        this.lblTongCong.Location = new System.Drawing.Point(300, 0);
        this.lblTongCong.Name = "lblTongCong";
        this.lblTongCong.Padding = new System.Windows.Forms.Padding(0, 8, 15, 0);
        this.lblTongCong.Size = new System.Drawing.Size(336, 42);
        this.lblTongCong.TabIndex = 0;
        this.lblTongCong.Text = "Tổng cộng: 0 đ";
        this.lblTongCong.TextAlign = System.Drawing.ContentAlignment.TopRight;

        // pnlNutChiTiet
        this.pnlNutChiTiet.Controls.Add(this.btnSuaSL);
        this.pnlNutChiTiet.Controls.Add(this.btnXoaMon);
        this.pnlNutChiTiet.Controls.Add(this.btnXemHoaDon);
        this.pnlNutChiTiet.Controls.Add(this.btnXuatPdf);
        this.pnlNutChiTiet.Controls.Add(this.btnIn);
        this.pnlNutChiTiet.Dock = System.Windows.Forms.DockStyle.Bottom;
        this.pnlNutChiTiet.Location = new System.Drawing.Point(3, 508);
        this.pnlNutChiTiet.Name = "pnlNutChiTiet";
        this.pnlNutChiTiet.Size = new System.Drawing.Size(636, 49);
        this.pnlNutChiTiet.TabIndex = 4;

        // btnSuaSL
        this.btnSuaSL.Location = new System.Drawing.Point(3, 3);
        this.btnSuaSL.Name = "btnSuaSL";
        this.btnSuaSL.Size = new System.Drawing.Size(80, 34);
        this.btnSuaSL.TabIndex = 0;
        this.btnSuaSL.Text = "Sửa SL";
        this.btnSuaSL.UseVisualStyleBackColor = true;

        // btnXoaMon
        this.btnXoaMon.Location = new System.Drawing.Point(89, 3);
        this.btnXoaMon.Name = "btnXoaMon";
        this.btnXoaMon.Size = new System.Drawing.Size(80, 34);
        this.btnXoaMon.TabIndex = 1;
        this.btnXoaMon.Text = "Xóa món";
        this.btnXoaMon.UseVisualStyleBackColor = true;

        // btnXemHoaDon
        this.btnXemHoaDon.Location = new System.Drawing.Point(175, 3);
        this.btnXemHoaDon.Name = "btnXemHoaDon";
        this.btnXemHoaDon.Size = new System.Drawing.Size(100, 34);
        this.btnXemHoaDon.TabIndex = 2;
        this.btnXemHoaDon.Text = "Xem hóa đơn";
        this.btnXemHoaDon.UseVisualStyleBackColor = true;

        // btnXuatPdf
        this.btnXuatPdf.Location = new System.Drawing.Point(281, 3);
        this.btnXuatPdf.Name = "btnXuatPdf";
        this.btnXuatPdf.Size = new System.Drawing.Size(85, 34);
        this.btnXuatPdf.TabIndex = 3;
        this.btnXuatPdf.Text = "Xuất PDF";
        this.btnXuatPdf.UseVisualStyleBackColor = true;

        // btnIn
        this.btnIn.Location = new System.Drawing.Point(372, 3);
        this.btnIn.Name = "btnIn";
        this.btnIn.Size = new System.Drawing.Size(75, 34);
        this.btnIn.TabIndex = 4;
        this.btnIn.Text = "In";
        this.btnIn.UseVisualStyleBackColor = true;

        // 
        // FormHoaDon
        // 
        this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        this.ClientSize = new System.Drawing.Size(1200, 664);
        this.Controls.Add(this.splMain);
        this.Controls.Add(this.grpTimKiem);
        this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
        this.MinimumSize = new System.Drawing.Size(1000, 600);
        this.Name = "FormHoaDon";
        this.Padding = new System.Windows.Forms.Padding(12);
        this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
        this.Text = "Quán cà phê Góc Phố - Quản lý hóa đơn";
        this.grpTimKiem.ResumeLayout(false);
        this.grpTimKiem.PerformLayout();
        this.splMain.Panel1.ResumeLayout(false);
        this.splMain.Panel2.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)(this.splMain)).EndInit();
        this.splMain.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)(this.dgvHoaDon)).EndInit();
        this.pnlNutHoaDon.ResumeLayout(false);
        this.grpChiTiet.ResumeLayout(false);
        this.pnlNhapHoaDon.ResumeLayout(false);
        this.pnlNhapHoaDon.PerformLayout();
        this.pnlChonMon.ResumeLayout(false);
        this.pnlChonMon.PerformLayout();
        ((System.ComponentModel.ISupportInitialize)(this.numSoLuong)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.dgvChiTiet)).EndInit();
        this.pnlTongChiTiet.ResumeLayout(false);
        this.pnlNutChiTiet.ResumeLayout(false);
        this.ResumeLayout(false);
    }

    private System.Windows.Forms.GroupBox grpTimKiem;
    private System.Windows.Forms.Label lblTuNgay;
    private System.Windows.Forms.DateTimePicker dtpTuNgay;
    private System.Windows.Forms.Label lblDenNgay;
    private System.Windows.Forms.DateTimePicker dtpDenNgay;
    private System.Windows.Forms.Label lblLocSoBan;
    private System.Windows.Forms.ComboBox cboLocSoBan;
    private System.Windows.Forms.Label lblLocHinhThuc;
    private System.Windows.Forms.ComboBox cboLocHinhThuc;
    private System.Windows.Forms.Label lblLocTenMon;
    private System.Windows.Forms.TextBox txtLocTenMon;
    private System.Windows.Forms.Button btnTim;

    private System.Windows.Forms.SplitContainer splMain;
    private System.Windows.Forms.Label lblTieuDeDanhSach;
    private System.Windows.Forms.DataGridView dgvHoaDon;
    private System.Windows.Forms.DataGridViewTextBoxColumn colMaHD;
    private System.Windows.Forms.DataGridViewTextBoxColumn colNgayLap;
    private System.Windows.Forms.DataGridViewTextBoxColumn colSoBan;
    private System.Windows.Forms.DataGridViewTextBoxColumn colHinhThucTT;
    private System.Windows.Forms.DataGridViewTextBoxColumn colTongTien;
    private System.Windows.Forms.Label lblTongDoanhThu;
    private System.Windows.Forms.FlowLayoutPanel pnlNutHoaDon;
    private System.Windows.Forms.Button btnHoaDonMoi;
    private System.Windows.Forms.Button btnSuaHoaDon;
    private System.Windows.Forms.Button btnXoaHoaDon;

    private System.Windows.Forms.GroupBox grpChiTiet;
    private System.Windows.Forms.Panel pnlNhapHoaDon;
    private System.Windows.Forms.DateTimePicker dtpNgayLap;
    private System.Windows.Forms.Label lblSoBan;
    private System.Windows.Forms.ComboBox cboSoBan;
    private System.Windows.Forms.RadioButton radTienMat;
    private System.Windows.Forms.RadioButton radChuyenKhoan;
    private System.Windows.Forms.Label lblGhiChu;
    private System.Windows.Forms.TextBox txtGhiChu;

    private System.Windows.Forms.Panel pnlChonMon;
    private System.Windows.Forms.Label lblChonMon;
    private System.Windows.Forms.ComboBox cboMon;
    private System.Windows.Forms.Label lblSoLuong;
    private System.Windows.Forms.NumericUpDown numSoLuong;
    private System.Windows.Forms.Button btnThemMon;

    private System.Windows.Forms.DataGridView dgvChiTiet;
    private System.Windows.Forms.DataGridViewTextBoxColumn colSTT;
    private System.Windows.Forms.DataGridViewTextBoxColumn colTenMon;
    private System.Windows.Forms.DataGridViewTextBoxColumn colSL;
    private System.Windows.Forms.DataGridViewTextBoxColumn colDonGia;
    private System.Windows.Forms.DataGridViewTextBoxColumn colThanhTien;

    private System.Windows.Forms.Panel pnlTongChiTiet;
    private System.Windows.Forms.Label lblTongCong;

    private System.Windows.Forms.FlowLayoutPanel pnlNutChiTiet;
    private System.Windows.Forms.Button btnSuaSL;
    private System.Windows.Forms.Button btnXoaMon;
    private System.Windows.Forms.Button btnXemHoaDon;
    private System.Windows.Forms.Button btnXuatPdf;
    private System.Windows.Forms.Button btnIn;
}
