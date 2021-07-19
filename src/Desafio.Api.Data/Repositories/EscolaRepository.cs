using Desafio.Api.Data.Context;
using Desafio.Api.Domain.Entities;
using Desafio.Api.Domain.Interface.Repositories;

namespace Desafio.Api.Data.Repositories
{
  public class EscolaRepository : RepositoryBase<Escola>, IEscolaRepository
  {
    readonly RepositoryDbContext _repositoryDbContext;

    public EscolaRepository(RepositoryDbContext repositoryDbContext) : base(repositoryDbContext)
    {
      _repositoryDbContext = repositoryDbContext;
    }
  }
}