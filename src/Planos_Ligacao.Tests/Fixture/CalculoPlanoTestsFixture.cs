using Bogus;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using PlanosLigacao.Domain.Entities.Planos;
using Xunit;

namespace PlanosLigacao.Tests.Fixture
{
    [CollectionDefinition(nameof(CalculoPlanoCollection))]
    public class CalculoPlanoCollection: ICollectionFixture<CalculoPlanoTestsFixture>
    {

    }
    public class CalculoPlanoTestsFixture : IDisposable
    {
        public CalculoPlano GerarCalculoPlanoValido()
        {
            return new CalculoPlano
            {
                CustoPlanoId = Guid.NewGuid(),
                PlanoId = Guid.NewGuid(),
                TempoCliente = 100,
                
            };
        }

        public CalculoPlano GerarCalculoPlanoInvalido()
        {
            return new CalculoPlano
            {
                CustoPlanoId = Guid.Empty,
                PlanoId = Guid.NewGuid(),
                TempoCliente = 0
            };
        }

        public Task<List<Plano>> GerarListaPlanos()
        {
            var planos = new Faker<Plano>(locale: "pt_BR").StrictMode(true)
                .RuleFor(r => r.Id, f => Guid.NewGuid())
                .RuleFor(r => r.NomePlano, f => f.Random.String())
                .RuleFor(r => r.TempoPlano, f => f.Random.Int());

            return Task.FromResult(planos.Generate(20));
                
        }

        public Task<List<CustoPlano>> GerarListaCustoPlanos()
        {
            var custoPlanos = new Faker<CustoPlano>(locale: "pt_BR").StrictMode(true)
                .RuleFor(r => r.Id, f => Guid.NewGuid())
                .RuleFor(r => r.Origem, f => f.Random.Int().ToString())
                .RuleFor(r => r.Destino, f => f.Random.Int().ToString())
                .RuleFor(r => r.CustoMinuto, f => f.Random.Decimal());

            return Task.FromResult(custoPlanos.Generate(20));

        }

        public Task<CustoPlano> GerarCustoPlano(Guid custoPlanoId)
        {
            var custoPlanos = new Faker<CustoPlano>(locale: "pt_BR").StrictMode(true)
                .RuleFor(r => r.Id, f => custoPlanoId)
                .RuleFor(r => r.Origem, f => f.Random.Int().ToString())
                .RuleFor(r => r.Destino, f => f.Random.Int().ToString())
                .RuleFor(r => r.CustoMinuto, f => f.Random.Decimal());

            return Task.FromResult(custoPlanos.Generate());
        }

        public Task<Plano> GerarPlano(Guid planoId)
        {
            var custoPlanos = new Faker<Plano>(locale: "pt_BR").StrictMode(true)
                .RuleFor(r => r.Id, f => planoId)
                .RuleFor(r => r.NomePlano, f => f.Random.String())
                .RuleFor(r => r.TempoPlano, f => f.Random.Int());

            return Task.FromResult(custoPlanos.Generate());
        }
        public void Dispose()
        {
           
        }
    }
}

