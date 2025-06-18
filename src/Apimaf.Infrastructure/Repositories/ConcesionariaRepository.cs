using Apimaf.Domain.Entities;
using Apimaf.Domain.Interfaces;
using Apimaf.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Apimaf.Infrastructure.Repositories;

/// <summary>
/// Implementación de repositorio de concesionarias usando EF Core.
/// </summary>
public class ConcesionariaRepository : IConcesionariaRepository
{
    private readonly ApplicationDbContext _context;

    public ConcesionariaRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    // TODO: Devuelve todas las concesionarias
    public async Task<IEnumerable<Concesionaria>> GetAllAsync()
        => await _context.Concesionarias.AsNoTracking().ToListAsync();

    // TODO: Busca una concesionaria por id
    public async Task<Concesionaria?> GetByIdAsync(int id)
        => await _context.Concesionarias.FindAsync(id);

    // TODO: Crea una nueva concesionaria
    public async Task AddAsync(Concesionaria entity)
        => await _context.Concesionarias.AddAsync(entity);

    // TODO: Guarda los cambios
    public async Task SaveChangesAsync()
        => await _context.SaveChangesAsync();
}
