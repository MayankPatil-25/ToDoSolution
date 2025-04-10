using ToDoApp.Mobile.Common;

namespace ToDoApp.Mobile.ViewModels;

public partial class AddToDoViewModel
{
    private string _todoTitle = string.Empty;
    public string ToDoTitle
    {
        get => _todoTitle;
        set
        {
            _todoTitle = value;
            OnPropertyChanged(nameof(ToDoTitle));
        }
    }

    private string _todoDescription = string.Empty;
    public string ToDoDescription
    {
        get => _todoDescription;
        set
        {
            _todoDescription = value;
            OnPropertyChanged(nameof(ToDoDescription));
        }
    }

    private DateTime _minDate = DateTime.Now;
    public DateTime MinDate
    {
        get => _minDate;
        set
        {
            _minDate = value;
            OnPropertyChanged(nameof(MinDate));
        }
    }
    
    private DateTime? _dueDate;
    public DateTime? DueDate
    {
        get => _dueDate;
        set
        {
            _dueDate = value;
            OnPropertyChanged(nameof(DueDate));
        }
    }
    
    private ToDoPriority? _todoPriority = ToDoPriority.Low;
    public ToDoPriority? TodoPriority
    {
        get => _todoPriority;
        set
        {
            _todoPriority = value;
            OnPropertyChanged(nameof(TodoPriority));
            
        }
    }
    
    private List<string> _priorityItems;
    public List<string> PriorityItems
    {
        get => _priorityItems;
        set
        {
            _priorityItems = value;
            OnPropertyChanged(nameof(PriorityItems));
        }
    }
}