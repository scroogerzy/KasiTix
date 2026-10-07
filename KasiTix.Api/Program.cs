using FluentValidation;
using FluentValidation.AspNetCore;
using KasiTix.Api.Middleware;
using KasiTix.Api.Services;
using KasiTix.Domain.Repositories;
using KasiTix.Infrastructure.Data;
using KasiTix.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddOpenApi();

builder.Services.AddValidatorsFromAssemblyContaining<Program>();

builder.Services.AddFluentValidationAutoValidation();

builder.Services.AddProblemDetails();

builder.Services.AddExceptionHandler<ApiExceptionHandler>();

builder.Services.AddDbContext<KasiTixDbContext>(options =>
{
    options.UseNpgsql(
        builder.Configuration.GetConnectionString("DefaultConnection"));
});

builder.Services.AddScoped<IEventRepository,
    EventRepository>();

builder.Services.AddScoped<IOrderRepository,
    OrderRepository>();

builder.Services.AddScoped<EventService>();

var app = builder.Build();

app.UseExceptionHandler();

app.MapControllers();

app.MapOpenApi();

app.Run();