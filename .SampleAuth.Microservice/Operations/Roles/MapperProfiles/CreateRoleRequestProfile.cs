using AutoMapper;
using SampleAuth.Microservice.Operations.Role.ViewModels;
using SampleAuth.Microservice.Services.Role.DomainModels;

namespace SampleAuth.Microservice.Operations.Role.MapperProfiles
{
    public class CreateRoleRequestProfile : Profile
    {
        public CreateRoleRequestProfile()
        {
            CreateMap<CreateRoleViewModel, RoleDomainModel>().ReverseMap();
        }
    }
}
