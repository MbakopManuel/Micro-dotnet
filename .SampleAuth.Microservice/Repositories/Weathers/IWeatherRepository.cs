using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SampleAuth.Microservice.Repositories.Weather.DtoModels;

namespace SampleAuth.Microservice.Repositories.Weather {

    public interface IWeatherRepository{

        IEnumerable<WeatherDtoModel> Get();

        
    }

}