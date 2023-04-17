using Microsoft.AspNetCore.Mvc;
using servicio.api.reglamento.Core.Entity;
using servicio.api.reglamento.Core.Interfaces;

namespace servicio.api.reglamento.Controllers;

[Route("api/[controller]")]
public class ReglamentoController : ControllerBase
{
    IReglamentoService _service;

    public ReglamentoController(IReglamentoService reglamentoService)
    {
        _service = reglamentoService;
    }

    [HttpGet]
    public ActionResult Get()
    {
        return Ok(_service.Get());
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<ReglamentoEntity>> GetById(Guid id)
    {
        var rta = await _service.GetById(id);
        return Ok(rta);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] ReglamentoEntity reglamento)
    {
        var rta = await _service.Create(reglamento);
        return Ok(rta);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(Guid id, [FromBody] ReglamentoEntity reglamento)
    {
        await _service.Update(id, reglamento);

        return Ok("Reglamento actualizado!");
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        await _service.Delete(id);

        return Ok("Reglamento eliminado correctamente");
    }

}