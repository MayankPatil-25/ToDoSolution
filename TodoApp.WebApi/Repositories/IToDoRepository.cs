using TodoApp.WebApi.Models;

namespace TodoApp.WebApi.Repositories;

public interface IToDoRepository
{    
    Task<List<ToDoItem>> GetAllToDoItemsAsync();
    
    Task<ToDoItem> CreateToDoItemAsync(ToDoItem item);
    
    Task<ToDoItem?> GetToDoItemAsync(int id);
    
    Task<ToDoItem?> UpdateToDoItemAsync(ToDoItem item);
    
    Task<bool> DeleteToDoItemAsync(int id);
}