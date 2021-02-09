using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Sample.Microservice.Repositories.Weather.DtoModels;

namespace Sample.Microservice.Repositories.Weather {

    public interface IWeatherRepository{

        IEnumerable<WeatherDtoModel> Get();

        
    }

}