using System.Collections.ObjectModel;
using System.Linq;
using CommunityToolkit.Mvvm.Input;
using ToDoApp.Mobile.Common;
using ToDoApp.Mobile.Models;
using ToDoApp.Mobile.Views;

namespace ToDoApp.Mobile.ViewModels;

public partial class ToDoListViewModel: BaseViewModel
{
    private ObservableCollection<ToDoItem> _toDoList = new ObservableCollection<ToDoItem>();
    public ObservableCollection<ToDoItem> ToDoList
    {
        get => _toDoList;
        set
        {
            _toDoList = value;
            OnPropertyChanged(nameof(ToDoList));
        }
    }

    private bool _isRefreshing;
    public bool IsRefreshing
    {
        get => _isRefreshing;
        set
        {
            _isRefreshing = value; 
            OnPropertyChanged(nameof(IsRefreshing));
        }
    }

    protected override void OnAppearing()
    {
        HasNavigationBar = false;
        Task.Run(RefreshToDoList);
    }

    protected override void OnDisappearing()
    {
        
    }
    
    [RelayCommand]
    private async Task RefreshToDoList()
    {
        IsRefreshing = true;
        IsBusy = true;
        ToDoList = [
            new ToDoItem(1, "Pick Up Santosh",  DateTime.Today, priority: ToDoPriority.High),
            new ToDoItem(2, "Finalise SDK Update docs", DateTime.Today, priority:ToDoPriority.High),
            new ToDoItem(3, "Complete Pull request change request", DateTime.Today, priority:ToDoPriority.High),
            new ToDoItem(4, "Family Dinner", DateTime.Today, priority:ToDoPriority.Medium),
            new ToDoItem(5, "Weekend with friend", DateTime.Today, priority:ToDoPriority.Low),
            new ToDoItem(6, "Groceries & Shopping on Weekend", DateTime.Today,priority: ToDoPriority.Low),
            new ToDoItem(7, "SetUp Laptop with .NET 9", DateTime.Today, priority:ToDoPriority.Medium),
            new ToDoItem(8, "Drop Santosh at HBF", DateTime.Today, priority:ToDoPriority.High),
            new ToDoItem(9, "Complete Assignment ", DateTime.Today, priority:ToDoPriority.High),
            new ToDoItem(10, "Assignment Docs", DateTime.Today, priority:ToDoPriority.High),
            new ToDoItem(11, "Email Assignment", DateTime.Today, priority:ToDoPriority.High)
        ];
        
        await Task.Delay(5000);
        IsRefreshing = false;
        IsBusy = false;
    }

    [RelayCommand]
    private void AddToDo()
    {
        App.Current.MainPage.Navigation.PushAsync(new AddToDoPage());
    }
}