using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Infoscreen.Models;
using Infoscreen.Data;

namespace Infoscreen.Controllers;

public class HomeController(AppDbContext appDb) : Controller 
{


    public IActionResult Location(int id )
    {
        var Location = appDb.Locations.FirstOrDefault(l => l.Id == id);
        return View();
    }
    public IActionResult Index()
    {
        return View();
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
