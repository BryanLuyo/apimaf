using Apimaf.Domain.Entities;

namespace Apimaf.Domain.Interfaces;

/// <summary>
/// Contrato para manejar los concesionarios.
/// </summary>
public interface IConcesionarioRepository
{
    // TODO: Devuelve todos los concesionarios
    Task<IEnumerable<Concesionario>> GetAllAsync();

    // TODO: Busca un concesionario por id
    Task<Concesionario?> GetByIdAsync(int id);

    // TODO: Crea un nuevo concesionario
    Task AddAsync(Concesionario entity);

    // TODO: Guarda los cambios
    Task SaveChangesAsync();
}
