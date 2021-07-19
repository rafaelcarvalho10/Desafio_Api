using Desafio.Api.Domain.Entities;
using Desafio.Api.Domain.Interface.Repositories;
using Desafio.Api.Domain.Interface.Services;

namespace Desafio.Api.Service.TurmaService
{
  public class TurmaService : ServiceBase<Turma>, ITurmaService
  {
    private readonly ITurmaRepository _repository;

    public TurmaService(ITurmaRepository repository) : base(repository)
    {
      _repository = repository;
    }
  }
}