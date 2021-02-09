using AutoMapper;
using SampleAuth.Microservice.Repositories.Weather.DtoModels;
using SampleAuth.Microservice.Services.Weather.DomainModels;

namespace SampleAuth.Microservice.Services.Weather.MapperProfiles
{
    public class WeatherProfile : Profile
    {
        public WeatherProfile()
        {
            CreateMap<WeatherDomainModel, WeatherDtoModel>().ReverseMap();
        }
    }
}
