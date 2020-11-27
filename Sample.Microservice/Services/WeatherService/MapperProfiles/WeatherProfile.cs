using AutoMapper;
using Sample.Microservice.Repositories.Weather.DtoModels;
using Sample.Microservice.Services.Weather.DomainModels;

namespace Sample.Microservice.Services.Weather.MapperProfiles
{
    public class WeatherProfile : Profile
    {
        public WeatherProfile()
        {
            CreateMap<WeatherDomainModel, WeatherDtoModel>().ReverseMap();
        }
    }
}
