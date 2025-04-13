using TodoApp.WebApi.Models;

namespace ToDoApp.WebApiTests.Data;

public static class TestData
{
    public static List<ToDoItem> GetTestTodos() =>
    [
        new ToDoItem { Id = 1, Title = "Test 1", IsCompleted = false },
        new ToDoItem { Id = 2, Title = "Test 2", IsCompleted = true }
    ];
}