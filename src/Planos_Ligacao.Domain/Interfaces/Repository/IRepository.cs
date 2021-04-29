using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PlanosLigacao.Domain.Interfaces.Repository
{
    public interface IRepository<TEntity>: IDisposable where TEntity : class
    {
        Task<List<TEntity>> GetAll();
    }
}
