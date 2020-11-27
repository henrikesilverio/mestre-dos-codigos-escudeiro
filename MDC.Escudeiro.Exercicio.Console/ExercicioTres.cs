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
                    _screenCommand.PrintResult(string.Format(Text.Resposta_2_0, i));
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
                    Title = Text.Pergunta_2_0
                }
            };

            return commands;
        }
    }
}