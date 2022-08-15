using Microsoft.EntityFrameworkCore;
using ToDoListAPI.Models;

namespace ToDoListAPI.Data;

public class ToDoListContext : DbContext
{
    public ToDoListContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<ToDoList> ToDoList { get; set; }
}