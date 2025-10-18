using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using AvaloniaApplication1.Models;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace AvaloniaApplication1.ViewModels;

public partial class Window1ViewModel : ViewModelBase
{
    private string _title = "Window1";
    private string _content = "Window1Content";

    public string Title
    {
        get => _title;
        set => SetProperty(ref _title, value);
    }

    public string Content
    {
        get => _content;
        set => SetProperty(ref _content, value);
    }
    [ObservableProperty] private ObservableCollection<People> _peoples;
    [ObservableProperty] private string _selectedItem;

    /// <summary>
    /// 选择改变
    /// </summary>
    /// <param name="value"></param>
    partial void OnSelectedItemChanged(string value)
    {
        // 当选择项改变时自动触发
        if (!string.IsNullOrEmpty(value))
        {
            // 处理选择逻辑
            Console.WriteLine($"选中了: {value}");
        }
    }

    public Window1ViewModel()
    {
        Title = "Window1";
        Content = "Window1Content";
        Books = new ObservableCollection<string>()
        {
            "Book1",
            "Book2",
            "Book3",
            "Book4",
        };
        _peoples = new ObservableCollection<People>()
        {
            new People(){ Name="张三", Des="可恶"},
            new People(){ Name="张五", Des="可恶"},
        };
    }

    public ObservableCollection<string> Books { get; set; }

    [ObservableProperty]
    private People _selectPeople;
    [RelayCommand]
    private void Click1()
    {
        this.Content = "改变" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
    }
    [RelayCommand]
    private void Click1ListBox(object obj)
    {

    }
    [RelayCommand]
    private void DoubleClick()
    {
        Debug.Write("双击");
    }
    [RelayCommand]
    private void SelectChanged(object obj)
    {
        if (obj is People p)
        {
            _selectPeople = p;
            _selectedIndex = Peoples.IndexOf(_selectPeople);
        }
        Debug.WriteLine("选中");
    }
    [RelayCommand]
    private void OnDelete()
    {
        if (_selectPeople != null)
        {
            _peoples.Remove(_selectPeople);
            _selectPeople = null;
        }
        else
        {
            if (_selectedIndex != -1 && Peoples.Count >= _selectedIndex + 1)
            {
                _peoples.RemoveAt(_selectedIndex);
            }
        }
        Debug.WriteLine("菜单");

    }
    [ObservableProperty]
    private int _selectedIndex = -1;

}