using System.Collections;
using FastReport;
using FastReport.Data;
using FastReport.Export.Pdf;
using QuanCaPhe.Models;

namespace QuanCaPhe.Services;

public static class ReportService
{
    public static bool CoMau(string tenFile) => File.Exists(AppConfig.DuongDanReport(tenFile));

    public static Report TaoReportHoaDon(HoaDon hd, List<ChiTietIn> dsChiTiet)
    {
        Thread.CurrentThread.CurrentCulture = AppConfig.ViCulture;
        Thread.CurrentThread.CurrentUICulture = AppConfig.ViCulture;

        var path = AppConfig.DuongDanReport(AppConfig.FrxHoaDon);
        var report = new Report();

        if (File.Exists(path))
        {
            report.Load(path);
        }
        else
        {
            // Nếu chưa có file mẫu, tạo và lưu file mẫu mặc định
            TaoMauHoaDonMacDinh(path);
            report.Load(path);
        }

        report.FileName = path;
        report.DoublePass = true;

        // E.8: Đăng ký danh sách các dòng chi tiết vào report với tên ChiTiet
        report.RegisterData(dsChiTiet, "ChiTiet");
        var ds = report.GetDataSource("ChiTiet");
        if (ds != null)
        {
            ds.Enabled = true;
        }

        // E.9: Truyền các tham số từ code
        // Tên quán, số hóa đơn (dạng HD000001), ngày lập, số bàn, hình thức thanh toán
        report.SetParameterValue("TenQuan", AppConfig.TenQuan);
        report.SetParameterValue("SoHD", $"HD{hd.MaHd:D6}");
        report.SetParameterValue("NgayLap", hd.NgayLap.ToString("dd/MM/yyyy HH:mm"));
        report.SetParameterValue("SoBan", hd.SoBan.ToString());
        report.SetParameterValue("HinhThucTT", hd.HinhThucTt);

        return report;
    }

    public static void XemTruoc(Report report)
    {
        if (report.Prepare())
        {
            report.ShowPrepared(true); // Modal dialog
        }
    }

    public static void XuatPdf(Report report, string filePath)
    {
        report.Prepare();
        using var pdf = new PDFExport();
        pdf.ShowProgress = false;
        report.Export(pdf, filePath);
    }

    public static void InHoaDon(Report report)
    {
        report.Prepare();
        report.PrintSettings.ShowDialog = true; // Hộp thoại in của FastReport
        report.Print();
    }

