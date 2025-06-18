using Apimaf.Domain.Entities;
using Apimaf.Domain.Interfaces;
using Apimaf.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Apimaf.Infrastructure.Repositories;

/// <summary>
/// Implementación de repositorio de sucursales usando EF Core.
/// </summary>
public class SucursalRepository : ISucursalRepository
{
    private readonly ApplicationDbContext _context;

    public SucursalRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    // TODO: Obtiene todas las sucursales de una concesionaria
    public async Task<IEnumerable<Sucursal>> GetByConcesionariaIdAsync(int concesionariaId)
        => await _context.Sucursales.Where(s => s.IdConcesionaria == concesionariaId).ToListAsync();

    // TODO: Crea una nueva sucursal
    public async Task AddAsync(Sucursal entity)
        => await _context.Sucursales.AddAsync(entity);

    // TODO: Guarda los cambios
    public async Task SaveChangesAsync()
        => await _context.SaveChangesAsync();
}
