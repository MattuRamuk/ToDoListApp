 
 using System.ComponentModel.DataAnnotations;

 namespace  ToDoListApp.Models;

public class WeatherModel 
{
    //date
    public DateTime Date { get; set; }
    //temperatureC
    public int? TemperatureC { get; set; }
    //temperatureF
    public int? TemperatureF { get; set; }
    //summary
    public string? Summary { get; set; }
}