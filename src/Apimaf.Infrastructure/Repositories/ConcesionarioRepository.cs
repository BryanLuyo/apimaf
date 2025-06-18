using Apimaf.Domain.Entities;
using Apimaf.Domain.Interfaces;
using Apimaf.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Apimaf.Infrastructure.Repositories;

/// <summary>
/// Implementación de repositorio de concesionarios usando EF Core.
/// </summary>
public class ConcesionarioRepository : IConcesionarioRepository
{
    private readonly ApplicationDbContext _context;

    public ConcesionarioRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    // TODO: Devuelve todos los concesionarios
    public async Task<IEnumerable<Concesionario>> GetAllAsync()
        => await _context.Concesionarios.AsNoTracking().ToListAsync();

    // TODO: Busca un concesionario por id
    public async Task<Concesionario?> GetByIdAsync(int id)
        => await _context.Concesionarios.FindAsync(id);

    // TODO: Crea un nuevo concesionario
    public async Task AddAsync(Concesionario entity)
        => await _context.Concesionarios.AddAsync(entity);

    // TODO: Guarda los cambios
    public async Task SaveChangesAsync()
        => await _context.SaveChangesAsync();
}
