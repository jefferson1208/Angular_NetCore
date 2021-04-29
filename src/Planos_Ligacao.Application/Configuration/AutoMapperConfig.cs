using AutoMapper;
using PlanosLigacao.Application.ViewModels.Planos;
using PlanosLigacao.Domain.Entities.Planos;

namespace PlanosLigacao.Application.Configuration
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {
            CreateMap<Plano, PlanoViewModel>().ReverseMap();
            CreateMap<CustoPlano, CustoPlanoViewModel>().ReverseMap();
            CreateMap<CalculoPlano, CalculoPlanoViewModel>().ReverseMap();
            
        }
    }
}
