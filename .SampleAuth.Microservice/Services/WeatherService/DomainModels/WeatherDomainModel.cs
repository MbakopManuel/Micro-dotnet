using System;

namespace SampleAuth.Microservice.Services.Weather.DomainModels{

    public class WeatherDomainModel {
        public DateTime Date { get; set; }

        public int TemperatureC { get; set; }

        public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);

        public string Summary { get; set; }
    }

}