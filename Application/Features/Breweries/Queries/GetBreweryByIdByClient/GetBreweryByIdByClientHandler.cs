using Application.Abstractions;
using Application.Features.Breweries.Responses;
using MediatR;

namespace Application.Features.Breweries.Queries.GetBreweryByIdByClient;

public class GetBreweryByIdByClientHandler : IRequestHandler<GetBreweryByIdByClient, BreweryResponse>
{
    private readonly IApiClient _client;

    public GetBreweryByIdByClientHandler(IApiClient client)
    {
        _client = client;
    }

    public async Task<BreweryResponse> Handle(GetBreweryByIdByClient request, CancellationToken cancellationToken)
    {
        var breweryEntity = await _client.GetBreweryById(request.Id);
        
        return new BreweryResponse
        {
            Name = breweryEntity.Name
        };
    }
}