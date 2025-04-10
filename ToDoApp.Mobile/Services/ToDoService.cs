using System.Net.Http.Json;
using ToDoApp.Mobile.Models;

namespace ToDoApp.Mobile.Services;

public class ToDoService: IToDoService
{
    private const string BaseUrl = "http://localhost:5270/api/todo";
    private readonly HttpClient _httpClient;
    
    public ToDoService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<List<ToDoItem>> GetAllToDoAsync()
    {
        try
        {
            return await _httpClient.GetFromJsonAsync<List<ToDoItem>>(BaseUrl) ?? new List<ToDoItem>();
        }
        catch (HttpRequestException)
        {
            return new List<ToDoItem>();
        }
    }

    public async Task<ToDoItem?> GetToDoByIdAsync(int id)
    {
        try
        {
            return await _httpClient.GetFromJsonAsync<ToDoItem>($"{BaseUrl}/{id}");
        }
        catch (HttpRequestException)
        {
            return null;
        }
    }

    public async Task<bool> AddToDoAsync(ToDoItem item)
    {
        try
        {
            var response = await _httpClient.PostAsJsonAsync(BaseUrl, item);
            return response.IsSuccessStatusCode;
        }
        catch (HttpRequestException)
        {
            return false;
        }
    }

    public async Task<bool> UpdateToDoAsync(ToDoItem item)
    {
        try
        {
            var response = await _httpClient.PutAsJsonAsync($"{BaseUrl}/{item.Id}", item);
            return response.IsSuccessStatusCode;
        }
        catch (HttpRequestException)
        {
            return false;
        }
    }

    public async Task<bool> DeleteToDoAsync(int id)
    {
        try
        {
            var response = await _httpClient.DeleteAsync($"{BaseUrl}/{id}");
            return response.IsSuccessStatusCode;
        }
        catch (HttpRequestException)
        {
            return false;
        }
    }
}