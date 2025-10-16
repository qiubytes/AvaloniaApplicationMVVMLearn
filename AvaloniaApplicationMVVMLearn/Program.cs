using Avalonia;
using System;
using System.IO;
using NLog;

namespace AvaloniaApplication1;

sealed class Program
{
    // Initialization code. Don't use any Avalonia, third-party APIs or any
    // SynchronizationContext-reliant code before AppMain is called: things aren't initialized
    // yet and stuff might break.
    // [STAThread]
    // public static void Main(string[] args) => BuildAvaloniaApp()
    //     .StartWithClassicDesktopLifetime(args);
    private static readonly Logger Logger = LogManager.GetCurrentClassLogger();

    [STAThread]
    public static void Main(string[] args)
    {
        // 初始化日志目录
        EnsureLogDirectory();

        // 记录启动信息
        Logger.Info("应用程序启动");
        try
        {
            BuildAvaloniaApp().StartWithClassicDesktopLifetime(args);
        }
        catch (Exception ex)
        {
            Logger.Fatal(ex, $"应用程序错误：{ex.Message}");
            Logger.Fatal(ex, $"应用程序错误堆栈：{ex.StackTrace}");
        }
    }

    /// <summary>
    /// 确定日志目录
    /// </summary>
    private static void EnsureLogDirectory()
    {
        var logDir = "logs";
        if (!Directory.Exists(logDir))
            Directory.CreateDirectory(logDir);
    }

    // Avalonia configuration, don't remove; also used by visual designer.
    public static AppBuilder BuildAvaloniaApp()
        => AppBuilder.Configure<App>()
            .UsePlatformDetect()
            .WithInterFont()
            .LogToTrace();
}