using MDC.Escudeiro.Domain.Interfaces;
using Moq;
using Xunit;

namespace MDC.Escudeiro.Exercicio.POO.Teste.Exercicios
{
    [Trait("Crie uma aplicação bancária", "todos")]
    public class ExercicioTresTeste
    {
        private readonly Mock<IScreenCommand> _screenCommand;

        public ExercicioTresTeste()
        {
            _screenCommand = new Mock<IScreenCommand>();
        }

        [Fact(DisplayName = "Criar uma conta corrente")]
        public void ExercicioTres_Criar_Conta_Corrente()
        {
            _screenCommand
                .Setup(x => x.InputValue("Insira o tipo da conta: "))
                .Returns("0");

            _screenCommand
                .Setup(x => x.InputValue("Insira o número da conta: "))
                .Returns("123456");

            _screenCommand
                .Setup(x => x.InputValue("Insira o saldo inicial: "))
                .Returns("1000,00");

            _screenCommand
                .Setup(x => x.InputValue("Insira a taxa de operação (0 a 100): "))
                .Returns("1");

            var exercicio = new ExercicioTres(_screenCommand.Object);
            var conta = exercicio.CriarConta();

            Assert.Equal(123456, conta.NumeroDaConta);
            Assert.Equal(1000.00, conta.Saldo);
            Assert.Equal("Conta Corrente: 123456 | Saldo: R$ 1.000,00 | Taxa de operação: 0,01", conta.MostrarDados());
        }

        [Fact(DisplayName = "Depositar em uma conta corrente")]
        public void ExercicioTres_Depositar_Conta_Corrente()
        {
            _screenCommand
                .Setup(x => x.InputValue("Insira o tipo da conta: "))
                .Returns("0");

            _screenCommand
                .Setup(x => x.InputValue("Insira o número da conta: "))
                .Returns("123456");

            _screenCommand
                .Setup(x => x.InputValue("Insira o saldo inicial: "))
                .Returns("1000,00");

            _screenCommand
                .Setup(x => x.InputValue("Insira a taxa de operação (0 a 100): "))
                .Returns("1");

            _screenCommand
                .Setup(x => x.InputValue("Insira o valor: "))
                .Returns("500,00");

            var exercicio = new ExercicioTres(_screenCommand.Object);
            var conta = exercicio.CriarConta();

            exercicio.Depositar();

            Assert.Equal(123456, conta.NumeroDaConta);
            Assert.Equal(1495.00, conta.Saldo);
            Assert.Equal("Conta Corrente: 123456 | Saldo: R$ 1.495,00 | Taxa de operação: 0,01", conta.MostrarDados());
        }

        [Fact(DisplayName = "Sacar de uma conta corrente")]
        public void ExercicioTres_Sacar_Conta_Corrente()
        {
            _screenCommand
                .Setup(x => x.InputValue("Insira o tipo da conta: "))
                .Returns("0");

            _screenCommand
                .Setup(x => x.InputValue("Insira o número da conta: "))
                .Returns("123456");

            _screenCommand
                .Setup(x => x.InputValue("Insira o saldo inicial: "))
                .Returns("1000,00");

            _screenCommand
                .Setup(x => x.InputValue("Insira a taxa de operação (0 a 100): "))
                .Returns("1");

            _screenCommand
                .Setup(x => x.InputValue("Insira o valor: "))
                .Returns("500,00");

            var exercicio = new ExercicioTres(_screenCommand.Object);
            var conta = exercicio.CriarConta();

            exercicio.Sacar();

            Assert.Equal(123456, conta.NumeroDaConta);
            Assert.Equal(495.00, conta.Saldo);
            Assert.Equal("Conta Corrente: 123456 | Saldo: R$ 495,00 | Taxa de operação: 0,01", conta.MostrarDados());
        }

        [Fact(DisplayName = "Sacar de uma conta corrente, sem saldo para taxa")]
        public void ExercicioTres_Sacar_Conta_Corrente_Sem_Saldo_Taxa()
        {
            _screenCommand
                .Setup(x => x.InputValue("Insira o tipo da conta: "))
                .Returns("0");

            _screenCommand
                .Setup(x => x.InputValue("Insira o número da conta: "))
                .Returns("123456");

            _screenCommand
                .Setup(x => x.InputValue("Insira o saldo inicial: "))
                .Returns("500,00");

            _screenCommand
                .Setup(x => x.InputValue("Insira a taxa de operação (0 a 100): "))
                .Returns("1");

            _screenCommand
                .Setup(x => x.InputValue("Insira o valor: "))
                .Returns("500,00");

            var exercicio = new ExercicioTres(_screenCommand.Object);
            var conta = exercicio.CriarConta();

            exercicio.Sacar();

            _screenCommand
                .Verify(x => x.PrintError("O valor de: R$ 500,00 + taxa de operação de: 0,01, é maior que saldo."), Times.Exactly(1));

            Assert.Equal(500.00, conta.Saldo);
        }

