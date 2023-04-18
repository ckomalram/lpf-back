using servicio.api.reglamento.Core.Entity;

namespace servicio.api.reglamento.Core.Interfaces;

public interface IReglamentoService
{
    Task<IEnumerable<ReglamentoEntity>> GetAll();
    Task<ReglamentoEntity> GetById(Guid id);

    Task<ReglamentoEntity> Create(ReglamentoEntity reglamento);
    Task<bool> Update(Guid id, ReglamentoEntity reglamento);
    Task<bool> Delete(Guid id);

}