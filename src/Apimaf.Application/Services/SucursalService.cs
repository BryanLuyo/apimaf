using Apimaf.Application.DTOs;
using Apimaf.Domain.Entities;
using Apimaf.Domain.Interfaces;

namespace Apimaf.Application.Services;

/// <summary>
/// Servicio de aplicación para manejar sucursales.
/// </summary>
public class SucursalService
{
    private readonly ISucursalRepository _repository;

    public SucursalService(ISucursalRepository repository)
    {
        _repository = repository;
    }

    // TODO: Obtiene las sucursales por concesionaria
    public async Task<IEnumerable<SucursalDto>> GetByConcesionariaIdAsync(int concesionariaId)
    {
        var items = await _repository.GetByConcesionariaIdAsync(concesionariaId);
        return items.Select(s => new SucursalDto(s.Id, s.IdConcesionaria, s.NomComercial));
    }

    // TODO: Crea una nueva sucursal
    public async Task<int> CreateAsync(SucursalDto dto)
    {
        var entity = new Sucursal
        {
            IdConcesionaria = dto.IdConcesionaria,
            NomComercial = dto.NomComercial
        };
        await _repository.AddAsync(entity);
        await _repository.SaveChangesAsync();
        return entity.Id;
    }
}
