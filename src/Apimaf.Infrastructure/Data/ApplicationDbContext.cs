using Microsoft.EntityFrameworkCore;
using Apimaf.Domain.Entities;

namespace Apimaf.Infrastructure.Data;

/// <summary>
/// DbContext de la aplicación.
/// </summary>
public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    // TODO: Tabla de Concesionarias
    public DbSet<Concesionaria> Concesionarias => Set<Concesionaria>();
    // TODO: Tabla de Sucursales
    public DbSet<Sucursal> Sucursales => Set<Sucursal>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // TODO: Configurar relación uno a muchos
        modelBuilder.Entity<Concesionaria>()
            .HasMany(c => c.Sucursales)
            .WithOne(s => s.Concesionaria!)
            .HasForeignKey(s => s.IdConcesionaria);
    }
}
