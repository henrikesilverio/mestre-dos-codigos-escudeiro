using MDC.Escudeiro.Domain.Builders;
using MDC.Escudeiro.Domain.Interfaces;
using MDC.Escudeiro.Domain.Models;
using System;

namespace MDC.Escudeiro.Exercicio.POO
{
    public class ExercicioDois : ExecicioBase, INodeBuilder
    {
        private readonly IScreenCommand _screenCommand;
        private Pessoa _pessoa;

        public ExercicioDois(IScreenCommand screenCommand) : base(screenCommand)
        {
            _screenCommand = screenCommand;
        }

        public CommandNode Build()
        {
            var arvore = new RootCommandNodeBuilder()
                .SetTitle(Text.Titulo_0)
                .AddChild(() => InserirPessoa(), Text.Pergunta_1_0)
                .AddChild(() =>
                {
                    var idade = CalcularIdade();
                    _screenCommand.PrintResult(string.Format(Text.Resposta_1_0, idade));
                }, Text.Pergunta_1_1)
                .AddChild(() => ImprimirDados(), Text.Pergunta_1_2)
                .Build();

            return arvore;
        }

        public Pessoa InserirPessoa()
        {
            ReceberValores();
            return _pessoa;
        }

        public int CalcularIdade() => _pessoa.CalcularIdade();

        public void ImprimirDados()
        {
            _screenCommand.PrintResult(_pessoa.ImprimirDados());
        }

        private void ReceberValores()
        {
            var nome = _screenCommand.InputValue(Text.InserirNome);
            var dataNascimento = _screenCommand.InputValue(Text.InserirData);
            var altura = _screenCommand.InputValue(Text.InserirAltura);

            _pessoa = new Pessoa();
            _pessoa.IncluirNome(nome);
            _pessoa.IncluirDataNascimento(DateTime.Parse(dataNascimento));
            _pessoa.IncluirAltura(Convert.ToDecimal(altura, GetNumberFormatInfo(altura)));
        }
    }
}