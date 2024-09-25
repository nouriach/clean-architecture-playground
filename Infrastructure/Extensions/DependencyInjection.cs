using Application.Abstractions;
using Infrastructure.Clients;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.Extensions;

public static class DependencyInjection
{
    public static IServiceCollection RegisterInfrastructureServices(this IServiceCollection services)
    {
        services.AddHttpClient<IApiClient, BreweryApiClient>();

        return services;
    }
}