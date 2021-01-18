using MDC.Escudeiro.Domain.Builders;
using MDC.Escudeiro.Domain.Interfaces;
using MDC.Escudeiro.Domain.Models;

namespace MDC.Escudeiro.Exercicio.Teorico
{
    public class ExercicioDois : INodeBuilder
    {
        private readonly IScreenCommand _screenCommand;

        public ExercicioDois(IScreenCommand screenCommand)
        {
            _screenCommand = screenCommand;
        }

        public CommandNode Build()
        {
            var arvore = new RootCommandNodeBuilder()
                .SetTitle(Text.Titulo_1)
                .AddChild(() => _screenCommand.PrintBigText(Text.Resposta_1_0), Text.Pergunta_1_0)
                .AddChild(() => _screenCommand.PrintBigText(Text.Resposta_1_1), Text.Pergunta_1_1)
                .AddChild(() => _screenCommand.PrintBigText(Text.Resposta_1_2), Text.Pergunta_1_2)
                .AddChild(() => _screenCommand.PrintBigText(Text.Resposta_1_3), Text.Pergunta_1_3)
                .AddChild(() => _screenCommand.PrintBigText(Text.Resposta_1_4), Text.Pergunta_1_4)
                .AddChild(() => _screenCommand.PrintBigText(Text.Resposta_1_5), Text.Pergunta_1_5)
                .AddChild(() => _screenCommand.PrintBigText(Text.Resposta_1_6), Text.Pergunta_1_6)
                .Build();

            return arvore;
        }
    }
}