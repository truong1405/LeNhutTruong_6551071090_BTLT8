namespace QuanCaPhe;

static class Program
{
    /// <summary>
    ///  The main entry point for the application.
    /// </summary>
    [STAThread]
    static void Main(string[] args)
    {
        var viCulture = new System.Globalization.CultureInfo("vi-VN");
        System.Globalization.CultureInfo.DefaultThreadCurrentCulture = viCulture;
        System.Globalization.CultureInfo.DefaultThreadCurrentUICulture = viCulture;
        Thread.CurrentThread.CurrentCulture = viCulture;
        Thread.CurrentThread.CurrentUICulture = viCulture;

        ApplicationConfiguration.Initialize();

        if (args.Length > 0 && args[0] == "--test")
        {
            TestRunner.RunTestsAsync().GetAwaiter().GetResult();
            return;
        }

        if (args.Length > 0 && args[0] == "--capture")
        {
            Application.Run(new Forms.FormHoaDon(isCaptureMode: true));
            return;
        }

        Application.Run(new Forms.FormHoaDon());
    }    
}