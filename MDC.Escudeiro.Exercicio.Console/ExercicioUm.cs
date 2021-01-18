using MDC.Escudeiro.Domain.Builders;
using MDC.Escudeiro.Domain.Interfaces;
using MDC.Escudeiro.Domain.Models;
using System;

namespace MDC.Escudeiro.Exercicio.Console
{
    public class ExercicioUm : ExecicioBase, INodeBuilder
    {
        private decimal _primeiroValor;
        private decimal _segundoValor;
        private readonly IScreenCommand _screenCommand;

        public ExercicioUm(IScreenCommand screenCommand)
        {
            _screenCommand = screenCommand;
        }

        public CommandNode Build()
        {
            var arvore = new RootCommandNodeBuilder()
                .SetTitle(Text.Titulo_0)
                .AddChild(() => _screenCommand.PrintResult(string.Format(Text.Resposta_0_0, Somar())), Text.Pergunta_0_0)
                .AddChild(() => _screenCommand.PrintResult(string.Format(Text.Resposta_0_1, Subtrair())), Text.Pergunta_0_1)
                .AddChild(() => _screenCommand.PrintResult(string.Format(Text.Resposta_0_2, Dividir())), Text.Pergunta_0_2)
                .AddChild(() => _screenCommand.PrintResult(string.Format(Text.Resposta_0_3, Multiplicar())), Text.Pergunta_0_3)
                .AddChild(() => _screenCommand.PrintResult(Classificar()), Text.Pergunta_0_4)
                .Build();

            return arvore;
        }

        public decimal Somar()
        {
            ReceberValores();
            return _primeiroValor + _segundoValor;
        }

        public decimal Subtrair()
        {
            ReceberValores();
            return _primeiroValor - _segundoValor;
        }

        public decimal Dividir()
        {
            ReceberValores();
            return _segundoValor / _primeiroValor;
        }

        public decimal Multiplicar()
        {
            ReceberValores();
            return _primeiroValor * _segundoValor;
        }

        public string Classificar()
        {
            ReceberValores();
            return string.Format(Text.Resposta_0_4, _primeiroValor, TipoValor(_primeiroValor), _segundoValor, TipoValor(_segundoValor));
        }

        private string TipoValor(decimal valor) => valor % 2 == 0 ? "é par" : "é ímpar";

        private void ReceberValores()
        {
            var primeiroValor = _screenCommand.InputValue(string.Format(Text.InserirValor, "A"));
            var segundoValor = _screenCommand.InputValue(string.Format(Text.InserirValor, "B"));

            _primeiroValor = Convert.ToDecimal(primeiroValor, GetNumberFormatInfo(primeiroValor));
            _segundoValor = Convert.ToDecimal(segundoValor, GetNumberFormatInfo(segundoValor));
        }
    }
}