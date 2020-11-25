using MDC.Escudeiro.Domain.Abstract;
using MDC.Escudeiro.Domain.Interfaces;
using MDC.Escudeiro.Domain.Models;
using System;
using System.Collections.Generic;

namespace MDC.Escudeiro.Exercicio.Console
{
    public class ExercicioQuatro : AbstractExercise
    {
        private readonly IScreenCommand _screenCommand;
        private static readonly List<Aluno> _alunos = new List<Aluno>();
        private Aluno _aluno;

        public ExercicioQuatro(IScreenCommand screenCommand)
        {
            _screenCommand = screenCommand;
        }

        public Aluno InserirAluno()
        {
            ReceberValores();
            _alunos.Add(_aluno);
            return _aluno;
        }

        public void RemoverTodos()
        {
            _alunos.Clear();
        }

        public List<Aluno> AlunosComNotaMaiorQueSete()
        {
            var alunos = new List<Aluno>();
            foreach (var aluno in _alunos)
            {
                if (aluno.Nota > 7)
                {
                    alunos.Add(aluno);
                }
            }

            return alunos;
        }

        public override CommandNode[] GetBranches(CommandNode parent)
        {
            var commands = new CommandNode[]
            {
                new CommandNode
                {
                    Action = () =>
                    {
                        var aluno = InserirAluno();
                        _screenCommand.PrintResult($"Aluno nome: {aluno.Nome}, nota: {aluno.Nota} inserido");
                    },
                    Parent = parent,
                    Order = 0,
                    Title = "({0}) Inserir aluno"
                },
                new CommandNode
                {
                    Action = () =>
                    {
                        var alunos = AlunosComNotaMaiorQueSete();
                        alunos.ForEach(a => _screenCommand.PrintResult($"Aluno nome: {a.Nome}, nota: {a.Nota}"));
                    },
                    Parent = parent,
                    Order = 1,
                    Title = "({0}) Imprima todos os alunos com média superior a 7"
                }
            };

            return commands;
        }

        private void ReceberValores()
        {
            var nome = _screenCommand.InputValue("Insira o nome: ");
            var nota = _screenCommand.InputValue("Insira a nota: ");

            _aluno = new Aluno
            {
                Nome = nome,
                Nota = Convert.ToDecimal(nota, GetNumberFormatInfo(nota))
            };
        }
    }
}