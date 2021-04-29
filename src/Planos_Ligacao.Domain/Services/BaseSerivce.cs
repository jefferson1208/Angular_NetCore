using System.Collections.Generic;
using System.Threading.Tasks;
using PlanosLigacao.Domain.Interfaces.Repository;
using PlanosLigacao.Domain.Interfaces.Services;
using PlanosLigacao.Domain.Notifications;
using FluentValidation.Results;

namespace PlanosLigacao.Domain.Services
{
    public abstract class BaseSerivce<TEntity>: IBaseService<TEntity> where TEntity : class
    {
        private readonly IRepository<TEntity> _repository;
        private readonly INotificador _notificador;
        public BaseSerivce(IRepository<TEntity> repository, INotificador notificador)
        {
            _repository = repository;
            _notificador = notificador;
        }

        public virtual void Dispose()
        {
            _repository?.Dispose();
        }

        protected void Notificar(ValidationResult validationResult)
        {
            foreach (var error in validationResult.Errors)
            {
                Notificar(error.ErrorMessage);
            }
        }

        protected void Notificar(string mensagem)
        {
            _notificador.Handle(new Notificacao(mensagem));
        }
        public async Task<IEnumerable<TEntity>> GetAll()
        {
            return await _repository.GetAll();
        }
    }
}
