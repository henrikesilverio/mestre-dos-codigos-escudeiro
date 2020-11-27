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
        private readonly List<Funcionario> _funcionarios = new List<Funcionario>();
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
            var salario = _screenCommand.InputValue(Text.InserirSalario);

            _funcionario = new Funcionario
            {
                Nome = nome,
                Salario = Convert.ToDecimal(salario, GetNumberFormatInfo(salario))
            };
        }

        private Action GetActions(int index)
        {
            return index switch
            {
                0 => () =>
                {
                    var funcionario = InserirFuncionario();
                    _screenCommand.PrintResult(string.Format(Text.Resposta_1_0, funcionario.Nome, funcionario.Salario));
                }
                ,
                1 => () => _screenCommand.PrintResult(string.Format(Text.Resposta_1_1, MaiorSalario())),
                2 => () => _screenCommand.PrintResult(string.Format(Text.Resposta_1_2, MenorSalario())),
                _ => default,
            };
        }
    }
}