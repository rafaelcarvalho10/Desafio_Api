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
  public class TurmaController : ControllerBase
  {

    public TurmaController()
    {
    }

    [HttpGet()]
    [AllowAnonymous]
    public async Task<ActionResult> Get([FromServices] ITurmaService serviceTurma)
    {
      if (ModelState.IsValid)
      {
        var result = await serviceTurma.GetAllAsync();
        return Ok(result);
      }
      return BadRequest(ModelState);

    }


    [HttpGet("{id}", Name = "GetTurmaById")]
    [AllowAnonymous]
    public async Task<ActionResult> GetById([FromServices] ITurmaService serviceTurma, [FromRoute][Required] Guid id)
    {
      if (ModelState.IsValid)
      {
        var result = await serviceTurma.GetByIdAsync(id);

        if (result == null)
          return NotFound(new { id });
        else
          return Ok(result);
      }
      return BadRequest(ModelState);

    }

    [HttpPost()]
    [AllowAnonymous]
    public async Task<ActionResult> Post([FromServices] ITurmaService turmaService, [FromBody] Turma model)
    {
      if (ModelState.IsValid)
      {
        var result = await turmaService.AddAsync(model);
        return CreatedAtRoute("GetTurmaById", new { id = result.Id }, result);
      }
      return BadRequest(ModelState);
    }



    [HttpPut("{id}")]
    [AllowAnonymous]
    public async Task<ActionResult> Put([FromServices] ITurmaService turmaService, [FromRoute][Required] Guid id, [FromBody] Turma model)
    {
      if (ModelState.IsValid)
      {
        var result = await turmaService.UpdateAsync(model, id);

        if (result == null)
          return NotFound(new { id });

        return Ok(result);
      }
      return BadRequest(ModelState);
    }


    [HttpDelete("{id}")]
    [AllowAnonymous]
    public async Task<ActionResult> Delete([FromServices] ITurmaService turmaService, [FromRoute][Required] Guid id)
    {
      if (ModelState.IsValid)
      {
        var result = await turmaService.DeleteAsync(id);
        if (result == 0) return NotFound(new { id }); else return Ok();
      }
      return BadRequest(ModelState);
    }
  }
}