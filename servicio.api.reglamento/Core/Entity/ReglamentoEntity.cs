namespace servicio.api.reglamento.Core.Entity;

public class ReglamentoEntity
{
    public Guid ReglamentoId { get; set; }
    public string Titulo { get; set; }
    public string Descripcion { get; set; }
    public string DocumentoUrl { get; set; }
    public string ImagenUrl { get; set; }

    public DateTime FechaCreado { get; set; }
    public TipoReglamento Tipo { get; set; }

    public StatusReglamento Estado { get; set; }

}

public enum StatusReglamento
{
    Activo,
    Inactivo

}

public enum TipoReglamento
{
    LPF,
    PROM,

    JUVENIL,
    LFF,
    CONDUCTA
}