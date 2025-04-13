using System.Collections.ObjectModel;
using ToDoApp.Mobile.Models;

namespace ToDoApp.Mobile.ViewModels;

public class ToDoItemDetailViewModel : BaseViewModel
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
        _toDoItemFields =
        [
            new FieldDetailModel(nameof(selectedItem.Title), selectedItem.Title),
            new FieldDetailModel(nameof(selectedItem.Description), selectedItem.Description),
            new FieldDetailModel(nameof(selectedItem.Priority), selectedItem.Priority.ToString()),
            new FieldDetailModel("Created date", selectedItem.DisplayCreatedAtDate),
            new FieldDetailModel("Due date", selectedItem.DisplayDueDate),
            new FieldDetailModel("Status", selectedItem.IsCompleted ? "Completed" : "Pending")
        ];
    }
}