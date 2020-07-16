using OperacaoBancaria.Domain.Enum;
using System;

namespace OperacaoBancaria.Domain.Lancamentos.Commands
{
    public class RegistrarLancamentoCommand : BaseLancamentosCommand
    {
        public RegistrarLancamentoCommand(Guid id, decimal valor, TipoOperacao tipoOperacao, long numeroConta)
        {
            Id = id;
            Valor = valor;
            TipoOperacao = tipoOperacao;
            NumeroConta = numeroConta;
        }
    }
}
