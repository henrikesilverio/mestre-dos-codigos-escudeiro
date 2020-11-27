using MDC.Escudeiro.Domain.Abstract;
using MDC.Escudeiro.Domain.Interfaces;
using MDC.Escudeiro.Domain.Models;

namespace MDC.Escudeiro.Exercicio.POO
{
    public class ExercicioUm : AbstractExercise
    {
        private readonly IScreenCommand _screenCommand;

        public ExercicioUm(IScreenCommand screenCommand)
        {
            _screenCommand = screenCommand;
        }

        public override CommandNode[] GetBranches(CommandNode parent)
        {
            var commands = new CommandNode[7];

            for (int i = 0; i < commands.Length; i++)
            {
                commands[i] = new CommandNode
                {
                    Action = () => _screenCommand.PrintBigText("Resposta"),
                    Order = i,
                    Parent = parent,
                    Title = Opcoes()[i],
                };
            }

            return commands;
        }

        private static string[] Opcoes()
        {
            return new string[]
            {
                "({0}) O que é POO?",
                "({0}) O que é polimorfismo?",
                "({0}) O que é abstração?",
                "({0}) O que é encapsulamento?",
                "({0}) Quando usar uma classe abstrata e quando devo usar uma interface?",
                "({0}) O que faz as interfaces IDisposable, IComparable, ICloneable e IEnumerable?",
                "({0}) Existe herança múltipla (de classes) em C#?",
            };
        }
    }
}
