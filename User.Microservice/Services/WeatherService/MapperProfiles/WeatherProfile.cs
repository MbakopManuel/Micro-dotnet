using AutoMapper;
using User.Microservice.Repositories.Weather.DtoModels;
using User.Microservice.Services.Weather.DomainModels;

namespace User.Microservice.Services.Weather.MapperProfiles
{
    public class WeatherProfile : Profile
    {
        public WeatherProfile()
        {
            CreateMap<WeatherDomainModel, WeatherDtoModel>().ReverseMap();
        }
    }
}
