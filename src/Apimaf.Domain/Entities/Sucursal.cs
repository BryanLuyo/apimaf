namespace Apimaf.Domain.Entities;

/// <summary>
/// Representa una sucursal de la concesionaria.
/// </summary>
public class Sucursal
{
    public int Id { get; set; }
    public int IdConcesionaria { get; set; }
    public string NomComercial { get; set; } = string.Empty;
    public int FlgEstado { get; set; } = 1;
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

    // TODO: Propiedad de navegación a Concesionaria
    public Concesionaria? Concesionaria { get; set; }
}
