using System.Collections.ObjectModel;
using System.ComponentModel;
using ToDoApp.Mobile.Models;

namespace ToDoApp.Mobile.ViewModels;

public partial class ToDoListViewModel
{
    private ObservableCollection<ToDoItem> _toDoList = new ObservableCollection<ToDoItem>();
    public ObservableCollection<ToDoItem> ToDoList
    {
        get => _toDoList;
        set
        {
            _toDoList = value;
            OnPropertyChanged(nameof(ToDoList));
        }
    }
}