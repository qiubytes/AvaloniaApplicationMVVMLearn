using Avalonia.Controls;
using Avalonia.Interactivity;

namespace AvaloniaApplication1.Views;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
    }

    private void Button_OnClick(object? sender, RoutedEventArgs e)
    {
        Txt1.Text = "已点击";
        var t = 0;
        var q = 100/ t;
    }
}