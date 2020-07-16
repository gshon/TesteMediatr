using FluentValidation;
using OperacaoBancaria.Domain.Core.Models;
using OperacaoBancaria.Domain.Enum;
using System;

namespace OperacaoBancaria.Domain.Lancamentos.Model
{
    public class Lancamentos : Entity<Lancamentos>
    {
        public TipoOperacao TipoOperacao { get; private set; }
        public decimal Valor { get; private set; }
        public decimal Saldo { get; private set; }
        public Guid ContaCorrenteId { get; private set; }
        public DateTime DataLancamento { get; private set; }

        public Lancamentos()
        {

        }

        public override bool EhValido()
        {
            Validar();
            return ValidationResult.IsValid;
        }

        private void Validar()
        {
            ValidarValor();
        }
        private void ValidarValor()
        {
            RuleFor(c => c.Valor)
                .NotEmpty().WithMessage("O valor do lançamento precisa ser informado")
                .GreaterThan(1).WithMessage("Valor precisa ser maior que zero");
        }

        public static class LancamentosFactory
        {
            public static Lancamentos NovoLancamentos(decimal valor, TipoOperacao tipoOperacao, decimal saldo, DateTime dataLancamento, Guid contaCorrenteId)
            {
                var lancamento = new Lancamentos
                {
                    ContaCorrenteId = contaCorrenteId,
                    Valor = valor,
                    TipoOperacao = tipoOperacao,
                    Saldo = saldo,
                    DataLancamento = dataLancamento
                };

                return lancamento;
            }

            public static Lancamentos ObterExtratoLancamento(decimal valor, decimal saldo, DateTime dataLancamento, Guid contaCorrenteId)
            {
                var lancamento = new Lancamentos
                {
                    Valor = valor,
                    Saldo = saldo,
                    DataLancamento = dataLancamento,
                    ContaCorrenteId = contaCorrenteId
                };

                return lancamento;
            }

            public static Lancamentos ObterUltimoLancamento(Guid id, decimal valor, decimal saldo, DateTime dataLancamento, Guid contaCorrenteId)
            {
                var lancamento = new Lancamentos
                {
                    Id = id,
                    Valor = valor,
                    Saldo = saldo,
                    DataLancamento = dataLancamento,
                    ContaCorrenteId = contaCorrenteId
                };

                return lancamento;
            }
        }
    }
}
