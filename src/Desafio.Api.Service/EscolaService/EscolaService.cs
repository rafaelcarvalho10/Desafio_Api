using Desafio.Api.Domain.Entities;
using Desafio.Api.Domain.Interface.Repositories;
using Desafio.Api.Domain.Interface.Services;

namespace Desafio.Api.Service.EscolaService
{
  public class EscolaService : ServiceBase<Escola>, IEscolaService
  {
    private readonly IEscolaRepository _repository;

    public EscolaService(IEscolaRepository repository) : base(repository)
    {
      _repository = repository;
    }
  }
}