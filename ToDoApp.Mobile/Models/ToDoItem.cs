using ToDoApp.Mobile.Common;

namespace ToDoApp.Mobile.Models;

public class ToDoItem
{
    public ToDoItem()
    {
        DueDate = DateTime.Today;
        Priority = ToDoPriority.Low;
        Title = string.Empty;
        Description = string.Empty;
    }
    
    public ToDoItem(int id, string title, DateTime? dueDate, string description = "" , ToDoPriority priority = ToDoPriority.Low)
    {
        Id = id;
        DueDate = dueDate;
        Priority = priority;
        Title = title;
        Description = description;
    }

    public int Id { get; set; }

    public string Title { get; set; }
    
    public string Description { get; set; }
    
    public bool IsCompleted { get; set; } = false;
    
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    
    public DateTime? DueDate { get; set; }

    public DateTime? CompletedAt { get; set; }

    public ToDoPriority Priority { get; set; }
    
    public string DisplayPriority => Priority.ToString();

    public string DisplayCreatedAtDate => CreatedAt.ToString("D");
}