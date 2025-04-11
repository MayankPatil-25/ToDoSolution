using Microsoft.AspNetCore.Mvc;
using TodoApp.WebApi.Models;
using TodoApp.WebApi.Services;

namespace TodoApp.WebApi.Controllers
{
    [Route("api/todo")]
    [ApiController]
    public class ToDoController : ControllerBase
    {
        private readonly IToDoService _service;

        public ToDoController(IToDoService context)
        {
            _service = context;
        }

        [HttpPost]
        public async Task<ActionResult<ToDoItem>> CreateToDoItemAsync(ToDoItem item)
        {   
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            
            var todoItemResult = await _service.CreateToDoItemAsync(item);
            return CreatedAtAction(actionName: nameof(GetToDoItemAsync),
                routeValues: new { id = todoItemResult.Id },
                value: todoItemResult);
        }

        [HttpGet]
        public async Task<ActionResult<List<ToDoItem>>> GetAllToDoItemsAsync()
        {
            var list = await _service.GetAllToDoItemsAsync();
            return Ok(list);
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<ToDoItem>> GetToDoItemAsync(int id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            
            var item = await _service.GetToDoItemAsync(id);
            if (item == null)
            {
                return NotFound();
            }

            return Ok(item);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateToDoItemAsync(ToDoItem item)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var updatedTodoItem = await _service.UpdateToDoItemAsync(item);
            if (updatedTodoItem == null)
            {
                return NotFound();
            }
            return Ok(updatedTodoItem);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteToDoItemAsync(int id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
    
            var deleted = await _service.DeleteToDoItemAsync(id);
            if (!deleted)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}