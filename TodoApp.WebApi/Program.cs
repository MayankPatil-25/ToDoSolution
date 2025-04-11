using Microsoft.EntityFrameworkCore;
using TodoApp.WebApi.Data;
using TodoApp.WebApi.Repositories;
using TodoApp.WebApi.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the DI container
builder.Services.AddDbContext<ToDoContext>(options => options.UseInMemoryDatabase("ToDoDb"));

builder.Services.AddScoped<IToDoRepository, ToDoRepository>();
builder.Services.AddScoped<IToDoService, ToDoService>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configuring middleware
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
