using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using AutoMapper;

using Sample.Microservice.Repositories.Weather;
using Sample.Microservice.Services.Weather;
using Sample.Microservice.Operations.Weather.MapperProfiles;
using Sample.Microservice.Services.Weather.MapperProfiles;

using Sample.Microservice.Repositories.Sample;
using Sample.Microservice.Services.Sample;
using Sample.Microservice.Operations.Sample.MapperProfiles;
using Sample.Microservice.Services.Sample.MapperProfiles;


namespace Sample.Microservice.Services {


    public class Service{

        private readonly IServiceCollection _services;
        public Service(IServiceCollection services){
            _services = services;
           
        }

        public Service(){}

        public void addService(){
            _services.TryAddScoped<IWeatherRepository, WeatherRepository>();
            _services.TryAddTransient<IWeatherService, WeatherService>();
            
            _services.TryAddScoped<ISampleRepository, SampleRepository>();
            _services.TryAddTransient<ISampleService, SampleService>();
          
        }

        public IEnumerable<Profile> addProfile(){
            var profiles = new Profile[] { 
                new WeatherProfile(),
                new WeatherResponseProfile(),

                new SampleProfile(),
                new CreateSampleRequestProfile(),
                new UpdateSampleRequestProfile()
             };

             return profiles;
        }
        

    }

}