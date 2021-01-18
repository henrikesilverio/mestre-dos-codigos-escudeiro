using MDC.Escudeiro.Domain.Builders;
using MDC.Escudeiro.Domain.Interfaces;
using MDC.Escudeiro.Domain.Models;

namespace MDC.Escudeiro.Exercicio.Builders
{
    public class ExerciseTreeBuilder : INodeBuilder
    {
        private readonly IScreenCommand _screenCommand;

        public ExerciseTreeBuilder(IScreenCommand screenCommand)
        {
            _screenCommand = screenCommand;
        }

        public CommandNode Build()
        {
            var arvore = new RootCommandNodeBuilder()
                .SetTitle(Text.Titulo)
                .AddChild(new ExerciseTheoreticalBuilder(_screenCommand))
                .AddChild(new ExerciseConsoleBuilder(_screenCommand))
                .AddChild(new ExercisePOOBuilder(_screenCommand))
                .Build();

            return arvore;
        }
    }
}