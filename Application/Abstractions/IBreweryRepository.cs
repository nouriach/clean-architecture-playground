using Domain.Entity;

namespace Application.Abstractions;

public interface IBreweryRepository
{
    Task<Brewery?> GetBreweryById(Guid id);
    Task<IEnumerable<Brewery?>> GetAllBreweries();
}