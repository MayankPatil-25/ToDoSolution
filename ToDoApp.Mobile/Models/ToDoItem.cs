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

    public ToDoItem(int id, string title, DateTime dueDate, string description = "", ToDoPriority priority = ToDoPriority.Low)
    {
        Id = id;
        DueDate = dueDate;
        Priority = priority;
        Title = title;
        Description = description;
    }
    
    public ToDoItem Update(string title, DateTime dueDate, string description, ToDoPriority priority)
    {
        DueDate = dueDate;
        Priority = priority;
        Title = title;
        Description = description ?? "";
        
        return this;
    }

    public int Id { get; set; }

    public string Title { get; set; }

    public string Description { get; set; }

    public bool IsCompleted { get; set; } = false;

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    public DateTime DueDate { get; set; } = DateTime.UtcNow;
    
    public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

    public ToDoPriority Priority { get; set; }

    public string DisplayPriority => $"{nameof(Priority)}: {Priority.ToString()}";

    public string DisplayCreatedAtDate => CreatedAt.ToString("D");

    public string DisplayDueDate => DueDate.ToString("D");

    public string PriorityIndicator => Priority switch
    {
        ToDoPriority.Low => Colors.Yellow.ToHex(),
        ToDoPriority.Medium => Colors.Orange.ToHex(),
        ToDoPriority.High => Colors.DarkRed.ToHex(),
        _ => Colors.White.ToHex()
    };
}