using AutoMapper;
using SampleAuth.Microservice.Repositories.Role.DtoModels;
using SampleAuth.Microservice.Services.Role.DomainModels;

namespace SampleAuth.Microservice.Services.Role.MapperProfiles
{
    public class RoleProfile : Profile
    {
        public RoleProfile()
        {
            CreateMap<RoleDomainModel, RoleDtoModel>().ReverseMap();
        }
    }
}
