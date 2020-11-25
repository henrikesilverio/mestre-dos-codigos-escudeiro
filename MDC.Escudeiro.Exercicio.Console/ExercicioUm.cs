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
            return $"Valor A: {_primeiroValor} {TipoValor(_primeiroValor)}, Valor B: {_segundoValor} {TipoValor(_segundoValor)}";
        }

        public override CommandNode[] GetBranches(CommandNode parent)
        {
            var commands = new CommandNode[]
            {
                new CommandNode
                {
                    Action = () => _screenCommand.PrintResult($"O valor de A + B = {Somar()}"),
                    Parent = parent,
                    Order = 0,
                    Title = "({0}) Some esses 2 valores"
                },
                new CommandNode
                {
                    Action = () => _screenCommand.PrintResult($"O valor de A - B = {Subtrair()}"),
                    Parent = parent,
                    Order = 1,
                    Title = "({0}) Faça uma subtração do valor A - B"
                },
                new CommandNode
                {
                    Action = () => _screenCommand.PrintResult($"O valor de B / A = {Dividir()}"),
                    Parent = parent,
                    Order = 2,
                    Title = "({0}) Divida o valor B por A"
                },
                new CommandNode
                {
                    Action = () => _screenCommand.PrintResult($"O valor de A * B = {Multiplicar()}"),
                    Parent = parent,
                    Order = 3,
                    Title = "({0}) Multiplique o valor A por B"
                },
                new CommandNode
                {
                    Action = () => _screenCommand.PrintResult(Classificar()),
                    Parent = parent,
                    Order = 4,
                    Title = "({0}) Número par ou ímpar"
                }
            };

            return commands;
        }

        private string TipoValor(decimal valor) => valor % 2 == 0 ? "é par" : "é ímpar";

        private void ReceberValores()
        {
            var primeiroValor = _screenCommand.InputValue("Insira o valor A: ");
            var segundoValor = _screenCommand.InputValue("Insira o valor B: ");

            _primeiroValor = Convert.ToDecimal(primeiroValor, GetNumberFormatInfo(primeiroValor));
            _segundoValor = Convert.ToDecimal(segundoValor, GetNumberFormatInfo(segundoValor));
        }
    }
}