using System.ComponentModel.DataAnnotations;

namespace ToDoListApp.Models;

public class ToDoItem{
    public Guid Id { get; set; }
    public string? TaskName { get; set; }
    public bool IsComplete { get; set; }
}