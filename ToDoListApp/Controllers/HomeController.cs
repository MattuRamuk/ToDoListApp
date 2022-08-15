using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ToDoListApp.Models;
using ToDoListApp.Helper;
using Newtonsoft.Json;

namespace ToDoListApp.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    WeatherAPI _api = new WeatherAPI();


    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public async Task<IActionResult> Index()
    {
        List<WeatherModel> weather = new List<WeatherModel>();
        HttpClient client = _api.Initial();
        HttpResponseMessage res = await client.GetAsync("/weatherforecast");

        if (res.IsSuccessStatusCode)
        {
            var result = res.Content.ReadAsStringAsync().Result;
            if (result != null)
            {
                weather = JsonConvert.DeserializeObject<List<WeatherModel>>(result);
            }
            
        }
        return View(weather);
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
