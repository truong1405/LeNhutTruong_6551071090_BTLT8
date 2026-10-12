using FastReport;
using QuanCaPhe.Helpers;
using QuanCaPhe.Models;
using QuanCaPhe.Services;

namespace QuanCaPhe.Forms;

public partial class FormHoaDon : Form
{
    private readonly DbService _dbService = new();
    private List<HoaDonItem> _dsHoaDon = new();
    private List<ChiTietItem> _dsChiTiet = new();
    private HoaDonItem? _hdDangChon;
    private ChiTietItem? _ctDangChon;
    private readonly bool _isCaptureMode;

    public FormHoaDon(bool isCaptureMode = false)
    {
        _isCaptureMode = isCaptureMode;
        InitializeComponent();
        KhoiTaoDuLieuBanDau();
        GanSuKien();

        if (_isCaptureMode)
        {
            Shown += async (_, _) =>
            {
                await Task.Delay(500);
                await TaiDuLieuBanDauAsync();
                await Task.Delay(500);

                Console.WriteLine($"[Debug] grpTimKiem Bounds: {grpTimKiem.Bounds}, Visible: {grpTimKiem.Visible}, Parent: {grpTimKiem.Parent?.Name}");
                Console.WriteLine($"[Debug] splMain Bounds: {splMain.Bounds}, Visible: {splMain.Visible}");

                string outDir = Path.Combine(AppContext.BaseDirectory, "KetQua");
                Directory.CreateDirectory(outDir);

                // 1. Chụp màn hình HD000001
                using (var bmp1 = new Bitmap(Width, Height))
                {
                    DrawToBitmap(bmp1, new Rectangle(0, 0, Width, Height));
                    string f1 = Path.Combine(outDir, "KetQua_FormHoaDon.png");
                    bmp1.Save(f1, System.Drawing.Imaging.ImageFormat.Png);
                    Console.WriteLine($"[Capture] Đã chụp ảnh Form: {f1}");
                }

                // 2. Chụp màn hình tìm "tiramisu"
                txtLocTenMon.Text = "tiramisu";
                await TimKiemHoaDonAsync();
                await Task.Delay(300);

                using (var bmp2 = new Bitmap(Width, Height))
                {
                    DrawToBitmap(bmp2, new Rectangle(0, 0, Width, Height));
                    string f2 = Path.Combine(outDir, "KetQua_FormHoaDon_TimTiramisu.png");
                    bmp2.Save(f2, System.Drawing.Imaging.ImageFormat.Png);
                    Console.WriteLine($"[Capture] Đã chụp ảnh Form tìm tiramisu: {f2}");
                }

                Application.Exit();
            };
        }
    }

    private void KhoiTaoDuLieuBanDau()
    {
        // 1. Khởi tạo danh sách tìm kiếm số bàn (Tất cả, 1..10)
        cboLocSoBan.Items.Add("Tất cả");
        for (int i = 1; i <= 10; i++)
        {
            cboLocSoBan.Items.Add(i.ToString());
        }
        cboLocSoBan.SelectedIndex = 0;

        // 2. Khởi tạo hình thức thanh toán tìm kiếm
        cboLocHinhThuc.Items.AddRange(new object[] { "Tất cả", "Tiền mặt", "Chuyển khoản" });
        cboLocHinhThuc.SelectedIndex = 0;

        // 3. Khởi tạo khoảng ngày mặc định (tháng 10/2026 theo dữ liệu bài)
        dtpTuNgay.Value = new DateTime(2026, 10, 1);
        dtpDenNgay.Value = new DateTime(2026, 10, 31);

        // 4. Khởi tạo danh sách số bàn cho hóa đơn (1..10)
        cboSoBan.Items.Clear();
        for (int i = 1; i <= 10; i++)
        {
            cboSoBan.Items.Add(i.ToString());
        }
        dtpNgayLap.Value = DateTime.Now;

        // Cấu hình không tự sinh cột cho DataGridView (chỉ dùng các cột đã thiết kế)
        dgvHoaDon.AutoGenerateColumns = false;
        dgvChiTiet.AutoGenerateColumns = false;

        // Đảm bảo cụm tìm kiếm được dock trước ở trên cùng
        grpTimKiem.Dock = DockStyle.Top;
        grpTimKiem.SendToBack();
        splMain.Dock = DockStyle.Fill;
        splMain.BringToFront();
    }