        [Fact(DisplayName = "Criar uma conta especial")]
        public void ExercicioTres_Criar_Conta_Especial()
        {
            _screenCommand
                .Setup(x => x.InputValue("Insira o tipo da conta: "))
                .Returns("1");

            _screenCommand
                .Setup(x => x.InputValue("Insira o número da conta: "))
                .Returns("123456");

            _screenCommand
                .Setup(x => x.InputValue("Insira o saldo inicial: "))
                .Returns("1000,00");

            _screenCommand
                .Setup(x => x.InputValue("Insira o limite: "))
                .Returns("500,00");

            var exercicio = new ExercicioTres(_screenCommand.Object);
            var conta = exercicio.CriarConta();

            Assert.Equal(123456, conta.NumeroDaConta);
            Assert.Equal(1000.00, conta.Saldo);
            Assert.Equal("Conta Especial: 123456 | Saldo: R$ 1.000,00 | Limite: R$ 500,00", conta.MostrarDados());
        }

        [Fact(DisplayName = "Depositar em uma conta especial")]
        public void ExercicioTres_Depositar_Conta_Especial()
        {
            _screenCommand
                .Setup(x => x.InputValue("Insira o tipo da conta: "))
                .Returns("1");

            _screenCommand
                .Setup(x => x.InputValue("Insira o número da conta: "))
                .Returns("123456");

            _screenCommand
                .Setup(x => x.InputValue("Insira o saldo inicial: "))
                .Returns("1000,00");

            _screenCommand
                .Setup(x => x.InputValue("Insira o limite: "))
                .Returns("500,00");

            _screenCommand
                .Setup(x => x.InputValue("Insira o valor: "))
                .Returns("500,00");

            var exercicio = new ExercicioTres(_screenCommand.Object);
            var conta = exercicio.CriarConta();

            exercicio.Depositar();

            Assert.Equal(123456, conta.NumeroDaConta);
            Assert.Equal(1500.00, conta.Saldo);
            Assert.Equal("Conta Especial: 123456 | Saldo: R$ 1.500,00 | Limite: R$ 500,00", conta.MostrarDados());
        }

        [Fact(DisplayName = "Sacar de uma conta especial")]
        public void ExercicioTres_Sacar_Conta_Especial()
        {
            _screenCommand
                .Setup(x => x.InputValue("Insira o tipo da conta: "))
                .Returns("1");

            _screenCommand
                .Setup(x => x.InputValue("Insira o número da conta: "))
                .Returns("123456");

            _screenCommand
                .Setup(x => x.InputValue("Insira o saldo inicial: "))
                .Returns("500,00");

            _screenCommand
                .Setup(x => x.InputValue("Insira o limite: "))
                .Returns("500,00");

            _screenCommand
                .Setup(x => x.InputValue("Insira o valor: "))
                .Returns("1000,00");

            var exercicio = new ExercicioTres(_screenCommand.Object);
            var conta = exercicio.CriarConta();

            exercicio.Sacar();

            Assert.Equal(123456, conta.NumeroDaConta);
            Assert.Equal(-500, conta.Saldo);
            Assert.Equal("Conta Especial: 123456 | Saldo: -R$ 500,00 | Limite: R$ 500,00", conta.MostrarDados());
        }

        [Fact(DisplayName = "Sacar de uma conta especial, acima do limite")]
        public void ExercicioTres_Sacar_Conta_Especial_Acima_Do_Limite()
        {
            _screenCommand
                .Setup(x => x.InputValue("Insira o tipo da conta: "))
                .Returns("1");

            _screenCommand
                .Setup(x => x.InputValue("Insira o número da conta: "))
                .Returns("123456");

            _screenCommand
                .Setup(x => x.InputValue("Insira o saldo inicial: "))
                .Returns("500,00");

            _screenCommand
                .Setup(x => x.InputValue("Insira o limite: "))
                .Returns("500,00");

            _screenCommand
                .Setup(x => x.InputValue("Insira o valor: "))
                .Returns("1100,00");

            var exercicio = new ExercicioTres(_screenCommand.Object);
            var conta = exercicio.CriarConta();

            exercicio.Sacar();

            _screenCommand
                .Verify(x => x.PrintError("O valor de: R$ 1.100,00 - o saldo de: R$ 500,00, é maior que o limite."), Times.Exactly(1));

            Assert.Equal(500, conta.Saldo);
        }
    }
}