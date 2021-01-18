using MDC.Escudeiro.Domain.Builders;
using MDC.Escudeiro.Domain.Interfaces;
using MDC.Escudeiro.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MDC.Escudeiro.Exercicio.Console
{
    public class ExercicioNove : ExecicioBase, INodeBuilder
    {
        private readonly IScreenCommand _screenCommand;
        private readonly List<int> _numeros = new List<int>();
        private int _numero;

        public ExercicioNove(IScreenCommand screenCommand)
        {
            _screenCommand = screenCommand;
        }

        public CommandNode Build()
        {
            var arvore = new RootCommandNodeBuilder()
                .SetTitle(Text.Titulo_8)
                .AddChild(ValidateAction(() => ImprimirTodos()), Text.Pergunta_8_0)
                .AddChild(ValidateAction(() => _screenCommand.PrintBigText(string.Format(Text.Resposta_8_1, ObterOrdemCrescente()))), Text.Pergunta_8_1)
                .AddChild(ValidateAction(() => _screenCommand.PrintBigText(string.Format(Text.Resposta_8_2, ObterOrdemDecrescente()))), Text.Pergunta_8_2)
                .AddChild(ValidateAction(() => _screenCommand.PrintBigText(string.Format(Text.Resposta_8_3, ObterPrimeiroNumero()))), Text.Pergunta_8_3)
                .AddChild(ValidateAction(() => _screenCommand.PrintResult(string.Format(Text.Resposta_8_4, ObterUltimoNumero()))), Text.Pergunta_8_4)
                .AddChild(() =>
                {
                    InserirNoComeco();
                    ImprimirTodos();
                }, Text.Pergunta_8_5)
                .AddChild(() =>
                {
                    InserirNoFim();
                    ImprimirTodos();
                }, Text.Pergunta_8_6)
                .AddChild(() =>
                {
                    RemoverPrimeiro();
                    ImprimirTodos();
                }, Text.Pergunta_8_7)
                .AddChild(() =>
                {
                    RemoverUltimo();
                    ImprimirTodos();
                }, Text.Pergunta_8_8)
                .AddChild(ValidateAction(() => _screenCommand.PrintBigText(string.Format(Text.Resposta_8_9, ObterNumerosPares()))), Text.Pergunta_8_9)
                .AddChild(ValidateAction(() => _screenCommand.PrintResult(string.Format(Text.Resposta_8_10, ConsultarNumero()))), Text.Pergunta_8_10)
                .Build();

            return arvore;
        }

        public void ImprimirTodos()
        {
            _screenCommand.PrintBigText(string.Format(Text.Resposta_8_0, string.Join(" | ", _numeros)));
        }

        public string ObterOrdemCrescente()
        {
            return string.Join(" | ", _numeros.OrderBy(n => n).ToArray());
        }

        public string ObterOrdemDecrescente()
        {
            return string.Join(" | ", _numeros.OrderByDescending(n => n).ToArray());
        }

        public int ObterPrimeiroNumero()
        {
            return _numeros.FirstOrDefault();
        }

        public int ObterUltimoNumero()
        {
            return _numeros.Last();
        }

        public void InserirNoComeco()
        {
            ReceberValores();

            _numeros.Insert(0, _numero);
        }

        public void InserirNoFim()
        {
            ReceberValores();

            _numeros.Add(_numero);
        }

        public void RemoverPrimeiro()
        {
            _numeros.RemoveAt(0);
        }

        public void RemoverUltimo()
        {
            _numeros.RemoveAt(_numeros.Count - 1);
        }

        public string ObterNumerosPares()
        {
            var pares = string.Join(" | ", _numeros.Where(n => n % 2 == 0).ToArray());

            if (string.IsNullOrEmpty(pares))
            {
                return Text.ParesNaoEncontrados;
            }

            return pares;
        }

        public string ConsultarNumero()
        {
            ReceberValores();

            if (_numeros.Contains(_numero))
            {
                return _numero.ToString();
            }

            return Text.NumeroNaoEncontrado;
        }

        public int[] ObterTodos()
        {
            return _numeros.ToArray();
        }

        private Action ValidateAction(Action action)
        {
            return () =>
            {
                if (_numeros.Any())
                {
                    action();
                }
                else
                {
                    _screenCommand.PrintResult(Text.ListaVazia);
                }
            };
        }

        private void ReceberValores()
        {
            var numero = _screenCommand.InputValue(Text.InserirNumero);

            _numero = Convert.ToInt32(numero, GetNumberFormatInfo(numero));
        }
    }
}