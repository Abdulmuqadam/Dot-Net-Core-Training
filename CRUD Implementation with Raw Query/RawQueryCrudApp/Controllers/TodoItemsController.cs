using Microsoft.AspNetCore.Mvc;
using RawQueryCrudApp.Models;
using RawQueryCrudApp.Repository;

namespace RawQueryCrudApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodoItemsController : ControllerBase
    {
        private readonly TodoItemRepository _repository;

        public TodoItemsController(TodoItemRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var todoItems = _repository.GetAll();
            return Ok(todoItems);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var todoItems = _repository.GetById(id);
            if (todoItems == null)
            {
                return NotFound();
            }
            return Ok(todoItems);
        }

        [HttpPost]
        public IActionResult Post([FromBody] TodoItem todoItem)
        {
            if (todoItem == null)
            {
                return BadRequest();
            }

            _repository.Add(todoItem);
            return CreatedAtAction(nameof(GetById), new { id = todoItem.Id }, todoItem);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] TodoItem todoItem)
        {
            if (todoItem == null || id != todoItem.Id)
            {
                return BadRequest();
            }

            _repository.Update(todoItem);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _repository.Delete(id);
            return NoContent();
        }
    }
}
