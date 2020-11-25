using MDC.Escudeiro.Domain.Abstract;
using MDC.Escudeiro.Domain.Interfaces;
using MDC.Escudeiro.Domain.Models;

namespace MDC.Escudeiro.Exercicio.Console
{
    public class ExercicioTres : AbstractExercise
    {
        private readonly IScreenCommand _screenCommand;

        public ExercicioTres(IScreenCommand screenCommand)
        {
            _screenCommand = screenCommand;
        }

        public void MultiplosTres()
        {
            for (int i = 1; i < 100; i++)
            {
                if (i % 3 == 0)
                {
                    _screenCommand.PrintResult($"{i} é múltiplo de 3");
                }
            }
        }

        public override CommandNode[] GetBranches(CommandNode parent)
        {
            var commands = new CommandNode[]
            {
                new CommandNode
                {
                    Action = MultiplosTres,
                    Parent = parent,
                    Order = 0,
                    Title = "({0}) Imprima todos os múltiplos de 3"
                }
            };

            return commands;
        }
    }
}