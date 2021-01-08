using MDC.Escudeiro.Domain.Abstract;
using MDC.Escudeiro.Domain.Interfaces;
using MDC.Escudeiro.Domain.Models;
using System;
using System.Linq.Expressions;

namespace MDC.Escudeiro.Exercicio.POO
{
    public class ExercicioTres : AbstractExercise
    {
        private readonly IScreenCommand _screenCommand;
        private TipoConta _tipoConta;
        private ContaBancariaAbstract _contaBancaria;

        public ExercicioTres(IScreenCommand screenCommand)
        {
            _screenCommand = screenCommand;
        }

        public ContaBancariaAbstract CriarConta()
        {
            ReceberValores();
            ImprimirDados(_contaBancaria);

            return _contaBancaria;
        }

        public void Depositar()
        {
            ExecutarOperacao(x => x.Depositar);
        }

        public void Sacar()
        {
            ExecutarOperacao(x => x.Sacar);
        }

        public void ImprimirDados(IImprimivel conta)
        {
            _screenCommand.PrintResult(conta.MostrarDados());
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
                    Title = Text.ResourceManager.GetString($"Pergunta-2-{i}"),
                };
            }

            return commands;
        }

        private void ExecutarOperacao(Expression<Func<ContaBancariaAbstract, Action<double>>> expressao)
        {
            if (_contaBancaria == null)
            {
                _screenCommand.PrintError(Text.ContaNaoCriada);
                return;
            }

            var valor = _screenCommand.InputValue(Text.InserirValor);

            try
            {
                var operacao = expressao.Compile().Invoke(_contaBancaria);
                operacao(Convert.ToDouble(valor, GetNumberFormatInfo(valor)));
                ImprimirDados(_contaBancaria);
            }
            catch (Exception ex)
            {
                _screenCommand.PrintError(ex.Message);
            }
        }

        private void ReceberValores()
        {
            _screenCommand.PrintInfo(Text.TipoConta);
            var tipoConta = _screenCommand.InputValue(Text.InserirTipoConta);
            var numeroConta = _screenCommand.InputValue(Text.InserirNumeroConta);
            var saldo = _screenCommand.InputValue(Text.InserirSaldo);

            _tipoConta = (TipoConta)Convert.ToInt32(tipoConta);

            if (_tipoConta == TipoConta.Corrente)
            {
                var taxaDeOperacao = ((double)Convert.ToInt32(_screenCommand.InputValue(Text.InserirTaxaOperacao))) / 100;

                _contaBancaria = new ContaCorrente(taxaDeOperacao)
                {
                    NumeroDaConta = Convert.ToInt64(numeroConta),
                    Saldo = Convert.ToDouble(saldo, GetNumberFormatInfo(saldo))
                };
            }
            if (_tipoConta == TipoConta.Especial)
            {
                var limite = Convert.ToDouble(_screenCommand.InputValue(Text.InserirLimite));

                _contaBancaria = new ContaEspecial(limite)
                {
                    NumeroDaConta = Convert.ToInt64(numeroConta),
                    Saldo = Convert.ToDouble(saldo, GetNumberFormatInfo(saldo))
                };
            }
        }

        private Action GetActions(int index)
        {
            return index switch
            {
                0 => () => CriarConta(),
                1 => () => Depositar(),
                2 => () => Sacar(),
                _ => default,
            };
        }
    }
}