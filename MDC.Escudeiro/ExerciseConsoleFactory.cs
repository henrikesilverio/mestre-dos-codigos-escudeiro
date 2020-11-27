using MDC.Escudeiro.Domain.Abstract;
using MDC.Escudeiro.Domain.Interfaces;
using MDC.Escudeiro.Exercicio.Console;

namespace MDC.Escudeiro
{
    public class ExerciseConsoleFactory : IExerciseFactory
    {
        public int Size => 9;

        public AbstractExercise Manufacture(int index)
        {
            return index switch
            {
                0 => new ExercicioUm(_screenCommandConsole),
                1 => new ExercicioDois(_screenCommandConsole),
                2 => new ExercicioTres(_screenCommandConsole),
                3 => new ExercicioQuatro(_screenCommandConsole),
                4 => new ExercicioCinco(_screenCommandConsole),
                5 => new ExercicioSeis(_screenCommandConsole),
                6 => new ExercicioSete(_screenCommandConsole),
                7 => new ExercicioOito(_screenCommandConsole),
                8 => new ExercicioNove(_screenCommandConsole),
                _ => default,
            };
        }

        private readonly static ScreenCommandConsole _screenCommandConsole = new ScreenCommandConsole { MarkCharacter = "*" };
    }
}