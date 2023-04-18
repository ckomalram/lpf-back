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
    public async Task<ActionResult<IEnumerable<ReglamentoEntity>>> GetAll()
    {
        var rta = await _service.GetAll();
        return Ok(rta);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<ReglamentoEntity>> GetById(Guid id)
    {
        var rta = await _service.GetById(id);
        if (rta == null)
        {
            return NotFound();
        }
        return Ok(rta);
    }

    [HttpPost]
    public async Task<ActionResult<ReglamentoEntity>> Create([FromBody] ReglamentoEntity reglamento)
    {
        var rta = await _service.Create(reglamento);
        Console.WriteLine(rta);
        return CreatedAtAction(nameof(GetById), new { id = reglamento.ReglamentoId }, reglamento);
        // return Ok(reglamento);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult> Update(Guid id, [FromBody] ReglamentoEntity reglamento)
    {

        var rta = await _service.Update(id, reglamento);

        if (!rta)
        {
            return NotFound();
        }

        return Ok("Reglamento actualizado!");
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete(Guid id)
    {
        var rta = await _service.Delete(id);

        if (!rta)
        {
            return NotFound();
        }
        return Ok("Reglamento eliminado correctamente");
    }

}