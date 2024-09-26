using System.Text.Json;
using Application.Abstractions;
using Domain.Entity;

namespace Infrastructure.Clients;

public class BreweryApiClient : IApiClient
{
    private readonly HttpClient _client;

    public BreweryApiClient(HttpClient client)
    {
        _client = client;
    }

    public async Task<Brewery?> GetBreweryById(Guid id)
    {
        var response = await ExecuteGetByIdRequestAsync(id);
        if (!response.IsSuccessStatusCode) return null;
        
        var responseContent = await response.Content.ReadAsStringAsync();
        return JsonSerializer.Deserialize<Brewery>(responseContent, new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
    }

    public async Task<IEnumerable<Brewery?>> GetAllBreweries()
    {
        var response = await ExecuteGetAllRequestAsync();
        if (!response.IsSuccessStatusCode) return null;
        
        var responseContent = await response.Content.ReadAsStringAsync();
        return JsonSerializer.Deserialize<IEnumerable<Brewery>>(responseContent, new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
    }

    private async Task<HttpResponseMessage> ExecuteGetAllRequestAsync()
    {
        var httpRequest = new HttpRequestMessage(HttpMethod.Get, "https://api.openbrewerydb.org/v1/breweries?per_page=5");

        return await _client.SendAsync(httpRequest);
    }
    
    private async Task<HttpResponseMessage> ExecuteGetByIdRequestAsync(Guid id)
    {
        var httpRequest = new HttpRequestMessage(HttpMethod.Get, $"https://api.openbrewerydb.org/v1/breweries/{id}");

        return await _client.SendAsync(httpRequest);
    }
}