using OperacaoBancaria.Domain.Interfaces;
using System;

namespace OperacaoBancaria.Domain.Lancamentos.Interface
{
    public interface ILancamentosRepository : IRepository<Model.Lancamentos>
    {
        public Model.Lancamentos ObterUltimoLancamento(Guid contaCorrenteId);
    }
}
