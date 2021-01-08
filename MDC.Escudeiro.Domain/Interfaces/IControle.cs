namespace MDC.Escudeiro.Domain.Interfaces
{
    public interface IControle
    {
        int AumentarVolume();

        int DecrementarCanal();

        int DiminuirVolume();

        int IncrementarCanal();

        int IrParaCanal(int numeroCanal);
    }
}
