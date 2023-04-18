using Microsoft.EntityFrameworkCore;
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

    public async Task<IEnumerable<ReglamentoEntity>> GetAll()
    {
        return await _context.Reglamentos.ToListAsync();
    }

    public async Task<ReglamentoEntity> GetById(Guid id)
    {
        // return await _context.Reglamentos.FirstOrDefaultAsync(x => x.Id == id);
        return await _context.Reglamentos.FindAsync(id);

    }

    public async Task<ReglamentoEntity> Create(ReglamentoEntity reglamento)
    {
        reglamento.FechaCreado = DateTime.Now;

        await _context.AddAsync(reglamento);

        await _context.SaveChangesAsync();

        return reglamento;


    }

    public async Task<bool> Update(Guid id, ReglamentoEntity reglamento)
    {
        var reglamentoActual = await _context.Reglamentos.FindAsync(id);

        if (reglamentoActual == null)
        {
            return false;
            // throw new Exception($"Ocurrio un error al actualizar reglamento con ID: ${id}");
        }
        reglamentoActual.Titulo = reglamento.Titulo;
        reglamentoActual.Descripcion = reglamento.Descripcion;
        reglamentoActual.DocumentoUrl = reglamento.DocumentoUrl;
        reglamentoActual.ImagenUrl = reglamento.ImagenUrl;
        reglamentoActual.Tipo = reglamento.Tipo;
        reglamentoActual.Estado = reglamento.Estado;

        var rta = await _context.SaveChangesAsync();
        Console.WriteLine(rta);
        return true;


    }
    public async Task<bool> Delete(Guid id)
    {
        var reglamentoActual = await _context.Reglamentos.FindAsync(id);

        if (reglamentoActual == null)
        {
            return false;

            // throw new Exception($"Ocurrio un error al eliminar reglamento con ID: ${id}");

        }

        _context.Remove(reglamentoActual);

        await _context.SaveChangesAsync();
        return true;

    }


}