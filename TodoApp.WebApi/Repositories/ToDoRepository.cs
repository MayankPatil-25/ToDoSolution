using Microsoft.EntityFrameworkCore;
using TodoApp.WebApi.Data;
using TodoApp.WebApi.Models;

namespace TodoApp.WebApi.Repositories;

public class ToDoRepository: IToDoRepository
{
    private readonly ToDoContext _context;

    public ToDoRepository(ToDoContext context)
    {
        _context = context;
    }

    public async Task<ToDoItem> CreateToDoItemAsync(ToDoItem todoItem)
    {
        await _context.ToDoItems.AddAsync(todoItem);   
        await _context.SaveChangesAsync();
        return todoItem;
    }
    
    public async Task<List<ToDoItem>> GetAllToDoItemsAsync()
    {
        return await _context.ToDoItems.ToListAsync();
    }
    
    public async Task<ToDoItem?> GetToDoItemAsync(int todoItemId)
    {
        return await _context.ToDoItems.FirstOrDefaultAsync(field => field.Id == todoItemId);
    }
    
    public async Task<ToDoItem?> UpdateToDoItemAsync(ToDoItem todoItem)
    {
        var savedToDoItem = await _context.ToDoItems.FirstOrDefaultAsync(field => field.Id == todoItem.Id);

        if (savedToDoItem == null)
        {
            return null;
        }
        
        if (!string.IsNullOrEmpty(todoItem.Title))
            savedToDoItem.Title = todoItem.Title;
        
        if (!string.IsNullOrEmpty(todoItem.Description))
            savedToDoItem.Description = todoItem.Description;

        savedToDoItem.Priority = todoItem.Priority;
        savedToDoItem.IsCompleted = todoItem.IsCompleted;
        savedToDoItem.DueDate = todoItem.DueDate;
        savedToDoItem.UpdatedAt = DateTime.UtcNow;
        
        _context.Update(savedToDoItem);
        await _context.SaveChangesAsync();
        return savedToDoItem;
    }

    public async Task<bool> DeleteToDoItemAsync(int id)
    {
        var todoItem = await GetToDoItemAsync(id);
        if (todoItem == null)
        {
            return false;
        }

        _context.ToDoItems.Remove(todoItem);
        await _context.SaveChangesAsync();
        return true;
    }
}