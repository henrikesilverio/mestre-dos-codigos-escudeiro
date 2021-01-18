using MDC.Escudeiro.Domain.Builders;
using MDC.Escudeiro.Domain.Interfaces;
using MDC.Escudeiro.Domain.Models;

namespace MDC.Escudeiro.Exercicio.Console
{
    public class ExercicioTres : ExecicioBase, INodeBuilder
    {
        private readonly IScreenCommand _screenCommand;

        public ExercicioTres(IScreenCommand screenCommand)
        {
            _screenCommand = screenCommand;
        }

        public CommandNode Build()
        {
            var arvore = new RootCommandNodeBuilder()
                .SetTitle(Text.Titulo_2)
                .AddChild(MultiplosTres, Text.Pergunta_2_0)
                .Build();

            return arvore;
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
    }
}