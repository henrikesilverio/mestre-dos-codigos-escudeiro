using MDC.Escudeiro.Domain.Interfaces;
using Moq;
using Xunit;

namespace MDC.Escudeiro.Exercicio.POO.Teste
{
    [Trait("Crie uma classe Televisao e uma classe ControleRemoto que pode controlar o volume e trocar os canais da televisão", "todos")]
    public class ExercicioQuatroTeste
    {
        private readonly Mock<IScreenCommand> _screenCommand;

        public ExercicioQuatroTeste()
        {
            _screenCommand = new Mock<IScreenCommand>();
        }

        [Fact(DisplayName = "Criar o controle direto na TV")]
        public void ExercicioQuatro_Criar_Controle_Direto()
        {
            _screenCommand
                .Setup(x => x.InputValue("Insira o tipo do controle: "))
                .Returns("0");

            var exercicio = new ExercicioQuatro(_screenCommand.Object);
            var televisao = exercicio.ObterTelevisao();
            var controle = exercicio.CriarControle();

            Assert.Equal(0, televisao.Canal);
            Assert.Equal(0, televisao.Volume);
        }

        [Fact(DisplayName = "Mudar o volume na TV")]
        public void ExercicioQuatro_Aumentar_Ou_Diminuir_Volume_Na_TV()
        {
            _screenCommand
                .Setup(x => x.InputValue("Insira o tipo do controle: "))
                .Returns("0");

            var exercicio = new ExercicioQuatro(_screenCommand.Object);
            var televisao = exercicio.ObterTelevisao();
            var controle = exercicio.CriarControle();

            exercicio.AumentarVolume();

            Assert.Equal(0, televisao.Canal);
            Assert.Equal(1, televisao.Volume);

            exercicio.DiminuirVolume();

            Assert.Equal(0, televisao.Canal);
            Assert.Equal(0, televisao.Volume);
        }

        [Fact(DisplayName = "Mudar de canal na TV")]
        public void ExercicioQuatro_Incrementar_Ou_Decrementar_Canal_Na_TV()
        {
            _screenCommand
                .Setup(x => x.InputValue("Insira o tipo do controle: "))
                .Returns("0");

            var exercicio = new ExercicioQuatro(_screenCommand.Object);
            var televisao = exercicio.ObterTelevisao();
            var controle = exercicio.CriarControle();

            exercicio.IncrementarCanal();

            Assert.Equal(1, televisao.Canal);
            Assert.Equal(0, televisao.Volume);

            exercicio.DecrementarCanal();

            Assert.Equal(0, televisao.Canal);
            Assert.Equal(0, televisao.Volume);
        }

        [Fact(DisplayName = "Mudar para um canal específico na TV")]
        public void ExercicioQuatro_Ir_Para_Canal_Na_TV()
        {
            _screenCommand
                .Setup(x => x.InputValue("Insira o tipo do controle: "))
                .Returns("0");

            _screenCommand
                .Setup(x => x.InputValue("Insira o número do canal: "))
                .Returns("4");

            var exercicio = new ExercicioQuatro(_screenCommand.Object);
            var televisao = exercicio.ObterTelevisao();
            var controle = exercicio.CriarControle();

            exercicio.IrParaCanal();

            Assert.Equal(4, televisao.Canal);
            Assert.Equal(0, televisao.Volume);
        }

        [Fact(DisplayName = "Criar o controle remoto da TV")]
        public void ExercicioQuatro_Criar_Controle_Remoto()
        {
            _screenCommand
                .Setup(x => x.InputValue("Insira o tipo do controle: "))
                .Returns("1");

            var exercicio = new ExercicioQuatro(_screenCommand.Object);
            var televisao = exercicio.ObterTelevisao();
            var controle = exercicio.CriarControle();

            Assert.Equal(0, televisao.Canal);
            Assert.Equal(0, televisao.Volume);
        }

        [Fact(DisplayName = "Mudar o volume no controle")]
        public void ExercicioQuatro_Aumentar_Ou_Diminuir_Volume_No_Controle()
        {
            _screenCommand
                .Setup(x => x.InputValue("Insira o tipo do controle: "))
                .Returns("1");

            var exercicio = new ExercicioQuatro(_screenCommand.Object);
            var televisao = exercicio.ObterTelevisao();
            var controle = exercicio.CriarControle();

            exercicio.AumentarVolume();

            Assert.Equal(0, televisao.Canal);
            Assert.Equal(1, televisao.Volume);

            exercicio.DiminuirVolume();

            Assert.Equal(0, televisao.Canal);
            Assert.Equal(0, televisao.Volume);
        }

        [Fact(DisplayName = "Mudar de canal no controle")]
        public void ExercicioQuatro_Incrementar_Ou_Decrementar_Canal_No_Controle()
        {
            _screenCommand
                .Setup(x => x.InputValue("Insira o tipo do controle: "))
                .Returns("1");

            var exercicio = new ExercicioQuatro(_screenCommand.Object);
            var televisao = exercicio.ObterTelevisao();
            var controle = exercicio.CriarControle();

            exercicio.IncrementarCanal();

            Assert.Equal(1, televisao.Canal);
            Assert.Equal(0, televisao.Volume);

            exercicio.DecrementarCanal();

            Assert.Equal(0, televisao.Canal);
            Assert.Equal(0, televisao.Volume);
        }

        [Fact(DisplayName = "Mudar para um canal específico no controle")]
        public void ExercicioQuatro_Ir_Para_Canal_No_Controle()
        {
            _screenCommand
                .Setup(x => x.InputValue("Insira o tipo do controle: "))
                .Returns("1");

            _screenCommand
                .Setup(x => x.InputValue("Insira o número do canal: "))
                .Returns("4");

            var exercicio = new ExercicioQuatro(_screenCommand.Object);
            var televisao = exercicio.ObterTelevisao();
            var controle = exercicio.CriarControle();

            exercicio.IrParaCanal();

            Assert.Equal(4, televisao.Canal);
            Assert.Equal(0, televisao.Volume);
        }
    }
}