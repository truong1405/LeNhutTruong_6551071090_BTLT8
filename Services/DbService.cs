using Microsoft.EntityFrameworkCore;
using QuanCaPhe.Models;

namespace QuanCaPhe.Services;

public class DbService
{
    private QuanCaPheContext CreateContext() => new();

    /// <summary>
    /// Lấy danh sách tất cả món từ bảng Mon
    /// </summary>
    public async Task<List<MonComboItem>> LayDanhSachMonAsync()
    {
        using var db = CreateContext();
        return await db.Mons
            .AsNoTracking()
            .OrderBy(m => m.NhomMon)
            .ThenBy(m => m.TenMon)
            .Select(m => new MonComboItem
            {
                MaMon = m.MaMon,
                TenMon = m.TenMon,
                DonGia = m.DonGia
            })
            .ToListAsync();
    }

    /// <summary>
    /// Lấy danh sách hóa đơn kết hợp các điều kiện lọc (Khoảng ngày, Số bàn, Hình thức TT, Tên món).
    /// Tổng tiền do truy vấn tính, không lưu trong bảng.
    /// </summary>
    public async Task<List<HoaDonItem>> LayDanhSachHoaDonAsync(
        DateTime? tuNgay = null,
        DateTime? denNgay = null,
        int? soBan = null,
        string? hinhThucTT = null,
        string? tenMon = null)
    {
        using var db = CreateContext();
        var query = db.HoaDons
            .Include(h => h.ChiTietHoaDons)
                .ThenInclude(ct => ct.MaMonNavigation)
            .AsNoTracking()
            .AsQueryable();

        // 1. Lọc theo khoảng ngày (Từ ngày, Đến ngày)
        if (tuNgay.HasValue)
        {
            var batDau = tuNgay.Value.Date;
            query = query.Where(h => h.NgayLap >= batDau);
        }

        if (denNgay.HasValue)
        {
            var ketThuc = denNgay.Value.Date.AddDays(1);
            query = query.Where(h => h.NgayLap < ketThuc);
        }

        // 2. Lọc theo số bàn (nếu chọn bàn cụ thể 1..10)
        if (soBan.HasValue && soBan.Value > 0)
        {
            query = query.Where(h => h.SoBan == soBan.Value);
        }

        // 3. Lọc theo hình thức thanh toán (Tiền mặt, Chuyển khoản)
        if (!string.IsNullOrWhiteSpace(hinhThucTT) && hinhThucTT != "Tất cả")
        {
            query = query.Where(h => h.HinhThucTt == hinhThucTT);
        }

        // 4. Lọc theo tên món (chỉ hiện các hóa đơn có chứa món đó)
        if (!string.IsNullOrWhiteSpace(tenMon))
        {
            var tuKhoa = tenMon.Trim().ToLower();
            query = query.Where(h => h.ChiTietHoaDons.Any(ct =>
                ct.MaMonNavigation.TenMon.ToLower().Contains(tuKhoa)));
        }

        var danhSach = await query
            .OrderBy(h => h.MaHd)
            .Select(h => new HoaDonItem
            {
                MaHD = h.MaHd,
                NgayLap = h.NgayLap,
                SoBan = h.SoBan,
                HinhThucTT = h.HinhThucTt,
                GhiChu = h.GhiChu,
                TongTien = h.ChiTietHoaDons.Sum(ct => ct.SoLuong * ct.DonGia)
            })
            .ToListAsync();

        return danhSach;
    }

    /// <summary>
    /// Lấy danh sách chi tiết của một hóa đơn
    /// </summary>
    public async Task<List<ChiTietItem>> LayChiTietHoaDonAsync(int maHd)
    {
        using var db = CreateContext();
        var rawList = await db.ChiTietHoaDons
            .Include(ct => ct.MaMonNavigation)
            .AsNoTracking()
            .Where(ct => ct.MaHd == maHd)
            .OrderBy(ct => ct.MaCt)
            .ToListAsync();

        var ketQua = new List<ChiTietItem>();
        int stt = 1;
        foreach (var item in rawList)
        {
            ketQua.Add(new ChiTietItem
            {
                MaCT = item.MaCt,
                STT = stt++,
                MaMon = item.MaMon,
                TenMon = item.MaMonNavigation?.TenMon ?? $"Món #{item.MaMon}",
                SoLuong = item.SoLuong,
                DonGia = item.DonGia
            });
        }

        return ketQua;
    }

    /// <summary>
    /// Lấy hóa đơn đầy đủ theo mã
    /// </summary>
    public async Task<HoaDon?> LayHoaDonByIdAsync(int maHd)
    {
        using var db = CreateContext();
        return await db.HoaDons
            .Include(h => h.ChiTietHoaDons)
                .ThenInclude(ct => ct.MaMonNavigation)
            .AsNoTracking()
            .FirstOrDefaultAsync(h => h.MaHd == maHd);
    }

    /// <summary>
    /// Lấy danh sách ChiTietIn cho FastReport
    /// </summary>
    public async Task<List<ChiTietIn>> LayDanhSachChiTietInAsync(int maHd)
    {
        var chiTiets = await LayChiTietHoaDonAsync(maHd);
        return chiTiets.Select(c => new ChiTietIn
        {
            STT = c.STT,
            TenMon = c.TenMon,
            SoLuong = c.SoLuong,
            DonGia = c.DonGia,
            ThanhTien = c.ThanhTien
        }).ToList();
    }

