using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Infoscreen.Models;
using Infoscreen.Data;

namespace Infoscreen.Controllers;

public class HomeController(AppDbContext appDb) : Controller
{


    public IActionResult Locations(int id)
    {
        var location = appDb.Locations.FirstOrDefault(l => l.Id == id);
         if (location == null)
        return NotFound();
        return View(location);
    }
   public IActionResult Index(string q)
{
    if (string.IsNullOrEmpty(q))
        return View();

    var location = appDb.Locations
    .Where(l => l.Name.Contains(q) || l.Address.Contains(q))
    .OrderByDescending(l => l.Id)
    .FirstOrDefault();
if (location == null)
    {
        ViewBag.NotFound = "Hittade ingen byggnad med det du skrev.";
        return View();
    }

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

    [HttpPut]
[Route("api/locations/{id}")]
public IActionResult UpdateLocation(int id, [FromBody] Location updated)
{
    var location = appDb.Locations.FirstOrDefault(l => l.Id == id);

    if (location == null)
        return NotFound();

    // Update fields
    location.Name = updated.Name;
    location.Address = updated.Address;
    location.FloorsInfo = updated.FloorsInfo;
    location.ExtraInfo = updated.ExtraInfo;
    location.LogoUrl = updated.LogoUrl;
    location.ImageUrl = updated.ImageUrl;

    appDb.SaveChanges();

    return Ok(location);
}


}

