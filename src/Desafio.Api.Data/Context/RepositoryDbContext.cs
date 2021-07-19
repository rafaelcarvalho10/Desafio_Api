using Microsoft.EntityFrameworkCore;

namespace Desafio.Api.Data.Context
{
  public partial class RepositoryDbContext : DbContext
  {
    public RepositoryDbContext(DbContextOptions options) : base(options)
    {
    }

    public void RunMigrate()
    {
      this.Database.Migrate();
    }

    public void Drop()
    {
      this.Database.EnsureDeleted();
    }
  }
}
