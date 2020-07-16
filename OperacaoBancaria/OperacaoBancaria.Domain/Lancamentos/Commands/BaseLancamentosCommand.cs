using OperacaoBancaria.Domain.Core.Command;
using OperacaoBancaria.Domain.Enum;
using System;

namespace OperacaoBancaria.Domain.Lancamentos.Commands
{
    public class BaseLancamentosCommand : Command
    {
        public Guid Id { get; protected set; }
        public TipoOperacao TipoOperacao { get; protected set; }
        public decimal Valor { get; protected set; }
        public decimal Saldo { get; protected set; }
        public long NumeroConta { get; protected set; }
    }
}
