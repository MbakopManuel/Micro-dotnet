using AutoMapper;
using SampleAuth.Microservice.Operations.Weather.ViewModels;
using SampleAuth.Microservice.Services.Weather.DomainModels;

namespace SampleAuth.Microservice.Operations.Weather.MapperProfiles
{
    public class WeatherResponseProfile : Profile
    {
        public WeatherResponseProfile()
        {
            CreateMap<WeatherDomainModel, WeatherViewModel>().ReverseMap();
        }
    }
}
