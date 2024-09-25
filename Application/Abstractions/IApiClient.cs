using Domain.Entity;

namespace Application.Abstractions;

public interface IApiClient
{
    Task<Brewery?> GetBreweryById(Guid id);
    Task<IEnumerable<Brewery?>> GetAllBreweries();
}