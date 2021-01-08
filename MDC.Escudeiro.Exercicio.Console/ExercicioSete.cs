using MDC.Escudeiro.Domain.Abstract;
using MDC.Escudeiro.Domain.Interfaces;
using MDC.Escudeiro.Domain.Models;
using System;
using System.Linq;

namespace MDC.Escudeiro.Exercicio.Console
{
    public class ExercicioSete : AbstractExercise
    {
        private readonly IScreenCommand _screenCommand;
        private readonly int[] _numeros;

        public ExercicioSete(IScreenCommand screenCommand)
        {
            _screenCommand = screenCommand;
            _numeros = new int[4];
        }

        public int SomarPares()
        {
            ReceberValores();

            return NumeroPares().Sum();
        }

        public override CommandNode[] GetBranches(CommandNode parent)
        {
            var commands = new CommandNode[]
            {
                new CommandNode
                {
                    Action = () =>
                    {
                        _screenCommand.PrintResult(string.Format(Text.Resposta_6_0, SomarPares()));
                        _screenCommand.PrintResult(string.Format(Text.Resposta_6_1, string.Join(",", NumeroPares())));
                    },
                    Parent = parent,
                    Order = 0,
                    Title = Text.Pergunta_6_0
                }
            };

            return commands;
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