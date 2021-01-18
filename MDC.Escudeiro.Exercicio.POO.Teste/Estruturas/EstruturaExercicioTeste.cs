using MDC.Escudeiro.Domain.Interfaces;
using Moq;
using Xunit;

namespace MDC.Escudeiro.Exercicio.POO.Teste.Estruturas
{
    [Trait("Validação das estruturas dos exercícios de POO", "todos")]
    public class EstruturaExercicioTeste
    {
        private readonly Mock<IScreenCommand> _screenCommand;

        public EstruturaExercicioTeste()
        {
            _screenCommand = new Mock<IScreenCommand>();
        }

        [Fact(DisplayName = "Verificar se todas as ações do exercicio 2 foram feitas")]
        public void ExercicioDois_Validar_Estrutura_Arvore()
        {
            var arvore = new ExercicioDois(_screenCommand.Object).Build();

            Assert.NotNull(arvore);
            Assert.Contains("Crie uma classe para representar uma pessoa.", arvore.Title);
            Assert.Equal(3, arvore.Branches.Length);
            Assert.Contains("Incluir a pessoa", arvore.Branches[0].Title);
            Assert.Contains("Calcular a idade", arvore.Branches[1].Title);
            Assert.Contains("Imprimir dados", arvore.Branches[2].Title);
            Assert.DoesNotContain(arvore.Branches, x => x.Action == null);
        }

        [Fact(DisplayName = "Verificar se todas as ações do exercicio 3 foram feitas")]
        public void ExercicioTres_Validar_Estrutura_Arvore()
        {
            var arvore = new ExercicioTres(_screenCommand.Object).Build();

            Assert.NotNull(arvore);
            Assert.Contains("Faça uma aplicação bancária.", arvore.Title);
            Assert.Equal(3, arvore.Branches.Length);
            Assert.Contains("Criar uma conta", arvore.Branches[0].Title);
            Assert.Contains("Depositar", arvore.Branches[1].Title);
            Assert.Contains("Sacar", arvore.Branches[2].Title);
            Assert.DoesNotContain(arvore.Branches, x => x.Action == null);
        }

        [Fact(DisplayName = "Verificar se todas as ações do exercicio 4 foram feitas")]
        public void ExercicioQuatro_Validar_Estrutura_Arvore()
        {
            var arvore = new ExercicioQuatro(_screenCommand.Object).Build();

            Assert.NotNull(arvore);
            Assert.Contains("Crie uma classe Televisao e uma classe ControleRemoto que pode controlar o volume e trocar os canais da televisão.", arvore.Title);
            Assert.Equal(6, arvore.Branches.Length);
            Assert.Contains("Criar controle", arvore.Branches[0].Title);
            Assert.Contains("Aumentar volume", arvore.Branches[1].Title);
            Assert.Contains("Diminuir volume", arvore.Branches[2].Title);
            Assert.Contains("Aumentar número canal", arvore.Branches[3].Title);
            Assert.Contains("Diminuir número canal", arvore.Branches[4].Title);
            Assert.Contains("Ir para o canal", arvore.Branches[5].Title);
            Assert.DoesNotContain(arvore.Branches, x => x.Action == null);
        }
    }
}
