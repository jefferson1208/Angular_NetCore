using Microsoft.EntityFrameworkCore;
using PlanosLigacao.Domain.Entities.Planos;
using System.Linq;

namespace PlanosLigacao.Infra.Data.Context
{
    public class PlanosLigacaoContext : DbContext
    {
        public PlanosLigacaoContext(DbContextOptions<PlanosLigacaoContext> options) : base(options) { }
        public DbSet<Plano> Planos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            foreach (var property in modelBuilder.Model.GetEntityTypes()
                .SelectMany(e => e.GetProperties()
                    .Where(p => p.ClrType == typeof(string))))
                property.SetColumnType("varchar(100)");

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(PlanosLigacaoContext).Assembly);

            foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys())) relationship.DeleteBehavior = DeleteBehavior.ClientSetNull;
            
            base.OnModelCreating(modelBuilder);
        }
    }
}
