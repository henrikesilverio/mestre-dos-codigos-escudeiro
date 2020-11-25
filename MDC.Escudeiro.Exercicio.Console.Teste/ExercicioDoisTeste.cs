using MDC.Escudeiro.Domain.Interfaces;
using Moq;
using Xunit;

namespace MDC.Escudeiro.Exercicio.Console.Teste
{
    [Trait("Crie uma aplicação que receba nome e salário de N funcionários. Utilize a repetição for e while", "todos")]
    public class ExercicioDoisTeste
    {
        private readonly Mock<IScreenCommand> _screenCommand;

        public ExercicioDoisTeste()
        {
            _screenCommand = new Mock<IScreenCommand>();
        }

        [Fact(DisplayName = "Inserir funcionario")]
        public void ExercicioDois_Inserir_Funcionario()
        {
            _screenCommand
                .Setup(x => x.InputValue("Insira o nome: "))
                .Returns("Henrique");

            _screenCommand
                .Setup(x => x.InputValue("Insira o salário: "))
                .Returns("1000,50");

            var exercicio = new ExercicioDois(_screenCommand.Object);
            exercicio.RemoverTodos();
            var funcionario = exercicio.InserirFuncionario();

            Assert.Equal("Henrique", funcionario.Nome);
            Assert.Equal(1000.50M, funcionario.Salario);
        }

        [Fact(DisplayName = "Imprima o maior salário")]
        public void ExercicioDois_Maior_Salario()
        {
            var exercicio = new ExercicioDois(_screenCommand.Object);
            exercicio.RemoverTodos();

            foreach (var salario in new[] { "4000,50", "2000,50", "3000,50" })
            {
                _screenCommand
                    .Setup(x => x.InputValue("Insira o nome: "))
                    .Returns("Henrique");

                _screenCommand
                    .Setup(x => x.InputValue("Insira o salário: "))
                    .Returns(salario);

                exercicio = new ExercicioDois(_screenCommand.Object);
                exercicio.InserirFuncionario();
            }

            var maior = exercicio.MaiorSalario();

            Assert.Equal(4000.50M, maior);
        }

        [Fact(DisplayName = "Imprima o maior salário sem funcionario")]
        public void ExercicioDois_Maior_Salario_Sem_Funcionario()
        {
            var exercicio = new ExercicioDois(_screenCommand.Object);
            exercicio.RemoverTodos();

            var maior = exercicio.MaiorSalario();

            Assert.Equal(0M, maior);
        }

        [Fact(DisplayName = "Imprima o menor salário")]
        public void ExercicioDois_Menor_Salario()
        {
            var exercicio = new ExercicioDois(_screenCommand.Object);
            exercicio.RemoverTodos();

            foreach (var salario in new[] { "4000,50", "2000,50", "3000,50" })
            {
                _screenCommand
                    .Setup(x => x.InputValue("Insira o nome: "))
                    .Returns("Henrique");

                _screenCommand
                    .Setup(x => x.InputValue("Insira o salário: "))
                    .Returns(salario);

                exercicio = new ExercicioDois(_screenCommand.Object);
                exercicio.InserirFuncionario();
            }

            var maior = exercicio.MenorSalario();

            Assert.Equal(2000.50M, maior);
        }

        [Fact(DisplayName = "Imprima o menor salário sem funcionario")]
        public void ExercicioDois_Menor_Salario_Sem_Funcionario()
        {
            var exercicio = new ExercicioDois(_screenCommand.Object);
            exercicio.RemoverTodos();

            var maior = exercicio.MenorSalario();

            Assert.Equal(0M, maior);
        }
    }
}