    private void GanSuKien()
    {
        Load += async (_, _) => await UiHelper.ChayAsync(this, TaiDuLieuBanDauAsync);

        // Sự kiện tìm kiếm
        btnTim.Click += async (_, _) => await UiHelper.ChayAsync(this, TimKiemHoaDonAsync);
        txtLocTenMon.KeyDown += async (s, e) =>
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                await UiHelper.ChayAsync(this, TimKiemHoaDonAsync);
            }
        };

        // Lưới hóa đơn
        dgvHoaDon.SelectionChanged += async (_, _) => await UiHelper.ChayAsync(this, HienThiChiTietHoaDonAsync);

        // Lưới chi tiết
        dgvChiTiet.SelectionChanged += (_, _) => ChonDongChiTiet();

        // Các nút thao tác hóa đơn
        btnHoaDonMoi.Click += async (_, _) => await UiHelper.ChayAsync(this, TaoHoaDonMoiAsync);
        btnSuaHoaDon.Click += async (_, _) => await UiHelper.ChayAsync(this, SuaHoaDonAsync);
        btnXoaHoaDon.Click += async (_, _) => await UiHelper.ChayAsync(this, XoaHoaDonAsync);

        // Các nút thao tác món
        btnThemMon.Click += async (_, _) => await UiHelper.ChayAsync(this, ThemMonAsync);
        btnSuaSL.Click += async (_, _) => await UiHelper.ChayAsync(this, SuaSoLuongAsync);
        btnXoaMon.Click += async (_, _) => await UiHelper.ChayAsync(this, XoaMonAsync);

        // Các nút in & xuất FastReport
        btnXemHoaDon.Click += (_, _) => UiHelper.Chay(this, XemHoaDon);
        btnXuatPdf.Click += (_, _) => UiHelper.Chay(this, XuatPdfHoaDon);
        btnIn.Click += (_, _) => UiHelper.Chay(this, InHoaDon);
    }

    public async Task TaiDuLieuBanDauAsync()
    {
        // Tải danh sách món vào ComboBox
        var dsMon = await _dbService.LayDanhSachMonAsync();
        cboMon.DataSource = dsMon;
        cboMon.DisplayMember = "DisplayText";
        cboMon.ValueMember = "MaMon";

        // Tải danh sách hóa đơn ban đầu
        await TimKiemHoaDonAsync();
    }

    public async Task TimKiemHoaDonAsync()
    {
        DateTime tuNgay = dtpTuNgay.Value.Date;
        DateTime denNgay = dtpDenNgay.Value.Date;

        int? soBan = null;
        if (cboLocSoBan.SelectedIndex > 0 && int.TryParse(cboLocSoBan.SelectedItem?.ToString(), out int b))
        {
            soBan = b;
        }

        string? hinhThucTT = cboLocHinhThuc.SelectedItem?.ToString();
        string? tenMon = txtLocTenMon.Text.Trim();

        _dsHoaDon = await _dbService.LayDanhSachHoaDonAsync(tuNgay, denNgay, soBan, hinhThucTT, tenMon);
        dgvHoaDon.DataSource = null;
        dgvHoaDon.DataSource = _dsHoaDon;

        // Cập nhật tổng doanh thu các hóa đơn đang hiển thị
        decimal tongDoanhThu = _dsHoaDon.Sum(h => h.TongTien);
        lblTongDoanhThu.Text = $"Tổng doanh thu đang hiển thị: {tongDoanhThu:N0} đ";

        if (_dsHoaDon.Count > 0)
        {
            dgvHoaDon.Rows[0].Selected = true;
            await HienThiChiTietHoaDonAsync();
        }
        else
        {
            _hdDangChon = null;
            _dsChiTiet.Clear();
            dgvChiTiet.DataSource = null;
            lblTongCong.Text = "Tổng cộng: 0 đ";
            grpChiTiet.Text = "Chi tiết hóa đơn";
            CapNhatTrangThaiNut(false);
        }
    }

    private async Task HienThiChiTietHoaDonAsync()
    {
        if (dgvHoaDon.CurrentRow?.DataBoundItem is not HoaDonItem hd)
        {
            _hdDangChon = null;
            _dsChiTiet.Clear();
            dgvChiTiet.DataSource = null;
            lblTongCong.Text = "Tổng cộng: 0 đ";
            grpChiTiet.Text = "Chi tiết hóa đơn";
            CapNhatTrangThaiNut(false);
            return;
        }

        _hdDangChon = hd;
        grpChiTiet.Text = $"Chi tiết hóa đơn {hd.MaHDHienThi}";

        // Hiển thị thông tin hóa đơn lên các control nhập liệu
        dtpNgayLap.Value = hd.NgayLap;
        cboSoBan.SelectedItem = hd.SoBan.ToString();
        if (hd.HinhThucTT == "Tiền mặt")
        {
            radTienMat.Checked = true;
        }
        else
        {
            radChuyenKhoan.Checked = true;
        }
        txtGhiChu.Text = hd.GhiChu ?? string.Empty;

        // Tải chi tiết các món của hóa đơn
        _dsChiTiet = await _dbService.LayChiTietHoaDonAsync(hd.MaHD);
        dgvChiTiet.DataSource = null;
        dgvChiTiet.DataSource = _dsChiTiet;

        decimal tongCong = _dsChiTiet.Sum(c => c.ThanhTien);
        lblTongCong.Text = $"Tổng cộng: {tongCong:N0} đ";

        CapNhatTrangThaiNut(true);
    }

    private void ChonDongChiTiet()
    {
        if (dgvChiTiet.CurrentRow?.DataBoundItem is ChiTietItem ct)
        {
            _ctDangChon = ct;
            numSoLuong.Value = Math.Max(1, Math.Min(50, ct.SoLuong));
        }
        else
        {
            _ctDangChon = null;
        }
    }

    private void CapNhatTrangThaiNut(bool coHoaDon)
    {
        btnSuaHoaDon.Enabled = coHoaDon;
        btnXoaHoaDon.Enabled = coHoaDon;
        btnThemMon.Enabled = coHoaDon;
        btnSuaSL.Enabled = coHoaDon;
        btnXoaMon.Enabled = coHoaDon;
        btnXemHoaDon.Enabled = coHoaDon;
        btnXuatPdf.Enabled = coHoaDon;
        btnIn.Enabled = coHoaDon;
    }

    private async Task TaoHoaDonMoiAsync()
    {
        if (!int.TryParse(cboSoBan.SelectedItem?.ToString(), out int soBan) || soBan < 1 || soBan > 10)
        {
            MessageBox.Show(this, "Vui lòng chọn số bàn từ 1 đến 10.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        DateTime ngayLap = dtpNgayLap.Value;
        string hinhThucTT = radTienMat.Checked ? "Tiền mặt" : "Chuyển khoản";
        string? ghiChu = txtGhiChu.Text.Trim();

        var hdMoi = await _dbService.TaoHoaDonAsync(ngayLap, soBan, hinhThucTT, ghiChu);

        MessageBox.Show(this, $"Đã tạo mới hóa đơn HD{hdMoi.MaHd:D6} thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

        // Tải lại danh sách và chọn hóa đơn vừa tạo
        await TimKiemHoaDonAsync();
        ChonHoaDonTrenLuoi(hdMoi.MaHd);
    }

    private async Task SuaHoaDonAsync()
    {
        if (_hdDangChon == null)
        {
            MessageBox.Show(this, "Vui lòng chọn một hóa đơn để sửa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        if (!int.TryParse(cboSoBan.SelectedItem?.ToString(), out int soBan) || soBan < 1 || soBan > 10)
        {
            MessageBox.Show(this, "Vui lòng chọn số bàn từ 1 đến 10.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        DateTime ngayLap = dtpNgayLap.Value;
        string hinhThucTT = radTienMat.Checked ? "Tiền mặt" : "Chuyển khoản";
        string? ghiChu = txtGhiChu.Text.Trim();

        await _dbService.SuaHoaDonAsync(_hdDangChon.MaHD, ngayLap, soBan, hinhThucTT, ghiChu);

        MessageBox.Show(this, $"Đã cập nhật hóa đơn {_hdDangChon.MaHDHienThi} thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

        int maHd = _hdDangChon.MaHD;
        await TimKiemHoaDonAsync();
        ChonHoaDonTrenLuoi(maHd);
    }

    private async Task XoaHoaDonAsync()
    {
        if (_hdDangChon == null)
        {
            MessageBox.Show(this, "Vui lòng chọn hóa đơn cần xóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        var xacNhan = MessageBox.Show(this,
            $"Bạn có chắc chắn muốn xóa hóa đơn {_hdDangChon.MaHDHienThi} không?\n" +
            "Toàn bộ món trong hóa đơn sẽ bị xóa trước khi xóa hóa đơn.",
            "Xác nhận xóa",
            MessageBoxButtons.YesNo,
            MessageBoxIcon.Question);

        if (xacNhan != DialogResult.Yes) return;

        await _dbService.XoaHoaDonAsync(_hdDangChon.MaHD);

        MessageBox.Show(this, $"Đã xóa hóa đơn {_hdDangChon.MaHDHienThi} thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

        await TimKiemHoaDonAsync();
    }

    private async Task ThemMonAsync()
    {
        if (_hdDangChon == null)
        {
            MessageBox.Show(this, "Vui lòng chọn hoặc tạo hóa đơn trước khi thêm món.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        if (cboMon.SelectedItem is not MonComboItem mon)
        {
            MessageBox.Show(this, "Vui lòng chọn một món.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        int soLuong = (int)numSoLuong.Value;
        if (soLuong <= 0)
        {
            MessageBox.Show(this, "Số lượng món phải lớn hơn 0.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        await _dbService.ThemMonVaoHoaDonAsync(_hdDangChon.MaHD, mon.MaMon, soLuong);

        // Làm mới chi tiết và cập nhật tổng tiền
        await CapNhatLaiChiTietVaTongTienAsync();
    }

    private async Task SuaSoLuongAsync()
    {
        if (_hdDangChon == null)
        {
            MessageBox.Show(this, "Vui lòng chọn hóa đơn.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        if (_ctDangChon == null)
        {
            MessageBox.Show(this, "Vui lòng chọn món cần sửa số lượng trên lưới chi tiết.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        int soLuongMoi = (int)numSoLuong.Value;
        if (soLuongMoi <= 0)
        {
            MessageBox.Show(this, "Số lượng phải lớn hơn 0.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        await _dbService.SuaSoLuongMonAsync(_ctDangChon.MaCT, soLuongMoi);

        await CapNhatLaiChiTietVaTongTienAsync();
    }

    private async Task XoaMonAsync()
    {
        if (_hdDangChon == null)
        {
            MessageBox.Show(this, "Vui lòng chọn hóa đơn.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        if (_ctDangChon == null)
        {
            MessageBox.Show(this, "Vui lòng chọn món cần xóa trên lưới chi tiết.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        var xacNhan = MessageBox.Show(this,
            $"Bạn có chắc chắn muốn xóa món \"{_ctDangChon.TenMon}\" khỏi hóa đơn?",
            "Xác nhận xóa món",
            MessageBoxButtons.YesNo,
            MessageBoxIcon.Question);

        if (xacNhan != DialogResult.Yes) return;

        await _dbService.XoaMonKhoiHoaDonAsync(_ctDangChon.MaCT);

        await CapNhatLaiChiTietVaTongTienAsync();
    }

    private async Task CapNhatLaiChiTietVaTongTienAsync()
    {
        if (_hdDangChon == null) return;

        int maHd = _hdDangChon.MaHD;

        // 1. Tải lại chi tiết
        _dsChiTiet = await _dbService.LayChiTietHoaDonAsync(maHd);
        dgvChiTiet.DataSource = null;
        dgvChiTiet.DataSource = _dsChiTiet;

        // 2. Cập nhật label Tổng cộng
        decimal tongCong = _dsChiTiet.Sum(c => c.ThanhTien);
        lblTongCong.Text = $"Tổng cộng: {tongCong:N0} đ";

        // 3. Cập nhật dòng tương ứng ở lưới trái (dgvHoaDon)
        var itemHd = _dsHoaDon.FirstOrDefault(h => h.MaHD == maHd);
        if (itemHd != null)
        {
            itemHd.TongTien = tongCong;
            dgvHoaDon.Refresh();
        }

        // 4. Cập nhật tổng doanh thu đang hiển thị
        decimal tongDoanhThu = _dsHoaDon.Sum(h => h.TongTien);
        lblTongDoanhThu.Text = $"Tổng doanh thu đang hiển thị: {tongDoanhThu:N0} đ";
    }

    private void ChonHoaDonTrenLuoi(int maHd)
    {
        for (int i = 0; i < dgvHoaDon.Rows.Count; i++)
        {
            if (dgvHoaDon.Rows[i].DataBoundItem is HoaDonItem item && item.MaHD == maHd)
            {
                dgvHoaDon.Rows[i].Selected = true;
                dgvHoaDon.CurrentCell = dgvHoaDon.Rows[i].Cells[0];
                break;
            }
        }
    }

    private (HoaDon? hdEntity, List<ChiTietIn>? dsIn) KiemTraVaLayDuLieuIn()
    {
        if (_hdDangChon == null)
        {
            MessageBox.Show(this, "Vui lòng chọn một hóa đơn để in hoặc xuất report.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return (null, null);
        }

        if (_dsChiTiet.Count == 0)
        {
            MessageBox.Show(this, "Hóa đơn chưa có món nào. Không thể in trang trống!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return (null, null);
        }

        var hdEntity = new HoaDon
        {
            MaHd = _hdDangChon.MaHD,
            NgayLap = _hdDangChon.NgayLap,
            SoBan = _hdDangChon.SoBan,
            HinhThucTt = _hdDangChon.HinhThucTT,
            GhiChu = _hdDangChon.GhiChu
        };

        var dsIn = _dsChiTiet.Select(c => new ChiTietIn
        {
            STT = c.STT,
            TenMon = c.TenMon,
            SoLuong = c.SoLuong,
            DonGia = c.DonGia,
            ThanhTien = c.ThanhTien
        }).ToList();

        return (hdEntity, dsIn);
    }

    private void XemHoaDon()
    {
        var (hdEntity, dsIn) = KiemTraVaLayDuLieuIn();
        if (hdEntity == null || dsIn == null) return;

        using var report = ReportService.TaoReportHoaDon(hdEntity, dsIn);
        ReportService.XemTruoc(report);
    }

    private void XuatPdfHoaDon()
    {
        var (hdEntity, dsIn) = KiemTraVaLayDuLieuIn();
        if (hdEntity == null || dsIn == null) return;

        string tenFileMacDinh = $"HoaDon_{_hdDangChon!.MaHDHienThi}.pdf";
        string? duongDan = UiHelper.ChonFileLuu("PDF Files (*.pdf)|*.pdf|All Files (*.*)|*.*", tenFileMacDinh);
        if (string.IsNullOrEmpty(duongDan)) return;

        using var report = ReportService.TaoReportHoaDon(hdEntity, dsIn);
        ReportService.XuatPdf(report, duongDan);

        UiHelper.HoiMoFile(this, duongDan);
    }

    private void InHoaDon()
    {
        var (hdEntity, dsIn) = KiemTraVaLayDuLieuIn();
        if (hdEntity == null || dsIn == null) return;

        using var report = ReportService.TaoReportHoaDon(hdEntity, dsIn);
        ReportService.InHoaDon(report);
    }
}
