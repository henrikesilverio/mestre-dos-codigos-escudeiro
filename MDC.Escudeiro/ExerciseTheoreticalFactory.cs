using MDC.Escudeiro.Domain.Abstract;
using MDC.Escudeiro.Domain.Interfaces;
using MDC.Escudeiro.Exercicio.Teorico;

namespace MDC.Escudeiro
{
    public class ExerciseTheoreticalFactory : IExerciseFactory
    {
        public int Size => 1;

        public AbstractExercise Manufacture(int index)
        {
            return index switch
            {
                0 => new ExercicioUm(_screenCommandConsole),
                _ => default,
            };
        }

        private readonly static ScreenCommandConsole _screenCommandConsole = new ScreenCommandConsole { MarkCharacter = "*" };
    }
}
