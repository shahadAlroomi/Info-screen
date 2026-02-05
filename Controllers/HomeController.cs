using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Infoscreen.Models;
using Infoscreen.Data;

namespace Infoscreen.Controllers;

public class HomeController(AppDbContext appDb) : Controller
{


    public IActionResult Locations(int id)
    {
        var Location = appDb.Locations.FirstOrDefault(l => l.Id == id);
        return View(Location);
    }
   public IActionResult Index(string q)
{
    if (string.IsNullOrEmpty(q))
        return View();

    var location = appDb.Locations
        .FirstOrDefault(l => l.Name.Contains(q) || l.Address.Contains(q));

    if (location == null)
        return View();

    return RedirectToAction(nameof(Locations), new { id = location.Id });
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

    [HttpPost]
    [Route("api/locations")]

    public IActionResult CreateLocation([FromBody] Location location)
    {
        appDb.Locations.Add(location);
        appDb.SaveChanges();

        return Ok(location);
    }

}

