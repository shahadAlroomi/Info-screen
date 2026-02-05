using Infoscreen.Models;
using Microsoft.EntityFrameworkCore;

namespace Infoscreen.Data;
public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options) {}
    public DbSet<Location> Locations {get;set;}

    protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Location>().HasData(
                new Location
                {
                    Id = 1,
                    Name = "Plan 1",
                    Address = "Källegatan 6-8",
                    FloorsInfo = " Garage ",// "PLAN 1\n Garage A\nCompany B",
                }
            );
        }
}