using System.ComponentModel.DataAnnotations;
using TodoApp.WebApi.Common;

namespace TodoApp.WebApi.Models;

public class ToDoItem
{
    public int Id { get; set; }
    
    [Required]
    [MaxLength(50)]
    public string Title { get; set; } = string.Empty;
    
    [Required]
    [MaxLength(200)]
    public string Description { get; set; } = string.Empty;
    
    public ToDoPriority Priority { get; set; }
    
    public bool IsCompleted { get; set; } = false;
    
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    
    public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
    
    
    public DateTime? DueDate { get; set; }
}