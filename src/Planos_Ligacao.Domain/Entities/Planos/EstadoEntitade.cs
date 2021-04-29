using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Text;

namespace PlanosLigacao.Domain.Entities.Planos
{
    public class EstadoEntitade
    {
        public bool Valido { get; set; }
        public ValidationResult Mensagens { get; set; }
    }
}
