using AutoMapper;
using Aplicacao = Domain.Application;

namespace Application.Core
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Aplicacao, Aplicacao>().ReverseMap();
        }
    }
}