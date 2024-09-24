using Application.Extensions;

var builder = WebApplication.CreateBuilder();

builder.Services.AddHealthChecks();

builder.Services.RegisterApplicationServices();

var app = builder.Build();

app.UseHealthChecks("/health");

app.Run();