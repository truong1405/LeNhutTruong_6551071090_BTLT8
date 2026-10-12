using System.Diagnostics;
using QuanCaPhe.Models;
using QuanCaPhe.Services;

namespace QuanCaPhe;

public static class TestRunner
{
    public static async Task RunTestsAsync()
    {
        Console.WriteLine("=== BẮT ĐẦU KIỂM TRA BÀI 2 ===");
        var db = new DbService();

        // 1. Kiểm tra danh sách món
        var dsMon = await db.LayDanhSachMonAsync();
        Console.WriteLine($"[1] Danh sách món: {dsMon.Count} món");
        foreach (var m in dsMon)
        {
            Console.WriteLine($"    - {m.TenMon} ({m.DonGia:N0} đ)");
        }

        // 2. Kiểm tra danh sách hóa đơn ban đầu
        var dsHd = await db.LayDanhSachHoaDonAsync();
        Console.WriteLine($"[2] Danh sách hóa đơn: {dsHd.Count} hóa đơn");
        foreach (var h in dsHd)
        {
            Console.WriteLine($"    - {h.MaHDHienThi} | Bàn: {h.SoBan} | {h.HinhThucTT} | Tổng: {h.TongTien:N0} đ");
        }

        // 3. Kiểm tra chi tiết HD000001
        var ct1 = await db.LayChiTietHoaDonAsync(1);
        Console.WriteLine($"[3] Chi tiết HD000001: {ct1.Count} dòng");
        foreach (var c in ct1)
        {
            Console.WriteLine($"    {c.STT}. {c.TenMon} | SL: {c.SoLuong} | Đơn giá: {c.DonGia:N0} | Thành tiền: {c.ThanhTien:N0}");
        }
        decimal tong1 = ct1.Sum(x => x.ThanhTien);
        Console.WriteLine($"    -> Tổng cộng HD000001 = {tong1:N0} đ (Kỳ vọng: 142.000 đ) - {(tong1 == 142000 ? "PASS" : "FAIL")}");

        // 4. Kiểm tra chi tiết HD000002
        var ct2 = await db.LayChiTietHoaDonAsync(2);
        Console.WriteLine($"[4] Chi tiết HD000002: {ct2.Count} dòng");
        foreach (var c in ct2)
        {
            Console.WriteLine($"    {c.STT}. {c.TenMon} | SL: {c.SoLuong} | Đơn giá: {c.DonGia:N0} | Thành tiền: {c.ThanhTien:N0}");
        }
        decimal tong2 = ct2.Sum(x => x.ThanhTien);
        Console.WriteLine($"    -> Tổng cộng HD000002 = {tong2:N0} đ (Kỳ vọng: 56.000 đ) - {(tong2 == 56000 ? "PASS" : "FAIL")}");

        // 5. Kiểm tra lọc theo tên món "tiramisu"
        var dsTiramisu = await db.LayDanhSachHoaDonAsync(tenMon: "tiramisu");
        Console.WriteLine($"[5] Lọc theo món 'tiramisu': {dsTiramisu.Count} hóa đơn (Kỳ vọng 1: HD000001)");
        decimal doanhThuTiramisu = dsTiramisu.Sum(x => x.TongTien);
        Console.WriteLine($"    -> Doanh thu = {doanhThuTiramisu:N0} đ - {(dsTiramisu.Count == 1 && dsTiramisu[0].MaHD == 1 && doanhThuTiramisu == 142000 ? "PASS" : "FAIL")}");

        // 6. Kiểm tra lọc hình thức "Chuyển khoản"
        var dsCk = await db.LayDanhSachHoaDonAsync(hinhThucTT: "Chuyển khoản");
        Console.WriteLine($"[6] Lọc theo hình thức 'Chuyển khoản': {dsCk.Count} hóa đơn (Kỳ vọng 1: HD000002) - {(dsCk.Count == 1 && dsCk[0].MaHD == 2 ? "PASS" : "FAIL")}");

        // 7. Kiểm tra xuất PDF bằng FastReport
        var hd1 = await db.LayHoaDonByIdAsync(1);
        var dsIn1 = await db.LayDanhSachChiTietInAsync(1);
        using var report = ReportService.TaoReportHoaDon(hd1!, dsIn1);
        string pdfPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "HoaDon_HD000001.pdf");
        ReportService.XuatPdf(report, pdfPath);
        bool fileExists = File.Exists(pdfPath) && new FileInfo(pdfPath).Length > 0;
        Console.WriteLine($"[7] Xuất PDF HD000001: {(fileExists ? $"PASS ({new FileInfo(pdfPath).Length} bytes)" : "FAIL")}");

        // 8. Kiểm tra hóa đơn dài 50 dòng (phân trang)
        var dsIn50 = new List<ChiTietIn>();
        for (int i = 1; i <= 50; i++)
        {
            dsIn50.Add(new ChiTietIn
            {
                STT = i,
                TenMon = $"Món thứ #{i:D2}",
                SoLuong = 1,
                DonGia = 25000,
                ThanhTien = 25000
            });
        }
        using var report50 = ReportService.TaoReportHoaDon(hd1!, dsIn50);
        string pdf50Path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "HoaDon_Dai_50_Dong.pdf");
        ReportService.XuatPdf(report50, pdf50Path);
        bool file50Exists = File.Exists(pdf50Path) && new FileInfo(pdf50Path).Length > 0;
        Console.WriteLine($"[8] Xuất PDF hóa đơn dài 50 dòng: {(file50Exists ? $"PASS ({new FileInfo(pdf50Path).Length} bytes)" : "FAIL")}");

        // 9. Xuất ảnh hóa đơn FastReport
        try
        {
            using var reportImg = ReportService.TaoReportHoaDon(hd1!, dsIn1);
            reportImg.Prepare();
            using var imgExport = new FastReport.Export.Image.ImageExport();
            imgExport.ImageFormat = FastReport.Export.Image.ImageExportFormat.Png;
            imgExport.Resolution = 150;
            string outDir = Path.Combine(AppContext.BaseDirectory, "KetQua");
            Directory.CreateDirectory(outDir);
            string imgPath = Path.Combine(outDir, "KetQua_HoaDon_FastReport.png");
            reportImg.Export(imgExport, imgPath);
            Console.WriteLine($"[9] Xuất ảnh FastReport: PASS (file: {imgPath})");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"[9] Xuất ảnh FastReport: {ex.Message}");
        }

        Console.WriteLine("=== TẤT CẢ KIỂM TRA LOGIC & BÁO CÁO ĐÃ HOÀN TẤT ===");
    }
}