    public static void TaoMauHoaDonMacDinh(string duongDanFile)
    {
        var dir = Path.GetDirectoryName(duongDanFile);
        if (!string.IsNullOrEmpty(dir) && !Directory.Exists(dir))
        {
            Directory.CreateDirectory(dir);
        }

        string xmlContent = """
<?xml version="1.0" encoding="utf-8"?>
<Report ScriptLanguage="CSharp" DoublePass="true" ReportInfo.Created="10/12/2026 08:00:00" ReportInfo.Modified="10/12/2026 08:00:00" ReportInfo.CreatorVersion="2026.2.8.0">
  <Dictionary>
    <BusinessObjectDataSource Name="ChiTiet" ReferenceName="ChiTiet" DataType="System.Collections.Generic.List`1[[QuanCaPhe.Models.ChiTietIn, QuanCaPhe]]" Enabled="true">
      <Column Name="STT" DataType="System.Int32"/>
      <Column Name="TenMon" DataType="System.String"/>
      <Column Name="SoLuong" DataType="System.Int32"/>
      <Column Name="DonGia" DataType="System.Decimal"/>
      <Column Name="ThanhTien" DataType="System.Decimal"/>
    </BusinessObjectDataSource>
    <Parameter Name="TenQuan" DataType="System.String" AsString="QUÁN CÀ PHÊ GÓC PHỐ"/>
    <Parameter Name="SoHD" DataType="System.String" AsString="HD000001"/>
    <Parameter Name="NgayLap" DataType="System.String" AsString="09/10/2026 08:15"/>
    <Parameter Name="SoBan" DataType="System.String" AsString="3"/>
    <Parameter Name="HinhThucTT" DataType="System.String" AsString="Tiền mặt"/>
    <Total Name="TongCong" Expression="[ChiTiet.ThanhTien]" Evaluator="Data1" PrintOn="ReportSummary1"/>
  </Dictionary>
  <ReportPage Name="Page1" PaperWidth="148" PaperHeight="210" RawPaperSize="11" LeftMargin="10" TopMargin="10" RightMargin="10" BottomMargin="10" FirstPageSource="15" OtherPagesSource="15">
    <ReportTitleBand Name="ReportTitle1" Width="483.84" Height="140">
      <TextObject Name="txtTenQuan" Left="0" Top="5" Width="483.84" Height="25" Text="[TenQuan]" HorzAlign="Center" VertAlign="Center" Font="Arial, 14pt, style=Bold"/>
      <TextObject Name="txtTieuDe" Left="0" Top="35" Width="483.84" Height="25" Text="HÓA ĐƠN THANH TOÁN" HorzAlign="Center" VertAlign="Center" Font="Arial, 13pt, style=Bold"/>
      <TextObject Name="txtSoHD" Left="15" Top="75" Width="220" Height="20" Text="Số HĐ: [SoHD]" VertAlign="Center" Font="Arial, 10pt"/>
      <TextObject Name="txtNgayLap" Left="240" Top="75" Width="230" Height="20" Text="Ngày: [NgayLap]" HorzAlign="Right" VertAlign="Center" Font="Arial, 10pt"/>
      <TextObject Name="txtSoBan" Left="15" Top="100" Width="220" Height="20" Text="Bàn: [SoBan]" VertAlign="Center" Font="Arial, 10pt"/>
      <TextObject Name="txtHinhThuc" Left="240" Top="100" Width="230" Height="20" Text="Hình thức: [HinhThucTT]" HorzAlign="Right" VertAlign="Center" Font="Arial, 10pt"/>
    </ReportTitleBand>
    <PageHeaderBand Name="PageHeader1" Top="144" Width="483.84" Height="28">
      <TextObject Name="hdrSTT" Left="15" Top="0" Width="40" Height="28" Border.Lines="All" Border.Width="1" Text="STT" HorzAlign="Center" VertAlign="Center" Font="Arial, 9.5pt, style=Bold"/>
      <TextObject Name="hdrTenMon" Left="55" Top="0" Width="175" Height="28" Border.Lines="All" Border.Width="1" Text="Tên món" HorzAlign="Center" VertAlign="Center" Font="Arial, 9.5pt, style=Bold"/>
      <TextObject Name="hdrSL" Left="230" Top="0" Width="45" Height="28" Border.Lines="All" Border.Width="1" Text="SL" HorzAlign="Center" VertAlign="Center" Font="Arial, 9.5pt, style=Bold"/>
      <TextObject Name="hdrDonGia" Left="275" Top="0" Width="95" Height="28" Border.Lines="All" Border.Width="1" Text="Đơn giá" HorzAlign="Center" VertAlign="Center" Font="Arial, 9.5pt, style=Bold"/>
      <TextObject Name="hdrThanhTien" Left="370" Top="0" Width="100" Height="28" Border.Lines="All" Border.Width="1" Text="Thành tiền" HorzAlign="Center" VertAlign="Center" Font="Arial, 9.5pt, style=Bold"/>
    </PageHeaderBand>
    <DataBand Name="Data1" Top="176" Width="483.84" Height="24" DataSource="ChiTiet">
      <TextObject Name="cellSTT" Left="15" Top="0" Width="40" Height="24" Border.Lines="All" Border.Width="1" Text="[ChiTiet.STT]" HorzAlign="Center" VertAlign="Center" Font="Arial, 9.5pt"/>
      <TextObject Name="cellTenMon" Left="55" Top="0" Width="175" Height="24" Border.Lines="All" Border.Width="1" Padding="4, 1, 2, 1" Text="[ChiTiet.TenMon]" VertAlign="Center" Font="Arial, 9.5pt"/>
      <TextObject Name="cellSL" Left="230" Top="0" Width="45" Height="24" Border.Lines="All" Border.Width="1" Text="[ChiTiet.SoLuong]" HorzAlign="Center" VertAlign="Center" Font="Arial, 9.5pt"/>
      <TextObject Name="cellDonGia" Left="275" Top="0" Width="95" Height="24" Border.Lines="All" Border.Width="1" Padding="2, 1, 4, 1" Format="Custom" Format.Format="#,##0" Text="[ChiTiet.DonGia]" HorzAlign="Right" VertAlign="Center" Font="Arial, 9.5pt"/>
      <TextObject Name="cellThanhTien" Left="370" Top="0" Width="100" Height="24" Border.Lines="All" Border.Width="1" Padding="2, 1, 4, 1" Format="Custom" Format.Format="#,##0" Text="[ChiTiet.ThanhTien]" HorzAlign="Right" VertAlign="Center" Font="Arial, 9.5pt"/>
    </DataBand>
    <ReportSummaryBand Name="ReportSummary1" Top="204" Width="483.84" Height="80">
      <TextObject Name="lblTongCong" Left="180" Top="10" Width="110" Height="25" Text="Tổng cộng:" HorzAlign="Right" VertAlign="Center" Font="Arial, 11pt, style=Bold"/>
      <TextObject Name="valTongCong" Left="290" Top="10" Width="180" Height="25" Padding="2, 1, 4, 1" Format="Custom" Format.Format="#,##0" Text="[TongCong]" HorzAlign="Right" VertAlign="Center" Font="Arial, 11pt, style=Bold"/>
      <TextObject Name="txtCamOn" Left="0" Top="45" Width="483.84" Height="25" Text="Cảm ơn quý khách. Hẹn gặp lại!" HorzAlign="Center" VertAlign="Center" Font="Arial, 10pt, style=Italic"/>
    </ReportSummaryBand>
    <PageFooterBand Name="PageFooter1" Top="288" Width="483.84" Height="25">
      <TextObject Name="txtPageNumber" Left="0" Top="0" Width="483.84" Height="20" Text="Trang [Page#]/[TotalPages#]" HorzAlign="Center" VertAlign="Center" Font="Arial, 9pt"/>
    </PageFooterBand>
  </ReportPage>
</Report>
""";
        File.WriteAllText(duongDanFile, xmlContent);
    }
}
