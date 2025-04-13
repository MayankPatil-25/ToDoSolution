using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using Moq;
using TodoApp.WebApi.Common;
using TodoApp.WebApi.Controllers;
using TodoApp.WebApi.Data;
using TodoApp.WebApi.Models;
using TodoApp.WebApi.Repositories;
using TodoApp.WebApi.Services;
using ToDoApp.WebApiTests.Data;

namespace ToDoApp.WebApiTests;

public class ToDoControllerTests
{
    private string databaseName => Guid.NewGuid().ToString(); 
    
    [Fact]
    public async Task CreateToDoItemAsync_ReturnsCreatedAtAction()
    {
        // Arrange
        var options = new DbContextOptionsBuilder<ToDoContext>()
            .UseInMemoryDatabase(databaseName: databaseName)
            .Options;
        await using var context = new ToDoContext(options);
        var repository = new ToDoRepository(context);
        var service = new ToDoService(repository);
        var controller = new ToDoController(service);

        // Act
        var result = await controller.CreateToDoItemAsync(TestData.GetTestTodos().First());

        // Assert
        var createdAtResult = Assert.IsType<CreatedAtActionResult>(result.Result);
        var item = Assert.IsType<ToDoItem>(createdAtResult.Value);
        Assert.Equal("CreateToDoItem", createdAtResult.ActionName);
        Assert.Equal(TestData.GetTestTodos().First().Title, item.Title);
        
        // clear all records
        context.RemoveRange(context.ToDoItems);
    }
    
    //TODO: Add tests for Max Character limit failure.
    
    [Fact]
    public async Task UpdateToDoItemAsync_ReturnsOkResultObjectWithUpdatedToDoItem()
    {
        var title = "Updated Title: Test for UpdateToDoItemAsync";
        var description = "Updated Description for Testing UpdateToDoItemAsync.";
        
        // Arrange
        var options = new DbContextOptionsBuilder<ToDoContext>()
            .UseInMemoryDatabase(databaseName: databaseName)
            .Options;

        // Seed test data
        await using var context = new ToDoContext(options);
        context.ToDoItems.AddRange(TestData.GetTestTodos());
        await context.SaveChangesAsync();
        var repository = new ToDoRepository(context);
        var service = new ToDoService(repository);
        var controller = new ToDoController(service);
        var firstItem = TestData.GetTestTodos().First();
        firstItem.Title = title;
        firstItem.Description = description;

        // Act
        var result = await controller.UpdateToDoItemAsync(firstItem);

        // Assert
        var okResult = Assert.IsType<OkObjectResult>(result);
        var item = Assert.IsType<ToDoItem>(okResult.Value);
        Assert.Equal(title, item.Title);
        Assert.Equal(description, item.Description);
        
        // clear all records
        context.RemoveRange(context.ToDoItems);
    }
    
    [Fact]
    public async Task GetAllToDoItemsAsync_ReturnsOkObjectWithAllItems()
    {
        // Arrange
        var options = new DbContextOptionsBuilder<ToDoContext>()
            .UseInMemoryDatabase(databaseName: databaseName) // ensure unique per test
            .Options;

        // Seed test data
        await using var context = new ToDoContext(options);
        context.ToDoItems.AddRange(TestData.GetTestTodos());
        await context.SaveChangesAsync();

        // Act
        var repository = new ToDoRepository(context);
        var service = new ToDoService(repository);
        var controller = new ToDoController(service);
        var result = await controller.GetAllToDoItemsAsync();

        // Assert
        var okResult = Assert.IsType<OkObjectResult>(result.Result);
        var items = Assert.IsType<List<ToDoItem>>(okResult.Value);
        Assert.Equal(2, items.Count);
        
        // clear all records
        context.RemoveRange(context.ToDoItems);
    }
    
    [Fact]
    public async Task GetToDoItemAsync_ActionResultWithToDoItem()
    {
        // Arrange
        var options = new DbContextOptionsBuilder<ToDoContext>()
            .UseInMemoryDatabase(databaseName: databaseName) // ensure unique per test
            .Options;

        // Seed test data
        await using var context = new ToDoContext(options);
        context.ToDoItems.AddRange(TestData.GetTestTodos());
        await context.SaveChangesAsync();
        var lastItem = TestData.GetTestTodos().Last();

        // Act
        var repository = new ToDoRepository(context);
        var service = new ToDoService(repository);
        var controller = new ToDoController(service);
        var result = await controller.GetToDoItemAsync(lastItem.Id);

        // Assert
        var okResult = Assert.IsType<OkObjectResult>(result.Result);
        var item = Assert.IsType<ToDoItem>(okResult.Value);
        Assert.Equal(lastItem.Id, item.Id);
        Assert.Equal(lastItem.Title, item.Title);
        
        // clear all records
        context.RemoveRange(context.ToDoItems);
    }
    
    [Fact]
    public async Task DeleteItemAsync_ReturnsNoContentResult()
    {
        // Arrange
        var options = new DbContextOptionsBuilder<ToDoContext>()
            .UseInMemoryDatabase(databaseName: databaseName) // ensure unique per test
            .Options;

        // Seed test data
        await using var context = new ToDoContext(options);
        context.ToDoItems.AddRange(TestData.GetTestTodos());
        await context.SaveChangesAsync();
        var lastItem = TestData.GetTestTodos().Last();

        // Act
        var repository = new ToDoRepository(context);
        var service = new ToDoService(repository);
        var controller = new ToDoController(service);
        var result = await controller.DeleteToDoItemAsync(lastItem.Id);

        // Assert
        Assert.IsType<NoContentResult>(result);
        
        // clear all records
        context.RemoveRange(context.ToDoItems);
    }
}