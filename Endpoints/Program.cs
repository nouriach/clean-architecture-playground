using Application.Abstractions;
using Application.Extensions;
using Application.Features.Breweries.Queries.GetAllBreweries;
using Application.Features.Breweries.Queries.GetAllBreweriesByClient;
using Application.Features.Breweries.Queries.GetBreweryByIdByClient;
using Application.Features.Breweries.Queries.GetBreweryId;
using Infrastructure.Clients;
using Infrastructure.Extensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence.Data;
using Persistence.Extensions;
using Persistence.Repositories;

var builder = WebApplication.CreateBuilder();

builder.Services.AddHealthChecks();

builder.Services.RegisterApplicationServices();
builder.Services.RegisterPersistenceServices();
builder.Services.RegisterInfrastructureServices();

builder.Services.AddDbContext<DataContext>(
    options => options.UseSqlite(
        builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.UseHealthChecks("/health");

app.MapGet("/v1/breweries/{id}", async (IMediator mediator, Guid id) =>
{
    var result = await mediator.Send(new GetBreweryById() { Id = id});

    return Results.Ok(result);
});
app.MapGet("/v1/breweries", async (IMediator mediator) =>
{
    var result = await mediator.Send(new GetAllBreweries());

    return Results.Ok(result);
});

app.MapGet("/v2/breweries/{id}", async (IMediator mediator, Guid id) =>
{
    var result = await mediator.Send(new GetBreweryByIdByClient() { Id = id});

    return Results.Ok(result);
});
app.MapGet("/v2/breweries", async (IMediator mediator) =>
{
    var result = await mediator.Send(new GetAllBreweriesByClient());

    return Results.Ok(result);
});

app.Run();