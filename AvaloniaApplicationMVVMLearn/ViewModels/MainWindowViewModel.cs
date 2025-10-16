using System.Collections.ObjectModel;
using System.Diagnostics;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.ApplicationLifetimes;
using AvaloniaApplication1.Views;
using CommunityToolkit.Mvvm.Input;
using NLog;

namespace AvaloniaApplication1.ViewModels;

public partial class MainWindowViewModel : ViewModelBase
{
    private static readonly Logger Logger = LogManager.GetCurrentClassLogger();

#pragma warning disable CA1822 // Mark members as static
    public string Greeting => "Welcome to Avalonia!";
    public string Hello => "Hello from Avalonia!";

    public ObservableCollection<string> Items { get; } = new()
    {
        "选项1", "选项2", "选项3", "选项4", "选项5", "选项5", "选项5", "选项5"
    };

    [RelayCommand]
    public void Clicked1()
    {
        Logger.Info("开始执行点击事件");
        Debug.Write("点击clicked1");
        var t = 0;
        var q = 100 / t;
        Logger.Info("点击事件执行完毕");
    }

    [RelayCommand]
    public void ClickedOpenWindow()
    {
        if (Application.Current?.ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
        {
            Window t = desktop.MainWindow;
            // 创建新的主窗口
            var loginWindow = new Window1(){DataContext = new Window1ViewModel()};
            
            // 替换主窗口
            desktop.MainWindow = loginWindow;
            
            // 显示新窗口
            loginWindow.Show();
            
            // 关闭当前窗口
            t.Close();
        }
    }
#pragma warning restore CA1822 // Mark members as static

    #region 操作

    /// <summary>
    /// 加载
    /// </summary>
    //private void Window_Loaded(object sender, RoutedEventArgs e)
    [RelayCommand]
    //private void Loaded(RoutedEventArgs e)
    private void Loaded()
    {
        Debug.WriteLine("Loaded");
    }

    /// <summary>
    /// 关闭
    /// </summary>
    [RelayCommand]
    private void Closed()
    {
        Debug.WriteLine("Closed");
    }

    [RelayCommand]
    private void Closing()
    {
        Debug.WriteLine("Closing");
    }

    [RelayCommand]
    private void DoubleClick(object? item)
    {
        Debug.Write("双击");
    }

    #endregion 操作
}