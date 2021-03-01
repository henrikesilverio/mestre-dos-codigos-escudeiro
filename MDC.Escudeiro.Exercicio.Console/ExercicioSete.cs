using MDC.Escudeiro.Domain.Builders;
using MDC.Escudeiro.Domain.Interfaces;
using MDC.Escudeiro.Domain.Models;
using System;
using System.Linq;

namespace MDC.Escudeiro.Exercicio.Console
{
    public class ExercicioSete : ExecicioBase, INodeBuilder
    {
        private readonly IScreenCommand _screenCommand;
        private readonly int[] _numeros;

        public ExercicioSete(IScreenCommand screenCommand) : base(screenCommand)
        {
            _screenCommand = screenCommand;
            _numeros = new int[4];
        }

        public CommandNode Build()
        {
            var arvore = new RootCommandNodeBuilder()
                .SetTitle(Text.Titulo_6)
                .AddChild(() =>
                {
                    var soma = SomarPares();
                    _screenCommand.PrintResult(string.Format(Text.Resposta_6_1, string.Join(" | ", NumeroPares())));
                    _screenCommand.PrintResult(string.Format(Text.Resposta_6_0, soma));
                }, Text.Pergunta_6_0)
                .Build();

            return arvore;
        }

        public int SomarPares()
        {
            ReceberValores();

            return NumeroPares().Sum();
        }

        private int[] NumeroPares()
        {
            return _numeros.Where(n => n % 2 == 0).ToArray();
        }

        private void ReceberValores()
        {
            for (int i = 0; i < 4; i++)
            {
                var numero = _screenCommand.InputValue(string.Format(Text.InserirPosicaoValor, i + 1));
                _numeros[i] = Convert.ToInt32(numero);
            }
        }
    }
}