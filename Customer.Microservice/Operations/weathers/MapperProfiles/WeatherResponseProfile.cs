using AutoMapper;
using Customer.Microservice.Operations.Weather.ViewModels;
using Customer.Microservice.Services.Weather.DomainModels;

namespace Customer.Microservice.Operations.Weather.MapperProfiles
{
    public class WeatherResponseProfile : Profile
    {
        public WeatherResponseProfile()
        {
            CreateMap<WeatherDomainModel, WeatherViewModel>().ReverseMap();
        }
    }
}
