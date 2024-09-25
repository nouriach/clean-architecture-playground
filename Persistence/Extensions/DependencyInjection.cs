using Application.Abstractions;
using Microsoft.Extensions.DependencyInjection;
using Persistence.Repositories;

namespace Persistence.Extensions;

public static class DependencyInjection
{
    public static IServiceCollection RegisterPersistenceServices(this IServiceCollection services)
    {
        services.AddScoped<IBreweryRepository, BreweryRepository>();

        return services;
    }
}