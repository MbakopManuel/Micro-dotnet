using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Customer.Microservice.Repositories.Weather.DtoModels;

namespace Customer.Microservice.Repositories.Weather {

    public interface IWeatherRepository{

        IEnumerable<WeatherDtoModel> Get();

        
    }

}