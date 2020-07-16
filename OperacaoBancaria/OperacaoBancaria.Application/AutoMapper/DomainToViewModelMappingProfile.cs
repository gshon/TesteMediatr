using AutoMapper;
using OperacaoBancaria.Application.ViewModels;
using OperacaoBancaria.Domain.ContaCorrente.Model;

namespace OperacaoBancaria.Application.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {
            CreateMap<ContaCorrente, RegistrarContaCorrenteViewModel>();
        }
    }
}
