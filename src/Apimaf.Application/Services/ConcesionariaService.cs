using Apimaf.Application.DTOs;
using Apimaf.Domain.Entities;
using Apimaf.Domain.Interfaces;

namespace Apimaf.Application.Services;

/// <summary>
/// Servicio de aplicación para manejar concesionarias.
/// </summary>
public class ConcesionariaService
{
    private readonly IConcesionariaRepository _repository;

    public ConcesionariaService(IConcesionariaRepository repository)
    {
        _repository = repository;
    }

    // TODO: Devuelve todas las concesionarias como DTOs
    public async Task<IEnumerable<ConcesionariaDto>> GetAllAsync()
    {
        var items = await _repository.GetAllAsync();
        return items.Select(c => new ConcesionariaDto(c.Id, c.Cod, c.NomComercial, c.Nombre));
    }

    // TODO: Crea una nueva concesionaria
    public async Task<int> CreateAsync(ConcesionariaDto dto)
    {
        var entity = new Concesionaria
        {
            Cod = dto.Cod,
            NomComercial = dto.NomComercial,
            Nombre = dto.Nombre
        };
        await _repository.AddAsync(entity);
        await _repository.SaveChangesAsync();
        return entity.Id;
    }
}
