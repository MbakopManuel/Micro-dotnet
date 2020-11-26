using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Customer.Microservice.Services.Weather.DomainModels;

namespace Customer.Microservice.Services.Weather {

    public interface IWeatherService{

        IEnumerable<WeatherDomainModel> Get();
        
    }

}