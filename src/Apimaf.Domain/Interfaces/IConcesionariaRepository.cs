using Apimaf.Domain.Entities;

namespace Apimaf.Domain.Interfaces;

/// <summary>
/// Contrato para manejar las concesionarias.
/// </summary>
public interface IConcesionariaRepository
{
    // TODO: Devuelve todas las concesionarias
    Task<IEnumerable<Concesionaria>> GetAllAsync();

    // TODO: Busca una concesionaria por id
    Task<Concesionaria?> GetByIdAsync(int id);

    // TODO: Crea una nueva concesionaria
    Task AddAsync(Concesionaria entity);

    // TODO: Guarda los cambios
    Task SaveChangesAsync();
}
