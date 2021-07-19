using System;

namespace Desafio.Api.Domain.Entities
{
  public class Turma
  {
    public Guid Id { get; set; }
    public int Codigo { get; set; }
    public string Nome { get; set; }
    public Guid EscolaId { get; set; }
    public virtual Escola EscolaReference { get; set; }

  }
}