using System;

namespace PlanosLigacao.Domain.Entities.Planos
{
    public class CustoPlano : Entity
    {
        public string Origem { get; set; }
        public string Destino { get; set; }

        public decimal CustoMinuto { get; set; }

        public decimal CalcularCustoPlano(int tempoExcedente)
        {
            var custo = Convert.ToDecimal(0);

            if(tempoExcedente > 0)
            {
                custo = (this.CustoMinuto * tempoExcedente) * CalcularAcrescimoPlano();
            }

            return custo;
        }

        public decimal CaclularCustoSemPlano(int tempoCliente)
        {
            return this.CustoMinuto * tempoCliente;
        }
        private decimal CalcularAcrescimoPlano()
        {
            return Convert.ToDecimal(1 + 0.1);
        }
    }


}
