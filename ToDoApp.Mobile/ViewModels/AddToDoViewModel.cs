using CommunityToolkit.Mvvm.ComponentModel;
using ToDoApp.Mobile.Common;
using ToDoApp.Mobile.Models;

namespace ToDoApp.Mobile.ViewModels;

public partial class AddToDoViewModel : BaseViewModel
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
    
    private DateTime _dueDate;
    public DateTime DueDate
    {
        get => _dueDate;
        set
        {
            _dueDate = value;
            OnPropertyChanged(nameof(DueDate));
        }
    }
    
    private ToDoPriority _todoPriority = ToDoPriority.Low;
    public ToDoPriority TodoPriority
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

    public AddToDoViewModel()
    {
        PriorityItems = Enum.GetNames(typeof(ToDoPriority)).ToList();
    }

    protected override void OnAppearing()
    {
        
    }

    protected override void OnDisappearing()
    {
        
    }
}