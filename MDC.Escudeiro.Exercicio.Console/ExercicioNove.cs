using MDC.Escudeiro.Domain.Abstract;
using MDC.Escudeiro.Domain.Interfaces;
using MDC.Escudeiro.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MDC.Escudeiro.Exercicio.Console
{
    public class ExercicioNove : AbstractExercise
    {
        private readonly IScreenCommand _screenCommand;
        private static readonly List<int> _numeros = new List<int>();
        private int _numero;

        public ExercicioNove(IScreenCommand screenCommand)
        {
            _screenCommand = screenCommand;
        }

        public void ImprimirTodos()
        {
            _screenCommand.PrintBigText($"Todos valores inseridos: {string.Join(" | ", _numeros)}");
        }

        public int[] ObterOrdemCrescente()
        {
            return _numeros.OrderBy(n => n).ToArray();
        }

        public int[] ObterOrdemDecrescente()
        {
            return _numeros.OrderByDescending(n => n).ToArray();
        }

        public int ObterPrimeiroNumero()
        {
            return _numeros.FirstOrDefault();
        }

        public int ObterUltimoNumero()
        {
            return _numeros.Last();
        }

        public void InserirNoComeco()
        {
            ReceberValores();

            _numeros.Insert(0, _numero);
        }

        public void InserirNoFim()
        {
            ReceberValores();

            _numeros.Add(_numero);
        }

        public void RemoverPrimeiro()
        {
            _numeros.RemoveAt(0);
        }

        public void RemoverUltimo()
        {
            _numeros.RemoveAt(_numeros.Count - 1);
        }

        public int[] ObterNumerosPares()
        {
            return _numeros.Where(n => n % 2 == 0).ToArray();
        }

        public int ConsultarNumero()
        {
            ReceberValores();

            return _numeros.FirstOrDefault(n => n == _numero);
        }

        public int[] ObterTodos()
        {
            return _numeros.ToArray();
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
                    Action = ImprimirTodos,
                    Parent = parent,
                    Order = 0,
                    Title = "({0}) Imprimir todos os números da lista"
                },
                new CommandNode
                {
                    Action = () => _screenCommand.PrintBigText($"Ordem crescente : {string.Join(" | ", ObterOrdemCrescente())}"),
                    Parent = parent,
                    Order = 1,
                    Title = "({0}) Imprimir todos os números da lista na ordem crescente"
                },
                new CommandNode
                {
                    Action = () => _screenCommand.PrintBigText($"Ordem decrescente : {string.Join(" | ", ObterOrdemDecrescente())}"),
                    Parent = parent,
                    Order = 2,
                    Title = "({0}) Imprimir todos os números da lista na ordem decrescente"
                },
                new CommandNode
                {
                    Action = () => _screenCommand.PrintResult($"Primeiro número da lista : {ObterPrimeiroNumero()}"),
                    Parent = parent,
                    Order = 3,
                    Title = "({0}) Imprima apenas o primeiro número da lista"
                },
                new CommandNode
                {
                    Action = () => _screenCommand.PrintResult($"Ultimo número da lista : {ObterUltimoNumero()}"),
                    Parent = parent,
                    Order = 4,
                    Title = "({0}) Imprima apenas o ultimo número da lista"
                },
                new CommandNode
                {
                    Action = () =>
                    {
                        InserirNoComeco();
                        ImprimirTodos();
                    },
                    Parent = parent,
                    Order = 5,
                    Title = "({0}) Insira um número no início da lista"
                },
                new CommandNode
                {
                    Action = () =>
                    {
                        InserirNoFim();
                        ImprimirTodos();
                    },
                    Parent = parent,
                    Order = 6,
                    Title = "({0}) Insira um número no final da lista"
                },
                new CommandNode
                {
                    Action = () =>
                    {
                        RemoverPrimeiro();
                        ImprimirTodos();
                    },
                    Parent = parent,
                    Order = 7,
                    Title = "({0}) Remova o primeiro número"
                },
                new CommandNode
                {
                    Action = () =>
                    {
                        RemoverUltimo();
                        ImprimirTodos();
                    },
                    Parent = parent,
                    Order = 8,
                    Title = "({0}) Remova o último número"
                },
                new CommandNode
                {
                    Action = () => _screenCommand.PrintBigText($"Número(s) par(es) {string.Join(" | ", ObterNumerosPares())}"),
                    Parent = parent,
                    Order = 9,
                    Title = "({0}) Retorne apenas os números pares"
                },
                new CommandNode
                {
                    Action = () => _screenCommand.PrintResult($"Número encontrado é : {ConsultarNumero()}"),
                    Parent = parent,
                    Order = 10,
                    Title = "({0}) Retorne apenas o número informado"
                }
            };

            return commands;
        }

        private void ReceberValores()
        {
            var numero = _screenCommand.InputValue("Insira o número: ");

            _numero = Convert.ToInt32(numero, GetNumberFormatInfo(numero));
        }
    }
}
