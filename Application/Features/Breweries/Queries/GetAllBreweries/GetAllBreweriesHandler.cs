using Application.Features.Breweries.Responses;
using MediatR;

namespace Application.Features.Breweries.Queries.GetAllBreweries;

public class GetAllBreweriesHandler : IRequestHandler<GetAllBreweries, BreweriesResponse>
{
    public Task<BreweriesResponse> Handle(GetAllBreweries request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}