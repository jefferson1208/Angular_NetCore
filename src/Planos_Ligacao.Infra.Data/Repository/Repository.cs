using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using PlanosLigacao.Domain.Interfaces.Repository;
using PlanosLigacao.Infra.Data.Context;

namespace PlanosLigacao.Infra.Data.Repository
{
    public abstract class Repository<TEntity> : IRepository<TEntity> where TEntity : class, new()
    {
        protected readonly PlanosLigacaoContext Db;
        protected readonly DbSet<TEntity> DbSet;
        protected Repository(PlanosLigacaoContext context)
        {
            Db = context;
            DbSet = context.Set<TEntity>();
        }

        public void Dispose()
        {
            Db?.Dispose();
        }

        public async Task<List<TEntity>> GetAll()
        {
            return await DbSet.ToListAsync();
        }

    }
}
