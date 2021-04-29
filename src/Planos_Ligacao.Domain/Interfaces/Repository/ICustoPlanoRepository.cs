using System;
using System.Threading.Tasks;
using PlanosLigacao.Domain.Entities.Planos;

namespace PlanosLigacao.Domain.Interfaces.Repository
{
    public interface ICustoPlanoRepository : IRepository<CustoPlano>
    {
        Task<CustoPlano> BuscarPlanoPorId(Guid custoPlanoId);
    }
}
