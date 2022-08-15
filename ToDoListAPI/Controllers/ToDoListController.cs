using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


using ToDoListAPI.Models;
using ToDoListAPI.Data;

namespace ToDoListAPI.Controllers;


/* implement DTO and Repository Pattern*/
[Route("api/todolist")]
[ApiController]
public class ToDoListController : ControllerBase
{
    private readonly ToDoListContext _context;
    public ToDoListController(ToDoListContext context)
    {
        _context = context;
    }

    // GET: api/ToDoItems
    [HttpGet]
    [Route("get-all-items")]
    public async Task<ActionResult<IEnumerable<ToDoList>>> GetToDoList()
    {
        return await _context.ToDoList.ToListAsync();
    }

    //GET: api/ToDoItems/3
    [HttpGet("get-todo-item/{id}")]
    public async Task<ActionResult<ToDoList>> GetToDoItem(Guid? id)
    {
        var toDoItem = await _context.ToDoList.FindAsync(id);
        if(toDoItem == null) return NotFound();

        return toDoItem;
    }

    //PUT: api/ToDoItems/3
    [HttpPut("update-todo-item/{id}")]
    
    public async Task<IActionResult> UpdateToDoItem(Guid? id, [FromBody] ToDoList toDoList)
    {
        //if (id.Equals(toDoList.Id))  return BadRequest();

        var todoItem = await _context.ToDoList.FindAsync(id);
        if (todoItem == null) return NotFound();

        todoItem.TaskName = toDoList.TaskName;
        todoItem.IsComplete = toDoList.IsComplete;

        try {
                await _context.SaveChangesAsync();
        } catch(DbUpdateConcurrencyException) when (!TodoItemExists(id)) { return NotFound();}

        return NoContent();

    }

    // POST: api/ToDoItems
    [HttpPost("add-new-item")]
   
    public async Task<ActionResult<ToDoList>> AddToDoItem(ToDoList toDoList)
    {
        _context.ToDoList.Add(toDoList);
        await _context.SaveChangesAsync();

        return CreatedAtAction("GetToDoList", new { id = toDoList.Id}, toDoList);
    }

    // DELETE: api/ToDoItems/3
    [HttpDelete("delete-todo-item/{id}")]
   
    public async Task<IActionResult> DeleteToDoItem(Guid? id)
    {
        var todoItem = await _context.ToDoList.FindAsync(id);

        if (todoItem == null) return NotFound();

        _context.ToDoList.Remove(todoItem);
        await _context.SaveChangesAsync();

        return NoContent();
        
    }

    //check item exists 
    private bool TodoItemExists(Guid? id)
    {
        return _context.ToDoList.Any(e => e.Id == id);
    }

}