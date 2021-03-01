using MDC.Escudeiro.Domain.Builders;
using MDC.Escudeiro.Domain.Interfaces;
using MDC.Escudeiro.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MDC.Escudeiro.Exercicio.Console
{
    public class ExercicioDois : ExecicioBase, INodeBuilder
    {
        private readonly IScreenCommand _screenCommand;
        private readonly List<Funcionario> _funcionarios = new List<Funcionario>();
        private Funcionario _funcionario;

        public ExercicioDois(IScreenCommand screenCommand) : base(screenCommand)
        {
            _screenCommand = screenCommand;
        }

        public CommandNode Build()
        {
            var arvore = new RootCommandNodeBuilder()
                .SetTitle(Text.Titulo_1)
                .AddChild(() =>
                {
                    var funcionario = InserirFuncionario();
                    _screenCommand.PrintResult(string.Format(Text.Resposta_1_0, funcionario.Nome, funcionario.Salario));
                }, Text.Pergunta_1_0)
                .AddChild(() =>
                {
                    ValidateList(_funcionarios, Text.ListaVazia, () =>
                    {
                        _screenCommand.PrintResult(string.Format(Text.Resposta_1_1, MaiorSalario()));
                    });
                }, Text.Pergunta_1_1)
                .AddChild(() =>
                {
                    ValidateList(_funcionarios, Text.ListaVazia, () =>
                    {
                        _screenCommand.PrintResult(string.Format(Text.Resposta_1_2, MenorSalario()));
                    });
                }, Text.Pergunta_1_2)
                .Build();

            return arvore;
        }

        public Funcionario InserirFuncionario()
        {
            ReceberValores();
            _funcionarios.Add(_funcionario);
            return _funcionario;
        }

        public decimal MaiorSalario()
        {
            var maior = decimal.Zero;
            if (_funcionarios.Any())
            {
                maior = _funcionarios[0].Salario;

                for (int i = 0; i < _funcionarios.Count; i++)
                {
                    if (_funcionarios[i].Salario >= maior)
                    {
                        maior = _funcionarios[i].Salario;
                    }
                }
            }

            return maior;
        }

        public decimal MenorSalario()
        {
            var menor = decimal.Zero;
            if (_funcionarios.Any())
            {
                menor = _funcionarios[0].Salario;
                var indice = 0;

                while (indice < _funcionarios.Count)
                {
                    if (_funcionarios[indice].Salario <= menor)
                    {
                        menor = _funcionarios[indice].Salario;
                    }

                    indice++;
                }
            }

            return menor;
        }

        private void ReceberValores()
        {
            var nome = _screenCommand.InputValue(Text.InserirNome);
            var salario = _screenCommand.InputValue(Text.InserirSalario);

            _funcionario = new Funcionario
            {
                Nome = nome,
                Salario = Convert.ToDecimal(salario, GetNumberFormatInfo(salario))
            };
        }
    }
}