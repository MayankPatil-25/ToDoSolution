using System.Collections.ObjectModel;
using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Maui.Core.Extensions;
using CommunityToolkit.Mvvm.Input;
using ToDoApp.Mobile.Common;
using ToDoApp.Mobile.Models;
using ToDoApp.Mobile.Services;
using ToDoApp.Mobile.Views;

namespace ToDoApp.Mobile.ViewModels;

public partial class ToDoListViewModel: BaseViewModel
{
    private List<ToDoItem> ToDoListMaster { get; set; } = new ();
    
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

    private ToDoFilter _selectedFilter;
    public ToDoFilter SelectedFilter
    {
        get => _selectedFilter;
        set
        {
            _selectedFilter = value;
            OnPropertyChanged(nameof(SelectedFilter));
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
    
    private ToDoFilter[] _filterOptions;
    public ToDoFilter[] FilterOptions
    {
        get => _filterOptions;
        set
        {
            _filterOptions = value; 
            OnPropertyChanged(nameof(FilterOptions));
        }
    }
    
    private readonly IToDoService _service;

    public ToDoListViewModel(IToDoService service)
    {
        _service = service;
        _filterOptions = Enum.GetValues(typeof(ToDoFilter)).Cast<ToDoFilter>().ToArray();
    }

    protected override void OnAppearing()
    {
        Task.Run(GetAllToDoItems);
        SelectedFilter = ToDoFilter.All;
    }
    
    [RelayCommand]
    private void AddToDo()
    {
        Navigate<AddToDoPage>();
    }

    [RelayCommand]
    private async Task ToDoItemLongPress(ToDoItem selectedItem)
    {
        if (CurrentPage == null) return;
        string[] options = selectedItem.IsCompleted ? ["Delete"] : ["Edit", "Delete"];
        var result = await CurrentPage.DisplayActionSheet("Please choose an action for the selected item.",
            "Cancel",
            null,
            options) ?? "";

        if (result == "Edit")
        {
            NavigateToUpdateToDoItem(selectedItem);
        }
        else if (result == "Delete")
        {
            await DeleteItemAsync(selectedItem);
        }
    }
    
    [RelayCommand]
    private async Task ToDoItemSelected(ToDoItem item)
    {
        if (CurrentPage == null) return;
        
        var page = new ToDoItemDetailPage(new ToDoItemDetailViewModel(item));
        await CurrentPage.Navigation.PushAsync(page, true);
    }
    
    [RelayCommand]
    private async Task ToDoCompletionSwitchToggled(ToDoItem updatedItem)
    {
        IsBusy = true;
        updatedItem.IsCompleted = !updatedItem.IsCompleted;
        var isUpdateSuccess = await _service.UpdateToDoAsync(updatedItem);
        var message = isUpdateSuccess
            ? "To do item status updated successfully."
            : "Something went wrong while updating the Todo item status.";
        await CurrentPage.DisplaySnackbar(message);
        IsBusy = false;
    }

    [RelayCommand]
    private async Task RefreshToDoList()
    {
        await GetAllToDoItemsAsync();
        IsRefreshing = false;
    }

    [RelayCommand]
    private void FilterToDoList(int selectedIndex)
    {
        SelectedFilter = FilterOptions[selectedIndex];
        FilterMasterList(SelectedFilter);
    }

    private async Task GetAllToDoItems()
    {
        IsBusy = true;
        await GetAllToDoItemsAsync();
        IsBusy = false;
    }

    private async Task GetAllToDoItemsAsync()
    {
        var list = await _service.GetAllToDoAsync();
        ToDoListMaster = list;
        FilterMasterList(SelectedFilter);
    }
    
    private void NavigateToUpdateToDoItem(ToDoItem selectedItem)
    {
        var viewModel = App.Services?.GetRequiredService<AddToDoViewModel>();
        if (viewModel == null) return;
        
        viewModel.NavigateData(selectedItem);
        CurrentPage?.Navigation?.PushAsync(new AddToDoPage(viewModel));
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
            await DisplayPopup("Alert","Something went wrong while deleting the Todo item.");
        }
        
        IsRefreshing = false;
        IsBusy = false;
    }
    
    private void FilterMasterList(ToDoFilter selectedFilter)
    {
        switch (selectedFilter)
        {
            case ToDoFilter.All:
                ToDoList = ToDoListMaster.ToObservableCollection();
                break;
            case ToDoFilter.Completed:
                ToDoList = ToDoListMaster.Where(item => item.IsCompleted).ToObservableCollection();
                break;
            case ToDoFilter.Pending:
                ToDoList = ToDoListMaster.Where(item => !item.IsCompleted).ToObservableCollection();
                break;
            default:
                ToDoList = ToDoListMaster.ToObservableCollection();
                break;
        }
    }
}