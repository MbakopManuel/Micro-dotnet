using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using User.Microservice.Repositories.Weather.DtoModels;

namespace User.Microservice.Repositories.Weather {

    public interface IWeatherRepository{

        IEnumerable<WeatherDtoModel> Get();

        
    }

}