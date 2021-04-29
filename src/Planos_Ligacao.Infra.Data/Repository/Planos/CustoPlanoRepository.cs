using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;
using PlanosLigacao.Domain.Entities.Planos;
using PlanosLigacao.Domain.Interfaces.Repository;
using PlanosLigacao.Infra.Data.Context;

namespace PlanosLigacao.Infra.Data.Repository.Planos
{
    public class CustoPlanoRepository: Repository<CustoPlano>, ICustoPlanoRepository
    {
        public CustoPlanoRepository(PlanosLigacaoContext context): base(context)
        {

        }

        public async Task<CustoPlano> BuscarPlanoPorId(Guid custoPlanoId)
        {
            return await DbSet.AsNoTracking().Where(p => p.Id == custoPlanoId).FirstOrDefaultAsync();
        }
    }
}
