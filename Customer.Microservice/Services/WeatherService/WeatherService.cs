using System;
using AutoMapper;
using System.Collections.Generic;
using System.Threading.Tasks;
using Customer.Microservice.Services.Weather.DomainModels;
using Customer.Microservice.Services.Weather;
using Customer.Microservice.Repositories.Weather;

namespace Customer.Microservice.Services.Weather {

    public class WeatherService : IWeatherService {

        private readonly IWeatherRepository _weatherRepository;
        private readonly IMapper _mapper;
        public WeatherService(IWeatherRepository weatherRepository, IMapper mapper) {
            _weatherRepository = weatherRepository;
            _mapper = mapper;
        }

        public  IEnumerable<WeatherDomainModel> Get(){
            var weather =  _weatherRepository.Get();
            return _mapper.Map<List<WeatherDomainModel>>(weather);
        }

    }

}