    /// <summary>
    /// Tạo hóa đơn mới
    /// </summary>
    public async Task<HoaDon> TaoHoaDonAsync(DateTime ngayLap, int soBan, string hinhThucTT, string? ghiChu)
    {
        using var db = CreateContext();
        var hd = new HoaDon
        {
            NgayLap = ngayLap,
            SoBan = soBan,
            HinhThucTt = hinhThucTT,
            GhiChu = string.IsNullOrWhiteSpace(ghiChu) ? null : ghiChu.Trim()
        };

        db.HoaDons.Add(hd);
        await db.SaveChangesAsync();
        return hd;
    }

    /// <summary>
    /// Sửa thông tin hóa đơn (ngày, bàn, hình thức thanh toán, ghi chú)
    /// </summary>
    public async Task SuaHoaDonAsync(int maHd, DateTime ngayLap, int soBan, string hinhThucTT, string? ghiChu)
    {
        using var db = CreateContext();
        var hd = await db.HoaDons.FirstOrDefaultAsync(h => h.MaHd == maHd);
        if (hd == null)
            throw new InvalidOperationException($"Không tìm thấy hóa đơn HD{maHd:D6} để sửa.");

        hd.NgayLap = ngayLap;
        hd.SoBan = soBan;
        hd.HinhThucTt = hinhThucTT;
        hd.GhiChu = string.IsNullOrWhiteSpace(ghiChu) ? null : ghiChu.Trim();

        await db.SaveChangesAsync();
    }

    /// <summary>
    /// Xóa hóa đơn: Xóa các dòng chi tiết trước rồi mới xóa hóa đơn
    /// </summary>
    public async Task XoaHoaDonAsync(int maHd)
    {
        using var db = CreateContext();

        // 1. Tìm và xóa các dòng chi tiết trước
        var chiTiets = await db.ChiTietHoaDons.Where(ct => ct.MaHd == maHd).ToListAsync();
        if (chiTiets.Count > 0)
        {
            db.ChiTietHoaDons.RemoveRange(chiTiets);
        }

        // 2. Xóa hóa đơn
        var hd = await db.HoaDons.FirstOrDefaultAsync(h => h.MaHd == maHd);
        if (hd != null)
        {
            db.HoaDons.Remove(hd);
        }

        await db.SaveChangesAsync();
    }

    /// <summary>
    /// Thêm một món vào hóa đơn. Đơn giá lấy từ bảng Mon tại thời điểm thêm.
    /// Nếu món đã có trong hóa đơn thì cộng dồn số lượng.
    /// </summary>
    public async Task ThemMonVaoHoaDonAsync(int maHd, int maMon, int soLuong)
    {
        if (soLuong <= 0)
            throw new ArgumentException("Số lượng món phải lớn hơn 0.", nameof(soLuong));

        using var db = CreateContext();

        // Lấy đơn giá tại thời điểm thêm từ bảng Mon
        var mon = await db.Mons.AsNoTracking().FirstOrDefaultAsync(m => m.MaMon == maMon);
        if (mon == null)
            throw new InvalidOperationException("Món ăn không tồn tại.");

        // Kiểm tra xem món này đã có trong chi tiết hóa đơn chưa
        var ctHienTai = await db.ChiTietHoaDons.FirstOrDefaultAsync(ct => ct.MaHd == maHd && ct.MaMon == maMon);
        if (ctHienTai != null)
        {
            ctHienTai.SoLuong += soLuong;
        }
        else
        {
            var chiTietMoi = new ChiTietHoaDon
            {
                MaHd = maHd,
                MaMon = maMon,
                SoLuong = soLuong,
                DonGia = mon.DonGia
            };
            db.ChiTietHoaDons.Add(chiTietMoi);
        }

        await db.SaveChangesAsync();
    }

    /// <summary>
    /// Đổi số lượng của dòng chi tiết đang chọn
    /// </summary>
    public async Task SuaSoLuongMonAsync(int maCt, int soLuongMoi)
    {
        if (soLuongMoi <= 0)
            throw new ArgumentException("Số lượng phải lớn hơn 0.", nameof(soLuongMoi));

        using var db = CreateContext();
        var ct = await db.ChiTietHoaDons.FirstOrDefaultAsync(c => c.MaCt == maCt);
        if (ct == null)
            throw new InvalidOperationException("Dòng chi tiết không tồn tại.");

        ct.SoLuong = soLuongMoi;
        await db.SaveChangesAsync();
    }

    /// <summary>
    /// Xóa dòng món đang chọn khỏi chi tiết hóa đơn
    /// </summary>
    public async Task XoaMonKhoiHoaDonAsync(int maCt)
    {
        using var db = CreateContext();
        var ct = await db.ChiTietHoaDons.FirstOrDefaultAsync(c => c.MaCt == maCt);
        if (ct != null)
        {
            db.ChiTietHoaDons.Remove(ct);
            await db.SaveChangesAsync();
        }
    }
}
