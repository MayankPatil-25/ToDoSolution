using System.Collections.ObjectModel;
using ToDoApp.Mobile.Models;

namespace ToDoApp.Mobile.ViewModels;

public partial class ToDoItemDetailViewModel : BaseViewModel
{
    private ObservableCollection<FieldDetailModel> _toDoItemFields;

    public ObservableCollection<FieldDetailModel> ToDoItemFields
    {
        get => _toDoItemFields;
        set
        {
            _toDoItemFields = value;
            OnPropertyChanged(nameof(ToDoItemFields));
        }
    }

    public ToDoItemDetailViewModel(ToDoItem selectedItem)
    {
        ToDoItemFields =
        [
            new(nameof(selectedItem.Title), selectedItem.Title),
            new(nameof(selectedItem.Description), selectedItem.Description),
            new(nameof(selectedItem.Priority), selectedItem.Priority.ToString()),
            new("Created date", selectedItem.DisplayCreatedAtDate),
            new("Due date", selectedItem.DisplayDueDate),
            new("Status", selectedItem.IsCompleted ? "Completed" : "Pending")
        ];
    }
}