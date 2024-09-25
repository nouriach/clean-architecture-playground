using Application.Abstractions;
using Application.Features.Breweries.Responses;
using Domain.Entity;
using MediatR;

namespace Application.Features.Breweries.Queries.GetAllBreweries;

public class GetAllBreweriesHandler : IRequestHandler<GetAllBreweries, BreweriesResponse>
{
    private readonly IBreweryRepository _repo;

    public GetAllBreweriesHandler(IBreweryRepository repo)
    {
        _repo = repo;
    }

    public async Task<BreweriesResponse> Handle(GetAllBreweries request, CancellationToken cancellationToken)
    {
        var breweryEntities = await _repo.GetAllBreweries();
        var breweries = breweryEntities.Select(x => new BreweryResponse() { Name = x.Name });

        return new BreweriesResponse
        {
            Breweries = breweries
        };
    }
}