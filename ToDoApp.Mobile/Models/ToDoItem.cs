using ToDoApp.Mobile.Common;

namespace ToDoApp.Mobile.Models;

public class ToDoItem
{
    public ToDoItem(int id, string title, DateTime? dueDate, ToDoPriority priority)
    {
        Id = id;
        DueDate = dueDate;
        Priority = priority;
        Title = title;
    }

    public int Id { get; set; }

    public string Title { get; set; }
    
    public bool IsCompleted { get; set; } = false;
    
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    
    public DateTime? DueDate { get; set; }

    public DateTime? CompletedAt { get; set; }

    public ToDoPriority Priority { get; set; }
    
    public string DisplayPriority => Priority.ToString();

    public string DisplayCreatedAtDate => CreatedAt.ToString("D");
}