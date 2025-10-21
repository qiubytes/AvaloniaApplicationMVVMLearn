using System.Collections.ObjectModel;
using System.IO;
using Avalonia.Media.Imaging;
using AvaloniaApplication1.Models;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace AvaloniaApplication1.ViewModels;

public partial class WindowBindSelfViewModel : ViewModelBase
{
    public ObservableCollection<People> Peoples { get; set; }

    /// <summary>
    /// 图片绑定
    /// </summary>
    [ObservableProperty]
    public Bitmap _img;
    public WindowBindSelfViewModel()
    {
        Peoples = new ObservableCollection<People>()
        {
            new People() { Name = "张三", Des = "123" },
            new People() { Name = "李四", Des = "235" }
        };
        _img = new Bitmap(new MemoryStream(File.ReadAllBytes(@"C:\Users\Lenovo\Downloads\微信图片_20250425143617.png")));
    }

    [RelayCommand]
    public void ItemButtonClick(object? obj)
    {
        
    }
}