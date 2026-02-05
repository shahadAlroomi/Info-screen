using Infoscreen.Models;
using Microsoft.EntityFrameworkCore;

public class AppDbContext : DbContext
{
    DbSet<Location> Locations {get;set;}
}