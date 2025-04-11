using Microsoft.AspNetCore.Mvc;
using TodoApp.WebApi.Models;

namespace TodoApp.WebApi.Services;

public interface IToDoService
{
    /// <summary>
    /// Get all the ToDoItems list.
    /// </summary>
    /// <returns>Returns all the available IEnumerable of TodoItem objects.</returns>
    Task<List<ToDoItem>> GetAllToDoItemsAsync();
    
    /// <summary>
    /// Creates a new record for ToDoItem object.
    /// </summary>
    /// <param name="item">TodoItem object item</param>
    /// <returns>Returns a newly created ToDoItem object.</returns>
    Task<ToDoItem> CreateToDoItemAsync(ToDoItem item);

    /// <summary>
    /// Finds a ToDoItem object from id. 
    /// </summary>
    /// <param name="id">ToDoItem object id.</param>
    /// <returns>Returns full object if item was found in the database.</returns>
    Task<ToDoItem?> GetToDoItemAsync(int id);

    /// <summary>
    /// Updates a new ToDoItem object.
    /// </summary>
    /// <param name="item">Updated ToDoItem object.</param>
    /// <returns>Returns the updated object.</returns>
    Task<ToDoItem?> UpdateToDoItemAsync(ToDoItem item);

    /// <summary>
    /// Delete the ToDoItem object found by id.
    /// </summary>
    /// <param name="id">Id of the particular ToDoItem object.</param>
    /// <returns>Returns a boolean flag to indicate success if true else failure if false.</returns>
    Task<bool> DeleteToDoItemAsync(int id);
}