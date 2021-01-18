using MDC.Escudeiro.Domain.Builders;
using MDC.Escudeiro.Domain.Interfaces;
using MDC.Escudeiro.Domain.Models;
using System;
using System.Collections.Generic;

namespace MDC.Escudeiro.Exercicio.Console
{
    public class ExercicioQuatro : ExecicioBase, INodeBuilder
    {
        private readonly IScreenCommand _screenCommand;
        private readonly List<Aluno> _alunos = new List<Aluno>();
        private Aluno _aluno;

        public ExercicioQuatro(IScreenCommand screenCommand)
        {
            _screenCommand = screenCommand;
        }

        public CommandNode Build()
        {
            var arvore = new RootCommandNodeBuilder()
                .SetTitle(Text.Titulo_3)
                .AddChild(() =>
                {
                    var aluno = InserirAluno();
                    _screenCommand.PrintResult(string.Format(Text.Resposta_3_0, aluno.Nome, aluno.Nota));
                }, Text.Pergunta_3_0)
                .AddChild(() =>
                {
                    var alunos = AlunosComNotaMaiorQueSete();
                    alunos.ForEach(a => _screenCommand.PrintResult(string.Format(Text.Resposta_3_1, a.Nome, a.Nota)));
                }, Text.Pergunta_3_1)
                .Build();

            return arvore;
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
    }
}