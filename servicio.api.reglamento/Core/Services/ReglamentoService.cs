using servicio.api.reglamento.Core.Context;
using servicio.api.reglamento.Core.Entity;
using servicio.api.reglamento.Core.Interfaces;

namespace servicio.api.reglamento.Core.Services;

public class ReglamentoService : IReglamentoService
{
    private readonly ReglamentoContext _context;

    public ReglamentoService(ReglamentoContext dbcontext)
    {
        _context = dbcontext;
    }

    public IEnumerable<ReglamentoEntity> Get()
    {
        return _context.Reglamentos.ToList();
    }

    public async Task<ReglamentoEntity> GetById(Guid id)
    {
        var reglamento = await _context.Reglamentos.FindAsync(id);

        if (reglamento != null)
        {
            return reglamento;
        }

        throw new Exception($"No existe el reglamento con ID: {id}");
    }

    public async Task<ReglamentoEntity> Create(ReglamentoEntity reglamento)
    {
        reglamento.FechaCreado = DateTime.Now;

        await _context.AddAsync(reglamento);

        await _context.SaveChangesAsync();

        return reglamento;


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

            var rta = await _context.SaveChangesAsync();
            Console.WriteLine(rta);
        }
        else
        {

            throw new Exception($"Ocurrio un error al actualizar reglamento con ID: ${id}");
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