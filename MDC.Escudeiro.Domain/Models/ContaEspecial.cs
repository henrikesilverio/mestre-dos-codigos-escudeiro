using MDC.Escudeiro.Domain.Abstract;
using System;

namespace MDC.Escudeiro.Domain.Models
{
    public class ContaEspecial : ContaBancariaAbstract
    {
        private readonly double _limite;

        public ContaEspecial(double limite)
        {
            _limite = limite;
        }

        public override void Depositar(double valor)
        {
            Saldo += valor;
        }

        public override void Sacar(double valor)
        {
            if (Saldo + _limite < valor)
            {
                throw new Exception($"O valor de: {valor:C2} - o saldo de: {Saldo:C2}, é maior que o limite.");
            }

            Saldo -= valor;
        }

        public override string MostrarDados()
        {
            return $"Conta Especial: {NumeroDaConta} | Saldo: {Saldo:C2} | Limite: {_limite:C2}";
        }
    }
}