using MDC.Escudeiro.Domain.Abstract;
using MDC.Escudeiro.Domain.Interfaces;
using MDC.Escudeiro.Domain.Models;
using System;

namespace MDC.Escudeiro.Exercicio.POO
{
    public class ExercicioDois : AbstractExercise
    {
        private readonly IScreenCommand _screenCommand;
        private Pessoa _pessoa;

        public ExercicioDois(IScreenCommand screenCommand)
        {
            _screenCommand = screenCommand;
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

        public override CommandNode[] GetBranches(CommandNode parent)
        {
            var commands = new CommandNode[3];

            for (int i = 0; i < commands.Length; i++)
            {
                commands[i] = new CommandNode
                {
                    Action = GetActions(i),
                    Order = i,
                    Parent = parent,
                    Title = Text.ResourceManager.GetString($"Pergunta-1-{i}"),
                };
            }

            return commands;
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

        private Action GetActions(int index)
        {
            return index switch
            {
                0 => () => InserirPessoa(),
                1 => () =>
                {
                    var idade = CalcularIdade();
                    _screenCommand.PrintResult(string.Format(Text.Resposta_1_0, idade));
                }
                ,
                2 => () => ImprimirDados(),
                _ => default,
            };
        }
    }
}