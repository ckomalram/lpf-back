using servicio.api.reglamento.Core.Entity;

namespace servicio.api.reglamento.Core.Interfaces;

public interface IReglamentoService
{
    IEnumerable<ReglamentoEntity> Get();
    Task<ReglamentoEntity> GetById(Guid id);

    Task<ReglamentoEntity> Create(ReglamentoEntity reglamento);
    Task Update(Guid id, ReglamentoEntity reglamento);
    Task Delete(Guid id);

}