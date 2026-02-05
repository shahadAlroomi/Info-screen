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
                    Name = "Main Office",
                    Address = "Example Street 1",
                    FloorsInfo = "PLAN 1\nCompany A\nCompany B",
                }
            );
        }
}