using System;

namespace PlanosLigacao.Application.ViewModels.Planos
{
    public class CustoPlanoViewModel
    {
        public Guid Id { get; set; }
        public string Origem { get; set; }
        public string Destino { get; set; }

        public decimal CustoMinuto { get; set; }
    }
}
