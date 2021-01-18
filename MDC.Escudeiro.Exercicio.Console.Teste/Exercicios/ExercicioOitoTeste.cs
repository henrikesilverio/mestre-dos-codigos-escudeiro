using MDC.Escudeiro.Domain.Interfaces;
using Moq;
using Xunit;

namespace MDC.Escudeiro.Exercicio.Console.Teste.Exercicios
{
    [Trait("Faça uma aplicação ler N valores decimais, imprima os valores em ordem crescente e decrescente", "todos")]
    public class ExercicioOitoTeste
    {
        private readonly Mock<IScreenCommand> _screenCommand;

        public ExercicioOitoTeste()
        {
            _screenCommand = new Mock<IScreenCommand>();
        }

        [Fact(DisplayName = "Imprima os valores em ordem crescente")]
        public void ExercicioOito_Obter_Ordem_Crescente()
        {
            var exercicio = new ExercicioOito(_screenCommand.Object);

            for (int i = 3; i >= 1; i--)
            {
                _screenCommand
                    .Setup(x => x.InputValue("Insira o número: "))
                    .Returns(i.ToString());

                exercicio.InserirNumero();
            }

            Assert.Equal("1 | 2 | 3", exercicio.ObterOrdemCrescente());
        }

        [Fact(DisplayName = "Imprima os valores em ordem decrescente")]
        public void ExercicioOito_Obter_Ordem_Decrescente()
        {
            var exercicio = new ExercicioOito(_screenCommand.Object);

            for (int i = 1; i <= 3; i++)
            {
                _screenCommand
                    .Setup(x => x.InputValue("Insira o número: "))
                    .Returns(i.ToString());

                exercicio.InserirNumero();
            }

            Assert.Equal("3 | 2 | 1", exercicio.ObterOrdemDecrescente());
        }
    }
}