using OperacaoBancaria.Domain.Lancamentos.Interface;
using OperacaoBancaria.Domain.Lancamentos.Model;
using OperacaoBancaria.Infra.Data.Context;
using System;
using System.Linq;

namespace OperacaoBancaria.Infra.Data.Repository
{
    public class LancamentosRepository : Repository<Lancamentos>, ILancamentosRepository
    {
        private readonly ApplicationDbContext _context;
        public LancamentosRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public Lancamentos ObterUltimoLancamento(Guid contaCorrenteId)
        {
            var lancamento = _context.Lancamentos.Where(x => x.ContaCorrenteId == contaCorrenteId).OrderByDescending(i => i.DataLancamento).FirstOrDefault();

            if (lancamento == null)
                return lancamento;

            var ultimoLancamento = Lancamentos.LancamentosFactory.ObterUltimoLancamento(lancamento.Id, lancamento.Valor, lancamento.Saldo, lancamento.DataLancamento, lancamento.ContaCorrenteId);

            return ultimoLancamento;
        }
    }
}
