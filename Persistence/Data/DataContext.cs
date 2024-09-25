using Domain.Entity;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Data;

public class DataContext : DbContext
{
    public DataContext(DbContextOptions<DataContext> options) : base(options)
    {
  
    }

    public DbSet<Brewery?> Breweries { get; set; }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Seed data into Breweries
        modelBuilder.Entity<Brewery>().HasData(
            new Brewery
            {
                Id = Guid.NewGuid(),
                Name = "Sample Brewery 1",
                City = "Denver",
                State = "Colorado",
                WebsiteUrl = "https://www.mountainpeaksbrewery.com"
            },
            new Brewery
            {
                Id = Guid.NewGuid(),
                Name = "Sample Brewery 2",
                City = "Portland",
                State = "Oregon",
                WebsiteUrl = "https://www.riverbendbrewingco.com"
            },
            new Brewery
            {
                Id = Guid.NewGuid(),
                Name = "Sample Brewery 3",
                City = "Madison",
                State = "Wisconsin",
                WebsiteUrl = "https://www.lakesidecraftbrewery.com"
            },
            new Brewery
            {
                Id = Guid.NewGuid(),
                Name = "Sample Brewery 4",
                City = "San Diego",
                State = "California",
                WebsiteUrl = "https://www.goldenhorizonbrewery.com"
            }
        );
    }
}