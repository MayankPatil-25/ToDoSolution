using System.Collections.ObjectModel;
using System.Linq;
using CommunityToolkit.Mvvm.Input;
using ToDoApp.Mobile.Common;
using ToDoApp.Mobile.Models;

namespace ToDoApp.Mobile.ViewModels;

public partial class ToDoListViewModel: BaseViewModel
{
    protected override void OnAppearing()
    {
        HasNavigationBar = false;
        Task.Run(LoadToDoList);
    }

    protected override void OnDisappearing()
    {
        
    }
    
    [RelayCommand]
    private async Task LoadToDoList()
    {
        IsBusy = true;
        ToDoList = [
            new ToDoItem(1, "Pick Up Santosh", DateTime.Today, ToDoPriority.High),
            new ToDoItem(2, "Finalise SDK Update docs", DateTime.Today, ToDoPriority.High),
            new ToDoItem(3, "Complete Pull request change request", DateTime.Today, ToDoPriority.High),
            new ToDoItem(4, "Family Dinner", DateTime.Today, ToDoPriority.Medium),
            new ToDoItem(5, "Weekend with friend", DateTime.Today, ToDoPriority.Low),
            new ToDoItem(6, "Groceries & Shopping on Weekend", DateTime.Today, ToDoPriority.Low),
            new ToDoItem(7, "SetUp Laptop with .NET 9", DateTime.Today, ToDoPriority.Medium),
            new ToDoItem(8, "Drop Santosh at HBF", DateTime.Today, ToDoPriority.High),
            new ToDoItem(9, "Complete Assignment ", DateTime.Today, ToDoPriority.High),
            new ToDoItem(10, "Assignment Docs", DateTime.Today, ToDoPriority.High),
            new ToDoItem(11, "Email Assignment", DateTime.Today, ToDoPriority.High)
        ];
        
        await Task.Delay(5000);
        
        IsBusy = false;
    }
}