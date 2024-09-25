using Application.Abstractions;
using Application.Features.Breweries.Responses;
using MediatR;

namespace Application.Features.Breweries.Queries.GetAllBreweriesByClient;

public class GetAllBreweriesByClientHandler : IRequestHandler<GetAllBreweriesByClient, BreweriesResponse>
{
    private readonly IApiClient _client;

    public GetAllBreweriesByClientHandler(IApiClient client)
    {
        _client = client;
    }

    public async Task<BreweriesResponse> Handle(GetAllBreweriesByClient request, CancellationToken cancellationToken)
    {
        var breweryEntities = await _client.GetAllBreweries();
        
        var breweries = breweryEntities.Select(x => new BreweryResponse() { Name = x.Name });

        return new BreweriesResponse
        {
            Breweries = breweries
        };
    }
}