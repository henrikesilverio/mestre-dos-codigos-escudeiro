using MDC.Escudeiro.Domain.Abstract;
using MDC.Escudeiro.Domain.Interfaces;
using MDC.Escudeiro.Exercicio.Teorico;

namespace MDC.Escudeiro
{
    public class ExerciseTheoreticalFactory : IExerciseFactory
    {
        public int Size => 2;

        public AbstractExercise Manufacture(int index)
        {
            return index switch
            {
                0 => new ExercicioUm(_screenCommandConsole),
                1 => new ExercicioDois(_screenCommandConsole),
                _ => default,
            };
        }

        private readonly static ScreenCommandConsole _screenCommandConsole = new ScreenCommandConsole { MarkCharacter = "*" };
    }
}