using MDC.Escudeiro.Domain.Interfaces;
using Moq;
using System;
using Xunit;

namespace MDC.Escudeiro.Exercicio.POO.Teste.Exercicios
{
    [Trait("Crie uma classe para representar uma pessoa", "todos")]
    public class ExercicioDoisTeste
    {
        private readonly Mock<IScreenCommand> _screenCommand;

        public ExercicioDoisTeste()
        {
            _screenCommand = new Mock<IScreenCommand>();
        }

        [Fact(DisplayName = "Inserir pessoa")]
        public void ExercicioDois_Inserir_Pessoa()
        {
            _screenCommand
                .Setup(x => x.InputValue("Insira o nome: "))
                .Returns("Henrique");

            _screenCommand
                .Setup(x => x.InputValue("Insira a data de nascimento (dd/MM/yyyy): "))
                .Returns("25/07/1989");

            _screenCommand
                .Setup(x => x.InputValue("Insira a altura: "))
                .Returns("1,87");

            var exercicio = new ExercicioDois(_screenCommand.Object);
            var pessoa = exercicio.InserirPessoa();

            Assert.Equal("Henrique", pessoa.ObterNome());
            Assert.Equal(new DateTime(1989, 7, 25), pessoa.ObterDataNascimento());
            Assert.Equal(1.87M, pessoa.ObterAltura());
        }

        [Theory(DisplayName = "Calcular a idade")]
        [InlineData(0, 0)]
        [InlineData(1, 0)]
        [InlineData(-1, 1)]
        public void ExercicioDois_Calcular_Idade(int ano, int idade)
        {
            _screenCommand
                .Setup(x => x.InputValue("Insira o nome: "))
                .Returns("Henrique");

            _screenCommand
                .Setup(x => x.InputValue("Insira a data de nascimento (dd/MM/yyyy): "))
                .Returns(DateTime.Now.AddYears(ano).ToString("dd/MM/yyyy"));

            _screenCommand
                .Setup(x => x.InputValue("Insira a altura: "))
                .Returns("1,87");

            var exercicio = new ExercicioDois(_screenCommand.Object);
            var pessoa = exercicio.InserirPessoa();

            Assert.Equal(idade, pessoa.CalcularIdade());
        }

        [Theory(DisplayName = "Calcular a idade especifica")]
        [InlineData(0, 0, -1, 1)]
        [InlineData(1, 0, -1, 0)]
        [InlineData(-1, 0, -1, 1)]
        public void ExercicioDois_Calcular_Idade_Especifica(int dia, int mes, int ano, int idade)
        {
            _screenCommand
                .Setup(x => x.InputValue("Insira o nome: "))
                .Returns("Henrique");

            _screenCommand
                .Setup(x => x.InputValue("Insira a data de nascimento (dd/MM/yyyy): "))
                .Returns(DateTime.Now.AddDays(dia).AddMonths(mes).AddYears(ano).ToString("dd/MM/yyyy"));

            _screenCommand
                .Setup(x => x.InputValue("Insira a altura: "))
                .Returns("1,87");

            var exercicio = new ExercicioDois(_screenCommand.Object);
            var pessoa = exercicio.InserirPessoa();

            Assert.Equal(idade, pessoa.CalcularIdade());
        }

        [Fact(DisplayName = "Imprimir dados")]
        public void ExercicioDois_Imprimir_Dados()
        {
            _screenCommand
                .Setup(x => x.InputValue("Insira o nome: "))
                .Returns("Henrique");

            _screenCommand
                .Setup(x => x.InputValue("Insira a data de nascimento (dd/MM/yyyy): "))
                .Returns("25/07/1989");

            _screenCommand
                .Setup(x => x.InputValue("Insira a altura: "))
                .Returns("1,87");

            var exercicio = new ExercicioDois(_screenCommand.Object);
            var pessoa = exercicio.InserirPessoa();

            Assert.Equal("Nome: Henrique, Data de nascimento: 25/07/1989, Altura: 1,87", pessoa.ImprimirDados());
        }
    }
}