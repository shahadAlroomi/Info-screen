using Infoscreen.Data;
using Infoscreen.Models;
using Microsoft.AspNetCore.Mvc;

namespace Infoscreen.Controllers;

[ApiController]
[Route("api/locations")]
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
