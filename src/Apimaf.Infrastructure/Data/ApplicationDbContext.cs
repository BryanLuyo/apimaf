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

        // TODO: Configurar tablas y relación uno a muchos
        modelBuilder.Entity<Concesionario>(entity =>
        {
            entity.ToTable("concesionario");

            // Mapeo explícito de columnas para coincidir con la base de datos
            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Cod).HasColumnName("cod");
            entity.Property(e => e.NomComercial).HasColumnName("nom_comercial");
            entity.Property(e => e.Nombre).HasColumnName("nombre");
            entity.Property(e => e.Descripcion).HasColumnName("descripcion");
            entity.Property(e => e.FlgEstado).HasColumnName("flg_estado");
            entity.Property(e => e.CreatedAt).HasColumnName("created_at");
            entity.Property(e => e.UpdatedAt).HasColumnName("updated_at");

            entity.HasMany(c => c.Sucursales)
                  .WithOne(s => s.Concesionario!)
                  .HasForeignKey(s => s.IdConcesionario);
        });

        modelBuilder.Entity<Sucursal>(entity =>
        {
            entity.ToTable("sucursal");

            // Mapeo explícito de columnas
            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.IdConcesionario).HasColumnName("id_concesionario");
            entity.Property(e => e.NomComercial).HasColumnName("nom_comercial");
            entity.Property(e => e.FlgEstado).HasColumnName("flg_estado");
            entity.Property(e => e.CreatedAt).HasColumnName("created_at");
            entity.Property(e => e.UpdatedAt).HasColumnName("updated_at");
        });
    }
}
