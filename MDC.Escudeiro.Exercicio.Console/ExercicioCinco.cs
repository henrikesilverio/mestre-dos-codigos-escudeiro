using MDC.Escudeiro.Domain.Builders;
using MDC.Escudeiro.Domain.Interfaces;
using MDC.Escudeiro.Domain.Models;
using System;

namespace MDC.Escudeiro.Exercicio.Console
{
    public class ExercicioCinco : ExecicioBase, INodeBuilder
    {
        private readonly IScreenCommand _screenCommand;
        private double _valorA;
        private double _valorB;
        private double _valorC;

        public ExercicioCinco(IScreenCommand screenCommand) : base(screenCommand)
        {
            _screenCommand = screenCommand;
        }

        public CommandNode Build()
        {
            var arvore = new RootCommandNodeBuilder()
                .SetTitle(Text.Titulo_4)
                .AddChild(() =>
                {
                    var raizes = CalcularBhaskara();
                    _screenCommand.PrintResult(string.Format(Text.Resposta_4_0, raizes.Item1, raizes.Item2));
                }, Text.Pergunta_4_0)
                .Build();

            return arvore;
        }

        public ValueTuple<double, double> CalcularBhaskara()
        {
            ReceberValores();

            var delta = Math.Pow(_valorB, 2) - 4 * _valorA * _valorC;
            var raizUm = (-_valorB + Math.Sqrt(delta)) / (2 * _valorA);
            var raizDois = (-_valorB - Math.Sqrt(delta)) / (2 * _valorA);

            return (raizUm, raizDois);
        }

        private void ReceberValores()
        {
            var valorA = _screenCommand.InputValue(string.Format(Text.InserirValor, "A"));
            var valorB = _screenCommand.InputValue(string.Format(Text.InserirValor, "B"));
            var valorC = _screenCommand.InputValue(string.Format(Text.InserirValor, "C"));

            _valorA = Convert.ToDouble(valorA, GetNumberFormatInfo(valorA));
            _valorB = Convert.ToDouble(valorB, GetNumberFormatInfo(valorB));
            _valorC = Convert.ToDouble(valorC, GetNumberFormatInfo(valorC));
        }
    }
}