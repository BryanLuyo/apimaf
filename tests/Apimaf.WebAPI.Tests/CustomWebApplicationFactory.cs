using Apimaf.Infrastructure.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Apimaf.WebAPI.Tests;

public class CustomWebApplicationFactory : WebApplicationFactory<Program>
{
    protected override void ConfigureWebHost(IWebHostBuilder builder)
    {
        builder.ConfigureServices(services =>
        {
            // Remove existing DbContext registration
            var descriptor = services.SingleOrDefault(d => d.ServiceType == typeof(DbContextOptions<ApplicationDbContext>));
            if (descriptor != null)
            {
                services.Remove(descriptor);
            }

            // Add in-memory database for tests
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseInMemoryDatabase("TestDb"));

            // Build service provider
            var sp = services.BuildServiceProvider();

            // Create a scope to seed data
            using var scope = sp.CreateScope();
            var db = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
            db.Database.EnsureCreated();

            // Seed initial data
            var concesionario = new Apimaf.Domain.Entities.Concesionario
            {
                Cod = 1,
                NomComercial = "Test Dealer",
                Nombre = "Dealer 1"
            };
            db.Concesionarios.Add(concesionario);
            db.Sucursales.Add(new Apimaf.Domain.Entities.Sucursal
            {
                IdConcesionario = concesionario.Id,
                NomComercial = "Main Branch"
            });
            db.SaveChanges();
        });
    }
}
