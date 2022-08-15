namespace ToDoListAPI.Models;

public class ToDoList   
{
    public Guid Id { get; set; }
    public string? TaskName { get; set; }
    public bool IsComplete { get; set; }

}