using System.Collections.Generic;
using PlanosLigacao.Domain.Notifications;

namespace PlanosLigacao.Domain.Interfaces.Services
{
    public interface INotificador
    {
        bool TemNotificacao();
        List<Notificacao> ObterNotificacoes();
        void Handle(Notificacao notificacao);
    }
}
