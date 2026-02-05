using Infoscreen.Data;
using Infoscreen.Models;
using Microsoft.AspNetCore.Mvc;

namespace Infoscreen.Controllers;

[ApiController]
[Route("api/[controller]")]
public class LocationsController (AppDbContext appDb) : ControllerBase
{


    // POST /api/locations
    [HttpPost]
    public IActionResult Create(Location location)
    {
        appDb.Locations.Add(location);
        appDb.SaveChanges();

        return Created($"/Home/Locations/{location.Id}", location);
    }
}
