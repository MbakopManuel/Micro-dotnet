using System;

namespace SampleAuth.Microservice.Repositories.Weather.DtoModels {

    public class WeatherDtoModel {
        public DateTime Date { get; set; }

        public int TemperatureC { get; set; }

        public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);

        public string Summary { get; set; }
    }

}