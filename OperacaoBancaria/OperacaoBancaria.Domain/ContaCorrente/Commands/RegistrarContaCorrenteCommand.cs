using System;

namespace OperacaoBancaria.Domain.ContaCorrente.Commands
{
    public class RegistrarContaCorrenteCommand : BaseContaCorrenteCommand
    {
        public RegistrarContaCorrenteCommand(Guid id, string nome, string cpf, long numeroConta)
        {
            Id = id;
            Nome = nome;
            Cpf = cpf;
            NumeroConta = numeroConta;
        }
    }
}
