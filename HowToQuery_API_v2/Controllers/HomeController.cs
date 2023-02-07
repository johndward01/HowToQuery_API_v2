using HowToQuery_API_v2.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RestSharp;
using System.Diagnostics;

namespace HowToQuery_API_v2.Controllers;
public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        var client = new RestClient("https://vaccovid-coronavirus-vaccine-and-treatment-tracker.p.rapidapi.com/api/npm-covid-data/");
        var request = new RestRequest();
        request.AddHeader("X-RapidAPI-Key", "074ffd9f62mshfab1a752b7e2342p1f409fjsnbc7bc16069e0");
        var response = client.Execute(request).Content;
        var root = JsonConvert.DeserializeObject<List<Covid_Root>>(response);
        return View(root);
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
