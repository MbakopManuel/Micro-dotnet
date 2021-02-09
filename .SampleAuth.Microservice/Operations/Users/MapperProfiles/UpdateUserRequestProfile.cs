using AutoMapper;
using SampleAuth.Microservice.Operations.User.ViewModels;
using SampleAuth.Microservice.Services.User.DomainModels;

namespace SampleAuth.Microservice.Operations.User.MapperProfiles
{
    public class UpdateUserRequestProfile : Profile
    {
        public UpdateUserRequestProfile()
        {
            CreateMap<UpdateUserViewModel, UserDomainModel>().ReverseMap();
        }
    }
}
