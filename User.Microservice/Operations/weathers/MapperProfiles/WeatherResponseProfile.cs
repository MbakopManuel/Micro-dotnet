using AutoMapper;
using User.Microservice.Operations.Weather.ViewModels;
using User.Microservice.Services.Weather.DomainModels;

namespace User.Microservice.Operations.Weather.MapperProfiles
{
    public class WeatherResponseProfile : Profile
    {
        public WeatherResponseProfile()
        {
            CreateMap<WeatherDomainModel, WeatherViewModel>().ReverseMap();
        }
    }
}
