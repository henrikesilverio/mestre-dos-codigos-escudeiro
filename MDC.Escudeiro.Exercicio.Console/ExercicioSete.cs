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
                        _screenCommand.PrintResult($"A soma dos números pares é: {SomarPares()}");
                        _screenCommand.PrintResult($"Número(s) par(es): {string.Join(",", NumeroPares())}");
                    },
                    Parent = parent,
                    Order = 0,
                    Title = "({0}) Somar os pares"
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
                var numero = _screenCommand.InputValue($"Insira o {i + 1}° valor: ");
                _numeros[i] = Convert.ToInt32(numero);
            }
        }
    }
}
