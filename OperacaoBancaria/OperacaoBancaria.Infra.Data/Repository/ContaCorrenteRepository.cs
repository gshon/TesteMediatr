using OperacaoBancaria.Domain.ContaCorrente.Interface;
using OperacaoBancaria.Domain.ContaCorrente.Model;
using OperacaoBancaria.Infra.Data.Context;

namespace OperacaoBancaria.Infra.Data.Repository
{
    public class ContaCorrenteRepository : Repository<ContaCorrente>, IContaCorrenteRepository
    {
        public ContaCorrenteRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
