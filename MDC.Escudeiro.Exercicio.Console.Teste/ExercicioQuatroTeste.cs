using MDC.Escudeiro.Domain.Interfaces;
using Moq;
using Xunit;

namespace MDC.Escudeiro.Exercicio.Console.Teste
{
    [Trait("Faça uma aplicação que receba N alunos com suas respectivas notas. Use foreach para a estrutura de repetição", "todos")]
    public class ExercicioQuatroTeste
    {
        private readonly Mock<IScreenCommand> _screenCommand;

        public ExercicioQuatroTeste()
        {
            _screenCommand = new Mock<IScreenCommand>();
        }

        [Fact(DisplayName = "Armazene os alunos em uma lista")]
        public void ExercicioQuatro_Inserir_Aluno()
        {
            _screenCommand
                .Setup(x => x.InputValue("Insira o nome: "))
                .Returns("Henrique");

            _screenCommand
                .Setup(x => x.InputValue("Insira a nota: "))
                .Returns("6");

            var exercicio = new ExercicioQuatro(_screenCommand.Object);
            exercicio.RemoverTodos();
            var aluno = exercicio.InserirAluno();

            Assert.Equal("Henrique", aluno.Nome);
            Assert.Equal(6, aluno.Nota);
        }

        [Fact(DisplayName = "Imprima todos os alunos com médias superiores a 7")]
        public void ExercicioQuatro_Alunos_Com_Nota_Maior_Que_Sete()
        {
            var exercicio = new ExercicioQuatro(_screenCommand.Object);
            exercicio.RemoverTodos();

            foreach (var nota in new[] { "6", "7.1", "7", "8" })
            {
                _screenCommand
                    .Setup(x => x.InputValue("Insira o nome: "))
                    .Returns("Carlos");

                _screenCommand
                    .Setup(x => x.InputValue("Insira a nota: "))
                    .Returns(nota);

                exercicio = new ExercicioQuatro(_screenCommand.Object);
                exercicio.InserirAluno();
            }

            var alunos = exercicio.AlunosComNotaMaiorQueSete();

            Assert.Contains(alunos, a => a.Nota == 7.1M);
            Assert.Contains(alunos, a => a.Nota == 8M);
        }
    }
}