using OperacaoBancaria.Domain.Core.Command;
using System;

namespace OperacaoBancaria.Domain.ContaCorrente.Commands
{
    public class BaseContaCorrenteCommand : Command
    {
        public Guid Id { get; protected set; }
        public string Nome { get; protected set; }
        public string Cpf { get; protected set; }
        public long NumeroConta { get; protected set; }
    }
}
