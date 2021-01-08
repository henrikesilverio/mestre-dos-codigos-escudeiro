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
        private readonly List<decimal> _numeros = new List<decimal>();
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

        public string ObterOrdemCrescente()
        {
            return string.Join(" | ", _numeros.OrderBy(x => x).ToArray());
        }

        public string ObterOrdemDecrescente()
        {
            return string.Join(" | ", _numeros.OrderByDescending(x => x).ToArray());
        }

        public override CommandNode[] GetBranches(CommandNode parent)
        {
            var commands = new CommandNode[3];

            for (int i = 0; i < commands.Length; i++)
            {
                commands[i] = new CommandNode
                {
                    Action = GetActions(i),
                    Order = i,
                    Parent = parent,
                    Title = Text.ResourceManager.GetString($"Pergunta-7-{i}"),
                };
            }

            return commands;
        }

        private void ReceberValores()
        {
            var numero = _screenCommand.InputValue(Text.InserirNumero);

            _numero = Convert.ToDecimal(numero, GetNumberFormatInfo(numero));
        }

        private Action GetActions(int index)
        {
            return index switch
            {
                0 => () =>
                {
                    var funcionario = InserirNumero();
                    _screenCommand.PrintResult(string.Format(Text.Resposta_7_0, _numero));
                }
                ,
                1 => () => _screenCommand.PrintResult(string.Format(Text.Resposta_7_1, ObterOrdemCrescente())),
                2 => () => _screenCommand.PrintResult(string.Format(Text.Resposta_7_2, ObterOrdemDecrescente())),
                _ => default,
            };
        }
    }
}