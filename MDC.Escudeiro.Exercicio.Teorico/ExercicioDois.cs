﻿using MDC.Escudeiro.Domain.Abstract;
using MDC.Escudeiro.Domain.Interfaces;
using MDC.Escudeiro.Domain.Models;

namespace MDC.Escudeiro.Exercicio.Teorico
{
    public class ExercicioDois : AbstractExercise
    {
        private readonly IScreenCommand _screenCommand;

        public ExercicioDois(IScreenCommand screenCommand)
        {
            _screenCommand = screenCommand;
        }

        public override CommandNode[] GetBranches(CommandNode parent)
        {
            var commands = new CommandNode[4];

            for (int i = 0; i < commands.Length; i++)
            {
                var resposta = Text.ResourceManager.GetString($"Resposta-1-{i}");
                commands[i] = new CommandNode
                {
                    Action = () => _screenCommand.PrintBigText(resposta),
                    Order = i,
                    Parent = parent,
                    Title = Text.ResourceManager.GetString($"Pergunta-1-{i}"),
                };
            }

            return commands;
        }
    }
}