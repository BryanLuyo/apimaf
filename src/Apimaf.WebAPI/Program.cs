using Apimaf.Application.Services;
using Apimaf.Application.DTOs;
using Apimaf.Domain.Interfaces;
using Apimaf.Infrastructure.Data;
using Apimaf.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Apimaf.WebAPI;

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

// TODO: Configurar autenticación JWT
var jwtSection = builder.Configuration.GetSection("Jwt");
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = jwtSection["Issuer"],
            ValidAudience = jwtSection["Audience"],
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSection["Key"] ?? string.Empty))
        };
    });
builder.Services.AddAuthorization();

var app = builder.Build();

// Middleware de manejo de errores
app.UseMiddleware<ErrorHandlingMiddleware>();

app.UseSwagger();
app.UseSwaggerUI();

app.UseAuthentication();
app.UseAuthorization();

// TODO: Endpoint para obtener un token JWT (ficticio)
app.MapPost("/login", (LoginDto login) =>
{
    var claims = new[] { new Claim(ClaimTypes.Name, login.Username) };
    var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSection["Key"]!));
    var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
    var token = new JwtSecurityToken(
        issuer: jwtSection["Issuer"],
        audience: jwtSection["Audience"],
        claims: claims,
        expires: DateTime.UtcNow.AddHours(1),
        signingCredentials: creds);
    var tokenString = new JwtSecurityTokenHandler().WriteToken(token);
    return Results.Ok(new ApiResponse<string>(0, "OK", tokenString));
});

// TODO: Mapear endpoints de concesionarios
app.MapGet("/concesionarios", async (ConcesionarioService service) =>
{
    var data = await service.GetAllAsync();
    return Results.Ok(new ApiResponse<IEnumerable<ConcesionarioDto>>(0, "OK", data));
}).RequireAuthorization();

// TODO: Mapear endpoints de sucursales
app.MapGet("/concesionarios/{id}/sucursales", async (int id, SucursalService service) =>
{
    var data = await service.GetByConcesionarioIdAsync(id);
    return Results.Ok(new ApiResponse<IEnumerable<SucursalDto>>(0, "OK", data));
}).RequireAuthorization();

app.Run();

public partial class Program { }
