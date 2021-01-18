using MDC.Escudeiro.Domain.Interfaces;
using MDC.Escudeiro.Exercicio.Builders;
using Moq;
using Xunit;

namespace MDC.Escudeiro.Exercicio.Teste.Estruturas
{
    [Trait("Validação das estruturas dos exercícios", "todos")]
    public class EstruturaExercicioTeste
    {
        private readonly Mock<IScreenCommand> _screenCommand;

        public EstruturaExercicioTeste()
        {
            _screenCommand = new Mock<IScreenCommand>();
        }

        [Fact(DisplayName = "Verificar se todos os exercicios foram feitos")]
        public void Exercicios_Validar_Estrutura_Arvore()
        {
            var arvore = new ExerciseTreeBuilder(_screenCommand.Object).Build();

            Assert.NotNull(arvore);
            Assert.Contains("Bem-vindo ao território de .Net do Mestre dos Códigos.", arvore.Title);
            Assert.Equal(3, arvore.Branches.Length);
            Assert.DoesNotContain(arvore.Branches, x => x.Title == null);
        }

        [Fact(DisplayName = "Verificar se todos os exercicios de Console foram feitos")]
        public void ExercicioConsole_Validar_Estrutura_Arvore()
        {
            var arvore = new ExerciseConsoleBuilder(_screenCommand.Object).Build();

            Assert.NotNull(arvore);
            Assert.Contains("Validar os exercícios de console.", arvore.Title);
            Assert.Equal(9, arvore.Branches.Length);
            Assert.DoesNotContain(arvore.Branches, x => x.Title == null);
        }

        [Fact(DisplayName = "Verificar se todos os exercicios de POO foram feitos")]
        public void ExercicioPOO_Validar_Estrutura_Arvore()
        {
            var arvore = new ExercisePOOBuilder(_screenCommand.Object).Build();

            Assert.NotNull(arvore);
            Assert.Contains("Validar os exercícios de POO.", arvore.Title);
            Assert.Equal(3, arvore.Branches.Length);
            Assert.DoesNotContain(arvore.Branches, x => x.Title == null);
        }

        [Fact(DisplayName = "Verificar se todos os exercicios de Teoria foram feitos")]
        public void ExercicioTeoria_Validar_Estrutura_Arvore()
        {
            var arvore = new ExerciseTheoreticalBuilder(_screenCommand.Object).Build();

            Assert.NotNull(arvore);
            Assert.Contains("Respostas sobre a parte teóricas.", arvore.Title);
            Assert.Equal(2, arvore.Branches.Length);
            Assert.DoesNotContain(arvore.Branches, x => x.Title == null);
        }
    }
}
