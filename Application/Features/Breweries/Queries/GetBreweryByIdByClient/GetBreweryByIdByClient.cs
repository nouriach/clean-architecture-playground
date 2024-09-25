using Application.Features.Breweries.Responses;
using MediatR;

namespace Application.Features.Breweries.Queries.GetBreweryByIdByClient;

public class GetBreweryByIdByClient : IRequest<BreweryResponse>
{
    public Guid Id { get; set; }
}