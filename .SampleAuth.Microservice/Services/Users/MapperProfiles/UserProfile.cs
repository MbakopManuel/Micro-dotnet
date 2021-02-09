using AutoMapper;
using SampleAuth.Microservice.Repositories.User.DtoModels;
using SampleAuth.Microservice.Services.User.DomainModels;

namespace SampleAuth.Microservice.Services.User.MapperProfiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<UserDomainModel, UserDtoModel>().ReverseMap();
        }
    }
}
