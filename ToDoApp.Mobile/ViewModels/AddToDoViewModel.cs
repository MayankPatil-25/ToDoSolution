using CommunityToolkit.Mvvm.Input;
using ToDoApp.Mobile.Common;
using ToDoApp.Mobile.Models;
using ToDoApp.Mobile.Services;

namespace ToDoApp.Mobile.ViewModels;

public partial class AddToDoViewModel : BaseViewModel
{
    private readonly IToDoService _service;
    private bool _isUpdatePage;
    private ToDoItem? _selectedToDoItem;

    public AddToDoViewModel(IToDoService service)
    {
        _service = service;
        _priorityItems = Enum.GetValues(typeof(ToDoPriority)).Cast<ToDoPriority>().ToList();
        PageTitle = "Add Todo";
        ButtonSubmitTitle = "Submit";
        DueDate = MinDate;
    }

    public void NavigateData(ToDoItem selectedItem)
    {
        PageTitle = "Update Todo";
        ButtonSubmitTitle = "Update";
        _isUpdatePage = true;
        _selectedToDoItem = selectedItem;
        ToDoTitle = selectedItem.Title;
        ToDoDescription = selectedItem.Description;
        DueDate = selectedItem.DueDate;
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        TodoPriority = _selectedToDoItem?.Priority ?? ToDoPriority.Low;
    }

    [RelayCommand]
    private void DateSelected(DateTime selectedDate)
    {
        DueDate = selectedDate;
    }

    [RelayCommand]
    private async Task CreateToDo()
    {
        if (!await IsFormValid())
        {
            return;
        }

        bool isUpdateSuccess;
        var todoItem = GetTodoItem();
        
        if (_isUpdatePage)
        {
            isUpdateSuccess = await _service.UpdateToDoAsync(todoItem);
        }
        else
        {
            isUpdateSuccess = await _service.AddToDoAsync(todoItem);
        }

        if (isUpdateSuccess)
        {
            await DisplayPopup("Success!", "The Todo item was saved successfully.");
            if (CurrentPage == null) return;
            await CurrentPage.Navigation.PopAsync(true);
        }
        else
        {
            await DisplayPopup("Error!", "Unfortunately something went wrong. Unable to save the Todo item.");
        }
    }

    private ToDoItem GetTodoItem()
    {
        if (_isUpdatePage)
        {
            return _selectedToDoItem!.Update(ToDoTitle,
                DueDate!.Value,
                ToDoDescription,
                TodoPriority!.Value);
        }
        
        return new ToDoItem(0,
            ToDoTitle,
            DueDate!.Value,
            ToDoDescription,
            TodoPriority ?? ToDoPriority.Low);
    }

    private async Task<bool> IsFormValid()
    {
        if (_isUpdatePage && !IsItemUpdated())
        {
            await DisplayPopup("Alert", "There were no updates made for this item.");
            return false;
        }
        
        if (TodoPriority == null)
        {
            await DisplayPopup("Alert", "Please select priority.");
            return false;
        }

        if (DueDate == null)
        {
            await DisplayPopup("Alert", "Please select a valid date.");
            return false;
        }

        if (string.IsNullOrWhiteSpace(ToDoTitle))
        {
            await DisplayPopup("Alert", "Please select a valid title.");
            return false;
        }

        return true;
    }

    private bool IsItemUpdated()
    {
        if (_selectedToDoItem == null)
            return false;
        
        var isUpdated = _selectedToDoItem.Description != ToDoDescription.Trim()
                        || _selectedToDoItem.Title != ToDoTitle.Trim()
                        || _selectedToDoItem.Priority != TodoPriority
                        || _selectedToDoItem.DueDate != DueDate;
        return isUpdated;
    }
}