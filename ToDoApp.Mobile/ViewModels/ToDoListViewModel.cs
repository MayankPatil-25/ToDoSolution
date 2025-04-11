using System.Collections.ObjectModel;
using System.Linq;
using CommunityToolkit.Mvvm.Input;
using ToDoApp.Mobile.Common;
using ToDoApp.Mobile.Models;
using ToDoApp.Mobile.Services;
using ToDoApp.Mobile.Views;

namespace ToDoApp.Mobile.ViewModels;

public partial class ToDoListViewModel: BaseViewModel
{
    private ObservableCollection<ToDoItem> _toDoList = new ();
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

    private readonly IToDoService _service;

    public ToDoListViewModel(IToDoService service)
    {
        _service = service;
    }

    protected override void OnAppearing()
    {
        Task.Run(RefreshToDoList);
    }
    
    [RelayCommand]
    private void AddToDo()
    {
        Navigate<AddToDoPage>();
    }

    [RelayCommand]
    private async Task ToDoItemLongPress(ToDoItem selectedItem)
    {
        var result = await PageInstance.DisplayActionSheet("Please select an action for the selected item?",
            "Cancel",
            "Skip",
            ["Edit", "Delete"]) ?? "";

        if (result == "Edit")
        {
            NavigateToUpdateToDoItem(selectedItem);
        }
        else if (result == "Delete")
        {
            await DeleteItemAsync(selectedItem);
        }
    }

    private void NavigateToUpdateToDoItem(ToDoItem selectedItem)
    {
        var viewModel = App.Services?.GetRequiredService<AddToDoViewModel>();
        if (viewModel != null)
        {
            viewModel.NavigateData(selectedItem);
            PageInstance.Navigation.PushAsync(new AddToDoPage(viewModel));
        }
    }

    [RelayCommand]
    private async Task RefreshToDoList()
    {
        IsBusy = true;

        var list = await _service.GetAllToDoAsync();
        ToDoList = new(list);
        
        IsRefreshing = false;
        IsBusy = false;
    }

    private async Task DeleteItemAsync(ToDoItem selectedItem)
    {
        IsBusy = true;

        var deleted = await _service.DeleteToDoAsync(selectedItem.Id);
        if (deleted)
        {
            ToDoList.Remove(selectedItem);
        }
        else
        {
            await DisplayPopup("Alert","Something went wrong while deleting the ToDo item.");
        }
        
        IsRefreshing = false;
        IsBusy = false;
    }
}