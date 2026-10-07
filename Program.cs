using FluentValidation;
using FluentValidation.AspNetCore;
using KasiTix.Api.Middleware;
using KasiTix.Api.Services;
using KasiTix.Infrastructure.Data;
using KasiTix.Infrastructure.Repositories;
using KasiTix.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddValidatorsFromAssemblyContaining<Program>();

builder.Services.AddFluentValidationAutoValidation();

builder.Services.AddExceptionHandler<ApiExceptionHandler>();

builder.Services.AddProblemDetails();

builder.Services.AddDbContext<KasiTixDbContext>(options =>
{
    options.UseNpgsql(
        builder.Configuration.GetConnectionString("Default"));
});

builder.Services.AddScoped<IEventRepository,
    EventRepository>();

builder.Services.AddScoped<IOrderRepository,
    OrderRepository>();

builder.Services.AddScoped<EventService>();

var app = builder.Build();

app.UseExceptionHandler();

app.MapControllers();

app.Run();