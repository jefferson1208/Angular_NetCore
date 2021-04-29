using System;
using System.Threading.Tasks;
using PlanosLigacao.Domain.Entities.Planos;

namespace PlanosLigacao.Domain.Interfaces.Services
{
    public interface ICustoPlanoService: IDisposable, IBaseService<CustoPlano>
    {
        Task<CalculoPlano> CalcularCustoPlano(CalculoPlano calculoPlano);

   
    }
}
