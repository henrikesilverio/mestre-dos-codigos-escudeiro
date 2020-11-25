using MDC.Escudeiro.Domain.Interfaces;
using Moq;
using Xunit;

namespace MDC.Escudeiro.Exercicio.Console.Teste
{
    [Trait("Utilizando a biblioteca LINQ crie no console e execute", "todos")]
    public class ExercicioNoveTeste
    {
        private readonly Mock<IScreenCommand> _screenCommand;

        public ExercicioNoveTeste()
        {
            _screenCommand = new Mock<IScreenCommand>();
        }

        [Fact(DisplayName = "Imprimir todos os números da lista na ordem crescente")]
        public void ExercicioNove_Obter_Ordem_Crescente()
        {
            var exercicio = new ExercicioNove(_screenCommand.Object);
            exercicio.RemoverTodos();

            for (int i = 3; i >= 1; i--)
            {
                _screenCommand
                    .Setup(x => x.InputValue("Insira o número: "))
                    .Returns(i.ToString());

                exercicio = new ExercicioNove(_screenCommand.Object);
                exercicio.InserirNoFim();
            }

            Assert.Equal("1,2,3", string.Join(",", exercicio.ObterOrdemCrescente()));
        }

        [Fact(DisplayName = "Imprimir todos os números da lista na ordem decrescente")]
        public void ExercicioNove_Obter_Ordem_Decrescente()
        {
            var exercicio = new ExercicioNove(_screenCommand.Object);
            exercicio.RemoverTodos();

            for (int i = 1; i <= 3; i++)
            {
                _screenCommand
                    .Setup(x => x.InputValue("Insira o número: "))
                    .Returns(i.ToString());

                exercicio = new ExercicioNove(_screenCommand.Object);
                exercicio.InserirNoFim();
            }

            Assert.Equal("3,2,1", string.Join(",", exercicio.ObterOrdemDecrescente()));
        }

        [Fact(DisplayName = "Imprima apenas o primeiro número da lista")]
        public void ExercicioNove_Obter_Primeiro_Numero()
        {
            var exercicio = new ExercicioNove(_screenCommand.Object);
            exercicio.RemoverTodos();

            for (int i = 1; i <= 3; i++)
            {
                _screenCommand
                    .Setup(x => x.InputValue("Insira o número: "))
                    .Returns(i.ToString());

                exercicio = new ExercicioNove(_screenCommand.Object);
                exercicio.InserirNoFim();
            }

            Assert.Equal(1, exercicio.ObterPrimeiroNumero());
        }

        [Fact(DisplayName = "Imprima apenas o ultimo número da lista")]
        public void ExercicioNove_Obter_Ultimo_Numero()
        {
            var exercicio = new ExercicioNove(_screenCommand.Object);
            exercicio.RemoverTodos();

            for (int i = 1; i <= 3; i++)
            {
                _screenCommand
                    .Setup(x => x.InputValue("Insira o número: "))
                    .Returns(i.ToString());

                exercicio = new ExercicioNove(_screenCommand.Object);
                exercicio.InserirNoFim();
            }

            Assert.Equal(3, exercicio.ObterUltimoNumero());
        }

        [Fact(DisplayName = "Insira um número no início da lista")]
        public void ExercicioNove_Inserir_No_Comeco()
        {
            var exercicio = new ExercicioNove(_screenCommand.Object);
            exercicio.RemoverTodos();

            for (int i = 1; i <= 3; i++)
            {
                _screenCommand
                    .Setup(x => x.InputValue("Insira o número: "))
                    .Returns(i.ToString());

                exercicio = new ExercicioNove(_screenCommand.Object);
                exercicio.InserirNoComeco();
            }

            Assert.Equal(3, exercicio.ObterPrimeiroNumero());
        }

        [Fact(DisplayName = "Insira um número no final da lista")]
        public void ExercicioNove_Inserir_No_Fim()
        {
            var exercicio = new ExercicioNove(_screenCommand.Object);
            exercicio.RemoverTodos();

            for (int i = 1; i <= 3; i++)
            {
                _screenCommand
                    .Setup(x => x.InputValue("Insira o número: "))
                    .Returns(i.ToString());

                exercicio = new ExercicioNove(_screenCommand.Object);
                exercicio.InserirNoFim();
            }

            Assert.Equal(3, exercicio.ObterUltimoNumero());
        }

        [Fact(DisplayName = "Remova o primeiro número")]
        public void ExercicioNove_Remover_Primeiro()
        {
            var exercicio = new ExercicioNove(_screenCommand.Object);
            exercicio.RemoverTodos();

            for (int i = 1; i <= 3; i++)
            {
                _screenCommand
                    .Setup(x => x.InputValue("Insira o número: "))
                    .Returns(i.ToString());

                exercicio = new ExercicioNove(_screenCommand.Object);
                exercicio.InserirNoFim();
            }

            exercicio.RemoverPrimeiro();

            Assert.Equal("2,3", string.Join(",", exercicio.ObterTodos()));
        }

        [Fact(DisplayName = "Remova o último número")]
        public void ExercicioNove_Remover_Ultimo()
        {
            var exercicio = new ExercicioNove(_screenCommand.Object);
            exercicio.RemoverTodos();

            for (int i = 1; i <= 3; i++)
            {
                _screenCommand
                    .Setup(x => x.InputValue("Insira o número: "))
                    .Returns(i.ToString());

                exercicio = new ExercicioNove(_screenCommand.Object);
                exercicio.InserirNoFim();
            }

            exercicio.RemoverUltimo();

            Assert.Equal("1,2", string.Join(",", exercicio.ObterTodos()));
        }

        [Fact(DisplayName = "Retorne apenas os números pares")]
        public void ExercicioNove_Obter_Numeros_Pares()
        {
            var exercicio = new ExercicioNove(_screenCommand.Object);
            exercicio.RemoverTodos();

            for (int i = 1; i <= 4; i++)
            {
                _screenCommand
                    .Setup(x => x.InputValue("Insira o número: "))
                    .Returns(i.ToString());

                exercicio = new ExercicioNove(_screenCommand.Object);
                exercicio.InserirNoFim();
            }

            Assert.Equal("2,4", string.Join(",", exercicio.ObterNumerosPares()));
        }

        [Fact(DisplayName = "Retorne apenas o número informado")]
        public void ExercicioNove_Consultar_Numero()
        {
            var exercicio = new ExercicioNove(_screenCommand.Object);
            exercicio.RemoverTodos();

            for (int i = 1; i <= 4; i++)
            {
                _screenCommand
                    .Setup(x => x.InputValue("Insira o número: "))
                    .Returns(i.ToString());

                exercicio = new ExercicioNove(_screenCommand.Object);
                exercicio.InserirNoFim();
            }

            _screenCommand
                .Setup(x => x.InputValue("Insira o número: "))
                .Returns("3");

            exercicio = new ExercicioNove(_screenCommand.Object);

            Assert.Equal(3, exercicio.ConsultarNumero());
        }
    }
}