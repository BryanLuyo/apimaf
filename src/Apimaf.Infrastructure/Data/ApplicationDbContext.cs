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

    // TODO: Tabla de Concesionarios
    public DbSet<Concesionario> Concesionarios => Set<Concesionario>();
    // TODO: Tabla de Sucursales
    public DbSet<Sucursal> Sucursales => Set<Sucursal>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // TODO: Mapear nombres de tablas existentes
        modelBuilder.Entity<Concesionario>().ToTable("concesionario");
        modelBuilder.Entity<Sucursal>().ToTable("sucursal");

        // TODO: Configurar relación uno a muchos
        modelBuilder.Entity<Concesionario>()
            .HasMany(c => c.Sucursales)
            .WithOne(s => s.Concesionario!)
            .HasForeignKey(s => s.IdConcesionario);
    }
}
