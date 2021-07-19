using System;

namespace Desafio.Api.Domain.Entities
{
  public class Escola
  {
    public Guid Id { get; set; }
    public int Codigo { get; set; }
    public string Nome { get; set; }
  }
}