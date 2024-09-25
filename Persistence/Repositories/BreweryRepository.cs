using Application.Abstractions;
using Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Persistence.Data;

namespace Persistence.Repositories;

public class BreweryRepository : IBreweryRepository
{
    private readonly DataContext _context;

    public BreweryRepository(DataContext context)
    {
        _context = context;
    }

    public async Task<Brewery?> GetBreweryById(Guid id)
    {
        var brewery = await _context.Breweries.FirstOrDefaultAsync(brewery => brewery.Id == id);
        return brewery;
    }

    public async Task<IEnumerable<Brewery?>> GetAllBreweries()
    {
        var breweries = await _context.Breweries.ToListAsync();
        return breweries;
    }
}