using MDC.Escudeiro.Domain.Abstract;
using MDC.Escudeiro.Domain.Interfaces;
using MDC.Escudeiro.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MDC.Escudeiro.Exercicio.Console
{
    public class ExercicioOito : AbstractExercise
    {
        private readonly IScreenCommand _screenCommand;
        private static readonly List<decimal> _numeros = new List<decimal>();
        private decimal _numero;

        public ExercicioOito(IScreenCommand screenCommand)
        {
            _screenCommand = screenCommand;
        }

        public List<decimal> InserirNumero()
        {
            ReceberValores();

            _numeros.Add(_numero);
            return _numeros;
        }

        public List<decimal> ObterOrdemCrescente()
        {
            return _numeros.OrderBy(x => x).ToList();
        }

        public List<decimal> ObterOrdemDecrescente()
        {
            return _numeros.OrderByDescending(x => x).ToList();
        }

        public void RemoverTodos()
        {
            _numeros.Clear();
        }

        public override CommandNode[] GetBranches(CommandNode parent)
        {
            var commands = new CommandNode[]
            {
                new CommandNode
                {
                    Action = () =>
                    {
                        var funcionario = InserirNumero();
                        _screenCommand.PrintResult($"Número: {_numero} inserido");
                    },
                    Parent = parent,
                    Order = 0,
                    Title = "({0}) Inserir número"
                },
                new CommandNode
                {
                    Action = () =>
                    {
                        _screenCommand.PrintResult($"Ordem crescente : {string.Join(" | ", ObterOrdemCrescente())}");
                    },
                    Parent = parent,
                    Order = 1,
                    Title = "({0}) Imprimir em ordem crescente"
                },
                new CommandNode
                {
                    Action = () =>
                    {
                        _screenCommand.PrintResult($"Ordem decrescente : {string.Join(" | ", ObterOrdemDecrescente())}");
                    },
                    Parent = parent,
                    Order = 2,
                    Title = "({0}) Imprimir em ordem decrescente"
                },
            };
            return commands;
        }

        private void ReceberValores()
        {
            var numero = _screenCommand.InputValue("Insira o número: ");

            _numero = Convert.ToDecimal(numero, GetNumberFormatInfo(numero));
        }
    }
}
