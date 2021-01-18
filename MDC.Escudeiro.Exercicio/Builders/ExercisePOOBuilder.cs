using MDC.Escudeiro.Domain.Builders;
using MDC.Escudeiro.Domain.Interfaces;
using MDC.Escudeiro.Domain.Models;
using MDC.Escudeiro.Exercicio.POO;

namespace MDC.Escudeiro.Exercicio.Builders
{
    public class ExercisePOOBuilder : INodeBuilder
    {
        private readonly IScreenCommand _screenCommand;

        public ExercisePOOBuilder(IScreenCommand screenCommand)
        {
            _screenCommand = screenCommand;
        }

        public CommandNode Build()
        {
            var arvore = new RootCommandNodeBuilder()
                .SetTitle(Text.Titulo_2)
                .AddChild(new ExercicioDois(_screenCommand))
                .AddChild(new ExercicioTres(_screenCommand))
                .AddChild(new ExercicioQuatro(_screenCommand))
                .Build();

            return arvore;
        }
    }
}