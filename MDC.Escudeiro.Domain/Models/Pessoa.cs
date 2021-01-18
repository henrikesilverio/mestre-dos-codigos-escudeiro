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
            var dataAtual = DateTime.Now;
            var diferencaEmAnos = dataAtual.Year - DataNascimento.Year;

            if (diferencaEmAnos <= 0)
            {
                return 0;
            }

            if (DataNascimento.Month <= dataAtual.Month && DataNascimento.Day <= dataAtual.Day)
            {
                return diferencaEmAnos;
            }

            return diferencaEmAnos - 1;
        }
    }
}