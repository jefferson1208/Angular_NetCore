using PlanosLigacao.Domain.Entities.Planos;
using PlanosLigacao.Domain.Interfaces.Repository;
using PlanosLigacao.Domain.Interfaces.Services;
using PlanosLigacao.Domain.Services;

namespace PlanosLigacao.Domain.Services
{
    public class PlanoService : BaseSerivce<Plano>, IPlanoService
    {

        public PlanoService(IPlanoRepository planoRepository, INotificador notificador): base(planoRepository, notificador)
        {

        }
    }
}
