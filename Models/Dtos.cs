namespace QuanCaPhe.Models;

/// <summary>
/// DTO phục vụ in FastReport theo yêu cầu mục E.8:
/// Gồm STT, TenMon, SoLuong, DonGia, ThanhTien
/// </summary>
public class ChiTietIn
{
    public int STT { get; set; }
    public string TenMon { get; set; } = string.Empty;
    public int SoLuong { get; set; }
    public decimal DonGia { get; set; }
    public decimal ThanhTien { get; set; }
}

/// <summary>
/// Model hiển thị trên DataGridView danh sách hóa đơn (lưới trái).
/// Tổng tiền do truy vấn tính, không lưu trong bảng.
/// </summary>
public class HoaDonItem
{
    public int MaHD { get; set; }
    public string MaHDHienThi => $"HD{MaHD:D6}";
    public DateTime NgayLap { get; set; }
    public int SoBan { get; set; }
    public string HinhThucTT { get; set; } = string.Empty;
    public decimal TongTien { get; set; }
    public string? GhiChu { get; set; }
}

/// <summary>
/// Model hiển thị trên DataGridView chi tiết hóa đơn (lưới phải).
/// </summary>
public class ChiTietItem
{
    public int MaCT { get; set; }
    public int STT { get; set; }
    public int MaMon { get; set; }
    public string TenMon { get; set; } = string.Empty;
    public int SoLuong { get; set; }
    public decimal DonGia { get; set; }
    public decimal ThanhTien => SoLuong * DonGia;
}

/// <summary>
/// Item cho ComboBox chọn món (hiển thị Tên món và Đơn giá)
/// </summary>
public class MonComboItem
{
    public int MaMon { get; set; }
    public string TenMon { get; set; } = string.Empty;
    public decimal DonGia { get; set; }

    public string DisplayText => $"{TenMon} - {DonGia:N0} đ";

    public override string ToString() => DisplayText;
}
