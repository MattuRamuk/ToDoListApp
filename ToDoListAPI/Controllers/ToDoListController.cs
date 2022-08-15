using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


using ToDoListAPI.Models;
using ToDoListAPI.Data;

namespace ToDoListAPI.Controllers;

[Route("api/controller")]
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

    // GET: api/ToDoItems/3

    // PUT: api/ToDoItems/3

    // POST: api/ToDoItems
    [HttpPost]
    [Route("add-new-item")]
    public async Task<ActionResult<ToDoList>> AddToDoItem(ToDoList toDoList)
    {
        _context.ToDoList.Add(toDoList);
        await _context.SaveChangesAsync();

        return CreatedAtAction("GetToDoList", new { id = toDoList.Id}, toDoList);
    }

    // DELETE: api/ToDoItems/3

}