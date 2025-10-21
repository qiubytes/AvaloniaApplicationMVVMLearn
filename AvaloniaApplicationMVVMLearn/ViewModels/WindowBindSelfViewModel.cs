using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using Avalonia.Media.Imaging;
using Avalonia.Threading;
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
    [ObservableProperty] public Bitmap _img;

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

    /// <summary>
    /// 异步绑定
    /// </summary>
    public Task<string> MyText => GetTextAsync();

    public async Task<string> GetTextAsync()
    {
        await Task.Delay(3000);
        return "Hello World";
    }

    [RelayCommand]
    public async Task GetImageBtnClick()
    {
        using (HttpClient client = new HttpClient())
        {
            HttpResponseMessage responseMessage =
                await client.GetAsync(new Uri("https://www.baidu.com/img/PCtm_d9c8750bed0b3c7d089fa7d55720d6cf.png"));
            responseMessage.EnsureSuccessStatusCode();
            Stream stream = await responseMessage.Content.ReadAsStreamAsync();
            // _img = new Bitmap(stream);
            Dispatcher.UIThread.Post(() =>
            {
                Img?.Dispose();//Img 会自动引发 PropertyChanged 事件，_img则不能
                Img = new Bitmap(stream);
            });
        }
    }
}