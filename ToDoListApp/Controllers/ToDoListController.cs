using System;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using ToDoListApp.Models;
using ToDoListApp.Helper;

namespace ToDoListApp.Controllers;


/*TODO: Implement pages and functionality for CRUD*/
public class ToDoListController : Controller
{
    private readonly ILogger<ToDoListController> _logger;
    ToDoListAPI _api = new ToDoListAPI();
    public ToDoListController(ILogger<ToDoListController> logger)
    {
        _logger = logger;
    }

    public async Task<IActionResult> Index()
    {
        List<ToDoItem> todoItems = new List<ToDoItem>();
        HttpClient client = _api.Initial();
        HttpResponseMessage res = await client.GetAsync("get-all-items");
        if (res.IsSuccessStatusCode)
        {
            var result = res.Content.ReadAsStringAsync().Result;
            if (result != null)
            {
                todoItems = JsonConvert.DeserializeObject<List<ToDoItem>>(result);
            }
            
        }

        return View(todoItems);
    }
    
    public ActionResult AddNew()
    {
        return View();
    }

    public async Task<IActionResult> Create(ToDoItem toDoItem)
    {
        HttpClient client = _api.Initial();
        
        var newItem = new ToDoItem
        {
            Id = toDoItem.Id,
            TaskName = toDoItem.TaskName,
            IsComplete = toDoItem.IsComplete
        };
    
        HttpResponseMessage res = await client.PostAsJsonAsync("add-new-item", newItem);

        if (res.IsSuccessStatusCode)
        {
            return RedirectToAction("Index");
        }
       return View(toDoItem);
    }
}