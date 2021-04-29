using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PlanosLigacao.Domain.Interfaces.Services
{
    public interface IBaseService<TEntity> : IDisposable where TEntity : class
    {
        Task<IEnumerable<TEntity>> GetAll();
    }
}
