using FluentValidation;
using PlanosLigacao.Domain.Entities.Planos;

namespace PlanosLigacao.Domain.Validation
{
    public class CalculoPlanoValidation: AbstractValidator<CalculoPlano>
    {
        public CalculoPlanoValidation()
        {
            RuleFor(e => e.CustoPlanoId)
                .NotEmpty().WithMessage("O Campo {PropertyName} é obrigatório!")
                .NotNull().WithMessage("O Campo {PropertyName} é obrigatório!");

            RuleFor(e => e.PlanoId)
                .NotEmpty().WithMessage("O Campo {PropertyName} é obrigatório!")
                .NotNull().WithMessage("O Campo {PropertyName} é obrigatório!");

            RuleFor(e => e.TempoCliente)
                .NotEmpty().WithMessage("O Campo {PropertyName} é obrigatório!")
                .NotNull().WithMessage("O Campo {PropertyName} é obrigatório!")
                .NotEqual(0).WithMessage("O Campo {PropertyName} é obrigatório!");
        }
    }
}
