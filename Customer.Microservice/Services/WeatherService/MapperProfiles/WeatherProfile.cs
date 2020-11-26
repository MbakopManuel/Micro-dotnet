using AutoMapper;
using Customer.Microservice.Repositories.Weather.DtoModels;
using Customer.Microservice.Services.Weather.DomainModels;

namespace Customer.Microservice.Services.Weather.MapperProfiles
{
    public class WeatherProfile : Profile
    {
        public WeatherProfile()
        {
            CreateMap<WeatherDomainModel, WeatherDtoModel>().ReverseMap();
        }
    }
}
