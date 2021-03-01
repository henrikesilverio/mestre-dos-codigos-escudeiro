using MDC.Escudeiro.Domain.Builders;
using MDC.Escudeiro.Domain.Interfaces;
using MDC.Escudeiro.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MDC.Escudeiro.Exercicio.Console
{
    public class ExercicioOito : ExecicioBase, INodeBuilder
    {
        private readonly IScreenCommand _screenCommand;
        private readonly List<decimal> _numeros = new List<decimal>();
        private decimal _numero;

        public ExercicioOito(IScreenCommand screenCommand) : base(screenCommand)
        {
            _screenCommand = screenCommand;
        }

        public CommandNode Build()
        {
            var arvore = new RootCommandNodeBuilder()
                .SetTitle(Text.Titulo_7)
                .AddChild(() =>
                {
                    var funcionario = InserirNumero();
                    _screenCommand.PrintResult(string.Format(Text.Resposta_7_0, _numero));
                }, Text.Pergunta_7_0)
                .AddChild(() => _screenCommand.PrintResult(string.Format(Text.Resposta_7_1, ObterOrdemCrescente())), Text.Pergunta_7_1)
                .AddChild(() => _screenCommand.PrintResult(string.Format(Text.Resposta_7_2, ObterOrdemDecrescente())), Text.Pergunta_7_2)
                .Build();

            return arvore;
        }

        public List<decimal> InserirNumero()
        {
            ReceberValores();

            _numeros.Add(_numero);
            return _numeros;
        }

        public string ObterOrdemCrescente()
        {
            return string.Join(" | ", _numeros.OrderBy(x => x).ToArray());
        }

        public string ObterOrdemDecrescente()
        {
            return string.Join(" | ", _numeros.OrderByDescending(x => x).ToArray());
        }

        private void ReceberValores()
        {
            var numero = _screenCommand.InputValue(Text.InserirNumero);

            _numero = Convert.ToDecimal(numero, GetNumberFormatInfo(numero));
        }
    }
}