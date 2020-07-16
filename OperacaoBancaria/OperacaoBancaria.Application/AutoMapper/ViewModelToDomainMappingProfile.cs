using AutoMapper;
using OperacaoBancaria.Application.ViewModels;
using OperacaoBancaria.Application.ViewModels.Lancamentos;
using OperacaoBancaria.Domain.ContaCorrente.Commands;
using OperacaoBancaria.Domain.Lancamentos.Commands;

namespace OperacaoBancaria.Application.AutoMapper
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public ViewModelToDomainMappingProfile()
        {
            CreateMap<RegistrarContaCorrenteViewModel, RegistrarContaCorrenteCommand>()
                .ConstructUsing(c => new RegistrarContaCorrenteCommand(c.Id ,c.Nome, c.Cpf, c.NumeroConta));

            CreateMap<RegistrarLancamentosViewModel, RegistrarLancamentoCommand>()
                .ConstructUsing(c => new RegistrarLancamentoCommand(c.Id, c.Valor, c.TipoOperacao, c.NumeroConta));
        }
    }
}
