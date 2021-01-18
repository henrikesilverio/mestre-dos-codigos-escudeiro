using MDC.Escudeiro.Domain.Interfaces;
using Moq;
using Xunit;

namespace MDC.Escudeiro.Exercicio.Console.Teste.Estruturas
{
    [Trait("Validação das estruturas dos exercícios de console", "todos")]
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
            Assert.Contains("Crie uma aplicação que receba os valores A e B. Mostre de forma simples, como utilizar variáveis e manipular dados.", arvore.Title);
            Assert.Equal(5, arvore.Branches.Length);
            Assert.Contains("Some esses 2 valores", arvore.Branches[0].Title);
            Assert.Contains("Faça uma subtração do valor A - B", arvore.Branches[1].Title);
            Assert.Contains("Divida o valor B por A", arvore.Branches[2].Title);
            Assert.Contains("Multiplique o valor A por B", arvore.Branches[3].Title);
            Assert.Contains("Número par ou ímpar", arvore.Branches[4].Title);
            Assert.DoesNotContain(arvore.Branches, x => x.Action == null);
        }

        [Fact(DisplayName = "Verificar se todas as ações do exercicio 2 foram feitas")]
        public void ExercicioDois_Validar_Estrutura_Arvore()
        {
            var arvore = new ExercicioDois(_screenCommand.Object).Build();

            Assert.NotNull(arvore);
            Assert.Contains("Crie uma aplicação que receba nome e salário de N funcionários. Utilize a repetição for e while.", arvore.Title);
            Assert.Equal(3, arvore.Branches.Length);
            Assert.Contains("Inserir funcionários", arvore.Branches[0].Title);
            Assert.Contains("Imprimir o maior salário", arvore.Branches[1].Title);
            Assert.Contains("Imprimir o menor salário", arvore.Branches[2].Title);
            Assert.DoesNotContain(arvore.Branches, x => x.Action == null);
        }

        [Fact(DisplayName = "Verificar se todas as ações do exercicio 3 foram feitas")]
        public void ExercicioTres_Validar_Estrutura_Arvore()
        {
            var arvore = new ExercicioTres(_screenCommand.Object).Build();

            Assert.NotNull(arvore);
            Assert.Contains("Crie uma aplicação que imprima todos os múltiplos de 3, entre 1 e 100. Utilize a repetição while.", arvore.Title);
            Assert.Single(arvore.Branches);
            Assert.Contains("Imprimir todos os múltiplos de 3", arvore.Branches[0].Title);
            Assert.DoesNotContain(arvore.Branches, x => x.Action == null);
        }

        [Fact(DisplayName = "Verificar se todas as ações do exercicio 4 foram feitas")]
        public void ExercicioQuatro_Validar_Estrutura_Arvore()
        {
            var arvore = new ExercicioQuatro(_screenCommand.Object).Build();

            Assert.NotNull(arvore);
            Assert.Contains("Crie uma aplicação que receba N alunos com suas respectivas notas. Use foreach para a estrutura de repetição.", arvore.Title);
            Assert.Equal(2, arvore.Branches.Length);
            Assert.Contains("Inserir aluno", arvore.Branches[0].Title);
            Assert.Contains("Imprimir todos os alunos com média superior a 7", arvore.Branches[1].Title);
            Assert.DoesNotContain(arvore.Branches, x => x.Action == null);
        }

        [Fact(DisplayName = "Verificar se todas as ações do exercicio 5 foram feitas")]
        public void ExercicioCinco_Validar_Estrutura_Arvore()
        {
            var arvore = new ExercicioCinco(_screenCommand.Object).Build();

            Assert.NotNull(arvore);
            Assert.Contains("Crie uma aplicação que calcule a fórmula de Bhaskara.", arvore.Title);
            Assert.Single(arvore.Branches);
            Assert.Contains("Receba os valores a, b, c", arvore.Branches[0].Title);
            Assert.DoesNotContain(arvore.Branches, x => x.Action == null);
        }

        [Fact(DisplayName = "Verificar se todas as ações do exercicio 6 foram feitas")]
        public void ExercicioSeis_Validar_Estrutura_Arvore()
        {
            var arvore = new ExercicioSeis(_screenCommand.Object).Build();

            Assert.NotNull(arvore);
            Assert.Contains("Crie uma aplicação que demonstre a diferença entre REF e OUT.", arvore.Title);
            Assert.Equal(2, arvore.Branches.Length);
            Assert.Contains("Definição do ref", arvore.Branches[0].Title);
            Assert.Contains("Definição do out", arvore.Branches[1].Title);
            Assert.DoesNotContain(arvore.Branches, x => x.Action == null);
        }

        [Fact(DisplayName = "Verificar se todas as ações do exercicio 7 foram feitas")]
        public void ExercicioSete_Validar_Estrutura_Arvore()
        {
            var arvore = new ExercicioSete(_screenCommand.Object).Build();

            Assert.NotNull(arvore);
            Assert.Contains("Crie uma aplicação que leia 4 números inteiros e calcular a soma dos que forem pares.", arvore.Title);
            Assert.Single(arvore.Branches);
            Assert.Contains("Somar os pares", arvore.Branches[0].Title);
            Assert.DoesNotContain(arvore.Branches, x => x.Action == null);
        }

        [Fact(DisplayName = "Verificar se todas as ações do exercicio 8 foram feitas")]
        public void ExercicioOito_Validar_Estrutura_Arvore()
        {
            var arvore = new ExercicioOito(_screenCommand.Object).Build();

            Assert.NotNull(arvore);
            Assert.Contains("Crie uma aplicação que leia N valores decimais, imprima os valores em ordem crescente e decrescente.", arvore.Title);
            Assert.Equal(3, arvore.Branches.Length);
            Assert.Contains("Inserir número", arvore.Branches[0].Title);
            Assert.Contains("Imprimir em ordem crescente", arvore.Branches[1].Title);
            Assert.Contains("Imprimir em ordem decrescente", arvore.Branches[2].Title);
            Assert.DoesNotContain(arvore.Branches, x => x.Action == null);
        }

        [Fact(DisplayName = "Verificar se todas as ações do exercicio 9 foram feitas")]
        public void ExercicioNove_Validar_Estrutura_Arvore()
        {
            var arvore = new ExercicioNove(_screenCommand.Object).Build();

            Assert.NotNull(arvore);
            Assert.Contains("Utilizando a biblioteca LINQ crie no console e execute.", arvore.Title);
            Assert.Equal(11, arvore.Branches.Length);
            Assert.Contains("Imprimir todos os números da lista", arvore.Branches[0].Title);
            Assert.Contains("Imprimir todos os números da lista na ordem crescente", arvore.Branches[1].Title);
            Assert.Contains("Imprimir todos os números da lista na ordem decrescente", arvore.Branches[2].Title);
            Assert.Contains("Imprimir apenas o primeiro número da lista", arvore.Branches[3].Title);
            Assert.Contains("Imprimir apenas o ultimo número da lista", arvore.Branches[4].Title);
            Assert.Contains("Inserir um número no início da lista", arvore.Branches[5].Title);
            Assert.Contains("Inserir um número no final da lista", arvore.Branches[6].Title);
            Assert.Contains("Remover o primeiro número", arvore.Branches[7].Title);
            Assert.Contains("Remover o último número", arvore.Branches[8].Title);
            Assert.Contains("Retornar apenas os números pares", arvore.Branches[9].Title);
            Assert.Contains("Retornar apenas o número informado", arvore.Branches[10].Title);
            Assert.DoesNotContain(arvore.Branches, x => x.Action == null);
        }
    }
}
