using MDC.Escudeiro.Domain.Abstract;
using MDC.Escudeiro.Domain.Interfaces;
using MDC.Escudeiro.Domain.Models;
using System;
using System.Linq.Expressions;

namespace MDC.Escudeiro.Exercicio.POO
{
    public class ExercicioQuatro : AbstractExercise
    {
        private readonly IScreenCommand _screenCommand;
        private readonly Televisao _televisao;
        private ControleAbstract _controle;
        private TipoControle _tipoControle;

        public ExercicioQuatro(IScreenCommand screenCommand)
        {
            _screenCommand = screenCommand;
            _televisao = new Televisao();
        }

        public Televisao ObterTelevisao()
        {
            return _televisao;
        }

        public ControleAbstract CriarControle()
        {
            ReceberValores();
            ImprimirDados();

            return _televisao;
        }

        public void AumentarVolume()
        {
            ExecutarOperacao(x => x.AumentarVolume);
        }

        public void DiminuirVolume()
        {
            ExecutarOperacao(x => x.DiminuirVolume);
        }

        public void IncrementarCanal()
        {
            ExecutarOperacao(x => x.IncrementarCanal);
        }

        public void DecrementarCanal()
        {
            ExecutarOperacao(x => x.DecrementarCanal);
        }

        public void IrParaCanal()
        {
            if (_controle == null)
            {
                _screenCommand.PrintError(Text.ControleNaoCriado);
                return;
            }

            var valor = _screenCommand.InputValue(Text.InserirCanal);
            var canal = Convert.ToInt32(valor, GetNumberFormatInfo(valor));

            _controle.IrParaCanal(canal);

            ImprimirDados();
        }

        public override CommandNode[] GetBranches(CommandNode parent)
        {
            var commands = new CommandNode[6];

            for (int i = 0; i < commands.Length; i++)
            {
                commands[i] = new CommandNode
                {
                    Action = GetActions(i),
                    Order = i,
                    Parent = parent,
                    Title = Text.ResourceManager.GetString($"Pergunta-3-{i}"),
                };
            }

            return commands;
        }

        private void ExecutarOperacao(Expression<Func<ControleAbstract, Action>> expressao)
        {
            if (_controle == null)
            {
                _screenCommand.PrintError(Text.ControleNaoCriado);
                return;
            }

            try
            {
                var operacao = expressao.Compile().Invoke(_controle);
                operacao();
                ImprimirDados();
            }
            catch (Exception ex)
            {
                _screenCommand.PrintError(ex.Message);
            }
        }

        private void ReceberValores()
        {
            _screenCommand.PrintInfo(Text.TipoControle);
            var tipoConta = _screenCommand.InputValue(Text.InserirTipoControle);

            _tipoControle = (TipoControle)Convert.ToInt32(tipoConta);

            if (_tipoControle == TipoControle.Direto)
            {
                _controle = _televisao;
            }
            if (_tipoControle == TipoControle.Remoto)
            {
                _controle = new ControleRemoto(_televisao);
            }
        }

        private void ImprimirDados()
        {
            _screenCommand.PrintResult(_televisao.MostrarDados());
        }

        private Action GetActions(int index)
        {
            return index switch
            {
                0 => () => CriarControle(),
                1 => () => AumentarVolume(),
                2 => () => DiminuirVolume(),
                3 => () => IncrementarCanal(),
                4 => () => DecrementarCanal(),
                5 => () => IrParaCanal(),
                _ => default,
            };
        }
    }
}