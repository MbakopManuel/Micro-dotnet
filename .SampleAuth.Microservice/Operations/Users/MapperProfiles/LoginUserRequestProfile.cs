using AutoMapper;
using SampleAuth.Microservice.Operations.User.ViewModels;
using SampleAuth.Microservice.Services.User.DomainModels;

namespace SampleAuth.Microservice.Operations.User.MapperProfiles
{
    public class LoginUserRequestProfile : Profile
    {
        public LoginUserRequestProfile()
        {
            CreateMap<LoginUserViewModel, UserDomainModel>().ReverseMap();
        }
    }
}
