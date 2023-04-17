using servicio.api.reglamento.Core.Context;
using servicio.api.reglamento.Core.Entity;
using servicio.api.reglamento.Core.Interfaces;

namespace servicio.api.reglamento.Core.Services;

public class ReglamentoService : IReglamento
{
    private readonly ReglamentoContext _context;

    public ReglamentoService(ReglamentoContext dbcontext)
    {
        _context = dbcontext;
    }

    public IEnumerable<ReglamentoEntity> Get()
    {
        return _context.Reglamentos;
    }

    public async Task Create(ReglamentoEntity reglamento)
    {
        reglamento.FechaCreado = DateTime.Now;

        _context.Add(reglamento);

        await _context.SaveChangesAsync();


    }

    public async Task Update(Guid id, ReglamentoEntity reglamento)
    {
        var reglamentoActual = await _context.Reglamentos.FindAsync(id);

        if (reglamentoActual != null)
        {
            reglamentoActual.Titulo = reglamento.Titulo;
            reglamentoActual.Descripcion = reglamento.Descripcion;
            reglamentoActual.DocumentoUrl = reglamento.DocumentoUrl;
            reglamentoActual.ImagenUrl = reglamento.ImagenUrl;
            reglamentoActual.Tipo = reglamento.Tipo;
            reglamentoActual.Estado = reglamento.Estado;

            await _context.SaveChangesAsync();
        }
    }
    public async Task Delete(Guid id)
    {
        var reglamentoActual = await _context.Reglamentos.FindAsync(id);

        if (reglamentoActual != null)
        {
            _context.Remove(reglamentoActual);

            await _context.SaveChangesAsync();

        }
    }


}