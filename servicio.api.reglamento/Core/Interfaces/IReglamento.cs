using servicio.api.reglamento.Core.Entity;

namespace servicio.api.reglamento.Core.Interfaces;

public interface IReglamento
{
    IEnumerable<ReglamentoEntity> Get();

    Task Create(ReglamentoEntity reglamento);
    Task Update(Guid id, ReglamentoEntity reglamento);
    Task Delete(Guid id);

}