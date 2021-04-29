using System;

namespace PlanosLigacao.Application.ViewModels.Planos
{
    public class CalculoPlanoViewModel
    {
        public Guid CustoPlanoId { get; set; }
        public Guid PlanoId { get; set; }
        public int TempoCliente { get; set; }
    }
}
