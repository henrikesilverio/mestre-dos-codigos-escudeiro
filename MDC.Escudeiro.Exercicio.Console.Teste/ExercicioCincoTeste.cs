using MDC.Escudeiro.Domain.Interfaces;
using Moq;
using Xunit;

namespace MDC.Escudeiro.Exercicio.Console.Teste
{
    [Trait("Crie uma aplicação que calcule a fórmula de Bhaskara", "todos")]
    public class ExercicioCincoTeste
    {
        private readonly Mock<IScreenCommand> _screenCommand;

        public ExercicioCincoTeste()
        {
            _screenCommand = new Mock<IScreenCommand>();
        }

        [Theory(DisplayName = "Imprima os resultados R1 e R2")]
        [InlineData(1, 12, -13, 1, -13)]
        [InlineData(2, -16, -18, 9, -1)]
        public void ExercicioCinco_Calcular_Bhaskara(double valorA, double valorB, double valorC, double raizUm, double raizDois)
        {
            _screenCommand
                .Setup(x => x.InputValue("Insira o valor A: "))
                .Returns(valorA.ToString());

            _screenCommand
                .Setup(x => x.InputValue("Insira o valor B: "))
                .Returns(valorB.ToString());

            _screenCommand
                .Setup(x => x.InputValue("Insira o valor C: "))
                .Returns(valorC.ToString());

            var exercicio = new ExercicioCinco(_screenCommand.Object);

            Assert.Equal((raizUm, raizDois), exercicio.CalcularBhaskara());
        }
    }
}
