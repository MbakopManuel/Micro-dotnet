using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SampleAuth.Microservice.Services.Weather.DomainModels;

namespace SampleAuth.Microservice.Services.Weather {

    public interface IWeatherService{

        IEnumerable<WeatherDomainModel> Get();
        
    }

}