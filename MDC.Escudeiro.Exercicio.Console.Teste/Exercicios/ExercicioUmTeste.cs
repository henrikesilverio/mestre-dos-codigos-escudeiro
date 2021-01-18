using MDC.Escudeiro.Domain.Interfaces;
using Moq;
using Xunit;

namespace MDC.Escudeiro.Exercicio.Console.Teste.Exercicios
{
    [Trait("Crie uma aplica��o, que receba os valores A e B. Mostre de forma simples, como utilizar vari�veis e manipular dados", "todos")]
    public class ExercicioUmTeste
    {
        private readonly Mock<IScreenCommand> _screenCommand;

        public ExercicioUmTeste()
        {
            _screenCommand = new Mock<IScreenCommand>();
        }

        [Theory(DisplayName = "Some esses 2 valores")]
        [InlineData(1, 1, 2)]
        [InlineData(1, 2, 3)]
        [InlineData(2, 1, 3)]
        public void ExercicioUm_Soma_Dois_Valores(decimal primeiro, decimal segundo, decimal resultado)
        {
            _screenCommand
                .Setup(x => x.InputValue("Insira o valor A: "))
                .Returns(primeiro.ToString());

            _screenCommand
                .Setup(x => x.InputValue("Insira o valor B: "))
                .Returns(segundo.ToString());

            var exercicio = new ExercicioUm(_screenCommand.Object);

            Assert.Equal(resultado, exercicio.Somar());
        }

        [Theory(DisplayName = "Fa�a uma subtra��o do valor A - B")]
        [InlineData(1, 1, 0)]
        [InlineData(1, 2, -1)]
        [InlineData(2, 1, 1)]
        public void ExercicioUm_Subtrair_Dois_Valores(decimal primeiro, decimal segundo, decimal resultado)
        {
            _screenCommand
                .Setup(x => x.InputValue("Insira o valor A: "))
                .Returns(primeiro.ToString());

            _screenCommand
                .Setup(x => x.InputValue("Insira o valor B: "))
                .Returns(segundo.ToString());

            var exercicio = new ExercicioUm(_screenCommand.Object);

            Assert.Equal(resultado, exercicio.Subtrair());
        }

        [Theory(DisplayName = "Divida o valor B por A")]
        [InlineData(1, 1, 1)]
        [InlineData(2, 1, 0.5)]
        [InlineData(1, 2, 2)]
        public void ExercicioUm_Dividir_Dois_Valores(decimal primeiro, decimal segundo, decimal resultado)
        {
            _screenCommand
                .Setup(x => x.InputValue("Insira o valor A: "))
                .Returns(primeiro.ToString());

            _screenCommand
                .Setup(x => x.InputValue("Insira o valor B: "))
                .Returns(segundo.ToString());

            var exercicio = new ExercicioUm(_screenCommand.Object);

            Assert.Equal(resultado, exercicio.Dividir());
        }

        [Theory(DisplayName = "Multiplique o valor A por B")]
        [InlineData(1, 1, 1)]
        [InlineData(1, 2, 2)]
        [InlineData(2, 1, 2)]
        [InlineData(2, 2, 4)]
        public void ExercicioUm_Multiplicar_Dois_Valores(decimal primeiro, decimal segundo, decimal resultado)
        {
            _screenCommand
                .Setup(x => x.InputValue("Insira o valor A: "))
                .Returns(primeiro.ToString());

            _screenCommand
                .Setup(x => x.InputValue("Insira o valor B: "))
                .Returns(segundo.ToString());

            var exercicio = new ExercicioUm(_screenCommand.Object);

            Assert.Equal(resultado, exercicio.Multiplicar());
        }

        [Theory(DisplayName = "Imprima os valores de entrada, informado se o n�mero � par ou �mpar")]
        [InlineData(2, 1, "Valor A: 2 � par, Valor B: 1 � �mpar")]
        [InlineData(1, 2, "Valor A: 1 � �mpar, Valor B: 2 � par")]
        [InlineData(3, 4, "Valor A: 3 � �mpar, Valor B: 4 � par")]
        [InlineData(4, 3, "Valor A: 4 � par, Valor B: 3 � �mpar")]
        public void ExercicioUm_Classificar_Dois_Valores(decimal primeiro, decimal segundo, string resultado)
        {
            _screenCommand
                .Setup(x => x.InputValue("Insira o valor A: "))
                .Returns(primeiro.ToString());

            _screenCommand
                .Setup(x => x.InputValue("Insira o valor B: "))
                .Returns(segundo.ToString());

            var exercicio = new ExercicioUm(_screenCommand.Object);

            Assert.Equal(resultado, exercicio.Classificar());
        }
    }
}