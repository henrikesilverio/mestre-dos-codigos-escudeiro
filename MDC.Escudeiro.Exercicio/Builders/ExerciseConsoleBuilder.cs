using MDC.Escudeiro.Domain.Builders;
using MDC.Escudeiro.Domain.Interfaces;
using MDC.Escudeiro.Domain.Models;
using MDC.Escudeiro.Exercicio.Console;

namespace MDC.Escudeiro.Exercicio.Builders
{
    public class ExerciseConsoleBuilder : INodeBuilder
    {
        private readonly IScreenCommand _screenCommand;

        public ExerciseConsoleBuilder(IScreenCommand screenCommand)
        {
            _screenCommand = screenCommand;
        }

        public CommandNode Build()
        {
            var arvore = new RootCommandNodeBuilder()
                .SetTitle(Text.Titulo_1)
                .AddChild(new ExercicioUm(_screenCommand))
                .AddChild(new ExercicioDois(_screenCommand))
                .AddChild(new ExercicioTres(_screenCommand))
                .AddChild(new ExercicioQuatro(_screenCommand))
                .AddChild(new ExercicioCinco(_screenCommand))
                .AddChild(new ExercicioSeis(_screenCommand))
                .AddChild(new ExercicioSete(_screenCommand))
                .AddChild(new ExercicioOito(_screenCommand))
                .AddChild(new ExercicioNove(_screenCommand))
                .Build();

            return arvore;
        }
    }
}