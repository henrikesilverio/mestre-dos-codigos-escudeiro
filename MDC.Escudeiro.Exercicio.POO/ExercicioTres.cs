using MDC.Escudeiro.Domain.Abstract;
using MDC.Escudeiro.Domain.Interfaces;
using MDC.Escudeiro.Domain.Models;

namespace MDC.Escudeiro.Exercicio.POO
{
    public class ExercicioTres : AbstractExercise
    {
        private readonly IScreenCommand _screenCommand;

        public ExercicioTres(IScreenCommand screenCommand)
        {
            _screenCommand = screenCommand;
        }

        public override CommandNode[] GetBranches(CommandNode parent)
        {
            var commands = new CommandNode[] { };
            return commands;
        }
    }
}
