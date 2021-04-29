using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;
using PlanosLigacao.Domain.Entities.Planos;
using PlanosLigacao.Domain.Interfaces.Repository;
using PlanosLigacao.Infra.Data.Context;

namespace PlanosLigacao.Infra.Data.Repository.Planos
{
    public class PlanoRepository: Repository<Plano>, IPlanoRepository
    {
        public PlanoRepository(PlanosLigacaoContext context) : base(context)
        {

        }

        public async Task<Plano> BuscarPlanoPorId(Guid planoId)
        {
            return await DbSet.AsNoTracking().Where(p => p.Id == planoId).FirstOrDefaultAsync();
        }
    }
}
