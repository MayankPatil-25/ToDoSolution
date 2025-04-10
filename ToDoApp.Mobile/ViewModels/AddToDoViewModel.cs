using CommunityToolkit.Mvvm.Input;
using ToDoApp.Mobile.Common;
using ToDoApp.Mobile.Models;
using ToDoApp.Mobile.Services;

namespace ToDoApp.Mobile.ViewModels;

public partial class AddToDoViewModel : BaseViewModel
{
    private readonly IToDoService _service;

    public AddToDoViewModel(IToDoService service)
    {
        _service = service;
        PriorityItems = Enum.GetNames(typeof(ToDoPriority)).ToList();
    }

    protected override void OnAppearing()
    {
    }

    protected override void OnDisappearing()
    {
    }

    [RelayCommand]
    private void DateSelected(DateTime selectedDate)
    {
        DueDate = selectedDate;
    }

    [RelayCommand]
    private async Task CreateToDo()
    {
        if (TodoPriority == null)
        {
            await DisplayPopup("Alert", "Please select priority.");
            return;
        }

        if (DueDate == null || DueDate <= MinDate)
        {
            await DisplayPopup("Alert", "Please select a valid date.");
            return;
        }

        if (string.IsNullOrWhiteSpace(ToDoTitle))
        {
            await DisplayPopup("Alert", "Please select a valid title.");
            return;
        }

        var success = await _service.AddToDoAsync(new ToDoItem(0,
                                                        ToDoTitle,
                                                        DueDate,
                                                        ToDoDescription,
                                                        TodoPriority ?? ToDoPriority.Low));
        if (success)
        {
            await DisplayPopup("Success!", "ToDo item created successfully.");
        }
        else
        {
            await DisplayPopup("Error!", "Unfortunately something went wrong. Unable to create a ToDo item.");
        }
    }
}