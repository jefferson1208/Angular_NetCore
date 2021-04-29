using System.Threading.Tasks;
using PlanosLigacao.Domain.Entities.Planos;
using PlanosLigacao.Domain.Interfaces.Repository;
using PlanosLigacao.Domain.Interfaces.Services;

namespace PlanosLigacao.Domain.Services
{
    public class CustoPlanoService : BaseSerivce<CustoPlano>, ICustoPlanoService
    {

        private readonly ICustoPlanoRepository _custoPlanoRepository;
        private readonly IPlanoRepository _planoRepository;
        public CustoPlanoService(ICustoPlanoRepository custoPlanoRepository,
            IPlanoRepository planoRepository,
            INotificador notificador): base(custoPlanoRepository, notificador)
        {
            _custoPlanoRepository = custoPlanoRepository;
            _planoRepository = planoRepository;
        }

        public async Task<CalculoPlano> CalcularCustoPlano(CalculoPlano calculoPlano)
        {
            var valid = calculoPlano.Validar();

            if (!valid.Valido)
            {
                Notificar(valid.Mensagens);
                return null;
            };

            var custoPlano = await _custoPlanoRepository.BuscarPlanoPorId(calculoPlano.CustoPlanoId);
            var plano = await _planoRepository.BuscarPlanoPorId(calculoPlano.PlanoId);


            calculoPlano.CustoPlano = custoPlano.CalcularCustoPlano(plano.CalcularExcedente(calculoPlano.TempoCliente));
            calculoPlano.CustoSemPlano = custoPlano.CaclularCustoSemPlano(calculoPlano.TempoCliente);
     
            return calculoPlano;

        }

        public override void Dispose()
        {
            _custoPlanoRepository?.Dispose();
            _planoRepository?.Dispose();
        }
    }
}
