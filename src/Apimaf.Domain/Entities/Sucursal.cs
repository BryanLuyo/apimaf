namespace Apimaf.Domain.Entities;

/// <summary>
/// Representa una sucursal del concesionario.
/// </summary>
public class Sucursal
{
    public int Id { get; set; }
    public int IdConcesionario { get; set; }
    public string NomComercial { get; set; } = string.Empty;
    public int FlgEstado { get; set; } = 1;
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

    // TODO: Propiedad de navegación al Concesionario
    public Concesionario? Concesionario { get; set; }
}
