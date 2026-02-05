using Infoscreen.Data;
using Microsoft.AspNetCore.Mvc;

namespace Infoscreen.Controllers;

[ApiController]
[Route("/api/images")] 
public class ImagesController(IWebHostEnvironment env) : ControllerBase
{

    // POST /api/images
    [HttpPost]
    public async Task<IActionResult> Upload(IFormFile file)
    {
        var path = Path.Combine(env.WebRootPath, "images");
        Directory.CreateDirectory(path);

        var name = Guid.NewGuid() + Path.GetExtension(file.FileName);
        var fullPath = Path.Combine(path, name);

        using var stream = System.IO.File.Create(fullPath);
        await file.CopyToAsync(stream);

        return Ok("/images/" + name);
    }

}
