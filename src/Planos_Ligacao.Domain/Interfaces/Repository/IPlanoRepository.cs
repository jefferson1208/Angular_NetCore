using System;
using System.Threading.Tasks;
using PlanosLigacao.Domain.Entities.Planos;

namespace PlanosLigacao.Domain.Interfaces.Repository
{
    public interface IPlanoRepository : IRepository<Plano>
    {
        Task<Plano> BuscarPlanoPorId(Guid planoId);
    }
}
