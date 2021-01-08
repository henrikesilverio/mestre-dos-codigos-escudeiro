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
        private readonly List<int> _numeros = new List<int>();
        private int _numero;

        public ExercicioNove(IScreenCommand screenCommand)
        {
            _screenCommand = screenCommand;
        }

        public void ImprimirTodos()
        {
            _screenCommand.PrintBigText(string.Format(Text.Resposta_8_0, string.Join(" | ", _numeros)));
        }

        public string ObterOrdemCrescente()
        {
            return string.Join(" | ", _numeros.OrderBy(n => n).ToArray());
        }

        public string ObterOrdemDecrescente()
        {
            return string.Join(" | ", _numeros.OrderByDescending(n => n).ToArray());
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

        public string ObterNumerosPares()
        {
            return string.Join(" | ", _numeros.Where(n => n % 2 == 0).ToArray());
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

        public override CommandNode[] GetBranches(CommandNode parent)
        {
            var commands = new CommandNode[11];

            for (int i = 0; i < commands.Length; i++)
            {
                commands[i] = new CommandNode
                {
                    Action = GetActions(i),
                    Order = i,
                    Parent = parent,
                    Title = Text.ResourceManager.GetString($"Pergunta-8-{i}"),
                };
            }

            return commands;
        }

        private Action ValidateAction(Action action)
        {
            return () =>
            {
                if (_numeros.Any())
                {
                    action();
                }
                else
                {
                    _screenCommand.PrintResult(Text.ListaVazia);
                }
            };
        }

        private void ReceberValores()
        {
            var numero = _screenCommand.InputValue(Text.InserirNumero);

            _numero = Convert.ToInt32(numero, GetNumberFormatInfo(numero));
        }

        private Action GetActions(int index)
        {
            return index switch
            {
                0 => ValidateAction(() => ImprimirTodos()),
                1 => ValidateAction(() => _screenCommand.PrintBigText(string.Format(Text.Resposta_8_1, ObterOrdemCrescente()))),
                2 => ValidateAction(() => _screenCommand.PrintBigText(string.Format(Text.Resposta_8_2, ObterOrdemDecrescente()))),
                3 => ValidateAction(() => _screenCommand.PrintBigText(string.Format(Text.Resposta_8_3, ObterPrimeiroNumero()))),
                4 => ValidateAction(() => _screenCommand.PrintResult(string.Format(Text.Resposta_8_4, ObterUltimoNumero()))),
                5 => () =>
                {
                    InserirNoComeco();
                    ImprimirTodos();
                }
                ,
                6 => () =>
                {
                    InserirNoFim();
                    ImprimirTodos();
                }
                ,
                7 => () =>
                {
                    RemoverPrimeiro();
                    ImprimirTodos();
                }
                ,
                8 => () =>
                {
                    RemoverUltimo();
                    ImprimirTodos();
                }
                ,
                9 => ValidateAction(() => _screenCommand.PrintBigText(string.Format(Text.Resposta_8_9, ObterNumerosPares()))),
                10 => ValidateAction(() => _screenCommand.PrintResult(string.Format(Text.Resposta_8_10, ConsultarNumero()))),
                _ => default,
            };
        }
    }
}