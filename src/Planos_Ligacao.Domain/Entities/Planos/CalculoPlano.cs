using System;
using System.ComponentModel.DataAnnotations.Schema;
using PlanosLigacao.Domain.Validation;

namespace PlanosLigacao.Domain.Entities.Planos
{
    [NotMapped]
    public class CalculoPlano
    {
        public Guid CustoPlanoId { get; set; }
        public Guid PlanoId { get; set; }
        public int TempoCliente { get; set; }

        public decimal CustoPlano { get; set; }
        public decimal CustoSemPlano { get; set; }



        public EstadoEntitade Validar()
        {
            var validator = new CalculoPlanoValidation().Validate(this);

            if (!validator.IsValid)
            {
                return new EstadoEntitade
                {
                    Valido = false,
                    Mensagens = validator
                };
            }

            return new EstadoEntitade
            {
                Valido = true
            };
        }
    }
}
