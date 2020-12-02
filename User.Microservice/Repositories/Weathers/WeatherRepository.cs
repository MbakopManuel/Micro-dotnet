using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Threading.Tasks;
using User.Microservice.Data;
using Microsoft.EntityFrameworkCore;
using User.Microservice.Repositories.Weather.DtoModels;

namespace User.Microservice.Repositories.Weather {


    public class WeatherRepository : IWeatherRepository {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        public readonly IApplicationDbContext _context;
        public WeatherRepository(IApplicationDbContext context){
            _context = context;
        }

        public  IEnumerable<WeatherDtoModel> Get(){
             var rng = new Random();
             
            return Enumerable.Range(1, 5).Select(index => new WeatherDtoModel
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            })
            .ToArray();
        }



    }

}