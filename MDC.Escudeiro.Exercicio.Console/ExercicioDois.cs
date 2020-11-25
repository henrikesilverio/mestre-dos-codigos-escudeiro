using MDC.Escudeiro.Domain.Abstract;
using MDC.Escudeiro.Domain.Interfaces;
using MDC.Escudeiro.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MDC.Escudeiro.Exercicio.Console
{
    public class ExercicioDois : AbstractExercise
    {
        private readonly IScreenCommand _screenCommand;
        private static readonly List<Funcionario> _funcionarios = new List<Funcionario>();
        private Funcionario _funcionario;

        public ExercicioDois(IScreenCommand screenCommand)
        {
            _screenCommand = screenCommand;
        }

        public Funcionario InserirFuncionario()
        {
            ReceberValores();
            _funcionarios.Add(_funcionario);
            return _funcionario;
        }

        public void RemoverTodos()
        {
            _funcionarios.Clear();
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

                for (int i = 0; i < _funcionarios.Count; i++)
                {
                    if (_funcionarios[i].Salario <= menor)
                    {
                        menor = _funcionarios[i].Salario;
                    }
                }
            }

            return menor;
        }

        public override CommandNode[] GetBranches(CommandNode parent)
        {
            var commands = new CommandNode[]
            {
                new CommandNode
                {
                    Action = () =>
                    {
                        var funcionario = InserirFuncionario();
                        _screenCommand.PrintResult($"Funcionario nome: {funcionario.Nome}, salário: {funcionario.Salario} inserido");
                    },
                    Parent = parent,
                    Order = 0,
                    Title = "({0}) Inserir funcionários"
                },
                new CommandNode
                {
                    Action = () => _screenCommand.PrintResult($"O maior salário é: {MaiorSalario()}"),
                    Parent = parent,
                    Order = 1,
                    Title = "({0}) Imprima o maior salário"
                },
                new CommandNode
                {
                    Action = () => _screenCommand.PrintResult($"O menor salário é {MenorSalario()}"),
                    Parent = parent,
                    Order = 2,
                    Title = "({0}) Imprima o menor salário"
                }
            };

            return commands;
        }

        private void ReceberValores()
        {
            var nome = _screenCommand.InputValue("Insira o nome: ");
            var salario = _screenCommand.InputValue("Insira o salário: ");

            _funcionario = new Funcionario
            {
                Nome = nome,
                Salario = Convert.ToDecimal(salario, GetNumberFormatInfo(salario))
            };
        }
    }
}