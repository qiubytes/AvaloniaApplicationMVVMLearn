using System.Collections.ObjectModel;
using AvaloniaApplication1.Models;
using CommunityToolkit.Mvvm.Input;

namespace AvaloniaApplication1.ViewModels;

public partial class WindowBindSelfViewModel : ViewModelBase
{
    public ObservableCollection<People> Peoples { get; set; }

    public WindowBindSelfViewModel()
    {
        Peoples = new ObservableCollection<People>()
        {
            new People() { Name = "张三", Des = "123" },
            new People() { Name = "李四", Des = "235" }
        };
    }

    [RelayCommand]
    public void ItemButtonClick(object? obj)
    {
        
    }
}