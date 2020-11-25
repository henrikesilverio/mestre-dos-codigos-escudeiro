using MDC.Escudeiro.Domain.Abstract;
using MDC.Escudeiro.Domain.Interfaces;
using MDC.Escudeiro.Domain.Models;

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
            var commands = new CommandNode[]
            {
                new CommandNode
                {
                    Action = () =>
                    {
                        Inicializar(out int contador);
                        Incrementar(ref contador);

                        _screenCommand.PrintResult("Usado para indicar que o parâmetro passado pode ser modificado pelo método.");
                        _screenCommand.PrintBigText("Por padrão, um tipo de referência passado para um método terá " +
                                                    "todas as alterações feitas em seus valores refletidas fora do método também. " +
                                                    "Se você atribuir o tipo de referência a um novo tipo de referência dentro do método, " +
                                                    "essas alterações serão apenas locais para o método.");
                    },
                    Parent = parent,
                    Order = 0,
                    Title = "({0}) Definição do ref"
                },
                new CommandNode
                {
                    Action = () =>
                    {
                        Inicializar(out int contador);
                        Incrementar(ref contador);

                        _screenCommand.PrintResult("Usado para indicar que o parâmetro passado deve ser modificado pelo método.");
                        _screenCommand.PrintBigText("Usando o modificador out, inicializamos uma variável dentro do método. " +
                                                    "Como ref, tudo o que acontece no método altera a variável fora do método. " +
                                                    "Com ref, você tem a opção de não fazer alterações no parâmetro. " +
                                                    "Ao usar out, você deve inicializar o parâmetro que passa dentro do método.");
                    },
                    Parent = parent,
                    Order = 1,
                    Title = "({0}) Definição do out"
                }
            };

            return commands;
        }
    }
}
