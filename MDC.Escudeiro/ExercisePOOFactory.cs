using MDC.Escudeiro.Domain.Abstract;
using MDC.Escudeiro.Domain.Interfaces;
using MDC.Escudeiro.Exercicio.POO;

namespace MDC.Escudeiro
{
    public class ExercisePOOFactory : IExerciseFactory
    {
        public int Size => 4;

        public AbstractExercise Manufacture(int index)
        {
            return index switch
            {
                0 => new ExercicioUm(_screenCommandConsole),
                1 => new ExercicioDois(_screenCommandConsole),
                2 => new ExercicioTres(_screenCommandConsole),
                3 => new ExercicioQuatro(_screenCommandConsole),
                _ => default,
            };
        }

        private readonly static ScreenCommandConsole _screenCommandConsole = new ScreenCommandConsole { MarkCharacter = "*" };
    }
}