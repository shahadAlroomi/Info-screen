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



}

