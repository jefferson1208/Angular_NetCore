using Moq;
using PlanosLigacao.Domain.Interfaces.Repository;
using PlanosLigacao.Domain.Interfaces.Services;
using PlanosLigacao.Domain.Services;
using PlanosLigacao.Tests.Fixture;
using System;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace Vortx.Tests.Services
{
    [Collection(nameof(CalculoPlanoCollection))]
    public class ServicesTests
    {
        private readonly CalculoPlanoTestsFixture _calculoPlanoTestsFixture;

        public ServicesTests(CalculoPlanoTestsFixture calculoPlanoTestsFixture)
        {
            _calculoPlanoTestsFixture = calculoPlanoTestsFixture;
        }

        [Fact(DisplayName = "Calcular custo de plano")]
        [Trait("Categoria", "Custo Plano Service Testes")]
        public async Task CustoPlanoService_CalcularCustoPlano_DeveEfetuarOCalculoCorretamente()
        {
            //Arange
            var calculo = _calculoPlanoTestsFixture.GerarCalculoPlanoValido();
            var custoPlanoRepository = new Mock<ICustoPlanoRepository>();
            var planoRepository = new Mock<IPlanoRepository>();
            var notificador = new Mock<INotificador>();

            var custoPlanoService = new CustoPlanoService(custoPlanoRepository.Object, planoRepository.Object, 
                notificador.Object);
            //Act

            var custoPlanoId = Guid.NewGuid();
            var planoId = Guid.NewGuid();

            var custoPlano = _calculoPlanoTestsFixture.GerarCustoPlano(custoPlanoId);

            

             custoPlanoRepository.Setup(p => p.BuscarPlanoPorId(custoPlanoId)).Returns(custoPlano);

            planoRepository.Setup(p => p.BuscarPlanoPorId(planoId)).Returns(_calculoPlanoTestsFixture.GerarPlano(planoId));
            
            var result = await custoPlanoService.CalcularCustoPlano(calculo);

            //Assert

            custoPlanoRepository.Verify(r => r.BuscarPlanoPorId(calculo.CustoPlanoId), Times.Once);
            planoRepository.Verify(r => r.BuscarPlanoPorId(calculo.PlanoId), Times.Once);
        }
        [Fact(DisplayName = "Buscar uma Lista de Planos")]
        [Trait("Categoria", "Plano Service Testes")]
        public async Task PlanoService_ObterTodos_DeveObterUmaListaDePlanos()
        {
            //Arange
            var planoRepository = new Mock<IPlanoRepository>();
            var notificador = new Mock<INotificador>();
            var planoService = new PlanoService(planoRepository.Object, notificador.Object);

            planoRepository.Setup(p => p.GetAll()).Returns(_calculoPlanoTestsFixture.GerarListaPlanos());

            //Act

            var result = await planoService.GetAll();

            //Assert
            planoRepository.Verify(r => r.GetAll(), Times.Once);
            Assert.True(result.Any());

        }

        [Fact(DisplayName = "Buscar uma Lista de custo de Planos")]
        [Trait("Categoria", "Plano Service Testes")]
        public async Task CustoPlanoService_ObterTodos_DeveObterUmaListaDeCustoDosPlanos()
        {
            //Arange
            var custoPlanoRepository = new Mock<ICustoPlanoRepository>();
            var notificador = new Mock<INotificador>();
            var planoRepository = new Mock<IPlanoRepository>();

            var custoPlanoService = new CustoPlanoService(custoPlanoRepository.Object, planoRepository.Object,
                notificador.Object);

            custoPlanoRepository.Setup(p => p.GetAll()).Returns(_calculoPlanoTestsFixture.GerarListaCustoPlanos());

            //Act

            var result = await custoPlanoService.GetAll();

            //Assert
            custoPlanoRepository.Verify(r => r.GetAll(), Times.Once);
            Assert.True(result.Any());

        }
    }
}
