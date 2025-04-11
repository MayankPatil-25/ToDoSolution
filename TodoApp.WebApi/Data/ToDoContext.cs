using Microsoft.EntityFrameworkCore;
using TodoApp.WebApi.Models;

namespace TodoApp.WebApi.Data;

public class ToDoContext : DbContext
{
    public ToDoContext(DbContextOptions<ToDoContext> options) : base(options)
    {
    }

    public DbSet<ToDoItem> ToDoItems { get; set; }
}