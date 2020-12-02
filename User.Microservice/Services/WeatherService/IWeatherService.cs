using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using User.Microservice.Services.Weather.DomainModels;

namespace User.Microservice.Services.Weather {

    public interface IWeatherService{

        IEnumerable<WeatherDomainModel> Get();
        
    }

}