using MDC.Escudeiro.Domain.Abstract;
using MDC.Escudeiro.Domain.Interfaces;
using MDC.Escudeiro.Domain.Models;
using System;

namespace MDC.Escudeiro.Exercicio.Console
{
    public class ExercicioUm : AbstractExercise
    {
        private decimal _primeiroValor;
        private decimal _segundoValor;
        private readonly IScreenCommand _screenCommand;

        public ExercicioUm(IScreenCommand screenCommand)
        {
            _screenCommand = screenCommand;
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

        public override CommandNode[] GetBranches(CommandNode parent)
        {
            var commands = new CommandNode[5];

            for (int i = 0; i < commands.Length; i++)
            {
                commands[i] = new CommandNode
                {
                    Action = GetActions(i),
                    Order = i,
                    Parent = parent,
                    Title = Text.ResourceManager.GetString($"Pergunta-0-{i}"),
                };
            }

            return commands;
        }

        private string TipoValor(decimal valor) => valor % 2 == 0 ? "é par" : "é ímpar";

        private void ReceberValores()
        {
            var primeiroValor = _screenCommand.InputValue(string.Format(Text.InserirValor, "A"));
            var segundoValor = _screenCommand.InputValue(string.Format(Text.InserirValor, "B"));

            _primeiroValor = Convert.ToDecimal(primeiroValor, GetNumberFormatInfo(primeiroValor));
            _segundoValor = Convert.ToDecimal(segundoValor, GetNumberFormatInfo(segundoValor));
        }

        private Action GetActions(int index)
        {
            return index switch
            {
                0 => () => _screenCommand.PrintResult(string.Format(Text.Resposta_0_0, Somar())),
                1 => () => _screenCommand.PrintResult(string.Format(Text.Resposta_0_1, Subtrair())),
                2 => () => _screenCommand.PrintResult(string.Format(Text.Resposta_0_2, Dividir())),
                3 => () => _screenCommand.PrintResult(string.Format(Text.Resposta_0_3, Multiplicar())),
                4 => () => _screenCommand.PrintResult(Classificar()),
                _ => default,
            };
        }
    }
}