using Application.Features.Breweries.Responses;
using MediatR;

namespace Application.Features.Breweries.Queries.GetBreweryId;

public class GetBreweryByIdHandler : IRequestHandler<GetBreweryById, BreweryResponse>
{
    public Task<BreweryResponse> Handle(GetBreweryById request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}