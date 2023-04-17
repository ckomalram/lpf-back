using Microsoft.EntityFrameworkCore;
using servicio.api.reglamento.Core.Entity;

namespace servicio.api.reglamento.Core.Context;

public class ReglamentoContext : DbContext
{
    public DbSet<ReglamentoEntity> Reglamentos { get; set; }

    public ReglamentoContext(DbContextOptions<ReglamentoContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {

        // Crear Semillero
        List<ReglamentoEntity> reglamentoInit = new List<ReglamentoEntity>();
        reglamentoInit.Add(
            new ReglamentoEntity()
            {
                ReglamentoId = Guid.Parse("71c87875-4439-4d7c-ba96-f8ba9136db03"),
                Titulo = "LPF",
                Descripcion = "Reglamento de ligra masculina de futbol lpf",
                DocumentoUrl = "https://lpf.com.pa/wp-content/uploads/2023/01/REGLAMENTO-DE-COMPETENCIA-LPF-2023.pdf",
                ImagenUrl = "https://lpf.com.pa/wp-content/uploads/2023/01/REGLAMENTO-DE-COMPETENCIA-LPF-2023-791x1024.webp",
                FechaCreado = DateTime.Now,
                Tipo = TipoReglamento.LPF,
                Estado = StatusReglamento.Activo
            }
        );

        // Crear Validaciones
        modelBuilder.Entity<ReglamentoEntity>(reglamento =>
        {
            reglamento.ToTable("Reglamento");
            reglamento.HasKey(p => p.ReglamentoId);
            reglamento.Property(p => p.Titulo).IsRequired();
            reglamento.Property(p => p.Descripcion).IsRequired();
            reglamento.Property(p => p.DocumentoUrl).IsRequired();
            reglamento.Property(p => p.ImagenUrl).IsRequired();
            reglamento.Property(p => p.Tipo).IsRequired();
            reglamento.Property(p => p.Estado).IsRequired();
            reglamento.Property(p => p.FechaCreado);
        });


    }

}