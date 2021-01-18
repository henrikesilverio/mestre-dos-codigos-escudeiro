using MDC.Escudeiro.Domain.Builders;
using MDC.Escudeiro.Domain.Interfaces;
using MDC.Escudeiro.Domain.Models;
using MDC.Escudeiro.Exercicio.Teorico;

namespace MDC.Escudeiro.Exercicio.Builders
{
    public class ExerciseTheoreticalBuilder : INodeBuilder
    {
        private readonly IScreenCommand _screenCommand;

        public ExerciseTheoreticalBuilder(IScreenCommand screenCommandConsole)
        {
            _screenCommand = screenCommandConsole;
        }

        public CommandNode Build()
        {
            var arvore = new RootCommandNodeBuilder()
                .SetTitle(Text.Titulo_0)
                .AddChild(new ExercicioUm(_screenCommand))
                .AddChild(new ExercicioDois(_screenCommand))
                .Build();

            return arvore;
        }
    }
}