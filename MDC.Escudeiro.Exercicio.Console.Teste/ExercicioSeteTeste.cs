using MDC.Escudeiro.Domain.Interfaces;
using Moq;
using Xunit;

namespace MDC.Escudeiro.Exercicio.Console.Teste
{
    [Trait("Faça uma aplicação ler 4 números inteiros e calcular a soma dos que forem pares", "todos")]
    public class ExercicioSeteTeste
    {
        private readonly Mock<IScreenCommand> _screenCommand;

        public ExercicioSeteTeste()
        {
            _screenCommand = new Mock<IScreenCommand>();
        }

        [Theory(DisplayName = "Imprima a soma dos que forem pares")]
        [InlineData(1, 3, 5, 7, 0)]
        [InlineData(1, 2, 3, 4, 6)]
        [InlineData(1, 2, 4, 6, 12)]
        [InlineData(2, 4, 6, 8, 20)]
        public void ExercicioSete_Somar_Pares(int valorUm, int valorDois, int valorTres, int valorQuatro, int resultado)
        {
            _screenCommand
                .Setup(x => x.InputValue("Insira o 1° valor: "))
                .Returns(valorUm.ToString());

            _screenCommand
                .Setup(x => x.InputValue("Insira o 2° valor: "))
                .Returns(valorDois.ToString());

            _screenCommand
                .Setup(x => x.InputValue("Insira o 3° valor: "))
                .Returns(valorTres.ToString());

            _screenCommand
                .Setup(x => x.InputValue("Insira o 4° valor: "))
                .Returns(valorQuatro.ToString());

            var exercicio = new ExercicioSete(_screenCommand.Object);

            Assert.Equal(resultado, exercicio.SomarPares());
        }
    }
}