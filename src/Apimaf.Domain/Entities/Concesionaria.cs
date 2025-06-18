namespace Apimaf.Domain.Entities;

/// <summary>
/// Entidad principal de una concesionaria de autos.
/// </summary>
public class Concesionaria
{
    public int Id { get; set; }
    public int Cod { get; set; }
    public string NomComercial { get; set; } = string.Empty;
    public string Nombre { get; set; } = string.Empty;
    public string? Descripcion { get; set; }
    public int FlgEstado { get; set; } = 1;
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

    // TODO: Lista de sucursales asociadas a la concesionaria
    public ICollection<Sucursal> Sucursales { get; set; } = new List<Sucursal>();
}
