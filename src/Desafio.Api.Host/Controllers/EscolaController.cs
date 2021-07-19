using System;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using Desafio.Api.Core.Entities;
using Desafio.Api.Domain.Entities;
using Desafio.Api.Domain.Interface.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Desafio.Api.Controllers
{
  [ApiController]
  [Route("[controller]")]
  public class EscolaController : ControllerBase
  {

    public EscolaController()
    {
    }

    [HttpGet()]
    [AllowAnonymous]
    public async Task<ActionResult> Get([FromServices] IEscolaService serviceEscola)
    {
      if (ModelState.IsValid)
      {
        var result = await serviceEscola.GetAllAsync();
        return Ok(result);
      }
      return BadRequest(ModelState);

    }

    [HttpGet("{id}", Name = "GetEscolaById")]
    [AllowAnonymous]
    public async Task<ActionResult> GetById([FromServices] IEscolaService serviceEscola, [FromRoute][Required] Guid id)
    {
      if (ModelState.IsValid)
      {
        var result = await serviceEscola.GetByIdAsync(id);

        if (result == null)
          return NotFound(new { id });
        else
          return Ok(result);
      }
      return BadRequest(ModelState);

    }


    [HttpPost()]
    [AllowAnonymous]
    public async Task<ActionResult> Post([FromServices] IEscolaService escolaService, [FromBody] Escola model)
    {
      if (ModelState.IsValid)
      {
        var result = await escolaService.AddAsync(model);
        return CreatedAtRoute("GetEscolaById", new { id = result.Id }, result);
      }
      return BadRequest(ModelState);
    }


    [HttpPut("{id}")]
    [AllowAnonymous]
    public async Task<ActionResult> Put([FromServices] IEscolaService escolaService, [FromRoute][Required] Guid id, [FromBody] Escola model)
    {
      if (ModelState.IsValid)
      {
        var result = await escolaService.UpdateAsync(model, id);

        if (result == null)
          return NotFound(new { id });

        return Ok(result);
      }
      return BadRequest(ModelState);
    }


    [HttpDelete("{id}")]
    [AllowAnonymous]
    public async Task<ActionResult> Delete([FromServices] IEscolaService escolaService, [FromRoute][Required] Guid id)
    {
      if (ModelState.IsValid)
      {
        var result = await escolaService.DeleteAsync(id);
        if (result == 0) return NotFound(new { id }); else return Ok();
      }
      return BadRequest(ModelState);
    }
  }
}
