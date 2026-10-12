using System.Diagnostics;
using System.Drawing.Printing;
using QuanCaPhe.Services;

namespace QuanCaPhe.Helpers;

public static class UiHelper
{
    public static string? ChonFileLuu(string boLoc, string tenMacDinh)
    {
        using var dlg = new SaveFileDialog
        {
            Filter = boLoc,
            FileName = tenMacDinh,
            OverwritePrompt = true,
            Title = "Chọn nơi lưu file PDF"
        };
        return dlg.ShowDialog() == DialogResult.OK ? dlg.FileName : null;
    }

    public static void HoiMoFile(IWin32Window owner, string path)
    {
        var kq = MessageBox.Show(owner,
            $"Đã lưu file thành công:\n{path}\n\nBạn có muốn mở file ngay không?",
            "Hoàn tất xuất file",
            MessageBoxButtons.YesNo,
            MessageBoxIcon.Question);

        if (kq == DialogResult.Yes)
        {
            try
            {
                Process.Start(new ProcessStartInfo(path) { UseShellExecute = true });
            }
            catch (Exception ex)
            {
                MessageBox.Show(owner, "Không thể mở file: " + ex.Message, "Lỗi mở file", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }

    public static bool CoMauReport(IWin32Window owner, string tenFile)
    {
        if (ReportService.CoMau(tenFile)) return true;

        MessageBox.Show(owner,
            $"Chưa tìm thấy mẫu report \"{tenFile}\" trong thư mục Reports.\n\n" +
            "Hệ thống sẽ tự động khởi tạo mẫu mặc định.",
            "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        return false;
    }

    public static void Chay(IWin32Window owner, Action tacVu)
    {
        try
        {
            tacVu();
        }
        catch (Exception ex)
        {
            HienLoi(owner, ex);
        }
    }

    public static async Task ChayAsync(IWin32Window owner, Func<Task> tacVu)
    {
        var ctl = owner as Control;
        try
        {
            if (ctl != null && !ctl.IsDisposed) ctl.Cursor = Cursors.WaitCursor;
            await tacVu();
        }
        catch (Exception ex)
        {
            HienLoi(owner, ex);
        }
        finally
        {
            if (ctl != null && !ctl.IsDisposed) ctl.Cursor = Cursors.Default;
        }
    }

    public static void HienLoi(IWin32Window owner, Exception ex)
    {
        var goc = ex.GetBaseException();
        string goiY = ex switch
        {
            InvalidPrinterException =>
                "\n\nGợi ý: Máy tính chưa cài máy in. Cài đặt 'Microsoft Print to PDF' để thử in.",
            IOException =>
                "\n\nGợi ý: File có thể đang được mở bởi chương trình khác. Vui lòng đóng file rồi thử lại.",
            _ when goc is Microsoft.Data.SqlClient.SqlException =>
                "\n\nGợi ý: Kiểm tra SQL Server LocalDB đã chạy và cơ sở dữ liệu QuanCaPhe đã được tạo bằng script QuanCaPhe.sql.",
            _ => ""
        };

        MessageBox.Show(owner, goc.Message + goiY, "Có lỗi xảy ra", MessageBoxButtons.OK, MessageBoxIcon.Error);
    }
}
