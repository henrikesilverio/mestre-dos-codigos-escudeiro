using MDC.Escudeiro.Domain.Builders;
using MDC.Escudeiro.Domain.Interfaces;
using MDC.Escudeiro.Domain.Models;

namespace MDC.Escudeiro.Exercicio.Console
{
    public class ExercicioSeis : ExecicioBase, INodeBuilder
    {
        private readonly IScreenCommand _screenCommand;

        public ExercicioSeis(IScreenCommand screenCommand) : base(screenCommand)
        {
            _screenCommand = screenCommand;
        }

        public CommandNode Build()
        {
            var arvore = new RootCommandNodeBuilder()
                .SetTitle(Text.Titulo_5)
                .AddChild(() =>
                {
                    Inicializar(out int contador);
                    Incrementar(ref contador);
                    _screenCommand.PrintBigText(Text.Resposta_5_0);
                }, Text.Pergunta_5_0)
                .AddChild(() =>
                {
                    Inicializar(out int contador);
                    Incrementar(ref contador);
                    _screenCommand.PrintBigText(Text.Resposta_5_1);
                }, Text.Pergunta_5_1)
                .Build();

            return arvore;
        }

        public void Incrementar(ref int contador)
        {
            contador += 1;
        }

        public void Inicializar(out int contador)
        {
            contador = 0;
        }
    }
}