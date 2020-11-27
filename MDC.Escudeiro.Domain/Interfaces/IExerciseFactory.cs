using MDC.Escudeiro.Domain.Abstract;

namespace MDC.Escudeiro.Domain.Interfaces
{
    public interface IExerciseFactory
    {
        public int Size { get; }

        AbstractExercise Manufacture(int index);
    }
}