using MDC.Escudeiro.Domain.Interfaces;

namespace MDC.Escudeiro.Domain.Abstract
{
    public abstract class ContaBancariaAbstract : IImprimivel
    {
        public long NumeroDaConta { get; set; }
        public double Saldo { get; set; }

        public abstract void Sacar(double valor);

        public abstract void Depositar(double valor);

        public abstract string MostrarDados();
    }
}