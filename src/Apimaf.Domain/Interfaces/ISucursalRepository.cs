using Apimaf.Domain.Entities;

namespace Apimaf.Domain.Interfaces;

/// <summary>
/// Contrato para manejar las sucursales.
/// </summary>
public interface ISucursalRepository
{
    // TODO: Obtiene todas las sucursales de una concesionaria
    Task<IEnumerable<Sucursal>> GetByConcesionariaIdAsync(int concesionariaId);

    // TODO: Crea una nueva sucursal
    Task AddAsync(Sucursal entity);

    // TODO: Guarda los cambios
    Task SaveChangesAsync();
}
