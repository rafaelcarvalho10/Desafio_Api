using Microsoft.Extensions.DependencyInjection;

namespace Desafio.Api.Domain.Interface
{
  public interface IDependencyGroup
  {
    void Register(IServiceCollection serviceCollection);
  }
}