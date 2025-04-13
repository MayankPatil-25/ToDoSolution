using TodoApp.WebApi.Models;
using TodoApp.WebApi.Repositories;

namespace TodoApp.WebApi.Services;

public class ToDoService: IToDoService
{
    private readonly IToDoRepository _todoRepository;

    public ToDoService(IToDoRepository repository)
    {
        _todoRepository = repository;
    }

    public async Task<ToDoItem> CreateToDoItemAsync(ToDoItem item)
    {
        return await _todoRepository.CreateToDoItemAsync(item);
    }
    
    public async Task<List<ToDoItem>> GetAllToDoItemsAsync()
    {
        return await _todoRepository.GetAllToDoItemsAsync();
    }
    
    public async Task<ToDoItem?> GetToDoItemAsync(int id)
    {
        return await _todoRepository.GetToDoItemAsync(id);
    }

    public async Task<ToDoItem?> UpdateToDoItemAsync(ToDoItem item)
    {
        return await _todoRepository.UpdateToDoItemAsync(item);
    }
    
    public async Task<bool> DeleteToDoItemAsync(int id)
    {
        return await _todoRepository.DeleteToDoItemAsync(id);
    }
}