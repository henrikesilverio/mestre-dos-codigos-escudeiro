using MDC.Escudeiro.Domain.Abstract;
using System;

namespace MDC.Escudeiro.Domain.Models
{
    public class ContaCorrente : ContaBancariaAbstract
    {
        private readonly double _taxaDeOperacao;

        public ContaCorrente(double taxaDeOperacao)
        {
            _taxaDeOperacao = taxaDeOperacao;
        }

        public override void Depositar(double valor)
        {
            var valorFinal = valor - (valor * _taxaDeOperacao);

            Saldo += valorFinal;
        }

        public override void Sacar(double valor)
        {
            var valorFinal = valor + (valor * _taxaDeOperacao);

            if (Saldo - valorFinal < 0)
            {
                throw new Exception($"O valor de: {valor:C2} + taxa de operação de: {_taxaDeOperacao:N2}, é maior que saldo.");
            }

            Saldo -= valorFinal;
        }

        public override string MostrarDados()
        {
            return $"Conta Corrente: {NumeroDaConta} | Saldo: {Saldo:C2} | Taxa de operação: {_taxaDeOperacao:N2}";
        }
    }
}