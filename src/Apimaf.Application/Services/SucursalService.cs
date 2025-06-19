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

    // TODO: Obtiene las sucursales por concesionario
    public async Task<IEnumerable<SucursalDto>> GetByConcesionarioIdAsync(int concesionarioId)
    {
        var items = await _repository.GetByConcesionarioIdAsync(concesionarioId);
        return items.Select(s => new SucursalDto(s.Id, s.IdConcesionario, s.NomComercial));
    }

    // TODO: Crea una nueva sucursal
    public async Task<int> CreateAsync(SucursalDto dto)
    {
        var entity = new Sucursal
        {
            IdConcesionario = dto.IdConcesionario,
            NomComercial = dto.NomComercial
        };
        await _repository.AddAsync(entity);
        await _repository.SaveChangesAsync();
        return entity.Id;
    }
}
