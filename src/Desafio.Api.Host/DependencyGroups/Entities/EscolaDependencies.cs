using Desafio.Api.Data.Repositories;
using Desafio.Api.Domain.Interface;
using Desafio.Api.Domain.Interface.Repositories;
using Desafio.Api.Domain.Interface.Services;
using Desafio.Api.Service.EscolaService;
using Microsoft.Extensions.DependencyInjection;

namespace Desafio.Api.Host.DependencyGroups.Entities
{
  public class EscolaDependencies : IDependencyGroup
  {
    /// <summary>
    /// This method is called to register dependencies with this application service collection.
    /// </summary>
    /// <param name="serviceCollection">The service collection to register with.</param>

    public void Register(IServiceCollection serviceCollection)
    {
      //repositories
      serviceCollection.AddTransient<IEscolaRepository, EscolaRepository>();

      //services
      serviceCollection.AddTransient<IEscolaService, EscolaService>();
    }
  }
}
