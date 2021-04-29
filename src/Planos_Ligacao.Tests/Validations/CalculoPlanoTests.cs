using PlanosLigacao.Tests.Fixture;
using Xunit;

namespace Vortx.Tests.Validations
{
    [Collection(nameof(CalculoPlanoCollection))]

    public class CalculoPlanoTests
    {
        private readonly CalculoPlanoTestsFixture _calculoPlanoTestsFixture;

        public CalculoPlanoTests(CalculoPlanoTestsFixture calculoPlanoTestsFixture)
        {
            _calculoPlanoTestsFixture = calculoPlanoTestsFixture;
        }

        [Fact(DisplayName = "Entrada para calculo válida")]
        [Trait("Categoria", "CalculoPlano Trait Testes")]
        public void CalculoPlano_Calculo_DeveEstarValido()
        {
            //Arrange
            var calculo = _calculoPlanoTestsFixture.GerarCalculoPlanoValido();

            //Act

            var result = calculo.Validar().Valido;
            
            //Assert
            Assert.True(result);
           
        }

        [Fact(DisplayName = "Entrada para calculo inválida")]
        [Trait("Categoria", "CalculoPlano Trait Testes")]
        public void CalculoPlano_Calculo_DeveEstarIValido()
        {
            //Arrange
            var calculo = _calculoPlanoTestsFixture.GerarCalculoPlanoInvalido();

            //Act

            var result = calculo.Validar().Valido;

            //Assert
    
            Assert.False(result);
        }
    }
}
