using Microsoft.Extensions.Configuration;

namespace ToDoListApp.Helper;

public class WeatherAPI
{
    public HttpClient Initial()
    {
        var client = new HttpClient();
        client.BaseAddress = new Uri("https://localhost:7130/");
        return client;
    }
}

public class ToDoListAPI
{
    public HttpClient Initial()
    {
        var client = new HttpClient();
       client.BaseAddress = new Uri("https://localhost:7130/api/controller/");
       return client;
    }
}