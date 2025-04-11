using ToDoApp.Mobile.Models;

namespace ToDoApp.Mobile.Services;

public interface IToDoService
{
    public Task<List<ToDoItem>> GetAllToDoAsync();

    public Task<ToDoItem?> GetToDoByIdAsync(int id);

    public Task<bool> AddToDoAsync(ToDoItem item);

    public Task<bool> UpdateToDoAsync(ToDoItem item);

    public Task<bool> DeleteToDoAsync(int id);
}