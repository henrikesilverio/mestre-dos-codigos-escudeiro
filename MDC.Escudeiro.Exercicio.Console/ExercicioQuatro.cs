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
        private readonly List<Aluno> _alunos = new List<Aluno>();
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
            var commands = new CommandNode[2];

            for (int i = 0; i < commands.Length; i++)
            {
                commands[i] = new CommandNode
                {
                    Action = GetActions(i),
                    Order = i,
                    Parent = parent,
                    Title = Text.ResourceManager.GetString($"Pergunta-3-{i}"),
                };
            }

            return commands;
        }

        private void ReceberValores()
        {
            var nome = _screenCommand.InputValue(Text.InserirNome);
            var nota = _screenCommand.InputValue(Text.InserirNota);

            _aluno = new Aluno
            {
                Nome = nome,
                Nota = Convert.ToDecimal(nota, GetNumberFormatInfo(nota))
            };
        }

        private Action GetActions(int index)
        {
            return index switch
            {
                0 => () =>
                {
                    var aluno = InserirAluno();
                    _screenCommand.PrintResult(string.Format(Text.Resposta_3_0, aluno.Nome, aluno.Nota));
                }
                ,
                1 => () =>
                {
                    var alunos = AlunosComNotaMaiorQueSete();
                    alunos.ForEach(a => _screenCommand.PrintResult(string.Format(Text.Resposta_3_1, a.Nome, a.Nota)));
                }
                ,
                _ => default,
            };
        }
    }
}