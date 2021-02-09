using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Sample.Microservice.Services.Weather.DomainModels;

namespace Sample.Microservice.Services.Weather {

    public interface IWeatherService{

        IEnumerable<WeatherDomainModel> Get();
        
    }

}