using System;

namespace MDC.Escudeiro.Domain.Models
{
    public class Pessoa
    {
        private string Nome;
        private DateTime DataNascimento;
        private decimal Altura;

        public void IncluirNome(string nome)
        {
            Nome = nome;
        }

        public void IncluirDataNascimento(DateTime dataNascimento)
        {
            DataNascimento = dataNascimento;
        }

        public void IncluirAltura(decimal altura)
        {
            Altura = altura;
        }

        public string ObterNome() => Nome;

        public DateTime ObterDataNascimento() => DataNascimento;

        public decimal ObterAltura() => Altura;

        public string ImprimirDados()
        {
            return $"Nome: {Nome}, Data de nascimento: {DataNascimento:dd/MM/yyyy}, Altura: {Altura}";
        }

        public int CalcularIdade()
        {
            var diferencaEmMilissegundos = (DateTime.Now - DataNascimento).Ticks;

            if (diferencaEmMilissegundos < 0)
            {
                return 0;
            }

            return new DateTime(diferencaEmMilissegundos).Year - 1;
        }
    }
}