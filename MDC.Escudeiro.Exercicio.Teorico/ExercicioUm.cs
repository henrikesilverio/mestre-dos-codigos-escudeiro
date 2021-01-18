using MDC.Escudeiro.Domain.Builders;
using MDC.Escudeiro.Domain.Interfaces;
using MDC.Escudeiro.Domain.Models;

namespace MDC.Escudeiro.Exercicio.Teorico
{
    public class ExercicioUm : INodeBuilder
    {
        private readonly IScreenCommand _screenCommand;

        public ExercicioUm(IScreenCommand screenCommand)
        {
            _screenCommand = screenCommand;
        }

        public CommandNode Build()
        {
            var arvore = new RootCommandNodeBuilder()
                .SetTitle(Text.Titulo_0)
                .AddChild(() => _screenCommand.PrintBigText(Text.Resposta_0_0), Text.Pergunta_0_0)
                .AddChild(() => _screenCommand.PrintBigText(Text.Resposta_0_1), Text.Pergunta_0_1)
                .AddChild(() => _screenCommand.PrintBigText(Text.Resposta_0_2), Text.Pergunta_0_2)
                .AddChild(() => _screenCommand.PrintBigText(Text.Resposta_0_3), Text.Pergunta_0_3)
                .Build();

            return arvore;
        }
    }
}