using Apimaf.Application.Services;
using Apimaf.Domain.Interfaces;
using Apimaf.Infrastructure.Data;
using Apimaf.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// TODO: Configurar cadena de conexión (valor por defecto en appsettings)
var connectionString = builder.Configuration.GetConnectionString("Default") ?? string.Empty;

// TODO: Registrar DbContext y servicios
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));

builder.Services.AddScoped<ConcesionarioService>();
builder.Services.AddScoped<SucursalService>();

builder.Services.AddScoped<IConcesionarioRepository, ConcesionarioRepository>();
builder.Services.AddScoped<ISucursalRepository, SucursalRepository>();

// TODO: Configurar Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

// TODO: Mapear endpoints de concesionarios
app.MapGet("/concesionarios", async (ConcesionarioService service) =>
{
    return Results.Ok(await service.GetAllAsync());
});

// TODO: Mapear endpoints de sucursales
app.MapGet("/concesionarios/{id}/sucursales", async (int id, SucursalService service) =>
{
    return Results.Ok(await service.GetByConcesionarioIdAsync(id));
});

app.Run();
