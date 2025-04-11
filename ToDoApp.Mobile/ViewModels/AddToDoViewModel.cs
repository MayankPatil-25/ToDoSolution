using CommunityToolkit.Mvvm.Input;
using ToDoApp.Mobile.Common;
using ToDoApp.Mobile.Models;
using ToDoApp.Mobile.Services;

namespace ToDoApp.Mobile.ViewModels;

public partial class AddToDoViewModel : BaseViewModel
{
    private readonly IToDoService _service;
    private bool _isUpdatePage;
    private ToDoItem _selectedToDoItem;

    public AddToDoViewModel(IToDoService service)
    {
        _service = service;
        PriorityItems = Enum.GetValues(typeof(ToDoPriority)).Cast<ToDoPriority>().ToList();
        PageTitle = "Add ToDo";
    }

    public void NavigateData(ToDoItem selectedItem)
    {
        PageTitle = "Update ToDo";
        _isUpdatePage = true;
        _selectedToDoItem = selectedItem;
        ToDoTitle = selectedItem.Title;
        ToDoDescription = selectedItem.Description;
        DueDate = selectedItem.DueDate;
        TodoPriority = selectedItem.Priority;
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

        var isUpdateSuccess = false;
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
            await DisplayPopup("Success!", "The ToDo item was saved successfully.");
            await PageInstance.Navigation.PopAsync(true);
        }
        else
        {
            await DisplayPopup("Error!", "Unfortunately something went wrong. Unable to save the ToDo item.");
        }
    }

    private ToDoItem GetTodoItem()
    {
        if (_isUpdatePage)
        {
            return _selectedToDoItem.Update(ToDoTitle,
                DueDate,
                ToDoDescription,
                TodoPriority!.Value);
        }
        
        return new ToDoItem(0,
            ToDoTitle,
            DueDate,
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

        if (DueDate == null || DueDate <= MinDate)
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
        var isUpdated = _selectedToDoItem.Description != ToDoDescription.Trim()
                        || _selectedToDoItem.Title != ToDoTitle.Trim()
                        || _selectedToDoItem.Priority != TodoPriority
                        || _selectedToDoItem.DueDate != DueDate;
        return isUpdated;
    }
}