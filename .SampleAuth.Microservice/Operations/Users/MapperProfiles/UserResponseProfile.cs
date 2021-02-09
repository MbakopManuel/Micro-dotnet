using AutoMapper;
using SampleAuth.Microservice.Operations.User.ViewModels;
using SampleAuth.Microservice.Services.User.DomainModels;

namespace SampleAuth.Microservice.Operations.User.MapperProfiles
{
    public class UserResponseProfile : Profile
    {
        public UserResponseProfile()
        {
            CreateMap<UserViewModel, UserDomainModel>().ReverseMap();
        }
    }
}
