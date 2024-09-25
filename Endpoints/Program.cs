using Application.Abstractions;
using Application.Extensions;
using Application.Features.Breweries.Queries.GetAllBreweries;
using Application.Features.Breweries.Queries.GetBreweryId;
using Application.Features.Breweries.Responses;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence.Data;
using Persistence.Repositories;

var builder = WebApplication.CreateBuilder();

builder.Services.AddHealthChecks();

builder.Services.RegisterApplicationServices();

builder.Services.AddDbContext<DataContext>(
    options => options.UseSqlite(
        builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<IBreweryRepository, BreweryRepository>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.UseHealthChecks("/health");

app.MapGet("/breweries/{id}", async (IMediator mediator, Guid id) =>
{
    var result = await mediator.Send(new GetBreweryById() { Id = id});

    return Results.Ok(result);
});
app.MapGet("/breweries", async (IMediator mediator) =>
{
    var result = await mediator.Send(new GetAllBreweries());

    return Results.Ok(result);
});

app.Run();