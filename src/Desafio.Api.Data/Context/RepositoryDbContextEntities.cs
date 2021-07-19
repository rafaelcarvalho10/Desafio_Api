using Desafio.Api.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Desafio.Api.Data.Context
{
  public partial class RepositoryDbContext : DbContext
  {
    public DbSet<Escola> Escola { get; set; }
    public DbSet<Turma> Turma { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      modelBuilder.Entity<Escola>();
      modelBuilder.Entity<Turma>(entity =>
      {
        entity.HasOne<Escola>(o => o.EscolaReference)
                .WithMany()
                .HasForeignKey(o => o.EscolaId)
                .HasPrincipalKey(d => d.Id)
                .IsRequired(true)
                .OnDelete(DeleteBehavior.Restrict);
      });

      base.OnModelCreating(modelBuilder);
    }
  }
}