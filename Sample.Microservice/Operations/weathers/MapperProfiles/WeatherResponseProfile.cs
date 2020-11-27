using AutoMapper;
using Sample.Microservice.Operations.Weather.ViewModels;
using Sample.Microservice.Services.Weather.DomainModels;

namespace Sample.Microservice.Operations.Weather.MapperProfiles
{
    public class WeatherResponseProfile : Profile
    {
        public WeatherResponseProfile()
        {
            CreateMap<WeatherDomainModel, WeatherViewModel>().ReverseMap();
        }
    }
}
