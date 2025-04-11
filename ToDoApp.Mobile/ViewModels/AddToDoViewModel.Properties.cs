using ToDoApp.Mobile.Common;

namespace ToDoApp.Mobile.ViewModels;

public partial class AddToDoViewModel
{
    private string _pageTitle = string.Empty;
    public string PageTitle
    {
        get => _pageTitle;
        set
        {
            _pageTitle = value;
            OnPropertyChanged(nameof(PageTitle));
        }
    }
    
    private string _buttonSubmitTitle = string.Empty;
    public string ButtonSubmitTitle
    {
        get => _buttonSubmitTitle;
        set
        {
            _buttonSubmitTitle = value;
            OnPropertyChanged(nameof(ButtonSubmitTitle));
        }
    }
    
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

    private DateTime _minDate = DateTime.Now.AddDays(1);
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
    
    private List<ToDoPriority> _priorityItems;
    public List<ToDoPriority> PriorityItems
    {
        get => _priorityItems;
        set
        {
            _priorityItems = value;
            OnPropertyChanged(nameof(PriorityItems));
        }
    }

    private int _toDoPickerSelectedIndex = 0;

    public int ToDoPickerSelectedIndex
    {
        get => _toDoPickerSelectedIndex;
        set
        {
            _toDoPickerSelectedIndex = value;
            OnPropertyChanged(nameof(ToDoPickerSelectedIndex));
        }
    }
}