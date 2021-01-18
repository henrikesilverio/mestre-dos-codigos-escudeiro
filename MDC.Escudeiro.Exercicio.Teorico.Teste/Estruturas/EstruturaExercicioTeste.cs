using MDC.Escudeiro.Domain.Interfaces;
using Moq;
using Xunit;

namespace MDC.Escudeiro.Exercicio.Teorico.Teste.Estruturas
{
    [Trait("Validação das estruturas dos exercícios de teoria", "todos")]
    public class EstruturaExercicioTeste
    {
        private readonly Mock<IScreenCommand> _screenCommand;

        public EstruturaExercicioTeste()
        {
            _screenCommand = new Mock<IScreenCommand>();
        }

        [Fact(DisplayName = "Verificar se todas as ações do exercicio 1 foram feitas")]
        public void ExercicioUm_Validar_Estrutura_Arvore()
        {
            var arvore = new ExercicioUm(_screenCommand.Object).Build();

            Assert.NotNull(arvore);
            Assert.Contains("Perguntas teóricas sobre C#.", arvore.Title);
            Assert.Equal(4, arvore.Branches.Length);
            Assert.Contains("Em quais linguagens o C# foi inspirado", arvore.Branches[0].Title);
            Assert.Contains("Inicialmente o C# foi criado para qual finalidade", arvore.Branches[1].Title);
            Assert.Contains("Quais os principais motivos para a Microsoft ter migrado para o Core", arvore.Branches[2].Title);
            Assert.Contains("Cite as principais diferenças entre .Net Full Framework e .Net Core", arvore.Branches[3].Title);
            Assert.DoesNotContain(arvore.Branches, x => x.Action == null);
        }

        [Fact(DisplayName = "Verificar se todas as ações do exercicio 2 foram feitas")]
        public void ExercicioDois_Validar_Estrutura_Arvore()
        {
            var arvore = new ExercicioDois(_screenCommand.Object).Build();

            Assert.NotNull(arvore);
            Assert.Contains("Perguntas teóricas sobre POO.", arvore.Title);
            Assert.Equal(7, arvore.Branches.Length);
            Assert.Contains("O que é POO", arvore.Branches[0].Title);
            Assert.Contains("O que é polimorfismo", arvore.Branches[1].Title);
            Assert.Contains("O que é abstração", arvore.Branches[2].Title);
            Assert.Contains("O que é encapsulamento", arvore.Branches[3].Title);
            Assert.Contains("Quando usar uma classe abstrata e quando devo usar uma interface", arvore.Branches[4].Title);
            Assert.Contains("O que faz as interfaces IDisposable, IComparable, ICloneable e IEnumerable", arvore.Branches[5].Title);
            Assert.Contains("Existe herança múltipla (de classes) em C#", arvore.Branches[6].Title);
            Assert.DoesNotContain(arvore.Branches, x => x.Action == null);
        }
    }
}
