using Microsoft.AspNetCore.Mvc;
using Apimaf.Application.Services;
using Apimaf.Application.DTOs;

namespace Apimaf.WebAPI.Controllers;

/// <summary>
/// Controlador para manejar concesionarios.
/// </summary>
[ApiController]
[Route("concesionarios")]
public class ConcesionariosController : ControllerBase
{
    private readonly ConcesionarioService _service;

    public ConcesionariosController(ConcesionarioService service)
    {
        _service = service;
    }

    // TODO: Devuelve todos los concesionarios
    [HttpGet]
    public async Task<ActionResult<ApiResponse<IEnumerable<ConcesionarioDto>>>> Get()
    {
        var data = await _service.GetAllAsync();
        return Ok(new ApiResponse<IEnumerable<ConcesionarioDto>>(200, "successful operation", data));
    }
}
