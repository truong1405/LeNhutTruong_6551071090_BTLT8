using System.Globalization;

namespace QuanCaPhe;

/// <summary>
/// Cấu hình dùng chung: Chuỗi kết nối CSDL, tên quán, đường dẫn mẫu FastReport.
/// </summary>
public static class AppConfig
{
    public const string ConnectionString =
        @"Server=(localdb)\MSSQLLocalDB;Database=QuanCaPhe;Trusted_Connection=True;TrustServerCertificate=True";

    public const string TenQuan = "QUÁN CÀ PHÊ GÓC PHỐ";
    public const string FrxHoaDon = "HoaDon.frx";

    public static readonly CultureInfo ViCulture = new("vi-VN");

    /// <summary>
    /// Thư mục chứa các file mẫu .frx.
    /// Tìm ngược lên từ BaseDirectory tới thư mục chứa file .csproj.
    /// </summary>
    public static string ThuMucReport { get; } = TimThuMucReport();

    public static string DuongDanReport(string tenFile) => Path.Combine(ThuMucReport, tenFile);

    private static string TimThuMucReport()
    {
        var dir = new DirectoryInfo(AppContext.BaseDirectory);
        while (dir != null)
        {
            if (dir.GetFiles("*.csproj").Length > 0)
            {
                var p = Path.Combine(dir.FullName, "Reports");
                Directory.CreateDirectory(p);
                return p;
            }
            dir = dir.Parent;
        }

        var macDinh = Path.Combine(AppContext.BaseDirectory, "Reports");
        Directory.CreateDirectory(macDinh);
        return macDinh;
    }
}
