using System.ComponentModel.DataAnnotations.Schema;

namespace PlanosLigacao.Domain.Entities.Planos
{
    public class Plano : Entity
    {
        public string NomePlano { get; set; }
        public int TempoPlano { get; set; }

        public int CalcularExcedente(int tempoCliente)
        {
            return tempoCliente - TempoPlano;
        }
    }
}
