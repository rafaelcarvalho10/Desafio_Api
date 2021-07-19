using Desafio.Api.Data.Context;
using Desafio.Api.Domain.Entities;
using Desafio.Api.Domain.Interface.Repositories;

namespace Desafio.Api.Data.Repositories
{
  public class TurmaRepository : RepositoryBase<Turma>, ITurmaRepository
  {
    readonly RepositoryDbContext _repositoryDbContext;

    public TurmaRepository(RepositoryDbContext repositoryDbContext) : base(repositoryDbContext)
    {
      _repositoryDbContext = repositoryDbContext;
    }
  }
}