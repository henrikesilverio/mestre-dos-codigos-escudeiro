using MDC.Escudeiro.Domain.Abstract;
using MDC.Escudeiro.Domain.Interfaces;
using MDC.Escudeiro.Domain.Models;
using System;

namespace MDC.Escudeiro.Exercicio.Console
{
    public class ExercicioSeis : AbstractExercise
    {
        private readonly IScreenCommand _screenCommand;

        public ExercicioSeis(IScreenCommand screenCommand)
        {
            _screenCommand = screenCommand;
        }

        public void Incrementar(ref int contador)
        {
            contador += 1;
        }

        public void Inicializar(out int contador)
        {
            contador = 0;
        }

        public override CommandNode[] GetBranches(CommandNode parent)
        {
            var commands = new CommandNode[2];

            for (int i = 0; i < commands.Length; i++)
            {
                commands[i] = new CommandNode
                {
                    Action = GetActions(i),
                    Order = i,
                    Parent = parent,
                    Title = Text.ResourceManager.GetString($"Pergunta-5-{i}"),
                };
            }

            return commands;
        }

        private Action GetActions(int index)
        {
            return index switch
            {
                0 => () =>
                {
                    Inicializar(out int contador);
                    Incrementar(ref contador);

                    _screenCommand.PrintBigText(Text.Resposta_5_0);
                }
                ,
                1 => () =>
                {
                    Inicializar(out int contador);
                    Incrementar(ref contador);

                    _screenCommand.PrintBigText(Text.Resposta_5_1);
                }
                ,
                _ => default,
            };
        }
    }
}