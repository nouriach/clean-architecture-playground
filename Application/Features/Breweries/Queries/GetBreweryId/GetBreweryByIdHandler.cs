using Application.Abstractions;
using Application.Features.Breweries.Responses;
using Domain.Entity;
using MediatR;

namespace Application.Features.Breweries.Queries.GetBreweryId;

public class GetBreweryByIdHandler : IRequestHandler<GetBreweryById, BreweryResponse>
{
    private readonly IBreweryRepository _repo;

    public GetBreweryByIdHandler(IBreweryRepository repo)
    {
        _repo = repo;
    }

    public async Task<BreweryResponse> Handle(GetBreweryById request, CancellationToken cancellationToken)
    {
        var breweryEntity = await _repo.GetBreweryById(request.Id);

        return new BreweryResponse
        {
            Name = breweryEntity.Name
        };
    }
}