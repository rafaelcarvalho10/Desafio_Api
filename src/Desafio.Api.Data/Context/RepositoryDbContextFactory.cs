using System;
using Desafio.Api.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Pay.Me.Service.Data.Context
{
  public class RepositoryDbContextFactory : IDesignTimeDbContextFactory<RepositoryDbContext>
  {
    public RepositoryDbContext CreateDbContext(string[] args)
    {
      var optionsBuilder = new DbContextOptionsBuilder<RepositoryDbContext>();

      var SQL_CONNECTION = Environment.GetEnvironmentVariable("SQL_CONNECTION") ?? @"Server=localhost,1433;Database=Desafio;User ID=sa;Password=ra81723069";

      optionsBuilder
          .UseSqlServer(SQL_CONNECTION, providerOptions => providerOptions
              .EnableRetryOnFailure(3)
              .CommandTimeout(30)
          );

      return new RepositoryDbContext(optionsBuilder.Options);
    }
  }
}
